Public Class SeleccionNrosLotes

#Region "Campos"
   Private _productoLote As Entidades.Producto = Nothing
   Private _cantidadSolicitada As Decimal = 0
   Private _coeficienteStock As Integer = 0
   Private _dt As DataTable = Nothing

   Private _idDeposito As Integer
   Private _idUbicacion As Integer

   Public _lotesSeleccionados As DataTable = Nothing
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(productoLote As Entidades.Producto, idDeposito As Integer, idUbicacion As Integer, cantidadSolicitada As Decimal, coeficienteStock As Integer, orden As Integer)
      Me.New(productoLote, idDeposito, idUbicacion, cantidadSolicitada, coeficienteStock, lotesSeleccionados:=Nothing)
   End Sub

   Public Sub New(productoLote As Entidades.Producto, idDeposito As Integer, idUbicacion As Integer, cantidadSolicitada As Decimal, coeficienteStock As Integer, lotesSeleccionados As DataTable)
      Me.New()
      _idDeposito = idDeposito
      _idUbicacion = idUbicacion
      _cantidadSolicitada = cantidadSolicitada
      _productoLote = productoLote
      _coeficienteStock = coeficienteStock
      _lotesSeleccionados = lotesSeleccionados
   End Sub
#End Region

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         If _productoLote IsNot Nothing Then
            lblProducto.Text = String.Format("Producto: {0} - Cantidad Solicitada: {1:N2}", Me._productoLote.NombreProducto, Me._cantidadSolicitada.ToString())
            CargarGrillaDetalle()
         End If
      End Sub)
   End Sub

#Region "Métodos"
   Private Sub CargarLotes()
      _lotesSeleccionados = _dt.Select("CantidadSeleccionada <> 0").CopyToDataTable
   End Sub

   Private Sub CargarGrillaDetalle()
      If _productoLote IsNot Nothing Then
         Dim rProductoLote As Reglas.ProductosLotes = New Reglas.ProductosLotes
         '# Si el coeficiente Stock es menor a 0 (ej: una venta), se van a buscar todos los lotes que tengan stock disponible. Caso contrario se traerán todos los lotes habilitados, con o sin stock.
         _dt = rProductoLote.GetPorProducto(_productoLote.IdSucursal, _idDeposito, _idUbicacion, _productoLote.IdProducto, parteIdLote:=Nothing, validarStock:=If(_coeficienteStock < 0, True, False))
         If _dt.Rows.Count > 0 Then
            _dt.Columns.Add("CantidadSeleccionada", GetType(Decimal))

            '# Visibilizo la columna Fecha de Vencimiento solo si el parámetro está activado
            ugNrosLotes.DisplayLayout.Bands(0).Columns("FechaVencimiento").Hidden = Not Publicos.LoteSolicitaFechaVencimiento

            ugNrosLotes.DataSource = _dt

            '# En caso que ya se hayan seleccionado lotes anteriormente, los vuelvo a marcar y a setear las cantidades que se seleccionaron anteriormente
            If _lotesSeleccionados IsNot Nothing Then
               For Each dr As DataRow In _dt.Rows
                  For Each row As DataRow In _lotesSeleccionados.Rows
                     If row("IdLote").ToString() = dr.Field(Of String)("IdLote") AndAlso
                        row("IdProducto").ToString() = dr.Field(Of String)("IdProducto") Then
                        dr("CantidadSeleccionada") = row.Field(Of Decimal)("CantidadSeleccionada")
                        dr("FechaVencimiento") = row("FechaVencimiento")
                     End If
                  Next
               Next
            End If
         End If
      End If

   End Sub

   Private Function ValidarDetalle() As Boolean

      Dim sumaCantidadTotal As Decimal = 0

      '# Validar que se haya seleccionado al menos 1 lote
      If Not _dt.Select(String.Format("CantidadSeleccionada <> 0")).Count > 0 Then
         ShowMessage(String.Format("ATENCIÓN: Debe seleccionar al menos un lote a {0}.", If(_coeficienteStock < 0, "descontar", "reponer")))
         Return False
      End If

      For Each dr As DataRow In _dt.Select(String.Format("CantidadSeleccionada <> 0"))

         '# Validar que de los lotes que se seleccionaron, en todos se haya ingresado una cantidad y que sea > 0
         If CDec(dr("CantidadSeleccionada")) <= 0 Then
            ShowMessage(String.Format("ATENCIÓN: Se ha seleccionado el lote {0} pero se ha ingresado una cantidad inválida.", dr.Field(Of String)("IdLote")))
            Return False
         End If

         '# Validar que no supere el stock actual del lote
         If _coeficienteStock < 0 Then
            If CDec(dr("CantidadSeleccionada")) > CDec(dr("CantidadActual")) Then
               ShowMessage(String.Format("ATENCIÓN: La cantidad ingresada en el lote {0} supera el stock del lote.", dr.Field(Of String)("IdLote")))
               Return False
            End If
         End If

         '# Si pasa las validaciones, voy sumando la cantidad para la siguiente validación
         sumaCantidadTotal += CDec(dr("CantidadSeleccionada"))
      Next

      '# Validar que la suma de las cantidades ingresadas sea IGUAL a la cantidad solicitada
      If sumaCantidadTotal <> _cantidadSolicitada Then
         ShowMessage(String.Format("ATENCIÓN: La cantidad a {2} ingresada ({0}) debe ser igual a la cantidad a {2} solicitada ({1}).", sumaCantidadTotal, _cantidadSolicitada, If(_coeficienteStock < 0, "descontar", "reponer")))
         Return False
      End If

      Return True
   End Function

#End Region

#Region "Eventos"
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
      Sub()
         If ValidarDetalle() Then
            CargarLotes()
            Close(DialogResult.OK)
         End If
      End Sub)
   End Sub
#End Region

End Class