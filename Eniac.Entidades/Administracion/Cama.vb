Public Class Cama
   Inherits Entidad

   Public Enum Columnas
      IdCama
      CodigoCama
      IdNave
      Lado
      Fila
      Columna
      Posicion
      m3
      Estado
      IdCategoriaCama
      Coeficiente
      FechaPosesion
      SeUtilizaEnCargos
      ImporteAlquiler
      PeriodoDesdeImpAlquiler
      PeriodoHastaImpAlquiler
      IdGrupoCama
   End Enum

   Public Class Estados
      Public Const Alta As String = "ALTA"
      Public Const Ocupado As String = "OCUPADO"
   End Class

End Class

