Public Class CuentasBancariasClaseDetalle

#Region "Constructores"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal entidad As Eniac.Entidades.CuentaBancariaClase)
        Me.InitializeComponent()
        Me._entidad = entidad
    End Sub

#End Region

#Region "Campos"

    Private _publicos As Publicos

#End Region

#Region "Overrides"

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)

        Try
            _publicos = New Publicos

            Me.BindearControles(Me._entidad, Me._liSources)

            ' I
            If Me.StateForm = Eniac.Win.StateForm.Insertar Then
                Me.txtIdCuentaBancariaClase.Text = (DirectCast(GetReglas(), Reglas.CuentasBancariasClase).GetCodigoMaximo() + 1).ToString()
            Else ' U
            
            End If

        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Protected Overrides Function GetReglas() As Eniac.Reglas.Base
        Return New Reglas.CuentasBancariasClase()
    End Function

    Protected Overrides Sub Aceptar()

        MyBase.Aceptar()

        If Not Me.HayError And Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.Close()
        End If
    End Sub

    Protected Overrides Function ValidarDetalle() As String

        Return MyBase.ValidarDetalle()
    End Function





#End Region

End Class