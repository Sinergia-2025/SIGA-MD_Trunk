Public MustInherit Class Base(Of T As Entidades.Entidad, TSql As SqlServer.Comunes)
   Inherits Base

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, T)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, T)))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, T)))
   End Sub

   Public Overloads Sub Insertar(entidad As T)
      EjecutaConTransaccion(Sub() _Insertar(entidad))
   End Sub
   Public Overloads Sub Actualizar(entidad As T)
      EjecutaConTransaccion(Sub() _Actualizar(entidad))
   End Sub
   Public Overloads Sub Borrar(entidad As T)
      EjecutaConTransaccion(Sub() _Borrar(entidad))
   End Sub

   Public Overridable Sub _Insertar(entidad As T)
      EjecutaSP(entidad, GetSql(), TipoSP._I)
   End Sub
   Public Overridable Sub _Actualizar(entidad As T)
      EjecutaSP(entidad, GetSql(), TipoSP._U)
   End Sub
   Public Overridable Sub _Borrar(entidad As T)
      EjecutaSP(entidad, GetSql(), TipoSP._D)
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return Buscar(entidad, GetSql())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return GetAll(GetSql())
   End Function

   Protected MustOverride Function GetSql() As TSql
   Protected MustOverride Sub EjecutaSP(en As T, sql As TSql, tipo As TipoSP)
   Protected MustOverride Overloads Function Buscar(entidad As Entidades.Buscar, sql As TSql) As DataTable
   Protected MustOverride Overloads Function GetAll(sql As TSql) As DataTable

   Protected MustOverride Sub CargarUno(o As T, dr As DataRow)

End Class
