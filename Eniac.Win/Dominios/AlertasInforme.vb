Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class AlertasInforme

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Dim p As New Eniac.Win.Publicos

         Me.cboPrioridad.Items.Insert(0, "TODAS")
         Me.cboPrioridad.Items.Insert(1, "ALTA")
         Me.cboPrioridad.Items.Insert(2, "NORMAL")
         Me.cboPrioridad.SelectedIndex = 0

         p.CargaComboCRMCategoriasNovedades(Me.cmbTipoDeNotificacion, "ALERTAS")

         Me.CargarValoresIniciales()
         'Me.RecargarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
         Me.RecargarDatosGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub RecargarDatosGrilla()
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim idTipoVehiculo As Integer = 0
         Dim fechaDesde As DateTime = Nothing
         Dim fechaHasta As DateTime = Nothing
         Dim idLocalidad As Integer = 0
         Dim idTipoNotificacion As Integer = 0
         Dim IdCliente As Long = 0
         Dim idCategoriaNovedad As Integer = 0
         Dim idEstadoNovedad As Integer = 0
         Dim IdUsuarioAsignado As String = String.Empty
         Dim IdMedioComunicacionNovedad As Integer = 0
         Dim IdNovedad As Integer = 0
         Dim IdProspecto As Long = 0
         Dim IdProveedor As Long = 0
         Dim IdPrioridadNovedad As Integer = 0
         Dim IdUsuarioAlta As String = String.Empty
         Dim FecNovedad As Boolean = True
         Dim Priorizado As Boolean? = Nothing

         Dim reg As Reglas.CRMNovedades = New Reglas.CRMNovedades()

         Dim cantFiltros As Integer = 0
         Dim TelefonoTenedor As String

         If Me.dtpDesde.Checked Then
            cantFiltros = cantFiltros + 1
            fechaDesde = Me.dtpDesde.Value
         End If
         If Me.dtpHasta.Checked Then
            cantFiltros = cantFiltros + 1
            fechaHasta = Me.dtpHasta.Value
         End If
         If Me.chbTipoDeNotificacion.Checked Then
            cantFiltros = cantFiltros + 1
            idCategoriaNovedad = Int32.Parse(Me.cmbTipoDeNotificacion.SelectedValue.ToString())
         End If

         If Me.cboPrioridad.Text = "ALTA" Then
            Priorizado = True
         ElseIf Me.cboPrioridad.Text = "NORMAL" Then
            Priorizado = False
         End If

         Dim colAlertas As DataTable

            Dim dt As DataTable, drCl As DataRow

         colAlertas = reg.GetAlertasInforme(dtpDesde.Value, dtpHasta.Value, "ALERTAS", True,
                                    idCategoriaNovedad, Priorizado)

            dt = Me.CrearDT()

            Dim totalDeuda As Decimal = 0

         
         Me.ugDetalle.DataSource = colAlertas

         Me.FormatearGrilla()

      Catch ex As Exception
         Throw
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub AlertasInforme_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Me.RecargarDatosGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarValoresIniciales()

      Me.cboPrioridad.SelectedIndex = 0
      Me.cmbTipoDeNotificacion.SelectedIndex = 1
      Me.chbTipoDeNotificacion.Checked = True
      Me.dtpDesde.Value = DateTime.Now.AddDays(-30)
      Me.dtpDesde.Checked = False
      Me.dtpHasta.Value = DateTime.Now
      Me.dtpHasta.Checked = True

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         .Columns.Add("Titular", System.Type.GetType("System.String"))
         .Columns.Add("PatenteVehiculo", System.Type.GetType("System.String"))
         .Columns.Add("MotivoAlerta", System.Type.GetType("System.String"))
         .Columns.Add("FechaAlerta", System.Type.GetType("System.DateTime"))
         .Columns.Add("IdDato", System.Type.GetType("System.Int64"))
         .Columns.Add("TipoNotificacion", System.Type.GetType("System.String"))
         .Columns.Add("TotalDeuda", System.Type.GetType("System.Decimal"))
         .Columns.Add("PrioridadAlta", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoriaCliente", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

   Private Sub chbTipoDeNotificacion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoDeNotificacion.CheckedChanged
      Me.cmbTipoDeNotificacion.Enabled = Me.chbTipoDeNotificacion.Checked
   End Sub


   Private Sub btnBuscar2_Click(sender As Object, e As EventArgs) Handles btnBuscar2.Click
      Try
         Me.RecargarDatosGrilla()
         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Public Sub FormatearGrilla()
      ugDetalle.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
      ugDetalle.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
      ugDetalle.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
      ugDetalle.DisplayLayout.Override.FilterRowAppearance.BackColor = Color.AntiqueWhite
      ugDetalle.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True

      ugDetalle.DisplayLayout.UseFixedHeaders = True
      ugDetalle.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None

      With Me.ugDetalle.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
         Next

         'If Not .Columns.Exists("Ver") Then
         '   .Columns.Add("Ver")
         'End If

         'If Not .Columns.Exists(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1") Then
         '   .Columns.Add(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1", String.Empty)
         'End If

         Dim pos As Integer = 0

         'FormatearColumna(.Columns("Ver"), "Ver", pos, 30, HAlign.Center)
         '.Columns("Ver").Style = ColumnStyle.Button
         '.Columns("Ver").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         '.Columns("Ver").Header.Fixed = True

         'FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1"), "", pos, 60)
         '.Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").Header.Fixed = True
         '.Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").CellActivation = Activation.NoEdit

         'FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString()), "", 1000, 30, , True)

         'FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()), "Tipo", pos, 60, , False)
         'FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()), "Número", pos, 60, HAlign.Right)

         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString()), "Fecha / Hora", pos, 120, HAlign.Center, hidden:=True)
         .Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString() + "_Fecha"), "Fecha", pos, 80, HAlign.Center)
         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString() + "_Hora"), "Hora", pos, 40, HAlign.Center)


         'Oculta
         'FormatearColumna(.Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()), "Código", 4, 80, HAlign.Right)
         FormatearColumna(.Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()), "Nombre Cliente", pos, 300)
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
         'FormatearColumna(.Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()), "Nombre de Fantasia", pos, 200)
         '.Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains

         FormatearColumna(.Columns("NombreCategoriaCliente"), "Categoria Cliente", pos, 120)


         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.Descripcion.ToString()), "Descripción", pos, 270)
         .Columns(Entidades.CRMNovedad.Columnas.Descripcion.ToString()).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains

         FormatearColumna(.Columns(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()), "Categoria", pos, 200)
         'FormatearColumna(.Columns(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()), "Estado", pos, 80)

         'FormatearColumna(.Columns(Entidades.CRMEstadoNovedad.Columnas.Finalizado.ToString()), "Fin.", pos, 40, HAlign.Center)

         'FormatearColumna(.Columns("HorasFinalizacion"), "Tiempo Resolución", pos, 70, HAlign.Right)

         'FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdUsuarioAsignado.ToString()), "Usuario Asignado", pos, 70)

         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.Priorizado.ToString()), "Prioridad", pos, 70)



         'FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString()), "Prox. Contacto", pos, 120, HAlign.Center, hidden:=True)
         '.Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         'FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString() + "_Fecha"), "Fecha Prox. Contacto", pos, 80, HAlign.Center)
         'FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString() + "_Hora"), "Hora Prox. Contacto", pos, 40, HAlign.Center)

         'FormatearColumna(.Columns(Entidades.CRMMedioComunicacionNovedad.Columnas.NombreMedioComunicacionNovedad.ToString()), "Medio", pos, 100)

         'FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString()), "Fecha/Hora Estado", pos, 80, HAlign.Center, hidden:=True)
         '.Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         'FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString() + "_Fecha"), "Fecha Estado", pos, 80, HAlign.Center)
         'FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString() + "_Hora"), "Hora Estado", pos, 40, HAlign.Center)

         ''FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdUsuarioEstadoNovedad.ToString()), "Usuario Estado", pos, 80)

         'FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdUsuarioAlta.ToString()), "Usuario Alta", pos, 80)


      End With

   End Sub

   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
      Try
         Dim en As Entidades.ClienteDeuda = New Reglas.ClientesDeudas().GetUno(Long.Parse(Me.ugDetalle.ActiveRow.Cells("IdCliente").Value.ToString()), 0)



         Me.Cursor = Cursors.Default
         Dim da As MutualDetalle = New MutualDetalle(en)
         da.StateForm = Eniac.Win.StateForm.Actualizar

         da.ShowDialog()

         If da.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.RecargarDatosGrilla()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugDetalle.AfterRowFilterChanged
      Try
         Me.tssRegistros.Text = Me.ugDetalle.Rows.FilteredInRowCount.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class