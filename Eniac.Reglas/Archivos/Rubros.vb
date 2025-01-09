#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports Eniac.Entidades
Imports Eniac.Reglas.ServiciosRest.Sincronizacion

#End Region
Public Class Rubros
   Inherits Eniac.Reglas.BaseSync(Of Entidades.JSonEntidades.Archivos.RubroJSonTransporte, Entidades.JSonEntidades.Archivos.RubroJSon)
   Implements IRestServices
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.RubroJSonTransporte, Entidades.JSonEntidades.Archivos.RubroJSon)

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Rubros"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Inserta(entidad)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Actualiza(entidad)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Rubros = New SqlServer.Rubros(Me.da)

         Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Rubros(Me.da).Rubros_GA(Nothing)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim rubro As Entidades.Rubro = DirectCast(entidad, Entidades.Rubro)
      Dim sql As SqlServer.Rubros = New SqlServer.Rubros(Me.da)
      Dim rRubrosDescRecar As Reglas.RubrosComisionesPorDescuento = New Reglas.RubrosComisionesPorDescuento(da)

      Dim sqlIVA As SqlServer.TiposImpuestos = New SqlServer.TiposImpuestos(Me.da)
      Dim tieneModuloContabilidad As Boolean = Publicos.TieneModuloContabilidad ' Boolean.Parse(New Reglas.Parametros(Me.da)._GetValor(Parametro.Parametros.MODULOCONTABILIDAD))

      Dim cuenta As Entidades.ucCuentaDHvb
      cuenta = New Entidades.ucCuentaDHvb
      Dim cuentaV As Entidades.ucCuentaDHvb
      cuentaV = New Entidades.ucCuentaDHvb

      Dim sqlCuenta As SqlServer.ucCuentasDH = New SqlServer.ucCuentasDH(Me.da)
      '' ''Dim idCuentaImpuestoDebe As Long
      '' ''Dim idCuentaImpuestoHaber As Long

      '' ''If tieneModuloContabilidad Then
      '' ''   For Each vC As Entidades.ucCuentaDHvb In rubro.EntidadCuentas
      '' ''      If vC.Tipo = Entidades.ContabilidadProceso.Procesos.COMPRAS.ToString() Then
      '' ''         cuenta.idCuentaDebe = vC.idCuentaDebe
      '' ''         cuenta.idCuentaHaber = vC.idCuentaHaber
      '' ''         cuenta.IdPlanCuenta = vC.IdPlanCuenta
      '' ''         cuenta.Tipo = vC.Tipo
      '' ''         'Else ' VENTAS
      '' ''         '   cuentaV.idCuentaDebe = vC.idCuentaDebe
      '' ''         '   cuentaV.idCuentaHaber = vC.idCuentaHaber
      '' ''         '   cuentaV.IdPlanCuenta = vC.IdPlanCuenta
      '' ''         '   cuentaV.Tipo = vC.Tipo
      '' ''      End If
      '' ''   Next

      '' ''   For Each vC As Entidades.ucCuentaDHvb In rubro.EntidadCuentasVentas
      '' ''      If vC.Tipo = Entidades.ContabilidadProceso.Procesos.VENTAS.ToString() Then
      '' ''         cuentaV.idCuentaDebe = vC.idCuentaDebe
      '' ''         cuentaV.idCuentaHaber = vC.idCuentaHaber
      '' ''         cuentaV.IdPlanCuenta = vC.IdPlanCuenta
      '' ''         cuentaV.Tipo = vC.Tipo
      '' ''      End If
      '' ''   Next

      '' ''   idCuentaImpuestoDebe = sqlIVA.GetCuentaDebe("IVA")
      '' ''   idCuentaImpuestoHaber = sqlIVA.GetCuentaHaber("IVA")

      '' ''End If


      Select Case tipo
         Case TipoSP._I

            sql.Rubros_I(rubro.IdRubro, rubro.NombreRubro, rubro.Actividad.IdProvincia, rubro.Actividad.IdActividad,
                         rubro.ComisionPorVenta, rubro.UnidHasta1, rubro.UnidHasta2, rubro.UnidHasta3, rubro.UnidHasta4, rubro.UnidHasta5,
                         rubro.UHPorc1, rubro.UHPorc2, rubro.UHPorc3, rubro.UHPorc4, rubro.UHPorc5, rubro.Orden, rubro.DescuentoRecargoPorc1, rubro.DescuentoRecargoPorc2, rubro.CodigoExportacion,
                         rubro.IdRubroTiendaNube, rubro.IdRubroMercadoLibre, rubro.idRubroArborea)

            rRubrosDescRecar.InsertaDesdeRubro(rubro)
            '' ''If tieneModuloContabilidad Then

            '' ''   ' inserto contabilidad en la tabla generica.
            '' ''   '######################### COMPRAS ###################################
            '' ''   'elimino la cuenta para luego volver a cargarla
            '' ''   sqlCuenta.EliminoUnaCuenta(rubro.IdRubro, cuenta.IdPlanCuenta, cuenta.idCuentaDebe)
            '' ''   If cuenta.idCuentaDebe <> 0 Then 'si la cuenta es 0 es porque no la cargo en el ABM
            '' ''      sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''                      , cuenta.IdPlanCuenta _
            '' ''                      , cuenta.Tipo _
            '' ''                      , cuenta.idCuentaDebe _
            '' ''                      , True _
            '' ''                      , False _
            '' ''                      , ContabilidadProcesos.ConstantesVenta.ImporteBruto) ' "Sub Total")
            '' ''   End If
            '' ''   sqlCuenta.EliminoUnaCuenta(rubro.IdRubro, cuenta.IdPlanCuenta, cuenta.idCuentaHaber)
            '' ''   If cuenta.idCuentaHaber <> 0 Then
            '' ''      sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''                              , cuenta.IdPlanCuenta _
            '' ''                              , cuenta.Tipo _
            '' ''                              , cuenta.idCuentaHaber _
            '' ''                              , False _
            '' ''                              , True _
            '' ''                              , ContabilidadProcesos.ConstantesVenta.ImporteTotal) '"Total")
            '' ''   End If

            '' ''   sqlCuenta.EliminoUnaCuenta(rubro.IdRubro, cuenta.IdPlanCuenta, idCuentaImpuestoDebe)
            '' ''   If idCuentaImpuestoDebe <> 0 Then
            '' ''      ' cuenta IVA CF 21% ---  esta va fija ""10401007" _
            '' ''      sqlCuenta.CuentaRubro_I(rubro.IdRubro,
            '' ''                           cuenta.IdPlanCuenta,
            '' ''                           cuenta.Tipo,
            '' ''                           idCuentaImpuestoDebe,
            '' ''                           True,
            '' ''                           False,
            '' ''                           ContabilidadProcesos.ConstantesVenta.IvaTotal) '"iva")
            '' ''   End If


            '' ''   '######################### VENTAS ###################################
            '' ''   ' cuenta DEUDORES de MATERIALES ---- 
            '' ''   sqlCuenta.EliminoUnaCuenta(rubro.IdRubro, cuenta.IdPlanCuenta, cuentaV.idCuentaDebe)
            '' ''   If cuentaV.idCuentaDebe <> 0 Then
            '' ''      sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''                              , cuenta.IdPlanCuenta _
            '' ''                              , cuentaV.Tipo _
            '' ''                              , cuentaV.idCuentaDebe _
            '' ''                              , True _
            '' ''                              , False _
            '' ''                              , ContabilidadProcesos.ConstantesVenta.ImporteTotal) ' "Sub Total")
            '' ''   End If


            '' ''   ' cuenta -- ventas locales -  
            '' ''   sqlCuenta.EliminoUnaCuenta(rubro.IdRubro, cuenta.IdPlanCuenta, cuentaV.idCuentaHaber)
            '' ''   If cuentaV.idCuentaHaber <> 0 Then
            '' ''      sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''                           , cuenta.IdPlanCuenta _
            '' ''                           , cuentaV.Tipo _
            '' ''                           , cuentaV.idCuentaHaber _
            '' ''                           , False _
            '' ''                           , True _
            '' ''                           , ContabilidadProcesos.ConstantesVenta.ImporteBruto)
            '' ''   End If

            '' ''   ' cuenta IVA DF --- 
            '' ''   sqlCuenta.EliminoUnaCuenta(rubro.IdRubro, cuenta.IdPlanCuenta, idCuentaImpuestoHaber)
            '' ''   If idCuentaImpuestoHaber <> 0 Then
            '' ''      sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''                              , cuenta.IdPlanCuenta _
            '' ''                              , cuentaV.Tipo _
            '' ''                              , idCuentaImpuestoHaber _
            '' ''                              , False _
            '' ''                              , True _
            '' ''                              , ContabilidadProcesos.ConstantesVenta.IvaTotal) '"Total")
            '' ''   End If

            '' ''   '#########################'STOCKXVTAS ###################################

            '' ''   ' cuenta COSTO de VENTA de MATERIALES ---fija
            '' ''   sqlCuenta.EliminoUnaCuenta(rubro.IdRubro, cuenta.IdPlanCuenta, 40102001)

            '' ''   sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''                        , cuenta.IdPlanCuenta _
            '' ''                        , "STOCKXVTAS" _
            '' ''                        , 40102001 _
            '' ''                        , True _
            '' ''                        , False _
            '' ''                        , ContabilidadProcesos.ConstantesVenta.ImporteTotal)

            '' ''   ' cuenta IVA DF --- la misma que se ingresa por pantalla para la compra
            '' ''   If Not sqlCuenta.Existe(rubro.IdRubro, cuenta.idCuentaDebe, cuenta.IdPlanCuenta) Then
            '' ''      If cuenta.idCuentaDebe <> 0 Then
            '' ''         sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''                                 , cuenta.IdPlanCuenta _
            '' ''                                 , "STOCKXVTAS" _
            '' ''                                 , cuenta.idCuentaDebe _
            '' ''                                 , False _
            '' ''                                 , True _
            '' ''                                 , ContabilidadProcesos.ConstantesVenta.ImporteBruto) 'sub total
            '' ''      End If
            '' ''   End If

            '' ''End If

         Case TipoSP._U

            sql.Rubros_U(rubro.IdRubro, rubro.NombreRubro, rubro.Actividad.IdProvincia, rubro.Actividad.IdActividad,
                        rubro.ComisionPorVenta, rubro.UnidHasta1, rubro.UnidHasta2, rubro.UnidHasta3, rubro.UnidHasta4, rubro.UnidHasta5,
                        rubro.UHPorc1, rubro.UHPorc2, rubro.UHPorc3, rubro.UHPorc4, rubro.UHPorc5, rubro.Orden, rubro.DescuentoRecargoPorc1, rubro.DescuentoRecargoPorc2, rubro.CodigoExportacion,
                        rubro.IdRubroTiendaNube, rubro.IdRubroMercadoLibre, rubro.idRubroArborea)

            rRubrosDescRecar.ActualizarDesdeRubro(rubro)

            '' ''If tieneModuloContabilidad Then

            '' ''   sqlCuenta.CuentaRubro_D(cuenta.IdPlanCuenta, _
            '' ''                           rubro.IdRubro, _
            '' ''                           cuenta.Tipo)

            '' ''   If cuenta.idCuentaDebe <> 0 Then
            '' ''      sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''                              , cuenta.IdPlanCuenta _
            '' ''                              , cuenta.Tipo _
            '' ''                              , cuenta.idCuentaDebe _
            '' ''                              , True _
            '' ''                              , False _
            '' ''                              , ContabilidadProcesos.ConstantesVenta.ImporteBruto) ' "Sub Total")
            '' ''   End If

            '' ''   If cuenta.idCuentaHaber <> 0 Then
            '' ''      sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''                              , cuenta.IdPlanCuenta _
            '' ''                              , cuenta.Tipo _
            '' ''                              , cuenta.idCuentaHaber _
            '' ''                              , False _
            '' ''                              , True _
            '' ''                              , ContabilidadProcesos.ConstantesVenta.ImporteTotal) '"Total")
            '' ''   End If

            '' ''   ' cuenta IVA CF 21% ---  
            '' ''   If Not sqlCuenta.Existe(rubro.IdRubro, idCuentaImpuestoDebe, cuenta.IdPlanCuenta) Then
            '' ''      sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''                           , cuenta.IdPlanCuenta _
            '' ''                           , cuenta.Tipo _
            '' ''                           , idCuentaImpuestoDebe _
            '' ''                           , True _
            '' ''                           , False _
            '' ''                           , ContabilidadProcesos.ConstantesVenta.IvaTotal) '"iva")
            '' ''   End If


            '' ''   '######################### VENTAS ###################################

            '' ''   sqlCuenta.CuentaRubro_D(cuenta.IdPlanCuenta, _
            '' ''                           rubro.IdRubro, _
            '' ''                           cuentaV.Tipo)


            '' ''   ' cuenta DEUDORES de MATERIALES ---- 
            '' ''   sqlCuenta.EliminoUnaCuenta(rubro.IdRubro, cuenta.IdPlanCuenta, cuentaV.idCuentaDebe)

            '' ''   If cuentaV.idCuentaDebe <> 0 Then
            '' ''      sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''            , cuenta.IdPlanCuenta _
            '' ''            , cuentaV.Tipo _
            '' ''            , cuentaV.idCuentaDebe _
            '' ''            , True _
            '' ''            , False _
            '' ''            , ContabilidadProcesos.ConstantesVenta.ImporteTotal) ' "Sub Total")
            '' ''   End If


            '' ''   ' cuenta -- ventas locales -  
            '' ''   sqlCuenta.EliminoUnaCuenta(rubro.IdRubro, cuenta.IdPlanCuenta, cuentaV.idCuentaHaber)
            '' ''   If cuentaV.idCuentaHaber <> 0 Then
            '' ''      sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''                           , cuenta.IdPlanCuenta _
            '' ''                           , cuentaV.Tipo _
            '' ''                           , cuentaV.idCuentaHaber _
            '' ''                           , False _
            '' ''                           , True _
            '' ''                           , ContabilidadProcesos.ConstantesVenta.ImporteBruto)
            '' ''   End If

            '' ''   ' cuenta IVA DF --- 
            '' ''   If Not sqlCuenta.Existe(rubro.IdRubro, idCuentaImpuestoHaber, cuenta.IdPlanCuenta) Then
            '' ''      sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''                              , cuenta.IdPlanCuenta _
            '' ''                              , cuentaV.Tipo _
            '' ''                              , idCuentaImpuestoHaber _
            '' ''                              , False _
            '' ''                              , True _
            '' ''                              , ContabilidadProcesos.ConstantesVenta.IvaTotal) '"Total")
            '' ''   End If


            '' ''   '#########################'STOCKXVTAS ###################################

            '' ''   sqlCuenta.CuentaRubro_D(cuenta.IdPlanCuenta, _
            '' ''                           rubro.IdRubro, _
            '' ''                           Entidades.ContabilidadProceso.Procesos.STOCKXVTAS.ToString())

            '' ''   ' cuenta COSTO de VENTA de MATERIALES ---fija
            '' ''   If Not sqlCuenta.Existe(rubro.IdRubro, 40102001, cuenta.IdPlanCuenta) Then
            '' ''      sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''                           , cuenta.IdPlanCuenta _
            '' ''                           , Entidades.ContabilidadProceso.Procesos.STOCKXVTAS.ToString() _
            '' ''                           , 40102001 _
            '' ''                           , True _
            '' ''                           , False _
            '' ''                           , ContabilidadProcesos.ConstantesVenta.ImporteTotal)
            '' ''   End If

            '' ''   ' cuenta IVA DF --- la misma que se ingresa por pantalla para la compra
            '' ''   If Not sqlCuenta.Existe(rubro.IdRubro, idCuentaImpuestoDebe, cuenta.IdPlanCuenta) Then
            '' ''      If cuenta.idCuentaDebe <> 0 Then
            '' ''         sqlCuenta.CuentaRubro_I(rubro.IdRubro _
            '' ''                                 , cuenta.IdPlanCuenta _
            '' ''                                 , Entidades.ContabilidadProceso.Procesos.STOCKXVTAS.ToString() _
            '' ''                                 , idCuentaImpuestoDebe _
            '' ''                                 , False _
            '' ''                                 , True _
            '' ''                                 , ContabilidadProcesos.ConstantesVenta.ImporteBruto) 'sub total
            '' ''      End If
            '' ''   End If
            '' ''End If

         Case TipoSP._D

            '' ''If tieneModuloContabilidad Then

            '' ''   ' validar contabilidad! si tiene asientos no se pueden eliminar!!!

            '' ''   ' POR AHORA ELIMINO EL PLAN 1 pero tendria que eliminar todos los planes
            '' ''   cuenta.IdPlanCuenta = 1

            '' ''   sqlCuenta.CuentaRubro_D(cuenta.IdPlanCuenta, _
            '' ''                           rubro.IdRubro, _
            '' ''                          Entidades.ContabilidadProceso.Procesos.COMPRAS.ToString())

            '' ''   sqlCuenta.CuentaRubro_D(cuenta.IdPlanCuenta, _
            '' ''                        rubro.IdRubro, _
            '' ''                        ContabilidadProceso.Procesos.VENTAS.ToString())

            '' ''   sqlCuenta.CuentaRubro_D(cuenta.IdPlanCuenta, _
            '' ''                        rubro.IdRubro, _
            '' ''                        Entidades.ContabilidadProceso.Procesos.STOCKXVTAS.ToString())

            '' ''End If

            rRubrosDescRecar.BorraDesdeRubro(rubro)
            sql.Rubros_D(rubro.IdRubro)


      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Rubro, ByVal dr As DataRow)

      With o
         .IdRubro = Integer.Parse(dr(Entidades.Rubro.Columnas.IdRubro.ToString()).ToString())
         .NombreRubro = dr(Entidades.Rubro.Columnas.NombreRubro.ToString()).ToString()
         If Not String.IsNullOrEmpty(dr(Entidades.Rubro.Columnas.IdActividad.ToString()).ToString()) Then
            .Actividad = New Reglas.Actividades(Me.da).GetUno(dr(Entidades.Actividad.Columnas.IdProvincia.ToString()).ToString(), Integer.Parse(dr(Entidades.Actividad.Columnas.IdActividad.ToString()).ToString()))
         End If
         .ComisionPorVenta = Decimal.Parse(dr(Entidades.Rubro.Columnas.ComisionPorVenta.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.Rubro.Columnas.UnidHasta1.ToString()).ToString()) Then
            .UnidHasta1 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UnidHasta1.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Rubro.Columnas.UnidHasta2.ToString()).ToString()) Then
            .UnidHasta2 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UnidHasta2.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Rubro.Columnas.UnidHasta3.ToString()).ToString()) Then
            .UnidHasta3 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UnidHasta3.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Rubro.Columnas.UnidHasta4.ToString()).ToString()) Then
            .UnidHasta4 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UnidHasta4.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Rubro.Columnas.UnidHasta5.ToString()).ToString()) Then
            .UnidHasta5 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UnidHasta5.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Rubro.Columnas.UHPorc1.ToString()).ToString()) Then
            .UHPorc1 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UHPorc1.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Rubro.Columnas.UHPorc2.ToString()).ToString()) Then
            .UHPorc2 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UHPorc2.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Rubro.Columnas.UHPorc3.ToString()).ToString()) Then
            .UHPorc3 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UHPorc3.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Rubro.Columnas.UHPorc4.ToString()).ToString()) Then
            .UHPorc4 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UHPorc4.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Rubro.Columnas.UHPorc5.ToString()).ToString()) Then
            .UHPorc5 = Decimal.Parse(dr(Entidades.Rubro.Columnas.UHPorc5.ToString()).ToString())
         End If

         If Not String.IsNullOrEmpty(dr(Entidades.Rubro.Columnas.Orden.ToString()).ToString()) Then
            .Orden = Integer.Parse(dr(Entidades.Rubro.Columnas.Orden.ToString()).ToString())
         End If

         If Not String.IsNullOrEmpty(dr(Entidades.Rubro.Columnas.DescuentoRecargoPorc1.ToString()).ToString()) Then
            .DescuentoRecargoPorc1 = Decimal.Parse(dr(Entidades.Rubro.Columnas.DescuentoRecargoPorc1.ToString()).ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Rubro.Columnas.DescuentoRecargoPorc2.ToString()).ToString()) Then
            .DescuentoRecargoPorc2 = Decimal.Parse(dr(Entidades.Rubro.Columnas.DescuentoRecargoPorc2.ToString()).ToString())
         End If

         .CodigoExportacion = dr.Field(Of String)(Entidades.Rubro.Columnas.CodigoExportacion.ToString())

         .RubroComisionPorDescuento = New RubrosComisionesPorDescuento(da).GetTodos(.IdRubro)
         .IdRubroTiendaNube = dr("IdRubroTiendaNube").ToString
         .IdRubroMercadoLibre = dr("IdRubroMercadoLibre").ToString
         .idRubroArborea = dr("idRubroarborea").ToString

         '' ''If Publicos.TieneModuloContabilidad Then

         '' ''   Dim oCuentas As Entidades.ucCuentaDHvb = New Entidades.ucCuentaDHvb() ' compras
         '' ''   Dim oCuentasVentas As Entidades.ucCuentaDHvb = New Entidades.ucCuentaDHvb() ' ventas

         '' ''   If String.IsNullOrEmpty(dr("idCuentaDebe").ToString()) Then
         '' ''      oCuentas.idCuentaDebe = 0
         '' ''   Else
         '' ''      oCuentas.idCuentaDebe = Integer.Parse(dr("idCuentaDebe").ToString())
         '' ''   End If
         '' ''   If String.IsNullOrEmpty(dr("idCuentaHaber").ToString()) Then
         '' ''      oCuentas.idCuentaHaber = 0
         '' ''   Else
         '' ''      oCuentas.idCuentaHaber = Integer.Parse(dr("idCuentaHaber").ToString())
         '' ''   End If
         '' ''   .entidadCuentas.Add(oCuentas)

         '' ''   ' para ventas
         '' ''   If String.IsNullOrEmpty(dr("idCuentaDebeV").ToString()) Then
         '' ''      oCuentasVentas.idCuentaDebe = 0
         '' ''   Else
         '' ''      oCuentasVentas.idCuentaDebe = Integer.Parse(dr("idCuentaDebeV").ToString())
         '' ''   End If
         '' ''   If String.IsNullOrEmpty(dr("idCuentaHaberV").ToString()) Then
         '' ''      oCuentasVentas.idCuentaHaber = 0
         '' ''   Else
         '' ''      oCuentasVentas.idCuentaHaber = Integer.Parse(dr("idCuentaHaberV").ToString())
         '' ''   End If
         '' ''   .entidadCuentasVentas.Add(oCuentasVentas)

         '' ''End If

      End With

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)

      Me.EjecutaSP(entidad, TipoSP._I)

   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)

      Me.EjecutaSP(entidad, TipoSP._U)

   End Sub

   Public Function GetTodos() As List(Of Entidades.Rubro)
      Try
         Me.da.OpenConection()

         Return _GetTodos()
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function _GetTodos() As List(Of Entidades.Rubro)
      Try
         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.Rubro
         Dim oLis As List(Of Entidades.Rubro) = New List(Of Entidades.Rubro)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.Rubro()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next
         Return oLis
      Catch
         Throw
      End Try
   End Function

   Public Function GetUno(ByVal IdRubro As Integer) As Entidades.Rubro
      Dim sql As SqlServer.Rubros = New SqlServer.Rubros(Me.da)
      Dim dt As DataTable = sql.Rubros_G1(IdRubro)
      Dim o As Entidades.Rubro = New Entidades.Rubro()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el Rubro.")
      End If
      Return o
   End Function

   Public Function GetPorCodigo(ByVal codigo As Integer) As DataTable

      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim stb As StringBuilder = New StringBuilder("")

         With stb
            .Append("SELECT IdRubro,")
            .Append("	NombreRubro,")
            .Append("	IdActividad")
            .Append("  FROM Rubros")
            If codigo > 0 Then
               .Append("	WHERE IdRubro= ")
               .Append(codigo)
            End If
            .Append("	ORDER BY NombreRubro")
         End With

         Return da.GetDataTable(stb.ToString())
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Function

   Public Function GetPorNombre(ByVal nombre As String) As DataTable
      Dim blnAbreConexion As Boolean = da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()

         Dim stb As StringBuilder = New StringBuilder("")

         With stb
            .Append("SELECT IdRubro,")
            .Append("	NombreRubro,")
            .Append("	IdActividad")
            .Append("  FROM Rubros")
            .Append("	WHERE NombreRubro LIKE '%")
            .Append(nombre)
            .Append("%' ")
            .Append("	ORDER BY NombreRubro")
         End With

         Return da.GetDataTable(stb.ToString())
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Function

   Public Function GetPorNombreExacto(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT IdRubro,")
         .AppendLine("       NombreRubro,")
         .AppendLine("       IdActividad")
         .AppendLine("  FROM Rubros")
         .AppendLine(" WHERE NombreRubro = '" & nombre & "' ")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Rubros(da).GetCodigoMaximo()
   End Function

   Public Function GetOrdenMaximo() As Integer
      Return New SqlServer.Rubros(da).GetOrdenMaximo()
   End Function

   Public Function GetPrimerRubro() As Integer
      Return New SqlServer.Rubros(da).Rubros_GetPrimerRubro()
   End Function

   '# Tienda Nube
#Region "Tiendas Web"

   Public Sub GuardarIdRubroTiendaNube(idRubro As Integer, idRubroTiendaNube As String)
      Dim sql As SqlServer.Rubros = New SqlServer.Rubros(da)
      Me.EjecutaSoloConTransaccion(Function()
                                      sql.GuardarIdRubroTiendaNube(idRubro, idRubroTiendaNube)
                                      Return True
                                   End Function)
   End Sub

   Public Function GetRubrosTiendasWeb(idTiendaWeb As Entidades.TiendasWeb) As DataTable
      Return New SqlServer.Rubros(da).GetRubrosTiendasWeb(idTiendaWeb)
   End Function

   Public Sub GuardarIdRubroTiendaWeb(idTiendaWeb As String, idRubro As Integer, idRubroTiendaWeb As String)
      Dim sql As SqlServer.Rubros = New SqlServer.Rubros(da)
      Me.EjecutaSoloConTransaccion(Function()
                                      sql.GuardarIdRubroTiendaWeb(idTiendaWeb, idRubro, idRubroTiendaWeb)
                                      Return True
                                   End Function)
   End Sub

#End Region

#End Region

End Class