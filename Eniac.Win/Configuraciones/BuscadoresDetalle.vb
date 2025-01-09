Public Class BuscadoresDetalle

   Private _publicos As Publicos
   Private ReadOnly Property Buscador As Entidades.Buscador
      Get
         Return DirectCast(_entidad, Entidades.Buscador)
      End Get
   End Property

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.Buscador)
      Me.New()
      _entidad = entidad
   End Sub
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()
         _publicos.CargaComboDesdeEnum(cmbIniciaConFocoEn, Entidades.Buscador.IniciaConFocoEnList.Grilla)
         _publicos.CargaComboDesdeEnum(cmbColumnaCondicion, Entidades.BuscadorCampo.TipoCondicion.Igual)
         _publicos.CargaComboDesdeEnum(cmbColumnaAlineacion, DataGridViewContentAlignment.MiddleLeft)

         ugBuscadoresColumnas.DataSource = Buscador.Campos

         BindearControles(_entidad)
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Buscadores()
   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Campos"
#Region "Eventos Campos"
   Private Sub btnRefrescarCampos_Click(sender As Object, e As EventArgs) Handles btnRefrescarCondicion.Click
      TryCatched(Sub() LimpiarCampo())
   End Sub
   Private Sub btnInsertarCampos_Click(sender As Object, e As EventArgs) Handles btnInsertarCondicion.Click
      TryCatched(Sub() InsertarCampo())
   End Sub
   Private Sub btnEliminarCampos_Click(sender As Object, e As EventArgs) Handles btnEliminarCondicion.Click
      TryCatched(Sub() EliminarCampo())
   End Sub
   Private Sub ugBuscadoresColumnas_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugBuscadoresColumnas.DoubleClickCell
      TryCatched(Sub() EditarCampo())
   End Sub
   Private Sub txtIdBuscadorNombreCampo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdBuscadorNombreCampo.KeyDown, txtColumnaValor.KeyDown, txtColumnaTitulo.KeyDown, txtColumnaOrden.KeyDown, txtColumnaFormato.KeyDown, txtColumnaColorFila.KeyDown, txtColumnaAncho.KeyDown, cmbColumnaCondicion.KeyDown, cmbColumnaAlineacion.KeyDown
      PresionarTab(e)
   End Sub
#End Region

#Region "Metodos"
   Public Sub LimpiarCampo()
      txtIdBuscadorNombreCampo.Clear()
      txtColumnaTitulo.Clear()
      txtColumnaOrden.SetValor(0I)
      txtColumnaAncho.SetValor(0I)
      cmbColumnaAlineacion.SelectedValue = DataGridViewContentAlignment.MiddleLeft
      txtColumnaFormato.Clear()
      cmbColumnaCondicion.SelectedValue = Entidades.BuscadorCampo.TipoCondicion.Igual
      txtColumnaValor.Clear()
      txtColumnaColorFila.Clear()
      txtIdBuscadorNombreCampo.Focus()
   End Sub
   Public Sub InsertarCampo()
      If ValidaCampo() Then
         Dim campo = New Entidades.BuscadorCampo With {
            .IdBuscadorNombreCampo = txtIdBuscadorNombreCampo.Text,
            .Titulo = txtColumnaTitulo.Text,
            .Orden = txtColumnaOrden.ValorNumericoPorDefecto(0I),
            .Ancho = txtColumnaAncho.ValorNumericoPorDefecto(0I),
            .Alineacion = cmbColumnaAlineacion.ValorSeleccionado(Of DataGridViewContentAlignment),
            .Formato = txtColumnaFormato.Text,
            .Condicion = cmbColumnaCondicion.ValorSeleccionado(Of Entidades.BuscadorCampo.TipoCondicion),
            .ValorCondicion = txtColumnaValor.Text,
            .ColorFilaCondicion = txtColumnaColorFila.Text
         }
         Buscador.Campos.Add(campo)
         ugBuscadoresColumnas.Rows.Refresh(RefreshRow.ReloadData)
         LimpiarCampo()
      End If
   End Sub
   Public Function ValidaCampo() As Boolean
      If String.IsNullOrWhiteSpace(txtIdBuscadorNombreCampo.Text) Then
         ShowMessage("El Campo es requerido.")
         txtIdBuscadorNombreCampo.Focus()
         Return False
      End If
      If String.IsNullOrWhiteSpace(txtColumnaTitulo.Text) Then
         ShowMessage("El Titulo es requerido.")
         txtColumnaTitulo.Focus()
         Return False
      End If
      If txtColumnaOrden.ValorNumericoPorDefecto(0I) <= 0I Then
         ShowMessage("El Orden debe ser mayor a cero.")
         txtColumnaOrden.Focus()
         Return False
      End If
      If txtColumnaAncho.ValorNumericoPorDefecto(0I) <= 0I Then
         ShowMessage("El Ancho debe ser mayor a cero.")
         txtColumnaAncho.Focus()
         Return False
      End If
      If cmbColumnaAlineacion.SelectedIndex = -1 Then
         ShowMessage("Debe seleccionar una Alineación.")
         cmbColumnaAlineacion.Focus()
         Return False
      End If
      If cmbColumnaCondicion.SelectedIndex = -1 Then
         ShowMessage("Debe seleccionar una Condición.")
         cmbColumnaCondicion.Focus()
         Return False
      End If
      Return True
   End Function
   Public Sub EliminarCampo()
      Dim campo = ugBuscadoresColumnas.FilaSeleccionada(Of Entidades.BuscadorCampo)
      If campo IsNot Nothing AndAlso ShowPregunta("¿Desea eliminar el campo de la lista de campos?") = DialogResult.Yes Then
         EliminarCampo(campo)
      End If
   End Sub
   Public Sub EliminarCampo(campo As Entidades.BuscadorCampo)
      Buscador.Campos.Remove(campo)
      ugBuscadoresColumnas.Rows.Refresh(RefreshRow.ReloadData)
   End Sub
   Public Sub EditarCampo()
      Dim campo = ugBuscadoresColumnas.FilaSeleccionada(Of Entidades.BuscadorCampo)
      If campo IsNot Nothing Then
         Dim campo1 = New Entidades.BuscadorCampo()
         txtIdBuscadorNombreCampo.Text = campo.IdBuscadorNombreCampo
         txtColumnaTitulo.Text = campo.Titulo
         txtColumnaOrden.SetValor(campo.Orden)
         txtColumnaAncho.SetValor(campo.Ancho)
         cmbColumnaAlineacion.SelectedValue = campo.Alineacion
         txtColumnaFormato.Text = campo.Formato
         cmbColumnaCondicion.SelectedValue = campo.Condicion
         txtColumnaValor.Text = campo.ValorCondicion
         txtColumnaColorFila.Text = campo.ColorFilaCondicion

         txtIdBuscadorNombreCampo.Focus()
         EliminarCampo(campo)
      End If
   End Sub

#End Region

#End Region
End Class