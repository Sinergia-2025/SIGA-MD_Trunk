Option Strict Off
Imports Eniac.Datos
Imports Eniac.Entidades
Public Class PercepcionIIBBCaba
   Implements IPercepcionIIBB
   Public Property IdProvincia As String

   Public Sub New(base As String, idProvincia As String)
      Me._base = base
      Me.IdProvincia = idProvincia
   End Sub

   Private _base As String

   Public Function GetMontoPercepcion(ByVal cliente As Entidades.Cliente,
                                      ByVal actividad As Entidades.Actividad,
                                      ByVal montoNeto As Decimal,
                                      ByVal montoTotal As Decimal,
                                      ByVal montoFacturadoEnElDia As Decimal,
                                      ByVal fecha As DateTime,
                                      ByVal da As DataAccess) As Entidades.PercepcionVentaCalculo Implements IPercepcionIIBB.GetMontoPercepcion

      Dim montoAPercibir As Decimal = 0

      'me fijo la condición de IVA para trabajar sobre un monto o el otro para sacar los calculos del porcentaje.
      If cliente.CategoriaFiscal.IvaDiscriminado Then
         montoAPercibir = montoNeto
      Else
         montoAPercibir = montoTotal
      End If

      Dim montoPercepcion As Decimal = 0

      Dim totalFact As Decimal = montoAPercibir + montoFacturadoEnElDia
      Dim baseImpo As Decimal = 0
      Dim porcentaje As Decimal = actividad.Porcentaje
      Dim sqlPadron As SqlServer.PadronesAGIP = New SqlServer.PadronesAGIP(da, Publicos.NombreBaseARBA)

      If Not sqlPadron.PadronAGIP_Existe(Nothing, fecha.ToString("yyyyMM")) Then
         Throw New Exception(String.Format("Aún no se ha cargado el padrón de AGIP para el periodo {0}. No es posible generar el comprobante deseado. Por favor realice la importación del padrón y reintente.",
                                           fecha.ToString("yyyyMM")))
      End If

      'como calcula la base imponible si ya facturo en el dia, como la llevo para grabar!!!!!!
      If totalFact >= actividad.BaseImponible Then
         baseImpo = montoAPercibir

         Dim dt As DataTable = sqlPadron.PadronAGIP_G1(CLng(cliente.Cuit), fecha.ToString("yyyyMM"))
         If dt.Rows.Count > 0 Then
            porcentaje = dt(0)(PadronAGIP.Columnas.AlicuotaPercepcion.ToString())
         End If

         montoPercepcion = baseImpo * porcentaje / 100
      End If


      Return New Entidades.PercepcionVentaCalculo(montoPercepcion, baseImpo, porcentaje, IdProvincia, actividad.IdActividad)
   End Function

End Class
