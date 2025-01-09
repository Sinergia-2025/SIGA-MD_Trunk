Public Class Naves
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Eniac.Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "Naves"
      da = accesoDatos
   End Sub

#End Region

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Nave), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Nave), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Nave), TipoSP._D))
   End Sub
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Naves(da).Naves_GA()
   End Function


   Private Sub EjecutaSP(en As Entidades.Nave, tipo As TipoSP)
      Dim sql = New SqlServer.Naves(da)
      Select Case tipo
         Case TipoSP._I
            sql.Naves_I(en.IdNave, en.NombreNave, en.NombrePC,
                           en.EnMantenimiento, en.LimiteDeKilos, en.IdTipoNave)
         Case TipoSP._U
            sql.Naves_U(en.IdNave, en.NombreNave, en.NombrePC,
                           en.EnMantenimiento, en.LimiteDeKilos, en.IdTipoNave)
         Case TipoSP._D
            sql.Naves_D(en.IdNave)
      End Select
   End Sub
   Private Sub CargarUno(o As Entidades.Nave, dr As DataRow)
      With o
         .IdNave = dr.Field(Of Short)(Entidades.Nave.Columnas.IdNave.ToString())
         .NombreNave = dr.Field(Of String)(Entidades.Nave.Columnas.NombreNave.ToString())
         .NombrePC = dr.Field(Of String)(Entidades.Nave.Columnas.NombrePC.ToString())
         .LimiteDeKilos = dr.Field(Of Integer)(Entidades.Nave.Columnas.LimiteDeKilos.ToString())
         .EnMantenimiento = dr.Field(Of Boolean)(Entidades.Nave.Columnas.EnMantenimiento.ToString())
         .IdTipoNave = dr.Field(Of Short)(Entidades.Nave.Columnas.IdTipoNave.ToString())
         .TipoNave = New TiposNaves(da).GetUno(.IdTipoNave)
      End With
   End Sub


   Public Function GetUno(idNave As Integer) As Entidades.Nave
      Return GetUno(idNave, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idNave As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Nave
      Return CargaEntidad(New SqlServer.Naves(da).Naves_G1(idNave),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Nave(),
                          accion, String.Format("No existe Nave con id {0}", idNave))
   End Function
   Public Function GetTodas() As List(Of Entidades.Nave)
      If Not New Generales().ExisteTabla("Naves") Then
         Return New List(Of Entidades.Nave)
      End If

      Return CargaLista(New SqlServer.Naves(da).Naves_GA(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Nave())
   End Function

   Public Function GetParaMovil() As DataTable
      If Not New Generales().ExisteTabla("Naves") Then
         Return Nothing
      End If

      Return New SqlServer.Naves(da).GetParaMovil()
   End Function
   Public Function GetHabilitadas(nombrePC As String) As System.Data.DataTable
      Return New SqlServer.Naves(da).Naves_GHabilitadas(nombrePC)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Naves(da).GetCodigoMaximo()
   End Function


End Class