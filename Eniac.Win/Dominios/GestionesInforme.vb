Public Class GestionesInforme

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()


         Dim ousuarios As Reglas.Usuarios = New Reglas.Usuarios()
         Me.cmbUsuarios.DisplayMember = "Id"
         Me.cmbUsuarios.ValueMember = "Id"
         Me.cmbUsuarios.DataSource = ousuarios.GetActivos(toLowerId:=False, usuarioActual:=String.Empty)
         Me.cmbUsuarios.SelectedIndex = -1

         Dim p As New Eniac.Win.Publicos
         p.CargaComboCRMCategoriasNovedades(Me.cmbTipoDeNotificacion, "GESTIONES")
         Me.cmbTipoDeNotificacion.SelectedValue = 2   'Llamado saliente
         Me.chbTipoDeNotificacion.Checked = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"


   Private Sub tsbRefrescar_Click(sender As System.Object, e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
         Me.CargarDatosGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
      Try

         If Me.chbUsuarios.Checked And Me.cmbUsuarios.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Habilito el filtro por Usuario y no selecciono un valor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbUsuarios.Focus()
            Exit Sub
         End If

         If Me.chbTipoDeNotificacion.Checked And cmbTipoDeNotificacion.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: Habilito el filtro por Tipo de Notificacion y no selecciono un valor.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbTipoDeNotificacion.Focus()
            Exit Sub
         End If

         Me.CargarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDatos.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbUsuario_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbUsuarios.CheckedChanged
      Me.cmbUsuarios.Enabled = Me.chbUsuarios.Checked
      If (Me.ugDatos.DisplayLayout.Bands(0).Columns.Exists("Id")) Then
         Me.ugDatos.DisplayLayout.Bands(0).Columns("Id").Hidden = Me.chbUsuarios.Checked
      End If
      If Me.chbUsuarios.Checked Then
         Me.cmbUsuarios.Focus()
      Else
         Me.cmbUsuarios.SelectedIndex = -1
      End If
   End Sub

   Private Sub tsmiAExcel_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         Dim nombreWS As String = Me.Text
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Dim wb As Infragistics.Documents.Excel.Workbook = New Infragistics.Documents.Excel.Workbook(Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
               wb.Worksheets.Add(nombreWS)
               wb.Worksheets(nombreWS).Rows(0).Cells(0).Value = Me.Text
               Me.UltraGridExcelExporter1.Export(Me.ugDatos, wb.Worksheets(nombreWS), 2, 0)
               wb.Save(Me.sfdExportar.FileName)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As System.Object, e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.ugDatos, Me.sfdExportar.FileName, Infragistics.Win.UltraWinGrid.DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub tsbPreferencias_Click(sender As System.Object, e As System.EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDatos, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As System.Object, e As System.EventArgs) Handles tsbImprimir.Click
      Try
         Dim pre As PreGridPrint = New PreGridPrint(Me.ugDatos, DirectCast(Me.ugDatos.DataSource, DataTable), Me.Text, "")
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDatos_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles ugDatos.DoubleClickCell
      Try
         Dim en As Entidades.ClienteDeuda = New Reglas.ClientesDeudas().GetUno(Long.Parse(Me.ugDatos.ActiveRow.Cells("IdCliente").Value.ToString()), 0)



         Me.Cursor = Cursors.Default
         Dim da As MutualDetalle = New MutualDetalle(en)
         da.StateForm = Eniac.Win.StateForm.Actualizar

         da.ShowDialog()

         If da.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.CargarDatosGrilla()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugDetalle_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugDatos.AfterRowFilterChanged
      Try
         Me.tssRegistros.Text = Me.ugDatos.Rows.FilteredInRowCount.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub CargarValoresIniciales()

      Me.cmbUsuarios.SelectedIndex = -1
      Me.dtpFechaDesde.Value = Date.Now
      Me.chbTipoDeNotificacion.Checked = True
      Me.cmbTipoDeNotificacion.SelectedValue = 2   'Llamado saliente

      Me.cmbUsuarios.Focus()

   End Sub

   Private Sub CargarDatosGrilla()
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim fechaDesde As DateTime = Nothing
         Dim fechaHasta As DateTime = Nothing
         Dim idTipoNotificacion As Integer = 0
         Dim IdUsuarioAlta As String = String.Empty
         Dim idCategoriaNovedad As Integer = 0
         Dim IdCategoria As Integer = 0

         Dim reg As Reglas.CRMNovedades = New Reglas.CRMNovedades()

         Dim cantFiltros As Integer = 0
         Dim TelefonoTenedor As String

         If Me.dtpFechaDesde.Checked Then
            cantFiltros = cantFiltros + 1
            fechaDesde = Me.dtpFechaDesde.Value
         End If
         If Me.dtpFechaHasta.Checked Then
            cantFiltros = cantFiltros + 1
            fechaHasta = Me.dtpFechaHasta.Value
         End If

         If Me.chbTipoDeNotificacion.Checked Then
            idCategoriaNovedad = Int32.Parse(Me.cmbTipoDeNotificacion.SelectedValue.ToString())
         End If

         If Me.chbUsuarios.Checked Then
            IdUsuarioAlta = Me.cmbUsuarios.SelectedValue.ToString()
         End If

         Dim Gestiones As DataTable

         Gestiones = reg.GetGestionesInforme(fechaDesde, fechaHasta, "GESTIONES", IdUsuarioAlta,
                                    idCategoriaNovedad, IdCategoria)

         Me.ugDatos.DataSource = Gestiones

         Me.FormatearGrilla()

      Catch ex As Exception
         Throw
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Public Sub FormatearGrilla()
      ugDatos.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow
      ugDatos.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Equals
      ugDatos.DisplayLayout.Override.FilterOperatorLocation = Infragistics.Win.UltraWinGrid.FilterOperatorLocation.AboveOperand
      ugDatos.DisplayLayout.Override.FilterRowAppearance.BackColor = Color.AntiqueWhite
      ugDatos.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True

      ugDatos.DisplayLayout.UseFixedHeaders = True
      ugDatos.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None

      With Me.ugDatos.DisplayLayout.Bands(0)

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

         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString()), "Realizado", pos, 120, HAlign.Center, hidden:=True)
         .Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString() + "_Fecha"), "Fecha", pos, 80, HAlign.Center)
         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString() + "_Hora"), "Hora", pos, 40, HAlign.Center)


         'Oculta
         'FormatearColumna(.Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()), "Código", 4, 80, HAlign.Right)
         FormatearColumna(.Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()), "Nombre Cliente", pos, 270)
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
         'FormatearColumna(.Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()), "Nombre de Fantasia", pos, 200)
         '.Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains

         FormatearColumna(.Columns("NombreCategoriaCliente"), "Categoria Cliente", pos, 120)

         FormatearColumna(.Columns(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()), "Categoria", pos, 200)

         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.Descripcion.ToString()), "Descripción", pos, 300)
         .Columns(Entidades.CRMNovedad.Columnas.Descripcion.ToString()).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains


         'FormatearColumna(.Columns(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()), "Estado", pos, 80)

         'FormatearColumna(.Columns(Entidades.CRMEstadoNovedad.Columnas.Finalizado.ToString()), "Fin.", pos, 40, HAlign.Center)

         'FormatearColumna(.Columns("HorasFinalizacion"), "Tiempo Resolución", pos, 70, HAlign.Right)

         'FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdUsuarioAsignado.ToString()), "Usuario Asignado", pos, 70)

         '  FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.Priorizado.ToString()), "Prioridad", pos, 70)



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

         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdUsuarioAlta.ToString()), "Usuario Alta", pos, 80)


      End With

   End Sub
   Private Sub chbTipoDeNotificacion_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbTipoDeNotificacion.CheckedChanged
      Me.cmbTipoDeNotificacion.Enabled = Me.chbTipoDeNotificacion.Checked
      If Me.chbTipoDeNotificacion.Checked Then
         Me.cmbTipoDeNotificacion.Focus()
      End If
   End Sub

#End Region

End Class