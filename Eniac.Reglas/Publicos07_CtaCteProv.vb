Partial Class Publicos
   Public Class CtaCteProv
      Public Shared ReadOnly Property RetencionesGananciasCalculoRecursivo() As Boolean
         Get
            Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.RETENCIONESGANANCIASCALCULORECURSIVO, Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property RetencionesGananciasCalculoRecursivoCantidadRepeticiones() As Integer
         Get
            Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.RETENCIONESGANANCIASCALCULORECURSIVOREPETIR, "5"))
         End Get
      End Property

      Public Shared ReadOnly Property PagoSolicitaFecha() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PAGOSOLICITAFECHA, True)
         End Get
      End Property

      Public Shared ReadOnly Property VisualizaPagoAProveedor() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.VISUALIZAPAGOAPROVEEDOR, True)
         End Get
      End Property

      Public Shared ReadOnly Property RealizaNCNDAutomaticaDescRec() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.CTACTEPROVREALIZANCNDDESCREC, False)
         End Get
      End Property
      Public Shared ReadOnly Property ImputacionAutomaticaDRFormaPago() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.CTACTEPROVIMPUTACIONAUTOMATICADRFORMAPAGO, False)
         End Get
      End Property

      Public Shared ReadOnly Property PermitePagoSinAplicarComprobantes() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PERMITEPAGOSINAPLICARCOMPROBANTES, False)
         End Get
      End Property
      Public Shared ReadOnly Property UtilizaCuotasVencimientoCtaCteProveedores() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.UTILIZACUOTASOVENCIMIENTOCCPROVEEDORES, True)
         End Get
      End Property
      Public Shared ReadOnly Property PagoIgnorarPCdeCaja() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PAGOIGNORARPCDECAJA, False)
         End Get
      End Property
      Public Shared ReadOnly Property PagoImprimeSaldo() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PAGOIMPRIMESALDO, True)
         End Get
      End Property
      Public Shared ReadOnly Property PagoImprimeTotalImporte() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PAGOIMPRIMETOTALIMPORTE, True)
         End Get
      End Property
      Public Shared ReadOnly Property PagoImprimeTotalSaldo() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PAGOIMPRIMETOTALSALDO, True)
         End Get
      End Property
      Public Shared ReadOnly Property PagoImprimeTotalDescRec() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PAGOIMPRIMETOTALDESCREC, True)
         End Get
      End Property
      Public Shared ReadOnly Property CtaCteProveedoresSeparar() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.CTACTEPROVEEDORESSEPARAR, True)
         End Get
      End Property
      Public Shared ReadOnly Property CtaCteProveedoresPermitirComprobantesEmisionPosterior() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.CtaCteProveedoresEmisionPosterior, False)
         End Get
      End Property
      Public Shared ReadOnly Property CtaCteProveedoresDHVistaContable() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.CTACTEPROVEEDORESDHVISTACONTABLE, False)
         End Get
      End Property
      Public Shared ReadOnly Property PagoProvConciliaAutomaticamenteTransferencias() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.PAGOPROVCONCILIAAUTOMATICAMENTETRANSFERENCIAS, False)
         End Get
      End Property
      Public Shared ReadOnly Property MostrarObservaciondeComprobantes() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.MOSTRAROBSERVACIONDECOMPROBANTES, False)
         End Get
      End Property
      Public Shared ReadOnly Property IDProductoDescuentoRecargo() As String
         Get
            Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.IDPRODUCTODESCUENTORECARGOPROV, String.Empty)
         End Get
      End Property

   End Class

End Class