Imports System.Windows.Forms

Public Class BuscadorCampo
   Inherits Entidad
   Public Const NombreTabla As String = "BuscadoresCampos"
   Public Enum Columnas
      IdBuscador
      IdBuscadorNombreCampo
      Orden
      Titulo
      Alineacion
      Ancho
      Formato
      Condicion
      Valor
      ColorFila
   End Enum

   Public Property IdBuscador As Integer
   Public Property IdBuscadorNombreCampo As String
   Public Property Orden As Integer
   Public Property Titulo As String
   Public Property Alineacion As DataGridViewContentAlignment
   Public Property Ancho As Integer
   Public Property Formato As String
   Public Property Condicion As TipoCondicion
   Public Property ValorCondicion As String
   Public Property ColorFilaCondicion As String

   Public Enum TipoCondicion
      Igual
      Menor
      Mayor
      Como
   End Enum


End Class