Option Strict On
Option Explicit On
Public Class MovimientosDeComprasParametros

   Public Property DecimalesAMostrarEnTotalXProducto As Integer
   Public Property DecimalesAMostrarEnPrecio As Integer
   Public Property DecimalesRedondeoEnPrecio As Integer
   Public Property DecimalesEnCantidad As Integer
   Public Property DecimalesMostrarEnCantidad As Integer
   Public Property DecimalesEnTotales As Integer
   Public Property PermiteModificarSubtotal As Boolean

   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(decimalesAMostrarEnTotalXProducto As Integer,
                  decimalesAMostrarEnPrecio As Integer,
                  decimalesRedondeoEnPrecio As Integer,
                  decimalesEnCantidad As Integer,
                  decimalesMostrarEnCantidad As Integer,
                  decimalesEnTotales As Integer,
                  permiteModificarSubtotal As Boolean)
      Me.New()

      Me.DecimalesAMostrarEnTotalXProducto = decimalesAMostrarEnTotalXProducto
      Me.DecimalesAMostrarEnPrecio = decimalesAMostrarEnPrecio
      Me.DecimalesRedondeoEnPrecio = decimalesRedondeoEnPrecio
      Me.DecimalesEnCantidad = decimalesEnCantidad
      Me.DecimalesMostrarEnCantidad = decimalesMostrarEnCantidad
      Me.DecimalesEnTotales = decimalesEnTotales
      Me.PermiteModificarSubtotal = permiteModificarSubtotal
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      txtComprasDecimalesEnTotal.Text = DecimalesEnTotales.ToString()
      txtComprasDecimalesEnTotalXProducto.Text = DecimalesAMostrarEnTotalXProducto.ToString()
      txtComprasDecimalesMostrarEnCantidad.Text = DecimalesMostrarEnCantidad.ToString()
      txtComprasDecimalesMostrarEnItems.Text = DecimalesAMostrarEnPrecio.ToString()
      txtComprasDecimalesRedondeoEnCantidad.Text = DecimalesEnCantidad.ToString()
      txtComprasDecimalesRedondeoEnPrecio.Text = DecimalesRedondeoEnPrecio.ToString()
      chbPermiteModificarSubtotal.Checked = PermiteModificarSubtotal

   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try

         DecimalesEnTotales = Integer.Parse(txtComprasDecimalesEnTotal.Text)
         DecimalesAMostrarEnTotalXProducto = Integer.Parse(txtComprasDecimalesEnTotalXProducto.Text)
         DecimalesMostrarEnCantidad = Integer.Parse(txtComprasDecimalesMostrarEnCantidad.Text)
         DecimalesAMostrarEnPrecio = Integer.Parse(txtComprasDecimalesMostrarEnItems.Text)
         DecimalesEnCantidad = Integer.Parse(txtComprasDecimalesRedondeoEnCantidad.Text)
         DecimalesRedondeoEnPrecio = Integer.Parse(txtComprasDecimalesRedondeoEnPrecio.Text)
         PermiteModificarSubtotal = chbPermiteModificarSubtotal.Checked

         DialogResult = Windows.Forms.DialogResult.OK
         Close()

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class
