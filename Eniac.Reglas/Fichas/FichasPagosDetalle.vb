Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class FichasPagosDetalle
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "FichasPagosDetalle"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim pago As Eniac.Entidades.FichaPagoDetalle = DirectCast(entidad, Eniac.Entidades.FichaPagoDetalle)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.ActualizaSaldos(pago)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim pago As Eniac.Entidades.FichaPagoDetalle = DirectCast(entidad, Eniac.Entidades.FichaPagoDetalle)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.ActualizaSaldosDevolucion(pago)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim pago As Eniac.Entidades.FichaPagoDetalle = DirectCast(entidad, Eniac.Entidades.FichaPagoDetalle)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.BorraFichaPagosDetalle(pago)
         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetUnaOperacionCompleta(ByVal idSucursal As Int32, ByVal IdCliente As Long, ByVal nroOperacion As Integer) As System.Collections.Generic.List(Of Eniac.Entidades.FichaPagoDetalle)
      Dim oFPDs As System.Collections.Generic.List(Of Eniac.Entidades.FichaPagoDetalle) = New System.Collections.Generic.List(Of Eniac.Entidades.FichaPagoDetalle)
      Dim oFPD As Eniac.Entidades.FichaPagoDetalle
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append(" SELECT * ")
         .Append(" FROM FichasPagosDetalle FPD ")
         .Append(" WHERE FPD.NroOperacion = ")
         .Append(nroOperacion.ToString())
         .Append(" AND FPD.IdSucursal = ")
         .Append(idSucursal.ToString())
         .Append(" AND FPD.IdCliente = ")
         .Append(IdCliente.ToString())
      End With
      Dim dt As DataTable = da.GetDataTable(stb.ToString())
      For Each dr As DataRow In dt.Rows
         oFPD = New Eniac.Entidades.FichaPagoDetalle(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
         With oFPD
            .IdSucursal = Int32.Parse(dr("IdSucursal").ToString())
            .IdCliente = Long.Parse(dr("IdCliente").ToString())
            .NroOperacion = Int32.Parse(dr("NroOperacion").ToString())
            .NroCuota = Int32.Parse(dr("NroCuota").ToString())
            .FechaPago = DateTime.Parse(dr("FechaPago").ToString())
            .Importe = Decimal.Parse(dr("Importe").ToString())
            .IdCobrador = Integer.Parse(dr("IdCobrador").ToString())
         End With
         oFPDs.Add(oFPD)
      Next
      Return oFPDs
   End Function

   Public Function GetFichasAImprimir(ByVal idSucursal As Int32, ByVal IdCliente As Long, ByVal nroOperacion As Integer, ByVal fechaPago As DateTime) As System.Collections.Generic.List(Of Eniac.Entidades.FichaPagoDetalle)
      Dim oFPDs As System.Collections.Generic.List(Of Eniac.Entidades.FichaPagoDetalle) = New System.Collections.Generic.List(Of Eniac.Entidades.FichaPagoDetalle)
      Dim oFPD As Eniac.Entidades.FichaPagoDetalle
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append(" select * from fichaspagosdetalle ")
         .AppendFormat(" where NroOperacion = {0}", nroOperacion)
         .AppendFormat(" and IdCliente = {0}", IdCliente)
         .AppendFormat(" and FechaPago = '{0}'", fechaPago.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat("and idsucursal = {0}", idSucursal)
      End With
      Dim dt As DataTable = da.GetDataTable(stb.ToString())
      For Each dr As DataRow In dt.Rows
         oFPD = New Eniac.Entidades.FichaPagoDetalle(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
         With oFPD
            .IdSucursal = Int32.Parse(dr("IdSucursal").ToString())
            .IdCliente = Long.Parse(dr("IdCliente").ToString())
            .NroOperacion = Int32.Parse(dr("NroOperacion").ToString())
            .NroCuota = Int32.Parse(dr("NroCuota").ToString())
            .FechaPago = DateTime.Parse(dr("FechaPago").ToString())
            .Importe = Decimal.Parse(dr("Importe").ToString())
            .IdCobrador = Integer.Parse(dr("IdCobrador").ToString())
            .FichaPagoAjuste = New Reglas.FichasPagosAjustes(da).GetUna(.IdSucursal, .NroOperacion, .IdCliente, .FechaPago)
         End With
         oFPDs.Add(oFPD)
      Next
      Return oFPDs
   End Function

   Public Function CtaCte(ByVal idSucursal As Int32, _
                          ByVal IdCliente As Long, _
                          ByVal operaciones As String) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .Append("SELECT NroOperacion, FechaOperacion as FechaCompra, MontoTotalBruto-Anticipo+Interes as ImporteCompra, NULL AS NroCuota, NULL AS FechaPago, NULL AS ImportePago, NULL as Saldo" & vbCrLf)
         .Append(" FROM Fichas " & vbCrLf)
         .Append(" WHERE IdCliente = " & IdCliente.ToString() & vbCrLf)
         .Append("   AND NroOperacion IN (" & operaciones & ")" & vbCrLf)

         .Append("UNION" & vbCrLf)

         'Si no filtro las operaciones en el detalle traigo las anuladas.
         .Append("SELECT NroOperacion, NULL AS FechaCompra, NULL AS ImporteCompra, NroCuota, FechaPago, Importe as ImportePago, NULL as Saldo" & vbCrLf)
         .Append(" FROM FichasPagosDetalle " & vbCrLf)
         .Append(" WHERE IdCliente = " & IdCliente.ToString() & vbCrLf)
         .Append("   AND NroOperacion IN (" & operaciones & ")" & vbCrLf)

         .Append("ORDER BY NroOperacion ASC, FechaOperacion DESC" & vbCrLf)
      End With

      Return Me.DataServer().GetDataTable(stbQuery.ToString())

   End Function

#End Region

#Region "Metodos Privados"

   Private Function EsMayorElSaldo(ByVal ent As Eniac.Entidades.FichaPagoDetalle) As Boolean
      Dim stbquery As StringBuilder = New StringBuilder("")
      With stbquery
         .Append(" SELECT Saldo FROM fichas FP  ")
         .Append(" WHERE	FP.NroOperacion = " & ent.NroOperacion)
         .Append(" AND FP.IdCliente = " & ent.IdCliente.ToString())
         .Append(" AND FP.IdSucursal = " & ent.IdSucursal & " ")
      End With
      Dim dt As DataTable = Me.DataServer().GetDataTable(stbquery.ToString())
      If ent.Importe > Decimal.Parse(dt.Rows(0)("Saldo").ToString()) Then
         Return True
      Else
         Return False
      End If
   End Function

#End Region

#Region "Metodos Friend"

   Friend Sub GrabaFichaPagosDetalle(ByVal ent As Eniac.Entidades.FichaPagoDetalle)

      Dim sql As SqlServer.FichasPagosDetalle = New SqlServer.FichasPagosDetalle(Me.da)

      sql.FichasPagosDetalle_I(ent.IdSucursal, ent.IdCliente, ent.NroOperacion, ent.NroCuota, ent.FechaPago, ent.Importe, _
                               ent.IdCobrador, ent.IdCaja, ent.NumeroPlanilla, ent.NumeroMovimiento)

   End Sub

   Friend Sub ActualizaSaldos(ByVal ent As Eniac.Entidades.FichaPagoDetalle)
      Dim stbQuery As StringBuilder = New StringBuilder("")
      Dim nuevoSaldo As Decimal = 0
      Dim importeADescontar As Decimal = ent.Importe
      Dim importaPago As Decimal = ent.Importe
      If EsMayorElSaldo(ent) Then
         Throw New Exception("El importe que quiere cancelar es mayor al saldo")
      End If

      'si el cliente compro el modulo de caja ingreso el movimiento
      If Boolean.Parse(New Eniac.Reglas.Parametros().GetValor("MODULOCAJA")) Then
         Dim deta As Eniac.Entidades.CajaDetalles = New Eniac.Entidades.CajaDetalles(ent.IdSucursal, ent.Usuario, ent.Password)
         Dim caj As Eniac.Reglas.Cajas = New Eniac.Reglas.Cajas(da)
         Dim cajaDet As Eniac.Reglas.CajaDetalles = New Eniac.Reglas.CajaDetalles(da)

         Dim cli As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes(Me.da)
         Dim client As Eniac.Entidades.Cliente = cli._GetUno(ent.IdCliente)

         With deta
            .IdSucursal = ent.IdSucursal
            .IdCaja = ent.IdCaja
            .FechaMovimiento = ent.FechaPago   'DateTime.Now
            .IdTipoMovimiento = "I"c
            .NumeroPlanilla = caj.GetPlanillaActual(ent.IdSucursal, ent.IdCaja).NumeroPlanilla
            .ImportePesos = ent.Importe
            .Observacion = client.NombreCliente + " - " + "-" + client.CodigoCliente.ToString() + " - Operacion: " + ent.NroOperacion.ToString()
            .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros().GetValor("CTACAJAVENTAS"))
            .Usuario = actual.Nombre
         End With

         cajaDet.AgregaMovimiento(deta, Nothing, Nothing)

         ent.NumeroPlanilla = deta.NumeroPlanilla

         If Boolean.Parse(New Eniac.Reglas.Parametros().GetValor("CTACAJAVENTASACUMULA")) Then
            deta = cajaDet.GetUltimoMovVenta(deta.IdSucursal, deta.IdCaja, deta.NumeroPlanilla, deta.IdCuentaCaja, deta.FechaMovimiento)
         End If

         ent.NumeroMovimiento = deta.NumeroMovimiento

         'No se usa, lo inserta directamente al final de este procedimiento.
         'Me.ActualizaMovimientoCaja(ent)
      End If

      'actualizo la tabla de ajustes por intereses, pagos, etc.
      If ent.FichaPagoAjuste.Importe > 0 Then

         'si el cliente compro el modulo de caja ingreso el movimiento
         If Boolean.Parse(New Eniac.Reglas.Parametros().GetValor("MODULOCAJA")) Then
            Dim deta As Eniac.Entidades.CajaDetalles = New Eniac.Entidades.CajaDetalles(ent.IdSucursal, ent.Usuario, ent.Password)
            Dim caj As Eniac.Reglas.Cajas = New Eniac.Reglas.Cajas(da)
            Dim cajaDet As Eniac.Reglas.CajaDetalles = New Eniac.Reglas.CajaDetalles(da)

            With deta
               .IdSucursal = ent.IdSucursal
               .IdCaja = ent.IdCaja
               .FechaMovimiento = ent.FechaPago    'DateTime.Now
               .IdTipoMovimiento = "I"c
               .NumeroPlanilla = caj.GetPlanillaActual(ent.IdSucursal, ent.IdCaja).NumeroPlanilla
               .ImportePesos = ent.FichaPagoAjuste.Importe
               .Observacion = ent.FichaPagoAjuste.Concepto
               .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros().GetValor("CTACAJAVENTAS"))
               .Usuario = actual.Nombre
            End With

            cajaDet.AgregaMovimiento(deta, Nothing, Nothing)

            ent.FichaPagoAjuste.NumeroPlanilla = deta.NumeroPlanilla

            If Boolean.Parse(New Eniac.Reglas.Parametros().GetValor("CTACAJAVENTASACUMULA")) Then
               deta = cajaDet.GetUltimoMovVenta(deta.IdSucursal, deta.IdCaja, deta.NumeroPlanilla, deta.IdCuentaCaja, deta.FechaMovimiento)
            End If

            ent.FichaPagoAjuste.NumeroMovimiento = deta.NumeroMovimiento

         End If

         Dim fpa As Reglas.FichasPagosAjustes = New Reglas.FichasPagosAjustes(da)
         fpa.GrabaFichaPagosAjuste(ent.FichaPagoAjuste)

      End If

      With stbQuery
         .Append("SELECT * ")
         .Append(" FROM FichasPagos FP ")
         .Append(" WHERE	FP.NroOperacion = " & ent.NroOperacion)
         .Append(" AND FP.IdSucursal = " & ent.IdSucursal & " ")
         .Append(" AND FP.IdCliente = " & ent.IdCliente.ToString())
         .Append(" AND FP.Saldo > 0 ")
         .Append(" ORDER BY FP.NroCuota ")
      End With
      Dim dt As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())

      Dim oFiPagos As Reglas.FichasPagos = New Reglas.FichasPagos(da)
      For Each dr As DataRow In dt.Rows
         ent.NroCuota = Integer.Parse(dr("NroCuota").ToString())
         If Decimal.Parse(dr("Saldo").ToString()) >= importeADescontar Then
            nuevoSaldo = Decimal.Parse(dr("Saldo").ToString()) - importeADescontar
            ent.Importe = importeADescontar
            Me.GrabaFichaPagosDetalle(ent)
            oFiPagos.ActualizaSaldo(ent.IdSucursal, ent.NroOperacion, ent.IdCliente, Integer.Parse(dr("NroCuota").ToString()), nuevoSaldo)
            Exit For
         Else
            nuevoSaldo = 0
            oFiPagos.ActualizaSaldo(ent.IdSucursal, ent.NroOperacion, ent.IdCliente, Integer.Parse(dr("NroCuota").ToString()), nuevoSaldo)
            importeADescontar = importeADescontar - Decimal.Parse(dr("Saldo").ToString())
            ent.Importe = Decimal.Parse(dr("Saldo").ToString())
            Me.GrabaFichaPagosDetalle(ent)
         End If
      Next

      With stbQuery
         .Length = 0
         .Append("SELECT F.Saldo  ")
         .Append(" FROM Fichas F ")
         .Append(" WHERE	F.NroOperacion = " & ent.NroOperacion)
         .Append(" AND F.IdSucursal = " & ent.IdSucursal & " ")
         .Append(" AND F.IdCliente = " & ent.IdCliente.ToString())
      End With
      dt = Me.DataServer().GetDataTable(stbQuery.ToString())
      Dim oFic As Reglas.Fichas = New Reglas.Fichas(da)
      nuevoSaldo = Decimal.Parse(dt.Rows(0)("Saldo").ToString()) - importaPago
      oFic.ActualizaSaldo(ent.IdSucursal, ent.NroOperacion, ent.IdCliente, nuevoSaldo)

   End Sub

   Friend Sub ActualizaSaldosDevolucion(ByVal ent As Eniac.Entidades.FichaPagoDetalle)
      Dim stbQuery As StringBuilder = New StringBuilder("")
      Dim nuevoSaldo As Decimal = 0
      Dim importeADevolver As Decimal = ent.Importe
      Dim importaDevolucionPago As Decimal = ent.Importe

      'si el cliente compro el modulo de caja egreso el movimiento
      If Boolean.Parse(New Eniac.Reglas.Parametros().GetValor("MODULOCAJA")) Then
         Dim deta As Eniac.Entidades.CajaDetalles = New Eniac.Entidades.CajaDetalles(ent.IdSucursal, ent.Usuario, ent.Password)
         Dim caj As Eniac.Reglas.Cajas = New Eniac.Reglas.Cajas(da)
         Dim cajaDet As Eniac.Reglas.CajaDetalles = New Eniac.Reglas.CajaDetalles(da)

         With deta
            .IdSucursal = ent.IdSucursal
            .IdCaja = ent.IdCaja
            .FechaMovimiento = ent.FechaPago     'DateTime.Now
            .IdTipoMovimiento = "E"c
            .NumeroPlanilla = caj.GetPlanillaActual(ent.IdSucursal, ent.IdCaja).NumeroPlanilla
            .ImportePesos = ent.Importe
            .Observacion = "Devolución " + " - " + ent.NroOperacion.ToString() + " - " + ent.NroCuota.ToString()
            .IdCuentaCaja = Integer.Parse(New Eniac.Reglas.Parametros().GetValor("CTACAJAVENTAS"))
            .Usuario = actual.Nombre
         End With

         cajaDet.AgregaMovimiento(deta, Nothing, Nothing)

         ent.NumeroPlanilla = deta.NumeroPlanilla

         If Boolean.Parse(New Eniac.Reglas.Parametros().GetValor("CTACAJAVENTASACUMULA")) Then
            deta = cajaDet.GetUltimoMovVenta(deta.IdSucursal, deta.IdCaja, deta.NumeroPlanilla, deta.IdCuentaCaja, deta.FechaMovimiento)
         End If

         ent.NumeroMovimiento = deta.NumeroMovimiento

         'No se usa, lo inserta directamente al final de este procedimiento.
         'Me.ActualizaMovimientoCaja(ent)
      End If

      With stbQuery
         .Append("SELECT * ")
         .Append(" FROM FichasPagos FP ")
         .Append(" WHERE	FP.NroOperacion = " & ent.NroOperacion)
         .Append(" AND FP.IdSucursal = " & ent.IdSucursal & " ")
         .Append(" AND FP.IdCliente = " & ent.IdCliente.ToString())
         .Append(" AND FP.Saldo <> FP.Importe ")
         .Append(" ORDER BY FP.NroCuota Desc ")
      End With
      Dim dt As DataTable = da.GetDataTable(stbQuery.ToString())
      Dim oFiPagos As Reglas.FichasPagos = New Reglas.FichasPagos(da)
      If dt.Rows.Count = 0 Then
         Throw New Exception("No existen pagos a devolver")
      End If
      For Each dr As DataRow In dt.Rows
         ent.NroCuota = Integer.Parse(dr("NroCuota").ToString())
         Dim impDesc As Decimal = Decimal.Parse(dr("Importe").ToString()) - Decimal.Parse(dr("Saldo").ToString())
         If impDesc >= importeADevolver Then
            nuevoSaldo = Decimal.Parse(dr("Saldo").ToString()) + importeADevolver
            ent.Importe = -importeADevolver
            Me.GrabaFichaPagosDetalle(ent)
            oFiPagos.ActualizaSaldo(ent.IdSucursal, ent.NroOperacion, ent.IdCliente, Integer.Parse(dr("NroCuota").ToString()), nuevoSaldo)
            Exit For
         Else
            nuevoSaldo = Decimal.Parse(dr("Importe").ToString())
            oFiPagos.ActualizaSaldo(ent.IdSucursal, ent.NroOperacion, ent.IdCliente, Integer.Parse(dr("NroCuota").ToString()), nuevoSaldo)
            importeADevolver = importeADevolver - impDesc
            ent.Importe = -impDesc
            Me.GrabaFichaPagosDetalle(ent)
         End If
      Next
      With stbQuery
         .Length = 0
         .Append("SELECT F.Saldo, F.TotalNeto  ")
         .Append(" FROM Fichas F ")
         .Append(" WHERE F.NroOperacion = " & ent.NroOperacion)
         .Append(" AND F.IdSucursal = " & ent.IdSucursal & " ")
         .Append(" AND F.IdCliente = " & ent.IdCliente.ToString())
      End With
      dt = da.GetDataTable(stbQuery.ToString())
      Dim saldoA As Decimal = Decimal.Parse(dt.Rows(0)("Saldo").ToString()) + importaDevolucionPago
      If Decimal.Parse(dt.Rows(0)("TotalNeto").ToString()) < saldoA Then
         Throw New Exception("El importe a devolver es mayor que el pago de la operación")
      End If
      Dim oFic As Reglas.Fichas = New Reglas.Fichas(da)
      nuevoSaldo = Decimal.Parse(dt.Rows(0)("Saldo").ToString()) + importaDevolucionPago
      oFic.ActualizaSaldo(ent.IdSucursal, ent.NroOperacion, ent.IdCliente, nuevoSaldo)

   End Sub

   Friend Sub BorraFichaPagosDetalle(ByVal pago As Eniac.Entidades.FichaPagoDetalle)
      Dim sql As SqlServer.FichasPagosDetalle = New SqlServer.FichasPagosDetalle(Me.da)
      sql.FichasPagosDetalle_D(pago.IdSucursal, pago.NroOperacion, pago.IdCliente, pago.NroCuota, pago.FechaPago)
   End Sub

   Private Sub ActualizaMovimientoCaja(ByVal ent As Entidades.FichaPagoDetalle)
      Try

         Dim sql As SqlServer.FichasPagosDetalle = New SqlServer.FichasPagosDetalle(Me.da)

         sql.FichasPagosDetalle_MovimientoCaja_U(ent.IdSucursal, ent.IdCliente, ent.NroOperacion, _
                                                 ent.NroCuota, ent.FechaPago, ent.IdCaja, ent.NumeroPlanilla, ent.NumeroMovimiento)

      Catch ex As Exception
         Throw ex
      End Try
   End Sub
#End Region

End Class
