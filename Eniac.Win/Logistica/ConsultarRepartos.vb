Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class ConsultarRepartos

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1
         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

         DtsRegistracionPagos.Pedidos.Columns.Add("FechaRendicion", GetType(DateTime))
         DtsRegistracionPagos.Pedidos.Columns.Add("Saldo", GetType(Decimal))
         DtsRegistracionPagos.Pedidos.Columns.Add("NullDate", GetType(DateTime)).DefaultValue = New Date()
         DtsRegistracionPagos.Pedidos.Columns.Add("Estado", GetType(String)).Expression = "IIF((ISNULL(FechaRendicion,NullDate)=NullDate),'PENDIENTE','RENDIDA')"

         DtsRegistracionPagos.Productos.Columns.Add("NumeroReparto", GetType(Integer))

         With ugComprobantes.DisplayLayout.Bands(DtsRegistracionPagos.Pedidos.TableName)
            .Columns("FechaRendicion").Hidden = True
            .Columns("NullDate").Hidden = True
            .Columns("Estado").Header.VisiblePosition = 0
            .Columns("Saldo").Header.VisiblePosition = .Columns(DtsRegistracionPagos.Pedidos.ImporteTotalColumn.ColumnName).Header.VisiblePosition + 1
            .Columns("Saldo").CellAppearance = DirectCast(.Columns(DtsRegistracionPagos.Pedidos.ImporteTotalColumn.ColumnName).CellAppearance.Clone(), AppearanceBase)
            .Columns("Saldo").Format = .Columns(DtsRegistracionPagos.Pedidos.ImporteTotalColumn.ColumnName).Format
            .Columns("Saldo").MaskInput = .Columns(DtsRegistracionPagos.Pedidos.ImporteTotalColumn.ColumnName).MaskInput
         End With
         With ugComprobantes.DisplayLayout.Bands(DtsRegistracionPagos.Pedidos.TableName) '.ChildRelations(0).RelationName)
            .Columns("NumeroReparto").Hidden = True
         End With
         With UltraGrid1.DisplayLayout.Bands(DtsRegistracionPagos.Productos.TableName)
            .Columns("NumeroReparto").Hidden = True
         End With

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ConsultarRepartos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"


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


         Dim Titulo As String

         Titulo = Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
         Me.UltraPrintPreviewDialog1.Name = Me.Text
         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = False
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")
         Me.UltraGridPrintDocument1.FitWidthToPages = 1  'Fuerzo el Ancho en uno por la observacion, tal vez haya que quitar ese campo.

         Me.UltraGridPrintDocument1.Grid = Me.ugDetalle

         Me.UltraPrintPreviewDialog1.ShowDialog()

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

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 dia.
            FechaTemp = dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumero.CheckedChanged
      Me.txtNumero.Enabled = Me.chbNumero.Checked
      If Not Me.chbNumero.Checked Then
         Me.txtNumero.Text = ""
      Else
         Me.txtNumero.Focus()
      End If
   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged
      Try
         Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

         If Not Me.chbVendedor.Checked Then
            Me.cmbVendedor.SelectedIndex = -1
         Else
            If Me.cmbVendedor.Items.Count > 0 Then
               Me.cmbVendedor.SelectedIndex = 0
            End If
         End If

         Me.cmbVendedor.Focus()
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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbNumero.Checked And (Me.txtNumero.Text = "" OrElse Long.Parse(Me.txtNumero.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumero.Focus()
            Exit Sub
         End If

         If Me.chbTransportista.Checked And Not Me.bscTransportista.Selecciono And IsNumeric(Me.bscTransportista.Tag) Then
            MessageBox.Show("No seleccionó un Transportista aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscTransportista.Focus()
            Exit Sub
         End If

         If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedItem Is Nothing Then
            MessageBox.Show("No seleccionó un Vendedor aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbVendedor.Focus()
            Exit Sub
         End If

         If Me.chbUsuario.Checked And Me.cmbUsuario.SelectedItem Is Nothing Then
            MessageBox.Show("No seleccionó un Usuario aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbUsuario.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If Me.ugDetalle.Rows.Count > 0 Then

            Me.ugDetalle.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("No hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.dtpDesde.Focus()

            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub bscTransportista_BuscadorClick() Handles bscTransportista.BuscadorClick
      Try
         Me._publicos.PreparaGrillaTransportistas(Me.bscTransportista)
         Dim oTransportistas As Eniac.Reglas.Transportistas = New Eniac.Reglas.Transportistas
         Me.bscTransportista.Datos = oTransportistas.GetFiltradoPorNombre(Me.bscTransportista.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub bscTransportista_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscTransportista.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTransportista(e.FilaDevuelta)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub chbTransportista_CheckedChanged(sender As Object, e As EventArgs) Handles chbTransportista.CheckedChanged
      Try
         Me.bscTransportista.Enabled = Me.chbTransportista.Checked

         If Not Me.chbTransportista.Checked Then
            Me.bscTransportista.Text = ""
         End If

         Me.bscTransportista.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)
      Me.chbNumero.Checked = False
      Me.chbVendedor.Checked = False
      Me.chbUsuario.Checked = False
      Me.chbTransportista.Checked = False

      'Limpio las Grillas.

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oVenta As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()

         Dim TotalNeto As Decimal = 0
         Dim TotalImpuestos As Decimal = 0
         Dim Total As Decimal = 0

         Dim IdCliente As Long = 0
         Dim IdTransportista As Integer = 0

         Dim IdTipoComprobante As String = String.Empty
         Dim NumeroReparto As Long = 0

         Dim TipoDocVendedor As String = String.Empty
         Dim NroDocVendedor As String = String.Empty

         Dim IdFormasPago As Integer = 0
         Dim IdUsuario As String = String.Empty

         If Me.chbNumero.Checked Then
            NumeroReparto = Long.Parse(Me.txtNumero.Text)
         End If

         If Me.cmbVendedor.Enabled Then
            TipoDocVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).TipoDocEmpleado
            NroDocVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).NroDocEmpleado
         End If

         If Me.bscTransportista.Enabled AndAlso Me.bscTransportista.Tag IsNot Nothing Then
            IdTransportista = CInt(Me.bscTransportista.Tag)
         End If

         If Me.chbUsuario.Checked Then
            IdUsuario = DirectCast(Me.cmbUsuario.SelectedItem, Eniac.Entidades.Usuario).Id
         End If

         Dim dtDetalle As DataTable

         dtDetalle = oVenta.GetRepartos(actual.Sucursal.Id,
                                        desde:=dtpDesde.Value,
                                        hasta:=dtpHasta.Value,
                                        tipoDocVendedor:=TipoDocVendedor,
                                        nroDocVendedor:=NroDocVendedor,
                                        idCliente:=IdCliente,
                                        tipoComprobante:=IdTipoComprobante,
                                        numeroReparto:=NumeroReparto,
                                        idFormasPago:=IdFormasPago,
                                        idUsuario:=IdUsuario,
                                        idEstadoComprobante:=String.Empty,
                                        porcUtilidadDesde:=-1,
                                        porcUtilidadHasta:=-1,
                                        comercial:="TODOS",
                                        idCategoria:=0,
                                        idTransportista:=IdTransportista)

         tbcDetalle.SelectedTab = tbpReparto
         DtsRegistracionPagos.Clear()
         Me.ugDetalle.DataSource = CargaDT(dtDetalle, CreaDT())

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CargarDatosTransportista(ByVal dr As DataGridViewRow)
      Me.bscTransportista.Text = dr.Cells("NombreTransportista").Value.ToString()
      Dim Transp As Eniac.Reglas.Transportistas = New Eniac.Reglas.Transportistas()
      Me.bscTransportista.Tag = Long.Parse(dr.Cells("IdTransportista").Value.ToString())
   End Sub

   Private Function CreaDT() As DataTable
      Dim dt As DataTable = New DataTable()

      dt.Columns.Add("FechaEnvio", GetType(DateTime))
      dt.Columns.Add("NumeroReparto", GetType(Integer))
      dt.Columns.Add("Transportistas", GetType(String))
      dt.Columns.Add("Vendedores", GetType(String))

      Return dt
   End Function

   Private Function CargaDT(dtOrigen As DataTable, dtDestino As DataTable) As DataTable

      For Each drOrigen As DataRow In dtOrigen.Rows
         Dim dr() As DataRow = dtDestino.Select("NumeroReparto = " + drOrigen("NumeroReparto").ToString())
         Dim drDestino As DataRow
         If dr.Length > 0 Then
            drDestino = dr(0)
         Else
            drDestino = dtDestino.NewRow()
            drDestino("FechaEnvio") = drOrigen("FechaEnvio")
            drDestino("NumeroReparto") = drOrigen("NumeroReparto")
            dtDestino.Rows.Add(drDestino)
         End If
         If IsDBNull(drDestino("Transportistas")) Then
            drDestino("Transportistas") = drOrigen("NombreTransportista")
         Else
            drDestino("Transportistas") = drDestino("Transportistas").ToString() + ", " + drOrigen("NombreTransportista").ToString()
         End If
         'If IsDBNull(drDestino("Vendedores")) Then
         '   drDestino("Vendedores") = drOrigen("Vendedores")
         'Else
         '   drDestino("Vendedores") = drDestino("Vendedores").ToString() + ", " + drOrigen("NombreVendedore").ToString()
         'End If
      Next
      Return dtDestino
   End Function

#End Region

   Private Sub tsbListadoClientes_Click(sender As Object, e As EventArgs) Handles tsbListadoClientes.Click

      Try
         If ugDetalle.ActiveRow IsNot Nothing AndAlso
            ugDetalle.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugDetalle.ActiveRow.ListObject) Is DataRowView AndAlso
            DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then

            Me.Cursor = Cursors.WaitCursor

            Dim dr As DataRow = DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row
            Dim fechaDesde As DateTime = CDate(dr("FechaEnvio")).Date
            Dim numeroReparto As Integer = CInt(dr("NumeroReparto"))

            Dim filtros As String = String.Empty
            Dim IdTransportista As Integer = 0
            Dim TipoDocVendedor As String = String.Empty
            Dim NroDocVendedor As String = String.Empty

            If Me.bscTransportista.Enabled AndAlso Me.bscTransportista.Tag IsNot Nothing Then
               IdTransportista = CInt(Me.bscTransportista.Tag)
               filtros = filtros + " Resp. de Distribución: " & Me.bscTransportista.Text & " -- "
            End If

            If Me.cmbVendedor.Enabled Then
               TipoDocVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).TipoDocEmpleado
               NroDocVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).NroDocEmpleado
               filtros = filtros + " Vendedor: " & DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).NombreEmpleado & " -- "
            End If

            filtros = filtros + " Nro. Reparto: " & numeroReparto & " -- "


            filtros = filtros + " Fecha de envío: desde el " & dtpDesde.Value.ToString() & " hasta el " & dtpHasta.Value.ToString()

            Dim impresion As New ImprimirRepartosListadoDeClientes()
            impresion.Imprimir(filtros, Nothing, Nothing, numeroReparto, numeroReparto, IdTransportista, TipoDocVendedor, NroDocVendedor, Me.Text)

         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbConsolidadoCarga_Click(sender As Object, e As EventArgs) Handles tsbConsolidadoCarga.Click
      Try
         ImprimirConsolidadCarga(False)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbConsolidadoCargaTipoOperacion_Click(sender As Object, e As EventArgs) Handles tsbConsolidadoCargaTipoOperacion.Click
      Try
         ImprimirConsolidadCarga(True)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDetalle.SelectedIndexChanged
      'PARA MEJORAR LA PERFORMANCE RECIEN CUANDO CAMBIO A LA SOLAPA DE COMPROBANTES SE EJECUTAN 
      'LOS QUERIES PARA DICHA TABLA SIEMPRE Y CUANDO YA NO SE ENCUENTREN EN MEMORIA.
      If Not tbcDetalle.SelectedTab.Equals(tbpReparto) AndAlso
         ugDetalle.ActiveRow IsNot Nothing AndAlso
         ugDetalle.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugDetalle.ActiveRow.ListObject) Is DataRowView AndAlso
         DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then
         Try
            Cursor = Cursors.WaitCursor
            Dim numeroReparto As Integer = CInt(DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row(DtsRegistracionPagos.Pedidos.NumeroRepartoColumn.ColumnName))
            If DtsRegistracionPagos.Pedidos.Select(String.Format("{0} = {1}",
                                                                  DtsRegistracionPagos.Pedidos.NumeroRepartoColumn.ColumnName,
                                                                  numeroReparto)).Length = 0 Then
               Dim cl As Reglas.RegistracionPagos = New Reglas.RegistracionPagos()
               DtsRegistracionPagos.Pedidos.Merge(cl.GetPedidos(actual.Sucursal.IdSucursal, 0, 0, numeroReparto, DateTime.MaxValue, False), False, MissingSchemaAction.Ignore)
               DtsRegistracionPagos.Productos.Merge(cl.GetPedidosProductos(actual.Sucursal.IdSucursal, 0, 0, numeroReparto, DateTime.MaxValue, False), False, MissingSchemaAction.Ignore)
            End If
            PedidosBindingSource.Filter = String.Format("{0} = {1}",
                                                        DtsRegistracionPagos.Pedidos.NumeroRepartoColumn.ColumnName,
                                                        numeroReparto)
            PedidosProductosBindingSource.Filter = String.Format("{0} = {1}",
                                                        DtsRegistracionPagos.Pedidos.NumeroRepartoColumn.ColumnName,
                                                        numeroReparto)
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Cursor = Cursors.Default
         End Try
      End If
   End Sub

   Private Sub ugComprobantes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugComprobantes.InitializeRow
      'PARA PINTAR LA COLUMNA DE ESTADO SEGÚN SU ESTADO.
      If e.Row.Band.Key = DtsRegistracionPagos.Pedidos.TableName Then
         If e.Row.Cells("Estado").Value.ToString() = "PENDIENTE" Then
            e.Row.Cells("Estado").Appearance.BackColor = Color.LightYellow
            e.Row.Cells("Estado").ActiveAppearance.BackColor = Color.LightYellow
            e.Row.Cells("Estado").ActiveAppearance.ForeColor = Color.Black
         Else
            e.Row.Cells("Estado").Appearance.BackColor = Color.LightGreen
            e.Row.Cells("Estado").ActiveAppearance.BackColor = Color.LightGreen
            e.Row.Cells("Estado").ActiveAppearance.ForeColor = Color.Black
         End If
      End If
   End Sub

   Private Sub ImprimirConsolidadCarga(porTipoOperacion As Boolean)
      If ugDetalle.ActiveRow IsNot Nothing AndAlso
         ugDetalle.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugDetalle.ActiveRow.ListObject) Is DataRowView AndAlso
         DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then

         Me.Cursor = Cursors.WaitCursor

         Dim dr As DataRow = DirectCast(ugDetalle.ActiveRow.ListObject, DataRowView).Row
         Dim fechaDesde As DateTime = CDate(dr("FechaEnvio")).Date
         Dim numeroReparto As Integer = CInt(dr("NumeroReparto"))

         Dim filtros As String = String.Empty
         Dim IdTransportista As Integer = 0
         Dim TipoDocVendedor As String = String.Empty
         Dim NroDocVendedor As String = String.Empty

         If Me.bscTransportista.Enabled AndAlso Me.bscTransportista.Tag IsNot Nothing Then
            IdTransportista = CInt(Me.bscTransportista.Tag)
            filtros = filtros + " Resp. de Distribución: " & Me.bscTransportista.Text & " -- "
         End If

         If Me.cmbVendedor.Enabled Then
            TipoDocVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).TipoDocEmpleado
            NroDocVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).NroDocEmpleado
            filtros = filtros + " Vendedor: " & DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).NombreEmpleado & " -- "
         End If

         filtros = filtros + " Nro. Reparto: " & numeroReparto & " -- "


         filtros = filtros + " Fecha de envío: desde el " & dtpDesde.Value.ToString() & " hasta el " & dtpHasta.Value.ToString()

         Dim impresion As New ImprimirRepartosConsolidadoCargaMercaderia()
         impresion.Imprimir(filtros, dtpDesde.Value, dtpHasta.Value, {numeroReparto}, IdTransportista, TipoDocVendedor, NroDocVendedor, Me.Text, porTipoOperacion)

      End If
   End Sub

End Class