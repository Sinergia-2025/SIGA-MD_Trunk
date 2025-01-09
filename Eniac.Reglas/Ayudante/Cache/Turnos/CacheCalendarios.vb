Namespace Ayudante.Cache.Turnos
   Public Class CacheCalendarios
      Inherits BusquedaCacheadaCommon(Of Entidades.Calendario)

#Region "Singleton"
      Private Shared _instancia As CacheCalendarios = New CacheCalendarios()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As CacheCalendarios
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New Eniac.Reglas.Calendarios().GetTodos())
      End Sub

      Public Overloads Function Buscar(id As Integer) As Entidades.Calendario
         Return MyBase.Buscar(Function(x) x.IdCalendario = id)
      End Function
      Public Function Existe(id As Integer) As Boolean
         Return Buscar(id) IsNot Nothing
      End Function

   End Class
End Namespace