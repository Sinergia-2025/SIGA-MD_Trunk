Option Explicit On
Option Strict On

Imports Eniac.Reglas

Public Class EnviarProductoF

#Region "Constructores"

   Public Sub New(ByVal notaRecepcion As Eniac.Entidades.RecepcionNotaProveedorF)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Me._entidad = notaRecepcion
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me.BindearControles(Me._entidad)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.RecepcionNotasProveedoresF()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      Dim vacio As String = ""

      If Not Me.bscProveedor.Selecciono Then
         Me.bscProveedor.Focus()
         Return "Debe Ingresar el Proveedor."
      End If

      Return vacio

   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Me.Close()
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Dim oProveedores As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores()
         Dim pub As Eniac.Win.Publicos = New Eniac.Win.Publicos()
         pub.PreparaGrillaProveedores(Me.bscProveedor)
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscProveedor.Text = e.FilaDevuelta.Cells("NombreProveedor").Value.ToString()

            DirectCast(Me._entidad, Eniac.Entidades.RecepcionNotaProveedorF).Proveedor = New Eniac.Reglas.Proveedores().GetUno(Long.Parse(e.FilaDevuelta.Cells("IdProveedor").Value.ToString()))
            Me.txtObservacion.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

End Class