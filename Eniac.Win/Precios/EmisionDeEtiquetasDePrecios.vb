Imports Microsoft.Reporting.WinForms

Public Class EmisionDeEtiquetasDePrecios

#Region "Campos"

   Private _publicos As Publicos
   Private _filtroMultiplesMarcas As MFMarcas
   Private _filtroMultiplesRubros As MFRubros
   Private _estaCargando As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try

         _publicos = New Publicos()
         _publicos.CargaComboListaDePrecios(cmbListaDePrecios)
         _publicos.CargaComboListaDePrecios(cmbListasDePrecios2)

         _filtroMultiplesMarcas = New MFMarcas()
         _filtroMultiplesRubros = New MFRubros()

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         _publicos.CargaComboFormatosEtiquetas(cmbFormatos, Entidades.FormatoEtiqueta.Tipos.PRECIOS, True)

         'Me.cmbFormatos.Items.Insert(0, "3 x Ancho")
         'Me.cmbFormatos.Items.Insert(1, "2 x Ancho")
         'Me.cmbFormatos.Items.Insert(2, "2 x Ancho con Encabezado")
         'Me.cmbFormatos.Items.Insert(3, "2 x Hoja")
         'Me.cmbFormatos.Items.Insert(4, "2 x Hoja con Encabezado")
         'Me.cmbFormatos.Items.Insert(5, "3 x Ancho 2 Listas Precios")

         cmbFormatos.SelectedIndex = 0

         ' Cargo el combo de Formas de Pago
         _publicos.CargaComboFormasDePago(cmbFormaPago, "VENTAS")
         cmbFormaPago.SelectedIndex = -1

         dgvDetalle.Columns("PrecioVentaSinIVA").Visible = Not Publicos.PreciosConIVA
         dgvDetalle.Columns("PrecioVentaConIVA").Visible = Publicos.PreciosConIVA

         dgvSeleccionados.Columns("gPrecioVentaSinIVA").Visible = Not Publicos.PreciosConIVA
         dgvSeleccionados.Columns("gPrecioVentaConIVA").Visible = Publicos.PreciosConIVA

         cmbMarca.Inicializar(False, True, True)
         cmbRubro.Inicializar(False, True, True)

         '  Me._estaCargando = False

         chbConIVA.Checked = Publicos.ConsultarPreciosConIVA

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      ElseIf keyData = Keys.F4 Then
         btnBuscar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click

      Try

         txtCodigo.Text = String.Empty
         txtProducto.Text = String.Empty

         cmbMarca.Refrescar()
         cmbRubro.Refrescar()

         cmbListaDePrecios.SelectedIndex = 0
         cmbFormaPago.SelectedIndex = -1

         chbFormaPago.Checked = False
         chbFechaActualizado.Checked = False
         chbStockPositivo.Checked = False

         cmbFormatos.SelectedIndex = 0
         txtCabecera.Text = String.Empty

         'Dim rProd = New Reglas.Productos()

         If TypeOf (dgvDetalle.DataSource) Is DataTable Then
            DirectCast(dgvDetalle.DataSource, DataTable).Rows.Clear()
         End If

         If TypeOf (dgvSeleccionados.DataSource) Is DataTable Then
            DirectCast(dgvSeleccionados.DataSource, DataTable).Rows.Clear()
         End If

         chbConIVA.Checked = Publicos.ConsultarPreciosConIVA
         chbConIVA.Enabled = True

         dgvDetalle.Columns("PrecioVentaSinIVA").Visible = Not Publicos.PreciosConIVA
         dgvDetalle.Columns("PrecioVentaConIVA").Visible = Publicos.PreciosConIVA

         dgvSeleccionados.Columns("gPrecioVentaSinIVA").Visible = Not Publicos.PreciosConIVA
         dgvSeleccionados.Columns("gPrecioVentaConIVA").Visible = Publicos.PreciosConIVA

         chbTodos.Checked = False
         tssRegistros.Text = String.Empty

         txtCodigo.Focus()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click

      If dgvDetalle.RowCount = 0 Then Exit Sub

      TryCatched(
         Sub()
            dgvSeleccionados.EndEdit()

            Dim Filtros = String.Empty

            Dim dt = GenerarDT()

            If dt.Rows.Count = 0 Then
               MessageBox.Show("No marco productos para Emitir la Etiqueta de Precios.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Exit Sub
            End If

            Dim parm = New List(Of ReportParameter)

            parm.Add(New ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
            parm.Add(New ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))
            parm.Add(New ReportParameter("DecimalesEnPrecio", Eniac.Reglas.Publicos.PreciosDecimalesEnVenta.ToString()))

            Dim frmImprime = New VisorReportes(GetFormatoEtiqueta().ArchivoAImprimir, "dsPrecios_EtiquetasDePrecios", dt, parm, GetFormatoEtiqueta().ArchivoAImprimirEmbebido, cantidadCopias:=1)

            frmImprime.Text = Text
            frmImprime.WindowState = FormWindowState.Normal
            frmImprime.StartPosition = FormStartPosition.CenterScreen
            frmImprime.Width = 900
            frmImprime.Show()

         End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub


   Private Sub chbFechaActualizado_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaActualizado.CheckedChanged
      TryCatched(
         Sub()
            dtpDesde.Enabled = chbFechaActualizado.Checked
            dtpHasta.Enabled = chbFechaActualizado.Checked
            dtpDesde.Value = Date.Today
            dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
            If chbFechaActualizado.Checked Then
               dtpDesde.Focus()
            End If
         End Sub)
   End Sub

   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      TryCatched(
         Sub()
            If chbFormaPago.Checked And cmbFormaPago.SelectedIndex = -1 Then
               ShowMessage("ATENCIÓN: Activo Forma de Pago Descuento Recargo pero no seleccionó nada.")
               cmbFormaPago.Focus()
               Exit Sub
            End If
            CargarDatosGrilla()
         End Sub)
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      TryCatched(
         Sub()
            For Each dr As DataGridViewRow In dgvDetalle.Rows
               dr.Cells("Imprime").Value = chbTodos.Checked
            Next
         End Sub)
   End Sub

   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged
      TryCatched(
         Sub()
            cmbFormaPago.Enabled = chbFormaPago.Checked
            If Not chbFormaPago.Checked Then
               cmbFormaPago.SelectedIndex = -1
            End If
         End Sub)
   End Sub

   Private Sub cmbFormatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormatos.SelectedIndexChanged
      TryCatched(
         Sub()
            '-- REQ
            '-.PE-32045.- Limpio grilla si cambio de formato
            'If TypeOf (dgvSeleccionados.DataSource) Is DataTable Then
            '   DirectCast(dgvSeleccionados.DataSource, DataTable).Rows.Clear()
            'End If
            'If TypeOf (dgvDetalle.DataSource) Is DataTable Then
            '   DirectCast(dgvDetalle.DataSource, DataTable).Rows.Clear()
            'End If

            If GetFormatoEtiqueta().UtilizaCabecera Then
               txtCabecera.Visible = True
               txtCabecera.Focus()
               SetearColumnas()
            Else
               txtCabecera.Visible = False
            End If

            If GetFormatoEtiqueta().SolicitaListaPrecios2 Then
               lblListasDePrecios2.Visible = True
               cmbListasDePrecios2.Visible = True

               If TypeOf (dgvSeleccionados.DataSource) Is DataTable Then
                  DirectCast(dgvSeleccionados.DataSource, DataTable).Rows.Clear()
               End If

               If TypeOf (dgvDetalle.DataSource) Is DataTable Then
                  DirectCast(dgvDetalle.DataSource, DataTable).Rows.Clear()
               End If

               If dgvDetalle.Columns.Contains("PrecioVentaSinIVA1") = True Then
                  dgvDetalle.Columns("PrecioVentaSinIVA1").Visible = Not Publicos.PreciosConIVA
                  dgvDetalle.Columns("PrecioVentaConIVA1").Visible = Publicos.PreciosConIVA
               End If
            Else
               lblListasDePrecios2.Visible = False
               cmbListasDePrecios2.Visible = False
               SetearColumnas()
            End If
         End Sub)
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      If dgvDetalle.RowCount = 0 Then Exit Sub
      TryCatched(
         Sub()
            dgvDetalle.EndEdit()

            Dim dt As DataTable
            Dim drCl As DataRow = Nothing
            chbConIVA.Enabled = False
            'Registros Seleccionados Actualmente
            If dgvSeleccionados.Rows.Count > 0 Then
               dt = DirectCast(dgvSeleccionados.DataSource, DataTable)
            Else
               dt = CrearDT()
            End If

            For Each dr As DataGridViewRow In dgvDetalle.Rows

               If Not dr.Cells("Imprime").Value Is Nothing Then
                  If Boolean.Parse(dr.Cells("Imprime").Value.ToString()) Then

                     drCl = dt.NewRow()

                     drCl("Imprime") = True

                     drCl("IdSucursal") = Integer.Parse(dr.Cells("IdSucursal").Value.ToString())
                     drCl("NombreSucursal") = dr.Cells("NombreSucursal").Value
                     drCl("IdProducto") = dr.Cells("IdProducto").Value
                     drCl("NombreProducto") = dr.Cells("NombreProducto").Value
                     drCl("PrecioVentaSinIVA") = Decimal.Parse(dr.Cells("PrecioVentaSinIVA").Value.ToString())
                     drCl("Alicuota") = Decimal.Parse(dr.Cells("Alicuota").Value.ToString())
                     drCl("PrecioVentaConIVA") = Decimal.Parse(dr.Cells("PrecioVentaConIVA").Value.ToString())
                     drCl("PrecioListaDePreciosSinIVA") = Decimal.Parse(dr.Cells("PrecioListaDePreciosSinIVA").Value.ToString())
                     drCl("PrecioListaDePreciosConIVA") = Decimal.Parse(dr.Cells("PrecioListaDePreciosConIVA").Value.ToString())
                     If cmbListasDePrecios2.Visible Then
                        drCl("PrecioVentaConIVA1") = Decimal.Parse(dr.Cells("PrecioVentaConIVA1").Value.ToString())
                        drCl("PrecioVentaSinIVA1") = Decimal.Parse(dr.Cells("PrecioVentaSinIVA1").Value.ToString())

                        If dr.Cells("PrecioListaDePreciosSinIVA1").Value IsNot Nothing Then
                           drCl("PrecioListaDePreciosSinIVA1") = Decimal.Parse(dr.Cells("PrecioListaDePreciosSinIVA1").Value.ToString())
                        End If
                        If dr.Cells("PrecioListaDePreciosConIVA1").Value IsNot Nothing Then
                           drCl("PrecioListaDePreciosConIVA1") = Decimal.Parse(dr.Cells("PrecioListaDePreciosConIVA1").Value.ToString())
                        End If

                        drCl("ListaPrecios") = dr.Cells("ListaPrecio").Value.ToString()
                        drCl("ListaPrecios1") = dr.Cells("ListaPrecio1").Value.ToString()
                        drCl("PrecioListaDePrecios") = dr.Cells("PrecioVentaConIVA1").Value.ToString()

                     End If
                     drCl("Stock") = Decimal.Parse(dr.Cells("Stock").Value.ToString())
                     drCl("StockInicial") = Decimal.Parse(dr.Cells("StockInicial").Value.ToString())
                     drCl("IdMarca") = Integer.Parse(dr.Cells("IdMarca").Value.ToString())
                     drCl("NombreMarca") = dr.Cells("NombreMarca").Value
                     drCl("IdRubro") = Integer.Parse(dr.Cells("IdRubro").Value.ToString())
                     drCl("NombreRubro") = dr.Cells("NombreRubro").Value
                     drCl("FechaActualizacion") = Date.Parse(dr.Cells("FechaActualizacion").Value.ToString())
                     drCl("CodigoDeBarras") = dr.Cells("CodigoDeBarras").Value

                     '-.PE-31715.-
                     If Decimal.Parse(dr.Cells("UnidHasta1").Value.ToString()) = 0 Then
                        If Not String.IsNullOrEmpty(dr.Cells("UnidHastaSR1").Value.ToString()) Then
                           If Not String.IsNullOrEmpty(dr.Cells("UnidHastaSR3").Value.ToString()) AndAlso Decimal.Parse(dr.Cells("UnidHastaSR3").Value.ToString()) <> 0 Then
                              drCl("PrecioDesc") = Decimal.Parse(dr.Cells("PrecioDescSR3").Value.ToString())
                              drCl("UnidHasta1") = Decimal.Parse(dr.Cells("UnidHastaSR3").Value.ToString())
                              drCl("UHPorc1") = Decimal.Parse(dr.Cells("UHPorcSR3").Value.ToString())

                              drCl("PrecioDesc2") = Decimal.Parse(dr.Cells("PrecioDescSR2").Value.ToString())
                              drCl("UnidHasta2") = Decimal.Parse(dr.Cells("UnidHastaSR2").Value.ToString())
                              drCl("UHPorc2") = Decimal.Parse(dr.Cells("UHPorcSR2").Value.ToString())

                              drCl("PrecioDesc3") = Decimal.Parse(dr.Cells("PrecioDescSR1").Value.ToString())
                              drCl("UnidHasta3") = Decimal.Parse(dr.Cells("UnidHastaSR1").Value.ToString())
                              drCl("UHPorc3") = Decimal.Parse(dr.Cells("UHPorcSR1").Value.ToString())

                           ElseIf Not String.IsNullOrEmpty(dr.Cells("UnidHastaSR2").Value.ToString()) AndAlso Decimal.Parse(dr.Cells("UnidHastaSR2").Value.ToString()) <> 0 Then
                              drCl("PrecioDesc") = Decimal.Parse(dr.Cells("PrecioDescSR2").Value.ToString())
                              drCl("UnidHasta1") = Decimal.Parse(dr.Cells("UnidHastaSR2").Value.ToString())
                              drCl("UHPorc1") = Decimal.Parse(dr.Cells("UHPorcSR2").Value.ToString())

                              drCl("PrecioDesc2") = Decimal.Parse(dr.Cells("PrecioDescSR1").Value.ToString())
                              drCl("UnidHasta2") = Decimal.Parse(dr.Cells("UnidHastaSR1").Value.ToString())
                              drCl("UHPorc2") = Decimal.Parse(dr.Cells("UHPorcSR1").Value.ToString())

                              drCl("PrecioDesc3") = 0
                              drCl("UnidHasta3") = 0
                              drCl("UHPorc3") = 0
                           Else
                              drCl("PrecioDesc") = Decimal.Parse(dr.Cells("PrecioDescSR1").Value.ToString())
                              drCl("UnidHasta1") = Decimal.Parse(dr.Cells("UnidHastaSR1").Value.ToString())
                              drCl("UHPorc1") = Decimal.Parse(dr.Cells("UHPorcSR1").Value.ToString())

                              drCl("PrecioDesc2") = 0
                              drCl("UnidHasta2") = 0
                              drCl("UHPorc2") = 0

                              drCl("PrecioDesc3") = 0
                              drCl("UnidHasta3") = 0
                              drCl("UHPorc3") = 0
                           End If

                        Else
                           drCl("PrecioDesc") = 0
                           drCl("UnidHasta1") = 0
                           drCl("UHPorc1") = 0

                           drCl("PrecioDesc2") = 0
                           drCl("UnidHasta2") = 0
                           drCl("UHPorc2") = 0

                           drCl("PrecioDesc3") = 0
                           drCl("UnidHasta3") = 0
                           drCl("UHPorc3") = 0
                        End If
                     Else

                        If Not String.IsNullOrEmpty(dr.Cells("UnidHasta3").Value.ToString()) AndAlso Decimal.Parse(dr.Cells("UnidHasta3").Value.ToString()) <> 0 Then

                           drCl("PrecioDesc") = Decimal.Parse(dr.Cells("PrecioDesc3").Value.ToString())
                           drCl("UnidHasta1") = Decimal.Parse(dr.Cells("UnidHasta3").Value.ToString())
                           drCl("UHPorc1") = Decimal.Parse(dr.Cells("UHPorc3").Value.ToString())

                           drCl("PrecioDesc2") = Decimal.Parse(dr.Cells("PrecioDesc2").Value.ToString())
                           drCl("UnidHasta2") = Decimal.Parse(dr.Cells("UnidHasta2").Value.ToString())
                           drCl("UHPorc2") = Decimal.Parse(dr.Cells("UHPorc2").Value.ToString())

                           drCl("PrecioDesc3") = Decimal.Parse(dr.Cells("PrecioDesc").Value.ToString())
                           drCl("UnidHasta3") = Decimal.Parse(dr.Cells("UnidHasta1").Value.ToString())
                           drCl("UHPorc3") = Decimal.Parse(dr.Cells("UHPorc1").Value.ToString())

                        ElseIf Not String.IsNullOrEmpty(dr.Cells("UnidHasta2").Value.ToString()) AndAlso Decimal.Parse(dr.Cells("UnidHasta2").Value.ToString()) <> 0 Then

                           drCl("PrecioDesc") = Decimal.Parse(dr.Cells("PrecioDesc2").Value.ToString())
                           drCl("UnidHasta1") = Decimal.Parse(dr.Cells("UnidHasta2").Value.ToString())
                           drCl("UHPorc1") = Decimal.Parse(dr.Cells("UHPorc2").Value.ToString())

                           drCl("PrecioDesc2") = Decimal.Parse(dr.Cells("PrecioDesc").Value.ToString())
                           drCl("UnidHasta2") = Decimal.Parse(dr.Cells("UnidHasta1").Value.ToString())
                           drCl("UHPorc2") = Decimal.Parse(dr.Cells("UHPorc1").Value.ToString())

                           drCl("PrecioDesc3") = 0
                           drCl("UnidHasta3") = 0
                           drCl("UHPorc3") = 0

                        Else
                           drCl("PrecioDesc") = Decimal.Parse(dr.Cells("PrecioDesc").Value.ToString())
                              drCl("UnidHasta1") = Decimal.Parse(dr.Cells("UnidHasta1").Value.ToString())
                              drCl("UHPorc1") = Decimal.Parse(dr.Cells("UHPorc1").Value.ToString())

                              drCl("PrecioDesc2") = 0
                              drCl("UnidHasta2") = 0
                              drCl("UHPorc2") = 0

                              drCl("PrecioDesc3") = 0
                              drCl("UnidHasta3") = 0
                              drCl("UHPorc3") = 0
                           End If

                     End If


                           drCl("Foto") = dr.Cells("Foto").Value

                           dt.Rows.Add(drCl)

                           dr.Cells("Imprime").Value = False

                        End If

                     End If

            Next

            dgvSeleccionados.DataSource = dt

            dgvSeleccionados.Columns("gPrecioVentaSinIVA").Visible = Not chbConIVA.Checked
            dgvSeleccionados.Columns("gPrecioVentaConIVA").Visible = chbConIVA.Checked

            If cmbListasDePrecios2.Visible Then
               dgvSeleccionados.Columns("PrecioVentaSinIVA11").Visible = Not chbConIVA.Checked
               dgvSeleccionados.Columns("PrecioVentaConIVA11").Visible = chbConIVA.Checked
               dgvSeleccionados.Columns("ListaPrecios").Visible = True
               dgvSeleccionados.Columns("ListaPrecios1").Visible = True
            End If

            tssRegistros.Text = dgvSeleccionados.RowCount.ToString() & " Registros"
            chbConIVA.Enabled = (dgvSeleccionados.Rows.Count = 0)
         End Sub)
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(
         Sub()
            If dgvSeleccionados.Rows.Count > 0 And dgvSeleccionados.SelectedCells.Count > 0 Then
               dgvSeleccionados.Rows.RemoveAt(dgvSeleccionados.SelectedCells(0).OwningRow.Index)
               'If Me.dgvSeleccionados.Rows.Count > 0 Then
               '   Me.dgvSeleccionados.FirstDisplayedScrollingRowIndex = 0
               '   Me.dgvSeleccionados.Rows(0).Selected = True
               'End If
            End If
            tssRegistros.Text = dgvSeleccionados.RowCount.ToString() & " Registros"

            chbConIVA.Enabled = (dgvSeleccionados.Rows.Count = 0)
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosGrilla()

      Dim oProd = New Reglas.Productos()

      Dim FechaActDesde As Date = Nothing
      Dim FechaActHasta As Date = Nothing
      Dim IdListaDePrecios As Integer
      Dim IdListaDePrecios2 As Integer
      Dim idFormaPago As Integer? = Nothing
      Dim descRec As Decimal? = Nothing


      Dim Stock = "TODOS"

      IdListaDePrecios = cmbListaDePrecios.ValorSeleccionado(Of Integer)      ' DirectCast(Me.cmbListaDePrecios.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios
      IdListaDePrecios2 = cmbListasDePrecios2.ValorSeleccionado(Of Integer)   ' DirectCast(Me.cmbListasDePrecios2.SelectedItem, Entidades.ListaDePrecios).IdListaPrecios

      If chbFechaActualizado.Checked Then
         FechaActDesde = dtpDesde.Value
         FechaActHasta = dtpHasta.Value
      End If

      If chbStockPositivo.Checked Then
         Stock = "SOLOPOSITIVOS"
      End If

      If chbFormaPago.Checked Then
         idFormaPago = Integer.Parse(cmbFormaPago.SelectedValue.ToString())
      End If


      Dim imprimeLote As Boolean = GetFormatoEtiqueta().ImprimeLote

      If Not cmbListasDePrecios2.Visible Then
         dgvDetalle.DataSource = oProd.GetPreciosEtiquetas({actual.Sucursal.Id},
                                                           txtCodigo.Text.Trim(), txtProducto.Text.Trim(),
                                                           cmbMarca.GetMarcas(True),
                                                           cmbRubro.GetRubros(True),
                                                           idFormaPago,
                                                           IdListaDePrecios,
                                                           FechaActDesde, FechaActHasta,
                                                           Stock,
                                                           idTipoComprobante:="", letra:="", emisor:=0, numeroComprobante:=0, idProveedor:=0,
                                                           imprimeLote:=imprimeLote, mostrarProveedorHabitual:=False)
      Else
         dgvDetalle.DataSource = oProd.GetPreciosEtiquetas2Listas({actual.Sucursal.Id},
                                                                  txtCodigo.Text.Trim(), txtProducto.Text.Trim(),
                                                                  cmbMarca.GetMarcas(True),
                                                                  cmbRubro.GetRubros(True),
                                                                  idFormaPago,
                                                                  IdListaDePrecios,
                                                                  IdListaDePrecios2,
                                                                  FechaActDesde, FechaActHasta,
                                                                  Stock, imprimeLote:=imprimeLote)
      End If
      SetearColumnas()

      dgvDetalle.Columns("Lote").Visible = imprimeLote
      dgvSeleccionados.Columns("Lote2").Visible = imprimeLote

      tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

      If dgvDetalle.Rows.Count > 0 Then
         chbTodos.Enabled = True
         If dgvDetalle.Rows.Count = 1 Then
            dgvDetalle.Rows(0).Cells("Imprime").Value = True
            btnInsertar.PerformClick()
            If txtCodigo.Text.Trim().Length > 0 Then
               txtCodigo.Focus()
               txtCodigo.SelectAll()
            Else
               txtProducto.Focus()
               txtProducto.SelectAll()
            End If
         Else
            dgvDetalle.Focus()
         End If
      Else
         txtCodigo.Focus()
         chbTodos.Enabled = False
      End If

      chbTodos.Checked = False
   End Sub

   Private Function GenerarDT() As DataTable

      Dim dt As DataTable
      Dim drCl As DataRow = Nothing

      dt = Me.CrearDT2()

      Dim blnPrecioConIVA = Publicos.PreciosConIVA
      Dim Col = 0I

      Dim MaxColumnas = GetFormatoEtiqueta().MaximoColumnas

      For Each dr As DataGridViewRow In Me.dgvSeleccionados.Rows
         If Not dr.Cells("gImprime").Value Is Nothing AndAlso dr.Cells("gImprime").Value.ToString() <> "" Then
            If Boolean.Parse(dr.Cells("gImprime").Value.ToString()) Then

               Col += 1
               If Col = 1 Then
                  drCl = dt.NewRow()
               End If

               If Not String.IsNullOrEmpty(dr.Cells("gCodigoDeBarras").Value.ToString.Trim()) Then
                  drCl("IdProducto" & Col.ToString()) = dr.Cells("gCodigoDeBarras").Value.ToString.Trim()
               Else
                  drCl("IdProducto" & Col.ToString()) = dr.Cells("gIdProducto").Value.ToString.Trim()
               End If

               drCl("NombreProducto" & Col.ToString()) = dr.Cells("gNombreProducto").Value
               drCl("IdMarca" & Col.ToString()) = dr.Cells("gIdMarca").Value
               drCl("NombreMarca" & Col.ToString()) = dr.Cells("gNombreMarca").Value
               drCl("IdRubro" & Col.ToString()) = dr.Cells("gIdRubro").Value
               drCl("NombreRubro" & Col.ToString()) = dr.Cells("gNombreRubro").Value
               drCl("Alicuota" & Col.ToString()) = dr.Cells("gAlicuota").Value

               If Me.chbConIVA.Checked Then
                  drCl("PrecioVenta" & Col.ToString()) = dr.Cells("gPrecioVentaConIVA").Value
                  drCl("PrecioDescuento1" & Col.ToString()) = Decimal.Parse(dr.Cells("gPrecioDesc").Value.ToString())
                  drCl("PrecioDescuento2" & Col.ToString()) = Decimal.Parse(dr.Cells("PrecioDesc2").Value.ToString())
                  drCl("PrecioDescuento3" & Col.ToString()) = Decimal.Parse(dr.Cells("PrecioDesc3").Value.ToString())

                  drCl("PrecioListaDePrecios" & Col.ToString()) = dr.Cells("gPrecioListaDePreciosConIVA").Value
                  If Me.cmbListasDePrecios2.Visible Then
                     drCl("PrecioVenta1" & Col.ToString()) = dr.Cells("PrecioVentaConIVA11").Value
                     drCl("ListaPrecios" & Col.ToString()) = dr.Cells("ListaPrecios").Value
                     drCl("ListaPrecios1" & Col.ToString()) = dr.Cells("ListaPrecios1").Value
                     '-.PE-32199.-
                     If dgvSeleccionados.Columns.Contains("gPrecioListaDePreciosConIVA1") Then
                        drCl("PrecioListaDePrecios" & Col.ToString()) = dr.Cells("PrecioVentaConIVA11").Value
                     End If
                  End If

               Else
                  drCl("PrecioVenta" & Col.ToString()) = dr.Cells("gPrecioVentaSinIVA").Value
                  drCl("PrecioDescuento" & Col.ToString()) = Decimal.Parse(dr.Cells("gPrecioVentaSinIVA").Value.ToString()) - (Decimal.Parse(dr.Cells("gPrecioVentaSinIVA").Value.ToString()) * (Math.Abs(Decimal.Parse(dr.Cells("gUHPorc1").Value.ToString())) / 100))
                  drCl("PrecioListaDePrecios" & Col.ToString()) = dr.Cells("gPrecioListaDePreciosSinIVA").Value
                  If Me.cmbListasDePrecios2.Visible Then
                     drCl("PrecioVenta1" & Col.ToString()) = dr.Cells("PrecioVentaSinIVA11").Value
                     drCl("ListaPrecios" & Col.ToString()) = dr.Cells("ListaPrecios").Value
                     drCl("ListaPrecios1" & Col.ToString()) = dr.Cells("ListaPrecios1").Value
                     '-.PE-32199.-
                     drCl("PrecioListaDePrecios" & Col.ToString()) = dr.Cells("gPrecioListaDePreciosSinIVA1").Value
                  End If
               End If

               drCl("FechaActualizacion" & Col.ToString()) = dr.Cells("gFechaActualizacion").Value

               drCl("TextoCabecera" & Col.ToString()) = Me.txtCabecera.Text

               '-.PE-31715.-
               drCl("PrecioDesc" & Col.ToString()) = drCl("PrecioListaDePrecios" & Col.ToString())  'dr.Cells("gPrecioDesc").Value
               drCl("UnidHasta1" & Col.ToString()) = dr.Cells("gUnidHasta1").Value

               drCl("UnidadesHasta1" & Col.ToString()) = dr.Cells("gUnidHasta1").Value
               drCl("UnidadesHasta2" & Col.ToString()) = dr.Cells("UnidHasta2").Value
               drCl("UnidadesHasta3" & Col.ToString()) = dr.Cells("UnidHasta3").Value

               drCl("Foto" & Col.ToString()) = dr.Cells("Foto").Value

               '   drCl("PrecioVenta" & Col.ToString()) = Math.Round(Double.Parse(drCl("PrecioVenta" & Col.ToString()).ToString()), Eniac.Reglas.Publicos.PreciosDecimalesEnVenta)

               If Col = MaxColumnas Then
                  dt.Rows.Add(drCl)
                  Col = 0
               End If
            End If
         End If
      Next

      'como son 3 columnas, verifico que inserte la fila por mas que no haya completado la fila
      If Col < MaxColumnas And Col <> 0 Then
         dt.Rows.Add(drCl)
      End If
      Return dt
   End Function

   Private Function CrearDT() As DataTable

      Dim dtTemp = New DataTable()

      With dtTemp
         .Columns.Add("Imprime")
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("NombreSucursal", GetType(String))
         .Columns.Add("IdProducto", GetType(String))
         .Columns.Add("NombreProducto", GetType(String))
         .Columns.Add("PrecioVentaSinIVA", GetType(Decimal))
         .Columns.Add("Alicuota", GetType(Decimal))
         .Columns.Add("PrecioVentaConIVA", GetType(Decimal))
         .Columns.Add("PrecioListaDePreciosSinIVA", GetType(Decimal))
         .Columns.Add("PrecioListaDePreciosConIVA", GetType(Decimal))
         If cmbListasDePrecios2.Visible Then
            .Columns.Add("PrecioVentaConIVA1", GetType(Decimal))
            .Columns.Add("PrecioVentaSinIVA1", GetType(Decimal))
            .Columns.Add("ListaPrecios", GetType(String))
            .Columns.Add("ListaPrecios1", GetType(String))

            .Columns.Add("PrecioListaDePreciosSinIVA1", GetType(Decimal))
            .Columns.Add("PrecioListaDePreciosConIVA1", GetType(Decimal))
            .Columns.Add("PrecioListaDePrecios", GetType(Decimal))
         End If
         .Columns.Add("Stock", GetType(Decimal))
         .Columns.Add("StockInicial", GetType(Decimal))
         .Columns.Add("IdMarca", GetType(Integer))
         .Columns.Add("NombreMarca", GetType(String))
         .Columns.Add("IdRubro", GetType(Integer))
         .Columns.Add("NombreRubro", GetType(String))
         .Columns.Add("FechaActualizacion", GetType(Date))
         .Columns.Add("CodigoDeBarras", GetType(String))

         '-.PE-31715.-
         .Columns.Add("PrecioDesc", GetType(Decimal))
         .Columns.Add("UnidHasta1", GetType(Decimal))
         .Columns.Add("UHPorc1", GetType(Decimal))

         .Columns.Add("PrecioDesc2", GetType(Decimal))
         .Columns.Add("UnidHasta2", GetType(Decimal))
         .Columns.Add("UHPorc2", GetType(Decimal))


         .Columns.Add("PrecioDesc3", GetType(Decimal))
         .Columns.Add("UnidHasta3", GetType(Decimal))
         .Columns.Add("UHPorc3", GetType(Decimal))


         .Columns.Add("Foto", GetType(Byte()))

      End With

      Return dtTemp

   End Function

   Private Function CrearDT2() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("IdProducto1", GetType(String))
         .Columns.Add("NombreProducto1", GetType(String))
         .Columns.Add("Tamano1", GetType(Decimal))
         .Columns.Add("IdUnidadDeMedida1", GetType(String))
         .Columns.Add("IdMarca1", GetType(Integer))
         .Columns.Add("NombreMarca1", GetType(String))
         .Columns.Add("IdRubro1", GetType(Integer))
         .Columns.Add("NombreRubro1", GetType(String))
         .Columns.Add("IdTipoImpuesto1", GetType(String))
         .Columns.Add("Alicuota1", GetType(Decimal))
         .Columns.Add("PrecioFabrica1", GetType(Decimal))
         .Columns.Add("PrecioCosto1", GetType(Decimal))
         .Columns.Add("PrecioVenta1", GetType(Decimal))
         .Columns.Add("PrecioDesc1", GetType(Decimal)) '-.PE-31715.-
         .Columns.Add("PrecioDescuento1", GetType(Decimal))
         .Columns.Add("UnidadesHasta1", GetType(Decimal))

         .Columns.Add("PrecioDescuento11", GetType(Decimal))
         .Columns.Add("PrecioDescuento21", GetType(Decimal))
         .Columns.Add("PrecioDescuento31", GetType(Decimal))

         .Columns.Add("UnidadesHasta11", GetType(Decimal))
         .Columns.Add("UnidadesHasta21", GetType(Decimal))
         .Columns.Add("UnidadesHasta31", GetType(Decimal))

         .Columns.Add("UnidHasta11", GetType(Decimal))

         .Columns.Add("PrecioListaDePrecios1", GetType(Decimal))


         If cmbListasDePrecios2.Visible Then
            .Columns.Add("PrecioVenta11", GetType(Decimal))
            .Columns.Add("ListaPrecios1", GetType(String))
            .Columns.Add("ListaPrecios11", GetType(String))
         End If
         .Columns.Add("FechaActualizacion1", GetType(Date))
         .Columns.Add("TextoCabecera1", GetType(String))

         .Columns.Add("IdProducto2", GetType(String))
         .Columns.Add("NombreProducto2", GetType(String))
         .Columns.Add("Tamano2", GetType(Decimal))
         .Columns.Add("IdUnidadDeMedida2", GetType(String))
         .Columns.Add("IdMarca2", GetType(Integer))
         .Columns.Add("NombreMarca2", GetType(String))
         .Columns.Add("IdRubro2", GetType(Integer))
         .Columns.Add("NombreRubro2", GetType(String))
         .Columns.Add("IdTipoImpuesto2", GetType(String))
         .Columns.Add("Alicuota2", GetType(Decimal))
         .Columns.Add("PrecioFabrica2", GetType(Decimal))
         .Columns.Add("PrecioCosto2", GetType(Decimal))
         .Columns.Add("PrecioVenta2", GetType(Decimal))
         .Columns.Add("PrecioDesc2", GetType(Decimal)) '-.PE-31715.-
         .Columns.Add("PrecioDescuento2", GetType(Decimal))
         .Columns.Add("UnidadesHasta2", GetType(Decimal))

         .Columns.Add("PrecioDescuento12", GetType(Decimal))
         .Columns.Add("PrecioDescuento22", GetType(Decimal))
         .Columns.Add("PrecioDescuento32", GetType(Decimal))

         .Columns.Add("UnidadesHasta12", GetType(Decimal))
         .Columns.Add("UnidadesHasta22", GetType(Decimal))
         .Columns.Add("UnidadesHasta32", GetType(Decimal))

         .Columns.Add("PrecioListaDePrecios2", GetType(Decimal))
         .Columns.Add("PrecioListaDePrecios3", GetType(Decimal))

         .Columns.Add("UnidHasta12", GetType(Decimal))
         If cmbListasDePrecios2.Visible Then
            .Columns.Add("PrecioVenta12", GetType(Decimal))
            .Columns.Add("ListaPrecios2", GetType(String))
            .Columns.Add("ListaPrecios12", GetType(String))
         End If
         .Columns.Add("FechaActualizacion2", GetType(Date))
         .Columns.Add("TextoCabecera2", GetType(String))

         .Columns.Add("IdProducto3", GetType(String))
         .Columns.Add("NombreProducto3", GetType(String))
         .Columns.Add("Tamano3", GetType(Decimal))
         .Columns.Add("IdUnidadDeMedida3", GetType(String))
         .Columns.Add("IdMarca3", GetType(Integer))
         .Columns.Add("NombreMarca3", GetType(String))
         .Columns.Add("IdRubro3", GetType(Integer))
         .Columns.Add("NombreRubro3", GetType(String))
         .Columns.Add("IdTipoImpuesto3", GetType(String))
         .Columns.Add("Alicuota3", GetType(Decimal))
         .Columns.Add("PrecioFabrica3", GetType(Decimal))
         .Columns.Add("PrecioCosto3", GetType(Decimal))
         .Columns.Add("PrecioVenta3", GetType(Decimal))
         .Columns.Add("PrecioDesc3", GetType(Decimal)) '-.PE-32045.-
         .Columns.Add("PrecioDescuento3", GetType(Decimal))
         .Columns.Add("UnidadesHasta3", GetType(Decimal))

         .Columns.Add("PrecioDescuento13", GetType(Decimal))
         .Columns.Add("PrecioDescuento23", GetType(Decimal))
         .Columns.Add("PrecioDescuento33", GetType(Decimal))

         .Columns.Add("UnidadesHasta13", GetType(Decimal))
         .Columns.Add("UnidadesHasta23", GetType(Decimal))
         .Columns.Add("UnidadesHasta33", GetType(Decimal))

         .Columns.Add("UnidHasta13", GetType(Decimal))
         If cmbListasDePrecios2.Visible Then
            .Columns.Add("PrecioVenta13", GetType(Decimal))
            .Columns.Add("ListaPrecios3", GetType(String))
            .Columns.Add("ListaPrecios13", GetType(String))
         End If
         .Columns.Add("FechaActualizacion3", GetType(Date))
         .Columns.Add("TextoCabecera3", GetType(String))

         .Columns.Add("Foto1", GetType(Byte()))
         .Columns.Add("Foto2", GetType(Byte()))
         .Columns.Add("Foto3", GetType(Byte()))

      End With
      Return dtTemp
   End Function

#End Region

   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      'If Me._estaCargando Then Exit Sub
      TryCatched(Sub() SetearColumnas())
   End Sub

   Private Sub chbFormaDePago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged
      TryCatched(
         Sub()
            If chbFormaPago.Checked Then
               cmbFormaPago.Enabled = True
            Else
               cmbFormaPago.Enabled = False
               cmbFormaPago.SelectedIndex = -1
            End If
         End Sub)
   End Sub

   Private Sub SetearColumnas()
      dgvDetalle.Columns("PrecioVentaSinIVA").Visible = Not chbConIVA.Checked
      dgvDetalle.Columns("PrecioVentaConIVA").Visible = chbConIVA.Checked
   End Sub

   Private Function GetFormatoEtiqueta() As Entidades.FormatoEtiqueta
      If cmbFormatos.SelectedIndex < 0 Then
         Return New Entidades.FormatoEtiqueta()
      End If
      Return DirectCast(cmbFormatos.SelectedItem, Entidades.FormatoEtiqueta)
   End Function
End Class