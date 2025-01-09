Option Strict On
Option Explicit On
Imports System.Text

Public Class SIFEREPercArchivo

   Public Sub New()
      _lineas = New List(Of SIFEREPercLinea)()
   End Sub

#Region "Propiedades"
   Private _lineas As List(Of SIFEREPercLinea)
   Public ReadOnly Property Lineas() As List(Of SIFEREPercLinea)
      Get
         Return _lineas
      End Get
   End Property
#End Region

#Region "Metodos Publicos"
   Public Sub GrabarArchivo(ByVal destino As String)
      Dim stb As StringBuilder = New StringBuilder()
      For Each linea As SIFEREPercLinea In Lineas
         If linea.Procesar Then
            stb.Append(linea.GetLinea()).AppendLine()
         End If
      Next
      IO.File.WriteAllText(destino, stb.ToString(), System.Text.Encoding.ASCII)
   End Sub
#End Region

End Class

Public Class SIFEREPercLinea

   Public Sub New()
   End Sub

#Region "Metodos Publicos"
   Public Function GetLinea() As String
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         'Jurisdiccion
         .Append(Jurisdiccion.ToString("000"))
         'Cuit
         .Append(Cuit.ToString("00-00000000-0"))
         'Fecha
         .Append(Fecha.ToString("dd/MM/yyyy"))
         'Emisor Percepcion
         .Append(EmisorPercepcion.ToString("0000"))
         'Numero Percepcion
         .Append(NumeroPercepcion.ToString("00000000"))
         'Tipo Comprobante
         .Append(CodigoComprobante.Substring(0, 1))
         'Letra Comprobante
         .Append(Letra.Substring(0, 1))
         'Importe
         Dim signo As String = "0"
         If Importe < 0 Then signo = "-"
         Dim parteEnteraImporte As Decimal = Math.Abs(Math.Truncate(Importe))
         Dim parteDecimalImporte As Decimal = Math.Truncate((Math.Abs(Importe) - parteEnteraImporte) * 100)
         .AppendFormat("{2}{0:00000000},{1:00}", parteEnteraImporte, parteDecimalImporte, signo)
      End With
      Return stb.ToString()
   End Function
#End Region

#Region "Propiedades"
   Public Property Procesar As Boolean
   Public Property Jurisdiccion As Integer
   Public Property Cuit As Long
   Public Property Fecha As DateTime
   Public Property EmisorPercepcion As Integer
   Public Property NumeroPercepcion As Long
   Public Property IdTipoComprobante As String
   Public Property CodigoComprobante As String
   Public Property Letra As String
   Public Property Importe As Decimal
#End Region
End Class
