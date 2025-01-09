Public Class MRPAQLBDetalle
#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.MRPAQLB)
      Me.New()
      _entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()
         BindearControles(_entidad, _liSources)

         If StateForm = Eniac.Win.StateForm.Insertar Then

         Else

         End If
         txtLimiteCalidadAceptable.Focus()
      End Sub)
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MRPAQLB()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      If txtLimiteCalidadAceptable.ValorNumericoPorDefecto(0D) < 0 Then
         txtLimiteCalidadAceptable.Focus()
         Return "El Límite de Calidad Aceptable no puede ser negativo"
      End If
      If txtTamanoMuestreo.ValorNumericoPorDefecto(0I) <= 0 Then
         txtTamanoMuestreo.Focus()
         Return "El Tamaño de Muestreo desde debe ser mayor a cero"
      End If
      If txtCantidadAceptacion.ValorNumericoPorDefecto(0I) < 0 Then
         txtCantidadAceptacion.Focus()
         Return "La cantidad de Aceptación no puede ser negativa"
      End If
      If txtCantidadRechazo.ValorNumericoPorDefecto(0I) < 0 Then
         txtCantidadRechazo.Focus()
         Return "La cantidad de Rechazo no puede ser negativa"
      End If


      Return MyBase.ValidarDetalle()
   End Function
#End Region

#Region "Métodos"

#End Region

#Region "Eventos"

#End Region
End Class