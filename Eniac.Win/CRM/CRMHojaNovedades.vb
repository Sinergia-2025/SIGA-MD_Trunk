Public Class CRMHojaNovedades

#Region "Campos"

   Private _publicos As Publicos
   Private _tienePermisoParaVerOtrosUsuarios As Boolean
   Private _fechaDesdeAnterior As Date?
   Private _refrescando As Boolean = False
   Private _muestraProyecto As Boolean
   Private _extrasSinergia As Boolean = False

   Private _feriados As New List(Of Entidades.Feriado)()
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboUsuarios(cmbIdUsuarioAsignado)
         _publicos.CargaComboDesdeEnum(cmbRevisionAdministrativa, GetType(Entidades.Publicos.SiNoTodos))
         _publicos.CargaComboDesdeEnum(cmbTotalizarPorMes, GetType(Entidades.Publicos.PeriodosCalendarios))
         cmbTotalizarPorMes.SelectedValue = Entidades.Publicos.PeriodosCalendarios.Dia

         _publicos.CargaComboCRMCategoriasNovedades(cmbCategoriaNovedad, "ACTIVIDAD")
         _publicos.CargaComboCRMTiposCategoriasNovedades(cmbTipoCategoriaNovedad, "ACTIVIDAD")

         _tienePermisoParaVerOtrosUsuarios = New Eniac.Reglas.Usuarios().TienePermisos(actual.Nombre, actual.Sucursal.Id, "ACTIVIDAD-VerOtrosUsuarios")

         '#Misma lógica que muestra la solapa Sinergia en DetalleABM.
         _extrasSinergia = Reglas.Publicos.ExtrasSinergia
         If Not _extrasSinergia Then
            chbFuncionNuevo.Visible = False
            bscFuncionNuevo.Visible = False
            chbNumero.Visible = False
            txtNumero.Visible = False
         End If

         _publicos.CargaComboCRMTiposNovedades(tscNovedades.ComboBox)
         If tscNovedades.ComboBox.Items.Count > 0 Then
            tscNovedades.ComboBox.SelectedIndex = 0
         End If

         Dim tipos = New Reglas.CRMTiposNovedades().GetTodos(reportaCantidad:=True)
         cmbRevisionAdministrativa.Visible = tipos.Any(Function(x) x.VisualizaRevisionAdministrativa)
         lblRevisionAdministrativa.Visible = cmbRevisionAdministrativa.Visible
         _muestraProyecto = tipos.Any(Function(x) x.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.PROYECTOS))

         RefrescarDatosGrilla()
         chbIdUsuarioAsignado.Enabled = _tienePermisoParaVerOtrosUsuarios
         cmbIdUsuarioAsignado.Enabled = _tienePermisoParaVerOtrosUsuarios
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir("Hoja de Novedades", New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, "Hoja de Novedades"))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, "Hoja de Novedades"))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
   Private Sub tsbNuevaNovedad_Click(sender As Object, e As EventArgs) Handles tsbNuevaNovedad.Click
      'Try
      '   Dim oDet As CRMNovedadesDetalle

      '   Dim tipoNov As Eniac.Entidades.CRMTipoNovedad

      '   tipoNov = DirectCast(Me.tscNovedades.ComboBox.SelectedItem, Entidades.CRMTipoNovedad)

      '   oDet = New CRMNovedadesDetalle(New Eniac.Entidades.CRMNovedad, tipoNov)

      '   oDet.MdiParent = MdiParent

      '   oDet.Show()
      'Catch ex As Exception
      '   ShowError(ex)
      'End Try
   End Sub
#End Region
#Region "Eventos Filtros"
   Private Sub chbIdUsuarioAsignado_CheckedChanged(sender As Object, e As EventArgs) Handles chbIdUsuarioAsignado.CheckedChanged
      TryCatched(Sub() chbIdUsuarioAsignado.FiltroCheckedChanged(cmbIdUsuarioAsignado, actual.Nombre, actual.Nombre))
   End Sub
   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      TryCatched(Sub() chbMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged
      TryCatched(
      Sub()
         If Not _refrescando Then
            If _fechaDesdeAnterior.HasValue AndAlso chbBloquearFechaHasta.Checked Then
               dtpHasta.Value = dtpHasta.Value.AddDays(dtpDesde.Value.Subtract(_fechaDesdeAnterior.Value).TotalDays)
            End If
         End If
         _fechaDesdeAnterior = dtpDesde.Value
      End Sub)
   End Sub
   Private Sub chbBloquearFechaHasta_CheckedChanged(sender As Object, e As EventArgs) Handles chbBloquearFechaHasta.CheckedChanged
      TryCatched(Sub() dtpHasta.Enabled = Not chbBloquearFechaHasta.Checked)
   End Sub
   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      TryCatched(Sub() chbNumero.FiltroCheckedChanged(txtNumero))
   End Sub
   Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
      TryCatched(
      Sub()
         If e.KeyCode = Keys.Enter Then
            If txtNumero.ValorNumericoPorDefecto(0L) > 0 Then
               btnConsultar.PerformClick()
            End If
         End If
      End Sub)
   End Sub
#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region
#Region "Eventos Buscador Proyectos"
   Private Sub chbProyecto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProyecto.CheckedChanged
      TryCatched(Sub() chbProyecto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProyecto, bscProyecto))
   End Sub
   Private Sub bscProyecto_BuscadorClick() Handles bscProyecto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProyectos(bscProyecto)
         '# Si se seleccionó un cliente, traigo solo los proyectos de ese cliente
         bscProyecto.Datos = New Reglas.Proyectos().GetFiltradoPorNombre(bscProyecto.Text.Trim(), FiltrarPorCliente())
      End Sub)
   End Sub
   Private Sub bscCodigoProyecto_BuscadorClick() Handles bscCodigoProyecto.BuscadorClick
      TryCatched(
      Sub()
         Dim codigoProyecto = bscCodigoProyecto.Text.ValorNumericoPorDefecto(0I).NullIf(0)
         _publicos.PreparaGrillaProyectos(bscCodigoProyecto)
         '# Si se seleccionó un cliente, traigo solo los proyectos de ese cliente
         bscCodigoProyecto.Datos = New Reglas.Proyectos().GetFiltradoPorCodigo(codigoProyecto, FiltrarPorCliente())
      End Sub)
   End Sub
   Private Sub bscProyecto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProyecto.BuscadorSeleccion, bscProyecto.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProyecto(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbTipoCategoriaNovedad_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoCategoriaNovedad.CheckedChanged
      TryCatched(Sub() chbTipoCategoriaNovedad.FiltroCheckedChanged(cmbTipoCategoriaNovedad))
   End Sub
   Private Sub chbCategoriaNovedad_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriaNovedad.CheckedChanged
      TryCatched(Sub() chbCategoriaNovedad.FiltroCheckedChanged(cmbCategoriaNovedad))
   End Sub
#Region "Eventos Buscador Funciones"
   Private Sub chbFuncionNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles chbFuncionNuevo.CheckedChanged
      TryCatched(Sub() chbFuncionNuevo.FiltroCheckedChanged(usaPermitido:=True, bscCodigoFuncionNuevo, bscFuncionNuevo))
   End Sub
   Private Sub bscCodigoFuncionNuevo_BuscadorClick() Handles bscCodigoFuncionNuevo.BuscadorClick

   End Sub
   Private Sub bscFuncionNuevo_BuscadorClick() Handles bscFuncionNuevo.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaFunciones2(bscFuncionNuevo)
         bscFuncionNuevo.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(String.Empty, bscFuncionNuevo.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoFuncionNuevo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoFuncionNuevo.BuscadorSeleccion, bscFuncionNuevo.BuscadorSeleccion
      TryCatched(Sub() CargarDatosFuncion(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbSabadosDomingoFeriado_CheckedChanged(sender As Object, e As EventArgs) Handles chbSabados.CheckedChanged, chbDomingos.CheckedChanged, chbFeriados.CheckedChanged, chbSinHoras.CheckedChanged
      TryCatched(Sub() MostrarFechas())
   End Sub
#End Region
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If ValidarFiltros() Then
            CargaGrillaDetalle()
         End If
      End Sub)
   End Sub

   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
      TryCatched(Sub() VerActividades(e.Cell))
   End Sub

#End Region

#Region "Metodos"
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscCodigoCliente.Selecciono = True
         bscCliente.Selecciono = True
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarDatosProyecto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoProyecto.Text = dr.Cells("IdProyecto").Value.ToString()
         bscProyecto.Text = dr.Cells("NombreProyecto").Value.ToString()
         bscCodigoProyecto.Selecciono = True
         bscProyecto.Selecciono = True
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarDatosFuncion(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscFuncionNuevo.Text = dr.Cells("Nombre").Value.ToString()
         bscCodigoFuncionNuevo.Text = dr.Cells("Id").Value.ToString().Trim()
         bscFuncionNuevo.Selecciono = True
         bscCodigoFuncionNuevo.Selecciono = True
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub RefrescarDatosGrilla()
      Try
         _refrescando = True

         chbIdUsuarioAsignado.Checked = True
         cmbIdUsuarioAsignado.SelectedValue = actual.Nombre

         chbMesCompleto.Checked = False
         chbBloquearFechaHasta.Checked = True

         dtpHasta.Value = Today

         While dtpHasta.Value.DayOfWeek <> DayOfWeek.Sunday
            dtpHasta.Value = dtpHasta.Value.AddDays(1)
         End While

         dtpDesde.Value = dtpHasta.Value.AddDays(-6)

         chbVerActividades.Checked = False
         chbTotalizadoPorCategoria.Checked = False
         cmbRevisionAdministrativa.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS

         chbCliente.Checked = False
         chbProyecto.Checked = False

         chbTipoCategoriaNovedad.Checked = False
         chbCategoriaNovedad.Checked = False

         chbSabados.Checked = True
         chbDomingos.Checked = True
         chbFeriados.Checked = True

         chbFuncionNuevo.Checked = False
         chbNumero.Checked = False

         ugDetalle.DataSource = Nothing

      Finally
         _refrescando = False
      End Try

   End Sub
   Private Function ValidarFiltros() As Boolean
      '# Cliente
      If chbCliente.Checked AndAlso Not (bscCodigoCliente.Selecciono AndAlso bscCliente.Selecciono) Then
         ShowMessage("ATENCIÓN: Activo el filtro por cliente pero no seleccionó uno.")
         bscCliente.Focus()
         Return False
      End If

      '# Proyecto
      If chbProyecto.Checked AndAlso Not (bscCodigoProyecto.Selecciono AndAlso bscProyecto.Selecciono) Then
         ShowMessage("ATENCIÓN: Activo el filtro por Proyecto pero no seleccionó uno.")
         bscProyecto.Focus()
         Return False
      End If

      '# Función
      If chbFuncionNuevo.Checked AndAlso Not (bscFuncionNuevo.Selecciono AndAlso bscCodigoFuncionNuevo.Selecciono) Then
         ShowMessage("ATENCIÓN: Activo el filtro por Función pero no seleccionó una.")
         bscFuncionNuevo.Focus()
         Return False
      End If

      '# Número
      If chbNumero.Checked AndAlso String.IsNullOrEmpty(txtNumero.Text) Then
         ShowMessage("ATENCIÓN: Activo el filtro por Número pero no ingresó uno.")
         txtNumero.Focus()
         Return False
      End If

      Return True
   End Function
   Public Sub CargaGrillaDetalle()

      If dtpDesde.Value > dtpHasta.Value Then
         Throw New Exception("La fecha desde debe ser anterior o igual a la fecha hasta.")
      End If

      Dim rCRM = New Reglas.CRMNovedades()
      Dim idCliente As Long? = Nothing
      Dim idProyecto As Integer? = Nothing
      Dim idNovedad As Integer = If(chbNumero.Checked, CInt(txtNumero.Text), 0)
      Dim idAplicacion = String.Empty
      Dim nroVersion = String.Empty
      Dim funcion As String = Me.bscCodigoFuncionNuevo.Text

      If chbCliente.Checked Then
         idCliente = FiltrarPorCliente()
      End If
      'If Me.bscCliente.Selecciono AndAlso Me.bscCodigoCliente.Selecciono Then
      '   idCliente = If(Me.bscCodigoCliente.Tag IsNot Nothing, Long.Parse(Me.bscCodigoCliente.Tag.ToString()), Long.Parse(Me.bscCliente.Tag.ToString()))
      'End If
      If bscProyecto.Selecciono AndAlso bscCodigoProyecto.Selecciono AndAlso chbProyecto.Checked Then
         idProyecto = bscCodigoProyecto.Text.ValorNumericoPorDefecto(0I) ' If(bscCodigoProyecto.Tag IsNot Nothing, CInt(Me.bscCodigoProyecto.Tag), CInt(Me.bscProyecto.Tag))
      End If

      Dim dt = rCRM.GetHojaNovedades(If(chbIdUsuarioAsignado.Checked, cmbIdUsuarioAsignado.ValorSeleccionado(Of String), String.Empty),
                                     chbVerActividades.Checked, cmbRevisionAdministrativa.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                     dtpDesde.Value, dtpHasta.Value, idCliente, idProyecto,
                                     If(chbTipoCategoriaNovedad.Checked, cmbTipoCategoriaNovedad.ValorSeleccionado(Of Integer), 0),
                                     If(chbCategoriaNovedad.Checked, cmbCategoriaNovedad.ValorSeleccionado(Of Integer), 0),
                                     chbTotalizadoPorCategoria.Checked,
                                     idNovedad, idAplicacion, nroVersion, funcion,
                                     cmbTotalizarPorMes.ValorSeleccionado(Of Entidades.Publicos.PeriodosCalendarios))

      _feriados = New Reglas.Feriados().GetTodos(dtpDesde.Value, dtpHasta.Value)

      ugDetalle.DataSource = dt
      FormatearGrilla()
      CargarColumnasASumar()
      ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "Proyecto", "NombreFuncion"})
   End Sub
   Private Sub FormatearGrilla()

      With ugDetalle.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         '-- REQ-33545.- --------------------------------------------------------------------------------------------------------
         .Columns("Total").FormatearColumna("Total", pos, 70, HAlign.Right, , "N2").Header.Appearance.TextHAlign = HAlign.Center
         '-----------------------------------------------------------------------------------------------------------------------
         If chbTotalizadoPorCategoria.Checked Then
            .Columns("NombreCategoriaNovedad").FormatearColumna("Categoria", pos, 150)
         Else
            .Columns("IdUsuarioAsignado").FormatearColumna("Usuario", pos, 80, , chbIdUsuarioAsignado.Checked)
            .Columns("IdCliente").FormatearColumna("Id Cliente", pos, 80, HAlign.Right, hidden:=True)
            .Columns("CodigoCliente").FormatearColumna("Codigo Cliente", pos, 80, HAlign.Right, hidden:=True)
            .Columns("NombreCliente").FormatearColumna("Cliente", pos, 200)
            .Columns("Proyecto").FormatearColumna("Proyecto", pos, 100, , Not _muestraProyecto)

            If chbVerActividades.Checked Then
               .Columns("NombreFuncion").FormatearColumna("Función", pos, 100)
               .Columns("NombreCategoriaNovedad").FormatearColumna("Categoria", pos, 150)
            End If

         End If

         For Each columna As UltraGridColumn In .Columns.Cast(Of UltraGridColumn).Where(Function(x) x.Key.StartsWith("Fecha_"))
            Dim fechaStr As String = columna.Key.Replace("Fecha_", "")
            Dim fecha = Date.ParseExact(fechaStr, "yyyyMMdd", Globalization.CultureInfo.InvariantCulture)
            columna.FormatearColumna(String.Format("{1} {0:dd/MM}", fecha, fecha.GetDiaEnEspanol(FormatoNombres.PrimerLetra)), pos, 60, HAlign.Right, , "N2").Header.Appearance.TextHAlign = HAlign.Center
            MostrarFechas(columna, fecha)
            If fecha.DayOfWeek = DayOfWeek.Sunday Or _feriados.Any(Function(f) f.FechaFeriado = fecha) Then
               columna.Color(Nothing, Color.LightCoral)
            ElseIf fecha.DayOfWeek = DayOfWeek.Saturday Then
               columna.Color(Nothing, Color.LightYellow)
            Else
               columna.Color(Nothing, Nothing)
            End If
         Next
         For Each columna As UltraGridColumn In .Columns.Cast(Of UltraGridColumn).Where(Function(x) x.Key.StartsWith("Mes_"))
            Dim fechaStr As String = columna.Key.Replace("Mes_", "")
            Dim fecha = Date.ParseExact(fechaStr + "01", "yyyyMMdd", Globalization.CultureInfo.InvariantCulture)
            columna.FormatearColumna(String.Format("{1} {0:yyyy}", fecha, fecha.GetMesEnEspanol(FormatoNombres.PrimerLetra)), pos, 60, HAlign.Right, , "N2").Header.Appearance.TextHAlign = HAlign.Center
            columna.Color(Nothing, Nothing)
         Next
         For Each columna As UltraGridColumn In .Columns.Cast(Of UltraGridColumn).Where(Function(x) x.Key.StartsWith("Anio_"))
            Dim fechaStr As String = columna.Key.Replace("Anio_", "")
            columna.FormatearColumna(fechaStr, pos, 60, HAlign.Right, , "N2").Header.Appearance.TextHAlign = HAlign.Center
            columna.Color(Nothing, Nothing)
         Next


         If Not chbTotalizadoPorCategoria.Checked Then
            .Columns("NombreCategoria").FormatearColumna("Categoria", pos, 100)
            .Columns("NombreEstadoCliente").FormatearColumna("Estado", pos, 100)
            .Columns("NombreTipoCliente").FormatearColumna("Tipo", pos, 100)

            .Columns("IdEstado").FormatearColumna("Codigo Estado", pos, 80, HAlign.Right, hidden:=True)
            .Columns("NombreEstado").FormatearColumna("Estado Proyecto", pos, 120)
            .Columns("IdClasificacion").FormatearColumna("Codigo Clasificación", pos, 80, HAlign.Right, hidden:=True)
            .Columns("NombreClasificacion").FormatearColumna("Clasificación Proyecto", pos, 120)
         End If
      End With
      MostrarFechas()
   End Sub
   Private Sub CargarColumnasASumar()
      Dim cols As List(Of String) = Me.ugDetalle.DisplayLayout.Bands(0).Columns.Cast(Of UltraGridColumn).
                  Where(Function(x) x.Key.StartsWith("Fecha_") Or x.Key.StartsWith("Mes_") Or x.Key.StartsWith("Anio_")).
                  ToList().ConvertAll(Function(x) x.Key)
      cols.Add("Total")
      ugDetalle.AgregarTotalesSuma(cols.ToArray())
   End Sub

   Private Function FiltrarPorCliente() As Long?
      If bscCliente.Selecciono AndAlso bscCodigoCliente.Selecciono AndAlso bscCodigoCliente.Tag IsNot Nothing Then
         Return Long.Parse(bscCodigoCliente.Tag.ToString())
      End If
      Return Nothing
   End Function

   Private Sub MostrarFechas(columna As UltraGridColumn, fecha As Date?)
      If fecha.HasValue Then
         columna.Hidden = (Not chbDomingos.Checked And fecha.Value.DayOfWeek = DayOfWeek.Sunday) Or
                          (Not chbSabados.Checked And fecha.Value.DayOfWeek = DayOfWeek.Saturday) Or
                          (Not chbFeriados.Checked And _feriados.Any(Function(f) f.FechaFeriado = fecha.Value))
      Else
         columna.Hidden = False
      End If
      If chbSinHoras.Checked Then
         If columna.Band.Summaries.Exists(columna.Key) AndAlso Decimal.Parse(columna.Band.Layout.Rows.SummaryValues(columna.Key).Value.ToString()) = 0 Then
            columna.Hidden = True
         End If
      End If
   End Sub
   Private Sub MostrarFechas(columna As UltraGridColumn)
      If columna.Key.StartsWith("Fecha_") Then
         Dim fechaStr As String = columna.Key.Replace("Fecha_", "")
         Dim fecha = Date.ParseExact(fechaStr, "yyyyMMdd", Globalization.CultureInfo.InvariantCulture)
         MostrarFechas(columna, fecha)
      End If
   End Sub
   Private Sub MostrarFechas()
      If cmbTotalizarPorMes.ValorSeleccionado(Of Entidades.Publicos.PeriodosCalendarios) = Entidades.Publicos.PeriodosCalendarios.Dia Then
         ugDetalle.DisplayLayout.Bands(0).Columns.OfType(Of UltraGridColumn).Where(Function(x) x.Key.StartsWith("Fecha_")).ForEachSecure(Sub(columna) MostrarFechas(columna))
      Else
         ugDetalle.DisplayLayout.Bands(0).Columns.OfType(Of UltraGridColumn).Where(Function(x) x.Key.StartsWith("Mes_") Or x.Key.StartsWith("Anio_")).ForEachSecure(Sub(columna) MostrarFechas(columna, fecha:=Nothing))
      End If
   End Sub

   Private Sub VerActividades(celda As UltraGridCell)
      If celda.Column.Key.StartsWith("Fecha_") Or celda.Column.Key = "Total" Then
         Dim fechaDesde As Date?
         Dim fechaHasta As Date?
         If celda.Column.Key.StartsWith("Fecha_") Then
            Dim fechaStr As String = celda.Column.Key.Replace("Fecha_", "")
            Dim fecha = Date.ParseExact(fechaStr, "yyyyMMdd", Globalization.CultureInfo.InvariantCulture)
            fechaDesde = fecha
            fechaHasta = fecha.UltimoSegundoDelDia()
         Else
            For Each columna As UltraGridColumn In ugDetalle.DisplayLayout.Bands(0).Columns.Cast(Of UltraGridColumn).Where(Function(x) x.Key.StartsWith("Fecha_"))
               Dim fechaStr As String = columna.Key.Replace("Fecha_", "")
               Dim fecha = Date.ParseExact(fechaStr, "yyyyMMdd", Globalization.CultureInfo.InvariantCulture)

               If Not fechaDesde.HasValue Then
                  fechaDesde = fecha
               End If
               If Not fechaHasta.HasValue OrElse fechaHasta.Value < fecha Then
                  fechaHasta = fecha.UltimoSegundoDelDia()
               End If
            Next
         End If

         Dim frm = New CRMNovedadesABM()

         Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(celda.Row)
         frm.Parametros = New CRMNovedadesABM.ParametrosLlamador() With
                           {
                              .FechaDesde = fechaDesde,
                              .FechaHasta = fechaHasta,
                              .IdUsuario = If(dr.Table.Columns.Contains("IdUsuarioAsignado"), dr.Field(Of String)("IdUsuarioAsignado"), String.Empty),
                              .AbrirAutomaticamenteSiHaySoloUno = True,
                              .CodigoCliente = If(dr.Table.Columns.Contains("CodigoCliente"), dr.Field(Of Long)("CodigoCliente"), 0),
                              .IgnoraFiltrosPersonalizados = True,
                              .Finalizado = Entidades.Publicos.SiNoTodos.TODOS,
                              .IdCategoriaNovedad = If(dr.Table.Columns.Contains("IdCategoriaNovedad"), dr.Field(Of Integer)("IdCategoriaNovedad"), DirectCast(Nothing, Integer?))
                           }

         DirectCast(frm, IConParametros).SetParametros("TipoNovedad=ACTIVIDAD")

         frm.MdiParent = MdiParent
         frm.IdFuncion = "CRMNOVEDADESABMACTIVIDAD"

         frm.Show()

      End If
   End Sub
#End Region

End Class