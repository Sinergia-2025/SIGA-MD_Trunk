Option Strict On
Option Explicit On
Imports System.Text
Imports System.IO

Public Class ContabilidadExportacionArchivo

#Region "Metodos Privados"


#End Region

#Region "Propiedades"

   Private _lineas As List(Of ContabilidadExportacionArchivoLinea)
   Public ReadOnly Property Lineas() As List(Of ContabilidadExportacionArchivoLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of ContabilidadExportacionArchivoLinea)()
         End If
         Return _lineas
      End Get
   End Property

#End Region

#Region "Metodos Publicos"

   '' ''Public Sub GrabarArchivo(ByVal destino As String)
   '' ''   Dim stb As StringBuilder
   '' ''   Try
   '' ''      stb = New StringBuilder()

   '' ''      For Each linea As ContabilidadExportacionArchivoLinea In Lineas
   '' ''         stb.Append(linea.GetLinea()).AppendLine()
   '' ''      Next

   '' ''      My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

   '' ''   Catch ex As Exception
   '' ''      Throw
   '' ''   End Try
   '' ''End Sub

#End Region

End Class

Public Class ContabilidadExportacionArchivoLinea

#Region "Campos"

   Private _stb As StringBuilder

#End Region

#Region "Constructores"

   Public Sub New()
      Me._stb = New StringBuilder()
   End Sub

#End Region

#Region "Metodos Publicos"

   '' ''Public Function GetLinea() As String
   '' ''   With Me._stb
   '' ''      .Length = 0
   '' ''      'COMPENSADO CON CEROS  A LA IZ  LONG  5 - Número correlativo
   '' ''      .AppendFormat(Me.NroDeAsiento.ToString("00000"))
   '' ''      .Append(Chr(9))
   '' ''      'SEGÚN PLAN DE CUENTAS COLICITAR A MOR - Longitud    11
   '' ''      .AppendFormat(Me.CuentaMayor.ToString("00000000000"))
   '' ''      .Append(Chr(9))
   '' ''      'REFERENCIA DEL ASIENTO    - LONG    30
   '' ''      .AppendFormat(Me.Concepto)
   '' ''      .Append(Chr(9))
   '' ''      'SI LA OP. LO REQUIERE LONG  10
   '' ''      .AppendFormat(Me.SubCuenta.ToString("0000000000"))
   '' ''      .Append(Chr(9))
   '' ''      '1 DEBE 2 HABER      LONG   1
   '' ''      .AppendFormat(Me.DebeHaber.ToString())
   '' ''      .Append(Chr(9))
   '' ''      'LONG   14    POSISIONES DECIMALES - IMPLICITAS   RELLENAR CON CEROS IZQ
   '' ''      .AppendFormat(Me.Importe.ToString("00000000000000"))
   '' ''   End With
   '' ''   Return Me._stb.ToString()
   '' ''End Function

#End Region

#Region "Propiedades"

   Public Property IdPlanCuenta As Integer
   Public Property NroDeAsiento As Integer
   Public Property CuentaMayor() As Long
   Private _concepto As String
   Public Property Concepto() As String
      Get
         If Me._concepto.Length < 30 Then
            Me._concepto = Me._concepto.PadRight(30) 'agrego vacios
         End If

         Return _concepto
      End Get
      Set(ByVal value As String)
         If value.Length > 30 Then
            _concepto = value.Substring(0, 30)
         Else
            _concepto = value
         End If
      End Set
   End Property
   Public Property SubCuenta() As Long
   Public Property DebeHaber() As Short
   Public Property Importe() As Decimal
   Public Property FechaExportacion() As DateTime


   Public Property CodigoComprobante() As Integer?
   Public Property PuntoEmision() As Integer?
   Public Property NumeroComprobante() As Long?
   Public Property FechaRegistro() As DateTime
   Public Property FechaComprobante() As DateTime?
   Public Property FechaVencimiento() As DateTime?

#End Region

End Class