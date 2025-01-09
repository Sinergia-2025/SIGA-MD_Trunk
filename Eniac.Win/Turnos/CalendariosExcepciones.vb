Option Strict Off
Imports Infragistics.Win.UltraWinGrid

Public Class CalendariosExcepciones
   Private _excepciones As DataTable = New DataTable

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)


      Dim pubG As Publicos = New Publicos()

      'CargaComboDesdeEnum(cmbDiaSemana, System.Enum.GetValues(GetType(DayOfWeek)))
      'cmbDiaSemana.Text = Me.dtpHoraDesde.Value.DayOfWeek.NombreDiaSemana.ToString()
      Me.lblDiaSemanaNombre.Text = Me.dtpHoraDesde.Value.DayOfWeek.NombreDiaSemana.ToString()

      pubG.CargaComboCalendariosxUsuario(cmbCalendario, Actual.Sucursal.IdSucursal, Actual.Nombre)
      If Me.cmbCalendario.Items.Count <> 0 Then
         Me.cmbCalendario.SelectedIndex = 0
      Else
         MessageBox.Show("No existen Calendarios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Exit Sub
      End If
      Me.CargarGrillas()
   
   End Sub

#End Region

#Region "Metodos"

   Public Sub CargaComboDesdeEnum(ByVal combo As Eniac.Controles.ComboBox, enumArray As Array)
      Dim list As List(Of KeyValuePair(Of Object, String)) = New List(Of KeyValuePair(Of Object, String))()
      For Each item As System.Enum In enumArray
         If Publicos.CheckBrowsable(item) Then
            list.Add(New KeyValuePair(Of Object, String)(item, DirectCast(item, DayOfWeek).NombreDiaSemana()))
         End If
      Next

      combo.DataSource = list
      combo.DisplayMember = "Value"
      combo.ValueMember = "Key"
   End Sub

   Private Sub CargarGrillas()
      If Me.cmbCalendario.SelectedIndex <> -1 Then

         Dim reg As Reglas.TurnosCalendarios = New Reglas.TurnosCalendarios()

         Dim idCalendario As Integer = Integer.Parse(Me.cmbCalendario.SelectedValue.ToString())

         Me.ugDiasSemana.DataSource = New Reglas.CalendariosHorarios().GetTodos(idCalendario)

         Dim reg2 As Reglas.CalendariosExcepciones = New Reglas.CalendariosExcepciones()

         Me._excepciones = reg2._GetTodos(Integer.Parse(cmbCalendario.SelectedValue.ToString()))

         Me.ugExcepciones.DataSource = Me._excepciones

      End If

   End Sub

#End Region

#Region "Eventos"

   Private Sub CalendariosExcepciones_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

      'GAR: 07/06/2018 - Por el momento no es conveniente borrar las excepciones por el riesgo que de grabar. Ante solicitud del usuario se replantearia.
      'If e.KeyCode = Keys.F5 Then
      '   Try
      '      Me.Cursor = Cursors.WaitCursor
      '      Me.CargarGrillas()
      '   Catch ex As Exception
      '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Finally
      '      Me.Cursor = Cursors.Default
      '   End Try
      'End If
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

   Private Sub mtcFecha_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs)
      Try
         Me.CargarGrillas()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         If ugExcepciones.Rows.Count > 0 And Me.tsbGrabar.Enabled Then
            Me.Cursor = Cursors.WaitCursor
            If MessageBox.Show("Desea limpiar todos los datos ingresados", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.Refrescar()
            End If
         Else
            Me.Refrescar()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         If ValidarInsertarExcepcion() Then
            InsertarExcepcion()
            Me.dtpHoraDesde.Focus()
            'cmbDiaSemana.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub Refrescar()

      'Me.tsbGrabar.Enabled = False
      Me.dtpHoraDesde.Value = Date.Today
      Me.dtpHoraHasta.Value = Date.Today

      Me.RefrescarDatosGrilla()

   End Sub

   Private Sub RefrescarDatosGrilla()

      If Not Me.ugExcepciones.DataSource Is Nothing Then
         DirectCast(Me.ugExcepciones.DataSource, DataTable).Rows.Clear()
      End If


   End Sub

   Private Function ValidarInsertarExcepcion() As Boolean

      'If cmbDiaSemana.SelectedIndex < 0 Then
      '   cmbDiaSemana.Focus()
      '   Return False
      'End If

      'Controlo que no haya turnos
      Dim Turnos As List(Of Entidades.TurnoCalendario) = New Reglas.TurnosCalendarios().GetTodos(Integer.Parse(cmbCalendario.SelectedValue.ToString()),
                                   dtpHoraDesde.Value, dtpHoraDesde.Value)


      If Turnos.Count > 0 Then
         MessageBox.Show("Hay turnos para el día seleccionado, reprograme los turnos y vuelva a ingresar la excepción.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      Dim entro As Boolean = False
      For Each dr As UltraGridRow In Me.ugDiasSemana.Rows
         If dr.Cells("NombreDiaSemana").Value.ToString() = Me.dtpHoraDesde.Value.DayOfWeek.NombreDiaSemana.ToString() Then
            entro = True
         End If
      Next
      If Not entro Then
         MessageBox.Show("El dia no pertenece a los horarios del Calendario.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      Else
         'cmbDiaSemana.Text = Me.dtpHoraDesde.Value.DayOfWeek.NombreDiaSemana.ToString()
         Me.lblDiaSemanaNombre.Text = Me.dtpHoraDesde.Value.DayOfWeek.NombreDiaSemana.ToString()
      End If

      For Each dia As UltraGridRow In ugExcepciones.Rows
         Dim fecha As String = Date.Parse(dia.Cells("FechaExcepcion").Value.ToString()).ToString("yyyy/MM/dd")
         Dim fechaIngresar As String = dtpHoraDesde.Value.ToString("yyyy/MM/dd")
         If fecha = fechaIngresar Then
            MessageBox.Show("La excepción ya fue ingresada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
         End If
      Next
      Return True
   End Function

   Private Sub InsertarExcepcion()

      Dim dr As DataRow

      dr = Me._excepciones.NewRow()
      dr("IdCalendario") = Integer.Parse(Me.cmbCalendario.SelectedValue.ToString())
      'dr("IdExcepcion") = Integer.Parse(Me.cmbCalendario.SelectedValue.ToString())
      dr("FechaExcepcion") = dtpHoraDesde.Value.ToString("yyyy/MM/dd")
      dr("IdDiaSemana") = Me.dtpHoraDesde.Value.DayOfWeek   'DirectCast(cmbDiaSemana.SelectedValue, DayOfWeek)
      dr("NombreDiaSemana") = Me.lblDiaSemanaNombre.Text    'cmbDiaSemana.Text.ToString()

      Me._excepciones.Rows.Add(dr)

      Me.ugExcepciones.DataSource = _excepciones

   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try

         Dim dt As DataTable = DirectCast(Me.ugExcepciones.DataSource, DataTable)
         Dim reg As Reglas.CalendariosExcepciones = New Reglas.CalendariosExcepciones()

         reg.GrabarCalendariosExcepciones(Integer.Parse(Me.cmbCalendario.SelectedValue.ToString()), dt)

         MessageBox.Show("Se actualizaron los datos correctamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.Refrescar()
         Me.CargarGrillas()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub dtpHoraDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpHoraDesde.ValueChanged
      Try
         If Me.dtpHoraDesde.Value < Date.Today Then
            MessageBox.Show("No puede seleccionar una fecha menor al dia actual.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            Dim entro As Boolean = False
            For Each dr As UltraGridRow In Me.ugDiasSemana.Rows
               If dr.Cells("NombreDiaSemana").Value.ToString() = Me.dtpHoraDesde.Value.DayOfWeek.NombreDiaSemana.ToString() Then
                  entro = True
               End If
            Next
            If Not entro Then
               MessageBox.Show("El dia no pertenece a los horarios del Calendario.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
               'cmbDiaSemana.Text = Me.dtpHoraDesde.Value.DayOfWeek.NombreDiaSemana.ToString()
               Me.lblDiaSemanaNombre.Text = Me.dtpHoraDesde.Value.DayOfWeek.NombreDiaSemana.ToString()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If Me.ugExcepciones.ActiveRow.Activated Then
            If MessageBox.Show("Esta Seguro de Eliminar la Excepción?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.tsbGrabar.Enabled = True
               Me.EliminarLineaDescuento()
            End If
         Else
            MessageBox.Show("No seleccionó ninguna excepción.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub EliminarLineaDescuento()

      Me._excepciones.Rows(Me.ugExcepciones.ActiveRow.Index).Delete()
      Me.ugExcepciones.DataSource = Me._excepciones

      If Me.ugExcepciones.Rows.Count > 0 Then
         Me.ugExcepciones.Rows(Me.ugExcepciones.Rows.Count - 1).Selected = True
      End If

   End Sub
End Class