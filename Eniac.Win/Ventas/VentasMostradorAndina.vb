Imports System.Text
Imports System.IO

Public Class VentasMostradorAndina

#Region "Propiedades"

   Private _lineas As List(Of VentasMostradorAndinaLinea)
   Public ReadOnly Property Lineas() As List(Of VentasMostradorAndinaLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of VentasMostradorAndinaLinea)()
         End If
         Return _lineas
      End Get
   End Property

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarArchivo(ByVal destino As String)
      Dim stb As StringBuilder
      Dim ITEMS As Integer = 0
      Try

         stb = New StringBuilder()

         '    stb.AppendLine("NumeroPedido;CodigoCliente;IdTipoComprobante;Letra;CentroEmisor;NumeroComprobante;FechaEmision;IdEstadoComprobante;ImporteCuota")

         For Each linea As VentasMostradorAndinaLinea In Lineas
            stb.Append(linea.GetLinea()).AppendLine()
            ITEMS += 1
         Next

         stb.AppendLine("ITEMS=" & ITEMS)

         Dim utf8WithoutBom As Encoding = New UTF8Encoding(False)

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, utf8WithoutBom)

      Catch ex As Exception
         Throw
      End Try
   End Sub

#End Region

End Class

Public Class VentasMostradorAndinaLinea

#Region "Campos"

   Private _stb As StringBuilder

#End Region

#Region "Constructores"

   Public Sub New()
      Me._stb = New StringBuilder()
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetLinea() As String
      With Me._stb

         '"NumeroPedido;CodigoCliente;IdTipoComprobante;Letra;CentroEmisor;NumeroComprobante;FechaEmision;IdEstadoComprobante;ImporteCuota"
         .Length = 0
         '.Append(Me.CentroEmisorPedido.ToString("0000") & "-" & Me.NumeroPedido.ToString(New String("0"c, 8)))
         '.Append(";")
         .Append(Me.CodigoCliente.ToString())
         .Append(";")
         .AppendFormat(Me.TipoComprobantePDA.ToString())
         .Append(";")
         .Append(Me.Letra.ToString())
         .Append(";")
         .Append(Me.CentroEmisor.ToString("0000"))
         .Append(";")
         .Append(Me.NumeroComprobante.ToString(New String("0"c, 8)))
         .Append(";")
         .Append(Me.FechaEmision.ToShortDateString())
         .Append(";")
         .Append(Me.IdEstadoComprobante.ToString())
         .Append(";")
         .Append((Me.ImporteTotal * Me.CoeficienteValores).ToString("0.00"))
         .Append(";")
         .Append(Me.Vendedor.IdEmpleado.ToString())
         '.AppendFormat(Me.PuntoDeVenta.ToString("00000"))
         ''04 - desde 017 hasta 036 / Númerico / Tam = 20 / Observaciones = 
         '.AppendFormat(Me.NroDeComprobante.ToString(New String("0"c, 20)))

      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"


   '"NumeroPedido;CodigoCliente;IdTipoComprobante;Letra;CentroEmisor;NumeroComprobante;FechaEmision;IdEstadoComprobante;ImporteCuota"

   Private _procesar As Boolean = False
   Public Property Procesar() As Boolean
      Get
         Return _procesar
      End Get
      Set(ByVal value As Boolean)
         _procesar = value
      End Set
   End Property

   Private _idSucursal As Integer = 0
   Public Property IdSucursal() As Integer
      Get
         Return Me._idSucursal
      End Get
      Set(ByVal value As Integer)
         Me._idSucursal = value
      End Set
   End Property

   Private _idCliente As String
   Public Property IdCliente() As String
      Get
         Return _idCliente
      End Get
      Set(ByVal value As String)
         _idCliente = value.Trim()
      End Set
   End Property

   Private _CodigoCliente As Long
   Public Property CodigoCliente() As Long
      Get
         Return _CodigoCliente
      End Get
      Set(ByVal value As Long)
         _CodigoCliente = value
      End Set
   End Property

   Private _nombreCliente As String
   Public Property NombreCliente() As String
      Get
         Return _nombreCliente
      End Get
      Set(ByVal value As String)
         _nombreCliente = value.Trim()
      End Set
   End Property

   Private _linea As Integer = 0
   Public Property Linea() As Integer
      Get
         Return _linea
      End Get
      Set(ByVal value As Integer)
         _linea = value
      End Set
   End Property

   Private _tipoComprobante As Entidades.TipoComprobante
   Public Property TipoComprobante() As Entidades.TipoComprobante
      Get
         If Me._tipoComprobante Is Nothing Then
            Me._tipoComprobante = New Entidades.TipoComprobante()
         End If
         Return _tipoComprobante
      End Get
      Set(ByVal value As Entidades.TipoComprobante)
         _tipoComprobante = value
      End Set
   End Property

   Private _letra As String
   Public Property Letra() As String
      Get
         Return _letra
      End Get
      Set(ByVal value As String)
         _letra = value
      End Set
   End Property

   Private _centroEmisor As Integer
   Public Property CentroEmisor() As Integer
      Get
         Return _centroEmisor
      End Get
      Set(ByVal value As Integer)
         _centroEmisor = value
      End Set
   End Property

   Private _numeroComprobante As Long
   Public Property NumeroComprobante() As Long
      Get
         Return _numeroComprobante
      End Get
      Set(ByVal value As Long)
         _numeroComprobante = value
      End Set
   End Property

   Private _fechaEmision As Date
   Public Property FechaEmision() As Date
      Get
         Return Me._fechaEmision
      End Get
      Set(ByVal value As Date)
         Me._fechaEmision = value
      End Set
   End Property

   Private _importeTotal As Decimal = 0
   Public Property ImporteTotal() As Decimal
      Get
         Return (Me._importeTotal)
      End Get
      Set(ByVal value As Decimal)
         Me._importeTotal = value
      End Set
   End Property

   Private _IdEstadoComprobante As String
   Public Property IdEstadoComprobante() As String
      Get
         Return _IdEstadoComprobante
      End Get
      Set(ByVal value As String)
         _IdEstadoComprobante = value.Trim()
      End Set
   End Property

   Private _centroEmisorPedido As Integer
   Public Property CentroEmisorPedido() As Integer
      Get
         Return _centroEmisorPedido
      End Get
      Set(ByVal value As Integer)
         _centroEmisorPedido = value
      End Set
   End Property

   Private _numeroPedido As Long
   Public Property NumeroPedido() As Long
      Get
         Return _numeroPedido
      End Get
      Set(ByVal value As Long)
         _numeroPedido = value
      End Set
   End Property

   Private _tipoComprobantePDA As Integer
   Public Property TipoComprobantePDA() As Integer
      Get
         Return _tipoComprobantePDA
      End Get
      Set(ByVal value As Integer)
         _tipoComprobantePDA = value
      End Set
   End Property

   Private _coeficienteValores As Integer


   Public Property CoeficienteValores() As Integer
      Get
         Return _coeficienteValores
      End Get
      Set(ByVal value As Integer)
         _coeficienteValores = value
      End Set
   End Property
   Public Property Vendedor() As Eniac.Entidades.Empleado

#End Region

#Region "Propiedades ReadOnly"

   Public ReadOnly Property IdTipoComprobante() As String
      Get
         Return Me.TipoComprobante.IdTipoComprobante
      End Get
   End Property

#End Region

End Class

Public Class VentasMostradorAndinaDetalle

#Region "Propiedades"

   Private _lineas As List(Of VentasMostradorAndinaLineaDetalle)
   Public ReadOnly Property Lineas() As List(Of VentasMostradorAndinaLineaDetalle)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of VentasMostradorAndinaLineaDetalle)()
         End If
         Return _lineas
      End Get
   End Property

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarArchivo(ByVal destino As String)
      Dim stb As StringBuilder
      Dim ITEMS As Integer = 0
      Try

         stb = New StringBuilder()

         '    stb.AppendLine("NumeroPedido;CodigoCliente;IdTipoComprobante;Letra;CentroEmisor;NumeroComprobante;FechaEmision;IdEstadoComprobante;ImporteCuota")

         For Each linea As VentasMostradorAndinaLineaDetalle In Lineas
            stb.Append(linea.GetLinea()).AppendLine()
            ITEMS += 1
         Next

         stb.AppendLine("ITEMS=" & ITEMS)

         Dim utf8WithoutBom As Encoding = New UTF8Encoding(False)

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, utf8WithoutBom)

      Catch ex As Exception
         Throw
      End Try
   End Sub

#End Region

End Class

Public Class VentasMostradorAndinaLineaDetalle

#Region "Campos"

   Private _stb As StringBuilder

#End Region

#Region "Constructores"

   Public Sub New()
      Me._stb = New StringBuilder()
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetLinea() As String
      With Me._stb

         .Length = 0
         .Append(Me.CodigoCliente.ToString())
         .Append(";")
         .AppendFormat(Me.TipoComprobantePDA.ToString())
         .Append(";")
         .Append(Me.Letra.ToString())
         .Append(";")
         .Append(Me.CentroEmisor.ToString("0000"))
         .Append(";")
         .Append(Me.NumeroComprobante.ToString(New String("0"c, 8)))
         .Append(";")
         .Append(Me.Producto.IdProducto)
         .Append(";")
         .Append(Me.Producto.NombreProducto)
         .Append(";")
         .Append(Me.Cantidad)
         .Append(";")
         .Append("0")
         .Append(";")
         .Append("0")
         .Append(";")
         .Append(Me.PrecioNeto)
         .Append(";")
         .Append(Math.Abs(Me.DescuentoRecargoProducto))
         .Append(";")
         .Append(Math.Abs(Me.DescuentoRecargoPorc1))
         .Append(";")
         .Append(Me.ImporteImpuesto)
         .Append(";")
         .Append(Me.AlicuotaImpuesto)
         .Append(";")
         .Append(Me.ImporteImpuestoInterno)
         .Append(";")
         .Append(Me.Producto.Embalaje)
         .Append(";")
         .Append(Me.ImporteTotalNeto)

      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"


   '"NumeroPedido;CodigoCliente;IdTipoComprobante;Letra;CentroEmisor;NumeroComprobante;FechaEmision;IdEstadoComprobante;ImporteCuota"

   Private _procesar As Boolean = False
   Public Property Procesar() As Boolean
      Get
         Return _procesar
      End Get
      Set(ByVal value As Boolean)
         _procesar = value
      End Set
   End Property

   Private _idSucursal As Integer = 0
   Public Property IdSucursal() As Integer
      Get
         Return Me._idSucursal
      End Get
      Set(ByVal value As Integer)
         Me._idSucursal = value
      End Set
   End Property

   Private _idCliente As String
   Public Property IdCliente() As String
      Get
         Return _idCliente
      End Get
      Set(ByVal value As String)
         _idCliente = value.Trim()
      End Set
   End Property

   Private _CodigoCliente As Long
   Public Property CodigoCliente() As Long
      Get
         Return _CodigoCliente
      End Get
      Set(ByVal value As Long)
         _CodigoCliente = value
      End Set
   End Property

   Private _nombreCliente As String
   Public Property NombreCliente() As String
      Get
         Return _nombreCliente
      End Get
      Set(ByVal value As String)
         _nombreCliente = value.Trim()
      End Set
   End Property

   Private _linea As Integer = 0
   Public Property Linea() As Integer
      Get
         Return _linea
      End Get
      Set(ByVal value As Integer)
         _linea = value
      End Set
   End Property

   Private _tipoComprobante As Entidades.TipoComprobante
   Public Property TipoComprobante() As Entidades.TipoComprobante
      Get
         If Me._tipoComprobante Is Nothing Then
            Me._tipoComprobante = New Entidades.TipoComprobante()
         End If
         Return _tipoComprobante
      End Get
      Set(ByVal value As Entidades.TipoComprobante)
         _tipoComprobante = value
      End Set
   End Property

   Private _letra As String
   Public Property Letra() As String
      Get
         Return _letra
      End Get
      Set(ByVal value As String)
         _letra = value
      End Set
   End Property

   Private _centroEmisor As Integer
   Public Property CentroEmisor() As Integer
      Get
         Return _centroEmisor
      End Get
      Set(ByVal value As Integer)
         _centroEmisor = value
      End Set
   End Property

   Private _numeroComprobante As Long
   Public Property NumeroComprobante() As Long
      Get
         Return _numeroComprobante
      End Get
      Set(ByVal value As Long)
         _numeroComprobante = value
      End Set
   End Property

   Private _fechaEmision As Date
   Public Property FechaEmision() As Date
      Get
         Return Me._fechaEmision
      End Get
      Set(ByVal value As Date)
         Me._fechaEmision = value
      End Set
   End Property

   Public Property CodigoProveedor As String

   Public Property Cantidad As Decimal

   Public Property NombreProducto As String

   Public Property DescuentoRecargoProducto() As Decimal

   Public Property DescuentoRecargoPorc1() As Decimal

   Public Property DescuentoRecargoPorc2() As Decimal

   Public Property Iva() As Decimal

   Public Property PrecioNeto() As Decimal

   Public Property ImporteTotal() As Decimal

   Public Property ImporteTotalNeto() As Decimal

   Public Property AlicuotaImpuesto() As Decimal
   Public Property ImporteImpuesto() As Decimal

   Public Property ImporteImpuestoInterno() As Decimal

   Public Property PorcImpuestoInterno As Decimal
   Public Property OrigenPorcImpInt As Entidades.OrigenesPorcImpInt

   Public Property Producto() As Entidades.Producto
   Public Property TipoComprobantePDA() As Integer

#End Region

#Region "Propiedades ReadOnly"

   Public ReadOnly Property IdTipoComprobante() As String
      Get
         Return Me.TipoComprobante.IdTipoComprobante
      End Get
   End Property

#End Region

End Class

