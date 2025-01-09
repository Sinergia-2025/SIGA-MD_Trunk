Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class CalendariosHorarios
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CalendariosHorarios_I(idCalendario As Integer,
                                    idDiaSemana As Integer,
                                    idHorario As Integer,
                                    horaDesde As String,
                                    horaHasta As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO CalendariosHorarios ({0}, {1}, {2}, {3}, {4})",
                       Entidades.CalendarioHorario.Columnas.IdCalendario.ToString(),
                       Entidades.CalendarioHorario.Columnas.IdDiaSemana.ToString(),
                       Entidades.CalendarioHorario.Columnas.IdHorario.ToString(),
                       Entidades.CalendarioHorario.Columnas.HoraDesde.ToString(),
                       Entidades.CalendarioHorario.Columnas.HoraHasta.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, {1}, {2}, '{3}', '{4}'",
                       idCalendario, idDiaSemana, idHorario, horaDesde, horaHasta)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CalendariosHorarios_U(idCalendario As Integer,
                                    idDiaSemana As Integer,
                                    idHorario As Integer,
                                    horaDesde As String,
                                    horaHasta As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE CalendariosHorarios ")
         .AppendFormat("   SET {0} = '{1}'", Entidades.CalendarioHorario.Columnas.HoraDesde.ToString(), horaDesde).AppendLine()
         .AppendFormat("     , {0} = '{1}'", Entidades.CalendarioHorario.Columnas.HoraHasta.ToString(), horaHasta).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.CalendarioHorario.Columnas.IdCalendario.ToString(), idCalendario)
         .AppendFormat("   AND {0} =  {1} ", Entidades.CalendarioHorario.Columnas.IdDiaSemana.ToString(), idDiaSemana)
         .AppendFormat("   AND {0} =  {1} ", Entidades.CalendarioHorario.Columnas.IdHorario.ToString(), idHorario)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CalendariosHorarios_D(idCalendario As Integer,
                                    idDiaSemana As Integer,
                                    idHorario As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM CalendariosHorarios").AppendLine()
         .AppendFormat("  WHERE {0} = {1}", Entidades.CalendarioHorario.Columnas.IdCalendario.ToString(), idCalendario).AppendLine()
         If idDiaSemana > -1 Then
            .AppendFormat("    AND {0} = {1}", Entidades.CalendarioHorario.Columnas.IdDiaSemana.ToString(), idDiaSemana).AppendLine()
         End If
         If idHorario > 0 Then
            .AppendFormat("    AND {0} = {1}", Entidades.CalendarioHorario.Columnas.IdHorario.ToString(), idHorario).AppendLine()
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT CH.*, '' AS NombreDiaSemana FROM CalendariosHorarios AS CH").AppendLine()
      End With
   End Sub

   Public Function CalendariosHorarios_GA() As DataTable
      Return CalendariosHorarios_G(idCalendario:=0, idDiaSemana:=-1, idHorario:=0)
   End Function
   Public Function CalendariosHorarios_GA(idCalendario As Integer) As DataTable
      Return CalendariosHorarios_G(idCalendario:=idCalendario, idDiaSemana:=-1, idHorario:=0)
   End Function
   Public Function CalendariosHorarios_GA(idCalendario As Integer, idDiaSemana As Integer) As DataTable
      Return CalendariosHorarios_G(idCalendario:=idCalendario, idDiaSemana:=idDiaSemana, idHorario:=0)
   End Function
   Private Function CalendariosHorarios_G(idCalendario As Integer, idDiaSemana As Integer, idHorario As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCalendario > 0 Then
            .AppendFormat("   AND CH.IdCalendario = {0}", idCalendario).AppendLine()
         End If
         If idDiaSemana > -1 Then
            .AppendFormat("   AND CH.IdDiaSemana = {0}", Convert.ToInt32(idDiaSemana)).AppendLine()
         End If
         If idHorario > 0 Then
            .AppendFormat("   AND CH.IdHorario = {0}", idHorario).AppendLine()
         End If
      End With

      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())

      For Each dr As DataRow In dt.Rows
         Dim diaSemana As Integer = Integer.Parse(dr(Entidades.CalendarioHorario.Columnas.IdDiaSemana.ToString()).ToString())
         dr("NombreDiaSemana") = DirectCast(diaSemana, System.DayOfWeek).NombreDiaSemana()
      Next

      Return dt
   End Function

   Public Function CalendariosHorarios_G1(idCalendario As Integer, idDiaSemana As Integer, idHorario As Integer) As DataTable
      Return CalendariosHorarios_G(idCalendario:=idCalendario, idDiaSemana:=idDiaSemana, idHorario:=idHorario)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      If columna = "NombreDiaSemana" Then
         'columna = "S." + columna
      Else
         columna = "CH." + columna
      End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo(idCalendario As Integer, idDiaSemana As Integer) As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.CalendarioHorario.Columnas.IdHorario.ToString(), "CalendariosHorarios",
                                                    String.Format("IdCalendarioHorario = {0} AND IdHorario = {1}", idCalendario, Convert.ToInt32(idDiaSemana))))
   End Function

End Class