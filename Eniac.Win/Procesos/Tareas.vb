Public Class Tareas

#Region "Campos"

   Private dtTareas As DataTable

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.Cursor = Cursors.WaitCursor

      'Dim oTar As Entidades.Tarea
      'Dim oTarea As Reglas.Tareas = New Reglas.Tareas
      'Me.dtTareas = oTarea.GetxFechaUsuario(DateTime.Today, actual.Nombre).Tables(0)
      'Me.clbTareas.Items.Clear()
      'For Each dr As DataRow In Me.dtTareas.Rows
      '   oTar = New Entidades.Tarea
      '   oTar.Id = Convert.ToInt32(dr("Id"))
      '   oTar.Fecha = Convert.ToDateTime(dr("Fecha"))
      '   oTar.Tarea = dr("Tarea").ToString()
      '   oTar.Usuario = dr("Usuario").ToString()
      '   Me.clbTareas.Items.Add(oTar)
      'Next

      Me.RefrescarTareas()

      Me.Cursor = Cursors.Default
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim oTareaArgs As Entidades.Tarea = New Entidades.Tarea()
         oTareaArgs.Fecha = Me.mclFecha.SelectionRange.Start.Date
         oTareaArgs.Tarea = Me.txtTareas.Text.Trim()
         oTareaArgs.Usuario = actual.Nombre

         Dim oTarea As Reglas.Tareas = New Reglas.Tareas()
         oTarea.Insertar(oTareaArgs)

         Me.RefrescarTareas()
         MessageBox.Show("Se agrego la tarea" & Convert.ToChar(Keys.Enter) & Me.txtTareas.Text.Trim(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtTareas.Text = ""
         Me.txtTareas.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not Me.clbTareas.SelectedItem Is Nothing Then
            Dim strTarea As String = Me.clbTareas.SelectedItem.ToString()
            Dim oTarea As Reglas.Tareas = New Reglas.Tareas()
            oTarea.Borrar(DirectCast(Me.clbTareas.SelectedItem, Entidades.Tarea))
            Me.RefrescarTareas()
            MessageBox.Show("Se elimino la tarea" & Convert.ToChar(Keys.Enter) & strTarea, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click
      Try

         If Me.dtTareas.Rows.Count = 0 Then
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor
         'Dim frmImprime As VisorReportes = New VisorReportes(My.Application.Info.AssemblyName & ".Tareas.rdlc", "SistemaDataSet_Tareas", Me.dtTareas)
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Tareas.rdlc", "SistemaDataSet_Tareas", Me.dtTareas, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.Text
         frmImprime.Show()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Hide()
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.RefrescarTareas()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub mclFecha_DateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mclFecha.DateChanged
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.RefrescarTareas()
         btnEliminar.Enabled = (clbTareas.SelectedItems.Count > 0)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub clbTareas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbTareas.SelectedIndexChanged
      Try
         Me.btnEliminar.Enabled = (clbTareas.SelectedItems.Count > 0)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarTareas()
      Dim oTar As Entidades.Tarea
      Dim oTarea As Reglas.Tareas = New Reglas.Tareas

      If Reglas.Publicos.TareasPorUsuario Then
         Me.dtTareas = oTarea.GetxFechaUsuario(Me.mclFecha.SelectionRange.Start, actual.Nombre).Tables(0)
      Else
         Me.dtTareas = oTarea.GetxFecha(Me.mclFecha.SelectionRange.Start).Tables(0)
      End If

      Me.clbTareas.Items.Clear()
      For Each dr As DataRow In Me.dtTareas.Rows
         oTar = New Entidades.Tarea
         oTar.Id = Convert.ToInt32(dr("Id"))
         oTar.Fecha = Convert.ToDateTime(dr("Fecha"))
         oTar.Tarea = dr("Tarea").ToString()
         oTar.Usuario = dr("Usuario").ToString()
         Me.clbTareas.Items.Add(oTar)
      Next
      Me.ActualizarContador()
   End Sub

   Private Sub ActualizarContador()
      Me.sslTareas.Text = Me.clbTareas.Items.Count & " Tareas"
   End Sub

#End Region

End Class