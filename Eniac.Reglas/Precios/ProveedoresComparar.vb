Option Explicit On
Option Strict On

Public Class ProveedoresComparar
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.ProveedorComparar.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ProveedorComparar.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProveedorComparar), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProveedorComparar), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProveedorComparar), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable

   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Dim sProveedoresComparar As SqlServer.ProveedoresComparar = New SqlServer.ProveedoresComparar(da)
      Return sProveedoresComparar.ProveedoresComparar_GA()
   End Function

#End Region

#Region "Métodos Públicos"

   Public Function GetUno(idProveedor As Long) As Entidades.ProveedorComparar
      Dim sProveedoresComparar As SqlServer.ProveedoresComparar = New SqlServer.ProveedoresComparar(da)
      Return CargaEntidad(sProveedoresComparar.ProveedoresComparar_G1(idProveedor),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProveedorComparar(),
                    AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No existe el Proveedor {0}", idProveedor))
   End Function

   Public Function GetTodos() As List(Of Entidades.ProveedorComparar)
      Dim dt As DataTable = Me.GetAll()
      Dim eProveedorComparar As Entidades.ProveedorComparar
      Dim lista As List(Of Entidades.ProveedorComparar) = New List(Of Entidades.ProveedorComparar)
      For Each dr As DataRow In dt.Rows
         eProveedorComparar = New Entidades.ProveedorComparar()
         Me.CargarUno(eProveedorComparar, dr)
         lista.Add(eProveedorComparar)
      Next
      Return lista
   End Function

   Public Sub ImportarParaComparar(proveedor As Entidades.ProveedorComparar, productos As DataTable)
      EjecutaConTransaccion(Sub() ImportarDatosParaComparar(proveedor, productos))
   End Sub

   Private Sub ImportarDatosParaComparar(proveedor As Entidades.ProveedorComparar, productos As DataTable)

      Dim rProveedoresProductosComparar As Reglas.ProveedoresProductosComparar = New Reglas.ProveedoresProductosComparar(da)
      Dim eProveedorProductoComparar As Entidades.ProveedorProductoComparar = New Entidades.ProveedorProductoComparar
      Dim linea As Integer = rProveedoresProductosComparar.GetCodigoMaximo

      '# Elimino los productos y la plantilla que tenga cargada el Proveedor
      eProveedorProductoComparar.IdProveedor = proveedor.IdProveedor
      rProveedoresProductosComparar.Borra(eProveedorProductoComparar)
      EjecutaSP(proveedor, TipoSP._D)

      '# Guardo la nueva plantilla con sus productos
      EjecutaSP(proveedor, TipoSP._I)
      For Each dr As DataRow In productos.Rows
         If dr.Field(Of Boolean)("Importa").ToString() = Boolean.TrueString Then
            Dim en As Entidades.ProveedorProductoComparar = New Entidades.ProveedorProductoComparar
            linea += 1

            en.IdProducto = dr.Field(Of String)("CodigoProducto")
            en.Linea = linea
            en.IdProveedor = proveedor.IdProveedor
            en.CodigoProductoProveedor = dr.Field(Of String)("CodigoProveedor")
            en.PrecioCompraAnterior = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.PrecioCompraAnterior.ToString())
            en.PorcVarCompra = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.PorcVarCompra.ToString())
            en.PrecioCompra = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.PrecioCompra.ToString())
            en.DescRec1 = dr.Field(Of Decimal?)("DescuentoRecargoPorc1")
            en.DescRec2 = dr.Field(Of Decimal?)("DescuentoRecargoPorc2")
            en.DescRec3 = dr.Field(Of Decimal?)("DescuentoRecargoPorc3")
            en.DescRec4 = dr.Field(Of Decimal?)("DescuentoRecargoPorc4")
            en.PrecioCostoAnterior = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.PrecioCostoAnterior.ToString())
            en.PorcVarCosto = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.PorcVarCosto.ToString())
            en.PrecioCosto = dr.Field(Of Decimal?)(Entidades.ProveedorProductoComparar.Columnas.PrecioCosto.ToString())

            rProveedoresProductosComparar.Inserta(en)
         End If
      Next

   End Sub

#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.ProveedorComparar, tipo As TipoSP)
      Dim sProveedoresComparar As SqlServer.ProveedoresComparar = New SqlServer.ProveedoresComparar(da)
      Select Case tipo
         Case TipoSP._I
            sProveedoresComparar.ProveedoresComparar_I(en.IdProveedor, en.IdPlantilla, en.FechaActualizacion)
         Case TipoSP._U
            sProveedoresComparar.ProveedoresComparar_U(en.IdProveedor, en.IdPlantilla, en.FechaActualizacion)
         Case TipoSP._D

            '# Elimino los productos y la plantilla que tenga cargada el Proveedor
            Dim rProveedoresProductosComparar As Reglas.ProveedoresProductosComparar = New ProveedoresProductosComparar(da)
            rProveedoresProductosComparar.Borra(New Entidades.ProveedorProductoComparar With {.IdProveedor = en.IdProveedor})

            sProveedoresComparar.ProveedoresComparar_D(en.IdProveedor)
      End Select
   End Sub

   Private Sub CargarUno(eProveedorComparar As Entidades.ProveedorComparar, dr As DataRow)
      With eProveedorComparar
         .IdProveedor = dr.Field(Of Long)(Entidades.ProveedorComparar.Columnas.IdProveedor.ToString())
         .NombreProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.NombreProveedor.ToString())
         .IdPlantilla = dr.Field(Of Integer)(Entidades.ProveedorComparar.Columnas.IdPlantilla.ToString())
         .FechaActualizacion = dr.Field(Of Date)(Entidades.ProveedorComparar.Columnas.FechaActualizacion.ToString())
      End With
   End Sub

#End Region

End Class
