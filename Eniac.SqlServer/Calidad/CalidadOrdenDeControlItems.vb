Public Class CalidadOrdenDeControlItems
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CalidadOrdenDeControlItems_I(IdSucursal As Integer, IdTipoComprobante As String, Letra As String, CentroEmisor As Integer,
                                           NumeroComprobante As Long, IdListaControl As Integer, IdListaControlItem As Integer,
                                           nivelInspeccion As Entidades.NivelInspeccionMRP, ValorAQL As Decimal, IdMRPAQLA As Integer,
                                           CodigoNivel As String, TamanoMuestreo As Integer, CantidadAceptacion As Integer, CantidadRechazo As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CalidadOrdenDeControlItem.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.CalidadOrdenDeControlItem.Columnas.IdSucursal.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControlItem.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControlItem.Columnas.Letra.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControlItem.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControlItem.Columnas.NumeroComprobante.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControlItem.Columnas.IdListaControl.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControlItem.Columnas.IdListaControlItem.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControlItem.Columnas.NivelInspeccion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControlItem.Columnas.ValorAQL.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControlItem.Columnas.IdMRPAQLA.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControlItem.Columnas.CodigoNivel.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControlItem.Columnas.TamanoMuestreo.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControlItem.Columnas.CantidadAceptacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadOrdenDeControlItem.Columnas.CantidadRechazo.ToString())
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	    {0} ", IdSucursal)
         .AppendFormatLine("	 , '{0}'", IdTipoComprobante)
         .AppendFormatLine("	 , '{0}'", Letra)
         .AppendFormatLine("	 ,  {0} ", CentroEmisor)
         .AppendFormatLine("	 ,  {0} ", NumeroComprobante)
         .AppendFormatLine("	 ,  {0} ", IdListaControl)
         .AppendFormatLine("	 ,  {0} ", IdListaControlItem)
         .AppendFormatLine("	 , '{0}'", nivelInspeccion.ToString())
         .AppendFormatLine("	 ,  {0} ", ValorAQL)
         .AppendFormatLine("	 ,  {0} ", IdMRPAQLA)
         .AppendFormatLine("	 , '{0}'", CodigoNivel)
         .AppendFormatLine("	 ,  {0} ", TamanoMuestreo)
         .AppendFormatLine("	 ,  {0} ", CantidadAceptacion)
         .AppendFormatLine("	 ,  {0} ", CantidadRechazo)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub
   Public Sub CalidadOrdenDeControlItems_U(IdSucursal As Integer, IdTipoComprobante As String, Letra As String, CentroEmisor As Integer,
                                           NumeroComprobante As Long, IdListaControl As Integer, IdListaControlItem As Integer,
                                           nivelInspeccion As Entidades.NivelInspeccionMRP, ValorAQL As Decimal, IdMRPAQLA As Integer,
                                           CodigoNivel As String, TamanoMuestreo As Integer, CantidadAceptacion As Integer, CantidadRechazo As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.CalidadOrdenDeControlItem.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CalidadOrdenDeControlItem.Columnas.NivelInspeccion.ToString(), nivelInspeccion.ToString())
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.ValorAQL.ToString(), ValorAQL)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.IdMRPAQLA.ToString(), IdMRPAQLA)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CalidadOrdenDeControlItem.Columnas.CodigoNivel.ToString(), CodigoNivel)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.TamanoMuestreo.ToString(), TamanoMuestreo)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.CantidadAceptacion.ToString(), CantidadAceptacion)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.CantidadRechazo.ToString(), CantidadRechazo)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.IdSucursal.ToString(), IdSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CalidadOrdenDeControlItem.Columnas.IdTipoComprobante.ToString(), IdTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CalidadOrdenDeControlItem.Columnas.Letra.ToString(), Letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.CentroEmisor.ToString(), CentroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.NumeroComprobante.ToString(), NumeroComprobante)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.IdListaControl.ToString(), IdListaControl)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.IdListaControlItem.ToString(), IdListaControlItem)
      End With
      Execute(myQuery)
   End Sub

   Public Sub CalidadOrdenDeControlItems_D(IdSucursal As Integer, IdTipoComprobante As String, Letra As String, CentroEmisor As Integer,
                                           NumeroComprobante As Long, IdListaControl As Integer, IdListaControlItem As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CalidadOrdenDeControlItem.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.IdSucursal.ToString(), IdSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CalidadOrdenDeControlItem.Columnas.IdTipoComprobante.ToString(), IdTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CalidadOrdenDeControlItem.Columnas.Letra.ToString(), Letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.CentroEmisor.ToString(), CentroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.NumeroComprobante.ToString(), NumeroComprobante)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.IdListaControl.ToString(), IdListaControl)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.IdListaControlItem.ToString(), IdListaControlItem)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CCI.*, CLC.NombreListaControl, CLI.NombreListaControlItem, CLI.Observacion ")
         .AppendFormatLine("  FROM {0} AS CCI", Entidades.CalidadOrdenDeControlItem.NombreTabla)
         .AppendFormatLine("  	INNER JOIN {0} AS CLC ON CCI.idListaControl = CLC.IdListaControl ", Entidades.CalidadListaControl.NombreTabla)
         .AppendFormatLine("  	INNER JOIN {0} AS CLI ON CCI.IdListaControlItem = CLI.IdListaControlItem ", Entidades.CalidadListaControlItem.NombreTabla)
      End With
   End Sub
   Private Function CalidadOrdenDeControlItems_G(IdSucursal As Integer, IdTipoComprobante As String, Letra As String, CentroEmisor As Integer,
                                                 NumeroComprobante As Long, IdListaControl As Integer, IdListaControlItem As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.CalidadOrdenDeControlItem.Columnas.IdSucursal.ToString(), IdSucursal)

         If Not String.IsNullOrWhiteSpace(IdTipoComprobante) Then
            .AppendFormatLine("   AND CCI.{0} = '{1}'", Entidades.CalidadOrdenDeControlItem.Columnas.IdTipoComprobante.ToString(), IdTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(Letra) Then
            .AppendFormatLine("   AND CCI.{0} = '{1}'", Entidades.CalidadOrdenDeControlItem.Columnas.Letra.ToString(), Letra)
         End If
         If CentroEmisor > 0 Then
            .AppendFormatLine("   AND CCI.{0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.CentroEmisor.ToString(), CentroEmisor)
         End If
         If NumeroComprobante > 0 Then
            .AppendFormatLine("   AND CCI.{0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.NumeroComprobante.ToString(), NumeroComprobante)
         End If
         If IdListaControl > 0 Then
            .AppendFormatLine("   AND CCI.{0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.IdListaControl.ToString(), IdListaControl)
         End If
         If IdListaControlItem > 0 Then
            .AppendFormatLine("   AND CCI.{0} =  {1} ", Entidades.CalidadOrdenDeControlItem.Columnas.IdListaControlItem.ToString(), IdListaControlItem)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function CalidadOrdenDeControlItems_G1(IdSucursal As Integer, IdTipoComprobante As String, Letra As String, CentroEmisor As Integer,
                                                 NumeroComprobante As Long, IdListaControl As Integer, IdListaControlItem As Integer) As DataTable
      Return CalidadOrdenDeControlItems_G(IdSucursal:=IdSucursal, IdTipoComprobante:=IdTipoComprobante, Letra:=Letra, CentroEmisor:=CentroEmisor,
                                          NumeroComprobante:=NumeroComprobante, IdListaControl:=IdListaControl, IdListaControlItem:=IdListaControlItem)
   End Function
   Public Function CalidadOrdenDeControlItems_GA() As DataTable
      Return CalidadOrdenDeControlItems_G(IdSucursal:=0, IdTipoComprobante:=Nothing, Letra:=Nothing, CentroEmisor:=0, NumeroComprobante:=0,
                                          IdListaControl:=0, IdListaControlItem:=0)
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "CCI.")
   End Function

   Public Function GetCalidadOrdenControlItemXEstados(sucursales As Entidades.Sucursal(), estadosOrdenes As Entidades.EstadoOrdenCalidad(), fechaDesde As Date?, fechaHasta As Date?,
                                                 listaComprobantes As Entidades.TipoComprobante(), numeroOrdenCalidad As Long, idProducto As String,
                                                 idProveedor As Long, idUsuario As String, idListaControl As Integer, idlistaControlItem As Integer) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendLine("SELECT COC.IdSucursal")
         .AppendLine("     , COC.IdTipoComprobante")
         .AppendLine("     , TCT.Descripcion AS DescripcionComprobante")
         .AppendLine("     , COC.Letra")
         .AppendLine("     , COC.CentroEmisor")
         .AppendLine("     , COC.NumeroComprobante")
         .AppendLine("     , COC.Fecha")
         '--
         .AppendLine("     , COI.IdListaControl")
         .AppendLine("     , CLC.NombreListaControl")
         .AppendLine("     , COI.IdListaControlItem")
         .AppendLine("     , CLI.NombreListaControlItem")
         .AppendLine("     , COI.NivelInspeccion")
         .AppendLine("     , COI.ValorAQL")
         .AppendLine("     , COI.IdMRPAQLA")
         .AppendLine("     , COI.CodigoNivel")
         .AppendLine("     , COI.TamanoMuestreo")
         .AppendLine("     , COI.CantidadAceptacion")
         .AppendLine("     , COI.CantidadRechazo")
         '--
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
         '---
         .AppendLine(" INNER JOIN CalidadOrdenDeControlItems AS COI")
         .AppendLine("    ON COI.IdSucursal = COC.IdSucursal")
         .AppendLine("   AND COI.IdTipoComprobante = COC.IdTipoComprobante")
         .AppendLine("   AND COI.Letra = COC.Letra")
         .AppendLine("   AND COI.CentroEmisor = COC.CentroEmisor")
         .AppendLine("   AND COI.NumeroComprobante = COC.NumeroComprobante")
         .AppendLine(" INNER JOIN CalidadListasControl CLC ON CLC.IdListaControl = COI.idListaControl")
         .AppendLine(" INNER JOIN CalidadListasControlItems CLI ON CLI.IdListaControlItem = COI.IdListaControlItem")

         '---
         .AppendLine(" INNER JOIN TiposComprobantes AS TCT ON TCT.IdTipoComprobante = COC.IdTipoComprobante")
         .AppendLine("  LEFT JOIN TiposComprobantes AS TCC ON TCC.IdTipoComprobante = COC.IdTipoComprobanteCompra")
         .AppendLine("  LEFT JOIN Proveedores AS PRV ON PRV.IdProveedor = COC.IdProveedor")
         .AppendLine(" INNER JOIN Productos AS PRD ON PRD.IdProducto = COC.IdProducto")
         .AppendLine(" INNER JOIN EstadosOrdenesCalidad EOC ON EOC.IdEstadoCalidad = COC.IdEstadoCalidad")
         .AppendLine("  LEFT JOIN SucursalesDepositos AS SUD")
         .AppendLine("    ON SUD.IdSucursal = COC.IdSucursal AND SUD.IdDeposito = COC.IdDeposito")
         .AppendLine("  LEFT JOIN SucursalesUbicaciones AS SUU")
         .AppendLine("    ON SUU.IdSucursal = COC.IdSucursal AND SUU.IdDeposito = COC.IdDeposito AND SUU.IdUbicacion = COC.IdUbicacion")

         .AppendLine(" WHERE 1 = 1 ")
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
         '--
         If idListaControl > 0 Then
            .AppendFormatLine("   AND COI.IdListaControl = {0}", idListaControl)
         End If
         If idlistaControlItem > 0 Then
            .AppendFormatLine("   AND COI.IdListaControlItem = {0}", idlistaControlItem)
         End If
         '--
         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendFormatLine("    and COC.IdUsuarioAlta = '{0}'", idUsuario)
         End If

         .AppendLine(" ORDER BY COC.IdSucursal, TCT.Descripcion, COC.Letra, COC.CentroEmisor, COC.NumeroComprobante")

      End With
      Return GetDataTable(stbQuery)
   End Function
End Class
