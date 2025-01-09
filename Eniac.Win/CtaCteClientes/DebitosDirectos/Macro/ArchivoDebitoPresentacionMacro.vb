Public Class ArchivoDebitoPresentacionMacro

#Region "Propiedades"

   Private _nroDeConvenio As Integer
   ''' <summary>
   ''' Nro de convenio	N 5	Numero de convenio en COBIS	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NroDeConvenio() As Integer
      Get
         Return _nroDeConvenio
      End Get
      Set(value As Integer)
         _nroDeConvenio = value
      End Set
   End Property

   Private _nroDeServicio As String
   ''' <summary>
   ''' Nro de servicio	A 10	Numero de servicio en COBIS	obligatorio. De no existir informar blancos
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NroDeServicio() As String
      Get
         If Me._nroDeServicio.Length > 16 Then
            Return Me._nroDeServicio.Substring(0, 16)
         Else
            Return _nroDeServicio
         End If
      End Get
      Set(value As String)
         _nroDeServicio = value
      End Set
   End Property

   Private _nroDeEmpresaDeSueldos As Integer
   ''' <summary>
   ''' Nro de empresa de sueldos	N 5	Numero de convenio AS en COBIS	informar ceros
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NroDeEmpresaDeSueldos() As Integer
      Get
         Return _nroDeEmpresaDeSueldos
      End Get
      Set(value As Integer)
         _nroDeEmpresaDeSueldos = value
      End Set
   End Property

   Private _fechaGeneracionDeArchivo As DateTime
   ''' <summary>
   ''' Fecha generacion de archivo	N 8 (AAAAMMDD)	fecha de generacion 	AAAAMMDD
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FechaGeneracionDeArchivo() As DateTime
      Get
         Return _fechaGeneracionDeArchivo
      End Get
      Set(value As DateTime)
         _fechaGeneracionDeArchivo = value
      End Set
   End Property

   ''' <summary>
   ''' Importe total de movimientos	N 18 (16 e 2 d)	
   ''' Sumatoria de importes DA o devoluc.	informar sumatoria de movimientos incorporados en el archivo
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property ImporteTotalDeMovimientos As Decimal
      Get
         Dim mon As Decimal = 0
         For Each ar As ArchivoDebitoPresentacionMacroDatos In Me.Datos
            mon += ar.ImporteADebitar
         Next
         Return mon
      End Get
   End Property

   Private _monedaDeLaEmpresa As Short
   ''' <summary>
   ''' Moneda de la empresa	N 03	Moneda de rendción y acreditacion 	 002 - dolares 080 - pesos
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property MonedaDeLaEmpresa() As Short
      Get
         Return _monedaDeLaEmpresa
      End Get
      Set(value As Short)
         _monedaDeLaEmpresa = value
      End Set
   End Property

   Private _tiposDeMovimientosDelArchivo As Short
   ''' <summary>
   ''' Tipo de movimientos del archivo	N 02	Identificacion de los movimientos	01 - Movimientos de Debitos Automaticos
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property TiposDeMovimientosDelArchivo() As Short
      Get
         Return _tiposDeMovimientosDelArchivo
      End Get
      Set(value As Short)
         _tiposDeMovimientosDelArchivo = value
      End Set
   End Property

   Private _datos As List(Of ArchivoDebitoPresentacionMacroDatos)
   Public Property Datos() As List(Of ArchivoDebitoPresentacionMacroDatos)
      Get
         If Me._datos Is Nothing Then
            Me._datos = New List(Of ArchivoDebitoPresentacionMacroDatos)()
         End If
         Return _datos
      End Get
      Set(value As List(Of ArchivoDebitoPresentacionMacroDatos))
         _datos = value
      End Set
   End Property

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarArchivo(destino As String)
      Dim stb As StringBuilder
      Try
         stb = New StringBuilder()

         'Cargar la primer lina del encabezado.
         'DATO	FORMATO	USO	OBSERVACION

         'Filler	N 1	Relleno 	informar '1' 
         stb.Append("1")
         'Nro de convenio	N 5	Numero de convenio en COBIS	obligatorio
         stb.Append(Me.NroDeConvenio.ToString("00000"))
         'Nro de servicio	A 10	Numero de servicio en COBIS	informar blancos
         stb.Append(Me.NroDeServicio.PadRight(10))
         'Nro de empresa de sueldos	N 5	Numero de convenio AS en COBIS	informar ceros
         stb.Append(Me.NroDeEmpresaDeSueldos.ToString("00000"))
         'Fecha generacion de archivo	N 8 (AAAAMMDD)	fecha de generacion 	AAAAMMDD
         stb.Append(Me.FechaGeneracionDeArchivo.ToString("yyyyMMdd"))
         'Importe total de movimientos	N 18 (16 e 2 d)	Sumatoria de importes DA o devoluc.	informar sumatoria de movimientos incorporados en el archivo
         stb.Append(Me.ImporteTotalDeMovimientos.ToString("0000000000000000.00").Replace(",", "").Replace(".", ""))
         'Moneda de la empresa	N 03	Moneda de rendción y acreditacion 	 002 - dolares 080 - pesos
         stb.Append(Me.MonedaDeLaEmpresa.ToString("000"))
         'Tipo de movimientos del archivo	N 02	Identificacion de los movimientos	01 - Movimientos de Debitos Automaticos
         stb.Append(Me.TiposDeMovimientosDelArchivo.ToString("00"))
         'Información monetaria	N 98	utilizada para la rendición	informar ceros
         stb.Append(New String("0"c, 98))
         'Sin uso 	A 69		informar blancos
         stb.Append(New String(" "c, 69))
         'Filler	N 1	Relleno 	informar '0' cero
         stb.Append("0")

         stb.AppendLine()

         For Each linea As ArchivoDebitoPresentacionMacroDatos In Datos
            stb.Append(linea.GetLinea()).AppendLine()
         Next

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

      Catch ex As Exception
         Throw
      End Try
   End Sub

#End Region

End Class

Public Class ArchivoDebitoPresentacionMacroDatos

#Region "Campos"

   Private _stb As StringBuilder
   Private _formatoAlineacionAdherente As String
   Private _caracterRellenado As String

#End Region

#Region "Constructores"

   Public Sub New()
      Me._stb = New StringBuilder()
      Me._formatoAlineacionAdherente = Reglas.Publicos.CtaCte.MacroFormatoAlineacionAdherente
      Me._caracterRellenado = Reglas.Publicos.CtaCte.MacroCaracterRelleanoAdherente
      If Me._caracterRellenado.Length = 0 Then
         Me._caracterRellenado = " " 'le pongo un vacio
      End If
   End Sub

#End Region

#Region "Propiedades"

   Private _nroConvenio As Integer
   ''' <summary>
   ''' Nro de convenio	N 5	Numero de convenio en COBIS	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NroConvenio() As Integer
      Get
         Return _nroConvenio
      End Get
      Set(value As Integer)
         _nroConvenio = value
      End Set
   End Property

   Private _nroDeServicio As String
   ''' <summary>
   ''' Nro de servicio	A 10	Numero de servicio en COBIS	obligatorio. De no existir informar blancos
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NroDeServicio() As String
      Get
         If Me._nroDeServicio.Length > 16 Then
            Return Me._nroDeServicio.Substring(0, 16)
         Else
            Return _nroDeServicio
         End If
      End Get
      Set(value As String)
         _nroDeServicio = value
      End Set
   End Property

   Private _nroDeEmpresaDeSueldos As Integer
   ''' <summary>
   ''' Nro de empresa de sueldos	N 5	Numero de convenio AS en COBIS	informar ceros
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NroDeEmpresaDeSueldos() As Integer
      Get
         Return _nroDeEmpresaDeSueldos
      End Get
      Set(value As Integer)
         _nroDeEmpresaDeSueldos = value
      End Set
   End Property

   Private _codigoDeBancoDelAdherente As Short
   ''' <summary>
   ''' Codigo de banco del adherente	N 3	Codigo de Banco asignado por BCRA	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CodigoDeBancoDelAdherente() As Short
      Get
         Return _codigoDeBancoDelAdherente
      End Get
      Set(value As Short)
         _codigoDeBancoDelAdherente = value
      End Set
   End Property

   Private _codigoDeSucursalDeLaCuenta As Integer
   ''' <summary>
   ''' Codigo de sucursal de la cuenta	N 4	Codigo de sucursal	
   ''' Para Banco Macro  informar el numero de sucursal. Para otros bancos, informar las posiciones 4 a 7 del bloque 1 De la CBU
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CodigoDeSucursalDeLaCuenta() As Integer
      Get
         Return _codigoDeSucursalDeLaCuenta
      End Get
      Set(value As Integer)
         _codigoDeSucursalDeLaCuenta = value
      End Set
   End Property

   Private _tipoDeCuenta As Integer
   ''' <summary>
   ''' Tipo de cuenta	N 1	Tipo de cuenta COBIS	
   ''' 3 - Cta Cte ,  4 - Caja de Ahorros para cuentas de Banco Macro - Bansud. Para cuentas de otros bancos no informar
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property TipoDeCuenta() As Integer
      Get
         Return _tipoDeCuenta
      End Get
      Set(value As Integer)
         _tipoDeCuenta = value
      End Set
   End Property

   Private _cuentaBancariaDelAdherente As Decimal
   ''' <summary>
   ''' Cuenta bancaria del adherente	N 15	Cuenta COBIS del adherente	Para Bco Macro informar el numero de cuenta. 
   ''' Para otros bancos, informar el bloque 2 De la CBU y rellenar con un cero a izquierda.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CuentaBancariaDelAdherente() As Decimal
      Get
         Return _cuentaBancariaDelAdherente
      End Get
      Set(value As Decimal)
         _cuentaBancariaDelAdherente = value
      End Set
   End Property

   Private _identificacionActualDelAdherente As String = String.Empty
   ''' <summary>
   ''' Identificacion actual del adherente	A 22	Identif. Del cliente con la empresa	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property IdentificacionActualDelAdherente() As String
      Get
         If Me._identificacionActualDelAdherente.Length > 22 Then
            Return Me._identificacionActualDelAdherente.Substring(0, 22)
         Else
            Return _identificacionActualDelAdherente
         End If
      End Get
      Set(value As String)
         _identificacionActualDelAdherente = value
      End Set
   End Property

   Private _identificacionDelDebito As String = String.Empty
   ''' <summary>
   ''' Identificacion del debito	A 15	Numero de factura  / recibo identif.	obligatorio. 
   ''' Identificacion del comprobante o recibo a debitar
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property IdentificacionDelDebito() As String
      Get
         If Me._identificacionDelDebito.Length > 15 Then
            Return Me._identificacionDelDebito.Substring(0, 15)
         Else
            Return _identificacionDelDebito
         End If
      End Get
      Set(value As String)
         _identificacionDelDebito = value
      End Set
   End Property

   Private _fechaDeVencimiento As DateTime
   ''' <summary>
   ''' Fecha de vencimiento	N 8 (AAAAMMDD)	Fecha aplicación / ABM	obligatoria
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FechaDeVencimiento() As DateTime
      Get
         Return _fechaDeVencimiento
      End Get
      Set(value As DateTime)
         _fechaDeVencimiento = value
      End Set
   End Property

   Private _monedaDelDebito As Short
   ''' <summary>
   ''' Moneda del debito	N 3	Moneda a debitar / debitada	002 - dolares 080 - pesos
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property MonedaDelDebito() As Short
      Get
         Return _monedaDelDebito
      End Get
      Set(value As Short)
         _monedaDelDebito = value
      End Set
   End Property

   Private _importeADebitar As Decimal
   ''' <summary>
   ''' Importe a debitar	N 13 (11 e 2 d)	importe de la transaccion 	no informar punto decimal
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ImporteADebitar() As Decimal
      Get
         Return _importeADebitar
      End Get
      Set(value As Decimal)
         _importeADebitar = value
      End Set
   End Property

   Private _datosDelRetorno As String = String.Empty
   ''' <summary>
   ''' Datos de retorno	A 40	libre	informacion discrecional de la empresa
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property DatosDelRetorno() As String
      Get
         If Me._datosDelRetorno.Length > 40 Then
            Return Me._datosDelRetorno.Substring(0, 40)
         Else
            Return _datosDelRetorno
         End If
      End Get
      Set(value As String)
         _datosDelRetorno = value
      End Set
   End Property

#End Region

#Region "Metodos Publicos"

   Public Function GetLinea() As String
      With Me._stb
         'DATO	FORMATO	USO	OBSERVACION
         .Length = 0

         'Filler 	N 1	Relleno 	informar '0' cero
         .Append("0")
         'Nro de convenio	N 5	Numero de convenio en COBIS	obligatorio
         .Append(Me.NroConvenio.ToString("00000"))
         'Nro de servicio	A 10	Numero de servicio en COBIS	obligatorio. De no existir informar blancos
         .Append(Me.NroDeServicio.PadRight(10))
         'Nro de empresa de sueldos	N 5	Numero de convenio AS en COBIS	obligatorio. De no existir informar ceros
         .Append(Me.NroDeEmpresaDeSueldos.ToString("00000"))
         'Codigo de banco del adherente	N 3	Codigo de Banco asignado por BCRA	obligatorio
         .Append(Me.CodigoDeBancoDelAdherente.ToString("000"))
         'Codigo de sucursal de la cuenta	N 4	Codigo de sucursal
         'Para Banco Macro  informar el numero de sucursal. Para otros bancos, informar las posiciones 4 a 7 del bloque 1 De la CBU
         .Append(Me.CodigoDeSucursalDeLaCuenta.ToString("0000"))
         'Tipo de cuenta	N 1	Tipo de cuenta COBIS	3 - Cta Cte ,  4 - Caja de Ahorros para cuentas de Banco Macro - Bansud. 
         'Para cuentas de otros bancos no informar
         .Append(Me.TipoDeCuenta.ToString("0"))
         'Cuenta bancaria del adherente	N 15	Cuenta COBIS del adherente	Para Bco Macro informar el numero de cuenta. 
         'Para otros bancos, informar el bloque 2 De la CBU y rellenar con un cero a izquierda.
         .Append(Me.CuentaBancariaDelAdherente.ToString("000000000000000"))
         'Identificacion actual del adherente	A 22	Identif. Del cliente con la empresa	obligatorio
         'Completar con 0 por recomendacion de Diego Robacio (Banco Macro).
         'Completar con vacios por recomendacion de Ana Beatriz Pujol (Banco Macro).
         If Me._formatoAlineacionAdherente = "Derecha a Izquierda" Then
            .Append(Me.IdentificacionActualDelAdherente.PadLeft(22, Char.Parse(Me._caracterRellenado)))
         Else
            .Append(Me.IdentificacionActualDelAdherente.PadRight(22, Char.Parse(Me._caracterRellenado)))
         End If

         'Identificacion del debito	A 15	Numero de factura  / recibo identif.	
         'obligatorio. Identificacion del comprobante o recibo a debitar
         .Append(Me.IdentificacionDelDebito.PadRight(15))
         'Funcion o uso del movimiento	A 2	identifica la transaccion a efectuar	informar blancos
         .Append(New String(" "c, 2))
         'codigo de motivo o rechazo	A 4	obligatorio para rechazos	informar blancos
         .Append(New String(" "c, 4))
         'Fecha de vencimiento	N 8 (AAAAMMDD)	Fecha aplicación / ABM	obligatoria
         .Append(Me.FechaDeVencimiento.ToString("yyyyMMdd"))
         'Moneda del debito	N 3	Moneda a debitar / debitada	002 - dolares 080 - pesos
         .Append(Me.MonedaDelDebito.ToString("000"))
         'Importe a debitar	N 13 (11 e 2 d)	importe de la transaccion 	no informar punto decimal
         .Append(Me.ImporteADebitar.ToString("00000000000.00").Replace(",", "").Replace(".", ""))
         'fecha reintento / fecha tope devoluc.	N 8 (AAAAMMDD)		informar ceros
         .Append("00000000")
         'Importe debitado	N 13 (11 e 2 d)		informar ceros
         .Append("0000000000000")
         'Nueva sucursal bancaria	N 4	Codigo de sucursal nueva	informar ceros
         .Append("0000")
         'Tipo de cuenta	N 1	Tipo de cuenta COBIS	informar ceros
         .Append("0")
         'Nueva cuenta bancaria	N 15	Nueva cuenta COBIS del adherente	informar ceros
         .Append("000000000000000")
         'Nueva identificacion del adherente	A 22	Nueva Identificacion Del cliente 	informar blancos
         .Append(New String(" "c, 22))
         'Datos de retorno	A 40	libre	informacion discrecional de la empresa
         .Append(Me.DatosDelRetorno.PadRight(40))
         'Sin uso 	A 5		informar blancos
         .Append(New String(" "c, 5))
         'Filler 	N 1	Relleno 	informar '0' cero
         .Append("0")
      End With
      Return Me._stb.ToString()
   End Function

#End Region

End Class