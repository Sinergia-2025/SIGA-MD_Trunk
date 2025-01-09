Public Class ArchivoDebitoPresentacionRio

#Region "Propiedades"

   Private _TipoDeRegistro As String
   ''' <summary>
   ''' Fijo ‘10’ 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property TipoDeRegistro() As String
      Get
         Return _TipoDeRegistro
      End Get
      Set(value As String)
         _TipoDeRegistro = value
      End Set
   End Property

   Private _fechaPresentacion As DateTime
   ''' <summary>
   ''' AAAAMMDD 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FechaPresentacion() As DateTime
      Get
         Return _fechaPresentacion
      End Get
      Set(value As DateTime)
         _fechaPresentacion = value
      End Set
   End Property

   Private _cantidadDeRegistros As Integer
   ''' <summary>
   '''Cantidad de Registros ‘11’ 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CantidadDeRegistros() As Integer
      Get
         Return _cantidadDeRegistros
      End Get
      Set(value As Integer)
         _cantidadDeRegistros = value
      End Set
   End Property

   Private _ImporteTotal As Decimal
   ''' <summary>
   ''' 17 enteros + 2 decimales . Sin punto
   '''Sumatoria importes registros ‘11’ 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ImporteTotal() As Decimal
      Get
         Return _ImporteTotal
      End Get
      Set(value As Decimal)
         _ImporteTotal = value
      End Set
   End Property

   Private _datos As List(Of ArchivoDebitoPresentacionRioDatos)
   Public Property Datos() As List(Of ArchivoDebitoPresentacionRioDatos)
      Get
         If Me._datos Is Nothing Then
            Me._datos = New List(Of ArchivoDebitoPresentacionRioDatos)()
         End If
         Return _datos
      End Get
      Set(value As List(Of ArchivoDebitoPresentacionRioDatos))
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


         stb.Append(Me.TipoDeRegistro.ToString.PadRight(2))
         ' AAAAMMDD 
         stb.Append(Me.FechaPresentacion.ToString("yyyyMMdd"))
         'Cantidad de Registros ‘11’ 
         stb.Append(Me.CantidadDeRegistros.ToString("00000"))
         ' 17 enteros + 2 decimales . Sin punto. Sumatoria importes registros ‘11’ 
         stb.Append(Me.ImporteTotal.ToString("00000000000000000.00").Replace(",", "").Replace(".", ""))

         stb.AppendLine()

         For Each linea As ArchivoDebitoPresentacionRioDatos In Datos
            stb.Append(linea.GetLinea()).AppendLine()
         Next

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

      Catch ex As Exception
         Throw
      End Try
   End Sub

#End Region

End Class

Public Class ArchivoDebitoPresentacionRioDatos

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

   Private _TipoDeRegistro As String
   ''' <summary>
   ''' Fijo ‘10’ 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property TipoDeRegistro() As String
      Get
         Return _TipoDeRegistro
      End Get
      Set(value As String)
         _TipoDeRegistro = value
      End Set
   End Property


   Private _Servicio As String
   ''' <summary>
   ''' Código de Servicio definido en Banco Río
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Servicio() As String
      Get
         If Me._Servicio.Length > 10 Then
            Return Me._Servicio.Substring(0, 10)
         Else
            Return _Servicio
         End If
      End Get
      Set(value As String)
         _Servicio = value
      End Set
   End Property

   Private _Partida As Long
   ''' <summary>
   '''Nro. de Cliente definido por la Empresa.
   '''Alineado a la izquierda, completado con
   '''espacios 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Partida() As Long
      Get
         'If Me._Partida.Length > 22 Then
         Return Me._Partida
         'Else
         Return _Partida
         'End If
      End Get
      Set(value As Long)
         _Partida = value
      End Set
   End Property

   Private _CBU As String
   ''' <summary>
   ''' Totalmente completo 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CBU() As String
      Get
         Return _CBU
      End Get
      Set(value As String)
         _CBU = value
      End Set
   End Property

   Private _fechaDeVencimiento As DateTime
   ''' <summary>
   ''' AAAAMMDD 
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

   Private _importeDebito As Decimal
   ''' <summary>
   ''' 14 enteros + 2 decimales. Sin punto. 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ImporteDebito() As Decimal
      Get
         Return _importeDebito
      End Get
      Set(value As Decimal)
         _importeDebito = value
      End Set
   End Property

   Private _identificacionDebito As String = String.Empty
   ''' <summary>
   ''' Referencia unívoca del débito 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property IdentificacionDebito() As String
      Get
         If Me._identificacionDebito.Length > 16 Then
            Return Me._identificacionDebito.Substring(0, 16)
         Else
            Return _identificacionDebito
         End If
      End Get
      Set(value As String)
         _identificacionDebito = value
      End Set
   End Property

   Private _NombreAdherente As String = String.Empty
   ''' <summary>
   ''' Nombre del Adherente 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NombreAdherente() As String
      Get
         If Me._NombreAdherente.Length > 22 Then
            Return Me._NombreAdherente.Substring(0, 22)
         Else
            Return _NombreAdherente
         End If
      End Get
      Set(value As String)
         _NombreAdherente = value
      End Set
   End Property

   Private _Filler As String = String.Empty
   ''' <summary>
   ''' Vacío 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Filler() As String
      Get
         If Me._Filler.Length > 1 Then
            Return Me._Filler.Substring(0, 1)
         Else
            Return _Filler
         End If
      End Get
      Set(value As String)
         _Filler = value
      End Set
   End Property
   Private _ReferenciaEmpresa As String = String.Empty
   ''' <summary>
   ''' Dato libre de la empresa. 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ReferenciaEmpresa() As String
      Get
         If Me._ReferenciaEmpresa.Length > 50 Then
            Return Me._ReferenciaEmpresa.Substring(0, 50)
         Else
            Return _ReferenciaEmpresa
         End If
      End Get
      Set(value As String)
         _ReferenciaEmpresa = value
      End Set
   End Property

#End Region

#Region "Metodos Publicos"

   Public Function GetLinea() As String
      With Me._stb

         .Length = 0

         ' Fijo ‘10’ 
         .Append(Me.TipoDeRegistro.ToString.PadRight(2))
         ' Código de Servicio definido en Banco Río
         .Append(Me.Servicio.ToString.PadRight(10))
         'Nro. de Cliente definido por la Empresa. Alineado a la izquierda, completado con espacios 
         If Me._formatoAlineacionAdherente = "Derecha a Izquierda" Then
            .Append(Me.Partida.ToString("00000000000").PadLeft(22, Char.Parse(Me._caracterRellenado)))
         Else
            .Append(Me.Partida.ToString("00000000000").PadRight(22, Char.Parse(Me._caracterRellenado)))
         End If
         '.Append(Me.Partida.ToString("00000000000").PadLeft(22))
         ' Totalmente completo 
         .Append(Me.CBU.ToString.PadRight(22))
         ' AAAAMMDD 
         .Append(Me.FechaDeVencimiento.ToString("yyyyMMdd"))
         ' 14 enteros + 2 decimales. Sin punto. 
         .Append(Me.ImporteDebito.ToString("00000000000000.00").Replace(",", "").Replace(".", ""))
         ' Referencia unívoca del débito 
         .Append(Me.IdentificacionDebito.PadRight(15))
         ' Nombre del Adherente 
         .Append(Me.NombreAdherente.PadRight(30))
         .Append(Me.Filler.PadRight(1))
         ' Dato libre de la empresa. 
         .Append(Me.ReferenciaEmpresa.PadRight(50))

      End With
      Return Me._stb.ToString()
   End Function

#End Region

End Class