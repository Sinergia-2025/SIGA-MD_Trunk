Public Class TareasProgramadasHorarios
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TareasProgramadasHorarios_I(idTareaProgramada As Integer,
                                          diaSemana As Integer,
                                          horaProgramada As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.TareaProgramadaHorario.NombreTabla)
         .AppendFormatLine("    ({0}", Entidades.TareaProgramadaHorario.Columnas.IdTareaProgramada.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TareaProgramadaHorario.Columnas.DiaSemana.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TareaProgramadaHorario.Columnas.HoraProgramada.ToString())
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("     {0} ", idTareaProgramada)
         .AppendFormatLine("   , {0} ", diaSemana)
         .AppendFormatLine("   ,'{0}'", horaProgramada)
         .AppendLine(" )")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TareasProgramadasHorarios_U(idTareaProgramada As Integer,
                                          diaSemana As Integer,
                                          horaProgramada As String)
      Throw New NotImplementedException("TareasProgramadasHorarios_U no se encuentra implementado")
      'Dim myQuery As StringBuilder = New StringBuilder()
      'With myQuery
      '   .AppendFormatLine("UPDATE {0}", Entidades.TareaProgramadaHorario.NombreTabla)
      '   .AppendFormatLine("   SET {0} = '{1}'", Entidades.TareaProgramadaHorario.Columnas.IdFuncion.ToString(), idFuncion)
      '   .AppendFormatLine("     , {0} = '{1}'", Entidades.TareaProgramadaHorario.Columnas.Usuario.ToString(), usuario)
      '   .AppendFormatLine("     , {0} = '{1}'", Entidades.TareaProgramadaHorario.Columnas.Observacion.ToString(), observacion)
      '   If ultimaFechaEjecucion.HasValue Then
      '      .AppendFormatLine("     , {0} = '{1}'", Entidades.TareaProgramadaHorario.Columnas.UltimaFechaEjecucion.ToString(), ObtenerFecha(ultimaFechaEjecucion.Value, True))
      '   Else
      '      .AppendFormatLine("     , {0} = NULL", Entidades.TareaProgramadaHorario.Columnas.UltimaFechaEjecucion.ToString())
      '   End If
      '   .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.TareaProgramadaHorario.Columnas.IdTareaProgramada.ToString(), idTareaProgramada)
      'End With

      'Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TareasProgramadasHorarios_D(idTareaProgramada As Integer,
                                          diaSemana As Integer,
                                          horaProgramada As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0}", Entidades.TareaProgramadaHorario.NombreTabla)
         .AppendFormat(" WHERE {0} = {1}", Entidades.TareaProgramadaHorario.Columnas.IdTareaProgramada.ToString(), idTareaProgramada)
         If diaSemana > -1 Then
            .AppendFormat("   AND {0} = {1}", Entidades.TareaProgramadaHorario.Columnas.DiaSemana.ToString(), diaSemana)
         End If
         If Not String.IsNullOrWhiteSpace(horaProgramada) Then
            .AppendFormat("   AND {0} = '{1}'", Entidades.TareaProgramadaHorario.Columnas.HoraProgramada.ToString(), horaProgramada)
         End If

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT TH.*")
         .AppendLine("  FROM TareasProgramadasHorarios TH")
      End With
   End Sub

   Private Function TareasProgramadasHorarios_G(idTareaProgramada As Integer,
                                                diaSemana As Integer,
                                                horaProgramada As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE 1 = 1")
         If idTareaProgramada > 0 Then
            .AppendFormatLine("   AND TH.{0} = {1}", Entidades.TareaProgramadaHorario.Columnas.IdTareaProgramada.ToString(), idTareaProgramada)
         End If
         If diaSemana > -1 Then
            .AppendFormat("   AND TH.{0} = {1}", Entidades.TareaProgramadaHorario.Columnas.DiaSemana.ToString(), diaSemana)
         End If
         If Not String.IsNullOrWhiteSpace(horaProgramada) Then
            .AppendFormat("   AND TH.{0} = '{1}'", Entidades.TareaProgramadaHorario.Columnas.HoraProgramada.ToString(), horaProgramada)
         End If

         .AppendFormatLine("  ORDER BY TH.{0}, TH.{1}",
                           Entidades.TareaProgramadaHorario.Columnas.DiaSemana.ToString(),
                           Entidades.TareaProgramadaHorario.Columnas.HoraProgramada.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function TareasProgramadasHorarios_GA() As DataTable
      Return TareasProgramadasHorarios_G(idTareaProgramada:=0, diaSemana:=-1, horaProgramada:=String.Empty)
   End Function

   Public Function TareasProgramadasHorarios_GA(idTareaProgramada As Integer) As DataTable
      Return TareasProgramadasHorarios_G(idTareaProgramada, diaSemana:=-1, horaProgramada:=String.Empty)
   End Function
   Public Function TareasProgramadasHorarios_G1(idTareaProgramada As Integer,
                                                diaSemana As Integer,
                                                horaProgramada As String) As DataTable
      Return TareasProgramadasHorarios_G(idTareaProgramada, diaSemana, horaProgramada)
   End Function

   Public Function Buscar(columna As String, valor As String) As DataTable
      columna = "TH." + columna
      'If columna = "D.NombreLocalidad" Then columna = columna.Replace("D.", "L.")
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
End Class