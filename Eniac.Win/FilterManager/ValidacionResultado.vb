#Region "Option"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace FilterManager
   Friend Class ValidacionResultado
      Private _mensaje As StringBuilder
      Public Property Mensaje As StringBuilder
         Get
            Return _mensaje
         End Get
         Private Set(value As StringBuilder)
            _mensaje = value
         End Set
      End Property

      Private _controlParaFoco As Control
      Public Property ControlParaFoco() As Control
         Get
            Return _controlParaFoco
         End Get
         Set(ByVal value As Control)
            _controlParaFoco = value
         End Set
      End Property


      Private _algunError As Boolean
      Public Property AlgunError As Boolean
         Get
            Return _algunError
         End Get
         Private Set(value As Boolean)
            _algunError = value
         End Set
      End Property

      Public Sub New()
         Mensaje = New StringBuilder()
         AlgunError = False
      End Sub

      Public Sub NuevoError(mensaje As String, controlParaFoco As Control)
         Me.Mensaje.AppendFormatLine(mensaje)
         Me.AlgunError = True
         If Me.ControlParaFoco Is Nothing Then
            Me.ControlParaFoco = controlParaFoco
         End If
      End Sub

   End Class
End Namespace