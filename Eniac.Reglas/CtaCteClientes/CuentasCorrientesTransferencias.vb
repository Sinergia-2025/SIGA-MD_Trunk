Public Class CuentasCorrientesTransferencias
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.CuentaCorrienteTransferencia.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaCorrienteTransferencia), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaCorrienteTransferencia), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CuentaCorrienteTransferencia), TipoSP._D))
   End Sub

   Public Sub _Inserta(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.CuentaCorrienteTransferencia), TipoSP._I)
   End Sub

   Public Sub _Actualiza(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.CuentaCorrienteTransferencia), TipoSP._U)
   End Sub

   Public Sub _Borra(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.CuentaCorrienteTransferencia), TipoSP._D)
   End Sub

   'Public Overrides Function Buscar( entidad As Eniac.Entidades.Buscar) As DataTable

   'End Function

   Public Overrides Function GetAll() As DataTable
      Dim sql = New SqlServer.CuentasCorrientesTransferencias(da)
      Return sql.CuentasCorrientesTransferencias_GA()
   End Function

#End Region

#Region "Métodos Públicos"
   'Public Sub ActualizarPKLibrosBancos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, orden As Integer,
   '                                    idSucursalLibroBanco As Integer, idCuentaBancariaLibroBanco As Integer, numeroMovimientoLibroBanco As Integer)
   '   Dim sCCTransferencias As New SqlServer.CuentasCorrientesTransferencias(da)
   '   sCCTransferencias.ActualizarPKLibrosBancos(idSucursal,
   '                                              idTipoComprobante,
   '                                              letra,
   '                                              centroEmisor,
   '                                              numeroComprobante,
   '                                              orden,
   '                                              idSucursalLibroBanco,
   '                                              idCuentaBancariaLibroBanco,
   '                                              numeroMovimientoLibroBanco)
   'End Sub

   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, orden As Integer) As Entidades.CuentaCorrienteTransferencia
      Dim sCuentasCorrientesTransferencias As SqlServer.CuentasCorrientesTransferencias = New SqlServer.CuentasCorrientesTransferencias(da)
      Return CargaEntidad(sCuentasCorrientesTransferencias.CuentasCorrientesTransferencias_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CuentaCorrienteTransferencia(),
                    AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No existen transferencias con PK: {0} {1} {2} {3} {4}", idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante))
      Return Nothing
   End Function

   '# Get Todas las transferencias de un registro de CuentaCorriente
   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As List(Of Entidades.CuentaCorrienteTransferencia)
      '# Paso ORDEN = 0 para traer todas las transferencias del vinculadas al mismo registro de la cuenta corriente
      Return CargaLista(New SqlServer.CuentasCorrientesTransferencias(da).CuentasCorrientesTransferencias_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden:=0),
                        Sub(o, dr) Me.CargarUno(o, dr),
                        Function() New Entidades.CuentaCorrienteTransferencia)
   End Function

   '# Actualización de Cuenta Bancaria
   Public Sub ActualizarCuentaBancaria(nuevoIdCuentaBancaria As Integer, recibo As Entidades.CuentaCorriente)
      Dim sql = New SqlServer.CuentasCorrientesTransferencias(da)
      sql.ActualizarCuentaBancaria(nuevoIdCuentaBancaria, recibo)
   End Sub

#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.CuentaCorrienteTransferencia, tipo As TipoSP)
      Dim sCuentasCorrientesTransferencias = New SqlServer.CuentasCorrientesTransferencias(da)
      Select Case tipo
         Case TipoSP._I
            sCuentasCorrientesTransferencias.CuentasCorrientesTransferencias_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante, en.Orden, en.Importe, en.IdCuentaBancaria,
                                                                               en.IdSucursalLibroBanco, en.IdCuentaBancariaLibroBanco, en.NumeroMovimientoLibroBanco)
         Case TipoSP._U
            sCuentasCorrientesTransferencias.CuentasCorrientesTransferencias_U(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante, en.Orden, en.Importe, en.IdCuentaBancaria)
         Case TipoSP._D
            sCuentasCorrientesTransferencias.CuentasCorrientesTransferencias_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante, en.Orden)
      End Select
   End Sub

   Private Sub CargarUno(eCuentaCorrienteTransferencia As Entidades.CuentaCorrienteTransferencia, dr As DataRow)
      With eCuentaCorrienteTransferencia
         .IdSucursal = dr.Field(Of Integer)(Entidades.CuentaCorrienteTransferencia.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.CuentaCorrienteTransferencia.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.CuentaCorrienteTransferencia.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.CuentaCorrienteTransferencia.Columnas.CentroEmisor.ToString())
         .NumeroComprobante = dr.Field(Of Long)(Entidades.CuentaCorrienteTransferencia.Columnas.NumeroComprobante.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.CuentaCorrienteTransferencia.Columnas.Orden.ToString())
         .Importe = dr.Field(Of Decimal)(Entidades.CuentaCorrienteTransferencia.Columnas.Importe.ToString())
         .IdCuentaBancaria = dr.Field(Of Integer)(Entidades.CuentaCorrienteTransferencia.Columnas.IdCuentaBancaria.ToString())
         .NombreCuenta = dr.Field(Of String)("NombreCuenta")
         .IdSucursalLibroBanco = dr.Field(Of Integer?)(Entidades.CuentaCorrienteTransferencia.Columnas.IdSucursalLibroBanco.ToString())
         .IdCuentaBancariaLibroBanco = dr.Field(Of Integer?)(Entidades.CuentaCorrienteTransferencia.Columnas.IdCuentaBancariaLibroBanco.ToString())
         .NumeroMovimientoLibroBanco = dr.Field(Of Integer?)(Entidades.CuentaCorrienteTransferencia.Columnas.NumeroMovimientoLibroBanco.ToString())
      End With
   End Sub

#End Region

End Class