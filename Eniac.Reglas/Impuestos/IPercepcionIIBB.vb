Imports Eniac.Datos

Public Interface IPercepcionIIBB

   Function GetMontoPercepcion(ByVal cliente As Entidades.Cliente,
                               ByVal actividad As Entidades.Actividad,
                               ByVal montoNeto As Decimal,
                               ByVal montoTotal As Decimal,
                               ByVal montoFacturadoEnElDia As Decimal,
                               ByVal fecha As DateTime,
                               ByVal da As DataAccess) As Entidades.PercepcionVentaCalculo

End Interface
