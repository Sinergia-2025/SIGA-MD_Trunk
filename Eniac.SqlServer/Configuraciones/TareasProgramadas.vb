Public Class TareasProgramadas
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TareasProgramadas_I(idTareaProgramada As Integer,
                                  idFuncion As String,
                                  usuario As String,
                                  observacion As String,
                                  ultimaFechaEjecucion As Date?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.TareaProgramada.NombreTabla)
         .AppendFormatLine("    ({0}", Entidades.TareaProgramada.Columnas.IdTareaProgramada.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TareaProgramada.Columnas.IdFuncion.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TareaProgramada.Columnas.Usuario.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TareaProgramada.Columnas.Observacion.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TareaProgramada.Columnas.UltimaFechaEjecucion.ToString())
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("     {0} ", idTareaProgramada)
         .AppendFormatLine("   ,'{0}'", idFuncion)
         .AppendFormatLine("   ,'{0}'", usuario)
         .AppendFormatLine("   ,'{0}'", observacion)
         If ultimaFechaEjecucion.HasValue Then
            .AppendFormatLine("   ,'{0}'", Me.ObtenerFecha(ultimaFechaEjecucion.Value, True))
         Else
            .AppendFormatLine("   ,NULL")
         End If
         .AppendLine(" )")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TareasProgramadas_U(idTareaProgramada As Integer,
                                  idFuncion As String,
                                  usuario As String,
                                  observacion As String,
                                  ultimaFechaEjecucion As Date?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.TareaProgramada.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.TareaProgramada.Columnas.IdFuncion.ToString(), idFuncion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.TareaProgramada.Columnas.Usuario.ToString(), usuario)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.TareaProgramada.Columnas.Observacion.ToString(), observacion)
         If ultimaFechaEjecucion.HasValue Then
            .AppendFormatLine("     , {0} = '{1}'", Entidades.TareaProgramada.Columnas.UltimaFechaEjecucion.ToString(), ObtenerFecha(ultimaFechaEjecucion.Value, True))
         Else
            .AppendFormatLine("     , {0} = NULL", Entidades.TareaProgramada.Columnas.UltimaFechaEjecucion.ToString())
         End If
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.TareaProgramada.Columnas.IdTareaProgramada.ToString(), idTareaProgramada)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TareasProgramadas_D(idTareaProgramada As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0}", Entidades.TareaProgramada.NombreTabla)
         .AppendFormat(" WHERE {0} = {1}", Entidades.TareaProgramada.Columnas.IdTareaProgramada.ToString(), idTareaProgramada)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT T.*")
         .AppendLine("     , F.Nombre NombreFuncion")
         .AppendLine("  FROM TareasProgramadas T")
         .AppendLine(" INNER JOIN Funciones F ON F.Id = T.IdFuncion")
      End With
   End Sub

   Private Function TareasProgramadas_G(idTareaProgramada As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE 1 = 1")
         If idTareaProgramada > 0 Then
            .AppendFormatLine("   AND T.{0} = {1}", Entidades.TareaProgramada.Columnas.IdTareaProgramada.ToString(), idTareaProgramada)
         End If
         .AppendFormatLine("  ORDER BY T.{0}", Entidades.TareaProgramada.Columnas.IdFuncion.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function TareasProgramadas_GA() As DataTable
      Return TareasProgramadas_G(idTareaProgramada:=0)
   End Function

   Public Function TareasProgramadas_G1(idTareaProgramada As Integer) As DataTable
      Return TareasProgramadas_G(idTareaProgramada)
   End Function

   Public Function Buscar(columna As String, valor As String) As DataTable
      If columna = "NombreFuncion" Then
         columna = "F.Nombre"
      Else
         columna = "T." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.TareaProgramada.Columnas.IdTareaProgramada.ToString(), Entidades.TareaProgramada.NombreTabla))
   End Function
End Class