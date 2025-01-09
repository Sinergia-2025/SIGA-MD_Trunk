Public Class CategoriasProveedoresDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.CategoriaProveedor)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()

         If Publicos.TieneModuloContabilidad Then
            Dim idCuenta As Long = Reglas.ContabilidadPublicos.ContabilidadCuentaCompras
            If idCuenta > 0 Then
               UcCuentas1.Cuenta = New Reglas.ContabilidadCuentas().GetUna(idCuenta)
            End If
         Else
            UcCuentas1.Visible = False
         End If

      Else
         If Publicos.TieneModuloContabilidad Then
            UcCuentas1.Cuenta = DirectCast(_entidad, Entidades.CategoriaProveedor).CuentaContable
         Else
            grpContabilidad.Visible = False
         End If
      End If


   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.CategoriasProveedores
   End Function

   Protected Overrides Function ValidarDetalle() As String

      Dim vacio As String = ""

      If Publicos.TieneModuloContabilidad Then
         If UcCuentas1.Cuenta Is Nothing OrElse UcCuentas1.Cuenta.IdCuenta = 0 Then
            UcCuentas1.Focus()
            Return "Debe indicar una cuenta contable para la categoría."
         End If
      End If

      Return vacio

   End Function

   Protected Overrides Sub Aceptar()

      If Publicos.TieneModuloContabilidad Then
         DirectCast(_entidad, Entidades.CategoriaProveedor).CuentaContable = UcCuentas1.Cuenta
      Else
         DirectCast(_entidad, Entidades.CategoriaProveedor).CuentaContable = Nothing
      End If

      MyBase.Aceptar()
   End Sub

   'Protected Overrides Sub LimpiarControles()
   '   MyBase.LimpiarControles()
   '   Me.txtDescuentoRecargo.Text = "0.00"
   'End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtCategoria.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim oCateg As Reglas.CategoriasProveedores = New Reglas.CategoriasProveedores()
      Me.txtCategoria.Text = (oCateg.GetIdMaximo() + 1).ToString()
   End Sub

#End Region

End Class
