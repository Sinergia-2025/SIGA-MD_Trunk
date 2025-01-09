Imports System.ComponentModel

Public Class CRMNovedadesABM
   Implements IConParametros

   Public Class ParametrosLlamador
      Public Property IdProyecto As Integer
      Public Property IgnoraFiltrosPersonalizados As Boolean = False
      Public Property QuitarFiltroPorUsuario As Boolean = False

      Public Property FechaDesde As Date?
      Public Property FechaHasta As Date?
      Public Property IdUsuario As String
      Public Property CodigoCliente As Long
      Public Property Finalizado As Entidades.Publicos.SiNoTodos?

      Public Property AbrirAutomaticamenteSiHaySoloUno As Boolean = False

      Public Property IdCategoriaNovedad As Integer?
      Public Property IdEstadoNovedad As Integer?
      Public Property IdMetodoResolucionNovedad As Integer?
   End Class

   Public Property Parametros As ParametrosLlamador

   'Public Property IdProyecto As Integer
   'Public Property IgnoraFiltrosPersonalizados As Boolean = False
   'Public Property QuitarFiltroPorUsuario As Boolean = False

   Protected Property TipoNovedad As Entidades.CRMTipoNovedad
   'Private WithEvents tsCmbEstado As ToolStripComboBox
   'Private WithEvents tsCmbUsuarioAsignado As ToolStripComboBox

   Private Const usuarioTodos As String = "(TODOS)"
   Private Const estadoTodos As String = "Todos"
   Private Const estadoActivos As String = "Activos"
   Private Const estadoFinalizados As String = "Finalizados"

   Private cargando As Boolean = False
   Private _PermiteAbrirMultiplesNovedadesNuevas As Boolean = False
   Private _PermiteAbrirMultiplesNovedadesEditar As Boolean = False
   Private _extrasSinergia As Boolean = False
   Private Property Modo As Entidades.Cliente.ModoClienteProspecto?
   Private _publicos As Publicos

   Private _tienePermisoParaVerOtrosUsuarios As Boolean = True
   Private _tienePermisoParaEliminarRegistros As Boolean = True

   Private _usr As Entidades.Usuario

   Private _cacheSemaforo As List(Of Entidades.SemaforoVentaUtilidad)
   Private _cerrar As Boolean = False

   'Private _Cliente As Long = 0

   Private Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      Dim _parametros As New ParametrosFuncion()
      ConParametrosAyudante.Parse(parametros, GetType(ParametrosPermitidos), _parametros,
                                  convertirDato:=
                                  Function(key, value, h)
                                     If key.Equals(ParametrosPermitidos.TipoNovedad) Then
                                        Return value
                                     ElseIf key.Equals(ParametrosPermitidos.IdEstadoNovedad) Or key.Equals(ParametrosPermitidos.IdMetodoResolucionNovedad) Then
                                        Return h.ToInteger(value)
                                     ElseIf key.Equals(ParametrosPermitidos.QuitarFiltroPorUsuario) Then
                                        Return h.ToBoolean(value)
                                     Else
                                        Throw New Exception(String.Format("Clave de parámetro '{0}' no válida", key.ToString()))
                                     End If
                                  End Function)

      If _parametros.Existe(ParametrosPermitidos.TipoNovedad) Then
         TipoNovedad = New Reglas.CRMTiposNovedades().GetUno(_parametros.GetValor(Of String)(ParametrosPermitidos.TipoNovedad))
      End If

      If Me.Parametros Is Nothing Then
         Me.Parametros = New ParametrosLlamador()
      End If
      If _parametros.Existe(ParametrosPermitidos.IdEstadoNovedad) Then
         Me.Parametros.IdEstadoNovedad = _parametros.GetValor(Of Integer)(ParametrosPermitidos.IdEstadoNovedad)
      End If
      If _parametros.Existe(ParametrosPermitidos.IdMetodoResolucionNovedad) Then
         Me.Parametros.IdMetodoResolucionNovedad = _parametros.GetValor(Of Integer)(ParametrosPermitidos.IdMetodoResolucionNovedad)
      End If
      If _parametros.Existe(ParametrosPermitidos.QuitarFiltroPorUsuario) Then
         Me.Parametros.QuitarFiltroPorUsuario = _parametros.GetValor(Of Boolean)(ParametrosPermitidos.QuitarFiltroPorUsuario)
      End If

   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return ConParametrosAyudante.ParametrosDisponiblesAyuda(GetType(ParametrosPermitidos))
   End Function
   Public Enum ParametrosPermitidos
      <DefaultValue(""), Description("Tipo de novedad a mostrar en pantalla")> TipoNovedad
      <DefaultValue(0I), Description("Id del Estado de novedad a filtrar")> IdEstadoNovedad
      <DefaultValue(0I), Description("Id del Método de Resolución de novedad a filtrar")> IdMetodoResolucionNovedad
      <DefaultValue(False), Description("Indica si se aplica el filtro de usuarios")> QuitarFiltroPorUsuario
   End Enum


   Friend WithEvents tsbFiltros As ToolStripButton
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      tsbFiltros = New ToolStripButton()
      '
      'tsbFiltros
      '
      tsbFiltros.Image = My.Resources.filter_data_24
      tsbFiltros.ImageTransparentColor = Color.Magenta
      tsbFiltros.Name = "tsbFiltros"
      tsbFiltros.Size = New Size(65, 26)
      tsbFiltros.Text = "Filtros"

      tstBarra.Items.Insert(tstBarra.Items.IndexOf(tsbPreferencias) + 1, tsbFiltros)
   End Sub
   Private Sub tsbFiltros_Click(sender As Object, e As EventArgs) Handles tsbFiltros.Click
      TryCatched(Sub() FiltersManager1.SeleccionarFiltro())
   End Sub


#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Parametros Is Nothing Then Parametros = New ParametrosLlamador()

      Dim sw As New Stopwatch()
      sw.Start()
      TryCatched(
         Sub()
            If TipoNovedad IsNot Nothing Then
               Text = TipoNovedad.NombreTipoNovedad
               dgvDatos.FindForm().Name = dgvDatos.FindForm().Name + "_" + TipoNovedad.IdTipoNovedad
            End If
         End Sub)

      Try
         _publicos = New Publicos()

         cargando = True

         If Parametros.FechaDesde.HasValue Or Parametros.FechaHasta.HasValue Then
            chbFecha.Checked = True
         End If

         dtpFechaDesde.Value = If(Parametros.FechaDesde, Date.Today)
         dtpFechaHasta.Value = If(Parametros.FechaHasta, Date.Today.UltimoSegundoDelDia())

         If TipoNovedad IsNot Nothing Then
            _tienePermisoParaVerOtrosUsuarios = New Reglas.Usuarios().TienePermisos(TipoNovedad.IdTipoNovedad + "-VerOtrosUsuarios")
            _tienePermisoParaEliminarRegistros = New Reglas.Usuarios().TienePermisos(TipoNovedad.IdTipoNovedad + "-PuedeEliminar")
         End If

         tsbBorrar.Visible = _tienePermisoParaEliminarRegistros

         _publicos.CargaComboUsuariosActivos(cmbUsuarioAlta)

         If Reglas.Publicos.CRMSoloMuestraUsuariosActivos Then
            _publicos.CargaComboUsuariosActivos(cmbUsuarioAsignado)
         Else
            _publicos.CargaComboUsuarios(cmbUsuarioAsignado)
         End If

         If Not String.IsNullOrWhiteSpace(Parametros.IdUsuario) Then
            _usr = New Reglas.Usuarios().GetUno(Parametros.IdUsuario)
         Else
            _usr = New Reglas.Usuarios().GetUno(actual.Nombre)
         End If

         chbUsuarioAsignado.Checked = True
         cmbUsuarioAsignado.SelectedValue = _usr.Id

         If Not _tienePermisoParaVerOtrosUsuarios Then
            chbUsuarioAsignado.Enabled = False
            cmbUsuarioAsignado.Enabled = False
         End If

         _PermiteAbrirMultiplesNovedadesNuevas = Reglas.Publicos.PermiteAbrirMultiplesNovedadesNuevas
         _PermiteAbrirMultiplesNovedadesEditar = Reglas.Publicos.PermiteAbrirMultiplesNovedadesEditar

         Me._extrasSinergia = Reglas.Publicos.ExtrasSinergia

         '#Misma lógica que muestra la solapa Sinergia en DetalleABM.
         If Not _extrasSinergia Then
            cmbAplicacion.Visible = False
            chbAplicacion.Visible = False
            cmbVersion.Visible = False
            chbVersion.Visible = False
         End If

         '# Seteos correspondientes en pantalla según el tipo de CRMNovedad elegido
         ConfiguracionInicialDinamicos()

         _publicos.CargaComboDesdeEnum(cmbFinalizado, GetType(Entidades.Publicos.SiNoTodos))
         cmbFinalizado.SelectedValue = Entidades.Publicos.SiNoTodos.NO

         _publicos.CargaComboDesdeEnum(Me.cmbRevisionAdministrativa, GetType(Entidades.Publicos.SiNoTodos))
         cmbRevisionAdministrativa.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbPriorizado, GetType(Entidades.Publicos.SiNoTodos))
         cmbPriorizado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         _publicos.CargaComboDesdeEnum(cmbTipoFechaFiltro, GetType(Entidades.CRMNovedad.TipoFechaFiltro))
         cmbTipoFechaFiltro.SelectedValue = Entidades.CRMNovedad.TipoFechaFiltro.FechaNovedad

         _publicos.CargaComboAplicacionesEntidad(cmbAplicacion)
         _publicos.CargaComboVersiones(cmbVersion, String.Empty)

         '_publicos.CargaComboCRMEstadosNovedades(cmbEstadoNovedad, TipoNovedad.IdTipoNovedad)
         '_publicos.CargaComboCRMCategoriasNovedades(cmbCategoriaNovedad, TipoNovedad.IdTipoNovedad)

         cmbCategoriasNovedad.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True, TipoNovedad.IdTipoNovedad)
         cmbCRMEstados.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True, TipoNovedad.IdTipoNovedad)
         cmbCRMMedios.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True, TipoNovedad.IdTipoNovedad)
         cmbCRMMetodos.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True, TipoNovedad.IdTipoNovedad)
         '_publicos.CargaComboCRMMediosComunicacionesNovedades(cmbMedio, TipoNovedad.IdTipoNovedad)
         '_publicos.CargaComboCRMMetodoResolucionNovedad(cmbMetodoResolucion, TipoNovedad.IdTipoNovedad)
         '-- REQ-30962 --
         _publicos.CargaComboTipoUsuarios(cmbTipoUsuario)

         Me._publicos.CargaComboDesdeEnum(Me.cmbCategoriaReporta, GetType(Entidades.CRMCategoriaNovedad.ComboReporta),  , True)
         Me.chbCategoriaReporta.Visible = Reglas.Publicos.CRMMuestraReportaCategoriasNovedades
         Me.cmbCategoriaReporta.Visible = Reglas.Publicos.CRMMuestraReportaCategoriasNovedades

         If Not TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.SISTEMAS) Then
            cmbAplicacion.Visible = False
            cmbVersion.Visible = False
            chbAplicacion.Visible = False
            chbVersion.Visible = False
         End If

         '# Prioridad del Pendiente
         If TipoNovedad Is Nothing Then
            _publicos.CargaComboCRMTiposNovedades(Me.cmbPrioridad)
         Else
            _publicos.CargaComboCRMPrioridadesNovedades(Me.cmbPrioridad, TipoNovedad.IdTipoNovedad)
         End If


         '############# Proyectos
         _publicos.CargaComboClasificaciones(Me.cmbClasificacionProyecto)
         cmbClasificacionProyecto.SelectedIndex = -1
         _publicos.CargaComboProyectosEstados(Me.cmbEstadoProyecto)
         cmbEstadoProyecto.SelectedIndex = -1

         If TipoNovedadTiene("PROYECTOS") Then
            Me.gbProyecto.Visible = True
            If Parametros.IdProyecto > 0 Then
               chbProyecto.Checked = True
               bscCodigoProyecto.Text = Parametros.IdProyecto.ToString()
               bscCodigoProyecto.PresionarBoton()
               chbProyecto.Enabled = False
               bscCodigoProyecto.Permitido = False
               bscProyecto.Permitido = False
            End If
         End If

         _publicos.CargaComboDesdeEnum(Me.cmbEnGarantia, GetType(Entidades.Publicos.SiNoTodos))
         _publicos.CargaComboDesdeEnum(Me.cmbConPrestamo, GetType(Entidades.Publicos.SiNoTodos))
         _publicos.CargaComboDesdeEnum(Me.cmbEstadoPrestamo, GetType(Entidades.CRMNovedad.EstadosProductosPrestados))

         cmbEnGarantia.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         cmbConPrestamo.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         cmbEstadoPrestamo.SelectedValue = Entidades.CRMNovedad.EstadosProductosPrestados.TODOS

         If TipoNovedad IsNot Nothing AndAlso TipoNovedad.IdTipoNovedad = "SERVICE" Or TipoNovedad.IdTipoNovedad = "VEHICULO" Then
            lblEnGarantia.Visible = True
            lblConPrestamo.Visible = True
            lblEstadoPrestamo.Visible = True
            cmbEnGarantia.Visible = True
            cmbConPrestamo.Visible = True
            cmbEstadoPrestamo.Visible = True
         End If

         If TipoNovedad IsNot Nothing AndAlso TipoNovedad.IdTipoNovedad = Entidades.CRMTipoNovedad.TipoDinamico.VEHICULO.ToString() Then
            pnlVehiculo.Visible = True
         Else
            pnlVehiculo.Visible = False
         End If

         If Parametros.CodigoCliente > 0 Then
            chbCliente.Checked = True
            bscCodigoCliente.Text = Parametros.CodigoCliente.ToString()
            bscCodigoCliente.PresionarBoton()
         End If

         If Parametros.Finalizado.HasValue Then
            cmbFinalizado.SelectedValue = Parametros.Finalizado.Value
         End If

         If Parametros.IdCategoriaNovedad.HasValue Then
            cmbCategoriasNovedad.SelectedValue = Parametros.IdCategoriaNovedad.Value
         End If
         If Parametros.IdEstadoNovedad.HasValue Then
            cmbCRMEstados.SelectedValue = Parametros.IdEstadoNovedad.Value
         End If
         If Parametros.IdMetodoResolucionNovedad.HasValue Then
            cmbCRMMetodos.SelectedValue = Parametros.IdMetodoResolucionNovedad.Value
         End If

         If Not Parametros.IgnoraFiltrosPersonalizados Then FiltersManager1.Refrescar()
         If Parametros.QuitarFiltroPorUsuario Then chbUsuarioAsignado.Checked = False

         _cacheSemaforo = New Reglas.SemaforoVentasUtilidades().GetTodos(Entidades.SemaforoVentaUtilidad.TiposSemaforos.ESTRELLAS)

         '-- REQ-35844.- -----------------------------------------------
         chbSucursal.Visible = False
         cmbSucursal.Visible = False
         If TipoNovedad.VisualizaSucursal = Entidades.CRMTipoNovedad.ColVisualizaSucursalNovedades.Compartida.ToString() Then
            '-- Check Sucursales.- ---
            chbSucursal.Visible = True
            chbSucursal.Checked = False
            '-- Combo sucursales.- ---
            cmbSucursal.Visible = True
            cmbSucursal.Enabled = False
            cmbSucursal.Initializar(False, IdFuncion)
         End If

         '--------------------------------------------------------------

      Catch ex As Exception
         ShowError(ex)
      Finally
         cargando = False
      End Try

      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
      TryCatched(
         Sub()
            If Parametros.AbrirAutomaticamenteSiHaySoloUno AndAlso dgvDatos.Count = 1 Then
               tsbEditar.PerformClick()
               _cerrar = True
               BeginInvoke(New MethodInvoker(AddressOf Close))
            End If
         End Sub)

      sw.Stop()
      'ShowMessage(String.Format("Tiempo de Carga ABM: {0}", sw.Elapsed.ToString()))
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(Sub() CargarMenuContextualGrilla())
      TryCatched(
      Sub()
         grpFiltros.AutoSize = True
         Dim tempSize = grpFiltros.Size
         grpFiltros.AutoSize = False
         grpFiltros.Size = tempSize
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   'Protected Overrides Sub OnHandleCreated(e As EventArgs)
   '   MyBase.OnHandleCreated(e)
   '   Try
   '      If _cerrar Then
   '         Me.Close()
   '      End If
   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try
   'End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CRMNovedadesDetalle(DirectCast(Me.GetEntidad(), Entidades.CRMNovedad), TipoNovedad)
      End If
      Return New CRMNovedadesDetalle(New Eniac.Entidades.CRMNovedad(), TipoNovedad)
   End Function

   Protected Overrides Function AbrirFormularioEditar(detalle As BaseDetalle) As DialogResult
      If _PermiteAbrirMultiplesNovedadesEditar Then
         '>1 permitida
         detalle.MdiParent = MdiParent
         detalle.Show()
         Return DialogResult.Cancel
      Else
         '1 permitida
         Return MyBase.AbrirFormularioEditar(detalle)
      End If
   End Function
   Protected Overrides Sub AbrirFormularioNuevo(detalle As BaseDetalle)
      If _PermiteAbrirMultiplesNovedadesNuevas Then
         '>1 permitida
         detalle.MdiParent = MdiParent
         detalle.Show()
      Else
         '1 permitida
         MyBase.AbrirFormularioNuevo(detalle)
      End If
   End Sub

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Return GetGrillaDetalle(buscarABM:=Nothing)
   End Function
   Protected Overrides Function Buscar(rg As Reglas.Base, bus As Entidades.Buscar) As DataTable
      Return GetGrillaDetalle(bus)
   End Function

   Protected Overrides Sub LimpiarFiltros()
      MyBase.LimpiarFiltros()
      Try
         cargando = True
         Me.RefrescarDatosGrilla()
      Finally
         cargando = False
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.CRMNovedades()
   End Function

   Protected Function GetReglasTipado() As Eniac.Reglas.CRMNovedades
      Return DirectCast(GetReglas(), Eniac.Reglas.CRMNovedades)
   End Function

   Protected Overrides Sub Borrar()
      Try
         If Me.dgvDatos.ActiveCell Is Nothing Then
            If Me.dgvDatos.ActiveRow IsNot Nothing Then
               Me.dgvDatos.ActiveCell = Me.dgvDatos.ActiveRow.Cells(0)
            End If
         End If
         If Me.dgvDatos.ActiveCell IsNot Nothing Then

            '-- REQ-31710.- --
            If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.SERVICE) Then
               If Not ValidaAnticipo() Then
                  Throw New Exception("El registro NO se puede eliminar porque tiene Recibos asociados.")
               End If
            End If
            '-----------------
            If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Dim cl As Reglas.Base = GetReglas()
               _entidad = GetEntidad()
               cl.Borrar(_entidad)

               Me.RefreshGrid()
            End If
         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            MessageBox.Show("El registro NO se puede eliminar porque esta siendo utilizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Try
   End Sub

   '-- REQ-31710.- ---------
   Private Function ValidaAnticipo() As Boolean
      Dim rNovedadesAnticipo = New Reglas.CuentasCorrientes()
      Dim dtNovedades As DataTable

      With dgvDatos.ActiveRow
         dtNovedades = rNovedadesAnticipo.ServicioTecnicoAsociados(.Cells(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()).Value.ToString(),
                                                                   .Cells(Entidades.CRMNovedad.Columnas.Letra.ToString()).Value.ToString(),
                                                                   Short.Parse(.Cells(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()).Value.ToString()),
                                                                   Long.Parse(.Cells(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()).Value.ToString()))
      End With
      Return (dtNovedades.Rows.Count = 0)
   End Function
   '-----------------------
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return GetReglasTipado().GetUno(.Cells(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()).Value.ToString(),
                                         .Cells(Entidades.CRMNovedad.Columnas.Letra.ToString()).Value.ToString(),
                                         Short.Parse(.Cells(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()).Value.ToString()),
                                         Long.Parse(.Cells(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()).Value.ToString()))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      FormatearGrilla(dgvDatos, TipoNovedad, pos:=0)
   End Sub

   Public Overloads Shared Sub FormatearGrilla(grilla As UltraGrid, TipoNovedad As Entidades.CRMTipoNovedad, ByRef pos As Integer)

      grilla.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True

      grilla.DisplayLayout.UseFixedHeaders = True
      grilla.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None

      With grilla.DisplayLayout.Bands(0)

         For Each columna In .Columns
            columna.Hidden = True
         Next

         If Not .Columns.Exists(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1") Then
            .Columns.Add(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1", String.Empty)
         End If

         If Not .Columns.Exists("Ver") Then
            .Columns.Add("Ver", String.Empty)
         End If

         '# Columnas de Auditoría
         If .Columns.Exists("FechaAuditoria") Then
            .Columns("FechaAuditoria").FormatearColumna("Fecha/Hora Auditoría", pos, 120, HAlign.Center, hidden:=True, Formatos.Format.FechaCompleta)
            .Columns("FechaAuditoria_Fecha").FormatearColumna("Fecha Auditoría", pos, 70, HAlign.Center, , Formatos.Format.FechaSinHora)
            .Columns("FechaAuditoria_Hora").FormatearColumna("Hora Auditoría", pos, 60, HAlign.Center, , Formatos.Format.HoraSinFecha)
            .Columns("OperacionAuditoria").FormatearColumna("Oper. Audit.", pos, 40, HAlign.Center)
            .Columns("UsuarioAuditoria").FormatearColumna("Usuario Auditoría", pos, 100, HAlign.Left)
         End If

         'Dim pos As Integer = 0

         .Columns("Ver").FormatearColumna("Ver", pos, 30)
         .Columns("Ver").Style = UltraWinGrid.ColumnStyle.Button
         .Columns("Ver").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always


         .Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").FormatearColumna("", pos, 60)
         .Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").Header.Fixed = True
         .Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").CellActivation = Activation.NoEdit

         .Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString()).FormatearColumna("", 1000, 30, , True)



         .Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()).FormatearColumna("Tipo", pos, 60, , TipoNovedad IsNot Nothing)
         .Columns(Entidades.CRMNovedad.Columnas.Letra.ToString()).FormatearColumna("L.", pos, 25, HAlign.Center)
         .Columns(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()).FormatearColumna("Emisor", pos, 45, HAlign.Right, True)
         .Columns(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()).FormatearColumna("Número", pos, 60, HAlign.Right)
         .Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString()).FormatearColumna("Fecha / Hora", pos, 120, HAlign.Center, hidden:=True)
         .Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         .Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString() + "_Fecha").FormatearColumna("Fecha", pos, 80, HAlign.Center)
         .Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString() + "_Hora").FormatearColumna("Hora", pos, 40, HAlign.Center)

         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES) Then
            'Oculta
            'FormatearColumna(.Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()), "Código", 4, 80, HAlign.Right)
            .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).FormatearColumna("Nombre Cliente", pos, 200)
            .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).FormatearColumna("Nombre de Fantasia", pos, 200)

            If New Reglas.Generales().ExisteTabla("Embarcaciones") Then
               .Columns("NombreEmbarcacion").FormatearColumna("Embarcacion", pos, 200)
            End If

            If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.SERVICE) And TipoNovedad.VisualizaSucursal = Entidades.CRMTipoNovedad.ColVisualizaSucursalNovedades.Compartida.ToString() Then
               .Columns("NombreSucursalNovedad").FormatearColumna("Suc. Última Novedad", pos, 200)
            End If
            .Columns("NombreCategoriaCliente").FormatearColumna("Categoria Cliente", pos, 120)
            .Columns("NombreTipoCliente").FormatearColumna("Tipo Cliente", pos, 120)
            .Columns("IdZonaGeografica").FormatearColumna("Código Z.G.", pos, 80, , True)
            .Columns("NombreZonaGeografica").FormatearColumna("Zona Geográfica", pos, 120)

            .Columns("ClienteValorizacionEstrellasResuelto").FormatearColumna("Estrellas", pos, 55, HAlign.Right, , "N2")

         End If

         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.VEHICULO) Then
            .Columns("PatenteVehiculo").FormatearColumna("Patente", pos, 80)
            .Columns("IdMarcaVehiculo").OcultoPosicion(hidden:=True, pos)
            .Columns("NombreMarcaVehiculo").FormatearColumna("Marca Vehículo", pos, 200)
            .Columns("IdModeloVehiculo").OcultoPosicion(hidden:=True, pos)
            .Columns("NombreModeloVehiculo").FormatearColumna("Modelo Vehículo", pos, 200)
            .Columns("AnioPatentamiento").FormatearColumna("Año", pos, 60, HAlign.Right)
            .Columns("ColorVehiculo").FormatearColumna("Color", pos, 120)
         End If

         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.PROSPECTOS) Then
            'Oculta
            'FormatearColumna(.Columns("CodigoProspecto"), "Código", 7, 80, HAlign.Right)
            .Columns("NombreProspecto").FormatearColumna("Nombre Prospecto", pos, 200)
            .Columns("NombreDeFantasiaProspecto").FormatearColumna("Nombre de Fantasia", pos, 200)
            .Columns("NombreCategoriaProspecto").FormatearColumna("Categoria Prospecto", pos, 120)
            .Columns("NombreTipoProspecto").FormatearColumna("Tipo Prospecto", pos, 120)

            .Columns("CantidadDePCsProspecto").FormatearColumna("Cantidad De PCs", pos, 80, HAlign.Right)
            .Columns("CantidadMovilProspecto").FormatearColumna("Cantidad Lic. Movil", pos, 80, HAlign.Right)
         End If

         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.PROVEEDORES) Then
            .Columns("NombreProveedor").FormatearColumna("Nombre Proveedor", pos, 200)
            .Columns("NombreCategoriaProveedor").FormatearColumna("Categoria Proveedor", pos, 120)
         End If

         .Columns(Entidades.CRMNovedad.Columnas.Interlocutor.ToString()).FormatearColumna("Interlocutor", pos, 80)

         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.PROYECTOS) Then
            .Columns(Entidades.CRMNovedad.Columnas.IdProyecto.ToString()).FormatearColumna("Cod. Proyecto", pos, 70, HAlign.Right)
            .Columns("NombreProyecto").FormatearColumna("Proyecto", pos, 130, HAlign.Left)
            .Columns(Entidades.Proyecto.Columnas.IdPrioridadProyecto.ToString()).FormatearColumna("Prioridad Proyecto", pos, 70, HAlign.Center)
            .Columns(Entidades.Proyecto.Columnas.IdClasificacion.ToString()).FormatearColumna("Cod. Clasificación", pos, 50, HAlign.Right, True)
            .Columns("NombreClasificacion").FormatearColumna("Clasificación Proyecto", pos, 130, HAlign.Left)
            .Columns(Entidades.Proyecto.Columnas.IdEstado.ToString()).FormatearColumna("Cod. Estado", pos, 50, HAlign.Right, True)
            .Columns("NombreEstado").FormatearColumna("Estado Proyecto", pos, 130, HAlign.Left)
         End If

         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.SISTEMAS) Then
            .Columns(Entidades.CRMNovedad.Columnas.IdSistema.ToString()).FormatearColumna("Sistema", pos, 80)
         End If

         .Columns(Entidades.CRMNovedad.Columnas.Descripcion.ToString()).FormatearColumna("Descripción", pos, 150)

         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.SERVICE) Then
            .Columns(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).FormatearColumna("Estado", 2, 80)
         Else
            .Columns(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).FormatearColumna("Estado", pos, 80)
         End If

         .Columns(Entidades.CRMNovedad.Columnas.Contador1.ToString()).FormatearColumna("Cont. 1", pos, 60, HAlign.Right)
         .Columns(Entidades.CRMNovedad.Columnas.Contador2.ToString()).FormatearColumna("Cont. 2", pos, 60, HAlign.Right)
         .Columns(Entidades.CRMNovedad.Columnas.IdUsuarioAsignado.ToString()).FormatearColumna("Usuario Asignado", pos, 70)
         .Columns(Entidades.CRMNovedad.Columnas.IdUsuarioResponsable.ToString()).FormatearColumna("Usuario Responsable", pos, 80)
         .Columns(Entidades.CRMPrioridadNovedad.Columnas.NombrePrioridadNovedad.ToString()).FormatearColumna("Prioridad", pos, 70)

         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.SERVICE) Then
            .Columns(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()).FormatearColumna("Categoria", 3, 110)
         Else
            .Columns(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()).FormatearColumna("Categoria", pos, 110)
         End If

         .Columns(Entidades.CRMCategoriaNovedad.Columnas.Reporta.ToString()).FormatearColumna("Reporta", pos, 60, HAlign.Center, hidden:=True)

         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.METODORESOLUCION) Then
            .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString()).FormatearColumna("Resolución", pos, 80)
         End If

         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.MOTIVOS) Then
            .Columns(Entidades.CRMMotivoNovedad.Columnas.NombreMotivoNovedad.ToString()).FormatearColumna("Motivo", pos, 80)
         End If
         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.APLICACIONTERCERO) Then
            .Columns("NombreAplicacionTerceros").FormatearColumna("Software Actual", pos, 80)
         End If

         .Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString()).FormatearColumna("Prox. Contacto", pos, 120, HAlign.Center, hidden:=True)
         .Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         .Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString() + "_Fecha").FormatearColumna("Fecha Prox. Contacto", pos, 80, HAlign.Center)
         .Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString() + "_Hora").FormatearColumna("Hora Prox. Contacto", pos, 40, HAlign.Center)

         .Columns(Entidades.CRMMedioComunicacionNovedad.Columnas.NombreMedioComunicacionNovedad.ToString()).FormatearColumna("Medio", pos, 100)

         If TipoNovedad IsNot Nothing AndAlso TipoNovedad.UnidadDeMedida <> "%" Then
            .Columns(Entidades.CRMNovedad.Columnas.Avance.ToString()).FormatearColumna(TipoNovedad.UnidadDeMedida, pos, 50, HAlign.Right)
         Else
            .Columns(Entidades.CRMNovedad.Columnas.Avance.ToString()).FormatearColumna("% Av.", pos, 45, HAlign.Right)
         End If

         .Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString()).FormatearColumna("Fecha/Hora Estado", pos, 80, HAlign.Center, hidden:=True)
         .Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         .Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString() + "_Fecha").FormatearColumna("Fecha Estado", pos, 80, HAlign.Center)
         .Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString() + "_Hora").FormatearColumna("Hora Estado", pos, 45, HAlign.Center)

         .Columns(Entidades.CRMNovedad.Columnas.FechaEntregado.ToString()).FormatearColumna("Fecha/Hora Reparado", pos, 80, HAlign.Center, hidden:=True)
         .Columns(Entidades.CRMNovedad.Columnas.FechaEntregado.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         .Columns(Entidades.CRMNovedad.Columnas.FechaEntregado.ToString() + "_Fecha").FormatearColumna("Fecha Reparado", pos, 80, HAlign.Center)
         .Columns(Entidades.CRMNovedad.Columnas.FechaEntregado.ToString() + "_Hora").FormatearColumna("Hora Reparado", pos, 40, HAlign.Center)

         .Columns(Entidades.CRMNovedad.Columnas.IdEstadoNovedadEntregado.ToString()).OcultoPosicion(True, pos)
         .Columns("FinalizadoEntregado").OcultoPosicion(True, pos)
         .Columns("ColorEstadoEntregado").OcultoPosicion(True, pos)
         .Columns("NombreEstadoNovedadEntregado").FormatearColumna("Estado Reparado", pos, 80)
         .Columns(Entidades.CRMNovedad.Columnas.IdUsuarioEntregado.ToString()).FormatearColumna("Usuario Reparado", pos, 70)

         .Columns(Entidades.CRMNovedad.Columnas.IdEstadoNovedadFinalizado.ToString()).OcultoPosicion(True, pos)
         .Columns("FinalizadoFinalizado").OcultoPosicion(True, pos)
         .Columns("ColorEstadoFinalizado").OcultoPosicion(True, pos)
         .Columns("NombreEstadoNovedadFinalizado").FormatearColumna("Estado Entregado", pos, 80)
         .Columns(Entidades.CRMNovedad.Columnas.IdUsuarioFinalizado.ToString()).FormatearColumna("Usuario Entregado", pos, 70)

         .Columns(Entidades.CRMNovedad.Columnas.FechaFinalizado.ToString()).FormatearColumna("Fecha/Hora Entregado", pos, 80, HAlign.Center, hidden:=True)
         .Columns(Entidades.CRMNovedad.Columnas.FechaFinalizado.ToString()).Format = "dd/MM/yyyy HH:mm:ss"
         .Columns(Entidades.CRMNovedad.Columnas.FechaFinalizado.ToString() + "_Fecha").FormatearColumna("Fecha Entregado", pos, 80, HAlign.Center)
         .Columns(Entidades.CRMNovedad.Columnas.FechaFinalizado.ToString() + "_Hora").FormatearColumna("Hora Entregado", pos, 40, HAlign.Center)

         .Columns(Entidades.CRMNovedad.Columnas.IdUsuarioEstadoNovedad.ToString()).FormatearColumna("Usuario Estado", pos, 80)
         .Columns(Entidades.CRMNovedad.Columnas.IdUsuarioAlta.ToString()).FormatearColumna("Usuario Alta", pos, 80)
         .Columns(Entidades.CRMNovedad.Columnas.Priorizado.ToString()).FormatearColumna("Priorizado", pos, 65)

         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.FUNCIONES) Then
            .Columns(Entidades.CRMNovedad.Columnas.IdFuncion.ToString()).FormatearColumna("Código Función", pos, 100)
            .Columns("NombreFuncion").FormatearColumna("Nombre Función", pos, 200)
         End If

         If Reglas.Publicos.CRMMuestraSolapaMasInfo Then
            .Columns(Entidades.CRMNovedad.Columnas.IdTipoNovedadPadre.ToString()).FormatearColumna("Padre Tipo", pos, 50, HAlign.Left)
            .Columns(Entidades.CRMNovedad.Columnas.IdNovedadPadre.ToString()).FormatearColumna("Padre Nro.", pos, 50, HAlign.Right)

            .Columns("NombrePrioridadNovedadPadre").FormatearColumna("Prioridad Padre", pos, 70)
            .Columns("NombreCategoriaNovedadPadre").FormatearColumna("Categoria Padre", pos, 110)
            .Columns("NombreEstadoNovedadPadre").FormatearColumna("Estado Padre", pos, 80)
            .Columns("FinalizadoPadre").FormatearColumna("Finalizado Padre", pos, 65)
            '.Columns("ColorCategoriaPadre")
            '.Columns("ColorEstadoPadre")
         End If

         If Reglas.Publicos.ExtrasSinergia Then
            .Columns(Entidades.CRMNovedad.Columnas.Version.ToString()).FormatearColumna("Version", pos, 50, HAlign.Left)
            .Columns(Entidades.CRMNovedad.Columnas.VersionFecha.ToString()).FormatearColumna("Version Fecha", pos, 80, HAlign.Center)
            .Columns(Entidades.CRMNovedad.Columnas.FechaInicioPlan.ToString()).FormatearColumna("Inicio Plan", pos, 80, HAlign.Center)
            .Columns(Entidades.CRMNovedad.Columnas.FechaFinPlan.ToString()).FormatearColumna("Fin Plan", pos, 80, HAlign.Center)
            .Columns(Entidades.CRMNovedad.Columnas.TiempoEstimado.ToString()).FormatearColumna("Tiempo Estimado", pos, 80, HAlign.Right)
            .Columns("CantidadHorasHijos").FormatearColumna("Horas Cargadas", pos, 80, HAlign.Right)
            .Columns(Entidades.CRMNovedad.Columnas.EtiquetaNovedad.ToString()).FormatearColumna("Etiquetas", pos, 100)
            .Columns(Entidades.CRMNovedad.Columnas.RequiereTesteo.ToString()).FormatearColumna("Requiere Testeo", pos, 60, HAlign.Center)
            .Columns(Entidades.Cliente.Columnas.ActualizadorFunciona.ToString()).FormatearColumna("Funciona Actualizador", pos, 80)

         End If

         .Columns("ComentarioSeguimientoPrincipal").FormatearColumna("Comentario", pos, 200)

         .Columns(Entidades.CRMNovedad.Columnas.Cantidad.ToString()).FormatearColumna("Cantidad", pos, 80, HAlign.Right)

         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.SERVICE) Then

            If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.SERVICELUGARCOMPRA) Then
               .Columns(Entidades.CRMNovedad.Columnas.ServiceLugarCompra.ToString()).FormatearColumna("Lugar Compra", pos, 100)
               .Columns(Entidades.CRMNovedad.Columnas.ServiceLugarCompraFecha.ToString()).FormatearColumna("Fecha Compra", pos, 70, HAlign.Center, , "dd/MM/yyyy")
               .Columns(Entidades.CRMNovedad.Columnas.ServiceLugarCompraTipoComprobante.ToString()).FormatearColumna("Comprobante Compra", pos, 100)
               .Columns(Entidades.CRMNovedad.Columnas.ServiceLugarCompraNumeroComprobante.ToString()).FormatearColumna("Número Compra", pos, 100)

            Else
               .Columns(Entidades.CRMNovedad.Columnas.IdSucursalService.ToString()).FormatearColumna("Suc. Service", pos, 80, HAlign.Center)
               .Columns(Entidades.CRMNovedad.Columnas.IdTipoComprobanteService.ToString()).FormatearColumna("Comprob. Service", pos, 100)
               .Columns(Entidades.CRMNovedad.Columnas.LetraService.ToString()).FormatearColumna("Letra Service", pos, 100, HAlign.Center)
               .Columns(Entidades.CRMNovedad.Columnas.CentroEmisorService.ToString()).FormatearColumna("CE Service", pos, 100, HAlign.Center)
               .Columns(Entidades.CRMNovedad.Columnas.NumeroComprobanteService.ToString()).FormatearColumna("Numero Comp. Service", pos, 100, HAlign.Right)
            End If


            .Columns(Entidades.CRMNovedad.Columnas.IdProducto.ToString()).FormatearColumna("Código Producto", pos, 100)
            .Columns("NombreProducto").FormatearColumna("Producto", pos, 200)
            .Columns("NombreMarcaService").FormatearColumna("Marca Producto", pos, 100, , True)
            .Columns("NombreMarcaProducto").FormatearColumna("Marca", pos, 100)
            .Columns("NombreModeloService").FormatearColumna("Modelo Producto", pos, 100, , True)
            .Columns("NombreModeloProducto").FormatearColumna("Modelo", pos, 100)

            .Columns(Entidades.CRMNovedad.Columnas.CantidadProducto.ToString()).FormatearColumna("Cantidad Producto", pos, 100, HAlign.Right)
            .Columns(Entidades.CRMNovedad.Columnas.CostoReparacion.ToString()).FormatearColumna("Costo Reparación", pos, 100, HAlign.Right)
            .Columns(Entidades.CRMNovedad.Columnas.IdProductoPrestado.ToString()).FormatearColumna("Código Producto Prest.", pos, 100)
            .Columns("NombreProductoPrestado").FormatearColumna("Producto Prestado", pos, 200)
            .Columns(Entidades.CRMNovedad.Columnas.CantidadProductoPrestado.ToString()).FormatearColumna("Cant.Producto Prestado", pos, 100, HAlign.Right)
            .Columns(Entidades.CRMNovedad.Columnas.NroSerieProductoPrestado.ToString()).FormatearColumna("Nro. Serie Producto Prestado", pos, 120, HAlign.Left)
            .Columns(Entidades.CRMNovedad.Columnas.ProductoPrestadoDevuelto.ToString()).FormatearColumna("Devuelto", pos, 60)
            .Columns("CodigoProveedorService").FormatearColumna("Código Proveedor", pos, 100)
            .Columns("NombreProveedorService").FormatearColumna("Proveedor", pos, 200)
            .Columns("NroDeSerie").FormatearColumna("Nro. Serie", pos, 200)
            .Columns("TieneGarantiaService").FormatearColumna("Tiene Garantía", pos, 55)
            .Columns("UbicacionService").FormatearColumna("Ubicación", pos, 80)
         End If
         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.PRODUCTOS) Then
            .Columns(Entidades.CRMNovedad.Columnas.IdProductoNovedad.ToString()).FormatearColumna("Código Producto", pos, 100)
            .Columns("NombreProductoCalidad").FormatearColumna("Producto", pos, 200)
         End If
         If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.OBSERVACION) Then
            .Columns("Observacion").FormatearColumna("Observación", pos, 200)
         End If
         If .Columns.Exists("PrioridadParaPriorizar") AndAlso TipoNovedad IsNot Nothing AndAlso TipoNovedad.IdTipoNovedad = "PENDIENTE" Then
            .Columns("PrioridadParaPriorizar").FormatearColumna("Prioridad para Priorizar", pos, 70, HAlign.Right)
         End If



      End With

      grilla.AgregarFiltroEnLinea({Entidades.Cliente.Columnas.NombreCliente.ToString(),
                                     Entidades.Cliente.Columnas.NombreDeFantasia.ToString(),
                                     "NombreProspecto",
                                     "NombreDeFantasiaProspecto",
                                     "NombreProveedor",
                                     Entidades.CRMNovedad.Columnas.Interlocutor.ToString(),
                                     Entidades.CRMNovedad.Columnas.Descripcion.ToString(),
                                     Entidades.CRMNovedad.Columnas.EtiquetaNovedad.ToString(),
                                     "NombreFuncion"})

      '# Agrego totales suma a las columnas de estimación y horas asignadas
      AgregarTotalesSuma(grilla, {"CantidadHorasHijos",
                                  Entidades.CRMNovedad.Columnas.TiempoEstimado.ToString(),
                                  Entidades.CRMNovedad.Columnas.Cantidad.ToString(),
                                  Entidades.CRMNovedad.Columnas.Contador1.ToString(),
                                  Entidades.CRMNovedad.Columnas.Contador2.ToString(),
                                  Entidades.CRMNovedad.Columnas.CantidadProducto.ToString(),
                                  Entidades.CRMNovedad.Columnas.CostoReparacion.ToString(),
                                  Entidades.CRMNovedad.Columnas.CantidadProductoPrestado.ToString()})

      grilla.DisplayLayout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False

      'If TipoNovedad IsNot Nothing AndAlso TipoNovedad.UnidadDeMedida <> "%" Then
      '   CargarColumnasASumar(grilla)
      'End If

   End Sub

   Public Overloads Shared Sub InitializeRow(row As UltraGridRow, TipoNovedad As Entidades.CRMTipoNovedad, _cacheSemaforo As List(Of Entidades.SemaforoVentaUtilidad))
      If row IsNot Nothing Then
         If row.Cells.Exists(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1") Then

            If Not String.IsNullOrWhiteSpace(row.Cells(Entidades.CRMNovedad.Columnas.BanderaColor.ToString()).Value.ToString()) Then
               Dim color = Drawing.Color.FromArgb(Integer.Parse(row.Cells(Entidades.CRMNovedad.Columnas.BanderaColor.ToString()).Value.ToString()))
               row.Cells(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").Color(color, color)

               Dim nombreColor As String = Entidades.CRMNovedad.NombreBanderaColor(color)
               row.Cells(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").Value = nombreColor
            End If
         End If

         If IsNumeric(row.Cells("ColorEstado").Value) Then
            Dim color = Drawing.Color.FromArgb(Integer.Parse(row.Cells("ColorEstado").Value.ToString()))
            row.Cells(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).Color(Nothing, color)

         End If

         If IsNumeric(row.Cells("ColorCategoria").Value) Then
            Dim color = Drawing.Color.FromArgb(Integer.Parse(row.Cells("ColorCategoria").Value.ToString()))
            row.Cells(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()).Color(Nothing, color)

         End If

         If IsNumeric(row.Cells("ColorMedio").Value) Then
            Dim color = Drawing.Color.FromArgb(Integer.Parse(row.Cells("ColorMedio").Value.ToString()))
            row.Cells(Entidades.CRMMedioComunicacionNovedad.Columnas.NombreMedioComunicacionNovedad.ToString()).Color(Nothing, color)

         End If

         If IsNumeric(row.Cells("ColorCategoriaPadre").Value) Then
            Dim color = Drawing.Color.FromArgb(row.Cells("ColorCategoriaPadre").ValorAs(Of Integer)())
            row.Cells("NombreCategoriaNovedadPadre").Color(Nothing, color)
         End If

         If IsNumeric(row.Cells("ColorEstadoPadre").Value) Then
            Dim color = Drawing.Color.FromArgb(row.Cells("ColorEstadoPadre").ValorAs(Of Integer)())
            row.Cells("NombreEstadoNovedadPadre").Color(Nothing, color)
         End If

         If IsNumeric(row.Cells("ColorEstadoEntregado").Value) Then
            Dim color = Drawing.Color.FromArgb(row.Cells("ColorEstadoEntregado").ValorAs(Of Integer)())
            row.Cells("NombreEstadoNovedadEntregado").Color(Nothing, color)
         End If

         If IsNumeric(row.Cells("ColorEstadoFinalizado").Value) Then
            Dim color = Drawing.Color.FromArgb(row.Cells("ColorEstadoFinalizado").ValorAs(Of Integer)())
            row.Cells("NombreEstadoNovedadFinalizado").Color(Nothing, color)
         End If

         If IsNumeric(row.Cells("ClienteValorizacionEstrellasResuelto").Value) Then
            Dim estrellas = row.Cells("ClienteValorizacionEstrellasResuelto").ValorAs(0D)
            Dim semaforo = If(_cacheSemaforo Is Nothing, Nothing, _cacheSemaforo.Where(Function(s) s.PorcentajeHasta >= estrellas).OrderBy(Function(s) s.PorcentajeHasta).FirstOrDefault())
            If semaforo IsNot Nothing Then
               row.Cells("ClienteValorizacionEstrellasResuelto").Color(Color.FromArgb(semaforo.ColorLetra), Color.FromArgb(semaforo.ColorSemaforo))
            Else
               row.Cells("ClienteValorizacionEstrellasResuelto").Color(Nothing, Nothing)
            End If
         End If

      End If
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

#End Region

   'Private Sub tsCmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tsCmbEstado.SelectedIndexChanged, tsCmbUsuarioAsignado.SelectedIndexChanged
   '   Try
   '      If Not cargando Then Buscar()
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Private Sub dgvDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      TryCatched(Sub() InitializeRow(e.Row, TipoNovedad, _cacheSemaforo))
   End Sub

   Private Sub dgvDatos_ClickCellButton(sender As Object, e As CellEventArgs) Handles dgvDatos.ClickCellButton
      TryCatched(
            Sub()
               If e.Cell.Column.Header.Caption = "Ver" Then
                  Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
                  If dr IsNot Nothing Then
                     With dgvDatos.FilaSeleccionada(Of DataRow)()
                        Dim novedadImprimir = GetReglasTipado().GetUno(.Field(Of String)(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()),
                                                                    .Field(Of String)(Entidades.CRMNovedad.Columnas.Letra.ToString()),
                                                                    .Field(Of Short)(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()),
                                                                    .Field(Of Long)(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()))
                        '# Impresión de CRM
                        Dim rNovedadesImpresion = New CRMNovedadesImpresion(novedadImprimir)
                        rNovedadesImpresion.ImprimirNovedad()
                     End With
                  End If
               End If
            End Sub)
   End Sub

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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            If Modo.HasValue Then
               Me.CargarDatosCliente(e.FilaDevuelta)
            Else
               If TipoNovedadTiene("PROVEEDORES") Then
                  Me.CargarDatosProveedor(e.FilaDevuelta)
               End If
            End If
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            If Modo.HasValue Then
               Me.CargarDatosCliente(e.FilaDevuelta)
            Else
               If TipoNovedadTiene("PROVEEDORES") Then
                  Me.CargarDatosProveedor(e.FilaDevuelta)
               End If
            End If
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbUsuarioAsignado_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuarioAsignado.CheckedChanged
      Try
         Me.cmbUsuarioAsignado.Enabled = Me.chbUsuarioAsignado.Checked
         If Not Me.chbUsuarioAsignado.Checked Then
            Me.cmbUsuarioAsignado.SelectedIndex = -1
         Else
            If Me.cmbUsuarioAsignado.Items.Count > 0 Then
               Me.cmbUsuarioAsignado.SelectedIndex = 0
            End If
         End If
         Me.cmbUsuarioAsignado.Focus()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   'Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs)

   '   Try
   '      Me.cmbCategoriaNovedad.Enabled = Me.chbCategoria.Checked
   '      '   Me.cmbCategoriasNovedad.Enabled = Me.chbCategoria.Checked
   '      If Not Me.chbCategoria.Checked Then
   '         Me.cmbCategoriaNovedad.SelectedIndex = -1
   '         'Me.cmbCategoriasNovedad.SelectedIndex = -1
   '      Else
   '         If Me.cmbCategoriaNovedad.Items.Count > 0 Then
   '            Me.cmbCategoriaNovedad.SelectedIndex = 0
   '         End If
   '         '  If Me.cmbCategoriasNovedad.Items.Count > 0 Then
   '         '  Me.cmbCategoriasNovedad.SelectedIndex = 0
   '         ' End If
   '         Me.cmbCategoriaNovedad.Focus()
   '         '   Me.cmbCategoriasNovedad.Focus()
   '      End If

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try

   'End Sub

   Private Sub chbCategoriaReporta_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriaReporta.CheckedChanged

      Try
         Me.cmbCategoriaReporta.Enabled = Me.chbCategoriaReporta.Checked
         If Not Me.chbCategoriaReporta.Checked Then
            Me.cmbCategoriaReporta.SelectedIndex = -1
         Else
            If Me.cmbCategoriaReporta.Items.Count > 0 Then
               Me.cmbCategoriaReporta.SelectedIndex = 0
            End If
            Me.cmbCategoriaReporta.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   'Private Sub chbEstado_CheckedChanged(sender As Object, e As EventArgs)
   '   Try
   '      Me.cmbEstadoNovedad.Enabled = Me.chbEstado.Checked
   '      If Not Me.chbEstado.Checked Then
   '         Me.cmbEstadoNovedad.SelectedIndex = -1
   '      Else
   '         If Me.cmbEstadoNovedad.Items.Count > 0 Then
   '            Me.cmbEstadoNovedad.SelectedIndex = 0
   '         End If
   '         Me.cmbEstadoNovedad.Focus()
   '      End If

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpFechaDesde, dtpFechaHasta))
   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      bscCodigoCliente.Enabled = Me.chbCliente.Checked
      bscCliente.Enabled = Me.chbCliente.Checked


      bscCodigoCliente.Text = String.Empty
      bscCodigoCliente.Tag = Nothing
      bscCliente.Text = String.Empty

      bscCodigoCliente.Focus()

   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      bscCliente.Text = dr.Cells("Nombre" + Modo.Value.ToString()).Value.ToString()
      bscCodigoCliente.Text = dr.Cells("Codigo" + Modo.Value.ToString()).Value.ToString()
      bscCodigoCliente.Tag = dr.Cells("Id" + Modo.Value.ToString()).Value.ToString()

   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)

      bscCliente.Text = dr.Cells("NombreProveedor").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoProveedor").Value.ToString()
      bscCodigoCliente.Tag = dr.Cells("IdProveedor").Value.ToString()

   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            Dim sModo As String = String.Empty
            If Modo.HasValue Then
               sModo = Modo.ToString()
            Else
               If TipoNovedadTiene("PROVEEDORES") Then
                  sModo = "Proveedor"
               End If
            End If
            MessageBox.Show(String.Format("ATENCION: NO seleccionó un {0} aunque activó ese Filtro.", Modo.ToString()), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If
         If Me.chbNumero.Checked And Me.txtNumero.Text = "0" Then
            MessageBox.Show("ATENCION: No ingreso un número de Novedad aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
         If Me.chbFuncionNuevo.Checked And Not Me.bscCodigoFuncionNuevo.Selecciono And Not Me.bscFuncionNuevo.Selecciono Then
            MessageBox.Show("ATENCION: No seleccionó una Funcion aunque activó ese Filtro.")
            Exit Sub
         End If
         'If Me.chbMedio.Checked = True AndAlso Me.cmbMedio.SelectedIndex = -1 Then
         '   ShowMessage("ATENCION: No seleccionó un Medio aunque activó ese Filtro.")
         '   Exit Sub
         'End If
         If Me.chbProyecto.Checked AndAlso (Not Me.bscCodigoProyecto.Selecciono OrElse Not Me.bscProyecto.Selecciono) Then
            ShowMessage("ATENCION: No ingreso un número de Proyecto aunque activó ese Filtro.")
            Exit Sub
         End If
         If Me.chbPrioridad.Checked AndAlso Me.cmbPrioridad.SelectedIndex = -1 Then
            ShowMessage("ATENCION: No seleccionó una prioridad aunque activó ese Filtro.")
            Me.cmbPrioridad.Focus()
            Exit Sub
         End If
         If Me.chbEstadoProyecto.Checked AndAlso Me.cmbEstadoProyecto.SelectedIndex = -1 Then
            ShowMessage("ATENCION: No seleccionó un estado para el Proyecto aunque activó ese Filtro.")
            Me.cmbEstadoProyecto.Focus()
            Exit Sub
         End If
         If Me.chbClasificacionProyecto.Checked AndAlso Me.cmbClasificacionProyecto.SelectedIndex = -1 Then
            ShowMessage("ATENCION: No seleccionó una clasificación para el Proyecto aunque activó ese Filtro.")
            Me.cmbClasificacionProyecto.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle(GetBuscar())

         dgvDatos.AgregarTotalesSuma({Entidades.CRMNovedad.Columnas.Cantidad.ToString()})

         If dgvDatos.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   Private Function GetGrillaDetalle(buscarABM As Entidades.Buscar) As DataTable
      Dim idCliente As Long = 0
      Dim idProspecto As Long = 0
      Dim idProveedor As Long = 0
      Dim idNovedad As Integer = 0
      Dim idNovedadPadre As Long = 0

      If Me.chbCliente.Checked Then
         If Modo.HasValue Then
            If Modo.Value = Entidades.Cliente.ModoClienteProspecto.Cliente Then
               idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            Else
               idProspecto = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            End If
         Else
            If TipoNovedadTiene("PROVEEDORES") Then
               idProveedor = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
            End If
         End If
      End If

      If Me.chbNumero.Checked Then
         idNovedad = Integer.Parse(Me.txtNumero.Text)
      End If
      If Me.chbNumeroPadre.Checked Then
         idNovedadPadre = Integer.Parse(Me.txtNumeroPadre.Text)
      End If

      Dim fechaDesde As Date? = Nothing
      If chbFecha.Checked Then fechaDesde = dtpFechaDesde.Value
      Dim fechaHasta As Date? = Nothing
      If chbFecha.Checked Then fechaHasta = dtpFechaHasta.Value

      '# Medio de Comunicación
      Dim medio As Integer = 0
      'If Me.chbMedio.Checked Then
      '   medio = Integer.Parse(Me.cmbMedio.SelectedValue.ToString())
      'End If

      '# Proyecto
      Dim idProyecto As Integer = 0
      If Me.chbProyecto.Checked Then
         idProyecto = Integer.Parse(Me.bscCodigoProyecto.Text)
      End If

      '# Prioridad del Pendiente
      Dim idPrioridad As Integer = 0
      If Me.chbPrioridad.Checked Then
         idPrioridad = Integer.Parse(Me.cmbPrioridad.SelectedValue.ToString())
      End If

      '# Prioridad del Proyecto
      Dim idPrioridadProyectoDesde As Decimal = 0
      Dim idPrioridadProyectoHasta As Decimal = 0
      If Me.chbPrioridadProyecto.Checked Then
         idPrioridadProyectoDesde = Me.nudPrioridadDesde.Value
         idPrioridadProyectoHasta = Me.nudPrioridadHasta.Value
      End If

      '# Estado del Proyecto
      Dim idEstadoProyecto As Integer = 0
      If Me.chbEstadoProyecto.Checked Then
         idEstadoProyecto = Integer.Parse(Me.cmbEstadoProyecto.SelectedValue.ToString())
      End If

      '# Tipo de Usuario del Proyecto
      Dim idTipoUsuario As Integer = 0
      If Me.chbTipoUsuario.Checked Then
         idTipoUsuario = Integer.Parse(Me.cmbTipoUsuario.SelectedValue.ToString())
      End If

      '# Clasificación del Proyecto
      Dim idClasificacionProyecto As Integer = 0
      If Me.chbClasificacionProyecto.Checked Then
         idClasificacionProyecto = Integer.Parse(Me.cmbClasificacionProyecto.SelectedValue.ToString())
      End If
      '-- REQ-35844.- --------------------------
      Dim sucursales As Entidades.Sucursal() = Nothing
      If TipoNovedad.VisualizaSucursal = Entidades.CRMTipoNovedad.ColVisualizaSucursalNovedades.Compartida.ToString() And chbSucursal.Checked And cmbSucursal.SelectedIndex <> 0 Then
         sucursales = cmbSucursal.GetSucursales()
      End If
      '-----------------------------------------

      Return GetReglasTipado().GetNovedades(fechaDesde, fechaHasta, cmbTipoFechaFiltro.ValorSeleccionado(Of Entidades.CRMNovedad.TipoFechaFiltro),
                                            TipoNovedad.IdTipoNovedad,
                                            buscarABM,
                                            cmbCategoriasNovedad.GetCategorias(TipoNovedad.IdTipoNovedad, True),
                                            cmbCRMEstados.GetEstado(TipoNovedad.IdTipoNovedad, True), cmbCRMMedios.GetMedio(TipoNovedad.IdTipoNovedad, True), cmbCRMMetodos.GetMetodos(TipoNovedad.IdTipoNovedad, True),
                                            If(chbUsuarioAsignado.Checked, Me.cmbUsuarioAsignado.SelectedValue.ToString(), String.Empty),
                                            idNovedad:=idNovedad, idNovedadPadre:=idNovedadPadre,
                                            idCliente:=idCliente, idProspecto:=idProspecto, idProveedor:=idProveedor,
                                            idPrioridadNovedad:=idPrioridad,
                                            idUsuarioAlta:=If(chbUsuarioAlta.Checked, cmbUsuarioAlta.ValorSeleccionado(Of String), String.Empty),
                                            finalizado:=Me.cmbFinalizado.SelectedValue.ToString(),
                                            idProyecto:=idProyecto, revisionAdministrativa:=cmbRevisionAdministrativa.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
                                            idAplicacion:=If(chbAplicacion.Checked, cmbAplicacion.SelectedValue.ToString(), String.Empty),
                                            nroVersion:=If(chbVersion.Checked, cmbVersion.SelectedValue.ToString, String.Empty),
                                            descripcion:=String.Empty,
                                            priorizado:=DirectCast(cmbPriorizado.SelectedValue, Entidades.Publicos.SiNoTodos),
                                            usaOrdenamientoDelTablero:=True,
                                            idFuncion:=Me.bscCodigoFuncionNuevo.Text,
                                            prioridadDelProyectoDesde:=idPrioridadProyectoDesde,
                                            prioridadDelProyectoHasta:=idPrioridadProyectoHasta,
                                            estadoDelProyecto:=idEstadoProyecto,
                                            clasificacionDelProyecto:=idClasificacionProyecto,
                                            enGarantia:=cmbEnGarantia.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
                                            enPrestamo:=cmbConPrestamo.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
                                            estadoPrestamo:=cmbEstadoPrestamo.ValorSeleccionado(Of Entidades.CRMNovedad.EstadosProductosPrestados)(),
                                            tipoUsuario:=idTipoUsuario,
                                            visualizaSucursal:=TipoNovedad.VisualizaSucursal,
                                            sucursales:=sucursales,
                                            categoriaReporta:=If(chbCategoriaReporta.Checked, Me.cmbCategoriaReporta.SelectedValue.ToString(), "TODOS"),
                                            If(chbVehiculo.Checked, bscCodigoVehiculo.Text, String.Empty))


   End Function
   Private Sub CargaGrillaDetalle(buscarABM As Eniac.Entidades.Buscar)
      Dim dtDetalle = GetGrillaDetalle(buscarABM)

      dgvDatos.DataSource = dtDetalle
      FormatearGrilla()
      PreferenciasLeer(dgvDatos, tsbPreferencias)
      tssRegistros.Text = dtDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Private Sub RefrescarDatosGrilla()
      chbFecha.Checked = False
      chkMesCompleto.Checked = False

      If Parametros.FechaDesde.HasValue Or Parametros.FechaHasta.HasValue Then
         chbFecha.Checked = True
      End If

      dtpFechaDesde.Value = If(Parametros.FechaDesde.HasValue, Parametros.FechaDesde.Value, DateTime.Today)
      dtpFechaHasta.Value = If(Parametros.FechaHasta.HasValue, Parametros.FechaHasta.Value, DateTime.Today.UltimoSegundoDelDia())

      cmbTipoFechaFiltro.SelectedValue = Entidades.CRMNovedad.TipoFechaFiltro.FechaNovedad

      'chbCategoria.Checked = False
      cmbCRMEstados.Refrescar()
      cmbCategoriasNovedad.Refrescar()
      cmbCRMMedios.Refrescar()
      cmbCRMMetodos.Refrescar()
      chbCategoriaReporta.Checked = False
      'chbEstado.Checked = False
      chbCliente.Checked = False
      chbUsuarioAlta.Checked = False
      chbUsuarioAsignado.Checked = False

      If Not Parametros.QuitarFiltroPorUsuario Then
         chbUsuarioAsignado.Checked = True
         cmbUsuarioAsignado.SelectedValue = _usr.Id
      End If

      If Not _tienePermisoParaVerOtrosUsuarios Then
         chbUsuarioAsignado.Enabled = False
         cmbUsuarioAsignado.Enabled = False
      End If

      chbNumero.Checked = False
      cmbFinalizado.SelectedValue = Entidades.Publicos.SiNoTodos.NO
      cmbPriorizado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbRevisionAdministrativa.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

      chbAplicacion.Checked = False
      chbVersion.Checked = False
      chbFuncionNuevo.Checked = False
      'chbMedio.Checked = False
      'chbMetodoResolucion.Checked = False

      If Parametros.IdProyecto > 0 Then
         chbProyecto.Checked = True
         bscCodigoProyecto.Text = Parametros.IdProyecto.ToString()
         bscCodigoProyecto.PresionarBoton()
         chbProyecto.Enabled = False
         bscCodigoProyecto.Permitido = False
         bscProyecto.Permitido = False
      Else
         Me.chbProyecto.Checked = False
      End If

      If Parametros.CodigoCliente > 0 Then
         chbCliente.Checked = True
         bscCodigoCliente.Text = Parametros.CodigoCliente.ToString()
         bscCodigoCliente.PresionarBoton()
      End If

      If Parametros.Finalizado.HasValue Then
         cmbFinalizado.SelectedValue = Parametros.Finalizado.Value
      End If

      If Parametros.IdCategoriaNovedad.HasValue Then
         cmbCategoriasNovedad.SelectedValue = Parametros.IdCategoriaNovedad.Value
      End If
      If Parametros.IdEstadoNovedad.HasValue Then
         cmbCRMEstados.SelectedValue = Parametros.IdEstadoNovedad.Value
      End If

      chbPrioridad.Checked = False
      chbPrioridadProyecto.Checked = False
      chbEstadoProyecto.Checked = False
      chbClasificacionProyecto.Checked = False

      cmbEnGarantia.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbConPrestamo.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      cmbEstadoPrestamo.SelectedValue = Entidades.CRMNovedad.EstadosProductosPrestados.TODOS

      Me.cmbCategoriaReporta.SelectedIndex = 0 'Hace falta?

      chbVehiculo.Checked = False
      bscCodigoVehiculo.Text = String.Empty

      If Not Parametros.IgnoraFiltrosPersonalizados Then FiltersManager1.Refrescar()

   End Sub

   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged

      chkMesCompleto.Enabled = chbFecha.Checked
      dtpFechaDesde.Enabled = chbFecha.Checked
      dtpFechaHasta.Enabled = chbFecha.Checked
   End Sub


   Private Sub chbAplicacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbAplicacion.CheckedChanged
      TryCatched(
         Sub()
            cmbAplicacion.Enabled = chbAplicacion.Checked
            If Not chbAplicacion.Checked Then
               cmbAplicacion.SelectedIndex = -1
            Else
               If cmbAplicacion.Items.Count > 0 Then
                  cmbAplicacion.SelectedIndex = 2
               End If
            End If
            cmbAplicacion.Focus()
         End Sub)
   End Sub

   Private Sub chbVersion_CheckedChanged(sender As Object, e As EventArgs) Handles chbVersion.CheckedChanged
      TryCatched(
         Sub()
            cmbVersion.Enabled = chbVersion.Checked
            If Not chbVersion.Checked Then
               cmbVersion.SelectedIndex = -1
            Else
               If cmbVersion.Items.Count > 0 Then
                  cmbVersion.SelectedIndex = 0
               End If
            End If
            cmbVersion.Focus()
         End Sub)
   End Sub

   Private Sub cmbAplicacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAplicacion.SelectedIndexChanged
      TryCatched(Sub() _publicos.CargaComboVersiones(cmbVersion, If(chbAplicacion.Checked, cmbAplicacion.SelectedValue.ToString(), String.Empty)))
   End Sub

   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      TryCatched(
         Sub()
            txtNumero.Enabled = chbNumero.Checked
            If Not chbNumero.Checked Then
               txtNumero.Text = ""
            Else
               txtNumero.Text = "0"
               txtNumero.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbFuncionNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbFuncionNuevo.CheckedChanged
      TryCatched(
         Sub()
            bscCodigoFuncionNuevo.Enabled = chbFuncionNuevo.Checked
            bscFuncionNuevo.Enabled = chbFuncionNuevo.Checked

            bscCodigoFuncionNuevo.Text = String.Empty
            bscCodigoFuncionNuevo.Tag = Nothing
            bscFuncionNuevo.Text = String.Empty

            bscCodigoFuncionNuevo.Focus()
         End Sub)
   End Sub
   Private Sub bscCodigoFuncionNuevo_BuscadorClick() Handles bscCodigoFuncionNuevo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaFunciones2(bscCodigoFuncionNuevo)
            bscCodigoFuncionNuevo.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(bscCodigoFuncionNuevo.Text, String.Empty)
         End Sub)
   End Sub
   Private Sub bscCodigoFuncionNuevo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoFuncionNuevo.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosFuncion(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
   Private Sub bscFuncionNuevo_BuscadorClick() Handles bscFuncionNuevo.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaFunciones2(bscFuncionNuevo)
            bscFuncionNuevo.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(String.Empty, bscFuncionNuevo.Text.Trim())
         End Sub)
   End Sub
   Private Sub bscFuncionNuevo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscFuncionNuevo.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosFuncion(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
   Private Sub CargarDatosFuncion(dr As DataGridViewRow)
      Me.bscFuncionNuevo.Text = dr.Cells("Nombre").Value.ToString()
      Me.bscCodigoFuncionNuevo.Text = dr.Cells("Id").Value.ToString().Trim()
   End Sub

#Region "Eventos Buscador Vehiculos"
   Private Sub chbVehiculo_CheckedChanged(sender As Object, e As EventArgs) Handles chbVehiculo.CheckedChanged
      TryCatched(Sub() chbVehiculo.FiltroCheckedChanged(usaPermitido:=True, bscCodigoVehiculo))
   End Sub
   Private Sub bscCodigoVehiculo_BuscadorClick() Handles bscCodigoVehiculo.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaVehiculos2(bscCodigoVehiculo)
         Dim codigoVehiculo = bscCodigoVehiculo.Text.Trim()
         bscCodigoVehiculo.Datos = New Reglas.Vehiculos().GetFiltradoPorPatente(codigoVehiculo, If(IsNumeric(bscCodigoCliente.Tag), Long.Parse(bscCodigoCliente.Tag.ToString()), 0), True)
      End Sub)
   End Sub
   Private Sub bscCodigoVehiculo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoVehiculo.BuscadorSeleccion
      TryCatched(Sub() CargarDatosVehiculos(e.FilaDevuelta))
   End Sub
   Private Sub CargarDatosVehiculos(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoVehiculo.Text = dr.Cells(Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString()).Value.ToString().Trim()
         bscCodigoVehiculo.Selecciono = True
      End If
   End Sub

#End Region


   Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
      TryCatched(
         Sub()
            If e.KeyCode = Keys.Enter Then
               If Not String.IsNullOrWhiteSpace(txtNumero.Text) Then
                  btnConsultar.PerformClick()
               End If
            End If
         End Sub)
   End Sub

   'Private Sub chbMedio_CheckedChanged(sender As Object, e As EventArgs)
   '   TryCatched(
   '      Sub()
   '         cmbMedio.Enabled = chbMedio.Checked
   '         If chbMedio.Checked = False Then
   '            cmbMedio.SelectedIndex = -1
   '         End If
   '      End Sub)
   'End Sub

   Private Sub bscProyecto_BuscadorClick() Handles bscProyecto.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProyectos(bscProyecto)
            Dim rProyectos = New Reglas.Proyectos()
            Dim idCliente = If(chbCliente.Checked, If(IsNumeric(bscCodigoCliente.Tag), Long.Parse(bscCodigoCliente.Tag.ToString()), 0), DirectCast(Nothing, Long?))
            bscProyecto.Datos = rProyectos.GetFiltradoPorNombre(bscProyecto.Text.Trim(), idCliente)
         End Sub)
   End Sub

   Private Sub bscProyecto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProyecto.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosProyecto(e.FilaDevuelta)
               btnConsultar.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscCodigoProyecto_BuscadorClick() Handles bscCodigoProyecto.BuscadorClick
      TryCatched(
         Sub()
            Dim codigoProyecto As Integer? = If(String.IsNullOrEmpty(bscCodigoProyecto.Text), DirectCast(Nothing, Integer?), Integer.Parse(bscCodigoProyecto.Text))
            _publicos.PreparaGrillaProyectos(bscCodigoProyecto)
            Dim rProyectos = New Reglas.Proyectos()
            Dim idCliente = If(chbCliente.Checked, If(IsNumeric(bscCodigoCliente.Tag), Long.Parse(bscCodigoCliente.Tag.ToString()), 0), DirectCast(Nothing, Long?))
            bscCodigoProyecto.Datos = rProyectos.GetFiltradoPorCodigo(codigoProyecto, idCliente)
         End Sub)
   End Sub

   Private Sub bscCodigoProyecto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProyecto.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosProyecto(e.FilaDevuelta)
               btnConsultar.Focus()
            End If
         End Sub)
   End Sub

   Private Sub CargarDatosProyecto(dr As DataGridViewRow)
      bscCodigoProyecto.Text = dr.Cells("IdProyecto").Value.ToString()
      bscProyecto.Text = dr.Cells("NombreProyecto").Value.ToString()
      bscCodigoProyecto.Selecciono = True
      bscProyecto.Selecciono = True
   End Sub

#Region "Menu Contextual"

   Private Function GetPersonalizados() As Entidades.CRMNovedad.CambioMasivo()
      Return {CreaCambioMasivo(idEstadoNovedad:=478, idMedio:=411, idUsuario:="tester", idPrioridad:=403),
              CreaCambioMasivo(idEstadoNovedad:=478, idMedio:=414, idUsuario:="tester", idPrioridad:=413),
              CreaCambioMasivo(idEstadoNovedad:=423, idMedio:=401, idUsuario:="generar", idPrioridad:=Nothing),
              CreaCambioMasivo(idEstadoNovedad:=448, idMedio:=Nothing, idUsuario:="scarrozzo", idPrioridad:=Nothing),
              CreaCambioMasivo(idEstadoNovedad:=408, idMedio:=410, idUsuario:="irene", idPrioridad:=Nothing),
              CreaCambioMasivo(idEstadoNovedad:=408, idMedio:=410, idUsuario:="vbilbao", idPrioridad:=Nothing)}
   End Function

   Private Function CreaCambioMasivo(idEstadoNovedad As Integer, idMedio As Integer?, idUsuario As String, idPrioridad As Integer?) As Entidades.CRMNovedad.CambioMasivo
      Return New Entidades.CRMNovedad.CambioMasivo() With {.EstadoNovedad = Reglas.Cache.CRMCacheHandler.Instancia.Estados.Buscar(idEstadoNovedad),
                                                           .MedioNovedad = If(idMedio.HasValue, Reglas.Cache.CRMCacheHandler.Instancia.Medios.Buscar(idMedio.Value), Nothing),
                                                           .UsuarioAsignado = DirectCast(cmbUsuarioAsignado.DataSource, List(Of Entidades.Usuario)).FirstOrDefault(Function(x) x.Id.ToLower() = idUsuario),
                                                           .Prioridad = If(idPrioridad.HasValue, Reglas.Cache.CRMCacheHandler.Instancia.Prioridades.Buscar(idPrioridad.Value), Nothing)}
   End Function

   Private Class UsuarioAccion
      Public Property Usuario As Entidades.Usuario
      Public Property Accion As Entidades.CRMNovedad.AccionEtiquetaNovedad
      Public ReadOnly Property Nombre As String
         Get
            Return Usuario.Nombre
         End Get
      End Property
      Public Sub New(usuario As Entidades.Usuario, accion As Entidades.CRMNovedad.AccionEtiquetaNovedad)
         Me.Usuario = usuario
         Me.Accion = accion
      End Sub
   End Class

   Private Sub CargarMenuContextualGrilla()
      If TipoNovedad IsNot Nothing Then
         Dim dtsPrioridad = New GridContextMenuManager.DataSourceMenu(Of Entidades.CRMPrioridadNovedad)(Reglas.Cache.CRMCacheHandler.Instancia.Prioridades.GetTodos(TipoNovedad.IdTipoNovedad).OrderBy(Function(x) x.Posicion).ToArray(), Function(x) x.NombrePrioridadNovedad)

         Dim dtUsuario = DirectCast(cmbUsuarioAsignado.DataSource, List(Of Entidades.Usuario)).OrderBy(Function(x) x.Nombre).ToArray()
         Dim dtsUsuario = New GridContextMenuManager.DataSourceMenu(Of Entidades.Usuario)(dtUsuario, Function(x) x.Nombre)

         Dim dtsUsuarioAgregar = New GridContextMenuManager.DataSourceMenu(Of UsuarioAccion)(dtUsuario.ToList().ConvertAll(Function(x) New UsuarioAccion(x, Entidades.CRMNovedad.AccionEtiquetaNovedad.AGREGAR)).ToArray(), Function(x) x.Nombre)
         Dim dtsUsuarioQuitar = New GridContextMenuManager.DataSourceMenu(Of UsuarioAccion)(dtUsuario.ToList().ConvertAll(Function(x) New UsuarioAccion(x, Entidades.CRMNovedad.AccionEtiquetaNovedad.QUITAR)).ToArray(), Function(x) x.Nombre)
         Dim dtsUsuarioCambiar = New GridContextMenuManager.DataSourceMenu(Of UsuarioAccion)(dtUsuario.ToList().ConvertAll(Function(x) New UsuarioAccion(x, Entidades.CRMNovedad.AccionEtiquetaNovedad.CAMBIAR)).ToArray(), Function(x) x.Nombre)


         Dim dtsMedio = New GridContextMenuManager.DataSourceMenu(Of Entidades.CRMMedioComunicacionNovedad)(Reglas.Cache.CRMCacheHandler.Instancia.Medios.GetTodos(TipoNovedad.IdTipoNovedad).OrderBy(Function(x) x.Posicion).ToArray(), Function(x) x.NombreMedioComunicacionNovedad)
         Dim dtsEstado = New GridContextMenuManager.DataSourceMenu(Of Entidades.CRMEstadoNovedad)(Reglas.Cache.CRMCacheHandler.Instancia.Estados.GetTodos(TipoNovedad.IdTipoNovedad).OrderBy(Function(x) x.Posicion).ToArray(), Function(x) x.NombreEstadoNovedad)
         Dim dtsDelta = New GridContextMenuManager.DataSourceMenu(Of Integer)({-15, -10, -5, -4, -3, -2, -1, +1, +2, +3, +4, +5, +10, +15}, Function(x) x.ToString("+ #;- #;0"))
         Dim dtsColor = New GridContextMenuManager.DataSourceMenu(Of Color)({Color.Red, Color.Yellow, Color.Green, Drawing.SystemColors.Control},
                                                                            Function(x)
                                                                               If x = Color.Red Then
                                                                                  Return "Rojo"
                                                                               ElseIf x = Color.Yellow Then
                                                                                  Return "Amarillo"
                                                                               ElseIf x = Color.Green Then
                                                                                  Return "Verde"
                                                                               Else
                                                                                  Return "(sin color)"
                                                                               End If
                                                                            End Function)

         Dim dtsRequiereTesteo = New GridContextMenuManager.DataSourceMenu(Of Boolean)({True, False}, Function(x) If(x, "Si", "No"))
         Dim dtsPriorizado = New GridContextMenuManager.DataSourceMenu(Of Boolean)({True, False}, Function(x) If(x, "Si", "No"))
         Dim dtsPersonalizados = New GridContextMenuManager.DataSourceMenu(Of Object)(GetPersonalizados(), Function(x) x.ToString())
         Dim dtsTiposNovedades = New GridContextMenuManager.DataSourceMenu(Of Entidades.CRMTipoNovedad)(Reglas.Cache.CRMCacheHandler.Instancia.Tipos.GetTodos().OrderBy(Function(x) x.NombreTipoNovedad).ToArray(), Function(x) x.NombreTipoNovedad)

         GridContextMenuManager1.AgregarMenu(GridContextMenuManager1.NewMenuAccion("Prioridad", {GridContextMenuManager1.NewMenuAccion("Específica", dtsPrioridad),
                                                                                                 GridContextMenuManager1.NewMenuAccion("Incrementar/Disminuir", dtsDelta)}))
         GridContextMenuManager1.AgregarMenu(GridContextMenuManager1.NewMenuAccion("Color", dtsColor, {GridContextMenuManager1.NewMenuAccion("Priorizado", dtsPriorizado)}))
         GridContextMenuManager1.AgregarMenu(GridContextMenuManager1.NewMenuAccion("Priorizado", dtsPriorizado, {GridContextMenuManager1.NewMenuAccion("Color", dtsColor)}))
         GridContextMenuManager1.AgregarMenu(GridContextMenuManager1.NewMenuAccion("Etiquetas", {GridContextMenuManager1.NewMenuAccion("Agregar", dtsUsuarioAgregar),
                                                                                                 GridContextMenuManager1.NewMenuAccion("Quitar", dtsUsuarioQuitar),
                                                                                                 GridContextMenuManager1.NewMenuAccion("Cambiar", dtsUsuarioCambiar)}))
         GridContextMenuManager1.AgregarMenu(GridContextMenuManager1.NewMenuAccion("Requiere Test", dtsRequiereTesteo))

         GridContextMenuManager1.AgregarMenu(GridContextMenuManager1.NewMenuAccion("Usuario Asignado", dtsUsuario,
                                                                                   {GridContextMenuManager1.NewMenuAccion("Medio", dtsMedio,
                                                                                                                          {GridContextMenuManager1.NewMenuAccion("Estado", dtsEstado)}),
                                                                                    GridContextMenuManager1.NewMenuAccion("Estado", dtsEstado,
                                                                                                                          {GridContextMenuManager1.NewMenuAccion("Medio", dtsMedio)})}))
         GridContextMenuManager1.AgregarMenu(GridContextMenuManager1.NewMenuAccion("Medio", dtsMedio,
                                                                                   {GridContextMenuManager1.NewMenuAccion("Usuario Asignado", dtsUsuario,
                                                                                                                          {GridContextMenuManager1.NewMenuAccion("Estado", dtsEstado)}),
                                                                                    GridContextMenuManager1.NewMenuAccion("Estado", dtsEstado,
                                                                                                                          {GridContextMenuManager1.NewMenuAccion("Usuario Asignado", dtsUsuario)})}))
         GridContextMenuManager1.AgregarMenu(GridContextMenuManager1.NewMenuAccion("Estado", dtsEstado,
                                                                                   {GridContextMenuManager1.NewMenuAccion("Usuario Asignado", dtsUsuario,
                                                                                                                          {GridContextMenuManager1.NewMenuAccion("Medio", dtsMedio)}),
                                                                                    GridContextMenuManager1.NewMenuAccion("Medio", dtsMedio,
                                                                                                                          {GridContextMenuManager1.NewMenuAccion("Usuario Asignado", dtsUsuario)})}))

         GridContextMenuManager1.AgregarMenu(GridContextMenuManager1.NewSeparador())
         If TipoNovedad.IdTipoNovedad = "PENDIENTE" Then
            GridContextMenuManager1.AgregarMenu(GridContextMenuManager1.NewMenuAccion("Personalizados", dtsPersonalizados))
         End If
         GridContextMenuManager1.AgregarMenu(GridContextMenuManager1.NewMenuAccion("Copiar al tablero", dtsTiposNovedades,
                                                                                   New GridContextMenuManager.SoloActualMenuManager(GridContextMenuManager1)))

         GridContextMenuManager1.CargarMenuContextualGrilla()
      End If
   End Sub

#Region "Eventos Menu Contextual"
   Private Sub GridContextMenuManager1_RefrecarGrilla(sender As Object, e As EventArgs) Handles GridContextMenuManager1.RefrecarGrilla
      TryCatched(Sub() btnConsultar.PerformClick())
   End Sub
   Private Class AccionSeleccionada
      Public Property CopiarAlTablero As Entidades.CRMTipoNovedad
      Public Property Cambio As New Entidades.CRMNovedad.CambioMasivo
   End Class
   Private Sub GridContextMenuManager1_EjecutarComando(sender As Object, e As GridContextMenuManager.EjecutarComandoEventArgs) Handles GridContextMenuManager1.EjecutarComando
      TryCatched(
         Sub()
            Dim cambio As New AccionSeleccionada()
            GridContextMenuManager1.BuscarRecursivo(cambio, e.SelectedItem,
                                              Sub(item)
                                                 If TypeOf (item.Tag) Is Entidades.Usuario Then
                                                    cambio.Cambio.UsuarioAsignado = item.TagAs(Of Entidades.Usuario)()
                                                 ElseIf TypeOf (item.Tag) Is UsuarioAccion Then
                                                    Dim usr = item.TagAs(Of UsuarioAccion)()
                                                    cambio.Cambio.EtiquetaNovedad = String.Concat("@", usr.Usuario.Usuario)
                                                    If usr.Accion = Entidades.CRMNovedad.AccionEtiquetaNovedad.AGREGAR Then
                                                       cambio.Cambio.AccionEtiquetaNovedad = Entidades.CRMNovedad.AccionEtiquetaNovedad.AGREGAR
                                                    ElseIf usr.Accion = Entidades.CRMNovedad.AccionEtiquetaNovedad.QUITAR Then
                                                       cambio.Cambio.AccionEtiquetaNovedad = Entidades.CRMNovedad.AccionEtiquetaNovedad.QUITAR
                                                    ElseIf usr.Accion = Entidades.CRMNovedad.AccionEtiquetaNovedad.CAMBIAR Then
                                                       cambio.Cambio.AccionEtiquetaNovedad = Entidades.CRMNovedad.AccionEtiquetaNovedad.CAMBIAR
                                                    Else

                                                    End If
                                                 ElseIf TypeOf (item.Tag) Is Entidades.CRMPrioridadNovedad Then
                                                    cambio.Cambio.Prioridad = item.TagAs(Of Entidades.CRMPrioridadNovedad)()
                                                 ElseIf TypeOf (item.Tag) Is Entidades.CRMMedioComunicacionNovedad Then
                                                    cambio.Cambio.MedioNovedad = item.TagAs(Of Entidades.CRMMedioComunicacionNovedad)()
                                                 ElseIf TypeOf (item.Tag) Is Entidades.CRMEstadoNovedad Then
                                                    cambio.Cambio.EstadoNovedad = item.TagAs(Of Entidades.CRMEstadoNovedad)()
                                                 ElseIf TypeOf (item.Tag) Is Color Then
                                                    cambio.Cambio.BanderaColor = item.TagAs(Of Color)()
                                                 ElseIf TypeOf (item.Tag) Is Integer Then
                                                    cambio.Cambio.PrioridadDelta = item.TagAs(Of Integer)()
                                                 ElseIf TypeOf (item.Tag) Is Boolean Then
                                                    If item.OwnerItem.Text = "Priorizado" Then
                                                       cambio.Cambio.Priorizado = DirectCast(item.Tag, Boolean)
                                                    Else
                                                       cambio.Cambio.RequiereTesteo = DirectCast(item.Tag, Boolean)
                                                    End If


                                                 ElseIf TypeOf (item.Tag) Is Entidades.CRMNovedad.CambioMasivo Then
                                                    cambio.Cambio = DirectCast(item.Tag, Entidades.CRMNovedad.CambioMasivo)

                                                 ElseIf TypeOf (item.Tag) Is Entidades.CRMTipoNovedad Then
                                                    cambio.CopiarAlTablero = item.TagAs(Of Entidades.CRMTipoNovedad)()

                                                 End If
                                              End Sub)
            If cambio.CopiarAlTablero Is Nothing Then
               e.Cancel = Not CambioMasivo(cambio.Cambio, e.Filas)
            Else

               Using frmCopia As New CRMNovedadesDetalle(New Entidades.CRMNovedad(), cambio.CopiarAlTablero,
                                                   New Reglas.CRMNovedades().GetUno(e.Filas(0).Field(Of String)(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()),
                                                                                    e.Filas(0).Field(Of String)(Entidades.CRMNovedad.Columnas.Letra.ToString()),
                                                                                    e.Filas(0).Field(Of Short)(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()),
                                                                                    e.Filas(0).Field(Of Long)(Entidades.CRMNovedad.Columnas.IdNovedad.ToString())),
                                                   copiarComentarios:=False)
                  frmCopia.ShowDialog()
               End Using
            End If
         End Sub)
   End Sub
#End Region

   Private Function CambioMasivo(cambio As Entidades.CRMNovedad.CambioMasivo, drCol As DataRow()) As Boolean
      If drCol.Length > 0 Then
         Using dt As DataTable = drCol(0).Table.Clone()
            dt.Columns.Add("selec", GetType(Boolean), Boolean.TrueString)
            dt.ImportRowRange(drCol)

            Using frm = New CRMNovedadesABMCambioMasivo()
               If frm.ShowDialog(Me, dt, cambio, TipoNovedad.IdTipoNovedad) = DialogResult.OK Then
                  Dim rNovedad As New Reglas.CRMNovedades()
                  rNovedad.ActualizacionMasiva(dt, cambio)
                  Return True
               End If
            End Using
         End Using
      End If
      Return False
   End Function

   Private Sub CambioMasivoMessage(cambio As Entidades.CRMNovedad.CambioMasivo, drCol As DataRow())
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Prioridad: {0}", If(cambio.Prioridad IsNot Nothing, cambio.Prioridad.NombrePrioridadNovedad, "(sin definir)"))
      stb.AppendFormatLine("Prioridad Delta: {0}", If(cambio.PrioridadDelta <> 0, cambio.PrioridadDelta.ToString(), "(sin definir)"))
      stb.AppendFormatLine("Usuario: {0}", If(cambio.UsuarioAsignado IsNot Nothing, cambio.UsuarioAsignado.Nombre, "(sin definir)"))
      stb.AppendFormatLine("Medio: {0}", If(cambio.MedioNovedad IsNot Nothing, cambio.MedioNovedad.NombreMedioComunicacionNovedad, "(sin definir)"))
      stb.AppendFormatLine("Estado: {0}", If(cambio.EstadoNovedad IsNot Nothing, cambio.EstadoNovedad.NombreEstadoNovedad, "(sin definir)"))

      If drCol.Count > 0 Then
         stb.AppendLine.AppendLine()
         For Each dr As DataRow In drCol
            stb.AppendFormatLine("{0} {1} {2:0000}-{3:00000000}",
                                 dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()),
                                 dr.Field(Of String)(Entidades.CRMNovedad.Columnas.Letra.ToString()),
                                 dr.Field(Of Short)(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()),
                                 dr.Field(Of Long)(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()))
         Next
      End If
      MessageBox.Show(stb.ToString())
   End Sub

#End Region

   Private Sub chbPrioridad_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrioridad.CheckedChanged
      TryCatched(
         Sub()
            cmbPrioridad.Enabled = chbPrioridad.Checked
            If Not chbPrioridad.Checked Then
               cmbPrioridad.SelectedIndex = -1
            Else
               If cmbPrioridad.Items.Count > 0 Then
                  cmbPrioridad.SelectedIndex = 0
               End If
               cmbPrioridad.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProyecto.CheckedChanged
      TryCatched(
         Sub()
            bscCodigoProyecto.Enabled = chbProyecto.Checked
            bscProyecto.Enabled = bscCodigoProyecto.Enabled
            If Not chbProyecto.Checked Then
               bscCodigoProyecto.Text = String.Empty
               bscProyecto.Text = String.Empty
            Else
               bscCodigoProyecto.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbPrioridadProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrioridadProyecto.CheckedChanged
      TryCatched(
         Sub()
            nudPrioridadDesde.Enabled = chbPrioridadProyecto.Checked
            nudPrioridadHasta.Enabled = nudPrioridadDesde.Enabled
            If Not chbPrioridadProyecto.Checked Then
               nudPrioridadDesde.Value = 1
               nudPrioridadHasta.Value = 5
            End If
         End Sub)
   End Sub

   Private Sub chbEstadoProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstadoProyecto.CheckedChanged
      TryCatched(
         Sub()
            cmbEstadoProyecto.Enabled = chbEstadoProyecto.Checked
            If Not chbEstadoProyecto.Checked Then
               cmbEstadoProyecto.SelectedIndex = -1
            End If
         End Sub)
   End Sub

   Private Sub chbClasificacionProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbClasificacionProyecto.CheckedChanged
      TryCatched(
         Sub()
            cmbClasificacionProyecto.Enabled = chbClasificacionProyecto.Checked
            If Not chbClasificacionProyecto.Checked Then
               cmbClasificacionProyecto.SelectedIndex = -1
            End If
         End Sub)
   End Sub

   Private Sub ConfiguracionInicialDinamicos()
      For Each dinamico As Entidades.CRMTipoNovedadDinamico In TipoNovedad.Dinamicos
         Select Case dinamico.IdNombreDinamico
            Case "CLIENTES"
               Modo = Entidades.Cliente.ModoClienteProspecto.Cliente
               chbCliente.Text = Modo.ToString()
            Case "PROSPECTOS"
               Modo = Entidades.Cliente.ModoClienteProspecto.Prospecto
               chbCliente.Text = Modo.ToString()
            Case "PROVEEDORES"
               Modo = Nothing
               chbCliente.Text = "Proveedor"
            Case "FUNCIONES"
               chbFuncionNuevo.Visible = True
               bscCodigoFuncionNuevo.Visible = False
               bscFuncionNuevo.Visible = True
            Case Else
         End Select
      Next
   End Sub

   'Private Sub chbMetodoResolucion_CheckedChanged(sender As Object, e As EventArgs)
   '   TryCatched(Sub() chbMetodoResolucion.FiltroCheckedChanged(cmbMetodoResolucion))
   'End Sub

   Private Sub chbUsuarioAlta_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuarioAlta.CheckedChanged
      TryCatched(Sub() chbUsuarioAlta.FiltroCheckedChanged(cmbUsuarioAlta))
   End Sub

   '-- REQ-30962 --
   Private Sub chbTipoUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoUsuario.CheckedChanged
      TryCatched(
         Sub()
            cmbTipoUsuario.Enabled = chbTipoUsuario.Checked
            If Not chbTipoUsuario.Checked Then
               cmbTipoUsuario.SelectedIndex = -1
            Else
               If cmbTipoUsuario.Items.Count > 0 Then
                  cmbTipoUsuario.SelectedIndex = 0
               End If
               cmbTipoUsuario.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbNumeroPadre_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroPadre.CheckedChanged
      TryCatched(
         Sub()
            txtNumeroPadre.Enabled = chbNumeroPadre.Checked
            If Not chbNumeroPadre.Checked Then
               txtNumeroPadre.Text = ""
            Else
               txtNumeroPadre.Text = "0"
               txtNumeroPadre.Focus()
            End If
         End Sub)
   End Sub

   Private Sub chbSucursal_CheckedChanged(sender As Object, e As EventArgs) Handles chbSucursal.CheckedChanged
      cmbSucursal.Enabled = Me.chbSucursal.Checked
      cmbSucursal.Focus()
   End Sub


End Class