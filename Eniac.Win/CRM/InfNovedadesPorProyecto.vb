Public Class InfNovedadesPorProyecto

   Private _publicos As Publicos

   Private Const EDITAR_PROYECTO_KEY As String = "mnuEditarProyecto"
   Private Const EDITAR_CLIENTE_KEY As String = "mnuEditarCliente"
   Private Const MOSTRAR_PREFIX_KEY As String = "mnuMostrar_"

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(Me.cmbProyectoFinalizado, GetType(Entidades.Publicos.SiNoTodos))
         _publicos.CargaComboDesdeEnum(Me.cmbFinalizado, GetType(Entidades.Publicos.SiNoTodos))
         _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad)
         _publicos.CargaComboProyectosEstados(cmbEstadoProyecto)
         _publicos.CargaComboClasificaciones(Me.cmbClasificacionProyecto)

         '-- REQ-30963 --
         Me._publicos.CargaComboTipoUsuarios(Me.cmbTipoUsuario)

         RefrescarDatosGrilla()

         GridContextMenuManager1.CargarMenuContextualGrilla()

         Dim itemProyecto = gridContextMenuStrip.Items.AddMenuItem("Editar Proyecto")
         itemProyecto.Name = EDITAR_PROYECTO_KEY
         AddHandler itemProyecto.Click, AddressOf tsbEditar_Click

         Dim itemCliente = gridContextMenuStrip.Items.AddMenuItem("Editar Cliente")
         itemCliente.Name = EDITAR_CLIENTE_KEY
         AddHandler itemCliente.Click, AddressOf editarCliente_Click

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         'Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbEditar_Click(sender As Object, e As EventArgs) Handles tsbEditar.Click
      TryCatched(Sub()
                    If New Reglas.Usuarios().TienePermisos("ProyectosABM") Then
                       Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)()
                       If dr IsNot Nothing Then
                          Dim idProyecto = dr.Field(Of Integer)(Entidades.Proyecto.Columnas.IdProyecto.ToString())
                          Dim proy = New Reglas.Proyectos().GetUno(idProyecto)
                          Using frm = New ProyectosDetalle(proy)
                             frm.StateForm = StateForm.Actualizar
                             frm.IdFuncion = "ProyectosABM"
                             If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                CargaGrillaDetalle()
                             End If
                          End Using
                       End If
                    End If
                 End Sub)
   End Sub

   Private Sub editarCliente_Click(sender As Object, e As EventArgs)
      TryCatched(Sub()
                    If New Reglas.Usuarios().TienePermisos("Clientes") Then
                       Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)()
                       If dr IsNot Nothing Then
                          Dim idCliente = dr.Field(Of Long)(Entidades.Cliente.Columnas.IdCliente.ToString())
                          Dim clte = New Reglas.Clientes().GetUno(idCliente)
                          Using frm = New ClientesDetalle(clte)
                             frm.StateForm = StateForm.Actualizar
                             frm.IdFuncion = "Clientes"
                             If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                                CargaGrillaDetalle()
                             End If
                          End Using
                       End If
                    End If
                 End Sub)
   End Sub

   Private Sub gridContextMenuStrip_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles gridContextMenuStrip.Opening
      TryCatched(Sub()
                    Dim regla = New Reglas.Usuarios()
                    gridContextMenuStrip.Items(EDITAR_PROYECTO_KEY).Enabled = regla.TienePermisos("ProyectosABM")
                    gridContextMenuStrip.Items(EDITAR_CLIENTE_KEY).Enabled = regla.TienePermisos("Clientes")
                 End Sub)
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + CargarFiltrosImpresion()

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
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         ugDetalle.Exportar(String.Format("{0}.xls", Me.Name), Me.Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         ugDetalle.Exportar(String.Format("{0}.pdf", Me.Name), Me.Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs)
      Me.UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub




   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      Try
         If Me.chkExpandAll.Checked Then
            Me.ugDetalle.Rows.ExpandAll(True)
         Else
            Me.ugDetalle.Rows.CollapseAll(True)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbTipoNovedad_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoNovedad.CheckedChanged
      Try
         chbTipoNovedad.FiltroCheckedChanged(cmbTipoNovedad)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbEstadoProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbEstadoProyecto.CheckedChanged, chbSoloConNovedades.CheckedChanged
      Try
         chbEstadoProyecto.FiltroCheckedChanged(cmbEstadoProyecto)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbClasificacionProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbClasificacionProyecto.CheckedChanged
      Try
         chbClasificacionProyecto.FiltroCheckedChanged(cmbClasificacionProyecto)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProyecto.CheckedChanged
      Try
         Me.chbProyecto.FiltroCheckedChanged(bscCodigoProyecto, bscProyecto)
         'GAR: 03/10/2020 - NO me amigo a tocar la rutira atnerior, pero no limpia al quitar el check.
         If Not Me.chbProyecto.Checked Then
            Me.bscCodigoProyecto.Text = String.Empty
            Me.bscProyecto.Text = String.Empty
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      Try
         chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscCliente)
         'GAR: 03/10/2020 - NO me amigo a tocar la rutira atnerior, pero no limpia al quitar el check.
         If Not Me.chbCliente.Checked Then
            Me.bscCodigoCliente.Text = String.Empty
            Me.bscCliente.Text = String.Empty
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

      Try

         Me.Cursor = Cursors.WaitCursor
         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.CargaGrillaDetalle()

         ugDetalle.AgregarTotalesSuma({Entidades.CRMNovedad.Columnas.Cantidad.ToString()})

         PreferenciasLeer(ugDetalle, tsbPreferencias)
         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub


#Region "Busquedas Foranea"
   Private Sub bscProyecto_BuscadorClick() Handles bscProyecto.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProyectos(Me.bscProyecto)
         Me.bscProyecto.Datos = New Reglas.Proyectos().GetFiltradoPorNombre(Me.bscProyecto.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscProyecto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProyecto.BuscadorSeleccion
      Try
         CargarDatosProyecto(e.FilaDevuelta)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscCodigoProyecto_BuscadorClick() Handles bscCodigoProyecto.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProyectos(Me.bscCodigoProyecto)
         Me.bscCodigoProyecto.Datos = New Reglas.Proyectos().GetFiltradoPorCodigo(Me.bscCodigoProyecto.Text.ToInt32())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscCodigoProyecto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProyecto.BuscadorSeleccion
      Try
         CargarDatosProyecto(e.FilaDevuelta)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub CargarDatosProyecto(dr As DataGridViewRow)
      If dr Is Nothing Then Return

      Me.bscCodigoProyecto.Text = dr.Cells("IdProyecto").Value.ToString()
      Me.bscProyecto.Text = dr.Cells("NombreProyecto").Value.ToString()
      bscCodigoProyecto.Selecciono = True
      bscProyecto.Selecciono = True

      bscCodigoCliente.Focus()

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Me.bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(Me.bscCodigoCliente.Text.ToInt64().IfNull(-1), True, False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         Me.CargarDatosCliente(e.FilaDevuelta)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Me.bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         Me.CargarDatosCliente(e.FilaDevuelta)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr Is Nothing Then Return

      Me.bscCliente.Text = dr.Cells(Entidades.Cliente.Columnas.NombreCliente.ToString()).Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()
      Me.bscCliente.Selecciono = True
      Me.bscCodigoCliente.Selecciono = True

      Me.btnConsultar.Focus()

   End Sub

#End Region

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()

      Me.cmbProyectoFinalizado.SelectedValue = Entidades.Publicos.SiNoTodos.NO
      Me.cmbFinalizado.SelectedValue = Entidades.Publicos.SiNoTodos.NO

      chbTipoNovedad.Checked = False
      chbProyecto.Checked = False
      chbEstadoProyecto.Checked = False
      chbClasificacionProyecto.Checked = False
      chbCliente.Checked = False

      chkExpandAll.Checked = False

      chbMuestraPendienters.Checked = True
      chbMuestraTotales.Checked = True
      chbMuestraAgrupadoPorEstado.Checked = True

      If TypeOf ugDetalle.DataSource Is DataTable Then
         DirectCast(ugDetalle.DataSource, DataTable).Clear()
      End If

   End Sub

   Private Sub CargaGrillaDetalle()

      If chbProyecto.Checked AndAlso (Not bscProyecto.Selecciono Or Not bscCodigoProyecto.Selecciono) Then
         bscCodigoProyecto.Focus()
         Throw New Exception(String.Format("ATENCION: No seleccionó un proyecto aunque activó ese Filtro."))
      End If
      If chbCliente.Checked AndAlso (Not bscCliente.Selecciono Or Not bscCodigoCliente.Selecciono) Then
         bscCodigoCliente.Focus()
         Throw New Exception(String.Format("ATENCION: No seleccionó un cliente aunque activó ese Filtro."))
      End If

      '# Tipo de Usuario del Proyecto
      Dim idTipoUsuario As Integer = 0
      If Me.chbTipoUsuario.Checked Then
         idTipoUsuario = Integer.Parse(Me.cmbTipoUsuario.SelectedValue.ToString())
      End If

      Dim dtDetalle As DataTable

      Dim regla = New Reglas.Proyectos()
      dtDetalle = regla.GetNovedadesPorProyecto(Me.cmbProyectoFinalizado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                Me.cmbFinalizado.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                If(chbEstadoProyecto.Checked, cmbEstadoProyecto.ValorSeleccionado(Of Integer), 0),
                                                If(chbTipoNovedad.Checked, cmbTipoNovedad.ValorSeleccionado(Of String), String.Empty),
                                                If(chbProyecto.Checked, bscCodigoProyecto.Text.ToInt32().IfNull(), 0),
                                                If(chbCliente.Checked, bscCodigoCliente.Tag.ToString().ToInt64().IfNull(), 0),
                                                If(chbClasificacionProyecto.Checked, cmbClasificacionProyecto.ValorSeleccionado(Of Integer), 0),
                                                chbSoloConNovedades.Checked, idTipoUsuario)

      Me.ugDetalle.DataSource = dtDetalle
      Me.FormatearGrilla()

   End Sub


   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New System.Text.StringBuilder()
      With filtro

         filtro.AppendFormat("{0}: {1}", lblFinalizado.Text, cmbFinalizado.Text)

         If chbTipoNovedad.Checked Then
            filtro.AppendFormat(" - {0}: {1}", chbTipoNovedad.Text, cmbTipoNovedad.Text)
         End If

         If chbProyecto.Checked Then
            filtro.AppendFormat(" - {0}: {1} - {2}", chbProyecto.Text, bscCodigoProyecto.Text, bscProyecto.Text)
         End If
         If chbEstadoProyecto.Checked Then
            filtro.AppendFormat(" - {0}: {1}", chbEstadoProyecto.Text, cmbEstadoProyecto.Text)
         End If
         If chbClasificacionProyecto.Checked Then
            filtro.AppendFormat(" - {0}: {1}", chbClasificacionProyecto.Text, cmbClasificacionProyecto.Text)
         End If

         If chbCliente.Checked Then
            filtro.AppendFormat(" - {0}: {1} - {2}", chbCliente.Text, bscCodigoCliente.Text, bscCliente.Text)
         End If

      End With

      Return filtro.ToString()

   End Function

   Private Sub FormatearGrilla()
      With Me.ugDetalle.DisplayLayout.Bands(0)
         For Each columna In .Columns
            columna.Hidden = True
         Next

         ugDetalle.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True
         ugDetalle.InicializaTotales()
         ugDetalle.DisplayLayout.UseFixedHeaders = True

         Dim pos As Integer = 0

         .Columns(Entidades.Proyecto.Columnas.IdProyecto.ToString()).FormatearColumna("Código", pos, 60, HAlign.Right).Header.Fixed = True
         .Columns(Entidades.Proyecto.Columnas.NombreProyecto.ToString()).FormatearColumna("Proyecto", pos, 200).Header.Fixed = True

         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).OcultoPosicion(True, pos)
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).FormatearColumna("Cliente", pos, 200)
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).FormatearColumna("Nombre de Fantasía", pos, 200)

         .Columns(Entidades.Proyecto.Columnas.IdEstado.ToString()).OcultoPosicion(True, pos)
         .Columns(Entidades.ProyectoEstado.Columnas.NombreEstado.ToString()).FormatearColumna("Estado", pos, 100)
         .Columns(Entidades.Proyecto.Columnas.IdClasificacion.ToString()).OcultoPosicion(True, pos)
         .Columns(Entidades.Clasificacion.Columnas.NombreClasificacion.ToString()).FormatearColumna("Clasificación", pos, 90)
         .Columns(Entidades.Proyecto.Columnas.IdPrioridadProyecto.ToString()).FormatearColumna("Prioridad", pos, 70, HAlign.Right, , "N2")

         .Columns(Entidades.Proyecto.Columnas.FechaInicio.ToString()).FormatearColumna("Inicio", pos, 80, HAlign.Center)
         .Columns(Entidades.Proyecto.Columnas.FechaFin.ToString()).FormatearColumna("Fin", pos, 80, HAlign.Center)
         .Columns(Entidades.Proyecto.Columnas.FechaFinReal.ToString()).FormatearColumna("Fin Real", pos, 80, HAlign.Center)

         .Columns(Entidades.Proyecto.Columnas.HsRealEstimadas.ToString()).FormatearColumna("HS Estimadas", pos, 80, HAlign.Right, , "N0")
         .Columns(Entidades.Proyecto.Columnas.Estimado.ToString()).FormatearColumna("HS Cobradas", pos, 80, HAlign.Right, , "N0")
         .Columns(Entidades.Proyecto.Columnas.HsInformadas.ToString()).FormatearColumna("HS Informadas", pos, 80, HAlign.Right, , "N0")
         .Columns("CantidadHorasHijos").FormatearColumna("HS Insumidas", pos, 80, HAlign.Right, , "N2")
         .Columns("DifHSCobradas").FormatearColumna("Dif. HS Cobradas", pos, 80, HAlign.Right, , "N2")
         .Columns("DifHSInformadas").FormatearColumna("Dif HS Informadas", pos, 80, HAlign.Right, , "N2")

         Dim col = New List(Of String)()

         Dim paraBorrar = New List(Of String)()
         For Each item As ToolStripItem In gridContextMenuStrip.Items
            If item.Name.StartsWith(MOSTRAR_PREFIX_KEY) Then
               paraBorrar.Add(item.Name)
            End If
         Next
         paraBorrar.All(Function(x)
                           gridContextMenuStrip.Items.RemoveByKey(x)
                           Return True
                        End Function)

         Dim colorPallete = New List(Of Color) From {Color.DarkSeaGreen, Color.DarkTurquoise, Color.PaleVioletRed}
         Dim indexColor = 0

         Dim basePositionTipoNovedad As Integer = 500
         For Each columna In .Columns
            If columna.Key.StartsWith("___") Then
               Dim keyValues = columna.Key.Replace("___", "")
               Dim tipo = Reglas.Cache.CRMCacheHandler.Instancia.Tipos.Buscar(keyValues)

               If tipo IsNot Nothing Then
                  columna.Hidden = False
                  columna.Header.VisiblePosition = basePositionTipoNovedad
                  basePositionTipoNovedad += 1
                  columna.Header.Caption = String.Format("{0}", tipo.NombreTipoNovedad)
                  columna.Width = 75
                  columna.CellAppearance.TextHAlign = HAlign.Right

                  columna.CellAppearance.BackColor = If(Not chbTipoNovedad.Checked, colorPallete(indexColor Mod 3), Nothing)
                  columna.CellAppearance.ForegroundAlpha = Alpha.Opaque
                  columna.CellAppearance.BackColorAlpha = Alpha.UseAlphaLevel
                  columna.CellAppearance.AlphaLevel = 50

                  col.Add(columna.Key)

                  Dim columna1 = .Columns(String.Concat(columna.Key, "_TOTALES"))
                  columna1.Hidden = False
                  columna1.Header.VisiblePosition = basePositionTipoNovedad
                  basePositionTipoNovedad += 1
                  columna1.Header.Caption = String.Format("Total {0}", tipo.NombreTipoNovedad)
                  columna1.Width = 75
                  columna1.CellAppearance.TextHAlign = HAlign.Right

                  columna1.CellAppearance.BackColor = columna.CellAppearance.BackColor
                  columna1.CellAppearance.ForegroundAlpha = columna.CellAppearance.ForegroundAlpha
                  columna1.CellAppearance.BackColorAlpha = columna.CellAppearance.BackColorAlpha
                  columna1.CellAppearance.AlphaLevel = columna.CellAppearance.AlphaLevel
                  indexColor += 1

                  col.Add(columna1.Key)

                  Dim item = gridContextMenuStrip.Items.AddMenuItem(String.Format("Mostrar {0}", tipo.NombreTipoNovedad))
                  item.Name = String.Concat(MOSTRAR_PREFIX_KEY, "_", tipo.IdTipoNovedad)
                  item.Enabled = New Reglas.Usuarios().TienePermisos(String.Concat("CRMNOVEDADESABM", tipo.IdTipoNovedad))
                  AddHandler item.Click, Sub(sender, e)
                                            TryCatched(Sub()
                                                          Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)()
                                                          If dr IsNot Nothing Then
                                                             Dim idProyecto = dr.Field(Of Integer)(Entidades.Proyecto.Columnas.IdProyecto.ToString())
                                                             Dim frm = New CRMNovedadesABM()
                                                             frm.Parametros = New CRMNovedadesABM.ParametrosLlamador() _
                                                                                 With {
                                                                                       .IdProyecto = idProyecto,
                                                                                       .IgnoraFiltrosPersonalizados = False,
                                                                                       .QuitarFiltroPorUsuario = True
                                                                                       }
                                                             DirectCast(frm, IConParametros).SetParametros(String.Format("TipoNovedad={0}", tipo.IdTipoNovedad))
                                                             'frm.IdProyecto = idProyecto
                                                             'frm.IgnoraFiltrosPersonalizados = False
                                                             'frm.QuitarFiltroPorUsuario = True
                                                             frm.IdFuncion = String.Concat("CRMNOVEDADESABM", tipo.IdTipoNovedad)
                                                             frm.MdiParent = MdiParent
                                                             frm.Show()
                                                          End If
                                                       End Sub)
                                         End Sub

               End If
               'ugDetalle.AgregarTotalSumaColumna(columna)
            End If
         Next
         Dim basePosition = New Dictionary(Of String, Integer)()
         For Each columna In .Columns
            If columna.Key.Contains("/") Then
               Dim keyValues = columna.Key.Split("/"c)
               Dim tipo = Reglas.Cache.CRMCacheHandler.Instancia.Tipos.Buscar(keyValues(0))
               Dim estado = Reglas.Cache.CRMCacheHandler.Instancia.Estados.Buscar(Integer.Parse(keyValues(1)))

               If Not basePosition.ContainsKey(tipo.IdTipoNovedad) Then
                  basePosition.Add(tipo.IdTipoNovedad, (basePosition.Count + 1) * 1000)
               End If

               columna.Hidden = False
               columna.CellAppearance.BackColor = estado.Color.ToArgbColor()
               columna.Header.VisiblePosition = basePosition(tipo.IdTipoNovedad) + estado.Posicion
               columna.Header.Caption = String.Format("{0} / {1}", tipo.NombreTipoNovedad, estado.NombreEstadoNovedad)
               columna.Width = 100
               columna.CellAppearance.TextHAlign = HAlign.Right

               col.Add(columna.Key)
               'ugDetalle.AgregarTotalSumaColumna(columna)
            End If
         Next
         col.Add(Entidades.Proyecto.Columnas.HsRealEstimadas.ToString())
         col.Add(Entidades.Proyecto.Columnas.Estimado.ToString())
         col.Add(Entidades.Proyecto.Columnas.HsInformadas.ToString())
         col.Add("CantidadHorasHijos")

         ugDetalle.AgregarTotalesSuma(col.ToArray())

         ugDetalle.AgregarFiltroEnLinea({Entidades.Proyecto.Columnas.NombreProyecto.ToString(),
                                         Entidades.Cliente.Columnas.NombreCliente.ToString(),
                                         Entidades.Cliente.Columnas.NombreDeFantasia.ToString()})

         MostrarOcultar()

      End With
   End Sub

   Private Sub MostrarOcultar()
      MostrarOcultar(chbMuestraPendienters.Checked, chbMuestraTotales.Checked, chbMuestraAgrupadoPorEstado.Checked)
   End Sub

   Private Sub MostrarOcultar(pendientes As Boolean, totales As Boolean, porEstado As Boolean)
      For Each columna In Me.ugDetalle.DisplayLayout.Bands(0).Columns
         If columna.Key.StartsWith("___") AndAlso columna.Key.EndsWith("_TOTALES") Then
            columna.Hidden = Not totales
         ElseIf columna.Key.StartsWith("___") AndAlso Not columna.Key.EndsWith("_") Then
            columna.Hidden = Not pendientes
         ElseIf columna.Key.Contains("/") Then
            columna.Hidden = Not porEstado
         End If
      Next

      With Me.ugDetalle.DisplayLayout.Bands(0)
         Dim ocultar As Action(Of String, Boolean) = Sub(c, h) If .Columns.Exists(c) Then .Columns(c).Hidden = h

         ocultar(Entidades.Proyecto.Columnas.FechaInicio.ToString(), Not chbMuestraDetalleProyecto.Checked)
         ocultar(Entidades.Proyecto.Columnas.FechaFin.ToString(), Not chbMuestraDetalleProyecto.Checked)
         ocultar(Entidades.Proyecto.Columnas.FechaFinReal.ToString(), Not chbMuestraDetalleProyecto.Checked)
         ocultar(Entidades.Proyecto.Columnas.HsRealEstimadas.ToString(), Not chbMuestraDetalleProyecto.Checked)
         ocultar(Entidades.Proyecto.Columnas.Estimado.ToString(), Not chbMuestraDetalleProyecto.Checked)
         ocultar(Entidades.Proyecto.Columnas.HsInformadas.ToString(), Not chbMuestraDetalleProyecto.Checked)
         ocultar("CantidadHorasHijos", Not chbMuestraDetalleProyecto.Checked)
         ocultar("DifHSCobradas", Not chbMuestraDetalleProyecto.Checked)
         ocultar("DifHSInformadas", Not chbMuestraDetalleProyecto.Checked)

      End With

   End Sub
#End Region

   Private Sub chbMuestra_CheckedChanged(sender As Object, e As EventArgs) Handles chbMuestraAgrupadoPorEstado.CheckedChanged, chbMuestraTotales.CheckedChanged, chbMuestraPendienters.CheckedChanged, chbMuestraDetalleProyecto.CheckedChanged
      TryCatched(Sub() MostrarOcultar())
   End Sub

   '-- REQ-30963 --
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
End Class