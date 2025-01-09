Option Explicit On
Option Strict On

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual

Imports System.Data
Imports System.IO
Imports System.Drawing

#End Region

Public Class SueldosExportacionSICOSS

#Region "Campos"

   Private _publicos As Publicos
   Private _sicoss As SICOSS

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.dtpPeriodoFiscal.Value = DateTime.Today

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbVerRegistrosConErrores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbVerRegistrosConErrores.Click
      Try
         Dim dt As dsAFIP.CitiVentasDataTable = DirectCast(Me.dgvDetalle.DataSource, dsAFIP.CitiVentasDataTable)
         Dim dtErro As dsAFIP.CitiVentasDataTable = New dsAFIP.CitiVentasDataTable()
         Dim drErro As dsAFIP.CitiVentasRow
         For Each dr As dsAFIP.CitiVentasRow In dt.Rows
            If Not String.IsNullOrEmpty(dr.TipoError) Then
               drErro = dtErro.NewCitiVentasRow()
               drErro.ItemArray = dr.ItemArray
               dtErro.Rows.Add(drErro)
            End If
         Next

         Dim cg As ConsultaGenerica = New ConsultaGenerica(dtErro)
         cg.Show()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvDetalle_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvDetalle.Sorted
      Try
         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
            If Not String.IsNullOrEmpty(dr.Cells("colError").Value.ToString()) Then
               dr.DefaultCellStyle.BackColor = Color.LightSalmon
               dr.Cells("ProcesoDataGridViewCheckBoxColumn").ReadOnly = True
            End If
         Next
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged
      Try
         Dim dt As dsAFIP.CitiVentasDataTable = DirectCast(Me.dgvDetalle.DataSource, dsAFIP.CitiVentasDataTable)
         For Each dr As dsAFIP.CitiVentasRow In dt.Rows
            If String.IsNullOrEmpty(dr.TipoError) And Not dr.EstaAnulada Then
               dr.Proceso = Me.chbTodos.Checked
            End If
         Next
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ExportacionCitiVentas_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbExportar.Click

      Try

         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub

         If Me.txtArchivoDestino.Text.Trim() = "" Then
            MessageBox.Show("No Indico el Archivo Destino.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtArchivoDestino.Focus()
            Exit Sub
         End If

         'If Me.dtpDesde.Value.Month <> Me.dtpHasta.Value.Month Or Me.dtpDesde.Value.Year <> Me.dtpHasta.Value.Year Then
         '   MessageBox.Show("No puede exportar informacion de destintos meses.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.dtpDesde.Focus()
         '   Exit Sub
         'End If

         Me.Cursor = Cursors.WaitCursor

         Me.ExportarDatos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub dgvDetalle_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
      Try

         If e.RowIndex <> -1 Then
            Me.dgvDetalle.UpdateCellValue(e.ColumnIndex, e.RowIndex)
         End If

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try


   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
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

      Me.dtpPeriodoFiscal.Value = DateTime.Today

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.txtArchivoDestino.Text = ""

      Me.tsbExportar.Enabled = False
      Me.tsbVerRegistrosConErrores.Enabled = False

   End Sub

   Private Sub CargaGrillaDetalle()

      'Dim oVenta As Reglas. = New Reglas.Ventas()

      Dim decSubTotal As Decimal = 0
      Dim decTotalImpuestos As Decimal = 0
      Dim decTotal As Decimal = 0

      Try

         Dim dtDetalle As DataTable
         Dim dt As dsAFIP.CitiVentasDataTable = New dsAFIP.CitiVentasDataTable()
         Dim drCl As dsAFIP.CitiVentasRow

         dtDetalle = Nothing ' oVenta.GetParaExportarAFIP(Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM")))

         Me.tsbVerRegistrosConErrores.Enabled = False

         Dim linea As Integer = 1

         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewCitiVentasRow()

            drCl.Linea = linea
            drCl.Proceso = False

            drCl.IdTipoComprobante = dr("IdTipoComprobante").ToString()
            drCl.DescripcionAbrev = dr("DescripcionAbrev").ToString()
            drCl.Letra = dr("Letra").ToString()
            drCl.CentroEmisor = Integer.Parse(dr("CentroEmisor").ToString())
            drCl.NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
            drCl.Fecha = Date.Parse(dr("Fecha").ToString())

            If Not String.IsNullOrEmpty(dr("TipoDocCliente").ToString()) Then
               drCl.TipoDocCliente = dr("TipoDocCliente").ToString()
               drCl.NroDocCliente = Long.Parse(dr("NroDocCliente").ToString())
            Else
               drCl.TipoDocCliente = ""
               drCl.NroDocCliente = 0
            End If



            drCl.NombreCategoriaFiscal = dr("NombreCategoriaFiscal").ToString()

            drCl.CUIT = dr("CUIT").ToString()

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

            drCl.IVA2100 = Decimal.Parse(dr("IVA2100").ToString())
            drCl.IVA1050 = Decimal.Parse(dr("IVA1050").ToString())
            drCl.IVA2700 = Decimal.Parse(dr("IVA2700").ToString())
            drCl.IVA0000 = Decimal.Parse(dr("IVA0000").ToString())

            If drCl.IVA2100 <> 0 Then
               drCl.CantidadDeAlicuotas += 1
            End If
            If drCl.IVA1050 <> 0 Then
               drCl.CantidadDeAlicuotas += 1
            End If
            If drCl.IVA2700 <> 0 Then
               drCl.CantidadDeAlicuotas += 1
            End If
            If drCl.IVA0000 <> 0 Then
               drCl.CantidadDeAlicuotas += 1
            End If
            'If drCl.CantidadDeAlicuotas = 0 Then     'No Gravado
            '   drCl.CantidadDeAlicuotas += 1

            'End If

            drCl.PGANA = Decimal.Parse(dr("PGANA").ToString())
            drCl.PIIBB = Decimal.Parse(dr("PIIBB").ToString())
            drCl.PIVA = Decimal.Parse(dr("PIVA").ToString())
            drCl.PVAR = Decimal.Parse(dr("PVAR").ToString())

            drCl.Importe = drCl.IVA2100 + drCl.IVA1050 + drCl.IVA2700
            drCl.Percepciones = drCl.PGANA + drCl.PIIBB + drCl.PIVA + drCl.PVAR

            drCl.ImpuestoInterno = Decimal.Parse(dr("IMPINT").ToString())

            If dr("IdEstadoComprobante").ToString() <> "ANULADO" Then
               drCl.NombreCliente = dr("NombreCliente").ToString()
               drCl.EstaAnulada = False
               drCl.ImporteBruto = Decimal.Parse(dr("ImporteBruto").ToString())
               drCl.Neto = Decimal.Parse(dr("Neto").ToString())
               'drCl.Importe = Decimal.Parse(dr("Importe").ToString())
               drCl.Total = Decimal.Parse(dr("Total").ToString()) + drCl.Percepciones
               ' drCl.Alicuota = Decimal.Parse(dr("Alicuota").ToString())
            Else
               drCl.NombreCliente = "** COMPROBANTE ANULADO **"
               drCl.EstaAnulada = True
               drCl.ImporteBruto = 0
               drCl.Importe = 0
               drCl.Total = 0
            End If

            'Dim formaPago As Entidades.VentaFormaPago = New Reglas.VentasFormasPago().GetUna(Integer.Parse(dr("IdFormasPago").ToString()))
            'drCl.FechaVto = drCl.Fecha.AddDays(formaPago.Dias)

            dt.Rows.Add(drCl)

            decSubTotal = decSubTotal + drCl.ImporteBruto
            decTotalImpuestos = decTotalImpuestos + drCl.Percepciones + drCl.Importe
            decTotal = decTotal + drCl.Total

            linea += 1

         Next


         Me.dgvDetalle.DataSource = dt

         Me.txtArchivoDestino.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\CitiVentas_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"

         Me.CrearCitiVentas()

         Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CrearCitiVentas()
      Try

         Me._sicoss = New SICOSS()

         Dim dt As dsAFIP.CitiVentasDataTable = DirectCast(Me.dgvDetalle.DataSource, dsAFIP.CitiVentasDataTable)

         Me.chbTodos.Checked = True

         For Each dr As dsAFIP.CitiVentasRow In dt.Rows
            dr.Proceso = Me.chbTodos.Checked
         Next

         'controlo que la cantidad de alicuotas sea la correcta para las notas de debito de cheques rechazados
         'For Each dr As dsAFIP.CitiVentasRow In dt.Rows
         '   If (dr.IdTipoComprobante.Contains("eNDEB") Or dr.IdTipoComprobante.Contains("NDEBCHEQRECH")) Then
         '      dr.CantidadRealSinAlicuota = Me.GetCantidadRealSinAlicuota(dt2,
         '                                                             dr.IdTipoComprobante,
         '                                                             dr.Letra,
         '                                                             dr.CentroEmisor,
         '                                                             dr.NumeroComprobante)
         '      dr.CantidadDeAlicuotas = Me.GetCantidadDeAlicuotas(dt2,
         '                                                             dr.IdTipoComprobante,
         '                                                             dr.Letra,
         '                                                             dr.CentroEmisor,
         '                                                             dr.NumeroComprobante)
         '   End If
         'Next

         Me.SICOSS(dt)


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
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         For Each li As SICOSSLinea In Me._sicoss.Lineas
            For Each dgv As DataGridViewRow In Me.dgvDetalle.Rows
               If li.Linea = Long.Parse(dgv.Cells(1).Value.ToString()) Then
                  li.Procesar = (dgv.Cells(0).Value.ToString() = "True")
                  Exit For
               End If
            Next
         Next

         stb.AppendFormat("Realmente desea generar el archivo para los {0} comprobantes?", Me._sicoss.CantidadDeLineasaProcesar)

         If MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me._sicoss.GrabarArchivo(Me.txtArchivoDestino.Text)
            MessageBox.Show("Se Exportaron " & Me._sicoss.CantidadDeLineasaProcesar.ToString() & " comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Else
            MessageBox.Show("Ha cancelado la exportación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         Throw
      End Try

   End Sub

   Private Sub SICOSS(ByVal dt As DataTable)
      Dim linea As SICOSSLinea

      Me.tspBarra.Visible = True
      Me.tspBarra.Minimum = 0
      Me.tspBarra.Maximum = dt.Rows.Count
      Me.tspBarra.Value = 0

      For Each dr As dsAFIP.CitiVentasRow In dt.Rows

         Me.tspBarra.Value = dr.Linea - 1
         'si esta anulada paso al proximo registro y no lo genero
         If dr.EstaAnulada Then
            dr.Proceso = False
            Continue For
         End If
         If Not dr.Proceso Then
            Continue For
         End If

         linea = New SICOSSLinea()

         linea.Linea = dr.Linea

         ''01 - desde 001 hasta 008 / Númerico / Tam = 8 / Observaciones = Fto. AAAAMMDD
         'linea.FechaDelComprobante = dr.Fecha
         ''02 - desde 009 hasta 011 / Númerico / Tam = 3 / Observaciones = Según tabla de comprobantes
         'linea.TipoDeComprobante = dr.IdAFIPTipoComprobante
         ''03 - desde 012 hasta 016 / Númerico / Tam = 5 / Observaciones = 
         'linea.PuntoDeVenta = dr.CentroEmisor
         ''04 - desde 017 hasta 036 / Númerico / Tam = 20 / Observaciones = 
         'linea.NroDeComprobante = dr.NumeroComprobante
         ''05 - desde 037 hasta 056 / Númerico / Tam = 20 / Observaciones = 
         'linea.NroDeComprobanteHasta = dr.NumeroComprobante
         ''06 - desde 057 hasta 058 / Númerico / Tam = 2 / Observaciones = Según tabla de documentos
         'If String.IsNullOrEmpty(dr.CUIT) Then
         '   'Reemplazar los 1000 por el parametro que hace Irene.
         '   'Aunque NO tenga DNI, debe informarlo, el registro NO entra porque Legalmente no puede hacer. Se vera con el cliente como solucionarlo
         '   If dr.IdAFIPTipoDocumento > 0 Or dr.Total >= Publicos.FacturacionControlaTopeCF Then
         '      linea.CodigoDeDocumentoIdentificatorioDelComprador = dr.IdAFIPTipoDocumento
         '   Else
         '      linea.CodigoDeDocumentoIdentificatorioDelComprador = 99 'si no identificamos un tipo de documento le enviamos fijo el 99 (Sin identificar/venta global diaria)
         '   End If
         'Else
         '   linea.CodigoDeDocumentoIdentificatorioDelComprador = 80
         'End If
         ''07 - desde 059 hasta 078 / AlfaNúmerico / Tam = 20 / Observaciones = 
         'If String.IsNullOrEmpty(dr.CUIT) Then
         '   linea.NroDeIdentificacionDelComprador = dr.NroDocCliente
         'Else
         '   linea.NroDeIdentificacionDelComprador = Long.Parse(dr.CUIT.Replace("-"c, ""))
         'End If
         ''08 - desde 079 hasta 108 / AlfaNúmerico / Tam = 30 / Observaciones = 
         'linea.ApellidoYNombreODenominacionDelComprador = dr.NombreCliente
         ''09 - desde 109 hasta 123 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         'linea.ImporteTotalDeLaOperacion = dr.Total
         ''10 - desde 124 hasta 138 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         'linea.TotalDeConceptosQueNoIntegranElPrecioNeto = dr.IVA0000
         ''11 - desde 139 hasta 153 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         'linea.ImpuestoLiquidadoARNIOPercANoCategoriz = 0
         ''12 - desde 154 hasta 168 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         'If dr.CantidadDeAlicuotas = 0 Then
         '   linea.ImporteDeOperacionesExentas = dr.CantidadRealSinAlicuota
         'Else
         '   linea.ImporteDeOperacionesExentas = 0
         'End If
         ''13 - desde 169 hasta 183 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         'linea.ImporteDePercepOPagosACtaDeImpuestoNac = dr.PGANA
         ''14 - desde 184 hasta 198 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         'linea.ImporteDePercepcionesDeIngresosBrutos = dr.PIIBB
         ''15 - desde 199 hasta 213 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         'linea.ImporteDePercepcionesDeImpuestosMunicipales = dr.PVAR
         ''16 - desde 214 hasta 228 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         'linea.ImporteDeImpuestosInternos = dr.ImpuestoInterno
         ''17 - desde 229 hasta 231 / Alfabetico / Tam = 3 / Observaciones =  Según tabla Monedas
         'linea.CodigoDeMoneda = "PES"
         ''18 - desde 232 hasta 241 / Númerico / Tam = 10 / Observaciones =  4 enteros 6 decimales sin punto decimal
         'linea.TipoDeCambio = 1
         ''19 - desde 242 hasta 242 / Númerico / Tam = 1 / Observaciones = 
         'linea.CantidadDeAlicuotasDeIVA = dr.CantidadDeAlicuotas
         ''20 - desde 243 hasta 243 / Alfabetico / Tam = 1 / Observaciones =   Según tabla Codigo_Operación, de No Corresponder v
         'If linea.ImporteDeOperacionesExentas <> 0 Then
         '   linea.CodigoDeOperacion = "E" 'OPERACIONES EXENTAS
         'Else
         '   If dr.IVA0000 <> 0 Then
         '      linea.CodigoDeOperacion = "N"
         '   Else
         '      linea.CodigoDeOperacion = String.Empty
         '   End If

         'End If
         ''21 - desde 244 hasta 258 / Númerico / Tam = 15 / Observaciones = 
         'linea.OtrosTributos = 0
         ''22 - desde 259 hasta 266 / Númerico / Tam = 8 / Observaciones =  Fto: AAAAMMDD

         'Dim comprobante As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno(dr.IdTipoComprobante)

         'If Not comprobante.EsFiscal Then
         '   linea.FechaDeVencimiento = dr.FechaVto
         'Else
         '   linea.FechaDeVencimiento = Nothing
         'End If


         Me._sicoss.Lineas.Add(linea)

         If linea.TieneError Then
            Me.tsbVerRegistrosConErrores.Enabled = True
            Me.dgvDetalle.Rows(linea.Linea - 1).DefaultCellStyle.BackColor = Color.LightSalmon
            Me.dgvDetalle.Rows(linea.Linea - 1).Cells("colError").Value = linea.TipoError
            dr.Proceso = False
            Me.dgvDetalle.Rows(linea.Linea - 1).Cells("ProcesoDataGridViewCheckBoxColumn").ReadOnly = True
         End If
         'para cada linea le digo si la procesa cuando va a grabar el archivo o no.
         linea.Procesar = dr.Proceso
      Next
   End Sub

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

End Class