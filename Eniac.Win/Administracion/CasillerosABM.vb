Option Explicit On
Option Strict On

Imports Eniac.Win
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class CasillerosABM

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Me.tsbImprimir.Visible = False
    End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CasillerosDetalle(DirectCast(Me.GetEntidad(), Entidades.Casillero))
      End If
      Return New CasillerosDetalle(New Entidades.Casillero)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Casilleros
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
         Return New Reglas.Casilleros().GetUno(Integer.Parse(.Cells(Entidades.Casillero.Columnas.IdCasillero.ToString()).Value.ToString()))
      End With

    End Function

    Protected Overrides Sub FormatearGrilla()
        With Me.dgvDatos.DisplayLayout.Bands(0)
            For Each col As UltraGridColumn In .Columns
                col.CellActivation = Activation.ActivateOnly
            Next

            .Columns(Entidades.Casillero.Columnas.IdCasillero.ToString()).Hidden = True
            .Columns(Entidades.Casillero.Columnas.CodigoCasillero.ToString()).Header.Caption = "Código"
            .Columns(Entidades.Casillero.Columnas.CodigoCasillero.ToString()).Width = 80
            .Columns(Entidades.Casillero.Columnas.CodigoCasillero.ToString()).CellAppearance.TextHAlign = HAlign.Right
            .Columns(Entidades.Sector.Columnas.NombreSector.ToString()).Header.Caption = "Sector"
            .Columns(Entidades.Sector.Columnas.NombreSector.ToString()).Header.VisiblePosition = 2
            .Columns(Entidades.Sector.Columnas.NombreSector.ToString()).Width = 300
            .Columns(Entidades.Casillero.Columnas.IdSector.ToString()).Hidden = True
            .Columns(Entidades.Casillero.Columnas.FilaCasillero.ToString()).Header.Caption = "Fila"
            .Columns(Entidades.Casillero.Columnas.FilaCasillero.ToString()).Width = 80
            .Columns(Entidades.Casillero.Columnas.ColumnaCasillero.ToString()).Header.Caption = "Columna"
            .Columns(Entidades.Casillero.Columnas.ColumnaCasillero.ToString()).Width = 80
            .Columns(Entidades.Casillero.Columnas.Activo.ToString()).Header.Caption = "Activo"
            .Columns(Entidades.Casillero.Columnas.Activo.ToString()).Width = 50
            .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Header.Caption = "Asignado al cliente"
            .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Width = 300
            .Columns(Entidades.Casillero.Columnas.IdCliente.ToString()).Hidden = True
        End With
        Me.dgvDatos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
    End Sub

#End Region

End Class