Public Class TiposDeExensionDetalle

#Region "Campos"

    Private _publicos As Publicos
    Private _cargandoPantalla As Boolean = True

#End Region

#Region "Constructores"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    Public Sub New(ByVal entidad As Entidades.TipoDeExension)
        Me.InitializeComponent()
        Me._entidad = entidad
    End Sub

#End Region

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

        MyBase.OnLoad(e)

        Me._publicos = New Publicos()

        Me.BindearControles(Me._entidad)

        If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.chbActivo.Checked = True
            Me.CargarProximoCodigo()
        End If

        Me._cargandoPantalla = False

    End Sub

    Protected Overrides Function GetReglas() As Eniac.Reglas.Base
        Return New Reglas.TiposDeExension
    End Function

    Protected Overrides Sub LimpiarControles()
        MyBase.LimpiarControles()
    End Sub

#End Region

#Region "Eventos"

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not Me.HayError Then Me.Close()
        Me.txtIdTipoDeExension.Focus()
    End Sub

#End Region

#Region "Metodos"

    Private Sub CargarProximoCodigo()
        Dim oRegTiposDeExension As Reglas.TiposDeExension = New Reglas.TiposDeExension()
        Dim ProximoTipoDeExension As Integer
        ProximoTipoDeExension = oRegTiposDeExension.GetCodigoMaximo() + 1
        Me.txtIdTipoDeExension.Text = ProximoTipoDeExension.ToString()
    End Sub

#End Region

End Class
