Public Class CRMTiposNovedades
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CRMTiposNovedades_I(idTipoNovedad As String,
                                  nombreTipoNovedad As String,
                                  unidadDeMedida As String,
                                  usuarioRequerido As Boolean,
                                  usuarioPorDefecto As Boolean,
                                  proximoContactoRequerido As Boolean,
                                  primerOrdenGrilla As String,
                                  primerOrdenDesc As Boolean,
                                  segundoOrdenGrilla As String,
                                  segundoOrdenDesc As Boolean,
                                  visualizaOtrasNovedades As Boolean,
                                  visualizaRevisionAdministrativa As Boolean,
                                  permiteBorrarComentarios As Boolean,
                                  diasProximoContacto As Integer,
                                  permiteIngresarNumero As Boolean,
                                  reportaAvance As Boolean,
                                  reportaCantidad As Boolean,
                                  letrasHabilitadas As String,
                                  verCambios As Boolean,
                                  requierePadre As Boolean,
                                  reporte As String,
                                  embebido As Boolean,
                                  cantidadCopias As Integer,
                                  solapaPorDefecto As Entidades.CRMTipoNovedad.SolapaPorDef,
                                  visualizaSucursal As String)


      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendFormat("INSERT INTO CRMTiposNovedades ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17},{18}, {19}, {20}, {21}, {22}, {23})",
                       Entidades.CRMTipoNovedad.Columnas.IdTipoNovedad.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.UnidadDeMedida.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.UsuarioRequerido.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.UsuarioPorDefecto.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.ProximoContactoRequerido.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.PrimerOrdenGrilla.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.PrimerOrdenDesc.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.SegundoOrdenGrilla.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.SegundoOrdenDesc.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.VisualizaOtrasNovedades.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.VisualizaRevisionAdministrativa.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.PermiteBorrarComentarios.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.DiasProximoContacto.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.PermiteIngresarNumero.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.ReportaAvance.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.ReportaCantidad.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.LetrasHabilitadas.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.VerCambios.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.RequierePadre.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.Reporte.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.Embebido.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.CantidadCopias.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.SolapaPorDefecto.ToString(),
                       Entidades.CRMTipoNovedad.Columnas.VisualizaSucursal.ToString()
                       ).AppendLine()

         .AppendFormat("     VALUES ('{0}', '{1}', '{2}', {3}, {4}, {5}, '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', {13}, {14}, {15}, {16}, '{17}',{18}, {19}, '{20}', {21}, {22}, '{23}')",
                       idTipoNovedad,
                       nombreTipoNovedad,
                       unidadDeMedida,
                       GetStringFromBoolean(usuarioRequerido),
                       GetStringFromBoolean(usuarioPorDefecto),
                       GetStringFromBoolean(proximoContactoRequerido),
                       primerOrdenGrilla,
                       GetStringFromBoolean(primerOrdenDesc),
                       segundoOrdenGrilla,
                       GetStringFromBoolean(segundoOrdenDesc),
                       GetStringFromBoolean(visualizaOtrasNovedades),
                       GetStringFromBoolean(visualizaRevisionAdministrativa),
                       GetStringFromBoolean(permiteBorrarComentarios),
                       diasProximoContacto,
                       GetStringFromBoolean(permiteIngresarNumero),
                       GetStringFromBoolean(reportaAvance),
                       GetStringFromBoolean(reportaCantidad),
                       letrasHabilitadas,
                       GetStringFromBoolean(verCambios),
                       GetStringFromBoolean(requierePadre),
                       reporte,
                       GetStringFromBoolean(embebido),
                       cantidadCopias,
                       solapaPorDefecto.ToString(),
                       visualizaSucursal)
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub CRMTiposNovedades_U(idTipoNovedad As String,
                                  nombreTipoNovedad As String,
                                  unidadDeMedida As String,
                                  usuarioRequerido As Boolean,
                                  usuarioPorDefecto As Boolean,
                                  proximoContactoRequerido As Boolean,
                                  primerOrdenGrilla As String,
                                  primerOrdenDesc As Boolean,
                                  segundoOrdenGrilla As String,
                                  segundoOrdenDesc As Boolean,
                                  visualizaOtrasNovedades As Boolean,
                                  visualizaRevisionAdministrativa As Boolean,
                                  permiteBorrarComentarios As Boolean,
                                  diasProximoContacto As Integer,
                                  permiteIngresarNumero As Boolean,
                                  reportaAvance As Boolean,
                                  reportaCantidad As Boolean,
                                  letrasHabilitadas As String,
                                  verCambios As Boolean,
                                  RequierePadre As Boolean,
                                  reporte As String,
                                  embebido As Boolean,
                                  cantidadCopias As Integer,
                                  solapaPorDefecto As Entidades.CRMTipoNovedad.SolapaPorDef,
                                  visualizaSucursal As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE CRMTiposNovedades ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString(), nombreTipoNovedad)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.UnidadDeMedida.ToString(), unidadDeMedida)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.UsuarioRequerido.ToString(), GetStringFromBoolean(usuarioRequerido))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.UsuarioPorDefecto.ToString(), GetStringFromBoolean(usuarioPorDefecto))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.ProximoContactoRequerido.ToString(), GetStringFromBoolean(proximoContactoRequerido))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.PrimerOrdenGrilla.ToString(), primerOrdenGrilla)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.PrimerOrdenDesc.ToString(), GetStringFromBoolean(primerOrdenDesc))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.SegundoOrdenGrilla.ToString(), segundoOrdenGrilla)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.SegundoOrdenDesc.ToString(), GetStringFromBoolean(segundoOrdenDesc))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.VisualizaOtrasNovedades.ToString(), GetStringFromBoolean(visualizaOtrasNovedades))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.VisualizaRevisionAdministrativa.ToString(), GetStringFromBoolean(visualizaRevisionAdministrativa))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.PermiteBorrarComentarios.ToString(), GetStringFromBoolean(permiteBorrarComentarios))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMTipoNovedad.Columnas.DiasProximoContacto.ToString(), diasProximoContacto)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMTipoNovedad.Columnas.PermiteIngresarNumero.ToString(), GetStringFromBoolean(permiteIngresarNumero))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMTipoNovedad.Columnas.ReportaAvance.ToString(), GetStringFromBoolean(reportaAvance))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMTipoNovedad.Columnas.ReportaCantidad.ToString(), GetStringFromBoolean(reportaCantidad))
         .AppendFormatLine("     , {0} =  '{1}'", Entidades.CRMTipoNovedad.Columnas.LetrasHabilitadas.ToString(), letrasHabilitadas)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMTipoNovedad.Columnas.VerCambios.ToString(), GetStringFromBoolean(verCambios))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CRMTipoNovedad.Columnas.RequierePadre.ToString(), GetStringFromBoolean(RequierePadre))

         .AppendFormatLine("     , {0} = '{1}' ", Entidades.CRMTipoNovedad.Columnas.Reporte.ToString(), reporte)
         .AppendFormatLine("     , {0} = {1} ", Entidades.CRMTipoNovedad.Columnas.Embebido.ToString(), GetStringFromBoolean(embebido))
         .AppendFormatLine("     , {0} = {1} ", Entidades.CRMTipoNovedad.Columnas.CantidadCopias.ToString(), cantidadCopias)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.SolapaPorDefecto.ToString(), solapaPorDefecto.ToString())
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.VisualizaSucursal.ToString(), visualizaSucursal)

         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub CRMTiposNovedades_D(idTipoNovedad As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE CRMTiposNovedades WHERE {0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT TN.* FROM CRMTiposNovedades AS TN").AppendLine()
      End With
   End Sub

   Public Function CRMTiposNovedades_GA(reportaCantidad As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         .AppendFormat(" AND TN.{0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.ReportaCantidad.ToString(), GetStringFromBoolean(reportaCantidad))
         .AppendFormat(" ORDER BY TN.NombreTipoNovedad")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CRMTiposNovedades_GA1(aplicaSeguridad As Boolean, idTipoNovedad As String,
                                         conDinamicos As Entidades.CRMTipoNovedad.TipoDinamico()) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If aplicaSeguridad Then
            .AppendFormatLine(" AND EXISTS (SELECT * FROM RolesFunciones RF")
            .AppendFormatLine("                INNER JOIN UsuariosRoles UR ON UR.IdRol = RF.IdRol")
            .AppendFormatLine("				WHERE RF.IdFuncion = 'CRMNOVEDADESABM' + TN.IdTipoNovedad")
            .AppendFormatLine("				  AND UR.IdUsuario = '{0}'", actual.Nombre)
            .AppendFormatLine("				  AND UR.IdSucursal = {0})", actual.Sucursal.Id)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoNovedad) Then
            .AppendFormatLine(" AND TN.{0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
         End If
         If conDinamicos.Count > 0 Then
            .AppendFormatLine("   AND EXISTS(SELECT * FROM CRMTiposNovedadesDinamicos D WHERE D.IdTipoNovedad = TN.IdTipoNovedad")
            .AppendFormatLine("                 AND D.IdNombreDinamico IN ({0}))", conDinamicos.JoinParaIn())
         End If
         .AppendFormat(" ORDER BY TN.NombreTipoNovedad")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function CRMTiposNovedades_G1(idTipoNovedad As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE TN.{0} = '{1}'", Entidades.CRMTipoNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      columna = "TN." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())

   End Function
End Class