Public Class ProdActualizacionMasivaCodigos

#Region "Globals"

   Dim _publicos As Publicos
   Dim _dt As DataTable
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         '# Incializo todos los combos
         Me.cmbRubro.Inicializar(False, True, True)
         Me.cmbMarca.Inicializar(False, True, True)
         If Reglas.Publicos.ProductoTieneSubRubro Then
            Me.cmbSubRubro.Inicializar(False)
            Me.pSubRubro.Visible = True
         End If
         Me._publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnumSI))

         Me.PreferenciasLeer(Me.ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Subs"

   Private Sub Grabar()
      Dim rProductos As Reglas.Productos = New Reglas.Productos
      For Each row As DataRow In _dt.Select("(NuevoIdProducto <> IdProducto)")
         rProductos.CambiarCodigo(row.Field(Of String)("IdProducto"),
                                  row.Field(Of String)("NuevoIdProducto"), Reglas.Publicos.NombreBaseProductosWeb,
                                  row.Field(Of Integer?)("IdFormula"))
      Next
      '# IdProductoNumerico
      For Each rw As DataRow In _dt.Select("(NuevoIdProductoNumerico IS NOT NULL)")
         '# Si el IdProductoNuevo no es nulo, se toma ese Código, ya que fue cambiado recientemente.
         Dim id As String = If(Not String.IsNullOrEmpty(rw.Field(Of String)("NuevoIdProducto")), rw.Field(Of String)("NuevoIdProducto"), rw.Field(Of String)("IdProducto"))
         rProductos.ActualizarIdProductoNumerico(id,
                                                 rw.Field(Of Long)("NuevoIdProductoNumerico"))
      Next

      ShowMessage("Los datos se actualizaron con exito !!")
   End Sub

   Private Sub MostrarNuevoCodigo()
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("NuevoIdProducto").Hidden = False
   End Sub

   Private Function ValidarGrabacion() As Boolean
      Dim table As DataTable = DirectCast(Me.ugDetalle.DataSource, DataTable)
      Dim msgSeleccionados As StringBuilder = New StringBuilder
      Dim msgExistentes As StringBuilder = New StringBuilder
      Dim msgExcesoCaracteres As StringBuilder = New StringBuilder
      Dim maxCaracteres As Integer = New Reglas.Publicos().GetAnchoCampo("Productos", "IdProducto")
      Dim rProductos As Reglas.Productos = New Reglas.Productos
      Dim countSeleccionados As Integer = 0

      For Each dr As DataRow In table.Select("(NuevoIdProducto <> '' AND (NuevoIdProducto <> IdProducto)) OR (NuevoIdProductoNumerico IS NOT NULL AND (NuevoIdProductoNumerico <> IdProductoNumerico)) OR (IdProductoNumerico IS NULL AND NuevoIdProductoNumerico IS NOT NULL)")

         '# Valido que todos los nuevos códigos de productos no estén siendo ya utilizados
         With msgExistentes
            If Not String.IsNullOrEmpty(dr("NuevoIdProducto").ToString()) AndAlso (dr.Field(Of String)("IdProducto") <> dr.Field(Of String)("NuevoIdProducto")) Then
               If rProductos.Existe(dr.Field(Of String)("NuevoIdProducto")) Then
                  .AppendFormatLine("Se ingresó un nuevo código para el Producto: {0}, pero el código ya está siendo utilizado en otro producto. Debe cambiarlo para actualizar.",
                                 dr.Field(Of String)("NombreProducto")).AppendLine()
               End If
            End If

            '# Valido que los nuevos códigos de productos ingresados no se solapen con otros nuevos códigos ingresados
            Dim condition As String = String.Format("NuevoIdProducto = '{0}' AND IdProducto <> '{1}'",
                                                    dr.Field(Of String)("NuevoIdProducto"),
                                                    dr.Field(Of String)("IdProducto"))
            If table.Select(condition).Count > 0 Then
               .AppendFormatLine("Se ingresó un nuevo código para el Producto: {0}, pero el código ya fué ingresado para actualizar en otro producto. Debe cambiarlo para actualizar.",
                                 dr.Field(Of String)("NombreProducto")).AppendLine()
            End If
         End With

         '# Valido que ninguno de los Nuevos Códigos se pase de los caracteres permitidos
         With msgExcesoCaracteres
            If Not String.IsNullOrEmpty(dr("NuevoIdProducto").ToString()) AndAlso dr.Field(Of String)("NuevoIdProducto").Length > maxCaracteres Then
               .AppendFormatLine("Se ingresó un nuevo código para el Producto: {0}, pero el código excede la cantidad permitida de caracteres ({1}). Debe cambiarlo para actualizar.",
                                 dr.Field(Of String)("NombreProducto"),
                                 maxCaracteres).AppendLine()
            End If
            If Not IsDBNull(dr("NuevoIdProductoNumerico")) AndAlso dr.Field(Of Long)("NuevoIdProductoNumerico").ToString().Length > maxCaracteres Then
               .AppendFormatLine("Se ingresó un nuevo código numérico para el Producto: {0}, pero el código excede la cantidad permitida de caracteres ({1}). Debe cambiarlo para actualizar.",
                                 dr.Field(Of String)("NombreProducto"),
                                 maxCaracteres).AppendLine()
            End If
         End With
         countSeleccionados += 1
      Next

      Dim ok As Boolean = True
      If Not String.IsNullOrEmpty(msgSeleccionados.ToString()) Then
         ShowMessage(msgSeleccionados.ToString())
         ok = False
      End If
      If Not String.IsNullOrEmpty(msgExistentes.ToString()) Then
         ShowMessage(msgExistentes.ToString())
         ok = False
      End If
      If Not String.IsNullOrEmpty(msgExcesoCaracteres.ToString()) Then
         ShowMessage(msgExcesoCaracteres.ToString())
         ok = False
      End If
      If countSeleccionados = 0 Then
         ShowMessage("ATENCIÓN: No se han ingresado nuevos códigos para actualizar.")
         ok = False
      End If

      Return ok
   End Function

   Private Sub AplicarCambios()

      Me.MostrarNuevoCodigo()

      '# Guardo las opciones de cambio aplicadas en variables
      Dim prefijo As String = If(Me.chbPrefijo.Checked, Me.txtPrefijo.Text, String.Empty)
      Dim sufijo As String = If(Me.chbSufijo.Checked, Me.txtSufijo.Text, String.Empty)
      Dim letraA As String = String.Empty
      Dim letraB As String = String.Empty
      Dim nuevoCodigo As String = String.Empty
      If Me.chbReemplazarCaracter.Checked Then
         letraA = Me.txtReemplazarCaracter1.Text
         letraB = Me.txtReemplazarCaracter2.Text
      End If

      '# Comienzo el proceso de cambiar los códigos seleccionados
      For Each dr As DataRow In _dt.Select("Check = 'True'")
         nuevoCodigo = dr.Field(Of String)("IdProducto") '# Seteo el código actual 

         '# Reemplazo caracter
         If Me.chbReemplazarCaracter.Checked Then nuevoCodigo = dr.Field(Of String)("IdProducto").Replace(letraA, letraB)

         '# Agrego prefijo y sufijo
         nuevoCodigo = String.Format("{0}{1}{2}", prefijo, nuevoCodigo, sufijo)

         '# Muestro el Código en la columna correspondiente
         dr("NuevoIdProducto") = nuevoCodigo
         Me.ugDetalle.UpdateData()
      Next

   End Sub

   Private Function ValidarOpciones() As Boolean

      '# Si no seleccionó ninguna opción
      If Not Me.chbPrefijo.Checked AndAlso Not Me.chbSufijo.Checked AndAlso Not Me.chbReemplazarCaracter.Checked Then
         ShowMessage("ATENCIÓN: No seleccionó ninguna opción de cambio.")
         Return False
      End If

      '# Si no seleccionó ningun registro a cambiar
      If DirectCast(Me.ugDetalle.DataSource, DataTable).Select("Check = 'True'").Count = 0 Then
         ShowMessage("ATENCIÓN: No seleccionó ningun producto a modificar.")
         Return False
      End If

      If Me.chbPrefijo.Checked AndAlso String.IsNullOrEmpty(Me.txtPrefijo.Text) Then
         ShowMessage("ATENCIÓN: Seleccionó la opción de Prefijo pero no ingresó ninguno.")
         Return False
      End If
      If Me.chbSufijo.Checked AndAlso String.IsNullOrEmpty(Me.txtSufijo.Text) Then
         ShowMessage("ATENCIÓN: Seleccionó la opción de Sufijo pero no ingresó ninguno.")
         Return False
      End If
      If Me.chbReemplazarCaracter.Checked AndAlso (String.IsNullOrEmpty(Me.txtReemplazarCaracter1.Text) OrElse String.IsNullOrEmpty(Me.txtReemplazarCaracter2.Text)) Then
         ShowMessage("ATENCIÓN: Seleccionó la opción de Reemplazar pero no completó los caracteres a reemplazar.")
         Return False
      End If

      Return True
   End Function

   Private Function GetRegistersCount() As String
      Return String.Format("{0} Registros", DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Count)
   End Function

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Selecciono = True
      Me.bscCodigoProducto2.Selecciono = True
   End Sub

   Private Sub FormatearGrilla()
      Dim pos As Integer = 0
      With Me.ugDetalle.DisplayLayout.Bands(0)
         .Columns("Check").FormatearColumna("Aplicar A", pos, 60, HAlign.Center)
         .Columns("Check").CellActivation = UltraWinGrid.Activation.AllowEdit

         .Columns("IdProducto").FormatearColumna("Código", pos, 100, HAlign.Left)
         .Columns("NuevoIdProducto").FormatearColumna("Nuevo Código", pos, 100, HAlign.Left, True)
         .Columns("NuevoIdProducto").CellActivation = UltraWinGrid.Activation.AllowEdit

         .Columns("IdProductoNumerico").FormatearColumna("Cód. Numérico", pos, 100, HAlign.Left, If(Reglas.Publicos.HabilitaCodigoNumericoProducto, False, True))
         .Columns("NuevoIdProductoNumerico").FormatearColumna("Nuevo Cód. Numérico", pos, 100, HAlign.Right, If(Reglas.Publicos.HabilitaCodigoNumericoProducto, False, True), , "nnnnnnnnnnnn")
         .Columns("NuevoIdProductoNumerico").CellActivation = UltraWinGrid.Activation.AllowEdit

         .Columns("IdFormula").FormatearColumna("IdFormula", pos, 60, HAlign.Left, True)
         .Columns("NombreProducto").FormatearColumna("Producto", pos, 220, HAlign.Left)
         .Columns("NombreMarca").FormatearColumna("Marca", pos, 140, HAlign.Left)
         .Columns("NombreRubro").FormatearColumna("Rubro", pos, 140, HAlign.Left)
         .Columns("NombreSubRubro").FormatearColumna("SubRubro", pos, 140, HAlign.Left, Not Reglas.Publicos.ProductoTieneSubRubro)

         '# Filtro en linea Contiene
         AgregarFiltroEnLinea(ugDetalle, {"IdProducto", "IdProductoNumerico", "NombreProducto", "NombreMarca", "NombreRubro", "NombreSubRubro"})
      End With
   End Sub

   Private Sub CargarGrillaDetalle()

      '# Validación de la selección del buscador de Producto
      If Me.chbProducto.Checked AndAlso Not (Me.bscProducto2.Selecciono AndAlso Me.bscCodigoProducto2.Selecciono) Then
         ShowMessage("ATENCIÓN: Activó el filtro por Producto pero no seleccionó uno.")
         Me.bscCodigoProducto2.Focus()
         Exit Sub
      End If

      '# Filters
      Dim codigoProducto As String = If(Me.chbProducto.Checked, Me.bscCodigoProducto2.Text, "0")
      Dim marcas As Entidades.Marca() = Me.cmbMarca.GetMarcas()
      Dim rubros As Entidades.Rubro() = Me.cmbRubro.GetRubros()

      Dim subrubros As Entidades.SubRubro() = Nothing
      If Reglas.Publicos.ProductoTieneSubRubro Then
         subrubros = Me.cmbSubRubro.GetSubRubros(True)
      End If

      Dim rProductos As Reglas.Productos = New Reglas.Productos
      _dt = rProductos.GetProductosActualizacionCodigo(actual.Sucursal.Id,
                                                                       marcas,
                                                                       rubros,
                                                                       subrubros,
                                                                       codigoProducto)
      '# Si hay registros, hago primer plano en la solapa para ingresar las opciones de cambio
      If _dt IsNot Nothing Then
         _dt.Columns.Add("Check", GetType(Boolean)) '# Check
         _dt.Columns.Add("NuevoIdProducto", GetType(String)) '# Nuevo Código de Producto
         _dt.Columns.Add("NuevoIdProductoNumerico", GetType(Long)) '# Nuevo Código de Producto Numérico

         Me.LimpiarMarcados()
         Me.ugDetalle.DataSource = _dt

         FormatearGrilla()
         MostrarNuevoCodigo()
         PreferenciasLeer(ugDetalle, tsbPreferencias)

         Me.tabFiltroOpciones.SelectedTab = tbpOpciones
      End If

   End Sub
#End Region

#Region "Events"
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Try
         Me.close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbPrefijo_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrefijo.CheckedChanged
      Try
         Me.txtPrefijo.Enabled = Me.chbPrefijo.Checked
         If Not Me.chbPrefijo.Checked Then
            Me.txtPrefijo.Clear()
         Else
            Me.txtPrefijo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbSufijo_CheckedChanged(sender As Object, e As EventArgs) Handles chbSufijo.CheckedChanged
      Try
         Me.txtSufijo.Enabled = Me.chbSufijo.Checked
         If Not Me.chbSufijo.Checked Then
            Me.txtSufijo.Clear()
         Else
            Me.txtSufijo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbReemplazarCaracter_CheckedChanged(sender As Object, e As EventArgs) Handles chbReemplazarCaracter.CheckedChanged
      Try
         Dim enabled As Boolean = Me.chbReemplazarCaracter.Checked
         Me.txtReemplazarCaracter1.Enabled = enabled
         Me.txtReemplazarCaracter2.Enabled = enabled
         If Not enabled Then
            Me.txtReemplazarCaracter1.Clear()
            Me.txtReemplazarCaracter2.Clear()
         Else
            Me.txtReemplazarCaracter1.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro.AfterSelectedIndexChanged
      Try
         If cmbRubro.SelectedIndex > -1 Then
            Dim rubros As Entidades.Rubro() = cmbRubro.GetRubros()
            cmbSubRubro.Inicializar(True, True, True, rubros)
         End If
         cmbSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      Try

         Me.Cursor = Cursors.WaitCursor

         If _dt IsNot Nothing Then
            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnumSI)
               Case Reglas.Publicos.TodosEnumSI.MarcarTodos
                  For Each dr As DataRow In _dt.Rows
                     dr("Check") = True
                  Next
                  Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.DesmarcarTodos

               Case Reglas.Publicos.TodosEnumSI.DesmarcarTodos
                  Me.LimpiarMarcados()
                  Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos

               Case Reglas.Publicos.TodosEnumSI.InvertirMarcasTodos
                  For Each dr As DataRow In _dt.Rows
                     dr("Check") = Not CBool(dr("Check"))
                  Next

            End Select
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      Try
         Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
         Me.bscProducto2.Enabled = Me.chbProducto.Checked
         If Me.chbProducto.Checked Then
            bscCodigoProducto2.Focus()
         End If
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub LimpiarMarcados()
      For Each dr As DataRow In _dt.Rows
         dr("Check") = False
      Next
      Me.ugDetalle.UpdateData()
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Dim f As Boolean = False
         Me.chbProducto.Checked = f
         Me.chbPrefijo.Checked = f
         Me.chbSufijo.Checked = f
         Me.chbReemplazarCaracter.Checked = f

         Me.cmbMarca.Refrescar()
         Me.cmbRubro.Refrescar()
         Me.LimpiarMarcados()
         Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("NuevoIdProducto").Hidden = True
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("NuevoIdProductoNumerico").Hidden = True
         Me.ugDetalle.ClearFilas()

         Me.tabFiltroOpciones.SelectedTab = tbpFiltros
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargarGrillaDetalle()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
         Me.tssRegistros.Text = Me.GetRegistersCount()
      End Try
   End Sub

   Private Sub btnAplicarCambios_Click(sender As Object, e As EventArgs) Handles btnAplicarCambios.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         If Me.ValidarOpciones() Then
            Me.AplicarCambios()
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
         Me.PreferenciasLeer(Me.ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.ugDetalle.UpdateData()
         If Me.ValidarGrabacion() Then
            Me.Grabar()

            Me.tabFiltroOpciones.SelectedTab = tbpFiltros
            Me.tsbRefrescar_Click(sender, e)
            Me.CargarGrillaDetalle()
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub Actualizador_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      Select Case e.KeyCode
         Case Keys.F4
            Me.tsbGrabar.PerformClick()
         Case Keys.F5
            Me.tsbRefrescar.PerformClick()
      End Select
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      Try
         Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)(e.Row)
         If Not String.IsNullOrEmpty(dr.Field(Of String)("NuevoIdProducto")) AndAlso (dr.Field(Of String)("IdProducto") <> dr.Field(Of String)("NuevoIdProducto")) Then
            e.Row.Cells("NuevoIdProducto").Appearance.BackColor = Color.Cyan
         Else
            e.Row.Cells("NuevoIdProducto").Appearance.BackColor = Nothing
         End If
         If IsNumeric(dr("NuevoIdProductoNumerico")) AndAlso (dr("IdProductoNumerico").ToString() <> dr.Field(Of Long)("NuevoIdProductoNumerico").ToString()) Then
            e.Row.Cells("NuevoIdProductoNumerico").Appearance.BackColor = Color.Cyan
         Else
            e.Row.Cells("NuevoIdProductoNumerico").Appearance.BackColor = Nothing
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

End Class