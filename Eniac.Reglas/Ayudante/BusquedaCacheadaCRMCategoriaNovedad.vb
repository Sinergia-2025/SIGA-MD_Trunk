Namespace Ayudante
   Public Class BusquedaCacheadaCRMCategoriaNovedad
      Inherits BusquedaCacheadaCommonCRM(Of Entidades.CRMCategoriaNovedad)

#Region "Singleton"
      Private Shared _instancia As BusquedaCacheadaCRMCategoriaNovedad = New BusquedaCacheadaCRMCategoriaNovedad()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As BusquedaCacheadaCRMCategoriaNovedad
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New CRMCategoriasNovedades().GetTodos(idTipoNovedad:=String.Empty))
      End Sub

      Public Overloads Function Buscar(idCategoriaNovedad As Integer) As Entidades.CRMCategoriaNovedad
         Return Buscar(Function(x) x.IdCategoriaNovedad = idCategoriaNovedad)
      End Function
      Public Function Existe(idCategoriaNovedad As Integer) As Boolean
         Return Buscar(idCategoriaNovedad) IsNot Nothing
      End Function

      Public Function BuscarDefault(idTipoNovedad As String) As Entidades.CRMCategoriaNovedad
         Return Buscar(Function(x) x.IdTipoNovedad = idTipoNovedad And x.PorDefecto)
      End Function
      Public Function BuscarDefaultOrFirst(idTipoNovedad As String) As Entidades.CRMCategoriaNovedad
         Dim r = BuscarDefault(idTipoNovedad)
         Return If(r Is Nothing, GetTodos(idTipoNovedad)(0), r)
      End Function

   End Class
End Namespace