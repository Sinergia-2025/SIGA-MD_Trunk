#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class CRMCategoriasNovedadesDetalle

   Private _publicos As Publicos
   Private Property PosicionOriginal As Integer
   Private Property IdTipoNovedadOriginal As String

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.CRMCategoriaNovedad)
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
         _publicos.CargaComboCRMTiposCategoriasNovedades(cmbTipoCategoriaNovedad, DirectCast(Me._entidad, Entidades.CRMCategoriaNovedad).TipoNovedad.IdTipoNovedad)

         Me._publicos.CargaComboDesdeEnum(Me.cmbReporta, GetType(Entidades.CRMCategoriaNovedad.ComboReporta), , True)

         Me._liSources.Add("TipoNovedad", DirectCast(Me._entidad, Entidades.CRMCategoriaNovedad).TipoNovedad)

         Me.cmbReporta.Visible = Reglas.Publicos.CRMMuestraReportaCategoriasNovedades
         Me.lblReporta.Visible = Reglas.Publicos.CRMMuestraReportaCategoriasNovedades

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            txtIdCategoriaNovedad.Text = (DirectCast(GetReglas(), Reglas.CRMCategoriasNovedades).GetCodigoMaximo() + 1).ToString()
            PosicionOriginal = -1
            IdTipoNovedadOriginal = String.Empty
            Me.cmbReporta.SelectedIndex = 0
         Else
            PosicionOriginal = DirectCast(_entidad, Entidades.CRMCategoriaNovedad).Posicion
            IdTipoNovedadOriginal = DirectCast(_entidad, Entidades.CRMCategoriaNovedad).IdTipoNovedad
            If DirectCast(Me._entidad, Entidades.CRMCategoriaNovedad).Color.HasValue Then
               Me.txtColor.BackColor = System.Drawing.Color.FromArgb(DirectCast(Me._entidad, Entidades.CRMCategoriaNovedad).Color.Value)
            Else
               Me.txtColor.BackColor = Nothing
            End If
            Me.cmbTipoCategoriaNovedad.SelectedValue = DirectCast(_entidad, Entidades.CRMCategoriaNovedad).IdTipoCategoriaNovedad
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.CRMCategoriasNovedades()
   End Function

   Protected Overrides Sub Aceptar()

      '# Valido que se haya seleccionado un tipo de categoría
      If Me.cmbTipoCategoriaNovedad.SelectedIndex = -1 Then
         ShowMessage("Debe seleccionar un Tipo de Categoría.")
         Me.cmbTipoCategoriaNovedad.Focus()
         Exit Sub
      End If

      DirectCast(_entidad, Entidades.CRMCategoriaNovedad).IdTipoCategoriaNovedad = DirectCast(Me.cmbTipoCategoriaNovedad.SelectedItem, Entidades.CRMTipoCategoriaNovedad).IdTipoCategoriaNovedad

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
               txtPosicion.Text = (DirectCast(GetReglas(), Reglas.CRMCategoriasNovedades).GetPosicionMaxima(cmbTipoNovedad.SelectedValue.ToString()) + 1).ToString()
            Else
               txtPosicion.Text = PosicionOriginal.ToString()
            End If
            _publicos.CargaComboCRMTiposCategoriasNovedades(Me.cmbTipoCategoriaNovedad, cmbTipoNovedad.SelectedValue.ToString())
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
            DirectCast(Me._entidad, Entidades.CRMCategoriaNovedad).Color = Me.cdColor.Color.ToArgb()
            Me.txtColor.BackColor = Me.cdColor.Color
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

End Class