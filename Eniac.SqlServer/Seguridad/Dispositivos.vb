Public Class Dispositivos
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Dispositivos_I(idDispositivo As String,
                             nombreDispositivo As String,
                             fechaUltimoLogin As Date?,
                             usuarioUltimoLogin As String,
                             idTipoDispositivo As String,
                             sistemaOperativo As String,
                             arquitecturaSO As String,
                             numeroSerieDiscoRigido As String,
                             direccionMAC As String,
                             numeroSerieMotherboard As String,
                             NumeroSerieDiscoPrimario As String,
                             resolucionPantalla As String,
                             versionFramework As String,
                             activo As Boolean,
                             control1 As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("INSERT INTO Dispositivos")
         .AppendLine("    (IdDispositivo")
         .AppendLine("    ,NombreDispositivo")
         .AppendLine("    ,FechaUltimoLogin")
         .AppendLine("    ,UsuarioUltimoLogin")
         .AppendLine("    ,IdTipoDispositivo")
         .AppendLine("    ,SistemaOperativo")
         .AppendLine("    ,ArquitecturaSO")
         .AppendLine("    ,NumeroSerieDiscoRigido")
         .AppendLine("    ,DireccionMAC")
         .AppendLine("    ,NumeroSerieMotherboard")
         .AppendLine("    ,NumeroSerieDiscoPrimario")
         .AppendLine("    ,ResolucionPantalla")
         .AppendLine("    ,VersionFramework")
         .AppendLine("    ,Activo")
         .AppendLine("    ,Control1")
         .AppendLine(" ) VALUES (")
         .AppendFormatLine("    '{0}'", idDispositivo.ToString())
         .AppendFormatLine("   ,'{0}'", nombreDispositivo)
         If fechaUltimoLogin.HasValue Then
            .AppendFormatLine("   ,'{0}'", Me.ObtenerFecha(fechaUltimoLogin.Value, True))
         Else
            .AppendFormatLine("   ,GetDate()")
         End If
         .AppendFormatLine("   ,'{0}'", usuarioUltimoLogin)
         .AppendFormatLine("   ,'{0}'", idTipoDispositivo)
         .AppendFormatLine("   ,'{0}'", sistemaOperativo.ToString())
         .AppendFormatLine("   ,'{0}'", arquitecturaSO)
         .AppendFormatLine("   ,'{0}'", numeroSerieDiscoRigido)
         .AppendFormatLine("   ,'{0}'", direccionMAC)
         .AppendFormatLine("   ,'{0}'", numeroSerieMotherboard)
         .AppendFormatLine("   ,'{0}'", NumeroSerieDiscoPrimario)
         .AppendFormatLine("   ,'{0}'", resolucionPantalla)
         .AppendFormatLine("   ,'{0}'", versionFramework)
         .AppendFormatLine("   ,'{0}'", activo.ToString())
         .AppendFormatLine("   ,'{0}'", control1)
         .AppendLine(" )")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Dispositivos_U(idDispositivo As String,
                             nombreDispositivo As String,
                             fechaUltimoLogin As Date?,
                             usuarioUltimoLogin As String,
                             idTipoDispositivo As String,
                             sistemaOperativo As String,
                             arquitecturaSO As String,
                             numeroSerieDiscoRigido As String,
                             direccionMAC As String,
                             numeroSerieMotherboard As String,
                             NumeroSerieDiscoPrimario As String,
                             resolucionPantalla As String,
                             versionFramework As String,
                             activo As Boolean,
                             control1 As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE Dispositivos ")
         .AppendFormatLine("   SET NombreDispositivo = '{0}'", nombreDispositivo)
         If fechaUltimoLogin.HasValue Then
            .AppendFormatLine("     , FechaUltimoLogin = '{0}'", ObtenerFecha(fechaUltimoLogin.Value, True))
         Else
            .AppendFormatLine("     , FechaUltimoLogin = GetDate()")
         End If
         .AppendFormatLine("     , UsuarioUltimoLogin = '{0}'", usuarioUltimoLogin)
         .AppendFormatLine("     , IdTipoDispositivo = '{0}'", idTipoDispositivo)
         .AppendFormatLine("     , SistemaOperativo = '{0}'", sistemaOperativo)
         .AppendFormatLine("     , ArquitecturaSO = '{0}'", arquitecturaSO)
         .AppendFormatLine("     , NumeroSerieDiscoRigido = '{0}'", numeroSerieDiscoRigido)
         .AppendFormatLine("     , DireccionMAC = '{0}'", direccionMAC)
         .AppendFormatLine("     , NumeroSerieMotherboard = '{0}'", numeroSerieMotherboard)
         .AppendFormatLine("     , NumeroSerieDiscoPrimario = '{0}'", NumeroSerieDiscoPrimario)
         .AppendFormatLine("     , ResolucionPantalla = '{0}'", resolucionPantalla)
         .AppendFormatLine("     , VersionFramework = '{0}'", versionFramework)
         .AppendFormatLine("     , Activo = '{0}'", activo.ToString())
         .AppendFormatLine("     , Control1 = '{0}'", control1)
         .AppendFormatLine(" WHERE IdDispositivo = '{0}'", idDispositivo)
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   Public Sub Dispositivos_M(idDispositivo As String,
                             nombreDispositivo As String,
                             fechaUltimoLogin As Date?,
                             usuarioUltimoLogin As String,
                             idTipoDispositivo As String,
                             sistemaOperativo As String,
                             arquitecturaSO As String,
                             numeroSerieDiscoRigido As String,
                             direccionMAC As String,
                             numeroSerieMotherboard As String,
                             NumeroSerieDiscoPrimario As String,
                             resolucionPantalla As String,
                             versionFramework As String,
                             control1 As String)  ',
      ')
      'activo As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("MERGE INTO Dispositivos AS D")
         .AppendFormatLine("        USING (SELECT '{0}' IdDispositivo", idDispositivo)
         .AppendFormatLine("                     ,'{0}' NombreDispositivo", nombreDispositivo)
         If fechaUltimoLogin.HasValue Then
            .AppendFormatLine("                     ,'{0}' FechaUltimoLogin", ObtenerFecha(fechaUltimoLogin.Value, True))
         Else
            .AppendFormatLine("                     ,GetDate() FechaUltimoLogin")
         End If
         .AppendFormatLine("                     ,'{0}' UsuarioUltimoLogin", usuarioUltimoLogin)
         .AppendFormatLine("                     ,'{0}' IdTipoDispositivo", idTipoDispositivo)
         .AppendFormatLine("                     ,'{0}' SistemaOperativo", sistemaOperativo)
         .AppendFormatLine("                     ,'{0}' ArquitecturaSO", arquitecturaSO)
         .AppendFormatLine("                     ,'{0}' NumeroSerieDiscoRigido", numeroSerieDiscoRigido)
         .AppendFormatLine("                     ,'{0}' DireccionMAC", direccionMAC)
         .AppendFormatLine("                     ,'{0}' NumeroSerieMotherboard", numeroSerieMotherboard)
         .AppendFormatLine("                     ,'{0}' NumeroSerieDiscoPrimario", NumeroSerieDiscoPrimario)
         .AppendFormatLine("                     ,'{0}' ResolucionPantalla", resolucionPantalla)
         .AppendFormatLine("                     ,'{0}' VersionFramework", versionFramework)
         .AppendFormatLine("                     ,'{0}' Activo", "True")
         .AppendFormatLine("                     ,'{0}' Control1", control1) '--Si es llamado para alta Pincha o ver como resolverlo lo del login, hay que usar el alta normal.
         .AppendFormatLine("              ) AS O ON D.IdDispositivo = O.IdDispositivo")
         .AppendFormatLine("    WHEN MATCHED THEN ")
         .AppendFormatLine("        UPDATE")
         .AppendFormatLine("           SET D.NombreDispositivo        = O.NombreDispositivo")
         .AppendFormatLine("             , D.FechaUltimoLogin         = O.FechaUltimoLogin")
         .AppendFormatLine("             , D.UsuarioUltimoLogin       = O.UsuarioUltimoLogin")
         .AppendFormatLine("             , D.IdTipoDispositivo        = O.IdTipoDispositivo")
         .AppendFormatLine("             , D.SistemaOperativo         = O.SistemaOperativo")
         .AppendFormatLine("             , D.ArquitecturaSO           = O.ArquitecturaSO")
         .AppendFormatLine("             , D.NumeroSerieDiscoRigido   = O.NumeroSerieDiscoRigido")
         .AppendFormatLine("             , D.DireccionMAC             = O.DireccionMAC")
         .AppendFormatLine("             , D.NumeroSerieMotherboard   = O.NumeroSerieMotherboard")
         .AppendFormatLine("             , D.NumeroSerieDiscoPrimario = O.NumeroSerieDiscoPrimario")
         .AppendFormatLine("             , D.ResolucionPantalla       = O.ResolucionPantalla")
         .AppendFormatLine("             , D.VersionFramework         = O.VersionFramework")
         .AppendFormatLine("             , D.Activo                   = O.Activo")
         .AppendFormatLine("             , D.Control1                 = O.Control1")
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT(idDispositivo, nombreDispositivo, fechaUltimoLogin, usuarioUltimoLogin, idTipoDispositivo, sistemaOperativo, arquitecturaSO, numeroSerieDiscoRigido, direccionMAC, NumeroSerieMotherboard, NumeroSerieDiscoPrimario, ResolucionPantalla, VersionFramework, Activo, Control1)")   '
         .AppendFormatLine("        VALUES (O.IdDispositivo, O.NombreDispositivo, O.FechaUltimoLogin, O.UsuarioUltimoLogin, O.IdTipoDispositivo, O.SistemaOperativo, O.ArquitecturaSO, O.NumeroSerieDiscoRigido, O.DireccionMAC, O.NumeroSerieMotherboard, O.NumeroSerieDiscoPrimario, O.ResolucionPantalla, O.VersionFramework, O.Activo, O.Control1);")   '
      End With

      Me.Execute(myQuery.ToString())

   End Sub

   'GAR: 07/01/2023: Anulo el codigo preventivamente porque no se permite borrar.
   'Public Sub Dispositivos_D(idDispositivo As String)
   '   Dim myQuery As StringBuilder = New StringBuilder()
   '   With myQuery
   '      .AppendFormat("DELETE FROM {0} ", Entidades.Dispositivo.NombreTabla)
   '      .AppendFormat(" WHERE {0} = '{1}'", Entidades.Dispositivo.Columnas.IdDispositivo.ToString(), idDispositivo)
   '   End With

   '   Me.Execute(myQuery.ToString())
   'End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT D.*")
         .AppendLine("  FROM Dispositivos D")
      End With
   End Sub

   Private Function Dispositivos_G(idDispositivo As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idDispositivo) Then
            .AppendFormatLine(" AND IdDispositivo = '{0}'", idDispositivo)
         End If
         .Append("  ORDER BY D.NombreDispositivo")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Dispositivos_GA() As DataTable
      Return Dispositivos_G(idDispositivo:=String.Empty)
   End Function

   Public Function Dispositivos_G1(idDispositivo As String) As DataTable
      Return Dispositivos_G(idDispositivo)
   End Function

   Public Function Buscar(columna As String, valor As String) As DataTable
      columna = "D." + columna
      'If columna = "D.NombreLocalidad" Then columna = columna.Replace("D.", "L.")
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetLicenciasVsDispositivos(DiasControlDeLicencias As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         '--C.Idcliente, C.NombreCliente AS Nombre
         .AppendLine("SELECT C.CodigoCliente AS Codigo, C.NombreDeFantasia AS Fantasia, Ca.NombreCategoria AS Categoria, Ca.IdGrupoCategoria AS Grupo")
         .AppendLine("     , A.NombreAplicacion AS Sistema")
         .AppendLine("     , NroVersion, FechaActualizacionVersion AS Actualizado")
         .AppendLine("     , C.CantidadDePCs AS Licencias, CD.CantidadDispositivos AS Utiliza")
         .AppendLine("	   , CD.CantidadDispositivos-C.CantidadDePCs AS Dif")
         .AppendLine("  From Clientes C")
         .AppendLine(" INNER JOIN Categorias Ca ON Ca.IdCategoria = C.IdCategoria")
         .AppendLine(" INNER JOIN Aplicaciones A ON A.IdAplicacion = C.IdAplicacion")
         .AppendLine(" INNER JOIN (SELECT A.IdCliente, Count(DISTINCT A.NombreDispositivo) AS CantidadDispositivos")
         .AppendLine("			       FROM ClientesDispositivos A")
         .AppendLine("			      WHERE A.IdTipoDispositivo = 'PC'")
         .AppendLine("                AND A.FechaUltimoLogin > GETDATE() - " & DiasControlDeLicencias.ToString())
         '--And A.IdCliente = 247
         '--And A.IdDispositivo = A.NombreDispositivo -- Los iguales son los de la nueva version.
         .AppendLine("			 GROUP BY A.IdCliente")
         .AppendLine("			) CD")
         .AppendLine("    On CD.IdCliente = C.IdCliente")
         .AppendLine(" WHERE CD.CantidadDispositivos > C.CantidadDePCs")
         .AppendLine(" ORDER BY Dif DESC")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class