Imports LibreriaFiscalV2

Namespace FiscalV2
   Public Class ImpresionFiscalV2Factory

      Public Shared Function ObtenerAuditoriaPorFecha(controladorFiscal As ControladorFiscal) As IObtenerAuditoriaPorFecha
         Dim marca = ResolverMarcaSegunModelo(controladorFiscal.Modelo)
         If marca = Marca.Epson Then
            Return New ObtenerAuditoriaPorFechaEpson(controladorFiscal)
         ElseIf marca = Marca.Hasar Then
            Return New ObtenerAuditoriaPorFechaHasar(controladorFiscal)
         Else
            Throw New NotImplementedException(String.Format("Marca de modelo no soportada. Marca: '{0}'", marca))
         End If
      End Function
      Public Shared Function ObtenerAuditoriaPorZeta(controladorFiscal As ControladorFiscal) As IObtenerAuditoriaPorZeta
         Dim marca = ResolverMarcaSegunModelo(controladorFiscal.Modelo)
         If marca = Marca.Epson Then
            Return New ObtenerAuditoriaPorZetaEpson(controladorFiscal)
         ElseIf marca = Marca.Hasar Then
            Return New ObtenerAuditoriaPorZetaHasar(controladorFiscal)
         Else
            Throw New NotImplementedException(String.Format("Marca de modelo no soportada. Marca: '{0}'", marca))
         End If
      End Function
      Public Shared Function InformeAFIP(controladorFiscal As ControladorFiscal) As IInformeAFIP
         Dim marca = ResolverMarcaSegunModelo(controladorFiscal.Modelo)
         If marca = Marca.Epson Then
            Return New InformeAFIPEpson(controladorFiscal)
         ElseIf marca = Marca.Hasar Then
            Return New InformeAFIPHasar(controladorFiscal)
         Else
            Throw New NotImplementedException(String.Format("Marca de modelo no soportada. Marca: '{0}'", marca))
         End If
      End Function


      Private Shared Function ResolverMarcaSegunModelo(modelo As ControladorFiscal.ModelosFiscales) As Marca
         If modelo = ControladorFiscal.ModelosFiscales.HASAR_250_2G Then
            Return Marca.Hasar
         ElseIf modelo = ControladorFiscal.ModelosFiscales.EPSON_TM900AF Then
            Return Marca.Epson
         Else
            Throw New NotImplementedException(String.Format("La exportación de informes no se encuentra habilitada para el modelo {0}", modelo.ToString()))
         End If
      End Function
      Private Enum Marca
         Epson
         Hasar
      End Enum
   End Class
End Namespace