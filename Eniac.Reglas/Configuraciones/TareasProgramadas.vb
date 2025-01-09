Option Strict On
Option Explicit On
Public Class TareasProgramadas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.TareaProgramada.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(entidad, TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(entidad, TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(entidad, TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.TareasProgramadas = New SqlServer.TareasProgramadas(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TareasProgramadas(Me.da).TareasProgramadas_GA()
   End Function
#End Region

#Region "Metodos Privados"


   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)

      Dim en As Entidades.TareaProgramada = DirectCast(entidad, Entidades.TareaProgramada)
      Dim sql As SqlServer.TareasProgramadas = New SqlServer.TareasProgramadas(Me.da)
      Dim rHorario As TareasProgramadasHorarios = New TareasProgramadasHorarios(da)

      Select Case tipo

         Case TipoSP._I
            sql.TareasProgramadas_I(en.IdTareaProgramada, en.IdFuncion, en.Usuario, en.Observacion, en.UltimaFechaEjecucion)
            rHorario.InsertaDesdeTareasProgramadas(en)

         Case TipoSP._U
            sql.TareasProgramadas_U(en.IdTareaProgramada, en.IdFuncion, en.Usuario, en.Observacion, en.UltimaFechaEjecucion)
            rHorario.BorrarDesdeTareasProgramadas(en)
            rHorario.InsertaDesdeTareasProgramadas(en)

         Case TipoSP._D
            rHorario.BorrarDesdeTareasProgramadas(en)
            sql.TareasProgramadas_D(en.IdTareaProgramada)

      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.TareaProgramada, dr As DataRow)
      With o
         .IdTareaProgramada = Integer.Parse(dr(Eniac.Entidades.TareaProgramada.Columnas.IdTareaProgramada.ToString()).ToString())
         .IdFuncion = dr(Eniac.Entidades.TareaProgramada.Columnas.IdFuncion.ToString()).ToString()
         .Usuario = dr(Eniac.Entidades.TareaProgramada.Columnas.Usuario.ToString()).ToString()
         .Observacion = dr(Eniac.Entidades.TareaProgramada.Columnas.Observacion.ToString()).ToString()
         If IsDate(dr(Eniac.Entidades.TareaProgramada.Columnas.UltimaFechaEjecucion.ToString())) Then
            .UltimaFechaEjecucion = DateTime.Parse(dr(Eniac.Entidades.TareaProgramada.Columnas.UltimaFechaEjecucion.ToString()).ToString())
         Else
            .UltimaFechaEjecucion = Nothing
         End If

         .Horarios = New TareasProgramadasHorarios(da).GetTodos(.IdTareaProgramada)

      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.TareaProgramada)
      Return CargaLista(Me.GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TareaProgramada())
   End Function

   Public Function GetUno(idTareaProgramada As Integer) As Entidades.TareaProgramada
      Return GetUno(idTareaProgramada, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idTareaProgramada As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.TareaProgramada
      Return CargaEntidad(New SqlServer.TareasProgramadas(Me.da).TareasProgramadas_G1(idTareaProgramada),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TareaProgramada(),
                          accion, Function() String.Format("La Tarea Programada {0} no existe. Por favor verifique.", idTareaProgramada))
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.TareasProgramadas(da).GetCodigoMaximo()
   End Function

#End Region

End Class