Option Explicit On
Option Strict Off

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.ComponentModel
Imports System.IO


Public Class ExportacionDeCompras

#Region "Campos"

   Private rComprasExportarDatos As Reglas.ComprasExportarDatos
   Private _publicos As publicos
   Private _columnaSelec As String = "Selec"

#End Region

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Me.dtpDesde.Value.AddMonths(-1)
         Me.dtpHasta.Value = DateTime.Today

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "COMPRAS")
         Me._publicos.CargaComboDesdeEnum(cmbTiposExportacion, GetType(Reglas.Publicos.ExportacionComprasEnum), valueAsString:=True)

         cmbTiposComprobantes.Initializar(False, "COMPRAS")
         Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()

         Me._publicos.CargaComboDesdeEnum(Me.cmbGrabanLibro, GetType(Entidades.Publicos.SiNoTodos))

         Me.cmbSucursal.Initializar(False, IdFuncion)
         Me.cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

         MostrarNombreArchivo()

         Me.tsbExportarCompras.Enabled = False

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#Region "Métodos"
   Private Sub ExportarDatos(dtComprobantes As DataTable)

      Dim stb As System.Text.StringBuilder = New StringBuilder
      Dim cant As Integer = 0
      Dim cant1 As Integer = 0

      Me.ugDetalle.UpdateData()

      For Each dr As DataRow In dtComprobantes.Select(String.Format("{0} = True", _columnaSelec))
         cant += 1
      Next

      Select Case Me.cmbTiposExportacion.SelectedValue.ToString()
         Case Reglas.Publicos.ExportacionComprasEnum.Holistor.ToString()
            If cant = 0 Then
               ShowMessage("No seleccionó ningún Comprobante")
               Exit Sub
            End If
      End Select
      stb.AppendFormat("Realmente desea generar el archivo para los {0} comprobantes?", cant)

      ''# Si el cliente no tiene configurado Tipo de Doc. se lo informo al usuario por pantalla
      'For Each row As DataRow In dtComprobantes.Select(String.Format("{0} = True", _columnaSelec))
      '   If Not IsNumeric(row(Entidades.AFIPTipoDocumento.Columnas.IdAFIPTipoDocumento.ToString())) AndAlso
      '      row(_columnaSelec) Then
      '      ShowMessage(String.Format("ATENCIÓN: El cliente {0} no tiene configurado su Tipo de Doc. Primero debe configurarlo para luego poder visualizarlo en el archivo exportado.",
      '                                row.Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString())))
      '      Exit For
      '   End If
      'Next

      If ShowPregunta(stb.ToString()) = Windows.Forms.DialogResult.Yes Then
         Dim nombreArchivo As String

         '# Nombre del Archivo a exportar
         nombreArchivo = txtArchivoDestino.Text

         Select Case Me.cmbTiposExportacion.SelectedValue.ToString()
            Case Reglas.Publicos.ExportacionComprasEnum.Holistor.ToString()
               rComprasExportarDatos = New Reglas.ComprasExportarDatos

               Me.CrearComprasHolistor(DirectCast(Me.ugDetalle.DataSource, DataTable))
               rComprasExportarDatos.GrabarArchivo(nombreArchivo)
               ShowMessage(String.Format("Se exportaron {0} registros EXITOSAMENTE !!!", cant.ToString()))
         End Select
      Else
         ShowMessage("Ha cancelado la exportación.")
      End If

   End Sub

   Private Sub RefrescarDatosGrilla()
      Me.dtpDesde.Value = Me.dtpDesde.Value.AddMonths(-1)
      Me.dtpHasta.Value = DateTime.Today
      Me.chbMesCompleto.Checked = False
      Me.chbTodos.Checked = True

      Me.cmbGrabanLibro.SelectedIndex = 0
      cmbSucursal.Refrescar()

      Me.ugDetalle.ClearFilas()
   End Sub

   Private Sub MostrarNombreArchivo()
      Try
         Select Case Me.cmbTiposExportacion.SelectedValue.ToString()
            Case Reglas.Publicos.ExportacionComprasEnum.Holistor.ToString()
               Me.txtArchivoDestino.Text = My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & Publicos.CuitEmpresa & "_Compras_Holistor_" & Date.Today().ToString("yyyyMMdd") & ".csv"
         End Select

         Me.txtArchivoDestino.Text = Me.txtArchivoDestino.Text.Replace(" ", "_")
         Me.tssRegistros.Text = Me.ContarRegistros()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Function ContarRegistros() As String
      Return String.Format("{0} Registros", Me.ugDetalle.Rows.Count.ToString())
   End Function

   Private Sub CargarGrillaDetalle()

      Dim IdProveedor As Long
      Dim fechaDesde As Date = Me.dtpDesde.Value
      Dim fechaHasta As Date = Me.dtpHasta.Value
      Dim tiposDeComprobantes As Entidades.TipoComprobante() = Me.cmbTiposComprobantes.GetTiposComprobantes()
      Dim sucursales As Entidades.Sucursal() = Me.cmbSucursal.GetSucursales()

      Try

         '# Filtros
         If Me.chbProveedor.Checked AndAlso (Me.bscCodigoProveedor.Selecciono AndAlso Me.bscProveedor.Selecciono) Then
            IdProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
         End If

         '# Consulta
         Dim dtComprobantes As DataTable = New DataTable
         Dim rCompras As Reglas.Compras = New Reglas.Compras

         Select Case Me.cmbTiposExportacion.SelectedValue.ToString()

            Case Reglas.Publicos.ExportacionComprasEnum.Holistor.ToString()
               dtComprobantes = rCompras.GetComprasHolistorAExportar(fechaDesde,
                                                                     fechaHasta,
                                                                     IdProveedor,
                                                                     sucursales,
                                                                     tiposDeComprobantes)

         End Select

         '# Select Column
         If dtComprobantes.Rows.Count > 0 Then
            dtComprobantes.Columns.Add(_columnaSelec, GetType(Boolean))
            For Each dr As DataRow In dtComprobantes.Rows
               dr(_columnaSelec) = Me.chbTodos.Checked
            Next
         End If
         Me.ugDetalle.DataSource = dtComprobantes

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
         Me.tssRegistros.Text = ContarRegistros()
      End Try

   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()

      Me.bscCodigoProveedor.Selecciono = True
      Me.bscProveedor.Selecciono = True
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
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub CrearComprasHolistor(dt As DataTable)

      Dim linea As Reglas.ComprasCamposHolistor

      Me.tspBarra.Visible = True
      Me.tspBarra.Minimum = 0
      Me.tspBarra.Maximum = ugDetalle.Rows.Count
      Me.tspBarra.Value = 0

      For Each dr As DataRow In dt.Select(String.Format("{0} = True", _columnaSelec))
         Me.tspBarra.Value += 1
         linea = New Reglas.ComprasCamposHolistor()

         With linea

            .FechaEmision = dr.Field(Of Date)("Fecha")
            .Comprobante = dr.Field(Of String)("DescripcionAbrev")
            .Letra = dr.Field(Of String)("Letra")
            .CentroEmisor = dr.Field(Of Integer)("CentroEmisor")
            .NumeroComprobante = dr.Field(Of Long)("NumeroComprobante")

            If IsNumeric(dr(Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoComprobante.ToString())) Then
               .IdAFIPTipoComprobante = dr.Field(Of Integer)(Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoComprobante.ToString())
            End If

            .NombreProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.NombreProveedor.ToString())
            .CuitProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.CuitProveedor.ToString())
            .Direccion = dr.Field(Of String)(Entidades.Proveedor.Columnas.DireccionProveedor.ToString())
            .IdLocalidad = dr.Field(Of Integer)("IdLocalidadProveedor")

            .IdAFIPProvincia = dr.Field(Of Integer)(Entidades.Provincia.Columnas.IdAFIPProvincia.ToString())

            .IdCategoriaFiscal = Convert.ToInt32(dr.Field(Of Short)(Entidades.Venta.Columnas.IdCategoriaFiscal.ToString()))

            '# CodigoExportacion
            '.CodNetoGravado = dr.Field(Of String)(Entidades.SubRubro.Columnas.CodigoExportacion.ToString())

            .NetoGravado = dr.Field(Of Decimal)("BaseImponible")
            .Alicuota = dr.Field(Of Decimal)(Entidades.VentaImpuesto.Columnas.Alicuota.ToString())

            If Not String.IsNullOrEmpty(.CuitProveedor) Then
               .IdAFIPTipoDocumento = 80 'Cód. AFIP para Documento'
            Else
               If IsNumeric(dr(Entidades.AFIPTipoDocumento.Columnas.IdAFIPTipoDocumento.ToString())) Then
                  .IdAFIPTipoDocumento = dr.Field(Of Integer)(Entidades.AFIPTipoDocumento.Columnas.IdAFIPTipoDocumento.ToString())
               End If
            End If


            .IVADebito = dr.Field(Of Decimal)("Importe")

            '# Cuando se emite una FACTURA A el iva liquidado es igual al iva débito,
            '# pero cuando el cliente emite una factura B se completa únicamente el iva débito y el iva liquidado queda vació
            'If .IdAFIPTipoComprobante = _CodAFIPFacturaA Then
            '   .IVALiquidado = .IVADebito
            'End If

            '# Los campos si no tienen valores van vacios, no con 0.
            '.CodNgEx = 0
            '.ConceptosNgEx = 0

            .ProvinciaPercRet = .IdAFIPProvincia

            '.CodPerRet = dr.Field(Of String)(Entidades.VentaImpuesto.Columnas.IdTipoImpuesto.ToString())
            .PercRet = dr.Field(Of Decimal)("TotalPercepciones")
            .Total = dr.Field(Of Decimal)("Total") '# Este es el importe total x linea

         End With

         rComprasExportarDatos.Lineas.Add(linea)
      Next

   End Sub

#End Region

#Region "Eventos"
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try

         Me.Cursor = Cursors.WaitCursor

         Me.CargarGrillaDetalle()
         If Me.ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
            Me.tsbExportarCompras.Enabled = True
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
         Me.tssRegistros.Text = Me.ContarRegistros()
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.RefrescarDatosGrilla()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chbMesCompleto.CheckedChanged
      Dim FechaTemp As Date

      Try

         If chbMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chbMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chbMesCompleto.Checked

      Catch ex As Exception
         chbMesCompleto.Checked = False
         ShowError(ex)
      End Try

   End Sub

   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      Try
         Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
         Me.bscProveedor.Enabled = Me.chbProveedor.Checked

         If Not chbProveedor.Checked Then
            Me.bscCodigoProveedor.Text = String.Empty
            Me.bscProveedor.Text = String.Empty
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor
         If Me.ugDetalle.DataSource Is Nothing Then Exit Sub

         For Each dr As DataRow In DirectCast(Me.ugDetalle.DataSource, DataTable).Rows
            dr(_columnaSelec) = Me.chbTodos.Checked
         Next
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Try
         Me.Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbExportarCompras_Click(sender As Object, e As EventArgs) Handles tsbExportarCompras.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not Me.ugDetalle.Rows.Count > 0 Then Exit Sub

         '# Exportar
         Me.ExportarDatos(DirectCast(Me.ugDetalle.DataSource, DataTable))

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region
End Class