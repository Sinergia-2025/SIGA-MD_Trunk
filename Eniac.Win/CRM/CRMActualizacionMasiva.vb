Public Class CRMActualizacionMasiva
   Implements IConParametros

#Region "Propiedades"
   Public ReadOnly Property TipoNovedad() As Entidades.CRMTipoNovedad
      Get
         Return DirectCast(cmbTipoNovedad.SelectedItem, Entidades.CRMTipoNovedad)
      End Get
   End Property

   Private Property Modo As Eniac.Entidades.Cliente.ModoClienteProspecto?
   Public Property TipoNovedadParametro As Entidades.CRMTipoNovedad
#End Region

#Region "Campos"
   Private Const selecColumnName As String = "selec"

   Private _publicos As Publicos
   Private _cargando As Boolean = True
   Private _usr As Entidades.Usuario
   Private _CRMMuestraSolapaExtrasSinergia As Boolean

   Private _dtDetalle As DataTable
   Private _listasDeVersionScript As List(Of Entidades.VersionScript)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try

         _listasDeVersionScript = New List(Of Entidades.VersionScript)()

         _publicos = New Publicos()

         chbFecha.Checked = True
         chbFecha.Checked = False
         tsbActualizar.Visible = False
         ToolStripSeparator2.Visible = False
         tsbGenerarVersion.Visible = False
         ToolStripSeparator6.Visible = False

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         cmbFinalizado.Items.Insert(0, "TODOS")
         cmbFinalizado.Items.Insert(1, "SI")
         cmbFinalizado.Items.Insert(2, "NO")
         cmbFinalizado.SelectedIndex = 2

         _publicos.CargaComboDesdeEnum(cmbTodos, GetType(Reglas.Publicos.TodosEnum))

         _publicos.CargaComboUsuarios(cmbUsuarioAlta)

         _publicos.CargaComboUsuarios(cmbIdUsuarioAsignado)
         _publicos.CargaComboUsuarios(cmbAsignadoANuevo)

         _publicos.CargaComboDesdeEnum(cmbPriorizado, GetType(Entidades.Publicos.SiNoTodos))
         _publicos.CargaComboDesdeEnum(cmbPriorizadoNuevo, GetType(Entidades.Publicos.SiNo))
         _publicos.CargaComboDesdeEnum(cmbPriorizadoVersion, GetType(Entidades.Publicos.SiNo))
         _publicos.CargaComboDesdeEnum(cmbRequiereTesteoNuevo, GetType(Entidades.Publicos.SiNo))

         If cmbIdUsuarioAsignado.DataSource IsNot Nothing AndAlso TypeOf (cmbIdUsuarioAsignado.DataSource) Is List(Of Entidades.Usuario) Then
            Dim lista = DirectCast(cmbIdUsuarioAsignado.DataSource, List(Of Entidades.Usuario))
            Dim usuario = New Entidades.Usuario()
            usuario.Id = "-"
            usuario.Usuario = "-"
            usuario.Nombre = String.Empty
            lista.Insert(0, usuario)
            'For Each usr As Entidades.Usuario In lista
            '   usr.Id = usr.Id.ToLower()
            '   usr.Usuario = usr.Usuario.ToLower()
            'Next

            cmbIdUsuarioAsignado.DataSource = Nothing
            cmbIdUsuarioAsignado.DisplayMember = "Nombre"
            cmbIdUsuarioAsignado.ValueMember = "Usuario"
            cmbIdUsuarioAsignado.DataSource = lista
         End If

         If TipoNovedadParametro IsNot Nothing Then
            _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad, TipoNovedadParametro.IdTipoNovedad)

         Else
            _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad)
         End If
         cmbTipoNovedad.SelectedIndex = 0

         _publicos.CargaComboZonasGeograficas(cmbAplicacion)
         _publicos.CargaComboZonasGeograficas(cmbAplicacionNueva)

         cmbCategoriasNovedad.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True, TipoNovedad.IdTipoNovedad)

         If TipoNovedadParametro IsNot Nothing Then cmbTipoNovedad.SelectedValue = TipoNovedadParametro.IdTipoNovedad
         _usr = New Reglas.Usuarios().GetUno(actual.Nombre)

         _cargando = False
         CambiaTipoNovedad()

         cmbRevisionAdministrativa.Text = "TODAS"

         Dim TienePermisoParaVerOtrosUsuarios As Boolean = New Reglas.Usuarios().TienePermisos(TipoNovedad.IdTipoNovedad + "-VerOtrosUsuarios")

         'GAR: 06/04/2023 - Lo cambio de Parametros porque lo separamos para Servicio Tecnico.
         '_CRMMuestraSolapaMasInfo = Reglas.Publicos.CRMMuestraSolapaMasInfo
         _CRMMuestraSolapaExtrasSinergia = Reglas.Publicos.ExtrasSinergia

         chbVersionNuevo.Visible = _CRMMuestraSolapaExtrasSinergia
         txtVersionNuevo.Visible = _CRMMuestraSolapaExtrasSinergia

         chbVersionFechaNuevo.Visible = _CRMMuestraSolapaExtrasSinergia
         dtpVersionFechaNuevo.Visible = _CRMMuestraSolapaExtrasSinergia

         chbFuncion.Visible = _CRMMuestraSolapaExtrasSinergia
         bscCodigoFuncion.Visible = _CRMMuestraSolapaExtrasSinergia
         bscFuncion.Visible = _CRMMuestraSolapaExtrasSinergia

         chbFuncionNuevo.Visible = _CRMMuestraSolapaExtrasSinergia
         bscCodigoFuncionNuevo.Visible = _CRMMuestraSolapaExtrasSinergia
         bscFuncionNuevo.Visible = _CRMMuestraSolapaExtrasSinergia

         If Not tbcVersion.TabPages.Contains(tbpEnviar) Then
            tbcVersion.TabPages.Add(tbpEnviar)
         End If

         ugScripts.DataSource = _listasDeVersionScript

         If Not TienePermisoParaVerOtrosUsuarios Then
            chbAsignadoA.Checked = True
            chbAsignadoA.Enabled = False
            cmbIdUsuarioAsignado.SelectedValue = _usr.Id
            cmbIdUsuarioAsignado.Enabled = False

            'Dim lista2 As List(Of Entidades.Usuario) = DirectCast(cmbIdUsuarioAsignado.DataSource, List(Of Entidades.Usuario))
            'lista2.Clear()
            'lista2.Add(usr)
            'cmbIdUsuarioAsignado.DisplayMember = actual.Nombre
            'cmbIdUsuarioAsignado.ValueMember = actual.Nombre
            'cmbIdUsuarioAsignado.DataSource = lista2

         End If
         tbcVersion.TabPages.Remove(tbpVersion)
         tbcVersion.TabPages.Remove(tbpEnviar)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub chbProyectoNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbProyectoNuevo.CheckedChanged
      Try
         bscCodigoProyectoNuevo.Enabled = chbProyectoNuevo.Checked
         bscProyectoNuevo.Enabled = bscCodigoProyectoNuevo.Enabled
         If Not chbProyectoNuevo.Checked Then
            bscProyectoNuevo.Text = String.Empty
            bscCodigoProyectoNuevo.Text = String.Empty
         Else
            bscCodigoProyectoNuevo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProyecto.CheckedChanged
      Try
         bscCodigoProyecto.Enabled = chbProyecto.Checked
         bscProyecto.Enabled = bscCodigoProyecto.Enabled
         If Not chbProyecto.Checked Then
            bscCodigoProyecto.Text = String.Empty
            bscProyecto.Text = String.Empty
         Else
            bscCodigoProyecto.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbFuncion_CheckedChanged(sender As Object, e As EventArgs) Handles chbFuncion.CheckedChanged
      Me.bscCodigoFuncion.Enabled = Me.chbFuncion.Checked
      Me.bscFuncion.Enabled = Me.chbFuncion.Checked

      Me.bscCodigoFuncion.Text = String.Empty
      Me.bscCodigoFuncion.Tag = Nothing
      Me.bscFuncion.Text = String.Empty

      Me.bscCodigoFuncion.Focus()
   End Sub
   Private Sub bscCodigoFuncion_BuscadorClick() Handles bscCodigoFuncion.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaFunciones2(Me.bscCodigoFuncion)
         Me.bscCodigoFuncion.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(bscCodigoFuncion.Text, String.Empty)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   Private Sub bscCodigoFuncion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoFuncion.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosFuncion(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscFuncion_BuscadorClick() Handles bscFuncion.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaFunciones2(Me.bscFuncion)
         Me.bscFuncion.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(String.Empty, Me.bscFuncion.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscFuncion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscFuncion.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosFuncion(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         If chbProspecto.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            Dim sModo As String = String.Empty
            If Modo.HasValue Then
               sModo = Modo.ToString()
            Else
               If TipoNovedadTiene("PROVEEDORES") Then
                  sModo = "Proveedor"
               End If
            End If
            MessageBox.Show(String.Format("ATENCION: NO seleccionó un {0} aunque activó ese Filtro.", Modo.ToString()), Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         If chbNumero.Checked And txtNumero.Text = "0" Then
            MessageBox.Show("ATENCION: No ingreso un número de Novedad aunque activó ese Filtro.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         If chbAplicacion.Checked And cmbAplicacion.SelectedIndex < 0 Then
            MessageBox.Show("ATENCION: No ingreso una aplicación aunque activó ese Filtro.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         If chbProyecto.Checked AndAlso (Not bscCodigoProyecto.Selecciono OrElse Not bscProyecto.Selecciono) Then
            ShowMessage("ATENCION: No ingreso un número de Proyecto aunque activó ese Filtro.")
            Exit Sub
         End If

         If chbFuncion.Checked AndAlso (Not bscCodigoFuncion.Selecciono OrElse Not bscFuncion.Selecciono) Then
            ShowMessage("ATENCION: No ingreso una Funcion aunque activó ese Filtro.")
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         Cursor = Cursors.WaitCursor

         CargaGrillaDetalle()

         If TipoNovedadParametro IsNot Nothing AndAlso TipoNovedadParametro.UnidadDeMedida <> "%" Then
            CargarColumnasASumar()
         End If

         cmbTodos.SelectedIndex = 0
         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         tssRegistros.Text = "0 Registros"
         ShowError(ex)
      Finally
         Cursor = Cursors.Default
      End Try

   End Sub
   Private Sub cmbTipoNovedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoNovedad.SelectedIndexChanged
      TryCatched(
         Sub()
            CambiaTipoNovedad()
            AgregarTab()
         End Sub)
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub tsbActualizar_Click(sender As Object, e As EventArgs) Handles tsbActualizar.Click
      TryCatched(
         Sub()
            If tsbActualizar.Visible = True Then
               If Not ugDetalle.Rows.Count > 0 Then Exit Sub
               Actualizar()
            End If
         End Sub)
   End Sub

   Private Sub tsbGenerarVersion_Click(sender As Object, e As EventArgs) Handles tsbGenerarVersion.Click
      TryCatched(
         Sub()
            If tsbGenerarVersion.Visible = True AndAlso chbAplicacion.Checked Then
               GenerarVersion()
            End If
         End Sub)
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
         Sub()
            'Pendiente ajustar los filtros
            Dim filtros = "Filtros: Rango de Fechas: desde el " & dtpDesde.Text & " hasta el " & dtpHasta.Text
            If cmbUsuarioAlta.Enabled Then
               filtros = filtros & " / Usuario: " & cmbUsuarioAlta.SelectedValue.ToString()
            End If

            ugDetalle.Imprimir(Text, filtros)
         End Sub)
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, ""))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, ""))
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs)
      UltraGridPrintDocument1.Footer.TextRight = "Página: " + UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub
#End Region


#Region "Eventos Filtros"
   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      Try
         chkMesCompleto.Enabled = chbFecha.Checked
         dtpDesde.Enabled = chbFecha.Checked
         dtpHasta.Enabled = chbFecha.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         ShowError(ex)

      End Try

   End Sub

   Private Sub chbPrioridad_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrioridad.CheckedChanged
      Try
         Me.cmbPrioridadNovedad.Enabled = Me.chbPrioridad.Checked
         If Not Me.chbPrioridad.Checked Then
            Me.cmbPrioridadNovedad.SelectedIndex = -1
         Else
            If Me.cmbPrioridadNovedad.Items.Count > 0 Then
               Me.cmbPrioridadNovedad.SelectedIndex = 0
            End If
            Me.cmbPrioridadNovedad.Focus()
         End If


      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   'Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs)

   '   Try
   '      Me.cmbCategoriaNovedad.Enabled = Me.chbCategoria.Checked
   '      If Not Me.chbCategoria.Checked Then
   '         Me.cmbCategoriaNovedad.SelectedIndex = -1
   '      Else
   '         If Me.cmbCategoriaNovedad.Items.Count > 0 Then
   '            Me.cmbCategoriaNovedad.SelectedIndex = 0
   '         End If
   '         Me.cmbCategoriaNovedad.Focus()
   '      End If

   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try

   'End Sub

   Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstado.CheckedChanged
      Try
         Me.cmbEstadoNovedad.Enabled = Me.chbEstado.Checked
         If Not Me.chbEstado.Checked Then
            Me.cmbEstadoNovedad.SelectedIndex = -1
         Else
            If Me.cmbEstadoNovedad.Items.Count > 0 Then
               Me.cmbEstadoNovedad.SelectedIndex = 0
            End If
            Me.cmbEstadoNovedad.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbAsignadoA_CheckedChanged(sender As Object, e As EventArgs) Handles chbAsignadoA.CheckedChanged
      Try
         Me.cmbIdUsuarioAsignado.Enabled = Me.chbAsignadoA.Checked
         If Not Me.chbAsignadoA.Checked Then
            Me.cmbIdUsuarioAsignado.SelectedIndex = -1
         Else
            If Me.cmbIdUsuarioAsignado.Items.Count > 0 Then
               Me.cmbIdUsuarioAsignado.SelectedIndex = 0
            End If
            Me.cmbIdUsuarioAsignado.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbMedio_CheckedChanged(sender As Object, e As EventArgs) Handles chbMedio.CheckedChanged
      Try
         Me.cmbMedio.Enabled = Me.chbMedio.Checked
         If Not Me.chbMedio.Checked Then
            Me.cmbMedio.SelectedIndex = -1
         Else
            If Me.cmbMedio.Items.Count > 0 Then
               Me.cmbMedio.SelectedIndex = 0
            End If
            Me.cmbMedio.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbMetodoResolulcion_CheckedChanged(sender As Object, e As EventArgs) Handles chbMetodoResolulcion.CheckedChanged
      TryCatched(Sub() chbMetodoResolulcion.FiltroCheckedChanged(cmbMetodoResolulcion))
   End Sub

   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      Try

         Me.txtNumero.Enabled = Me.chbNumero.Checked
         If Not Me.chbNumero.Checked Then
            Me.txtNumero.Text = ""
         Else
            Me.txtNumero.Text = "0"
            Me.txtNumero.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbProspecto.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbProspecto.Checked
      Me.bscCliente.Enabled = Me.chbProspecto.Checked


      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      Try
         Me.cmbUsuarioAlta.Enabled = Me.chbUsuario.Checked
         If Not Me.chbUsuario.Checked Then
            Me.cmbUsuarioAlta.SelectedIndex = -1
         Else
            If Me.cmbUsuarioAlta.Items.Count > 0 Then
               Me.cmbUsuarioAlta.SelectedIndex = 0
            End If
         End If
         Me.cmbUsuarioAlta.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbAplicacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbAplicacion.CheckedChanged
      Try
         Me.cmbAplicacion.Enabled = Me.chbAplicacion.Checked
         If Not Me.chbAplicacion.Checked Then
            Me.cmbAplicacion.SelectedIndex = -1
            AgregarTab()
         Else
            If Me.cmbAplicacion.Items.Count > 0 Then
               Me.cmbAplicacion.SelectedIndex = 2
               AgregarTab()
            End If
         End If
         Me.cmbAplicacion.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbVersion_CheckedChanged(sender As Object, e As EventArgs) Handles chbVersion.CheckedChanged
      Try
         Me.cmbVersion.Enabled = Me.chbVersion.Checked
         If Not Me.chbVersion.Checked Then
            Me.cmbVersion.SelectedIndex = -1
         Else
            If Me.cmbVersion.Items.Count > 0 Then
               Me.cmbVersion.SelectedIndex = 0
            End If
         End If
         Me.cmbVersion.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbAplicacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAplicacion.SelectedIndexChanged
      Try
         If chbAplicacion.Checked Then
            chbVersion.Enabled = True
            _publicos.CargaComboVersiones(cmbVersion, cmbAplicacion.SelectedValue.ToString())
         Else
            chbVersion.Checked = False
            chbVersion.Enabled = False
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Eventos Actualizacion"
   Private Sub chbEstadoNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstadoNuevo.CheckedChanged
      Try
         Me.cmbEstadoNuevo.Enabled = Me.chbEstadoNuevo.Checked
         If Not Me.chbEstadoNuevo.Checked Then
            Me.cmbEstadoNuevo.SelectedIndex = -1
         Else
            If Me.cmbEstadoNuevo.Items.Count > 0 Then
               Me.cmbEstadoNuevo.SelectedIndex = 0
            End If
            Me.cmbEstadoNuevo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbPrioridadNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrioridadNuevo.CheckedChanged
      Try
         Me.cmbPrioridadNovedadNuevo.Enabled = Me.chbPrioridadNuevo.Checked
         If Not Me.chbPrioridadNuevo.Checked Then
            Me.cmbPrioridadNovedadNuevo.SelectedIndex = -1
         Else
            If Me.cmbPrioridadNovedadNuevo.Items.Count > 0 Then
               Me.cmbPrioridadNovedadNuevo.SelectedIndex = 0
            End If
            Me.cmbPrioridadNovedadNuevo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbRequiereTesteoNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbRequiereTesteoNuevo.CheckedChanged
      TryCatched(Sub() chbRequiereTesteoNuevo.FiltroCheckedChanged(cmbRequiereTesteoNuevo))
   End Sub

   Private Sub chbPriorizadoNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbPriorizadoNuevo.CheckedChanged
      Try
         Me.cmbPriorizadoNuevo.Enabled = Me.chbPriorizadoNuevo.Checked
         If Not Me.chbPriorizadoNuevo.Checked Then
            Me.cmbPriorizadoNuevo.SelectedIndex = -1
         Else
            If Me.cmbPriorizadoNuevo.Items.Count > 0 Then
               Me.cmbPriorizadoNuevo.SelectedIndex = 0
            End If
            Me.cmbPriorizadoNuevo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbAsignadoANuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbAsignadoANuevo.CheckedChanged
      Try
         Me.cmbAsignadoANuevo.Enabled = Me.chbAsignadoANuevo.Checked
         If Not Me.chbAsignadoANuevo.Checked Then
            Me.cmbAsignadoANuevo.SelectedIndex = -1
         Else
            If Me.cmbAsignadoANuevo.Items.Count > 0 Then
               Me.cmbAsignadoANuevo.SelectedIndex = 0
            End If
            Me.cmbAsignadoANuevo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbAvanceNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbAvanceNuevo.CheckedChanged
      Try
         Me.txtAvanceNuevo.Enabled = Me.chbAvanceNuevo.Checked
         If Not Me.chbAvanceNuevo.Checked Then
            Me.txtAvanceNuevo.Text = String.Empty
         Else
            Me.txtAvanceNuevo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbVersionNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbVersionNuevo.CheckedChanged
      Try
         Me.txtVersionNuevo.Enabled = Me.chbVersionNuevo.Checked
         If Not Me.chbVersionNuevo.Checked Then
            Me.txtVersionNuevo.Text = String.Empty
         Else
            txtVersionNuevo.Text = String.Format("{0:yy}.{0:MM}.{0:dd}.1", Today)
            Me.txtVersionNuevo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbVersionFechaNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbVersionFechaNuevo.CheckedChanged
      Try
         Me.dtpVersionFechaNuevo.Enabled = Me.chbVersionFechaNuevo.Checked
         If Not Me.chbVersionFechaNuevo.Checked Then
            Me.dtpVersionFechaNuevo.Value = Now
         Else
            Me.dtpVersionFechaNuevo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbMedioNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbMedioNuevo.CheckedChanged
      Try
         Me.cmbMedioNuevo.Enabled = Me.chbMedioNuevo.Checked
         If Not Me.chbMedioNuevo.Checked Then
            Me.cmbMedioNuevo.SelectedIndex = -1
         Else
            If Me.cmbMedioNuevo.Items.Count > 0 Then
               Me.cmbMedioNuevo.SelectedIndex = 0
            End If
            Me.cmbMedioNuevo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbMetodoNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbMetodoNuevo.CheckedChanged
      TryCatched(Sub() chbMetodoNuevo.FiltroCheckedChanged(cmbMetodoNuevo))
   End Sub

   Private Sub chbColorNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbColorNuevo.CheckedChanged
      Try
         Me.pnlColorNuevo.Enabled = Me.chbColorNuevo.Checked
         btnColorNuevo.Visible = chbColorNuevo.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnColorNuevo_Click(sender As Object, e As EventArgs) Handles btnColorNuevo.Click
      Try
         If btnColorNuevo.BackColor.ToArgb().Equals(SystemColors.Control.ToArgb()) Then
            btnColorNuevo.BackColor = Color.Green
         ElseIf btnColorNuevo.BackColor.ToArgb().Equals(Color.Green.ToArgb()) Then
            btnColorNuevo.BackColor = Color.Yellow
         ElseIf btnColorNuevo.BackColor.ToArgb().Equals(Color.Yellow.ToArgb()) Then
            btnColorNuevo.BackColor = Color.Red
         ElseIf btnColorNuevo.BackColor.ToArgb().Equals(Color.Red.ToArgb()) Then
            btnColorNuevo.BackColor = SystemColors.Control
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Nothing, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

#Region "Eventos Busquedas Foraneas"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick

      Dim codigoCliente As Long = -1
      Try
         If Modo.HasValue Then
            If Modo.Value = Entidades.Cliente.ModoClienteProspecto.Cliente Then
               Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
            Else
               Me._publicos.PreparaGrillaProspectos2(Me.bscCodigoCliente)
            End If
            Dim oClientes As Reglas.Clientes = New Reglas.Clientes(Modo.Value)
            If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
               codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
            End If
            Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
         Else
            If TipoNovedadTiene("PROVEEDORES") Then
               Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoCliente)
               Dim oClientes As Reglas.Proveedores = New Reglas.Proveedores()
               If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
                  codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
               End If
               Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True)
            End If
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            If Modo.HasValue Then
               Me.CargarDatosCliente(e.FilaDevuelta, True)
            Else
               If TipoNovedadTiene("PROVEEDORES") Then
                  Me.CargarDatosProveedor(e.FilaDevuelta)
               End If
            End If
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         If Modo.HasValue Then
            If Modo.Value = Entidades.Cliente.ModoClienteProspecto.Cliente Then
               Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
            Else
               Me._publicos.PreparaGrillaProspectos2(Me.bscCliente)
            End If
         Else
            If TipoNovedadTiene("PROVEEDORES") Then
               Me._publicos.PreparaGrillaProveedores2(Me.bscCliente)
            End If
         End If
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes(Modo.Value)
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            If Modo.HasValue Then
               Me.CargarDatosCliente(e.FilaDevuelta, True)
            Else
               If TipoNovedadTiene("PROVEEDORES") Then
                  Me.CargarDatosProveedor(e.FilaDevuelta)
               End If
            End If
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region


#Region "Eventos Grilla"

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      If e.Row IsNot Nothing And e.Row.Cells.Exists(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1") Then
         Dim color As Color = SystemColors.Control

         If Not String.IsNullOrWhiteSpace(e.Row.Cells(Entidades.CRMNovedad.Columnas.BanderaColor.ToString()).Value.ToString()) Then
            color = Drawing.Color.FromArgb(Integer.Parse(e.Row.Cells(Entidades.CRMNovedad.Columnas.BanderaColor.ToString()).Value.ToString()))
            e.Row.Cells(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").Appearance.BackColor = color
            e.Row.Cells(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").Appearance.ForeColor = color
            e.Row.Cells(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").ActiveAppearance.BackColor = color
            e.Row.Cells(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").ActiveAppearance.ForeColor = color

            Dim nombreColor As String = Entidades.CRMNovedad.NombreBanderaColor(color)
            e.Row.Cells(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").Value = nombreColor
         End If

         If IsNumeric(e.Row.Cells("ColorEstado").Value) Then
            color = Drawing.Color.FromArgb(Integer.Parse(e.Row.Cells("ColorEstado").Value.ToString()))
            e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).Appearance.BackColor = color
            'e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).Appearance.ForeColor = color
            e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).ActiveAppearance.BackColor = color
            'e.Row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).ActiveAppearance.ForeColor = color

         End If
      End If

      Try
         e.Row.Cells("Ver").Value = "..."
         e.Row.Cells("Ver").ButtonAppearance.TextHAlign = HAlign.Center
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton

      Try
         Me.Cursor = Cursors.WaitCursor
         Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Dim oNovedad As Reglas.CRMNovedades = New Reglas.CRMNovedades()

            Dim novedad As Entidades.CRMNovedad = oNovedad.GetUno(dr(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()).ToString(),
                                                                  dr(Entidades.CRMNovedad.Columnas.Letra.ToString()).ToString(),
                                                                  Short.Parse(Me.ugDetalle.ActiveRow.Cells(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()).Value.ToString()),
                                                                  Long.Parse(Me.ugDetalle.ActiveRow.Cells(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()).Value.ToString()))

            Dim oNovImp As CRMNovedadesImpresion = New CRMNovedadesImpresion(novedad)

            oNovImp.ImprimirNovedad()

         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
#End Region

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugDetalle.MarcarDesmarcar(cmbTodos, selecColumnName), Sub(owner) AgregarNovedadesSeleccionadas())
   End Sub
#End Region

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub chbAplicacionNueva_CheckedChanged(sender As Object, e As EventArgs) Handles chbAplicacionNueva.CheckedChanged
      Try
         Me.cmbAplicacionNueva.Enabled = Me.chbAplicacionNueva.Checked
         If Not Me.chbAplicacionNueva.Checked Then
            Me.cmbAplicacionNueva.SelectedIndex = -1
         Else
            If Me.cmbAplicacionNueva.Items.Count > 0 Then
               Me.cmbAplicacionNueva.SelectedIndex = 2
            End If
         End If
         Me.cmbAplicacionNueva.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbCategoriaNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriaNuevo.CheckedChanged
      Try
         Me.cmbCategoriaNovedadNuevo.Enabled = Me.chbCategoriaNuevo.Checked
         If Not Me.chbCategoriaNuevo.Checked Then
            Me.cmbCategoriaNovedadNuevo.SelectedIndex = -1
         Else
            If Me.cmbCategoriaNovedadNuevo.Items.Count > 0 Then
               Me.cmbCategoriaNovedadNuevo.SelectedIndex = 0
            End If
            Me.cmbCategoriaNovedadNuevo.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub chbCliente_CheckedChanged_1(sender As Object, e As EventArgs) Handles chbClienteNuevo.CheckedChanged
      Me.bscCodClienteNuevo.Enabled = Me.chbClienteNuevo.Checked
      Me.bscNombreClienteNuevo.Enabled = Me.chbClienteNuevo.Checked

      Me.bscCodClienteNuevo.Text = String.Empty
      Me.bscCodClienteNuevo.Tag = Nothing
      Me.bscNombreClienteNuevo.Text = String.Empty

      Me.bscCodClienteNuevo.Focus()
   End Sub

   Private Sub bscCodClienteNuevo_BuscadorClick() Handles bscCodClienteNuevo.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         If Modo.HasValue Then
            If Modo.Value = Entidades.Cliente.ModoClienteProspecto.Cliente Then
               Me._publicos.PreparaGrillaClientes2(Me.bscCodClienteNuevo)
            Else
               Me._publicos.PreparaGrillaProspectos2(Me.bscCodClienteNuevo)
            End If
            Dim oClientes As Reglas.Clientes = New Reglas.Clientes(Modo.Value)
            If Me.bscCodClienteNuevo.Text.Trim.Length > 0 Then
               codigoCliente = Long.Parse(Me.bscCodClienteNuevo.Text.Trim())
            End If
            Me.bscCodClienteNuevo.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodClienteNuevo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodClienteNuevo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            If Modo.HasValue Then
               Me.CargarDatosCliente(e.FilaDevuelta, False)
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscNombreClienteNuevo_BuscadorClick() Handles bscNombreClienteNuevo.BuscadorClick
      Try
         If Modo.HasValue Then
            If Modo.Value = Entidades.Cliente.ModoClienteProspecto.Cliente Then
               Me._publicos.PreparaGrillaClientes2(Me.bscNombreClienteNuevo)
            Else
               Me._publicos.PreparaGrillaProspectos2(Me.bscNombreClienteNuevo)
            End If
         End If
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes(Modo.Value)
         Me.bscNombreClienteNuevo.Datos = oClientes.GetFiltradoPorNombre(Me.bscNombreClienteNuevo.Text.Trim(), False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscNombreClienteNuevo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreClienteNuevo.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            If Modo.HasValue Then
               Me.CargarDatosCliente(e.FilaDevuelta, False)
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub BtnProbarFTP_Click(sender As Object, e As EventArgs) Handles btnProbarFTP.Click
      Try
         Dim ftp As Reglas.IFtp = Reglas.FtpFactory.Crear()
         Dim carpetaRemotaFTP As String = Reglas.Publicos.FTPCarpetaRemota

         ftp.TestFtpConfiguration(carpetaRemotaFTP)

         ShowMessage("Conexión realizada con exito!")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub HabilitarControlers(habilitar As Boolean)
      tbcVersion.Enabled = habilitar
      ugDetalle.Enabled = habilitar
      cmbTodos.Enabled = habilitar
      btnTodos.Enabled = habilitar

      For Each item As ToolStripItem In tstBarra.Items
         item.Enabled = habilitar
      Next

      ControlBox = habilitar
   End Sub

   Private Sub chbFuncionNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbFuncionNuevo.CheckedChanged
      Me.bscCodigoFuncionNuevo.Enabled = Me.chbFuncionNuevo.Checked
      Me.bscFuncionNuevo.Enabled = Me.chbFuncionNuevo.Checked

      Me.bscCodigoFuncionNuevo.Text = String.Empty
      Me.bscCodigoFuncionNuevo.Tag = Nothing
      Me.bscFuncionNuevo.Text = String.Empty

      Me.bscCodigoFuncionNuevo.Focus()
   End Sub
   Private Sub bscCodigoFuncionNuevo_BuscadorClick() Handles bscCodigoFuncionNuevo.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaFunciones2(Me.bscCodigoFuncionNuevo)
         Me.bscCodigoFuncionNuevo.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(bscCodigoFuncionNuevo.Text, String.Empty)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   Private Sub bscCodigoFuncionNuevo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoFuncionNuevo.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosFuncionNuevo(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscFuncionNuevo_BuscadorClick() Handles bscFuncionNuevo.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaFunciones2(Me.bscFuncionNuevo)
         Me.bscFuncionNuevo.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(String.Empty, Me.bscFuncionNuevo.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscFuncionNuevo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscFuncionNuevo.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosFuncionNuevo(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnSeleccionarScript_Click(sender As Object, e As EventArgs) Handles btnSeleccionarScript.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         If ofgScript.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim oFilaName As String() = ofgScript.FileNames.OrderBy(Function(x) x).ToArray()
            For Each oFila As String In oFilaName
               Dim NombreArchivo As String = New IO.FileInfo(oFila).Name.ToString()
               If Not existeScript(NombreArchivo) Then
                  Dim versionScript As Entidades.VersionScript = New Entidades.VersionScript()
                  versionScript.Script = IO.File.ReadAllText(oFila).ToString()
                  versionScript.Nombre = New IO.FileInfo(oFila).Name.ToString()
                  versionScript.Orden = If(_listasDeVersionScript.Count = 0, 0, _listasDeVersionScript.Max(Function(v) v.Orden)) + 1
                  versionScript.Aplicacion.IdAplicacion = Me.cmbAplicacion.SelectedValue.ToString()
                  versionScript.Version.NroVersion = Me.txtVersionFinal.Text
                  versionScript.Obligatorio = True
                  _listasDeVersionScript.Add(versionScript)
               End If
            Next

            ugScripts.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.ReloadData)
            tssRegistrosScript.Text = ugScripts.Rows.Count.ToString() & " - Script de Versión"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Function SubirScriptVersion(listasDeVersionScript As IEnumerable(Of Entidades.VersionScript)) As String
      Try
         If listasDeVersionScript.Count > 0 Then
            Dim oSincronizar = New Reglas.SubirScriptVersion()
            oSincronizar.SincronizarScriptsdeVersion(listasDeVersionScript)
         End If
      Catch ex As Exception
         Return String.Format("Error en Subir Script de versión {0}", ex.Message)
      End Try
      Return String.Empty
   End Function

   Private Function existeScript(nombreScript As String) As Boolean
      Dim oReg As Reglas.VersionesScripts = New Reglas.VersionesScripts()
      Dim validaExisteEnVersion As String = String.Empty
      For Each ent As Entidades.VersionScript In _listasDeVersionScript
         If ent.Nombre = nombreScript Then
            Throw New Exception(String.Format("El siguiente Script {0} ya fue ingresado a la grilla.", nombreScript))
         End If
      Next
      validaExisteEnVersion = oReg.ExisteNombre(Me.cmbAplicacion.SelectedValue.ToString(), nombreScript)
      If Not String.IsNullOrWhiteSpace(validaExisteEnVersion) Then
         Throw New Exception(validaExisteEnVersion)
      End If
      Return False
   End Function

   Private Sub btnEliminarScript_Click(sender As Object, e As EventArgs) Handles btnEliminarScript.Click
      Try
         Dim dr As Entidades.VersionScript = ugScripts.FilaSeleccionada(Of Entidades.VersionScript)()
         If dr IsNot Nothing Then
            If ShowPregunta("¿Desea eliminar el Script seleccionado?") = Windows.Forms.DialogResult.Yes Then
               _listasDeVersionScript.Remove(dr)
               ugScripts.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.ReloadData)
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Metodos"

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = ugDetalle.FindForm().Name + IdFuncion + "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugDetalle.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub RefrescarDatosGrilla()

      chbFecha.Checked = False
      Me.chkMesCompleto.Checked = False

      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      Me.rdbFechaNovedad.Checked = True

      Me.cmbTodos.SelectedIndex = 0

      'Me.chbCategoria.Checked = False
      Me.chbAsignadoA.Checked = False
      Me.chbEstado.Checked = False
      Me.chbMedio.Checked = False
      Me.chbPrioridad.Checked = False
      Me.chbProspecto.Checked = False
      Me.chbUsuario.Checked = False
      Me.chkExpandAll.Checked = False
      Me.chbNumero.Checked = False
      Me.cmbFinalizado.SelectedIndex = 2
      Me.chbAplicacion.Checked = False
      Me.chbProyecto.Checked = False
      Me.cmbPriorizado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If
      If Not Me.ugEnviar.DataSource Is Nothing Then
         DirectCast(Me.ugEnviar.DataSource, DataTable).Rows.Clear()
      End If

      If TipoNovedadParametro IsNot Nothing Then cmbTipoNovedad.SelectedValue = TipoNovedadParametro.IdTipoNovedad

      Dim idFuncion2 As String = "CRMNovedadesABM"
      If TipoNovedad IsNot Nothing Then
         idFuncion2 += TipoNovedad.IdTipoNovedad
      End If

      cmbCategoriasNovedad.Refrescar()

      Dim TienePermisoParaVerOtrosUsuarios As Boolean = New Eniac.Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, TipoNovedad.IdTipoNovedad + "-VerOtrosUsuarios")

      Me.cmbRevisionAdministrativa.Text = "TODAS"

      If Not TienePermisoParaVerOtrosUsuarios Then
         Me.chbAsignadoA.Enabled = False
         Me.cmbIdUsuarioAsignado.Enabled = False
      Else
         Me.chbAsignadoA.Enabled = True
         chbAsignadoA.Checked = False
      End If
      _listasDeVersionScript.Clear()
      Me.dtpDesde.Focus()

   End Sub

   Private Sub CambiaTipoNovedad()
      If _cargando Then Return
      Dim tipoNovedad As Entidades.CRMTipoNovedad = GetTipoNovedad()

      Me.RefrescarDatosGrilla()

      If tipoNovedad IsNot Nothing Then
         Dim idTipoNovedad As String = tipoNovedad.IdTipoNovedad
         _publicos.CargaComboCRMPrioridadesNovedades(cmbPrioridadNovedad, idTipoNovedad)
         _publicos.CargaComboCRMEstadosNovedades(cmbEstadoNovedad, idTipoNovedad)
         '_publicos.CargaComboCRMCategoriasNovedades(cmbCategoriaNovedad, idTipoNovedad)
         _publicos.CargaComboCRMCategoriasNovedades(cmbCategoriaNovedadNuevo, idTipoNovedad)
         _publicos.CargaComboCRMMediosComunicacionesNovedades(cmbMedio, idTipoNovedad)
         _publicos.CargaComboCRMMetodoResolucionNovedad(cmbMetodoResolulcion, idTipoNovedad)

         For Each dinamico As Entidades.CRMTipoNovedadDinamico In tipoNovedad.Dinamicos
            Select Case dinamico.IdNombreDinamico
               Case Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES.ToString()
                  Modo = Entidades.Cliente.ModoClienteProspecto.Cliente
                  chbProspecto.Text = Modo.ToString()
               Case Entidades.CRMTipoNovedad.TipoDinamico.PROSPECTOS.ToString()
                  Modo = Entidades.Cliente.ModoClienteProspecto.Prospecto
                  chbProspecto.Text = Modo.ToString()
               Case Entidades.CRMTipoNovedad.TipoDinamico.PROVEEDORES.ToString()
                  Modo = Nothing
                  chbProspecto.Text = "Proveedor"
               Case Entidades.CRMTipoNovedad.TipoDinamico.METODORESOLUCION.ToString()
                  cmbMetodoResolulcion.Visible = True
                  chbMetodoResolulcion.Visible = True
               Case Else
            End Select
         Next

         _publicos.CargaComboCRMEstadosNovedades(cmbEstadoNuevo, idTipoNovedad)
         _publicos.CargaComboCRMPrioridadesNovedades(cmbPrioridadNovedadNuevo, idTipoNovedad)
         _publicos.CargaComboCRMMediosComunicacionesNovedades(cmbMedioNuevo, idTipoNovedad)
         _publicos.CargaComboCRMMetodoResolucionNovedad(cmbMetodoNuevo, idTipoNovedad)

         If Not tbcVersion.TabPages.Contains(tbpVersion) Then
            tbcVersion.TabPages.Add(tbpVersion)
         End If

         _publicos.CargaComboCRMPrioridadesNovedades(cmbPrioridadNovedadVersion, idTipoNovedad)
         _publicos.CargaComboCRMEstadosNovedades(cmbEstadoVersion, idTipoNovedad)
         _publicos.CargaComboCRMMediosComunicacionesNovedades(cmbMedioVersion, idTipoNovedad)

         If chbAplicacion.Checked Then
            tbcVersion.TabPages.Add(tbpVersion)
         End If

      Else
         ClearCombo(cmbPrioridadNovedad)
         ClearCombo(cmbEstadoNovedad)
         'ClearCombo(cmbCategoriaNovedad)
         ClearCombo(cmbMedio)

         ClearCombo(cmbEstadoNuevo)
         ClearCombo(cmbPrioridadNovedadNuevo)
         ClearCombo(cmbCategoriaNovedadNuevo)
         ClearCombo(cmbMedioNuevo)

         'ClearCombo(cmbPrioridadNovedadVersion)
         'ClearCombo(cmbEstadoVersion)
         'ClearCombo(cmbMedioVersion)
      End If

   End Sub

   Private Function GetTipoNovedad() As Entidades.CRMTipoNovedad
      If cmbTipoNovedad.SelectedIndex >= 0 Then
         Return DirectCast(cmbTipoNovedad.SelectedItem, Entidades.CRMTipoNovedad)
      Else
         Return Nothing
      End If
   End Function

   Private Sub ClearCombo(cmb As ComboBox)
      If TypeOf (cmb.DataSource) Is IList Then DirectCast(cmb.DataSource, IList).Clear()
   End Sub

   Private Sub CargaGrillaDetalle()


      Dim IdCliente As Long = 0
      Dim idCategoriaNovedad As Integer = 0
      Dim CategoriasNovedades As Entidades.CRMCategoriaNovedad()
      Dim CatNov As Entidades.CRMCategoriaNovedad
      Dim EstadosNovedades As Entidades.CRMEstadoNovedad()
      Dim EstNov As Entidades.CRMEstadoNovedad
      Dim MediosNovedades As Entidades.CRMMedioComunicacionNovedad()
      Dim MedNov As Entidades.CRMMedioComunicacionNovedad
      Dim MetodosNovedades As Entidades.CRMMetodoResolucionNovedad()
      Dim MetNov As Entidades.CRMMetodoResolucionNovedad
      Dim idEstadoNovedad As Integer = 0
      Dim IdUsuarioAsignado As String = String.Empty
      Dim IdMedioComunicacionNovedad As Integer = 0
      Dim IdMetodoResolucionNovedad As Integer = 0
      Dim IdNovedad As Integer = 0
      Dim idNovedadPadre As Integer = 0
      Dim IdProspecto As Long = 0
      Dim IdProveedor As Long = 0
      Dim IdPrioridadNovedad As Integer = 0
      Dim IdUsuarioAlta As String = String.Empty
      'Dim FecNovedad As Boolean = True
      Dim idProyecto As Integer = 0
      Dim IdFuncion As String = String.Empty

      If Me.chbProspecto.Checked Then
         If Modo.HasValue Then
            If Modo.Value = Entidades.Cliente.ModoClienteProspecto.Cliente Then
               IdCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            Else
               IdProspecto = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            End If
         Else
            If TipoNovedadTiene("PROVEEDORES") Then
               IdProveedor = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            End If
         End If
      End If

      'If Me.chbCategoria.Checked Then
      '   idCategoriaNovedad = Integer.Parse(Me.cmbCategoriaNovedad.SelectedValue.ToString())
      '   CatNov = New Reglas.CRMCategoriasNovedades().GetUno(idCategoriaNovedad)
      '   CategoriasNovedades = {CatNov}
      'Else
      '   CategoriasNovedades = Nothing
      'End If

      If Me.chbEstado.Checked Then
         idEstadoNovedad = Integer.Parse(Me.cmbEstadoNovedad.SelectedValue.ToString())
         EstNov = New Reglas.CRMEstadosNovedades().GetUno(idEstadoNovedad)
         EstadosNovedades = {EstNov}
      Else
         EstadosNovedades = Nothing
      End If

      If Me.chbAsignadoA.Checked Then
         IdUsuarioAsignado = Me.cmbIdUsuarioAsignado.SelectedValue.ToString()
      End If

      If Me.chbMedio.Checked Then
         IdMedioComunicacionNovedad = Integer.Parse(Me.cmbMedio.SelectedValue.ToString())
         MedNov = New Reglas.CRMMediosComunicacionesNovedades().GetUno(IdMedioComunicacionNovedad)
         MediosNovedades = {MedNov}
      Else
         MediosNovedades = Nothing
      End If
      If Me.chbMetodoResolulcion.Checked Then
         IdMetodoResolucionNovedad = Integer.Parse(Me.cmbMetodoResolulcion.SelectedValue.ToString())
         MetNov = New Reglas.CRMMetodosResolucionesNovedades().GetUno(IdMetodoResolucionNovedad)
         MetodosNovedades = {MetNov}
      Else
         MetodosNovedades = Nothing
      End If

      If Me.cmbUsuarioAlta.Enabled Then
         IdUsuarioAlta = Me.cmbUsuarioAlta.SelectedValue.ToString()
      End If

      If Me.chbNumero.Checked Then
         IdNovedad = Integer.Parse(Me.txtNumero.Text)
      End If

      If Me.chbPrioridad.Checked Then
         IdPrioridadNovedad = Integer.Parse(Me.cmbPrioridadNovedad.SelectedValue.ToString())
      End If

      If Me.chbProyecto.Checked Then
         idProyecto = Integer.Parse(Me.bscCodigoProyecto.Text)
      End If

      If Me.chbFuncion.Checked Then
         IdFuncion = Me.bscCodigoFuncion.Text
      End If

      Dim revAdmin = Entidades.Publicos.SiNoTodos.TODOS
      If Me.cmbRevisionAdministrativa.Text <> "TODAS" Then
         If Me.cmbRevisionAdministrativa.Text = "SI" Then
            revAdmin = Entidades.Publicos.SiNoTodos.SI
         Else
            revAdmin = Entidades.Publicos.SiNoTodos.NO
         End If
      End If

      'FecNovedad = Me.rdbFechaNovedad.Checked
      Dim tipoFechaFiltro = If(rdbFechaNovedad.Checked, Entidades.CRMNovedad.TipoFechaFiltro.FechaNovedad, Entidades.CRMNovedad.TipoFechaFiltro.FechaProximoContacto)

      'TODO: El parametro de proyectos se envia cero pero hay que poner el control en la pantalla y enviar el parametro 
      'correcto para que funcione la pantalla.
      Dim desde As Date? = Nothing
      Dim hasta As Date? = Nothing
      If chbFecha.Checked Then
         desde = dtpDesde.Value
         hasta = dtpHasta.Value
      End If
      Dim rCRM = New Reglas.CRMNovedades()
      _dtDetalle = rCRM.GetNovedades(desde, hasta, tipoFechaFiltro, cmbTipoNovedad.SelectedValue.ToString(), Nothing,
                                     cmbCategoriasNovedad.GetCategorias(TipoNovedad.IdTipoNovedad, True), EstadosNovedades, MediosNovedades, MetodosNovedades, IdUsuarioAsignado,
                                     IdNovedad, idNovedadPadre, IdCliente, IdProspecto, IdProveedor, IdPrioridadNovedad, IdUsuarioAlta,
                                     cmbFinalizado.Text, idProyecto, revAdmin,
                                     If(chbAplicacion.Checked, cmbAplicacion.SelectedValue.ToString(), String.Empty),
                                     If(chbVersion.Checked, cmbVersion.SelectedValue.ToString(), String.Empty), Me.txtDescripcion.Text,
                                     priorizado:=cmbPriorizado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                     usaOrdenamientoDelTablero:=False, IdFuncion,
                                     prioridadDelProyectoDesde:=0, prioridadDelProyectoHasta:=0, estadoDelProyecto:=0, clasificacionDelProyecto:=0,
                                     enGarantia:=Entidades.Publicos.SiNoTodos.TODOS, enPrestamo:=Entidades.Publicos.SiNoTodos.TODOS, estadoPrestamo:=Entidades.CRMNovedad.EstadosProductosPrestados.TODOS,
                                     tipoUsuario:=0, visualizaSucursal:=Nothing, sucursales:=Nothing, categoriaReporta:="TODOS", patenteVehiculo:=String.Empty)

      _dtDetalle.Columns.Add(selecColumnName, GetType(Boolean))
      For Each dr As DataRow In _dtDetalle.Rows
         dr(selecColumnName) = False
      Next

      ugDetalle.DataSource = _dtDetalle

      FormatearGrilla()

      If ugDetalle.Rows.Count > 0 Then
         If Not Me.ugEnviar.DataSource Is Nothing Then
            DirectCast(Me.ugEnviar.DataSource, DataTable).Rows.Clear()

            If tbcVersion.TabPages.Contains(Me.tbpEnviar) Then
               Dim currentPage As TabPage = tbcVersion.SelectedTab
               tbcVersion.SelectedTab = tbpEnviar
               With ugEnviar.DisplayLayout.Bands(0)
                  .SortedColumns.Clear()
                  .SortedColumns.Add("NombrePadre", False)
                  .SortedColumns.Add("NombreFuncion", False)
                  .SortedColumns.Add("Descripcion", False)
               End With
               tbcVersion.SelectedTab = currentPage
            End If
         End If

      End If

      Me.tssRegistros.Text = _dtDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Public Sub FormatearGrilla()
      ugDetalle.DisplayLayout.UseFixedHeaders = True
      ugDetalle.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None
      Dim pos As Integer = 0
      With Me.ugDetalle.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.NoEdit
         Next

         If Not .Columns.Exists("Ver") Then
            .Columns.Add("Ver")
         End If

         If Not .Columns.Exists(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1") Then
            .Columns.Add(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1", String.Empty)
         End If

         .Columns(selecColumnName).FormatearColumna("", pos, 20, HAlign.Center).CellActivation = Activation.AllowEdit

         FormatearColumna(.Columns("Ver"), "Ver", pos, 30, HAlign.Center)
         .Columns("Ver").Style = UltraWinGrid.ColumnStyle.Button
         .Columns("Ver").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         .Columns("Ver").Header.Fixed = True

         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1"), "", pos, 60)
         .Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").Header.Fixed = True
         .Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").CellActivation = Activation.NoEdit

         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString()), "", 1000, 30, , True)

         FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()), "Tipo", pos, 60, , TipoNovedad IsNot Nothing)
         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.Letra.ToString()), "L.", pos, 25, HAlign.Center)
         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()), "Emisor", pos, 45, HAlign.Right, True)
         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()), "Número", pos, 60, HAlign.Right)
         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString()), "Fecha / Hora", pos, 120, HAlign.Center, hidden:=True)
         .Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString() + "_Fecha"), "Fecha", pos, 80, HAlign.Center)
         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString() + "_Hora"), "Hora", pos, 40, HAlign.Center)

         If TipoNovedadTiene("CLIENTES") Then
            'Oculta
            'FormatearColumna(.Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()), "Código", 4, 80, HAlign.Right)
            FormatearColumna(.Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()), "Nombre Cliente", pos, 200)

            FormatearColumna(.Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()), "Nombre de Fantasia", pos, 200)

            FormatearColumna(.Columns("NombreCategoriaCliente"), "Categoria Cliente", pos, 120)
         End If

         If TipoNovedadTiene("PROSPECTOS") Then
            'Oculta
            'FormatearColumna(.Columns("CodigoProspecto"), "Código", 7, 80, HAlign.Right)
            FormatearColumna(.Columns("NombreProspecto"), "Nombre Prospecto", pos, 200)

            FormatearColumna(.Columns("NombreDeFantasiaProspecto"), "Nombre de Fantasia", pos, 200)

            FormatearColumna(.Columns("NombreCategoriaProspecto"), "Categoria Prospecto", pos, 120)
         End If

         If TipoNovedadTiene("PROVEEDORES") Then
            FormatearColumna(.Columns("NombreProveedor"), "Nombre Proveedor", pos, 200)

            FormatearColumna(.Columns("NombreCategoriaProveedor"), "Categoria Proveedor", pos, 120)
         End If

         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.Interlocutor.ToString()), "Interlocutor", pos, 80)


         If TipoNovedadTiene("PROYECTOS") Then
            FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdProyecto.ToString()), "Proyecto", pos, 80, HAlign.Right)
         End If

         If TipoNovedadTiene("SISTEMAS") Then
            FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdSistema.ToString()), "Sistema", pos, 80)
         End If

         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.Descripcion.ToString()), "Descripción", pos, 150)

         FormatearColumna(.Columns(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()), "Estado", pos, 80)

         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdUsuarioAsignado.ToString()), "Usuario Asignado", pos, 70)

         FormatearColumna(.Columns(Entidades.CRMPrioridadNovedad.Columnas.NombrePrioridadNovedad.ToString()), "Prioridad", pos, 70)

         FormatearColumna(.Columns(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()), "Categoria", pos, 110)

         If TipoNovedadTiene("METODORESOLUCION") Then
            FormatearColumna(.Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString()), "Resolución", pos, 80)
         End If

         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString()), "Prox. Contacto", pos, 120, HAlign.Center, hidden:=True)
         .Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString() + "_Fecha"), "Fecha Prox. Contacto", pos, 80, HAlign.Center)
         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString() + "_Hora"), "Hora Prox. Contacto", pos, 40, HAlign.Center)

         FormatearColumna(.Columns(Entidades.CRMMedioComunicacionNovedad.Columnas.NombreMedioComunicacionNovedad.ToString()), "Medio", pos, 100)

         If TipoNovedad IsNot Nothing AndAlso TipoNovedad.UnidadDeMedida <> "%" Then
            FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.Avance.ToString()), TipoNovedad.UnidadDeMedida, pos, 50, HAlign.Right)
         Else
            FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.Avance.ToString()), "% Av.", pos, 45, HAlign.Right)
         End If

         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString()), "Fecha/Hora Estado", pos, 80, HAlign.Center, hidden:=True)
         .Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString() + "_Fecha"), "Fecha Estado", pos, 80, HAlign.Center)
         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString() + "_Hora"), "Hora Estado", pos, 40, HAlign.Center)

         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdUsuarioEstadoNovedad.ToString()), "Usuario Estado", pos, 80)

         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdUsuarioAlta.ToString()), "Usuario Alta", pos, 80)


         FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.Priorizado.ToString()), "Priorizado", pos, 60)

         If TipoNovedadTiene("FUNCIONES") Then
            FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdFuncion.ToString()), "Código Función", pos, 100)
            FormatearColumna(.Columns("NombreFuncion"), "Nombre Función", pos, 200)
         End If

         If Reglas.Publicos.CRMMuestraSolapaMasInfo Then
            FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdTipoNovedadPadre.ToString()), "Padre Tipo", pos, 50, HAlign.Left)
            FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.IdNovedadPadre.ToString()), "Padre Nro.", pos, 50, HAlign.Right)
            FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.Version.ToString()), "Version", pos, 50, HAlign.Left)
            FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.VersionFecha.ToString()), "Version Fecha", pos, 80, HAlign.Center)
            FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaInicioPlan.ToString()), "Inicio Plan", pos, 80, HAlign.Center)
            FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.FechaFinPlan.ToString()), "Fin Plan", pos, 80, HAlign.Center)
            FormatearColumna(.Columns(Entidades.CRMNovedad.Columnas.TiempoEstimado.ToString()), "Tiempo Estimado", pos, 80, HAlign.Right)
         End If


      End With

      ugDetalle.AgregarFiltroEnLinea({Entidades.Cliente.Columnas.NombreCliente.ToString(),
                                     Entidades.Cliente.Columnas.NombreDeFantasia.ToString(),
                                     "NombreProspecto",
                                     "NombreDeFantasiaProspecto",
                                     "NombreProveedor",
                                     Entidades.CRMNovedad.Columnas.Interlocutor.ToString(),
                                     Entidades.CRMNovedad.Columnas.Descripcion.ToString(),
                                     "NombreFuncion"})

      If TipoNovedad IsNot Nothing AndAlso TipoNovedad.UnidadDeMedida <> "%" Then
         Me.CargarColumnasASumar()
      End If

      LeerPreferencias()

   End Sub

   Protected Function TipoNovedadTiene(dinamico As String) As Boolean
      If TipoNovedad Is Nothing Then Return True
      For Each din As Entidades.CRMTipoNovedadDinamico In TipoNovedad.Dinamicos
         If din.IdNombreDinamico.ToLower().Equals(dinamico.ToLower()) Then
            Return True
         End If
      Next
      Return False
   End Function

   Protected Sub FormatearColumna(col As UltraGridColumn, caption As String, ByRef posicion As Integer, ancho As Integer,
                               Optional alineacion As HAlign = HAlign.Default, Optional hidden As Boolean = False)
      col.Hidden = hidden
      col.Header.Caption = caption
      col.Header.VisiblePosition = posicion
      col.Width = ancho
      col.CellAppearance.TextHAlign = alineacion
      posicion += 1
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow, cargaClienteFiltro As Boolean)
      If cargaClienteFiltro Then
         Me.bscCliente.Text = dr.Cells("Nombre" + Modo.Value.ToString()).Value.ToString()
         Me.bscCodigoCliente.Text = dr.Cells("Codigo" + Modo.Value.ToString()).Value.ToString()
         Me.bscCodigoCliente.Tag = dr.Cells("Id" + Modo.Value.ToString()).Value.ToString()
      Else
         Me.bscNombreClienteNuevo.Text = dr.Cells("Nombre" + Modo.Value.ToString()).Value.ToString()
         Me.bscCodClienteNuevo.Text = dr.Cells("Codigo" + Modo.Value.ToString()).Value.ToString()
         Me.bscCodClienteNuevo.Tag = dr.Cells("Id" + Modo.Value.ToString()).Value.ToString()
      End If
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdProveedor").Value.ToString()

   End Sub

   Private Sub CargarColumnasASumar()

      If Not Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Exists("Avance") Then

         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
         Me.ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Avance")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Avance", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Total:"

      End If

   End Sub

   Private Sub Actualizar()
      If ValidaActualizacion() Then
         Dim valores = New Entidades.CRMNovedad.CambioMasivo()

         If chbPrioridadNuevo.Checked Then
            valores.Prioridad = DirectCast(cmbPrioridadNovedadNuevo.SelectedItem, Entidades.CRMPrioridadNovedad)
         End If

         If chbPriorizadoNuevo.Checked Then
            valores.Priorizado = DirectCast(cmbPriorizadoNuevo.SelectedValue, Entidades.Publicos.SiNo) = Entidades.Publicos.SiNo.SI
         End If

         If chbRequiereTesteoNuevo.Checked Then
            valores.RequiereTesteo = cmbRequiereTesteoNuevo.ValorSeleccionado(Of Entidades.Publicos.SiNo) = Entidades.Publicos.SiNo.SI
         End If

         If chbAsignadoANuevo.Checked Then
            valores.UsuarioAsignado = DirectCast(cmbAsignadoANuevo.SelectedItem, Entidades.Usuario)
         End If
         If chbAvanceNuevo.Checked Then
            valores.Avance = Decimal.Parse(txtAvanceNuevo.Text)
         End If
         If chbEstadoNuevo.Checked Then
            valores.EstadoNovedad = DirectCast(cmbEstadoNuevo.SelectedItem, Entidades.CRMEstadoNovedad)
         End If
         If chbVersionFechaNuevo.Checked Then
            valores.VersionFecha = dtpVersionFechaNuevo.Value
         End If
         If chbVersionNuevo.Checked Then
            valores.Version.Valor = txtVersionNuevo.Text
         End If

         If chbFechaProximoContacto.Checked Then
            valores.FechaProximoContacto = If(dtpFechaProximoContacto.Checked, dtpFechaProximoContacto.Value, Date.MinValue)
         End If
         If chbMedioNuevo.Checked Then
            valores.MedioNovedad = DirectCast(cmbMedioNuevo.SelectedItem, Entidades.CRMMedioComunicacionNovedad)
         End If
         If chbMetodoNuevo.Checked Then
            valores.MetodoNovedad = cmbMetodoNuevo.ItemSeleccionado(Of Entidades.CRMMetodoResolucionNovedad)()
         End If

         If chbColorNuevo.Checked Then
            valores.BanderaColor = btnColorNuevo.BackColor
         End If

         If chbCategoriaNuevo.Checked Then
            valores.Categoria = DirectCast(cmbCategoriaNovedadNuevo.SelectedItem, Entidades.CRMCategoriaNovedad)
         End If

         If chbAplicacionNueva.Checked Then
            valores.Aplicacion = DirectCast(cmbAplicacionNueva.SelectedItem, Entidades.ZonaGeografica)
         End If

         If chbFuncionNuevo.Checked Then
            valores.IdFuncion = bscCodigoFuncionNuevo.Text
         End If
         If chbClienteNuevo.Checked Then
            valores.IdCliente = Long.Parse(bscCodClienteNuevo.Tag.ToString())
         End If
         If chbProyectoNuevo.Checked Then
            valores.IdProyecto = Integer.Parse(bscCodigoProyectoNuevo.Text)
         End If

         Dim rNovedades = New Reglas.CRMNovedades()
         rNovedades.ActualizacionMasiva(_dtDetalle, valores)


         ShowMessage("Actualizacion realizada con exito!")

         tbcVersion.SelectedTab = tbpFiltros
         btnConsultar.PerformClick()

      End If
   End Sub

   Private Function ValidaActualizacion() As Boolean
      Dim valida As Boolean = True
      Dim stbMensaje As StringBuilder = New StringBuilder()

      ValidaIndividual(valida, chbPrioridadNuevo, cmbPrioridadNovedadNuevo, stbMensaje)
      ValidaIndividual(valida, chbPriorizadoNuevo, cmbPriorizadoNuevo, stbMensaje)
      ValidaIndividual(valida, chbEstadoNuevo, cmbEstadoNuevo, stbMensaje)
      ValidaIndividual(valida, chbAsignadoANuevo, cmbAsignadoANuevo, stbMensaje)
      ValidaIndividual(valida, chbVersionNuevo, txtVersionNuevo, stbMensaje)
      ValidaIndividual(valida, chbMedioNuevo, cmbMedioNuevo, stbMensaje)

      If Me.chbFuncionNuevo.Checked And Not Me.bscCodigoFuncionNuevo.Selecciono And Not Me.bscFuncionNuevo.Selecciono Then
         stbMensaje.AppendLine("ATENCION: No seleccionó una Funcion aunque activó ese Filtro.")
         valida = False
      End If
      If Me.chbClienteNuevo.Checked And Not Me.bscCodClienteNuevo.Selecciono And Not Me.bscNombreClienteNuevo.Selecciono Then
         stbMensaje.AppendLine("ATENCION: No seleccionó una Cliente aunque activó ese Filtro.")
         valida = False
      End If
      If Me.chbProyectoNuevo.Checked AndAlso (Not Me.bscCodigoProyectoNuevo.Selecciono OrElse Not Me.bscProyectoNuevo.Selecciono) Then
         stbMensaje.AppendLine("ATENCION: No ingresó un número de Proyecto aunque activó ese Filtro.")
         valida = False
      End If

      If valida And chbEstadoNuevo.Checked Then
         If DirectCast(cmbEstadoNuevo.SelectedItem, Entidades.CRMEstadoNovedad).Finalizado Then
            Dim avance As Decimal = If(IsNumeric(txtAvanceNuevo.Text), Decimal.Parse(txtAvanceNuevo.Text), 0)
            If avance <> 100 Then
               stbMensaje.AppendLine("Selecciono un Estado Nuevo Finalizado, el Avance debe ser 100 %.")
               If chbAvanceNuevo.Checked Then
                  txtAvanceNuevo.Focus()
               Else
                  chbAvanceNuevo.Focus()
               End If
               valida = False
            End If
         End If
      End If

      If Not valida Then
         ShowMessage(stbMensaje.ToString())
      End If
      Return valida
   End Function

   Private Sub ValidaIndividual(ByRef valida As Boolean, chb As CheckBox, cmb As ComboBox, stb As StringBuilder)
      If chb.Checked And cmb.SelectedIndex < 0 Then
         ValidaIndividual(valida, chb, DirectCast(cmb, Control), stb)
      End If
   End Sub

   Private Sub ValidaIndividual(ByRef valida As Boolean, chb As CheckBox, txt As TextBox, stb As StringBuilder)
      If chb.Checked And String.IsNullOrWhiteSpace(txt.Text) Then
         ValidaIndividual(valida, chb, DirectCast(txt, Control), stb)
      End If
   End Sub

   Private Sub ValidaIndividual(ByRef valida As Boolean, chb As CheckBox, ctrl As Control, stb As StringBuilder)
      stb.AppendFormatLine("Activo el {0} y no seleccionó uno.", chb.Text)
      If valida Then ctrl.Focus()
      valida = False
   End Sub

   Private Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      If Not String.IsNullOrWhiteSpace(parametros) Then
         TipoNovedadParametro = New Reglas.CRMTiposNovedades().GetUno(parametros)
      End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.SufijoXML = IdFuncion
         pre.ShowDialog()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub GenerarVersion()
      Dim mensaje As String = ValidaActualizacionVersion()
      If String.IsNullOrWhiteSpace(mensaje) Then
         InicializaBackgroundWorkerGenerarVersion(GetValoresGenerarVersion())
      Else
         Throw New Exception(mensaje)
      End If
   End Sub

   Private Sub CargarDatosFuncion(dr As DataGridViewRow)
      Me.bscFuncion.Text = dr.Cells("Nombre").Value.ToString()
      Me.bscCodigoFuncion.Text = dr.Cells("Id").Value.ToString().Trim()
      bscCodigoFuncion.Selecciono = True
      bscFuncion.Selecciono = True
   End Sub

   Private Sub CargarDatosFuncionNuevo(dr As DataGridViewRow)
      Me.bscFuncionNuevo.Text = dr.Cells("Nombre").Value.ToString()
      Me.bscCodigoFuncionNuevo.Text = dr.Cells("Id").Value.ToString().Trim()
      bscCodigoFuncionNuevo.Selecciono = True
      bscFuncionNuevo.Selecciono = True
   End Sub

#End Region

#Region "Tab Version"
   Private Sub AgregarTab()
      If chbAplicacion.Checked Then

         Me.tbcVersion.TabPages.Add(tbpVersion)
         Me.tbcVersion.TabPages.Add(tbpEnviar)

         AgregarNovedadesSeleccionadas()

         tsbGenerarVersion.Visible = True

         ToolStripSeparator6.Visible = True


         Me.chbAvanceVersion.Checked = True
         Me.txtAvanceVersion.Enabled = False

         Me.chbPrioridadVersion.Checked = True
         Me.chbPrioridadVersion.Enabled = False

         Me.chbPriorizadoVersion.Checked = True
         Me.chbPriorizadoVersion.Enabled = False
         Me.cmbPriorizadoVersion.Enabled = False

         Me.chbVersionFinal.Checked = True

         Me.chbEstadoVersion.Checked = True
         Me.chbEstadoVersion.Enabled = False


         Me.chbAvanceVersion.Enabled = False
         Me.txtAvanceVersion.Text = "100"

         Me.chbMedioVersion.Checked = True
         Me.chbMedioVersion.Enabled = False


         Me.chbVersionFinal.Checked = True
         Me.chbVersionFinal.Enabled = False

         Me.chbVersionFechaFinal.Checked = True
         Me.chbVersionFechaFinal.Enabled = False

         Me.chbFechaProximoContactoVersion.Enabled = False
         Me.chbFechaProximoContactoVersion.Checked = True

         Me.chbColorVersion.Checked = True
         Me.chbColorVersion.Enabled = False
         Me.btnColorVersion.Enabled = False
      Else
         Me.cmbFinalizado.SelectedIndex = 2
         Me.tbcVersion.TabPages.Remove(tbpVersion)
         Me.tbcVersion.TabPages.Remove(tbpEnviar)
         tsbGenerarVersion.Visible = False
         ToolStripSeparator6.Visible = False
      End If
   End Sub

   Private Function GetValoresGenerarVersion() As Entidades.CRMNovedad.CambioMasivo
      Dim valores As Entidades.CRMNovedad.CambioMasivo = New Entidades.CRMNovedad.CambioMasivo()

      If chbPrioridadVersion.Checked Then
         valores.Prioridad = DirectCast(cmbPrioridadNovedadVersion.SelectedItem, Entidades.CRMPrioridadNovedad)
      End If
      If chbPriorizadoVersion.Checked Then
         valores.Priorizado = DirectCast(cmbPriorizadoVersion.SelectedValue, Entidades.Publicos.SiNo) = Entidades.Publicos.SiNo.SI
      End If

      If chbAvanceVersion.Checked Then
         valores.Avance = Decimal.Parse(txtAvanceVersion.Text)
      End If
      If chbEstadoVersion.Checked Then
         valores.EstadoNovedad = DirectCast(cmbEstadoVersion.SelectedItem, Entidades.CRMEstadoNovedad)
      End If
      If chbVersionFechaFinal.Checked Then
         valores.VersionFecha = dtpVersionFechaFinal.Value
      End If
      If chbVersionFinal.Checked Then
         valores.Version.Valor = txtVersionFinal.Text
      End If

      If chbFechaProximoContactoVersion.Checked Then
         valores.FechaProximoContacto = If(dtpFechaProximoContactoVersion.Checked, dtpFechaProximoContacto.Value, DateTime.MinValue)
      End If
      If chbMedioVersion.Checked Then
         valores.MedioNovedad = DirectCast(cmbMedioVersion.SelectedItem, Entidades.CRMMedioComunicacionNovedad)
      End If

      If chbColorVersion.Checked Then
         valores.BanderaColor = btnColorVersion.BackColor
      End If

      valores.Aplicacion = DirectCast(cmbAplicacion.SelectedItem, Entidades.ZonaGeografica)

      valores.GrabaResponsableEnAsignado = True
      valores.EstadosPadres.Add("TICKETS", 432) 'FINALIZADO    ''437)   ' PARA ACTUALIZAR
      valores.EstadosPadres.Add("REQUER", 413)  'FINALIZADO    ''422)   ' PARA ACTUALIZAR

      Return valores
   End Function

   Private Function ActualizarVerionFinal(dt As DataTable, valores As Entidades.CRMNovedad.CambioMasivo, idAplicacion As String) As String
      Try
         Dim rNovedades As Reglas.CRMNovedades = New Reglas.CRMNovedades()
         rNovedades.ActualizacionGenerarVersion(dt, valores, idAplicacion, _listasDeVersionScript)
      Catch ex As Exception
         Return String.Format("Error generando versión {0}", ex.Message)
      End Try
      Return String.Empty
   End Function

   Private Function ValidaActualizacionVersion() As String
      Dim valida As Boolean = True
      Dim stbMensaje As StringBuilder = New StringBuilder()

      ValidaIndividual(valida, chbPrioridadVersion, cmbPrioridadNovedadVersion, stbMensaje)
      ValidaIndividual(valida, chbEstadoVersion, cmbEstadoVersion, stbMensaje)
      ValidaIndividual(valida, chbMedioVersion, cmbMedioVersion, stbMensaje)
      ValidaIndividual(valida, chbVersionFinal, txtVersionFinal, stbMensaje)
      ValidaIndividual(valida, chbPriorizadoVersion, cmbPriorizadoVersion, stbMensaje)
      ValidaIndividual(valida, chbVersionFinal, TxtRutaFTP, stbMensaje)
      If valida And chbEstadoVersion.Checked Then
         If DirectCast(cmbEstadoVersion.SelectedItem, Entidades.CRMEstadoNovedad).Finalizado Then
            Dim avance As Decimal = If(IsNumeric(txtAvanceVersion.Text), Decimal.Parse(txtAvanceVersion.Text), 0)
            If avance <> 100 Then
               stbMensaje.AppendLine("Selecciono un Estado Nuevo Finalizado, el Avance debe ser 100 %.")
               If chbAvanceNuevo.Checked Then
                  txtAvanceNuevo.Focus()
               Else
                  chbAvanceNuevo.Focus()
               End If
               valida = False
            End If
         End If
      End If

      If cmbAplicacion.SelectedIndex < 0 Then
         valida = False
         stbMensaje.AppendLine("Debe seleccionar una aplicación para poder generar versión.")
      End If

      If Not valida Then
         Return stbMensaje.ToString()
      End If
      Return String.Empty
   End Function

   Private Sub AbrePedidoParaModificar()
      Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then
         Dim oNovedad As Entidades.CRMNovedad = New Reglas.CRMNovedades().GetUno(dr(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()).ToString(),
                                                                                 dr(Entidades.CRMNovedad.Columnas.Letra.ToString()).ToString(),
                                                                                 Short.Parse(dr(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()).ToString()),
                                                                                 Long.Parse(dr(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()).ToString()))
         Using frmPedidos As CRMNovedadesDetalle = New CRMNovedadesDetalle(oNovedad, GetTipoNovedad())
            frmPedidos.IdFuncion = IdFuncion
            frmPedidos.StateForm = StateForm.Actualizar
            frmPedidos.ShowDialog(Me)
         End Using
      Else
         Throw New Exception(String.Format("Por favor seleccione un {0}.", cmbTipoNovedad.Text))
      End If
   End Sub

   Private Sub tsbModificar_Click(sender As Object, e As EventArgs) Handles tsbModificar.Click
      Try
         AbrePedidoParaModificar()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbPrioridadVersion_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrioridadVersion.CheckedChanged
      Try

         If Not Me.chbPrioridadVersion.Checked Then
            Me.cmbPrioridadNovedadVersion.SelectedIndex = -1
         Else
            If Me.cmbPrioridadNovedadVersion.Items.Count > 0 Then
               Me.cmbPrioridadNovedadVersion.SelectedValue = 403
            End If

         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbEstadoVersion_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstadoVersion.CheckedChanged
      Try

         If Not Me.chbEstadoVersion.Checked Then
            Me.cmbEstadoVersion.SelectedIndex = -1
         Else
            If Me.cmbEstadoVersion.Items.Count > 0 Then
               Me.cmbEstadoVersion.SelectedValue = 403
            End If

         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbMedioVersion_CheckedChanged(sender As Object, e As EventArgs) Handles chbMedioVersion.CheckedChanged
      Try
         Me.cmbMedioVersion.Enabled = Me.chbMedioVersion.Checked
         If Not Me.chbMedioVersion.Checked Then
            Me.cmbMedioVersion.SelectedIndex = -1
         Else
            If Me.cmbMedioVersion.Items.Count > 0 Then
               Me.cmbMedioVersion.SelectedIndex = 0
            End If
            Me.cmbMedioNuevo.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbVersionFinal_CheckedChanged(sender As Object, e As EventArgs) Handles chbVersionFinal.CheckedChanged
      Try
         If Not Me.chbVersionFinal.Checked Then
            Me.txtVersionFinal.Text = String.Empty
         Else
            txtVersionFinal.Text = String.Format("{0:yy}.{0:MM}.{0:dd}.1", Today)
            Me.txtVersionFinal.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbPriorizadoVersion_CheckedChanged(sender As Object, e As EventArgs) Handles chbPriorizadoVersion.CheckedChanged
      Try

         If Not Me.chbPriorizadoVersion.Checked Then
            Me.cmbPriorizadoVersion.SelectedIndex = -1
         Else
            Me.cmbPriorizadoVersion.SelectedIndex = 1
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbColorVersion_CheckedChanged(sender As Object, e As EventArgs) Handles chbColorVersion.CheckedChanged
      Try
         Me.pnlColorNuevoVersion.Enabled = Me.chbColorVersion.Checked
         btnColorVersion.Visible = chbColorVersion.Checked
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnColorVersion_Click(sender As Object, e As EventArgs) Handles btnColorVersion.Click
      Try
         If btnColorVersion.BackColor.ToArgb().Equals(SystemColors.Control.ToArgb()) Then
            btnColorVersion.BackColor = Color.Green
         ElseIf btnColorVersion.BackColor.ToArgb().Equals(Color.Green.ToArgb()) Then
            btnColorVersion.BackColor = Color.Yellow
         ElseIf btnColorVersion.BackColor.ToArgb().Equals(Color.Yellow.ToArgb()) Then
            btnColorVersion.BackColor = Color.Red
         ElseIf btnColorVersion.BackColor.ToArgb().Equals(Color.Red.ToArgb()) Then
            btnColorVersion.BackColor = SystemColors.Control
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Nothing, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbVersionFechaFinal_CheckedChanged(sender As Object, e As EventArgs) Handles chbVersionFechaFinal.CheckedChanged
      Try
         Me.dtpVersionFechaFinal.Enabled = Me.chbVersionFechaFinal.Checked
         If Not Me.chbVersionFechaFinal.Checked Then
            Me.dtpVersionFechaFinal.Value = Now
         Else
            Me.dtpVersionFechaFinal.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugDetalle.DoubleClickRow
      Try
         AbrePedidoParaModificar()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      Try
         AgregarNovedadesSeleccionadas()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub AgregarNovedadesSeleccionadas()
      If tbcVersion.TabPages.Contains(tbpEnviar) Then
         ugDetalle.UpdateData()
         If _dtDetalle IsNot Nothing Then
            Dim dt As DataTable = _dtDetalle.Clone()
            dt.ImportRowRange(_dtDetalle.Select(selecColumnName))

            For Each dr As DataRow In dt.Rows
               dr(Entidades.CRMNovedad.Columnas.Version.ToString()) = txtVersionFinal.Text
            Next

            ugEnviar.DataSource = dt
            FormatearGrillaEnviar()
         End If
      End If
   End Sub

   Public Sub FormatearGrillaEnviar()
      ugEnviar.DisplayLayout.UseFixedHeaders = True
      ugEnviar.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None
      Dim pos As Integer = 0
      With Me.ugEnviar.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.NoEdit
         Next

         FormatearColumna(.Columns("IdNovedad"), "Número", pos, 60, HAlign.Right)
         FormatearColumna(.Columns("Interlocutor"), "Solicitante", pos, 70)
         FormatearColumna(.Columns("FechaNovedad"), "Alta", pos, 80, HAlign.Center)
         FormatearColumna(.Columns("NombreCategoriaNovedad"), "Categoria", pos, 150)
         FormatearColumna(.Columns("NombreDeFantasia"), "Nombre de Fantasia", pos, 250)
         FormatearColumna(.Columns("NombrePadre"), "Padre", pos, 150)
         FormatearColumna(.Columns("NombreFuncion"), "Nombre Función", pos, 250)
         FormatearColumna(.Columns("Descripcion"), "Descripción", pos, 300)
         FormatearColumna(.Columns("NombreUsuarioResponsable"), "Responsable", pos, 85)


      End With
   End Sub

#End Region

#Region "Eventos de Enviar"

   Private Function EnviarMail(args As GenerarVersionArgs, stbCuerpo As StringBuilder) As String
      Dim valor As Boolean = False
      If ValidarCorreo() Then
         Try
            GenerarMails(String.Format(Reglas.Publicos.CRMAsuntoGenerarVersion,
                                       args.NombreAplicacion,
                                       args.Valores.Version.Valor,
                                       args.Valores.VersionFecha.Value),
                         String.Format("Adjunto se encuentra el detalle de la versión{0}{0}{1}", Environment.NewLine, stbCuerpo.ToString()).Replace(Environment.NewLine, "<BR>"),
                         args)
            '{0} = Aplicación
            '{1} = Versión desde
            '{2} = Fecha de Versión
         Catch ex As Exception
            Return String.Format("Error enviando mail: {0}", ex.Message)
         End Try
      Else
         Return String.Format("Error enviando mail: Los Datos de la configuración del correo estan incompletos (Configuraciones -> Parametros del Sistema)")
      End If
      Return String.Empty
   End Function

   Private Function SubirArchvivoFTP(args As GenerarVersionArgs,
                                     uploadBegins As Eniac.Reglas.IFtp.FileUploadBeginningEventHandler,
                                     progress As Eniac.Reglas.IFtp.BytesUploadedEventHandler) As String
      If ValidarDatosFtp() = True Then
         Try
            ExportarDatos(args, uploadBegins, progress)
         Catch ex As Exception
            Return String.Format("Error subiendo archivos: {0}", ex.Message)
         End Try
      Else
         Return String.Format("Error subiendo archivos: Los Datos del FTP estan incompletos (Configuraciones -> Parametros del Sistema)")
      End If
      Return String.Empty
   End Function
   Private Function ValidarDatosFtp() As Boolean
      Dim validaDatos As Boolean = True
      If (Reglas.Publicos.FTPServidor = "" Or
          Reglas.Publicos.FTPUsuario = "" Or
          Reglas.Publicos.FTPPassword = "" Or
          Reglas.Publicos.FTPCarpetaRemota = "") Then
         validaDatos = False
      End If
      Return validaDatos
   End Function
   Private Function ValidarCorreo() As Boolean
      Dim validaDatos As Boolean = True
      If (String.IsNullOrWhiteSpace(Reglas.Publicos.MailServidor) Or
          String.IsNullOrWhiteSpace(Reglas.Publicos.MailDireccion) Or
          String.IsNullOrWhiteSpace(Reglas.Publicos.MailUsuario) Or
          String.IsNullOrWhiteSpace(Reglas.Publicos.MailPassword) Or
          Reglas.Publicos.MailPuertoSalida = 0) Then
         validaDatos = False
      End If
      Return validaDatos
   End Function


   Private Sub GenerarMails(asunto As String, mensaje As String, args As GenerarVersionArgs)
      If String.IsNullOrEmpty(asunto) Then
         Throw New Exception("ATENCION: Debe ingresar el Asunto del Correo.")
      End If
      If String.IsNullOrEmpty(mensaje) Then
         Throw New Exception("ATENCION: Debe ingresar el Cuerpo del Correo.")
      End If
      '**********************************************************************************
      Dim archivos As Dictionary(Of Long, String) = New Dictionary(Of Long, String)()
      '**********************************************************************************
      Dim Adjunto As String = ""
      Try
         Adjunto = args.NombreArchivo

         '**********************************************************************************
         Me.Enviar(asunto, mensaje, Adjunto)
         '**********************************************************************************
      Catch
         Throw
      End Try
   End Sub

   Private Function ProcesaDestinatarios(para As String) As String()
      Dim destina As List(Of String) = New List(Of String)()
      If Not String.IsNullOrWhiteSpace(para) Then
         Dim split As String() = para.Split(";"c)
         For Each correo As String In split
            If Not String.IsNullOrWhiteSpace(correo) Then
               destina.Add(correo)
            End If
         Next
      End If
      Return destina.ToArray()
   End Function

   Public Sub Enviar(asuntoMail As String, cuerpoMail As String, Adjunto As String)

      If String.IsNullOrEmpty(asuntoMail) Then Throw New ArgumentNullException("ATENCION: Debe ingresar el Asunto del Correo.")
      If String.IsNullOrEmpty(cuerpoMail) Then Throw New ArgumentNullException("ATENCION: Debe ingresar el Cuerpo del Correo.")

      Dim intCantidad As Integer = 0
      Dim rEnvioMail As Reglas.CRMEnvioMasivoNovedadesMails = New Reglas.CRMEnvioMasivoNovedadesMails()

      Dim destina As String() = ProcesaDestinatarios(Reglas.Publicos.CRMGenerarVersionPara)
      Dim destinaBCC As String() = ProcesaDestinatarios(Reglas.Publicos.CRMGenerarVersionCopiaOculta)

      If destina.Count = 0 And destinaBCC.Count = 0 Then Exit Sub

      'Al 12/02/2015 Son 2 reglas, 150 maximo por hora y 15 maximo por minuto.
      'Se baja a 120 por hora y 12 por minutos.
      '30 Segundos = 30 x 1000 = 120 Correos por Horas
      Dim intTiempoEntreCorreos As Integer = 30000
      If intCantidad <= 120 Then
         '5 Segundos 
         intTiempoEntreCorreos = 5000
      End If

      'creo el mail y lo envio
      Dim ms As Eniac.Win.MailSSS = New Eniac.Win.MailSSS()
      ms.CrearMail("TO", destina, asuntoMail, cuerpoMail, Nothing, destinaBCC)

      If Not String.IsNullOrWhiteSpace(Adjunto) Then
         ms.AgregarAdjunto(Adjunto)
      End If

      ms.EnviarMail()

   End Sub

   Private Sub tbcVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcVersion.SelectedIndexChanged
      If tbcVersion.SelectedTab.Equals(tbpCambios) Then
         tsbActualizar.Visible = True
         ToolStripSeparator2.Visible = True
         tsbGenerarVersion.Visible = False
         ToolStripSeparator6.Visible = False
      Else
         tsbActualizar.Visible = False
         ToolStripSeparator2.Visible = False
      End If
      If tbcVersion.SelectedTab.Equals(tbpEnviar) Or tbcVersion.SelectedTab.Equals(tbpVersion) Then
         tsbGenerarVersion.Visible = True
         ToolStripSeparator6.Visible = True
         tsbActualizar.Visible = False
         ToolStripSeparator2.Visible = False
      Else
         tsbGenerarVersion.Visible = False
         ToolStripSeparator6.Visible = False
      End If

   End Sub

   Private Sub CRMActualizacionMasiva_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      Select Case (e.KeyCode)
         Case Keys.F5
            Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
         Case Keys.F4
            If tsbActualizar.Visible = True Then
               Me.tsbActualizar_Click(Me.tsbActualizar, New EventArgs())
            End If
            If tsbGenerarVersion.Visible = True Then
               Me.tsbGenerarVersion_Click(Me.tsbGenerarVersion, New EventArgs())
            End If
      End Select
   End Sub

   Private Sub BtnFTP_Click(sender As Object, e As EventArgs) Handles BtnFTP.Click
      Try
         With OpenFileDialog1
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .Filter = "Archivos de imágen(*.msi)|*.msi"
            .FilterIndex = 1
            .RestoreDirectory = True
            .FileName = ""
         End With
         If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Me.TxtRutaFTP.Text = OpenFileDialog1.FileName
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ExportarDatos(args As GenerarVersionArgs,
                             uploadBegins As Eniac.Reglas.IFtp.FileUploadBeginningEventHandler,
                             progress As Eniac.Reglas.IFtp.BytesUploadedEventHandler)

      '****************************Configuracion Validad *********************
      'Dim servidorFTP As String = "www.sinergiass.com.ar"
      'Dim usuarioFTP As String = "sinergia.ftp@sinergiass.com.ar"
      'Dim claveFTP As String = "Sinergia!!2018"
      'Dim conexionPasivaFTP As Boolean = True
      'Dim carpetaRemotaFTP As String = "/public_html/deploy/siga1"
      '************************************************************************

      If String.IsNullOrEmpty(TxtRutaFTP.Text) Then
         Throw New ArgumentNullException("Debe seleccionar un archivo a subir.")
      End If

      Dim archivo As IO.FileInfo = New IO.FileInfo(TxtRutaFTP.Text)
      Dim archivo2 As IO.FileInfo = New IO.FileInfo(TxtRutaFTP.Text)

      If Not archivo.Exists Then
         Throw New ArgumentNullException("El archivo seleccionado no existe.")
      End If

      Dim CarptetaLocal As String = archivo.DirectoryName
      Dim NombreArchivo As String = archivo.Name

      Dim servidorFTP As String = Reglas.Publicos.FTPServidor
      Dim usuarioFTP As String = Reglas.Publicos.FTPUsuario
      Dim claveFTP As String = Reglas.Publicos.FTPPassword
      Dim conexionPasivaFTP As Boolean = Reglas.Publicos.FTPConexionPasiva
      Dim carpetaRemotaFTP As String = Reglas.Publicos.FTPCarpetaRemota

      If Not carpetaRemotaFTP.EndsWith("/") Then
         carpetaRemotaFTP = String.Concat(carpetaRemotaFTP, "/")
      End If
      carpetaRemotaFTP = String.Concat(carpetaRemotaFTP, args.IdAplicacion).ToLower()

      Dim ftp As Reglas.IFtp

      ftp = New Reglas.SimpleFtp(servidorFTP, usuarioFTP, claveFTP)

      AddHandler ftp.FileUploadBeginning, uploadBegins
      AddHandler ftp.BytesUploaded, progress

      Try
         ftp.UsePassive = conexionPasivaFTP

         ftp.Upload(archivo, carpetaRemotaFTP, archivo.Name.ToLower())

         If archivo.Extension = ".msi" Then
            archivo = New IO.FileInfo(IO.Path.Combine(archivo.Directory.FullName, archivo.Name.Replace(".msi", ".exe")))
            'NombreArchivo = archivo.Name.Replace(".msi", ".exe")
            If archivo.Exists Then
               ftp.Upload(archivo, carpetaRemotaFTP, archivo.Name.ToLower())
            End If
         End If
      Finally
         RemoveHandler ftp.FileUploadBeginning, uploadBegins
         RemoveHandler ftp.BytesUploaded, progress
      End Try

      'si tiene seteado para enviar el archivo a otro FTP
      If Reglas.Publicos.FTPSubeInfoAlservidor2 Then
         'creo el directorio de la versión
         Dim ver As System.Version
         Dim servidorFTP2 As String = Reglas.Publicos.FTPServidor2
         Dim usuarioFTP2 As String = Reglas.Publicos.FTPUsuario2
         Dim claveFTP2 As String = Reglas.Publicos.FTPPassword2
         Dim conexionPasivaFTP2 As Boolean = Reglas.Publicos.FTPConexionPasiva2
         Dim carpetaRemotaFTP2 As String = Reglas.Publicos.FTPCarpetaRemota2

         ftp = New Reglas.SimpleFtp(servidorFTP2, usuarioFTP2, claveFTP2)

         AddHandler ftp.FileUploadBeginning, uploadBegins
         AddHandler ftp.BytesUploaded, progress

         Try
            ftp.UsePassive = conexionPasivaFTP2

            If Not args.Valores.Version.EsNull Then
               ver = New System.Version(args.Valores.Version.Valor) '/MSI
               carpetaRemotaFTP2 += args.IdAplicacion + "/"
               ftp.MakeDirectory(carpetaRemotaFTP2, ver.ToString())
               carpetaRemotaFTP2 += ver.ToString()
            End If

            ftp.Upload(archivo2, carpetaRemotaFTP2, archivo2.Name.ToLower())

            If archivo2.Extension = ".msi" Then
               archivo2 = New IO.FileInfo(IO.Path.Combine(archivo2.Directory.FullName, archivo2.Name.Replace(".msi", ".exe")))
               If archivo2.Exists Then
                  ftp.Upload(archivo2, carpetaRemotaFTP2, archivo2.Name.ToLower())
               End If
            End If
         Finally
            RemoveHandler ftp.FileUploadBeginning, uploadBegins
            RemoveHandler ftp.BytesUploaded, progress
         End Try


      End If


   End Sub

#End Region

#Region "BackgroundWorker bwkGenerarVersion"
   Private Class GenerarVersionArgs
      Public Property Valores As Entidades.CRMNovedad.CambioMasivo
      Public Property Dt As DataTable
      Public Property IdAplicacion As String
      Public Property NombreAplicacion As String
      Public Property NombreTipoNovedad As String
      Public Property NombreArchivo As String
      Public Property ListaVersiones As IEnumerable(Of Entidades.VersionScript)
   End Class


   Private swGenerarVersion As Stopwatch
   Private stbGenerarVersionMensaje As StringBuilder
   Public Sub InicializaBackgroundWorkerGenerarVersion(valores As Entidades.CRMNovedad.CambioMasivo)
      swGenerarVersion = New Stopwatch()
      stbGenerarVersionMensaje = New StringBuilder()
      swGenerarVersion.Start()

      Cursor = Cursors.WaitCursor

      Const directorioCorreos As String = "Eniac\Correos"
      Dim nombreArchivo As String = "GenerarVersion_{0}_{2}_{1:yyyyMMdd}.xls"
      nombreArchivo = String.Format(nombreArchivo, cmbAplicacion.Text, valores.VersionFecha.Value, valores.Version.Valor)
      nombreArchivo = IO.Path.Combine(Entidades.Publicos.DriverBase, directorioCorreos, nombreArchivo)
      Dim asunto As String = String.Format("{0} - Versión {1} generada", cmbAplicacion.Text, valores.Version.Valor)

      Dim exp As UltraGridExportarExcel = New UltraGridExportarExcel(UltraGridExcelExporter1, Reglas.Publicos.NombreEmpresaImpresion)
      exp.Exportar(nombreArchivo, asunto, ugEnviar, "", True)

      For Each vers As Entidades.VersionScript In _listasDeVersionScript
         vers.Aplicacion.IdAplicacion = valores.Aplicacion.IdZonaGeografica
         vers.Version.NroVersion = valores.Version.Valor
      Next

      HabilitarControlers(False)
      bwkGenerarVersion.RunWorkerAsync(New GenerarVersionArgs() With {.Valores = valores,
                                                                      .Dt = _dtDetalle,
                                                                      .IdAplicacion = cmbAplicacion.SelectedValue.ToString(),
                                                                      .NombreAplicacion = cmbAplicacion.Text,
                                                                      .NombreTipoNovedad = cmbTipoNovedad.Text,
                                                                      .NombreArchivo = nombreArchivo,
                                                                      .ListaVersiones = _listasDeVersionScript.ToArray()})

   End Sub

   Private Class GenerarVersionProgress
      Public Property Texto As String
      Public Sub New(texto As String)
         Me.Texto = texto
      End Sub
   End Class

   Private Function AgregarGenerarVersionProgress(texto As String, stb As StringBuilder) As GenerarVersionProgress
      stb.AppendFormatLine(texto)
      Return New GenerarVersionProgress(texto)
   End Function

   Private Sub bwkBajarDatosBackup_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwkGenerarVersion.DoWork
      Try
         Reglas.Publicos.VerificaConfiguracionRegional()

         Dim args As GenerarVersionArgs = DirectCast(e.Argument, GenerarVersionArgs)

         Dim _inicioSubirDatos As DateTime = Now
         If ugEnviar.Rows.Count > 0 Then
            Dim stbCuerpo As StringBuilder = New StringBuilder()

            bwkGenerarVersion.ReportProgress(0, String.Format("Actualizando Versión de {0}.", args.NombreTipoNovedad))
            Dim mensaje As String = ActualizarVerionFinal(args.Dt, args.Valores, args.IdAplicacion)
            If String.IsNullOrWhiteSpace(mensaje) Then
               bwkGenerarVersion.ReportProgress(0, AgregarGenerarVersionProgress("Versión generada exitosamente.", stbCuerpo))

               mensaje = SubirArchvivoFTP(args,
                                          Sub(sender1 As Object, e1 As Reglas.FileUploadEventArgs)
                                             bwkGenerarVersion.ReportProgress(0, e1)
                                          End Sub,
                                          Sub(sender1 As Object, e1 As Reglas.BytesUploadedEventArgs)
                                             bwkGenerarVersion.ReportProgress(0, e1)
                                          End Sub)

               If String.IsNullOrWhiteSpace(mensaje) Then
                  bwkGenerarVersion.ReportProgress(0, AgregarGenerarVersionProgress("Archivo subido exitosamente.", stbCuerpo))
               Else
                  bwkGenerarVersion.ReportProgress(0, AgregarGenerarVersionProgress(mensaje, stbCuerpo))
               End If

               bwkGenerarVersion.ReportProgress(0, String.Format("Subiendo Script de Versión."))
               mensaje = SubirScriptVersion(args.ListaVersiones)

               If String.IsNullOrWhiteSpace(mensaje) Then
                  bwkGenerarVersion.ReportProgress(0, AgregarGenerarVersionProgress("Script enviado exitosamente.", stbCuerpo))
               Else
                  bwkGenerarVersion.ReportProgress(0, AgregarGenerarVersionProgress(mensaje, stbCuerpo))
               End If

               bwkGenerarVersion.ReportProgress(0, String.Format("Enviando correo con versión."))
               mensaje = EnviarMail(args, stbCuerpo)
               If String.IsNullOrWhiteSpace(mensaje) Then
                  bwkGenerarVersion.ReportProgress(0, AgregarGenerarVersionProgress("Correo enviado exitosamente.", stbCuerpo))
               Else
                  bwkGenerarVersion.ReportProgress(0, AgregarGenerarVersionProgress(mensaje, stbCuerpo))
               End If

            Else
               bwkGenerarVersion.ReportProgress(0, AgregarGenerarVersionProgress(mensaje, stbCuerpo))
            End If
         Else
            bwkGenerarVersion.ReportProgress(0, New GenerarVersionProgress(String.Format("Debe seleccionar al menos un {0}", args.NombreTipoNovedad)))
         End If
      Catch ex As Exception
         bwkGenerarVersion.ReportProgress(0, ex)
         bwkGenerarVersion.CancelAsync()
      End Try
   End Sub

   Private Sub bwkBajarDatosBackup_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bwkGenerarVersion.ProgressChanged
      If TypeOf (e.UserState) Is Exception Then
         stbGenerarVersionMensaje.AppendLine(DirectCast(e.UserState, Exception).Message)
      ElseIf TypeOf (e.UserState) Is Reglas.FileUploadEventArgs Then
         tssInfo.Text = String.Format("Subiendo el archivo {0}", DirectCast(e.UserState, Reglas.FileUploadEventArgs).FileName)
      ElseIf TypeOf (e.UserState) Is Reglas.BytesUploadedEventArgs Then
         tssInfo.Text = String.Format("Subiendo el archivo {0} - {1:P2}",
                                      DirectCast(e.UserState, Reglas.BytesUploadedEventArgs).Uri,
                                      DirectCast(e.UserState, Reglas.BytesUploadedEventArgs).Percentage / 100)
      ElseIf TypeOf (e.UserState) Is GenerarVersionProgress Then
         tssInfo.Text = DirectCast(e.UserState, GenerarVersionProgress).Texto.ToString()
         stbGenerarVersionMensaje.AppendLine(DirectCast(e.UserState, GenerarVersionProgress).Texto.ToString()).AppendLine()
      ElseIf TypeOf (e.UserState) Is String Then
         tssInfo.Text = e.UserState.ToString()
      End If
   End Sub

   Private Sub bwkBajarDatosBackup_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwkGenerarVersion.RunWorkerCompleted

      swGenerarVersion.Stop()
      stbGenerarVersionMensaje.AppendFormatLine("Tiempo Transcurrido: {0:hh\:mm\:ss}", swGenerarVersion.Elapsed)

      ShowMessage(stbGenerarVersionMensaje.ToString())

      HabilitarControlers(True)

      If Not e.Cancelled Then
         tbcVersion.SelectedTab = tbpFiltros
         btnConsultar.PerformClick()
      End If

      Cursor = Cursors.Default

   End Sub
#End Region

   Private Sub bscProyecto_BuscadorClick() Handles bscProyecto.BuscadorClick

      Try
         Me._publicos.PreparaGrillaProyectos(Me.bscProyecto)
         Dim rProyectos As Reglas.Proyectos = New Reglas.Proyectos()
         Me.bscProyecto.Datos = rProyectos.GetFiltradoPorNombre(Me.bscProyecto.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscProyecto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProyecto.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProyecto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoProyecto_BuscadorClick() Handles bscCodigoProyecto.BuscadorClick

      Try
         Dim codigoProyecto As Integer? = If(String.IsNullOrEmpty(Me.bscCodigoProyecto.Text), DirectCast(Nothing, Integer?), Integer.Parse(Me.bscCodigoProyecto.Text))
         Me._publicos.PreparaGrillaProyectos(Me.bscCodigoProyecto)
         Dim rProyectos As Reglas.Proyectos = New Reglas.Proyectos()
         Me.bscCodigoProyecto.Datos = rProyectos.GetFiltradoPorCodigo(codigoProyecto)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoProyecto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProyecto.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProyecto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscProyectoNuevo_BuscadorClick() Handles bscProyectoNuevo.BuscadorClick

      Try
         Me._publicos.PreparaGrillaProyectos(Me.bscProyectoNuevo)
         Dim rProyectos As Reglas.Proyectos = New Reglas.Proyectos()
         Me.bscProyectoNuevo.Datos = rProyectos.GetFiltradoPorNombre(Me.bscProyectoNuevo.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscProyectoNuevo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProyectoNuevo.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProyectoNuevo(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoProyectoNuevo_BuscadorClick() Handles bscCodigoProyectoNuevo.BuscadorClick

      Try
         Dim codigoProyectoNuevo As Integer? = If(String.IsNullOrEmpty(Me.bscCodigoProyectoNuevo.Text), DirectCast(Nothing, Integer?), Integer.Parse(Me.bscCodigoProyectoNuevo.Text))
         Me._publicos.PreparaGrillaProyectos(Me.bscCodigoProyectoNuevo)
         Dim rProyectos As Reglas.Proyectos = New Reglas.Proyectos()
         Me.bscCodigoProyectoNuevo.Datos = rProyectos.GetFiltradoPorCodigo(codigoProyectoNuevo)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoProyectoNuevo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProyectoNuevo.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosProyectoNuevo(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub CargarDatosProyecto(dr As DataGridViewRow)

      Me.bscCodigoProyecto.Text = dr.Cells("IdProyecto").Value.ToString()
      Me.bscProyecto.Text = dr.Cells("NombreProyecto").Value.ToString()
      bscCodigoProyecto.Selecciono = True
      bscProyecto.Selecciono = True
   End Sub

   Private Sub CargarDatosProyectoNuevo(dr As DataGridViewRow)

      Me.bscCodigoProyectoNuevo.Text = dr.Cells("IdProyecto").Value.ToString()
      Me.bscProyectoNuevo.Text = dr.Cells("NombreProyecto").Value.ToString()
      bscCodigoProyectoNuevo.Selecciono = True
      bscProyectoNuevo.Selecciono = True
   End Sub

   Private Sub lblPriorizado_Click(sender As Object, e As EventArgs) Handles lblPriorizado.Click

   End Sub

End Class