Public Class ClientesDispositivos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

#Region "Insert/Update/Merge/Delete"
   Public Sub ClientesDispositivos_I(idCliente As Long,
                                     nombreServidor As String,
                                     baseDatos As String,
                                     idDispositivo As String,
                                     nombreDispositivo As String,
                                     fechaUltimoLogin As Date,
                                     usuarioUltimoLogin As String,
                                     idTipoDispositivo As String,
                                     sistemaOperativo As String,
                                     arquitecturaSO As String,
                                     numeroSerieDiscoRigido As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO  {0}  (", Entidades.ClienteDispositivo.NombreTabla)
         .AppendFormatLine("             {0} ", Entidades.ClienteDispositivo.Columnas.IdCliente.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteDispositivo.Columnas.NombreServidor.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteDispositivo.Columnas.BaseDatos.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteDispositivo.Columnas.IdDispositivo.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteDispositivo.Columnas.NombreDispositivo.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteDispositivo.Columnas.FechaUltimoLogin.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteDispositivo.Columnas.UsuarioUltimoLogin.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteDispositivo.Columnas.IdTipoDispositivo.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteDispositivo.Columnas.SistemaOperativo.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteDispositivo.Columnas.ArquitecturaSO.ToString())
         .AppendFormatLine("           , {0} ", Entidades.ClienteDispositivo.Columnas.NumeroSerieDiscoRigido.ToString())
         .AppendFormatLine("           ) VALUES (")
         .AppendFormatLine("             {0} ", idCliente)
         .AppendFormatLine("           ,'{0}'", nombreServidor)
         .AppendFormatLine("           ,'{0}'", baseDatos)
         .AppendFormatLine("           ,'{0}'", idDispositivo)
         .AppendFormatLine("           ,'{0}'", nombreDispositivo)
         .AppendFormatLine("           ,'{0}'", ObtenerFecha(fechaUltimoLogin, True))
         .AppendFormatLine("           ,'{0}'", usuarioUltimoLogin)
         .AppendFormatLine("           ,'{0}'", idTipoDispositivo)
         .AppendFormatLine("           ,'{0}'", sistemaOperativo)
         .AppendFormatLine("           ,'{0}'", arquitecturaSO)
         .AppendFormatLine("           ,'{0}'", numeroSerieDiscoRigido)
         .AppendFormatLine("           )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub ClientesDispositivos_U(idCliente As Long,
                                     nombreServidor As String,
                                     baseDatos As String,
                                     idDispositivo As String,
                                     nombreDispositivo As String,
                                     fechaUltimoLogin As Date,
                                     usuarioUltimoLogin As String,
                                     idTipoDispositivo As String,
                                     sistemaOperativo As String,
                                     arquitecturaSO As String,
                                     numeroSerieDiscoRigido As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.ClienteDispositivo.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ClienteDispositivo.Columnas.NombreDispositivo.ToString(), nombreDispositivo)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteDispositivo.Columnas.FechaUltimoLogin.ToString(), ObtenerFecha(fechaUltimoLogin, True))
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteDispositivo.Columnas.UsuarioUltimoLogin.ToString(), usuarioUltimoLogin)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteDispositivo.Columnas.IdTipoDispositivo.ToString(), idTipoDispositivo)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteDispositivo.Columnas.SistemaOperativo.ToString(), sistemaOperativo)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteDispositivo.Columnas.ArquitecturaSO.ToString(), arquitecturaSO)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.ClienteDispositivo.Columnas.NumeroSerieDiscoRigido.ToString(), numeroSerieDiscoRigido)

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ClienteDispositivo.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteDispositivo.Columnas.NombreServidor.ToString(), nombreServidor)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteDispositivo.Columnas.BaseDatos.ToString(), baseDatos)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteDispositivo.Columnas.IdDispositivo.ToString(), idDispositivo)
      End With
      Execute(myQuery)
   End Sub

   Public Sub ClientesDispositivos_D(idCliente As Long)
      ClientesDispositivos_D(idCliente, nombreServidor:=String.Empty, baseDatos:=String.Empty, idDispositivo:=String.Empty)
   End Sub
   Public Sub ClientesDispositivos_D(idCliente As Long,
                                     nombreServidor As String,
                                     baseDatos As String,
                                     idDispositivo As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.ClienteDispositivo.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ClienteDispositivo.Columnas.IdCliente.ToString(), idCliente)
         If Not String.IsNullOrWhiteSpace(nombreServidor) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteDispositivo.Columnas.NombreServidor.ToString(), nombreServidor)
         End If
         If Not String.IsNullOrWhiteSpace(baseDatos) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteDispositivo.Columnas.BaseDatos.ToString(), baseDatos)
         End If
         If Not String.IsNullOrWhiteSpace(idDispositivo) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ClienteDispositivo.Columnas.IdDispositivo.ToString(), idDispositivo)
         End If
      End With
      Execute(myQuery)
   End Sub
#End Region

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CD.*")
         .AppendFormatLine("  FROM {0} AS CD", Entidades.ClienteDispositivo.NombreTabla)
      End With
   End Sub

#Region "GetAll"
   Public Function ClientesDispositivos_GA() As DataTable
      Return ClientesDispositivos_G(idCliente:=0, nombreServidor:=String.Empty, baseDatos:=String.Empty, idDispositivo:=String.Empty)
   End Function
   Public Function ClientesDispositivos_GA(idCliente As Integer) As DataTable
      Return ClientesDispositivos_G(idCliente, nombreServidor:=String.Empty, baseDatos:=String.Empty, idDispositivo:=String.Empty)
   End Function
   Private Function ClientesDispositivos_G(idCliente As Long,
                                           nombreServidor As String,
                                           baseDatos As String,
                                           idDispositivo As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCliente <> 0 Then
            .AppendFormatLine("   AND CD.{0} =  {1} ", Entidades.ClienteDispositivo.Columnas.IdCliente.ToString(), idCliente)
         End If
         If Not String.IsNullOrWhiteSpace(nombreServidor) Then
            .AppendFormatLine("   AND CD.{0} = '{1}'", Entidades.ClienteDispositivo.Columnas.NombreServidor.ToString(), nombreServidor)
         End If
         If Not String.IsNullOrWhiteSpace(baseDatos) Then
            .AppendFormatLine("   AND CD.{0} = '{1}'", Entidades.ClienteDispositivo.Columnas.BaseDatos.ToString(), baseDatos)
         End If
         If Not String.IsNullOrWhiteSpace(idDispositivo) Then
            .AppendFormatLine("   AND CD.{0} = '{1}'", Entidades.ClienteDispositivo.Columnas.IdDispositivo.ToString(), idDispositivo)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function ClientesDispositivos_G1(idCliente As Long,
                                           nombreServidor As String,
                                           baseDatos As String,
                                           idDispositivo As String) As DataTable
      Return ClientesDispositivos_G(idCliente, nombreServidor, baseDatos, idDispositivo)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "CD.")
   End Function
#End Region

   Public Function GetInfClienteDispositivos(idCliente As Long, desde As Date?, hasta As Date?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT D.IdCliente")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("     , C.NombreDeFantasia")
         .AppendFormatLine("     , C.IdZonaGeografica")
         .AppendFormatLine("     , ZG.NombreZonaGeografica")
         .AppendFormatLine("     , C.IdAplicacion")
         .AppendFormatLine("     , A.NombreAplicacion")
         .AppendFormatLine("     , C.IdCategoria")
         .AppendFormatLine("     , Cat.NombreCategoria")
         .AppendFormatLine("     , C.IdCategoriaFiscal")
         .AppendFormatLine("     , CF.NombreCategoriaFiscal")
         .AppendFormatLine("     , D.NombreServidor")
         .AppendFormatLine("     , D.BaseDatos")
         .AppendFormatLine("     , D.IdDispositivo")
         .AppendFormatLine("     , D.NombreDispositivo")
         .AppendFormatLine("     , D.FechaUltimoLogin")
         .AppendFormatLine("     , D.UsuarioUltimoLogin")
         .AppendFormatLine("     , D.IdTipoDispositivo")
         .AppendFormatLine("     , D.Activo")
         .AppendFormatLine("     , D.SistemaOperativo")
         .AppendFormatLine("     , D.ArquitecturaSO")
         .AppendFormatLine("     , D.VersionFramework")
         .AppendFormatLine("     , D.ResolucionPantalla")
         .AppendFormatLine("     , D.NumeroSerieDiscoPrimario")
         .AppendFormatLine("     , D.NumeroSerieDiscoRigido")
         .AppendFormatLine("     , D.NumeroSerieMotherboard")

         .AppendFormatLine("  FROM ClientesDispositivos AS D")
         .AppendFormatLine(" INNER JOIN Clientes AS C ON D.IdCliente = C.IdCliente")
         .AppendFormatLine("  LEFT JOIN ZonasGeograficas ZG ON ZG.IdZonaGeografica = C.IdZonaGeografica")
         .AppendFormatLine("  LEFT JOIN Aplicaciones A ON A.IdAplicacion = C.IdAplicacion")
         .AppendFormatLine("  LEFT JOIN Categorias Cat ON Cat.IdCategoria = C.IdCategoria")
         .AppendFormatLine("  LEFT JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal")

         .AppendFormatLine(" WHERE 1 = 1")
         If idCliente > 0 Then
            .AppendFormatLine("	 AND C.IdCliente = {0}", idCliente)
         End If
         If desde.HasValue Then
            .AppendFormatLine("	 AND D.FechaUltimoLogin >= '{0}'", ObtenerFecha(desde.Value, True))
         End If
         If hasta.HasValue Then
            .AppendFormatLine("   AND D.FechaUltimoLogin <= '{0}'", ObtenerFecha(hasta.Value, True))
         End If
         .AppendFormatLine(" ORDER BY C.NombreCliente, D.FechaUltimoLogin")
      End With
      Return GetDataTable(stb)
   End Function

End Class