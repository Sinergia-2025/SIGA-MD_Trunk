Imports System.ComponentModel
Public Class Bitacora
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdBitacora
      FechaBitacora
      IdFuncion
      Nombre
      IdUsuario
      NombrePC
      Tipo
      Descripcion
   End Enum

   Public Enum TipoBitacora As Integer
      <Description("Acceder a Pantalla")> IniciarPantalla = 0
      <Description("Error")> SucedioError = 1
      <Description("Actualizacion de Datos")> Actualizacion = 2
      <Description("Borrado de registro")> Borrado = 3
      <Description("Alta de registro")> NuevoRegistro = 4
      <Description("Inicio de Proceso")> InicioProceso = 5
      <Description("Fin de Proceso")> FinProceso = 6
   End Enum

#Region "Propiedades"

   Public Property IdBitacora As Integer
   Public Property FechaBitacora As Date
   Public Property IdFuncion As String
   Public Property IdUsuario As String
   Public Property NombrePC As String
   Public Property Tipo As String
   Public Property Descripcion As String

#End Region

End Class