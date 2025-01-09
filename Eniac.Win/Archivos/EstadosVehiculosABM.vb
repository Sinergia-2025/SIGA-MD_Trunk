Public Class EstadosVehiculosABM

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New EstadosVehiculosDetalle(DirectCast(GetEntidad(), Entidades.EstadoVehiculo))
      End If
      Return New EstadosVehiculosDetalle(New Entidades.EstadoVehiculo())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.EstadosVehiculos()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      With dgvDatos.ActiveRow
         Return New Reglas.EstadosVehiculos().GetUno(Integer.Parse(.Cells("IdEstadoVehiculo").Value.ToString()))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col = 0I
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Entidades.EstadoVehiculo.Columnas.IdEstadoVehiculo.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Entidades.EstadoVehiculo.Columnas.NombreEstadoVehiculo.ToString()).FormatearColumna("Nombre", col, 300)
         .Columns(Entidades.EstadoVehiculo.Columnas.Predeterminado.ToString()).FormatearColumna("Predeterminado", col, 60, HAlign.Center)
         .Columns(Entidades.EstadoVehiculo.Columnas.EnStock.ToString()).FormatearColumna("En Stock", col, 60, HAlign.Center)
         .Columns(Entidades.EstadoVehiculo.Columnas.SolicitaFecha.ToString()).FormatearColumna("Solicita Fecha", col, 60, HAlign.Center)
         .Columns(Entidades.EstadoVehiculo.Columnas.IdEstadoVehiculoLuegoVencer.ToString()).FormatearColumna("Código Luego Vencer", col, 80, HAlign.Right, hidden:=True)
         .Columns("NombreEstadoVehiculoLuevoVencer").FormatearColumna("Estado Luego Vencer", col, 300)
      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.EstadoVehiculo.Columnas.NombreEstadoVehiculo.ToString(), "NombreEstadoVehiculoLuevoVencer"})
   End Sub
#End Region

End Class