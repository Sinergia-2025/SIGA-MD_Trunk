Public Class ProduccionProductos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "MovimientosStockProductos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overloads Function GetAll(idSucursal As Integer, idproduccion As Integer) As DataTable
      Return New SqlServer.ProduccionProductos(da).ProduccionProductos_GA(idSucursal, idproduccion)
   End Function

#End Region

#Region "Metodos Publicos"

   Public Function GetPorRangoFechas(idSucursal As Integer, desde As Date, hasta As Date,
                                     idProducto As String, idEstado As Entidades.OrdenProduccionEstado.FiltroEstadosInforme,
                                     marcas As Entidades.Marca(), rubros As Entidades.Rubro()) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ProduccionProductos(da).
                                   GetPorRangoFechas(idSucursal, desde, hasta, idProducto, idEstado, marcas, rubros))
   End Function

   Public Function GetPorRangoFechasProd(idSucursal As Integer, producciones As String) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ProduccionProductos(da).
                                    GetPorRangoFechasProd(idSucursal, producciones))
   End Function

   Public Function GetTotalPorProducto(idSucursal As Integer, desde As Date, hasta As Date,
                                       idProducto As String, marcas As Entidades.Marca(), rubros As Entidades.Rubro()) As DataTable
      Return EjecutaConConexion(Function() New SqlServer.ProduccionProductos(da).
                                                   GetTotalPorProducto(idSucursal, desde, hasta,
                                                                       idProducto, marcas, rubros))
   End Function

   Public Function GetTodos(idSucursal As Integer, idproduccion As Integer) As List(Of Entidades.ProduccionProducto)
      Return CargaLista(GetAll(idSucursal, idproduccion),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProduccionProducto)
   End Function

   Public Sub _Insertar(en As Entidades.ProduccionProducto)
      EjecutaSP(en, TipoSP._I)
   End Sub

#End Region


#Region "Metodos Privados"

   Friend Sub EjecutaSP(en As Entidades.ProduccionProducto, tipo As TipoSP)
      Dim sql = New SqlServer.ProduccionProductos(da)
      Dim rNroSerie = New ProduccionProductosNrosSerie(da)
      sql.ProduccionProductos_I(en.Produccion.IdSucursal, en.Produccion.IdProduccion,
                                en.Orden, en.IdProducto, en.Cantidad, en.IdLote, en.VtoLote, en.IdFormula,
                                en.IdProduccionProceso, en.IdProduccionForma, en.Espmm, en.EspPies, en.CodigoSAE,
                                en.LargoExtAlto, en.AnchoIntBase, en.UrlPlano, en.IdDeposito, en.IdUbicacion)
      rNroSerie._Insertar(en)

   End Sub

   Private Sub CargarUno(o As Entidades.ProduccionProducto, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)("IdSucursal")
         .IdProduccion = dr.Field(Of Integer)("IdProduccion")
         .Orden = dr.Field(Of Integer)("Orden")
         .IdProducto = dr.Field(Of String)("IdProducto")
         .Cantidad = dr.Field(Of Decimal)("CantidadProducida")
         .IdLote = dr.Field(Of String)("IdLote")
         .VtoLote = dr.Field(Of Date?)("FechaVencimiento").IfNull()
         .IdFormula = dr.Field(Of Integer)("IdFormula")

         .IdProduccionProceso = dr.Field(Of Integer?)("IdProduccionProceso").IfNull()
         .IdProduccionForma = dr.Field(Of Integer?)("IdProduccionForma").IfNull()

         .Espmm = dr.Field(Of Decimal?)("Espmm").IfNull()
         .EspPies = dr.Field(Of String)("EspPies").IfNull()
         .CodigoSAE = dr.Field(Of String)("CodigoSAE").ValorNumericoPorDefecto(0I)
         .LargoExtAlto = dr.Field(Of Decimal?)("LargoExtAlto").IfNull()
         .AnchoIntBase = dr.Field(Of Decimal?)("AnchoIntBase").IfNull()
         .UrlPlano = dr.Field(Of String)("UrlPlano").IfNull()

         .IdDeposito = dr.Field(Of Integer?)("IdDeposito").IfNull()
         .IdUbicacion = dr.Field(Of Integer?)("IdUbicacion").IfNull()

         .Componentes = New ProduccionProductosComp(da).GetTodos(.IdSucursal, .IdProduccion, .Orden, .IdProducto)
         .NrosSerie = New ProduccionProductosNrosSerie(da).GetTodos(.IdSucursal, .IdProduccion, .Orden, .IdProducto)

      End With
   End Sub

#End Region

End Class