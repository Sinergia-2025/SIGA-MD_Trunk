#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class MRPCategoriasEmpleadosABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New MRPCategoriasEmpleadosDetalle(DirectCast(Me.GetEntidad(), Entidades.MRPCategoriaEmpleado))
      End If
      Return New MRPCategoriasEmpleadosDetalle(New Entidades.MRPCategoriaEmpleado)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MRPCategoriasEmpleados()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim CategoriaEmpleado = New Entidades.MRPCategoriaEmpleado
      With Me.dgvDatos.ActiveRow
         CategoriaEmpleado = New Reglas.MRPCategoriasEmpleados().GetUno(Integer.Parse(.Cells("IdCategoriaEmpleado").Value.ToString()))
      End With
      Return CategoriaEmpleado
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.MRPCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString()).FormatearColumna("idCódigo", col, 80, HAlign.Right, True)
         .Columns(Entidades.MRPCategoriaEmpleado.Columnas.CodigoCategoriaEmpleado.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Entidades.MRPCategoriaEmpleado.Columnas.Descripcion.ToString()).FormatearColumna("Descripcion", col, 400)
         .Columns(Entidades.MRPCategoriaEmpleado.Columnas.ValorHoraProduccion.ToString()).FormatearColumna("Valor Hora", col, 80, HAlign.Right, , "N2")
         .Columns(Entidades.MRPCategoriaEmpleado.Columnas.Activo.ToString()).FormatearColumna("Activo", col, 60)
      End With
   End Sub
#End Region

End Class