Public Class ProcesoTalleresExternosEnvioVincularOC

   Private _dtOP As DataTable
   Private _drOP As DataRow
   Private _tit As Dictionary(Of String, String)

#Region "Overrides/Overloads"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _tit = GetColumnasVisiblesGrilla(ugOC)
         ugOC.AgregarTotalesSuma({"Cantidad", "CantEntregada", "CantidadNuevoEstado"})
         ugOC.AgregarFiltroEnLinea({"Observacion"})
         MostrarInformacionOP()
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Public Overloads Function ShowDialog(owner As IWin32Window, dr As DataRow, dtOP As DataTable) As DialogResult
      _drOP = dr
      _dtOP = dtOP
      Return ShowDialog(owner)
   End Function
#End Region

#Region "Eventos"
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub

   Private Sub ugOC_CellChange(sender As Object, e As CellEventArgs) Handles ugOC.CellChange
      TryCatched(
      Sub()
         If e.Cell.Column.Key = "masivo" Then
            Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)
            If dr IsNot Nothing Then
               e.Cell.UpdateData()

               If Not FilaSeleccionada(dr) Then
                  dr("CantidadNuevoEstado") = 0D
               Else
                  dr("CantidadNuevoEstado") = Math.Max(0, Math.Min(CalculaCantidadPendiente(), dr.Field(Of Decimal)("CantEntregada")))
               End If
            End If
         End If
      End Sub)
   End Sub
   Private Sub ugOC_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugOC.AfterCellUpdate
      TryCatched(
      Sub()
         If CalculaCantidadPendiente() < 0 Then
            For Each row In ugOC.Rows
               Dim dr = row.FilaSeleccionada(Of DataRow)()
               If dr IsNot Nothing AndAlso FilaSeleccionada(dr) Then
                  row.Cells("CantidadNuevoEstado").Color(Color.White, Color.Red)
               End If
            Next
         Else
            For Each row In ugOC.Rows
               Dim dr = row.FilaSeleccionada(Of DataRow)()
               If dr IsNot Nothing Then
                  Dim colores = GetColoresCelda(dr)
                  row.Cells("CantidadNuevoEstado").Color(colores)
               End If
            Next
         End If
      End Sub)
   End Sub
   Private Sub ugOC_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugOC.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            If FilaSeleccionada(dr) Then
               e.Row.Cells("CantidadNuevoEstado").Activation = Activation.AllowEdit
            Else
               e.Row.Cells("CantidadNuevoEstado").Activation = Activation.ActivateOnly
            End If

            Dim colores = GetColoresCelda(dr)
            e.Row.Cells("CantidadNuevoEstado").Color(colores)

         End If
      End Sub)
   End Sub

   Private Function GetColoresCelda(dr As DataRow) As ColorPair
      Dim colores As ColorPair
      If FilaSeleccionada(dr) Then
         If CalculaCantidadPendiente() < 0 Then
            colores = New ColorPair(Color.White, Color.Red)
         Else
            If dr.Field(Of Decimal)("CantidadNuevoEstado") > dr.Field(Of Decimal)("CantEntregada") Then
               colores = New ColorPair(Color.White, Color.Red)
            Else
               colores = New ColorPair(Color.Black, Color.Cyan)
            End If
         End If
      Else
         colores = ColorPair.ColorCleaner()
      End If

      Return colores
   End Function

#End Region


#Region "Metodos Privados"
   Private Function CalculaCantidadPendiente() As Decimal
      Dim cantidadOP = txtCantidad.ValorNumericoPorDefecto(0D)
      Dim cantidadTotalSeleccionada = ugOC.DataSource(Of DataTable).Sum(Function(dr) dr.Field(Of Decimal)("CantidadNuevoEstado"))
      Return cantidadOP - cantidadTotalSeleccionada
   End Function

   Private Sub MostrarInformacionOP()
      If _drOP IsNot Nothing Then
         txtOrdenProduccion.Text = GetPkComprobanteOP(_drOP)
         txtProducto.Text = String.Format("{0} - {1}",
                                          _drOP.Field(Of String)("IdProductoProceso"),
                                          _drOP.Field(Of String)("NombreProductoResultante"))
         If _drOP.Field(Of Integer?)("NumeroPedido").HasValue Then
            txtPedido.Text = String.Format("{0} {1} {2:0000}-{3:00000000} - Ln: {4}",
                                           _drOP.Field(Of String)("DescripcionTipoComprobantePedido"), _drOP.Field(Of String)("LetraPedido"),
                                           _drOP.Field(Of Integer)("CentroEmisorPedido"), _drOP.Field(Of Integer)("NumeroPedido"),
                                           _drOP.Field(Of Integer)("OrdenPedido"))
         End If
         txtCantidad.SetValor(_drOP.Field(Of Decimal)("CantidadSeleccionada"))

         Dim rPedidos = New Reglas.PedidosProveedores()
         Dim dtOC = rPedidos.GetPedidos({actual.Sucursal}, Reglas.Publicos.EstadoOrdenCompraAVincular,
                                        fechaDesde:=Nothing, fechaHasta:=Nothing, numeroPedido:=0,
                                        _drOP.Field(Of String)("IdProductoProceso"),
                                        idProveedor:=0, marcas:={}, modelos:={}, rubros:={}, subRubros:={}, subSubRubros:={}, ordenCompra:=0,
                                        Entidades.TipoComprobante.Tipos.ORDENCOMPRAPROV.ToString(),
                                        tiposComprobante:={},
                                        letra:="", centroEmisor:=0, orden:=0, fechaEstado:=Nothing,
                                        seguridadRol:=Entidades.Publicos.LecturaEscrituraTodos.LECTURA)

         If _drOP IsNot Nothing Then
            Dim drColOCenOP = _drOP.Field(Of DataRow())("Vincular")
            If drColOCenOP IsNot Nothing Then
               For Each drOCenOP In drColOCenOP
                  If FilaSeleccionada(drOCenOP) Then
                     For Each drOCenGrilla In dtOC.Where(Function(dr) _
                                                         dr.Field(Of Integer)("IdSucursal") = drOCenOP.Field(Of Integer)("IdSucursal") And
                                                         dr.Field(Of String)("IdTipoComprobante") = drOCenOP.Field(Of String)("IdTipoComprobante") And
                                                         dr.Field(Of String)("Letra") = drOCenOP.Field(Of String)("Letra") And
                                                         dr.Field(Of Integer)("CentroEmisor") = drOCenOP.Field(Of Integer)("CentroEmisor") And
                                                         dr.Field(Of Long)("NumeroPedido") = drOCenOP.Field(Of Long)("NumeroPedido") And
                                                         dr.Field(Of Integer)("Orden") = drOCenOP.Field(Of Integer)("Orden") And
                                                         dr.Field(Of Date)("FechaEstado") = drOCenOP.Field(Of Date)("FechaEstado"))
                        drOCenGrilla("masivo") = Boolean.TrueString
                        drOCenGrilla("CantidadNuevoEstado") = drOCenOP("CantidadNuevoEstado")
                     Next
                  End If
               Next
            End If
         End If


         'TODO: Descontar a la OC lo seleccionado en otras OP
         'For Each drOP In _dtOP.Where(Function(dr) Not dr.Equals(_drOP))
         '   Dim drColOCenOP = drOP.Field(Of DataRow())("Vincular")
         '   If drColOCenOP IsNot Nothing Then
         '      For Each drOCenOP In drColOCenOP

         '      Next
         '   End If
         'Next


         ugOC.DataSource = dtOC
         AjustarColumnasGrilla(ugOC, _tit)

      End If
   End Sub
   Public Sub Aceptar()
      ugOC.UpdateData()
      If ValidaAceptar() Then
         _drOP("Vincular") = ugOC.DataSource(Of DataTable).Where(Function(dr) FilaSeleccionada(dr)).ToArray()
         Close(DialogResult.OK)
      End If
   End Sub

   Private Function ValidaAceptar() As Boolean
      Dim dtOC = ugOC.DataSource(Of DataTable)
      Dim drSeleccionados = ugOC.DataSource(Of DataTable).Where(Function(dr) FilaSeleccionada(dr)).ToArray()
      If Not drSeleccionados.AnySecure() Then
         ShowMessage("No seleccionó ninguna Orden de Compra")
         ugOC.Focus()
         Return False
      End If
      For Each drSelCero In drSeleccionados.Where(Function(dr) dr.Field(Of Decimal)("CantidadNuevoEstado") = 0)
         ShowMessage(String.Format("La {0} fue seleccionada pero la Cantidad a Vincular es cero.",
                                   GetPkComprobante(drSelCero)))
         ugOC.Focus()
         Return False
      Next
      For Each drSelCero In drSeleccionados.Where(Function(dr) dr.Field(Of Decimal)("CantidadNuevoEstado") > dr.Field(Of Decimal)("CantEntregada"))
         ShowMessage(String.Format("Seleccionó mayor cantidad de la disponible en el estado de la {0}.",
                                   GetPkComprobante(drSelCero)))
         ugOC.Focus()
         Return False
      Next

      Dim totalSeleccionado = drSeleccionados.SumSecure(Function(dr) dr.Field(Of Decimal)("CantidadNuevoEstado"))
      If totalSeleccionado > txtCantidad.ValorNumericoPorDefecto(0D) Then
         ShowMessage(String.Format("Seleccionó mayor cantidad de la necesaria para en la {0}.",
                                   GetPkComprobanteOP(_drOP)))
         ugOC.Focus()
         Return False
      End If
      Return True
   End Function

   Private Function FilaSeleccionada(dr As DataRow) As Boolean
      Return dr.Field(Of String)("masivo") = Boolean.TrueString
   End Function

   Private Function GetPkComprobanteOP(dr As DataRow) As String
      Return String.Format("{0} {1} {2:0000}-{3:00000000} - Ln: {4}",
                           dr.Field(Of String)("DescripcionTipoComprobanteOP"), dr.Field(Of String)("LetraComprobante"),
                           dr.Field(Of Integer)("CentroEmisor"), dr.Field(Of Integer)("NumeroOrdenProduccion"),
                           dr.Field(Of Integer)("Orden"))
   End Function
   Private Function GetPkComprobante(dr As DataRow) As String
      Return String.Format("{0} {1} {2:0000}-{3:00000000}.",
                           dr.Field(Of String)("DescripcionTipoComprobante"), dr.Field(Of String)("Letra"),
                           dr.Field(Of Integer)("CentroEmisor"), dr.Field(Of Integer)("NumeroPedido"),
                           dr.Field(Of Integer)("Orden"))
   End Function

#End Region

End Class