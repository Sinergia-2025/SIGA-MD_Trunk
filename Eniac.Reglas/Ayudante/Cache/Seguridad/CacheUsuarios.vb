Option Strict On
Option Explicit On
Namespace Ayudante.Cache.Seguridad
   Public Class CacheUsuarios
      Inherits BusquedaCacheadaCommon(Of Entidades.Usuario)

#Region "Singleton"
      Private Shared _instancia As CacheUsuarios = New CacheUsuarios()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As CacheUsuarios
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New Eniac.Reglas.Usuarios().GetTodos(toLowerId:=True))
      End Sub

      Public Overloads Function Buscar(idUsuario As String) As Entidades.Usuario
         idUsuario = If(String.IsNullOrWhiteSpace(idUsuario), String.Empty, idUsuario.ToLower())
         Return MyBase.Buscar(Function(x) x.Id = idUsuario)
      End Function
      Public Function Existe(idUsuario As String) As Boolean
         Return Buscar(idUsuario) IsNot Nothing
      End Function

   End Class
End Namespace