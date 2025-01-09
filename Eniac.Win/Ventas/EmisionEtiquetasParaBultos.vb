Imports Microsoft.Reporting.WinForms
Public Class EmisionEtiquetasParaBultos

#Region "Campos"
   Private _publicos As Publicos
   Private _numeroComprobanteDesdeAnterior As Long
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         '# Sucursales
         cmbSucursal.Initializar(False, IdFuncion, Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
         cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         cmbTiposComprobantes.Initializar(False, "VENTAS")

         _publicos.CargaComboLetraComprobanteVenta(Me.cmbLetra)
         _publicos.CargaComboEmisor(Me.cmbEmisor)

         _publicos.CargaComboCategorias(Me.cmbCategoriasClientes)
         _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         _publicos.CargaComboTransportistas(Me.cmbTransportista)
         _publicos.CargaComboTiposDirecciones(Me.cmbTipoDireccion)
         _publicos.CargaComboDesdeEnum(Me.cmbOrigenCategoria, GetType(Entidades.OrigenFK))
         _publicos.CargaComboDesdeEnum(Me.cmbOrigenVendedor, GetType(Entidades.OrigenFK))
         _publicos.CargaComboDesdeEnum(Me.cmbOrigenTransportista, GetType(Entidades.OrigenFK))
         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnum))

         _publicos.CargaComboFormatosEtiquetas(cmbFormatos, Entidades.FormatoEtiqueta.Tipos.BULTOS, True)
         If cmbFormatos.Items.Count > 0 Then
            cmbFormatos.SelectedIndex = 0
         End If

         PreferenciasLeer(ugDetalle, tsbPreferencias)

         RefrescarDatosGrilla()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.F5 Then
            Me.tsbRefrescar.PerformClick()
            Return True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
#End Region

#Region "Eventos"

#Region "Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As System.EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub()
                    Me.RefrescarDatosGrilla()
                    Me.tslTexto.Text = String.Empty
                    MostrarRegistros(0)
                 End Sub)
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As System.EventArgs) Handles tsbImprimir.Click
      TryCatched({tsbImprimir},
                 Sub()
                    Imprimir()
                 End Sub)
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

#End Region

#Region "Eventos Filtros"
   Private Sub chbClientesConVenta_CheckedChanged(sender As Object, e As EventArgs) Handles chbClientesConVenta.CheckedChanged
      TryCatched(Sub()
                    chbMesCompleto.Enabled = chbClientesConVenta.Checked
                    dtpDesde.Enabled = chbClientesConVenta.Checked And Not chbMesCompleto.Checked
                    dtpHasta.Enabled = chbClientesConVenta.Checked And Not chbMesCompleto.Checked
                    cmbSucursal.Enabled = chbClientesConVenta.Checked
                    cmbTiposComprobantes.Enabled = chbClientesConVenta.Checked
                    chbLetra.Enabled = chbClientesConVenta.Checked
                    cmbLetra.Enabled = chbClientesConVenta.Checked And chbLetra.Checked
                    chbEmisor.Enabled = chbClientesConVenta.Checked
                    cmbEmisor.Enabled = chbClientesConVenta.Checked And chbEmisor.Checked
                    chbNumero.Enabled = chbClientesConVenta.Checked
                    txtNumeroCompDesde.Enabled = chbClientesConVenta.Checked And chbNumero.Checked
                    txtNumeroCompHasta.Enabled = chbClientesConVenta.Checked And chbNumero.Checked

                    cmbOrigenCategoria.Enabled = chbClientesConVenta.Checked
                    cmbOrigenTransportista.Enabled = chbClientesConVenta.Checked
                    cmbOrigenVendedor.Enabled = chbClientesConVenta.Checked

                    cmbOrigenCategoria.SelectedValue = If(chbClientesConVenta.Checked, Entidades.OrigenFK.Movimiento, Entidades.OrigenFK.Actual)
                    cmbOrigenTransportista.SelectedValue = If(chbClientesConVenta.Checked, Entidades.OrigenFK.Movimiento, Entidades.OrigenFK.Actual)
                    cmbOrigenVendedor.SelectedValue = If(chbClientesConVenta.Checked, Entidades.OrigenFK.Movimiento, Entidades.OrigenFK.Actual)

                 End Sub)
   End Sub

   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      TryCatched(Sub() chbMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta, ultimoSegundo:=True))
   End Sub
   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      TryCatched(Sub() chbLetra.FiltroCheckedChanged(cmbLetra))
   End Sub
   Private Sub chbEmisor_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmisor.CheckedChanged
      chbEmisor.FiltroCheckedChanged(cmbEmisor)
   End Sub
   Private Sub chbNumero_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbNumero.CheckedChanged
      Me.txtNumeroCompDesde.Enabled = Me.chbNumero.Checked
      Me.txtNumeroCompHasta.Enabled = Me.txtNumeroCompDesde.Enabled
      If Not Me.chbNumero.Checked Then
         Me.txtNumeroCompDesde.Text = "0"
         Me.txtNumeroCompHasta.Text = "0"
      Else
         Me.txtNumeroCompDesde.Focus()
      End If
   End Sub
   Private Sub txtNumeroCompDesde_Enter(sender As Object, e As EventArgs) Handles txtNumeroCompDesde.Enter
      _numeroComprobanteDesdeAnterior = txtNumeroCompDesde.ValorNumericoPorDefecto(0L)
   End Sub
   Private Sub txtNumeroCompDesde_Leave(sender As Object, e As EventArgs) Handles txtNumeroCompDesde.Leave
      Try
         Dim desde = txtNumeroCompDesde.ValorNumericoPorDefecto(0L)
         Dim hasta = txtNumeroCompHasta.ValorNumericoPorDefecto(0L)
         Dim delta = desde - _numeroComprobanteDesdeAnterior
         txtNumeroCompHasta.Text = (hasta + delta).ToString()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbCliente_CheckedChanged(sender As Object, e As System.EventArgs) Handles chbCliente.CheckedChanged
      chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscNombreCliente)
   End Sub

#Region "Busqueda de Cliente"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         Me.bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, busquedaParcial:=True, soloActivos:=True)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscNombreCliente)
         Me.bscNombreCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(Me.bscNombreCliente.Text, soloActivos:=True)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
   Private Sub bscNombreCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

   Private Sub chbCategoriaCliente_CheckedChanged(sender As Object, e As System.EventArgs) Handles chbCategoriaCliente.CheckedChanged
      TryCatched(Sub() chbCategoriaCliente.FiltroCheckedChanged(cmbCategoriasClientes))
   End Sub
   Private Sub chbTransportista_CheckedChanged(sender As Object, e As System.EventArgs) Handles chbTransportista.CheckedChanged
      TryCatched(Sub() chbTransportista.FiltroCheckedChanged(cmbTransportista))
   End Sub
   Private Sub chbVendedor_CheckedChanged(sender As Object, e As System.EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub
   Private Sub chbTipoDireccion_CheckedChanged(sender As Object, e As System.EventArgs) Handles chbTipoDireccion.CheckedChanged
      TryCatched(Sub() chbTipoDireccion.FiltroCheckedChanged(cmbTipoDireccion))
   End Sub
#End Region

   Private Sub chbReimpresion_CheckedChanged(sender As Object, e As System.EventArgs) Handles chbReimpresion.CheckedChanged
      TryCatched(Sub()
                    ugDetalle.DisplayLayout.Bands(0).Columns("CantidadBultosDesde").Hidden = Not chbReimpresion.Checked
                    ugDetalle.DisplayLayout.Bands(0).Columns("CantidadBultosHasta").Hidden = Not chbReimpresion.Checked
                    If Not chbReimpresion.Checked AndAlso TypeOf (ugDetalle.DataSource) Is DataTable Then
                       DirectCast(ugDetalle.DataSource, DataTable).Select().
                              ToList().ForEach(Sub(dr)
                                                  Dim cantidadBultos = dr.Field(Of Integer)("CantidadBultos")
                                                  dr("CantidadBultosDesde") = If(cantidadBultos = 0, 0, 1)
                                                  dr("CantidadBultosHasta") = cantidadBultos
                                               End Sub)
                    End If
                 End Sub)
   End Sub

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnum Then

            Me.Cursor = Cursors.WaitCursor

            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnum)
               Case Reglas.Publicos.TodosEnum.MararTodos
                  MarcarDesmarcar(txtCantidadBultos.ValorNumericoPorDefecto(0I), ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarTodos

               Case Reglas.Publicos.TodosEnum.DesmarcarTodos
                  MarcarDesmarcar(0, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos

               Case Reglas.Publicos.TodosEnum.MarcarFiltrados
                  MarcarDesmarcar(txtCantidadBultos.ValorNumericoPorDefecto(0I), ugDetalle.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarFiltrados

               Case Reglas.Publicos.TodosEnum.DesmarcarFiltrados
                  MarcarDesmarcar(0, ugDetalle.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MarcarFiltrados

               Case Reglas.Publicos.TodosEnum.InvertirMarcasTodos
                  MarcarDesmarcar(Nothing, ugDetalle.Rows.ToArray())

               Case Reglas.Publicos.TodosEnum.InvertirMarcasFiltrados
                  MarcarDesmarcar(Nothing, ugDetalle.Rows.GetFilteredInNonGroupByRows())

               Case Else

            End Select
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         ugDetalle.UpdateData()
      End Try
   End Sub
   Private Sub MarcarDesmarcar(marcar As Integer?, rows As UltraGridRow())
      For Each dr As UltraGridRow In rows
         Dim direccion = dr.Cells("Direccion").Value.ToString()
         If Not String.IsNullOrWhiteSpace(direccion) Then
            If marcar.HasValue Then
               dr.Cells("CantidadBultos").Value = marcar.Value
            Else
               Dim cantidadActual = Integer.Parse(dr.Cells("CantidadBultos").Value.ToString())
               dr.Cells("CantidadBultos").Value = If(cantidadActual = 0, txtCantidadBultos.ValorNumericoPorDefecto(0I), 0)
            End If
         End If
      Next
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscNombreCliente.Selecciono Then
            ShowMessage("ATENCION: Activo el filtro de Cliente, Debe seleccionar uno.")
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         Me.tsbImprimir.Enabled = True

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
            Exit Sub
         End If
      Catch ex As Exception
         Me.tslTexto.Text = String.Empty
         MostrarRegistros(0)
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#Region "Grilla"
   Private Sub ugDetalle_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugDetalle.AfterCellUpdate
      TryCatched(Sub()
                    If e.Cell.Column.Key = "CantidadBultos" Then
                       Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
                       If dr IsNot Nothing Then
                          Dim cantidadBultos = e.Cell.ValorAs(Of Integer) ' dr.Field(Of Integer)("CantidadBultos")
                          dr("CantidadBultosDesde") = If(cantidadBultos = 0, 0, 1)
                          dr("CantidadBultosHasta") = cantidadBultos
                       End If
                    End If
                 End Sub)

   End Sub
   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(Sub()
                    Dim dr = ugDetalle.FilaSeleccionada(Of DataRow)(e.Row)
                    If dr IsNot Nothing Then
                       Dim direccion = dr.Field(Of String)("Direccion")
                       e.Row.Cells("CantidadBultos").Activation = If(String.IsNullOrWhiteSpace(direccion), Activation.Disabled, Activation.AllowEdit)
                       e.Row.Cells("CantidadBultosDesde").Activation = If(String.IsNullOrWhiteSpace(direccion), Activation.Disabled, Activation.AllowEdit)
                       e.Row.Cells("CantidadBultosHasta").Activation = If(String.IsNullOrWhiteSpace(direccion), Activation.Disabled, Activation.AllowEdit)

                       Dim cantidadBultos = dr.Field(Of Integer)("CantidadBultos")
                       Dim cantidadBultosDesde = dr.Field(Of Integer)("CantidadBultosDesde")
                       Dim cantidadBultosHasta = dr.Field(Of Integer)("CantidadBultosHasta")

                       If cantidadBultos > 0 Then
                          e.Row.Cells("CantidadBultos").Color(Color.Black, Color.Aqua)
                       Else
                          e.Row.Cells("CantidadBultos").Color(Nothing, Nothing)
                       End If

                       If cantidadBultos > 0 AndAlso cantidadBultosDesde <> 1 Then
                          e.Row.Cells("CantidadBultosDesde").Color(Color.Black, Color.Aqua)
                       Else
                          e.Row.Cells("CantidadBultosDesde").Color(Nothing, Nothing)
                       End If

                       If cantidadBultosHasta <> cantidadBultos Then
                          e.Row.Cells("CantidadBultosHasta").Color(Color.Black, Color.Aqua)
                       Else
                          e.Row.Cells("CantidadBultosHasta").Color(Nothing, Nothing)
                       End If
                    End If
                 End Sub)

   End Sub
#End Region

#End Region

#Region "Metodos Privados"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Permitido = False
      Me.bscNombreCliente.Permitido = False
      Me.bscCodigoCliente.Selecciono = True
      Me.bscNombreCliente.Selecciono = True
   End Sub

   Private Sub RefrescarDatosGrilla()

      dtpDesde.Value = Today
      dtpHasta.Value = Today.UltimoSegundoDelDia()

      cmbSucursal.Refrescar()
      cmbTiposComprobantes.Refrescar()

      cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

      chbLetra.Checked = False
      chbEmisor.Checked = False
      chbNumero.Checked = False
      chbCliente.Checked = False
      txtComenzarPorNombreCliente.Clear()
      chbCategoriaCliente.Checked = False
      chbTransportista.Checked = False
      chbVendedor.Checked = False
      chbTipoDireccion.Checked = False
      chbMesCompleto.Checked = False

      chbClientesConVenta.Checked = False
      chbReimpresion.Checked = False


      txtCantidadBultos.Text = "1"

      ugDetalle.ClearFilas()

      Me.tsbImprimir.Enabled = False

      Me.tslTexto.Text = String.Empty
      MostrarRegistros(0)

      Me.chbClientesConVenta.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()
      Dim rClientes = New Reglas.Clientes()
      Dim dt = rClientes.GetEmisionEtiquetasParaBultos(dtpDesde.Valor(chbClientesConVenta), dtpHasta.Valor(chbClientesConVenta),
                                                       If(chbClientesConVenta.Checked, cmbSucursal.GetSucursales(), {}),
                                                       If(chbClientesConVenta.Checked, cmbTiposComprobantes.GetTiposComprobantes(), {}),
                                                       If(chbClientesConVenta.Checked And chbLetra.Checked, cmbLetra.ValorSeleccionado(Of String), String.Empty),
                                                       If(chbClientesConVenta.Checked And chbEmisor.Checked, cmbEmisor.ValorSeleccionado(Of Short), 0S),
                                                       If(chbClientesConVenta.Checked And chbNumero.Checked, txtNumeroCompDesde.ValorNumericoPorDefecto(0L), 0L),
                                                       If(chbClientesConVenta.Checked And chbNumero.Checked, txtNumeroCompHasta.ValorNumericoPorDefecto(0L), 0L),
                                                       If(chbCliente.Checked, ObjectExtensions.ValorNumericoPorDefecto(bscCodigoCliente.Tag, 0L), 0L),
                                                       If(chbTipoDireccion.Checked, cmbTipoDireccion.ValorSeleccionado(Of Integer), 0I),
                                                       txtComenzarPorNombreCliente.Text,
                                                       If(chbCategoriaCliente.Checked, cmbCategoriasClientes.ValorSeleccionado(Of Integer), 0I), cmbOrigenCategoria.ValorSeleccionado(Of Entidades.OrigenFK),
                                                       If(chbTransportista.Checked, cmbTransportista.ValorSeleccionado(Of Integer), 0I), cmbOrigenTransportista.ValorSeleccionado(Of Entidades.OrigenFK),
                                                       If(chbVendedor.Checked, cmbVendedor.ValorSeleccionado(Of Integer), 0I), cmbOrigenVendedor.ValorSeleccionado(Of Entidades.OrigenFK))

      Me.ugDetalle.DataSource = dt
      MostrarRegistros(ugDetalle.Count)

   End Sub

   Private Sub Imprimir()

      If cmbFormatos.SelectedIndex < 0 Then
         ShowMessage("ATENCION: Debe seleecionar un formato de Etiqueta.")
         cmbFormatos.Focus()
         Exit Sub
      End If

      ugDetalle.UpdateData()

      If TypeOf (ugDetalle.DataSource) Is DataTable Then
         Dim drCols = DirectCast(ugDetalle.DataSource, DataTable).Select("CantidadBultos <> 0")
         If drCols.Length = 0 Then
            Throw New Exception("No ingresó bultos a imprimir.")
         End If
         If ShowPregunta(String.Format("¿Desea imprimir {0} etiquetas para los {1} clientes seleccionados?",
                                       drCols.Sum(Function(dr) dr.Field(Of Integer)("CantidadBultosHasta") - dr.Field(Of Integer)("CantidadBultosDesde") + 1),
                                       drCols.Count())) = DialogResult.Yes Then

            Me.Cursor = Cursors.WaitCursor

            Using dtImprimir = DirectCast(ugDetalle.DataSource, DataTable).Clone()
               dtImprimir.Columns.Add("BultoActual", GetType(Integer)).DefaultValue = 1
               For Each drOrigen In drCols
                  Dim cantidadBultos = drOrigen.Field(Of Integer)("CantidadBultos")
                  Dim cantidadBultosDesde = drOrigen.Field(Of Integer)("CantidadBultosDesde")
                  Dim cantidadBultosHasta = drOrigen.Field(Of Integer)("CantidadBultosHasta")

                  For i = cantidadBultosDesde To cantidadBultosHasta
                     Dim drDestino = dtImprimir.NewRow()
                     drDestino.ItemArray = DirectCast(drOrigen.ItemArray.Clone(), Object())
                     drDestino("BultoActual") = i
                     dtImprimir.Rows.Add(drDestino)
                  Next
               Next

               Dim parms = New List(Of ReportParameter)

               parms.Add(New ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
               parms.Add(New ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
               '-.PE-32361.- Se agregan los sig. parametros para la etiqueta de la Perfumeria Beauty World
               parms.Add(New ReportParameter("eMail", actual.Sucursal.Correo.ToString()))
               parms.Add(New ReportParameter("web", Reglas.Publicos.DireccionWebEmpresa))

               Dim eSucursal As Entidades.Sucursal = New Reglas.Sucursales().GetUna(actual.Sucursal.IdSucursal, False)


               parms.Add(New ReportParameter("TelefonoEmpresa", eSucursal.Telefono))
               parms.Add(New ReportParameter("DireccionEmpresa", eSucursal.DireccionComercial))
               parms.Add(New ReportParameter("Fecha", Date.Today.ToString()))

               '# Logo
               Dim LogoImagen As System.Drawing.Image = Eniac.Entidades.Usuario.Actual.Logo

               parms.Add(New ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
               parms.Add(New ReportParameter("LogoMime", LogoImagen.MimeType))

               '-.PE-32053.-
               Dim reporte As Entidades.InformePersonalizadoResuelto

               reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.EmisionEtiquetasParaBultos, GetFormatoEtiqueta().ArchivoAImprimir)

               Using frmImprime = New VisorReportes(reporte.NombreArchivo,
                                                    "dtEtiquetasParaBultos", dtImprimir,
                                                    parms, reporte.ReporteEmbebido, 1)
                  frmImprime.Text = Me.Text
                  frmImprime.WindowState = FormWindowState.Normal
                  frmImprime.StartPosition = FormStartPosition.CenterScreen
                  frmImprime.Width = 900
                  frmImprime.ShowDialog(Me)
               End Using

            End Using
         End If
      End If
   End Sub

   Private Sub MostrarRegistros(cantidadRegistros As Integer)
      tssRegistros.Text = String.Format("{0} Registro{1}", cantidadRegistros, If(cantidadRegistros <> 1, "s", ""))
   End Sub

   Private Function GetFormatoEtiqueta() As Entidades.FormatoEtiqueta
      If cmbFormatos.SelectedIndex < 0 Then
         Return New Entidades.FormatoEtiqueta()
      End If
      Return DirectCast(cmbFormatos.SelectedItem, Entidades.FormatoEtiqueta)
   End Function

   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      Try
         If e.Cell.Row.Index <> -1 AndAlso e.Cell.Column.Key.Equals("CantidadBultos") AndAlso e.Cell.Text <> "" AndAlso CInt(e.Cell.Text) > 0 AndAlso CInt(e.Cell.Row.Cells("CantidadBultosNuevo").Text) = 0 Then
            e.Cell.Row.Cells("CantidadBultosNuevo").Value = 1
         End If
         If e.Cell.Row.Index <> -1 AndAlso e.Cell.Column.Key.Equals("CantidadBultosNuevo") AndAlso e.Cell.Text <> "" AndAlso CInt(e.Cell.Text) > 0 AndAlso CInt(e.Cell.Row.Cells("CantidadBultos").Value) = 0 Then
            e.Cell.Row.Cells("CantidadBultos").Value = 1
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

End Class