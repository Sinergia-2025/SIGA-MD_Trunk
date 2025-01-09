Option Explicit On
Option Strict On



Public Class TiposNavesABM


#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Me.tsbImprimir.Visible = False
    End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposNavesDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoNave))
      End If
      Return New TiposNavesDetalle(New Entidades.TipoNave)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposNaves
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
         Return New Reglas.TiposNaves().GetUno(Integer.Parse(.Cells(Entidades.TipoNave.Columnas.IdTipoNave.ToString()).Value.ToString()))
      End With

    End Function

    Protected Overrides Sub FormatearGrilla()
        With Me.dgvDatos.DisplayLayout.Bands(0)
            For Each col As UltraGridColumn In .Columns
                col.CellActivation = Activation.ActivateOnly
            Next

            .Columns(Entidades.TipoNave.Columnas.IdTipoNave.ToString()).Header.Caption = "Código"
            .Columns(Entidades.TipoNave.Columnas.IdTipoNave.ToString()).Width = 80
            .Columns(Entidades.TipoNave.Columnas.IdTipoNave.ToString()).CellAppearance.TextHAlign = HAlign.Right
            .Columns(Entidades.TipoNave.Columnas.NombreTipoNave.ToString()).Header.Caption = "Nombre"
            .Columns(Entidades.TipoNave.Columnas.NombreTipoNave.ToString()).Width = 300
            .Columns(Entidades.TipoNave.Columnas.Seco.ToString()).Header.Caption = "Es seco"
        End With
    End Sub

#End Region

End Class