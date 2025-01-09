Option Strict On
Option Explicit On
Public Class CRMMetodosResolucionesNovedadesDetalle

   Private _publicos As Publicos
   Private Property PosicionOriginal As Integer
   Private Property IdTipoNovedadOriginal As String

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.CRMMetodoResolucionNovedad)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()
         _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad)

         Me._liSources.Add("TipoNovedad", DirectCast(Me._entidad, Entidades.CRMMetodoResolucionNovedad).TipoNovedad)

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            txtIdPlanCuenta.Text = (DirectCast(GetReglas(), Reglas.CRMMetodosResolucionesNovedades).GetCodigoMaximo() + 1).ToString()
            PosicionOriginal = -1
            IdTipoNovedadOriginal = String.Empty
         Else
            PosicionOriginal = DirectCast(_entidad, Entidades.CRMMetodoResolucionNovedad).Posicion
            IdTipoNovedadOriginal = DirectCast(_entidad, Entidades.CRMMetodoResolucionNovedad).IdTipoNovedad
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.CRMMetodosResolucionesNovedades()
   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()

      If Not Me.HayError And Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.Close()
      End If
   End Sub

#End Region

   Private Sub cmbTipoNovedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoNovedad.SelectedIndexChanged
      Try
         If cmbTipoNovedad.SelectedIndex >= 0 Then

            If IdTipoNovedadOriginal <> cmbTipoNovedad.SelectedValue.ToString() Then
               txtPosicion.Text = (DirectCast(GetReglas(), Reglas.CRMMetodosResolucionesNovedades).GetPosicionMaxima(cmbTipoNovedad.SelectedValue.ToString()) + 1).ToString()
            Else
               txtPosicion.Text = PosicionOriginal.ToString()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class