Public Class SolicitarCAE

#Region "Campos"

   Private _publicos As Publicos
   Private _vta As Entidades.Venta
   Private _regCAE As Reglas.Ventas
   Private _estaCargando As Boolean = True
   Private _asunto As String = ""
   Private _cuerpo As String = ""
   Private _Sucursal As Integer = 0
   Private _Comprobante As String = ""
   Private _tipoTipoComprobante As String
   Private _Letra As String = ""
   Private _Emisor As Short = 0
   Private _NumeroComprobante As Long = 0
   Private _SinInternet As Boolean = False
   Private _NumeroRepartoDesde As Integer
   Private _NumeroRepartoHasta As Integer
   Private _cantidadDiasFiltroFecha As Integer

   Public ConsultarAutomaticamente As Boolean = False
   Public _nroRepartoInvocacionMasiva As Integer
   Public _fechaDesde As Date?
   Public _fechaHasta As Date?

#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(numeroRepartoDesde As Integer, numeroRepartoHasta As Integer)
      Me.New()

      _NumeroRepartoDesde = numeroRepartoDesde
      _NumeroRepartoHasta = numeroRepartoHasta
   End Sub

#End Region

#Region "Overrides"

   Protected Overridable Function GetReglaVentas() As Reglas.Ventas
      Return New Reglas.Ventas()
   End Function

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()
         _regCAE = GetReglaVentas()

         cmbTiposComprobantes.Initializar(MiraPC:=False, Entidades.TipoComprobante.Tipos.VENTAS.ToString(), EsElectronico:=True)
         cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         '_publicos.CargaComboTiposComprobantesElectronicos(Me.cmbTiposComprobantes, "TODOS")
         'cmbTiposComprobantes.SelectedIndex = -1

         cmbEstados.SelectedIndex = 0

         _cantidadDiasFiltroFecha = Reglas.Publicos.SolicitarCAECantidadDiasFiltroFecha
         chbPorFecha.Checked = _cantidadDiasFiltroFecha > -1

         If chbPorFecha.Checked Then
            dtpDesde.Value = If(_fechaDesde.HasValue, _fechaDesde.Value.AddDays(_cantidadDiasFiltroFecha * -1), Today.AddDays(_cantidadDiasFiltroFecha * -1))
            dtpHasta.Value = If(_fechaHasta.HasValue, _fechaHasta.Value, Date.Today.UltimoSegundoDelDia())
         End If

         'Me.dtpDesde.Value = Date.Today.AddDays(-5)  'Limite del AFIP para transmitir comprobantes.
         'Me.dtpHasta.Value = Date.Today

         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         cmbVendedor.SelectedIndex = -1

         _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")
         cmbFormaPago.SelectedIndex = -1

         _publicos.CargaComboUsuarios(cmbUsuario)

         With cboLetra
            .DisplayMember = "LetraFiscal"
            .ValueMember = "LetraFiscal"
            .DataSource = New Reglas.VentasNumeros().GetLetrasFiscales()
            .SelectedIndex = -1
         End With

         With cmbEmisor
            .DisplayMember = "CentroEmisor"
            .ValueMember = "CentroEmisor"
            .DataSource = New Reglas.VentasNumeros().GetCentrosEmisores()
            .SelectedIndex = -1
         End With

         _publicos.CargaComboCategorias(cmbCategoria)


         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = True, blnCajasModificables As Boolean = True
         Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, blnMiraUsuario, blnMiraPC, blnCajasModificables)

         Dim dt As DataTable

         dt = New Reglas.Textos().GetTextos(Me.Name, "")

         For Each dr As DataRow In dt.Rows
            Me._asunto = dr("Asunto").ToString()

            'Trabajo el cuerpo para que respete el formato
            Dim stbCuerpo As System.Text.StringBuilder = New System.Text.StringBuilder()

            Dim parts As String() = dr("Cuerpo").ToString.Split(ControlChars.CrLf.ToCharArray)

            stbCuerpo.Append("<!DOCTYPE HTML>")
            stbCuerpo.Append("<html>")
            stbCuerpo.Append("<head>")
            stbCuerpo.Append("</head>")
            stbCuerpo.Append("<body>")

            For Each st As String In parts
               stbCuerpo.Append("<br>")
               stbCuerpo.Append(st)
            Next
            stbCuerpo.Append("</body>")
            stbCuerpo.Append("</html>")

            Me._cuerpo = stbCuerpo.ToString()

         Next

         Me.chbImprimeLuegoDeSolicitarCAE.Checked = Reglas.Publicos.ImprimeLuegoDeSolictarCAE

         Me.CargarColumnasASumar()

         Me._estaCargando = False

         Try
            Me.Cursor = Cursors.WaitCursor

            Me.TestGeneralesAFIP()

            Me.Cursor = Cursors.Default
         Catch ex As Exception
            ShowError(ex)
         End Try

         anchoColumnaNombreCliente = ugDetalle.DisplayLayout.Bands(0).Columns("NombreCliente").Width

         If ConsultarAutomaticamente Then
            If _NumeroRepartoDesde = 0 And _NumeroRepartoHasta = 0 Then
               Me.btnConsultar.PerformClick()
            Else
               Me.chbNroReparto.Checked = True
               Me.txtNroRepartoDesde.Text = _NumeroRepartoDesde.ToString()
               Me.txtNroRepartoHasta.Text = _NumeroRepartoHasta.ToString()
               Me.btnConsultar.PerformClick()
            End If

         End If

         ugDetalle.DisplayLayout.Bands(0).Columns("TotalPercepcion").Hidden = Not Reglas.Publicos.RetieneIIBB
         ugDetalle.DisplayLayout.Bands(0).Columns("TotalImpuestoInterno").Hidden = True

         ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "CUIT", "Observacion"})

         PreferenciasLeer(ugDetalle, tsbPreferencias)
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbObtenerCAEs.PerformClick()
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

   Private anchoColumnaNombreCliente As Integer

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbNumero.Checked And (Long.Parse("0" & Me.txtNumero.Text) = 0) Then
            MessageBox.Show("ATENCION: NO seleccionó un Numero aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtNumero.Focus()
            Exit Sub
         End If

         If Me.chbNroReparto.Checked And (Long.Parse("0" & Me.txtNroRepartoDesde.Text) = 0) Then
            MessageBox.Show("ATENCION: NO Informó un Numero Reparto Desde aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtNroRepartoDesde.Focus()
            Exit Sub
         End If

         If Me.chbNroReparto.Checked And (Long.Parse("0" & Me.txtNroRepartoHasta.Text) = 0) Then
            MessageBox.Show("ATENCION: NO Informó un Numero Reparto Hasta aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtNroRepartoHasta.Focus()
            Exit Sub
         End If

         If Me.chbNroReparto.Checked And Long.Parse("0" & Me.txtNroRepartoDesde.Text) > Long.Parse("0" & Me.txtNroRepartoHasta.Text) Then
            MessageBox.Show("ATENCION: Rango Invalido de Repartos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtNroRepartoHasta.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle()

         Try
            TestGeneralesAFIP()

            If _SinInternet Then
               ShowMessage("Sin Internet, Por favor revise la conexión y luego presione el boton de Testear Servidores AFIP para continuar")
               Exit Sub
            End If
         Catch ex As Exception
            ShowError(ex)
         End Try

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("No hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub

   Private Sub chbPorFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbPorFecha.CheckedChanged
      Try
         Me.dtpDesde.Enabled = Me.chbPorFecha.Checked
         Me.dtpHasta.Enabled = Me.chbPorFecha.Checked

         If chbPorFecha.Checked Then
            If _cantidadDiasFiltroFecha > -1 Then
               dtpDesde.Value = Today.AddDays(_cantidadDiasFiltroFecha * -1)
               dtpHasta.Value = Today
            Else
               dtpDesde.Value = Today.AddDays(-5)
               dtpHasta.Value = Today
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked


      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick

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

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion

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

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbObtenerCAEs_Click(sender As Object, e As EventArgs) Handles tsbObtenerCAEs.Click

      Dim i As Integer = 0
      Dim progreso As Integer
      Dim total As Integer = 0

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.ugDetalle.UpdateData()

         If Me.chbCambiarFecha.Checked Then
            If MessageBox.Show("Esta seguro de cambiar la fecha de los comprobantes antes de transmitir?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
               Me.CambiarFechaComprobantes()
            Else
               Exit Sub
            End If
         End If

         Me.tspBarra.Visible = True
         Me.tspBarra.Value = 0

         progreso = 0

         For Each dr As UltraGridRow In Me.ugDetalle.Rows
            If dr.Cells("Check").Value Is Nothing OrElse Boolean.Parse(dr.Cells("Check").Value.ToString()) = False Then
               Continue For
            End If
            total += 1
         Next

         Me.tspBarra.Maximum = total
         Me.tspBarra.Value = progreso

         For Each dr As UltraGridRow In Me.ugDetalle.Rows.ToArray()
            If dr.Cells("Check").Value Is Nothing OrElse Boolean.Parse(dr.Cells("Check").Value.ToString()) = False Then
               Continue For
            End If
            progreso += 1

            Me.tspBarra.Value = progreso
            Me.tssInfo.Text = "Solicitando CAE ...  " + dr.Cells("DescripcionAbrev").Value.ToString() + "-" +
               dr.Cells("Letra").Value.ToString() + "-" + dr.Cells("CentroEmisor").Value.ToString() + "-" +
            dr.Cells("NumeroComprobante").Value.ToString() + " -  " + dr.Cells("NombreCliente").Value.ToString()

            Me._Sucursal = Integer.Parse(dr.Cells("IdSucursal").Value.ToString())
            Me._Comprobante = dr.Cells("IdTipoComprobante").Value.ToString()
            Me._Letra = dr.Cells("Letra").Value.ToString()
            Me._Emisor = Short.Parse(dr.Cells("CentroEmisor").Value.ToString())
            Me._NumeroComprobante = Long.Parse(dr.Cells("NumeroComprobante").Value.ToString())

            Try
               Me.ActualizarCAE(dr, Entidades.AFIPCAE.Secuencia.PrimeraVez)
            Catch ex As Exception
               Try
                  Me.tssInfo.Text = String.Empty
                  Application.DoEvents()
                  dr.Cells("CodigoErrorAfip").Value = ex.Message
                  dr.DataErrorInfo.SetColumnError("CodigoErrorAfip", ex.Message)
               Catch ex1 As Exception
                  MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               End Try
               Throw
            End Try

            dr.Delete(False)
            Application.DoEvents()

            If Me._SinInternet Then
               Exit For
            End If

            i += 1
         Next
         Me.tspBarra.Value = 0

         MessageBox.Show("Se actualizó el CAE de " + i.ToString() + " registros.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         If Not Me._SinInternet Then
            Me.btnConsultar.PerformClick()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Dim ven As Reglas.Ventas = GetReglaVentas()
         ven.ActualizarCodigoErrorAFIP(Me._Sucursal, Me._Comprobante, Me._Letra, Me._Emisor, Me._NumeroComprobante, ex.Message.ToString())

      Finally

         Me.tspBarra.Visible = False
         Me.tssInfo.Text = String.Empty

         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub cmbEstados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstados.SelectedIndexChanged

      Try

         If Me._estaCargando Then Exit Sub

         Select Case Me.cmbEstados.Text
            Case "Sin CAE"
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("ObtenerCAE").Hidden = False
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("Check").Hidden = False
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("ControlarInfo").Hidden = False
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("CAE").Hidden = True
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("CAEVencimiento").Hidden = True
               Me.tsbObtenerCAEs.Visible = True
            Case "Con CAE"
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("ObtenerCAE").Hidden = True
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("Check").Hidden = True
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("ControlarInfo").Hidden = True
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("CAE").Hidden = False
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("CAEVencimiento").Hidden = False
               Me.tsbObtenerCAEs.Visible = False
            Case "Todos"
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("ObtenerCAE").Hidden = True
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("Check").Hidden = True
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("ControlarInfo").Hidden = True
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("CAE").Hidden = False
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("CAEVencimiento").Hidden = False
               Me.tsbObtenerCAEs.Visible = False
         End Select

         Me.btnConsultar.PerformClick()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged

      Try
         Me.Cursor = Cursors.WaitCursor

         For Each dr As UltraGridRow In Me.ugDetalle.Rows
            dr.Cells("Check").Value = Me.chbTodos.Checked
         Next

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbCambiarFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbCambiarFecha.CheckedChanged
      Try
         Me.dtpCambiarFecha.Enabled = Me.chbCambiarFecha.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbConfigurarMail_Click(sender As Object, e As EventArgs) Handles tsbConfigurarMail.Click
      Try

         Dim txt As Textos = New Textos(Me.Name, "")
         txt.ShowDialog()

         Me._asunto = txt.asunto

         'Trabajo el cuerpo para que respete el formato
         Dim stbCuerpo As System.Text.StringBuilder = New System.Text.StringBuilder()

         Dim parts As String() = txt.cuerpo.Split(ControlChars.CrLf.ToCharArray)

         stbCuerpo.Append("<!DOCTYPE HTML>")
         stbCuerpo.Append("<html>")
         stbCuerpo.Append("<head>")
         stbCuerpo.Append("</head>")
         stbCuerpo.Append("<body>")

         For Each st As String In parts
            stbCuerpo.Append("<br>")
            stbCuerpo.Append(st)
         Next
         stbCuerpo.Append("</body>")
         stbCuerpo.Append("</html>")

         Me._cuerpo = stbCuerpo.ToString()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton

      If e.Cell.Row.Index <> -1 Then
         Try
            Me.Cursor = Cursors.WaitCursor
            Select Case e.Cell.Column.Key

               Case "Ver"
                  Dim oVentas As Reglas.Ventas = GetReglaVentas()
                  Dim venta As Entidades.Venta = oVentas.GetUna(actual.Sucursal.Id,
                              Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(),
                              Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(),
                              Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()),
                              Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))

                  Dim oImpr As Impresion = New Impresion(venta)

                  If venta.Impresora.TipoImpresora = "NORMAL" Then
                     oImpr.ImprimirComprobanteNoFiscal(True)
                  Else
                     oImpr.ReImprimirComprobanteFiscal()
                  End If

               Case "ObtenerCAE"

                  Me.Cursor = Cursors.WaitCursor

                  Me.TestGeneralesAFIP()

                  Me.Cursor = Cursors.Default

                  If Me._SinInternet Then
                     MessageBox.Show("Sin Internet, Por favor revise la conexión y luego presione el boton de Testear Servidores AFIP para continuar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Exit Sub
                  End If

                  If Me.chbCambiarFecha.Checked Then
                     If MessageBox.Show("Esta seguro de cambiar la fecha del comprobante antes de transmitir?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Fecha").Value = Me.dtpCambiarFecha.Value
                     Else
                        Exit Sub
                     End If
                  End If

                  Me.ActualizarCAE(Me.ugDetalle.Rows(e.Cell.Row.Index), Entidades.AFIPCAE.Secuencia.PrimeraVez)

                  If Me._vta IsNot Nothing Then
                     MessageBox.Show("Se actualizó el CAE " + Me._vta.AFIPCAE.CAE, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  End If

                  e.Cell.Row.Delete(False)
                  ''Me.btnConsultar.PerformClick()


               Case "ControlarInfo"

                  Me.Cursor = Cursors.WaitCursor

                  Me.TestGeneralesAFIP()

                  Me.Cursor = Cursors.Default

                  If Me._SinInternet Then
                     MessageBox.Show("Sin Internet, Por favor revise la conexión y luego presione el boton de Testear Servidores AFIP para continuar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     Exit Sub
                  End If

                  If Me.chbCambiarFecha.Checked Then
                     If MessageBox.Show("Esta seguro de cambiar la fecha del comprobante antes de transmitir?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes Then
                        Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Fecha").Value = Me.dtpCambiarFecha.Value
                     Else
                        Exit Sub
                     End If
                  End If

                  Me.ActualizarCAE(Me.ugDetalle.Rows(e.Cell.Row.Index), Entidades.AFIPCAE.Secuencia.SegundaVez)

                  If Me._vta IsNot Nothing Then
                     MessageBox.Show("Se recuperó el CAE " + Me._vta.AFIPCAE.CAE, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  End If

                  e.Cell.Row.Delete(False)
                  ''Me.btnConsultar.PerformClick()


            End Select

         Catch ex As Exception

            Me.tssInfo.Text = String.Empty

            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Try
               Dim ven As Reglas.Ventas = GetReglaVentas()
               ven.ActualizarCodigoErrorAFIP(actual.Sucursal.Id,
                                 Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(),
                                 Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(),
                                 Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()),
                                 Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()),
                                                 ex.Message.ToString())

            Catch ex1 As Exception
               MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try

            Try
               e.Cell.Row.Cells("CodigoErrorAfip").Value = ex.Message
               e.Cell.Row.DataErrorInfo.SetColumnError("CodigoErrorAfip", ex.Message)
            Catch ex1 As Exception
               MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try

         Finally
            ''Me.btnConsultar.PerformClick()
            Me.Cursor = Cursors.Default
         End Try

      End If
   End Sub

   Private Sub tsbConsultarUltimoComprobante_Click(sender As Object, e As EventArgs) Handles tsbConsultarUltimoComprobante.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         'If Me.ugDetalle.Rows.Count <> 0 Then
         '   Dim fr As ConsultarUltimoComprobante = New ConsultarUltimoComprobante(Me.ugDetalle.ActiveRow.Cells("Letra").Value.ToString().Trim(), _
         '                                                                               Short.Parse(Me.ugDetalle.ActiveRow.Cells("CentroEmisor").Value.ToString()))
         '   fr.ConsultarAutomaticamente = True
         '   fr.MdiParent = Me.MdiParent
         '   fr.Show()
         'End If

         Dim fr As ConsultarUltimoComprobante

         If Me.ugDetalle.Rows.Count > 0 Then

            fr = New ConsultarUltimoComprobante(Me.ugDetalle.ActiveRow.Cells("Letra").Value.ToString().Trim(),
                                                                                        Short.Parse(Me.ugDetalle.ActiveRow.Cells("CentroEmisor").Value.ToString()))
            fr.ConsultarAutomaticamente = True

         Else

            fr = New ConsultarUltimoComprobante()
            fr.ConsultarAutomaticamente = False

         End If

         fr.MdiParent = Me.MdiParent
         fr.Show()


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chbNumeroRep_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroReparto.CheckedChanged
      Me.txtNroRepartoDesde.Enabled = chbNroReparto.Checked
      Me.txtNroRepartoHasta.Enabled = chbNroReparto.Checked
      If Not Me.chbNroReparto.Checked Then
         Me.txtNroRepartoDesde.Text = ""
         Me.txtNroRepartoHasta.Text = ""
      Else
         Me.txtNroRepartoDesde.Focus()
      End If
   End Sub

   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      Me.txtNumero.Enabled = Me.chbNumero.Checked
      If Not Me.chbNumero.Checked Then
         Me.txtNumero.Text = ""
      Else
         Me.txtNumero.Focus()
      End If
   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
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

   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged

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

   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged

      Me.cmbCategoria.Enabled = Me.chbCategoria.Checked

      If Not Me.chbCategoria.Checked Then
         Me.cmbCategoria.SelectedIndex = -1
      Else
         If Me.cmbCategoria.Items.Count > 0 Then
            Me.cmbCategoria.SelectedIndex = 0
         End If

         Me.cmbCategoria.Focus()

      End If

   End Sub

   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      Me.cboLetra.Enabled = Me.chbLetra.Checked
      If Not Me.chbLetra.Checked Then
         Me.cboLetra.SelectedIndex = -1
      Else
         If Me.cboLetra.Items.Count > 0 Then
            Me.cboLetra.SelectedIndex = 0
         End If
      End If
      Me.cboLetra.Focus()

   End Sub

   Private Sub chbEmisor_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmisor.CheckedChanged
      Me.cmbEmisor.Enabled = Me.chbEmisor.Checked
      If Not Me.chbEmisor.Checked Then
         Me.cmbEmisor.SelectedIndex = -1
      Else
         If Me.cmbEmisor.Items.Count > 0 Then
            Me.cmbEmisor.SelectedIndex = 0
         End If
      End If
      Me.cmbEmisor.Focus()

   End Sub

   Private Sub btnTesteaServidorAfip_Click(sender As Object, e As EventArgs) Handles btnTesteaServidorAfip.Click
      Try

         Me.Cursor = Cursors.WaitCursor

         Me.TestGeneralesAFIP()

         Me.Cursor = Cursors.Default

         If Me._SinInternet Then
            MessageBox.Show("Sin Internet, Por favor revise la conexión y luego presione el boton de Testear Servidores AFIP para continuar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

#Region "Metodos"

   Public Overridable Sub ActualizarCAEProceso(dr As UltraGridRow, vtaNueva As Eniac.Entidades.Venta)
      'esto no hace nada, es solo para herencia.
   End Sub

   Public Sub ActualizarCAE(udr As UltraGridRow, secuencia As Entidades.AFIPCAE.Secuencia)

      If Not Publicos.HayInternet() Then
         MessageBox.Show("No tiene internet para realizar esta acción.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
         Exit Sub
      End If

      Dim oVentas = GetReglaVentas()

      Me.tssInfo.Text = "Obteniendo información del documento."
      Application.DoEvents()

      Dim dr = udr.FilaSeleccionada(Of DataRow)()

      Dim idSucursal = dr.Field(Of Integer)("IdSucursal")
      Dim idTipoComprobante = dr.Field(Of String)("IdTipoComprobante")
      Dim letra = dr.Field(Of String)("Letra")
      Dim centroEmisor = dr.Field(Of Integer)("CentroEmisor").ToShort()
      Dim numeroComprobante = dr.Field(Of Long)("NumeroComprobante")
      _vta = oVentas.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

      tssInfo.Text = "Se cargo la información del documento " + _vta.NumeroComprobante.ToString() + "."
      Application.DoEvents()

      _vta.Usuario = actual.Nombre

      _vta.IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

      _vta.Fecha = Date.Parse(udr.Cells("Fecha").Value.ToString())

      'Actualizo la Fecha de Transmision fuera del proceso normal para que no lo tome la transaccion
      'Si tiene la Fecha.. no podra anularlo.
      oVentas.ActualizarFechaTransmisionAFIP(_vta.IdSucursal,
                                             _vta.TipoComprobante.IdTipoComprobante,
                                             _vta.LetraComprobante,
                                             _vta.CentroEmisor,
                                             _vta.NumeroComprobante,
                                             Date.Now)

      tssInfo.Text = "Se actualizó la fecha de transmisión del documento Nro. " + _vta.NumeroComprobante.ToString() + "."
      Application.DoEvents()

      Try
         'actualizo el nro. de CAE
         _regCAE.ActualizarCAE(_vta, secuencia, Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)
      Catch ex As Exception ' Reglas.Ventas.ActualizaCAEException
         Dim stbMensaje = New StringBuilder(ex.Message)
         stbMensaje.AppendLine().AppendLine()
         stbMensaje.AppendFormat("¿Desea reintentar el envio del comprobante {0}?",
                                 String.Format(Entidades.Venta.FormatoPKStandard, idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante))
         If ShowPregunta(stbMensaje.ToString(), MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            Try
               ActualizarCAE(udr, Eniac.Entidades.AFIPCAE.Secuencia.SegundaVez)
               'Dim rVentas = New Reglas.Ventas()
               'rVentas.ActualizarCAE(_vta, Entidades.AFIPCAE.Secuencia.SegundaVez, Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)
            Catch ex1 As Reglas.Ventas.ActualizaCAEException
               ''''ShowError(ex1)
               'PE-42085 - Se cambia el ShowError por un Throw para cortar con la ejecución y que no exporte y envie el archivo al cliente.
               Throw
            End Try
         Else
            ''''ShowMessage("No se realizó el reenvio del comprobante. Verifique en Solicitar CAE.")
            'PE-42085 - Se cambia el ShowError por un Throw para cortar con la ejecución y que no exporte y envie el archivo al cliente.
            Throw New Exception("No se realizó el reenvio del comprobante. Verifique en Solicitar CAE.")
         End If
         'Catch
         '   Throw
      End Try

      tssInfo.Text = "Se actualizó el número de CAE."
      Application.DoEvents()

      'este codigo es para ejecutar desde los hijos que se heredan
      ActualizarCAEProceso(udr, _vta)

      tssInfo.Text = "Se actualizó el número de CAE."
      Application.DoEvents()

      'Imprime luego de solicitar
      If chbImprimeLuegoDeSolicitarCAE.Checked Then
         Dim oVentas1 = GetReglaVentas()
         Dim venta1 = oVentas1.GetUna(_vta.IdSucursal, _vta.TipoComprobante.IdTipoComprobante, _vta.LetraComprobante, _vta.CentroEmisor, _vta.NumeroComprobante)

         Dim oImpr = New Impresion(venta1)
         oImpr.ImprimirComprobanteNoFiscal(False)
      End If

      tssInfo.Text = "Se procede a armar el documento PDF."
      Application.DoEvents()

      ExportarPDF.ArmarDocumento(_vta, _asunto, _cuerpo)

      tssInfo.Text = "Se completo la actualización."
      Application.DoEvents()

   End Sub

   Private Sub RefrescarDatosGrilla()

      cmbEstados.SelectedIndex = 0
      chbPorFecha.Checked = _cantidadDiasFiltroFecha > -1

      chk_ExcluirComprobantesFalloCF.Checked = True

      If chbPorFecha.Checked Then
         dtpDesde.Value = Today.AddDays(_cantidadDiasFiltroFecha * -1)
         dtpHasta.Value = Today
      End If

      chbCliente.Checked = False

      cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      chbTodos.Checked = False

      cmbCajas.SelectedIndex = 0

      chbCambiarFecha.Checked = False

      chbNroReparto.Checked = False

      chbNumero.Checked = False
      chbVendedor.Checked = False
      chbUsuario.Checked = False
      chbFormaPago.Checked = False
      chbCategoria.Checked = False
      chbLetra.Checked = False
      chbEmisor.Checked = False

      ugDetalle.ClearFilas()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      btnConsultar.Focus()

   End Sub

   Private Sub CargarColumnasASumar()
      If Not Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Exists("ImporteTotal") Then
         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
         Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("SubTotal")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("SubTotal", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("TotalImpuestos")
         Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("TotalImpuestos", SummaryType.Sum, columnToSummarize2)
         summary2.DisplayFormat = "{0:N2}"
         summary2.Appearance.TextHAlign = HAlign.Right

         Dim columnToSummarize3 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal")
         Dim summary3 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotal", SummaryType.Sum, columnToSummarize3)
         summary3.DisplayFormat = "{0:N2}"
         summary3.Appearance.TextHAlign = HAlign.Right

         With Me.ugDetalle.DisplayLayout.Bands(0)
            Dim summary As SummarySettings
            summary = .Summaries.Add("TotalPercepcion", SummaryType.Sum, .Columns("TotalPercepcion"))
            summary.DisplayFormat = "{0:N2}"
            summary.Appearance.TextHAlign = HAlign.Right
            summary = .Summaries.Add("TotalIVA", SummaryType.Sum, .Columns("TotalIVA"))
            summary.DisplayFormat = "{0:N2}"
            summary.Appearance.TextHAlign = HAlign.Right

            summary = .Summaries.Add("TotalImpuestoInterno", SummaryType.Sum, .Columns("TotalImpuestoInterno"))
            summary.DisplayFormat = "{0:N2}"
            summary.Appearance.TextHAlign = HAlign.Right
         End With

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"
      End If

   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oVenta As Reglas.Ventas = GetReglaVentas()

         Dim Estado As Entidades.AFIPCAE.EstadoElectronicos

         Dim fechaDesde As Date = Nothing
         Dim fechahasta As Date = Nothing

         Dim IdCliente As Long = 0

         'Dim IdTipoComprobante As String = String.Empty

         Dim NumeroRepartoDesde As Integer = 0
         Dim NumeroRepartoHasta As Integer = 0

         Dim Letra As String = ""
         Dim emisor As Integer = 0
         Dim NumeroComprobante As Long = 0

         Dim IdCategoria As Integer = 0

         Dim IdUsuario As String = String.Empty

         Dim IdVendedor As Integer = 0

         Dim IdFormasPago As Integer = 0

         'If Me.cmbTiposComprobantes.Enabled Then
         '   IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         'End If

         Select Case Me.cmbEstados.Text
            Case "Con CAE"
               Estado = Entidades.AFIPCAE.EstadoElectronicos.ConCAE
            Case "Sin CAE"
               Estado = Entidades.AFIPCAE.EstadoElectronicos.SinCAE
            Case "Todos"
               Estado = Entidades.AFIPCAE.EstadoElectronicos.Todos
         End Select

         If Me.chbPorFecha.Checked Then
            fechaDesde = Me.dtpDesde.Value
            fechahasta = Me.dtpHasta.Value
         End If

         If Me.chbCliente.Checked Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.chbNroReparto.Checked Then
            NumeroRepartoDesde = Integer.Parse(Me.txtNroRepartoDesde.Text.ToString())
            NumeroRepartoHasta = Integer.Parse(Me.txtNroRepartoHasta.Text.ToString())
         End If

         If Me.chbNumero.Checked Then
            NumeroComprobante = Long.Parse(Me.txtNumero.Text)
         End If

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.cmbFormaPago.Enabled Then
            IdFormasPago = Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
         End If

         If Me.cmbUsuario.Enabled Then
            IdUsuario = Me.cmbUsuario.SelectedValue.ToString()
         End If

         If Me.cmbCategoria.Enabled Then
            IdCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         If Me.cboLetra.Enabled Then
            Letra = Me.cboLetra.SelectedValue.ToString()
         End If

         If Me.cmbEmisor.Enabled Then
            emisor = Integer.Parse(Me.cmbEmisor.SelectedValue.ToString())
         End If


         Dim dtDetalle As DataTable
         Dim dt As DataTable
         Dim drCl As DataRow

         dtDetalle = oVenta.GetComprobantesElectronicos(Estado,
                                                        fechaDesde, fechahasta,
                                                        IdCliente,
                                                        NumeroRepartoDesde, NumeroRepartoHasta,
                                                        cmbTiposComprobantes.GetTiposComprobantes(),
                                                        Letra,
                                                        emisor,
                                                        NumeroComprobante,
                                                        IdCategoria,
                                                        IdUsuario,
                                                        IdVendedor,
                                                        IdFormasPago,
                                                        _nroRepartoInvocacionMasiva)

         chbTodos.Checked = (dtDetalle.Rows.Count > 0) AndAlso Reglas.Publicos.SolicitarCAESeleccionarTodos

         dt = CrearDT()
         Dim check = Reglas.Publicos.SolicitarCAESeleccionarTodos
         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("Ver") = "..."
            drCl("Check") = check
            'drCl("colObtenerCAE") = ""
            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("DescripcionAbrev") = dr("DescripcionAbrev").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
            drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
            drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
            drCl("TipoDocCliente") = dr("TipoDocCliente").ToString()
            drCl("NroDocCliente") = dr("NroDocCliente")
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal").ToString()
            drCl("FormaDePago") = dr("FormaDePago").ToString()
            drCl("SubTotal") = Decimal.Parse(dr("SubTotal").ToString())
            drCl("TotalImpuestos") = Decimal.Parse(dr("TotalImpuestos").ToString())
            drCl("TotalPercepcion") = Decimal.Parse(dr("TotalPercepcion").ToString())
            drCl("TotalIVA") = Decimal.Parse(dr("TotalIVA").ToString())
            drCl("TotalImpuestoInterno") = dr("TotalImpuestoInterno")
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())
            If Not String.IsNullOrEmpty(dr("CUIT").ToString()) Then
               drCl("CUIT") = Long.Parse(dr("CUIT").ToString())
            End If
            If Not String.IsNullOrEmpty(dr("CAE").ToString()) Then
               drCl("CAE") = dr("CAE").ToString()
            End If
            If Not String.IsNullOrEmpty(dr("CAEVencimiento").ToString()) Then
               drCl("CAEVencimiento") = dr("CAEVencimiento").ToString()
            End If
            'drCl("colPDF") = ""
            'drCl("colControlarInfo") = ""
            drCl("Usuario") = dr("Usuario").ToString()
            drCl("Observacion") = dr("Observacion").ToString()
            drCl("IdSucursal") = Integer.Parse(dr("IdSucursal").ToString())
            If Not String.IsNullOrEmpty(dr("CodigoErrorAfip").ToString()) Then
               drCl("CodigoErrorAfip") = dr("CodigoErrorAfip").ToString()
            End If

            drCl("NombreVendedor") = dr("NombreVendedor")

            If chk_ExcluirComprobantesFalloCF.Checked Then
               If ValidaComprobanteFalloCF(dr) Then
                  dt.Rows.Add(drCl)
               End If
            Else
               dt.Rows.Add(drCl)
            End If

         Next

         Me.ugDetalle.DataSource = dt

         For Each dr As UltraGridRow In Me.ugDetalle.Rows
            If Not String.IsNullOrEmpty(dr.Cells("CodigoErrorAfip").Value.ToString()) Then
               dr.DataErrorInfo.SetColumnError("CodigoErrorAfip", dr.Cells("CodigoErrorAfip").Value.ToString())
            End If
         Next

         ugDetalle.DisplayLayout.Bands(0).Columns("TotalImpuestoInterno").Hidden = dt.Select("TotalImpuestoInterno <> 0").Length = 0

         'Como se hicieron más anchas las columnas de Neto e IVA, cuando mostramos las columnas de Impuestos Internos
         'debo achicar la columna de nombre de cliente para que se vean todos los importes. El ancho que se le agregó
         'a las mismas suma 20, por lo que le sacamos esos 20 al cliente.
         If ugDetalle.DisplayLayout.Bands(0).Columns("TotalImpuestoInterno").Hidden Then
            ugDetalle.DisplayLayout.Bands(0).Columns("NombreCliente").Width = anchoColumnaNombreCliente
         Else
            ugDetalle.DisplayLayout.Bands(0).Columns("NombreCliente").Width = anchoColumnaNombreCliente - 20
         End If

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   Private Function ValidaComprobanteFalloCF(dr As DataRow) As Boolean
      Dim resp = True
      Dim eCatFiscal = New Reglas.CategoriasFiscales().GetUno(Short.Parse(dr("IdCategoriaFiscal").ToString()))

      If Decimal.Parse(dr("ImporteTotal").ToString()) > Reglas.Publicos.Facturacion.FacturacionControlaTopeCF AndAlso
               eCatFiscal.EsPasiblePercIIBB = False AndAlso eCatFiscal.IvaDiscriminado = False AndAlso eCatFiscal.SolicitaCUIT = False AndAlso
               String.IsNullOrEmpty(dr("NroDocCliente").ToString()) Then
         resp = False
      End If
      Return resp
   End Function
   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         .Columns.Add("Check", GetType(Boolean))
         '.Columns.Add("colObtenerCAE")
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("DescripcionAbrev", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Integer))
         .Columns.Add("NumeroComprobante", GetType(Long))
         .Columns.Add("Fecha", GetType(Date))
         .Columns.Add("TipoDocCliente", GetType(String))
         .Columns.Add("NroDocCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("CUIT", GetType(Long))
         .Columns.Add("NombreCategoriaFiscal", GetType(String))
         .Columns.Add("FormaDePago", GetType(String))
         .Columns.Add("SubTotal", GetType(Decimal))
         .Columns.Add("TotalImpuestos", GetType(Decimal))
         .Columns.Add("TotalPercepcion", GetType(Decimal))
         .Columns.Add("TotalIVA", GetType(Decimal))
         .Columns.Add("TotalImpuestoInterno", GetType(Decimal))
         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("CAE", GetType(String))
         .Columns.Add("CAEVencimiento", GetType(Date))
         '.Columns.Add("colPDF")
         '.Columns.Add("colControlarInfo")
         .Columns.Add("Usuario", GetType(String))
         .Columns.Add("Observacion", GetType(String))
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("CodigoErrorAfip", GetType(String))
         .Columns.Add("NombreVendedor", GetType(String))
      End With

      Return dtTemp

   End Function

   Private Sub CambiarFechaComprobantes()
      For Each dr In ugDetalle.Rows
         If Boolean.Parse(dr.Cells("Check").Value.ToString()) Then
            dr.Cells("Fecha").Value = dtpCambiarFecha.Value
         End If
      Next
      Me.ugDetalle.Update()
   End Sub


   Private Sub TestGeneralesAFIP()

      pcbInternet.Image = My.Resources.server_cancel_48
      pcbAFIP.Image = My.Resources.server_cancel_48

      ugDetalle.DisplayLayout.Bands(0).Columns("ObtenerCAE").CellActivation = Activation.Disabled
      ugDetalle.DisplayLayout.Bands(0).Columns("ControlarInfo").CellActivation = Activation.Disabled

      tsbObtenerCAEs.Enabled = False

      If Publicos.HayInternet() Then
         pcbInternet.Image = My.Resources.server_ok_48

         Dim estados = New List(Of String)
         Dim reg As Reglas.AFIPFE = New Reglas.AFIPFE()
         estados.AddRange(reg.TestearServidoresV1().Split("/"c))
         If New Reglas.Impresoras().AlgunaUsaBonos() Then
            'If Reglas.Publicos.UtilizaBonosFiscalesElectronicos Then
            Dim reg1 = New Reglas.AFIPBFE()
            estados.AddRange(reg1.TestearServidoresV1().Split("/"c))
         End If

         'estados(0) -> Servidor Autorización      'estados(1) -> Servidor Aplicación     'estados(2) -> Servidor Base de Datos

         If estados.All(Function(x) x = "OK") Then ' estados(0) = "OK" And estados(1) = "OK" And estados(2) = "OK" Then
            pcbAFIP.Image = My.Resources.server_ok_48
            ugDetalle.DisplayLayout.Bands(0).Columns("ObtenerCAE").CellActivation = Activation.AllowEdit
            ugDetalle.DisplayLayout.Bands(0).Columns("ControlarInfo").CellActivation = Activation.AllowEdit
            tsbObtenerCAEs.Enabled = True
            pcbInternet.Image = My.Resources.server_ok_48
            pcbAFIP.Image = My.Resources.server_ok_48
         End If


         _SinInternet = False
      Else
         _SinInternet = True
      End If

   End Sub

#End Region

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click

      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class