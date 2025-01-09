#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports Eniac.Win
#End Region
Public Class TiposChequesABM

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        'Me.BotonImprimir.Visible = False
    End Sub

    Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
        If estado = StateForm.Actualizar Then
            Return New TiposChequesDetalle(DirectCast(Me.GetEntidad(), Entidades.TiposCheques))
        End If
        Return New TiposChequesDetalle(New Eniac.Entidades.TiposCheques())
    End Function

    Protected Overrides Function GetReglas() As Eniac.Reglas.Base
        Return New Reglas.TiposCheques()
    End Function

    Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
        MyBase.GetEntidad()
        With Me.dgvDatos.ActiveRow
            Return New Reglas.TiposCheques().GetUno((.Cells(Entidades.TiposCheques.Columnas.IdTipoCheque.ToString()).Value.ToString()))
        End With
    End Function
    Protected Overrides Sub FormatearGrilla()
        Try


            With Me.dgvDatos.DisplayLayout.Bands(0)

                Dim col As Integer = 0

                .Columns(Entidades.TiposCheques.Columnas.IdTipoCheque.ToString()).FormatearColumna("Código", col, 60, HAlign.Right)
                .Columns(Entidades.TiposCheques.Columnas.NombreTipoCheque.ToString()).FormatearColumna("Descripción", col, 180)
                .Columns(Entidades.TiposCheques.Columnas.SolicitaNroOperacion.ToString()).FormatearColumna("Solicitar Nro Operación", col, 180)

            End With

            ' Agrego el Filtro en Linea x Descripción de la clase
            AgregarFiltroEnLinea(dgvDatos, {Entidades.TiposCheques.Columnas.NombreTipoCheque.ToString()})
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

#End Region

#Region "Eventos"

    '#

#End Region

End Class