Public Class SucursalesDepositos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.SucursalDeposito.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.SucursalDeposito)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.SucursalDeposito)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.SucursalDeposito), controlaCantidadDepositosAlBorrar:=True))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.SucursalesDepositos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.SucursalesDepositos(da).SucursalesDepositos_GA()
   End Function
   Public Sub _InsertarDesdeSucursal(en As Entidades.Sucursal)
      Dim eDepo = New Entidades.SucursalDeposito
      With eDepo
         .IdSucursal = en.IdSucursal
         .IdDeposito = GetProximoId(en.IdSucursal)
         .NombreDeposito = en.Nombre
         .CodigoDeposito = .IdDeposito.ToString()
         .SucursalAsociada = en.IdSucursalAsociada
         .DepositoAsociado = 0
         .DisponibleVenta = True
         .Activo = True
         .TipoDeposito = Entidades.SucursalDeposito.TiposDepositos.OPERATIVO
      End With
      _Insertar(eDepo)
   End Sub
   Public Sub _Insertar(entidad As Entidades.SucursalDeposito)
      _Insertar(entidad, actualizandoAsociado:=False, creaUbicacionPredeterminada:=True, controlaCantidadDepositosAlBorrar:=True)
   End Sub
   Public Sub _Insertar(entidad As Entidades.SucursalDeposito, actualizandoAsociado As Boolean)
      _Insertar(entidad, actualizandoAsociado, creaUbicacionPredeterminada:=True, controlaCantidadDepositosAlBorrar:=True)
   End Sub
   Public Sub _Insertar(entidad As Entidades.SucursalDeposito, actualizandoAsociado As Boolean, creaUbicacionPredeterminada As Boolean)
      _Insertar(entidad, actualizandoAsociado, creaUbicacionPredeterminada, controlaCantidadDepositosAlBorrar:=True)
   End Sub
   Public Sub _Insertar(entidad As Entidades.SucursalDeposito, actualizandoAsociado As Boolean, creaUbicacionPredeterminada As Boolean, controlaCantidadDepositosAlBorrar As Boolean)
      EjecutaSP(entidad, TipoSP._I, actualizandoAsociado, creaUbicacionPredeterminada, controlaCantidadDepositosAlBorrar)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.SucursalDeposito)
      EjecutaSP(entidad, TipoSP._U, actualizandoAsociado:=False, creaUbicacionPredeterminada:=True, controlaCantidadDepositosAlBorrar:=True)
   End Sub

   Public Sub _BorrarDesdeDeposito(en As Entidades.Sucursal)
      Dim eDepo = New Entidades.SucursalDeposito
      With eDepo
         .IdSucursal = en.IdSucursal
         '.IdDeposito = GetProximoId(en.IdSucursal)
      End With
      _Borrar(eDepo, controlaCantidadDepositosAlBorrar:=False)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Entidad, controlaCantidadDepositosAlBorrar As Boolean)
      EjecutaSP(DirectCast(entidad, Entidades.SucursalDeposito), TipoSP._D, actualizandoAsociado:=False, creaUbicacionPredeterminada:=True, controlaCantidadDepositosAlBorrar)
   End Sub

#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.SucursalDeposito, tipo As TipoSP, actualizandoAsociado As Boolean, creaUbicacionPredeterminada As Boolean, controlaCantidadDepositosAlBorrar As Boolean)

      Dim sqlD = New SqlServer.SucursalesDepositos(da)
      Dim rUbica = New SucursalesUbicaciones(da)
      Dim rProDepo = New ProductosDepositos(da)
      Dim rDepUsr = New SucursalesDepositosUsuarios(da)
      Dim rSucursales = New Sucursales(da)

      Select Case tipo
         Case TipoSP._I
            en.IdDeposito = GetProximoId(en.IdSucursal)

            sqlD.SucursalesDepositos_I(en.IdDeposito, en.IdSucursal, en.NombreDeposito, en.CodigoDeposito, en.SucursalAsociada, en.DepositoAsociado, en.DisponibleVenta, en.Activo, en.TipoDeposito)
            ''-- Procedimiento de Carga de ubicaciones.- ---
            'rUbica._InsertarDesdeDeposito(en, actualizandoAsociado:=True)
            ''-- Procedimiento de Carga de Productos-Depositos.- -----
            'rProDepo.ProductosSucursalesDepositos_I(en.IdDeposito, en.IdSucursal)
            ''--------------------------------------------------------
            rDepUsr._Insertar(en)

            Dim rSistema = New Reglas.ControlSistema(da)
            Dim suc = rSucursales.GetUna(en.IdSucursal, incluirLogo:=False)
            rSistema.ControlaCantidadDeposito(Publicos.GetSistema(suc.IdEmpresa), en.IdSucursal, "El tipo de deposito {0} ya llegó a la cantidad máxima habilitada por Licencia ({2})")

         Case TipoSP._U
            sqlD.SucursalesDepositos_U(en.IdDeposito, en.IdSucursal, en.NombreDeposito, en.CodigoDeposito, en.DisponibleVenta, en.Activo, en.TipoDeposito)
            rDepUsr._Actualizar(en)
         Case TipoSP._D
            If controlaCantidadDepositosAlBorrar Then
               '-- Procedimiento de Eliminacion de ubicaciones.- ---
               Using dt = sqlD.SucursalesDepositos_GA(en.IdSucursal, en.TipoDeposito, permiteEscritura:=Entidades.Publicos.SiNoTodos.TODOS)
                  'Using dt = rUbica.GetSucursalDeposito(en.IdDeposito, en.IdSucursal)
                  If dt.Rows.Count = 1 Then
                     'Throw New Exception("No se Puede Borrar el Deposito. Posee más de 1 (una) Ubicacion.")
                     Throw New Exception(String.Format("No se Puede Borrar el Deposito. La Sucursal posee 1 (un) solo Deposito del tipo {0}.", en.TipoDeposito.ToString()))
                  End If
               End Using
            End If
            rDepUsr._Borrar(en)
            '-- Elimina Ubicacion.- -------------------------------------
            rUbica._BorrarDesdeDeposito(en)
            '-- Procedimiento de Eliminacion de Productos-Depositos.- ---
            rProDepo.ProductosSucursalesDepositos_D(en.IdDeposito, en.IdSucursal)
            '-- Elimina Deposito.- --------------------------------------
            sqlD.SucursalesDepositos_D(en.IdDeposito, en.IdSucursal)
            '------------------------------------------------------------
      End Select

      If Not actualizandoAsociado Then
         Dim suc = New Sucursales(da).GetUna(en.IdSucursal, incluirLogo:=False).IdSucursalAsociada
         If suc <> 0 Then
            If tipo = TipoSP._I Then
               en.SucursalAsociada = en.IdSucursal
               en.DepositoAsociado = en.IdDeposito
            End If

            en.IdSucursal = suc
            EjecutaSP(en, tipo, actualizandoAsociado:=True, creaUbicacionPredeterminada, controlaCantidadDepositosAlBorrar)

            If tipo = TipoSP._I Then
               Dim temp = en.IdSucursal
               en.IdSucursal = en.SucursalAsociada
               en.SucursalAsociada = temp
               temp = en.IdDeposito
               en.IdDeposito = en.DepositoAsociado
               en.DepositoAsociado = temp

               _ActualizaDepositoAsociado(en.IdDeposito, en.IdSucursal, en.DepositoAsociado, en.SucursalAsociada)
            End If
         End If
         If tipo = TipoSP._I And creaUbicacionPredeterminada Then
            '-- Procedimiento de Carga de ubicaciones.- ---
            rUbica._InsertarDesdeDeposito(en, actualizandoAsociado:=False)
         End If
      End If


   End Sub
   Private Sub CargarUno(o As Entidades.SucursalDeposito, dr As DataRow, cargaUsuarios As Boolean)
      With o
         .IdDeposito = dr.Field(Of Integer)(Entidades.SucursalDeposito.Columnas.IdDeposito.ToString())
         .NombreDeposito = dr.Field(Of String)(Entidades.SucursalDeposito.Columnas.NombreDeposito.ToString())
         .IdSucursal = dr.Field(Of Integer)(Entidades.SucursalDeposito.Columnas.IdSucursal.ToString())
         .NombreSucursal = dr.Field(Of String)(Entidades.SucursalDeposito.Columnas.NombreSucursal.ToString())
         .CodigoDeposito = dr.Field(Of String)(Entidades.SucursalDeposito.Columnas.CodigoDeposito.ToString())
         .DisponibleVenta = dr.Field(Of Boolean)(Entidades.SucursalDeposito.Columnas.DisponibleVenta.ToString())
         .Activo = dr.Field(Of Boolean)(Entidades.SucursalDeposito.Columnas.Activo.ToString())
         .SucursalAsociada = dr.Field(Of Integer?)(Entidades.SucursalDeposito.Columnas.SucursalAsociada.ToString()).IfNull()
         .DepositoAsociado = dr.Field(Of Integer?)(Entidades.SucursalDeposito.Columnas.DepositoAsociado.ToString()).IfNull()
         .TipoDeposito = dr.Field(Of String)(Entidades.SucursalDeposito.Columnas.TipoDeposito.ToString()).StringToEnum(Entidades.SucursalDeposito.TiposDepositos.OPERATIVO)

         If cargaUsuarios Then
            .Usuarios = New SucursalesDepositosUsuarios(da).GetTodos(.IdDeposito, .IdSucursal)
         End If
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idDeposito As Integer, idSucursal As Integer) As Entidades.SucursalDeposito
      Return GetUno(idDeposito, idSucursal, cargaUsuarios:=False)
   End Function
   Public Function GetUno(idDeposito As Integer, idSucursal As Integer, cargaUsuarios As Boolean) As Entidades.SucursalDeposito
      Return GetUno(idDeposito, idSucursal, cargaUsuarios, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idDeposito As Integer, idSucursal As Integer, cargaUsuarios As Boolean, accion As AccionesSiNoExisteRegistro) As Entidades.SucursalDeposito
      Return CargaEntidad(New SqlServer.SucursalesDepositos(da).SucursalesDepositos_G1(idDeposito, idSucursal),
                          Sub(o, dr) CargarUno(o, dr, cargaUsuarios), Function() New Entidades.SucursalDeposito(),
                          accion, Function() String.Format("No existe Sucursal ({0}) - Deposito ({1})", idSucursal, idDeposito))
   End Function
   Public Function GetTodos() As List(Of Entidades.SucursalDeposito)
      Return CargaLista(New SqlServer.SucursalesDepositos(da).SucursalesDepositos_GA(),
                      Sub(o, dr) CargarUno(o, dr, cargaUsuarios:=False), Function() New Entidades.SucursalDeposito())
   End Function

   Public Function GetTodos(sucursales As Entidades.Sucursal()) As List(Of Entidades.SucursalDeposito)
      Return EjecutaConConexion(Function() _GetTodos(idSucursal:=0, sucursales:=sucursales))
   End Function

   Public Function _GetTodos(idSucursal As Integer, sucursales As Entidades.Sucursal()) As List(Of Entidades.SucursalDeposito)
      Return CargaLista(New SqlServer.SucursalesDepositos(da).SucursalesDepositos_GA(sucursal:=idSucursal, sucursales:=sucursales, permiteEscritura:=Entidades.Publicos.SiNoTodos.SI),
                        Sub(o, dr) CargarUno(o, dr, cargaUsuarios:=False), Function() New Entidades.SucursalDeposito())
   End Function

   Public Function GetProximoId(idSucursal As Integer) As Integer
      Return New SqlServer.SucursalesDepositos(da).GetProximoId(idSucursal)
   End Function

   Public Function GetCantidadPorTipo(idSucursal As Integer) As Dictionary(Of Entidades.SucursalDeposito.TiposDepositos, Integer)
      Return GetCantidadPorTipo(idSucursal, tipo:=Nothing)
   End Function
   Public Function GetCantidadPorTipo(idSucursal As Integer, tipo As Entidades.SucursalDeposito.TiposDepositos?) As Dictionary(Of Entidades.SucursalDeposito.TiposDepositos, Integer)
      Dim result = New Dictionary(Of Entidades.SucursalDeposito.TiposDepositos, Integer)()
      For Each dr In New SqlServer.SucursalesDepositos(da).GetCantidadPorTipo(idSucursal).AsEnumerable()
         AgregaCantidadPorTipo(result, tipo, Entidades.SucursalDeposito.TiposDepositos.OPERATIVO, dr)
         AgregaCantidadPorTipo(result, tipo, Entidades.SucursalDeposito.TiposDepositos.RESERVADO, dr)
         AgregaCantidadPorTipo(result, tipo, Entidades.SucursalDeposito.TiposDepositos.ENTRANSITO, dr)
         AgregaCantidadPorTipo(result, tipo, Entidades.SucursalDeposito.TiposDepositos.DEFECTUOSO, dr)
      Next
      Return result
   End Function
   Private Function AgregaCantidadPorTipo(result As Dictionary(Of Entidades.SucursalDeposito.TiposDepositos, Integer),
                                          tipoParam As Entidades.SucursalDeposito.TiposDepositos?,
                                          tipoBD As Entidades.SucursalDeposito.TiposDepositos,
                                          dr As DataRow) As Dictionary(Of Entidades.SucursalDeposito.TiposDepositos, Integer)
      If Not tipoParam.HasValue OrElse tipoParam.Value = tipoBD Then
         Dim cantidadDB = dr.Field(Of Integer)(tipoBD.ToString())
         result.Add(tipoBD, cantidadDB)
      End If
      Return result
   End Function


   Public Function GetTodosSucursales(idSucursal As Integer) As DataTable
      Return New SqlServer.SucursalesDepositos(da).SucursalesDepositos_G1(idDeposito:=0, idSucursal)
   End Function
   Public Function GetTodosDeposito(idDeposito As Integer) As DataTable
      Return New SqlServer.SucursalesDepositos(da).SucursalesDepositos_G1(idDeposito:=idDeposito, idSucursal:=0)
   End Function
   Public Function GetSucursalesDepositos(idSucursal As Integer, usuario As String, permiteEscritura As Boolean, disponibleVenta As Boolean, activos As Entidades.Publicos.SiNoTodos,
                                          tipos As IEnumerable(Of Entidades.SucursalDeposito.TiposDepositos)) As DataTable
      Return New SqlServer.SucursalesDepositos(da).GetSucursalesDepositos(idSucursal, usuario, permiteEscritura, disponibleVenta, activos, tipos)
   End Function

   Public Function GetDeposito(idSucursal As Integer) As DataTable
      Return New SqlServer.SucursalesDepositos(da).GetDeposito(idSucursal)
   End Function
   Public Function GetDepositoNombres(nombreDeposito As String) As DataTable
      Return New SqlServer.SucursalesDepositos(da).GetDepositoNombre(0, nombreDeposito)
   End Function

   Public Sub ActualizaDepositoAsociado(idDeposito As Integer, idSucursal As Integer,
                                        depositoAsociado As Integer, sucursalAsociada As Integer)
      EjecutaConTransaccion(Sub() _ActualizaDepositoAsociado(idDeposito, idSucursal, depositoAsociado, sucursalAsociada))
   End Sub

   Public Sub _ActualizaDepositoAsociado(idDeposito As Integer, idSucursal As Integer,
                                         depositoAsociado As Integer, sucursalAsociada As Integer)
      Dim sql = New SqlServer.SucursalesDepositos(da)
      sql.SucursalesDepositos_U_SucAsoc(idDeposito, idSucursal, depositoAsociado, sucursalAsociada)
   End Sub

   Public Function GetDepositoNombre(idSucursal As Integer, nombreDeposito As String) As Entidades.SucursalDeposito
      Return GetDepositoNombre(idSucursal, nombreDeposito, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetDepositoNombre(idSucursal As Integer, nombreDeposito As String, accion As AccionesSiNoExisteRegistro) As Entidades.SucursalDeposito
      Return CargaEntidad(New SqlServer.SucursalesDepositos(da).GetDepositoNombre(idSucursal, nombreDeposito),
                          Sub(o, dr) CargarUno(o, dr, False), Function() New Entidades.SucursalDeposito(),
                          accion, Function() String.Format("No existe Deposito"))
   End Function
   Public Function ExistePorNombre(idSucursal As Integer, nombreDeposito As String) As Boolean
      Return GetDepositoNombre(idSucursal, nombreDeposito, AccionesSiNoExisteRegistro.Nulo) IsNot Nothing
   End Function

   Public Function ExisteProductoPredeterminado(idSucursal As Integer, idDeposito As Integer) As Boolean
      Return New ProductosSucursales(da).GetProductosPorUbicacionPredeterminada(idSucursal, idDeposito, idUbicacion:=0).Any()
   End Function

   Public Function ValidarInactivacionDeposito(idSucursal As Integer, idDeposito As Integer, ByRef mensaje As String) As Boolean
      '-- Valida Stock (ProductosDepositos.Stock).- ----------------
      If New ProductosDepositos().ValidaProductosSucursalesDepositosStock(idSucursal:=idSucursal, IdDeposito:=idDeposito) Then
         mensaje = “No se Puede Inactivar Deposito. Posee Productos con Stock dentro de su/s Depósito/s”
         Return False
      End If
      '-- Valida Deposito Defecto (ProductosSucursales.IdDepositoDefecto).- ----------------
      If New ProductosSucursales().ValidaProductosSucursalesDepositoDefecto(idSucursal:=idSucursal, IdDeposito:=idDeposito) Then
         mensaje = “No se Puede Inactivar Deposito. Existen Productos configurados con este Depósito por defecto”
         Return False
      End If
      '-- Valida Deposito Asociado (SucursalesDeposito.DepositoAsociado).- ----------------
      If ValidaSucursalesDepositoAsociado(idSucursal:=idSucursal, IdDeposito:=idDeposito) Then
         mensaje = “No se puede Inactivar porque está siendo utilizado en Sucursales Depósitos Asociados”
         Return False
      End If
      '-- Valida EstadosPedidosSucursales - (EstadosPedidosSucursales.IdDeposito).- ----------------
      If New EstadosPedidosSucursales().ValidaEstadosPedidosSucursalesDepositos(idSucursal:=idSucursal, IdDeposito:=idDeposito) Then
         mensaje = “No se puede Inactivar porque está siendo utilizado en Estados Pedidos Sucursales”
         Return False
      End If
      '-- Valida - (EstadosOrdenesProduccionSucursales.IdDeposito).- ----------------
      If New EstadosOrdenesProduccionSucursales().ValidaEstadosOPSucursalesDepositos(idSucursal:=idSucursal, IdDeposito:=idDeposito) Then
         mensaje = “No se puede Inactivar porque está siendo utilizado en Estados Ordenes Produccion Sucursales”
         Return False
      End If
      '-- Valida PedidosEstados - (PedidosEstado.IdEstado).- ----------------
      If New PedidosEstados().ValidaPedidosEstadosDepositos(idSucursal:=idSucursal, IdDeposito:=idDeposito) Then
         mensaje = “No se puede Inactivar porque está siendo utilizado en Pedidos Estado”
         Return False
      End If
      '-- Valida OrdenesProduccionMRPOperaciones - (OrdenesProduccionMRPOperaciones.DepositoOperacion).- ----------------
      If New OrdenesProduccionMRPOperaciones().ValidaOrdenesProduccionOperacionesDepositos(idSucursal:=idSucursal, IdDeposito:=idDeposito) Then
         mensaje = “No se puede Inactivar porque está siendo utilizado en Ordenes de Produccion MRP Operaciones”
         Return False
      End If
      '-- Valida OrdenesProduccionMRPProductos - (OrdenesProduccionMRPProductos.IdDepositoOrigen).- ----------------
      If New OrdenesProduccionMRPProductos().ValidaOrdenesProduccionProductosDepositos(idSucursal:=idSucursal, IdDeposito:=idDeposito) Then
         mensaje = “No se puede Inactivar porque está siendo utilizado en Ordenes de Produccion MRP Productos”
         Return False
      End If
      '-- Valida MRPProcesosProductivosOperaciones - (MRPProcesosProductivosOperaciones.DepositoOperacion).- ----------------
      If New MRPProcesosProductivosOperaciones().ValidaMRPProcesosProductosOperaciones(idSucursal:=idSucursal, IdDeposito:=idDeposito) Then
         mensaje = “No se puede Inactivar porque está siendo utilizado en MRP Proceso Productivo Operaciones”
         Return False
      End If
      '-- Valida MRPProcesoProductivoProductos - (MRPProcesoProductivoProductos.Deposito).- ----------------
      If New MRPProcesosProductivosProductos().ValidaMRPProcesosProductosDepositos(idSucursal:=idSucursal, IdDeposito:=idDeposito) Then
         mensaje = “No se puede Inactivar porque está siendo utilizado en MRP Proceso Productivo Productos”
         Return False
      End If
      Return True

   End Function

   Public Function ValidaSucursalesDepositoAsociado(idSucursal As Integer, IdDeposito As Integer) As Boolean
      Dim dt = New SqlServer.SucursalesDepositos(da).GetSucursalesPorDepositoAsociado(idSucursal, IdDeposito)
      Return dt.Rows.Count() > 0
   End Function

#End Region

End Class