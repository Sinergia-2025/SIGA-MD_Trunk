Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class LocalidadesDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.Localidad)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Propiedades"

   Public Property IdLocalidad() As Integer
      Get
         Return Me._idLocalidad
      End Get
      Set(ByVal value As Integer)
         Me._idLocalidad = value
      End Set
   End Property

   Private _idLocalidad As Integer

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Dim dtProv As DataTable
      Dim oProv As Reglas.Provincias = New Reglas.Provincias()
      dtProv = oProv.GetAll()

      Me.cmbProvincia.DisplayMember = "NombreProvincia"
      Me.cmbProvincia.ValueMember = "IdProvincia"
      Me.cmbProvincia.DataSource = dtProv.Copy()
      Me.cmbProvincia.SelectedIndex = -1

      Me.BindearControles(Me._entidad)
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Localidades
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If Me.txtIdLocalidad.Text = "0" Then
         Me.txtIdLocalidad.Focus()
         Return "ATENCION: El Codigo Postal No puede ser 0."
      End If

      If Me.txtIdLocalidad.Text.Trim.Length < 4 Then
         Me.txtIdLocalidad.Focus()
         Return "ATENCION: El Codigo Postal debe tener al menos 4 digitos"
      End If

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()

      Me.IdLocalidad = Integer.Parse(Me.txtIdLocalidad.Text.ToString())

      MyBase.Aceptar()

      If Not Me.HayError Then Me.Close()

   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdLocalidad.Focus()
   End Sub

#End Region

End Class
