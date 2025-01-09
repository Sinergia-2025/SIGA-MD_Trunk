Public Class CRMEstadosCiclosPlanificacionDetalle

   Private ReadOnly Property CRMEstadoCicloPlanificacion As Entidades.CRMEstadoCicloPlanificacion
      Get
         Return DirectCast(_entidad, Entidades.CRMEstadoCicloPlanificacion)
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

   Public Sub New(entidad As Entidades.CRMEstadoCicloPlanificacion)
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

         _publicos.CargaComboDesdeEnum(cmbTiposEstados, Entidades.CRMEstadoCicloPlanificacion.TiposEstadosCicloPlanificacion.PENDIENTE)

         BindearControles(_entidad)

         If StateForm = StateForm.Insertar Then
            CargarValoresIniciales()

         Else
            If CRMEstadoCicloPlanificacion.BackColor.HasValue Then
               lblBackColor.Checked = True
               txtBackColor.BackColor = Color.FromArgb(CRMEstadoCicloPlanificacion.BackColor.Value)
            Else
               lblBackColor.Checked = False
            End If

            If CRMEstadoCicloPlanificacion.ForeColor.HasValue Then
               lblForeColor.Checked = True
               txtForeColor.BackColor = Color.FromArgb(CRMEstadoCicloPlanificacion.ForeColor.Value)
            Else
               lblForeColor.Checked = False
            End If
         End If
         MostrarTextoEjemplo()
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CRMEstadosCiclosPlanificacion()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function

   Protected Overrides Sub Aceptar()
      If lblBackColor.Checked Then
         CRMEstadoCicloPlanificacion.BackColor = txtBackColor.BackColor.ToArgb()
      Else
         CRMEstadoCicloPlanificacion.BackColor = Nothing
      End If
      If lblForeColor.Checked Then
         CRMEstadoCicloPlanificacion.ForeColor = txtForeColor.BackColor.ToArgb()
      Else
         CRMEstadoCicloPlanificacion.ForeColor = Nothing
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
            CRMEstadoCicloPlanificacion.BackColor = cdColor.Color.ToArgb()
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
            CRMEstadoCicloPlanificacion.ForeColor = cdColor.Color.ToArgb()
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
      txtOrden.SetValor(New Reglas.CRMEstadosCiclosPlanificacion().GetOrdenMaximo() + 10)
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