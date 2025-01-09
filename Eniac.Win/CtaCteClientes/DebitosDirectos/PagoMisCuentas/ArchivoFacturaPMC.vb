Imports System.Text
Imports System.IO
Imports System.Globalization

Public Class ArchivoFacturaPMC

#Region "Propiedades"

   Private _codigoEmpresa As Integer
   ''' <summary>
   '''Nro. de empresa asignado por Banelco. 
   '''Son los cuatro dígitos que figuran en el mail de “Confirmación de aprobación de solicitud” que recibe la empresa.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CodigoEmpresa() As Integer
      Get
         Return _codigoEmpresa
      End Get
      Set(ByVal value As Integer)
         _codigoEmpresa = value
      End Set
   End Property

   Private _fechaArchivo As DateTime
   ''' <summary>
   ''' Fecha de generación del archivo.Formato: AAAAMMDD
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FechaArchivo() As DateTime
      Get
         Return _fechaArchivo
      End Get
      Set(ByVal value As DateTime)
         _fechaArchivo = value
      End Set
   End Property

   Private _datos As List(Of ArchivoFacturaPMCDatos)
   Public Property Datos() As List(Of ArchivoFacturaPMCDatos)
      Get
         If Me._datos Is Nothing Then
            Me._datos = New List(Of ArchivoFacturaPMCDatos)()
         End If
         Return _datos
      End Get
      Set(ByVal value As List(Of ArchivoFacturaPMCDatos))
         _datos = value
      End Set
   End Property

   ''' <summary>
   ''' Sumatoria del campo ‘Importe 1er.Vto.’ de los registros de detalle. 
   ''' Formato: 9 enteros, 2 decimales, sin separadores.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property TotalImporte As Decimal
      Get
         Dim tot As Decimal = 0
         For Each ar As ArchivoFacturaPMCDatos In Datos
            tot += ar.Importe1erVencimiento
         Next
         Return tot
      End Get
   End Property

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarArchivo(ByVal destino As String)
      Dim stb As StringBuilder
      Try
         stb = New StringBuilder()

         'Header

         'Código de Registro. Valor fijo: 0. Siempre es 0 e indica que este renglón es el header.
         stb.Append("0")
         'Identificador Banelco. Valor fijo: 400. Siempre es 400 e indica que el ente recaudador es Banelco.
         stb.Append("400")
         'Nro. de empresa asignado por Banelco. 
         'Son los cuatro dígitos que figuran en el mail de “Confirmación de aprobación de solicitud” que recibe la empresa.
         stb.Append(Me.CodigoEmpresa.ToString("0000"))
         'Fecha de generación del archivo.Formato: AAAAMMDD
         stb.Append(Me.FechaArchivo.ToString("yyyyMMdd"))
         'Campo para uso futuro. Valor fijo: ceros.
         stb.Append(New String("0"c, 264))

         stb.AppendLine()

         'Detalle

         For Each linea As ArchivoFacturaPMCDatos In Datos
            stb.Append(linea.GetLinea()).AppendLine()
         Next

         ''stb.AppendLine()
         'Trailer

         'Código de Registro. Valor fijo: 9.Siempre es  9 e indica que este renglón es el trailer.
         stb.Append("9")
         'Identificador Banelco. Valor fijo: 400. Siempre es 400 e indica que el ente recaudador es Banelco.
         stb.Append("400")
         'Nro. de empresa asignado por Banelco. 
         'Son los cuatro dígitos que figuran en el mail de “Confirmación de aprobación de solicitud” que recibe la empresa.
         stb.Append(Me.CodigoEmpresa.ToString("0000"))
         'Fecha de generación del archivo.Formato: AAAAMMDD
         stb.Append(Me.FechaArchivo.ToString("yyyyMMdd"))
         'Cantidad de registros de detalle informados.Es la cantidad de renglones que tiene el detalle.
         stb.Append(Datos.Count.ToString("0000000"))
         'Campo para uso futuro. Valor fijo: ceros.
         stb.Append("0000000")
         'Sumatoria del campo ‘Importe 1er.Vto.’ de los registros de detalle. 
         'Formato: 9 enteros, 2 decimales, sin separadores.
         stb.Append(Me.TotalImporte.ToString("00000000000000.00").Replace(",", "").Replace(".", ""))
         'Campo para uso futuro. Valor fijo: ceros.
         stb.Append(New String("0"c, 234))

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

      Catch ex As Exception
         Throw
      End Try
   End Sub

#End Region

End Class

Public Class ArchivoFacturaPMCDatos

#Region "Campos"

   Private _stb As StringBuilder

#End Region

#Region "Constructores"

   Public Sub New()
      Me._stb = New StringBuilder()
   End Sub

#End Region

#Region "Propiedades"

   Private _nroReferencia As String = String.Empty
   ''' <summary>
   ''' Identificación del cliente en la empresa. 
   ''' Se refiere a la identificación que deberá ingresar el cliente para poder pagar, 
   ''' que le sirve a la empresa para saber quien le está pagando. 
   ''' Son los números que componen el “concepto utilizado como ID del cliente” que 
   ''' la empresa completó en el formulario de adhesión.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NroReferencia() As String
      Get
         If Me._nroReferencia.Length > 19 Then
            Return Me._nroReferencia.Substring(0, 19)
         Else
            Return _nroReferencia
         End If
      End Get
      Set(ByVal value As String)
         _nroReferencia = value
      End Set
   End Property

   Private _idFactura As String = String.Empty
   ''' <summary>
   ''' Identificación de la factura. 
   ''' Se refiere a la identificación particular de la factura que está pagando el cliente. 
   ''' No tiene que ser obligatoriamente el “Nro. de Factura”, sino que puede ser cualquier 
   ''' número que utilice la empresa para individualizar el pago (puede que para un mismo Nro. 
   ''' Referencia, haya varios Id. Factura, si un cliente tiene varias facturas a pagar).
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property IdFactura() As String
      Get
         If Me._idFactura.Length > 20 Then
            Return Me._idFactura.Substring(0, 20)
         Else
            Return _idFactura
         End If
      End Get
      Set(ByVal value As String)
         _idFactura = value
      End Set
   End Property

   Private _fecha1erVencimiento As DateTime
   ''' <summary>
   ''' Fecha del 1er vencimiento de la factura
   ''' Formato: AAAAMMDD
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Fecha1erVencimiento() As DateTime
      Get
         Return _fecha1erVencimiento
      End Get
      Set(ByVal value As DateTime)
         _fecha1erVencimiento = value
      End Set
   End Property

   Private _importe1erVencimiento As Decimal
   ''' <summary>
   ''' Importe de la factura para el 1er vencimiento.
   ''' Formato: 9 enteros, 2 decimales, sin separadores. 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Importe1erVencimiento() As Decimal
      Get
         Return _importe1erVencimiento
      End Get
      Set(ByVal value As Decimal)
         _importe1erVencimiento = value
      End Set
   End Property

   Private _fecha2doVencimiento As DateTime
   ''' <summary>
   ''' Fecha del 2do vencimiento de la factura
   ''' Formato: AAAAMMDD
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Fecha2doVencimiento() As DateTime
      Get
         Return _fecha2doVencimiento
      End Get
      Set(ByVal value As DateTime)
         _fecha2doVencimiento = value
      End Set
   End Property

   Private _importe2doVencimiento As Decimal
   ''' <summary>
   ''' Importe de la factura para el 2do vencimiento.
   ''' Formato: 9 enteros, 2 decimales, sin separadores. 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Importe2doVencimiento() As Decimal
      Get
         Return _importe2doVencimiento
      End Get
      Set(ByVal value As Decimal)
         _importe2doVencimiento = value
      End Set
   End Property

   Private _fecha3erVencimiento As DateTime
   ''' <summary>
   ''' Fecha del 3er vencimiento de la factura
   ''' Formato: AAAAMMDD
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Fecha3erVencimiento() As DateTime
      Get
         Return _fecha3erVencimiento
      End Get
      Set(ByVal value As DateTime)
         _fecha3erVencimiento = value
      End Set
   End Property

   Private _importe3erVencimiento As Decimal
   ''' <summary>
   ''' Importe de la factura para el 3er vencimiento.
   ''' Formato: 9 enteros, 2 decimales, sin separadores. 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Importe3erVencimiento() As Decimal
      Get
         Return _importe3erVencimiento
      End Get
      Set(ByVal value As Decimal)
         _importe3erVencimiento = value
      End Set
   End Property

   Private _mensajeTicket As String = String.Empty
   ''' <summary>
   ''' Datos a informar en el ticket de pago. 
   ''' Es el mensaje  que se imprimirá en el comprobante de pago que se refiere al concepto abonado por el cliente. 
   ''' Ej: Cuota Noviembre.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property MensajeTicket() As String
      Get
         If _mensajeTicket.Length > 40 Then
            Return _mensajeTicket.Substring(0, 40)
         Else
            Return _mensajeTicket
         End If
      End Get
      Set(ByVal value As String)
         _mensajeTicket = value
      End Set
   End Property

   ''' <summary>
   ''' Datos a informar en la pantalla de selección de la factura a pagar.
   ''' Es el mensaje que verá el cliente en pantalla antes de confirmar el pago. 
   ''' Se refiere al mismo concepto que el campo “Mensaje Ticket”, pero con menos caracteres.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property MensajePantalla As String
      Get
         Dim valor As String

         'TODO: DB
         ' ''If Publicos.CargosCalcularPor = "CAMA" Then
         ' ''   valor = _mensajeTicket.Replace("Periodo: ", "P:").Replace(", Cama: ", ",C:").Replace("/", "")
         ' ''Else
         valor = _mensajeTicket
         ' ''End If

         If valor.Length > 15 Then
            valor = valor.Substring(0, 15)
         End If

         Return valor
      End Get
   End Property

   Private _codigoBarras As String = String.Empty
   ''' <summary>
   ''' Código de barras.
   ''' Son los números que componen el código de barras de la empresa. 
   ''' Si no posee uno, se debe completar el campo con espacios.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CodigoBarras() As String
      Get
         If Me._codigoBarras.Length > 60 Then
            Return Me._codigoBarras.Substring(0, 60)
         Else
            Return _codigoBarras
         End If
      End Get
      Set(ByVal value As String)
         _codigoBarras = value
      End Set
   End Property

#End Region

#Region "Metodos Publicos"

   Public Function GetLinea() As String
      With Me._stb
         .Length = 0

         'Código de Registro. Valor fijo: 5.Indica que este renglón forma parte del detalle.
         .Append("5")
         'Identificación del cliente en la empresa. 
         'Se refiere a la identificación que deberá ingresar el cliente para poder pagar, que le sirve a la empresa para saber quien le está pagando. 
         'Son los números que componen el “concepto utilizado como ID del cliente” que la empresa completó en el formulario de adhesión.
         .Append(Me.NroReferencia.ToUpper().PadRight(19))
         'Identificación de la factura. 
         'Se refiere a la identificación particular de la factura que está pagando el cliente. 
         'No tiene que ser obligatoriamente el “Nro. de Factura”, sino que puede ser cualquier número que 
         'utilice la empresa para individualizar el pago (puede que para un mismo Nro. Referencia, haya varios 
         'Id. Factura, si un cliente tiene varias facturas a pagar).
         .Append(Me.IdFactura.PadRight(20))
         'Código de moneda de los importes informados.Valor fijo: 0 (Pesos).Siempre es  0 e indica que la factura es en pesos.
         .Append("0")
         'Fecha del 1er vencimiento de la factura Formato: AAAAMMDD
         .Append(Me.Fecha1erVencimiento.ToString("yyyyMMdd"))
         'Importe de la factura para el 1er vencimiento. Formato: 9 enteros, 2 decimales, sin separadores. 
         .Append(Me.Importe1erVencimiento.ToString("000000000.00").Replace(",", "").Replace(".", ""))
         'Fecha del 2do vencimiento de la factura Formato: AAAAMMDD
         .Append(Me.Fecha2doVencimiento.ToString("yyyyMMdd"))
         'Importe de la factura para el 2do vencimiento. Formato: 9 enteros, 2 decimales, sin separadores. 
         .Append(Me.Importe2doVencimiento.ToString("000000000.00").Replace(",", "").Replace(".", ""))
         'Fecha del 3er vencimiento de la factura Formato: AAAAMMDD
         .Append(Me.Fecha3erVencimiento.ToString("yyyyMMdd"))
         'Importe de la factura para el 3er vencimiento. Formato: 9 enteros, 2 decimales, sin separadores. 
         .Append(Me.Importe3erVencimiento.ToString("000000000.00").Replace(",", "").Replace(".", ""))
         'Campo para uso futuro. Valor fijo: ceros.
         .Append(New String("0"c, 19))
         'Se debe repetir la información del campo “Nro. Referencia”.
         'En caso que se modifique la identificación del cliente, se deberá informar la identificación anterior 
         'por única vez, luego se deberá repetir la información del campo Nro. Referencia.
         .Append(Me.NroReferencia.ToUpper().PadRight(19))
         'Datos a informar en el ticket de pago. 
         'Es el mensaje  que se imprimirá en el comprobante de pago que se refiere al concepto abonado por 
         'el cliente. Ej: Cuota Noviembre.
         .Append(Me.MensajeTicket.PadRight(40))
         'Datos a informar en la pantalla de selección de la factura a pagar.
         'Es el mensaje que verá el cliente en pantalla antes de confirmar el pago. 
         'Se refiere al mismo concepto que el campo “Mensaje Ticket”, pero con menos caracteres.
         .Append(Me.MensajePantalla.PadRight(15))
         'Código de barras.
         'Son los números que componen el código de barras de la empresa. 
         'Si no posee uno, se debe completar el campo con espacios.
         .Append(Me.CodigoBarras.PadRight(60))
         'Campo para uso futuro. Valor fijo: ceros.
         .Append(New String("0"c, 29))
      End With
      Return Me._stb.ToString().ToUpper()
   End Function

#End Region

End Class