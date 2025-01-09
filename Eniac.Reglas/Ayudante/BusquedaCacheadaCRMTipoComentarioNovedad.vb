Option Strict On
Option Explicit On
Namespace Ayudante
   Public Class BusquedaCacheadaCRMTipoComentarioNovedad
      Inherits BusquedaCacheadaCommon(Of Entidades.CRMTipoComentarioNovedad)

#Region "Singleton"
      Private Shared _instancia As BusquedaCacheadaCRMTipoComentarioNovedad = New BusquedaCacheadaCRMTipoComentarioNovedad()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As BusquedaCacheadaCRMTipoComentarioNovedad
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New Eniac.Reglas.CRMTiposComentariosNovedades().GetTodos(idTipoNovedad:=String.Empty))
      End Sub

      Public Overloads Function Buscar(idTipoComentarioNovedad As Integer) As Entidades.CRMTipoComentarioNovedad
         Return MyBase.Buscar(Function(x) x.IdTipoComentarioNovedad = idTipoComentarioNovedad)
      End Function
      Public Function Existe(idTipoComentarioNovedad As Integer) As Boolean
         Return Buscar(idTipoComentarioNovedad) IsNot Nothing
      End Function

   End Class
End Namespace