Public Class PanelesTablerosControlDetalle
#Region "Campos"
   Private _Publicos As Publicos
#End Region

   Public ReadOnly Property Panel As Entidades.TableroControlPanel
      Get
         Return DirectCast(_entidad, Entidades.TableroControlPanel)
      End Get
   End Property

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.TableroControlPanel)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Me._Publicos = New Win.Publicos

      Me.BindearControles(Me._entidad, _liSources)

      If Me.StateForm = Win.StateForm.Insertar Then

      Else

         chbBackColor1.Checked = Panel.BackColor1.HasValue
         chbBackColor2.Checked = Panel.BackColor2.HasValue

         chbForeColor1.Checked = Panel.ForeColor1.HasValue
         chbForeColor2.Checked = Panel.ForeColor2.HasValue

         SetColor1()
         SetColor2()

      End If
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TablerosControlPaneles()
   End Function
#End Region

#Region "Eventos"
   Private Sub chbBackColor1_CheckedChanged(sender As Object, e As EventArgs) Handles chbBackColor1.CheckedChanged
      TryCatched(Sub()
                    btnBackColor1.Enabled = chbBackColor1.Checked
                    If Not chbBackColor1.Checked Then Panel.BackColor1 = Nothing
                    SetColor1()
                 End Sub)
   End Sub
   Private Sub chbBackColor2_CheckedChanged(sender As Object, e As EventArgs) Handles chbBackColor2.CheckedChanged
      TryCatched(Sub()
                    btnBackColor2.Enabled = chbBackColor2.Checked
                    If Not chbBackColor2.Checked Then Panel.BackColor2 = Nothing
                    SetColor2()
                 End Sub)
   End Sub
   Private Sub chbForeColor1_CheckedChanged(sender As Object, e As EventArgs) Handles chbForeColor1.CheckedChanged
      TryCatched(Sub()
                    btnForeColor1.Enabled = chbForeColor1.Checked
                    If Not chbForeColor1.Checked Then Panel.ForeColor1 = Nothing
                    SetColor1()
                 End Sub)
   End Sub
   Private Sub chbForeColor2_CheckedChanged(sender As Object, e As EventArgs) Handles chbForeColor2.CheckedChanged
      TryCatched(Sub()
                    btnForeColor2.Enabled = chbForeColor2.Checked
                    If Not chbForeColor2.Checked Then Panel.ForeColor2 = Nothing
                    SetColor2()
                 End Sub)
   End Sub
#End Region

#Region "Evetos/Metodos Color"
   Private Sub btnBackColor1_Click(sender As Object, e As EventArgs) Handles btnBackColor1.Click
      TryCatched(Sub()
                    Me.cdColor.Color = If(Panel.BackColor1.HasValue, Color.FromArgb(Panel.BackColor1.Value), Nothing)
                    If Me.cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
                       Panel.BackColor1 = Me.cdColor.Color.ToArgb()
                    Else
                       Panel.BackColor1 = Nothing
                    End If
                    SetColor1()
                 End Sub)
   End Sub
   Private Sub btnBackColor2_Click(sender As Object, e As EventArgs) Handles btnBackColor2.Click
      TryCatched(Sub()
                    Me.cdColor.Color = If(Panel.BackColor2.HasValue, Color.FromArgb(Panel.BackColor2.Value), Nothing)
                    If Me.cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
                       Panel.BackColor2 = Me.cdColor.Color.ToArgb()
                    Else
                       Panel.BackColor2 = Nothing
                    End If
                    SetColor2()
                 End Sub)
   End Sub
   Private Sub btnForeColor1_Click(sender As Object, e As EventArgs) Handles btnForeColor1.Click
      TryCatched(Sub()
                    Me.cdColor.Color = If(Panel.ForeColor1.HasValue, Color.FromArgb(Panel.ForeColor1.Value), Nothing)
                    If Me.cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
                       Panel.ForeColor1 = Me.cdColor.Color.ToArgb()
                    Else
                       Panel.ForeColor1 = Nothing
                    End If
                    SetColor1()
                 End Sub)
   End Sub
   Private Sub btnForeColor2_Click(sender As Object, e As EventArgs) Handles btnForeColor2.Click
      TryCatched(Sub()
                    Me.cdColor.Color = If(Panel.ForeColor2.HasValue, Color.FromArgb(Panel.ForeColor2.Value), Nothing)
                    If Me.cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
                       Panel.ForeColor2 = Me.cdColor.Color.ToArgb()
                    Else
                       Panel.ForeColor2 = Nothing
                    End If
                    SetColor2()
                 End Sub)
   End Sub
   Private Sub SetColor1()
      SetColor(txtColor1, Panel.BackColor1, Panel.ForeColor1)
   End Sub
   Private Sub SetColor2()
      SetColor(txtColor2, Panel.BackColor2, Panel.ForeColor2)
   End Sub
   Private Sub SetColor(txt As TextBox, backColor As Integer?, foreColor As Integer?)
      SetColor(txt, If(backColor.HasValue, Color.FromArgb(backColor.Value), Nothing), If(foreColor.HasValue, Color.FromArgb(foreColor.Value), Nothing))
   End Sub
   Private Sub SetColor(txt As TextBox, backColor As Color, foreColor As Color)
      txt.BackColor = backColor
      txt.ForeColor = foreColor
   End Sub
#End Region

End Class