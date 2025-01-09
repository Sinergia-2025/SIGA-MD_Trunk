Option Strict Off
Imports Eniac.Win
Imports Eniac.Entidades
Imports Eniac.Reglas

Public Class CartasPendientes

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos
   Private _dt As DataTable

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.CargarValoresIniciales()
   
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
      Try
         Dim IdCob As Integer = 0

         Dim nombreCob As String = String.Empty
            Dim nombreCliente As String = String.Empty
            Dim cliente As Eniac.Entidades.Cliente = New Eniac.Entidades.Cliente()
            Dim IdCliente As Long = 0
            Dim nroOperacion As Integer = 0

         Me.Cursor = Cursors.WaitCursor

         Dim oFPagos As Eniac.Reglas.FichasPagos = New Eniac.Reglas.FichasPagos()

         If Me.chbConCobrador.Checked Then
            If Me.cmbCobradores.SelectedIndex <> -1 Then
               IdCob = Me.cmbCobradores.SelectedItem("IdEmpleado").ToString()
               nombreCob = Me.cmbCobradores.Text
            End If
         End If
            If Me.bscCodigoCliente.Text <> "" Then
                cliente = New Eniac.Reglas.Clientes().GetUnoPorCodigo(Long.Parse(Me.bscCodigoCliente.Text.ToString()))
            End If


         If Me.chbPorCliente.Checked Then
            If Me.bscCliente.Text <> "" Then
                    IdCliente = cliente.IdCliente
                    NombreCliente = cliente.NombreCliente
            End If
         End If

         If txtNroOperacion.Text <> 0 Then
            nroOperacion = Integer.Parse(txtNroOperacion.Text.ToString())
         End If

         Me._dt = oFPagos.GetPagosPendientesParaCarta(Eniac.Entidades.Usuario.Actual.Sucursal.Id, Me.dtpDesde.Value, Me.dtpHasta.Value, IdCob, IdCliente, nroOperacion)

         Me.dgvClientes.DataSource = Me._dt

         Me.Text = "Emisión de cartas para deudores - (Cartas disponibles para enviar: " & Me._dt.Rows.Count.ToString() & ")"

         If Me._dt.Rows.Count > 0 Then
            Me.chbTodos.Enabled = True
            Me.btnEmitirCarta.Enabled = True
            Me.cmbTipoCarta.Enabled = True
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Me.CargarValoresIniciales()
   End Sub

   Private Sub chbConCobrador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbConCobrador.CheckedChanged
      Me.cmbCobradores.Enabled = Me.chbConCobrador.Checked
   End Sub

   Private Sub btnEmitirCarta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmitirCarta.Click

      Dim suma As Double = 0
      Dim nombreReporte As String = String.Empty
      Dim reporteDataSource As String = "FichasDataSet_PagosPendientes"

      Try
         Me.Cursor = Cursors.WaitCursor

         Select Case Me.cmbTipoCarta.Text
            Case "Recordatoria"
               nombreReporte = ".CartaPendiente.rdlc"
            Case "Intimidatoria"
               nombreReporte = ".CartaIntimida.rdlc"
            Case "Garante"
               nombreReporte = ".CartaGarante.rdlc"
         End Select


         Dim dt As DataTable
         Dim fecha As DateTime = DateTime.Now
         'Dim frmImprime As VisorReportes
         Dim i As Integer = 0
         Dim drCl As DataRow

         Dim ultimoIdCliente As Long = 0
         Dim ultimoNombre As String = String.Empty
         Dim strOperaciones As String = String.Empty
         Dim strOperacion As String = String.Empty

         strOperaciones = ""
         strOperacion = ""

         dt = Me.CrearDT()
         Dim primero As Boolean = True
         Dim entro As Boolean = False

         For Each dr As DataGridViewRow In Me.dgvClientes.Rows
            If dr.Cells("Check").Value = True Then
               entro = True
            End If
         Next

         If entro = False Then
            MessageBox.Show("ATENCION: NO selecciono ninguna operación !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         For Each dr As DataGridViewRow In Me.dgvClientes.Rows
            If dr.Cells("Check").Value = True Then

               If Not primero Then
                  If ultimoIdCliente <> dr.Cells("IdCliente").Value Then

                     Me.CargaParametrosEImprime("Eniac.Win" & nombreReporte, reporteDataSource, dt, suma, ultimoIdCliente, ultimoNombre, strOperaciones)

                     strOperacion = ""
                     strOperaciones = ""
                     suma = 0
                     dt.Rows.Clear()

                     If MessageBox.Show("Continua viendo cartas?", Me.Text.Substring(0, 31), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                        Exit For
                     End If

                  End If
               Else
                  primero = False
               End If

               drCl = dt.NewRow()
               drCl("NombreCliente") = dr.Cells("NombreCliente").Value
               drCl("NroOperacion") = dr.Cells("NroOperacion").Value
               drCl("Direccion") = dr.Cells("Direccion").Value
               drCl("NroCuota") = dr.Cells("NroCuota").Value
               drCl("Saldo") = dr.Cells("Saldo").Value
               drCl("Producto") = dr.Cells("Producto").Value
               drCl("FechaVencimiento") = dr.Cells("FechaVencimiento").Value

               suma += Double.Parse(drCl("Saldo").ToString())
               dt.Rows.Add(drCl)

               ultimoIdCliente = dr.Cells("IdCliente").Value.ToString()
               ultimoNombre = dr.Cells("NombreCliente").Value

               If strOperacion <> dr.Cells("NroOperacion").Value.ToString() Then
                  strOperacion = dr.Cells("NroOperacion").Value.ToString()
                  strOperaciones = strOperaciones & dr.Cells("NroOperacion").Value.ToString() & "|"
               End If

            End If
         Next

         If dt.Rows.Count > 0 Then
            Me.CargaParametrosEImprime("Eniac.Win" & nombreReporte, reporteDataSource, dt, suma, ultimoIdCliente, ultimoNombre, strOperaciones)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged
      Me.Cursor = Cursors.WaitCursor

      For Each dr As DataGridViewRow In Me.dgvClientes.Rows
         dr.Cells("Check").Value = Me.chbTodos.Checked
      Next

      Me.Cursor = Cursors.Default
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Dim codigoCliente As Long = -1
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
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Clientes = New Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(sender As System.Object, e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub llbOperacion_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbOperacion.LinkClicked
      'Me._primerSaldo = 0
      Me.VerOperaciones(True)
   End Sub

   Private Sub chbPorCliente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbPorCliente.CheckedChanged
      Try
         Me.bscCodigoCliente.Enabled = Me.chbPorCliente.Checked
         Me.bscCliente.Enabled = Me.chbPorCliente.Checked

         If Not Me.chbPorCliente.Checked Then
            Me.bscCodigoCliente.Text = ""
            Me.bscCliente.Text = ""
         Else
            Me.bscCodigoCliente.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try


   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()
      Me._publicos = New Eniac.Win.Publicos()

      Me.dtpDesde.Value = DateTime.Now.AddMonths(-1)
      Me.dtpHasta.Value = DateTime.Now
      Me._publicos.CargaComboEmpleados(Me.cmbCobradores, Eniac.Entidades.Publicos.TiposEmpleados.COMPRADOR)

      Me.Text = "Emisión de cartas para deudores"
      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCliente.Text = String.Empty
      Me.txtNroOperacion.Text = "0"
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

      If Not Me._dt Is Nothing Then
         Me._dt.Rows.Clear()
      End If
      Me.chbPorCliente.Checked = False
      Me.chbTodos.Enabled = False
      Me.chbTodos.Checked = False
      Me.btnEmitirCarta.Enabled = False
      Me.cmbTipoCarta.Enabled = False

      Me.CargaComboCartas()

   End Sub

   Private Sub CargaParametrosEImprime(ByVal nombreReporte As String, ByVal reporteDataSource As String, ByVal dt As DataTable, ByVal suma As Double, ByVal ultimoIdCliente As Long, ByVal ultimoNombre As String, ByVal pOperaciones As String)

      Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

      parm.Clear()

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now.ToString("dd \de MMMMM \de yyyy")))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Muchos", True))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Suma", suma))

      If Me.cmbTipoCarta.Text = "Garante" Then
         Dim gar As Garante = New Garante()

         gar.Text = "Garante de " & ultimoNombre
         gar.IdCliente = ultimoIdCliente

         If gar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreGarante", gar.NombreGarante))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionGarante", gar.DireccionGarante))
         Else
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreGarante", String.Empty))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionGarante", String.Empty))
         End If
      End If


      'Grabo en el historia la carta enviada.
      Dim oClientes As Clientes = New Clientes

      oClientes.ActualizarEnvioCarta(ultimoIdCliente, Me.cmbTipoCarta.Text, pOperaciones, Ayudantes.Common.usuario, actual.Sucursal.Id)
      '-------------------------------------------------------------------------------------------------

      Dim frmImprime As VisorReportes = New VisorReportes(nombreReporte, reporteDataSource, dt, parm, 1) '# 1 = Cantidad de Copias
      frmImprime.Text = "Carta " & Me.cmbTipoCarta.Text
      frmImprime.WindowState = FormWindowState.Maximized
      frmImprime.Show()

      ''Dim im As Imprimir = New Imprimir()
      ''im.Run("C:\My Documents\Visual Studio Projects\Eniac\....\CartaPendiente.rdlc", "SistemaDataSet_PagosPendientes", dt, parm)

   End Sub

   Private Function CrearDT() As DataTable
      Dim dt As DataTable = New DataTable()
      With dt
         .Columns.Add("NombreCliente")
         .Columns.Add("NroOperacion")
         .Columns.Add("Direccion")
         .Columns.Add("NroCuota")
         .Columns.Add("Saldo")
         .Columns.Add("Producto")
         .Columns.Add("FechaVencimiento")
      End With
      Return dt
   End Function

   Public Sub CargaComboCartas()
      With Me.cmbTipoCarta
         .Items.Clear()
         .Items.Add("Recordatoria")
         .Items.Add("Intimidatoria")
         .Items.Add("Garante")
         .SelectedIndex = 0
      End With
   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString.Trim()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString.Trim()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString.Trim()

      Me.txtNroOperacion.Text = 0
      Me.txtNroOperacion.ReadOnly = False
      'Me.VerOperaciones(False)
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

      Dim oFichas As Reglas.Fichas = New Reglas.Fichas()
      Me.dtpDesde.Value = oFichas.GetOperacionesConSaldo(actual.Sucursal.Id, Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

      If Not Me._dt Is Nothing Then
         Me._dt.Rows.Clear()
         Me.dgvClientes.DataSource = Me._dt
      End If

   End Sub

   Private Sub VerOperaciones(ByVal todas As Boolean)
      Dim oOperPend As FichasPendientes = New FichasPendientes(Long.Parse(Me.bscCodigoCliente.Tag.ToString), todas)
      If oOperPend.HayRegistro Then
         If todas Then
            oOperPend.Text += " de " & Me.bscCliente.Text
         Else
            oOperPend.Text += " pendientes de " & Me.bscCliente.Text
         End If
         oOperPend.ShowDialog()
         If oOperPend.Selecciono Then
            Me.txtNroOperacion.Text = oOperPend.NroOperacion
            Me.txtNroOperacion.ReadOnly = True
            'Alguna PC paso el control de la fecha maxima y tiene fecha larga asi que le actualizo el maximo.
            'Me.dtpFecha.MaxDate = oOperPend.FechaOperacion
            'Me.dtpFecha.Value = oOperPend.FechaOperacion
            'Me.PrepararFichaParaPago()
         End If
      Else
         MessageBox.Show("ATENCION: NO hay operaciones para el cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
   End Sub
#End Region


End Class