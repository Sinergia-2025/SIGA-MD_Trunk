Namespace Ayudante
   Public Class BusquedaCacheadaCRMEstadoNovedad
      Inherits BusquedaCacheadaCommonCRM(Of Entidades.CRMEstadoNovedad)

#Region "Singleton"
      Private Shared _instancia As BusquedaCacheadaCRMEstadoNovedad = New BusquedaCacheadaCRMEstadoNovedad()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As BusquedaCacheadaCRMEstadoNovedad
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New CRMEstadosNovedades().GetTodos(idTipoNovedad:=String.Empty))
      End Sub

      Public Overloads Function Buscar(IdEstadoNovedad As Integer?) As Entidades.CRMEstadoNovedad
         If IdEstadoNovedad.HasValue Then
            Return Buscar(Function(x) x.IdEstadoNovedad = IdEstadoNovedad.Value)
         Else
            Return Nothing
         End If
      End Function
      Public Overloads Function Buscar(IdEstadoNovedad As Integer) As Entidades.CRMEstadoNovedad
         Return Buscar(Function(x) x.IdEstadoNovedad = IdEstadoNovedad)
      End Function
      Public Function Existe(IdEstadoNovedad As Integer) As Boolean
         Return Buscar(IdEstadoNovedad) IsNot Nothing
      End Function

      Public Overloads Function BuscarDefault(idTipoNovedad As String) As Entidades.CRMEstadoNovedad
         Return Buscar(Function(x) x.IdTipoNovedad = idTipoNovedad And x.PorDefecto)
      End Function
      Public Function BuscarDefaultOrFirst(idTipoNovedad As String) As Entidades.CRMEstadoNovedad
         Dim r = BuscarDefault(idTipoNovedad)
         Return If(r Is Nothing, GetTodos(idTipoNovedad)(0), r)
      End Function

   End Class
End Namespace