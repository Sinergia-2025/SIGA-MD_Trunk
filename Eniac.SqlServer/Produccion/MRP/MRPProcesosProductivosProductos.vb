Imports Eniac.Entidades
Public Class MRPProcesosProductivosProductos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProcesosProductivosProductos_I(idOperacion As Integer,
                                             idProcesoProductivo As Long,
                                             IdProductoProceso As String,
                                             cantidadSolicitada As Decimal,
                                             precioCostoProducto As Decimal,
                                             esProductoNecesario As Boolean,
                                             idSucursal As Integer,
                                             idDeposito As Integer,
                                             idUbicacion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})",
                       MRPProcesoProductivoProducto.NombreTabla,
                       MRPProcesoProductivoProducto.Columnas.IdOperacion.ToString(),
                       MRPProcesoProductivoProducto.Columnas.IdProcesoProductivo.ToString(),
                       MRPProcesoProductivoProducto.Columnas.IdProductoProceso.ToString(),
                       MRPProcesoProductivoProducto.Columnas.CantidadSolicitada.ToString(),
                       MRPProcesoProductivoProducto.Columnas.PrecioCostoProducto.ToString(),
                       MRPProcesoProductivoProducto.Columnas.EsProductoNecesario.ToString(),
                       MRPProcesoProductivoProducto.Columnas.IdSucursalOrigen.ToString(),
                       MRPProcesoProductivoProducto.Columnas.IdDepositoOrigen.ToString(),
                       MRPProcesoProductivoProducto.Columnas.IdUbicacionOrigen.ToString()
                       ).AppendLine()
         .AppendFormat("  VALUES ({0}, {1}, '{2}', {3}, {4}, {5}, {6}, {7}, {8}",
                        idOperacion,
                        idProcesoProductivo,
                        IdProductoProceso,
                        cantidadSolicitada,
                        precioCostoProducto,
                        GetStringFromBoolean(esProductoNecesario),
                        IIf(idSucursal = 0, "NULL", idSucursal),
                        IIf(idDeposito = 0, "NULL", idDeposito),
                        IIf(idUbicacion = 0, "NULL", idUbicacion)
                        )
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub ProcesosProductivosProductos_U(idOperacion As Integer,
                                             idProcesoProductivo As Long,
                                             IdProductoProceso As String,
                                             CantidadSolicitada As Decimal,
                                             precioCostoProducto As Decimal,
                                             esProductoNecesario As Boolean,
                                             idSucursal As Integer,
                                             idDeposito As Integer,
                                             idUbicacion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", MRPProcesoProductivoProducto.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} =   {1}  ", MRPProcesoProductivoProducto.Columnas.CantidadSolicitada.ToString(), CantidadSolicitada).AppendLine()
         .AppendFormat("      ,{0} =   {1}  ", MRPProcesoProductivoProducto.Columnas.PrecioCostoProducto.ToString(), precioCostoProducto).AppendLine()

         .AppendFormat("      ,{0} =   {1}  ", MRPProcesoProductivoProducto.Columnas.IdSucursalOrigen.ToString(), IIf(idSucursal = 0, "NULL", idSucursal)).AppendLine()
         .AppendFormat("      ,{0} =   {1}  ", MRPProcesoProductivoProducto.Columnas.IdDepositoOrigen.ToString(), IIf(idDeposito = 0, "NULL", idDeposito)).AppendLine()
         .AppendFormat("      ,{0} =   {1}  ", MRPProcesoProductivoProducto.Columnas.IdUbicacionOrigen.ToString(), IIf(idUbicacion = 0, "NULL", idUbicacion)).AppendLine()

         .AppendFormat(" WHERE {0} =   {1}  ", MRPProcesoProductivoProducto.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo).AppendLine()
         .AppendFormat("   AND {0} =   {1}  ", MRPProcesoProductivoProducto.Columnas.IdOperacion.ToString(), idOperacion).AppendLine()
         .AppendFormat("   AND {0} =  '{1}' ", MRPProcesoProductivoProducto.Columnas.IdProductoProceso.ToString(), IdProductoProceso).AppendLine()
         .AppendFormat("   AND {0} =   {1}  ", MRPProcesoProductivoProducto.Columnas.EsProductoNecesario.ToString(), GetStringFromBoolean(esProductoNecesario)).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub ProcesosProductivosProductos_D(idOperacion As Integer,
                                             idProcesoProductivo As Long,
                                             IdProductoProceso As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} ", MRPProcesoProductivoProducto.NombreTabla)
         .AppendFormat(" WHERE {0} =  {1}  ", MRPProcesoProductivoProducto.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", MRPProcesoProductivoProducto.Columnas.IdOperacion.ToString(), idOperacion).AppendLine()
         If Not String.IsNullOrEmpty(IdProductoProceso) Then
            .AppendFormat("   AND {0} =  '{1}'  ", MRPProcesoProductivoProducto.Columnas.IdProductoProceso.ToString(), IdProductoProceso).AppendLine()
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT PPP.*, PPO.CodigoProcProdOperacion, UM.NombreUnidadDeMedida AS UnidadMedidaProd, P.NombreProducto FROM {0} AS PPP ", MRPProcesoProductivoProducto.NombreTabla).AppendLine()
         .AppendFormat("   INNER JOIN {0} AS PPO ON PPO.IdProcesoProductivo = PPP.IdProcesoProductivo AND PPO.IdOperacion = PPP.idOperacion ", MRPProcesoProductivoOperacion.NombreTabla).AppendLine()
         .AppendFormat("   INNER JOIN {0} AS P ON P.IdProducto = PPP.IdProductoProceso ", Producto.NombreTabla).AppendLine()
         .AppendFormat("   INNER JOIN {0} AS UM ON P.IdUnidadDeMedida = UM.IdUnidadDeMedida ", UnidadDeMedida.NombreTabla).AppendLine()
      End With
   End Sub


   Private Function ProcesosProductivosProductos_G(idProcesoProductivo As Long, idOperacion As Integer, esNecesario As Entidades.Publicos.SiNoTodos) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idProcesoProductivo > 0 Then
            .AppendFormat("   AND PPP.IdProcesoProductivo = {0}", idProcesoProductivo).AppendLine()
         End If
         If idOperacion > 0 Then
            .AppendFormat("   AND PPP.IdOperacion = {0}", idOperacion).AppendLine()
         End If
         If esNecesario <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("      AND PPP.EsProductoNecesario = {0}", GetStringFromBoolean(esNecesario = Entidades.Publicos.SiNoTodos.SI))
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function ProcesosProductivosProductos_G1(idProcesoProductivo As Long,
                                                    idOperacion As Integer) As DataTable
      Return ProcesosProductivosProductos_G(idProcesoProductivo, idOperacion, Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Function ProcesosProductivosProductos_GA() As DataTable
      Return ProcesosProductivosProductos_G(idProcesoProductivo:=0, idOperacion:=0, esNecesario:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Function ProcesosProductivosProductos_GA(idProcesoProductivo As Long, idOperacion As Integer, esNecesario As Entidades.Publicos.SiNoTodos) As DataTable
      Return ProcesosProductivosProductos_G(idProcesoProductivo:=idProcesoProductivo, idOperacion:=idOperacion, esNecesario:=esNecesario)
   End Function

   Public Function ObtieneListaNecesarios(idProcesoProductivo As Long, requerimiento As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("SELECT PP.IdProcesoProductivo, PP.IdProductoProceso, P.NombreProducto, SUM(PP.CantidadSolicitada) as CantidadSolicitada, ")
         .AppendLine("       P.IdProcesoProductivoDefecto ")
         If Not requerimiento Then
            .AppendLine("       ,SUM(MPP.TiempoTotalProceso) AS TiempoTotalProceso")
         End If
         .AppendLine(" FROM MRPProcesosProductivosProductos PP")
         .AppendLine("      INNER JOIN Productos P ON P.IdProducto = PP.IdProductoProceso ")
         If Not requerimiento Then
            .AppendLine("      INNER JOIN MRPProcesosProductivos MPP ON P.IdProcesoProductivoDefecto = MPP.IdProcesoProductivo ")
            .AppendFormat("   WHERE PP.IdProcesoProductivo = {0} AND PP.EsProductoNecesario = 1 AND P.IdProcesoProductivoDefecto IS NOT NULL ", idProcesoProductivo).AppendLine()
         Else
            .AppendFormat("   WHERE PP.IdProcesoProductivo = {0} AND PP.EsProductoNecesario = 1 AND P.IdProcesoProductivoDefecto IS NULL ", idProcesoProductivo).AppendLine()
         End If
         .AppendLine(" GROUP BY PP.IdProcesoProductivo, PP.IdProductoProceso, P.NombreProducto, P.IdProcesoProductivoDefecto")

         If Not requerimiento Then
            .AppendLine(" , MPP.TiempoTotalProceso")
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function GetCantidadSucursalesDepositos(IdSucursal As Integer, IdDeposito As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT COUNT(*) AS Cantidad FROM {0} as MRPP", Entidades.MRPProcesoProductivoProducto.NombreTabla)
         .AppendFormatLine("     WHERE MRPP.IdSucursalOrigen = {0}", IdSucursal)
         If IdDeposito <> 0 Then
            .AppendFormatLine("       AND MRPP.IdDepositoOrigen = {0}", IdDeposito)
         End If
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetProductoExisteEnOtroPP(idProducto As String, idProductoProceso As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT MPP.CodigoProcesoProductivo, MPP.DescripcionProceso FROM {0} as MPPP", Entidades.MRPProcesoProductivoProducto.NombreTabla)
         .AppendFormatLine("     INNER JOIN MRPProcesosProductivos MPP ON MPP.IdProcesoProductivo = MPPP.IdProcesoProductivo")
         .AppendFormatLine("    WHERE MPPP.EsProductoNecesario = 0 AND MPPP.IdProductoProceso = '{0}' AND MPP.IdProductoProceso <> '{1}'", idProducto, idProductoProceso)
         .AppendFormatLine(" GROUP BY MPP.CodigoProcesoProductivo, MPP.DescripcionProceso")
      End With

      Return GetDataTable(stb)
   End Function
End Class
