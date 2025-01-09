Public Class ParametrosImagenes
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ParametrosImagenes_I(idEmpresa As Integer, idParametro As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO ParametrosImagenes  ")
         .AppendFormatLine("  (IdEmpresa, IdParametroImagen)")
         .AppendFormatLine("  VALUES")
         .AppendFormatLine("  ({0}, '{1}')", idEmpresa, idParametro)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ParametrosImagenes_U(idEmpresa As Integer, idParametro As String)


      'Dim myQuery As StringBuilder = New StringBuilder("")

      'With myQuery
      '   .Append("UPDATE  ")
      '   .Append("ParametrosImagenes  ")
      '   .Append("SET  ")

      '   .Append("ValorParametro = '" & valorParametro & "' ")

      '   .Append("WHERE ")
      '   .Append("idParametro = '" & idParametro & "'")
      'End With

      'Me.Execute(myQuery.ToString())
   End Sub

   Public Function ParametrosImagenes_M(idEmpresaOrigen As Integer, idEmpresaDestino As Integer) As Integer
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("MERGE INTO ParametrosImagenes AS P")
         .AppendFormatLine("        USING (SELECT *, {1} AS IdEmpresaDestino FROM ParametrosImagenes WHERE IdEmpresa = {0}) AS PT ON P.IdParametroImagen = PT.IdParametroImagen AND P.IdEmpresa = PT.IdEmpresaDestino", idEmpresaOrigen, idEmpresaDestino)
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET P.{0} = PT.IdEmpresaDestino", Entidades.ParametroImagen.Columnas.IdEmpresa.ToString())
         .AppendFormatLine("                  ,P.{0} = PT.{0}", Entidades.ParametroImagen.Columnas.IdParametroImagen.ToString())
         .AppendFormatLine("                  ,P.{0} = PT.{0}", Entidades.ParametroImagen.Columnas.ValorParametroImagen.ToString())
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT ({0}, {1}, {2}) VALUES (PT.IdEmpresaDestino, PT.{1}, PT.{2})",
                           Entidades.ParametroImagen.Columnas.IdEmpresa.ToString(), Entidades.ParametroImagen.Columnas.IdParametroImagen.ToString(),
                           Entidades.ParametroImagen.Columnas.ValorParametroImagen.ToString())
         .AppendFormatLine(";")
      End With

      Return Me.Execute(myQuery.ToString())
   End Function


   Public Sub ParametrosImagenes_D(idEmpresa As Integer, idParametro As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM ParametrosImagenes  ")
         .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
         If Not String.IsNullOrWhiteSpace(idParametro) Then
            .AppendFormatLine("   AND IdParametro = '{0}'", idParametro)
         End If
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT PI.*")
         .AppendFormatLine("  FROM ParametrosImagenes PI")
      End With
   End Sub

   Public Function ParametrosImagenes_GA(idEmpresa As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE PI.IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine(" ORDER BY PI.IdParametro")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Overloads Function Buscar(columna As String, valor As String, idEmpresa As Integer) As DataTable
      'If columna = "NombreVendedor" Then
      '   columna = "E.NombreEmpleado"
      'Else
      columna = "PI." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
         .AppendFormatLine("   AND PI.IdEmpresa = {0}", idEmpresa)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Existe(idEmpresa As Integer, idParametro As String) As Boolean
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT * FROM ParametrosImagenes ")
         .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND IdParametroImagen = '{0}'", idParametro)
      End With

      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())
      If dt.Rows.Count > 0 Then
         Return True
      Else
         Return False
      End If
   End Function

   Public Function GetValor(idEmpresa As Integer, idParametro As String) As String
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT ValorParametro ")
         .AppendFormatLine(" FROM ParametrosImagenes")
         .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND IdParametro = '{0}'", idParametro.ToUpper.Trim())
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return dt.Rows(0)("ValorParametro").ToString().Trim()
      Else
         Throw New Exception(String.Format("ATENCION: NO existe el Parametro '{0}' para la Empresa {1} y NO podrá continuar." & vbCrLf & vbCrLf & "Por favor contáctese con Sistemas.",
                                           idParametro.ToUpper().Trim(), idEmpresa))
      End If
   End Function

   Public Sub GrabarFoto(imagen As System.Drawing.Image, idEmpresa As Integer, idParametroImagen As String)
      If Not System.IO.Directory.Exists(Entidades.Publicos.DriverBase + "Eniac\") Then
         System.IO.Directory.CreateDirectory(Entidades.Publicos.DriverBase + "Eniac\")
      End If
      Dim path As String = Entidades.Publicos.DriverBase + "Eniac\" + idParametroImagen + ".jpg"

      Dim stbQuery As StringBuilder = New StringBuilder()

      If imagen IsNot Nothing Then
         imagen.Save(path)

         Dim fsArchivo As System.IO.FileStream = New System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read)

         Dim iFileLength As Integer = Convert.ToInt32(fsArchivo.Length)

         Dim foto(Int32.Parse(fsArchivo.Length.ToString())) As Byte

         fsArchivo.Read(foto, 0, iFileLength)

         fsArchivo.Close()

         With stbQuery
            .AppendLine("UPDATE ParametrosImagenes ")
            .AppendLine("   SET ValorParametroImagen = @Foto ")
            .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
            .AppendFormatLine("   AND IdParametroImagen = '{0}'", idParametroImagen)
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
            .AppendLine("UPDATE ParametrosImagenes ")
            .AppendLine("   SET ValorParametroImagen = NULL")
            .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
            .AppendFormatLine("   AND IdParametroImagen = '{0}'", idParametroImagen)
         End With

         Me.Execute(stbQuery.ToString())
      End If

   End Sub

   Public Sub GrabarParametroImagen(path As String, idEmpresa As Integer, idParametroImagen As String)
      Dim stbQuery As StringBuilder = New StringBuilder()

      Dim fsArchivo As System.IO.FileStream = New System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read)

      Dim iFileLength As Integer = Convert.ToInt32(fsArchivo.Length)

      Dim foto(Int32.Parse(fsArchivo.Length.ToString())) As Byte

      fsArchivo.Read(foto, 0, iFileLength)

      fsArchivo.Close()

      With stbQuery
         If Me.Existe(idEmpresa, idParametroImagen) Then
            .AppendLine("UPDATE ParametrosImagenes ")
            .AppendLine("   SET ValorParametroImagen =  @Foto ")
            .AppendFormatLine(" WHERE IdEmpresa = {0}", idEmpresa)
            .AppendFormatLine("   AND IdParametroImagen = '{0}'", idParametroImagen)
         Else
            .AppendLine("INSERT INTO ParametrosImagenes ")
            .AppendLine("   (IdEmpresa, IdParametroImagen, ValorParametroImagen)")
            .AppendLine(" VALUES ")
            .AppendFormatLine("   ({0}, '{1}', @Foto)", idEmpresa, idParametroImagen)
         End If
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

   End Sub

End Class