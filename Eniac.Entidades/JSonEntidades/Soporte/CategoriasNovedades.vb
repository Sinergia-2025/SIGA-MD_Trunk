Namespace JSonEntidades.Soporte
   Public Class CategoriasNovedades
      Inherits JSonEntidad
      Public Sub New(idEmpresa As Integer)
         MyBase.New(idEmpresa)
      End Sub
      Public Sub New(idEmpresa As Integer,
                     categoria As CRMCategoriaNovedad)
         Me.New(idEmpresa)
         Me.IdCategoriaNovedad = categoria.IdCategoriaNovedad
         Me.IdTipoNovedad = categoria.IdTipoNovedad
         Me.NombreCategoriaNovedad = categoria.NombreCategoriaNovedad
         Me.Posicion = categoria.Posicion
         Me.PorDefecto = categoria.PorDefecto
         Me.Reporta = categoria.Reporta
         Me.Color = categoria.Color
         Me.PublicarEnWeb = categoria.PublicarEnWeb
      End Sub

      Public Property IdTipoNovedad As String
      Public Property IdCategoriaNovedad As Integer
      Public Property NombreCategoriaNovedad As String
      Public Property Posicion As Integer
      Public Property PorDefecto As Boolean
      Public Property Reporta As String
      Public Property Color As Integer?
      Public Property PublicarEnWeb As Boolean

   End Class
End Namespace