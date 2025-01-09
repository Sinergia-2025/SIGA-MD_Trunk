Public Class AsignacionMasivaCargos

#Region "Campos"
   Private _dtCargosClientes As DataTable

   Private _automat As Boolean = False
   Private _estaCargando As Boolean = True

   Private Const _precioListaColumn As String = "PrecioListaNuevo"
   Private Const _descuentoRecargoPorc1Column As String = "DescuentoRecargoPorc1Nuevo"
   Private Const _descuentoRecargoPorcGralColumn As String = "DescuentoRecargoPorcGral"

   Private Const _selecColumn As String = "Selec"
   Private Const _cantidadColumn As String = "cantidad"
   Private Const _montoColumn As String = "MontoNuevo"
   Private Const _importeColumn As String = "ImporteNuevo"

   Private _publicos As Publicos

   Private _cargosClientesObservaciones As List(Of Entidades.CargoClienteObservacion)
   Private _mostrarDescRec As Boolean = Reglas.Publicos.CargosUtilizaDescuentosRecargos
   Private _ColorColumnasEditables As Color = System.Drawing.Color.FromArgb(224, 224, 224)
   Private _DecimalesEnPrecio As Integer = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio

   'Private _listaSucursales As List(Of Entidades.Sucursal)
   Private _utilizaCentroCostos As Boolean = False
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         _publicos = New Publicos()
         '-- Carga tipo de Liquidacion.- ------------------------------------------------
         _publicos.CargaComboTiposLiquidacion(cmbTiposLiquidacion)
         cmbTiposLiquidacion.SelectedIndex = 0
         '-- Carga Categorias.- ---------------------------------------------------------
         _publicos.CargaComboCategorias(Me.cmbCategorias)
         '-- Carga Zonas Geograficas.- --------------------------------------------------
         _publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         cmbZonaGeografica.SelectedIndex = -1
         '-- REQ-34811.- ----------------------------------------------------------------
         _publicos.CargaComboDesdeEnum(cmbActivo, GetType(Entidades.Publicos.SiNoTodos))
         cmbActivo.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         '-- Proceso de Carga de Datos de Grillas.- -------------------------------------
         Refrescar()
         '-------------------------------------------------------------------------------
         _estaCargando = False
         _utilizaCentroCostos = Reglas.Publicos.TieneModuloContabilidad AndAlso Reglas.ContabilidadPublicos.UtilizaCentroCostos
         '-------------------------------------------------------------------------------
         ugCargos.AgregarFiltroEnLinea({"NombreCargo"})
         '-------------------------------------------------------------------------------
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 And tsbGrabar.Enabled Then
         tsbGrabar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Protected Overridable Function GetRegla() As Eniac.Reglas.VentasProductos
      Return New Reglas.VentasProductos()
   End Function
   Protected Overridable Sub LeerPreferencias()
      Try

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

#Region "Eventos"
   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      cmbCategorias.Enabled = chbCategoria.Checked

      If chbCategoria.Checked Then
         cmbCategorias.SelectedIndex = 0
         cmbCategorias.Focus()
      Else
         cmbCategorias.SelectedIndex = -1
      End If
   End Sub
   Private Sub chbSoloConImportes_CheckedChanged(sender As Object, e As EventArgs) Handles chbSoloConImportes.CheckedChanged
      Try
         Dim drCliente = DirectCast(ugClientes.ActiveRow.ListObject, DataRowView).Row
         CargarGrillaCargos(drCliente)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub chbCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbCobrador.CheckedChanged
      cmbCobrador.Enabled = chbCobrador.Checked
      If Not chbCobrador.Checked Then
         cmbCobrador.SelectedIndex = -1
      Else
         If cmbCobrador.Items.Count > 0 Then
            cmbCobrador.SelectedIndex = 0
         End If
         cmbCobrador.Focus()
      End If
   End Sub
   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      cmbZonaGeografica.Enabled = chbZonaGeografica.Checked
      If chbZonaGeografica.Checked = True Then
         If cmbZonaGeografica.Items.Count > 0 Then
            cmbZonaGeografica.SelectedIndex = 0
         End If
         cmbZonaGeografica.Focus()
      Else
         cmbZonaGeografica.SelectedIndex = -1
      End If
   End Sub
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         Refrescar()
         LeerPreferencias()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

#Region "Metodos privados"
   Private Sub Refrescar()
      If Me.chbCategoria.Checked And Me.cmbCategorias.SelectedIndex = -1 Then
         MessageBox.Show("ATENCION: NO seleccionó una Categoría aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbCategorias.Focus()
         Exit Sub
      End If
      If Me.chbZonaGeografica.Checked And Me.cmbZonaGeografica.SelectedIndex = -1 Then
         MessageBox.Show("ATENCION: NO seleccionó una Zona Geográfica aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbZonaGeografica.Focus()
         Exit Sub
      End If

      Dim idCategoria As Integer? = 0
      Dim idZonaGeografica As String = ""
      Dim idCobrador As Integer = 0

      '-- Carga Id de cobrador.- --
      If chbCategoria.Checked AndAlso cmbCategorias.SelectedValue IsNot Nothing Then
         idCategoria = CInt(cmbCategorias.SelectedValue)
      End If
      '-- Carga Id de Zona Geografica.- --
      If chbZonaGeografica.Checked AndAlso cmbZonaGeografica.SelectedValue IsNot Nothing Then
         idZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
      End If
      '-- Carga Id de Cobrador.- --
      If chbCobrador.Checked Then
         idCobrador = DirectCast(cmbCobrador.SelectedItem, Entidades.Empleado).IdEmpleado
      End If

      _dtCargosClientes = New Reglas.CargosClientes().GetCargosClientes(actual.Sucursal.IdSucursal,
                                                                        Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString()),
                                                                        idCategoria,
                                                                        idZonaGeografica,
                                                                        idCobrador,
                                                                        "<", 0, True, 0, 0)

      For Each dr As DataRow In _dtCargosClientes.Select("DescuentoRecargoPorcGral <> ClienteDescuentoRecargoPorc")
         Dim precioLista As Decimal = If(IsNumeric(dr(_precioListaColumn)), Decimal.Parse(dr(_precioListaColumn).ToString()), 0)
         dr(_descuentoRecargoPorcGralColumn) = dr("ClienteDescuentoRecargoPorc")
         Dim descuentoRecargoPorcGral As Decimal = If(IsNumeric(dr(_descuentoRecargoPorcGralColumn)), Decimal.Parse(dr(_descuentoRecargoPorcGralColumn).ToString()), 0)
         Dim descuentoRecargoPorc1 As Decimal = If(IsNumeric(dr(_descuentoRecargoPorc1Column)), Decimal.Parse(dr(_descuentoRecargoPorc1Column).ToString()), 0)
         Dim nuevoMonto As Decimal

         nuevoMonto = precioLista
         nuevoMonto = nuevoMonto * (1 + (descuentoRecargoPorcGral / 100))
         nuevoMonto = nuevoMonto * (1 + (descuentoRecargoPorc1 / 100))
         dr(Entidades.Cargo.Columnas.Monto.ToString()) = nuevoMonto
      Next

      Dim dtClientes As DataTable
      'Traigo todos los Clientes y las cargo en la grilla
      Dim oClientes As Reglas.Clientes = New Reglas.Clientes()
      dtClientes = oClientes.GetAsignacionCargos(idCategoria,
                                                 idZonaGeografica,
                                                 idCobrador,
                                                 "<", 0, 0, DirectCast(cmbActivo.SelectedValue, Entidades.Publicos.SiNoTodos), 0)
      ugClientes.DataSource = dtClientes
      FormatearGrillaClientes()

      ugCargos.DataSource = New DataView(_dtCargosClientes, String.Format("1 = 2"), "", DataViewRowState.CurrentRows)
      FormatearGrillaCargos()

   End Sub
   Private Sub FormatearGrillaCargos()
      With ugCargos.DisplayLayout.Bands(0)
         '-- Oculta todas las columnas.- --------------------
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
            column.CellActivation = Activation.NoEdit
         Next
         '-- Define que columnas se deberan ver.- -----------
         Dim col As Integer = 0

         .Columns(_selecColumn).FormatearColumna("Sel.", col, 60, HAlign.Center, False, , , Activation.AllowEdit).MaxWidth = 60
         .Columns(Entidades.Cargo.Columnas.NombreCargo.ToString()).FormatearColumna("Nombre cargo", col, 200, , False, , , Activation.NoEdit)
         .Columns(_cantidadColumn).FormatearColumna("Cant.", col, 80, HAlign.Right, False, "N2", , Activation.AllowEdit)

         .Columns(_precioListaColumn).FormatearColumna("Lista", col, 80, HAlign.Right, False, "N2", , Activation.AllowEdit)
         .Columns(_descuentoRecargoPorcGralColumn).FormatearColumna("% Gral", col, 80, HAlign.Right, Not _mostrarDescRec, "N2", , Activation.NoEdit)
         .Columns(_descuentoRecargoPorc1Column).FormatearColumna("%", col, 80, HAlign.Right, Not _mostrarDescRec, "N2", , Activation.AllowEdit)
         .Columns(_montoColumn).FormatearColumna("Precio", col, 80, HAlign.Right, Not _mostrarDescRec, "N2", , Activation.AllowEdit)

         .Columns("ImporteNuevo").FormatearColumna("Monto", col, 80, HAlign.Right, False, "N2", , Activation.AllowEdit)
         .Columns("Observacion").Hidden = False
      End With
      ugCargos.AgregarTotalesSuma({"Importe"})
   End Sub
   Private Sub FormatearGrillaClientes()

      With ugClientes.DisplayLayout.Bands(0)

         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
            column.CellActivation = Activation.NoEdit
         Next

         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Hidden = False
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Header.Caption = "Código"
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Width = 50
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Header.VisiblePosition = 1
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).Hidden = True
         .Columns(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).Header.Caption = "Tp.Doc"
         .Columns(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).Header.VisiblePosition = 2
         .Columns(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).Width = 60

         .Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).Hidden = True
         .Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).Header.Caption = "Nro.Doc"
         .Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).Header.VisiblePosition = 3
         .Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).Width = 100
         .Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Hidden = False
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Header.Caption = "Cliente"
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Width = 250
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Header.VisiblePosition = 4
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains

         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).Hidden = False
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).Header.Caption = "Nombre de Fantasia"
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).Width = 250
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).Header.VisiblePosition = 5
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains

         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).Hidden = False
         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).Header.Caption = "Categoría"
         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).Width = 150
         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).Header.VisiblePosition = 6

         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).Hidden = False
         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).Header.Caption = "Zona Geografica"
         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).Width = 150
         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).Header.VisiblePosition = 7

         .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).Hidden = True
      End With

      ugClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
      ugClientes.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
      ugClientes.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
      ugClientes.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.AboveOperand
      ugClientes.DisplayLayout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Equals
      ugClientes.DisplayLayout.Override.FilterRowAppearance.BackColor = Color.AntiqueWhite

   End Sub
   Private Sub CargarGrillaCargos(drCliente As DataRow)

      If chbSoloConImportes.Checked Then
         '# Cargo solo los cargos que tienen importes asignados
         Dim dt As DataTable = _dtCargosClientes.Clone()
         For Each row As DataRow In _dtCargosClientes.Select(String.Format("{0} = {1} AND Selec = True", Entidades.Cliente.Columnas.IdCliente.ToString(), drCliente(Entidades.Cliente.Columnas.IdCliente.ToString())))
            dt.ImportRow(row)
         Next

         '# Si el cliente tiene cargos con importes, muestro solo esos, caso contrario por más que tenga activado el check, lo desactivo y muestro la lista completa
         If dt.Rows.Count > 0 Then
            Me.ugCargos.DataSource = dt
            Exit Sub
         End If
      End If
      ugCargos.DataSource = New DataView(_dtCargosClientes,
                                               String.Format("{0} = {1}", Entidades.Cliente.Columnas.IdCliente.ToString(), drCliente(Entidades.Cliente.Columnas.IdCliente.ToString())),
                                                             "", DataViewRowState.CurrentRows)

   End Sub
#End Region

End Class