#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class MRPCentrosProductoresABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New MRPCentrosProductoresDetalle(DirectCast(Me.GetEntidad(), Entidades.MRPCentroProductor))
      End If
      Return New MRPCentrosProductoresDetalle(New Entidades.MRPCentroProductor)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MRPCentrosProductores()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim CentroProductor = New Entidades.MRPCentroProductor
      With Me.dgvDatos.ActiveRow
         CentroProductor = New Reglas.MRPCentrosProductores().GetUno(Integer.Parse(.Cells("IdCentroProductor").Value.ToString()))
      End With
      Return CentroProductor
   End Function

   Protected Overrides Sub FormatearGrilla()
      Dim pos = 0I
      With Me.dgvDatos.DisplayLayout.Bands(0)
         For Each col As UltraGridColumn In .Columns
            col.Hidden = True
         Next

         Grilla.AgregarFiltroEnLinea(dgvDatos, {"CodigoCentroProductor", "Descripcion", "DescripSeccion", "ClaseCentroProductor"})

         .Columns(Entidades.MRPCentroProductor.Columnas.IdCentroProductor.ToString()).FormatearColumna("idCódigo", pos, 80, HAlign.Right, True)
         .Columns(Entidades.MRPCentroProductor.Columnas.CodigoCentroProductor.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.MRPCentroProductor.Columnas.Descripcion.ToString()).FormatearColumna("Descripcion", pos, 200)
         .Columns("DescripSeccion").FormatearColumna("Seccion", pos, 200)
         .Columns(Entidades.MRPCentroProductor.Columnas.ClaseCentroProductor.ToString()).FormatearColumna("Clase", pos, 80, HAlign.Center)
         .Columns("NombreProveedor").FormatearColumna("Proveedor", pos, 200)
         .Columns(Entidades.MRPCentroProductor.Columnas.Dotacion.ToString()).FormatearColumna("Dotacion", pos, 80, HAlign.Right)
         .Columns(Entidades.MRPCentroProductor.Columnas.Activo.ToString()).FormatearColumna("Activo", pos, 60)
         .Columns("DescripNorma").FormatearColumna("Norma Fabricacion", pos, 200)
         .Columns(Entidades.MRPCentroProductor.Columnas.MantenimientoAutonomo.ToString()).FormatearColumna("Mantenimiento Autonomo", pos, 100)
         .Columns(Entidades.MRPCentroProductor.Columnas.CantidadControles.ToString()).FormatearColumna("Cant.Controles", pos, 80, HAlign.Right)
      End With
   End Sub
#End Region
End Class