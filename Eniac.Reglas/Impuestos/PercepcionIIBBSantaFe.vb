Imports Eniac.Datos

Public Class PercepcionIIBBSantaFe
   Implements IPercepcionIIBB

   'NOTA IMPORTANTE:
   '***************
   'PERCEPCIONES DE ENTRE RIOS HEREDA DE ESTA CLASE. SI SE VA A VER MODIFICADA LA LÓGICA VER SI LA MISMA DEBE IMPACTAR EN ENTRE RIOS TAMBIEN
   'EN CASO DE QUE NO SE DEBA VER IMPACTADA, COPIAR LA LOGICA ACTUAL A ENTRE RIOS, SACANDO LA HERENCIA Y LUEGO MODIFICAR ESTA

   Public Property IdProvincia As String

   Public Sub New(idProvincia As String)
      Me.IdProvincia = idProvincia
   End Sub

   Public Function GetMontoPercepcion(ByVal cliente As Entidades.Cliente,
                                      ByVal actividad As Entidades.Actividad,
                                      ByVal montoNeto As Decimal,
                                      ByVal montoTotal As Decimal,
                                      ByVal montoFacturadoEnElDia As Decimal,
                                      ByVal fecha As DateTime,
                                      ByVal da As DataAccess) As Entidades.PercepcionVentaCalculo Implements IPercepcionIIBB.GetMontoPercepcion

      Dim montoAPercibir As Decimal = 0
      Dim montoPercepcion As Decimal = 0

      'PE-23528: Realiza calculo de percepciones IIBB sobre el total y seria sobre NETO.
      montoAPercibir = montoNeto
      'me fijo la condición de IVA para trabajar sobre un monto o el otro para sacar los calculos del porcentaje.
      'If cliente.CategoriaFiscal.IvaDiscriminado Then
      '   montoAPercibir = montoNeto
      'Else
      '   montoAPercibir = montoTotal
      'End If

      Dim totalFact As Decimal = montoAPercibir + montoFacturadoEnElDia
      Dim baseImpo As Decimal = 0

      If cliente.Localidad.IdProvincia = actividad.IdProvincia Then
         'como calcula la base imponible si ya facturo en el dia, como la llevo para grabar!!!!!!
         If totalFact >= actividad.BaseImponible Then
            baseImpo = montoAPercibir
            montoPercepcion = baseImpo * actividad.Porcentaje / 100
         End If

      End If

      Return New Entidades.PercepcionVentaCalculo(montoPercepcion, baseImpo, actividad.Porcentaje, IdProvincia, actividad.IdActividad)
   End Function

End Class
