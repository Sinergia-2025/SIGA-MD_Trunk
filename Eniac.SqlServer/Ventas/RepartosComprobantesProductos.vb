Public Class RepartosComprobantesProductos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#Region "Insert/Update/Merge/Delete"
   Public Sub RepartosComprobantesProductos_I(idSucursal As Integer,
                                              idReparto As Integer,
                                              orden As Integer,
                                              idProducto As String,
                                              ordenProducto As Integer,
                                              nombreProducto As String,
                                              cantidad As Decimal,
                                              cantidadCambio As Decimal,
                                              precio As Decimal,
                                              precioConImp As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO  {0}  (", Entidades.RepartoComprobanteProducto.NombreTabla)
         .AppendFormatLine("             {0} ", Entidades.RepartoComprobanteProducto.Columnas.IdSucursal.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobanteProducto.Columnas.IdReparto.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobanteProducto.Columnas.Orden.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobanteProducto.Columnas.IdProducto.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobanteProducto.Columnas.OrdenProducto.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobanteProducto.Columnas.NombreProducto.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobanteProducto.Columnas.Cantidad.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobanteProducto.Columnas.CantidadCambio.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobanteProducto.Columnas.Precio.ToString())
         .AppendFormatLine("           , {0} ", Entidades.RepartoComprobanteProducto.Columnas.PrecioConImp.ToString())
         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("             {0} ", idSucursal)
         .AppendFormatLine("           , {0} ", idReparto)
         .AppendFormatLine("           , {0} ", orden)
         .AppendFormatLine("           ,'{0}'", idProducto)
         .AppendFormatLine("           , {0} ", ordenProducto)
         .AppendFormatLine("           ,'{0}'", nombreProducto)
         .AppendFormatLine("           , {0} ", cantidad)
         .AppendFormatLine("           , {0} ", cantidadCambio)
         .AppendFormatLine("           , {0} ", precio)
         .AppendFormatLine("           , {0} ", precioConImp)

         .AppendFormatLine("           )")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosComprobantesProductos_U(idSucursal As Integer,
                                              idReparto As Integer,
                                              orden As Integer,
                                              idProducto As String,
                                              ordenProducto As Integer,
                                              nombreProducto As String,
                                              cantidad As Decimal,
                                              cantidadCambio As Decimal,
                                              precio As Decimal,
                                              precioConImp As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.RepartoComprobanteProducto.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.RepartoComprobanteProducto.Columnas.NombreProducto.ToString(), nombreProducto)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.Cantidad.ToString(), cantidad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.CantidadCambio.ToString(), cantidadCambio)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.Precio.ToString(), precio)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.PrecioConImp.ToString(), precioConImp)

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoComprobanteProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.OrdenProducto.ToString(), ordenProducto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosComprobantesProductos_D(idSucursal As Integer,
                                              idReparto As Integer,
                                              orden As Integer,
                                              idProducto As String,
                                              ordenProducto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.RepartoComprobanteProducto.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.IdReparto.ToString(), idReparto)
         If orden <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.Orden.ToString(), orden)
         End If
         If orden <> 0 Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoComprobanteProducto.Columnas.IdProducto.ToString(), idProducto)
         End If
         If ordenProducto <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.OrdenProducto.ToString(), ordenProducto)
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub
#End Region

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RCP.*")
         .AppendFormatLine("  FROM {0} AS RCP", Entidades.RepartoComprobanteProducto.NombreTabla)
      End With
   End Sub

#Region "GetAll"
   Public Function RepartosComprobantesProductos_GA(idSucursal As Integer) As DataTable
      Return RepartosComprobantesProductos_G(idSucursal, idReparto:=0, orden:=0, idProducto:=String.Empty, ordenProducto:=0)
   End Function
   Public Function RepartosComprobantesProductos_GA(idSucursal As Integer, idReparto As Integer, orden As Integer) As DataTable
      Return RepartosComprobantesProductos_G(idSucursal, idReparto, orden, idProducto:=String.Empty, ordenProducto:=0)
   End Function
   Private Function RepartosComprobantesProductos_G(idSucursal As Integer,
                                                    idReparto As Integer,
                                                    orden As Integer,
                                                    idProducto As String,
                                                    ordenProducto As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal <> 0 Then
            .AppendFormatLine("   AND RCP.{0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If idReparto <> 0 Then
            .AppendFormatLine("   AND  RCP.{0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.IdReparto.ToString(), idReparto)
         End If
         If orden <> 0 Then
            .AppendFormatLine("   AND  RCP.{0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.Orden.ToString(), orden)
         End If
         If orden <> 0 Then
            .AppendFormatLine("   AND  RCP.{0} = '{1}'", Entidades.RepartoComprobanteProducto.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden <> 0 Then
            .AppendFormatLine("   AND  RCP.{0} =  {1} ", Entidades.RepartoComprobanteProducto.Columnas.OrdenProducto.ToString(), ordenProducto)
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function RepartosComprobantesProductos_G1(idSucursal As Integer,
                                                    idReparto As Integer,
                                                    orden As Integer,
                                                    idProducto As String,
                                                    ordenProducto As Integer) As DataTable
      Return RepartosComprobantesProductos_G(idSucursal, idReparto, orden, idProducto, ordenProducto)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      'If columna = "CategoriaParametro" Or columna = "DescripcionParametro" Then
      '   columna = "P." + columna
      'ElseIf columna = "ValorParametroOriginal" Then
      '   columna = "P.ValorParametro"
      'Else
      columna = "RCP." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
#End Region

   Public Overloads Function GetCodigoMaximo(idSucursal As Integer, idReparto As Integer, orden As Integer) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.RepartoComprobanteProducto.Columnas.OrdenProducto.ToString(),
                                             Entidades.RepartoComprobanteProducto.NombreTabla,
                                             String.Format("{0} = {1} AND {2} = {3} AND {4} = {5}",
                                                           Entidades.RepartoComprobanteProducto.Columnas.IdSucursal.ToString(), idSucursal,
                                                           Entidades.RepartoComprobanteProducto.Columnas.IdReparto.ToString(), idReparto,
                                                           Entidades.RepartoComprobanteProducto.Columnas.Orden.ToString(), orden)))
   End Function

End Class