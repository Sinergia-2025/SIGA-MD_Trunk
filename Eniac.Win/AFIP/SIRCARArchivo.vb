Imports System.Text
Imports System.IO

Public Class SIRCARArchivo

#Region "Propiedades"

   Private _lineas As List(Of SIRCARArchivoLinea)
   Public ReadOnly Property Lineas() As List(Of SIRCARArchivoLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of SIRCARArchivoLinea)()
         End If
         Return _lineas
      End Get
   End Property

   Public ReadOnly Property CantidadDeLineasaProcesar() As Integer
      Get
         Dim cant As Integer = 0
         For Each li As SIRCARArchivoLinea In Me.Lineas
            If li.Procesar Then
               cant += 1
            End If
         Next
         Return cant
      End Get
   End Property

#End Region

#Region "Metodos Publicos"


   Public Sub GrabarArchivo(ByVal destino As String, ByVal Tipo As Entidades.TipoImpuesto.Tipos)
      Dim stb As StringBuilder
      Try
         stb = New StringBuilder()
         If Tipo = Entidades.TipoImpuesto.Tipos.PIIBB Then
            For Each linea As SIRCARArchivoLinea In Lineas
               stb.Append(linea.GetLineaPerc()).AppendLine()
            Next
         Else
            For Each linea As SIRCARArchivoLinea In Lineas
               stb.Append(linea.GetLineaRet()).AppendLine()
            Next
         End If

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

      Catch ex As Exception
         Throw
      End Try
   End Sub

#End Region

End Class

Public Class SIRCARArchivoLinea

#Region "Campos"

   Private _stb As StringBuilder

#End Region

#Region "Constructores"

   Public Sub New()
      Me._stb = New StringBuilder()
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetLineaRet() As String
      With Me._stb
         .Length = 0
         'Número de Renglón (único por archivo)
         .AppendFormat(Me.NumeroRenglon.ToString("00000"))
         .Append(",")
         'Origen del Comprobante 
         .AppendFormat(Me.OrigenComprobante.ToString())
         .Append(",")
         'Tipo de Comprobante 
         .AppendFormat(Me.TipoComprobante.ToString())
         .Append(",")
         'Nro. del comprobante.
         .AppendFormat(Me.NroComprobante.ToString("000000000000").PadRight(12))
         .Append(",")
         'CUIT Contribuyente involucrado en la transacción Comercial
         .AppendFormat(Me.CuitProveedor.ToString("00000000000"))
         .Append(",")
         'Fecha de Retención (en formato dd/mm/aaaa)
         .AppendFormat(Me.FechaDeLaRetencion.ToString("dd/MM/yyyy"))
         .Append(",")
         'Monto Sujeto a Retención (numérico sin separador de miles)
         .AppendFormat(Me.MontoImponible.ToString())
         .Append(",")
         'Alícuota (porcentaje sin separador de miles)
         .AppendFormat(Me.Alicuota.ToString())
         .Append(",")
         'Monto Retenido (numérico sin separador de miles, se obtiene de multiplicar el campo 7 por el campo 8 y dividirlo por 100) 
         .AppendFormat(Me.MontoRetenido.ToString())
         .Append(",")
         'Tipo de Régimen de Retención (código correspondiente según tabla definida por la jurisdicción) 
         .AppendFormat(Me.TipoRegimen.ToString("000"))
         .Append(",")
         'Jurisdicción (código en Convenio Multilateral de la jurisdicción a la cual está presentando la DDJJ) 
         .AppendFormat(Me.Jurisdiccion.ToString("000"))


      End With
      Return Me._stb.ToString()
   End Function

   Public Function GetLineaPerc() As String
      With Me._stb
         .Length = 0
         'Número de Renglón (único por archivo)
         .AppendFormat(Me.NumeroRenglon.ToString("00000"))
         .Append(",")
         'Tipo de Comprobante
         .AppendFormat(Me.CodigoComprobante.ToString("000"))
         .Append(",")
         'Letra del Comprobante (A, B ó C, según tipo de Comprobante) Z si no existe identificación del Comprobante 
         .AppendFormat(Me.LetraComprobante)
         .Append(",")
         'Nro. del comprobante.
         .AppendFormat(Me.NroComprobante.ToString("000000000000").PadRight(12))
         .Append(",")
         'CUIT Contribuyente involucrado en la transacción Comercial
         .AppendFormat(Me.CuitProveedor.ToString("00000000000"))
         .Append(",")
         'Fecha de Retención (en formato dd/mm/aaaa)
         .AppendFormat(Me.FechaDeLaRetencion.ToString("dd/MM/yyyy"))
         .Append(",")
         'Monto Sujeto a Retención (numérico sin separador de miles)
         .AppendFormat(Me.MontoImponible.ToString())
         .Append(",")
         'Alícuota (porcentaje sin separador de miles)
         .AppendFormat(Me.Alicuota.ToString())
         .Append(",")
         'Monto Retenido (numérico sin separador de miles, se obtiene de multiplicar el campo 7 por el campo 8 y dividirlo por 100) 
         .AppendFormat(Me.MontoRetenido.ToString())
         .Append(",")
         'Tipo de Régimen de Retención (código correspondiente según tabla definida por la jurisdicción) 
         .AppendFormat(Me.TipoRegimen.ToString("000"))
         .Append(",")
         'Jurisdicción (código en Convenio Multilateral de la jurisdicción a la cual está presentando la DDJJ) 
         .AppendFormat(Me.Jurisdiccion.ToString("000"))

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

   Public Property NumeroRenglon() As Integer

   Public Property OrigenComprobante() As Short

   Public Property FechaDeLaRetencion() As datetime

   Public Property CodigoArticulo() As Integer

   Public ReadOnly Property CodigoComprobante() As Integer
      Get
         Select Case Me.IdTipoComprobante
            Case Entidades.TipoComprobante.Tipos.FACT.ToString(), Entidades.TipoComprobante.Tipos.eFACT.ToString() 'Factura
               Return 1 'Nota de Débito
            Case Entidades.TipoComprobante.Tipos.NDEB.ToString(), Entidades.TipoComprobante.Tipos.eNDEB.ToString() '"NDEB"
               Return 2
               'Case "PAGO" 'Orden de Pago
               '   Return 102
               '04	Boleta de depósito
               '05	Liquidación de pago
               '06	Certificado de Obra
            Case "RECIBO"   'Recibo
               Return 3
               '08	Constancia de Retención
               '09 Otros comprobantes
               '10 Reintegro
            Case Entidades.TipoComprobante.Tipos.NCRED.ToString(), Entidades.TipoComprobante.Tipos.eNCRED.ToString()
               Return 102
            Case Else   'Otro(comprobante)
               Return 20
         End Select
      End Get
   End Property

   Public Property IdTipoComprobante() As String

   Public Property TipoComprobante() As Integer

   Public Property LetraComprobante() As String

   Public Property NroComprobante() As Decimal

   Public Property CuitProveedor() As Long


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
         Return _montoImponible
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
         Return _impuestoDeterminado
      End Get
      Set(ByVal value As Decimal)
         _impuestoDeterminado = value
      End Set
   End Property

   Public Property MontoDeducible() As Decimal

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
         Return _montoRetenido
      End Get
      Set(ByVal value As Decimal)
         _montoRetenido = value
      End Set
   End Property

   Public Property CondicionFrenteAIIBB() As Short
     
   Public Property NroInscripcionIIBB() As Long

   Public Property TipoRegimen() As Integer

   Public Property Jurisdiccion() As Integer


#End Region

End Class
