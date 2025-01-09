Imports System.Text
Imports Eniac.Datos

Public Class RolesFunciones
   Inherits Eniac.Reglas.Base

   Public Sub New()
      Me.NombreEntidad = "RolesFunciones"
      da = New Datos.DataAccess(CadenaSegura)
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

   

#Region "Overrides"
   Protected Overridable Function GetSqlServer() As Eniac.SqlServer.RolesFunciones
      Return New SqlServer.RolesFunciones(da)
   End Function

   Protected Overridable Function GetReglasUsuarios() As Reglas.Usuarios
      Return New Reglas.Usuarios
   End Function
   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim usuario As Entidades.RolFuncion = DirectCast(entidad, Entidades.RolFuncion)
      Try
         da.OpenConection()
         da.BeginTransaction()
         With usuario
            'DataService.GetDataAccess(CadenaSegura).ExecuteNonQuery(Me.NombreEntidad & PrefijoInsert, _
            '        CommandType.StoredProcedure, _
            '        .IdRol, _
            '        .IdFuncion)
            GetSqlServer().RolesFunciones_I(.IdRol, .IdFuncion)
         End With
         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim usuario As Entidades.RolFuncion = DirectCast(entidad, Entidades.RolFuncion)
      Try
         da.OpenConection()
         da.BeginTransaction()
         With usuario
            GetSqlServer().RolesFunciones_D(.IdRol, .IdFuncion)
         End With
         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try


   End Sub
   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      'Dim stbQuery As StringBuilder = New StringBuilder("")
      'With stbQuery
      '   .Append(" SELECT U.Id ")
      '   .Append("       ,U.Nombre ")
      '   .Append("       ,U.Clave ")
      '   .Append("   FROM Usuarios U ")
      '   .Append("  WHERE ")
      '   .Append(entidad.Columna)
      '   .Append(" LIKE '%")
      '   .Append(entidad.Valor.ToString())
      '   .Append("%'")
      'End With
      'Return Me.da.GetDataTable(stbQuery.ToString())
      Return GetReglasUsuarios.Buscar(entidad)

   End Function

#End Region

   Public Function GetFuncionesPorRol(ByVal rol As String) As DataTable
      Return GetSqlServer.RolesFunciones_GA(rol)
   End Function

#Region "Metodos privados"

   'Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
   '   Dim ur As Entidades.RolFuncion = DirectCast(entidad, Entidades.RolFuncion)
   '   Try
   '      da.OpenConection(CadenaSegura)
   '      da.BeginTransaction()

   '      da.Command.Parameters.Clear()
   '      da.Command.Connection = da.Connection
   '      da.Command.Transaction = da.Transaction
   '      da.Command.CommandText = Me.NombreEntidad & tipo.ToString()
   '      da.Command.CommandType = CommandType.StoredProcedure

   '      da.LoadParameter("@idRol", ParameterDirection.Input, DbType.String, ur.IdRol)
   '      da.LoadParameter("@idFuncion", ParameterDirection.Input, DbType.String, ur.IdFuncion)
   '      da.Command.ExecuteNonQuery()

   '      da.CommitTransaction()

   '   Catch ex As Exception
   '      da.RollbakTransaction()
   '      Throw ex
   '   Finally
   '      da.CloseConection()
   '   End Try
   'End Sub

#End Region

End Class


