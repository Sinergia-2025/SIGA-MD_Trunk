Imports System.ComponentModel

Public Class RequerimientosComprasAdminAsignarProveedores

   Private _publicos As Publicos
   Private _tipoTipoComprobante1 As Entidades.TipoComprobante.Tipos = Entidades.TipoComprobante.Tipos.PRESUPPROV
   Private _tipoTipoComprobante2 As Entidades.TipoComprobante.Tipos = Entidades.TipoComprobante.Tipos.PRESUPPROV
   Private _dtProductos As DataTable
   Private _dtAsignaciones As DataTable
   Private _rRQ As Reglas.RequerimientosCompras

   Private _titProd As Dictionary(Of String, String)
   Private _titAsig As Dictionary(Of String, String)

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      _rRQ = New Reglas.RequerimientosCompras()
   End Sub

#Region "Overrides/Overloads/Shadows"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()
         _publicos.CargaComboDesdeEnum(cmbTodos, Reglas.Publicos.TodosEnum.MararTodos)

         cmbTiposComprobantes.Initializar(permiteSinSeleccion:=False, seleccionMultiple:=False, seleccionTodos:=False,
                                          MiraPC:=True, Tipo1:=_tipoTipoComprobante1.ToString(), Tipo2:=_tipoTipoComprobante2.ToString(), UsaFacturacion:=True)
         cmbTiposComprobantes.SelectedIndexIfAny(0)
         cmbFormaDePago.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=False, seleccionTodos:=False, "COMPRAS")
         cmbFormaDePago.SelectedIndexIfAny(0)

         _publicos.CargaComboEmpleados(cmbComprador, Entidades.Publicos.TiposEmpleados.COMPRADOR)
         _publicos.CargaComboEstadoVisita(cmbEstadoVisita, admitePedidoSinLineas:=Nothing, admintePedidoConLineas:=True)

         ugProductos.DisplayLayout.Bands(0).Columns("NombreModelo").Hidden = Not Reglas.Publicos.ProductoTieneModelo
         ugProductos.DisplayLayout.Bands(0).Columns("NombreSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubRubro
         ugProductos.DisplayLayout.Bands(0).Columns("NombreSubSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubSubRubro

         _titProd = GetColumnasVisiblesGrilla(ugProductos)
         _titAsig = GetColumnasVisiblesGrilla(ugAsignaciones)

         ugProductos.DataSource = _dtProductos
         ugAsignaciones.DataSource = _dtAsignaciones

         AjustarColumnasGrilla(ugProductos, _titProd)
         AjustarColumnasGrilla(ugAsignaciones, _titAsig)

         ugAsignaciones.AgregarTotalesSuma({"CantidadAsignada", "CantidadUMCompra"})

      End Sub)
   End Sub
   Protected Overrides Sub OnClosing(e As CancelEventArgs)
      If DialogResult <> DialogResult.OK AndAlso btnAceptar.Enabled Then
         e.Cancel = ShowPregunta(String.Format("¿Está seguro de querer cancelar la asignación de Proveedores? Se perderan los cambios que haya realizado"), MessageBoxDefaultButton.Button2) = DialogResult.No
      End If
      MyBase.OnClosing(e)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
         'ElseIf keyData = Keys.Escape Then
         '   btnCancelar.PerformClick()
      ElseIf keyData = (Keys.Control Or Keys.Add) Then
         btnInsertar.Focus()
         btnInsertar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Public Shadows Function ShowDialog(owner As IWin32Window,
                                      tipoTipoComprobante1 As Entidades.TipoComprobante.Tipos,
                                      tipoTipoComprobante2 As Entidades.TipoComprobante.Tipos,
                                      dtProductos As DataTable) As DialogResult
      _tipoTipoComprobante1 = tipoTipoComprobante1
      _tipoTipoComprobante2 = tipoTipoComprobante2

      _dtProductos = dtProductos
      _dtAsignaciones = dtProductos.Clone()

      UnselecProductos()

      Return MyBase.ShowDialog(owner)
   End Function

#End Region

#Region "Eventos"
#Region "Eventos Buscador Proveedor"
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor, True)
      End Sub)
   End Sub
   Private Sub bscNombreProveedor_BuscadorClick() Handles bscNombreProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscNombreProveedor)
         bscNombreProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscNombreProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscNombreProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub

#End Region
   Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
      TryCatched(Sub() LimpiarProveedores())
   End Sub
   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(Sub() InsertarProveedores())
   End Sub
   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(Sub() EliminarProveedores())
   End Sub

   Private Sub txtCantidad_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCantidad.KeyDown, dtpFechaEntregaProd.KeyDown
      TryCatched(Sub() If TypeOf (sender) Is Control Then NavegacionConEnter(e, DirectCast(sender, Control)))
   End Sub

   Private Sub ugProductos_CellChange(sender As Object, e As CellEventArgs) Handles ugProductos.CellChange
      TryCatched(
      Sub()
         If e.Cell.Column.Key = "Selec" Then
            e.Cell.UpdateData()
            ControlaRegistrosSeleccionados()
         End If
      End Sub)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub

#Region "Marcar/Desmarcar Todos"
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(
      Sub()
         ugProductos.MarcarDesmarcar(cmbTodos, "Selec", Function(dr) True)
         ControlaRegistrosSeleccionados()
      End Sub)
   End Sub
#End Region

#End Region

#Region "Metodos"
   Private Sub ControlaRegistrosSeleccionados()
      Dim dtProductos = ugProductos.DataSource(Of DataTable)
      Dim drSelec = dtProductos.Where(Function(dr) dr.Field(Of Boolean)("Selec"))
      pnlProveedor.Enabled = drSelec.Count > 0           ' Habilito el proveedor si selecciono al menos un producto en la grilla superior
      btnInsertar.Enabled = drSelec.Count > 0            ' Habilito el botón Insertar si selecciono al menos un producto en la grilla superior
      txtCantidad.Enabled = drSelec.Count = 1            ' Habilito de cantidad si solo selecciono un producto. Si son más de uno no puedo cambiar la cantidad
      If drSelec.Count = 1 Then
         txtCantidad.SetValor(drSelec.First().Field(Of Decimal)("Cantidad"))           ' Si seleccionó solo un producto muestro su cantidad
         dtpFechaEntregaProd.Value = drSelec.First().Field(Of Date)("FechaEntrega")    ' Si seleccionó solo un producto muestro su fecha de entrega
      ElseIf drSelec.Count > 1 Then
         ' Si seleccionó más de un producto, a todos le voy a poner la misma fecha, por defecto la entrega del último
         dtpFechaEntregaProd.Value = drSelec.Max(Function(x) x.Field(Of Date?)("FechaEntrega").IfNull())
         If dtpFechaEntregaProd.Value < Date.Today Then
            dtpFechaEntregaProd.Value = Date.Today       ' Si la fecha de entrega ya pasó, le pongo TODAY
         End If
      End If
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         NavegacionConEnter(bscCodigoProveedor)
      End If
   End Sub

   Private Sub UnselecProductos()
      _dtProductos.ForEach(Sub(dr) dr("Selec") = False)
      ugProductos.Rows.Refresh(RefreshRow.ReloadData)
      cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos
      ControlaRegistrosSeleccionados()
   End Sub

   Private Sub LimpiarProveedores()
      bscCodigoProveedor.Text = String.Empty
      bscCodigoProveedor.Tag = Nothing
      bscNombreProveedor.Text = String.Empty
      txtCantidad.SetValor(0)
      dtpFechaEntregaProd.Value = Today

      'UnselecProductos()

      bscCodigoProveedor.Focus()
   End Sub
   Private Function ValidarProveedores() As Boolean
      If Not bscCodigoProveedor.Selecciono And Not bscNombreProveedor.Selecciono Then
         ShowMessage("No eligió un Proveedor o falto pulsar ENTER.")
         bscCodigoProveedor.Focus()
         Return False
      End If
      If txtCantidad.Enabled AndAlso Not txtCantidad.ReadOnly AndAlso txtCantidad.ValorNumericoPorDefecto(0D) = 0 Then
         ShowMessage("No puede ingresar sin cantidad.")
         txtCantidad.Focus()
         Return False
      End If
      If dtpFechaEntregaProd.Value < Today Then
         ShowMessage("La fecha de entrega no puede ser anterior a Hoy.")
         txtCantidad.Focus()
         Return False
      End If
      Return True
   End Function
   Private Sub InsertarProveedores()
      If ValidarProveedores() Then
         ugProductos.UpdateData()
         _dtProductos.Where(Function(dr) dr.Field(Of Boolean)("Selec")).ToList().ForEach(
            Sub(dr)
               Dim idProveedor = Long.Parse(bscCodigoProveedor.Tag.ToString())
               If _dtAsignaciones.Where(Function(drExiste) drExiste.Field(Of Long)("IdRequerimientoCompra") = dr.Field(Of Long)("IdRequerimientoCompra") AndAlso
                                                           drExiste.Field(Of String)("IdProducto") = dr.Field(Of String)("IdProducto") AndAlso
                                                           drExiste.Field(Of Integer)("Orden") = dr.Field(Of Integer)("Orden") AndAlso
                                                           drExiste.Field(Of Long)("IdProveedorAsignado") = idProveedor).Count = 0 Then
                  Dim drAsig = _dtAsignaciones.NewRow()
                  drAsig.CopiarValores(dr)
                  drAsig("IdProveedorAsignado") = idProveedor
                  drAsig("CodigoProveedorAsignado") = bscCodigoProveedor.Text.ValorNumericoPorDefecto(0L)
                  drAsig("NombreProveedorAsignado") = bscNombreProveedor.Text
                  If txtCantidad.Enabled And Not txtCantidad.ReadOnly Then
                     drAsig("CantidadAsignada") = txtCantidad.ValorNumericoPorDefecto(0D)
                  Else
                     drAsig("CantidadAsignada") = dr("Cantidad")
                  End If
                  drAsig("CantidadUMCompra") = dr.Field(Of Decimal)("FactorConversionCompra") * drAsig.Field(Of Decimal)("CantidadAsignada")
                  drAsig("FechaAsignacion") = dtpFechaEntregaProd.Value
                  drAsig("FechaEntrega_Fecha") = dtpFechaEntregaProd.Value

                  _dtAsignaciones.Rows.Add(drAsig)
                  ugAsignaciones.Rows.Refresh(RefreshRow.ReloadData)
               End If
            End Sub)
         'UnselecProductos()
         LimpiarProveedores()
         ControlaRegistrosSeleccionados()
      End If
   End Sub
   Private Sub EliminarProveedores()
      Dim drCol = ugAsignaciones.FilasSeleccionadasOActiva(Of DataRow)
      If drCol.Count > 0 Then
         Dim mensaje = If(drCol.Count = 1, "¿Desea eliminar el Producto/Proveedor seleccionado?",
                          String.Format("¿Desea eliminar los {0} Productos/Proveedores seleccionados?", drCol.Count))
         drCol.Delete().AcceptChanges()
         ugAsignaciones.Rows.Refresh(RefreshRow.ReloadData)
      End If
   End Sub

   Private Function ValidarAsignacion() As Boolean
      If cmbTiposComprobantes.SelectedIndex = -1 Then
         ShowMessage("No seleccionó Tipo de Comprobante")
         cmbTiposComprobantes.Focus()
         Return False
      End If
      If cmbFormaDePago.SelectedIndex = -1 Then
         ShowMessage("No seleccionó Forma de Pago")
         cmbFormaDePago.Focus()
         Return False
      End If
      If Not ugAsignaciones.DataSource(Of DataTable).Any() Then
         ShowMessage(String.Format("No selecciono ningún Producto para generar {0}", cmbTiposComprobantes.Text))
         ugProductos.Focus()
         Return False
      End If

      Return True
   End Function
   Private Sub Aceptar()
      If ValidarAsignacion() Then
         _rRQ.GenerarAsignaciones(ugAsignaciones.DataSource(Of DataTable),
                                  cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante),
                                  cmbFormaDePago.ItemSeleccionado(Of Entidades.VentaFormaPago),
                                  cmbComprador.ItemSeleccionado(Of Entidades.Empleado),
                                  cmbEstadoVisita.ItemSeleccionado(Of Entidades.EstadoVisita))
         Close(DialogResult.OK)
      End If
   End Sub


#Region "Navegación"
   Private Sub NavegacionConEnter(e As KeyEventArgs, controlOrigen As Control)
      If e.KeyCode = Keys.Enter Then
         NavegacionConEnter(controlOrigen)
      End If
   End Sub
   Private Sub NavegacionConEnter(controlOrigen As Control)
      If controlOrigen.Equals(bscCodigoProveedor) Then
         Navegar(txtCantidad)
      ElseIf controlOrigen.Equals(txtCantidad) Then
         Navegar(dtpFechaEntregaProd)
      ElseIf controlOrigen.Equals(dtpFechaEntregaProd) Then
         Navegar(btnInsertar)
      End If
   End Sub
   Private Sub Navegar(controlDestino As Control)
      If controlDestino.Enabled Then
         controlDestino.Focus()
      Else
         NavegacionConEnter(controlDestino)
      End If
   End Sub

#End Region

#End Region

End Class