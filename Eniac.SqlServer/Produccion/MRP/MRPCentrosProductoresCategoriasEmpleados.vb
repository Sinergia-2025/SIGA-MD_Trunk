Imports Eniac.Entidades

Public Class MRPCentrosProductoresCategoriasEmpleados
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CentrosProductoresCategoriaE_I(idCentroProductor As Integer,
                                             idCategoriaEmpleado As Integer,
                                             cantidadCategoria As Decimal,
                                             valorHoraCategoria As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4})",
                       MRPCentroProductorCategoriaEmpleado.NombreTabla,
                       MRPCentroProductorCategoriaEmpleado.Columnas.IdCentroProductor.ToString(),
                       MRPCentroProductorCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString(),
                       MRPCentroProductorCategoriaEmpleado.Columnas.CantidadCategoria.ToString(),
                       MRPCentroProductorCategoriaEmpleado.Columnas.ValorHoraCategoria.ToString()).AppendLine()

         .AppendFormat("  VALUES ({0}, {1}, {2}, {3}",
                        idCentroProductor,
                        idCategoriaEmpleado,
                        cantidadCategoria,
                        valorHoraCategoria)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub CentrosProductoresCategoriaE_U(idCentroProductor As Integer,
                                             idCategoriaEmpleado As Integer,
                                             cantidadCategoria As Decimal,
                                             valorHoraCategoria As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", MRPCentroProductorCategoriaEmpleado.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} =  {1}  ", MRPCentroProductorCategoriaEmpleado.Columnas.CantidadCategoria.ToString(), cantidadCategoria).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPCentroProductorCategoriaEmpleado.Columnas.ValorHoraCategoria.ToString(), valorHoraCategoria).AppendLine()
         .AppendFormat(" WHERE {0} =  {1}  ", MRPCentroProductorCategoriaEmpleado.Columnas.IdCentroProductor.ToString(), idCentroProductor).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", MRPCentroProductorCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString(), idCategoriaEmpleado).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub CentrosProductoresCategoriaE_D(idCentroProductor As Integer,
                                             idCategoriaEmpleado As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} ", MRPCentroProductorCategoriaEmpleado.NombreTabla)
         .AppendFormat(" WHERE {0} =  {1}  ", MRPCentroProductorCategoriaEmpleado.Columnas.IdCentroProductor.ToString(), idCentroProductor).AppendLine()
         If idCategoriaEmpleado > 0 Then
            .AppendFormat("   AND {0} =  {1}  ", MRPCentroProductorCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString(), idCategoriaEmpleado).AppendLine()
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT CPCE.*, CE.Descripcion, CE.ValorhoraProduccion FROM {0} AS CPCE ", MRPCentroProductorCategoriaEmpleado.NombreTabla).AppendLine()
         .AppendFormat("   INNER JOIN {0} AS CE ON CPCE.IdCategoriaEmpleado = CE.IdCategoriaEmpleado ", MRPCategoriaEmpleado.NombreTabla).AppendLine()
      End With
   End Sub

   Private Function CentrosProductoresCategoriaE_G(idCentroProd As Integer, idCategoria As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCentroProd > 0 Then
            .AppendFormat("   AND CPCE.IdCentroProductor = {0}", idCentroProd).AppendLine()
         End If
         If idCategoria > 0 Then
            .AppendFormat("   AND CPCE.IdCategoriaEmpleado = {0}", idCategoria).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function CentrosProductoresCategoriaE_G1(idCentroProd As Integer,
                                                   idCategoriaEmp As Integer) As DataTable
      Return CentrosProductoresCategoriaE_G(idCentroProd, idCategoriaEmp)
   End Function
   Public Function CentrosProductoresCategoriaE_GA() As DataTable
      Return CentrosProductoresCategoriaE_G(idCentroProd:=0, idCategoria:=0)
   End Function
   Public Function CentrosProductoresCategoriaE_GA(idCentroProd As Integer, idCategoriaEmp As Integer) As DataTable
      Return CentrosProductoresCategoriaE_G(idCentroProd:=idCentroProd, idCategoria:=idCategoriaEmp)
   End Function

End Class
