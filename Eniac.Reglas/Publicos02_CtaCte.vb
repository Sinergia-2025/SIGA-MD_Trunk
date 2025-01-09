Partial Class Publicos
   Public Class CtaCte

      Public Shared ReadOnly Property CtaCteClientesSeparar() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CTACTECLIENTESSEPARAR, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property CtaCteClientesPermitirComprobantesEmisionPosterior() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CTACTECLIENTESEMISIONPOSTERIOR, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property CtaCtePermitirModificarComprobanteAsociado As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CTACTEPERMITIRMODIFICARCOMPROBANTEASOCIADO, Boolean.FalseString))
         End Get
      End Property

      '-- REQ-43822.- ------------------------------------------------------------------------------------------------------------------------------------------------
      Public Shared ReadOnly Property CobranzaElectronicaHabilitaRoela As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CTACTECOBRANZAELECTRONICAHABILITAROELA, Boolean.FalseString))
         End Get
      End Property
      Public Shared ReadOnly Property CobranzaElectronicaHabilitaSirPlus As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CTACTECOBRANZAELECTRONICAHABILITASIRPLUS, Boolean.FalseString))
         End Get
      End Property
      Public Shared ReadOnly Property CobranzaElectronicaHabilitaDebitoAutomatico As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CTACTECOBRANZAELECTRONICAHABILITADEBITOAUTOMATICO, Boolean.FalseString))
         End Get
      End Property



      '---------------------------------------------------------------------------------------------------------------------------------------------------------------



      Public Shared ReadOnly Property CtaCteClientesPriorizarNCsyAnticipos() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CTACTECLIENTESPRIORIZARNCSYANTICIPOS, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property CtaCteClientesCalcularPromedios() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CtaCteClientesCalcularPromedios, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property SaldoLimiteDeCreditoContemplaPedidos() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.CTACTESALDOLIMITEDECREDITOCONTEMPLAPEDIDOS, True)
         End Get
      End Property
      Public Shared ReadOnly Property SaldoLimiteDeCreditoContemplaAnticipos() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.CTACTESALDOLIMITEDECREDITOCONTEMPLAANTICIPOS, True)
         End Get
      End Property
      Public Shared ReadOnly Property SaldoLimiteDeCreditoDiasSumarFechaCobro() As Integer
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.CTACTESALDOLIMITEDECREDITODIASSUMARFECHACOBRO, -15I)
         End Get
      End Property
      Public Shared ReadOnly Property CantidadDeDiasPremioCobro() As Integer
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.CTACTECANTIDADDIASPREMIOCOBRO, 0I)
         End Get
      End Property


      Public Shared ReadOnly Property InteresesAdicionalProporcionalDiario() As Decimal
         Get
            Return Decimal.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.INTERESESADICIONALPROPORCIONALDIARIO, "0"))
         End Get
      End Property

      Public Shared ReadOnly Property InteresesCalculoCompletoPrimerPago() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.INTERESESCALCULOCOMPLETOPRIMERPAGO, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property InteresesMontoAplicadoIncluyeIntereses() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.INTERESESMONTOAPLICADOINCLUYEINTERESES, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property PermiteModificarImporteInteresesRecibo() As Boolean
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.RECIBOPERMITEMODIFICARIMPORTEINTERESES.ToString(), Boolean.FalseString) = Boolean.TrueString
         End Get
      End Property

      Public Shared ReadOnly Property ReciboConciliaAutomaticamenteTransferencias() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.RECIBOCONCILIAAUTOMATICAMENTETRANSFERENCIAS, Boolean.FalseString))
         End Get
      End Property
      Public Shared ReadOnly Property RecibosEnviaMailCliente() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.ENVIAMAILCLIENTERECIBO, False)
         End Get
      End Property

      Public Shared ReadOnly Property ReciboIgnorarPCdeCaja() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.RECIBOIGNORARPCDECAJA, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property ReciboSolicitaFecha() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.RECIBOSOLICITAFECHA, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property ReciboUtilizaDescuentoRecargo() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.RECIBOUTILIZADESCUENTORECARGO, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property ReciboMuestraSaldoImpresion() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.RECIBOMUESTRASALDOCTACTEIMPRESION, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property RecibosMantieneNumeracionModificada() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.RECIBOMANTIENENUMMODIFICADA, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property ReciboAplicaSaldoEnPesos() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.RECIBOAPLICASALDOENPESOS, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property ReciboComparteNumeracionEntreSucursales() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.RECIBOCOMPARTENUMERACIONENTRESUCURSALES, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property ReciboCalculoInteresFuturos() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.RECIBOCALCULOINTERESESFUTURO, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property VisualizaReciboDeCliente() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.VISUALIZARECIBO, Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property ValidaEmisorElectronicoEnRecibos() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.VALIDAEMISORELECTRONICOENRECIBOS.ToString(), Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property PermiteReciboSinAplicarComprobantes() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PERMITERECIBOSINAPLICARCOMPROBANTES, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property ContemplaCategoriaClienteRecibo() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CTACTECATEGORIACLIENTESRECIBO, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property IDProductoDescuentoRecargo() As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.IDPRODUCTODESCUENTORECARGO, "11")
         End Get
      End Property

      Public Shared ReadOnly Property CategoriaClientePredeterminada() As String
         Get
            Return New Parametros().GetValorPD(Entidades.Parametro.Parametros.CTACTECATEGORIACLIENTE, "ACTUAL")
         End Get
      End Property

      Public Shared ReadOnly Property UtilizaCuotasVencimientoCtaCteClientes() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD("UTILIZACUOTASOVENCIMIENTOCCCLIENTES", Boolean.TrueString))
         End Get
      End Property

      Public Shared ReadOnly Property MontoMinimoInteresPermitido() As Decimal
         Get
            Return Decimal.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.RECIBOMONTOMINIMOINTERESPERMITO, "0"))
         End Get
      End Property

      Public Shared ReadOnly Property PintaColumaCuotaCtaCteCliente() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CTACTECLIENTEPINTACUOTA, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property FacturacionAsuntoEnvioMasivoEmailCtaCte As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTURACIONASUNTOENVIOMASIVOEMAILCTACTE.ToString(), "{0} - Comprobantes vencidos")
         End Get
      End Property

      Public Shared ReadOnly Property CantidadDiasVencimientoMail() As Integer
         Get
            Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CTACTECANTDIASVENCICOMPMAIL.ToString(), "0"))
         End Get
      End Property

      Public Shared ReadOnly Property CantidadDiasDHRecibos() As Integer
         Get
            Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.CTACTECANTDIASDHRECIBOS.ToString(), "0"))
         End Get
      End Property

      Public Shared ReadOnly Property MacroFormatoAlineacionAdherente As String
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.MACROADHERENTEALINEACION, "Derecha a Izquierda")
         End Get
      End Property
      Public Shared ReadOnly Property MacroCaracterRelleanoAdherente() As String
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.MACROADHERENTERELLENADO, "0")
         End Get
      End Property
      Public Shared ReadOnly Property DebitoAutomaticoSantanderCodigoServicio() As String
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.DEBITOAUTOMATICOSANTANDERCODIGOSERVICIO, String.Empty)
         End Get
      End Property
      Public Shared ReadOnly Property DebitoAutomaticoCuentaBancariaTransfBanc() As Integer
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.DEBITOAUTOMATICOCUENTABANCARIATRANSBANC, 0I)
         End Get
      End Property
      Public Shared ReadOnly Property DebitoAutomaticoCajaCtaBancariaTransfBanc() As Integer
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.DEBITOAUTOMATICOCAJACUENTABANCARIATRANSBANC, 0I)
         End Get
      End Property
      Public Shared ReadOnly Property DebitoAutomaticoTipoReciboCtaBancariaTransf() As String
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.DEBITOAUTOMATICOTIPORECIBOCTABANCARIATRANF, String.Empty)
         End Get
      End Property
      Public Shared ReadOnly Property DebitoAutomaticoCobradorCtaBancariaTransf() As Integer
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.DEBITOAUTOMATICOCOBRADORCTABANCARIATRANF, 0I)
         End Get
      End Property
      Public Shared ReadOnly Property NumeroEmpresaBanelco() As Integer
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.NROEMPRESABANELCO, 0I)
         End Get
      End Property
      Public Shared ReadOnly Property PMCFormato() As Entidades.CuentaCorriente.FormatoPMC
         Get
            Dim str As String = New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.PMCFORMATO.ToString(), Entidades.CuentaCorriente.FormatoPMC.PMC.ToString())
            Dim result As Entidades.CuentaCorriente.FormatoPMC
            If [Enum].TryParse(str, result) Then
               Return result
            End If
            Return Entidades.CuentaCorriente.FormatoPMC.PMC
         End Get
      End Property

   End Class
End Class