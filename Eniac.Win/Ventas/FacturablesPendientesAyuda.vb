Public Class FacturablesPendientesAyuda

#Region "Campos"

   Private _publicos As Publicos

   Private _idTipoComprobanteInvocado0 As String    'No puede tener el nombre _idTipoComprobante porque coincide con el parametro.
   Private _tipoComprobanteFacturador As Entidades.TipoComprobante
   Private _idListaPrecios As Integer
   Private _idCliente As Long
   Private _soloCopia As Boolean

   Private _dtComprobantes As DataTable
   Private _comprobantesSeleccionados As List(Of Entidades.Venta)
   Private _tit As Dictionary(Of String, String)

   '# El diccionario guarda la clave primaria de Ventas + Mensaje de Error
   Private dicErrores As New Dictionary(Of Tuple(Of Integer, String, String, Integer, Long), String)()

#End Region

#Region "Propiedades"
   Public ReadOnly Property ComprobantesSeleccionados() As List(Of Entidades.Venta)
      Get
         Return _comprobantesSeleccionados
      End Get
   End Property
#End Region

#Region "Constructores"
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub
   Public Sub New(idTipoComprobanteFacturador As String, idListaPrecios As Integer, idTipoComprobante As String, idCliente As Long, comprobantesSeleccionados As List(Of Entidades.Venta))
      Me.New()

      _idTipoComprobanteInvocado0 = idTipoComprobante
      _tipoComprobanteFacturador = New Reglas.TiposComprobantes().GetUno(idTipoComprobanteFacturador)
      _idListaPrecios = idListaPrecios
      _idCliente = idCliente

      _comprobantesSeleccionados = comprobantesSeleccionados
      If _comprobantesSeleccionados Is Nothing Then
         _comprobantesSeleccionados = New List(Of Entidades.Venta)()
      End If

   End Sub
   <Obsolete("Si no tengo comprobantes seleccionados usar el otro constructor pero pasar nothing como parámetro", False)>
   Public Sub New(idTipoComprobanteFacturador As String, idListaPrecios As Integer, idTipoComprobante As String, IdCliente As Long)
      Me.New(idTipoComprobanteFacturador, idListaPrecios, idTipoComprobante, IdCliente, comprobantesSeleccionados:=Nothing)
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() CargarValoresIniciales())
      TryCatched(Sub() _tit = GetColumnasVisiblesGrilla(ugDetalle))
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.Escape Then
         btnCancelar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub chbNroComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbNroComprobante.CheckedChanged
      TryCatched(
      Sub()
         txtNroComprobante.Enabled = chbNroComprobante.Checked
         If Not chbNroComprobante.Checked Then
            txtNroComprobante.Clear()
         Else
            txtNroComprobante.Focus()
         End If
      End Sub)
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

#Region "Eventos Buscador Clientes"
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(usaPermitido:=True, bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCodigoCliente)
         Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, True)
      End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaClientes2(bscCliente)
         bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), True)
      End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador Localidades"
   Private Sub chbLocalidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbLocalidad.CheckedChanged
      TryCatched(Sub() chbLocalidad.FiltroCheckedChanged(usaPermitido:=True, bscCodigoLocalidad, bscNombreLocalidad))
   End Sub
   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaLocalidades(bscCodigoLocalidad)
         bscCodigoLocalidad.Datos = New Reglas.Localidades().GetPorCodigo(bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaLocalidades(bscNombreLocalidad)
         bscNombreLocalidad.Datos = New Reglas.Localidades().GetPorNombre(bscNombreLocalidad.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion, bscNombreLocalidad.BuscadorSeleccion
      TryCatched(Sub() CargarLocalidad(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged
      TryCatched(Sub() chbProvincia.FiltroCheckedChanged(cmbProvincia))
   End Sub

   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      TryCatched(
      Sub()
         ValidarCargaGrillaDetalle()
         CargaGrillaDetalle()
      End Sub)
   End Sub

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(
      Sub()
         ugDetalle.MarcarDesmarcar(cmbTodos, "Check")
         RecalcularTotalSeleccionado()
      End Sub)
   End Sub
#End Region

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() If Aceptar() Then Close(DialogResult.OK))
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub

   Private Sub chbSoloCopiar_CheckedChanged(sender As Object, e As EventArgs) Handles chbSoloCopiar.CheckedChanged
      TryCatched(
      Sub()
         If chbSoloCopiar.Checked Then chbSoloCabecera.Checked = False
         '# En caso de realizar una copia, no importan los errores dentro del error area. El comprobante se puede solo copiar.
         'If Not String.IsNullOrEmpty(_TextError.ToString()) Then
         If dicErrores.Count > 0 Then
            btnAceptar.Enabled = chbSoloCopiar.Checked
         Else
            btnAceptar.Enabled = True
         End If
      End Sub)
   End Sub

   Private Sub txtNroComprobante_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroComprobante.KeyDown
      TryCatched(
      Sub()
         If e.KeyCode = Keys.Enter Then
            btnBuscar.Focus()
            btnBuscar.PerformClick()
            If ugDetalle.Rows.Count = 1 Then
               cmbTodos.SelectedIndex = 0
               btnTodos.PerformClick()
               btnAceptar.Focus()
            End If
         End If
      End Sub)
   End Sub

   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugDetalle.CellChange
      TryCatched(
      Sub()
         If e.Cell.Column.Key = "Check" Then
            ugDetalle.UpdateData()

            If _tipoComprobanteFacturador.CoeficienteStock <> 0 Then
               Dim drVenta = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
               Dim invocados = New Reglas.VentasInvocados().GetInvocados(drVenta.Field(Of Integer)(Entidades.Venta.Columnas.IdSucursal.ToString()),
                                                                                    drVenta.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                                                                    drVenta.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                                                                    drVenta.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                                                                                    drVenta.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()))

               If invocados.Count > 0 Then
                  For Each dr In invocados.Where(Function(vv) vv.Invocado.CoeficienteStock <> 0)
                     Dim pk = New Tuple(Of Integer, String, String, Integer, Long) _
                                                  (drVenta.Field(Of Integer)(Entidades.Venta.Columnas.IdSucursal.ToString()),
                                                   drVenta.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                                   drVenta.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                                   drVenta.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                                                   drVenta.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()))
                     If drVenta.Field(Of Boolean)("Check") Then
                        Dim msgError = String.Format("El Comprobante {0} {1} {2} {3}, Invocó a otro que afectó Stock, NO puede seleccionarlo.",
                                                                drVenta.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                                                drVenta.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                                                drVenta.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()),
                                                                drVenta.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString())) '# Guardo el error para mostrarlo luego en ErrorArea
                        If Not dicErrores.ContainsKey(pk) Then
                           dicErrores.Add(pk, msgError)
                        End If
                     Else
                        If dicErrores.ContainsKey(pk) Then
                           dicErrores.Remove(pk)
                        End If
                     End If
                  Next
               End If
            End If

            RecalcularTotalSeleccionado()

            btnAceptar.Enabled = dicErrores.Count = 0 Or chbSoloCopiar.Checked
            txtTextError.Text = If(dicErrores.Count > 0, dicErrores.Values(0), String.Empty)
         End If
      End Sub)

   End Sub

#End Region

#Region "Metodos"

   Private Function Aceptar() As Boolean
      ugDetalle.UpdateData()

      Dim rVentas = New Reglas.Ventas()


      Dim drGral As Decimal? = Nothing
      For Each dr As DataRow In _dtComprobantes.Select("Check")

         'Permito si SOLO COPIA o que un Presupuesto elija Presupuesto.
         If Not chbSoloCopiar.Checked And (dr.Field(Of String)("IdTipoComprobante") = _tipoComprobanteFacturador.IdTipoComprobante And
                                           _tipoComprobanteFacturador.CoeficienteStock <> 0) Then
            clbTiposComprobantes.Focus()
            Throw New Exception("ATENCION: no puede elegir el mismo comprobante que el Invocador.")
         End If

         Dim comprobante = rVentas.GetUna(dr.Field(Of Integer)(Entidades.Venta.Columnas.IdSucursal.ToString()),
                                          dr.Field(Of String)(Entidades.Venta.Columnas.IdTipoComprobante.ToString()),
                                          dr.Field(Of String)(Entidades.Venta.Columnas.Letra.ToString()),
                                          dr.Field(Of Integer)(Entidades.Venta.Columnas.CentroEmisor.ToString()).ToShort(),
                                          dr.Field(Of Long)(Entidades.Venta.Columnas.NumeroComprobante.ToString()))

         If chbSoloCopiar.Checked Then
            comprobante.VentasProductos.
               ForEach(Sub(vp)
                          'PE-36645  >>>
                          vp.Producto.NrosSeries.Clear()
                          'No fué solicitado y habría que hacer pruebas y definir si está bien o no que copie los Lotes,
                          'pero si hubiera que eliminarlo en la copia solo habría que descomentar la línea siguiente
                          'vp.VentasProductosLotes.Clear()  
                          'PE-36645  <<<
                       End Sub)
         End If

         If _tipoComprobanteFacturador.CargaDescRecGralActual Then
            If Not drGral.HasValue Then
               drGral = comprobante.DescuentoRecargoPorc
            End If
            If drGral.Value <> comprobante.DescuentoRecargoPorc Then
               _comprobantesSeleccionados.Clear()
               ShowMessage("No se permite seleccionar comprobantes con diferentes descuentos y recargos.")
               Return False
            End If
         End If

         _comprobantesSeleccionados.Add(comprobante)

      Next

      If (_tipoComprobanteFacturador.InformaLibroIVA Or _tipoComprobanteFacturador.EsPreElectronico) AndAlso
         _comprobantesSeleccionados.Any(Function(v) v.ImpuestosVarios.Any(Function(vi) vi.IdTipoImpuesto = Entidades.TipoImpuesto.Tipos.PIVA)) AndAlso
         _comprobantesSeleccionados.Count > 1 Then
         _comprobantesSeleccionados.Clear()
         ShowMessage("No puede seleccionar más de un comprobante con Percepciones de IVA")
         Return False
      End If

      If _comprobantesSeleccionados.Count = 0 Then
         ugDetalle.Focus()
         Throw New Exception("ATENCION: NO Selecciono Ningun Comprobante para Invocar.")
      End If

      '---PE-44464- Invocar Comprobantes: alertar si los comprobantes tienen distinta cotizacion dolar y comprobante no carga precio actual
      Dim CantidadSeleccionados As Integer = ugDetalle.Rows.Cast(Of UltraGridRow)().
                                              Count(Function(dr) dr.Cells("Check").Value IsNot Nothing AndAlso
                                              dr.Cells("Check").Value.ToString().ToLower() = "true")
      If CantidadSeleccionados > 1 Then
         If (_comprobantesSeleccionados(0).IdMoneda = Entidades.Moneda.Dolar And Reglas.Publicos.Facturacion.CotizacionDolarComprobanteInvocado <> Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO) Or
                       (_comprobantesSeleccionados(0).IdMoneda = Entidades.Moneda.Peso And Reglas.Publicos.Facturacion.CotizacionDolarComprobantePesosInvocado <> Entidades.Publicos.CotizacionDolarComprobanteInvocado.NO) Then
            Dim DolarPedido As Decimal = _comprobantesSeleccionados(0).CotizacionDolar
            If Not _comprobantesSeleccionados(0).TipoComprobante.CargaPrecioActual Then
               For Each dr As UltraGridRow In Me.ugDetalle.Rows
                  If dr.Cells("Check").Value IsNot Nothing Then
                     If Boolean.Parse(dr.Cells("Check").Value.ToString()) = True Then
                        If Decimal.Parse(dr.Cells("CotizacionDolar").Value.ToString()) <> DolarPedido Then
                           _comprobantesSeleccionados.Clear()
                           ShowMessage("No se permite seleccionar comprobantes de diferentes cotizaciones de dólar.")
                           Return False
                        End If
                     End If
                  End If
               Next
            End If
         End If
      End If

      Return True
   End Function

   Private Sub CargarValoresIniciales()

      _publicos = New Publicos()

      _publicos.CargaComboDesdeEnum(cmbInvocados, GetType(Entidades.Publicos.SiNoTodos), Entidades.Publicos.SiNoTodos.NO)
      _publicos.CargaComboDesdeEnum(cmbTodos, GetType(Reglas.Publicos.TodosEnum))
      _publicos.CargaComboProvincias(cmbProvincia)

      Dim ComprobAsoc = _tipoComprobanteFacturador.ComprobantesAsociados
      _publicos.CargaListaTiposComprobantesFacturables(clbTiposComprobantes, ComprobAsoc, False)

      clbTiposComprobantes.ClearSelected()
      If _comprobantesSeleccionados IsNot Nothing Then
         Dim dt = DirectCast(clbTiposComprobantes.DataSource, DataTable)
         _comprobantesSeleccionados.ConvertAll(Function(v) v.IdTipoComprobante).Distinct().ToList().
            ForEach(Sub(id)
                       Dim dr = dt.Select(String.Format("IdTipoComprobante = '{0}'", id))
                       If dr.Length > 0 Then
                          Dim idx = dt.Rows.IndexOf(dr(0))
                          clbTiposComprobantes.SetItemChecked(idx, True)
                       End If
                    End Sub)
      End If

      '-- REQ-33460.- -------------------------------------------------------------------------------
      chbSoloCabecera.Checked = Reglas.Publicos.Facturacion.FacturacionRelacionaCabecera
      '----------------------------------------------------------------------------------------------

      'If String.IsNullOrWhiteSpace(_idTipoComprobanteInvocado0) Then
      '   Dim ComprobAsoc = _tipoComprobanteFacturador.ComprobantesAsociados
      '   _publicos.CargaListaTiposComprobantesFacturables(Me.clbTiposComprobantes, ComprobAsoc, False)
      'Else
      '   _publicos.CargaListaTiposComprobantesPedidos(Me.clbTiposComprobantes)
      'End If

      'If clbTiposComprobantes.Items.Count > 0 And _idTipoComprobanteInvocado0 <> "" Then
      '   Dim Cont As Integer = 0
      '   For Each doc As DataRowView In clbTiposComprobantes.Items
      '      If doc("IdTipoComprobante").ToString() = Me._idTipoComprobanteInvocado0 Then
      '         Me.clbTiposComprobantes.SetItemChecked(Cont, True)
      '         Exit For
      '      End If
      '      Cont += 1
      '   Next
      'End If

      If clbTiposComprobantes.Items.Count = 1 Then
         clbTiposComprobantes.SetItemChecked(0, True)
      End If

      If (TypeOf (Owner) Is FacturacionRapida) Then
         dtpDesde.Value = Date.Now.AddMinutes(-15) 'Busco lo que sucedio hace poco.
         dtpHasta.Value = Date.Now
         'Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)
      Else
         dtpDesde.Value = Date.Today.AddDays(-(Publicos.FacturacionDiasInvocacionComprobantes))   ' el today no tiene hora, adrede para que arranque con cero
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
         'Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)
      End If

      chbCliente.Enabled = Reglas.Publicos.Facturacion.FacturacionInvocarDeOtroCliente

      ugDetalle.AgregarTotalesSuma({Entidades.Venta.Columnas.ImporteTotal.ToString()})
      'ugDetalle.AgregarTotalCustomColumna(Entidades.Venta.Columnas.Kilos.ToString(),
      '                                    New CustomSummaries.SummaryTotalSeleccionado(_dtComprobantes,
      '                                                                                 Entidades.Venta.Columnas.ImporteTotal.ToString(),
      '                                                                                 "Check"))
      ugDetalle.AgregarFiltroEnLinea({Entidades.Venta.Columnas.Observacion.ToString()})

   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells(Entidades.Cliente.Columnas.NombreCliente.ToString()).Value.ToString()
         bscCodigoCliente.Text = dr.Cells(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Value.ToString()
         bscCodigoCliente.Tag = dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()
         bscCliente.Permitido = False
         bscCodigoCliente.Permitido = False
         btnBuscar.Focus()
      End If
   End Sub
   Private Sub CargarLocalidad(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
         bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
         bscNombreLocalidad.Permitido = False
         bscCodigoLocalidad.Permitido = False
         btnBuscar.Focus()
      End If
   End Sub

   Private Sub ValidarCargaGrillaDetalle()
      If clbTiposComprobantes.CheckedItems.Count = 0 Then
         clbTiposComprobantes.Focus()
         Throw New Exception("ATENCION: Debe elegir al menos un Tipo de Comprobante")
      End If

      Dim descripcionPrimerTC As String = String.Empty
      Dim afectaCajaPrimerTC As Boolean = False
      Dim grabaLibroPrimerTC As Boolean = False
      Dim coeficienteStockPrimerTC As Integer

      Dim tiposSeleccionados = clbTiposComprobantes.CheckedItems
      If tiposSeleccionados.Count > 0 Then
         Dim dr = DirectCast(tiposSeleccionados(0), DataRowView).Row
         descripcionPrimerTC = dr.Field(Of String)(Entidades.TipoComprobante.Columnas.Descripcion.ToString()).Trim().ToUpper()
         afectaCajaPrimerTC = dr.Field(Of Boolean)(Entidades.TipoComprobante.Columnas.AfectaCaja.ToString())
         grabaLibroPrimerTC = dr.Field(Of Boolean)(Entidades.TipoComprobante.Columnas.GrabaLibro.ToString())
         coeficienteStockPrimerTC = dr.Field(Of Integer)(Entidades.TipoComprobante.Columnas.CoeficienteStock.ToString())
      End If

      Try
         For Each doc As DataRowView In tiposSeleccionados
            Dim dr = doc.Row
            If grabaLibroPrimerTC <> dr.Field(Of Boolean)(Entidades.TipoComprobante.Columnas.GrabaLibro.ToString()) Then
               Throw New Exception(String.Format("ATENCION: el Tipo Comprobante '{0}' tiene distinta Configuracion de IVA del '{1}'.",
                                                 dr.Field(Of String)(Entidades.TipoComprobante.Columnas.Descripcion.ToString()).Trim().ToUpper(), descripcionPrimerTC))
            End If
            If afectaCajaPrimerTC <> dr.Field(Of Boolean)(Entidades.TipoComprobante.Columnas.AfectaCaja.ToString()) Then
               Throw New Exception(String.Format("ATENCION: el Tipo Comprobante '{0}' tiene distinta Configuracion de Caja del '{1}'.",
                                                 dr.Field(Of String)(Entidades.TipoComprobante.Columnas.Descripcion.ToString()).Trim().ToUpper(), descripcionPrimerTC))
            End If
            'Permito que sean -1 y 1, pero no uno que sea 0 (y 1 / -1)
            If coeficienteStockPrimerTC <> dr.Field(Of Integer)(Entidades.TipoComprobante.Columnas.CoeficienteStock.ToString()) And
               (coeficienteStockPrimerTC = 0 Or dr.Field(Of Integer)(Entidades.TipoComprobante.Columnas.CoeficienteStock.ToString()) = 0) Then
               Throw New Exception(String.Format("ATENCION: el Tipo Comprobante '{0}' tiene distinta Configuracion de Coeficiente Stock del '{1}' cuando algun valor es 0 (Cero).",
                                                 dr.Field(Of String)(Entidades.TipoComprobante.Columnas.Descripcion.ToString()).Trim().ToUpper(), descripcionPrimerTC))
            End If
            'Permito que sean -1 y 1, pero no uno que sea 0 (y 1 / -1), pero tampoco permito distintos si el invocador es una NCRED.
            If coeficienteStockPrimerTC <> dr.Field(Of Integer)(Entidades.TipoComprobante.Columnas.CoeficienteStock.ToString()) And
               _tipoComprobanteFacturador.CoeficienteValores = -1 Then
               Throw New Exception(String.Format("ATENCION: el Tipo Comprobante '{0}' tiene distinta Configuracion de Coeficiente Stock del '{1}', y NO lo permite el invocador '{2}'.",
                                                 dr.Field(Of String)(Entidades.TipoComprobante.Columnas.Descripcion.ToString()).Trim().ToUpper(), descripcionPrimerTC, _tipoComprobanteFacturador.Descripcion.Trim.ToUpper()))
            End If
         Next
      Catch
         clbTiposComprobantes.Focus()
         Throw
      End Try

      If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
         bscCodigoCliente.Focus()
         Throw New Exception("No seleccionó un Cliente aunque activó ese Filtro")
      End If

      If chbNroComprobante.Checked And txtNroComprobante.ValorNumericoPorDefecto(0L) = 0 Then
         txtNroComprobante.Focus()
         Throw New Exception("No ingresó un Nro Comprobante aunque activó ese Filtro")
      End If
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idTiposComprobantes = New List(Of String)()
      For Each doc As DataRowView In clbTiposComprobantes.CheckedItems
         idTiposComprobantes.Add(doc("IdTipoComprobante").ToString())
      Next

      'If Me.clbTiposComprobantes.Items.Count > 0 Then
      '   If Me.cmbTiposComprobantes.SelectedItem IsNot Nothing Then
      '      'strTipoComprobante = Me.cmbTiposComprobantes.SelectedItem("IdTipoComprobante").ToString()
      '      IdTipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
      '   End If
      'End If

      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), _idCliente)
      Dim nroComprobante = If(chbNroComprobante.Checked, Long.Parse(Me.txtNroComprobante.Text.ToString()), 0L)
      Dim idLocalidad = If(chbLocalidad.Checked, bscCodigoLocalidad.Text.ValorNumericoPorDefecto(0I), 0I)
      Dim idProvincia = cmbProvincia.ValorSeleccionado(chbProvincia, String.Empty)

      Dim oVentas = New Reglas.Ventas()
      Dim dt = oVentas.GetFacturables(actual.Sucursal.Id,
                                      dtpDesde.Value, dtpHasta.Value,
                                      idTiposComprobantes, nroComprobante,
                                      idCliente,
                                      idLocalidad, idProvincia,
                                      cmbInvocados.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos))
      ugDetalle.DataSource = dt
      AjustarColumnasGrilla(ugDetalle, _tit)

      If _dtComprobantes IsNot Nothing Then _dtComprobantes.Dispose()
      _dtComprobantes = dt

      Dim decTotal = ObjectExtensions.ValorNumericoPorDefecto(dt.Compute(String.Format("SUM({0})", Entidades.Venta.Columnas.ImporteTotal.ToString()), String.Empty), 0D)
      txtTotal.Text = decTotal.ToString("N2")
      tssRegistros.Text = String.Format("{0} Registros", dt.Rows.Count)

      cmbTodos.SelectedIndex = 0

      If _comprobantesSeleccionados.Count > 0 Then
         For Each comp In _comprobantesSeleccionados
            dt.Select(String.Format("{0} = {1} AND {2} = '{3}' AND {4} = '{5}' AND {6} = {7} AND {8} = {9}",
                                    Entidades.Venta.Columnas.IdSucursal.ToString(), comp.IdSucursal,
                                    Entidades.Venta.Columnas.IdTipoComprobante.ToString(), comp.IdTipoComprobante,
                                    Entidades.Venta.Columnas.Letra.ToString(), comp.LetraComprobante,
                                    Entidades.Venta.Columnas.CentroEmisor.ToString(), comp.CentroEmisor,
                                    Entidades.Venta.Columnas.NumeroComprobante.ToString(), comp.NumeroComprobante)).
               All(Function(dr)
                      dr.SetField("Check", True)
                      Return True
                   End Function)
         Next
      End If
      _comprobantesSeleccionados = New List(Of Entidades.Venta)()

      If ugDetalle.Rows.Count = 0 Then
         ShowMessage("No se encontraron registros.")
      End If

   End Sub

   Private Sub RecalcularTotalSeleccionado()
      Dim decTotal = ObjectExtensions.ValorNumericoPorDefecto(_dtComprobantes.Compute(String.Format("SUM({0})", Entidades.Venta.Columnas.ImporteTotal.ToString()), "Check"), 0D)
      txtSeleccionado.Text = decTotal.ToString("N2")
   End Sub

   Private Sub chbSoloCabecera_CheckedChanged(sender As Object, e As EventArgs) Handles chbSoloCabecera.CheckedChanged
      If chbSoloCabecera.Checked Then chbSoloCopiar.Checked = False
   End Sub

#End Region

End Class