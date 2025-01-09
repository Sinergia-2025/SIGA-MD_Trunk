Public Class PCs
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "PCs"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region


   Public Function GetPCsHabilitadas() As List(Of Entidades.PC)
      Dim sql As SqlServer.PCs = New SqlServer.PCs(Me.da)
      Dim dt As DataTable = sql.GetPCsHabilitadas()
      Dim o As Entidades.PC
      Dim oLis As List(Of Entidades.PC) = New List(Of Entidades.PC)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.PC()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Private Sub CargarUno(ByVal o As Entidades.PC, ByVal dr As DataRow)
      With o
         .NombrePC = dr("NombrePC").ToString()
         .Mac = dr("Mac").ToString()
      End With
   End Sub

End Class
