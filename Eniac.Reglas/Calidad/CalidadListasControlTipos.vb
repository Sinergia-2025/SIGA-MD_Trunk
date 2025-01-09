Public Class CalidadListasControlTipos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CalidadListaControlTipo.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CalidadListaControlTipo)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CalidadListaControlTipo)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CalidadListaControlTipo)))
   End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetSql().CalidadListasControlTipos_GA()
   End Function
#End Region

#Region "Métodos Públicos"
   Public Sub _Insertar(entidad As Entidades.CalidadListaControlTipo)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CalidadListaControlTipo)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CalidadListaControlTipo)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function Get1(idTipoListaControl As Integer) As DataTable
      Return GetSql().CalidadListasControlTipos_G1(idTipoListaControl)
   End Function
   Public Function GetUno(idTipoListaControl As Integer) As Entidades.CalidadListaControlTipo
      Return GetUno(idTipoListaControl, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idTipoListaControl As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CalidadListaControlTipo
      Return CargaEntidad(Get1(idTipoListaControl), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadListaControlTipo(),
                          accion, Function() String.Format("No existe el Tipo de Lista de Control {0}", idTipoListaControl))
   End Function
   Public Function GetUnoxNombre(nombreListaControlTipo As String) As Entidades.CalidadListaControlTipo
      Return CargaEntidad(GetSql().CalidadListasControlTipos_GA(nombreListaControlTipo, nombreExacto:=True),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadListaControlTipo(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el Tipo de Lista de Control {0}", nombreListaControlTipo))
   End Function

   Public Function GetTodos() As List(Of Entidades.CalidadListaControlTipo)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadListaControlTipo())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return GetSql().GetCodigoMaximo() + 1
   End Function

#End Region

#Region "Métodos Privados"
   Private Function GetSql() As SqlServer.CalidadListasControlTipos
      Return New SqlServer.CalidadListasControlTipos(da)
   End Function

   Private Sub EjecutaSP(en As Entidades.CalidadListaControlTipo, tipo As TipoSP)
      Dim sql = GetSql()
      Select Case tipo
         Case TipoSP._I
            sql.CalidadListasControlTipos_I(en.IdListaControlTipo, en.NombreListaControlTipo)
         Case TipoSP._U
            sql.CalidadListasControlTipos_U(en.IdListaControlTipo, en.NombreListaControlTipo)
         Case TipoSP._D
            sql.CalidadListasControlTipos_D(en.IdListaControlTipo)
      End Select
   End Sub

   Private Sub CargarUno(eListaControlTipo As Entidades.CalidadListaControlTipo, dr As DataRow)
      With eListaControlTipo
         .IdListaControlTipo = dr.Field(Of Integer)(Entidades.CalidadListaControlTipo.Columnas.IdListaControlTipo.ToString())
         .NombreListaControlTipo = dr.Field(Of String)(Entidades.CalidadListaControlTipo.Columnas.NombreListaControlTipo.ToString())
      End With
   End Sub

#End Region

End Class