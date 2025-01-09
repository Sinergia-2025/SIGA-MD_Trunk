Public Class ProduccionProductosComp
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProduccionProductosComp_I(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String,
                                        idDeposito As Integer, idUbicacion As Integer,
                                        idProductoElaborado As String, idUnicoNodoProductoElaborado As String,
                                        idProductoComponente As String, idUnicoNodoProductoComponente As String,
                                        idFormula As Integer, secuenciaFormula As Integer,
                                        nombreProductoElaborado As String, nombreProductoComponente As String, nombreFormula As String,
                                        cantidad As Decimal, cantidadEnFormula As Decimal,
                                        precioCosto As Decimal, precioVenta As Decimal, importeCosto As Decimal, importeVenta As Decimal,
                                        segunCalculoForma As Boolean, formulaCalculoKilaje As String,
                                        idMoneda As Integer) '', idLote As String)
      Dim qry = New StringBuilder()
      With qry
         .AppendFormatLine("INSERT INTO ProduccionProductosComponentes (")
         .AppendFormatLine("            IdSucursal")
         .AppendFormatLine("          , IdProduccion")
         .AppendFormatLine("          , Orden")
         .AppendFormatLine("          , IdProducto")
         .AppendFormatLine("          , IdDeposito")
         .AppendFormatLine("          , IdUbicacion")

         .AppendFormatLine("          , IdProductoElaborado")
         .AppendFormatLine("          , IdUnicoNodoProductoElaborado")
         .AppendFormatLine("          , IdProductoComponente")
         .AppendFormatLine("          , IdUnicoNodoProductoComponente")

         .AppendFormatLine("          , IdFormula")
         .AppendFormatLine("          , SecuenciaFormula")
         .AppendFormatLine("          , NombreProductoElaborado")
         .AppendFormatLine("          , NombreProductoComponente")
         .AppendFormatLine("          , NombreFormula")

         .AppendFormatLine("          , Cantidad")
         .AppendFormatLine("          , CantidadEnFormula")

         .AppendFormatLine("          , PrecioCosto")
         .AppendFormatLine("          , PrecioVenta")
         .AppendFormatLine("          , ImporteCosto")
         .AppendFormatLine("          , ImporteVenta")

         .AppendFormatLine("          , SegunCalculoForma")
         .AppendFormatLine("          , FormulaCalculoKilaje")

         .AppendFormatLine("          , IdMoneda")
         '.AppendFormatLine("          , IdLote")
         .AppendFormatLine(")     VALUES(")
         .AppendFormatLine("             {0} ", idSucursal)
         .AppendFormatLine("          ,  {0} ", idProduccion)
         .AppendFormatLine("          ,  {0} ", orden)
         .AppendFormatLine("          , '{0}'", idProducto)

         .AppendFormatLine("          ,  {0} ", idDeposito)
         .AppendFormatLine("          ,  {0} ", idUbicacion)

         .AppendFormatLine("          , '{0}'", idProductoElaborado)
         .AppendFormatLine("          , '{0}'", idUnicoNodoProductoElaborado)
         .AppendFormatLine("          , '{0}'", idProductoComponente)
         .AppendFormatLine("          , '{0}'", idUnicoNodoProductoComponente)

         .AppendFormatLine("          ,  {0} ", idFormula)

         If secuenciaFormula = 0 Then
            .AppendFormatLine("          , ISNULL((SELECT MAX(SecuenciaFormula) FROM ProduccionProductosComponentes PPC1")
            .AppendFormatLine("            WHERE PPC1.IdSucursal = {0} AND PPC1.IdProduccion = {1} AND PPC1.Orden = {2} AND PPC1.IdProducto = '{3}' AND PPC1.IdProductoComponente = '{4}'), 0) + 1",
                              idSucursal, idProduccion, orden, idProducto, idProductoComponente)
         Else
            .AppendFormatLine("          ,  {0} ", secuenciaFormula)
         End If

         .AppendFormatLine("          , '{0}'", nombreProductoElaborado)
         .AppendFormatLine("          , '{0}'", nombreProductoComponente)
         .AppendFormatLine("          , '{0}'", nombreFormula)

         .AppendFormatLine("          ,  {0} ", cantidad)
         .AppendFormatLine("          ,  {0} ", cantidadEnFormula)

         .AppendFormatLine("          ,  {0} ", precioCosto)
         .AppendFormatLine("          ,  {0} ", precioVenta)
         .AppendFormatLine("          ,  {0} ", importeCosto)
         .AppendFormatLine("          ,  {0} ", importeVenta)

         .AppendFormatLine("          ,  {0} ", GetStringFromBoolean(segunCalculoForma))
         .AppendFormatLine("          , '{0}'", formulaCalculoKilaje)

         .AppendFormatLine("          ,  {0} ", idMoneda)
         '.AppendFormatLine("          ,  {0} ", GetStringParaQueryConComillas(idLote))
         .AppendFormatLine(")")
      End With
      Execute(qry)
      Sincroniza_I(qry.ToString(), "ProduccionProductosComponentes")
   End Sub

   Public Function ProduccionProductosComponentes_GA(idSucursal As Integer, idproduccion As Integer, orden As Integer, idProducto As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT PPC.*")
         .AppendFormatLine("     , P.IdDepositoDefecto")
         .AppendFormatLine("     , P.IdUbicacionDefecto")
         .AppendFormatLine("  FROM ProduccionProductosComponentes PPC")
         .AppendFormatLine(" INNER JOIN ProductosSucursales P ON P.IdProducto = PPC.IdProducto AND P.IdSucursal = PPC.IdSucursal")
         .AppendFormatLine(" WHERE PPC.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND PPC.IdProduccion = {0}", idproduccion)
         .AppendFormatLine("   AND PPC.Orden = {0}", orden)
         .AppendFormatLine("   AND PPC.IdProducto = '{0}'", idProducto)
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetSecuenciaMaxima(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String, idProductoComponente As String) As Integer
      Return GetCodigoMaximo("SecuenciaFormula", "ProduccionProductosComponentes", String.Format("IdProduccion = {1} AND Orden = {2} AND IdProducto = '{3}' AND IdProductoComponente = '{4}'",
                                                                                                 idSucursal, idProduccion, orden, idProducto, idProductoComponente)).ToInteger()
   End Function

End Class