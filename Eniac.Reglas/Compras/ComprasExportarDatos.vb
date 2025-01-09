Public Class ComprasExportarDatos

   Private _lineas As List(Of ComprasCamposHolistor)
   Public ReadOnly Property Lineas() As List(Of ComprasCamposHolistor)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of ComprasCamposHolistor)()
         End If
         Return _lineas
      End Get
   End Property

   Public Sub GrabarArchivo(ByVal destino As String)
      Dim stb As StringBuilder
      stb = New StringBuilder()

      stb.AppendLine(GetTitulos())

      For Each linea As ComprasCamposHolistor In Lineas

         stb.Append(linea.GetLinea()).AppendLine()
      Next

      Dim utf8WithoutBom As Encoding = New UTF8Encoding(False)

      My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, utf8WithoutBom)

   End Sub

   Protected Overridable Function GetTitulos() As String
      Return "Fecha;Cpbte;Tipo;Suc.;Numero;Razon Social;Tipo Doc;CUIT;Domicilio;C.P.;Pcia;Cond Fisc;Cod. Neto;Neto Gravado;Alic.;IVA Liquidado;IVA Debito;Cod. NG/EX;Conceptos NG/EX;Cod. P/R;Perc./Ret.;Pcia P/R;Total"
   End Function

   Public Overridable Function GetLinea() As ComprasCamposHolistor
      Return New ComprasCamposHolistor()
   End Function

End Class

Public Class ComprasCamposHolistor

   Private _stb As StringBuilder

   Public Sub New()
      Me._stb = New StringBuilder()
   End Sub

#Region "Metodos Publicos"

   Public Overridable Function GetLinea() As String
      With Me._stb

         '# Fecha del Comprobante // Fto: dd/MM/yyyy
         .AppendFormat(Me.FechaEmision.ToString("dd/MM/yyyy"))
         .Append(";")

         '# Cód. Comprobante (Según Tablas AFIP)
         .Append(Me.IdAFIPTipoComprobante.ToString())
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

         '# Razon social del Proveedor
         .Append(Me.NombreProveedor)
         .Append(";")

         '# CUIT del Cliente (en caso de RI)
         .Append(IIf(Not String.IsNullOrWhiteSpace(Me.CuitProveedor), Me.CuitProveedor, ""))
         .Append(";")

         '# Tipo de Documento (Según Tablas AFIP)
         .Append(Me.IdAFIPTipoDocumento)
         .Append(";")

         '# Dirección/Domicilio
         .Append(Me.Direccion)
         .Append(";")

         '# Localidad
         .Append(Me.IdLocalidad)
         .Append(";")

         '# Cód. Provincia (Según Tablas AFIP)
         .Append(Me.IdAFIPProvincia)
         .Append(";")

         '# Cód. Categoría Fiscal (Según Tablas AFIP)
         .Append(Me.IdCategoriaFiscal)
         .Append(";")

         .Append(Me.CodNetoGravado)
         .Append(";")

         '# Importe de Neto Gravado
         .Append(Format(Me.NetoGravado, "N2"))
         .Append(";")

         '# Alícuota (10,5 / 21.0 / etc)
         .Append(Me.Alicuota)
         .Append(";")

         '# IVA Liquidado
         .Append(Me.IVALiquidado)
         .Append(";")

         '# IVA Débito
         .Append(Me.IVADebito)
         .Append(";")

         .Append(Me.CodNgEx)
         .Append(";")

         .Append(Me.ConceptosNgEx)
         .Append(";")

         .Append(Me.CodPerRet)
         .Append(";")

         .Append(Me.PercRet)
         .Append(";")

         .Append(Me.ProvinciaPercRet)
         .Append(";")

         .Append(Me.Total)
      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"

   Public Property FechaEmision As Date
   'Public Property FechaRecepcion As Date?
   Public Property Comprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property NombreProveedor As String
   Public Property IdAFIPTipoComprobante As Integer?
   Public Property CuitProveedor As String
   Public Property IdAFIPTipoDocumento As Integer?
   Public Property NroDocumento As String
   Public Property Alicuota As Decimal
   Public Property Direccion As String
   Public Property IdLocalidad As String
   Public Property IdAFIPProvincia As Integer
   Public Property IdCategoriaFiscal As Integer
   Public Property CodNetoGravado As String
   Public Property NetoGravado As Decimal
   Public Property IVALiquidado As Decimal?
   Public Property IVADebito As Decimal
   Public Property CodNgEx As String
   Public Property ConceptosNgEx As Decimal?
   Public Property CodPerRet As String
   Public Property PercRet As Decimal?
   Public Property ProvinciaPercRet As Decimal?
   Public Property Total As Decimal

#End Region

End Class