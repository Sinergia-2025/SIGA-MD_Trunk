Public Class CRMEstadosCiclosPlanificacion
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CRMEstadoCicloPlanificacion.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CRMEstadoCicloPlanificacion)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CRMEstadoCicloPlanificacion)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CRMEstadoCicloPlanificacion)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetSql().CRMEstadosCiclosPlanificacion_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.CRMEstadosCiclosPlanificacion
      Return New SqlServer.CRMEstadosCiclosPlanificacion(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.CRMEstadoCicloPlanificacion, tipo As TipoSP)
      Dim sql = GetSql()
      Select Case tipo
         Case TipoSP._I
            sql.CRMEstadosCiclosPlanificacion_I(en.IdEstadoCicloPlanificacion, en.TipoEstadoCicloPlanificacion, en.Orden, en.PorDefecto, en.BackColor, en.ForeColor)

         Case TipoSP._U
            sql.CRMEstadosCiclosPlanificacion_U(en.IdEstadoCicloPlanificacion, en.TipoEstadoCicloPlanificacion, en.Orden, en.PorDefecto, en.BackColor, en.ForeColor)

         Case TipoSP._D
            sql.CRMEstadosCiclosPlanificacion_D(en.IdEstadoCicloPlanificacion)

      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CRMEstadoCicloPlanificacion, dr As DataRow)
      With o
         .IdEstadoCicloPlanificacion = dr.Field(Of String)(Entidades.CRMEstadoCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString())
         .TipoEstadoCicloPlanificacion = dr.Field(Of String)(Entidades.CRMEstadoCicloPlanificacion.Columnas.TipoEstadoCicloPlanificacion.ToString()).StringToEnum(Entidades.CRMEstadoCicloPlanificacion.TiposEstadosCicloPlanificacion.PENDIENTE)
         .Orden = dr.Field(Of Integer)(Entidades.CRMEstadoCicloPlanificacion.Columnas.Orden.ToString())
         .PorDefecto = dr.Field(Of Boolean)(Entidades.CRMEstadoCicloPlanificacion.Columnas.PorDefecto.ToString())
         .BackColor = dr.Field(Of Integer?)(Entidades.CRMEstadoCicloPlanificacion.Columnas.BackColor.ToString())
         .ForeColor = dr.Field(Of Integer?)(Entidades.CRMEstadoCicloPlanificacion.Columnas.ForeColor.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CRMEstadoCicloPlanificacion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CRMEstadoCicloPlanificacion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CRMEstadoCicloPlanificacion)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overloads Function GetAll(tipoEstadoCicloPlanificacion As Entidades.CRMEstadoCicloPlanificacion.TiposEstadosCicloPlanificacion) As DataTable
      Return GetSql().CRMEstadosCiclosPlanificacion_GA(tipoEstadoCicloPlanificacion)
   End Function
   Public Function Get1(idEstadoCicloPlanificacion As String) As DataTable
      Return GetSql().CRMEstadosCiclosPlanificacion_G1(idEstadoCicloPlanificacion)
   End Function
   Public Function Get1PorDefecto() As DataTable
      Return GetSql().CRMEstadosCiclosPlanificacion_GA(porDefecto:=True)
   End Function

   Public Function GetUno(idEstadoCicloPlanificacion As String) As Entidades.CRMEstadoCicloPlanificacion
      Return GetUno(idEstadoCicloPlanificacion, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idEstadoCicloPlanificacion As String, accion As AccionesSiNoExisteRegistro) As Entidades.CRMEstadoCicloPlanificacion
      Return CargaEntidad(Get1(idEstadoCicloPlanificacion), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMEstadoCicloPlanificacion(),
                          accion, Function() String.Format("No existe Estado {0}", idEstadoCicloPlanificacion))
   End Function

   Public Function GetUnoPorDefecto() As Entidades.CRMEstadoCicloPlanificacion
      Return GetUnoPorDefecto(AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUnoPorDefecto(accion As AccionesSiNoExisteRegistro) As Entidades.CRMEstadoCicloPlanificacion
      Return CargaEntidad(Get1PorDefecto(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMEstadoCicloPlanificacion(),
                          accion, Function() String.Format("No existe Estado por defecto"))
   End Function

   Public Function GetTodos() As List(Of Entidades.CRMEstadoCicloPlanificacion)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMEstadoCicloPlanificacion())
   End Function
   Public Function GetTodos(tipoEstadoCicloPlanificacion As Entidades.CRMEstadoCicloPlanificacion.TiposEstadosCicloPlanificacion) As List(Of Entidades.CRMEstadoCicloPlanificacion)
      Return CargaLista(GetAll(tipoEstadoCicloPlanificacion), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMEstadoCicloPlanificacion())
   End Function

   Public Function GetOrdenMaximo() As Integer
      Return GetSql().GetOrdenMaximo()
   End Function

#End Region
End Class