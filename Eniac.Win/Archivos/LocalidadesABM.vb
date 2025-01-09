Imports Eniac.Win

Public Class LocalidadesABM

#Region "Overrides"

    Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
        If estado = StateForm.Actualizar Then
         Return New LocalidadesDetalle(DirectCast(Me.GetEntidad(), Entidades.Localidad))
        End If
        Return New LocalidadesDetalle(New Entidades.Localidad)
   End Function

    Protected Overrides Function GetReglas() As Eniac.Reglas.Base
        Return New Reglas.Localidades()
   End Function

    Protected Overrides Sub Imprimir()
        MyBase.Imprimir()
        Try
            Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Localidades.rdlc", "SistemaDataSet_Localidades", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
            frmImprime.Text = "Localidades"
            frmImprime.Show()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim loca As Entidades.Localidad = New Entidades.Localidad()
      With Me.dgvDatos.ActiveCell.Row
         loca.IdLocalidad = Int32.Parse(.Cells("IdLocalidad").Value.ToString())
         loca.IdProvincia = .Cells("IdProvincia").Value.ToString()
         loca.NombreLocalidad = .Cells("NombreLocalidad").Value.ToString()
      End With
      Return loca
   End Function

    Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns("IdLocalidad").Header.Caption = "C.P."
         .Columns("IdLocalidad").Width = 50
         .Columns("NombreLocalidad").Header.Caption = "Localidad"
         .Columns("NombreLocalidad").Width = 300
         .Columns("IdProvincia").Hidden = True
         .Columns("NombreProvincia").Header.Caption = "Provincia"
         .Columns("NombreProvincia").Width = 120
         '.Columns("NombreProvincia").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

         AgregarFiltroEnLinea(Me.dgvDatos, {"NombreLocalidad", "NombreProvincia"})
      End With
    End Sub

#End Region

End Class
