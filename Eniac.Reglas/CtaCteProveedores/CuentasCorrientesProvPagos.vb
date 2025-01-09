Imports Eniac.Entidades
Imports Eniac.Reglas.ParametrosCache

Public Class CuentasCorrientesProvPagos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      MyBase.New()
      Me.NombreEntidad = "CuentasCorrientesProvPagos"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos"

   Public Function GetProximoNumero(IdSucursal As Integer, idTipoComprobante As String, letraFiscal As String, emisor As Integer) As Integer
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append("SELECT (Numero + 1) Numero ")
         .Append(" FROM ComprasNumeros")
         .Append(" WHERE IdTipoComprobante = '" & idTipoComprobante & "'")
         .Append(" AND LetraFiscal = '" & letraFiscal & "'")
         .Append(" AND CentroEmisor = " & emisor.ToString())
         .Append(" AND IdSucursal = " & IdSucursal.ToString())
      End With
      Dim dt As DataTable = da.GetDataTable(stbQuery.ToString())
      If dt.Rows.Count > 0 Then
         Return Integer.Parse(dt.Rows(0)("Numero").ToString())
      Else
         Return 1
      End If
   End Function

   Public Function GetCuentacorrienteProvPagosSecuenciaRetencion(ent As Entidades.CuentaCorrienteProvPago) As Integer
      Dim secRetencion = 0
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .AppendLine("SELECT COUNT(*) as Numero from CuentasCorrientesProvPagos")
         .AppendLine("  WHERE")
         .AppendFormat("	    IdSucursal = {0} ", ent.IdSucursal)
         .AppendFormat("	AND IdTipoComprobante2 = '{0}'", ent.IdTipoComprobante)
         .AppendFormat("	AND Letra2 = '{0}'", ent.Letra)
         .AppendFormat("	AND CentroEmisor2 = {0}", ent.CentroEmisor)
         .AppendFormat("	AND NumeroComprobante2 = {0}", ent.NumeroComprobante)
         .AppendFormat("	AND IdTipoComprobante = 'PAGO'")
      End With
      Dim dt As DataTable = da.GetDataTable(stbQuery.ToString())
      If dt IsNot Nothing Then
         Return Integer.Parse(dt.Rows(0)("Numero").ToString())
      End If
      Return secRetencion
   End Function

   Friend Sub GrabaCuentaCorrienteProvPagos(ent As Entidades.CuentaCorrienteProvPago, cuota As Integer)

      Dim ajuste As Decimal = ent.CuentaCorrienteProv.TipoComprobante.CoeficienteValores
      Dim saldo As Decimal = 0
      Dim importeCuota As Decimal = 0

      Dim tipo2 As String = Nothing
      Dim letra2 As String = Nothing
      Dim cuota2 As Integer = 0
      Dim comprobante2 As Long = 0
      Dim emisor2 As Integer = 0

      If Not ent.CuentaCorrienteProv.TipoComprobante.EsRecibo Then
         ' If ent.CuentaCorrienteProv.TipoComprobante.IdTipoComprobante.Trim() <> "PAGO" And ent.CuentaCorrienteProv.TipoComprobante.IdTipoComprobante.Trim() <> "PAGOPROV" Then
         tipo2 = ent.CuentaCorrienteProv.TipoComprobante.IdTipoComprobante
         letra2 = ent.CuentaCorrienteProv.Letra
         emisor2 = ent.CuentaCorrienteProv.CentroEmisor
         comprobante2 = ent.CuentaCorrienteProv.NumeroComprobante
         cuota2 = cuota

         saldo = ent.SaldoCuota
         importeCuota = ent.SaldoCuota
      Else
         importeCuota = ent.Paga

      End If

      Dim sql As SqlServer.CuentasCorrientesProvPagos = New SqlServer.CuentasCorrientesProvPagos(da)

      sql.CuentasCorrientesProvPagos_I(ent.CuentaCorrienteProv.IdSucursal, ent.CuentaCorrienteProv.TipoComprobante.IdTipoComprobante,
                 ent.CuentaCorrienteProv.Letra, ent.CuentaCorrienteProv.CentroEmisor, ent.CuentaCorrienteProv.NumeroComprobante,
                 cuota, ent.CuentaCorrienteProv.Proveedor.IdProveedor,
                 ent.CuentaCorrienteProv.Fecha, ent.FechaVencimiento, importeCuota * ajuste, saldo * ajuste,
                 ent.CuentaCorrienteProv.FormaPago.IdFormasPago, ent.CuentaCorrienteProv.Observacion, tipo2, comprobante2, emisor2, cuota2, letra2, ent.DescuentoRecargoPorc,
                 ent.DescuentoRecargo)

   End Sub

   Friend Sub Eliminar(ent As Entidades.CuentaCorrienteProvPago)

      Dim sql As SqlServer.CuentasCorrientesProvPagos = New SqlServer.CuentasCorrientesProvPagos(da)

      sql.CuentasCorrientesProvPagos_D(ent.CuentaCorrienteProv.IdSucursal,
                                       ent.CuentaCorrienteProv.Proveedor.IdProveedor,
                                       ent.CuentaCorrienteProv.TipoComprobante.IdTipoComprobante,
                                       ent.CuentaCorrienteProv.Letra,
                                       ent.CuentaCorrienteProv.CentroEmisor,
                                       ent.CuentaCorrienteProv.NumeroComprobante)

   End Sub

   Friend Sub ActualizaSaldo(ent As Entidades.CuentaCorrienteProvPago, importeAplicar As Decimal)

      Dim sql As SqlServer.CuentasCorrientesProvPagos = New SqlServer.CuentasCorrientesProvPagos(da)

      sql.CuentasCorrientesProvPagos_USaldo(ent.IdSucursal, ent.CuentaCorrienteProv.Proveedor.IdProveedor, ent.IdTipoComprobante,
                                            ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, ent.Cuota, importeAplicar)

   End Sub

   Friend Sub ActualizaComprobantes(ent As Entidades.CuentaCorrienteProvPago, cuota As Integer)

      Dim sql As SqlServer.CuentasCorrientesProvPagos = New SqlServer.CuentasCorrientesProvPagos(da)

      sql.CuentasCorrientesProvPagos_UComprobante(ent.CuentaCorrienteProv.IdSucursal,
                                                  ent.CuentaCorrienteProv.Proveedor.IdProveedor, ent.CuentaCorrienteProv.TipoComprobante.IdTipoComprobante,
                                                  ent.CuentaCorrienteProv.Letra, ent.CuentaCorrienteProv.CentroEmisor, ent.CuentaCorrienteProv.NumeroComprobante,
                                                  cuota, ent.TipoComprobante.IdTipoComprobante, ent.NumeroComprobante, ent.CentroEmisor,
                                                  ent.Cuota, ent.Letra)

   End Sub

   Public Function GetDetalle(sucursales() As Eniac.Entidades.Sucursal,
                              desde As Date,
                              hasta As Date,
                              idProveedor As Long,
                              idTipoComprobante As String,
                              saldo As String,
                              vencimiento As String,
                              idCategoria As Integer,
                              grabaLibro As String) As DataTable
      Return New SqlServer.CuentasCorrientesProvPagos(da).GetDetalle(sucursales,
                                                                     desde, hasta,
                                                                     idProveedor,
                                                                     idTipoComprobante,
                                                                     saldo,
                                                                     vencimiento,
                                                                     idCategoria,
                                                                     grabaLibro,
                                                                     actual.NivelAutorizacion)
   End Function

   Public Function GetKardexComprobante(Sucursal As Integer,
                                        IdProveedor As Long,
                                        TipoComprobante As String,
                                        Letra As String,
                                        Emisor As Integer,
                                        Numero As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT CCP.IdSucursal, ")
         .Append("	CCP.IdTipoComprobante, ")
         .Append("	CCP.Letra, ")
         .Append("	CCP.CentroEmisor, ")
         .Append("	CCP.NumeroComprobante, ")
         .Append("	CCP.CuotaNumero, ")
         .Append("	CCP.Fecha, ")
         .Append("	CCP.FechaVencimiento, ")
         .Append("	CCP.ImporteCuota, ")
         .Append("	CCP.Observacion, ")
         .Append("	CCP.IdProveedor ")
         .Append("	FROM CuentasCorrientesProvPagos CCP")

         .AppendLine("  INNER JOIN Proveedores P ON CCP.IdProveedor = P.IdProveedor ")

         .Append("  WHERE CCP.IdSucursal = " & Sucursal.ToString())

         .Append("	 AND P.IdProveedor = " & IdProveedor)

         .Append("	 AND (")
         .Append("	 (CCP.IdTipoComprobante = '" & TipoComprobante & "'")
         .Append("	 AND CCP.Letra = '" & Letra & "'")
         .Append("	 AND CCP.CentroEmisor = " & Emisor)
         .Append("	 AND CCP.NumeroComprobante = " & Numero & ")")

         .Append("	 OR (CCP.IdTipoComprobante2 = '" & TipoComprobante & "'")
         .Append("	 AND CCP.Letra2 = '" & Letra & "'")
         .Append("	 AND CCP.CentroEmisor2 = " & Emisor)
         .Append("	 AND CCP.NumeroComprobante2 = " & Numero & ")")
         .Append("	 ) ")

         .Append("	ORDER BY CCP.Fecha")
         .Append("	,CCP.IdTipoComprobante")
         .Append("	,CCP.Letra")
         .Append("	,CCP.CentroEmisor")
         .Append("	,CCP.NumeroComprobante")
         .Append("	,CCP.CuotaNumero")

      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorCuentaCorriente(ctacte As Entidades.CuentaCorrienteProv) As List(Of Entidades.CuentaCorrienteProvPago)
      Dim sql = New SqlServer.CuentasCorrientesProvPagos(da)
      Dim oLis = New List(Of Entidades.CuentaCorrienteProvPago)
      Using dt = sql.GetPorCuentaCorriente(ctacte.IdSucursal, ctacte.Proveedor.IdProveedor, ctacte.TipoComprobante.IdTipoComprobante, ctacte.Letra, ctacte.CentroEmisor, ctacte.NumeroComprobante)
         For Each dr As DataRow In dt.Rows
            Dim o = New Entidades.CuentaCorrienteProvPago()
            CargarUna(dr, o)
            o.ImporteCuota *= ctacte.TipoComprobante.CoeficienteValores
            o.Paga *= ctacte.TipoComprobante.CoeficienteValores
            o.SaldoCuota *= ctacte.TipoComprobante.CoeficienteValores
            If ctacte.TipoComprobante.IdTipoComprobante <> o.TipoComprobante.IdTipoComprobante Then
               o.ImporteCuota = sql.GetImporteCuota(o.IdSucursal, ctacte.Proveedor.IdProveedor, o.TipoComprobante.IdTipoComprobante, o.Letra, o.CentroEmisor, o.NumeroComprobante, o.Cuota)
               'Se calcula el saldo a 1 segundo antes del pago, es decir el que tenia al momento de hacerlo.
               'No se utiliza el de la base porque podria hacer los pagos en momentos distintos cronologricamente.
               o.SaldoCuota = sql.GetSaldoCuota(o.IdSucursal, ctacte.Proveedor.IdProveedor, o.TipoComprobante.IdTipoComprobante, o.Letra, o.CentroEmisor, o.NumeroComprobante, o.Cuota, o.Fecha.AddSeconds(-1))
               o.Fecha = sql.GetFecha(o.IdSucursal, ctacte.Proveedor.IdProveedor, o.TipoComprobante.IdTipoComprobante, o.Letra, o.CentroEmisor, o.NumeroComprobante, o.Cuota)
               o.FechaVencimiento = sql.GetFechaVencimiento(o.IdSucursal, ctacte.Proveedor.IdProveedor, o.TipoComprobante.IdTipoComprobante, o.Letra, o.CentroEmisor, o.NumeroComprobante, o.Cuota)
            End If
            oLis.Add(o)
         Next
      End Using
      Return oLis
   End Function

   Private Sub CargarUna(dr As DataRow, o As Entidades.CuentaCorrienteProvPago)
      With o
         .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
         .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dr("IdTipoComprobante2").ToString())
         .Letra = dr("Letra2").ToString()
         .CentroEmisor = Short.Parse(dr("CentroEmisor2").ToString())
         .NumeroComprobante = Long.Parse(dr("NumeroComprobante2").ToString())
         .Cuota = Integer.Parse(dr("CuotaNumero2").ToString())
         .Fecha = Date.Parse(dr("Fecha").ToString())
         .FechaVencimiento = Date.Parse(dr("FechaVencimiento").ToString())
         .ImporteCuota = Decimal.Parse(dr("ImporteCuota").ToString())
         .SaldoCuota = Decimal.Parse(dr("SaldoCuota").ToString())
         .FormaPago.DescripcionFormasPago = New Reglas.VentasFormasPago().GetUna(Integer.Parse(dr("IdFormasPago").ToString())).DescripcionFormasPago
         .Paga = Decimal.Parse(dr("ImporteCuota").ToString())
         .DescuentoRecargoPorc = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
         .DescuentoRecargo = Decimal.Parse(dr("DescuentoRecargo").ToString())
         .Observacion = dr("Observacion").ToString()
      End With
   End Sub

   Public Function GetSaldoProveedores(Desde As Date,
                                       Hasta As Date) As DataTable

      Dim sql As SqlServer.CuentasCorrientesProvPagos
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.CuentasCorrientesProvPagos(da)
         dt = sql.GetSaldoProveedores(Desde, Hasta)

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetSaldosCtaCte(sucursal As Integer,
                                   fechaHasta As Date,
                                   idProveedor As Long,
                                   tipoSaldo As String,
                                   idCategoria As Integer,
                                   grabaLibro As String,
                                   idRubroCompra As Integer) As DataTable

      '(Sucursal As Integer, _
      '                             Optional FechaHasta As Date = Nothing, _
      '                             Optional IdProveedor As Long = 0, _
      '                             Optional TipoSaldo As String = "", _
      '                             Optional IdCategoria As Integer = 0, _
      '                             Optional GrabaLibro As String = "TODOS")

      Return New SqlServer.CuentasCorrientesProvPagos(da).GetSaldosCtaCte(sucursal,
                                                                          fechaHasta,
                                                                          idProveedor,
                                                                          tipoSaldo,
                                                                          idCategoria,
                                                                          grabaLibro,
                                                                          actual.NivelAutorizacion,
                                                                          idRubroCompra)

   End Function

   Public Function GetPorProveedor(sucursales As Entidades.Sucursal(), proveedor As Entidades.Proveedor,
                                   fechaUtilizada As String, desde As Date?, hasta As Date?,
                                   grabaLibro As Entidades.Publicos.SiNoTodos) As DataTable
      Return New SqlServer.CuentasCorrientesProvPagos(da).GetPorProveedor(sucursales, proveedor, fechaUtilizada, desde, hasta,
                                                                          grabaLibro, actual.NivelAutorizacion)
   End Function

   Public Function GetControlInconsistenciasCtaCteVsCtaCtePagos(idSucursal As Integer) As DataTable

      Dim sql As SqlServer.CuentasCorrientesProvPagos
      Dim dt As DataTable

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         sql = New SqlServer.CuentasCorrientesProvPagos(da)

         dt = sql.GetControlInconsistenciasCtaCtevsCtaCtePagos(idSucursal)

         Me.da.CommitTransaction()

         Return dt

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetSaldosPorVencimientos(sucursales As Entidades.Sucursal(),
                                            fechaHasta As Entidades.CuentaCorrienteAntiguedadSaldoConfig.FechasInforme,
                                            idProveedor As Long,
                                            excluirSaldosNegativos As String,
                                            idCategoria As Integer,
                                            grabaLibro As String,
                                            grupo As String,
                                            excluirAnticipos As String,
                                            excluirPreComprobantes As String,
                                            rangosDias As Entidades.CuentaCorrienteAntiguedadSaldoConfig,
                                            idProvincia As String) As DataTable

      Return New SqlServer.CuentasCorrientesProvPagos(da).GetSaldosPorVencimientos(sucursales,
                                          fechaHasta,
                                          idProveedor,
                                          excluirSaldosNegativos,
                                          idCategoria,
                                          grabaLibro,
                                          grupo,
                                          excluirAnticipos,
                                          excluirPreComprobantes,
                                          rangosDias,
                                          idProvincia,
                                          actual.NivelAutorizacion)
   End Function


   Public Function GetParaAlerta(sucursales As Entidades.Sucursal(),
                                 fechaVancimientoHasta As Date?,
                                 saldoMinimoAlerta As Decimal,
                                 cantidadComprobanteAdeudados As Integer) As DataTable

      Dim dt = New SqlServer.CuentasCorrientesProvPagos(da).
                     GetParaAlerta(sucursales, fechaVancimientoHasta, saldoMinimoAlerta, cantidadComprobanteAdeudados)

      Dim p = Sub(dc As DataColumn, caption As String, ByRef orden As Integer)
                 dc.Caption = caption
                 dc.SetOrdinal(orden)
                 orden += 1
              End Sub

      Dim pos = 0I
      p(dt.Columns("CodigoProveedor"), "Código", pos)
      p(dt.Columns("NombreProveedor"), "Cliente", pos)
      p(dt.Columns("NombreCategoria"), "Categoria", pos)
      p(dt.Columns("TelefonoProveedor"), "Teléfono", pos)
      p(dt.Columns("Saldo"), "Saldo", pos)

      dt.Columns.Remove("IdProveedor")
      dt.Columns.Remove("Total")
      dt.Columns.Remove("Cantidad")

      Return dt
   End Function

   Public Function GetUna(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Integer,
                          numeroComprobante As Long,
                          idProveedor As Long,
                          cuotaNumero As Integer) As Entidades.CuentaCorrienteProvPago
      Dim sql As SqlServer.CuentasCorrientesProvPagos = New SqlServer.CuentasCorrientesProvPagos(da)
      Dim dt As DataTable = sql.GetUna(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, cuotaNumero)
      Dim o As Entidades.CuentaCorrienteProvPago = New Entidades.CuentaCorrienteProvPago()
      For Each dr As DataRow In dt.Rows
         Me.CargarUna(dr, o)
      Next
      Return o

   End Function
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entd As Eniac.Entidades.Entidad)
      Dim ent As Entidades.CuentaCorrienteProvPago = DirectCast(entd, Entidades.CuentaCorrienteProvPago)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.GrabaCuentaCorrienteProvPagos(ent, ent.Cuota)

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
