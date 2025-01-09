Namespace SistemaE
   Public Class AlertaSistemaCondicion
      Inherits Entidad

      Public Const NombreTabla As String = "AlertasSistemaCondiciones"
      Public Enum Columnas
         IdAlertaSistema
         OrdenCondicion
         CondicionCount
         ValorCondicionCount
         MensajeCount
         ColorCondicionCount
         OrdenPrioridad
         MostrarPopUp
         ParametrosAdicionalesPantalla


      End Enum

      Public Property IdAlertaSistema As Integer
      Public Property OrdenCondicion As Integer
      Public Property CondicionCount As CondicionesCountAlerta
      Public Property ValorCondicionCount As Integer
      Public Property MensajeCount As String
      Public Property ColorCondicionCount As Drawing.Color
      Public Property OrdenPrioridad As Integer
      Public Property MostrarPopUp As Boolean
      Public Property ParametrosAdicionalesPantalla As String

   End Class

   Public Enum CondicionesCountAlerta
      Menor
      <Description("Menor o Igual")> MenorIgual
      Igual
      <Description("Mayor o Igual")> MayorIgual
      Mayor
      Diferente
   End Enum

End Namespace