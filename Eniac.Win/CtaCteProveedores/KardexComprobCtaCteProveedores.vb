Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class KardexComprobCtaCteProveedores

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "COMPRAS", "CTACTE", "SI")
         Me.cmbTiposComprobantes.SelectedIndex = -1

         Dim aTipoFactura As ArrayList = New ArrayList
         aTipoFactura.Insert(0, "A")
         aTipoFactura.Insert(1, "B")
         aTipoFactura.Insert(2, "C")
         aTipoFactura.Insert(3, "E")
         aTipoFactura.Insert(4, "M")
         aTipoFactura.Insert(5, "R")
         aTipoFactura.Insert(6, "X")
         Me.cboLetra.DataSource = aTipoFactura

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

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.cmbTiposComprobantes.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.cmbTiposComprobantes.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
            MessageBox.Show("ATENCION: Es obligatorio seleccionar un Proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         If Me.cmbTiposComprobantes.SelectedIndex < 0 Then
            MessageBox.Show("ATENCION: Es obligatorio seleccionar un Tipo de Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbTiposComprobantes.Focus()
            Exit Sub
         End If

         If Me.cboLetra.SelectedIndex < 0 Then
            MessageBox.Show("ATENCION: Es obligatorio seleccionar una Letra de Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cboLetra.Focus()
            Exit Sub
         End If

         If Integer.Parse("0" & Me.txtEmisor.Text) = 0 Then
            MessageBox.Show("ATENCION: Es obligatorio digitar un Emisor de Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtEmisor.Focus()
            Exit Sub
         End If

         If Integer.Parse("0" & Me.txtNumero.Text) = 0 Then
            MessageBox.Show("ATENCION: Es obligatorio digitar un Numero de Comprobante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtNumero.Focus()
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

   Private Sub KardexComprobCtaCteProveedores_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         Dim Filtros As String

         Dim dt As DataTable

         Me.Cursor = Cursors.WaitCursor

         Filtros = "Proveedor: " & Me.bscCodigoProveedor.Text & " - " & Me.bscProveedor.Text

         Filtros = Filtros & " - Comprobante: " & Me.cmbTiposComprobantes.Text

         Filtros = Filtros & " '" & Me.cboLetra.Text & "'"

         Filtros = Filtros & "  " & Me.txtEmisor.Text & " - " & Me.txtNumero.Text

         dt = DirectCast(Me.dgvDetalle.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         Dim frmImprime As VisorReportes

         frmImprime = New VisorReportes("Eniac.Win.KardexComprobCtaCteProveedores.rdlc", "SistemaDataSet_CuentasCorrientesProvPagos", dt, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False


   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.bscProveedor.Enabled = True
      Me.bscProveedor.Text = ""
      Me.bscCodigoProveedor.Enabled = True
      Me.bscCodigoProveedor.Text = ""

      Me.cmbTiposComprobantes.SelectedIndex = -1
      Me.cboLetra.SelectedIndex = -1
      Me.txtEmisor.Text = ""
      Me.txtNumero.Text = ""

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

      Dim oCtaCteDet As Reglas.CuentasCorrientesProvPagos = New Reglas.CuentasCorrientesProvPagos()

      Dim IdProveedor As Long = 0

      Dim TipoComprobante As String
      Dim Letra As String
      Dim Emisor As Integer
      Dim Numero As Integer

      Dim decSaldo As Decimal = 0

      Try

         IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())

         TipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         Letra = Me.cboLetra.SelectedValue.ToString()
         Emisor = Integer.Parse(Me.txtEmisor.Text)
         Numero = Integer.Parse(Me.txtNumero.Text)

         Me.dgvDetalle.DataSource = oCtaCteDet.GetKardexComprobante(actual.Sucursal.Id, IdProveedor, TipoComprobante, Letra, Emisor, Numero)

         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
            dr.Cells("Ver").Value = "..."
            decSaldo = decSaldo + Decimal.Parse(dr.Cells("ImporteCuota").Value.ToString())

         Next

         txtSaldo.Text = decSaldo.ToString("#,##0.00")

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

   Private Sub dgvDetalle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
      Try

         'Pregunto distinto porque el boton Ver se me cambia de Posicion de 0 a 1, ni idea...
         If e.RowIndex <> -1 AndAlso Me.dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() = "..." Then

            'If e.ColumnIndex = 0 And e.RowIndex <> -1 Then

            Try

               Me.Cursor = Cursors.WaitCursor

               Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()
               oTipoComprobante = New Reglas.TiposComprobantes().GetUno(Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString())

               If oTipoComprobante.EsRecibo = True Then

                  '  If Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString() = "PAGO" Or Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString() = "PAGOPROV" Then

                  Dim reg As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()
                  Dim ctacte As Entidades.CuentaCorrienteProv = reg.GetUna(actual.Sucursal.Id, _
                                 Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("IdProveedor").Value.ToString()), _
                                Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
                                Me.dgvDetalle.Rows(e.RowIndex).Cells("Letra").Value.ToString(), _
                                Int32.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
                                Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NroComprobante").Value.ToString()))
                  Dim imp As PagosImprimir = New PagosImprimir()
                  imp.ImprimirPago(ctacte, True)

               Else

                  Dim oCompras As Reglas.Compras = New Reglas.Compras()
                  Dim Compra As Entidades.Compra = oCompras.GetUna(actual.Sucursal.Id, _
                              Me.dgvDetalle.Rows(e.RowIndex).Cells("IdTipoComprobante").Value.ToString(), _
                              Me.dgvDetalle.Rows(e.RowIndex).Cells("Letra").Value.ToString(), _
                              Short.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("CentroEmisor").Value.ToString()), _
                              Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("NroComprobante").Value.ToString()), _
                              Long.Parse(Me.dgvDetalle.Rows(e.RowIndex).Cells("IdProveedor").Value.ToString()))

                  Dim oImpr As ImpresionCompra = New ImpresionCompra(Compra)

                  oImpr.ImprimirComprobante(True, Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral)

               End If

            Catch ex As Exception
               MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
               Me.Cursor = Cursors.Default
            End Try

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class