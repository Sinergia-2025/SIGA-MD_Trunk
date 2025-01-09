Imports System.Text
Imports System.IO
Imports System.Globalization

Public Class ArchivoPagoAInversionistasOrdPagoMacro

#Region "Propiedades"

   Private _datos As List(Of ArchivoPagoAInversionistasOrdPagoMacroDatos)
   Public Property Datos() As List(Of ArchivoPagoAInversionistasOrdPagoMacroDatos)
      Get
         If Me._datos Is Nothing Then
            Me._datos = New List(Of ArchivoPagoAInversionistasOrdPagoMacroDatos)()
         End If
         Return _datos
      End Get
      Set(ByVal value As List(Of ArchivoPagoAInversionistasOrdPagoMacroDatos))
         _datos = value
      End Set
   End Property

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarArchivo(ByVal destino As String)
      Dim stb As StringBuilder
      Try
         stb = New StringBuilder()

         For Each linea As ArchivoPagoAInversionistasOrdPagoMacroDatos In Datos
            stb.Append(linea.GetLinea()).AppendLine()
         Next

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

      Catch ex As Exception
         Throw
      End Try
   End Sub

#End Region

End Class

Public Class ArchivoPagoAInversionistasOrdPagoMacroDatos

#Region "Campos"

   Private _stb As StringBuilder

#End Region

#Region "Constructores"

   Public Sub New()
      Me._stb = New StringBuilder()
   End Sub

#End Region

#Region "Propiedades"

   Private _tdd_bnf_id As Integer
   ''' <summary>
   ''' Tipo de documento del beneficiario	N 2	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property TipoDocumento() As Integer
      Get
         Return _tdd_bnf_id
      End Get
      Set(ByVal value As Integer)
         _tdd_bnf_id = value
      End Set
   End Property

   Private _bnf_numdoc As Long
   ''' <summary>
   ''' Número de documento del beneficiario	N 14	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NroDocumento() As Long
      Get
         Return _bnf_numdoc
      End Get
      Set(ByVal value As Long)
         _bnf_numdoc = value
      End Set
   End Property

   Private _suc_entrega As Integer
   ''' <summary>
   ''' Sucursal de Entrega N 3	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property SucursalEntrega() As Integer
      Get
         Return _suc_entrega
      End Get
      Set(ByVal value As Integer)
         _suc_entrega = value
      End Set
   End Property

   Private _Opg_idopgcli As String
   ''' <summary>
   '''Clave Identificatoria de la Orden de Pago según el cliente. A 30	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property OrdenPagoCliente() As String
      Get
         Return _Opg_idopgcli
      End Get
      Set(ByVal value As String)
         _Opg_idopgcli = value
      End Set
   End Property

   Private _Opg_ordenalt As String
   ''' <summary>
   ''' Orden del pago / Razón social  alternativa.	A 40	no obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property OrdenPagoAlt() As String
      Get
         If Me._Opg_ordenalt.Length > 40 Then
            Return Me._Opg_ordenalt.Substring(0, 40)
         Else
            Return _Opg_ordenalt
         End If
      End Get
      Set(ByVal value As String)
         _Opg_ordenalt = value
      End Set
   End Property

   Private _Opg_imp_pago As Decimal
   ''' <summary>
   ''' Importe del Pago	D (13,2)	
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Importe() As Decimal
      Get
         Return _Opg_imp_pago
      End Get
      Set(ByVal value As Decimal)
         _Opg_imp_pago = value
      End Set
   End Property

   Private _cta_cuentadebito As Double
   ''' <summary>
   ''' Cuenta de débito 	N 25	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CuentaDebito() As Double
      Get
         Return _cta_cuentadebito
      End Get
      Set(ByVal value As Double)
         _cta_cuentadebito = value
      End Set
   End Property

   Private _opg_cuentapago As String
   'VERRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
   ''' <summary>
   ''' Cuenta de pago	N 25	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CuentaPago() As String
      Get
         Return _opg_cuentapago
      End Get
      Set(ByVal value As String)
         _opg_cuentapago = value
      End Set
   End Property

   Public ReadOnly Property EsDelBancoMacro As Boolean
      Get
         If Me.CuentaPago.Length > 3 Then
            Return (Me.CuentaPago.Trim().Substring(0, 3) = "285")
         Else
            Return False
         End If
      End Get
   End Property

   Private _mpg_id As Integer
   ''' <summary>
   ''' Modalidad de Pago N 2	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FormaPago() As Integer
      Get
         Return _mpg_id
      End Get
      Set(ByVal value As Integer)
         _mpg_id = value
      End Set
   End Property

   Private _opg_mar_regchq As Integer
   ''' <summary>
   ''' Marca de Registración de Cheque (Sólo para cheques de pago diferido) N 1	no obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property RegistCheque() As Integer
      Get
         Return _opg_mar_regchq
      End Get
      Set(ByVal value As Integer)
         _opg_mar_regchq = value
      End Set
   End Property

   Private _opg_fec_pago As Date
   ''' <summary>
   ''' Fecha de Pago date 10	 obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FechaPago() As Date
      Get
         Return _opg_fec_pago
      End Get
      Set(ByVal value As Date)
         _opg_fec_pago = value
      End Set
   End Property

   Private _opg_fec_pagodiferido As Date
   ''' <summary>
   '''Fecha de Pago Diferido (Requerido solo para modalidad de pago "cheque de pago diferido") date 10	 no obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FechaPagoDiferido() As Date
      Get
         Return _opg_fec_pagodiferido
      End Get
      Set(ByVal value As Date)
         _opg_fec_pagodiferido = value
      End Set
   End Property

   Private _usr_firmante1 As String
   ''' <summary>
   ''' Identificación del Firmante/Autorizante	A 10	
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property IdentificacionFirmante1() As String
      Get
         If Me._usr_firmante1.Length > 10 Then
            Return Me._usr_firmante1.Substring(0, 10)
         Else
            Return _usr_firmante1
         End If
      End Get
      Set(ByVal value As String)
         _usr_firmante1 = value
      End Set
   End Property

   Private _usr_firmante2 As String
   ''' <summary>
   ''' Identificación del Firmante/Autorizante	A 10	
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property IdentificacionFirmante2() As String
      Get
         If Me._usr_firmante2.Length > 10 Then
            Return Me._usr_firmante2.Substring(0, 10)
         Else
            Return _usr_firmante2
         End If
      End Get
      Set(ByVal value As String)
         _usr_firmante2 = value
      End Set
   End Property

   Private _usr_firmante3 As String
   ''' <summary>
   ''' Identificación del Firmante/Autorizante	A 10	
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property IdentificacionFirmante3() As String
      Get
         If Me._usr_firmante3.Length > 10 Then
            Return Me._usr_firmante3.Substring(0, 10)
         Else
            Return _usr_firmante3
         End If
      End Get
      Set(ByVal value As String)
         _usr_firmante3 = value
      End Set
   End Property

#End Region

#Region "Metodos Publicos"

   Public Function GetLinea() As String
      With Me._stb
         'DATO	FORMATO	USO	OBSERVACION
         .Length = 0

         'Tipo de documento del beneficiario	N 2	obligatorio
         .Append(Me.TipoDocumento.ToString("00"))
         .Append(Chr(9))
         'Número de documento del beneficiario	N 14	obligatorio
         .Append(Me.NroDocumento.ToString("00000000000000"))
         .Append(Chr(9))
         ' Sucursal de Entrega N 3	obligatorio
         .Append(Me.SucursalEntrega.ToString("000"))
         .Append(Chr(9))
         'Clave Identificatoria de la Orden de Pago según el cliente. A 30	obligatorio
         .Append(Me.OrdenPagoCliente.PadRight(30))
         .Append(Chr(9))
         ' Orden del pago / Razón social  alternativa.	A 40	no obligatorio
         .Append(Me.OrdenPagoAlt.PadRight(40))
         .Append(Chr(9))
         ' Importe del Pago	D (13,2)	   (15 en Total)
         .Append(Me.Importe.ToString("#0.00").Replace(".", ","))
         .Append(Chr(9))
         ' Cuenta de débito 	N 25	obligatorio
         .Append(Me.CuentaDebito.ToString())
         .Append(Chr(9))
         ' Cuenta de pago	N 25	obligatorio
         .Append(Me.CuentaPago)
         .Append(Chr(9))
         ' Modalidad de Pago N 2	obligatorio
         .Append(Me.FormaPago.ToString("00"))
         .Append(Chr(9))
         ' Marca de Registración de Cheque (Sólo para cheques de pago diferido) N 1	no obligatorio
         .Append(Me.RegistCheque.ToString("0"))
         .Append(Chr(9))
         ' Fecha de Pago date 10	 obligatorio
         .Append(Me.FechaPago.ToString("dd/MM/yyyy"))
         .Append(Chr(9))
         'Fecha de Pago Diferido (Requerido solo para modalidad de pago "cheque de pago diferido") date 10	 no obligatorio
         If Me.FechaPagoDiferido > Date.Parse("1900-01-01") Then
            .Append(Me.FechaPagoDiferido.ToString("dd/MM/yyyy"))
         Else
            .Append(Strings.Space(10))
         End If
         .Append(Chr(9))
         ' Identificación del Firmante/Autorizante	A 10	
         .Append(Me.IdentificacionFirmante1.PadRight(10))
         .Append(Chr(9))
         ' Identificación del Firmante/Autorizante2	A 10	
         .Append(Me.IdentificacionFirmante2.PadRight(10))
         .Append(Chr(9))
         ' Identificación del Firmante/Autorizante2	A 10	
         .Append(Me.IdentificacionFirmante3.PadRight(10))

      End With
      Return Me._stb.ToString()
   End Function

#End Region

End Class