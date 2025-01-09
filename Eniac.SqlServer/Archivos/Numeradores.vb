Public Class Numeradores
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Numeradores_I(idNumerador As String,
                            numero As Long,
                            descripcion As String)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.Numerador.NombreTabla)
         .AppendFormatLine("            ({0}, {1}, {2})",
                           Entidades.Numerador.Columnas.IdNumerador.ToString(),
                           Entidades.Numerador.Columnas.Numero.ToString(),
                           Entidades.Numerador.Columnas.Descripcion.ToString()).AppendLine()
         .AppendFormatLine("     VALUES ('{0}', {1}, '{2}')",
                           idNumerador, numero, descripcion)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Numeradores_U(idNumerador As String,
                            numero As Long,
                            descripcion As String)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.Numerador.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.Numerador.Columnas.Numero.ToString(), numero)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Numerador.Columnas.Descripcion.ToString(), descripcion)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.Numerador.Columnas.IdNumerador.ToString(), idNumerador)

      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Numeradores_M(idNumerador As String, numero As Long, descripcion As String)
      Numeradores_M(idNumerador, numero, descripcion, False)
   End Sub
   Public Sub Numeradores_M_Numero(idNumerador As String, numero As Long)
      Numeradores_M(idNumerador, numero, String.Empty, True)
   End Sub
   Private Sub Numeradores_M(idNumerador As String,
                            numero As Long,
                            descripcion As String,
                            maximo As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO {0} AS D", Entidades.Numerador.NombreTabla)
         .AppendFormatLine("        USING (SELECT '{1}' AS {0}", Entidades.Numerador.Columnas.IdNumerador.ToString(), idNumerador)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.Numerador.Columnas.Numero.ToString(), numero)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.Numerador.Columnas.Descripcion.ToString(), descripcion)
         .AppendFormatLine("              ) AS O ON O.{0} = D.{0}", Entidades.Numerador.Columnas.IdNumerador.ToString())
         .AppendFormatLine("    WHEN MATCHED THEN")
         Dim formatUpdate As String
         If Not maximo Then
            'Si no es máximo es un merge normal
            formatUpdate = "        UPDATE SET D.{0} = O.{0}, D.{1} = O.{1}"
         Else
            'Si hace el merge por máximo solo actualizo el número aplicando el mayor valor entre el pasado y el actual
            formatUpdate = "        UPDATE SET D.{0} = CASE WHEN D.{0} < O.{0} THEN O.{0} ELSE D.{0} END"
         End If
         .AppendFormatLine(formatUpdate,
                           Entidades.Numerador.Columnas.Numero.ToString(),
                           Entidades.Numerador.Columnas.Descripcion.ToString())
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT ({0}, {1}, {2}) VALUES (O.{0}, O.{1}, O.{2})",
                           Entidades.Numerador.Columnas.IdNumerador.ToString(),
                           Entidades.Numerador.Columnas.Numero.ToString(),
                           Entidades.Numerador.Columnas.Descripcion.ToString())
         .AppendFormatLine(";")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Numeradores_D(idNumerador As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.Numerador.NombreTabla)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.Numerador.Columnas.IdNumerador.ToString(), idNumerador)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT NR.*")
         .AppendFormatLine("  FROM {0} AS NR", Entidades.Numerador.NombreTabla)
      End With
   End Sub

   Public Function Numeradores_G(idNumerador As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If Not String.IsNullOrEmpty(idNumerador) Then
            .AppendFormatLine("   AND NR.{0} = '{1}'", Entidades.Numerador.Columnas.IdNumerador.ToString(), idNumerador)
         End If
         .AppendFormat(" ORDER BY NR.{0}", Entidades.Numerador.Columnas.IdNumerador.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Numeradores_GA() As DataTable
      Return Numeradores_G(idNumerador:=String.Empty)
   End Function

   Public Function Numeradores_G1(idNumerador As String) As DataTable
      Return Numeradores_G(idNumerador)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "NR." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class