Imports Eniac.Entidades
Imports Infragistics.Documents.Excel
Public Class PlanillaDeCaja

#Region "Campos"

   Private _planillaActual As Entidades.Caja
   Private _CheqPropio As Boolean = False
   Private _idSucursal As Integer = 0
   Private _idCaja As Integer = 0
   Private _utilizaCentroCostos As Boolean

   Private _cargoBienLaPantalla As Boolean
   Private _mensajeDeErrorEnCarga As String = ""

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try
         Cursor = Cursors.WaitCursor

         _cargoBienLaPantalla = False

         'Lo hago primero porque al Asiganar la Caja se cargan los datos.
         If Not Reglas.Publicos.CajaPlanillaMuestraProductosConAlerta Then
            utcDetalle.Tabs.Remove(Me.utcDetalle.Tabs("ProductosConAlerta"))
         End If

         If Not Reglas.Publicos.CajaPlanillaMuestraVentasEnCtaCte Then
            utcDetalle.Tabs.Remove(Me.utcDetalle.Tabs("VentasEnCtaCte"))
         End If

         Dim pub = New Publicos()

         _utilizaCentroCostos = Reglas.ContabilidadPublicos.UtilizaCentroCostos

         _idSucursal = actual.Sucursal.Id

         'carga las cajas.
         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = False, blnCajasModificables As Boolean = False

         pub.CargaComboCajas(cmbCajas, _idSucursal, miraUsuario:=True, miraPC:=Eniac.Reglas.Publicos.PlanillaCajaPredPorPC, cajasModificables:=False)
         SeteaBotonesUsuario()
         SetearColumnas()
         cmbCajas.Focus()

         ugMovimientos.InicializaGrilla()
         ugMovimientos.AgregarFiltroEnLinea({"NombreCuentaCaja", "Observacion"})

         PreferenciasLeer(ugMovimientos, tsbPreferencias)

         _cargoBienLaPantalla = True
      Catch ex As Exception
         _mensajeDeErrorEnCarga = ex.Message
         _cargoBienLaPantalla = False
      End Try

   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(
         Sub()
            If Not _cargoBienLaPantalla Then
               ShowMessage(_mensajeDeErrorEnCarga)
               Close()
            End If
         End Sub)
      Cursor = Cursors.Default
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() CargarPlanillasYMovimientos())
   End Sub

   Private Sub tsbNuevoMovimiento_Click(sender As Object, e As EventArgs) Handles tsbNuevoMovimiento.Click
      TryCatched(
         Sub()
            Using detalle = New CajaDetalles()
               detalle.Operacion = Reglas.CajaDetalles.TipoOperacion.Nuevo
               detalle.NumeroPlanilla = _planillaActual.NumeroPlanilla
               detalle.IdSucursalMovimiento = actual.Sucursal.IdSucursal
               detalle.CajaNombre.IdCaja = _idCaja
               detalle.CajaNombre.NombreCaja = cmbCajas.Text

               detalle.ShowDialog()

               CargarPlanillasYMovimientos()
            End Using
         End Sub)
   End Sub

   Private Sub tsbEditarMovimiento_Click(sender As Object, e As EventArgs) Handles tsbEditarMovimiento.Click
      TryCatched(
         Sub()
            Dim dr = ugMovimientos.FilaSeleccionada(Of DataRow)
            If dr IsNot Nothing Then
               Using frmDetalle = New CajaDetalles()
                  Dim nroMovimiento = dr.Field(Of Integer)("NumeroMovimiento")

                  frmDetalle.Operacion = Reglas.CajaDetalles.TipoOperacion.Modificacion

                  If Reglas.Publicos.TieneModuloContabilidad Then
                     Dim oCajaDetalles = New Reglas.CajaDetalles()
                     Dim eCajaDetalles = oCajaDetalles.GetUna(dr.Field(Of Integer)("IdSucursal"), dr.Field(Of Integer)("IdCaja"),
                                                              dr.Field(Of Integer)("NumeroPlanilla"), dr.Field(Of Integer)("NumeroMovimiento"))

                     Dim ctbl = New Reglas.Contabilidad()
                     If ctbl.AsientoProcesadoComoDefinitivo(eCajaDetalles.IdEjercicio, eCajaDetalles.IdPlanCuenta, eCajaDetalles.IdAsiento) Then
                        MessageBox.Show("No es posible Modificar el movimiento de caja porque el asiento contable asociado ya fue procesado como DEFINITIVO." + Environment.NewLine + Environment.NewLine +
                                        "Se mostrará el movimiento en modo consulta.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        frmDetalle.Operacion = Reglas.CajaDetalles.TipoOperacion.Consulta
                     End If
                  End If

                  frmDetalle.NumeroPlanilla = _planillaActual.NumeroPlanilla
                  frmDetalle.NroDeMovimiento = nroMovimiento
                  frmDetalle.IdSucursalMovimiento = actual.Sucursal.IdSucursal
                  frmDetalle.CajaNombre.IdCaja = _idCaja
                  frmDetalle.CajaNombre.NombreCaja = cmbCajas.Text

                  frmDetalle.ShowDialog()

                  Dim i = ugMovimientos.ActiveRow.Index

                  CargarPlanillasYMovimientos()
                  Try
                     ugMovimientos.ActiveCell = ugMovimientos.Rows(i).Cells(0)
                  Catch ex As IndexOutOfRangeException
                     If ugMovimientos.Rows.Count > 0 Then
                        ugMovimientos.ActiveCell = ugMovimientos.Rows(ugMovimientos.Rows.Count - 1).Cells(0)
                     End If
                  End Try
               End Using
            Else
               MessageBox.Show("Por favor seleccione el movimiento a modificar.", "Modificar Movimiento.",
                               MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
         End Sub)
   End Sub

   Private Sub tsbEliminarMovimiento_Click(sender As Object, e As EventArgs) Handles tsbEliminarMovimiento.Click
      TryCatched(
         Sub()
            'If Me.ugMovimientos.ActiveCell IsNot Nothing Then
            Dim dr = ugMovimientos.FilaSeleccionada(Of DataRow)
            If dr IsNot Nothing Then

               If Not dr.Field(Of Boolean)("EsModificable") Then
                  ShowMessage("Este detalle no se puede Eliminar.")
                  Exit Sub
               End If

               Dim rCajaDetalles = New Reglas.CajaDetalles()
               Dim cajaDetalles = New Entidades.CajaDetalles()

               cajaDetalles = rCajaDetalles.GetUna(actual.Sucursal.Id, dr.Field(Of Integer)("IdCaja"),
                                                   dr.Field(Of Integer)("NumeroPlanilla"), dr.Field(Of Integer)("NumeroMovimiento"))

               If Reglas.Publicos.ContabilidadEjecutarEnLinea Then
                  Dim oEjercicio = New Reglas.ContabilidadEjercicios()

                  Dim codEjeVigente = oEjercicio.GetEjercicioVigente(dr.Field(Of Date)("fechaMovimiento"))  'obtengo el ejercicio vigente
                  If codEjeVigente = 0 Then
                     Dim strMensaje As String
                     strMensaje = "No puede eliminar el movimiento, el periódo contable esta cerrado"
                     ShowMessage(strMensaje)
                     Exit Sub
                  End If
                  Dim idPeriodoActual = oEjercicio.GetPeriodoActual(codEjeVigente, dr.Field(Of Date)("fechaMovimiento"))

                  If (oEjercicio.EstaPeriodoCerrado(codEjeVigente, idPeriodoActual)) Then 'valido que el periodo no este cerrado
                     Dim strMensaje As String
                     strMensaje = "No puede eliminar el movimiento, el periódo contable esta cerrado"
                     MessageBox.Show(strMensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                     Exit Sub
                  Else

                     Dim ctbl = New Reglas.Contabilidad()
                     If ctbl.AsientoProcesadoComoDefinitivo(cajaDetalles.IdEjercicio, cajaDetalles.IdPlanCuenta, cajaDetalles.IdAsiento) Then
                        Throw New Exception("No es posible Eliminar el movimiento de caja porque el asiento contable asociado ya fue procesado como DEFINITIVO.")
                     End If
                  End If
               End If

               'Si tiene monto de Cheques y es un ingreso, controlo que los cheques involucrados NO tengan egreso.
               If dr.Field(Of Decimal)("ImporteCheques") > 0 And dr.Field(Of String)("IdTipoMovimiento") = "I" Then
                  Dim oCheq = New Reglas.Cheques()

                  Dim intCheqUsados = oCheq.GetCantChequesEgresados(_idSucursal, txtNroPlanillaActual.Text.ValorNumericoPorDefecto(0I), dr.Field(Of Integer)("NumeroMovimiento"), Me._CheqPropio)

                  If intCheqUsados > 0 Then
                     Dim strMensaje As String
                     strMensaje = "No puede eliminar el movimiento de ingreso porque tiene " & intCheqUsados.ToString() & " cheque(s) con movimiento(s) de EGRESO"
                     MessageBox.Show(strMensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                     Exit Sub
                  End If

               End If

               Dim cupones = New Reglas.TarjetasCupones().GetTodosDeMovimientoCaja(cajaDetalles)
               If cupones.AnySecure() Then
                  If cajaDetalles.IdTipoMovimiento = Entidades.CajaDetalles.TipoMovimiento.Ingreso Then
                     Dim cuponesError = cupones.Where(Function(c) c.IdEstadoTarjeta <> Entidades.TarjetaCupon.Estados.ENCARTERA)
                     If cuponesError.AnySecure() Then
                        ShowMessage(String.Format("No puede eliminar el movimiento de Ingreso porque tiene {0} cupones en con estado diferente a EN CARTERA", cuponesError.Count))
                        Exit Sub
                     End If
                  ElseIf cajaDetalles.IdTipoMovimiento = Entidades.CajaDetalles.TipoMovimiento.Egreso Then
                     Dim cuponesError = cupones.Where(Function(c) c.IdEstadoTarjeta <> Entidades.TarjetaCupon.Estados.EGRESOCAJA)
                     If cuponesError.AnySecure() Then
                        ShowMessage(String.Format("No puede eliminar el movimiento de Egreso porque tiene {0} cupones en con estado diferente a EGRESO CAJA", cuponesError.Count))
                        Exit Sub
                     End If
                  End If
               End If

               Dim Pregunta As DialogResult = MessageBox.Show("Realmente desea eliminar el movimiento seleccionado?",
                                                               "Eliminar Movimiento",
                                                               MessageBoxButtons.YesNo,
                                                               MessageBoxIcon.Question,
                                                               MessageBoxDefaultButton.Button2)

               If Pregunta = Windows.Forms.DialogResult.Yes Then

                  Dim i As Integer = ugMovimientos.ActiveRow.Index

                  BorrarMovimiento(dr)

                  CargarPlanillasYMovimientos()

                  If i - 1 >= 0 Then
                     ugMovimientos.ActiveRow = ugMovimientos.Rows(i - 1)
                  End If

                  MessageBox.Show("El movimiento ha sido eliminado con exito.", "Eliminar Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If

            End If
         End Sub)
   End Sub

   Private Sub tsbImprimirMovimiento_Click(sender As Object, e As EventArgs) Handles tsbImprimirMovimiento.Click
      TryCatched(
      Sub()
         If ugMovimientos.ActiveCell Is Nothing Then Exit Sub

         Dim numeroPlanilla = txtNroPlanillaActual.Text.ValorNumericoPorDefecto(0I)
         Dim numeroMovimiento = Integer.Parse(ugMovimientos.ActiveCell.Row.Cells("NumeroMovimiento").Value.ToString())

         Dim imp = New ImprimirMovimientoCaja()
         imp.Imprimir(_idSucursal, _idCaja, numeroPlanilla, numeroMovimiento, visualiza:=True)
      End Sub)
   End Sub

   Private Sub tsbFinalizarPlanilla_Click(sender As Object, e As EventArgs) Handles tsbFinalizarPlanilla.Click

      Try

         Dim mensaje As String
         mensaje = "Cerrar la planilla implica abrir una nueva y convertirla en actual, realmente desea cerrar la planilla actual? "

         Dim resultado As Windows.Forms.DialogResult
         resultado = MessageBox.Show(mensaje, "Cerrar Planilla", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

         If resultado = Windows.Forms.DialogResult.Yes Then

            'Actualizo a la situacion actual porque puedo hacer algun moviento desde otra PC, o bien dejar esta pantalla levantada con un saldo viejo.
            Me.CargarPlanillasYMovimientos()

            Dim oCheques As Reglas.Cheques = New Reglas.Cheques()
            If oCheques.GetSaldoChequesEnCartera(Me._planillaActual.IdSucursal, Me._idCaja) <> Decimal.Parse(Me.txtPACCheques.Text) Then
               MessageBox.Show("Tiene Diferencia en el Saldo de Cheques con aquellos EN CARTERA." & Chr(13) & Chr(13) & "NO podra Finalizar la Planilla. Por favor contactese con Sistemas!!", "Cerrar Planilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Exit Sub
            End If

            Dim oCaja = New Reglas.Cajas()
            ''-- REQ-43574.- ------------------------------------------------------------------------------------------------------------
            Dim oCupones = New Reglas.TarjetasCupones()
            If oCupones.GetSaldoCuponesEnCartera(_planillaActual.IdSucursal, _idCaja) <> Decimal.Parse(Me.txtPACTarjetas.Text) Then
               MessageBox.Show("Tiene Diferencia en el Saldo de Tarjetas con aquellas EN CARTERA." & Chr(13) & Chr(13) & "NO podra Finalizar la Planilla. Por favor contactese con Sistemas!!", "Cerrar Planilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Exit Sub
            End If
            ''---------------------------------------------------------------------------------------------------------------------------
            'Ver si la caja se cerro en otra PC
            Dim cajas As Entidades.Caja = New Reglas.Cajas().GetPlanillaCaja(Me._planillaActual.IdSucursal, Me._planillaActual.IdCaja, Me._planillaActual.NumeroPlanilla)
            If cajas.BancosSaldoFinal <> 0 Or cajas.ChequesSaldoFinal <> 0 Or cajas.DolaresSaldoFinal <> 0 Or cajas.PesosSaldoFinal <> 0 Or
                cajas.RetencionesSaldoFinal <> 0 Or cajas.TarjetasSaldoFinal <> 0 Or cajas.TicketsSaldoFinal <> 0 Then
               MessageBox.Show("Ya planilla ya fue cerrada!", "Cerrar Planilla", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Exit Sub
            Else
               oCaja.CerrarPlanilla(_planillaActual.IdSucursal, _idCaja, _planillaActual.NumeroPlanilla)

               Dim oPlanilla As Entidades.Caja = New Reglas.Cajas().GetUltimaPlanilla(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbCajas.SelectedValue.ToString()))
               'Imprimir Planilla
               Using oImprimirPlanilla = New ImprimirPlanilla(actual.Sucursal.IdSucursal,
                                                              Integer.Parse(cmbCajas.SelectedValue.ToString()),
                                                              oPlanilla.NumeroPlanilla)
                  oImprimirPlanilla.ShowDialog()
               End Using
               Me.CargarPlanillasYMovimientos()

            End If

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub tsbImprimirPlanilla_Click(sender As Object, e As EventArgs) Handles tsbImprimirPlanilla.Click

      TryCatched(
         Sub()
            Using frmPrintPlanilla As ImprimirPlanilla = New ImprimirPlanilla(actual.Sucursal.IdSucursal,
                                                                              Integer.Parse(cmbCajas.SelectedValue.ToString()),
                                                                              _planillaActual.NumeroPlanilla)
               frmPrintPlanilla.ShowDialog()
            End Using
         End Sub)
   End Sub

   Private Sub tsbCerrar_Click(sender As Object, e As EventArgs) Handles tsbCerrar.Click
      Close()
   End Sub

   Private Sub ugMovimientos_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugMovimientos.DoubleClickRow
      tsbEditarMovimiento.PerformClick()
   End Sub


   Private Sub cmbCajas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCajas.SelectedIndexChanged
      TryCatched(
         Sub()
            _idCaja = cmbCajas.ValorSeleccionado(Of Integer)

            CargarPlanillasYMovimientos()
            SeteaBotonesUsuario()
         End Sub)
   End Sub

   Private Sub CargarColumnasASumar()

      'Grilla Productos con Alerta de Caja.
      ugProductosAlertaCaja.AgregarTotalesSuma({"ImporteTotalNeto", "ImporteTotal", "Kilos", "Cantidad"})

      'Grilla Ventas en Cta.Cte.
      ugProductosAlertaCaja.AgregarTotalesSuma({"SubTotal", "TotalImpuestos", "ImporteTotal"})
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub CargarPlanillasYMovimientos()

      CargarPlanillaAnterior()
      CargarPlanillaActual()
      CargarSaldosActuales()
      CargarMovimientos()

      SeteaBotonesUsuario()

      If utcDetalle.Tabs.Exists("ProductosConAlerta") Then
         CargarProductosAlerta()
      End If

      If utcDetalle.Tabs.Exists("VentasEnCtaCte") Then
         CargarVentasEnCtaCte()
      End If

   End Sub

   Friend Shared Sub SetearColumnasMovimientos(ugMovimientos As UltraGrid, _utilizaCentroCostos As Boolean)

      With ugMovimientos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         .Columns("IdSucursal").OcultoPosicion(True, pos)
         .Columns("IdCaja").OcultoPosicion(True, pos)
         .Columns("NombreCaja").OcultoPosicion(True, pos)
         .Columns("FechaPlanilla").OcultoPosicion(True, pos)
         .Columns("NumeroPlanilla").OcultoPosicion(True, pos)

         .Columns("NumeroMovimiento").FormatearColumna("Nro.", pos, 40, HAlign.Right)

         .Columns("IdCuentaCaja").OcultoPosicion(True, pos)

         .Columns("NombreCuentaCaja").FormatearColumna("Cuenta", pos, 120)
         .Columns("IdGrupoCuenta").FormatearColumna("Grupo", pos, 60)
         .Columns("FechaMovimiento").FormatearColumna("Fecha", pos, 70, HAlign.Center, , "dd/MM/yyyy")
         .Columns("Hora").FormatearColumna("Hora", pos, 40, HAlign.Center, , "HH:mm")
         .Columns("IdTipoMovimiento").FormatearColumna("T", pos, 20, HAlign.Center)

         .Columns("NombreTipoMovimiento").OcultoPosicion(True, pos)

         .Columns("ImportePesos").FormatearColumna("Pesos", pos, 75, HAlign.Right, , "N2")
         .Columns("ImporteCheques").FormatearColumna("Cheques", pos, 75, HAlign.Right, , "N2")
         .Columns("ImporteTarjetas").FormatearColumna("Tarjetas", pos, 75, HAlign.Right, , "N2")
         .Columns("ImporteDolares").FormatearColumna("Dolares", pos, 75, HAlign.Right, , "N2")
         .Columns("ImporteRetenciones").FormatearColumna("Retenciones", pos, 75, HAlign.Right, , "N2")
         .Columns("ImporteBancos").FormatearColumna("Bancos", pos, 75, HAlign.Right, , "N2")
         .Columns("ImporteBancosDolares").FormatearColumna("Bancos Dolares", pos, 75, HAlign.Right, , "N2")
         .Columns("Total").FormatearColumna("Total", pos, 75, HAlign.Right, , "N2")

         .Columns("IdUsuario").FormatearColumna("Usuario", pos, 75)
         .Columns("EsModificable").FormatearColumna("Mod.", pos, 35)
         .Columns("GeneraContabilidad").FormatearColumna("Cntb.", pos, 35)
         .Columns("Observacion").FormatearColumna("Observación", pos, 400)

         .Columns("CotizacionDolar").FormatearColumna("Cotización", pos, 75, HAlign.Right, , "N2")
         .Columns("ImporteTickets").FormatearColumna("Tickets", pos, 75, HAlign.Right, , "N2")

         .Columns("IdConceptoCM05").OcultoPosicion(hidden:=True, pos)
         .Columns("DescripcionConceptoCM05").FormatearColumna("Concepto CM05", pos, 150, , Not Reglas.Publicos.AFIPUtilizaCM05)
         .Columns("TipoConceptoCM05").FormatearColumna("Tipo CM05", pos, 80, HAlign.Center, Not Reglas.Publicos.AFIPUtilizaCM05)


         .Columns("IdPlanCuenta").FormatearColumna("P.", pos, 25, HAlign.Right, Not Reglas.Publicos.TieneModuloContabilidad)

         .Columns("IdAsiento").FormatearColumna("Asiento", pos, 54, HAlign.Right, Not Reglas.Publicos.TieneModuloContabilidad)
         .Columns("IdCentroCosto").FormatearColumna("C. C.", pos, 54, HAlign.Right, Not Reglas.Publicos.TieneModuloContabilidad)
         .Columns("NombreCentroCosto").FormatearColumna("Centro de Costos", pos, 150, , Not _utilizaCentroCostos)

         .Columns("IdEjercicio").Hidden = True
         .Columns("IdTipoComprobante").Hidden = True
         .Columns("NumeroDeposito").Hidden = True
         .Columns("IdMonedaImporteBancos").Hidden = True

      End With

      ugMovimientos.AgregarTotalesSuma({"ImportePesos", "ImporteDolares", "ImporteCheques", "ImporteBancos", "ImporteBancosDolares", "ImporteTarjetas", "ImporteRetenciones", "ImporteTickets", "Total"})
      ugMovimientos.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True

   End Sub

   Private Sub SetearColumnas()

      SetearColumnasMovimientos(ugMovimientos, _utilizaCentroCostos)

      With Me.ugVentasEnCtaCte.DisplayLayout.Bands(0)

         For Each columna As UltraWinGrid.UltraGridColumn In .Columns
            columna.Hidden = True
         Next

         '.Columns("Ver").Hidden = False
         .Columns("DescripcionAbrev").Hidden = False
         .Columns("Letra").Hidden = False
         .Columns("CentroEmisor").Hidden = False
         .Columns("NumeroComprobante").Hidden = False
         .Columns("Fecha").Hidden = False
         .Columns("NombreCliente").Hidden = False
         .Columns("NombreCategoriaFiscal").Hidden = False
         .Columns("SubTotal").Hidden = False
         .Columns("TotalImpuestos").Hidden = False
         .Columns("ImporteTotal").Hidden = False
         .Columns("Usuario").Hidden = False
         .Columns("NombreVendedor").Hidden = False
         .Columns("Observacion").Hidden = False
      End With

      Me.CargarColumnasASumar()

   End Sub

   Private Sub SeteaBotonesUsuario()
      Dim oCajasUsuarios As Reglas.CajasUsuarios = New Reglas.CajasUsuarios()
      Dim dt As DataTable = New DataTable()
      dt = oCajasUsuarios.GetCajaPorUsuario(Integer.Parse(Me.cmbCajas.SelectedValue.ToString()), Me._idSucursal, actual.Nombre)
      If Not Boolean.Parse(dt.Rows(0).Item("PermitirEscritura").ToString()) Then
         tsbNuevoMovimiento.Visible = False
         tsbEditarMovimiento.Visible = False
         tsbFinalizarPlanilla.Visible = False
         tsbEliminarMovimiento.Visible = False
         ToolStripSeparator1.Visible = False
         ToolStripSeparator4.Visible = False
         ToolStripSeparator5.Visible = False
         ToolStripSeparator2.Visible = False
      Else
         tsbNuevoMovimiento.Visible = True
         tsbEditarMovimiento.Visible = True
         tsbFinalizarPlanilla.Visible = True
         tsbEliminarMovimiento.Visible = True
         ToolStripSeparator1.Visible = False
         ToolStripSeparator4.Visible = True
         ToolStripSeparator5.Visible = True
         ToolStripSeparator2.Visible = True
      End If
   End Sub

   Private Sub CargarProductosAlerta()

      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

      Me.ugProductosAlertaCaja.DataSource = oVentas.GetProductosAlertaPorCaja(Me._idSucursal, Me._idCaja, Me._planillaActual.NumeroPlanilla)

   End Sub

   Private Sub CargarVentasEnCtaCte()
      ugVentasEnCtaCte.DataSource = New Reglas.Ventas().GetInfVentasEnCtaCtePorCaja(_idSucursal, _idCaja, _planillaActual.NumeroPlanilla)
   End Sub

   Private Sub CargarMovimientos()
      ugMovimientos.DataSource = New Reglas.CajaDetalles().GetTodas(_idSucursal, _idCaja, _planillaActual.NumeroPlanilla, OrdenarPor:="FECHA")
   End Sub

   Private Sub CargarPlanillaAnterior()
      Dim oPlanilla = New Reglas.Cajas().GetUltimaPlanilla(_idSucursal, _idCaja, Reglas.Base.AccionesSiNoExisteRegistro.Vacio)
      With oPlanilla
         txtNroPlanillaAnterior.Text = .NumeroPlanilla.ToString()
         txtPAFecha.Text = .FechaPlanilla.ToString("dd/MM/yyyy")
         txtPAEfectivo.Text = .PesosSaldoFinal.ToString("N2")
         txtPADolares.Text = .DolaresSaldoFinal.ToString("N2")
         txtPATickets.Text = .TicketsSaldoFinal.ToString("N2")
         txtPARetenciones.Text = .RetencionesSaldoFinal.ToString("N2")
         txtPACheques.Text = .ChequesSaldoFinal.ToString("N2")
         txtPATarjetas.Text = .TarjetasSaldoFinal.ToString("N2")
         txtPABancos.Text = .BancosSaldoFinal.ToString("N2")
         txtPABancosDolares.Text = .BancosDolaresSaldoFinal.ToString("N2")
      End With
   End Sub

   Private Sub CargarPlanillaActual()
      Dim oPlanilla = New Reglas.Cajas().GetPlanillaActual(_idSucursal, _idCaja)
      If oPlanilla IsNot Nothing Then
         With oPlanilla

            'If _planillaActual Is Nothing Then
            '   _planillaActual = New Entidades.Caja(_idSucursal, actual.Nombre, actual.Pwd)
            'End If

            _planillaActual = oPlanilla

            txtNroPlanillaActual.Text = _planillaActual.NumeroPlanilla.ToString()
            txtPACFecha.Text = _planillaActual.FechaPlanilla.ToString("dd/MM/yyyy")
         End With
      Else
         CrearNuevaPlanilla()
         CargarPlanillaActual()
      End If
   End Sub

   Public Sub CargarSaldosActuales()

      'Dim oCaja = New Reglas.Cajas()

      Dim saldos = New Reglas.Cajas().GetSaldosActuales(_idSucursal, _idCaja, _planillaActual.NumeroPlanilla)

      'Dim sPesos As Decimal = oCaja.GetSaldoPesos(Me._idSucursal, Me._idCaja, Me._planillaActual.NumeroPlanilla)
      'Dim sDolares As Decimal = oCaja.GetSaldoDolares(Me._idSucursal, Me._idCaja, Me._planillaActual.NumeroPlanilla)
      'Dim sTickets As Decimal = oCaja.GetSaldoTickets(Me._idSucursal, Me._idCaja, Me._planillaActual.NumeroPlanilla)
      'Dim sCheques As Decimal = oCaja.GetSaldoCheques(Me._idSucursal, Me._idCaja, Me._planillaActual.NumeroPlanilla)
      'Dim sTarjetas As Decimal = oCaja.GetSaldoTarjetas(Me._idSucursal, Me._idCaja, Me._planillaActual.NumeroPlanilla)
      'Dim sBancos As Decimal = oCaja.GetSaldoBancos(Me._idSucursal, Me._idCaja, Me._planillaActual.NumeroPlanilla)
      'Dim sRetenciones As Decimal = oCaja.GetSaldoRetenciones(Me._idSucursal, Me._idCaja, Me._planillaActual.NumeroPlanilla)

      _planillaActual.PesosSaldoFinal = _planillaActual.PesosSaldoInicial + saldos.PesosSaldoFinal
      _planillaActual.DolaresSaldoFinal = _planillaActual.DolaresSaldoInicial + saldos.DolaresSaldoFinal
      _planillaActual.TicketsSaldoFinal = _planillaActual.TicketsSaldoInicial + saldos.TicketsSaldoFinal
      _planillaActual.ChequesSaldoFinal = _planillaActual.ChequesSaldoInicial + saldos.ChequesSaldoFinal
      _planillaActual.TarjetasSaldoFinal = _planillaActual.TarjetasSaldoInicial + saldos.TarjetasSaldoFinal
      _planillaActual.RetencionesSaldoFinal = _planillaActual.RetencionesSaldoInicial + saldos.RetencionesSaldoFinal
      _planillaActual.BancosSaldoFinal = _planillaActual.BancosSaldoInicial + saldos.BancosSaldoFinal
      _planillaActual.BancosDolaresSaldoFinal = _planillaActual.BancosDolaresSaldoInicial + saldos.BancosDolaresSaldoFinal

      txtPACEfectivo.Text = _planillaActual.PesosSaldoFinal.ToString("N2")
      txtPACDolares.Text = _planillaActual.DolaresSaldoFinal.ToString("N2")
      txtPACTickets.Text = _planillaActual.TicketsSaldoFinal.ToString("N2")
      txtPACRetenciones.Text = _planillaActual.RetencionesSaldoFinal.ToString("N2")
      txtPACCheques.Text = _planillaActual.ChequesSaldoFinal.ToString("N2")
      txtPACTarjetas.Text = _planillaActual.TarjetasSaldoFinal.ToString("N2")
      txtPACBancos.Text = _planillaActual.BancosSaldoFinal.ToString("N2")
      txtPACBancosDolares.Text = _planillaActual.BancosDolaresSaldoFinal.ToString("N2")

   End Sub

   Private Function ArmarArrayChequesAplicados(dr As DataRow) As IEnumerable(Of Entidades.Cheque)

      Dim eCheques = New List(Of Entidades.Cheque)()

      Dim rCheq = New Reglas.Cheques()
      Using dtCheques = rCheq.GetChequesAplicados(_idSucursal,
                                                  _idCaja,
                                                  txtNroPlanillaActual.Text.ValorNumericoPorDefecto(0I),
                                                  dr.Field(Of Integer)("NumeroMovimiento"),
                                                  dr.Field(Of String)("IdTipoMovimiento"),
                                                  _CheqPropio)

         For Each drCh As DataRow In dtCheques.Rows
            Dim sCheque = New Entidades.Cheque(_idSucursal, actual.Nombre, actual.Pwd)
            With sCheque
               .IdSucursal = Me._idSucursal
               .IdCheque = Integer.Parse(drCh("IdCheque").ToString())
               .NumeroCheque = Integer.Parse(drCh("NumeroCheque").ToString())
               .Banco.IdBanco = Integer.Parse(drCh("IdBanco").ToString())
               .IdBancoSucursal = Integer.Parse(drCh("IdBancoSucursal").ToString())
               .FechaEmision = DateTime.Parse(drCh("FechaEmision").ToString())
               .FechaCobro = DateTime.Parse(drCh("FechaCobro").ToString())
               .Titular = drCh("Titular").ToString()
               .Localidad.IdLocalidad = Integer.Parse(drCh("IdLocalidad").ToString())
               .Importe = Decimal.Parse(drCh("Importe").ToString())

               .IdCajaIngreso = Integer.Parse(drCh("IdCajaIngreso").ToString())
               .NroPlanillaIngreso = Integer.Parse(drCh("NroPlanillaIngreso").ToString())
               .NroMovimientoIngreso = Integer.Parse(drCh("NroMovimientoIngreso").ToString())

               If Not drCh("NroPlanillaEgreso") Is System.DBNull.Value Then
                  .IdCajaEgreso = Integer.Parse(drCh("IdCajaEgreso").ToString())
                  .NroPlanillaEgreso = Integer.Parse(drCh("NroPlanillaEgreso").ToString())
                  .NroMovimientoEgreso = Integer.Parse(drCh("NroMovimientoEgreso").ToString())
               End If

               'Lo pongo en este estado para que lo tome la funcionalidad de desaplicar.
               .RowState = DataRowState.Deleted

            End With
            eCheques.Add(sCheque)
         Next
      End Using
      Return eCheques
   End Function

   Private Sub DesasociarChequesAMovimiento(idSucursal As Integer, TipoMovimiento As String, cheques As ArrayList)

      Dim oCheques As Reglas.Cheques = New Reglas.Cheques()

      For Each ch As Entidades.Cheque In cheques
         If ch.RowState = DataRowState.Deleted Then
            oCheques.DesasociarChequesAMovimiento(idSucursal, TipoMovimiento, ch.NumeroCheque, ch.Banco.IdBanco, ch.IdBancoSucursal, ch.Localidad.IdLocalidad, ch.IdCheque)
         End If
      Next

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub CrearNuevaPlanilla()

      Dim nCaja = New Reglas.Cajas()
      Dim eCaja = New Entidades.Caja(_idSucursal, actual.Nombre, actual.Pwd)

      With eCaja
         '.NumeroPlanilla = 0
         .FechaPlanilla = Date.Now()

         'If Me._planillaActual Is Nothing Then
         .PesosSaldoInicial = 0
         .PesosSaldoFinal = 0
         .DolaresSaldoInicial = 0
         .DolaresSaldoFinal = 0
         .TicketsSaldoInicial = 0
         .TicketsSaldoFinal = 0
         .ChequesSaldoInicial = 0
         .ChequesSaldoFinal = 0
         .TarjetasSaldoInicial = 0
         .TarjetasSaldoFinal = 0
         .BancosSaldoInicial = 0
         .BancosSaldoFinal = 0
         .IdCaja = Me._idCaja
         'Else
         '   .PesosSaldoInicial = Me._planillaActual.PesosSaldoFinal
         '   .DolaresSaldoInicial = Me._planillaActual.DolaresSaldoFinal
         '   .TicketsSaldoInicial = Me._planillaActual.TicketsSaldoFinal
         '   .ChequesSaldoInicial = Me._planillaActual.ChequesSaldoFinal
         '   .TarjetasSaldoInicial = Me._planillaActual.TarjetasSaldoFinal
         '   .BancosSaldoInicial = Me._planillaActual.BancosSaldoFinal
         '   .RetencionesSaldoInicial = Me._planillaActual.RetencionesSaldoFinal
         '   .IdCaja = Me._idCaja
         'End If

      End With

      nCaja.Insertar(eCaja)

   End Sub

   Public Sub BorrarMovimiento(dr As DataRow)
      Dim nroMovimiento = dr.Field(Of Integer)("NumeroMovimiento")

      Dim rCajaDetalle = New Reglas.CajaDetalles()
      Dim eCajaDetalle = rCajaDetalle.GetUna(_idSucursal, cmbCajas.ValorSeleccionado(Of Integer),
                                             txtNroPlanillaActual.Text.ValorNumericoPorDefecto(0I), nroMovimiento)

      rCajaDetalle.BorrarMovimiento(eCajaDetalle, ArmarArrayChequesAplicados(dr))

   End Sub

#End Region

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugMovimientos.Rows.Count = 0 Then Exit Sub

         Dim myWorkbook As New Workbook
         Dim myWorksheet As Worksheet
         myWorksheet = myWorkbook.Worksheets.Add("Hoja1")
         myWorksheet.Rows(0).Cells(0).Value = Reglas.Publicos.NombreEmpresa
         myWorksheet.Rows(1).Cells(0).Value = Me.Text + " : " + cmbCajas.Text + " "
         myWorksheet.Rows(0).Cells(7).Value = "Planilla Nro: " + txtNroPlanillaActual.Text + "             Estado: !!! Abierta !!!"

         myWorksheet.Rows(3).Cells(0).Value = "Planilla Anterior"


         myWorksheet.Rows(2).Cells(2).Value = "Nro Planilla"
         myWorksheet.Rows(3).Cells(2).Value = txtNroPlanillaAnterior.Text
         myWorksheet.Rows(2).Cells(3).Value = "Fecha"
         myWorksheet.Rows(3).Cells(3).Value = txtPAFecha.Text
         myWorksheet.Rows(2).Cells(6).Value = "Pesos"
         myWorksheet.Rows(3).Cells(6).Value = Decimal.Parse(txtPAEfectivo.Text)
         myWorksheet.Rows(2).Cells(7).Value = "Cheques"
         myWorksheet.Rows(3).Cells(7).Value = Decimal.Parse(txtPACheques.Text)
         myWorksheet.Rows(2).Cells(8).Value = "Tarjetas"
         myWorksheet.Rows(3).Cells(8).Value = Decimal.Parse(txtPATarjetas.Text)
         myWorksheet.Rows(2).Cells(9).Value = "Retenciones"
         myWorksheet.Rows(3).Cells(9).Value = Decimal.Parse(txtPARetenciones.Text)
         myWorksheet.Rows(2).Cells(10).Value = "Bancos"
         myWorksheet.Rows(3).Cells(10).Value = Decimal.Parse(txtPABancos.Text)
         myWorksheet.Rows(2).Cells(15).Value = "Tickets"
         myWorksheet.Rows(3).Cells(15).Value = Decimal.Parse(txtPATickets.Text)


         Me.sfdExportar.FileName = Me.Name & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.UltraGridExcelExporter1.Export(ugMovimientos, myWorksheet, 4, 0)
               Dim UltLinea As Integer = Me.ugMovimientos.Rows.Count + 9

               myWorksheet.Rows(UltLinea).Cells(0).Value = "Planilla Actual"

               myWorksheet.Rows(UltLinea - 1).Cells(2).Value = "Nro Planilla"
               myWorksheet.Rows(UltLinea).Cells(2).Value = txtNroPlanillaActual.Text
               myWorksheet.Rows(UltLinea - 1).Cells(3).Value = "Fecha"
               myWorksheet.Rows(UltLinea).Cells(3).Value = txtPACFecha.Text
               myWorksheet.Rows(UltLinea - 1).Cells(6).Value = "Pesos"
               myWorksheet.Rows(UltLinea).Cells(6).Value = Decimal.Parse(txtPACEfectivo.Text)
               myWorksheet.Rows(UltLinea - 1).Cells(7).Value = "Cheques"
               myWorksheet.Rows(UltLinea).Cells(7).Value = Decimal.Parse(txtPACCheques.Text)
               myWorksheet.Rows(UltLinea - 1).Cells(8).Value = "Tarjetas"
               myWorksheet.Rows(UltLinea).Cells(8).Value = Decimal.Parse(txtPACTarjetas.Text)
               myWorksheet.Rows(UltLinea - 1).Cells(9).Value = "Retenciones"
               myWorksheet.Rows(UltLinea).Cells(9).Value = Decimal.Parse(txtPACRetenciones.Text)
               myWorksheet.Rows(UltLinea - 1).Cells(10).Value = "Bancos"
               myWorksheet.Rows(UltLinea).Cells(10).Value = Decimal.Parse(txtPACBancos.Text)
               myWorksheet.Rows(UltLinea - 1).Cells(15).Value = "Tickets"
               myWorksheet.Rows(UltLinea).Cells(15).Value = Decimal.Parse(txtPACTickets.Text)

               myWorkbook.Save(Me.sfdExportar.FileName)
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         PreferenciasCargar(ugMovimientos, tsbPreferencias)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class