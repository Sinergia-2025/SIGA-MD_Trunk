Public Class FuncionesVinculadas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub FuncionesVinculadas_I(idFuncion As String, idFuncionVinculada As String)
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.FuncionVinculada.NombreTabla)
         .AppendFormatLine("      {0} ", Entidades.FuncionVinculada.Columnas.IdFuncion.ToString())
         .AppendFormatLine("   ,  {0} ", Entidades.FuncionVinculada.Columnas.IdFuncionVinculada.ToString())
         .AppendFormatLine("  ) VALUES ( ")
         .AppendFormatLine("     '{0}'", idFuncion)
         .AppendFormatLine("   , '{0}'", idFuncionVinculada)
         .AppendFormatLine("  )")
      End With
      Execute(myQuery)
   End Sub
   Public Sub FuncionesVinculadas_U(idFuncion As String, idFuncionVinculada As String)
      Throw New NotImplementedException("La función SqlServer.FuncionesVinculadas.FuncionesVinculadas_U no está implementada por falta de campos a actualizar.")
      'Dim myQuery = New StringBuilder()

      'With myQuery
      '   .AppendFormatLine("UPDATE {0}", Entidades.FuncionVinculada.NombreTabla)
      '   '.AppendFormatLine("   SET {0} = '{1}'", Entidades.FuncionVinculada.Columnas.Nombre.ToString(), nombre)
      '   '.AppendFormatLine("     , {0} = '{1}'", Entidades.FuncionVinculada.Columnas.Descripcion.ToString(), descripcion)
      '   .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.FuncionVinculada.Columnas.IdFuncion.ToString(), idFuncion)
      '   .AppendFormatLine("   AND {0} = '{1}'", Entidades.FuncionVinculada.Columnas.IdFuncionVinculada.ToString(), idFuncionVinculada)
      'End With
      'Execute(myQuery)
   End Sub
   Public Sub FuncionesVinculadas_D(idFuncion As String, idFuncionVinculada As String)
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.FuncionVinculada.NombreTabla)
         .AppendFormatLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idFuncion) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.FuncionVinculada.Columnas.IdFuncion.ToString(), idFuncion)
         End If
         If Not String.IsNullOrWhiteSpace(idFuncionVinculada) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.FuncionVinculada.Columnas.IdFuncionVinculada.ToString(), idFuncionVinculada)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT FV.*")
         .AppendFormatLine("     , F1.Nombre AS NombreFuncion")
         .AppendFormatLine("     , F2.Nombre AS NombreFuncionVinculada")
         .AppendFormatLine("  FROM {0} FV", Entidades.FuncionVinculada.NombreTabla)
         .AppendFormatLine("  LEFT JOIN Funciones F1 ON F1.Id = FV.{0}", Entidades.FuncionVinculada.Columnas.IdFuncion.ToString())
         .AppendFormatLine("  LEFT JOIN Funciones F2 ON F2.Id = FV.{0}", Entidades.FuncionVinculada.Columnas.IdFuncionVinculada.ToString())
      End With
   End Sub

   Public Function FuncionesVinculadas_GA() As DataTable
      Return FuncionesVinculadas_GA(idFuncion:=String.Empty, idFuncionVinculada:=String.Empty)
   End Function
   Public Function FuncionesVinculadas_GA(idFuncion As String) As DataTable
      Return FuncionesVinculadas_GA(idFuncion, idFuncionVinculada:=String.Empty)
   End Function
   Public Function FuncionesVinculadas_G1(idFuncion As String, idFuncionVinculada As String) As DataTable
      Return FuncionesVinculadas_GA(idFuncion, idFuncionVinculada)
   End Function
   Public Function FuncionesVinculadas_GA(idFuncion As String, idFuncionVinculada As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idFuncion) Then
            .AppendFormatLine("   AND FV.{0} = '{1}'", Entidades.FuncionVinculada.Columnas.IdFuncion.ToString(), idFuncion)
         End If
         If Not String.IsNullOrWhiteSpace(idFuncionVinculada) Then
            .AppendFormatLine("   AND FV.{0} = '{1}'", Entidades.FuncionVinculada.Columnas.IdFuncionVinculada.ToString(), idFuncionVinculada)
         End If
         .AppendLine(" ORDER BY F1.Nombre, F2.Nombre")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String, igual As Boolean) As DataTable
      Return Buscar(columna, valor, Sub(stb1) SelectTexto(stb1), "FV.",
                    New Dictionary(Of String, String) From {{"NombreFuncion", "F1.Nombre"}, {"NombreFuncionVinculada", "F2.Nombre"}})
   End Function
End Class