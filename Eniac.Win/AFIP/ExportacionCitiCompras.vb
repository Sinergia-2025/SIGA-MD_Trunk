#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports System.Data
Imports System.IO
Imports Eniac.Entidades
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridColumn
#End Region
Public Class ExportacionCitiCompras

#Region "Campos"

   Private _publicos As Publicos
   Private _citi As CitiCompras
   Private _citiAlicuotas As CitiComprasAlicuotas
   Private _citiComprasDespachoImportacion As CitiComprasDespachoImportacion

   Private _titComprobantes As Dictionary(Of String, String)
   Private _titAlicuotas As Dictionary(Of String, String)
   Private _titDespacho As Dictionary(Of String, String)
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.dtpPeriodoFiscal.Value = DateTime.Today

         TabControl1.SelectedTab = TbpComprobantes
         _titComprobantes = GetColumnasVisiblesGrilla(ugDetalle)
         ugDetalle.AgregarTotalesSuma({"ImporteBruto", "Neto", "Importe", "Percepciones", "Total", "ImpuestosInternos"})
         ugDetalle.AgregarFiltroEnLinea({"NombreProveedor"})

         TabControl1.SelectedTab = tbpAlicuotas
         _titAlicuotas = GetColumnasVisiblesGrilla(ugAlicuotas)
         ugAlicuotas.AgregarTotalesSuma({"Importe", "Neto", "Percepciones", "Total"})
         ugAlicuotas.AgregarFiltroEnLinea({})


         TabControl1.SelectedTab = tbpDespachoImportacion
         _titDespacho = GetColumnasVisiblesGrilla(ugDespachoImportacion)
         ugDespachoImportacion.AgregarTotalesSuma({"Bruto", "ImporteImpuesto", "Total"})
         ugDespachoImportacion.AgregarFiltroEnLinea({})

         TabControl1.SelectedTab = TbpComprobantes


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbVerRegistrosConErrores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbVerRegistrosConErrores.Click
      Try
         If TypeOf (ugDetalle.DataSource) Is dsAFIP.CitiComprasDataTable Then
            Dim dt As dsAFIP.CitiComprasDataTable = DirectCast(Me.ugDetalle.DataSource, dsAFIP.CitiComprasDataTable)
            Dim dtErro As dsAFIP.CitiComprasDataTable = New dsAFIP.CitiComprasDataTable()
            Dim drErro As dsAFIP.CitiComprasRow
            For Each dr As dsAFIP.CitiComprasRow In dt.Rows
               If Not String.IsNullOrEmpty(dr.TipoError) Then
                  drErro = dtErro.NewCitiComprasRow()
                  drErro.ItemArray = dr.ItemArray
                  dtErro.Rows.Add(drErro)
               End If
            Next

            Dim cg As ConsultaGenerica = New ConsultaGenerica(dtErro)
            cg.Show()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged
      Try
         If TypeOf (ugDetalle.DataSource) Is dsAFIP.CitiComprasDataTable Then
            Dim dt As dsAFIP.CitiComprasDataTable = DirectCast(ugDetalle.DataSource, dsAFIP.CitiComprasDataTable)
            For Each dr As dsAFIP.CitiComprasRow In dt.Rows
               If String.IsNullOrEmpty(dr.TipoError) And Not dr.EstaAnulada Then
                  dr.Proceso = Me.chbTodos.Checked
               End If
            Next

            Dim dt2 As dsAFIP.CitiComprasAlicuotasDataTable = DirectCast(ugAlicuotas.DataSource, dsAFIP.CitiComprasAlicuotasDataTable)
            For Each dr2 As dsAFIP.CitiComprasAlicuotasRow In dt2.Rows
               If String.IsNullOrEmpty(dr2.TipoError) Then
                  dr2.Proceso = Me.chbTodos.Checked
               End If
            Next

            Dim dt3 As dsAFIP.CitiComprasDespachoImportacionDataTable = DirectCast(ugDespachoImportacion.DataSource, dsAFIP.CitiComprasDespachoImportacionDataTable)
            For Each dr3 As dsAFIP.CitiComprasDespachoImportacionRow In dt3.Rows
               If String.IsNullOrEmpty(dr3.TipoError) Then
                  dr3.Proceso = Me.chbTodos.Checked
               End If
            Next
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ExportacionCitiCompras_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = "0 Registros"

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExportar.Click

      Try

         If ugDetalle.Rows.Count = 0 Then Exit Sub

         If Me.txtArchivoDestinoComprobantes.Text.Trim() = "" Then
            MessageBox.Show("No Indico el Archivo Destino.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtArchivoDestinoComprobantes.Focus()
            Exit Sub
         End If

         'If Me.dtpDesde.Value.Month <> Me.dtpHasta.Value.Month Or Me.dtpDesde.Value.Year <> Me.dtpHasta.Value.Year Then
         '   MessageBox.Show("No puede exportar informacion de destintos meses.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.dtpDesde.Focus()
         '   Exit Sub
         'End If

         Me.Cursor = Cursors.WaitCursor

         Me.ExportarDatos()

         CerrarPeriodoFiscal()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
            Me.chbTodos.Enabled = True
            Me.tsbExportar.Enabled = True
         Else
            Me.tsbExportar.Enabled = False
            Me.chbTodos.Enabled = False
            MessageBox.Show("No hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub btnExaminarComprobantes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminarComprobantes.Click

      Dim DialogoGuardarArchivo As New SaveFileDialog()

      DialogoGuardarArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoGuardarArchivo.Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*"
      DialogoGuardarArchivo.FilterIndex = 1
      DialogoGuardarArchivo.RestoreDirectory = True
      DialogoGuardarArchivo.FileName = "CitiCompras_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"

      If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            If DialogoGuardarArchivo.FileName <> "" Then

               Me.txtArchivoDestinoComprobantes.Text = DialogoGuardarArchivo.FileName

            End If

         Catch Ex As Exception

            MessageBox.Show(Ex.Message)

         End Try

      End If

   End Sub

   Private Sub btnExaminarAlicuotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminarAlicuotas.Click

      Dim DialogoGuardarArchivo As New SaveFileDialog()

      DialogoGuardarArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoGuardarArchivo.Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*"
      DialogoGuardarArchivo.FilterIndex = 1
      DialogoGuardarArchivo.RestoreDirectory = True
      DialogoGuardarArchivo.FileName = "CitiComprasAlicuotas_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"

      If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            If DialogoGuardarArchivo.FileName <> "" Then

               Me.txtArchivoDestinoAlicuotas.Text = DialogoGuardarArchivo.FileName

               'If System.IO.File.Exists(Me.txtArchivoDestinoAlicuotas.Text.Trim()) Then
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

   Private Sub dtpPeriodoFiscal_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodoFiscal.ValueChanged
      dtpPeriodoFiscal.Value = dtpPeriodoFiscal.Value.PrimerDiaMes()
   End Sub


   Private Sub ugDetalle_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      Try
         If e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
            TypeOf (DirectCast(e.Row.ListObject, DataRowView).Row) Is dsAFIP.CitiComprasRow Then
            Dim dr As dsAFIP.CitiComprasRow = DirectCast(DirectCast(e.Row.ListObject, DataRowView).Row, dsAFIP.CitiComprasRow)
            If String.IsNullOrWhiteSpace(dr.TipoError) Then
               e.Row.Appearance.BackColor = Nothing
               e.Row.Cells("Proceso").Activation = UltraWinGrid.Activation.AllowEdit
            Else
               e.Row.Appearance.BackColor = Color.LightSalmon
               e.Row.Cells("Proceso").Activation = UltraWinGrid.Activation.NoEdit
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalleAlicuotas_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles ugAlicuotas.InitializeRow
      Try
         If e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
            TypeOf (DirectCast(e.Row.ListObject, DataRowView).Row) Is dsAFIP.CitiComprasAlicuotasRow Then
            Dim dr As dsAFIP.CitiComprasAlicuotasRow = DirectCast(DirectCast(e.Row.ListObject, DataRowView).Row, dsAFIP.CitiComprasAlicuotasRow)
            If String.IsNullOrWhiteSpace(dr.TipoError) Then
               e.Row.Appearance.BackColor = Nothing
               e.Row.Cells("Proceso").Activation = UltraWinGrid.Activation.AllowEdit
            Else
               e.Row.Appearance.BackColor = Color.LightSalmon
               e.Row.Cells("Proceso").Activation = UltraWinGrid.Activation.NoEdit
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      Me.dtpPeriodoFiscal.Value = DateTime.Today

      If TypeOf (ugDetalle.DataSource) Is DataTable Then
         DirectCast(ugDetalle.DataSource, DataTable).Rows.Clear()
      End If
      If TypeOf (ugAlicuotas.DataSource) Is DataTable Then
         DirectCast(ugAlicuotas.DataSource, DataTable).Rows.Clear()
      End If
      If TypeOf (ugDespachoImportacion.DataSource) Is DataTable Then
         DirectCast(ugDespachoImportacion.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtArchivoDestinoComprobantes.Text = ""
      Me.txtArchivoDestinoAlicuotas.Text = ""
      Me.txtArchivoDespacho.Text = ""

      Me.tsbExportar.Enabled = False
      Me.tsbVerRegistrosConErrores.Enabled = False

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oCompras As Reglas.Compras = New Reglas.Compras()

      'Dim decTotalNeto As Decimal = 0
      'Dim decSubTotal As Decimal = 0
      'Dim decTotalImpuestos As Decimal = 0
      'Dim decTotal As Decimal = 0

      Try

         Dim existeAlgunDespacho As Boolean = False

         Dim dtDetalle As DataTable
         Dim dt As dsAFIP.CitiComprasDataTable = New dsAFIP.CitiComprasDataTable()
         Dim drCl As dsAFIP.CitiComprasRow

         dtDetalle = oCompras.GetParaExportarAFIP(actual.Sucursal.IdEmpresa, Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM")))

         Me.tsbVerRegistrosConErrores.Enabled = False

         Dim linea As Integer = 1

         For Each dr As DataRow In dtDetalle.Rows
            drCl = dt.NewCitiComprasRow()

            drCl.Linea = linea
            drCl.Proceso = False
            drCl.IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
            drCl.IdTipoComprobante = dr("IdTipoComprobante").ToString()
            drCl.DescripcionAbrev = dr("DescripcionAbrev").ToString()
            drCl.Letra = dr("Letra").ToString()
            drCl.CentroEmisor = Integer.Parse(dr("CentroEmisor").ToString())
            drCl.NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
            drCl.Fecha = Date.Parse(dr("Fecha").ToString())

            If Not String.IsNullOrEmpty(dr("TipoDocProveedor").ToString()) Then
               drCl.TipoDocProveedor = dr("TipoDocProveedor").ToString()
               drCl.NroDocProveedor = Long.Parse(dr("NroDocProveedor").ToString())
            Else
               drCl.TipoDocProveedor = ""
               drCl.NroDocProveedor = 0
            End If

            drCl.NombreCategoriaFiscal = dr("NombreCategoriaFiscal").ToString()

            drCl.CUIT = dr("CuitProveedor").ToString()
            drCl.NombreProveedor = dr("NombreProveedor").ToString()

            If Not String.IsNullOrEmpty(dr("IdAFIPTipoComprobante").ToString()) Then
               drCl.IdAFIPTipoComprobante = Int32.Parse(dr("IdAFIPTipoComprobante").ToString())
            Else
               drCl.IdAFIPTipoComprobante = 0
            End If

            If Not String.IsNullOrEmpty(dr("IdAFIPTipoDocumento").ToString()) Then
               drCl.IdAFIPTipoDocumento = Int32.Parse(dr("IdAFIPTipoDocumento").ToString())
            Else
               drCl.IdAFIPTipoDocumento = 0
            End If

            drCl.CantidadDeAlicuotas = 0

            drCl.EsDespachoImportacion = Boolean.Parse(dr("EsDespachoImportacion").ToString())

            drCl.NumeroDespachoCompleto = dr("NumeroDespachoCompleto").ToString()

            If drCl.EsDespachoImportacion Then
               existeAlgunDespacho = True
            End If

            If drCl.Letra = "A" Or drCl.Letra = "B" Or drCl.Letra = "M" Or drCl.Letra = "X" Or drCl.EsDespachoImportacion Then
               drCl.CantidadDeAlicuotas = Integer.Parse(dr("CantidadAlicuotas").ToString())
            Else
               '"C"
               drCl.CantidadDeAlicuotas = 0
            End If


            drCl.PGANA = Decimal.Parse(dr("PercepcionGanancias").ToString())
            drCl.PIIBB = Decimal.Parse(dr("PercepcionIB").ToString())
            drCl.PIVA = Decimal.Parse(dr("PercepcionIVA").ToString())
            drCl.PVAR = Decimal.Parse(dr("PercepcionVarias").ToString())
            drCl.ImpuestosInternos = Decimal.Parse(dr("ImpuestosInternos").ToString())

            drCl.Importe = Decimal.Parse(dr("TotalImporteImpuesto").ToString())
            drCl.Percepciones = drCl.PGANA + drCl.PIIBB + drCl.PIVA + drCl.PVAR

            If dr("IdEstadoComprobante").ToString() <> "ANULADO" Then
               drCl.NombreProveedor = dr("NombreProveedor").ToString()
               drCl.EstaAnulada = False
               drCl.ImporteBruto = Decimal.Parse(dr("TotalBruto").ToString())
               drCl.Neto = Decimal.Parse(dr("TotalBaseImponible").ToString())
               drCl.NetoNoGravado = Decimal.Parse(dr("TotalNoGrabado").ToString())
               'drCl.Importe = Decimal.Parse(dr("Importe").ToString())
               drCl.Total = Decimal.Parse(dr("ImporteTotal").ToString())
               ' drCl.Alicuota = Decimal.Parse(dr("Alicuota").ToString())

            Else
               drCl.NombreProveedor = "** COMPROBANTE ANULADO **"
               drCl.EstaAnulada = True
               drCl.ImporteBruto = 0
               drCl.Importe = 0
               drCl.Total = 0
            End If

            drCl.TotalImporteImpuesto = Decimal.Parse(dr("TotalImporteImpuesto").ToString())

            If drCl.EsDespachoImportacion Then
               drCl.Total += Decimal.Parse(dr("BaseImponibleDespachoImportacion").ToString())
            End If

            dt.Rows.Add(drCl)

            linea += 1
         Next

         ugDetalle.DataSource = dt
         AjustarColumnasGrilla(ugDetalle, _titComprobantes)

         'If Me.chkMesCompleto.Checked Then
         Me.txtArchivoDestinoComprobantes.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\CitiCompras_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"
         Me.txtArchivoDestinoAlicuotas.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\CitiComprasAlicuotas_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"
         Me.txtArchivoDespacho.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\CitiComprasDespacho_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"
         'Else
         'Me.txtArchivoDestino.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\CitiCompras_" & Me.dtpDesde.Value.ToString("yyyyMMdd") & "_" & Me.dtpHasta.Value.ToString("yyyyMMdd") & ".txt"
         'Me.txtArchivoDestinoAlicuotas.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\CitiComprasAlicuotas_" & Me.dtpDesde.Value.ToString("yyyyMMdd") & "_" & Me.dtpHasta.Value.ToString("yyyyMMdd") & ".txt"
         'End If

         'Alicuotas-----------------------------------------------------------------------------------------------------------------------------
         Dim dtDetalleAlicuotas As DataTable
         Dim dt1 As dsAFIP.CitiComprasAlicuotasDataTable = New dsAFIP.CitiComprasAlicuotasDataTable()
         Dim drCl1 As dsAFIP.CitiComprasAlicuotasRow

         dtDetalleAlicuotas = oCompras.GetParaExportarAFIPAlicuotas(actual.Sucursal.IdEmpresa, Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM")))

         Dim linea1 As Integer = 1

         For Each dr1 As DataRow In dtDetalleAlicuotas.Rows
            If dr1("IdTipoComprobante").ToString() <> "DESPACHOIMP" Then
               drCl1 = dt1.NewCitiComprasAlicuotasRow()
               drCl1.Linea = linea1
               drCl1.Proceso = False
               drCl1.IdSucursal = Integer.Parse(dr1("IdSucursal").ToString())
               drCl1.IdTipoComprobante = dr1("IdTipoComprobante").ToString()
               drCl1.DescripcionAbrev = dr1("DescripcionAbrev").ToString()
               drCl1.Letra = dr1("Letra").ToString()
               drCl1.CentroEmisor = Integer.Parse(dr1("CentroEmisor").ToString())
               drCl1.NumeroComprobante = Long.Parse(dr1("NumeroComprobante").ToString())

               If Not String.IsNullOrEmpty(dr1("TipoDocProveedor").ToString()) Then
                  drCl1.TipoDocCliente = dr1("TipoDocProveedor").ToString()
                  drCl1.NroDocCliente = Long.Parse(dr1("NroDocProveedor").ToString())
               Else
                  drCl1.TipoDocCliente = ""
                  drCl1.NroDocCliente = 0
               End If

               drCl1.CUIT = dr1("CuitProveedor").ToString()

               drCl1.Alicuota = Decimal.Parse(dr1("Alicuota").ToString()) ' 21
               drCl1.IdAFIPIVA = dr1.ValorNumericoPorDefecto("CodigoAlicuota", -1) ' 5

               drCl1.Neto = Decimal.Parse(dr1("BaseImponible").ToString()) * Decimal.Parse(dr1("CoeficienteValores").ToString())

               drCl1.Importe = Decimal.Parse(dr1("ImporteImpuesto").ToString()) * Decimal.Parse(dr1("CoeficienteValores").ToString())

               drCl1.Total = drCl1.Neto + drCl1.Importe

               If Not String.IsNullOrEmpty(dr1("IdAFIPTipoComprobante").ToString()) Then
                  drCl1.IdAFIPTipoComprobante = Int32.Parse(dr1("IdAFIPTipoComprobante").ToString())
               Else
                  drCl1.IdAFIPTipoComprobante = 0
               End If
               If Not String.IsNullOrEmpty(dr1("IdAFIPTipoDocumento").ToString()) Then
                  drCl1.IdAFIPTipoDocumento = Int32.Parse(dr1("IdAFIPTipoDocumento").ToString())
               Else
                  drCl1.IdAFIPTipoDocumento = 0
               End If


               dt1.Rows.Add(drCl1)

               linea1 += 1
            End If
         Next

         ugAlicuotas.DataSource = dt1
         AjustarColumnasGrilla(ugAlicuotas, _titAlicuotas)

         '---------------------------------------------------Despacho Importacion------------------------------------------------------

         Dim dtDetDespacho As DataTable
         Dim dt2 As dsAFIP.CitiComprasDespachoImportacionDataTable
         Dim drCl2 As dsAFIP.CitiComprasDespachoImportacionRow

         dtDetDespacho = oCompras.GetParaExportarAFIPDespachoImportacion(actual.Sucursal.IdEmpresa, Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM")))
         dt2 = New dsAFIP.CitiComprasDespachoImportacionDataTable() ' Me.CrearDT()
         Dim linea2 As Integer = 1

         For Each dr2 As DataRow In dtDetDespacho.Rows

            drCl2 = dt2.NewCitiComprasDespachoImportacionRow()

            drCl2.Linea = linea2
            drCl2.Proceso = False
            drCl2.IdSucursal = Integer.Parse(dr2("IdSucursal").ToString())
            drCl2.IdTipoComprobante = dr2("IdTipoComprobante").ToString()
            drCl2.DescripcionAbrev = dr2("DescripcionAbrev").ToString()
            'drCl2("IdAduana") = dr2("IdAduana").ToString()
            'drCl2("IdDestinacion") = dr2("IdDestinacion").ToString()
            drCl2.Letra = dr2("Letra").ToString()
            drCl2.CentroEmisor = Integer.Parse(dr2("CentroEmisor").ToString())
            drCl2.NumeroComprobante = Long.Parse(dr2("NumeroComprobante").ToString())
            drCl2.NumeroDespachoCompleto = dr2("NumeroDespachoCompleto").ToString()

            drCl2.Alicuota = Decimal.Parse(dr2("Alicuota").ToString()) ' 21
            drCl2.IdAFIPIVA = Integer.Parse(dr2("CodigoAlicuota").ToString()) ' 5
            drCl2.BaseImponible = Decimal.Parse(dr2("BaseImponible").ToString())
            drCl2.ImporteImpuesto = Decimal.Parse(dr2("ImporteImpuesto").ToString())
            drCl2.Total = Decimal.Parse(dr2("BaseImponible").ToString()) + Decimal.Parse(dr2("ImporteImpuesto").ToString())


            If Not String.IsNullOrEmpty(dr2("IdAFIPTipoComprobante").ToString()) Then
               drCl2.IdAFIPTipoComprobante = Integer.Parse(dr2("IdAFIPTipoComprobante").ToString())
            Else
               drCl2.IdAFIPTipoComprobante = 0
            End If
            If Not String.IsNullOrEmpty(dr2("IdAFIPTipoDocumento").ToString()) Then
               drCl2.IdAFIPTipoDocumento = Integer.Parse(dr2("IdAFIPTipoDocumento").ToString())
            Else
               drCl2.IdAFIPTipoDocumento = 0
            End If
            'drCl2("DigitoVerificadorDespacho") = dr2("DigitoVerificadorDespacho").ToString()

            'drCl2("FechaOficializacionDespacho") = Date.Parse(dr2("FechaOficializacionDespacho").ToString()).ToString("dd/MM/yyyy")

            dt2.Rows.Add(drCl2)

            linea2 += 1

         Next

         ugDespachoImportacion.DataSource = dt2
         'AjustarColumnasGrilla(ugDespachoImportacion, _titDespacho)

         If existeAlgunDespacho Then
            If Not TabControl1.TabPages.Contains(tbpDespachoImportacion) Then
               TabControl1.TabPages.Add(tbpDespachoImportacion)
            End If
            ugDetalle.DisplayLayout.Bands(0).Columns("NumeroDespachoCompleto").Hidden = False
         Else
            If TabControl1.TabPages.Contains(tbpDespachoImportacion) Then
               TabControl1.TabPages.Remove(tbpDespachoImportacion)
            End If
            ugDetalle.DisplayLayout.Bands(0).Columns("NumeroDespachoCompleto").Hidden = True
         End If

         '-----------------------------------------------------------------------------------------------------------------------------

         Me.CrearCitiCompras()

         Me.tssRegistros.Text = dt.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CrearCitiCompras()
      Try

         If Not TypeOf (ugDetalle.DataSource) Is dsAFIP.CitiComprasDataTable Then Exit Sub
         If Not TypeOf (ugAlicuotas.DataSource) Is dsAFIP.CitiComprasAlicuotasDataTable Then Exit Sub

         Me._citi = New CitiCompras()
         Me._citiAlicuotas = New CitiComprasAlicuotas()
         Me._citiComprasDespachoImportacion = New CitiComprasDespachoImportacion()

         Dim dt As dsAFIP.CitiComprasDataTable = DirectCast(ugDetalle.DataSource, dsAFIP.CitiComprasDataTable)
         Dim dt2 As dsAFIP.CitiComprasAlicuotasDataTable = DirectCast(ugAlicuotas.DataSource, dsAFIP.CitiComprasAlicuotasDataTable)
         Dim dt3 As dsAFIP.CitiComprasDespachoImportacionDataTable = DirectCast(ugDespachoImportacion.DataSource, dsAFIP.CitiComprasDespachoImportacionDataTable)

         Me.chbTodos.Checked = True

         For Each dr As dsAFIP.CitiComprasRow In dt.Rows
            dr.Proceso = Me.chbTodos.Checked
         Next

         For Each dr1 As dsAFIP.CitiComprasAlicuotasRow In dt2.Rows
            dr1.Proceso = Me.chbTodos.Checked
         Next

         For Each dr As dsAFIP.CitiComprasDespachoImportacionRow In dt3.Rows
            dr.Proceso = Me.chbTodos.Checked
         Next

         Me.CitiCompras(dt)
         Me.CitiComprasAlicuotas(dt2)
         Me.CitiComprasDespachoImportacion(dt3)

      Catch ex As Exception
         Throw
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try


   End Sub

   Private Sub ExportarDatos()

      Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()
      If Not TypeOf (ugDetalle.DataSource) Is DataTable Then Exit Sub
      If Not TypeOf (ugAlicuotas.DataSource) Is DataTable Then Exit Sub
      If Not TypeOf (ugDespachoImportacion.DataSource) Is DataTable Then Exit Sub

      For Each li As CitiComprasLinea In Me._citi.Lineas
         For Each dgv As DataRow In DirectCast(ugDetalle.DataSource, DataTable).Rows
            If li.Linea = Long.Parse(dgv("Linea").ToString()) Then
               li.Procesar = (dgv("Proceso").ToString() = "True")
               Exit For
            End If
         Next
      Next

      stb.AppendFormat("Realmente desea generar el archivo para los {0} comprobantes?", Me._citi.CantidadDeLineasaProcesar)

      If MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
         Me._citi.GrabarArchivo(Me.txtArchivoDestinoComprobantes.Text)
         MessageBox.Show("Se Exportaron " & Me._citi.CantidadDeLineasaProcesar.ToString() & " comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Else
         MessageBox.Show("Ha cancelado la exportación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

      Dim stb1 As System.Text.StringBuilder = New System.Text.StringBuilder()

      For Each li As CitiComprasAlicuotasLinea In Me._citiAlicuotas.Lineas
         For Each dgv As DataRow In DirectCast(ugAlicuotas.DataSource, DataTable).Rows
            If li.Linea = Long.Parse(dgv("Linea").ToString()) Then
               li.Procesar = (dgv("Proceso").ToString() = "True")
               Exit For
            End If
         Next
      Next

      stb1.AppendFormat("Realmente desea generar el archivo para los {0} Comprobantes Alicuotas?", Me._citiAlicuotas.CantidadDeLineasaProcesar)

      If MessageBox.Show(stb1.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
         Me._citiAlicuotas.GrabarArchivo(Me.txtArchivoDestinoAlicuotas.Text)
         MessageBox.Show("Se Exportaron " & Me._citiAlicuotas.CantidadDeLineasaProcesar.ToString() & " comprobantes Alicuotas EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Else
         MessageBox.Show("Ha cancelado la exportación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

      '---------------------------------------------------------------------------------------------------

      If ugDespachoImportacion.Rows.Count > 0 Then
         Dim stb2 As System.Text.StringBuilder = New System.Text.StringBuilder()

         For Each li As CitiComprasDespachoImportacionLinea In Me._citiComprasDespachoImportacion.Lineas
            For Each dgv As DataRow In DirectCast(ugDespachoImportacion.DataSource, DataTable).Rows
               If li.Linea = Long.Parse(dgv("Linea").ToString()) Then
                  li.Procesar = (dgv("Proceso").ToString() = "True")
                  Exit For
               End If
            Next
         Next

         stb2.AppendFormat("Realmente desea generar el archivo para los {0} Comprobantes Despacho de Importación?", Me._citiComprasDespachoImportacion.CantidadDeLineasaProcesar)

         If MessageBox.Show(stb2.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me._citiComprasDespachoImportacion.GrabarArchivo(Me.txtArchivoDespacho.Text)
            MessageBox.Show("Se Exportaron " & Me._citiComprasDespachoImportacion.CantidadDeLineasaProcesar.ToString() & " Comprobantes Despacho de Importación EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Else
            MessageBox.Show("Ha cancelado la exportación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End If

   End Sub
   Private Sub CerrarPeriodoFiscal()
      Try
         Dim rPeriodoFiscal As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales
         Dim oPeriodoFiscal As Entidades.PeriodoFiscal

         oPeriodoFiscal = rPeriodoFiscal.GetUno(actual.Sucursal.IdEmpresa, Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM")))

         If oPeriodoFiscal IsNot Nothing Then
            With oPeriodoFiscal
               .UsuarioCierre = actual.Nombre
               .FechaCierre = Date.Now
            End With
            rPeriodoFiscal.Actualizar(oPeriodoFiscal)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub CitiCompras(ByVal dt As DataTable)
      Dim linea As CitiComprasLinea

      Me.tspBarra.Visible = True
      Me.tspBarra.Minimum = 0
      Me.tspBarra.Maximum = dt.Rows.Count
      Me.tspBarra.Value = 0

      For Each dr As dsAFIP.CitiComprasRow In dt.Rows

         Me.tspBarra.Value = dr.Linea - 1
         'si esta anulada paso al proximo registro y no lo genero
         If dr.EstaAnulada Then
            dr.Proceso = False
            Continue For
         End If
         If Not dr.Proceso Then
            Continue For
         End If

         linea = New CitiComprasLinea()

         linea.Linea = dr.Linea



         '01 - desde 001 hasta 008 / Númerico / Tam = 8 / Observaciones = Fto. AAAAMMDD
         linea.FechaDelComprobante = dr.Fecha
         '02 - desde 009 hasta 011 / Númerico / Tam = 3 / Observaciones = Según tabla de comprobantes
         linea.TipoDeComprobante = dr.IdAFIPTipoComprobante

         '03 - desde 012 hasta 016 / Númerico / Tam = 5 / Observaciones = 
         If linea.TipoDeComprobante = 99 Or dr.EsDespachoImportacion Then
            'pongo fijo el cero ya que los tipos de comprobantes de este tipo son de Resumenes Bancarios.
            'esto fue planteado por la contador de BBP Amoblamientos
            linea.PuntoDeVenta = 0
         Else
            linea.PuntoDeVenta = dr.CentroEmisor
         End If
         '04 - desde 017 hasta 036 / Númerico / Tam = 20 / Observaciones = 
         If dr.EsDespachoImportacion Then
            linea.NroDeComprobante = 0
         Else
            linea.NroDeComprobante = dr.NumeroComprobante
         End If

         '05 - desde 037 hasta 052 / AlfaNúmerico / Tam = 16 / Observaciones = 
         If dr.EsDespachoImportacion Then
            linea.NroDespachoDeImportacion = dr.NumeroDespachoCompleto
         Else
            linea.NroDespachoDeImportacion = ""
         End If
         '06 - desde 053 hasta 054 / Númerico / Tam = 2 / Observaciones = Según tabla de documentos
         If String.IsNullOrEmpty(dr.CUIT) Then
            linea.CodigoDeDocumentoIdentificatorioDelComprador = dr.IdAFIPTipoDocumento
         Else
            linea.CodigoDeDocumentoIdentificatorioDelComprador = 80
         End If
         '07 - desde 055 hasta 074 / AlfaNúmerico / Tam = 20 / Observaciones = 
         If String.IsNullOrEmpty(dr.CUIT) Then
            linea.NroDeIdentificacionDelComprador = dr.NroDocProveedor
         Else
            linea.NroDeIdentificacionDelComprador = Long.Parse(dr.CUIT.Replace("-"c, ""))
         End If
         '08 - desde 075 hasta 104 / AlfaNúmerico / Tam = 30 / Observaciones = 
         linea.ApellidoYNombreODenominacionDelComprador = dr.NombreProveedor
         '09 - desde 105 hasta 119 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         linea.ImporteTotalDeLaOperacion = dr.Total
         '10 - desde 120 hasta 134 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         linea.TotalDeConceptosQueNoIntegranElPrecioNeto = 0
         '11 - desde 135 hasta 149 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         If dr.CantidadDeAlicuotas = 0 Then
            If dr.Letra = "A" Then 'EL CAMPO IMPORTE OPERACIONES EXENTAS DEBE SER IGUAL A CERO CUANDO SON CPTES. B O C
               linea.ImporteDeOperacionesExentas = dr.ImporteBruto
            End If
         End If
         '12 - desde 150 hasta 164 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDePercepcionesOPagosACtaDelIVA = dr.PIVA
         '13 - desde 165 hasta 179 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDePercepOPagosACtaDeImpuestoNac = dr.PGANA
         '14 - desde 180 hasta 194 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDePercepcionesDeIngresosBrutos = dr.PIIBB
         '15 - desde 195 hasta 209 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDePercepcionesDeImpuestosMunicipales = dr.PVAR
         '16 - desde 210 hasta 224 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDeImpuestosInternos = dr.ImpuestosInternos
         '17 - desde 225 hasta 227 / Alfabetico / Tam = 3 / Observaciones =  Según tabla Monedas
         linea.CodigoDeMoneda = "PES"
         '18 - desde 228 hasta 237 / Númerico / Tam = 10 / Observaciones =  4 enteros 6 decimales sin punto decimal
         linea.TipoDeCambio = 1
         '19 - desde 238 hasta 238 / Númerico / Tam = 1 / Observaciones = 
         linea.CantidadDeAlicuotasDeIVA = dr.CantidadDeAlicuotas
         '20 - desde 239 hasta 239 / Alfabetico / Tam = 1 / Observaciones =   Según tabla Codigo_Operación, de No Corresponder v
         If dr.NombreCategoriaFiscal = "Exento" And dr.CantidadDeAlicuotas = 0 Then
            linea.CodigoDeOperacion = "E"
         Else
            If dr.NetoNoGravado <> 0 And dr.CantidadDeAlicuotas <> 0 Then
               linea.CodigoDeOperacion = "E"
            Else
               linea.CodigoDeOperacion = "0"
            End If
         End If
         '21 - desde 240 hasta 254 / Númerico / Tam = 15 / Observaciones = 
         linea.CreditoFiscalComputable = 0
         If Reglas.Publicos.AFIPCitiComprasProrrateo <> EnumAfip.ProrrateoCitiCompras.SI_GLOBAL Then
            linea.CreditoFiscalComputable = dr.TotalImporteImpuesto
         End If
         '22 - desde 255 hasta 269 / Númerico / Tam = 15 / Observaciones = 
         linea.OtrosTributos = 0
         '23 - desde 270 hasta 280 / Númerico / Tam = 11 / Observaciones =  
         linea.CuitEmisor = 0
         '24 - desde 281 hasta 310 / AlfaNúmerico / Tam = 30 / Observaciones =  
         linea.DenominacionDelEmisorCorredor = ""
         '25 - desde 311 hasta 325 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.IvaComision = 0

         Me._citi.Lineas.Add(linea)

         If linea.TieneError Then
            Me.tsbVerRegistrosConErrores.Enabled = True
            Dim drCol As DataRow() = DirectCast(ugDetalle.DataSource, DataTable).Select(String.Format("Linea = {0}", linea.Linea))
            If drCol.Length > 0 Then
               drCol(0)("TipoError") = linea.TipoError
            End If

            dr.Proceso = False
         End If
         'para cada linea le digo si la procesa cuando va a grabar el archivo o no.
         linea.Procesar = dr.Proceso
      Next
   End Sub

   Private Sub CitiComprasAlicuotas(ByVal dt As DataTable)

      Dim linea As CitiComprasAlicuotasLinea


      For Each dr As dsAFIP.CitiComprasAlicuotasRow In dt.Rows


         linea = New CitiComprasAlicuotasLinea()

         linea.Linea = dr.Linea

         '01 - desde 001 hasta 003 / Númerico / Tam = 3 / Observaciones = Según tabla de comprobantes
         linea.TipoDeComprobante = dr.IdAFIPTipoComprobante

         '02 - desde 004 hasta 008 / Númerico / Tam = 5 / Observaciones = 
         If linea.TipoDeComprobante = 99 Then
            'pongo fijo el cero ya que los tipos de comprobantes de este tipo son de Resumenes Bancarios.
            'esto fue planteado por la contador de BBP Amoblamientos
            linea.PuntoDeVenta = 0
         Else
            linea.PuntoDeVenta = dr.CentroEmisor
         End If

         '03 - desde 009 hasta 028 / Númerico / Tam = 20 / Observaciones = 
         linea.NroDeComprobante = dr.NumeroComprobante
         '04 - desde 029 hasta 030 / Númerico / Tam = 2 / Observaciones =  Segun tabla Documentos

         If String.IsNullOrEmpty(dr.CUIT) Then
            linea.CodigoDeDocumentoIdentificatorioDelVendedor = dr.IdAFIPTipoDocumento
         Else
            linea.CodigoDeDocumentoIdentificatorioDelVendedor = 80
         End If
         '05 - desde 031 hasta 050 / AlfaNúmerico / Tam = 20 / Observaciones =  
         If String.IsNullOrEmpty(dr.CUIT) Then
            linea.NroDeIdentificacionDelVendedor = dr.NroDocCliente
         Else
            linea.NroDeIdentificacionDelVendedor = Long.Parse(dr.CUIT.Replace("-"c, ""))
         End If
         '06 - desde 051 hasta 065 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         linea.ImporteNetoGravado = dr.Neto
         '07 - desde 066 hasta 069 / Númerico / Tam = 4 / Observaciones =  Según tabla Alícuotas
         linea.AlicuotaDeIVA = dr.IdAFIPIVA
         '08 - desde 070 hasta 084 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImpuestoLiquidado = dr.Importe

         Me._citiAlicuotas.Lineas.Add(linea)

         If linea.TieneError Then
            Me.tsbVerRegistrosConErrores.Enabled = True
            Dim drCol As DataRow() = DirectCast(ugAlicuotas.DataSource, DataTable).Select(String.Format("Linea = {0}", linea.Linea))
            If drCol.Length > 0 Then
               drCol(0)("TipoError") = linea.TipoError
            End If
            dr.Proceso = False

         End If
         'para cada linea le digo si la procesa cuando va a grabar el archivo o no.
         linea.Procesar = dr.Proceso


      Next
   End Sub
   Private Sub CitiComprasDespachoImportacion(dt As dsAFIP.CitiComprasDespachoImportacionDataTable)

      Dim linea As CitiComprasDespachoImportacionLinea


      For Each dr As dsAFIP.CitiComprasDespachoImportacionRow In dt.Rows

         linea = New CitiComprasDespachoImportacionLinea()

         linea.Linea = dr.Linea

         '01 - desde 001 hasta 016 / AlfaNúmerico / Tam = 16 / Observaciones =  
         linea.DespachoImportacion = dr.NumeroDespachoCompleto
         '02 - desde 017 hasta 031 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         linea.ImporteNetoGravado = dr.BaseImponible
         '03 - desde 032 hasta 035 / Númerico / Tam = 4 / Observaciones =  Según tabla Alícuotas
         linea.AlicuotaDeIVA = dr.IdAFIPIVA
         '04 - desde 036 hasta 050 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImpuestoLiquidado = dr.ImporteImpuesto

         Me._citiComprasDespachoImportacion.Lineas.Add(linea)

         'para cada linea le digo si la procesa cuando va a grabar el archivo o no.
         linea.Procesar = dr.Proceso

      Next
   End Sub
#End Region

   Private Sub btnExaminarDespacho_Click(sender As Object, e As EventArgs) Handles btnExaminarDespacho.Click

      Dim DialogoGuardarArchivo As New SaveFileDialog()

      DialogoGuardarArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoGuardarArchivo.Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*"
      DialogoGuardarArchivo.FilterIndex = 1
      DialogoGuardarArchivo.RestoreDirectory = True
      DialogoGuardarArchivo.FileName = "CitiComprasDespacho_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"

      If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            If DialogoGuardarArchivo.FileName <> "" Then

               Me.txtArchivoDespacho.Text = DialogoGuardarArchivo.FileName

               'If System.IO.File.Exists(Me.txtArchivoDestinoAlicuotas.Text.Trim()) Then
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


   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      Try
         If e.Cell.Row.ListObject IsNot Nothing Then
            Dim drDet As dsAFIP.CitiComprasRow = ugDetalle.FilaSeleccionada(Of dsAFIP.CitiComprasRow)(e.Cell.Row)
            If e.Cell IsNot Nothing AndAlso e.Cell.Row IsNot Nothing Then
               Dim dt As dsAFIP.CitiComprasAlicuotasDataTable = DirectCast(ugAlicuotas.DataSource, dsAFIP.CitiComprasAlicuotasDataTable)

               For Each drAli As dsAFIP.CitiComprasAlicuotasRow In dt.Rows
                  If drAli.IdSucursal = Integer.Parse(drDet("IdSucursal").ToString()) And
                 drAli.IdTipoComprobante = drDet("IdTipoComprobante").ToString() And
                  drAli.Letra = drDet("Letra").ToString() And
                  drAli.CentroEmisor = Integer.Parse(drDet("CentroEmisor").ToString()) And
                  drAli.NumeroComprobante = Long.Parse(drDet("NumeroComprobante").ToString()) Then
                     If Boolean.Parse(drDet("Proceso").ToString()) Then
                        drAli.Proceso = False
                     Else
                        drAli.Proceso = True
                     End If

                  End If
               Next

               Dim dt2 As dsAFIP.CitiComprasDespachoImportacionDataTable = DirectCast(ugDespachoImportacion.DataSource, dsAFIP.CitiComprasDespachoImportacionDataTable)

               For Each drDesp As dsAFIP.CitiComprasDespachoImportacionRow In dt2.Rows
                  If drDesp.IdSucursal = Integer.Parse(drDet("IdSucursal").ToString()) And
                     drDesp.IdTipoComprobante = drDet("IdTipoComprobante").ToString() And
                     drDesp.Letra = drDet("Letra").ToString() And
                     drDesp.CentroEmisor = Integer.Parse(drDet("CentroEmisor").ToString()) And
                     drDesp.NumeroComprobante = Long.Parse(drDet("NumeroComprobante").ToString()) Then

                     If Boolean.Parse(drDet("Proceso").ToString()) Then
                        drDesp.Proceso = False
                     Else
                        drDesp.Proceso = True
                     End If

                  End If
               Next
            End If
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class