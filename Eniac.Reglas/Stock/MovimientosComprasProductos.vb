#Region "Imports"

Imports System.Text

#End Region

<Obsolete("Se reemplaza por MovimientosStockProductos", True)>
Public Class MovimientosComprasProductos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "MovimientosComprasProductos"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "MovimientosComprasProductos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append("SELECT ")
         .Append(" M.IdSucursal ")
         .Append(", M.IdComprobanteStock ")
         .Append(", M.NroComprobanteStock ")
         .Append(", M.IdProducto ")
         .Append(", M.Cantidad ")
         .Append(", M.PrecioCosto ")
         .Append(", M.CantidadReservado ")
         .Append(", M.CantidadDefectuoso ")
         .Append(", M.CantidadFuturo ")
         .Append(", M.CantidadFuturoReservado ")
         .Append(" FROM  ")
         .Append("MovimientosDetalle M ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

#End Region

#Region "Metodos Privados"

   Friend Sub EjecutaSP(ByVal mov As Entidades.MovimientoCompraProducto, ByVal tipo As TipoSP)
      Try
         Dim sql As SqlServer.MovimientosComprasProductos = New SqlServer.MovimientosComprasProductos(Me.da)
         sql.MovimientosComprasProductos_I(mov.MovimientoCompra.Sucursal.Id, mov.MovimientoCompra.TipoMovimiento.IdTipoMovimiento,
                                           mov.MovimientoCompra.NumeroMovimiento, mov.Orden, mov.IdProducto, mov.Cantidad, mov.Precio, mov.IdLote,
                                           mov.CantidadReservado, mov.CantidadDefectuoso, mov.CantidadFuturo, mov.CantidadFuturoReservado,
                                           mov.IdaAtributoProducto01, mov.IdaAtributoProducto02, mov.IdaAtributoProducto03, mov.IdaAtributoProducto04)

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Sub EliminarPorComprobante(ByVal mcp As Entidades.MovimientoCompra)
      Dim sql As SqlServer.MovimientosComprasProductos = New SqlServer.MovimientosComprasProductos(Me.da)
      sql.EliminarPorComprobante(mcp.IdSucursal, mcp.TipoMovimiento.IdTipoMovimiento,
                                        mcp.NumeroMovimiento)
   End Sub

   Public Sub EliminarPorProduccion(ByVal mcp As Entidades.MovimientoCompraProducto)
      Dim sql As SqlServer.MovimientosComprasProductos = New SqlServer.MovimientosComprasProductos(Me.da)
      sql.EliminarPorProduccion(mcp.IdSucursal, mcp.MovimientoCompra.TipoMovimiento.IdTipoMovimiento,
                                        mcp.MovimientoCompra.NumeroMovimiento)
   End Sub


   Private Sub CargarUno(ByVal o As Entidades.MovimientoCompraProducto, ByVal dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.MovimientoCompra.Columnas.IdSucursal.ToString()).ToString())
         .IdProducto = dr("IdProducto").ToString()
         .NombreProducto = dr("NombreProducto").ToString()
         .Cantidad = Decimal.Parse(dr("Cantidad").ToString())
         .Precio = Decimal.Parse(dr("Precio").ToString())
         .IdLote = dr("IdLote").ToString()
         .Orden = Integer.Parse(dr("Orden").ToString())
         .CantidadReservado = Decimal.Parse(dr("CantidadReservado").ToString())
         .CantidadDefectuoso = Decimal.Parse(dr("CantidadDefectuoso").ToString())
         .CantidadFuturo = Decimal.Parse(dr("CantidadFuturo").ToString())
         .CantidadFuturoReservado = Decimal.Parse(dr("CantidadFuturoReservado").ToString())
         '-- REQ-34747.- --------------------------------------------------------------------
         .IdaAtributoProducto01 = dr.Field(Of Integer?)("IdaAtributoProducto01").IfNull()
         .IdaAtributoProducto02 = dr.Field(Of Integer?)("IdaAtributoProducto02").IfNull()
         .IdaAtributoProducto03 = dr.Field(Of Integer?)("IdaAtributoProducto03").IfNull()
         .IdaAtributoProducto04 = dr.Field(Of Integer?)("IdaAtributoProducto04").IfNull()
         '-----------------------------------------------------------------------------------
         Dim rMovimientosComprasProductosNrosSerie As Reglas.MovimientosComprasProductosNrosSerie = New Reglas.MovimientosComprasProductosNrosSerie(da)
         .ProductosNrosSerie = rMovimientosComprasProductosNrosSerie.GetTodos(.IdSucursal,
                                                                              dr.Field(Of String)(Entidades.MovimientoCompraProducto.Columnas.IdTipoMovimiento.ToString()),
                                                                              dr.Field(Of Long)(Entidades.MovimientoCompraProducto.Columnas.NumeroMovimiento.ToString()),
                                                                              .Orden,
                                                                              .IdProducto)
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Function GetTodos(idSucursal As Integer,
                            idTipoMovimiento As String,
                            numeroMovimiento As Long) As List(Of Entidades.MovimientoCompraProducto)
      Dim dt As DataTable = New SqlServer.MovimientosComprasProductos(da).MovimientosComprasProductos_GA(idSucursal, idTipoMovimiento, numeroMovimiento)
      Dim lst As List(Of Entidades.MovimientoCompraProducto) = New List(Of Entidades.MovimientoCompraProducto)()
      Dim o As Entidades.MovimientoCompraProducto
      For Each dr As DataRow In dt.Rows
         o = New Entidades.MovimientoCompraProducto()
         Me.CargarUno(o, dr)
         lst.Add(o)
      Next

      Return lst
   End Function



#End Region

End Class