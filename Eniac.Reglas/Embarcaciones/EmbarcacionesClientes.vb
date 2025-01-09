Public Class EmbarcacionesClientes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Eniac.Datos.DataAccess())
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "EmbarcacionesClientes"
      da = accesoDatos
   End Sub

#End Region

   Public Function GetResponsablesDeCargos(ByVal idEmbarcacion As Long) As DataTable
      If Not New Reglas.Generales().ExisteTabla("EmbarcacionesClientes") Then
         Return New DataTable()
      End If
      Return New SqlServer.EmbarcacionesClientes(Me.da).GetResponsablesDeCargos(idEmbarcacion)
   End Function

End Class