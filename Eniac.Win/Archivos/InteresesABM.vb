Public Class InteresesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New InteresesDetalle(DirectCast(GetEntidad(), Entidades.Interes))
      End If
      Return New InteresesDetalle(New Entidades.Interes())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.InteresesDias()
   End Function

   Protected Overrides Sub Borrar()
      Try
         If dgvDatos.ActiveCell Is Nothing Then
            If dgvDatos.ActiveRow IsNot Nothing Then
               dgvDatos.ActiveCell = dgvDatos.ActiveRow.Cells(0)
            End If
         End If
         If dgvDatos.ActiveCell IsNot Nothing Then
            If ShowPregunta("¿Está seguro de eliminar el registro seleccionado?") = Windows.Forms.DialogResult.Yes Then
               Dim cl = New Reglas.Intereses()
               _entidad = GetEntidad()
               cl.Borrar(_entidad)
               RefreshGrid()
            End If
         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            ShowMessage("El registro NO se puede eliminar porque esta siendo utilizado.")
         Else
            ShowMessage(ex.Message)
         End If
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      Return New Reglas.Intereses().GetUno(dr.Field(Of Integer)("IdInteresMaster"))
   End Function
   Protected Overrides Sub FormatearGrilla()

      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns(Entidades.InteresDias.Columnas.IdInteres.ToString()).FormatearColumna("IdInteres", pos, 70, , True)

         .Columns("IdInteresMaster").FormatearColumna("Cod.", pos, 50, HAlign.Right)
         .Columns(Entidades.Interes.Columnas.NombreInteres.ToString()).FormatearColumna("Nombre Interés", pos, 180)

         .Columns(Entidades.InteresDias.Columnas.DiasDesde.ToString()).FormatearColumna("Desde", pos, 60, HAlign.Center)
         .Columns(Entidades.InteresDias.Columnas.DiasHasta.ToString()).FormatearColumna("Hasta", pos, 60, HAlign.Center)
         .Columns(Entidades.InteresDias.Columnas.Interes.ToString()).FormatearColumna("Interes", pos, 60, HAlign.Right, , "N2")

         .Columns(Entidades.Interes.Columnas.MetodoParaDeterminarRango.ToString()).FormatearColumna("Toma rango como", pos, 180)
         .Columns(Entidades.Interes.Columnas.AdicionalProporcinalDias.ToString()).FormatearColumna("Adic. Prop. Diario", pos, 100, HAlign.Right, , "N2")

         '-.PE-32074.-
         .Columns(Entidades.Interes.Columnas.FechaVigenciaDesde.ToString()).FormatearColumna("Fecha Vigencia Desde", pos, 120, HAlign.Center)
         .Columns(Entidades.Interes.Columnas.FechaVigenciaHasta.ToString()).FormatearColumna("Fecha Vigencia Hasta", pos, 120, HAlign.Center)

         .Columns(Entidades.Interes.Columnas.VencimientoExcluyeSabado.ToString()).FormatearColumna("Vencimiento Excluye Sábado", pos, 80, HAlign.Center)
         .Columns(Entidades.Interes.Columnas.VencimientoExcluyeDomingo.ToString()).FormatearColumna("Vencimiento Excluye Domingo", pos, 80, HAlign.Center)
         .Columns(Entidades.Interes.Columnas.VencimientoExcluyeFeriados.ToString()).FormatearColumna("Vencimiento Excluye Feriado", pos, 80, HAlign.Center)

      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.Interes.Columnas.NombreInteres.ToString()})

   End Sub

#End Region

End Class