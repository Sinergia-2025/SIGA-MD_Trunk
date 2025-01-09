Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class ucNovedadesProveedores

#Region "Busqueda"
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick

      Dim codigoProveedor As Long = -1
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString().Trim()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()

      Me.txtCategoria.Text = dr.Cells("NombreCategoria").Value.ToString()
      Me.txtTelefonos.Text = Strings.Trim(dr.Cells("TelefonoProveedor").Value.ToString() & " " & dr.Cells("FaxProveedor").Value.ToString())
      Me.txtCorreo.Text = dr.Cells("CorreoElectronico").Value.ToString()

      OnSelectedChanged(Nothing)

   End Sub
#End Region

   Public Property IdProveedor() As Long
      Get
         Dim result As Long = 0
         If bscCodigoProveedor.Tag IsNot Nothing AndAlso IsNumeric(bscCodigoProveedor.Tag) Then
            result = Convert.ToInt64(bscCodigoProveedor.Tag)
         End If
         Return result
      End Get
      Set(ByVal value As Long)
         Try
            If value > 0 Then
               bscCodigoProveedor.Text = New Reglas.Proveedores().GetUno(value).CodigoProveedor.ToString()
               bscCodigoProveedor.PresionarBoton()
            Else
               bscCodigoProveedor.Text = String.Empty
               bscProveedor.Text = String.Empty
            End If
            OnSelectedChanged(Nothing)
         Catch ex As Exception
            bscCodigoProveedor.Text = String.Empty
            bscProveedor.Text = String.Empty
            OnSelectedChanged(Nothing)
            MessageBox.Show(String.Format("No se pudo recuperar el Proveedor: {0}", ex.Message), FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End Set
   End Property

   Private Sub llbProveedor_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbProveedor.LinkClicked
      Try

         Dim PantProveedor As ProveedoresDetalle

         If Me.bscCodigoProveedor.Selecciono Or Me.bscProveedor.Selecciono Then
            Dim Clie As Eniac.Entidades.Proveedor = New Eniac.Entidades.Proveedor
            Dim blnIncluirFoto As Boolean = True
            Clie = New Eniac.Reglas.Proveedores().GetUno(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()), blnIncluirFoto)
            Clie.Usuario = actual.Nombre
            PantProveedor = New ProveedoresDetalle(Clie)
            PantProveedor.CierraAutomaticamente = True
            PantProveedor.StateForm = Eniac.Win.StateForm.Actualizar
            'Else
            '   PantProveedor = New ProveedoresDetalle(New Entidades.Proveedor())
            '   PantProveedor.CierraAutomaticamente = True
            '   PantProveedor.StateForm = Eniac.Win.StateForm.Insertar

            If PantProveedor.ShowDialog() = Windows.Forms.DialogResult.OK Then
               Me.bscCodigoProveedor.Text = PantProveedor.txtCodigoProveedor.Text
               Me.bscCodigoProveedor.PresionarBoton()
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

End Class
