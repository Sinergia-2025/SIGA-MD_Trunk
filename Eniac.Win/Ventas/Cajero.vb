Imports System.ComponentModel

Public Class Cajero
   Inherits BaseForm
   Implements IConParametros

#Region "Constantes"

   Private Const _columnaSeleccionMultiple As String = "Selec"

#End Region

#Region "Campos"

   Private _initializing As Boolean = True
   Private _titVentas As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _titVentasProductos As Dictionary(Of String, String) = New Dictionary(Of String, String)()
   Private _cajeroGenera As Entidades.VentaCajero.CajeroGenera
   Private _cajeroSeleccionMultiple As Boolean

   Private _reglasVentas As Reglas.Ventas
   Private _reglasVentasCajeros As Reglas.VentasCajeros

   Private _entiVenta As Entidades.Venta

   Private _dtVentasCajeros As DataTable

   Private _drCobro As DataRow

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _titVentas = GetColumnasVisiblesGrilla(ugVentas)

            If _modo = ModoCajero.MODIFICAR Then
               Text += " Modificar Comprobante"
               tsbCobrar.Text = "Modificar (F4)"
               tsbCobrar.Image = My.Resources.document_edit
            End If

            _titVentasProductos = GetColumnasVisiblesGrilla(ugVentasProductos)

            _reglasVentas = New Reglas.Ventas()
            _reglasVentasCajeros = New Reglas.VentasCajeros()

            chbActualizacionAutomatica.Checked = Reglas.Publicos.CajeroPermiteActualizacionAutomatica
            txtSegundos.Value = Math.Max(1, Reglas.Publicos.CajeroTiempoDeActualizacionAutomatica)

            Timer1.Interval = Decimal.ToInt32(txtSegundos.Value) * 1000

            If chbActualizacionAutomatica.Checked Then
               Timer1.Start()
            End If

            _cajeroGenera = Reglas.Publicos.CajeroGenera.StringToEnum(Entidades.VentaCajero.CajeroGenera.Ventas)
            _cajeroSeleccionMultiple = Reglas.Publicos.CajeroSeleccionMultiple

            If _cajeroSeleccionMultiple Then
               ugVentas.InicializaTotales()
               ugVentas.DisplayLayout.Bands(0).SummaryFooterCaption = "Importe total de comprobantes seleccionados:"
            End If

            'Hay que colocarlo del CargarColumnasASumar porque sino da error.
            PreferenciasLeer(ugVentas, tsbPreferencias)

         End Sub)

      _initializing = False

      TryCatched(Sub() Actualizar())

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         Actualizar()
      ElseIf keyData = Keys.F4 Then
         If tsbCobrar.Visible And tsbCobrar.Visible Then
            Cobrar()
         End If
         If tsbVisto.Visible And tsbVisto.Visible Then
            MarcarVistoComprobante()
         End If
      ElseIf keyData = Keys.F8 Then
         CobrarEfectivo()
      ElseIf keyData = Keys.Delete Then
         AnularComprobante()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Metodos"

   Private Sub Actualizar()
      Try
         Cursor = Cursors.WaitCursor

         _dtVentasCajeros = _reglasVentasCajeros.GetAll()

         _dtVentasCajeros.Columns.Add(_columnaSeleccionMultiple, GetType(Boolean))
         For Each dr As DataRow In _dtVentasCajeros.Rows
            dr(_columnaSeleccionMultiple) = False
         Next

         ugVentas.DataSource = _dtVentasCajeros
         AjustarColumnasGrilla(ugVentas, _titVentas)

         PreferenciasLeer(ugVentas, tsbPreferencias)

         ugVentas.DisplayLayout.Bands(0).Columns(_columnaSeleccionMultiple).Hidden = Not _cajeroSeleccionMultiple

         If _cajeroSeleccionMultiple Then
            ugVentas.QuitarTotalSumaColumna(Entidades.VentaCajero.Columnas.ImporteTotal.ToString())
            ugVentas.AgregarTotalCustomColumna(Entidades.VentaCajero.Columnas.ImporteTotal.ToString(),
                                               New CustomSummaries.SummaryTotalSeleccionado(_dtVentasCajeros, Entidades.VentaCajero.Columnas.ImporteTotal.ToString(), _columnaSeleccionMultiple))
         End If

         ugVentasProductos.ClearFilas()

         tssRegistros.Text = _dtVentasCajeros.Rows.Count.ToString() & " Registros"
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   'Private Sub AjustarColumnasGrillaVentas()
   '   'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
   '   'tit("NOMBRECOLUMNA") = "NUEVO HEADER"

   '   For Each col As UltraGridColumn In ugVentas.DisplayLayout.Bands(0).Columns
   '      col.Hidden = Not _titVentas.ContainsKey(col.Key)
   '      If _titVentas.ContainsKey(col.Key) Then
   '         If Not String.IsNullOrWhiteSpace(_titVentas(col.Key)) Then
   '            col.Header.Caption = _titVentas(col.Key)
   '         End If
   '      End If
   '   Next
   'End Sub

   'Private Sub AjustarColumnasGrillaVentasProductos()
   '   'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
   '   'tit("NOMBRECOLUMNA") = "NUEVO HEADER"

   '   For Each col As UltraGridColumn In ugVentasProductos.DisplayLayout.Bands(0).Columns
   '      col.Hidden = Not _titVentasProductos.ContainsKey(col.Key)
   '      If _titVentasProductos.ContainsKey(col.Key) Then
   '         If Not String.IsNullOrWhiteSpace(_titVentasProductos(col.Key)) Then
   '            col.Header.Caption = _titVentasProductos(col.Key)
   '         End If
   '      End If
   '   Next
   'End Sub

   'Protected Overridable Sub LeerPreferencias()
   '   Try
   '      Dim nameGrid As String = Me.ugVentas.FindForm().Name & "Grid.xml"

   '      If System.IO.File.Exists(nameGrid) Then
   '         Me.ugVentas.DisplayLayout.LoadFromXml(nameGrid)
   '      End If

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Private Sub CobrarEfectivo()
      Dim timerEnabled As Boolean = Timer1.Enabled
      Try
         If tsbCobrarEfectivo.Enabled AndAlso tsbCobrarEfectivo.Visible Then
            Cursor = Cursors.WaitCursor
            Timer1.Stop()

            Dim dr = ugVentas.FilaSeleccionada(Of DataRow)()
            If dr IsNot Nothing Then
               Using frm = New CajeroCobroRapido()
                  frm.IdFuncion = IdFuncion
                  Dim rVentas = New Reglas.VentasCajeros()
                  Dim oVenta = rVentas.GetUno(dr.Field(Of Integer)(Entidades.VentaCajero.Columnas.IdSucursal.ToString()),
                                              dr.Field(Of String)(Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString()),
                                              dr.Field(Of String)(Entidades.VentaCajero.Columnas.Letra.ToString()),
                                              dr.Field(Of Integer)(Entidades.VentaCajero.Columnas.CentroEmisor.ToString()).ToShort(),
                                              dr.Field(Of Long)(Entidades.VentaCajero.Columnas.NumeroComprobante.ToString()))
                  frm.VentaCajero = oVenta
                  frm.ShowInTaskbar = False
                  'frm.StateForm = StateForm.Actualizar
                  If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                     Actualizar()
                  End If
               End Using
            End If
         End If
      Finally
         Cursor = Cursors.Default
         Timer1.Enabled = timerEnabled
      End Try
   End Sub

   Private Sub Cobrar()
      Dim timerEnabled As Boolean = Timer1.Enabled
      Try
         Cursor = Cursors.WaitCursor
         Timer1.Stop()

         'Al generar ventas se habre la pantalla de FacturacionV2 con el nuevo comprobante a grabar invocando la pre-venta
         If _cajeroGenera = Eniac.Entidades.VentaCajero.CajeroGenera.Ventas Then
            _drCobro = ugVentas.FilaSeleccionada(Of DataRow)()
            If _drCobro IsNot Nothing Then

               _entiVenta = _reglasVentas.GetUna(_drCobro.Field(Of Integer)(Entidades.VentaCajero.Columnas.IdSucursal.ToString()),
                                                 _drCobro.Field(Of String)(Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString()),
                                                 _drCobro.Field(Of String)(Entidades.VentaCajero.Columnas.Letra.ToString()),
                                                 _drCobro.Field(Of Integer)(Entidades.VentaCajero.Columnas.CentroEmisor.ToString()).ToShort(),
                                                 _drCobro.Field(Of Long)(Entidades.VentaCajero.Columnas.NumeroComprobante.ToString()))

               If Reglas.Publicos.CajeroAbrirVariasVentanasDeFactuacion Then
                  Dim frm = New FacturacionV2()
                  frm.SetCacheCalculosDescuentosRecargos(CalculosDescuentosRecargos1.Cache)
                  frm.IdFuncion = IdFuncion
                  frm.InvocarDesdeCajero(_entiVenta, _idTipoComprobanteGenerar)
                  frm.ShowInTaskbar = False
                  frm.MdiParent = ActiveForm
                  frm.Show()
               Else
                  Using frm = New FacturacionV2()
                     frm.SetCacheCalculosDescuentosRecargos(CalculosDescuentosRecargos1.Cache)
                     frm.IdFuncion = IdFuncion
                     frm.InvocarDesdeCajero(_entiVenta, _idTipoComprobanteGenerar)
                     frm.ShowInTaskbar = False
                     'frm.StateForm = StateForm.Actualizar
                     If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Actualizar()
                     End If
                  End Using
               End If
            End If
         ElseIf _cajeroGenera = Eniac.Entidades.VentaCajero.CajeroGenera.Recibos Then
            If TypeOf (ugVentas.DataSource) Is DataTable Then
               ugVentas.UpdateData()

               ValidaSeleccionMultiple()

               Dim drCol = DirectCast(ugVentas.DataSource, DataTable).Select(String.Format("{0} = {1}", _columnaSeleccionMultiple, True))
               If drCol.Length = 0 Then
                  Dim dr As DataRow = ugVentas.FilaSeleccionada(Of DataRow)()
                  If dr Is Nothing Then
                     Throw New Exception("Debe seleccionar al menos un comprobante.")
                  End If
                  drCol = {dr}
               End If

               Dim invocadosCajero As List(Of Entidades.Venta) = New List(Of Entidades.Venta)()

               For Each dr In drCol
                  _entiVenta = _reglasVentas.GetUna(dr.Field(Of Integer)(Entidades.VentaCajero.Columnas.IdSucursal.ToString()),
                                                    dr.Field(Of String)(Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString()),
                                                    dr.Field(Of String)(Entidades.VentaCajero.Columnas.Letra.ToString()),
                                                    dr.Field(Of Integer)(Entidades.VentaCajero.Columnas.CentroEmisor.ToString()).ToShort(),
                                                    dr.Field(Of Long)(Entidades.VentaCajero.Columnas.NumeroComprobante.ToString()))
                  invocadosCajero.Add(_entiVenta)
               Next
               If Reglas.Publicos.CajeroAbrirVariasVentanasDeFactuacion Then
                  Dim frm = New Recibos()
                  frm.IdFuncion = IdFuncion
                  frm.InvocarDesdeCajero(invocadosCajero)
                  frm.ShowInTaskbar = False
                  frm.MdiParent = ActiveForm
                  frm.Show()
               Else
                  Using frm = New Recibos()
                     frm.IdFuncion = IdFuncion
                     frm.InvocarDesdeCajero(invocadosCajero)
                     frm.ShowInTaskbar = False
                     'frm.StateForm = StateForm.Actualizar
                     If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        Actualizar()
                     End If
                  End Using
               End If
            End If
         End If
      Finally
         Cursor = Cursors.Default
         Timer1.Enabled = timerEnabled
      End Try
   End Sub

   Private Sub ValidaSeleccionMultiple()
      Dim drColContado = DirectCast(ugVentas.DataSource, DataTable).Select(String.Format("{0} = {1} AND AfectaCaja = 0", _columnaSeleccionMultiple, True))
      Dim drColCtaCte = DirectCast(ugVentas.DataSource, DataTable).Select(String.Format("{0} = {1} AND AfectaCaja = 1", _columnaSeleccionMultiple, True))
      If drColContado.Count > 0 And drColCtaCte.Count > 0 Then
         Throw New Exception("No es posible seleccionar comprobantes que SI Afectan Caja y NO Afectan Caja al mismo tiempo.")
      End If
   End Sub

   Private Sub AnularComprobante()
      AnularComprobante(ugVentas.ActiveRow, Acciones.Anular)
   End Sub
   Private Sub MarcarVistoComprobante()
      ValidaSeleccionMultiple()
      QuitarComprobanteCajero(ugVentas.ActiveRow, Acciones.MarcarComoVisto)
   End Sub

   Private Enum Acciones
      Anular
      <Description("Marcar como Visto")> MarcarComoVisto
   End Enum

   Private Sub QuitarComprobanteCajero(ugr As UltraGridRow, accion As Acciones)
      Try
         Dim dr = ugVentas.FilaSeleccionada(Of DataRow)(ugr)
         If dr IsNot Nothing Then
            If ShowPregunta(String.Format("¿Desea {4} el {0} {1} seleccionado para el Cliente {2} ({3})?",
                                          dr(Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString()),
                                          dr(Entidades.VentaCajero.Columnas.NumeroComprobante.ToString()),
                                          dr(Entidades.VentaCajero.Columnas.NombreCliente.ToString()).ToString().Trim(),
                                          dr(Entidades.VentaCajero.Columnas.CodigoCliente.ToString()),
                                          Publicos.GetEnumString(accion))) = Windows.Forms.DialogResult.Yes Then
               Cursor = Cursors.WaitCursor
               Dim rCajero As Reglas.VentasCajeros = New Reglas.VentasCajeros()
               rCajero.Borrar(dr.ValorNumericoPorDefecto(Entidades.VentaCajero.Columnas.IdSucursal.ToString(), 0I),
                              dr(Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString()).ToString(),
                              dr(Entidades.VentaCajero.Columnas.Letra.ToString()).ToString(),
                              dr.ValorNumericoPorDefecto(Entidades.VentaCajero.Columnas.CentroEmisor.ToString(), 0S),
                              dr.ValorNumericoPorDefecto(Entidades.VentaCajero.Columnas.NumeroComprobante.ToString(), 0L))
               Actualizar()
            End If
         End If
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub AnularComprobante(ugr As UltraGridRow, accion As Acciones)
      Try
         Dim dr As DataRow = ugVentas.FilaSeleccionada(Of DataRow)(ugr)
         If dr IsNot Nothing Then

            If accion = Acciones.Anular Then
               If dr.Field(Of Boolean)(Entidades.TipoComprobante.Columnas.EsFiscal.ToString()) Then
                  Throw New Exception(String.Format("Eliminar comprobante {1} {2} no se puede {0} porque es Fiscal.",
                                                    Publicos.GetEnumString(accion),
                                                    dr(Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString()),
                                                    dr(Entidades.VentaCajero.Columnas.NumeroComprobante.ToString())))
               End If
               If dr.Field(Of Boolean)(Entidades.TipoComprobante.Columnas.EsElectronico.ToString()) And
                  Not dr.Field(Of Boolean)(Entidades.TipoComprobante.Columnas.EsPreElectronico.ToString()) Then
                  Throw New Exception(String.Format("Eliminar comprobante {1} {2} no se puede {0} porque es Electrónico.",
                                                    Publicos.GetEnumString(accion),
                                                    dr(Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString()),
                                                    dr(Entidades.VentaCajero.Columnas.NumeroComprobante.ToString())))
               End If
            End If

            If ShowPregunta(String.Format("¿Desea {4} el {0} {1} seleccionado para el Cliente {2} ({3})?",
                                          dr(Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString()),
                                          dr(Entidades.VentaCajero.Columnas.NumeroComprobante.ToString()),
                                          dr(Entidades.VentaCajero.Columnas.NombreCliente.ToString()).ToString().Trim(),
                                          dr(Entidades.VentaCajero.Columnas.CodigoCliente.ToString()),
                                          accion)) = Windows.Forms.DialogResult.Yes Then
               Cursor = Cursors.WaitCursor
               Dim rVentas = New Reglas.Ventas()
               rVentas.AnularComprobante(dr.Field(Of Integer)(Entidades.VentaCajero.Columnas.IdSucursal.ToString()),
                                         dr.Field(Of String)(Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString()),
                                         dr.Field(Of String)(Entidades.VentaCajero.Columnas.Letra.ToString()),
                                         dr.Field(Of Integer)(Entidades.VentaCajero.Columnas.CentroEmisor.ToString()).ToShort(),
                                         dr.Field(Of Long)(Entidades.VentaCajero.Columnas.NumeroComprobante.ToString()),
                                         Entidades.Entidad.MetodoGrabacion.Manual, IdFuncion)
               Actualizar()
            End If
         End If
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Eventos"

   Private Sub Cajero_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
      Try
         Enabled = False
         CalculosDescuentosRecargos1.Inicializar()
      Finally
         lblEstado.Text = String.Empty
         Enabled = True
      End Try
   End Sub

   Private Sub chbActualizacionAutomatica_CheckedChanged(sender As Object, e As EventArgs) Handles chbActualizacionAutomatica.CheckedChanged
      TryCatched(
         Sub()
            If _initializing Then Return
            If chbActualizacionAutomatica.Checked Then
               Timer1.Start()
            Else
               Timer1.Stop()
            End If
         End Sub)
   End Sub

   Private Sub txtSegundos_ValueChanged(sender As Object, e As EventArgs) Handles txtSegundos.ValueChanged
      TryCatched(
         Sub()
            If _initializing Then Return
            Timer1.Stop()
            Timer1.Interval = Decimal.ToInt32(txtSegundos.Value) * 1000
            If chbActualizacionAutomatica.Checked Then
               Timer1.Start()
            End If
         End Sub)
   End Sub

   Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
      TryCatched(Sub() Actualizar())
   End Sub

   Private Sub ugDetalle_CellChange(sender As Object, e As CellEventArgs) Handles ugVentas.CellChange
      TryCatched(
         Sub()
            If e.Cell.Row.ListObject IsNot Nothing AndAlso e.Cell.Column.Key = _columnaSeleccionMultiple Then
               ugVentas.UpdateData()
               Timer1.Stop()
               Timer1.Start()
            End If
         End Sub)
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() Actualizar())
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugVentas, tsbPreferencias))
   End Sub

   Private Sub ugVentas_AfterRowActivate(sender As Object, e As EventArgs) Handles ugVentas.AfterRowActivate
      TryCatched(
         Sub()
            Dim dr = ugVentas.FilaSeleccionada(Of DataRow)()
            If dr IsNot Nothing Then

               Dim afectaCaja = dr.Field(Of Boolean)("AfectaCaja")
               Dim rVentasProductos = New Reglas.VentasProductos()

               Dim dt = rVentasProductos.GetDetalleCompletoPorComprobante(
                                             dr.Field(Of Integer)(Entidades.VentaCajero.Columnas.IdSucursal.ToString()),
                                             dr.Field(Of String)(Entidades.VentaCajero.Columnas.IdTipoComprobante.ToString()),
                                             dr.Field(Of String)(Entidades.VentaCajero.Columnas.Letra.ToString()),
                                             dr.Field(Of Integer)(Entidades.VentaCajero.Columnas.CentroEmisor.ToString()).ToShort(),
                                             dr.Field(Of Long)(Entidades.VentaCajero.Columnas.NumeroComprobante.ToString()))
               ugVentasProductos.DataSource = dt
               AjustarColumnasGrilla(ugVentasProductos, _titVentasProductos)

               If _cajeroGenera = Entidades.VentaCajero.CajeroGenera.Ventas Then
                  tsbCobrar.Visible = Not afectaCaja
                  tsbVisto.Visible = afectaCaja
               Else
                  tsbCobrar.Visible = True
                  tsbVisto.Visible = False
               End If
            End If
         End Sub)
   End Sub

   Private Sub tsbAnular_Click(sender As Object, e As EventArgs) Handles tsbAnular.Click
      TryCatched(Sub() AnularComprobante())
   End Sub

   Private Sub tsbCobrar_Click(sender As Object, e As EventArgs) Handles tsbCobrar.Click
      TryCatched(Sub() Cobrar())
   End Sub

   Private Sub ugVentas_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugVentas.DoubleClickRow
      TryCatched(
         Sub()
            If Not _cajeroSeleccionMultiple Then
               If tsbCobrar.Visible And tsbCobrar.Visible Then
                  Cobrar()
               End If
               If tsbVisto.Visible And tsbVisto.Visible Then
                  MarcarVistoComprobante()
               End If
            End If
         End Sub)
   End Sub

   Private Sub tsbCobrarEfectivo_Click(sender As Object, e As EventArgs) Handles tsbCobrarEfectivo.Click
      TryCatched(Sub() CobrarEfectivo())
   End Sub
   Private Sub tsbVisto_Click(sender As Object, e As EventArgs) Handles tsbVisto.Click
      TryCatched(Sub() MarcarVistoComprobante())
   End Sub

   Private Sub CalculosDescuentosRecargos1_ReporteEstado(sender As Object, e As CalculosDescuentosRecargosReporteEstadoEventArgs) Handles CalculosDescuentosRecargos1.ReporteEstado
      Try
         lblEstado.Text = e.Estado
         Application.DoEvents()
      Catch ex As Exception
      End Try
   End Sub

#Region "Metodos IConParametros"
   Private _idTipoComprobanteGenerar As String = String.Empty
   Private _modo As ModoCajero
   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      Dim _parametros = New ParametrosFuncion()
      ConParametrosAyudante.Parse(parametros, GetType(ParametrosPermitidos), _parametros)
      _idTipoComprobanteGenerar = _parametros.GetValor(Of String)(ParametrosPermitidos.IdTipoComprobanteGenerar)
      _modo = _parametros.GetValor(Of String)(ParametrosPermitidos.Modo).StringToEnum(ModoCajero.COBRAR)
   End Sub

   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return ConParametrosAyudante.ParametrosDisponiblesAyuda(GetType(ParametrosPermitidos))
   End Function
   Public Enum ParametrosPermitidos
      <DefaultValue("COBRAR"), Description("Modo de trabajo de la pantalla COBRAR/MODIFICAR")> Modo
      <DefaultValue(""), Description("Id del Tipo de Comprobante a generar")> IdTipoComprobanteGenerar
   End Enum
   Public Enum ModoCajero
      COBRAR
      MODIFICAR
   End Enum
#End Region

#End Region

End Class