Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Public Class ModificarRepartos

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         _publicos.CargaComboTransportistas(cmbTransportista)

         DtsRegistracionPagos.Pedidos.Columns.Add("FechaRendicion", GetType(DateTime))
         DtsRegistracionPagos.Pedidos.Columns.Add("Saldo", GetType(Decimal))
         DtsRegistracionPagos.Pedidos.Columns.Add("NullDate", GetType(DateTime)).DefaultValue = New Date()
         DtsRegistracionPagos.Pedidos.Columns.Add("Estado", GetType(String)).Expression = "IIF((ISNULL(FechaRendicion,NullDate)=NullDate),'PENDIENTE','RENDIDA')"

         DtsRegistracionPagos.Productos.Columns.Add("NumeroReparto", GetType(Integer))

         With ugComprobantes.DisplayLayout.Bands(DtsRegistracionPagos.Pedidos.TableName)
            .Columns("FechaRendicion").Hidden = True
            .Columns("NullDate").Hidden = True
            .Columns("Estado").Header.VisiblePosition = 1
            .Columns("Saldo").Hidden = True
            .Columns("Saldo").Header.VisiblePosition = .Columns(DtsRegistracionPagos.Pedidos.ImporteTotalColumn.ColumnName).Header.VisiblePosition + 1
            .Columns("Saldo").CellAppearance = DirectCast(.Columns(DtsRegistracionPagos.Pedidos.ImporteTotalColumn.ColumnName).CellAppearance.Clone(), AppearanceBase)
            .Columns("Saldo").Format = .Columns(DtsRegistracionPagos.Pedidos.ImporteTotalColumn.ColumnName).Format
            .Columns("Saldo").MaskInput = .Columns(DtsRegistracionPagos.Pedidos.ImporteTotalColumn.ColumnName).MaskInput

         End With
         With ugComprobantes.DisplayLayout.Bands(DtsRegistracionPagos.Pedidos.TableName) '.ChildRelations(0).RelationName)
            .Columns("NumeroReparto").Hidden = True
         End With

         RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ModificarRepartos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar.PerformClick()
      ElseIf e.KeyCode = Keys.F4 Then
         tsbGrabar.PerformClick()
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         MuestraCantidadRegistros()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try
         GrabarReparto()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try
         If Me.ugComprobantes.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty


         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

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

         Me.UltraGridPrintDocument1.Grid = Me.ugComprobantes

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
               Me.UltraGridExcelExporter1.Export(Me.ugComprobantes, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
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
               Me.UltraGridDocumentExporter1.Export(Me.ugComprobantes, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If Me.bscReparto2.Text = "" OrElse Long.Parse(Me.bscReparto2.Text) = 0 Then
            MessageBox.Show("Ingrese el Número de Reparto a modificar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscReparto2.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If DtsRegistracionPagos.Pedidos.Rows.Count > 0 Then
            ugComprobantes.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("No hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscReparto2.Focus()
            Exit Sub
         End If
      Catch ex As Exception
         MuestraCantidadRegistros(0)
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region


#Region "Metodos"
   Private Sub RefrescarDatosGrilla()

      bscReparto2.Text = "0"
      dtpFechaEnvio.Value = Today
      cmbTransportista.SelectedIndex = -1
      chbTransportista.Checked = False
      chbFechaEnvio.Checked = False
      bscReparto2.Focus()
      btnInsertar.Enabled = False
      btnEliminar.Enabled = False

      'Limpio las Grillas.
      DtsRegistracionPagos.Clear()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try
         bscReparto2.PresionarBoton()

         Dim NumeroReparto As Integer = 0
         NumeroReparto = Integer.Parse(Me.bscReparto2.Text)

         DtsRegistracionPagos.Clear()
         Dim cl As Reglas.RegistracionPagos = New Reglas.RegistracionPagos()
         DtsRegistracionPagos.Pedidos.Merge(cl.GetPedidos(actual.Sucursal.IdSucursal, 0, 0, NumeroReparto, DateTime.MaxValue, False,
                                                          Entidades.RegistracionPagos.ModoConsultarComprobantes.SoloRepartoSeleccionado, IdEmpleado:=0, idRuta:=0, dia:=Nothing), False, MissingSchemaAction.Ignore)
         DtsRegistracionPagos.Productos.Merge(cl.GetPedidosProductos(actual.Sucursal.IdSucursal, 0, 0, NumeroReparto, DateTime.MaxValue, False,
                                                                     Entidades.RegistracionPagos.ModoConsultarComprobantes.SoloRepartoSeleccionado, IdEmpleado:=0, idRuta:=0, dia:=Nothing), False, MissingSchemaAction.Ignore)

         MuestraCantidadRegistros()

         btnInsertar.Enabled = True
         btnEliminar.Enabled = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub MuestraCantidadRegistros()
      MuestraCantidadRegistros(DtsRegistracionPagos.Pedidos)
   End Sub
   Private Sub MuestraCantidadRegistros(dt As DataTable)
      MuestraCantidadRegistros(dt.Rows.Count)
   End Sub
   Private Sub MuestraCantidadRegistros(cantidad As Integer)
      Me.tssRegistros.Text = cantidad.ToString() & " Registros"
   End Sub

   Private Sub GrabarReparto()
      Try
         If Not IsNumeric(bscReparto2.Text) Then
            MessageBox.Show("Debe ingresar un Número de Reparto", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
         If DtsRegistracionPagos.Pedidos.Count = 0 Then
            MessageBox.Show("No puede grabar un reparto sin comprobantes. Para anular un reparto use la Anulación de Repartos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
         DtsRegistracionPagos.AcceptChanges()
         Dim numeroReparto As Integer = Integer.Parse(bscReparto2.Text)
         If numeroReparto <> DtsRegistracionPagos.Pedidos(0).NumeroReparto Then
            MessageBox.Show("El número de reparto indicado difiere del número de reparto de los comprobantes. Presione Consultar y vuelva a intentar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
         If MessageBox.Show(String.Format("¿Desea modificar el reparto {0}?", bscReparto2.Text), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim rRepartos As Reglas.Repartos = New Reglas.Repartos()
            Dim nuevoNroReparto As Integer
            Dim nuevaFechaReparto As DateTime? = Nothing
            Dim nuevoTransportista As Eniac.Entidades.Transportista = Nothing
            If chbFechaEnvio.Checked Then
               nuevaFechaReparto = dtpFechaEnvio.Value.Date
            End If
            If chbTransportista.Checked AndAlso cmbTransportista.SelectedIndex > -1 Then
               nuevoTransportista = DirectCast(cmbTransportista.SelectedItem, Eniac.Entidades.Transportista)
            End If

            nuevoNroReparto = rRepartos.ModificarReparto(actual.Sucursal.IdSucursal, numeroReparto, DtsRegistracionPagos.Pedidos,
                                                         nuevaFechaReparto, nuevoTransportista)

            MessageBox.Show("¡Grabación realizada exitosamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            RefrescarDatosGrilla()

            bscReparto2.Text = nuevoNroReparto.ToString()
            bscReparto2.PresionarBoton()
            CargaGrillaDetalle()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region


   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         bscComprobante2.Visible = True
         bscComprobante2.PresionarBoton()
         bscComprobante2.Visible = False
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If ugComprobantes.ActiveRow IsNot Nothing AndAlso
            ugComprobantes.ActiveRow.ListObject IsNot Nothing AndAlso
            TypeOf (ugComprobantes.ActiveRow.ListObject) Is DataRowView AndAlso
            DirectCast(ugComprobantes.ActiveRow.ListObject, DataRowView).Row IsNot Nothing AndAlso
            TypeOf (DirectCast(ugComprobantes.ActiveRow.ListObject, DataRowView).Row) Is dtsRegistracionPagos.PedidosRow Then

            Dim dr As dtsRegistracionPagos.PedidosRow = DirectCast(DirectCast(ugComprobantes.ActiveRow.ListObject, DataRowView).Row, dtsRegistracionPagos.PedidosRow)

            If IsDBNull(dr("FechaRendicion")) Then
               If MessageBox.Show(String.Format("¿Está seguro que desea eliminar el comprobante {0} {1} {2:0000}-{3:00000000} del reparto {4}?",
                                                dr.IdTipoComprobante, dr.Letra, dr.CentroEmisor, dr.NumeroComprobante, bscReparto2.Text), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                  dr.Delete()
               Else
                  Exit Sub
               End If
            Else
               MessageBox.Show("El comprobante seleccionado ya ha sido rendido en este reparto. No se puede eliminar.")
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscComprobante2_BuscadorClick() Handles bscComprobante2.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaComprobantesReenvio(Me.bscComprobante2)
         Dim regla As Reglas.OrganizarEntregas = New Reglas.OrganizarEntregas()

         Dim dt As DataTable = regla.GetPedidosSolos(fechaDesde:=New Date(1900, 1, 1), fechaHasta:=New Date(3000, 1, 1),
                                                     distribucion:=0, IdEmpleado:=0,
                                                     producto:=String.Empty, sinStock:=False, NombreProducto:=String.Empty,
                                                     pedidos:=False, reenvios:=True,
                                                     ordenProducto:=Nothing,
                                                     IdLocalidad:=Nothing,
                                                     IdCliente:=Nothing)
         If dt.Rows.Count = 1 Then
            dt.Rows.Add(dt.NewRow())
         End If
         Me.bscComprobante2.Datos = dt
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscComprobante2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscComprobante2.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarComprobanteReenvio(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub CargarComprobanteReenvio(dr As DataGridViewRow)
      If IsNumeric(dr.Cells("IdSucursal").Value.ToString()) Then
         Dim drPedido As dtsRegistracionPagos.PedidosRow = DtsRegistracionPagos.Pedidos.NewPedidosRow()

         drPedido.IdSucursal = actual.Sucursal.IdSucursal
         drPedido.NumeroReparto = Integer.Parse(bscReparto2.Text)
         drPedido.IdSucursal = Integer.Parse(dr.Cells("IdSucursal").Value.ToString())
         drPedido.IdTipoComprobante = dr.Cells("IdTipoComprobante").Value.ToString()
         drPedido.Letra = dr.Cells("Letra").Value.ToString()
         drPedido.CentroEmisor = Integer.Parse(dr.Cells("CentroEmisor").Value.ToString())
         drPedido.NumeroComprobante = Long.Parse(dr.Cells("NumeroPedido").Value.ToString())
         drPedido.FormaDePago = dr.Cells("DescripcionFormasPago").Value.ToString()
         drPedido.CodigoCliente = Long.Parse(dr.Cells("CodigoCliente").Value.ToString())
         drPedido.NombreCliente = dr.Cells("NombreCliente").Value.ToString()
         drPedido.Direccion = dr.Cells("Direccion").Value.ToString()

         drPedido.ImporteTotal = Decimal.Parse(dr.Cells("ImporteTotal").Value.ToString())
         'drPedido.FechaEnvio = DateTime.Parse(dr.Cells("FechaEntrega").Value.ToString())
         drPedido.Fecha = DateTime.Parse(dr.Cells("FechaPedido").Value.ToString())
         drPedido.NombreTransportista = dr.Cells("NombreTransportista").Value.ToString()
         drPedido.NombreEmpleado = dr.Cells("NombreEmpleado").Value.ToString()

         DtsRegistracionPagos.Pedidos.AddPedidosRow(drPedido)
      Else
         MessageBox.Show("Debe seleccionar un comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If            'If IsNumeric(dr.Cells("IdSucursal").Value.ToString()) Then
   End Sub

   Private Sub bscReparto2_BuscadorClick() Handles bscReparto2.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaRepartos(Me.bscReparto2)

         Dim NumeroReparto As Integer = 0
         If IsNumeric(bscReparto2.Text) Then NumeroReparto = Integer.Parse(bscReparto2.Text)

         Dim oVenta As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()
         Dim dt As DataTable = oVenta.GetRepartos({actual.Sucursal},
                                                  fechaEnvioDesde:=Nothing,
                                                  fechaEnvioHasta:=Nothing,
                                                  IdVendedor:=0,
                                                  idCliente:=0,
                                                  idTipoComprobante:=String.Empty,
                                                  numeroReparto:=NumeroReparto,
                                                  idFormasPago:=0,
                                                  idUsuario:=String.Empty,
                                                  idEstadoComprobante:=String.Empty,
                                                  porcUtilidadDesde:=Nothing,
                                                  porcUtilidadHasta:=Nothing,
                                                  esComercial:=Entidades.Publicos.SiNoTodos.TODOS,
                                                  idCategoria:=0,
                                                  idTransportista:=0)

         'Dim regla As Reglas.Repartos = New Reglas.Repartos()

         'Dim dt As DataTable = regla.GetAll()
         '(fechaDesde:=New Date(1900, 1, 1), fechaHasta:=New Date(3000, 1, 1),
         '                                                  distribucion:=0, TipoDocEmpleado:=String.Empty, NroDocEmpleado:=String.Empty,
         '                                                  producto:=String.Empty, sinStock:=False, NombreProducto:=String.Empty,
         '                                                  Pedidos:=False, reenvios:=True)
         Me.bscReparto2.Datos = dt
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscReparto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscReparto2.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarReparto(e.FilaDevuelta)
            btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub CargarReparto(dr As DataGridViewRow)
      bscReparto2.Text = dr.Cells("NumeroReparto").Value.ToString()
      dtpFechaEnvio.Value = DateTime.Parse(dr.Cells("FechaEnvio").Value.ToString())
      cmbTransportista.SelectedValue = dr.Cells("IdTransportista").Value
   End Sub

   Private Sub lblTransportista_Click(sender As Object, e As EventArgs) Handles lblTransportista.Click
      chbTransportista.Checked = Not chbTransportista.Checked
   End Sub

   Private Sub lblFechaEnvio_Click(sender As Object, e As EventArgs) Handles lblFechaEnvio.Click
      chbFechaEnvio.Checked = Not chbFechaEnvio.Checked
   End Sub

   Private Sub chbFechaEnvio_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEnvio.CheckedChanged
      dtpFechaEnvio.Enabled = chbFechaEnvio.Checked
   End Sub

   Private Sub chbTransportista_CheckedChanged(sender As Object, e As EventArgs) Handles chbTransportista.CheckedChanged
      cmbTransportista.Enabled = chbTransportista.Checked
   End Sub
End Class