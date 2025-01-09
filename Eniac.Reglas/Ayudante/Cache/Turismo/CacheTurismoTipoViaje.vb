Namespace Ayudante.Cache.Turismo
   Public Class CacheTurismoTipoViaje
      Inherits BusquedaCacheadaCommon(Of Entidades.TurismoTipoViaje)

#Region "Singleton"
      Private Shared _instancia As CacheTurismoTipoViaje = New CacheTurismoTipoViaje()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As CacheTurismoTipoViaje
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New TurismoTiposViajes().GetTodos())
      End Sub

      Public Overloads Function Buscar(idTipoViaje As Integer) As Entidades.TurismoTipoViaje
         Return Buscar(Function(x) x.IdTipoViaje = idTipoViaje)
      End Function
      Public Function Existe(idTipoViaje As Integer) As Boolean
         Return Buscar(idTipoViaje) IsNot Nothing
      End Function

   End Class
End Namespace