Public Class VentasProductosNrosSerie
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasProductosNrosSerie_I(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Integer,
                                         numeroComprobante As Long,
                                         orden As Integer,
                                         idProducto As String,
                                         nroSerie As String)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("INSERT INTO VentasProductosNrosSerie(")
         .AppendFormatLine("	IdSucursal,")
         .AppendFormatLine("	IdTipoComprobante,")
         .AppendFormatLine("	Letra,")
         .AppendFormatLine("	CentroEmisor,")
         .AppendFormatLine("	NumeroComprobante,")
         .AppendFormatLine("	Orden,")
         .AppendFormatLine("	IdProducto,")
         .AppendFormatLine("	NroSerie")
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine(" {0}", idSucursal)
         .AppendFormatLine(" ,'{0}'", idTipoComprobante)
         .AppendFormatLine(" ,'{0}'", letra)
         .AppendFormatLine(" ,{0}", centroEmisor)
         .AppendFormatLine(" ,{0}", numeroComprobante)
         .AppendFormatLine(" ,{0}", orden)
         .AppendFormatLine(" ,'{0}'", idProducto)
         .AppendFormatLine(" ,'{0}'", nroSerie)
         .AppendFormatLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub VentasProductosNrosSerie_U(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Integer,
                                         numeroComprobante As Long,
                                         orden As Integer,
                                         idProducto As String,
                                         nroSerie As String)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE VentasProductosNrosSerie SET")
         .AppendFormatLine("	   NroSerie = '{0}'", nroSerie)
         .AppendFormatLine("  WHERE ")
         .AppendFormatLine("     {0} = {1} ", Entidades.VentaProductoNroSerie.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("     ,{0} = '{1}' ", Entidades.VentaProductoNroSerie.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("     ,{0} = '{1}' ", Entidades.VentaProductoNroSerie.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("     ,{0} = {1} ", Entidades.VentaProductoNroSerie.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("     ,{0} = {1} ", Entidades.VentaProductoNroSerie.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         .AppendFormatLine("     ,{0} = {1} ", Entidades.VentaProductoNroSerie.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("     ,{0} = '{1}' ", Entidades.VentaProductoNroSerie.Columnas.IdProducto.ToString(), idProducto)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub VentasProductosNrosSerie_D(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Integer,
                                         numeroComprobante As Long)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE VentasProductosNrosSerie")
         .AppendFormatLine("  WHERE ")
         .AppendFormatLine("     {0} = {1} ", Entidades.VentaProductoNroSerie.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("     AND {0} = '{1}' ", Entidades.VentaProductoNroSerie.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("     AND {0} = '{1}' ", Entidades.VentaProductoNroSerie.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("     AND {0} = {1} ", Entidades.VentaProductoNroSerie.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("     AND {0} = {1} ", Entidades.VentaProductoNroSerie.Columnas.NumeroComprobante.ToString(), numeroComprobante)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function VentasProductosNrosSerie_GA() As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function VentasProductosNrosSerie_G1(idSucursal As Integer,
                                          idTipoComprobante As String,
                                          letra As String,
                                          centroEmisor As Integer,
                                          numeroComprobante As Long,
                                          orden As Integer,
                                          idProducto As String,
                                          nroSerie As String) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormatLine("  WHERE ")
         .AppendFormatLine("     {0} = {1} ", Entidades.VentaProductoNroSerie.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("     AND {0} = '{1}' ", Entidades.VentaProductoNroSerie.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("     AND {0} = '{1}' ", Entidades.VentaProductoNroSerie.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("     AND {0} = {1} ", Entidades.VentaProductoNroSerie.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("     AND {0} = {1} ", Entidades.VentaProductoNroSerie.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         .AppendFormatLine("     AND {0} = {1} ", Entidades.VentaProductoNroSerie.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("     AND {0} = '{1}' ", Entidades.VentaProductoNroSerie.Columnas.IdProducto.ToString(), idProducto)

         If Not String.IsNullOrEmpty(nroSerie) Then
            .AppendFormatLine("     AND {0} = '{1}' ", Entidades.VentaProductoNroSerie.Columnas.NroSerie.ToString(), nroSerie)
         End If
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function GetTodosPorComprobante(idSucursal As Integer,
                                              idTipoComprobante As String,
                                              letra As String,
                                              centroEmisor As Integer,
                                              numeroComprobante As Long,
                                              orden As Integer,
                                              idProducto As String) As DataTable
      Return Me.VentasProductosNrosSerie_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden, idProducto, nroSerie:=Nothing)
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT")
         .AppendFormatLine("	IdSucursal")
         .AppendFormatLine("	,IdTipoComprobante")
         .AppendFormatLine("	,Letra")
         .AppendFormatLine("	,CentroEmisor")
         .AppendFormatLine("	,NumeroComprobante")
         .AppendFormatLine("	,Orden")
         .AppendFormatLine("	,IdProducto")
         .AppendFormatLine("	,NroSerie")
         .AppendFormatLine("FROM VentasProductosNrosSerie")
      End With
   End Sub

End Class
