Namespace Ayudante
   Public Class BusquedaCacheadaCRMMedioComunicacionNovedad
      Inherits BusquedaCacheadaCommonCRM(Of Entidades.CRMMedioComunicacionNovedad)

#Region "Singleton"
      Private Shared _instancia As BusquedaCacheadaCRMMedioComunicacionNovedad = New BusquedaCacheadaCRMMedioComunicacionNovedad()
      ''' <summary>
      ''' Obtiene la instancia única del Cache de Parámetros (ReadOnly/Singleton)
      ''' </summary>
      ''' <returns>Instancia del Cache de Parámetros</returns>
      ''' <remarks></remarks>
      Public Shared ReadOnly Property Instancia As BusquedaCacheadaCRMMedioComunicacionNovedad
         Get
            Return _instancia
         End Get
      End Property
#End Region

      Public Sub New()
         MyBase.New(Function() New CRMMediosComunicacionesNovedades().GetTodos(idTipoNovedad:=String.Empty))
      End Sub

      Public Overloads Function Buscar(idMedioComunicacionNovedad As Integer) As Entidades.CRMMedioComunicacionNovedad
         Return Buscar(Function(x) x.IdMedioComunicacionNovedad = idMedioComunicacionNovedad)
      End Function
      Public Function Existe(idPrioridadNovedad As Integer) As Boolean
         Return Buscar(idPrioridadNovedad) IsNot Nothing
      End Function

      Public Function BuscarDefault(idTipoPrioridad As String) As Entidades.CRMMedioComunicacionNovedad
         Return Buscar(Function(x) x.IdTipoNovedad = idTipoPrioridad And x.PorDefecto)
      End Function
      Public Function BuscarDefaultOrFirst(idTipoNovedad As String) As Entidades.CRMMedioComunicacionNovedad
         Dim r = BuscarDefault(idTipoNovedad)
         Return If(r Is Nothing, GetTodos(idTipoNovedad)(0), r)
      End Function

   End Class
End Namespace