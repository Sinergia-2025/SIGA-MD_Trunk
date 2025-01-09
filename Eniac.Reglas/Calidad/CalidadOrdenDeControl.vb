Public Class CalidadOrdenDeControl
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CalidadOrdenDeControl.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CalidadOrdenDeControl)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CalidadOrdenDeControl)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CalidadOrdenDeControl)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetSql().CalidadOrdenDeControl_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.CalidadOrdenDeControl
      Return New SqlServer.CalidadOrdenDeControl(da)
   End Function
   Private Sub ValidaGrabacion(en As Entidades.CalidadOrdenDeControl, tipo As TipoSP)
      If {TipoSP._I, TipoSP._U, TipoSP._M}.Contains(tipo) Then
         If en.CantidadControlar <= 0 Then
            Throw New Exception("La cantidad a controlar debe ser mayor a 0")
         End If
         If String.IsNullOrWhiteSpace(en.IdProducto) Then
            Throw New Exception("Debe seleccionar un producto")
         End If
      End If
   End Sub
   Private Sub EjecutaSP(en As Entidades.CalidadOrdenDeControl, tipo As TipoSP)
      Dim sql = GetSql()
      Dim rControlItem = New CalidadOrdenDeControlItems(da)
      Dim rComprasProductos = New ComprasProductos(da)
      ValidaGrabacion(en, tipo)
      Select Case tipo
         Case TipoSP._I
            If String.IsNullOrWhiteSpace(en.IdUsuarioAlta) Then
               en.IdUsuarioAlta = actual.Nombre
               en.FechaAlta = Date.Now
            End If
            If String.IsNullOrWhiteSpace(en.IdUsuarioActualizacion) Then
               en.IdUsuarioActualizacion = actual.Nombre
               en.FechaActualizacion = Date.Now
            End If

            '-- Nuevo numero de Comprobante.- --------------------------------------------------------------------------------------------------------------
            en.NumeroComprobante = GetUltimoNumeroComprobante(en.IdTipoComprobante, en.Letra, en.CentroEmisor)
            '-----------------------------------------------------------------------------------------------------------------------------------------------
            sql.CalidadOrdenDeControl_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                        en.Fecha, en.IdProducto,
                                        en.IdDeposito, en.IdUbicacion, en.IdLote,
                                        en.IdProveedor, en.IdSucursalCompra, en.IdTipoComprobanteCompra, en.LetraCompra, en.CentroEmisorCompra, en.NumeroComprobanteCompra, en.OrdenComprobanteCompra,
                                        en.CantidadControlar, en.IdEstadoCalidad, en.Observaciones,
                                        en.IdUsuarioAlta, en.FechaAlta, en.IdUsuarioActualizacion, en.FechaActualizacion)
            '-- Inserta Items Desde Control.- --------------------------------------------------------------------------------------------------------------
            rControlItem.ActualizaDesdeOrdenDeControl(en)
            '-- Actualiza ComprasProductos.- ---------------------------------------------------------------------------------------------------------------
            If en.IdSucursalCompra.HasValue Then
               rComprasProductos.ActualizaFechaActualizacionCalidad(en, en.Fecha)
            End If
            '-- Actualizo numero de Comprobante.- --------------------------------------------------------------------------------------------------------------
            ActualizaNumeroComprobante(en)
            ' ----------------------------------------------------------------------------------------------------------------------------------------------
         Case TipoSP._U
            en.IdUsuarioActualizacion = actual.Nombre
            en.FechaActualizacion = Date.Now

            sql.CalidadOrdenDeControl_U(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                        en.Fecha, en.IdProducto,
                                        en.IdDeposito, en.IdUbicacion, en.IdLote,
                                        en.IdProveedor, en.IdSucursalCompra, en.IdTipoComprobanteCompra, en.LetraCompra, en.CentroEmisorCompra, en.NumeroComprobanteCompra, en.OrdenComprobanteCompra,
                                        en.CantidadControlar, en.IdEstadoCalidad, en.Observaciones,
                                        en.IdUsuarioAlta, en.FechaAlta, en.IdUsuarioActualizacion, en.FechaActualizacion)
            '-- Inserta Items Desde Control.- --------------------------------------------------------------------------------------------------------------
            rControlItem.ActualizaDesdeOrdenDeControl(en)
            '-- Actualiza ComprasProductos.- ---------------------------------------------------------------------------------------------------------------
            If en.IdSucursalCompra.HasValue Then
               rComprasProductos.ActualizaFechaActualizacionCalidad(en, en.Fecha)
            End If
            ' ----------------------------------------------------------------------------------------------------------------------------------------------
         Case TipoSP._D
            '-- Actualiza ComprasProductos.- ---------------------------------------------------------------------------------------------------------------
            If en.IdSucursalCompra.HasValue Then
               rComprasProductos.ActualizaFechaActualizacionCalidad(en, fecha:=Nothing)
            End If
            '-- Borra Items Desde Control.- --------------------------------------------------------------------------------------------------------------
            rControlItem.BorraDesdeOrdenDeControl(en)
            ' ----------------------------------------------------------------------------------------------------------------------------------------------
            sql.CalidadOrdenDeControl_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante)
      End Select
   End Sub
   Private Sub CargarUno(o As Entidades.CalidadOrdenDeControl, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.CalidadOrdenDeControl.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.CalidadOrdenDeControl.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.CalidadOrdenDeControl.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.CalidadOrdenDeControl.Columnas.CentroEmisor.ToString())
         .NumeroComprobante = dr.Field(Of Long)(Entidades.CalidadOrdenDeControl.Columnas.NumeroComprobante.ToString())

         .Fecha = dr.Field(Of Date)(Entidades.CalidadOrdenDeControl.Columnas.Fecha.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.CalidadOrdenDeControl.Columnas.IdProducto.ToString())

         .IdDeposito = dr.Field(Of Integer?)(Entidades.CalidadOrdenDeControl.Columnas.IdDeposito.ToString())
         .IdUbicacion = dr.Field(Of Integer?)(Entidades.CalidadOrdenDeControl.Columnas.IdUbicacion.ToString())
         .IdLote = dr.Field(Of String)(Entidades.CalidadOrdenDeControl.Columnas.IdLote.ToString())

         .IdProveedor = dr.Field(Of Long?)(Entidades.CalidadOrdenDeControl.Columnas.IdProveedor.ToString())
         .IdSucursalCompra = dr.Field(Of Integer?)(Entidades.CalidadOrdenDeControl.Columnas.IdSucursalCompra.ToString())
         .IdTipoComprobanteCompra = dr.Field(Of String)(Entidades.CalidadOrdenDeControl.Columnas.IdTipoComprobanteCompra.ToString())
         .LetraCompra = dr.Field(Of String)(Entidades.CalidadOrdenDeControl.Columnas.LetraCompra.ToString())
         .CentroEmisorCompra = dr.Field(Of Integer?)(Entidades.CalidadOrdenDeControl.Columnas.CentroEmisorCompra.ToString())
         .NumeroComprobanteCompra = dr.Field(Of Long?)(Entidades.CalidadOrdenDeControl.Columnas.NumeroComprobanteCompra.ToString())
         .OrdenComprobanteCompra = dr.Field(Of Integer?)(Entidades.CalidadOrdenDeControl.Columnas.OrdenComprobanteCompra.ToString())

         .CantidadControlar = dr.Field(Of Decimal)(Entidades.CalidadOrdenDeControl.Columnas.CantidadControlar.ToString())
         .EstadoCalidad = New EstadosOrdenesCalidad(da).GetUno(dr.Field(Of String)(Entidades.CalidadOrdenDeControl.Columnas.IdEstadoCalidad.ToString()))
         .Observaciones = dr.Field(Of String)(Entidades.CalidadOrdenDeControl.Columnas.Observaciones.ToString())

         .CalidadOrdenDeControlItems = New Reglas.CalidadOrdenDeControlItems(da).GetTodas(.IdSucursal, .IdTipoComprobante, .Letra, .CentroEmisor, .NumeroComprobante)

         .IdUsuarioAlta = dr.Field(Of String)(Entidades.CalidadOrdenDeControl.Columnas.IdUsuarioAlta.ToString())
         .FechaAlta = dr.Field(Of Date)(Entidades.CalidadOrdenDeControl.Columnas.FechaAlta.ToString())
         .IdUsuarioActualizacion = dr.Field(Of String)(Entidades.CalidadOrdenDeControl.Columnas.IdUsuarioActualizacion.ToString())
         .FechaActualizacion = dr.Field(Of Date)(Entidades.CalidadOrdenDeControl.Columnas.FechaActualizacion.ToString())

      End With
   End Sub
   Private Sub ActualizaNumeroComprobante(ent As Entidades.CalidadOrdenDeControl)
      Dim oVNRe = New VentasNumeros(da)

      Dim oVN = New Entidades.VentaNumero With {
         .IdTipoComprobante = ent.IdTipoComprobante,
         .LetraFiscal = ent.Letra,
         .CentroEmisor = Short.Parse(ent.CentroEmisor.ToString()),
         .IdSucursal = ent.IdSucursal,
         .Numero = ent.NumeroComprobante,
         .Fecha = ent.Fecha
      }
      oVNRe.ActualizarNumero(oVN)
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CalidadOrdenDeControl)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CalidadOrdenDeControl)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CalidadOrdenDeControl)
      EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Function Get1(IdSucursal As Integer, IdTipoComprobante As String, Letra As String, CentroEmisor As Integer,
                        NumeroComprobante As Long) As DataTable
      Return GetSql().CalidadOrdenDeControl_G1(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante)
   End Function
   Public Function GetUno(IdSucursal As Integer, IdTipoComprobante As String, Letra As String, CentroEmisor As Integer,
                          NumeroComprobante As Long) As Entidades.CalidadOrdenDeControl
      Return GetUno(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(IdSucursal As Integer, IdTipoComprobante As String, Letra As String, CentroEmisor As Integer,
                          NumeroComprobante As Long, accion As AccionesSiNoExisteRegistro) As Entidades.CalidadOrdenDeControl
      Return CargaEntidad(Get1(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadOrdenDeControl(),
                          accion, Function() String.Format("No existe Orden de Calidad {0}", NumeroComprobante))
   End Function
   Public Function GetTodas() As List(Of Entidades.CalidadOrdenDeControl)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadOrdenDeControl())
   End Function

   Public Function GetUltimoNumeroComprobante(IdTipoComprobante As String, LetraComprobante As String, CentroEmisor As Integer) As Long
      Dim sucursalOperacion = New Reglas.Sucursales(da).GetUna(actual.Sucursal.IdSucursal, incluirLogo:=False)
      '-- Nuevo numero de Comprobante.- --------------------------------------------------------------------------------------------------------------
      Dim oVentasNumeros = New Reglas.VentasNumeros(da)
      Return oVentasNumeros.GetProximoNumero(sucursalOperacion, IdTipoComprobante, LetraComprobante, Short.Parse(CentroEmisor.ToString()))
   End Function

   Public Function GetOrdenesDeCalidadXEstados(sucursales As Entidades.Sucursal(), estadosOrdenes As Entidades.EstadoOrdenCalidad(), dtpDesde As Date?, dtpHasta As Date?,
                                               listaComprobantes As Entidades.TipoComprobante(), numeroOrdenCalidad As Long, idProducto As String,
                                               idProveedor As Long, idUsuario As String) As DataTable
      Dim sql = New SqlServer.CalidadOrdenDeControl(da)
      Return sql.GetCalidadOrdenDeControlXEstados(sucursales, estadosOrdenes, dtpDesde, dtpHasta, listaComprobantes, numeroOrdenCalidad, idProducto, idProveedor, idUsuario)
   End Function

   Public Function CreaOrdenControlCalidad(dr As DataRow, tipoComprobante As Entidades.TipoComprobante, estadoOrdenCalidad As Entidades.EstadoOrdenCalidad, fechaOrdenCalidad As Date, observaciones As String) As Entidades.CalidadOrdenDeControl
      Return EjecutaConTransaccion(Function() _CreaOrdenControlCalidad(dr, tipoComprobante, estadoOrdenCalidad, fechaOrdenCalidad, observaciones))
   End Function
   Public Function CreaOrdenControlCalidad(drCol As IEnumerable(Of DataRow), tipoComprobante As Entidades.TipoComprobante, estadoOrdenCalidad As Entidades.EstadoOrdenCalidad, fechaOrdenCalidad As Date, observaciones As String) As IEnumerable(Of Entidades.CalidadOrdenDeControl)
      Return EjecutaConTransaccion(
         Function()
            Dim result = New List(Of Entidades.CalidadOrdenDeControl)()
            For Each dr In drCol
               result.Add(_CreaOrdenControlCalidad(dr, tipoComprobante, estadoOrdenCalidad, fechaOrdenCalidad, observaciones))
            Next
            Return result
         End Function)
   End Function

   Public Function _CreaOrdenControlCalidad(dr As DataRow, tipoComprobante As Entidades.TipoComprobante, estadoOrdenCalidad As Entidades.EstadoOrdenCalidad, fechaOrdenCalidad As Date,
                                            observaciones As String) As Entidades.CalidadOrdenDeControl
      Return _CreaOrdenControlCalidad(dr, tipoComprobante, estadoOrdenCalidad, fechaOrdenCalidad, observaciones, New CalidadOrdenDeControlItems())
   End Function
   Public Function _CreaOrdenControlCalidad(dr As DataRow,
                                            tipoComprobante As Entidades.TipoComprobante, estadoOrdenCalidad As Entidades.EstadoOrdenCalidad, fechaOrdenCalidad As Date,
                                            observaciones As String,
                                            rOCI As CalidadOrdenDeControlItems) As Entidades.CalidadOrdenDeControl

      Dim oImpresoras = New Impresoras(da)._GetPorSucursalPCTipoComprobante(actual.Sucursal.Id, My.Computer.Name, tipoComprobante.IdTipoComprobante)

      Dim oc = New Entidades.CalidadOrdenDeControl With {
         .IdSucursal = actual.Sucursal.Id,
         .IdTipoComprobante = tipoComprobante.IdTipoComprobante,
         .Letra = tipoComprobante.LetrasHabilitadas.Split(","c).First(),
         .CentroEmisor = oImpresoras.CentroEmisor,
         .NumeroComprobante = 0,
         .Fecha = fechaOrdenCalidad,
         .IdProducto = dr.Field(Of String)(Entidades.Producto.Columnas.IdProducto.ToString()),
         .IdDeposito = dr.Field(Of Integer)(Entidades.CompraProducto.Columnas.IdDeposito.ToString()),
         .IdUbicacion = dr.Field(Of Integer)(Entidades.CompraProducto.Columnas.IdUbicacion.ToString()),
         .IdLote = dr.Field(Of String)(Entidades.CompraProducto.Columnas.IdLote.ToString()),
         .IdProveedor = dr.Field(Of Long)(Entidades.Proveedor.Columnas.IdProveedor.ToString()),
         .IdSucursalCompra = dr.Field(Of Integer)("IdSucursalCompra"),
         .IdTipoComprobanteCompra = dr.Field(Of String)("IdTipoComprobanteCompra"),
         .LetraCompra = dr.Field(Of String)("LetraCompra"),
         .CentroEmisorCompra = dr.Field(Of Integer)("CentroEmisorCompra"),
         .NumeroComprobanteCompra = dr.Field(Of Long)("NumeroComprobanteCompra"),
         .OrdenComprobanteCompra = dr.Field(Of Integer)("OrdenComprobanteCompra"),
         .CantidadControlar = dr.Field(Of Decimal)("Cantidad"),
         .EstadoCalidad = estadoOrdenCalidad,
         .Observaciones = observaciones
      }

      rOCI.CargaListaControlItemsDelProducto(oc.CalidadOrdenDeControlItems, oc.IdProducto)
      rOCI.CalculaCantidadesListaControlItems(oc.CalidadOrdenDeControlItems, oc.CantidadControlar)

      _Insertar(oc)

      Return oc
   End Function

#End Region

End Class