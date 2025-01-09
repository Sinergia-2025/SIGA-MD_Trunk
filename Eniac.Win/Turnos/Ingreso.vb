Option Strict Off
Imports Infragistics.Win.UltraWinGrid

Public Class Ingreso

#Region "Campos"

   Private _colorDefault As System.Drawing.Color
   '  Private _contrataciones As List(Of Entidades.Contratacion)
   Private _publicos As Publicos
   Private _titTurnos As Dictionary(Of String, String)
   Private _titTurnosAnteriores As Dictionary(Of String, String)
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      _publicos = New Publicos()

      Dim pub As Eniac.Win.Publicos = New Eniac.Win.Publicos()

      Me._colorDefault = Me.picImagen.BackColor

      '    Me._contrataciones = New List(Of Entidades.Contratacion)

      With UltraDropDown1
         .DataSource = New Reglas.EstadosTurnos().GetCombo()
         .ValueMember = "IdEstadoTurno"
         .DisplayMember = "NombreEstadoTurno"
      End With

      _titTurnos = GetColumnasVisiblesGrilla(ugTurnos)
      _titTurnosAnteriores = GetColumnasVisiblesGrilla(ugTurnosAnteriores)

      Me.ugTurnos.DisplayLayout.Bands(0).Columns("NombreEstadoTurno").ValueList = UltraDropDown1
      Me.bscCliente.Focus()

   End Sub

#End Region

#Region "Metodos"

   Private Sub Refrescar()
      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCliente.Text = String.Empty
      Me.bscCodigoCliente.Enabled = True
      Me.bscCliente.Enabled = True

      Me.picImagen.BackColor = Me._colorDefault
      '  Me._contrataciones.Clear()
      '   Me.dgvContrataciones.DataSource = Me._contrataciones.ToArray()
      If Me.ugTurnos.DataSource IsNot Nothing Then
         DirectCast(Me.ugTurnos.DataSource, DataTable).Rows.Clear()
      End If
      If Me.ugTurnosAnteriores.DataSource IsNot Nothing Then
         DirectCast(Me.ugTurnosAnteriores.DataSource, DataTable).Rows.Clear()
      End If

      Me.picImagen.Image = Nothing
      Me.lblCertificado.Text = String.Empty
      Me.bscCliente.Focus()
   End Sub

   Private Sub BuscarCliente()
      Dim reg As Reglas.Clientes = New Reglas.Clientes()
      Dim IdCliente As Long = 0
      Dim certi As String = String.Empty

      If Me.bscCodigoCliente.Text.Trim().Length > 0 Then
         IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If

      Dim cli As Entidades.Cliente = reg.GetUno(IdCliente, True)

      Dim Turnos As Reglas.TurnosCalendarios = New Reglas.TurnosCalendarios()

      Me.ugTurnos.DataSource = Turnos.GetTurnosxCliente(IdCliente)
      AjustarColumnasGrilla(ugTurnos, _titTurnos)
      Me.ugTurnosAnteriores.DataSource = Turnos.GetTurnosxClienteHistorial(IdCliente)
      AjustarColumnasGrilla(ugTurnosAnteriores, _titTurnosAnteriores)
      'If soc.FechaBaja <> Nothing Then
      '   MessageBox.Show(soc.NombreSocio + " esta dado/a de baja por:" + _
      '                     Convert.ToChar(Keys.Enter) + " - " + _
      '                     Convert.ToChar(Keys.Enter) + soc.MotivoBaja, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.Refrescar()
      'Else
      '   Me.txtNombreSocio.Text = soc.NombreSocio

      'Dim contra As Reglas.Contrataciones = New Reglas.Contrataciones()
      'Me._contrataciones = contra.GetTodosDeUnSocio(soc.TipoDocSocio.TipoDocumento, soc.NroDocSocio)
      'Me.dgvContrataciones.DataSource = Me._contrataciones.ToArray()

      ' Dim contraAct As Reglas.ContratacionesActividades = New Reglas.ContratacionesActividades()
      '  Me.dgvActividades.DataSource = contraAct.GetActividadDelSocio(soc.TipoDocSocio.TipoDocumento, soc.NroDocSocio)

      'If contra.EstaHabilitadoAIngresar(soc.TipoDocSocio.TipoDocumento, soc.NroDocSocio) Then
      Me.picImagen.BackColor = Me._colorDefault
      Me.picImagen.Image = cli.Foto
      '   If soc.EntregoCertMedico Then
      '      certi += "Entrego el Certificado Medico" + Convert.ToChar(Keys.Enter)
      '   End If
      '   If soc.FechaVencCertMedico <> Nothing Then
      '      certi += "Fecha Vencimiento " + soc.FechaVencCertMedico.ToString("dd/MM/yyyy")
      '   End If
      'Else
      '   Me.picImagen.BackColor = Color.Red
      '   MessageBox.Show("No esta habilitado a ingresar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End If

      Me.lblCertificado.Text = certi

      'End If
   End Sub

   Protected Overridable Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells(Entidades.Cliente.Columnas.NombreCliente.ToString()).Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Value.ToString().Trim()
      Me.bscCodigoCliente.Tag = dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()
      Me.bscCliente.Tag = New Reglas.Clientes().GetUno(Long.Parse(dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()))

      Me.bscCliente.Enabled = False
      Me.bscCodigoCliente.Enabled = False

      Me.btnBuscar.PerformClick()

   End Sub

   Private Sub CargarGrillas()
       Dim Turnos As Reglas.TurnosCalendarios = New Reglas.TurnosCalendarios()

      Me.ugTurnos.DataSource = Turnos.GetTurnosxCliente(Me.bscCodigoCliente.Tag)
      Me.ugTurnosAnteriores.DataSource = Turnos.GetTurnosxClienteHistorial(Me.bscCodigoCliente.Tag)

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Refrescar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub Ingreso_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      Try
         If e.KeyCode = Keys.F5 Then
            Me.Refrescar()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.BuscarCliente()

      Catch ex As Exception
         Me.Refrescar()
         Me.picImagen.BackColor = Color.Red
         Me.lblCertificado.Text = String.Empty
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.picImagen.BackColor = Me._colorDefault
      Finally
         'Me.bscCodigoCliente.Focus()
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         If IsNumeric(Me.bscCodigoCliente.Text) Then codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         Me.bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Me.bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.Refrescar()
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Function GetTurnoSeleccionado() As DataRow
      If ugTurnos.ActiveRow IsNot Nothing AndAlso
         ugTurnos.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugTurnos.ActiveRow.ListObject) Is DataRowView AndAlso
         DirectCast(ugTurnos.ActiveRow.ListObject, DataRowView).Row IsNot Nothing Then
         Return DirectCast(ugTurnos.ActiveRow.ListObject, DataRowView).Row
      End If
      Return Nothing
   End Function

   Private Sub tsbCambiarTipoTurno_Click(sender As Object, e As EventArgs) Handles tsbCambiarTipoTurno.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim drTurnoSeleccionado As DataRow = GetTurnoSeleccionado()
         If drTurnoSeleccionado IsNot Nothing Then
            Dim turnosTipoBase As Entidades.EstadoTurno = New Reglas.EstadosTurnos().GetUno(Reglas.Publicos.TurnosEstadoBase)
            Dim turnosTipoCambio As Entidades.EstadoTurno = New Reglas.EstadosTurnos().GetUno(Reglas.Publicos.TurnosTipoCambio)
            If drTurnoSeleccionado("IdEstadoTurno").ToString() <> turnosTipoBase.IdEstadoTurno Then
               ShowMessage(String.Format("El turno seleccionado está en {0}. Solo se pueden confirmar en {1}.", drTurnoSeleccionado("NombreTipoTurno"), turnosTipoBase.NombreEstadoTurno))
               Exit Sub
            End If
            If ShowPregunta(String.Format("Desea cambiar a '{0}' el turno de las {1}", turnosTipoCambio.NombreEstadoTurno, drTurnoSeleccionado("FechaDesde"))) = Windows.Forms.DialogResult.Yes Then
               Dim reg As Reglas.TurnosCalendarios = New Reglas.TurnosCalendarios()
               Dim en As Entidades.TurnoCalendario = New Entidades.TurnoCalendario()
               en = reg.GetUno(Integer.Parse(drTurnoSeleccionado("IdTurno").ToString()), idCalendario:=0)
               en.IdEstadoTurno = Reglas.Publicos.TurnosTipoCambio
               reg.ActualizarAtencion(en.IdTurno, en.IdEstadoTurno)
               btnBuscar.PerformClick()
            End If
         End If            'If ugTurnos.ActiveRow IsNot Nothing Then
         'If Me.ugTurnos.Rows.Count <> 0 Then
         '   Dim reg As Reglas.TurnosCalendarios = New Reglas.TurnosCalendarios()
         '   Dim en As Entidades.TurnoCalendario = New Entidades.TurnoCalendario()

         '   If MessageBox.Show("Desea cambiar el estado de todos los pendientes?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
         '      Dim TurnoBase As String = New Reglas.TiposTurnos().GetUno(Publicos.TurnosTipoBase).NombreTipoTurno
         '      Dim TurnoCambio As String = New Reglas.TiposTurnos().GetUno(Publicos.TurnosTipoCambio).IdTipoTurno

         '      For Each dr As UltraGridRow In Me.ugTurnos.Rows
         '         If dr.Cells("NombreTipoTurno").Value = TurnoBase Then
         '            reg = New Reglas.TurnosCalendarios()
         '            en = New Entidades.TurnoCalendario()
         '            en = reg.GetUnoxTurno(Long.Parse(dr.Cells("IdCliente").Value.ToString()), Integer.Parse(dr.Cells("idCalendario").Value.ToString()),
         '                                  Date.Parse(dr.Cells("FechaDesde").Value.ToString()), Date.Parse(dr.Cells("FechaHasta").Value.ToString()))

         '            en.TipoTurno.IdTipoTurno = TurnoCambio
         '            reg.ActualizarAtencion(en)

         '         End If
         '      Next
         '      Me.CargarGrillas()
         '   Else

         '      If Me.ugTurnos.ActiveRow.Cells("NombreTipoTurno").IsActiveCell Then
         '         Me.ugTurnos.UpdateData()

         '         en = reg.GetUnoxTurno(Long.Parse(Me.ugTurnos.ActiveRow.Cells("IdCliente").Value.ToString()), Integer.Parse(Me.ugTurnos.ActiveRow.Cells("idCalendario").Value.ToString()),
         '                               Date.Parse(Me.ugTurnos.ActiveRow.Cells("FechaDesde").Value.ToString()), Date.Parse(Me.ugTurnos.ActiveRow.Cells("FechaHasta").Value.ToString()))

         '         'Dim TipoTurno As Entidades.TipoTurno = New Reglas.TiposTurnos().GetxDescripcion(Me.ugTurnos.ActiveRow.Cells("NombreTipoTurno").Value.ToString())
         '         en.TipoTurno.IdTipoTurno = Me.ugTurnos.ActiveRow.Cells("NombreTipoTurno").Value.ToString()
         '         reg.ActualizarAtencion(en)
         '         MessageBox.Show("Se modificó el Tipo de Turno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '         Me.CargarGrillas()
         '      Else
         '         MessageBox.Show("No modificó el Tipo de Turno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '      End If
         '   End If
         'End If               'If Me.ugTurnos.Rows.Count <> 0 Then

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

End Class