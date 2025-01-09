Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class TiposDeExensionABM

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Me.BotonImprimir.Visible = False
    End Sub

    Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
        If estado = StateForm.Actualizar Then
            Return New TiposDeExensionDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.TipoDeExension))
        End If
        Return New TiposDeExensionDetalle(New Entidades.TipoDeExension)
    End Function

    Protected Overrides Function GetReglas() As Eniac.Reglas.Base
        Return New Reglas.TiposDeExension()
    End Function

    Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
        MyBase.GetEntidad()
        Dim MoE As Entidades.TipoDeExension = New Entidades.TipoDeExension
        With Me.dgvDatos.ActiveCell.Row
            MoE.IdTipoDeExension = Short.Parse(.Cells(Entidades.TipoDeExension.Columnas.IdTipoDeExension.ToString()).Value.ToString())
            MoE = New Reglas.TiposDeExension().GetUno(MoE.IdTipoDeExension)
        End With
        Return MoE
    End Function

    Protected Overrides Sub FormatearGrilla()
        With Me.dgvDatos.DisplayLayout.Bands(0)
            .Columns(Entidades.TipoDeExension.Columnas.IdTipoDeExension.ToString()).Header.Caption = "Código"
            .Columns(Entidades.TipoDeExension.Columnas.IdTipoDeExension.ToString()).Width = 70
            .Columns(Entidades.TipoDeExension.Columnas.IdTipoDeExension.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
            .Columns(Entidades.TipoDeExension.Columnas.NombreTipoDeExension.ToString()).Header.Caption = "Nombre"
            .Columns(Entidades.TipoDeExension.Columnas.NombreTipoDeExension.ToString()).Width = 250
            .Columns(Entidades.TipoDeExension.Columnas.NombreTipoDeExensionAbrev.ToString()).Header.Caption = "Nombre Abrev."
            .Columns(Entidades.TipoDeExension.Columnas.NombreTipoDeExensionAbrev.ToString()).Width = 250
            .Columns(Entidades.TipoDeExension.Columnas.Activo.ToString()).Header.Caption = "Activo"
            .Columns(Entidades.TipoDeExension.Columnas.Activo.ToString()).Width = 70
        End With
    End Sub

#End Region

End Class