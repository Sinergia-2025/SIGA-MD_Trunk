Imports Infragistics.Win.UltraWinGrid

Public Class ExcepcionesProductos

#Region "Campos"

   Private _dtProductos As DataTable
   Private _dtProductosExcepciones As Entidades.ListConBorrados(Of Entidades.ProductoExcepcion)
   Private _publicos As Publicos
   Private _cargandoPantalla As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._cargandoPantalla = True
         _publicos = New Publicos()
         _publicos.CargaComboTiposListasControl(cmbTipoListaControl)
         _publicos.CargaComboTiposExcepciones(cmbTiposExcepciones)

         Me._cargandoPantalla = False

         '  Me.CargarListasControl(True)
         '  RefrescarGrilla()

         spcDatos.Enabled = True

         LeerPreferencias()

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
         '  Me.ControlaCambios()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProductos(tablaVacia As Boolean)
      If Not Me._cargandoPantalla Then
         If rbtTodosLosProductos.Checked Then
            _dtProductos = New Reglas.Productos().GetProductosCalidadSinReparaciones()
         Else
            _dtProductos = New Reglas.ListasControlProductos().GetProductosPanelControl(IdProductoModeloTipo:=0)
         End If

         bdsProductos.DataSource = _dtProductos
         Me.FormateaGrillaProductos()
      End If
   End Sub

   Private Sub CargarProductosListasControl(tablaVacia As Boolean)
      If Me.bscExcepcion2.Selecciono Then

         Dim lista As List(Of Entidades.ProductoExcepcion) = New Reglas.ProductosExcepciones().GetTodas(Integer.Parse(Me.bscExcepcion2.Tag.ToString().Trim()))

         _dtProductosExcepciones = New Entidades.ListConBorrados(Of Entidades.ProductoExcepcion)(lista)

         bdsProductosExcepciones.Filter = String.Empty
         bdsProductosExcepciones.DataSource = _dtProductosExcepciones
         FormateaGrillaProductosExcepxiones()
      End If
   End Sub

   Private Sub ControlaCambios()
      If Me.tsbGrabar.Enabled Then
         If ShowPregunta("¿Desea grabar los cambios?") = Windows.Forms.DialogResult.Yes Then
            Me.Grabar()
         End If
      End If
   End Sub

   Private Sub AgregarProductoaExcepcion()
      Me.Cursor = Cursors.WaitCursor

      If ugProductos.Selected.Rows.Count = 0 And ugProductos.ActiveRow IsNot Nothing Then
         ugProductos.ActiveRow.Selected = True
      End If

      Try

         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         '  If oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ExcepProductos_ElimAgregProd") Then

         Dim drListaCol As List(Of DataRow) = New List(Of DataRow)()
            For Each dgLista As UltraGridRow In ugProductos.Selected.Rows
               If dgLista.ListObject IsNot Nothing AndAlso
                  TypeOf (dgLista.ListObject) Is DataRowView AndAlso
                  DirectCast(dgLista.ListObject, DataRowView).Row IsNot Nothing Then

                  For Each item As Entidades.ProductoExcepcion In _dtProductosExcepciones
                     If item.IdProducto = dgLista.Cells("IdProducto").Value.ToString() Then
                        Throw New Exception("Ya existe el Producto: " & dgLista.Cells("IdProducto").Value.ToString())
                     End If
                  Next

                  drListaCol.Add(DirectCast(dgLista.ListObject, DataRowView).Row)


               End If
            Next

            Dim Lista As Entidades.ProductoExcepcion

            For Each drLista As DataRow In drListaCol

               Lista = New Entidades.ProductoExcepcion()

               Lista.NombreProducto = drLista.Field(Of String)("NombreProducto")
               Lista.IdProducto = drLista.Field(Of String)("IdProducto")
               Lista.IdUsuario = actual.Nombre
               Lista.fecha = Date.Now()
               Lista.IdExcepcion = Integer.Parse(Me.bscExcepcion2.Tag.ToString())

               _dtProductosExcepciones.Add(Lista)
               ugProductoExcepciones.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
               ugProductoExcepciones.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)

               _dtProductos.AcceptChanges()

            Next

            tsbGrabar.Enabled = True
         'Else
         '   If Not oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ExcepProductos_ElimAgregProd") Then
         '      MessageBox.Show("No puede agregar el Producto. Necesita autorización. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         '      Exit Sub
         '   End If
         'End If

      Catch
         ' _dtProductosListasControl.RejectChanges()
         _dtProductos.RejectChanges()
         Throw
      End Try

   End Sub

   Private Sub SacarListaDeProducto()
      If ugProductoExcepciones.Selected.Rows.Count = 0 And ugProductoExcepciones.ActiveRow IsNot Nothing Then
         ugProductoExcepciones.ActiveRow.Selected = True
      End If

      Try
         Dim drProductoExcepcion As List(Of Entidades.ProductoExcepcion) = New List(Of Entidades.ProductoExcepcion)()
         For Each dgRow As UltraGridRow In ugProductoExcepciones.Selected.Rows
            If dgRow.ListObject IsNot Nothing AndAlso
               TypeOf (dgRow.ListObject) Is Entidades.ProductoExcepcion AndAlso
               DirectCast(dgRow.ListObject, Entidades.ProductoExcepcion) IsNot Nothing Then

               Dim Lista As Entidades.ProductoExcepcion = GetCurrentLista()

               drProductoExcepcion.Add(Lista)

            End If
         Next
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()

         If oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ExcepProductos_ElimAgregProd") Then

            For Each drLista As Entidades.ProductoExcepcion In drProductoExcepcion

               _dtProductosExcepciones.Remove(drLista)
               ugProductoExcepciones.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)

               _dtProductos.AcceptChanges()

               tsbGrabar.Enabled = True

            Next
         Else
            ' If Not oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ExcepProductos_ElimAgregProd") Then
            MessageBox.Show("No puede eliminar el Producto. Necesita autorización. ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
               Exit Sub
            '  End If
         End If

      Catch
         '   _dtProductosListasControl.RejectChanges()
         _dtProductos.RejectChanges()
         Throw
      End Try
   End Sub

   Private Sub Grabar()

      'Me._dtProductosExcepciones.AcceptChanges()

      Dim rProductosExcepciones As Reglas.ProductosExcepciones = New Reglas.ProductosExcepciones()

      rProductosExcepciones.Guardar(Me._dtProductosExcepciones)

      Me.Cursor = Cursors.Default
      MessageBox.Show("Lista/s de Control grabada/s exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      RefrescarGrilla()
   End Sub

   Private Sub RefrescarGrilla()
      Me.bdsProductosExcepciones.DataSource = Nothing
      Me.bdsProductos.DataSource = Nothing
      Me.tsbGrabar.Enabled = False
      spcDatos.Enabled = False
      Me.bscExcepcion2.Enabled = True
      Me.bscExcepcion2.Enabled = True
      Me.bscExcepcion2.Text = ""
      Me.bscExcepcion2.Text = ""
      Me.cmbTiposExcepciones.SelectedIndex = -1
      Me.cmbTipoListaControl.SelectedIndex = -1
      Me.txtItem.Text = ""

   End Sub

   Private Sub FormateaGrillaProductos()
      FormateaGrillaProductos(Me.ugProductos)
   End Sub

   Private Sub FormateaGrillaProductosExcepxiones()
      FormateaGrillaProductosExcepxiones(Me.ugProductoExcepciones)
   End Sub

   Private Sub FormateaGrillaProductos(grilla As UltraGrid)
      Dim col As Integer = 0
      Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"NombreListaControl"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         ' Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdListaControl"), "Código", col, 70)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdProducto"), "Código", col, 70)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreProducto"), "Modelo", col, 250)

      End With
   End Sub

   Private Sub FormateaGrillaProductosExcepxiones(grilla As UltraGrid)
      Dim col As Integer = 0
      Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"NombreProducto"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next
         '.Columns("Aplica").Style = ColumnStyle.CheckBox

         '     Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Aplica"), "Aplica", col, 60, , , , , Activation.AllowEdit)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdProducto"), "Código", col, 70)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreProducto"), "Nombre", col, 250)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdUsuario"), "Usuario", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Fecha"), "Fecha Alta", col, 80)
         'Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("FecIngreso"), "Fecha Ingreso", col, 80)



      End With
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

   Private Sub CargarDatosExcepcion(ByVal dr As DataGridViewRow, buscador As Eniac.Controles.Buscador2)
      buscador.Text = dr.Cells("IdExcepcion").Value.ToString()
      buscador.Tag = dr.Cells("IdExcepcion").Value.ToString.Trim()
      Me.cmbTipoListaControl.SelectedValue = Integer.Parse(dr.Cells("IdListaControlTipo").Value.ToString())
      Me.cmbTiposExcepciones.SelectedValue = Integer.Parse(dr.Cells("IdExcepcionTipo").Value.ToString())
      Me.txtItem.Text = dr.Cells("Item").Value.ToString()
      Me.tsbGrabar.Enabled = True

      Me.CargaGrillas()

   End Sub

   Private Function ValidaLinea() As Boolean
      If Me._dtProductosExcepciones IsNot Nothing Then
         'For Each item As DataRow In _dtProductosListasControl.Rows
         '   If item("IdListaControl") = Integer.Parse(ugListasControl.ActiveRow.Cells("IdListaControl").Value.ToString()) Then
         '      Throw New Exception("Ya existe la lista de control.")
         '   End If
         'Next
      End If
      Return True
   End Function

   Private Function GetCurrentLista() As Entidades.ProductoExcepcion
      If ugProductoExcepciones.ActiveRow IsNot Nothing AndAlso
         ugProductoExcepciones.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugProductoExcepciones.ActiveRow.ListObject) Is Entidades.ProductoExcepcion Then
         Return DirectCast(ugProductoExcepciones.ActiveRow.ListObject, Entidades.ProductoExcepcion)
      End If
      Return Nothing
   End Function

   Private Sub CargaGrillas()
      Try

         Me.Cursor = Cursors.WaitCursor

         Me.bscExcepcion2.Enabled = False

         CargarProductos(False)

         CargarProductosListasControl(False)

         spcDatos.Enabled = True

         Me.tssProductosListaControl.Text = ugProductoExcepciones.Rows.Count.ToString() & " Registros"
         Me.tssListasControlAsignar.Text = ugProductos.Rows.Count.ToString() & " Registros"

         If _dtProductos.Rows.Count > 0 Then
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


#End Region

#Region "Eventos"

   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub dgvClientes_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugProductos.MouseDoubleClick
      Me.btnAgregar_Click(sender, e)
   End Sub

   Private Sub dgvRutas_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugProductoExcepciones.MouseDoubleClick
      Me.btnSacar_Click(sender, e)
   End Sub

   Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
      Try
         AgregarProductoaExcepcion()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub dgvRutas_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ugProductoExcepciones.DragEnter
      e.Effect = DragDropEffects.Copy
   End Sub

   Private Sub btnSacar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSacar.Click
      Try
         Me.SacarListaDeProducto()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
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

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try

         '' '' '' ''Dim sFecha As String
         '' '' '' ''Dim sVendedor As String
         '' '' '' ''Dim ru As Reglas.RutasClientes = New Reglas.RutasClientes()
         '' '' '' ''Dim idRuta As Integer = DirectCast(Me.cmbRutas.SelectedItem, Entidades.Ruta).IdRuta
         '' '' '' ''Dim dt As DataTable

         '' '' '' ''Me.Cursor = Cursors.WaitCursor

         '' '' '' ''sFecha = "Fecha : " & DateTime.Now().ToString("dd/MM/yyyy hh:mm tt")
         '' '' '' ''sVendedor = DirectCast(Me.cmbRutas.SelectedItem, Entidades.Ruta).Vendedor.NombreEmpleado
         '' '' '' ''Me._ruta = ru.GetPorVendedor(idRuta)
         '' '' '' ''dt = DirectCast(Me._ruta, DataTable)

         '' '' '' ''Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         '' '' '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresa))
         '' '' '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
         '' '' '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Vendedor", sVendedor))

         ' '' '' '' ''GAR: 02/10/2017 - Esta Parametro se quito del reporte porque esta la fecha de impresion. Tal vez alguna vez tenia la fecha de actualizado.
         '' '' '' ''parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", sFecha))

         '' '' '' ''Dim frmImprime As VisorReportes = New VisorReportes("Eniac.SiLIVE.Win.ListadoRutaClientes.rdlc", "DataSet_log", dt, parm, True)
         '' '' '' ''frmImprime.Text = Me.Text
         '' '' '' ''frmImprime.WindowState = FormWindowState.Maximized
         '' '' '' ''frmImprime.ShowDialog()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chbAlineacionPaneles_CheckedChanged(sender As Object, e As EventArgs) Handles chbAlineacionPaneles.CheckedChanged
      If Me.chbAlineacionPaneles.Checked Then
         Me.spcDatos.Orientation = Orientation.Horizontal
      Else
         Me.spcDatos.Orientation = Orientation.Vertical
      End If
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try

         If Not Me.bscExcepcion2.Selecciono Then
            ShowMessage("ATENCION: Debe seleccionar un Producto")
            Me.bscExcepcion2.Focus()
            Exit Sub
         End If


         Me.Cursor = Cursors.WaitCursor

         Me.bscExcepcion2.Enabled = False

         CargarProductos(False)
         CargarProductosListasControl(False)

         spcDatos.Enabled = True

         Me.tssProductosListaControl.Text = ugProductoExcepciones.Rows.Count.ToString() & " Registros"
         Me.tssListasControlAsignar.Text = ugProductos.Rows.Count.ToString() & " Registros"

         If _dtProductos.Rows.Count > 0 Then
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

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugProductos, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscExcepcion2_BuscadorClick() Handles bscExcepcion2.BuscadorClick
      Try
         Dim oExecepciones As Reglas.Excepciones = New Reglas.Excepciones
         Me._publicos.PreparaGrillaExcepciones(Me.bscExcepcion2)
         Dim Seccion As Integer = 0
         Dim TipoExcepcion As Integer = 0
         If Me.cmbTipoListaControl.SelectedIndex <> -1 Then
            Seccion = Integer.Parse(Me.cmbTipoListaControl.SelectedValue.ToString())
         End If
         If Me.cmbTiposExcepciones.SelectedIndex <> -1 Then
            TipoExcepcion = Integer.Parse(Me.cmbTiposExcepciones.SelectedValue.ToString())
         End If
         Me.bscExcepcion2.Datos = oExecepciones.GetExcepciones(Seccion, TipoExcepcion)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscExcepcion2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscExcepcion2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosExcepcion(e.FilaDevuelta, Me.bscExcepcion2)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugUsuarios_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugProductos.AfterRowFilterChanged
      Me.tssProductosListaControl.Text = Me.ugProductos.Rows.FilteredInRowCount.ToString() & " Registros"
   End Sub

   Private Sub ugListasControlUsuarios_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugProductoExcepciones.AfterRowFilterChanged
      Me.tssListasControlAsignar.Text = Me.ugProductoExcepciones.Rows.FilteredInRowCount.ToString() & " Registros"
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         RefrescarGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ProductosListasControl_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
      Select Case e.KeyCode
         Case Keys.F5
            Me.tsbRefrescar.PerformClick()
         Case Keys.F4
            Me.tsbGrabar.PerformClick()
         Case Else
      End Select
   End Sub


#End Region


End Class