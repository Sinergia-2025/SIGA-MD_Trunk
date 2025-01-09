Imports LibreriaFiscalV2

Namespace FiscalV2
   Public Class ObtenerAuditoriaPorZetaEpson
      Implements IObtenerAuditoriaPorZeta

      Private _controladorFiscal As ControladorFiscal

      Public Sub New(controladorFiscal As ControladorFiscal)
         _controladorFiscal = controladorFiscal
      End Sub

      Public ReadOnly Property PuedeExportarPorNroZeta As Boolean Implements IObtenerAuditoriaPorZeta.PuedeExportarPorNroZeta
         Get
            Return True
         End Get
      End Property

      Public Sub ObtenerAuditoria(zetaDesde As Integer, zetaHasta As Integer, archivoSalida As String) Implements IObtenerAuditoriaPorZeta.ObtenerAuditoria

         ' extracción por nro. de Zetas
         _controladorFiscal.ObtenerPrimerBloqueAuditoria(zetaDesde, zetaHasta, False, False)

         If (_controladorFiscal.Respuesta.CodigoRetorno = ControladorFiscal.F2G_CodigosRetorno.SUB_ESTADO_INVALIDO) Then
            _controladorFiscal.CancelarObtencionBloqueAuditoria()
            _controladorFiscal.ObtenerPrimerBloqueAuditoria(1, 10, False, False)
         End If

         Using sfile = New IO.StreamWriter(archivoSalida)
            Do
               _controladorFiscal.ObtenerSiguienteBloqueAuditoria()
               sfile.Write(_controladorFiscal.Respuesta.Campo(3).ToString())
               If _controladorFiscal.Respuesta.Campo(4).ToString().ToUpper() <> "S" Then
                  sfile.Close()
                  Exit Do
               End If
            Loop
         End Using

         _controladorFiscal.FinalizarObtencionBloqueAuditoria()

      End Sub
   End Class
End Namespace