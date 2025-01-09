Public Class CuentasCorrientesProvTransferencias
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.CuentaCorrienteProvTransferencia.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaCorrienteProvTransferencia), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaCorrienteProvTransferencia), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaCorrienteProvTransferencia), TipoSP._D))
   End Sub

   Public Sub _Inserta(entidad As Entidades.CuentaCorrienteProvTransferencia)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualiza(entidad As Entidades.CuentaCorrienteProvTransferencia)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.CuentaCorrienteProvTransferencia)
      EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CuentaCorrienteProv)
      _Borrar(New Entidades.CuentaCorrienteProvTransferencia() With {
                  .IdSucursal = entidad.IdSucursal,
                  .IdTipoComprobante = entidad.TipoComprobante.IdTipoComprobante,
                  .Letra = entidad.Letra,
                  .CentroEmisor = entidad.CentroEmisor,
                  .NumeroComprobante = entidad.NumeroComprobante,
                  .IdProveedor = entidad.Proveedor.IdProveedor
             })
   End Sub

   'Public Overrides Function Buscar( entidad As Eniac.Entidades.Buscar) As DataTable

   'End Function

   Public Overrides Function GetAll() As DataTable
      Dim sql = New SqlServer.CuentasCorrientesProvTransferencias(da)
      Return sql.CuentasCorrientesProvTransferencias_GA()
   End Function

#End Region

#Region "Métodos Públicos"

   Public Function GetUno(idSucursal As Integer, idproveedor As Long, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, orden As Integer) As Entidades.CuentaCorrienteProvTransferencia
      Dim sCuentasCorrientesProvTransferencias As SqlServer.CuentasCorrientesProvTransferencias = New SqlServer.CuentasCorrientesProvTransferencias(da)
      Return CargaEntidad(sCuentasCorrientesProvTransferencias.CuentasCorrientesProvTransferencias_G1(idSucursal, idproveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CuentaCorrienteProvTransferencia(),
                    AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No existen transferencias con PK: {0} {1} {2} {3} {4} {5}", idSucursal, idproveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante))
      Return Nothing
   End Function

   '# Get Todas las transferencias de un registro de CuentaCorriente
   Public Function GetTodos(idSucursal As Integer, idProveedor As Long, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As List(Of Entidades.CuentaCorrienteProvTransferencia)
      '# Paso ORDEN = 0 para traer todas las transferencias del vinculadas al mismo registro de la cuenta corriente
      Return CargaLista(New SqlServer.CuentasCorrientesProvTransferencias(da).CuentasCorrientesProvTransferencias_G1(idSucursal, idProveedor, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden:=0),
                        Sub(o, dr) Me.CargarUno(o, dr),
                        Function() New Entidades.CuentaCorrienteProvTransferencia)
   End Function

   '# Actualización de Cuenta Bancaria
   Public Sub ActualizarCuentaBancaria(nuevoIdCuentaBancaria As Integer, pago As Entidades.CuentaCorrienteProv)
      Dim sql = New SqlServer.CuentasCorrientesProvTransferencias(da)
      sql.ActualizarCuentaBancaria(nuevoIdCuentaBancaria, pago)
   End Sub

#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.CuentaCorrienteProvTransferencia, tipo As TipoSP)
      Dim sCuentasCorrientesProvTransferencias = New SqlServer.CuentasCorrientesProvTransferencias(da)
      Select Case tipo
         Case TipoSP._I
            sCuentasCorrientesProvTransferencias.CuentasCorrientesProvTransferencias_I(en.IdSucursal, en.IdProveedor, en.IdTipoComprobante,
                                                                               en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                                                               en.Orden, en.Importe, en.IdCuentaBancaria,
                                                                               en.IdSucursalLibroBanco, en.IdCuentaBancariaLibroBanco,
                                                                               en.NumeroMovimientoLibroBanco)
         Case TipoSP._U
            sCuentasCorrientesProvTransferencias.CuentasCorrientesProvTransferencias_U(en.IdSucursal, en.IdProveedor, en.IdTipoComprobante,
                                                                               en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                                                               en.Orden, en.Importe, en.IdCuentaBancaria)
         Case TipoSP._D
            sCuentasCorrientesProvTransferencias.CuentasCorrientesProvTransferencias_D(en.IdSucursal, en.IdProveedor, en.IdTipoComprobante, en.Letra,
                                                                               en.CentroEmisor, en.NumeroComprobante, en.Orden)
      End Select
   End Sub

   Private Sub CargarUno(eCuentaCorrienteProvTransferencia As Entidades.CuentaCorrienteProvTransferencia, dr As DataRow)
      With eCuentaCorrienteProvTransferencia
         .IdSucursal = dr.Field(Of Integer)(Entidades.CuentaCorrienteProvTransferencia.Columnas.IdSucursal.ToString())
         .IdProveedor = dr.Field(Of Long)(Entidades.CuentaCorrienteProvTransferencia.Columnas.IdProveedor.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.CuentaCorrienteProvTransferencia.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.CuentaCorrienteProvTransferencia.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.CuentaCorrienteProvTransferencia.Columnas.CentroEmisor.ToString())
         .NumeroComprobante = dr.Field(Of Long)(Entidades.CuentaCorrienteProvTransferencia.Columnas.NumeroComprobante.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.CuentaCorrienteProvTransferencia.Columnas.Orden.ToString())
         .Importe = dr.Field(Of Decimal)(Entidades.CuentaCorrienteProvTransferencia.Columnas.Importe.ToString())
         .IdCuentaBancaria = dr.Field(Of Integer)(Entidades.CuentaCorrienteProvTransferencia.Columnas.IdCuentaBancaria.ToString())
         .NombreCuenta = dr.Field(Of String)("NombreCuenta")
         .IdSucursalLibroBanco = dr.Field(Of Integer?)(Entidades.CuentaCorrienteProvTransferencia.Columnas.IdSucursalLibroBanco.ToString())
         .IdCuentaBancariaLibroBanco = dr.Field(Of Integer?)(Entidades.CuentaCorrienteProvTransferencia.Columnas.IdCuentaBancariaLibroBanco.ToString())
         .NumeroMovimientoLibroBanco = dr.Field(Of Integer?)(Entidades.CuentaCorrienteProvTransferencia.Columnas.NumeroMovimientoLibroBanco.ToString())
      End With
   End Sub

#End Region

End Class