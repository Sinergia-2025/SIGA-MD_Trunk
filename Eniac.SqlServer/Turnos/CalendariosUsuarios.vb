Imports System.Text

Public Class CalendariosUsuarios
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CalendariosUsuarios_I(ByVal IdSucursal As Integer, _
                              ByVal idCalendario As Integer, _
                              ByVal IdUsuario As String, _
                              ByVal PermitirEscritura As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO  ")
         .Append("CalendariosUsuarios  ")
         .Append("(IdSucursal, ")
         .Append("IdCalendario, ")
         .Append("IdUsuario, ")
         .AppendLine(" PermitirEscritura")
         .Append(") VALUES (")
         .Append(IdSucursal & ", ")
         .Append(idCalendario & ", ")
         .Append("'" & IdUsuario.ToString() & "',")
         .AppendFormat(" {0} ", Me.GetStringFromBoolean(PermitirEscritura) & ")")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CalendariosUsuarios")

   End Sub


   Public Sub CalendariosUsuarios_D(ByVal IdSucursal As Integer, _
                              ByVal IdCalendario As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM CalendariosUsuarios  ")
         .Append(" WHERE IdCalendario = " & IdCalendario)
         If IdSucursal <> 0 Then
            .AppendLine(" AND IdSucursal = " & IdSucursal)
         End If
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "CalendariosUsuarios")

   End Sub

End Class
