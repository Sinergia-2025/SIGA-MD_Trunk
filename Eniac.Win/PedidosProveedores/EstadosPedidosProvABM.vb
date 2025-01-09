Public Class EstadosPedidosProvABM
   Implements IConParametros

   Private _tipoTipoComprobante As String
   Private _tipoTipoComprobanteParaCombo As String
   Private _tipoTipoComprobanteParaCombo2 As String
   Private _parametros As String

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSPROV"
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      FormatearGrilla()
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      Dim frm As EstadosPedidosProvDetalle
      If estado = StateForm.Actualizar Then
         frm = New EstadosPedidosProvDetalle(DirectCast(GetEntidad(), Entidades.EstadoPedidoProveedor))
      Else
         frm = New EstadosPedidosProvDetalle(New Entidades.EstadoPedidoProveedor(_tipoTipoComprobante))
      End If
      frm.IdFuncion = IdFuncion
      frm.SetParametros(_parametros)
      Return frm
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.EstadosPedidosProveedores()
   End Function

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Return DirectCast(rg, Reglas.EstadosPedidosProveedores).GetAll(_tipoTipoComprobante)
   End Function
   Protected Overrides Function Buscar(rg As Reglas.Base, args As Entidades.Buscar) As DataTable
      Return DirectCast(rg, Reglas.EstadosPedidosProveedores).Buscar(args, _tipoTipoComprobante)
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim estado As Entidades.EstadoPedidoProveedor
      Dim rEstados = New Reglas.EstadosPedidosProveedores()

      With dgvDatos.ActiveRow
         estado = rEstados.GetUno(.Cells(Entidades.EstadoPedidoProveedor.Columnas.IdEstado.ToString()).Value.ToString(), _tipoTipoComprobante)
      End With

      Return estado
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I

         .Columns(Entidades.EstadoPedidoProveedor.Columnas.IdEstado.ToString()).FormatearColumna("Estado", pos, 100)
         .Columns(Entidades.EstadoPedidoProveedor.Columnas.idTipoComprobante.ToString()).FormatearColumna("Comprobante", pos, 100)
         .Columns(Entidades.EstadoPedidoProveedor.Columnas.IdTipoEstado.ToString()).FormatearColumna("Tipo Estado", pos, 100)
         .Columns(Entidades.EstadoPedidoProveedor.Columnas.Orden.ToString()).FormatearColumna("Orden", pos, 60)

         .Columns(Entidades.EstadoPedidoProveedor.Columnas.TipoEstadoPedido.ToString()).OcultoPosicion(hidden:=True, pos)

         .Columns(Entidades.EstadoPedidoProveedor.Columnas.Color.ToString()).FormatearColumna("Color", pos, 80, HAlign.Right)

         .Columns(Entidades.EstadoPedidoProveedor.Columnas.IdEstadoFacturado.ToString()).FormatearColumna("Estado Pedido Facturado", pos, 100)

         .Columns(Entidades.EstadoPedidoProveedor.Columnas.TipoEstadoPedidoCliente.ToString()).FormatearColumna("Tp. Est. Clte.", pos, 100, , True)
         .Columns(Entidades.EstadoPedidoProveedor.Columnas.IdEstadoPedidoCliente.ToString()).FormatearColumna("Estado Ped. Clte.", pos, 100)

         .Columns(Entidades.EstadoPedidoProveedor.Columnas.IdTipoMovimiento.ToString()).FormatearColumna("Tipo Movimiento", pos, 100)
         .Columns(Entidades.EstadoPedidoProveedor.Columnas.StockAfectado.ToString()).FormatearColumna("Stock Afectado", pos, 100)
         .Columns(Entidades.EstadoPedidoProveedor.Columnas.IdEstadoDestino.ToString()).FormatearColumna("Solo puede pasar a", pos, 100)
         dgvDatos.AgregarFiltroEnLinea({})

      End With
   End Sub

#End Region

#Region "Eventos"
   Private Sub dgvDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      TryCatched(
      Sub()
         Dim row = e.Row.FilaSeleccionada(Of DataRow)
         If row IsNot Nothing Then
            Dim colorColumnKey = Entidades.EstadoPedidoProveedor.Columnas.Color.ToString()
            If row.Table.Columns.Contains(colorColumnKey) AndAlso IsNumeric(e.Row.Cells(colorColumnKey).Value) Then
               Dim colorEstado = Color.FromArgb(row.Field(Of Integer)(colorColumnKey))
               e.Row.Cells(colorColumnKey).Color(colorEstado, colorEstado)
            End If
         End If
      End Sub)
   End Sub
#End Region

#Region "Parametros"
   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _parametros = parametros
      If parametros IsNot Nothing Then
         Dim parametrosCol As String() = parametros.Split("\"c)
         _tipoTipoComprobante = parametrosCol(0)
         If parametrosCol.Length > 1 Then
            Dim tipos As String() = parametrosCol(1).Split(","c)
            _tipoTipoComprobanteParaCombo = tipos(0)
            If tipos.Length > 1 Then
               _tipoTipoComprobanteParaCombo2 = tipos(1)
            End If
         End If
      End If
   End Sub

   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Definir el tipo de Tipo de Comprobante para usar en la pantalla.")
      stb.AppendFormatLine("Por defecto: PEDIDOSPROV\COMPRAS")
      stb.AppendFormatLine("Estructura: {TiposComprobantes.Tipo}\{TiposComprobantes.Tipo Combo (1)},{TiposComprobantes.Tipo Combo (2)}")
      stb.AppendFormatLine("")
      stb.AppendFormatLine("Donde:")
      stb.AppendFormatLine("    {TiposComprobantes.Tipo} es el Tipo de tipo de comprobante de los estados gestionados en la pantalla")
      stb.AppendFormatLine("    {TiposComprobantes.Tipo Combo (1)} es el Tipo de tipo de comprobante que se carga en el combo de TP Comp")
      stb.AppendFormatLine("    {TiposComprobantes.Tipo Combo (2)} es el segundo Tipo de TP comp que se carga en el combo de TP Comp")
      stb.AppendFormatLine("")
      stb.AppendFormatLine("    Los TiposComprobantes.Tipo Combo (1) y TiposComprobantes.Tipo Combo (2) se combinan con OR")
      Return stb.ToString()
   End Function
#End Region
End Class