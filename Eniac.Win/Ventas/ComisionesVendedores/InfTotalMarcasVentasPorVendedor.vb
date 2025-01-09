Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section

Public Class InfTotalMarcasVentasPorVendedor

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

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1

         
         Me.cmbConComision.Items.Insert(0, "TODOS")
         Me.cmbConComision.Items.Insert(1, "SI")
         Me.cmbConComision.Items.Insert(2, "NO")
         Me.cmbConComision.SelectedIndex = 1       'SI

         Dim oMarca As Reglas.Marcas = New Reglas.Marcas()
         'Me.cmbMarca.ValueMember = "IdMarca"
         'Me.cmbMarca.DisplayMember = "NombreMarca"

         'Me.cmbMarca.DataSource = oMarca.GetAll()
         'Me.cmbMarca.SelectedIndex = -1

         'Dim oRubro As Reglas.Rubros = New Reglas.Rubros()
         'Me.cmbRubro.ValueMember = "IdRubro"
         'Me.cmbRubro.DisplayMember = "NombreRubro"

         'Me.cmbRubro.DataSource = oRubro.GetAll()
         'Me.cmbRubro.SelectedIndex = -1

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me.cmbZonaGeografica.SelectedIndex = -1

         ' Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         Me.chbUnificar.Enabled = Me.cmbSucursal.Enabled

         'If Not Reglas.Publicos.ProductoTieneSubRubro Then
         '   Me.chbSubRubro.Visible = False
         '   Me.cmbSubRubro.Visible = False
         'End If

         Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

         Me._publicos.CargaComboGrupos(Me.cmbGrupos)
         Me.cmbGrupos.SelectedIndex = -1

         Me._publicos.CargaComboDesdeEnum(cmbGrabanLibro, GetType(Entidades.Publicos.SiNoTodos))

         cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         pnlSubRubros.Visible = Reglas.Publicos.ProductoTieneSubRubro

         _publicos.CargaComboListaPreciosVentas(Me.cmbListaPrecios)
         _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")
         cmbFormaPago.SelectedIndex = -1

         cmbTiposComprobantes.Initializar(False, "VENTAS")
         Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

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

         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = Me.CargarFiltrosImpresion

         Dim dt As DataTable

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.InfTotalMarcasVentasPorVendedor.rdlc", "dsVentas_InfTotalMarcasVentasPorVendedor", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
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

         'If Me.chbMarca.Checked And cmbMarca.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: NO seleccionó una Marca aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.cmbMarca.Focus()
         '   Exit Sub
         'End If

         'If Me.chbRubro.Checked And cmbRubro.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.cmbRubro.Focus()
         '   Exit Sub
         'End If

         'If Me.chbSubRubro.Checked And cmbSubRubro.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: NO seleccionó un Subrubro aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.cmbSubRubro.Focus()
         '   Exit Sub
         'End If

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

         If dgvDetalle.Rows.Count > 0 Then
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

   'Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

   '   Me.cmbMarca.Enabled = Me.chbMarca.Checked

   '   If Not Me.chbMarca.Checked Then
   '      Me.cmbMarca.SelectedIndex = -1
   '   Else
   '      If Me.cmbMarca.Items.Count > 0 Then
   '         Me.cmbMarca.SelectedIndex = 0
   '      End If
   '   End If

   '   Me.cmbMarca.Focus()

   'End Sub

   'Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

   '   Me.cmbRubro.Enabled = Me.chbRubro.Checked

   '   If Not Me.chbRubro.Checked Then
   '      Me.cmbRubro.SelectedIndex = -1
   '   Else
   '      If Me.cmbRubro.Items.Count > 0 Then
   '         Me.cmbRubro.SelectedIndex = 0
   '      End If
   '   End If

   '   Me.cmbRubro.Focus()

   'End Sub

   'Private Sub chbSubRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
   '   Try
   '      Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

   '      If Not Me.chbSubRubro.Checked Then
   '         Me.cmbSubRubro.SelectedIndex = -1
   '      Else
   '         If Me.cmbSubRubro.Items.Count > 0 Then
   '            Me.cmbSubRubro.SelectedIndex = 0
   '         End If
   '      End If

   '      Me.cmbSubRubro.Focus()
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try

   'End Sub
   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged
      TryCatched(Sub() chbFormaPago.FiltroCheckedChanged(cmbFormaPago))
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

   Private Sub cmbRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim rubros = cmbRubros.GetRubros(todosVacio:=True)
                    cmbSubRubros.ConcatenarNombreRubro = rubros.CountSecure() <> 1
                    cmbSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                             rubros:=rubros)
                 End Sub)
   End Sub
   Private Sub cmbSubRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim subRubros = cmbSubRubros.GetSubRubros(todosVacio:=True)
                 End Sub)

   End Sub

   Private Sub chbListaPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaPrecios.CheckedChanged
      Try
         Me.cmbListaPrecios.Enabled = Me.chbListaPrecios.Checked

         If Not Me.chbListaPrecios.Checked Then
            Me.cmbListaPrecios.SelectedIndex = -1
         Else
            Me.cmbListaPrecios.SelectedIndex = 0
            Me.cmbListaPrecios.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

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

      'Me.chbMarca.Checked = False
      'Me.chbRubro.Checked = False

      cmbMarcas.Refrescar()
      cmbRubros.Refrescar()
      cmbSubRubros.Refrescar()

      Me.chbVendedor.Checked = False

      Me.cmbConComision.SelectedIndex = 1 'SI

      Me.chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

      cmbSucursal.Refrescar()


      Me.chbTipoComprobante.Checked = False

      Me.cmbGrabanLibro.SelectedIndex = 0

      Me.chbGrupo.Checked = False

      Me.chbUnificar.Checked = True
      Me.chbListaPrecios.Checked = False
      Me.chbFormaPago.Checked = False


      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
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

      'If Me.chbMarca.Checked Then
      '   IdMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
      'End If

      'If Me.chbRubro.Checked Then
      '   IdRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
      'End If

      'If Me.cmbSubRubro.Enabled Then
      '   idSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
      'End If

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
      Dim listaPrecios As Integer = 0

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

         Dim idFormaDePago = If(cmbFormaPago.Enabled, cmbFormaPago.ValorSeleccionado(Of Integer), 0)

         If Me.cmbListaPrecios.Enabled Then
            listaPrecios = Integer.Parse(Me.cmbListaPrecios.SelectedValue.ToString())
         End If

         Me.dgvDetalle.DataSource = oVenta.GetComisionesTotalesMarcasPorVendedor(Me.cmbSucursal.GetSucursales(),
                                                                 Me.dtpDesde.Value, Me.dtpHasta.Value,
                                                                 Me.cmbConComision.Text, Me.chbUnificar.Checked,
                                                                 IdVendedor,
                                                                 IdCliente,
                                                                 cmbMarcas.GetMarcas(todosVacio:=True),
                                                                 cmbRubros.GetRubros(todosVacio:=True),
                                                                 cmbSubRubros.GetSubRubros(todosVacio:=True),
                                                                 IdZonageografica,
                                                                 ConIVA,
                                                                 tiposComprobantes,
                                                                 Me.cmbGrabanLibro.Text,
                                                                 Grupo,
                                                                 idFormaDePago,
                                                                 listaPrecios)

         Me.dgvDetalle.Columns("IdSucursal").Visible = Not Me.chbUnificar.Checked

         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
            Total += Decimal.Parse(dr.Cells("Total").Value.ToString())
            Comision += Decimal.Parse(dr.Cells("Comision").Value.ToString())
         Next

         Me.txtTotal.Text = Total.ToString("##,##0.00")
         Me.txtTotalComision.Text = Comision.ToString("##,##0.00")

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

         If cmbMarcas.Visible Then cmbMarcas.CargarFiltrosImpresionMarcas(filtro, muestraId:=True, muestraNombre:=False)
         If cmbRubros.Visible Then cmbRubros.CargarFiltrosImpresionRubros(filtro, muestraId:=True, muestraNombre:=False)
         If cmbSubRubros.Visible Then cmbSubRubros.CargarFiltrosImpresionSubRubros(filtro, muestraId:=True, muestraNombre:=False)

         'If Me.chbMarca.Checked Then
         '   .AppendFormat(" Marca: {0} -", Me.cmbMarca.Text)
         'End If

         'If Me.chbRubro.Checked Then
         '   .AppendFormat(" Rubro: {0} -", Me.cmbRubro.Text)
         'End If

         'If Me.chbSubRubro.Checked Then
         '   .AppendFormat(" SubRubro: {0} -", Me.cmbSubRubro.Text)
         'End If
         If Me.cmbFormaPago.SelectedIndex >= 0 Then
            .AppendFormat(" Forma de Pago: {0} -", Me.cmbFormaPago.SelectedText)
         End If
         If Me.cmbListaPrecios.SelectedIndex >= 0 Then
            .AppendFormat(" Lista de Precios: {0} -", Me.cmbListaPrecios.Text)
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


End Class