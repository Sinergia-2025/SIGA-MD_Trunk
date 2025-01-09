Public Class Camas
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.NombreEntidad = "Camas"
      da = New Datos.DataAccess()
   End Sub
   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Camas"
      da = accesoDatos
   End Sub
#End Region

   Public Function GetCamaPorCodigo(ByVal codigo As String) As DataTable
      Return New SqlServer.Camas(Me.da).GetFiltradoCamaPorCodigo(codigo)
   End Function

End Class
