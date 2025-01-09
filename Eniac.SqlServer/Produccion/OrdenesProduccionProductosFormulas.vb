Public Class OrdenesProduccionProductosFormulas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub OrdenesProduccionProductosFormulas_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                                   idProducto As String, orden As Integer,
                                                   idProductoElaborado As String, idUnicoNodoProductoElaborado As String,
                                                   idProductoComponente As String, idUnicoNodoProductoComponente As String,
                                                   idFormula As Integer, secuenciaFormula As Integer,
                                                   nombreProductoElaborado As String, nombreProductoComponente As String,
                                                   nombreFormula As String,
                                                   precioCosto As Decimal, precioVenta As Decimal,
                                                   cantidad As Decimal, cantidadEnFormula As Decimal,
                                                   segunCalculoForma As Boolean,
                                                   importeCosto As Decimal, importeVenta As Decimal,
                                                   formulaCalculoKilaje As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.OrdenProduccionProductoFormula.NombreTabla)
         .AppendFormatLine("            {0}", Entidades.OrdenProduccionProductoFormula.Columnas.IdSucursal.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.Letra.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.NumeroOrdenProduccion.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.IdProducto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.Orden.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.IdProductoElaborado.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.IdUnicoNodoProductoElaborado.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.IdProductoComponente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.IdUnicoNodoProductoComponente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.IdFormula.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.SecuenciaFormula.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.NombreProductoElaborado.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.NombreProductoComponente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.NombreFormula.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.PrecioCosto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.PrecioVenta.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.Cantidad.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.CantidadEnFormula.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.SegunCalculoForma.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.ImporteCosto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.ImporteVenta.ToString())
         .AppendFormatLine("           ,{0}", Entidades.OrdenProduccionProductoFormula.Columnas.FormulaCalculoKilaje.ToString())

         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("             {0} ", idSucursal)
         .AppendFormatLine("           ,'{0}'", idTipoComprobante)
         .AppendFormatLine("           ,'{0}'", letra)
         .AppendFormatLine("           , {0} ", centroEmisor)
         .AppendFormatLine("           , {0} ", numeroOrdenProduccion)
         .AppendFormatLine("           ,'{0}'", idProducto)
         .AppendFormatLine("           , {0} ", orden)
         .AppendFormatLine("           ,'{0}'", idProductoElaborado)
         .AppendFormatLine("           ,'{0}'", idUnicoNodoProductoElaborado)
         .AppendFormatLine("           ,'{0}'", idProductoComponente)
         .AppendFormatLine("           ,'{0}'", idUnicoNodoProductoComponente)
         .AppendFormatLine("           , {0} ", idFormula)
         .AppendFormatLine("           , {0} ", secuenciaFormula)
         .AppendFormatLine("           ,'{0}'", nombreProductoElaborado)
         .AppendFormatLine("           ,'{0}'", nombreProductoComponente)
         .AppendFormatLine("           ,'{0}'", nombreFormula)
         .AppendFormatLine("           , {0} ", precioCosto)
         .AppendFormatLine("           , {0} ", precioVenta)
         .AppendFormatLine("           , {0} ", cantidad)
         .AppendFormatLine("           , {0} ", cantidadEnFormula)
         .AppendFormatLine("           , {0} ", GetStringFromBoolean(segunCalculoForma))
         .AppendFormatLine("           , {0} ", importeCosto)
         .AppendFormatLine("           , {0} ", importeVenta)
         .AppendFormatLine("           ,'{0}'", formulaCalculoKilaje)
         .AppendFormatLine("           )")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub OrdenesProduccionProductosFormulas_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long)
      OrdenesProduccionProductosFormulas_D(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                           idProducto:=String.Empty, orden:=Nothing, idProductoElaborado:=String.Empty, idUnicoNodoProductoElaborado:=String.Empty,
                                           idProductoComponente:=String.Empty, idUnicoNodoProductoComponente:=String.Empty, idFormula:=0, secuenciaFormula:=0)
   End Sub
   Public Sub OrdenesProduccionProductosFormulas_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                                   idProducto As String, orden As Integer?,
                                                   idProductoElaborado As String, idUnicoNodoProductoElaborado As String,
                                                   idProductoComponente As String, idUnicoNodoProductoComponente As String,
                                                   idFormula As Integer, secuenciaFormula As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.OrdenProduccionProductoFormula.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.OrdenProduccionProductoFormula.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.OrdenProduccionProductoFormula.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.OrdenProduccionProductoFormula.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.OrdenProduccionProductoFormula.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.OrdenProduccionProductoFormula.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.OrdenProduccionProductoFormula.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden.HasValue Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.OrdenProduccionProductoFormula.Columnas.Orden.ToString(), orden.Value)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoElaborado) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.OrdenProduccionProductoFormula.Columnas.IdProductoElaborado.ToString(), idProductoElaborado)
         End If
         If Not String.IsNullOrWhiteSpace(idUnicoNodoProductoElaborado) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.OrdenProduccionProductoFormula.Columnas.IdUnicoNodoProductoElaborado.ToString(), idUnicoNodoProductoElaborado)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoComponente) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.OrdenProduccionProductoFormula.Columnas.IdProductoComponente.ToString(), idProductoComponente)
         End If
         If Not String.IsNullOrWhiteSpace(idUnicoNodoProductoComponente) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.OrdenProduccionProductoFormula.Columnas.IdUnicoNodoProductoComponente.ToString(), idUnicoNodoProductoComponente)
         End If
         If idFormula <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.OrdenProduccionProductoFormula.Columnas.IdFormula.ToString(), idFormula)
         End If
         If secuenciaFormula <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.OrdenProduccionProductoFormula.Columnas.SecuenciaFormula.ToString(), secuenciaFormula)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT PPF.*")
         .AppendFormatLine("     , PPF.PrecioVenta * PPF.Cantidad AS ImporteVenta")
         .AppendFormatLine("     , P.IdDepositoDefecto")
         .AppendFormatLine("     , P.IdUbicacionDefecto")
         .AppendFormatLine("  FROM {0} AS PPF", Entidades.OrdenProduccionProductoFormula.NombreTabla)
         .AppendFormatLine(" INNER JOIN ProductosSucursales AS P ON P.IdProducto = PPF.IdProducto AND P.IdSucursal = PPF.IdSucursal")
      End With
   End Sub

   Public Function OrdenesProduccionProductosFormulas_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                               idProducto As String, orden As Integer, soloMateriaPrima As Boolean) As DataTable
      Return OrdenesProduccionProductosFormulas_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                        idProducto, orden,
                                        idProductoElaborado:=Nothing, idUnicoNodoProductoElaborado:=Nothing,
                                        idProductoComponente:=Nothing, idUnicoNodoProductoComponente:=Nothing,
                                        idFormula:=0, secuenciaFormula:=0, soloMateriaPrima)
   End Function
   Private Function OrdenesProduccionProductosFormulas_G(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                               idProducto As String, orden As Integer,
                                               idProductoElaborado As String, idUnicoNodoProductoElaborado As String,
                                               idProductoComponente As String, idUnicoNodoProductoComponente As String,
                                               idFormula As Integer, secuenciaFormula As Integer,
                                               soloMateriaPrima As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormatLine("   AND PPF.{0} = {1}", Entidades.OrdenProduccionProductoFormula.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND PPF.{0} = '{1}'", Entidades.OrdenProduccionProductoFormula.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND PPF.{0} = '{1}'", Entidades.OrdenProduccionProductoFormula.Columnas.Letra.ToString(), letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("   AND PPF.{0} = {1}", Entidades.OrdenProduccionProductoFormula.Columnas.CentroEmisor.ToString(), centroEmisor)
         End If
         If numeroOrdenProduccion > 0 Then
            .AppendFormatLine("   AND PPF.{0} = {1}", Entidades.OrdenProduccionProductoFormula.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND PPF.{0} = '{1}'", Entidades.OrdenProduccionProductoFormula.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden > 0 Then
            .AppendFormatLine("   AND PPF.{0} = {1}", Entidades.OrdenProduccionProductoFormula.Columnas.Orden.ToString(), orden)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoElaborado) Then
            .AppendFormatLine("   AND PPF.{0} = '{1}'", Entidades.OrdenProduccionProductoFormula.Columnas.IdProductoElaborado.ToString(), idProductoElaborado)
         End If
         If Not String.IsNullOrWhiteSpace(idUnicoNodoProductoElaborado) Then
            .AppendFormatLine("   AND PPF.{0} = '{1}'", Entidades.OrdenProduccionProductoFormula.Columnas.IdUnicoNodoProductoElaborado.ToString(), idUnicoNodoProductoElaborado)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoComponente) Then
            .AppendFormatLine("   AND PPF.{0} = '{1}'", Entidades.OrdenProduccionProductoFormula.Columnas.IdProductoComponente.ToString(), idProductoComponente)
         End If
         If Not String.IsNullOrWhiteSpace(idUnicoNodoProductoComponente) Then
            .AppendFormatLine("   AND PPF.{0} = '{1}'", Entidades.OrdenProduccionProductoFormula.Columnas.IdUnicoNodoProductoComponente.ToString(), idUnicoNodoProductoComponente)
         End If
         If idFormula > 0 Then
            .AppendFormatLine("   AND PPF.{0} = {1}", Entidades.OrdenProduccionProductoFormula.Columnas.IdFormula.ToString(), idFormula)
         End If
         If secuenciaFormula > 0 Then
            .AppendFormatLine("   AND PPF.{0} = {1}", Entidades.OrdenProduccionProductoFormula.Columnas.SecuenciaFormula.ToString(), secuenciaFormula)
         End If

         If soloMateriaPrima Then
            .AppendFormatLine("   AND NOT EXISTS (SELECT 1")
            .AppendFormatLine("                     FROM OrdenesProduccionProductosFormulas PPFx")
            .AppendFormatLine("                    WHERE PPFx.IdSucursal = PPF.IdSucursal")
            .AppendFormatLine("                      AND PPFx.IdTipoComprobante = PPF.IdTipoComprobante")
            .AppendFormatLine("                      AND PPFx.Letra = PPF.Letra")
            .AppendFormatLine("                      AND PPFx.CentroEmisor = PPF.CentroEmisor")
            .AppendFormatLine("                      AND PPFx.NumeroOrdenProduccion = PPF.NumeroOrdenProduccion")

            .AppendFormatLine("                      AND PPFx.IdProducto = PPF.IdProducto")
            .AppendFormatLine("                      AND PPFx.Orden = PPF.Orden")

            .AppendFormatLine("                      AND PPFx.IdUnicoNodoProductoElaborado = PPF.IdUnicoNodoProductoComponente")
            .AppendFormatLine("                   )")
         End If

      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function OrdenesProduccionProductosFormulas_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                               idProducto As String, orden As Integer,
                                               idProductoElaborado As String, idUnicoNodoProductoElaborado As String,
                                               idProductoComponente As String, idUnicoNodoProductoComponente As String,
                                               idFormula As Integer, secuenciaFormula As Integer) As DataTable
      Return OrdenesProduccionProductosFormulas_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                        idProducto, orden,
                                        idProductoElaborado, idUnicoNodoProductoElaborado,
                                        idProductoComponente, idUnicoNodoProductoComponente,
                                        idFormula, secuenciaFormula, soloMateriaPrima:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "PPF.")
   End Function

End Class