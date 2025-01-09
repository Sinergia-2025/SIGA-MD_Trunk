Public Class RenumerarPedidos

   Private _idSucursal As Integer
   Private _idTipoComprobante As String
   Private _letra As String
   Private _centroEmisor As Short
   Private _numeroComprobante As Long

   Public ReadOnly Property IdSucursal As Integer
      Get
         Return _idSucursal
      End Get
   End Property
   Public ReadOnly Property IdTipoComprobante As String
      Get
         Return _idTipoComprobante
      End Get
   End Property
   Public ReadOnly Property Letra As String
      Get
         Return _letra
      End Get
   End Property
   Public ReadOnly Property CentroEmisor As Short
      Get
         Return _centroEmisor
      End Get
   End Property
   Public ReadOnly Property NumeroComprobante As Long
      Get
         Return _numeroComprobante
      End Get
   End Property

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         txtTipoComprobante.Text = idTipoComprobante
         txtLetra.Text = letra
         txtEmisor.Text = centroEmisor.ToString()
         txtNumero.Text = numeroComprobante.ToString()

         txtNumero.Focus()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         If IsNumeric(txtNumero.Text) Then
            Dim nuevoNumero As Long = Long.Parse(txtNumero.Text)
            If _numeroComprobante = nuevoNumero Then
               ShowMessage("No cambió el Número de Pedido")
               txtNumero.Focus()
               Exit Sub
            End If
            _numeroComprobante = nuevoNumero

            DialogResult = Windows.Forms.DialogResult.OK
            Close()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Try
         DialogResult = Windows.Forms.DialogResult.Cancel
         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Public Overloads Function ShowDialog(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DialogResult
      _idTipoComprobante = idTipoComprobante
      _letra = letra
      _centroEmisor = centroEmisor
      _numeroComprobante = numeroComprobante
      Return ShowDialog()
   End Function

   Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
      If e.KeyCode = Keys.Enter Then
         btnAceptar.PerformClick()
      End If
   End Sub
End Class