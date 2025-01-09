#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class MRPTareasABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New MRPTareasDetalle(DirectCast(Me.GetEntidad(), Entidades.MRPTarea))
      End If
      Return New MRPTareasDetalle(New Entidades.MRPTarea)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MRPTareas()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim tarea = New Entidades.MRPTarea
      With Me.dgvDatos.ActiveRow
         tarea = New Reglas.MRPTareas().GetUno(Integer.Parse(.Cells("IdTarea").Value.ToString()))
      End With
      Return tarea
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()
         Dim col As Integer = 0
         .Columns(Entidades.MRPTarea.Columnas.IdTarea.ToString()).FormatearColumna("idCódigo", col, 80, HAlign.Right, True)
         .Columns(Entidades.MRPTarea.Columnas.CodigoTarea.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Entidades.MRPTarea.Columnas.Descripcion.ToString()).FormatearColumna("Descripcion", col, 200)
         .Columns("NombreCentroProductor").FormatearColumna("Centro Productor", col, 450, HAlign.Left)
         .Columns(Entidades.MRPTarea.Columnas.Activo.ToString()).FormatearColumna("Activo", col, 60)
      End With
      '-- Agrega Filtros.- ---
      dgvDatos.AgregarFiltroEnLinea({Entidades.MRPTarea.Columnas.CodigoTarea.ToString(), Entidades.MRPTarea.Columnas.Descripcion.ToString()})
   End Sub
#End Region
End Class