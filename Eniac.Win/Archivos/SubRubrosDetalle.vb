Option Strict On
Option Explicit On
#Region "Option"
Imports Eniac.Controles
#End Region
Public Class SubRubrosDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(idRubro As Integer, subRubro As Entidades.SubRubro)
      Me.InitializeComponent()
      Me._entidad = subRubro
      _idRubro = idRubro
   End Sub

#End Region

#Region "Campos"
   Private _onLoad As Boolean = False
   Private _publicos As Publicos
   Private _idRubro As Integer
   Private _titSubRubroComisDesRec As Dictionary(Of String, String)
   Private _EntSubRubroComisDesRec As List(Of Entidades.SubRubroComisionPorDescuento)
   '-- REQ-34666.- --------------------------------------------------------------------------------------------------
   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
   '-----------------------------------------------------------------------------------------------------------------
#End Region

#Region "Propiedades"
   Protected ReadOnly Property pSubRubros() As Entidades.SubRubro
      Get
         Return DirectCast(_entidad, Entidades.SubRubro)
      End Get
   End Property
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      Try
         MyBase.OnLoad(e)

         Me._publicos = New Publicos()

         _onLoad = True

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
            Me.bscCodigoRubro.PresionarBoton()
         Else
            If _idRubro > 0 Then
               bscCodigoRubro.Text = _idRubro.ToString()
               bscCodigoRubro.PresionarBoton()
            End If
         End If
         '-- REQ-34666.- --------------------------------------------------------------------------------------
         VerificaValorAtributos()
         '-----------------------------------------------------------------------------------------------------
         tbcDetalle.SelectedTab = tbpComisionPorDesCuento
         _titSubRubroComisDesRec = GetColumnasVisiblesGrilla(ugDetalle)
         Me._EntSubRubroComisDesRec = DirectCast(Me._entidad, Entidades.SubRubro).SubRubroComisionPorDescuento
         Me.ugDetalle.DataSource = Me._EntSubRubroComisDesRec

         FormateaGrilla()

         tbcDetalle.SelectedTab = tbpDescuentos

         '-- REQ-35485.- ------------------------------------------------------------------
         Dim TieneProducto = New Reglas.SubRubros().AtributoSubRubroProducto(Integer.Parse(txtIdSubRubro.Text)) > 0

         If Me.StateForm = Eniac.Win.StateForm.Actualizar And TieneProducto Then
            '-- Atributo 01.- --
            chbAtributo01.Enabled = False
            bscCodigoGrupoAtributo01.Permitido = False
            bscDescripcionGrupoAtributo01.Permitido = False
            '-- Atributo 02.- --
            chbAtributo02.Enabled = False
            bscCodigoGrupoAtributo02.Permitido = False
            bscDescripcionGrupoAtributo02.Permitido = False
            '-- Atributo 03.- --
            chbAtributo03.Enabled = False
            bscCodigoGrupoAtributo03.Permitido = False
            bscDescripcionGrupoAtributo03.Permitido = False
            '-- Atributo 04.- --
            chbAtributo04.Enabled = False
            bscCodigoGrupoAtributo04.Permitido = False
            bscDescripcionGrupoAtributo04.Permitido = False
            '-- Etiqueta de Mensaje.- --------------------------------------------------------
            lblMensajeSubRubroAtributo.Visible = True
            '---------------------------------------------------------------------------------
         End If
         txtNombreSubRubro.Focus()
      Finally
         _onLoad = False
      End Try
   End Sub
   Private Sub FormateaGrilla()
      AjustarColumnasGrilla(ugDetalle, _titSubRubroComisDesRec)
   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SubRubros()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If Decimal.Parse(Me.txtDescuentoRecargoPorc1.Text) <= -100 Or Decimal.Parse(Me.txtDescuentoRecargoPorc1.Text) >= 100 Then
         txtDescuentoRecargoPorc1.Focus()
         Return "El Descuento/Recargo 1 NO es Válido."
      End If
      If Decimal.Parse(Me.txtDescuentoRecargoPorc2.Text) <= -100 Or Decimal.Parse(Me.txtDescuentoRecargoPorc2.Text) >= 100 Then
         txtDescuentoRecargoPorc2.Focus()
         Return "El Descuento/Recargo 2 NO es Válido."
      End If

      If Not Me.bscCodigoRubro.Selecciono And Not Me.bscRubro.Selecciono Then
         Me.bscRubro.Focus()
         Return "No selecciono el Rubro."
      End If

      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Eventos"
   '-- REQ-34666.- ---------------------------------------------------------------------------------------------------------------------------------------
   Private Sub bscCodigoAtributo01_BuscadorClick() Handles bscCodigoGrupoAtributo01.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaGrupoTipoAtributoProducto2(bscCodigoGrupoAtributo01)
            bscCodigoGrupoAtributo01.Datos = New Reglas.GruposTiposAtributosProductos().GetFiltradoPorCodigo(bscCodigoGrupoAtributo01.Text.ValorNumericoPorDefecto(0S), TipoAtributo01)
         End Sub)
   End Sub
   Private Sub bscCodigoGrupoAtributo01_BuscadorSeleccion(sender As Object, e As BuscadorEventArgs) Handles bscCodigoGrupoAtributo01.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosGrupoAtributo(e.FilaDevuelta, 1)
            End If
         End Sub)
   End Sub
   Private Sub bscDescripcionGrupoAtributo01_BuscadorClick() Handles bscDescripcionGrupoAtributo01.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaTipoAtributoProducto2(bscDescripcionGrupoAtributo01)
            bscDescripcionGrupoAtributo01.Datos = New Reglas.GruposTiposAtributosProductos().GetFiltradoPorDescripcion(bscDescripcionGrupoAtributo01.Text, TipoAtributo01)
         End Sub)
   End Sub
   Private Sub bscDescripcionGrupoAtributo01_BuscadorSeleccion(sender As Object, e As BuscadorEventArgs) Handles bscDescripcionGrupoAtributo01.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosGrupoAtributo(e.FilaDevuelta, 1)
            End If
         End Sub)
   End Sub

   Private Sub bscCodigoAtributo02_BuscadorClick() Handles bscCodigoGrupoAtributo02.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaGrupoTipoAtributoProducto2(bscCodigoGrupoAtributo02)
            bscCodigoGrupoAtributo02.Datos = New Reglas.GruposTiposAtributosProductos().GetFiltradoPorCodigo(bscCodigoGrupoAtributo02.Text.ValorNumericoPorDefecto(0S), TipoAtributo02)
         End Sub)
   End Sub
   Private Sub bscCodigoGrupoAtributo02_BuscadorSeleccion(sender As Object, e As BuscadorEventArgs) Handles bscCodigoGrupoAtributo02.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosGrupoAtributo(e.FilaDevuelta, 2)
            End If
         End Sub)
   End Sub
   Private Sub bscDescripcionGrupoAtributo02_BuscadorClick() Handles bscDescripcionGrupoAtributo02.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaTipoAtributoProducto2(bscDescripcionGrupoAtributo02)
            bscDescripcionGrupoAtributo02.Datos = New Reglas.GruposTiposAtributosProductos().GetFiltradoPorDescripcion(bscDescripcionGrupoAtributo02.Text, TipoAtributo02)
         End Sub)
   End Sub
   Private Sub bscDescripcionGrupoAtributo02_BuscadorSeleccion(sender As Object, e As BuscadorEventArgs) Handles bscDescripcionGrupoAtributo02.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosGrupoAtributo(e.FilaDevuelta, 2)
            End If
         End Sub)
   End Sub

   Private Sub bscCodigoAtributo03_BuscadorClick() Handles bscCodigoGrupoAtributo03.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaGrupoTipoAtributoProducto2(bscCodigoGrupoAtributo03)
            bscCodigoGrupoAtributo03.Datos = New Reglas.GruposTiposAtributosProductos().GetFiltradoPorCodigo(bscCodigoGrupoAtributo03.Text.ValorNumericoPorDefecto(0S), TipoAtributo03)
         End Sub)
   End Sub
   Private Sub bscCodigoGrupoAtributo03_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoGrupoAtributo03.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosGrupoAtributo(e.FilaDevuelta, 3)
            End If
         End Sub)
   End Sub
   Private Sub bscDescripcionGrupoAtributo03_BuscadorClick() Handles bscDescripcionGrupoAtributo03.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaTipoAtributoProducto2(bscDescripcionGrupoAtributo03)
            bscDescripcionGrupoAtributo03.Datos = New Reglas.GruposTiposAtributosProductos().GetFiltradoPorDescripcion(bscDescripcionGrupoAtributo03.Text, TipoAtributo03)
         End Sub)
   End Sub
   Private Sub bscDescripcionGrupoAtributo03_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscDescripcionGrupoAtributo03.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosGrupoAtributo(e.FilaDevuelta, 3)
            End If
         End Sub)
   End Sub

   Private Sub bscCodigoAtributo04_BuscadorClick() Handles bscCodigoGrupoAtributo04.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaGrupoTipoAtributoProducto2(bscCodigoGrupoAtributo04)
            bscCodigoGrupoAtributo04.Datos = New Reglas.GruposTiposAtributosProductos().GetFiltradoPorCodigo(bscCodigoGrupoAtributo04.Text.ValorNumericoPorDefecto(0S), TipoAtributo04)
         End Sub)
   End Sub
   Private Sub bscCodigoGrupoAtributo04_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoGrupoAtributo04.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosGrupoAtributo(e.FilaDevuelta, 4)
            End If
         End Sub)
   End Sub
   Private Sub bscDescripcionGrupoAtributo04_BuscadorClick() Handles bscDescripcionGrupoAtributo04.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaTipoAtributoProducto2(bscDescripcionGrupoAtributo04)
            bscDescripcionGrupoAtributo04.Datos = New Reglas.GruposTiposAtributosProductos().GetFiltradoPorDescripcion(bscDescripcionGrupoAtributo04.Text, TipoAtributo04)
         End Sub)
   End Sub
   Private Sub bscDescripcionGrupoAtributo04_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscDescripcionGrupoAtributo04.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosGrupoAtributo(e.FilaDevuelta, 4)
            End If
         End Sub)
   End Sub

   Private Sub CargarDatosGrupoAtributo(dr As DataGridViewRow, buscador As Integer)
      Select Case buscador
         Case 1
            bscCodigoGrupoAtributo01.Text = dr.Cells("IdGrupoTipoAtributoProducto").Value.ToString()
            bscDescripcionGrupoAtributo01.Text = dr.Cells("Descripcion").Value.ToString()
         Case 2
            bscCodigoGrupoAtributo02.Text = dr.Cells("IdGrupoTipoAtributoProducto").Value.ToString()
            bscDescripcionGrupoAtributo02.Text = dr.Cells("Descripcion").Value.ToString()
         Case 3
            bscCodigoGrupoAtributo03.Text = dr.Cells("IdGrupoTipoAtributoProducto").Value.ToString()
            bscDescripcionGrupoAtributo03.Text = dr.Cells("Descripcion").Value.ToString()
         Case 4
            bscCodigoGrupoAtributo04.Text = dr.Cells("IdGrupoTipoAtributoProducto").Value.ToString()
            bscDescripcionGrupoAtributo04.Text = dr.Cells("Descripcion").Value.ToString()
      End Select
   End Sub
   '------------------------------------------------------------------------------------------------------------------------------------------------------
   Private Sub bscCodigoRubro_BuscadorClick() Handles bscCodigoRubro.BuscadorClick
      Try
         Dim oRubros As Reglas.Rubros = New Reglas.Rubros
         Me._publicos.PreparaGrillaRubros(Me.bscCodigoRubro)
         Me.bscCodigoRubro.Datos = oRubros.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoRubro.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoRubro_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoRubro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarRubro(e.FilaDevuelta)
            Me.txtIdSubRubro.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscRubro_BuscadorClick() Handles bscRubro.BuscadorClick
      Try
         Dim oRubros As Reglas.Rubros = New Reglas.Rubros
         Me._publicos.PreparaGrillaRubros(Me.bscRubro)
         Me.bscRubro.Datos = oRubros.GetPorNombre(Me.bscRubro.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscRubro_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscRubro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarRubro(e.FilaDevuelta)
            Me.txtIdSubRubro.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdSubRubro.Focus()
   End Sub
   Private Sub txtDesRecHasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDesRecHasta.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub txtComisonDescRec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComisionDescRec.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub btnInsertarRubroComsion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnInsertarSubRubroComsion.KeyPress
      PresionarTab(e)
   End Sub
   Private Sub btnInsertarSubRubroComsion_Click(sender As Object, e As EventArgs) Handles btnInsertarSubRubroComsion.Click
      Try
         If Me.ValidarDescRec() Then
            Me.InsertarDescRec()
            RefrescaDescRec()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub btnEliminarSubRubroComsion_Click(sender As Object, e As EventArgs) Handles btnEliminarSubRubroComsion.Click
      Try
         Dim entSubRubroComisDesRec As Entidades.SubRubroComisionPorDescuento = GetSubRubroComicDescRec()
         If entSubRubroComisDesRec IsNot Nothing Then
            _EntSubRubroComisDesRec.Remove(entSubRubroComisDesRec)
            Me.ugDetalle.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub ugDetalle_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugDetalle.DoubleClickRow
      Try
         Dim row As Entidades.SubRubroComisionPorDescuento = GetSubRubroComicDescRec()
         If row IsNot Nothing Then
            If Not String.IsNullOrWhiteSpace(row.IdSubRubro.ToString()) Then
               Me.txtDesRecHasta.Text = row.DescuentoRecargoHasta.ToString()
               Me.txtComisionDescRec.Text = row.Comision.ToString()
               _EntSubRubroComisDesRec.Remove(row)
               Me.ugDetalle.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
               txtDesRecHasta.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub btnRefrescarDescRec_Click(sender As Object, e As EventArgs) Handles btnRefrescarDescRec.Click
      Try
         RefrescaDescRec()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Metodos"
   Private Sub VerificaValorAtributos()
      Dim eAtributo As Entidades.TipoAtributoProducto
      tbcDetalle.SelectedTab = Me.tpAtributos
      If TipoAtributo01 > 0 Then
         '-- Carga ValoresBsc.- --------------------------------------------------------------------------------
         If DirectCast(_entidad, Entidades.SubRubro).GrupoAtributo01 IsNot Nothing Then
            bscCodigoGrupoAtributo01.Text = DirectCast(_entidad, Entidades.SubRubro).GrupoAtributo01.ToString()
            bscCodigoGrupoAtributo01.PresionarBoton()
         End If
         '-- Carga Valores Check.- -----------------------------------------------------------------------------
         eAtributo = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01)
         chbAtributo01.Text = eAtributo.Descripcion
         chbAtributo01.Checked = StateForm = Eniac.Win.StateForm.Actualizar And DirectCast(_entidad, Entidades.SubRubro).GrupoAtributo01.IfNull > 0
      Else
         chbAtributo01.Visible = False
         bscCodigoGrupoAtributo01.Visible = False
         bscDescripcionGrupoAtributo01.Visible = False
      End If
      If TipoAtributo02 > 0 Then
         If DirectCast(_entidad, Entidades.SubRubro).GrupoAtributo02 IsNot Nothing Then
            '-- Carga ValoresBsc.- --------------------------------------------------------------------------------
            bscCodigoGrupoAtributo02.Text = DirectCast(_entidad, Entidades.SubRubro).GrupoAtributo02.ToString()
            bscCodigoGrupoAtributo02.PresionarBoton()
         End If
         '-- Carga Valores Check.- -----------------------------------------------------------------------------
         eAtributo = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02)
         chbAtributo02.Text = eAtributo.Descripcion
         chbAtributo02.Checked = StateForm = Eniac.Win.StateForm.Actualizar And DirectCast(_entidad, Entidades.SubRubro).GrupoAtributo02.IfNull > 0
      Else
         chbAtributo02.Visible = False
         bscCodigoGrupoAtributo02.Visible = False
         bscDescripcionGrupoAtributo02.Visible = False
      End If
      If TipoAtributo03 > 0 Then
         '-- Carga ValoresBsc.- --------------------------------------------------------------------------------
         If DirectCast(_entidad, Entidades.SubRubro).GrupoAtributo03 IsNot Nothing Then
            bscCodigoGrupoAtributo03.Text = DirectCast(_entidad, Entidades.SubRubro).GrupoAtributo03.ToString()
            bscCodigoGrupoAtributo03.PresionarBoton()
         End If
         '-- Carga Valores Check.- -----------------------------------------------------------------------------
         eAtributo = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo03)
         chbAtributo03.Text = eAtributo.Descripcion
         chbAtributo03.Checked = StateForm = Eniac.Win.StateForm.Actualizar And DirectCast(_entidad, Entidades.SubRubro).GrupoAtributo03.IfNull > 0
      Else
         chbAtributo03.Visible = False
         bscCodigoGrupoAtributo03.Visible = False
         bscDescripcionGrupoAtributo03.Visible = False
      End If
      If TipoAtributo04 > 0 Then
         '-- Carga ValoresBsc.- --------------------------------------------------------------------------------
         If DirectCast(_entidad, Entidades.SubRubro).GrupoAtributo04 IsNot Nothing Then
            bscCodigoGrupoAtributo04.Text = DirectCast(_entidad, Entidades.SubRubro).GrupoAtributo04.ToString()
            bscCodigoGrupoAtributo04.PresionarBoton()
         End If
         '-- Carga Valores Check.- -----------------------------------------------------------------------------
         eAtributo = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01)
         chbAtributo04.Text = eAtributo.Descripcion
         chbAtributo04.Checked = StateForm = Eniac.Win.StateForm.Actualizar And DirectCast(_entidad, Entidades.SubRubro).GrupoAtributo04.IfNull > 0
      Else
         chbAtributo04.Visible = False
         bscCodigoGrupoAtributo04.Visible = False
         bscDescripcionGrupoAtributo04.Visible = False
      End If

      If Not chbAtributo01.Visible And Not chbAtributo02.Visible And Not chbAtributo03.Visible And Not chbAtributo04.Visible Then
         tbcDetalle.TabPages.Remove(tpAtributos)
      End If

   End Sub

   Private Sub CargarRubro(ByVal dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.SubRubro).IdRubro = Integer.Parse(dr.Cells("IdRubro").Value.ToString())
      Me.bscCodigoRubro.Text = dr.Cells("IdRubro").Value.ToString()
      Me.bscRubro.Text = dr.Cells("NombreRubro").Value.ToString()


      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
      End If
   End Sub
   Private Sub CargarProximoNumero()
      Dim oRubro As Reglas.SubRubros = New Reglas.SubRubros()
      Me.txtIdSubRubro.Text = (oRubro.GetCodigoMaximo(Integer.Parse(Me.bscCodigoRubro.Text)) + 1).ToString()
   End Sub
   Private Sub RefrescaDescRec()
      Me.txtComisionDescRec.Text = "0.00"
      Me.txtDesRecHasta.Text = "0.00"
      Me.txtDesRecHasta.Focus()
   End Sub
   Private Function ValidarDescRec() As Boolean

      If Decimal.Parse(Me.txtDesRecHasta.Text) >= 0 Then
         MessageBox.Show("Debe ingresar un valor Negativo para el porcentaje de Descuento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         txtDesRecHasta.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtDesRecHasta.Text) <= -100 Then
         MessageBox.Show("El valor del  Descuento no puede superar a -100", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtDesRecHasta.Focus()
         Return False
      End If
      If Decimal.Parse(Me.txtComisionDescRec.Text) <= 0 Then
         MessageBox.Show("La Comisión debe ser mayor a 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtComisionDescRec.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtComisionDescRec.Text) >= 100 Then
         MessageBox.Show("El valor de la Comisión no debe ser mayor a 100", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtComisionDescRec.Focus()
         Return False
      End If
      For Each ent As Entidades.SubRubroComisionPorDescuento In _EntSubRubroComisDesRec
         If (ent.DescuentoRecargoHasta = Decimal.Parse(Me.txtDesRecHasta.Text)) Then
            MessageBox.Show("Existe un Descuento Hasta  con el mismo valor a ingresar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
         End If
      Next
      Return True
   End Function
   Private Sub InsertarDescRec()

      Dim entSubRubroComisDesRec As Entidades.SubRubroComisionPorDescuento = New Entidades.SubRubroComisionPorDescuento()
      With entSubRubroComisDesRec
         .IdSubRubro = Integer.Parse(Me.txtIdSubRubro.Text)
         .DescuentoRecargoHasta = Decimal.Parse(Me.txtDesRecHasta.Text)
         .Comision = Decimal.Parse(Me.txtComisionDescRec.Text)
      End With
      Me._EntSubRubroComisDesRec.Add(entSubRubroComisDesRec)
      Me.ugDetalle.Rows.Refresh(RefreshRow.ReloadData)
   End Sub

   Private Function GetSubRubroComicDescRec() As Entidades.SubRubroComisionPorDescuento
      Return ugDetalle.FilaSeleccionada(Of Entidades.SubRubroComisionPorDescuento)()
   End Function

   Protected Overrides Sub Aceptar()
      If ValidaAtributoProductos() Then
         With pSubRubros
            .GrupoAtributo01 = If(chbAtributo01.Checked, Integer.Parse(bscCodigoGrupoAtributo01.Text), Nothing)
            .TipoAtributo01 = If(chbAtributo01.Checked, TipoAtributo01, Nothing)
            .GrupoAtributo02 = If(chbAtributo02.Checked, Integer.Parse(bscCodigoGrupoAtributo02.Text), Nothing)
            .TipoAtributo02 = If(chbAtributo02.Checked, TipoAtributo02, Nothing)
            .GrupoAtributo03 = If(chbAtributo03.Checked, Integer.Parse(bscCodigoGrupoAtributo03.Text), Nothing)
            .TipoAtributo03 = If(chbAtributo03.Checked, TipoAtributo03, Nothing)
            .GrupoAtributo04 = If(chbAtributo04.Checked, Integer.Parse(bscCodigoGrupoAtributo04.Text), Nothing)
            .TipoAtributo04 = If(chbAtributo04.Checked, TipoAtributo04, Nothing)
         End With
         MyBase.Aceptar()
      Else
         HayError = True
      End If
   End Sub
   Private Function ValidaAtributoProductos() As Boolean
      If tbcDetalle.TabPages.Contains(tpAtributos) Then
         'If New Reglas.SubRubros().AtributoSubRubroProducto(Integer.Parse(txtIdSubRubro.Text)) > 0 Then
         '   ShowMessage("ATENCIÓN: ¡No es posible modificar los atributos! El SubRubro contiene productos asociados")
         '   Return False
         'End If

         If chbAtributo01.Checked And Not bscCodigoGrupoAtributo01.Selecciono And Not bscDescripcionGrupoAtributo01.Selecciono Then
            ShowMessage("ATENCIÓN: Debe seleccionar un Tipo de Atributo de Producto.")
            bscCodigoGrupoAtributo01.Focus()
            Return False
         End If
         If chbAtributo02.Checked And Not bscCodigoGrupoAtributo02.Selecciono And Not bscDescripcionGrupoAtributo02.Selecciono Then
            ShowMessage("ATENCIÓN: Debe seleccionar un Tipo de Atributo de Producto.")
            bscCodigoGrupoAtributo02.Focus()
            Return False
         End If
         If chbAtributo03.Checked And Not bscCodigoGrupoAtributo03.Selecciono And Not bscDescripcionGrupoAtributo03.Selecciono Then
            ShowMessage("ATENCIÓN: Debe seleccionar un Tipo de Atributo de Producto.")
            bscCodigoGrupoAtributo03.Focus()
            Return False
         End If
         If chbAtributo04.Checked And Not bscCodigoGrupoAtributo04.Selecciono And Not bscDescripcionGrupoAtributo04.Selecciono Then
            ShowMessage("ATENCIÓN: Debe seleccionar un Tipo de Atributo de Producto.")
            bscCodigoGrupoAtributo04.Focus()
            Return False
         End If
      End If

      Return True
   End Function

   Private Sub chbAtributo01_CheckedChanged(sender As Object, e As EventArgs) Handles chbAtributo01.CheckedChanged
      If Not _onLoad Then
         bscCodigoGrupoAtributo01.Text = ""
         bscDescripcionGrupoAtributo01.Text = ""
      End If
      bscCodigoGrupoAtributo01.Enabled = chbAtributo01.Checked
      bscDescripcionGrupoAtributo01.Enabled = chbAtributo01.Checked
   End Sub
   Private Sub chbAtributo02_CheckedChanged(sender As Object, e As EventArgs) Handles chbAtributo02.CheckedChanged
      If Not _onLoad Then
         bscCodigoGrupoAtributo02.Text = ""
         bscDescripcionGrupoAtributo02.Text = ""
      End If
      bscCodigoGrupoAtributo02.Enabled = chbAtributo02.Checked
      bscDescripcionGrupoAtributo02.Enabled = chbAtributo02.Checked
   End Sub
   Private Sub chbAtributo03_CheckedChanged(sender As Object, e As EventArgs) Handles chbAtributo03.CheckedChanged
      If Not _onLoad Then
         bscCodigoGrupoAtributo03.Text = ""
         bscDescripcionGrupoAtributo03.Text = ""
      End If
      bscCodigoGrupoAtributo03.Enabled = chbAtributo03.Checked
      bscDescripcionGrupoAtributo03.Enabled = chbAtributo03.Checked
   End Sub
   Private Sub chbAtributo04_CheckedChanged(sender As Object, e As EventArgs) Handles chbAtributo04.CheckedChanged
      If Not _onLoad Then
         bscCodigoGrupoAtributo04.Text = ""
         bscDescripcionGrupoAtributo04.Text = ""
      End If
      bscCodigoGrupoAtributo04.Enabled = chbAtributo04.Checked
      bscDescripcionGrupoAtributo04.Enabled = chbAtributo04.Checked
   End Sub

#End Region

End Class