Imports System.Text
Imports System.IO
Imports System.Globalization

Public Class ArchivoPresentacionMaster

#Region "Propiedades"

    Private _numeroComercio As Long
    ''' <summary>
    '''Número de Comercio                           
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NumeroComercio() As Long
        Get
            Return _numeroComercio
        End Get
        Set(ByVal value As Long)
            _numeroComercio = value
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

    Private _datos As List(Of ArchivoPresentacionMasterDatos)
    Public Property Datos() As List(Of ArchivoPresentacionMasterDatos)
        Get
            If Me._datos Is Nothing Then
                Me._datos = New List(Of ArchivoPresentacionMasterDatos)()
            End If
            Return _datos
        End Get
        Set(ByVal value As List(Of ArchivoPresentacionMasterDatos))
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
            For Each ar As ArchivoPresentacionMasterDatos In Datos
                tot += ar.Importe
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

            'Cabecera

            'Número de comercio
            stb.Append(Me.NumeroComercio.ToString("0000000"))
            'Tipo de Registro
            stb.Append("1")
            'Fecha Presentacion. Formato: DDMMAA
            stb.Append(Me.FechaArchivo.ToString("ddMMyy"))
            'Cantidad de registros                                                    
            stb.Append(Datos.Count.ToString("0000000"))
            'Signo Importe
            If Me.TotalImporte >= 0 Then
                stb.Append("0")
            Else
                stb.Append("-")
            End If
            'Importe
            stb.Append(Me.TotalImporte.ToString("000000000000.00").Replace(",", "").Replace(".", ""))
            'Reservado – Constante espacios
            stb.Append(New String(" "c, 91))


            stb.AppendLine()

            'Detalle

            For Each linea As ArchivoPresentacionMasterDatos In Datos
                stb.Append(linea.GetLinea()).AppendLine()
            Next


            My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

End Class

Public Class ArchivoPresentacionMasterDatos

#Region "Campos"

    Private _stb As StringBuilder

#End Region

#Region "Constructores"

    Public Sub New()
        Me._stb = New StringBuilder()
    End Sub

#End Region

#Region "Propiedades"

    Private _numeroComercio As Long
    ''' <summary>
    '''Número de Comercio                           
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NumeroComercio() As Long
        Get
            Return _numeroComercio
        End Get
        Set(ByVal value As Long)
            _numeroComercio = value
        End Set
    End Property

    Private _tipoTarjeta As String = String.Empty
    ''' <summary>
    ''' Tipo Tarjeta         
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TipoTarjeta() As String
        Get
            If Me._tipoTarjeta.Length > 1 Then
                Return Me._tipoTarjeta.Substring(0, 1)
            Else
                Return _tipoTarjeta
            End If
        End Get
        Set(ByVal value As String)
            _tipoTarjeta = value
        End Set
    End Property

    Private _nroTarjeta As String = String.Empty
    ''' <summary>
    ''' Número de Tarjeta         
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NroTarjeta() As String
        Get
            If Me._nroTarjeta.Length > 19 Then
                Return Me._nroTarjeta.Substring(0, 19)
            Else
                Return _nroTarjeta
            End If
        End Get
        Set(ByVal value As String)
            _nroTarjeta = value
        End Set
    End Property


    Private _nroReferencia As Long
    ''' <summary>
    ''' Referencia o número de comprobante o Nro. Secuencial ascendente único por archivo    
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NroReferencia() As Long
        Get
            Return _nroReferencia
        End Get
        Set(ByVal value As Long)
            _nroReferencia = value
        End Set
    End Property


    Private _fechaVencimiento As DateTime
    ''' <summary>
    ''' Fecha de origen o vencimiento del débito
    ''' Formato: AAAAMMDD
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FechaVencimiento() As DateTime
        Get
            Return _fechaVencimiento
        End Get
        Set(ByVal value As DateTime)
            _fechaVencimiento = value
        End Set
    End Property

    Private _importe As Decimal
    ''' <summary>
    ''' Importe 
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


#End Region

#Region "Metodos Publicos"

    Public Function GetLinea() As String
        With Me._stb
            .Length = 0

            'Número de comercio
            .Append(Me.NumeroComercio.ToString("0000000"))
            'Tipo de Registro
            If Me.TipoTarjeta = "D" Then
                .Append("2")
            Else
                .Append("3")
            End If

            'Número de Tarjeta         
            .Append(Me.NroTarjeta.PadRight(16))
            ' Referencia o número de comprobante o Nro. Secuencial ascendente único por archivo    
            .Append(Me.NroReferencia.ToString("00000000"))
            'Cuota/s
            .Append("001")
            'Cuotas Plan
            .Append("001")
            'Frecuencia DB
            .Append("01")
            'Importe
            .Append(Me.Importe.ToString("000000000.00")).Replace(",", "").Replace(".", "")
         'Periodo
            .Append("  CRED")
            'Filler
            .Append(" ")
            ' Fecha vencimiento pago
            .Append(Me.FechaVencimiento.ToString("ddMMyy"))
            'Datos Auxiliares
            .Append(New String(" "c, 40))
            'Filler
            .Append(New String(" "c, 20))

        End With
        Return Me._stb.ToString()
    End Function

#End Region

End Class