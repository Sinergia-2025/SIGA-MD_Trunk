Public Class ProduccionProductosComponentesNrosSerie
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProduccionProductosComponentesNrosSerie_I(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                                        idProductoComponente As String, secuenciaFormula As Integer,
                                                        nroSerie As String)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("INSERT INTO {0} (", Entidades.ProduccionProductoCompNroSerie.NombreTabla)
         .AppendFormatLine("     IdSucursal")
         .AppendFormatLine("   , IdProduccion")
         .AppendFormatLine("   , Orden")
         .AppendFormatLine("   , IdProducto")
         .AppendFormatLine("   , IdProductoComponente")
         .AppendFormatLine("   , SecuenciaFormula")
         .AppendFormatLine("   , NroSerie")

         .AppendFormatLine("   )  VALUES (")
         .AppendFormatLine("      {0} ", idSucursal)
         .AppendFormatLine("   ,  {0} ", idProduccion)
         .AppendFormatLine("   ,  {0} ", orden)
         .AppendFormatLine("   , '{0}'", idProducto)
         .AppendFormatLine("   , '{0}'", idProductoComponente)
         .AppendFormatLine("   ,  {0} ", secuenciaFormula)
         .AppendFormatLine("   , '{0}'", nroSerie)
         .AppendFormatLine(")")
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProduccionProductos")
   End Sub
   Public Sub ProduccionProductosComponentesNrosSerie_D(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                                        idProductoComponente As String, secuenciaFormula As Integer,
                                                        nroSerie As String)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("DELETE {0}", Entidades.ProduccionProductoCompNroSerie.NombreTabla)
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
         If Not String.IsNullOrWhiteSpace(nroSerie) Then
            .AppendFormatLine("   AND NroSerie = '{0}'", nroSerie)
         End If
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProduccionProductos")
   End Sub

   Public Function ProduccionProductosComponentesNrosSerie_G1(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                                              idProductoComponente As String, secuenciaFormula As Integer,
                                                              nroSerie As String) As DataTable
      Return ProduccionProductosComponentesNrosSerie_G(idSucursal, idProduccion, orden, idProducto, idProductoComponente, secuenciaFormula, nroSerie)
   End Function
   Public Function ProduccionProductosComponentesNrosSerie_GA(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                                              idProductoComponente As String, secuenciaFormula As Integer) As DataTable
      Return ProduccionProductosComponentesNrosSerie_G(idSucursal, idProduccion, orden, idProducto, idProductoComponente, secuenciaFormula, nroSerie:=String.Empty)
   End Function
   Private Function ProduccionProductosComponentesNrosSerie_G(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                                              idProductoComponente As String, secuenciaFormula As Integer,
                                                              nroSerie As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT PPNS.*")
         .AppendFormatLine("  FROM {0} PPNS", Entidades.ProduccionProductoCompNroSerie.NombreTabla)
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
         If Not String.IsNullOrWhiteSpace(nroSerie) Then
            .AppendFormatLine("   AND PPNS.NroSerie = '{0}'", nroSerie)
         End If
      End With
      Return GetDataTable(stbQuery)
   End Function

End Class