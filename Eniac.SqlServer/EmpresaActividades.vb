Imports System.Text

Public Class EmpresaActividades
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EmpresaActividades_I(ByVal IdProvincia As String, _
                                         ByVal IdActividad As Integer, _
                                         ByVal principal As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO EmpresaActividades")
         .AppendLine("   (IdProvincia")
         .AppendLine("   ,IdActividad")
         .AppendLine("   ,Principal")
         .AppendLine(" ) VALUES (")
         .AppendLine("  '" & IdProvincia & "'")
         .AppendLine("  ," & IdActividad.ToString())
         .AppendLine("  ,'" & Me.GetStringFromBoolean(principal) & "'")
         .AppendLine(")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "EmpresaActividades")

   End Sub

   Public Sub EmpresaActividades_D()

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("DELETE FROM EmpresaActividades ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "EmpresaActividades")

   End Sub

   Public Function GetEmpresaActividades(idProvincia As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Length = 0
         .AppendLine("SELECT EA.IdProvincia")
         .AppendLine("      ,P.NombreProvincia")
         .AppendLine("      ,EA.IdActividad")
         .AppendLine("      ,A.NombreActividad")
         .AppendLine("      ,A.Porcentaje")
         .AppendLine("      ,EA.Principal")
         .AppendLine(" FROM EmpresaActividades EA ")
         .AppendLine(" INNER JOIN Actividades A ON A.IdActividad = EA.IdActividad ")
         .AppendLine("  AND A.IdProvincia = EA.IdProvincia")
         .AppendLine(" INNER JOIN Provincias P ON P.IdProvincia = EA.IdProvincia  ")
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idProvincia) Then
            .AppendFormat("   AND EA.IdProvincia = '{0}'", idProvincia).AppendLine()
         End If
         .AppendLine(" ORDER BY A.NombreActividad")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   
End Class
