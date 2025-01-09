Partial Class Publicos
   Public Class FacturaElectronica
      Public Shared ReadOnly Property URLWSAA() As String
         Get
            Return Parametros.GetValorPD(Of String)(Entidades.Parametro.Parametros.URLWSAA, String.Empty)
         End Get
      End Property
      Public Shared ReadOnly Property ClaveTicketAccesoFE() As String
         Get
            Return Parametros.GetValorPD(Of String)(Entidades.Parametro.Parametros.CLAVETICKETACCESOFE, String.Empty)
         End Get
      End Property
      Public Shared ReadOnly Property URLWSFE() As String
         Get
            Return Parametros.GetValorPD(Of String)(Entidades.Parametro.Parametros.URLWSFE, String.Empty)
         End Get
      End Property
      Public Shared ReadOnly Property URLWSFEX() As String
         Get
            Return Parametros.GetValorPD(Of String)(Entidades.Parametro.Parametros.URLWSFEX, String.Empty)
         End Get
      End Property
      Public Shared ReadOnly Property URLWSBFE() As String
         Get
            Return Parametros.GetValorPD(Of String)(Entidades.Parametro.Parametros.URLWSBFE, String.Empty)
         End Get
      End Property
      Public Shared ReadOnly Property URLWSPN4() As String
         Get
            Return Parametros.GetValorPD(Of String)(Entidades.Parametro.Parametros.URLWSPN4, String.Empty)
         End Get
      End Property

      '

      Public Shared ReadOnly Property FactElectSource() As String
         Get
            Return Parametros.GetValorPD(Of String)(Entidades.Parametro.Parametros.FACTELECTSOURCE, String.Empty)
         End Get
      End Property

      Public Shared ReadOnly Property FactElectDestination() As String
         Get
            Return Parametros.GetValorPD(Of String)(Entidades.Parametro.Parametros.FACTELECTDESTINATION, String.Empty)
         End Get
      End Property

      Public Shared ReadOnly Property FactElecUniqueID() As Integer
         Get
            Return Parametros.GetValorPD(Entidades.Parametro.Parametros.FACTELECUNIQUEID, 1I)
         End Get
      End Property

      Public Shared ReadOnly Property FactElectGenerationTime() As Date
         Get
            Return Date.Parse(New Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTELECTGENERATIONTIME, Date.Now.ToString("dd/MM/yyy HH:mm:ss")))
         End Get
      End Property

      Public Shared ReadOnly Property FactElectExpirationTime() As Date
         Get
            Return Date.Parse(New Parametros().GetValorPD(Entidades.Parametro.Parametros.FACTELECTEXPIRATIONTIME, Date.Now.ToString("dd/MM/yyy HH:mm:ss")))
         End Get
      End Property

      Public Shared ReadOnly Property FactElecService() As String
         Get
            Return Parametros.GetValorPD(Of String)(Entidades.Parametro.Parametros.FACTELECSERVICE, String.Empty)
         End Get
      End Property

      Public Shared ReadOnly Property FactElecGuardarLog() As Boolean
         Get
            Return Parametros.GetValorPD(Entidades.Parametro.Parametros.FACTELECGUARDARLOG, False)
         End Get
      End Property

      Public Shared ReadOnly Property FactElecGuardarLogPath() As String
         Get
            Return Parametros.GetValorPD(Of String)(Entidades.Parametro.Parametros.FACTELECGUARDARLOGPATH, "c:\Eniac\SiGA\LOGs\FacturaElectronica\")
         End Get
      End Property

   End Class
End Class