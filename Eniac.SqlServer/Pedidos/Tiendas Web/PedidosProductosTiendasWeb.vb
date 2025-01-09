Public Class PedidosProductosTiendasWeb
   Inherits Comunes

#Region "Constructores"

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub PedidosProductosTiendasWeb_I(id As String,
                                           sistemaDestino As String,
                                           numero As Long,
                                           idProductoTiendaWeb As String,
                                           nombreProductoTiendaWeb As String,
                                           precio As Decimal,
                                           cantidad As Decimal)

      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO PedidosProductosTiendasWeb (")
         .AppendFormatLine("	 Id")
         .AppendFormatLine("	,SistemaDestino")
         .AppendFormatLine("	,Numero")
         .AppendFormatLine("	,IdProductoTiendaWeb")
         .AppendFormatLine("	,NombreProductoTiendaWeb")
         .AppendFormatLine("	,Precio")
         .AppendFormatLine("	,Cantidad")
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	 '{0}'", id)
         .AppendFormatLine("	,'{0}'", sistemaDestino)
         .AppendFormatLine("	,{0}", numero)
         .AppendFormatLine("	,'{0}'", idProductoTiendaWeb)
         .AppendFormatLine("	,'{0}'", NombreProductoTiendaWeb)
         .AppendFormatLine("	,{0}", precio)
         .AppendFormatLine("	,{0}", cantidad)
         .AppendFormatLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub PedidosProductosTiendasWeb_U(id As String,
                                           sistemaDestino As String,
                                           numero As Long,
                                           idProductoTiendaWeb As String,
                                           precio As Decimal,
                                           cantidad As Decimal)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE PPTW SET")
         .AppendFormatLine("	 PPTW.Numero = {0}")
         .AppendFormatLine("	,PPTW.Precio = {0}")
         .AppendFormatLine("	,PPTW.Cantidad = {0}")
         .AppendFormatLine("FROM PedidosProductosTiendasWeb PPTW")
         .AppendFormatLine("WHERE PPTW.Id = '{0}' AND PPTW.SistemaDestino = '{1}' AND PPTW.IdProductoTiendaWeb = '{2}'", id, sistemaDestino, idProductoTiendaWeb)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub PedidosProductosTiendasWeb_D(id As String, sistemaDestino As String, idProductoTiendaWeb As String)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE PedidosProductosTiendasWeb")
         .AppendFormatLine("WHERE Id = '{0}' AND SistemaDestino = '{1}' AND IdProductoTiendaWeb = '{2}'", id, sistemaDestino, idProductoTiendaWeb)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function PedidosProductosTiendasWeb_GA() As DataTable
      Return Me.PedidosProductosTiendasWeb_GA(Nothing, Nothing)
   End Function

   Public Function PedidosProductosTiendasWeb_GA(sistemaDestino As String,
                                                 id As String) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query)
         If Not String.IsNullOrEmpty(sistemaDestino) Then
            .AppendFormatLine("WHERE Id = '{0}' AND SistemaDestino = '{1}'", id, sistemaDestino)
         End If
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function PedidosProductosTiendasWeb_G1(id As String, sistemaDestino As String, idProductoTiendaWeb As String) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query)
         .AppendFormatLine("WHERE Id = '{0}' AND SistemaDestino = '{1}' AND IdProductoTiendaWeb = '{2}'", id, sistemaDestino, idProductoTiendaWeb)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function GetPedidosProductosAImportar(sistemaDestino As String, estados As String(),
                                                nroPedido As Long?,
                                                desde As DateTime?,
                                                hasta As DateTime?,
                                                tipoFechaFiltro As String) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT PPTW.Id, PPTW.SistemaDestino, PPTW.NombreProductoTiendaWeb Producto, PPTW.Precio, PPTW.Cantidad FROM PedidosProductosTiendasWeb PPTW")
         .AppendFormatLine("  INNER JOIN PedidosTiendasWeb PTW ON PPTW.Id = PTW.Id AND PPTW.SistemaDestino = PTW.SistemaDestino")
         .AppendFormatLine("WHERE 1 = 1")
         .AppendFormatLine("  AND PTW.SistemaDestino = '{0}' ", sistemaDestino)
         If estados IsNot Nothing Then GetListaMultiples(query, estados, "PTW", "IdEstadoPedidoTiendaWeb")
         If nroPedido.HasValue AndAlso nroPedido.Value <> 0 Then .AppendFormatLine("  AND PTW.Numero = {0}", nroPedido.Value)

         If Not String.IsNullOrEmpty(tipoFechaFiltro) Then
            If tipoFechaFiltro = "FechaPedido" Then
               .AppendFormatLine("  AND PTW.FechaPedido >= {0} AND PTW.FechaPedido <= {1}", ObtenerFecha(desde, True), ObtenerFecha(hasta, True))
            ElseIf tipoFechaFiltro = "FechaDescarga" Then
               .AppendFormatLine("  AND PTW.FechaDescarga >= {0} AND PTW.FechaDescarga <= {1}", ObtenerFecha(desde, True), ObtenerFecha(hasta, True))
            ElseIf tipoFechaFiltro = "FechaEstado" Then
               .AppendFormatLine("  AND PTW.FechaEstado >= {0} AND PTW.FechaEstado <= {1}", ObtenerFecha(desde, True), ObtenerFecha(hasta, True))
            End If
         End If
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	 PPTW.Id")
         .AppendFormatLine("	,PPTW.SistemaDestino")
         .AppendFormatLine("	,PPTW.Numero")
         .AppendFormatLine("	,PPTW.IdProductoTiendaWeb")
         .AppendFormatLine("	,PPTW.NombreProductoTiendaWeb")
         .AppendFormatLine("	,PPTW.Precio")
         .AppendFormatLine("	,PPTW.Cantidad")
         .AppendFormatLine("FROM PedidosProductosTiendasWeb PPTW")
      End With
   End Sub

End Class