Imports Eniac.Win

Public Class ActividadesABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ActividadesDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.Actividad))
      End If
      Return New ActividadesDetalle(New Entidades.Actividad)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Actividades()
   End Function
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Actividades.rdlc", "SistemaDataSet_Actividades", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "Actividades"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim acti As Entidades.Actividad = New Entidades.Actividad
      With Me.dgvDatos.ActiveCell.Row
         acti.IdProvincia = .Cells("IdProvincia").Value.ToString()
         acti.IdActividad = Int32.Parse(.Cells("IdActividad").Value.ToString())
         acti.NombreActividad = .Cells("NombreActividad").Value.ToString()
         acti.Porcentaje = Decimal.Parse(.Cells("Porcentaje").Value.ToString())
         If Not String.IsNullOrEmpty(.Cells("BaseImponible").Value.ToString()) Then
            acti.BaseImponible = Decimal.Parse(.Cells("BaseImponible").Value.ToString())
         End If
         If Not String.IsNullOrEmpty(.Cells("CodigoAfip").Value.ToString()) Then
            acti.CodigoAfip = Integer.Parse(.Cells("CodigoAfip").Value.ToString())
         End If
      End With
      Return acti
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns("IdProvincia").Hidden = True
         .Columns("NombreProvincia").Header.Caption = "Provincia"
         .Columns("NombreProvincia").Width = 120
         .Columns("IdActividad").Header.Caption = "Cod. Actividad"
         .Columns("IdActividad").Width = 60
         .Columns("NombreActividad").Header.Caption = "Actividad"
         .Columns("NombreActividad").Width = 300
         .Columns("Porcentaje").Header.Caption = "Porcentaje"
         .Columns("Porcentaje").Width = 90
         .Columns("Porcentaje").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Porcentaje").Format = "N2"
         .Columns("BaseImponible").Header.Caption = "Base Imponible"
         .Columns("BaseImponible").Width = 100
         .Columns("BaseImponible").CellAppearance.TextHAlign = HAlign.Right
         .Columns("BaseImponible").Format = "N2"
         .Columns("CodigoAfip").Header.Caption = "Codigo Afip"
         .Columns("CodigoAfip").Width = 100
         .Columns("CodigoAfip").CellAppearance.TextHAlign = HAlign.Right

      End With
   End Sub

#End Region

End Class