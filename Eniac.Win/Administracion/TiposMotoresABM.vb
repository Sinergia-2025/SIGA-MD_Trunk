Option Explicit On
Option Strict On

Imports Eniac.Win
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class TiposMotoresABM

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Me.tsbImprimir.Visible = False
    End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposMotoresDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoMotor))
      End If
      Return New TiposMotoresDetalle(New Entidades.TipoMotor())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposMotores()
   End Function

   Protected Overrides Sub Imprimir()
        'MyBase.Imprimir()
        'Try
        '   Me.Cursor = Cursors.WaitCursor
        '   Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Productos.rdlc", "SistemaDataSet_Productos", Me.dtDatos, True)
        '   frmImprime.Text = "Productos"
        '   frmImprime.Show()
        '   Me.Cursor = Cursors.Default
        'Catch ex As Exception
        '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Protected Overrides Function GetEntidad() As Entidades.Entidad

        With Me.dgvDatos.ActiveRow
         Return New Reglas.TiposMotores().GetUno(Integer.Parse(.Cells(Entidades.TipoMotor.Columnas.IdTipoMotor.ToString()).Value.ToString()))
      End With

    End Function

    Protected Overrides Sub FormatearGrilla()
        With Me.dgvDatos.DisplayLayout.Bands(0)
            For Each col As UltraGridColumn In .Columns
                col.CellActivation = Activation.ActivateOnly
            Next

            .Columns(Entidades.TipoMotor.Columnas.IdTipoMotor.ToString()).Header.Caption = "Código"
            .Columns(Entidades.TipoMotor.Columnas.IdTipoMotor.ToString()).Width = 80
            .Columns(Entidades.TipoMotor.Columnas.IdTipoMotor.ToString()).CellAppearance.TextHAlign = HAlign.Right
            .Columns(Entidades.TipoMotor.Columnas.NombreTipoMotor.ToString()).Header.Caption = "Nombre"
            .Columns(Entidades.TipoMotor.Columnas.NombreTipoMotor.ToString()).Width = 300
        End With
    End Sub

#End Region

End Class