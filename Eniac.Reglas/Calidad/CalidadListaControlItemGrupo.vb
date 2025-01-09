Public Class CalidadListaControlItemGrupo
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CalidadListaControlItemGrupo.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CalidadListaControlItemGrupo)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CalidadListaControlItemGrupo)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CalidadListaControlItemGrupo)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetSql().CalidadListasControlItemsGrupos_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.CalidadListasControlItemsGrupos
      Return New SqlServer.CalidadListasControlItemsGrupos(da)
   End Function

   Private Sub EjecutaSP(en As Entidades.CalidadListaControlItemGrupo, tipo As TipoSP)
      Dim sqlC = GetSql()
      Select Case tipo
         Case TipoSP._I
            sqlC.CalidadListasControlItemsGrupos_I(en.IdListaControlItemGrupo, en.NombreListaControlItemGrupo)
         Case TipoSP._U
            sqlC.CalidadListasControlItemsGrupos_U(en.IdListaControlItemGrupo, en.NombreListaControlItemGrupo)
         Case TipoSP._D
            sqlC.CalidadListasControlItemsGrupos_D(en.IdListaControlItemGrupo)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CalidadListaControlItemGrupo, dr As DataRow)
      With o
         .IdListaControlItemGrupo = dr.Field(Of String)(Entidades.CalidadListaControlItemGrupo.Columnas.IdListaControlItemGrupo.ToString())
         .NombreListaControlItemGrupo = dr.Field(Of String)(Entidades.CalidadListaControlItemGrupo.Columnas.NombreListaControlItemGrupo.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CalidadListaControlItemGrupo)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CalidadListaControlItemGrupo)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CalidadListaControlItemGrupo)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function Get1(idListaControlItemGrupo As String) As DataTable
      Return GetSql().CalidadListasControlItemsGrupos_G1(idListaControlItemGrupo)
   End Function
   Public Function GetUno(idListaControlItemGrupo As String) As Entidades.CalidadListaControlItemGrupo
      Return GetUno(idListaControlItemGrupo, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idListaControlItemGrupo As String, accion As AccionesSiNoExisteRegistro) As Entidades.CalidadListaControlItemGrupo
      Return CargaEntidad(Get1(idListaControlItemGrupo), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadListaControlItemGrupo(),
                          accion, Function() String.Format("No existe grupo {0}", idListaControlItemGrupo))
   End Function
   Public Function GetTodos() As List(Of Entidades.CalidadListaControlItemGrupo)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadListaControlItemGrupo())
   End Function

#End Region
End Class