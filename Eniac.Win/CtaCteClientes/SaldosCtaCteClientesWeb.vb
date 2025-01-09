Imports System.Text
Imports System.IO

Public Class SaldosCtaCteClientesWeb

#Region "Propiedades"

   Private _lineas As List(Of SaldosCtaCteClientesWebLinea)
   Public ReadOnly Property Lineas() As List(Of SaldosCtaCteClientesWebLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of SaldosCtaCteClientesWebLinea)()
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

         stb.AppendLine("categoria;idcliente;cliente;cuit;D.P.V;D.Pr;Saldo;Telefono(s);Vencido;vendedor;zona geograf.")

         For Each linea As SaldosCtaCteClientesWebLinea In Lineas

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

Public Class SaldosCtaCteClientesWebLinea

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

         'categoria;idcliente;cliente;cuit;//D.P.V;D.Pr;Saldo;Telefono(s);Vencido;vendedor;zona geograf.

         .Length = 0
         .Append(Me.Categoria.ToString())
         .Append(";")
         .AppendFormat(Me.IdCliente.ToString())
         .Append(";")
         .AppendFormat(Me.NombreCliente.ToString())
         .Append(";")
         .Append(Me.Cuit.ToString())
         .Append(";")
         .Append(Me.Dpv.ToString())
         .Append(";")
         .Append(Me.Dpr.ToString())
         .Append(";")
         .Append(Me.Saldo.ToString(Formatos.Culturas.Argentina))
         .Append(";")
         .Append(Me.Telefonos.ToString())
         .Append(";")
         .Append(Me.Vencido.ToString(Formatos.Culturas.Argentina))
         .Append(";")
         .Append(Me.NombreVendedor.ToString())
         .Append(";")
         .Append(Me.ZonaGeografica.ToString())

      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"


   'categoria;idcliente;cliente;cuit;D.P.V;D.Pr;Saldo;Telefono(s);Vencido;vendedor;zona geograf.

   Private _categoria As String
   Public Property Categoria() As String
      Get
         Return Me._categoria
      End Get
      Set(ByVal value As String)
         Me._categoria = value
      End Set
   End Property

   Private _procesar As Boolean = False
   Public Property Procesar() As Boolean
      Get
         Return _procesar
      End Get
      Set(ByVal value As Boolean)
         _procesar = value
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

   Private _nombreCliente As String
   Public Property NombreCliente() As String
      Get
         Return _nombreCliente
      End Get
      Set(ByVal value As String)
         _nombreCliente = value.Trim()
      End Set
   End Property

   Private _cuit As String = String.Empty
   Public Property Cuit() As String
      Get
         Return Me._cuit
      End Get
      Set(ByVal value As String)
         Me._cuit = value.Trim()
      End Set
   End Property

   Private _dpv As String
   Public Property Dpv() As String
      Get
         Return _dpv
      End Get
      Set(ByVal value As String)
         _dpv = value
      End Set
   End Property

   Private _dpr As Integer = 0
   Public Property Dpr() As Integer
      Get
         Return _dpr
      End Get
      Set(ByVal value As Integer)
         _dpr = value
      End Set
   End Property

   Private _saldo As Decimal = 0

   Public Property Saldo() As Decimal
      Get
         Return Me._saldo
      End Get
      Set(ByVal value As Decimal)
         Me._saldo = value
      End Set
   End Property

   Private _telefonos As String
   Public Property Telefonos() As String
      Get
         Return Me._telefonos
      End Get
      Set(ByVal value As String)
         Me._telefonos = value.Trim()
      End Set
   End Property

   Private _vencido As Decimal = 0

   Public Property Vencido() As Decimal
      Get
         Return Me._vencido
      End Get
      Set(ByVal value As Decimal)
         Me._vencido = value
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

#End Region

End Class

