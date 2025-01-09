Option Strict Off
Imports Infragistics.Win.UltraWinGrid

Public Class ProductosPorCliente

#Region "Campos"

   Private _dtProductos As DataTable
   Private _dtProductosCliente As DataTable
   Private _publicos As Publicos
   Private _cargandoPantalla As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._cargandoPantalla = True
         _publicos = New Publicos()

         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            Me.lblSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
         End If


         cmbSubRubro.ConcatenarNombreRubro = True
         cmbMarca.Inicializar(False, True, True)
         cmbRubro.Inicializar(False, True, True)


         Me.cmbMarca.Enabled = False
         Me.cmbRubro.Enabled = False
         Me.cmbSubRubro.Enabled = False


         RefrescarGrilla()

         spcDatos.Enabled = True

         spcDatos.Enabled = False


         tsbPreferencias.Enabled = True
         tsbGrabar.Enabled = False


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me._cargandoPantalla = False
      End Try

   End Sub

   Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
      MyBase.OnClosing(e)
      Try
         Me.ControlaCambios()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"


   Private Sub ControlaCambios()
      If Me.tsbGrabar.Enabled Then
         If ShowPregunta("¿Desea grabar los cambios?") = Windows.Forms.DialogResult.Yes Then
            Me.Grabar()
         End If
      End If
   End Sub


   Private Sub Grabar()

      Dim oProductosCliente As Reglas.ProductosClientes = New Reglas.ProductosClientes

      oProductosCliente.Guardar(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), _dtProductosCliente)

      Me.Cursor = Cursors.Default
      MessageBox.Show("Productos  de Cliente grabados exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      RefrescarGrilla()

   End Sub
   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False
      Me.cmbMarca.Enabled = True
      Me.cmbRubro.Enabled = True
      Me.cmbSubRubro.Enabled = True
      CargarDatos()
   End Sub
   Private Sub RefrescarGrilla()

      Me.tsbGrabar.Enabled = False

      spcDatos.Enabled = False

      Me.bscCodigoCliente.Text = ""
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Text = ""

      Me.bscCliente.Enabled = True
      Me.bscCodigoCliente.Enabled = True
      Me.cmbMarca.Enabled = False
      Me.cmbRubro.Enabled = False
      Me.cmbSubRubro.Enabled = False

      cmbMarca.Refrescar()
      cmbRubro.Refrescar()
      cmbSubRubro.Refrescar()

      If Not Me.ugProductos.DataSource Is Nothing Then
         DirectCast(ugProductos.DataSource, DataTable).Rows.Clear()
      End If


      If Not Me.ugProductosCliente.DataSource Is Nothing Then
         DirectCast(ugProductosCliente.DataSource, DataTable).Rows.Clear()
      End If

   End Sub

   Private Sub FormateaGrillaProductos()
      FormateaGrilla(Me.ugProductos, True)
   End Sub

   Private Sub FormateaGrillaProductosCliente()
      FormateaGrilla(Me.ugProductosCliente, False)
   End Sub
   Private Sub FormateaGrilla(grilla As UltraGrid, muestraCantidadVisitas As Boolean)

      Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"NombreProducto", "NombreMarca", "NombreRubro", "NombreSubRubro"})
      If Not Reglas.Publicos.ProductoTieneSubRubro Then
         grilla.DisplayLayout.Bands(0).Columns("NombreSubRubro").FormatearColumna("SubRubro", 999, 65, HAlign.Right, True)
      End If
   End Sub

#End Region

#Region "Eventos"

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
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

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
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

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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


   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub ugProductos_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugProductos.MouseDoubleClick
      Me.btnAgregar_Click(sender, e)
   End Sub



   Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
      Try
         AgregarProductosAClientes()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub AgregarProductosAClientes()
      Me.Cursor = Cursors.WaitCursor

      If ugProductos.Selected.Rows.Count = 0 And ugProductos.ActiveRow IsNot Nothing Then
         ugProductos.ActiveRow.Selected = True
      End If

      Try
         Dim drProductoCol As List(Of DataRow) = New List(Of DataRow)()
         For Each dgProducto As UltraGridRow In ugProductos.Selected.Rows
            If dgProducto.ListObject IsNot Nothing AndAlso
               TypeOf (dgProducto.ListObject) Is DataRowView AndAlso
               DirectCast(dgProducto.ListObject, DataRowView).Row IsNot Nothing Then
               drProductoCol.Add(DirectCast(dgProducto.ListObject, DataRowView).Row)
            End If
         Next
         For Each drProducto As DataRow In drProductoCol
            Dim drProductoCliente As DataRow = _dtProductosCliente.NewRow()

            For Each dc As DataColumn In _dtProductos.Columns
               If drProductoCliente.Table.Columns.Contains(dc.ColumnName) Then
                  drProductoCliente(dc.ColumnName) = drProducto(dc.ColumnName)
               End If
            Next

            _dtProductosCliente.Rows.Add(drProductoCliente)
            _dtProductosCliente.AcceptChanges()
            drProducto.Delete()
            _dtProductos.AcceptChanges()

         Next

         tsbGrabar.Enabled = True

      Catch
         _dtProductosCliente.RejectChanges()
         _dtProductos.RejectChanges()
         Throw
      End Try
   End Sub
   Private Sub ugProductosCliente_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ugProductosCliente.DragEnter
      e.Effect = DragDropEffects.Copy
   End Sub
   Private Sub btnSacar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSacar.Click
      Try
         Me.EliminarProductosCliente()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub ugProductosCliente_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugProductosCliente.MouseDoubleClick
      Me.btnSacar_Click(sender, e)
   End Sub
   Private Sub EliminarProductosCliente()
      If ugProductosCliente.Selected.Rows.Count = 0 And ugProductosCliente.ActiveRow IsNot Nothing Then
         ugProductosCliente.ActiveRow.Selected = True
      End If

      Try
         Dim drProductosClienteCol As List(Of DataRow) = New List(Of DataRow)()
         For Each dgRow As UltraGridRow In ugProductosCliente.Selected.Rows
            If dgRow.ListObject IsNot Nothing AndAlso
               TypeOf (dgRow.ListObject) Is DataRowView AndAlso
               DirectCast(dgRow.ListObject, DataRowView).Row IsNot Nothing Then
               drProductosClienteCol.Add(DirectCast(dgRow.ListObject, DataRowView).Row)
            End If
         Next

         For Each drProductosCliente As DataRow In drProductosClienteCol
            Dim drProducto As DataRow = _dtProductos.NewRow()

            For Each dc As DataColumn In _dtProductos.Columns
               If drProducto.Table.Columns.Contains(dc.ColumnName) Then
                  drProducto(dc.ColumnName) = drProductosCliente(dc.ColumnName)
               End If
            Next

            _dtProductos.Rows.Add(drProducto)
            _dtProductos.AcceptChanges()
            drProductosCliente.Delete()
            _dtProductosCliente.AcceptChanges()

         Next
         ugProductos.DisplayLayout.Bands(0).SortedColumns.RefreshSort(False)
         ugProductos.Rows.Refresh(RefreshRow.ReloadData)
         tsbGrabar.Enabled = True
      Catch
         _dtProductosCliente.RejectChanges()
         _dtProductos.RejectChanges()
         Throw
      End Try
   End Sub
   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.Grabar()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub


#End Region

   Private Sub ugProductos_AfterRowActivate(sender As Object, e As EventArgs) Handles ugProductos.AfterRowActivate
      Try
         Me.Cursor = Cursors.WaitCursor
         If Me.ugProductos.ActiveRow IsNot Nothing Then
            If Me.ugProductos.ActiveRow.Cells("IdProducto").Value.ToString() = String.Empty Then Exit Sub
            'Me.txtInfoProducto.Text = Me.ugProductos.ActiveRow.Cells("NombreProducto").Value.ToString()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ugProductosCliente_AfterRowActivate(sender As Object, e As EventArgs) Handles ugProductosCliente.AfterRowActivate
      Try
         If Me.ugProductosCliente.ActiveRow IsNot Nothing Then
            If Me.ugProductosCliente.ActiveRow.Cells("IdProducto").Value.ToString() = String.Empty Then Exit Sub
            'Me.txtInfoProductosCliente.Text = Me.ugProductosCliente.ActiveRow.Cells("NombreProducto").Value.ToString()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbAlineacionPaneles_CheckedChanged(sender As Object, e As EventArgs) Handles chbAlineacionPaneles.CheckedChanged
      If Me.chbAlineacionPaneles.Checked Then
         Me.spcDatos.Orientation = Orientation.Horizontal
      Else
         Me.spcDatos.Orientation = Orientation.Vertical
      End If
   End Sub


   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugProductos, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugProductos.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugProductos.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarDatos()
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: Debe seleccionar un Cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If


         CargarProductosCliente()
         CargarProductos()

         spcDatos.Enabled = True


         If ugProductos.Rows.Count > 0 Then
            ugProductos.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub CargarProductos()
      If Not Me._cargandoPantalla Then

         If Not Me.ugProductos.DataSource Is Nothing Then
            DirectCast(ugProductos.DataSource, DataTable).Rows.Clear()
         End If

         Dim oProd As Reglas.ProductosClientes = New Reglas.ProductosClientes()

         Dim idMarca As Integer = 0
         Dim idRubro As Integer = 0
         Dim idSubRubro As Integer = 0

         If Me.cmbMarca.SelectedIndex > -1 Then
            idMarca = Int32.Parse(Me.cmbMarca.SelectedValue.ToString())
         End If
         If Me.cmbRubro.SelectedIndex > -1 Then
            idRubro = Int32.Parse(Me.cmbRubro.SelectedValue.ToString())
         End If
         If Me.cmbSubRubro.SelectedIndex > -1 Then
            idSubRubro = Int32.Parse(Me.cmbSubRubro.SelectedValue.ToString())
         End If


         _dtProductos = oProd.GetProductosCliente(0, cmbMarca.GetMarcas(True), cmbRubro.GetRubros(True), cmbSubRubro.GetSubRubros(True))

         For Each drProductosCliente As DataRow In _dtProductosCliente.Rows

            For Each drProdutos As DataRow In _dtProductos.Rows
               If drProductosCliente("IdProducto").ToString() = drProdutos("IdProducto").ToString Then
                  drProdutos.Delete()

               End If
            Next
            _dtProductos.AcceptChanges()
         Next


         Me.ugProductos.DataSource = _dtProductos

         tslContadorGrillaProductos.Text = ugProductos.Rows.Count

         FormateaGrillaProductos()

         LeerPreferencias()
      End If


   End Sub
   Private Sub CargarProductosCliente()

      If Not Me._cargandoPantalla Then
         Dim oProd As Reglas.ProductosClientes = New Reglas.ProductosClientes()

         Dim IdCliente As Long = 0
         Dim idMarca As Integer = 0
         Dim idRubro As Integer = 0
         Dim idSubRubro As Integer = 0

         IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())

         If Me.cmbMarca.SelectedIndex > -1 Then
            idMarca = Int32.Parse(Me.cmbMarca.SelectedValue.ToString())
         End If
         If Me.cmbRubro.SelectedIndex > -1 Then
            idRubro = Int32.Parse(Me.cmbRubro.SelectedValue.ToString())
         End If
         If Me.cmbSubRubro.SelectedIndex > -1 Then
            idSubRubro = Int32.Parse(Me.cmbSubRubro.SelectedValue.ToString())
         End If

         _dtProductosCliente = oProd.GetProductosCliente(IdCliente, cmbMarca.GetMarcas(True), cmbRubro.GetRubros(True), cmbSubRubro.GetSubRubros(True))

         Me.ugProductosCliente.DataSource = _dtProductosCliente

         tslProductosAsignados.Text = ugProductosCliente.Rows.Count

         FormateaGrillaProductosCliente()
      End If
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub cmbMarca_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarca.SelectedIndexChanged
      Try
         CargarProductos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbRubro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro.SelectedIndexChanged
      Try
         CargarProductos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbSubRubro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubro.SelectedIndexChanged
      Try
         CargarProductos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class