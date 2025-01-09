#Region "Option/Imports"
'Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class EnviosOCLogE
#Region "Campos"

   Private _publicos As Publicos

   Private _OC As List(Of Entidades.ActivacionOC)

   Private _tit As Dictionary(Of String, String)
   Private _tipoTipoComprobante As String


#End Region
   Enum TipoEnvio As Integer
      TODOS = 0
      M_Manual = 1
      A_Automático = 2
      N_NoEnviar = 3
      P_Proceso = 4
   End Enum


#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.Cursor = Cursors.WaitCursor

         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSPROV"

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
         Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
         _publicos.CargaComboUsuarios(cmbUsuario)

         Me._publicos.CargaComboEstadosPedidosProvCalidad(cmbEstados, True, True, False, True, False, _tipoTipoComprobante)
         Me.cmbEstados.SelectedIndex = 1

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.AddDays(1).AddSeconds(-1)

         _tit = GetColumnasVisiblesGrilla(ugeResumen)

         Me.ugeResumen.AgregarFiltroEnLinea({})

         PreferenciasLeer(Me.ugeResumen, tsbPreferencias)
         Me.btnConsultar.PerformClick()

         Me.Cursor = Cursors.Default

      Catch ex As Exception

         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region


#Region "Eventos"

   Private Sub ugeResumen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugeResumen.InitializeLayout
      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft
      e.Layout.ViewStyle = ViewStyle.MultiBand
      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try

         If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         If Me.chbIdPedido.Checked AndAlso Integer.Parse("0" & Me.txtIdPedido.Text) = 0 Then
            MessageBox.Show("ATENCION: NO Ingresó un Número de Orden de Compra aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtIdPedido.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         If Me.ugeResumen.DataSource IsNot Nothing AndAlso TypeOf (ugeResumen.DataSource) Is DataSet Then
            DirectCast(Me.ugeResumen.DataSource, DataSet).Clear()
         End If

         Me.CargarGrillaDetalle()

         If ugeResumen.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugeResumen.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         ' Filtros = "Filtros: Estado: " & Me.cmbEstados.Text

         If Me.chbFecha.Checked Then
            Filtros = Filtros & " / Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text
         End If

         If Me.chbProveedor.Checked Then
            Filtros = Filtros & " / Proveedor: " & Me.bscCodigoProveedor.Text.Trim() & " - " & Me.bscProveedor.Text.Trim()
         End If

         If Me.cmbUsuario.Enabled Then
            Filtros = Filtros & " / Usuario: " & Me.cmbUsuario.SelectedValue.ToString()
         End If

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

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

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(Me.ugeResumen, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.ugeResumen, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick, bscCodigoProveedor.BuscadorClick
      ' Dim codigoProveedor As Long = -1
      Dim codigoProveedor As String = String.Empty

      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim rProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            ' codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
            codigoProveedor = Me.bscCodigoProveedor.Text.Trim()
         End If
         Me.bscCodigoProveedor.Datos = rProveedores.GetFiltradoPorCodigoLetras(codigoProveedor, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim rProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         Me.bscProveedor.Datos = rProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

      Me.bscCodigoProveedor.Focus()

   End Sub


   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged

      Me.chkMesCompleto.Enabled = Me.chbFecha.Checked
      Me.dtpDesde.Enabled = Me.chbFecha.Checked
      Me.dtpHasta.Enabled = Me.chbFecha.Checked

      If Not Me.chbFecha.Checked Then
         Me.chkMesCompleto.Checked = False
         Me.dtpDesde.Value = DateTime.Today
         Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Else
         Me.dtpDesde.Focus()
      End If

   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click

      Me.chkMesCompleto.Checked = False
      Me.chbProveedor.Checked = False
      Me.chbUsuario.Checked = False
      Me.chbIdPedido.Checked = False
      Me.chbFechaEntrega.Checked = False
      Me.chbFechaReprogEntrega.Checked = False

      Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.AddDays(1).AddSeconds(-1)

      If Me.ugeResumen.DataSource IsNot Nothing AndAlso TypeOf (ugeResumen.DataSource) Is DataSet Then
         DirectCast(Me.ugeResumen.DataSource, DataSet).Clear()
      End If

      Me.chbOcultarFiltros.Checked = True

   End Sub

   Private Sub chbIdPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbIdPedido.CheckedChanged
      Me.txtIdPedido.Enabled = Me.chbIdPedido.Checked

      If Not Me.chbIdPedido.Checked Then
         Me.txtIdPedido.Text = String.Empty
      Else
         Me.txtIdPedido.Focus()
      End If

   End Sub

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      Try
         Me.cmbUsuario.Enabled = Me.chbUsuario.Checked

         If Not Me.chbUsuario.Checked Then
            Me.cmbUsuario.SelectedIndex = -1
         Else
            If Me.cmbUsuario.Items.Count > 0 Then
               Me.cmbUsuario.SelectedIndex = 0
            End If
         End If

         Me.cmbUsuario.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      Dim FechaTemp As Date

      Try

         'Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         'Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp
         Else
            Me.dtpDesde.Value = DateTime.Today
            Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         End If



      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntrega.CheckedChanged

      Me.chkMesCompletoFEN.Enabled = Me.chbFechaEntrega.Checked
      Me.dtpFechaEntregaDesde.Enabled = Me.chbFechaEntrega.Checked
      Me.dtpFechaEntregaHasta.Enabled = Me.chbFechaEntrega.Checked

      If Not Me.chbFechaEntrega.Checked Then
         Me.chkMesCompletoFEN.Checked = False
         Me.dtpFechaEntregaDesde.Value = DateTime.Today
         Me.dtpFechaEntregaHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Else
         Me.dtpFechaEntregaDesde.Focus()
      End If

   End Sub

   Private Sub chbFechaReprogEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaReprogEntrega.CheckedChanged

      Me.chkMesCompletoFRE.Enabled = Me.chbFechaReprogEntrega.Checked
      Me.dtpFechaRepEntregaDesde.Enabled = Me.chbFechaReprogEntrega.Checked
      Me.dtpFechaRepEntregaHasta.Enabled = Me.chbFechaReprogEntrega.Checked

      If Not Me.chbFechaReprogEntrega.Checked Then
         Me.chkMesCompletoFRE.Checked = False
         Me.dtpFechaRepEntregaDesde.Value = DateTime.Today
         Me.dtpFechaRepEntregaHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Else
         Me.dtpFechaRepEntregaDesde.Focus()
      End If

   End Sub

   Private Sub chkMesCompletoFEN_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompletoFEN.CheckedChanged

      Dim FechaTemp As Date

      Try
         If chkMesCompletoFEN.Checked Then

            FechaTemp = New Date(Me.dtpFechaEntregaDesde.Value.Year, Me.dtpFechaEntregaDesde.Value.Month, 1)
            Me.dtpFechaEntregaDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpFechaEntregaDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpFechaEntregaHasta.Value = FechaTemp

         End If

         Me.dtpFechaEntregaDesde.Enabled = Not Me.chkMesCompletoFEN.Checked
         Me.dtpFechaEntregaHasta.Enabled = Not Me.chkMesCompletoFEN.Checked

      Catch ex As Exception

         chkMesCompletoFEN.Checked = False
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chkMesCompletoFRE_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompletoFRE.CheckedChanged
      Dim FechaTemp As Date

      Try

         If chkMesCompletoFRE.Checked Then

            FechaTemp = New Date(Me.dtpFechaRepEntregaDesde.Value.Year, Me.dtpFechaRepEntregaDesde.Value.Month, 1)
            Me.dtpFechaRepEntregaDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpFechaRepEntregaDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpFechaRepEntregaHasta.Value = FechaTemp

         End If

         Me.dtpFechaRepEntregaDesde.Enabled = Not Me.chkMesCompletoFRE.Checked
         Me.dtpFechaRepEntregaHasta.Enabled = Not Me.chkMesCompletoFRE.Checked

      Catch ex As Exception

         chkMesCompletoFRE.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try
   End Sub


#End Region

#Region "Métodos"

   Private Sub CargarGrillaDetalle()

      Dim IdPedido As Integer = -1
      Dim idProducto As String = String.Empty
      Dim IdProveedor As Long = 0
      Dim idObservacion As Integer = 0
      Dim IdUsuario As String = String.Empty

      Dim FechaDesde As Date = Nothing
      Dim FechaHasta As Date = Nothing

      Dim FechaDesdeEntrega As Date = Nothing
      Dim FechaHastaEntrega As Date = Nothing

      Dim FechaDesdeRepEntrega As Date = Nothing
      Dim FechaHastaRepEntrega As Date = Nothing

      ' If Me.chbFecha.Checked Then
      FechaDesde = Me.dtpDesde.Value
      FechaHasta = Me.dtpHasta.Value
      '  End If

      If Me.chbFechaEntrega.Checked Then
         FechaDesdeEntrega = Me.dtpFechaEntregaDesde.Value
         FechaHastaEntrega = Me.dtpFechaEntregaHasta.Value
      End If

      If Me.chbFechaReprogEntrega.Checked Then
         FechaDesdeRepEntrega = Me.dtpFechaRepEntregaDesde.Value
         FechaHastaRepEntrega = Me.dtpFechaRepEntregaHasta.Value
      End If

      If Me.chbIdPedido.Checked Then
         IdPedido = Integer.Parse(Me.txtIdPedido.Text)
      End If

      If Me.chbProveedor.Checked Then
         IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
      End If

      If Me.cmbUsuario.Enabled Then
         IdUsuario = Me.cmbUsuario.SelectedValue.ToString()
      End If

      If Me.chbUsuario.Checked Then
         IdUsuario = Me.cmbUsuario.SelectedValue.ToString
      End If

      Dim TipoEnvio As String = "TODOS"


      Dim oEnviosOCError As Reglas.EnviosOCErrores = New Reglas.EnviosOCErrores
      Dim dtDetalle As DataTable
      dtDetalle = oEnviosOCError.GetInforme(IdPedido, FechaDesde, FechaHasta,
                                             FechaDesdeRepEntrega, FechaHastaRepEntrega,
                                             _tipoTipoComprobante, cmbTiposComprobantes.GetTiposComprobantes(),
                                             IdProveedor, IdUsuario, Me.cmbEstados.Text.ToString())

      ugeResumen.DataSource = dtDetalle


      Me.tssRegistros.Text = Me.ugeResumen.Rows.Count.ToString() & " Registros"

   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedorLetras").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub

   Private Sub chbOcultarFiltros_CheckedChanged(sender As Object, e As EventArgs) Handles chbOcultarFiltros.CheckedChanged
      Try
         Me.SplitContainer1.Panel1Collapsed = Not Me.chbOcultarFiltros.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugeResumen, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region



End Class