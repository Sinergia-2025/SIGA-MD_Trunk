Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class CalendariosExcepciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CalendariosExcepciones_I(idCalendario As Integer,
                                    idDiaSemana As Integer,
                                    idExcepcion As Integer,
                                    FechaExcepcion As Date)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO CalendariosExcepciones ({0}, {1}, {2}, {3})",
                       Entidades.CalendarioExcepcion.Columnas.IdCalendario.ToString(),
                       Entidades.CalendarioExcepcion.Columnas.IdDiaSemana.ToString(),
                       Entidades.CalendarioExcepcion.Columnas.IdExcepcion.ToString(),
                       Entidades.CalendarioExcepcion.Columnas.FechaExcepcion.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, {1}, {2}, '{3}'",
                       idCalendario, idDiaSemana, idExcepcion, FechaExcepcion.ToString("yyyyMMdd"))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CalendariosExcepciones_U(idCalendario As Integer,
                                    idDiaSemana As Integer,
                                    idExcepcion As Integer,
                                    FechaExcepcion As Date)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE CalendariosExcepciones ")
         .AppendFormat("   SET {0} = '{1}'", Entidades.CalendarioExcepcion.Columnas.IdDiaSemana.ToString(), idDiaSemana).AppendLine()
         .AppendFormat("     , {0} = '{1}'", Entidades.CalendarioExcepcion.Columnas.FechaExcepcion.ToString(), FechaExcepcion).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.CalendarioExcepcion.Columnas.IdCalendario.ToString(), idCalendario)
         .AppendFormat("   AND {0} =  {1} ", Entidades.CalendarioExcepcion.Columnas.IdExcepcion.ToString(), idExcepcion)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CalendariosExcepciones_D(idCalendario As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM CalendariosExcepciones").AppendLine()
         .AppendFormat("  WHERE {0} = {1}", Entidades.CalendarioExcepcion.Columnas.IdCalendario.ToString(), idCalendario).AppendLine()
        
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT CH.*, '' AS NombreDiaSemana FROM CalendariosExcepciones AS CH").AppendLine()
      End With
   End Sub

   Public Function CalendariosExcepciones_GA() As DataTable
      Return CalendariosExcepciones_G(idCalendario:=0)
   End Function
   Public Function CalendariosExcepciones_GA(idCalendario As Integer) As DataTable
      Return CalendariosExcepciones_G(idCalendario:=idCalendario)
   End Function
   Public Function CalendariosExcepciones_GA(idCalendario As Integer, idExcepcion As Integer) As DataTable
      Return CalendariosExcepciones_G(idCalendario:=idCalendario)
   End Function
   Private Function CalendariosExcepciones_G(idCalendario As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCalendario > 0 Then
            .AppendFormat("   AND CH.IdCalendario = {0}", idCalendario).AppendLine()
         End If
      End With

      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())

      For Each dr As DataRow In dt.Rows
         Dim diaSemana As Integer = Integer.Parse(dr(Entidades.CalendarioHorario.Columnas.IdDiaSemana.ToString()).ToString())
         dr("NombreDiaSemana") = DirectCast(diaSemana, System.DayOfWeek).NombreDiaSemana()
      Next

      Return dt
   End Function

   Private Function CalendariosExcepciones_GetActuales(idCalendario As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE CH.FechaExcepcion >= " & Date.Today())
         If idCalendario > 0 Then
            .AppendFormat("   AND CH.IdCalendario = {0}", idCalendario).AppendLine()
         End If
      End With

      Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())

      For Each dr As DataRow In dt.Rows
         Dim diaSemana As Integer = Integer.Parse(dr(Entidades.CalendarioHorario.Columnas.IdDiaSemana.ToString()).ToString())
         dr("NombreDiaSemana") = DirectCast(diaSemana, System.DayOfWeek).NombreDiaSemana()
      Next

      Return dt
   End Function

   Public Function CalendariosExcepciones_G1(idCalendario As Integer, idExcepcion As Integer) As DataTable
      Return CalendariosExcepciones_G1(idCalendario:=idCalendario, idExcepcion:=idExcepcion)
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

   Public Overloads Function GetCodigoMaximo(idCalendario As Integer) As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.CalendarioExcepcion.Columnas.IdExcepcion.ToString(), "CalendariosExcepciones",
                                                    String.Format("IdCalendario = {0} ", idCalendario)))
   End Function

End Class