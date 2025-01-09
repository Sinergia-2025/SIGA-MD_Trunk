Public Class HistorialPrecios
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Friend Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.HistorialPrecio.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.HistorialPrecio), TipoSP._I))
   End Sub

#End Region

#Region "Metodos Privados"

   Friend Sub Borra(ps As Entidades.ProductoSucursal, idListaPrecio As Integer, idFuncion As String)
      EjecutaSP(New Entidades.HistorialPrecio(ps, idFuncion), TipoSP._D)
   End Sub

   Friend Sub Inserta(ps As Entidades.ProductoSucursal, idFuncion As String)
      EjecutaSP(New Entidades.HistorialPrecio(ps, idFuncion), TipoSP._I)
   End Sub

   Friend Sub Inserta(psp As Entidades.ProductoSucursalPrecio, idFuncion As String)
      EjecutaSP(New Entidades.HistorialPrecio(psp, idFuncion), TipoSP._I)
   End Sub

   Private Sub EjecutaSP(hist As Entidades.HistorialPrecio, tipo As TipoSP)

      Dim sql = New SqlServer.HistorialPrecios(da)
      'System.Threading.Thread.Sleep(500)
      Select Case tipo
         Case TipoSP._I
            sql.HistorialPrecios_I(hist.IdProducto.Trim(),
                                   hist.IdSucursal,
                                   hist.IdListaPrecios,
                                   hist.NombreListaPrecios,
                                   hist.FechaHora,
                                   hist.PrecioFabrica,
                                   hist.PrecioCosto,
                                   hist.PrecioVenta,
                                   hist.Usuario,
                                   hist.IdFuncion)
         Case TipoSP._D
            sql.HistorialPrecios_D(hist.IdProducto.Trim(), hist.IdSucursal)
      End Select

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetHistorialPrecios(idSucursales As Integer(),
                                       fechaDesde As Date, fechaHasta As Date,
                                       idProducto As String, idMarca As Integer, idRubro As Integer,
                                       usuario As String,
                                       listaDePrecios As Entidades.ListaDePrecios(), traerListaDeCostos As Boolean) As DataTable
      Return EjecutaConConexion(
         Function()
            Dim sql = New SqlServer.HistorialPrecios(da)
            Dim dt = sql.GetHistorialPrecios(idSucursales, fechaDesde, fechaHasta, idProducto, idMarca, idRubro, usuario, listaDePrecios,
                                             cantidadRegistros:=0, ordenDescendente:=False, traerListaDeCostos:=traerListaDeCostos)
            dt.Columns.Add("IndicePrecioCosto", GetType(Decimal), "((PrecioCosto / PrecioCostoAnterior) - 1) * 100")
            dt.Columns.Add("IndicePrecioVenta", GetType(Decimal), "((PrecioVenta / PrecioVentaAnterior) - 1) * 100")
            Return dt
         End Function)
   End Function

#End Region

End Class