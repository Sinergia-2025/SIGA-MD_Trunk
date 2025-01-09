Option Strict On
Option Explicit On
Imports System.Runtime.CompilerServices
Namespace Extensions
   Public Module ClienteExtensions
      <Extension>
      Public Function HorarioToString(cliente As Entidades.Cliente) As String
         Dim horaInicio As DateTime? = StringToDate(cliente.HoraInicio)
         Dim horaFin As DateTime? = StringToDate(cliente.HoraFin)
         Dim horaInicio2 As DateTime? = StringToDate(cliente.HoraInicio2)
         Dim horaFin2 As DateTime? = StringToDate(cliente.HoraFin2)
         Dim horaSabInicio As DateTime? = StringToDate(cliente.HoraSabInicio)
         Dim horaSabFin As DateTime? = StringToDate(cliente.HoraSabFin)
         Dim horaSabInicio2 As DateTime? = StringToDate(cliente.HoraSabInicio2)
         Dim horaSabFin2 As DateTime? = StringToDate(cliente.HoraSabFin2)
         Dim horaDomInicio As DateTime? = StringToDate(cliente.HoraDomInicio)
         Dim horaDomFin As DateTime? = StringToDate(cliente.HoraDomFin)
         Dim horaDomInicio2 As DateTime? = StringToDate(cliente.HoraDomInicio2)
         Dim horaDomFin2 As DateTime? = StringToDate(cliente.HoraDomFin2) '.ToString()).ToString("HH:mm")

         Dim stbHorario As StringBuilder = New StringBuilder()
         Dim prefijo As String = ""
         ConcatenaHorario(stbHorario, prefijo, "Lunes a Viernes", horaInicio, horaFin, horaInicio2, horaFin2, cliente.HorarioCorrido)
         ConcatenaHorario(stbHorario, prefijo, "Sábados", horaSabInicio, horaSabFin, horaSabInicio2, horaSabFin2, cliente.HorarioCorridoSab)
         ConcatenaHorario(stbHorario, prefijo, "Domingos", horaDomInicio, horaDomFin, horaDomInicio2, horaDomFin2, cliente.HorarioCorridoDom)

         Return stbHorario.ToString()
      End Function

      Private Sub ConcatenaHorario(stb As StringBuilder, ByRef prefijo As String, dia As String, inicio As DateTime?, fin As DateTime?, inicio2 As DateTime?, fin2 As DateTime?, horarioCorrido As Boolean)
         If inicio.HasValue And fin.HasValue And inicio2.HasValue And fin2.HasValue AndAlso
            inicio.Value.Hour <> 0 Then
            If horarioCorrido Then
               stb.AppendFormat("{0}{1}: Horario Corrido {2:HH:mm} a {3:HH:mm}", prefijo, dia, inicio, fin2)
            Else
               stb.AppendFormat("{0}{1}: {2:HH:mm} a {3:HH:mm} y {4:HH:mm} a {5:HH:mm}", prefijo, dia, inicio, fin, inicio2, fin2)
            End If
            prefijo = " - "
         End If

      End Sub
      Private Function StringToDate(hora As String) As DateTime?
         If IsDate(hora) Then
            Return DateTime.Parse(hora)
         End If
         Return Nothing
      End Function
   End Module
End Namespace