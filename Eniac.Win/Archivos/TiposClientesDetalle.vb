Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class TiposClientesDetalle

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.TipoCliente)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Propiedades"

   Private _idTipoCliente As Integer
   Public Property IdTipoCliente() As Integer
      Get
         Return Me._idTipoCliente
      End Get
      Set(ByVal value As Integer)
         Me._idTipoCliente = value
      End Set
   End Property


#End Region


#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
         DirectCast(Me._entidad, Entidades.TipoCliente).Usuario = actual.Nombre
      End If

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposClientes()
   End Function

   Protected Overrides Sub Aceptar()

      Me.IdTipoCliente = Integer.Parse(Me.txtIdTipoCliente.Text.ToString())

      MyBase.Aceptar()

      If Not Me.HayError Then Me.Close()

   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
      End If
      Me.txtIdTipoCliente.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim oTipoCliente As Reglas.TiposClientes = New Reglas.TiposClientes()
      Me.txtIdTipoCliente.Text = oTipoCliente.GetProximoId().ToString("##0")
   End Sub

#End Region

End Class