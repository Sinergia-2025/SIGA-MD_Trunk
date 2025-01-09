Imports System.Text
Imports System.IO
Imports System.Globalization

Public Class ArchivoPagoAInversionistasBnfMacro

#Region "Propiedades"

   Private _datos As List(Of ArchivoPagoAInversionistasBnfMacroDatos)
   Public Property Datos() As List(Of ArchivoPagoAInversionistasBnfMacroDatos)
      Get
         If Me._datos Is Nothing Then
            Me._datos = New List(Of ArchivoPagoAInversionistasBnfMacroDatos)()
         End If
         Return _datos
      End Get
      Set(ByVal value As List(Of ArchivoPagoAInversionistasBnfMacroDatos))
         _datos = value
      End Set
   End Property

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarArchivo(ByVal destino As String)
      Dim stb As StringBuilder
      Try
         stb = New StringBuilder()

         For Each linea As ArchivoPagoAInversionistasBnfMacroDatos In Datos
            stb.Append(linea.GetLinea()).AppendLine()
         Next

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

      Catch ex As Exception
         Throw
      End Try
   End Sub

#End Region

End Class

Public Class ArchivoPagoAInversionistasBnfMacroDatos

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
   ''' <returns>_tdd_bnf_id</returns>
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
   ''' <returns>_bnf_numdoc</returns>
   ''' <remarks></remarks>
   Public Property NroDocumento() As Long
      Get
         Return _bnf_numdoc
      End Get
      Set(ByVal value As Long)
         _bnf_numdoc = value
      End Set
   End Property

   Private _cib_id As Integer
   ''' <summary>
   ''' Condición de Ingresos Brutos	N 2	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns>_cib_id</returns>
   ''' <remarks></remarks>
   Public Property IdCondicionIngresosBrutos() As Integer
      Get
         Return _cib_id
      End Get
      Set(ByVal value As Integer)
         _cib_id = value
      End Set
   End Property
   Private _cng_id As Integer
   ''' <summary>
   '''Condición de Ganancias	N 2	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns>_cng_id</returns>
   ''' <remarks></remarks>
   Public Property IdCondicionGanancias() As Integer
      Get
         Return _cng_id
      End Get
      Set(ByVal value As Integer)
         _cng_id = value
      End Set
   End Property

   Private _cni_id As Integer
   ''' <summary>
   ''' Condición de I.V.A.	N 2	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property IdCategoriaFiscal() As Integer
      Get
         Return _cni_id
      End Get
      Set(ByVal value As Integer)
         _cni_id = value
      End Set
   End Property

   Private _bnf_razonsocial As String
   ''' <summary>
   ''' Razón social del beneficiario	A 40	
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NombreCliente() As String
      Get
         If Me._bnf_razonsocial.Length > 40 Then
            Return Me._bnf_razonsocial.Substring(0, 40)
         Else
            Return _bnf_razonsocial
         End If
      End Get
      Set(ByVal value As String)
         _bnf_razonsocial = value
      End Set
   End Property

   Private _bnf_calle As String
   ''' <summary>
   ''' Calle	A 60	
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property Calle() As String
      Get
         If Me._bnf_calle.Length > 60 Then
            Return Me._bnf_calle.Substring(0, 60)
         Else
            Return _bnf_calle
         End If
      End Get
      Set(ByVal value As String)
         _bnf_calle = value
      End Set
   End Property

   Private _bnf_numpuerta As Integer
   ''' <summary>
   ''' Número de puerta	N 8	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property NumeroPuerta() As Integer
      Get
         Return _bnf_numpuerta
      End Get
      Set(ByVal value As Integer)
         _bnf_numpuerta = value
      End Set
   End Property

   Private _bnf_unidadfuncional As String
   ''' <summary>
   ''' Unidad funcional / Piso, Departamento, etc.	A 20	
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property PisoDpto() As String
      Get
         If Me._bnf_unidadfuncional.Length > 20 Then
            Return Me._bnf_unidadfuncional.Substring(0, 20)
         Else
            Return _bnf_unidadfuncional
         End If
      End Get
      Set(ByVal value As String)
         _bnf_unidadfuncional = value
      End Set
   End Property

   Private _ccp_id As Integer
   ''' <summary>
   ''' Código Postal	N 6	obligatorio
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property IdLocalidad() As Integer
      Get
         Return _ccp_id
      End Get
      Set(ByVal value As Integer)
         _ccp_id = value
      End Set
   End Property

   Private _bnf_numib As String
   ''' <summary>
   ''' Número de Ingresos Brutos	A 20	
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property IngresosBrutos() As String
      Get
         If Me._bnf_numib.Length > 20 Then
            Return Me._bnf_numib.Substring(0, 20)
         Else
            Return _bnf_numib
         End If
      End Get
      Set(ByVal value As String)
         _bnf_numib = value
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
         'Condición de Ingresos Brutos	N 2	obligatorio
         .Append(Me.IdCondicionIngresosBrutos.ToString("00"))
         .Append(Chr(9))
         'Condición de Ganancias	N 2	obligatorio
         .Append(Me.IdCondicionGanancias.ToString("00"))
         .Append(Chr(9))
         ' Condición de I.V.A.	N 2	obligatorio
         .Append(Me.IdCategoriaFiscal.ToString("00"))
         .Append(Chr(9))
         'Razón social del beneficiario	A 40	
         .Append(Me.NombreCliente.PadRight(40))
         .Append(Chr(9))
         'Calle	A 60	
         .Append(Me.Calle)
         .Append(Chr(9))
         'Número de puerta	N 8	obligatorio
         .Append(Me.NumeroPuerta.ToString())
         .Append(Chr(9))
         'Unidad funcional / Piso, Departamento, etc.	A 20	
         .Append(Me.PisoDpto)
         .Append(Chr(9))
         'Código Postal	N 6	obligatorio
         .Append(Me.IdLocalidad.ToString("000000"))
         .Append(Chr(9))
         'Número de Ingresos Brutos	A 20	
         .Append(Me.IngresosBrutos)
         .Append(Chr(9))
      End With
      Return Me._stb.ToString()
   End Function

#End Region

End Class