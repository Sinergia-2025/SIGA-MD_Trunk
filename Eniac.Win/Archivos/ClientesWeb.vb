Imports System.Text
Imports System.IO

Public Class ClientesWeb

#Region "Propiedades"

   Private _lineas As List(Of ClientesWebLinea)
   Public ReadOnly Property Lineas() As List(Of ClientesWebLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of ClientesWebLinea)()
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

         'stb.AppendLine("cuitempresa;cuitcliente;codigo;nombre;direccion;cp;telefono;celular;email;categoria;categoriafiscal;vendedor;listadeprecios;zona;doc;numerodoc;observacion")
         stb.AppendLine("cuitcliente;codigo;nombre;direccion;cp;telefono;celular;email;categoria;categoriafiscal;vendedor;listadeprecios;zona;doc;numerodoc;observacion;idvendedor")

         For Each linea As ClientesWebLinea In Lineas

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

Public Class ClientesWebLinea

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

         ' cuitempresa;cuitcliente;codigo;nombre;direccion;cp;telefono;celular;email;categoria;categoriafiscal;vendedor;listadeprecios;zona;doc;numerodoc;observacion

         .Length = 0
         '.Append(Me.CuitEmpresa.ToString())
         '.Append(";")
         .AppendFormat(Me.Cuit.ToString())
         .Append(";")
         .AppendFormat(Me.CodigoCliente.ToString())
         .Append(";")
         .Append(Me.NombreCliente.ToString())
         .Append(";")
         .Append(Me.Direccion.ToString())
         .Append(";")
         .AppendFormat(Me.IdLocalidad.ToString())
         .Append(";")
         .Append(Me.Telefono.ToString())
         .Append(";")
         .Append(Me.Celular.ToString())
         .Append(";")
         .Append(Me.CorreoElectronico.ToString())
         .Append(";")
         .Append(Me.NombreCategoria)
         .Append(";")
         .Append(Me.CategoriaFiscal.NombreCategoriaFiscal.ToString())
         .Append(";")
         .Append(Me.Vendedor.NombreEmpleado.ToString())
         .Append(";")
         .Append(Me.NombreListaPrecios)
         .Append(";")
         .Append(Me.ZonaGeografica.NombreZonaGeografica.ToString())
         .Append(";")
         .Append(Me.TipoDocCliente.ToString())
         .Append(";")
         .Append(Me.NroDocCliente.ToString())
         .Append(";")
         .Append(Me.Observacion)
         .Append(";")
         .Append(Me.IdVendedor)

      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"


   Private _procesar As Boolean = False
   Public Property Procesar() As Boolean
      Get
         Return _procesar
      End Get
      Set(ByVal value As Boolean)
         _procesar = value
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

   Private _cuitEmpresa As String = String.Empty
   Public Property CuitEmpresa() As String
      Get
         Return Me._cuitEmpresa
      End Get
      Set(ByVal value As String)
         Me._cuitEmpresa = value.Trim()
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

      Private _CodigoCliente As Long
   Public Property CodigoCliente() As Long
      Get
         Return _CodigoCliente
      End Get
      Set(ByVal value As Long)
         _CodigoCliente = value
      End Set
   End Property

   Private _nombreCliente As String = ""
   Public Property NombreCliente() As String
      Get
         Return Me._nombreCliente
      End Get
      Set(ByVal value As String)
         Me._nombreCliente = value.Trim()
      End Set
   End Property

   Private _direccion As String = ""
   Public Property Direccion() As String
      Get
         Return Me._direccion
      End Get
      Set(ByVal value As String)
         If value.Length > 100 Then
            System.Windows.Forms.MessageBox.Show("El ancho de la dirección no puede exceder los 100 caracteres")
            Throw New Exception("El ancho de la dirección no puede exceder los 100 caracteres")
         Else
            Me._direccion = value.Trim()
         End If
      End Set
   End Property

   Private _localidad As Entidades.Localidad
   Public Property Localidad() As Entidades.Localidad
      Get
         If Me._localidad Is Nothing Then
            Me._localidad = New Entidades.Localidad()
         End If
         Return Me._localidad
      End Get
      Set(ByVal value As Entidades.Localidad)
         Me._localidad = value
      End Set
   End Property

   Private _idLocalidad As Integer = 0
   Public ReadOnly Property IdLocalidad() As Integer
      Get
         Return Me.Localidad.IdLocalidad
      End Get
   End Property

   Private _telefono As String = ""
   Public Property Telefono() As String
      Get
         Return Me._telefono
      End Get
      Set(ByVal value As String)
         Me._telefono = value.Trim()
      End Set
   End Property

   Private _celular As String = ""
   Public Property Celular() As String
      Get
         Return Me._celular
      End Get
      Set(ByVal value As String)
         Me._celular = value.Trim()
      End Set
   End Property

   Private _correoElectronico As String = ""
   Public Property CorreoElectronico() As String
      Get
         Return Me._correoElectronico
      End Get
      Set(ByVal value As String)
         Me._correoElectronico = value.Trim()
      End Set
   End Property

   Private _nombreCategoria As String = String.Empty
   Public Property NombreCategoria() As String
      Get
         Return _nombreCategoria
      End Get
      Set(ByVal value As String)
         _nombreCategoria = value
      End Set
   End Property

   Private _categoriaFiscal As Entidades.CategoriaFiscal
   Public Property CategoriaFiscal() As Entidades.CategoriaFiscal
      Get
         If _categoriaFiscal Is Nothing Then
            _categoriaFiscal = New Entidades.CategoriaFiscal()
         End If
         Return _categoriaFiscal
      End Get
      Set(ByVal value As Entidades.CategoriaFiscal)
         _categoriaFiscal = value
      End Set
   End Property

   Private _vendedor As Entidades.Empleado
   Public Property Vendedor() As Entidades.Empleado
      Get
         If Me._vendedor Is Nothing Then
            Me._vendedor = New Entidades.Empleado()
         End If
         Return _vendedor
      End Get
      Set(ByVal value As Entidades.Empleado)
         _vendedor = value
      End Set
   End Property

   Private _idListaPrecios As Integer
   Public Property IdListaPrecios() As Integer
      Get
         Return _idListaPrecios
      End Get
      Set(ByVal value As Integer)
         _idListaPrecios = value
      End Set
   End Property

   Private _nombreListaPrecios As String
   Public Property NombreListaPrecios() As String
      Get
         Return _nombreListaPrecios
      End Get
      Set(ByVal value As String)
         _nombreListaPrecios = value
      End Set
   End Property

   Private _zonaGeografica As Entidades.ZonaGeografica
   Public Property ZonaGeografica() As Entidades.ZonaGeografica
      Get
         If Me._zonaGeografica Is Nothing Then
            Me._zonaGeografica = New Entidades.ZonaGeografica()
         End If
         Return _zonaGeografica
      End Get
      Set(ByVal value As Entidades.ZonaGeografica)
         _zonaGeografica = value
      End Set
   End Property

   Private _tipoDocCliente As String = ""

   Public Property TipoDocCliente() As String
      Get
         Return Me._tipoDocCliente
      End Get
      Set(ByVal value As String)
         Me._tipoDocCliente = value
      End Set
   End Property

   Private _nroDocCliente As Long = 0
   Public Property NroDocCliente() As Long
      Get
         Return Me._nroDocCliente
      End Get
      Set(ByVal value As Long)
         Me._nroDocCliente = value
      End Set
   End Property

   Private _observacion As String = String.Empty
   Public Property Observacion() As String
      Get
         Return Me._observacion
      End Get
      Set(ByVal value As String)
         Me._observacion = value.Trim()
      End Set
   End Property

   Public Property IdVendedor() As Integer

#End Region

End Class

