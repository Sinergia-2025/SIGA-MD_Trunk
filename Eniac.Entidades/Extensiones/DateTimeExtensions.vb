#Region "Imports"
Imports System.Globalization
#End Region
Namespace Extensiones
   Public Module DateTimeExtensions
      Private culturaArgentina As New CultureInfo("es-AR")

      <Extension()>
      Public Function UltimoDiaMes(fecha As Date) As Date
         Return UltimoDiaMes(fecha, False)
      End Function

      <Extension()>
      Public Function UltimoDiaMes(fecha As Date, ultimoSegundo As Boolean) As Date
         If ultimoSegundo Then
            Return PrimerDiaMes(fecha).AddMonths(1).AddSeconds(-1)
         Else
            Return PrimerDiaMes(fecha).AddMonths(1).AddDays(-1)
         End If
      End Function
      <Extension>
      Public Function UltimoSegundoDelDia(fecha As Date) As Date
         Return fecha.Date.AddDays(1).AddSeconds(-1)
      End Function
      <Extension>
      Public Function UltimoSegundoDelDia(fecha As Date?) As Date?
         If fecha.HasValue Then
            Return fecha.Value.Date.AddDays(1).AddSeconds(-1)
         Else
            Return Nothing
         End If
      End Function
      <Extension>
      Public Function [Date](fecha As Date?) As Date?
         If fecha.HasValue Then
            Return fecha.Value.Date
         Else
            Return Nothing
         End If
      End Function

      <Extension()>
      Public Function PrimerDiaMes(fecha As Date) As Date
         Return New Date(fecha.Year, fecha.Month, 1)
      End Function
      <Extension()>
      Public Function PrimerDiaAnio(fecha As Date) As Date
         Return New Date(fecha.Year, 1, 1)
      End Function

      <Extension()>
      Public Function RedondearFecha(fechaSinRedondeas As Date, lapsoMinutos As Decimal) As Date
         ' just some date, should be a parameter to your function
         Dim mydatetime As Date = fechaSinRedondeas

         ' split into date + time parts
         Dim datepart As Date = mydatetime.Date
         Dim timepart As TimeSpan = mydatetime.TimeOfDay

         Dim medioLapso As Decimal = lapsoMinutos / 2
         ' round time to the nearest 5 minutes
         timepart = TimeSpan.FromMinutes(Math.Floor((timepart.TotalMinutes + medioLapso) / lapsoMinutos) * lapsoMinutos)

         ' combine the parts
         Dim newtime As Date = datepart.Add(timepart)
         ' a function would return this value
         Return newtime
      End Function

      <Extension()>
      Public Function SemanaDelAnio(fecha As Date) As Integer
         Return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(fecha, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)
         'CInt(DatePart(DateInterval.WeekOfYear, CDate(fecha.ToString), FirstDayOfWeek.Monday, FirstWeekOfYear.FirstFullWeek))
      End Function

      <Extension()>
      Public Function LunesAnterior(fecha As Date) As Date
         If fecha.DayOfWeek = DayOfWeek.Sunday Then fecha = fecha.AddDays(2)
         While fecha.DayOfWeek > DayOfWeek.Monday
            fecha = fecha.AddDays(-1)
         End While
         Return fecha
      End Function

      Public Function PrimerDiaSemanaISO8601(anioSemana As String) As Date
         Dim split As String() = anioSemana.Split("-"c)
         If split.Length = 2 AndAlso IsNumeric(split(0)) And IsNumeric(split(1)) Then
            Return PrimerDiaSemanaISO8601(Integer.Parse(split(0)), Integer.Parse(split(1)))
         End If
         Throw New FormatException("Formato de Año-Semana inválido")
      End Function
      Public Function PrimerDiaSemanaISO8601(anio As Integer, semana As Integer) As Date
         Dim enero1 As Date = New DateTime(anio, 1, 1)
         Dim daysOffset As Integer = DayOfWeek.Thursday - enero1.DayOfWeek

         '' Use first Thursday in January to get first week of the year as
         '' it will never be in Week 52/53
         Dim primerJueves As Date = enero1.AddDays(daysOffset)
         Dim primerSemana As Integer = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(primerJueves, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday)

         Dim numeroSemana As Integer = semana
         '' As we're adding days to a date in Week 1,
         '' we need to subtract 1 in order to get the right date for week #1
         If primerSemana = 1 Then
            numeroSemana -= 1
         End If

         '' Using the first Thursday as starting week ensures that we are starting in the right year
         '' then we add number of weeks multiplied with days
         Dim result As Date = primerJueves.AddDays(numeroSemana * 7)

         '' Subtract 3 days from Thursday to get Monday, which is the first weekday in ISO8601
         Return result.AddDays(-3)
      End Function

      Public Function CompraraRangoDeFechas(fechaDesdeNuevo As Date, fechaHastaNuevo As Date, fechaDesdeExistente As Date, fechaHastaExistente As Date) As Boolean
         Return (fechaDesdeNuevo >= fechaDesdeExistente And fechaHastaNuevo <= fechaHastaExistente) Or
                (fechaDesdeNuevo <= fechaDesdeExistente And fechaHastaNuevo >= fechaDesdeExistente) Or
                (fechaDesdeNuevo <= fechaHastaExistente And fechaHastaNuevo >= fechaHastaExistente)
      End Function


      <Extension>
      Public Function GetDiaEnEspanol(fecha As Date) As String
         Return culturaArgentina.DateTimeFormat.GetDayName(fecha.DayOfWeek)
      End Function
      <Extension>
      Public Function GetMonthEnEspanol(fecha As Date) As String
         Return culturaArgentina.DateTimeFormat.GetMonthName(fecha.Month)
      End Function

      <Extension>
      Public Function ToStringValue(fecha As Date?) As String
         Return fecha.ToStringValue(String.Empty)
      End Function
      <Extension>
      Public Function ToStringFormat(fecha As Date?, format As String) As String
         Return fecha.ToStringValue(format, String.Empty)
      End Function
      <Extension>
      Public Function ToStringValue(fecha As Date?, defaultValue As String) As String
         If fecha.HasValue Then
            Return fecha.Value.ToString()
         Else
            Return defaultValue
         End If
      End Function
      <Extension>
      Public Function ToStringValue(fecha As Date?, format As String, defaultValue As String) As String
         If fecha.HasValue Then
            Return fecha.Value.ToString(format)
         Else
            Return defaultValue
         End If
      End Function

      <Extension>
      Public Function IfNull(valor As Date?) As Date
         Return valor.IfNull(New DateTime())
      End Function
      <Extension>
      Public Function IfNull(valor As Date?, valueIfNull As Date) As Date
         If valor.HasValue Then
            Return valor.Value
         End If
         Return valueIfNull
      End Function

      <Extension>
      Public Function ToStringISO8601(value As Date) As String
         Return value.ToString("O")
      End Function
      <Extension>
      Public Function ToStringISO8601(value As Date?) As String
         Return If(value.HasValue, value.Value.ToStringISO8601(), Nothing)
      End Function
      <Extension>
      Public Function FromStringISO8601(value As String) As Date?
         Dim tempDate As Date
         If DateTime.TryParse(value, tempDate) Then
            Return tempDate
         End If
         Dim split = value.Split("+"c)
         If split.Length > 1 AndAlso DateTime.TryParse(split(0), tempDate) Then
            Return tempDate
         End If
         split = value.Split("-"c)
         If split.Length > 1 AndAlso DateTime.TryParse(split(0), tempDate) Then
            Return tempDate
         End If
         Return Nothing
      End Function

      Public Const FormatoFechaURL As String = "yyyy-MM-dd_HHmmss"
      Public Const FormatoFechaPropio As String = "yyyy-MM-dd HH:mm:ss"
      Public Const FormatoFechaPropioConMilisegundos As String = "yyyy-MM-dd HH:mm:ss.fff"
      <Extension>
      Public Function ToStringFormatoURL(fecha As Date?) As String
         If fecha.HasValue Then
            Return ToStringFormatoPropio(fecha.Value, True)
         End If
         Return Nothing
      End Function
      <Extension>
      Public Function ToStringFormatoPropio(fecha As Date) As String
         Return PrivateToStringFormatoPropio(fecha, conMilisegundos:=False)
      End Function
      <Extension>
      Public Function ToStringFormatoPropio(fecha As Date?) As String
         Return PrivateToStringFormatoPropio(fecha, conMilisegundos:=False)
      End Function
      <Extension>
      Public Function ToStringFormatoPropio(fecha As Date, conMilisegundos As Boolean) As String
         Return PrivateToStringFormatoPropio(fecha, conMilisegundos)
      End Function
      <Extension>
      Public Function ToStringFormatoPropio(fecha As Date?, conMilisegundos As Boolean) As String
         Return PrivateToStringFormatoPropio(fecha, conMilisegundos)
      End Function

      Private Function PrivateToStringFormatoPropio(fecha As Date?, conMilisegundos As Boolean) As String
         If fecha.HasValue Then
            If conMilisegundos Then
               Return fecha.Value.ToString(FormatoFechaPropioConMilisegundos)
            Else
               Return fecha.Value.ToString(FormatoFechaPropio)
            End If
         Else
            Return Nothing
         End If
      End Function

      <Extension>
      Public Function ToDateTimeFormatoPropio(fecha As String) As Date
         Return ToDateTimeFormatoPropio(fecha, False)
      End Function
      <Extension>
      Public Function ToDateTimeFormatoPropio(fecha As String, conMilisegundos As Boolean) As Date
         If conMilisegundos Then
            Return ToDateTimeFormatoPropio(fecha, FormatoFechaPropioConMilisegundos)
         Else
            Return ToDateTimeFormatoPropio(fecha, FormatoFechaPropio)
         End If
      End Function

      <Extension>
      Public Function ToDateTimeFormatoPropio(fecha As String, formato As String) As Date
         Try
            Return DateTime.ParseExact(fecha, formato, Globalization.CultureInfo.InvariantCulture)
         Catch
            Try
               Return DateTime.Parse(fecha)
            Catch
               Return Now
            End Try
         End Try
      End Function

      <Extension>
      Public Function ToDateTime(value As String) As Date?
         Dim result As Date
         If Not String.IsNullOrWhiteSpace(value) AndAlso DateTime.TryParse(value, result) Then
            Return result
         End If
         Return Nothing
      End Function


      <Extension()>
      Public Function ToPeriodo(fecha As Date) As Integer
         Return fecha.Year * 100 + fecha.Month
      End Function
      <Extension()>
      Public Function FromPeriodo(periodo As Integer) As Date
         Dim anio = Convert.ToInt32(Math.Truncate(periodo / 100))
         Dim mes = periodo - (anio * 100)
         Return New DateTime(anio, mes, 1)
      End Function

      <Extension>
      Public Function ToPeriodList(rangoFechas As Tuple(Of Date, Date)) As List(Of String)
         Return ToPeriodList(rangoFechas, descending:=False)
      End Function

      <Extension>
      Public Function ToPeriodList(rangoFechas As Tuple(Of Date, Date), descending As Boolean) As List(Of String)
         Dim fechaDesde = rangoFechas.Item1
         Dim fechaHasta = rangoFechas.Item2
         Dim periodos = New List(Of String)()
         Dim tempFecha = fechaDesde.PrimerDiaMes()
         Do
            periodos.Add(tempFecha.ToString("yyyyMM"))
            tempFecha = tempFecha.AddMonths(1)
         Loop While tempFecha < fechaHasta
         If Not descending Then
            Return periodos.OrderBy(Function(s) s).ToList()
         Else
            Return periodos.OrderByDescending(Function(s) s).ToList()
         End If
      End Function

   End Module
End Namespace