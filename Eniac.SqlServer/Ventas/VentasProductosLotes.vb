Public Class VentasProductosLotes
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasProductosLotes_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                     idProducto As String, idLote As String,
                                     idDeposito As Integer, idUbicacion As Integer,
                                     fechaVencimiento As Date?, cantidad As Decimal, orden As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO VentasProductosLotes (")
         .AppendFormatLine("       IdSucursal")
         .AppendFormatLine("     , IdTipoComprobante")
         .AppendFormatLine("     , Letra")
         .AppendFormatLine("     , CentroEmisor")
         .AppendFormatLine("     , NumeroComprobante")
         .AppendFormatLine("     , IdProducto")
         .AppendFormatLine("     , IdLote")
         .AppendFormatLine("     , FechaVencimiento")
         .AppendFormatLine("     , Cantidad")
         .AppendFormatLine("     , Orden")
         .AppendFormatLine("     , IdDeposito")
         .AppendFormatLine("     , IdUbicacion")
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("        {0} ", idSucursal)
         .AppendFormatLine("     , '{0}'", idTipoComprobante)
         .AppendFormatLine("     , '{0}'", letra)
         .AppendFormatLine("     ,  {0} ", centroEmisor)
         .AppendFormatLine("     ,  {0} ", numeroComprobante)
         .AppendFormatLine("     , '{0}'", idProducto)
         .AppendFormatLine("     , '{0}'", idLote)
         .AppendFormatLine("     ,  {0} ", ObtenerFecha(fechaVencimiento, True))
         .AppendFormatLine("     ,  {0} ", cantidad)
         .AppendFormatLine("     ,  {0} ", orden)
         .AppendFormatLine("     ,  {0} ", idDeposito)
         .AppendFormatLine("     ,  {0} ", idUbicacion)
         .AppendFormatLine(" )")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasProductosLotes")
   End Sub
   Public Sub VentasProductosLotes_U(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                     idProducto As String, idLote As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE VentasProductosLotes")
         .AppendFormatLine("   SET IdLote = '{0}'", idLote)
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasProductosLotes")
   End Sub
   Public Sub VentasProductosLotes_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                     idProducto As String, idLote As String, orden As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM VentasProductosLotes")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND IdProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND IdLote = '{0}'", idLote)
         .AppendFormatLine("   AND Orden = {0}", orden)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasProductosLotes")
   End Sub

   Public Sub VentasProductosLotes_D2(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM VentasProductosLotes ")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasProductosLotes")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT VPL.*")
         .AppendFormatLine("		, P.NombreProducto")
         .AppendFormatLine("  FROM VentasProductosLotes VPL ")
         .AppendFormatLine("  LEFT JOIN Productos P ON P.IdProducto = VPL.IdProducto")
      End With
   End Sub

   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                        orden As Integer, idLote As String, idProducto As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE VPL.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND VPL.idTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND VPL.Letra = '{0}'", letra)
         .AppendFormatLine("   AND VPL.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND VPL.NumeroComprobante = {0}", numeroComprobante)
         If orden > 0 Then
            .AppendFormatLine("   AND VPL.Orden = {0}", orden)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND VPL.IdProducto = '{0}'", idProducto)
         End If
         If Not String.IsNullOrWhiteSpace(idLote) Then
            .AppendFormatLine("   AND VPL.IdLote = '{0}'", idLote)
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetAll(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          idProducto As String, orden As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1=1")
         If idSucursal > 0 Then .AppendFormatLine("   AND VPL.IdSucursal = {0}", idSucursal)
         If Not String.IsNullOrEmpty(idTipoComprobante) Then .AppendFormatLine("   AND VPL.IdTipoComprobante = '{0}'", idTipoComprobante)
         If Not String.IsNullOrEmpty(letra) Then .AppendFormatLine("   AND VPL.Letra = '{0}'", letra)
         If centroEmisor > 0 Then .AppendFormatLine("   AND VPL.CentroEmisor = {0}", centroEmisor)
         If numeroComprobante > 0 Then .AppendFormatLine("   AND VPL.NumeroComprobante = {0}", numeroComprobante)
         If Not String.IsNullOrEmpty(idProducto) Then .AppendFormatLine("   AND VPL.IdProducto = '{0}'", idProducto)
         If orden > 0 Then .AppendFormatLine("   AND VPL.Orden = {0}", orden)
      End With
      Return GetDataTable(stb)
   End Function
End Class