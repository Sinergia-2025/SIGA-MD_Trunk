Public Class DebitosDirectosProcesoMacro
   Implements IDebitosDirectosProceso

   Private _add As ArchivoDebitoPresentacionMacro

   Public Sub CrearDD(dt As System.Data.DataTable,
                     banco As Eniac.Entidades.Banco,
                     nombreArchivo As String,
                     fechaVencimiento As Date,
                      nroRefinanciacion As Integer) Implements IDebitosDirectosProceso.CrearDD
      Dim i As Integer = 0

      Try
         Me._add = New ArchivoDebitoPresentacionMacro()

         Dim linea As ArchivoDebitoPresentacionMacroDatos
         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

         'Dim cbu As Decimal

         'en la primera linea tengo que cargar los datos de la cabecera****************************************************
         With Me._add

            'DATO	FORMATO	USO	OBSERVACION

            'Nro de convenio	N 5	Numero de convenio en COBIS	obligatorio
            .NroDeConvenio = banco.Convenio

            'Nro de servicio	A 10	Numero de servicio en COBIS	informar blancos
            .NroDeServicio = New String(" "c, 10)

            'Nro de empresa de sueldos	N 5	Numero de convenio AS en COBIS	informar ceros
            .NroDeEmpresaDeSueldos = 0

            'Fecha generacion de archivo	N 8 (AAAAMMDD)	fecha de generacion 	AAAAMMDD
            .FechaGeneracionDeArchivo = DateTime.Now

            'Moneda de la empresa	N 03	Moneda de rendción y acreditacion 	 002 - dolares 080 - pesos
            .MonedaDeLaEmpresa = 80

            'Tipo de movimientos del archivo	N 02	Identificacion de los movimientos	01 - Movimientos de Debitos Automaticos
            .TiposDeMovimientosDelArchivo = 1

            'desde la segunda linea en adelante tengo que cargar todos los registros.****************************************
            For Each dr As DataRow In dt.Rows

               If Not Boolean.Parse(dr("Selec").ToString()) Then
                  Continue For
               End If

               i += 1

               linea = New ArchivoDebitoPresentacionMacroDatos()

               With linea
                  'DATO	FORMATO	USO	OBSERVACION

                  'Nro de convenio	N 5	Numero de convenio en COBIS	obligatorio
                  .NroConvenio = Me._add.NroDeConvenio

                  'Nro de servicio	A 10	Numero de servicio en COBIS	obligatorio. De no existir informar blancos
                  .NroDeServicio = Me._add.NroDeServicio

                  'Nro de empresa de sueldos	N 5	Numero de convenio AS en COBIS	obligatorio. De no existir informar ceros
                  .NroDeEmpresaDeSueldos = Me._add.NroDeEmpresaDeSueldos

                  'Codigo de banco del adherente	N 3	Codigo de Banco asignado por BCRA	obligatorio
                  'Ignoro el seteo del Cliente que podria estar mal. la Posicion 9 lo contiene (valores 3 o 4).
                  '.CodigoDeBancoDelAdherente = Short.Parse(dr("IdBanco").ToString())
                  .CodigoDeBancoDelAdherente = Short.Parse(dr("CBU").ToString().Substring(0, 3))

                  'Codigo de sucursal de la cuenta	N 4	Codigo de sucursal	Para Banco Macro  informar el numero de sucursal. 
                  'Para otros bancos, informar las posiciones 4 a 7 del bloque 1 De la CBU
                  'cbu = Decimal.Parse(dr("CBU").ToString())

                  Dim cbu As String = dr("CBU").ToString()
                  Dim cbud As Decimal
                  If Not Decimal.TryParse(cbu, cbud) Then
                     Dim mensajeError As String = String.Format("El CBU del cliente {0} ({1}) es inválido. Por favor verifique.",
                                                                dr("NombreCliente"), dr("CodigoCliente"))
                     dr.SetColumnError("CBU", mensajeError)
                     Throw New Exception(mensajeError)
                  End If

                  .CodigoDeSucursalDeLaCuenta = Integer.Parse(cbu.Substring(3, 4))

                  'Tipo de cuenta	N 1	Tipo de cuenta COBIS	3 - Cta Cte ,  4 - Caja de Ahorros para cuentas de Banco Macro - Bansud. 
                  'Para cuentas de otros bancos no informar
                  If .CodigoDeBancoDelAdherente = Eniac.Entidades.Banco.Codigos.Macro Then 'banco MACRO
                     'Ignoro el seteo del Cliente que podria estar mal. la Posicion 9 lo contiene (valores 3 o 4).
                     .TipoDeCuenta = Integer.Parse(cbu.Substring(8, 1))
                  Else
                     .TipoDeCuenta = 0   'Esta en cero pero para recordar que corresponde dicho valor.
                  End If

                  'Cuenta bancaria del adherente	N 15	Cuenta COBIS del adherente	Para Bco Macro informar el numero de cuenta. 
                  'Para otros bancos, informar el bloque 2 De la CBU y rellenar con un cero a izquierda.
                  If .CodigoDeBancoDelAdherente = Eniac.Entidades.Banco.Codigos.Macro Then
                     .CuentaBancariaDelAdherente = Decimal.Parse(dr("NumeroCuentaBancaria").ToString().Replace("-", "").Replace("/", ""))
                  Else 'otros bancos
                     .CuentaBancariaDelAdherente = Decimal.Parse(cbu.Substring(8, 14)) 'Envio 14 porque para Otros incluye un cero delante.
                  End If

                  'Identificacion actual del adherente	A 22	Identif. Del cliente con la empresa	obligatorio
                  .IdentificacionActualDelAdherente = dr("CodigoCliente").ToString()

                  'Identificacion del debito	A 15	Numero de factura  / recibo identif.	obligatorio. 
                  'Identificacion del comprobante o recibo a debitar
                  .IdentificacionDelDebito = Integer.Parse(dr("CentroEmisor").ToString()).ToString("0000") + Long.Parse(dr("NumeroComprobante").ToString()).ToString("00000000")
                  '.IdentificacionDelDebito = dr("CodigoCliente").ToString()

                  'Fecha de vencimiento	N 8 (AAAAMMDD)	Fecha aplicación / ABM	obligatoria
                  '.FechaDeVencimiento = DateTime.Parse(dr("FechaVencimiento").ToString())
                  .FechaDeVencimiento = fechaVencimiento

                  'Moneda del debito	N 3	Moneda a debitar / debitada	002 - dolares 080 - pesos
                  .MonedaDelDebito = 80

                  'Importe a debitar	N 13 (11 e 2 d)	importe de la transaccion 	no informar punto decimal
                  '.ImporteADebitar = Decimal.Parse(dr("ImporteTotal").ToString())
                  .ImporteADebitar = Decimal.Parse(dr("SaldoCtaCte").ToString())

               End With

               Me._add.Datos.Add(linea)

            Next
            .GrabarArchivo(nombreArchivo)
         End With

         If stb.Length > 0 Then
            MessageBox.Show(stb.ToString(), "Debitos Directos", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If

      Catch ex As Exception
         Throw New Exception(ex.Message & " Linea " & i.ToString())
      End Try
   End Sub

   Public ReadOnly Property NumeroDeRegistros As Integer Implements IDebitosDirectosProceso.NumeroDeRegistros
      Get
         Return Me._add.Datos.Count
      End Get
   End Property

End Class
