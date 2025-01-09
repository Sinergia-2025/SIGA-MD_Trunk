Public Class ExportacionLibIvaDigCompras

#Region "Campos"

   Private _publicos As Publicos
   Private _libroivadigitalcompras As LibroIvaDigitalCompras
   Private _libroivadigitalcomprasalicuotas As LibroIvaDigitalComprasAlicuotas
   Private _libroivadigitalcomprasdespachoimportacion As LibroIvaDigitalComprasDespachoImportacion

   Private _titComprobantes As Dictionary(Of String, String)
   Private _titAlicuotas As Dictionary(Of String, String)
   Private _titDespacho As Dictionary(Of String, String)
   Private _existeAlgunDespacho As Boolean

   Private _ds As DataSet
   Private _estaCargando As Boolean = False

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            dtpPeriodoFiscal.Value = Date.Today.PrimerDiaMes()

            TabControl1.SelectedTab = TbpComprobantes
            _titComprobantes = GetColumnasVisiblesGrilla(ugDetalle)
            ugDetalle.AgregarTotalesSuma({"TotalBruto", "TotalBaseImponible", "TotalImporteImpuesto", "Importe", "Percepciones", "ImporteTotal", "ImpuestosInternos"})
            ugDetalle.AgregarFiltroEnLinea({"NombreProveedor"})

            TabControl1.SelectedTab = tbpAlicuotas
            _titAlicuotas = GetColumnasVisiblesGrilla(ugAlicuotas)
            ugAlicuotas.AgregarTotalesSuma({"ImporteImpuesto", "BaseImponible", "Percepciones", "ImporteTotal"})
            ugAlicuotas.AgregarFiltroEnLinea({})

            TabControl1.SelectedTab = tbpDespachoImportacion
            _titDespacho = GetColumnasVisiblesGrilla(ugDespachoImportacion)
            ugDespachoImportacion.AgregarTotalesSuma({"ImporteImpuesto", "ImporteTotal"})
            ugDespachoImportacion.AgregarFiltroEnLinea({})

            TabControl1.SelectedTab = TbpComprobantes

         End Sub)
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

   Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
      TryCatched(Sub() tssRegistros.Text = TextoRegistros())
   End Sub

   Private Sub tsbVerRegistrosConErrores_Click(sender As Object, e As EventArgs) Handles tsbVerRegistrosConErrores.Click
      Try
         If TypeOf (ugDetalle.DataSource) Is DataTable Then
            Dim dt As DataTable = DirectCast(Me.ugDetalle.DataSource, DataTable)
            Dim dtError As DataTable = dt.Clone()
            Dim drError As DataRow
            For Each dr As DataRow In dt.Rows
               If Not String.IsNullOrEmpty(dr("TipoError").ToString()) Then
                  drError = dtError.NewRow
                  drError.ItemArray = dr.ItemArray
                  dtError.Rows.Add(drError)
               End If
            Next
            Dim cg As ConsultaGenerica = New ConsultaGenerica(dtError)
            cg.Show()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      Try
         If TypeOf (ugDetalle.DataSource) Is DataTable Then
            Dim dt As DataTable = DirectCast(ugDetalle.DataSource, DataTable)
            For Each dr As DataRow In dt.Rows
               If String.IsNullOrEmpty(dr("TipoError").ToString()) AndAlso (String.IsNullOrEmpty(dr("EstaAnulado").ToString()) OrElse Not Boolean.Parse(dr("EstaAnulado").ToString())) Then
                  dr("Procesar") = Me.chbTodos.Checked
               End If
            Next

            Dim dt2 As DataTable = DirectCast(ugAlicuotas.DataSource, DataTable)
            For Each dr2 As DataRow In dt2.Rows
               If String.IsNullOrEmpty(dr2("TipoError").ToString()) Then
                  dr2("Procesar") = Me.chbTodos.Checked
               End If
            Next

            Dim dt3 As DataTable = DirectCast(ugDespachoImportacion.DataSource, DataTable)
            For Each dr3 As DataRow In dt3.Rows
               If String.IsNullOrEmpty(dr3("TipoError").ToString()) Then
                  dr3("Procesar") = Me.chbTodos.Checked
               End If
            Next
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
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
   Private Sub tsbExportar_Click(sender As Object, e As EventArgs) Handles tsbExportar.Click

      Try

         If ugDetalle.Rows.Count = 0 Then Exit Sub

         If Me.txtArchivoDestinoComprobantes.Text.Trim() = "" Then
            ShowMessage("No Indico el Archivo Destino.")
            Me.txtArchivoDestinoComprobantes.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.ExportarDatos()
         Me.CerrarPeriodoFiscal()

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

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
            ShowMessage("No hay registros que cumplan con la selección !!!")
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.tssRegistros.Text = Me.TextoRegistros()
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   Private Sub btnExaminarComprobantes_Click(sender As Object, e As EventArgs) Handles btnExaminarComprobantes.Click

      Dim DialogoGuardarArchivo As New SaveFileDialog()

      DialogoGuardarArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoGuardarArchivo.Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*"
      DialogoGuardarArchivo.FilterIndex = 1
      DialogoGuardarArchivo.RestoreDirectory = True
      DialogoGuardarArchivo.FileName = "LibroIvaCompras_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"

      If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            If DialogoGuardarArchivo.FileName <> "" Then
               Me.txtArchivoDestinoComprobantes.Text = DialogoGuardarArchivo.FileName
            End If
         Catch ex As Exception
            ShowError(ex)
         End Try
      End If

   End Sub
   Private Sub btnExaminarAlicuotas_Click(sender As Object, e As EventArgs) Handles btnExaminarAlicuotas.Click

      Dim DialogoGuardarArchivo As New SaveFileDialog()

      DialogoGuardarArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoGuardarArchivo.Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*"
      DialogoGuardarArchivo.FilterIndex = 1
      DialogoGuardarArchivo.RestoreDirectory = True
      DialogoGuardarArchivo.FileName = "LibroIvaComprasAlicuotas_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"

      If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            If DialogoGuardarArchivo.FileName <> "" Then

               Me.txtArchivoDestinoAlicuotas.Text = DialogoGuardarArchivo.FileName

            End If

         Catch Ex As Exception
            ShowError(Ex)
         End Try
      End If

   End Sub
   Private Sub dtpPeriodoFiscal_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodoFiscal.ValueChanged
      dtpPeriodoFiscal.Value = dtpPeriodoFiscal.Value.PrimerDiaMes()
   End Sub
   Private Sub ugDetalle_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      Try
         If Me.ugDetalle.Rows.Count = 0 Or _estaCargando Then Exit Sub

         '# Si el comprobante ya esta anulado, no dejo tildarlo ya que hay una solapa exclusiva para Anulados
         If Boolean.Parse(e.Row.Cells("EstaAnulado").Value.ToString()) Then
            e.Row.Cells("Procesar").Value = False
            ShowMessage("Este comprobante se encuentra ANULADO. No puede procesarse.")
         End If

         '# Si el comprobante tiene error , no dejo tildarlo
         If Not String.IsNullOrEmpty(e.Row.Cells("TipoError").Value.ToString()) Then
            e.Row.Cells("Procesar").Value = False
            ShowMessage("Este comprobante tiene errores. No puede procesarse.")
         End If

         For Each rowComprobante As DataRow In Me._ds.Tables("Comprobantes").Rows
            For Each rowAlicuota As DataRow In rowComprobante.GetChildRows(_ds.Relations("ComprobantesAlicuotasRelacion"))
               rowAlicuota("Procesar") = rowComprobante("Procesar")
               Me.ugAlicuotas.UpdateData()
            Next
            For Each rowDespacho As DataRow In rowComprobante.GetChildRows(_ds.Relations("ComprobantesDespachosRelacion"))
               rowDespacho("Procesar") = rowComprobante("Procesar")
               Me.ugDespachoImportacion.UpdateData()
            Next
         Next

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub ugAlicuotas_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles ugAlicuotas.InitializeRow
      Try
         If e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
            TypeOf (DirectCast(e.Row.ListObject, DataRowView).Row) Is DataRow Then
            Dim dr As DataRow = DirectCast(DirectCast(e.Row.ListObject, DataRowView).Row, DataRow)
            If String.IsNullOrWhiteSpace(dr("TipoError").ToString()) Then
               e.Row.Appearance.BackColor = Nothing
               e.Row.Cells("Procesar").Activation = UltraWinGrid.Activation.AllowEdit
            Else
               e.Row.Appearance.BackColor = Color.LightSalmon
               e.Row.Cells("Procesar").Activation = UltraWinGrid.Activation.NoEdit
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub btnExaminarDespacho_Click(sender As Object, e As EventArgs) Handles btnExaminarDespacho.Click

      Dim DialogoGuardarArchivo As New SaveFileDialog()

      DialogoGuardarArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoGuardarArchivo.Filter = "Archivos de Texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*"
      DialogoGuardarArchivo.FilterIndex = 1
      DialogoGuardarArchivo.RestoreDirectory = True
      DialogoGuardarArchivo.FileName = "LibroIvaComprasDespachos_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"

      If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            If DialogoGuardarArchivo.FileName <> "" Then
               Me.txtDestinoDespacho.Text = DialogoGuardarArchivo.FileName
            End If
         Catch ex As Exception
            ShowError(ex)
         End Try
      End If

   End Sub
   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      Try
         Me.ugDetalle.UpdateData()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Métodos"

   Private Function TextoRegistros() As String

      '# Registros
      Dim mensaje As String
      If Me.TabControl1.SelectedTab Is TbpComprobantes Then
         mensaje = String.Format("{0} Comprobantes", Me.ugDetalle.Rows.Count.ToString())
      ElseIf Me.TabControl1.SelectedTab Is tbpAlicuotas Then
         mensaje = String.Format("{0} Alícuotas", Me.ugAlicuotas.Rows.Count.ToString())
      Else
         mensaje = String.Format("{0} Despachos", Me.ugDespachoImportacion.Rows.Count.ToString())
      End If
      Return mensaje

   End Function

   Private Sub RefrescarDatosGrilla()

      Me.ugDespachoImportacion.ClearFilas()
      Me.ugAlicuotas.ClearFilas()
      Me.ugDetalle.ClearFilas()

      Me.dtpPeriodoFiscal.Value = DateTime.Today
      Me.txtArchivoDestinoComprobantes.Clear()
      Me.txtArchivoDestinoAlicuotas.Clear()
      Me.txtDestinoDespacho.Clear()

      Me.tsbExportar.Enabled = False
      Me.tsbVerRegistrosConErrores.Enabled = False

      Me.TabControl1.SelectedTab = TbpComprobantes
   End Sub
   Private Sub ProcesarComprobantes(dt As DataTable)

      Dim linea As Integer = 1
      _existeAlgunDespacho = False
      Me.tsbVerRegistrosConErrores.Enabled = False

      '# Procesamiento de la tabla
      dt.Columns.Add("Procesar", GetType(Boolean))
      dt.Columns.Add("EstaAnulado", GetType(Boolean))
      dt.Columns.Add("Linea", GetType(Integer))
      dt.Columns.Add("CantidadDeAlicuotas", GetType(Integer))
      dt.Columns.Add("Percepciones", GetType(Decimal))
      dt.Columns.Add("ImpuestoInterno", GetType(Decimal))
      dt.Columns.Add("FechaVto", GetType(DateTime))
      dt.Columns.Add("TipoError", GetType(String))

      For Each dr As DataRow In dt.Rows
         dr("Linea") = linea

         If String.IsNullOrEmpty(dr(Entidades.Proveedor.Columnas.TipoDocProveedor.ToString()).ToString()) Then
            dr(Entidades.Proveedor.Columnas.TipoDocProveedor.ToString()) = ""
            dr(Entidades.Proveedor.Columnas.NroDocProveedor.ToString()) = 0
         Else
            If String.IsNullOrEmpty(Entidades.Proveedor.Columnas.NroDocProveedor.ToString()) Then
               dr(Entidades.Proveedor.Columnas.NroDocProveedor.ToString()) = 0
            End If
         End If

         If String.IsNullOrEmpty(dr("IdAFIPTipoComprobante").ToString()) Then
            dr("IdAFIPTipoComprobante") = 0
         End If

         If String.IsNullOrEmpty(dr("IdAFIPTipoDocumento").ToString()) Then
            dr("IdAFIPTipoDocumento") = 0
         End If

         If Boolean.Parse(dr("EsDespachoImportacion").ToString()) Then
            _existeAlgunDespacho = True
         End If

         If dr("Letra").ToString() = "A" Or dr("Letra").ToString() = "M" Or dr("Letra").ToString() = "X" Or Boolean.Parse(dr("EsDespachoImportacion").ToString()) Then
            If dr.Field(Of String)("IvaCeroCategoriaFiscal").StringToEnum(Entidades.Publicos.FormatoIvaCero.GRAVADO) = Entidades.Publicos.FormatoIvaCero.EXENTO Or
               dr.Field(Of String)("IvaCeroCategoriaFiscal").StringToEnum(Entidades.Publicos.FormatoIvaCero.GRAVADO) = Entidades.Publicos.FormatoIvaCero.NOGRAVADO Then
               dr("CantidadDeAlicuotas") = dr("CantidadAlicuotasAlicuotaDif0")
            Else
               dr("CantidadDeAlicuotas") = dr("CantidadAlicuotas")
            End If
         Else
            dr("CantidadDeAlicuotas") = 0
         End If

         '# Percepciones
         Dim PGANA As Decimal = Decimal.Parse(dr("PercepcionGanancias").ToString())
         Dim PIIBB As Decimal = Decimal.Parse(dr("PercepcionIB").ToString())
         Dim PIVA As Decimal = Decimal.Parse(dr("PercepcionIVA").ToString())
         Dim PVAR As Decimal = Decimal.Parse(dr("PercepcionVarias").ToString())

         dr("ImpuestoInterno") = Decimal.Parse(dr("ImpuestosInternos").ToString())
         dr("Percepciones") = PGANA + PIIBB + PIVA + PVAR

         If dr("IdEstadoComprobante").ToString() = "ANULADO" Then
            dr("NombreProveedor") = "** COMPROBANTE ANULADO **"
            dr("EstaAnulado") = True
            dr("TotalBruto") = 0
            dr("ImporteTotal") = 0
         Else
            dr("EstaAnulado") = False
         End If

         Dim total As Decimal = Convert.ToDecimal(dr("ImporteTotal"))
         If Boolean.Parse(dr("EsDespachoImportacion").ToString()) Then
            total += Decimal.Parse(dr("BaseImponibleDespachoImportacion").ToString())
            dr("ImporteTotal") = total
         End If

         linea += 1
      Next

      ugDetalle.DataSource = dt
      AjustarColumnasGrilla(ugDetalle, _titComprobantes)

      Me.txtArchivoDestinoComprobantes.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\LibroIvaCompras_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"

   End Sub
   Private Sub ProcesarAlicuotas(dt As DataTable)

      Dim linea As Integer = 1
      dt.Columns.Add("Procesar", GetType(Boolean))
      dt.Columns.Add("EstaAnulado", GetType(Boolean))
      dt.Columns.Add("Linea", GetType(Integer))
      dt.Columns.Add("ImporteTotal", GetType(Decimal))
      dt.Columns.Add("TipoError", GetType(String))

      For Each dr As DataRow In dt.Rows
         If dr("IdTipoComprobante").ToString() <> "DESPACHOIMP" Then
            dr("Linea") = linea

            If String.IsNullOrEmpty(dr(Entidades.Proveedor.Columnas.TipoDocProveedor.ToString()).ToString()) Then
               dr(Entidades.Proveedor.Columnas.TipoDocProveedor.ToString()) = ""
               dr(Entidades.Proveedor.Columnas.NroDocProveedor.ToString()) = 0
            Else
               If String.IsNullOrEmpty(Entidades.Proveedor.Columnas.NroDocProveedor.ToString()) Then
                  dr(Entidades.Proveedor.Columnas.NroDocProveedor.ToString()) = 0
               End If
            End If

            If String.IsNullOrEmpty(dr("IdAFIPTipoComprobante").ToString()) Then
               dr("IdAFIPTipoComprobante") = 0
            End If

            If String.IsNullOrEmpty(dr("IdAFIPTipoDocumento").ToString()) Then
               dr("IdAFIPTipoDocumento") = 0
            End If

            dr("ImporteTotal") = Decimal.Parse(dr("BaseImponible").ToString()) + Decimal.Parse(dr("ImporteImpuesto").ToString())

            linea += 1
         End If
      Next

      ugAlicuotas.DataSource = dt
      AjustarColumnasGrilla(ugAlicuotas, _titAlicuotas)

      Me.txtArchivoDestinoAlicuotas.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\LibroIvaComprasAlicuotas_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"

   End Sub
   Private Sub ProcesarDespachos(dt As DataTable)

      Dim linea As Integer = 1

      '# Procesamiento de la tabla
      dt.Columns.Add("Procesar", GetType(Boolean))
      dt.Columns.Add("Linea", GetType(Integer))
      dt.Columns.Add("NroDocCliente", GetType(String))
      dt.Columns.Add("TipoDocCliente", GetType(Integer))
      dt.Columns.Add("Cuit", GetType(Long))
      dt.Columns.Add("ImporteTotal", GetType(Decimal))
      dt.Columns.Add("TipoError", GetType(String))

      For Each dr As DataRow In dt.Rows
         dr("Linea") = linea
         dr("ImporteTotal") = Decimal.Parse(dr("BaseImponible").ToString()) + Decimal.Parse(dr("ImporteImpuesto").ToString())

         If String.IsNullOrEmpty(dr("IdAFIPTipoComprobante").ToString()) Then
            dr("IdAFIPTipoComprobante") = 0
         End If
         If String.IsNullOrEmpty(dr("IdAFIPTipoDocumento").ToString()) Then
            dr("IdAFIPTipoDocumento") = 0
         End If

         linea += 1
      Next

      ugDespachoImportacion.DataSource = dt

      If _existeAlgunDespacho Then
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

      Me.txtDestinoDespacho.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\LibroIvaComprasDespachos_" & Me.dtpPeriodoFiscal.Value.ToString("yyyyMM") & ".txt"

   End Sub
   Private Sub CrearLIBROIVADIGITALCompras()

      Try
         If Not TypeOf (ugDetalle.DataSource) Is DataTable Then Exit Sub
         If Not TypeOf (ugAlicuotas.DataSource) Is DataTable Then Exit Sub

         Me._libroivadigitalcompras = New LibroIvaDigitalCompras()
         Me._libroivadigitalcomprasalicuotas = New LibroIvaDigitalComprasAlicuotas()
         Me._libroivadigitalcomprasdespachoimportacion = New LibroIvaDigitalComprasDespachoImportacion()

         Dim dt As DataTable = DirectCast(ugDetalle.DataSource, DataTable)
         Dim dt2 As DataTable = DirectCast(ugAlicuotas.DataSource, DataTable)
         Dim dt3 As DataTable = DirectCast(ugDespachoImportacion.DataSource, DataTable)
         Me.chbTodos.Checked = True

         For Each dr As DataRow In dt.Rows
            dr("Procesar") = Me.chbTodos.Checked
            Me.ugDetalle.UpdateData()
         Next
         For Each dr As DataRow In dt2.Rows
            dr("Procesar") = Me.chbTodos.Checked
            Me.ugAlicuotas.UpdateData()
         Next
         For Each dr As DataRow In dt3.Rows
            dr("Procesar") = Me.chbTodos.Checked
            Me.ugDespachoImportacion.UpdateData()
         Next

         Me.LIBROIVADIGITALCompras(dt)
         Me.LIBROIVADIGITALComprasAlicuotas(dt2)
         Me.LIBROIVADIGITALComprasDespachoImportacion(dt3)

      Catch ex As Exception
         Throw
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try

   End Sub
   Private Sub CargaGrillaDetalle()

      Try
         _estaCargando = True

         Dim rCompras As Reglas.Compras = New Reglas.Compras()
         Dim periodoFiscal As Integer = Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM"))
         Dim _existeAlgunDespacho As Boolean = False

         '# Procesamiento de los comprobantes
         Me.ProcesarComprobantes(rCompras.GetParaExportarAFIP(actual.Sucursal.IdEmpresa, periodoFiscal))

         '# Procesamiento de las alícuotas
         Me.ProcesarAlicuotas(rCompras.GetParaExportarAFIPAlicuotas(actual.Sucursal.IdEmpresa, periodoFiscal))

         '# Procesamiento de Despacho
         Me.ProcesarDespachos(rCompras.GetParaExportarAFIPDespachoImportacion(actual.Sucursal.IdEmpresa, periodoFiscal))

         '# Crear las relaciones entre las tablas
         Me.CrearRelaciones()

         '# Crear Libro
         Me.CrearLIBROIVADIGITALCompras()

         If Me.ugDetalle.DisplayLayout.Bands().Count > 1 Then
            Me.ugDetalle.DisplayLayout.Bands(1).Hidden = True
            Me.ugDetalle.DisplayLayout.Bands(2).Hidden = True
         End If

         Me.tsbVerRegistrosConErrores.Enabled = False

      Catch ex As Exception
         ShowError(ex)
      Finally
         _estaCargando = False
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CrearRelaciones()

      '# Creo la relación entre la tabla de Comprobantes y las alícuotas
      _ds = New DataSet
      _ds.Tables.Add("Comprobantes", DirectCast(Me.ugDetalle.DataSource, DataTable))
      _ds.Tables.Add("Alicuotas", DirectCast(Me.ugAlicuotas.DataSource, DataTable))
      _ds.Tables.Add("Despachos", DirectCast(Me.ugDespachoImportacion.DataSource, DataTable))

      Dim Relacion As DataRelation = New DataRelation("ComprobantesAlicuotasRelacion",
                            {_ds.Tables("Comprobantes").Columns(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                             _ds.Tables("Comprobantes").Columns(Entidades.Venta.Columnas.Letra.ToString()),
                             _ds.Tables("Comprobantes").Columns(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                             _ds.Tables("Comprobantes").Columns(Entidades.Venta.Columnas.NumeroComprobante.ToString())},
                            {_ds.Tables("Alicuotas").Columns(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                             _ds.Tables("Alicuotas").Columns(Entidades.Venta.Columnas.Letra.ToString()),
                             _ds.Tables("Alicuotas").Columns(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                             _ds.Tables("Alicuotas").Columns(Entidades.Venta.Columnas.NumeroComprobante.ToString())}, False)
      _ds.Relations.Add(Relacion)

      '# Creo la relación entre la de tabla de Comprobantes y despachos
      Dim Relacion1 As DataRelation = New DataRelation("ComprobantesDespachosRelacion",
                            {_ds.Tables("Comprobantes").Columns(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                             _ds.Tables("Comprobantes").Columns(Entidades.Venta.Columnas.Letra.ToString()),
                             _ds.Tables("Comprobantes").Columns(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                             _ds.Tables("Comprobantes").Columns(Entidades.Venta.Columnas.NumeroComprobante.ToString())},
                            {_ds.Tables("Despachos").Columns(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                             _ds.Tables("Despachos").Columns(Entidades.Venta.Columnas.Letra.ToString()),
                             _ds.Tables("Despachos").Columns(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                             _ds.Tables("Despachos").Columns(Entidades.Venta.Columnas.NumeroComprobante.ToString())}, False)
      _ds.Relations.Add(Relacion1)

   End Sub

   Private Sub ExportarDatos()

      Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()
      If Not TypeOf (ugDetalle.DataSource) Is DataTable Then Exit Sub
      If Not TypeOf (ugAlicuotas.DataSource) Is DataTable Then Exit Sub
      If Not TypeOf (ugDespachoImportacion.DataSource) Is DataTable Then Exit Sub

      For Each li As LibroIvaDigitalComprasLinea In Me._libroivadigitalcompras.Lineas
         For Each dr As DataRow In DirectCast(ugDetalle.DataSource, DataTable).Rows
            If li.Linea = Long.Parse(dr("Linea").ToString()) Then
               li.Procesar = Boolean.Parse(dr("Procesar").ToString())
               Exit For
            End If
         Next
      Next


      '# Si no existen registros para generar, le aviso al usuario que no se va a generar el archivo
      If Me._libroivadigitalcompras.CantidadDeLineasaProcesar = 0 Then
         ShowMessage(String.Format("No hay comprobantes seleccionados. No se generará el archivo LibroIvaCompras_{0}", Me.dtpPeriodoFiscal.Value.ToString("yyyyMM")))
      Else
         stb.AppendFormat("Realmente desea generar el archivo para los {0} Comprobantes?", Me._libroivadigitalcompras.CantidadDeLineasaProcesar)
         If ShowPregunta(stb.ToString()) = Windows.Forms.DialogResult.Yes Then
            Me._libroivadigitalcompras.GrabarArchivo(Me.txtArchivoDestinoComprobantes.Text)
            ShowMessage(String.Format("Se Exportaron {0} comprobantes EXITOSAMENTE !!!", Me._libroivadigitalcompras.CantidadDeLineasaProcesar.ToString()))
         Else
            ShowMessage("Ha cancelado la exportación.")
         End If
      End If

      Dim stb1 As System.Text.StringBuilder = New System.Text.StringBuilder()

      For Each li As LibroIvaDigitalComprasAlicuotasLinea In Me._libroivadigitalcomprasalicuotas.Lineas
         For Each dr As DataRow In DirectCast(ugAlicuotas.DataSource, DataTable).Rows
            If li.Linea = Long.Parse(dr("Linea").ToString()) Then
               li.Procesar = Boolean.Parse(dr("Procesar").ToString())
               Exit For
            End If
         Next
      Next

      '# Si no existen registros para generar, le aviso al usuario que no se va a generar el archivo
      If Me._libroivadigitalcomprasalicuotas.CantidadDeLineasaProcesar = 0 Then
         ShowMessage(String.Format("No hay alícuotas seleccionadas. No se generará el archivo LibroIvaComprasAlicuotas_{0}", Me.dtpPeriodoFiscal.Value.ToString("yyyyMM")))
      Else
         stb1.AppendFormat("Realmente desea generar el archivo para los {0} Comprobantes Alicuotas?", Me._libroivadigitalcomprasalicuotas.CantidadDeLineasaProcesar)
         If ShowPregunta(stb1.ToString()) = Windows.Forms.DialogResult.Yes Then
            Me._libroivadigitalcomprasalicuotas.GrabarArchivo(Me.txtArchivoDestinoAlicuotas.Text)
            ShowMessage(String.Format("Se Exportaron {0} comprobantes Alicuotas EXITOSAMENTE !!!", Me._libroivadigitalcomprasalicuotas.CantidadDeLineasaProcesar.ToString()))
         Else
            ShowMessage("Ha cancelado la exportación.")
         End If
      End If

      If ugDespachoImportacion.Rows.Count > 0 Then
         Dim stb2 As System.Text.StringBuilder = New System.Text.StringBuilder()

         For Each li As LibroIvaDigitalComprasDespachoImportacionLinea In Me._libroivadigitalcomprasdespachoimportacion.Lineas
            For Each dr As DataRow In DirectCast(ugDespachoImportacion.DataSource, DataTable).Rows
               If li.Linea = Long.Parse(dr("Linea").ToString()) Then
                  li.Procesar = Boolean.Parse(dr("Procesar").ToString())
                  Exit For
               End If
            Next
         Next

         '# Si no existen registros para generar, le aviso al usuario que no se va a generar el archivo
         If Me._libroivadigitalcomprasdespachoimportacion.CantidadDeLineasaProcesar = 0 Then
            ShowMessage(String.Format("No hay despachos seleccionados. No se generará el archivo LibroIvaComprasDespachos_{0}", Me.dtpPeriodoFiscal.Value.ToString("yyyyMM")))
         Else
            stb2.AppendFormat("Realmente desea generar el archivo para los {0} Comprobantes Despacho de Importación?", Me._libroivadigitalcomprasdespachoimportacion.CantidadDeLineasaProcesar.ToString())
            If ShowPregunta(stb2.ToString()) = Windows.Forms.DialogResult.Yes Then
               Me._libroivadigitalcomprasdespachoimportacion.GrabarArchivo(Me.txtDestinoDespacho.Text)
               ShowMessage(String.Format("Se Exportaron {0} Comprobantes Despacho de Importación EXITOSAMENTE !!!", Me._libroivadigitalcomprasdespachoimportacion.CantidadDeLineasaProcesar.ToString()))
            Else
               ShowMessage("Ha cancelado la exportación.")
            End If
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
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub LIBROIVADIGITALCompras(dt As DataTable)
      Dim linea As LibroIvaDigitalComprasLinea

      Me.tspBarra.Visible = True
      Me.tspBarra.Minimum = 0
      Me.tspBarra.Maximum = dt.Rows.Count
      Me.tspBarra.Value = 0

      For Each dr As DataRow In dt.Rows

         Me.tspBarra.Value = Convert.ToInt32(dr("Linea")) - 1
         'si esta anulada paso al proximo registro y no lo genero
         If Not String.IsNullOrEmpty(dr("EstaAnulado").ToString()) AndAlso Boolean.Parse(dr("EstaAnulado").ToString()) Then
            dr("Procesar") = False
            Continue For
         End If
         If Not Boolean.Parse(dr("Procesar").ToString()) Then
            Continue For
         End If

         Dim coe = dr.Field(Of Integer)("CoeficienteValores")

         linea = New LibroIvaDigitalComprasLinea()

         linea.Linea = Convert.ToInt32(dr("Linea"))

         '01 - desde 001 hasta 008 / Númerico / Tam = 8 / Observaciones = Fto. AAAAMMDD
         linea.FechaDelComprobante = Date.Parse(dr("Fecha").ToString())
         '02 - desde 009 hasta 011 / Númerico / Tam = 3 / Observaciones = Según tabla de comprobantes
         linea.TipoDeComprobante = Convert.ToInt32(dr("IdAFIPTipoComprobante"))

         '03 - desde 012 hasta 016 / Númerico / Tam = 5 / Observaciones = 
         If linea.TipoDeComprobante = 99 Or Boolean.Parse(dr("EsDespachoImportacion").ToString()) Then
            'pongo fijo el cero ya que los tipos de comprobantes de este tipo son de Resumenes Bancarios.
            'esto fue planteado por la contador de BBP Amoblamientos
            linea.PuntoDeVenta = 0
         Else
            linea.PuntoDeVenta = Convert.ToInt32(dr("CentroEmisor"))
         End If
         '04 - desde 017 hasta 036 / Númerico / Tam = 20 / Observaciones = 
         If Boolean.Parse(dr("EsDespachoImportacion").ToString()) Then
            linea.NroDeComprobante = 0
         Else
            linea.NroDeComprobante = Convert.ToInt64(dr("NumeroComprobante"))
         End If

         '05 - desde 037 hasta 052 / AlfaNúmerico / Tam = 16 / Observaciones = 
         If Boolean.Parse(dr("EsDespachoImportacion").ToString()) Then
            linea.NroDespachoDeImportacion = dr("NumeroDespachoCompleto").ToString()
         Else
            linea.NroDespachoDeImportacion = ""
         End If
         '06 - desde 053 hasta 054 / Númerico / Tam = 2 / Observaciones = Según tabla de documentos
         If String.IsNullOrEmpty(dr("CuitProveedor").ToString()) Then
            linea.CodigoDeDocumentoIdentificatorioDelComprador = Convert.ToInt32(dr("IdAFIPTipoDocumento"))
         Else
            linea.CodigoDeDocumentoIdentificatorioDelComprador = 80
         End If
         '07 - desde 055 hasta 074 / AlfaNúmerico / Tam = 20 / Observaciones = 
         If String.IsNullOrEmpty(dr("CuitProveedor").ToString()) Then
            linea.NroDeIdentificacionDelComprador = Convert.ToInt64(dr("NroDocProveedor"))
         Else
            linea.NroDeIdentificacionDelComprador = Long.Parse(dr("CuitProveedor").ToString().Replace("-"c, ""))
         End If
         '08 - desde 075 hasta 104 / AlfaNúmerico / Tam = 30 / Observaciones = 
         linea.ApellidoYNombreODenominacionDelComprador = dr("NombreProveedor").ToString()
         '09 - desde 105 hasta 119 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         linea.ImporteTotalDeLaOperacion = Convert.ToDecimal(dr("ImporteTotal")) * coe

         '-- REQ-34586.- ------------------------------------------------------------------------------------------------------------------------------------
         '10 - desde 120 hasta 134 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         linea.TotalDeConceptosQueNoIntegranElPrecioNeto = If(dr("IvaCeroCategoriaFiscal").ToString() = Entidades.Publicos.FormatoIvaCero.NOGRAVADO.ToString(), dr.Field(Of Decimal)("TotalNoGrabado") * coe, 0)
         '11 - desde 135 hasta 149 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDeOperacionesExentas = If(dr("IvaCeroCategoriaFiscal").ToString() = Entidades.Publicos.FormatoIvaCero.EXENTO.ToString() OrElse
                                                dr("IvaCeroCategoriaFiscal").ToString() = Entidades.Publicos.FormatoIvaCero.ZONAFRANCA.ToString(), (dr.Field(Of Decimal)("TotalNoGrabado") * coe), 0)

         '----------------------------------------------------------------------------------------------------------------------------------------------------
         'linea.TotalDeConceptosQueNoIntegranElPrecioNeto = 0
         'If Convert.ToInt32(dr("CantidadDeAlicuotas")) = 0 Then
         '   If dr("Letra").ToString() = "A" Then 'EL CAMPO IMPORTE OPERACIONES EXENTAS DEBE SER IGUAL A CERO CUANDO SON CPTES. B O C
         '      linea.ImporteDeOperacionesExentas = Convert.ToDecimal(dr("ImporteBruto")) * coe
         '   End If
         'End If
         '----------------------------------------------------------------------------------------------------------------------------------------------------

         '12 - desde 150 hasta 164 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDePercepcionesOPagosACtaDelIVA = Convert.ToDecimal(dr("PercepcionIVA")) * coe
         '13 - desde 165 hasta 179 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDePercepOPagosACtaDeImpuestoNac = Convert.ToDecimal(dr("PercepcionGanancias")) * coe
         '14 - desde 180 hasta 194 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDePercepcionesDeIngresosBrutos = Convert.ToDecimal(dr("PercepcionIB")) * coe
         '15 - desde 195 hasta 209 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDePercepcionesDeImpuestosMunicipales = Convert.ToDecimal(dr("PercepcionVarias")) * coe
         '16 - desde 210 hasta 224 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImporteDeImpuestosInternos = Convert.ToDecimal(dr("ImpuestosInternos")) * coe
         '17 - desde 225 hasta 227 / Alfabetico / Tam = 3 / Observaciones =  Según tabla Monedas
         linea.CodigoDeMoneda = "PES"
         '18 - desde 228 hasta 237 / Númerico / Tam = 10 / Observaciones =  4 enteros 6 decimales sin punto decimal
         linea.TipoDeCambio = 1
         '19 - desde 238 hasta 238 / Númerico / Tam = 1 / Observaciones = 
         linea.CantidadDeAlicuotasDeIVA = Convert.ToInt32(dr("CantidadDeAlicuotas"))
         '20 - desde 239 hasta 239 / Alfabetico / Tam = 1 / Observaciones =   Según tabla Codigo_Operación, de No Corresponder v
         'PE-35435 >>> Se vuelve atrás a la lógica que estaba antes del cambio.
         If dr("NombreCategoriaFiscal").ToString() = "Exento" And Convert.ToInt32(dr("CantidadDeAlicuotas")) = 0 Then
            linea.CodigoDeOperacion = "E"
         Else
            If Convert.ToDecimal(dr("TotalNoGrabado")) <> 0 And Convert.ToInt32(dr("CantidadDeAlicuotas")) <> 0 Then
               linea.CodigoDeOperacion = "E"
            Else
               linea.CodigoDeOperacion = "0"
            End If
         End If
         ''''If linea.CantidadDeAlicuotasDeIVA = 0 Then
         ''''   Select Case dr.Field(Of String)("IvaCeroCategoriaFiscal").StringToEnum(Entidades.Publicos.FormatoIvaCero.GRAVADO)
         ''''      Case Entidades.Publicos.FormatoIvaCero.NOGRAVADO
         ''''         linea.CodigoDeOperacion = "N"
         ''''      Case Entidades.Publicos.FormatoIvaCero.EXENTO
         ''''         linea.CodigoDeOperacion = "E"
         ''''      Case Else
         ''''         linea.CodigoDeOperacion = "0"
         ''''   End Select
         ''''Else
         ''''   linea.CodigoDeOperacion = "0"
         ''''End If
         'PE-35435 <<<

         '21 - desde 240 hasta 254 / Númerico / Tam = 15 / Observaciones = 
         linea.CreditoFiscalComputable = 0
         If Reglas.Publicos.AFIPCitiComprasProrrateo <> Entidades.EnumAfip.ProrrateoCitiCompras.SI_GLOBAL Then
            linea.CreditoFiscalComputable = Convert.ToDecimal(dr("TotalImporteImpuesto")) * coe
         End If
         '22 - desde 255 hasta 269 / Númerico / Tam = 15 / Observaciones = 
         linea.OtrosTributos = 0
         '23 - desde 270 hasta 280 / Númerico / Tam = 11 / Observaciones =  
         linea.CuitEmisor = 0
         '24 - desde 281 hasta 310 / AlfaNúmerico / Tam = 30 / Observaciones =  
         linea.DenominacionDelEmisorCorredor = ""
         '25 - desde 311 hasta 325 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.IvaComision = 0

         Dim esZonaFranca = dr.Field(Of Integer)("CantidadDeAlicuotas") = 0 And dr.Field(Of String)("IvaCeroCategoriaFiscal") = "ZONAFRANCA"
         If esZonaFranca Then
            linea.CodigoDeOperacion = "E"
            linea.CantidadDeAlicuotasDeIVA = dr.Field(Of Integer)("CantidadAlicuotas")
            If {11, 12, 13}.Contains(linea.TipoDeComprobante) Then   'FACTURAS C / NOTAS DE DEBITO C / NOTAS DE CREDITO C
               linea.CantidadDeAlicuotasDeIVA = 0
               linea.ImporteDeOperacionesExentas = 0
            End If
         End If

         Me._libroivadigitalcompras.Lineas.Add(linea)

         If linea.TieneError Then
            Me.tsbVerRegistrosConErrores.Enabled = True
            Me.ugDetalle.Rows(linea.Linea - 1).CellAppearance.BackColor = Color.LightSalmon
            Me.ugDetalle.Rows(linea.Linea - 1).Cells("TipoError").Value = linea.TipoError
            dr("Procesar") = False
            Me.ugDetalle.Rows(linea.Linea - 1).Cells("Linea").Activation = Activation.ActivateOnly
         End If

         'para cada linea le digo si la procesa cuando va a grabar el archivo o no.
         linea.Procesar = Boolean.Parse(dr("Procesar").ToString())
      Next
   End Sub
   Private Sub LIBROIVADIGITALComprasAlicuotas(dt As DataTable)

      Dim linea As LibroIvaDigitalComprasAlicuotasLinea

      For Each dr As DataRow In dt.Rows
         linea = New LibroIvaDigitalComprasAlicuotasLinea()
         linea.Linea = Convert.ToInt32(dr("Linea"))

         Dim coe = dr.Field(Of Integer)("CoeficienteValores")

         '01 - desde 001 hasta 003 / Númerico / Tam = 3 / Observaciones = Según tabla de comprobantes
         linea.TipoDeComprobante = Convert.ToInt32(dr("IdAFIPTipoComprobante"))

         '02 - desde 004 hasta 008 / Númerico / Tam = 5 / Observaciones = 
         If linea.TipoDeComprobante = 99 Then
            'pongo fijo el cero ya que los tipos de comprobantes de este tipo son de Resumenes Bancarios.
            'esto fue planteado por la contador de BBP Amoblamientos
            linea.PuntoDeVenta = 0
         Else
            linea.PuntoDeVenta = Convert.ToInt32(dr("CentroEmisor"))
         End If

         '03 - desde 009 hasta 028 / Númerico / Tam = 20 / Observaciones = 
         linea.NroDeComprobante = Convert.ToDecimal(dr("NumeroComprobante"))
         '04 - desde 029 hasta 030 / Númerico / Tam = 2 / Observaciones =  Segun tabla Documentos

         If String.IsNullOrEmpty(dr("CuitProveedor").ToString()) Then
            linea.CodigoDeDocumentoIdentificatorioDelVendedor = Convert.ToInt32(dr("IdAFIPTipoDocumento"))
         Else
            linea.CodigoDeDocumentoIdentificatorioDelVendedor = 80
         End If
         '05 - desde 031 hasta 050 / AlfaNúmerico / Tam = 20 / Observaciones =  
         If String.IsNullOrEmpty(dr("CuitProveedor").ToString()) Then
            linea.NroDeIdentificacionDelVendedor = Convert.ToInt64(dr("NroDocProveedor"))
         Else
            linea.NroDeIdentificacionDelVendedor = Long.Parse(dr("CuitProveedor").ToString().Replace("-"c, ""))
         End If
         '06 - desde 051 hasta 065 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         linea.ImporteNetoGravado = Convert.ToDecimal(dr("BaseImponible")) * coe
         '07 - desde 066 hasta 069 / Númerico / Tam = 4 / Observaciones =  Según tabla Alícuotas
         linea.AlicuotaDeIVA = Convert.ToInt32(dr("CodigoAlicuota"))
         '08 - desde 070 hasta 084 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImpuestoLiquidado = Convert.ToDecimal(dr("ImporteImpuesto")) * coe


         Dim esZonaFranca = dr.Field(Of String)("IvaCeroCategoriaFiscal") = "ZONAFRANCA"
         If esZonaFranca Then
            linea.ImporteNetoGravado = 0
         End If

         Me._libroivadigitalcomprasalicuotas.Lineas.Add(linea)

         If linea.TieneError Then
            Me.tsbVerRegistrosConErrores.Enabled = True
            Dim drCol As DataRow() = DirectCast(ugAlicuotas.DataSource, DataTable).Select(String.Format("Linea = {0}", linea.Linea))
            If drCol.Length > 0 Then
               drCol(0)("TipoError") = linea.TipoError
            End If
            dr("Procesar") = False
         End If

         '# Manejo la relación entre la alícuota y su comprobante padre (a la inversa)
         '# Si el comprobante no se va a procesar porque está anulado o porque tiene errores, la alícuota tampoco debe procesarse
         'For Each rowComprobante As DataRow In dr.GetParentRows(_ds.Relations("ComprobantesAlicuotasRelacion"))
         '   Me.ugDetalle.UpdateData()
         '   dr("Procesar") = Boolean.Parse(rowComprobante("Procesar").ToString())
         '   Me.ugAlicuotas.UpdateData()
         'Next
         linea.Procesar = Boolean.Parse(dr("Procesar").ToString())
      Next
   End Sub
   Private Sub LIBROIVADIGITALComprasDespachoImportacion(dt As DataTable)

      Dim linea As LibroIvaDigitalComprasDespachoImportacionLinea
      For Each dr As DataRow In dt.Rows
         linea = New LibroIvaDigitalComprasDespachoImportacionLinea()

         linea.Linea = Convert.ToInt32(dr("Linea"))

         Dim coe = dr.Field(Of Integer)("CoeficienteValores")

         '01 - desde 001 hasta 016 / AlfaNúmerico / Tam = 16 / Observaciones =  
         linea.DespachoImportacion = dr("NumeroDespachoCompleto").ToString()
         '02 - desde 017 hasta 031 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         linea.ImporteNetoGravado = Convert.ToDecimal(dr("BaseImponible")) * coe
         '03 - desde 032 hasta 035 / Númerico / Tam = 4 / Observaciones =  Según tabla Alícuotas
         linea.AlicuotaDeIVA = Convert.ToInt32(dr("CodigoAlicuota"))
         '04 - desde 036 hasta 050 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         linea.ImpuestoLiquidado = Convert.ToDecimal(dr("ImporteImpuesto")) * coe

         Me._libroivadigitalcomprasdespachoimportacion.Lineas.Add(linea)

         'para cada linea le digo si la procesa cuando va a grabar el archivo o no.
         linea.Procesar = Boolean.Parse(dr("Procesar").ToString())
      Next

   End Sub

#End Region

End Class