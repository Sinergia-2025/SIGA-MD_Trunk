Option Explicit On
Option Strict On

Public Class ContabilidadPlanesDetalle
#Region "Campos"

   Private _publicos As ContabilidadPublicos

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.ContabilidadPlan)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New ContabilidadPublicos()

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarValoresIniciales()
         Me.txtIdPlanCuenta.Focus()
      End If

      'If Me.StateForm = Eniac.Win.StateForm.Actualizar And CInt(Me.txtIdPlanCuenta.Text) = 1 Then
      '    MessageBox.Show("Este centro de costo no es editable", "Centro Costo", MessageBoxButtons.OK, MessageBoxIcon.Information)
      '    Me.Close()
      'End If


   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ContabilidadPlanes
   End Function

#End Region

#Region "Eventos"



   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
      '   Me.CargarValoresIniciales()
      'End If
      Me.txtIdPlanCuenta.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()
      Me.CargarProximoNumero()
   End Sub

   Private Sub CargarProximoNumero()
      Dim oplan As Reglas.ContabilidadPlanes = New Reglas.ContabilidadPlanes
      Dim ProximoID As Integer
      ProximoID = oplan.GetIdMaximo() + 1
      Me.txtIdPlanCuenta.Text = ProximoID.ToString()
   End Sub

#End Region

End Class