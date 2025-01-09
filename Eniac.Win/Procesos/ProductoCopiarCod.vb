Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ProductoCopiarCod

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos()
         Me.txtCodigoInicial.Text = (oProductos.GetCodigoMaximo() + 1).ToString()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"


   Private Sub ProductoCopiarCod_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

         'Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbActualizar.Click

      Try
         If Me.Valida() Then

            Dim men As String
                men = "Usted va a COPIAR el Producto '" & Me.bscCodigoProducto2.Text.Trim() & " - " & Me.bscProducto2.Text & "'"
                men = men & Convert.ToChar(Keys.Enter) & Convert.ToChar(Keys.Enter)
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

    Private Sub tsbGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGenerar.Click

        Try

            If Integer.Parse(Me.txtCopias.Text) <= 0 Then
                MessageBox.Show("ATENCION: debe cargar un valor correcto de CANTIDAD DE COPIAS", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.txtCopias.Focus()
                Exit Sub
            End If

            If Integer.Parse(Me.txtCopias.Text) > 20 Then
                MessageBox.Show("ATENCION: El MAXIMO de cantidad de copias es 20", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.txtCopias.Focus()
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            Me.Mostrar()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

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
                Me.CargarProducto(e.FilaDevuelta)
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
                Me.CargarProducto(e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

#End Region

#Region "Metodos"

    Private Sub RefrescarDatosGrilla()

        Me.bscCodigoProducto2.Enabled = True
        Me.bscProducto2.Enabled = True

        Me.bscCodigoProducto2.Text = ""
        Me.bscProducto2.Text = ""

        Me.txtMarcaCodigo.Text = ""
        Me.txtMarcaNombre.Text = ""
        Me.txtRubroCodigo.Text = ""
        Me.txtRubroNombre.Text = ""
        Me.txtTamanio.Text = ""
        Me.txtUnidadDeMedida.Text = ""

        Me.txtStock.Text = "0.00"
        Me.txtPrecioCosto.Text = "0.00"
        Me.txtPrecioVenta.Text = "0.00"

        Me.txtCopias.Text = "0"

        'Limpio la Grilla.

        'Metodo 1
        If Not Me.dgvDetalle.DataSource Is Nothing Then
            DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
        End If

        Me.txtPrefijo.Text = ""

        Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos()
        Me.txtCodigoInicial.Text = (oProductos.GetCodigoMaximo() + 1).ToString()

        Me.bscCodigoProducto2.Focus()

    End Sub

    Private Sub CargarProducto(ByVal dr As DataGridViewRow)

        Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString()
        Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()

        Me.txtTamanio.Text = dr.Cells("Tamano").Value.ToString()
        Me.txtUnidadDeMedida.Text = dr.Cells("IdUnidadDeMedida").Value.ToString()

        Me.txtStock.Text = dr.Cells("Stock").Value.ToString()
        Me.txtMarcaCodigo.Text = dr.Cells("IdMarca").Value.ToString()
        Me.txtRubroCodigo.Text = dr.Cells("IdRubro").Value.ToString()
        Me.txtPrecioCosto.Text = dr.Cells("PrecioCosto").Value.ToString()
        Me.txtPrecioVenta.Text = dr.Cells("PrecioVenta").Value.ToString()

        Dim oMarcas As New Reglas.Marcas
        Dim oRubros As New Reglas.Rubros
        Dim dt As New DataTable

        dt = oMarcas.GetPorCodigo(Int32.Parse(dr.Cells("IdMarca").Value.ToString()))

        Me.txtMarcaNombre.Text = dt.Rows(0)("NombreMarca").ToString()

        dt = oRubros.GetPorCodigo(Int32.Parse(dr.Cells("IdRubro").Value.ToString()))

        Me.txtRubroNombre.Text = dt.Rows(0)("NombreRubro").ToString()

        Me.bscProducto2.Enabled = False
        Me.bscCodigoProducto2.Enabled = False

    End Sub

    Private Sub Mostrar()

        Dim dt As DataTable, drCl As DataRow
        Dim Cont As Integer, Copias As Integer

        Dim ProdActual As Long

        Copias = Integer.Parse(Me.txtCopias.Text)

        'tsbImportar.Enabled = False
        tsbSalir.Enabled = False

        Try

            ProdActual = Long.Parse(Me.txtCodigoInicial.Text) - 1

            Me.Cursor = Cursors.WaitCursor

            dt = Me.CrearDT()

            For Cont = 1 To Copias

                System.Windows.Forms.Application.DoEvents()

                ProdActual = ProdActual + 1

                drCl = dt.NewRow()

                drCl("CodigoProducto") = Me.txtPrefijo.Text & ProdActual.ToString()
                drCl("NombreProducto") = Me.bscProducto2.Text
                drCl("Tamanio") = IIf(Me.txtTamanio.Text <> "", Me.txtTamanio.Text, 0)
                drCl("UnidadDeMedida") = Me.txtUnidadDeMedida.Text

                dt.Rows.Add(drCl)

            Next

            Me.dgvDetalle.DataSource = dt

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Me.Cursor = Cursors.Default
            'tsbImportar.Enabled = True
            tsbSalir.Enabled = True
        End Try

    End Sub

    Private Function CrearDT() As DataTable

        Dim dtTemp As DataTable = New DataTable()

        With dtTemp
            .Columns.Add("CodigoProducto", System.Type.GetType("System.String"))
            .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
            .Columns.Add("Tamanio", System.Type.GetType("System.Decimal"))
            .Columns.Add("UnidadDeMedida", System.Type.GetType("System.String"))
        End With

        Return dtTemp

    End Function

    Private Function Valida() As Boolean

        If Me.bscCodigoProducto2.Text = "" Then
            MessageBox.Show("Falta ingresar el Código de Producto del ORIGEN", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Return False
        End If

        If Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            MessageBox.Show("Se ha cambiado el Código de Producto de ORIGEN", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Return False
        End If

        If Long.Parse(Me.txtCodigoInicial.Text) <= 0 Then
            MessageBox.Show("El Código inicial de Producto es INVALIDO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtCodigoInicial.Focus()
            Return False
        End If

        Return True

    End Function

    Private Sub Actualizar()

        Dim oProductos As Reglas.Productos = New Reglas.Productos()

        Dim dtDatos As DataTable

        dtDatos = DirectCast(Me.dgvDetalle.DataSource, DataTable)

      oProductos.CopiarProductos(Me.bscCodigoProducto2.Text.Trim(), dtDatos, actual.Nombre, Me.chbBorraProducto.Checked, IdFuncion)

        MessageBox.Show("Los Productos se COPIARON con EXITO !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.RefrescarDatosGrilla()

    End Sub

#End Region

End Class