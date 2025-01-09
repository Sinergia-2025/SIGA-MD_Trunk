Namespace Ayudante
   Public Class Comisiones
      Public Shared Sub Calculo(queSuma As String,
         aliasEmpleado As String, aliasEmpreadoProducto As String, aliasEmpreadoProductoLista As String, aliasRubro As String, aliasEmpleadoRubro As String,
         aliasEmpleadoRubroLista As String, aliasEmpleadoSubRubro As String, aliasEmpleadoSubSubRubro As String,
         aliasMarca As String, aliasEmpreadoMarca As String, aliasEmpleadoMarcaLista As String, aliasProducto As String,
         comisionVendedor As String,
         stb As StringBuilder)

         If comisionVendedor = "VENDEDORRUBROMARCA" Then
            With stb
               'la función COALESCE, que devuelve el primer valor no nulo en la lista de argumentos. 
               .AppendFormatLine("       {0} / 100 *  COALESCE(", queSuma)
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpreadoProductoLista)      'EMPLEADO PRODUCTO LISTA
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpreadoProducto)           'EMPLEADO PRODUCTO
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpleadoSubSubRubro)        'EMPLEADO SUB SUB RUBRO
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpleadoSubRubro)           'EMPLEADO SUB RUBRO
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpleadoRubroLista)         'EMPLEADO RUBRO LISTA
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpleadoRubro)              'EMPLEADO RUBRO
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpleadoMarcaLista)         'EMPLEADO MARCA LISTA
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpreadoMarca)              'EMPLEADO MARCA
               .AppendFormatLine("       NULLIF({0}.ComisionPorVenta, 0),", aliasProducto)           'PRODUCTO
               .AppendFormatLine("       NULLIF({0}.ComisionPorVenta, 0),", aliasRubro)              'RUBRO
               .AppendFormatLine("       NULLIF({0}.ComisionPorVenta, 0),", aliasMarca)              'MARCA
               .AppendFormatLine("       {0}.ComisionPorVenta ) ", aliasEmpleado)                     'EMPLEADO


               '.AppendFormatLine("       {0} / 100 * ", queSuma)
               '.AppendFormatLine("       CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpreadoProducto)                                            'EMPLEADO PRODUCTO
               '.AppendFormatLine("          CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpleadoSubSubRubro)                                      'EMPLEADO SUB SUB RUBRO
               '.AppendFormatLine("             CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpleadoSubRubro)                                      'EMPLEADO SUB RUBRO
               '.AppendFormatLine("                CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpleadoRubroLista)                                 'EMPLEADO RUBRO LISTA
               '.AppendFormatLine("                   CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpleadoRubro)                                   'EMPLEADO RUBRO
               '.AppendFormatLine("                     CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpleadoMarcaLista)                            'EMPLEADO MARCA LISTA
               '.AppendFormatLine("                        CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpreadoMarca)                              'EMPLEADO MARCA
               '.AppendFormatLine("                           CASE WHEN ISNULL({0}.ComisionPorVenta, 0) <> 0 THEN {0}.ComisionPorVenta ELSE", aliasProducto)                'PRODUCTO
               '.AppendFormatLine("                              CASE WHEN ISNULL({0}.ComisionPorVenta, 0) <> 0 THEN {0}.ComisionPorVenta ELSE", aliasRubro)                'RUBRO
               '.AppendFormatLine("                                 CASE WHEN {0}.ComisionPorVenta <> 0 THEN {0}.ComisionPorVenta", aliasMarca)                             'MARCA
               '.AppendFormatLine("                                 ELSE {0}.ComisionPorVenta", aliasEmpleado)                                                              'EMPLEADO
               '.AppendFormatLine("                                 END")
               '.AppendFormatLine("                              END")
               '.AppendFormatLine("                           END")
               '.AppendFormatLine("                        END")
               '.AppendFormatLine("                     END")
               '.AppendFormatLine("                   END")
               '.AppendFormatLine("                END")
               '.AppendFormatLine("             END")
               '.AppendFormatLine("          END")
               '.AppendFormatLine("       END")
            End With
         Else
            With stb
               .AppendFormatLine("       {0} / 100 *  COALESCE(", queSuma)
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpreadoProductoLista)      'EMPLEADO PRODUCTO LISTA
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpreadoProducto)           'EMPLEADO PRODUCTO
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpleadoMarcaLista)         'EMPLEADO MARCA LISTA
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpreadoMarca)              'EMPLEADO MARCA
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpleadoSubSubRubro)        'EMPLEADO SUB SUB RUBRO
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpleadoSubRubro)           'EMPLEADO SUB RUBRO
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpleadoRubroLista)         'EMPLEADO RUBRO LISTA
               .AppendFormatLine("       NULLIF({0}.Comision, 0),", aliasEmpleadoRubro)              'EMPLEADO RUBRO
               .AppendFormatLine("       NULLIF({0}.ComisionPorVenta, 0),", aliasProducto)           'PRODUCTO
               .AppendFormatLine("       NULLIF({0}.ComisionPorVenta, 0),", aliasMarca)              'RUBRO
               .AppendFormatLine("       NULLIF({0}.ComisionPorVenta, 0),", aliasRubro)              'MARCA
               .AppendFormatLine("       {0}.ComisionPorVenta ) ", aliasEmpleado)                     'EMPLEADO


               '.AppendFormatLine("       {0} / 100 * ", queSuma)
               '.AppendFormatLine("          CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpreadoProducto)                                         'EMPLEADO PRODUCTO
               '.AppendFormatLine("             CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpleadoMarcaLista)                                    'EMPLEADO MARCA LISTA
               '.AppendFormatLine("                CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpreadoMarca)                                      'EMPLEADO MARCA
               '.AppendFormatLine("                   CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpleadoSubSubRubro)                             'EMPLEADO SUB SUB RUBRO
               '.AppendFormatLine("                      CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpleadoSubRubro)                             'EMPLEADO SUB RUBRO
               '.AppendFormatLine("                         CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpleadoRubroLista)                        'EMPLEADO RUBRO LISTA
               '.AppendFormatLine("                            CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpleadoRubro)                          'EMPLEADO RUBRO
               '.AppendFormatLine("                               CASE WHEN ISNULL({0}.ComisionPorVenta, 0) <> 0 THEN {0}.ComisionPorVenta ELSE", aliasProducto)            'PRODUCTO 
               '.AppendFormatLine("                                  CASE WHEN {0}.ComisionPorVenta <> 0 THEN {0}.ComisionPorVenta ELSE", aliasMarca)                       'MARCA
               '.AppendFormatLine("                                     CASE WHEN {0}.ComisionPorVenta <> 0 THEN {0}.ComisionPorVenta", aliasRubro)                         'RUBRO
               '.AppendFormatLine("                                     ELSE {0}.ComisionPorVenta", aliasEmpleado)                                                          'EMPLEADO
               '.AppendFormatLine("                                     END")
               '.AppendFormatLine("                                  END")
               '.AppendFormatLine("                               END")
               '.AppendFormatLine("                            END")
               '.AppendFormatLine("                         END")
               '.AppendFormatLine("                      END")
               '.AppendFormatLine("                   END")
               '.AppendFormatLine("                END")
               '.AppendFormatLine("             END")
               '.AppendFormatLine("          END")
            End With
         End If



         'Dim primeroEmpleado As String = If(comisionVendedor = "VENDEDORRUBROMARCA", aliasEmpleadoRubro, aliasEmpreadoMarca)
         'Dim segundoEmpleado As String = If(comisionVendedor = "VENDEDORRUBROMARCA", aliasEmpreadoMarca, aliasEmpleadoRubro)
         'Dim primeroSolo As String = If(comisionVendedor = "VENDEDORRUBROMARCA", aliasRubro, aliasMarca)
         'Dim segundoSolo As String = If(comisionVendedor = "VENDEDORRUBROMARCA", aliasMarca, aliasRubro)

         'With stb
         '   .AppendFormatLine("       {0} / 100 * ", queSuma)
         '   .AppendFormatLine("             CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", aliasEmpreadoProducto)
         '   .AppendFormatLine("                  CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", primeroEmpleado)
         '   .AppendFormatLine("                       CASE WHEN {0}.ComisionPorVenta <> 0 THEN {0}.ComisionPorVenta ELSE", primeroSolo)
         '   .AppendFormatLine("                            CASE WHEN ISNULL({0}.Comision, 0) <> 0 THEN {0}.Comision ELSE", segundoEmpleado)
         '   .AppendFormatLine("                                 CASE WHEN {0}.ComisionPorVenta <> 0 THEN {0}.ComisionPorVenta", segundoSolo)
         '   .AppendFormatLine("                                 ELSE {0}.ComisionPorVenta", aliasEmpleado)
         '   .AppendFormatLine("                              END")
         '   .AppendFormatLine("                           END")
         '   .AppendFormatLine("                        END")
         '   .AppendFormatLine("                     END")
         '   .AppendFormatLine("                  END")
         'End With
      End Sub
   End Class
End Namespace