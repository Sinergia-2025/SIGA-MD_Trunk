Imports System.Text

Public Class CategoriasImagenes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CategoriasImagenes_I(ByVal en As Entidades.CategoriaImagen)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO CategoriasImagenes ")
         .AppendLine("   (IdCategoriaImagen")
         .AppendLine("   ,IdCategoria")
         .AppendLine("   ,IdTipoNave")
         ' .AppendLine("   ,Foto")

         .AppendLine("   ,ColorFuente")
         .AppendLine("   ,ColorFuenteVto")
         .AppendLine(")     VALUES(")
         .AppendFormat("           {0}", en.IdCategoriaImagen)
         .AppendFormat("           ,{0}", en.Categoria.IdCategoria)
         If en.IdTipoNave <> 0 Then
            .AppendFormat("           ,{0}", en.IdTipoNave)
         Else
            .AppendFormat("           ,null")
         End If
         .AppendFormat("     ,'{0}'", en.ColorFuente)
         .AppendFormat("     ,'{0}'", en.ColorFuenteVto)
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasImagenes")

   End Sub

   Public Sub CategoriasImagenes_U(ByVal en As Entidades.CategoriaImagen)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE CategoriasImagenes ")
         .AppendFormat("  SET IdCategoria = {0}", en.Categoria.IdCategoria)
         If en.IdTipoNave <> 0 Then
            .AppendFormat("     ,IdTipoNave= '{0}'", en.IdTipoNave)
         Else
            .AppendFormat("     ,IdTipoNave= null")
         End If
         .AppendFormat("     ,ColorFuente= '{0}'", en.ColorFuente)
         .AppendFormat("     ,ColorFuenteVto= '{0}'", en.ColorFuenteVto)

         .AppendFormat(" WHERE IdCategoriaImagen = {0}", en.IdCategoriaImagen)

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasImagenes")

   End Sub

   Public Sub CategoriasImagenes_D(ByVal IdCategoriaImagen As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM CategoriasImagenes ")
         .AppendLine(" WHERE IdCategoriaImagen = " & IdCategoriaImagen.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CategoriasImagenes")

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb

         .Length = 0
         .AppendLine("SELECT C.IdCategoriaImagen")
         .AppendLine("      ,C.IdCategoria")
         .AppendLine("      ,CA.NombreCategoria")
         .AppendLine("      ,C.IdTipoNave")
         .AppendLine("      ,TN.NombreTipoNave")
         .AppendLine("      ,C.Foto")
         .AppendLine("      ,C.FotoReverso")
         .AppendLine("      ,C.ColorFuente")
         .AppendLine("      ,C.ColorFuenteVto")
         .AppendLine("      FROM CategoriasImagenes C")
         .AppendLine("      INNER JOIN Categorias CA ON CA.IdCategoria = C.IdCategoria")
         .AppendLine("      LEFT JOIN TiposNaves TN ON TN.IdTipoNave = C.IdTipoNave")

      End With
   End Sub

   Public Function CategoriasImagenes_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY C.IdCategoriaImagen")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CategoriasImagenes_G1(ByVal IdCategoriaImagen As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE C.IdCategoriaImagen = " & IdCategoriaImagen.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "C." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub GrabarFoto(ByVal imagen As System.Drawing.Image, ByVal idCategoriaImagen As Integer)

      If Not System.IO.Directory.Exists(Entidades.Publicos.DriverBase + "Eniac\") Then
         System.IO.Directory.CreateDirectory(Entidades.Publicos.DriverBase + "Eniac\")
      End If

      Dim path As String = Entidades.Publicos.DriverBase + "Eniac\Imagenes\" + idCategoriaImagen.ToString() + ".jpg"

      Dim stbQuery As StringBuilder = New StringBuilder("")

      If imagen IsNot Nothing Then

         Dim fotoParam As Dictionary(Of String, Integer) = GetParametrosFoto()
         Dim imgHandler As ImagenHandler = New ImagenHandler()
         imgHandler.Guardar(imagen, New ImagenHandler.Size(fotoParam.Item("FOTOGUARDADOANCHO"), fotoParam.Item("FOTOGUARDADOALTO")), fotoParam.Item("PORCENTAJECALIDADFOTO"))
         'imagen.Save(path)

         Dim fsArchivo As System.IO.FileStream = New System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read)

         Dim iFileLength As Integer = Integer.Parse(fsArchivo.Length.ToString())

         Dim foto(Integer.Parse(fsArchivo.Length.ToString())) As Byte

         fsArchivo.Read(foto, 0, iFileLength)

         fsArchivo.Close()

         With stbQuery
            .AppendLine("UPDATE CategoriasImagenes SET Foto = @Foto ")
            .AppendFormat(" WHERE IdCategoriaImagen = {0}", idCategoriaImagen)
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
            .AppendLine("UPDATE CategoriasImagenes SET Foto = null ")
            .AppendFormat(" WHERE IdCategoriaImagen = {0}", idCategoriaImagen)
         End With

         Me.Execute(stbQuery.ToString())
      End If

   End Sub

   Public Sub GrabarFotoReverso(ByVal imagen As System.Drawing.Image, ByVal idCategoriaImagen As Integer)

      If Not System.IO.Directory.Exists(Entidades.Publicos.DriverBase + "Eniac\") Then
         System.IO.Directory.CreateDirectory(Entidades.Publicos.DriverBase + "Eniac\")
      End If

      Dim path As String = Entidades.Publicos.DriverBase + "Eniac\Imagenes\" + idCategoriaImagen.ToString() + ".jpg"

      Dim stbQuery As StringBuilder = New StringBuilder("")

      If imagen IsNot Nothing Then

         Dim fotoParam As Dictionary(Of String, Integer) = GetParametrosFoto()
         Dim imgHandler As ImagenHandler = New ImagenHandler()
         imgHandler.Guardar(imagen, New ImagenHandler.Size(fotoParam.Item("FOTOGUARDADOANCHO"), fotoParam.Item("FOTOGUARDADOALTO")), fotoParam.Item("PORCENTAJECALIDADFOTO"))
         'imagen.Save(path)

         Dim fsArchivo As System.IO.FileStream = New System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read)

         Dim iFileLength As Integer = Integer.Parse(fsArchivo.Length.ToString())

         Dim foto(Integer.Parse(fsArchivo.Length.ToString())) As Byte

         fsArchivo.Read(foto, 0, iFileLength)

         fsArchivo.Close()

         With stbQuery
            .AppendLine("UPDATE CategoriasImagenes SET FotoReverso = @Foto ")
            .AppendFormat(" WHERE IdCategoriaImagen = {0}", idCategoriaImagen)
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
            .AppendLine("UPDATE CategoriasImagenes SET FotoReverso = null ")
            .AppendFormat(" WHERE IdCategoriaImagen = {0}", idCategoriaImagen)
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
         .Append("SELECT ValorParametro ")
         .Append(" FROM Parametros")
         .AppendFormat(" WHERE IdParametro = '{0}'", idParametro.ToUpper.Trim())
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return CInt(dt.Rows(0)("ValorParametro"))
      Else
         Return CInt(porDefecto)
      End If
   End Function

   Public Function GetImagenCategoria(ByVal IdCategoria As Integer, ByVal IdTipoNave As Short?) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT * ")
         .AppendLine("      FROM CategoriasImagenes ")
         .AppendLine("      WHERE IdCategoria = " & IdCategoria)
         If IdTipoNave IsNot Nothing Then
            .AppendLine("      AND IdTipoNave = " & IdTipoNave)
         Else
            .AppendLine("   AND IdTipoNave is Null ")
         End If

      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class
