Public Class ParametrosABM

#Region "Overrides"
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ParametrosDetalle(DirectCast(GetEntidad(), Entidades.Parametro))
      End If
      Return New ParametrosDetalle(New Entidades.Parametro())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Parametros()
   End Function

   Protected Overrides Sub Imprimir()

      MyBase.Imprimir()
      TryCatched(
         Sub()
            Using frmImprime = New VisorReportes("Eniac.Win.Parametros.rdlc", "SistemaDataSet_Parametros", dtDatos, True, 1) '# 1 = Cantidad Copias
               frmImprime.Text = "Parametros"
               frmImprime.Show()
            End Using
         End Sub)
   End Sub

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim parametro = New Entidades.Parametro()
      With dgvDatos.ActiveRow
         parametro = New Reglas.Parametros().GetUno(actual.Sucursal.IdEmpresa, .Cells("IdParametro").Value.ToString(), Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)
      End With
      Return parametro
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns("IdParametro").FormatearColumna("Código", pos, 250)
         .Columns("DescripcionParametro").FormatearColumna("Descripción", pos, 390)
         .Columns("ValorParametro").FormatearColumna("Valor", pos, 150)
         .Columns("CategoriaParametro").FormatearColumna("Categoría", pos, 150)
         .Columns("UbicacionParametro").FormatearColumna("Ubicacion", pos, 400)
      End With
      dgvDatos.AgregarFiltroEnLinea({"IdParametro", "NombreParametro", "DescripcionParametro", "UbicacionParametro"})
   End Sub
#End Region

End Class