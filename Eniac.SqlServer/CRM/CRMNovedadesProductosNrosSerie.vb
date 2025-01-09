Public Class CRMNovedadesProductosNrosSerie
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT NP.*")
         .AppendFormatLine("  FROM CRMNovedadesProductosNrosSerie AS NP")
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

   Public Sub CRMNovedadesProductosNrosSerie_I(idTipoNovedad As String,
                                      letraNovedad As String,
                                      centroEmisor As Short,
                                      idNovedad As Long,
                                      idProducto As String,
                                      ordenProducto As Integer,
                                      NroSerie As String,
                                      IdSucursal As Integer,
                                      IdDeposito As Integer,
                                      IdUbicacion As Integer)
      Dim myQuery = New StringBuilder()

      With myQuery
         '-- Carga Nombre de la tabla.- --
         .AppendFormat("INSERT INTO {0} (", Entidades.CRMNovedadProductoNrosSerie.NombreTabla)
         '-- Ingresa Campos.- --
         .AppendFormatLine(" {0}", Entidades.CRMNovedadProductoNrosSerie.Columnas.idTipoNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoNrosSerie.Columnas.IdNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoNrosSerie.Columnas.LetraNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoNrosSerie.Columnas.CentroEmisor.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoNrosSerie.Columnas.IdProducto.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoNrosSerie.Columnas.OrdenProducto.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoNrosSerie.Columnas.NroSerie.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoNrosSerie.Columnas.IdSucursal.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoNrosSerie.Columnas.IdDeposito.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadProductoNrosSerie.Columnas.IdUbicacion.ToString())
         '-- Ingresa Values.- --
         .AppendFormatLine("  ) VALUES ( ")
         '-- Ingresa Valores.- --
         .AppendFormatLine(" '{0}'", idTipoNovedad)
         .AppendFormatLine(", {0} ", idNovedad)
         .AppendFormatLine(",'{0}'", letraNovedad)
         .AppendFormatLine(", {0} ", centroEmisor)
         .AppendFormatLine(",'{0}'", idProducto)
         .AppendFormatLine(", {0} ", ordenProducto)
         .AppendFormatLine(",'{0}'", NroSerie)
         .AppendFormatLine(", {0} ", IdSucursal)
         .AppendFormatLine(", {0} ", IdDeposito)
         .AppendFormatLine(", {0} ", IdUbicacion)
         '-- Cierra Sentencia.- --
         .AppendFormatLine(")")
      End With
      '-- Ejecuta Sentencia.- ------
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub CRMNovedadesProductosNrosSerie_U(idTipoNovedad As String,
                                      letraNovedad As String,
                                      centroEmisor As Short,
                                      idNovedad As Long,
                                      idProducto As String,
                                      ordenProducto As Integer,
                                      NroSerie As String,
                                      IdSucursal As Integer,
                                      IdDeposito As Integer,
                                      IdUbicacion As Integer)

      Dim myQuery = New StringBuilder()

      With myQuery
         '-- Carga Nombre de la tabla.- --
         .AppendFormat("UPDATE {0} ", Entidades.CRMNovedadProductoNrosSerie.NombreTabla)
         '-- Ingresa Campos.- --
         .AppendFormatLine("   SET {0} = {1}", Entidades.CRMNovedadProductoNrosSerie.Columnas.IdSucursal.ToString(), IdSucursal)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProductoNrosSerie.Columnas.IdDeposito.ToString(), IdDeposito)
         .AppendFormatLine("   ,{0} = {1}", Entidades.CRMNovedadProductoNrosSerie.Columnas.IdUbicacion.ToString(), IdUbicacion)
         '-- Ingresa WHERE.- --
         .AppendFormatLine("WHERE {0} = '{1}'", Entidades.CRMNovedadProductoNrosSerie.Columnas.idTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("  AND {0} = '{1}'", Entidades.CRMNovedadProductoNrosSerie.Columnas.LetraNovedad.ToString(), letraNovedad)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProductoNrosSerie.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProductoNrosSerie.Columnas.IdNovedad.ToString(), idNovedad)
         .AppendFormatLine("  AND {0} = '{1}'", Entidades.CRMNovedadProductoNrosSerie.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProductoNrosSerie.Columnas.OrdenProducto.ToString(), ordenProducto)
         .AppendFormatLine("  AND {0} =  '{1}'", Entidades.CRMNovedadProductoNrosSerie.Columnas.NroSerie.ToString(), NroSerie)
      End With
      '-- Ejecuta Sentencia.- ------
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub CRMNovedadesProductosNrosSerie_D(idTipoNovedad As String,
                                      letraNovedad As String,
                                      centroEmisor As Short,
                                      idNovedad As Long,
                                      idProducto As String,
                                      ordenProducto As Integer,
                                       NroSerie As String)
      Dim myQuery = New StringBuilder()

      With myQuery
         '-- Carga Nombre de la tabla.- --
         .AppendFormat("DELETE FROM {0} ", Entidades.CRMNovedadProductoNrosSerie.NombreTabla)
         '-- Ingresa Campos.- --
         .AppendFormatLine("WHERE {0} = '{1}'", Entidades.CRMNovedadProductoNrosSerie.Columnas.idTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("  AND {0} = '{1}'", Entidades.CRMNovedadProductoNrosSerie.Columnas.LetraNovedad.ToString(), letraNovedad)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProductoNrosSerie.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProductoNrosSerie.Columnas.IdNovedad.ToString(), idNovedad)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("  AND {0} = '{1}'", Entidades.CRMNovedadProductoNrosSerie.Columnas.IdProducto.ToString(), idProducto)
         End If
         If ordenProducto <> 0 Then
            .AppendFormatLine("  AND {0} =  {1} ", Entidades.CRMNovedadProductoNrosSerie.Columnas.OrdenProducto.ToString(), ordenProducto)
         End If
         .AppendFormatLine("  AND {0} =  '{1}'", Entidades.CRMNovedadProductoNrosSerie.Columnas.NroSerie.ToString(), NroSerie)

      End With
      '-- Ejecuta Sentencia.- ------
      Execute(myQuery)
   End Sub

   Public Function CRMNovedadesProductosNrosSerie_GA(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idProducto As String) As DataTable
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
         .AppendFormatLine("  AND {0} = '{1}'", Entidades.CRMNovedadProductoNrosSerie.Columnas.IdProducto.ToString(), idProducto)

         .AppendFormatLine(" ORDER BY NP.IdTipoNovedad, NP.IdNovedad, NP.OrdenProducto ASC")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class
