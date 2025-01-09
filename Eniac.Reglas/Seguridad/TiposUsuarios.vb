Public Class TiposUsuarios
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.TipoUsuario.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConConexion(Sub() Me.EjecutaSP(entidad, TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConConexion(Sub() Me.EjecutaSP(entidad, TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConConexion(Sub() Me.EjecutaSP(entidad, TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.TiposUsuarios = New SqlServer.TiposUsuarios(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposUsuarios(Me.da).TiposUsuarios_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)
      Dim en As Entidades.TipoUsuario = DirectCast(entidad, Entidades.TipoUsuario)

      Dim sqlC As SqlServer.TiposUsuarios = New SqlServer.TiposUsuarios(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.TiposUsuarios_I(en.IdTipoUsuario, en.NombreTipoUsuario, en.EsDeProceso)
         Case TipoSP._U
            sqlC.TiposUsuarios_U(en.IdTipoUsuario, en.NombreTipoUsuario, en.EsDeProceso)
         Case TipoSP._D
            sqlC.TiposUsuarios_D(en.IdTipoUsuario)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.TipoUsuario, dr As DataRow)
      With o
         .IdTipoUsuario = dr.Field(Of Integer)(Entidades.TipoUsuario.Columnas.IdTipoUsuario.ToString())
         .NombreTipoUsuario = dr.Field(Of String)(Entidades.TipoUsuario.Columnas.NombreTipoUsuario.ToString())
         .EsDeProceso = dr.Field(Of Boolean)(Entidades.TipoUsuario.Columnas.EsDeProceso.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idTipoUsuario As Integer) As Entidades.TipoUsuario
      Return GetUno(idTipoUsuario, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idTipoUsuario As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.TipoUsuario
      Return CargaEntidad(New SqlServer.TiposUsuarios(Me.da).TiposUsuarios_G1(idTipoUsuario),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoUsuario(),
                          accion, Function() String.Format("No se encontró Tipo de Usuario con Id = {0}", idTipoUsuario))
   End Function

   Public Function GetTodos() As List(Of Entidades.TipoUsuario)
      Return CargaLista(Me.GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoUsuario())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.TiposUsuarios(Me.da).GetCodigoMaximo()
   End Function

#End Region

End Class