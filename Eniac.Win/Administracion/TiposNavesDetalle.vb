Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class TiposNavesDetalle

#Region "Campos"

    Private _publicos As Publicos

#End Region

#Region "Constructores"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal entidad As Entidades.TipoNave)
        Me.InitializeComponent()
        Me._entidad = entidad
    End Sub

#End Region

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Try
            Me._publicos = New Publicos()

            Me.BindearControles(Me._entidad)

            If Me.StateForm = Eniac.Win.StateForm.Insertar Then

                Me.CargarProximoNumero()
                DirectCast(Me._entidad, Entidades.TipoNave).Usuario = actual.Nombre

            Else

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposNaves
   End Function

   Protected Overrides Function ValidarDetalle() As String

        Return MyBase.ValidarDetalle()
    End Function

#End Region

#Region "Eventos"

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not Me.HayError Then Me.Close()
        Me.txtNombre.Focus()
    End Sub

#End Region

#Region "Metodos"

    Private Sub CargarProximoNumero()
        Dim oTipoNave As Reglas.TiposNaves = New Reglas.TiposNaves()
        Me.txtId.Text = (oTipoNave.GetCodigoMaximo() + 1).ToString()
    End Sub

#End Region

End Class