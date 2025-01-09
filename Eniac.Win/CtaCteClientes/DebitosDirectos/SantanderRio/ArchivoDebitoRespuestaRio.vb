#Region "Imports"
Imports System.Text
Imports System.IO
Imports System.Globalization
#End Region
Public Class ArchivoDebitoRespuestaRio

#Region "Propiedades"

   Private _TipoDeRegistro As String
   ''' <summary>
   ''' Fijo ‘20’ 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property TipoDeRegistro() As String
      Get
         Return _TipoDeRegistro
      End Get
      Set(ByVal value As String)
         _TipoDeRegistro = value
      End Set
   End Property

   Private _fechaPresentacion As DateTime
   ''' <summary>
   ''' AAAAMMDD 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FechaPresentacion() As DateTime
      Get
         Return _fechaPresentacion
      End Get
      Set(ByVal value As DateTime)
         _fechaPresentacion = value
      End Set
   End Property

   Private _cantidadDeRegistros As Integer
   ''' <summary>
   '''Cantidad de Registros ‘21’ 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CantidadDeRegistros() As Integer
      Get
         Return _cantidadDeRegistros
      End Get
      Set(ByVal value As Integer)
         _cantidadDeRegistros = value
      End Set
   End Property

   Private _ImporteTotal As Decimal
   ''' <summary>
   ''' 17 enteros + 2 decimales . Sin punto
   '''Sumatoria importes registros ‘21’ 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ImporteTotal() As Decimal
      Get
         Return _ImporteTotal
      End Get
      Set(ByVal value As Decimal)
         _ImporteTotal = value
      End Set
   End Property

   Private _datos As List(Of ArchivoDebitoRespuestaRioDatos)
   Public Property Datos() As List(Of ArchivoDebitoRespuestaRioDatos)
      Get
         If Me._datos Is Nothing Then
            Me._datos = New List(Of ArchivoDebitoRespuestaRioDatos)()
         End If
         Return _datos
      End Get
      Set(ByVal value As List(Of ArchivoDebitoRespuestaRioDatos))
         _datos = value
      End Set
   End Property

#End Region

#Region "Metodos Publicos"
   Public Function GetInfo(archivoFisico As StreamReader) As ArchivoDebitoRespuestaRio

      Dim linea As String
      Dim arDa As ArchivoDebitoRespuestaRioDatos = New ArchivoDebitoRespuestaRioDatos()
      linea = archivoFisico.ReadLine()
      'leo la primer linea, la cual tengo que recuperar la información de la cabecera

      Me.TipoDeRegistro = linea.Substring(0, 2)
      ' AAAAMMDD 
      Me.FechaPresentacion = New DateTime(Int32.Parse(linea.Substring(2, 4)), Int32.Parse(linea.Substring(6, 2)), Int32.Parse(linea.Substring(8, 2)))
      'Cantidad de Registros ‘11’ 
      Me.CantidadDeRegistros = Integer.Parse(linea.Substring(10, 5))
      ' 17 enteros + 2 decimales . Sin punto. Sumatoria importes registros ‘11’ 
      Me.ImporteTotal = Decimal.Parse(linea.Substring(15, 19)) / 100

      linea = archivoFisico.ReadLine()
      Do While linea IsNot Nothing
         Me.Datos.Add(New ArchivoDebitoRespuestaRioDatos().GetDato(linea))
         linea = archivoFisico.ReadLine()
      Loop

      Return Me
   End Function

#End Region

End Class

Public Class ArchivoDebitoRespuestaRioDatos

#Region "Campos"

   Private _stb As StringBuilder

#End Region

#Region "Constructores"

   Public Sub New()
      Me._stb = New StringBuilder()
   End Sub

#End Region

#Region "Propiedades"

   Private _TipoDeRegistro As String
   ''' <summary>
   ''' Fijo ‘10’ 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property TipoDeRegistro() As String
      Get
         Return _TipoDeRegistro
      End Get
      Set(ByVal value As String)
         _TipoDeRegistro = value
      End Set
   End Property


   Private _Servicio As String
   ''' <summary>
   ''' Código de Servicio definido en Banco Río
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Servicio() As String
      Get
         If Me._Servicio.Length > 10 Then
            Return Me._Servicio.Substring(0, 10)
         Else
            Return _Servicio
         End If
      End Get
      Set(ByVal value As String)
         _Servicio = value
      End Set
   End Property

   Private _Partida As Long
   ''' <summary>
   '''Nro. de Cliente definido por la Empresa.
   '''Alineado a la izquierda, completado con
   '''espacios 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Partida() As Long
      Get
         'If Me._Partida.Length > 22 Then
         Return Me._Partida
         'Else
         Return _Partida
         'End If
      End Get
      Set(ByVal value As Long)
         _Partida = value
      End Set
   End Property

   Private _nombreCliente As String = String.Empty
   Public Property NombreCliente() As String
      Get
         Return Me._nombreCliente
      End Get
      Set(ByVal value As String)
         Me._nombreCliente = value
      End Set
   End Property

   Private _CBU As String
   ''' <summary>
   ''' Totalmente completo 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CBU() As String
      Get
         Return _CBU
      End Get
      Set(ByVal value As String)
         _CBU = value
      End Set
   End Property

   Private _fechaDeVencimiento As DateTime
   ''' <summary>
   ''' AAAAMMDD 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FechaDeVencimiento() As DateTime
      Get
         Return _fechaDeVencimiento
      End Get
      Set(ByVal value As DateTime)
         _fechaDeVencimiento = value
      End Set
   End Property

   Private _importeDebito As Decimal
   ''' <summary>
   ''' 14 enteros + 2 decimales. Sin punto. 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ImporteDebito() As Decimal
      Get
         Return _importeDebito
      End Get
      Set(ByVal value As Decimal)
         _importeDebito = value
      End Set
   End Property

   Private _identificacionDebito As String = String.Empty
   ''' <summary>
   ''' Referencia unívoca del débito 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property IdentificacionDebito() As String
      Get
         If Me._identificacionDebito.Length > 16 Then
            Return Me._identificacionDebito.Substring(0, 16)
         Else
            Return _identificacionDebito
         End If
      End Get
      Set(ByVal value As String)
         _identificacionDebito = value
      End Set
   End Property

   Private _CodigoError As String = String.Empty
   ''' <summary>
   ''' Nombre del Adherente 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CodigoError() As String
      Get
         If Me._CodigoError.Length > 3 Then
            Return Me._CodigoError.Substring(0, 3)
         Else
            Return _CodigoError
         End If
      End Get
      Set(ByVal value As String)
         _CodigoError = value
      End Set
   End Property

   Private _ReferenciaEmpresa As String = String.Empty
   ''' <summary>
   ''' Dato libre de la empresa. 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ReferenciaEmpresa() As String
      Get
         If Me._ReferenciaEmpresa.Length > 50 Then
            Return Me._ReferenciaEmpresa.Substring(0, 50)
         Else
            Return _ReferenciaEmpresa
         End If
      End Get
      Set(ByVal value As String)
         _ReferenciaEmpresa = value
      End Set
   End Property

#End Region

#Region "Metodos Publicos"

   Public Function GetDato(linea As String) As ArchivoDebitoRespuestaRioDatos

      Dim oCliente As Entidades.Cliente
      Dim regCli As Reglas.Clientes = New Reglas.Clientes()

      Dim dato As ArchivoDebitoRespuestaRioDatos = New ArchivoDebitoRespuestaRioDatos()
      With dato

         ' Fijo ‘21’ 
         dato.TipoDeRegistro = linea.Substring(0, 2)
         ' Código de Servicio definido en Banco Río
         dato.Servicio = linea.Substring(2, 10)
         'Nro. de Cliente definido por la Empresa. Alineado a la izquierda, completado con espacios    
         dato.Partida = Long.Parse(linea.Substring(12, 22))
         oCliente = regCli.GetUnoPorCodigo(Long.Parse(dato.Partida.ToString.Trim()))
         dato.NombreCliente = oCliente.NombreCliente
         ' Totalmente completo 
         dato.CBU = linea.Substring(34, 22)
         ' AAAAMMDD 
         dato.FechaDeVencimiento = New DateTime(Int32.Parse(linea.Substring(56, 4)), Int32.Parse(linea.Substring(60, 2)), Int32.Parse(linea.Substring(62, 2)))
         ' 14 enteros + 2 decimales. Sin punto. 
         dato.ImporteDebito = Decimal.Parse(linea.Substring(64, 16)) / 100
         ' Referencia unívoca del débito 
         dato.IdentificacionDebito = linea.Substring(80, 15)
         ' Nombre del Adherente 
         dato.CodigoError = linea.Substring(95, 3)
         ' Dato libre de la empresa. 
         dato.ReferenciaEmpresa = linea.Substring(98, 50)

      End With

      Return dato
   End Function

#End Region

End Class