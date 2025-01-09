Option Strict On
Option Explicit On
Imports System.Text

Public Class ContabilidadExportacionSAE
   Inherits ContabilidadExportacionCommon

   Public Overrides Sub GetLinea(linea As ContabilidadExportacionArchivoLinea, stb As StringBuilder)
      With stb
         'COMPENSADO CON CEROS  A LA IZ  LONG  5 - Número correlativo
         .Append(linea.NroDeAsiento.ToString("00000"))
         .Append(Chr(9))
         'SEGÚN PLAN DE CUENTAS COLICITAR A MOR - Longitud    11
         .Append(linea.CuentaMayor.ToString("00000000000"))
         .Append(Chr(9))
         'REFERENCIA DEL ASIENTO    - LONG    30
         .Append(linea.Concepto)
         .Append(Chr(9))
         'SI LA OP. LO REQUIERE LONG  10
         .Append(linea.SubCuenta.ToString("0000000000"))
         .Append(Chr(9))
         '1 DEBE 2 HABER      LONG   1
         .Append(linea.DebeHaber.ToString())
         .Append(Chr(9))
         'LONG   14    POSISIONES DECIMALES - IMPLICITAS   RELLENAR CON CEROS IZQ
         .Append((linea.Importe * 100).ToString("00000000000000"))
      End With
   End Sub
End Class
