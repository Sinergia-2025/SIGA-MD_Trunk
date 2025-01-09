Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class CRMProspectosInterlocutores
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
   Public Sub CRMProspectosInterlocutores_I(ByVal en As Entidades.CRMProspectoInterlocutor)
      CRMProspectosInterlocutores_I(en.IdProspecto, en.Interlocutor)
   End Sub
   Public Sub CRMProspectosInterlocutores_I(IdProspecto As Long, Interlocutor As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("MERGE INTO CRMProspectosInterlocutores AS P")
         .AppendLine("     USING (SELECT {2} AS {0}, '{3}' AS {1}) AS PT")
         .AppendLine("        ON P.{0} = PT.{0} AND P.{1} = PT.{1}")
         .AppendLine(" WHEN NOT MATCHED THEN")
         .AppendLine("    INSERT (   {0},    {1})")
         .AppendLine("    VALUES (PT.{0}, PT.{1});")

      End With
      Me.Execute(String.Format(myQuery.ToString(),
                               CRMProspectoInterlocutor.Columnas.IdProspecto.ToString(),
                               CRMProspectoInterlocutor.Columnas.Interlocutor.ToString(),
                               IdProspecto,
                               Interlocutor))
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT CI.* FROM CRMProspectosInterlocutores AS CI").AppendLine()
      End With
   End Sub

   Public Function CRMProspectosInterlocutores_GA(Optional IdCliente As Long = 0) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         'Si viene en 0 el IdProspecto, no debe traer ningún interlocutor.
         'If IdProspecto <> 0 Then
         .AppendFormat(" AND CI.{0} = {1}", Entidades.CRMProspectoInterlocutor.Columnas.IdProspecto.ToString(), IdCliente)
         'End If
         .AppendFormat(" ORDER BY CI.Interlocutor")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class
