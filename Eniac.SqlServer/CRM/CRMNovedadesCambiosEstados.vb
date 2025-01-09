Public Class CRMNovedadesCambiosEstados
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub
   Public Sub CRMNovedadesCambiosEstados_I(idTipoNovedad As String,
                                           letra As String,
                                           centroEmisor As Short,
                                           idNovedad As Long,
                                           idCambioEstado As Integer,
                                           fechaCambioEstado As Date,
                                           idEstadoNovedad As Integer,
                                           idUsuario As String,
                                           idUsuarioAsignado As String,
                                           idSucursalNovedad As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0}", Entidades.CRMNovedadCambioEstado.NombreTabla)

         .AppendFormatLine("({0}", Entidades.CRMNovedadCambioEstado.Columnas.IdTipoNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadCambioEstado.Columnas.Letra.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadCambioEstado.Columnas.CentroEmisor.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadCambioEstado.Columnas.IdNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadCambioEstado.Columnas.IdCambioEstado.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadCambioEstado.Columnas.FechaCambioEstado.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadCambioEstado.Columnas.IdEstadoNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadCambioEstado.Columnas.IdUsuario.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadCambioEstado.Columnas.IdUsuarioAsignado.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadCambioEstado.Columnas.IdSucursalNovedad.ToString())

         .AppendFormatLine("   ) VALUES ( ")

         .AppendFormatLine(" '{0}'", idTipoNovedad)
         .AppendFormatLine(",'{0}'", letra)
         .AppendFormatLine(", {0} ", centroEmisor)
         .AppendFormatLine(", {0} ", idNovedad)
         .AppendFormatLine(", {0} ", idCambioEstado)
         .AppendFormatLine(",'{0}'", ObtenerFecha(fechaCambioEstado, True))
         .AppendFormatLine(",'{0}'", idEstadoNovedad)
         .AppendFormatLine(",'{0}'", idUsuario)
         .AppendFormatLine(",'{0}'", idUsuarioAsignado)
         .AppendFormatLine(", {0} ", GetStringFromNumber(idSucursalNovedad))

         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMNovedadesCambiosEstados_U(idTipoNovedad As String,
                                           letra As String,
                                           centroEmisor As Short,
                                           idNovedad As Long,
                                           idCambioEstado As Integer,
                                           fechaCambioEstado As Date,
                                           idEstadoNovedad As Integer,
                                           idUsuario As String,
                                           idUsuarioAsignado As String,
                                           idSucursalNovedad As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE CRMNovedadesCambiosEstados")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CRMNovedadCambioEstado.Columnas.FechaCambioEstado.ToString(), ObtenerFecha(fechaCambioEstado, True))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedadCambioEstado.Columnas.IdEstadoNovedad.ToString(), idEstadoNovedad)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedadCambioEstado.Columnas.IdUsuario.ToString(), idUsuario)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedadCambioEstado.Columnas.IdUsuarioAsignado.ToString(), idUsuarioAsignado)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedadCambioEstado.Columnas.IdSucursalNovedad.ToString(), GetStringFromNumber(idSucursalNovedad))
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMNovedadCambioEstado.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadCambioEstado.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadCambioEstado.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadCambioEstado.Columnas.IdNovedad.ToString(), idNovedad)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadCambioEstado.Columnas.IdCambioEstado.ToString(), idCambioEstado)
      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMNovedadesCambiosEstados_D(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long)
      CRMNovedadesCambiosEstados_D(idTipoNovedad, letra, centroEmisor, idNovedad, idCambioEstado:=0)
   End Sub
   Public Sub CRMNovedadesCambiosEstados_D(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idCambioEstado As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM CRMNovedadesCambiosEstados ")
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMNovedadCambioEstado.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadCambioEstado.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadCambioEstado.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadCambioEstado.Columnas.IdNovedad.ToString(), idNovedad)
         If idCambioEstado > 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadCambioEstado.Columnas.IdCambioEstado.ToString(), idCambioEstado)
         End If
      End With

      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT NCE.*")
         .AppendFormatLine("     , EN.NombreEstadoNovedad")
         .AppendFormatLine("     , S.Nombre NombreSucursalNovedad")
         .AppendFormatLine("  FROM {0} AS NCE", Entidades.CRMNovedadCambioEstado.NombreTabla)
         .AppendFormatLine("  LEFT JOIN CRMEstadosNovedades AS EN ON EN.IdEstadoNovedad = NCE.IdEstadoNovedad")
         .AppendFormatLine("  LEFT JOIN Sucursales AS S ON S.IdSucursal = NCE.IdSucursalNovedad")
      End With
   End Sub

   Public Function CRMNovedadesCambiosEstados_GA(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As DataTable
      Return CRMNovedadesCambiosEstados_GA(idTipoNovedad, letra, centroEmisor, idNovedad, idCambioEstado:=0)
   End Function
   Public Function CRMNovedadesCambiosEstados_GA() As DataTable
      Return CRMNovedadesCambiosEstados_GA(idTipoNovedad:=String.Empty, letra:=String.Empty, centroEmisor:=0, idNovedad:=0, idCambioEstado:=0)
   End Function

   Public Function CRMNovedadesCambiosEstados_GA(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idCambioEstado As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine("   AND NCE.{0} = '{1}'", Entidades.CRMNovedadCambioEstado.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND NCE.{0} = '{1}'", Entidades.CRMNovedadCambioEstado.Columnas.Letra.ToString(), letra)
         End If
         If idNovedad > 0 Then
            .AppendFormatLine("   AND NCE.{0} = {1}", Entidades.CRMNovedadCambioEstado.Columnas.CentroEmisor.ToString(), centroEmisor)
         End If
         If idNovedad > 0 Then
            .AppendFormatLine("   AND NCE.{0} = {1}", Entidades.CRMNovedadCambioEstado.Columnas.IdNovedad.ToString(), idNovedad)
         End If
         If idCambioEstado > 0 Then
            .AppendFormatLine("   AND NCE.{0} > '{1}'", Entidades.CRMNovedadCambioEstado.Columnas.IdCambioEstado.ToString(), idCambioEstado)
         End If

         .AppendFormatLine(" ORDER BY NCE.IdTipoNovedad, NCE.Letra, NCE.CentroEmisor, NCE.IdNovedad, NCE.FechaCambioEstado, EN.Posicion, NCE.IdCambioEstado")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function CRMNovedadesCambiosEstados_GA_Agrupados(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT NCE1.IdTipoNovedad")
         .AppendFormatLine("     , NCE1.Letra")
         .AppendFormatLine("     , NCE1.CentroEmisor")
         .AppendFormatLine("     , NCE1.IdNovedad")
         .AppendFormatLine("     , NCE1.IdCambioEstado")
         .AppendFormatLine("     , NCE1.FechaCambioEstado")
         .AppendFormatLine("     , NCE1.IdEstadoNovedad")
         .AppendFormatLine("     , NCE1.IdUsuario")
         .AppendFormatLine("     , NCE1.IdUsuarioAsignado")
         .AppendFormatLine("     , NCE1.IdSucursalNovedad")
         .AppendFormatLine("     , S.Nombre NombreSucursalNovedad")
         .AppendFormatLine("  FROM (SELECT NCE.IdTipoNovedad, NCE.Letra, NCE.CentroEmisor, NCE.IdNovedad, NCE.IdEstadoNovedad")
         .AppendFormatLine("             , MAX(NCE.IdCambioEstado) IdCambioEstado")
         .AppendFormatLine("          FROM CRMNovedadesCambiosEstados NCE")
         .AppendFormatLine("         WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine("           And NCE.{0} = '{1}'", Entidades.CRMNovedadCambioEstado.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("           AND NCE.{0} = '{1}'", Entidades.CRMNovedadCambioEstado.Columnas.Letra.ToString(), letra)
         End If
         If idNovedad > 0 Then
            .AppendFormatLine("           AND NCE.{0} = {1}", Entidades.CRMNovedadCambioEstado.Columnas.CentroEmisor.ToString(), centroEmisor)
         End If
         If idNovedad > 0 Then
            .AppendFormatLine("           AND NCE.{0} = {1}", Entidades.CRMNovedadCambioEstado.Columnas.IdNovedad.ToString(), idNovedad)
         End If
         .AppendFormatLine("         GROUP BY NCE.IdTipoNovedad, NCE.Letra, NCE.CentroEmisor, NCE.IdNovedad, NCE.IdEstadoNovedad")
         .AppendFormatLine("       ) NCE")
         .AppendFormatLine(" INNER JOIN CRMEstadosNovedades EN ON EN.IdEstadoNovedad = NCE.IdEstadoNovedad")
         .AppendFormatLine(" INNER JOIN CRMNovedadesCambiosEstados NCE1 ON NCE.IdTipoNovedad    = NCE1.IdTipoNovedad")
         .AppendFormatLine("                                           AND NCE.Letra            = NCE1.Letra")
         .AppendFormatLine("                                           AND NCE.CentroEmisor     = NCE1.CentroEmisor")
         .AppendFormatLine("                                           AND NCE.IdNovedad        = NCE1.IdNovedad")
         .AppendFormatLine("                                           AND NCE.IdCambioEstado   = NCE1.IdCambioEstado")
         .AppendFormatLine("  LEFT JOIN Sucursales AS S ON S.IdSucursal = NCE1.IdSucursalNovedad")

         .AppendFormatLine(" ORDER BY NCE1.IdTipoNovedad, NCE1.Letra, NCE1.CentroEmisor, NCE1.IdNovedad, EN.Posicion, NCE1.FechaCambioEstado")

      End With
      Return GetDataTable(stb)
   End Function

   Public Function CRMNovedadesCambiosEstados_G1(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idCambioEstado As Integer) As DataTable
      Return CRMNovedadesCambiosEstados_GA(idTipoNovedad, letra, centroEmisor, idNovedad, idCambioEstado)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "NCE.",
                    New Dictionary(Of String, String) From {{"NombreEstadoNovedad", "EN.NombreEstadoNovedad"}})
   End Function

   Public Overloads Function GetCodigoMaximo(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.CRMNovedadCambioEstado.Columnas.IdCambioEstado.ToString(), "CRMNovedadesCambiosEstados",
                                             String.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = {5} AND {6} = {7}",
                                                           Entidades.CRMNovedadCambioEstado.Columnas.IdTipoNovedad.ToString(), idTipoNovedad,
                                                           Entidades.CRMNovedadCambioEstado.Columnas.Letra.ToString(), letra,
                                                           Entidades.CRMNovedadCambioEstado.Columnas.CentroEmisor.ToString(), centroEmisor,
                                                           Entidades.CRMNovedadCambioEstado.Columnas.IdNovedad.ToString(), idNovedad)))
   End Function

End Class