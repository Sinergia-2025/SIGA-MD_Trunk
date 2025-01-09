Imports Infragistics.Win.UltraWinGrid

Public Class ListasControlUsuarios

#Region "Campos"

   Private _dtUsuarios As DataTable
   Private _dtListasControlUsuarios As DataTable
   Private _publicos As Publicos
   Private _cargandoPantalla As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._cargandoPantalla = True
         _publicos = New Publicos()

         _publicos.CargaComboListasControl(Me.cmbListasControl)
         If cmbListasControl.Items.Count > 0 Then
            cmbListasControl.SelectedIndex = 0
         End If

         Me._cargandoPantalla = False

         Me.CargarUsuarios(True)

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
         Me.ControlaCambios()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarUsuarios(tablaVacia As Boolean)
      If Not Me._cargandoPantalla Then
         _dtUsuarios = New Reglas.Usuarios()._GetTodos(True)
         bdsUsuarios.DataSource = _dtUsuarios
         ' bdsClientes.Filter = String.Format("CantidadVisitas > CantidadVisitasAsignadas AND DiaActual = False")
         Me.FormateaGrillaUsuarios()
      End If
   End Sub

   Private Sub CargarListasControlUsuario(tablaVacia As Boolean)
      If Me.cmbListasControl.SelectedIndex > -1 Then
         _dtListasControlUsuarios = New Reglas.ListasControlUsuarios().GetUsuariosxListaControl(Integer.Parse(Me.cmbListasControl.SelectedValue.ToString()))

         bdsListasControlUsuarios.Filter = String.Empty
         bdsListasControlUsuarios.DataSource = _dtListasControlUsuarios
         FormateaGrillaListasControlUsuarios()
      End If
   End Sub

   Private Sub ControlaCambios()
      If Me.tsbGrabar.Enabled Then
         If ShowPregunta("¿Desea grabar los cambios?") = Windows.Forms.DialogResult.Yes Then
            Me.Grabar()
         End If
      End If
   End Sub

   Private Sub AgregarUsuarioaLista()
      Me.Cursor = Cursors.WaitCursor
      If Me.ValidaLinea() Then



         If ugUsuarios.Selected.Rows.Count = 0 And ugUsuarios.ActiveRow IsNot Nothing Then
            ugUsuarios.ActiveRow.Selected = True
         End If

         Try
            Dim drUsuarioCol As List(Of DataRow) = New List(Of DataRow)()
            For Each dgUsuario As UltraGridRow In ugUsuarios.Selected.Rows
               If dgUsuario.ListObject IsNot Nothing AndAlso
                  TypeOf (dgUsuario.ListObject) Is DataRowView AndAlso
                  DirectCast(dgUsuario.ListObject, DataRowView).Row IsNot Nothing Then

                  For Each item As DataRow In _dtListasControlUsuarios.Rows
                     If item.Field(Of String)("IdUsuario") = dgUsuario.Cells("Id").Value.ToString() Then
                        Throw New Exception("Ya existe el usuario: " & dgUsuario.Cells("Id").Value.ToString())
                     End If
                  Next

                  drUsuarioCol.Add(DirectCast(dgUsuario.ListObject, DataRowView).Row)
               End If
            Next
            For Each drUsuario As DataRow In drUsuarioCol
               Dim drListaControlUsuario As DataRow = _dtListasControlUsuarios.NewRow()

               For Each dc As DataColumn In _dtUsuarios.Columns
                  If drListaControlUsuario.Table.Columns.Contains(dc.ColumnName) Then
                     drListaControlUsuario(dc.ColumnName) = drUsuario(dc.ColumnName)
                     drListaControlUsuario("IdUsuario") = drUsuario("Id")
                  End If
               Next
               drListaControlUsuario("IdListaControl") = cmbListasControl.SelectedValue

               _dtListasControlUsuarios.Rows.Add(drListaControlUsuario)
               _dtListasControlUsuarios.AcceptChanges()
               _dtUsuarios.AcceptChanges()

            Next

            tsbGrabar.Enabled = True

         Catch
            _dtListasControlUsuarios.RejectChanges()
            _dtUsuarios.RejectChanges()
            Throw
         End Try
      End If
   End Sub

   Private Sub SacarUsuarioLista()
      If ugListasControlUsuarios.Selected.Rows.Count = 0 And ugListasControlUsuarios.ActiveRow IsNot Nothing Then
         ugListasControlUsuarios.ActiveRow.Selected = True
      End If

      Try
         Dim drListaControlUsuario As List(Of DataRow) = New List(Of DataRow)()
         For Each dgRow As UltraGridRow In ugListasControlUsuarios.Selected.Rows
            If dgRow.ListObject IsNot Nothing AndAlso
               TypeOf (dgRow.ListObject) Is DataRowView AndAlso
               DirectCast(dgRow.ListObject, DataRowView).Row IsNot Nothing Then
               drListaControlUsuario.Add(DirectCast(dgRow.ListObject, DataRowView).Row)
            End If
         Next

         For Each drUsuarios As DataRow In drListaControlUsuario
            drUsuarios.Delete()
         Next

         _dtListasControlUsuarios.AcceptChanges()
         _dtUsuarios.AcceptChanges()

         tsbGrabar.Enabled = True
      Catch
         _dtListasControlUsuarios.RejectChanges()
         _dtUsuarios.RejectChanges()
         Throw
      End Try
   End Sub
   Private Function ValidaLinea() As Boolean
      If Me._dtListasControlUsuarios IsNot Nothing Then
         For Each item As DataRow In _dtListasControlUsuarios.Rows
            If item.Field(Of String)("IdUsuario") = ugUsuarios.ActiveRow.Cells("Id").Value.ToString() Then
               Throw New Exception("Ya existe el usuario.")
            End If
         Next
      End If
      Return True
   End Function
   Private Sub Grabar()

      Dim ListaDeControl As Entidades.ListaControl

      ListaDeControl = DirectCast(Me.cmbListasControl.SelectedItem, Entidades.ListaControl)

      Dim rListasControlUsuarios As Reglas.ListasControlUsuarios = New Reglas.ListasControlUsuarios()

      rListasControlUsuarios.Guardar(ListaDeControl, Me._dtListasControlUsuarios)

      Me.Cursor = Cursors.Default
      MessageBox.Show("Usuario/s grabado/s exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      RefrescarGrilla()
   End Sub

   Private Sub RefrescarGrilla()

      Me.CargarUsuarios(True)
      _dtListasControlUsuarios.Clear()
      '   Me.CargarListasControlUsuario(True)
      Me.tsbGrabar.Enabled = False
      spcDatos.Enabled = False
      Me.cmbListasControl.Enabled = True
      Me.cmbListasControl.SelectedIndex = 0
      cmbListasControl.Focus()

   End Sub

   Private Sub FormateaGrillaUsuarios()
      FormateaGrilla(Me.ugUsuarios)
   End Sub

   Private Sub FormateaGrillaListasControlUsuarios()
      FormateaGrillaListasControlUsuarios(Me.ugListasControlUsuarios)
   End Sub

   Private Sub FormateaGrilla(grilla As UltraGrid)
      Dim col As Integer = 0
      Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"Nombre"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Id"), "Código", col, 70)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Nombre"), "Nombre", col, 150)

      End With
   End Sub

   Private Sub FormateaGrillaListasControlUsuarios(grilla As UltraGrid)
      Dim col As Integer = 0
      Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"Nombre"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdUsuario"), "Código", col, 70)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Nombre"), "Nombre", col, 150)

      End With
   End Sub

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugUsuarios.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugUsuarios.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub dgvClientes_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugUsuarios.MouseDoubleClick
      Me.btnAgregar_Click(sender, e)
   End Sub

   Private Sub dgvRutas_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugListasControlUsuarios.MouseDoubleClick
      Me.btnSacar_Click(sender, e)
   End Sub

   Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
      Try
         AgregarUsuarioaLista()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub dgvRutas_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ugListasControlUsuarios.DragEnter
      e.Effect = DragDropEffects.Copy
   End Sub

   Private Sub btnSacar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSacar.Click
      Try
         Me.SacarUsuarioLista()
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

         If Me.cmbListasControl.SelectedIndex < 0 Then
            ShowMessage("ATENCION: Debe seleccionar una Ruta.")
            Me.cmbListasControl.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.cmbListasControl.Enabled = False

         CargarUsuarios(False)
         CargarListasControlUsuario(False)

         spcDatos.Enabled = True

         Me.tssUsuariosListaControl.Text = ugListasControlUsuarios.Rows.Count.ToString() & " Registros"
         Me.tssUsuariosAsignar.Text = ugUsuarios.Rows.Count.ToString() & " Registros"

         If _dtUsuarios.Rows.Count > 0 Then
            ugUsuarios.Focus()
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
         Dim pre As Preferencias = New Preferencias(Me.ugUsuarios, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugUsuarios_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugUsuarios.AfterRowFilterChanged
      Me.tssUsuariosListaControl.Text = Me.ugUsuarios.Rows.FilteredInRowCount.ToString() & " Registros"
   End Sub

   Private Sub ugListasControlUsuarios_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugListasControlUsuarios.AfterRowFilterChanged
      Me.tssUsuariosAsignar.Text = Me.ugListasControlUsuarios.Rows.FilteredInRowCount.ToString() & " Registros"
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         RefrescarGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

End Class