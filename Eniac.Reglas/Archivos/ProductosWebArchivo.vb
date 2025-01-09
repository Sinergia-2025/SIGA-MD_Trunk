Imports System.Text
Imports System.IO



Public Class ProductosWebArchivo

#Region "Propiedades"

   Private _lineas As List(Of ProductosWebLinea)
   Public ReadOnly Property Lineas() As List(Of ProductosWebLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of ProductosWebLinea)()
         End If
         Return _lineas
      End Get
   End Property

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarArchivo(ByVal destino As String, grabatitulo As Boolean)
      Dim stb As StringBuilder
      Try
         stb = New StringBuilder()

         If grabatitulo Then
            stb.AppendLine(GetTitulos())
         End If

         For Each linea As ProductosWebLinea In Lineas

            stb.Append(linea.GetLinea()).AppendLine()
         Next

         Dim utf8WithoutBom As Encoding = New UTF8Encoding(False)

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, utf8WithoutBom)

      Catch ex As Exception
         Throw
      End Try
   End Sub

   Public Sub GrabarArchivoQendra(ByVal destino As String)
      Dim stb As StringBuilder
      Try
         stb = New StringBuilder()

         For Each linea As ProductosWebLinea In Lineas

            stb.Append(linea.GetLinea()).AppendLine()
         Next

         Dim utf8WithoutBom As Encoding = New UTF8Encoding(False)

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, utf8WithoutBom)

      Catch ex As Exception
         Throw
      End Try
   End Sub

   Public Sub GrabarArchivoNEO(ByVal destino As String)
      Dim stb As StringBuilder
      Try
         stb = New StringBuilder()

         '  stb.AppendLine(GetTitulos())

         For Each linea As ProductosWebLinea In Lineas

            stb.Append(linea.GetLinea()).AppendLine()
         Next

         Dim utf8WithoutBom As Encoding = New UTF8Encoding(False)

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, utf8WithoutBom)

      Catch ex As Exception
         Throw
      End Try
   End Sub

   Public Sub GrabarArchivoWebExperto(ByVal destino As String)
      Dim stb As StringBuilder
      Try
         stb = New StringBuilder()

         For Each linea As ProductosWebLinea In Lineas

            stb.Append(linea.GetLinea()).AppendLine()
         Next

         Dim utf8WithoutBom As Encoding = New UTF8Encoding(False)

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, utf8WithoutBom)

      Catch ex As Exception
         Throw
      End Try
   End Sub
   Protected Overridable Function GetTitulos() As String
      'Return "codigo;descripcion;marca;rubro;iva;preciocosto;precioventa;moneda;scanner"
      Return "codigo;descripcion;idmarca;nombremarca;idrubro;nombrerubro;idsubrubro;nombresubrubro;iva;preciocosto;precioventa;moneda;codigodebarras;nombrearchivofoto"
   End Function

   Public Overridable Function GetLinea() As ProductosWebLinea
      Return New ProductosWebLinea()
   End Function

#End Region

End Class

Public Class ProductosWebLinea

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

         ' cuit;codigo;descripcion;marca;rubro;iva;preciocosto;precioventa;moneda;scanner

         .Length = 0
         '.Append(Me.Cuit.ToString())
         '.Append(";")

         .AppendFormat(Me.IdProducto.ToString())
         .Append(";")
         .Append(Me.NombreProducto) '.ToString())
         .Append(";")
         .Append(Me.IdMarca.ToString())
         .Append(";")
         .Append(Me.NombreMarca.ToString())
         .Append(";")
         .Append(Me.IdRubro.ToString())
         .Append(";")
         .Append(Me.NombreRubro.ToString())
         .Append(";")
         .Append(Me.IdSubRubro.ToString())
         .Append(";")
         .Append(Me.NombreSubRubro.ToString())
         .Append(";")
         .Append(Math.Round(Me.Alicuota, 2).ToString().Replace(".", ","))
         .Append(";")
         .Append(Math.Round(Me.PrecioCosto, 4).ToString().Replace(".", ","))
         .Append(";")
         .Append(Math.Round(Me.PrecioVenta, 4).ToString().Replace(".", ","))
         .Append(";")
         .Append(Me.Moneda)
         .Append(";")
         .Append(Me.CodigoDeBarras)
         .Append(";")
         .Append(Me.NombreArchivoFoto)

      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"

   Private _cuit As String = String.Empty
   Public Property Cuit() As String
      Get
         Return Me._cuit
      End Get
      Set(ByVal value As String)
         Me._cuit = value.Trim()
      End Set
   End Property


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

   Private _idProducto As String = ""
   Public Property IdProducto() As String
      Get
         Return Me._idProducto
      End Get
      Set(ByVal value As String)
         Me._idProducto = value.Trim()
      End Set
   End Property

   Public Property IdProductoNumerico As Long

   Private _nombreProducto As String = ""
   Public Property NombreProducto() As String
      Get
         Return Me._nombreProducto
      End Get
      Set(ByVal value As String)
         Me._nombreProducto = value.Trim()
      End Set
   End Property

   '-.PE-31924.-
   Private _nombreProductoWeb As String = ""
   Public Property NombreProductoWeb() As String
      Get
         Return Me._nombreProductoWeb
      End Get
      Set(ByVal value As String)
         Me._nombreProductoWeb = value.Trim()
      End Set
   End Property
   Public Property IdMarca() As Integer

   Private _nombreMarca As String
   Public Property NombreMarca() As String
      Get
         Return Me._nombreMarca
      End Get
      Set(ByVal value As String)
         Me._nombreMarca = value
      End Set
   End Property

   Public Property IdRubro() As Integer

   Private _nombreRubro As String
   Public Property NombreRubro() As String
      Get
         Return _nombreRubro
      End Get
      Set(ByVal value As String)
         _nombreRubro = value
      End Set
   End Property

   Public Property ModalidadCodigoDeBarras() As String
   Public Property IdSubRubro() As Integer
   Public Property NombreSubRubro() As String

   Public Property IdSubSubRubro() As Integer
   Public Property NombreSubSubRubro() As String

   Public Property Caracteristica1() As String
   Public Property Caracteristica2() As String
   Public Property Caracteristica3() As String
   Public Property ValorCaracteristica1() As String
   Public Property ValorCaracteristica2() As String
   Public Property ValorCaracteristica3() As String

   Private _alicuota As Decimal = 0

   Public Property Alicuota() As Decimal
      Get
         Return Me._alicuota
      End Get
      Set(ByVal value As Decimal)
         Me._alicuota = value
      End Set
   End Property

   Private _precioVenta As Decimal = 0
   Public Property PrecioVenta() As Decimal
      Get
         Return Me._precioVenta
      End Get
      Set(ByVal value As Decimal)
         Me._precioVenta = value
      End Set
   End Property

   Private _precioCosto As Decimal = 0
   Public Property PrecioCosto() As Decimal
      Get
         Return Me._precioCosto
      End Get
      Set(ByVal value As Decimal)
         Me._precioCosto = value
      End Set
   End Property

   '-.PE-32135.-
   Private _precioMayorista As Decimal = 0
   Public Property PrecioMayorista() As Decimal
      Get
         Return Me._precioMayorista
      End Get
      Set(ByVal value As Decimal)
         Me._precioMayorista = value
      End Set
   End Property

   Private _moneda As String
   Public Property Moneda() As String
      Get
         Return Me._moneda
      End Get
      Set(ByVal value As String)
         Me._moneda = value
      End Set
   End Property

   Private _codigoDeBarras As String = String.Empty
   Public Property CodigoDeBarras() As String
      Get
         Return Me._codigoDeBarras
      End Get
      Set(ByVal value As String)
         Me._codigoDeBarras = value
      End Set
   End Property

   Private _codigoLargoProducto As String
   Public Property CodigoLargoProducto() As String
      Get
         Return Me._codigoLargoProducto
      End Get
      Set(ByVal value As String)
         Me._codigoLargoProducto = value
      End Set
   End Property

   Private _unidadDeMedida As Entidades.UnidadDeMedida
   Public Property UnidadDeMedida() As Entidades.UnidadDeMedida
      Get
         If _unidadDeMedida Is Nothing Then
            _unidadDeMedida = New Entidades.UnidadDeMedida()
         End If
         Return Me._unidadDeMedida
      End Get
      Set(ByVal value As Entidades.UnidadDeMedida)
         Me._unidadDeMedida = value
      End Set
   End Property

   Private _observacion As String
   Public Property Observacion() As String
      Get
         Return Me._observacion
      End Get
      Set(ByVal value As String)
         Me._observacion = value
      End Set
   End Property

   Private _nombrearchivofoto As String
   Public Property NombreArchivoFoto() As String
      Get
         Return Me._nombrearchivofoto
      End Get
      Set(ByVal value As String)
         Me._nombrearchivofoto = value
      End Set
   End Property

   Private _nombrearchivofoto2 As String
   Public Property NombreArchivoFoto2() As String
      Get
         Return Me._nombrearchivofoto2
      End Get
      Set(ByVal value As String)
         Me._nombrearchivofoto2 = value
      End Set
   End Property

   Private _nombrearchivofoto3 As String
   Public Property NombreArchivoFoto3() As String
      Get
         Return Me._nombrearchivofoto3
      End Get
      Set(ByVal value As String)
         Me._nombrearchivofoto3 = value
      End Set
   End Property

   Private _stock As Integer
   Public Property Stock() As Integer
      Get
         Return Me._stock
      End Get
      Set(ByVal value As Integer)
         Me._stock = value
      End Set
   End Property

   Private _kilos As Decimal
   Public Property Kilos() As Decimal
      Get
         Return _kilos
      End Get
      Set(ByVal value As Decimal)
         _kilos = value
      End Set
   End Property

   Private _alto As Decimal
   Public Property Alto() As Decimal
      Get
         Return _alto
      End Get
      Set(ByVal value As Decimal)
         _alto = value
      End Set
   End Property

   Private _ancho As Decimal
   Public Property Ancho() As Decimal
      Get
         Return _ancho
      End Get
      Set(ByVal value As Decimal)
         _ancho = value
      End Set
   End Property

   Private _largo As Decimal
   Public Property Largo() As Decimal
      Get
         Return _largo
      End Get
      Set(ByVal value As Decimal)
         _largo = value
      End Set
   End Property

   Private _EsParaConstructora As Boolean
   Public Property EsParaConstructora() As Boolean
      Get
         Return _EsParaConstructora
      End Get
      Set(ByVal value As Boolean)
         _EsParaConstructora = value
      End Set
   End Property

   Private _EsParaIndustria As Boolean
   Public Property EsParaIndustria() As Boolean
      Get
         Return _EsParaIndustria
      End Get
      Set(ByVal value As Boolean)
         _EsParaIndustria = value
      End Set
   End Property

   Private _EsParaCooperativaElectrica As Boolean
   Public Property EsParaCooperativaElectrica() As Boolean
      Get
         Return _EsParaCooperativaElectrica
      End Get
      Set(ByVal value As Boolean)
         _EsParaCooperativaElectrica = value
      End Set
   End Property

   Private _EsParaMayorista As Boolean
   Public Property EsParaMayorista() As Boolean
      Get
         Return _EsParaMayorista
      End Get
      Set(ByVal value As Boolean)
         _EsParaMayorista = value
      End Set
   End Property

   Private _EsParaMinorista As Boolean
   Public Property EsParaMinorista() As Boolean
      Get
         Return _EsParaMinorista
      End Get
      Set(ByVal value As Boolean)
         _EsParaMinorista = value
      End Set
   End Property

   Public Property IdProductoMercosur() As String
   Public Property NombreCorto As String

#End Region

End Class

Public Class ProductosDonWeb
   Inherits ProductosWebArchivo
   Protected Overrides Function GetTitulos() As String
      Return "id;precio;moneda;nombre;descripcion;""producto habilitado"";""ID Youtube"";codigo"
   End Function
   Public Overrides Function GetLinea() As ProductosWebLinea
      Return New ProductosDonWebLinea()
   End Function
End Class

Public Class ProductosDonWebLinea
   Inherits ProductosWebLinea

   Public Overrides Function GetLinea() As String
      With Me._stb

         'Id,precio,moneda,nombre,descripcion,"producto habilitado","ID Youtube",codigo

         .Length = 0
         If Me.CodigoLargoProducto <> "" Then
            .Append(Me.CodigoLargoProducto)
         End If
         ''.Append()    '' En blanco cuando es nuevo
         .Append(";")
         .Append(Math.Round(Me.PrecioVenta, 4).ToString().Replace(".", ","))
         .Append(";")
         .Append(Me.Moneda)
         .Append(";")
         .Append(Me.NombreProducto.ToString())
         .Append(";")
         ''.Append()    '' Descripcion.
         .Append(";")
         .Append(1)     '' 1 Habilitado
         .Append(";")
         ''.Append()    '' Id Youtube
         .Append(";")
         .AppendFormat(Me.IdProducto.ToString())

      End With
      Return Me._stb.ToString()
   End Function

End Class

Public Class ProductosQendra
   Inherits ProductosWebArchivo
   Protected Overrides Function GetTitulos() As String
      ' Return "Seccion;CodigoPLU;Descripcion;NumeroPLU;PrecioLista1;PrecioLista2;TipoVenta;Vencimiento;OtrosDatos"
   End Function
   Public Overrides Function GetLinea() As ProductosWebLinea
      Return New ProductosQendraLinea()
   End Function
End Class

Public Class ProductosQendraLinea
   Inherits ProductosWebLinea

   Public Overrides Function GetLinea() As String
      With Me._stb

         .Length = 0
         .Append(Me.NombreRubro)
         .Append(";")
         If Me.IdProducto <> "" Then
            .Append(Me.IdProducto)
         End If
         .Append(";")
         .Append(Me.NombreProducto.ToString())
         .Append(";")
         If Me.IdProducto <> "" Then
            .Append(Me.IdProducto)
         End If
         .Append(";")
         .Append(Math.Round(Me.PrecioVenta, 2).ToString())
         .Append(";")
         .Append(Math.Round(Me.PrecioVenta, 2).ToString())
         .Append(";")
         If Me.UnidadDeMedida.IdUnidadDeMedida = "KG" Then
            .Append("p")
         Else
            .Append("u")
         End If
         .Append(";")
         .Append("1")
         .Append(";")
         .Append(Me.Observacion)

      End With
      Return Me._stb.ToString()
   End Function

End Class

Public Class ProductosWebExperto
   Inherits ProductosWebArchivo
   Protected Overrides Function GetTitulos() As String
      ' Return "Seccion;CodigoPLU;Descripcion;NumeroPLU;PrecioLista1;PrecioLista2;TipoVenta;Vencimiento;OtrosDatos"
   End Function
   Public Overrides Function GetLinea() As ProductosWebLinea
      Return New ProductosWebExpertoLinea()
   End Function
End Class

Public Class ProductosWebExpertoLinea
   Inherits ProductosWebLinea

   Public Overrides Function GetLinea() As String
      With Me._stb

         .Length = 0
         .AppendFormat("""{0}""|", Me.IdProducto)
         .AppendFormat("""{0}""|", Me.NombreRubro)
         If Me.NombreSubRubro <> "" Then
            .AppendFormat("""{0}""|", Me.NombreSubRubro)
         Else
            .Append("""""|")
         End If
         If Me.NombreSubSubRubro <> "" Then
            .AppendFormat("""{0}""|", Me.NombreSubSubRubro)
         Else
            .Append("""""|")
         End If
         .AppendFormat("""{0}""|", Publicos.NormalizarDescripcion(Me.NombreProducto))
         .AppendFormat("""{0}""|", Me.NombreMarca)
         .AppendFormat("""{0}""|", Me.Observacion)
         .AppendFormat("""{0}""|", Me.Caracteristica1)
         .AppendFormat("""{0}""|", Me.ValorCaracteristica1)
         .AppendFormat("""{0}""|", Me.Caracteristica2)
         .AppendFormat("""{0}""|", Me.ValorCaracteristica2)
         .AppendFormat("""{0}""|", Me.Caracteristica3)
         .AppendFormat("""{0}""|", Me.ValorCaracteristica3)
         If Me.Stock >= 0 Then
            .AppendFormat("""{0}""|", Me.Stock)
         Else
            .Append("""0""|")
         End If
         .AppendFormat("""{0}""|", Decimal.Round(Me.PrecioVenta, 2).ToString())

         .AppendFormat("""{0}""|", Me.NombreArchivoFoto)
         .AppendFormat("""{0}""|", Me.NombreArchivoFoto2)
         .AppendFormat("""{0}""|", Me.NombreArchivoFoto3)

         .AppendFormat("""{0}""|", Decimal.Round(Me.Kilos, 2).ToString())
         .AppendFormat("""{0}""|", Decimal.Round(Me.Alto, 2).ToString())
         .AppendFormat("""{0}""|", Decimal.Round(Me.Ancho, 2).ToString())
         .AppendFormat("""{0}""|", Decimal.Round(Me.Largo, 2).ToString())
         .AppendFormat("""{0}""|", Me.EsParaConstructora)
         .AppendFormat("""{0}""|", Me.EsParaCooperativaElectrica)
         .AppendFormat("""{0}""|", Me.EsParaIndustria)
         .AppendFormat("""{0}""|", Me.EsParaMayorista)
         .AppendFormat("""{0}""|", Me.EsParaMinorista)
      End With
      Return Me._stb.ToString()
   End Function

End Class

Public Class ProductosiTegraKretz
   Inherits ProductosWebArchivo
   Protected Overrides Function GetTitulos() As String
      Return "codigo;nombre;descripcion;codigodebarras;precioventa;departamento;etiqueta"
   End Function
   Public Overrides Function GetLinea() As ProductosWebLinea
      Return New ProductosiTegraLinea()
   End Function
End Class

Public Class ProductosiTegraLinea
   Inherits ProductosWebLinea

   Public Overrides Function GetLinea() As String
      With Me._stb

         .Length = 0
         .Append(Me.IdProducto).Append(";")
         .Append(Me.NombreProducto.ToString()).Append(";")
         .Append(Me.NombreProducto.ToString()).Append(";")
         If Not String.IsNullOrEmpty(Me.CodigoDeBarras) Then
            .Append(Me.CodigoDeBarras).Append(";")
         Else
            .Append(Me.IdProducto).Append(";")
         End If
         .Append(Math.Round(Me.PrecioVenta, 2).ToString()).Append(";")
         .Append("1").Append(";") 'pongo fija el departamento 1 (hay que setearlo en el sistema de ellos
         .Append("1") 'pongo fija la etiqueta 1 ya que es solo para imprimir

      End With
      Return Me._stb.ToString()
   End Function

End Class

Public Class ProductosWooCommerceSimple
   Inherits ProductosWebArchivo
   Protected Overrides Function GetTitulos() As String
      Return "sku,regular_price,manage_stock,stock,stock_status"
   End Function
   Public Overrides Function GetLinea() As ProductosWebLinea
      Return New ProductosWooCommerceSimpleLinea()
   End Function
End Class
Public Class ProductosWooCommerceSimpleLinea
   Inherits ProductosWebLinea

   Public Overrides Function GetLinea() As String
      With Me._stb

         .Length = 0
         .Append(Me.IdProducto)
         .Append(",")
         .Append(Math.Round(Me.PrecioVenta, 4).ToString())
         .Append(",")
         .Append("yes")
         .Append(",")
         .Append(Math.Round(Me.Stock, 2).ToString())
         .Append(",")
         If Me.Stock > 0 Then
            .Append("instock")
         Else
            .Append("outofstock")
         End If
      End With
      Return Me._stb.ToString()
   End Function

End Class

Public Class ProductosWooCommerceCompacto
   Inherits ProductosWebArchivo
   Protected Overrides Function GetTitulos() As String
      Return "sku,post_title,regular_price,manage_stock,stock,parent_sku"
   End Function
   Public Overrides Function GetLinea() As ProductosWebLinea
      Return New ProductosWooCommerceCompactoLinea()
   End Function
End Class

Public Class ProductosWooCommerceCompactoLinea
   Inherits ProductosWebLinea

   Public Overrides Function GetLinea() As String
      With Me._stb

         .Length = 0
         .Append(Me.IdProducto)
         .Append(",")
         .Append(Me.NombreProducto.ToString())
         .Append(",")
         .Append(Math.Round(Me.PrecioVenta, 4).ToString())
         .Append(",")
         .Append("yes")
         .Append(",")
         .Append(Math.Round(Me.Stock, 2).ToString())
         .Append(",")
         .Append(Me.IdProductoMercosur)
      End With
      Return Me._stb.ToString()
   End Function

End Class

Public Class ProductosiTegraConVenc
   Inherits ProductosWebArchivo
   Protected Overrides Function GetTitulos() As String
      Return "Nombre_Plu;Numero_Plu;Codigo_Plu;Codigo_Depto;Precio;Tipo_Plu;Precio2;Descripcion;Codigo_EtiquetaVencimiento"
   End Function
   Public Overrides Function GetLinea() As ProductosWebLinea
      Return New ProductosiTegraConVencLinea()
   End Function
End Class

Public Class ProductosiTegraConVencLinea
   Inherits ProductosWebLinea

   Public Overrides Function GetLinea() As String
      With Me._stb

         .Length = 0
         .Append(Strings.Left(Me.NombreProducto, 26))
         .Append(",")
         .Append(Me.IdProductoNumerico)
         .Append(",")
         .Append(Me.IdProductoNumerico)
         .Append(",")
         .Append("1")
         .Append(",")
         .Append(Math.Round(Me.PrecioVenta, 2).ToString())
         .Append(",")
         If String.IsNullOrEmpty(ModalidadCodigoDeBarras) Or ModalidadCodigoDeBarras <> Entidades.Producto.Modalidades.PESO.ToString() Then
            .Append("N")
         Else
            .Append("P")
         End If
         .Append(",,,")
         .Append("1")
         .Append(",")
         .Append("0")
      End With
      Return Me._stb.ToString()
   End Function

End Class


Public Class ProductosMiTienda
   Inherits ProductosWebArchivo
   Protected Overrides Function GetTitulos() As String
      Return "sku,post_title,regular_price,manage_stock,stock,parent_sku"
   End Function
   Public Overrides Function GetLinea() As ProductosWebLinea
      Return New ProductosMiTiendaLinea()
   End Function
End Class

Public Class ProductosMiTiendaLinea
   Inherits ProductosWebLinea

   Public Overrides Function GetLinea() As String
      With Me._stb

         .Length = 0
         .Append(Me.IdProducto)
         .Append(";")
         .Append(Me.NombreProducto.ToString())
         .Append(";")
         .Append(Math.Round(Me.PrecioVenta, 4).ToString())
         .Append(";")
         .Append("yes")
         .Append(";")
         .Append(Math.Round(Me.Stock, 2).ToString())
         .Append(";")
         .Append(Me.IdProductoMercosur)
      End With
      Return Me._stb.ToString()
   End Function

End Class

Public Class ProductosDabadoo
   Inherits ProductosWebArchivo
   Dim quote As String = "\"""
   Protected Overrides Function GetTitulos() As String
      Return "ID,Tipo,SKU,Nombre,Publicado," & Chr(34) & "¿Está destacado?" & Chr(34) & "," & Chr(34) & "Visibilidad en el catálogo" & Chr(34) & "," & Chr(34) & "Descripción corta" & Chr(34) & ",Descripción," & Chr(34) & "Día en que empieza el precio rebajado" & Chr(34) & "," & Chr(34) & "Día en que termina el precio rebajado" & Chr(34) & "," & Chr(34) & "Estado del impuesto" & Chr(34) & "," & Chr(34) & "Clase de impuesto" & Chr(34) & "," & Chr(34) & "¿En inventario?" & Chr(34) & ",Inventario," & Chr(34) & "Cantidad de bajo inventario" & Chr(34) & "," & Chr(34) & "¿Permitir reservas de productos agotados?" & Chr(34) & "," & Chr(34) & "¿Vendido individualmente?" & Chr(34) & "," & Chr(34) & "Peso (kg)" & Chr(34) & "," & Chr(34) & "Longitud (cm)" & Chr(34) & "," & Chr(34) & "Anchura (cm)" & Chr(34) & "," & Chr(34) & "Altura (cm)" & Chr(34) & "," & Chr(34) & "¿Permitir valoraciones de clientes?" & Chr(34) & "," & Chr(34) & "Nota de compra" & Chr(34) & "," & Chr(34) & "Precio rebajado" & Chr(34) & "," & Chr(34) & "Precio normal" & Chr(34) & ",Categorías,Etiquetas," & Chr(34) & "Clase de envío" & Chr(34) & ",Imágenes," & Chr(34) & "Límite de descargas" & Chr(34) & "," & Chr(34) & "Días de caducidad de la descarga" & Chr(34) & ",Superior," & Chr(34) & "Productos agrupados" & Chr(34) & "," & Chr(34) & "Ventas dirigidas" & Chr(34) & "," & Chr(34) & "Ventas cruzadas" & Chr(34) & "," & Chr(34) & "URL externa" & Chr(34) & "," & Chr(34) & "Texto del botón" & Chr(34) & ",Posición "
   End Function
   Public Overrides Function GetLinea() As ProductosWebLinea
      Return New ProductosDabadooLinea()
   End Function
End Class

Public Class ProductosDabadooLinea
   Inherits ProductosWebLinea

   Public Overrides Function GetLinea() As String
      With Me._stb

         'ID,Tipo,SKU,Nombre,Publicado,"¿Está destacado?","Visibilidad en el catálogo","Descripción corta",Descripción,"Día en que empieza el precio rebajado",
         '"Día en que termina el precio rebajado","Estado del impuesto","Clase de impuesto","¿En inventario?",Inventario,"Cantidad de bajo inventario","¿Permitir reservas de productos agotados?",
         '"¿Vendido individualmente?","Peso (kg)","Longitud (cm)","Anchura (cm)","Altura (cm)","¿Permitir valoraciones de clientes?","Nota de compra","Precio rebajado","Precio normal",Categorías,
         'Etiquetas, "Clase de envío", Imágenes, "Límite de descargas", "Días de caducidad de la descarga", Superior, "Productos agrupados", "Ventas dirigidas", "Ventas cruzadas", "URL externa",
         ' "Texto del botón", Posición

         .Length = 0
         .Append("")
         .Append(",")
         .Append("simple")
         .Append(",")
         .Append(Me.IdProducto)
         .Append(",")
         .Append(Chr(34) & Me.NombreProducto.ToString().Replace(Chr(34), "pulg") & Chr(34))
         .Append(",1")
         .Append(",0")
         .Append(",visible")
         .Append("," & Chr(34) & Chr(34) & "," & Chr(34) & Chr(34))
         .Append(",,,taxable,,1,,,0,0,,,,,1,,")
         .Append(Math.Round(Me.PrecioVenta, 4).ToString())
         .Append(",")
         .Append(Math.Round(Me.PrecioVenta, 4).ToString())
         .Append(",")
         .Append(Chr(34) & Me.NombreRubro & Chr(34))
         .Append(",,,")
         .Append("/sitio/wp-content/productos/" & Me.IdProducto & ".png")
         .Append(",,,,,,,,,0")

      End With
      Return Me._stb.ToString()
   End Function
End Class

'NUEVO
Public Class ProductosArborea
      Inherits ProductosWebArchivo
      Dim quote As String = "\"""
   Protected Overrides Function GetTitulos() As String
      Return "codigo;descripcion;idmarca;nombremarca;idrubro;nombrerubro;idsubrubro;nombresubrubro;iva;preciocosto;precioventa;moneda;codigodebarras;nombrearchivofoto;precio_mayorista;stock"
   End Function
   Public Overrides Function GetLinea() As ProductosWebLinea
         Return New ProductosArboreaLinea()
      End Function
   End Class

Public Class ProductosArboreaLinea
   Inherits ProductosWebLinea

   Public Overrides Function GetLinea() As String
      With Me._stb
         .Length = 0

         .AppendFormat(Me.IdProducto.ToString())
         .Append(";")
         If Not Me.NombreProductoWeb = Nothing Then
            .Append(Chr(34) & Me.NombreProductoWeb.ToString().Replace(Chr(34), "pulg") & Chr(34))
         Else
            .Append(Chr(34) & Me.NombreProducto.ToString().Replace(Chr(34), "pulg") & Chr(34))
         End If
         .Append(";")
         .Append(Me.IdMarca.ToString())
         .Append(";")
         .Append(Me.NombreMarca.ToString())
         .Append(";")
         .Append(Me.IdRubro.ToString())
         .Append(";")
         .Append(Me.NombreRubro.ToString())
         .Append(";")
         .Append(Me.IdSubRubro.ToString())
         .Append(";")
         .Append(Me.NombreSubRubro.ToString())
         .Append(";")
         .Append(Math.Round(Me.Alicuota, 2).ToString().Replace(".", ","))
         .Append(";")
         .Append(Math.Round(Me.PrecioCosto, 4).ToString().Replace(".", ","))
         .Append(";")
         .Append(Math.Round(Me.PrecioVenta, 4).ToString().Replace(".", ","))
         .Append(";")
         .Append(Me.Moneda)
         .Append(";")
         .Append(Me.CodigoDeBarras)
         .Append(";")
         .Append(Me.NombreArchivoFoto)
         .Append(";")
         .Append(Math.Round(Me.PrecioMayorista, 4).ToString().Replace(".", ","))
         .Append(";")
         .Append(Me.Stock)
      End With
      Return Me._stb.ToString()
   End Function
End Class

Public Class ProductosNEO
      Inherits ProductosWebArchivo
      Protected Overrides Function GetTitulos() As String
      '   Return "rubro,codRubro,NombreProducto,CodigoBarra,PrecioIVA, Fijo, Normal, Fijo"
      Return ""
   End Function
      Public Overrides Function GetLinea() As ProductosWebLinea
         Return New ProductosNEOLinea()
      End Function
   End Class
Public Class ProductosNEOLinea
   Inherits ProductosWebLinea

   Public Overrides Function GetLinea() As String
      With Me._stb

         .Length = 0
         .Append(Me.NombreRubro)
         .Append(";")
         .Append(Me.IdproductoNumerico)
         .Append(";")
         .Append(Strings.Left(Me.NombreProducto, 45))
         .Append(";;")
         .Append(Math.Round(Me.PrecioVenta, 2).ToString())
         .Append(";0")
         .Append(";Unitario")
         .Append(";0;;0;0")
         .Append(";;;;;;;;;;;;;;0;")
         .Append(Me.CodigoDeBarras)

      End With
      Return Me._stb.ToString()
   End Function

End Class