Imports System.Text
Imports System.IO

Public Class Documentos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Documentos_I(ByVal en As Eniac.Entidades.Documento)
      Dim stbQuery As StringBuilder = New StringBuilder("")

      Dim s() As String = en.Nombre.Split(New Char() {"\"c})
      Dim doc As String = s(s.Length - 1)

      With stbQuery
         .Length = 0
         .AppendLine("INSERT INTO Documentos (")
         .AppendLine("       " & Entidades.Documento.Columnas.idDocumento.ToString)
         .AppendLine("      ," & Entidades.Documento.Columnas.Nombre.ToString)
         .AppendLine("      ," & Entidades.Documento.Columnas.Grupo.ToString)
         .AppendLine("      ," & Entidades.Documento.Columnas.Version.ToString)
         .AppendLine("      ," & Entidades.Documento.Columnas.Documento.ToString)
         .AppendLine(") VALUES (")
         .AppendLine("       " & en.idDocumento.ToString)
         .AppendLine("      , '" & doc & "'")
         .AppendLine("      , '" & en.Grupo.ToString & "'")
         .AppendLine("      , " & en.Version.ToString)
         .AppendLine("      ,@Documento")
         .AppendLine(")")
      End With

      Dim fsArchivo As System.IO.FileStream = New System.IO.FileStream(en.Nombre.ToString, System.IO.FileMode.Open, System.IO.FileAccess.Read)

      Dim iFileLength As Integer = Integer.Parse(fsArchivo.Length.ToString()) - 1
      Dim f(iFileLength) As Byte
      fsArchivo.Read(f, 0, iFileLength)

      fsArchivo.Close()

      Me._da.Command.CommandText = stbQuery.ToString()
      Me._da.Command.CommandType = CommandType.Text
      Me._da.Command.Transaction = Me._da.Transaction
      Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
      oParameter.ParameterName = "@Documento"
      oParameter.DbType = DbType.Binary
      oParameter.Size = f.Length
      oParameter.Value = f
      Me._da.Command.Parameters.Add(oParameter)
      Me._da.Command.Connection = Me._da.Connection
      Me._da.ExecuteNonQuery(Me._da.Command)
   End Sub

   Public Sub Documentos_U(ByVal en As Eniac.Entidades.Documento)

      If ((en.Nombre.Contains("/")) Or (en.Nombre.Contains("\"))) Then
         Dim stbQuery As StringBuilder = New StringBuilder("")

         Dim s() As String = en.Nombre.Split(New Char() {"\"c})
         Dim doc As String = s(s.Length - 1)

         With stbQuery
            .Length = 0
            .AppendLine("UPDATE Documentos ")
            .AppendLine("   SET " & Entidades.Documento.Columnas.Nombre.ToString & " = '" & doc & "'")
            .AppendLine("      ," & Entidades.Documento.Columnas.Grupo.ToString & " = '" & en.Grupo.ToString & "'")
            .AppendLine("      ," & Entidades.Documento.Columnas.Version.ToString & " = " & en.Version.ToString)
            .AppendLine("      ," & Entidades.Documento.Columnas.Documento.ToString & " = @Documento")
            .AppendLine(" WHERE " & Entidades.Documento.Columnas.idDocumento.ToString & " = " & en.idDocumento.ToString)
         End With

         Dim fsArchivo As System.IO.FileStream = New System.IO.FileStream(en.Nombre.ToString, System.IO.FileMode.Open, System.IO.FileAccess.Read)

         Dim iFileLength As Integer = Integer.Parse(fsArchivo.Length.ToString()) - 1
         Dim f(iFileLength) As Byte
         fsArchivo.Read(f, 0, iFileLength)

         fsArchivo.Close()

         Me._da.Command.CommandText = stbQuery.ToString()
         Me._da.Command.CommandType = CommandType.Text
         Me._da.Command.Transaction = Me._da.Transaction
         Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
         oParameter.ParameterName = "@Documento"
         oParameter.DbType = DbType.Binary
         oParameter.Size = f.Length
         oParameter.Value = f
         Me._da.Command.Parameters.Add(oParameter)
         Me._da.Command.Connection = Me._da.Connection
         Me._da.ExecuteNonQuery(Me._da.Command)


         Me.Execute(stbQuery.ToString())
         Me.Sincroniza_I(stbQuery.ToString(), "Documentos")
      Else
         Dim stbQuery As StringBuilder = New StringBuilder("")

         Dim s() As String = en.Nombre.Split(New Char() {"\"c})
         Dim doc As String = s(s.Length - 1)

         With stbQuery
            .Length = 0
            .AppendLine("UPDATE Documentos ")
            .AppendLine("   SET ")
            .AppendLine("      " & Entidades.Documento.Columnas.Nombre.ToString & " = '" & doc & "'")
            .AppendLine("      ," & Entidades.Documento.Columnas.Grupo.ToString & " = '" & en.Grupo.ToString & "'")
            .AppendLine("      ," & Entidades.Documento.Columnas.Version.ToString & " = " & en.Version.ToString)
            .AppendLine(" WHERE " & Entidades.Documento.Columnas.idDocumento.ToString & " = " & en.idDocumento.ToString)
         End With

         Me.Execute(stbQuery.ToString())
         Me.Sincroniza_I(stbQuery.ToString(), "Documentos")
      End If

   End Sub

   Public Sub Documentos_D(ByVal idDocumento As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM Documentos ")
         .AppendLine(" WHERE " & Eniac.Entidades.Documento.Columnas.idDocumento.ToString() & " = " & idDocumento.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Documentos")

   End Sub

   Public Sub GrabarDocumento(ByVal path As String)
      Dim stbQuery As StringBuilder = New StringBuilder("")

      Dim s() As String = path.Split(New Char() {"\"c})
      Dim doc As String = s(s.Length - 1)

      With stbQuery
         .Length = 0
         .AppendLine("INSERT INTO Documentos (")
         .AppendLine("       " & Entidades.Documento.Columnas.idDocumento.ToString)
         .AppendLine("      ," & Entidades.Documento.Columnas.Nombre.ToString)
         .AppendLine("      ," & Entidades.Documento.Columnas.Grupo.ToString)
         .AppendLine("      ," & Entidades.Documento.Columnas.Version.ToString)
         .AppendLine("      ," & Entidades.Documento.Columnas.Documento.ToString)
         .AppendLine(") VALUES (")
         .AppendLine("       " & GetProximoCodigoDocumento())
         .AppendLine("      , '" & doc & "'")
         .AppendLine("      , 'Carpeta'")
         .AppendLine("      , '1.2'")
         .AppendLine("      ,@Documento")
         .AppendLine(")")
      End With

      '      If Not System.IO.Directory.Exists(Entidades.Publicos.DriverBase + "Eniac\") Then
      ' System.IO.Directory.CreateDirectory(Entidades.Publicos.DriverBase + "Eniac\")
      ' End If

      Dim fsArchivo As System.IO.FileStream = New System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read)

      Dim iFileLength As Integer = Integer.Parse(fsArchivo.Length.ToString()) - 1
      Dim f(iFileLength) As Byte
      fsArchivo.Read(f, 0, iFileLength)

      fsArchivo.Close()

      Me._da.Command.CommandText = stbQuery.ToString()
      Me._da.Command.CommandType = CommandType.Text
      Me._da.Command.Transaction = Me._da.Transaction
      Dim oParameter As Data.Common.DbParameter = Me._da.Command.CreateParameter()
      oParameter.ParameterName = "@Documento"
      oParameter.DbType = DbType.Binary
      oParameter.Size = f.Length
      oParameter.Value = f
      Me._da.Command.Parameters.Add(oParameter)
      Me._da.Command.Connection = Me._da.Connection
      Me._da.ExecuteNonQuery(Me._da.Command)

   End Sub

   Public Function GetProximoCodigoDocumento() As Long

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(" & Entidades.Documento.Columnas.idDocumento.ToString & ") AS Maximo FROM Documentos")
      End With

      Dim dt As DataTable = Me._da.GetDataTable(stb.ToString())
      Dim val As Long = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
            val = Long.Parse(dt.Rows(0)("Maximo").ToString()) + 1
         Else
            val = 1
         End If
      End If

      Return val

   End Function

   Public Function GetDocumento(ByVal idDocumento As Long) As Eniac.Entidades.Documento
      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         Me.SelectTexto(stbQuery)
         .AppendLine(" WHERE " & Entidades.Documento.Columnas.idDocumento.ToString & " = " & idDocumento.ToString)
      End With
      Dim dt As DataTable = Me.GetDataTable(stbQuery.ToString())

      Dim oDoc As Entidades.Documento = New Entidades.Documento()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)

         oDoc = New Entidades.Documento
         oDoc.idDocumento = Integer.Parse(dr(Entidades.Documento.Columnas.idDocumento.ToString()).ToString())
         oDoc.Nombre = dr(Entidades.Documento.Columnas.Nombre.ToString()).ToString()
         oDoc.Grupo = dr(Entidades.Documento.Columnas.Grupo.ToString()).ToString()
         oDoc.Version = Decimal.Parse(dr(Entidades.Documento.Columnas.Version.ToString()).ToString())
         oDoc.Documento = CType(dr(Entidades.Documento.Columnas.Documento.ToString()), Byte())

      End If

      Return oDoc
   End Function

   Public Function Documentos_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY Nombre")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Documentos_G1(ByVal IdDocumento As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & Entidades.Documento.Columnas.idDocumento.ToString() & " = " & IdDocumento.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT " & Entidades.Documento.Columnas.idDocumento.ToString)
         .AppendLine("       ," & Entidades.Documento.Columnas.Nombre.ToString)
         .AppendLine("       ," & Entidades.Documento.Columnas.Version.ToString)
         .AppendLine("       ," & Entidades.Documento.Columnas.Grupo.ToString)
         .AppendLine("       ," & Entidades.Documento.Columnas.Documento.ToString)
         .AppendLine(" FROM Documentos ")
      End With
   End Sub

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      'columna = "C." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
