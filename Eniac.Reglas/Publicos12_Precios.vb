Partial Class Publicos
   Public Class ConsultaPreciosCliente
      Public Shared ReadOnly Property Moneda() As Integer
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.CONSULTAPRECIOSCLIENTEMONEDA, -1I)
         End Get
      End Property
      Public Shared ReadOnly Property UsaPredeterminado() As Boolean
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.CONSULTAPRECIOSCLIENTEUSAPREDETERMINADO, False)
         End Get
      End Property
      Public Shared ReadOnly Property CodigoCliente() As Long
         Get
            Return ParametrosCache.Instancia.GetValorPD(Entidades.Parametro.Parametros.CONSULTAPRECIOSCLIENTEUSACODIGOCLIENTE, 0L)
         End Get
      End Property

   End Class
End Class
