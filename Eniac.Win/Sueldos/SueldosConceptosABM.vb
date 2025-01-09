Option Strict Off

Public Class SueldosConceptosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SueldosConceptosDetalle(DirectCast(Me.GetEntidad(), Entidades.SueldosConcepto))
      End If
      Return New SueldosConceptosDetalle(New Entidades.SueldosConcepto)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SueldosConceptos()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Productos.rdlc", "SistemaDataSet_Productos", Me.dtDatos, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim ent As Entidades.SueldosConcepto = New Entidades.SueldosConcepto

      With Me.dgvDatos.SelectedCells(0).OwningRow

         ent.idConcepto = .Cells("IdConcepto").Value.ToString().Trim()

         ent = New Reglas.SueldosConceptos().GetUno(ent.idConcepto)

         'ent.NombreConcepto = .Cells("NombreConcepto").Value.ToString().Trim()
         'ent.idTipoConcepto = .Cells("IdTipoConcepto").Value.ToString().Trim()

         'ent.Tipo = .Cells("Tipo").Value.ToString().Trim()
         'ent.idQuepide = .Cells("idQuepide").Value.ToString().Trim()

         'ent.Valor = .Cells("Valor").Value.ToString().Trim()

         'ent.Aguinaldo = .Cells("Aguinaldo").Value.ToString().Trim()
         '   If Boolean.Parse(.Cells("LiquidacionAnual").Value.ToString()) = False Then
         '       ent.LiquidacionAnual = False
         '   Else
         '       ent.LiquidacionAnual = True
         '   End If

         'ent.LiquidacionMeses = .Cells("LiquidacionMeses").Value.ToString().Trim()

         'Dim Aguinaldo As Boolean = False
         'If ent.Aguinaldo = "S" Then
         '   Aguinaldo = True
         'End If

         ''    produ.Calculo1 = .Cells("Calculo1").Value.ToString().Trim()
         'ent.Formula = .Cells("Formula").Value.ToString().Trim()

         'PORQUE LO VUELVE A HACER ???
         'ent = New Reglas.SueldosConceptos().GetUno(ent.idConcepto, Aguinaldo)

         ent.Usuario = actual.Sucursal.Usuario

      End With

      Return ent

   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos

         .Columns("IdConcepto").Visible = False
         .Columns("CodigoConcepto").HeaderText = "Concepto"
         .Columns("CodigoConcepto").Width = 60
         .Columns("CodigoConcepto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns("CodigoConcepto").DisplayIndex = 0

         .Columns("NombreConcepto").HeaderText = "Nombre Concepto"
         .Columns("NombreConcepto").Width = 200
         .Columns("IdTipoConcepto").Visible = False
         .Columns("NombreTipoConcepto").HeaderText = "Nombre Tipo Concepto"
         .Columns("NombreTipoConcepto").Width = 150

         .Columns("IdQuepide").Visible = False
         .Columns("NombreQuePide").HeaderText = "Que Pide"
         .Columns("NombreQuePide").Width = 80

         .Columns("Tipo").HeaderText = "Tipo"
         .Columns("Tipo").Width = 40
         .Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns("Valor").HeaderText = "Valor"
         .Columns("Valor").Width = 70
         .Columns("Valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns("EsContempladoAguinaldo").HeaderText = "Cont. Aguin."
         .Columns("EsContempladoAguinaldo").Width = 50
         .Columns("EsContempladoAguinaldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns("Aguinaldo").HeaderText = "Aguin."
         .Columns("Aguinaldo").Width = 50
         .Columns("Aguinaldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns("LiquidacionAnual").HeaderText = "Liq. Anual"
         .Columns("LiquidacionAnual").Width = 50

         .Columns("Formula").HeaderText = "Formula"
         .Columns("Formula").Width = 200
         '.Columns("Formula").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

         .Columns("LiquidacionMeses").Visible = False

         .Columns("MostrarEnRecibo").HeaderText = "Mostrar en Recibo"
         .Columns("MostrarEnRecibo").Width = 100
      End With

   End Sub

#End Region

End Class
