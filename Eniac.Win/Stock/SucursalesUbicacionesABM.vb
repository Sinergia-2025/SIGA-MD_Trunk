Public Class SucursalesUbicacionesABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SucursalesUbicacionesDetalle(DirectCast(GetEntidad(), Entidades.SucursalUbicacion))
      End If
      Return New SucursalesUbicacionesDetalle(New Entidades.SucursalUbicacion())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.SucursalesUbicaciones()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then
         Return New Reglas.SucursalesUbicaciones().GetUno(dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdSucursal"), dr.Field(Of Integer)("IdUbicacion"))
      End If
      Return Nothing
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col = 0I
         .Columns(Entidades.SucursalUbicacion.Columnas.IdSucursal.ToString()).FormatearColumna("Sucursal", col, 80, HAlign.Right)
         .Columns(Entidades.SucursalUbicacion.Columnas.NombreSucursal.ToString()).FormatearColumna("Nombre Sucursal", col, 200)
         .Columns(Entidades.SucursalUbicacion.Columnas.CodigoDeposito.ToString()).FormatearColumna("Depósito", col, 80, HAlign.Left)
         .Columns(Entidades.SucursalUbicacion.Columnas.NombreDeposito.ToString()).FormatearColumna("Nombre Depósito", col, 200)
         .Columns(Entidades.SucursalUbicacion.Columnas.CodigoUbicacion.ToString()).FormatearColumna("Ubicación", col, 80, HAlign.Left)
         .Columns(Entidades.SucursalUbicacion.Columnas.NombreUbicacion.ToString()).FormatearColumna("Nombre Ubicación", col, 200)
         .Columns(Entidades.SucursalUbicacion.Columnas.NombreEstado.ToString()).FormatearColumna("Nombre Estado", col, 200)
         .Columns(Entidades.SucursalUbicacion.Columnas.Activo.ToString()).FormatearColumna("Activo", col, 80)

         .Columns(Entidades.SucursalUbicacion.Columnas.EstadoUbicacion.ToString()).Hidden = True
         .Columns(Entidades.SucursalUbicacion.Columnas.IdDeposito.ToString()).Hidden = True
         .Columns(Entidades.SucursalUbicacion.Columnas.IdUbicacion.ToString()).Hidden = True

         .Columns(Entidades.SucursalUbicacion.Columnas.SucursalAsociada.ToString()).Hidden = True
         .Columns(Entidades.SucursalUbicacion.Columnas.DepositoAsociado.ToString()).Hidden = True
         .Columns(Entidades.SucursalUbicacion.Columnas.UbicacionAsociada.ToString()).Hidden = True

      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.SucursalUbicacion.Columnas.NombreSucursal.ToString(),
                                     Entidades.SucursalUbicacion.Columnas.NombreDeposito.ToString(),
                                     Entidades.SucursalUbicacion.Columnas.NombreUbicacion.ToString(),
                                     Entidades.SucursalUbicacion.Columnas.NombreEstado.ToString()})
   End Sub

#End Region
End Class