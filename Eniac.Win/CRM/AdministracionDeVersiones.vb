#Region "Option/Imports"

Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section

#End Region

Public Class AdministracionDeVersiones

#Region "Campos"

   Private _publicos As Publicos
   Private _dtClientes As DataTable
   Private _estaCargando As Boolean = True
   Private _titDetalle As Dictionary(Of String, String)
   Private _ws As WSActualiza.WSActualizador
   Private _versionesClientes As List(Of Entidades.VersionCliente)

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         cmbCategoriasClientes.Inicializar(False)
         _publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnum))
         _publicos.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
         _publicos.CargaComboAplicaciones(cmbAplicacion)

         'Inicializo los _tit
         tbcEnvioMail.SelectedTab = tbpClientes
         _titDetalle = GetColumnasVisiblesGrilla(ugClientes)

         'Agrego filtros con comportamiento estandar
         ugClientes.AgregarFiltroEnLinea({"NombreCliente", "CorreoElectronico"})

         Me.LeerPreferencias()

         Me.ConfiguroWeb()

         Me._estaCargando = False

         Me.cmbAplicacion.SelectedValue = "SIGA"

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

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugClientes.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugClientes.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscNombreCliente.Selecciono Then
            ShowMessage("ATENCION: Activo el filtro de Cliente. Debe seleccionar uno.")
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If
         If Me.cmbCategoriasClientes.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar una Categoría de Cliente.")
            Me.cmbCategoriasClientes.Focus()
            Exit Sub
         End If
         If Me.chbCobrador.Checked And Me.cmbCobrador.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Activo el filtro de Cobrador. Debe seleccionar uno.")
            Me.cmbCobrador.Focus()
            Exit Sub
         End If
         If Me.chbZonaGeografica.Checked And Me.cmbZonaGeografica.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Activo el filtro de Zona Geográfica. Debe seleccionar una.")
            Me.cmbZonaGeografica.Focus()
            Exit Sub
         End If

         If Me.cmbVersionDesde.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar una Versión desde.")
            Me.cmbVersionDesde.Focus()
            Exit Sub
         End If
         If Me.cmbVersionHasta.SelectedIndex = -1 Then
            ShowMessage("ATENCION: Debe seleccionar una Versión hasta.")
            Me.cmbVersionHasta.Focus()
            Exit Sub
         End If

         Me.tsbActualizarVersion.Enabled = True

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

      Catch ex As Exception
         Me.tssInfo.Text = String.Empty
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub


#Region "Toolbar"
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.RefrescarDatosGrilla()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.tssInfo.Text = String.Empty
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbActualizarVersion_Click(sender As Object, e As EventArgs) Handles tsbActualizarVersion.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.ugClientes.UpdateData()

         Me.tsbActualizarVersion.Enabled = False
         Dim cantidad As Integer = _dtClientes.Rows.Count

         If _dtClientes.Select("Envio").Length > 0 Then
            Dim av As ActualizarAVersion = New ActualizarAVersion(_dtClientes.Select("Envio").CopyToDataTable(),
                                                                  Me.cmbAplicacion.Text,
                                                                  Me._ws,
                                                                  Me.cmbAplicacion.Text)
            av.ShowDialog()
         End If

      Catch ex As Exception
         ShowError(ex, True)
      Finally
         Me.Cursor = Cursors.Default
         tsbActualizarVersion.Enabled = True
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Select Case True
            Case tbcEnvioMail.SelectedTab Is tbpClientes
               Dim pre As Preferencias = New Preferencias(Me.ugClientes, True)
               pre.ShowDialog()
            Case Else

         End Select
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "ProcessTabKey"

   Private Sub controles_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComenzarPorNombreCliente.KeyUp, cmbZonaGeografica.KeyUp, bscNombreCliente.KeyUp, bscCodigoCliente.KeyUp
      PresionarTab(e)
   End Sub

#End Region

#Region "Cliente"
   Private Sub chbCliente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscNombreCliente.Enabled = Me.chbCliente.Checked

      If Me.chbCliente.Checked Then
         Me.bscCodigoCliente.Focus()
      Else
         Me.bscCodigoCliente.Text = String.Empty
         Me.bscCodigoCliente.Tag = Nothing
         Me.bscNombreCliente.Text = String.Empty
      End If

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Dim entidad As Reglas.Clientes = New Reglas.Clientes()
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim codigoCliente As Long = If(IsNumeric(bscCodigoCliente.Text.Trim()), Long.Parse(bscCodigoCliente.Text.Trim()), -1)
         Me.bscCodigoCliente.Datos = entidad.GetFiltradoPorCodigo(codigoCliente, True, True)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
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
         Dim entidad As Reglas.Clientes = New Reglas.Clientes()
         Me._publicos.PreparaGrillaClientes(Me.bscNombreCliente)
         Me.bscNombreCliente.Datos = entidad.GetFiltradoPorNombre(Me.bscNombreCliente.Text, True)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscNombreCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreCliente.BuscadorSeleccion
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

#Region "Eventos Filtros"
   Private Sub chbZonaGeografica_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbZonaGeografica.CheckedChanged
      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Me.chbZonaGeografica.Checked Then
         Me.cmbZonaGeografica.Focus()
      Else
         Me.cmbZonaGeografica.SelectedIndex = -1
      End If
   End Sub

   Private Sub chbCobrador_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCobrador.CheckedChanged
      Me.cmbCobrador.Enabled = Me.chbCobrador.Checked
      If Not Me.chbCobrador.Checked Then
         Me.cmbCobrador.SelectedIndex = -1
      Else
         If Me.cmbCobrador.Items.Count > 0 Then
            Me.cmbCobrador.SelectedIndex = 0
         End If
         Me.cmbCobrador.Focus()
      End If
   End Sub

   Private Sub cmbAplicacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAplicacion.SelectedIndexChanged
      Try
         If Not _estaCargando Then
            Me._publicos.CargaComboVersiones(Me.cmbVersionDesde, Me.cmbAplicacion.Text)
            Me._publicos.CargaComboVersiones(Me.cmbVersionHasta, Me.cmbAplicacion.Text)
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnum Then

            Me.Cursor = Cursors.WaitCursor

            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnum)
               Case Reglas.Publicos.TodosEnum.MararTodos
                  MarcarDesmarcar(True, ugClientes.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarTodos

               Case Reglas.Publicos.TodosEnum.DesmarcarTodos
                  MarcarDesmarcar(False, ugClientes.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos

               Case Reglas.Publicos.TodosEnum.MarcarFiltrados
                  MarcarDesmarcar(True, ugClientes.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarFiltrados

               Case Reglas.Publicos.TodosEnum.DesmarcarFiltrados
                  MarcarDesmarcar(False, ugClientes.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MarcarFiltrados

               Case Reglas.Publicos.TodosEnum.InvertirMarcasTodos
                  MarcarDesmarcar(Nothing, ugClientes.Rows.ToArray())

               Case Reglas.Publicos.TodosEnum.InvertirMarcasFiltrados
                  MarcarDesmarcar(Nothing, ugClientes.Rows.GetFilteredInNonGroupByRows())

               Case Else

            End Select
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         ugClientes.UpdateData()
      End Try
   End Sub
   Private Sub MarcarDesmarcar(marcar As Boolean?, rows As UltraGridRow())
      For Each dr As UltraGridRow In rows
         If dr.Cells("CorreoElectronico").Text <> "" Then
            If marcar.HasValue Then
               dr.Cells("Envio").Value = marcar.Value
            Else
               dr.Cells("Envio").Value = Not CBool(dr.Cells("Envio").Value)
            End If
         End If
      Next
   End Sub
#End Region

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         Select Case True
            Case tbcEnvioMail.SelectedTab Is tbpClientes
               If Me.ugClientes.Rows.Count = 0 Then Exit Sub

               Dim myWorkbook As New Workbook
               Dim myWorksheet As Worksheet
               myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
               myWorksheet.Rows(0).Cells(0).Value = Publicos.NombreEmpresaImpresion
               myWorksheet.Rows(1).Cells(0).Value = Me.Text & " - Clientes"
               myWorksheet.Rows(2).Cells(0).Value = Me.CargarFiltrosImpresion()

               Me.sfdExportar.FileName = Me.Name & "_Clientes.xls"
               Me.sfdExportar.Filter = "Archivos excel|*.xls"
               If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
                     Me.UltraGridExcelExporter1.Export(ugClientes, myWorksheet, 4, 0)
                     myWorkbook.Save(Me.sfdExportar.FileName)
                  End If
               End If


         End Select



      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         Select Case True
            Case tbcEnvioMail.SelectedTab Is tbpClientes
               If Me.ugClientes.Rows.Count = 0 Then Exit Sub

               Me.sfdExportar.FileName = Me.Name & "_Clientes.pdf"
               Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
               If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
                     Dim r As New Report()
                     Dim sec As ISection = r.AddSection()
                     sec.AddText.AddContent(Publicos.NombreEmpresaImpresion + System.Environment.NewLine)
                     sec.AddText.AddContent(Me.Text & " - Clientes" + System.Environment.NewLine)
                     sec.AddText.AddContent(Me.CargarFiltrosImpresion() + System.Environment.NewLine + System.Environment.NewLine)
                     Me.UltraGridDocumentExporter1.Export(Me.ugClientes, sec)
                     r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
                  End If
               End If


         End Select

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos Privados"

   Private Function GetVersionesClientes(listado As WSActualiza.VersionCliente()) As List(Of Entidades.VersionCliente)
      Dim versiones As List(Of Entidades.VersionCliente)
      versiones = New List(Of Entidades.VersionCliente)()
      If listado Is Nothing Then
         Return versiones
      End If
      Dim vcN As Entidades.VersionCliente

      For Each vc As WSActualiza.VersionCliente In listado
         vcN = New Entidades.VersionCliente()

         vcN.CodigoCliente = vc.Cliente.CodigoCliente
         vcN.NroVersion = vc.NroVersionHabilitada
         vcN.NombreCliente = vc.Cliente.NombreCliente

         versiones.Add(vcN)
      Next
      Return versiones
   End Function

   Private Sub ConfiguroWeb()
      Me._ws = New WSActualiza.WSActualizador()
      Me._ws.Url = Reglas.Publicos.URLActualizacion

   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Enabled = False
      Me.bscNombreCliente.Enabled = False
   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.txtComenzarPorNombreCliente.Text = String.Empty
      Me.chbCliente.Checked = False
      Me.cmbCategoriasClientes.Refrescar()
      Me.chbZonaGeografica.Checked = False
      Me.chbCobrador.Checked = False

      If TypeOf (Me.ugClientes.DataSource) Is DataTable Then DirectCast(Me.ugClientes.DataSource, DataTable).Rows.Clear()

      Me.cmbTodos.SelectedIndex = 0

      Me.tsbActualizarVersion.Enabled = False

      Me.tssInfo.Text = ""
      Me.tssRegistros.Text = "0 registros"
   End Sub

   Private Sub CargaGrillaDetalle()
      Try
         Dim idCliente As Long = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0)
         Dim idZonaGeografica As String = If(chbZonaGeografica.Checked, cmbZonaGeografica.SelectedValue.ToString(), String.Empty)

         Dim idCobrador As Integer = If(chbCobrador.Checked, DirectCast(cmbCobrador.SelectedItem, Entidades.Empleado).IdEmpleado, 0)

         Dim envioMasivo As CRMEnvioMasivoNovedadesMails = New CRMEnvioMasivoNovedadesMails()

         _dtClientes = envioMasivo.GetEnvioMasivoNovedadesMail(cmbAplicacion.SelectedValue.ToString(),
                                                                cmbCategoriasClientes.GetCategorias(True),
                                                                idZonaGeografica,
                                                                idCliente,
                                                                txtComenzarPorNombreCliente.Text,
                                                                Reglas.Publicos.ConfiguraciónMailCRM,
                                                                idCobrador)
         'agrego la columna con la versión Web
         Me._dtClientes.Columns.Add("VersionWeb", System.Type.GetType("System.String"))
         Me.CargarVersionesWeb()

         Me.ugClientes.DataSource = _dtClientes

         Me.ConfigurarGrilla()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.tssRegistros.Text = String.Format("{0} Registros", _dtClientes.Rows.Count)
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarVersionesWeb()
      Dim lis As WSActualiza.VersionCliente() = Me._ws.GetVersionesClientes(Me.cmbAplicacion.Text, False, True)
      Me._versionesClientes = Me.GetVersionesClientes(lis)
      For Each dr As DataRow In Me._dtClientes.Rows
         For Each vc As Eniac.Entidades.VersionCliente In Me._versionesClientes
            If Long.Parse(dr("CodigoCliente").ToString()) = vc.CodigoCliente Then
               dr("VersionWeb") = vc.NroVersion
               Exit For
            End If
         Next
      Next

   End Sub

   Private Sub ConfigurarGrilla()
      With Me.ugClientes.DisplayLayout.Bands(0)
         For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In .Columns
            col.Hidden = True
            col.CellActivation = Activation.NoEdit
         Next
         Dim pos As Integer = 0
         Grilla.FormatearColumna(.Columns("Envio"), "Actualiza", pos, 80, HAlign.Center, False, "", "", Activation.AllowEdit)
         Grilla.FormatearColumna(.Columns("CodigoCliente"), "Código", pos, 80, HAlign.Right, False)
         Grilla.FormatearColumna(.Columns("NombreCliente"), "Cliente", pos, 250, HAlign.Left, False)
         Grilla.FormatearColumna(.Columns("Edicion"), "Edición", pos, 80, HAlign.Left, False)
         Grilla.FormatearColumna(.Columns("NroVersion"), "Versión", pos, 80, HAlign.Left, False)
         Grilla.FormatearColumna(.Columns("VersionWeb"), "Versión Web", pos, 80, HAlign.Left, False)
         Grilla.FormatearColumna(.Columns("FechaActualizacionVersion"), "Fecha Act.", pos, 90, HAlign.Center, False)
      End With
   End Sub

   Private Sub ExaminarArchivo(ByVal txtArchivo As TextBox)

      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      Dim result As DialogResult = DialogoAbrirArchivo.ShowDialog()
      If result = System.Windows.Forms.DialogResult.OK Then
         Try
            Using DialogoAbrirArchivo.OpenFile()
               'Si bien aca lo pude abrir, solo es para obtener el path.
               txtArchivo.Text = DialogoAbrirArchivo.FileName
               txtArchivo.Focus()
            End Using
         Catch ex As Exception
            ShowMessage(String.Format("ATENCION: No se puede leer el Archivo {0}. Error: {1}", DialogoAbrirArchivo.FileName, ex.Message))
         End Try
      End If

   End Sub


   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         'cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)

         '.AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         'cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)

         'If Me.cboLetra.SelectedIndex >= 0 Then
         '   .AppendFormat(" Letra: {0} - ", Me.cboLetra.SelectedText)
         'End If

         'If Me.cmbEmisor.SelectedIndex >= 0 Then
         '   .AppendFormat(" Emisor: {0} -", Me.cmbEmisor.SelectedText)
         'End If

         'If Me.chbNumero.Checked Then
         '   .AppendFormat(" Número: {0} -", Me.txtNumero.Text)
         'End If

         'If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
         '   .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         'End If

         'If Me.cmbVendedor.SelectedIndex >= 0 Then
         '   .AppendFormat(" Vendedor: {0} - ", Me.cmbVendedor.SelectedText)
         'End If

         'If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
         '   .AppendFormat(" Zona G.: {0} - ", Me.cmbZonaGeografica.SelectedText)
         'End If

         'If Me.cmbUsuario.SelectedIndex >= 0 Then
         '   .AppendFormat(" Usuario: {0}", Me.cmbUsuario.SelectedText)
         'End If

         'If Me.cmbFormaPago.SelectedIndex >= 0 Then
         '   .AppendFormat(" Forma de Pago: {0} -", Me.cmbFormaPago.SelectedText)
         'End If

         'If Me.cmbGrabanLibro.SelectedIndex >= 0 Then     '0 Es TODOS
         '   .AppendFormat(" Graban Libro: {0} - ", Me.cmbGrabanLibro.Text)
         'End If

         'If Me.cmbEsComercial.SelectedIndex >= 0 Then
         '   .AppendFormat(" Es Comercial: {0} - ", Me.cmbEsComercial.Text)
         'End If

         'If Me.cmbAfectaCaja.SelectedIndex >= 0 Then
         '   .AppendFormat(" Afecta Caja: {0} -", Me.cmbAfectaCaja.Text)
         'End If

         'If Me.cmbMercDespachada.SelectedIndex >= 0 Then
         '   .AppendFormat(" Mercaderia Despachada: {0} -", cmbMercDespachada.Text)
         'End If

         'If Me.chbCategoria.Checked Then
         '   .AppendFormat(" Categoría {0} - ", Me.cmbCategoria.SelectedText)
         'End If

         'If Me.bscCodigoLocalidad.Text.Length > 0 And Me.bscNombreLocalidad.Text.Length > 0 Then
         '   .AppendFormat(" Localidad: {0} - {1} - ", Me.bscCodigoLocalidad.Text, Me.bscNombreLocalidad.Text)
         'End If

         'If Me.chbProvincia.Checked Then
         '   .AppendFormat(" Provincia {0} - ", Me.cmbProvincia.SelectedText)
         'End If

         'If Me.chbNroReparto.Checked Then
         '   .AppendFormat(" Numero de Reparto de {0} a {1} -", txtNroRepartoDesde, txtNroRepartoHasta)
         'End If


      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function

#End Region

End Class