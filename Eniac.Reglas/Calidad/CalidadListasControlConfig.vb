Public Class CalidadListasControlConfig
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CalidadListaControlConfig.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CalidadListaControlConfig)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CalidadListaControlConfig)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CalidadListaControlConfig)))
   End Sub

   Public Overrides Function GetAll() As DataTable
      Return GetSql().CalidadListasControlConfig_GA()
   End Function
   Public Overloads Function GetAll(idListaControl As Integer) As DataTable
      Return GetSql().CalidadListasControlConfig_GA(idListaControl)
   End Function
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.CalidadListasControlConfig
      Return New SqlServer.CalidadListasControlConfig(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.CalidadListaControlConfig, tipo As TipoSP)
      Dim sqlC = GetSql()
      Select Case tipo
         Case TipoSP._I
            sqlC.CalidadListasControlConfig_I(en.IdListaControl, en.IdListaControlItem, en.Orden)
         Case TipoSP._U
            sqlC.CalidadListasControlConfig_U(en.IdListaControl, en.IdListaControlItem, en.Orden)
         Case TipoSP._D
            sqlC.CalidadListasControlConfig_D(en.IdListaControl, en.IdListaControlItem)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CalidadListaControlConfig, dr As DataRow)
      With o
         .IdListaControl = dr.Field(Of Integer)(Entidades.CalidadListaControlConfig.Columnas.IdListaControl.ToString())
         .Item = New CalidadListasControlItems(da).GetUno(dr.Field(Of Integer)(Entidades.CalidadListaControlConfig.Columnas.IdListaControlItem.ToString()))
         .Orden = dr.Field(Of Integer)(Entidades.CalidadListaControlConfig.Columnas.Orden.ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CalidadListaControlConfig)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CalidadListaControlConfig)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CalidadListaControlConfig)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub _Insertar(entidad As Entidades.CalidadListaControl)
      entidad.Items.ForEach(
         Sub(en)
            en.IdListaControl = entidad.IdListaControl
            _Insertar(en)
         End Sub)
   End Sub
   Public Overloads Sub Actualizar(entidad As Entidades.CalidadListaControl)
      EjecutaConTransaccion(Sub() _Actualizar(entidad))
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CalidadListaControl)
      _Borrar(entidad)
      _Insertar(entidad)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CalidadListaControl)
      _Borrar(New Entidades.CalidadListaControlConfig() With {.IdListaControl = entidad.IdListaControl})
   End Sub

   Public Function Get1(idListaControl As Integer, idListaControlItem As Integer) As DataTable
      Return GetSql().CalidadListasControlConfig_G1(idListaControl, idListaControlItem)
   End Function
   Public Function GetUno(idListaControl As Integer, idListaControlItem As Integer) As Entidades.CalidadListaControlConfig
      Return GetUno(idListaControl, idListaControlItem, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idListaControl As Integer, idListaControlItem As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CalidadListaControlConfig
      Return CargaEntidad(Get1(idListaControl, idListaControlItem), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadListaControlConfig(),
                          accion, Function() String.Format("No existe Item {1} para la Lista de Control {0}", idListaControl, idListaControlItem))
   End Function
   Public Function GetTodas(idListaControl As Integer) As List(Of Entidades.CalidadListaControlConfig)
      Return CargaLista(GetAll(idListaControl), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadListaControlConfig())
   End Function
   Public Function GetOrdenMaximo(idListaControl As Integer) As Integer
      Return GetSql().GetOrdenMaximo(idListaControl)
   End Function

#End Region

End Class