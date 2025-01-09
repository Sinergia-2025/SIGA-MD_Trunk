Public Class ProspectosABM
   Inherits ClientesABM
   Public Sub New()
      MyBase.New()
      ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Prospecto
      Name = "ProspectosABM"
   End Sub
End Class
