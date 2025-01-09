Public Class EstadosProyectosDetalle

#Region "Constructores"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Public Sub New(ByVal entidad As Eniac.Entidades.ProyectoEstado)
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


            If Me.StateForm = Eniac.Win.StateForm.Insertar Then

                Me.txtIdEstado.Text = (DirectCast(GetReglas(), Reglas.ProyectosEstados).GetCodigoMaximo() + 1).ToString()

            Else

                If DirectCast(Me._entidad, Entidades.ProyectoEstado).Color.HasValue Then
                    Me.txtColor.BackColor = System.Drawing.Color.FromArgb(DirectCast(Me._entidad, Entidades.ProyectoEstado).Color.Value)
                Else
                    Me.txtColor.BackColor = Nothing
                End If

            End If

        Catch ex As Exception
            ShowError(ex)
        End Try

    End Sub

    Protected Overrides Function GetReglas() As Eniac.Reglas.Base
        Return New Reglas.ProyectosEstados()
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

#Region "Eventos"

    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        Try
            Me.cdColor.Color = Me.txtColor.BackColor

            If Me.cdColor.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.txtColor.Key = Me.cdColor.Color.ToArgb().ToString()
                DirectCast(Me._entidad, Entidades.ProyectoEstado).Color = Me.cdColor.Color.ToArgb()
                Me.txtColor.BackColor = Me.cdColor.Color
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

#End Region

End Class