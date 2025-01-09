Imports actual = Eniac.Entidades.Usuario.Actual
Imports System.Text
Imports System.IO
Imports System.Globalization

Public Class ArchivoRendicionVisa

#Region "Propiedades"

   Public Property NumeroEstablecimiento As String
   Public Property FechaArchivo As DateTime
   Public Property Datos As List(Of ArchivoRendicionVisaDatos)

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
         For Each ar As ArchivoRendicionVisaDatos In Datos
            tot += ar.Importe
         Next
         Return tot
      End Get
   End Property

#End Region

   Public Sub New()
      Datos = New List(Of ArchivoRendicionVisaDatos)()
   End Sub

   Public Function GetInfo(archivoFisico As StreamReader, tomaFoto As Boolean) As ArchivoRendicionVisa
      Dim linea As String
      Dim arDa As ArchivoRendicionVisa = New ArchivoRendicionVisa()
      linea = archivoFisico.ReadLine()
      'leo la primer linea, la cual tengo que recuperar la información del header

      'Nro. de establecimiento asignado por VISA. 
      'Son los cuatro dígitos que figuran en el mail de “Confirmación de aprobación de solicitud” que recibe la empresa.
      Me.NumeroEstablecimiento = linea.Substring(19, 10)

      'TODO: DB
      ' ''If Me.NumeroEstablecimiento <> Publicos.NumeroEstablecimientoVisa Then
      ' ''   Throw New Exception(String.Format("El archivo que está importando pertenece a otra empresa.{0}{0}Su codigo Establecimiento VISA: {1}{0}Establecimiento del archivo: {2}",
      ' ''                                     Environment.NewLine, Publicos.NumeroEstablecimientoVisa, Me.NumeroEstablecimiento))
      ' ''End If

      'Fecha de generación del archivo. Debe coincidir con la fecha del nombre del archivo
      'Formato: SSAAMMDD + ddmm
      Me.FechaArchivo = New DateTime(Int32.Parse(linea.Substring(29, 4)), Int32.Parse(linea.Substring(33, 2)), Int32.Parse(linea.Substring(35, 2)),
                                     Int32.Parse(linea.Substring(37, 2)), Int32.Parse(linea.Substring(39, 2)), 0)

      linea = archivoFisico.ReadLine()
      Do While linea IsNot Nothing
         If linea.Substring(0, 1) = "1" Then 'es una detalle
            Me.Datos.Add(New ArchivoRendicionVisaDatos().GetDato(linea, tomaFoto))
         ElseIf linea.Substring(0, 1) = "9" Then 'es pie
            'controlo que la cantidad de registros informados y en el archivo esten bien
            If Int32.Parse(linea.Substring(41, 7)) <> Me.Datos.Count Then
               Throw New Exception("La cantidad de registros del archivo es incorrecta.")
            End If
         End If
         linea = archivoFisico.ReadLine()
      Loop

      Return Me
   End Function

End Class

Public Class ArchivoRendicionVisaDatos

#Region "Propiedades"
   Public Property Banco As String
   Public Property Sucursal As String
   Public Property Lote As String
   Public Property CodigoTransaccion As String
   Public Property NumeroEstablecimiento As String
   Public Property NroTarjeta As String
   Public Property NroCupon As String
   Public Property Fecha As DateTime
   Public Property Importe As Decimal
   Public Property Cuotas As String
   Public Property Identificador As String
   Public Property PrimerDebito As String
   Public Property NumeroCuenta As String
   Public Property SegRama As String
   Public Property SegEndoso As String



   Public Property EstadoMovimiento As String
   Public Property CodigoRechazo1 As String
   Public Property DescripcionRechazo1 As String
   Public Property CodigoRechazo2 As String
   Public Property DescripcionRechazo2 As String
   Public Property NroTarjetaNueva As String
   Public Property FechaPresentacion As DateTime
   Public Property FechaPago As DateTime?
   Public Property Cartera As String


   Public Property Cliente As Entidades.ClienteReducido
   Public Property Caja As Eniac.Entidades.CajaNombre
   Public Property Alerta As String

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdCliente() As Long
      Get
         If Cliente Is Nothing Then Return 0
         Return Cliente.IdCliente
      End Get
   End Property
   Public ReadOnly Property CodigoCliente() As Long
      Get
         If Cliente Is Nothing Then Return 0
         Return Cliente.CodigoCliente
      End Get
   End Property

   Public ReadOnly Property NombreCliente() As String
      Get
         If Cliente Is Nothing Then Return String.Empty
         Return Cliente.NombreCliente
      End Get
   End Property

   Public ReadOnly Property NombreCategoria() As String
      Get
         If Cliente Is Nothing OrElse Cliente.Categoria Is Nothing Then Return String.Empty
         Return Cliente.Categoria.NombreCategoria
      End Get
   End Property

   Public ReadOnly Property IdCaja() As Integer
      Get
         If Cliente Is Nothing OrElse Cliente.Categoria Is Nothing Then Return 0
         Return Cliente.Categoria.IdCaja
      End Get
   End Property

   Public ReadOnly Property NombreCaja() As String
      Get
         If Caja Is Nothing Then Return String.Empty
         Return Caja.NombreCaja
      End Get
   End Property

   Public ReadOnly Property Saldo() As Decimal
      Get
         If Cliente Is Nothing Then Return 0
         Return Cliente.SaldoCtaCte
      End Get
   End Property

   Public ReadOnly Property Rechazado() As Boolean
      Get
         Return ((IsNumeric(CodigoRechazo1) AndAlso Integer.Parse(CodigoRechazo1) > 0) Or
                 (IsNumeric(CodigoRechazo2) AndAlso Integer.Parse(CodigoRechazo2) > 0))
      End Get
   End Property

   Public ReadOnly Property PuedeProcesar() As Boolean
      Get
         Return Not Rechazado And Importe <= Saldo
      End Get
   End Property

#End Region

#End Region

   Public Function GetDato(linea As String, tomaFoto As Boolean) As ArchivoRendicionVisaDatos
      Dim dato As ArchivoRendicionVisaDatos = New ArchivoRendicionVisaDatos()
      With dato

         'Código de Registro. Valor fijo: 1. Indica que este renglón forma parte del detalle.
         dato.Banco = linea.Substring(1, 3)
         dato.Sucursal = linea.Substring(4, 3)
         dato.Lote = linea.Substring(7, 4)
         dato.CodigoTransaccion = linea.Substring(11, 4)
         dato.NumeroEstablecimiento = linea.Substring(16, 10)
         dato.NroTarjeta = linea.Substring(26, 16)
         dato.NroCupon = linea.Substring(42, 8)
         dato.Fecha = New DateTime(2000 + Integer.Parse(linea.Substring(54, 2)), Integer.Parse(linea.Substring(52, 2)), Integer.Parse(linea.Substring(50, 2)))
         dato.Importe = Decimal.Parse(linea.Substring(62, 15)) / 100
         dato.Cuotas = linea.Substring(77, 2)
         dato.Identificador = linea.Substring(94, 15).TrimStart("0"c)
         dato.PrimerDebito = linea.Substring(109, 1)
         dato.NumeroCuenta = linea.Substring(110, 10)
         dato.SegRama = linea.Substring(120, 3)
         dato.SegEndoso = linea.Substring(123, 3)

         dato.EstadoMovimiento = linea.Substring(129, 1)
         dato.CodigoRechazo1 = linea.Substring(130, 2).Replace("00", "")
         dato.DescripcionRechazo1 = linea.Substring(132, 29)
         dato.CodigoRechazo2 = linea.Substring(161, 2).Replace("00", "")
         dato.DescripcionRechazo2 = linea.Substring(163, 29)
         dato.NroTarjetaNueva = linea.Substring(208, 16)

         If Not String.IsNullOrWhiteSpace(linea.Substring(224, 6)) Then
            dato.FechaPresentacion = New DateTime(2000 + Integer.Parse(linea.Substring(228, 2)), Integer.Parse(linea.Substring(226, 2)), Integer.Parse(linea.Substring(224, 2)))
         End If
         If Not String.IsNullOrWhiteSpace(linea.Substring(230, 6)) Then
            dato.FechaPago = New DateTime(2000 + Integer.Parse(linea.Substring(234, 2)), Integer.Parse(linea.Substring(232, 2)), Integer.Parse(linea.Substring(230, 2)))
         End If
         dato.Cartera = linea.Substring(236, 2)

         'TODO: DB
         ' ''If IsNumeric(dato.NroTarjeta.Trim()) AndAlso IsNumeric(dato.Identificador.Trim()) Then
         ' ''   If tomaFoto Then
         ' ''      dato.Cliente = New Reglas.Clientes().LiquidacionesClientesUnoReducidoPorTarjeta(Long.Parse(dato.NroTarjeta.Trim()), Long.Parse(dato.Identificador.Trim()))
         ' ''   Else
         ' ''      dato.Cliente = New Reglas.Clientes().ClientesUnoReducidoPorTarjeta(Long.Parse(dato.NroTarjeta.Trim()), Long.Parse(dato.Identificador.Trim()))
         ' ''   End If
         ' ''   If dato.IdCaja > 0 Then
         ' ''      dato.Caja = New Eniac.Reglas.CajasNombres().GetUna(actual.Sucursal.IdSucursal, dato.IdCaja)
         ' ''   End If
         ' ''End If

         If dato.Rechazado Then
            dato.Importe = 0   'Por el momento lo limpio para que no sume en pantalla.
            dato.Alerta = "R"
         ElseIf dato.Importe > dato.Saldo Then
            dato.Alerta = "S"
         End If
      End With

      Return dato
   End Function

End Class