Public Class MRPAQLADetalle
#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.MRPAQLA)
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
         txtTamanoLoteDesde.Focus()
      End Sub)
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MRPAQLA()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      If txtTamanoLoteDesde.ValorNumericoPorDefecto(0D) <= 0 Then
         txtTamanoLoteDesde.Focus()
         Return "El Tamaño de Lote desde debe ser mayor a cero"
      End If
      If txtTamanoLoteHasta.ValorNumericoPorDefecto(0D) <= 0 Then
         txtTamanoLoteHasta.Focus()
         Return "El Tamaño de Lote hasta debe ser mayor a cero"
      End If
      If txtTamanoLoteDesde.ValorNumericoPorDefecto(0D) >= txtTamanoLoteHasta.ValorNumericoPorDefecto(0D) Then
         txtTamanoLoteHasta.Focus()
         Return "El Tamaño de Lote desde debe ser menos a hasta"
      End If

      Return MyBase.ValidarDetalle()
   End Function
#End Region

#Region "Métodos"

#End Region

#Region "Eventos"

#End Region
End Class