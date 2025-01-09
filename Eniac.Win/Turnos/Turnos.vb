Imports Actual = Eniac.Entidades.Usuario.Actual

Public Class Turnos

#Region "Overrides"

   Private _titPresentes As Dictionary(Of String, String)
   Private _titAusentes As Dictionary(Of String, String)
   Private _titAtendidos As Dictionary(Of String, String)
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)
      tbcTurnos.SelectedTab = tbpAtendidos
      _titAtendidos = GetColumnasVisiblesGrilla(ugAtendidos)
      tbcTurnos.SelectedTab = tbpPresentes
      _titPresentes = GetColumnasVisiblesGrilla(ugPresentes)
      _titAusentes = GetColumnasVisiblesGrilla(ugAusentes)

      Me.txtUsuario.Text = New Reglas.Usuarios().GetUno(Actual.Nombre).Nombre

      Dim pubG As Publicos = New Publicos()

      pubG.CargaComboCalendariosxUsuario(cmbCalendario, Actual.Sucursal.IdSucursal, Actual.Nombre)
      If Me.cmbCalendario.Items.Count <> 0 Then
         Me.cmbCalendario.SelectedIndex = 0
      Else
         MessageBox.Show("No existen Calendarios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Exit Sub
      End If


      '   pubG.CargarComboActividadesPorUsuario(Me.cmbActividad, Eniac.Entidades.Usuario.Actual.Nombre)

   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarGrillas()
      If Me.cmbCalendario.SelectedIndex <> -1 Then

         Dim reg As Reglas.TurnosCalendarios = New Reglas.TurnosCalendarios()

         Dim idCalendario As Integer = Integer.Parse(Me.cmbCalendario.SelectedValue.ToString())

         Me.ugAusentes.DataSource = reg.GetAusentesConTurnos(idCalendario, Me.mtcFecha.SelectionStart)

         Me.AjustarColumnasGrilla(ugAusentes, _titAusentes)

         Me.ugPresentes.DataSource = reg.GetPresentesConTurnos(idCalendario, Me.mtcFecha.SelectionStart, False)

         Me.AjustarColumnasGrilla(ugPresentes, _titPresentes)

         Me.ugAtendidos.DataSource = reg.GetAtendidos(idCalendario, Me.mtcFecha.SelectionStart, True)

         Me.AjustarColumnasGrilla(ugAtendidos, _titAtendidos)

      End If

   End Sub

#End Region

#Region "Eventos"

   Private Sub Turnos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

      If e.KeyCode = Keys.F5 Then
         Try
            Me.Cursor = Cursors.WaitCursor

            Me.tsbRefrescar.PerformClick()

         Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If

   End Sub

   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub cmbActividad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCalendario.SelectedIndexChanged
      Try
         Me.CargarGrillas()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub mtcFecha_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mtcFecha.DateChanged
      Try
         Me.CargarGrillas()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.CargarGrillas()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   'Private Sub ugAtendidos_ClickCell(sender As Object, e As UltraWinGrid.ClickCellEventArgs) Handles ugAtendidos.ClickCell
   '   Try
   '      If Me.ugAtendidos.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Key = "EsEfectivo" Then
   '         Dim dr As DataRow = ugPresentes.FilaSeleccionada(Of DataRow)(e.Cell.Row)
   '         If dr IsNot Nothing Then
   '            If ShowPregunta("¿Cancela la atención?") = Windows.Forms.DialogResult.Yes Then
   '               Dim idTurno As Integer = Integer.Parse(dr("IdTurno").ToString())
   '               Dim reg As Reglas.TurnosCalendarios = New Reglas.TurnosCalendarios()
   '               reg.ActualizarAtencion(idTurno, "E")
   '               Me.CargarGrillas()
   '            End If
   '         End If
   '      End If

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Private Sub ugAtendidos_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugAtendidos.ClickCellButton
      Try
         Dim IdCliente As Long = New Reglas.Clientes().GetUnoPorCodigo(Long.Parse(Me.ugAtendidos.Rows(e.Cell.Row.Index).Cells("CodigoCliente").Value.ToString())).IdCliente
         Dim idCalendario As Integer = Integer.Parse(Me.ugAtendidos.Rows(e.Cell.Row.Index).Cells("IdCalendario").Value.ToString())
         Dim fechaHoraInicio As DateTime = DateTime.Parse(Me.ugAtendidos.Rows(e.Cell.Row.Index).Cells("FechaDesde").Value.ToString())
         Dim fechaHoraFin As DateTime = DateTime.Parse(Me.ugAtendidos.Rows(e.Cell.Row.Index).Cells("FechaHasta").Value.ToString())
         If Me.ugAtendidos.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Header.Caption = "Historial" Then
            Dim hi As Historial = New Historial(IdCliente)
            hi.ShowDialog()
         ElseIf Me.ugAtendidos.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Key = "Atendido" Then
            Dim dr As DataRow = ugPresentes.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If dr IsNot Nothing Then
               If ShowPregunta("¿Cancela la atención?") = Windows.Forms.DialogResult.Yes Then
                  Dim idTurno As Integer = Integer.Parse(dr("IdTurno").ToString())
                  Dim reg As Reglas.TurnosCalendarios = New Reglas.TurnosCalendarios()
                  reg.ActualizarAtencion(idTurno, "E")
                  Me.CargarGrillas()
               End If
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   'Private Sub ugPresentes_ClickCell(sender As Object, e As UltraWinGrid.ClickCellEventArgs) Handles ugPresentes.ClickCell
   '   Try
   '      If Me.ugPresentes.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Key = "EsEfectivo" Then
   '         Dim dr As DataRow = ugPresentes.FilaSeleccionada(Of DataRow)(e.Cell.Row)
   '         If dr IsNot Nothing Then
   '            If ShowPregunta("¿Confirma la atención?") = Windows.Forms.DialogResult.Yes Then
   '               Dim idTurno As Integer = Integer.Parse(dr("IdTurno").ToString())
   '               Dim reg As Reglas.TurnosCalendarios = New Reglas.TurnosCalendarios()
   '               reg.ActualizarAtencion(idTurno, "T")
   '               Me.CargarGrillas()
   '            End If
   '         End If
   '      End If

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try

   'End Sub

   Private Sub ugPresentes_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugPresentes.ClickCellButton
      Try
         Dim IdCliente As Long = New Reglas.Clientes().GetUnoPorCodigo(Long.Parse(Me.ugPresentes.Rows(e.Cell.Row.Index).Cells("CodigoCliente").Value.ToString())).IdCliente
         Dim idCalendario As Integer = Integer.Parse(Me.ugPresentes.Rows(e.Cell.Row.Index).Cells("IdCalendario").Value.ToString())
         Dim fechaHoraInicio As DateTime = DateTime.Parse(Me.ugPresentes.Rows(e.Cell.Row.Index).Cells("FechaDesde").Value.ToString())
         Dim fechaHoraFin As DateTime = DateTime.Parse(Me.ugPresentes.Rows(e.Cell.Row.Index).Cells("FechaHasta").Value.ToString())
         If Me.ugPresentes.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Header.Caption = "Historial" Then
            Dim hi As Historial = New Historial(IdCliente)
            hi.ShowDialog()
         ElseIf Me.ugPresentes.Rows(e.Cell.Row.Index).Cells(e.Cell.Column.Index).Column.Key = "Atendido" Then
            Dim dr As DataRow = ugPresentes.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If dr IsNot Nothing Then
               If ShowPregunta("¿Confirma la atención?") = Windows.Forms.DialogResult.Yes Then
                  Dim idTurno As Integer = Integer.Parse(dr("IdTurno").ToString())
                  Dim reg As Reglas.TurnosCalendarios = New Reglas.TurnosCalendarios()
                  reg.ActualizarAtencion(idTurno, "T")
                  Me.CargarGrillas()
               End If
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

End Class