<Serializable()>
Public Class Impresora
   Inherits Entidad
   Public Const NombreTabla As String = "Impresoras"

   Public Enum Columnas
      IdSucursal
      IdImpresora
      TipoImpresora
      CentroEmisor
      ComprobantesHabilitados
      Puerto
      Velocidad
      EsProtocoloExtendido
      Modelo
      OrigenPapel
      CantidadCopias
      TipoFormulario
      TamanioLetra
      Marca
      Metodo
      AbrirCajonDinero
      GrabarLOGs
      ImprimirLineaALinea
      CierreFiscalEstandar
      PorCtaOrden
      DireccionCentroEmisor
      IdLocalidadCentroEmisor
      MaximoCaracteresItem

      FiscalUltimaFechaExtraidaAuditoria
      FiscalUltimoZetaExtraidoAuditoria
      FiscalUltimaFechaExtraidaInforme
      UtilizaBonosFiscalesElectronicos

   End Enum

   Public Enum MetodosFiscal
      <Description("Batch")> BATCH
      <Description("DLL")> DLLs
      <Description("DLL v2")> DLLsV2
   End Enum

#Region "Propiedades"

   Public Property EsProtocoloExtendido As Boolean
   Public Property Velocidad As Integer
   Public Property Puerto As String
   Public Property MaximoCaracteresItem As Integer
   Public Property TipoImpresora As String
   Public Property CentroEmisor As Short
   Public Property IdImpresora As String
   Public Property ComprobantesHabilitados As String
   Public Property Modelo As String
   Public Property OrigenPapel As String
   Public Property CantidadCopias As Short
   Public Property TipoFormulario As String
   Public Property TamanioLetra As Short
   Public Property Marca As String
   Public Property Metodo As MetodosFiscal?
   Public Property AbrirCajonDinero As Boolean
   Public Property GrabarLOGs As Boolean
   Public Property ImprimirLineaALinea As Boolean
   Public Property CierreFiscalEstandar As Boolean
   Public Property PorCtaOrden As Boolean
   Public Property DireccionCentroEmisor As String

   Public Property FiscalUltimaFechaExtraidaAuditoria As Date?
   Public Property FiscalUltimoZetaExtraidoAuditoria As Integer?
   Public Property FiscalUltimaFechaExtraidaInforme As Date?

   Public Property UtilizaBonosFiscalesElectronicos As Boolean

   Public Property PCs As String()

   Private _localidadCentroEmisor As Localidad
   Public Property LocalidadCentroEmisor As Localidad
      Get
         If _localidadCentroEmisor Is Nothing Then
            _localidadCentroEmisor = New Localidad()
         End If
         Return _localidadCentroEmisor
      End Get
      Set(value As Localidad)
         _localidadCentroEmisor = value
      End Set
   End Property

#End Region

End Class