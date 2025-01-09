Namespace Ayudante.Cache.Turnos
   Public Class CacheTiposTurnos
      Inherits BusquedaCacheadaCommon(Of Entidades.TipoTurno)

#Region "Singleton"
      Private Shared _instancia As CacheTiposTurnos = New CacheTiposTurnos()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As CacheTiposTurnos
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New Eniac.Reglas.TiposTurnos().GetTodos(idTipoCalendario:=0))
      End Sub

      Public Overloads Function Buscar(id As String) As Entidades.TipoTurno
         Return MyBase.Buscar(Function(x) x.IdTipoTurno = id)
      End Function
      Public Function Existe(id As String) As Boolean
         Return Buscar(id) IsNot Nothing
      End Function
      Public Function BuscarPorTipoCalendario(id As Short) As IEnumerable(Of Entidades.TipoTurno)
         Return GetTodos().Where(Function(x) x.IdTipoCalendario = id).ToArray()
      End Function

   End Class
End Namespace