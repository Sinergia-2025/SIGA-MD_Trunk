Public Class ConsultaGenerica

#Region "Campos"

   Private _datos As Object
   Private _columnasContains As String()
   Private _columnasSum As String()

#End Region

#Region "Constructores"
   Public Sub New()
      Me.New(Nothing)
   End Sub
   Public Sub New(datos As Object)
      Me.New(datos, {}, {})
   End Sub

   Public Sub New(datos As Object, columnasContains As String(), columnasSum As String())
      MyBase.New()
      InitializeComponent()
      _datos = datos
      _columnasContains = columnasContains
      _columnasSum = columnasSum
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            ugDetalle.DataSource = _datos

            For Each cl As UltraGridColumn In ugDetalle.DisplayLayout.Bands(0).Columns
               cl.CellActivation = Activation.ActivateOnly
               If cl.DataType Is GetType(Decimal) Or cl.DataType Is GetType(Integer) Or cl.DataType Is GetType(Long) Then
                  cl.CellAppearance.TextHAlign = HAlign.Right
                  'GAR: 04/02/2023. Importe y Saldo.
                  'GAR: 07/02/2023. Se agrego "Total / Porc" aunque es posible que el futuro se use para algo no Decimal.
                  If cl.Key.Contains("Importe") Or cl.Key.Contains("Saldo") Or cl.Key.Contains("Total") Or cl.Key.Contains("Porc") Then
                     cl.Format = "N2"
                     cl.Width = 100
                  End If

               ElseIf cl.DataType Is GetType(Date) Then
                  cl.Width = 90
                  'GAR: Muy Profesional!! jaja
                  If cl.Key.Contains("Hora") Then
                     cl.Format = "dd/MM/yyyy HH:mm"
                     cl.Width = 100
                  End If
               End If
               cl.MaxWidth = 200
            Next
            ugDetalle.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand)

            ugDetalle.AgregarFiltroEnLinea(_columnasContains)
            If _columnasSum.Count > 0 Then
               ugDetalle.AgregarTotalesSuma(_columnasSum)
            End If

            tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.Escape Then
         Close()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(Text, String.Empty))
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, String.Empty))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Me.Text, UltraGridDocumentExporter1, String.Empty))
   End Sub

   Private Sub tsbCerrar_Click(sender As Object, e As EventArgs) Handles tsbCerrar.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub
#End Region

End Class