Public Class AdministracionDeContratos

#Region "Campos"

   Private _publicos As Publicos
   'Dim FechaDesde As Date = Nothing
   'Dim FechaHasta As Date = Nothing
   'Dim IdProducto As String = String.Empty
   Dim NumeroContrato As Long = 0
   Dim idEstado As Integer = 0
   Dim FechaRealFin As Date

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Me.dtpDesde.Value.AddMonths(1)

      Me.cmbRenovables.Items.Insert(0, "TODOS")
      Me.cmbRenovables.Items.Insert(1, "SI")
      Me.cmbRenovables.Items.Insert(2, "NO")
      Me.cmbRenovables.SelectedIndex = 0

      Me._publicos.CargaComboEstadosContratos(Me.cmbEstados)
      Me.cmbEstados.SelectedIndex = 0

      Me._publicos.CargaComboEstadosContratos(Me.cmbEstadoCambiar)
      DirectCast(Me.cmbEstadoCambiar.DataSource, DataTable).Rows.RemoveAt(0)  'Borro el Elemento ALTA.
      Me.cmbEstadoCambiar.SelectedIndex = 0

   End Sub

#End Region

#Region "Eventos"

   Private Sub AdministracionDeContratos_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar.PerformClick()
      End If
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
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

   Private Sub tsbImprimirContrato_Click(sender As Object, e As EventArgs) Handles tsbImprimirContrato.Click

      If Me.ugDetalle.ActiveCell Is Nothing Then
         MessageBox.Show("Debe seleccionar un Contrato para Imprimir.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      Me.ImprimirContrato()

   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         'Filtros = Filtros & " / Fecha de: " & IIf(Me.rdbFechaMovimiento.Checked, "Movimiento", "Planilla").ToString()

         'If Me.chbCaja.Checked Then
         '   Filtros = Filtros & " / Caja: " & Me.cmbCajas.Text
         'End If

         'If Me.chbCuentaDeCaja.Checked Then
         '   Filtros = "Cuenta: " & Me.bscCuentaCaja.Text & " - " & Me.bscNombreCuentaCaja.Text
         'End If

         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1
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

         Me.UltraPrintPreviewDialog1.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
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

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
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

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged

      Try

         If Me.chkTodos.Checked Then
            Me.dtpDesde.Value = Reglas.Publicos.FechaInicioActividades
            Me.dtpHasta.Value = Me.dtpHasta.MaxDate
         End If

         Me.dtpDesde.Enabled = Not Me.chkTodos.Checked
         Me.dtpHasta.Enabled = Not Me.chkTodos.Checked

      Catch ex As Exception

         Me.chkTodos.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstado.CheckedChanged

      Me.cmbEstados.Enabled = Me.chbEstado.Checked

      If Not Me.chbEstado.Checked Then
         Me.cmbEstados.SelectedIndex = -1
      Else
         Me.chbEstadoActivo.Checked = False
         Me.cmbEstados.SelectedIndex = 0
         Me.cmbEstados.Focus()
      End If

   End Sub

   Private Sub chbEstadoActivo_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstadoActivo.CheckedChanged

      If chbEstadoActivo.Checked Then
         Me.chbEstado.Checked = False
      End If

   End Sub

   Private Sub cmbEstadoCambiar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstadoCambiar.SelectedIndexChanged

      Me.lblNuevoFinReal.Visible = (cmbEstadoCambiar.Text = "Finalizado" Or cmbEstadoCambiar.Text = "Renovado")
      Me.dtpNuevoFinReal.Visible = Me.lblNuevoFinReal.Visible

   End Sub

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      Else
         Me.bscCodigoProducto2.Focus()
      End If
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Dim blnSoloAlquilables As Boolean = True
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", , , blnSoloAlquilables)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Dim blnSoloAlquilables As Boolean = True
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", , blnSoloAlquilables)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbProducto.Checked And Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         'Me.chkExpandAll.Enabled = True
         'Me.chkExpandAll.Checked = False

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub ugDetalle_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugDetalle.ClickCell

      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      If Me.ugDetalle.ActiveCell Is Nothing Then Exit Sub

      'FechaDesde = Date.Parse(Me.ugDetalle.ActiveCell.Row.Cells("FechaDesde").Value.ToString())
      'FechaHasta = Date.Parse(Me.ugDetalle.ActiveCell.Row.Cells("FechaHasta").Value.ToString())
      'IdProducto = Me.ugDetalle.ActiveCell.Row.Cells("IdProducto").Value.ToString()

      NumeroContrato = Long.Parse(Me.ugDetalle.ActiveCell.Row.Cells("NumeroContrato").Value.ToString())

      idEstado = Integer.Parse(Me.ugDetalle.ActiveCell.Row.Cells("IdEstado").Value.ToString())

      FechaRealFin = Date.Parse(Me.ugDetalle.ActiveCell.Row.Cells("FechaRealFin").Value.ToString())
      Me.dtpNuevoFinReal.Value = FechaRealFin

      'Me.lblContrato.Text = FechaDesde.ToString() & " - " & _
      '                      FechaHasta.ToString() & " Producto: " & Me.ugDetalle.ActiveCell.Row.Cells("NombreProducto").Value.ToString()

   End Sub

   Private Sub cmdCambiar_Click(sender As Object, e As EventArgs) Handles cmdCambiar.Click

      If Me.ugDetalle.ActiveCell Is Nothing Then
         MessageBox.Show("Debe seleccionar un Contrato para cambiar el Estado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      'If Me.cmbEstadoCambiar.SelectedIndex = 0 Then
      '   MessageBox.Show("Debe seleccionar un Estado distinto de ""Todos"" para cambiar el Estado del Contrato.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Exit Sub
      'End If

      'El Estado Renovado es el unico que permite repetir.
      If idEstado = 40 Then
         MessageBox.Show("El Estado Finalizado del Contrato NO permite cambio.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      'El Estado Renovado es el unico que permite repetir.
      If idEstado <> 30 And idEstado = Integer.Parse(Me.cmbEstadoCambiar.SelectedValue.ToString()) Then
         MessageBox.Show("El Estado a cambiar debe ser distinto al Estado Actual del Contrato.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      If idEstado = 10 And Integer.Parse(Me.cmbEstadoCambiar.SelectedValue.ToString()) <> 20 Then
         MessageBox.Show("Desde el estado ""ALTA"" solo puede moverlo a ""En Vigencia"".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      If MessageBox.Show("Desea cambiar el Estado actual del Contarto -" & Me.ugDetalle.ActiveCell.Row.Cells("NombreEstado").Value.ToString() & "- al Estado: " & Me.cmbEstadoCambiar.Text, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

         Dim oAlquileres As Reglas.Alquileres = New Reglas.Alquileres

         oAlquileres.ActualizarEstadoContrato(actual.Sucursal.Id, NumeroContrato, Integer.Parse(Me.cmbEstadoCambiar.SelectedValue.ToString()), Me.dtpNuevoFinReal.Value, Entidades.Entidad.MetodoGrabacion.Manual, Me.IdFuncion)

         MessageBox.Show("Contrato actualizado Exitosamente !!.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.CargaGrillaDetalle()

      End If

   End Sub

   Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
      Me.cmbEstadoCambiar.SelectedIndex = 0
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProducto(dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.cmbEstados.SelectedIndex = 0
      Me.cmbEstadoCambiar.SelectedIndex = 0

      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Me.dtpDesde.Value.AddMonths(1)

      Me.chbEstado.Checked = False
      Me.chbEstadoActivo.Checked = True

      Me.cmbRenovables.SelectedIndex = 0

      Me.chkTodos.Checked = False

      Me.chbProducto.Checked = False

      'Limpio la Grilla.
      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      'FechaDesde = Nothing
      'FechaHasta = Nothing
      'IdProducto = String.Empty

      NumeroContrato = 0
      idEstado = 0

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oAlquileres As Reglas.Alquileres = New Reglas.Alquileres

         Me.cmbEstadoCambiar.SelectedIndex = 0

         Dim IdEstado As Integer = -1

         If Me.chbEstado.Checked Then
            IdEstado = Integer.Parse(Me.cmbEstados.SelectedValue.ToString())
         End If

         Dim IdProducto As String = String.Empty

         If Me.chbProducto.Checked Then
            IdProducto = Me.bscCodigoProducto2.Text
         End If

         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         dtDetalle = oAlquileres.GetContratos(actual.Sucursal.IdSucursal _
                                                , Me.dtpDesde.Value _
                                                , Me.dtpHasta.Value _
                                                , IdEstado _
                                                , Me.chbEstadoActivo.Checked _
                                                , Me.cmbRenovables.Text _
                                                , IdProducto)

         dt = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("Color") = ""
            drCl("IdEstado") = Integer.Parse(dr("IdEstado").ToString())
            drCl("NombreEstado") = dr("NombreEstado").ToString()
            drCl("IdProducto") = dr("IdProducto").ToString()
            drCl("NombreProducto") = dr("NombreProducto").ToString()
            drCl("NumeroContrato") = Long.Parse(dr("NumeroContrato").ToString())
            drCl("FechaContrato") = Date.Parse(dr("FechaContrato").ToString())
            drCl("FechaDesde") = Date.Parse(dr("FechaDesde").ToString())
            drCl("FechaHasta") = Date.Parse(dr("FechaHasta").ToString())
            drCl("CantDias") = Date.Parse(dr("FechaRealFin").ToString()).Date.Subtract(Date.Parse(dr("FechaDesde").ToString()).Date).TotalDays.ToString
            drCl("FechaRealFin") = Date.Parse(dr("FechaRealFin").ToString())
            drCl("EsRenovable") = IIf(Boolean.Parse(dr("EsRenovable").ToString()), "SI", "NO")
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())
            drCl("IdUsuario") = dr("IdUsuario").ToString()

            If Not String.IsNullOrEmpty(dr("Letra").ToString()) Then
               drCl("Remito") = dr("Letra").ToString() & " " & Integer.Parse(dr("CentroEmisor").ToString()).ToString("0000") & "-" & Long.Parse(dr("NumeroComprobante").ToString()).ToString("00000000")
            End If

            dt.Rows.Add(drCl)

         Next

         Me.ugDetalle.DataSource = dt

         For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.ugDetalle.Rows
            Select Case Integer.Parse(fila.Cells("IdEstado").Value.ToString())
               Case 20 ' En Vigencia
                  fila.Cells("Color").Appearance.BackColor = Color.Green
               Case 30 ' Renovado
                  fila.Cells("Color").Appearance.BackColor = Color.Yellow
               Case 40 ' Finalizado
                  fila.Cells("Color").Appearance.BackColor = Color.Red
            End Select
         Next

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         '.Columns.Add("Color")
         .Columns.Add("Color", System.Type.GetType("System.String"))
         .Columns.Add("IdEstado", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreEstado", System.Type.GetType("System.String"))
         .Columns.Add("IdProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         .Columns.Add("NumeroContrato", System.Type.GetType("System.Int64"))
         .Columns.Add("FechaContrato", System.Type.GetType("System.DateTime"))
         .Columns.Add("FechaDesde", System.Type.GetType("System.DateTime"))
         .Columns.Add("FechaHasta", System.Type.GetType("System.DateTime"))
         .Columns.Add("CantDias", System.Type.GetType("System.Int32"))
         .Columns.Add("FechaRealFin", System.Type.GetType("System.DateTime"))
         .Columns.Add("EsRenovable", System.Type.GetType("System.String"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdUsuario", System.Type.GetType("System.String"))
         .Columns.Add("Remito", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

   Private Sub ImprimirContrato()

      Try

         Dim regAlquileres As Reglas.Alquileres = New Reglas.Alquileres
         Dim oAlquiler As Entidades.Alquiler = New Entidades.Alquiler

         oAlquiler = regAlquileres.GetUna(actual.Sucursal.IdSucursal, Long.Parse(Me.ugDetalle.ActiveCell.Row.Cells("NumeroContrato").Value.ToString()))

         Dim regClientes As Reglas.Clientes = New Reglas.Clientes()
         Dim oCliente As Entidades.Cliente

         oCliente = regClientes.GetUno(oAlquiler.IdCliente)

         Dim oProducto As Entidades.Producto = New Entidades.Producto
         oProducto = New Reglas.Productos().GetUno(oAlquiler.IdProducto)

         'Dim nombreLogo As String = Entidades.Publicos.DriverBase + "Eniac\LOGOEMPRESA.jpg"

         'Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()

         'If parI.GetValor(Entidades.ParametroImagen.Parametros.LOGOEMPRESA) Is Nothing Then
         '   MsgBox("ATENCION: NO tiene definido el LOGO de la Empresa, por favor carguelo en Parametros antes de Emitir el Contrato.", MsgBoxStyle.Exclamation)
         '   Exit Sub
         'End If

         'parI.GetValor(Entidades.ParametroImagen.Parametros.LOGOEMPRESA).Save(nombreLogo)


         'creo la coleccion de parametros
         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresa))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", actual.Sucursal.Nombre))

         'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Logo", nombreLogo))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NumeroContrato", oAlquiler.NumeroContrato.ToString()))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreCliente", oCliente.NombreCliente))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", oCliente.Direccion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CUIT", oCliente.Cuit))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", oCliente.Telefono & " " & oCliente.Celular))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("LocatarioNroDocumento", oAlquiler.LocatarioNroDocumento.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("LocatarioNombre", oAlquiler.LocatarioNombre))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("LocatarioCargo", oAlquiler.LocatarioCargo))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PersonalCapacitado", oAlquiler.PersonalCapacitado))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("LugarER", oAlquiler.LugarER))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("HoraE", oAlquiler.horaE))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("HoraR", oAlquiler.horaR))

         'With Me.dgvProductos.SelectedRows(0)
         '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("EquipoMarca", .Cells("EquipoMarca").Value.ToString))
         '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("EquipoModelo", .Cells("EquipoModelo").Value.ToString))
         '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NumeroSerie", .Cells("NumeroSerie").Value.ToString))
         '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CaractSII", .Cells("CaractSII").Value.ToString))
         '   parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("AnioProducto", .Cells("Anio").Value.ToString))
         'End With

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("EquipoMarca", oProducto.EquipoMarca))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("EquipoModelo", oProducto.EquipoModelo))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NumeroSerie", oProducto.NumeroSerie))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CaractSII", oProducto.CaractSII))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("AnioProducto", oProducto.Anio.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CantDias", oAlquiler.FechaRealFin.Date.Subtract(oAlquiler.FechaDesde.Date).TotalDays.ToString))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaDesde", oAlquiler.FechaDesde.ToShortDateString))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaHasta", oAlquiler.FechaRealFin.ToShortDateString))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Monto", oAlquiler.ImporteAlquiler.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaContrato", oAlquiler.FechaContrato.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("ImporteTraslado", oAlquiler.ImporteTraslado.ToString()))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Contrato.rdlc", parm, True, 1) '# 1 = Cantidad de Copias

         frmImprime.Text = "Contrato Locación"
         frmImprime.rvReporte.DocumentMapCollapsed = True
         frmImprime.Size = New Size(780, 600)
         frmImprime.StartPosition = FormStartPosition.CenterScreen
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, "Imprimir contrato", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

End Class