Public Class EstadosOrdenesCalidadDetalle

   Private ReadOnly Property EstadoOrdenCalidad As Entidades.EstadoOrdenCalidad
      Get
         Return DirectCast(_entidad, Entidades.EstadoOrdenCalidad)
      End Get
   End Property

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.EstadoOrdenCalidad)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(cmbTiposEstados, Entidades.EstadoOrdenCalidad.TiposEstadosCalidad.PENDIENTE)

         BindearControles(_entidad)

         If StateForm = StateForm.Insertar Then
            CargarValoresIniciales()

         Else
            If EstadoOrdenCalidad.BackColor.HasValue Then
               lblBackColor.Checked = True
               txtBackColor.BackColor = Color.FromArgb(EstadoOrdenCalidad.BackColor.Value)
            Else
               lblBackColor.Checked = False
            End If

            If EstadoOrdenCalidad.ForeColor.HasValue Then
               lblForeColor.Checked = True
               txtForeColor.BackColor = Color.FromArgb(EstadoOrdenCalidad.ForeColor.Value)
            Else
               lblForeColor.Checked = False
            End If
         End If
         MostrarTextoEjemplo()
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.EstadosOrdenesCalidad()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function

   Protected Overrides Sub Aceptar()
      If lblBackColor.Checked Then
         EstadoOrdenCalidad.BackColor = txtBackColor.BackColor.ToArgb()
      Else
         EstadoOrdenCalidad.BackColor = Nothing
      End If
      If lblForeColor.Checked Then
         EstadoOrdenCalidad.ForeColor = txtForeColor.BackColor.ToArgb()
      Else
         EstadoOrdenCalidad.ForeColor = Nothing
      End If
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"
   Private Sub lblBackColor_CheckedChanged(sender As Object, e As EventArgs) Handles lblBackColor.CheckedChanged
      TryCatched(
      Sub()
         txtBackColor.Enabled = lblBackColor.Checked
         btnBackColor.Enabled = lblBackColor.Checked
         MostrarTextoEjemplo()
      End Sub)
   End Sub
   Private Sub lblForeColor_CheckedChanged(sender As Object, e As EventArgs) Handles lblForeColor.CheckedChanged
      TryCatched(
      Sub()
         txtForeColor.Enabled = lblForeColor.Checked
         btnForeColor.Enabled = lblForeColor.Checked
         MostrarTextoEjemplo()
      End Sub)
   End Sub

   Private Sub btnBackColor_Click(sender As Object, e As EventArgs) Handles btnBackColor.Click
      TryCatched(
      Sub()
         cdColor.Color = txtBackColor.BackColor
         If cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtBackColor.Key = cdColor.Color.ToArgb().ToString()
            EstadoOrdenCalidad.BackColor = cdColor.Color.ToArgb()
            txtBackColor.BackColor = cdColor.Color
         End If
         MostrarTextoEjemplo()
      End Sub)
   End Sub
   Private Sub btnForeColor_Click(sender As Object, e As EventArgs) Handles btnForeColor.Click
      TryCatched(
      Sub()
         cdColor.Color = txtForeColor.BackColor
         If cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtForeColor.Key = cdColor.Color.ToArgb().ToString()
            EstadoOrdenCalidad.ForeColor = cdColor.Color.ToArgb()
            txtForeColor.BackColor = cdColor.Color
         End If
         MostrarTextoEjemplo()
      End Sub)
   End Sub
   Private Sub txtIdEstado_TextChanged(sender As Object, e As EventArgs) Handles txtIdEstado.TextChanged
      TryCatched(Sub() MostrarTextoEjemplo())
   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()
      txtBackColor.BackColor = Nothing
      txtForeColor.BackColor = Nothing
      txtOrden.SetValor(New Reglas.EstadosOrdenesCalidad().GetOrdenMaximo() + 10)
   End Sub

   Private Sub MostrarTextoEjemplo()
      lblEjemploColor.Text = txtIdEstado.Text

      If lblBackColor.Checked Then
         lblEjemploColor.BackColor = txtBackColor.BackColor
      Else
         lblEjemploColor.BackColor = Color.White
      End If
      If lblForeColor.Checked Then
         lblEjemploColor.ForeColor = txtForeColor.BackColor
      Else
         lblEjemploColor.ForeColor = Color.Black
      End If
   End Sub

#End Region


End Class