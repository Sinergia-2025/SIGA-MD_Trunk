Partial Class Publicos
   Public Class SiSeN
      Public Shared ReadOnly Property TipoTurnoParaRecepcion As String
         Get
            Return New Reglas.Parametros().GetValorPD("TIPOTURNOPARARECEPCION", "R")
         End Get
      End Property
      Public Shared ReadOnly Property TipoTurnoParaSalida As String
         Get
            Return New Reglas.Parametros().GetValorPD("TIPOTURNOPARASALIDA", "S,SD")
         End Get
      End Property

      Public Shared ReadOnly Property ReservaSaldoMinimoSemaforo() As Decimal
         Get
            Return Decimal.Parse(New Reglas.Parametros().GetValorPD("RESERVASALDOMINIMOSEMAFORO", "50"))
         End Get
      End Property

      Public Shared ReadOnly Property ReservaSemaforoAmarillo() As Integer
         Get
            Return Integer.Parse(New Reglas.Parametros().GetValorPD("RESERVASEMAFOROAMARILLO", "2"))
         End Get
      End Property

   End Class
End Class