#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class CRMTiposComentariosNovedadesDetalle
   Private _publicos As Publicos
   Private Property PosicionOriginal As Integer
   Private Property IdTipoNovedadOriginal As String

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.CRMTipoComentarioNovedad)
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

         Me._liSources.Add("TipoNovedad", DirectCast(Me._entidad, Entidades.CRMTipoComentarioNovedad).TipoNovedad)

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            txtIdTipoComentarioNovedad.Text = (DirectCast(GetReglas(), Reglas.CRMTiposComentariosNovedades).GetCodigoMaximo() + 1).ToString()
            PosicionOriginal = -1
            IdTipoNovedadOriginal = String.Empty
         Else
            PosicionOriginal = DirectCast(_entidad, Entidades.CRMTipoComentarioNovedad).Posicion
            IdTipoNovedadOriginal = DirectCast(_entidad, Entidades.CRMTipoComentarioNovedad).IdTipoNovedad

            If DirectCast(Me._entidad, Entidades.CRMTipoComentarioNovedad).Color.HasValue Then
               Me.txtColor.BackColor = System.Drawing.Color.FromArgb(DirectCast(Me._entidad, Entidades.CRMTipoComentarioNovedad).Color.Value)
            Else
               Me.txtColor.BackColor = Nothing
            End If

         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.CRMTiposComentariosNovedades()
   End Function

#End Region

   Private Sub cmbTipoNovedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoNovedad.SelectedIndexChanged
      Try
         If cmbTipoNovedad.SelectedIndex >= 0 Then

            If IdTipoNovedadOriginal <> cmbTipoNovedad.SelectedValue.ToString() Then
               txtPosicion.Text = (DirectCast(GetReglas(), Reglas.CRMTiposComentariosNovedades).GetPosicionMaxima(cmbTipoNovedad.SelectedValue.ToString()) + 1).ToString()
            Else
               txtPosicion.Text = PosicionOriginal.ToString()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
      Try
         Me.cdColor.Color = Me.txtColor.BackColor

         If Me.cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtColor.Key = Me.cdColor.Color.ToArgb().ToString()
            DirectCast(Me._entidad, Entidades.CRMTipoComentarioNovedad).Color = Me.cdColor.Color.ToArgb()
            Me.txtColor.BackColor = Me.cdColor.Color
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
End Class