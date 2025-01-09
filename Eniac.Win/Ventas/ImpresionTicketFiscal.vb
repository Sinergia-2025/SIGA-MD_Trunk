Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Eniac.Entidades.Entidad


Public Class ImpresionTicketFiscal

#Region "Campos"

   Private _publicos As Publicos
   Private _vta As Entidades.Venta
   Private _estaCargando As Boolean = True
   Private _Sucursal As Integer = 0
   Private _Comprobante As String = ""
   Private _Letra As String = ""
   Private _Emisor As Short = 0
   Private _NumeroComprobante As Long = 0
   Public Property ConsultarAutomaticamente As Boolean = False
   Private _NumeroRepartoDesde As Integer
   Private _NumeroRepartoHasta As Integer

   Private _cantidadDiasFiltroFecha As Integer
   Private _fc As FacturacionComunes
   'Private _CtrlInfo As Boolean

#End Region

#Region "Constructores"
   Public Sub New()
      Me.InitializeComponent()
   End Sub

   'Public Sub New(ByVal NumeroRepartoDesde As Integer, NumeroRepartoHasta As Integer)

   '   Me.New()

   '   Me._NumeroRepartoDesde = NumeroRepartoDesde
   '   Me._NumeroRepartoHasta = NumeroRepartoHasta

   'End Sub

#End Region

#Region "Overrides"

   Protected Overridable Function GetReglaVentas() As Reglas.Ventas
      Return New Reglas.Ventas()
   End Function

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboTiposComprobantesElectronicos(Me.cmbTiposComprobantes, "TODOS")
         Me.cmbTiposComprobantes.SelectedIndex = -1

         Me.cmbEstados.SelectedIndex = 0

         _cantidadDiasFiltroFecha = Reglas.Publicos.SolicitarCAECantidadDiasFiltroFecha
         Me.chbPorFecha.Checked = _cantidadDiasFiltroFecha > -1

         If chbPorFecha.Checked Then
            dtpDesde.Value = Today.AddDays(_cantidadDiasFiltroFecha * -1)
            dtpHasta.Value = Today
         End If

         'Me.dtpDesde.Value = Date.Today.AddDays(-5)  'Limite del AFIP para transmitir comprobantes.
         'Me.dtpHasta.Value = Date.Today

         Me._fc = New FacturacionComunes()

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1

         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         Me.cmbFormaPago.SelectedIndex = -1

         Me._publicos.CargaComboUsuarios(Me.cmbUsuario)

         With Me.cboLetra
            .DisplayMember = "LetraFiscal"
            .ValueMember = "LetraFiscal"
            .DataSource = New Reglas.VentasNumeros().GetLetrasFiscales()
            .SelectedIndex = -1
         End With

         With Me.cmbEmisor
            .DisplayMember = "CentroEmisor"
            .ValueMember = "CentroEmisor"
            .DataSource = New Reglas.VentasNumeros().GetCentrosEmisores()
            .SelectedIndex = -1
         End With

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)


         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = True, blnCajasModificables As Boolean = True
         Me._publicos.CargaComboCajas(Me.cmbCajas, actual.Sucursal.IdSucursal, blnMiraUsuario, blnMiraPC, blnCajasModificables)

         Me.CargarColumnasASumar()

         Me._estaCargando = False

         Try
            Me.Cursor = Cursors.Default
         Catch ex As Exception
            ShowError(ex)
         End Try

         anchoColumnaNombreCliente = ugDetalle.DisplayLayout.Bands(0).Columns("NombreCliente").Width

         'Seguridad del campo Precio de Costo
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         'Me._CtrlInfo = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ImpresionTicketFiscal-CtrlInfo")

         If ConsultarAutomaticamente Then
            Me.btnConsultar.PerformClick()
         End If

         ugDetalle.DisplayLayout.Bands(0).Columns("TotalPercepcion").Hidden = Not Reglas.Publicos.RetieneIIBB
         ugDetalle.DisplayLayout.Bands(0).Columns("TotalImpuestoInterno").Hidden = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private anchoColumnaNombreCliente As Integer

#End Region

#Region "Eventos"

   Private Sub SolicitarCAE_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar.PerformClick()
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

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            Me.cmbTiposComprobantes.SelectedIndex = -1
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

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

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


         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         Try

            Me.Cursor = Cursors.Default


         Catch ex As Exception
            ShowError(ex)
         End Try

         If Me.ugDetalle.Rows.Count > 0 Then
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

   Private Sub chbPorFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPorFecha.CheckedChanged
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

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

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

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion

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

   Private Sub tsbImprimirTickets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimirTickets.Click

      Dim i As Integer = 0
      Dim progreso As Integer
      Dim total As Integer = 0

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.ugDetalle.UpdateData()

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
            Me.tssInfo.Text = "Imprimiendo ...  " + dr.Cells("DescripcionAbrev").Value.ToString() + "-" + _
               dr.Cells("Letra").Value.ToString() + "-" + dr.Cells("CentroEmisor").Value.ToString() + "-" + _
            dr.Cells("NumeroComprobante").Value.ToString() + " -  " + dr.Cells("NombreCliente").Value.ToString()

            Me._Sucursal = Integer.Parse(dr.Cells("IdSucursal").Value.ToString())
            Me._Comprobante = dr.Cells("IdTipoComprobante").Value.ToString()
            Me._Letra = dr.Cells("Letra").Value.ToString()
            Me._Emisor = Short.Parse(dr.Cells("CentroEmisor").Value.ToString())
            Me._NumeroComprobante = Long.Parse(dr.Cells("NumeroComprobante").Value.ToString())

            Try

               Me.ImprimirTicket(dr)

               dr.Delete(False)
               Application.DoEvents()

            Catch ex As Exception
               Try
                  Me.tssInfo.Text = String.Empty
                  Application.DoEvents()
                  dr.Cells("CodigoErrorAfip").Value = ex.Message
                  dr.DataErrorInfo.SetColumnError("CodigoErrorAfip", ex.Message)
               Catch ex1 As Exception
                  MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               End Try
               Throw ex
            End Try

            i += 1
         Next

         Me.tspBarra.Value = 0


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Dim ven As Reglas.Ventas = GetReglaVentas()
         ven.ActualizarCodigoErrorAFIP(Me._Sucursal, Me._Comprobante, Me._Letra, Me._Emisor, Me._NumeroComprobante, ex.Message.ToString())

      Finally
         MessageBox.Show("Se imprimieron " + i.ToString() + " comprobantes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.tspBarra.Visible = False
         Me.tssInfo.Text = String.Empty

         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub cmbEstados_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstados.SelectedIndexChanged

      Try

         If Me._estaCargando Then Exit Sub

         Select Case Me.cmbEstados.Text
            Case "Sin CAE"
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("ObtenerCAE").Hidden = False
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("Check").Hidden = False
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("ControlarInfo").Hidden = False
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("CAE").Hidden = True
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("CAEVencimiento").Hidden = True
               Me.tsbImprimirTickets.Visible = True
            Case "Con CAE"
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("ObtenerCAE").Hidden = True
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("Check").Hidden = True
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("ControlarInfo").Hidden = True
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("CAE").Hidden = False
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("CAEVencimiento").Hidden = False
               Me.tsbImprimirTickets.Visible = False
            Case "Todos"
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("ObtenerCAE").Hidden = True
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("Check").Hidden = True
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("ControlarInfo").Hidden = True
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("CAE").Hidden = False
               Me.ugDetalle.DisplayLayout.Bands(0).Columns("CAEVencimiento").Hidden = False
               Me.tsbImprimirTickets.Visible = False
         End Select

         Me.btnConsultar.PerformClick()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged

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

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton

      If e.Cell.Row.Index <> -1 Then
         Try
            Me.Cursor = Cursors.WaitCursor

            Dim oVentas As Reglas.Ventas = GetReglaVentas()
            Dim venta As Entidades.Venta = oVentas.GetUna(actual.Sucursal.Id, _
                        Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(), _
                        Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(), _
                        Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()), _
                        Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()))

            venta.Usuario = Entidades.Usuario.Actual.Nombre

            venta.IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

            venta.Fecha = Date.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Fecha").Value.ToString())

            Select Case e.Cell.Column.Key

               Case "Ver"

                  Dim oImpr As Impresion = New Impresion(venta)

                  If venta.Impresora.TipoImpresora = "NORMAL" Then
                     oImpr.ImprimirComprobanteNoFiscal(True)
                  Else
                     oImpr.ReImprimirComprobanteFiscal()
                  End If

               Case "ObtenerCAE"

                  Me.Cursor = Cursors.WaitCursor

                  Dim ComprobanteFiscal As Entidades.Venta = oVentas.ArmarComprobanteFiscal(venta)

                  Try
                     If Me._fc.ImprimirComprobante(ComprobanteFiscal, venta.TipoComprobante.EsFiscal) Then
                        Try
                           '''''Si la impresion fue ok grabo el TICKET FISCAL
                           oVentas.GrabarComprobanteFiscal(venta, ComprobanteFiscal, MetodoGrabacion.Manual, Me.IdFuncion)

                           e.Cell.Row.Delete(False)

                        Catch ex As Reglas.Ventas.ActualizaCAEException
                           MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Catch
                           MessageBox.Show("Error en la grabación del comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Try
                     End If
                  Catch ex As Exception
                     Try
                        Dim ven As Reglas.Ventas = GetReglaVentas()
                        ven.ActualizarCodigoErrorAFIP(actual.Sucursal.Id, _
                                          Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(), _
                                          Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(), _
                                          Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()), _
                                          Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()), _
                                                          ex.Message.ToString())

                     Catch ex1 As Exception
                        MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     End Try

                     Try
                        e.Cell.Row.Cells("CodigoErrorAfip").Value = ex.Message
                        e.Cell.Row.DataErrorInfo.SetColumnError("CodigoErrorAfip", ex.Message)
                     Catch ex1 As Exception
                        MessageBox.Show("Error en la impresión Fiscal.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                     End Try
                  End Try

               Case "ControlarInfo"

                  Me.Cursor = Cursors.WaitCursor

                  Dim numeroPapel As Long = 0
                  If IsNumeric(e.Cell.Row.Cells("NumeroComprobanteFiscal").Value) Then
                     numeroPapel = Long.Parse(e.Cell.Row.Cells("NumeroComprobanteFiscal").Value.ToString())
                  End If

                  Using frm As New ImpresionTicketFiscalConfirmar(venta, numeroPapel)
                     If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

                        Dim nuevoComprobanteFiscal As Entidades.Venta = oVentas.ArmarComprobanteFiscal(venta)

                        nuevoComprobanteFiscal.NumeroComprobante = frm.NuevoNumeroComprobante

                        'If MessageBox.Show("Esta seguro de reemplazar Pre-Ticket por Ticket Fiscal con número de comprobante: " & Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobanteFiscal").Value.ToString() & " ?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then

                        oVentas.GrabarComprobanteFiscal(venta, nuevoComprobanteFiscal, MetodoGrabacion.Manual, Me.IdFuncion)

                        e.Cell.Row.Delete(False)

                        'End If

                     End If
                  End Using

                  'If Not String.IsNullOrEmpty(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobanteFiscal").Value.ToString()) Then

                  '   Dim ComprobanteFiscal As Entidades.Venta = oVentas.ArmarComprobanteFiscal(venta)

                  '   ComprobanteFiscal.NumeroComprobante = Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobanteFiscal").Value.ToString())

                  '   If MessageBox.Show("Esta seguro de reemplazar Pre-Ticket por Ticket Fiscal con número de comprobante: " & Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobanteFiscal").Value.ToString() & " ?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then

                  '      oVentas.GrabarComprobanteFiscal(venta, ComprobanteFiscal, MetodoGrabacion.Manual, Me.IdFuncion)

                  '      e.Cell.Row.Delete(False)

                  '   End If
                  'End If

            End Select

         Catch ex As Exception

            Me.tssInfo.Text = String.Empty

            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Try
            '   Dim ven As Reglas.Ventas = GetReglaVentas()
            '   ven.ActualizarCodigoErrorAFIP(actual.Sucursal.Id, _
            '                     Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("IdTipoComprobante").Value.ToString(), _
            '                     Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("Letra").Value.ToString(), _
            '                     Short.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CentroEmisor").Value.ToString()), _
            '                     Long.Parse(Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("NumeroComprobante").Value.ToString()), _
            '                                     ex.Message.ToString())

            'Catch ex1 As Exception
            '   MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End Try

            'Try
            '   e.Cell.Row.Cells("CodigoErrorAfip").Value = ex.Message
            '   e.Cell.Row.DataErrorInfo.SetColumnError("CodigoErrorAfip", ex.Message)
            'Catch ex1 As Exception
            '   MessageBox.Show(ex1.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End Try

         Finally
            ''Me.btnConsultar.PerformClick()
            Me.Cursor = Cursors.Default
         End Try

      End If
   End Sub

   Private Sub tsbConsultarUltimoComprobante_Click(sender As Object, e As EventArgs)
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

            fr = New ConsultarUltimoComprobante(Me.ugDetalle.ActiveRow.Cells("Letra").Value.ToString().Trim(), _
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

   Private Sub chbCategoria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCategoria.CheckedChanged

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


#End Region

#Region "Metodos"


   Public Sub ImprimirTicket(ByVal dr As UltraGridRow)

      Dim oVentas As Reglas.Ventas = GetReglaVentas()

      Me.tssInfo.Text = "Obteniendo información del comprobante."
      Application.DoEvents()

      Me._vta = oVentas.GetUna(Integer.Parse(dr.Cells("IdSucursal").Value.ToString()), _
                                               dr.Cells("IdTipoComprobante").Value.ToString(), _
                                               dr.Cells("Letra").Value.ToString(), _
                                               Short.Parse(dr.Cells("CentroEmisor").Value.ToString()), _
                                               Long.Parse(dr.Cells("NumeroComprobante").Value.ToString()))

      _vta.Usuario = Entidades.Usuario.Actual.Nombre

      _vta.IdCaja = Integer.Parse(Me.cmbCajas.SelectedValue.ToString())

      _vta.Fecha = Date.Parse(dr.Cells("Fecha").Value.ToString())

      Me.tssInfo.Text = "Se cargo la información del comprobante " + Me._vta.NumeroComprobante.ToString() + "."
      Application.DoEvents()


      Dim ComprobanteFiscal As Entidades.Venta = oVentas.ArmarComprobanteFiscal(_vta)

      Try
         If Me._fc.ImprimirComprobante(ComprobanteFiscal, _vta.TipoComprobante.EsFiscal) Then
            Try

               'Guardo numero de comprobante por si falla la grabacion del TICKET
               oVentas.ActualizaNumeroComprobanteFiscal(_vta.IdSucursal, _vta.TipoComprobante.IdTipoComprobante, _
                                                   _vta.LetraComprobante, _vta.Impresora.CentroEmisor, _
                                                   _vta.NumeroComprobante, ComprobanteFiscal.NumeroComprobante)


               Me.tssInfo.Text = "Imprimiendo comprobante."
               Application.DoEvents()
               '''''Si la impresion fue ok grabo el TICKET FISCAL
               oVentas.GrabarComprobanteFiscal(_vta, ComprobanteFiscal, MetodoGrabacion.Manual, Me.IdFuncion)

               Me.tssInfo.Text = "Grabando comprobante definitivo."
               Application.DoEvents()

            Catch ex As Reglas.Ventas.ActualizaCAEException
               Throw
            End Try
         End If
      Catch ex As Exception
         oVentas.ActualizarCodigoErrorAFIP(_vta.IdSucursal, _vta.TipoComprobante.IdTipoComprobante, _
                                          _vta.LetraComprobante, _vta.Impresora.CentroEmisor, _
                                          _vta.NumeroComprobante, ex.Message.ToString())

         Throw
      End Try

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.cmbEstados.SelectedIndex = 0
      Me.chbPorFecha.Checked = _cantidadDiasFiltroFecha > -1

      If chbPorFecha.Checked Then
         dtpDesde.Value = Today.AddDays(_cantidadDiasFiltroFecha * -1)
         dtpHasta.Value = Today
      End If

      Me.chbCliente.Checked = False

      Me.chbTipoComprobante.Checked = False

      Me.chbTodos.Checked = False


      Me.chbNroReparto.Checked = False

      Me.chbNumero.Checked = False
      Me.chbVendedor.Checked = False
      Me.chbUsuario.Checked = False
      Me.chbFormaPago.Checked = False
      Me.chbCategoria.Checked = False
      Me.chbLetra.Checked = False
      Me.chbEmisor.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.btnConsultar.Focus()

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

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

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

         Dim IdTipoComprobante As String = String.Empty

         Dim NumeroRepartoDesde As Integer = 0
         Dim NumeroRepartoHasta As Integer = 0

         Dim Letra As String = ""
         Dim emisor As Integer = 0
         Dim NumeroComprobante As Long = 0

         Dim IdCategoria As Integer = 0

         Dim IdUsuario As String = String.Empty

         Dim IdVendedor As Integer = 0

         Dim IdFormasPago As Integer = 0

         If Me.cmbTiposComprobantes.Enabled Then
            IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

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

         dtDetalle = oVenta.GetComprobantesFiscales(Estado, _
                                                        fechaDesde, fechahasta, _
                                                        IdCliente, _
                                                        NumeroRepartoDesde, NumeroRepartoHasta, _
                                                        IdTipoComprobante, _
                                                        Letra, _
                                                        emisor, _
                                                        NumeroComprobante, _
                                                        IdCategoria, _
                                                        IdUsuario, _
                                                        IdVendedor,
                                                        IdFormasPago)

         Me.chbTodos.Checked = (dtDetalle.Rows.Count > 0) AndAlso Reglas.Publicos.SolicitarCAESeleccionarTodos

         dt = Me.CrearDT()
         Dim check As Boolean = Reglas.Publicos.SolicitarCAESeleccionarTodos
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

            If Not String.IsNullOrEmpty(dr("CantidadReintentosImpresion").ToString()) Then
               drCl("CantidadReintentosImpresion") = Integer.Parse(dr("CantidadReintentosImpresion").ToString())
            End If

            If Not String.IsNullOrEmpty(dr("NumeroComprobanteFiscal").ToString()) Then
               drCl("NumeroComprobanteFiscal") = Integer.Parse(dr("NumeroComprobanteFiscal").ToString())
            End If

            drCl("NombreVendedor") = dr("NombreVendedor")



            dt.Rows.Add(drCl)

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

         'If Not _CtrlInfo Then
         '   ugDetalle.DisplayLayout.Bands(0).Columns("ControlarInfo").CellActivation = Activation.Disabled
         'Else
         '   'For Each dr As UltraGridRow In Me.ugDetalle.Rows
         '   '   If Not String.IsNullOrEmpty(dr.Cells("NumeroComprobanteFiscal").Value.ToString()) Then
         '   '      dr.Cells("NumeroComprobanteFiscal").Activation = Activation.AllowEdit
         '   '      dr.Cells("ControlarInfo").Activation = Activation.ActivateOnly
         '   '   Else
         '   '      dr.Cells("ControlarInfo").Activation = Activation.Disabled
         '   '   End If
         '   'Next
         'End If

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
         .Columns.Add("Ver")
         .Columns.Add("Check", System.Type.GetType("System.Boolean"))
         '.Columns.Add("colObtenerCAE")
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAbrev", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("TipoDocCliente", System.Type.GetType("System.String"))
         .Columns.Add("NroDocCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("CUIT", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
         .Columns.Add("FormaDePago", System.Type.GetType("System.String"))
         .Columns.Add("SubTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalImpuestos", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalPercepcion", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalIVA", System.Type.GetType("System.Decimal"))
         .Columns.Add("TotalImpuestoInterno", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("CAE", System.Type.GetType("System.String"))
         .Columns.Add("CAEVencimiento", System.Type.GetType("System.DateTime"))
         '.Columns.Add("colPDF")
         '.Columns.Add("colControlarInfo")
         .Columns.Add("Usuario", System.Type.GetType("System.String"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
         .Columns.Add("IdSucursal", System.Type.GetType("System.Int32"))
         .Columns.Add("CodigoErrorAfip", System.Type.GetType("System.String"))
         .Columns.Add("NombreVendedor", GetType(String))
         .Columns.Add("CantidadReintentosImpresion", GetType(Integer))
         .Columns.Add("NumeroComprobanteFiscal", GetType(Long))

      End With

      Return dtTemp

   End Function

#End Region

End Class