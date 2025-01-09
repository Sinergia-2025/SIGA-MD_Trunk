Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section

Public Class InfTotalClientesVentasPorVendedor

#Region "Campos"

   Private _publicos As Publicos
   Private _idEmpleado As Integer = 0
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1


         Me.cmbConComision.Items.Insert(0, "TODOS")
         Me.cmbConComision.Items.Insert(1, "SI")
         Me.cmbConComision.Items.Insert(2, "NO")
         Me.cmbConComision.SelectedIndex = 1       'SI

         Dim oMarca As Reglas.Marcas = New Reglas.Marcas()
         Me.cmbMarca.ValueMember = "IdMarca"
         Me.cmbMarca.DisplayMember = "NombreMarca"

         Me.cmbMarca.DataSource = oMarca.GetAll()
         Me.cmbMarca.SelectedIndex = -1

         Dim oRubro As Reglas.Rubros = New Reglas.Rubros()
         Me.cmbRubro.ValueMember = "IdRubro"
         Me.cmbRubro.DisplayMember = "NombreRubro"

         Me.cmbRubro.DataSource = oRubro.GetAll()
         Me.cmbRubro.SelectedIndex = -1

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         Me.chbUnificar.Enabled = Me.cmbSucursal.Enabled

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.chbSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If

         Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

         Me._publicos.CargaComboGrupos(Me.cmbGrupos)
         Me.cmbGrupos.SelectedIndex = -1

         Me._publicos.CargaComboDesdeEnum(cmbGrabanLibro, GetType(Entidades.Publicos.SiNoTodos))

         cmbTiposComprobantes.Initializar(False, "VENTAS")
         Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         '# Selecciono todos los tabs para que me tome las preferencias y las inicializo.
         Me.tbcComisionesVendedores.SelectedTab = tbpComprobantes
         Me.tbcComisionesVendedores.SelectedTab = tbpVendedores

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub


         Dim imprimirSolapaComprobantes As Boolean = Me.tbcComisionesVendedores.SelectedTab Is tbpComprobantes
         Dim Filtros As String = Me.CargarFiltrosImpresion

         Dim Titulo As String
         Dim texto As String = If(imprimirSolapaComprobantes, Me.Text + " (Comprobantes)", Me.Text)
         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + texto + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         Me.UltraGridPrintDocument1.Grid = If(imprimirSolapaComprobantes, Me.ugComprobantes, Me.ugDetalle)

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

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

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Vendedor aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbVendedor.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not (Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono) Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbZonaGeografica.Checked And cmbZonaGeografica.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Zona Geográfica aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbZonaGeografica.Focus()
            Exit Sub
         End If

         If Me.chbMarca.Checked And cmbMarca.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Marca aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbMarca.Focus()
            Exit Sub
         End If

         If Me.chbRubro.Checked And cmbRubro.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbRubro.Focus()
            Exit Sub
         End If

         If Me.chbSubRubro.Checked And cmbSubRubro.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Subrubro aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbSubRubro.Focus()
            Exit Sub
         End If

         If Me.chbTipoComprobante.Checked And cmbTiposComprobantes.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó un tipo de comprobante aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbTiposComprobantes.Focus()
            Exit Sub
         End If
         If Me.chbGrupo.Checked And Me.cmbGrupos.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO Informó el Grupo aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbGrupos.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbZonaGeografica.CheckedChanged

      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Not Me.chbZonaGeografica.Checked Then
         Me.cmbZonaGeografica.SelectedIndex = -1
      Else
         If Me.cmbZonaGeografica.Items.Count > 0 Then
            Me.cmbZonaGeografica.SelectedIndex = 0
         End If

         Me.cmbZonaGeografica.Focus()

      End If

   End Sub

   Private Sub chbMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If Me.chbMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chbMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chbMesCompleto.Checked

      Catch ex As Exception

         Me.chbMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked

      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged

      Me.cmbMarca.Enabled = Me.chbMarca.Checked

      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         If Me.cmbMarca.Items.Count > 0 Then
            Me.cmbMarca.SelectedIndex = 0
         End If
      End If

      Me.cmbMarca.Focus()

   End Sub

   Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged

      Me.cmbRubro.Enabled = Me.chbRubro.Checked

      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
      Else
         If Me.cmbRubro.Items.Count > 0 Then
            Me.cmbRubro.SelectedIndex = 0
         End If
      End If

      Me.cmbRubro.Focus()

   End Sub

   Private Sub chbSubRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbSubRubro.CheckedChanged
      Try
         Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

         If Not Me.chbSubRubro.Checked Then
            Me.cmbSubRubro.SelectedIndex = -1
         Else
            If Me.cmbSubRubro.Items.Count > 0 Then
               Me.cmbSubRubro.SelectedIndex = 0
            End If
         End If

         Me.cmbSubRubro.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If
      End If

      Me.cmbVendedor.Focus()

   End Sub

   Private Sub InfDetalleVentasPorVendedor_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("TipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreDeFantasia", System.Type.GetType("System.String"))

         .Columns.Add("IdClienteVinculado", GetType(Long))
         .Columns.Add("CodigoClienteVinculado", GetType(Long))
         .Columns.Add("NombreClienteVinculado", GetType(String))

         .Columns.Add("NombreZonaGeografica", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
         .Columns.Add("Direccion", System.Type.GetType("System.String"))
         .Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         .Columns.Add("NombreProvincia", System.Type.GetType("System.String"))
         .Columns.Add("FormaDePago", System.Type.GetType("System.String"))
         .Columns.Add("NombreVendedor", System.Type.GetType("System.String"))
         .Columns.Add("Subtotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("Usuario", System.Type.GetType("System.String"))
         .Columns.Add("FechaActualizacion", System.Type.GetType("System.DateTime"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
         .Columns.Add("NombreProveedor", System.Type.GetType("System.String"))
         .Columns.Add("ImportePesos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTickets", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteCheques", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTarjetas", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdCuentaBancaria", System.Type.GetType("System.Int32"))
         .Columns.Add("ImporteTransfBancaria", System.Type.GetType("System.Decimal"))
         .Columns.Add("NombreBanco", System.Type.GetType("System.String"))
         .Columns.Add("IVA", System.Type.GetType("System.Decimal"))
         .Columns.Add("Percepciones", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdPlanCuenta", GetType(Integer))
         .Columns.Add("IdAsiento", GetType(Long))
         .Columns.Add("NombreCategoria", System.Type.GetType("System.String"))
         .Columns.Add("CantidadInvocados", System.Type.GetType("System.Int32"))
         .Columns.Add("CantidadLotes", System.Type.GetType("System.Int32"))
         .Columns.Add("CAE", System.Type.GetType("System.String"))
         .Columns.Add("CAEVencimiento", System.Type.GetType("System.DateTime"))
         .Columns.Add("NombreCaja", System.Type.GetType("System.String"))
         .Columns.Add("NumeroPlanilla", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroMovimiento", System.Type.GetType("System.Int32"))
         .Columns.Add("MetodoGrabacion", System.Type.GetType("System.String"))
         .Columns.Add("IdFuncion", System.Type.GetType("System.String"))
         .Columns.Add("NumeroReparto", System.Type.GetType("System.Int32"))
         .Columns.Add("TotalImpuestoInterno", System.Type.GetType("System.Decimal"))
         .Columns.Add("CantidadContactos", System.Type.GetType("System.Int32"))
         .Columns.Add("NombresCentrosCosto", GetType(String))

         .Columns.Add("IdMoneda", GetType(Integer))
         .Columns.Add("NombreMoneda", GetType(String))
         .Columns.Add("Simbolo", GetType(String))
         .Columns.Add("CotizacionDolar", GetType(Decimal))
         .Columns.Add("FechaEnvioCorreo", GetType(DateTime))
         .Columns.Add("NroVersionAplicacion", GetType(String))
      End With

      Return dtTemp
   End Function

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

      Me.chbMesCompleto.Checked = False

      Me.chbCliente.Checked = False
      Me.bscCodigoCliente.Text = ""
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Text = ""

      Me.chbMarca.Checked = False
      Me.chbRubro.Checked = False
      Me.chbVendedor.Checked = False

      Me.cmbConComision.SelectedIndex = 1 'SI

      Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

      cmbSucursal.Refrescar()


      Me.chbTipoComprobante.Checked = False

      Me.cmbGrabanLibro.SelectedIndex = 0

      Me.chbGrupo.Checked = False
      Me.chbZonaGeografica.Checked = False
      Me.chbUnificar.Checked = True

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If
      If Not Me.ugComprobantes.DataSource Is Nothing Then
         DirectCast(Me.ugComprobantes.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oVenta As Reglas.Ventas = New Reglas.Ventas()

      Dim IdCliente As Long = 0

      Dim IdVendedor As Integer = 0

      Dim IdMarca As Integer = 0
      Dim IdRubro As Integer = 0
      Dim idSubRubro As Integer = 0

      Dim IdZonageografica As String = String.Empty
      Dim ConIVA As Boolean = False

      If Me.chbMarca.Checked Then
         IdMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
      End If

      If Me.chbRubro.Checked Then
         IdRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
      End If

      If Me.cmbSubRubro.Enabled Then
         idSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
      End If

      If Me.cmbZonaGeografica.Enabled Then
         IdZonageografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
      End If

      If chbConIVA.Checked Then
         ConIVA = True
      End If

      Dim Total As Decimal = 0
      Dim Comision As Decimal = 0
      Dim TipoComprobante As String = String.Empty
      Dim Grupo As String = String.Empty
      Dim fechaDesde As DateTime = Me.dtpDesde.Value
      Dim fechaHasta As DateTime = Me.dtpHasta.Value
      Dim conComision As String = Me.cmbConComision.Text
      Dim grabaLibro As String = Me.cmbGrabanLibro.Text

      Me.chkExpandAll.Enabled = True

      Try
         If chbCliente.Checked Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If


         If Me.chbVendedor.Checked Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         Dim tiposComprobantes As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)()
         tiposComprobantes.AddRange(cmbTiposComprobantes.GetTiposComprobantes())

         If Me.chbGrupo.Checked Then
            Grupo = Me.cmbGrupos.SelectedValue.ToString()
         End If

         '# Cargo la grilla agrupada por vendedores
         Me.ugDetalle.DataSource = oVenta.GetComisionesTotalesClientesPorVendedor(Me.cmbSucursal.GetSucursales(), _
                                                                 fechaDesde, fechaHasta, _
                                                                 conComision, Me.chbUnificar.Checked, _
                                                                 IdVendedor,
                                                                 IdCliente, _
                                                                 IdMarca, _
                                                                 IdRubro, idSubRubro, _
                                                                 IdZonageografica, _
                                                                 ConIVA,
                                                                 tiposComprobantes,
                                                                 grabaLibro,
                                                                 Grupo)

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Me.chbUnificar.Checked
         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreCliente", "NombreLocalidad", "NombreEmpleado", "NombreZonaGeografica", "NombreProvincia"})
         Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"Total", "Comision"})

         '# Cargo la grilla de Comprobantes
         Me.ugComprobantes.DataSource = oVenta.GetComprobantesTotalesClientesPorVendedor(Me.cmbSucursal.GetSucursales(),
                                                                                             Me.dtpDesde.Value,
                                                                                             Me.dtpHasta.Value,
                                                                                             IdVendedor,
                                                                                             ConIVA,
                                                                                             conComision,
                                                                                             IdCliente,
                                                                                             IdMarca,
                                                                                             IdRubro,
                                                                                             idSubRubro,
                                                                                             IdZonageografica,
                                                                                             tiposComprobantes,
                                                                                             grabaLibro,
                                                                                             Grupo)

         '# Totalizo la columna Comisión
         Me.ugComprobantes.AgregarTotalesSuma({"Comision"})

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub


   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         If Me.cmbSucursal.Enabled Then
            Me.cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=False, muestraNombre:=True)
            .AppendFormat(" - ")
         End If

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         If Me.cmbConComision.Text <> "TODOS" Then
            .AppendFormat(" Con Comisión: {0} - ", Me.cmbConComision.Text)
         End If

         If Me.chbConIVA.Checked Then
            .AppendFormat("Con IVA - ")
         End If

         If Me.chbCliente.Checked Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.chbVendedor.Checked Then
            .AppendFormat(" Vendedor: {0} - ", Me.cmbVendedor.Text)
         End If

         If Me.chbZonaGeografica.Checked Then
            .AppendFormat(" Zona Geografica: {0} - ", Me.cmbZonaGeografica.Text)
         End If

         If Me.chbMarca.Checked Then
            .AppendFormat(" Marca: {0} -", Me.cmbMarca.Text)
         End If

         If Me.chbRubro.Checked Then
            .AppendFormat(" Rubro: {0} -", Me.cmbRubro.Text)
         End If

         If Me.chbSubRubro.Checked Then
            .AppendFormat(" SubRubro: {0} -", Me.cmbSubRubro.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function
   Private Sub chbGrupo_CheckedChanged(sender As Object, e As EventArgs) Handles chbGrupo.CheckedChanged
      Try
         Me.cmbGrupos.Enabled = Me.chbGrupo.Checked

         If Not Me.chbGrupo.Checked Then
            Me.cmbGrupos.SelectedIndex = -1
         Else
            If Me.cmbGrupos.Items.Count > 0 Then
               Me.cmbGrupos.SelectedIndex = 0
            End If
         End If

         Me.cmbGrupos.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
         Else
            Me.cmbTiposComprobantes.SelectedIndex = -1
            Me.cmbTiposComprobantes.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         If Me.tbcComisionesVendedores.SelectedTab Is tbpVendedores Then
            Me.PreferenciasCargar(Me.ugDetalle, Me.ugDetalle.Name, tsbPreferencias)
         Else
            Me.PreferenciasCargar(Me.ugComprobantes, ugComprobantes.Name, tsbPreferencias)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim solapaComprobantes As Boolean = Me.tbcComisionesVendedores.SelectedTab Is tbpComprobantes

         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim r As New Report()
               Dim sec As ISection = r.AddSection()
               sec.AddText.AddContent(Publicos.NombreEmpresaImpresion + System.Environment.NewLine)
               sec.AddText.AddContent(If(solapaComprobantes, Me.Text + " (Comprobantes)", Me.Text) + System.Environment.NewLine)
               sec.AddText.AddContent(Me.CargarFiltrosImpresion() + System.Environment.NewLine + System.Environment.NewLine)
               '# Elijo qué grilla exportar según la solapa seleccionada
               Me.UltraGridDocumentExporter1.Export(If(solapaComprobantes, Me.ugComprobantes, Me.ugDetalle), sec)
               r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim solapaComprobantes As Boolean = Me.tbcComisionesVendedores.SelectedTab Is tbpComprobantes

         Dim myWorkbook As New Workbook
         Dim myWorksheet As Worksheet
         myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Publicos.NombreEmpresaImpresion
         myWorksheet.Rows(1).Cells(0).Value = If(solapaComprobantes, Me.Text + " (Comprobantes)", Me.Text)
         myWorksheet.Rows(2).Cells(0).Value = Me.CargarFiltrosImpresion()

         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               '# Elijo qué grilla exportar según la solapa seleccionada
               Me.UltraGridExcelExporter1.Export(If(solapaComprobantes, Me.ugComprobantes, Me.ugDetalle), myWorksheet, 4, 0)
               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
 

   Private Sub tsbImprimirPrediseñado_Click(sender As Object, e As EventArgs) Handles tsbImprimirPrediseñado.Click
      Dim imprimirSolapaComprobantes As Boolean = Me.tbcComisionesVendedores.SelectedTab Is tbpComprobantes

      If imprimirSolapaComprobantes Then
         If Me.ugComprobantes.Rows.Count = 0 Then Exit Sub
      Else
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
      End If

      Try
         Me.Cursor = Cursors.WaitCursor

         Dim Filtros As String = CargarFiltrosImpresion()

         Dim dt As DataTable
         If Not imprimirSolapaComprobantes Then
            dt = DirectCast(Me.ugDetalle.DataSource, DataTable)
         Else
            dt = DirectCast(Me.ugComprobantes.DataSource, DataTable)
         End If

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes
         If Not imprimirSolapaComprobantes Then
            frmImprime = New VisorReportes("Eniac.Win.InfTotalClientesVentasPorVendedor.rdlc", "SistemaDataSet_InfTotalClientesVentasPorVendedor", dt, parm, True, 1) '# 1 = Cantidad Copias
         Else
            frmImprime = New VisorReportes("Eniac.Win.InfTotalComprobantesVentasPorVendedor.rdlc", "SistemaDataSet_InfTotalComprobantesVentasPorVendedor", dt, parm, True, 1) '# 1 = Cantidad Copias
         End If

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.DisplayModeInicial = Microsoft.Reporting.WinForms.DisplayMode.PrintLayout
         frmImprime.rvReporte.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugComprobantes_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugComprobantes.ClickCellButton

      If Me.ugComprobantes.Rows.Count = 0 Then Exit Sub

      Try
         Dim rVentas As Reglas.Ventas = New Reglas.Ventas
         Dim venta As Entidades.Venta = rVentas.GetUna(Integer.Parse(Me.ugComprobantes.Rows(e.Cell.Row.Index).Cells("IdSucursal").Value.ToString()), _
                              Me.ugComprobantes.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(), _
                              Me.ugComprobantes.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(), _
                              Short.Parse(Me.ugComprobantes.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()), _
                              Long.Parse(Me.ugComprobantes.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))


         Dim oImpr As Impresion = New Impresion(venta)
         If venta.Impresora.TipoImpresora = "NORMAL" Then
            oImpr.ImprimirComprobanteNoFiscal(Visualizar:=True, UtilizarComprobanteEstandar:=False)

            'If venta.Percepciones IsNot Nothing Then
            '   For Each perc As Entidades.PercepcionVenta In venta.Percepciones
            '      If perc.ImporteTotal <> 0 Then
            '         Dim ret As PercepcionImprimir = New PercepcionImprimir()
            '         ret.ImprimirPercepcion(venta, perc)
            '      End If
            '   Next
            'End If

         Else
            oImpr.ReImprimirComprobanteFiscal()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tbcComisionesVendedores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcComisionesVendedores.SelectedIndexChanged

      Dim solapaComprobantes As Boolean = tbcComisionesVendedores.SelectedTab Is tbpComprobantes
      If Not solapaComprobantes Then
         PreferenciasLeer(grid:=ugDetalle, sufijoXML:=ugDetalle.Name.ToString(), tsbPreferencias:=tsbPreferencias)
      Else
         PreferenciasLeer(grid:=ugComprobantes, sufijoXML:=ugComprobantes.Name.ToString(), tsbPreferencias:=tsbPreferencias)
      End If

   End Sub
End Class