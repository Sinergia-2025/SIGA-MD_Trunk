Public Class ImportarChequesElectronicos
#Region "Variables"
   Private _publicos As Publicos
   Private _nombreArchivo As String
   Private _result As Integer
   Private _cargando As Boolean

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = Not Reglas.Publicos.CtaCteProv.PagoIgnorarPCdeCaja, blnCajasModificables As Boolean = True

         _publicos = New Publicos()
         With _publicos
            .CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, blnMiraUsuario, blnMiraPC, blnCajasModificables)
            .CargaComboEmpleados(cmbCobradores, Entidades.Publicos.TiposEmpleados.COBRADOR)
            .CargaComboTiposComprobantesRecibo(Me.cmbTipoRecibo, miraPC:=True, tipo1:="CTACTECLIE", esReciboClienteVinculado:=Nothing)
            _cargando = True
            .CargaComboDesdeEnum(cmbTipo, GetType(Reglas.Publicos.BancosImportacionCheques))
            _cargando = False
         End With

         CargarParametros()

         tssRegistros.Text = ""

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
#End Region

#Region "Eventos"
   Private Sub CargarParametros()
      If IsNumeric(Reglas.Publicos.CtaCte.DebitoAutomaticoCajaCtaBancariaTransfBanc) Then
         cmbCajas.SelectedValue = Reglas.Publicos.CtaCte.DebitoAutomaticoCajaCtaBancariaTransfBanc
      End If
      cmbTipoRecibo.SelectedValue = Reglas.Publicos.CtaCte.DebitoAutomaticoTipoReciboCtaBancariaTransf
      cmbCobradores.SelectedValue = Reglas.Publicos.CtaCte.DebitoAutomaticoCobradorCtaBancariaTransf
      '---------------------------------------
      dtpFecha.Value = Date.Now
      '---------------------------------------
      'tsbGenerarRecibos.Enabled = False
      '---------------------------------------
      txtRangoCeldasFilaDesde.Text = String.Empty
      txtRangoCeldasFilaHasta.Text = String.Empty
      '---------------------------------------
      _cargando = True
      cmbTipo.SelectedIndex = -1
      _cargando = False
      cmbTipo.Select()
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         '-- Refresca la Grilla y Parametros.- --
         RefrescarDatosGrilla()
         '---------------------------------------
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ImportarChequesElectronicos_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         tsbRefrescar_Click(tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
         Sub()
            Dim dr = e.Row.FilaSeleccionada(Of DataRow)()
            If dr IsNot Nothing Then
               Dim accion = dr.Field(Of String)(Entidades.CuentaCorrienteCheque.Columnas.EstadoExportacion.ToString())
               If accion = "X" Then
                  e.Row.Cells(Entidades.CuentaCorrienteCheque.Columnas.EstadoExportacion.ToString()).Color(Color.White, Color.Red)
               ElseIf accion = "C" Then
                  e.Row.Cells(Entidades.CuentaCorrienteCheque.Columnas.EstadoExportacion.ToString()).Color(Color.Black, Color.Yellow)
               Else
                  e.Row.Cells(Entidades.CuentaCorrienteCheque.Columnas.EstadoExportacion.ToString()).ColorClear()
               End If
            End If
         End Sub)
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()

      CargarParametros()
      dtpFecha.Value = Date.Now

      Me.dtpFecha.Value = Date.Now()
      Me.tsbLeerArchivo.Enabled = True

      If ugDetalle.DataSource IsNot Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbLeerArchivo_Click(sender As Object, e As EventArgs) Handles tsbLeerArchivo.Click
      Try
         '-- Define nuevo OpenFileDialog.- --
         Dim ofd = New OpenFileDialog()
         '-----------------------------------
         Me.tssInfo.Text = "Leyendo archivo...."
         Application.DoEvents()
         '-----------------------------------
         If String.IsNullOrWhiteSpace(txtRangoCeldasColumnaDesde.Text) Or
         String.IsNullOrWhiteSpace(txtRangoCeldasColumnaHasta.Text) Or
         Not IsNumeric(txtRangoCeldasFilaDesde.Text) Or
         Not IsNumeric(txtRangoCeldasFilaHasta.Text) Then
            ShowMessage("Debe indicar el rango de celdas a leer del archivo Excel")
            txtRangoCeldasFilaHasta.Focus()
            Exit Sub
         End If
         '-----------------------------------
         If Me.cmbTipo.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar un Tipo de Formato de Banco.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.tsbLeerArchivo.Enabled = True
            Me.cmbTipo.Focus()
            Exit Sub
         End If
         '-----------------------------------
         Select Case DirectCast(cmbTipo.SelectedValue, Reglas.Publicos.BancosImportacionCheques)
            Case Reglas.Publicos.BancosImportacionCheques.MACRO
               ofd.Filter = "Archivo de Banco MACRO (xls)|*.xls|Todos los Archivos (*.*)|*.*"
            Case Reglas.Publicos.BancosImportacionCheques.BBVA
               ofd.Filter = "Archivo de Banco BBVA (xls)|.xls|Todos los Archivos (*.*)|*.*"
         End Select
         '--------------------------------------
         ofd.FilterIndex = 1
         ofd.RestoreDirectory = True
         '--------------------------------------
         Me.tssInfo.Text = "Cargando archivo...."
         Application.DoEvents()
         '--------------------------------------
         If ofd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            _nombreArchivo = ofd.FileName
            '-----------------------------------
            Dim rangoExcel = String.Format("[{0}{1}:{2}{3}]",
                                          txtRangoCeldasColumnaDesde.Text.Trim(),
                                          txtRangoCeldasFilaDesde.Text.Trim(),
                                          txtRangoCeldasColumnaHasta.Text.Trim(),
                                          txtRangoCeldasFilaHasta.Text.Trim())
            '-----------------------------------
            If Not String.IsNullOrEmpty(rangoExcel) Then
               '--------------------------------------
               Me.tssInfo.Text = "Generando información...."
               Application.DoEvents()
               '--------------------------------------
               LeerExcel(rangoExcel)
            End If
            '-- Activa Generacion de Recibos.- --
            Me.Cursor = Cursors.WaitCursor
            Me.tsbGenerarRecibos.Enabled = True ' (_result = 0)
            '-----------------------------------
            Me.tssInfo.Text = ""
            Application.DoEvents()
            '-----------------------------------
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub LeerExcel(rangoExcel As String)
      Try
         _result = 0
         '-----------------------------------
         Me.tssInfo.Text = "Seteando grillas...."
         Application.DoEvents()
         '-----------------------------------
         Dim rCtasCteChq = New Reglas.CuentasCorrientesCheques()

         Me.ugDetalle.DataSource = rCtasCteChq.ObtieneFormatFile(rangoExcel, _nombreArchivo, cmbTipo.SelectedValue.ToString(), _result)
         Me.FormatearGrilla()

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.tssRegistros.Text = "0 Registros"
         If ex.Message.Contains("FROM") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRangoCeldasFilaHasta.Focus()
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Finally
         Me.Cursor = Cursors.Default
         'tsbGenerarRecibos.Enabled = True
         tsbSalir.Enabled = True
      End Try
   End Sub

   Private Sub FormatearGrilla()

      Dim pos As Integer = 0

      With ugDetalle.DisplayLayout.Bands(0)
         For Each col In .Columns
            col.Hidden = True
         Next
         '-- Configura solo las visibles.- --
         .Columns("EstadoExportacion").FormatearColumna("Estado", pos, 80, HAlign.Center)
         .Columns("FechaEmision").FormatearColumna("Fecha Emision", pos, 100, HAlign.Center)
         .Columns("FechaCobro").FormatearColumna("Fecha Cobro", pos, 100, HAlign.Center)
         .Columns("NroCheque").FormatearColumna("Nro. Cheque", pos, 100, HAlign.Right)
         .Columns("IdsCheque").FormatearColumna("Ids. Cheque", pos, 140, HAlign.Left)
         .Columns("Importe").FormatearColumna("Importe", pos, 110, HAlign.Right, , "N2")

         .Columns("CodigoCliente").FormatearColumna("Codigo Cliente", pos, 100, HAlign.Right)
         .Columns("RazonSocial").FormatearColumna("Razon Social", pos, 200, HAlign.Left)
         .Columns("CUIT").FormatearColumna("CUIT Cliente", pos, 80, HAlign.Right)

         .Columns("RazonSocialEmisor").FormatearColumna("Razon Social Emisor", pos, 200, HAlign.Left)
         .Columns("CUITEmisor").FormatearColumna("CUIT Emisor", pos, 100, HAlign.Right)

         '-- REQ-35400.- ----------------------------------------------------------------------------
         .Columns("IdBancoEmisor").FormatearColumna("Codigo Banco", pos, 100, HAlign.Right)
         .Columns("BancoEmisor").FormatearColumna("Banco Emisor", pos, 200, HAlign.Left)
         .Columns("SucBancoEmisor").FormatearColumna("Suc. Banco", pos, 100, HAlign.Right)

         .Columns("CodigoPostal").FormatearColumna("Codigo Postal", pos, 100, HAlign.Right)

         .Columns("IdProveedor").Hidden = True
         .Columns("CodigoProveedor").Hidden = True
         .Columns("NombreProveedor").FormatearColumna("Proveedor", pos, 200, HAlign.Left)

         .Columns("NumeroOrdenCompra").FormatearColumna("Orden Compra", pos, 100, HAlign.Right)

         '-------------------------------------------------------------------------------------------
         .Columns("Observacion").FormatearColumna("Observación", pos, 200, HAlign.Left)
         .Columns("Mensaje").FormatearColumna("Mensaje Error", pos, 240, HAlign.Left)

         .Columns("IdCliente").Hidden = True

      End With
   End Sub

   Private Sub cmbTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedIndexChanged
      If Not _cargando Then
         '-----------------------------------    
         Select Case cmbTipo.SelectedValue.ToString()
            Case Reglas.Publicos.BancosImportacionCheques.MACRO.ToString()
               txtRangoCeldasColumnaDesde.Text = "A"
               txtRangoCeldasColumnaHasta.Text = "S"
            Case Reglas.Publicos.BancosImportacionCheques.BBVA.ToString()

         End Select
         '--------------------------------------
         txtRangoCeldasFilaDesde.Select()
      End If
   End Sub

   Private Sub tsbGenerarRecibos_Click(sender As Object, e As EventArgs) Handles tsbGenerarRecibos.Click
      Try
         Cursor = Cursors.WaitCursor
         If ValidaGeneracion() Then
            GrabarRecibo()
            MessageBox.Show("Proceso finalizado con Exito.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            tsbRefrescar.PerformClick()
         End If

      Catch ex As Exception
         Cursor = Cursors.Default
         ShowError(ex)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Function ValidaGeneracion() As Boolean
      '-- Tipo de Recibo.- --
      If cmbTipoRecibo.SelectedIndex = -1 Then
         MessageBox.Show("Falta seleccionar el Tipo de Recibo", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         cmbTipoRecibo.Select()
         Return False
      End If
      '-- Cajas.- -- 
      If cmbCajas.SelectedIndex = -1 Then
         MessageBox.Show("Falta seleccionar la Caja", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         cmbCajas.Select()
         Return False
      End If
      '-- Cobrador.- --
      If cmbCobradores.SelectedIndex = -1 Then
         MessageBox.Show("Falta seleccionar el Cobrador", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         cmbCobradores.Select()
         Return False
      End If
      Return True
   End Function
   Private Sub GrabarRecibo()
      If MessageBox.Show("¿Desea Procesar Todos los Cheques?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

         Me.tssInfo.Text = "Armando datos...."
         Application.DoEvents()


         Dim rCtaCteChq = New Reglas.CuentasCorrientesCheques()
         rCtaCteChq.GrabarRecibos(DirectCast(cmbCobradores.SelectedItem, Entidades.Empleado),
                               Integer.Parse(Me.cmbCajas.SelectedValue.ToString()),
                               DirectCast(cmbTipoRecibo.SelectedItem, Entidades.TipoComprobante),
                               DirectCast(ugDetalle.DataSource, DataTable),
                               dtpFecha.Value,
                               _nombreArchivo,
                               DirectCast(cmbTipo.SelectedValue, Reglas.Publicos.BancosImportacionCheques).ToString(),
                               Me.IdFuncion)


      End If
   End Sub

   Private Sub ugDetalle_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugDetalle.DoubleClickRow
      Try
         Dim rCtasCteChq = New Reglas.CuentasCorrientesCheques()
         Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)(e.Row)
         If dr IsNot Nothing Then
            'If dr("EstadoExportacion").ToString() = "C" Or dr("EstadoExportacion").ToString() = "P" Then
            Using frm = New BuscaClientesImportacionCheques
               If frm.ShowDialog() = DialogResult.OK Then
                  If Not String.IsNullOrEmpty(frm.bscCodigoCliente.Text) Or frm.bscCodigoCliente.Selecciono Or frm.bscCliente.Selecciono Then
                     dr("CodigoCliente") = frm.bscCodigoCliente.Text
                     dr("IdCliente") = frm.bscCodigoCliente.Tag
                     dr("RazonSocial") = frm.bscCliente.Text
                  End If
               End If
               If frm.chbProveedor.Checked Then
                  dr("CodigoProveedor") = frm.bscCodigoProveedor.Text
                  dr("IdProveedor") = frm.bscCodigoProveedor.Tag
                  dr("NombreProveedor") = frm.bscProveedor.Text
               End If
               '-- Revalida Fila de la Grilla.- 
               rCtasCteChq.RevalidaFilaGrilla(dr)
            End Using
         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         SupervisaGrilla()
      End Try
   End Sub

   Private Sub SupervisaGrilla()
      Dim dt = DirectCast(ugDetalle.DataSource, DataTable)
      'Dim drCol As DataRow() = dt.Select("EstadoExportacion <> 'A'")
      'tsbGenerarRecibos.Enabled = Not dt.AsEnumerable().Any(Function(dr) dr.Field(Of String)("EstadoExportacion") <> "A")  'drCol.Length = 0
   End Sub

#End Region
End Class