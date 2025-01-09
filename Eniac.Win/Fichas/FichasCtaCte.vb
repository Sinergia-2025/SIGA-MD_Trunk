Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class FichasCtaCte

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos

   Private oFichas As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas()
   Private oFichaPagos As Generic.List(Of Eniac.Entidades.FichaPago)
   Private oFichaProductos As System.Collections.Generic.List(Of Eniac.Entidades.FichaProducto)

   Private oFicha As Eniac.Entidades.Ficha

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Eniac.Win.Publicos()

         'Me.dtpDesde.Value = DateTime.Now
         'Me.dtpHasta.Value = DateTime.Now


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

         Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Es obligatorio seleccionar un Cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.txtOperaciones.Text.Length = 0 Then
            MessageBox.Show("ATENCION: Este Cliente NO tiene Operaciones a detallar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
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

   Private Sub dtgVentas_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick

      If e.ColumnIndex = 0 And e.RowIndex <> -1 And Not Me.dgvDetalle.Rows(e.RowIndex).Cells("Ver").Value Is Nothing Then

         oFicha = oFichas.GetUna(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Int32.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NroOperacion").Value.ToString()), actual.Sucursal.Id)

         oFichaProductos = oFicha.Productos
         oFichaPagos = oFicha.Pagos


         Try
            Me.Cursor = Cursors.WaitCursor
            Dim dtFic As FichasDataSet.FichasProductosDataTable = New FichasDataSet.FichasProductosDataTable()
            Dim drF As FichasDataSet.FichasProductosRow
            For Each fp As Eniac.Entidades.FichaProducto In oFichaProductos
               drF = dtFic.NewFichasProductosRow()
               drF.ProductoDesc = fp.ProductoDesc
               drF.Cantidad = fp.Cantidad
               drF.Precio = fp.Precio
               dtFic.AddFichasProductosRow(drF)
            Next

            Dim pagare As String = String.Empty

            'pagare = Me.txtCuotas.Text & " cuotas de $ " & Me.txtImpCuota.Text & " cada una.------------------------------"

            Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", Me.dgvDetalle.Rows(e.RowIndex).Cells("FechaCompra").Value.ToString()))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDoc", Me.bscCodigoCliente.Text))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroOperacion", Me.dgvDetalle.Rows(e.RowIndex).Cells("NroOperacion").Value.ToString()))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", Me.bscCliente.Text))
            'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", Me.txtDireccion.Text))
            'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", Me.txtTelefono.Text))
            'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Localidad", Me.txtLocalidad.Text))
            'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Saldo", Me.txtTotalCuotas.Text))
            'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pagaremos", pagare))
            'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Anticipo", Me.txtAnticipo.Text))

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", "***INFORMAR***"))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", "***INFORMAR***"))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Localidad", "***INFORMAR***"))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Saldo", "0"))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Pagaremos", pagare))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Anticipo", "0"))

            Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Ficha.rdlc", "SistemaDataSet_FichasProductos", dtFic, parm, 1) '# 1 = Cantidad de Copias
            frmImprime.Text = "Ficha"
            frmImprime.Show()
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try


         Try
            Me.Cursor = Cursors.WaitCursor

            Dim dtFic As FichasDataSet.FichasProductosDataTable = New FichasDataSet.FichasProductosDataTable()
            Dim drF As FichasDataSet.FichasProductosRow

            For Each fp As Eniac.Entidades.FichaProducto In oFichaProductos
               drF = dtFic.NewFichasProductosRow()
               drF.ProductoDesc = fp.ProductoDesc
               drF.Cantidad = fp.Cantidad
               drF.Precio = fp.Precio
               dtFic.AddFichasProductosRow(drF)
            Next

            Dim dtPag As FichasDataSet.FichasPagosDataTable = New FichasDataSet.FichasPagosDataTable()
            Dim drP As FichasDataSet.FichasPagosRow = Nothing
            Dim cont As Integer = 5
            Dim contMax As Integer = 5
            For Each fp As Eniac.Entidades.FichaPago In Me.oFichaPagos
               If cont = contMax Then
                  drP = dtPag.NewFichasPagosRow()
                  cont = 0
               End If
               If cont = 0 Then
                  drP.NroOperacion = fp.NroOperacion
                  drP.IdCliente = fp.IdCliente
                  drP.NroCuota = fp.NroCuota
                  drP.FechaVencimiento = fp.FechaVencimiento
                  drP.Importe = fp.Importe
               End If
               If cont = 1 Then
                  drP.NroCuota1 = fp.NroCuota
                  drP.FechaVencimiento1 = fp.FechaVencimiento
                  drP.Importe1 = fp.Importe
               End If
               If cont = 2 Then
                  drP.NroCuota2 = fp.NroCuota
                  drP.FechaVencimiento2 = fp.FechaVencimiento
                  drP.Importe2 = fp.Importe
               End If
               If cont = 3 Then
                  drP.NroCuota3 = fp.NroCuota
                  drP.FechaVencimiento3 = fp.FechaVencimiento
                  drP.Importe3 = fp.Importe
               End If
               If cont = 4 Then
                  drP.NroCuota4 = fp.NroCuota
                  drP.FechaVencimiento4 = fp.FechaVencimiento
                  drP.Importe4 = fp.Importe
               End If
               cont += 1
               If cont = contMax Then
                  dtPag.AddFichasPagosRow(drP)
               End If
            Next
            If cont <> contMax Then
               dtPag.AddFichasPagosRow(drP)
            End If

            Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", Me.bscCliente.Text))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", Me.dgvDetalle.Rows(e.RowIndex).Cells("FechaCompra").Value.ToString()))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroOperacion", Me.dgvDetalle.Rows(e.RowIndex).Cells("NroOperacion").Value.ToString()))

            Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.FichaCliente.rdlc", "SistemaDataSet_FichasProductos", dtFic, "SistemaDataSet_FichasPagos", dtPag, parm, 1) '# 1 = Cantidad de Copias
            frmImprime.Text = "Ficha Cliente"
            frmImprime.Show()
         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try

      End If

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
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
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

   Private Sub ConsultarVentas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub chkSoloConSaldo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSoloConSaldo.CheckedChanged

      Me.txtOperaciones.Text = Me.FichasConSaldo()

   End Sub


   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.dgvDetalle.RowCount = 0 Then
            Exit Sub
         End If

         Dim dt As DataTable
         Dim Filtros As String
         Dim decSaldo As Decimal = 0

         Me.Cursor = Cursors.WaitCursor

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Filtros = "Cliente: " & Me.bscCodigoCliente.Text & " - " & Me.bscCliente.Text

         'decSaldo = Decimal.Parse(Me.txtTotalIngresos.Text) + Decimal.Parse(Me.txtTotalEgresos.Text)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))
         'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Saldo", decSaldo.ToString()))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.FichasCtaCte.rdlc", "SistemaDataSet_FichasCtaCte", dt, parm, 1) '# 1 = Cantidad de Copias

         frmImprime.Text = "Fichas - Cuenta Corriente de Clientes"
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try


   End Sub


#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString.Trim()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString.Trim()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

      Me.txtOperaciones.Text = Me.FichasConSaldo()

   End Sub

   Private Sub RefrescarDatosGrilla()

      'Me.chkFechas.Checked = False
      'Me.dtpDesde.Value = Date.Now
      'Me.dtpHasta.Value = Date.Now

      Me.bscCodigoCliente.Enabled = True
      Me.bscCodigoCliente.Text = ""

      Me.bscCliente.Enabled = True
      Me.bscCliente.Text = ""

      Me.chkSoloConSaldo.Checked = False

      Me.txtOperaciones.Text = ""

      'Limpio la Grilla.

      'Metodo 1 
      'Dim dt As DataTable = DirectCast(Me.dgvPorCliente.DataSource, DataTable)
      'dt.Rows.Clear()

      'Metodo 2
      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oFichasPagDet As Eniac.Reglas.FichasPagosDetalle = New Eniac.Reglas.FichasPagosDetalle()

      Dim decCompras As Decimal = 0
      Dim decPagos As Decimal = 0
      Dim decTotal As Decimal = 0

      'Dim FechaDesde As Date
      'Dim FechaHasta As Date

      Try

         'If Me.chkFechas.Checked Then
         '   FechaDesde = Me.dtpDesde.Value
         '   FechaHasta = Me.dtpHasta.Value
         'End If

         Me.dgvDetalle.DataSource = oFichasPagDet.CtaCte(actual.Sucursal.Id, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Me.txtOperaciones.Text)

         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows

            If Not String.IsNullOrEmpty(dr.Cells("FechaCompra").Value.ToString()) Then

               dr.Cells("Ver").Value = "..."

               decCompras = decCompras + Decimal.Parse(dr.Cells("ImporteCompra").Value.ToString())
               decTotal = 0

            Else

               'dr.Cells("Ver").Value = ""
               'DataGridViewTextBoxColumn

               decPagos = decPagos + Decimal.Parse(dr.Cells("ImportePago").Value.ToString())

               decTotal = decCompras - decPagos

               dr.Cells("Saldo").Value = decTotal

            End If

         Next

         decTotal = decCompras - decPagos

         Me.txtTotalCompras.Text = decCompras.ToString("#,##0.00")
         Me.txtTotalPagado.Text = decPagos.ToString("#,##0.00")
         Me.txtSaldo.Text = decTotal.ToString("#,##0.00")

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function FichasConSaldo() As String

      If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
         Return ""
      End If

      Dim oFichas As Eniac.Reglas.Fichas = New Eniac.Reglas.Fichas

      Dim dt As DataTable

      dt = oFichas.GetOperaciones(actual.Sucursal.Id, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Me.chkSoloConSaldo.Checked)

      If dt.Rows.Count = 0 Then
         Return ""
      End If

      Dim Operaciones As String

      Operaciones = ""

      For Each dr As DataRow In dt.Rows
         Operaciones = Operaciones & dr(0).ToString() & ", "
      Next

      Operaciones = Operaciones.Substring(0, Operaciones.Length - 2)

      Return Operaciones

   End Function

#End Region

End Class