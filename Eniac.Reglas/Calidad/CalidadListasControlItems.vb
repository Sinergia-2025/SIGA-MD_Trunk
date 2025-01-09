Public Class CalidadListasControlItems
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CalidadListaControlItem.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CalidadListaControlItem)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CalidadListaControlItem)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CalidadListaControlItem)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return GetSql().CalidadListasControlItems_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.CalidadListasControlItems
      Return New SqlServer.CalidadListasControlItems(da)
   End Function

   Private Sub EjecutaSP(en As Entidades.CalidadListaControlItem, tipo As TipoSP)
      Dim sqlC = GetSql()
      Select Case tipo
         Case TipoSP._I
            sqlC.CalidadListasControlItems_I(en.IdListaControlItem, en.NombreListaControlItem,
                                             en.IdListaControlItemGrupo, en.IdListaControlItemSubGrupo,
                                             en.NivelInspeccion, en.ValorAQL, en.Observacion)
         Case TipoSP._U
            sqlC.CalidadListasControlItems_U(en.IdListaControlItem, en.NombreListaControlItem,
                                             en.IdListaControlItemGrupo, en.IdListaControlItemSubGrupo,
                                             en.NivelInspeccion, en.ValorAQL, en.Observacion)
         Case TipoSP._D
            sqlC.CalidadListasControlItems_D(en.IdListaControlItem)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CalidadListaControlItem, dr As DataRow)
      With o
         .IdListaControlItem = dr.Field(Of Integer)(Entidades.CalidadListaControlItem.Columnas.IdListaControlItem.ToString())
         .NombreListaControlItem = dr.Field(Of String)(Entidades.CalidadListaControlItem.Columnas.NombreListaControlItem.ToString())
         .Grupo = New CalidadListaControlItemGrupo(da).GetUno(dr.Field(Of String)(Entidades.CalidadListaControlItem.Columnas.IdListaControlItemGrupo.ToString()))
         .SubGrupo = New CalidadListasControlItemsSubGrupos(da).GetUno(dr.Field(Of String)(Entidades.CalidadListaControlItem.Columnas.IdListaControlItemGrupo.ToString()),
                                                                       dr.Field(Of String)(Entidades.CalidadListaControlItem.Columnas.IdListaControlItemSubGrupo.ToString()))
         .NivelInspeccion = dr.Field(Of String)(Entidades.CalidadListaControlItem.Columnas.NivelInspeccion.ToString()).StringToEnum(Entidades.NivelInspeccionMRP.I)
         .ValorAQL = dr.Field(Of Decimal)(Entidades.CalidadListaControlItem.Columnas.ValorAQL.ToString())
         .Observacion = dr.Field(Of String)(Entidades.CalidadListaControlItem.Columnas.Observacion.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CalidadListaControlItem)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CalidadListaControlItem)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CalidadListaControlItem)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function Get1(idListaControlItem As Integer) As DataTable
      Return GetSql().CalidadListasControlItems_G1(idListaControlItem)
   End Function
   Public Function GetUno(idListaControlItem As Integer) As Entidades.CalidadListaControlItem
      Return GetUno(idListaControlItem, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idListaControlItem As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CalidadListaControlItem
      Return CargaEntidad(Get1(idListaControlItem), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadListaControlItem(),
                          accion, Function() String.Format("No existe Item de Control de Calidad con Id: {0}", idListaControlItem))
   End Function
   Public Function GetTodos() As List(Of Entidades.CalidadListaControlItem)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadListaControlItem())
   End Function
   Public Overloads Function GetCodigoMaximo() As Integer
      Return New SqlServer.CalidadListasControlItems(da).GetCodigoMaximo()
   End Function

#End Region
End Class