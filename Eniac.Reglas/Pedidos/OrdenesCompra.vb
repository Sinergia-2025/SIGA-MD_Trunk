Public Class OrdenesCompra
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "OrdenesCompra"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Inserta(DirectCast(entidad, Entidades.OrdenCompra)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Actualiza(DirectCast(entidad, Entidades.OrdenCompra)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Borra(DirectCast(entidad, Entidades.OrdenCompra)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.OrdenesCompra(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.OrdenesCompra(da).OrdenesCompra_GA(actual.Sucursal.IdSucursal)
   End Function

#End Region

#Region "Metodos Privados"

   Public Sub Inserta(entidad As Entidades.OrdenCompra)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Actualiza(entidad As Entidades.OrdenCompra)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub Borra(entidad As Entidades.OrdenCompra)
      EjecutaSP(entidad, TipoSP._D)
   End Sub


   Private Sub EjecutaSP(en As Entidades.OrdenCompra, tipo As TipoSP)
      Dim sql = New SqlServer.OrdenesCompra(da)
      Select Case tipo
         Case TipoSP._I
            sql.OrdenesCompra_I(en.IdSucursal, en.NumeroOrdenCompra, en.IdProveedor, en.IdFormasPago,
                                en.FechaPedidos, en.Usuario, en.RespetaPreciosOrdenCompra, en.AplicaDescuentoRecargo,
                                en.Anticipado)

         Case TipoSP._U
            sql.OrdenesCompra_U(en.IdSucursal, en.NumeroOrdenCompra, en.IdProveedor, en.IdFormasPago,
                                en.FechaPedidos, en.Usuario, en.RespetaPreciosOrdenCompra, en.AplicaDescuentoRecargo,
                                en.Anticipado)

         Case TipoSP._D
            sql.OrdenesCompra_D(en.IdSucursal, en.NumeroOrdenCompra)

      End Select
   End Sub

   Private Sub CargarUna(o As Entidades.OrdenCompra, dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.OrdenCompra.Columnas.IdSucursal.ToString()).ToString())
         .NumeroOrdenCompra = Long.Parse(dr(Entidades.OrdenCompra.Columnas.NumeroOrdenCompra.ToString()).ToString())
         .IdProveedor = Long.Parse(dr(Entidades.OrdenCompra.Columnas.IdProveedor.ToString()).ToString())
         .IdFormasPago = Integer.Parse(dr(Entidades.OrdenCompra.Columnas.IdFormasPago.ToString()).ToString())
         .FechaPedidos = Date.Parse(dr(Entidades.OrdenCompra.Columnas.FechaPedidos.ToString()).ToString())
         .Usuario = dr(Entidades.OrdenCompra.Columnas.IdUsuario.ToString()).ToString()
         .IdUsuario = dr(Entidades.OrdenCompra.Columnas.IdUsuario.ToString()).ToString()
         .RespetaPreciosOrdenCompra = Boolean.Parse(dr(Entidades.OrdenCompra.Columnas.RespetaPreciosOrdenCompra.ToString()).ToString())
         .AplicaDescuentoRecargo = Boolean.Parse(dr(Entidades.OrdenCompra.Columnas.AplicaDescuentoRecargo.ToString()).ToString())
         .Anticipado = Boolean.Parse(dr(Entidades.OrdenCompra.Columnas.Anticipado.ToString()).ToString())

         .CodigoProveedor = dr(Entidades.Proveedor.Columnas.CodigoProveedor.ToString()).ToString()
         .NombreProveedor = dr(Entidades.Proveedor.Columnas.NombreProveedor.ToString()).ToString()
         .DescripcionFormasPago = dr(Entidades.VentaFormaPago.Columnas.DescripcionFormasPago.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.OrdenCompra)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.OrdenCompra())
   End Function

   Public Function GetUno(IdSucursal As Integer, NumeroOrdenCompra As Long, retornaExcepcion As Boolean) As Entidades.OrdenCompra
      Return GetUno(IdSucursal, NumeroOrdenCompra, If(retornaExcepcion, AccionesSiNoExisteRegistro.Excepcion, AccionesSiNoExisteRegistro.Nulo))
   End Function

   Public Function GetUno(IdSucursal As Integer, NumeroOrdenCompra As Long, accion As AccionesSiNoExisteRegistro) As Entidades.OrdenCompra
      Return CargaEntidad(Get1(IdSucursal, NumeroOrdenCompra),
                          Sub(o, dr) CargarUna(o, dr), Function() New Entidades.OrdenCompra(),
                          accion, Function() String.Format("No Existe la Orden de Compra con Numero {0}.", NumeroOrdenCompra))
   End Function

   Public Function Get1(idSucursal As Integer, numeroOrdenCompra As Long) As DataTable
      Dim sql = New SqlServer.OrdenesCompra(da)
      Return sql.OrdenesCompra_G1(idSucursal, numeroOrdenCompra, numeroOrdenCompraCeroTodos:=False)
   End Function

   Public Function GetPorCodigo(idSucursal As Integer, numeroOrdenCompra As Long) As DataTable
      Dim sql = New SqlServer.OrdenesCompra(da)
      Return sql.OrdenesCompra_G1(idSucursal, numeroOrdenCompra, numeroOrdenCompraCeroTodos:=True)
   End Function

#End Region

End Class