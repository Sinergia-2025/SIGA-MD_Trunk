#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Documents.Excel
Imports Infragistics.Documents.Reports.Report
Imports Infragistics.Documents.Reports.Report.Section
Imports System.Text.RegularExpressions

#End Region
Public Class EnvioNovedadesDeVersiones

#Region "Campos"
   Private _publicos As Publicos
   Private _dtEnvioMail As DataTable
   Private _dtNovedades As DataTable
   Private _estaCargando As Boolean = True
   Private _titDetalle As Dictionary(Of String, String)
   Private _titNovedades As Dictionary(Of String, String)
   Private _titClientesNovedades As Dictionary(Of String, String)
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         If (Not Me.ValidarCorreo()) Then
            ShowMessage(String.Format("No se podrán enviar correos electrónicos hasta que se complete la Configuración{0}(Configuraciones -> Parametros del Sistema)",
                                      Environment.NewLine))
         End If

         Me._publicos = New Publicos()

         cmbCategoriasClientes.Inicializar(False)
         _publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnum))
         _publicos.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)
         _publicos.CargaComboAplicaciones(cmbAplicacion)

         txtCopiaOculta.Text = Reglas.Publicos.CRMEnvioMailCopiaOculta

         chbCopiaOculta.Checked = Not String.IsNullOrWhiteSpace(txtCopiaOculta.Text)

         'Inicializo los _tit
         tbcEnvioMail.SelectedTab = tbpNovedades
         _titNovedades = GetColumnasVisiblesGrilla(ugNovedades)
         tbcEnvioMail.SelectedTab = tbpNovedadesDelCliente
         _titClientesNovedades = GetColumnasVisiblesGrilla(ugClientesNovedades)
         tbcEnvioMail.SelectedTab = tbpClientes
         _titDetalle = GetColumnasVisiblesGrilla(ugClientes)

         'Agrego filtros con comportamiento estandar
         ugClientes.AgregarFiltroEnLinea({"NombreCliente", "CorreoElectronico"})
         ugNovedades.AgregarFiltroEnLinea({"NombreFuncion", "Descripcion"})
         ugClientesNovedades.AgregarFiltroEnLinea({"NombreFuncion", "Descripcion"})

         Me.LeerPreferencias()
         Me._estaCargando = False

         Me.cmbAplicacion.SelectedValue = "SIGA"

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.F5 Then
            Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
            Return True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
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

         Me.tsbEnviarCorreos.Enabled = True

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugClientes.Rows.Count > 0 Then
            txtAsuntoMail.Text = String.Format(Reglas.Publicos.CRMAsuntoEnvioMasivoNovedadesEmail,
                                               cmbAplicacion.Text,
                                               cmbVersionDesde.Text, cmbVersionHasta.Text,
                                               Reglas.Publicos.NombreEmpresa,
                                               Reglas.Publicos.NombreFantasia)
            btnConsultar.Focus()
         Else
            txtAsuntoMail.Text = ""

            Cursor = Cursors.Default
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssInfo.Text = String.Empty
         ShowError(ex)
      Finally
         MostrarCantidadRegistros()
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnExpandirHtml_Click(sender As Object, e As EventArgs) Handles btnExpandirHtml.Click
      Using frm As EditorHtml = New EditorHtml(rtbCuerpoMail.BodyHtml)
         If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            rtbCuerpoMail.BodyHtml = frm.BodyHTML
         End If
      End Using
   End Sub

   Private Sub tbcEnvioMail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcEnvioMail.SelectedIndexChanged
      Try
         MostrarCantidadRegistros()
      Catch ex As Exception
         ShowError(ex)
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
         MostrarCantidadRegistros()
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
   Private Sub tsbEnviarCorreos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEnviarCorreos.Click
      Try
         If ValidarCorreo() Then
            Me.Cursor = Cursors.WaitCursor
            Me.tsbEnviarCorreos.Enabled = False
            EnviaMails()
         Else
            ShowMessage(String.Format("Los Datos del Correo Electronico estan incompletos{0}(Configuraciones -> Parametros del Sistema)", Environment.NewLine))
         End If
      Catch ex As Exception
         ShowError(ex, True)
      Finally
         Me.Cursor = Cursors.Default
         tsbEnviarCorreos.Enabled = True
      End Try
   End Sub


   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Select Case True
            Case tbcEnvioMail.SelectedTab Is tbpClientes
               Dim pre As Preferencias = New Preferencias(Me.ugClientes, True)
               pre.ShowDialog()
            Case tbcEnvioMail.SelectedTab Is tbpNovedades
               Dim pre As Preferencias = New Preferencias(Me.ugNovedades, True)
               pre.ShowDialog()
            Case tbcEnvioMail.SelectedTab Is tbpNovedadesDelCliente
               Dim pre As Preferencias = New Preferencias(Me.ugClientesNovedades, True)
               pre.ShowDialog()
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

#Region "Eventos Grilla"
   Private Sub ugClientes_CellChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugClientes.CellChange
      If e.Cell.Row.Index <> -1 AndAlso e.Cell.Column.Key.Equals("Envio") AndAlso CBool(e.Cell.Text) Then
         If e.Cell.Row.Cells("CorreoElectronico").Text = "" Then
            ShowMessage("No se puede seleccionar porque no tiene correo electronico")
            e.Cell.Value = False
         End If
      End If
   End Sub
   Private Sub ugClientes_AfterRowActivate(sender As Object, e As EventArgs) Handles ugClientes.AfterRowActivate
      Try
         Dim dr As DataRow = ugClientes.FilaSeleccionada(Of DataRow)()
         CargaClientesNovedades(dr)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Examinar"
   Private Sub btnExaminar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar1.Click
      Me.ExaminarArchivo(txtArchivo1)
   End Sub
   Private Sub btnExaminar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar2.Click
      Me.ExaminarArchivo(txtArchivo2)
   End Sub
   Private Sub btnExaminar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar3.Click
      Me.ExaminarArchivo(txtArchivo3)
   End Sub
   Private Sub btnExaminar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar4.Click
      Me.ExaminarArchivo(txtArchivo4)
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


            Case tbcEnvioMail.SelectedTab Is tbpNovedades
               If Me.ugNovedades.Rows.Count = 0 Then Exit Sub

               Dim myWorkbook As New Workbook
               Dim myWorksheet As Worksheet
               myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
               myWorksheet.Rows(0).Cells(0).Value = Publicos.NombreEmpresaImpresion
               myWorksheet.Rows(1).Cells(0).Value = Me.Text & " - Novedades"
               myWorksheet.Rows(2).Cells(0).Value = Me.CargarFiltrosImpresion()

               Me.sfdExportar.FileName = Me.Name & "_Novedades.xls"
               Me.sfdExportar.Filter = "Archivos excel|*.xls"
               If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
                     Me.UltraGridExcelExporter1.Export(ugNovedades, myWorksheet, 4, 0)
                     myWorkbook.Save(Me.sfdExportar.FileName)
                  End If
               End If


            Case tbcEnvioMail.SelectedTab Is tbpNovedadesDelCliente
               If Me.ugClientesNovedades.Rows.Count = 0 Then Exit Sub

               Dim myWorkbook As New Workbook
               Dim myWorksheet As Worksheet
               myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
               myWorksheet.Rows(0).Cells(0).Value = Publicos.NombreEmpresaImpresion
               myWorksheet.Rows(1).Cells(0).Value = Me.Text & " - Clientes Novedades"
               myWorksheet.Rows(2).Cells(0).Value = Me.CargarFiltrosImpresion()

               Me.sfdExportar.FileName = Me.Name & "_ClientesNovedades.xls"
               Me.sfdExportar.Filter = "Archivos excel|*.xls"
               If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
                     Me.UltraGridExcelExporter1.Export(ugClientesNovedades, myWorksheet, 4, 0)
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


            Case tbcEnvioMail.SelectedTab Is tbpNovedades
               If Me.ugNovedades.Rows.Count = 0 Then Exit Sub

               Me.sfdExportar.FileName = Me.Name & "_Novedades.pdf"
               Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
               If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
                     Dim r As New Report()
                     Dim sec As ISection = r.AddSection()
                     sec.AddText.AddContent(Publicos.NombreEmpresaImpresion + System.Environment.NewLine)
                     sec.AddText.AddContent(Me.Text & " - Novedades" + System.Environment.NewLine)
                     sec.AddText.AddContent(Me.CargarFiltrosImpresion() + System.Environment.NewLine + System.Environment.NewLine)
                     Me.UltraGridDocumentExporter1.Export(Me.ugNovedades, sec)
                     r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
                  End If
               End If


            Case tbcEnvioMail.SelectedTab Is tbpNovedadesDelCliente
               If Me.ugClientesNovedades.Rows.Count = 0 Then Exit Sub

               Me.sfdExportar.FileName = Me.Name & "_ClientesNovedades.pdf"
               Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
               If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
                     Dim r As New Report()
                     Dim sec As ISection = r.AddSection()
                     sec.AddText.AddContent(Publicos.NombreEmpresaImpresion + System.Environment.NewLine)
                     sec.AddText.AddContent(Me.Text & " - Clientes Novedades" + System.Environment.NewLine)
                     sec.AddText.AddContent(Me.CargarFiltrosImpresion() + System.Environment.NewLine + System.Environment.NewLine)
                     Me.UltraGridDocumentExporter1.Export(Me.ugClientesNovedades, sec)
                     r.Publish(Me.sfdExportar.FileName, FileFormat.PDF)
                  End If
               End If
         End Select

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbCorreoPrueba_Click(sender As Object, e As EventArgs) Handles tsbCorreoPrueba.Click
      Try
         If ValidarCorreo() Then
            Me.EnviaMailPrueba()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos Privados"
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
      If TypeOf (Me.ugNovedades.DataSource) Is DataTable Then DirectCast(Me.ugNovedades.DataSource, DataTable).Rows.Clear()
      If TypeOf (Me.ugClientesNovedades.DataSource) Is DataTable Then DirectCast(Me.ugClientesNovedades.DataSource, DataTable).Rows.Clear()

      Me.cmbTodos.SelectedIndex = 0

      Me.tsbEnviarCorreos.Enabled = False
      Me.txtAsuntoMail.Text = String.Empty
      Me.rtbCuerpoMail.Text = String.Empty

      Me.tssInfo.Text = ""
      MostrarCantidadRegistros(0)
      Me.txtCopiaOculta.Text = Reglas.Publicos.CRMEnvioMailCopiaOculta
      Me.chbCopiaOculta.Checked = Not String.IsNullOrWhiteSpace(txtCopiaOculta.Text)
      Me.chbEnvioCtaCteCliente.Checked = True

      Me.txtArchivo1.Text = String.Empty
      Me.txtArchivo2.Text = String.Empty
      Me.txtArchivo3.Text = String.Empty
      Me.txtArchivo4.Text = String.Empty

   End Sub

   Private Sub CargaGrillaDetalle()
      Try
         Dim idCliente As Long = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0)
         Dim idZonaGeografica As String = If(chbZonaGeografica.Checked, cmbZonaGeografica.SelectedValue.ToString(), String.Empty)
         Dim idCobrador As Integer = If(chbCobrador.Checked, DirectCast(cmbCobrador.SelectedItem, Entidades.Empleado).IdEmpleado, 0)

         Dim envioMasivo As CRMEnvioMasivoNovedadesMails = New CRMEnvioMasivoNovedadesMails()

         _dtEnvioMail = envioMasivo.GetEnvioMasivoNovedadesMail(cmbAplicacion.SelectedValue.ToString(),
                                                                cmbCategoriasClientes.GetCategorias(True),
                                                                idZonaGeografica,
                                                                idCliente,
                                                                txtComenzarPorNombreCliente.Text,
                                                                Reglas.Publicos.ConfiguraciónMailCRM,
                                                                idCobrador)
         Me.ugClientes.DataSource = _dtEnvioMail
         AjustarColumnasGrilla(ugClientes, _titDetalle)

         _dtNovedades = New Reglas.CRMNovedades().GetNovedadesPorVersion(cmbAplicacion.SelectedValue.ToString(), idZonaGeografica, cmbVersionDesde.Text, cmbVersionHasta.Text)
         Me.ugNovedades.DataSource = _dtNovedades
         AjustarColumnasGrilla(ugNovedades, _titNovedades)

      Catch ex As Exception
         ShowError(ex)
      Finally
         MostrarCantidadRegistros()
         Me.Cursor = Cursors.Default
      End Try
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

   Private Sub EnviaMails()
      If String.IsNullOrEmpty(txtAsuntoMail.Text) Then
         Me.txtAsuntoMail.Focus()
         Throw New Exception("ATENCION: Debe ingresar el Asunto del Correo.")
      End If
      If String.IsNullOrEmpty(rtbCuerpoMail.BodyHtml) Then
         Me.rtbCuerpoMail.Focus()
         Throw New Exception("ATENCION: Debe ingresar el Cuerpo del Correo.")
      End If

      Dim copiaOculta As String = String.Empty
      If chbCopiaOculta.Checked Then copiaOculta = txtCopiaOculta.Text

      Me.ugClientes.UpdateData()

      Dim adjuntos As String() = {Me.txtArchivo1.Text, Me.txtArchivo2.Text, Me.txtArchivo3.Text, Me.txtArchivo4.Text}
      Dim archivos As Dictionary(Of Long, String) = GenerarArchivos(_dtEnvioMail)

      Dim wEnvioMasivo As CRMEnvioMasivoNovedadesMails = New CRMEnvioMasivoNovedadesMails()
      wEnvioMasivo.EnviarMails(txtAsuntoMail.Text, rtbCuerpoMail.BodyHtml, copiaOculta,
                               _dtEnvioMail, _dtNovedades, adjuntos, archivos,
                               tspBarra, tssInfo, Me.chbEnvioCtaCteCliente.Checked)

      ShowMessage("¡¡Novedades enviadas con Exito!!")

      Me.tspBarra.Value = 0
      Me.RefrescarDatosGrilla()
   End Sub

   Private Sub EnviaMailPrueba()
      If String.IsNullOrEmpty(txtAsuntoMail.Text) Then
         Me.txtAsuntoMail.Focus()
         Throw New Exception("ATENCION: Debe ingresar el Asunto del Correo.")
      End If
      If String.IsNullOrEmpty(rtbCuerpoMail.BodyHtml) Then
         Me.rtbCuerpoMail.Focus()
         Throw New Exception("ATENCION: Debe ingresar el Cuerpo del Correo.")
      End If

      Dim mailPrueba As String = String.Empty
      If chbCopiaOculta.Checked And Not String.IsNullOrWhiteSpace(txtCopiaOculta.Text) Then
         mailPrueba = txtCopiaOculta.Text
      Else
         mailPrueba = Reglas.Publicos.ProcesosCorreoPruebaPara
      End If



      Me.ugClientes.UpdateData()

      Dim adjuntos As String() = {Me.txtArchivo1.Text, Me.txtArchivo2.Text, Me.txtArchivo3.Text, Me.txtArchivo4.Text}
      Dim archivos As Dictionary(Of Long, String) = GenerarArchivos(_dtEnvioMail)

      Me.EnviarMailPrueba(txtAsuntoMail.Text, rtbCuerpoMail.BodyHtml, mailPrueba,
                               _dtEnvioMail, _dtNovedades, adjuntos, archivos,
                               tspBarra, tssInfo, Me.chbEnvioCtaCteCliente.Checked)


      Me.tspBarra.Value = 0
      '  Me.RefrescarDatosGrilla()
   End Sub

   Private Function GenerarArchivos(dt As DataTable) As Dictionary(Of Long, String)
      Dim archivos As Dictionary(Of Long, String) = New Dictionary(Of Long, String)()
      Dim formatoNombreArchivo As String = "NovedadesDeVersion_{0}_{1}_{2}_{3}.xls"
      Dim nombreArchivo As String
      Dim nombreArchivoFull As String
      Const directorioCorreos As String = "Eniac\Correos"
      For Each dr As DataRow In dt.Select("Envio")
         If IsNumeric(dr("IdCliente")) Then
            Dim idCliente As Long = Long.Parse(dr("IdCliente").ToString())
            If idCliente > 0 AndAlso Not archivos.ContainsKey(idCliente) Then
               nombreArchivo = String.Format(formatoNombreArchivo, dr("IdAplicacion"), dr("Edicion"), dr("NombreCliente"), dr("CodigoCliente"))
               nombreArchivoFull = IO.Path.Combine(Entidades.Publicos.DriverBase, directorioCorreos, nombreArchivo)

               tssInfo.Text = String.Format("Generando archivo {0}", nombreArchivo)
               Application.DoEvents()

               CargaClientesNovedades(dr)
               Dim exp As UltraGridExportarExcel = New UltraGridExportarExcel(UltraGridExcelExporter1, Publicos.NombreEmpresaImpresion)
               exp.Exportar(nombreArchivoFull, txtAsuntoMail.Text, ugClientesNovedades, "", True)
               archivos.Add(idCliente, nombreArchivoFull)
            End If
         End If
      Next

      Return archivos
   End Function

   Private Function ValidarCorreo() As Boolean
      Dim validaDatos As Boolean = True
      If (Publicos.MailServidor = "" Or
          Publicos.MailDireccion = "" Or
          Publicos.MailUsuario = "" Or
          Publicos.MailPassword = "" Or
          Publicos.MailPuertoSalida = 0) Then
         validaDatos = False
      End If
      Return validaDatos
   End Function

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugClientes.FindForm().Name & "Grid.xml"
         Dim nameGrid1 As String = Me.ugNovedades.FindForm().Name & "Grid.xml"
         Dim nameGrid2 As String = Me.ugClientesNovedades.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugClientes.DisplayLayout.LoadFromXml(nameGrid)
         End If

         If System.IO.File.Exists(nameGrid1) Then
            Me.ugNovedades.DisplayLayout.LoadFromXml(nameGrid1)
         End If

         If System.IO.File.Exists(nameGrid2) Then
            Me.ugClientesNovedades.DisplayLayout.LoadFromXml(nameGrid2)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargaClientesNovedades(dr As DataRow)
      Dim dt As DataTable = _dtNovedades.Clone()
      If dr IsNot Nothing Then
         Dim condicion As String = "(Reporta = 'CLIENTE' AND IdCliente = {1}) OR (Reporta = 'SI' AND {0} = 'S')"
         If dr("Edicion").ToString() = "Plus" Then
            condicion = String.Format(condicion, "Plus", dr("IdCliente"))
         ElseIf dr("Edicion").ToString() = "Básica" Then
            condicion = String.Format(condicion, "Basica", dr("IdCliente"))
         ElseIf dr("Edicion").ToString() = "Express" Then
            condicion = String.Format(condicion, "Express", dr("IdCliente"))
         ElseIf dr("Edicion").ToString() = "PV" Then
            condicion = String.Format(condicion, "PV", dr("IdCliente"))
         Else
            condicion = String.Format(condicion, "'N'", -1)
         End If
         dt.ImportRowRange(_dtNovedades.Select(condicion))
      End If

      dt.DefaultView.Sort = "NombreFuncionPadre, NombreFuncion, Descripcion"
      ugClientesNovedades.DataSource = dt.DefaultView
      AjustarColumnasGrilla(ugClientesNovedades, _titClientesNovedades)
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

   Public Sub EnviarMailPrueba(asuntoMail As String, cuerpoMail As String, bcc As String,
                          dtEnvioMail As DataTable, dtNovedades As DataTable, adjuntos As String(),
                          dicArchivosNovedades As Dictionary(Of Long, String),
                          tspBarra As ToolStripProgressBar, tslTexto As ToolStripStatusLabel,
                          envioCtaCteCliente As Boolean)

      If String.IsNullOrEmpty(asuntoMail) Then Throw New Exception("ATENCION: Debe ingresar el Asunto del Correo.")
      If cuerpoMail Is Nothing OrElse cuerpoMail.Length = 0 Then Throw New Exception("ATENCION: Debe ingresar el Cuerpo del Correo.")

      Dim intCantidad As Integer = 0
      Dim rEnvioMail As Reglas.CRMEnvioMasivoNovedadesMails = New Reglas.CRMEnvioMasivoNovedadesMails()

      Dim destinaBCC As List(Of String) = New List(Of String)()
      If Not String.IsNullOrWhiteSpace(bcc) Then
         For Each correo As String In bcc.Split(";"c)
            If Not String.IsNullOrWhiteSpace(correo) Then
               ' destinaBCC.Add(correo)
            End If
         Next
      End If

      'Trabajo el cuerpo para que respete el formato
      Dim stbCuerpo As StringBuilder = New StringBuilder()
      ' FormatearCuerpoMensaje(stbCuerpo, cuerpoMail)
      '--------------------------------------------

      '  tspBarra.Maximum = clientesEnvio.Count * 2
      tspBarra.Value = 0

      'Al 12/02/2015 Son 2 reglas, 150 maximo por hora y 15 maximo por minuto.
      'Se baja a 120 por hora y 12 por minutos.

      '30 Segundos = 30 x 1000 = 120 Correos por Horas
      Dim intTiempoEntreCorreos As Integer = 30000
      If intCantidad <= 120 Then
         '5 Segundos 
         intTiempoEntreCorreos = 5000
      End If

      Dim intActual As Integer = 0
      Dim TiempoEstimado As Integer = intCantidad * 1000 + intCantidad * intTiempoEntreCorreos
      Dim HoraInicio As DateTime = DateTime.Now()
      Dim oVentas As Eniac.Reglas.Ventas = New Eniac.Reglas.Ventas()
      Dim saldocliente As Decimal
      Dim entro As Boolean = False

      'recorro todos los clientes seleccionados en la grilla
      For Each dr As UltraGridRow In Me.ugClientes.Rows

         If entro Then Exit For

         If Not CBool(dr.Cells("Envio").Value.ToString()) Then Continue For

         entro = True

         intActual += 1
         'La barra queda un poco corta para tanto texto
         '  tslTexto.Text = String.Format("Cliente: ({0){1}. Correos: {2}. ",
         '                            dr.Cells("CodigoCliente").Value, dr.Cells("NombreCliente").Value,)
         Application.DoEvents()


         Dim CorreoPrueba As String = String.Empty

         If chbCopiaOculta.Checked And Not String.IsNullOrWhiteSpace(bcc) Then
            CorreoPrueba = bcc
         ElseIf Not String.IsNullOrWhiteSpace(bcc) Then
            CorreoPrueba = bcc
         End If



         Dim PantCorreo As CorreoPrueba = New CorreoPrueba(CorreoPrueba)
         PantCorreo.ShowDialog()

         If PantCorreo.DialogResult = Windows.Forms.DialogResult.OK Then

            If IsValidEmail(PantCorreo.txtCorreoDePrueba.Text) Then
               tslTexto.Text = String.Format(" Enviando Correo a: {0}", PantCorreo.txtCorreoDePrueba.Text)
               tspBarra.PerformStep()
               Application.DoEvents()

               Dim destina As List(Of String) = New List(Of String)()

               'cargo los destinatarios
               For Each correo As String In PantCorreo.txtCorreoDePrueba.Text.Split(";"c)
                  If Not String.IsNullOrWhiteSpace(correo) Then
                     destina.Add(correo)
                  End If
               Next

               saldocliente = 0

               Dim cuerpoMailTemp As String = stbCuerpo.ToString()
               If cuerpoMailTemp.Contains("@@saldocliente@@") Then
                  cuerpoMailTemp = cuerpoMailTemp.Replace("@@saldocliente@@", saldocliente.ToString("N2"))
               End If

               If cuerpoMailTemp.Contains("{0}") Then
                  cuerpoMailTemp = String.Format(cuerpoMailTemp, dr.Cells("NombreCliente").Value)
               End If

               'creo el mail y lo envio
               Dim ms As Eniac.Win.MailSSS = New Eniac.Win.MailSSS()
               ms.CrearMail("TO", destina.ToArray(), asuntoMail, cuerpoMailTemp, Nothing, destinaBCC.ToArray())
               'For Each comprMail As Reglas.CRMEnvioMasivoNovedadesMails.ComprobanteEnvioMail In clienteEnvio.Comprobantes
               '   ms.AgregarAdjunto(comprMail.NombreArchivoDestino)
               'Next

               For Each adjunto As String In adjuntos
                  If Not String.IsNullOrWhiteSpace(adjunto) Then
                     ms.AgregarAdjunto(adjunto)
                  End If
               Next

               If dicArchivosNovedades.ContainsKey(Long.Parse(dr.Cells("IdCliente").Value.ToString())) AndAlso IO.File.Exists(dicArchivosNovedades(Long.Parse(dr.Cells("IdCliente").Value.ToString()))) Then
                  ms.AgregarAdjunto(dicArchivosNovedades(Long.Parse(dr.Cells("IdCliente").Value.ToString())))
               End If

               ms.EnviarMail()

               tspBarra.PerformStep()
               tslTexto.Text = String.Format("({0}) ", Math.Round(intTiempoEntreCorreos / 1000, 0)) + tslTexto.Text
               Application.DoEvents()

               System.Threading.Thread.Sleep(intTiempoEntreCorreos)

               ShowMessage("¡¡Mail enviado con Exito!!")
            Else
               ShowMessage("ATENCION: Ingrese un correo valido")
            End If

         End If

         tssInfo.Text = ""
         Application.DoEvents()
      Next

      If Not entro Then
         ShowMessage("ATENCION: No seleccionó ningún Cliente.")
      End If

   End Sub
   Private Function IsValidEmail(ByVal email As String) As Boolean
      If email = String.Empty Then Return False
      ' Compruebo si el formato de la dirección es correcto.
      Dim re As Regex = New Regex("^[\w._%-]+@[\w.-]+\.[a-zA-Z]{2,4}$")
      Dim m As Match = re.Match(email)
      Return (m.Captures.Count <> 0)
   End Function

#Region "Metodos StatusBar"
   Private Sub MostrarCantidadRegistros()
      If tbcEnvioMail.SelectedTab.Equals(tbpClientes) Then
         MostrarCantidadRegistros(ugClientes)
      ElseIf tbcEnvioMail.SelectedTab.Equals(tbpNovedades) Then
         MostrarCantidadRegistros(ugNovedades)
      ElseIf tbcEnvioMail.SelectedTab.Equals(tbpNovedadesDelCliente) Then
         MostrarCantidadRegistros(ugClientesNovedades)
      Else
         MostrarCantidadRegistros(0)
      End If
   End Sub
   Private Sub MostrarCantidadRegistros(grilla As UltraGrid)
      If TypeOf (grilla.DataSource) Is DataTable Then
         MostrarCantidadRegistros(DirectCast(grilla.DataSource, DataTable).Rows.Count)
      Else
         '  MostrarCantidadRegistros(0)
         MostrarCantidadRegistros(ugClientesNovedades.Rows.Count)
      End If
   End Sub
   Private Sub MostrarCantidadRegistros(count As Integer)
      tssRegistros.Text = String.Format("{0} Registros", count)
   End Sub
#End Region

#End Region

End Class