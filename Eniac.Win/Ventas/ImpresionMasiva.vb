#Region "Option/Imports"
Option Explicit On
Option Strict On
#End Region
Public Class ImpresionMasiva

   Private _publicos As Publicos
   Public ConsultarAutomaticamente As Boolean = False
   Private _numeroReparto As Integer
   Private _numeroRepartoHasta As Integer
   Private _impreso As Entidades.Publicos.SiNoTodos
   Private _fechaDesde As DateTime?
   Private _fechaHasta As DateTime?
   Private _modoAutomatico As Boolean
   Public NroRepartoInvocacion As Integer = 0

#Region "Constructores"
   Public Sub New()
      Me.InitializeComponent()
      _impreso = Entidades.Publicos.SiNoTodos.NO
   End Sub

   Public Sub New(numeroReparto As Integer, numeroRepartoHasta As Integer, impreso As Entidades.Publicos.SiNoTodos,
                  fechaDesde As DateTime, fechaHasta As DateTime)

      Me.New()

      _numeroReparto = numeroReparto
      _numeroRepartoHasta = numeroRepartoHasta
      _impreso = impreso
      _fechaDesde = fechaDesde
      _fechaHasta = fechaHasta
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = If(_fechaDesde.HasValue, _fechaDesde.Value, Date.Today)
         Me.dtpHasta.Value = If(_fechaHasta.HasValue, _fechaHasta.Value, Date.Today.UltimoSegundoDelDia())

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS")
         Me.cmbTiposComprobantes.SelectedIndex = -1

         _publicos.CargaComboDesdeEnum(cmbImpreso, GetType(Entidades.Publicos.SiNoTodos))
         'Me.cmbImpreso.SelectedIndex = 1   'No Impresos
         Me.cmbImpreso.SelectedValue = _impreso

         Me.cmbEstadoComprobante.Items.Insert(0, "PENDIENTE")
         Me.cmbEstadoComprobante.Items.Insert(1, "FACTURADO")
         Me.cmbEstadoComprobante.Items.Insert(2, "ANULADO")
         Me.cmbEstadoComprobante.Items.Insert(3, "NO ANULADO")
         Me.cmbEstadoComprobante.SelectedIndex = -1

         Me.cmbGrabanLibro.Items.Insert(0, "TODOS")
         Me.cmbGrabanLibro.Items.Insert(1, "SI")
         Me.cmbGrabanLibro.Items.Insert(2, "NO")
         Me.cmbGrabanLibro.SelectedIndex = 0

         Me.cmbAfectaCaja.Items.Insert(0, "TODOS")
         Me.cmbAfectaCaja.Items.Insert(1, "SI")
         Me.cmbAfectaCaja.Items.Insert(2, "NO")
         Me.cmbAfectaCaja.SelectedIndex = 0

         _publicos.CargaComboDesdeEnum(cmbExportado, GetType(Entidades.Publicos.SiNoTodos))

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1
         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)
         cmbCategoria.Inicializar(False)
         _publicos.CargaComboDesdeEnum(cmbOrigenCategoria, GetType(Entidades.OrigenFK))
         cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual

         Me.RefrescarDatos()

         If ConsultarAutomaticamente Then
            If _numeroReparto = 0 And _numeroRepartoHasta = 0 Then
               Me.btnConsultar.PerformClick()
            Else
               Me.chbNumeroRep.Checked = True
               Me.txtNroReparto.Text = Me._numeroReparto.ToString()
               Me.txtNroRepartoHasta.Text = Me._numeroRepartoHasta.ToString()
               Me.btnConsultar.PerformClick()
            End If

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ImpresionMasiva_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar.PerformClick()
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.RefrescarDatos()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try
         If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         If Integer.Parse("0" & Me.txtNroHasta.Text) > 0 And Integer.Parse("0" & Me.txtNroHasta.Text) - Integer.Parse("0" & Me.txtNroDesde.Text) + 1 <> Me.dgvDetalle.RowCount Then

            Dim intDiferencia As Integer = Integer.Parse("0" & Me.txtNroHasta.Text) - Integer.Parse("0" & Me.txtNroDesde.Text) + 1 - Me.dgvDetalle.RowCount

            If MessageBox.Show("ATENCION: Existe una diferencia de " & intDiferencia.ToString() & " entre el rango seleccionado y el Rango en pantalla, ¿ Esta Seguro de Continuar ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
               Me.txtNroDesde.Focus()
               Exit Sub
            End If

         End If

         Me.tssInfo.Text = "Imprimiendo..."
         Me.tspBarra.Visible = True
         Me.tspBarra.Value = 0
         Me.Imprimir()
         Me.tspBarra.Value = 0
         Me.btnConsultar.PerformClick()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.tspBarra.Visible = False
         Me.tssInfo.Text = String.Empty
      End Try
   End Sub

   Private Sub tsbExportar_Click(sender As Object, e As EventArgs) Handles tsbExportar.Click
      Try
         If Me.dgvDetalle.RowCount = 0 Then Exit Sub
         If Integer.Parse("0" & Me.txtNroHasta.Text) > 0 And Integer.Parse("0" & Me.txtNroHasta.Text) - Integer.Parse("0" & Me.txtNroDesde.Text) + 1 <> Me.dgvDetalle.RowCount Then
            Dim intDiferencia As Integer = Integer.Parse("0" & Me.txtNroHasta.Text) - Integer.Parse("0" & Me.txtNroDesde.Text) + 1 - Me.dgvDetalle.RowCount
            If MessageBox.Show("ATENCION: Existe una diferencia de " & intDiferencia.ToString() & " entre el rango seleccionado y el Rango en pantalla, ¿ Esta Seguro de Continuar ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
               Me.txtNroDesde.Focus()
               Exit Sub
            End If
         End If

         Me.tssInfo.Text = "Exportando..."
         Me.tspBarra.Visible = True
         Me.tspBarra.Value = 0
         Me.Exportar()
         Me.tspBarra.Value = 0
         Me.btnConsultar.PerformClick()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.tspBarra.Visible = False
         Me.tssInfo.Text = String.Empty
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

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged
      Try
         Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
         Me.bscCliente.Enabled = Me.chbCliente.Checked

         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = String.Empty

         Me.bscCodigoCliente.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, True)
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
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
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

   Private Sub chbEstado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbEstadoComprobante.CheckedChanged

      Try
         Me.cmbEstadoComprobante.Enabled = Me.chbEstadoComprobante.Checked

         If Not Me.chbEstadoComprobante.Checked Then
            Me.cmbEstadoComprobante.SelectedIndex = -1
         Else
            If Me.cmbEstadoComprobante.Items.Count > 0 Then
               Me.cmbEstadoComprobante.SelectedIndex = 0
            End If
         End If

         Me.cmbEstadoComprobante.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked
         'Me.cmbLetras.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            Me.cmbTiposComprobantes.SelectedIndex = -1
            'Me.cmbLetras.SelectedIndex = -1
         Else
            If Me.cmbTiposComprobantes.Items.Count > 0 Then
               Me.cmbTiposComprobantes.SelectedIndex = 0
            End If
         End If

         Me.cmbTiposComprobantes.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbLetra_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLetra.CheckedChanged
      Try
         Me.cmbLetras.Enabled = Me.chbLetra.Checked

         If Not Me.chbLetra.Checked Then
            Me.cmbLetras.SelectedIndex = -1
         Else
            If Me.cmbLetras.Items.Count > 0 Then
               Me.cmbLetras.SelectedIndex = 0
            End If
         End If

         Me.chbLetra.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
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

   Private Sub chbFormaPago_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFormaPago.CheckedChanged

      Try
         Me.cmbFormaPago.Enabled = Me.chbFormaPago.Checked

         If Not Me.chbFormaPago.Checked Then
            Me.cmbFormaPago.SelectedIndex = -1
         Else
            If Me.cmbFormaPago.Items.Count > 0 Then
               Me.cmbFormaPago.SelectedIndex = 0
            End If
         End If

         Me.cmbFormaPago.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("No seleccionó un Cliente aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("No hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub dgvDetalle_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
      Dim ventas As Reglas.Ventas
      Dim venta As Entidades.Venta
      Dim idSucursal As Integer
      Dim idTipoComprobante As String
      Dim letra As String
      Dim centroEmisor As Short
      Dim numeroComprobante As Integer
      Dim dr As DataGridViewRow

      Try

         If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         If Me.dgvDetalle.SelectedRows.Count = 0 Then Exit Sub

         If e.RowIndex <> -1 Then

            dr = Me.dgvDetalle.Rows(e.RowIndex)

            If dr.Cells(e.ColumnIndex).OwningColumn.Name = "colVer" Then

               Me.Cursor = Cursors.WaitCursor

               ventas = New Reglas.Ventas()

               idSucursal = Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal
               idTipoComprobante = dr.Cells("IdTipoComprobante").Value.ToString()
               letra = dr.Cells("Letra").Value.ToString()
               centroEmisor = Short.Parse(dr.Cells("CentroEmisor").Value.ToString())
               numeroComprobante = Int32.Parse(dr.Cells("NumeroComprobante").Value.ToString())

               venta = ventas.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

               Dim oImpr As Impresion = New Impresion(venta)

               If dr.Cells("TipoImpresora").Value.ToString() = "NORMAL" Then
                  oImpr.ImprimirComprobanteNoFiscal(True)
               Else
                  oImpr.ReImprimirComprobanteFiscal()
               End If

               Me.btnConsultar.PerformClick()

            End If

         End If
      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.MarcarTodos()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Friend Sub MarcarTodos()
      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         dr.Cells("Imprime").Value = Me.chbTodos.Checked
      Next
   End Sub

   Private Sub chbNumeroRep_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroRep.CheckedChanged
      txtNroReparto.Enabled = chbNumeroRep.Checked
      txtNroRepartoHasta.Enabled = chbNumeroRep.Checked
      If Not Me.chbNumeroRep.Checked Then
         txtNroReparto.Text = ""
         txtNroRepartoHasta.Text = ""
      Else
         Me.txtNroReparto.Focus()
      End If
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

   Private Sub RefrescarDatos()

      Me.chkMesCompleto.Checked = False

      Me.dtpDesde.Value = If(_fechaDesde.HasValue, _fechaDesde.Value, Date.Today)
      Me.dtpHasta.Value = If(_fechaHasta.HasValue, _fechaHasta.Value, Date.Today.UltimoSegundoDelDia())

      'Me.cmbImpreso.SelectedIndex = 1   'No Impresos
      Me.cmbImpreso.SelectedValue = _impreso

      Me.chbCliente.Checked = False
      Me.chbEstadoComprobante.Checked = False

      Me.chbTipoComprobante.Checked = False
      Me.chbLetra.Checked = False

      Me.cmbLetras.SelectedIndex = -1
      Me.txtEmisor.Text = String.Empty
      Me.txtNroDesde.Text = String.Empty
      Me.txtNroHasta.Text = String.Empty

      Me.cmbGrabanLibro.SelectedIndex = 0
      Me.cmbAfectaCaja.SelectedIndex = 0

      Me.chbVendedor.Checked = False
      Me.chbUsuario.Checked = False
      Me.chbFormaPago.Checked = False
      Me.chbNumeroRep.Checked = False

      If Me.dgvDetalle.DataSource IsNot Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.chbTodos.Checked = False
      Me.chbOrdenInverso.Checked = Reglas.Publicos.Facturacion.Impresion.ImpresionMasivaOrdenInverso

      cmbCategoria.Refrescar()
      Me.cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual
      Me.cmbExportado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      Me.dtpDesde.Focus()

   End Sub

   Friend Sub CargaGrillaDetalle()

      Try

         Dim oVenta As Reglas.Ventas = New Reglas.Ventas()

         Dim fechaDesde As Date
         Dim fechaHasta As Date

         Dim Orden As String

         Dim IdCliente As Long = 0

         Dim IdEstadoComprobante As String = String.Empty

         Dim idTipoComprobante As String = String.Empty
         Dim nroDesde As Long
         Dim nroHasta As Long
         Dim emisor As Short

         Dim IdVendedor As Integer = 0

         Dim IdFormasPago As Integer = 0
         Dim IdUsuario As String = String.Empty
         Dim NumeroReparto As Integer = 0
         Dim NumeroRepartoHasta As Integer = 0

         fechaDesde = Me.dtpDesde.Value
         fechaHasta = Me.dtpHasta.Value

         Dim impreso As Entidades.Publicos.SiNoTodos = cmbImpreso.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()

         Orden = IIf(Me.chbOrdenInverso.Checked, "DESC", "ASC").ToString()

         If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbEstadoComprobante.Enabled Then
            IdEstadoComprobante = Me.cmbEstadoComprobante.Text
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            idTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Not String.IsNullOrEmpty(Me.txtNroDesde.Text.Trim()) Then
            nroDesde = Long.Parse(Me.txtNroDesde.Text.Trim())
         End If

         If Not String.IsNullOrEmpty(Me.txtNroHasta.Text.Trim()) Then
            nroHasta = Long.Parse(Me.txtNroHasta.Text.Trim())
         End If

         If Not String.IsNullOrEmpty(Me.txtEmisor.Text.Trim()) Then
            emisor = Short.Parse(Me.txtEmisor.Text.Trim())
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.cmbFormaPago.Enabled Then
            IdFormasPago = Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
         End If

         If Me.cmbUsuario.Enabled Then
            'IdUsuario = DirectCast(Me.cmbUsuario.SelectedItem, Entidades.Usuario).Usuario
            IdUsuario = Me.cmbUsuario.SelectedValue.ToString()
         End If

         If Me.txtNroReparto.Enabled Then
            NumeroReparto = Integer.Parse(Me.txtNroReparto.Text.ToString())
            NumeroRepartoHasta = Integer.Parse(Me.txtNroRepartoHasta.Text.ToString())
         End If

         Dim dtDetalle As DataTable

         dtDetalle = oVenta.GetParaImpresionMasiva(Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal,
                                                   fechaDesde,
                                                   fechaHasta,
                                                   impreso,
                                                   Orden,
                                                   IdCliente,
                                                   idTipoComprobante,
                                                   Me.cmbLetras.Text,
                                                   emisor,
                                                   nroDesde,
                                                   nroHasta,
                                                   IdEstadoComprobante,
                                                   Me.cmbGrabanLibro.Text,
                                                   Me.cmbAfectaCaja.Text,
                                                   IdVendedor,
                                                   IdFormasPago,
                                                   IdUsuario, NumeroReparto, NumeroRepartoHasta,
                                                   cmbCategoria.GetCategorias(True),
                                                   DirectCast(cmbOrigenCategoria.SelectedValue, Entidades.OrigenFK),
                                                   cmbExportado.Text,
                                                   NroRepartoInvocacion)

         Dim dt As DataTable
         Dim drCl As DataRow

         dt = Me.CrearDT()

         'No Impresos
         Me.chbTodos.Checked = (Me.cmbImpreso.SelectedIndex = 2 And dtDetalle.Rows.Count > 0)

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            'If dr("TipoImpresora").ToString() = "NORMAL" Then
            drCl("Imprime") = Me.chbTodos.Checked
            'Else
            '   drCl("Ver") = "( F )"
            'End If

            drCl("TipoImpresora") = dr("TipoImpresora").ToString()
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("DescripcionAbrev") = dr("DescripcionAbrev").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())

            If dr("IdEstadoComprobante").ToString() <> "ANULADO" Then
               drCl("NombreCliente") = dr("NombreCliente").ToString()
            Else
               drCl("NombreCliente") = "** COMPROBANTE ANULADO **"
            End If

            drCl("NombreVendedor") = dr("NombreVendedor")

            drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal").ToString()
            drCl("FormaDePago") = dr("FormaDePago").ToString()

            drCl("SubTotal") = Decimal.Parse(dr("SubTotal").ToString())
            drCl("TotalImpuestos") = Decimal.Parse(dr("TotalImpuestos").ToString())
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())

            If Not String.IsNullOrEmpty(dr("FechaImpresion").ToString()) Then
               drCl("FechaImpresion") = Date.Parse(dr("FechaImpresion").ToString())
            End If

            dt.Rows.Add(drCl)

         Next

         Me.dgvDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Imprime", System.Type.GetType("System.Boolean"))
         .Columns.Add("TipoImpresora", System.Type.GetType("System.String"))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAbrev", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("IdCliente", System.Type.GetType("System.String"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreVendedor", GetType(String))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
         .Columns.Add("FormaDePago", System.Type.GetType("System.String"))
         .Columns.Add("SubTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("FechaImpresion", System.Type.GetType("System.DateTime"))
      End With

      Return dtTemp

   End Function

   Private Sub Imprimir()

      Dim total As Integer
      Dim progreso As Integer
      Dim venta As Entidades.Venta
      Dim ventas As Reglas.Ventas
      Dim idSucursal As Integer
      Dim idTipoComprobante As String
      Dim letra As String
      Dim centroEmisor As Short
      Dim numeroComprobante As Long
      Dim imp As Impresion

      ventas = New Reglas.Ventas()
      total = 0

      Me.dgvDetalle.EndEdit()
      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         If Boolean.Parse(dr.Cells("Imprime").Value.ToString()) Then
            total += 1
         End If
      Next

      If total = 0 Then
         MessageBox.Show("No se indicaron comprobantes para Imprimir.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      progreso = 0

      Me.tspBarra.Maximum = total
      Me.tspBarra.Value = progreso

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows

         If Boolean.Parse(dr.Cells("Imprime").Value.ToString()) Then

            progreso += 1
            Me.tspBarra.Value = progreso
            Me.tssInfo.Text = "Imprimiendo... " + progreso.ToString() + " de " + total.ToString()

            System.Windows.Forms.Application.DoEvents()

            idSucursal = Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal
            idTipoComprobante = dr.Cells("IdTipoComprobante").Value.ToString()
            letra = dr.Cells("Letra").Value.ToString()
            centroEmisor = Short.Parse(dr.Cells("CentroEmisor").Value.ToString())
            numeroComprobante = Long.Parse(dr.Cells("NumeroComprobante").Value.ToString())

            venta = ventas.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

            imp = New Impresion(venta)

            imp.ImprimirComprobanteNoFiscal(False)

         End If
      Next

      MessageBox.Show("Se imprimieron " + progreso.ToString() + " comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

   End Sub

   Friend Sub Exportar()
      Exportar(raizDestino:=Nothing, silentMode:=False)
   End Sub

   Friend Sub Exportar(raizDestino As String, silentMode As Boolean)

      Dim total As Integer
      Dim progreso As Integer
      Dim venta As Entidades.Venta
      Dim ventas As Reglas.Ventas
      Dim idSucursal As Integer
      Dim idTipoComprobante As String
      Dim letra As String
      Dim centroEmisor As Short
      Dim numeroComprobante As Long


      ventas = New Reglas.Ventas()
      total = 0

      Me.dgvDetalle.EndEdit()
      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         If Boolean.Parse(dr.Cells("Imprime").Value.ToString()) Then
            total += 1
         End If
      Next

      If total = 0 Then
         MessageBox.Show("No se indicaron comprobantes para Exportar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      '# En caso que el parámetro esté vacio, se abre el browser para seleccionar la ubicación.
      If String.IsNullOrEmpty(raizDestino) Then
         If Not FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
         raizDestino = FolderBrowserDialog1.SelectedPath
      End If

      progreso = 0

      Me.tspBarra.Maximum = total
      Me.tspBarra.Value = progreso

      Dim ePDF As ExportarPDF = New ExportarPDF()
      Dim cuitEmpresa As String = Publicos.CuitEmpresa
      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows

         If Boolean.Parse(dr.Cells("Imprime").Value.ToString()) Then

            progreso += 1
            Me.tspBarra.Value = progreso
            Me.tssInfo.Text = "Exportando... " + progreso.ToString() + " de " + total.ToString()

            System.Windows.Forms.Application.DoEvents()

            idSucursal = Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal
            idTipoComprobante = dr.Cells("IdTipoComprobante").Value.ToString()
            letra = dr.Cells("Letra").Value.ToString()
            centroEmisor = Short.Parse(dr.Cells("CentroEmisor").Value.ToString())
            numeroComprobante = Long.Parse(dr.Cells("NumeroComprobante").Value.ToString())

            venta = ventas.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
            '-- REQ-34676.- ----------------------------------------------------------------------------------------------
            Dim archivoDestino = IO.Path.Combine(raizDestino, New Reglas.Ventas().FormatoNombreArchivoExportacion(venta))
            '-------------------------------------------------------------------------------------------------------------
            ePDF.Exportar(venta, archivoDestino)

            '# Luego de exportar, actualizo la fecha de exportación
            Dim rVentas As Reglas.Ventas = New Reglas.Ventas
            rVentas.ActualizaFechaExportacion(venta.IdSucursal,
                                              venta.TipoComprobante.IdTipoComprobante,
                                              venta.CentroEmisor,
                                              venta.LetraComprobante,
                                              venta.NumeroComprobante,
                                              Date.Now)

         End If
      Next

      If Not silentMode Then
         ShowMessage("Se imprimieron " + progreso.ToString() + " comprobante.")
      End If

   End Sub

#End Region

End Class