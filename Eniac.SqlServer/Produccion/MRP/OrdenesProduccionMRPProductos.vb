Imports Eniac.Entidades
Imports Eniac.Entidades.EstadoOrdenCalidad
Public Class OrdenesProduccionMRPProductos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub OrdenesProduccionMRPProductos_I(idSucursal As Integer,
                                              idTipoComprobante As String,
                                              letra As String,
                                              centroEmisor As Integer,
                                              numeroOrdenProduccion As Long,
                                              orden As Integer,
                                              idProducto As String,
                                              idProcesoProductivo As Long,
                                              idOperacion As Integer,
                                              idProductoProceso As String,
                                              cantidadSolicitada As Decimal,
                                              precioCostoProducto As Decimal,
                                              esProductoNecesario As Boolean,
                                              idSucursalOrigen As Integer,
                                              idDepositoOrigen As Integer,
                                              idUbicacionOrigen As Integer,
                                              estadocompra As String,
                                              cantidadProcesada As Decimal,
                                              cantidadUnitaria As Decimal)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}",
                       OrdenProduccionMRPProducto.NombreTabla,
                       OrdenProduccionMRPProducto.Columnas.IdSucursal.ToString(),
                       OrdenProduccionMRPProducto.Columnas.IdTipoComprobante.ToString(),
                       OrdenProduccionMRPProducto.Columnas.LetraComprobante.ToString(),
                       OrdenProduccionMRPProducto.Columnas.CentroEmisor.ToString(),
                       OrdenProduccionMRPProducto.Columnas.NumeroOrdenProduccion.ToString(),
                       OrdenProduccionMRPProducto.Columnas.Orden.ToString(),
                       OrdenProduccionMRPProducto.Columnas.IdProducto.ToString(),
                       OrdenProduccionMRPProducto.Columnas.IdProcesoProductivo.ToString(),
                       OrdenProduccionMRPProducto.Columnas.IdOperacion.ToString(),
                       OrdenProduccionMRPProducto.Columnas.IdProductoProceso.ToString(),
                       OrdenProduccionMRPProducto.Columnas.EsProductoNecesario.ToString(),
                       OrdenProduccionMRPProducto.Columnas.CantidadSolicitada.ToString(),
                       OrdenProduccionMRPProducto.Columnas.PrecioCostoProducto.ToString(),
                       OrdenProduccionMRPProducto.Columnas.IdSucursalOrigen.ToString(),
                       OrdenProduccionMRPProducto.Columnas.IdDepositoOrigen.ToString(),
                       OrdenProduccionMRPProducto.Columnas.IdUbicacionOrigen.ToString(),
                       OrdenProduccionMRPProducto.Columnas.EstadoCompra.ToString(),
                       OrdenProduccionMRPProducto.Columnas.CantidadProcesada.ToString(),
                       OrdenProduccionMRPProducto.Columnas.CantidadUnitaria.ToString())

         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	    {0} ", idSucursal)
         .AppendFormatLine("	 , '{0}'", idTipoComprobante)
         .AppendFormatLine("	 , '{0}'", letra)
         .AppendFormatLine("	 ,  {0} ", centroEmisor)
         .AppendFormatLine("	 ,  {0} ", numeroOrdenProduccion)
         .AppendFormatLine("	 ,  {0} ", orden)
         .AppendFormatLine("	 , '{0}'", idProducto)
         .AppendFormatLine("	 ,  {0} ", idProcesoProductivo)
         .AppendFormatLine("	 ,  {0} ", idOperacion)
         .AppendFormatLine("	 , '{0}'", idProductoProceso)
         .AppendFormatLine("	 ,  {0} ", GetStringFromBoolean(esProductoNecesario))
         .AppendFormatLine("	 ,  {0} ", cantidadSolicitada)
         .AppendFormatLine("	 ,  {0} ", precioCostoProducto)
         If idSucursalOrigen > 0 Then
            .AppendFormatLine("	 ,  {0} ", idSucursalOrigen)
         Else
            .AppendFormatLine("	 , NULL ")
         End If
         If idDepositoOrigen > 0 Then
            .AppendFormatLine("	 ,  {0} ", idDepositoOrigen)
         Else
            .AppendFormatLine("	 , NULL ")
         End If
         If idUbicacionOrigen > 0 Then
            .AppendFormatLine("	 ,  {0} ", idUbicacionOrigen)
         Else
            .AppendFormatLine("	 , NULL ")
         End If
         If Not String.IsNullOrEmpty(estadocompra) Then
            .AppendFormatLine("	 , '{0}'", estadocompra)
         Else
            .AppendFormatLine("	 , NULL ")
         End If
         .AppendFormatLine("	 ,  {0} ", cantidadProcesada)
         .AppendFormatLine("	 ,  {0} ", cantidadUnitaria)

         .AppendFormat(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub OrdenesProduccionMRPProductos_U(idSucursal As Integer,
                                              idTipoComprobante As String,
                                              letra As String,
                                              centroEmisor As Integer,
                                              numeroOrdenProduccion As Long,
                                              orden As Integer,
                                              idProducto As String,
                                              idProcesoProductivo As Long,
                                              idOperacion As Integer,
                                              idProductoProceso As String,
                                              cantidadSolicitada As Decimal,
                                              precioCostoProducto As Decimal,
                                              esProductoNecesario As Boolean,
                                              idSucursalOrigen As Integer,
                                              idDepositoOrigen As Integer,
                                              idUbicacionOrigen As Integer,
                                              cantidadProcesada As Decimal,
                                              cantidadUnitaria As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", OrdenProduccionMRPProducto.NombreTabla).AppendLine()
         .AppendFormatLine("   SET {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.CantidadSolicitada.ToString(), cantidadSolicitada)
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.PrecioCostoProducto.ToString(), precioCostoProducto)
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.CantidadProcesada.ToString(), cantidadProcesada)
         .AppendFormatLine("      ,{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.CantidadUnitaria.ToString(), cantidadUnitaria)

         If idSucursalOrigen > 0 Then
            .AppendFormatLine("      ,{0} =   {1}  ", MRPProcesoProductivoProducto.Columnas.IdSucursalOrigen.ToString(), idSucursalOrigen)
         Else
            .AppendFormatLine("      ,{0} =  NULL  ", MRPProcesoProductivoProducto.Columnas.IdSucursalOrigen.ToString())
         End If
         If idDepositoOrigen > 0 Then
            .AppendFormatLine("      ,{0} =   {1}  ", MRPProcesoProductivoProducto.Columnas.IdDepositoOrigen.ToString(), idDepositoOrigen)
         Else
            .AppendFormatLine("      ,{0} =  NULL  ", MRPProcesoProductivoProducto.Columnas.IdDepositoOrigen.ToString())
         End If
         If idUbicacionOrigen > 0 Then
            .AppendFormatLine("      ,{0} =   {1}  ", MRPProcesoProductivoProducto.Columnas.IdUbicacionOrigen.ToString(), idUbicacionOrigen)
         Else
            .AppendFormatLine("      ,{0} =  NULL  ", MRPProcesoProductivoProducto.Columnas.IdUbicacionOrigen.ToString())
         End If

         .AppendFormatLine(" WHERE {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.LetraComprobante.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdOperacion.ToString(), idOperacion)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdProductoProceso.ToString(), idProductoProceso)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.EsProductoNecesario.ToString(), GetStringFromBoolean(esProductoNecesario))
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub OrdenesProduccionMRPProductos_D(idSucursal As Integer,
                                              idTipoComprobante As String,
                                              letra As String,
                                              centroEmisor As Integer,
                                              numeroOrdenProduccion As Long,
                                              orden As Integer,
                                              idProducto As String,
                                              idProcesoProductivo As Long,
                                              idOperacion As Integer,
                                              idProductoProceso As String,
                                              esProductoNecesario As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} ", OrdenProduccionMRPProducto.NombreTabla)
         .AppendFormat(" WHERE {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.LetraComprobante.ToString(), letra).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.CentroEmisor.ToString(), centroEmisor).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.Orden.ToString(), orden).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdProducto.ToString(), idProducto).AppendLine()
         If idProcesoProductivo > 0 Then
            .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo).AppendLine()
         End If
         If idOperacion > 0 Then
            .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdOperacion.ToString(), idOperacion).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idProductoProceso) Then
            .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdProductoProceso.ToString(), idProductoProceso).AppendLine()
            .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.EsProductoNecesario.ToString(), GetStringFromBoolean(esProductoNecesario)).AppendLine()
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT OPP.*, PP.NombreProducto As NombreProductoPrincipal, PP.IdUnidadDeMedida AS UnidadMedidaPrincipal, PS.NombreProducto As NombreProductoSecundario, PS.IdUnidadDeMedida AS UnidadMedidaSecundaria FROM {0} AS OPP ", OrdenProduccionMRPProducto.NombreTabla).AppendLine()
         .AppendFormat("   INNER JOIN {0} AS PP ON PP.IdProducto = OPP.IdProducto ", Producto.NombreTabla).AppendLine()
         .AppendFormat("   INNER JOIN {0} AS PS ON PS.IdProducto = OPP.IdProductoProceso ", Producto.NombreTabla).AppendLine()
      End With
   End Sub
   Private Function OrdenesProduccionMRPProductos_G(idSucursal As Integer,
                                                    idTipoComprobante As String,
                                                    letra As String,
                                                    centroEmisor As Integer,
                                                    numeroOrdenProduccion As Long,
                                                    orden As Integer,
                                                    idProducto As String,
                                                    idProcesoProductivo As Long,
                                                    idOperacion As Integer,
                                                    idProductoProceso As String,
                                                    esProductoNecesario As Entidades.Publicos.SiNoTodos) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE OPP.{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         .AppendFormat("   AND OPP.{0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         .AppendFormat("   AND OPP.{0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.LetraComprobante.ToString(), letra).AppendLine()
         .AppendFormat("   AND OPP.{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.CentroEmisor.ToString(), centroEmisor).AppendLine()
         .AppendFormat("   AND OPP.{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.Orden.ToString(), orden).AppendLine()
         .AppendFormat("   AND OPP.{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion).AppendLine()
         .AppendFormat("   AND OPP.{0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdProducto.ToString(), idProducto).AppendLine()
         If idProcesoProductivo > 0 Then
            .AppendFormat("   AND OPP.{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo).AppendLine()
         End If
         If idOperacion > 0 Then
            .AppendFormat("   AND OPP.{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdOperacion.ToString(), idOperacion).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idProductoProceso) Then
            .AppendFormat("   AND OPP.{0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdProductoProceso.ToString(), idProductoProceso).AppendLine()
         End If
         Select Case esProductoNecesario
            Case Publicos.SiNoTodos.SI
               .AppendFormat("   AND OPP.{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.EsProductoNecesario.ToString(), GetStringFromBoolean(True)).AppendLine()
            Case Publicos.SiNoTodos.NO
               .AppendFormat("   AND OPP.{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.EsProductoNecesario.ToString(), GetStringFromBoolean(False)).AppendLine()
         End Select
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function OrdenesProduccionMRPProductos_GA(idSucursal As Integer,
                                                    idTipoComprobante As String,
                                                    letra As String,
                                                    centroEmisor As Integer,
                                                    numeroOrdenProduccion As Long,
                                                    orden As Integer,
                                                    idProducto As String,
                                                    idProcesoProductivo As Long,
                                                    idOperacion As Integer,
                                                    esNecesario As Entidades.Publicos.SiNoTodos) As DataTable
      Return OrdenesProduccionMRPProductos_G(idSucursal:=idSucursal,
                                             idTipoComprobante:=idTipoComprobante,
                                             letra:=letra,
                                             centroEmisor:=centroEmisor,
                                             numeroOrdenProduccion:=
                                             numeroOrdenProduccion,
                                             orden:=orden,
                                             idProducto:=idProducto,
                                             idProcesoProductivo:=idProcesoProductivo,
                                             idOperacion:=idOperacion,
                                             idProductoProceso:=String.Empty,
                                             esProductoNecesario:=esNecesario)
   End Function
   Public Function OrdenesProduccionMRPProductos_G1(idSucursal As Integer,
                                                    idTipoComprobante As String,
                                                    letra As String,
                                                    centroEmisor As Integer,
                                                    numeroOrdenProduccion As Long,
                                                    orden As Integer,
                                                    idProducto As String,
                                                    idProcesoProductivo As Long,
                                                    idOperacion As Integer,
                                                    idProductoProceso As String,
                                                    esProductoNecesario As Entidades.Publicos.SiNoTodos) As DataTable
      Return OrdenesProduccionMRPProductos_G(idSucursal:=idSucursal,
                                             idTipoComprobante:=idTipoComprobante,
                                             letra:=letra,
                                             centroEmisor:=centroEmisor,
                                             numeroOrdenProduccion:=
                                             numeroOrdenProduccion,
                                             orden:=orden,
                                             idProducto:=idProducto,
                                             idProcesoProductivo:=idProcesoProductivo,
                                             idOperacion:=idOperacion,
                                             idProductoProceso:=idProductoProceso,
                                             esProductoNecesario:=esProductoNecesario)
   End Function

   Public Sub VinculaOrdenProduccion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long, orden As Integer,
                                     esNecesario As Boolean, idProducto As String,
                                     idSucursalOP As Integer, idTipoComprobanteOP As String, letraOP As String, centroEmisorOP As Integer, numeroOrdenProduccionOP As Long, ordenOP As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine(" UPDATE {0}  ", OrdenProduccionMRPProducto.NombreTabla)
         .AppendFormatLine(" SET {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdSucursalOP.ToString(), idSucursalOP)
         .AppendFormatLine("   , {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdTipoComprobanteOP.ToString(), idTipoComprobanteOP)
         .AppendFormatLine("   , {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.LetraComprobanteOP.ToString(), letraOP)
         .AppendFormatLine("   , {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.CentroEmisorOP.ToString(), centroEmisorOP)
         .AppendFormatLine("   , {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdProductoOP.ToString(), idProducto)
         .AppendFormatLine("   , {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.OrdenOP.ToString(), ordenOP)
         .AppendFormatLine("   , {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.NumeroOrdenProduccionOP.ToString(), numeroOrdenProduccionOP)
         .AppendFormatLine(" WHERE {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.LetraComprobante.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdProductoProceso.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1} ", OrdenProduccionMRPProducto.Columnas.EsProductoNecesario.ToString(), GetStringFromBoolean(esNecesario))
      End With
      Execute(myQuery)
   End Sub

   Public Sub OrdenesProduccionProductos_Requerimiento_U_Anular(idRequerimientoCompra As Long, idProducto As String, ordenRQ As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat(" UPDATE {0}  ", OrdenProduccionMRPProducto.NombreTabla).AppendLine()
         .AppendFormat(" SET {0} =  NULL ", OrdenProduccionMRPProducto.Columnas.IdRequerimiento.ToString()).AppendLine()
         .AppendFormat("   , {0} =  NULL ", OrdenProduccionMRPProducto.Columnas.IdProductoRQ.ToString()).AppendLine()
         .AppendFormat("   , {0} =  NULL ", OrdenProduccionMRPProducto.Columnas.EstadoCompra.ToString()).AppendLine()
         .AppendFormat("   , {0} =  NULL ", OrdenProduccionMRPProducto.Columnas.ORdenRQ.ToString()).AppendLine()

         .AppendFormat(" WHERE {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdRequerimiento.ToString(), idRequerimientoCompra).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdProductoRQ.ToString(), idProducto).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.ORdenRQ.ToString(), ordenRQ).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub VinculaRequerimientoCompra(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Integer,
                                         numeroOrdenProduccion As Long,
                                         orden As Integer,
                                         esNecesario As Integer,
                                         idProducto As String,
                                         idRequerimientoCompra As Long, ordenRQ As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat(" UPDATE {0}  ", OrdenProduccionMRPProducto.NombreTabla).AppendLine()
         .AppendFormat(" SET {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdRequerimiento.ToString(), idRequerimientoCompra).AppendLine()
         .AppendFormat("   , {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdProductoRQ.ToString(), idProducto).AppendLine()
         .AppendFormat("   , {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.ORdenRQ.ToString(), ordenRQ).AppendLine()

         .AppendFormat(" WHERE {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.LetraComprobante.ToString(), letra).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.CentroEmisor.ToString(), centroEmisor).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.Orden.ToString(), orden).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdProductoProceso.ToString(), idProducto).AppendLine()
         .AppendFormat("   AND {0} =  {1} ", OrdenProduccionMRPProducto.Columnas.EsProductoNecesario.ToString(), esNecesario).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub ActualizarEstadoOrdenProdMRPPro(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long, orden As Integer,
                                              esNecesario As Boolean, idProducto As String,
                                              newEstado As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine(" UPDATE {0}  ", OrdenProduccionMRPProducto.NombreTabla)
         .AppendFormatLine(" SET {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.EstadoCompra.ToString(), newEstado)
         .AppendFormatLine(" WHERE {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.LetraComprobante.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion)
         .AppendFormatLine("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdProductoProceso.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1} ", OrdenProduccionMRPProducto.Columnas.EsProductoNecesario.ToString(), GetStringFromBoolean(esNecesario))
      End With
      Execute(myQuery)
   End Sub

   Public Sub ActualizarCantidadOrdProdMRPPro(idSucursal As Integer,
                                              idTipoComprobante As String,
                                              letra As String,
                                              centroEmisor As Integer,
                                              numeroOrdenProduccion As Long,
                                              orden As Integer,
                                              IdProcesoProductivio As Long,
                                              idProducto As String,
                                              idOperacion As Integer,
                                              esNecesario As Boolean,
                                              cantidadProceso As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat(" UPDATE {0}  ", OrdenProduccionMRPProducto.NombreTabla).AppendLine()
         .AppendFormat(" SET {0} = {0} + {1} ", OrdenProduccionMRPProducto.Columnas.CantidadProcesada.ToString(), cantidadProceso).AppendLine()
         .AppendFormat(" WHERE {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.LetraComprobante.ToString(), letra).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.CentroEmisor.ToString(), centroEmisor).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.Orden.ToString(), orden).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdProcesoProductivo.ToString(), IdProcesoProductivio).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdProductoProceso.ToString(), idProducto).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdOperacion.ToString(), idOperacion).AppendLine()
         .AppendFormat("   AND {0} =  {1} ", OrdenProduccionMRPProducto.Columnas.EsProductoNecesario.ToString(), GetStringFromBoolean(esNecesario)).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Function ObtieneListaNecesariosP(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer,
                                           nrocomprobante As Integer, idProcesoProductivo As Long, requerimiento As Boolean, idProductoPadre As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("SELECT PP.IdProcesoProductivo, PP.IdProductoProceso, PP.IdDepositoOrigen, P.NombreProducto, SUM(PP.CantidadSolicitada) as CantidadSolicitada ")
         .AppendLine("       , P.IdProcesoProductivoDefecto ")
         .AppendLine("       , PP.CantidadUnitaria, PP.IdProducto , MRP.Activo as ProcesoActivo")
         If Not requerimiento Then
            .AppendLine("       , SUM(MPP.TiempoTotalProceso) AS TiempoTotalProceso")
         End If
         .AppendLine(" FROM OrdenesProduccionMRPProductos PP")

         .AppendLine("      INNER JOIN Productos P ON P.IdProducto = PP.IdProductoProceso ")
         .AppendLine("      LEFT JOIN MRPProcesosProductivos MRP ON MRP.IdProcesoProductivo = P.IdProcesoProductivoDefecto AND MRP.IdProductoProceso = PP.IdProductoProceso ")

         If Not requerimiento Then
            .AppendLine("      INNER JOIN OrdenesProduccionMRP MPP")
            .AppendLine("          ON PP.IdSucursal = MPP.IdSucursal ")
            .AppendLine("         AND PP.IdTipoComprobante = MPP.IdTipoComprobante ")
            .AppendLine("         AND PP.LetraComprobante = MPP.LetraComprobante")
            .AppendLine("         AND pp.CentroEmisor = MPP.CentroEmisor ")
            .AppendLine("         AND PP.NumeroOrdenProduccion = MPP.NumeroOrdenProduccion")

            .AppendFormat("   WHERE PP.IdProcesoProductivo = {0} AND PP.EsProductoNecesario = 1 AND P.IdProcesoProductivoDefecto IS NOT NULL ", idProcesoProductivo)
         Else
            .AppendLine("	LEFT JOIN (SELECT PP.IdProductoProceso, pp.IdOperacion FROM OrdenesProduccionMRPProductos PP")
            .AppendLine("				  INNER JOIN Productos P ON P.IdProducto = PP.IdProductoProceso ")
            .AppendFormat("      WHERE PP.IdProcesoProductivo = {0} AND PP.EsProductoNecesario = 0 AND P.IdProcesoProductivoDefecto IS NULL ", idProcesoProductivo)
            .AppendFormat("   AND PP.IdSucursal = {0} AND PP.IdTipoComprobante = '{1}' ", idSucursal, idTipoComprobante)
            .AppendFormat("   AND PP.LetraComprobante = '{0}' AND PP.CentroEmisor = '{1}' ", letra, centroEmisor)
            .AppendFormat("   AND PP.NumeroOrdenProduccion = {0}", nrocomprobante)
            .AppendLine("				   GROUP BY PP.IdProcesoProductivo, PP.IdProductoProceso, PP.IdDepositoOrigen, P.NombreProducto, P.IdProcesoProductivoDefecto, PP.IdOperacion) AS RQ")
            .AppendLine("				   ON RQ.IdProductoProceso = PP.IdProductoProceso")

            .AppendFormat("   WHERE PP.IdProcesoProductivo = {0} AND PP.EsProductoNecesario = 1 AND P.IdProcesoProductivoDefecto IS NULL ", idProcesoProductivo)
            .AppendFormat("      AND RQ.IdOperacion IS NULL")
         End If
         .AppendFormat("   AND PP.IdSucursal = {0} AND PP.IdTipoComprobante = '{1}' ", idSucursal, idTipoComprobante)
         .AppendFormat("   AND PP.LetraComprobante = '{0}' AND PP.CentroEmisor = '{1}' ", letra, centroEmisor)
         .AppendFormat("   AND PP.NumeroOrdenProduccion = {0}", nrocomprobante)

         If Not String.IsNullOrWhiteSpace(idProductoPadre) Then
            .AppendFormat("   AND PP.IdProductoProceso <> '{0}'", idProductoPadre).AppendLine()
         End If

         .AppendLine(" GROUP BY PP.IdProcesoProductivo, PP.IdProductoProceso, PP.IdDepositoOrigen, P.NombreProducto, P.IdProcesoProductivoDefecto, PP.CantidadUnitaria, PP.IdProducto, MRP.Activo")

         If Not requerimiento Then
            .AppendLine(" , MPP.TiempoTotalProceso")
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ObtieneListaNecesarios(idProcesoProductivo As Long, requerimiento As Boolean, idProductoPadre As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("SELECT PP.IdProcesoProductivo, PP.IdProductoProceso, PP.IdDepositoOrigen, P.NombreProducto, SUM(PP.CantidadSolicitada) as CantidadSolicitada ")
         .AppendLine("       , P.IdProcesoProductivoDefecto ")
         .AppendLine("       , PP.CantidadSolicitada as CantidadUnitaria, MRP.IdProductoProceso as IdProducto, MRP.Activo as ProcesoActivo ")
         If Not requerimiento Then
            .AppendLine("       ,SUM(MPP.TiempoTotalProceso) AS TiempoTotalProceso")
         End If
         .AppendLine(" FROM MRPProcesosProductivosProductos PP")
         .AppendLine("      INNER JOIN Productos P ON P.IdProducto = PP.IdProductoProceso ")
         .AppendLine("      LEFT JOIN MRPProcesosProductivos MRP ON MRP.IdProcesoProductivo = PP.IdProcesoProductivo")
         If Not requerimiento Then
            .AppendLine("      INNER JOIN MRPProcesosProductivos MPP ON P.IdProcesoProductivoDefecto = MPP.IdProcesoProductivo ")
            .AppendFormat("   WHERE PP.IdProcesoProductivo = {0} AND PP.EsProductoNecesario = 1 AND P.IdProcesoProductivoDefecto IS NOT NULL ", idProcesoProductivo).AppendLine()
         Else
            .AppendFormat("   WHERE PP.IdProcesoProductivo = {0} AND PP.EsProductoNecesario = 1 AND P.IdProcesoProductivoDefecto IS NULL ", idProcesoProductivo).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idProductoPadre) Then
            .AppendFormat("   AND PP.IdProductoProceso <> '{0}'", idProductoPadre).AppendLine()
         End If
         .AppendLine(" GROUP BY PP.IdProcesoProductivo, PP.IdProductoProceso, PP.IdDepositoOrigen, P.NombreProducto, P.IdProcesoProductivoDefecto, PP.CantidadSolicitada, MRP.IdProductoProceso, MRP.Activo")

         If Not requerimiento Then
            .AppendLine(" , MPP.TiempoTotalProceso ")
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetCantidadSucursalesDepositos(IdSucursal As Integer, IdDeposito As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT COUNT(*) AS Cantidad FROM {0} as OPP", Entidades.OrdenProduccionMRPProducto.NombreTabla)

         .AppendFormatLine("   INNER JOIN OrdenesProduccionEstados OPE")
         .AppendFormatLine("   	ON  OPP.IdSucursal = OPE.IdSucursal ")
         .AppendFormatLine("   	AND OPP.NumeroOrdenProduccion = OPE.NumeroOrdenProduccion")
         .AppendFormatLine("   	AND OPP.IdTipoComprobante = OPE.IdTipoComprobante")
         .AppendFormatLine("   	AND OPP.CentroEmisor = OPE.CentroEmisor")
         .AppendFormatLine("   	AND OPP.Orden = OPE.Orden")
         .AppendFormatLine("   	AND OPP.IdProducto = OPE.IdProducto")
         .AppendFormatLine("   INNER JOIN EstadosOrdenesProduccion EOP ")
         .AppendFormatLine("   	ON OPE.IdEstado = EOP.IdEstado")

         .AppendFormatLine("     WHERE OPP.IdSucursalOrigen = {0}", IdSucursal)
         If IdDeposito <> 0 Then
            .AppendFormatLine("       AND OPP.IdDepositoOrigen = {0}", IdDeposito)
         End If
         .AppendFormatLine("     AND EOP.IdTipoEstado <> 'FINALIZADO'")
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetInformeProductos(idEstado As String, codigoProcProdOperacion As String, fechaDesde As Date?, fechaHasta As Date?,
                                       idTipoComprobante As String, letraFiscal As String, centroEmisor As Integer, numeroDesde As Long, numeroHasta As Long,
                                       idProducto As String, idCliente As Long?,
                                       idTipoComprobantePedido As String, letraFiscalPedido As String, centroEmisorPedido As Integer, numeroPedidoDesde As Long, numeroPedidoHasta As Long, lineaPedido As Integer,
                                       planMaestroNumero As Integer, esResultante As Entidades.Publicos.SiNoTodos) As DataTable
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

         .AppendFormatLine("     , OPOP.IdProductoProceso")
         .AppendFormatLine("     , PNR.NombreProducto NombreProductoProceso")
         .AppendFormatLine("     , OPOP.EsProductoNecesario")
         .AppendFormatLine("     , CASE WHEN OPOP.EsProductoNecesario = 'True' THEN 'NECESARIO' ELSE 'RESULTANTE' END AS DescriptionEsProductoNecesario")
         .AppendFormatLine("     , OPOP.CantidadSolicitada")
         .AppendFormatLine("     , OPOP.CantidadProcesada")
         .AppendFormatLine("     , OPOP.CantidadSolicitada - OPOP.CantidadProcesada AS CantidadPendiente")
         .AppendFormatLine("     , OPOP.EstadoCompra")

         .AppendFormatLine("     , OPOP.IdSucursalOP")
         .AppendFormatLine("     , OPOP.IdTipoComprobanteOP")
         .AppendFormatLine("     , TPOP.Descripcion DescripcionTipoComprobanteOP")
         .AppendFormatLine("     , OPOP.LetraComprobanteOP")
         .AppendFormatLine("     , OPOP.CentroEmisorOP")
         .AppendFormatLine("     , OPOP.NumeroOrdenProduccionOP")
         .AppendFormatLine("     , OPOP.OrdenOP")

         .AppendFormatLine("  FROM OrdenesProduccionMRPOperaciones OPO")

         .AppendFormatLine(" INNER JOIN OrdenesProduccionMRPProductos OPOP")
         .AppendFormatLine("         ON OPOP.IdSucursal = OPO.IdSucursal")
         .AppendFormatLine("        AND OPOP.IdTipoComprobante = OPO.IdTipoComprobante")
         .AppendFormatLine("        AND OPOP.LetraComprobante = OPO.LetraComprobante")
         .AppendFormatLine("        AND OPOP.CentroEmisor = OPO.CentroEmisor")
         .AppendFormatLine("        AND OPOP.NumeroOrdenProduccion = OPO.NumeroOrdenProduccion")
         .AppendFormatLine("        AND OPOP.IdProducto = OPO.IdProducto")
         .AppendFormatLine("        AND OPOP.Orden = OPO.Orden")
         .AppendFormatLine("        AND OPOP.IdProcesoProductivo = OPO.IdProcesoProductivo")
         .AppendFormatLine("        AND OPOP.IdOperacion = OPO.IdOperacion")

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
         .AppendFormatLine("  LEFT JOIN TiposComprobantes TPOP ON TPOP.IdTipoComprobante = OPOP.IdTipoComprobanteOP")
         .AppendFormatLine(" INNER JOIN Productos PNR ON PNR.IdProducto = OPOP.IdProductoProceso")
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

         If esResultante <> Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("   AND OPOP.EsProductoNecesario = {0}", GetStringFromBoolean(esResultante = Publicos.SiNoTodos.NO))
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
   Public Function OrdenesProduccionMRPProductos_GHija(idSucursal As Integer,
                                                         idTipoComprobante As String,
                                                         letra As String,
                                                         centroEmisor As Integer,
                                                         numeroOrdenProduccion As Long,
                                                         orden As Integer,
                                                         idProducto As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE OPP.{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.IdSucursalOP.ToString(), idSucursal).AppendLine()
         .AppendFormat("   AND OPP.{0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdTipoComprobanteOP.ToString(), idTipoComprobante).AppendLine()
         .AppendFormat("   AND OPP.{0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.LetraComprobanteOP.ToString(), letra).AppendLine()
         .AppendFormat("   AND OPP.{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.CentroEmisorOP.ToString(), centroEmisor).AppendLine()
         .AppendFormat("   AND OPP.{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.OrdenOP.ToString(), orden).AppendLine()
         .AppendFormat("   AND OPP.{0} =  {1}  ", OrdenProduccionMRPProducto.Columnas.NumeroOrdenProduccionOP.ToString(), numeroOrdenProduccion).AppendLine()
         .AppendFormat("   AND OPP.{0} = '{1}' ", OrdenProduccionMRPProducto.Columnas.IdProductoOP.ToString(), idProducto).AppendLine()
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class