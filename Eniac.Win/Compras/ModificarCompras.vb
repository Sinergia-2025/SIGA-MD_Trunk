Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Entidades

Public Class ModificarCompras

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, True, "COMPRAS")
         Me.cmbTiposComprobantes.SelectedIndex = -1

         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreProveedor", "Observacion"}, {"Ver"})

         Me.LeerPreferencias()

         Me.dtpDesde.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub ModificarCompras_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbModificar.Click

      If ugDetalle.ActiveRow Is Nothing Then Exit Sub

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.ModificarCompra()

         Me.btnConsultar_Click(Me.btnConsultar, New EventArgs())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub rdbPorPeriodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPorPeriodoFiscal.CheckedChanged
      Me.HabilitarFiltrosFecha(True, False)
      Me.dtpPeriodoFiscal.Focus()
   End Sub

   Private Sub rdbPorFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPorFechas.CheckedChanged
      Me.HabilitarFiltrosFecha(False, True)
      Me.dtpDesde.Focus()
   End Sub

   Private Sub rdbAmbos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbAmbos.CheckedChanged
      Me.HabilitarFiltrosFecha(True, True)
      Me.dtpPeriodoFiscal.Focus()
   End Sub
   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            Me.dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbProveedor.Checked And Me.bscCodigoProveedor.Text.Length = 0 Then
            MessageBox.Show("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProveedor.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ugDetalle_ClickCellButton(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton

      Try
         Me.Cursor = Cursors.WaitCursor
         If e.Cell.Column.Index = 0 And e.Cell.Row.Index <> -1 Then
            Dim oCompras As Reglas.Compras = New Reglas.Compras()

            Dim Compra As Entidades.Compra = oCompras.GetUna(actual.Sucursal.Id, _
                        e.Cell.Row.Cells("IdTipoComprobante").Value.ToString(), _
                        e.Cell.Row.Cells("Letra").Value.ToString(), _
                        Short.Parse(e.Cell.Row.Cells("CentroEmisor").Value.ToString()), _
                        Long.Parse(e.Cell.Row.Cells("NumeroComprobante").Value.ToString()), _
                        Long.Parse(e.Cell.Row.Cells("IdProveedor").Value.ToString()))

            Dim oImpr As ImpresionCompra = New ImpresionCompra(Compra)

            oImpr.ImprimirComprobante(True, Reglas.Publicos.Compras.Redondeo.ComprasDecimalesEnTotalGeneral)
         Else
            If e.Cell.Column.Index = 13 And e.Cell.Row.Index <> -1 Then

               If String.IsNullOrEmpty(e.Cell.Row.Cells("CantidadInvocados").Value.ToString()) Then Exit Sub

               Dim oComprobantesInvocados As FacturablesInvocadosCom

               oComprobantesInvocados = New FacturablesInvocadosCom(e.Cell.Row.Cells("IdTipoComprobante").Value.ToString(), _
                                                                  e.Cell.Row.Cells("Letra").Value.ToString(), _
                                                                 Short.Parse(e.Cell.Row.Cells("CentroEmisor").Value.ToString()), _
                                                                  Long.Parse(e.Cell.Row.Cells("NumeroComprobante").Value.ToString()), _
                                                                  Long.Parse(e.Cell.Row.Cells("IdProveedor").Value.ToString()))

               oComprobantesInvocados.ShowDialog()

            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   'If ugDetalle.ActiveRow Is Nothing Then Exit Sub

   'Try

   '   Me.Cursor = Cursors.WaitCursor

   '   Me.ModificarCompra()

   '   Me.btnConsultar_Click(Me.btnConsultar, New EventArgs())

   'Catch ex As Exception
   '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

   'Finally
   '   Me.Cursor = Cursors.Default
   'End Try
   Private Sub chbTipoComprobante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTipoComprobante.CheckedChanged

      Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

      If Not Me.chbTipoComprobante.Checked Then
         Me.cmbTiposComprobantes.SelectedIndex = -1
      Else
         If Me.cmbTiposComprobantes.Items.Count > 0 Then
            Me.cmbTiposComprobantes.SelectedIndex = 0
         End If
      End If

      Me.cmbTiposComprobantes.Focus()

   End Sub

   Private Sub chbProveedor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

      Me.bscCodigoProveedor.Focus()

   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dtpPeriodoFiscal_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodoFiscal.ValueChanged
      dtpPeriodoFiscal.Value = dtpPeriodoFiscal.Value.PrimerDiaMes()
   End Sub

   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As UltraWinGrid.DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
      If ugDetalle.ActiveRow Is Nothing Then Exit Sub

      Try

         Me.Cursor = Cursors.WaitCursor

         Me.ModificarCompra()

         Me.btnConsultar_Click(Me.btnConsultar, New EventArgs())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

#Region "Metodos"

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()

      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False
   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now
      Me.chbProveedor.Checked = False
      Me.chbTipoComprobante.Checked = False
      Me.rdbPorFechas.Checked = True

      If TypeOf (Me.ugDetalle.DataSource) Is DataTable Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

      Me.dtpDesde.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oCompra As Reglas.Compras = New Reglas.Compras()

      Dim decNetoNoGravado As Decimal = 0
      Dim decNeto As Decimal = 0
      Dim decIva210 As Decimal = 0
      Dim decIva105 As Decimal = 0
      Dim decIva270 As Decimal = 0
      Dim decTotal As Decimal = 0

      Dim IdProveedor As Long = 0

      Dim TipoComprobante As String = String.Empty
      Dim PeriodoFiscal As Integer = 0

      Try
         If Me.bscCodigoProveedor.Tag IsNot Nothing Then
            IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         End If

         If Me.cmbTiposComprobantes.Enabled Then
            TipoComprobante = Me.cmbTiposComprobantes.SelectedValue.ToString()
         End If

         If Me.rdbPorPeriodoFiscal.Checked Or Me.rdbAmbos.Checked Then
            PeriodoFiscal = Integer.Parse(Me.dtpPeriodoFiscal.Value.ToString("yyyyMM"))
         End If

         Dim dtDetalle As DataTable, dt As DataTable     ', drCl As DataRow

         'dtDetalle = oCompra.GetModificacionCompras(actual.Sucursal.Id, _
         '                                           Me.dtpDesde.Value, Me.dtpHasta.Value, _
         '                                           IdProveedor, _
         '                                           TipoComprobante, PeriodoFiscal)
         dtDetalle = oCompra.GetPorRangoFechas({actual.Sucursal},
                                               actual.Sucursal.IdEmpresa, PeriodoFiscal,
                                               Me.dtpDesde.Value, Me.dtpHasta.Value,
                                               IdProveedor,
                                               IdComprador:=0,
                                               grabaLibro:="TODOS", afectaCaja:="TODOS", esComercial:="TODOS",
                                               tipoComprobante:=TipoComprobante,
                                               numeroComprobante:=0, idFormasPago:=0, idRubro:=0, estado:="", idCategoria:=0, idUsuario:="", idCentroCosto:=0,
                                               idMoneda:=Entidades.Moneda.Peso, tipoConversion:=Entidades.Moneda_TipoConversion.Comprobante, cotizDolar:=0)

         dt = ConsultarCompras.CrearDT()

         'For Each dr As DataRow In dtDetalle.Rows

         '   drCl = dt.NewRow()

         '   'If dr("TipoImpresora").ToString() = "NORMAL" Then
         '   drCl("Ver") = "..."
         '   'Else
         '   '   drCl("Ver") = "( F )"
         '   'End If

         '   If Not String.IsNullOrEmpty(dr("PeriodoFiscal").ToString()) Then
         '      drCl("PeriodoFiscal") = Integer.Parse(dr("PeriodoFiscal").ToString())
         '   End If
         '   drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
         '   drCl("NombreTipoComprobante") = dr("NombreTipoComprobante").ToString()
         '   drCl("Letra") = dr("Letra").ToString()
         '   drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
         '   drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
         '   drCl("Fecha") = Date.Parse(dr("Fecha").ToString())

         '   drCl("IdProveedor") = dr("IdProveedor").ToString()
         '   drCl("CodigoProveedor") = dr("CodigoProveedor").ToString()

         '   drCl("NombreProveedor") = dr("NombreProveedor").ToString()
         '   drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal").ToString()
         '   drCl("FormaDePago") = dr("FormaDePago").ToString()

         '   If Integer.Parse(dr("CantidadInvocados").ToString()) > 0 Then
         '      drCl("CantidadInvocados") = Integer.Parse(dr("CantidadInvocados").ToString())
         '   End If

         '   drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString())

         '   drCl("ImportePesos") = dr("ImportePesos")
         '   drCl("ImporteTarjetas") = dr("ImporteTarjetas")
         '   drCl("ImporteCheques") = dr("ImporteCheques")
         '   drCl("ImporteTransfBancaria") = dr("ImporteTransfBancaria")
         '   drCl("IdCuentaBancaria") = dr("IdCuentaBancaria")
         '   drCl("NombreCuenta") = dr("NombreCuenta")
         '   drCl("NombreBanco") = dr("NombreBanco")

         '   drCl("DerechoAduanero") = dr("DerechoAduanero")

         '   drCl("Observacion") = dr("Observacion").ToString()
         '   drCl("FechaActualizacion") = Date.Parse(dr("FechaActualizacion").ToString())
         '   drCl("Usuario") = dr("Usuario").ToString()

         '   drCl("IdPlanCuenta") = dr("IdPlanCuenta")
         '   drCl("IdAsiento") = dr("IdAsiento")

         '   drCl("TotalBruto") = dr("TotalBruto")
         '   drCl("TotalNeto") = dr("TotalNeto")
         '   drCl("TotalIVA") = dr("TotalIVA")
         '   drCl("TotalPercepciones") = dr("TotalPercepciones")


         '   drCl(Entidades.Compra.Columnas.MetodoGrabacion.ToString()) = dr(Entidades.Compra.Columnas.MetodoGrabacion.ToString())
         '   drCl(Entidades.Compra.Columnas.IdFuncion.ToString()) = dr(Entidades.Compra.Columnas.IdFuncion.ToString())

         '   dt.Rows.Add(drCl)

         '   decNeto = decNeto + Decimal.Parse(dr("TotalNeto").ToString())
         '   decIva105 = decIva105 + Decimal.Parse(dr("TotalIVA").ToString())
         '   decTotal = decTotal + Decimal.Parse(dr("ImporteTotal").ToString())

         'Next

         'txtNetoNoGravado.Text = decNetoNoGravado.ToString("#,##0.00")
         'txtNeto.Text = decNeto.ToString("#,##0.00")
         'txtIva210.Text = decIva210.ToString("#,##0.00")
         'txtIva105.Text = decIva105.ToString("#,##0.00")
         'txtTotal.Text = decTotal.ToString("#,##0.00")

         'Me.dgvDetalle.DataSource = dt

         Me.ugDetalle.DataSource = ConsultarCompras.CopiarDt(dtDetalle, dt)
         ConsultarCompras.FormatearGrilla(ugDetalle)

         Me.tssRegistros.Text = ugDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   'Private Function CrearDT() As DataTable

   '   Dim dtTemp As DataTable = New DataTable()

   '   With dtTemp
   '      .Columns.Add("Ver")
   '      .Columns.Add("PeriodoFiscal", GetType(Integer))
   '      .Columns.Add("IdTipoComprobante", GetType(String))
   '      .Columns.Add("NombreTipoComprobante", GetType(String))
   '      .Columns.Add("Letra", GetType(String))
   '      .Columns.Add("CentroEmisor", GetType(Integer))
   '      .Columns.Add("NumeroComprobante", GetType(Long))
   '      .Columns.Add("Fecha", GetType(DateTime))
   '      .Columns.Add("IdProveedor", GetType(Long))
   '      .Columns.Add("CodigoProveedor", GetType(Long))
   '      .Columns.Add("NombreProveedor", GetType(String))
   '      .Columns.Add("NombreCategoriaFiscal", GetType(String))
   '      .Columns.Add("FormaDePago", GetType(String))
   '      .Columns.Add("CantidadInvocados", GetType(Integer))
   '      .Columns.Add("ImporteTotal", GetType(Decimal))
   '      .Columns.Add("Observacion", GetType(String))
   '      .Columns.Add("FechaActualizacion", GetType(DateTime))
   '      .Columns.Add("Usuario", GetType(String))

   '      .Columns.Add("IdPlanCuenta", GetType(Integer))
   '      .Columns.Add("IdAsiento", GetType(Integer))

   '      .Columns.Add("ImportePesos", GetType(Decimal))
   '      .Columns.Add("ImporteTarjetas", GetType(Decimal))
   '      .Columns.Add("ImporteCheques", GetType(Decimal))
   '      .Columns.Add("ImporteTransfBancaria", GetType(Decimal))
   '      .Columns.Add("IdCuentaBancaria", GetType(Integer))
   '      .Columns.Add("NombreBanco", GetType(String))
   '      .Columns.Add("NombreCuenta", GetType(String))
   '      .Columns.Add("DerechoAduanero", GetType(Decimal))

   '      .Columns.Add("TotalBruto", GetType(Decimal))
   '      .Columns.Add("TotalNeto", GetType(Decimal))
   '      .Columns.Add("TotalIVA", GetType(Decimal))
   '      .Columns.Add("TotalPercepciones", GetType(Decimal))

   '      .Columns.Add(Entidades.Compra.Columnas.MetodoGrabacion.ToString(), GetType(String))
   '      .Columns.Add(Entidades.Compra.Columnas.IdFuncion.ToString(), GetType(String))

   '      '.Columns.Add("Ver")
   '      '.Columns.Add("PeriodoFiscal", System.Type.GetType("System.Int32"))
   '      '.Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
   '      '.Columns.Add("NombreTipoComprobante", System.Type.GetType("System.String"))
   '      '.Columns.Add("Letra", System.Type.GetType("System.String"))
   '      '.Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
   '      '.Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
   '      '.Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
   '      '.Columns.Add("IdProveedor", System.Type.GetType("System.Int64"))
   '      '.Columns.Add("CodigoProveedor", System.Type.GetType("System.Int64"))
   '      '.Columns.Add("NombreProveedor", System.Type.GetType("System.String"))
   '      '.Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
   '      '.Columns.Add("FormaDePago", System.Type.GetType("System.String"))
   '      '.Columns.Add("NetoNoGravado", System.Type.GetType("System.Decimal"))
   '      '.Columns.Add("Neto", System.Type.GetType("System.Decimal"))
   '      '.Columns.Add("Iva105", System.Type.GetType("System.Decimal"))
   '      '.Columns.Add("Iva210", System.Type.GetType("System.Decimal"))
   '      '.Columns.Add("Iva270", System.Type.GetType("System.Decimal"))
   '      '.Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
   '      '.Columns.Add("PercepcionIVA", System.Type.GetType("System.Decimal"))
   '      '.Columns.Add("PercepcionIB", System.Type.GetType("System.Decimal"))
   '      '.Columns.Add("PercepcionGanancias", System.Type.GetType("System.Decimal"))
   '      '.Columns.Add("PercepcionVarias", System.Type.GetType("System.Decimal"))
   '      '.Columns.Add("Observacion", System.Type.GetType("System.String"))
   '   End With

   '   Return dtTemp

   'End Function

   Private Sub ModificarCompra()

      Dim oCompras As Reglas.Compras = New Reglas.Compras()

      Dim Compra As Entidades.Compra = oCompras.GetUna(actual.Sucursal.Id, _
                  Me.ugDetalle.ActiveRow.Cells("IdTipoComprobante").Value.ToString(), _
                  Me.ugDetalle.ActiveRow.Cells("Letra").Value.ToString(), _
                  Short.Parse(Me.ugDetalle.ActiveRow.Cells("CentroEmisor").Value.ToString()), _
                  Long.Parse(Me.ugDetalle.ActiveRow.Cells("NumeroComprobante").Value.ToString()), _
                  Long.Parse(Me.ugDetalle.ActiveRow.Cells("IdProveedor").Value.ToString()))

      Dim frmModifCompraDet As New ModificarComprasDetalle(Compra)

      frmModifCompraDet.ShowDialog()

   End Sub

   Private Sub HabilitarFiltrosFecha(ByVal ActivaPeriodoFiscal As Boolean, ByVal ActivaFechas As Boolean)
      Me.dtpPeriodoFiscal.Enabled = ActivaPeriodoFiscal
      Me.chkMesCompleto.Enabled = ActivaFechas
      Me.dtpDesde.Enabled = ActivaFechas
      Me.dtpHasta.Enabled = ActivaFechas
   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True

      With filtro

         If Me.rdbPorPeriodoFiscal.Checked Or Me.rdbAmbos.Checked Then
            filtro.AppendFormat(" - Periodo: {0}", Me.dtpPeriodoFiscal.Value.ToString("MMMMM") & " " & Me.dtpPeriodoFiscal.Value.ToString("yyyy"))
         End If

         If Me.chkMesCompleto.Checked Then
            filtro.AppendFormat(" - Fechas: Desde {0:dd/MM/yyyy} Hasta {1:dd/MM/yyyy}", dtpDesde.Value, dtpHasta.Value)
         End If


         If Me.chbProveedor.Checked Then
            filtro.AppendFormat(" - Proveedor: {0} - {1}", Me.bscCodigoProveedor.Text, Me.bscProveedor.Text)
         End If

         If Me.chbTipoComprobante.Checked Then
            filtro.AppendFormat(" - Tipo de Comprobante: {0}", Me.cmbTiposComprobantes.Text)
         End If

      End With

      Return filtro.ToString.Trim().Trim("-"c)

   End Function
   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugDetalle.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugDetalle.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


#End Region

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Me.CargarFiltrosImpresion

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
End Class