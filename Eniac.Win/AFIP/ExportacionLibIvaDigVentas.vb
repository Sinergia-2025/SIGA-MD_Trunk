Public Class ExportacionLibIvaDigVentas

#Region "Campos"

   Private _publicos As Publicos
   Private _libivadigital As LibroIvaDigitalVentas
   Private _libivadigitalalicuotas As LibroIvaDigitalVentasAlicuotas
   Private _libivadigitalcomprobantesanulados As LibroIvaDigitalVentasComprobantesAnulados
   Private _ds As DataSet
   Private _estaCargando As Boolean
   Private _comprobantesConImporte0 As StringBuilder

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(Sub() dtpPeriodoFiscal.Value = Date.Today.PrimerDiaMes())
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

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbExportar_Click(sender As Object, e As EventArgs) Handles tsbExportar.Click
      TryCatched(
      Sub()
         If ugComprobantes.Rows.Count = 0 Then Exit Sub
         If String.IsNullOrEmpty(txtArchivoDestinoComprobantes.Text.Trim()) Then
            ShowMessage("No Indico el Archivo Destino.")
            txtArchivoDestinoComprobantes.Focus()
            Exit Sub
         End If
         ''''Dim RegistrosErroneos As Boolean = False
         ''''For Each dr As UltraGridRow In Me.ugComprobantes.Rows
         ''''   If Not Boolean.Parse(dr.Cells("Procesar").Value.ToString()) Then
         ''''      RegistrosErroneos = True
         ''''      Exit For
         ''''   End If
         ''''Next
         ''''For Each dr As UltraGridRow In Me.ugAlicuotas.Rows
         ''''   If Not Boolean.Parse(dr.Cells("Procesar").Value.ToString()) Then
         ''''      RegistrosErroneos = True
         ''''      Exit For
         ''''   End If
         ''''Next
         ''''For Each dr As UltraGridRow In Me.ugComprobantesAnulados.Rows
         ''''   If Not Boolean.Parse(dr.Cells("Procesar").Value.ToString()) Then
         ''''      RegistrosErroneos = True
         ''''      Exit For
         ''''   End If
         ''''Next
         ''''If RegistrosErroneos Then
         ''''   If MessageBox.Show("Existen registros erróneos, ¿desea continuar con la exportación?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
         ''''      Exit Sub
         ''''   End If
         ''''End If

         Using frmConfirmar = New ExportarCitiVentasConfirmacion()
            If frmConfirmar.ShowDialog(Me,
                                    ugComprobantes.DataSource(Of DataTable),
                                    ugAlicuotas.DataSource(Of DataTable),
                                    ugComprobantesAnulados.DataSource(Of DataTable)) = DialogResult.OK Then
               ExportarDatos()
               CerrarPeriodoFiscal()

               ''ShowMessage(String.Format("Se Exportaron {0} comprobantes y {1} alicuotas EXITOSAMENTE !!!",
               ''                       _citi.CantidadDeLineasaProcesar, _citiAlicuotas.CantidadDeLineasaProcesar))
            Else
               ShowMessage("Ha cancelado la exportación.")
            End If
         End Using

         ''ExportarDatos()
         ''CerrarPeriodoFiscal()
      End Sub)
   End Sub
   Private Sub tsbVerRegistrosConErrores_Click(sender As Object, e As EventArgs) Handles tsbVerRegistrosConErrores.Click
      TryCatched(
      Sub()
         Dim dt As DataTable = DirectCast(Me.ugComprobantes.DataSource, DataTable)
         Dim dtError As DataTable = dt.Clone()
         Dim drError As DataRow
         For Each dr As DataRow In dt.Rows
            If Not String.IsNullOrEmpty(dr("TipoError").ToString()) Then
               drError = dtError.NewRow
               drError.ItemArray = dr.ItemArray
               dtError.Rows.Add(drError)
            End If
         Next
         Using cg = New ConsultaGenerica(dtError)
            cg.ShowDialog(Me)
         End Using
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

   Private Sub ugComprobantes_CellChange(sender As Object, e As CellEventArgs) Handles ugComprobantes.CellChange
      TryCatched(Sub() ugComprobantes.UpdateData())
   End Sub

   Private Sub ugComprobantes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugComprobantes.InitializeRow
      TryCatched(
      Sub()
         If ugComprobantes.Rows.Count = 0 Or _estaCargando Then Exit Sub

         '# Si el comprobante ya esta anulado, no dejo tildarlo ya que hay una solapa exclusiva para Anulados
         If Boolean.Parse(e.Row.Cells("EstaAnulado").Value.ToString()) Then
            e.Row.Cells("Procesar").Value = False
            ugComprobantes.UpdateData()
            ShowMessage("Este comprobante se encuentra ANULADO. No puede procesarse.")
         End If

         '# Si el comprobante tiene error , no dejo tildarlo
         If Not String.IsNullOrEmpty(e.Row.Cells("TipoError").Value.ToString()) Then
            e.Row.Cells("Procesar").Value = False
            ugComprobantes.UpdateData()
            ShowMessage("Este comprobante tiene errores. No puede procesarse.")
         End If

         For Each rowComprobante As DataRow In _ds.Tables("Comprobantes").Rows
            For Each rowAlicuota As DataRow In rowComprobante.GetChildRows(_ds.Relations("ComprobantesAlicuotasRelacion"))
               ugComprobantes.UpdateData()
               rowAlicuota("Procesar") = rowComprobante("Procesar")
               ugAlicuotas.UpdateData()
            Next
         Next
      End Sub)
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         _estaCargando = True

         CargaGrillaDetalle()

         If ugComprobantes.Rows.Count > 0 Then
            btnConsultar.Focus()
            chbTodos.Enabled = True
            tsbExportar.Enabled = True
         Else
            tsbExportar.Enabled = False
            chbTodos.Enabled = False
            ShowMessage("No hay registros que cumplan con la selección !!!")
         End If
      End Sub)
      _estaCargando = False
      tssRegistros.Text = TextoRegistros()

   End Sub
   Private Sub btnExaminarComprobantes_Click(sender As Object, e As EventArgs) Handles btnExaminarComprobantes.Click
      TryCatched(
      Sub()
         Using DialogoGuardarArchivo = New SaveFileDialog With {
               .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop,
               .Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*",
               .FilterIndex = 1,
               .RestoreDirectory = True,
               .FileName = "LibroIvaVentas_" & dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"
         }
            If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK AndAlso DialogoGuardarArchivo.FileName <> "" Then
               txtArchivoDestinoComprobantes.Text = DialogoGuardarArchivo.FileName
            End If
         End Using
      End Sub)
   End Sub
   Private Sub btnExaminarAlicuotas_Click(sender As Object, e As EventArgs) Handles btnExaminarAlicuotas.Click
      TryCatched(
      Sub()
         Using DialogoGuardarArchivo = New SaveFileDialog With {
               .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop,
               .Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*",
               .FilterIndex = 1,
               .RestoreDirectory = True,
               .FileName = "LibroIvaVentasAlicuotas_" & dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"
         }
            If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK AndAlso DialogoGuardarArchivo.FileName <> "" Then
               txtArchivoDestinoAlicuotas.Text = DialogoGuardarArchivo.FileName
            End If
         End Using
      End Sub)
   End Sub
   Private Sub btnExaminarComprobantesAnulados_Click(sender As Object, e As EventArgs) Handles btnExaminarComprobantesAnulados.Click
      TryCatched(
      Sub()
         Using DialogoGuardarArchivo = New SaveFileDialog With {
              .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop,
              .Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*",
              .FilterIndex = 1,
              .RestoreDirectory = True,
              .FileName = "LibroIvaVentasComprobantesAnulados_" & dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"
          }

            If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK AndAlso DialogoGuardarArchivo.FileName <> "" Then
               txtArchivoDestinoAlicuotas.Text = DialogoGuardarArchivo.FileName
            End If
         End Using
      End Sub)
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      TryCatched(
      Sub()
         Dim dt As DataTable = DirectCast(Me.ugComprobantes.DataSource, DataTable)
         For Each dr As DataRow In dt.Rows
            If String.IsNullOrEmpty(dr("TipoError").ToString()) AndAlso Not Boolean.Parse(dr("EstaAnulado").ToString()) Then
               dr("Procesar") = Me.chbTodos.Checked
            End If
         Next
         Dim dt2 As DataTable = DirectCast(Me.ugAlicuotas.DataSource, DataTable)
         For Each dr2 As DataRow In dt2.Rows
            If String.IsNullOrEmpty(dr2("TipoError").ToString()) Then
               dr2("Procesar") = Me.chbTodos.Checked
            End If
         Next
      End Sub)
   End Sub
   Private Sub tbcRegistros_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcRegistros.SelectedIndexChanged
      TryCatched(Sub() tssRegistros.Text = TextoRegistros())
   End Sub

#End Region

#Region "Métodos"
   Private Sub CerrarPeriodoFiscal()
      Dim rPeriodoFiscal = New Reglas.PeriodosFiscales()
      Dim oPeriodoFiscal = rPeriodoFiscal.GetUno(actual.Sucursal.IdEmpresa, Integer.Parse(dtpPeriodoFiscal.Value.ToString("yyyyMM")))

      If oPeriodoFiscal IsNot Nothing Then
         oPeriodoFiscal.VentasHabilitadas = False
         rPeriodoFiscal.Actualizar(oPeriodoFiscal)
      End If
   End Sub

   Private Function TextoRegistros() As String
      '# Registros
      If tbcRegistros.SelectedTab Is TbpComprobantes Then
         Return String.Format("{0} Comprobantes", ugComprobantes.Rows.Count.ToString())
      ElseIf tbcRegistros.SelectedTab Is tbpAlicuotas Then
         Return String.Format("{0} Alícuotas", ugAlicuotas.Rows.Count.ToString())
      Else
         Return String.Format("{0} Comprobantes Anulados", ugComprobantesAnulados.Rows.Count.ToString())
      End If
   End Function

   Private Function ValidarComprobantes(row As UltraGridRow) As Boolean

      '# Si el comprobante ya esta anulado, no dejo tildarlo ya que hay una solapa exclusiva para Anulados
      If Boolean.Parse(row.Cells("EstaAnulado").Value.ToString()) Then
         row.Cells("Procesar").Value = False
         ShowMessage("Este comprobante se encuentra ANULADO. No puede procesarse.")
         ugComprobantes.UpdateData()
         ugAlicuotas.UpdateData()
         Return False
      End If

      '# Si el comprobante tiene error , no dejo tildarlo
      If Not String.IsNullOrEmpty(row.Cells("TipoError").Value.ToString()) Then
         row.Cells("Procesar").Value = False
         ShowMessage("Este comprobante tiene errores. No puede procesarse.")
         ugComprobantes.UpdateData()
         ugAlicuotas.UpdateData()
         Return False
      End If

      Return True
   End Function

   Private Sub ExportarDatos()
      'Dim stb = New StringBuilder()
      tbcRegistros.Focus()

      '# Exportación de Comprobantes
      For Each li As LibroIvaDigitalVentasLinea In _libivadigital.Lineas
         For Each dr As DataRow In DirectCast(ugComprobantes.DataSource, DataTable).Rows
            If li.Linea = Long.Parse(dr("Linea").ToString()) Then
               li.Procesar = Boolean.Parse(dr("Procesar").ToString())
               Exit For
            End If
         Next
      Next

      '# Si no existen registros para generar, le aviso al usuario que no se va a generar el archivo
      If _libivadigital.CantidadDeLineasaProcesar = 0 Then
         ShowMessage(String.Format("No hay comprobantes seleccionados. No se generará el archivo LibroIvaVentas_{0}", dtpPeriodoFiscal.Value.ToString("yyyyMM")))
      Else
         'stb.AppendFormat("Realmente desea generar el archivo para los {0} Comprobantes?", _libivadigital.CantidadDeLineasaProcesar)
         'If ShowPregunta(stb.ToString()) = Windows.Forms.DialogResult.Yes Then
         _libivadigital.GrabarArchivo(txtArchivoDestinoComprobantes.Text)
         ShowMessage(String.Format("Se Exportaron {0} Comprobantes EXITOSAMENTE !!!", _libivadigital.CantidadDeLineasaProcesar.ToString()))
         'Else
         '   ShowMessage("Ha cancelado la exportación.")
         'End If
      End If

      'Dim stb1 As StringBuilder = New StringBuilder()

      '# Exportación de Alícuotas
      For Each li As LibroIvaDigitalVentasAlicuotasLinea In Me._libivadigitalalicuotas.Lineas
         For Each dr As DataRow In DirectCast(Me.ugAlicuotas.DataSource, DataTable).Rows
            If li.Linea = Long.Parse(dr("Linea").ToString()) Then
               li.Procesar = Boolean.Parse(dr("Procesar").ToString())
               Exit For
            End If
         Next
      Next

      '# Si no existen registros para generar, le aviso al usuario que no se va a generar el archivo
      If _libivadigitalalicuotas.CantidadDeLineasaProcesar = 0 Then
         ShowMessage(String.Format("No hay alícuotas seleccionadas. No se generará el archivo LibroIvaVentasAlicuotas_{0}", Me.dtpPeriodoFiscal.Value.ToString("yyyyMM")))
      Else
         'stb1.AppendFormat("Realmente desea generar el archivo para los {0} Comprobantes Alícuotas?", Me._libivadigitalalicuotas.CantidadDeLineasaProcesar)
         'If ShowPregunta(stb1.ToString()) = Windows.Forms.DialogResult.Yes Then
         _libivadigitalalicuotas.GrabarArchivo(txtArchivoDestinoAlicuotas.Text)
         ShowMessage(String.Format("Se Exportaron {0} Comprobantes Alícuotas EXITOSAMENTE !!!", _libivadigitalalicuotas.CantidadDeLineasaProcesar.ToString()))
         'Else
         '   ShowMessage("Ha cancelado la exportación.")
         'End If
      End If
      'stb = New StringBuilder

      '# Exportación de Comprobantes Anulados
      For Each li As LibroIvaDigitalVentasComprobantesAnuladosLinea In Me._libivadigitalcomprobantesanulados.Lineas
         For Each dr As DataRow In DirectCast(Me.ugComprobantesAnulados.DataSource, DataTable).Rows
            If li.Linea = Long.Parse(dr("Linea").ToString()) Then
               li.Procesar = Boolean.Parse(dr("Procesar").ToString())
               Exit For
            End If
         Next
      Next

      '# Si no existen registros para generar, le aviso al usuario que no se va a generar el archivo
      If _libivadigitalcomprobantesanulados.CantidadDeLineasaProcesar = 0 Then
         ShowMessage(String.Format("No hay comprobantes anulados seleccionados. No se generará el archivo LibroIvaVentasComprobantesAnulados_{0}", Me.dtpPeriodoFiscal.Value.ToString("yyyyMM")))
      Else
         'stb.AppendFormat("Realmente desea generar el archivo para los {0} Comprobantes Anulados?", Me._libivadigitalcomprobantesanulados.CantidadDeLineasaProcesar)
         'If ShowPregunta(stb.ToString()) = Windows.Forms.DialogResult.Yes Then
         _libivadigitalcomprobantesanulados.GrabarArchivo(txtArchivoDestinoComprobantesAnulados.Text)
         ShowMessage(String.Format("Se Exportaron {0} Comprobantes Anulados EXITOSAMENTE !!!", _libivadigitalcomprobantesanulados.CantidadDeLineasaProcesar.ToString()))
         'Else
         '   ShowMessage("Ha cancelado la exportación.")
         'End If
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      dtpPeriodoFiscal.Value = Date.Today.PrimerDiaMes()

      ugComprobantesAnulados.ClearFilas()
      ugAlicuotas.ClearFilas()
      ugComprobantes.ClearFilas()

      txtArchivoDestinoComprobantes.Text = String.Empty
      txtTotalComp.Text = "0.00"
      txtSubtotalComp.Text = "0.00"
      txtImpuestosComp.Text = "0.00"

      txtArchivoDestinoAlicuotas.Text = String.Empty
      txtTotalAlic.Text = "0.00"
      txtSubtotalAlic.Text = "0.00"
      txtImpuestosAlic.Text = "0.00"

      tsbExportar.Enabled = False
      tsbVerRegistrosConErrores.Enabled = False

      tbcRegistros.SelectedTab = TbpComprobantes

      tssRegistros.Text = "0 Registros"

   End Sub

   Private Sub CargaGrillaDetalle()
      Dim rVentas = New Reglas.Ventas()
      Dim periodoFiscal = Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM"))


      '# Procesamiento de los comprobantes
      ProcesarComprobantes(rVentas.GetParaExportarAFIP(periodoFiscal))

      '# Procesamiento de las alícuotas
      ProcesarAlicuotas(rVentas.GetParaExportarAFIPAlicuotas(periodoFiscal))

      '# Procesamiento de los comprobantes anulados
      ProcesarComprobantesAnulados(rVentas.GetParaExportarAFIPComprobantesAnulados(dtpPeriodoFiscal.Value))

      '# Creo la relación entre la tabla de Comprobantes y las alícuotas
      _ds = New DataSet
      _ds.Tables.Add("Comprobantes", DirectCast(ugComprobantes.DataSource, DataTable))
      _ds.Tables.Add("Alicuotas", DirectCast(ugAlicuotas.DataSource, DataTable))

      Dim Relacion = New DataRelation("ComprobantesAlicuotasRelacion",
                               {_ds.Tables("Comprobantes").Columns(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                _ds.Tables("Comprobantes").Columns(Entidades.Venta.Columnas.Letra.ToString()),
                                _ds.Tables("Comprobantes").Columns(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                                _ds.Tables("Comprobantes").Columns(Entidades.Venta.Columnas.NumeroComprobante.ToString())},
                               {_ds.Tables("Alicuotas").Columns(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                _ds.Tables("Alicuotas").Columns(Entidades.Venta.Columnas.Letra.ToString()),
                                _ds.Tables("Alicuotas").Columns(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                                _ds.Tables("Alicuotas").Columns(Entidades.Venta.Columnas.NumeroComprobante.ToString())})
      _ds.Relations.Add(Relacion)

      '# Crear LibroF
      CrearLIBROIVADIGITALVentas()

      FormatearGrillas()

      '# Si existieron comprobantes con importe $0 (por ej. eFactura), informo al usuario que fueron excluidos y NO van a exportarse en el libro de IVA Digital
      If Not String.IsNullOrEmpty(_comprobantesConImporte0.ToString()) Then
         Dim msg = New StringBuilder()
         With msg
            .AppendFormatLine("Los siguientes comprobantes fueron excluidos por tener Importe $0 y NO van a exportarse").AppendLine()
            .AppendFormatLine("{0}", _comprobantesConImporte0.ToString())
         End With

         ShowMessage(msg.ToString())
      End If

   End Sub

   Private Sub CrearLIBROIVADIGITALVentas()
      _libivadigital = New LibroIvaDigitalVentas()
      _libivadigitalalicuotas = New LibroIvaDigitalVentasAlicuotas()
      _libivadigitalcomprobantesanulados = New LibroIvaDigitalVentasComprobantesAnulados

      Dim dt = DirectCast(ugComprobantes.DataSource, DataTable)
      Dim dt2 = DirectCast(ugAlicuotas.DataSource, DataTable)
      Dim dt3 = DirectCast(ugComprobantesAnulados.DataSource, DataTable)

      chbTodos.Checked = True

      '# Marco todos los registros para procesar
      For Each dr As DataRow In dt.Rows
         dr("Procesar") = chbTodos.Checked
      Next
      'For Each dr As DataRow In dt2.Rows
      '   dr("Procesar") = Me.chbTodos.Checked
      'Next
      For Each dr As DataRow In dt3.Rows
         dr("Procesar") = chbTodos.Checked
      Next

      '# Controlo que la cantidad de alicuotas sea la correcta para las notas de debito de cheques rechazados
      For Each dr As DataRow In dt.Rows
         Dim idTipoComprobante As String = dr(Entidades.Venta.Columnas.IdTipoComprobante.ToString()).ToString()
         If (idTipoComprobante.Contains("eNDEB") Or idTipoComprobante.Contains("NDEBCHEQRECH")) Then
            dr("CantidadRealSinAlicuota") = GetCantidadRealSinAlicuota(dt2,
                                                                     dr.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                                                     dr.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                                                     dr.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                                                                     dr.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()))
            dr("CantidadDeAlicuotas") = GetCantidadDeAlicuotas(dt2,
                                                                  dr.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                                                  dr.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                                                  dr.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                                                                  dr.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()))
         End If
      Next

      '# Armo los libros
      LIBIVADIGITALVentas(dt)
      LIBIVADIGITALVentasAlicuotas(dt2)
      LIBROIVADIGITALVentasComprobantesAnulados(dt3)

      'Catch ex As Exception
      'Throw
      'Finally
      '   Me.tspBarra.Value = 0
      '   Me.tspBarra.Visible = False
      'End Try


   End Sub

   Private Sub ProcesarComprobantes(dt As DataTable)

      Dim descSubTotal As Decimal = 0
      Dim descTotalImpuestos As Decimal = 0
      Dim descTotal As Decimal = 0
      Dim descTotalNeto As Decimal = 0
      _comprobantesConImporte0 = New StringBuilder()

      '# Procesamiento de la tabla
      Dim linea = 1I

      dt.Columns.Add("Procesar", GetType(Boolean))
      dt.Columns.Add("EstaAnulado", GetType(Boolean))
      dt.Columns.Add("Linea", GetType(Integer))
      dt.Columns.Add("CantidadRealSinAlicuota", GetType(Decimal))
      dt.Columns.Add("CantidadDeAlicuotas", GetType(Integer))
      dt.Columns.Add("Percepciones", GetType(Decimal))
      dt.Columns.Add("ImpuestoInterno", GetType(Decimal))
      dt.Columns.Add("FechaVto", GetType(Date))
      dt.Columns.Add("TipoError", GetType(String))

      For Each dr As DataRow In dt.Rows

         ''''If CDec(dr("Importe")) = 0 Then

         ''''   '# Si el comprobante es una factura con importe $0, NO debe exportarse y se le va a informar al usuario por pantalla.
         ''''   Dim comp As String = String.Format("{0} {1} {2:0000}-{3:00000000}",
         ''''                                            dr("DescripcionAbrev"),
         ''''                                            dr("Letra"),
         ''''                                            dr("CentroEmisor"),
         ''''                                            dr("NumeroComprobante"))
         ''''   With _comprobantesConImporte0
         ''''      .AppendFormatLine("{0}", comp)
         ''''   End With

         ''''Else
         dr("Linea") = linea

         If String.IsNullOrEmpty(dr(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).ToString()) Then
            dr(Entidades.Cliente.Columnas.TipoDocCliente.ToString()) = ""
            dr(Entidades.Cliente.Columnas.NroDocCliente.ToString()) = 0
         Else
            If String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.NroDocCliente.ToString()).ToString()) Then
               dr(Entidades.Cliente.Columnas.NroDocCliente.ToString()) = 0
            End If
         End If

         If String.IsNullOrEmpty(dr("IdAFIPTipoComprobante").ToString()) Then
            dr("IdAFIPTipoComprobante") = 0
         End If
         If String.IsNullOrEmpty(dr("IdAFIPTipoDocumento").ToString()) Then
            dr("IdAFIPTipoDocumento") = 0
         End If

         '# IVAs
         Dim IVA2100 As Decimal = Decimal.Parse(dr("IVA2100").ToString())
         Dim IVA1050 As Decimal = Decimal.Parse(dr("IVA1050").ToString())
         Dim IVA2700 As Decimal = Decimal.Parse(dr("IVA2700").ToString())
         Dim IVA0000 As Decimal = Decimal.Parse(dr("IVA0000").ToString())

         Dim cantidadDeAlicuotas As Integer = 0
         If IVA2100 <> 0 Then
            cantidadDeAlicuotas += 1
            dr("CantidadDeAlicuotas") = cantidadDeAlicuotas
         End If
         If IVA1050 <> 0 Then
            cantidadDeAlicuotas += 1
            dr("CantidadDeAlicuotas") = cantidadDeAlicuotas
         End If
         If IVA2700 <> 0 Then
            cantidadDeAlicuotas += 1
            dr("CantidadDeAlicuotas") = cantidadDeAlicuotas
         End If
         If IVA0000 <> 0 Then
            cantidadDeAlicuotas += 1
            dr("CantidadDeAlicuotas") = cantidadDeAlicuotas
         End If

         '# Percepciones
         Dim PGANA As Decimal = Decimal.Parse(dr("PGANA").ToString())
         Dim PIIBB As Decimal = Decimal.Parse(dr("PIIBB").ToString())
         Dim PIVA As Decimal = Decimal.Parse(dr("PIVA").ToString())
         Dim PVAR As Decimal = Decimal.Parse(dr("PVAR").ToString())

         dr("Importe") = IVA2100 + IVA1050 + IVA2700
         dr("Percepciones") = PGANA + PIIBB + PIVA + PVAR
         dr("ImpuestoInterno") = Decimal.Parse(dr("IMPINT").ToString())

         If dr("IdEstadoComprobante").ToString() = "ANULADO" Then
            dr(Entidades.Cliente.Columnas.NombreCliente.ToString()) = "** COMPROBANTE ANULADO **"
            dr("EstaAnulado") = True
            dr("ImporteBruto") = 0
            dr("Importe") = 0
            dr("Neto") = 0
            dr("Total") = 0
         Else
            dr("EstaAnulado") = False
         End If

         '# Fecha de Vencimiento
         dr("FechaVto") = Convert.ToDateTime(dr("Fecha")).AddDays(New Reglas.VentasFormasPago().GetUna(Integer.Parse(dr(Entidades.Venta.Columnas.IdFormasPago.ToString()).ToString())).Dias)

         'If Not String.IsNullOrWhiteSpace(dr("IncluyeFechaVencimiento").ToString()) Then
         '   drCl.IncluyeFechaVencimiento = Boolean.Parse(dr("IncluyeFechaVencimiento").ToString())
         'End If

         descTotalNeto = descTotalNeto + Convert.ToDecimal(dr("Neto"))
         descSubTotal = descSubTotal + Convert.ToDecimal(dr("ImporteBruto"))
         descTotalImpuestos = descTotalImpuestos + Convert.ToDecimal(dr("Importe"))
         descTotal = descTotal + Convert.ToDecimal(dr("Total"))

         linea += 1
         ''''End If
      Next

      txtSubtotalComp.Text = descTotalNeto.ToString("N2")
      txtImpuestosComp.Text = descTotalImpuestos.ToString("N2")
      txtTotalComp.Text = descTotal.ToString("N2")

      Dim dtFiltrado = dt.Select("Total <> 0").CopyToDataTable(whenEmpty:=Function() dt.Clone()) '# Solo exporto los comprobantes que tienen Importe > 0

      '# Luego del método .CopyToDataTable() pierden el orden, así que vuelvo a ordenar la tabla
      dtFiltrado.DefaultView.Sort = "Linea ASC"
      ugComprobantes.DataSource = dtFiltrado.DefaultView.ToTable()
      dtFiltrado.Dispose() '# Libero la tabla temporal

      txtArchivoDestinoComprobantes.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\LibroIvaVentas_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"

   End Sub

   Private Sub ProcesarAlicuotas(dt As DataTable)

      Dim linea As Integer = 1

      Dim descSubTotal As Decimal = 0
      Dim descTotalImpuestos As Decimal = 0
      Dim descTotal As Decimal = 0

      dt.Columns.Add("Procesar", GetType(Boolean))
      dt.Columns.Add("Linea", GetType(Integer))
      dt.Columns.Add("TipoError", GetType(String))

      For Each dr As DataRow In dt.Rows
         dr("Linea") = linea

         If String.IsNullOrEmpty(dr(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).ToString()) Then
            If String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.NroDocCliente.ToString()).ToString()) Then
               dr(Entidades.Cliente.Columnas.NroDocCliente.ToString()) = 0
            End If
         Else
            dr(Entidades.Cliente.Columnas.TipoDocCliente.ToString()) = ""
            dr(Entidades.Cliente.Columnas.NroDocCliente.ToString()) = 0
         End If

         If String.IsNullOrEmpty(dr("IdAFIPTipoComprobante").ToString()) Then
            dr("IdAFIPTipoComprobante") = 0
         End If
         If String.IsNullOrEmpty(dr("IdAFIPTipoDocumento").ToString()) Then
            dr("IdAFIPTipoDocumento") = 0
         End If

         descSubTotal = descSubTotal + Convert.ToDecimal(dr("Neto"))
         descTotalImpuestos = descTotalImpuestos + Convert.ToDecimal(dr("Importe"))
         descTotal = descTotal + Convert.ToDecimal(dr("Total"))

         linea += 1

      Next

      txtSubtotalAlic.Text = descSubTotal.ToString("N2")
      txtImpuestosAlic.Text = descTotalImpuestos.ToString("N2")
      txtTotalAlic.Text = descTotal.ToString("N2")

      Me.ugAlicuotas.DataSource = dt

      Me.txtArchivoDestinoAlicuotas.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\LibroIvaVentasAlicuotas_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"

   End Sub

   Private Sub ProcesarComprobantesAnulados(dt As DataTable)

      '# Procesamiento de la tabla
      Dim linea As Integer = 1

      Dim subTotal As Decimal
      Dim importeImpuestos As Decimal
      Dim importeTotal As Decimal

      dt.Columns.Add("Procesar", GetType(Boolean))
      dt.Columns.Add("Linea", GetType(Integer))
      dt.Columns.Add("TipoError", GetType(String))

      For Each dr As DataRow In dt.Rows
         dr("Linea") = linea

         If String.IsNullOrEmpty(dr(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).ToString()) Then
            dr(Entidades.Cliente.Columnas.TipoDocCliente.ToString()) = ""
            dr(Entidades.Cliente.Columnas.NroDocCliente.ToString()) = 0
         Else
            If String.IsNullOrWhiteSpace(dr(Entidades.Cliente.Columnas.NroDocCliente.ToString()).ToString()) Then
               dr(Entidades.Cliente.Columnas.NroDocCliente.ToString()) = 0
            End If
         End If

         subTotal = subTotal + Convert.ToDecimal(dr(Entidades.Venta.Columnas.SubTotal.ToString()))
         importeImpuestos = importeImpuestos + Convert.ToDecimal(dr(Entidades.Venta.Columnas.TotalImpuestos.ToString()))
         importeTotal = importeTotal + Convert.ToDecimal(dr(Entidades.Venta.Columnas.ImporteTotal.ToString()))

         linea += 1
      Next

      Me.txtSubTotalCompAnulados.Text = subTotal.ToString("N2")
      Me.txtImpuestosCompAnulados.Text = importeImpuestos.ToString("N2")
      Me.txtTotalCompAnulados.Text = importeTotal.ToString("N2")

      Me.ugComprobantesAnulados.DataSource = dt

      Me.txtArchivoDestinoComprobantesAnulados.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\LibroIvaVentasComprobantesAnulados_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"

   End Sub
   Private Function GetCantidadRealSinAlicuota(dt As DataTable,
                                               idTipoComprobante As String, letra As String, centroEmisor As Integer, numero As Long) As Decimal
      'realizo una validación sobre los cheques rechazados ya que tienen 2 alicuotas pero una esta en cero
      'por ello si el tipo de comprobante en ND y el importe y alicuota son 0 entonces

      Return dt.AsEnumerable.Where(Function(dr) dr.Field(Of String)("IdTipoComprobante") = idTipoComprobante And dr.Field(Of String)("Letra") = letra And
                                                dr.Field(Of Integer)("CentroEmisor") = centroEmisor And dr.Field(Of Long)("NumeroComprobante") = numero And
                                                dr.Field(Of Decimal)("Alicuota") = 0 And dr.Field(Of Decimal)("Importe") = 0).
                             Sum(Function(dr) dr.Field(Of Decimal)("Neto"))

      ''Dim var As EnumerableRowCollection = From r In dt.AsEnumerable Select r
      ''                                     Where r("IdTipoComprobante").ToString() = idTipoComprobante And Convert.ToInt32(r("CentroEmisor")) = centroEmisor And Convert.ToInt32(r("NumeroComprobante")) = numero

      ''Dim ali As Decimal = 0

      ''For Each f As DataRow In var
      ''   If Convert.ToInt32(f("Alicuota")) = 0 And Convert.ToInt32(f("Importe")) = 0 Then
      ''      ali += Convert.ToInt32(f("Neto"))
      ''   End If
      ''Next

      ''Return ali

   End Function

   Private Function GetCantidadDeAlicuotas(dt As DataTable,
                                           idTipoComprobante As String, letra As String, centroEmisor As Integer, numero As Long) As Integer
      Return dt.AsEnumerable.Count(Function(dr) dr.Field(Of String)("IdTipoComprobante") = idTipoComprobante And dr.Field(Of String)("Letra") = letra And
                                                dr.Field(Of Integer)("CentroEmisor") = centroEmisor And dr.Field(Of Long)("NumeroComprobante") = numero)
   End Function

   Private Sub LIBIVADIGITALVentas(dt As DataTable)
      Dim linea As LibroIvaDigitalVentasLinea

      tspBarra.Visible = True
      tspBarra.Minimum = 0
      tspBarra.Maximum = dt.Select().MaxSecure(Function(dr) dr.Field(Of Integer)("Linea")).IfNull()
      tspBarra.Value = 0

      'Array.ForEach(dt.Select(), Sub(dr) Console.WriteLine(dr("Linea")))

      For Each dr As DataRow In dt.Rows

         Me.tspBarra.Value = Convert.ToInt32(dr("Linea")) - 1

         '# Si esta anulada paso al proximo registro y no lo genero
         If Not String.IsNullOrEmpty(dr("EstaAnulado").ToString()) AndAlso Boolean.Parse(dr("EstaAnulado").ToString()) Then
            dr("Procesar") = False
            Continue For
         End If
         If Not Boolean.Parse(dr("Procesar").ToString()) Then
            Continue For
         End If

         linea = New LibroIvaDigitalVentasLinea()

         linea.Linea = Convert.ToInt32(dr("Linea"))

         '01 - desde 001 hasta 008 / Númerico / Tam = 8 / Observaciones = Fto. AAAAMMDD
         linea.FechaDelComprobante = Date.Parse(dr("Fecha").ToString())
         '02 - desde 009 hasta 011 / Númerico / Tam = 3 / Observaciones = Según tabla de comprobantes
         linea.TipoDeComprobante = Convert.ToInt32(dr("IdAFIPTipoComprobante"))
         '03 - desde 012 hasta 016 / Númerico / Tam = 5 / Observaciones = 
         linea.PuntoDeVenta = Convert.ToInt32(dr("CentroEmisor"))
         '04 - desde 017 hasta 036 / Númerico / Tam = 20 / Observaciones = 
         linea.NroDeComprobante = Convert.ToDecimal(dr("NumeroComprobante"))
         '05 - desde 037 hasta 056 / Númerico / Tam = 20 / Observaciones = 
         linea.NroDeComprobanteHasta = Convert.ToDecimal(dr("NumeroComprobante"))
         '06 - desde 057 hasta 058 / Númerico / Tam = 2 / Observaciones = Según tabla de documentos
         If String.IsNullOrEmpty(dr("IdAFIPTipoDocumentoTipoCbte").ToString()) Then
            If String.IsNullOrEmpty(dr("CUIT").ToString()) Then
               'Reemplazar los 1000 por el parametro que hace Irene.
               'Aunque NO tenga DNI, debe informarlo, el registro NO entra porque Legalmente no puede hacer. Se vera con el cliente como solucionarlo
               If Convert.ToInt32(dr("IdAFIPTipoDocumento")) > 0 Or Convert.ToDecimal(dr("Total")) >= Reglas.Publicos.Facturacion.FacturacionControlaTopeCF Then
                  linea.CodigoDeDocumentoIdentificatorioDelComprador = Convert.ToInt32(dr("IdAFIPTipoDocumento"))
               Else
                  linea.CodigoDeDocumentoIdentificatorioDelComprador = 99 'si no identificamos un tipo de documento le enviamos fijo el 99 (Sin identificar/venta global diaria)
               End If
            Else
               linea.CodigoDeDocumentoIdentificatorioDelComprador = 80
            End If
         Else
            linea.CodigoDeDocumentoIdentificatorioDelComprador = Convert.ToInt32(dr("IdAFIPTipoDocumentoTipoCbte"))
         End If
         '07 - desde 059 hasta 078 / AlfaNúmerico / Tam = 20 / Observaciones = 
         If String.IsNullOrEmpty(dr("CUIT").ToString()) Then
            linea.NroDeIdentificacionDelComprador = Convert.ToInt64(dr("NroDocCliente"))
         Else
            linea.NroDeIdentificacionDelComprador = Long.Parse(dr("CUIT").ToString().Replace("-"c, ""))
         End If
         '08 - desde 079 hasta 108 / AlfaNúmerico / Tam = 30 / Observaciones = 
         linea.ApellidoYNombreODenominacionDelComprador = Publicos.NormalizarDescripcion(dr("NombreCliente").ToString())
         '09 - desde 109 hasta 123 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         linea.ImporteTotalDeLaOperacion = Convert.ToDecimal(dr("Total"))
         '10 - desde 124 hasta 138 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         linea.TotalDeConceptosQueNoIntegranElPrecioNeto = Convert.ToDecimal(dr("IVA0000"))
         '11 - desde 139 hasta 153 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImpuestoLiquidadoARNIOPercANoCategoriz = 0
         '12 - desde 154 hasta 168 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         If Convert.ToInt32(dr("CantidadDeAlicuotas")) = 0 Then
            linea.ImporteDeOperacionesExentas = Convert.ToDecimal(dr("CantidadRealSinAlicuota"))
         Else
            linea.ImporteDeOperacionesExentas = 0
         End If
         '13 - desde 169 hasta 183 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDePercepOPagosACtaDeImpuestoNac = Convert.ToDecimal(dr("PGANA"))
         '14 - desde 184 hasta 198 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDePercepcionesDeIngresosBrutos = Convert.ToDecimal(dr("PIIBB"))
         '15 - desde 199 hasta 213 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDePercepcionesDeImpuestosMunicipales = Convert.ToDecimal(dr("PVAR"))
         '16 - desde 214 hasta 228 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDeImpuestosInternos = Convert.ToDecimal(dr("ImpuestoInterno"))
         '17 - desde 229 hasta 231 / Alfabetico / Tam = 3 / Observaciones =  Según tabla Monedas
         linea.CodigoDeMoneda = "PES"
         '18 - desde 232 hasta 241 / Númerico / Tam = 10 / Observaciones =  4 enteros 6 decimales sin punto decimal
         linea.TipoDeCambio = 1
         '19 - desde 242 hasta 242 / Númerico / Tam = 1 / Observaciones = 
         linea.CantidadDeAlicuotasDeIVA = Convert.ToInt32(dr("CantidadDeAlicuotas"))
         '20 - desde 243 hasta 243 / Alfabetico / Tam = 1 / Observaciones =   Según tabla Codigo_Operación, de No Corresponder v
         If linea.ImporteDeOperacionesExentas <> 0 Then
            linea.CodigoDeOperacion = "E" 'OPERACIONES EXENTAS
         Else
            If Convert.ToDecimal(dr("IVA0000")) <> 0 Then
               linea.CodigoDeOperacion = "N"
            Else
               linea.CodigoDeOperacion = "0"
            End If

         End If
         '21 - desde 244 hasta 258 / Númerico / Tam = 15 / Observaciones = 
         linea.OtrosTributos = 0
         '22 - desde 259 hasta 266 / Númerico / Tam = 8 / Observaciones =  Fto: AAAAMMDD

         Dim comprobante As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno(dr("IdTipoComprobante").ToString())

         If String.IsNullOrEmpty(dr("IncluyeFechaVencimiento").ToString()) Then
            If Not comprobante.EsFiscal Then
               If linea.TipoDeComprobante = 60 Or linea.TipoDeComprobante = 61 Then
                  linea.FechaDeVencimiento = Nothing
               Else
                  linea.FechaDeVencimiento = Date.Parse(dr("FechaVto").ToString())
               End If
            Else
               linea.FechaDeVencimiento = Nothing
            End If
         Else
            linea.FechaDeVencimiento = If(Boolean.Parse(dr("IncluyeFechaVencimiento").ToString()), Date.Parse(dr("FechaVto").ToString()), Nothing)
         End If

         _libivadigital.Lineas.Add(linea)

         If linea.TieneError Then
            tsbVerRegistrosConErrores.Enabled = True
            ugComprobantes.Rows(linea.Linea - 1).CellAppearance.BackColor = Color.LightSalmon
            ugComprobantes.Rows(linea.Linea - 1).Cells("TipoError").Value = linea.TipoError
            dr("Procesar") = False
            ugComprobantes.Rows(linea.Linea - 1).Cells("Linea").Activation = Activation.ActivateOnly
         End If

         '# Para cada linea le digo si la procesa cuando va a grabar el archivo o no.
         linea.Procesar = Boolean.Parse(dr("Procesar").ToString())
      Next
   End Sub

   Private Sub LIBIVADIGITALVentasAlicuotas(dt As DataTable)

      Dim linea As LibroIvaDigitalVentasAlicuotasLinea

      For Each dr As DataRow In dt.Rows

         linea = New LibroIvaDigitalVentasAlicuotasLinea()

         linea.Linea = Convert.ToInt32(dr("Linea"))

         '01 - desde 001 hasta 003 / Númerico / Tam = 3 / Observaciones = Según tabla de comprobantes
         linea.TipoDeComprobante = Convert.ToInt32(dr("IdAFIPTipoComprobante"))
         '02 - desde 004 hasta 008 / Númerico / Tam = 5 / Observaciones = 
         linea.PuntoDeVenta = Convert.ToInt32(dr("CentroEmisor"))
         '03 - desde 009 hasta 028 / Númerico / Tam = 20 / Observaciones = 
         linea.NroDeComprobante = Convert.ToDecimal(dr("NumeroComprobante"))
         '04 - desde 029 hasta 043 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         linea.ImporteNetoGravado = Convert.ToDecimal(dr("Neto"))
         '05 - desde 044 hasta 047 / Númerico / Tam = 4 / Observaciones =  Según tabla Alícuotas
         linea.AlicuotaDeIVA = Convert.ToInt32(dr("IdAFIPIVA"))
         'si la alicuota es cero el importe neto gravado tiene que ser cero
         If Convert.ToInt32(dr("IdAFIPIVA")) = 3 Then
            linea.ImporteNetoGravado = 0
         End If
         '06 - desde 148 hasta 062 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImpuestoLiquidado = Convert.ToDecimal(dr("Importe"))

         If String.IsNullOrEmpty(dr("IdAFIPTipoDocumentoTipoCbte").ToString()) Then
            If String.IsNullOrEmpty(dr("CUIT").ToString()) Then
               'Reemplazar los 1000 por el parametro que hace Irene.
               'Aunque NO tenga DNI, debe informarlo, el registro NO entra porque Legalmente no puede hacer. Se vera con el cliente como solucionarlo
               If Convert.ToInt32(dr("IdAFIPTipoDocumento")) > 0 Or Convert.ToDecimal(dr("Total")) >= Reglas.Publicos.Facturacion.FacturacionControlaTopeCF Then
                  linea.CodigoDeDocumentoIdentificatorioDelComprador = Convert.ToInt32(dr("IdAFIPTipoDocumento"))
               Else
                  linea.CodigoDeDocumentoIdentificatorioDelComprador = 99 'si no identificamos un tipo de documento le enviamos fijo el 99 (Sin identificar/venta global diaria)
               End If
            Else
               linea.CodigoDeDocumentoIdentificatorioDelComprador = 80
            End If
         Else
            linea.CodigoDeDocumentoIdentificatorioDelComprador = Convert.ToInt32(dr("IdAFIPTipoDocumentoTipoCbte"))
         End If

         Me._libivadigitalalicuotas.Lineas.Add(linea)

         If linea.TieneError Then
            Me.tsbVerRegistrosConErrores.Enabled = True
            Me.ugAlicuotas.Rows(linea.Linea - 1).CellAppearance.BackColor = Color.LightSalmon
            Me.ugAlicuotas.Rows(linea.Linea - 1).Cells("TipoError").Value = linea.TipoError
            Me.ugAlicuotas.Rows(linea.Linea - 1).Cells("Linea").Activation = Activation.ActivateOnly
            dr("Procesar") = False
         End If

         '# Manejo la relación entre la alícuota y su comprobante padre (a la inversa)
         '# Si el comprobante no se va a procesar porque está anulado o porque tiene errores, la alícuota tampoco debe procesarse
         For Each rowComprobante As DataRow In dr.GetParentRows(_ds.Relations("ComprobantesAlicuotasRelacion"))
            Me.ugComprobantes.UpdateData()
            dr("Procesar") = Boolean.Parse(rowComprobante("Procesar").ToString())
            linea.Procesar = Boolean.Parse(dr("Procesar").ToString())
            Me.ugAlicuotas.UpdateData()
         Next
      Next
   End Sub

   Private Sub LIBROIVADIGITALVentasComprobantesAnulados(dt As DataTable)

      Dim linea As LibroIvaDigitalVentasComprobantesAnuladosLinea

      Me.tspBarra.Visible = True
      Me.tspBarra.Minimum = 0
      Me.tspBarra.Maximum = dt.Rows.Count
      Me.tspBarra.Value = 0

      For Each dr As DataRow In dt.Rows

         Me.tspBarra.Value = Convert.ToInt32(dr("Linea")) - 1

         linea = New LibroIvaDigitalVentasComprobantesAnuladosLinea()
         linea.Linea = Convert.ToInt32(dr("Linea"))

         '01 - desde 001 hasta 008 / Númerico / Tam = 8 / Observaciones = Fto. AAAAMMDD
         linea.FechaDelComprobante = Date.Parse(dr("Fecha").ToString())
         '02 - desde 009 hasta 011 / Númerico / Tam = 3 / Observaciones = Según tabla de comprobantes
         linea.TipoDeComprobante = Convert.ToInt32(dr("IdAFIPTipoComprobante"))
         '03 - desde 012 hasta 016 / Númerico / Tam = 5 / Observaciones = 
         linea.PuntoDeVenta = Convert.ToInt32(dr("CentroEmisor"))
         '04 - desde 017 hasta 036 / Númerico / Tam = 20 / Observaciones = 
         linea.NroDeComprobante = Convert.ToDecimal(dr("NumeroComprobante"))
         '05 - desde 037 hasta 044 / Númerico / Tam = 8 / Observaciones = Fto. AAAAMMDD
         linea.FechaDeAnulacion = Date.Parse(dr("FechaDeAnulacion").ToString())

         Me._libivadigitalcomprobantesanulados.Lineas.Add(linea)

         If linea.TieneError Then
            Me.tsbVerRegistrosConErrores.Enabled = True
            Me.ugComprobantesAnulados.Rows(linea.Linea - 1).CellAppearance.BackColor = Color.LightSalmon
            Me.ugComprobantesAnulados.Rows(linea.Linea - 1).Cells("TipoError").Value = linea.TipoError
            dr("Procesar") = False
            Me.ugComprobantesAnulados.Rows(linea.Linea - 1).Cells("Linea").Activation = Activation.ActivateOnly
         End If

         '# Para cada linea le digo si la procesa cuando va a grabar el archivo o no.
         linea.Procesar = Boolean.Parse(dr("Procesar").ToString())
      Next

   End Sub

   Private Sub FormatearGrillas()

      Dim pos As Integer = 0

      '# Grilla de Comprobantes
      With Me.ugComprobantes.DisplayLayout.Bands(0)
         For Each col As UltraGridColumn In .Columns
            col.Hidden = True
         Next
         FormatearColumna(.Columns("Procesar"), "P.", pos, 30, HAlign.Center)
         .Columns("Procesar").CellActivation = Activation.AllowEdit
         FormatearColumna(.Columns("Linea"), "Linea", pos, 45, HAlign.Right)
         FormatearColumna(.Columns(Entidades.TipoComprobante.Columnas.DescripcionAbrev.ToString()), "Comprobante", pos, 120, HAlign.Left)
         FormatearColumna(.Columns(Entidades.Venta.Columnas.Letra.ToString()), "Letra", pos, 45, HAlign.Center)
         FormatearColumna(.Columns(Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoComprobante.ToString()), "AFIP", pos, 55, HAlign.Right)
         FormatearColumna(.Columns(Entidades.Venta.Columnas.CentroEmisor.ToString()), "Emisor", pos, 70, HAlign.Right)
         FormatearColumna(.Columns(Entidades.Venta.Columnas.NumeroComprobante.ToString()), "Nro. Comp.", pos, 80, HAlign.Right)
         FormatearColumna(.Columns(Entidades.Venta.Columnas.Fecha.ToString()), "Fecha", pos, 100, HAlign.Center)
         FormatearColumna(.Columns(Entidades.Cliente.Columnas.TipoDocCliente.ToString()), "Tipo Doc.", pos, 50, HAlign.Left)
         FormatearColumna(.Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()), "Nro. Doc.", pos, 80, HAlign.Right)
         FormatearColumna(.Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()), "Cliente", pos, 200, HAlign.Left)
         FormatearColumna(.Columns(Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscal.ToString()), "Categ. Fiscal", pos, 80, HAlign.Left)
         FormatearColumna(.Columns(Entidades.Cliente.Columnas.Cuit.ToString()), "CUIT", pos, 120, HAlign.Left)
         FormatearColumna(.Columns(Entidades.Venta.Columnas.ImporteBruto.ToString()), "Bruto", pos, 100, HAlign.Right)
         FormatearColumna(.Columns("Neto"), "Neto", pos, 100, HAlign.Right)
         FormatearColumna(.Columns("Importe"), "Importe", pos, 100, HAlign.Right)
         FormatearColumna(.Columns("Percepciones"), "Percepciones", pos, 100, HAlign.Right)
         FormatearColumna(.Columns("ImpuestoInterno"), "Imp. Interno", pos, 100, HAlign.Right)
         FormatearColumna(.Columns("Total"), "Total", pos, 100, HAlign.Right)
         FormatearColumna(.Columns("CantidadDeAlicuotas"), "Cant. Alícuotas", pos, 65, HAlign.Right)
         FormatearColumna(.Columns("EstaAnulado"), "Anulada", pos, 60, HAlign.Right)
         FormatearColumna(.Columns("TipoError"), "Error", pos, 600, HAlign.Right)
      End With

      '# Grilla de Alicuotas
      With Me.ugAlicuotas.DisplayLayout.Bands(0)
         For Each col As UltraGridColumn In .Columns
            col.Hidden = True
         Next
         FormatearColumna(.Columns("Procesar"), "P.", pos, 30, HAlign.Center)
         FormatearColumna(.Columns("Linea"), "Linea", pos, 45, HAlign.Right)
         FormatearColumna(.Columns(Entidades.TipoComprobante.Columnas.DescripcionAbrev.ToString()), "Comprobante", pos, 120, HAlign.Left)
         FormatearColumna(.Columns(Entidades.Venta.Columnas.Letra.ToString()), "Letra", pos, 45, HAlign.Center)
         FormatearColumna(.Columns(Entidades.Venta.Columnas.CentroEmisor.ToString()), "Emisor", pos, 70, HAlign.Right)
         FormatearColumna(.Columns(Entidades.Venta.Columnas.NumeroComprobante.ToString()), "Nro. Comp.", pos, 80, HAlign.Right)
         FormatearColumna(.Columns("Neto"), "Neto", pos, 100, HAlign.Right)
         FormatearColumna(.Columns("Alicuota"), "Alícuota", pos, 100, HAlign.Right)
         FormatearColumna(.Columns("Importe"), "Importe", pos, 100, HAlign.Right)
         FormatearColumna(.Columns("TipoError"), "Error", pos, 600, HAlign.Right)
      End With

      ugComprobantes.AgregarTotalesSuma({"ImporteBruto", "Neto", "ImporteImpuesto", "Importe", "Percepciones", "ImporteTotal", "ImpuestoInterno"})
      ugComprobantes.AgregarFiltroEnLinea({"NombreCliente"})

      ugAlicuotas.AgregarTotalesSuma({"Importe", "Neto", "Percepciones", "ImporteTotal"})
      ugAlicuotas.AgregarFiltroEnLinea({"NombreCliente"})

      ugComprobantesAnulados.AgregarFiltroEnLinea({"NombreCliente"})

      ugComprobantes.DisplayLayout.Bands(1).Hidden = True

   End Sub

#End Region

End Class