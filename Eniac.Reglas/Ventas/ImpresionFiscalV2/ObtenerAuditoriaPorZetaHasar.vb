Imports LibreriaFiscalV2

Namespace FiscalV2
   Public Class ObtenerAuditoriaPorZetaHasar
      Implements IObtenerAuditoriaPorZeta

      Private _controladorFiscal As ControladorFiscal

      Public Sub New(controladorFiscal As ControladorFiscal)
         _controladorFiscal = controladorFiscal
      End Sub

      Public ReadOnly Property PuedeExportarPorNroZeta As Boolean Implements IObtenerAuditoriaPorZeta.PuedeExportarPorNroZeta
         Get
            Return False
         End Get
      End Property

      Public Sub ObtenerAuditoria(zetaDesde As Integer, zetaHasta As Integer, archivoSalida As String) Implements IObtenerAuditoriaPorZeta.ObtenerAuditoria
         Throw New NotImplementedException()
      End Sub

   End Class
End Namespace