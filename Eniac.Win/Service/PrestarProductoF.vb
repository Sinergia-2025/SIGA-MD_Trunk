Option Explicit On
Option Strict On

Imports Eniac
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class PrestarProductoF

   Public Sub New(ByVal nota As Eniac.Entidades.RecepcionNotaF)
      InitializeComponent()

      Me._entidad = nota
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try

         Me.StateForm = Eniac.Win.StateForm.Actualizar

         Me.BindearControles(Me._entidad)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.RecepcionNotasF()
   End Function

   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      Try
         Dim pub As Eniac.Win.Publicos = New Eniac.Win.Publicos()
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         pub.PreparaGrillaProductos2(Me.bscCodigoProducto)
         Me.bscCodigoProducto.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscProducto.Text = e.FilaDevuelta.Cells("NombreProducto").Value.ToString()
            Me.bscCodigoProducto.Text = e.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim()
            DirectCast(Me._entidad, Eniac.Entidades.RecepcionNotaF).ProductoPrestado = New Eniac.Reglas.Productos().GetUno(e.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim())
            Me.txtCantidadProductos.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto_BuscadorClick() Handles bscProducto.BuscadorClick
      Try
         Dim pub As Eniac.Win.Publicos = New Eniac.Win.Publicos()
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos()
         pub.PreparaGrillaProductos2(Me.bscProducto)
         Me.bscProducto.Datos = oProductos.GetPorNombre(Me.bscProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscProducto.Text = e.FilaDevuelta.Cells("NombreProducto").Value.ToString()
            Me.bscCodigoProducto.Text = e.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim()
            DirectCast(Me._entidad, Eniac.Entidades.RecepcionNotaF).ProductoPrestado = New Eniac.Reglas.Productos().GetUno(e.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim())
            Me.txtCantidadProductos.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class