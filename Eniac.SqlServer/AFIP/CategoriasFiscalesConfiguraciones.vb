Public Class CategoriasFiscalesConfiguraciones
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CategoriasFiscalesConfiguraciones_I(idCategoriaFiscalEmpresa As Short, idCategoriaFiscalCliente As Short,
                                                  letraFiscal As String, letraFiscalCompra As String,
                                                  ivaDiscriminado As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.CategoriaFiscalConfiguracion.NombreTabla).AppendLine()
         .AppendFormatLine("           ({0}, {1}, {2}, {3}, {4})",
                           Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalEmpresa.ToString(),
                           Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalCliente.ToString(),
                           Entidades.CategoriaFiscalConfiguracion.Columnas.LetraFiscal.ToString(),
                           Entidades.CategoriaFiscalConfiguracion.Columnas.LetraFiscalCompra.ToString(),
                           Entidades.CategoriaFiscalConfiguracion.Columnas.IvaDiscriminado.ToString())
         .AppendFormatLine("    VALUES ({0}, {1}, '{2}', '{3}', {4}",
                           idCategoriaFiscalEmpresa, idCategoriaFiscalCliente,
                           letraFiscal, letraFiscalCompra,
                           GetStringFromBoolean(ivaDiscriminado))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CategoriasFiscalesConfiguraciones_U(idCategoriaFiscalEmpresa As Short, idCategoriaFiscalCliente As Short,
                                                  letraFiscal As String, letraFiscalCompra As String,
                                                  ivaDiscriminado As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.CategoriaFiscalConfiguracion.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CategoriaFiscalConfiguracion.Columnas.LetraFiscal.ToString(), letraFiscal)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CategoriaFiscalConfiguracion.Columnas.LetraFiscalCompra.ToString(), letraFiscalCompra)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CategoriaFiscalConfiguracion.Columnas.IvaDiscriminado.ToString(), GetStringFromBoolean(ivaDiscriminado))

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalEmpresa.ToString(), idCategoriaFiscalEmpresa)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalCliente.ToString(), idCategoriaFiscalCliente)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CategoriasFiscalesConfiguraciones_M(idCategoriaFiscalEmpresa As Short, idCategoriaFiscalCliente As Short,
                                                  letraFiscal As String, letraFiscalCompra As String,
                                                  ivaDiscriminado As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO {0} AS D", Entidades.CategoriaFiscalConfiguracion.NombreTabla)
         .AppendFormatLine("        USING (SELECT  {1}  AS {0}", Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalEmpresa.ToString(), idCategoriaFiscalEmpresa)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalCliente.ToString(), idCategoriaFiscalCliente)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.CategoriaFiscalConfiguracion.Columnas.LetraFiscal.ToString(), letraFiscal)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.CategoriaFiscalConfiguracion.Columnas.LetraFiscalCompra.ToString(), letraFiscalCompra)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.CategoriaFiscalConfiguracion.Columnas.IvaDiscriminado.ToString(), GetStringFromBoolean(ivaDiscriminado))
         .AppendFormatLine("              ) AS O ON O.{0} = D.{0} AND O.{1} = D.{1}",
                           Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalEmpresa.ToString(),
                           Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalCliente.ToString())
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET D.{0} = O.{0}, D.{1} = O.{1}, D.{2} = O.{2}",
                           Entidades.CategoriaFiscalConfiguracion.Columnas.LetraFiscal.ToString(),
                           Entidades.CategoriaFiscalConfiguracion.Columnas.LetraFiscalCompra.ToString(),
                           Entidades.CategoriaFiscalConfiguracion.Columnas.IvaDiscriminado.ToString())
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT ({0}, {1}, {2}, {3}, {4}) VALUES (O.{0}, O.{1}, O.{2}, O.{3}, O.{4})",
                           Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalEmpresa.ToString(),
                           Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalCliente.ToString(),
                           Entidades.CategoriaFiscalConfiguracion.Columnas.LetraFiscal.ToString(),
                           Entidades.CategoriaFiscalConfiguracion.Columnas.LetraFiscalCompra.ToString(),
                           Entidades.CategoriaFiscalConfiguracion.Columnas.IvaDiscriminado.ToString())
         .AppendFormatLine(";")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CategoriasFiscalesConfiguraciones_D(idCategoriaFiscalEmpresa As Short, idCategoriaFiscalCliente As Short)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CategoriaFiscalConfiguracion.NombreTabla)
         .AppendFormatLine(" WHERE 1 = 1")
         If idCategoriaFiscalEmpresa > 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalEmpresa.ToString(), idCategoriaFiscalEmpresa)
         End If
         If idCategoriaFiscalCliente > 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalCliente.ToString(), idCategoriaFiscalCliente)
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CFC.*")
         .AppendFormatLine("  FROM {0} AS CFC", Entidades.CategoriaFiscalConfiguracion.NombreTabla)
      End With
   End Sub

   'Public Function CategoriasFiscalesConfiguraciones_GA() As DataTable
   '   Return CategoriasFiscalesConfiguraciones_G(idCategoriaFiscalEmpresa:=0, idCategoriaFiscalCliente:=0)
   'End Function
   Public Function CategoriasFiscalesConfiguraciones_GA(idCategoriaFiscalEmpresa As Short) As DataTable
      Return CategoriasFiscalesConfiguraciones_G(idCategoriaFiscalEmpresa, idCategoriaFiscalCliente:=0)
   End Function
   Public Function CategoriasFiscalesConfiguraciones_G(idCategoriaFiscalEmpresa As Short, idCategoriaFiscalCliente As Short) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCategoriaFiscalEmpresa > 0 Then
            .AppendFormatLine("   AND MR.{0} = {1}", Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalEmpresa.ToString(), idCategoriaFiscalEmpresa)
         End If
         If idCategoriaFiscalCliente > 0 Then
            .AppendFormatLine("   AND MR.{0} = {1}", Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalCliente.ToString(), idCategoriaFiscalCliente)
         End If
         .AppendFormatLine(" ORDER BY MR.{0}", Entidades.CategoriaFiscalConfiguracion.Columnas.IdCategoriaFiscalCliente.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CategoriasFiscalesConfiguraciones_G1(idCategoriaFiscalEmpresa As Short, idCategoriaFiscalCliente As Short) As DataTable
      Return CategoriasFiscalesConfiguraciones_G(idCategoriaFiscalEmpresa, idCategoriaFiscalCliente)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      'If columna = "NombreVendedor" Then
      '   columna = "E.NombreEmpleado"
      'ElseIf columna = "NombreTransportista" Then
      '   columna = "T." + columna
      'Else
      columna = "CFC." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class