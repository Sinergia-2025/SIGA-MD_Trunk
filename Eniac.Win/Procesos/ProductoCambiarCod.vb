Public Class ProductoCambiarCod

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         tsbActualizar.PerformClick()
         Return True
      ElseIf keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), Eniac.Entidades.Usuario.Actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), Eniac.Entidades.Usuario.Actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2REC_BuscadorClick() Handles bscCodigoProducto2REC.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2REC)
         Me.bscCodigoProducto2REC.Datos = oProductos.GetPorCodigoTodos(Me.bscCodigoProducto2REC.Text.Trim(), Eniac.Entidades.Usuario.Actual.Sucursal.Id, 0)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2REC_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2REC.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProductoRec(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


   Private Sub tsbActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbActualizar.Click

      Try
         If Me.Valida() Then

            Dim men As String
            men = "Usted va a transferir todas las operaciones cambiando el Código del Producto '" & Me.bscProducto2.Text & "'"
            men = men & " desde " & Convert.ToChar(Keys.Enter) & Convert.ToChar(Keys.Enter)
            men = men & Me.bscCodigoProducto2.Text
            men = men & "   a   "
            men = men & Me.bscCodigoProducto2REC.Text & Convert.ToChar(Keys.Enter) & Convert.ToChar(Keys.Enter)
            men = men & "¿ Está seguro ?"

            If MessageBox.Show(men, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.Cursor = Cursors.WaitCursor
               Me.Actualizar()
            Else
               MessageBox.Show("¡¡ Usted a cancelado la actualización !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default

      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub


#End Region

#Region "Metodos"

   Private Function Valida() As Boolean

      If Me.bscCodigoProducto2.Text = "" Then
         MessageBox.Show("Falta ingresar el Código de Producto del ORIGEN", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoProducto2.Focus()
         Return False
      End If

      If Me.bscCodigoProducto2REC.Text = "" Then
         MessageBox.Show("Falta ingresar el Código de Producto del DESTINO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoProducto2REC.Focus()
         Return False
      End If

      If Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
         MessageBox.Show("Se ha cambiado el Código de Producto de ORIGEN", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoProducto2.Focus()
         Return False
      End If

      Dim oProd As Reglas.Productos = New Reglas.Productos()
      If oProd.GetPorCodigoTodos(Me.bscCodigoProducto2REC.Text, Eniac.Entidades.Usuario.Actual.Sucursal.Id, 0).Rows.Count > 0 Then
         MessageBox.Show("El Codigo de Producto DESTINO YA EXISTE", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      Return True

   End Function

   Private Sub CargarDatosProducto(ByVal dr As DataGridViewRow)

      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()

      Me.txtStock.Text = dr.Cells("Stock").Value.ToString()
      Me.txtMarcaCodigo.Text = dr.Cells("IdMarca").Value.ToString()
      Me.txtRubroCodigo.Text = dr.Cells("IdRubro").Value.ToString()
      'Me.txtPrecioCosto.Text = dr.Cells("PrecioCosto").Value.ToString()
      Me.txtPrecioVenta.Text = dr.Cells("PrecioVenta").Value.ToString()

      Dim oMarcas As New Reglas.Marcas
      Dim oRubros As New Reglas.Rubros
      Dim dt As New DataTable

      dt = oMarcas.GetPorCodigo(Int32.Parse(dr.Cells("IdMarca").Value.ToString()))

      Me.txtMarcaNombre.Text = dt.Rows(0)("NombreMarca").ToString()

      dt = oRubros.GetPorCodigo(Int32.Parse(dr.Cells("IdRubro").Value.ToString()))

      Me.txtRubroNombre.Text = dt.Rows(0)("NombreRubro").ToString()

      'Me.bscProducto2.Enabled = False
      'Me.bscCodigoProducto2.Enabled = False

      Me.CargarOperaciones()

      Me.bscCodigoProducto2REC.Focus()

   End Sub

   Private Sub CargarDatosProductoRec(ByVal dr As DataGridViewRow)
      Me.bscCodigoProducto2REC.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      'Me.bscProducto2REC.Text = dr.Cells("NombreProducto").Value.ToString()
   End Sub

   Private Sub CargarOperaciones()

      Dim oStock As Reglas.Stock = New Reglas.Stock()

      Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

      Try

         dtDetalle = oStock.GetDetallePorProducto(Eniac.Entidades.Usuario.Actual.Sucursal.Id, _
                                                   Now.AddYears(-1), Now, _
                                                   "", _
                                                   "", _
                                                   bscCodigoProducto2.Text)

         dt = Me.CrearDT()


         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("FechaMovimiento") = dr("FechaMovimiento").ToString
            drCl("TipoMovimiento") = dr("TipoMovimiento").ToString
            drCl("NumeroMovimiento") = dr("NumeroMovimiento").ToString
            drCl("TipoComprobante") = dr("TipoComprobante").ToString
            drCl("Letra") = dr("Letra").ToString
            If Not String.IsNullOrEmpty(dr("CentroEmisor").ToString) Then
               drCl("NumeroComprobante") = Strings.Format(dr("CentroEmisor"), "0000") & "-" & Strings.Format(dr("NumeroComprobante"), "00000000")
            Else
               drCl("NumeroComprobante") = ""
            End If
            drCl("IdClienteProveedor") = dr("IdClienteProveedor").ToString
            drCl("CodigoClienteProveedor") = dr("CodigoClienteProveedor").ToString
            drCl("NombreClienteProveedor") = dr("NombreClienteProveedor").ToString
            drCl("SucursalDeA") = dr("NombreSucursalDeA").ToString
            drCl("Cantidad") = dr("Cantidad").ToString
            drCl("Usuario") = dr("Usuario").ToString
            drCl("IdFormula") = dr("IdFormula").ToString

            dt.Rows.Add(drCl)

         Next

         Me.dgvDetalle.DataSource = dt

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function CrearDT() As DataTable
      Dim dtTemp As DataTable = New DataTable()
      With dtTemp
         .Columns.Add("FechaMovimiento")
         .Columns.Add("TipoMovimiento")
         .Columns.Add("NumeroMovimiento")
         .Columns.Add("TipoComprobante")
         .Columns.Add("Letra")
         .Columns.Add("NumeroComprobante")
         .Columns.Add("IdClienteProveedor")
         .Columns.Add("CodigoClienteProveedor")
         .Columns.Add("NombreClienteProveedor")
         .Columns.Add("SucursalDeA")
         .Columns.Add("Cantidad")
         .Columns.Add("Usuario")
         .Columns.Add("IdFormula")
      End With
      Return dtTemp
   End Function

   Private Sub Actualizar()

      Dim oProductos As Reglas.Productos = New Reglas.Productos()
      Dim idFormula As Integer? = Nothing

      '-- REQ-31943.- --
      Dim filaDevuelta As DataGridViewRow
      If bscCodigoProducto2.FilaDevuelta Is Nothing Then
         filaDevuelta = bscProducto2.FilaDevuelta
      Else
         filaDevuelta = bscCodigoProducto2.FilaDevuelta
      End If

      If IsNumeric(filaDevuelta.Cells("IdFormula").Value) Then
         idFormula = CInt(filaDevuelta.Cells("IdFormula").Value)
      End If

      oProductos.CambiarCodigo(Me.bscCodigoProducto2.Text, Me.bscCodigoProducto2REC.Text, Reglas.Publicos.NombreBaseProductosWeb,
                               idFormula) '# Esta pantalla no funcionaría si se desea cambiar el código de un producto que tiene fórmula.

      MessageBox.Show("Los datos se actualizaron con exito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Me.LimpiarCampos()

   End Sub

   Private Sub LimpiarCampos()

      bscCodigoProducto2.Text = String.Empty
      bscProducto2.Text = String.Empty
      bscCodigoProducto2REC.Text = String.Empty

      txtMarcaCodigo.Text = String.Empty
      txtMarcaNombre.Text = String.Empty
      txtRubroCodigo.Text = String.Empty
      txtRubroNombre.Text = String.Empty
      txtPrecioVenta.Text = "0.00"
      txtStock.Text = "0.00"

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.bscCodigoProducto2.Focus()

   End Sub

#End Region

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         LimpiarCampos()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class