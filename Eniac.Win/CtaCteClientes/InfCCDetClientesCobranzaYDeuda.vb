#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
#End Region
Public Class InfCCDetClientesCobranzaYDeuda

#Region "Campos"

   Private _publicos As Publicos
   Private TotalContadoNeto As Decimal = 0
   Private TotalContadoFinal As Decimal = 0
   Private TotalCtaCteNeto As Decimal = 0
   Private TotalCtaCteFinal As Decimal = 0

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()


         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = -1

         Me._publicos.CargaComboCategorias(Me.cmbCategoria)
         Me.cmbCategoria.SelectedIndex = -1
         Me._publicos.CargaComboEmpleados(Me.cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
         Me.cmbCobrador.SelectedIndex = -1

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         _publicos.CargaComboDesdeEnum(cmbOrigenVendedor, GetType(Entidades.OrigenFK))
         cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Movimiento

         _publicos.CargaComboDesdeEnum(cmbOrigenCobrador, GetType(Entidades.OrigenFK))
         cmbOrigenCobrador.SelectedValue = Entidades.OrigenFK.Movimiento

         _publicos.CargaComboDesdeEnum(cmbOrigenCategoria, GetType(Entidades.OrigenFK))
         cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Movimiento

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

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

#End Region

#Region "Eventos"

   Private Sub InfCobranzasRealizadas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
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

   Private Sub tsbPreferencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Es obligatorio seleccionar un Cliente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbVendedor.Checked And Me.cmbVendedor.SelectedIndex < 0 Then
            MessageBox.Show("ATENCION: Marcó el filtro de Vendedor pero no seleccionó ninguno. Por favor verifique.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbVendedor.Focus()
            Exit Sub
         End If
         If Me.chbCobrador.Checked And Me.cmbCobrador.SelectedIndex < 0 Then
            MessageBox.Show("ATENCION: Marcó el filtro de Cobrador pero no seleccionó ninguno. Por favor verifique.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbCobrador.Focus()
            Exit Sub
         End If
         If Me.chbCategoria.Checked And Me.cmbCategoria.SelectedIndex < 0 Then
            MessageBox.Show("ATENCION: Marcó el filtro de Categoria pero no seleccionó ninguno. Por favor verifique.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmbCategoria.Focus()
            Exit Sub
         End If


         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillasDetalle()

         If Me.ugDetalle.Rows.Count > 0 Then
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

   Private Sub chbVendedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbVendedor.CheckedChanged

      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked
      cmbOrigenVendedor.Enabled = chbVendedor.Checked

      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         If Me.cmbVendedor.Items.Count > 0 Then
            Me.cmbVendedor.SelectedIndex = 0
         End If

         Me.cmbVendedor.Focus()

      End If

   End Sub

   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCliente.Enabled = Me.chbCliente.Checked
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked

      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Text = ""
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscCliente.Text = ""
      Else
         Me.bscCodigoCliente.Focus()
      End If

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
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
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
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



   Private Sub chbCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbCobrador.CheckedChanged

      Me.cmbCobrador.Enabled = Me.chbCobrador.Checked
      cmbOrigenCobrador.Enabled = chbCobrador.Checked

      If Not Me.chbCobrador.Checked Then
         Me.cmbCobrador.SelectedIndex = -1
      Else
         If Me.cmbCobrador.Items.Count > 0 Then
            Me.cmbCobrador.SelectedIndex = 0
         End If

         Me.cmbCobrador.Focus()

      End If

   End Sub

   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      Me.cmbCategoria.Enabled = Me.chbCategoria.Checked
      cmbOrigenCategoria.Enabled = chbCategoria.Checked

      If Not Me.chbCategoria.Checked Then
         Me.cmbCategoria.SelectedIndex = -1
      Else
         If Me.cmbCategoria.Items.Count > 0 Then
            Me.cmbCategoria.SelectedIndex = 0
         End If

         Me.cmbCategoria.Focus()

      End If

   End Sub
   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()

      With filtro

         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, False, True)

         .AppendFormat("Rango de Fechas: {0} - {1} - ", Me.dtpDesde.Text, Me.dtpHasta.Text)

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            .AppendFormat("Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.cmbVendedor.SelectedIndex >= 0 Then
            .AppendFormat("Vendedor: {0} - {1} - ", Me.cmbVendedor.Text, Me.cmbOrigenVendedor.Text)
         End If

         If Me.chbCategoria.Checked Then
            .AppendFormat("Categoría {0} - {1} - ", Me.cmbCategoria.Text, Me.cmbOrigenCategoria.Text)
         End If
         If Me.cmbCobrador.SelectedIndex >= 0 Then
            .AppendFormat("Cobrador: {0} - {1} - ", Me.cmbCobrador.Text, Me.cmbOrigenCobrador.Text)
         End If



      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function


   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub


         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         ugDetalle.Exportar(String.Format("{0},xls", Me.Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         ugDetalle.Exportar(String.Format("{0},xls", Me.Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
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

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today
      Me.cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Movimiento
      Me.chbCliente.Checked = False
      Me.chbVendedor.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      cmbSucursal.Refrescar()

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillasDetalle()

      Dim rCtaCte As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
      Dim desde As Date = Nothing
      Dim hasta As Date = Nothing

      Dim IdVendedor As Integer = 0

      Dim idCliente As Long = 0

      Try

         If Me.cmbVendedor.Enabled Then
            IdVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
         End If

         If Me.bscCodigoCliente.Text.Length > 0 Then
            idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
         End If

         Dim dt As DataTable
         dt = rCtaCte.GetCobrSemana(cmbSucursal.GetSucursales(), Me.dtpDesde.Value, Me.dtpHasta.Value, idCliente,
                                         IdVendedor, DirectCast(cmbOrigenVendedor.SelectedValue, Entidades.OrigenFK),
                                         If(chbCategoria.Checked, Integer.Parse(cmbCategoria.SelectedValue.ToString()), 0), DirectCast(cmbOrigenCategoria.SelectedValue, Entidades.OrigenFK),
                                         If(chbCobrador.Checked, Integer.Parse(cmbCobrador.SelectedValue.ToString()), 0), DirectCast(cmbOrigenCobrador.SelectedValue, Entidades.OrigenFK))
         ugDetalle.DataSource = dt
         FormatearGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub FormatearGrilla()

      With ugDetalle.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.NoEdit
         Next

         Dim pos As Integer = 0
         .Columns("CodigoCliente").FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns("NombreCliente").FormatearColumna("Cliente", pos, 220)
         .Columns("Direccion").FormatearColumna("Direccion", pos, 150)
         .Columns("Saldo").FormatearColumna("Saldo", pos, 80, HAlign.Right, , "N2")
         .Columns("NombreVendedor").FormatearColumna("Vendedor", pos, 100)
         .Columns("NombreCobrador").FormatearColumna("Cobrador", pos, 100)
         .Columns("IdTipoComprobante2").FormatearColumna("Tipo", pos, 70)
         .Columns("Letra2").FormatearColumna("L.", pos, 30, HAlign.Center)
         .Columns("CentroEmisor2").FormatearColumna("Emisor", pos, 50, HAlign.Right, , "0000")
         .Columns("NumeroComprobante2").FormatearColumna("Número", pos, 80, HAlign.Right)
         .Columns("Fecha").FormatearColumna("Fecha", pos, 80, HAlign.Center, , "dd/MM/yyyy")
         .Columns("NombreProductos").FormatearColumna("Producto", pos, 120)


         ugDetalle.InicializaTotales()
         For Each columna As UltraGridColumn In .Columns
            If (columna.Key.Length = 6 Or columna.Key.Length = 7) AndAlso columna.Key.Substring(4, 1) = "-" Then
               If Integer.Parse(columna.Key.Split("-"c)(1)) = 1 Then
                  columna.FormatearColumna(New DateTime(Integer.Parse(columna.Key.Split("-"c)(0)), 1, 1).ToString("dd/MM/yyyy"), pos, 80, HAlign.Right, , "N2")
               Else
                  columna.FormatearColumna(DateTimeExtensions.PrimerDiaSemanaISO8601(columna.Key).ToString("dd/MM/yyyy"), pos, 80, HAlign.Right, , "N2")
               End If
               ugDetalle.AgregarTotalSumaColumna(columna)
            End If
         Next

      End With

      ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreVendedor"})
      ugDetalle.ColumnasFijas({"CodigoCliente", "NombreCliente", "Direccion", "Saldo"})

      PreferenciasLeer(ugDetalle)

   End Sub


#End Region
End Class