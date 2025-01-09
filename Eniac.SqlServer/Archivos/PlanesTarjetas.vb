Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class PlanesTarjetas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub PlanesTarjetas_I(IdPlanTarjeta As Integer,
                               NombrePlanTarjeta As String,
                               CuotasDesde As Integer,
                               CuotasHasta As Integer,
                               PorcDescRec As Decimal,
                               IdTarjeta As Integer,
                               IdBanco As Integer,
                               Activo As Boolean,
                               PorcDescRecDom As Boolean,
                               PorcDescRecLun As Boolean,
                               PorcDescRecMar As Boolean,
                               PorcDescRecMie As Boolean,
                               PorcDescRecJue As Boolean,
                               PorcDescRecVie As Boolean,
                               PorcDescRecSab As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO PlanesTarjetas ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14})",
                       PlanTarjeta.Columnas.IdPlanTarjeta.ToString(),
                       PlanTarjeta.Columnas.NombrePlanTarjeta.ToString(),
                       PlanTarjeta.Columnas.CuotasDesde.ToString(),
                       PlanTarjeta.Columnas.CuotasHasta.ToString(),
                       PlanTarjeta.Columnas.PorcDescRec.ToString(),
                       PlanTarjeta.Columnas.IdTarjeta.ToString(),
                       PlanTarjeta.Columnas.IdBanco.ToString(),
                       PlanTarjeta.Columnas.Activo.ToString(),
                       PlanTarjeta.Columnas.PorcDescRecDom.ToString(),
                       PlanTarjeta.Columnas.PorcDescRecLun.ToString(),
                       PlanTarjeta.Columnas.PorcDescRecMar.ToString(),
                       PlanTarjeta.Columnas.PorcDescRecMie.ToString(),
                       PlanTarjeta.Columnas.PorcDescRecJue.ToString(),
                       PlanTarjeta.Columnas.PorcDescRecVie.ToString(),
                       PlanTarjeta.Columnas.PorcDescRecSab.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14})",
                       IdPlanTarjeta, NombrePlanTarjeta, CuotasDesde, CuotasHasta,
                       PorcDescRec,
                       IIf(IdTarjeta > 0, IdTarjeta.ToString(), "NULL"),
                       IIf(IdBanco > 0, IdBanco.ToString(), "NULL"),
                       GetStringFromBoolean(Activo),
                       GetStringFromBoolean(PorcDescRecDom),
                       GetStringFromBoolean(PorcDescRecLun),
                       GetStringFromBoolean(PorcDescRecMar),
                       GetStringFromBoolean(PorcDescRecMie),
                       GetStringFromBoolean(PorcDescRecJue),
                       GetStringFromBoolean(PorcDescRecVie),
                       GetStringFromBoolean(PorcDescRecSab))
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub PlanesTarjetas_U(IdPlanTarjeta As Integer,
                               NombrePlanTarjeta As String,
                               CuotasDesde As Integer,
                               CuotasHasta As Integer,
                               PorcDescRec As Decimal,
                               IdTarjeta As Integer,
                               IdBanco As Integer,
                               Activo As Boolean,
                               PorcDescRecDom As Boolean,
                               PorcDescRecLun As Boolean,
                               PorcDescRecMar As Boolean,
                               PorcDescRecMie As Boolean,
                               PorcDescRecJue As Boolean,
                               PorcDescRecVie As Boolean,
                               PorcDescRecSab As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .Length = 0
         .AppendLine("UPDATE PlanesTarjetas ")
         .AppendFormat("   SET {0} = '{1}'", PlanTarjeta.Columnas.NombrePlanTarjeta.ToString(), NombrePlanTarjeta).AppendLine()
         .AppendFormat("      ,{0} = {1}", PlanTarjeta.Columnas.CuotasDesde.ToString(), CuotasDesde).AppendLine()
         .AppendFormat("      ,{0} = {1}", PlanTarjeta.Columnas.CuotasHasta.ToString(), CuotasHasta).AppendLine()
         .AppendFormat("      ,{0} = {1}", PlanTarjeta.Columnas.PorcDescRec.ToString(), PorcDescRec).AppendLine()
         .AppendFormat("      ,{0} = {1}", PlanTarjeta.Columnas.IdTarjeta.ToString(), IIf(IdTarjeta > 0, IdTarjeta.ToString(), "NULL")).AppendLine()
         .AppendFormat("      ,{0} = {1}", PlanTarjeta.Columnas.IdBanco.ToString(), IIf(IdBanco > 0, IdBanco.ToString(), "NULL")).AppendLine()
         .AppendFormat("      ,{0} = {1}", PlanTarjeta.Columnas.Activo.ToString(), GetStringFromBoolean(Activo)).AppendLine()
         '-- REQ-34584.- ------------------------------------------------------------------------------------------------------
         .AppendFormat("      ,{0} = {1}", PlanTarjeta.Columnas.PorcDescRecDom.ToString(), GetStringFromBoolean(PorcDescRecDom)).AppendLine()
         .AppendFormat("      ,{0} = {1}", PlanTarjeta.Columnas.PorcDescRecLun.ToString(), GetStringFromBoolean(PorcDescRecLun)).AppendLine()
         .AppendFormat("      ,{0} = {1}", PlanTarjeta.Columnas.PorcDescRecMar.ToString(), GetStringFromBoolean(PorcDescRecMar)).AppendLine()
         .AppendFormat("      ,{0} = {1}", PlanTarjeta.Columnas.PorcDescRecMie.ToString(), GetStringFromBoolean(PorcDescRecMie)).AppendLine()
         .AppendFormat("      ,{0} = {1}", PlanTarjeta.Columnas.PorcDescRecJue.ToString(), GetStringFromBoolean(PorcDescRecJue)).AppendLine()
         .AppendFormat("      ,{0} = {1}", PlanTarjeta.Columnas.PorcDescRecVie.ToString(), GetStringFromBoolean(PorcDescRecVie)).AppendLine()
         .AppendFormat("      ,{0} = {1}", PlanTarjeta.Columnas.PorcDescRecSab.ToString(), GetStringFromBoolean(PorcDescRecSab)).AppendLine()
         '---------------------------------------------------------------------------------------------------------------------
         .AppendFormat(" WHERE {0} = {1}", PlanTarjeta.Columnas.IdPlanTarjeta.ToString(), IdPlanTarjeta)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub PlanesTarjetas_D(IdPlanTarjeta As Integer)
      Me.Execute(String.Format("DELETE FROM PlanesTarjetas WHERE {0} = {1}", PlanTarjeta.Columnas.IdPlanTarjeta.ToString(), IdPlanTarjeta))
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT PT.*")
         .AppendLine("     , T.NombreTarjeta")
         .AppendLine("     , B.NombreBanco")
         .AppendLine("  FROM PlanesTarjetas AS PT")
         .AppendLine("  LEFT JOIN Tarjetas AS T ON T.IdTarjeta = PT.IdTarjeta")
         .AppendLine("  LEFT JOIN Bancos AS B ON B.IdBanco = PT.IdBanco")
      End With
   End Sub

   Public Function PlanesTarjetas_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" ORDER BY PT.NombrePlanTarjeta")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function PlanesTarjetas_G1(IdPlanTarjeta As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE PT.{0} = {1}", PlanTarjeta.Columnas.IdPlanTarjeta.ToString(), IdPlanTarjeta)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function PlanesTarjetas_GActivos() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE PT.Activo = 1")
         .AppendFormat(" ORDER BY PT.NombrePlanTarjeta")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      If columna = Entidades.Tarjeta.Columnas.NombreTarjeta.ToString() Then
         columna = "T." + columna
      ElseIf columna = "NombreBanco" Then
         columna = "B." + columna
      Else
         columna = "PT." + columna
      End If
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(PlanTarjeta.Columnas.IdPlanTarjeta.ToString(), "PlanesTarjetas"))
   End Function
End Class
