Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class SueldosCategoriasDetalle

#Region "Constructores"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal entidad As Entidades.SueldosCategoria)
        Me.InitializeComponent()
        Me._entidad = entidad
    End Sub

#End Region

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)

        Me.BindearControles(Me._entidad)

        If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            DirectCast(Me._entidad, Entidades.SueldosCategoria).Usuario = actual.Nombre
        End If

    End Sub

    Protected Overrides Function GetReglas() As Eniac.Reglas.Base
        Return New Reglas.SueldosCategorias()
    End Function

    Protected Overrides Sub Aceptar()
        MyBase.Aceptar()
        Me.txtIdCategoria.Focus()
    End Sub

#End Region



End Class




