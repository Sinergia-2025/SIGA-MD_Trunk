Public Class TableroDeComandox1
   Inherits BaseForm
   Implements IConParametros

   Private Const CantidadMinimaTableros As Integer = 1

#Region "Campos"
   Private _publicos As Publicos
   Private _initializing As Boolean = True
   Private _controller As TableroDeComandoController
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _controller = New TableroDeComandoController(Me, {tsbRefrescar, btnConsultar}) With {.Timer1 = Timer1, .tssInfo = tssInfo}


         Me._publicos = New Publicos()

         _publicos.CargaComboTablerosControlPaneles(cmbPaneles)

         Me.txtMinutos.Value = Publicos.MinutosTableroComando
         chbActualizacionAutomatica.Checked = False

      Catch ex As Exception
         ShowError(ex)
      Finally
         _initializing = False
      End Try

      Try
         CargarDatosGrillas()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      End If

      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
#End Region

#Region "Metodos"
   Private Sub RefrescarGrilla()
      _controller.RefrescarGrillas()
      '_controller.InicializaBackgroundWorker()
   End Sub
   Private Sub CargarDatosGrillas()
      _controller.CargarGrillaDetalle()
   End Sub
   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      With filtro

         .AppendFormat("{1}: {0} - ", Me.cmbPaneles.Text, lblPaneles.Text)

         'cmbCategoriasClientes.CargarFiltrosImpresionCategorias(filtro, False, True)
         'filtro.Append(" - ")

         'If Me.chbActualizaAplicacion.Checked Then
         '   .AppendFormat("{1}: {0} - ", Me.cmbActualizaAplicacion.Text, chbActualizaAplicacion.Text)
         'End If

         '.AppendFormat("{1}: {0} - ", Me.cmbNombreCliente.Text, lblNombreCliente.Text)
      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

#End Region

#Region "Eventos"
   Private Sub chbActualizacionAutomatica_CheckedChanged(sender As Object, e As EventArgs) Handles chbActualizacionAutomatica.CheckedChanged
      Try
         If _initializing Then Return
         _controller.ActualizacionAutomatica = chbActualizacionAutomatica.Checked
         cmbPaneles.Enabled = Not chbActualizacionAutomatica.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtSegundos_ValueChanged(sender As Object, e As EventArgs) Handles txtMinutos.ValueChanged
      Try
         If _initializing Then Return
         _controller.Intervalo = Convert.ToInt32(txtMinutos.Value)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarGrilla())
   End Sub
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(Sub() CargarDatosGrillas())
   End Sub
   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
   Private Sub cmbPaneles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaneles.SelectedIndexChanged
      Try
         Dim panel = cmbPaneles.ItemSeleccionado(Of Entidades.TableroControlPanel)()
         If cmbPaneles.SelectedIndex > -1 AndAlso panel IsNot Nothing Then
            _controller.ClearGrillas()
            _controller.AgregarGrilla(_controller.Crear(panel, ugGrilla1))
            _controller.CargarGrillaDetalle()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugGrilla1.Rows.Count = 0 Then Exit Sub
         Dim Filtros As String = Me.CargarFiltrosImpresion
         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraPrintPreviewDialog1.Name = Me.Text
         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub tsmiAExcel_Click_1(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugGrilla1.Rows.Count = 0 Then Exit Sub
         ugGrilla1.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub tsmiAPDF_Click_1(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugGrilla1.Rows.Count = 0 Then Exit Sub
         ugGrilla1.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      '_tableros = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

End Class