Public Class VentasFormasPagoSucursales
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasFormasPagoSucursales_I(idSucursal As Integer,
                                           idFormaPago As Integer)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("INSERT INTO {0}(", Entidades.VentasFormasPagoSucursales.NombreTabla)
         .AppendFormatLine("{0}, {1}", Entidades.VentasFormasPagoSucursales.Columnas.IdSucursal.ToString(),
                                       Entidades.VentasFormasPagoSucursales.Columnas.IdFormasPago.ToString())
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("{0},", idSucursal)
         .AppendFormatLine("{0}", idFormaPago)
         .AppendLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub VentasFormasPagoSucursales_U(idSucursal As Integer,
                                           idFormaPago As Integer)

      '#############################################
      '# Éste método por ahora no se va a utilizar #
      '#############################################

   End Sub

   Public Sub VentasFormasPagoSucursales_D(idSucursal As Integer,
                                          idFormasPago As Integer)

      '#############################################
      '# Éste método por ahora no se va a utilizar #
      '#############################################

   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT VFPS.{0}", Entidades.VentasFormasPagoSucursales.Columnas.IdSucursal.ToString())
         .AppendFormatLine("      ,VFPS.{0}", Entidades.VentasFormasPagoSucursales.Columnas.IdFormasPago.ToString())
         .AppendFormatLine("      ,S.{0}", Entidades.Sucursal.Columnas.Nombre.ToString())
         .AppendFormatLine("      ,FP.{0}", Entidades.VentaFormaPago.Columnas.DescripcionFormasPago.ToString())
         .AppendFormatLine("      ,FP.{0}", Entidades.VentaFormaPago.Columnas.OrdenVentas.ToString())
         .AppendFormatLine("      ,FP.{0}", Entidades.VentaFormaPago.Columnas.OrdenCompras.ToString())
         .AppendFormatLine("      ,FP.{0}", Entidades.VentaFormaPago.Columnas.OrdenFichas.ToString())
         .AppendFormatLine("FROM {0} VFPS", Entidades.VentasFormasPagoSucursales.NombreTabla)
         .AppendFormatLine("LEFT JOIN {0} S ON VFPS.{1} = S.{1}", Entidades.Sucursal.NombreTabla, Entidades.VentasFormasPagoSucursales.Columnas.IdSucursal.ToString())
         .AppendFormatLine("LEFT JOIN {0} FP ON VFPS.{1} = FP.{1}", Entidades.VentaFormaPago.NombreTabla, Entidades.VentasFormasPagoSucursales.Columnas.IdFormasPago.ToString())
         .AppendLine(" WHERE 1=1")
      End With
   End Sub

   Public Function VentasFormasPagoSucursales_GA(idSucursal As Integer?) As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         SelectTexto(query)

         '# Filto por Sucursal
         If idSucursal.HasValue Then
            .AppendFormatLine("  AND VFPS.{0} = {1}", Entidades.VentasFormasPagoSucursales.Columnas.IdSucursal.ToString(), idSucursal.Value)
         End If

         .AppendFormatLine(" ORDER BY FP.{0}", Entidades.VentaFormaPago.Columnas.DescripcionFormasPago.ToString())
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function VentasFormasPagoSucursales_G1(idSucursal As Integer,
                                                idFormaPago As Integer) As DataTable

      '#############################################
      '# Éste método por ahora no se va a utilizar #
      '#############################################

      Return Nothing
   End Function

   Public Sub BorrarTodas(valor As Integer, esIdFormaDePago As Boolean)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE {0}", Entidades.VentasFormasPagoSucursales.NombreTabla)

         '# Si esIdFormaDePago, borro todos los registros que tengan IdFormasPago = el valor recibido por parámetro
         '# Si NO esIdFormaDePago, borro todos los registros que tengan IdSucursal = el valor recibido por parámetro
         .AppendFormatLine("     WHERE {0} = {1}", If(esIdFormaDePago,
                                                      Entidades.VentasFormasPagoSucursales.Columnas.IdFormasPago.ToString(),
                                                      Entidades.VentasFormasPagoSucursales.Columnas.IdSucursal.ToString()), valor)
      End With
      Me.Execute(query.ToString())
   End Sub

   Public Sub VincularTodas(idFormasPago As Integer)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("INSERT INTO {0}({1},{2})",
                           Entidades.VentasFormasPagoSucursales.NombreTabla,
                           Entidades.VentasFormasPagoSucursales.Columnas.IdSucursal,
                           Entidades.VentasFormasPagoSucursales.Columnas.IdFormasPago.ToString())
         .AppendFormatLine("SELECT {0},{1} FROM {2}",
                           Entidades.VentasFormasPagoSucursales.Columnas.IdSucursal.ToString(),
                           idFormasPago,
                           Entidades.Sucursal.NombreTabla)
      End With
      Me.Execute(query.ToString())
   End Sub
End Class
