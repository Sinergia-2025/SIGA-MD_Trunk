Namespace Ayudante.Cache.Turnos
   Public Class CacheTurnosEstados
      Inherits BusquedaCacheadaCommon(Of Entidades.EstadoTurno)

#Region "Singleton"
      Private Shared _instancia As CacheTurnosEstados = New CacheTurnosEstados()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As CacheTurnosEstados
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New Eniac.Reglas.EstadosTurnos().GetTodos())
      End Sub

      Public Overloads Function Buscar(idTurno As String) As Entidades.EstadoTurno
         Return MyBase.Buscar(Function(x) x.IdEstadoTurno = idTurno)
      End Function
      Public Function Existe(idTurno As String) As Boolean
         Return Buscar(idTurno) IsNot Nothing
      End Function

   End Class
End Namespace