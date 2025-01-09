Public Class CopiarFormula

#Region "Campos"
   Private _producto As String
   Private _idProductoOriginal As String
   Private _publicos As Publicos
   Private _Componentes As DataTable
#End Region

   Public Sub New(idProducto As String, nombreProducto As String, idProductoOriginal As String)
      MyBase.New()
      InitializeComponent()
      TryCatched(
      Sub()
         _publicos = New Publicos()

         txtIdProducto.Text = idProducto
         txtNombreProducto.Text = nombreProducto

         CargarComponentes(idProducto)

         _producto = idProducto
         _idProductoOriginal = idProductoOriginal
      End Sub)
   End Sub

#Region "Eventos"

   Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      TryCatched(
      Sub()
         Dim rProdForm = New Reglas.ProductosFormulas()
         Dim rFormComp = New Reglas.ProductosComponentes()
         Dim idFormulaNuevo = rProdForm.GetIdFormulaMaximo(_idProductoOriginal)

         Dim reemplaza = False

         Using dt = rProdForm.GetPorNombreExacto(_idProductoOriginal, cmbFormulas.Text)
            If dt.Any() Then
               Dim algunoSinComponentes As Boolean = False
               For Each dr As DataRow In dt.Rows
                  If rFormComp.GetComponentes(actual.Sucursal.IdSucursal, _idProductoOriginal, CInt(dr("IdFormula")), 0).Empty() Then
                     algunoSinComponentes = True
                     reemplaza = True
                     idFormulaNuevo = CInt(dr("IdFormula"))
                  End If
               Next
               If Not algunoSinComponentes Then
                  Dim result = MessageBox.Show("Ya existe una formula con este nombre. ¿Desea reemplazar la misma?" + Environment.NewLine + Environment.NewLine +
                                               "   SI: Reemplaza la formula existente" + Environment.NewLine +
                                               "   NO: Crea una nueva formula con el mismo nombre" + Environment.NewLine +
                                               "   CANCELAR: Cancela la grabación", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                  If result = Windows.Forms.DialogResult.Cancel Then
                     Exit Sub
                  ElseIf result = Windows.Forms.DialogResult.Yes Then
                     reemplaza = True
                     idFormulaNuevo = dt.Rows(0).Field(Of Integer)("IdFormula")
                  End If
               End If
            End If
         End Using

         If Not reemplaza Then rProdForm.GrabarFormula(_idProductoOriginal, idFormulaNuevo, cmbFormulas.Text, PorcentajeGanancia:=0)
         rFormComp.GrabarComponentesCopiados(_idProductoOriginal, idFormulaNuevo, _Componentes)

         Dim rProd = New Reglas.Productos()
         Dim rFormulas = New Reglas.ProductosFormulas()
         Using formulas = rFormulas.GetFormulas(actual.Sucursal.IdSucursal, _idProductoOriginal)
            If formulas.Rows.Count = 1 Then
               For Each dr In formulas.AsEnumerable()
                  rProd.ActualizarFormulaDefecto(_idProductoOriginal, dr.Field(Of Integer)("IdFormula"))
               Next
            End If
         End Using

         ShowMessage("Se copió la formula correctamente.")
         Close(DialogResult.OK)
      End Sub)
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub

   Private Sub cmbFormulas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFormulas.SelectedIndexChanged
      TryCatched(
      Sub()
         Dim idFormula = cmbFormulas.ValorSeleccionado(cmbFormulas.SelectedIndex >= 0, -1I)

         Dim rComponentes = New Reglas.ProductosComponentes()
         _Componentes = rComponentes.GetComponentes(actual.Sucursal.IdSucursal, _producto, idFormula, Reglas.Publicos.ListaPreciosPredeterminada)
         ugComponentes.DataSource = _Componentes
         AjustarColumnasVisibles()
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarComponentes(IdProducto As String)

      'Carga grilla de Componentes Productos

      cmbFormulas.Enabled = True

      _publicos.CargaComboFormulasDeProductos(cmbFormulas, IdProducto)
      If cmbFormulas.Items.Count > 0 Then
         Dim producto = New Reglas.Productos().GetUno(IdProducto)
         cmbFormulas.SelectedValue = producto.IdFormula 'Si esta NULL viene en cero y al no encontrar elemento queda en -1
         If cmbFormulas.SelectedIndex = -1 Then
            cmbFormulas.SelectedIndex = 0
         End If
      End If

      If cmbFormulas.SelectedValue IsNot Nothing OrElse cmbFormulas.Items.Count > 0 Then
         Dim rComponentes = New Reglas.ProductosComponentes()
         _Componentes = rComponentes.GetComponentes(actual.Sucursal.IdSucursal, IdProducto, cmbFormulas.ValorSeleccionado(Of Integer),
                                                    Reglas.Publicos.ListaPreciosPredeterminada)
         ugComponentes.DataSource = _Componentes
         AjustarColumnasVisibles()
      End If

   End Sub

   Private _columnasVisibles As String() = {"IdProductoComponente", "NombreProducto", "PrecioCosto", "Cantidad"}
   Private Sub AjustarColumnasVisibles()
      ugComponentes.DisplayLayout.Bands(0).Columns.OfType(Of UltraGridColumn).ToList().
         ForEach(Sub(c) c.Hidden = Not _columnasVisibles.Contains(c.Key))
      ugComponentes.AgregarFiltroEnLinea({"NombreProducto"})
   End Sub

#End Region

End Class