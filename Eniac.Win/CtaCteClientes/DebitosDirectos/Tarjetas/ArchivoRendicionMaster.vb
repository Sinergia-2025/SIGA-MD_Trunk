Imports System.Text
Imports System.IO
Imports System.Globalization

Public Class ArchivoRendicionMaster

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

    Private _datos As List(Of ArchivoRendicionMasterDatos)
    Public Property Datos() As List(Of ArchivoRendicionMasterDatos)
        Get
            If Me._datos Is Nothing Then
                Me._datos = New List(Of ArchivoRendicionMasterDatos)()
            End If
            Return _datos
        End Get
        Set(ByVal value As List(Of ArchivoRendicionMasterDatos))
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
            For Each ar As ArchivoRendicionMasterDatos In Datos
                tot += ar.Importe
            Next
            Return tot
        End Get
    End Property

#End Region

    Public Function GetInfo(archivoFisico As StreamReader) As ArchivoRendicionMaster

        Dim linea As String
        Dim arDa As ArchivoRendicionMaster = New ArchivoRendicionMaster()
        linea = archivoFisico.ReadLine()
        'leo la primer linea, la cual tengo que recuperar la información del header

        'Nro. de empresa asignado por Banelco. 
        'Son los cuatro dígitos que figuran en el mail de “Confirmación de aprobación de solicitud” que recibe la empresa.
        Me.CodigoEmpresa = Int32.Parse(linea.Substring(4, 4))
        'Fecha de generación del archivo. Debe coincidir con la fecha del nombre del archivo
        'Formato: AAAAMMDD
        Me.FechaArchivo = New DateTime(Int32.Parse(linea.Substring(8, 4)), Int32.Parse(linea.Substring(12, 2)), Int32.Parse(linea.Substring(14, 2)))

        linea = archivoFisico.ReadLine()
        Do While linea IsNot Nothing
            If linea.Substring(0, 1) = "5" Then 'es una detalle
                Me.Datos.Add(New ArchivoRendicionMasterDatos().GetDato(linea))
            Else
                ' = 9 then Trailer
                'controlo que la cantidad de registros informados y en el archivo esten bien
                If Int32.Parse(linea.Substring(16, 7)) <> Me.Datos.Count Then
                    Throw New Exception("La cantidad de registros del archivo es incorrecta.")
                End If

            End If
            linea = archivoFisico.ReadLine()
        Loop

        Return Me
    End Function

End Class

Public Class ArchivoRendicionMasterDatos

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

    Private _nombreCliente As String = String.Empty
    ''' <summary>
    ''' Nombre del cliente en la empresa. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NombreCliente() As String
        Get
            If Me._nombreCliente.Length > 19 Then
                Return Me._nombreCliente.Substring(0, 19)
            Else
                Return _nombreCliente
            End If
        End Get
        Set(ByVal value As String)
            _nombreCliente = value
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

    Private _fechaDeVencimiento As DateTime
    ''' <summary>
    ''' Fecha del primer vencimiento de la factura abonada, independientemente de si la empresa trabaja con más vencimientos.
    ''' En caso de ser un pago sin factura, se rellena con ceros.
    ''' Formato: AAAAMMDD
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

    Private _fechaAplicacion As DateTime
    ''' <summary>
    ''' Fecha en que se cobró la factura.
    ''' Formato: AAAAMMDD
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FechaAplicacion() As DateTime
        Get
            Return _fechaAplicacion
        End Get
        Set(ByVal value As DateTime)
            _fechaAplicacion = value
        End Set
    End Property

    Private _importe As Decimal
    ''' <summary>
    ''' Importe abonado. Formato: 9 enteros, 2 decimales, sin separadores.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Importe() As Decimal
        Get
            Return _importe
        End Get
        Set(ByVal value As Decimal)
            _importe = value
        End Set
    End Property

    Private _codigoMovimiento As Short
    ''' <summary>
    ''' Código de movimiento. Valores(posibles) 1 = Pago sin factura. 2 = Pago con factura. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CodigoMovimiento() As Short
        Get
            Return _codigoMovimiento
        End Get
        Set(ByVal value As Short)
            _codigoMovimiento = value
        End Set
    End Property

    Private _fechaAcreditacion As DateTime
    ''' <summary>
    ''' Fecha en que se le acreditan los fondos a la empresa. Debe coincidir con la fecha del nombre del 
    ''' archivo, del header y del trailer.
    ''' Formato: AAAAMMDD
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FechaAcreditacion() As DateTime
        Get
            Return _fechaAcreditacion
        End Get
        Set(ByVal value As DateTime)
            _fechaAcreditacion = value
        End Set
    End Property

    Private _canalPago As String = String.Empty
    ''' <summary>
    ''' Canal de pago por el cual se abonó la factura. Valores posibles: PC = Pagomiscuentas HB = Home Banking S1 = ATM 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CanalPago() As String
        Get
            If Me._canalPago.Length > 2 Then
                Return Me._canalPago.Substring(0, 2)
            Else
                Return _canalPago
            End If
        End Get
        Set(ByVal value As String)
            _canalPago = value
        End Set
    End Property

    Private _nroControl As String = String.Empty
    ''' <summary>
    ''' Número de control generado por Banelco, informado en el ticket.  
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NroControl() As String
        Get
            If Me._nroControl.Length > 4 Then
                Return Me._nroControl.Substring(0, 4)
            Else
                Return _nroControl
            End If
        End Get
        Set(ByVal value As String)
            _nroControl = value
        End Set
    End Property

    Private _codigoProvincia As String = String.Empty
    ''' <summary>
    ''' Si la cobranza se realizó por medio de ATM, se informa el código de provincia de la terminal. Caso contrario se rellena con espacios.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CodigoProvincia() As String
        Get
            If Me._codigoProvincia.Length > 3 Then
                Return Me._codigoProvincia.Substring(0, 3)
            Else
                Return _codigoProvincia
            End If
        End Get
        Set(ByVal value As String)
            _codigoProvincia = value
        End Set
    End Property

#End Region

#Region "Metodos Publicos"

    Public Function GetDato(linea As String) As ArchivoRendicionMasterDatos
        Dim dato As ArchivoRendicionMasterDatos = New ArchivoRendicionMasterDatos()
        With dato

            'Código de Registro. Valor fijo: 5. Indica que este renglón forma parte del detalle.
            'Identificación del cliente en la empresa. 
            'Se refiere a la identificación que deberá ingresar el cliente para poder pagar, que le sirve a la empresa para saber quien le está pagando. 
            'Son los números que componen el “concepto utilizado como ID del cliente” que la empresa completó en el formulario de adhesión.
            dato.NroReferencia = linea.Substring(1, 19)
            'Identificación de la factura. 
         'Se refiere a la identificación particular de la factura que está pagando el cliente. No tiene que ser obligatoriamente el “Nro. de Factura”, sino que puede ser cualquier número que utilice la empresa para individualizar el pago (puede que para un mismo Nro. Referencia, haya varios Id. Factura, si un cliente tiene varias facturas a pagar).
         'TODO: DB
         ' ''dato.NombreCliente = New Reglas.Clientes()._GetUnoPorCodigo(Long.Parse(dato.NroReferencia.ToString())).NombreCliente

            dato.IdFactura = linea.Substring(20, 20)
            'Fecha del primer vencimiento de la factura abonada, independientemente de si la empresa trabaja con más vencimientos.
            'En caso de ser un pago sin factura, se rellena con ceros.
            'Formato: AAAAMMDD
            If linea.Substring(40, 8) <> "00000000" Then
                dato.FechaDeVencimiento = New DateTime(Int32.Parse(linea.Substring(40, 4)), Int32.Parse(linea.Substring(44, 2)), Int32.Parse(linea.Substring(46, 2)))
            End If
            'Fecha en que se cobró la factura.
            'Formato: AAAAMMDD
            dato.FechaAplicacion = New DateTime(Int32.Parse(linea.Substring(49, 4)), Int32.Parse(linea.Substring(53, 2)), Int32.Parse(linea.Substring(55, 2)))
            'Importe abonado. Formato: 9 enteros, 2 decimales, sin separadores.
            dato.Importe = Decimal.Parse(linea.Substring(57, 11)) / 100
            'Código de movimiento. Valores(posibles) 1 = Pago sin factura. 2 = Pago con factura. 
            dato.CodigoMovimiento = Short.Parse(linea.Substring(68, 1))
            'Fecha en que se le acreditan los fondos a la empresa. Debe coincidir con la fecha del nombre del archivo, del header y del trailer.
            'Formato: AAAAMMDD
            dato.FechaAcreditacion = New DateTime(Int32.Parse(linea.Substring(69, 4)), Int32.Parse(linea.Substring(73, 2)), Int32.Parse(linea.Substring(75, 2)))
            'Canal de pago por el cual se abonó la factura. Valores posibles: PC = Pagomiscuentas HB = Home Banking S1 = ATM 
            dato.CanalPago = linea.Substring(77, 2)
            'Número de control generado por Banelco, informado en el ticket. 
            dato.NroControl = linea.Substring(79, 4)
            'Si la cobranza se realizó por medio de ATM, se informa el código de provincia de la terminal. Caso contrario se rellena con espacios.
            dato.CodigoProvincia = linea.Substring(83, 3)

        End With

        Return dato
    End Function

#End Region

End Class