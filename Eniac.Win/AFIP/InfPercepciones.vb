Public Class InfPercepciones

#Region "Campos"

   Private _publicos As Publicos
   Public ConsultarAutomaticamente As Boolean = False
   Private _siprib As SIPRIBArchivo
   Private _siager As SIAGERArchivo
   Private _SIRCAR As SIRCARArchivo
   Private _sicore As SICORE
   Private _dtDetalle As DataTable

   Private _tit As Dictionary(Of String, String)
   Private _ord As Dictionary(Of String, Integer)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboTiposImpuestos(cmbTipoImpuesto, "PERCEPCION")
         _publicos.CargaComboProvincias(cmbProvincia)

         ugDetalle.AgregarFiltroEnLinea({"NombreCliente"})
         ugDetalle.AgregarTotalesSuma({"BaseImponible", "ImporteTotal"})

         _tit = GetColumnasVisiblesGrilla(ugDetalle)

         RefrescarDatosGrilla()

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

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbExportar_Click(sender As Object, e As EventArgs) Handles tsbExportar.Click
      TryCatched(
      Sub()
         Dim stb = New StringBuilder()

         stb.AppendFormat("Realmente desea generar el archivo para los {0} comprobantes?", ugDetalle.Count())

         If MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim ar As ArchivoDestinoExportacion = New ArchivoDestinoExportacion()
            If ar.ShowDialog() = Windows.Forms.DialogResult.Yes Then


               If Not String.IsNullOrEmpty(ar.txtArchivoDestino.Text) Then

                  If chbProvincia.Checked And Me.cmbProvincia.SelectedIndex = 7 Then
                     CrearSIAGER(_dtDetalle)
                     _siager.GrabarArchivo(ar.txtArchivoDestino.Text)
                     MessageBox.Show("Se Exportaron " & Me._siager.Lineas.Count.ToString() & " comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                  Else
                     Dim tipoImpuesto As Entidades.TipoImpuesto = New Reglas.TiposImpuestos().GetUno(Entidades.TipoImpuesto.Tipos.PIIBB)
                     If tipoImpuesto.AplicativoAfip = "SIRCAR" Then
                        CreaSIRCAR(_dtDetalle)
                        _SIRCAR.GrabarArchivo(ar.txtArchivoDestino.Text, Entidades.TipoImpuesto.Tipos.PIIBB)
                        MessageBox.Show("Se Exportaron " & Me._SIRCAR.Lineas.Count.ToString() & " comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                     Else
                        CrearSIPRIB(_dtDetalle)
                        _siprib.GrabarArchivo(ar.txtArchivoDestino.Text)
                        MessageBox.Show("Se Exportaron " & Me._siprib.Lineas.Count.ToString() & " comprobantes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                     End If

                  End If

               End If
            End If
         Else
            MessageBox.Show("Ha cancelado la exportación.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Sub)
   End Sub
   Private Sub tsbExportarParaSicore_Click(sender As Object, e As EventArgs) Handles tsbExportarParaSicore.Click
      TryCatched(
      Sub()
         Dim stb = New StringBuilder()

         stb.AppendFormat("Realmente desea generar el archivo para los {0} comprobantes?", ugDetalle.Count())

         If ShowPregunta(stb.ToString()) = Windows.Forms.DialogResult.Yes Then
            Dim ar = New ArchivoDestinoExportacion()
            If ar.ShowDialog() = Windows.Forms.DialogResult.Yes Then
               If Not String.IsNullOrEmpty(ar.txtArchivoDestino.Text) Then
                  CrearSICORE(_dtDetalle)
                  _sicore.GrabarArchivo(ar.txtArchivoDestino.Text)
                  ShowMessage(String.Format("Se Exportaron {0} comprobantes EXITOSAMENTE !!!", _sicore.Lineas.Count))
               End If
            End If
         Else
            ShowMessage("Ha cancelado la exportación.")
         End If
      End Sub)
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
      Sub()
         If ugDetalle.Count() = 0 Then Exit Sub

         Dim dt = ugDetalle.DataSource(Of DataTable)
         Dim parm = New ReportParameterCollection(CargarFiltrosImpresion())

         Dim frmImprime = New VisorReportes("Eniac.Win.InfPercepciones.rdlc", "dsAFIP_Retenciones", dt, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub chbTipoImpuesto_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoImpuesto.CheckedChanged
      TryCatched(Sub() chbTipoImpuesto.FiltroCheckedChanged(cmbTipoImpuesto))
   End Sub
   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged
      TryCatched(Sub() chbProvincia.FiltroCheckedChanged(cmbProvincia))
   End Sub
   Private Sub cmbTipoImpuesto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoImpuesto.SelectedIndexChanged
      TryCatched(
      Sub()
         If cmbTipoImpuesto.SelectedIndex > -1 Then
            chbProvincia.Enabled = cmbTipoImpuesto.SelectedValue.ToString() = Entidades.TipoImpuesto.Tipos.PIIBB.ToString()
            cmbProvincia.Enabled = chbProvincia.Enabled AndAlso chbProvincia.Checked
         Else
            chbProvincia.Enabled = False
            cmbProvincia.Enabled = False
         End If
      End Sub)
   End Sub

#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbTipoImpuesto.Checked And cmbTipoImpuesto.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó un Tipo Impuesto aunque activó ese Filtro")
            cmbTipoImpuesto.Focus()
            Exit Sub
         End If

         If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
            bscCodigoCliente.Focus()
            Exit Sub
         End If

         If chbProvincia.Enabled AndAlso chbProvincia.Checked And cmbProvincia.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Provincia aunque activó ese Filtro")
            cmbProvincia.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle()

         If ugDetalle.Count > 0 Then
            btnConsultar.Focus()
            tsbExportar.Enabled = True
            tsbExportarParaSicore.Enabled = cmbTipoImpuesto.ValorSeleccionado(Of String) = Entidades.TipoImpuesto.Tipos.PIVA.ToString()
         Else
            tsbExportar.Enabled = False
            tsbExportarParaSicore.Enabled = False
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
         bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
         bscCliente.Permitido = False
         bscCodigoCliente.Permitido = False

         btnConsultar.Focus()
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today

      chbTipoImpuesto.Checked = False
      chbCliente.Checked = False

      tsbExportar.Enabled = False
      tsbExportarParaSicore.Enabled = False

      ugDetalle.ClearFilas()

   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idTipoImpuesto = cmbTipoImpuesto.ValorSeleccionado(chbTipoImpuesto, String.Empty)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idProvincia = cmbProvincia.ValorSeleccionado(chbProvincia, String.Empty)

      Dim rPercepciones = New Reglas.PercepcionVentas()
      _dtDetalle = rPercepciones.GetTodos(actual.Sucursal.Id, dtpDesde.Value, dtpHasta.Value,
                                          idTipoImpuesto.ToString(), idCliente, idProvincia)

      ugDetalle.DataSource = _dtDetalle
      AjustarColumnasGrilla(ugDetalle, _tit)

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         .AppendFormat("Fechas: Desde {0:dd/MM/yyyy} Hasta el {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         If chbCliente.Checked Then
            .AppendFormat(" - Cliente: {0} - {1}", bscCodigoCliente.Text.Trim(), bscCliente.Text.Trim())
         End If
         If chbTipoImpuesto.Checked Then
            .AppendFormat(" - Impuesto: {0}", cmbTipoImpuesto.Text)
         End If
         If chbProvincia.Checked Then
            .AppendFormat(" - Provincia: {0}", cmbProvincia.Text)
         End If
         If chbAplicativoAfip.Checked Then
            .AppendFormat(" - Aplicativo: {0}", cmbAplicativoAfip.Text)
         End If
      End With
      Return filtro.ToString()
   End Function

#Region "Aplicativos"
   Private Sub CrearSIPRIB(dt As DataTable)

      Dim i As Integer = 0

      Try
         Me._siprib = New SIPRIBArchivo()

         Dim linea As SIPRIBArchivoLinea
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = dt.Rows.Count
         Me.tspBarra.Value = 0

         For Each dr As DataRow In dt.Rows

            Me.tspBarra.Value = i

            i += 1

            linea = New SIPRIBArchivoLinea()

            With linea
               'Se pone fijo el 2 porque es una Percepcion.
               .CodigoOperacion = 2
               .FechaDeLaRetencion = DateTime.Parse(dr("FechaEmision").ToString())
               'queda fijo por el momento con el valor:
               '029 Art.10 - inciso J - (Res. Gral. 15/97 y Modif.)
               .CodigoArticulo = 29

               .IdTipoComprobante = dr("IdTipoComprobante").ToString()

               'Letra de comprobante
               .LetraComprobante = dr("Letra").ToString()

               'Nro. del comprobante
               .NroComprobante = Decimal.Parse(dr("NumeroComprobante").ToString())

               'Fecha de emisión comprobante (menor o igual a la fecha de la retención/percepción).
               .FechaEmisionComprobante = DateTime.Parse(dr("FechaEmision").ToString())

               'Importe comprobante (debe ser mayor a 0). Numérico 9 enteros 2 decimales separados por comas.
               If New Reglas.CategoriasFiscales().GetUno(Short.Parse(dr("IdCategoriaFiscal").ToString())).IvaDiscriminado Then
                  .ImporteComprobante = Decimal.Parse(dr("ImporteComprobante").ToString())
               Else
                  .ImporteComprobante = Decimal.Parse(dr("ImporteSubTotalComprobante").ToString())
               End If


               'Tipo documento retenido/percibido. Numérico de 1 posición
               'va fijo el 3 porque es el CUIT
               .TipoDocPercibido = 3

               'Nro. documento retenido/percibido. Se validará según el tipo. Numérico 11 posiciones.
               If Not String.IsNullOrEmpty(dr("Cuit").ToString()) Then
                  .NroDocPercibido = Long.Parse(dr("Cuit").ToString())
               Else
                  stb.Append("El Cliente " & dr("NombreCliente").ToString() & ", No tiene Cargado el CUIT, la Linea queda invalida.").AppendLine()
                  Continue For
               End If

               'Condición frente a Ingresos Brutos: Numérico de 1 posición 
               If Boolean.Parse(dr("InscriptoIBStaFe").ToString()) Then
                  .CondicionFrenteAIIBB = 1 'Inscripto 
               Else
                  .CondicionFrenteAIIBB = 3 'No inscripto, no obligado a inscribirse.
               End If

               'Nro de inscripción en Ingresos Brutos: será exigido si condición frente a ingresos brutos es 1, 
               'de lo contrario deberá ingresar ceros.  Numérico de 10 posiciones.
               If .CondicionFrenteAIIBB = 1 Then
                  If Not String.IsNullOrEmpty(dr("IngresosBrutos").ToString()) Then
                     .NroInscripcionIIBB = Long.Parse(dr("IngresosBrutos").ToString().Replace("-", ""))
                  Else
                     stb.Append("El Cliente " & dr("NombreCliente").ToString() & ", No tiene Cargado el Numero de IIBB, la Linea queda invalida.").AppendLine()
                     Continue For
                  End If
               End If

               'Situación frente a IVA: Numérico de 1 posición.
               .IdCategoriaFiscal = Short.Parse(dr("IdCategoriaFiscal").ToString())

               'Marca inscripción en otros gravámenes (Artículo 138 Código Fiscal): Numérico de 1 posición
               'lo puse fijo a No inscripto en otros gravámenes
               .MarcaInscripcionEnOtrosGravamenes = 0

               'Marca inscripción en Derecho de Registro e Inspección: Numérico de 1 posición
               'lo puse fijo a No inscripto en derecho de registro e inspección
               .MarcaInscDerechoRegistroInspeccion = 0

               'Importe Otros Gravámenes 
               If .MarcaInscDerechoRegistroInspeccion = 1 Then
                  .ImporteOtrosGravamenes = 0
               End If

               'Importe I.V.A. 
               If .SituacionFrenteAIVA = 1 Then
                  .ImporteIVA = 0
               End If

               'Monto imponible
               .MontoImponible = Decimal.Parse(dr("BaseImponible").ToString())

               'Alícuota
               .Alicuota = Decimal.Parse(dr("Alicuota").ToString())

               'Impuesto determinado
               .ImpuestoDeterminado = Decimal.Parse(dr("ImporteTotal").ToString())

               'Monto deducible derecho de registro e inspección
               If .MarcaInscDerechoRegistroInspeccion = 1 Then
                  .MontoDeducible = 0
               End If

               'Monto retenido
               .MontoRetenido = .ImpuestoDeterminado - .MontoDeducible

               'Artículo/Inciso para el cálculo del monto de la retención/percepción
               'fijo por 003	Art. 5° inciso 2)(Res. Gral. 15/97 y Modif.)
               .ArticuloParaPercepcion = 3

               If .CondicionFrenteAIIBB = 1 Then

                  'Tipo de exención: numérico de 1 posición
                  If Not String.IsNullOrEmpty(dr("IdTipoDeExension").ToString()) Then
                     .TipoDeExension = Short.Parse(dr("IdTipoDeExension").ToString())
                  Else
                     .TipoDeExension = 0
                  End If


                  'Año de exención:  numérico de 4 posiciones
                  If .TipoDeExension = 0 Or .TipoDeExension = 4 Then
                     .AñoDeExension = 0
                  Else
                     .AñoDeExension = Integer.Parse(dr("AnioExension").ToString())
                  End If

                  'Número de certificado de exención: alfanumérico de 6 posiciones
                  .NumeroCertificadoExencion = dr("NroCertExension").ToString()

                  'Número de certificado propio:  alfanumérico de 12 posiciones
                  .NumeroCertificadoPropio = dr("NroCertPropio").ToString()

               Else

                  .TipoDeExension = 0
                  .AñoDeExension = 0
                  .NumeroCertificadoExencion = ""
                  .NumeroCertificadoPropio = ""

               End If


            End With

            Me._siprib.Lineas.Add(linea)

         Next

         If stb.Length > 0 Then
            MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If

      Catch ex As Exception
         Throw New Exception(ex.Message & " Linea " & i.ToString())
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try


   End Sub
   Private Sub CrearSIAGER(dt As DataTable)

      Dim i As Integer = 0

      Try
         Me._siager = New SIAGERArchivo()

         Dim linea As SIAGERArchivoLinea
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = dt.Rows.Count
         Me.tspBarra.Value = 0

         For Each dr As DataRow In dt.Rows

            Me.tspBarra.Value = i

            i += 1

            linea = New SIAGERArchivoLinea()

            With linea

               .TipoAgente = 1
               If dr("Act").ToString() <> "" Then
                  .MotivoMovimiento = Integer.Parse(dr("Act").ToString())
               Else
                  .MotivoMovimiento = 61
               End If
               .CUITCliente = Long.Parse(dr("CUIT").ToString())
               .FechaPercepcion = DateTime.Parse(dr("FechaEmision").ToString())
               .IdTipoComprobante = dr("CodigoComprobanteSifere").ToString()
               .LetraComprobante = dr("Letra").ToString()
               .CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
               .NroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
               .ImporteBase = Decimal.Parse(dr("BaseImponible").ToString())
               .Alicuota = Decimal.Parse(dr("Alicuota").ToString())
               .ImpuestoPercibido = Decimal.Parse(dr("ImporteTotal").ToString())
               .Anulacion = 0
               .ContribuyenteConvMultilateral = 1

            End With

            Me._siager.Lineas.Add(linea)

         Next

         If stb.Length > 0 Then
            MessageBox.Show(stb.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If

      Catch ex As Exception
         Throw New Exception(ex.Message & " Linea " & i.ToString())
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try


   End Sub
   Private Function CreaSIRCAR(dt As DataTable) As SIRCARArchivo
      Dim i As Integer = 0
      _SIRCAR = New SIRCARArchivo()
      Try
         Dim linea As SIRCARArchivoLinea
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         Me.tspBarra.Visible = True
         Me.tspBarra.Minimum = 0
         Me.tspBarra.Maximum = dt.Rows.Count
         Me.tspBarra.Step = 1
         Me.tspBarra.Value = 0

         For Each dr As DataRow In dt.Rows
            Me.tspBarra.PerformStep()
            i += 1
            linea = New SIRCARArchivoLinea()
            With linea
               .Procesar = True

               'Número de Renglón (único por archivo)
               .NumeroRenglon = i

               'Tipo de Comprobante 
               .IdTipoComprobante = dr("IdtipoComprobante").ToString()

               'Letra del Comprobante (A, B ó C, según tipo de Comprobante) Z si no existe identificación del Comprobante 
               .LetraComprobante = dr("Letra").ToString()

               'Número de Comprobante (incluye el punto de venta)
               .NroComprobante = Decimal.Parse(dr("CentroEmisor").ToString() & dr("NumeroComprobante").ToString())

               'Nro. documento retenido/percibido. Se validará según el tipo. Numérico 11 posiciones.
               If Not String.IsNullOrEmpty(dr("Cuit").ToString()) Then
                  .CuitProveedor = Long.Parse(dr("Cuit").ToString())
               Else
                  stb.Append("El Cliente " & dr("NombreCliente").ToString() & ", No tiene Cargado el CUIT, la Linea queda invalida.").AppendLine()
                  Continue For
               End If

               .FechaDeLaRetencion = DateTime.Parse(dr("FechaEmision").ToString())

               'Nro de inscripción en Ingresos Brutos: será exigido si condición frente a ingresos brutos es 1, 
               'de lo contrario deberá ingresar ceros.  Numérico de 10 posiciones.
               'If .CondicionFrenteAIIBB = 1 Then
               '   If Not String.IsNullOrEmpty(dr("IngresosBrutos").ToString()) Then
               '      .NroInscripcionIIBB = Long.Parse(dr("IngresosBrutos").ToString().Replace("-", ""))
               '      If .NroInscripcionIIBB = Long.Parse(Publicos.IngresosBrutos.ToString().Replace("-", "")) Then
               '         stb.Append("El Cliente " & dr("NombreProveedor").ToString() & ", tiene el mismo Numero de IIBB que la Empresa, la Linea queda invalida.").AppendLine()
               '         Continue For
               '      End If
               '   Else
               '      stb.Append("El Cliente " & dr("NombreProveedor").ToString() & ", No tiene Cargado el Numero de IIBB, la Linea queda invalida.").AppendLine()
               '      Continue For
               '   End If
               'End If



               'Monto Sujeto a Retención (numérico sin separador de miles)
               Dim MontoImp As Decimal = 0
               MontoImp = Math.Round(Decimal.Parse(dr("BaseImponible").ToString()), 2)

               .MontoImponible = MontoImp

               'Alícuota (porcentaje sin separador de miles)
               .Alicuota = Decimal.Parse(dr("Alicuota").ToString())

               'Impuesto determinado
               Dim Imp As Decimal = 0
               Imp = Decimal.Parse(dr("ImporteTotal").ToString())
               .ImpuestoDeterminado = Imp

               'Monto Retenido (numérico sin separador de miles, se obtiene de multiplicar el campo 7 por el campo 8 y dividirlo por 100) 
               .MontoRetenido = Math.Round(.ImpuestoDeterminado, 2)


               .TipoRegimen = New Reglas.Actividades().GetUno(dr("IdProvincia").ToString(), Integer.Parse(dr("IdActividad").ToString())).CodigoAfip

               .Jurisdiccion = New Reglas.Provincias().GetUno(dr("IdProvincia").ToString()).Jurisdiccion

               '   .Jurisdiccion = Integer.Parse(dr("Jurisdiccion").ToString())

            End With
            _SIRCAR.Lineas.Add(linea)
         Next

         If stb.Length > 0 Then
            stb.Append("¿Desea continuar?")
            If ShowPregunta(stb.ToString()) = Windows.Forms.DialogResult.No Then
               Return Nothing
            End If
         End If

         Return _SIRCAR
      Catch ex As Exception
         Throw New Exception(ex.Message & " Linea " & i.ToString(), ex)
      Finally
         Me.tspBarra.Value = 0
         Me.tspBarra.Visible = False
      End Try

   End Function
   Private Sub CrearSICORE(dt As DataTable)
      _sicore = New SICORE()

      tspBarra.Visible = True
      tspBarra.Minimum = 0
      tspBarra.Maximum = dt.Rows.Count
      tspBarra.Value = 0

      Dim i As Integer = 0

      For Each dr In dt.AsEnumerable()
         '  tspBarra.Value = i

         Dim linea = New SICORELinea()

         'Código de comprobante / Entero / Desde 1 Hasta 2 / Longitud 2
         linea.CodigoDeComprobante = dr.Field(Of Integer?)("CodigoComprobanteSicore").IfNull()
         'Fecha de emisión del comprobante (DD/MM/YYYY) / Fecha / Desde 3 Hasta 12 / Longitud 10
         linea.FechaEmisionDelComprobante = dr.Field(Of Date?)("FechaEmision").IfNull()
         'Número del comprobante / Texto / Desde 13 Hasta 28 / Longitud 16
         linea.NroDeComprobante = String.Format("{0:00000}{1:00000000}", dr.Field(Of Integer?)("CentroEmisor").IfNull(), dr.Field(Of Long?)("NumeroComprobante").IfNull())
         'Importe del comprobante / Decimal / Desde 29 Hasta 44 / Longitud 16
         linea.ImporteDelComprobante = dr.Field(Of Decimal)("ImporteComprobante")  ''= cctt.ImporteTotal

         linea.CodigoDeImpuesto = 767 ' 767 es el código del SICORE-IMPTO AL VALOR AGREGADO

         'Código de régimen / Entero / Desde 48 Hasta 50 / Longitud 3
         linea.CodigoDeRegimen = dr.Field(Of Integer?)("CodigoAFIP").IfNull()
         linea.CodigoDeOperacion = 2 ' Percepcion
         'Base de cálculo / Decimal / Desde 52 Hasta 65 / Longitud 14
         linea.BaseDeCalculo = dr.Field(Of Decimal?)("BaseImponible").IfNull()


         'Fecha de emisión de la retención (DD/MM/YYYY) / Fecha / Desde 66 Hasta 75 / Longitud 10
         linea.FechaEmisionRetencion = dr.Field(Of Date?)("FechaEmision").IfNull()

         'Código de condición / Entero / Desde 76 Hasta 77 / Longitud 2
         If dr.Field(Of Decimal)("Alicuota") = 3 Then
            linea.CodigoDeCondicion = 13 'Inscripto
         ElseIf dr.Field(Of Decimal)("Alicuota") = 1.5 Then
            linea.CodigoDeCondicion = 14
         End If

         'Retención practicada a sujetos suspendidos según: / Entero / Desde 78 Hasta 78 / Longitud 1
         linea.RetencionPracticadaASuspendidos = 0 'Ninguno
         'Importe de la retención / Decimal / Desde 79 Hasta 92 / Longitud 14
         linea.ImporteDeLaRetencion = dr.Field(Of Decimal?)("ImporteTotal").IfNull()
         'Porcentaje de exclusión / Decimal / Desde 93 Hasta 98 / Longitud 6
         linea.PorcentajeDeExclusion = 0 ' cctt.Retenciones(0).Alicuota
         'Fecha de emisión del boletín / Fecha / Desde 99 Hasta 108 / Longitud 10

         linea.FechaEmisionDelBoletin = Nothing
         'Tipo de documento del retenido / Entero / Desde 109 Hasta 110 / Longitud 2

         'Aunque podria no tener el CUIT, por la categoria fiscal deben reportarlo. Es preferible que haya problemas y que corrijan el dato.
         'If Not String.IsNullOrEmpty(cctt.Proveedor.CuitProveedor) Then

         If dr.Field(Of Boolean?)("SolicitaCUIT").IfNull(True) Then
            linea.TipoDocumentoDelRetenido = dr.Field(Of Integer?)("IdAFIPTipoDocumentoCuit").IfNull()
            'Número de documento del retenido / Texto / Desde 111 Hasta 130 / Longitud 20
            linea.NumeroDocumentoDelRetenido = dr.Field(Of String)("Cuit").IfNull()
         Else
            linea.TipoDocumentoDelRetenido = dr.Field(Of Integer?)("IdAFIPTipoDocumento").IfNull()
            'Número de documento del retenido / Texto / Desde 111 Hasta 130 / Longitud 20
            linea.NumeroDocumentoDelRetenido = dr.Field(Of String)("NroDocCliente").IfNull()
         End If

         ''estos son datos para el certificado del exterior -----------------------------------------
         'Número certificado original / Entero / Desde 131 Hasta 144 / Longitud 14
         'Denominación del ordenante / Texto / Desde 145 Hasta 174 / Longitud 30
         'Acrecentamiento / Entero / Desde 175 Hasta 175 / Longitud 1
         'Cuit del país del retenido / Texto / Desde 176 Hasta 186 / Longitud 11
         'Cuit del ordenante / Texto / Desde 187 Hasta 197 / Longitud 11

         'para cada linea le digo si la procesa cuando va a grabar el archivo o no.
         linea.Procesar = True

         _sicore.Lineas.Add(linea)

         i += 1
         tspBarra.Value = i
      Next

   End Sub
#End Region

#End Region

End Class