Imports System.Text
Imports System.IO

Public Class CtaCteClientesWeb

#Region "Propiedades"

   Private _lineas As List(Of CtaCteClientesWebLinea)
   Public ReadOnly Property Lineas() As List(Of CtaCteClientesWebLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of CtaCteClientesWebLinea)()
         End If
         Return _lineas
      End Get
   End Property

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarArchivo(ByVal destino As String)
      Dim stb As StringBuilder
      Try
         stb = New StringBuilder()

         stb.AppendLine("CodigoCliente;IdSucursal;IdTipoComprobante;Letra;CentroEmisor;NumeroComprobante;Cuota;FechaEmision;FechaVencimiento;ImporteCuota;SaldoCuota;Observacion")

         For Each linea As CtaCteClientesWebLinea In Lineas

            stb.Append(linea.GetLinea()).AppendLine()
         Next

         Dim utf8WithoutBom As Encoding = New UTF8Encoding(False)

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, utf8WithoutBom)

      Catch ex As Exception
         Throw
      End Try
   End Sub

#End Region

End Class

Public Class CtaCteClientesWebLinea

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

         'CodigoCliente;IdSucursal;IdTipoComprobante;Letra;CentroEmisor;NumeroComprobante;Cuota;FechaEmision;FechaVencimiento;ImporteCuota;SaldoCuota;Observacion

         .Length = 0
         .Append(Me.CodigoCliente.ToString())
         .Append(";")
         .AppendFormat(Me.IdSucursal.ToString())
         .Append(";")
         .AppendFormat(Me.IdTipoComprobante.ToString())
         .Append(";")
         .Append(Me.Letra.ToString())
         .Append(";")
         .Append(Me.CentroEmisor.ToString())
         .Append(";")
         .Append(Me.NumeroComprobante.ToString())
         .Append(";")
         .Append(Me.Cuota.ToString())
         .Append(";")
         .Append(Me.FechaEmision.ToShortDateString())
         .Append(";")
         .Append(Me.FechaVencimiento.ToShortDateString())
         .Append(";")
         .Append(Me.ImporteCuota.ToString(Formatos.Culturas.Argentina))
         .Append(";")
         .Append(Me.SaldoCuota.ToString(Formatos.Culturas.Argentina))
         .Append(";")
         .Append(Me.Observacion.ToString())

      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"


   'CodigoCliente;IdSucursal;IdTipoComprobante;Letra;CentroEmisor;NumeroComprobante;Cuota;FechaEmision;FechaVencimiento;ImporteCuota;SaldoCuota;Observacion

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

   Private _nombreVendedor As String
   Public Property NombreVendedor() As String
      Get
         Return Me._nombreVendedor
      End Get
      Set(ByVal value As String)
         Me._nombreVendedor = value
      End Set
   End Property

   Private _zonaGeografica As String
   Public Property ZonaGeografica() As String
      Get
         Return Me._zonaGeografica
      End Get
      Set(ByVal value As String)
         Me._zonaGeografica = value
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

   Private _cuota As Integer
   Public Property Cuota() As Integer
      Get
         Return _cuota
      End Get
      Set(ByVal value As Integer)
         _cuota = value
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

   Private _fechaVencimiento As Date
   Public Property FechaVencimiento() As Date
      Get
         Return Me._fechaVencimiento
      End Get
      Set(ByVal value As Date)
         Me._fechaVencimiento = value
      End Set
   End Property

   Private _importeCuota As Decimal = 0
   Public Property ImporteCuota() As Decimal
      Get
         Return (Me._importeCuota)
      End Get
      Set(ByVal value As Decimal)
         Me._importeCuota = value
      End Set
   End Property

   Private _saldoCuota As Decimal = 0
   Public Property SaldoCuota() As Decimal
      Get
         Return Me._saldoCuota
      End Get
      Set(ByVal value As Decimal)
         Me._saldoCuota = value
      End Set
   End Property

   Private _observacion As String
   Public Property Observacion() As String
      Get
         Return Me._observacion
      End Get
      Set(ByVal value As String)
         Me._observacion = value
      End Set
   End Property

#End Region

#Region "Propiedades ReadOnly"

   Public ReadOnly Property IdTipoComprobante() As String
      Get
         Return Me.TipoComprobante.IdTipoComprobante
      End Get
   End Property

#End Region

End Class

