Public Class CalidadOrdenDeControl
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CalidadOrdenDeControl_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                      fecha As Date, idProducto As String,
                                      idDeposito As Integer?, idUbicacion As Integer?, idLote As String,
                                      idProveedor As Long?, idSucursalCompra As Integer?, idTipoComprobanteCompra As String, letraCompra As String, centroEmisorCompra As Integer?, numeroComprobanteCompra As Long?, ordenComprobanteCompra As Integer?,
                                      cantidadControlar As Decimal, idEstadoCalidad As String, observaciones As String,
                                      idUsuarioAlta As String, fechaAlta As Date, idUsuarioActualizacion As String, fechaActualizacion As Date)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CalidadOrdenDeControl.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.CalidadOrdenDeControl.Columnas.IdSucursal.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.Letra.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.NumeroComprobante.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.Fecha.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.IdProducto.ToString())

         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.IdDeposito.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.IdUbicacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.IdLote.ToString())

         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.IdProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.IdSucursalCompra.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.IdTipoComprobanteCompra.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.LetraCompra.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.CentroEmisorCompra.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.NumeroComprobanteCompra.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.OrdenComprobanteCompra.ToString())

         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.CantidadControlar.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.IdEstadoCalidad.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.Observaciones.ToString())

         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.IdUsuarioAlta.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.FechaAlta.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.IdUsuarioActualizacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControl.Columnas.FechaActualizacion.ToString())

         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	    {0} ", idSucursal)
         .AppendFormatLine("	 , '{0}'", idTipoComprobante)
         .AppendFormatLine("	 , '{0}'", letra)
         .AppendFormatLine("	 ,  {0} ", centroEmisor)
         .AppendFormatLine("	 ,  {0} ", numeroComprobante)
         .AppendFormatLine("	 , '{0}'", ObtenerFecha(fecha, True))
         .AppendFormatLine("	 , '{0}'", idProducto)

         .AppendFormatLine("	 ,  {0} ", GetStringFromNumber(idDeposito))
         .AppendFormatLine("	 ,  {0} ", GetStringFromNumber(idUbicacion))
         .AppendFormatLine("	 ,  {0} ", GetStringParaQueryConComillas(idLote))

         .AppendFormatLine("	 ,  {0} ", GetStringFromNumber(idProveedor))
         .AppendFormatLine("	 ,  {0} ", GetStringFromNumber(idSucursalCompra))
         .AppendFormatLine("	 ,  {0} ", GetStringParaQueryConComillas(idTipoComprobanteCompra))
         .AppendFormatLine("	 ,  {0} ", GetStringParaQueryConComillas(letraCompra))
         .AppendFormatLine("	 ,  {0} ", GetStringFromNumber(centroEmisorCompra))
         .AppendFormatLine("	 ,  {0} ", GetStringFromNumber(numeroComprobanteCompra))
         .AppendFormatLine("	 ,  {0} ", GetStringFromNumber(ordenComprobanteCompra))

         .AppendFormatLine("	 ,  {0} ", cantidadControlar)
         .AppendFormatLine("	 , '{0}'", idEstadoCalidad)
         .AppendFormatLine("	 , '{0}'", observaciones)

         .AppendFormatLine("	 , '{0}'", idUsuarioAlta)
         .AppendFormatLine("	 , '{0}'", ObtenerFecha(fechaAlta, True))
         .AppendFormatLine("	 , '{0}'", idUsuarioActualizacion)
         .AppendFormatLine("	 , '{0}'", ObtenerFecha(fechaActualizacion, True))

         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub
   Public Sub CalidadOrdenDeControl_U(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                      fecha As Date, idProducto As String,
                                      idDeposito As Integer?, idUbicacion As Integer?, idLote As String,
                                      idProveedor As Long?, idSucursalCompra As Integer?, idTipoComprobanteCompra As String, letraCompra As String, centroEmisorCompra As Integer?, numeroComprobanteCompra As Long?, ordenComprobanteCompra As Integer?,
                                      cantidadControlar As Decimal, idEstadoCalidad As String, observaciones As String,
                                      idUsuarioAlta As String, fechaAlta As Date, idUsuarioActualizacion As String, fechaActualizacion As Date)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.CalidadOrdenDeControl.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CalidadOrdenDeControl.Columnas.Fecha.ToString(), ObtenerFecha(fecha, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CalidadOrdenDeControl.Columnas.IdProducto.ToString(), idProducto)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.IdDeposito.ToString(), GetStringFromNumber(idDeposito))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.IdUbicacion.ToString(), GetStringFromNumber(idUbicacion))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.IdLote.ToString(), GetStringParaQueryConComillas(idLote))


         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.IdProveedor.ToString(), GetStringFromNumber(idProveedor))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.IdSucursalCompra.ToString(), GetStringFromNumber(idSucursalCompra))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.IdTipoComprobanteCompra.ToString(), GetStringParaQueryConComillas(idTipoComprobanteCompra))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.LetraCompra.ToString(), GetStringParaQueryConComillas(letraCompra))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.CentroEmisorCompra.ToString(), GetStringFromNumber(centroEmisorCompra))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.NumeroComprobanteCompra.ToString(), GetStringFromNumber(numeroComprobanteCompra))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.OrdenComprobanteCompra.ToString(), GetStringFromNumber(ordenComprobanteCompra))


         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.CantidadControlar.ToString(), cantidadControlar)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CalidadOrdenDeControl.Columnas.IdEstadoCalidad.ToString(), idEstadoCalidad)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CalidadOrdenDeControl.Columnas.Observaciones.ToString(), observaciones)

         .AppendFormatLine("     , {0} = '{1}'", Entidades.CalidadOrdenDeControl.Columnas.IdUsuarioAlta.ToString(), idUsuarioAlta)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CalidadOrdenDeControl.Columnas.FechaAlta.ToString(), ObtenerFecha(fechaAlta, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CalidadOrdenDeControl.Columnas.IdUsuarioActualizacion.ToString(), idUsuarioActualizacion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CalidadOrdenDeControl.Columnas.FechaActualizacion.ToString(), ObtenerFecha(fechaActualizacion, True))

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CalidadOrdenDeControl.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CalidadOrdenDeControl.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.NumeroComprobante.ToString(), numeroComprobante)
      End With
      Execute(myQuery)
   End Sub
   Public Sub CalidadOrdenDeControl_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CalidadOrdenDeControl.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CalidadOrdenDeControl.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CalidadOrdenDeControl.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.NumeroComprobante.ToString(), numeroComprobante)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT COC.*")
         .AppendFormatLine("     , PRV.NombreProveedor")
         .AppendFormatLine("     , PRO.NombreProducto")
         .AppendFormatLine("     , SUD.NombreDeposito")
         .AppendFormatLine("     , SUU.NombreUbicacion")
         .AppendFormatLine("     , TC.Descripcion DescripcionComprobante")
         .AppendFormatLine("     , TCC.Descripcion DescripcionComprobanteCompra")
         .AppendFormatLine("     , UAL.Nombre NombreUsuarioAlta")
         .AppendFormatLine("     , UAC.Nombre NombreUsuarioActualizacion")
         .AppendFormatLine("     , TC.Descripcion DescripcionComprobante")
         .AppendFormatLine("  FROM {0} AS COC", Entidades.CalidadOrdenDeControl.NombreTabla)
         .AppendFormatLine(" INNER JOIN TiposComprobantes AS TC ON TC.IdTipoComprobante = COC.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN {0} AS PRO ON COC.IdProducto = PRO.IdProducto ", Entidades.Producto.NombreTabla)
         .AppendFormatLine(" INNER JOIN Usuarios AS UAL ON UAL.Id = COC.{0}", Entidades.CalidadOrdenDeControl.Columnas.IdUsuarioAlta.ToString())
         .AppendFormatLine(" INNER JOIN Usuarios AS UAC ON UAC.Id = COC.{0}", Entidades.CalidadOrdenDeControl.Columnas.IdUsuarioActualizacion.ToString())
         .AppendFormatLine("  LEFT JOIN TiposComprobantes AS TCC ON TC.IdTipoComprobante = COC.IdTipoComprobanteCompra")
         .AppendFormatLine("  LEFT JOIN {0} AS PRV ON COC.IdProveedor = PRV.IdProveedor ", Entidades.Proveedor.NombreTabla)
         .AppendFormatLine("  LEFT JOIN {0} AS SUD ON COC.IdSucursal = SUD.IdSucursal AND COC.IdDeposito = SUD.IdDeposito ", Entidades.SucursalDeposito.NombreTabla)
         .AppendFormatLine("  LEFT JOIN {0} AS SUU ON COC.IdSucursal = SUU.IdSucursal AND COC.IdDeposito = SUU.IdDeposito AND COC.IdUbicacion = SUU.IdUbicacion", Entidades.SucursalUbicacion.NombreTabla)

      End With
   End Sub

   Private Function CalidadOrdenDeControl_G(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1 ")
         If idSucursal > 0 Then
            .AppendFormatLine("   AND COC.{0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND COC.{0} = '{1}'", Entidades.CalidadOrdenDeControl.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND COC.{0} = '{1}'", Entidades.CalidadOrdenDeControl.Columnas.Letra.ToString(), letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("   AND COC.{0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.CentroEmisor.ToString(), centroEmisor)
         End If
         If numeroComprobante > 0 Then
            .AppendFormatLine("   AND COC.{0} =  {1} ", Entidades.CalidadOrdenDeControl.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function CalidadOrdenDeControl_G1(IdSucursal As Integer, IdTipoComprobante As String, Letra As String,
                                            CentroEmisor As Integer, NumeroComprobante As Long) As DataTable
      Return CalidadOrdenDeControl_G(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante)
   End Function
   Public Function CalidadOrdenDeControl_GA() As DataTable
      Return CalidadOrdenDeControl_G(IdSucursal:=0, IdTipoComprobante:=Nothing, Letra:=Nothing, CentroEmisor:=0,
                                     NumeroComprobante:=0)
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "COC.")
   End Function

   Public Function GetCalidadOrdenDeControlXEstados(sucursales As Entidades.Sucursal(), estadosOrdenes As Entidades.EstadoOrdenCalidad(), fechaDesde As Date?, fechaHasta As Date?,
                                                    listaComprobantes As Entidades.TipoComprobante(), numeroOrdenCalidad As Long, idProducto As String,
                                                    idProveedor As Long, idUsuario As String) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT    '' as Visualizar, COC.IdSucursal")
         .AppendLine("     , COC.IdTipoComprobante")
         .AppendLine("     , TCT.Descripcion AS DescripcionComprobante")
         .AppendLine("     , COC.Letra")
         .AppendLine("     , COC.CentroEmisor")
         .AppendLine("     , COC.NumeroComprobante")
         .AppendLine("     , COC.Fecha")
         .AppendLine("     , COC.IdProveedor")
         .AppendLine("     , PRV.CodigoProveedor")
         .AppendLine("     , PRV.NombreProveedor")
         .AppendLine("     , COC.IdProducto")
         .AppendLine("     , PRD.NombreProducto")
         .AppendLine("     , COC.CantidadControlar")
         .AppendLine("     , COC.IdLote")
         .AppendLine("     , COC.IdDeposito")
         .AppendLine("     , SUD.CodigoDeposito")
         .AppendLine("     , SUD.NombreDeposito")
         .AppendLine("     , COC.IdUbicacion")
         .AppendLine("     , SUU.CodigoUbicacion")
         .AppendLine("     , SUU.NombreUbicacion")
         .AppendLine("     , COC.IdEstadoCalidad")
         .AppendLine("     , COC.IdUsuarioAlta")
         .AppendLine("     , COC.FechaAlta")
         .AppendLine("     , COC.IdUsuarioActualizacion")
         .AppendLine("     , COC.FechaActualizacion")
         .AppendLine("     , COC.Observaciones")

         .AppendLine("     , COC.IdSucursalCompra")
         .AppendLine("     , COC.IdTipoComprobanteCompra")
         .AppendLine("     , TCC.Descripcion AS DescripcionComprobanteCompra")
         .AppendLine("     , COC.LetraCompra")
         .AppendLine("     , COC.CentroEmisorCompra")
         .AppendLine("     , COC.NumeroComprobanteCompra")
         .AppendLine("     , COC.OrdenComprobanteCompra")

         .AppendLine("  FROM CalidadOrdenDeControl COC")
         .AppendLine("  	INNER JOIN TiposComprobantes AS TCT ON TCT.IdTipoComprobante = COC.IdTipoComprobante")
         .AppendLine("   LEFT JOIN TiposComprobantes AS TCC ON TCC.IdTipoComprobante = COC.IdTipoComprobanteCompra")
         .AppendLine("   LEFT JOIN Proveedores AS PRV ON PRV.IdProveedor = COC.IdProveedor")
         .AppendLine("  	INNER JOIN Productos AS PRD ON PRD.IdProducto = COC.IdProducto")
         .AppendLine("     INNER JOIN EstadosOrdenesCalidad EOC ON EOC.IdEstadoCalidad = COC.IdEstadoCalidad")
         .AppendLine("   LEFT JOIN SucursalesDepositos AS SUD ")
         .AppendLine("  		ON SUD.IdSucursal = COC.IdSucursal AND SUD.IdDeposito = COC.IdDeposito")
         .AppendLine("   LEFT JOIN SucursalesUbicaciones AS SUU ")
         .AppendLine("  		ON SUU.IdSucursal = COC.IdSucursal AND SUU.IdDeposito = COC.IdDeposito AND SUU.IdUbicacion = COC.IdUbicacion")

         .AppendLine(" WHERE 1 = 1")
         GetListaSucursalesMultiples(stbQuery, sucursales, "COC")
         GetListaTiposComprobantesMultiples(stbQuery, listaComprobantes, "COC")
         GetListaEstadosOrdenCalidadMultiples(stbQuery, estadosOrdenes, "COC")

         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND COC.Fecha >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
            .AppendFormatLine("   AND COC.Fecha <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If

         If numeroOrdenCalidad > 0 Then
            .AppendFormatLine("   AND COC.NumeroComprobante = {0}", numeroOrdenCalidad)
         End If

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("   AND COC.IdProducto = '{0}'", idProducto)
         End If

         If idProveedor > 0 Then
            .AppendFormatLine("   AND COC.IdProveedor = {0}", idProveedor)
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendFormatLine("    and COC.IdUsuarioAlta = '{0}'", idUsuario)
         End If

         .AppendLine(" ORDER BY COC.IdSucursal, TCT.Descripcion, COC.Letra, COC.CentroEmisor, COC.NumeroComprobante")

      End With
      Return GetDataTable(stbQuery)
   End Function
End Class