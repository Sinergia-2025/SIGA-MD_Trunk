Namespace Ayudante
   Public Class BusquedaCacheadaCRMPrioridadNovedad
      Inherits BusquedaCacheadaCommonCRM(Of Entidades.CRMPrioridadNovedad)

#Region "Singleton"
      Private Shared _instancia As BusquedaCacheadaCRMPrioridadNovedad = New BusquedaCacheadaCRMPrioridadNovedad()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As BusquedaCacheadaCRMPrioridadNovedad
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New CRMPrioridadesNovedades().GetTodos(idTipoNovedad:=String.Empty))
      End Sub

      Public Overloads Function Buscar(idPrioridadNovedad As Integer) As Entidades.CRMPrioridadNovedad
         Return Buscar(Function(x) x.IdPrioridadNovedad = idPrioridadNovedad)
      End Function
      Public Function Existe(idPrioridadNovedad As Integer) As Boolean
         Return Buscar(idPrioridadNovedad) IsNot Nothing
      End Function

      Public Function BuscarDefault(idTipoNovedad As String) As Entidades.CRMPrioridadNovedad
         Return Buscar(Function(x) x.IdTipoNovedad = idTipoNovedad And x.PorDefecto)
      End Function
      Public Function BuscarDefaultOrFirst(idTipoNovedad As String) As Entidades.CRMPrioridadNovedad
         Dim r = BuscarDefault(idTipoNovedad)
         Return If(r Is Nothing, GetTodos(idTipoNovedad)(0), r)
      End Function

   End Class
End Namespace