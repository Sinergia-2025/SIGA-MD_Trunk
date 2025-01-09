Option Explicit On
Option Strict On

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual

Imports System.Data
Imports System.IO
Imports Infragistics.Win.UltraWinGrid.DocumentExport
Imports Infragistics.Win.UltraWinGrid.ExcelExport


#End Region

Public Class ContabilidadExportacion

#Region "Campos"

   Private _publicosContabilidad As ContabilidadPublicos
   Private _publicos As Publicos
   Private _archi As ContabilidadExportacionArchivo

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicosContabilidad = New ContabilidadPublicos()
         Me._publicos = New Publicos()

         Me._publicosContabilidad.CargaComboPlanes(Me.cmbPlan, False)

         _publicos.CargaListBoxDesdeEnum(chkprocesos, GetType(Entidades.ContabilidadProceso.Procesos))

         Me.RefrescarDatosGrilla()

         Me.cmbAsientosExportados.SelectedIndex = 0
         Me._publicosContabilidad.CargaComboFechasExportacion(cmbFechasExportacion)

         chbTodos.Checked = False
         chbTodos.Checked = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   'Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged
   '   Try
   '      Dim dt As dsAFIP.CitiVentasDataTable = DirectCast(Me.ugdAsientos.DataSource, dsAFIP.CitiVentasDataTable)
   '      For Each dr As dsAFIP.CitiVentasRow In dt.Rows
   '         If String.IsNullOrEmpty(dr.TipoError) And Not dr.EstaAnulada Then
   '            dr.Proceso = Me.chbTodos.Checked
   '         End If
   '      Next
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Private Sub ContabilidadExportacion_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbExportar.PerformClick()
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.ugdAsientos.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExportar.Click

      Try

         If Me.ugdAsientos.Rows.Count = 0 Then Exit Sub

         If Me.txtArchivoDestino.Text.Trim() = "" Then
            MessageBox.Show("No Indico el Archivo Destino.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtArchivoDestino.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.ExportarDatos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugdAsientos.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
            Me.tsbExportar.Enabled = True
         Else
            Me.tsbExportar.Enabled = False
            MessageBox.Show("No hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArchivo.Click

      Dim DialogoGuardarArchivo As New SaveFileDialog()

      DialogoGuardarArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoGuardarArchivo.Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*"
      DialogoGuardarArchivo.FilterIndex = 1
      DialogoGuardarArchivo.RestoreDirectory = True

      If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            If DialogoGuardarArchivo.FileName <> "" Then

               Me.txtArchivoDestino.Text = DialogoGuardarArchivo.FileName

               'If System.IO.File.Exists(Me.txtArchivoDestino.Text.Trim()) Then
               '   If MessageBox.Show("El Archivo Seleccionado Existe, Desea Sobreescribirlo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
               '      Me.txtArchivoDestino.Text = ""
               '   End If
               'End If

            End If

         Catch Ex As Exception

            MessageBox.Show(Ex.Message)

         End Try

      End If

   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.dtpFechaDesde.Value = DateTime.Today
      Me.dtpFechaHasta.Value = DateTime.Today

      If Not Me.ugdAsientos.DataSource Is Nothing Then
         DirectCast(Me.ugdAsientos.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtArchivoDestino.Text = ""

      Me.tsbExportar.Enabled = False

      Me.cmbAsientosExportados.SelectedIndex = 0

      lblFormato.Text = Reglas.ContabilidadPublicos.ContabilidadFormatoExportacion

      chbTodos.Checked = False
      chbTodos.Checked = True

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oConta As Reglas.ContabilidadAsientos = New Reglas.ContabilidadAsientos()

      Try

         Dim dtDetalle As DataTable

         Dim FechaExport As DateTime = Date.Today

         If cmbFechasExportacion.Visible And cmbFechasExportacion.SelectedIndex <> -1 Then
            FechaExport = DateTime.Parse(cmbFechasExportacion.SelectedValue.ToString())
         End If

         dtDetalle = oConta.GetAsientosAExportar(Int32.Parse(Me.cmbPlan.SelectedValue.ToString()),
                                                 Me.dtpFechaDesde.Value, Me.dtpFechaHasta.Value,
                                                 Me.cmbAsientosExportados.Text, FechaExport,
                                                 chkprocesos.CheckedItems)

         Dim linea As Integer = 1
         Me._archi = New ContabilidadExportacionArchivo()

         AgregarSubsiAsientoDescr(dtDetalle)

         Me.ugdAsientos.DataSource = dtDetalle

         FormatearGrilla()

         Me.txtArchivoDestino.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\Contabilidad_" + Me.dtpFechaDesde.Value.ToString("yyyyMMdd") + "_" + Me.dtpFechaHasta.Value.ToString("yyyyMMdd") + ".txt"

         Me.CrearArchivoExportacion()

         Me.tssRegistros.Text = Me.ugdAsientos.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Friend Shared Sub AgregarSubsiAsientoDescr(dtDetalle As DataTable)
      dtDetalle.Columns.Add("SubsiAsientoDescr", GetType(String))

      Dim procesos As Dictionary(Of Object, String) = Publicos.EnumToDictionary(GetType(Entidades.ContabilidadProceso.Procesos), , True)
      For Each dr As DataRow In dtDetalle.Rows
         If procesos.ContainsKey(dr("SubsiAsiento").ToString().Trim()) Then
            dr("SubsiAsientoDescr") = procesos(dr("SubsiAsiento").ToString().Trim())
         End If
      Next
   End Sub

   Private Sub FormatearGrilla()
      'Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      ''Me.dgdDatos.DisplayLayout.Bands(0).SortedColumns.Add("idAsiento", False, False)
      'Me.ugDetalle.DisplayLayout.Bands(0).SortedColumns.Add("nombreAsiento", False, True)
      'Me.ugDetalle.DisplayLayout.Bands(0).Columns("idAsiento").Band.SortedColumns.RefreshSort(False)
      'Me.ugDetalle.Rows.ExpandAll(False)

      With Me.ugdAsientos.DisplayLayout.Bands(0)
         .Columns("IdPlanCuenta").Header.VisiblePosition = 0
         .Columns("IdPlanCuenta").Header.Caption = "P."
         .Columns("IdPlanCuenta").CellAppearance.TextHAlign = HAlign.Right
         .Columns("IdPlanCuenta").Width = 25
         .Columns("idAsiento").Header.VisiblePosition = 1
         .Columns("idAsiento").Header.Caption = "Asiento"
         .Columns("idAsiento").CellAppearance.TextHAlign = HAlign.Right
         .Columns("IdAsiento").Width = 54
         .Columns("fechaAsiento").Header.VisiblePosition = 2
         .Columns("fechaAsiento").Width = 80
         .Columns("fechaAsiento").Header.Caption = "Fecha"
         .Columns("fechaAsiento").CellAppearance.TextHAlign = HAlign.Center
         .Columns("nombreAsiento").Header.VisiblePosition = 3
         .Columns("nombreAsiento").Header.Caption = "Asiento"
         .Columns("nombreAsiento").Width = 170
         .Columns("idRenglon").Header.VisiblePosition = 6
         .Columns("idRenglon").Header.Caption = "Orden"
         .Columns("idRenglon").CellAppearance.TextHAlign = HAlign.Right
         .Columns("idRenglon").Width = 45
         .Columns("idCuenta").Header.VisiblePosition = 4
         .Columns("idCuenta").Header.Caption = "Nro. Cuenta"
         .Columns("idCuenta").CellAppearance.TextHAlign = HAlign.Right
         .Columns("NombreCuenta").Header.VisiblePosition = 5
         .Columns("NombreCuenta").Header.Caption = "Cuenta"
         .Columns("NombreCuenta").Width = 150
         .Columns("Debe").Header.VisiblePosition = 7
         .Columns("Debe").Width = 70
         .Columns("Debe").Header.Caption = "Debe"
         .Columns("Debe").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Debe").Format = "N2"
         .Columns("Haber").Header.VisiblePosition = 8
         .Columns("Haber").Width = 70
         .Columns("Haber").Header.Caption = "Haber"
         .Columns("Haber").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Haber").Format = "N2"

         .Columns("CodigoReferencia").Header.VisiblePosition = 9
         .Columns("CodigoReferencia").Width = 70
         .Columns("CodigoReferencia").Header.Caption = "Referencia"
         .Columns("CodigoReferencia").CellAppearance.TextHAlign = HAlign.Right

         .Columns("NombreReferencia").Header.VisiblePosition = 10
         .Columns("NombreReferencia").Width = 170
         .Columns("NombreReferencia").Header.Caption = "Nombre Referencia"

         .Columns("SubsiAsientoDescr").Header.VisiblePosition = 11
         .Columns("SubsiAsientoDescr").Header.Caption = "Subsistema"

         .Columns("FechaExportacion").Header.VisiblePosition = 12
         .Columns("FechaExportacion").Width = 130
         .Columns("FechaExportacion").Header.Caption = "Fecha Exportación"
         .Columns("FechaExportacion").CellAppearance.TextHAlign = HAlign.Center
         .Columns("FechaExportacion").Format = "dd/MM/yyyy HH:mm:ss"

         .Columns("IdEjercicio").Hidden = True
         .Columns("SubsiAsiento").Hidden = True
         .Columns("IdTipoReferencia").Hidden = True
         .Columns("Referencia").Hidden = True
         .Columns("EsManual").Hidden = True

      End With
   End Sub

   Private Sub CrearArchivoExportacion()
      Try

         Dim dt As DataTable = DirectCast(Me.ugdAsientos.DataSource, DataTable)

         'Me.chbTodos.Checked = True

         'For Each dr As dsAFIP.CitiVentasRow In dt.Rows
         '   dr.Proceso = Me.chbTodos.Checked
         'Next

         Me.Exportacion(dt)

      Catch ex As Exception
         Throw
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try


   End Sub

   Private Function GetCantidadRealSinAlicuota(filas As dsAFIP.CitiVentasAlicuotasDataTable,
                                      idTipoComprobante As String,
                                      letra As String,
                                      centroEmisor As Integer,
                                      numero As Long) As Decimal
      'realizo una validación sobre los cheques rechazados ya que tienen 2 alicuotas pero una esta en cero
      'por ello si el tipo de comprobante en ND y el importe y alicuota son 0 entonces

      Dim var As EnumerableRowCollection = From r In filas.AsEnumerable Select r
                                           Where r.IdTipoComprobante = idTipoComprobante And r.CentroEmisor = centroEmisor And r.NumeroComprobante = numero

      Dim ali As Decimal = 0

      For Each f As dsAFIP.CitiVentasAlicuotasRow In var
         If f.Alicuota = 0 And f.Importe = 0 Then
            ali += f.Neto
         End If
      Next

      Return ali

   End Function

   Private Function GetCantidadDeAlicuotas(filas As dsAFIP.CitiVentasAlicuotasDataTable,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numero As Long) As Integer
      Dim var As EnumerableRowCollection = From r In filas.AsEnumerable Select r
                                           Where r.IdTipoComprobante = idTipoComprobante And r.CentroEmisor = centroEmisor And r.NumeroComprobante = numero

      Dim ali As Integer = 0

      For Each f As dsAFIP.CitiVentasAlicuotasRow In var
         ali += 1
      Next

      Return ali

   End Function

   Private Sub ExportarDatos()

      Try
         If MessageBox.Show(String.Format("Realmente desea generar el archivo para los {0} movimientos?", Me._archi.Lineas.Count),
                                  Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

            Dim FechaExport As DateTime = Date.Now

            Dim export As ContabilidadExportacionCommon

            Select Case lblFormato.Text
               Case Reglas.ContabilidadPublicos.FormatoExportacion.SAE.ToString()
                  export = New ContabilidadExportacionSAE()
               Case Reglas.ContabilidadPublicos.FormatoExportacion.SAEv2.ToString()
                  export = New ContabilidadExportacionSAEv2()
               Case Else
                  Throw New Exception(String.Format("El formato de exportación '{0}' no es válido. Por favor verifique el formato de exportación configurado en Parámetros del Sistema.",
                                                    lblFormato.Text))
            End Select

            export.GrabarArchivo(Me.txtArchivoDestino.Text, _archi)

            Dim dtDatos As DataTable = DirectCast(Me.ugdAsientos.DataSource, DataTable)

            Dim Asientos As Reglas.ContabilidadAsientos = New Reglas.ContabilidadAsientos()

            Asientos.ActualizarFechaExportacion(dtDatos, FechaExport)

            MessageBox.Show(String.Format("Se Exportaron {0} movimientos EXITOSAMENTE !!!", Me._archi.Lineas.Count),
                            Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Me.btnConsultar.PerformClick()
            Me._publicosContabilidad.CargaComboFechasExportacion(cmbFechasExportacion)

         Else
            MessageBox.Show("Ha cancelado la exportación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         Throw
      End Try

   End Sub

   Private Sub Exportacion(ByVal dt As DataTable)
      Dim linea As ContabilidadExportacionArchivoLinea

      Me.tspBarra.Visible = True
      Me.tspBarra.Minimum = 0
      Me.tspBarra.Maximum = dt.Rows.Count
      Me.tspBarra.Value = 0

      For Each dr As DataRow In dt.Rows

         Me.tspBarra.Value = 1

         linea = New ContabilidadExportacionArchivoLinea()

         linea.IdPlanCuenta = Int32.Parse(dr(Entidades.ContabilidadAsiento.Columnas.IdPlanCuenta.ToString()).ToString())
         'COMPENSADO CON CEROS  A LA IZ  LONG  5 - Número correlativo
         linea.NroDeAsiento = Int32.Parse(dr(Entidades.ContabilidadAsiento.Columnas.IdAsiento.ToString()).ToString())
         'SEGÚN PLAN DE CUENTAS COLICITAR A MOR - Longitud    11
         linea.CuentaMayor = Long.Parse(dr("IdCuenta").ToString())
         'REFERENCIA DEL ASIENTO    - LONG    30
         linea.Concepto = dr(Entidades.ContabilidadAsiento.Columnas.NombreAsiento.ToString()).ToString()
         'SI LA OP. LO REQUIERE LONG  10
         Dim subCuenta As Long = 0
         If dr("CodigoReferencia").ToString().Length > 10 OrElse Not Long.TryParse(dr("CodigoReferencia").ToString(), subCuenta) Then subCuenta = 0
         linea.SubCuenta = subCuenta
         '1 DEBE 2 HABER      LONG   1
         If Decimal.Parse(dr("Debe").ToString()) <> 0 Then
            linea.DebeHaber = 1
            linea.Importe = Decimal.Parse(dr("Debe").ToString())
         Else
            linea.DebeHaber = 2
            linea.Importe = Decimal.Parse(dr("Haber").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("FechaExportacion").ToString()) Then
            linea.FechaExportacion = DateTime.Parse(dr("FechaExportacion").ToString())
         End If

         linea.FechaRegistro = DateTime.Parse(dr("FechaAsiento").ToString())

         If Not String.IsNullOrWhiteSpace(dr("IdAFIPTipoComprobante").ToString()) Then
            linea.CodigoComprobante = Integer.Parse(dr("IdAFIPTipoComprobante").ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("CentroEmisor").ToString()) Then
            linea.PuntoEmision = Integer.Parse(dr("CentroEmisor").ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("NumeroComprobante").ToString()) Then
            linea.NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("FechaComprobante").ToString()) Then
            linea.FechaComprobante = DateTime.Parse(dr("FechaComprobante").ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr("FechaVencimiento").ToString()) Then
            linea.FechaVencimiento = DateTime.Parse(dr("FechaVencimiento").ToString())
         End If


         Me._archi.Lineas.Add(linea)

      Next
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Fecha desde: {0:dd/MM/yyyy} - hasta: {1:dd/MM/yyyy}", dtpFechaDesde.Value, dtpFechaHasta.Value)
         If cmbPlan.SelectedIndex >= 0 Then
            .AppendFormat(" - Plan: {0}", cmbPlan.Text)
         End If
         If cmbAsientosExportados.SelectedIndex >= 0 Then
            .AppendFormat(" - Asientos Exportados:{0}", cmbAsientosExportados.Text)
         End If
         'If chkprocesos.CheckedItems.Count > 0 Then
         '   Dim sucs = String.Join(", ", chkprocesos.CheckedItems.OfType(Of Entidades.ContabilidadProceso.Procesos) _
         '                  .Select(Function(s) s.GetDescription()).ToArray())
         '   .AppendFormat(" - Procesos: {0}", sucs)
         'End If
         If chkprocesos.CheckedItems.Count > 0 Then
            Dim descripciones As New List(Of String)
            For Each item As KeyValuePair(Of Object, String) In chkprocesos.CheckedItems
               ' Agregar la descripción del valor seleccionado
               descripciones.Add(item.Value)
            Next

            Dim sucs = String.Join(", ", descripciones)
            .AppendFormat(" - Procesos: {0}", sucs)
         End If
      End With
      Return filtro.ToString()
   End Function

   Private Function InformoLaAlicuota(tipoComprobante As String,
                                      importeAlicuota As Decimal,
                                      importeTotal As Decimal) As Boolean
      'no lo informo si es NOta de Debito y tiene el importe de la alicuota en cero y el importe total en cero
      If (tipoComprobante.Contains("eNDEB") Or tipoComprobante.Contains("NDEBCHEQRECH")) And
         importeAlicuota = 0 And
         importeTotal = 0 Then
         Return False
      End If

      Return True
   End Function

#End Region
#Region "Eventos Toolbar"
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugdAsientos.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugdAsientos.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugdAsientos.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
#End Region
   Private Sub cmbAsientosExportados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAsientosExportados.SelectedIndexChanged
      Try
         If Me.cmbAsientosExportados.SelectedIndex = 1 Then
            Me.cmbFechasExportacion.Visible = True
         Else
            Me.cmbFechasExportacion.Visible = False
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor

         For i As Integer = 0 To chkprocesos.Items.Count - 1
            chkprocesos.SetItemChecked(i, chbTodos.Checked)
         Next

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
End Class