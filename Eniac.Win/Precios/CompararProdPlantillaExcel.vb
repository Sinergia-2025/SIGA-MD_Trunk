Imports Infragistics.Win.UltraWinGrid

Public Class CompararProdPlantillaExcel

#Region "Campos"

   Private _publicos As Publicos
   Private rPublicos As Reglas.Publicos = New Reglas.Publicos

   Private Const selecColumnName As String = "Select" '# Columna sobre la cual va a responder el botón de selección

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()
         cmbMarca.Inicializar(False, True, True)
         cmbRubro.Inicializar(False, True, True)
         cmbSubRubro.Inicializar(False)
         cmbSubSubRubro.Inicializar(False)

         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnum))

         '# Inicializo las solapas
         Me.tbcDetalle.SelectedTab = tbpDatos
         Me.tbcDetalle.SelectedTab = tbpFiltros

         '# Visualización de Filtros
         Me.pSubRubro.Visible = Reglas.Publicos.ProductoTieneSubRubro
         Me.pSubSubRubro.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

         '# Filtros dinámicos
         CargarGrillaDetalle()
         AgregarFiltroEnLinea(Me.ugPlantillas, {"IdProveedor", "NombreProveedor"})
         AgregarFiltroEnLinea(Me.ugDatos, {"IdProducto", "NombreProducto"})

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Métodos"

   Private Sub MarcarDesmarcar(marcar As Boolean?, rows As UltraGridRow())
      For Each drTwo As UltraGridRow In rows
         If marcar.HasValue Then
            drTwo.Cells(selecColumnName).Value = marcar.Value
         Else
            drTwo.Cells(selecColumnName).Value = Not CBool(drTwo.Cells(selecColumnName).Value)
         End If
      Next
   End Sub

   Private Sub PintarCeldas()

      Dim dt As DataTable = DirectCast(Me.ugDatos.DataSource, DataTable)
      For Each row As DataRow In dt.Rows
         Dim menorcosto As Decimal = 999999999
         Dim colmenorcosto As String = String.Empty
         For Each col As DataColumn In dt.Columns
            If col.ColumnName.StartsWith("Pr. Costo") Or col.ColumnName = "Actual" Then
               Dim valor As String = row(col.ColumnName).ToString()
               If Not String.IsNullOrEmpty(valor) Then
                  If Decimal.Parse(valor) <= menorcosto Then
                     menorcosto = Decimal.Parse(valor)
                     colmenorcosto = col.ColumnName
                  End If
               End If
            End If
         Next
         Me.ugDatos.Rows(dt.Rows.IndexOf(row)).Cells(colmenorcosto).Appearance.BackColor = Color.LightGreen
         Me.ugDatos.UpdateData()
      Next

   End Sub

   Private Sub MostrarFiltroDatos()
      Me.lblFiltrosAplicados.Text = CargarFiltrosImpresion()
      Me.lblFiltrosAplicados.Visible = True
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro
         .AppendFormat("Marcas: {0}", Me.cmbMarca.Text)
         .AppendFormat(" - Rubros: {0}", Me.cmbRubro.Text)

         If Me.chbProducto.Checked Then
            .AppendFormat(" - Producto: {0}", Me.bscCodigoProducto2.Text, Me.bscProducto2.Text)
         End If
      End With

      Return filtro.ToString.Trim().Trim("-"c)
   End Function

   Private Function ValidarFiltros() As Boolean

      Dim dt As DataTable = DirectCast(Me.ugPlantillas.DataSource, DataTable)
      Dim count As Integer = 0
      For Each row As DataRow In dt.Rows
         If Boolean.Parse(row(selecColumnName).ToString()) Then
            count += 1
         End If
         If count = 1 Then
            Exit For
         End If
      Next
      If count = 0 Then
         ShowMessage("ATENCIÓN: No seleccionó ninguna plantilla para comparar.")
         Return False
      End If

      If Me.chbProducto.Checked AndAlso (Not Me.bscCodigoProducto2.Selecciono OrElse Not Me.bscProducto2.Selecciono) Then
         ShowMessage("ATENCIÓN: Activó filtro por Producto pero no seleccionó ninguno.")
         Me.bscCodigoProducto2.Focus()
         Return False
      End If

      Return True
   End Function

   Private Sub CompararProductos()

      Me.Cursor = Cursors.WaitCursor

      Dim rProveedoresProductosComparar As Reglas.ProveedoresProductosComparar = New Reglas.ProveedoresProductosComparar
      Dim dt As DataTable = DirectCast(Me.ugPlantillas.DataSource, DataTable)

      '# Filtros
      Dim idProducto As String = Me.bscCodigoProducto2.Text
      Dim marcas As Entidades.Marca() = Me.cmbMarca.GetMarcas(True)
      Dim rubros As Entidades.Rubro() = Me.cmbRubro.GetRubros(True)
      Dim subrubros As Entidades.SubRubro() = Me.cmbSubRubro.GetSubRubros(True)
      Dim subsubrubros As Entidades.SubSubRubro() = Me.cmbSubSubRubro.GetSubSubRubros(True)

      Me.ugDatos.DataSource = rProveedoresProductosComparar.CompararProductosEntreProveedores(dt,
                                                                                              idProducto,
                                                                                              marcas,
                                                                                              rubros,
                                                                                              subrubros,
                                                                                              subsubrubros)
      FormatearGrilla()
      MostrarFiltroDatos()
      Me.tbcDetalle.SelectedTab = tbpDatos

      If Me.ugDatos.Rows.Count = 0 Then ShowMessage("NO hay registros que cumplan con la selección !!!")

   End Sub

   Private Sub CargarDatosProducto(ByVal dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False
      Me.bscProducto2.Selecciono = True
      Me.bscCodigoProducto2.Selecciono = True
   End Sub

   Private Sub FormatearGrilla()

      With ugDatos.DisplayLayout.Bands(0)
         For Each col As UltraGridColumn In .Columns
            If col.Header.Caption.StartsWith("Pr. Costo") Then
               col.Width = 100
               col.CellAppearance.TextHAlign = HAlign.Right
               col.Format = String.Format("N{0}", Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnPrecio)
               col.CellActivation = Activation.ActivateOnly
            End If
         Next
      End With

      '# Pinto las celdas con el precio costo más bajo de cada producto
      PintarCeldas()

   End Sub

   Private Sub CargarGrillaDetalle()

      Dim rProveedoresComparar As Reglas.ProveedoresComparar = New Reglas.ProveedoresComparar
      Dim dt As DataTable = rProveedoresComparar.GetAll()

      '# Agrego la columna para seleccionar
      dt.Columns.Add(selecColumnName, GetType(Boolean))
      For Each row As DataRow In dt.Rows
         row(selecColumnName) = True
      Next
      Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarTodos
      Me.ugPlantillas.DataSource = dt

   End Sub
#End Region

#Region "Eventos"

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDatos.Rows.Count = 0 Then Exit Sub
         ugDatos.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDatos.Rows.Count = 0 Then Exit Sub
         ugDatos.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click

      Try

         If Me.ugDatos.Rows.Count = 0 Then Exit Sub

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
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         If ValidarFiltros() Then
            CompararProductos()
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugPlantilllas_AfterRowActivate(sender As Object, e As EventArgs)

      Try
         Me.ugPlantillas.UpdateData()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click

      Try
         Me.ugDatos.ClearFilas()
         Me.tbcDetalle.SelectedTab = tbpFiltros
         Me.chbProducto.Checked = False
         Me.cmbMarca.Refrescar()
         Me.cmbRubro.Refrescar()
         Me.cmbSubRubro.Refrescar()
         Me.cmbSubSubRubro.Refrescar()
         Me.lblFiltrosAplicados.Text = String.Empty
         Me.lblFiltrosAplicados.Visible = False

         CargarGrillaDetalle()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged

      Try
         Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
         Me.bscProducto2.Enabled = Me.chbProducto.Checked

         If Not Me.chbProducto.Checked Then
            Me.bscCodigoProducto2.Text = String.Empty
            Me.bscProducto2.Text = String.Empty
            Me.bscCodigoProducto2.Selecciono = False
            Me.bscProducto2.Selecciono = False
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub ugDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDatos.InitializeRow
      If ugDatos.Rows.Count = 0 Then Exit Sub

      Try

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click

      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnum Then

            Me.Cursor = Cursors.WaitCursor

            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnum)
               Case Reglas.Publicos.TodosEnum.MararTodos
                  MarcarDesmarcar(True, ugPlantillas.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarTodos

               Case Reglas.Publicos.TodosEnum.DesmarcarTodos
                  MarcarDesmarcar(False, ugPlantillas.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos

               Case Reglas.Publicos.TodosEnum.MarcarFiltrados
                  MarcarDesmarcar(True, ugPlantillas.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarFiltrados

               Case Reglas.Publicos.TodosEnum.DesmarcarFiltrados
                  MarcarDesmarcar(False, ugPlantillas.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MarcarFiltrados

               Case Reglas.Publicos.TodosEnum.InvertirMarcasTodos
                  MarcarDesmarcar(Nothing, ugPlantillas.Rows.ToArray())

               Case Reglas.Publicos.TodosEnum.InvertirMarcasFiltrados
                  MarcarDesmarcar(Nothing, ugPlantillas.Rows.GetFilteredInNonGroupByRows())

               Case Else

            End Select
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
         ugPlantillas.UpdateData()
      End Try

   End Sub

   Private Sub tsbEliminarPlantilla_Click(sender As Object, e As EventArgs) Handles tsbEliminarPlantilla.Click

      Try

         If Me.ugPlantillas.Rows.Count = 0 Then Exit Sub

         Dim rProveedoresComparar As Reglas.ProveedoresComparar = New Reglas.ProveedoresComparar
         Dim dr As DataRow = Me.ugPlantillas.FilaSeleccionada(Of DataRow)()

         '# Mensaje de confirmación
         Dim mensaje As String = String.Format("¿Desea eliminar la plantilla {0} del Proveedor {1} {2} de la lista de Comparación?",
                                               dr(Entidades.Plantilla.Columnas.NombrePlantilla.ToString()).ToString(),
                                               dr(Entidades.ProveedorComparar.Columnas.IdProveedor.ToString()).ToString(),
                                               dr(Entidades.Proveedor.Columnas.NombreProveedor.ToString()).ToString())
         If (ShowPregunta(mensaje)) = Windows.Forms.DialogResult.Yes Then
            rProveedoresComparar.Borrar(New Entidades.ProveedorComparar With {.IdProveedor = dr.Field(Of Long)(Entidades.ProveedorComparar.Columnas.IdProveedor.ToString())})

            ShowMessage("Plantilla eliminada correctamente !!!")
            CargarGrillaDetalle()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tbcDetalle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcDetalle.SelectedIndexChanged

      Try
         Me.tsbEliminarPlantilla.Visible = Me.tbcDetalle.SelectedTab Is tbpFiltros
         Me.tss3.Visible = Me.tbcDetalle.SelectedTab Is tbpFiltros
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub cmbRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro.AfterSelectedIndexChanged
      Try
         If Reglas.Publicos.ProductoTieneSubRubro Then
            Dim rubros As Entidades.Rubro() = Me.cmbRubro.GetRubros()
            Me.cmbSubRubro.Inicializar(True, True, True, rubros)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbSubRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubro.AfterSelectedIndexChanged
      Try
         If Reglas.Publicos.ProductoTieneSubSubRubro Then
            Dim subrubros As Entidades.SubRubro() = Me.cmbSubRubro.GetSubRubros()
            Me.cmbSubSubRubro.Inicializar(True, True, True, subrubros)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

End Class