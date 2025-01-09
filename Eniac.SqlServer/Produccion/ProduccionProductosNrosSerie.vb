Public Class ProduccionProductosNrosSerie
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProduccionProductosNrosSerie_I(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                             nroSerie As String)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("INSERT INTO {0} (", Entidades.ProduccionProductoNrosSerie.NombreTabla)
         .AppendFormatLine("     IdSucursal")
         .AppendFormatLine("   , IdProduccion")
         .AppendFormatLine("   , Orden")
         .AppendFormatLine("   , IdProducto")
         .AppendFormatLine("   , NroSerie")

         .AppendFormatLine("   )  VALUES (")
         .AppendFormatLine("      {0} ", idSucursal)
         .AppendFormatLine("   ,  {0} ", idProduccion)
         .AppendFormatLine("   ,  {0} ", orden)
         .AppendFormatLine("   , '{0}'", idProducto)
         .AppendFormatLine("   , '{0}'", nroSerie)
         .AppendFormatLine(")")
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProduccionProductos")
   End Sub
   Public Sub ProduccionProductosNrosSerie_D(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                             nroSerie As String)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("DELETE {0}", Entidades.ProduccionProductoNrosSerie.NombreTabla)
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
         If Not String.IsNullOrWhiteSpace(nroSerie) Then
            .AppendFormatLine("   AND NroSerie = '{0}'", nroSerie)
         End If
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProduccionProductos")
   End Sub

   Public Function ProduccionProductosNrosSerie_G1(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                                   nroSerie As String) As DataTable
      Return ProduccionProductosNrosSerie_G(idSucursal, idProduccion, orden, idProducto, nroSerie)
   End Function
   Public Function ProduccionProductosNrosSerie_GA(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String) As DataTable
      Return ProduccionProductosNrosSerie_G(idSucursal, idProduccion, orden, idProducto, nroSerie:=String.Empty)
   End Function
   Private Function ProduccionProductosNrosSerie_G(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                                   nroSerie As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT PPNS.*")
         .AppendFormatLine("  FROM {0} PPNS", Entidades.ProduccionProductoNrosSerie.NombreTabla)
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
         If Not String.IsNullOrWhiteSpace(nroSerie) Then
            .AppendFormatLine("   AND PPNS.NroSerie = '{0}'", nroSerie)
         End If
      End With
      Return GetDataTable(stbQuery)
   End Function

End Class