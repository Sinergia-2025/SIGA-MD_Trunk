Option Strict On
Option Explicit On
Partial Class SincronizarOrdenesCompra

#Region "Metodos"
   Public Function GetDetallesBejerman(fechaDesde As Date?,
                                       fechaHasta As Date?) As DataTable

      Return New SqlServer.SincronizarOrdenesCompra(da).GetDetallesBejerman(String.Concat(Publicos.CalidadBaseExternaClientes, ".dbo."), fechaDesde, fechaHasta)

   End Function

   Public Function GetProveedoresBejerman(fechaModificacionDesde As Date?,
                                          fechaModificacionHasta As Date?) As DataTable

      Return New SqlServer.SincronizarOrdenesCompra(da).GetProveedoresBejerman(String.Concat(Publicos.CalidadBaseExternaClientes, ".dbo."),
                                                                               fechaModificacionDesde,
                                                                               fechaModificacionHasta)

   End Function

   Public Function GetCabecerasBejerman(fechaModificacionDesde As Date,
                                        fechaModificacionHasta As Date,
                                        fechaIngresoDesde As Date?,
                                        fechaIngresoHasta As Date?) As DataTable

      Return New SqlServer.SincronizarOrdenesCompra(da).GetCabecerasBejerman(String.Concat(Publicos.CalidadBaseExternaClientes, ".dbo."),
                                                                             fechaModificacionDesde,
                                                                             fechaModificacionHasta,
                                                                             fechaIngresoDesde,
                                                                             fechaIngresoHasta)
   End Function

#End Region
End Class