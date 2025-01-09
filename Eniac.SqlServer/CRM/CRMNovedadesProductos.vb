Public Class CRMNovedadesProductos
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT NP.*, P.nroSerie")
         .AppendFormatLine("  FROM CRMNovedadesProductos AS NP")
         .AppendFormatLine("  INNER JOIN Productos P ON P.idProducto = NP.idProducto")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Dim stb = New StringBuilder()

      columna = "NP." + columna
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub CRMNovedadesProductos_I(idTipoNovedad As String,
                                      letraNovedad As String,
                                      centroEmisor As Short,
                                      idNovedad As Long,
                                      idProducto As String,
                                      ordenProducto As Integer,
                                      nombreProducto As String,
                                      cantidadProducto As Decimal,
                                      precioProducto As Decimal,
                                      listaPrecios As Integer,
                                      stockConsumido As Boolean,
                                      IdSucursalActual As Integer,
                                      IdDepositoActual As Integer,
                                      IdUbicacionActual As Integer,
                                      IdsucursalAnterior As Integer,
                                      IdDepositoAnterior As Integer,
                                      IdUbicacionAnterior As Integer,
                                      stockReservado As Boolean)

      Dim myQuery = New StringBuilder()

      With myQuery
         '-- Carga Nombre de la tabla.- --
         .AppendFormat("INSERT INTO {0} (", Entidades.CRMNovedadProducto.NombreTabla)
         '-- Ingresa Campos.- --
         .AppendFormatLine(" {0}", Entidades.CRMNovedadProducto.Columnas.idTipoNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.IdNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.LetraNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.CentroEmisor.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.IdProducto.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.OrdenProducto.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.NombreProducto.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.CantidadProducto.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.PrecioProducto.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.IdListaPrecios.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.StockConsumidoProducto.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.IdSucursalActual.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.IdDepositoActual.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.IdUbicacionActual.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.IdsucursalAnterior.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.IdDepositoAnterior.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.IdUbicacionAnterior.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProducto.Columnas.StockReservadoProducto.ToString())
         '-- Ingresa Values.- --
         .AppendFormatLine("  ) VALUES ( ")
         '-- Ingresa Valores.- --
         .AppendFormatLine(" '{0}'", idTipoNovedad)
         .AppendFormatLine(", {0} ", idNovedad)
         .AppendFormatLine(",'{0}'", letraNovedad)
         .AppendFormatLine(", {0} ", centroEmisor)
         .AppendFormatLine(",'{0}'", idProducto)
         .AppendFormatLine(", {0} ", ordenProducto)
         .AppendFormatLine(",'{0}'", nombreProducto)
         .AppendFormatLine(", {0} ", cantidadProducto)
         .AppendFormatLine(", {0} ", precioProducto)
         .AppendFormatLine(", {0} ", listaPrecios)
         .AppendFormatLine(", {0} ", GetStringFromBoolean(stockConsumido))
         If IdSucursalActual > 0 Then
            .AppendFormatLine(", {0} ", IdSucursalActual)
         Else
            .AppendFormatLine(", NULL")
         End If
         If IdDepositoActual > 0 Then
            .AppendFormatLine(", {0} ", IdDepositoActual)
         Else
            .AppendFormatLine(", NULL")
         End If
         If IdUbicacionActual > 0 Then
            .AppendFormatLine(", {0} ", IdUbicacionActual)
         Else
            .AppendFormatLine(", NULL")
         End If
         If IdsucursalAnterior > 0 Then
            .AppendFormatLine(", {0} ", IdsucursalAnterior)
         Else
            .AppendFormatLine(", NULL")
         End If
         If IdDepositoAnterior > 0 Then
            .AppendFormatLine(", {0} ", IdDepositoAnterior)
         Else
            .AppendFormatLine(", NULL")
         End If
         If IdUbicacionAnterior > 0 Then
            .AppendFormatLine(", {0} ", IdUbicacionAnterior)
         Else
            .AppendFormatLine(", NULL")
         End If
         .AppendFormatLine(", {0} ", GetStringFromBoolean(stockReservado))
         '-- Cierra Sentencia.- --
         .AppendFormatLine(")")
      End With
      '-- Ejecuta Sentencia.- ------
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMNovedadesProductos_U(idTipoNovedad As String,
                                      letraNovedad As String,
                                      centroEmisor As Short,
                                      idNovedad As Long,
                                      idProducto As String,
                                      ordenProducto As Integer,
                                      cantidadProducto As Decimal,
                                      precioProducto As Decimal,
                                      stockConsumido As Boolean,
                                      IdSucursalActual As Integer,
                                      IdDepositoActual As Integer,
                                      IdUbicacionActual As Integer,
                                      IdsucursalAnterior As Integer,
                                      IdDepositoAnterior As Integer,
                                      IdUbicacionAnterior As Integer,
                                      stockReservado As Boolean)
      Dim myQuery = New StringBuilder()

      With myQuery
         '-- Carga Nombre de la tabla.- --
         .AppendFormat("UPDATE {0} ", Entidades.CRMNovedadProducto.NombreTabla)
         '-- Ingresa Campos.- --
         .AppendFormatLine("SET {0} = {1}", Entidades.CRMNovedadProducto.Columnas.CantidadProducto.ToString(), cantidadProducto)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProducto.Columnas.PrecioProducto.ToString(), precioProducto)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProducto.Columnas.StockConsumidoProducto.ToString(), GetStringFromBoolean(stockConsumido))
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProducto.Columnas.StockReservadoProducto.ToString(), GetStringFromBoolean(stockReservado))
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProducto.Columnas.IdSucursalActual.ToString(), IdSucursalActual)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProducto.Columnas.IdDepositoActual.ToString(), IdDepositoActual)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProducto.Columnas.IdUbicacionActual.ToString(), IdUbicacionActual)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProducto.Columnas.IdsucursalAnterior.ToString(), IdsucursalAnterior)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProducto.Columnas.IdDepositoAnterior.ToString(), IdDepositoAnterior)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProducto.Columnas.IdUbicacionAnterior.ToString(), IdUbicacionAnterior)

         '-- Ingresa WHERE.- --
         .AppendFormatLine("WHERE {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.idTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("  AND {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.LetraNovedad.ToString(), letraNovedad)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.IdNovedad.ToString(), idNovedad)
         .AppendFormatLine("  AND {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.OrdenProducto.ToString(), ordenProducto)
      End With
      '-- Ejecuta Sentencia.- ------
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMNovedadesProductos_U_StockConsumido(idTipoNovedad As String, letraNovedad As String, centroEmisor As Short, idNovedad As Long,
                                                     idProducto As String, ordenProducto As Integer,
                                                     stockConsumido As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         '-- Carga Nombre de la tabla.- --
         .AppendFormatLine("UPDATE {0} ", Entidades.CRMNovedadProducto.NombreTabla)
         '-- Ingresa Campos.- --
         .AppendFormatLine("   SET {0} = {1}", Entidades.CRMNovedadProducto.Columnas.StockConsumidoProducto.ToString(), GetStringFromBoolean(stockConsumido))
         '-- Ingresa WHERE.- --
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.idTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.LetraNovedad.ToString(), letraNovedad)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.IdNovedad.ToString(), idNovedad)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.OrdenProducto.ToString(), ordenProducto)
      End With
      '-- Ejecuta Sentencia.- ------
      Execute(myQuery)
   End Sub
   Public Sub CRMNovedadesProductos_U_StockReservado(idTipoNovedad As String, letraNovedad As String, centroEmisor As Short, idNovedad As Long,
                                                     idProducto As String, ordenProducto As Integer,
                                                     stockReservado As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         '-- Carga Nombre de la tabla.- --
         .AppendFormatLine("UPDATE {0} ", Entidades.CRMNovedadProducto.NombreTabla)
         '-- Ingresa Campos.- --
         .AppendFormatLine("   SET {0} = {1}", Entidades.CRMNovedadProducto.Columnas.StockReservadoProducto.ToString(), GetStringFromBoolean(stockReservado))
         '-- Ingresa WHERE.- --
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.idTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.LetraNovedad.ToString(), letraNovedad)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.IdNovedad.ToString(), idNovedad)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.OrdenProducto.ToString(), ordenProducto)
      End With
      '-- Ejecuta Sentencia.- ------
      Execute(myQuery)
   End Sub
   Public Sub CRMNovedadesProductos_D(idTipoNovedad As String,
                                      letraNovedad As String,
                                      centroEmisor As Short,
                                      idNovedad As Long,
                                      idProducto As String,
                                      ordenProducto As Integer)
      Dim myQuery = New StringBuilder()

      With myQuery
         '-- Carga Nombre de la tabla.- --
         .AppendFormat("DELETE FROM {0} ", Entidades.CRMNovedadProducto.NombreTabla)
         '-- Ingresa Campos.- --
         .AppendFormatLine("WHERE {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.idTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("  AND {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.LetraNovedad.ToString(), letraNovedad)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.IdNovedad.ToString(), idNovedad)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("  AND {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.IdProducto.ToString(), idProducto)
         End If
         If ordenProducto <> 0 Then
            .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.OrdenProducto.ToString(), ordenProducto)
         End If
      End With
      '-- Ejecuta Sentencia.- ------
      Execute(myQuery)
   End Sub

   Public Function CRMNovedadesProductos_GA(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine("   AND NP.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND NP.LetraNovedad = '{0}'", letra)
         End If
         If idNovedad > 0 Then
            .AppendFormatLine("   AND NP.CentroEmisor = {0}", centroEmisor)
         End If
         If idNovedad > 0 Then
            .AppendFormatLine("   AND NP.IdNovedad = {0}", idNovedad)
         End If

         .AppendFormatLine(" ORDER BY NP.IdTipoNovedad, NP.IdNovedad, NP.OrdenProducto ASC")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Sub CRMNovedadesProductos_U_Depositos(idTipoNovedad As String, letraNovedad As String, centroEmisor As Short, idNovedad As Long,
                                                   idProducto As String, ordenProducto As Integer,
                                                     IdSucursalActual As Integer,
                                                     IdDepositoActual As Integer,
                                                     IdUbicacionActual As Integer,
                                                     IdsucursalAnterior As Integer,
                                                     IdDepositoAnterior As Integer,
                                                     IdUbicacionAnterior As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         '-- Carga Nombre de la tabla.- --
         .AppendFormatLine("UPDATE {0} ", Entidades.CRMNovedadProducto.NombreTabla)
         '-- Ingresa Campos.- --
         .AppendFormatLine("   SET {0} = {1}", Entidades.CRMNovedadProducto.Columnas.IdSucursalActual.ToString(), IdSucursalActual)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProducto.Columnas.IdDepositoActual.ToString(), IdDepositoActual)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProducto.Columnas.IdUbicacionActual.ToString(), IdUbicacionActual)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProducto.Columnas.IdsucursalAnterior.ToString(), IdsucursalAnterior)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProducto.Columnas.IdDepositoAnterior.ToString(), IdDepositoAnterior)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProducto.Columnas.IdUbicacionAnterior.ToString(), IdUbicacionAnterior)
         '-- Ingresa WHERE.- --
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.idTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.LetraNovedad.ToString(), letraNovedad)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.IdNovedad.ToString(), idNovedad)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.OrdenProducto.ToString(), ordenProducto)
      End With
      '-- Ejecuta Sentencia.- ------
      Execute(myQuery)
   End Sub
End Class
