<Serializable()>
Public Class PercepcionVentaCalculo
   Inherits Entidad

   Public Sub New()
   End Sub

   Private Sub New(monto As Decimal, baseImponible As Decimal, alicuota As Decimal)
      Me.New()
      Me.Monto = monto
      Me.BaseImponible = baseImponible
      Me.Alicuota = alicuota
   End Sub

   Public Sub New(monto As Decimal, baseImponible As Decimal, alicuota As Decimal, IdProvincia As String, IdActividad As Integer)
      Me.New(monto, baseImponible, alicuota)
      Me.IdProvincia = IdProvincia
      Me.IdActividad = IdActividad
   End Sub

   Public Sub New(monto As Decimal, baseImponible As Decimal, alicuota As Decimal, idRegimenPercepcion As Integer, nombreRegimenPercepcion As String)
      Me.New(monto, baseImponible, alicuota)
      Me.IdRegimenPercepcion = idRegimenPercepcion
      Me.NombreRegimenPercepcion = nombreRegimenPercepcion
   End Sub

   Public Property Monto As Decimal
   Public Property BaseImponible As Decimal
   Public Property Alicuota As Decimal

   Public Property IdProvincia As String
   Public Property IdActividad As Integer

   Public Property IdRegimenPercepcion As Integer
   Public Property NombreRegimenPercepcion As String
End Class