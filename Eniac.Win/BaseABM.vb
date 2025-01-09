Option Strict Off
'Imports Eniac.Controles

Public Class BaseABM

#Region "Campos"

   Protected dtDatos As DataTable
   Protected _entidad As Entidades.Entidad
   Private _ultimaColumnaSeleccionada As Integer = 0
   'Protected _ultimaFilaSeleccionada(0) As DataGridViewCell

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)
      If Not DesignMode Then
         If GetService(GetType(ComponentModel.Design.IDesignerHost)) Is Nothing Then
            dgvDatos.DataSource = dtDatos
            RefreshGrid()
         End If
      End If
   End Sub

#End Region

#Region "Overridable"

   Protected Overridable Function GetDetalle(estado As StateForm) As BaseDetalle
      Return New BaseDetalle()
   End Function

   Protected Overridable Function GetReglas() As Reglas.Base
      Return New Reglas.Base()
   End Function

   Protected Overridable Sub RefreshGrid()
      Try
         Dim rg As Reglas.Base = Me.GetReglas()
         If Not Me.tstBuscar.Tag Is Nothing And Me.tstBuscar.Text <> "" Then
            Dim bus As Entidades.Buscar = New Entidades.Buscar()
            bus.Columna = Me.tstBuscar.Tag.ToString()
            bus.Valor = Me.tstBuscar.Text.Trim()
            Me.dtDatos = Buscar(rg, bus)
         Else
            'TODO Cambiar para ver el disenador
            Me.dtDatos = GetAll(rg)
         End If
         'If Me.dgvDatos.SelectedCells.Count > 0 Then
         '   ReDim Me._ultimaFilaSeleccionada(Me.dgvDatos.Columns.Count)
         '   Me.dgvDatos.Rows(Me.dgvDatos.SelectedCells(0).RowIndex).Cells.CopyTo(Me._ultimaFilaSeleccionada, 0)
         'End If
         Me.dgvDatos.DataSource = Me.dtDatos
         If Not Me.dtDatos Is Nothing Then
            Me.FormatearGrilla()
         End If
         If Me.dgvDatos.Rows.Count > 1 Then
            Me.tssRegistros.Text = Me.dgvDatos.Rows.Count & " Registros"
         Else
            Me.tssRegistros.Text = Me.dgvDatos.Rows.Count & " Registro"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overridable Function GetAll(rg As Reglas.Base) As Object
      If rg IsNot Nothing Then Return rg.GetAll()
      Return Nothing
   End Function

   Protected Overridable Function Buscar(rg As Reglas.Base, args As Entidades.Buscar) As Object
      If rg IsNot Nothing Then Return rg.Buscar(args)
      Return Nothing
   End Function

   Protected Overridable Sub Borrar()
      Try
         If Me.dgvDatos.SelectedCells.Count > 0 Then
            If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Dim cl As Reglas.Base = Me.GetReglas()
               Me._entidad = Me.GetEntidad()
               cl.Borrar(Me._entidad)
               Me.RefreshGrid()
            End If
         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            MessageBox.Show("No se puede eliminar porque esta siendo utilizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Try
   End Sub

   Protected Overridable Function GetEntidad() As Entidades.Entidad
      Return New Entidades.Entidad
   End Function

   Protected Overridable Sub Editar()
      Try
         If Me.dgvDatos.RowCount = 0 Then Exit Sub
         Dim frm As BaseDetalle = Me.GetDetalle(StateForm.Actualizar)
         frm.StateForm = StateForm.Actualizar
         If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.RefreshGrid()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overridable Sub Nuevo()
      Dim detalle As BaseDetalle = Me.GetDetalle(StateForm.Insertar)
      detalle.StateForm = StateForm.Insertar
      detalle.ShowDialog()
      Me.RefreshGrid()
   End Sub

   Protected Overridable Sub Buscar()
      Try
         If Me.dgvDatos.SelectedCells.Count > 0 Then
            Me.tstBuscar.Tag = Me.dgvDatos.SelectedCells(0).OwningColumn.Name
            Me._ultimaColumnaSeleccionada = Me.dgvDatos.SelectedCells(0).OwningColumn.Index
         End If
         Me.RefreshGrid()
         If Me.dgvDatos.Rows.Count > 0 Then
            Me.dgvDatos.CurrentCell = Me.dgvDatos.Rows(0).Cells(Me._ultimaColumnaSeleccionada)
         End If
         Me.dgvDatos.Refresh()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overridable Sub Imprimir()
   End Sub

   Protected Overridable Sub FormatearGrilla()

   End Sub

#End Region

#Region "Propiedades"

   Public ReadOnly Property BotonImprimir() As ToolStripButton
      Get
         Return Me.tsbImprimir
      End Get
   End Property

   Public ReadOnly Property BotonEditar() As ToolStripButton
      Get
         Return Me.tsbEditar
      End Get
   End Property

#End Region

#Region "Eventos"

   Private Sub tstBuscar_GotFocus(sender As Object, e As System.EventArgs) Handles tstBuscar.GotFocus
      Me.tstBuscar.SelectAll()
   End Sub

   Private Sub tstBuscar_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tstBuscar.KeyUp
      If e.KeyCode = Keys.Enter Then
         Me.tsbBuscar_Click(sender, New EventArgs())
      End If
   End Sub

   Private Sub tsbNuevo_Click(sender As System.Object, e As System.EventArgs) Handles tsbNuevo.Click
      Try
         Me.Nuevo()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbBorrar_Click(sender As System.Object, e As System.EventArgs) Handles tsbBorrar.Click
      Me.Borrar()
   End Sub

   Private Sub tsbEditar_Click(sender As System.Object, e As System.EventArgs) Handles tsbEditar.Click
      Me.Cursor = Cursors.WaitCursor
      Me.Editar()
      Me.Cursor = Cursors.Default
   End Sub

   Private Sub tsbImprimir_Click(sender As System.Object, e As System.EventArgs) Handles tsbImprimir.Click
      Me.Cursor = Cursors.WaitCursor
      Me.Imprimir()
      Me.Cursor = Cursors.Default
   End Sub

   Private Sub tsbBuscar_Click(sender As System.Object, e As System.EventArgs) Handles tsbBuscar.Click
      Me.Cursor = Cursors.WaitCursor
      Me.Buscar()
      Me.Cursor = Cursors.Default
   End Sub

   Private Sub tsbRefresh_Click(sender As System.Object, e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.tstBuscar.Text = String.Empty
         Me.tstBuscar.Tag = Nothing
         Me.RefreshGrid()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub dgvDatos_DoubleClick(sender As Object, e As System.EventArgs)
      If Me.dgvDatos.SelectedCells.Count > 0 Then
         Me.Cursor = Cursors.WaitCursor
         Me.Editar()
         Me.Cursor = Cursors.Default
      End If
   End Sub

   Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub dgvDatos_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellDoubleClick
      Me.Editar()
   End Sub

   Private Sub BaseABM_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefresh_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

#End Region

End Class