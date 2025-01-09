Public Class Nacionalidades
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Nacionalidades_I(idNacionalidad As Integer, nombreNacionalidad As String)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .Length = 0
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}) ",
         Entidades.Nacionalidad.NombreTabla,
         Entidades.Nacionalidad.Columnas.IdNacionalidad.ToString(),
         Entidades.Nacionalidad.Columnas.NombreNacionalidad.ToString())

         .AppendFormat("   VALUES ({1}, '{2}')",
         Entidades.Nacionalidad.NombreTabla, idNacionalidad, nombreNacionalidad)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub Nacionalidades_U(idNacionalidad As Integer, nombreNacionalidad As String)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("UPDATE {0}", Entidades.Nacionalidad.NombreTabla)
         .AppendFormatLine("  SET {0} = '{1}'", Entidades.Nacionalidad.Columnas.NombreNacionalidad.ToString(), nombreNacionalidad)
         .AppendFormatLine("WHERE {0} = {1}", Entidades.Nacionalidad.Columnas.IdNacionalidad.ToString(), idNacionalidad)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub Nacionalidades_D(idNacionalidad As Integer)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.Nacionalidad.NombreTabla, Entidades.Nacionalidad.Columnas.IdNacionalidad.ToString(), idNacionalidad)
      End With
      Me.Execute(query.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT N.* FROM {0} N", Entidades.Nacionalidad.NombreTabla)
      End With
   End Sub

   Private Function Nacionalidades_G(idNacionalidad As Integer, nombreNacionalidad As String, nombreExacto As Boolean) As DataTable
      Dim query As StringBuilder = New StringBuilder()

      With query
         Me.SelectTexto(query)
         .AppendFormatLine("WHERE 1 = 1")
         If idNacionalidad > 0 Then
            .AppendFormatLine(" AND N.IdNacionalidad = {0}", idNacionalidad)
         End If

         If Not String.IsNullOrWhiteSpace(nombreNacionalidad) Then
            If nombreExacto Then
               .AppendFormatLine("  AND N.NombreNacionalidad = '{0}'", nombreNacionalidad)
            Else
               .AppendFormatLine("  AND N.NombreNacionalidad LIKE '%{0}%'", nombreNacionalidad)
            End If
         End If
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function Nacionalidades_GA() As DataTable
      Return Nacionalidades_G(idNacionalidad:=0, nombreNacionalidad:=String.Empty, nombreExacto:=False)
   End Function

   Public Function Nacionalidades_G1(IdNacionalidad As Integer) As DataTable
      Return Nacionalidades_G(idNacionalidad:=IdNacionalidad, nombreNacionalidad:=String.Empty, nombreExacto:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "N." + columna

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.Nacionalidad.Columnas.IdNacionalidad.ToString(), "Nacionalidades"))
   End Function
End Class
