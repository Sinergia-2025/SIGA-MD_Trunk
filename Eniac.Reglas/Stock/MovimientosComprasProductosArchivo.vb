Imports System.Windows.Forms
Public Class MovimientosComprasProductosArchivo

#Region "Propiedades"

   Private _lineas As List(Of MovimientosComprasProductosLinea)
   Public ReadOnly Property Lineas() As List(Of MovimientosComprasProductosLinea)
      Get
         If _lineas Is Nothing Then
            _lineas = New List(Of MovimientosComprasProductosLinea)()
         End If
         Return _lineas
      End Get
   End Property

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarArchivo(destino As String)
      Dim stb = New StringBuilder()

      For Each linea As MovimientosComprasProductosLinea In Lineas
         stb.Append(linea.GetLinea()).AppendLine()
      Next

      Dim utf8WithoutBom = New UTF8Encoding(False)
      My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, utf8WithoutBom)
   End Sub

   Public Overridable Function GetLinea() As MovimientosComprasProductosLinea
      Return New MovimientosComprasProductosLinea()
   End Function


   Public Function GenerarArchivo(idSucursal As Integer, idDeposito As Integer, idTipoMovimiento As String, NumeroMovimiento As Long) As Integer
      Dim oMov As Entidades.MovimientoStock
      oMov = New Reglas.MovimientosStock().GetUno(idSucursal, idTipoMovimiento, NumeroMovimiento)

      Dim DialogoGuardarArchivo = New SaveFileDialog With {
         .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop,
         .Filter = "Archivos de Texto (*.csv)|*.csv|Todos los Archivos (*.*)|*.*",
         .FilterIndex = 1,
         .RestoreDirectory = True,
         .FileName = String.Format("{0}_Envio_A_Sucursal_{1}_{2:yyyyMMdd_HHmm}.csv",
                              Publicos.CuitEmpresa.ToString(),
                              oMov.Sucursal2.Id,
                              Date.Now())
      }

      If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         If DialogoGuardarArchivo.FileName <> "" Then
            GenerarArchivo(oMov, DialogoGuardarArchivo.FileName)
            Return oMov.Productos.Count
         End If
      End If
      Return 0
   End Function
   Private Sub GenerarArchivo(omov As Entidades.MovimientoStock, Archivo As String)
      CrearMovimientoCompras(omov)
      GrabarArchivo(Archivo)
   End Sub

   Public Sub CrearMovimientoCompras(omov As Entidades.MovimientoStock)
      For Each dr In omov.Productos
         Dim linea = GetLinea()
         linea.MovimientoCompra.Sucursal2.Id = omov.Sucursal2.Id
         linea.IdProducto = dr.IdProducto
         linea.NombreProducto = dr.NombreProducto
         linea.Cantidad = dr.Cantidad * omov.TipoMovimiento.CoeficienteStock
         linea.Precio = dr.Precio
         linea.ImporteTotal = dr.ImporteTotal

         Lineas.Add(linea)
      Next
   End Sub
#End Region

End Class

Public Class MovimientosComprasProductosLinea

#Region "Campos"

   Protected _stb As StringBuilder

#End Region

#Region "Constructores"

   Public Sub New()
      Me._stb = New StringBuilder()
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Overridable Function GetLinea() As String
      With _stb
         .Length = 0
         .AppendFormat(MovimientoCompra.Sucursal2.Id.ToString())
         .Append(";")
         .AppendFormat(IdProducto)
         .Append(";")
         .Append(NombreProducto)
         .Append(";")
         .AppendFormat(Cantidad.ToString())
         .Append(";")
         .Append(Math.Round(Precio, 4).ToString().Replace(".", ","))
      End With
      Return _stb.ToString()
   End Function

#End Region

#Region "Propiedades"

   Private _procesar As Boolean = False
   Public Property Procesar() As Boolean
      Get
         Return _procesar
      End Get
      Set(value As Boolean)
         _procesar = value
      End Set
   End Property

   Private _linea As Integer = 0
   Public Property Linea() As Integer
      Get
         Return _linea
      End Get
      Set(value As Integer)
         _linea = value
      End Set
   End Property

   Public Property Orden() As Integer
   Public Property IdProducto() As String
   Public Property NombreProducto() As String
   Public Property Cantidad() As Decimal
   Public Property PrecioCostoO() As Decimal
   Public Property PrecioCostoNuevo() As Decimal
   Public Property Precio() As Decimal
   Public Property PrecioVentaActual() As Decimal
   Public Property PrecioVentaNuevo() As Decimal
   Public Property DescuentoRecargoPorc() As Decimal
   Public Property DescuentoRecargo() As Decimal
   Public Property DescRecGeneral() As Decimal
   Public Property Stock() As Decimal
   Public Property ImporteTotal() As Decimal
   Public Property PorcentajeIVA() As Decimal
   Public Property IVA() As Decimal
   Public Property TotalProducto() As Decimal
   Public Property PorcVar() As Decimal
   Private _movimientoCompra As Entidades.MovimientoStock
   Public Property MovimientoCompra() As Entidades.MovimientoStock
      Get
         If Me._movimientoCompra Is Nothing Then
            Me._movimientoCompra = New Entidades.MovimientoStock()
         End If
         Return Me._movimientoCompra
      End Get
      Set(value As Entidades.MovimientoStock)
         Me._movimientoCompra = value
      End Set
   End Property
   Private _productoSucursal As Entidades.ProductoSucursal = Nothing
   Public Property ProductoSucursal() As Entidades.ProductoSucursal
      Get
         If Me._productoSucursal Is Nothing Then
            Me._productoSucursal = New Entidades.ProductoSucursal()
         End If
         Return Me._productoSucursal
      End Get
      Set(value As Entidades.ProductoSucursal)
         Me._productoSucursal = value
      End Set
   End Property
   Public Property IdLote() As String
   Public Property VtoLote As Date?
   Public Property PorcentRecargo() As Decimal
   Public Property IdConcepto() As Integer
   Public Property NombreConcepto() As String
   Public Property FechaActualizacion() As Date
   Public Property CodigoProductoProveedor() As String

   Public Property CantidadReservado() As Decimal
   Public Property CantidadDefectuoso() As Decimal
   Public Property CantidadFuturo() As Decimal
   Public Property CantidadFuturoReservado() As Decimal

#End Region

End Class

