Public Class SeleccionMultipleUbicacionListaProductos

   Public _dtProductos As List(Of Entidades.SeleccionMultipleProducto)
   Private _tit As Dictionary(Of String, String)
   Private _coeficienteStock As Integer
   Private _solicitaInformeCalidad As Boolean

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() MostrarDatos())
   End Sub
   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         btnCancelar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

   Public Overloads Function ShowDialog(owner As IWin32Window, dtProductos As List(Of Entidades.SeleccionMultipleProducto), coeficienteStock As Integer, solicitaInformeCalidad As Boolean) As DialogResult
      _dtProductos = dtProductos
      _coeficienteStock = coeficienteStock
      _solicitaInformeCalidad = solicitaInformeCalidad
      If Not _dtProductos.Any() Then
         Return DialogResult.OK
      End If
      Return ShowDialog(owner)
   End Function



   Private Sub ugProductos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugProductos.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of Entidades.SeleccionMultipleProducto)
         If dr IsNot Nothing Then
            e.Row.Cells("LoteSeleccionado").Activation = If(dr.Producto.Lote, Activation.AllowEdit, Activation.Disabled)
            e.Row.Cells("NroSerieSeleccionado").Activation = If(dr.Producto.NroSerie, Activation.AllowEdit, Activation.Disabled)

         End If
      End Sub)
   End Sub
   Private Sub ugProductos_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugProductos.ClickCellButton
      TryCatched(
      Sub()
         Dim dr = e.Cell.Row.FilaSeleccionada(Of Entidades.SeleccionMultipleProducto)
         If dr IsNot Nothing Then
            'Dim tipoComp = New Reglas.TiposComprobantes().GetUno(estado.IdTipoComprobante, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)

            Dim selectedColumn = e.Cell.Column.Key
            Select Case selectedColumn
               Case "LoteSeleccionado", "NroSerieSeleccionado"
                  Using frm = New SeleccionMultipleUbicacion()
                     If frm.ShowDialog(Me, _coeficienteStock, _solicitaInformeCalidad,
                                       dr.IdProducto, actual.Sucursal.Id, dr.Ubicaciones, dr.Cantidad,
                                       SeleccionMultipleUbicacion.ModosUbicacion.UbicacionFija, SeleccionMultipleUbicacion.ModosLoteSerie.Visible) = DialogResult.OK Then
                        dr.Ubicaciones = frm.UbicacionesSeleccionadas
                     End If
                  End Using

               Case Else

            End Select
         End If

      End Sub)
   End Sub


   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub



   Private Sub MostrarDatos()
      _tit = GetColumnasVisiblesGrilla(ugProductos)

      ugProductos.DataSource = _dtProductos

      AjustarColumnasGrilla(ugProductos, _tit)

      With ugProductos.DisplayLayout.Bands(0)
         .Columns("LoteSeleccionado").Hidden = Not _dtProductos.Any(Function(dr) dr.Producto.Lote)
         .Columns("NroSerieSeleccionado").Hidden = Not _dtProductos.Any(Function(dr) dr.Producto.NroSerie)
      End With

   End Sub

   Private Function Validar() As Boolean
      Dim err = New Entidades.ErrorBuilder()

      For Each p In _dtProductos.Where(Function(dr) dr.Producto.Lote Or dr.Producto.NroSerie)
         Dim cantLote = p.Ubicaciones.SumSecure(Function(u) u.Lotes.SumSecure(Function(l) l.Cantidad).IfNull()).IfNull()
         Dim cantNroSerie = p.Ubicaciones.SumSecure(Function(u) u.NrosSerie.SumSecure(Function(l) l.Cantidad).IfNull()).IfNull()

         If p.Producto.Lote And p.Cantidad <> cantLote Then
            err.AddError("La cantidad de lotes ({2}) seleccionados para el producto {0} - {1} no coincide con la cantidad del producto ({3}).", p.IdProducto, p.NombreProducto, cantLote, p.Cantidad)
         End If
         If p.Producto.NroSerie And p.Cantidad <> cantNroSerie Then
            err.AddError("La cantidad de nros de serie ({2:N0}) seleccionados para el producto {0} - {1} no coincide con la cantidad del producto ({3:N0}).", p.IdProducto, p.NombreProducto, cantNroSerie, p.Cantidad)
         End If
      Next

      If err.AnyError Then
         ShowMessage(err.ErrorToString())
         Return False
      End If

      If err.AnyWarning Then
         If ShowPregunta(err.WarningToString()) = DialogResult.No Then
            Return False
         End If
      End If

      Return True
   End Function
   Private Sub Aceptar()
      If Validar() Then
         Close(DialogResult.OK)
      End If
   End Sub


   Private Function CondicionBusqueda() As Func(Of DataRow, Boolean)
      Return Function(dr) dr.Field(Of Boolean)("ProductoConLote") Or dr.Field(Of Boolean)("ProductoConNroSerie")
   End Function

End Class