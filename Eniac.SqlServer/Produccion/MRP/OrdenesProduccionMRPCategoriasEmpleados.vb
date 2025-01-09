Imports Eniac.Entidades

Public Class OrdenesProduccionMRPCategoriasEmpleados
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub OrdenesProduccionMRPCategoriasE_I(idSucursal As Integer,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Integer,
                                                numeroOrdenProduccion As Long,
                                                orden As Integer,
                                                idProducto As String,
                                                idProcesoProductivo As Long,
                                                idOperacion As Integer,
                                                idCategoriaEmpleado As Integer,
                                                cantidadCategoria As Decimal,
                                                valorHoraCategoria As Decimal)

      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12})",
                       OrdenProduccionMRPCategoriaEmpleado.NombreTabla,
                       OrdenProduccionMRPCategoriaEmpleado.Columnas.IdSucursal.ToString(),
                       OrdenProduccionMRPCategoriaEmpleado.Columnas.IdTipoComprobante.ToString(),
                       OrdenProduccionMRPCategoriaEmpleado.Columnas.LetraComprobante.ToString(),
                       OrdenProduccionMRPCategoriaEmpleado.Columnas.CentroEmisor.ToString(),
                       OrdenProduccionMRPCategoriaEmpleado.Columnas.NumeroOrdenProduccion.ToString(),
                       OrdenProduccionMRPCategoriaEmpleado.Columnas.Orden.ToString(),
                       OrdenProduccionMRPCategoriaEmpleado.Columnas.IdProducto.ToString(),
                       OrdenProduccionMRPCategoriaEmpleado.Columnas.IdProcesoProductivo.ToString(),
                       OrdenProduccionMRPCategoriaEmpleado.Columnas.IdOperacion.ToString(),
                       OrdenProduccionMRPCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString(),
                       OrdenProduccionMRPCategoriaEmpleado.Columnas.CantidadCategoria.ToString(),
                       OrdenProduccionMRPCategoriaEmpleado.Columnas.ValorHoraCategoria.ToString()).AppendLine()

         .AppendFormat("  VALUES ({0}, '{1}', '{2}', {3}, {4}, {5}, '{6}', {7}, {8}, {9}, {10}, {11})",
                        idSucursal,
                        idTipoComprobante,
                        letra,
                        centroEmisor,
                        numeroOrdenProduccion,
                        orden,
                        idProducto,
                        idProcesoProductivo,
                        idOperacion,
                        idCategoriaEmpleado,
                        cantidadCategoria,
                        valorHoraCategoria)
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub OrdenesProduccionMRPCategoriasE_U(idSucursal As Integer,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Integer,
                                                numeroOrdenProduccion As Long,
                                                orden As Integer,
                                                idProducto As String,
                                                idProcesoProductivo As Long,
                                                idOperacion As Integer,
                                                idCategoriaEmpleado As Integer,
                                                cantidadCategoria As Decimal,
                                                valorHoraCategoria As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", OrdenProduccionMRPCategoriaEmpleado.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.CantidadCategoria.ToString(), cantidadCategoria).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.ValorHoraCategoria.ToString(), valorHoraCategoria).AppendLine()
         .AppendFormat(" WHERE {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPCategoriaEmpleado.Columnas.LetraComprobante.ToString(), letra).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.CentroEmisor.ToString(), centroEmisor).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.Orden.ToString(), orden).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdProducto.ToString(), idProducto).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdOperacion.ToString(), idOperacion).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString(), idCategoriaEmpleado).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub OrdenesProduccionMRPCategoriasE_D(idSucursal As Integer,
                                               idTipoComprobante As String,
                                               letra As String,
                                               centroEmisor As Integer,
                                               numeroOrdenProduccion As Long,
                                               orden As Integer,
                                               idProducto As String,
                                               idProcesoProductivo As Long,
                                               idOperacion As Integer,
                                               idCategoriaEmpleado As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} ", OrdenProduccionMRPCategoriaEmpleado.NombreTabla)
         .AppendFormat(" WHERE {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPCategoriaEmpleado.Columnas.LetraComprobante.ToString(), letra).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.CentroEmisor.ToString(), centroEmisor).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.Orden.ToString(), orden).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdProducto.ToString(), idProducto).AppendLine()
         If idProcesoProductivo > 0 Then
            .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo).AppendLine()
         End If
         If idOperacion > 0 Then
            .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdOperacion.ToString(), idOperacion).AppendLine()
         End If
         If idCategoriaEmpleado > 0 Then
            .AppendFormat("   AND {0} =  {1}  ", MRPProcesoProductivoCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString(), idCategoriaEmpleado).AppendLine()
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT OPCE.*, CE.Descripcion, CE.ValorHoraProduccion FROM {0} AS OPCE ", OrdenProduccionMRPCategoriaEmpleado.NombreTabla).AppendLine()
         .AppendFormat("   INNER JOIN {0} AS CE ON OPCE.IdCategoriaEmpleado = CE.IdCategoriaEmpleado ", MRPCategoriaEmpleado.NombreTabla).AppendLine()
      End With
   End Sub
   Private Function OrdenesProduccionMRPCategoriaE_G(idSucursal As Integer,
                                                     idTipoComprobante As String,
                                                     letra As String,
                                                     centroEmisor As Integer,
                                                     numeroOrdenProduccion As Long,
                                                     orden As Integer,
                                                     idProducto As String,
                                                     idProcesoProductivo As Long,
                                                     idOperacion As Integer,
                                                     idCategoriaEmpleado As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPCategoriaEmpleado.Columnas.LetraComprobante.ToString(), letra).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.CentroEmisor.ToString(), centroEmisor).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.Orden.ToString(), orden).AppendLine()
         .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.NumeroOrdenProduccion.ToString(), numeroOrdenProduccion).AppendLine()
         .AppendFormat("   AND {0} = '{1}' ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdProducto.ToString(), idProducto).AppendLine()
         If idProcesoProductivo > 0 Then
            .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo).AppendLine()
         End If
         If idOperacion > 0 Then
            .AppendFormat("   AND {0} =  {1}  ", OrdenProduccionMRPCategoriaEmpleado.Columnas.IdOperacion.ToString(), idOperacion).AppendLine()
         End If
         If idCategoriaEmpleado > 0 Then
            .AppendFormat("   AND {0} =  {1}  ", MRPProcesoProductivoCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString(), idCategoriaEmpleado).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function OrdenesProduccionMRPCategoriaE_GA(idSucursal As Integer,
                                                     idTipoComprobante As String,
                                                     letra As String,
                                                     centroEmisor As Integer,
                                                     numeroOrdenProduccion As Long,
                                                     orden As Integer,
                                                     idProducto As String,
                                                     idProcesosProductivos As Long,
                                                     idOperacion As Integer) As DataTable
      Return OrdenesProduccionMRPCategoriaE_G(idSucursal:=idSucursal,
                                              idTipoComprobante:=idTipoComprobante,
                                              letra:=letra,
                                              centroEmisor:=centroEmisor,
                                              numeroOrdenProduccion:=
                                              numeroOrdenProduccion,
                                              orden:=orden,
                                              idProducto:=idProducto,
                                              idProcesoProductivo:=idProcesosProductivos,
                                              idOperacion:=idOperacion,
                                              idCategoriaEmpleado:=0)
   End Function
   Public Function OrdenesProduccionMRPCategoriaE_G1(idSucursal As Integer,
                                                     idTipoComprobante As String,
                                                     letra As String,
                                                     centroEmisor As Integer,
                                                     numeroOrdenProduccion As Long,
                                                     orden As Integer,
                                                     idProducto As String,
                                                     idProcesoProductivo As Long,
                                                     idOperacion As Integer,
                                                     idCategoriaEmpleado As Integer) As DataTable
      Return OrdenesProduccionMRPCategoriaE_G(idSucursal:=idSucursal,
                                              idTipoComprobante:=idTipoComprobante,
                                              letra:=letra,
                                              centroEmisor:=centroEmisor,
                                              numeroOrdenProduccion:=
                                              numeroOrdenProduccion,
                                              orden:=orden,
                                              idProducto:=idProducto,
                                              idProcesoProductivo:=idProcesoProductivo,
                                              idOperacion:=idOperacion,
                                              idCategoriaEmpleado:=idCategoriaEmpleado)
   End Function

End Class
