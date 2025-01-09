Namespace Ayudante
   Public Class VerificarTablasEspejo
      Public ReadOnly Property ConError As Boolean
         Get
            For Each campo As CamposTabla In Campos
               If campo.ConError Then Return True
            Next
            Return False
         End Get
      End Property

      Public Property TablaOrigen As String
      Public Property TablaDestino As String

      Private Property _campos As CamposTabla()
      Public ReadOnly Property Campos As CamposTabla()
         Get
            Return _campos
         End Get
      End Property

      Public Sub New(campos As CamposTabla(), tablaOrigen As String, tablaDestino As String)
         Me._campos = campos
         Me.TablaOrigen = tablaOrigen
         Me.TablaDestino = tablaDestino
      End Sub

      Public Class CamposTabla
         Public Property NombreCampo As String
         Public Property TipoDato As String
         Public Property ConError As Boolean
         Public Property Motivo As String

         Public Sub New(nombreCampo As String, tipoDato As String)
            Me.NombreCampo = nombreCampo
            Me.TipoDato = tipoDato
            Me.ConError = False
            Me.Motivo = String.Empty
         End Sub

      End Class
   End Class
End Namespace