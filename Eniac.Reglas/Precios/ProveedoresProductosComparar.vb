Option Explicit On
Option Strict On

Public Class ProveedoresProductosComparar
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.ProveedorProductoComparar.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ProveedorProductoComparar.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overloads Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProveedorProductoComparar), TipoSP._I))
   End Sub

   Public Overloads Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProveedorProductoComparar), TipoSP._U))
   End Sub

   Public Overloads Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProveedorProductoComparar), TipoSP._D))
   End Sub

   Public Overrides Function GetAll() As System.Data.DataTable
      Dim sProveedoresComparar As SqlServer.ProveedoresProductosComparar = New SqlServer.ProveedoresProductosComparar(da)
      Return sProveedoresComparar.ProveedoresProductosComparar_GA()
   End Function

#End Region

#Region "Métodos Públicos"

   Public Sub Inserta(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ProveedorProductoComparar), TipoSP._I)
   End Sub

   Public Sub Actualiza(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ProveedorProductoComparar), TipoSP._U)
   End Sub

   Public Sub Borra(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ProveedorProductoComparar), TipoSP._D)
   End Sub

   Public Function GetUno(idProducto As String, linea As Integer) As Entidades.ProveedorProductoComparar
      Dim sProveedoresProductosComparar As SqlServer.ProveedoresProductosComparar = New SqlServer.ProveedoresProductosComparar(da)
      Return CargaEntidad(sProveedoresProductosComparar.ProveedoresProductosComparar_G1(idProducto, linea),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProveedorProductoComparar(),
                    AccionesSiNoExisteRegistro.Nulo, Function() String.Format(""))
   End Function

   Public Function GetTodos() As List(Of Entidades.ProveedorProductoComparar)
      Dim dt As DataTable = Me.GetAll()
      Dim eProveedoresProductosComparar As Entidades.ProveedorProductoComparar
      Dim lista As List(Of Entidades.ProveedorProductoComparar) = New List(Of Entidades.ProveedorProductoComparar)
      For Each dr As DataRow In dt.Rows
         eProveedoresProductosComparar = New Entidades.ProveedorProductoComparar()
         Me.CargarUno(eProveedoresProductosComparar, dr)
         lista.Add(eProveedoresProductosComparar)
      Next
      Return lista
   End Function

#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.ProveedorProductoComparar, tipo As TipoSP)
      Dim sProveedoresProductosComparar As SqlServer.ProveedoresProductosComparar = New SqlServer.ProveedoresProductosComparar(da)
      Select Case tipo
         Case TipoSP._I
            sProveedoresProductosComparar.ProveedoresProductosComparar_I(en.IdProducto, en.Linea, en.IdProveedor, en.CodigoProductoProveedor, en.PrecioCompraAnterior,
                                                                         en.PorcVarCompra, en.PrecioCompra, en.DescRec1, en.DescRec2, en.DescRec3, en.DescRec4, en.PrecioCostoAnterior,
                                                                         en.PorcVarCosto, en.PrecioCosto)
         Case TipoSP._U
            sProveedoresProductosComparar.ProveedoresProductosComparar_U(en.IdProducto, en.Linea, en.IdProveedor, en.CodigoProductoProveedor, en.PrecioCompraAnterior,
                                                                         en.PorcVarCompra, en.PrecioCompra, en.DescRec1, en.DescRec2, en.DescRec3, en.DescRec4, en.PrecioCostoAnterior,
                                                                         en.PorcVarCosto, en.PrecioCosto)
         Case TipoSP._D
            sProveedoresProductosComparar.ProveedoresProductosComparar_D(en.IdProveedor)
      End Select
   End Sub

   Private Sub CargarUno(eProveedoresProductosComparar As Entidades.ProveedorProductoComparar, dr As DataRow)
      With eProveedoresProductosComparar
         .IdProducto = dr.Field(Of String)(Entidades.ProveedorProductoComparar.Columnas.IdProducto.ToString())
         .Linea = dr.Field(Of Integer)(Entidades.ProveedorProductoComparar.Columnas.Linea.ToString())
         .IdProveedor = dr.Field(Of Long)(Entidades.ProveedorProductoComparar.Columnas.IdProveedor.ToString())
         .CodigoProductoProveedor = dr.Field(Of String)(Entidades.ProveedorProductoComparar.Columnas.CodigoProductoProveedor.ToString())
         .PrecioCompraAnterior = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.PrecioCompraAnterior.ToString())
         .PorcVarCompra = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.PorcVarCompra.ToString())
         .PrecioCompra = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.PrecioCompra.ToString())
         .DescRec1 = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.DescRec1.ToString())
         .DescRec2 = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.DescRec2.ToString())
         .DescRec3 = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.DescRec3.ToString())
         .DescRec4 = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.DescRec4.ToString())
         .PrecioCostoAnterior = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.PrecioCostoAnterior.ToString())
         .PorcVarCosto = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.PorcVarCosto.ToString())
         .PrecioCosto = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.PrecioCosto.ToString())
      End With
   End Sub

   Public Function CompararProductosEntreProveedores(dt As DataTable,
                                                     idProducto As String,
                                                     marcas As Entidades.Marca(),
                                                     rubros As Entidades.Rubro(),
                                                     subrubros As Entidades.SubRubro(),
                                                     subsubrubros As Entidades.SubSubRubro()) As DataTable
      Dim sProveedoresProductosComparar As SqlServer.ProveedoresProductosComparar = New SqlServer.ProveedoresProductosComparar(da)
      Dim proveedores As List(Of Entidades.Proveedor) = New List(Of Entidades.Proveedor)
      For Each row As DataRow In dt.Rows
         If Boolean.Parse(row("Select").ToString()) Then
            Dim prov As Entidades.Proveedor = New Entidades.Proveedor With {.IdProveedor = row.Field(Of Long)(Entidades.Proveedor.Columnas.IdProveedor.ToString()),
                                                                            .NombreProveedor = row.Field(Of String)(Entidades.Proveedor.Columnas.NombreProveedor.ToString())}
            proveedores.Add(prov)
         End If
      Next
      Return sProveedoresProductosComparar.CompararProductosEntreProveedores(proveedores,
                                                                             actual.Sucursal.Id,
                                                                             idProducto,
                                                                             marcas,
                                                                             rubros,
                                                                             subrubros,
                                                                             subsubrubros)
   End Function


   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ProveedoresProductosComparar = New SqlServer.ProveedoresProductosComparar(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return New SqlServer.ProveedoresProductosComparar(Me.da).GetCodigoMaximo()
   End Function

#End Region

End Class
