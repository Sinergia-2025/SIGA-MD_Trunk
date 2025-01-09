Imports System.Text
Imports System.IO

Public Class SIPRIBArchivo

#Region "Metodos Privados"


#End Region

#Region "Propiedades"

   Private _lineas As List(Of SIPRIBArchivoLinea)
   Public ReadOnly Property Lineas() As List(Of SIPRIBArchivoLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of SIPRIBArchivoLinea)()
         End If
         Return _lineas
      End Get
   End Property

   Public ReadOnly Property CantidadDeLineasaProcesar() As Integer
      Get
         Dim cant As Integer = 0
         For Each li As SIPRIBArchivoLinea In Me.Lineas
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

         For Each linea As SIPRIBArchivoLinea In Lineas
            stb.Append(linea.GetLinea()).AppendLine()
         Next

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

      Catch ex As Exception
         Throw
      End Try
   End Sub

#End Region

End Class

Public Class SIPRIBArchivoLinea

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
         'Código operación: Numérico de 1 posición
         .AppendFormat(Me.CodigoOperacion.ToString("0"))
         'Fecha de la Retención: debe pertenecer a la quincena que está declarando
         .AppendFormat(Me.FechaDeLaRetencion.ToString("dd/MM/yyyy"))
         'Código de Artículo/Inciso por el que retiene:  Numérico de 3 posiciones
         .AppendFormat(Me.CodigoArticulo.ToString("000"))
         'Código de comprobante:
         .AppendFormat(Me.CodigoComprobante.ToString("00"))
         'Letra de comprobante: Será obligatorio si se trata de factura o certificado de obra, de lo contrario puede ser espacio en blanco. 
         'Alfanumérico de 1 posición.
         .AppendFormat(Me.LetraComprobante.PadRight(1))
         'Nro. del comprobante. Obligatorio. Para factura o certificado de obra los 4 primeros dígitos corresponden 
         'al número de sucursal y los 8 dígitos restantes para el número de emisión del comprobante, 
         'sumando 12 posiciones en total, las cuatro posiciones restantes (para completar las 16 posiciones 
         'del nro. de comprobante) deberán completarse con blancos, quedando el nro. de comprobante alineado 
         'a izquierda. En caso de que el comprobante sea constancia de retención (código 08), 
         'deberá ingresarse el nro de la siguiente manera: 4 dígitos para la sucursal, 4 dígitos para el año, 
         '6 dígitos para el número, sumando 14 posiciones, las dos posiciones restantes deberán completarse con blancos.
         .AppendFormat(Me.NroComprobante.ToString("000000000000").PadRight(16))
         'Fecha de emisión comprobante (menor o igual a la fecha de la retención/percepción).
         .AppendFormat(Me.FechaEmisionComprobante.ToString("dd/MM/yyyy"))

         'Importe comprobante (debe ser mayor a 0). Numérico 11 enteros 2 decimales separados por comas.
         .AppendFormat(Me.ImporteComprobante.ToString("000000000000.00").Replace(",", "").Replace(".", ","))

         'Tipo documento retenido/percibido. Numérico de 1 posición
         .AppendFormat(Me.TipoDocPercibido.ToString("0"))
         'Nro. documento retenido/percibido. Se validará según el tipo. Numérico 11 posiciones.
         .AppendFormat(Me.NroDocPercibido.ToString("00000000000"))
         'Condición frente a Ingresos Brutos: Numérico de 1 posición 
         .AppendFormat(Me.CondicionFrenteAIIBB.ToString("0"))
         'Nro de inscripción en Ingresos Brutos: será exigido si condición frente a ingresos brutos es 1, de lo contrario deberá ingresar ceros.  Numérico de 10 posiciones.
         .AppendFormat(Me.NroInscripcionIIBB.ToString("0000000000"))
         'Situación frente a IVA: Numérico de 1 posición.
         .AppendFormat(Me.SituacionFrenteAIVA.ToString("0"))
         'Marca inscripción en otros gravámenes (Artículo 138 Código Fiscal): Numérico de 1 posición
         .AppendFormat(Me.MarcaInscripcionEnOtrosGravamenes.ToString("0"))
         'Marca inscripción en Derecho de Registro e Inspección: Numérico de 1 posición
         .AppendFormat(Me.MarcaInscDerechoRegistroInspeccion.ToString("0"))
         'Importe Otros Gravámenes aquí corresponde colocar el importe ingresado en concepto de otros gravámenes incluídos 
         'en el artículo 138 del Código Fiscal, siempre que marca de inscripción en otros gravámenes sea igual a 1. 
         'Caso contrario deberá ingresar ceros (Numérico de 9 enteros 2 decimales separados por comas).
         .AppendFormat(Me.ImporteOtrosGravamenes.ToString("0000000000.00").Replace(",", "").Replace(".", ","))
         'Importe I.V.A. aquí corresponde colocar el importe ingresado en concepto de IVA si correspondiere, 
         'es decir, si situación frente a IVA es igual a 1. Caso contrario deberá ingresar ceros 
         '(Numérico de 9 enteros 2 decimales separados por comas).
         .AppendFormat(Me.ImporteIVA.ToString("0000000000.00").Replace(",", "").Replace(".", ","))
         'Monto imponible: se controlará de la misma forma que la especificada para el ingreso. 
         '(Numérico de 9 enteros 2 decimales separados por comas).
         .AppendFormat(Me.MontoImponible.ToString("000000000000.00").Replace(",", "").Replace(".", ","))
         'Alícuota: se validarán las permitidas por el código fiscal, Si el sujeto retenido pertenece al convenio multilateral, 
         'y se optó por la opción del art. 5to. Inc.1 (RG 015/97 y modif.) corresponderá una alícuota del 0,7; 
         'pero si se retiene por el artículo 1 inc.j, entonces corresponderá ingresar una alícuota del 2,5.  
         'Por no inscripto, obligado a inscribirse en ingresos brutos se controlará que sean las permitidas por el código 
         'fiscal incrementadas en un 50%.  Además, si en "Tipo de exención" se ingresa un número distinto de 0 
         '(cuando el sujeto retenido es exento), se podrá colocar 00,00 en alícuota o cualquiera de las permitidas por el código fiscal.
         .AppendFormat(Me.Alicuota.ToString("00.00").Replace(",", "").Replace(".", ","))
         'Impuesto determinado: se controlará que sea igual al Monto imponible por la Alícuota. 
         '(Numérico de 9 enteros 2 decimales separados por comas).
         .AppendFormat(Me.ImpuestoDeterminado.ToString("000000000000.00").Replace(",", "").Replace(".", ","))
         'Monto deducible derecho de registro e inspección: si marca de derecho de registro e inspección está en 0, 
         'este deberá ser ceros. Si marca de derecho de registro e inspección es 1, entonces para que se permita un 
         'importe distinto de ceros, debe ser una retención y retener por el artículo 1° inciso k o l, ó bien, 
         'debe utilizarse para el cálculo el arículo 5° 1er. párrafo. (Numérico de 9 enteros 2 decimales separados por comas).
         .AppendFormat(Me.MontoDeducible.ToString("000000000.00").Replace(",", "").Replace(".", ","))
         'Monto retenido: se controlará que sea la resta entre Impuesto Determinado y derecho de registro e inspección. 
         '(Numérico de 9 enteros 2 decimales separado por comas).
         .AppendFormat(Me.MontoRetenido.ToString("000000000000.00").Replace(",", "").Replace(".", ","))
         'Artículo/Inciso para el cálculo del monto de la retención/percepción: Numérico de 3 posiciones.  
         .AppendFormat(Me.ArticuloParaPercepcion.ToString("000"))
            'Tipo de exención: numérico de 1
            .AppendFormat(Me.TipoDeExension.ToString("0"))
            'Año de exención:  numérico de 4 posiciones
            .AppendFormat(Me.AñoDeExension.ToString("0000"))
            'Número de certificado de exención: alfanumérico de 6 posiciones
            .AppendFormat(Me.NumeroCertificadoExencion.PadRight(6))
            'Número de certificado propio:  alfanumérico de 12 posiciones
            .AppendFormat(Me.NumeroCertificadoPropio.PadRight(12))

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

   Private _codigoOperacion As Short
   ''' <summary>
   ''' Código operación: Numérico de 1 posición
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CodigoOperacion() As Short
      Get
         Return _codigoOperacion
      End Get
      Set(ByVal value As Short)
         _codigoOperacion = value
      End Set
   End Property

   Private _fechaDeLaRetencion As datetime
   ''' <summary>
   ''' Fecha de la Retención: debe pertenecer a la quincena que está declarando
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FechaDeLaRetencion() As datetime
      Get
         Return _fechaDeLaRetencion
      End Get
      Set(ByVal value As datetime)
         _fechaDeLaRetencion = value
      End Set
   End Property
   Private _codigoArticulo As Integer
   ''' <summary>
   ''' Código de Artículo/Inciso por el que retiene:  Numérico de 3 posiciones
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CodigoArticulo() As Integer
      Get
         Return _codigoArticulo
      End Get
      Set(ByVal value As Integer)
         _codigoArticulo = value
      End Set
   End Property

   ''' <summary>
   ''' Código de comprobante
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property CodigoComprobante() As Integer
      Get
         Select Case Me.IdTipoComprobante
            Case Entidades.TipoComprobante.Tipos.FACT.ToString(), Entidades.TipoComprobante.Tipos.eFACT.ToString() 'Factura
               Return 1 'Nota de Débito
            Case Entidades.TipoComprobante.Tipos.NDEB.ToString(), Entidades.TipoComprobante.Tipos.eNDEB.ToString() '"NDEB"
               Return 2
            Case "PAGO" 'Orden de Pago
               Return 3
               '04	Boleta de depósito
               '05	Liquidación de pago
               '06	Certificado de Obra
            Case "RECIBO"   'Recibo
               Return 7
               '08	Constancia de Retención
               '09 Otros comprobantes
               '10 Reintegro
               'Case Entidades.TipoComprobante.Tipos.NCRED.ToString(), Entidades.TipoComprobante.Tipos.eNCRED.ToString()
               '   Return 10
            Case Else   'Otro(comprobante)
               Return 9
         End Select
      End Get
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

   Private _nroComprobante As Decimal
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
   Public Property NroComprobante() As Decimal
      Get
         Return _nroComprobante
      End Get
      Set(ByVal value As Decimal)
         _nroComprobante = value
      End Set
   End Property

   Private _fechaEmisionComprobante As DateTime
   ''' <summary>
   ''' Fecha de emisión comprobante (menor o igual a la fecha de la retención/percepción).
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FechaEmisionComprobante() As DateTime
      Get
         Return _fechaEmisionComprobante
      End Get
      Set(ByVal value As DateTime)
         _fechaEmisionComprobante = value
      End Set
   End Property

   Private _importeComprobante As Decimal
   ''' <summary>
   ''' Importe comprobante (debe ser mayor a 0). Numérico 9 enteros 2 decimales separados por comas.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ImporteComprobante() As Decimal
      Get
         Return System.Math.Abs(_importeComprobante)
      End Get
      Set(ByVal value As Decimal)
         _importeComprobante = value
      End Set
   End Property

   Private _tipoDocPercibido As Short
   ''' <summary>
   ''' Tipo documento retenido/percibido. Numérico de 1 posición
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property TipoDocPercibido() As Short
      Get
         Return _tipoDocPercibido
      End Get
      Set(ByVal value As Short)
         _tipoDocPercibido = value
      End Set
   End Property

   Private _nroDocPercibido As Long
   ''' <summary>
   ''' Nro. documento retenido/percibido. Se validará según el tipo. Numérico 11 posiciones.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NroDocPercibido() As Long
      Get
         Return _nroDocPercibido
      End Get
      Set(ByVal value As Long)
         _nroDocPercibido = value
      End Set
   End Property

   Private _condicionFrenteAIIBB As Short
   ''' <summary>
   ''' Condición frente a Ingresos Brutos: Numérico de 1 posición 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CondicionFrenteAIIBB() As Short
      Get
         Return _condicionFrenteAIIBB
      End Get
      Set(ByVal value As Short)
         _condicionFrenteAIIBB = value
      End Set
   End Property

   Private _nroInscripcionIIBB As Long
   ''' <summary>
   ''' Nro de inscripción en Ingresos Brutos: será exigido si condición frente a ingresos brutos es 1, 
   ''' de lo contrario deberá ingresar ceros.  Numérico de 10 posiciones.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NroInscripcionIIBB() As Long
      Get
         Return _nroInscripcionIIBB
      End Get
      Set(ByVal value As Long)
         _nroInscripcionIIBB = value
      End Set
   End Property

   ''' <summary>
   ''' Situación frente a IVA: Numérico de 1 posición.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property SituacionFrenteAIVA() As Short
      Get
         Select Case Me.IdCategoriaFiscal
            Case 2 'Responsable inscripto
               Return 1
            Case 3 'Responsable no inscripto
               Return 2
            Case 4 'Exento
               Return 3
            Case 6 'Monotributista
               Return 4
            Case Else
               Return 0
         End Select
      End Get
   End Property

   Private _idCategoriaFiscal As Short
   ''' <summary>
   ''' Es la categoria fiscal de la aplicación SIGA
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property IdCategoriaFiscal() As Short
      Get
         Return _idCategoriaFiscal
      End Get
      Set(ByVal value As Short)
         _idCategoriaFiscal = value
      End Set
   End Property


   Private _marcaInscripcionEnOtrosGravamenes As Short
   ''' <summary>
   ''' Marca inscripción en otros gravámenes (Artículo 138 Código Fiscal): Numérico de 1 posición
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property MarcaInscripcionEnOtrosGravamenes() As Short
      Get
         Return _marcaInscripcionEnOtrosGravamenes
      End Get
      Set(ByVal value As Short)
         _marcaInscripcionEnOtrosGravamenes = value
      End Set
   End Property

   Private _marcaInscDerechoRegistroInspeccion As Short
   ''' <summary>
   ''' Marca inscripción en Derecho de Registro e Inspección: Numérico de 1 posición
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property MarcaInscDerechoRegistroInspeccion() As Short
      Get
         Return _marcaInscDerechoRegistroInspeccion
      End Get
      Set(ByVal value As Short)
         _marcaInscDerechoRegistroInspeccion = value
      End Set
   End Property

   Private _importeOtrosGravamentes As Decimal
   ''' <summary>
   ''' Importe Otros Gravámenes aquí corresponde colocar el importe ingresado en concepto de 
   ''' otros gravámenes incluídos en el artículo 138 del Código Fiscal, siempre que marca de 
   ''' inscripción en otros gravámenes sea igual a 1. 
   ''' Caso contrario deberá ingresar ceros (Numérico de 9 enteros 2 decimales separados por comas).
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ImporteOtrosGravamenes() As Decimal
      Get
         Return _importeOtrosGravamentes
      End Get
      Set(ByVal value As Decimal)
         _importeOtrosGravamentes = value
      End Set
   End Property

   Private _importeIVA As Decimal
   ''' <summary>
   ''' Importe I.V.A. aquí corresponde colocar el importe ingresado en concepto de IVA si correspondiere, 
   ''' es decir, si situación frente a IVA es igual a 1. 
   ''' Caso contrario deberá ingresar ceros (Numérico de 9 enteros 2 decimales separados por comas).
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ImporteIVA() As Decimal
      Get
         Return _importeIVA
      End Get
      Set(ByVal value As Decimal)
         _importeIVA = value
      End Set
   End Property

   Private _montoImponible As Decimal
   ''' <summary>
   ''' Monto imponible: se controlará de la misma forma que la especificada para el ingreso. 
   ''' (Numérico de 9 enteros 2 decimales separados por comas).
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property MontoImponible() As Decimal
      Get
         Return System.Math.Abs(_montoImponible)
      End Get
      Set(ByVal value As Decimal)
         _montoImponible = value
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

   Private _impuestoDeterminado As Decimal
   ''' <summary>
   ''' Impuesto determinado: se controlará que sea igual al Monto imponible por la Alícuota. 
   ''' (Numérico de 9 enteros 2 decimales separados por comas).
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ImpuestoDeterminado() As Decimal
      Get
         Return System.Math.Abs(_impuestoDeterminado)
      End Get
      Set(ByVal value As Decimal)
         _impuestoDeterminado = value
      End Set
   End Property

   Private _montoDeducible As Decimal
   ''' <summary>
   ''' Monto deducible derecho de registro e inspección: si marca de derecho de registro e inspección está en 0, 
   ''' este deberá ser ceros. Si marca de derecho de registro e inspección es 1, entonces para que se permita un 
   ''' importe distinto de ceros, debe ser una retención y retener por el artículo 1° inciso k o l, ó bien, 
   ''' debe utilizarse para el cálculo el arículo 5° 1er. párrafo. (Numérico de 9 enteros 2 decimales separados por comas).
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property MontoDeducible() As Decimal
      Get
         Return _montoDeducible
      End Get
      Set(ByVal value As Decimal)
         _montoDeducible = value
      End Set
   End Property

   Private _montoRetenido As Decimal
   ''' <summary>
   ''' Monto retenido: se controlará que sea la resta entre Impuesto Determinado y derecho de registro e inspección. 
   ''' (Numérico de 9 enteros 2 decimales separado por comas).
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property MontoRetenido() As Decimal
      Get
         Return System.Math.Abs(_montoRetenido)
      End Get
      Set(ByVal value As Decimal)
         _montoRetenido = value
      End Set
   End Property

   Private _articuloParaPercepcion As Integer
   ''' <summary>
   ''' Artículo/Inciso para el cálculo del monto de la retención/percepción: Numérico de 3 posiciones.  
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ArticuloParaPercepcion() As Integer
      Get
         Return _articuloParaPercepcion
      End Get
      Set(ByVal value As Integer)
         _articuloParaPercepcion = value
      End Set
   End Property

    Private _tipoDeExension As Short
    ''' <summary>
    ''' Tipo de exención: numérico de 1 posición. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TipoDeExension() As Short
        Get
            Return _tipoDeExension
        End Get
        Set(ByVal value As Short)
            _tipoDeExension = value
        End Set
    End Property

    Private _añoDeExension As Long
    ''' <summary>
    ''' Año de exención:  numérico de 4 posiciones
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AñoDeExension() As Long
        Get
            Return _añoDeExension
        End Get
        Set(ByVal value As Long)
            _añoDeExension = value
        End Set
    End Property

    Private _numeroCertificadoExension As String = String.Empty
    ''' <summary>
    ''' Número de certificado de exención: alfanumérico de 6 posiciones
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NumeroCertificadoExencion() As String
        Get
            Return _numeroCertificadoExension
        End Get
        Set(ByVal value As String)
            _numeroCertificadoExension = value
        End Set
    End Property

    Private _numeroCertificadoPropio As String = String.Empty
    ''' <summary>
    ''' Número de certificado propio:  alfanumérico de 12 posiciones
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NumeroCertificadoPropio() As String
        Get
            Return _numeroCertificadoPropio
        End Get
        Set(ByVal value As String)
            _numeroCertificadoPropio = value
        End Set
    End Property

#End Region

#Region "Metodos Privados"


   'Private Function EstaBienElCodigoDeComprobante(ByVal codigoDeComprobante As Integer) As Boolean
   '   If codigoDeDocumento = 80 Then
   '      Return True
   '   Else 'si el codigo del documento es distinto a 80 (CUIT) entonces tengo que verificar el tipo de comprobante
   '      If Me._tipoDeComprobante = 6 Or _
   '            Me._tipoDeComprobante = 7 Or _
   '            Me._tipoDeComprobante = 8 Or _
   '            Me._tipoDeComprobante = 9 Or _
   '            Me._tipoDeComprobante = 10 Or _
   '            Me._tipoDeComprobante = 35 Or _
   '            Me._tipoDeComprobante = 40 Or _
   '            Me._tipoDeComprobante = 61 Or _
   '            Me._tipoDeComprobante = 62 Or _
   '            Me._tipoDeComprobante = 82 Then
   '         Return True
   '      Else
   '         Return False
   '      End If
   '   End If
   'End Function

#End Region

End Class
