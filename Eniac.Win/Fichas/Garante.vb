Option Explicit On
Option Strict On

Imports Eniac.Reglas
Imports Eniac.Entidades
Imports Eniac.Win

Public Class Garante

#Region "Campos"

   Private _publicos As Eniac.Win.Publicos

   Private _idCliente As Long = 0
   Private _nombreGarante As String = String.Empty
   Private _direccionGarante As String = String.Empty

#End Region

#Region "Propiedades"

   Public Property IdCliente() As Long
      Get
         Return Me._idCliente
      End Get
      Set(ByVal value As Long)
         Me._idCliente = value
      End Set
   End Property

   Public Property NombreGarante() As String

      Get
         Return Me._nombreGarante
      End Get
      Set(ByVal value As String)
         Me._nombreGarante = value
      End Set

   End Property

   Public Property DireccionGarante() As String

      Get
         Return Me._direccionGarante
      End Get
      Set(ByVal value As String)
         Me._direccionGarante = value
      End Set

   End Property

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Eniac.Win.Publicos()

         If Me._idCliente > 0 Then

            Dim oClientes As Clientes = New Clientes
            Dim oCliente As Cliente

            oCliente = oClientes.GetUno(Me._idCliente)

            'Si tiene Garante, asigno dicho cliente, sino es si mismo.
            If oCliente.IdClienteGarante > 0 Then

               Dim oClienteGarante As Cliente
               oClienteGarante = oClientes.GetUno(oCliente.IdClienteGarante)

               Me.bscCodigoCliente.Text = oClienteGarante.CodigoCliente.ToString()
            Else

               Me.bscCodigoCliente.Text = oCliente.CodigoCliente.ToString()

            End If

            Me.bscCodigoCliente.PresionarBoton()

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Dim codigoCliente As Long = -1
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Clientes = New Clientes
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

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

      Me.DialogResult = Windows.Forms.DialogResult.OK

      If Me.bscCodigoCliente.Text.Trim() <> "" Then

         Dim oClientes As Clientes = New Clientes

         'Actualizo siempre, sin importar que no lo haya cambiado (no pregunto)
         oClientes.ActualizarGarante(Me._idCliente, Long.Parse(Me.bscCodigoCliente.Tag.ToString()))

         Me.Close()

      End If

   End Sub

   #End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)
      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("IdCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me._direccionGarante = dr.Cells("Direccion").Value.ToString()
      Me._nombreGarante = dr.Cells("NombreCliente").Value.ToString()
   End Sub

   Private Sub LimpiarCampos()
      Me.bscCodigoCliente.Text = ""
      Me.bscCliente.Text = ""
      Me.bscCliente.Focus()
   End Sub

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

#End Region

End Class