Public Class TiposCalendarios
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.TipoCalendario.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConConexion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TipoCalendario), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConConexion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TipoCalendario), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConConexion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TipoCalendario), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.TiposCalendarios = New SqlServer.TiposCalendarios(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposCalendarios(Me.da).TiposCalendarios_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.TipoCalendario, tipo As TipoSP)
      Dim sqlC As SqlServer.TiposCalendarios = New SqlServer.TiposCalendarios(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.TiposCalendarios_I(en.IdTipoCalendario, en.NombreTipoCalendario)
         Case TipoSP._U
            sqlC.TiposCalendarios_U(en.IdTipoCalendario, en.NombreTipoCalendario)
         Case TipoSP._D
            sqlC.TiposCalendarios_D(en.IdTipoCalendario)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.TipoCalendario, dr As DataRow)
      With o
         .IdTipoCalendario = dr.Field(Of Short)(Entidades.TipoCalendario.Columnas.IdTipoCalendario.ToString())
         .NombreTipoCalendario = dr.Field(Of String)(Entidades.TipoCalendario.Columnas.NombreTipoCalendario.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idTipoCalendario As Short) As Entidades.TipoCalendario
      Return GetUno(idTipoCalendario, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idTipoCalendario As Short, accion As AccionesSiNoExisteRegistro) As Entidades.TipoCalendario
      Return CargaEntidad(New SqlServer.TiposCalendarios(Me.da).TiposCalendarios_G1(idTipoCalendario),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.TipoCalendario(),
                          accion, Function() String.Format("No existe Tipo Calendario con Id {0}", idTipoCalendario))
   End Function

   Public Function GetTodos() As List(Of Entidades.TipoCalendario)
      Return CargaLista(New SqlServer.TiposCalendarios(Me.da).TiposCalendarios_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.TipoCalendario())
   End Function

   Public Function GetCodigoMaximo() As Short
      Return New SqlServer.TiposCalendarios(Me.da).GetCodigoMaximo()
   End Function

#End Region

End Class