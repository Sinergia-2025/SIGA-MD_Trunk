Public Class Empleados
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Empleados"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Empleados"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(entidad, TipoSP._I))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(entidad, TipoSP._D))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(entidad, TipoSP._U))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.Empleados(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Empleados(Me.da).Empleados_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)

      Dim emp As Entidades.Empleado = DirectCast(entidad, Entidades.Empleado)

      Dim sqlEmp As SqlServer.Empleados = New SqlServer.Empleados(da)
      Dim rObjetivos As Reglas.EmpleadosObjetivos = New Reglas.EmpleadosObjetivos(da)
      Dim rEmpleadosSucursales As EmpleadosSucursales = New EmpleadosSucursales(da)
      Select Case tipo
         Case TipoSP._I

            If emp.IdEmpleado = 0 Then
               emp.IdEmpleado = sqlEmp.Empleados_GetIdMaximo("IdEmpleado") + 1
            End If

            sqlEmp.Empleados_I(emp.TipoDocEmpleado, emp.NroDocEmpleado, emp.NombreEmpleado, emp.TelefonoEmpleado,
                               emp.CelularEmpleado, emp.EsVendedor, emp.EsComprador, emp.EsCobrador, emp.IdUsuario, emp.IdUsuarioMovil, emp.ComisionPorVenta,
                               emp.Direccion, emp.IdLocalidad, emp.GeoLocalizacionLat, emp.GeoLocalizacionLng,
                               emp.IdEmpleado, emp.Color, emp.NivelAutorizacion, emp.Clave, emp.DebitoDirecto,
                               emp.IdBanco, emp.IdDispositivo, emp.DebitoTarjeta, emp.IdTarjeta, emp.EsChofer, emp.IdTransportista, emp.EsRespProd,
                               emp.IdCategoriaEmpleado, emp.ValorHoraProduccion, emp.CobraPremioCobranza, emp.EntidadCobranza)
            ActualizarComisionesVarios(emp)
            InsertaObjetivos(emp)

            emp.EmpleadoSucursal.IdSucursal = actual.Sucursal.IdSucursal
            emp.EmpleadoSucursal.IdEmpleado = emp.IdEmpleado
            rEmpleadosSucursales.InsertaOActualiza(emp.EmpleadoSucursal)

         Case TipoSP._U
            sqlEmp.Empleados_U(emp.TipoDocEmpleado, emp.NroDocEmpleado, emp.NombreEmpleado, emp.TelefonoEmpleado,
                               emp.CelularEmpleado, emp.EsVendedor, emp.EsComprador, emp.EsCobrador, emp.IdUsuario, emp.IdUsuarioMovil, emp.ComisionPorVenta,
                               emp.Direccion, emp.IdLocalidad, emp.GeoLocalizacionLat, emp.GeoLocalizacionLng,
                               emp.IdEmpleado, emp.Color, emp.NivelAutorizacion, emp.Clave, emp.DebitoDirecto,
                               emp.IdBanco, emp.IdDispositivo, emp.DebitoTarjeta, emp.IdTarjeta, emp.EsChofer, emp.IdTransportista, emp.EsRespProd,
                               emp.IdCategoriaEmpleado, emp.ValorHoraProduccion, emp.CobraPremioCobranza, emp.EntidadCobranza)

            ActualizarComisionesVarios(emp)
            ActualizarObjetivos(emp)

            emp.EmpleadoSucursal.IdSucursal = actual.Sucursal.IdSucursal
            emp.EmpleadoSucursal.IdEmpleado = emp.IdEmpleado
            rEmpleadosSucursales.InsertaOActualiza(emp.EmpleadoSucursal)

         Case TipoSP._D
            rEmpleadosSucursales.Borrar(emp.IdEmpleado)
            BorrarComisionesVarios(emp)
            BorraObjetivos(emp)
            sqlEmp.Empleados_D(emp.IdEmpleado)
      End Select

   End Sub

   Public Sub BorrarComisionesVarios(empleado As Entidades.Empleado)
      Dim sql1 As SqlServer.EmpleadosComisionesMarcas = New SqlServer.EmpleadosComisionesMarcas(da)
      Dim sql2 As SqlServer.EmpleadosComisionesRubros = New SqlServer.EmpleadosComisionesRubros(da)
      Dim sql3 As SqlServer.EmpleadosComisionesProductos = New SqlServer.EmpleadosComisionesProductos(da)

      sql1.EmpleadosComisionesMarcas_D(empleado.IdEmpleado, 0)
      sql2.EmpleadosComisionesRubros_D(empleado.IdEmpleado, 0)
      sql3.EmpleadosComisionesProductos_D(empleado.IdEmpleado, "")
   End Sub

   Private Sub ActualizarComisionesVarios(empleado As Entidades.Empleado)
      Dim listado As DataSet = empleado.Comisiones

      If listado Is Nothing Then Exit Sub

      Dim sql1 As SqlServer.EmpleadosComisionesMarcas = New SqlServer.EmpleadosComisionesMarcas(da)
      Dim sql2 As SqlServer.EmpleadosComisionesRubros = New SqlServer.EmpleadosComisionesRubros(da)
      Dim sql3 As SqlServer.EmpleadosComisionesProductos = New SqlServer.EmpleadosComisionesProductos(da)
      Dim sql4 As SqlServer.EmpleadosComisionesSubRubros = New SqlServer.EmpleadosComisionesSubRubros(da)
      Dim sql5 As SqlServer.EmpleadosComisionesSubSubRubros = New SqlServer.EmpleadosComisionesSubSubRubros(da)

      For Each rd As DataTable In listado.Tables
         If rd.TableName = Entidades.Empleado.ComisionesMarcasTableName Then
            If rd.GetChanges(DataRowState.Deleted) IsNot Nothing Then
               For Each dr As DataRow In rd.GetChanges(DataRowState.Deleted).Rows
                  sql1.EmpleadosComisionesMarcas_D(Integer.Parse(dr("IdEmpleado", DataRowVersion.Original).ToString()),
                                                   Int32.Parse(dr("IdMarca", DataRowVersion.Original).ToString()))
               Next
            End If

            For Each dr As DataRow In rd.Rows
               If dr.RowState = DataRowState.Added Then
                  sql1.EmpleadosComisionesMarcas_I(Integer.Parse(dr("IdEmpleado").ToString()),
                                                   Int32.Parse(dr("IdMarca").ToString()),
                                                   Decimal.Parse(dr("Comision").ToString()))
               End If
            Next
         End If

         If rd.TableName = Entidades.Empleado.ComisionesRubrosTableName Then
            If rd.GetChanges(DataRowState.Deleted) IsNot Nothing Then
               For Each dr As DataRow In rd.GetChanges(DataRowState.Deleted).Rows
                  sql2.EmpleadosComisionesRubros_D(Integer.Parse(dr("IdEmpleado", DataRowVersion.Original).ToString()),
                                                   Int32.Parse(dr("IdRubro", DataRowVersion.Original).ToString()))
               Next
            End If

            For Each dr As DataRow In rd.Rows
               If dr.RowState = DataRowState.Added Then
                  sql2.EmpleadosComisionesRubros_I(Integer.Parse(dr("IdEmpleado").ToString()),
                                                   Int32.Parse(dr("IdRubro").ToString()),
                                                   Decimal.Parse(dr("Comision").ToString()))
               End If

            Next
         End If
         '--
         If rd.TableName = Entidades.Empleado.ComisionesSubRubrosTableName Then
            If rd.GetChanges(DataRowState.Deleted) IsNot Nothing Then
               For Each dr As DataRow In rd.GetChanges(DataRowState.Deleted).Rows
                  sql4.EmpleadosComisionesSubRubros_D(Integer.Parse(dr("IdEmpleado", DataRowVersion.Original).ToString()),
                                                      Int32.Parse(dr("IdRubro", DataRowVersion.Original).ToString()),
                                                      Int32.Parse(dr("IdSubRubro", DataRowVersion.Original).ToString()))
               Next
            End If

            For Each dr As DataRow In rd.Rows
               If dr.RowState = DataRowState.Added Then
                  sql4.EmpleadosComisionesSubRubros_I(Integer.Parse(dr("IdEmpleado").ToString()),
                                                   Int32.Parse(dr("IdRubro").ToString()),
                                                   Int32.Parse(dr("IdSubRubro").ToString()),
                                                   Decimal.Parse(dr("Comision").ToString()))
               End If

            Next
         End If
         '--
         If rd.TableName = Entidades.Empleado.ComisionesSubSubRubrosTableName Then
            If rd.GetChanges(DataRowState.Deleted) IsNot Nothing Then
               For Each dr As DataRow In rd.GetChanges(DataRowState.Deleted).Rows
                  sql5.EmpleadosComisionesSubSubRubros_D(Integer.Parse(dr("IdEmpleado", DataRowVersion.Original).ToString()),
                                                         Int32.Parse(dr("IdRubro", DataRowVersion.Original).ToString()),
                                                         Int32.Parse(dr("IdSubRubro", DataRowVersion.Original).ToString()),
                                                         Int32.Parse(dr("IdSubSubRubro", DataRowVersion.Original).ToString()))
               Next
            End If

            For Each dr As DataRow In rd.Rows
               If dr.RowState = DataRowState.Added Then
                  sql5.EmpleadosComisionesSubSubRubros_I(Integer.Parse(dr("IdEmpleado").ToString()),
                                                         Int32.Parse(dr("IdRubro").ToString()),
                                                         Int32.Parse(dr("IdSubRubro").ToString()),
                                                         Int32.Parse(dr("IdSubSubRubro").ToString()),
                                                         Decimal.Parse(dr("Comision").ToString()))
               End If

            Next
         End If

         '--
         If rd.TableName = Entidades.Empleado.ComisionesProductosTableName Then
            If rd.GetChanges(DataRowState.Deleted) IsNot Nothing Then
               For Each dr As DataRow In rd.GetChanges(DataRowState.Deleted).Rows
                  sql3.EmpleadosComisionesProductos_D(Integer.Parse(dr("IdEmpleado", DataRowVersion.Original).ToString()),
                                                      dr("IdProducto", DataRowVersion.Original).ToString())
               Next
            End If

            For Each dr As DataRow In rd.Rows
               If dr.RowState = DataRowState.Added Then
                  sql3.EmpleadosComisionesProductos_I(Integer.Parse(dr("IdEmpleado").ToString()),
                                                      dr("IdProducto").ToString(),
                                                      Decimal.Parse(dr("Comision").ToString()))
               End If
            Next
         End If
      Next
   End Sub
   Public Sub InsertaObjetivos(entidad As Eniac.Entidades.Empleado)
      If entidad.EmpleadoObjetivo IsNot Nothing Then
         Dim sql As SqlServer.EmpleadosObjetivos = New SqlServer.EmpleadosObjetivos(da)
         For Each ent As Entidades.EmpleadoObjetivo In entidad.EmpleadoObjetivo
            sql.EmpleadosObjetivos_I(ent.IdEmpleado, ent.PeriodoFiscal, ent.ImporteObjetivo)
         Next
      End If
   End Sub
   Public Sub BorraObjetivos(entidad As Eniac.Entidades.Empleado)
      If entidad.EmpleadoObjetivo IsNot Nothing Then
         Dim sql As SqlServer.EmpleadosObjetivos = New SqlServer.EmpleadosObjetivos(da)
         sql.EmpleadosObjetivos_D(entidad.IdEmpleado)
      End If
   End Sub
   Public Sub ActualizarObjetivos(entidad As Eniac.Entidades.Empleado)
      If entidad.EmpleadoObjetivo IsNot Nothing Then
         BorraObjetivos(entidad)
         InsertaObjetivos(entidad)
      End If
   End Sub

   Public Sub Inserta(entidad As Eniac.Entidades.Entidad)
      Dim emp As Entidades.Empleado = DirectCast(entidad, Entidades.Empleado)
      Dim sqlEmp As SqlServer.Empleados = New SqlServer.Empleados(da)
      sqlEmp.Empleados_I(emp.TipoDocEmpleado, emp.NroDocEmpleado, emp.NombreEmpleado, emp.TelefonoEmpleado,
                         emp.CelularEmpleado, emp.EsVendedor, emp.EsComprador, emp.EsCobrador, emp.IdUsuario, emp.IdUsuarioMovil, emp.ComisionPorVenta,
                         emp.Direccion, emp.IdLocalidad, emp.GeoLocalizacionLat, emp.GeoLocalizacionLng,
                         emp.IdEmpleado, emp.Color, emp.NivelAutorizacion, emp.Clave, emp.DebitoDirecto,
                         emp.IdBanco, emp.IdDispositivo, emp.DebitoTarjeta, emp.IdTarjeta, emp.EsChofer, emp.IdTransportista, emp.EsRespProd,
                         emp.IdCategoriaEmpleado, emp.ValorHoraProduccion, emp.CobraPremioCobranza, emp.EntidadCobranza)
   End Sub

   Protected Sub CargarUno(o As Entidades.Empleado, dr As DataRow)

      With o
         .TipoDocEmpleado = dr.Field(Of String)("TipoDocEmpleado")
         .NroDocEmpleado = dr.Field(Of String)("NroDocEmpleado")
         .NombreEmpleado = dr.Field(Of String)("NombreEmpleado")
         If Not String.IsNullOrEmpty(dr("TelefonoEmpleado").ToString()) Then
            .TelefonoEmpleado = dr("TelefonoEmpleado").ToString()
         End If
         If Not String.IsNullOrEmpty(dr("CelularEmpleado").ToString()) Then
            .CelularEmpleado = dr("CelularEmpleado").ToString()
         End If
         .EsVendedor = dr.Field(Of Boolean)("EsVendedor")
         .EsComprador = dr.Field(Of Boolean)("EsComprador")
         .EsCobrador = dr.Field(Of Boolean)("EsCobrador")
         '-- REQ-37326.- --------------------------------------
         .EsRespProd = dr.Field(Of Boolean)("EsRespProd")
         '-- REQ-33530.- --------------------------------------
         .EsChofer = dr.Field(Of Boolean)("EsChofer")
         If Not String.IsNullOrEmpty(dr("IdTransportista").ToString()) Then
            .IdTransportista = Integer.Parse(dr("IdTransportista").ToString())
         End If
         '-----------------------------------------------------
         .IdUsuario = dr.Field(Of String)("IdUsuario")
         .IdUsuarioMovil = dr.Field(Of String)("IdUsuarioMovil")

         .ComisionPorVenta = dr.Field(Of Decimal)("ComisionPorVenta")
         .Direccion = dr.Field(Of String)("Direccion")
         .IdLocalidad = dr.Field(Of Integer)("IdLocalidad")
         If Not String.IsNullOrEmpty(dr("GeoLocalizacionLat").ToString()) Then
            .GeoLocalizacionLat = Double.Parse(dr("GeoLocalizacionLat").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("GeoLocalizacionLng").ToString()) Then
            .GeoLocalizacionLng = Double.Parse(dr("GeoLocalizacionLng").ToString())
         End If
         .IdEmpleado = dr.Field(Of Integer)("IdEmpleado")

         .Color = dr.Field(Of Integer?)(Entidades.Empleado.Columnas.Color.ToString())

         .NivelAutorizacion = dr.Field(Of Short)(Entidades.Empleado.Columnas.NivelAutorizacion.ToString())

         .Clave = dr.Field(Of String)(Entidades.Empleado.Columnas.Clave.ToString())

         .EmpleadoObjetivo = New Reglas.EmpleadosObjetivos(da).GetTodos(.IdEmpleado)
         .DebitoDirecto = dr.Field(Of Boolean)(Eniac.Entidades.Empleado.Columnas.DebitoDirecto.ToString())

         .IdBanco = dr.Field(Of Integer?)(Eniac.Entidades.Empleado.Columnas.IdBanco.ToString()).IfNull()

         .NombreBanco = dr.Field(Of String)(Eniac.Entidades.Empleado.Columnas.NombreBanco.ToString())
         .IdDispositivo = dr.Field(Of String)(Eniac.Entidades.Empleado.Columnas.IdDispositivo.ToString())

         .EmpleadoSucursal = New EmpleadosSucursales(da).GetUno(actual.Sucursal.IdSucursal, .IdEmpleado)

         '-.PE-31509.-
         .DebitoTarjeta = dr.Field(Of Boolean)(Eniac.Entidades.Empleado.Columnas.DebitoTarjeta.ToString())

         .IdTarjeta = dr.Field(Of Integer?)(Eniac.Entidades.Empleado.Columnas.IdTarjeta.ToString()).IfNull()
         .NombreTarjeta = dr.Field(Of String)(Eniac.Entidades.Empleado.Columnas.NombreTarjeta.ToString())
         .IdCategoriaEmpleado = dr.Field(Of Integer?)(Eniac.Entidades.Empleado.Columnas.IdCategoriaEmpleado.ToString()).IfNull()
         .ValorHoraProduccion = dr.Field(Of Decimal?)("ValorHoraProd").IfNull()

         '-- REQ-42860.-
         .CobraPremioCobranza = dr.Field(Of Boolean)("CobraPremioCobranza")
         .EntidadCobranza = dr.Field(Of String)(Eniac.Entidades.Empleado.Columnas.EntidadCobranza.ToString())
      End With

   End Sub


#End Region

#Region "Metodos Publicos"
   Public Function GetFiltradoPorCodigo(idEmpleado As Integer) As DataTable
      Return New SqlServer.Empleados(Me.da).Empleados_Buscador(idEmpleado)
   End Function

   Public Function GetFiltradoPorNombre(nombre As String) As DataTable
      Return New SqlServer.Empleados(Me.da).Empleados_GA(Entidades.Publicos.TiposEmpleados.TODOS, String.Empty, String.Empty, nombre, conDebitoTarjeta:=False)
   End Function

   Public Function GetTodos(incluyeComisiones As Boolean) As List(Of Entidades.Empleado)
      Return CargaLista(GetAll(),
                        Sub(o, dr)
                           CargarUno(o, dr)
                           If incluyeComisiones Then CargaComisiones(o)
                        End Sub,
                        Function() New Entidades.Empleado())
   End Function

   Public Function GetPorTipo(tipoEmpleado As Entidades.Publicos.TiposEmpleados,
                              idUsuario As String, conDebitoTarjeta As Boolean ) As List(Of Entidades.Empleado)
      Return CargaLista(New SqlServer.Empleados(Me.da).Empleados_GA(tipoEmpleado, idUsuario, String.Empty, String.Empty, conDebitoTarjeta),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Empleado())
   End Function

   Public Function GetUno(idEmpleado As Integer) As Entidades.Empleado
      Return GetUno(idEmpleado, AccionesSiNoExisteRegistro.Excepcion)
   End Function

   Public Function GetUno(idEmpleado As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Empleado
      Return CargaComisiones(CargaEntidad(New SqlServer.Empleados(Me.da).Empleados_G1(idEmpleado),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Empleado(),
                          accion, Function() String.Format("No existe Empleado con Id '{0}'", idEmpleado)))
   End Function

   Public Function GetPorTipoNro(tipoDocEmpleado As String, nroDocEmpleado As String) As List(Of Entidades.Empleado)
      Return CargaLista(New SqlServer.Empleados(Me.da).Empleados_G(tipoDocEmpleado, nroDocEmpleado),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Empleado())
   End Function

   Public Function GetPorClave(clave As String, accion As AccionesSiNoExisteRegistro) As Entidades.Empleado
      Dim dt As DataTable = New SqlServer.Empleados(Me.da).Empleados_G1_PorClave(clave)
      If dt.Rows.Count > 1 Then
         Throw New Exception("La clave está registrada para más de un vendedor")
      End If
      Return CargaComisiones(CargaEntidad(dt,
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Empleado(),
                          accion, Function() String.Format("No existe Empleado con la clave proporcionada")))
   End Function

   Public Function GetPorUsuario(idUsuario As String) As DataTable
      Return New SqlServer.Empleados(Me.da).Empleados_GA(Entidades.Publicos.TiposEmpleados.TODOS, idUsuario, String.Empty, String.Empty, conDebitoTarjeta:=False)
   End Function
   Public Function GetPorNombreExacto(nombre As String) As DataTable
      Return New SqlServer.Empleados(Me.da).Empleados_GA(Entidades.Publicos.TiposEmpleados.TODOS, String.Empty, nombre, String.Empty, conDebitoTarjeta:=False)
   End Function

   Public Function GetIdMaximo() As Integer
      Return New SqlServer.Empleados(Me.da).Empleados_GetIdMaximo()
   End Function

   Public Function ExisteEmpleado(idEmpleado As Integer) As Boolean
      Dim dt As DataTable = New SqlServer.Empleados(Me.da).Empleados_G1(idEmpleado)
      If dt.Rows.Count > 0 Then
         Return True
      Else
         Return False
      End If
   End Function

   Public Sub ActualizarGeolocalizacion(pTipoDocumento As String, pNroDocumento As String, Lat As Double, lng As Double)

      Dim stbQuery As StringBuilder = New StringBuilder()
      Try
         da.OpenConection()
         da.BeginTransaction()
         da.Command.Connection = da.Connection
         da.Command.Transaction = da.Transaction
         da.Command.CommandType = CommandType.Text

         With stbQuery
            .Append("UPDATE Empleados  SET ")
            .Append("  GeoLocalizacionLat=" & Lat & ", ")
            .Append("  GeoLocalizacionLng=" & lng & " ")
            .Append(" WHERE TipoDocEmpleado ='" & pTipoDocumento & "' ")
            .Append("   AND NroDocEmpleado ='" & pNroDocumento.Trim() & "' ")
         End With
         da.Command.CommandText = stbQuery.ToString

         da.Command.ExecuteNonQuery()

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Function CargaComisiones(empleado As Entidades.Empleado) As Entidades.Empleado
      If empleado.Comisiones Is Nothing Then
         empleado.Comisiones = New DataSet()
      End If
      If empleado.Comisiones.Tables.Contains(Entidades.Empleado.ComisionesMarcasTableName) Then
         empleado.Comisiones.Tables.Remove(Entidades.Empleado.ComisionesMarcasTableName)
      End If
      If empleado.Comisiones.Tables.Contains(Entidades.Empleado.ComisionesProductosTableName) Then
         empleado.Comisiones.Tables.Remove(Entidades.Empleado.ComisionesProductosTableName)
      End If
      If empleado.Comisiones.Tables.Contains(Entidades.Empleado.ComisionesRubrosTableName) Then
         empleado.Comisiones.Tables.Remove(Entidades.Empleado.ComisionesRubrosTableName)
      End If
      If empleado.Comisiones.Tables.Contains(Entidades.Empleado.ComisionesSubRubrosTableName) Then
         empleado.Comisiones.Tables.Remove(Entidades.Empleado.ComisionesSubRubrosTableName)
      End If
      If empleado.Comisiones.Tables.Contains(Entidades.Empleado.ComisionesSubSubRubrosTableName) Then
         empleado.Comisiones.Tables.Remove(Entidades.Empleado.ComisionesSubSubRubrosTableName)
      End If
      'Dim dt As DataTable

      empleado.Comisiones.Tables.Add(New SqlServer.EmpleadosComisionesMarcas(Me.da).GetEmpleadosComisionesMarcas(empleado.IdEmpleado))
      empleado.Comisiones.Tables.Add(New SqlServer.EmpleadosComisionesRubros(Me.da).GetEmpleadosComisionesRubros(empleado.IdEmpleado))
      empleado.Comisiones.Tables.Add(New SqlServer.EmpleadosComisionesSubRubros(Me.da).GetEmpleadosComisionesSubRubros(empleado.IdEmpleado))
      empleado.Comisiones.Tables.Add(New SqlServer.EmpleadosComisionesSubSubRubros(Me.da).GetEmpleadosComisionesSubSubRubros(empleado.IdEmpleado))

      empleado.Comisiones.Tables.Add(New SqlServer.EmpleadosComisionesProductos(Me.da).GetEmpleadosComisionesProductos(empleado.IdEmpleado))

      Return empleado

   End Function

   Public Function GetVendedoresDelCliente(idCliente As Long) As List(Of Eniac.Entidades.Empleado)
      Dim result As List(Of Eniac.Entidades.Empleado) = New List(Of Eniac.Entidades.Empleado)()

      For Each dr As DataRow In New SqlServer.Empleados(Me.da).GetVendedoresDelCliente(idCliente).Rows
         Dim o As Eniac.Entidades.Empleado = New Eniac.Entidades.Empleado()
         Me.CargarUno(o, dr)
         result.Add(o)
      Next

      Return result
   End Function

   Public Function GetDebitosDirectos() As System.Data.DataTable
      Return New SqlServer.Empleados(Me.da).Empleados_DebitosDirectos()
   End Function

   Public Function GetChoferTransportista(idTransportista As Integer) As System.Data.DataTable
      Return New SqlServer.Empleados(Me.da).Chofer_Transportista(idTransportista)
   End Function

   Public Sub GrabaComisionesPorListaProducto(idEmpleado As Integer, ds As DataSet)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim m As New EmpleadosComisionesProductosPrecios(da)

         m._Grabar(idEmpleado, ds.Tables(Entidades.EmpleadoComisionProductoPrecio.NombreTabla))

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub GrabaComisionesPorLista(idEmpleado As Integer, ds As DataSet)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim m As New EmpleadosComisionesMarcasPrecios(da)
         Dim r As New EmpleadosComisionesRubrosPrecios(da)

         m._Grabar(idEmpleado, ds.Tables(Entidades.EmpleadoComisionMarcaPrecio.NombreTabla))
         r._Grabar(idEmpleado, ds.Tables(Entidades.EmpleadoComisionRubroPrecio.NombreTabla))


         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub
   Public Function GetPrimerIdEmpleado() As Integer
      Return New SqlServer.Empleados(da).Empleados_GetPrimerIdEmpleado()
   End Function

   Public Function GetTop1Cobrador() As Integer
      Dim result As Integer = 0
      Dim dt As DataTable = New SqlServer.Empleados(da).GetTop1()
      If dt.Rows.Count > 0 Then result = dt.Rows(0).Field(Of Integer)(Entidades.Empleado.Columnas.IdEmpleado.ToString())
      Return result
   End Function

#End Region


End Class