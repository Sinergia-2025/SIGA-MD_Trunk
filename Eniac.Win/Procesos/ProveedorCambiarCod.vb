Public Class ProveedorCambiarCod

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

#End Region

#Region "Eventos"

   Private Sub bscNroDoc_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick

      Dim NroDoc As Long = -1

      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            NroDoc = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         'Me.bscNroDoc.Datos = oProveedores.GetFiltradoPorTipoYNroDocumento(Me.cmbTipoDoc.Text, NroDoc)
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigoTodos(NroDoc)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscNroDoc_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNroDocRec_BuscadorClick() Handles bscCodigoProveedorRec.BuscadorClick

      Dim NroDoc As Long = -1

      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedorRec)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedorRec.Text.Trim.Length > 0 Then
            NroDoc = Long.Parse(Me.bscCodigoProveedorRec.Text.Trim())
         End If
         'Me.bscNroDocRec.Datos = oProveedores.GetFiltradoPorTipoYNroDocumento(Me.cmbTipoDocRec.Text, NroDoc)
         Me.bscCodigoProveedorRec.Datos = oProveedores.GetFiltradoPorCodigoTodos(NroDoc)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscNroDocRec_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedorRec.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedorRec(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbActualizar.Click

      Try
         If Me.Valida() Then

            Dim men As String
            men = "Usted va a transferir todas las operaciones cambiando el Código del Proveedor '" & Me.bscProveedor.Text & "'"
            men = men & " desde " & Convert.ToChar(Keys.Enter) & Convert.ToChar(Keys.Enter)
            men = men & Me.bscCodigoProveedor.Text
            men = men & "   a   "
            men = men & Me.bscCodigoProveedorRec.Text & Convert.ToChar(Keys.Enter) & Convert.ToChar(Keys.Enter)
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

   Private Sub cmbTipoDoc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
      Me.bscCodigoProveedor.Selecciono = False
   End Sub

   Private Sub cmbTipoDocRec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
      Me.bscCodigoProveedorRec.Selecciono = False
   End Sub

#End Region

#Region "Metodos"

   Private Function Valida() As Boolean

      If Me.bscCodigoProveedor.Text = "" Then
         MessageBox.Show("Falta ingresar el NUMERO de Documento del ORIGEN", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoProveedor.Focus()
         Return False
      End If

      If Me.bscCodigoProveedorRec.Text = "" Then
         MessageBox.Show("Falta ingresar el NUMERO de Documento del DESTINO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoProveedorRec.Focus()
         Return False
      End If

      'If Me.bscProveedor.Text = "" Then
      '   MessageBox.Show("Falta ingresar el Proveedor ORIGEN", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.bscProveedor.Focus()
      '   Return False
      'End If

      If Not Me.bscCodigoProveedor.Selecciono And Not Me.bscProveedor.Selecciono Then
         MessageBox.Show("Se ha cambiado el nro. de documento de ORIGEN", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoProveedor.Focus()
         Return False
      End If

      Dim oProv As Reglas.Proveedores = New Reglas.Proveedores()
      'If oProv.GetFiltradoPorTipoYNroDocumento(Me.cmbTipoDocRec.Text, Long.Parse(Me.bscNroDocRec.Text), False).Rows.Count > 0 Then
      If oProv.GetFiltradoPorCodigoTodos(Long.Parse(Me.bscCodigoProveedorRec.Text), False).Rows.Count > 0 Then
         MessageBox.Show("El Proveedor DESTINO existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      Return True

   End Function

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.txtDireccion.Text = dr.Cells("DireccionProveedor").Value.ToString()
      Me.txtLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.txtTelefono.Text = dr.Cells("TelefonoProveedor").Value.ToString()

      Me.CargarOperaciones()

      Me.bscCodigoProveedorRec.Focus()

   End Sub

   Private Sub CargarOperaciones()

      Dim oCompras As Reglas.Compras = New Reglas.Compras()

      Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

      Try

         dtDetalle = oCompras.GetPorSucursalCliente(Eniac.Entidades.Usuario.Actual.Sucursal.Id, Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), Now.AddYears(-1), Now.AddDays(1))

         dt = Me.CrearDT()


         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
            drCl("Letra") = dr("Letra").ToString()
            drCl("NumeroComprobante") = Strings.Format(dr("CentroEmisor"), "0000") & "-" & Strings.Format(dr("NumeroComprobante"), "00000000")
            drCl("Fecha") = Strings.Format(dr("Fecha"), "dd/MM/yyyy HH:mm")
            drCl("Neto210") = Decimal.Parse(dr("Neto210").ToString()).ToString("##,##0.00")
            drCl("DescuentoRecargo") = Decimal.Parse(dr("DescuentoRecargo").ToString()).ToString("##,##0.00")
            drCl("Iva210") = Decimal.Parse(dr("Iva210").ToString()).ToString("##,##0.00")
            drCl("Iva105") = Decimal.Parse(dr("Iva105").ToString()).ToString("##,##0.00")
            drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotal").ToString()).ToString("##,##0.00")
            drCl("Observacion") = dr("Observacion").ToString

            dt.Rows.Add(drCl)

         Next

         Me.dgvOperaciones.DataSource = dt

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try


   End Sub

   Private Function CrearDT() As DataTable
      Dim dtTemp As DataTable = New DataTable()
      With dtTemp
         .Columns.Add("IdTipoComprobante")
         .Columns.Add("Letra")
         .Columns.Add("NumeroComprobante")
         .Columns.Add("Fecha")
         .Columns.Add("Neto210")
         .Columns.Add("DescuentoRecargo")
         .Columns.Add("Iva210")
         .Columns.Add("Iva105")
         .Columns.Add("ImporteTotal")
         .Columns.Add("Observacion")
      End With
      Return dtTemp
   End Function

   Private Sub CargarDatosProveedorRec(ByVal dr As DataGridViewRow)
      Me.bscCodigoProveedorRec.Text = dr.Cells("CodigoProveedor").Value.ToString()
   End Sub

   Private Sub Actualizar()

      Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores()

      'oProveedores.CambiarCodigo(Me.bscNroDoc.Text, Me.bscNroDocRec.Text)

      MessageBox.Show("Los datos se actualizaron con exito", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Me.LimpiarCampos()

   End Sub

   Private Sub LimpiarCampos()
      Me.bscCodigoProveedor.Text = ""
      Me.bscCodigoProveedorRec.Text = ""
      Me.bscProveedor.Text = ""

      If Not Me.dgvOperaciones.DataSource Is Nothing Then
         DirectCast(Me.dgvOperaciones.DataSource, DataTable).Rows.Clear()
      End If

      Me.bscProveedor.Focus()
   End Sub

#End Region

End Class