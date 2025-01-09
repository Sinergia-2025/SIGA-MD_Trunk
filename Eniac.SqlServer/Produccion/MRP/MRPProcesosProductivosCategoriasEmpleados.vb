Imports Eniac.Entidades

Public Class MRPProcesosProductivosCategoriasEmpleados
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProcesosProductivosCategoriaE_I(idOperacion As Integer,
                                              idProcesoProductivo As Long,
                                              idCategoriaEmpleado As Integer,
                                              cantidadCategoria As Decimal,
                                              valorHoraCategoria As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5})",
                       MRPProcesoProductivoCategoriaEmpleado.NombreTabla,
                       MRPProcesoProductivoCategoriaEmpleado.Columnas.IdOperacion.ToString(),
                       MRPProcesoProductivoCategoriaEmpleado.Columnas.IdProcesoProductivo.ToString(),
                       MRPProcesoProductivoCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString(),
                       MRPProcesoProductivoCategoriaEmpleado.Columnas.CantidadCategoria.ToString(),
                       MRPProcesoProductivoCategoriaEmpleado.Columnas.ValorHoraCategoria.ToString()).AppendLine()

         .AppendFormat("  VALUES ({0}, {1}, {2}, {3}, {4}",
                        idOperacion,
                        idProcesoProductivo,
                        idCategoriaEmpleado,
                        cantidadCategoria,
                        valorHoraCategoria)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub ProcesosProductivosCategoriaE_U(idOperacion As Integer,
                                              idProcesoProductivo As Long,
                                              idCategoriaEmpleado As Integer,
                                              cantidadCategoria As Decimal,
                                              valorHoraCategoria As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", MRPProcesoProductivoCategoriaEmpleado.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} =  {1}  ", MRPProcesoProductivoCategoriaEmpleado.Columnas.CantidadCategoria.ToString(), cantidadCategoria).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivoCategoriaEmpleado.Columnas.ValorHoraCategoria.ToString(), valorHoraCategoria).AppendLine()
         .AppendFormat(" WHERE {0} =  {1}  ", MRPProcesoProductivoCategoriaEmpleado.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", MRPProcesoProductivoCategoriaEmpleado.Columnas.IdOperacion.ToString(), idOperacion).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", MRPProcesoProductivoCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString(), idCategoriaEmpleado).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ProcesosProductivosCategoriaE_D(idOperacion As Integer,
                                              idProcesoProductivo As Long,
                                              idCategoriaEmpleado As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} ", MRPProcesoProductivoCategoriaEmpleado.NombreTabla)
         .AppendFormat(" WHERE {0} =  {1}  ", MRPProcesoProductivoCategoriaEmpleado.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", MRPProcesoProductivoCategoriaEmpleado.Columnas.IdOperacion.ToString(), idOperacion).AppendLine()
         If idCategoriaEmpleado > 0 Then
            .AppendFormat("   AND {0} =  {1}  ", MRPProcesoProductivoCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString(), idCategoriaEmpleado).AppendLine()
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT PPCE.*, PPO.CodigoProcProdOperacion, CE.Descripcion, CE.ValorhoraProduccion FROM {0} AS PPCE ", MRPProcesoProductivoCategoriaEmpleado.NombreTabla).AppendLine()
         .AppendFormat("   INNER JOIN {0} AS PPO ON PPO.IdProcesoProductivo = PPCE.IdProcesoProductivo AND PPO.IdOperacion = PPCE.idOperacion ", MRPProcesoProductivoOperacion.NombreTabla).AppendLine()
         .AppendFormat("   INNER JOIN {0} AS CE ON PPCE.IdCategoriaEmpleado = CE.IdCategoriaEmpleado ", MRPCategoriaEmpleado.NombreTabla).AppendLine()
      End With
   End Sub

   Private Function ProcesosProductivosCategoriaE_G(idProcesoProductivo As Long, idOperacion As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idProcesoProductivo > 0 Then
            .AppendFormat("   AND PPCE.IdProcesoProductivo = {0}", idProcesoProductivo).AppendLine()
         End If
         If idOperacion > 0 Then
            .AppendFormat("   AND PPCE.IdOperacion = {0}", idOperacion).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function ProcesosProductivosCategoriaE_G1(idProcesoProductivo As Long,
                                                    idOperacion As Integer) As DataTable
      Return ProcesosProductivosCategoriaE_G(idProcesoProductivo, idOperacion)
   End Function
   Public Function ProcesosProductivosCategoriaE_GA() As DataTable
      Return ProcesosProductivosCategoriaE_G(idProcesoProductivo:=0, idOperacion:=0)
   End Function
   Public Function ProcesosProductivosCategoriaE_GA(idProcesoProductivo As Long, idOperacion As Integer) As DataTable
      Return ProcesosProductivosCategoriaE_G(idProcesoProductivo:=idProcesoProductivo, idOperacion:=idOperacion)
   End Function

End Class
