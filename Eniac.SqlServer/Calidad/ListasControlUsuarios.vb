Public Class ListasControlUsuarios
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ListasControlUsuarios_I(idListaControl As Integer,
                                      idUsuario As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO CalidadListasControlUsuarios ({0}, {1})",
                       Entidades.ListaControlUsuario.Columnas.IdListaControl.ToString(),
                       Entidades.ListaControlUsuario.Columnas.IdUsuario.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}')",
                       IdListaControl, IdUsuario)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlUsuarios_U(idListaControl As Integer,
                                      idUsuario As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE CalidadListasControlUsuarios ")
         .AppendFormat("   SET {0} = '{1}'", Entidades.ListaControlUsuario.Columnas.IdUsuario.ToString(), IdUsuario).AppendLine()
         .AppendFormat(" WHERE {0} = {1}", Entidades.ListaControlUsuario.Columnas.IdListaControl.ToString(), IdListaControl)

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlUsuarios_D(idListaControl As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadListasControlUsuarios ")
         .AppendFormat(" WHERE {0} = {1}", Entidades.ListaControlUsuario.Columnas.IdListaControl.ToString(), IdListaControl)

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT LCU.*, U.Nombre, LC.NombreListaControl FROM CalidadListasControlUsuarios AS LCU").AppendLine()
         .AppendFormat(" LEFT JOIN Usuarios AS U ON U.Id = LCU.IdUsuario")
         .AppendFormat(" LEFT JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl")
      End With
   End Sub

   Public Function ListasControlUsuarios_GA(idListaControl As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE LCU.{0} = {1}", Entidades.ListaControlUsuario.Columnas.IdListaControl.ToString(), IdListaControl)

         .AppendFormat(" ORDER BY U.Nombre")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class