Public Class InformeDescCliProdMarcaRubro

#Region "Campos"
   Private _publicos As Publicos
   Private _tit As Dictionary(Of String, String)
#End Region


#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      TryCatched(Sub()
                    PreferenciasLeer(ugDetalle, tsbPreferencias)
                 End Sub)

      _publicos = New Publicos()

         Me._publicos.CargaComboMarcas(Me.cmbMarca)
         Me._publicos.CargaComboRubros(Me.cmbRubro)
         Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)


      '# Filtros en Linea
      'Me.ugDetalle.AgregarFiltroEnLinea({"IdProducto", "NombreProducto"})

      If Not Reglas.Publicos.ProductoTieneSubRubro Then
         Me.cmbSubRubro.Visible = False
         Me.chbSubRubro.Visible = False
      End If

      Me.Refrescar()
      _tit = GetColumnasVisiblesGrilla(ugDetalle)

   End Sub

#End Region

#Region "Eventos"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Refrescar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub InformeDescCliProdMarcaRubro_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         If ugDetalle.Rows.Count = 0 Then Exit Sub

         ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         If ugDetalle.Rows.Count = 0 Then Exit Sub

         ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try

         If ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = Me.CargarFiltrosImpresion
         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraPrintPreviewDialog1.Name = Me.Text
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
         ShowError(ex)
      End Try
   End Sub
   Private Sub UltraGridPrintDocument1_PagePrinting(ByVal sender As System.Object, ByVal e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub
   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      Me.cmbMarca.Enabled = Me.chbMarca.Checked

      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         If Me.cmbMarca.Items.Count > 0 Then
            Me.cmbMarca.SelectedIndex = 0
         End If
         'Si elijo una marca, limpio el producto seleccionado (hipotericamente)
         'La Marca la dejo porque puede intencionalmente hacer un filtro combinado
         Me.chbProducto.Checked = False
      End If
      Me.cmbMarca.Focus()
   End Sub

   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged
      Me.cmbRubro.Enabled = Me.chbRubro.Checked

      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
      Else
         If Me.cmbRubro.Items.Count > 0 Then
            Me.cmbRubro.SelectedIndex = 0
         End If
         'Si elijo una marca, limpio el producto seleccionado (hipotericamente)
         'La Marca la dejo porque puede intencionalmente hacer un filtro combinado
         Me.chbProducto.Checked = False
      End If

      Me.cmbRubro.Focus()
   End Sub

   Private Sub chbSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubRubro.CheckedChanged
      Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

      If Not Me.chbSubRubro.Checked Then
         Me.cmbSubRubro.SelectedIndex = -1
      Else
         If Me.cmbSubRubro.Items.Count > 0 Then
            Me.cmbSubRubro.SelectedIndex = 0
         End If
      End If

      Me.cmbRubro.Focus()
   End Sub

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
         Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
         Me.bscProducto2.Enabled = Me.chbProducto.Checked

         If Not Me.chbProducto.Checked Then
            Me.bscCodigoProducto2.Text = String.Empty
            Me.bscProducto2.Text = String.Empty
         Else
            chbMarca.Checked = False
            chbRubro.Checked = False
         End If

         Me.bscCodigoProducto2.Focus()
   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked

      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()
   End Sub
   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
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
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta, bscCodigoCliente, bscCliente)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta, bscCodigoCliente, bscCliente)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

      Try
         If Me.chbMarca.Checked And Me.cmbMarca.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Marca aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbMarca.Focus()
            Exit Sub
         End If

         If Me.chbRubro.Checked And Me.cmbRubro.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbRubro.Focus()
            Exit Sub
         End If

         If Me.chbSubRubro.Checked And Me.cmbSubRubro.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Sub Rubro aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbSubRubro.Focus()
            Exit Sub
         End If

         If Me.chbProducto.Checked And Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar()

         If ugDetalle.Rows.Count > 0 Then

            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            Me.tssRegistros.Text = "0 Registros"
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try


   End Sub

#End Region

#Region "Métodos"
   Private Sub Refrescar()

      Me.chbCliente.Checked = False
      Me.chbProducto.Checked = False
      Me.chbMarca.Checked = False
      Me.chbRubro.Checked = False
      Me.chbSubRubro.Checked = False

      Me.cmbMarca.SelectedIndex = -1
      Me.cmbRubro.SelectedIndex = -1
      Me.cmbSubRubro.SelectedIndex = -1

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False

      Me.tssRegistros.Text = ugDetalle.Rows.Count.ToString() & " Registros"

      lblExistenMasRegistros.Visible = False
      txtMaxRegistros.Text = "100000"

      If Me.ugDetalle.Rows.Count > 0 Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If
   End Sub
   Private Sub CargarProducto(ByVal dr As DataGridViewRow)

      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False

   End Sub
   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow, controlCodigo As Eniac.Controles.Buscador2, controlNombre As Eniac.Controles.Buscador2)

      controlNombre.Text = dr.Cells("NombreCliente").Value.ToString()
      controlCodigo.Text = dr.Cells("CodigoCliente").Value.ToString()
      controlCodigo.Tag = dr.Cells("IdCliente").Value.ToString()
      controlNombre.Enabled = False
      controlCodigo.Enabled = False
      controlNombre.Selecciono = True
      controlCodigo.Selecciono = True
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim reg = New Reglas.Clientes()

      Dim idProducto As String = String.Empty
      Dim idMarca As Integer = 0
      Dim idRubro As Integer = 0
      Dim idSubRubro As Integer = 0
      Dim idCliente = (If(chbCliente.Checked, ObjectExtensions.ValorNumericoPorDefecto(bscCodigoCliente.Tag, 0L), 0L))
      Dim maxRegistros As Integer = 0

      If Me.chbProducto.Checked Then
         idProducto = Me.bscCodigoProducto2.Text.Trim()
      End If
      If Me.chbMarca.Checked Then
         idMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
      End If
      If Me.chbRubro.Checked Then
         idRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
      End If
      If Me.chbSubRubro.Checked Then
         idSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
      End If

      If Integer.Parse(Me.txtMaxRegistros.Text.ToString()) > 0 Then
         maxRegistros = Integer.Parse(Me.txtMaxRegistros.Text.ToString())
      End If

      ugDetalle.ClearFilas()
      Dim dtTemp = If(TypeOf (ugDetalle.DataSource) Is IDisposable, DirectCast(ugDetalle.DataSource, IDisposable), Nothing)

      Dim dtDetalle As DataTable = reg.GetInformeDescuentosClientesPMR(idProducto, idMarca, idRubro, idSubRubro, idCliente, maxRegistros)

      Me.ugDetalle.DataSource = dtDetalle
      If maxRegistros = ugDetalle.Count Then
         lblExistenMasRegistros.Visible = True
      Else
         'Si la consulta devuelve menos registros del tope se Oculta la etiqueta
         lblExistenMasRegistros.Visible = False
      End If

      If dtTemp IsNot Nothing Then dtTemp.Dispose()

      AjustarColumnasGrilla(ugDetalle, _tit)
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         If Me.cmbMarca.SelectedIndex >= 0 Then
            .AppendFormat(" Vendedor: {0} - ", Me.cmbMarca.SelectedText)
         End If

         If Me.cmbRubro.SelectedIndex >= 0 Then
            .AppendFormat(" Vendedor: {0} - ", Me.cmbRubro.SelectedText)
         End If

         If Me.cmbSubRubro.SelectedIndex >= 0 Then
            .AppendFormat(" Vendedor: {0} - ", Me.cmbSubRubro.SelectedText)
         End If

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.bscCodigoProducto2.Text.Length > 0 And Me.bscProducto2.Text.Length > 0 Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoProducto2.Text, Me.bscProducto2.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

#End Region

End Class