#Region "Imports"
Imports Microsoft.Reporting.WinForms
Imports Infragistics.Win.UltraWinGrid
#End Region
Public Class MovilRutasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
      Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(dgvDatos, {Entidades.MovilRuta.Columnas.NombreRuta.ToString()})
   End Sub

   Protected Overrides Function ConfirmarBorrado() As DialogResult
      Dim idRuta As Integer = Int32.Parse(Me.dgvDatos.ActiveCell.Row.Cells(Entidades.MovilRuta.Columnas.IdRuta.ToString()).Value.ToString())
      Dim count As Integer = New Reglas.MovilRutasClientes().GetPorRuta(idRuta).Rows.Count
      If count > 0 Then
         Return ShowPregunta(String.Format("La ruta que desea eliminar aún tiene {0} clientes asociados. ¿Está seguro de eliminar la misma de todas maneras?", count))
      End If

      Return MyBase.ConfirmarBorrado()
   End Function


   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New MovilRutasDetalle(DirectCast(Me.GetEntidad(), Entidades.MovilRuta))
      End If
      Return New MovilRutasDetalle(New Entidades.MovilRuta())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MovilRutas()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim Ruta As Entidades.MovilRuta = New Entidades.MovilRuta()
      With Me.dgvDatos.ActiveCell.Row
         Ruta = DirectCast(GetReglas(), Reglas.MovilRutas).GetUno(Int32.Parse(.Cells(Entidades.MovilRuta.Columnas.IdRuta.ToString()).Value.ToString()))
      End With
      Return Ruta
   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next
         Dim col As Integer = 0

         .Columns(Entidades.MovilRuta.Columnas.IdRuta.ToString()).FormatearColumna("Código", col, 70, HAlign.Right)
         .Columns(Entidades.MovilRuta.Columnas.NombreRuta.ToString()).FormatearColumna("Nombre Ruta", col, 200)
         .Columns(Entidades.MovilRuta.Columnas.Activa.ToString()).FormatearColumna("Hab.", col, 50, HAlign.Center)
         .Columns(Entidades.MovilRuta.Columnas.IdDispositivoPorDefecto.ToString()).FormatearColumna("Dispositivo", col, 150)

         .Columns("NombreVendedor").FormatearColumna("Vendedor/Cobrador", col, 150)
         .Columns(Entidades.Transportista.Columnas.NombreTransportista.ToString()).FormatearColumna("Transportista", col, 150)
         .Columns(Entidades.MovilRuta.Columnas.PuedeModificarPrecio.ToString()).FormatearColumna("Permite Modificar Precio", col, 80)
         .Columns(Entidades.MovilRuta.Columnas.PermiteIngresarPorcentajeDescuentos.ToString()).FormatearColumna("Permite Desc./Rec.", col, 80)
         .Columns(Entidades.MovilRuta.Columnas.PrecioConImpuestos.ToString()).FormatearColumna("Precios Con Impuestos", col, 80)

         .Columns(Entidades.MovilRuta.Columnas.PermiteCobroParcial.ToString()).FormatearColumna("Permite Cobro Parcial", col, 80)
         .Columns(Entidades.MovilRuta.Columnas.ConfiguraClienteSegun.ToString()).FormatearColumna("Configura Clientes Según", col, 100)
         .Columns(Entidades.MovilRuta.Columnas.DescuentoMax.ToString()).FormatearColumna("Descuento Maximo", col, 50, HAlign.Right,, "N2")
         .Columns(Entidades.MovilRuta.Columnas.RecargaMax.ToString()).FormatearColumna("Recarga Maximo", col, 50, HAlign.Right,, "N2")
      End With
   End Sub

#End Region

End Class