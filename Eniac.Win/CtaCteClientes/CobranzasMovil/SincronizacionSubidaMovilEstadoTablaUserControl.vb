Option Strict On
Option Explicit On
Public Class SincronizacionSubidaMovilEstadoTablaUserControl
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub

   Public Sub SetAvance(tabla As String, estado As String, totalRegistrosSubidos As Long)
      lblTabla.Text = tabla
      lblEstado.Text = estado
      lblCantidad.Text = totalRegistrosSubidos.ToString("N0")
   End Sub

End Class
