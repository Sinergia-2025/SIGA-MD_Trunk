Option Strict On
Option Explicit On
Namespace Validaciones.Impositivo
   Public Interface IValidarIdFiscal
      Inherits IValidacion(Of DatosValidacionFiscal)

   End Interface

   Public Class DatosValidacionFiscal
      Public Property IdFiscal As String
      Public Property SolicitaCUIT As Boolean
      'Public Property CategoriaFiscal As Entidades.CategoriaFiscal
      'Public Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto
   End Class

End Namespace