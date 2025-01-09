Namespace Filtros
   Public Class GetPorRangoFechasFiltros
      Public Sub New(fechaDesde As DateTime, fechaHasta As DateTime)
         Me.FechaDesde = fechaDesde
         Me.FechaHasta = fechaHasta
      End Sub
      Public Sub New(fechaDesde As DateTime, fechaHasta As DateTime, esEfectivo As Boolean)
         Me.New(fechaDesde, fechaHasta)
         Me.EsEfectivo = esEfectivo
      End Sub
      Public Property FechaDesde As DateTime
      Public Property FechaHasta As DateTime
      Public Property IdSucursal As Integer
      Public Property IdCalendario As Integer
      Public Property EsEfectivo As Boolean?
      Public Property IdCliente As Long
      Public Property IdTipoTurno As String
      Public Property IdEstadoTurno As String
      Public Property idProducto As String

      Public Property IdEmbarcacion As Long
   End Class
End Namespace