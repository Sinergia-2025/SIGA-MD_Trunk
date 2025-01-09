Public Class ListasDePrecios
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ListasDePrecios_I(idListaPrecios As Integer, nombreListaPrecios As String,
                                fechaVigencia As Date, usuario As String, listaACopiar As Integer,
                                descRecarPorc As Decimal, orden As Integer, activa As Boolean,
                                nombreCortoListaPrecios As String,
                                idFormasPago As Integer,
                                publicarEnWeb As Boolean,
                                permiteUtilidadEnCero As Boolean)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO ListasDePrecios")
         .AppendFormatLine("           (IdListaPrecios")
         .AppendFormatLine("           ,NombreListaPrecios")
         .AppendFormatLine("           ,FechaVigencia")
         .AppendFormatLine("           ,DescuentoRecargoPorc")
         .AppendFormatLine("           ,Orden")
         .AppendFormatLine("           ,Activa")
         .AppendFormatLine("           ,NombreCortoListaPrecios")
         .AppendFormatLine("           ,IdFormasPago")
         .AppendFormatLine("           ,PublicarenWeb")
         .AppendFormatLine("           ,PermiteUtilidadEnCero")
         .AppendFormatLine(")")
         .AppendFormatLine("     VALUES (")
         .AppendFormatLine("             {0} ", idListaPrecios)
         .AppendFormatLine("           ,'{0}'", nombreListaPrecios)
         .AppendFormatLine("           ,'{0}'", Me.ObtenerFecha(fechaVigencia, True))
         .AppendFormatLine("           , {0} ", descRecarPorc)
         .AppendFormatLine("           , {0} ", orden)
         .AppendFormatLine("           ,'{0}'", activa)
         .AppendFormatLine("           ,'{0}'", nombreCortoListaPrecios)
         If idFormasPago > 0 Then
            .AppendFormatLine("           , {0} ", idFormasPago)
         Else
            .AppendFormatLine("           ,NULL")
         End If
         .AppendFormatLine("           ,'{0}'", publicarEnWeb)
         .AppendFormatLine("           ,'{0}'", permiteUtilidadEnCero)
         .AppendFormatLine(")")
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "ListasDePrecios")

      Dim sqlPSP = New ProductosSucursalesPrecios(Me._da)
      sqlPSP.ProductosSucursalesPrecios_IFull(idListaPrecios, usuario, listaACopiar)

   End Sub

   Public Sub ListasDePrecios_U(idListaPrecios As Integer, nombreListaPrecios As String,
                                fechaVigencia As Date, descRecarPorc As Decimal,
                                orden As Integer, activa As Boolean,
                                nombreCortoListaPrecios As String,
                                idFormasPago As Integer,
                                publicarEnWeb As Boolean,
                                permiteUtilidadEnCero As Boolean)
      Dim stb = New StringBuilder()
      With stb
         .Append("UPDATE ListasDePrecios SET ")
         .AppendFormatLine("      NombreListaPrecios = '{0}'", nombreListaPrecios)
         .AppendFormatLine("      ,FechaVigencia = '{0}'", Me.ObtenerFecha(fechaVigencia, True))
         .AppendFormatLine("      ,DescuentoRecargoPorc = {0}", descRecarPorc)
         .AppendFormatLine("      ,Orden = {0}", orden)
         .AppendFormatLine("      ,Activa = '{0}'", activa)
         .AppendFormatLine("      ,NombreCortoListaPrecios = '{0}'", nombreCortoListaPrecios)
         If idFormasPago > 0 Then
            .AppendFormatLine("      ,IdFormasPago = {0}", idFormasPago)
         Else
            .AppendFormatLine("      ,IdFormasPago = NULL")
         End If
         .AppendFormatLine("      ,PublicarEnWeb = '{0}'", publicarEnWeb)
         .AppendFormatLine("      ,PermiteUtilidadEnCero = '{0}'", permiteUtilidadEnCero)
         .AppendFormatLine(" WHERE IdListaPrecios = {0}", idListaPrecios)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "ListasDePrecios")
   End Sub

   Public Sub ListasDePrecios_D(idListaPrecios As Integer)
      Dim sqlPSP = New ProductosSucursalesPrecios(Me._da)
      sqlPSP.ProductosSucursalesPrecios_DFull(idListaPrecios)

      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM ListasDePrecios ")
         .AppendFormatLine(" WHERE IdListaPrecios = {0}", idListaPrecios)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "ListasDePrecios")
   End Sub

   Public Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT LP.*")
         .AppendFormatLine("     , FP.DescripcionFormasPago")
         .AppendFormatLine("  FROM ListasDePrecios LP")
         .AppendFormatLine("  LEFT JOIN VentasFormasPago FP ON FP.IdFormasPago = LP.IdFormasPago")
      End With
   End Sub

   Public Function ListasDePrecios_GA(activa As Boolean?, orderBy As Entidades.ListaDePrecios.Columnas) As DataTable
      Return ListasDePrecios_G(idListaPrecios:=-1, activa:=activa, nombre:=String.Empty, nombreExacto:=False, orderBy:=orderBy)
   End Function

   Public Function ListasDePrecios_G(idListaPrecios As Integer, activa As Boolean?, nombre As String, nombreExacto As Boolean, orderBy As Entidades.ListaDePrecios.Columnas) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1").AppendLine()
         If idListaPrecios > -1 Then
            .AppendFormatLine("   AND LP.IdListaPrecios = {0}", idListaPrecios)
         End If
         If activa.HasValue Then
            .AppendFormatLine("   AND Activa = {0}", GetStringFromBoolean(activa.Value))
         End If
         If Not String.IsNullOrWhiteSpace(nombre) Then
            If nombreExacto Then
               .AppendFormatLine("   AND NombreListaPrecios = '{0}'", nombre)
            Else
               .AppendFormatLine("   AND NombreListaPrecios LIKE '%{0}%'", nombre)
            End If
         End If
         .AppendFormatLine("  ORDER BY LP.{0}", orderBy.ToString()).AppendLine()
      End With

      Return Me.GetDataTable(stb)
   End Function

   Public Function ListasDePrecios_GA(nombre As String, nombreExacto As Boolean) As DataTable
      Return ListasDePrecios_G(idListaPrecios:=-1, activa:=Nothing, nombre:=nombre, nombreExacto:=nombreExacto, orderBy:=Entidades.ListaDePrecios.Columnas.NombreListaPrecios)
   End Function

   Public Function GetClientesAsociados(idLista As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT IdCliente")
         .AppendFormatLine("  FROM Clientes")
         .AppendFormatLine(" WHERE IdListaPrecios = {0}", idLista)
      End With
      Return Me.GetDataTable(stb)
   End Function

   Public Function GetProspectosAsociados(idLista As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT IdProspecto")
         .AppendFormatLine("  FROM Prospectos")
         .AppendFormatLine(" WHERE IdListaPrecios = {0}", idLista)
      End With
      Return Me.GetDataTable(stb)
   End Function

   Public Function ListasDePrecios_G1(idListaPrecios As Integer) As DataTable
      Return ListasDePrecios_G(idListaPrecios, activa:=Nothing, nombre:=String.Empty, nombreExacto:=False, orderBy:=Entidades.ListaDePrecios.Columnas.IdListaPrecios)
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("IdListaPrecios", "ListasDePrecios"))
   End Function
   Public Function ListasDePrecios_GetPorCodigo(codigo As Integer, codigoExacto As Boolean) As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         SelectTexto(query)
         .AppendFormatLine(" WHERE LP.{0} {1} {2}", Entidades.ListaDePrecios.Columnas.IdListaPrecios.ToString(), If(codigoExacto, "=", "LIKE"), codigo)
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "LP.",
                    New Dictionary(Of String, String) From {{"DescripcionFormasPago", "FP.DescripcionFormasPago"}})
   End Function

   Public Function ListasDePrecios_GetPedidosPorListaDePrecios(idListaDePrecio As Integer) As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine(" SELECT PP.IdListaPrecios, PE.IdEstado, * FROM PedidosProductos PP ")

         .AppendFormatLine(" INNER JOIN PedidosEstados PE")
         .AppendFormatLine("       ON PP.IdSucursal= PE.IdSucursal")
         .AppendFormatLine("      AND PP.NumeroPedido = PE.NumeroPedido")
         .AppendFormatLine("      AND PP.IdProducto = PE.IdProducto")
         .AppendFormatLine("      AND PP.Orden = PE.Orden")
         .AppendFormatLine("      AND PP.IdTipoComprobante = PE.IdTipoComprobante")
         .AppendFormatLine("      AND PP.letra = PE.letra")
         .AppendFormatLine("      AND PP.CentroEmisor = PE.CentroEmisor")

         .AppendFormatLine(" INNER JOIN EstadosPedidos EP ON EP.idEstado = PE.IdEstado ")

         .AppendFormatLine(" WHERE EP.IdTipoEstado IN ('PENDIENTE', 'EN PROCESO') ")
         .AppendFormatLine("    AND PP.IdListaPrecios = {0}", idListaDePrecio)
      End With
      Return Me.GetDataTable(query.ToString())
   End Function
End Class