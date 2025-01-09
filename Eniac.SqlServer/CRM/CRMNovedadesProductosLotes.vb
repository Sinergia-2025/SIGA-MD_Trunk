Public Class CRMNovedadesProductosLotes
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT NPL.*")
         .AppendFormatLine("  FROM CRMNovedadesProductosLotes AS NPL")
         '   .AppendFormatLine("  INNER JOIN Productos P ON P.idProducto = NP.idProducto")
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

   Public Sub CRMNovedadesProductosLotes_I(idTipoNovedad As String,
                                      letraNovedad As String,
                                      centroEmisor As Short,
                                      idNovedad As Long,
                                      idProducto As String,
                                      ordenProducto As Integer,
                                      IdLote As String,
                                      fechaIngreso As Date,
                                      fechaVencimiento As Date,
                                      cantidadActual As Decimal,
                                      IdSucursal As Integer,
                                      IdDeposito As Integer,
                                      IdUbicacion As Integer)

      Dim myQuery = New StringBuilder()

      With myQuery
         '-- Carga Nombre de la tabla.- --
         .AppendFormat("INSERT INTO {0} (", Entidades.CRMNovedadProductoLote.NombreTabla)
         '-- Ingresa Campos.- --
         .AppendFormatLine(" {0}", Entidades.CRMNovedadProductoLote.Columnas.idTipoNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoLote.Columnas.IdNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoLote.Columnas.LetraNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoLote.Columnas.CentroEmisor.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoLote.Columnas.IdProducto.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoLote.Columnas.OrdenProducto.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoLote.Columnas.IdLote.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoLote.Columnas.FechaIngreso.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoLote.Columnas.FechaVencimiento.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoLote.Columnas.CantidadActual.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoLote.Columnas.IdSucursal.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoLote.Columnas.IdDeposito.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoLote.Columnas.IdUbicacion.ToString())

         '-- Ingresa Values.- --
         .AppendFormatLine("  ) VALUES ( ")
         '-- Ingresa Valores.- --
         .AppendFormatLine(" '{0}'", idTipoNovedad)
         .AppendFormatLine(", {0} ", idNovedad)
         .AppendFormatLine(",'{0}'", letraNovedad)
         .AppendFormatLine(", {0} ", centroEmisor)
         .AppendFormatLine(",'{0}'", idProducto)
         .AppendFormatLine(", {0} ", ordenProducto)
         .AppendFormatLine(",'{0}'", IdLote)
         .AppendFormatLine(", '{0}' ", ObtenerFecha(fechaIngreso, True))
         .AppendFormatLine(", '{0}'", ObtenerFecha(fechaVencimiento, True))
         .AppendFormatLine(", {0} ", cantidadActual)
         .AppendFormatLine(", {0} ", IdSucursal)
         .AppendFormatLine(", {0} ", IdDeposito)
         .AppendFormatLine(", {0} ", IdUbicacion)

         '-- Cierra Sentencia.- --
         .AppendFormatLine(")")
      End With
      '-- Ejecuta Sentencia.- ------
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMNovedadesProductosLotes_U(idTipoNovedad As String,
                                      letraNovedad As String,
                                      centroEmisor As Short,
                                      idNovedad As Long,
                                      idProducto As String,
                                      ordenProducto As Integer,
                                      IdLote As String,
                                      fechaIngreso As Date,
                                      fechaVencimiento As Date,
                                      cantidadActual As Decimal,
                                      IdSucursal As Integer,
                                      IdDeposito As Integer,
                                      IdUbicacion As Integer)

      Dim myQuery = New StringBuilder()

      With myQuery
         '-- Carga Nombre de la tabla.- --
         .AppendFormat("UPDATE {0} ", Entidades.CRMNovedadProductoLote.NombreTabla)
         '-- Ingresa Campos.- --
         .AppendFormatLine("SET {0} = '{1}'", Entidades.CRMNovedadProductoLote.Columnas.FechaIngreso.ToString(), ObtenerFecha(fechaIngreso, True))
         .AppendFormatLine("   ,{0} = '{1}'", Entidades.CRMNovedadProductoLote.Columnas.FechaVencimiento.ToString(), ObtenerFecha(fechaVencimiento, True))
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProductoLote.Columnas.CantidadActual.ToString(), cantidadActual)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProductoLote.Columnas.IdSucursal.ToString(), IdSucursal)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProductoLote.Columnas.IdDeposito.ToString(), IdDeposito)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProductoLote.Columnas.IdUbicacion.ToString(), IdUbicacion)

         '-- Ingresa WHERE.- --
         .AppendFormatLine("WHERE {0} = '{1}'", Entidades.CRMNovedadProductoLote.Columnas.idTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("  AND {0} = '{1}'", Entidades.CRMNovedadProductoLote.Columnas.LetraNovedad.ToString(), letraNovedad)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProductoLote.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProductoLote.Columnas.IdNovedad.ToString(), idNovedad)
         .AppendFormatLine("  AND {0} = '{1}'", Entidades.CRMNovedadProductoLote.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProductoLote.Columnas.OrdenProducto.ToString(), ordenProducto)
         .AppendFormatLine("  AND {0} =  '{1}' ", Entidades.CRMNovedadProductoLote.Columnas.IdLote.ToString(), IdLote)

      End With
      '-- Ejecuta Sentencia.- ------
      Me.Execute(myQuery.ToString())
   End Sub

   'Public Sub CRMNovedadesProductosLotes_U_StockConsumido(idTipoNovedad As String, letraNovedad As String, centroEmisor As Short, idNovedad As Long,
   '                                                  idProducto As String, ordenProducto As Integer,
   '                                                  stockConsumido As Boolean)
   '   Dim myQuery = New StringBuilder()
   '   With myQuery
   '      '-- Carga Nombre de la tabla.- --
   '      .AppendFormatLine("UPDATE {0} ", Entidades.CRMNovedadProducto.NombreTabla)
   '      '-- Ingresa Campos.- --
   '      .AppendFormatLine("   SET {0} = {1}", Entidades.CRMNovedadProducto.Columnas.StockConsumidoProducto.ToString(), GetStringFromBoolean(stockConsumido))
   '      '-- Ingresa WHERE.- --
   '      .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.idTipoNovedad.ToString(), idTipoNovedad)
   '      .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.LetraNovedad.ToString(), letraNovedad)
   '      .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.CentroEmisor.ToString(), centroEmisor)
   '      .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.IdNovedad.ToString(), idNovedad)
   '      .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadProducto.Columnas.IdProducto.ToString(), idProducto)
   '      .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadProducto.Columnas.OrdenProducto.ToString(), ordenProducto)
   '   End With
   '   '-- Ejecuta Sentencia.- ------
   '   Execute(myQuery)
   'End Sub

   Public Sub CRMNovedadesProductosLotes_D(idTipoNovedad As String,
                                      letraNovedad As String,
                                      centroEmisor As Short,
                                      idNovedad As Long,
                                      idProducto As String,
                                      ordenProducto As Integer,
                                      idLote As String)
      Dim myQuery = New StringBuilder()

      With myQuery
         '-- Carga Nombre de la tabla.- --
         .AppendFormat("DELETE FROM {0} ", Entidades.CRMNovedadProductoLote.NombreTabla)
         '-- Ingresa Campos.- --
         .AppendFormatLine("WHERE {0} = '{1}'", Entidades.CRMNovedadProductoLote.Columnas.idTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("  AND {0} = '{1}'", Entidades.CRMNovedadProductoLote.Columnas.LetraNovedad.ToString(), letraNovedad)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProductoLote.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProductoLote.Columnas.IdNovedad.ToString(), idNovedad)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("  AND {0} = '{1}'", Entidades.CRMNovedadProductoLote.Columnas.IdProducto.ToString(), idProducto)
         End If
         If ordenProducto <> 0 Then
            .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProductoLote.Columnas.OrdenProducto.ToString(), ordenProducto)
         End If
         .AppendFormatLine("  AND {0} =  '{1}'", Entidades.CRMNovedadProductoLote.Columnas.IdLote.ToString(), idLote)
      End With

      '-- Ejecuta Sentencia.- ------
      Execute(myQuery)
   End Sub

   Public Function CRMNovedadesProductosLotes_GA(idTipoNovedad As String, letra As String,
                                                 centroEmisor As Short, idNovedad As Long, idProducto As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine("   AND NPL.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND NPL.LetraNovedad = '{0}'", letra)
         End If
         If idNovedad > 0 Then
            .AppendFormatLine("   AND NPL.CentroEmisor = {0}", centroEmisor)
         End If
         If idNovedad > 0 Then
            .AppendFormatLine("   AND NPL.IdNovedad = {0}", idNovedad)
         End If
         .AppendFormatLine("   AND NPL.IdProducto = '{0}'", idProducto)

         .AppendFormatLine(" ORDER BY NPL.IdTipoNovedad, NPL.IdNovedad, NPL.OrdenProducto ASC")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class
