Public Class ListasControlRoles
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ListasControlRoles_I(idListaControl As Integer,
                                      idUsuario As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO CalidadListasControlRoles ({0}, {1})",
                       Entidades.ListaControlRol.Columnas.IdListaControl.ToString(),
                       Entidades.ListaControlRol.Columnas.IdRol.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}')",
                       idListaControl, idUsuario)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlRoles_U(idListaControl As Integer,
                                      idUsuario As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE CalidadListasControlRoles ")
         .AppendFormat("   SET {0} = '{1}'", Entidades.ListaControlRol.Columnas.IdRol.ToString(), idUsuario).AppendLine()
         .AppendFormat(" WHERE {0} = {1}", Entidades.ListaControlRol.Columnas.IdListaControl.ToString(), idListaControl)

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlRoles_D(idListaControl As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadListasControlRoles ")
         .AppendFormat(" WHERE {0} = {1}", Entidades.ListaControlRol.Columnas.IdListaControl.ToString(), idListaControl)

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT LCU.*, U.Nombre, LC.NombreListaControl FROM CalidadListasControlRoles AS LCU").AppendLine()
         .AppendFormat(" LEFT JOIN Roles AS U ON U.Id = LCU.IdRol")
         .AppendFormat(" LEFT JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl")
      End With
   End Sub

   Public Function ListasControlRoles_GA(idListaControl As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE LCU.{0} = {1}", Entidades.ListaControlRol.Columnas.IdListaControl.ToString(), idListaControl)

         .AppendFormat(" ORDER BY U.Nombre")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class