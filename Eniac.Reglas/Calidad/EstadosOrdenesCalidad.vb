Imports Eniac.Entidades.Banco

Public Class EstadosOrdenesCalidad
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.EstadoOrdenCalidad.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.EstadoOrdenCalidad)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.EstadoOrdenCalidad)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.EstadoOrdenCalidad)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetSql().EstadosOrdenesCalidad_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.EstadosOrdenesCalidad
      Return New SqlServer.EstadosOrdenesCalidad(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.EstadoOrdenCalidad, tipo As TipoSP)
      Dim sql = GetSql()
      Select Case tipo
         Case TipoSP._I
            sql.EstadosOrdenesCalidad_I(en.IdEstadoCalidad, en.TipoEstadoCalidad, en.Orden, en.BackColor, en.ForeColor)

         Case TipoSP._U
            sql.EstadosOrdenesCalidad_U(en.IdEstadoCalidad, en.TipoEstadoCalidad, en.Orden, en.BackColor, en.ForeColor)

         Case TipoSP._D
            sql.EstadosOrdenesCalidad_D(en.IdEstadoCalidad)

      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.EstadoOrdenCalidad, dr As DataRow)
      With o
         .IdEstadoCalidad = dr.Field(Of String)(Entidades.EstadoOrdenCalidad.Columnas.IdEstadoCalidad.ToString())
         .TipoEstadoCalidad = dr.Field(Of String)(Entidades.EstadoOrdenCalidad.Columnas.TipoEstadoCalidad.ToString()).StringToEnum(Entidades.EstadoOrdenCalidad.TiposEstadosCalidad.PENDIENTE)
         .Orden = dr.Field(Of Integer)(Entidades.EstadoOrdenCalidad.Columnas.Orden.ToString())
         .BackColor = dr.Field(Of Integer?)(Entidades.EstadoOrdenCalidad.Columnas.BackColor.ToString())
         .ForeColor = dr.Field(Of Integer?)(Entidades.EstadoOrdenCalidad.Columnas.ForeColor.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.EstadoOrdenCalidad)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.EstadoOrdenCalidad)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.EstadoOrdenCalidad)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function Get1(idEstadoCalidad As String) As DataTable
      Return GetSql().EstadosOrdenesCalidad_G1(idEstadoCalidad)
   End Function
   Public Function GetUno(idEstadoCalidad As String) As Entidades.EstadoOrdenCalidad
      Return GetUno(idEstadoCalidad, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idEstadoCalidad As String, accion As AccionesSiNoExisteRegistro) As Entidades.EstadoOrdenCalidad
      Return CargaEntidad(Get1(idEstadoCalidad), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.EstadoOrdenCalidad(),
                          accion, Function() String.Format("No existe Estado de Calidad {0}", idEstadoCalidad))
   End Function

   Public Function GetTodos() As List(Of Entidades.EstadoOrdenCalidad)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.EstadoOrdenCalidad())
   End Function

   Public Function GetOrdenMaximo() As Integer
      Return GetSql().GetOrdenMaximo()
   End Function

   Public Function GetPorCodigo(codigo As String) As DataTable
      Return GetSql().EstadosOrdenesCalidad_G1(codigo)
   End Function
   Public Function GetPorNombre(Tipo As String) As DataTable
      Return GetSql().EstadosOrdenesCalidad_GT(Tipo)
   End Function
#End Region
End Class