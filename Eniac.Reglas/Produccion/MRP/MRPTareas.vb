#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class MRPTareas
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.MRPTarea.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPTarea), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPTarea), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPTarea), TipoSP._D))
   End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.MRPTareas(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.MRPTareas(Me.da).Tareas_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MRPTarea, tipo As TipoSP)
      Dim sqlC = New SqlServer.MRPTareas(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.Tareas_I(en.IdTarea, en.CodigoTarea, en.Descripcion, en.IdCentroProductor, en.Activo)
         Case TipoSP._U
            sqlC.Tareas_U(en.IdTarea, en.CodigoTarea, en.Descripcion, en.IdCentroProductor, en.Activo)
         Case TipoSP._D
            sqlC.Tareas_D(en.IdTarea)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.MRPTarea, dr As DataRow)
      With o
         .IdTarea = dr.Field(Of Integer)(Entidades.MRPTarea.Columnas.IdTarea.ToString())
         .CodigoTarea = dr.Field(Of String)(Entidades.MRPTarea.Columnas.CodigoTarea.ToString())
         .Descripcion = dr.Field(Of String)(Entidades.MRPTarea.Columnas.Descripcion.ToString())
         .IdCentroProductor = dr.Field(Of Integer?)(Entidades.MRPTarea.Columnas.IdCentroProductor.ToString()).IfNull()
         .Activo = dr.Field(Of Boolean)(Entidades.MRPTarea.Columnas.Activo.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetFiltradoPorCodigo(CodigoTarea As String,
                                        Optional BusquedaParcial As Boolean = True) As DataTable
      Dim sql = New SqlServer.MRPTareas(da)
      Dim dt = sql.Tareas_G1_Codigo(CodigoTarea, codigoExacto:=True)
      If dt.Rows.Count = 0 And BusquedaParcial Then
         dt = sql.Tareas_G1_Codigo(CodigoTarea, codigoExacto:=False)
      End If
      Return dt
   End Function

   Public Function GetFiltradoPorNombre(nombreTarea As String, activos As Entidades.Publicos.SiNoTodos) As DataTable
      Return New SqlServer.MRPTareas(da).Tareas_GA_Nombre(nombreTarea, nombreExacto:=False, activos)
   End Function

   Public Function GetUno(idTarea As Integer) As Entidades.MRPTarea
      Return GetUno(idTarea, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idTarea As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.MRPTarea
      Return CargaEntidad(New SqlServer.MRPTareas(Me.da).Tareas_G1(idTarea),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MRPTarea(),
                          accion, Function() String.Format("No existe Tarea con Id: {0}", idTarea))
   End Function
   Public Function GetTodos() As List(Of Entidades.MRPTarea)
      Return CargaLista(New SqlServer.MRPTareas(Me.da).Tareas_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MRPTarea())
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.MRPTareas(Me.da).GetCodigoMaximo()
   End Function
   Public Function Existe(codigoTarea As String) As Boolean
      Return New SqlServer.MRPTareas(da).Existe(codigoTarea)
   End Function

#End Region

End Class
