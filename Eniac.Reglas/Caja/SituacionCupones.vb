Public Class SituacionCupones
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.SituacionCupon.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.SituacionCupon), TipoSP._I))

   End Sub
   Public Overrides Sub Actualizar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.SituacionCupon), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.SituacionCupon), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.SituacionCupones = New SqlServer.SituacionCupones(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.SituacionCupones(Me.da).SituacionCupones_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.SituacionCupon, tipo As TipoSP)
      Dim sqlC As SqlServer.SituacionCupones = New SqlServer.SituacionCupones(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.SituacionCupones_I(en.IdSituacionCupon, en.NombreSituacionCupon, en.PorDefecto)
         Case TipoSP._U
            sqlC.SituacionCupones_U(en.IdSituacionCupon, en.NombreSituacionCupon, en.PorDefecto)
         Case TipoSP._D
            sqlC.SituacionCupones_D(en.IdSituacionCupon)
      End Select
   End Sub

   Private Sub CargarUno(e As Entidades.SituacionCupon, dr As DataRow)
      With e
         .IdSituacionCupon = dr.Field(Of Integer)(Entidades.SituacionCupon.Columnas.IdSituacionCupon.ToString())
         .NombreSituacionCupon = dr.Field(Of String)(Entidades.SituacionCupon.Columnas.NombreSituacionCupon.ToString())
         .PorDefecto = dr.Field(Of Boolean)(Entidades.SituacionCupon.Columnas.PorDefecto.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Function GetUno(idSituacionCupon As Integer) As Entidades.SituacionCupon
      Return GetUno(idSituacionCupon, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idSituacionCupon As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.SituacionCupon
      Return CargaEntidad(New SqlServer.SituacionCupones(Me.da).SituacionCupones_G1(idSituacionCupon),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.SituacionCupon(),
                          accion, Function() String.Format("No Existe Situacion de Cupon con Id: {0}"))
   End Function

   Public Function GetTodos() As List(Of Entidades.SituacionCupon)
      Return CargaLista(New SqlServer.SituacionCupones(Me.da).SituacionCupones_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.SituacionCupon())
   End Function

   Public Function GetPorDefecto() As Entidades.SituacionCupon
      Return GetPorDefecto(AccionesSiNoExisteRegistro.Excepcion)
   End Function

   Public Function GetPorDefecto(accion As AccionesSiNoExisteRegistro) As Entidades.SituacionCupon
      Return CargaEntidad(New SqlServer.SituacionCupones(Me.da).SituacionCupones_G_PorDfecto(),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.SituacionCupon(),
                          accion, Function() String.Format("No Existe Situacion de Cupon Por Defecto"))
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.SituacionCupones(Me.da).GetCodigoMaximo()
   End Function
#End Region
End Class
