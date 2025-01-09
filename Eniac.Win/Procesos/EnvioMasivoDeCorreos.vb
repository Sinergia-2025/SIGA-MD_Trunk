Option Explicit On
Option Strict On

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Data
Imports System.IO
Imports System.ComponentModel
Imports Eniac.Reglas.VentasEnvioMasivoMails

#End Region

Public Class EnvioMasivoDeCorreos

#Region "Campos"

   Private _publicos As Win.Publicos
   Private _expensas As DataTable
   Private _conceptos As DataTable
   Private _adicionales As DataTable
   Private _voucher As DataTable
   Private _expensasMail As DataTable
   Private _adicionalesMail As DataTable
   Private _voucherMail As DataTable
   Private Const selecColumnName As String = "Envio"
   Private _dtDetalle As DataTable
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         If (Not Me.ValidarCorreo()) Then
            ShowMessage("No se podrán enviar las facturas hasta que " + Environment.NewLine + "se completen los datos del Correo Electronico " + Environment.NewLine + "(Configuraciones -> Parametros del Sistema)")
         End If

         Me._publicos = New Win.Publicos()
         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnum))
         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1

         Me._publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         Me._publicos.CargaComboCategorias(Me.cmbCategoria)

         Me._publicos.CargaComboListaDePrecios(Me.cmbListaDePrecios)
         Me.cmbListaDePrecios.SelectedIndex = -1

         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
         Me.cmbFormaPago.SelectedIndex = -1

         Me.cmbActivo.Items.Insert(0, "TODOS")
         Me.cmbActivo.Items.Insert(1, "SI")
         Me.cmbActivo.Items.Insert(2, "NO")
         Me.cmbActivo.SelectedIndex = 0

         Me.cmbRecibeNotificaciones.Items.Insert(0, "TODOS")
         Me.cmbRecibeNotificaciones.Items.Insert(1, "SI")
         Me.cmbRecibeNotificaciones.Items.Insert(2, "NO")
         Me.cmbRecibeNotificaciones.SelectedIndex = 1

         Me._publicos.CargaComboDesdeEnum(cmbConfiguracionMail, GetType(Entidades.Cliente.ConfiguracionMail), , True)
         Me.cmbConfiguracionMail.SelectedValue = Publicos.ConfiguraciónMail

         Me.txtCopiaOculta.Text = Reglas.Publicos.Facturacion.FacturacionEnvioMailCopiaOculta
         Me.chbCopiaOculta.Checked = Not String.IsNullOrWhiteSpace(txtCopiaOculta.Text)

         'Dim columnToSummarize As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImportePrimerVto")
         'Dim summary As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImportePrimerVto", SummaryType.Sum, columnToSummarize)
         'summary.DisplayFormat = "Exp. = {0:c}"
         'summary.Appearance.TextHAlign = HAlign.Left

         '# Solo aplica para aplicación SISEN
         CargarComboEmbarcaciones()
         If Publicos.IDAplicacionSinergia = "SISEN" Then
            Me.lblEmbarcaciones.Visible = True
            Me.cmbEmbarcaciones.Visible = True
         End If

         FormatearGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub EnvioMasivoDeCorreos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = String.Empty

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If

         Me.cmbVendedor.Focus()

      End If

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

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked

      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()

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

   Private Sub chbListaDePrecios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbListaDePrecios.CheckedChanged

      Me.cmbListaDePrecios.Enabled = Me.chbListaDePrecios.Checked

      If Not Me.chbListaDePrecios.Checked Then
         Me.cmbListaDePrecios.SelectedIndex = -1
      Else
         If Me.cmbListaDePrecios.Items.Count > 0 Then
            Me.cmbListaDePrecios.SelectedIndex = 0
         End If

         Me.cmbListaDePrecios.Focus()

      End If

   End Sub

   Private Sub chbFormaPago_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbFormaPago.CheckedChanged
      Me.cmbFormaPago.Enabled = Me.chbFormaPago.Checked
      If Not Me.chbFormaPago.Checked Then
         Me.cmbFormaPago.SelectedIndex = -1
      Else
         If Me.cmbFormaPago.Items.Count > 0 Then
            Me.cmbFormaPago.SelectedIndex = 0
         End If
         Me.cmbFormaPago.Focus()
      End If
   End Sub

   Private Sub chbDescuentoRecargo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbDescuentoRecargo.CheckedChanged
      Me.txtDescuentoRecargoPorc.Enabled = Me.chbDescuentoRecargo.Checked
      If Not Me.chbDescuentoRecargo.Checked Then
         Me.txtDescuentoRecargoPorc.Text = "0.00"
      Else
         Me.txtDescuentoRecargoPorc.Focus()
      End If
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: No seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.tsbEnviarCorreos.Enabled = True

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         Me.cmbTodos.SelectedIndex = 0
         If ugDetalle.Rows.Count > 0 Then

            'Me.txtAsuntoMail.Text = Publicos.NombreEmpresa & " - Expensa del Periodo: " & Me.dtpPeriodo.Text

            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = String.Empty
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub ugDetalle_CellChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.CellChange
      If e.Cell.Row.Index <> -1 AndAlso e.Cell.Column.ToString() = "Envio" Then
         If Me.ugDetalle.Rows(e.Cell.Row.Index).Cells("CorreoElectronico").Text = "" Then
            MessageBox.Show("NO puede Seleccionarlo porque NO tiene Correo Electronico !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.ugDetalle.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Value = False
         End If
      End If
      ugDetalle.UpdateData()
   End Sub

   Private Sub btnExpandirHtml_Click(sender As Object, e As EventArgs) Handles btnExpandirHtml.Click
      Using frm As EditorHtml = New EditorHtml(rtbCuerpoMail.BodyHtml)
         If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            rtbCuerpoMail.BodyHtml = frm.BodyHTML
         End If
      End Using
   End Sub

   Private Sub btnExaminar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar1.Click
      Me.ExaminarArchivo(1)
   End Sub

   Private Sub btnExaminar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar2.Click
      Me.ExaminarArchivo(2)
   End Sub

   Private Sub btnExaminar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar3.Click
      Me.ExaminarArchivo(3)
   End Sub

   Private Sub btnExaminar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar4.Click
      Me.ExaminarArchivo(4)
   End Sub

   Private Sub tsbEnviarCorreos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEnviarCorreos.Click

      Try

         ugDetalle.UpdateData()

         If (ValidarCorreo()) Then

            Me.Cursor = Cursors.WaitCursor

            If String.IsNullOrEmpty(Me.txtAsuntoMail.Text) Then
               MessageBox.Show("ATENCION: Debe ingresar el Asunto del Correo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.txtAsuntoMail.Focus()
               Exit Sub
            End If

                'If String.IsNullOrEmpty(Me.rtbCuerpoMail.Text) Then

                If String.IsNullOrEmpty(rtbCuerpoMail.BodyHtml) Then
               MessageBox.Show("ATENCION: Debe ingresar el Cuerpo del Correo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.rtbCuerpoMail.Focus()
               Exit Sub
            End If

            ''# Muestro la columna de estado
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("Estado").Hidden = False

            Dim _dtEnvioMail As DataTable = DirectCast(ugDetalle.DataSource, DataTable)

            Dim adjuntos As String() = {Me.txtArchivo1.Text, Me.txtArchivo2.Text, Me.txtArchivo3.Text, Me.txtArchivo4.Text}

            Dim reporteCtaCte As Entidades.Publicos.InformesCtaCte? = Entidades.Publicos.InformesCtaCte.CTACTE
                Dim BodyHtml As String = rtbCuerpoMail.BodyHtml
                BodyHtml = BodyHtml.Replace("<BODY scroll=auto><IMG", "<img")



                BodyHtml = BodyHtml.Replace(">", "/>")
                BodyHtml = BodyHtml.Replace("</BODY/>", "")



                Dim wEnvioMasivo As VentasEnvioMasivoMails = New VentasEnvioMasivoMails()
            wEnvioMasivo.EnviarMails(txtAsuntoMail.Text, BodyHtml, txtCopiaOculta.Text,
                                     _dtEnvioMail, adjuntos,
                                     tspBarra, tslTexto, False, reporteCtaCte, Entidades.Cliente.ClienteVinculado.Cliente)

            'Dim copiaOculta As List(Of String) = New List(Of String)()

            'If Me.chbCopiaOculta.Checked Then copiaOculta.Add(Me.txtCopiaOculta.Text)

            'Dim CorreoSSS As Eniac.Win.MailSSS
            'Dim destina As List(Of String) = New List(Of String)()

            'Me.tspBarra.Maximum = Me.ugDetalle.Rows.Count
            'Me.tspBarra.Value = 0
            'Dim Enviados As Integer = 0

            'Dim Correos() As String

            'For Each dr As UltraGridRow In Me.ugDetalle.Rows

            '    Me.tspBarra.Value += 1

            '    If Boolean.Parse(dr.Cells("Envio").Value.ToString()) Then

            '        Enviados = 1

            '        Me.tslTexto.Text = "Enviando Mail a: " & dr.Cells("CorreoElectronico").Value.ToString()
            '        Application.DoEvents()

            '        'cargo los destinatarios
            '        destina.Clear()
            '        Correos = dr.Cells("CorreoElectronico").Value.ToString.Split(";"c)
            '        Dim Cont As Integer
            '        For Cont = 0 To Correos.Length - 1
            '            destina.Add(Correos(Cont))
            '        Next


            '        'Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()
            '        'stb.Append("<!DOCTYPE HTML>")
            '        'stb.Append("<html>")
            '        'stb.Append("<head>")
            '        'stb.Append("</head>")
            '        'stb.Append("<body>")
            '        'For Each st As String In Me.rtbCuerpoMail.Lines
            '        '    stb.Append("<br>")
            '        '    stb.Append(st)
            '        'Next
            '        'stb.Append("</body>")
            '        'stb.Append("</html>")

            '        'creo el mail y lo envio
            '        CorreoSSS = New Eniac.Win.MailSSS()
            '        'CorreoSSS.CrearMail(destina.ToArray(), Me.txtAsuntoMail.Text, stb.ToString(), Nothing, copiaOculta.ToArray())
            '        CorreoSSS.CrearMail(destina.ToArray(), Me.txtAsuntoMail.Text, Me.rtbCuerpoMail.BodyHtml, Nothing, copiaOculta.ToArray())

            '        If Not String.IsNullOrEmpty(Me.txtArchivo1.Text) Then
            '            CorreoSSS.AgregarAdjunto(Me.txtArchivo1.Text)
            '        End If
            '        If Not String.IsNullOrEmpty(Me.txtArchivo2.Text) Then
            '            CorreoSSS.AgregarAdjunto(Me.txtArchivo2.Text)
            '        End If
            '        If Not String.IsNullOrEmpty(Me.txtArchivo3.Text) Then
            '            CorreoSSS.AgregarAdjunto(Me.txtArchivo3.Text)
            '        End If
            '        If Not String.IsNullOrEmpty(Me.txtArchivo4.Text) Then
            '            CorreoSSS.AgregarAdjunto(Me.txtArchivo4.Text)
            '        End If

            '        CorreoSSS.EnviarMail()

            '    End If

            'Next

            'If Enviados = 0 Then
            '    MessageBox.Show("No Seleccionó Ningún Cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If

            MessageBox.Show("Correos enviados con Exito !!.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Me.tspBarra.Value = 0
            'Me.RefrescarDatosGrilla()

            Me.btnConsultar.Focus()

         Else
            ShowMessage("Los Datos del Correo Electronico estan incompletos " + Environment.NewLine + " (Configuraciones -> Parametros del Sistema)")
         End If


      Catch ex As Exception
         Dim st As System.Text.StringBuilder = New System.Text.StringBuilder()
         st.Append(ex.Message).AppendLine()
         If ex.InnerException IsNot Nothing Then
            st.Append(ex.InnerException.Message).AppendLine()
            If ex.InnerException.InnerException IsNot Nothing Then
               st.Append(ex.InnerException.InnerException.Message)
            End If
         End If
         MessageBox.Show(st.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub CargarComboEmbarcaciones()

      Me.cmbEmbarcaciones.Items.Insert(0, "TODOS")
      Me.cmbEmbarcaciones.Items.Insert(1, "Responsable de Cargos")
      Me.cmbEmbarcaciones.Items.Insert(2, "Titulares")
      Me.cmbEmbarcaciones.Items.Insert(3, "Autorizados")

      Me.cmbEmbarcaciones.SelectedIndex = 0

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chbCliente.Checked = False
      Me.chbVendedor.Checked = False
      Me.chbZonaGeografica.Checked = False
      Me.chbCategoria.Checked = False
      Me.chbListaDePrecios.Checked = False
      Me.cmbActivo.SelectedIndex = 0
      Me.cmbEmbarcaciones.SelectedIndex = 0
      Me.chbFormaPago.Checked = False
      Me.chbDescuentoRecargo.Checked = False

      Me.txtCopiaOculta.Text = Reglas.Publicos.Facturacion.FacturacionEnvioMailCopiaOculta
      Me.chbCopiaOculta.Checked = Not String.IsNullOrWhiteSpace(txtCopiaOculta.Text)


      If Me.ugDetalle.Rows.Count > 0 Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.tsbEnviarCorreos.Enabled = False

      Me.txtAsuntoMail.Text = ""
      Me.rtbCuerpoMail.Text = ""

      Me.cmbTodos.SelectedIndex = 0
      Me.tslTexto.Text = ""

      Me.btnConsultar.Focus()

      FormatearGrilla()
   End Sub

   Private Sub CargaGrillaDetalle()

      Try

         Dim oRegClientes As Reglas.Clientes = New Reglas.Clientes()

         Dim Total1 As Decimal = 0
         Dim Total2 As Decimal = 0

         Dim IdVendedor As Integer = 0

         Dim idZonaGeografica As String = String.Empty

         Dim Desde As Date = Nothing
         Dim Hasta As Date = Nothing

         Dim IdCliente As Long = 0

         Dim idFormaPago As Integer = 0
         Dim descPorRecargo As Decimal? = Nothing

         Dim IdCategoria As Integer = 0

         Dim idListaDePrecios As Integer = -1

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.cmbZonaGeografica.Enabled Then
            idZonaGeografica = Me.cmbZonaGeografica.SelectedValue.ToString()
         End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbCategoria.Enabled Then
            IdCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         If Me.cmbListaDePrecios.Enabled Then
            idListaDePrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())
         End If

         If Me.cmbFormaPago.Enabled Then
            idFormaPago = Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
         End If

         If Me.chbDescuentoRecargo.Checked Then
            descPorRecargo = Decimal.Parse(Me.txtDescuentoRecargoPorc.Text)
         End If

         Dim dtDetalle As DataTable

         Dim drCl As DataRow

         dtDetalle = oRegClientes.GetParaEnvioMasivoCorreo(IdVendedor,
                                                         IdCliente,
                                                         idZonaGeografica,
                                                         IdCategoria,
                                                         idListaDePrecios,
                                                         idFormaPago,
                                                         descPorRecargo,
                                                         Me.cmbActivo.Text, "", Me.cmbConfiguracionMail.SelectedValue.ToString(), Me.cmbRecibeNotificaciones.Text,
                                                         Me.cmbEmbarcaciones.Text)

         _dtDetalle = Me.CrearDT()

         For Each dr As DataRow In dtDetalle.Rows

            drCl = _dtDetalle.NewRow()

            drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
            drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
            drCl("NombreCliente") = dr("NombreCliente").ToString()
            drCl("NombreDeFantasia") = dr("NombreDeFantasia").ToString()
            drCl("CorreoElectronico") = dr("CorreoElectronico").ToString()
            drCl("Direccion") = dr("Direccion").ToString()
            drCl("IdLocalidad") = dr("IdLocalidad").ToString()
            drCl("NombreLocalidad") = dr("NombreLocalidad").ToString()
            drCl("CUIT") = dr("CUIT").ToString()
            drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal").ToString()
            drCl("NombreZonaGeografica") = dr("NombreZonaGeografica").ToString()
            drCl("NombreCategoria") = dr("NombreCategoria").ToString()
            drCl("NombreListaPrecios") = dr("NombreListaPrecios").ToString()
            drCl("Telefonos") = Strings.Trim(dr("Telefono").ToString() & " " & dr("Celular").ToString())
            drCl("NombreVendedor") = dr("NombreVendedor").ToString()
            drCl("DescuentoRecargoPorc") = dr("DescuentoRecargoPorc")
            drCl("DescripcionFormasPago") = dr("DescripcionFormasPago")
            drCl("Activo") = dr("Activo")
            drCl("RecibeNotificaciones") = dr("RecibeNotificaciones")
            drCl("Envio") = dr("Envio")
            drCl("SiMovilIdUsuario") = dr("SiMovilIdUsuario")
            drCl("SiMovilClave") = dr("SiMovilClave")

            _dtDetalle.Rows.Add(drCl)

         Next

         Me.ugDetalle.DataSource = _dtDetalle

         FormatearGrilla()

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
         .Columns.Add("Estado", GetType(String))
         .Columns.Add("Envio", GetType(Boolean))
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreDeFantasia", System.Type.GetType("System.String"))
         .Columns.Add("CorreoElectronico", System.Type.GetType("System.String"))
         .Columns.Add("Direccion", System.Type.GetType("System.String"))
         .Columns.Add("IdLocalidad", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         .Columns.Add("CUIT", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
         .Columns.Add("NombreZonaGeografica", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoria", System.Type.GetType("System.String"))
         .Columns.Add("NombreListaPrecios", System.Type.GetType("System.String"))
         .Columns.Add("Telefonos", System.Type.GetType("System.String"))
         .Columns.Add("NombreVendedor", System.Type.GetType("System.String"))
         .Columns.Add("DescuentoRecargoPorc", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionFormasPago", System.Type.GetType("System.String"))
         .Columns.Add("Activo", System.Type.GetType("System.Boolean"))
         .Columns.Add("RecibeNotificaciones", System.Type.GetType("System.Boolean"))
         .Columns.Add("SiMovilIdUsuario", System.Type.GetType("System.String"))
         .Columns.Add("SiMovilClave", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function
   Public Sub FormatearGrilla()
      ugDetalle.DisplayLayout.UseFixedHeaders = True
      ugDetalle.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None
      Dim pos As Integer = 0
      With Me.ugDetalle.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.NoEdit
         Next

         FormatearColumna(.Columns("Estado"), "Estado", pos, 60, HAlign.Left, True)
         .Columns(selecColumnName).FormatearColumna("Envio", pos, 30, HAlign.Center).CellActivation = Activation.AllowEdit


         FormatearColumna(.Columns("NombreCliente"), "Nombre Cliente", pos, 180)

         FormatearColumna(.Columns("NombredeFantasia"), "Nombre de Fantasia", pos, 200)

         FormatearColumna(.Columns("CorreoElectronico"), "Correo(s) Electronico(2)", pos, 110)


         FormatearColumna(.Columns("NombreCategoriaFiscal"), "Categoria Fiscal", pos, 80)


         FormatearColumna(.Columns("NombreZonaGeografica"), "Zona Geografica", pos, 90)

         FormatearColumna(.Columns("NombreCategoria"), "Categoria", pos, 80)

         FormatearColumna(.Columns("NombreListaPrecios"), "Lista de Precios", pos, 80)

         FormatearColumna(.Columns("Telefonos"), "Telefonos", pos, 80)

         FormatearColumna(.Columns("NombreVendedor"), "Vendedor", pos, 100)

         FormatearColumna(.Columns("DescuentoRecargoPorc"), "D/R", pos, 50, HAlign.Right)

         FormatearColumna(.Columns("DescripcionFormasPago"), "Formas de Pago", pos, 80)

         FormatearColumna(.Columns("Activo"), "Activo", pos, 50, HAlign.Center)

         FormatearColumna(.Columns("RecibeNotificaciones"), "Rec. Notif.", pos, 50, HAlign.Center)

      End With


      ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreDeFantasia", "CorreoElectronico"})

      LeerPreferencias()

   End Sub
   Private Sub ExaminarArchivo(ByVal NumeroArchivo As Integer)

      Dim ArchivoStream As Stream = Nothing
      Dim DialogoAbrirArchivo As New OpenFileDialog()

      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoAbrirArchivo.Filter = "Adobe Reader (*.pdf)|*.pdf|Todos los Archivos (*.*)|*.*"
      DialogoAbrirArchivo.FilterIndex = 1
      DialogoAbrirArchivo.RestoreDirectory = True

      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            ArchivoStream = DialogoAbrirArchivo.OpenFile()
            If (ArchivoStream IsNot Nothing) Then
               'Si bien aca lo pude abrir, solo es para obtener el path.
               Select Case NumeroArchivo
                  Case 1
                     Me.txtArchivo1.Text = DialogoAbrirArchivo.FileName
                     Me.txtArchivo1.Focus()
                  Case 2
                     Me.txtArchivo2.Text = DialogoAbrirArchivo.FileName
                     Me.txtArchivo2.Focus()
                  Case 3
                     Me.txtArchivo3.Text = DialogoAbrirArchivo.FileName
                     Me.txtArchivo3.Focus()
                  Case Else
                     Me.txtArchivo4.Text = DialogoAbrirArchivo.FileName
                     Me.txtArchivo4.Focus()
               End Select
            End If
         Catch Ex As Exception
            MessageBox.Show("ATENCION: No se puede leer el Archivo " & NumeroArchivo.ToString() & ". Error: " & Ex.Message)
         Finally
            If (ArchivoStream IsNot Nothing) Then
               ArchivoStream.Close()
            End If
         End Try
      End If

   End Sub

   Private Function ValidarCorreo() As Boolean

      Dim validaDatos As Boolean = True

      If (Publicos.MailServidor = "" Or Publicos.MailDireccion = "" Or Publicos.MailUsuario = "" Or Publicos.MailPassword = "" Or Publicos.MailPuertoSalida = 0) Then
         validaDatos = False

      End If

      Return validaDatos

   End Function
   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugDetalle.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugDetalle.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Dim oCliente As Entidades.Cliente = New Reglas.Clientes().GetUno(Long.Parse(dr("IdCliente").ToString()), False)
            Using frmCliente As ClientesDetalle = New ClientesDetalle(oCliente)
               frmCliente.IdFuncion = IdFuncion
               frmCliente.StateForm = StateForm.Actualizar
               If frmCliente.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                  Dim dtNuevo As DataTable = GetDataTableCLienteActualizar(oCliente.IdCliente)
                  If dtNuevo.Rows.Count > 0 Then
                     Dim drNuevo As DataRow = dtNuevo.Rows(0)
                     For Each dcSeleccionado As DataColumn In dr.Table.Columns
                        If drNuevo.Table.Columns.Contains(dcSeleccionado.ColumnName) Then
                           dr(dcSeleccionado.ColumnName) = drNuevo(dcSeleccionado.ColumnName)
                        End If
                     Next
                  End If   '
               End If
            End Using
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: Por favor seleccione un cliente valido !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Function GetDataTableCLienteActualizar(idCliente As Long) As DataTable

      Try

         Dim oRegClientes As Reglas.Clientes = New Reglas.Clientes()

         Dim Total1 As Decimal = 0
         Dim Total2 As Decimal = 0

         Dim IdVendedor As Integer = 0

         Dim idZonaGeografica As String = String.Empty

         Dim Desde As Date = Nothing
         Dim Hasta As Date = Nothing


         Dim idFormaPago As Integer = 0
         Dim descPorRecargo As Decimal? = Nothing

         Dim IdCategoria As Integer = 0

         Dim idListaDePrecios As Integer = -1

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.cmbZonaGeografica.Enabled Then
            idZonaGeografica = Me.cmbZonaGeografica.SelectedValue.ToString()
         End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         If Me.cmbCategoria.Enabled Then
            IdCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
         End If

         If Me.cmbListaDePrecios.Enabled Then
            idListaDePrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())
         End If

         If Me.cmbFormaPago.Enabled Then
            idFormaPago = Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
         End If

         If Me.txtDescuentoRecargoPorc.Enabled Then
            descPorRecargo = Decimal.Parse(Me.txtDescuentoRecargoPorc.Text)
         End If

         Dim dtDetalle As DataTable

         Return oRegClientes.GetParaEnvioMasivoCorreo(IdVendedor, idCliente,
                                                            idZonaGeografica,
                                                            IdCategoria,
                                                            idListaDePrecios,
                                                            idFormaPago,
                                                            descPorRecargo,
                                                            Me.cmbActivo.Text, "", Me.cmbConfiguracionMail.SelectedValue.ToString(), Me.cmbRecibeNotificaciones.Text,
                                                            Me.cmbEmbarcaciones.SelectedValue.ToString())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Function

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
      For Each drTwo As UltraGridRow In rows
         If Not String.IsNullOrWhiteSpace(drTwo.Cells("CorreoElectronico").Value.ToString()) Then
            If marcar.HasValue Then
               drTwo.Cells(selecColumnName).Value = marcar.Value
            Else
               drTwo.Cells(selecColumnName).Value = Not CBool(drTwo.Cells(selecColumnName).Value)
            End If
         End If
      Next
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

         Dim _dtEnvioMail As DataTable = DirectCast(Me.ugDetalle.DataSource, DataTable).Clone
         _dtEnvioMail.ImportRow(dr)
         _dtEnvioMail.AcceptChanges()

         Dim reporteCtaCte As Entidades.Publicos.InformesCtaCte? = Nothing

         Dim adjuntos As String() = {Me.txtArchivo1.Text, Me.txtArchivo2.Text, Me.txtArchivo3.Text, Me.txtArchivo4.Text}
         Dim wEnvioMasivo As VentasEnvioMasivoMails = New VentasEnvioMasivoMails()
         wEnvioMasivo.EnviarMailPrueba(txtAsuntoMail.Text, rtbCuerpoMail.BodyHtml, mailPrueba, _dtEnvioMail, adjuntos, tspBarra, tslTexto, False, reporteCtaCte)
      Else
         Throw New Exception("ATENCION: No tiene ninguna fila selleccionada para enviar el correo de prueba.")
      End If



      Me.tspBarra.Value = 0
      '  Me.RefrescarDatosGrilla()
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
End Class