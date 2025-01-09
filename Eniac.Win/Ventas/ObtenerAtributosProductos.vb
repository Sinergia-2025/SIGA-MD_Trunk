Public Class ObtenerAtributosProductos
   Implements ISeleccionaAtributosProductos

#Region "Campos"
   Public Property Atributo01 As New Entidades.AtributoProducto Implements ISeleccionaAtributosProductos.Atributo01
   Public Property Atributo02 As New Entidades.AtributoProducto Implements ISeleccionaAtributosProductos.Atributo02
   Public Property Atributo03 As New Entidades.AtributoProducto Implements ISeleccionaAtributosProductos.Atributo03
   Public Property Atributo04 As New Entidades.AtributoProducto Implements ISeleccionaAtributosProductos.Atributo04

   Private _onLoad As Boolean = False
   Private _publicos As Publicos

   Public Property idSucursal As Integer Implements ISeleccionaAtributosProductos.idSucursal
   Public Property idProducto As String Implements ISeleccionaAtributosProductos.idProducto

   '-- REQ-34669.- --------------------------------------------------------------------------------------------------
   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
   '-----------------------------------------------------------------------------------------------------------------
   Private _DatosAtributoProducto As DataTable
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      Try
         MyBase.OnLoad(e)

         Me._publicos = New Publicos()

         _onLoad = True

         '-- REQ-34669.- ---------------------------------------------------------------------------------------
         VerificaValorAtributos()
         '-- Recupera Datos Generales.- -----
         _DatosAtributoProducto = New Reglas.AtributosProductos().GetStockAtributoProductos(idProducto, idSucursal, Atributo01.IdGrupoTipoAtributoProducto, Atributo01.IdTipoAtributoProducto, Atributo02.IdGrupoTipoAtributoProducto, Atributo02.IdTipoAtributoProducto)
         '-- Carga los datos a la grilla.- --
         SeteaAtributoProductoSource()
         '-- Formatea Grilla.- --------------
         FormateaGrilla()
         '-----------------------------------------------------------------------------------------------------
         If (Atributo01.IdGrupoTipoAtributoProducto + Atributo01.IdTipoAtributoProducto) > 0 Then
            txtAtributo01.Select()
         ElseIf (Atributo02.IdGrupoTipoAtributoProducto + Atributo02.IdTipoAtributoProducto) > 0 Then
            txtAtributo02.Select()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         _onLoad = False
      End Try

   End Sub
#End Region

#Region "Eventos"
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      '----------------------------------------------------------------------------------
      DialogResult = Windows.Forms.DialogResult.Cancel
      Close()
      '----------------------------------------------------------------------------------
   End Sub
   Private Sub txtAtributo01_TextChanged(sender As Object, e As EventArgs) Handles txtAtributo01.TextChanged
      With ugDetalle.DisplayLayout.Bands(0)
         For Each col In .Columns.OfType(Of UltraGridColumn).Where(Function(c) c.Key.StartsWith("Atrib1_"))
            col.Hidden = Not col.Header.Caption.ToLower().Contains(txtAtributo01.Text.ToLower())
         Next
      End With
   End Sub
   Private Sub txtAtributo02_TextChanged(sender As Object, e As EventArgs) Handles txtAtributo02.TextChanged
      bdsAtributosProductos.Filter = String.Format("DescripcionAtributo like '%{0}%'", txtAtributo02.Text)
   End Sub
   Private Sub txtAtributo01_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAtributo01.KeyPress, txtAtributo02.KeyPress
      TryCatched(
         Sub()
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
               Dim countVisibles = ugDetalle.DisplayLayout.Bands(0).Columns.OfType(Of UltraGridColumn).Where(Function(c) (c.Key.StartsWith("Atrib1_") Or c.Key.StartsWith("Stock")) And c.Hidden = False)
               If ugDetalle.Rows.Count = 1 And countVisibles.Count = 1 Then
                  ugDetalle.ActiveCell = ugDetalle.Rows(0).Cells(countVisibles(0).Key)
                  Aceptar()
               End If
            End If
         End Sub)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() Aceptar())
   End Sub
   Private Sub ugDetalle_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ugDetalle.KeyPress
      TryCatched(Sub() Aceptar())
   End Sub
   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
      TryCatched(Sub() Aceptar())
   End Sub
#End Region

#Region "Metodos"
   ''' <summary>
   ''' Procedimiento al presionar el boton Aceptar.-
   ''' </summary>
   Private Sub Aceptar()

      If ugDetalle.ActiveCell Is Nothing Then Exit Sub
      If Not ugDetalle.ActiveCell.Column.Key.StartsWith("Atrib1_") AndAlso Not ugDetalle.ActiveCell.Column.Key.StartsWith("Stock") Then
         Throw New Exception(String.Format("Debe seleccionar una celda de {0}.", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01).Descripcion))
      End If

      Dim idAtributo01 = If(ugDetalle.ActiveCell.Column.Key.StartsWith("Stock"), 0, ugDetalle.ActiveCell.Column.Key.Split("_"c)(1).ToInt32().IfNull())
      Dim idAtributo02 = ugDetalle.ActiveCell.Row.Cells("IdAtributo").Value.ToString().ToInt32().IfNull()

      '-- Carga datos en Entidades.- ----------------------------------------------------
      Atributo01 = New Reglas.AtributosProductos().GetUnoIDA(idAtributo01)
      Atributo02 = New Reglas.AtributosProductos().GetUnoIDA(idAtributo02)
      '----------------------------------------------------------------------------------
      DialogResult = Windows.Forms.DialogResult.OK
      Close()
   End Sub
   ''' <summary>
   ''' Setea Data source a la grilla de Atributos Productos.-
   ''' </summary>
   Private Sub SeteaAtributoProductoSource()
      bdsAtributosProductos.DataSource = _DatosAtributoProducto
      ugDetalle.DataSource = bdsAtributosProductos
   End Sub
   ''' <summary>
   ''' Procedimiento de Formateo de Grilla de Atributos Productos.- 
   ''' </summary>
   Private Sub FormateaGrilla()
      With ugDetalle.DisplayLayout.Bands(0)
         '-- Configura solo las visibles.- --
         .Columns("IdAtributo").Hidden = True
         If (Atributo02.IdGrupoTipoAtributoProducto + Atributo02.IdTipoAtributoProducto) > 0 Then
            .Columns("DescripcionAtributo").Header.Caption = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02).Descripcion
         Else
            .Columns("DescripcionAtributo").Hidden = True
         End If
         '-- Recorre Columnas y establece el Header.- ------------
         For Each col In .Columns.OfType(Of UltraGridColumn).Where(Function(c) c.Key.StartsWith("Atrib1_"))
            col.Header.Caption = col.Header.Caption.Split("_"c)(2)
            col.Header.Appearance.TextHAlign = HAlign.Center
            col.CellAppearance.TextHAlign = HAlign.Right
            col.CellActivation = Activation.NoEdit
            '-- REQ-35481.- Establece Formato de los Valores.- --- 
            col.Format = "N0"
         Next
         '--------------------------------------------------------
      End With
   End Sub
   ''' <summary>
   ''' Obtienen los Nombres de los Tipos de Atributos de Parametros.- ----------------
   ''' </summary>
   Private Sub VerificaValorAtributos()
      Dim eAtributo As Entidades.TipoAtributoProducto
      '-- Atributo 001.- -------------------------------------------------------------
      If TipoAtributo01 > 0 And (Atributo01.IdGrupoTipoAtributoProducto + Atributo01.IdTipoAtributoProducto) > 0 Then
         '-- Carga Valores Check.- ---------------------------------------------------
         eAtributo = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01)
         lblAtributo01.Text = eAtributo.Descripcion
      Else
         lblAtributo01.Visible = False
         txtAtributo01.Visible = False
      End If
      '-- Atributo 002.- -------------------------------------------------------------
      If TipoAtributo02 > 0 And (Atributo02.IdGrupoTipoAtributoProducto + Atributo02.IdTipoAtributoProducto) > 0 Then
         '-- Carga Valores Check.- ---------------------------------------------------
         eAtributo = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02)
         lblAtributo02.Text = eAtributo.Descripcion
      Else
         lblAtributo02.Visible = False
         txtAtributo02.Visible = False
      End If
   End Sub

   Private Function ISeleccionaAtributosProductos_ShowDialog(owner As IWin32Window) As DialogResult Implements ISeleccionaAtributosProductos.ShowDialog
      Return ShowDialog(owner)
   End Function


#End Region

End Class