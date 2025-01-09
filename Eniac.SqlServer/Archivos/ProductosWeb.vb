Public Class ProductosWeb
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProductosWeb_I(idProducto As String,
                          Caracteristica1 As String,
                          ValorCaracteristica1 As String,
                          Caracteristica2 As String,
                          ValorCaracteristica2 As String,
                          Caracteristica3 As String,
                          ValorCaracteristica3 As String,
                          Base As String,
                          EsParaConstructora As Boolean,
                          EsParaIndustria As Boolean,
                          EsParaCooperativaElectrica As Boolean,
                          EsParaMayorista As Boolean,
                          EsParaMinorista As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO " & Base & "ProductosWeb (")
         .AppendLine("   IdProducto")
         .AppendLine(" ,Caracteristica1")
         .AppendLine(" ,ValorCaracteristica1")
         .AppendLine(" ,Caracteristica2")
         .AppendLine(" ,ValorCaracteristica2")
         .AppendLine(" ,Caracteristica3")
         .AppendLine(" ,ValorCaracteristica3")
         .AppendLine(" ,EsParaConstructora")
         .AppendLine(" ,EsParaIndustria")
         .AppendLine(" ,EsParaCooperativaElectrica")
         .AppendLine(" ,EsParaMayorista")
         .AppendLine(" ,EsParaMinorista")
         .AppendLine(") VALUES (")
         .AppendLine("  '" & idProducto & "'")
         .AppendFormat(" ,'{0}'", Caracteristica1).AppendLine()
         .AppendFormat(" ,'{0}'", ValorCaracteristica1).AppendLine()
         .AppendFormat(" ,'{0}'", Caracteristica2).AppendLine()
         .AppendFormat(" ,'{0}'", ValorCaracteristica2).AppendLine()
         .AppendFormat(" ,'{0}'", Caracteristica3).AppendLine()
         .AppendFormat(" ,'{0}'", ValorCaracteristica3).AppendLine()
         .AppendFormat(" ,'{0}'", EsParaConstructora).AppendLine()
         .AppendFormat(" ,'{0}'", EsParaIndustria).AppendLine()
         .AppendFormat(" ,'{0}'", EsParaCooperativaElectrica).AppendLine()
         .AppendFormat(" ,'{0}'", EsParaMayorista).AppendLine()
         .AppendFormat(" ,'{0}'", EsParaMinorista).AppendLine()

         .AppendLine(") ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ProductosWeb")

   End Sub

   Public Sub ProductosWeb_U(idProducto As String,
                          Caracteristica1 As String,
                          ValorCaracteristica1 As String,
                          Caracteristica2 As String,
                          ValorCaracteristica2 As String,
                          Caracteristica3 As String,
                          ValorCaracteristica3 As String,
                          Base As String,
                          EsParaConstructora As Boolean,
                          EsParaIndustria As Boolean,
                          EsParaCooperativaElectrica As Boolean,
                          EsParaMayorista As Boolean,
                          EsParaMinorista As Boolean,
                          modificoParWebPara As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE " & Base & "ProductosWeb SET ")
         .AppendFormat("  Caracteristica1 = '{0}'", Caracteristica1).AppendLine()
         .AppendFormat("  ,ValorCaracteristica1 = '{0}'", ValorCaracteristica1).AppendLine()
         .AppendFormat("  ,Caracteristica2 = '{0}'", Caracteristica2).AppendLine()
         .AppendFormat("  ,ValorCaracteristica2 = '{0}'", ValorCaracteristica2).AppendLine()
         .AppendFormat("  ,Caracteristica3 = '{0}'", Caracteristica3).AppendLine()
         .AppendFormat("  ,ValorCaracteristica3 = '{0}'", ValorCaracteristica3).AppendLine()

         If modificoParWebPara Then
            .AppendFormat("  ,EsParaConstructora = '{0}'", EsParaConstructora).AppendLine()
            .AppendFormat("  ,EsParaIndustria = '{0}'", EsParaIndustria).AppendLine()
            .AppendFormat("  ,EsParaCooperativaElectrica = '{0}'", EsParaCooperativaElectrica).AppendLine()
            .AppendFormat("  ,EsParaMayorista = '{0}'", EsParaMayorista).AppendLine()
            .AppendFormat("  ,EsParaMinorista = '{0}'", EsParaMinorista).AppendLine()
         End If

         .AppendFormat(" WHERE IdProducto = '{0}'", idProducto)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Productos")

   End Sub

   Public Sub ProductosWeb_D(ByVal idProducto As String, base As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM " & base & "ProductosWeb ")
         .Append(" WHERE IdProducto = '" & idProducto & "'")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ProductosWeb")

   End Sub

   Public Function ProductosWeb_GA(base As String) As DataTable

      Return ProductosWeb_GA(False, base)

   End Function

   Public Function ProductosWeb_G1(idProducto As String, base As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()
      Dim consultaFoto As Boolean = False

      Me.SelectTexto(myQuery, consultaFoto, base)

      With myQuery
         .AppendLine(" WHERE 1 = 1 ")
         .AppendFormat("   AND IdProducto = '{0}' ", idProducto).AppendLine()
         ' .AppendLine(" ORDER BY P.NombreProducto  ")
      End With

      Return Me.GetDataTable(myQuery.ToString())


      Return ProductosWeb_GA(False, base)

   End Function

   Public Function ProductosWeb_GA(soloObservacion As Boolean, base As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")
      Dim consultaFoto As Boolean = False

      Me.SelectTexto(myQuery, consultaFoto, base)

      With myQuery

         .AppendLine(" WHERE 1 = 1 ")
         If soloObservacion Then
            .AppendFormat("   AND P.EsObservacion = 1")
         End If
         .AppendLine(" ORDER BY P.NombreProducto  ")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Private Sub SelectTexto(ByVal stb As StringBuilder, ByVal incluirFoto As Boolean, base As String)

      Dim strAnchoIdProducto As String
      strAnchoIdProducto = Me.GetAnchoCampo("Productos", "IdProducto").ToString()

      With stb
         .Length = 0

         .AppendLine("SELECT RIGHT(REPLICATE(' '," & strAnchoIdProducto & ") + P.IdProducto," & strAnchoIdProducto & ") as IdProducto")
         .AppendLine("      ,P.Caracteristica1")
         .AppendLine("      ,P.ValorCaracteristica1")
         .AppendLine("      ,P.Caracteristica2")
         .AppendLine("      ,P.ValorCaracteristica2")
         .AppendLine("      ,P.Caracteristica3")
         .AppendLine("      ,P.ValorCaracteristica3")
         .AppendLine("      ,P.Foto2")
         .AppendLine("      ,P.Foto3")
         .AppendLine("      ,P.EsParaConstructora")
         .AppendLine("      ,P.EsParaIndustria")
         .AppendLine("      ,P.EsParaCooperativaElectrica")
         .AppendLine("      ,P.EsParaMayorista")
         .AppendLine("      ,P.EsParaMinorista")
         .AppendLine(" FROM " & base & "ProductosWeb P ")
      End With

   End Sub

   Public Sub GrabarFoto2(ByVal imagen As System.Drawing.Image, ByVal idProducto As String, ByVal base As String)



      ''If Not System.IO.Directory.Exists(Entidades.Publicos.DriverBase + "Eniac\") Then
      ''   System.IO.Directory.CreateDirectory(Entidades.Publicos.DriverBase + "Eniac\")
      ''End If

      ''Dim path As String = Entidades.Publicos.DriverBase + "Eniac\" + idProducto.Replace("/", "_") + ".jpg"

      Dim stbQuery As StringBuilder = New StringBuilder()

      If imagen IsNot Nothing Then
         ''imagen.Save(path)

         ''Dim fsArchivo As System.IO.FileStream = New System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read)

         ''Dim iFileLength As Integer = Integer.Parse(fsArchivo.Length.ToString())

         ''Dim foto(Integer.Parse(fsArchivo.Length.ToString())) As Byte

         ''fsArchivo.Read(foto, 0, iFileLength)

         ''fsArchivo.Close()


         Dim fotoParam As Dictionary(Of String, Integer) = GetParametrosFoto()
         Dim imgHandler As ImagenHandler = New ImagenHandler()
         Dim foto As Byte() = imgHandler.Guardar(imagen, New ImagenHandler.Size(fotoParam.Item("FOTOGUARDADOANCHO"), fotoParam.Item("FOTOGUARDADOALTO")), fotoParam.Item("PORCENTAJECALIDADFOTO"))

         With stbQuery
            .AppendFormat(" UPDATE " & base & "ProductosWeb SET Foto2 = @Foto WHERE IdProducto = '{0}'", idProducto)
         End With

         Me._da.Command.CommandText = stbQuery.ToString()
         Me._da.Command.CommandType = CommandType.Text
         Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
         oParameter.ParameterName = "@Foto"
         oParameter.DbType = DbType.Binary
         oParameter.Size = foto.Length
         oParameter.Value = foto
         Me._da.Command.Parameters.Add(oParameter)
         Me._da.Command.Connection = Me._da.Connection
         Me._da.ExecuteNonQuery(Me._da.Command)
      Else
         With stbQuery
            .AppendFormat(" UPDATE " & base & "ProductosWeb SET Foto2 = NULL WHERE IdProducto = '{0}'", idProducto)
         End With

         Me.Execute(stbQuery.ToString())
      End If

   End Sub

   Public Sub GrabarFoto3(ByVal imagen As System.Drawing.Image, ByVal idProducto As String, ByVal base As String)



      ''If Not System.IO.Directory.Exists(Entidades.Publicos.DriverBase + "Eniac\") Then
      ''   System.IO.Directory.CreateDirectory(Entidades.Publicos.DriverBase + "Eniac\")
      ''End If

      ''Dim path As String = Entidades.Publicos.DriverBase + "Eniac\" + idProducto.Replace("/", "_") + ".jpg"

      Dim stbQuery As StringBuilder = New StringBuilder()

      If imagen IsNot Nothing Then
         ''imagen.Save(path)

         ''Dim fsArchivo As System.IO.FileStream = New System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read)

         ''Dim iFileLength As Integer = Integer.Parse(fsArchivo.Length.ToString())

         ''Dim foto(Integer.Parse(fsArchivo.Length.ToString())) As Byte

         ''fsArchivo.Read(foto, 0, iFileLength)

         ''fsArchivo.Close()


         Dim fotoParam As Dictionary(Of String, Integer) = GetParametrosFoto()
         Dim imgHandler As ImagenHandler = New ImagenHandler()
         Dim foto As Byte() = imgHandler.Guardar(imagen, New ImagenHandler.Size(fotoParam.Item("FOTOGUARDADOANCHO"), fotoParam.Item("FOTOGUARDADOALTO")), fotoParam.Item("PORCENTAJECALIDADFOTO"))

         With stbQuery
            .AppendFormat(" UPDATE " & base & "ProductosWeb SET Foto3 = @Foto WHERE IdProducto = '{0}'", idProducto)
         End With

         Me._da.Command.CommandText = stbQuery.ToString()
         Me._da.Command.CommandType = CommandType.Text
         Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
         oParameter.ParameterName = "@Foto"
         oParameter.DbType = DbType.Binary
         oParameter.Size = foto.Length
         oParameter.Value = foto
         Me._da.Command.Parameters.Add(oParameter)
         Me._da.Command.Connection = Me._da.Connection
         Me._da.ExecuteNonQuery(Me._da.Command)
      Else
         With stbQuery
            .AppendFormat(" UPDATE " & base & "ProductosWeb SET Foto3 = NULL WHERE IdProducto = '{0}'", idProducto)
         End With

         Me.Execute(stbQuery.ToString())
      End If

   End Sub

   Public Overloads Function GetParametrosFoto() As Dictionary(Of String, Integer)
      Dim ret As New Dictionary(Of String, Integer)
      ret.Add("PORCENTAJECALIDADFOTO", Me.GetParametrosFoto("PORCENTAJECALIDADFOTO", 70))
      ret.Add("FOTOGUARDADOANCHO", Me.GetParametrosFoto("FOTOGUARDADOANCHO", 800))
      ret.Add("FOTOGUARDADOALTO", Me.GetParametrosFoto("FOTOGUARDADOALTO", 600))
      Return ret
   End Function

   Public Overloads Function GetParametrosFoto(ByVal idParametro As String, ByVal porDefecto As Integer) As Integer
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .AppendFormat("SELECT ValorParametro FROM Parametros WHERE IdParametro = '{0}'", idParametro.ToUpper.Trim())
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return CInt(dt.Rows(0)("ValorParametro"))
      Else
         Return CInt(porDefecto)
      End If
   End Function

  End Class
