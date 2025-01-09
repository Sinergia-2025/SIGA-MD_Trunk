<Obsolete("Se reemplaza por MovimientosStockProductosNrosSerie", True)>
Public Class MovimientosVentasProductosNrosSerie
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MovimientosVentasProductosNrosSerie_I(idSucursal As Integer,
                                                    idTipoMovimiento As String,
                                                    numeroMovimiento As Long,
                                                    orden As Integer,
                                                    idProducto As String,
                                                    nroSerie As String,
                                                    cantidad As Integer)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("INSERT INTO MovimientosVentasProductosNrosSerie(")
         .AppendFormatLine("	IdSucursal,")
         .AppendFormatLine("	IdTipoMovimiento,")
         .AppendFormatLine("	NumeroMovimiento,")
         .AppendFormatLine("	Orden,")
         .AppendFormatLine("	IdProducto,")
         .AppendFormatLine("	NroSerie,")
         .AppendFormatLine("	Cantidad")
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine(" {0}", idSucursal)
         .AppendFormatLine(" ,'{0}'", idTipoMovimiento)
         .AppendFormatLine(" ,{0}", numeroMovimiento)
         .AppendFormatLine(" ,{0}", orden)
         .AppendFormatLine(" ,'{0}'", idProducto)
         .AppendFormatLine(" ,'{0}'", nroSerie)
         .AppendFormatLine(" ,{0}", cantidad)
         .AppendFormatLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub MovimientosVentasProductosNrosSerie_U(idSucursal As Integer,
                                                    idTipoMovimiento As String,
                                                    numeroMovimiento As Long,
                                                    orden As Integer,
                                                    idProducto As String,
                                                    nroSerie As String,
                                                    cantidad As Integer)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE MovimientosVentasProductosNrosSerie SET")
         .AppendFormatLine("	NroSerie = '{0}'", nroSerie)
         .AppendFormatLine("	,Cantidad = {0}", cantidad)
         .AppendFormatLine("WHERE {0} = {1}", Entidades.MovimientoVentaProductoNroSerie.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("	AND {0} = '{1}'", Entidades.MovimientoVentaProductoNroSerie.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("	AND {0} = {1}", Entidades.MovimientoVentaProductoNroSerie.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
         .AppendFormatLine("	AND {0} = {1}", Entidades.MovimientoVentaProductoNroSerie.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("	AND {0} = '{1}'", Entidades.MovimientoVentaProductoNroSerie.Columnas.IdProducto.ToString(), idProducto)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub MovimientosVentasProductosNrosSerie_D(idSucursal As Integer,
                                                    idTipoMovimiento As String,
                                                    numeroMovimiento As Long)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE MovimientosVentasProductosNrosSerie")
         .AppendFormatLine("WHERE {0} = {1}", Entidades.MovimientoVentaProductoNroSerie.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("	AND {0} = '{1}'", Entidades.MovimientoVentaProductoNroSerie.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("	AND {0} = {1}", Entidades.MovimientoVentaProductoNroSerie.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function MovimientosVentasProductosNrosSerie_GA() As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function MovimientosVentasProductosNrosSerie_G1(idSucursal As Integer,
                                                          idTipoMovimiento As String,
                                                          numeroMovimiento As Long,
                                                          orden As Integer,
                                                          idProducto As String,
                                                          nroSerie As String) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormatLine("WHERE {0} = {1}", Entidades.MovimientoVentaProductoNroSerie.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("	AND {0} = '{1}'", Entidades.MovimientoVentaProductoNroSerie.Columnas.IdTipoMovimiento.ToString(), idTipoMovimiento)
         .AppendFormatLine("	AND {0} = {1}", Entidades.MovimientoVentaProductoNroSerie.Columnas.NumeroMovimiento.ToString(), numeroMovimiento)
         .AppendFormatLine("	AND {0} = {1}", Entidades.MovimientoVentaProductoNroSerie.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("	AND {0} = '{1}'", Entidades.MovimientoVentaProductoNroSerie.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("	AND {0} = '{1}'", Entidades.MovimientoVentaProductoNroSerie.Columnas.NroSerie.ToString(), nroSerie)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function GetUltimoNumeroDeMovimiento(idSucursal As Integer,
                                               idTipoMovimiento As String) As Integer
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT MAX(NumeroMovimiento) Numero FROM MovimientosVentasProductosNrosSerie")
         .AppendFormatLine("	WHERE IdTipoMovimiento = '{0}'", idTipoMovimiento)
         .AppendFormatLine("	AND IdSucursal = {0}", idSucursal)
      End With

      Dim dt As DataTable = Me.GetDataTable(query.ToString())
      If (dt.Rows.Count > 0 AndAlso IsNumeric(dt.Rows(0)("Numero"))) Then
         Return Int32.Parse(dt.Rows(0)("Numero").ToString())
      Else
         Return 0
      End If

      Me.GetDataTable(query.ToString())
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT")
         .AppendFormatLine("	IdSucursal")
         .AppendFormatLine("	,IdTipoMovimiento")
         .AppendFormatLine("	,NumeroMovimiento")
         .AppendFormatLine("	,Orden")
         .AppendFormatLine("	,IdProducto")
         .AppendFormatLine("	,NroSerie")
         .AppendFormatLine("	,Cantidad")
         .AppendFormatLine("FROM MovimientosVentasProductosNrosSerie")
      End With
   End Sub

End Class
