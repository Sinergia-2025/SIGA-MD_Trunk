Public Class DividirPedidoV2
#Region "Campos"

   Private _publicos As Publicos
   Private _detalles As List(Of Reglas.Pedidos.DetallesDividir)

#End Region

#Region "Propiedades"
   Private Property Pedido As Entidades.Pedido
   Public Property PedidosGenerados As List(Of Entidades.Pedido)
#End Region


   Private Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub

   Public Sub New(pedido As Entidades.Pedido)
      Me.New()
      _Pedido = pedido
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboTiposComprobantes(Me.cmbTipoComprNuevo, False, "VENTAS")
         cmbTipoComprNuevo.SelectedIndex = -1
         _publicos.CargaComboSucursales(Me.cmbSucursalNueva)
         If cmbSucursalNueva.Items.Count > 1 Then
            cmbSucursalNueva.SelectedIndex = -1
         Else
            cmbSucursalNueva.SelectedIndex = 0
         End If

         txtIdTipoComprobante.Text = Pedido.TipoComprobante.IdTipoComprobante.ToString()
         txtLetra.Text = Pedido.LetraComprobante.ToString()
         txtCentroEmisor.Text = Pedido.CentroEmisor.ToString()
         txtNumeroComprobante.Text = Pedido.NumeroPedido.ToString()
         If Pedido.TipoComprobanteFact IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Pedido.TipoComprobanteFact.Descripcion) Then
            txtcompActual.Text = Pedido.TipoComprobanteFact.Descripcion
         Else
            txtcompActual.Text = New Eniac.Reglas.TiposComprobantes().GetUno(Pedido.Cliente.IdTipoComprobante).Descripcion
         End If

         txtIdSucursal.Text = Pedido.IdSucursal.ToString()
         Dim sucur = New Reglas.Sucursales().GetUna(Pedido.IdSucursal, False)
         If sucur IsNot Nothing Then
            txtNombreSucursal.Text = sucur.Nombre
         Else
            txtNombreSucursal.Text = String.Empty
         End If

         _detalles = GetDetalleCollection(Pedido.PedidosProductos)
         ugDetalle.DataSource = _detalles

         FormatearGrilla(ugDetalle)
      End Sub)

   End Sub

   Private Sub FormatearGrilla(grilla As UltraGrid)
      With grilla.DisplayLayout.Bands(0)
         For Each columna As UltraGridColumn In .Columns
            columna.CellActivation = Activation.NoEdit
            columna.Hidden = True
         Next

         grilla.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Center

         Dim group1 As UltraGridGroup
         Dim group2 As UltraGridGroup
         Dim group3 As UltraGridGroup

         If .Groups.Count = 0 Then
            group1 = New UltraGridGroup("", 1)
            group2 = New UltraGridGroup("Original", 2)
            group3 = New UltraGridGroup("Nuevo", 3)

            .Groups.Add(group1)
            .Groups.Add(group2)
            .Groups.Add(group3)
         Else
            group1 = DirectCast(.Groups.GetItem(0), UltraGridGroup)
            group2 = DirectCast(.Groups.GetItem(1), UltraGridGroup)
            group3 = DirectCast(.Groups.GetItem(2), UltraGridGroup)
         End If

         Dim pos = 0I
         .Columns(Reglas.Pedidos.DetallesDividir.Columnas.IdProducto.ToString()).FormatearColumna("Código", pos, 80).MaxWidth = 80
         group1.Columns.Add(.Columns(Reglas.Pedidos.DetallesDividir.Columnas.IdProducto.ToString()))

         .Columns(Reglas.Pedidos.DetallesDividir.Columnas.NombreProducto.ToString()).FormatearColumna("Producto", pos, 200)
         group1.Columns.Add(.Columns(Reglas.Pedidos.DetallesDividir.Columnas.NombreProducto.ToString()))

         .Columns(Reglas.Pedidos.DetallesDividir.Columnas.CantidadOriginal.ToString()).FormatearColumna("Cantidad", pos, 80, HAlign.Right, , "N4", "{double:-9.4}").MaxWidth = 80
         group1.Columns.Add(.Columns(Reglas.Pedidos.DetallesDividir.Columnas.CantidadOriginal.ToString()))

         .Columns(Reglas.Pedidos.DetallesDividir.Columnas.PrecioNeto.ToString()).FormatearColumna("Precio", pos, 80, HAlign.Right, , "N2", "{double:-9.2}").MaxWidth = 80
         group1.Columns.Add(.Columns(Reglas.Pedidos.DetallesDividir.Columnas.PrecioNeto.ToString()))

         .Columns(Reglas.Pedidos.DetallesDividir.Columnas.ImporteTotalOriginal.ToString()).FormatearColumna("Importe Total", pos, 80, HAlign.Right,, "N2", "{double:-9.2}").MaxWidth = 80
         group1.Columns.Add(.Columns(Reglas.Pedidos.DetallesDividir.Columnas.ImporteTotalOriginal.ToString()))

         Dim col = .Columns(Reglas.Pedidos.DetallesDividir.Columnas.CantidadOrigen.ToString()).FormatearColumna("Cantidad", pos, 80, HAlign.Right, , "N" + txtDecimales.Text, Formatos.MaskInput.CustomMaskInput(9, txtDecimales.ValorNumericoPorDefecto(0I)), Activation.AllowEdit)
         col.MaxWidth = 80
         col.Color(Color.Black, Color.Aqua)
         group2.Columns.Add(.Columns(Reglas.Pedidos.DetallesDividir.Columnas.CantidadOrigen.ToString()))

         .Columns(Reglas.Pedidos.DetallesDividir.Columnas.ImporteTotalOrigen.ToString()).FormatearColumna("Importe Total", pos, 80, HAlign.Right, , "N2", "{double:-9.2}").MaxWidth = 80
         group2.Columns.Add(.Columns(Reglas.Pedidos.DetallesDividir.Columnas.ImporteTotalOrigen.ToString()))

         col = .Columns(Reglas.Pedidos.DetallesDividir.Columnas.CantidadDestino.ToString()).FormatearColumna("Cantidad", pos, 80, HAlign.Right, , "N" + txtDecimales.Text, Formatos.MaskInput.CustomMaskInput(9, txtDecimales.ValorNumericoPorDefecto(0I)), Activation.AllowEdit)
         col.MaxWidth = 80
         col.Color(Color.Black, Color.Aqua)
         group3.Columns.Add(.Columns(Reglas.Pedidos.DetallesDividir.Columnas.CantidadDestino.ToString()))

         .Columns(Reglas.Pedidos.DetallesDividir.Columnas.ImporteTotalDestino.ToString()).FormatearColumna("Importe Total", pos, 80, HAlign.Right, , "N2", "{double:-9.2}").MaxWidth = 80
         group3.Columns.Add(.Columns(Reglas.Pedidos.DetallesDividir.Columnas.ImporteTotalDestino.ToString()))


         ugDetalle.AgregarTotalesSuma({Reglas.Pedidos.DetallesDividir.Columnas.ImporteTotalOriginal.ToString(),
                                       Reglas.Pedidos.DetallesDividir.Columnas.ImporteTotalOrigen.ToString(),
                                       Reglas.Pedidos.DetallesDividir.Columnas.ImporteTotalDestino.ToString()})
      End With
      ugDetalle.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
      ugDetalle.DisplayLayout.Override.SummaryValueAppearance.BackColor = Color.Yellow

      ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

      ugDetalle.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
      ugDetalle.DisplayLayout.PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand)
   End Sub

   Private Function GetDetalleCollection(productos As List(Of Eniac.Entidades.PedidoProducto)) As List(Of Reglas.Pedidos.DetallesDividir)
      Dim rPedidos = New Reglas.Pedidos()
      Return rPedidos.GetDetalleDividir(productos)
   End Function

   Private Sub txtDecimales_TextChanged(sender As Object, e As EventArgs) Handles txtDecimales.TextChanged
      TryCatched(
      Sub()
      If _detalles Is Nothing Then Exit Sub
         For Each detalle In _detalles
         'detalle.CantidadOrigen = CDec(Math.Ceiling(detalle.Cantidad * CDec(txtPorcOrigen.Text) / 100 * Math.Pow(10, CDec(txtDecimales.Text) + 1)) / Math.Pow(10, CDec(txtDecimales.Text) + 1))
         Dim decs As Integer = 0
         If IsNumeric(txtDecimales.Text) Then
            decs = CInt(txtDecimales.Text)
         End If
         detalle.CantidadOrigen = CDec(Math.Round(detalle.CantidadOrigen, decs, MidpointRounding.AwayFromZero))
      Next

      With ugDetalle.DisplayLayout.Bands(0)
            If .Columns.IndexOf(Reglas.Pedidos.DetallesDividir.Columnas.CantidadOrigen.ToString()) >= 0 Then
               .Columns(Reglas.Pedidos.DetallesDividir.Columnas.CantidadOrigen.ToString()).Format = "N" + txtDecimales.Text
               .Columns(Reglas.Pedidos.DetallesDividir.Columnas.CantidadOrigen.ToString()).MaskInput = "{double:-9." + txtDecimales.Text + "}"
         End If
            If .Columns.IndexOf(Reglas.Pedidos.DetallesDividir.Columnas.CantidadDestino.ToString()) >= 0 Then
               .Columns(Reglas.Pedidos.DetallesDividir.Columnas.CantidadDestino.ToString()).Format = "N" + txtDecimales.Text
               .Columns(Reglas.Pedidos.DetallesDividir.Columnas.CantidadDestino.ToString()).MaskInput = "{double:-9." + txtDecimales.Text + "}"
         End If
      End With

      ugDetalle.Refresh()
      End Sub)
   End Sub

   Private Sub btnDividir_Click(sender As Object, e As EventArgs) Handles btnDividir.Click
      TryCatched(
      Sub()
         For Each detalle In _detalles
         detalle.CantidadOrigen = CDec(Math.Round(detalle.CantidadOriginal * CDec(txtPorcOrigen.Text) / 100, CInt(txtDecimales.Text), MidpointRounding.AwayFromZero))
      Next
      ugDetalle.Refresh()

         For Each summary In ugDetalle.DisplayLayout.Bands(0).Summaries.OfType(Of SummarySettings)
         summary.Refresh()
      Next
      End Sub)
   End Sub

   Private Sub txtPorcOrigen_Leave(sender As Object, e As EventArgs) Handles txtPorcOrigen.Leave
      TryCatched(Sub() txtPorcDestino.SetValor(100 - txtPorcOrigen.ValorNumericoPorDefecto(0D)))
   End Sub

   Private Sub txtPorcDestino_Leave(sender As Object, e As EventArgs) Handles txtPorcDestino.Leave
      TryCatched(Sub() txtPorcOrigen.SetValor(100 - txtPorcDestino.ValorNumericoPorDefecto(0D)))
   End Sub

   Private Sub tsbCerrar_Click(sender As Object, e As EventArgs) Handles tsbCerrar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      TryCatched(
      Sub()
         If cmbTipoComprNuevo.SelectedValue Is Nothing Then
            cmbTipoComprNuevo.Focus()
            Throw New Exception("Debe seleccionar el tipo de comprobante a generar para el nuevo pedido.")
         End If
         If cmbSucursalNueva.SelectedValue Is Nothing Then
            cmbSucursalNueva.Focus()
            Throw New Exception("Debe seleccionar la sucursal para el nuevo pedido.")
         End If

         Guardar()
         Close(DialogResult.OK)
      End Sub)
   End Sub

   Private Sub Guardar()
      Dim rPedidos = New Reglas.Pedidos()
      PedidosGenerados = rPedidos.DividirPedido(_detalles, cmbTipoComprNuevo.ValorSeleccionado(String.Empty), Pedido)
   End Sub

End Class