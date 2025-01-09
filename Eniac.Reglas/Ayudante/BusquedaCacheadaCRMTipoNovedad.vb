Option Strict On
Option Explicit On
Namespace Ayudante
   Public Class BusquedaCacheadaCRMTipoNovedad
      Inherits BusquedaCacheadaCommon(Of Entidades.CRMTipoNovedad)

#Region "Singleton"
      Private Shared _instancia As BusquedaCacheadaCRMTipoNovedad = New BusquedaCacheadaCRMTipoNovedad()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As BusquedaCacheadaCRMTipoNovedad
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New Eniac.Reglas.CRMTiposNovedades().GetTodos(idTipoNovedad:=String.Empty))
      End Sub

      Public Overloads Function Buscar(idTipoNovedad As String) As Entidades.CRMTipoNovedad
         Return MyBase.Buscar(Function(x) x.IdTipoNovedad = idTipoNovedad)
      End Function
      Public Function Existe(idTipoNovedad As String) As Boolean
         Return Buscar(idTipoNovedad) IsNot Nothing
      End Function

   End Class
End Namespace