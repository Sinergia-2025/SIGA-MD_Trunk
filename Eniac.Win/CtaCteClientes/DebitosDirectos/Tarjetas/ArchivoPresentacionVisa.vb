Imports System.Text
Imports System.IO
Imports System.Globalization

Public Class ArchivoPresentacionVisa

#Region "Propiedades"

    Private _numeroEstablecimiento As String
    ''' <summary>
    '''Número del Establecimiento que generó el archivo                           
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NumeroEstablecimiento() As String
        Get
            Return _numeroEstablecimiento
        End Get
        Set(ByVal value As String)
            _numeroEstablecimiento = value
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

    Private _datos As List(Of ArchivoPresentacionVisaDatos)
    Public Property Datos() As List(Of ArchivoPresentacionVisaDatos)
        Get
            If Me._datos Is Nothing Then
                Me._datos = New List(Of ArchivoPresentacionVisaDatos)()
            End If
            Return _datos
        End Get
        Set(ByVal value As List(Of ArchivoPresentacionVisaDatos))
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
            For Each ar As ArchivoPresentacionVisaDatos In Datos
                tot += ar.Importe
            Next
            Return tot
        End Get
    End Property

#End Region

#Region "Metodos Publicos"

    Public Sub GrabarArchivo(ByVal destino As String, ByVal tipoTarjeta As String)
        Dim stb As StringBuilder
        Try
            stb = New StringBuilder()

            'Cabecera

            'Tipo de Registro (Fijo "0")  	
            stb.Append("0")
            'Constante  "DEBLIQC"    y un blanco 
            If tipoTarjeta = "VISA - CREDITO" Then
                stb.Append("DEBLIQC ")
            Else
                stb.Append("DEBLIQD ")
            End If
            'Número del Establecimiento que generó el archivo
            stb.Append(Me.NumeroEstablecimiento.PadRight(10))
            'Constante “900000” 	u cuatro blancos                                      
            stb.Append("900000    ")
            'Fecha de generación del archivo.Formato: AAAAMMDD
            stb.Append(Me.FechaArchivo.ToString("yyyyMMdd"))
            'Hora de generación del archivo (HHMM)
            stb.Append(Me.FechaArchivo.ToString("HHmm"))
            'Tipo de Archivo. Débitos a liquidar “0”= Altas  
            stb.Append("0")
            'Estado archivo - Constante espacios   
            stb.Append(New String(" "c, 2))
            'Reservado – Constante espacios
            stb.Append(New String(" "c, 55))
            'Marca de fin de registro – Constante “*”        
            stb.Append("*")

            stb.AppendLine()

            'Detalle

            For Each linea As ArchivoPresentacionVisaDatos In Datos
                stb.Append(linea.GetLinea()).AppendLine()
            Next

            'stb.AppendLine()
            'Pie

            'Código del tipo de Registro – Constante “9”                            
            stb.Append("9")
            'Nombre del archivo - Constante “DEBLIQC”   y un blanco    
            If tipoTarjeta = "VISA - CREDITO" Then
                stb.Append("DEBLIQC ")
            Else
                stb.Append("DEBLIQD ")
            End If
            'Número del Establecimiento que generó el archivo
            stb.Append(Me.NumeroEstablecimiento.PadRight(10))
            'Entidad de destino – Constante “900000”   y cuatro blancos                                         
            stb.Append("900000    ")
            'Fecha de generación del archivo.Formato: AAAAMMDD
            stb.Append(Me.FechaArchivo.ToString("yyyyMMdd"))
            'Hora de generación del archivo (HHMM)
            stb.Append(Me.FechaArchivo.ToString("HHmm"))
            'Cantidad total registros detalle                                                   
            stb.Append(Datos.Count.ToString("0000000"))
            'Sumatoria Importes registros detalle
            stb.Append(Me.TotalImporte.ToString("0000000000000.00").Replace(",", "").Replace(".", ""))
            'Reservado – Constante espacios
            stb.Append(New String(" "c, 36))
            'Marca de fin de registro – Constante “*”        
            stb.Append("*")

            stb.AppendLine()


            My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

        Catch ex As Exception
            Throw
        End Try
    End Sub

#End Region

End Class

Public Class ArchivoPresentacionVisaDatos

#Region "Campos"

    Private _stb As StringBuilder

#End Region

#Region "Constructores"

    Public Sub New()
        Me._stb = New StringBuilder()
    End Sub

#End Region

#Region "Propiedades"

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

    Private _identificadorDebito As String = String.Empty
    ''' <summary>
    ''' Identificador del débito  	     
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IdentintificadorDebito() As String
        Get
            If Me._identificadorDebito.Length > 15 Then
                Return Me._identificadorDebito.Substring(0, 15)
            Else
                Return _identificadorDebito
            End If
        End Get
        Set(ByVal value As String)
            _identificadorDebito = value
        End Set
    End Property


#End Region

#Region "Metodos Publicos"

    Public Function GetLinea() As String
        With Me._stb
            .Length = 0

            'Tipo de Registro (Fijo "1")  	
            .Append("1")
            'Número de Tarjeta         
            .Append(Me.NroTarjeta.PadRight(16))
            'Reservado – Constante espacios                                                        
            .Append("   ")
            ' Referencia o número de comprobante o Nro. Secuencial ascendente único por archivo    
            .Append(Me.NroReferencia.ToString("00000000"))
            ' Fecha de origen o vencimiento del débito
            .Append(Me.FechaVencimiento.ToString("yyyyMMdd"))
            'Código de Transacción – Constante 0005
            .Append("0005")
            'Importe
            .Append(Me.Importe.ToString("0000000000000.00")).Replace(",", "").Replace(".", "")
            'Identificador del débito  
            .Append(Me.IdentintificadorDebito.PadRight(15))
            'Código de alta de Identificador Constante “E” si es el primer débito informado, si no espacios.                                   
            .Append("E")
            'Estado del registro – Constante espacios                                          
            .Append("  ")
            'Reservado – Constante espacios                                                        
            .Append(New String(" "c, 26))
            'Marca de fin de registro – Constante “*”        
            .Append("*")

        End With
        Return Me._stb.ToString()
    End Function

#End Region

End Class