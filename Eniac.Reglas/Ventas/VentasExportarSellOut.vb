Imports System.Text
Imports System.IO
Public Class VentasExportarSellOut

#Region "Propiedades"

   Private _lineas As List(Of VentasCamposAExportarSellOut)
   Public ReadOnly Property Lineas() As List(Of VentasCamposAExportarSellOut)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of VentasCamposAExportarSellOut)()
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

         stb.AppendLine(GetTitulos())

         For Each linea As VentasCamposAExportarSellOut In Lineas

            stb.Append(linea.GetLinea()).AppendLine()
         Next

         Dim utf8WithoutBom As Encoding = New UTF8Encoding(False)

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, utf8WithoutBom)

      Catch ex As Exception
         Throw
      End Try
   End Sub


   Protected Overridable Function GetTitulos() As String
      Return "Num de Factura;	Fecha de Factura;	CUIT ;Razon Social;	SE Referencia;	Cantidad; Tipo Cliente; Canal; Zip; Provincia; Sucursal;  Vendedor;	Moneda;	Precio Neto de Venta"
   End Function

   Public Overridable Function GetLinea() As VentasCamposAExportarSellOut
      Return New VentasCamposAExportarSellOut()
   End Function

#End Region
End Class
Public Class VentasCamposAExportarSellOut

#Region "Campos"

   Protected _stb As StringBuilder

#End Region

#Region "Constructores"

   Public Sub New()
      Me._stb = New StringBuilder()
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Overridable Function GetLinea() As String
      With Me._stb

         .Length = 0
         .Append(Me.CentroEmisor.ToString("0000") & "-" & Me.NumeroComprobante.ToString(New String("0"c, 8)))
         .Append(";")
         .AppendFormat(Me.Fecha.ToString("dd/MM/yyyy"))
         .Append(";")
         .Append(IIf(Not String.IsNullOrWhiteSpace(Me.Cuit.ToString()), Me.Cuit, ""))
         .Append(";")
         .Append(Me.NombreCliente)
         .Append(";")
         .Append(Me.CodigoProveedor)
         .Append(";")
         .Append(Me.Cantidad)
         .Append(";")
         .Append(Me.TipoCliente)
         .Append(";")
         .Append(Me.Canal)
         .Append(";")
         .Append(Me.Zip)
         .Append(";")
         .Append(Me.Provincia)
         .Append(";")
         .Append(Me.Sucursal)
         .Append(";")
         .Append(Me.Vendedor)
         .Append(";")
         .Append(Me.Moneda)
         .Append(";")
         .Append(Me.PrecioNeto.ToString("0.00"))
      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"

   Public Property Fecha As Date
   Public Property CentroEmisor As Short
   Public Property NumeroComprobante As Long
   Public Property Cuit As Long
   Public Property NombreCliente() As String
   Public Property TipoCliente As String
   Public Property Canal As String
   Public Property Zip As Integer
   Public Property Provincia As String
   Public Property Sucursal As String
   Public Property Vendedor As String
   Public Property CodigoProveedor As String
   Public Property Cantidad As Decimal
   Public Property Moneda As String
   Public Property PrecioNeto As Decimal

#End Region

End Class