Public Class RequerimientosComprasProductos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RequerimientosComprasProductos_I(idRequerimientoCompra As Long, idProducto As String, orden As Integer,
                                               nombreProducto As String, cantidad As Decimal, cantidadUMCompra As Decimal, factorConversionCompra As Decimal,
                                               idUnidadDeMedida As String, idUnidadDeMedidaCompra As String,
                                               fechaEntrega As Date,
                                               observacion As String,
                                               fechaAnulacion As Date?, idUsuarioAnulacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.RequerimientoCompraProducto.NombreTabla)
         .AppendFormatLine("   ( {0}", Entidades.RequerimientoCompraProducto.Columnas.IdRequerimientoCompra.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProducto.Columnas.IdProducto.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProducto.Columnas.Orden.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProducto.Columnas.NombreProducto.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProducto.Columnas.Cantidad.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProducto.Columnas.CantidadUMCompra.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProducto.Columnas.IdUnidadDeMedida.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProducto.Columnas.IdUnidadDeMedidaCompra.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProducto.Columnas.FactorConversionCompra.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProducto.Columnas.FechaEntrega.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProducto.Columnas.Observacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProducto.Columnas.FechaAnulacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.RequerimientoCompraProducto.Columnas.IdUsuarioAnulacion.ToString())
         .AppendFormatLine("   ) VALUES (")
         .AppendFormatLine("      {0} ", idRequerimientoCompra)
         .AppendFormatLine("   , '{0}'", idProducto)
         .AppendFormatLine("   ,  {0} ", orden)
         .AppendFormatLine("   , '{0}'", nombreProducto)
         .AppendFormatLine("   ,  {0} ", cantidad)
         .AppendFormatLine("   ,  {0} ", cantidadUMCompra)
         .AppendFormatLine("   , '{0}'", idUnidadDeMedida)
         .AppendFormatLine("   , '{0}'", idUnidadDeMedidaCompra)
         .AppendFormatLine("   ,  {0} ", factorConversionCompra)
         .AppendFormatLine("   , '{0}'", fechaEntrega)
         .AppendFormatLine("   , '{0}'", observacion)
         .AppendFormatLine("   ,  {0} ", ObtenerFecha(fechaAnulacion, True))
         .AppendFormatLine("   ,  {0} ", GetStringParaQueryConComillas(idUsuarioAnulacion))
         .AppendFormatLine("   )")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RequerimientosComprasProductos")
   End Sub

   Public Sub RequerimientosComprasProductos_U(idRequerimientoCompra As Long, idProducto As String, orden As Integer,
                                               nombreProducto As String, cantidad As Decimal, cantidadUMCompra As Decimal, factorConversionCompra As Decimal,
                                               idUnidadDeMedida As String, idUnidadDeMedidaCompra As String,
                                               fechaEntrega As Date,
                                               observacion As String,
                                               fechaAnulacion As Date?, idUsuarioAnulacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.RequerimientoCompraProducto.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.RequerimientoCompraProducto.Columnas.NombreProducto.ToString(), nombreProducto)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.Cantidad.ToString(), cantidad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.CantidadUMCompra.ToString(), cantidadUMCompra)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.IdUnidadDeMedida.ToString(), idUnidadDeMedida)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.IdUnidadDeMedidaCompra.ToString(), idUnidadDeMedidaCompra)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.FactorConversionCompra.ToString(), factorConversionCompra)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RequerimientoCompraProducto.Columnas.FechaEntrega.ToString(), ObtenerFecha(fechaEntrega, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.RequerimientoCompraProducto.Columnas.Observacion.ToString(), observacion)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.FechaAnulacion.ToString(), ObtenerFecha(fechaAnulacion, True))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.IdUsuarioAnulacion.ToString(), GetStringParaQueryConComillas(idUsuarioAnulacion))

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.IdRequerimientoCompra.ToString(), idRequerimientoCompra)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RequerimientoCompraProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.Orden.ToString(), orden)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RequerimientosComprasProductos")
   End Sub
   Public Sub RequerimientosComprasProductos_U_Anular(idRequerimientoCompra As Long, idProducto As String, orden As Integer,
                                                      cantidad As Decimal, fechaAnulacion As Date?, idUsuarioAnulacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.RequerimientoCompraProducto.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.Cantidad.ToString(), cantidad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.FechaAnulacion.ToString(), ObtenerFecha(fechaAnulacion, True))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.IdUsuarioAnulacion.ToString(), GetStringParaQueryConComillas(idUsuarioAnulacion))

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.IdRequerimientoCompra.ToString(), idRequerimientoCompra)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RequerimientoCompraProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.Orden.ToString(), orden)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RequerimientosComprasProductos")
   End Sub

   Public Sub RequerimientosComprasProductos_M(idRequerimientoCompra As Long, idProducto As String, orden As Integer,
                                               nombreProducto As String, cantidad As Decimal, cantidadUMCompra As Decimal, factorConversionCompra As Decimal,
                                               idUnidadDeMedida As String, idUnidadDeMedidaCompra As String,
                                               fechaEntrega As Date,
                                               observacion As String,
                                               fechaAnulacion As Date?, idUsuarioAnulacion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO RequerimientosComprasProductos AS D")
         .AppendFormatLine("        USING (SELECT  {0}  IdRequerimientoCompra,", idRequerimientoCompra)
         .AppendFormatLine("                      '{0}' IdProducto,", idProducto)
         .AppendFormatLine("                       {0}  Orden,", orden)
         .AppendFormatLine("                      '{0}' NombreProducto,", nombreProducto)
         .AppendFormatLine("                       {0}  Cantidad,", cantidad)
         .AppendFormatLine("                       {0}  CantidadUMCompra,", cantidadUMCompra)
         .AppendFormatLine("                      '{0}' IdUnidadDeMedida,", idUnidadDeMedida)
         .AppendFormatLine("                      '{0}' IdUnidadDeMedidaCompra,", idUnidadDeMedidaCompra)
         .AppendFormatLine("                       {0}  FactorConversionCompra,", factorConversionCompra)
         .AppendFormatLine("                      '{0}' FechaEntrega,", ObtenerFecha(fechaEntrega, True))
         .AppendFormatLine("                      '{0}' Observacion,", observacion)
         .AppendFormatLine("                       {0}  FechaAnulacion,", ObtenerFecha(fechaAnulacion, True))
         .AppendFormatLine("                       {0}  IdUsuarioAnulacion", GetStringParaQueryConComillas(idUsuarioAnulacion))
         .AppendFormatLine("               ) AS O ON D.IdRequerimientoCompra = O.IdRequerimientoCompra AND D.IdProducto = O.IdProducto AND D.Orden = O.Orden")
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET D.Cantidad               = O.Cantidad")
         .AppendFormatLine("                 , D.CantidadUMCompra       = O.CantidadUMCompra")
         .AppendFormatLine("                 , D.IdUnidadDeMedida       = O.IdUnidadDeMedida")
         .AppendFormatLine("                 , D.IdUnidadDeMedidaCompra = O.IdUnidadDeMedidaCompra")
         .AppendFormatLine("                 , D.NombreProducto         = O.NombreProducto")
         .AppendFormatLine("                 , D.FactorConversionCompra = O.FactorConversionCompra")
         .AppendFormatLine("                 , D.FechaEntrega           = O.FechaEntrega")
         .AppendFormatLine("                 , D.Observacion            = O.Observacion")
         .AppendFormatLine("                 , D.FechaAnulacion         = O.FechaAnulacion")
         .AppendFormatLine("                 , D.IdUsuarioAnulacion     = O.IdUsuarioAnulacion")
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT (  IdRequerimientoCompra,   IdProducto,   NombreProducto,   Orden,   Cantidad,   CantidadUMCompra,   IdUnidadDeMedida,   IdUnidadDeMedidaCompra,   FactorConversionCompra,   FechaEntrega,   Observacion,   FechaAnulacion,   IdUsuarioAnulacion)")
         .AppendFormatLine("        VALUES (O.IdRequerimientoCompra, O.IdProducto, O.NombreProducto, O.Orden, O.Cantidad, O.CantidadUMCompra, O.IdUnidadDeMedida, O.IdUnidadDeMedidaCompra, O.FactorConversionCompra, O.FechaEntrega, O.Observacion, O.FechaAnulacion, O.IdUsuarioAnulacion)")
         .AppendFormatLine(";")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RequerimientosComprasProductos")
   End Sub

   Public Sub RequerimientosComprasProductos_D(idRequerimientoCompra As Long, idProducto As String, orden As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.RequerimientoCompraProducto.NombreTabla)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.RequerimientoCompraProducto.Columnas.IdRequerimientoCompra.ToString(), idRequerimientoCompra)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RequerimientoCompraProducto.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden > 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.Orden.ToString(), orden)
         End If
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "RequerimientosComprasProductos")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RCP.*")
         .AppendFormatLine("     , RC.{0}", Entidades.RequerimientoCompra.Columnas.IdSucursal.ToString())
         .AppendFormatLine("     , RC.{0}", Entidades.RequerimientoCompra.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("     , RC.{0}", Entidades.RequerimientoCompra.Columnas.Letra.ToString())
         .AppendFormatLine("     , RC.{0}", Entidades.RequerimientoCompra.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("     , RC.{0}", Entidades.RequerimientoCompra.Columnas.NumeroRequerimiento.ToString())
         .AppendFormatLine("     , P.{0} NombreProductoOriginal", Entidades.Producto.Columnas.NombreProducto.ToString())
         .AppendFormatLine("  FROM {0} RCP", Entidades.RequerimientoCompraProducto.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} RC ON RC.{1} = RCP.{2}", Entidades.RequerimientoCompra.NombreTabla, Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString(), Entidades.RequerimientoCompraProducto.Columnas.IdRequerimientoCompra.ToString())
         .AppendFormatLine(" INNER JOIN {0} P ON P.{1} = RCP.{2}", Entidades.Producto.NombreTabla, Entidades.Producto.Columnas.IdProducto.ToString(), Entidades.RequerimientoCompraProducto.Columnas.IdProducto.ToString())
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "RCP.",
                    New Dictionary(Of String, String) From {{Entidades.Producto.Columnas.NombreProducto.ToString(), String.Format("P.{0}", Entidades.Producto.Columnas.NombreProducto.ToString())},
                                                            {Entidades.RequerimientoCompra.Columnas.IdSucursal.ToString(), String.Format("RC.{0}", Entidades.RequerimientoCompra.Columnas.IdSucursal.ToString())},
                                                            {Entidades.RequerimientoCompra.Columnas.IdTipoComprobante.ToString(), String.Format("RC.{0}", Entidades.RequerimientoCompra.Columnas.IdTipoComprobante.ToString())},
                                                            {Entidades.RequerimientoCompra.Columnas.Letra.ToString(), String.Format("RC.{0}", Entidades.RequerimientoCompra.Columnas.Letra.ToString())},
                                                            {Entidades.RequerimientoCompra.Columnas.CentroEmisor.ToString(), String.Format("RC.{0}", Entidades.RequerimientoCompra.Columnas.CentroEmisor.ToString())},
                                                            {Entidades.RequerimientoCompra.Columnas.NumeroRequerimiento.ToString(), String.Format("RC.{0}", Entidades.RequerimientoCompra.Columnas.NumeroRequerimiento.ToString())}})
   End Function

   Public Function RequerimientosComprasProductos_GA() As DataTable
      Return RequerimientosComprasProductos_GA(idRequerimientoCompra:=0)
   End Function
   Public Function RequerimientosComprasProductos_GA(idRequerimientoCompra As Long) As DataTable
      Return RequerimientosComprasProductos_G(idRequerimientoCompra, idProducto:=String.Empty, orden:=0)
   End Function
   Public Function RequerimientosComprasProductos_G(idRequerimientoCompra As Long, idProducto As String, orden As Integer) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendFormatLine(" WHERE 1 = 1")
         If idRequerimientoCompra > 0 Then
            .AppendFormatLine("   AND RCP.{0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.IdRequerimientoCompra.ToString(), idRequerimientoCompra)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND RCP.{0} = '{1}'", Entidades.RequerimientoCompraProducto.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden > 0 Then
            .AppendFormatLine("   AND RCP.{0} =  {1} ", Entidades.RequerimientoCompraProducto.Columnas.Orden.ToString(), orden)
         End If

      End With
      Return GetDataTable(stb)
   End Function

   Public Function RequerimientosComprasProductos_G1(idRequerimientoCompra As Long, idProducto As String, orden As Integer) As DataTable
      Return RequerimientosComprasProductos_G(idRequerimientoCompra, idProducto, orden)
   End Function

   Public Overloads Function GetCodigoMaximo(idRequerimientoCompra As Long) As Long
      Return GetCodigoMaximo(Entidades.RequerimientoCompraProducto.Columnas.Orden.ToString(), Entidades.RequerimientoCompraProducto.NombreTabla,
                             String.Format("{0} = {1}", Entidades.RequerimientoCompraProducto.Columnas.IdRequerimientoCompra.ToString(), idRequerimientoCompra))
   End Function

   Public Function GetParaInfRequerimietos(fechaDesde As Date?, fechaHasta As Date?, fechaEntregaDesde As Date?, fechaEntregaHasta As Date?,
                                           tiposComprobante As Entidades.TipoComprobante(), numeroRequerimiento As Long,
                                           asignados As Entidades.Publicos.SiNoTodos, idUsuario As String,
                                           idProducto As String,
                                           marcas As Entidades.Marca(), modelos As Entidades.Modelo(),
                                           rubros As Entidades.Rubro(), subrubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro()) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT RCP.*")
         .AppendFormatLine("     , P.{0} NombreProductoOriginal", Entidades.Producto.Columnas.NombreProducto.ToString())
         .AppendFormatLine("     , P.IdUnidadDeMedida")
         .AppendFormatLine("  FROM {0} RCP", Entidades.RequerimientoCompraProducto.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} RC ON RC.{1} = RCP.{2}", Entidades.RequerimientoCompra.NombreTabla, Entidades.RequerimientoCompra.Columnas.IdRequerimientoCompra.ToString(), Entidades.RequerimientoCompraProducto.Columnas.IdRequerimientoCompra.ToString())
         .AppendFormatLine(" INNER JOIN {0} P ON P.{1} = RCP.{2}", Entidades.Producto.NombreTabla, Entidades.Producto.Columnas.IdProducto.ToString(), Entidades.RequerimientoCompraProducto.Columnas.IdProducto.ToString())

         .AppendFormatLine(" WHERE 1 = 1")
         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND RC.{0} BETWEEN '{1}' AND '{2}'", Entidades.RequerimientoCompra.Columnas.Fecha.ToString(), ObtenerFecha(fechaDesde.Value, True), ObtenerFecha(fechaHasta.Value, True))
         End If
         If fechaEntregaDesde.HasValue Then
            .AppendFormatLine("   AND RCP.{0} BETWEEN '{1}' AND '{2}'", Entidades.RequerimientoCompraProducto.Columnas.FechaEntrega.ToString(), ObtenerFecha(fechaEntregaDesde.Value.Date, False), ObtenerFecha(fechaEntregaHasta.Value.UltimoSegundoDelDia(), True))
         End If

         GetListaTiposComprobantesMultiples(stb, tiposComprobante, "RC")

         If numeroRequerimiento > 0 Then
            .AppendFormatLine("   AND RC.{0} =  {1} ", Entidades.RequerimientoCompra.Columnas.NumeroRequerimiento.ToString(), numeroRequerimiento)
         End If

         'If asignados <> Entidades.Publicos.SiNoTodos.TODOS Then
         '   .AppendFormatLine("   AND {0} EXISTS(SELECT 1 FROM RequerimientosComprasProductosAsignaciones RCPA", If(asignados = Entidades.Publicos.SiNoTodos.NO, "NOT", ""))
         '   .AppendFormatLine("               WHERE RCPA.IdRequerimientoCompra = RCP.IdRequerimientoCompra")
         '   .AppendFormatLine("                 AND RCPA.IdProducto = RCP.IdProducto")
         '   .AppendFormatLine("                 AND RCPA.Orden = RCP.Orden")
         '   .AppendFormatLine("             )")
         'End If

         If Not String.IsNullOrWhiteSpace(idUsuario) Then
            .AppendFormatLine("   AND RC.{0} = '{1}'", Entidades.RequerimientoCompra.Columnas.IdUsuarioAlta.ToString(), idUsuario)
         End If

         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND P.IdProducto = '{0}'", idProducto)
         End If

         GetListaMarcasMultiples(stb, marcas, "P")
         GetListaModelosMultiples(stb, modelos, "P")
         GetListaRubrosMultiples(stb, rubros, "P")
         GetListaSubRubrosMultiples(stb, subrubros, "P")
         GetListaSubSubRubrosMultiples(stb, subSubRubros, "P")

      End With
      Return GetDataTable(stb)

   End Function

End Class