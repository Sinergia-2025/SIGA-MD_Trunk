Public Class SituacionCheques
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.SituacionCheque.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.SituacionCheque), TipoSP._I))

   End Sub
   Public Overrides Sub Actualizar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.SituacionCheque), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.SituacionCheque), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.SituacionCheques = New SqlServer.SituacionCheques(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.SituacionCheques(Me.da).SituacionCheques_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.SituacionCheque, tipo As TipoSP)
      Dim sqlC As SqlServer.SituacionCheques = New SqlServer.SituacionCheques(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.SituacionCheques_I(en.IdSituacionCheque, en.NombreSituacionCheque, en.PorDefecto)
         Case TipoSP._U
            sqlC.SituacionCheques_U(en.IdSituacionCheque, en.NombreSituacionCheque, en.PorDefecto)
         Case TipoSP._D
            sqlC.SituacionCheques_D(en.IdSituacionCheque)
      End Select
   End Sub

   Private Sub CargarUno(e As Entidades.SituacionCheque, dr As DataRow)
      With e
         .IdSituacionCheque = dr.Field(Of Integer)(Entidades.SituacionCheque.Columnas.IdSituacionCheque.ToString())
         .NombreSituacionCheque = dr.Field(Of String)(Entidades.SituacionCheque.Columnas.NombreSituacionCheque.ToString())
         .PorDefecto = dr.Field(Of Boolean)(Entidades.SituacionCheque.Columnas.PorDefecto.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Function GetUno(idSituacionCheque As Integer) As Entidades.SituacionCheque
      Return GetUno(idSituacionCheque, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idSituacionCheque As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.SituacionCheque
      Return CargaEntidad(New SqlServer.SituacionCheques(Me.da).SituacionCheques_G1(idSituacionCheque),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.SituacionCheque(),
                          accion, Function() String.Format("No Existe Situacion de Cheque con Id: {0}"))
   End Function

   Public Function GetTodos() As List(Of Entidades.SituacionCheque)
      Return CargaLista(New SqlServer.SituacionCheques(Me.da).SituacionCheques_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.SituacionCheque())
   End Function

   Public Function GetPorDefecto() As Entidades.SituacionCheque
      Return GetPorDefecto(AccionesSiNoExisteRegistro.Excepcion)
   End Function

   Public Function GetPorDefecto(accion As AccionesSiNoExisteRegistro) As Entidades.SituacionCheque
      Return CargaEntidad(New SqlServer.SituacionCheques(Me.da).SituacionCheques_G_PorDfecto(),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.SituacionCheque(),
                          accion, Function() String.Format("No Existe Situacion de Cheque Por Defecto"))
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.SituacionCheques(Me.da).GetCodigoMaximo()
   End Function
#End Region
End Class