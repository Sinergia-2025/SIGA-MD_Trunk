Public Class RepartosProductosSinDescargar
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
   Public Sub RepartosProductosSinDescargar_I(idSucursal As Integer,
                                              numeroReparto As Integer,
                                              idProducto As String,
                                              cantidad As Decimal,
                                              precio As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.RepartoProductoSinDescargar.NombreTabla).AppendLine()
         .AppendFormatLine("           ({0}, {1}, {2}, {3}, {4})",
                           Entidades.RepartoProductoSinDescargar.Columnas.IdSucursal.ToString(),
                           Entidades.RepartoProductoSinDescargar.Columnas.IdReparto.ToString(),
                           Entidades.RepartoProductoSinDescargar.Columnas.IdProducto.ToString(),
                           Entidades.RepartoProductoSinDescargar.Columnas.Cantidad.ToString(),
                           Entidades.RepartoProductoSinDescargar.Columnas.Precio.ToString())
         .AppendFormatLine("    VALUES ({0}, {1}, '{2}', {3}, {4}",
                       idSucursal, numeroReparto, idProducto, cantidad, precio)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub RepartosProductosSinDescargar_U(idSucursal As Integer,
                                              idReparto As Integer,
                                              idProducto As String,
                                              cantidad As Decimal,
                                              precio As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.MovilRuta.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.RepartoProductoSinDescargar.Columnas.Cantidad.ToString(), cantidad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.RepartoProductoSinDescargar.Columnas.Precio.ToString(), precio)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoProductoSinDescargar.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoProductoSinDescargar.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoProductoSinDescargar.Columnas.IdProducto.ToString(), idProducto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosProductosSinDescargar_D(idSucursal As Integer,
                                              idReparto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0} ", Entidades.RepartoProductoSinDescargar.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.RepartoProductoSinDescargar.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.RepartoProductoSinDescargar.Columnas.IdReparto.ToString(), idReparto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub RepartosProductosSinDescargar_M(idSucursal As Integer,
                                              idReparto As Integer,
                                              idProducto As String,
                                              cantidad As Decimal,
                                              precio As Decimal)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("MERGE INTO {0} DEST", Entidades.RepartoProductoSinDescargar.NombreTabla)
         .AppendFormatLine("        USING (SELECT  {1}  AS {0}", Entidades.RepartoProductoSinDescargar.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.RepartoProductoSinDescargar.Columnas.IdReparto.ToString(), idReparto)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.RepartoProductoSinDescargar.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.RepartoProductoSinDescargar.Columnas.Cantidad.ToString(), cantidad)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.RepartoProductoSinDescargar.Columnas.Precio.ToString(), precio)
         .AppendFormatLine("              ) AS ORIG ON ORIG.{0} = DEST.{0} AND ORIG.{1} = DEST.{1} AND ORIG.{2} = DEST.{2}",
                           Entidades.RepartoProductoSinDescargar.Columnas.IdSucursal.ToString(),
                           Entidades.RepartoProductoSinDescargar.Columnas.IdReparto.ToString(),
                           Entidades.RepartoProductoSinDescargar.Columnas.IdProducto.ToString())
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET DEST.{0} = DEST.{0} + ORIG.{0}, DEST.{1} = ORIG.{1}",
                           Entidades.RepartoProductoSinDescargar.Columnas.Cantidad.ToString(),
                           Entidades.RepartoProductoSinDescargar.Columnas.Precio.ToString())
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT ({0}, {1}, {2}, {3}, {4}) VALUES (ORIG.{0}, ORIG.{1}, ORIG.{2}, ORIG.{3}, ORIG.{4})",
                           Entidades.RepartoProductoSinDescargar.Columnas.IdSucursal.ToString(),
                           Entidades.RepartoProductoSinDescargar.Columnas.IdReparto.ToString(),
                           Entidades.RepartoProductoSinDescargar.Columnas.IdProducto.ToString(),
                           Entidades.RepartoProductoSinDescargar.Columnas.Cantidad.ToString(),
                           Entidades.RepartoProductoSinDescargar.Columnas.Precio.ToString())
         .AppendFormatLine(";")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Function GetRepartosProductosSinDescargar(idSucursal As Integer, idReparto As Integer, idProducto As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendLine("SELECT   RPSD.IdSucursal")
         .AppendLine("        ,RPSD.IdReparto")
         .AppendLine("        ,RPSD.IdProducto")
         .AppendLine("        ,P.NombreProducto")
         .AppendLine("        ,RPSD.Cantidad")
         .AppendLine("        ,RPSD.Precio")
         .AppendLine(" FROM RepartosProductosSinDescargar AS RPSD")
         .AppendLine(" INNER JOIN Productos P On P.IdProducto=RPSD.IdProducto")
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.Reparto.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.Reparto.Columnas.IdReparto.ToString(), idReparto)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.RepartoProductoSinDescargar.Columnas.IdProducto.ToString(), idProducto)
         End If

      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class