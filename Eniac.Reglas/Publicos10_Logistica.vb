Partial Class Publicos
   Public Class Logistica
      Public Shared ReadOnly Property RutaArchivosPalm() As String
         Get
            Return New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.RUTAARCHIVOSPALM.ToString(), System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop))
         End Get
      End Property

      Public Shared ReadOnly Property LogisticaFormatoExportacionDefault As String
         Get
            Return New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.LOGISTICAFORMATOEXPORTACIONDEFAULT.ToString(), Entidades.GenerarArchivo.FormatosExportacion.Sync.ToString())
         End Get
      End Property

      Public Shared ReadOnly Property LogisticaFormatoExportacionDefaultEnum As Entidades.GenerarArchivo.FormatosExportacion
         Get
            Dim dv As String = LogisticaFormatoExportacionDefault
            Dim val As Entidades.GenerarArchivo.FormatosExportacion
            Try
               val = DirectCast([Enum].Parse(GetType(Entidades.GenerarArchivo.FormatosExportacion), dv), Entidades.GenerarArchivo.FormatosExportacion)
            Catch ex As Exception
               val = Entidades.GenerarArchivo.FormatosExportacion.Sync
            End Try
            Return val
         End Get
      End Property

      Public Shared ReadOnly Property ExportarPreciosConIVA() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.EXPORTARPRECIOSCONIVA1, True)
         End Get
      End Property

      Public Shared ReadOnly Property IncluirEsCambiableEsBonificable() As Boolean
         Get
            Return Boolean.Parse(New Eniac.Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.INCLUIRESCAMBIABLEESBONIFICABLE.ToString(), Boolean.FalseString))
         End Get
      End Property

      Public Shared ReadOnly Property ConsolidadoCargaOrdenIdProducto() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.CONSOLIDADOCARGAORDENIDPRODUCTO, False)
         End Get
      End Property

      Public Shared ReadOnly Property NormalizaClientesEnRutas() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.LOGISTICANORMALIZACLIENTESENRUTAS, False)
         End Get
      End Property


   End Class
End Class