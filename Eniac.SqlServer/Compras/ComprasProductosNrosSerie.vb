Public Class ComprasProductosNrosSerie
      Inherits Comunes

      Public Sub New(ByVal da As Eniac.Datos.DataAccess)
         MyBase.New(da)
      End Sub

   Public Sub ComprasProductosNrosSerie_I(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Integer,
                                         numeroComprobante As Long,
                                         orden As Integer,
                                         idProveedor As Long,
                                         idProducto As String,
                                         nroSerie As String)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("INSERT INTO ComprasProductosNrosSerie(")
         .AppendFormatLine("	IdSucursal,")
         .AppendFormatLine("	IdTipoComprobante,")
         .AppendFormatLine("	Letra,")
         .AppendFormatLine("	CentroEmisor,")
         .AppendFormatLine("	NumeroComprobante,")
         .AppendFormatLine("	Orden,")
         .AppendFormatLine("	IdProveedor,")
         .AppendFormatLine("	IdProducto,")
         .AppendFormatLine("	NroSerie")
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine(" {0}", idSucursal)
         .AppendFormatLine(" ,'{0}'", idTipoComprobante)
         .AppendFormatLine(" ,'{0}'", letra)
         .AppendFormatLine(" ,{0}", centroEmisor)
         .AppendFormatLine(" ,{0}", numeroComprobante)
         .AppendFormatLine(" ,{0}", orden)
         .AppendFormatLine(" ,{0}", idProveedor)
         .AppendFormatLine(" ,'{0}'", idProducto)
         .AppendFormatLine(" ,'{0}'", nroSerie)
         .AppendFormatLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ComprasProductosNrosSerie_U(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Integer,
                                         numeroComprobante As Long,
                                         orden As Integer,
                                         idProveedor As Long,
                                         idProducto As String,
                                         nroSerie As String)

      '##############################################################################################
      '# Al ser una tabla compuesta solo de PK no se podría actualizar ningún campo por el momento. #
      '##############################################################################################

      'Dim query As StringBuilder = New StringBuilder
      'With query
      '   .AppendFormatLine("UPDATE ComprasProductosNrosSerie SET")
      '   .AppendFormatLine("  WHERE ")
      '   .AppendFormatLine("     {0} = {1} ", Entidades.CompraProductoNroSerie.Columnas.IdSucursal.ToString(), idSucursal)
      '   .AppendFormatLine("     ,{0} = '{1}' ", Entidades.CompraProductoNroSerie.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
      '   .AppendFormatLine("     ,{0} = '{1}' ", Entidades.CompraProductoNroSerie.Columnas.Letra.ToString(), letra)
      '   .AppendFormatLine("     ,{0} = {1} ", Entidades.CompraProductoNroSerie.Columnas.CentroEmisor.ToString(), centroEmisor)
      '   .AppendFormatLine("     ,{0} = {1} ", Entidades.CompraProductoNroSerie.Columnas.NumeroComprobante.ToString(), numeroComprobante)
      '   .AppendFormatLine("     ,{0} = {1} ", Entidades.CompraProductoNroSerie.Columnas.Orden.ToString(), orden)
      '   .AppendFormatLine("     ,{0} = '{1}' ", Entidades.CompraProductoNroSerie.Columnas.IdProducto.ToString(), idProducto)
      'End With

      'Me.Execute(query.ToString())
   End Sub

   Public Sub ComprasProductosNrosSerie_D(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Integer,
                                         numeroComprobante As Long,
                                         orden As Integer,
                                         idProveedor As Long,
                                         idProducto As String)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE ComprasProductosNrosSerie")
         .AppendFormatLine("  WHERE  {0} = {1} ", Entidades.CompraProductoNroSerie.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("     AND {0} = '{1}' ", Entidades.CompraProductoNroSerie.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("     AND {0} = '{1}' ", Entidades.CompraProductoNroSerie.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("     AND {0} = {1} ", Entidades.CompraProductoNroSerie.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("     AND {0} = {1} ", Entidades.CompraProductoNroSerie.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         .AppendFormatLine("     AND {0} = {1} ", Entidades.CompraProductoNroSerie.Columnas.IdProveedor.ToString(), idProveedor)

         If orden > 0 Then
            .AppendFormatLine("     AND {0} = {1} ", Entidades.CompraProductoNroSerie.Columnas.Orden.ToString(), orden)
         End If
         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("     AND {0} = '{1}' ", Entidades.CompraProductoNroSerie.Columnas.IdProducto.ToString(), idProducto)
         End If

      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function ComprasProductosNrosSerie_GA() As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ComprasProductosNrosSerie_G1(idSucursal As Integer,
                                          idTipoComprobante As String,
                                          letra As String,
                                          centroEmisor As Integer,
                                          numeroComprobante As Long,
                                          orden As Integer?,
                                          idProveedor As Long,
                                          idProducto As String,
                                          nroSerie As String) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormatLine("  WHERE ")
         .AppendFormatLine("         CPNS.{0} = {1} ", Entidades.CompraProductoNroSerie.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("     AND CPNS.{0} = '{1}' ", Entidades.CompraProductoNroSerie.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("     AND CPNS.{0} = '{1}' ", Entidades.CompraProductoNroSerie.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("     AND CPNS.{0} = {1} ", Entidades.CompraProductoNroSerie.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("     AND CPNS.{0} = {1} ", Entidades.CompraProductoNroSerie.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         .AppendFormatLine("     AND CPNS.{0} = '{1}' ", Entidades.CompraProductoNroSerie.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("     AND CPNS.{0} = {1} ", Entidades.CompraProductoNroSerie.Columnas.IdProveedor.ToString(), idProveedor)
         If Not String.IsNullOrEmpty(nroSerie) Then
            .AppendFormatLine("     AND {0} = '{1}' ", Entidades.CompraProductoNroSerie.Columnas.NroSerie.ToString(), nroSerie)
         End If
         If orden.HasValue Then
            .AppendFormatLine("     AND CPNS.{0} = {1} ", Entidades.CompraProductoNroSerie.Columnas.Orden.ToString(), orden)
         End If
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function GetTodosPorComprobante(idSucursal As Integer,
                                              idTipoComprobante As String,
                                              letra As String,
                                              centroEmisor As Integer,
                                              numeroComprobante As Long,
                                              orden As Integer?,
                                              idProveedor As Long,
                                              idProducto As String) As DataTable
      Return Me.ComprasProductosNrosSerie_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden, idProveedor, idProducto, nroSerie:=Nothing)
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT")
         .AppendFormatLine("	 CPNS.IdSucursal")
         .AppendFormatLine("	,CPNS.IdTipoComprobante")
         .AppendFormatLine("	,CPNS.Letra")
         .AppendFormatLine("	,CPNS.CentroEmisor")
         .AppendFormatLine("	,CPNS.NumeroComprobante")
         .AppendFormatLine("	,CPNS.Orden")
         .AppendFormatLine("	,CPNS.IdProveedor")
         .AppendFormatLine("	,CPNS.IdProducto")
         .AppendFormatLine("	,CPNS.NroSerie")
         .AppendFormatLine("FROM ComprasProductosNrosSerie CPNS")
      End With
   End Sub

   Public Function GetProductosNrosSerieADevolver(idProducto As String, idProveedor As Long) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT CPNS.* FROM ComprasProductosNrosSerie CPNS ")
         .AppendFormatLine(" INNER JOIN ComprasProductos CP ON CPNS.IdSucursal = CP.IdSucursal")
         .AppendFormatLine("							   AND CPNS.IdTipoComprobante = CP.IdTipoComprobante")
         .AppendFormatLine("							   AND CPNS.Letra = CP.Letra")
         .AppendFormatLine("							   AND CPNS.CentroEmisor = CP.CentroEmisor")
         .AppendFormatLine("							   AND CPNS.NumeroComprobante = CP.NumeroComprobante")
         .AppendFormatLine("							   AND CPNS.IdProveedor = CP.IdProveedor")
         .AppendFormatLine("							   AND CPNS.Orden = CP.Orden")
         .AppendFormatLine("							   AND CPNS.IdProducto = CP.IdProducto")
         .AppendFormatLine(" INNER JOIN Compras C ON CP.IdSucursal = C.IdSucursal")
         .AppendFormatLine("                     AND CP.IdTipoComprobante = C.IdTipoComprobante")
         .AppendFormatLine("					 AND CP.Letra = C.Letra")
         .AppendFormatLine("					 AND CP.CentroEmisor = C.CentroEmisor")
         .AppendFormatLine("					 AND CP.NumeroComprobante = C.NumeroComprobante")
         .AppendFormatLine("					 AND CP.IdProveedor = C.IdProveedor")
         .AppendFormatLine(" INNER JOIN ProductosNrosSerie P ON CPNS.IdSucursal = P.IdSucursal")
         .AppendFormatLine("								 AND CPNS.IdProducto = P.IdProducto")
         .AppendFormatLine("								 AND CPNS.NroSerie = P.NroSerie")
         .AppendFormatLine("WHERE CPNS.IdProveedor = {0}", idProveedor)
         .AppendFormatLine("  AND CPNS.IdProducto = '{0}'", idProducto)
         .AppendFormatLine("  AND P.Vendido = 'False'")
      End With
      Return Me.GetDataTable(query.ToString())
   End Function
End Class

