Imports Infragistics.Win.UltraWinGrid

Public Class ItemsListasControlRoles

#Region "Campos"

   Private _dtRoles As DataTable
   Private _dtListasControlRoles As DataTable
   Private _publicos As Publicos
   Private _cargandoPantalla As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._cargandoPantalla = True

         _publicos = New Publicos()

         Me.CargarRoles(True)
         _publicos.CargaComboListasControl(Me.cmbListasControl)
         'If cmbListasControl.Items.Count > 0 Then
         '   cmbListasControl.SelectedIndex = 0
         'End If


         spcDatos.Enabled = True

         LeerPreferencias()

         spcDatos.Enabled = False

         tsbPreferencias.Enabled = True
         tsbGrabar.Enabled = False

         Me._cargandoPantalla = False

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

   Private Sub CargarRoles(tablaVacia As Boolean)
      If Not Me._cargandoPantalla Then
         _dtRoles = New Reglas.Roles().GetAll()
         bdsRoles.DataSource = _dtRoles
         Me.FormateaGrillaRoles()
      End If
   End Sub

   Private Sub CargarListasControlRoles(tablaVacia As Boolean)
      If Me.cmbListasControl.SelectedIndex > -1 Then
         _dtListasControlRoles = New Reglas.ListasControlRoles().GetRolesxListaControl(Integer.Parse(Me.cmbListasControl.SelectedValue.ToString()))

         bdsListasControlRoles.Filter = String.Empty
         bdsListasControlRoles.DataSource = _dtListasControlRoles
         FormateaGrillaListasControlRoles()
      End If
   End Sub

   Private Sub ControlaCambios()
      If Me.tsbGrabar.Enabled Then
         If ShowPregunta("¿Desea grabar los cambios?") = Windows.Forms.DialogResult.Yes Then
            Me.Grabar()
         End If
      End If
   End Sub

   Private Sub AgregarRolaLista()
      Me.Cursor = Cursors.WaitCursor
      If Me.ValidaLinea() Then



         If ugRoles.Selected.Rows.Count = 0 And ugRoles.ActiveRow IsNot Nothing Then
            ugRoles.ActiveRow.Selected = True
         End If

         Try
            Dim drRolCol As List(Of DataRow) = New List(Of DataRow)()
            For Each dgRol As UltraGridRow In ugRoles.Selected.Rows
               If dgRol.ListObject IsNot Nothing AndAlso
                  TypeOf (dgRol.ListObject) Is DataRowView AndAlso
                  DirectCast(dgRol.ListObject, DataRowView).Row IsNot Nothing Then

                  For Each item As DataRow In Me._dtListasControlRoles.Rows
                     If item.Field(Of String)("IdRol") = dgRol.Cells("Id").Value.ToString() Then
                        Throw New Exception("Ya existe el rol: " & dgRol.Cells("Id").Value.ToString())
                     End If
                  Next

                  drRolCol.Add(DirectCast(dgRol.ListObject, DataRowView).Row)
               End If
            Next
            For Each drRol As DataRow In drRolCol
               Dim drListaControlRol As DataRow = Me._dtListasControlRoles.NewRow()

               For Each dc As DataColumn In _dtRoles.Columns
                  If drListaControlRol.Table.Columns.Contains(dc.ColumnName) Then
                     drListaControlRol(dc.ColumnName) = drRol(dc.ColumnName)
                     drListaControlRol("IdRol") = drRol("Id")
                  End If
               Next
               drListaControlRol("IdListaControl") = cmbListasControl.SelectedValue

               Me._dtListasControlRoles.Rows.Add(drListaControlRol)
               Me._dtListasControlRoles.AcceptChanges()
               _dtRoles.AcceptChanges()

            Next

            tsbGrabar.Enabled = True

         Catch
            Me._dtListasControlRoles.RejectChanges()
            _dtRoles.RejectChanges()
            Throw
         End Try
      End If
   End Sub

   Private Sub SacarRolLista()
      If ugListasControlRoles.Selected.Rows.Count = 0 And ugListasControlRoles.ActiveRow IsNot Nothing Then
         ugListasControlRoles.ActiveRow.Selected = True
      End If

      Try
         Dim drListaControlRol As List(Of DataRow) = New List(Of DataRow)()
         For Each dgRow As UltraGridRow In ugListasControlRoles.Selected.Rows
            If dgRow.ListObject IsNot Nothing AndAlso
               TypeOf (dgRow.ListObject) Is DataRowView AndAlso
               DirectCast(dgRow.ListObject, DataRowView).Row IsNot Nothing Then
               drListaControlRol.Add(DirectCast(dgRow.ListObject, DataRowView).Row)
            End If
         Next

         For Each drRoles As DataRow In drListaControlRol
            drRoles.Delete()
         Next

         Me._dtListasControlRoles.AcceptChanges()
         _dtRoles.AcceptChanges()

         tsbGrabar.Enabled = True
      Catch
         Me._dtListasControlRoles.RejectChanges()
         _dtRoles.RejectChanges()
         Throw
      End Try
   End Sub
   Private Function ValidaLinea() As Boolean
      If Me._dtListasControlRoles IsNot Nothing Then
         For Each item As DataRow In Me._dtListasControlRoles.Rows
            If item.Field(Of String)("IdRol") = ugRoles.ActiveRow.Cells("Id").Value.ToString() Then
               Throw New Exception("Ya existe el rol.")
            End If
         Next
      End If
      Return True
   End Function
   Private Sub Grabar()

      Dim ListaDeControl As Entidades.ListaControl

      ListaDeControl = New Reglas.ListasControl().GetUno(Integer.Parse(Me.cmbListasControl.SelectedValue.ToString()))

      Dim rListasControlRoles As Reglas.ListasControlRoles = New Reglas.ListasControlRoles()

      rListasControlRoles.Guardar(ListaDeControl, Me._dtListasControlRoles)

      Me.Cursor = Cursors.Default
      MessageBox.Show("Rol/es grabado/s exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      RefrescarGrilla()
   End Sub

   Private Sub RefrescarGrilla()
      Me._dtRoles.Clear()
      Me._dtListasControlRoles.Clear()
      Me.tsbGrabar.Enabled = False
      Me.cmbListasControl.SelectedIndex = -1
      cmbListasControl.Focus()
      spcDatos.Enabled = False
      Me.cmbListasControl.Enabled = True
   End Sub

   Private Sub FormateaGrillaRoles()
      FormateaGrilla(Me.ugRoles)
   End Sub

   Private Sub FormateaGrillaListasControlRoles()
      FormateaGrillaListasControlRoles(Me.ugListasControlRoles)
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

   Private Sub FormateaGrillaListasControlRoles(grilla As UltraGrid)
      Dim col As Integer = 0
      Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"Nombre"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdRol"), "Código", col, 70)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Nombre"), "Nombre", col, 150)

      End With
   End Sub

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugRoles.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugRoles.DisplayLayout.LoadFromXml(nameGrid)
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

   Private Sub dgvClientes_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugRoles.MouseDoubleClick
      Me.btnAgregar_Click(sender, e)
   End Sub

   Private Sub dgvRutas_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ugListasControlRoles.MouseDoubleClick
      Me.btnSacar_Click(sender, e)
   End Sub

   Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
      Try
         AgregarRolaLista()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub dgvRutas_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ugListasControlRoles.DragEnter
      e.Effect = DragDropEffects.Copy
   End Sub

   Private Sub btnSacar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSacar.Click
      Try
         Me.SacarRolLista()
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

   Private Sub chbAlineacionPaneles_CheckedChanged(sender As Object, e As EventArgs) Handles chbAlineacionPaneles.CheckedChanged
      If Me.chbAlineacionPaneles.Checked Then
         Me.spcDatos.Orientation = Orientation.Horizontal
      Else
         Me.spcDatos.Orientation = Orientation.Vertical
      End If
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try

         Me.Cursor = Cursors.WaitCursor
         '   If Not _cargandoPantalla Then


         CargarRoles(False)
         CargarListasControlRoles(False)

         spcDatos.Enabled = True

         Me.tssRolesListaControl.Text = ugListasControlRoles.Rows.Count.ToString() & " Registros"
         Me.tssRolesAsignar.Text = ugRoles.Rows.Count.ToString() & " Registros"

         If _dtRoles.Rows.Count > 0 Then
            ugRoles.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         '       End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugRoles, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugRoles_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugRoles.AfterRowFilterChanged
      Me.tssRolesListaControl.Text = Me.ugRoles.Rows.FilteredInRowCount.ToString() & " Registros"
   End Sub

   Private Sub ugListasControlRoles_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugListasControlRoles.AfterRowFilterChanged
      Me.tssRolesAsignar.Text = Me.ugListasControlRoles.Rows.FilteredInRowCount.ToString() & " Registros"
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         RefrescarGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbListasControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListasControl.SelectedIndexChanged
      Try

         Me.Cursor = Cursors.WaitCursor

         If Not _cargandoPantalla Then

            CargarRoles(False)
            CargarListasControlRoles(False)

            spcDatos.Enabled = True

            Me.cmbListasControl.Enabled = False

            Me.tssRolesListaControl.Text = ugListasControlRoles.Rows.Count.ToString() & " Registros"
            Me.tssRolesAsignar.Text = ugRoles.Rows.Count.ToString() & " Registros"

            If _dtRoles.Rows.Count > 0 Then
               ugRoles.Focus()
            Else
               Me.Cursor = Cursors.Default
               MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
         End If
         '  Me.cmbListasControl.Enabled = False

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ListasControlRoles_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
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