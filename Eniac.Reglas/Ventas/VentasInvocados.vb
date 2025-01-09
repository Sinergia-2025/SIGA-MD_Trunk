Public Class VentasInvocados
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.VentaInvocado.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me._Insertar(DirectCast(entidad, Entidades.VentaInvocado)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me._Actualizar(DirectCast(entidad, Entidades.VentaInvocado)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me._Borrar(DirectCast(entidad, Entidades.VentaInvocado)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.VentasInvocados = New SqlServer.VentasInvocados(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.VentasInvocados(da).VentasInvocados_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Public Sub _Insertar(entidad As Entidades.VentaInvocado)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.VentaInvocado)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.VentaInvocado)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub _Borrar(invocador As Entidades.Venta)
      _Borrar(invocador.IdSucursal, invocador.IdTipoComprobante, invocador.LetraComprobante, invocador.CentroEmisor, invocador.NumeroComprobante)
   End Sub
   Public Sub _Borrar(idSucursalInvocador As Integer, idTipoComprobanteInvocador As String, letraInvocador As String, centroEmisorInvocador As Integer, numeroComprobanteInvocador As Long)
      Dim sqlC = New SqlServer.VentasInvocados(da)
      sqlC.VentasInvocados_D_Invocados(idSucursalInvocador, idTipoComprobanteInvocador, letraInvocador, centroEmisorInvocador, numeroComprobanteInvocador)
   End Sub

   Private Sub EjecutaSP(en As Entidades.VentaInvocado, tipo As TipoSP)
      Dim sqlC = New SqlServer.VentasInvocados(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.VentasInvocados_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                   en.IdSucursalInvocado, en.IdTipoComprobanteInvocado, en.LetraInvocado, en.CentroEmisorInvocado, en.NumeroComprobanteInvocado)
         Case TipoSP._U
            sqlC.VentasInvocados_U(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                   en.IdSucursalInvocado, en.IdTipoComprobanteInvocado, en.LetraInvocado, en.CentroEmisorInvocado, en.NumeroComprobanteInvocado)
         Case TipoSP._D
            sqlC.VentasInvocados_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                   en.IdSucursalInvocado, en.IdTipoComprobanteInvocado, en.LetraInvocado, en.CentroEmisorInvocado, en.NumeroComprobanteInvocado)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.VentaInvocado, dr As DataRow)
      With o
         .Invocado = New Entidades.VentaInvocada() With
                           {.IdSucursal = dr.Field(Of Integer)(Entidades.VentaInvocado.Columnas.IdSucursalInvocado.ToString()),
                            .IdTipoComprobante = dr.Field(Of String)(Entidades.VentaInvocado.Columnas.IdTipoComprobanteInvocado.ToString()),
                            .Letra = dr.Field(Of String)(Entidades.VentaInvocado.Columnas.LetraInvocado.ToString()),
                            .CentroEmisor = dr.Field(Of Integer)(Entidades.VentaInvocado.Columnas.CentroEmisorInvocado.ToString()),
                            .NumeroComprobante = dr.Field(Of Long)(Entidades.VentaInvocado.Columnas.NumeroComprobanteInvocado.ToString()),
                            .IdCliente = dr.Field(Of Long)("IdClienteInvocado"),
                            .Cuit = dr.Field(Of String)("CuitInvocado"),
                            .Fecha = dr.Field(Of Date)("FechaInvocado"),
                            .TipoTipoComprobante = dr.Field(Of String)("TipoTipoComprobanteInvocado"),
                            .CoeficienteStock = dr.Field(Of Integer)("CoeficienteStockInvocado"),
                            .IdProveedor = dr.Field(Of Long?)("IdProveedorInvocado"),
                            .IdTipoComprobanteContraMovInvocar = dr.Field(Of String)("IdTipoComprobanteContraMovInvocarInvocado"),
                            .DescripcionTipoComprobante = dr.Field(Of String)("DescripcionTipoComprobanteInvocado")}

      End With
   End Sub
   Private Sub CargarAmbos(o As Entidades.VentaInvocado, dr As DataRow)
      With o
         .Invocador = New Entidades.VentaInvocada() With
                           {.IdSucursal = dr.Field(Of Integer)(Entidades.VentaInvocado.Columnas.IdSucursal.ToString()),
                            .IdTipoComprobante = dr.Field(Of String)(Entidades.VentaInvocado.Columnas.IdTipoComprobante.ToString()),
                            .Letra = dr.Field(Of String)(Entidades.VentaInvocado.Columnas.Letra.ToString()),
                            .CentroEmisor = dr.Field(Of Integer)(Entidades.VentaInvocado.Columnas.CentroEmisor.ToString()),
                            .NumeroComprobante = dr.Field(Of Long)(Entidades.VentaInvocado.Columnas.NumeroComprobante.ToString()),
                            .IdCliente = dr.Field(Of Long)("IdCliente"),
                            .Cuit = dr.Field(Of String)("Cuit"),
                            .Fecha = dr.Field(Of Date)("Fecha"),
                            .TipoTipoComprobante = dr.Field(Of String)("TipoTipoComprobante"),
                            .CoeficienteStock = dr.Field(Of Integer)("CoeficienteStock"),
                            .IdProveedor = dr.Field(Of Long?)("IdProveedor"),
                            .IdTipoComprobanteContraMovInvocar = dr.Field(Of String)("IdTipoComprobanteContraMovInvocar"),
                            .DescripcionTipoComprobante = dr.Field(Of String)("DescripcionTipoComprobante")}
         .Invocado = New Entidades.VentaInvocada() With
                           {.IdSucursal = dr.Field(Of Integer)(Entidades.VentaInvocado.Columnas.IdSucursalInvocado.ToString()),
                            .IdTipoComprobante = dr.Field(Of String)(Entidades.VentaInvocado.Columnas.IdTipoComprobanteInvocado.ToString()),
                            .Letra = dr.Field(Of String)(Entidades.VentaInvocado.Columnas.LetraInvocado.ToString()),
                            .CentroEmisor = dr.Field(Of Integer)(Entidades.VentaInvocado.Columnas.CentroEmisorInvocado.ToString()),
                            .NumeroComprobante = dr.Field(Of Long)(Entidades.VentaInvocado.Columnas.NumeroComprobanteInvocado.ToString()),
                            .IdCliente = dr.Field(Of Long)("IdClienteInvocado"),
                            .Cuit = dr.Field(Of String)("CuitInvocado"),
                            .Fecha = dr.Field(Of Date)("FechaInvocado"),
                            .TipoTipoComprobante = dr.Field(Of String)("TipoTipoComprobanteInvocado"),
                            .CoeficienteStock = dr.Field(Of Integer)("CoeficienteStockInvocado"),
                            .IdProveedor = dr.Field(Of Long?)("IdProveedorInvocado"),
                            .IdTipoComprobanteContraMovInvocar = dr.Field(Of String)("IdTipoComprobanteContraMovInvocarInvocado"),
                            .DescripcionTipoComprobante = dr.Field(Of String)("DescripcionTipoComprobanteInvocado")}

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          idSucursalInvocado As Integer, idTipoComprobanteInvocado As String, letraInvocado As String, centroEmisorInvocado As Integer, numeroComprobanteInvocado As Long) As Entidades.VentaInvocado
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                    idSucursalInvocado, idTipoComprobanteInvocado, letraInvocado, centroEmisorInvocado, numeroComprobanteInvocado,
                    AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          idSucursalInvocado As Integer, idTipoComprobanteInvocado As String, letraInvocado As String, centroEmisorInvocado As Integer, numeroComprobanteInvocado As Long,
                          accion As AccionesSiNoExisteRegistro) As Entidades.VentaInvocado
      Return CargaEntidad(New SqlServer.VentasInvocados(da).VentasInvocados_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                                                  idSucursalInvocado, idTipoComprobanteInvocado, letraInvocado, centroEmisorInvocado, numeroComprobanteInvocado),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.VentaInvocado(),
                          accion, Function() String.Format("No existe Venta Invocado con Invocador: {0}/{1} {2} {3:0000}-{4:00000000} e Invocado: {5}/{6} {7} {8:0000}-{9:00000000}",
                                                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                           idSucursalInvocado, idTipoComprobanteInvocado, letraInvocado, centroEmisorInvocado, numeroComprobanteInvocado))
   End Function

   Public Function GetTodos() As List(Of Entidades.VentaInvocado)
      Return CargaLista(New SqlServer.VentasInvocados(da).VentasInvocados_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.VentaInvocado())
   End Function

   Public Function GetInvocados(venta As Entidades.Venta) As Entidades.VentasInvocadasCollection '  List(Of Entidades.VentaInvocado)
      Return GetInvocados(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante)
   End Function

   Public Function GetInvocados(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As Entidades.VentasInvocadasCollection 'List(Of Entidades.VentaInvocado)
      Dim sql = New SqlServer.VentasInvocados(da)
      Dim sqlP = New SqlServer.PedidosEstados(da)
      Return CargaLista({
                           sql.VentasInvocados_G_InvocadosPorInvocador(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante),
                           sqlP.PedidosEstados_G_ParaGetVinculados(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
                        },
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaInvocado(),
                        Function() New Entidades.VentasInvocadasCollection())
   End Function

   Public Function GetInvocadores(venta As Entidades.Venta) As Entidades.VentasInvocadasCollection  'List(Of Entidades.VentaInvocado)
      Return GetInvocadores(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante)
   End Function
   Public Function GetInvocadores(idSucursalInvocado As Integer, idTipoComprobanteInvocado As String, letraInvocado As String, centroEmisorInvocado As Integer, numeroComprobanteInvocado As Long) As Entidades.VentasInvocadasCollection  'List(Of Entidades.VentaInvocado)
      Return CargaLista(New SqlServer.VentasInvocados(da).VentasInvocados_G_InvocadoresPorInvocado(idSucursalInvocado, idTipoComprobanteInvocado, letraInvocado, centroEmisorInvocado, numeroComprobanteInvocado),
                        Sub(o, dr) CargarAmbos(o, dr), Function() New Entidades.VentaInvocado(),
                        Function() New Entidades.VentasInvocadasCollection())
   End Function

#End Region


   Public Function GetInvocadosInvocadores(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As Tuple(Of DataTable, DataTable, DataTable)

      Return EjecutaConConexion(
         Function()
            Dim sql = New SqlServer.VentasInvocados(da)
            Dim sqlVenta = New SqlServer.Ventas(da)

            Dim dtVenta = sqlVenta.Ventas_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
            Dim dtInvocados = sql.GetInvocadosParaInformes(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
            Dim dtInvocadores = sql.GetInvocadoresParaInformes(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

            Return New Tuple(Of DataTable, DataTable, DataTable)(dtVenta, dtInvocados, dtInvocadores)
         End Function)

   End Function

End Class