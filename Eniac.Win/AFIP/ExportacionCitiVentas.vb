Public Class ExportacionCitiVentas

#Region "Campos"

   Private _publicos As Publicos
   Private _citi As CitiVentas
   Private _citiAlicuotas As CitiVentasAlicuotas

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
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

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbExportar.Click
      TryCatched(
      Sub()
         If dgvDetalle.Rows.Count = 0 Then Exit Sub

         If txtArchivoDestinoComprobantes.Text.Trim() = "" Then
            ShowMessage("No Indico el Archivo Destino.")
            txtArchivoDestinoComprobantes.Focus()
            Exit Sub
         End If

         'If Me.dtpDesde.Value.Month <> Me.dtpHasta.Value.Month Or Me.dtpDesde.Value.Year <> Me.dtpHasta.Value.Year Then
         '   MessageBox.Show("No puede exportar informacion de destintos meses.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me.dtpDesde.Focus()
         '   Exit Sub
         'End If

         ExportarDatos()
         CerrarPeriodoFiscal()
      End Sub)
   End Sub
   Private Sub CerrarPeriodoFiscal()
      TryCatched(
      Sub()
         Dim rPeriodoFiscal = New Reglas.PeriodosFiscales

         Dim oPeriodoFiscal = rPeriodoFiscal.GetUno(actual.Sucursal.IdEmpresa, Integer.Parse(dtpPeriodoFiscal.Value.ToString("yyyyMM")))

         If oPeriodoFiscal IsNot Nothing Then
            oPeriodoFiscal.VentasHabilitadas = False
            rPeriodoFiscal.Actualizar(oPeriodoFiscal)
         End If
      End Sub)
   End Sub
   Private Sub tsbVerRegistrosConErrores_Click(sender As Object, e As EventArgs) Handles tsbVerRegistrosConErrores.Click
      TryCatched(
      Sub()
         Dim dt = DirectCast(dgvDetalle.DataSource, dsAFIP.CitiVentasDataTable)
         Dim dtErro = New dsAFIP.CitiVentasDataTable()
         For Each dr In dt.AsEnumerable().Where(Function(dr1) Not String.IsNullOrEmpty(dr1.TipoError))
            Dim drErro = dtErro.NewCitiVentasRow()
            drErro.ItemArray = dr.ItemArray
            dtErro.Rows.Add(drErro)
         Next

         Dim cg = New ConsultaGenerica(dtErro)
         cg.Show()
      End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub dtpPeriodoFiscal_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodoFiscal.ValueChanged
      dtpPeriodoFiscal.Value = dtpPeriodoFiscal.Value.PrimerDiaMes()
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         CargaGrillaDetalle()

         If dgvDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
            chbTodos.Enabled = True
            tsbExportar.Enabled = True
         Else
            tsbExportar.Enabled = False
            chbTodos.Enabled = False
            ShowMessage("No hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub
#End Region

#Region "Eventos Grilla"
   Private Sub dgvDetalle_Sorted(sender As Object, e As EventArgs) Handles dgvDetalle.Sorted
      TryCatched(
      Sub()
         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
            If Not String.IsNullOrEmpty(dr.Cells("dgvDetalle_colError").Value.ToString()) Then
               dr.DefaultCellStyle.BackColor = Color.LightSalmon
               dr.Cells("dgvDetalle_Proceso").ReadOnly = True
            End If
         Next
      End Sub)
   End Sub

   Private Sub dgvDetalle_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellClick
      TryCatched(
      Sub()
         If e.RowIndex <> -1 Then
            dgvDetalle.UpdateCellValue(e.ColumnIndex, e.RowIndex)
         End If
      End Sub)
   End Sub


   Private Sub dgvDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalle.CellContentClick
      TryCatched(
      Sub()
         If e.RowIndex <> -1 And Not dgvDetalle.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly Then
            'El valor en pantalla todavía no cambio. cambia luego de ejecutarse este evento
            ActivarVentaAlicuota(dgvDetalle.CurrentRow, Not Boolean.Parse(dgvDetalle.Rows(e.RowIndex).Cells(0).Value.ToString()))
         End If
      End Sub)
   End Sub



   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      TryCatched(
      Sub()
         Dim dt As dsAFIP.CitiVentasDataTable = DirectCast(Me.dgvDetalle.DataSource, dsAFIP.CitiVentasDataTable)
         For Each dr As dsAFIP.CitiVentasRow In dt.Rows
            If String.IsNullOrEmpty(dr.TipoError) And Not dr.EstaAnulada Then
               dr.Proceso = Me.chbTodos.Checked
            End If
         Next

         Dim dt2 As dsAFIP.CitiVentasAlicuotasDataTable = DirectCast(Me.dgvAlicuotas.DataSource, dsAFIP.CitiVentasAlicuotasDataTable)
         For Each dr2 As dsAFIP.CitiVentasAlicuotasRow In dt2.Rows
            If String.IsNullOrEmpty(dr2.TipoError) Then
               dr2.Proceso = Me.chbTodos.Checked
            End If
         Next
      End Sub)
   End Sub
#End Region


   Private Sub btnExaminarComprobantes_Click(sender As Object, e As EventArgs) Handles btnExaminarComprobantes.Click
      TryCatched(
      Sub()
         Dim DialogoGuardarArchivo = New SaveFileDialog With {
              .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop,
              .Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*",
              .FilterIndex = 1,
              .RestoreDirectory = True,
              .FileName = "CitiVentas_" & dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"
          }

         If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrWhiteSpace(DialogoGuardarArchivo.FileName) Then
               txtArchivoDestinoComprobantes.Text = DialogoGuardarArchivo.FileName
               'If System.IO.File.Exists(Me.txtArchivoDestino.Text.Trim()) Then
               '   If MessageBox.Show("El Archivo Seleccionado Existe, Desea Sobreescribirlo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
               '      Me.txtArchivoDestino.Text = ""
               '   End If
               'End If
            End If
         End If
      End Sub)
   End Sub

   Private Sub btnExaminarAlicuotas_Click(sender As Object, e As EventArgs) Handles btnExaminarAlicuotas.Click
      TryCatched(
      Sub()
         Dim DialogoGuardarArchivo = New SaveFileDialog With {
                   .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop,
                   .Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*",
                   .FilterIndex = 1,
                   .RestoreDirectory = True,
                   .FileName = "CitiVentasAlicuotas_" & dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"
               }

         If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrWhiteSpace(DialogoGuardarArchivo.FileName) Then
               txtArchivoDestinoAlicuotas.Text = DialogoGuardarArchivo.FileName
               'If System.IO.File.Exists(Me.txtArchivoDestinoAlicuotas.Text.Trim()) Then
               '   If MessageBox.Show("El Archivo Seleccionado Existe, Desea Sobreescribirlo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
               '      Me.txtArchivoDestino.Text = ""
               '   End If
               'End If
            End If
         End If
      End Sub)

   End Sub

#End Region

#Region "Metodos"

   Private Sub RefrescarDatosGrilla()

      dtpPeriodoFiscal.Value = Date.Today.PrimerDiaMes()

      If TypeOf (dgvDetalle.DataSource) Is DataTable Then
         DirectCast(dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      txtArchivoDestinoComprobantes.Text = ""
      txtTotalComp.Text = "0.00"
      txtSubtotalComp.Text = "0.00"
      txtImpuestosComp.Text = "0.00"

      txtArchivoDestinoAlicuotas.Text = ""
      txtTotalAlic.Text = "0.00"
      txtSubtotalAlic.Text = "0.00"
      txtImpuestosAlic.Text = "0.00"

      tsbExportar.Enabled = False
      tsbVerRegistrosConErrores.Enabled = False

      tssRegistros.Text = dgvDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim decSubTotal As Decimal = 0
      Dim decTotalImpuestos As Decimal = 0
      Dim decTotal As Decimal = 0

      Dim dtDetalle As DataTable
      Dim dt = New dsAFIP.CitiVentasDataTable()
      Dim drCl As dsAFIP.CitiVentasRow

      Dim rVenta As Reglas.Ventas = New Reglas.Ventas()
      dtDetalle = rVenta.GetParaExportarAFIP(Integer.Parse(dtpPeriodoFiscal.Value.ToString("yyyyMM")))

      Me.tsbVerRegistrosConErrores.Enabled = False

      Dim linea As Integer = 1

      Dim decTotalNeto As Decimal = 0

      For Each dr As DataRow In dtDetalle.Rows

         drCl = dt.NewCitiVentasRow()

         drCl.Linea = linea
         drCl.Proceso = False
         drCl.IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
         drCl.IdTipoComprobante = dr("IdTipoComprobante").ToString()
         drCl.DescripcionAbrev = dr("DescripcionAbrev").ToString()
         drCl.Letra = dr("Letra").ToString()
         drCl.CentroEmisor = Integer.Parse(dr("CentroEmisor").ToString())
         drCl.NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
         drCl.Fecha = Date.Parse(dr("Fecha").ToString())

         If Not String.IsNullOrEmpty(dr("TipoDocCliente").ToString()) Then
            drCl.TipoDocCliente = dr("TipoDocCliente").ToString()
            If Not String.IsNullOrWhiteSpace(dr("NroDocCliente").ToString()) Then
               drCl.NroDocCliente = Long.Parse(dr("NroDocCliente").ToString())
            Else
               drCl.NroDocCliente = 0
            End If
         Else
            drCl.TipoDocCliente = ""
            drCl.NroDocCliente = 0
         End If



         drCl.NombreCategoriaFiscal = dr("NombreCategoriaFiscal").ToString()

         drCl.CUIT = dr("CUIT").ToString()

         If Not String.IsNullOrEmpty(dr("IdAFIPTipoComprobante").ToString()) Then
            drCl.IdAFIPTipoComprobante = Integer.Parse(dr("IdAFIPTipoComprobante").ToString())
         Else
            drCl.IdAFIPTipoComprobante = 0
         End If
         If Not String.IsNullOrEmpty(dr("IdAFIPTipoDocumento").ToString()) Then
            drCl.IdAFIPTipoDocumento = Integer.Parse(dr("IdAFIPTipoDocumento").ToString())
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
            drCl.Neto = 0
            drCl.Total = 0
         End If

         Dim formaPago As Entidades.VentaFormaPago = New Reglas.VentasFormasPago().GetUna(Integer.Parse(dr("IdFormasPago").ToString()))
         drCl.FechaVto = drCl.Fecha.AddDays(formaPago.Dias)

         If IsNumeric(dr("IdAFIPTipoDocumentoTipoCbte")) Then
            drCl.IdAFIPTipoDocumentoTipoCbte = Integer.Parse(dr("IdAFIPTipoDocumentoTipoCbte").ToString())
         End If

         If Not String.IsNullOrWhiteSpace(dr("IncluyeFechaVencimiento").ToString()) Then
            drCl.IncluyeFechaVencimiento = Boolean.Parse(dr("IncluyeFechaVencimiento").ToString())
         End If

         dt.Rows.Add(drCl)

         Try
            decTotalNeto = decTotalNeto + drCl.Neto
         Catch ex As Exception
            Throw
         End Try
         decSubTotal = decSubTotal + drCl.ImporteBruto
         'SPC: 17/05/2018 - Quito percepciones de la suma para comparar con Alicuotas. Ademas el TextBox no se usa para nada.
         '                 Habria que agregar totales en Grilla.
         '     Mismo ajuste que en Compras realizado por GAR
         'decTotalImpuestos = decTotalImpuestos + drCl.Percepciones + drCl.Importe
         decTotalImpuestos = decTotalImpuestos + drCl.Importe
         decTotal = decTotal + drCl.Total

         linea += 1

      Next

      txtSubtotalComp.Text = decTotalNeto.ToString("#,##0.00")
      txtImpuestosComp.Text = decTotalImpuestos.ToString("#,##0.00")
      txtTotalComp.Text = decTotal.ToString("#,##0.00")

      Me.dgvDetalle.DataSource = dt

      'If Me.chkMesCompleto.Checked Then
      Me.txtArchivoDestinoComprobantes.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\CitiVentas_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"
      Me.txtArchivoDestinoAlicuotas.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\CitiVentasAlicuotas_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"
      'Else
      '   Me.txtArchivoDestino.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\CitiVentas_" & Me.dtpDesde.Value.ToString("yyyyMMdd") & "_" & Me.dtpHasta.Value.ToString("yyyyMMdd") & ".txt"
      '   Me.txtArchivoDestinoAlicuotas.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\CitiVentasAlicuotas_" & Me.dtpDesde.Value.ToString("yyyyMMdd") & "_" & Me.dtpHasta.Value.ToString("yyyyMMdd") & ".txt"
      'End If

      'Alicuotas-----------------------------------------------------------------------------------------------------------------------------
      Dim dtDetalleAlicuotas As DataTable
      Dim dt1 As dsAFIP.CitiVentasAlicuotasDataTable = New dsAFIP.CitiVentasAlicuotasDataTable()
      Dim drCl1 As dsAFIP.CitiVentasAlicuotasRow

      dtDetalleAlicuotas = rVenta.GetParaExportarAFIPAlicuotas(Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM")))

      Dim linea1 As Integer = 1

      decSubTotal = 0
      decTotalImpuestos = 0
      decTotal = 0

      For Each dr1 As DataRow In dtDetalleAlicuotas.Rows

         drCl1 = dt1.NewCitiVentasAlicuotasRow()

         drCl1.Linea = linea1
         drCl1.Proceso = True
         drCl1.IdSucursal = Integer.Parse(dr1("IdSucursal").ToString())
         drCl1.IdTipoComprobante = dr1("IdTipoComprobante").ToString()
         drCl1.DescripcionAbrev = dr1("DescripcionAbrev").ToString()
         drCl1.Letra = dr1("Letra").ToString()
         drCl1.CentroEmisor = Integer.Parse(dr1("CentroEmisor").ToString())
         drCl1.NumeroComprobante = Long.Parse(dr1("NumeroComprobante").ToString())

         If Not String.IsNullOrEmpty(dr1("TipoDocCliente").ToString()) Then
            drCl1.TipoDocCliente = dr1("TipoDocCliente").ToString()
            If Not String.IsNullOrWhiteSpace(dr1("NroDocCliente").ToString()) Then
               drCl1.NroDocCliente = Long.Parse(dr1("NroDocCliente").ToString())
            Else
               drCl1.NroDocCliente = 0
            End If
         Else
            drCl1.TipoDocCliente = ""
            drCl1.NroDocCliente = 0
         End If

         drCl1.CUIT = dr1("CUIT").ToString()

         drCl1.Alicuota = Decimal.Parse(dr1("Alicuota").ToString())
         drCl1.IdAFIPIVA = Integer.Parse(dr1("IdAFIPIVA").ToString())
         drCl1.Neto = Decimal.Parse(dr1("Neto").ToString())
         drCl1.Importe = Decimal.Parse(dr1("Importe").ToString())
         drCl1.Total = Decimal.Parse(dr1("Total").ToString())

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

         If IsNumeric(dr1("IdAFIPTipoDocumentoTipoCbte")) Then
            drCl1.IdAFIPTipoDocumentoTipoCbte = Integer.Parse(dr1("IdAFIPTipoDocumentoTipoCbte").ToString())
         End If


         dt1.Rows.Add(drCl1)

         decSubTotal = decSubTotal + drCl1.Neto
         decTotalImpuestos = decTotalImpuestos + drCl1.Importe
         decTotal = decTotal + drCl1.Total

         linea1 += 1

      Next

      txtSubtotalAlic.Text = decSubTotal.ToString("#,##0.00")
      txtImpuestosAlic.Text = decTotalImpuestos.ToString("#,##0.00")
      txtTotalAlic.Text = decTotal.ToString("#,##0.00")

      Me.dgvAlicuotas.DataSource = dt1

      Me.CrearCitiVentas()

      For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
         If Not String.IsNullOrEmpty(dr.Cells("dgvDetalle_colError").Value.ToString()) Then
            dr.DefaultCellStyle.BackColor = Color.LightSalmon
            dr.Cells("dgvDetalle_Proceso").ReadOnly = True
         End If
      Next

      Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Private Sub CrearCitiVentas()
      _citi = New CitiVentas()
      _citiAlicuotas = New CitiVentasAlicuotas()

      Dim dt = DirectCast(dgvDetalle.DataSource, dsAFIP.CitiVentasDataTable)
      Dim dt2 = DirectCast(dgvAlicuotas.DataSource, dsAFIP.CitiVentasAlicuotasDataTable)

      chbTodos.Checked = True

      For Each dr As dsAFIP.CitiVentasRow In dt.Rows
         dr.Proceso = chbTodos.Checked
      Next

      For Each dr1 As dsAFIP.CitiVentasAlicuotasRow In dt2.Rows
         dr1.Proceso = chbTodos.Checked
      Next

      'controlo que la cantidad de alicuotas sea la correcta para las notas de debito de cheques rechazados
      For Each dr As dsAFIP.CitiVentasRow In dt.Rows
         If (dr.IdTipoComprobante.Contains("eNDEB") Or dr.IdTipoComprobante.Contains("NDEBCHEQRECH")) Then
            dr.CantidadRealSinAlicuota = GetCantidadRealSinAlicuota(dt2,
                                                                   dr.IdTipoComprobante,
                                                                   dr.Letra,
                                                                   dr.CentroEmisor,
                                                                   dr.NumeroComprobante)
            dr.CantidadDeAlicuotas = GetCantidadDeAlicuotas(dt2,
                                                                   dr.IdTipoComprobante,
                                                                   dr.Letra,
                                                                   dr.CentroEmisor,
                                                                   dr.NumeroComprobante)
         End If
      Next

      CitiVentas(dt)

      CitiVentasAlicuotas(dt2)

   End Sub

   Private Function GetCantidadRealSinAlicuota(filas As dsAFIP.CitiVentasAlicuotasDataTable,
                                      idTipoComprobante As String,
                                      letra As String,
                                      centroEmisor As Integer,
                                      numero As Long) As Decimal
      'realizo una validación sobre los cheques rechazados ya que tienen 2 alicuotas pero una esta en cero
      'por ello si el tipo de comprobante en ND y el importe y alicuota son 0 entonces

      Dim var = From r In filas.AsEnumerable Select r
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
      Dim var = From r In filas.AsEnumerable Select r
                Where r.IdTipoComprobante = idTipoComprobante And r.CentroEmisor = centroEmisor And r.NumeroComprobante = numero

      Dim ali As Integer = 0

      For Each f As dsAFIP.CitiVentasAlicuotasRow In var
         ali += 1
      Next

      Return ali

   End Function

   Private Sub ExportarDatos()
      Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()
      tbcRegistros.Focus()

      For Each li As CitiVentasLinea In Me._citi.Lineas
         For Each dgv As DataGridViewRow In Me.dgvDetalle.Rows
            If li.Linea = Long.Parse(dgv.Cells("dgvDetalle_Linea").Value.ToString()) Then
               li.Procesar = (dgv.Cells("dgvDetalle_Proceso").Value.ToString() = "True")
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

      For Each li As CitiVentasAlicuotasLinea In Me._citiAlicuotas.Lineas
         For Each dgv As DataGridViewRow In Me.dgvAlicuotas.Rows
            If li.Linea = Long.Parse(dgv.Cells("dgvAlicuotas_Linea").Value.ToString()) Then
               li.Procesar = (dgv.Cells("dgvAlicuotas_Proceso").Value.ToString() = "True")
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

   End Sub

   Private Sub CitiVentas(dt As DataTable)
      Dim linea As CitiVentasLinea

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

         linea = New CitiVentasLinea()

         linea.Linea = dr.Linea

         '01 - desde 001 hasta 008 / Númerico / Tam = 8 / Observaciones = Fto. AAAAMMDD
         linea.FechaDelComprobante = dr.Fecha
         '02 - desde 009 hasta 011 / Númerico / Tam = 3 / Observaciones = Según tabla de comprobantes
         linea.TipoDeComprobante = dr.IdAFIPTipoComprobante
         '03 - desde 012 hasta 016 / Númerico / Tam = 5 / Observaciones = 
         linea.PuntoDeVenta = dr.CentroEmisor
         '04 - desde 017 hasta 036 / Númerico / Tam = 20 / Observaciones = 
         linea.NroDeComprobante = dr.NumeroComprobante
         '05 - desde 037 hasta 056 / Númerico / Tam = 20 / Observaciones = 
         linea.NroDeComprobanteHasta = dr.NumeroComprobante
         '06 - desde 057 hasta 058 / Númerico / Tam = 2 / Observaciones = Según tabla de documentos
         If dr.IsIdAFIPTipoDocumentoTipoCbteNull Then
            If String.IsNullOrEmpty(dr.CUIT) Then
               'Reemplazar los 1000 por el parametro que hace Irene.
               'Aunque NO tenga DNI, debe informarlo, el registro NO entra porque Legalmente no puede hacer. Se vera con el cliente como solucionarlo
               If dr.IdAFIPTipoDocumento > 0 Or dr.Total >= Reglas.Publicos.Facturacion.FacturacionControlaTopeCF Then
                  linea.CodigoDeDocumentoIdentificatorioDelComprador = dr.IdAFIPTipoDocumento
               Else
                  linea.CodigoDeDocumentoIdentificatorioDelComprador = 99 'si no identificamos un tipo de documento le enviamos fijo el 99 (Sin identificar/venta global diaria)
               End If
            Else
               linea.CodigoDeDocumentoIdentificatorioDelComprador = 80
            End If
         Else
            linea.CodigoDeDocumentoIdentificatorioDelComprador = dr.IdAFIPTipoDocumentoTipoCbte
         End If
         '07 - desde 059 hasta 078 / AlfaNúmerico / Tam = 20 / Observaciones = 
         If String.IsNullOrEmpty(dr.CUIT) Then
            linea.NroDeIdentificacionDelComprador = dr.NroDocCliente
         Else
            linea.NroDeIdentificacionDelComprador = Long.Parse(dr.CUIT.Replace("-"c, ""))
         End If
         '08 - desde 079 hasta 108 / AlfaNúmerico / Tam = 30 / Observaciones = 
         linea.ApellidoYNombreODenominacionDelComprador = Publicos.NormalizarDescripcion(dr.NombreCliente)
         '09 - desde 109 hasta 123 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         linea.ImporteTotalDeLaOperacion = dr.Total
         '10 - desde 124 hasta 138 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         linea.TotalDeConceptosQueNoIntegranElPrecioNeto = dr.IVA0000
         '11 - desde 139 hasta 153 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImpuestoLiquidadoARNIOPercANoCategoriz = 0
         '12 - desde 154 hasta 168 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         If dr.CantidadDeAlicuotas = 0 Then
            linea.ImporteDeOperacionesExentas = dr.CantidadRealSinAlicuota
         Else
            linea.ImporteDeOperacionesExentas = 0
         End If
         '13 - desde 169 hasta 183 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDePercepOPagosACtaDeImpuestoNac = dr.PGANA
         '14 - desde 184 hasta 198 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDePercepcionesDeIngresosBrutos = dr.PIIBB
         '15 - desde 199 hasta 213 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDePercepcionesDeImpuestosMunicipales = dr.PVAR
         '16 - desde 214 hasta 228 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDeImpuestosInternos = dr.ImpuestoInterno
         '17 - desde 229 hasta 231 / Alfabetico / Tam = 3 / Observaciones =  Según tabla Monedas
         linea.CodigoDeMoneda = "PES"
         '18 - desde 232 hasta 241 / Númerico / Tam = 10 / Observaciones =  4 enteros 6 decimales sin punto decimal
         linea.TipoDeCambio = 1
         '19 - desde 242 hasta 242 / Númerico / Tam = 1 / Observaciones = 
         linea.CantidadDeAlicuotasDeIVA = dr.CantidadDeAlicuotas
         '20 - desde 243 hasta 243 / Alfabetico / Tam = 1 / Observaciones =   Según tabla Codigo_Operación, de No Corresponder v
         If linea.ImporteDeOperacionesExentas <> 0 Then
            linea.CodigoDeOperacion = "E" 'OPERACIONES EXENTAS
         Else
            If dr.IVA0000 <> 0 Then
               linea.CodigoDeOperacion = "N"
            Else
               linea.CodigoDeOperacion = "0"
            End If

         End If
         '21 - desde 244 hasta 258 / Númerico / Tam = 15 / Observaciones = 
         linea.OtrosTributos = 0
         '22 - desde 259 hasta 266 / Númerico / Tam = 8 / Observaciones =  Fto: AAAAMMDD

         Dim comprobante As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno(dr.IdTipoComprobante)

         If dr.IsIncluyeFechaVencimientoNull Then
            If Not comprobante.EsFiscal Then
               If linea.TipoDeComprobante = 60 Or linea.TipoDeComprobante = 61 Then
                  linea.FechaDeVencimiento = Nothing
               Else
                  linea.FechaDeVencimiento = dr.FechaVto
               End If
            Else
               linea.FechaDeVencimiento = Nothing
            End If
         Else
            linea.FechaDeVencimiento = If(dr.IncluyeFechaVencimiento, dr.FechaVto, Nothing)
         End If


         Me._citi.Lineas.Add(linea)

         If linea.TieneError Then
            Me.tsbVerRegistrosConErrores.Enabled = True
            Me.dgvDetalle.Rows(linea.Linea - 1).DefaultCellStyle.BackColor = Color.LightSalmon
            Me.dgvDetalle.Rows(linea.Linea - 1).Cells("dgvDetalle_colError").Value = linea.TipoError
            dr.Proceso = False
            Me.dgvDetalle.Rows(linea.Linea - 1).Cells("dgvDetalle_Linea").ReadOnly = True
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

   Private Sub CitiVentasAlicuotas(dt As DataTable)

      Dim linea As CitiVentasAlicuotasLinea


      For Each dr As dsAFIP.CitiVentasAlicuotasRow In dt.Rows

         'controlo que no informe los registros de Notas de Debito de cheques rechazados
         'If Not Me.InformoLaAlicuota(dr.IdTipoComprobante, dr.Alicuota, dr.Importe) Then
         '   Continue For
         'End If

         linea = New CitiVentasAlicuotasLinea()

         linea.Linea = dr.Linea

         '01 - desde 001 hasta 003 / Númerico / Tam = 3 / Observaciones = Según tabla de comprobantes
         linea.TipoDeComprobante = dr.IdAFIPTipoComprobante
         '02 - desde 004 hasta 008 / Númerico / Tam = 5 / Observaciones = 
         linea.PuntoDeVenta = dr.CentroEmisor
         '03 - desde 009 hasta 028 / Númerico / Tam = 20 / Observaciones = 
         linea.NroDeComprobante = dr.NumeroComprobante
         '04 - desde 029 hasta 043 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         linea.ImporteNetoGravado = dr.Neto
         '05 - desde 044 hasta 047 / Númerico / Tam = 4 / Observaciones =  Según tabla Alícuotas
         linea.AlicuotaDeIVA = dr.IdAFIPIVA
         'si la alicuota es cero el importe neto gravado tiene que ser cero
         If dr.IdAFIPIVA = 3 Then
            linea.ImporteNetoGravado = 0
         End If
         '06 - desde 148 hasta 062 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImpuestoLiquidado = dr.Importe

         If dr.IsIdAFIPTipoDocumentoTipoCbteNull Then
            If String.IsNullOrEmpty(dr.CUIT) Then
               'Reemplazar los 1000 por el parametro que hace Irene.
               'Aunque NO tenga DNI, debe informarlo, el registro NO entra porque Legalmente no puede hacer. Se vera con el cliente como solucionarlo
               If dr.IdAFIPTipoDocumento > 0 Or dr.Total >= Reglas.Publicos.Facturacion.FacturacionControlaTopeCF Then
                  linea.CodigoDeDocumentoIdentificatorioDelComprador = dr.IdAFIPTipoDocumento
               Else
                  linea.CodigoDeDocumentoIdentificatorioDelComprador = 99 'si no identificamos un tipo de documento le enviamos fijo el 99 (Sin identificar/venta global diaria)
               End If
            Else
               linea.CodigoDeDocumentoIdentificatorioDelComprador = 80
            End If
         Else
            linea.CodigoDeDocumentoIdentificatorioDelComprador = dr.IdAFIPTipoDocumentoTipoCbte
         End If
         'If String.IsNullOrEmpty(dr.CUIT) Then
         '   linea.CodigoDeDocumentoIdentificatorioDelComprador = dr.IdAFIPTipoDocumento
         'Else
         '   linea.CodigoDeDocumentoIdentificatorioDelComprador = 80
         'End If

         Me._citiAlicuotas.Lineas.Add(linea)

         If linea.TieneError Then
            Me.tsbVerRegistrosConErrores.Enabled = True
            Me.dgvAlicuotas.Rows(linea.Linea - 1).DefaultCellStyle.BackColor = Color.LightSalmon
            Me.dgvAlicuotas.Rows(linea.Linea - 1).Cells("dgvAlicuotas_TipoError").Value = linea.TipoError
            dr.Proceso = False
            Me.dgvAlicuotas.Rows(linea.Linea - 1).Cells("dgvAlicuotas_Linea").ReadOnly = True
         End If
         'para cada linea le digo si la procesa cuando va a grabar el archivo o no.
         linea.Procesar = dr.Proceso
      Next
   End Sub
   Private Sub ActivarVentaAlicuota(drv As DataGridViewRow, valor As Boolean)
      Try

         Dim Dt As dsAFIP.CitiVentasAlicuotasDataTable = DirectCast(Me.dgvAlicuotas.DataSource, dsAFIP.CitiVentasAlicuotasDataTable)
         For Each dr As dsAFIP.CitiVentasAlicuotasRow In Dt.Rows
            If dr.IdSucursal = Integer.Parse(drv.Cells("dgvDetalle_IdSucursal").Value.ToString()) And
               dr.IdTipoComprobante = drv.Cells("dgvDetalle_IdTipoComprobante").Value.ToString() And
               dr.Letra = drv.Cells("dgvDetalle_Letra").Value.ToString() And
               dr.CentroEmisor = Integer.Parse(drv.Cells("dgvDetalle_CentroEmisor").Value.ToString()) And
               dr.NumeroComprobante = Long.Parse(drv.Cells("dgvDetalle_NumeroComprobante").Value.ToString()) Then
               dr.Proceso = valor

            End If
         Next
      Catch ex As Exception
         Throw
      End Try

   End Sub

#End Region

End Class