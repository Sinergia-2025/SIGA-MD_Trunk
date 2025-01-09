Public Class EstadosTurnos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EstadosTurnos_I(idEstadoTurno As String,
                                nombreEstadoTurno As String,
                                color As Integer?,
                                finalizado As Boolean)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO EstadosTurnos")
         .AppendFormatLine("           (IdEstadoTurno")
         .AppendFormatLine("           ,NombreEstadoTurno")
         .AppendFormatLine("           ,Color")
         .AppendFormatLine("           ,Finalizado")
         .AppendFormatLine("   ) VALUES (")
         .AppendFormatLine("            '{0}' ", idEstadoTurno)
         .AppendFormatLine("          ,'{0}'", nombreEstadoTurno)
         .AppendFormatLine("          , {0} ", GetStringFromNumber(color))
         .AppendFormatLine("          ,'{0}'", GetStringFromBoolean(finalizado))

         .AppendFormatLine(")")
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub EstadosTurnos_U(idEstadoTurno As String,
                                nombreEstadoTurno As String,
                                color As Integer?,
                                finalizado As Boolean)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE EstadosTurnos")
         .AppendFormatLine("   SET NombreEstadoTurno = '{0}'", nombreEstadoTurno)
         .AppendFormatLine("     , Color = {0}", GetStringFromNumber(color))
         .AppendFormatLine("     , Finalizado = '{0}'", GetStringFromBoolean(finalizado))
         .AppendFormatLine(" WHERE IdEstadoTurno = '{0}'", idEstadoTurno)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub EstadosTurnos_D(idEstadoTurno As String)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM EstadosTurnos")
         .AppendFormatLine(" WHERE IdEstadoTurno = '{0}'", idEstadoTurno)
      End With
      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT EC.*")
         .AppendFormatLine("  FROM EstadosTurnos EC ")
      End With
   End Sub

   Public Function EstadosTurnos_GA() As DataTable
      Return EstadosTurnos_G(idEstadoTurno:=String.Empty, nombreEstadoTurno:=String.Empty, nombreExacto:=False)
   End Function

   Private Function EstadosTurnos_G(idEstadoTurno As String, nombreEstadoTurno As String, nombreExacto As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idEstadoTurno) Then
            .AppendFormatLine("   AND EC.IdEstadoTurno = '{0}'", idEstadoTurno)
         End If
         If Not String.IsNullOrWhiteSpace(nombreEstadoTurno) Then
            If nombreExacto Then
               .AppendFormatLine("   AND EC.NombreEstadoTurno = '{0}'", nombreEstadoTurno)
            Else
               .AppendFormatLine("   AND EC.NombreEstadoTurno LIKE '%{0}%'", nombreEstadoTurno)
            End If
         End If
         .AppendFormatLine(" ORDER BY EC.NombreEstadoTurno")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetXNombre(estadoTurno As String) As DataTable
      Return EstadosTurnos_G(idEstadoTurno:=String.Empty, nombreEstadoTurno:=estadoTurno, nombreExacto:=True)
   End Function

   Public Function EstadosTurnos_G1(idEstadoTurno As String) As DataTable
      Return EstadosTurnos_G(idEstadoTurno, nombreEstadoTurno:=String.Empty, nombreExacto:=True)
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "EC." + columna
      'If columna = "D.NombreLocalidad" Then columna = columna.Replace("D.", "L.")
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine("  WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function TiposTurnos_GCombo() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE EC.IdEstadoTurno <> 'T'")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   'Public Function EstadosTurnos_GetMaximo() As Integer
   '   Return Convert.ToInt32(GetCodigoMaximo("IdEstadoTurno", "EstadosTurnos"))
   'End Function

End Class