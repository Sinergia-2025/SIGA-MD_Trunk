Option Explicit On
Option Strict On
Public Class DepositosCuentasBancos
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.DepositosCuentasBancos.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.DepositosCuentasBancos, tipo As TipoSP)
      Dim sql As SqlServer.DepositosCuentasBancos = New SqlServer.DepositosCuentasBancos(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.DepositosCuentasBancos_I(en)
         Case TipoSP._U
            sql.DepositosCuentasBancos_U(en)
         Case TipoSP._D
            sql.DepositosCuentasBancos_D(en)
      End Select
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.DepositosCuentasBancos)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.DepositosCuentasBancos.Columnas.IdSucursal.ToString())
         .NumeroDeposito = dr.Field(Of Long)(Entidades.DepositosCuentasBancos.Columnas.NumeroDeposito.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.DepositosCuentasBancos.Columnas.IdTipoComprobante.ToString())
         .IdCuentaBanco = dr.Field(Of Integer)(Entidades.DepositosCuentasBancos.Columnas.IdCuentaBanco.ToString())
         .IdTipoCuenta = dr.Field(Of String)(Entidades.DepositosCuentasBancos.Columnas.IdTipoCuenta.ToString())
         .Importe = dr.Field(Of Decimal)(Entidades.DepositosCuentasBancos.Columnas.Importe.ToString())
         .Observacion = dr.Field(Of String)(Entidades.DepositosCuentasBancos.Columnas.Observacion.ToString())
         .NombreCuentaBanco = dr.Field(Of String)(Entidades.CuentaBanco.Columnas.NombreCuentaBanco.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub _Inserta(en As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(en, Entidades.DepositosCuentasBancos), TipoSP._I)
   End Sub
   Public Sub _Actualiza(en As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(en, Entidades.DepositosCuentasBancos), TipoSP._U)
   End Sub
   Public Sub _Borra(en As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(en, Entidades.DepositosCuentasBancos), TipoSP._D)
   End Sub
   Public Function GetTodas(idSucursal As Integer?,
                            numeroDeposito As Long?,
                            idTipoComprobante As String,
                            idCuentaBanco As Integer?) As List(Of Entidades.DepositosCuentasBancos)
      Return CargaLista(Me.GetAll(idSucursal, numeroDeposito, idTipoComprobante, idCuentaBanco),
                       Sub(o, dr) CargarUno(dr, o), Function() New Entidades.DepositosCuentasBancos())
   End Function

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(en As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(en, Entidades.DepositosCuentasBancos), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(en As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(en, Entidades.DepositosCuentasBancos), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(en As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(en, Entidades.DepositosCuentasBancos), TipoSP._D))
   End Sub

   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetAll(idSucursal:=Nothing, numeroDeposito:=Nothing, idTipoComprobante:=Nothing, idCuentaBanco:=Nothing)
   End Function

   Public Overloads Function GetAll(idSucursal As Integer?,
                                    numeroDeposito As Long?,
                                    idTipoComprobante As String,
                                    idCuentaBanco As Integer?) As DataTable
      Dim sql As SqlServer.DepositosCuentasBancos = New SqlServer.DepositosCuentasBancos(Me.da)
      Return sql.DepositosCuentasBancos_GA(idSucursal,
                                           numeroDeposito,
                                           idTipoComprobante,
                                           idCuentaBanco)
   End Function

   Public Sub BorrarTodas(idSucursal As Integer, numeroDeposito As Long, idTipoComprobante As String)
      Dim sql As SqlServer.DepositosCuentasBancos = New SqlServer.DepositosCuentasBancos(Me.da)
      sql.BorrarTodas(idSucursal, numeroDeposito, idTipoComprobante)
   End Sub

#End Region
End Class