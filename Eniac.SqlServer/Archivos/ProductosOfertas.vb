Public Class ProductosOfertas
   Inherits Comunes

#Region "Constructores"
   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub ProductosOfertas_I(idProducto As String,
                                 idOferta As Integer,
                                 fechaDesde As Date,
                                 fechaHasta As Date,
                                 limiteStock As Decimal,
                                 cantidadConsumida As Decimal,
                                 precioOferta As Decimal,
                                 activa As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO ProductosOfertas")
         .AppendFormatLine("           (IdProducto")
         .AppendFormatLine("           ,IdOferta")
         .AppendFormatLine("           ,FechaDesde")
         .AppendFormatLine("           ,FechaHasta")
         .AppendFormatLine("           ,LimiteStock")
         .AppendFormatLine("           ,CantidadConsumida")
         .AppendFormatLine("           ,PrecioOferta")
         .AppendFormatLine("           ,Activa)")
         .AppendFormatLine("  VALUES ")
         .AppendFormatLine("      ('{0}'", idProducto)
         .AppendFormatLine("       ,{0}", idOferta)
         .AppendFormatLine("       ,'{0}'", ObtenerFecha(fechaDesde, True))
         .AppendFormatLine("       ,'{0}'", ObtenerFecha(UltimoSegundoDelDia(fechaHasta), True))
         .AppendFormatLine("       ,{0}", limiteStock)
         .AppendFormatLine("       ,{0}", cantidadConsumida)
         .AppendFormatLine("       ,{0}", precioOferta)
         .AppendFormatLine("       ,{0})", Me.GetStringFromBoolean(activa))
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ProductosOfertas")
   End Sub

   Public Sub ProductosOfertas_U(idProducto As String,
                                 idOferta As Integer,
                                 fechaDesde As Date,
                                 fechaHasta As Date,
                                 limiteStock As Decimal,
                                 cantidadConsumida As Decimal,
                                 precioOferta As Decimal,
                                 activa As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE ProductosOfertas SET ")
         .AppendFormatLine("       FechaDesde =  '{0}'", ObtenerFecha(fechaDesde, True))
         .AppendFormatLine("      ,FechaHasta =  '{0}'", ObtenerFecha(UltimoSegundoDelDia(fechaHasta), True))
         .AppendFormatLine("      ,PrecioOferta = {0}", precioOferta)
         .AppendFormatLine("      ,LimiteStock =  {0}", limiteStock)
         .AppendFormatLine("      ,CantidadConsumida =  {0}", cantidadConsumida)
         .AppendFormatLine("      ,Activa =       {0}", Me.GetStringFromBoolean(activa))
         .AppendFormatLine("WHERE IdProducto = '{0}' AND IdOferta={1}", idProducto, idOferta)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ProductosOfertas")
   End Sub
   Public Sub ConsumirCantidadOferta(idProducto As String,
                                     idOferta As Integer,
                                     cantidadConsumida As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE ProductosOfertas SET ")
         .AppendFormatLine("      CantidadConsumida = CantidadConsumida + {0}", cantidadConsumida)
         .AppendFormatLine("WHERE IdProducto = '{0}' AND IdOferta = {1}", idProducto, idOferta)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ProductosOfertas")
   End Sub
   Public Sub ProductosOfertas_D(idProducto As String, idOferta As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM ProductosOfertas ")
         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto)
         If idOferta > 0 Then
            .AppendFormatLine("  AND IdOferta = '{0}'", idOferta)
         End If
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ProductosOfertas")
   End Sub
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT   PO.*")
         .AppendFormatLine("  FROM {0} AS PO ", Entidades.ProductoOferta.NombreTabla)
      End With
   End Sub
   Public Function ProductosOfertas_GA(idProducto As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE PO.idProducto = '{0}'", idProducto)
         .AppendFormatLine(" ORDER BY PO.FechaDesde")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function ProductosOfertas_G_Oferta(fechaComprobante As Date, idProducto As String, idOferta As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE  PO.idProducto = '{0}'", idProducto)
         .AppendFormatLine("       AND (PO.Activa = 1) AND (PO.CantidadConsumida < PO.LimiteStock) ")
         .AppendFormatLine("       AND  PO.FechaDesde <='{0}'", ObtenerFecha(fechaComprobante, False))
         .AppendFormatLine("       AND  PO.FechaHasta >= '{0}'", ObtenerFecha(fechaComprobante, False))
         If idOferta > 0 Then
            .AppendFormatLine("       AND PO.IdOferta = {0}", idOferta)
         End If
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function ProductosOfertas_G1(idProducto As String, idOferta As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE PO.idProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND PO.IdOferta = {0}", idOferta)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function ProductosOfertas_Count_OfertaAplicada(idProducto As String, idOferta As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT COUNT(*)")
         .AppendFormatLine("  FROM VentasProductos")
         .AppendFormatLine(" WHERE IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND IdOferta = {0}", idOferta)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
#End Region

   Public Overloads Function GetCodigoMaximo(idProducto As String) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.ProductoOferta.Columnas.IdOferta.ToString(), Entidades.ProductoOferta.NombreTabla,
                                             String.Format("{0} = '{1}'", Entidades.ProductoOferta.Columnas.IdProducto.ToString, idProducto)))
   End Function

End Class