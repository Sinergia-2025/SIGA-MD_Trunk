Imports Eniac.Entidades
Imports Microsoft.Office.Interop.Word

Public Class MRPCentrosProductoresDetalle
#Region "Campos"
   Private _publicos As Publicos
   Private _estoyCargando As Boolean
#End Region
#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.MRPCentroProductor)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      _publicos = New Publicos()

      _estoyCargando = True
      _publicos.CargaComboDesdeEnum(cmbClaseCentroProd, GetType(Entidades.MRPCentroProductor.ClaseCentrosProd))

      _publicos.CargaComboSecciones(cmbSecciones)

      BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         InicializaCampos()
         CargarProximoNumero()
      Else
         '-- Activa o desactiva segun clase de Centro Productor.- ---
         InternoExterno()
         '-----------------------------------------------------------
         With DirectCast(_entidad, Entidades.MRPCentroProductor)
            tsbPAPTiempos.ValueDecimal = .TiempoPAP
            tsbProdTiempos.ValueDecimal = .TiempoProductivo
            tsbNoProdTiempos.ValueDecimal = .TiempoNoProductivo

            tsbPAPHorasHombre.ValueDecimal = .HorasHombrePAP
            tsbProdHorasHombre.ValueDecimal = .HorasHombreProductivo
            tsbNoProdHorasHombre.ValueDecimal = .HorasHombreNoProductivo
            txtDotacionCentroProd.Text = .Dotacion.ToString()
         End With

         If DirectCast(_entidad, Entidades.MRPCentroProductor).IdProveedor <> 0 Then
            chbProveedor.Checked = True
            bscCodigoProveedor.Text = New Reglas.Proveedores().GetUno(DirectCast(_entidad, Entidades.MRPCentroProductor).IdProveedor, False).CodigoProveedor.ToString()
            bscCodigoProveedor.PresionarBoton()
         End If
         If DirectCast(_entidad, Entidades.MRPCentroProductor).IdNormaFabricacion <> 0 Then
            chbNormasFabricacion.Checked = True
            Dim eNorma = New Reglas.MRPNormasFabricacion().GetUno(DirectCast(_entidad, Entidades.MRPCentroProductor).IdNormaFabricacion)
            bscNormasFabricacion.Text = eNorma.Descripcion.Trim()
            bscNormasFabricacion.Tag = eNorma.IdNormaFab
            bscNormasFabricacion.Selecciono = True
         End If

      End If
      bscCodigoProveedor.Enabled = (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())
      bscProveedor.Enabled = (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())
      chbProveedor.Enabled = (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())

      chbNormasFabricacion.Enabled = (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.INT.ToString())
      chkMantenimientoAutonomo.Enabled = (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.INT.ToString())

      utcGrillas.Tabs(1).Visible = (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.INT.ToString())

      '-- Carga las Grillas de Categorias Empleados.- ---------------------------------------------------------
      Dim operacionSeleccionada = GetOperacionActiva()
      ugCategoriasEmpleados.DataSource = operacionSeleccionada.CategoriasEmpleados
      FormateGrillaCategoriasEmpleados()
      '--------------------------------------------------------------------------------------------------------

      txtCodigoCentroProd.Focus()
      _estoyCargando = False
   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.MRPCentrosProductores
   End Function

   Private Function ValidaCamposHorarios(txtValor As TextBox) As Boolean
      If Decimal.Parse(txtValor.Text) > 24 Then
         Return False
      End If
      Return True
   End Function

   Protected Overrides Function ValidarDetalle() As String
      If chbProveedor.Checked AndAlso Not bscCodigoProveedor.Selecciono AndAlso Not bscProveedor.Selecciono Then
         bscCodigoProveedor.Focus()
         Return "Debe seleccionar un Proveedor por Defecto."
      End If

      If chbNormasFabricacion.Checked AndAlso Not bscNormasFabricacion.Selecciono Then
         bscNormasFabricacion.Focus()
         Return "Debe seleccionar una Norma de Fabricación por Defecto."
      End If
      '-- Valida Dotacion.- -------------------------------------------------------------
      If Integer.Parse(txtDotacionCentroProd.Text()) = 0 AndAlso cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.INT.ToString() Then
         txtDotacionCentroProd.Focus()
         Return "El valor de la Dotación asignado debe ser mayor a Cero(0)."
      End If
      '-- Valida Cantidad Controles.- ---------------------------------------------------
      If Integer.Parse(txtCantidadControles.Text()) = 0 AndAlso cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.INT.ToString() Then
         txtCantidadControles.Focus()
         Return "El valor de la Cantidad de Controles debe ser mayor a Cero(0)."
      End If

      '-- Control e Valores de las horas Diarias.- --------------------------------------
      If Not ValidaCamposHorarios(txtLunesCentroProd) Then
         txtLunesCentroProd.Focus()
         Return "Debe seleccionar un valor entre 0 y 24."
      End If
      If Not ValidaCamposHorarios(txtMartesCentroProd) Then
         txtMartesCentroProd.Focus()
         Return "Debe seleccionar un valor entre 0 y 24."
      End If
      If Not ValidaCamposHorarios(txtMiercolesCentroProd) Then
         txtMiercolesCentroProd.Focus()
         Return "Debe seleccionar un valor entre 0 y 24."
      End If
      If Not ValidaCamposHorarios(txtJuevesCentroProd) Then
         txtJuevesCentroProd.Focus()
         Return "Debe seleccionar un valor entre 0 y 24."
      End If
      If Not ValidaCamposHorarios(txtViernesCentroProd) Then
         txtViernesCentroProd.Focus()
         Return "Debe seleccionar un valor entre 0 y 24."
      End If
      If Not ValidaCamposHorarios(txtSabadoCentroProd) Then
         txtSabadoCentroProd.Focus()
         Return "Debe seleccionar un valor entre 0 y 24."
      End If
      If Not ValidaCamposHorarios(txtDomingoCentroProd) Then
         txtDomingoCentroProd.Focus()
         Return "Debe seleccionar un valor entre 0 y 24."
      End If

      '----------------------------------------------------------------------------------
      If cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.INT.ToString() And Integer.Parse(txtDotacionCentroProd.Text) = 0 Or String.IsNullOrEmpty(txtDotacionCentroProd.Text) Then
         Return "Debe ingresar una Dotacion mayor a Cero pra Centros Productores Internos"
      End If

      With DirectCast(_entidad, Entidades.MRPCentroProductor)
         .TiempoPAP = tsbPAPTiempos.ValueDecimal
         .TiempoProductivo = tsbProdTiempos.ValueDecimal
         .TiempoNoProductivo = tsbNoProdTiempos.ValueDecimal

         .HorasHombrePAP = tsbPAPHorasHombre.ValueDecimal
         .HorasHombreProductivo = tsbProdHorasHombre.ValueDecimal
         .HorasHombreNoProductivo = tsbNoProdHorasHombre.ValueDecimal

         If bscCodigoProveedor.Tag IsNot Nothing Then
            .IdProveedor = Integer.Parse(bscCodigoProveedor.Tag.ToString())
         End If
      End With
      Return MyBase.ValidarDetalle()
   End Function
#End Region

#Region "Eventos"
   Private Sub bscCategoriaEmpleados_BuscadorClick() Handles bscCategoriaEmpleados.BuscadorClick
      TryCatched(
   Sub()
      _publicos.PreparaGrillaCatgoriasEmpleados2(bscCategoriaEmpleados)
      bscCategoriaEmpleados.Datos = New Reglas.MRPCategoriasEmpleados().GetFiltradoPorNombre(bscCategoriaEmpleados.Text.Trim(), Entidades.Publicos.SiNoTodos.SI)
   End Sub)
   End Sub
   Private Sub bscCategoriaEmpleados_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCategoriaEmpleados.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosCategoriaEmpleados(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
   Private Sub btnInsertarCategoriaEmpleado_Click(sender As Object, e As EventArgs) Handles btnInsertarCategoriaEmpleado.Click
      TryCatched(
         Sub()
            If Not bscCategoriaEmpleados.Selecciono Or bscCategoriaEmpleados.FilaDevuelta Is Nothing Then
               ShowMessage("Debe seleccionar una Categoria de Empleado.")
               bscCategoriaEmpleados.Focus()
               Exit Sub
            End If
            If Integer.Parse(txtCantidaCategoriaEmpleado.Text) = 0 Then
               ShowMessage("La Cantidad ingresada no puede ser Cero.")
               txtCantidaCategoriaEmpleado.Focus()
               Exit Sub

            End If
            If String.IsNullOrEmpty(txtCantidaCategoriaEmpleado.Text) Then
               ShowMessage("Debe ingresar una Cantidad Valida.")
               txtCantidaCategoriaEmpleado.Focus()
               Exit Sub
            End If
            If Integer.Parse(txtCantidaCategoriaEmpleado.Text) > Integer.Parse(txtDotacionCentroProd.Text) Then
               ShowMessage("La cantidad debe ser menor o igual a la dotacion.")
               txtCantidaCategoriaEmpleado.Focus()
               Exit Sub
            End If
            Dim operacionSeleccionada = GetOperacionActiva()
            If operacionSeleccionada.CategoriasEmpleados IsNot Nothing Then
               If (operacionSeleccionada.CategoriasEmpleados.Sum(Function(x) x.CantidadCategoria) + Integer.Parse(txtCantidaCategoriaEmpleado.Text)) > Integer.Parse(txtDotacionCentroProd.Text) Then
                  ShowMessage("La cantidad total supera a la dotacion permitida.")
                  txtCantidaCategoriaEmpleado.Focus()
                  Exit Sub
               End If
            End If
            InsertarCategoriaEmpleados()
            '-- Habilito Borrar.- --
            btnEliminarCategoriaEmpleado.Enabled = True
            '------------------------------------------------------
            bscCategoriaEmpleados.Focus()
         End Sub)

   End Sub
   Private Function GetOperacionActiva() As MRPCentroProductor
      Return DirectCast(_entidad, MRPCentroProductor)
   End Function
   Private Sub InsertarCategoriaEmpleados()
      Dim operacionSeleccionada = GetOperacionActiva()
      If operacionSeleccionada IsNot Nothing Then
         Dim oLineaCE = New MRPCentroProductorCategoriaEmpleado
         With oLineaCE
            .IdCentroProductor = operacionSeleccionada.IdCentroProductor
            .IdCategoriaEmpleado = Integer.Parse(bscCategoriaEmpleados.Tag.ToString())
            .NombreCategoriaEmpleado = bscCategoriaEmpleados.Text
            .CantidadCategoria = Integer.Parse(txtCantidaCategoriaEmpleado.Text)
            .ValorHoraCategoria = Decimal.Parse(txtValorHoraCategoria.Text)
         End With
         operacionSeleccionada.CategoriasEmpleados.Add(oLineaCE)
         '-- Refresca los Datos de la Grilla.- ---------------------
         ugCategoriasEmpleados.Rows.Refresh(RefreshRow.FireInitializeRow)
         '-- Formate Grilla.- --------------------------------------
         FormateGrillaCategoriasEmpleados()
         LimpiaCategoriaEmpleados()
         '------------------------------------------------------------------------------------------------------------------------------------------------------------
      End If
   End Sub
   Private Sub LimpiaCategoriaEmpleados()
      bscCategoriaEmpleados.Text = String.Empty
      bscCategoriaEmpleados.Tag = String.Empty
      txtValorHoraCategoria.Text = "0.00"
      txtCantidaCategoriaEmpleado.Text = "0"
   End Sub
   Private Sub btnEliminarCategoriaEmpleado_Click(sender As Object, e As EventArgs) Handles btnEliminarCategoriaEmpleado.Click
      Try
         Dim operacionSeleccionada = GetOperacionActiva()

         Dim eRegCategoria = ugCategoriasEmpleados.FilaSeleccionada(Of MRPCentroProductorCategoriaEmpleado)()
         If eRegCategoria IsNot Nothing AndAlso operacionSeleccionada IsNot Nothing Then
            If ShowPregunta(String.Format("¿Desea eliminar la Categoría {0}?", eRegCategoria.NombreCategoriaEmpleado)) = DialogResult.Yes Then
               DirectCast(_entidad, MRPCentroProductor).CategoriasEmpleados.Remove(eRegCategoria)
               ugCategoriasEmpleados.Rows.Refresh(RefreshRow.FireInitializeRow)
               FormateGrillaCategoriasEmpleados()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region
#Region "Métodos"
   Private Sub FormateGrillaCategoriasEmpleados()
      ugCategoriasEmpleados.Rows.Refresh(RefreshRow.ReloadData)

      With ugCategoriasEmpleados.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         '-- Oculta las Columnas.- -------------------------
         .OcultaTodasLasColumnas()
         .Columns("NombreCategoriaEmpleado").FormatearColumna("Categoría", pos, 330, HAlign.Left)
         .Columns("ValorHoraCategoria").FormatearColumna("Valor Hora", pos, 120, HAlign.Right,, "N2")
         .Columns("CantidadCategoria").FormatearColumna("Cantidad", pos, 120, HAlign.Right,, "N2")
      End With
      ugCategoriasEmpleados.AgregarTotalesSuma({"CantidadCategoria"})
   End Sub
   Private Sub CargarDatosCategoriaEmpleados(dr As DataGridViewRow)
      bscCategoriaEmpleados.Text = dr.Cells("Descripcion").Value.ToString()
      bscCategoriaEmpleados.Tag = dr.Cells("IdCategoriaEmpleado").Value.ToString()
      txtValorHoraCategoria.Text = dr.Cells("ValorHoraProduccion").Value.ToString()
      '------------------------------------------------------------------------------------------------------------------------------------------------------------
      txtCantidaCategoriaEmpleado.Focus()
   End Sub

   Private Function FromHoraDecimal(hora As Decimal) As Date
      Return Date.Today.AddHours(Math.Truncate(hora)).AddMinutes(Math.Truncate((hora - Math.Truncate(hora)) * 60)).AddSeconds(Math.Truncate((hora - (hora - Math.Truncate(hora))) * 60))
   End Function
   Private Function ToHoraDecimal(dtp As DateTimePicker) As Decimal
      Return Convert.ToDecimal(dtp.Value.TimeOfDay.TotalHours)
   End Function

   Private Sub CargarProximoNumero()
      Dim oCentroProd = New Reglas.MRPCentrosProductores()
      DirectCast(_entidad, Entidades.MRPCentroProductor).IdCentroProductor = (oCentroProd.GetCodigoMaximo() + 1)
      txtCodigoCentroProd.Text = DirectCast(_entidad, Entidades.MRPCentroProductor).IdCentroProductor.ToString()
   End Sub
   Public Sub InicializaCampos()
      txtLunesCentroProd.Text = "0.00"
      txtMartesCentroProd.Text = "0.00"
      txtMiercolesCentroProd.Text = "0.00"
      txtJuevesCentroProd.Text = "0.00"
      txtViernesCentroProd.Text = "0.00"
      txtSabadoCentroProd.Text = "0.00"
      txtDomingoCentroProd.Text = "0.00"
      chkMantenimientoAutonomo.Checked = True
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores

         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores

         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      Try
         If e.FilaDevuelta IsNot Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString
   End Sub

   Private Sub bscNormasFabricacion_BuscadorClick() Handles bscNormasFabricacion.BuscadorClick
      Try
         Dim oNormas = New Eniac.Reglas.MRPNormasFabricacion()
         _publicos.PreparaGrillaMRPNormas(bscNormasFabricacion)
         bscNormasFabricacion.Datos = oNormas.GetFiltradoPorNombre(bscNormasFabricacion.Text)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscNormasFabricacion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNormasFabricacion.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargarNormasFabricacion(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub CargarNormasFabricacion(dr As DataGridViewRow)
      '-- Carga datos de Buscador.-
      bscNormasFabricacion.Text = dr.Cells("Descripcion").Value.ToString.Trim()
      bscNormasFabricacion.Tag = dr.Cells("IdNormaFab").Value.ToString.Trim()
   End Sub

   Private Sub cmbClaseCentroProd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClaseCentroProd.SelectedIndexChanged
      If Not _estoyCargando Then
         bscCodigoProveedor.Text = String.Empty
         bscCodigoProveedor.Tag = Nothing
         bscProveedor.Text = String.Empty
         '-- Setea Proveedor.- --------------------------------------------------------------------------------------------------------------------
         bscCodigoProveedor.Enabled = (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())
         bscProveedor.Enabled = (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())
         chbProveedor.Enabled = (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())
         chbProveedor.Checked = False
         '-- Setea Normas de Fabricacion.- ---------------------------------------------------------------------------------------------------------
         chbNormasFabricacion.Enabled = (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.INT.ToString())
         chbNormasFabricacion.Checked = False
         '------------------------------------------------------------------------------------------------------------------------------------------
         chkMantenimientoAutonomo.Enabled = (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.INT.ToString())
         chkMantenimientoAutonomo.Checked = (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.INT.ToString())
         '------------------------------------------------------------------------------------------------------------------------------------------
         utcGrillas.Tabs(1).Visible = (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.INT.ToString())
         '-- Activa o desactiva segun clase de Centro Productor.- ----------------------------------------------------------------------------------
         InternoExterno()
         '------------------------------------------------------------------------------------------------------------------------------------------
         If Not bscCodigoProveedor.Enabled Then
            With DirectCast(_entidad, MRPCentroProductor)
               .IdProveedor = 0
            End With
         End If
         '------------------------------------------------------------------------------------------------------------------------------------------
         If Not bscNormasFabricacion.Enabled Then
            With DirectCast(_entidad, MRPCentroProductor)
               .IdNormaFabricacion = 0
            End With
         End If
         '------------------------------------------------------------------------------------------------------------------------------------------
         txtDotacionCentroProd.Focus()
      End If
   End Sub
   Private Sub InternoExterno()
      '-- Activa o desactiva segun clase de Centro Productor.- --------------------------------------------------------------------------------------
      gpbHorasDiarias.Enabled = Not (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())
      gpbPAPCentroProd.Enabled = Not (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())
      gpbProdCentroProd.Enabled = Not (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())
      gpbNoProdCentroProd.Enabled = Not (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())
      txtDotacionCentroProd.Enabled = Not (cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())
      '----------------------------------------------------------------------------------------------------------------------------------------------
      If Not _estoyCargando Then
         txtDotacionCentroProd.Text = If(Not cmbClaseCentroProd.SelectedValue.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString(), "1", "0")
      End If
   End Sub
   Protected Overrides Sub Aceptar()
      Dim mensaje = ValidarDetalle()
      If String.IsNullOrEmpty(mensaje) Then
         '----------------------------------------------------------------------------------------------------------------------------------------------
         If chbNormasFabricacion.Checked Then
            DirectCast(_entidad, MRPCentroProductor).IdNormaFabricacion = Integer.Parse(bscNormasFabricacion.Tag.ToString())
         Else
            DirectCast(_entidad, MRPCentroProductor).IdNormaFabricacion = 0
         End If
         '----------------------------------------------------------------------------------------------------------------------------------------------
         If chbProveedor.Checked Then
            DirectCast(_entidad, MRPCentroProductor).IdProveedor = Integer.Parse(bscCodigoProveedor.Tag.ToString())
         Else
            DirectCast(_entidad, MRPCentroProductor).IdProveedor = 0
         End If
         '----------------------------------------------------------------------------------------------------------------------------------------------
         _estoyCargando = True
         MyBase.Aceptar()
         _estoyCargando = False
      Else
         MessageBox.Show(mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
   End Sub

   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      bscCodigoProveedor.Enabled = chbProveedor.Checked
      bscCodigoProveedor.Text = String.Empty
      bscProveedor.Enabled = chbProveedor.Checked
      bscProveedor.Text = String.Empty
      bscCodigoProveedor.Focus()
      If Not chbProveedor.Checked Then
         bscCodigoProveedor.Tag = Nothing
      End If
   End Sub

   Private Sub chbNormasFabricacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbNormasFabricacion.CheckedChanged
      bscNormasFabricacion.Enabled = chbNormasFabricacion.Checked
      bscNormasFabricacion.Text = String.Empty
      bscNormasFabricacion.Focus()
   End Sub

   Private Sub txtLunesCentroProd_TextChanged(sender As Object, e As EventArgs) Handles txtLunesCentroProd.TextChanged
      If Not IsNumeric(txtLunesCentroProd.Text) Then
         txtLunesCentroProd.Text = " "
      End If
   End Sub

   Private Sub txtMiercolesCentroProd_TextChanged(sender As Object, e As EventArgs) Handles txtMiercolesCentroProd.TextChanged
      If Not IsNumeric(txtMiercolesCentroProd.Text) Then
         txtMiercolesCentroProd.Text = " "
      End If
   End Sub

   Private Sub txtViernesCentroProd_TextChanged(sender As Object, e As EventArgs) Handles txtViernesCentroProd.TextChanged
      If Not IsNumeric(txtViernesCentroProd.Text) Then
         txtViernesCentroProd.Text = " "
      End If
   End Sub

   Private Sub txtMartesCentroProd_TextChanged(sender As Object, e As EventArgs) Handles txtMartesCentroProd.TextChanged
      If Not IsNumeric(txtMartesCentroProd.Text) Then
         txtMartesCentroProd.Text = " "
      End If
   End Sub

   Private Sub txtJuevesCentroProd_TextChanged(sender As Object, e As EventArgs) Handles txtJuevesCentroProd.TextChanged
      If Not IsNumeric(txtJuevesCentroProd.Text) Then
         txtJuevesCentroProd.Text = " "
      End If
   End Sub

   Private Sub txtSabadoCentroProd_TextChanged(sender As Object, e As EventArgs) Handles txtSabadoCentroProd.TextChanged
      If Not IsNumeric(txtSabadoCentroProd.Text) Then
         txtSabadoCentroProd.Text = " "
      End If
   End Sub

   Private Sub txtDomingoCentroProd_TextChanged(sender As Object, e As EventArgs) Handles txtDomingoCentroProd.TextChanged
      If Not IsNumeric(txtDomingoCentroProd.Text) Then
         txtDomingoCentroProd.Text = " "
      End If
   End Sub

#End Region
End Class