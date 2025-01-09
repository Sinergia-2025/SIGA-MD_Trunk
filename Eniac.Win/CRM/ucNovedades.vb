Option Strict On
Option Explicit On
Public Class ucNovedades
   Protected Property _publicos As Publicos
   Public Property Dinamico() As Entidades.CRMTipoNovedadDinamico

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Public Event SelectedChanged(sender As Object, e As EventArgs)

   Protected Sub OnSelectedChanged(e As EventArgs)
      RaiseEvent SelectedChanged(Me, e)
   End Sub

   Private _stateForm As Eniac.Win.StateForm
   Public Property StateForm() As Eniac.Win.StateForm
      Get
         Return _stateForm
      End Get
      Set(ByVal value As Eniac.Win.StateForm)
         _stateForm = value
      End Set
   End Property


End Class
