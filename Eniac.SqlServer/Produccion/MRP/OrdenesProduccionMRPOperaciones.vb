Imports Eniac.Entidades
Imports Eniac.Entidades.MRPProcesoProductivoOperacion

Public Class OrdenesProduccionMRPOperaciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub
   Public Sub OrdenesProduccionMRPOperaciones_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                                orden As Integer, idProducto As String, idProcesoProductivo As Long, idOperacion As Integer,
                                                codigoProcProdOperacion As String, descripcionOperacion As String,
                                                sucursalOperacion As Integer, DepositoOperacion As Integer, UbicacionOperacion As Integer,
                                                centroProductorOperacion As Integer,
                                                papTiemposMaquina As Decimal, papTiemposHHombre As Decimal, prodTiemposMaquina As Decimal, prodTiemposHHombre As Decimal,
                                                proveedor As Long, costoExterno As Decimal,
                                                unidadesHora As Decimal,
                                                normasDispositivos As String, normasMetodos As String, normasSeguridad As String, normasControlCalidad As String,
                                                idEstadoTarea As String,
                                                fechaComienzo As Date,
                                                idCodigoTarea As Integer,
                                                TipoOperacionExterna As OperacionesExternas?,
                                                idOperacionExternaVinculada As Integer?)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", OrdenProduccionMRPOperacion.NombreTabla)
         .AppendFormatLine("     {0}", OrdenProduccionMRPOperacion.Columnas.IdSucursal.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.LetraComprobante.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.NumeroOrdenProduccion.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.Orden.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.IdProducto.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.IdProcesoProductivo.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.IdOperacion.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.CodigoProcProdOperacion.ToString())        '' 10
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.DescripcionOperacion.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.SucursalOperacion.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.DepositoOperacion.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.UbicacionOperacion.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.CentroProductorOperacion.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.PAPTiemposMaquina.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.PAPTiemposHHombre.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.ProdTiemposMaquina.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.ProdTiemposHHombre.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.Proveedor.ToString())                      '' 20
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.CostoExterno.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.UnidadesHora.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.NormasDispositivos.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.NormasMetodos.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.NormasSeguridad.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.NormasControlCalidad.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.IdEstadoTarea.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.FechaComienzo.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.IdCodigoTarea.ToString())
         '-- REQ-42033.- ---------------------------------------------------------------------------------------------
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.TipoOperacionExterna.ToString())
         .AppendFormatLine("   , {0}", OrdenProduccionMRPOperacion.Columnas.IdOperacionExternaVinculada.ToString())
         '------------------------------------------------------------------------------------------------------------
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("      {0} ", idSucursal)
         .AppendFormatLine("   , '{0}'", idTipoComprobante)
         .AppendFormatLine("   , '{0}'", letra)
         .AppendFormatLine("   ,  {0} ", centroEmisor)
         .AppendFormatLine("   ,  {0} ", numeroOrdenProduccion)
         .AppendFormatLine("   ,  {0} ", orden)
         .AppendFormatLine("   , '{0}'", idProducto)
         .AppendFormatLine("   ,  {0} ", idProcesoProductivo)
         .AppendFormatLine("   ,  {0} ", idOperacion)
         .AppendFormatLine("   , '{0}'", codigoProcProdOperacion)             ' 10
         .AppendFormatLine("   , '{0}'", descripcionOperacion)
         .AppendFormatLine("   ,  {0} ", sucursalOperacion)
         .AppendFormatLine("   ,  {0} ", DepositoOperacion)
         .AppendFormatLine("   ,  {0} ", UbicacionOperacion)
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(centroProductorOperacion))
         .AppendFormatLine("   ,  {0} ", papTiemposMaquina)
         .AppendFormatLine("   ,  {0} ", papTiemposHHombre)
         .AppendFormatLine("   ,  {0} ", prodTiemposMaquina)
         .AppendFormatLine("   ,  {0} ", prodTiemposHHombre)
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(proveedor))      ' 20
         .AppendFormatLine("   ,  {0} ", costoExterno)
         .AppendFormatLine("   ,  {0} ", unidadesHora)
         .AppendFormatLine("   , '{0}'", normasDispositivos)
         .AppendFormatLine("   , '{0}'", normasMetodos)
         .AppendFormatLine("   , '{0}'", normasSeguridad)
         .AppendFormatLine("   , '{0}'", normasControlCalidad)
         .AppendFormatLine("   , '{0}'", idEstadoTarea)
         .AppendFormatLine("   , '{0}'", ObtenerFecha(fechaComienzo, True))
         .AppendFormatLine("   ,  {0} ", idCodigoTarea)
         '-- REQ-42033.- ---------------------------------------------------------------------------------------------
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
         '------------------------------------------------------------------------------------------------------------
         .AppendFormat(")")
      End With
      Execute(myQuery)
   End Sub
   Public Sub OrdenesProduccionMRPOperaciones_U(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                                orden As Integer, idProducto As String, idProcesoProductivo As Long, idOperacion As Integer,
                                                codigoProcProdOperacion As String, descripcionOperacion As String,
                                                sucursalOperacion As Integer, depositoOperacion As Integer, ubicacionOperacion As Integer,
                                                centroProductorOperacion As Integer,
                                                papTiemposMaquina As Decimal, papTiemposHHombre As Decimal, prodTiemposMaquina As Decimal, prodTiemposHHombre As Decimal,
                                                proveedor As Long, costoExterno As Decimal,
                                                unidadesHora As Decimal,
                                                normasDispositivos As String, normasMetodos As String, normasSeguridad As String, normasControlCalidad As String,
                                                idEstadoTarea As String,
                                                fechaComienzo As Date,
                                                idCodigoTarea As Integer,
                                                TipoOperacionExterna As OperacionesExternas?,
                                                idOperacionExternaVinculada As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", OrdenProduccionMRPOperacion.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.CodigoProcProdOperacion.ToString(), codigoProcProdOperacion)
         .AppendFormatLine("      ,{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.DescripcionOperacion.ToString(), descripcionOperacion)
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdCodigoTarea.ToString(), idCodigoTarea)
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.SucursalOperacion.ToString(), sucursalOperacion)
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.DepositoOperacion.ToString(), depositoOperacion)
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.UbicacionOperacion.ToString(), ubicacionOperacion)
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.CentroProductorOperacion.ToString(), GetStringFromNumber(centroProductorOperacion))
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.UnidadesHora.ToString(), unidadesHora)
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.PAPTiemposMaquina.ToString(), papTiemposMaquina)
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.PAPTiemposHHombre.ToString(), papTiemposHHombre)
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.ProdTiemposMaquina.ToString(), prodTiemposMaquina)
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.ProdTiemposHHombre.ToString(), prodTiemposHHombre)
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.Proveedor.ToString(), GetStringFromNumber(proveedor))
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.CostoExterno.ToString(), costoExterno)
         .AppendFormatLine("      ,{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.NormasDispositivos.ToString(), normasDispositivos)
         .AppendFormatLine("      ,{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.NormasMetodos.ToString(), normasMetodos)
         .AppendFormatLine("      ,{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.NormasSeguridad.ToString(), normasSeguridad)
         .AppendFormatLine("      ,{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.NormasControlCalidad.ToString(), normasControlCalidad)
         .AppendFormatLine("      ,{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.IdEstadoTarea.ToString(), idEstadoTarea)
         .AppendFormatLine("      ,{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.FechaComienzo.ToString(), ObtenerFecha(fechaComienzo, True))

         If TipoOperacionExterna.HasValue Then
            .AppendFormat("      ,{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.TipoOperacionExterna.ToString(), TipoOperacionExterna).AppendLine()
         Else
            .AppendFormat("      ,{0} = NULL ", OrdenProduccionMRPOperacion.Columnas.TipoOperacionExterna.ToString()).AppendLine()
         End If
         If idOperacionExternaVinculada.HasValue Then
            .AppendFormat("      ,{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdOperacionExternaVinculada.ToString(), idOperacionExternaVinculada).AppendLine()
         Else
            .AppendFormat("      ,{0} =  NULL  ", OrdenProduccionMRPOperacion.Columnas.IdOperacionExternaVinculada.ToString()).AppendLine()
         End If
         .AppendFormatLine(" WHERE {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.LetraComprobante.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdOperacion.ToString(), idOperacion)
      End With
      Execute(myQuery)
   End Sub
   Public Sub OrdenesProduccionMRPOperaciones_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                                orden As Integer, idProducto As String, idProcesoProductivo As Long, idOperacion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", OrdenProduccionMRPOperacion.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.LetraComprobante.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.IdProducto.ToString(), idProducto)
         If idProcesoProductivo > 0 Then
            .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo)
         End If
         If idOperacion > 0 Then
            .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdOperacion.ToString(), idOperacion)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT OPO.*")
         .AppendFormatLine("     , CP.Descripcion")
         .AppendFormatLine("     , PRO.NombreProducto")
         .AppendFormatLine("     , MCP.Descripcion as DescripcionCentro")
         .AppendFormatLine("     , PRV.CodigoProveedor, PRV.NombreProveedor")
         .AppendFormatLine("	   , OP.IdCliente, CLI.CodigoCliente, CLI.NombreCliente")
         .AppendFormatLine("  FROM {0} AS OPO ", Entidades.OrdenProduccionMRPOperacion.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} CP  ON CP.IdCentroProductor    = OPO.CentroProductorOperacion ", Entidades.MRPCentroProductor.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} PRO ON PRO.IdProducto          = OPO.IdProducto", Entidades.Producto.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} MCP ON MCP.IdCentroProductor   = OPO.CentroProductorOperacion", Entidades.MRPCentroProductor.NombreTabla)
         '-- REQ-41512.- -----------------------------------------------------------------------------------------------------
         .AppendFormatLine(" LEFT JOIN {0} PRV ON PRV.IdProveedor         = OPO.Proveedor", Entidades.Proveedor.NombreTabla)
         '--------------------------------------------------------------------------------------------------------------------
         .AppendFormatLine(" INNER JOIN OrdenesProduccion OP")
         .AppendFormatLine("         ON OP.IdSucursal             = OPO.IdSucursal ")
         .AppendFormatLine("        AND OP.IdTipoComprobante      = OPO.IdTipoComprobante")
         .AppendFormatLine("        AND OP.Letra                  = OPO.LetraComprobante")
         .AppendFormatLine("        AND OP.CentroEmisor           = OPO.CentroEmisor")
         .AppendFormatLine("        AND OP.NumeroOrdenProduccion  = OPO.NumeroOrdenProduccion")
         .AppendFormatLine(" INNER JOIN {0} CLI ON CLI.IdCliente  = OP.IdCliente", Entidades.Cliente.NombreTabla)

         'ADVERTENCIA: No agregar ORDER BY en el SelectTexto porque hay métodos que luego de llamarlo agregan JOINS
      End With
   End Sub
   Private Function OrdenesProduccionMRPOperaciones_G(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                                      orden As Integer, idProducto As String, idProcesoProductivo As Long, idOperacion As Integer, codigoOperacion As String,
                                                      orderBy As OrderByList) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE OPO.{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND OPO.{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND OPO.{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.LetraComprobante.ToString(), letra)
         .AppendFormatLine("   AND OPO.{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND OPO.{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("   AND OPO.{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion)
         .AppendFormatLine("   AND OPO.{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.IdProducto.ToString(), idProducto)
         If idProcesoProductivo > 0 Then
            .AppendFormatLine("   AND OPO.{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo)
         End If
         If idOperacion > 0 Then
            .AppendFormatLine("   AND OPO.{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdOperacion.ToString(), idOperacion)
         End If
         If Not String.IsNullOrWhiteSpace(codigoOperacion) Then
            .AppendFormatLine("   AND OPO.{0} <  '{1}'  ", OrdenProduccionMRPOperacion.Columnas.CodigoProcProdOperacion.ToString(), codigoOperacion)
         End If

         If orderBy.AnySecure() Then
            .AppendFormatLine(orderBy.ToString())
         End If

      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function OrdenesProduccionMRPOperaciones_Ant(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer,
                                                       numeroOrdenProduccion As Long, orden As Integer, idProducto As String, idProcesoProductivo As Long,
                                                       codigoOperacion As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE OPO.{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND OPO.{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND OPO.{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.LetraComprobante.ToString(), letra)
         .AppendFormatLine("   AND OPO.{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND OPO.{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("   AND OPO.{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion)
         .AppendFormatLine("   AND OPO.{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.IdProducto.ToString(), idProducto)
         If idProcesoProductivo > 0 Then
            .AppendFormatLine("   AND OPO.{0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo)
         End If
         If Not String.IsNullOrWhiteSpace(codigoOperacion) Then
            .AppendFormatLine("   AND OPO.{0} <  '{1}'  ", OrdenProduccionMRPOperacion.Columnas.CodigoProcProdOperacion.ToString(), codigoOperacion)
         End If

         .AppendFormatLine("ORDER BY OPO.CodigoProcProdOperacion DESC")

      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function OrdenesProduccionMRPOperaciones_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                                      orden As Integer, idProducto As String, idProcesoProductivo As Long, codigoOperacion As String) As DataTable
      Return OrdenesProduccionMRPOperaciones_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                orden, idProducto, idProcesoProductivo, idOperacion:=0, codigoOperacion,
                                                orderBy:=New OrderByList().Add("OPO", Entidades.OrdenProduccionMRPOperacion.Columnas.CodigoProcProdOperacion, OrderByOrientaciones.Descendente))
   End Function
   Public Function OrdenesProduccionMRPOperaciones_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                                      orden As Integer, idProducto As String, idProcesoProductivo As Long) As DataTable
      Return OrdenesProduccionMRPOperaciones_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                                orden, idProducto, idProcesoProductivo, idOperacion:=0, codigoOperacion:=String.Empty, orderBy:=Nothing)
   End Function
   Public Function OrdenesProduccionMRPOperaciones_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                                      orden As Integer, idProducto As String, idProcesoProductivo As Long, idOperacion As Integer) As DataTable
      Return OrdenesProduccionMRPOperaciones_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion,
                                              orden, idProducto, idProcesoProductivo, idOperacion, codigoOperacion:=String.Empty, orderBy:=Nothing)
   End Function

   Public Function OrdenesProduccionMRPOperaciones_GA_TalleresExternos(idProveedor As Long, fechaDesde As Date?, fechaHasta As Date?,
                                                                       idCentroProductor As Integer,
                                                                       idTipoComprobanteOP As String, numeroOrdenProduccion As Long,
                                                                       idTipoComprobantePedido As String, numeroPedido As Integer, ordenPedido As Integer,
                                                                       esProductoNecesario As Entidades.Publicos.SiNoTodos,
                                                                       pkOPMRP As IEnumerable(Of Entidades.OrdenProduccionMRPPK)) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT CONVERT(BIT, 0) AS Masivo")
         .AppendFormatLine("     , OPPrR.IdSucursal")
         .AppendFormatLine("     , OPPrR.IdTipoComprobante")
         .AppendFormatLine("     , TPOP.Descripcion DescripcionTipoComprobanteOP")
         .AppendFormatLine("     , OPPrR.LetraComprobante")
         .AppendFormatLine("     , OPPrR.CentroEmisor")
         .AppendFormatLine("     , OPPrR.NumeroOrdenProduccion")
         .AppendFormatLine("     , OPPrR.Orden")
         .AppendFormatLine("     , OPPrR.IdProducto")
         .AppendFormatLine("     , Pr.NombreProducto NombreProducto")
         .AppendFormatLine("     , OPPrR.IdOperacion")
         .AppendFormatLine("     , MCP.IdCentroProductor")
         .AppendFormatLine("     , MCP.CodigoCentroProductor AS CodigoCentroProductorOperacion")
         .AppendFormatLine("     , MCP.Descripcion AS DescripcionCentroProductorOperacion")
         .AppendFormatLine("     , OPPrR.IdProcesoProductivo")
         .AppendFormatLine("     , OPPrR.IdProductoProceso")
         .AppendFormatLine("     , PrR.NombreProducto NombreProductoResultante")
         .AppendFormatLine("     , PrR.IdUnidadDeMedida IdUnidadDeMedidaProceso")

         .AppendFormatLine("     , PrR.IdUnidadDeMedidaCompra IdUnidadDeMedidaCompra
                                 , PrR.FactorConversionCompra 
		                           , CONVERT(DECIMAL(16,4), 0) AS CantidadSeleccionadaCompra")

         .AppendFormatLine("     , PrR.AfectaStock AfectaStockProductoProceso")
         .AppendFormatLine("     , PrR.Lote LoteProductoProceso")
         .AppendFormatLine("     , PrR.NroSerie NroSerieProductoProceso")

         .AppendFormatLine("     , Prv.IdProveedor, Prv.CodigoProveedor, Prv.NombreProveedor")
         .AppendFormatLine("     , Clte.IdCliente, Clte.CodigoCliente, Clte.NombreCliente")
         .AppendFormatLine("     , OPPrR.EsProductoNecesario")
         .AppendFormatLine("     , OPPrR.CantidadSolicitada")
         .AppendFormatLine("     , OPPrR.CantidadProcesada")
         .AppendFormatLine("     , OPPrR.CantidadSolicitada - OPPrR.CantidadProcesada AS CantidadPendiente")
         .AppendFormatLine("     , CONVERT(DECIMAL(16,4), 0) AS CantidadSeleccionada")

         .AppendFormatLine("     , OPP.IdTipoComprobantePedido")
         .AppendFormatLine("     , TPOPP.Descripcion DescripcionTipoComprobantePedido")
         .AppendFormatLine("     , OPP.LetraPedido")
         .AppendFormatLine("     , OPP.CentroEmisorPedido")
         .AppendFormatLine("     , OPP.NumeroPedido")
         .AppendFormatLine("     , OPP.OrdenPedido")
         .AppendFormatLine("     , OPP.IdProductoPedido")
         '-- REQ-42982.- -----------------------------------------------
         .AppendFormatLine("     , OPO.NormasMetodos")
         '--------------------------------------------------------------
         .AppendFormatLine("  FROM OrdenesProduccionMRPProductos OPPrR")
         .AppendFormatLine(" INNER JOIN OrdenesProduccionMRPOperaciones AS OPO")
         .AppendFormatLine("         ON OPO.IdSucursal = OPPrR.IdSucursal")
         .AppendFormatLine("        AND OPO.IdTipoComprobante = OPPrR.IdTipoComprobante")
         .AppendFormatLine("        AND OPO.LetraComprobante = OPPrR.LetraComprobante")
         .AppendFormatLine("        AND OPO.CentroEmisor = OPPrR.CentroEmisor")
         .AppendFormatLine("        AND OPO.NumeroOrdenProduccion = OPPrR.NumeroOrdenProduccion")
         .AppendFormatLine("        AND OPO.IdProducto = OPPrR.IdProducto")
         .AppendFormatLine("        AND OPO.IdProcesoProductivo = OPPrR.IdProcesoProductivo")
         .AppendFormatLine("        AND OPO.IdOperacion = OPPrR.IdOperacion")

         .AppendFormatLine(" INNER JOIN OrdenesProduccionProductos OPP")
         .AppendFormatLine("         ON OPP.IdSucursal             = OPO.IdSucursal ")
         .AppendFormatLine("        AND OPP.IdTipoComprobante      = OPO.IdTipoComprobante")
         .AppendFormatLine("        AND OPP.Letra                  = OPO.LetraComprobante")
         .AppendFormatLine("        AND OPP.CentroEmisor           = OPO.CentroEmisor")
         .AppendFormatLine("        AND OPP.NumeroOrdenProduccion  = OPO.NumeroOrdenProduccion")
         .AppendFormatLine("        AND OPP.IdProducto             = OPO.IdProducto")
         .AppendFormatLine("        AND OPP.Orden                  = OPO.Orden")

         .AppendFormatLine(" INNER JOIN OrdenesProduccion OP")
         .AppendFormatLine("         ON OP.IdSucursal             = OPO.IdSucursal ")
         .AppendFormatLine("        AND OP.IdTipoComprobante      = OPO.IdTipoComprobante")
         .AppendFormatLine("        AND OP.Letra                  = OPO.LetraComprobante")
         .AppendFormatLine("        AND OP.CentroEmisor           = OPO.CentroEmisor")
         .AppendFormatLine("        AND OP.NumeroOrdenProduccion  = OPO.NumeroOrdenProduccion")

         .AppendFormatLine(" INNER JOIN Productos Pr  ON Pr.IdProducto  = OPPrR.IdProducto")
         .AppendFormatLine(" INNER JOIN Productos PrR ON PrR.IdProducto = OPPrR.IdProductoProceso")
         .AppendFormatLine(" INNER JOIN MRPCentrosProductores MCP ON MCP.IdCentroProductor = OPO.CentroProductorOperacion")
         .AppendFormatLine(" INNER JOIN Clientes Clte ON Clte.IdCliente = OP.IdCliente")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TPOP ON TPOP.IdTipoComprobante = OP.IdTipoComprobante")
         .AppendFormatLine("  LEFT JOIN TiposComprobantes TPOPP ON TPOPP.IdTipoComprobante = OPP.IdTipoComprobantePedido")
         .AppendFormatLine("  LEFT JOIN Proveedores Prv ON PRV.IdProveedor = OPO.Proveedor")

         'Agrego a las JOINS agregados en SelectTexto el de PedidosEstados para poder filtrar por IdTipoComprobante, NumeroPedido, Orden
         .AppendFormatLine("  LEFT JOIN PedidosEstados PDE")
         .AppendFormatLine("         ON PDE.IdSucursalProduccion        = OPO.IdSucursal")
         .AppendFormatLine("        AND PDE.IdTipoComprobanteProduccion = OPO.IdTipoComprobante")
         .AppendFormatLine("        AND PDE.LetraProduccion             = OPO.LetraComprobante")
         .AppendFormatLine("        AND PDE.CentroEmisorProduccion      = OPO.CentroEmisor")
         .AppendFormatLine("        AND PDE.NumeroOrdenProduccion       = OPO.NumeroOrdenProduccion")
         .AppendFormatLine("        AND PDE.OrdenProduccion             = OPO.Orden")

         .AppendFormatLine(" WHERE MCP.ClaseCentroProductor = '{0}'", Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())
         If esProductoNecesario <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND OPPrR.EsProductoNecesario = '{0}'", GetStringFromBoolean(esProductoNecesario = Entidades.Publicos.SiNoTodos.SI))
         End If

         '--
         .AppendFormatLine("   AND OPO.IdEstadoTarea <> '{0}' AND OPO.TipoOperacionExterna = '{1}' AND (OPPrR.CantidadSolicitada - OPPrR.CantidadProcesada) > 0",
                                                                                          Entidades.MRPProcesoProductivoOperacion.EstadoAsignaTarea.FINALIZADA,
                                                                                          Entidades.MRPProcesoProductivoOperacion.OperacionesExternas.ENVIO)
         '--
         'Busco si tiene al menos un Estado "En Proceso" con EXISTS porque podría tener más de uno y si hago un JOIN me podría duplicar registros
         .AppendFormatLine("   AND EXISTS(SELECT 1")
         .AppendFormatLine("                FROM OrdenesProduccionEstados OPE")
         .AppendFormatLine("               INNER JOIN EstadosOrdenesProduccion EOP ON EOP.idEstado = OPE.IdEstado")
         .AppendFormatLine("               WHERE OPE.IdSucursal = OPO.IdSucursal")
         .AppendFormatLine("                 AND OPE.IdTipoComprobante = OPO.IdTipoComprobante")
         .AppendFormatLine("                 AND OPE.Letra = OPO.LetraComprobante")
         .AppendFormatLine("                 AND OPE.CentroEmisor = OPO.CentroEmisor")
         .AppendFormatLine("                 AND OPE.NumeroOrdenProduccion = OPO.NumeroOrdenProduccion")
         .AppendFormatLine("                 AND OPE.IdProducto = OPO.IdProducto")
         .AppendFormatLine("                 AND OPE.Orden = OPO.Orden")
         .AppendFormatLine("                 AND EOP.IdTipoEstado = '{0}')", Entidades.EstadoOrdenProduccion.TipoEstado.ENPROCESO)

         If idProveedor > 0 Then
            .AppendFormatLine("   AND OPO.Proveedor = {0}", idProveedor)
         End If
         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND OP.FechaOrdenProduccion >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND OP.FechaOrdenProduccion <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If

         If idCentroProductor <> 0 Then
            .AppendFormatLine("   AND OPO.CentroProductorOperacion = {0}", idCentroProductor)
         End If

         If Not String.IsNullOrWhiteSpace(idTipoComprobanteOP) Then
            .AppendFormatLine("   AND OPO.IdTipoComprobante = '{0}'", idTipoComprobanteOP)
         End If
         If numeroOrdenProduccion > 0 Then
            .AppendFormatLine("   AND OPO.NumeroOrdenProduccion = {0}", numeroOrdenProduccion)
         End If

         If Not String.IsNullOrEmpty(idTipoComprobantePedido) Then
            .AppendFormatLine("   AND PDE.IdTipoComprobante = '{0}'", idTipoComprobantePedido)
         End If
         If numeroPedido > 0 Then
            .AppendFormatLine("   AND PDE.NumeroPedido = {0}", numeroPedido)
         End If
         If ordenPedido > 0 Then
            .AppendFormatLine("   AND PDE.Orden = {0}", ordenPedido)
         End If

         If pkOPMRP.AnySecure() Then
            Dim f = "(OPPrR.IdSucursal = {0} AND OPPrR.IdTipoComprobante = '{1}' AND OPPrR.LetraComprobante = '{2}' AND OPPrR.CentroEmisor = {3} AND OPPrR.NumeroOrdenProduccion = {4} AND OPPrR.Orden = {5} AND OPPrR.IdProducto = '{6}' AND OPPrR.IdProcesoProductivo = {7})"
            Dim pks = pkOPMRP.ToList().ConvertAll(Function(pk) String.Format(f, pk.IdSucursal, pk.IdTipoComprobante, pk.LetraComprobante, pk.CentroEmisor, pk.NumeroOrdenProduccion, pk.Orden, pk.IdProducto, pk.IdProcesoProductivo))
            .AppendFormatLine("   AND ({0})", String.Join(" OR ", pks))
         End If

      End With
      Return GetDataTable(myQuery)
   End Function


   Public Function OrdenesProduccionMRPOperaciones_GA_TalleresExternos_old(proveedor As Long, fechaDesde As Date?, fechaHasta As Date?,
                                                 idCentroProductor As Integer,
                                                 idTipoComprobanteOP As String, ordenProduccion As Long,
                                                 idTipoComprobantePedido As String, idPedido As Integer, linea As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         'Agrego a las JOINS agregados en SelectTexto el de PedidosEstados para poder filtrar por IdTipoComprobante, NumeroPedido, Orden
         .AppendFormatLine("  LEFT JOIN PedidosEstados PDE")
         .AppendFormatLine("         ON PDE.IdSucursalProduccion        = OPO.IdSucursal")
         .AppendFormatLine("        AND PDE.IdTipoComprobanteProduccion = OPO.IdTipoComprobante")
         .AppendFormatLine("        AND PDE.LetraProduccion             = OPO.LetraComprobante")
         .AppendFormatLine("        AND PDE.CentroEmisorProduccion      = OPO.CentroEmisor")
         .AppendFormatLine("        AND PDE.NumeroOrdenProduccion       = OPO.NumeroOrdenProduccion")
         .AppendFormatLine("			AND PDE.OrdenProduccion             = OPO.Orden")

         .AppendFormatLine(" WHERE MCP.ClaseCentroProductor = '{0}'", Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())

         'Busco si tiene al menos un Estado "En Proceso" con EXISTS porque podría tener más de uno y si hago un JOIN me podría duplicar registros
         .AppendFormatLine("   AND EXISTS(SELECT 1")
         .AppendFormatLine("                FROM OrdenesProduccionEstados OPE")
         .AppendFormatLine("               INNER JOIN EstadosOrdenesProduccion EOP ON EOP.idEstado = OPE.IdEstado")
         .AppendFormatLine("               WHERE OPE.IdSucursal = OPO.IdSucursal")
         .AppendFormatLine("                 AND OPE.IdTipoComprobante = OPO.IdTipoComprobante")
         .AppendFormatLine("                 AND OPE.Letra = OPO.LetraComprobante")
         .AppendFormatLine("                 AND OPE.CentroEmisor = OPO.CentroEmisor")
         .AppendFormatLine("                 AND OPE.NumeroOrdenProduccion = OPO.NumeroOrdenProduccion")
         .AppendFormatLine("                 AND OPE.IdProducto = OPO.IdProducto")
         .AppendFormatLine("                 AND OPE.Orden = OPO.Orden")
         .AppendFormatLine("                 AND EOP.IdTipoEstado = '{0}')", Entidades.EstadoOrdenProduccion.TipoEstado.ENPROCESO)


         If proveedor > 0 Then
            .AppendFormatLine("   AND OPO.Proveedor = {0}", proveedor)
         End If
         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND OP.FechaOrdenProduccion >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND OP.FechaOrdenProduccion <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If

         If ordenProduccion > 0 Then
            .AppendFormatLine("   AND OPO.NumeroOrdenProduccion = {0}", ordenProduccion)
            .AppendFormatLine("   AND OPO.IdTipoComprobante = '{0}'", idTipoComprobanteOP)
         End If

         If Not String.IsNullOrEmpty(idTipoComprobantePedido) Then
            .AppendFormatLine("   AND PDE.IdTipoComprobante = '{0}'", idTipoComprobantePedido)
         End If
         If idPedido > 0 Then
            .AppendFormatLine("   AND PDE.NumeroPedido = {0}", idPedido)
         End If
         If linea > 0 Then
            .AppendFormatLine("   AND PDE.Orden = {0}", linea)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Sub OrdenesProduccionMRPOperaciones_UA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long,
                                                 orden As Integer, idProducto As String, idProcesoProductivo As Long,
                                                 idOperacion As Integer, centroProductorOperacion As Integer,
                                                 proveedor As Long,
                                                 idEstadoTarea As String,
                                                 fechaComienzo As Date,
                                                 idEmpleado As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", OrdenProduccionMRPOperacion.NombreTabla)

         .AppendFormatLine("   SET {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.CentroProductorOperacion.ToString(), centroProductorOperacion)
         .AppendFormatLine("     , {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.Proveedor.ToString(), GetStringFromNumber(proveedor))
         .AppendFormatLine("      ,{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.IdEstadoTarea.ToString(), idEstadoTarea)
         .AppendFormatLine("      ,{0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.FechaComienzo.ToString(), ObtenerFecha(fechaComienzo, True))
         .AppendFormatLine("     , {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdEmpleado.ToString(), GetStringFromNumber(idEmpleado))

         .AppendFormatLine(" WHERE {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.LetraComprobante.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPOperacion.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPOperacion.Columnas.IdOperacion.ToString(), idOperacion)
      End With
      Execute(myQuery)
   End Sub

   Public Function GetOrdenProduccionCantidadSucursalesDepositos(IdSucursal As Integer, IdDeposito As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT COUNT(*) AS Cantidad FROM {0} as OPO", Entidades.OrdenProduccionMRPOperacion.NombreTabla)

         .AppendFormatLine("   INNER JOIN OrdenesProduccionEstados OPE")
         .AppendFormatLine("   	ON  OPO.IdSucursal = OPE.IdSucursal ")
         .AppendFormatLine("   	AND OPO.NumeroOrdenProduccion = OPE.NumeroOrdenProduccion")
         .AppendFormatLine("   	AND OPO.IdTipoComprobante = OPE.IdTipoComprobante")
         .AppendFormatLine("   	AND OPO.CentroEmisor = OPE.CentroEmisor")
         .AppendFormatLine("   	AND OPO.Orden = OPE.Orden")
         .AppendFormatLine("   	AND OPO.IdProducto = OPE.IdProducto")
         .AppendFormatLine("   INNER JOIN EstadosOrdenesProduccion EOP ")
         .AppendFormatLine("   	ON OPE.IdEstado = EOP.IdEstado")

         .AppendFormatLine("     WHERE OPO.SucursalOperacion = {0}", IdSucursal)
         If IdDeposito <> 0 Then
            .AppendFormatLine("       AND OPO.DepositoOperacion = {0}", IdDeposito)
         End If
         .AppendFormatLine("     AND EOP.IdTipoEstado <> 'FINALIZADO'")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetInformeOperaciones(idEstado As String, codigoProcProdOperacion As String, fechaDesde As Date?, fechaHasta As Date?,
                                         idTipoComprobante As String, letraFiscal As String, centroEmisor As Integer, numeroDesde As Long, numeroHasta As Long,
                                         idProducto As String, idCliente As Long?,
                                         idTipoComprobantePedido As String, letraFiscalPedido As String, centroEmisorPedido As Integer, numeroPedidoDesde As Long, numeroPedidoHasta As Long, lineaPedido As Integer,
                                         planMaestroNumero As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT OPO.IdSucursal")
         .AppendFormatLine("     , OPO.IdTipoComprobante")
         .AppendFormatLine("     , TP.Descripcion DescripcionTipoComprobante")
         .AppendFormatLine("     , OPO.LetraComprobante")
         .AppendFormatLine("     , OPO.CentroEmisor")
         .AppendFormatLine("     , OPO.NumeroOrdenProduccion")
         .AppendFormatLine("     , OPO.IdProcesoProductivo")
         .AppendFormatLine("     , OPO.Orden")
         .AppendFormatLine("     , OPO.IdOperacion")
         .AppendFormatLine("     , OPO.CodigoProcProdOperacion")
         .AppendFormatLine("     , OPO.DescripcionOperacion")
         .AppendFormatLine("     , OPO.IdEstadoTarea")
         .AppendFormatLine("     , OP.FechaOrdenProduccion")
         .AppendFormatLine("     , OP.IdCliente")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("     , OPP.IdProducto")
         .AppendFormatLine("     , OPP.NombreProducto")
         .AppendFormatLine("     , OPP.IdSucursalPedido")
         .AppendFormatLine("     , OPP.IdTipoComprobantePedido")
         .AppendFormatLine("     , TPP.Descripcion DescripcionTipoComprobantePedido")
         .AppendFormatLine("     , OPP.LetraPedido")
         .AppendFormatLine("     , OPP.CentroEmisorPedido")
         .AppendFormatLine("     , OPP.NumeroPedido")
         .AppendFormatLine("     , OPP.IdProductoPedido")
         .AppendFormatLine("     , OPP.OrdenPedido")
         .AppendFormatLine("  FROM OrdenesProduccionMRPOperaciones OPO")
         .AppendFormatLine(" INNER JOIN OrdenesProduccionProductos OPP")
         .AppendFormatLine("         ON OPP.IdSucursal = OPO.IdSucursal")
         .AppendFormatLine("        AND OPP.IdTipoComprobante = OPO.IdTipoComprobante")
         .AppendFormatLine("        AND OPP.Letra = OPO.LetraComprobante")
         .AppendFormatLine("        AND OPP.CentroEmisor = OPO.CentroEmisor")
         .AppendFormatLine("        AND OPP.NumeroOrdenProduccion = OPO.NumeroOrdenProduccion")
         .AppendFormatLine("        AND OPP.IdProducto = OPO.IdProducto")
         .AppendFormatLine("        AND OPP.Orden = OPO.Orden")
         .AppendFormatLine(" INNER JOIN OrdenesProduccion OP")
         .AppendFormatLine("         ON OP.IdSucursal = OPO.IdSucursal")
         .AppendFormatLine("        AND OP.IdTipoComprobante = OPO.IdTipoComprobante")
         .AppendFormatLine("        AND OP.Letra = OPO.LetraComprobante")
         .AppendFormatLine("        AND OP.CentroEmisor = OPO.CentroEmisor")
         .AppendFormatLine("        AND OP.NumeroOrdenProduccion = OPO.NumeroOrdenProduccion")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = OP.IdCliente")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TP ON TP.IdTipoComprobante = OPO.IdTipoComprobante")
         .AppendFormatLine("  LEFT JOIN TiposComprobantes TPP ON TPP.IdTipoComprobante = OPP.IdTipoComprobantePedido")
         .AppendFormatLine(" WHERE 1 = 1")

         If Not String.IsNullOrWhiteSpace(idEstado) Then
            .AppendFormatLine("   AND OPO.IdEstadoTarea = '{0}'", idEstado)
         End If
         If Not String.IsNullOrWhiteSpace(codigoProcProdOperacion) Then
            .AppendFormatLine("   AND OPO.CodigoProcProdOperacion = '{0}'", codigoProcProdOperacion)
         End If
         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND OP.FechaOrdenProduccion >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND OP.FechaOrdenProduccion <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND OPO.IdTipoComprobante = '{0}'", idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letraFiscal) Then
            .AppendFormatLine("   AND OPO.LetraComprobante = '{0}'", letraFiscal)
         End If
         If centroEmisor <> 0 Then
            .AppendFormatLine("   AND OPO.CentroEmisor = {0}", centroEmisor)
         End If
         If numeroDesde <> 0 Then
            .AppendFormatLine("   AND OPO.NumeroOrdenProduccion >= {0}", numeroDesde)
         End If
         If numeroHasta <> 0 Then
            .AppendFormatLine("   AND OPO.NumeroOrdenProduccion <= {0}", numeroHasta)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND OPP.IdProducto = '{0}'", idProducto)
         End If
         If idCliente <> 0 Then
            .AppendFormatLine("   AND OP.IdCliente = {0}", idCliente)
         End If

         If Not String.IsNullOrWhiteSpace(idTipoComprobantePedido) Then
            .AppendFormatLine("   AND OPP.IdTipoComprobantePedido = '{0}'", idTipoComprobantePedido)
         End If
         If Not String.IsNullOrWhiteSpace(letraFiscalPedido) Then
            .AppendFormatLine("   AND OPP.LetraPedido = '{0}'", letraFiscalPedido)
         End If
         If centroEmisorPedido <> 0 Then
            .AppendFormatLine("   AND OPP.CentroEmisorPedido = {0}", centroEmisorPedido)
         End If
         If numeroPedidoDesde <> 0 Then
            .AppendFormatLine("   AND OPP.NumeroPedido >= {0}", numeroPedidoDesde)
         End If
         If numeroPedidoHasta <> 0 Then
            .AppendFormatLine("   AND OPP.NumeroPedido <= {0}", numeroPedidoHasta)
         End If
         If lineaPedido <> 0 Then
            .AppendFormatLine("   AND OPP.OrdenPedido = {0}", lineaPedido)
         End If

         If planMaestroNumero <> 0 Then
            .AppendFormatLine("   AND EXISTS (SELECT 1")
            .AppendFormatLine("                 FROM OrdenesProduccionEstados OPE")
            .AppendFormatLine("                WHERE OPE.IdSucursal = OPP.IdSucursal")
            .AppendFormatLine("                  AND OPE.IdTipoComprobante = OPP.IdTipoComprobante")
            .AppendFormatLine("                  AND OPE.Letra = OPP.Letra")
            .AppendFormatLine("                  AND OPE.CentroEmisor = OPP.CentroEmisor")
            .AppendFormatLine("                  AND OPE.NumeroOrdenProduccion = OPP.NumeroOrdenProduccion")
            .AppendFormatLine("                  AND OPE.IdProducto = OPP.IdProducto")
            .AppendFormatLine("                  AND OPE.Orden = OPP.Orden")
            .AppendFormatLine("                  AND OPE.PlanMaestroNumero = {0})", planMaestroNumero)
         End If

         .AppendFormatLine(" ORDER BY OPO.IdSucursal, OPO.IdTipoComprobante, OPO.LetraComprobante, OPO.CentroEmisor, OPO.NumeroOrdenProduccion")
         .AppendFormatLine("        , OPO.Orden, OPO.CodigoProcProdOperacion")
      End With

      Return GetDataTable(stb)
   End Function

End Class