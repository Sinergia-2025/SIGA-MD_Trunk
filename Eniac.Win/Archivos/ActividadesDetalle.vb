Public Class ActividadesDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Actividad)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me.cmbProvincia.DisplayMember = "NombreProvincia"
      Me.cmbProvincia.ValueMember = "IdProvincia"
      Me.cmbProvincia.DataSource = New Reglas.Provincias().GetAll()

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.cmbProvincia.Text = New Reglas.Localidades().GetUna(Publicos.LocalidadEmpresa).NombreProvincia.ToString()
         Me.CargarProximoNumero(Me.cmbProvincia.SelectedValue.ToString())
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Actividades
   End Function

   Protected Overrides Function ValidarDetalle() As String

      Dim vacio As String = ""

      If Math.Abs(Decimal.Parse(Me.txtPorcentaje.Text)) >= 100 Then
         Return "El Descuento/Recargo NO es Válido."
      End If

      Return vacio

   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtActividad.Focus()
   End Sub

   Private Sub cmbProvincia_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged
      Try
         Dim provincia As String = ""
         If Me.cmbProvincia.SelectedValue IsNot Nothing Then
            provincia = Me.cmbProvincia.SelectedValue.ToString()

            If Not String.IsNullOrEmpty(provincia) Then
               Me.CargarProximoNumero(provincia)
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero(ByVal idProvincia As String)
      Dim oCateg As Reglas.Actividades = New Reglas.Actividades()
      Me.txtActividad.Text = (oCateg.GetIdMaximo(idProvincia) + 1).ToString()
   End Sub

#End Region


End Class
