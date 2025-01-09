Public Class CalidadListasControlItemsSubGrupos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CalidadListaControlItemSubGrupo.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CalidadListaControlItemSubGrupo)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CalidadListaControlItemSubGrupo)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CalidadListaControlItemSubGrupo)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return GetSql().CalidadListasControlItemsSubGrupos_GA()
   End Function
   Public Overloads Function GetAll(idListaControlItemGrupo As String) As DataTable
      Return GetSql().CalidadListasControlItemsSubGrupos_GA(idListaControlItemGrupo)
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.CalidadListasControlItemsSubGrupos
      Return New SqlServer.CalidadListasControlItemsSubGrupos(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.CalidadListaControlItemSubGrupo, tipo As TipoSP)
      Dim sqlC = GetSql()
      Select Case tipo
         Case TipoSP._I
            sqlC.CalidadListasControlItemsSubGrupos_I(en.IdListaControlItemGrupo, en.IdListaControlItemSubGrupo, en.NombreListaControlItemSubGrupo)
         Case TipoSP._U
            sqlC.CalidadListasControlItemsSubGrupos_U(en.IdListaControlItemGrupo, en.IdListaControlItemSubGrupo, en.NombreListaControlItemSubGrupo)
         Case TipoSP._D
            sqlC.CalidadListasControlItemsSubGrupos_D(en.IdListaControlItemGrupo, en.IdListaControlItemSubGrupo)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CalidadListaControlItemSubGrupo, dr As DataRow)
      With o
         .IdListaControlItemGrupo = dr.Field(Of String)(Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemGrupo.ToString())
         .IdListaControlItemSubGrupo = dr.Field(Of String)(Entidades.CalidadListaControlItemSubGrupo.Columnas.IdListaControlItemSubGrupo.ToString())
         .NombreListaControlItemSubGrupo = dr.Field(Of String)(Entidades.CalidadListaControlItemSubGrupo.Columnas.NombreListaControlItemSubGrupo.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CalidadListaControlItemSubGrupo)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CalidadListaControlItemSubGrupo)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CalidadListaControlItemSubGrupo)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function Get1(idListaControlItemGrupo As String, idListaControlItemSubGrupo As String) As DataTable
      Return GetSql().CalidadListasControlItemsSubGrupos_G1(idListaControlItemGrupo, idListaControlItemSubGrupo)
   End Function
   Public Function GetUno(idListaControlItemGrupo As String, idListaControlItemSubGrupo As String) As Entidades.CalidadListaControlItemSubGrupo
      Return GetUno(idListaControlItemGrupo, idListaControlItemSubGrupo, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idListaControlItemGrupo As String, idListaControlItemSubGrupo As String, accion As AccionesSiNoExisteRegistro) As Entidades.CalidadListaControlItemSubGrupo
      Return CargaEntidad(Get1(idListaControlItemGrupo, idListaControlItemSubGrupo), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadListaControlItemSubGrupo(),
                          accion, Function() String.Format("No existe Sub Grupo {1} del grupo {0}", idListaControlItemGrupo, idListaControlItemSubGrupo))
   End Function
   Public Function GetTodos() As List(Of Entidades.CalidadListaControlItemSubGrupo)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadListaControlItemSubGrupo())
   End Function
   Public Function GetTodos(idListaControlItemGrupo As String) As List(Of Entidades.CalidadListaControlItemSubGrupo)
      Return CargaLista(GetAll(idListaControlItemGrupo), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadListaControlItemSubGrupo())
   End Function

#End Region
End Class