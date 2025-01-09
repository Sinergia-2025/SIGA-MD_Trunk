#Region "Imports"
Imports System.Text
Imports System.IO
Imports System.Globalization
#End Region
Public Class ArchivoDebitoRespuestaMacro

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
      Set(ByVal value As Integer)
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
      Set(ByVal value As String)
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
      Set(ByVal value As Integer)
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
      Set(ByVal value As DateTime)
         _fechaGeneracionDeArchivo = value
      End Set
   End Property

   Private _importeTotalDeMovimientos As Decimal
   ''' <summary>
   ''' Importe total de movimientos	N 18 (16 e 2 d)	
   ''' Sumatoria de importes DA o devoluc.	informar sumatoria de movimientos incorporados en el archivo
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ImporteTotalDeMovimientos As Decimal
      Get
         Return _importeTotalDeMovimientos
      End Get
      Set(value As Decimal)
         _importeTotalDeMovimientos = value
      End Set
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
      Set(ByVal value As Short)
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
      Set(ByVal value As Short)
         _tiposDeMovimientosDelArchivo = value
      End Set
   End Property

   Private _datos As List(Of ArchivoDebitoRespuestaMacroDatos)
   Public Property Datos() As List(Of ArchivoDebitoRespuestaMacroDatos)
      Get
         If Me._datos Is Nothing Then
            Me._datos = New List(Of ArchivoDebitoRespuestaMacroDatos)()
         End If
         Return _datos
      End Get
      Set(ByVal value As List(Of ArchivoDebitoRespuestaMacroDatos))
         _datos = value
      End Set
   End Property


#End Region

   Public Function GetInfo(archivoFisico As StreamReader) As ArchivoDebitoRespuestaMacro

      Dim linea As String
      Dim arDa As ArchivoDebitoPresentacionMacro = New ArchivoDebitoPresentacionMacro()
      linea = archivoFisico.ReadLine()
      'leo la primer linea, la cual tengo que recuperar la información de la cabecera

      'DATO	FORMATO	USO	OBSERVACION
      'Filler	N 1	Relleno 	idem envio debitos
      'Nro de convenio	N 5	Numero de convenio en COBIS	idem envio debitos
      Me.NroDeConvenio = Int32.Parse(linea.Substring(1, 5))
      'Nro de servicio	A 10	Numero de servicio en COBIS	idem envio debitos
      Me.NroDeServicio = linea.Substring(6, 10)
      'Nro de empresa de sueldos	N 5	Numero de convenio AS en COBIS	idem envio debitos
      Me.NroDeEmpresaDeSueldos = Int32.Parse(linea.Substring(16, 5))
      'Fecha generacion de archivo	N 8 (AAAAMMDD)	fecha de generacion 	idem envio debitos
      Me.FechaGeneracionDeArchivo = New DateTime(Int32.Parse(linea.Substring(21, 4)), Int32.Parse(linea.Substring(25, 2)), Int32.Parse(linea.Substring(27, 2)))
      'Importe total de movimientos	N 18 (16 e 2 d)	Sumatoria de importes DA o devoluc.	idem envio debitos
      Me.ImporteTotalDeMovimientos = Decimal.Parse(linea.Substring(29, 18)) / 100
      'Moneda de la empresa	N 03	Moneda de rendción y acreditacion 	idem envio debitos
      Me.MonedaDeLaEmpresa = Short.Parse(linea.Substring(47, 3))
      'Tipo de movimientos del archivo	N 02	Identificacion de los movimientos	03
      Me.TiposDeMovimientosDelArchivo = Short.Parse(linea.Substring(50, 2))
      'Información monetaria	N 98	utilizada para la rendición	idem envio debitos
      'Sin uso 	A 69		idem envio debitos
      'Filler	N 1	Relleno 	idem envio debitos

      linea = archivoFisico.ReadLine()
      Do While linea IsNot Nothing
         Me.Datos.Add(New ArchivoDebitoRespuestaMacroDatos().GetDato(linea))
         linea = archivoFisico.ReadLine()
      Loop

      Return Me
   End Function

End Class

Public Class ArchivoDebitoRespuestaMacroDatos

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
      Set(ByVal value As Integer)
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
      Set(ByVal value As String)
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
      Set(ByVal value As Integer)
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
      Set(ByVal value As Short)
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
      Set(ByVal value As Integer)
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
      Set(ByVal value As Integer)
         _tipoDeCuenta = value
      End Set
   End Property

   Private _cuentaBancariaDelAdherente As Long
   ''' <summary>
   ''' Cuenta bancaria del adherente	N 15	Cuenta COBIS del adherente	Para Bco Macro informar el numero de cuenta. 
   ''' Para otros bancos, informar el bloque 2 De la CBU y rellenar con un cero a izquierda.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CuentaBancariaDelAdherente() As Long
      Get
         Return _cuentaBancariaDelAdherente
      End Get
      Set(ByVal value As Long)
         _cuentaBancariaDelAdherente = value
      End Set
   End Property

   Private _identificacionActualDelAdherente As Long
   Public Property IdentificacionActualDelAdherente() As Long
      Get
         'If Me._identificacionActualDelAdherente.Length > 22 Then
         '   Return Me._identificacionActualDelAdherente.Substring(0, 22)
         'Else
         '   Return _identificacionActualDelAdherente
         'End If
         Return Me._identificacionActualDelAdherente
      End Get
      Set(ByVal value As Long)
         Me._identificacionActualDelAdherente = value
      End Set
   End Property

   Private _nombreCliente As String = String.Empty
   Public Property NombreCliente() As String
      Get
         Return Me._nombreCliente
      End Get
      Set(ByVal value As String)
         Me._nombreCliente = value
      End Set
   End Property

   Private _nombreCategoria As String = String.Empty
   Public Property NombreCategoria() As String
      Get
         Return Me._nombreCategoria
      End Get
      Set(ByVal value As String)
         Me._nombreCategoria = value
      End Set
   End Property

   Private _idCaja As Integer
   Public Property IdCaja() As Integer
      Get
         Return _idCaja
      End Get
      Set(ByVal value As Integer)
         _idCaja = value
      End Set
   End Property

   Private _nombreCaja As String = String.Empty
   Public Property NombreCaja() As String
      Get
         Return Me._nombreCaja
      End Get
      Set(ByVal value As String)
         Me._nombreCaja = value
      End Set
   End Property


   Private _saldo As Decimal
   Public Property Saldo() As Decimal
      Get
         Return _saldo
      End Get
      Set(ByVal value As Decimal)
         _saldo = value
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
      Set(ByVal value As String)
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
      Set(ByVal value As DateTime)
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
      Set(ByVal value As Short)
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
      Set(ByVal value As Decimal)
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
      Set(ByVal value As String)
         _datosDelRetorno = value
      End Set
   End Property

   Private _funcionOUsoDelMovimiento As String
   Public Property FuncionOUsoDelMovimiento() As String
      Get
         Return _funcionOUsoDelMovimiento
      End Get
      Set(ByVal value As String)
         _funcionOUsoDelMovimiento = value
      End Set
   End Property

   Private _codigoDeMotivoORechazo As String
   Public Property CodigoDeMotivoORechazo() As String
      Get
         Return _codigoDeMotivoORechazo
      End Get
      Set(ByVal value As String)
         _codigoDeMotivoORechazo = value
      End Set
   End Property

   Public ReadOnly Property MotivoRechazo() As String
      Get
         Select Case Me.CodigoDeMotivoORechazo.Trim()
            Case "R02"
               Return "CUENTA CERRADA / BLOQUEADA / INMOVILIZADA"
            Case "R03"
               Return "CUENTA INEXISTENTE"
            Case "R04"
               Return "NUMERO DE CUENTA INVALIDO"
            Case "R08"
               Return "ORDEN DE NO PAGAR"
            Case "R10"
               Return "FONDOS INSUFICIENTES"
            Case "R14"
               Return "IDENTIFICACION DEL CLIENTE EN LA EMPRESA ERRONEA"
            Case "R15"
               Return "BAJA DEL SERVICIO"
            Case "R17"
               Return "ERROR DE FORMATO"
            Case "R19"
               Return "IMPORTE ERRONEO"
            Case "R20"
               Return "MONEDA DISTINTA A LA CUENTA DE DEBITO"
            Case "R23"
               Return "SUCURSAL NO HABILITADA"
            Case "R24"
               Return "TRANSACCION DUPLICADA"
            Case "R26"
               Return "ERROR POR CAMPO MANDATORIO"
            Case Else
               Return ""
         End Select
      End Get
   End Property


   Private _fechaReintento As DateTime
   Public Property FechaReintento() As DateTime
      Get
         Return _fechaReintento
      End Get
      Set(ByVal value As DateTime)
         _fechaReintento = value
      End Set
   End Property

   Private _importeDebitado As Decimal
   Public Property ImporteDebitado() As Decimal
      Get
         Return _importeDebitado
      End Get
      Set(ByVal value As Decimal)
         _importeDebitado = value
      End Set
   End Property

   Private _alerta As String = String.Empty
   Public Property Alerta() As String
      Get
         Return _alerta
      End Get
      Set(ByVal value As String)
         _alerta = value
      End Set
   End Property

#End Region

#Region "Metodos Publicos"

   Public Function GetDato(linea As String) As ArchivoDebitoRespuestaMacroDatos

      Dim oCliente As Entidades.Cliente
      Dim regCli As Reglas.Clientes = New Reglas.Clientes()

      Dim dato As ArchivoDebitoRespuestaMacroDatos = New ArchivoDebitoRespuestaMacroDatos()
      With dato

         'DATO	FORMATO	USO	OBSERVACION

         'Filler 	N 1	Relleno 	idem envio debitos
         'Nro de convenio	N 5	Numero de convenio en COBIS	idem envio debitos
         dato.NroConvenio = Int32.Parse(linea.Substring(1, 5))
         'Nro de servicio	A 10	Numero de servicio en COBIS	idem envio debitos
         dato.NroDeServicio = linea.Substring(6, 10)
         'Nro de empresa de sueldos	N 5	Numero de convenio AS en COBIS	idem envio debitos
         dato.NroDeEmpresaDeSueldos = Int32.Parse(linea.Substring(16, 5))
         'Codigo de banco del adherente	N 3	Codigo de Banco asignado por BCRA	idem envio debitos
         dato.CodigoDeBancoDelAdherente = Short.Parse(linea.Substring(21, 3))
         'Codigo de sucursal de la cuenta	N 4	Codigo de sucursal	idem envio debitos
         dato.CodigoDeSucursalDeLaCuenta = Int32.Parse(linea.Substring(24, 4))
         'Tipo de cuenta	N 1	Tipo de cuenta COBIS	idem envio debitos
         If Not String.IsNullOrWhiteSpace(linea.Substring(28, 1)) Then
            dato.TipoDeCuenta = Int32.Parse(linea.Substring(28, 1))
         End If
         'Cuenta bancaria del adherente	N 15	Cuenta COBIS del adherente	idem envio debitos
         dato.CuentaBancariaDelAdherente = Long.Parse(linea.Substring(29, 15))

         'Identificacion actual del adherente	A 22	Identif. Del cliente con la empresa	idem envio debitos
         dato.IdentificacionActualDelAdherente = Long.Parse(linea.Substring(44, 22))

         'Agregado para mostrar en Pantalla.

         oCliente = regCli.GetUnoPorCodigo(dato.IdentificacionActualDelAdherente, False)
         If oCliente IsNot Nothing AndAlso Not String.IsNullOrEmpty(oCliente.NombreCliente) Then
            dato.NombreCliente = oCliente.NombreCliente
            dato.NombreCategoria = oCliente.NombreCategoria

            dato.IdCaja = oCliente.IdCaja
            If dato.IdCaja > 0 Then
               dato.NombreCaja = New Eniac.Reglas.CajasNombres().GetUna(Eniac.Entidades.Usuario.Actual.Sucursal.Id, dato.IdCaja).NombreCaja
            End If

            dato.Saldo = oCliente.SaldoPendiente
         Else
            dato.NombreCliente = "*** Cliente Inexistente o Inactivo ***"
            dato.NombreCategoria = "N/A"
            dato.IdCaja = 0
            dato.NombreCaja = ""
            dato.Saldo = 0
         End If

         'Identificacion del debito	A 15	Numero de factura  / recibo identif.	idem envio debitos
         dato.IdentificacionDelDebito = linea.Substring(66, 15)
         'Funcion o uso del movimiento	A 2	identifica la transaccion a efectuar	idem envio debitos
         dato.FuncionOUsoDelMovimiento = linea.Substring(81, 2)
         'codigo de motivo o rechazo	A 4	obligatorio para rechazos	observar tabla anexa de movimientos rechazados
         dato.CodigoDeMotivoORechazo = linea.Substring(83, 4)
         'Fecha de vencimiento	N 8 (AAAAMMDD)	Fecha aplicación / ABM	fecha de vencimiento de registro original
         dato.FechaDeVencimiento = New DateTime(Int32.Parse(linea.Substring(87, 4)), Int32.Parse(linea.Substring(91, 2)), Int32.Parse(linea.Substring(93, 2)))
         'Moneda del debito	N 3	Moneda a debitar / debitada	idem envio debitos
         dato.MonedaDelDebito = Short.Parse(linea.Substring(95, 3))
         'Importe a debitar	N 13 (11 e 2 d)	importe de la transaccion 	importe registro original
         dato.ImporteADebitar = Decimal.Parse(linea.Substring(98, 13)) / 100
         'fecha reintento / fecha tope devoluc.	N 8 (AAAAMMDD)		fecha de vencimiento de reintento 
         If linea.Substring(111, 4) <> "0000" Then
            dato.FechaReintento = New DateTime(Int32.Parse(linea.Substring(111, 4)), Int32.Parse(linea.Substring(115, 2)), Int32.Parse(linea.Substring(117, 2)))
         End If
         'Importe debitado	N 13 (11 e 2 d)		importe del reintento
         dato.ImporteDebitado = Decimal.Parse(linea.Substring(119, 13)) / 100    'Viene en cero (esta mal).
         'Nueva sucursal bancaria	N 4	Codigo de sucursal nueva	idem envio debitos
         'Tipo de cuenta	N 1	Tipo de cuenta COBIS	idem envio debitos
         'Nueva cuenta bancaria	N 15	Nueva cuenta COBIS del adherente	idem envio debitos
         'Nueva identificacion del adherente	A 22	Nueva Identificacion Del cliente 	idem envio debitos
         'Datos de retorno	A 40	libre	idem envio debitos
         dato.DatosDelRetorno = linea.Substring(174, 40)
         'Sin uso 	A 5		idem envio debitos
         'Filler 	N 1	Relleno 	idem envio debitos
         If Not String.IsNullOrEmpty(dato.CodigoDeMotivoORechazo.Trim()) Then
            dato.ImporteADebitar = 0   'Por el momento lo limpio para que no sume en pantalla.
            dato.Alerta = "R"
         ElseIf dato.ImporteADebitar > dato.Saldo Then
            dato.Alerta = "S"
         End If
      End With

      Return dato
   End Function

#End Region

End Class