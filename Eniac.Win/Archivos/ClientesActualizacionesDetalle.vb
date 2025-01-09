#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports Infragistics.Documents.Excel
#End Region
Public Class ClientesActualizacionesDetalle

#Region "Campos/Propiedades"
   Private Property Ejecucion As Entidades.ClienteActualizacion

   Private _idCliente As Long
   Private _nombreServidor As String
   Private _baseDatos As String
   Private _fechaEjecucion As DateTime
   Private _marcarEventHandler As Func(Of DialogResult)

   Private _tit As Dictionary(Of String, String)
#End Region

#Region "Overrides/Overloads"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         ugDetalle.AgregarFiltroEnLinea({Entidades.ClienteActualizacionSuceso.Columnas.Datos.ToString(),
                                         Entidades.ClienteActualizacionSuceso.Columnas.TipoSuceso.ToString()})

         RefrescarDatosGrilla()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Public Overloads Function ShowDialog(owner As Form,
                                        idCliente As Long,
                                        nombreServidor As String,
                                        baseDatos As String,
                                        fechaEjecucion As DateTime,
                                        marcarEventHandler As Func(Of DialogResult)) As DialogResult
      Try
         _idCliente = idCliente
         _nombreServidor = nombreServidor
         _baseDatos = baseDatos
         _fechaEjecucion = fechaEjecucion
         _marcarEventHandler = marcarEventHandler

      Catch ex As Exception
         ShowError(ex)
         Return Windows.Forms.DialogResult.Cancel
      End Try
      Return ShowDialog(owner)
   End Function
#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         RefrescarDatosGrilla()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try
         Try

            If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

            Dim Filtros As String = CargarFiltrosImpresion()

            Dim Titulo As String

            Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

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

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         Using sfdExportar As New System.Windows.Forms.SaveFileDialog()
            sfdExportar.FileName = String.Format("{0}.xls", Name)
            sfdExportar.Filter = "Archivos excel|*.xls"
            If sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
               Dim myWorkbook As New Workbook()
               Dim myWorksheet As Worksheet
               Dim nombreHoja As String = String.Format("Hoja {0}", myWorkbook.Worksheets.Count + 1)


               myWorksheet = myWorkbook.Worksheets.Add(nombreHoja)
               myWorksheet.Rows(0).Cells(0).Value = Publicos.NombreEmpresaImpresion
               myWorksheet.Rows(1).Cells(0).Value = Text
               myWorksheet.Rows(2).Cells(0).Value = PrimerFilaFiltros()
               myWorksheet.Rows(3).Cells(0).Value = SegundaFilaFiltros()
               myWorksheet.Rows(4).Cells(0).Value = TerceraFilaFiltros()

               Me.UltraGridExcelExporter1.Export(ugDetalle, myWorksheet, 6, 0)

               myWorkbook.Save(sfdExportar.FileName.Trim())
            End If
         End Using

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Try
         DialogResult = Windows.Forms.DialogResult.Cancel
         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

   Private Sub ugDetalle_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      Try
         Dim dr As Entidades.ClienteActualizacionSuceso = ugDetalle.FilaSeleccionada(Of Entidades.ClienteActualizacionSuceso)(e.Row)
         If dr IsNot Nothing Then
            e.Row.Cells(Entidades.ClienteActualizacionSuceso.Columnas.Estado.ToString()).Appearance.BackColor = DefinirBackColorSegunEstado(dr.Estado)
            e.Row.Cells(Entidades.ClienteActualizacionSuceso.Columnas.Estado.ToString()).Appearance.ForeColor = DefinirForeColorSegunEstado(dr.Estado)
            e.Row.Cells(Entidades.ClienteActualizacionSuceso.Columnas.Estado.ToString()).ActiveAppearance.BackColor = DefinirBackColorSegunEstado(dr.Estado)
            e.Row.Cells(Entidades.ClienteActualizacionSuceso.Columnas.Estado.ToString()).ActiveAppearance.ForeColor = DefinirForeColorSegunEstado(dr.Estado)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()

      Ejecucion = New Reglas.ClientesActualizaciones().GetUno(_idCliente, _nombreServidor, _baseDatos, _fechaEjecucion, cargaSucesos:=True, accion:=Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)

      txtCodigoCliente.Text = Ejecucion.CodigoCliente.ToString()
      txtNombreCliente.Text = Ejecucion.NombreCliente

      txtNombreServidor.Text = Ejecucion.NombreServidor
      txtBaseDatos.Text = Ejecucion.BaseDatos
      dtpFechaEjecución.Value = Ejecucion.FechaEjecucion

      dtpFechaInicioActualizacion.Value = If(Ejecucion.FechaInicioActualizacion.HasValue, Ejecucion.FechaInicioActualizacion.Value, dtpFechaInicioActualizacion.MinDate)
      dtpFechaInicioActualizacion.Checked = Ejecucion.FechaInicioActualizacion.HasValue
      dtpFechaFinActualizacion.Value = If(Ejecucion.FechaFinActualizacion.HasValue, Ejecucion.FechaFinActualizacion.Value, dtpFechaFinActualizacion.MinDate)
      dtpFechaFinActualizacion.Checked = Ejecucion.FechaFinActualizacion.HasValue

      txtIdUnico.Text = Ejecucion.IdUnico
      txtActivo.Text = ConvertirActivoString(Ejecucion.Activo)

      txtEstado.Text = Ejecucion.Estado.ToString()
      txtDescargaScripts.Text = Ejecucion.EstadoDescargaScripts.ToString()
      txtDescargaInstalador.Text = Ejecucion.EstadoDescargaInstalador.ToString()
      txtBackup.Text = Ejecucion.EstadoBackup.ToString()
      txtEjecucionScripts.Text = Ejecucion.EstadoEjecucionScripts.ToString()
      txtEjecucionInstalador.Text = Ejecucion.EstadoEjecucionInstalador.ToString()

      DefinirColorSegunEstado(txtEstado, Ejecucion.Estado)
      DefinirColorSegunEstado(txtDescargaScripts, Ejecucion.EstadoDescargaScripts)
      DefinirColorSegunEstado(txtDescargaInstalador, Ejecucion.EstadoDescargaInstalador)
      DefinirColorSegunEstado(txtBackup, Ejecucion.EstadoBackup)
      DefinirColorSegunEstado(txtEjecucionScripts, Ejecucion.EstadoEjecucionScripts)
      DefinirColorSegunEstado(txtEjecucionInstalador, Ejecucion.EstadoEjecucionInstalador)

      tsbDesactivar.Visible = Ejecucion.Estado = Entidades.ClienteActualizacion.EstadoActualizacion.ConError AndAlso Ejecucion.Activo
      tssDesactivar.Visible = tsbDesactivar.Visible

      ugDetalle.DataSource = Ejecucion.Sucesos.OrderBy(Function(x) x.Orden).ToArray()
      AjustarColumnasGrilla(ugDetalle, _tit)
      PreferenciasLeer(ugDetalle, tsbPreferencias)

      tssRegistros.Text = String.Format("{0} Registros", Ejecucion.Sucesos.Count)

   End Sub


#Region "Manejo de colores segun estado"
   Private Sub DefinirColorSegunEstado(txt As Control, estado As Entidades.ClienteActualizacion.EstadoActualizacion)
      txt.BackColor = DefinirBackColorSegunEstado(estado)
      txt.ForeColor = DefinirForeColorSegunEstado(estado)
   End Sub

   Private Function DefinirForeColorSegunEstado(estado As Entidades.ClienteActualizacion.EstadoActualizacion) As Color
      Select Case estado
         Case Entidades.ClienteActualizacion.EstadoActualizacion.ConError
            Return Color.White
         Case Entidades.ClienteActualizacion.EstadoActualizacion.Inicio
            Return Color.Yellow
         Case Entidades.ClienteActualizacion.EstadoActualizacion.Finalizado
            Return Color.White
         Case Else
            Return Nothing
      End Select
   End Function

   Private Function DefinirBackColorSegunEstado(estado As Entidades.ClienteActualizacion.EstadoActualizacion) As Color
      Select Case estado
         Case Entidades.ClienteActualizacion.EstadoActualizacion.ConError
            Return Color.Red
         Case Entidades.ClienteActualizacion.EstadoActualizacion.Inicio
            Return Color.Yellow
         Case Entidades.ClienteActualizacion.EstadoActualizacion.Finalizado
            Return Color.Green
         Case Else
            Return Nothing
      End Select
   End Function
#End Region

#Region "Metodos Filtros"
   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      With filtro

         filtro.AppendFormat("{0}", PrimerFilaFiltros())
         filtro.AppendFormat(" - {0}", SegundaFilaFiltros())
         filtro.AppendFormat(" - {0}", TerceraFilaFiltros())

      End With

      Return filtro.ToString()

   End Function

   Private Function ConvertirActivoString(activo As Boolean) As String
      Return If(Ejecucion.Activo, "ACTIVO", "INACTIVO")
   End Function
   Private Function PrimerFilaFiltros() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      With filtro

         filtro.AppendFormat("{0}: ({1}) {2}", lblCliente.Text, Ejecucion.CodigoCliente, Ejecucion.NombreCliente)
         filtro.AppendFormat(" - {0}: {1}", lblNombreServidor.Text, Ejecucion.NombreServidor)
         filtro.AppendFormat(" - {0}: {1}", lblBaseDatos.Text, Ejecucion.BaseDatos)

      End With
      Return filtro.ToString()
   End Function
   Private Function SegundaFilaFiltros() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      With filtro

         filtro.AppendFormat("{0}: {1:dd/MM/yyyy HH:mm:ss}", lblFechaEjecucion.Text, Ejecucion.FechaEjecucion)
         filtro.AppendFormat(" - {0}: {1:dd/MM/yyyy HH:mm:ss} {2}: {3:dd/MM/yyyy HH:mm:ss}", lblFechaInicioActualizacion.Text, Ejecucion.FechaInicioActualizacion, lblFechaFinActualizacion.Text, Ejecucion.FechaFinActualizacion)
         filtro.AppendFormat(" - {0}: {1}", lblIdUnico.Text, Ejecucion.IdUnico)
         filtro.AppendFormat(" - {0}", ConvertirActivoString(Ejecucion.Activo))

      End With
      Return filtro.ToString()
   End Function
   Private Function TerceraFilaFiltros() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      With filtro

         filtro.AppendFormat("{0}: {1}", lblEstado.Text, Ejecucion.Estado.ToString())
         filtro.AppendFormat(" - {0}: {1}", lblDescargaScripts.Text, Ejecucion.EstadoDescargaScripts.ToString())
         filtro.AppendFormat(" - {0}: {1}", lblDescargaInstalador.Text, Ejecucion.EstadoDescargaInstalador.ToString())
         filtro.AppendFormat(" - {0}: {1}", lblBackup.Text, Ejecucion.EstadoBackup.ToString())
         filtro.AppendFormat(" - {0}: {1}", lblEjecucionScripts.Text, Ejecucion.EstadoEjecucionScripts.ToString())
         filtro.AppendFormat(" - {0}: {1}", lblEjecucionInstalador.Text, Ejecucion.EstadoEjecucionInstalador.ToString())

      End With
      Return filtro.ToString()
   End Function
#End Region
#End Region

   Private Sub tsbDesactivar_Click(sender As Object, e As EventArgs) Handles tsbDesactivar.Click
      Try
         If _marcarEventHandler IsNot Nothing Then
            If _marcarEventHandler.Invoke() = Windows.Forms.DialogResult.OK Then
               DialogResult = Windows.Forms.DialogResult.OK
               Close()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      Try
         Dim dr As Entidades.ClienteActualizacionSuceso = ugDetalle.FilaSeleccionada(Of Entidades.ClienteActualizacionSuceso)(e.Cell.Row)
         Select Case e.Cell.Column.Key
            Case "VerScript"
               If Not String.IsNullOrWhiteSpace(dr.Script) Then
                  Using frm As VisorTexto = New VisorTexto
                     frm.ShowDialog(Me, "Script", dr.Script)
                  End Using
               End If
            Case "CopiarScript"
               If Not String.IsNullOrWhiteSpace(dr.Script) Then
                  Clipboard.SetText(dr.Script)
               End If
            Case Else

         End Select
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class