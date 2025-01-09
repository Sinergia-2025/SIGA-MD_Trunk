Namespace Ayudante
   Public Class BusquedaCacheadaMetodoResolucionNovedad
      Inherits BusquedaCacheadaCommonCRM(Of Entidades.CRMMetodoResolucionNovedad)

#Region "Singleton"
      Private Shared _instancia As BusquedaCacheadaMetodoResolucionNovedad = New BusquedaCacheadaMetodoResolucionNovedad()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As BusquedaCacheadaMetodoResolucionNovedad
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New CRMMetodosResolucionesNovedades().GetTodos(idTipoNovedad:=String.Empty))
      End Sub

      Public Overloads Function Buscar(idMetodoResolucionNovedad As Integer) As Entidades.CRMMetodoResolucionNovedad
         Return Buscar(Function(x) x.IdMetodoResolucionNovedad = idMetodoResolucionNovedad)
      End Function
      Public Function Existe(idPrioridadNovedad As Integer) As Boolean
         Return Buscar(idPrioridadNovedad) IsNot Nothing
      End Function

      Public Function BuscarDefault(idTipoPrioridad As String) As Entidades.CRMMetodoResolucionNovedad
         Return Buscar(Function(x) x.IdTipoNovedad = idTipoPrioridad And x.PorDefecto)
      End Function
      Public Function BuscarDefaultOrFirst(idTipoNovedad As String) As Entidades.CRMMetodoResolucionNovedad
         Dim r = BuscarDefault(idTipoNovedad)
         Return If(r Is Nothing, GetTodos(idTipoNovedad)(0), r)
      End Function

   End Class
End Namespace