Imports Eniac.Entidades.Entidad

Public Class FechasSincronizaciones
   Inherits Comunes

#Region "Constructores"

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub FechasSincronizaciones_I(sistemaDestino As String, tabla As String,
                                       fechaInicioSubida As Date?, fechaInicioBajada As Date?,
                                       fechaSubida As Date?, fechaBajada As Date?,
                                       idUsuario As String, fechaActualizacion As Date, nroVersionAplicacion As String,
                                       metodoGrabacion As MetodoGrabacion, idFuncion As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO FechasSincronizaciones(")
         .AppendFormatLine("	  SistemaDestino")
         .AppendFormatLine("	, Tabla")
         .AppendFormatLine("	, FechaInicioSubida")
         .AppendFormatLine("	, FechaInicioBajada")
         .AppendFormatLine("	, FechaSubida")
         .AppendFormatLine("	, FechaBajada")
         .AppendFormatLine("	, IdUsuario")
         .AppendFormatLine("	, FechaActualizacion")
         .AppendFormatLine("	, NroVersionAplicacion")
         .AppendFormatLine("	, MetodoGrabacion")
         .AppendFormatLine("	, IdFuncion")
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	  '{0}'", sistemaDestino)
         .AppendFormatLine("	, '{0}'", tabla)
         .AppendFormatLine("	,  {0} ", ObtenerFecha(fechaSubida, True, True))
         .AppendFormatLine("	,  {0} ", ObtenerFecha(fechaBajada, True, True))
         .AppendFormatLine("	,  {0} ", ObtenerFecha(fechaInicioSubida, True, True))
         .AppendFormatLine("	,  {0} ", ObtenerFecha(fechaInicioBajada, True, True))
         .AppendFormatLine("	, '{0}'", idUsuario)
         .AppendFormatLine("	, '{0}'", ObtenerFecha(fechaActualizacion, True, True))
         .AppendFormatLine("	, '{0}'", nroVersionAplicacion)
         .AppendFormatLine("	, '{0}'", metodoGrabacion.ToString().Substring(0, 1))
         .AppendFormatLine("	, '{0}'", idFuncion)
         .AppendFormatLine(")")
      End With
      Execute(query)
   End Sub
   Public Sub FechasSincronizaciones_U(sistemaDestino As String, tabla As String,
                                       fechaInicioSubida As Date?, fechaInicioBajada As Date?,
                                       fechaSubida As Date?, fechaBajada As Date?,
                                       idUsuario As String, fechaActualizacion As Date, nroVersionAplicacion As String,
                                       metodoGrabacion As MetodoGrabacion, idFuncion As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE FS")
         .AppendFormatLine("	 SET FS.FechaSubida =  {0} ", ObtenerFecha(fechaSubida, True, True))
         .AppendFormatLine("	   , FS.FechaBajada =  {0} ", ObtenerFecha(fechaBajada, True, True))
         .AppendFormatLine("	   , FS.FechaInicioSubida =  {0} ", ObtenerFecha(fechaInicioSubida, True, True))
         .AppendFormatLine("	   , FS.FechaInicioBajada =  {0} ", ObtenerFecha(fechaInicioBajada, True, True))
         .AppendFormatLine("	   , FS.NroVersionAplicacion = '{0}'", nroVersionAplicacion)
         .AppendFormatLine("     , FS.FechaActualizacion = '{0}'", ObtenerFecha(fechaActualizacion, True, True))
         .AppendFormatLine("	   , FS.MetodoGrabacion = '{0}'", metodoGrabacion.ToString().Substring(0, 1))
         .AppendFormatLine("	   , FS.IdFuncion = '{0}'", idFuncion)
         .AppendFormatLine("  FROM FechasSincronizaciones FS ")
         .AppendFormatLine(" WHERE FS.SistemaDestino = '{0}'", sistemaDestino)
         .AppendFormatLine("   AND FS.Tabla = '{0}'", tabla)
      End With
      Execute(query)
   End Sub
   Public Sub FechasSincronizaciones_U_FechaFinalizacion(sistemaDestino As String, tabla As String,
                                                         campo As Entidades.FechaSincronizacion.Columnas, fecha As Date?, fechaActualizacion As Date)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE FS")
         .AppendFormatLine("	 SET FS.{1} =  {0} ", ObtenerFecha(fecha, True, True), campo.ToString())
         .AppendFormatLine("     , FS.FechaActualizacion = '{0}'", ObtenerFecha(fechaActualizacion, True, True))
         .AppendFormatLine("  FROM FechasSincronizaciones FS ")
         .AppendFormatLine(" WHERE FS.SistemaDestino = '{0}'", sistemaDestino)
         .AppendFormatLine("   AND FS.Tabla = '{0}'", tabla)
      End With
      Execute(query)
   End Sub
   Public Sub FechasSincronizaciones_D(sistemaDestino As String, tabla As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("DELETE FechasSincronizaciones ")
         .AppendFormatLine("WHERE SistemaDestino = '{0}'", sistemaDestino)
         .AppendFormatLine("  AND Tabla = '{0}'", tabla)
      End With
      Execute(query)
   End Sub
   Public Sub FechasSincronizaciones_M(sistemaDestino As String, tabla As String,
                                       fechaInicioSubida As Date?, fechaInicioBajada As Date?,
                                       fechaSubida As Date?, fechaBajada As Date?,
                                       idUsuario As String, fechaActualizacion As Date?, nroVersionAplicacion As String,
                                       metodoGrabacion As MetodoGrabacion, idFuncion As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("MERGE INTO FechasSincronizaciones AS DEST")
         .AppendFormatLine("        USING (SELECT '{0}' SistemaDestino, ", sistemaDestino)
         .AppendFormatLine("					  '{0}' Tabla, ", tabla)
         .AppendFormatLine("					   {0}  FechaInicioSubida, ", ObtenerFecha(fechaInicioSubida, True, True))
         .AppendFormatLine("					   {0}  FechaInicioBajada, ", ObtenerFecha(fechaInicioBajada, True, True))
         .AppendFormatLine("					   {0}  FechaSubida, ", ObtenerFecha(fechaSubida, True, True))
         .AppendFormatLine("					   {0}  FechaBajada, ", ObtenerFecha(fechaBajada, True, True))
         .AppendFormatLine("					  '{0}' IdUsuario, ", idUsuario)
         If fechaActualizacion.HasValue Then
            .AppendFormatLine("					  '{0}' FechaActualizacion, ", ObtenerFecha(fechaActualizacion.Value, True, True))
         End If
         .AppendFormatLine("					  '{0}' NroVersionAplicacion, ", nroVersionAplicacion)
         .AppendFormatLine("					  '{0}' MetodoGrabacion, ", metodoGrabacion.ToString().Substring(0, 1))
         .AppendFormatLine("					  '{0}' IdFuncion ", idFuncion)
         .AppendFormatLine(") AS ORIG ON DEST.SistemaDestino = ORIG.SistemaDestino AND DEST.Tabla = ORIG.Tabla")
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET DEST.FechaInicioSubida = ORIG.FechaInicioSubida")
         .AppendFormatLine("                 , DEST.FechaInicioBajada = ORIG.FechaInicioBajada")
         .AppendFormatLine("                 , DEST.FechaSubida = ORIG.FechaSubida")
         .AppendFormatLine("                 , DEST.FechaBajada = ORIG.FechaBajada")
         If fechaActualizacion.HasValue Then
            .AppendFormatLine("                 , DEST.FechaActualizacion = ORIG.FechaActualizacion")
         End If
         .AppendFormatLine("                 , DEST.MetodoGrabacion = ORIG.MetodoGrabacion")
         .AppendFormatLine("                 , DEST.IdFuncion = ORIG.IdFuncion")
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT (SistemaDestino, Tabla, FechaInicioSubida, FechaInicioBajada, FechaSubida, FechaBajada,")
         .AppendFormatLine("                IdUsuario, FechaActualizacion, NroVersionAplicacion, MetodoGrabacion, IdFuncion) VALUES (")
         .AppendFormatLine("				 ORIG.SistemaDestino")
         .AppendFormatLine("				,ORIG.Tabla")
         .AppendFormatLine("				,ORIG.FechaInicioSubida")
         .AppendFormatLine("				,ORIG.FechaInicioBajada")
         .AppendFormatLine("				,ORIG.FechaSubida")
         .AppendFormatLine("				,ORIG.FechaBajada")
         .AppendFormatLine("				,ORIG.IdUsuario")
         .AppendFormatLine("				,'19000101'") ''ORIG.FechaActualizacion")
         .AppendFormatLine("				,ORIG.NroVersionAplicacion")
         .AppendFormatLine("				,ORIG.MetodoGrabacion")
         .AppendFormatLine("				,ORIG.IdFuncion")
         .AppendFormatLine(");")
      End With
      Execute(query)
   End Sub

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT FS.*")
         .AppendFormatLine("  FROM FechasSincronizaciones FS")
      End With
   End Sub
   Public Function FechasSincronizaciones_GA() As DataTable
      Dim query = New StringBuilder()
      SelectTexto(query)
      Return GetDataTable(query)
   End Function
   Public Function FechasSincronizaciones_G1(sistemaDestino As String, tabla As String) As DataTable '', fechaActualizacion As Date) As DataTable
      Dim query = New StringBuilder()
      With query
         SelectTexto(query)
         '.AppendFormatLine("FROM FechasSincronizaciones FS")
         .AppendFormatLine(" WHERE FS.SistemaDestino = '{0}'")
         .AppendFormatLine("   AND FS.Tabla = '{0}'")
         '.AppendFormatLine("   AND FechaActualizacion = '{0}'")
      End With
      Return GetDataTable(query)
   End Function
   Public Function FechasSincronizaciones_GA_EnEjecucion(sistemaDestino As String) As DataTable
      Dim query = New StringBuilder()
      With query
         SelectTexto(query)
         .AppendFormatLine(" WHERE SistemaDestino = '{0}'", sistemaDestino)
         .AppendFormatLine("   AND ((FechaInicioSubida IS NOT NULL AND FechaSubida IS NULL) OR")
         .AppendFormatLine("        (FechaInicioBajada IS NOT NULL AND FechaBajada IS NULL))")
      End With
      Return GetDataTable(query)
   End Function
   Public Function GetFechaUltimaSincronizacion(sistemaDestino As String, tabla As String) As DataTable
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("SELECT MAX(FS.FechaActualizacion) FechaActualizacion FROM FechasSincronizaciones FS")
         .AppendFormatLine(" WHERE FS.SistemaDestino = '{0}' AND FS.Tabla = '{1}'", sistemaDestino, tabla)
      End With
      Return GetDataTable(query)
   End Function

End Class