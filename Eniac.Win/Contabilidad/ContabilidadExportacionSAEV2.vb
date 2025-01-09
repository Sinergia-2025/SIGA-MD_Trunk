Option Strict On
Option Explicit On
Imports System.Text

Public Class ContabilidadExportacionSAEv2
   Inherits ContabilidadExportacionCommon

   Public Overrides Sub GetLinea(linea As ContabilidadExportacionArchivoLinea, stb As StringBuilder)
      With stb
         'COMPENSADO CON CEROS  A LA IZ  LONG  5 - Número correlativo
         .Append(linea.NroDeAsiento.ToString("00000"))
         .Append(Chr(9))
         'SEGÚN PLAN DE CUENTAS COLICITAR A MOR - Longitud    11
         .Append(linea.CuentaMayor.ToString())
         .Append(Chr(9))
         '1 DEBE 2 HABER      LONG   1
         .Append(linea.DebeHaber.ToString())
         .Append(Chr(9))
         'LONG   14    POSISIONES DECIMALES - IMPLICITAS   RELLENAR CON CEROS IZQ
         .Append((linea.Importe * 100).ToString("00000000000000"))
         .Append(Chr(9))
         'REFERENCIA DEL ASIENTO    - LONG    30
         .Append(linea.Concepto)
         .Append(Chr(9))
         'CODIGO COMPROBANTE
         If linea.CodigoComprobante.HasValue Then
            .Append(linea.CodigoComprobante.Value)
         Else
            .Append(String.Empty)
         End If
         .Append(Chr(9))
         'FECHA REGISTRO
         .Append(linea.FechaRegistro.ToString("ddMMyyyy"))
         .Append(Chr(9))
         'SI LA OP. LO REQUIERE LONG  10
         .Append(linea.SubCuenta.ToString())
         .Append(Chr(9))
         'FECHA COMPROBANTE
         If linea.FechaComprobante.HasValue Then
            .Append(linea.FechaComprobante.Value.ToString("ddMMyyyy"))
         Else
            .Append(String.Empty)
         End If
         .Append(Chr(9))
         'FECHA VENCIMIENTO
         If linea.FechaVencimiento.HasValue Then
            .Append(linea.FechaVencimiento.Value.ToString("ddMMyyyy"))
         Else
            If linea.FechaComprobante.HasValue Then
               .Append(linea.FechaComprobante.Value.ToString("ddMMyyyy"))
            Else
               .Append(String.Empty)
            End If
         End If
         .Append(Chr(9))
         'PUNTO EMISION
         If linea.PuntoEmision.HasValue Then
            .Append(linea.PuntoEmision.Value)
         Else
            .Append(String.Empty)
         End If
         .Append(Chr(9))
         'NUMERO COMPROBANTE
         If linea.NumeroComprobante.HasValue Then
            .Append(linea.NumeroComprobante.Value)
         Else
            .Append(String.Empty)
         End If
      End With
   End Sub
End Class
