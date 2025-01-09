#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class ListasControlProductos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ListasControlProductos"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ListasControlProductos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub


#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         Dim en As Entidades.ListaControlProducto = DirectCast(entidad, Entidades.ListaControlProducto)

         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ListasControlProductos = New SqlServer.ListasControlProductos(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.ListasControlProductos_I(en.IdProducto, en.IdListaControl, en.fecha, en.IdUsuario, en.Aplica, en.IdEstadoCalidad)
            Case TipoSP._U
               sqlC.ListasControlProductos_U(en.IdProducto, en.IdListaControl, en.FecIngreso, en.FecEgreso, en.CincoS,
                                             en.CincoSComment, en.CincoSC, en.CincoSCommentC, en.CincoSUsr, en.CincoSFecha,
                                             en.CincoSUsrC, en.CincoSFechaC, en.IdUsuario, en.Aplica, en.IdEstadoCalidad,
                                              en.Observacion)
            Case TipoSP._D
               sqlC.ListasControlProductos_D(en.IdProducto)
         End Select
         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ListaControlProducto, ByVal dr As DataRow)
      With o
         .IdProducto = dr(Entidades.ListaControlProducto.Columnas.IdProducto.ToString()).ToString()
         .IdListaControl = Integer.Parse(dr(Entidades.ListaControlProducto.Columnas.IdListaControl.ToString()).ToString())
         .IdUsuario = dr(Entidades.ListaControlProducto.Columnas.Idusuario.ToString()).ToString()
         .Aplica = Boolean.Parse(dr(Entidades.ListaControlProducto.Columnas.Aplica.ToString()).ToString())
         .fecha = Date.Parse(dr(Entidades.ListaControlProducto.Columnas.fecha.ToString()).ToString())
         .NombreListaControl = dr(Entidades.ListaControl.Columnas.NombreListaControl.ToString()).ToString()
         .IdEstadoCalidad = Integer.Parse(dr(Entidades.ListaControlProducto.Columnas.IdEstadoCalidad.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.ListaControlProducto.Columnas.FecIngreso.ToString()).ToString()) Then
            .FecIngreso = DateTime.Parse(dr(Entidades.ListaControlProducto.Columnas.FecIngreso.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.ListaControlProducto.Columnas.FecEgreso.ToString()).ToString()) Then
            .FecEgreso = DateTime.Parse(dr(Entidades.ListaControlProducto.Columnas.FecEgreso.ToString()).ToString())
         End If
         .Orden = Integer.Parse(dr(Entidades.ListaControl.Columnas.Orden.ToString()).ToString())
         .Observacion = dr(Entidades.ListaControlProducto.Columnas.Observacion.ToString()).ToString()
         .CincoS = dr(Entidades.ListaControlProducto.Columnas.CincoS.ToString()).ToString()
         .CincoSC = dr(Entidades.ListaControlProducto.Columnas.CincoSC.ToString()).ToString()
         .CincoSComment = dr(Entidades.ListaControlProducto.Columnas.CincoSComment.ToString()).ToString()
         .CincoSCommentC = dr(Entidades.ListaControlProducto.Columnas.CincoSCommentC.ToString()).ToString()
         If Not String.IsNullOrEmpty(dr(Entidades.ListaControlProducto.Columnas.CincoSFecha.ToString()).ToString()) Then
            .CincoSFecha = DateTime.Parse(dr(Entidades.ListaControlProducto.Columnas.CincoSFecha.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.ListaControlProducto.Columnas.CincoSFechaC.ToString()).ToString()) Then
            .CincoSFechaC = DateTime.Parse(dr(Entidades.ListaControlProducto.Columnas.CincoSFechaC.ToString()).ToString())
         End If
         .CincoSUsr = dr(Entidades.ListaControlProducto.Columnas.CincoSUsr.ToString()).ToString()
         .CincoSUsrC = dr(Entidades.ListaControlProducto.Columnas.CincoSUsrC.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Overloads Sub Borrar(idProducto As String, IdListaControl As Integer)
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.ListasControlProductos = New SqlServer.ListasControlProductos(da)
         sqlC.ListasControlProductos_D(idProducto)

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Sub

   Public Overloads Sub Insertar(ListasControlProductos As List(Of Entidades.ListaControlProducto))
      For Each Item As Entidades.ListaControlProducto In ListasControlProductos
         Me.EjecutaSP(Item, TipoSP._I)
      Next
   End Sub

   Public Function GetUno(IdProducto As String, IdListaControl As Integer) As Entidades.ListaControlProducto
      Dim dt As DataTable = New SqlServer.ListasControlProductos(Me.da).CalidadListasControl_G1(IdProducto, IdListaControl)
      Dim o As Entidades.ListaControlProducto = New Entidades.ListaControlProducto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodas(IdProducto As String) As List(Of Entidades.ListaControlProducto)
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).ListasControlProductos_GA(IdProducto)
      Dim o As Entidades.ListaControlProducto
      Dim oLis As List(Of Entidades.ListaControlProducto) = New List(Of Entidades.ListaControlProducto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ListaControlProducto()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetListasControlxProducto(IdProducto As String) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).ListasControlProductos_GA(IdProducto)
      Return dt
   End Function

   Public Function GetListasControlxLista(IdListaControl As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).ListasControlProductos_GxLista(IdListaControl)
      Return dt
   End Function

   Public Function GetListasControlxProductoLista(IdProducto As String, idListaControl As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).CalidadListasControl_G1(IdProducto, idListaControl)
      Return dt
   End Function

   Public Function GetListasControlSiguienteOrden(IdProducto As String, Orden As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).CalidadListasControl_GetListasControlSiguienteOrden(IdProducto, Orden)
      Return dt
   End Function

   Public Function GetListasControlProductos(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                                IdestadoCalidad As Integer, Liberado As Boolean,
                                                Entregado As Boolean, IdListaControl As Integer,
                                                IdTipoListaControl As Integer, IdCliente As Long,
                                                CincoS As String, Ubicacion As String) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).ListasControlProductos_GProductos(idProducto,
                                                                                                       FechaDesde, FechaHasta, IdestadoCalidad,
                                                                                                       Liberado, Entregado, IdListaControl,
                                                                                                       IdTipoListaControl,
                                                                                                       IdCliente, CincoS, Ubicacion)
      Return dt
   End Function

   Public Function GetInformeLeadTime(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                               IdestadoCalidad As Integer, IdListaControl As Integer,
                                               IdCliente As Long, Ubicacion As String) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).ListasControlProductos_LeadTime(idProducto,
                                                                                                       FechaDesde, FechaHasta, IdestadoCalidad,
                                                                                                       IdListaControl,
                                                                                                       IdCliente, Ubicacion)
      Return dt
   End Function

   Public Function PreEntrega(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                             IdCliente As Long, PreEntreg As String, Ubicacion As String) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).ListasControlProductos_PreEntrega(idProducto,
                                                                                                       FechaDesde, FechaHasta,
                                                                                                       IdCliente, PreEntreg,
                                                                                                       Ubicacion)
      Return dt
   End Function

   Public Function LiberarProducto(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                            IdCliente As Long, Liberado As String, Ubicacion As String) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).ListasControlProductos_LiberarProducto(idProducto,
                                                                                                       FechaDesde, FechaHasta,
                                                                                                       IdCliente, Liberado,
                                                                                                       Ubicacion)
      Return dt
   End Function

   Public Function EntregadoACLiente(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                           IdCliente As Long, Entregado As String, Ubicacion As String) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).ListasControlProductos_EntregadoACLiente(idProducto,
                                                                                                       FechaDesde, FechaHasta,
                                                                                                       IdCliente, Entregado,
                                                                                                       Ubicacion)
      Return dt
   End Function

   Public Function GetListasControlxProductoRoles(IdProducto As String, Roles As DataTable) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).ListasControlProductos_GxRoles(IdProducto, Roles)
      Return dt
   End Function

   Public Function GetListasControlxProductoEnProceso(IdProducto As String) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).GetListasControlEnproceso(IdProducto)
      Return dt
   End Function


   Public Sub Guardar(dtListasControlProductos As Entidades.ListConBorrados(Of Entidades.ListaControlProducto))
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sql As SqlServer.ListasControlProductos = New SqlServer.ListasControlProductos(da)
         Dim sql2 As SqlServer.ListasControlProductosItems = New SqlServer.ListasControlProductosItems(da)
         Dim sql3 As Reglas.ListasControlConfig = New Reglas.ListasControlConfig(da)
         Dim ListaItems As List(Of Entidades.ListaControlConfig) = New List(Of Entidades.ListaControlConfig)
         Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)
         Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)
         Dim dtAudit As DataTable = New DataTable()
         Dim OperacAudit As Entidades.OperacionesAuditorias
         Dim ListaControlItems As DataTable
         Dim ListaControl As DataTable
         Dim oCal As Reglas.ListasControlProductosItems = New Reglas.ListasControlProductosItems(da)
         Dim oLC As Reglas.ListasControlProductos = New Reglas.ListasControlProductos(da)

         If dtListasControlProductos IsNot Nothing Then

            'BAJAS
            For Each lista As Entidades.ListaControlProducto In dtListasControlProductos.Borrados

               ListaControlItems = oCal.GetListasControlxProductoListaControl(lista.IdProducto, lista.IdListaControl)

               If ListaControlItems.Rows.Count <> 0 Then
                  OperacAudit = Entidades.OperacionesAuditorias.Baja

                  rAudit.Insertar("CalidadListasControlProductos", OperacAudit, actual.Nombre,
                                                   String.Format("{0} = '{1}' AND {2} = {3} ",
                                                  Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                                                 lista.IdProducto, Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                                                  lista.IdListaControl))

                  For Each dr As DataRow In ListaControlItems.Rows

                     rAudit.Insertar("CalidadListasControlProductosItems", OperacAudit, actual.Nombre,
                                String.Format("{0} = '{1}' AND {2} = {3} AND {4} = {5} ",
                               Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                              dr(Entidades.ListaControlProducto.Columnas.IdProducto.ToString()).ToString(),
                               Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                              dr("IdListaControl").ToString(),
                               Entidades.ListaControlProductoItem.Columnas.Item.ToString(),
                                dr("Item").ToString()))

                  Next
               End If

               sql2.ListasControlProductosItems_D(lista.IdProducto, lista.IdListaControl)

               sql.ListasControlProductos_D(lista.IdProducto, lista.IdListaControl)



            Next

            'ALTAS
            For Each lista As Entidades.ListaControlProducto In dtListasControlProductos


               'controlar si la lista ya existe no hace nada!!!

               ListaControl = oLC.GetListasControlxProductoLista(lista.IdProducto, lista.IdListaControl)

               If ListaControl.Rows.Count = 0 Then

                  OperacAudit = Entidades.OperacionesAuditorias.Alta
                  'Lista NUEVA
                  sql.ListasControlProductos_I(lista.IdProducto, lista.IdListaControl, lista.fecha, lista.IdUsuario,
                                               lista.Aplica, lista.IdEstadoCalidad)


                  rAudit.Insertar("CalidadListasControlProductos", OperacAudit, actual.Nombre,
                              String.Format("{0} = '{1}' AND {2} = {3} ",
                             Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                            lista.IdProducto, Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                             lista.IdListaControl))


                  ListaItems = sql3.GetTodas(lista.IdListaControl)


                  For Each item As Entidades.ListaControlConfig In ListaItems

                     sql2.ListasControlProductosItems_I(lista.IdProducto,
                                                         item.IdListaControl, item.Item, item.IdListaControlItem, False, False, False, False, False, "",
                                                         item.Orden, actual.Nombre, DateTime.Now(), False, False, False, False, False, "", actual.Nombre, DateTime.Now())



                     rAudit.Insertar("CalidadListasControlProductosItems", OperacAudit, actual.Nombre,
                                String.Format("{0} = '{1}' AND {2} = {3} AND {4} = {5} ",
                               Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                             lista.IdProducto, Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                              item.IdListaControl,
                               Entidades.ListaControlProductoItem.Columnas.Item.ToString(),
                               item.Item))

                  Next
               Else

                  ListaControlItems = oCal.GetListasControlxProductoListaControl(lista.IdProducto, lista.IdListaControl)

                  If ListaControlItems.Rows.Count = 0 Then


                     OperacAudit = Entidades.OperacionesAuditorias.Alta

                     ListaItems = sql3.GetTodas(lista.IdListaControl)


                     For Each item As Entidades.ListaControlConfig In ListaItems

                        sql2.ListasControlProductosItems_I(lista.IdProducto,
                                                            item.IdListaControl, item.Item, item.IdListaControlItem, False, False, False, False, False, "",
                                                            item.Orden, actual.Nombre, DateTime.Now(), False, False, False, False, False, "", actual.Nombre, DateTime.Now())



                        rAudit.Insertar("CalidadListasControlProductosItems", OperacAudit, actual.Nombre,
                                   String.Format("{0} = '{1}' AND {2} = {3} AND {4} = {5} ",
                                  Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                                lista.IdProducto, Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                                 item.IdListaControl,
                                  Entidades.ListaControlProductoItem.Columnas.Item.ToString(),
                                  item.Item))

                     Next

                  End If

               End If

            Next

         End If


         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Class GetProductosPorListasControlPivotInfo
      Public Property dtColumnas As DataTable
      Public Property dtResult As DataTable
   End Class
   Public Function GetProductosPorListasControl(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                                IdestadoCalidad As Integer, Liberado As Boolean,
                                                Entregado As Boolean, IdCliente As Long, Ubicacion As String) As GetProductosPorListasControlPivotInfo

      Dim sql As SqlServer.ListasControlProductos = New SqlServer.ListasControlProductos(da)

      Dim pivotcolName As StringBuilder = New StringBuilder()
      Dim sumPivot As StringBuilder = New StringBuilder()

      Dim dtColumnas As DataTable = sql.GetEstadosPorListasControl_ColumnasPivot(idProducto)

      If dtColumnas.Rows.Count = 0 Then
         Throw New Exception("No se encontraron Modelos para estos filtros.")
      End If

      Dim primero As Boolean = True
      For Each drColumna As DataRow In dtColumnas.Rows
         If Not primero Then
            pivotcolName.Append(",")
            sumPivot.Append(",")
         End If
         pivotcolName.AppendFormat("[{0}]", drColumna("NombreColumma"))
         sumPivot.AppendFormat("MAX([{0}]) as [{0}]", drColumna("NombreColumma"))
         primero = False
      Next

      Return New GetProductosPorListasControlPivotInfo() _
          With {.dtColumnas = dtColumnas,
          .dtResult = New SqlServer.ListasControlProductos(da).GetEstadosPorListasControl(idProducto,
                                                                      FechaDesde, FechaHasta, IdestadoCalidad,
                                                                       Liberado, Entregado,
                                                                     pivotcolName.ToString(),
                                                                     sumPivot.ToString(), IdCliente, Ubicacion)}
   End Function

   Public Function GetProductosPorListasControlTipos(idProducto As String, fechaDesde As DateTime?, fechaHasta As DateTime?,
                                                     idestadoCalidad As Integer, idCliente As Long, ubicacion As String,
                                                     liberados As Entidades.Publicos.SiNoTodos, entregados As Entidades.Publicos.SiNoTodos,
                                                     liberadosPDI As Entidades.Publicos.SiNoTodos, PanelGerencia As Boolean,
                                                     MostrarReparaciones As Boolean) As GetProductosPorListasControlPivotInfo

      Dim sql As SqlServer.ListasControlProductos = New SqlServer.ListasControlProductos(da)

      Dim pivotcolName As StringBuilder = New StringBuilder()
      Dim sumPivot As StringBuilder = New StringBuilder()
      Dim pivotcolName2 As StringBuilder = New StringBuilder()
      Dim sumPivot2 As StringBuilder = New StringBuilder()

      Dim dtColumnas As DataTable = sql.GetEstadosPorListasControlTipo_ColumnasPivot(idProducto)
      Dim dtColumnas2 As DataTable = sql.GetEstadosPorListasControlTipoEstado_ColumnasPivot(idProducto)

      If dtColumnas.Rows.Count = 0 Then
         Throw New Exception("No se encontraron Tipos de Listas para estos filtros.")
      End If


      If dtColumnas2.Rows.Count = 0 Then
         Throw New Exception("No se encontraron Estados para estos filtros.")
      End If

      Dim primero As Boolean = True
      For Each drColumna As DataRow In dtColumnas.Rows
         If Not primero Then
            pivotcolName.Append(",")
            sumPivot.Append(",")
         End If
         pivotcolName.AppendFormat("[{0}]", drColumna("NombreColumma"))
         sumPivot.AppendFormat("MIN([{0}]) as [{0}]", drColumna("NombreColumma"))
         primero = False
      Next

      Dim primero1 As Boolean = True
      For Each drColumna As DataRow In dtColumnas2.Rows
         If Not primero1 Then
            pivotcolName2.Append(",")
            sumPivot2.Append(",")
         End If
         pivotcolName2.AppendFormat("[{0}]", drColumna("NombreColumma"))
         sumPivot2.AppendFormat("AVG([{0}]) as [{0}]", drColumna("NombreColumma"))
         primero1 = False
      Next

      Return New GetProductosPorListasControlPivotInfo() _
          With {.dtColumnas = dtColumnas,
          .dtResult = New SqlServer.ListasControlProductos(da).GetEstadosPorListasControlTipo(idProducto, fechaDesde, fechaHasta,
                                                                                              idestadoCalidad, idCliente, ubicacion,
                                                                                              liberados, entregados, liberadosPDI, PanelGerencia, MostrarReparaciones,
                                                                                              pivotcolName.ToString(), sumPivot.ToString(), pivotcolName2.ToString(), sumPivot2.ToString())}
   End Function

   Public Function GetLeadTimeListasControlTipo(idProducto As String, fechaDesde As DateTime?, fechaHasta As DateTime?,
                                                      fechaDesdeLiberado As DateTime?, fechaHastaLiberado As DateTime?,
                                                     idestadoCalidad As Integer, idCliente As Long, ubicacion As String,
                                                     liberados As Entidades.Publicos.SiNoTodos,
                                                     entregados As Entidades.Publicos.SiNoTodos,
                                                     liberadosPDI As Entidades.Publicos.SiNoTodos,
                                                      IdProductoModeloTipo As Integer) As GetProductosPorListasControlPivotInfo

      Dim sql As SqlServer.ListasControlProductos = New SqlServer.ListasControlProductos(da)

      Dim pivotcolName As StringBuilder = New StringBuilder()
      Dim sumPivot As StringBuilder = New StringBuilder()
      Dim pivotcolName2 As StringBuilder = New StringBuilder()
      Dim sumPivot2 As StringBuilder = New StringBuilder()
      Dim pivotcolName3 As StringBuilder = New StringBuilder()
      Dim sumPivot3 As StringBuilder = New StringBuilder()

      Dim dtColumnas As DataTable = sql.GetEstadosPorListasControlTipo_ColumnasPivot(idProducto)
      Dim dtColumnas2 As DataTable = sql.GetEstadosPorListasControlTipoEstado_ColumnasPivot(idProducto)
      Dim dtColumnas3 As DataTable = sql.GetLeadTimePorListasControlTipo_ColumnasPivot(idProducto)


      If dtColumnas.Rows.Count = 0 Then
         Throw New Exception("No se encontraron Tipos de Listas para estos filtros.")
      End If


      If dtColumnas2.Rows.Count = 0 Then
         Throw New Exception("No se encontraron Estados para estos filtros.")
      End If

      Dim primero As Boolean = True
      For Each drColumna As DataRow In dtColumnas.Rows
         If Not primero Then
            pivotcolName.Append(",")
            sumPivot.Append(",")
         End If
         pivotcolName.AppendFormat("[{0}]", drColumna("NombreColumma"))
         sumPivot.AppendFormat("MIN([{0}]) as [{0}]", drColumna("NombreColumma"))
         primero = False
      Next

      Dim primero1 As Boolean = True
      For Each drColumna As DataRow In dtColumnas2.Rows
         If Not primero1 Then
            pivotcolName2.Append(",")
            sumPivot2.Append(",")
         End If
         pivotcolName2.AppendFormat("[{0}]", drColumna("NombreColumma"))
         sumPivot2.AppendFormat("AVG([{0}]) as [{0}]", drColumna("NombreColumma"))
         primero1 = False
      Next

      Dim primero2 As Boolean = True
      For Each drColumna As DataRow In dtColumnas3.Rows
         If Not primero2 Then
            pivotcolName3.Append(",")
            sumPivot3.Append(",")
         End If
         pivotcolName3.AppendFormat("[{0}]", drColumna("NombreColumma"))
         sumPivot3.AppendFormat("'' as [{0}]", drColumna("NombreColumma"))
         primero2 = False
      Next

      Return New GetProductosPorListasControlPivotInfo() _
          With {.dtColumnas = dtColumnas,
          .dtResult = New SqlServer.ListasControlProductos(da).GetLeadTimeListasControlTipo(idProducto, fechaDesde, fechaHasta,
                                                                                            fechaDesdeLiberado, fechaHastaLiberado,
                                                                                              idestadoCalidad, idCliente, ubicacion,
                                                                                              liberados, entregados, liberadosPDI, IdProductoModeloTipo,
                                                                                              pivotcolName.ToString(), sumPivot.ToString(),
                                                                                              pivotcolName2.ToString(), sumPivot2.ToString(),
                                                                                              pivotcolName3.ToString(), sumPivot3.ToString())}
   End Function


   Public Function GetProductosPanelControl(IdProductoModeloTipo As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).ListasControlProductos_GetProductosPanelControl(IdProductoModeloTipo)
      Return dt
   End Function

   Public Function GetProductosPanelControlMetas(IdProductoModeloTipo As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).ListasControlProductos_GetProductosPanelControlMetas(IdProductoModeloTipo)
      Return dt
   End Function

   Public Function GetPanelDeControlWeb(idProducto As String, fechaDesde As DateTime?, fechaHasta As DateTime?,
                                                     idestadoCalidad As Integer, idCliente As Long, ubicacion As String,
                                                     liberados As Entidades.Publicos.SiNoTodos, entregados As Entidades.Publicos.SiNoTodos,
                                                     liberadosPDI As Entidades.Publicos.SiNoTodos,
                                                        IdProductoModeloTipo As Integer) As GetProductosPorListasControlPivotInfo

      Dim sql As SqlServer.ListasControlProductos = New SqlServer.ListasControlProductos(da)

      Dim pivotcolName As StringBuilder = New StringBuilder()
      Dim sumPivot As StringBuilder = New StringBuilder()
      Dim pivotcolName2 As StringBuilder = New StringBuilder()
      Dim sumPivot2 As StringBuilder = New StringBuilder()

      Dim dtColumnas As DataTable = sql.GetEstadosPorListasControlTipo_ColumnasPivot(idProducto)
      Dim dtColumnas2 As DataTable = sql.GetEstadosPorListasControlTipoEstado_ColumnasPivot(idProducto)

      If dtColumnas.Rows.Count = 0 Then
         Throw New Exception("No se encontraron Tipos de Listas para estos filtros.")
      End If


      If dtColumnas2.Rows.Count = 0 Then
         Throw New Exception("No se encontraron Estados para estos filtros.")
      End If

      Dim primero As Boolean = True
      For Each drColumna As DataRow In dtColumnas.Rows
         If Not primero Then
            pivotcolName.Append(",")
            sumPivot.Append(",")
         End If
         pivotcolName.AppendFormat("[{0}]", drColumna("NombreColumma"))
         sumPivot.AppendFormat("MIN([{0}]) as [{0}]", drColumna("NombreColumma"))
         primero = False
      Next

      Dim primero1 As Boolean = True
      For Each drColumna As DataRow In dtColumnas2.Rows
         If Not primero1 Then
            pivotcolName2.Append(",")
            sumPivot2.Append(",")
         End If
         pivotcolName2.AppendFormat("[{0}]", drColumna("NombreColumma"))
         sumPivot2.AppendFormat("AVG([{0}]) as [{0}]", drColumna("NombreColumma"))
         primero1 = False
      Next

      Return New GetProductosPorListasControlPivotInfo() _
          With {.dtColumnas = dtColumnas,
          .dtResult = New SqlServer.ListasControlProductos(da).GetPanelDeControlWeb(idProducto, fechaDesde, fechaHasta,
                                                                                              idestadoCalidad, idCliente, ubicacion,
                                                                                              liberados, entregados, liberadosPDI,
                                                                                              IdProductoModeloTipo,
                                                                                              pivotcolName.ToString(), sumPivot.ToString(), pivotcolName2.ToString(), sumPivot2.ToString())}
   End Function
   Public Sub Guardar(ListasControl As Entidades.ListaControlProducto)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sql2 As SqlServer.ListasControlProductos = New SqlServer.ListasControlProductos(da)
         Dim rAudit As Reglas.Auditorias = New Reglas.Auditorias(da)
         Dim sqlAudit As SqlServer.Auditorias = New SqlServer.Auditorias(da)
         Dim dtAudit As DataTable = New DataTable()
         Dim OperacAudit As Entidades.OperacionesAuditorias


         sql2.ListasControlProductos_U(ListasControl.IdProducto, ListasControl.IdListaControl, ListasControl.FecIngreso,
                                       ListasControl.FecEgreso, ListasControl.CincoS, ListasControl.CincoSComment, ListasControl.CincoSC,
                                       ListasControl.CincoSCommentC, ListasControl.CincoSUsr, ListasControl.CincoSFecha, ListasControl.CincoSUsrC,
                                       ListasControl.CincoSFechaC, ListasControl.IdUsuario, True, ListasControl.IdEstadoCalidad,
                                       ListasControl.Observacion)


         dtAudit = sqlAudit.Auditorias_G1("CalidadListasControlProductos", String.Format("{0} = '{1}' AND {2} = {3} ",
                                                                                    Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                                                                                 ListasControl.IdProducto,
                                                                                 Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                                                                                 ListasControl.IdListaControl))

         'Si no tiene registro es porque se borro el alta en la auditoria (podria pasar en la implementacion inicial)
         If dtAudit.Rows.Count > 0 Then
            OperacAudit = Entidades.OperacionesAuditorias.Modificacion
         Else
            OperacAudit = Entidades.OperacionesAuditorias.Alta
         End If

         rAudit.Insertar("CalidadListasControlProductos", OperacAudit, actual.Nombre,
                         String.Format("{0} = '{1}' AND {2} = {3} ",
                        Entidades.ListaControlProductoItem.Columnas.IdProducto.ToString(),
                        ListasControl.IdProducto,
                        Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(),
                        ListasControl.IdListaControl))


         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Public Function GetListasControlxProducto_Auditoria(IdProducto As String) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).ListasControlProductos_GetAuditoria(IdProducto)
      Return dt
   End Function

   Public Function GetProximoNroCertificado() As Integer
      Dim NroCert As Integer = New SqlServer.ListasControlProductos(da).GetProximoNroCertificado()
      Return NroCert
   End Function

   Public Function GetProximoNroCertEntregado() As Integer
      Dim NroCert As Integer = New SqlServer.ListasControlProductos(da).GetProximoNroCertEntregado()
      Return NroCert
   End Function

   Public Function GetListasControlxProductoPendientesAuditoria(idProducto As String, FechaDesde As DateTime, FechaHasta As DateTime,
                                          IdListaControl As Integer, Liberado As Boolean,
                                          Entregado As Boolean, IdCliente As Long, IdEstado As Integer) As DataTable
      Dim dt As DataTable = New SqlServer.ListasControlProductos(da).ListasControlProductos_GListasxProductoPendientesAuditoria(idProducto, FechaDesde, FechaHasta,
                                                                                                                                IdListaControl, Liberado, Entregado,
                                                                                                                                IdCliente, IdEstado)
      Return dt
   End Function

   Public Function FinalizarListas() As Integer
      Try

         Dim CantidadListas As Integer = 0
         Dim ProductosPanel As DataTable = New DataTable
         Dim ProductosListas As DataTable = New DataTable
         Dim ProductosListasItems As DataTable = New DataTable
         Dim Roles As DataTable = New DataTable
         Dim ListaControl As Entidades.ListaControlProducto
         Dim Finaliza As Boolean = True

         Dim ListaActiva As Entidades.ListaControl = New Entidades.ListaControl()

         'Busco todos los productos que no fueron Liberados y estan en el Panel de Control
         ProductosPanel = New Reglas.ListasControlProductos().GetProductosPanelControl(IdProductoModeloTipo:=0)
         For Each dr As DataRow In ProductosPanel.Rows
            'Busco todas las listas EN PROCESO para finalizar las que esten todo OK
            ProductosListas = New Reglas.ListasControlProductos().GetListasControlxProductoEnProceso(dr("Idproducto").ToString())
            For Each dr1 As DataRow In ProductosListas.Rows
               Finaliza = True
               ListaControl = New Reglas.ListasControlProductos().GetUno(dr("Idproducto").ToString(), Integer.Parse(dr1("IdListaControl").ToString()))

               ListaActiva = New Reglas.ListasControl().GetUno(Integer.Parse(dr1("IdListaControl").ToString()))
               'Busco los items de las listas para hacer el control para poder finalizar la lista
               ProductosListasItems = New Reglas.ListasControlProductosItems().GetListasControlxProductoListaControl(dr("Idproducto").ToString(), Integer.Parse(dr1("IdListaControl").ToString()))
               For Each dr2 As DataRow In ProductosListasItems.Rows
                  If ListaActiva.ControlaProduccion Then
                     Dim selec As String
                     selec = If(Boolean.Parse(dr2("NoOk").ToString()), "NoOk",
                             If(Boolean.Parse(dr2("Obs").ToString()), "Obs",
                             If(Boolean.Parse(dr2("Mat").ToString()), "Mat", String.Empty)))

                     'Si controla producción y hay alguno no OK o NA da error
                     If Not String.IsNullOrWhiteSpace(selec) Then

                        Finaliza = False
                     End If

                     If Not Boolean.Parse(dr2("Ok").ToString()) And Not Boolean.Parse(dr2("NA").ToString()) Then
                        Finaliza = False
                     End If

                  End If

                  If ListaActiva.ControlaCalidad Then
                     Dim selec As String
                     selec = If(Boolean.Parse(dr2("NoOkCalidad").ToString()), "NoOkCalidad",
                             If(Boolean.Parse(dr2("ObsCalidad").ToString()), "ObsCalidad",
                             If(Boolean.Parse(dr2("MatCalidad").ToString()), "MatCalidad", String.Empty)))
                     If Not String.IsNullOrWhiteSpace(selec) Then
                        Finaliza = False

                     End If

                     If Not Boolean.Parse(dr2("OkCalidad").ToString()) And Not Boolean.Parse(dr2("NACalidad").ToString()) Then
                        Finaliza = False
                     End If

                     If ListaActiva.ControlaProduccion Then
                        If Boolean.Parse(dr2("Ok").ToString()) <> Boolean.Parse(dr2("OkCalidad").ToString()) Or
                                            Boolean.Parse(dr2("NA").ToString()) <> Boolean.Parse(dr2("NACalidad").ToString()) Then
                           Finaliza = False
                        End If

                     End If
                  End If

                  If Not Finaliza Then
                     Exit For
                  End If
               Next

               If Finaliza Then

                  Dim EstadoFinalizado As Entidades.EstadoListaControl = New Reglas.EstadosListasControl().GetUno(Reglas.Publicos.EstadoListaControlTerminado)
                  Dim TipoLista As Entidades.ListaControlTipo = New Entidades.ListaControlTipo
                  TipoLista = New Reglas.ListasControlTipos().GetUno(ListaActiva.IdListaControlTipo)

                  If ListaActiva.HabilitaFechaLiberado Or ListaActiva.HabilitaFechaLiberadoPDI Or Not TipoLista.VisiblePanelControl Then
                     Exit For
                  End If

                  ListaControl.IdEstadoCalidad = EstadoFinalizado.IdEstadoCalidad
                  ListaControl.FecEgreso = Date.Now()
                  ListaControl.FecIngreso = Nothing
                  ListaControl.Observacion = "TERMINADO AUTOMATICO"


                  Dim Producto As Entidades.Producto
                  Dim rListasControlProductos As Reglas.ListasControlProductosItems = New Reglas.ListasControlProductosItems()
                  Producto = New Reglas.Productos().GetUno(dr("Idproducto").ToString())
                  rListasControlProductos.GuardarListaControl(Producto, ListaControl)
                  CantidadListas += 1

               End If

            Next

         Next
         Return CantidadListas
      Catch ex As Exception
         Throw
      End Try

   End Function
#End Region

End Class