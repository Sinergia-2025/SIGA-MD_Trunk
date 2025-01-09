Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ProductoUnificarCodigos

#Region "Campos"

   Private _publicos As Publicos
   Private _listas As List(Of Entidades.ListaDePrecios)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me.CargaListasDePrecios()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Sub CargaListasDePrecios()

      Dim oLista As Reglas.ListasDePrecios = New Reglas.ListasDePrecios()

      Me._listas = oLista.GetTodos()

      Dim dt As DataTable = New DataTable()
      dt.Columns.Add("Id", System.Type.GetType("System.Int32"))
      dt.Columns.Add("Lista", System.Type.GetType("System.String"))
      dt.Columns.Add("Producto1", System.Type.GetType("System.Boolean"))
      dt.Columns.Add("Producto2", System.Type.GetType("System.Boolean"))
      dt.Columns.Add("Precio", System.Type.GetType("System.Decimal"))

      Dim dr As DataRow

      For Each lp As Entidades.ListaDePrecios In Me._listas
         dr = dt.NewRow()
         dr("Id") = lp.IdListaPrecios
         dr("Lista") = lp.NombreListaPrecios
         dr("Producto1") = False
         dr("Producto2") = False
         dr("Precio") = 0
         dt.Rows.Add(dr)
      Next

      'dr = dt.NewRow()
      'dr("Id") = 0
      'dr("Lista") = "Lista de Venta 1"
      'dr("Producto1") = False
      'dr("Producto2") = False
      'dr("Precio") = 0
      'dt.Rows.InsertAt(dr, 0)


      Me.dgvListasPrecios.DataSource = dt

      'seteo la grilla
      With Me.dgvListasPrecios
         .RowHeadersVisible = False

         .Columns("Id").Visible = False

         .Columns("Lista").HeaderText = "Nombre"
         .Columns("Lista").Width = 100
         .Columns("Lista").ReadOnly = True

         .Columns("Producto1").HeaderText = "Pd. 1"
         .Columns("Producto1").Width = 40
         .Columns("Producto1").ValueType = System.Type.GetType("System.Boolean")

         .Columns("Producto2").HeaderText = "Pd. 2"
         .Columns("Producto2").Width = 40
         .Columns("Producto2").ValueType = System.Type.GetType("System.Boolean")

         .Columns("Precio").HeaderText = "Precio"
         .Columns("Precio").Width = 60
         .Columns("Precio").ReadOnly = True
         .Columns("Precio").DefaultCellStyle.Format = "#,##0.00"
         .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

      End With

   End Sub

   Private Function Valida() As Boolean

        If Me.bscCodigoProducto12.Text = "" Then
            MessageBox.Show("Falta ingresar el Código de Producto 1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto12.Focus()
            Return False
        End If

        If Me.bscCodigoProducto22.Text = "" Then
            MessageBox.Show("Falta ingresar el Código de Producto 2", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto22.Focus()
            Return False
        End If

        If Not Me.bscCodigoProducto12.Selecciono Then
            MessageBox.Show("Se ha cambiado el Código de Producto 1", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto12.Focus()
            Return False
        End If

        If Not Me.bscCodigoProducto22.Selecciono Then
            MessageBox.Show("Se ha cambiado el Código de Producto 2", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto22.Focus()
            Return False
        End If

        If Not Me.rdbPrecCompra1.Checked And Not Me.rdbPrecCompra2.Checked Then
            MessageBox.Show("NO ha seleccionado el Precio de Compra Resultante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.rdbPrecCompra1.Focus()
            Return False
        End If

        If Not Me.rdbPrecCosto1.Checked And Not Me.rdbPrecCosto2.Checked Then
            MessageBox.Show("NO ha seleccionado el Precio de Costo Resultante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.rdbPrecCosto1.Focus()
            Return False
        End If

        If Not Me.rdbProducto1.Checked And Not Me.rdbProducto2.Checked Then
            MessageBox.Show("NO ha seleccionado el Producto Resultante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.rdbProducto1.Focus()
            Return False
        End If

        If Me.txtDescripcionProductoResultado.Text.Trim() = "" Then
            MessageBox.Show("NO existe la Descripcion del Producto Resultante", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtDescripcionProductoResultado.Focus()
            Return False
        End If

        If Me.txtMarcaNombre1.Text <> Me.txtMarcaNombre2.Text Then
            MessageBox.Show("NO coinciden las Marcas de los Productos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtMarcaNombre1.Focus()
            Return False
        End If

        If Me.txtRubroNombre1.Text <> Me.txtRubroNombre2.Text Then
            MessageBox.Show("NO coincideb los Rubros de los Productos", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRubroNombre1.Focus()
            Return False
        End If

        For Each dr As DataGridViewRow In Me.dgvListasPrecios.Rows
            If Not Boolean.Parse(dr.Cells("Producto1").Value.ToString()) And Not Boolean.Parse(dr.Cells("Producto2").Value.ToString()) Then
                MessageBox.Show("La '" & dr.Cells("Lista").Value.ToString() & "' No tiene seleccionado el Producto ", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.dgvListasPrecios.Focus()
                Return False
            End If
        Next

        Return True

    End Function

    Private Sub CargarProducto(ByVal QueProducto As Integer, ByVal dr As DataGridViewRow)

        Dim oMarcas As New Reglas.Marcas
        Dim oRubros As New Reglas.Rubros
        Dim dt As New DataTable

        If QueProducto = 1 Then

            Me.bscCodigoProducto12.Text = dr.Cells("IdProducto").Value.ToString.Trim()
            Me.bscProducto12.Text = dr.Cells("NombreProducto").Value.ToString()

            Me.txtStock1.Text = dr.Cells("Stock").Value.ToString()

            Me.txtPrecioCompra1.Text = dr.Cells("PrecioFabrica").Value.ToString()
            Me.txtPrecioCosto1.Text = dr.Cells("PrecioCosto").Value.ToString()
            Me.txtPrecioVenta1.Text = dr.Cells("PrecioVenta").Value.ToString()

            dt = oMarcas.GetPorCodigo(Int32.Parse(dr.Cells("IdMarca").Value.ToString()))

            Me.txtMarcaNombre1.Text = dt.Rows(0)("NombreMarca").ToString()

            dt = oRubros.GetPorCodigo(Int32.Parse(dr.Cells("IdRubro").Value.ToString()))

            Me.txtRubroNombre1.Text = dt.Rows(0)("NombreRubro").ToString()

        Else

            Me.bscCodigoProducto22.Text = dr.Cells("IdProducto").Value.ToString.Trim()
            Me.bscProducto22.Text = dr.Cells("NombreProducto").Value.ToString()

            Me.txtStock2.Text = dr.Cells("Stock").Value.ToString()

            Me.txtPrecioCompra2.Text = dr.Cells("PrecioFabrica").Value.ToString()
            Me.txtPrecioCosto2.Text = dr.Cells("PrecioCosto").Value.ToString()
            Me.txtPrecioVenta2.Text = dr.Cells("PrecioVenta").Value.ToString()

            dt = oMarcas.GetPorCodigo(Int32.Parse(dr.Cells("IdMarca").Value.ToString()))

            Me.txtMarcaNombre2.Text = dt.Rows(0)("NombreMarca").ToString()

            dt = oRubros.GetPorCodigo(Int32.Parse(dr.Cells("IdRubro").Value.ToString()))

            Me.txtRubroNombre2.Text = dt.Rows(0)("NombreRubro").ToString()

        End If

        Me.txtStockResultado.Text = (Decimal.Parse(Me.txtStock1.Text) + Decimal.Parse(Me.txtStock2.Text)).ToString("##0.00")

        Me.CargarOperaciones(QueProducto)

        Me.rdbPrecCompra1.Checked = False
        Me.rdbPrecCompra2.Checked = False

        Me.rdbPrecCosto1.Checked = False
        Me.rdbPrecCosto2.Checked = False

        Me.rdbProducto1.Checked = False
        Me.rdbProducto2.Checked = False

        Me.CargaListasDePrecios() 'Para blanquear el precio elegido

    End Sub

    Private Sub CargarOperaciones(ByVal QueProducto As Integer)

        Dim oStock As Reglas.Stock = New Reglas.Stock()

        Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

        Try

            dtDetalle = oStock.GetDetallePorProducto(Eniac.Entidades.Usuario.Actual.Sucursal.Id, _
                                                     Now.AddYears(-1), Now, _
                                                     "", _
                                                     "", _
                                                      IIf(QueProducto = 1, bscCodigoProducto12.Text.Trim(), bscCodigoProducto22.Text.Trim()).ToString())

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
            drCl("IdClienteProveedor") = Long.Parse(dr("IdClienteProveedor").ToString)
            drCl("CodigoClienteProveedor") = Long.Parse(dr("CodigoClienteProveedor").ToString)
                drCl("NombreClienteProveedor") = dr("NombreClienteProveedor").ToString
                drCl("SucursalDeA") = dr("NombreSucursalDeA").ToString
                drCl("Cantidad") = dr("Cantidad").ToString
                drCl("Usuario") = dr("Usuario").ToString

                dt.Rows.Add(drCl)

            Next

            If QueProducto = 1 Then
                Me.dgvDetalle1.DataSource = dt
            Else
                Me.dgvDetalle2.DataSource = dt
            End If

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
        End With
        Return dtTemp
    End Function

    Private Sub Actualizar()

        Dim oProductos As Reglas.Productos = New Reglas.Productos()

        Dim Stock As Decimal, PrecioCompra As Decimal, PrecioCosto As Decimal, Listas As DataTable, CodigoProducto As Integer, DescripcionProducto As String

        Stock = Decimal.Parse(Me.txtStockResultado.Text)
        PrecioCompra = Decimal.Parse(Me.txtPrecioCompraResultado.Text)
        PrecioCosto = Decimal.Parse(Me.txtPrecioCostoResultado.Text)
        Listas = DirectCast(Me.dgvListasPrecios.DataSource, System.Data.DataTable)
        CodigoProducto = Int32.Parse(IIf(Me.rdbProducto1.Checked, 1, 2).ToString())
        DescripcionProducto = Me.txtDescripcionProductoResultado.Text

        oProductos.UnificarCodigos(actual.Sucursal.Id, _
                                   Me.bscCodigoProducto12.Text, _
                                   Me.bscCodigoProducto22.Text, _
                                   Stock, _
                                   PrecioCompra, _
                                   PrecioCosto, _
                                   Listas, _
                                   CodigoProducto, _
                                   DescripcionProducto, _
                                   actual.Nombre)

        MessageBox.Show("Los datos se actualizaron con exito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.LimpiarCampos()

    End Sub

    Private Sub LimpiarCampos()

        Me.bscCodigoProducto12.Text = ""
        Me.bscProducto12.Text = ""
        Me.txtStock1.Text = "0.00"
        Me.txtPrecioCompra1.Text = "0.00"
        Me.txtPrecioCosto1.Text = "0.00"
        Me.txtPrecioVenta1.Text = "0.00"
        Me.txtMarcaNombre1.Text = ""
        Me.txtRubroNombre1.Text = ""

        Me.bscCodigoProducto22.Text = ""
        Me.bscProducto22.Text = ""
        Me.txtStock2.Text = "0.00"
        Me.txtPrecioCompra2.Text = "0.00"
        Me.txtPrecioCosto2.Text = "0.00"
        Me.txtPrecioVenta2.Text = "0.00"
        Me.txtMarcaNombre2.Text = ""
        Me.txtRubroNombre2.Text = ""

        If Not Me.dgvDetalle1.DataSource Is Nothing Then
            DirectCast(Me.dgvDetalle1.DataSource, DataTable).Rows.Clear()
        End If

        If Not Me.dgvDetalle2.DataSource Is Nothing Then
            DirectCast(Me.dgvDetalle2.DataSource, DataTable).Rows.Clear()
        End If

        Me.rdbPrecCompra1.Checked = False
        Me.rdbPrecCompra2.Checked = False

        Me.rdbPrecCosto1.Checked = False
        Me.rdbPrecCosto2.Checked = False

        Me.rdbProducto1.Checked = False
        Me.rdbProducto2.Checked = False

        Me.CargaListasDePrecios()  'Para limpiar

        Me.bscCodigoProducto12.Focus()

    End Sub

#End Region

#Region "Eventos"

    Private Sub dgvListasPrecios_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvListasPrecios.CellContentClick
        Try
            If e.RowIndex > -1 Then
                Me.dgvListasPrecios.EndEdit()
                If e.ColumnIndex = 2 Then
                    Me.dgvListasPrecios.Rows(e.RowIndex).Cells(3).Value = Not Boolean.Parse(Me.dgvListasPrecios.Rows(e.RowIndex).Cells(2).Value.ToString())
                    Me.dgvListasPrecios.Rows(e.RowIndex).Cells(4).Value = Decimal.Parse(Me.txtPrecioVenta1.Text)
                End If
                If e.ColumnIndex = 3 Then
                    Me.dgvListasPrecios.Rows(e.RowIndex).Cells(2).Value = Not Boolean.Parse(Me.dgvListasPrecios.Rows(e.RowIndex).Cells(3).Value.ToString())
                    Me.dgvListasPrecios.Rows(e.RowIndex).Cells(4).Value = Decimal.Parse(Me.txtPrecioVenta2.Text)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscCodigoProducto12_BuscadorClick() Handles bscCodigoProducto12.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto12)
         Me.bscCodigoProducto12.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto12.Text.Trim(), Eniac.Entidades.Usuario.Actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub bscCodigoProducto12_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto12.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(1, e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub bscProducto12_BuscadorClick() Handles bscProducto12.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me._publicos.PreparaGrillaProductos2(Me.bscProducto12)
         Me.bscProducto12.Datos = oProductos.GetPorNombre(Me.bscProducto12.Text.Trim(), Eniac.Entidades.Usuario.Actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
            Me.bscCodigoProducto12.Selecciono = True   'siempre debe estar confirmado el codigo, no importa si ajusto la descripcion.
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub bscProducto12_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto12.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(1, e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscCodigoProducto22_BuscadorClick() Handles bscCodigoProducto22.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto22)
         Me.bscCodigoProducto22.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto22.Text.Trim(), Eniac.Entidades.Usuario.Actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub bscCodigoProducto22_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto22.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(2, e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub bscProducto22_BuscadorClick() Handles bscProducto22.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me._publicos.PreparaGrillaProductos2(Me.bscProducto22)
         Me.bscProducto22.Datos = oProductos.GetPorNombre(Me.bscProducto22.Text.Trim(), Eniac.Entidades.Usuario.Actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
            Me.bscCodigoProducto22.Selecciono = True   'siempre debe estar confirmado el codigo, no importa si ajusto la descripcion.
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub bscProducto22_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto22.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(2, e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub tsbActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbActualizar.Click

        Try
            If Me.Valida() Then

                Dim men As String
                men = "Usted va a UNIFICAR los productos y las operaciones del Producto "
                men = men & Convert.ToChar(Keys.Enter) & Convert.ToChar(Keys.Enter)
                men = men & Me.bscCodigoProducto12.Text & " - " & Me.bscProducto12.Text
                men = men & Convert.ToChar(Keys.Enter) & Convert.ToChar(Keys.Enter)
                men = men & "             y " & Convert.ToChar(Keys.Enter) & Convert.ToChar(Keys.Enter)
                men = men & Me.bscCodigoProducto22.Text & " - " & Me.bscProducto22.Text
                men = men & Convert.ToChar(Keys.Enter) & Convert.ToChar(Keys.Enter)
                men = men & "¿ Está seguro ?"

                If MessageBox.Show(men, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.Actualizar()
                Else
                    MessageBox.Show("¡¡ Usted a cancelado la unificación !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Se produjo un problema haciendo el cambio, detalle: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub rdbPrecCompra1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPrecCompra1.CheckedChanged
        Me.txtPrecioCompraResultado.Text = Me.txtPrecioCompra1.Text
    End Sub

    Private Sub rdbPrecCompra2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPrecCompra2.CheckedChanged
        Me.txtPrecioCompraResultado.Text = Me.txtPrecioCompra2.Text
    End Sub

    Private Sub rdbPrecCosto1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPrecCosto1.CheckedChanged
        Me.txtPrecioCostoResultado.Text = Me.txtPrecioCosto1.Text
    End Sub

    Private Sub rdbPrecCosto2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbPrecCosto2.CheckedChanged
        Me.txtPrecioCostoResultado.Text = Me.txtPrecioCosto2.Text
    End Sub

    Private Sub rdbProducto1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbProducto1.CheckedChanged
        Me.txtCodigoProductoResultado.Text = Me.bscCodigoProducto12.Text
        Me.txtDescripcionProductoResultado.Text = Me.bscProducto12.Text
    End Sub

    Private Sub rdbProducto2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbProducto2.CheckedChanged
        Me.txtCodigoProductoResultado.Text = Me.bscCodigoProducto22.Text
        Me.txtDescripcionProductoResultado.Text = Me.bscProducto22.Text
    End Sub


#End Region

End Class