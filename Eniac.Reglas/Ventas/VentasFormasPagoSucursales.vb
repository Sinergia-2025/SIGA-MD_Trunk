Option Explicit On
Option Strict On
Public Class VentasFormasPagoSucursales
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.VentasFormasPagoSucursales.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.VentasFormasPagoSucursales, tipo As TipoSP)

      Dim sql As SqlServer.VentasFormasPagoSucursales = New SqlServer.VentasFormasPagoSucursales(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.VentasFormasPagoSucursales_I(en.IdSucursal,
                                             en.IdFormasPago)
         Case TipoSP._U
            sql.VentasFormasPagoSucursales_U(en.IdSucursal,
                                             en.IdFormasPago)
         Case TipoSP._D
            sql.VentasFormasPagoSucursales_D(en.IdSucursal,
                                             en.IdFormasPago)
      End Select
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.VentasFormasPagoSucursales)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.VentasFormasPagoSucursales.Columnas.IdSucursal.ToString())
         .IdFormasPago = dr.Field(Of Integer)(Entidades.VentasFormasPagoSucursales.Columnas.IdFormasPago.ToString())
         .DescripcionFormasPago = dr.Field(Of String)(Entidades.VentaFormaPago.Columnas.DescripcionFormasPago.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub _Inserta(en As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(en, Entidades.VentasFormasPagoSucursales), TipoSP._I)
   End Sub
   Public Sub _Actualiza(en As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(en, Entidades.VentasFormasPagoSucursales), TipoSP._U)
   End Sub
   Public Sub _Borra(en As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(en, Entidades.VentasFormasPagoSucursales), TipoSP._D)
   End Sub
   Public Function GetTodas(idSucursal As Integer?) As List(Of Entidades.VentasFormasPagoSucursales)
      Return CargaLista(Me.GetAll(idSucursal),
                       Sub(o, dr) CargarUno(dr, o), Function() New Entidades.VentasFormasPagoSucursales())
   End Function
   Public Sub BorrarTodas(valor As Integer, esIdFormaPago As Boolean)
      Dim sql As SqlServer.VentasFormasPagoSucursales = New SqlServer.VentasFormasPagoSucursales(da)
      sql.BorrarTodas(valor, esIdFormaPago)
   End Sub
   Public Sub VincularTodas(idFormasPago As Integer)
      Dim sql As SqlServer.VentasFormasPagoSucursales = New SqlServer.VentasFormasPagoSucursales(da)
      sql.VincularTodas(idFormasPago)
   End Sub


#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(en As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(en, Entidades.VentasFormasPagoSucursales), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(en As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(en, Entidades.VentasFormasPagoSucursales), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(en As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(en, Entidades.VentasFormasPagoSucursales), TipoSP._D))
   End Sub

   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetAll(idSucursal:=Nothing)
   End Function

   Public Overloads Function GetAll(idSucursal As Integer?) As DataTable
      Dim sql As SqlServer.VentasFormasPagoSucursales = New SqlServer.VentasFormasPagoSucursales(Me.da)
      Return sql.VentasFormasPagoSucursales_GA(idSucursal)
   End Function

#End Region
End Class
