Option Explicit On
Option Strict On

Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Reglas
Imports Eniac.Entidades

Public Class Fichas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Fichas"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos"

#Region "Públicos"

   Public Function GetPendientesDePago(ByVal IdCliente As Long, ByVal idSucursal As Integer, ByVal todas As Boolean) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append(" SELECT F.NroOperacion, ")
         .Append(" F.FechaOperacion, ")
         .Append(" F.Saldo, ")
         .Append(" F.IdEstado, ")
         .Append(" (SELECT  MAX(P.NombreProducto) FROM FichasProductos FP ")
         .Append(" 	LEFT JOIN Productos P ON P.IdProducto = FP.IdProducto ")
         .Append(" 	WHERE FP.IdCliente = " & IdCliente.ToString())
         .Append(" 	AND FP.IdSucursal = " & idSucursal.ToString())
         .Append(" 	AND FP.NroOperacion = F.NroOperacion) Producto ")
         .Append(" FROM Fichas F ")
         .Append(" WHERE F.IdCliente = " & IdCliente.ToString())
         .Append(" AND F.IdSucursal = " & idSucursal.ToString())
         If Not todas Then
            .Append(" AND F.IdEstado <> 'INACTIVO' ")
            .Append(" AND F.Saldo <> 0")
         End If
      End With
      Return Me.DataServer().GetDataTable(stbQuery.ToString())
   End Function

   Public Function GetTodas(ByVal IdCliente As Long, ByVal idSucursal As Integer) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append(" SELECT F.*, C.NombreEmpleado NombreCobrador, E.NombreEmpleado NombreVendedor ")
         .Append(" FROM Fichas F ")
         .Append(" LEFT JOIN Empleados C ON F.IdCobrador = C.IdEmpleado ")
         .Append(" LEFT JOIN Empleados E ON F.IdVendedor = E.IdEmpleado ")
         .Append(" WHERE F.IdCliente = " & IdCliente.ToString())
         .Append(" AND F.IdSucursal = " & idSucursal.ToString())
      End With
      Return Me.DataServer().GetDataTable(stbQuery.ToString())
   End Function

   Public Function GetProximoNroOperacionDelCliente(ByVal IdCliente As Long, ByVal idSucursal As Integer) As Integer
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append(" SELECT MAX(NroOperacion)+1 as NroOperacion FROM Fichas F  ")
         .Append(" WHERE F.IdCliente = " & IdCliente.ToString())
         .Append(" AND F.IdSucursal = " & idSucursal.ToString())
      End With
      Dim dt As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())
      If dt.Rows.Count > 0 Then
         If Not dt.Rows(0)("NroOperacion") Is System.DBNull.Value Then
            Return Integer.Parse(dt.Rows(0)("NroOperacion").ToString())
         End If
      End If
      Return 1
   End Function
   Public Function GetUna(ByVal IdCliente As Long, ByVal nroOperacion As Integer, ByVal idSucursal As Integer) As Eniac.Entidades.Ficha
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append(" SELECT F.*, C.NombreEmpleado NombreCobrador, E.NombreEmpleado NombreVendedor ")
         .Append(" FROM Fichas F ")
         .Append(" LEFT JOIN Empleados C ON F.IdCobrador = C.IdEmpleado ")
         .Append(" LEFT JOIN Empleados E ON F.IdVendedor = E.IdEmpleado ")
         .Append(" WHERE	F.NroOperacion = " & nroOperacion)
         .Append(" AND F.IdCliente = " & IdCliente.ToString())
         .Append(" AND F.IdSucursal = " & idSucursal.ToString())
      End With
      Dim dtFicha As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())

      With stbQuery
         .Length = 0
         .Append(" SELECT FP.*, P.NombreProducto, PV.NombreProveedor ")
         .Append(" FROM FichasProductos FP ")
         .Append(" LEFT JOIN Productos P ON P.IdProducto = FP.IdProducto ")
         .Append(" LEFT JOIN Proveedores PV ON PV.IdProveedor = FP.IdProveedor ")
         .Append(" WHERE	FP.NroOperacion = " & nroOperacion)
         .Append(" AND		FP.IdCliente = " & IdCliente.ToString())
         .Append(" AND		FP.IdSucursal = " & idSucursal & " ")
      End With

      Dim dtFichasProductos As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())

      With stbQuery
         .Length = 0
         .Append(" SELECT FP.* ")
         .Append(" FROM FichasPagos FP ")
         .Append(" WHERE	FP.NroOperacion = " & nroOperacion)
         .Append(" AND		FP.IdCliente = " & IdCliente.ToString())
         .Append(" AND		FP.IdSucursal = " & idSucursal & " ")
      End With

      Dim dtFichasPagos As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())

      With stbQuery
         .Length = 0
         .Append(" SELECT FP.*, E.NombreEmpleado NombreCobrador ")
         .Append(" FROM FichasPagosDetalle FP ")
         .Append(" LEFT JOIN Empleados E ON FP.IdCobrador = E.IdEmpleado ")
         .Append(" WHERE	FP.NroOperacion = " & nroOperacion)
         .Append(" AND		FP.IdCliente = " & IdCliente.ToString())
         .Append(" AND		FP.IdSucursal = " & idSucursal & " ")
      End With

      Dim dtFichasPagosDetalle As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())

      'Carga la ficha para enviar a la IU
      Dim oFicha As Eniac.Entidades.Ficha = New Eniac.Entidades.Ficha(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
      Dim oFichaProducto As Eniac.Entidades.FichaProducto
      Dim oFichaPago As Eniac.Entidades.FichaPago
      Dim oFichaPagoDetalle As Eniac.Entidades.FichaPagoDetalle
      With oFicha
         .FechaOperacion = DateTime.Parse(dtFicha.Rows(0)("FechaOperacion").ToString())
         .IdCliente = Long.Parse(dtFicha.Rows(0)("IdCliente").ToString())
         .NroOperacion = Integer.Parse(dtFicha.Rows(0)("NroOperacion").ToString())
         .MontoTotalBruto = Decimal.Parse(dtFicha.Rows(0)("MontoTotalBruto").ToString())
         .Comentario = dtFicha.Rows(0)("Comentario").ToString()
         .Anticipo = Decimal.Parse(dtFicha.Rows(0)("Anticipo").ToString())
         .IdCobrador = Integer.Parse(dtFicha.Rows(0)("IdCobrador").ToString())
         .NombreCobrador = dtFicha.Rows(0)("NombreCobrador").ToString()
         .IdVendedor = Integer.Parse(dtFicha.Rows(0)("IdVendedor").ToString())
         .NombreVendedor = dtFicha.Rows(0)("NombreVendedor").ToString()
         .Cuotas = Integer.Parse(dtFicha.Rows(0)("Cuotas").ToString())
         .IdFormasPago = Integer.Parse(dtFicha.Rows(0)("IdFormasPago").ToString())
         .Interes = Decimal.Parse(dtFicha.Rows(0)("Interes").ToString())
         .TotalNeto = Decimal.Parse(dtFicha.Rows(0)("TotalNeto").ToString())
         .Saldo = Decimal.Parse(dtFicha.Rows(0)("Saldo").ToString())
         .IdEstado = dtFicha.Rows(0)("IdEstado").ToString()
         .Usuario = dtFicha.Rows(0)("Usuario").ToString()
      End With
      For Each dr As DataRow In dtFichasProductos.Rows
         oFichaProducto = New Eniac.Entidades.FichaProducto(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
         With oFichaProducto
            .NroOperacion = Integer.Parse(dr("NroOperacion").ToString())
            .IdCliente = Long.Parse(dr("IdCliente").ToString())
            .IdProducto = dr("IdProducto").ToString().Trim()
            .Cantidad = Integer.Parse(dr("Cantidad").ToString())
            .Precio = Decimal.Parse(dr("Precio").ToString())
            If Not dr("FechaEntrega") Is System.DBNull.Value Then
               .FechaEntrega = DateTime.Parse(dr("FechaEntrega").ToString())
            End If
            If Not dr("Garantia") Is System.DBNull.Value Then
               .Garantia = Integer.Parse(dr("Garantia").ToString())
            End If
            If Not dr("IdProveedor") Is System.DBNull.Value Then
               .Proveedor = New Proveedores()._GetUno(Long.Parse(dr("IdProveedor").ToString()))
            End If
            .ProductoDesc = dr("NombreProducto").ToString()
         End With
         oFicha.Productos.Add(oFichaProducto)
      Next
      For Each dr As DataRow In dtFichasPagos.Rows
         oFichaPago = New Eniac.Entidades.FichaPago(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
         With oFichaPago
            .NroOperacion = Integer.Parse(dr("NroOperacion").ToString())
            .IdCliente = Long.Parse(dr("IdCliente").ToString())
            .NroCuota = Integer.Parse(dr("NroCuota").ToString())
            .FechaVencimiento = DateTime.Parse(dr("FechaVencimiento").ToString())
            .Importe = Decimal.Parse(dr("Importe").ToString())
            .Saldo = Decimal.Parse(dr("Saldo").ToString())
         End With
         oFicha.Pagos.Add(oFichaPago)
      Next
      For Each dr As DataRow In dtFichasPagosDetalle.Rows
         oFichaPagoDetalle = New Eniac.Entidades.FichaPagoDetalle(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
         With oFichaPagoDetalle
            .NroOperacion = Integer.Parse(dr("NroOperacion").ToString())
            .IdCliente = Long.Parse(dr("IdCliente").ToString())
            .FechaPago = DateTime.Parse(dr("FechaPago").ToString())
            .Importe = Decimal.Parse(dr("Importe").ToString())
            .IdCobrador = Integer.Parse(dr("IdCobrador").ToString())
            .NroCuota = Integer.Parse(dr("NroCuota").ToString())
            .NombreCobrador = dr("NombreCobrador").ToString()
            .IdCaja = Integer.Parse(dr("IdCaja").ToString())
            .NumeroPlanilla = Integer.Parse(dr("NumeroPlanilla").ToString())
            .NumeroMovimiento = Integer.Parse(dr("NumeroMovimiento").ToString())
         End With
         oFicha.PagosDetalle.Add(oFichaPagoDetalle)
      Next
      Return oFicha
   End Function
   Public Sub ActualizarEstado(ByVal ficha As Eniac.Entidades.Ficha)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim oFichasProd As Reglas.FichasProductos = New Reglas.FichasProductos(da)
         Dim oPro As ProductosSucursales = New ProductosSucursales(da)

         Me.ActualizaEstado(ficha.IdSucursal, ficha.NroOperacion, ficha.IdCliente, ficha.IdEstado)

         ficha.Productos = oFichasProd.GetUna(ficha.IdSucursal, ficha.NroOperacion, ficha.IdCliente)

         Dim oMov = New MovimientosStock(da)

         'graba el movimiento de stock
         oMov.CargarMovimientoStock(Me.GetMovimientoVenta(ficha, True), Entidad.MetodoGrabacion.Automatico, "")

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Function HayQueRevisar(ByVal ficha As Eniac.Entidades.Ficha) As Boolean
      Dim stb As StringBuilder = New StringBuilder("")
      Try
         With stb
            .Append(" SELECT Revisar ")
            .Append(" FROM Fichas ")
            .Append(" WHERE NroOperacion = ")
            .Append(ficha.NroOperacion.ToString())
            .Append(" AND IdCliente = " & ficha.IdCliente.ToString())
            .Append(" AND IdSucursal = " & ficha.IdSucursal & "")
         End With
         Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())
         If dt.Rows.Count > 0 Then
            If String.IsNullOrEmpty(dt.Rows(0)("Revisar").ToString()) Then
               Return False
            Else
               Return True
            End If
         Else
            Return False
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function GetCartasEmitidas(ByVal ficha As Eniac.Entidades.Ficha) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      Try
         With stb
            .Append(" select CC.TipoCarta, CC.FechaEnvio, CC.IdClienteGarante, C.NombreCliente AS NombreGarante,")
            .Append(" CC.Usuario ,C.TipoDocCliente as TipoDocumentoGarante, C.NroDocCliente as NroDocumentoGarante")
            .Append(" from CartasAClientes CC ")
            .Append(" left join Clientes C on CC.IdClienteGarante = C.IdCliente ")
            .Append(" where CC.idSucursal = " & ficha.IdSucursal.ToString() & " ")
            .Append(" and CC.IdCliente = " & ficha.IdCliente.ToString())
            .Append(" and CC.NroOperacion =" & ficha.NroOperacion.ToString() & "")
            .Append(" order by CC.FechaEnvio desc")
         End With
         Return Me.da.GetDataTable(stb.ToString())
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Sub ActualizarRevisar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim ficha As Eniac.Entidades.Ficha = DirectCast(entidad, Eniac.Entidades.Ficha)
      Dim stb As StringBuilder = New StringBuilder("")
      Try
         With stb
            .Append(" UPDATE Fichas ")
            .Append(" SET Revisar = NULL ")
            .Append(" WHERE NroOperacion = ")
            .Append(ficha.NroOperacion.ToString())
            .Append(" AND IdCliente = " & ficha.IdCliente.ToString())
            .Append(" AND IdSucursal = " & ficha.IdSucursal & "")
         End With
         Me.DataServer().GetDataTable(stb.ToString())
      Catch ex As Exception
         Throw ex
      End Try

   End Sub

   Public Sub ActualizarFichaACliente(ByVal fichaOrigen As Eniac.Entidades.Ficha, ByVal fichaDestino As Eniac.Entidades.Ficha)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim oFPro As Reglas.FichasProductos = New Reglas.FichasProductos(da)
         Dim oFPDs As System.Collections.Generic.List(Of Eniac.Entidades.FichaPagoDetalle)
         Dim oFPa As Reglas.FichasPagos = New Reglas.FichasPagos(da)
         Dim oPro As Productos = New Productos(da)
         Dim oFPDet As Reglas.FichasPagosDetalle = New Reglas.FichasPagosDetalle(da)
         Dim lngIdCliente As Long
         Dim nroOper As Integer

         fichaOrigen = Me.GetUna(fichaOrigen.IdCliente, fichaOrigen.NroOperacion, fichaOrigen.IdSucursal)
         nroOper = Me.GetProximoNroOperacionDelCliente(fichaDestino.IdCliente, fichaOrigen.IdSucursal)

         oFPDs = oFPDet.GetUnaOperacionCompleta(fichaOrigen.IdSucursal, fichaOrigen.IdCliente, fichaOrigen.NroOperacion)

         'eliminar la ficha existente
         For Each fpd As Eniac.Entidades.FichaPagoDetalle In oFPDs
            oFPDet.BorraFichaPagosDetalle(fpd)
         Next

         For Each prod As Eniac.Entidades.FichaProducto In fichaOrigen.Productos
            oFPro.BorraFichaProductos(prod)
         Next

         For Each pago As Eniac.Entidades.FichaPago In fichaOrigen.Pagos
            oFPa.BorraFichaPagos(pago)
         Next

         Me.BorraFicha(fichaOrigen)

         'cargar la ficha nueva
         lngIdCliente = fichaDestino.IdCliente

         fichaOrigen.NroOperacion = nroOper
         fichaOrigen.IdCliente = lngIdCliente
         Me.GrabaFicha(fichaOrigen)

         For Each prod As Eniac.Entidades.FichaProducto In fichaOrigen.Productos
            prod.NroOperacion = nroOper
            prod.IdCliente = lngIdCliente
            oFPro.GrabaFichaProductos(prod)
         Next

         For Each pago As Eniac.Entidades.FichaPago In fichaOrigen.Pagos
            pago.NroOperacion = nroOper
            pago.IdCliente = lngIdCliente
            oFPa.GrabaFichaPagos(pago)
         Next

         For Each fpd As Eniac.Entidades.FichaPagoDetalle In oFPDs
            fpd.NroOperacion = nroOper
            fpd.IdCliente = lngIdCliente
            oFPDet.GrabaFichaPagosDetalle(fpd)
         Next

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Function GetEmitidas(ByVal idSucursal As Integer, ByVal fechaDesde As DateTime, ByVal fechaHasta As DateTime, ByVal IdCob As Integer, ByVal IdVen As Integer, ByVal verAnuladas As Boolean) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append(" SELECT F.FechaOperacion, F.IdCliente, ")
         .Append(" 		F.NroOperacion, C.NombreCliente, F.MontoTotalBruto, ")
         .Append(" 		F.Anticipo, F.Interes, F.TotalNeto, F.Usuario, F.idEstado ")
         .Append(" FROM Fichas F ")
         .Append(" INNER JOIN Clientes C ON F.IdCliente = C.IdCliente ")
         .Append(" WHERE F.FechaOperacion >= '")
         .Append(fechaDesde.ToString("yyyyMMdd") & " 00:00:00")
         .Append("' AND F.FechaOperacion <= '")
         .Append(fechaHasta.ToString("yyyyMMdd") & " 23:59:59")
         .Append("' ")
         .Append(" 	AND F.IdSucursal = " & idSucursal)
         If Not verAnuladas Then
            .Append(" AND F.IdEstado = 'ACTIVO' ")
         End If
         If IdCob > 0 Then
            .Append(" AND F.IdCobrador = '")
            .Append(IdCob)
            .Append("' ")
         End If
         If IdVen > 0 Then
            .Append(" AND F.IdVendedor = '")
            .Append(IdVen)
            .Append("' ")
         End If
         .Append(" ORDER BY F.FechaOperacion ")
      End With
      Return Me.DataServer().GetDataTable(stbQuery.ToString())
   End Function

   Public Function GetIngresosPorFichas(ByVal idSucursal As Integer, ByVal fechaDesde As DateTime, ByVal fechaHasta As DateTime, ByVal IdCob As Integer) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Length = 0
         .AppendLine("(SELECT F.FechaOperacion Fecha, F.IdCliente, F.NroOperacion, C.NombreCliente, 'Anticipo' Tipo, F.Anticipo Importe ")
         .AppendLine("   FROM Fichas F ")
         .AppendLine("   LEFT JOIN Clientes C ON C.IdCliente = F.IdCliente ")
         .AppendLine("  WHERE F.Anticipo <> 0 ")
         .AppendLine("    AND F.IdEstado = 'ACTIVO' ")
         .AppendLine(" 	  AND F.IdSucursal = " & idSucursal.ToString())
         .AppendLine("    AND F.FechaOperacion >= '" & fechaDesde.ToString("yyyyMMdd") & " 00:00:00'")
         .AppendLine("    AND F.FechaOperacion <= '" & fechaHasta.ToString("yyyyMMdd") & " 23:59:59'")
         If IdCob > 0 Then
            .AppendLine("    AND F.IdCobrador = " & IdCob)
         End If
         .AppendLine(" UNION ")
         .AppendLine("SELECT FPD.FechaPago Fecha, FPD.IdCliente, FPD.NroOperacion, C.NombreCliente, 'Cuota ' + right(str(FPD.NroCuota), 3) Tipo, FPD.Importe Importe ")
         .AppendLine("  FROM FichasPagosDetalle FPD ")
         .AppendLine("  LEFT JOIN Clientes C ON C.IdCliente = FPD.IdCliente ")
         .AppendLine(" WHERE FPD.Importe <> 0 ")
         .AppendLine(" 	 AND FPD.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND FPD.FechaPago >= '" & fechaDesde.ToString("yyyyMMdd") & " 00:00:00'")
         .AppendLine("   AND FPD.FechaPago <= '" & fechaHasta.ToString("yyyyMMdd") & " 23:59:59'")
         If IdCob > 0 Then
            .AppendLine("    AND FPD.IdCobrador = " & IdCob)
         End If
         .AppendLine(" ) ORDER BY Fecha, C.NombreCliente ")
      End With
      Return Me.DataServer().GetDataTable(stbQuery.ToString())
   End Function

   Public Sub ActualizarComentario(ByVal ficha As Eniac.Entidades.Ficha)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Fichas = New SqlServer.Fichas(Me.da)

         sql.Fichas_UComentario(ficha.IdSucursal, ficha.NroOperacion, ficha.IdCliente, ficha.Comentario)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Function GetOperaciones(ByVal idSucursal As Integer, ByVal IdCliente As Long, ByVal ConSaldo As Boolean) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .Append("SELECT F.NroOperacion")
         .Append("  FROM Fichas F ")
         .Append(" WHERE F.IdSucursal = " & idSucursal.ToString())
         .Append("   AND F.IdCliente = " & IdCliente.tostring())
         If ConSaldo Then
            .Append("   AND F.Saldo>0")
         End If
         .Append("   AND IdEstado='ACTIVO'")
      End With

      Return Me.DataServer().GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetOperacionesConSaldo(ByVal idSucursal As Integer, ByVal IdCliente As Long) As Date

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine("SELECT F.NroOperacion, F.FechaOperacion")
         .AppendLine("  FROM Fichas F ")
         .AppendLine(" WHERE F.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND F.IdCliente = " & IdCliente.ToString())
         .AppendLine("   AND F.Saldo > 0")
         .AppendLine(" ORDER BY F.FechaOperacion")
      End With

      Dim dt As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())

      If dt.Rows.Count > 0 Then
         Return Date.Parse(dt.Rows(0)("FechaOperacion").ToString())
      Else
         Return Date.Now
      End If

   End Function

#End Region

#Region "Privados"

   Private Sub GrabaFicha(ByVal ent As Eniac.Entidades.Ficha)
      Try

         Dim sql As SqlServer.Fichas = New SqlServer.Fichas(Me.da)
         sql.Fichas_I(ent.IdSucursal, ent.NroOperacion, ent.IdCliente, ent.FechaOperacion, _
               ent.MontoTotalBruto, ent.Anticipo, ent.Cuotas, ent.IdFormasPago, ent.Interes, ent.TotalNeto, _
               ent.Saldo, ent.IdCobrador, ent.IdEstado, ent.NroFactura, ent.Comentario, _
               ent.IdVendedor, ent.Usuario)

      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Private Function GetMovimientoVenta(ByVal ficha As Ficha, ByVal esUnaAnulacion As Boolean) As MovimientoStock
      Dim mo = New MovimientoStock()

      mo.TipoMovimiento = New TiposMovimientos(da).GetUno("VENTA")
      If esUnaAnulacion Then
         mo.TipoMovimiento.CoeficienteStock = mo.TipoMovimiento.CoeficienteStock * -1
      End If
      mo.Sucursal = New Sucursales(da).GetUna(ficha.IdSucursal, False)
      mo.FechaMovimiento = ficha.FechaOperacion
      mo.Neto = ficha.TotalNeto
      mo.Total = ficha.TotalNeto
      mo.Cliente = New Clientes(da)._GetUno(ficha.IdCliente)
      mo.Venta.TipoComprobante = New TiposComprobantes(da).GetUno("FICHAS")
      mo.Venta.Impresora.CentroEmisor = 0
      mo.Venta.NumeroComprobante = ficha.NroOperacion
      mo.Usuario = ficha.Usuario

      Dim pr As MovimientoStockProducto
      For Each fi As Eniac.Entidades.FichaProducto In ficha.Productos
         pr = New MovimientoStockProducto()
         pr.MovimientoStock = mo
         pr.ProductoSucursal = New ProductosSucursales(da)._GetUno(fi.IdSucursal, fi.IdProducto.Trim())
         pr.Cantidad = fi.Cantidad
         pr.Cantidad2 = 0
         pr.Precio = fi.Precio
         mo.Productos.Add(pr)
      Next

      Return mo
   End Function

#End Region

#Region "Friend"

   Friend Sub ActualizaEstado(ByVal idSucursal As Int32, ByVal nroOperacion As Integer, ByVal IdCliente As Long, ByVal idEstado As String)
      Dim sql As SqlServer.Fichas = New SqlServer.Fichas(Me.da)
      sql.Fichas_UEstado(idSucursal, nroOperacion, IdCliente, idEstado)
   End Sub

   Friend Sub ActualizaSaldo(ByVal idSucursal As Int32, ByVal nroOperacion As Integer, ByVal IdCliente As Long, ByVal saldo As Decimal)
      Dim sql As SqlServer.Fichas = New SqlServer.Fichas(Me.da)
      sql.Fichas_USaldo(idSucursal, nroOperacion, IdCliente, saldo)
   End Sub

   Friend Sub BorraFicha(ByVal ficha As Eniac.Entidades.Ficha)
      Dim sql As SqlServer.Fichas = New SqlServer.Fichas(Me.da)
      sql.Fichas_D(ficha.IdSucursal, ficha.NroOperacion, ficha.IdCliente)
   End Sub

#End Region

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim ficha As Eniac.Entidades.Ficha = DirectCast(entidad, Eniac.Entidades.Ficha)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim oFPro As Reglas.FichasProductos = New Reglas.FichasProductos(da)
         Dim oFPa As Reglas.FichasPagos = New Reglas.FichasPagos(da)
         Dim oPro As ProductosSucursales = New ProductosSucursales(da)
         Dim oMov = New MovimientosStock(da)
         Dim oCaj As Eniac.Reglas.Cajas = New Eniac.Reglas.Cajas(da)

         If ficha.EsNueva Then
            'graba la cabecera de la ficha
            Me.GrabaFicha(ficha)
            'inserta todos los productos de la ficha
            For Each prod As Eniac.Entidades.FichaProducto In ficha.Productos
               oFPro.GrabaFichaProductos(prod)
               'oPro.ActualizarStock(prod.IdProducto, prod.IdSucursal, -prod.Cantidad)
            Next
            'graba todos las cuotas de pagos
            For Each pago As Eniac.Entidades.FichaPago In ficha.Pagos
               oFPa.GrabaFichaPagos(pago)
            Next
            'graba el movimiento de stock
            oMov.CargarMovimientoStock(Me.GetMovimientoVenta(ficha, False), Entidad.MetodoGrabacion.Automatico, "")

            'inserta en la caja si el anticipo tiene monto
            If ficha.Anticipo > 0 Then
               'si el cliente compro el modulo de caja
               If Boolean.Parse(New Eniac.Reglas.Parametros(Me.da)._GetValor(Parametro.Parametros.MODULOCAJA)) Then
                  Dim deta As Eniac.Entidades.CajaDetalles = New Eniac.Entidades.CajaDetalles(ficha.IdSucursal, ficha.Usuario, ficha.Password)
                  Dim caj As Eniac.Reglas.Cajas = New Eniac.Reglas.Cajas(da)
                  Dim cajaDet As Eniac.Reglas.CajaDetalles = New Eniac.Reglas.CajaDetalles(da)

                  With deta
                     .IdSucursal = ficha.IdSucursal
                     .IdCaja = ficha.IdCaja
                     .FechaMovimiento = ficha.FechaOperacion   'DateTime.Now
                     .IdTipoMovimiento = "I"c
                     .NumeroPlanilla = caj.GetPlanillaActual(ficha.IdSucursal, ficha.IdCaja).NumeroPlanilla
                     .ImportePesos = ficha.Anticipo
                     .Observacion = "Anticipo Ficha" + " - " + ficha.NroOperacion.ToString()
                     'seteo siempre la cuenta nro. 1 para este tipo de valores
                     .IdCuentaCaja = 1
                     .Usuario = actual.Nombre
                  End With

                  cajaDet.AgregaMovimiento(deta, Nothing, Nothing)
               End If


            End If
         Else
            Me.Actualizar(ficha)
         End If

         da.CommitTransaction()

      Catch ex As Exception

         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

End Class