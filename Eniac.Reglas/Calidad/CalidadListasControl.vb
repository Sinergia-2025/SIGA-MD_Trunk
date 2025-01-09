Public Class CalidadListasControl
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CalidadListaControl.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CalidadListaControl)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CalidadListaControl)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CalidadListaControl)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetSql().CalidadListasControl_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.CalidadListasControl
      Return New SqlServer.CalidadListasControl(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.CalidadListaControl, tipo As TipoSP)
      Dim sql = GetSql()
      Dim rConfig = New CalidadListasControlConfig(da)
      Select Case tipo
         Case TipoSP._I
            sql.CalidadListasControl_I(en.IdListaControl, en.NombreListaControl, en.Orden, en.IdListaControlTipo)

         Case TipoSP._U
            sql.CalidadListasControl_U(en.IdListaControl, en.NombreListaControl, en.Orden, en.IdListaControlTipo)

         Case TipoSP._D
            rConfig._Borrar(en)
            sql.CalidadListasControl_D(en.IdListaControl)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CalidadListaControl, dr As DataRow, cargaItems As Boolean)
      With o
         .IdListaControl = dr.Field(Of Integer)(Entidades.CalidadListaControl.Columnas.IdListaControl.ToString())
         .NombreListaControl = dr.Field(Of String)(Entidades.CalidadListaControl.Columnas.NombreListaControl.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.CalidadListaControl.Columnas.Orden.ToString())
         .Tipo = New CalidadListasControlTipos(da).GetUno(dr.Field(Of Integer)(Entidades.CalidadListaControl.Columnas.IdListaControlTipo.ToString()))
         If cargaItems Then
            .Items = New CalidadListasControlConfig(da).GetTodas(.IdListaControl)
         End If
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CalidadListaControl)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CalidadListaControl)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CalidadListaControl)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function Get1(idListaControl As Integer) As DataTable
      Return GetSql().CalidadListasControl_G1(idListaControl)
   End Function
   Public Function GetUno(idListaControl As Integer, cargaItems As Boolean) As Entidades.CalidadListaControl
      Return GetUno(idListaControl, cargaItems, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idListaControl As Integer, cargaItems As Boolean, accion As AccionesSiNoExisteRegistro) As Entidades.CalidadListaControl
      Return CargaEntidad(Get1(idListaControl), Sub(o, dr) CargarUno(o, dr, cargaItems), Function() New Entidades.CalidadListaControl(),
                          accion, Function() String.Format("No existe Lista de Control {0}", idListaControl))
   End Function

   Public Function GetTodos() As List(Of Entidades.CalidadListaControl)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr, cargaItems:=False), Function() New Entidades.CalidadListaControl())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetSql().GetCodigoMaximo()
   End Function

#End Region
End Class