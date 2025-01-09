Imports System.Text
Imports System.IO
Public Class VentasExportarDatos '# Esta clase SOLO se utiliza para HOLISTOR

#Region "Propiedades"

   Private _lineas As List(Of VentasCamposAExportar)
   Public ReadOnly Property Lineas() As List(Of VentasCamposAExportar)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of VentasCamposAExportar)()
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

         For Each linea As VentasCamposAExportar In Lineas

            stb.Append(linea.GetLinea()).AppendLine()
         Next

         Dim utf8WithoutBom As Encoding = New UTF8Encoding(False)

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, utf8WithoutBom)

      Catch ex As Exception
         Throw
      End Try
   End Sub


   Protected Overridable Function GetTitulos() As String
      Return "Fecha;Cpbte;Tipo;Suc.;Numero;Razon Social;Tipo Doc;CUIT;Domicilio;C.P.;Pcia;Cond Fisc;Cod. Neto;Neto Gravado;Alic.;IVA Liquidado;IVA Debito;Cod. NG/EX;Conceptos NG/EX;Cod. P/R;Perc./Ret.;Pcia P/R;Total"
   End Function

   Public Overridable Function GetLinea() As VentasCamposAExportar
      Return New VentasCamposAExportar()
   End Function

#End Region
End Class
Public Class VentasCamposAExportar

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

         '# Fecha del Comprobante // Fto: dd/MM/yyyy
         .AppendFormat(Me.Fecha.ToString("dd/MM/yyyy"))
         .Append(";")

         '# Cód. Comprobante (Según Tablas AFIP)
         .Append(Me.TipoComprobanteIdAFIP)
         .Append(";")

         '# Letra del Comprobante 
         .Append(Me.Letra.ToString())
         .Append(";")

         '# Centro Emisor
         .Append(Me.CentroEmisor.ToString("0000"))
         .Append(";")

         '# Numero de Comprobante
         .Append(Me.NumeroComprobante.ToString(New String("0"c, 8)))
         .Append(";")

         '# Nombre del Cliente
         .Append(Me.NombreCliente.Replace(";", " - "))
         .Append(";")

         '# Tipo de Documento (Según Tablas AFIP)
         .Append(Me.TipoDocumentoIdAFIP)
         .Append(";")

         '# CUIT del Cliente (en caso de RI)
         .Append(IIf(Not String.IsNullOrWhiteSpace(Me.Cuit), Me.Cuit, ""))
         .Append(";")

         '# Dirección/Domicilio
         .Append(Me.Direccion)
         .Append(";")

         '# Localidad
         .Append(Me.CP)
         .Append(";")

         '# Cód. Provincia (Según Tablas AFIP)
         .Append(Me.IdAFIPProvincia)
         .Append(";")

         ''# Cód. Categoría Fiscal (Según Tablas AFIP)
         '.Append(Me.IdCategoriaFiscal)
         '.Append(";")
         .Append(Me.CodigoExportacion)
         .Append(";")

         '# Cód. Neto // Observaciones:
         '#                         -  Vtas. Mercaderías: V01
         '#                         -  Vtas. Bien de Uso: V02
         '#                         -  Compra. Mercaderías: CMG
         '#                         -  Compra. Bien de Uso: CBU
         .Append(Me.CodNetoGravado)
         .Append(";")

         '# Importe de Neto Gravado
         .Append(Format(Me.NetoGravado, "N2").Replace(",", "").Replace(".", ","))
         .Append(";")
         Me.FormatearCampo(Alicuota, _stb)
         Me.FormatearCampo(IVALiquidado, _stb)
         Me.FormatearCampo(IVADebito, _stb)

         .Append(Me.CodNgEx)
         .Append(";")
         .Append(Me.ConceptosNgEx)
         .Append(";")
         .Append(Me.CodPerRet)
         .Append(";")

         Me.FormatearCampo(PercRet, _stb)
         Me.FormatearCampo(ProvinciaPercRet, _stb)
         Me.FormatearCampo(Total, _stb)
      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"

   Public Property Fecha() As Date
   Public Property Comprobante() As String
   Public Property Letra() As String
   Public Property CentroEmisor() As Integer
   Public Property NumeroComprobante() As Long
   Public Property NombreCliente() As String
   Public Property Cuit() As String
   Public Property TipoComprobanteIdAFIP() As Integer
   Public Property TipoDocumentoIdAFIP() As Integer
   Public Property NroDocCliente() As String
   Public Property Alicuota() As Decimal
   Public Property Direccion() As String
   Public Property CP() As String
   Public Property NombreLocalidad() As String
   Public Property IdAFIPProvincia As Integer
   Public Property NombreProvincia() As String
   Public Property IdCategoriaFiscal() As Integer
   Public Property CodigoExportacion As String
   Public Property CodNetoGravado() As String
   Public Property NetoGravado() As Decimal
   Public Property IVALiquidado() As Decimal?
   Public Property IVADebito() As Decimal
   Public Property CodNgEx() As String
   Public Property ConceptosNgEx() As String
   Public Property CodPerRet() As String
   Public Property PercRet() As Decimal?
   Public Property ProvinciaPercRet() As Decimal?
   Public Property Total() As Decimal

#End Region

#Region "Métodos"

   Public Sub FormatearCampo(valor As Decimal?, stb As StringBuilder)
      With stb
         If valor.HasValue Then
            .Append(valor.ToString().Replace(",", "").Replace(".", ","))
            .Append(";")
         Else
            .Append(valor)
            .Append(";")
         End If
      End With
   End Sub

#End Region

End Class