Imports System.ComponentModel

Public Class Grupo
   Inherits Eniac.Entidades.Entidad

   ' ESTA ENTIDAD NO EXISTE EN BASE DE DATOS. SE UTILIZA PARA LA SELECCION MULTIPLE DE GRUPOS Y SE CARGA CON UN DISTINCT DE TIPOS DE COMPROBANTES

   Public Enum Columnas
      IdGrupo
      NombreGrupo
   End Enum
   Public Enum ValoresFijosGrupos As Integer
      <Description("(Selección Multiple)")> SeleccionMultiple = -1
      <Description("(Todos)")> Todos = -2
   End Enum

   Public Property IdGrupo As String
   Public Property NombreGrupo As String
End Class
