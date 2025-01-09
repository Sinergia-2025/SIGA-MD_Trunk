Imports Eniac.Entidades

Public Class CalidadListasControlProductos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CalidadListaControlProducto.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CalidadListaControlProducto)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CalidadListaControlProducto)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CalidadListaControlProducto)))
   End Sub

   Public Overrides Function GetAll() As DataTable
      Return GetSql().CalidadListasControlProductos_GA()
   End Function
   Public Function GetTodos() As List(Of CalidadListaControlProducto)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadListaControlProducto())
   End Function

   Public Function _GetTodos(IdProducto As String) As ListConBorrados(Of Entidades.CalidadListaControlProducto)
      Dim dt As DataTable = Get1(IdProducto, 0)
      Dim o As Entidades.CalidadListaControlProducto
      Dim oLis = New ListConBorrados(Of Entidades.CalidadListaControlProducto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CalidadListaControlProducto()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.CalidadListasControlProductos
      Return New SqlServer.CalidadListasControlProductos(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.CalidadListaControlProducto, tipo As TipoSP)
      Dim sql = New SqlServer.CalidadListasControlProductos(da)
      Select Case tipo
         Case TipoSP._I
            sql.CalidadListasControlProductos_I(en.IdProducto, en.IdListaControl, en.FechaActualizacion, en.IdUsuario)
         Case TipoSP._U
            sql.CalidadListasControlProductos_U(en.IdProducto, en.IdListaControl, en.FechaActualizacion, en.IdUsuario)
         Case TipoSP._D
            sql.CalidadListasControlProductos_D(en.IdProducto, en.IdListaControl)
      End Select
   End Sub
   Private Sub CargarUno(o As Entidades.CalidadListaControlProducto, dr As DataRow)
      With o
         .IdProducto = dr.Field(Of String)(Entidades.CalidadListaControlProducto.Columnas.IdProducto.ToString())
         .IdListaControl = dr.Field(Of Integer)(Entidades.CalidadListaControlProducto.Columnas.IdListaControl.ToString())
         .IdUsuario = dr.Field(Of String)(Entidades.CalidadListaControlProducto.Columnas.IdUsuario.ToString())
         .FechaActualizacion = dr.Field(Of DateTime)(Entidades.CalidadListaControlProducto.Columnas.FechaActualizacion.ToString())
         .NombreListaControl = dr.Field(Of String)("NombreListaControl")
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CalidadListaControlProducto)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CalidadListaControlProducto)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CalidadListaControlProducto)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function Get1(idProducto As String, idListaControl As Integer) As DataTable
      Return GetSql().CalidadListasControlProductos_G1(idProducto, idListaControl)
   End Function
   Public Function GetUno(idProducto As String, idListaControl As Integer) As Entidades.CalidadListaControlProducto
      Return GetUno(idProducto, idListaControl, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idProducto As String, idListaControl As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CalidadListaControlProducto
      Return CargaEntidad(Get1(idProducto, idListaControl), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadListaControlProducto(),
                          accion, Function() String.Format("No existe CalidadListasControlProductos {0}", idProducto))
   End Function

   Public Sub ActualizaDesdeProducto(entidad As ListConBorrados(Of CalidadListaControlProducto), idProducto As String)
      If entidad IsNot Nothing Then
         For Each ent As Entidades.CalidadListaControlProducto In entidad.Borrados
            _Borrar(ent)
         Next
         For Each ent As Entidades.CalidadListaControlProducto In entidad
            If ent.IdProducto Is Nothing Then
               ent.IdProducto = idProducto
               ent.IdUsuario = actual.Nombre
               ent.FechaActualizacion = DateTime.Now
               _Insertar(ent)
            End If
         Next
      End If
   End Sub
   Public Function GetItemListaControlPorProducto(idProducto As String) As DataTable
      Return GetSql().CalidadOrdenListaControlProductos_G(idProducto)
   End Function
#End Region
End Class
