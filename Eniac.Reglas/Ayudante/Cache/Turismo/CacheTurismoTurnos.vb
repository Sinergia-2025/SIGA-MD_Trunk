Option Strict On
Option Explicit On
Namespace Ayudante.Cache.Turismo
   Public Class CacheTurismoTurnos
      Inherits BusquedaCacheadaCommon(Of Entidades.TurismoTurno)

#Region "Singleton"
      Private Shared _instancia As CacheTurismoTurnos = New CacheTurismoTurnos()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As CacheTurismoTurnos
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New Eniac.Reglas.TurismoTurnos().GetTodos())
      End Sub

      Public Overloads Function Buscar(idTurno As Integer) As Entidades.TurismoTurno
         Return MyBase.Buscar(Function(x) x.IdTurno = idTurno)
      End Function
      Public Function Existe(idTurno As Integer) As Boolean
         Return Buscar(idTurno) IsNot Nothing
      End Function

   End Class
End Namespace