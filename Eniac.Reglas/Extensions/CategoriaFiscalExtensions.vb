Option Strict On
Option Explicit On
Imports System.Runtime.CompilerServices
Namespace Extensions
   Public Module CategoriaFiscalExtensions
      <Extension>
      Public Function ResuelveUtilizaAlicuota2Producto(categoria As Entidades.CategoriaFiscal, cliente As Entidades.Cliente) As Boolean
         Dim utilizaAlicuota2Producto As Boolean = categoria.UtilizaAlicuota2Producto
         If cliente IsNot Nothing Then
            utilizaAlicuota2Producto = cliente.Alicuota2deProducto = Entidades.Cliente.Alicuota2DeProductoSegun.SI Or
                                       (cliente.Alicuota2deProducto = Entidades.Cliente.Alicuota2DeProductoSegun.SEGUNCATEGORIAFISCAL And
                                        categoria.UtilizaAlicuota2Producto)
         End If
         Return utilizaAlicuota2Producto
      End Function

   End Module
End Namespace