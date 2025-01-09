Imports QRCoder.PayloadGenerator.ShadowSocksConfig

Public Class InformeDeNovedades
   Implements IConParametros

   Public ReadOnly Property TipoNovedad() As Entidades.CRMTipoNovedad
      Get
         Return TipoNovedadParametro 'DirectCast(cmbTipoNovedad.SelectedItem, Entidades.CRMTipoNovedad)
      End Get
   End Property

#Region "Propiedades"
   Private Property Modo As Eniac.Entidades.Cliente.ModoClienteProspecto?
   Public Property TipoNovedadParametro As Entidades.CRMTipoNovedad

   Public Property FechaDesde() As Date?
   Public Property FechaHasta() As Date?
   Public Property TipoFechaFiltro As Entidades.CRMNovedad.TipoFechaFiltro?

   Public Property VieneDeAlerta() As Boolean = False



#End Region
#Region "Campos"

   Private _publicos As Publicos
   Private _cargando As Boolean = True
   Private _usr As Entidades.Usuario
   Private _cacheSemaforo As List(Of Entidades.SemaforoVentaUtilidad)

#End Region

   Private Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      If Not String.IsNullOrWhiteSpace(parametros) Then
         TipoNovedadParametro = New Reglas.CRMTiposNovedades().GetUno(parametros)
      End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      Try
         _cacheSemaforo = New Reglas.SemaforoVentasUtilidades().GetTodos(Entidades.SemaforoVentaUtilidad.TiposSemaforos.ESTRELLAS)
      Catch ex As Exception
         ShowError(ex)
      End Try

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         If Me.FechaDesde.HasValue Then
            Me.dtpDesde.Value = Me.FechaDesde.Value
         Else
            Me.dtpDesde.Value = DateTime.Today
         End If

         If Me.FechaHasta.HasValue Then
            Me.dtpHasta.Value = Me.FechaHasta.Value
         Else
            Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         End If

         'Me.dtpDesde.Value = DateTime.Today
         'Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)

         Me.cmbFinalizado.Items.Insert(0, "TODOS")
         Me.cmbFinalizado.Items.Insert(1, "SI")
         Me.cmbFinalizado.Items.Insert(2, "NO")
         Me.cmbFinalizado.SelectedIndex = 0

         '###########################
         '#      Carga Combos       #
         '###########################
         Me._publicos.CargaComboUsuarios(Me.cmbUsuarioAlta)
         Me._publicos.CargaComboUsuarios(Me.cmbIdUsuarioAsignado)
         Me._publicos.CargaComboDesdeEnum(cmbTipoFechaFiltro, GetType(Entidades.CRMNovedad.TipoFechaFiltro), hideBrowsable:=True)

         '# Asignado
         If cmbIdUsuarioAsignado.DataSource IsNot Nothing AndAlso TypeOf (cmbIdUsuarioAsignado.DataSource) Is List(Of Entidades.Usuario) Then
            Dim lista As List(Of Entidades.Usuario) = DirectCast(cmbIdUsuarioAsignado.DataSource, List(Of Entidades.Usuario))
            Dim usuario As Entidades.Usuario = New Entidades.Usuario()
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

         '# Proyectos
         Me._publicos.CargaComboClasificaciones(Me.cmbClasificacionProyecto)
         Me.cmbClasificacionProyecto.SelectedIndex = -1
         Me._publicos.CargaComboProyectosEstados(Me.cmbEstadoProyecto)
         Me.cmbEstadoProyecto.SelectedIndex = -1

         If TipoNovedadTiene("PROYECTOS") Then
            Me.gbProyecto.Visible = True
         End If

         '# Priorizado
         Me._publicos.CargaComboDesdeEnum(cmbPriorizado, GetType(Entidades.Publicos.SiNoTodos))
         cmbPriorizado.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         '# Aplicaciones y Versiones
         Me._publicos.CargaComboAplicacionesEntidad(cmbAplicacion)
         Me._publicos.CargaComboVersiones(cmbVersion, String.Empty)

         '#Misma lógica que muestra la solapa Sinergia en CRMNovedadesDetalle.
         If Not Reglas.Publicos.ExtrasSinergia Then
            Me.cmbAplicacion.Visible = False
            Me.chbAplicacion.Visible = False
            Me.cmbVersion.Visible = False
            Me.chbVersion.Visible = False
         End If

         Me._publicos.CargaComboDesdeEnum(Me.cmbEnGarantia, GetType(Entidades.Publicos.SiNoTodos))
         Me._publicos.CargaComboDesdeEnum(Me.cmbConPrestamo, GetType(Entidades.Publicos.SiNoTodos))
         Me._publicos.CargaComboDesdeEnum(Me.cmbEstadoPrestamo, GetType(Entidades.CRMNovedad.EstadosProductosPrestados))

         cmbCRMCategorias.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True, TipoNovedad.IdTipoNovedad)
         '-- REQ-30962 --
         Me._publicos.CargaComboTipoUsuarios(Me.cmbTipoUsuario)

         Me.cmbEnGarantia.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         Me.cmbConPrestamo.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         Me.cmbEstadoPrestamo.SelectedValue = Entidades.CRMNovedad.EstadosProductosPrestados.TODOS

         If TipoNovedad IsNot Nothing AndAlso TipoNovedad.IdTipoNovedad = "SERVICE" Or TipoNovedad.IdTipoNovedad = "VEHICULO" Then
            Me.lblEnGarantia.Visible = True
            Me.lblConPrestamo.Visible = True
            Me.lblEstadoPrestamo.Visible = True
            Me.cmbEnGarantia.Visible = True
            Me.cmbConPrestamo.Visible = True
            Me.cmbEstadoPrestamo.Visible = True
         End If

         If TipoNovedad.IdTipoNovedad = "VEHICULO" Then
            Me.chbVehiculo.Visible = True
            Me.bscCodigoVehiculo.Visible = True
         Else
            Me.chbVehiculo.Visible = False
            Me.bscCodigoVehiculo.Visible = False
         End If

         If TipoNovedadParametro IsNot Nothing Then
            _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad, TipoNovedadParametro.IdTipoNovedad)

         Else
            _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad)
         End If
         Me.cmbTipoNovedad.SelectedIndex = 0

         If TipoNovedadParametro IsNot Nothing Then cmbTipoNovedad.SelectedValue = TipoNovedadParametro.IdTipoNovedad
         _usr = New Reglas.Usuarios().GetUno(actual.Nombre)

         _cargando = False
         CambiaTipoNovedad()

         Me.cmbTipoFechaFiltro.SelectedValue = If(TipoFechaFiltro.HasValue, TipoFechaFiltro.Value, Entidades.CRMNovedad.TipoFechaFiltro.FechaNovedad)

         Me.cmbRevisionAdministrativa.Text = "TODAS"

         Me._publicos.CargaComboDesdeEnum(Me.cmbCategoriaReporta, GetType(Entidades.CRMCategoriaNovedad.ComboReporta),  , True)
         Me.chbCategoriaReporta.Visible = Reglas.Publicos.CRMMuestraReportaCategoriasNovedades
         Me.cmbCategoriaReporta.Visible = Reglas.Publicos.CRMMuestraReportaCategoriasNovedades

         Dim idFuncion2 As String = "CRMNovedadesABM"
         If TipoNovedad IsNot Nothing Then
            idFuncion2 += TipoNovedad.IdTipoNovedad
         End If

         Dim TienePermisoParaVerOtrosUsuarios As Boolean = New Eniac.Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, TipoNovedad.IdTipoNovedad + "-VerOtrosUsuarios")

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

         If VieneDeAlerta Then
            Me.cmbFinalizado.SelectedIndex = 2  'Mira los NO finalizados (A Vencer/Vencidos)
            Me.btnConsultar.PerformClick()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Filtros = "Filtros: Rango de Fechas: desde el " & Me.dtpDesde.Text & " hasta el " & Me.dtpHasta.Text

         'If Me.chbCliente.Checked Then
         '   Filtros = Filtros & " / Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
         'End If

         If Me.cmbUsuarioAlta.Enabled Then
            Filtros = Filtros & " / Usuario: " & Me.cmbUsuarioAlta.SelectedValue.ToString()
         End If

         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraPrintPreviewDialog1.Name = Me.Text
         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridDocumentExporter1.Export(Me.ugDetalle, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs)
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
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

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub cmbTipoNovedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoNovedad.SelectedIndexChanged
      Try
         Cursor = Cursors.WaitCursor
         CambiaTipoNovedad()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbProspecto.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
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

         If Me.chbVehiculo.Checked = True And Not Me.bscCodigoVehiculo.Selecciono Then
            ShowMessage("ATENCION: No seleccionó un Vehiculo aunque activó ese Filtro.")
            Exit Sub
         End If

         If Me.chbProyecto.Checked And Not Me.bscCodigoProyecto.Selecciono And Not Me.bscProyecto.Selecciono Then
            MessageBox.Show("ATENCION: No seleccionó un Proyecto aunque activó ese Filtro.")
            Exit Sub
         End If

         If Me.chbEstadoProyecto.Checked AndAlso Me.cmbEstadoProyecto.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: No seleccionó un Estado de Proyecto aunque activó ese Filtro.")
            Exit Sub
         End If

         If Me.chbClasificacionProyecto.Checked AndAlso Me.cmbClasificacionProyecto.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: No seleccionó una Clasificación de Proyecto aunque activó ese Filtro.")
            Exit Sub
         End If

         If Me.chbFuncionNuevo.Checked And Not Me.bscCodigoFuncionNuevo.Selecciono And Not Me.bscFuncionNuevo.Selecciono Then
            MessageBox.Show("ATENCION: No seleccionó una Funcion aunque activó ese Filtro.")
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         ugDetalle.AgregarTotalesSuma({Entidades.CRMNovedad.Columnas.Cantidad.ToString()})

         LeerPreferencias()
         If ugDetalle.Rows.Count > 0 Then
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      Try
         CRMNovedadesABM.InitializeRow(e.Row, TipoNovedad, _cacheSemaforo)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      TryCatched(
         Sub()
            Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)()
            If dr IsNot Nothing Then
               Dim oNovedad = New Reglas.CRMNovedades()

               Dim novedad = oNovedad.GetUno(dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()),
                                             dr.Field(Of String)(Entidades.CRMNovedad.Columnas.Letra.ToString()),
                                             dr.Field(Of Short)(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()),
                                             dr.Field(Of Long)(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()))
               Dim oNovImp = New CRMNovedadesImpresion(novedad)
               oNovImp.ImprimirNovedad()
            End If
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub ConfiguracionInicialDinamicos()
      For Each dinamico As Entidades.CRMTipoNovedadDinamico In TipoNovedadParametro.Dinamicos
         Select Case dinamico.IdNombreDinamico
            Case "CLIENTES"
               Modo = Entidades.Cliente.ModoClienteProspecto.Cliente
               chbProspecto.Text = Modo.ToString()
            Case "PROSPECTOS"
               Modo = Entidades.Cliente.ModoClienteProspecto.Prospecto
               chbProspecto.Text = Modo.ToString()
            Case "PROVEEDORES"
               Modo = Nothing
               chbProspecto.Text = "Proveedor"
            Case "FUNCIONES"
               chbFuncionNuevo.Visible = True
               bscCodigoFuncionNuevo.Visible = False
               bscFuncionNuevo.Visible = True
            Case Else
         End Select
      Next
   End Sub

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugDetalle.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugDetalle.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False

      If Me.FechaDesde.HasValue Then
         Me.dtpDesde.Value = Me.FechaDesde.Value
      Else
         Me.dtpDesde.Value = DateTime.Today
      End If

      If Me.FechaHasta.HasValue Then
         Me.dtpHasta.Value = Me.FechaHasta.Value
      Else
         Me.dtpHasta.Value = DateTime.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
      End If

      'Me.chbCategoria.Checked = False
      Me.chbCategoriaReporta.Checked = False

      Me.chbAsignadoA.Checked = False
      Me.chbEstado.Checked = False
      Me.chbMedio.Checked = False
      Me.chbPrioridad.Checked = False
      Me.chbProspecto.Checked = False
      Me.chbUsuario.Checked = False
      Me.chkExpandAll.Checked = False
      Me.chbNumero.Checked = False
      Me.cmbFinalizado.SelectedIndex = 0
      Me.cmbTipoFechaFiltro.SelectedValue = Entidades.CRMNovedad.TipoFechaFiltro.FechaNovedad
      Me.chbAplicacion.Checked = False
      Me.chbVersion.Checked = False
      Me.chbMetodoResolucion.Checked = False

      Me.chbFuncionNuevo.Checked = False
      Me.chbProyecto.Checked = False
      Me.chbPrioridadProyecto.Checked = False
      Me.chbEstadoProyecto.Checked = False
      Me.chbClasificacionProyecto.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      If TipoNovedadParametro IsNot Nothing Then cmbTipoNovedad.SelectedValue = TipoNovedadParametro.IdTipoNovedad

      Dim idFuncion2 As String = "CRMNovedadesABM"
      If TipoNovedad IsNot Nothing Then
         idFuncion2 += TipoNovedad.IdTipoNovedad
      End If

      Dim TienePermisoParaVerOtrosUsuarios As Boolean = New Eniac.Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id,
                                                                                      TipoNovedad.IdTipoNovedad + "-VerOtrosUsuarios")

      Me.cmbRevisionAdministrativa.Text = "TODAS"

      If VieneDeAlerta Then
         Me.chbAsignadoA.Checked = True
         Me.cmbIdUsuarioAsignado.SelectedValue = _usr.Id
         Me.cmbFinalizado.SelectedIndex = 2  'Mira los NO finalizados (A Vencer/Vencidos)
      End If

      If Not TienePermisoParaVerOtrosUsuarios Then
         Me.chbAsignadoA.Enabled = False
         Me.cmbIdUsuarioAsignado.Enabled = False
      End If

      cmbCRMCategorias.Refrescar()

      Me.cmbEnGarantia.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      Me.cmbConPrestamo.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      Me.cmbEstadoPrestamo.SelectedValue = Entidades.CRMNovedad.EstadosProductosPrestados.TODOS

      chbVehiculo.Checked = False
      bscCodigoVehiculo.Text = String.Empty

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
         _publicos.CargaComboCRMMediosComunicacionesNovedades(cmbMedio, idTipoNovedad)
         _publicos.CargaComboCRMMetodoResolucionNovedad(cmbMetodoResolucion, idTipoNovedad)

         For Each dinamico As Entidades.CRMTipoNovedadDinamico In tipoNovedad.Dinamicos
            Select Case dinamico.IdNombreDinamico
               Case "CLIENTES"
                  Modo = Entidades.Cliente.ModoClienteProspecto.Cliente
                  chbProspecto.Text = Modo.ToString()
               Case "PROSPECTOS"
                  Modo = Entidades.Cliente.ModoClienteProspecto.Prospecto
                  chbProspecto.Text = Modo.ToString()
               Case "PROVEEDORES"
                  Modo = Nothing
                  chbProspecto.Text = "Proveedor"
               Case "FUNCIONES"
                  chbFuncionNuevo.Visible = True
                  bscCodigoFuncionNuevo.Visible = False
                  bscFuncionNuevo.Visible = True
               Case Else
            End Select
         Next

      Else
         ClearCombo(cmbPrioridadNovedad)
         ClearCombo(cmbEstadoNovedad)
         'ClearCombo(cmbCategoriaNovedad)
         ClearCombo(cmbMedio)
         ClearCombo(cmbMetodoResolucion)
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

      Dim oCRM As Reglas.CRMNovedades = New Reglas.CRMNovedades()

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
      '   'If cmbCategoriaNovedad.SelectedItem IsNot Nothing Then
      '   '   idCategoriaNovedad = DirectCast(cmbCategoriaNovedad.SelectedItem, Entidades.CRMCategoriaNovedad).IdCategoriaNovedad
      '   'End If
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
      If Me.chbMetodoResolucion.Checked Then
         IdMetodoResolucionNovedad = Integer.Parse(Me.cmbMetodoResolucion.SelectedValue.ToString())
         MetNov = New Reglas.CRMMetodosResolucionesNovedades().GetUno(IdMetodoResolucionNovedad)
         MetodosNovedades = {MetNov}
      Else
         MetodosNovedades = Nothing
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

      If Me.cmbUsuarioAlta.Enabled Then
         IdUsuarioAlta = Me.cmbUsuarioAlta.SelectedValue.ToString()
      End If

      If Me.chbNumero.Checked Then
         IdNovedad = Integer.Parse(Me.txtNumero.Text)
      End If
      If Me.chbNumeroPadre.Checked Then
         idNovedadPadre = Integer.Parse(Me.txtNumeroPadre.Text)
      End If

      If Me.chbPrioridad.Checked Then
         IdPrioridadNovedad = Integer.Parse(Me.cmbPrioridadNovedad.SelectedValue.ToString())
      End If

      Dim revAdmin = Entidades.Publicos.SiNoTodos.TODOS
      If Me.cmbRevisionAdministrativa.Text <> "TODAS" Then
         If Me.cmbRevisionAdministrativa.Text = "SI" Then
            revAdmin = Entidades.Publicos.SiNoTodos.SI
         Else
            revAdmin = Entidades.Publicos.SiNoTodos.NO
         End If
      End If

      '# Proyecto
      Dim idProyecto As Integer = 0
      If Me.chbProyecto.Checked Then
         idProyecto = Integer.Parse(Me.bscCodigoProyecto.Text)
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

      '# Clasificación del Proyecto
      Dim idClasificacionProyecto As Integer = 0
      If Me.chbClasificacionProyecto.Checked Then
         idClasificacionProyecto = Integer.Parse(Me.cmbClasificacionProyecto.SelectedValue.ToString())
      End If

      '# Tipo de Filtro Fecha seleccionado
      Dim filtroFecha As Entidades.CRMNovedad.TipoFechaFiltro = cmbTipoFechaFiltro.ValorSeleccionado(Of Entidades.CRMNovedad.TipoFechaFiltro)
      If TipoFechaFiltro.HasValue Then filtroFecha = Me.TipoFechaFiltro.Value

      Dim dtDetalle As DataTable

      '# Tipo de Usuario del Proyecto
      Dim idTipoUsuario As Integer = 0
      If Me.chbTipoUsuario.Checked Then
         idTipoUsuario = Integer.Parse(Me.cmbTipoUsuario.SelectedValue.ToString())
      End If

      'TODO: El parametro de proyectos se envia cero pero hay que poner el control en la pantalla y enviar el parametro 
      'correcto para que funcione la pantalla.
      dtDetalle = oCRM.GetNovedades(dtpDesde.Value, dtpHasta.Value, filtroFecha, cmbTipoNovedad.SelectedValue.ToString(), Nothing,
                                    cmbCRMCategorias.GetCategorias(TipoNovedad.IdTipoNovedad, True), EstadosNovedades, MediosNovedades, MetodosNovedades, IdUsuarioAsignado,
                                    IdNovedad, idNovedadPadre, IdCliente, IdProspecto, IdProveedor, IdPrioridadNovedad, IdUsuarioAlta,
                                    Me.cmbFinalizado.Text, idProyecto, revAdmin,
                                    idAplicacion:=If(chbAplicacion.Checked, cmbAplicacion.SelectedValue.ToString(), String.Empty),
                                    nroVersion:=If(chbVersion.Checked, cmbVersion.SelectedValue.ToString, String.Empty), descripcion:=String.Empty,
                                    priorizado:=Entidades.Publicos.SiNoTodos.TODOS, usaOrdenamientoDelTablero:=False, idFuncion:=Me.bscCodigoFuncionNuevo.Text,
                                    prioridadDelProyectoDesde:=idPrioridadProyectoDesde,
                                    prioridadDelProyectoHasta:=idPrioridadProyectoHasta,
                                    estadoDelProyecto:=idEstadoProyecto,
                                    clasificacionDelProyecto:=idClasificacionProyecto,
                                    enGarantia:=cmbEnGarantia.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
                                    enPrestamo:=cmbConPrestamo.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)(),
                                    estadoPrestamo:=cmbEstadoPrestamo.ValorSeleccionado(Of Entidades.CRMNovedad.EstadosProductosPrestados)(),
                                    tipoUsuario:=idTipoUsuario,
                                    visualizaSucursal:=Nothing,
                                    sucursales:=Nothing,
                                    categoriaReporta:=If(chbCategoriaReporta.Checked, Me.cmbCategoriaReporta.SelectedValue.ToString(), "TODOS"),
                                    If(chbVehiculo.Checked, bscCodigoVehiculo.Text, String.Empty))

      Me.ugDetalle.DataSource = dtDetalle
      Me.FormatearGrilla()
      Me.tssRegistros.Text = dtDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Public Sub FormatearGrilla()

      CRMNovedadesABM.FormatearGrilla(ugDetalle, TipoNovedad, pos:=0)

      'ugDetalle.AgregarFiltroEnLinea({Entidades.Cliente.Columnas.NombreCliente.ToString(),
      '                                Entidades.Cliente.Columnas.NombreDeFantasia.ToString(),
      '                                "NombreProspecto", "NombreDeFantasiaProspecto",
      '                                "NombreProveedor",
      '                                Entidades.CRMNovedad.Columnas.Descripcion.ToString()})
      'ugDetalle.DisplayLayout.UseFixedHeaders = True
      'ugDetalle.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None

      'With Me.ugDetalle.DisplayLayout.Bands(0)
      '   For Each columna As UltraGridColumn In .Columns
      '      columna.Hidden = True
      '   Next

      '   If Not .Columns.Exists("Ver") Then
      '      .Columns.Add("Ver")
      '   End If

      '   If Not .Columns.Exists(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1") Then
      '      .Columns.Add(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1", String.Empty)
      '   End If

      '   Dim pos As Integer = 0

      '   .Columns("Ver").FormatearColumna("Ver", pos, 30, HAlign.Center)
      '   .Columns("Ver").Style = ColumnStyle.Button
      '   .Columns("Ver").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
      '   .Columns("Ver").Header.Fixed = True

      '   .Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").FormatearColumna("", pos, 60)
      '   .Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").Header.Fixed = True
      '   .Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString() + "1").CellActivation = Activation.NoEdit

      '   .Columns(Entidades.CRMNovedad.Columnas.BanderaColor.ToString()).FormatearColumna("", 1000, 30, , True)

      '   .Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()).FormatearColumna("Tipo", pos, 60, , TipoNovedad IsNot Nothing)
      '   .Columns(Entidades.CRMNovedad.Columnas.Letra.ToString()).FormatearColumna("L.", pos, 25, HAlign.Center)
      '   .Columns(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()).FormatearColumna("Emisor", pos, 45, HAlign.Right, True)
      '   .Columns(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()).FormatearColumna("Número", pos, 60, HAlign.Right)

      '   .Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString()).FormatearColumna("Fecha / Hora", pos, 120, HAlign.Center, True, "dd/MM/yyyy HH:mm:ss")
      '   .Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString() + "_Fecha").FormatearColumna("Fecha", pos, 80, HAlign.Center)
      '   .Columns(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString() + "_Hora").FormatearColumna("Hora", pos, 40, HAlign.Center)

      '   If TipoNovedadTiene("CLIENTES") Then
      '      'Oculta
      '      .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right, True)
      '      .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).FormatearColumna("Nombre Cliente", pos, 200)
      '      .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).FormatearColumna("Nombre de Fantasia", pos, 200)
      '      .Columns("NombreCategoriaCliente").FormatearColumna("Categoria Cliente", pos, 120)
      '   End If

      '   If TipoNovedadTiene("PROSPECTOS") Then
      '      'Oculta
      '      .Columns("CodigoProspecto").FormatearColumna("Código", pos, 80, HAlign.Right, True)
      '      .Columns("NombreProspecto").FormatearColumna("Nombre Prospecto", pos, 200)
      '      .Columns("NombreDeFantasiaProspecto").FormatearColumna("Nombre de Fantasia", pos, 200)
      '      .Columns("NombreCategoriaProspecto").FormatearColumna("Categoria Prospecto", pos, 120)
      '   End If

      '   If TipoNovedadTiene("PROVEEDORES") Then
      '      .Columns("CodigoProveedor").FormatearColumna("Código", pos, 80, HAlign.Right, True)
      '      .Columns("NombreProveedor").FormatearColumna("Nombre Proveedor", pos, 200)
      '      .Columns("NombreCategoriaProveedor").FormatearColumna("Categoria Proveedor", pos, 120)
      '   End If

      '   .Columns(Entidades.CRMNovedad.Columnas.Interlocutor.ToString()).FormatearColumna("Interlocutor", pos, 80)

      '   If TipoNovedadTiene("PROYECTOS") Then
      '      .Columns(Entidades.CRMNovedad.Columnas.IdProyecto.ToString()).FormatearColumna("Proyecto", pos, 80, HAlign.Right)
      '   End If

      '   If TipoNovedadTiene("SISTEMAS") Then
      '      .Columns(Entidades.CRMNovedad.Columnas.IdSistema.ToString()).FormatearColumna("Sistema", pos, 80)
      '   End If

      '   .Columns(Entidades.CRMNovedad.Columnas.Descripcion.ToString()).FormatearColumna("Descripción", pos, 150)


      '   .Columns(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()).FormatearColumna("Estado", pos, 80)
      '   .Columns(Entidades.CRMEstadoNovedad.Columnas.Finalizado.ToString()).FormatearColumna("Fin.", pos, 40, HAlign.Center)
      '   .Columns("HorasFinalizacion").FormatearColumna("Tiempo Resolución", pos, 70, HAlign.Right)
      '   .Columns(Entidades.CRMNovedad.Columnas.IdUsuarioAsignado.ToString()).FormatearColumna("Usuario Asignado", pos, 70)
      '   .Columns(Entidades.CRMNovedad.Columnas.IdUsuarioResponsable.ToString()).FormatearColumna("Usuario Responsable", pos, 70)
      '   .Columns(Entidades.CRMPrioridadNovedad.Columnas.NombrePrioridadNovedad.ToString()).FormatearColumna("Prioridad", pos, 70)
      '   .Columns(Entidades.CRMNovedad.Columnas.Priorizado.ToString()).FormatearColumna("Priorizado", pos, 40)
      '   .Columns(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()).FormatearColumna("Categoria", pos, 110)

      '   If TipoNovedadTiene("METODORESOLUCION") Then
      '      .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString()).FormatearColumna("Resolución", pos, 80)
      '   End If

      '   .Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString()).FormatearColumna("Prox. Contacto", pos, 120, HAlign.Center, True, "dd/MM/yyyy HH:mm:ss")
      '   .Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString() + "_Fecha").FormatearColumna("Fecha Prox. Contacto", pos, 80, HAlign.Center)
      '   .Columns(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString() + "_Hora").FormatearColumna("Hora Prox. Contacto", pos, 40, HAlign.Center)

      '   .Columns(Entidades.CRMMedioComunicacionNovedad.Columnas.NombreMedioComunicacionNovedad.ToString()).FormatearColumna("Medio", pos, 100)

      '   .Columns(Entidades.CRMNovedad.Columnas.Avance.ToString()).FormatearColumna("% Av.", pos, 50, HAlign.Right)
      '   .Columns(Entidades.CRMNovedad.Columnas.Cantidad.ToString()).FormatearColumna(TipoNovedadParametro.UnidadDeMedida, pos, 50, HAlign.Right)

      '   .Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString()).FormatearColumna("Fecha/Hora Estado", pos, 80, HAlign.Center, True, "dd/MM/yyyy HH:mm:ss")
      '   .Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString() + "_Fecha").FormatearColumna("Fecha Estado", pos, 80, HAlign.Center)
      '   .Columns(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString() + "_Hora").FormatearColumna("Hora Estado", pos, 40, HAlign.Center)

      '   .Columns(Entidades.CRMNovedad.Columnas.IdUsuarioEstadoNovedad.ToString()).FormatearColumna("Usuario Estado", pos, 80)
      '   .Columns(Entidades.CRMNovedad.Columnas.IdUsuarioAlta.ToString()).FormatearColumna("Usuario Alta", pos, 80)
      '   .Columns(Entidades.CRMNovedad.Columnas.FechaAlta.ToString()).FormatearColumna("Fecha/Hora Alta", pos, 80, HAlign.Center, True, "dd/MM/yyyy HH:mm:ss")
      '   .Columns(Entidades.CRMNovedad.Columnas.FechaAlta.ToString() + "_Fecha").FormatearColumna("Fecha Alta", pos, 80, HAlign.Center)
      '   .Columns(Entidades.CRMNovedad.Columnas.FechaAlta.ToString() + "_Hora").FormatearColumna("Hora Alta", pos, 40, HAlign.Center)

      '   If TipoNovedadTiene("FUNCIONES") Then
      '      .Columns(Entidades.CRMNovedad.Columnas.IdFuncion.ToString()).FormatearColumna("Código Función", pos, 100)
      '      .Columns("NombreFuncion").FormatearColumna("Nombre Función", pos, 200)
      '      .Columns("NombreFuncion").FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
      '   End If

      '   .Columns(Entidades.CRMNovedad.Columnas.RevisionAdministrativa.ToString()).FormatearColumna("Rev. Adm.", pos, 40, HAlign.Center)

      '   If Publicos.CRMMuestraSolapaMasInfo Then
      '      .Columns(Entidades.CRMNovedad.Columnas.IdTipoNovedadPadre.ToString()).FormatearColumna("Tipo Padre", pos, 60, , TipoNovedad IsNot Nothing)
      '      .Columns(Entidades.CRMNovedad.Columnas.LetraPadre.ToString()).FormatearColumna("L. P.", pos, 25, HAlign.Center)
      '      .Columns(Entidades.CRMNovedad.Columnas.CentroEmisorPadre.ToString()).FormatearColumna("Emisor Padre", pos, 45, HAlign.Right, True)
      '      .Columns(Entidades.CRMNovedad.Columnas.IdNovedadPadre.ToString()).FormatearColumna("Número Padre", pos, 60, HAlign.Right)

      '      .Columns(Entidades.CRMNovedad.Columnas.Version.ToString()).FormatearColumna("Versión", pos, 80)
      '      .Columns(Entidades.CRMNovedad.Columnas.VersionFecha.ToString()).FormatearColumna("Fecha/Hora Versión", pos, 80, HAlign.Center, True, "dd/MM/yyyy HH:mm:ss")
      '      .Columns(Entidades.CRMNovedad.Columnas.VersionFecha.ToString() + "_Fecha").FormatearColumna("Fecha Versión", pos, 80, HAlign.Center)
      '      .Columns(Entidades.CRMNovedad.Columnas.VersionFecha.ToString() + "_Hora").FormatearColumna("Hora Versión", pos, 40, HAlign.Center)

      '      .Columns(Entidades.CRMNovedad.Columnas.TiempoEstimado.ToString()).FormatearColumna("Tiempo Estimado", pos, 45, HAlign.Right, True)

      '      .Columns(Entidades.CRMNovedad.Columnas.FechaInicioPlan.ToString()).FormatearColumna("Fecha/Hora Inicio Plan", pos, 80, HAlign.Center, True, "dd/MM/yyyy HH:mm:ss")
      '      .Columns(Entidades.CRMNovedad.Columnas.FechaInicioPlan.ToString() + "_Fecha").FormatearColumna("Fecha Inicio Plan", pos, 80, HAlign.Center)
      '      .Columns(Entidades.CRMNovedad.Columnas.FechaInicioPlan.ToString() + "_Hora").FormatearColumna("Hora Inicio Plan", pos, 40, HAlign.Center)

      '      .Columns(Entidades.CRMNovedad.Columnas.FechaFinPlan.ToString()).FormatearColumna("Fecha/Hora Fin Plan", pos, 80, HAlign.Center, True, "dd/MM/yyyy HH:mm:ss")
      '      .Columns(Entidades.CRMNovedad.Columnas.FechaFinPlan.ToString() + "_Fecha").FormatearColumna("Fecha Fin Plan", pos, 80, HAlign.Center)
      '      .Columns(Entidades.CRMNovedad.Columnas.FechaFinPlan.ToString() + "_Hora").FormatearColumna("Hora Fin Plan", pos, 40, HAlign.Center)

      '   End If

      '   If TipoNovedadTiene("OBSERVACION") Then
      '      .Columns(Entidades.CRMNovedad.Columnas.Observacion.ToString()).FormatearColumna("Observación", pos, 200, HAlign.Right)
      '   End If

      '   .Columns("IdZonaGeografica").FormatearColumna("Código Z.G.", pos, 60)
      '   .Columns("NombreZonaGeografica").FormatearColumna("Zona Geográfica", pos, 100)


      'End With

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

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("Nombre" + Modo.Value.ToString()).Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("Codigo" + Modo.Value.ToString()).Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("Id" + Modo.Value.ToString()).Value.ToString()

   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdProveedor").Value.ToString()

   End Sub

#End Region

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
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
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
            Me.CargarDatosFuncion(e.FilaDevuelta)
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
            Me.CargarDatosFuncion(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarDatosFuncion(dr As DataGridViewRow)
      Me.bscFuncionNuevo.Text = dr.Cells("Nombre").Value.ToString()
      Me.bscCodigoFuncionNuevo.Text = dr.Cells("Id").Value.ToString().Trim()
   End Sub

   Private Sub chbMetodoResolucion_CheckedChanged(sender As Object, e As EventArgs) Handles chbMetodoResolucion.CheckedChanged
      TryCatched(Sub() chbMetodoResolucion.FiltroCheckedChanged(cmbMetodoResolucion))
   End Sub

   Private Sub chbAplicacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbAplicacion.CheckedChanged
      Try
         Me.cmbAplicacion.Enabled = Me.chbAplicacion.Checked
         If Not Me.chbAplicacion.Checked Then
            Me.cmbAplicacion.SelectedIndex = -1
         Else
            If Me.cmbAplicacion.Items.Count > 0 Then
               Me.cmbAplicacion.SelectedIndex = 2
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
         _publicos.CargaComboVersiones(cmbVersion, If(chbAplicacion.Checked, cmbAplicacion.SelectedValue.ToString(), String.Empty))
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProyecto.CheckedChanged

      Try
         Me.bscCodigoProyecto.Enabled = Me.chbProyecto.Checked
         Me.bscProyecto.Enabled = bscCodigoProyecto.Enabled
         If Not Me.chbProyecto.Checked Then
            Me.bscCodigoProyecto.Text = String.Empty
            Me.bscProyecto.Text = String.Empty
         Else
            Me.bscCodigoProyecto.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub chbPrioridadProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbPrioridadProyecto.CheckedChanged
      Try
         Me.nudPrioridadDesde.Enabled = Me.chbPrioridadProyecto.Checked
         Me.nudPrioridadHasta.Enabled = Me.nudPrioridadDesde.Enabled
         If Not Me.chbPrioridadProyecto.Checked Then
            Me.nudPrioridadDesde.Value = 1
            Me.nudPrioridadHasta.Value = 5
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbEstadoProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstadoProyecto.CheckedChanged

      Try
         Me.cmbEstadoProyecto.Enabled = Me.chbEstadoProyecto.Checked
         If Not Me.chbEstadoProyecto.Checked Then
            Me.cmbEstadoProyecto.SelectedIndex = -1
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub chbClasificacionProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbClasificacionProyecto.CheckedChanged

      Try
         Me.cmbClasificacionProyecto.Enabled = Me.chbClasificacionProyecto.Checked
         If Not Me.chbClasificacionProyecto.Checked Then
            Me.cmbClasificacionProyecto.SelectedIndex = -1
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Private Sub bscProyecto_BuscadorClick() Handles bscProyecto.BuscadorClick

      Try
         Me._publicos.PreparaGrillaProyectos(Me.bscProyecto)
         Dim rProyectos As Reglas.Proyectos = New Reglas.Proyectos()
         Dim idCliente = If(chbProspecto.Checked, If(IsNumeric(bscCodigoCliente.Tag), Long.Parse(bscCodigoCliente.Tag.ToString()), 0), DirectCast(Nothing, Long?))
         Me.bscProyecto.Datos = rProyectos.GetFiltradoPorNombre(Me.bscProyecto.Text.Trim(), idCliente)

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
         Dim idCliente = If(chbProspecto.Checked, If(IsNumeric(bscCodigoCliente.Tag), Long.Parse(bscCodigoCliente.Tag.ToString()), 0), DirectCast(Nothing, Long?))
         Me.bscCodigoProyecto.Datos = rProyectos.GetFiltradoPorCodigo(codigoProyecto, idCliente)

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

   Private Sub CargarDatosProyecto(dr As DataGridViewRow)

      Me.bscCodigoProyecto.Text = dr.Cells("IdProyecto").Value.ToString()
      Me.bscProyecto.Text = dr.Cells("NombreProyecto").Value.ToString()
      bscCodigoProyecto.Selecciono = True
      bscProyecto.Selecciono = True
   End Sub

   '-- REQ-30962 --
   Private Sub chbTipoUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoUsuario.CheckedChanged
      Try
         Me.cmbTipoUsuario.Enabled = Me.chbTipoUsuario.Checked
         If Not Me.chbTipoUsuario.Checked Then
            Me.cmbTipoUsuario.SelectedIndex = -1
         Else
            If Me.cmbTipoUsuario.Items.Count > 0 Then
               Me.cmbTipoUsuario.SelectedIndex = 0
            End If
            Me.cmbTipoUsuario.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbNumeroPadre_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumeroPadre.CheckedChanged
      TryCatched(Sub()
                    Me.txtNumeroPadre.Enabled = Me.chbNumeroPadre.Checked
                    If Not Me.chbNumeroPadre.Checked Then
                       Me.txtNumeroPadre.Text = ""
                    Else
                       Me.txtNumeroPadre.Text = "0"
                       Me.txtNumeroPadre.Focus()
                    End If
                 End Sub)
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
End Class