Imports Eniac.Win
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class RegimenesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New RegimenesDetalle(DirectCast(Me.GetEntidad(), Entidades.Regimen))
      End If
      Return New RegimenesDetalle(New Entidades.Regimen)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Regimenes()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      'Try
      '   Me.Cursor = Cursors.WaitCursor

      '   Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

      '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresa))
      '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

      '   Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Productos.rdlc", "SistemaDataSet_Productos", Me.dtDatos, parm, True)

      '   frmImprime.Text = Me.Text
      '   frmImprime.Show()
      '   Me.Cursor = Cursors.Default
      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim regi As Entidades.Regimen = New Entidades.Regimen

      With Me.dgvDatos.ActiveCell.Row
         regi.IdRegimen = Integer.Parse(.Cells("IdRegimen").Value.ToString())
         regi = New Reglas.Regimenes().GetUno(regi.IdRegimen)
         regi.Usuario = actual.Sucursal.Usuario
      End With

      Return regi

   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.Regimen.Columnas.IdRegimen.ToString()).Header.Caption = "Régimen"
         .Columns(Entidades.Regimen.Columnas.IdRegimen.ToString()).Width = 50
         .Columns(Entidades.Regimen.Columnas.IdRegimen.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Regimen.Columnas.ConceptoRegimen.ToString()).Header.Caption = "Concepto"
         .Columns(Entidades.Regimen.Columnas.ConceptoRegimen.ToString()).Width = 250

         .Columns(Entidades.Regimen.Columnas.ARetenerInscripto.ToString()).Header.Caption = "Ret. Inscr."
         .Columns(Entidades.Regimen.Columnas.ARetenerInscripto.ToString()).Width = 80
         .Columns(Entidades.Regimen.Columnas.ARetenerInscripto.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Regimen.Columnas.ARetenerNoInscripto.ToString()).Header.Caption = "Ret No Incr."
         .Columns(Entidades.Regimen.Columnas.ARetenerNoInscripto.ToString()).Width = 80
         .Columns(Entidades.Regimen.Columnas.ARetenerNoInscripto.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Regimen.Columnas.MontoAExceder.ToString()).Header.Caption = "Monto a Exceder"
         .Columns(Entidades.Regimen.Columnas.MontoAExceder.ToString()).Width = 80
         .Columns(Entidades.Regimen.Columnas.MontoAExceder.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Regimen.Columnas.MinimoNoImponible.ToString()).Header.Caption = "Minimo No Imponible"
         .Columns(Entidades.Regimen.Columnas.MinimoNoImponible.ToString()).Width = 80
         .Columns(Entidades.Regimen.Columnas.MinimoNoImponible.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Regimen.Columnas.ImporteMinimoInscripto.ToString()).Header.Caption = "Imp. Mínimo Inscr."
         .Columns(Entidades.Regimen.Columnas.ImporteMinimoInscripto.ToString()).Width = 80
         .Columns(Entidades.Regimen.Columnas.ImporteMinimoInscripto.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Regimen.Columnas.ImporteMinimoNoInscripto.ToString()).Header.Caption = "Imp. Mínimo No Inscr."
         .Columns(Entidades.Regimen.Columnas.ImporteMinimoNoInscripto.ToString()).Width = 80
         .Columns(Entidades.Regimen.Columnas.ImporteMinimoNoInscripto.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Regimen.Columnas.IdTipoImpuesto.ToString()).Header.Caption = "Tipo Imp"
         .Columns(Entidades.Regimen.Columnas.IdTipoImpuesto.ToString()).Width = 65
         .Columns(Entidades.Regimen.Columnas.IdTipoImpuesto.ToString()).CellAppearance.TextHAlign = HAlign.Center
         .Columns(Entidades.Regimen.Columnas.IdTipoImpuesto.ToString()).Hidden = True

         .Columns("NombreTipoImpuesto").Header.Caption = "Impuesto"
         .Columns("NombreTipoImpuesto").Width = 100

         .Columns(Entidades.Regimen.Columnas.RetienePorEscala.ToString()).Header.Caption = "Escala"
         .Columns(Entidades.Regimen.Columnas.ImporteMinimoNoInscripto.ToString()).Width = 40

         .Columns(Entidades.Regimen.Columnas.OrigenBaseImponible.ToString()).Header.Caption = "Origen Base"
         .Columns(Entidades.Regimen.Columnas.OrigenBaseImponible.ToString()).Width = 60

         .Columns(Entidades.Regimen.Columnas.CodigoAfip.ToString()).Header.Caption = "Código AFIP"
         .Columns(Entidades.Regimen.Columnas.CodigoAfip.ToString()).Width = 70
         .Columns(Entidades.Regimen.Columnas.CodigoAfip.ToString()).CellAppearance.TextHAlign = HAlign.Right

      End With
   End Sub

#End Region


End Class