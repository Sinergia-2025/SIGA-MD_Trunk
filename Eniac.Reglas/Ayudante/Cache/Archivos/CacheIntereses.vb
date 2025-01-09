Namespace Ayudante.Cache.Archivos
   Public Class CacheIntereses
      Inherits BusquedaCacheadaCommon(Of Entidades.Interes)

#Region "Singleton"
      Private Shared _instancia As CacheIntereses = New CacheIntereses()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As CacheIntereses
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New Intereses().GetTodos())
      End Sub

      Public Overloads Function Buscar(idInteres As Integer) As Entidades.Interes
         Return Buscar(Function(x) x.IdInteres = idInteres)
      End Function
      Public Function Existe(idInteres As Integer) As Boolean
         Return Buscar(idInteres) IsNot Nothing
      End Function

   End Class
End Namespace