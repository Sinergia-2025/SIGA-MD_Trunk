Public Class CRMNovedadesSeguimiento
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMNovedadesSeguimiento_I(fechaActualizacionWebSync As Date?,
                                        idTipoNovedad As String,
                                        letra As String,
                                        centroEmisor As Short,
                                        idNovedad As Long,
                                        idSeguimiento As Integer,
                                        idUnico As String,
                                        fechaSeguimiento As Date,
                                        comentario As String,
                                        interlocutor As String,
                                        esComentario As Boolean,
                                        usuarioSeguimiento As String,
                                        idTipoComentarioNovedad As Integer?,
                                        comentarioPrincipal As Boolean,
                                        activo As Boolean,
                                        idEstadoNovedad As Integer?,
                                        usuarioAsignado As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0}", Entidades.CRMNovedadSeguimiento.NombreTabla)

         .AppendFormatLine("({0}", Entidades.CRMNovedadSeguimiento.Columnas.FechaActualizacionWeb.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.IdTipoNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.Letra.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.CentroEmisor.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.IdNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.IdSeguimiento.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.IdUnico.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.FechaSeguimiento.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.Comentario.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.Interlocutor.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.EsComentario.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.UsuarioSeguimiento.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.IdTipoComentarioNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.ComentarioPrincipal.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.Activo.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.IdEstadoNovedad.ToString())
         .AppendFormatLine(",{0}", Entidades.CRMNovedadSeguimiento.Columnas.UsuarioAsignado.ToString())

         .AppendFormatLine("   ) VALUES ( ")

         If Not fechaActualizacionWebSync.HasValue Then
            .AppendFormatLine(" GETDATE()", Entidades.CRMNovedadSeguimiento.Columnas.FechaActualizacionWeb.ToString())
         Else
            .AppendFormatLine(" '{0}'", ObtenerFecha(fechaActualizacionWebSync.Value, True, True))
         End If

         .AppendFormatLine(",'{0}'", idTipoNovedad)
         .AppendFormatLine(",'{0}'", letra)
         .AppendFormatLine(", {0} ", centroEmisor)
         .AppendFormatLine(", {0} ", idNovedad)
         .AppendFormatLine(", {0} ", idSeguimiento)
         .AppendFormatLine(",'{0}'", idUnico)
         .AppendFormatLine(",'{0}'", ObtenerFecha(fechaSeguimiento, True))
         .AppendFormatLine(",'{0}'", comentario)
         .AppendFormatLine(",'{0}'", interlocutor)
         .AppendFormatLine(", {0} ", GetStringFromBoolean(esComentario))
         .AppendFormatLine(",'{0}'", usuarioSeguimiento)
         .AppendFormatLine(", {0} ", GetStringFromNumber(If(idTipoComentarioNovedad.HasValue, idTipoComentarioNovedad.Value, 0)))
         .AppendFormatLine(", {0} ", GetStringFromBoolean(comentarioPrincipal))
         .AppendFormatLine(", {0} ", GetStringFromBoolean(activo))

         If idEstadoNovedad.HasValue AndAlso idEstadoNovedad.Value <> 0 Then
            .AppendFormatLine(", {0} ", idEstadoNovedad.Value)
         Else
            .AppendLine(", NULL")
         End If

         .AppendFormatLine(",'{0}'", usuarioAsignado)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMNovedadesSeguimiento_U(fechaActualizacionWebSync As Date?,
                                        idTipoNovedad As String,
                                        letra As String,
                                        centroEmisor As Short,
                                        idNovedad As Long,
                                        idSeguimiento As Integer,
                                        idUnico As String,
                                        fechaSeguimiento As Date,
                                        comentario As String,
                                        interlocutor As String,
                                        esComentario As Boolean,
                                        usuarioSeguimiento As String,
                                        idTipoComentarioNovedad As Integer?,
                                        comentarioPrincipal As Boolean,
                                        activo As Boolean,
                                        idEstadoNovedad As Integer?,
                                        usuarioAsignado As String)
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE CRMNovedadesSeguimiento ")

         If Not fechaActualizacionWebSync.HasValue Then
            .AppendFormatLine("   SET {0} = GETDATE()", Entidades.CRMNovedadSeguimiento.Columnas.FechaActualizacionWeb.ToString())
         Else
            .AppendFormatLine("   SET {0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionWebSync.Value, True, True))
         End If

         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.FechaSeguimiento.ToString(), ObtenerFecha(fechaSeguimiento, True))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.Comentario.ToString(), comentario)
         If Not String.IsNullOrWhiteSpace(interlocutor) Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.Interlocutor.ToString(), interlocutor)
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.CRMNovedadSeguimiento.Columnas.Interlocutor.ToString())
         End If
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedadSeguimiento.Columnas.EsComentario.ToString(), GetStringFromBoolean(esComentario))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.UsuarioSeguimiento.ToString(), usuarioSeguimiento)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedadSeguimiento.Columnas.IdTipoComentarioNovedad.ToString(), GetStringFromNumber(If(idTipoComentarioNovedad.HasValue, idTipoComentarioNovedad.Value, 0)))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedadSeguimiento.Columnas.ComentarioPrincipal.ToString(), GetStringFromBoolean(comentarioPrincipal))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedadSeguimiento.Columnas.Activo.ToString(), GetStringFromBoolean(activo))

         If idEstadoNovedad.HasValue AndAlso idEstadoNovedad.Value <> 0 Then
            .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMNovedadSeguimiento.Columnas.IdEstadoNovedad.ToString(), idEstadoNovedad.Value)
         Else
            .AppendFormatLine(", {0} = NULL", Entidades.CRMNovedadSeguimiento.Columnas.IdEstadoNovedad.ToString())
         End If

         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.UsuarioAsignado.ToString(), usuarioAsignado)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimiento.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimiento.Columnas.IdNovedad.ToString(), idNovedad)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimiento.Columnas.IdSeguimiento.ToString(), idSeguimiento)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.IdUnico.ToString(), idUnico)
      End With
      Execute(myQuery)
   End Sub

   Public Sub CRMNovedadesSeguimiento_D(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long)
      CRMNovedadesSeguimiento_D(idTipoNovedad, letra, centroEmisor, idNovedad, idSeguimiento:=0, idUnico:=String.Empty)
   End Sub
   Public Sub CRMNovedadesSeguimiento_D(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idSeguimiento As Integer, idUnico As String)
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM CRMNovedadesSeguimiento ")
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimiento.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimiento.Columnas.IdNovedad.ToString(), idNovedad)
         If idSeguimiento > 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.CRMNovedadSeguimiento.Columnas.IdSeguimiento.ToString(), idSeguimiento)
         End If
         If Not String.IsNullOrWhiteSpace(idUnico) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.IdUnico.ToString(), idUnico)
         End If
      End With

      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT NS.*")
         .AppendFormatLine("  FROM CRMNovedadesSeguimiento AS NS")
         .AppendFormatLine("  LEFT JOIN CRMTiposComentariosNovedades AS TC ON TC.IdTipoComentarioNovedad = NS.IdTipoComentarioNovedad")
      End With
   End Sub

   Private Sub SelectTextoDetallado(stb As StringBuilder)
      CRMNovedades.SelectTexto(stb, esAuditoria:=False,
                               Function(stb1)
                                  stb1.AppendFormatLine(" , NS.IdSeguimiento ")
                                  stb1.AppendFormatLine(" , NS.FechaSeguimiento ")
                                  stb1.AppendFormatLine(" , CONVERT(DATE, NS.FechaSeguimiento) AS FechaSeguimiento_Fecha")
                                  stb1.AppendFormatLine(" , CONVERT(VARCHAR(5), NS.FechaSeguimiento, 108) AS FechaSeguimiento_Hora")

                                  stb1.AppendFormatLine(" , NS.Comentario ")
                                  stb1.AppendFormatLine(" , NS.EsComentario ")
                                  stb1.AppendFormatLine(" , NS.UsuarioSeguimiento ")
                                  stb1.AppendFormatLine(" , NS.Interlocutor ")

                                  stb1.AppendFormatLine(" , NS.IdTipoComentarioNovedad")
                                  stb1.AppendFormatLine(" , TCNS.NombreTipoComentarioNovedad")
                                  stb1.AppendFormatLine(" , TCNS.Color ColorTiposComentariosNovedades")
                                  stb1.AppendFormatLine(" , NS.ComentarioPrincipal")
                                  stb1.AppendFormatLine(" , NS.Activo")
                                  stb1.AppendFormatLine(" , NS.IdEstadoNovedad IdEstadoNovedadSeguimiento")
                                  stb1.AppendFormatLine(" , ENS.NombreEstadoNovedad NombreEstadoNovedadSeguimiento")
                                  stb1.AppendFormatLine(" , ENS.Color ColorEstadoNovedadSeguimiento")
                                  stb1.AppendFormatLine(" , NS.UsuarioAsignado UsuarioAsignadoSeguimiento")
                                  stb1.AppendFormatLine(" , NS.IdUnico")
                                  stb1.AppendFormatLine(" , NS.FechaActualizacionWeb")

                                  Return stb1
                               End Function,
                               Function(stb1)
                                  stb1.AppendFormatLine(" INNER JOIN CRMNovedadesSeguimiento AS NS ON NS.IdTipoNovedad = N.IdTipoNovedad and NS.IdNovedad = N.IDNovedad")
                                  stb1.AppendFormatLine("  LEFT JOIN CRMTiposComentariosNovedades AS TCNS ON TCNS.IdTipoComentarioNovedad = NS.IdTipoComentarioNovedad")
                                  stb1.AppendFormatLine("  LEFT JOIN CRMEstadosNovedades AS ENS ON ENS.IdEstadoNovedad = NS.IdEstadoNovedad")

                                  Return stb1
                               End Function)
   End Sub

   Protected Overridable Sub AgregarCamposJoins(stb As StringBuilder)

   End Sub

   Protected Overridable Sub AgregarJoins(stb As StringBuilder)

   End Sub

   Public Function CRMNovedades_GetNovedadesSeguimientos(desde As Date, hasta As Date, idTipoNovedad As String,
                                                         idCategoriaNovedad As Integer, idEstadoNovedad As Integer,
                                                         idUsuario As String, tipoUsuario As Entidades.CRMNovedad.TipoUsuarioFiltro, idMedioComunicacionNovedad As Integer,
                                                         idNovedad As Long, idNovedadPadre As Long, idCliente As Long, idProspecto As Long, idProveedor As Long,
                                                         idPrioridadNovedad As Integer, esComentario As String,
                                                         tipoFechaFiltro As Entidades.CRMNovedad.TipoFechaFiltro,
                                                         finalizado As String,
                                                         idFuncion As String,
                                                         idMetodoResolucionNovedad As Integer,
                                                         revisionAdministrativa As Entidades.Publicos.SiNoTodos,
                                                         priorizado As Entidades.Publicos.SiNoTodos,
                                                         idAplicacion As String,
                                                         nroVersion As String,
                                                         idProyecto As Integer,
                                                         prioridadDelProyectoDesde As Decimal,
                                                         prioridadDelProyectoHasta As Decimal,
                                                         estadoDelProyecto As Integer,
                                                         clasificacionDelProyecto As Integer,
                                                         enGarantia As Entidades.Publicos.SiNoTodos,
                                                         enPrestamo As Entidades.Publicos.SiNoTodos,
                                                         estadoPrestamo As Entidades.CRMNovedad.EstadosProductosPrestados,
                                                         activo As Entidades.Publicos.SiNoTodos,
                                                         idTipoComentario As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTextoDetallado(myQuery)

         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine(" WHERE N.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If

         Dim prefix As String = If(tipoFechaFiltro = Entidades.CRMNovedad.TipoFechaFiltro.FechaSeguimiento, "NS", "N")

         .AppendFormatLine("  AND {2}.{1} >= '{0}'", ObtenerFecha(desde, True), tipoFechaFiltro.ToString(), prefix)
         .AppendFormatLine("  AND {2}.{1} <= '{0}'", ObtenerFecha(hasta, True), tipoFechaFiltro.ToString(), prefix)

         If idCategoriaNovedad > 0 Then
            .AppendFormatLine(" AND N.idCategoriaNovedad = {0}", idCategoriaNovedad)
         End If

         If idEstadoNovedad > 0 Then
            .AppendFormatLine(" AND N.idEstadoNovedad = {0}", idEstadoNovedad)
         End If

         If Not String.IsNullOrEmpty(idUsuario) Then
            .AppendFormatLine(" AND {1} = '{0}'", idUsuario, tipoUsuario.ToString().Replace("___", "."))
         End If

         If idMedioComunicacionNovedad > 0 Then
            .AppendFormatLine(" AND N.IdMedioComunicacionNovedad = {0}", idMedioComunicacionNovedad)
         End If

         If idNovedad > 0 Then
            .AppendFormatLine(" AND N.IdNovedad = {0}", idNovedad)
         End If

         If idNovedadPadre > 0 Then
            .AppendFormatLine(" AND N.IdNovedadPadre = {0}", idNovedadPadre)
         End If

         If idCliente > 0 Then
            .AppendFormatLine(" AND N.IdCliente = {0}", idCliente)
         End If

         If idProspecto > 0 Then
            .AppendFormatLine(" AND N.IdProspecto = {0}", idProspecto)
         End If

         If idProveedor > 0 Then
            .AppendFormatLine(" AND N.IdProveedor = {0}", idProveedor)
         End If

         If idPrioridadNovedad > 0 Then
            .AppendFormatLine(" AND N.IdPrioridadNovedad = '{0}'", idPrioridadNovedad)
         End If

         If finalizado <> "TODOS" Then
            .AppendLine("  AND EN.Finalizado = " & IIf(finalizado = "SI", "1", "0").ToString())
         End If

         If revisionAdministrativa <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND N.RevisionAdministrativa = '{0}'", Me.GetStringFromBoolean(revisionAdministrativa = Entidades.Publicos.SiNoTodos.SI))
         End If

         If esComentario <> "TODOS" Then
            .AppendLine("  AND NS.EsComentario = " & IIf(esComentario = "SI", "1", "0").ToString())
         End If

         If idMetodoResolucionNovedad <> 0 Then
            .AppendFormatLine(" AND N.IdMetodoResolucionNovedad = {0}", idMetodoResolucionNovedad)
         End If

         If priorizado <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND N.Priorizado = {0}", GetStringFromBoolean(priorizado = Entidades.Publicos.SiNoTodos.SI))
         End If

         If Not String.IsNullOrWhiteSpace(idFuncion) Then
            .AppendFormatLine("  AND N.IdFuncion = '{0}'", idFuncion)
         End If

         If Not String.IsNullOrWhiteSpace(idAplicacion) Then
            .AppendFormatLine("  AND N.IdSistema = '{0}'", idAplicacion)
         End If

         If Not String.IsNullOrWhiteSpace(nroVersion) Then
            .AppendFormatLine("  AND N.Version = '{0}'", nroVersion)
         End If

         '# Proyecto
         If idProyecto <> 0 Then
            .AppendFormat(" AND N.IdProyecto = {0}", idProyecto).AppendLine()
         End If

         '# Prioridad del Proyecto
         If prioridadDelProyectoDesde > 0 Then
            .AppendFormatLine("  AND PRO.IdPrioridadProyecto >= {0} AND PRO.IdPrioridadProyecto <= {1}", prioridadDelProyectoDesde, prioridadDelProyectoHasta)
         End If

         '# Estado del Proyecto
         If estadoDelProyecto > 0 Then
            .AppendFormatLine("  AND PRO.IdEstado = {0}", estadoDelProyecto)
         End If

         '# Clasificacion del Proyecto
         If clasificacionDelProyecto > 0 Then
            .AppendFormatLine("  AND PRO.IdClasificacion = {0}", clasificacionDelProyecto)
         End If

         '# Service
         If enGarantia <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND N.TieneGarantiaService = '{0}'", enGarantia = Entidades.Publicos.SiNoTodos.SI)
         End If
         If enPrestamo <> Entidades.Publicos.SiNoTodos.TODOS Then
            If enPrestamo = Entidades.Publicos.SiNoTodos.SI Then
               .AppendFormatLine("  AND N.IdProductoPrestado <> '' AND N.IdProductoPrestado IS NOT NULL")
            Else
               .AppendFormatLine("  AND (N.IdProductoPrestado = '' OR N.IdProductoPrestado IS NULL)")
            End If
         End If
         If estadoPrestamo <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND N.ProductoPrestadoDevuelto = '{0}'", estadoPrestamo = Entidades.CRMNovedad.EstadosProductosPrestados.DEVUELTO)
         End If

         If activo <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("  AND NS.Activo = '{0}'", activo = Entidades.Publicos.SiNoTodos.SI)
         End If

         If idTipoComentario > 0 Then
            .AppendFormatLine(" AND NS.IdTipoComentarioNovedad = {0}", idTipoComentario)
         End If

         .AppendFormatLine(" ORDER BY N.IdNovedad")
      End With

      Return GetDataTable(myQuery)
   End Function

   Public Function CRMNovedadesSeguimiento_GA(fechaActualizacionWebDesde As Date?,
                                              visibleParaCliente As Entidades.Publicos.SiNoTodos, visibleParaRepresentante As Entidades.Publicos.SiNoTodos) As DataTable
      Return CRMNovedadesSeguimiento_GA(idTipoNovedad:=String.Empty, letra:=String.Empty, centroEmisor:=0, idNovedad:=0, fechaActualizacionWebDesde:=fechaActualizacionWebDesde,
                                        visibleParaCliente:=Entidades.Publicos.SiNoTodos.TODOS, visibleParaRepresentante:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Function CRMNovedadesSeguimiento_GA() As DataTable
      Return CRMNovedadesSeguimiento_GA(idTipoNovedad:=String.Empty, letra:=String.Empty, centroEmisor:=0, idNovedad:=0, fechaActualizacionWebDesde:=Nothing,
                                        visibleParaCliente:=Entidades.Publicos.SiNoTodos.TODOS, visibleParaRepresentante:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function

   Public Function CRMNovedadesSeguimiento_GA(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, fechaActualizacionWebDesde As Date?,
                                              visibleParaCliente As Entidades.Publicos.SiNoTodos, visibleParaRepresentante As Entidades.Publicos.SiNoTodos) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine("   AND NS.IdTipoNovedad = '{0}'", idTipoNovedad)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND NS.Letra = '{0}'", letra)
         End If
         If idNovedad > 0 Then
            .AppendFormatLine("   AND NS.CentroEmisor = {0}", centroEmisor)
         End If
         If idNovedad > 0 Then
            .AppendFormatLine("   AND NS.IdNovedad = {0}", idNovedad)
         End If
         If fechaActualizacionWebDesde.HasValue Then
            .AppendFormatLine("   AND NS.{0} > '{1}'", Entidades.CRMNovedad.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionWebDesde.Value, True, True))
         End If

         .AppendFormatLine(" ORDER BY NS.IdTipoNovedad, NS.IdNovedad, NS.IdSeguimiento DESC")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function CRMNovedadesSeguimiento_G1(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idSeguimiento As Integer, idUnico As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE NS.{0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         .AppendFormatLine("   AND NS.{0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND NS.{0} =  {1} ", Entidades.CRMNovedadSeguimiento.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND NS.{0} =  {1} ", Entidades.CRMNovedadSeguimiento.Columnas.IdNovedad.ToString(), idNovedad)
         .AppendFormatLine("   AND NS.{0} =  {1} ", Entidades.CRMNovedadSeguimiento.Columnas.IdSeguimiento.ToString(), idSeguimiento)
         .AppendFormatLine("   AND NS.{0} = '{1}'", Entidades.CRMNovedadSeguimiento.Columnas.IdUnico.ToString(), idUnico)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable

      If columna = "NombreTipoNovedad" Then
         'columna = "TN." + columna
      Else
         columna = "NS." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.CRMNovedadSeguimiento.Columnas.IdSeguimiento.ToString(), "CRMNovedadesSeguimiento",
                                                    String.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = {5} AND {6} = {7}",
                                                                  Entidades.CRMNovedadSeguimiento.Columnas.IdTipoNovedad.ToString(), idTipoNovedad,
                                                                  Entidades.CRMNovedadSeguimiento.Columnas.Letra.ToString(), letra,
                                                                  Entidades.CRMNovedadSeguimiento.Columnas.CentroEmisor.ToString(), centroEmisor,
                                                                  Entidades.CRMNovedadSeguimiento.Columnas.IdNovedad.ToString(), idNovedad)))
   End Function


   Public Function GetNovedadesParaWeb(fechaMinimaTicketsFinalizados As Date, fechaMinimaMejorasFinalizados As Date, dataBase As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT NS.*")
         .AppendFormatLine("      ,NSA.NombreAdjunto")
         .AppendFormatLine("  FROM CRMNovedades N")
         .AppendFormatLine(" INNER JOIN CRMNovedadesSeguimiento NS ON NS.IdTipoNovedad = N.IdTipoNovedad AND NS.Letra = N.Letra AND NS.CentroEmisor = N.CentroEmisor AND NS.IdNovedad = N.IdNovedad")
         .AppendFormatLine("  LEFT JOIN {0}CRMNovedadesSeguimientoAdjuntos NSA ON NSA.IdTipoNovedad = N.IdTipoNovedad COLLATE Modern_Spanish_CI_AS AND NSA.Letra = N.Letra COLLATE Modern_Spanish_CI_AS AND NSA.CentroEmisor = N.CentroEmisor AND NSA.IdNovedad = N.IdNovedad AND NSA.IdSeguimiento = NS.IdSeguimiento", dataBase)

         .AppendFormatLine(" INNER JOIN CRMEstadosNovedades E ON E.IdEstadoNovedad = N.IdEstadoNovedad")
         .AppendFormatLine(" INNER JOIN CRMCategoriasNovedades CN ON CN.IdCategoriaNovedad = N.IdCategoriaNovedad")
         .AppendFormatLine(" INNER JOIN CRMTiposComentariosNovedades TCN ON TCN.IdTipoComentarioNovedad = NS.IdTipoComentarioNovedad")
         .AppendFormatLine(" WHERE 1 = 1", ObtenerFecha(fechaMinimaTicketsFinalizados, True))
         .AppendFormatLine("   AND CN.PublicarEnWeb = 'True'")
         .AppendFormatLine("   AND (TCN.VisibleParaCliente = 'True' OR TCN.VisibleParaRepresentante = 'True')")
         .AppendFormatLine("   AND ((N.IdTipoNovedad = 'TICKETS' AND (E.Finalizado = 'False' OR (E.Finalizado = 'True' AND N.FechaEstadoNovedad > '{0}'))) OR", ObtenerFecha(fechaMinimaTicketsFinalizados, True))
         .AppendFormatLine("        (N.IdTipoNovedad = 'PENDIENTE' AND N.FechaEstadoNovedad > '{0}'))", ObtenerFecha(fechaMinimaMejorasFinalizados, True))


         ', 'PENDIENTE'
      End With
      Return GetDataTable(stb.ToString())
   End Function

End Class