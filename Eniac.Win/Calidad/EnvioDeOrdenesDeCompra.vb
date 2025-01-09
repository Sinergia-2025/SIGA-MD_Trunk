Imports System.IO
Public Class EnvioDeOrdenesDeCompra
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   Dim dtsMaster_detalle As DataSet
   'Dim primeraCarga As Boolean = True
   Dim dtDetalle As DataTable
   Dim dtPedidoDetalle As DataTable
   Dim dtPedidoDetalleComprobante As DataTable
   Private _tipoTipoComprobante As String
   Private _estaCargando As Boolean = True

   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _tit1 As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _tit2 As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Private _puedeVerPrecios As Boolean

   Private IdUsuario As String = actual.Nombre
   Private _cabecera As DataTable = New DataTable()
#End Region

   Private Const imprimirCompColumnKey As String = "ImprimirComp"
   Private Const imprimirCabConCantidadColumnKey As String = "ImprimirCabConCantidad"
   Private Const imprimirCabColumnKey As String = "VerCabecera"
   Private Const detalleColumnKey As String = "Ver"

   Enum SiNoTodos As Integer
      TODOS = 0
      SI = 1
      NO = 2
      NO_ENVIAR = 3
   End Enum

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSPROV"

         _puedeVerPrecios = True

         cmbTiposComprobantes.Initializar(False, True, True, False, _tipoTipoComprobante)
         Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
         Me.cmbActivadas.SelectedIndex = 2


         Me._publicos = New Publicos()

         Me._publicos.CargaComboEstadosPedidosProvCalidad(cmbEstados, True, True, False, True, False, _tipoTipoComprobante)
         Me.cmbEstados.SelectedIndex = 1

         _publicos.CargaComboDesdeEnum(Me.cmbCorreoEnviado, GetType(SiNoTodos))
         Me.cmbCorreoEnviado.SelectedValue = SiNoTodos.NO

         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnumSI))

         '   chbFecha.Checked = True
         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.AddDays(1).AddSeconds(-1)

         Me.dtpFechaAutorizacionDesde.Value = Date.Today
         Me.dtpFechaAutorizacionHasta.Value = Date.Today.AddDays(1).AddSeconds(-1)

         Me.dtpFechaEntregaDesde.Value = Date.Today
         Me.dtpFechaEntregaHasta.Value = Date.Today.AddDays(1).AddSeconds(-1)

         Me.dtpFechaEnvioDesde.Value = Date.Today
         Me.dtpFechaEnviohasta.Value = Date.Today.AddDays(1).AddSeconds(-1)

         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

         'Si el Usuario no tiene Compradores asociados limpio la variable para que no filtre en el cargar combo.
         If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
            IdUsuario = ""
         End If

         If Not _puedeVerPrecios Then
            ugDetalle.DisplayLayout.Bands("Cabecera").Columns("ImporteTotal").Hidden = True

         End If

         _tit = GetColumnasVisiblesGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"))

         Me.ugDetalle.AgregarFiltroEnLinea({"Act"})

         Me.txtCopiaOculta.Text = Eniac.Reglas.Publicos.CalidadCopiaOcultaEnvioOC.ToString()

         '    rtbCuerpoMail.BodyHtml = rtbCuerpoMail.LoadFromUrl("C:\Eniac\Correos\MailOC.html")

         txtCopiaOculta.Text = Reglas.Publicos.CalidadCopiaOcultaEnvioOC

         Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"ImporteTotal", "TotalImpuestos", "ImporteBruto"})

         If My.Computer.FileSystem.FileExists("C:\Eniac\SiGA\Programas\Reportes\MailOC.html") Then

            Dim reader As StreamReader = File.OpenText("C:\Eniac\SiGA\Programas\Reportes\MailOC.html")

            Dim HTMLCuerpoMail As String = reader.ReadToEnd()

            rtbCuerpoMail.BodyHtml = HTMLCuerpoMail
         Else
            MessageBox.Show("No existe el cuerpo del Mail", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.btnEnviar.Enabled = False
         End If

         Me._estaCargando = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
#End Region

#Region "Eventos"

   Private Sub ConsultarPedidos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try
         If Me.chbProveedor.Checked And Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         If Me.chbIdPedido.Checked AndAlso Integer.Parse("0" & Me.txtNroDesde.Text) = 0 Then
            MessageBox.Show("ATENCION: NO Ingresó un Número de OC aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNroDesde.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.tsbEnviarFacturas.Enabled = True
         Me.lblCantidadDeErrores.Visible = False
         Me.btnEnviar.Enabled = True

         Me.Cursor = Cursors.WaitCursor

         If Me.ugDetalle.DataSource IsNot Nothing AndAlso TypeOf (ugDetalle.DataSource) Is DataSet Then
            DirectCast(Me.ugDetalle.DataSource, DataSet).Clear()
         End If

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tslTexto.Text = "0 Registros"
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tslTexto.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Filtros: Estado: " & Me.cmbEstados.Text

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

         Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

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
               Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
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
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chbFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFecha.CheckedChanged

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

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

      Me.bscCodigoProveedor.Focus()

   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick, bscCodigoProveedor.BuscadorClick
      'Dim codigoProveedor As Long = -1
      Dim codigoProveedor As String = String.Empty

      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim rProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            'codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
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

   Private Sub chbUsuario_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbUsuario.CheckedChanged
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

   Private Sub chbIdPedido_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbIdPedido.CheckedChanged

      Me.txtNroDesde.Enabled = Me.chbIdPedido.Checked
      Me.txtNroHasta.Enabled = Me.chbIdPedido.Checked

      If Not Me.chbIdPedido.Checked Then
         Me.txtNroDesde.Text = String.Empty
         Me.txtNroHasta.Text = String.Empty
      Else
         Me.txtNroDesde.Focus()
      End If

   End Sub

#End Region

#Region "Eventos Grilla"
   Private Sub ugDetalle_ClickCellButton(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      Try
         Me.Cursor = Cursors.WaitCursor
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         'Imprimer el comprobante Fact o Remito según corresponda.
         Dim letra As String = String.Empty
         Dim IdTipoComprobante As String = String.Empty
         Dim CentroEmisor As Short = 0
         Dim NumeroComprobante As Long = 0
         Dim idProducto As String = String.Empty
         Dim orden As Integer = 0
         IdTipoComprobante = e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).Value.ToString
         letra = e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.Letra.ToString()).Value.ToString
         CentroEmisor = Short.Parse(e.Cell.Row.Cells(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).Value.ToString)
         NumeroComprobante = Long.Parse(e.Cell.Row.Cells("NumeroPedido").Value.ToString)

         If e.Cell.Column.Key = imprimirCabColumnKey Or e.Cell.Column.Key = detalleColumnKey Then

            Dim oPedido As Entidades.PedidoProveedor = New Reglas.PedidosProveedores().GetUno(actual.Sucursal.Id, IdTipoComprobante, letra, CentroEmisor, NumeroComprobante)
            Dim impresion As ImpresionPedidosProv = New ImpresionPedidosProv()

            If e.Cell.Column.Header.Caption = "" Then
               'Reporte = "Eniac.Win.PedidoV2.rdlc"
               impresion.ImprimirPedido(oPedido, True, False)
            Else
               'Reporte = "Eniac.Win.PedidoV2Detalle.rdlc"
               ' impresion.ImprimirPedidoDetallado(oPedido, True)
            End If
         ElseIf e.Cell.Column.Key = "Envios" Then

            Dim fr As ConsultaGenerica = New ConsultaGenerica(New Reglas.EnviosOC().GetEnviosXOC(actual.Sucursal.Id, IdTipoComprobante,
                                                               letra, CentroEmisor, NumeroComprobante))

            fr.Width = 600
            fr.Text = "Envíos OC"
            fr.MdiParent = Me.MdiParent
            fr.Show()
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = True
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("IdTipoComprobante").Hidden = True
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("Letra").Hidden = True
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("CentroEmisor").Hidden = True
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("NumeroPedido").Hidden = True
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("FechaEnvio").Header.Caption = "Fecha Envío"
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("FechaEnvio").Format = "dd/MM/yyyy HH:mm"
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("FechaEnvio").Width = 150
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("IdUsuario").Header.Caption = "Usuario"
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("IdFuncion").Header.Caption = "Función"
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("MetodoGrabacion").Header.Caption = "Método"
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("MetodoGrabacion").Width = 50
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("FechaReprogramacion").Header.Caption = "Fecha Reprogramación"
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("FechaReprogramacion").Format = "dd/MM/yyyy HH:mm"
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("FechaReprogramacion").CellAppearance.ImageHAlign = HAlign.Center
            fr.ugDetalle.DisplayLayout.Bands(0).Columns("FechaReprogramacion").Width = 130

         ElseIf e.Cell.Column.Key = "NoEnv" Then

            If Not IsDate(e.Cell.Row.Cells(Entidades.EnvioOC.Columnas.FechaEnvio.ToString()).Value.ToString) Then

               Dim EnvioOC As Entidades.EnvioOC
               Dim rEnvioOC As Reglas.EnviosOC = New Reglas.EnviosOC()

               EnvioOC = New Entidades.EnvioOC
               With EnvioOC
                  .IdSucursal = actual.Sucursal.Id
                  .TipoComprobante = New Reglas.TiposComprobantes().GetUno(IdTipoComprobante)
                  .Letra = letra
                  .CentroEmisor = CentroEmisor
                  .NumeroPedido = NumeroComprobante
                  .FechaEnvio = Date.Now
                  .IdUsuario = actual.Nombre

               End With
               rEnvioOC.Insertar(EnvioOC, "N", IdFuncion)

            End If

            Me.btnConsultar.PerformClick()
         End If
      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub ugDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow
      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)
      e.Layout.Override.SpecialRowSeparatorHeight = 6
      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft
      e.Layout.ViewStyle = ViewStyle.MultiBand

      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
      '  e.Layout.Override.FixedRowStyle = FixedRowStyle.Top

      For Each banda As UltraGridBand In e.Layout.Bands
         If banda.Key <> "Detalle" Then
            banda.HeaderVisible = True
            banda.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left
            banda.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Else
            banda.HeaderVisible = False
         End If
      Next

      ' Me.ugDetalle.DisplayLayout.Bands(0).Columns("Dif").Hidden = Not Me.chbDiferenciasFechas.Checked

      ' ugDetalle.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False

   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs)
      Try
         If e.Row IsNot Nothing AndAlso
            e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Row.ListObject, DataRowView).Row IsNot Nothing Then
            Dim row As DataRow = DirectCast(e.Row.ListObject, DataRowView).Row

            If row.Table.Columns.Contains("Color") AndAlso IsNumeric(e.Row.Cells("Color").Value) Then
               e.Row.Cells("IdEstado").Appearance.BackColor = Color.FromArgb(Integer.Parse(e.Row.Cells("Color").Value.ToString()))
               e.Row.Cells("IdEstado").Appearance.AlphaLevel = 128
               e.Row.Cells("IdEstado").Appearance.ForegroundAlpha = Alpha.Opaque

               e.Row.Cells("IdEstado").ActiveAppearance.BackColor = Color.FromArgb(Integer.Parse(e.Row.Cells("Color").Value.ToString()))
               e.Row.Cells("IdEstado").ActiveAppearance.BackColorAlpha = Alpha.Opaque
               e.Row.Cells("IdEstado").ActiveAppearance.ForegroundAlpha = Alpha.Opaque
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub
#End Region

#End Region

#Region "Metodos"

   'Private Sub CargarColumnasASumar()
   '   Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"CantEstado", "cantPendiente"})
   'End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedorLetras").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.cmbEstados.SelectedIndex = 1
      Me.cmbActivadas.SelectedIndex = 2

      Me.chbFecha.Checked = False
      Me.chbFechaEnvio.Checked = False
      Me.chbProveedor.Checked = False
      Me.chbUsuario.Checked = False

      Me.chbIdPedido.Checked = False

      Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      Me.cmbCorreoEnviado.SelectedValue = SiNoTodos.NO

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      Me.chbFechaEntrega.Checked = False
      Me.chbFechaAutorizacion.Checked = False
      Me.chbRangoImporte.Checked = False

      Me.btnEnviar.Enabled = True
      Me.lblCantidadDeErrores.Visible = False
      Me.chbReprogramadas.Checked = False
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.cmbEstados.Focus()
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oPedidos As Reglas.PedidosProveedores = New Reglas.PedidosProveedores()

      Dim FechaDesde As Date = Nothing
      Dim FechaHasta As Date = Nothing

      Dim FechaDesdeEntrega As Date = Nothing
      Dim FechaHastaEntrega As Date = Nothing

      Dim FechaDesdeAutorizacion As Date = Nothing
      Dim FechaHastaAutorizacion As Date = Nothing

      Dim FechaDesdeEnvio As Date = Nothing
      Dim FechaHastaEnvio As Date = Nothing

      Dim importeMinimo As Decimal = 0
      Dim importeMaximo As Decimal = 0

      Dim NroDesde As Long = 0
      Dim NroHasta As Long = 0

      Dim idProducto As String = String.Empty
      Dim IdMarca As Integer = 0
      Dim IdRubro As Integer = 0
      Dim idSubRubro As Integer = 0
      Dim lote As String = String.Empty

      Dim IdPedido As Integer = -1
      Dim OrdenCompra As Long = 0
      Dim Tamanio As Decimal = 0

      Dim IdProveedor As Long = 0

      Dim TipoComprobante As String = String.Empty

      Dim IdComprador As Integer = 0

      Dim IdFormaDePago As Integer = 0
      Dim IdUsuario As String = String.Empty
      Dim Cantidad As String = String.Empty

      Dim idPed_str As String = String.Empty

      If Me.chbFecha.Checked Then
         FechaDesde = Me.dtpDesde.Value
         FechaHasta = Me.dtpHasta.Value
      End If

      If Me.chbFechaEntrega.Checked Then
         FechaDesdeEntrega = Me.dtpFechaEntregaDesde.Value
         FechaHastaEntrega = Me.dtpFechaEntregaHasta.Value
      End If

      If Me.chbFechaAutorizacion.Checked Then
         FechaDesdeAutorizacion = Me.dtpFechaAutorizacionDesde.Value
         FechaHastaAutorizacion = Me.dtpFechaAutorizacionHasta.Value
      End If

      If Me.cmbCorreoEnviado.SelectedIndex = 1 And Me.chbFechaEnvio.Checked Then
         FechaDesdeEnvio = Me.dtpFechaEnvioDesde.Value
         FechaHastaEnvio = Me.dtpFechaEnviohasta.Value
      End If

      If Me.chbProveedor.Checked Then
         IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
      End If

      If Me.cmbUsuario.Enabled Then
         IdUsuario = Me.cmbUsuario.SelectedValue.ToString()
      End If

      If Me.chbIdPedido.Checked Then
         IdPedido = Integer.Parse(Me.txtNroDesde.Text)
      End If

      If chbRangoImporte.Checked Then
         importeMinimo = Decimal.Parse(Me.txtMinRango.Text.ToString())
         importeMaximo = Decimal.Parse(Me.txtMaxRango.Text.ToString())
      End If

      If chbIdPedido.Checked Then
         NroDesde = Long.Parse(Me.txtNroDesde.Text.ToString())
         NroHasta = Long.Parse(Me.txtNroHasta.Text.ToString())
      End If

      dtsMaster_detalle = New DataSet()

      dtDetalle = oPedidos.OCCabecera(actual.Sucursal.Id,
                                           Me.cmbEstados.Text,
                                           FechaDesde, FechaHasta,
                                           IdPedido,
                                           NroHasta,
                                           idProducto,
                                           IdMarca,
                                           IdRubro,
                                           lote,
                                           IdProveedor,
                                           IdUsuario,
                                           Tamanio,
                                           IdComprador,
                                           OrdenCompra,
                                           _tipoTipoComprobante,
                                           cmbTiposComprobantes.GetTiposComprobantes(),
                                           String.Empty, 0,
                                           FechaDesdeEntrega,
                                           FechaHastaEntrega,
                                           importeMinimo,
                                           importeMaximo,
                                           FechaDesdeAutorizacion,
                                           FechaHastaAutorizacion,
                                           Me.cmbCorreoEnviado.Text.ToString(),
                                           FechaDesdeEnvio, FechaHastaEnvio,
                                           Me.chbReprogramadas.Checked)

      If dtDetalle.Rows.Count = 0 Then
         If TypeOf (ugDetalle.DataSource) Is DataSet Then DirectCast(ugDetalle.DataSource, DataSet).Clear()
         If TypeOf (ugDetalle.DataSource) Is DataTable Then DirectCast(ugDetalle.DataSource, DataTable).Clear()
         Exit Sub
      End If

      _cabecera = dtDetalle

      dtDetalle.TableName = "Cabecera"


      Me.ugDetalle.DataSource = dtDetalle

      AjustarColumnasGrilla()

      For Each dr As UltraGridRow In Me.ugDetalle.Rows
         If IsDate(dr.Cells("FechaEnvio").Value.ToString()) Then
            dr.Cells("NoEnv").Activation = Activation.Disabled
         End If
         If cmbCorreoEnviado.Text = "SI" Then
            If IsDate(dr.Cells("FechaReprogEnvio").Value.ToString()) Then
               If Date.Parse(dr.Cells("FechaReprogEnvio").Value.ToString()).ToShortDateString <> Date.Parse(dr.Cells("FechaEntrega").Value.ToString()).ToShortDateString Then
                  dr.Cells("Envio").Appearance.BackColor = Color.Red
                  dr.Cells("Envio").Activation = Activation.Disabled
                  dr.Cells("Observacion").Value = "No se puede reimprimir, enviar por opción NO Enviadas."
               End If
            End If
         End If
         If dr.Cells("CorreoElectronico").Value.ToString().Trim = "" Then
            dr.Cells("Envio").Appearance.BackColor = Color.Red
            dr.Cells("Envio").Activation = Activation.Disabled
            dr.Cells("Observacion").Value = "No se puede seleccionar porque no tiene correo electrónico"
         End If
      Next

      Me.tslTexto.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      ' Me.ugDetalle.DisplayLayout.Bands(0).ColumnFilters("Acti").FilterConditions.Clear()

      'If Me.cmbActivadas.SelectedIndex <> 2 Then
      '   If Me.cmbActivadas.SelectedIndex = 0 Then
      '      Me.ugDetalle.DisplayLayout.Bands(0).ColumnFilters("Acti").FilterConditions.Add(FilterComparisionOperator.Equals, True)
      '   Else
      '      Me.ugDetalle.DisplayLayout.Bands(0).ColumnFilters("Acti").FilterConditions.Add(FilterComparisionOperator.Equals, False)
      '   End If
      'End If

   End Sub

   Private Overloads Sub AjustarColumnasGrilla()
      AjustarColumnasGrilla(ugDetalle.DisplayLayout.Bands("Cabecera"), _tit)
   End Sub

   Private Sub Activadas()
      Try
         Dim producto As String = String.Empty
         Dim Orden As Integer = 0
         ' For Each band As UltraGridBand In Me.ugDetalle.DisplayLayout.Bands
         ' Dim ActOC As List(Of Entidades.ActivacionOC) = New List(Of Entidades.ActivacionOC)
         Dim ActiOC As DataTable = New DataTable()
         Dim oActiOC As Reglas.ActivacionesOC = New Reglas.ActivacionesOC()

         For Each dr As UltraGridRow In Me.ugDetalle.Rows


            ActiOC = oActiOC.GetAll(Integer.Parse(dr.Cells("IdSucursal").Value.ToString()),
                                                            dr.Cells("IdTipoComprobante").Value.ToString(),
                                                            dr.Cells("letra").Value.ToString(),
                                                            Integer.Parse(dr.Cells("CentroEmisor").Value.ToString()),
                                                            Long.Parse(dr.Cells("NumeroPedido").Value.ToString()),
                                                            producto)

            If ActiOC.Count <> 0 Then
               ' dr.Cells("Act").Value = True
               If ActiOC.Rows(0).Item("Criticidad").ToString() = "Normal" Then
                  dr.Cells("Acti").Appearance.BackColor = Color.Green
               ElseIf ActiOC.Rows(0).Item("Criticidad").ToString() = "Crítica" Then
                  dr.Cells("Acti").Appearance.BackColor = Color.Red
                  'Else
                  '   dr.Cells("Act").Appearance.BackColor = Color.White
               End If
            Else
               '   dr.Cells("Act").Value = False
               ' dr.Cells("Act").Appearance.BackColor = Color.White
            End If

            If Date.Parse(dr.Cells("FechaEntrega").Value.ToString()) = Date.Today Then
               dr.Cells("FechaEntrega").Appearance.BackColor = Color.Khaki
            ElseIf Date.Parse(dr.Cells("FechaEntrega").Value.ToString()) < Date.Now Then
               dr.Cells("FechaEntrega").Appearance.BackColor = Color.LightCoral
            Else
               dr.Cells("FechaEntrega").Appearance.BackColor = Color.LightGreen
            End If

            If IsDate(dr.Cells("FechaReprogEntrega").Value.ToString()) Then
               If Date.Parse(dr.Cells("FechaReprogEntrega").Value.ToString()).ToShortDateString() = Date.Today.ToShortDateString() Then
                  dr.Cells("FechaReprogEntrega").Appearance.BackColor = Color.Khaki
               ElseIf Date.Parse(dr.Cells("FechaReprogEntrega").Value.ToString()) < Date.Today Then
                  dr.Cells("FechaReprogEntrega").Appearance.BackColor = Color.LightCoral
               Else
                  dr.Cells("FechaReprogEntrega").Appearance.BackColor = Color.LightGreen
               End If
            End If

            Dim Dif As Long = 0

            If IsDate(dr.Cells("FechaEntrega").Value) And IsDate(dr.Cells("FechaReprogEntrega").Value) Then
               Dif = DateDiff(DateInterval.Day, Date.Parse(dr.Cells("FechaEntrega").Value.ToString()), Date.Parse(dr.Cells("FechaReprogEntrega").Value.ToString()))
               dr.Cells("Dif").Value = Dif
            End If

            If IsDate(dr.Cells("FechaEntrega").Value) And IsDate(dr.Cells("FechaPedido").Value) Then
               Dif = DateDiff(DateInterval.Day, Date.Parse(dr.Cells("FechaPedido").Value.ToString()), Date.Parse(dr.Cells("FechaEntrega").Value.ToString()))
               dr.Cells("Dif1").Value = Dif
            End If

            If IsDate(dr.Cells("FechaEntrega").Value) Then
               Dif = DateDiff(DateInterval.Day, Date.Parse(dr.Cells("FechaEntrega").Value.ToString()), Date.Today)
               If Dif > 0 Then
                  dr.Cells("Dif2").Value = Dif
               End If

            End If

         Next
         'Next
         ' Dim band As UltraGridBand = Me.ugDetalle.DisplayLayout.Bands(1)
         'Dim row As UltraGridRow
         'For Each row In band.GetRowEnumerator(GridRowType.DataRow)

         '   ActiOC = oActiOC.GetAll(Integer.Parse(row.Cells("IdSucursal").Value.ToString()),
         '                                                 row.Cells("IdTipoComprobante").Value.ToString(),
         '                                                 row.Cells("letra").Value.ToString(),
         '                                                 Integer.Parse(row.Cells("CentroEmisor").Value.ToString()),
         '                                                 Long.Parse(row.Cells("NumeroPedido").Value.ToString()),
         '                                                 row.Cells("IdProducto").Value.ToString())

         '   If ActiOC.Count <> 0 Then
         '      row.Cells("Act").Value = True
         '      'row.Cells("Act").Appearance.BackColor = Color.Green
         '   Else
         '      row.Cells("Act").Value = False
         '   End If

         'Next row

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _tipoTipoComprobante = parametros
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Definir el tipo de Tipo de Comprobante para usar en la pantalla.")
      stb.AppendFormatLine("Por defecto: PEDIDOSPROV")
      stb.AppendFormatLine("El valor se carga directamente.")
      Return stb.ToString()
   End Function

   Private Sub chbFechaEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntrega.CheckedChanged
      Try
         Me.dtpFechaEntregaDesde.Enabled = Me.chbFechaEntrega.Checked
         Me.dtpFechaEntregaHasta.Enabled = Me.chbFechaEntrega.Checked

         If Not Me.chbFechaEntrega.Checked Then
            Me.dtpFechaEntregaDesde.Value = DateTime.Today
            Me.dtpFechaEntregaHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         Else
            Me.dtpFechaEntregaDesde.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   'Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) 
   '   Try
   '      Dim OC As DataTable = New Reglas.PedidosProveedores()._GetUno(actual.Sucursal.IdSucursal, Me.ugDetalle.ActiveRow.Cells("IdtipoComprobante").Value.ToString(),
   '                                                                    Me.ugDetalle.ActiveRow.Cells("Letra").Value.ToString(),
   '                                                                    Integer.Parse(Me.ugDetalle.ActiveRow.Cells("CentroEmisor").Value.ToString()),
   '                                                                    Long.Parse(Me.ugDetalle.ActiveRow.Cells("NumeroPedido").Value.ToString()))

   '      Me.txtTipo.Text = OC.Rows(0).Item("IdTipoComprobante").ToString()
   '      Me.txtOC.Text = OC.Rows(0).Item("NumeroPedido").ToString()
   '      Dim Prov As Entidades.Proveedor = New Reglas.Proveedores().GetUno(Long.Parse(OC.Rows(0).Item("Idproveedor").ToString()))
   '      Me.txtCodProv.Text = Prov.CodigoProveedorLetras.ToString()
   '      Me.txtProveedor.Text = Prov.NombreProveedor
   '      Me.txtFechaE.Text = Date.Parse(OC.Rows(0).Item("FechaPedido").ToString()).ToString("dd/MM/yyyy")
   '      Me.txtFechaEnt.Text = Date.Parse(Me.ugDetalle.ActiveRow.Cells("FechaEntrega").Value.ToString()).ToString("dd/MM/yyyy")
   '      Me.txtTotal.Text = Decimal.Parse(OC.Rows(0).Item("ImporteTotal").ToString()).ToString("C2")
   '      If Me.ugDetalle.ActiveRow.Band.Index = 0 Then
   '         Me.txtPorcImpPendiente.Text = Decimal.Parse(Me.ugDetalle.ActiveRow.Cells("PorcPendienteImporte").Value.ToString()).ToString()
   '      End If

   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try
   'End Sub

   Private Sub chbRangoImporte_CheckedChanged(sender As Object, e As EventArgs) Handles chbRangoImporte.CheckedChanged
      Try
         Me.txtMinRango.Enabled = Me.chbRangoImporte.Checked
         Me.txtMaxRango.Enabled = Me.chbRangoImporte.Checked
         If Not Me.chbRangoImporte.Checked Then
            Me.txtMinRango.Text = String.Empty
            Me.txtMaxRango.Text = String.Empty
         Else
            Me.txtMaxRango.Focus()
            Me.txtMinRango.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

   Private Sub ugDetalle_AfterRowExpanded(sender As Object, e As RowEventArgs)
      Try
         Me.ugDetalle.Selected.Rows.Clear()
         Me.ugDetalle.ActiveRow = e.Row
         Me.ugDetalle.Selected.Rows.Add(e.Row)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbOcultarFiltros_CheckedChanged(sender As Object, e As EventArgs) Handles chbOcultarFiltros.CheckedChanged
      Try
         Me.SplitContainer1.Panel1Collapsed = Not Me.chbOcultarFiltros.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_AfterRowCollapsed(sender As Object, e As RowEventArgs)
      Me.ugDetalle.Selected.Rows.Clear()
      Me.ugDetalle.ActiveRow = e.Row
      Me.ugDetalle.Selected.Rows.Add(e.Row)
   End Sub

   Private Sub chbFechaAutorizacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaAutorizacion.CheckedChanged
      Try
         Me.dtpFechaAutorizacionDesde.Enabled = Me.chbFechaAutorizacion.Checked
         Me.dtpFechaAutorizacionHasta.Enabled = Me.chbFechaAutorizacion.Checked

         If Not Me.chbFechaAutorizacion.Checked Then
            Me.dtpFechaAutorizacionDesde.Value = DateTime.Today
            Me.dtpFechaAutorizacionHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         Else
            Me.dtpFechaAutorizacionDesde.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub UltraGridExcelExporter1_ExportStarted(sender As Object, e As ExcelExport.ExportStartedEventArgs) Handles UltraGridExcelExporter1.ExportStarted
      e.Layout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand
   End Sub

   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnumSI Then

            Me.Cursor = Cursors.WaitCursor

            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnumSI)
               Case Reglas.Publicos.TodosEnumSI.MarcarTodos
                  MarcarDesmarcar(True, ugDetalle.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.DesmarcarTodos

               Case Reglas.Publicos.TodosEnumSI.DesmarcarTodos
                  MarcarDesmarcar(False, ugDetalle.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos

               'Case Reglas.Publicos.TodosEnum.MarcarFiltrados
               '   MarcarDesmarcar(True, ugDetalle.Rows.GetFilteredInNonGroupByRows())
               '   cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarFiltrados

               'Case Reglas.Publicos.TodosEnum.DesmarcarFiltrados
               '   MarcarDesmarcar(False, ugDetalle.Rows.GetFilteredInNonGroupByRows())
               '   cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MarcarFiltrados

               Case Reglas.Publicos.TodosEnumSI.InvertirMarcasTodos
                  MarcarDesmarcar(Nothing, ugDetalle.Rows.GetFilteredInNonGroupByRows())

                  'Case Reglas.Publicos.TodosEnum.InvertirMarcasFiltrados
                  '   MarcarDesmarcar(Nothing, ugDetalle.Rows.GetFilteredInNonGroupByRows())

               Case Else

            End Select
         End If
         Me.tslTexto.Text = Me.ugDetalle.Rows.FilteredInRowCount.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         ugDetalle.UpdateData()
      End Try
   End Sub

   Private Sub MarcarDesmarcar(marcar As Boolean?, rows As UltraGridRow())
      For Each dr As UltraGridRow In rows
         If Not String.IsNullOrEmpty(dr.Cells("CorreoElectronico").Text.Trim().ToString()) AndAlso Not dr.Cells("Envio").Activation = Activation.Disabled Then
            If marcar.HasValue Then
               dr.Cells("Envio").Value = marcar.Value
            Else
               dr.Cells("Envio").Value = Not CBool(dr.Cells("Envio").Value)
            End If
         End If
      Next
   End Sub

   Private Sub tsbEnviarFacturas_Click(sender As Object, e As EventArgs) Handles tsbEnviarFacturas.Click
      Try
         If (ValidarCorreo()) Then
            Me.Cursor = Cursors.WaitCursor
            Me.tsbEnviarFacturas.Enabled = False
            EnviaMails()
         Else
            ShowMessage("Los Datos del Correo Electronico estan incompletos " + Environment.NewLine + " (Configuraciones -> Parametros del Sistema)")
         End If

      Catch ex As Exception
         ShowError(ex, True)
      Finally
         Me.Cursor = Cursors.Default
         tsbEnviarFacturas.Enabled = True
      End Try
   End Sub

   Private Function ValidarCorreo() As Boolean

      Dim validaDatos As Boolean = True

      If (Reglas.Publicos.MailServidor = "" Or
          Reglas.Publicos.MailDireccion = "" Or
          Reglas.Publicos.MailUsuario = "" Or
          Reglas.Publicos.MailPassword = "" Or
          Reglas.Publicos.MailPuertoSalida = 0) Then
         validaDatos = False

      End If

      Return validaDatos

   End Function

   Private Sub EnviaMails()

      'If String.IsNullOrEmpty(txtAsuntoMail.Text) Then
      '   Me.txtAsuntoMail.Focus()
      '   Throw New Exception("ATENCION: Debe ingresar el Asunto del Correo.")
      'End If

      'If String.IsNullOrEmpty(rtbCuerpoMail.BodyHtml) Then
      '   Me.rtbCuerpoMail.Focus()
      '   Throw New Exception("ATENCION: Debe ingresar el Cuerpo del Correo.")
      'End If

      Dim copiaOculta As String = String.Empty
      If txtCopiaOculta.Text <> String.Empty Then copiaOculta = txtCopiaOculta.Text

      '# Muestro al usuario la columna de Estado
      '   Me.ugDetalle.DisplayLayout.Bands(0).Columns("Estado").Hidden = False

      Me.ugDetalle.UpdateData()

      Dim adjuntos As String() = {Me.txtArchivo1.Text, Me.txtArchivo2.Text, Me.txtArchivo3.Text, Me.txtArchivo4.Text}

      Dim wEnvioMasivo As OCEnvioMasivoMails = New OCEnvioMasivoMails()
      'wEnvioMasivo.EnviarMails(String.Empty, txtMailCuerpo.Text, copiaOculta,
      '                                 dtDetalle, adjuntos, tspBarra, tslTexto, Me.IdFuncion)
      Dim Sel As Boolean = False
      For Each dr As DataRow In dtDetalle.Rows
         If Boolean.Parse(dr("Envio").ToString()) Then
            Sel = True
            Exit For
         End If
      Next

      If Sel Then
         wEnvioMasivo.EnviarMails(String.Empty, rtbCuerpoMail.BodyHtml, copiaOculta,
                                               dtDetalle, adjuntos, tspBarra, tslTexto, Me.IdFuncion, lblCantidadDeErrores)

         ShowMessage("Envío finalizado. - " & Me.lblCantidadDeErrores.Text.ToString())

         Me.tspBarra.Value = 0

         Me.btnConsultar.PerformClick()
      Else
         MessageBox.Show("No seleccionó ninguna Orden de Compra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.Cursor = Cursors.Default
         Me.btnEnviar.Enabled = True
      End If

   End Sub

   Private Sub tsbCorreoPrueba_Click(sender As Object, e As EventArgs) Handles tsbCorreoPrueba.Click
      Try
         If ValidarCorreo() Then
            Me.EnviaMailPrueba()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub EnviaMailPrueba()
      'If String.IsNullOrEmpty(txtAsuntoMail.Text) Then
      '   Me.txtAsuntoMail.Focus()
      '   Throw New Exception("ATENCION: Debe ingresar el Asunto del Correo.")
      'End If
      'If String.IsNullOrEmpty(rtbCuerpoMail.BodyHtml) Then
      '   Me.rtbCuerpoMail.Focus()
      '   Throw New Exception("ATENCION: Debe ingresar el Cuerpo del Correo.")
      'End If

      'Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()
      'If dr IsNot Nothing Then

      '   Dim mailPrueba As String = String.Empty
      '   If chbCopiaOculta.Checked And Not String.IsNullOrWhiteSpace(txtCopiaOculta.Text) Then
      '      mailPrueba = txtCopiaOculta.Text
      '   Else
      '      mailPrueba = Reglas.Publicos.ProcesosCorreoPruebaPara
      '   End If

      '   Me.ugDetalle.UpdateData()

      '   'Dim _dtEnvioMail As DataTable = DirectCast(Me.ugDetalle.DataSource, DataTable).Clone
      '   '_dtEnvioMail.ImportRow(dr)
      '   '_dtEnvioMail.AcceptChanges()

      '   Dim reporteCtaCte As Entidades.Publicos.InformesCtaCte? = Nothing
      '   If cmbReportesCtaCte.SelectedIndex > -1 Then
      '      reporteCtaCte = DirectCast(cmbReportesCtaCte.SelectedValue, Entidades.Publicos.InformesCtaCte)
      '   End If

      '   Dim adjuntos As String() = {Me.txtArchivo1.Text, Me.txtArchivo2.Text, Me.txtArchivo3.Text, Me.txtArchivo4.Text}
      '   Dim wEnvioMasivo As VentasEnvioMasivoMails = New VentasEnvioMasivoMails()
      '   wEnvioMasivo.EnviarMailPrueba(txtAsuntoMail.Text, rtbCuerpoMail.BodyHtml, mailPrueba, _dtEnvioMail, adjuntos, tspBarra, tslTexto, True, reporteCtaCte)
      'Else
      '   Throw New Exception("ATENCION: No tiene ninguna fila selleccionada para enviar el correo de prueba.")
      'End If



      Me.tspBarra.Value = 0
      'Me.RefrescarDatosGrilla()
   End Sub

   Private Sub btnExpandirHtml_Click(sender As Object, e As EventArgs) Handles btnExpandirHtml.Click
      Using frm As EditorHtml = New EditorHtml(rtbCuerpoMail.BodyHtml)
         If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            rtbCuerpoMail.BodyHtml = frm.BodyHTML
            If rtbCuerpoMail.BodyHtml <> String.Empty Then
               Me.btnEnviar.Enabled = True
            End If
         End If
      End Using
   End Sub

   Private Sub cmbCorreoEnviado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCorreoEnviado.SelectedIndexChanged
      If cmbCorreoEnviado.SelectedIndex = 1 Then
         Me.chbFechaEnvio.Enabled = True
      Else
         Me.chbFechaEnvio.Enabled = False
      End If
   End Sub

   Private Sub ugDetalle_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugDetalle.AfterRowFilterChanged
      Try
         btnTodos.PerformClick()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
      '  Try
      If (ValidarCorreo()) Then
         Me.Cursor = Cursors.WaitCursor
         Me.btnEnviar.Enabled = False
         Me.lblCantidadDeErrores.Visible = True

         EnviaMails()
      Else
         ShowMessage("Los Datos del Correo Electronico estan incompletos " + Environment.NewLine + " (Configuraciones -> Parametros del Sistema)")

      End If

      'Catch ex As Exception
      '   ShowError(ex, True)
      'Finally
      '   Me.Cursor = Cursors.Default
      '   tsbEnviarFacturas.Enabled = True
      'End Try
   End Sub

   Private Sub txtNroDesde_Leave(sender As Object, e As EventArgs) Handles txtNroDesde.Leave
      Try
         Me.txtNroHasta.Text = Me.txtNroDesde.Text
         Me.txtNroHasta.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaEnvio_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEnvio.CheckedChanged

      Me.chbMesCompletoFechaEnvio.Enabled = Me.chbFechaEnvio.Checked
      Me.dtpFechaEnvioDesde.Enabled = Me.chbFechaEnvio.Checked
      Me.dtpFechaEnviohasta.Enabled = Me.chbFechaEnvio.Checked

      If Not Me.chbFechaEnvio.Checked Then
         Me.chbMesCompletoFechaEnvio.Checked = False
         Me.dtpFechaEnvioDesde.Value = DateTime.Today
         Me.dtpFechaEnviohasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      Else
         Me.dtpFechaEnvioDesde.Focus()
      End If

   End Sub

   Private Sub chbMesCompletoFechaEnvio_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompletoFechaEnvio.CheckedChanged
      Dim FechaTemp As Date

      Try

         If chbMesCompletoFechaEnvio.Checked Then

            FechaTemp = New Date(Me.dtpFechaEnvioDesde.Value.Year, Me.dtpFechaEnvioDesde.Value.Month, 1)
            Me.dtpFechaEnvioDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpFechaEnvioDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpFechaEnviohasta.Value = FechaTemp

         End If

         Me.dtpFechaEnvioDesde.Enabled = Not Me.chbMesCompletoFechaEnvio.Checked
         Me.dtpFechaEnviohasta.Enabled = Not Me.chbMesCompletoFechaEnvio.Checked

      Catch ex As Exception

         chbMesCompletoFechaEnvio.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try
   End Sub

   Private Sub btnNoEnviar_Click(sender As Object, e As EventArgs) Handles btnNoEnviar.Click
      Try

         For Each dr As UltraGridRow In Me.ugDetalle.Rows

            If Boolean.Parse(dr.Cells("Envio").Value.ToString()) Then

               If Not IsDate(dr.Cells(Entidades.EnvioOC.Columnas.FechaEnvio.ToString()).Value.ToString) Then

                  Dim EnvioOC As Entidades.EnvioOC
                  Dim rEnvioOC As Reglas.EnviosOC = New Reglas.EnviosOC()

                  EnvioOC = New Entidades.EnvioOC
                  With EnvioOC
                     .IdSucursal = actual.Sucursal.Id
                     .TipoComprobante = New Reglas.TiposComprobantes().GetUno(dr.Cells("IdTipoComprobante").Value.ToString())
                     .Letra = dr.Cells("Letra").Value.ToString()
                     .CentroEmisor = Integer.Parse(dr.Cells("CentroEmisor").Value.ToString())
                     .NumeroPedido = Long.Parse(dr.Cells("NumeroPedido").Value.ToString())
                     .FechaEnvio = Date.Now
                     .IdUsuario = actual.Nombre

                  End With
                  rEnvioOC.Insertar(EnvioOC, "N", IdFuncion)

               End If
            End If
         Next

         Me.btnConsultar.PerformClick()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbVerErroresEnvio_Click(sender As Object, e As EventArgs) Handles tsbVerErroresEnvio.Click
      Try

         Dim pant As EnviosOCLogE = New EnviosOCLogE()
         pant.ShowDialog()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      If e.Cell.Row.Index <> -1 AndAlso e.Cell.Column.Key.Equals("Envio") AndAlso CBool(e.Cell.Text) Then
         If e.Cell.Row.Cells("CorreoElectronico").Text.Trim() = "" Then
            ShowMessage("No se puede seleccionar porque no tiene correo electronico")
            e.Cell.Value = False
         End If
         If cmbCorreoEnviado.Text = "SI" Then
            Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If IsDate(dr("FechaReprogEnvio").ToString()) Then
               If Date.Parse(dr("FechaReprogEnvio").ToString()).ToShortDateString <> Date.Parse(dr("FechaEntrega").ToString()).ToShortDateString Then
                  ShowMessage("No se puede seleccionar porque se debe enviar por la opcion NO enviadas.")
                  e.Cell.Value = False
               End If
            End If
         End If
      End If
   End Sub
End Class