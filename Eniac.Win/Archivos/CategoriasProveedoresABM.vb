Imports Eniac.Win

Public Class CategoriasProveedoresABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CategoriasProveedoresDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.CategoriaProveedor))
      End If
      Return New CategoriasProveedoresDetalle(New Entidades.CategoriaProveedor)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.CategoriasProveedores()
   End Function
   'Protected Overrides Sub Imprimir()
   '   MyBase.Imprimir()
   '   Try
   '      Me.Cursor = Cursors.WaitCursor
   '      Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.CategoriasProveedores.rdlc", "SistemaDataSet_CategoriasProveedores", Me.dtDatos, True)
   '      frmImprime.Text = "CategoriasProveedores"
   '      frmImprime.Show()
   '      Me.Cursor = Cursors.Default
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim cate As Entidades.CategoriaProveedor = New Entidades.CategoriaProveedor

      With Me.dgvDatos.DisplayLayout.ActiveRow
         cate = New Reglas.CategoriasProveedores().GetUno(Integer.Parse(.Cells("IdCategoria").Value.ToString().Trim()))
      End With

      Return cate

   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.CategoriaProveedor.Columnas.IdCategoria).Header.Caption = "Código"
         .Columns(Entidades.CategoriaProveedor.Columnas.IdCategoria).Width = 50
         .Columns(Entidades.CategoriaProveedor.Columnas.NombreCategoria).Header.Caption = "Nombre"
         .Columns(Entidades.CategoriaProveedor.Columnas.NombreCategoria).Width = 180

         .Columns(Entidades.CategoriaProveedor.Columnas.IdCuentaContable.ToString()).Header.Caption = "Cuenta"
         .Columns(Entidades.CategoriaProveedor.Columnas.IdCuentaContable.ToString()).Width = 90
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Header.Caption = "Nombre Cuenta"
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Width = 280

         If Not Publicos.TieneModuloContabilidad Then
            .Columns(Entidades.CategoriaProveedor.Columnas.IdCuentaContable.ToString()).Hidden = True
            .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Hidden = True
         End If

      End With
    End Sub

#End Region

End Class