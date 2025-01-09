Public Class ProduccionProductosComponentesLotes
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProduccionProductosComponentesLotes_I(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                                    idProductoComponente As String, secuenciaFormula As Integer,
                                                    idLote As String, cantidad As Decimal)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("INSERT INTO {0} (", Entidades.ProduccionProductoCompLote.NombreTabla)
         .AppendFormatLine("     IdSucursal")
         .AppendFormatLine("   , IdProduccion")
         .AppendFormatLine("   , Orden")
         .AppendFormatLine("   , IdProducto")
         .AppendFormatLine("   , IdProductoComponente")
         .AppendFormatLine("   , SecuenciaFormula")
         .AppendFormatLine("   , IdLote")
         .AppendFormatLine("   , Cantidad")

         .AppendFormatLine("   )  VALUES (")
         .AppendFormatLine("      {0} ", idSucursal)
         .AppendFormatLine("   ,  {0} ", idProduccion)
         .AppendFormatLine("   ,  {0} ", orden)
         .AppendFormatLine("   , '{0}'", idProducto)
         .AppendFormatLine("   , '{0}'", idProductoComponente)
         .AppendFormatLine("   ,  {0} ", secuenciaFormula)
         .AppendFormatLine("   , '{0}'", idLote)
         .AppendFormatLine("   ,  {0} ", cantidad)
         .AppendFormatLine(")")
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProduccionProductos")
   End Sub
   Public Sub ProduccionProductosComponentesLotes_D(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                                    idProductoComponente As String, secuenciaFormula As Integer,
                                                    idLote As String)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("DELETE {0}", Entidades.ProduccionProductoCompLote.NombreTabla)
         .AppendFormatLine(" WHERE 1 = 1")
         If idSucursal <> 0 Then
            .AppendFormatLine("   AND IdSucursal = {0}", idSucursal)
         End If
         If idProduccion <> 0 Then
            .AppendFormatLine("   AND IdProduccion = {0}", idProduccion)
         End If
         If orden <> 0 Then
            .AppendFormatLine("   AND Orden = {0}", orden)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoComponente) Then
            .AppendFormatLine("   AND IdProductoComponente = '{0}'", idProductoComponente)
         End If
         If secuenciaFormula <> 0 Then
            .AppendFormatLine("   AND SecuenciaFormula = {0}", secuenciaFormula)
         End If
         If Not String.IsNullOrWhiteSpace(idLote) Then
            .AppendFormatLine("   AND IdLote = '{0}'", idLote)
         End If
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProduccionProductos")
   End Sub

   Public Function ProduccionProductosComponentesLotes_G1(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                                              idProductoComponente As String, secuenciaFormula As Integer,
                                                              idLote As String) As DataTable
      Return ProduccionProductosComponentesLotes_G(idSucursal, idProduccion, orden, idProducto, idProductoComponente, secuenciaFormula, idLote)
   End Function
   Public Function ProduccionProductosComponentesLotes_GA(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                                          idProductoComponente As String, secuenciaFormula As Integer) As DataTable
      Return ProduccionProductosComponentesLotes_G(idSucursal, idProduccion, orden, idProducto, idProductoComponente, secuenciaFormula, idLote:=String.Empty)
   End Function
   Private Function ProduccionProductosComponentesLotes_G(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                                          idProductoComponente As String, secuenciaFormula As Integer,
                                                          idLote As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT PPNS.*")
         .AppendFormatLine("  FROM {0} PPNS", Entidades.ProduccionProductoCompLote.NombreTabla)
         .AppendFormatLine(" WHERE 1 = 1")
         If idSucursal <> 0 Then
            .AppendFormatLine("   AND PPNS.IdSucursal = {0}", idSucursal)
         End If
         If idProduccion <> 0 Then
            .AppendFormatLine("   AND PPNS.IdProduccion = {0}", idProduccion)
         End If
         If orden <> 0 Then
            .AppendFormatLine("   AND PPNS.Orden = {0}", orden)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND PPNS.IdProducto = '{0}'", idProducto)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoComponente) Then
            .AppendFormatLine("   AND PPNS.IdProductoComponente = '{0}'", idProductoComponente)
         End If
         If secuenciaFormula <> 0 Then
            .AppendFormatLine("   AND PPNS.SecuenciaFormula = {0}", secuenciaFormula)
         End If
         If Not String.IsNullOrWhiteSpace(idLote) Then
            .AppendFormatLine("   AND PPNS.IdLote = '{0}'", idLote)
         End If
      End With
      Return GetDataTable(stbQuery)
   End Function

End Class