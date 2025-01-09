Imports LibreriaFiscalV2

Namespace FiscalV2
   Public Class ObtenerAuditoriaPorFechaEpson
      Implements IObtenerAuditoriaPorFecha

      Private _controladorFiscal As ControladorFiscal

      Public Sub New(controladorFiscal As ControladorFiscal)
         _controladorFiscal = controladorFiscal
      End Sub

      Public Sub ObtenerAuditoria(fechaDesde As Date, fechaHasta As Date, archivoSalida As String) Implements IObtenerAuditoriaPorFecha.ObtenerAuditoria
         ' extracción por fechas.
         _controladorFiscal.ObtenerPrimerBloqueAuditoria(fechaDesde, fechaHasta, ControladorFiscal.F2G_TiposDeReporteZ.REPORTE_ZFECHA, False, False)

         If (_controladorFiscal.Respuesta.CodigoRetorno = ControladorFiscal.F2G_CodigosRetorno.SUB_ESTADO_INVALIDO) Then
            _controladorFiscal.CancelarObtencionBloqueAuditoria()
            _controladorFiscal.ObtenerPrimerBloqueAuditoria(fechaDesde, fechaHasta, ControladorFiscal.F2G_TiposDeReporteZ.REPORTE_ZFECHA, False, False)
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