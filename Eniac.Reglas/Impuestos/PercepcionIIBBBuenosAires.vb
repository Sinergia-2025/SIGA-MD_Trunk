Public Class PercepcionIIBBBuenosAires
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
                                      ByVal da As Datos.DataAccess) As Entidades.PercepcionVentaCalculo Implements IPercepcionIIBB.GetMontoPercepcion

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
      Dim sqlPadron As SqlServer.PadronesARBA = New SqlServer.PadronesARBA(da, Publicos.NombreBaseARBA)

      If Not sqlPadron.PadronARBA_Existe(Nothing, Integer.Parse(fecha.ToString("yyyyMM")), Nothing) Then
         Throw New Exception(String.Format("Aún no se ha cargado el padrón de ARBA para el periodo {0}. No es posible generar el comprobante deseado. Por favor realice la importación del padrón y reintente.",
                                           fecha.ToString("yyyyMM")))
      End If

      'como calcula la base imponible si ya facturo en el dia, como la llevo para grabar!!!!!!
      If totalFact >= actividad.BaseImponible Then
         baseImpo = montoAPercibir

         Dim dt As DataTable = sqlPadron.PadronARBA_G1(CLng(cliente.Cuit), Integer.Parse(fecha.ToString("yyyyMM")), Entidades.PadronARBA.TipoRegimenEnum.Percepcion)
         If dt.Rows.Count > 0 Then
            porcentaje = dt(0).Field(Of Decimal?)(Entidades.PadronARBA.Columnas.Alicuota.ToString()).IfNull()
         End If

         montoPercepcion = baseImpo * porcentaje / 100
      End If


      Return New Entidades.PercepcionVentaCalculo(montoPercepcion, baseImpo, porcentaje, IdProvincia, actividad.IdActividad)
   End Function

End Class
