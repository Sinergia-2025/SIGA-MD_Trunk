Public Class CRMNovedadesSeguimientoAdjuntos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess, dataBase As String)
      MyBase.New(da)
      Me._database = dataBase
   End Sub

   Private _database As String = String.Empty
   Private ReadOnly Property DataBase As String
      Get
         Return Me._database
      End Get
   End Property

   Public Sub CRMNovedadesSeguimientoAdjuntos_I(idTipoNovedad As String,
                                                letra As String,
                                                centroEmisor As Short,
                                                idNovedad As Long,
                                                idSeguimiento As Integer,
                                                idUnico As String,
                                                nombreAdjunto As String,
                                                adjunto As Byte())
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO {0}CRMNovedadesSeguimientoAdjuntos ", Me.DataBase)
         .AppendFormatLine("            ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
                           Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdTipoNovedad.ToString(),
                           Entidades.CRMNovedadSeguimientoAdjunto.Columnas.Letra.ToString(),
                           Entidades.CRMNovedadSeguimientoAdjunto.Columnas.CentroEmisor.ToString(),
                           Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdNovedad.ToString(),
                           Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdSeguimiento.ToString(),
                           Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdUnico.ToString(),
                           Entidades.CRMNovedadSeguimientoAdjunto.Columnas.NombreAdjunto.ToString(),
                           Entidades.CRMNovedadSeguimientoAdjunto.Columnas.Adjunto.ToString())
         .AppendFormatLine("     VALUES ('{0}', '{1}', {2}, {3}, {4}, '{5}', '{6}', @adjunto)",
                           idTipoNovedad, letra, centroEmisor, idNovedad, idSeguimiento, idUnico, nombreAdjunto)


         Me._da.Command.CommandText = .ToString()
         Me._da.Command.CommandType = CommandType.Text
         Me._da.Command.Transaction = Me._da.Transaction
         Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
         oParameter.ParameterName = "@adjunto"
         oParameter.DbType = DbType.Binary
         oParameter.Size = adjunto.Length
         oParameter.Value = adjunto
         Me._da.Command.Parameters.Add(oParameter)
         Me._da.Command.Connection = Me._da.Connection
         Me._da.ExecuteNonQuery(Me._da.Command)

      End With
   End Sub

   Public Sub CRMNovedadesSeguimientoAdjuntos_U(idTipoNovedad As String,
                                                letra As String,
                                                centroEmisor As Short,
                                                idNovedad As Long,
                                                idSeguimiento As Integer,
                                                idUnico As String,
                                                nombreAdjunto As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendFormatLine("UPDATE {0}CRMNovedadesSeguimientoAdjuntos ", Me.DataBase)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.NombreAdjunto.ToString(), nombreAdjunto)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdNovedad.ToString(), idNovedad)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdSeguimiento.ToString(), idSeguimiento)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdUnico.ToString(), idUnico)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CRMNovedadesSeguimientoAdjuntos_D(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long)
      CRMNovedadesSeguimientoAdjuntos_D(idTipoNovedad, letra, centroEmisor, idNovedad, idSeguimiento:=0, idUnico:=String.Empty)
   End Sub
   Public Sub CRMNovedadesSeguimientoAdjuntos_D(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idSeguimiento As Integer, idUnico As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM {0}CRMNovedadesSeguimientoAdjuntos ", Me.DataBase)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdNovedad.ToString(), idNovedad)
         If idSeguimiento > 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdSeguimiento.ToString(), idSeguimiento)
         End If
         If Not String.IsNullOrWhiteSpace(idUnico) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdUnico.ToString(), idUnico)
         End If
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, incluirFoto As Boolean)
      With stb
         .AppendFormatLine("SELECT NS.IdTipoNovedad")
         .AppendFormatLine("      ,NS.Letra")
         .AppendFormatLine("      ,NS.CentroEmisor")
         .AppendFormatLine("      ,NS.IdNovedad")
         .AppendFormatLine("      ,NS.IdSeguimiento")
         .AppendFormatLine("      ,NS.IdUnico")
         .AppendFormatLine("      ,NS.NombreAdjunto")
         If incluirFoto Then
            .AppendFormatLine("      ,NS.Adjunto")
         Else
            .AppendFormatLine("      ,NULL AS Adjunto")
         End If
         .AppendFormatLine("  FROM {0}CRMNovedadesSeguimientoAdjuntos AS NS", Me.DataBase)
      End With
   End Sub

   Public Function CRMNovedadesSeguimientoAdjuntos_GA(incluirFoto As Boolean) As DataTable
      Return CRMNovedadesSeguimientoAdjuntos_GA(idTipoNovedad:=String.Empty, letra:=String.Empty, centroEmisor:=0, idNovedad:=0, idSeguimiento:=0, idUnico:=String.Empty, incluirFoto:=incluirFoto)
   End Function
   Public Function CRMNovedadesSeguimientoAdjuntos_GA(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, incluirFoto As Boolean) As DataTable
      Return CRMNovedadesSeguimientoAdjuntos_GA(idTipoNovedad, letra, centroEmisor, idNovedad, idSeguimiento:=0, idUnico:=String.Empty, incluirFoto:=incluirFoto)
   End Function
   Public Function CRMNovedadesSeguimientoAdjuntos_GA(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idSeguimiento As Integer, idUnico As String, incluirFoto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery, incluirFoto)
         .AppendFormatLine(" WHERE 1 = 1")

         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine("   AND NS.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND NS.Letra = '{0}'", letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("   AND NS.CentroEmisor = {0}", centroEmisor)
         End If
         If idNovedad > 0 Then
            .AppendFormatLine("   AND NS.IdNovedad = {0}", idNovedad)
         End If
         If idSeguimiento > 0 Then
            .AppendFormatLine("   AND NS.IdSeguimiento = {0}", idSeguimiento)
         End If
         If Not String.IsNullOrWhiteSpace(idUnico) Then
            .AppendFormatLine("   AND NS.IdUnico = '{0}'", idUnico)
         End If

         .AppendFormatLine(" ORDER BY NS.IdTipoNovedad, NS.IdNovedad, NS.IdSeguimiento DESC")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CRMNovedadesSeguimientoAdjuntos_G1(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idSeguimiento As Integer, idUnico As String, incluirFoto As Boolean) As DataTable
      Return CRMNovedadesSeguimientoAdjuntos_GA(idTipoNovedad, letra, centroEmisor, idNovedad, idSeguimiento, idUnico, incluirFoto)
   End Function

   Public Function CRMNovedadesSeguimientoAdjuntos_GA_ParaArchivar(fechaDesde As DateTime?, fechaHasta As DateTime?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT CONVERT(BIT, 1) Selec, N.IdTipoNovedad, N.Letra, N.CentroEmisor, N.IdNovedad, N.Descripcion, A.NombreAdjunto, A.IdSeguimiento, A.IdUnico")
         .AppendFormatLine("     , DATALENGTH(A.Adjunto) Bytes")
         .AppendFormatLine("     , CONVERT(DECIMAL, DATALENGTH(A.Adjunto)) / 1024 KBytes")
         .AppendFormatLine("     , CONVERT(DECIMAL, DATALENGTH(A.Adjunto)) / 1024 / 1024 MBytes")
         .AppendFormatLine("     , CASE WHEN C.CodigoCliente IS NOT NULL THEN 'Cliente' ELSE")
         .AppendFormatLine("       CASE WHEN PR.CodigoProspecto IS NOT NULL THEN 'Prospecto' ELSE")
         .AppendFormatLine("       CASE WHEN P.CodigoProveedor IS NOT NULL THEN 'Proveedor' ELSE '' END END END TipoClienteProspectoProveedor")
         .AppendFormatLine("     , ISNULL(C.IdCliente, ISNULL(PR.IdProspecto, ISNULL(P.IdProveedor, 0))) IdClienteProspectoProveedor")
         .AppendFormatLine("     , ISNULL(C.CodigoCliente, ISNULL(PR.CodigoProspecto, ISNULL(P.CodigoProveedor, 0))) CodigoClienteProspectoProveedor")
         .AppendFormatLine("     , ISNULL(C.NombreCliente, ISNULL(PR.NombreProspecto, ISNULL(P.NombreProveedor, 0))) NombreClienteProspectoProveedor")
         .AppendFormatLine("     , ISNULL(C.NombreDeFantasia, ISNULL(PR.NombreDeFantasia, ISNULL(P.NombreDeFantasia, 0))) NombreDeFantasiaClienteProspectoProveedor")
         .AppendFormatLine("     , '' EstadoProceso")
         .AppendFormatLine("     , '' MensajeProceso")
         .AppendFormatLine("  FROM CRMNovedades N")
         .AppendFormatLine(" INNER JOIN CRMEstadosNovedades E ON E.IdEstadoNovedad = N.IdEstadoNovedad")
         .AppendFormatLine(" INNER JOIN {0}CRMNovedadesSeguimientoAdjuntos A ", Me.DataBase)
         .AppendFormatLine("         ON A.IdTipoNovedad = N.IdTipoNovedad COLLATE Modern_Spanish_CI_AS")
         .AppendFormatLine("        AND A.Letra = N.Letra COLLATE Modern_Spanish_CI_AS")
         .AppendFormatLine("        AND A.CentroEmisor = N.CentroEmisor")
         .AppendFormatLine("        AND A.IdNovedad = N.IdNovedad")
         .AppendFormatLine("  LEFT JOIN Clientes C ON C.IdCliente = N.IdCliente")
         .AppendFormatLine("  LEFT JOIN Prospectos PR ON PR.IdProspecto = N.IdProspecto")
         .AppendFormatLine("  LEFT JOIN Proveedores P ON P.IdProveedor = N.IdProveedor")
         .AppendFormatLine(" WHERE E.Finalizado = 'True'")
         .AppendFormatLine("   AND A.Adjunto IS NOT NULL")
         If fechaDesde.HasValue Then
            .AppendFormatLine("   AND N.FechaFinalizado >= '{0}'", ObtenerFecha(fechaDesde.Value, True))
         End If
         If fechaHasta.HasValue Then
            .AppendFormatLine("   AND N.FechaFinalizado <= '{0}'", ObtenerFecha(fechaHasta.Value, True))
         End If

      End With
      Return GetDataTable(stb.ToString())
   End Function

   Public Sub CRMNovedadesSeguimientoAdjuntos_U_EliminarContenido(idTipoNovedad As String,
                                                                  letra As String,
                                                                  centroEmisor As Short,
                                                                  idNovedad As Long,
                                                                  idSeguimiento As Integer,
                                                                  idUnico As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE {0}CRMNovedadesSeguimientoAdjuntos ", Me.DataBase)
         .AppendFormatLine("   SET {0} = NULL ", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.Adjunto.ToString())
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdNovedad.ToString(), idNovedad)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdSeguimiento.ToString(), idSeguimiento)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdUnico.ToString(), idUnico)
      End With
      Me.Execute(myQuery.ToString())
   End Sub


   Public Overloads Function Buscar(columna As String, valor As String) As DataTable

      If columna = "NombreTipoNovedad" Then
         'columna = "TN." + columna
      Else
         columna = "NS." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb, False)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdSeguimiento.ToString(), String.Format("{0}CRMNovedadesSeguimientoAdjuntos", Me.DataBase),
                                                    String.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = {5} AND {6} = {7}",
                                                                  Entidades.CRMNovedadSeguimiento.Columnas.IdTipoNovedad.ToString(), idTipoNovedad,
                                                                  Entidades.CRMNovedadSeguimiento.Columnas.Letra.ToString(), letra,
                                                                  Entidades.CRMNovedadSeguimiento.Columnas.CentroEmisor.ToString(), centroEmisor,
                                                                  Entidades.CRMNovedadSeguimiento.Columnas.IdNovedad.ToString(), idNovedad)))
   End Function

End Class