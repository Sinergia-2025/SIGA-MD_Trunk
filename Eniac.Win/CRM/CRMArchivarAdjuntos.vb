Imports Infragistics.Win.UltraWinGrid

Public Class CRMArchivarAdjuntos

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      TryCatched(Sub()
                    Me._publicos = New Publicos()

                    _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnum))

                    ugDetalle.AgregarFiltroEnLinea({"Descripcion", "NombreAdjunto", "NombreClienteProspectoProveedor", "NombreDeFantasiaClienteProspectoProveedor"})
                    ugDetalle.AgregarTotalesSuma({"Bytes", "KBytes", "MBytes"})
                 End Sub)
   End Sub
   Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
      If bkwArchivar.IsBusy Then
         ShowMessage("No se puede cerrar mientras el procesa está en ejecución. Presione Cancelar para poder cerrar la ventana.")
         e.Cancel = True
      End If
      MyBase.OnClosing(e)
   End Sub
#End Region

#Region "Eventos"
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(Sub()
                    Me.CargaGrillaDetalle()
                    If ugDetalle.Rows.Count > 0 Then
                       Me.btnConsultar.Focus()
                    Else
                       Me.Cursor = Cursors.Default
                       ShowMessage("NO hay registros que cumplan con la seleccion !!!")
                       Exit Sub
                    End If
                 End Sub)
   End Sub
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub tsbArchivar_Click(sender As Object, e As EventArgs) Handles tsbArchivar.Click
      TryCatched(Sub()
                    IniciarWorker()
                 End Sub)
   End Sub

   Private Sub tsbCancelar_Click(sender As Object, e As EventArgs) Handles tsbCancelar.Click
      If bkwArchivar.IsBusy Then
         bkwArchivar.CancelAsync()
      End If
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region

#Region "Marcar/Desmarcar Todos"
   Private Const selecColumnName As String = "Selec"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnum Then

            Me.Cursor = Cursors.WaitCursor

            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnum)
               Case Reglas.Publicos.TodosEnum.MararTodos
                  MarcarDesmarcar(True, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarTodos

               Case Reglas.Publicos.TodosEnum.DesmarcarTodos
                  MarcarDesmarcar(False, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos

               Case Reglas.Publicos.TodosEnum.MarcarFiltrados
                  MarcarDesmarcar(True, ugDetalle.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarFiltrados

               Case Reglas.Publicos.TodosEnum.DesmarcarFiltrados
                  MarcarDesmarcar(False, ugDetalle.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MarcarFiltrados

               Case Reglas.Publicos.TodosEnum.InvertirMarcasTodos
                  MarcarDesmarcar(Nothing, ugDetalle.Rows.ToArray())

               Case Reglas.Publicos.TodosEnum.InvertirMarcasFiltrados
                  MarcarDesmarcar(Nothing, ugDetalle.Rows.GetFilteredInNonGroupByRows())

               Case Else

            End Select
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         ugDetalle.UpdateData()
      End Try
   End Sub
   Private Sub MarcarDesmarcar(marcar As Boolean?, rows As UltraGridRow())
      For Each dr As UltraGridRow In rows
         If marcar.HasValue Then
            dr.Cells(selecColumnName).Value = marcar.Value
         Else
            dr.Cells(selecColumnName).Value = Not CBool(dr.Cells(selecColumnName).Value)
         End If
      Next
   End Sub
#End Region

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()

      If TypeOf (Me.ugDetalle.DataSource) Is DataTable Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim rAdjuntos = New Reglas.CRMNovedadesSeguimientoAdjuntos()

      Dim dtDetalle = rAdjuntos.GetAdjuntosParaArchivar()

      Me.ugDetalle.DataSource = dtDetalle
      'Me.FormatearGrilla()
      Me.tssRegistros.Text = dtDetalle.Rows.Count.ToString() & " Registros"

      Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarTodos

      ugDetalle.DisplayLayout.Bands(0).Columns("EstadoProceso").Hidden = True
      ugDetalle.DisplayLayout.Bands(0).Columns("MensajeProceso").Hidden = True

   End Sub
#End Region

   Private Sub IniciarWorker()
      If TypeOf (Me.ugDetalle.DataSource) Is DataTable Then
         ugDetalle.UpdateData()
         tspBarra.Value = 0
         bkwArchivar.RunWorkerAsync(New Object() {DirectCast(ugDetalle.DataSource, DataTable), txtNombreEstadoNovedad.Text})
         ChangeEnable(False)

         ugDetalle.DisplayLayout.Bands(0).Columns("EstadoProceso").Hidden = False
         ugDetalle.DisplayLayout.Bands(0).Columns("MensajeProceso").Hidden = False
      End If

   End Sub
   Private Sub bkwArchivar_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bkwArchivar.DoWork
      Dim dt = DirectCast(DirectCast(e.Argument, Object())(0), DataTable)
      Dim rootPath = DirectCast(DirectCast(e.Argument, Object())(1), String)
      Dim rAdjuntos = New Reglas.CRMNovedadesSeguimientoAdjuntos()
      rAdjuntos.ArchivarAdjuntos(dt, rootPath,
                                 Sub(mensaje, i, length)
                                    bkwArchivar.ReportProgress(Convert.ToInt32((i / length) * 100), mensaje)
                                 End Sub,
                                 Function() bkwArchivar.CancellationPending)
      If bkwArchivar.CancellationPending Then
         e.Cancel = True
      End If

   End Sub

   Private Sub bkwArchivar_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bkwArchivar.ProgressChanged
      tspBarra.Value = e.ProgressPercentage
      tssInfo.Text = DirectCast(e.UserState, String)
   End Sub

   Private Sub bkwArchivar_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bkwArchivar.RunWorkerCompleted
      ChangeEnable(True)
      Dim stb = New StringBuilder()
      Dim dt = DirectCast(ugDetalle.DataSource, DataTable)

      stb.AppendFormatLine("Proceso {0} ", If(e.Cancelled, "Cancelado por el usuario", "Finalizado Exitosamente")).AppendLine()
      stb.AppendFormatLine("{0} adjuntos archivados exitosamente", dt.Select("EstadoProceso = 'Exitoso'").Length)
      stb.AppendFormatLine("{0} adjuntos con error", dt.Select("EstadoProceso = 'Error'").Length)
      stb.AppendFormatLine("{0} adjuntos no procesados", dt.Select("EstadoProceso = '' OR EstadoProceso = 'Comenzando'").Length)

      ShowMessage(stb.ToString())

   End Sub

   Private Sub ChangeEnable(enable As Boolean)
      tsbRefrescar.Enabled = enable
      tsbArchivar.Enabled = enable
      tsbSalir.Enabled = enable
      btnConsultar.Enabled = enable
      btnTodos.Enabled = enable

      tsbCancelar.Visible = Not enable

      ugDetalle.DisplayLayout.Override.AllowUpdate = If(enable, DefaultableBoolean.True, DefaultableBoolean.False)
   End Sub

End Class