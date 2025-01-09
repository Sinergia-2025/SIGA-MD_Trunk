Public Class EnvioMasivoDeFacturas
   Implements IConParametros

#Region "Campos"
   Private _dtEnvioMail As DataTable
   Private _publicos As Publicos
   Private _modoFechas As String
   Private _reportesCtaCtePorDefecto As Entidades.Publicos.InformesCtaCte = Entidades.Publicos.InformesCtaCte.CTACTEDET
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            If String.IsNullOrWhiteSpace(_modoFechas) Then _modoFechas = "EMISION"

            If (Not ValidarCorreo()) Then
               ShowMessage("No se podrán enviar las facturas hasta que " + Environment.NewLine + "se completen los datos del Correo Electronico " + Environment.NewLine + "(Configuraciones -> Parametros del Sistema)")
            End If

            FechaLiquidacion()

            _publicos = New Publicos()

            '# Sucursales
            cmbSucursal.Initializar(False, IdFuncion)
            cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

            _publicos.CargaComboCategorias(Me.cmbCategoriasClientes)
            _publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
            _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnum))
            _publicos.CargaComboDesdeEnum(Me.cmbCorreoEnviado, GetType(Entidades.Publicos.SiNoTodos))
            _publicos.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)

            ' REQ-43920.-
            _publicos.CargaComboDesdeEnum(cmbTipoCliente, GetType(Entidades.Cliente.ClienteVinculado))
            cmbTipoCliente.SelectedIndex = 0

            '# Combo para filtrar x Saldo
            _publicos.CargaComboDesdeEnum(Me.cmbOperadorLogico, GetType(Entidades.Publicos.OperadoresRelacionales))
            Me.cmbOperadorLogico.SelectedIndex = -1

            _publicos.CargaComboDesdeEnum(Me.cmbReportesCtaCte, GetType(Entidades.Publicos.InformesCtaCte))

            'Me.cmbReportesCtaCte.Items.Insert(0, "Informe de Cta. Cte. de Clientes")
            'Me.cmbReportesCtaCte.Items.Insert(1, "Informe de Cta. Cte. - Debe Haber")
            'cmbReportesCtaCte.SelectedIndex = 0
            cmbReportesCtaCte.SelectedValue = _reportesCtaCtePorDefecto

            cmbCorreoEnviado.SelectedValue = Entidades.Publicos.SiNoTodos.NO

            chbEnvioCtaCteCliente.Checked = Reglas.Publicos.EnvioMasivoComprobantesAdjuntaCtaCte

            cmbTiposComprobantes.Initializar(False, "VENTAS")
            cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

            ugDetalle.DisplayLayout.Bands(0).Columns("FechaVencimiento").Hidden = _modoFechas = "EMISION"
            ugDetalle.DisplayLayout.Bands(0).Columns("Dias").Hidden = _modoFechas = "EMISION"

            If _modoFechas = "VENCIMIENTO" Then
               Text = "Envío Masivo de Comprobantes Vencidos/Por Vencer"
            End If

            txtCopiaOculta.Text = Reglas.Publicos.Facturacion.FacturacionEnvioMailCopiaOculta
            chbCopiaOculta.Checked = Not String.IsNullOrWhiteSpace(txtCopiaOculta.Text)
            PreferenciasLeer(ugDetalle, tsbPreferencias)

            AgregarTotalesSuma(ugDetalle, {"Saldo"})
            FormateaGrilla(True)
         End Sub)

   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

#Region "Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(
         Sub()
            RefrescarDatosGrilla()
            tslTexto.Text = String.Empty
         End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
   Private Sub tsbEnviarFacturas_Click(sender As Object, e As EventArgs) Handles tsbEnviarFacturas.Click
      TryCatched(
         Sub()
            If (ValidarCorreo()) Then
               tsbEnviarFacturas.Enabled = False
               EnviaMails()
            Else
               ShowMessage("Los Datos del Correo Electronico estan incompletos " + Environment.NewLine + " (Configuraciones -> Parametros del Sistema)")
            End If
         End Sub)
      tsbEnviarFacturas.Enabled = True
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

#End Region

#Region "ProcessTabKey"
   Private Sub controles_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtComenzarPorNombreCliente.KeyUp, dtpHasta.KeyUp, dtpDesde.KeyUp, cmbZonaGeografica.KeyUp, cmbCategoriasClientes.KeyUp, bscNombreCliente.KeyUp, bscCodigoCliente.KeyUp
      TryCatched(Sub() PresionarTab(e))
   End Sub
#End Region

#Region "Cliente"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(
         Sub()
            bscCodigoCliente.Enabled = chbCliente.Checked
            bscNombreCliente.Enabled = chbCliente.Checked

            If chbCliente.Checked Then
               bscCodigoCliente.Focus()
            Else
               bscCodigoCliente.Text = String.Empty
               bscCodigoCliente.Tag = Nothing
               bscNombreCliente.Text = String.Empty
            End If
         End Sub)
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1)
            bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, True)
         End Sub)
   End Sub
   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes(bscNombreCliente)
            bscNombreCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscNombreCliente.Text, True)
         End Sub)
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscNombreCliente.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosCliente(e.FilaDevuelta)
               btnConsultar.Focus()
            End If
         End Sub)
   End Sub
#End Region

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      Try
         If chkMesCompleto.Checked Then
            dtpDesde.Value = dtpDesde.Value.PrimerDiaMes()
            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            dtpHasta.Value = dtpDesde.Value.AddMonths(1).AddSeconds(-1)
         End If
         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked
      Catch ex As Exception
         chkMesCompleto.Checked = False
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbCategoriaCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriaCliente.CheckedChanged
      Me.cmbCategoriasClientes.Enabled = Me.chbCategoriaCliente.Checked

      If Me.chbCategoriaCliente.Checked Then
         Me.cmbCategoriasClientes.Focus()
      Else
         Me.cmbCategoriasClientes.SelectedIndex = -1
      End If
   End Sub
   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Me.chbZonaGeografica.Checked Then
         Me.cmbZonaGeografica.Focus()
      Else
         Me.cmbZonaGeografica.SelectedIndex = -1
      End If
   End Sub

   Private Sub chbCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbCobrador.CheckedChanged

      Me.cmbCobrador.Enabled = Me.chbCobrador.Checked
      'cmbOrigenCobrador.Enabled = chbCobrador.Checked
      If Not Me.chbCobrador.Checked Then
         Me.cmbCobrador.SelectedIndex = -1
      Else
         If Me.cmbCobrador.Items.Count > 0 Then
            Me.cmbCobrador.SelectedIndex = 0
         End If

         Me.cmbCobrador.Focus()

      End If

   End Sub

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnum Then

            Me.Cursor = Cursors.WaitCursor

            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnum)
               Case Reglas.Publicos.TodosEnum.MararTodos
                  MarcarDesmarcar(True, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarTodos

               Case Reglas.Publicos.TodosEnum.DesmarcarTodos
                  MarcarDesmarcar(False, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos

               Case Reglas.Publicos.TodosEnum.MarcarFiltrados
                  MarcarDesmarcar(True, ugDetalle.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarFiltrados

               Case Reglas.Publicos.TodosEnum.DesmarcarFiltrados
                  MarcarDesmarcar(False, ugDetalle.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MarcarFiltrados

               Case Reglas.Publicos.TodosEnum.InvertirMarcasTodos
                  MarcarDesmarcar(Nothing, ugDetalle.Rows.ToArray())

               Case Reglas.Publicos.TodosEnum.InvertirMarcasFiltrados
                  MarcarDesmarcar(Nothing, ugDetalle.Rows.GetFilteredInNonGroupByRows())

               Case Else

            End Select
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         ugDetalle.UpdateData()
      End Try
   End Sub
   Private Sub MarcarDesmarcar(marcar As Boolean?, rows As UltraGridRow())
      For Each dr As UltraGridRow In rows
         If dr.Cells("CorreoElectronico").Text <> "" Then
            If marcar.HasValue Then
               dr.Cells("Envio").Value = marcar.Value
            Else
               dr.Cells("Envio").Value = Not CBool(dr.Cells("Envio").Value)
            End If
         End If
      Next
   End Sub
#End Region
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscNombreCliente.Selecciono Then
            ShowMessage("ATENCION: Activo el filtro de Cliente, Debe seleccionar uno.")
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbCategoriaCliente.Checked And Me.cmbCategoriasClientes.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Activo el filtro de Categoría de Cliente, Debe seleccionar una.")
            Me.cmbCategoriasClientes.Focus()
            Exit Sub
         End If

         If Me.chbZonaGeografica.Checked And Me.cmbZonaGeografica.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Activo el filtro de Zona Geográfica, Debe seleccionar una.")
            Me.cmbCategoriasClientes.Focus()
            Exit Sub
         End If

         If Me.chbSaldo.Checked Then
            If Me.cmbOperadorLogico.SelectedIndex = -1 Then
               ShowMessage("ATENCION: Activo el filtro Saldo, pero no seleccionó una condición.")
               Me.cmbOperadorLogico.Focus()
               Exit Sub
            End If
            If String.IsNullOrEmpty(Me.txtSaldo.Text) Then
               ShowMessage("ATENCION: Activo el filtro Saldo, pero no ingresó ningún monto.")
               Me.txtSaldo.Focus()
               Exit Sub
            End If
         End If

         Me.tsbEnviarFacturas.Enabled = True

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            '{0} = Empresa / {1} = Nombre Fantasía
            '{2:dd/MM/yyyy} = Fecha desde / {3:dd/MM/yyyy} = Fecha hasta
            If _modoFechas = "EMISION" Then
               Me.txtAsuntoMail.Text = String.Format(Reglas.Publicos.Facturacion.FacturacionAsuntoEnvioMasivoEmail,
                                                     Reglas.Publicos.NombreEmpresa,
                                                     Reglas.Publicos.NombreFantasia,
                                                     dtpDesde.Value,
                                                     dtpHasta.Value)
            Else
               'CTA CTE
               Me.txtAsuntoMail.Text = String.Format(Reglas.Publicos.CtaCte.FacturacionAsuntoEnvioMasivoEmailCtaCte,
                                                     Reglas.Publicos.NombreEmpresa,
                                                     Reglas.Publicos.NombreFantasia,
                                                     dtpDesde.Value,
                                                     dtpHasta.Value)
            End If

            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
            Exit Sub
         End If
      Catch ex As Exception
         Me.tslTexto.Text = String.Empty
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub ugDetalle_CellChange(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.CellChange
      If e.Cell.Row.Index <> -1 AndAlso e.Cell.Column.Key.Equals("Envio") AndAlso CBool(e.Cell.Text) Then
         If e.Cell.Row.Cells("CorreoElectronico").Text = "" Then
            ShowMessage("No se puede seleccionar porque no tiene correo electronico")
            e.Cell.Value = False
         End If
      End If
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow

      Try
         If ugDetalle.Rows.Count = 0 Then Exit Sub
         Dim rVentasEnvioMasivoMails As VentasEnvioMasivoMails = New VentasEnvioMasivoMails
         rVentasEnvioMasivoMails.PintarCeldas(e.Row.Cells("Estado"))
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#Region "Examinar"
   Private Sub btnExaminar1_Click(sender As Object, e As EventArgs) Handles btnExaminar1.Click
      Me.ExaminarArchivo(txtArchivo1)
   End Sub
   Private Sub btnExaminar2_Click(sender As Object, e As EventArgs) Handles btnExaminar2.Click
      Me.ExaminarArchivo(txtArchivo2)
   End Sub
   Private Sub btnExaminar3_Click(sender As Object, e As EventArgs) Handles btnExaminar3.Click
      Me.ExaminarArchivo(txtArchivo3)
   End Sub
   Private Sub btnExaminar4_Click(sender As Object, e As EventArgs) Handles btnExaminar4.Click
      Me.ExaminarArchivo(txtArchivo4)
   End Sub
#End Region

#End Region

#Region "Metodos Privados"

   Private Sub EnviaMailPrueba()
      If String.IsNullOrEmpty(txtAsuntoMail.Text) Then
         Me.txtAsuntoMail.Focus()
         Throw New Exception("ATENCION: Debe ingresar el Asunto del Correo.")
      End If
      If String.IsNullOrEmpty(rtbCuerpoMail.BodyHtml) Then
         Me.rtbCuerpoMail.Focus()
         Throw New Exception("ATENCION: Debe ingresar el Cuerpo del Correo.")
      End If

      Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then

         Dim mailPrueba As String = String.Empty
         If chbCopiaOculta.Checked And Not String.IsNullOrWhiteSpace(txtCopiaOculta.Text) Then
            mailPrueba = txtCopiaOculta.Text
         Else
            mailPrueba = Reglas.Publicos.ProcesosCorreoPruebaPara
         End If

         Me.ugDetalle.UpdateData()

         'Dim _dtEnvioMail As DataTable = DirectCast(Me.ugDetalle.DataSource, DataTable).Clone
         '_dtEnvioMail.ImportRow(dr)
         '_dtEnvioMail.AcceptChanges()

         Dim reporteCtaCte As Entidades.Publicos.InformesCtaCte? = Nothing
         If cmbReportesCtaCte.SelectedIndex > -1 Then
            reporteCtaCte = DirectCast(cmbReportesCtaCte.SelectedValue, Entidades.Publicos.InformesCtaCte)
         End If

         Dim adjuntos As String() = {Me.txtArchivo1.Text, Me.txtArchivo2.Text, Me.txtArchivo3.Text, Me.txtArchivo4.Text}
         Dim wEnvioMasivo As VentasEnvioMasivoMails = New VentasEnvioMasivoMails()
         wEnvioMasivo.EnviarMailPrueba(txtAsuntoMail.Text, rtbCuerpoMail.BodyHtml, mailPrueba, _dtEnvioMail, adjuntos, tspBarra, tslTexto, True, reporteCtaCte)
      Else
         Throw New Exception("ATENCION: No tiene ninguna fila selleccionada para enviar el correo de prueba.")
      End If



      Me.tspBarra.Value = 0
      'Me.RefrescarDatosGrilla()
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Enabled = False
      Me.bscNombreCliente.Enabled = False
   End Sub

   Private Sub RefrescarDatosGrilla()

      If Me.ugDetalle.DisplayLayout.Bands(0).Columns.Contains("Estado") Then
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("Estado").Hidden = True
      End If

      Me.FechaLiquidacion()
      Me.txtComenzarPorNombreCliente.Text = String.Empty
      Me.chbCliente.Checked = False
      Me.chbCategoriaCliente.Checked = False
      Me.chbZonaGeografica.Checked = False
      Me.chbCobrador.Checked = False

      If Me.ugDetalle.Rows.Count > 0 AndAlso TypeOf (Me.ugDetalle.DataSource) Is DataTable Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      cmbTipoCliente.SelectedIndex = 0

      Me.cmbTodos.SelectedIndex = 0
      Me.cmbSucursal.Refrescar()

      Me.tsbEnviarFacturas.Enabled = False
      Me.txtAsuntoMail.Text = String.Empty
      Me.rtbCuerpoMail.Text = String.Empty

      Me.tslTexto.Text = ""
      Me.txtCopiaOculta.Text = Reglas.Publicos.Facturacion.FacturacionEnvioMailCopiaOculta
      Me.chbCopiaOculta.Checked = Not String.IsNullOrWhiteSpace(txtCopiaOculta.Text)

      Me.chbEnvioCtaCteCliente.Checked = Reglas.Publicos.EnvioMasivoComprobantesAdjuntaCtaCte

      Me.txtArchivo1.Text = String.Empty
      Me.txtArchivo2.Text = String.Empty
      Me.txtArchivo3.Text = String.Empty
      Me.txtArchivo4.Text = String.Empty

      Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      Me.dtpDesde.Focus()

      Me.chbSaldo.Checked = False
      Me.cmbOperadorLogico.SelectedIndex = -1
      Me.cmbOperadorLogico.Enabled = False
      Me.txtSaldo.Clear()
      Me.txtSaldo.Enabled = False

   End Sub

   Private Sub CargaGrillaDetalle()
      Try
         Dim idCliente As Long = 0
         Dim idCategoria As Integer = 0
         Dim IdZonaGeografica As String = String.Empty
         Dim idCobrador As Integer = 0
         Dim tipoCliente = cmbTipoCliente.ValorSeleccionado(Of Entidades.Cliente.ClienteVinculado)()

         If chbCliente.Checked Then idCliente = Long.Parse(bscCodigoCliente.Tag.ToString())
         If chbCategoriaCliente.Checked Then idCategoria = Integer.Parse(cmbCategoriasClientes.SelectedValue.ToString())
         If chbZonaGeografica.Checked Then IdZonaGeografica = cmbZonaGeografica.SelectedValue.ToString()
         If chbCobrador.Checked Then idCobrador = Integer.Parse(cmbCobrador.SelectedValue.ToString())

         Dim operador As Entidades.Publicos.OperadoresRelacionales? = Nothing
         Dim saldo As Decimal? = Nothing
         If Me.chbSaldo.Checked Then
            operador = DirectCast(Me.cmbOperadorLogico.SelectedValue, Entidades.Publicos.OperadoresRelacionales)
            saldo = Decimal.Parse(Me.txtSaldo.Text)
         End If

         Dim envioMasivo As VentasEnvioMasivoMails = New VentasEnvioMasivoMails()
         _dtEnvioMail = envioMasivo.GetEnvioMasivoMail(Me.cmbSucursal.GetSucursales(),
                                                       Me.dtpDesde.Value, Me.dtpHasta.Value, _modoFechas,
                                                       idCategoria, IdZonaGeografica,
                                                       idCliente, txtComenzarPorNombreCliente.Text,
                                                       Reglas.Publicos.ConfiguraciónMail, idCobrador,
                                                       DirectCast(cmbCorreoEnviado.SelectedValue, Entidades.Publicos.SiNoTodos),
                                                       cmbTiposComprobantes.GetTiposComprobantes(),
                                                       operador,
                                                       saldo, tipoCliente)

         '# Agrego la columna de Estado al dt
         _dtEnvioMail.Columns.Add("Estado", GetType(String))

         Me.ugDetalle.DataSource = _dtEnvioMail

         FormateaGrilla(cmbTipoCliente.ValorSeleccionado(Of Entidades.Cliente.ClienteVinculado)() = Entidades.Cliente.ClienteVinculado.Cliente)

         Me.tslTexto.Text = _dtEnvioMail.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Public Sub FormateaGrilla(tipo As Boolean)
      Dim pos = 0I

      With ugDetalle.DisplayLayout.Bands(0)
         .Columns("IdClienteVinculado").Hidden = tipo
         .Columns("CodigoClienteVinculado").Hidden = tipo
         .Columns("NombreClienteVinculado").Hidden = tipo
         .Columns("CorreoClienteVinculado").Hidden = tipo
      End With
   End Sub
   Private Sub FechaLiquidacion()
      chkMesCompleto.Checked = False
      dtpDesde.Value = If(_modoFechas = "EMISION", Today, Today.AddDays(Reglas.Publicos.CtaCte.CantidadDiasVencimientoMail * -1))
      dtpHasta.Value = Today.UltimoSegundoDelDia()
   End Sub

   Private Sub ExaminarArchivo(txtArchivo As TextBox)

      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      Dim result As DialogResult = DialogoAbrirArchivo.ShowDialog()
      If result = System.Windows.Forms.DialogResult.OK Then
         Try
            Using DialogoAbrirArchivo.OpenFile()
               'Si bien aca lo pude abrir, solo es para obtener el path.
               txtArchivo.Text = DialogoAbrirArchivo.FileName
               txtArchivo.Focus()
            End Using
         Catch ex As Exception
            ShowMessage(String.Format("ATENCION: No se puede leer el Archivo {0}. Error: {1}", DialogoAbrirArchivo.FileName, ex.Message))
         End Try
      End If

   End Sub

   Private Sub EnviaMails()

      If String.IsNullOrEmpty(txtAsuntoMail.Text) Then
         Me.txtAsuntoMail.Focus()
         Throw New Exception("ATENCION: Debe ingresar el Asunto del Correo.")
      End If
      If String.IsNullOrEmpty(rtbCuerpoMail.BodyHtml) Then
         Me.rtbCuerpoMail.Focus()
         Throw New Exception("ATENCION: Debe ingresar el Cuerpo del Correo.")
      End If

      Dim copiaOculta As String = String.Empty
      If chbCopiaOculta.Checked Then copiaOculta = txtCopiaOculta.Text

      '# Muestro al usuario la columna de Estado
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("Estado").Hidden = False

      Me.ugDetalle.UpdateData()

      Dim adjuntos As String() = {Me.txtArchivo1.Text, Me.txtArchivo2.Text, Me.txtArchivo3.Text, Me.txtArchivo4.Text}

      Dim reporteCtaCte As Entidades.Publicos.InformesCtaCte? = Nothing
      If cmbReportesCtaCte.SelectedIndex > -1 Then
         reporteCtaCte = DirectCast(cmbReportesCtaCte.SelectedValue, Entidades.Publicos.InformesCtaCte)
      End If
      Dim tipoCliente = cmbTipoCliente.ValorSeleccionado(Of Entidades.Cliente.ClienteVinculado)()

      Dim wEnvioMasivo As VentasEnvioMasivoMails = New VentasEnvioMasivoMails()
      wEnvioMasivo.EnviarMails(txtAsuntoMail.Text, rtbCuerpoMail.BodyHtml, copiaOculta,
                                       _dtEnvioMail, adjuntos,
                                       tspBarra, tslTexto, Me.chbEnvioCtaCteCliente.Checked, reporteCtaCte, tipoCliente)


      ShowMessage("¡¡Facturas enviadas con Exito!!")

      Me.tspBarra.Value = 0
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

#End Region

   Private Sub btnExpandirHtml_Click(sender As Object, e As EventArgs) Handles btnExpandirHtml.Click
      Using frm As EditorHtml = New EditorHtml(rtbCuerpoMail.BodyHtml)
         If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            rtbCuerpoMail.BodyHtml = frm.BodyHTML
         End If
      End Using
   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros

      parametros.Split(";"c).ToList().
            ForEach(Sub(p)
                       Dim kv = p.Split("="c)
                       If kv(0) = "ModoFechas" Then
                          If kv(1) = "PORVENCIMIENTO" Then
                             _modoFechas = "VENCIMIENTO"
                          Else
                             _modoFechas = "EMISION"
                          End If
                       ElseIf kv(0) = "ReportesCtaCte" Then
                          _reportesCtaCtePorDefecto = kv(1).StringToEnum(Entidades.Publicos.InformesCtaCte.CTACTEDET)
                       End If
                    End Sub)

      'If parametros = "PORVENCIMIENTO" Then
      '   _modoFechas = "VENCIMIENTO"
      'Else
      '   _modoFechas = "EMISION"
      'End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder("Lista separada por ';' de pares clave valor separados por '='").AppendLine().AppendLine()

      stb.AppendFormatLine("ModoFechas       = Modalidad de la pantalla")
      stb.AppendFormatLine("                 - Valores posibles: PORVENCIMIENTO o blanco")
      stb.AppendFormatLine("                 - Si PORVENCIMIENTO usa modo VENCIMIENTO. Si blanco usa modo EMISION")
      stb.AppendFormatLine("                 - Por defecto: blanco")

      stb.AppendFormatLine("ReportesCtaCte   = Reporte por defecto de Cta Cte")
      stb.AppendFormatLine("                 - Valores posibles: CTACTE, CTACTEDH, CTACTEDET o CTACTEDETDH")
      stb.AppendFormatLine("                 - Por defecto: CTACTEDET")

      Return stb.ToString()
   End Function

   Private Sub chbEnvioCtaCteCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbEnvioCtaCteCliente.CheckedChanged
      Try
         cmbReportesCtaCte.Enabled = chbEnvioCtaCteCliente.Checked
         If Not Me.chbEnvioCtaCteCliente.Checked Then
            Me.cmbReportesCtaCte.SelectedIndex = -1
         Else
            If Me.cmbReportesCtaCte.Items.Count > 0 Then
               Me.cmbReportesCtaCte.SelectedIndex = 0
            End If
            Me.cmbReportesCtaCte.Focus()
         End If
      Catch ex As Exception

      End Try

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

   Private Sub chbSaldo_CheckedChanged(sender As Object, e As EventArgs) Handles chbSaldo.CheckedChanged
      Me.cmbOperadorLogico.Enabled = Me.chbSaldo.Checked
      Me.txtSaldo.Enabled = Me.chbSaldo.Checked
      If Not Me.chbSaldo.Checked Then
         Me.txtSaldo.Clear()
      Else
         Me.txtSaldo.Text = "0.00"
      End If
      Me.cmbOperadorLogico.SelectedIndex = -1
   End Sub

End Class