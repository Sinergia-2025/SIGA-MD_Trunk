Namespace Ayudante.Cache.Turismo
   Public Class CacheTurismoCursos
      Inherits BusquedaCacheadaCommon(Of Entidades.TurismoCurso)

#Region "Singleton"
      Private Shared _instancia As CacheTurismoCursos = New CacheTurismoCursos()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As CacheTurismoCursos
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New TurismoCursos().GetTodos())
      End Sub

      Public Overloads Function Buscar(idCurso As Integer) As Entidades.TurismoCurso
         Return MyBase.Buscar(Function(x) x.IdCurso = idCurso)
      End Function
      Public Function Existe(idCurso As Integer) As Boolean
         Return Buscar(idCurso) IsNot Nothing
      End Function

   End Class
End Namespace