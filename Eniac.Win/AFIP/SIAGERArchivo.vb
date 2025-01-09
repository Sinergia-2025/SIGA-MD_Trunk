Imports System.Text
Imports System.IO

Public Class SIAGERArchivo

#Region "Propiedades"

   Private _lineas As List(Of SIAGERArchivoLinea)
   Public ReadOnly Property Lineas() As List(Of SIAGERArchivoLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of SIAGERArchivoLinea)()
         End If
         Return _lineas
      End Get
   End Property

   Public ReadOnly Property CantidadDeLineasaProcesar() As Integer
      Get
         Dim cant As Integer = 0
         For Each li As SIAGERArchivoLinea In Me.Lineas
            If li.Procesar Then
               cant += 1
            End If
         Next
         Return cant
      End Get
   End Property

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarArchivo(ByVal destino As String)
      Dim stb As StringBuilder
      Try
         stb = New StringBuilder()

         For Each linea As SIAGERArchivoLinea In Lineas
            stb.Append(linea.GetLinea()).AppendLine()
         Next

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

      Catch ex As Exception
         Throw
      End Try
   End Sub

#End Region

End Class

Public Class SIAGERArchivoLinea

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

         .AppendFormat(Me.TipoAgente.ToString("0"))
         .AppendFormat(Me.MotivoMovimiento.ToString("00"))
         .AppendFormat(Me.CUITCliente.ToString("00000000000"))
         .AppendFormat(Me.FechaPercepcion.ToString("dd/MM/yyyy"))
         .AppendFormat(Me.IdTipoComprobante.PadLeft(6))
         .AppendFormat(Me.LetraComprobante.PadRight(1))
         .AppendFormat(Me.CentroEmisor.ToString("0000").PadRight(4))
         .AppendFormat(Me.NroComprobante.ToString("00000000").PadRight(8))
         .AppendFormat(Me.ImporteBase.ToString("000000000000.00").Replace(".", ","))
         .AppendFormat(Me.Alicuota.ToString("000.00").Replace(".", ","))
         .AppendFormat(Me.ImpuestoPercibido.ToString("000000000000.00").Replace(".", ","))
         .AppendFormat(Me.Anulacion.ToString("0"))
         .AppendFormat(Me.ContribuyenteConvMultilateral.ToString("0"))

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

   Private _TipoAgente As Short
   ''' <summary>
   ''' Tipo de Agente: Numérico de 1 posición
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property TipoAgente() As Short
      Get
         Return _TipoAgente
      End Get
      Set(ByVal value As Short)
         _TipoAgente = value
      End Set
   End Property


   Private _MotivoMovimiento As Integer
   ''' <summary>
   ''' Motivo Movimiento:  Numérico de 2 posiciones
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property MotivoMovimiento() As Integer
      Get
         Return _MotivoMovimiento
      End Get
      Set(ByVal value As Integer)
         _MotivoMovimiento = value
      End Set
   End Property


   Private _CUITCliente As Long
   ''' <summary>
   ''' CUIT del Cliente.  Numérico de 11 posiciones.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CUITCliente() As Long
      Get
         Return _CUITCliente
      End Get
      Set(ByVal value As Long)
         _CUITCliente = value
      End Set
   End Property


   Private _fechaPercepcion As DateTime
   ''' <summary>
   ''' Fecha Percepcion: debe pertenecer a la quincena que está declarando
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FechaPercepcion() As DateTime
      Get
         Return _fechaPercepcion
      End Get
      Set(ByVal value As DateTime)
         _fechaPercepcion = value
      End Set
   End Property

   Private _idTipoComprobante As String = String.Empty
   ''' <summary>
   ''' Es el tipo de comprobante del SIGA.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property IdTipoComprobante() As String
      Get
         Return _idTipoComprobante
      End Get
      Set(ByVal value As String)
         _idTipoComprobante = value
      End Set
   End Property

   Private _letraComprobante As String = String.Empty
   ''' <summary>
   ''' Letra de comprobante: Será obligatorio si se trata de factura o certificado de obra, de lo contrario puede ser espacio en blanco. 
   ''' Alfanumérico de 1 posición.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property LetraComprobante() As String
      Get
         Return _letraComprobante
      End Get
      Set(ByVal value As String)
         _letraComprobante = value
      End Set
   End Property

   Private _nroComprobante As Long
   ''' <summary>
   ''' Nro. del comprobante. 
   ''' Obligatorio. Para factura o certificado de obra los 4 primeros dígitos corresponden al número de sucursal y 
   ''' los 8 dígitos restantes para el número de emisión del comprobante, sumando 12 posiciones en total, 
   ''' las cuatro posiciones restantes (para completar las 16 posiciones del nro. de comprobante) 
   ''' deberán completarse con blancos, quedando el nro. de comprobante alineado a izquierda. 
   ''' En caso de que el comprobante sea constancia de retención (código 08), 
   ''' deberá ingresarse el nro de la siguiente manera: 4 dígitos para la sucursal, 4 dígitos para el año, 
   ''' 6 dígitos para el número, sumando 14 posiciones, las dos posiciones restantes deberán completarse con blancos.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NroComprobante() As Long
      Get
         Return _nroComprobante
      End Get
      Set(ByVal value As Long)
         _nroComprobante = value
      End Set
   End Property

   Private _centroEmisor As Short
   
   Public Property CentroEmisor() As Short
      Get
         Return _centroEmisor
      End Get
      Set(ByVal value As Short)
         _centroEmisor = value
      End Set
   End Property

   Private _importeBase As Decimal
   ''' <summary>
   ''' Importe Base Numérico 9 enteros 2 decimales separados por comas.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ImporteBase() As Decimal
      Get
         Return System.Math.Abs(_importeBase)
      End Get
      Set(ByVal value As Decimal)
         _importeBase = value
      End Set
   End Property

   Private _alicuota As Decimal
   ''' <summary>
   ''' Alícuota: se validarán las permitidas por el código fiscal, 
   ''' Si el sujeto retenido pertenece al convenio multilateral, y se optó por la opción del art. 5to. Inc.1 (RG 015/97 y modif.) 
   ''' corresponderá una alícuota del 0,7; pero si se retiene por el artículo 1 inc.j, entonces corresponderá ingresar una 
   ''' alícuota del 2,5.  Por no inscripto, obligado a inscribirse en ingresos brutos se controlará que sean las 
   ''' permitidas por el código fiscal incrementadas en un 50%.  Además, si en "Tipo de exención" se ingresa un 
   ''' número distinto de 0 (cuando el sujeto retenido es exento), se podrá colocar 00,00 en alícuota o cualquiera de las 
   ''' permitidas por el código fiscal.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Alicuota() As Decimal
      Get
         Return _alicuota
      End Get
      Set(ByVal value As Decimal)
         _alicuota = value
      End Set
   End Property

   Private _impuestoPercibido As Decimal
   ''' <summary>
   ''' Impuesto determinado: se controlará que sea igual al Monto imponible por la Alícuota. 
   ''' (Numérico de 9 enteros 2 decimales separados por comas).
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ImpuestoPercibido() As Decimal
      Get
         Return System.Math.Abs(_impuestoPercibido)
      End Get
      Set(ByVal value As Decimal)
         _impuestoPercibido = value
      End Set
   End Property

   Private _Anulacion As Short
   ''' <summary>
   ''' Anulacion: Numérico de 1 posición
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Anulacion() As Short
      Get
         Return _Anulacion
      End Get
      Set(ByVal value As Short)
         _Anulacion = value
      End Set
   End Property

   Private _ContribuyenteConvMultilateral As Short
   ''' <summary>
   ''' _Contribuyente Conv Multilateral: Numérico de 1 posición
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ContribuyenteConvMultilateral() As Short
      Get
         Return _ContribuyenteConvMultilateral
      End Get
      Set(ByVal value As Short)
         _ContribuyenteConvMultilateral = value
      End Set
   End Property


#End Region

End Class
