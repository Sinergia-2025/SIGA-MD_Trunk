Public Class VentasTransferencias
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.VentaTransferencia.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.VentaTransferencia)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.VentaTransferencia)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.VentaTransferencia)))
   End Sub
#End Region

#Region "Metodos Privados"
   Friend Sub EjecutaSP(ent As Entidades.VentaTransferencia, tipo As TipoSP)
      Dim sql = New SqlServer.VentasTransferencias(da)
      Select Case tipo
         Case TipoSP._I
            sql.VentasTransferencias_I(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.Orden,
                                       ent.Importe, ent.IdCuentaBancaria,
                                       ent.IdSucursalLibroBanco, ent.IdCuentaBancariaLibroBanco, ent.NumeroMovimientoLibroBanco)
         Case TipoSP._U
            sql.VentasTransferencias_U(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.Orden,
                                       ent.Importe, ent.IdCuentaBancaria,
                                       ent.IdSucursalLibroBanco, ent.IdCuentaBancariaLibroBanco, ent.NumeroMovimientoLibroBanco)
         Case TipoSP._D
            sql.VentasTransferencias_D(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.Orden)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.VentaTransferencia, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.VentaTransferencia.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.VentaTransferencia.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.VentaTransferencia.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.VentaTransferencia.Columnas.CentroEmisor.ToString())
         .NumeroComprobante = dr.Field(Of Long)(Entidades.VentaTransferencia.Columnas.NumeroComprobante.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.VentaTransferencia.Columnas.Orden.ToString())

         .Importe = dr.Field(Of Decimal)(Entidades.VentaTransferencia.Columnas.Importe.ToString())
         .IdCuentaBancaria = dr.Field(Of Integer)(Entidades.VentaTransferencia.Columnas.IdCuentaBancaria.ToString())
         .NombreCuenta = dr.Field(Of String)(Entidades.CuentaBancaria.Columnas.NombreCuenta.ToString())           'FK

         .IdSucursalLibroBanco = dr.Field(Of Integer?)(Entidades.VentaTransferencia.Columnas.IdSucursalLibroBanco.ToString())
         .IdCuentaBancariaLibroBanco = dr.Field(Of Integer?)(Entidades.VentaTransferencia.Columnas.IdCuentaBancariaLibroBanco.ToString())
         .NumeroMovimientoLibroBanco = dr.Field(Of Integer?)(Entidades.VentaTransferencia.Columnas.NumeroMovimientoLibroBanco.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub _Insertar(vt As Entidades.VentaTransferencia)
      EjecutaSP(vt, TipoSP._I)
   End Sub
   Public Sub _Actualizar(vt As Entidades.VentaTransferencia)
      EjecutaSP(vt, TipoSP._U)
   End Sub
   Public Overloads Sub _Borrar(vt As Entidades.VentaTransferencia)
      EjecutaSP(vt, TipoSP._D)
   End Sub

   Public Sub _Insertar(v As Entidades.Venta, coe As Integer)
      If coe = 0 Then coe = 1
      v.Transferencias.ForEach(
      Sub(vt)
         vt.IdSucursal = v.IdSucursal
         vt.IdTipoComprobante = v.IdTipoComprobante
         vt.Letra = v.LetraComprobante
         vt.CentroEmisor = v.CentroEmisor
         vt.NumeroComprobante = v.NumeroComprobante
         If vt.Orden = 0 Then
            vt.Orden = GetOrdenMaximo(v.IdSucursal, v.IdTipoComprobante, v.LetraComprobante, v.CentroEmisor, v.NumeroComprobante) + 1
         End If
         vt.Importe = vt.Importe * coe
         _Insertar(vt)
      End Sub)
   End Sub
   Public Overloads Sub _Borrar(v As Entidades.Venta)
      _Borrar(New Entidades.VentaTransferencia() With
              {
                  .IdSucursal = v.IdSucursal,
                  .IdTipoComprobante = v.IdTipoComprobante,
                  .Letra = v.LetraComprobante,
                  .CentroEmisor = v.CentroEmisor,
                  .NumeroComprobante = v.NumeroComprobante
              })
   End Sub


   Public Overloads Function GetAll(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Return New SqlServer.VentasTransferencias(da).VentasTransferencias_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function
   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As List(Of Entidades.VentaTransferencia)
      Return CargaLista(New SqlServer.VentasTransferencias(da).VentasTransferencias_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaTransferencia())
   End Function
   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, orden As Integer) As DataTable
      Return New SqlServer.VentasTransferencias(da).VentasTransferencias_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, orden As Integer) As Entidades.VentaTransferencia
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, orden As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.VentaTransferencia
      Return CargaEntidad(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, orden),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaTransferencia(),
                          accion, Function() String.Format("No existe el registro de VentaTransferencia"))
   End Function
   Public Function GetOrdenMaximo(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As Integer
      Return New SqlServer.VentasTransferencias(da).GetOrdenMaximo(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function
#End Region

End Class