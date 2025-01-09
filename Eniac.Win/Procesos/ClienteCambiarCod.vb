Option Strict Off
Public Class ClienteCambiarCod

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me._publicos.CargaComboTipoDocumento(Me.cmbTipoDoc)
         Me._publicos.CargaComboTipoDocumento(Me.cmbTipoDocRec)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Function Valida() As Boolean

      If Me.cmbTipoDoc.SelectedIndex = -1 Then
         MessageBox.Show("Falta ingresar el TIPO de Documento del ORIGEN", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbTipoDoc.Focus()
         Return False
      End If

      If Me.cmbTipoDocRec.SelectedIndex = -1 Then
         MessageBox.Show("Falta ingresar el TIPO de Documento del DESTINO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbTipoDoc.Focus()
         Return False
      End If

      If Me.bscCodigoCliente.Text = "" Then
         MessageBox.Show("Falta ingresar el NUMERO de Documento del ORIGEN", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Return False
      End If

      If Me.bscNroDocRec.Text = "" Then
         MessageBox.Show("Falta ingresar el NUMERO de Documento del DESTINO", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscNroDocRec.Focus()
         Return False
      End If

      'If Me.bscCliente.Text = "" Then
      '    MessageBox.Show("Falta ingresar el Cliente ORIGEN", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '    Me.bscCliente.Focus()
      '    Return False
      'End If

      If Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
         MessageBox.Show("Se ha cambiado el nro. de documento de ORIGEN", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Return False
      End If

      Dim oCli As Reglas.Clientes = New Reglas.Clientes()
      If oCli.GetFiltradoPorCodigoTodos(Me.bscNroDocRec.Text, False).Rows.Count > 0 Then
         MessageBox.Show("El cliente DESTINO existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End If

      Return True

   End Function

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.cmbTipoDoc.Text = dr.Cells("TipoDocumento").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("NroDocumento").Value.ToString()
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.txtDireccion.Text = dr.Cells("Direccion").Value.ToString()
      Me.txtLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.txtTelefono.Text = dr.Cells("Telefono").Value.ToString()

      Me.CargarOperaciones()

      Me.bscNroDocRec.Focus()

   End Sub

   Private Sub CargarOperaciones()

      'Dim oReglas As Reglas.Fichas = New Reglas.Fichas()
      'Me.dgvOperaciones.DataSource = oReglas.GetTodas(Me.cmbTipoDoc.Text, Me.bscCodigoCliente.Text, Eniac.Entidades.Usuario.Actual.Sucursal.Id)

      Dim oVentas As Reglas.Ventas = New Reglas.Ventas()

      Dim dtDetalle As DataTable, dt As DataTable, drCl As DataRow

      Try

         dtDetalle = oVentas.GetPorSucursalCliente(Eniac.Entidades.Usuario.Actual.Sucursal.Id, Me.bscCodigoCliente.Text, Now.AddYears(-1), Now.AddDays(1))

         dt = Me.CrearDT()


         For Each dr As DataRow In dtDetalle.Rows

            drCl = dt.NewRow()

            drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString
            drCl("Letra") = dr("Letra").ToString
            drCl("NumeroComprobante") = Strings.Format(dr("CentroEmisor"), "0000") & "-" & Strings.Format(dr("NumeroComprobante"), "00000000")
            drCl("Fecha") = Strings.Format(dr("Fecha"), "dd/MM/yyyy HH:mm")
            drCl("SubTotal") = String.Format(dr("SubTotal"), "##,##0.00")
            drCl("TotalImpuestos") = String.Format(dr("TotalImpuestos"), "##,##0.00")
            drCl("ImporteTotal") = String.Format(dr("ImporteTotal"), "##,##0.00")
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
         .Columns.Add("SubTotal")
         .Columns.Add("TotalImpuestos")
         .Columns.Add("ImporteTotal")
         .Columns.Add("Observacion")
      End With
      Return dtTemp
   End Function

   Private Sub CargarDatosClienteRec(ByVal dr As DataGridViewRow)
      Me.bscNroDocRec.Text = dr.Cells("NroDocumento").Value.ToString()
      Me.cmbTipoDocRec.Text = dr.Cells("TipoDocumento").Value.ToString()
   End Sub

   Private Sub Actualizar()

      Dim oClientes As Reglas.Clientes = New Reglas.Clientes()

      'oClientes.CambiarCodigo(Me.cmbTipoDoc.Text, Me.bscCodigoCliente.Text, Me.cmbTipoDocRec.Text, Me.bscNroDocRec.Text)

      MessageBox.Show("Los datos se Actualizaron con EXITO !!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Me.LimpiarCampos()

   End Sub

   Private Sub LimpiarCampos()
      Me.cmbTipoDoc.Text = Reglas.Publicos.TipoDocumentoCliente()  '"DNI"
      Me.cmbTipoDocRec.Text = Reglas.Publicos.TipoDocumentoCliente()  '"DNI"
      Me.bscCodigoCliente.Text = ""
      Me.bscNroDocRec.Text = ""
      Me.bscCliente.Text = ""

      If Not Me.dgvOperaciones.DataSource Is Nothing Then
         DirectCast(Me.dgvOperaciones.DataSource, DataTable).Rows.Clear()
      End If

      Me.bscCliente.Focus()
   End Sub



#End Region

#Region "Eventos"

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNroDoc_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigoTodos(Me.bscCodigoCliente.Text.Trim())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscNroDoc_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscNroDocRec_BuscadorClick() Handles bscNroDocRec.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes(Me.bscNroDocRec)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscNroDocRec.Datos = oClientes.GetFiltradoPorCodigoTodos(Me.bscNroDocRec.Text.Trim(), False)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscNroDocRec_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNroDocRec.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteRec(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbActualizar.Click

      Try
         If Me.Valida() Then
            Dim men As String

            men = "Usted va a transferir todas las operaciones cambiando el Código del Cliente '" & Me.bscCliente.Text & "'"
            men = men & " desde " & Convert.ToChar(Keys.Enter) & Convert.ToChar(Keys.Enter)
            men = men & Me.cmbTipoDoc.Text & " - " & Me.bscCodigoCliente.Text
            men = men & "   a   "
            men = men & Me.cmbTipoDocRec.Text & " - " & Me.bscNroDocRec.Text & Convert.ToChar(Keys.Enter) & Convert.ToChar(Keys.Enter)
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

   Private Sub cmbTipoDoc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoDoc.SelectedIndexChanged
      Me.bscCodigoCliente.Selecciono = False
   End Sub

   Private Sub cmbTipoDocRec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoDocRec.SelectedIndexChanged
      Me.bscNroDocRec.Selecciono = False
   End Sub

#End Region

End Class