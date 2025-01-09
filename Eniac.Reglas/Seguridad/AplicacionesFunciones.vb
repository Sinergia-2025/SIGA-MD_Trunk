Option Strict On
Option Explicit On
Option Infer On
Public Class AplicacionesFunciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.AplicacionFuncion.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.AplicacionFuncion)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.AplicacionFuncion)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.AplicacionFuncion)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.AplicacionesFunciones = New SqlServer.AplicacionesFunciones(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.AplicacionesFunciones(Me.da).AplicacionesFunciones_GA()
   End Function

   Public Overloads Function GetAll(idAplicacion As String) As System.Data.DataTable
      Return New SqlServer.AplicacionesFunciones(Me.da).AplicacionesFunciones_GA(idAplicacion)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.AplicacionFuncion, tipo As TipoSP)
      Dim sqlC As SqlServer.AplicacionesFunciones = New SqlServer.AplicacionesFunciones(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.AplicacionesFunciones_I(en.IdAplicacion, en.IdFuncion, en.NombreFuncion, en.IdFuncionPadre)
         Case TipoSP._U
            sqlC.AplicacionesFunciones_U(en.IdAplicacion, en.IdFuncion, en.NombreFuncion, en.IdFuncionPadre)
         Case TipoSP._D
            sqlC.AplicacionesFunciones_D(en.IdAplicacion, en.IdFuncion)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.AplicacionFuncion, dr As DataRow)
      With o
         .IdAplicacion = dr.Field(Of String)(Entidades.AplicacionFuncion.Columnas.IdAplicacion.ToString())
         .IdFuncion = dr.Field(Of String)(Entidades.AplicacionFuncion.Columnas.IdFuncion.ToString())
         .NombreFuncion = dr.Field(Of String)(Entidades.AplicacionFuncion.Columnas.NombreFuncion.ToString())
         .IdFuncionPadre = dr.Field(Of String)(Entidades.AplicacionFuncion.Columnas.IdFuncionPadre.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.AplicacionFuncion)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.AplicacionFuncion)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.AplicacionFuncion)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetUno(idAplicacion As String, idFuncion As String) As Entidades.AplicacionFuncion
      Return GetUno(idAplicacion, idFuncion, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idAplicacion As String, idFuncion As String, accion As AccionesSiNoExisteRegistro) As Entidades.AplicacionFuncion
      Return CargaEntidad(New SqlServer.AplicacionesFunciones(Me.da).AplicacionesFunciones_G1(idAplicacion, idFuncion),
                          Sub(o, dr) CargarUno(o, dr),
                          Function() New Entidades.AplicacionFuncion(),
                          accion, Function() String.Format("No existe Función de IdAplicacion: {0} y IdFuncion: {1}", idAplicacion, idFuncion))
   End Function

   Public Function GetTodos() As List(Of Entidades.AplicacionFuncion)
      Return GetTodos(idAplicacion:=String.Empty)
   End Function
   Public Function GetTodos(idAplicacion As String) As List(Of Entidades.AplicacionFuncion)
      Return CargaLista(Me.GetAll(idAplicacion),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.AplicacionFuncion), dr),
                        Function() New Entidades.AplicacionFuncion())
   End Function

   Public Function GetFiltradoPorCodigo(idAplicacion As String, idFuncion As String) As DataTable
      Dim sql = New SqlServer.AplicacionesFunciones(da)
      Dim dt = sql.AplicacionesFunciones_G(idAplicacion, idFuncion, nombreFuncion:=String.Empty, idExacto:=True, nombreExacto:=False)
      If dt.Rows.Count = 0 Then
         dt = sql.AplicacionesFunciones_G(idAplicacion, idFuncion, nombreFuncion:=String.Empty, idExacto:=False, nombreExacto:=False)
      End If
      Return dt
   End Function
   Public Function GetFiltradoPorNombre(idAplicacion As String, nombreFuncion As String) As DataTable
      Return New SqlServer.AplicacionesFunciones(da).AplicacionesFunciones_G(idAplicacion, idFuncion:=String.Empty, nombreFuncion:=nombreFuncion, idExacto:=False, nombreExacto:=False)
   End Function

#End Region

End Class