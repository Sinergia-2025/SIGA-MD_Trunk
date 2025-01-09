Public Class ComprasTransferencias
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CompraTransferencia.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CompraTransferencia)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CompraTransferencia)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CompraTransferencia)))
   End Sub
#End Region

#Region "Metodos Privados"
   Friend Sub EjecutaSP(ent As Entidades.CompraTransferencia, tipo As TipoSP)
      Dim sql = New SqlServer.ComprasTransferencias(da)
      Select Case tipo
         Case TipoSP._I
            sql.ComprasTransferencias_I(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor,
                                        ent.NumeroComprobante, ent.IdProveedor, ent.Orden,
                                       ent.Importe, ent.IdCuentaBancaria,
                                       ent.IdSucursalLibroBanco, ent.IdCuentaBancariaLibroBanco,
                                       ent.NumeroMovimientoLibroBanco)
         Case TipoSP._U
            sql.ComprasTransferencias_U(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor,
                                        ent.NumeroComprobante, ent.IdProveedor, ent.Orden,
                                       ent.Importe, ent.IdCuentaBancaria,
                                       ent.IdSucursalLibroBanco, ent.IdCuentaBancariaLibroBanco,
                                       ent.NumeroMovimientoLibroBanco)
         Case TipoSP._D
            sql.ComprasTransferencias_D(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor,
                                        ent.NumeroComprobante, ent.IdProveedor, ent.Orden)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CompraTransferencia, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.CompraTransferencia.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.CompraTransferencia.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.CompraTransferencia.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.CompraTransferencia.Columnas.CentroEmisor.ToString())
         .NumeroComprobante = dr.Field(Of Long)(Entidades.CompraTransferencia.Columnas.NumeroComprobante.ToString())
         .IdProveedor = Long.Parse(dr(Entidades.CompraTransferencia.Columnas.IdProveedor.ToString()).ToString())
         .Orden = dr.Field(Of Integer)(Entidades.CompraTransferencia.Columnas.Orden.ToString())

         .Importe = dr.Field(Of Decimal)(Entidades.CompraTransferencia.Columnas.Importe.ToString())
         .IdCuentaBancaria = dr.Field(Of Integer)(Entidades.CompraTransferencia.Columnas.IdCuentaBancaria.ToString())
         .NombreCuenta = dr.Field(Of String)(Entidades.CuentaBancaria.Columnas.NombreCuenta.ToString())           'FK

         .IdSucursalLibroBanco = dr.Field(Of Integer?)(Entidades.CompraTransferencia.Columnas.IdSucursalLibroBanco.ToString())
         .IdCuentaBancariaLibroBanco = dr.Field(Of Integer?)(Entidades.CompraTransferencia.Columnas.IdCuentaBancariaLibroBanco.ToString())
         .NumeroMovimientoLibroBanco = dr.Field(Of Integer?)(Entidades.CompraTransferencia.Columnas.NumeroMovimientoLibroBanco.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub _Insertar(vt As Entidades.CompraTransferencia)
      EjecutaSP(vt, TipoSP._I)
   End Sub
   Public Sub _Actualizar(vt As Entidades.CompraTransferencia)
      EjecutaSP(vt, TipoSP._U)
   End Sub
   Public Overloads Sub _Borrar(vt As Entidades.CompraTransferencia)
      EjecutaSP(vt, TipoSP._D)
   End Sub

   Public Sub _Insertar(v As Entidades.Compra, coe As Integer)
      If coe = 0 Then coe = 1
      v.Transferencias.ForEach(
      Sub(vt)
         vt.IdSucursal = v.IdSucursal
         vt.IdTipoComprobante = v.IdTipoComprobante
         vt.Letra = v.Letra
         vt.CentroEmisor = v.CentroEmisor
         vt.NumeroComprobante = v.NumeroComprobante
         vt.IdProveedor = v.Proveedor.IdProveedor
         If vt.Orden = 0 Then
            vt.Orden = GetOrdenMaximo(v.IdSucursal, v.IdTipoComprobante, v.Letra, v.CentroEmisor, v.NumeroComprobante, v.Proveedor.IdProveedor) + 1
         End If
         vt.Importe = vt.Importe * coe
         _Insertar(vt)
      End Sub)
   End Sub
   Public Overloads Sub _Borrar(v As Entidades.Compra)
      _Borrar(New Entidades.CompraTransferencia() With
              {
                  .IdSucursal = v.IdSucursal,
                  .IdTipoComprobante = v.IdTipoComprobante,
                  .Letra = v.Letra,
                  .CentroEmisor = v.CentroEmisor,
                  .NumeroComprobante = v.NumeroComprobante,
                  .IdProveedor = v.Proveedor.IdProveedor
              })
   End Sub


   Public Overloads Function GetAll(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long) As DataTable
      Return New SqlServer.ComprasTransferencias(da).ComprasTransferencias_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)
   End Function
   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long) As List(Of Entidades.CompraTransferencia)
      Return CargaLista(New SqlServer.ComprasTransferencias(da).ComprasTransferencias_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CompraTransferencia())
   End Function
   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long, orden As Integer) As DataTable
      Return New SqlServer.ComprasTransferencias(da).ComprasTransferencias_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, orden)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long, orden As Integer) As Entidades.CompraTransferencia
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, orden, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long, orden As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.CompraTransferencia
      Return CargaEntidad(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, orden),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CompraTransferencia(),
                          accion, Function() String.Format("No existe el registro de CompraTransferencia"))
   End Function
   Public Function GetOrdenMaximo(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long) As Integer
      Return New SqlServer.ComprasTransferencias(da).GetOrdenMaximo(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)
   End Function
#End Region

End Class