Imports Eniac.Entidades
Imports Eniac.Entidades.MRPProcesoProductivoOperacion

Public Class MRPProcesosProductivosOperaciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProcesosProductivosOperaciones_I(idOperacion As Integer,
                                               idProcesoProductivo As Long,
                                               codigoProcProdOperacion As String,
                                               descripcionOperacion As String,
                                               codigoTarea As Integer,
                                               SucursalOperacion As Integer,
                                               DepositoOperacion As Integer,
                                               UbicacionOperacion As Integer,
                                               CentroProductorOperacion As Integer,
                                               papTiemposMaquina As Decimal,
                                               papTiemposHHombre As Decimal,
                                               prodTiemposMaquina As Decimal,
                                               prodTiemposHHombre As Decimal,
                                               Proveedor As Long,
                                               costoExterno As Decimal,
                                               unidadesHora As Decimal,
                                               NormasDispositivos As String,
                                               NormasMetodos As String,
                                               NormasSeguridad As String,
                                               NormasControlCalidad As String,
                                               TipoOperacionExterna As OperacionesExternas?,
                                               idOperacionExternaVinculada As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}) ",
                       MRPProcesoProductivoOperacion.NombreTabla,
                       MRPProcesoProductivoOperacion.Columnas.IdOperacion.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.IdProcesoProductivo.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.CodigoProcProdOperacion.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.DescripcionOperacion.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.IdCodigoTarea.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.SucursalOperacion.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.DepositoOperacion.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.UbicacionOperacion.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.CentroProductorOperacion.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.PAPTiemposMaquina.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.PAPTiemposHHombre.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.ProdTiemposMaquina.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.ProdTiemposHHombre.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.Proveedor.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.CostoExterno.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.UnidadesHora.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.NormasDispositivos.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.NormasMetodos.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.NormasSeguridad.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.NormasControlCalidad.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.TipoOperacionExterna.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.IdOperacionExternaVinculada.ToString()).AppendLine()

         .AppendFormat("  VALUES (")
         .AppendFormat("         {0} ", idOperacion).AppendLine()
         .AppendFormat("      ,  {0} ", idProcesoProductivo).AppendLine()
         .AppendFormat("      , '{0}'", codigoProcProdOperacion).AppendLine()
         .AppendFormat("      , '{0}'", descripcionOperacion).AppendLine()
         .AppendFormat("      ,  {0} ", codigoTarea).AppendLine()
         .AppendFormat("      ,  {0} ", SucursalOperacion).AppendLine()
         .AppendFormat("      ,  {0} ", DepositoOperacion).AppendLine()
         .AppendFormat("      ,  {0} ", UbicacionOperacion).AppendLine()
         .AppendFormat("      ,  {0} ", CentroProductorOperacion).AppendLine()
         .AppendFormat("      ,  {0} ", papTiemposMaquina).AppendLine()
         .AppendFormat("      ,  {0} ", papTiemposHHombre).AppendLine()
         .AppendFormat("      ,  {0} ", prodTiemposMaquina).AppendLine()
         .AppendFormat("      ,  {0} ", prodTiemposHHombre).AppendLine()
         If Proveedor > 0 Then
            .AppendFormat("      ,{0} ", Proveedor).AppendLine()
         Else
            .AppendFormat("      ,NULL ").AppendLine()
         End If
         .AppendFormat("      , {0}  ", costoExterno).AppendLine()
         .AppendFormat("      , {0}  ", unidadesHora).AppendLine()
         .AppendFormat("      ,'{0}' ", NormasDispositivos).AppendLine()
         .AppendFormat("      ,'{0}' ", NormasMetodos).AppendLine()
         .AppendFormat("      ,'{0}' ", NormasSeguridad).AppendLine()
         .AppendFormat("      ,'{0}' ", NormasControlCalidad).AppendLine()
         If TipoOperacionExterna.HasValue Then
            .AppendFormat("      ,'{0}' ", TipoOperacionExterna).AppendLine()
         Else
            .AppendFormat("      ,NULL ").AppendLine()
         End If
         If idOperacionExternaVinculada.HasValue Then
            .AppendFormat("      ,{0} ", idOperacionExternaVinculada).AppendLine()
         Else
            .AppendFormat("      ,NULL  ").AppendLine()
         End If
         .AppendFormat(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub ProcesosProductivosOperaciones_U(idOperacion As Integer,
                                               idProcesoProductivo As Long,
                                               codigoProcProdOperacion As String,
                                               descripcionOperacion As String,
                                               codigoTarea As Integer,
                                               SucursalOperacion As Integer,
                                               DepositoOperacion As Integer,
                                               UbicacionOperacion As Integer,
                                               CentroProductorOperacion As Integer,
                                               papTiemposMaquina As Decimal,
                                               papTiemposHHombre As Decimal,
                                               prodTiemposMaquina As Decimal,
                                               prodTiemposHHombre As Decimal,
                                               Proveedor As Long,
                                               costoExterno As Decimal,
                                               unidadesHora As Decimal,
                                               NormasDispositivos As String,
                                               NormasMetodos As String,
                                               NormasSeguridad As String,
                                               NormasControlCalidad As String,
                                               TipoOperacionExterna As OperacionesExternas?,
                                               idOperacionExternaVinculada As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", MRPProcesoProductivoOperacion.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}' ", MRPProcesoProductivoOperacion.Columnas.CodigoProcProdOperacion.ToString(), codigoProcProdOperacion).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", MRPProcesoProductivoOperacion.Columnas.DescripcionOperacion.ToString(), descripcionOperacion).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.IdCodigoTarea.ToString(), codigoTarea).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.SucursalOperacion.ToString(), SucursalOperacion).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.DepositoOperacion.ToString(), DepositoOperacion).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.UbicacionOperacion.ToString(), UbicacionOperacion).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.CentroProductorOperacion.ToString(), CentroProductorOperacion).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.UnidadesHora.ToString(), unidadesHora).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.PAPTiemposMaquina.ToString(), papTiemposMaquina).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.PAPTiemposHHombre.ToString(), papTiemposHHombre).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.ProdTiemposMaquina.ToString(), prodTiemposMaquina).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.ProdTiemposHHombre.ToString(), prodTiemposHHombre).AppendLine()
         If Proveedor > 0 Then
            .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.Proveedor.ToString(), Proveedor).AppendLine()
         Else
            .AppendFormat("      ,{0} =  NULL  ", MRPProcesoProductivoOperacion.Columnas.Proveedor.ToString()).AppendLine()
         End If
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.CostoExterno.ToString(), costoExterno).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", MRPProcesoProductivoOperacion.Columnas.NormasDispositivos.ToString(), NormasDispositivos).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", MRPProcesoProductivoOperacion.Columnas.NormasMetodos.ToString(), NormasMetodos).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", MRPProcesoProductivoOperacion.Columnas.NormasSeguridad.ToString(), NormasSeguridad).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", MRPProcesoProductivoOperacion.Columnas.NormasControlCalidad.ToString(), NormasControlCalidad).AppendLine()
         If TipoOperacionExterna.HasValue Then
            .AppendFormat("      ,{0} = '{1}' ", MRPProcesoProductivoOperacion.Columnas.TipoOperacionExterna.ToString(), TipoOperacionExterna).AppendLine()
         Else
            .AppendFormat("      ,{0} = NULL ", MRPProcesoProductivoOperacion.Columnas.TipoOperacionExterna.ToString()).AppendLine()
         End If
         If idOperacionExternaVinculada.HasValue Then
            .AppendFormat("      ,{0} =  {1} ", MRPProcesoProductivoOperacion.Columnas.IdOperacionExternaVinculada.ToString(), idOperacionExternaVinculada).AppendLine()
         Else
            .AppendFormat("      ,{0} =  NULL  ", MRPProcesoProductivoOperacion.Columnas.IdOperacionExternaVinculada.ToString()).AppendLine()
         End If
         .AppendFormat(" WHERE {0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.IdOperacion.ToString(), idOperacion).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub ProcesosProductivosOperaciones_D(idOperacion As Integer,
                                               idProcesoProductivo As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {3} AND {2} = {4}",
                       MRPProcesoProductivoOperacion.NombreTabla,
                       MRPProcesoProductivoOperacion.Columnas.IdProcesoProductivo.ToString(),
                       MRPProcesoProductivoOperacion.Columnas.IdOperacion.ToString(),
                       idProcesoProductivo, idOperacion)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   ''' <summary>
   ''' Vincula las Operaciones de Envio con las de recepcion.-
   ''' </summary>
   ''' <param name="idOperacion"></param>
   ''' <param name="idProcesoProductivo"></param>
   ''' <param name="idOperacionExternaVinculada">Id de Operacion Recepcion</param>
   Public Sub ProcesosProductivosOperaciones_UOperacionesVinculadas(idOperacion As Integer,
                                                                    idProcesoProductivo As Long,
                                                                    idOperacionExternaVinculada As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", MRPProcesoProductivoOperacion.NombreTabla).AppendLine()
         If idOperacionExternaVinculada > 0 Then
            .AppendFormat("   SET {0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.IdOperacionExternaVinculada.ToString(), idOperacionExternaVinculada).AppendLine()
         Else
            .AppendFormat("   SET {0} =  NULL  ", MRPProcesoProductivoOperacion.Columnas.IdOperacionExternaVinculada.ToString()).AppendLine()
         End If

         .AppendFormat(" WHERE {0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo).AppendLine()
         If idOperacion > 0 Then
            .AppendFormat("   AND {0} =  {1}  ", MRPProcesoProductivoOperacion.Columnas.IdOperacion.ToString(), idOperacion).AppendLine()
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT PPO.*, P.NombreProducto AS DescripcionProductoPrincipal, PP.IdProductoProceso as IdProductoPrincipal FROM {0} AS PPO ", MRPProcesoProductivoOperacion.NombreTabla).AppendLine()
         .AppendFormat("   INNER JOIN {0} AS PP ON PPO.IdProcesoProductivo = PP.IdProcesoProductivo", MRPProcesoProductivo.NombreTabla).AppendLine()
         .AppendFormat("   INNER JOIN {0} AS P ON PP.IdProductoProceso = P.IdProducto ", Producto.NombreTabla).AppendLine()
      End With
   End Sub

   Private Function ProcesosProductivosOperaciones_G(idProcesoProductivo As Long, idOperacion As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idProcesoProductivo > 0 Then
            .AppendFormat("   AND PP.IdProcesoProductivo = {0}", idProcesoProductivo).AppendLine()
         End If
         If idOperacion > 0 Then
            .AppendFormat("   AND PPO.IdOperacion = {0}", idOperacion).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Private Function ProcesosProductivosOperaciones_G_Ant(idProcesoProductivo As Long, codigoOperacion As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idProcesoProductivo > 0 Then
            .AppendFormat("   AND PP.IdProcesoProductivo = {0}", idProcesoProductivo).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(codigoOperacion) Then
            .AppendFormat("   AND PPO.{0} < '{1}'", MRPProcesoProductivoOperacion.Columnas.CodigoProcProdOperacion.ToString(), codigoOperacion).AppendLine()
         End If
         .AppendLine(" ORDER BY PPO.CodigoProcProdOperacion DESC ")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ProcesosProductivosOperaciones_G1(idProcesoProductivo As Long,
                                          idOperacion As Integer) As DataTable

      Return ProcesosProductivosOperaciones_G(idProcesoProductivo, idOperacion)
   End Function
   Public Function ProcesosProductivosOperaciones_G1_Ant(idProcesoProductivo As Long,
                                                         codigoOperacion As String) As DataTable

      Return ProcesosProductivosOperaciones_G_Ant(idProcesoProductivo, codigoOperacion)
   End Function

   Public Function ProcesosProductivosOperaciones_GA() As DataTable
      Return ProcesosProductivosOperaciones_G(idProcesoProductivo:=0, idOperacion:=0)
   End Function
   Public Function ProcesosProductivosOperaciones_GA(idProcesoProductivo As Long) As DataTable
      Return ProcesosProductivosOperaciones_G(idProcesoProductivo:=idProcesoProductivo, idOperacion:=0)
   End Function

   Public Overloads Function GetCodigoMaximo(idProcesoProductivo As Long) As Integer

      Return Convert.ToInt32(GetCodigoMaximo(MRPProcesoProductivoOperacion.Columnas.IdOperacion.ToString(), MRPProcesoProductivoOperacion.NombreTabla,
                                             String.Format("{0} = {1} ",
                                                           MRPProcesoProductivoOperacion.Columnas.IdProcesoProductivo.ToString(),
                                                           idProcesoProductivo)))
   End Function

   Public Function TiempoTotalesPAP(idProcesoProductivo As Long) As Decimal
      Dim tiempoFinalPAP As Decimal = 0

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("SELECT SUM(PAPTiemposMaquina) + SUM(PAPTiemposHHombre) as TiemposPAP FROM {0} WHERE {1} = {2}",
                       MRPProcesoProductivoOperacion.NombreTabla,
                       MRPProcesoProductivoOperacion.Columnas.IdProcesoProductivo.ToString(),
                       idProcesoProductivo)
      End With
      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())
      If dt.Rows.Count > 0 Then
         tiempoFinalPAP = Decimal.Parse(dt.Rows(0)("TiemposPAP").ToString())
      End If

      Return tiempoFinalPAP
   End Function

   Public Function GetCantidadSucursalesDepositos(IdSucursal As Integer, IdDeposito As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT COUNT(*) AS Cantidad FROM {0} as MRPO", Entidades.MRPProcesoProductivoOperacion.NombreTabla)
         .AppendFormatLine("     WHERE MRPO.SucursalOperacion = {0}", IdSucursal)
         If IdDeposito <> 0 Then
            .AppendFormatLine("       AND MRPO.DepositoOperacion = {0}", IdDeposito)
         End If
      End With

      Return GetDataTable(stb)
   End Function
End Class
