Namespace Ayudante.Cache.Archivos
   Public Class CacheTiposVehiculos
      Inherits BusquedaCacheadaCommon(Of Entidades.TipoVehiculo)

#Region "Singleton"
      Private Shared _instancia As CacheTiposVehiculos = New CacheTiposVehiculos()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As CacheTiposVehiculos
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New TiposVehiculos().GetTodos())
      End Sub

      Public Overloads Function Buscar(idTipoVehiculo As Integer) As Entidades.TipoVehiculo
         Return MyBase.Buscar(Function(x) x.IdTipoVehiculo = idTipoVehiculo)
      End Function
      Public Function Existe(idTipoVehiculo As Integer) As Boolean
         Return Buscar(idTipoVehiculo) IsNot Nothing
      End Function

   End Class
End Namespace