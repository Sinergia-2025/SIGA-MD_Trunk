Public Class MRPConceptosNoProductivos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MRPConceptosNoProductivos_I(idConceptoNoProductivo As Integer,
                                          codigoConceptoNoProductivo As String,
                                          nombreConceptoNoProductivo As String,
                                          activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}, {3}, {4})",
                           Entidades.MRPConceptoNoProductivo.NombreTabla,
                           Entidades.MRPConceptoNoProductivo.Columnas.IdConceptoNoProductivo.ToString(),
                           Entidades.MRPConceptoNoProductivo.Columnas.CodigoConceptoNoProductivo.ToString(),
                           Entidades.MRPConceptoNoProductivo.Columnas.NombreConceptoNoProductivo.ToString(),
                           Entidades.MRPConceptoNoProductivo.Columnas.Activo.ToString())
         .AppendFormatLine("  VALUES ({0}, '{1}', '{2}', {3})",
                           idConceptoNoProductivo, codigoConceptoNoProductivo.ToUpper(), nombreConceptoNoProductivo, GetStringFromBoolean(activo))
      End With
      Execute(myQuery)
   End Sub

   Public Sub MRPConceptosNoProductivos_U(idConceptoNoProductivo As Integer,
                                          codigoConceptoNoProductivo As String,
                                          nombreConceptoNoProductivo As String,
                                          activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.MRPConceptoNoProductivo.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}' ", Entidades.MRPConceptoNoProductivo.Columnas.CodigoConceptoNoProductivo.ToString(), codigoConceptoNoProductivo.ToUpper())
         .AppendFormatLine("      ,{0} = '{1}' ", Entidades.MRPConceptoNoProductivo.Columnas.NombreConceptoNoProductivo.ToString(), nombreConceptoNoProductivo)
         .AppendFormatLine("      ,{0} =  {1}  ", Entidades.MRPConceptoNoProductivo.Columnas.Activo.ToString(), GetStringFromBoolean(activo))
         .AppendFormatLine(" WHERE {0} =  {1}  ", Entidades.MRPConceptoNoProductivo.Columnas.IdConceptoNoProductivo.ToString(), idConceptoNoProductivo)
      End With
      Execute(myQuery)
   End Sub

   Public Sub MRPConceptosNoProductivos_D(idConceptoNoProductivo As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} WHERE {1} = {2}", Entidades.MRPConceptoNoProductivo.NombreTabla, Entidades.MRPConceptoNoProductivo.Columnas.IdConceptoNoProductivo.ToString(), idConceptoNoProductivo)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CNP.*")
         .AppendFormatLine("  FROM {0} AS CNP", Entidades.MRPConceptoNoProductivo.NombreTabla)
      End With
   End Sub

   Private Function MRPConceptosNoProductivos_G(idConceptoNoProductivo As Integer, codigoConceptoNoProductivo As String, nombreConceptoNoProductivo As String, valorExacto As Boolean, activas As Entidades.Publicos.SiNoTodos) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idConceptoNoProductivo > 0 Then
            .AppendFormatLine("   AND CNP.IdConceptoNoProductivo = {0}", idConceptoNoProductivo)
         End If
         If Not String.IsNullOrWhiteSpace(codigoConceptoNoProductivo) Then
            If valorExacto Then
               .AppendFormatLine("   AND CNP.CodigoConceptoNoProductivo = '{0}'", codigoConceptoNoProductivo)
            Else
               .AppendFormatLine("   AND CNP.CodigoConceptoNoProductivo LIKE '%{0}%'", codigoConceptoNoProductivo)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(nombreConceptoNoProductivo) Then
            If valorExacto Then
               .AppendFormatLine("   AND CNP.NombreConceptoNoProductivo = '{0}'", nombreConceptoNoProductivo)
            Else
               .AppendFormatLine("   AND CNP.NombreConceptoNoProductivo LIKE '%{0}%'", nombreConceptoNoProductivo)
            End If
         End If
         If activas <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine(" AND CNP.Activo = {0}", GetStringFromBoolean(activas = Entidades.Publicos.SiNoTodos.SI))
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function MRPConceptosNoProductivos_G1(IdConceptoNoProductivo As Integer) As DataTable
      Return MRPConceptosNoProductivos_G(idConceptoNoProductivo:=IdConceptoNoProductivo, codigoConceptoNoProductivo:=String.Empty, nombreConceptoNoProductivo:=String.Empty, valorExacto:=False, activas:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Function MRPConceptosNoProductivos_G1_Codigo(CodigoConceptoNoProductivo As String, codigoExacto As Boolean) As DataTable
      Return MRPConceptosNoProductivos_G(idConceptoNoProductivo:=0, codigoConceptoNoProductivo:=CodigoConceptoNoProductivo, nombreConceptoNoProductivo:=String.Empty, valorExacto:=codigoExacto, activas:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function

   Public Function MRPConceptosNoProductivos_GA_Nombre(nombreTarea As String, nombreExacto As Boolean, activas As Entidades.Publicos.SiNoTodos) As DataTable

      Return MRPConceptosNoProductivos_G(idConceptoNoProductivo:=0, codigoConceptoNoProductivo:=String.Empty, nombreConceptoNoProductivo:=nombreTarea, valorExacto:=nombreExacto, activas)
   End Function

   Public Function MRPConceptosNoProductivos_GA() As DataTable
      Return MRPConceptosNoProductivos_G(idConceptoNoProductivo:=0, codigoConceptoNoProductivo:=String.Empty, nombreConceptoNoProductivo:=String.Empty, valorExacto:=False, activas:=Entidades.Publicos.SiNoTodos.TODOS)
   End Function


   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "CNP.")
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.MRPConceptoNoProductivo.Columnas.IdConceptoNoProductivo.ToString(), Entidades.MRPConceptoNoProductivo.NombreTabla).ToInteger()
   End Function

End Class