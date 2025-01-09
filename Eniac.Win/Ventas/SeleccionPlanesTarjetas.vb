Option Strict On
Option Explicit On
Imports Infragistics.Win.UltraWinGrid
Public Class SeleccionPlanesTarjetas

   'Public Const IdEfectivo As Integer = -100
   Public Const BotonAgregarKey As String = "AGREGAR"

   Private Property ImporteTotalSinInterses As Decimal
   '-- REQ-34513.- ------------------------
   Public Property Efectivo As Decimal
   Public Property Transferencia As Decimal
   Public Property Tickets As Decimal
   Public Property Cheques As Decimal
   Public Property Dolares As Decimal
   '---------------------------------------
   Public Property ImporteAnticipoSinInteres As Decimal
   Private Property Tarjetas As List(Of Entidades.VentaTarjeta)
   Public Property ImporteTotalConInterses As Decimal
   Private Property DtPlanesTarjetas As DataTable

   Private _activaImporteSinInteres As Boolean

   Public _fechaComprobante As Date

   Private Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub
   Public Sub New(nimporteTotalSinInterses As Decimal, nefectivo As Decimal, ntransferencia As Decimal, ntickets As Decimal, ncheques As Decimal, ndolares As Decimal, ntarjetas As List(Of Entidades.VentaTarjeta), nactivaImporteSinInteres As Boolean, nimporteAnticipoSinInteres As Decimal)
      Me.New()
      ImporteTotalSinInterses = nimporteTotalSinInterses
      ImporteAnticipoSinInteres = nimporteAnticipoSinInteres
      '-- REQ-34513.- -----------------------------------------
      Efectivo = nefectivo
      Transferencia = ntransferencia
      Tickets = ntickets
      Cheques = ncheques
      Dolares = ndolares
      '--------------------------------------------------------
      Tarjetas = ntarjetas
      _activaImporteSinInteres = nactivaImporteSinInteres
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         CargaValueLists()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
      Try
         CargaPlanesTarjetas()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

      Try
         txtImporteTotalSinInterses.Text = ImporteTotalSinInterses.ToString("N2")

         '-- REQ-34513.- -----------------------------------------
         txtEfectivo.Text = Efectivo.ToString("N2")
         txtTransferencia.Text = Transferencia.ToString("N2")
         txtCheque.Text = Cheques.ToString("N2")
         txtTicket.Text = Tickets.ToString("N2")
         '--------------------------------------------------------
         'If Efectivo <> 0 Then
         'Dim dr() As DataRow = DtPlanesTarjetas.Select(String.Format("IdTarjeta = {0}", IdEfectivo))
         'If dr.Length <> 0 Then
         '   dr(0)(ColumnasDatatable.Importe.ToString()) = Efectivo
         '   dr(0)(ColumnasDatatable.SELEC) = True
         'End If
         'End If
         'For Each VT As Entidades.VentaTarjeta In Tarjetas
         '   If VT.Monto <> 0 Then
         '      Dim drCol() As DataRow = DtPlanesTarjetas.Select(String.Format("{0} = {1} AND {2} = {3}",
         '                                                                  ColumnasDatatable.IdTarjeta.ToString(), VT.Tarjeta.IdTarjeta,
         '                                                                  ColumnasDatatable.IdBanco.ToString(), VT.Banco.IdBanco))
         '      For Each dr As DataRow In drCol
         '         Dim importe As Decimal = 0
         '         If Not String.IsNullOrWhiteSpace(ColumnasDatatable.Importe.ToString()) Then
         '            importe = Decimal.Parse(ColumnasDatatable.Importe.ToString())
         '         End If
         '         If importe = 0 Then
         '            dr(ColumnasDatatable.Importe.ToString()) = Decimal.Round((VT.Monto) / (1 + (Decimal.Parse(drCol(0)(ColumnasDatatable.Interes.ToString()).ToString()) / 100)), 2)
         '            dr(ColumnasDatatable.IdBanco.ToString()) = VT.Banco.IdBanco
         '            dr(ColumnasDatatable.IdTarjeta.ToString()) = VT.Tarjeta.IdTarjeta
         '            dr(ColumnasDatatable.SELEC) = True
         '         Else


         '                           DirectCast(e.Cell.Row.ListObject, DataRowView).Row IsNot Nothing Then
         '            Dim newRow As DataRow = DtPlanesTarjetas.NewRow()
         '            newRow.ItemArray = DirectCast(DirectCast(e.Cell.Row.ListObject, DataRowView).Row.ItemArray.Clone(), Object())
         '            newRow(ColumnasDatatable.Importe.ToString()) = 0

         '            Dim bancoModificable As Boolean = CBool(newRow(ColumnasDatatable.BancoModificable.ToString()))
         '            Dim tarjetaModificable As Boolean = CBool(newRow(ColumnasDatatable.TarjetaModificable.ToString()))
         '            If Not bancoModificable Then
         '               newRow(ColumnasDatatable.IdBanco.ToString()) = 0
         '            End If
         '            If Not tarjetaModificable Then
         '               newRow(ColumnasDatatable.IdTarjeta.ToString()) = 0
         '            End If
         '            DtPlanesTarjetas.Rows.Add(newRow)

         '            ugPlanesTarjetas.DisplayLayout.Bands(0).SortedColumns.RefreshSort(False)


         '         End If
         '      Next
         '   End If
         'Next
         lblImporteAnticipoSinInteres.Visible = _activaImporteSinInteres
         txtImporteAnticipoSinInteres.Visible = _activaImporteSinInteres
         txtImporteAnticipoSinInteres.Text = ImporteAnticipoSinInteres.ToString("N2")
         MuestraPendiente()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      Try
         ugPlanesTarjetas.ActiveRow = ugPlanesTarjetas.Rows(0)
         ugPlanesTarjetas.ActiveCell = ugPlanesTarjetas.ActiveRow.Cells(0)
         ugPlanesTarjetas.PerformAction(UltraGridAction.FirstCellInGrid)
         ugPlanesTarjetas.PerformAction(UltraGridAction.EnterEditMode)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub CargaPlanesTarjetas()
      Dim planesTarjetas As List(Of Entidades.PlanTarjeta) = New Reglas.PlanesTarjetas().GetPlanesActivos()

      DtPlanesTarjetas = CreaDT()

      'AgregaEfectivo()

      For Each drPlanTarjeta As Entidades.PlanTarjeta In planesTarjetas
         AgregaTarjeta(drPlanTarjeta)
      Next

      ugPlanesTarjetas.DataSource = DtPlanesTarjetas

   End Sub


   Private Function CreaDT() As DataTable
      Dim dt As DataTable = New DataTable()

      dt.Columns.Add(ColumnasDatatable.SELEC.ToString(), GetType(Boolean))
      dt.Columns.Add(ColumnasDatatable.OrdenInterno.ToString(), GetType(Integer))
      dt.Columns.Add(ColumnasDatatable.IdPlanTarjeta.ToString(), GetType(Integer))
      dt.Columns.Add(ColumnasDatatable.NombrePlanTarjeta.ToString(), GetType(String))
      dt.Columns.Add(ColumnasDatatable.Importe.ToString(), GetType(Decimal))

      '-- REQ-43663.- -------------------------------------------------------------------------------
      dt.Columns.Add(ColumnasDatatable.NroCupon.ToString(), GetType(Integer))
      dt.Columns.Add(ColumnasDatatable.NroLote.ToString(), GetType(Integer))
      '----------------------------------------------------------------------------------------------

      dt.Columns.Add(ColumnasDatatable.Interes.ToString(), GetType(Decimal))
      dt.Columns.Add(ColumnasDatatable.ImporteAplicar.ToString(), GetType(Decimal)).Expression = "Importe + (Importe * Interes / 100)"
      dt.Columns.Add(ColumnasDatatable.CuotasDesde.ToString(), GetType(Decimal))
      dt.Columns.Add(ColumnasDatatable.CuotasHasta.ToString(), GetType(Decimal))

      dt.Columns.Add(ColumnasDatatable.IdTarjeta.ToString(), GetType(Integer))
      dt.Columns.Add(ColumnasDatatable.NombreTarjeta.ToString(), GetType(String))
      dt.Columns.Add(ColumnasDatatable.TarjetaModificable.ToString(), GetType(Boolean))
      dt.Columns.Add(ColumnasDatatable.IdBanco.ToString(), GetType(Integer))
      dt.Columns.Add(ColumnasDatatable.NombreBanco.ToString(), GetType(String))
      dt.Columns.Add(ColumnasDatatable.BancoModificable.ToString(), GetType(Boolean))

      Return dt
   End Function

   Private Sub AgregaTarjeta(drTarjeta As Entidades.PlanTarjeta)
      Dim drPlanesTarjetas As DataRow = DtPlanesTarjetas.NewRow()

      drPlanesTarjetas(ColumnasDatatable.SELEC) = False
      drPlanesTarjetas(ColumnasDatatable.OrdenInterno.ToString()) = 100
      drPlanesTarjetas(ColumnasDatatable.IdPlanTarjeta.ToString()) = drTarjeta.IdPlanTarjeta
      drPlanesTarjetas(ColumnasDatatable.NombrePlanTarjeta.ToString()) = drTarjeta.NombrePlanTarjeta
      drPlanesTarjetas(ColumnasDatatable.Importe.ToString()) = 0
      '-- REQ-43663.- -------------------------------------------------------------------------------
      drPlanesTarjetas(ColumnasDatatable.NroCupon.ToString()) = 0
      drPlanesTarjetas(ColumnasDatatable.NroLote.ToString()) = 0

      '-- REQ-34675.- ----------------
      Select Case _fechaComprobante.DayOfWeek
         Case DayOfWeek.Sunday
            drPlanesTarjetas(ColumnasDatatable.Interes.ToString()) = If(drTarjeta.PorcDescRecDom, drTarjeta.PorcDescRec, 0)
         Case DayOfWeek.Monday
            drPlanesTarjetas(ColumnasDatatable.Interes.ToString()) = If(drTarjeta.PorcDescRecLun, drTarjeta.PorcDescRec, 0)
         Case DayOfWeek.Tuesday
            drPlanesTarjetas(ColumnasDatatable.Interes.ToString()) = If(drTarjeta.PorcDescRecMar, drTarjeta.PorcDescRec, 0)
         Case DayOfWeek.Wednesday
            drPlanesTarjetas(ColumnasDatatable.Interes.ToString()) = If(drTarjeta.PorcDescRecMie, drTarjeta.PorcDescRec, 0)
         Case DayOfWeek.Thursday
            drPlanesTarjetas(ColumnasDatatable.Interes.ToString()) = If(drTarjeta.PorcDescRecJue, drTarjeta.PorcDescRec, 0)
         Case DayOfWeek.Friday
            drPlanesTarjetas(ColumnasDatatable.Interes.ToString()) = If(drTarjeta.PorcDescRecVie, drTarjeta.PorcDescRec, 0)
         Case DayOfWeek.Saturday
            drPlanesTarjetas(ColumnasDatatable.Interes.ToString()) = If(drTarjeta.PorcDescRecSab, drTarjeta.PorcDescRec, 0)
      End Select
      '-------------------------------
      drPlanesTarjetas(ColumnasDatatable.CuotasDesde.ToString()) = drTarjeta.CuotasDesde
      drPlanesTarjetas(ColumnasDatatable.CuotasHasta.ToString()) = drTarjeta.CuotasHasta

      drPlanesTarjetas(ColumnasDatatable.IdTarjeta.ToString()) = drTarjeta.IdTarjeta
      drPlanesTarjetas(ColumnasDatatable.NombreTarjeta.ToString()) = drTarjeta.NombreTarjeta
      drPlanesTarjetas(ColumnasDatatable.TarjetaModificable.ToString()) = drTarjeta.IdTarjeta = 0
      drPlanesTarjetas(ColumnasDatatable.IdBanco.ToString()) = drTarjeta.IdBanco
      drPlanesTarjetas(ColumnasDatatable.NombreBanco.ToString()) = drTarjeta.NombreBanco
      drPlanesTarjetas(ColumnasDatatable.BancoModificable.ToString()) = drTarjeta.IdBanco = 0

      DtPlanesTarjetas.Rows.Add(drPlanesTarjetas)
   End Sub

   Private Sub grdPlanesTarjetas_AfterExitEditMode(sender As Object, e As EventArgs) Handles ugPlanesTarjetas.AfterExitEditMode
      Try
         ugPlanesTarjetas.UpdateData()
         MuestraPendiente()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         Valida()

         Aceptar()

         DialogResult = Windows.Forms.DialogResult.OK
         Close()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Try
         DialogResult = Windows.Forms.DialogResult.Cancel
         Close()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub Valida()

      If Not IsNumeric(txtEfectivo.Text) Then
         txtEfectivo.Text = "0.00"
      End If
      '-- REQ-34513.- ---------------------------------
      If Not IsNumeric(txtTransferencia.Text) Then
         txtTransferencia.Text = "0.00"
      End If
      If Not IsNumeric(txtTicket.Text) Then
         txtTicket.Text = "0.00"
      End If
      If Not IsNumeric(txtCheque.Text) Then
         txtCheque.Text = "0.00"
      End If

      Dim totalImporteIngresado As Decimal = Decimal.Round(Decimal.Parse(ugPlanesTarjetas.Rows.SummaryValues(ColumnasDatatable.Importe.ToString()).Value.ToString()), 2) +
                                             Decimal.Parse(txtEfectivo.Text) +
                                             Decimal.Parse(txtTransferencia.Text) + Decimal.Parse(txtTicket.Text) + Decimal.Parse(txtCheque.Text)
      '------------------------------------------------

      If (ImporteTotalSinInterses + ImporteAnticipoSinInteres).MidRound(0, 2) <> totalImporteIngresado.MidRound(0, 2) Then
         Throw New Exception(String.Format("El total de importe ingresado de los planes ({0:N2}) difiere del total a facturar ({1:N2}). Por favor verifique.",
                                           totalImporteIngresado, ImporteTotalSinInterses + ImporteAnticipoSinInteres))
      End If

      For Each drPlanesTarjetas As DataRow In DtPlanesTarjetas.Select(String.Format("{0} <> 0", ColumnasDatatable.ImporteAplicar.ToString()))
         Dim nombrePlan As String = drPlanesTarjetas(ColumnasDatatable.NombrePlanTarjeta.ToString()).ToString()

         If Decimal.Parse(drPlanesTarjetas(ColumnasDatatable.Importe.ToString()).ToString()) < 0 Then
            Throw New Exception(String.Format("Al plan '{0}' tiene Importe Negativo. Por favor verifique.", nombrePlan))
         End If

         '-- REQ-43663.- -------------------------------------------------------------------------------
         If String.IsNullOrEmpty(drPlanesTarjetas(ColumnasDatatable.NroLote.ToString()).ToString()) Then
            Throw New Exception(String.Format("Al plan '{0}' le falta indicar el Número de Lote. Por favor verifique.", nombrePlan))
         Else
            If Integer.Parse(drPlanesTarjetas(ColumnasDatatable.NroLote.ToString()).ToString()) <= 0 Then
               Throw New Exception(String.Format("Al plan '{0}' le falta indicar el Número de Lote. Por favor verifique.", nombrePlan))
            End If
         End If
         If String.IsNullOrEmpty(drPlanesTarjetas(ColumnasDatatable.NroCupon.ToString()).ToString()) Then
            Throw New Exception(String.Format("Al plan '{0}' le falta indicar el Número de Cupón. Por favor verifique.", nombrePlan))
         Else
            If Integer.Parse(drPlanesTarjetas(ColumnasDatatable.NroCupon.ToString()).ToString()) <= 0 Then
               Throw New Exception(String.Format("Al plan '{0}' le falta indicar el Número de Cupón. Por favor verifique.", nombrePlan))
            End If
         End If
         '----------------------------------------------------------------------------------------------


         If String.IsNullOrWhiteSpace(drPlanesTarjetas(ColumnasDatatable.IdTarjeta.ToString()).ToString()) Then
            Throw New Exception(String.Format("Al plan '{0}' le falta indicar con que TARJETA se paga. Por favor verifique.", nombrePlan))
         End If

         If String.IsNullOrWhiteSpace(drPlanesTarjetas(ColumnasDatatable.IdBanco.ToString()).ToString()) Then
            Throw New Exception(String.Format("Al plan '{0}' le falta indicar con que BANCO se paga. Por favor verifique.", nombrePlan))
         End If

      Next

   End Sub

   Private Sub MuestraPendiente()
      If _activaImporteSinInteres Then
         ImporteAnticipoSinInteres = Decimal.Parse(Me.txtImporteAnticipoSinInteres.Text)
      End If

      Dim totalImporteIngresado As Decimal = Decimal.Round(Decimal.Parse(ugPlanesTarjetas.Rows.SummaryValues(ColumnasDatatable.Importe.ToString()).Value.ToString()), 2)
      Dim mEfectivo As Decimal
      If IsNumeric(txtEfectivo.Text) Then mEfectivo = Decimal.Parse(txtEfectivo.Text)
      '-- REQ-34513.- ---------------------------------
      Dim mTransferencia As Decimal
      If IsNumeric(txtTransferencia.Text) Then mTransferencia = Decimal.Parse(txtTransferencia.Text)
      Dim mCheque As Decimal
      If IsNumeric(txtCheque.Text) Then mCheque = Decimal.Parse(txtCheque.Text)
      Dim mTicket As Decimal
      If IsNumeric(txtTicket.Text) Then mTicket = Decimal.Parse(txtTicket.Text)
      '------------------------------------------------
      txtPendiente.Text = (ImporteTotalSinInterses + ImporteAnticipoSinInteres - totalImporteIngresado - mEfectivo - mTransferencia - mTicket - mCheque).ToString("N2")
   End Sub

   Private Sub Aceptar()
      Tarjetas.Clear()
      For Each drPlanesTarjetas As DataRow In DtPlanesTarjetas.Select(String.Format("{0} <> 0", ColumnasDatatable.ImporteAplicar.ToString()))

         Dim importeAplicar As Decimal = Decimal.Round(Decimal.Parse(drPlanesTarjetas(ColumnasDatatable.ImporteAplicar.ToString()).ToString()), 2)
         Dim importeOrginal As Decimal = Decimal.Parse(drPlanesTarjetas(ColumnasDatatable.Importe.ToString()).ToString())

         Dim idPlanTarjeta As Integer = Integer.Parse(drPlanesTarjetas(ColumnasDatatable.IdPlanTarjeta.ToString()).ToString())
         Dim idTarjeta As Integer = 0
         Dim idBanco As Integer = 0
         Dim interes As Decimal = 0
         Dim MontodelInteres As Decimal = 0

         '-- REQ-43663.- -------------------------------------------------------------------------------
         Dim _NroLote = Integer.Parse(drPlanesTarjetas(ColumnasDatatable.NroLote.ToString()).ToString())
         Dim _NroCupon = Integer.Parse(drPlanesTarjetas(ColumnasDatatable.NroCupon.ToString()).ToString())
         '----------------------------------------------------------------------------------------------


         If Not String.IsNullOrWhiteSpace(drPlanesTarjetas(ColumnasDatatable.Interes.ToString()).ToString()) Then
            interes = Decimal.Parse(drPlanesTarjetas(ColumnasDatatable.Interes.ToString()).ToString())
            MontodelInteres = importeAplicar - Decimal.Parse(drPlanesTarjetas(ColumnasDatatable.Importe.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(drPlanesTarjetas(ColumnasDatatable.IdTarjeta.ToString()).ToString()) Then
            idTarjeta = Integer.Parse(drPlanesTarjetas(ColumnasDatatable.IdTarjeta.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(drPlanesTarjetas(ColumnasDatatable.IdBanco.ToString()).ToString()) Then
            idBanco = Integer.Parse(drPlanesTarjetas(ColumnasDatatable.IdBanco.ToString()).ToString())
         End If

         'If idPlanTarjeta = IdEfectivo Then
         '   Efectivo = importeAplicar
         'Else
         Dim estaEnTarjetas As Boolean = False

         Dim vt As Entidades.VentaTarjeta = New Entidades.VentaTarjeta()
         Dim tarjeta As Entidades.Tarjeta = New Reglas.Tarjetas().GetUno(idTarjeta)
         Dim banco As Entidades.Banco = New Reglas.Bancos().GetUno(idBanco)
         Dim planTarjeta As Entidades.PlanTarjeta = New Reglas.PlanesTarjetas().GetUno(idPlanTarjeta)

         tarjeta.PorcIntereses = planTarjeta.PorcDescRec

         vt.Tarjeta = tarjeta
         vt.Banco = banco
         vt.Cuotas = planTarjeta.CuotasHasta
         vt.Monto = importeAplicar
         vt.PorcentajeDelInteres = interes
         vt.MontoDelInteres = MontodelInteres
         '-- REQ-43663.- -------------------------------------------------------------------------------
         vt.NumeroLote = _NroLote
         vt.NumeroCupon = _NroCupon
         '----------------------------------------------------------------------------------------------
         Tarjetas.Add(vt)


         'For Each tarjeta As Entidades.VentaTarjeta In Tarjetas
         '   If tarjeta.Tarjeta.IdTarjeta = idTarjeta Then
         '      If importeAplicar <> 0 Then
         '         tarjeta.Monto = importeAplicar
         '      Else
         '         Tarjetas.Remove(tarjeta)
         '      End If
         '      estaEnTarjetas = True
         '      Exit For
         '   End If
         'Next
         'If Not estaEnTarjetas AndAlso importeAplicar <> 0 Then
         '   Dim vt As Entidades.VentaTarjeta = New Entidades.VentaTarjeta()
         '   Dim tarjeta As Entidades.Tarjeta = New Reglas.Tarjetas().GetUno(idTarjeta)

         '   vt.Tarjeta = tarjeta
         '   vt.Cuotas = tarjeta.CantidadCuotas
         '   vt.Monto = importeAplicar

         '   Tarjetas.Add(vt)
         'End If
         'End If
      Next
      If IsNumeric(txtEfectivo.Text) Then
         Efectivo = Decimal.Parse(txtEfectivo.Text)
      End If
      '-- REQ-34513.- -----------------------------------------
      If IsNumeric(txtTransferencia.Text) Then
         Transferencia = Decimal.Parse(txtTransferencia.Text)
      End If
      If IsNumeric(txtCheque.Text) Then
         Cheques = Decimal.Parse(txtCheque.Text)
      End If
      If IsNumeric(txtTicket.Text) Then
         Tickets = Decimal.Parse(txtTicket.Text)
      End If

      ImporteTotalConInterses = Decimal.Round(Decimal.Parse(ugPlanesTarjetas.Rows.SummaryValues(ColumnasDatatable.ImporteAplicar.ToString()).Value.ToString()), 2) + Efectivo + Transferencia + Cheques + Tickets
      '-------------------------------------------------------

   End Sub

   Private Sub grdPlanesTarjetas_CellChange(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugPlanesTarjetas.CellChange
      Try
         If e.Cell.Column.Key = ColumnasDatatable.SELEC.ToString() Then
            ugPlanesTarjetas.UpdateData()

            HabilitaCamposGrilla(CBool(e.Cell.Value), e.Cell.Row)

            If CBool(e.Cell.Value) Then
               e.Cell.Row.Cells(ColumnasDatatable.Importe.ToString()).Value = Decimal.Parse(txtPendiente.Text)

               ugPlanesTarjetas.ActiveCell = e.Cell.Row.Cells(ColumnasDatatable.Importe.ToString())
               ugPlanesTarjetas.PerformAction(UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
            Else
               e.Cell.Row.Cells(ColumnasDatatable.Importe.ToString()).Value = 0

               e.Cell.Row.Cells(ColumnasDatatable.NroCupon.ToString()).Value = 0
               e.Cell.Row.Cells(ColumnasDatatable.NroLote.ToString()).Value = 0
            End If
            MuestraPendiente()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub grdPlanesTarjetas_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles ugPlanesTarjetas.InitializeRow
      Try
         HabilitaCamposGrilla(CBool(e.Row.Cells(ColumnasDatatable.SELEC).Value), e.Row)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub HabilitaCamposGrilla(selec As Boolean, row As UltraGridRow)
      If selec Then
         row.Cells(ColumnasDatatable.Importe.ToString()).Activation = UltraWinGrid.Activation.AllowEdit

         '-- REQ-43663.- -------------------------------------------------------------------------------
         row.Cells(ColumnasDatatable.NroLote.ToString()).Activation = UltraWinGrid.Activation.AllowEdit
         row.Cells(ColumnasDatatable.NroCupon.ToString()).Activation = UltraWinGrid.Activation.AllowEdit
         '----------------------------------------------------------------------------------------------

         Dim idPlanTarjeta As Integer = Integer.Parse(row.Cells(ColumnasDatatable.IdPlanTarjeta.ToString()).Value.ToString())
         Dim bancoModificable As Boolean = CBool(row.Cells(ColumnasDatatable.BancoModificable.ToString()).Value)
         Dim tarjetaModificable As Boolean = CBool(row.Cells(ColumnasDatatable.TarjetaModificable.ToString()).Value)

         'If idPlanTarjeta <> IdEfectivo Then
         If bancoModificable Then
            row.Cells(ColumnasDatatable.IdBanco.ToString()).Activation = UltraWinGrid.Activation.AllowEdit
         Else
            row.Cells(ColumnasDatatable.IdBanco.ToString()).Activation = UltraWinGrid.Activation.ActivateOnly
         End If
         If tarjetaModificable Then
            row.Cells(ColumnasDatatable.IdTarjeta.ToString()).Activation = UltraWinGrid.Activation.AllowEdit
         Else
            row.Cells(ColumnasDatatable.IdTarjeta.ToString()).Activation = UltraWinGrid.Activation.ActivateOnly
         End If
         row.Cells(BotonAgregarKey).Activation = UltraWinGrid.Activation.AllowEdit
         row.Cells(BotonAgregarKey).ButtonAppearance.Image = My.Resources.add_16
         'End If
      Else
         row.Cells(ColumnasDatatable.Importe.ToString()).Activation = UltraWinGrid.Activation.NoEdit

         '-- REQ-43663.- -------------------------------------------------------------------------------
         row.Cells(ColumnasDatatable.NroLote.ToString()).Activation = UltraWinGrid.Activation.NoEdit
         row.Cells(ColumnasDatatable.NroCupon.ToString()).Activation = UltraWinGrid.Activation.NoEdit
         '----------------------------------------------------------------------------------------------

         row.Cells(ColumnasDatatable.IdBanco.ToString()).Activation = UltraWinGrid.Activation.Disabled
         row.Cells(ColumnasDatatable.IdTarjeta.ToString()).Activation = UltraWinGrid.Activation.Disabled
         row.Cells(BotonAgregarKey).ButtonAppearance.Image = Nothing
         row.Cells(BotonAgregarKey).Activation = UltraWinGrid.Activation.Disabled
      End If
   End Sub

   Private Sub grdPlanesTarjetas_KeyDown(sender As Object, e As KeyEventArgs) Handles ugPlanesTarjetas.KeyDown
      Try
         Select Case e.KeyCode
            Case Keys.Enter

               Dim currentActiveCell As UltraGridCell = ugPlanesTarjetas.ActiveCell
               ugPlanesTarjetas.PerformAction(UltraWinGrid.UltraGridAction.NextCellByTab)
               While Not ugPlanesTarjetas.ActiveCell.CanEnterEditMode And Not currentActiveCell.Equals(ugPlanesTarjetas.ActiveCell)
                  currentActiveCell = ugPlanesTarjetas.ActiveCell
                  ugPlanesTarjetas.PerformAction(UltraWinGrid.UltraGridAction.NextCellByTab)
               End While
            Case Keys.Space
               Dim dr = ugPlanesTarjetas.FilaSeleccionada(Of DataRow)()
               If dr IsNot Nothing Then
                  ugPlanesTarjetas.PerformAction(UltraGridAction.EnterEditMode)
                  dr(ColumnasDatatable.SELEC.ToString()) = Not dr.Field(Of Boolean)(ColumnasDatatable.SELEC.ToString())
                  ugPlanesTarjetas.Rows.Refresh(RefreshRow.RefreshDisplay)
               End If

         End Select
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.F8 Then
            btnAceptar.PerformClick()
            Return True
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

   Private Enum ColumnasDatatable
      SELEC
      OrdenInterno
      IdPlanTarjeta
      NombrePlanTarjeta
      Importe
      NroCupon
      NroLote
      Interes
      ImporteAplicar
      CuotasDesde
      CuotasHasta
      IdTarjeta
      NombreTarjeta
      TarjetaModificable
      IdBanco
      NombreBanco
      BancoModificable
   End Enum

   Private Sub CargaValueLists()
      With ugPlanesTarjetas.DisplayLayout
         If .ValueLists.Exists("Tarjetas") Then
            Dim tarjetas As List(Of Entidades.Tarjeta) = New Reglas.Tarjetas().GetTodos()
            .ValueLists("Tarjetas").ValueListItems.Add(0, "(seleccione una tarjeta)")
            For Each tarjeta As Entidades.Tarjeta In tarjetas
               .ValueLists("Tarjetas").ValueListItems.Add(tarjeta.IdTarjeta, tarjeta.NombreTarjeta)
            Next
         End If

         If .ValueLists.Exists("Bancos") Then
            Dim bancos As DataTable = New Reglas.Bancos().GetTodos()
            .ValueLists("Bancos").ValueListItems.Add(0, "(seleccione un banco)")
            For Each banco As DataRow In bancos.Rows
               .ValueLists("Bancos").ValueListItems.Add(banco("IdBanco"), banco("NombreBanco").ToString())
            Next
         End If
      End With

   End Sub

   Private Sub grdPlanesTarjetas_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugPlanesTarjetas.ClickCellButton
      Try
         If e.Cell.Column.Key = BotonAgregarKey Then
            If e.Cell.Row IsNot Nothing AndAlso
               e.Cell.Row.ListObject IsNot Nothing AndAlso
               TypeOf (e.Cell.Row.ListObject) Is DataRowView AndAlso
               DirectCast(e.Cell.Row.ListObject, DataRowView).Row IsNot Nothing Then
               Dim newRow As DataRow = DtPlanesTarjetas.NewRow()
               newRow.ItemArray = DirectCast(DirectCast(e.Cell.Row.ListObject, DataRowView).Row.ItemArray.Clone(), Object())
               newRow(ColumnasDatatable.Importe.ToString()) = Decimal.Parse(txtPendiente.Text)

               Dim bancoModificable As Boolean = CBool(newRow(ColumnasDatatable.BancoModificable.ToString()))
               Dim tarjetaModificable As Boolean = CBool(newRow(ColumnasDatatable.TarjetaModificable.ToString()))
               If bancoModificable Then
                  newRow(ColumnasDatatable.IdBanco.ToString()) = 0
               End If
               If tarjetaModificable Then
                  newRow(ColumnasDatatable.IdTarjeta.ToString()) = 0
               End If
               DtPlanesTarjetas.Rows.Add(newRow)

               ugPlanesTarjetas.DisplayLayout.Bands(0).SortedColumns.RefreshSort(False)
            End If

         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   '-- REQ-34513.- --------------------------------------
   Private Sub MuestraPendiente_Leave(sender As Object, e As EventArgs) Handles txtEfectivo.Leave, txtTransferencia.Leave, txtCheque.Leave, txtTicket.Leave, txtImporteAnticipoSinInteres.Leave
      Try
         MuestraPendiente()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

End Class