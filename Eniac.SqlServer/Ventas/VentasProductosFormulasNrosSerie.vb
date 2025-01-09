Public Class VentasProductosFormulasNrosSerie
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasProductosFormulasNrosSerie_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                                 idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer,
                                                 nroSerie As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.VentaProductoFormulaNroSerie.NombreTabla)
         .AppendFormatLine("            {0}", Entidades.VentaProductoFormulaNroSerie.Columnas.IdSucursal.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaNroSerie.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaNroSerie.Columnas.Letra.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaNroSerie.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaNroSerie.Columnas.NumeroComprobante.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaNroSerie.Columnas.IdProducto.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaNroSerie.Columnas.Orden.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaNroSerie.Columnas.IdProductoComponente.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaNroSerie.Columnas.IdFormula.ToString())
         .AppendFormatLine("           ,{0}", Entidades.VentaProductoFormulaNroSerie.Columnas.NroSerie.ToString())
         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("             {0} ", idSucursal)
         .AppendFormatLine("           ,'{0}'", idTipoComprobante)
         .AppendFormatLine("           ,'{0}'", letra)
         .AppendFormatLine("           , {0} ", centroEmisor)
         .AppendFormatLine("           , {0} ", numeroComprobante)
         .AppendFormatLine("           ,'{0}'", idProducto)
         .AppendFormatLine("           , {0} ", orden)
         .AppendFormatLine("           ,'{0}'", idProductoComponente)
         .AppendFormatLine("           , {0} ", idFormula)
         .AppendFormatLine("           ,'{0}'", nroSerie)
         .AppendFormatLine("           )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub VentasProductosFormulasNrosSerie_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                                 idProducto As String, orden As Integer?, idProductoComponente As String, idFormula As Integer, nroSerie As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.VentaProductoFormulaNroSerie.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.VentaProductoFormulaNroSerie.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaProductoFormulaNroSerie.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaProductoFormulaNroSerie.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.VentaProductoFormulaNroSerie.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.VentaProductoFormulaNroSerie.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaProductoFormulaNroSerie.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden.HasValue Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.VentaProductoFormulaNroSerie.Columnas.Orden.ToString(), orden.Value)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoComponente) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.VentaProductoFormulaNroSerie.Columnas.IdProductoComponente.ToString(), idProductoComponente)
         End If
         If idFormula <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.VentaProductoFormulaNroSerie.Columnas.IdFormula.ToString(), idFormula)
         End If
         If Not String.IsNullOrWhiteSpace(nroSerie) Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.VentaProductoFormulaNroSerie.Columnas.NroSerie.ToString(), nroSerie)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT VPFS.*")
         .AppendFormatLine("  FROM {0} AS VPFS", Entidades.VentaProductoFormulaNroSerie.NombreTabla)
      End With
   End Sub

   Public Function VentasProductosFormulasNrosSerie_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                                       idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer) As DataTable
      Return VentasProductosFormulasNrosSerie_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                idProducto, orden, idProductoComponente, idFormula, nroSerie:=String.Empty)
   End Function
   Private Function VentasProductosFormulasNrosSerie_G(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                                       idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer, nroSerie As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormatLine("   AND VPFS.{0} = {1}", Entidades.VentaProductoFormulaNroSerie.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND VPFS.{0} = '{1}'", Entidades.VentaProductoFormulaNroSerie.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND VPFS.{0} = '{1}'", Entidades.VentaProductoFormulaNroSerie.Columnas.Letra.ToString(), letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("   AND VPFS.{0} = {1}", Entidades.VentaProductoFormulaNroSerie.Columnas.CentroEmisor.ToString(), centroEmisor)
         End If
         If numeroComprobante > 0 Then
            .AppendFormatLine("   AND VPFS.{0} = {1}", Entidades.VentaProductoFormulaNroSerie.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND VPFS.{0} = '{1}'", Entidades.VentaProductoFormulaNroSerie.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden > 0 Then
            .AppendFormatLine("   AND VPFS.{0} = {1}", Entidades.VentaProductoFormulaNroSerie.Columnas.Orden.ToString(), orden)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoComponente) Then
            .AppendFormatLine("   AND VPFS.{0} = '{1}'", Entidades.VentaProductoFormulaNroSerie.Columnas.IdProductoComponente.ToString(), idProductoComponente)
         End If
         If idFormula > 0 Then
            .AppendFormatLine("   AND VPFS.{0} = {1}", Entidades.VentaProductoFormulaNroSerie.Columnas.IdFormula.ToString(), idFormula)
         End If
         If Not String.IsNullOrWhiteSpace(nroSerie) Then
            .AppendFormatLine("   AND VPFS.{0} = '{1}'", Entidades.VentaProductoFormulaNroSerie.Columnas.NroSerie.ToString(), nroSerie)
         End If

      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function VentasProductosFormulasNrosSerie_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                                   idProducto As String, orden As Integer, idProductoComponente As String, idFormula As Integer, nroSerie As String) As DataTable
      Return VentasProductosFormulasNrosSerie_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                idProducto, orden, idProductoComponente, idFormula, nroSerie)
   End Function

End Class