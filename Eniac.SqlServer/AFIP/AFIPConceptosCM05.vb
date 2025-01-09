Public Class AFIPConceptosCM05
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub AFIPConceptosCM05_I(idConceptoCM05 As Integer, descripcionConceptoCM05 As String, tipoConceptoCM05 As Entidades.AFIPConceptoCM05.TiposConceptosCM05)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.AFIPConceptoCM05.NombreTabla)
         .AppendFormatLine("        {0} ", Entidades.AFIPConceptoCM05.Columnas.IdConceptoCM05.ToString())
         .AppendFormatLine("     ,  {0} ", Entidades.AFIPConceptoCM05.Columnas.DescripcionConceptoCM05.ToString())
         .AppendFormatLine("     ,  {0} ", Entidades.AFIPConceptoCM05.Columnas.TipoConceptoCM05.ToString())
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("        {0} ", idConceptoCM05)
         .AppendFormatLine("     , '{0}'", descripcionConceptoCM05)
         .AppendFormatLine("     , '{0}'", tipoConceptoCM05.ToString())
         .AppendFormatLine(" )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub AFIPConceptosCM05_U(idConceptoCM05 As Integer, descripcionConceptoCM05 As String, tipoConceptoCM05 As Entidades.AFIPConceptoCM05.TiposConceptosCM05)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.AFIPConceptoCM05.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.AFIPConceptoCM05.Columnas.DescripcionConceptoCM05.ToString(), descripcionConceptoCM05)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.AFIPConceptoCM05.Columnas.TipoConceptoCM05.ToString(), tipoConceptoCM05)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.AFIPConceptoCM05.Columnas.IdConceptoCM05.ToString(), idConceptoCM05)
      End With
      Execute(myQuery)
   End Sub

   Public Sub AFIPConceptosCM05_D(idConceptoCM05 As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.AFIPConceptoCM05.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.AFIPConceptoCM05.Columnas.IdConceptoCM05.ToString(), idConceptoCM05)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CM05.*")
         .AppendFormatLine("  FROM {0} AS CM05", Entidades.AFIPConceptoCM05.NombreTabla)
      End With
   End Sub

   Public Function AFIPConceptosCM05_G(idConceptoCM05 As Integer, idConceptoCM05CeroTodos As Boolean, tipoConceptoCM05 As Entidades.AFIPConceptoCM05.TiposConceptosCM05?) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idConceptoCM05 <> 0 OrElse Not idConceptoCM05CeroTodos Then
            .AppendFormatLine("   AND CM05.{0} = {1} ", Entidades.AFIPConceptoCM05.Columnas.IdConceptoCM05.ToString(), idConceptoCM05)
         End If
         If tipoConceptoCM05.HasValue Then
            .AppendFormatLine("   AND CM05.{0} = '{1}'", Entidades.AFIPConceptoCM05.Columnas.TipoConceptoCM05.ToString(), tipoConceptoCM05.Value.ToString())
         End If
         .AppendFormatLine(" ORDER BY CM05.{0}", Entidades.AFIPConceptoCM05.Columnas.DescripcionConceptoCM05.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function AFIPConceptosCM05_GA() As DataTable
      Return AFIPConceptosCM05_G(idConceptoCM05:=0, idConceptoCM05CeroTodos:=True, tipoConceptoCM05:=Nothing)
   End Function

   Public Function AFIPConceptosCM05_G1(idConceptoCM05 As Integer) As DataTable
      Return AFIPConceptosCM05_G(idConceptoCM05, idConceptoCM05CeroTodos:=False, tipoConceptoCM05:=Nothing)
   End Function
   Public Function AFIPConceptosCM05_GA_TipoConceptoCM05(tipoConceptoCM05 As Entidades.AFIPConceptoCM05.TiposConceptosCM05?) As DataTable
      Return AFIPConceptosCM05_G(idConceptoCM05:=0, idConceptoCM05CeroTodos:=True, tipoConceptoCM05)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "CM05.")
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.AFIPConceptoCM05.Columnas.IdConceptoCM05.ToString(), Entidades.AFIPConceptoCM05.NombreTabla).ToInteger()
   End Function

End Class