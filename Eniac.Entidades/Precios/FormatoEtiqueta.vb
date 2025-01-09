Imports System.ComponentModel

Public Class FormatoEtiqueta
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "FormatosEtiquetas"
   Public Enum Columnas
      IdFormatoEtiqueta
      NombreFormatoEtiqueta
      Tipo
      ArchivoAImprimir
      ArchivoAImprimirEmbebido
      NombreImpresora
      ImprimeLote
      MaximoColumnas
      UtilizaCabecera
      SolicitaListaPrecios2
      Activo

   End Enum

   Public Enum Tipos
      <Description("Precios")> PRECIOS
      <Description("Codigos de Barra")> CODIGOBARRA
      <Description("Bultos")> BULTOS
   End Enum

   Public Property IdFormatoEtiqueta As Integer
   Public Property NombreFormatoEtiqueta As String
   Public Property Tipo As Tipos
   Public Property ArchivoAImprimir As String
   Public Property ArchivoAImprimirEmbebido As Boolean
   Public Property NombreImpresora As String
   Public Property ImprimeLote As Boolean
   Public Property MaximoColumnas As Integer
   Public Property UtilizaCabecera As Boolean
   Public Property SolicitaListaPrecios2 As Boolean
   Public Property Activo As Boolean

End Class