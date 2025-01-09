Imports System.Runtime.CompilerServices
Namespace Extensions
   Public Module VentaExtensions
      <Extension()>
      Public Function NombreArchivoExportar(v As Entidades.Venta) As String
         Return v.NombreArchivoExportar(Nothing)
      End Function
      <Extension()>
      Public Function NombreArchivoExportar(v As Entidades.Venta, sufijo As String) As String
         Dim result = String.Format("{0}_{1}_{2}_{3:0000}_{4:00000000}_{5:yyyyMMdd_HHmmss}",
                                    v.IdSucursal,
                                    v.IdTipoComprobante,
                                    v.LetraComprobante,
                                    v.CentroEmisor,
                                    v.NumeroComprobante,
                                    Date.Now)
         If Not String.IsNullOrWhiteSpace(sufijo) Then
            result = String.Concat(result, "_", sufijo)
         End If
         Return result
      End Function
      <Extension()>
      Public Function PKComprobante(v As Entidades.Venta) As Entidades.IPKComprobante
         Return New Entidades.PKComprobante(v)
      End Function
   End Module
End Namespace