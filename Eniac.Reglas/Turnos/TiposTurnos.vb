Public Class TiposTurnos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TiposTurnos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.TiposTurnos(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposTurnos(Me.da).TiposTurnos_GA(idTipoCalendario:=0)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)
      Try
         Dim en As Entidades.TipoTurno = DirectCast(entidad, Entidades.TipoTurno)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.TiposTurnos = New SqlServer.TiposTurnos(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.TiposTurnos_I(en.IdTipoTurno, en.NombreTipoTurno, en.IdTipoCalendario)
            Case TipoSP._U
               sqlC.TiposTurnos_U(en.IdTipoTurno, en.NombreTipoTurno, en.IdTipoCalendario)
            Case TipoSP._D
               sqlC.TiposTurnos_D(en.IdTipoTurno)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(o As Entidades.TipoTurno, dr As DataRow)
      With o
         .IdTipoTurno = dr.Field(Of String)(Entidades.TipoTurno.Columnas.IdTipoTurno.ToString())
         .NombreTipoTurno = dr.Field(Of String)(Entidades.TipoTurno.Columnas.NombreTipoTurno.ToString())
         .IdTipoCalendario = dr.Field(Of Short)(Entidades.TipoTurno.Columnas.IdTipoCalendario.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idTipoTurno As String) As Entidades.TipoTurno
      Return GetUno(idTipoTurno, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idTipoTurno As String, accion As AccionesSiNoExisteRegistro) As Entidades.TipoTurno
      Return CargaEntidad(New SqlServer.TiposTurnos(Me.da).TiposTurnos_G1(idTipoTurno),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoTurno(),
                          accion, Function() String.Format("No existe un Tipo de Turno con Código {0}", idTipoTurno))
   End Function

   Public Function GetTodos(idTipoCalendario As Short) As List(Of Entidades.TipoTurno)
      Return CargaLista(New SqlServer.TiposTurnos(Me.da).TiposTurnos_GA(idTipoCalendario),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoTurno())
   End Function

   Public Function GetCombo() As List(Of Entidades.TipoTurno)
      Return CargaLista(New SqlServer.TiposTurnos(Me.da).TiposTurnos_GCombo(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoTurno())
   End Function

   Public Function GetxDescripcion(nombreTipoTurno As String) As Entidades.TipoTurno
      Return GetxDescripcion(nombreTipoTurno, AccionesSiNoExisteRegistro.Nulo)
   End Function
   Public Function GetxDescripcion(nombreTipoTurno As String, accion As AccionesSiNoExisteRegistro) As Entidades.TipoTurno
      Return CargaEntidad(New SqlServer.TiposTurnos(Me.da).TiposTurnos_GxNombre(nombreTipoTurno),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoTurno(),
                          accion, Function() String.Format("No existe un Tipo de Turno con Nombre '{0}'", nombreTipoTurno))
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.TiposTurnos(Me.da).GetCodigoMaximo()
   End Function

#End Region
End Class