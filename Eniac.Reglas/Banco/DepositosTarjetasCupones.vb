Option Explicit On
Option Strict On
Public Class DepositosTarjetasCupones
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.DepositosTarjetasCupones.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.DepositosTarjetasCupones, tipo As TipoSP)
      Dim sql As SqlServer.DepositosTarjetasCupones = New SqlServer.DepositosTarjetasCupones(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.DepositosTarjetasCupones_I(en)
         Case TipoSP._U
            sql.DepositosTarjetasCupones_U(en)
         Case TipoSP._D
            sql.DepositosTarjetasCupones_D(en)
      End Select
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.DepositosTarjetasCupones)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.DepositosTarjetasCupones.Columnas.IdSucursal.ToString())
         .NumeroDeposito = dr.Field(Of Long)(Entidades.DepositosTarjetasCupones.Columnas.NumeroDeposito.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.DepositosTarjetasCupones.Columnas.IdTipoComprobante.ToString())
         .IdTarjetaCupon = dr.Field(Of Integer)(Entidades.DepositosTarjetasCupones.Columnas.IdTarjetaCupon.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub _Inserta(en As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(en, Entidades.DepositosTarjetasCupones), TipoSP._I)
   End Sub
   Public Sub _Actualiza(en As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(en, Entidades.DepositosTarjetasCupones), TipoSP._U)
   End Sub
   Public Sub _Borra(en As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(en, Entidades.DepositosTarjetasCupones), TipoSP._D)
   End Sub
   Public Function GetTodas(idSucursal As Integer?,
                            numeroDeposito As Long?,
                            idTipoComprobante As String,
                            IdTarjetaCupon As Integer?) As List(Of Entidades.DepositosTarjetasCupones)
      Return CargaLista(Me.GetAll(idSucursal, numeroDeposito, idTipoComprobante, IdTarjetaCupon),
                       Sub(o, dr) CargarUno(dr, o), Function() New Entidades.DepositosTarjetasCupones())
   End Function

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(en As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(en, Entidades.DepositosTarjetasCupones), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(en As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(en, Entidades.DepositosTarjetasCupones), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(en As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(en, Entidades.DepositosTarjetasCupones), TipoSP._D))
   End Sub

   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetAll(idSucursal:=Nothing, numeroDeposito:=Nothing, idTipoComprobante:=Nothing, IdTarjetaCupon:=Nothing)
   End Function

   Public Overloads Function GetAll(idSucursal As Integer?,
                                    numeroDeposito As Long?,
                                    idTipoComprobante As String,
                                    IdTarjetaCupon As Integer?) As DataTable
      Dim sql As SqlServer.DepositosTarjetasCupones = New SqlServer.DepositosTarjetasCupones(Me.da)
      Return sql.DepositosTarjetasCupones_GA(idSucursal,
                                           numeroDeposito,
                                           idTipoComprobante,
                                           IdTarjetaCupon)
   End Function

   Public Sub BorrarTodos(idSucursal As Integer, numeroDeposito As Long, idTipoComprobante As String)
      Dim sql As SqlServer.DepositosTarjetasCupones = New SqlServer.DepositosTarjetasCupones(Me.da)
      sql.BorrarTodos(idSucursal, numeroDeposito, idTipoComprobante)
   End Sub
#End Region
End Class
