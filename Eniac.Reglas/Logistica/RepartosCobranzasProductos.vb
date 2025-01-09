Public Class RepartosCobranzasProductos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.RepartoCobranzaProducto.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.RepartoCobranzaProducto)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.RepartoCobranzaProducto)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.RepartoCobranzaProducto)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.RepartosCobranzasProductos(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.RepartosCobranzasProductos(Me.da).RepartosCobranzasProductos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.RepartoCobranzaProducto, tipo As TipoSP)
      Dim sqlC As SqlServer.RepartosCobranzasProductos = New SqlServer.RepartosCobranzasProductos(da)

      Select Case tipo
         Case TipoSP._I
            sqlC.RepartosCobranzasProductos_I(en.IdSucursal, en.IdReparto, en.IdCobranza,
                                              en.IdSucursalComp, en.IdTipoComprobanteComp, en.LetraComp, en.CentroEmisorComp, en.NumeroComprobanteComp,
                                              en.IdProducto, en.Orden, en.CantidadDevuelta, en.IdEstadoVenta)
         Case TipoSP._U
            sqlC.RepartosCobranzasProductos_U(en.IdSucursal, en.IdReparto, en.IdCobranza,
                                              en.IdSucursalComp, en.IdTipoComprobanteComp, en.LetraComp, en.CentroEmisorComp, en.NumeroComprobanteComp,
                                              en.IdProducto, en.Orden, en.CantidadDevuelta, en.IdEstadoVenta)
         Case TipoSP._D
            sqlC.RepartosCobranzasProductos_D(en.IdSucursal, en.IdReparto, en.IdCobranza,
                                              en.IdSucursalComp, en.IdTipoComprobanteComp, en.LetraComp, en.CentroEmisorComp, en.NumeroComprobanteComp,
                                              en.IdProducto, en.Orden)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.RepartoCobranzaProducto, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.RepartoCobranzaProducto.Columnas.IdSucursal.ToString())
         .IdReparto = dr.Field(Of Integer)(Entidades.RepartoCobranzaProducto.Columnas.IdReparto.ToString())
         .IdCobranza = dr.Field(Of Integer)(Entidades.RepartoCobranzaProducto.Columnas.IdCobranza.ToString())

         .IdSucursalComp = dr.Field(Of Integer)(Entidades.RepartoCobranzaProducto.Columnas.IdSucursalComp.ToString())
         .IdTipoComprobanteComp = dr.Field(Of String)(Entidades.RepartoCobranzaProducto.Columnas.IdTipoComprobanteComp.ToString())
         .LetraComp = dr.Field(Of String)(Entidades.RepartoCobranzaProducto.Columnas.LetraComp.ToString())

         .CentroEmisorComp = Convert.ToInt16(dr.Field(Of Integer)(Entidades.RepartoCobranzaProducto.Columnas.CentroEmisorComp.ToString()))
         .NumeroComprobanteComp = dr.Field(Of Long)(Entidades.RepartoCobranzaProducto.Columnas.NumeroComprobanteComp.ToString())

         .IdProducto = dr.Field(Of String)(Entidades.RepartoCobranzaProducto.Columnas.IdProducto.ToString())

         .Orden = dr.Field(Of Integer)(Entidades.RepartoCobranzaProducto.Columnas.Orden.ToString())

         .CantidadDevuelta = dr.Field(Of Decimal)(Entidades.RepartoCobranzaProducto.Columnas.CantidadDevuelta.ToString())
         .IdEstadoVenta = dr.Field(Of Integer)(Entidades.RepartoCobranzaProducto.Columnas.IdEstadoVenta.ToString())
         .NombreEstadoNovedad = dr.Field(Of String)(Entidades.EstadoVenta.Columnas.NombreEstadoVenta.ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.RepartoCobranzaProducto)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Insertar(entidad As Entidades.RepartoCobranzaComprobante)
      entidad.Productos.All(Function(x)
                               x.IdSucursal = entidad.IdSucursal
                               x.IdReparto = entidad.IdReparto
                               x.IdCobranza = entidad.IdCobranza
                               _Insertar(x)
                               Return True
                            End Function)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.RepartoCobranzaProducto)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.RepartoCobranzaProducto)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Function _Borrar(en As Entidades.RepartoCobranzaComprobante) As RepartosCobranzasProductos
      _Borrar(New Entidades.RepartoCobranzaProducto() _
               With {.IdSucursal = en.IdSucursal, .IdReparto = en.IdReparto, .IdCobranza = en.IdCobranza,
                     .IdSucursalComp = en.IdSucursalComp, .IdTipoComprobanteComp = en.IdTipoComprobanteComp, .LetraComp = en.LetraComp, .CentroEmisorComp = en.CentroEmisorComp, .NumeroComprobanteComp = en.NumeroComprobanteComp})
      Return Me
   End Function

   Public Function GetUno(idSucursal As Integer,
                          idReparto As Integer,
                          idCobranza As Integer,
                          idSucursalComp As Integer,
                          idTipoComprobanteComp As String,
                          letraComp As String,
                          centroEmisorComp As Short,
                          numeroComprobanteComp As Long,
                          idProducto As String,
                          orden As Integer) As Entidades.RepartoCobranzaProducto
      Return GetUno(idSucursal, idReparto, idCobranza, idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp, idProducto, orden, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idSucursal As Integer,
                          idReparto As Integer,
                          idCobranza As Integer,
                          idSucursalComp As Integer,
                          idTipoComprobanteComp As String,
                          letraComp As String,
                          centroEmisorComp As Short,
                          numeroComprobanteComp As Long,
                          idProducto As String,
                          orden As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.RepartoCobranzaProducto
      Return CargaEntidad(New SqlServer.RepartosCobranzasProductos(Me.da).RepartosCobranzasProductos_G1(idSucursal, idReparto, idCobranza,
                                                                                                        idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp,
                                                                                                        idProducto, orden),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoCobranzaProducto(),
                          accion, Function()
                                     Dim stb = New StringBuilder("No existe Producto de Cobranza de Reparto con ")
                                     stb.AppendFormat("IdSucursal: {0}, IdReparto: {1}, IdCobranza: {2} ", idSucursal, idReparto, idCobranza)
                                     stb.AppendFormat("IdSucursalComp: {0}, IdTipoComprobanteComp: {1}, LetraComp: {2}, CentroEmisorComp: {3}, NumeroComprobanteComp: {4} ", idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp)
                                     stb.AppendFormat("IdProducto: {0}, Orden: {1}", idProducto, orden)
                                     Return stb.ToString()
                                  End Function)
   End Function

   Public Function GetTodos(idSucursal As Integer, idReparto As Integer, idCobranza As Integer,
                            idSucursalComp As Integer, idTipoComprobanteComp As String, letraComp As String, centroEmisorComp As Short, numeroComprobanteComp As Long) As List(Of Entidades.RepartoCobranzaProducto)
      Return CargaLista(New SqlServer.RepartosCobranzasProductos(Me.da).RepartosCobranzasProductos_GA(idSucursal, idReparto, idCobranza,
                                                                                                      idSucursalComp, idTipoComprobanteComp, letraComp, centroEmisorComp, numeroComprobanteComp),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoCobranzaProducto())
   End Function

   Public Function GetTodos() As List(Of Entidades.RepartoCobranzaProducto)
      Return CargaLista(Me.GetAll(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoCobranzaProducto())
   End Function

#End Region

   Public Shared Function Parse(drCol As IEnumerable(Of Entidades.dtsRegistracionPagosV2.ProductosRow)) As List(Of Entidades.RepartoCobranzaProducto)
      Dim result = New List(Of Entidades.RepartoCobranzaProducto)()
      drCol.All(Function(dr)
                   result.Add(Parse(dr))
                   Return True
                End Function)
      Return result
   End Function
   Public Shared Function Parse(dr As Entidades.dtsRegistracionPagosV2.ProductosRow) As Entidades.RepartoCobranzaProducto
      Dim prod = New Entidades.RepartoCobranzaProducto()
      prod.IdSucursalComp = dr.IdSucursal
      prod.IdTipoComprobanteComp = dr.IdTipoComprobante
      prod.LetraComp = dr.Letra
      prod.CentroEmisorComp = Convert.ToInt16(dr.CentroEmisor)
      prod.NumeroComprobanteComp = dr.NumeroComprobante
      prod.IdProducto = dr.IdProducto
      prod.Orden = dr.Orden
      prod.CantidadDevuelta = dr.Devuelve
      prod.IdEstadoVenta = dr.IdMotivo

      Return prod

   End Function

End Class