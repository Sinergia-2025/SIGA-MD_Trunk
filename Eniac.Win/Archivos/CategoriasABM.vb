Public Class CategoriasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CategoriasDetalle(DirectCast(GetEntidad(), Entidades.Categoria))
      End If
      Return New CategoriasDetalle(New Entidades.Categoria())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Categorias()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      Return New Reglas.Categorias().GetUno(dr.Field(Of Integer)(Entidades.Categoria.Columnas.IdCategoria.ToString()))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns(Entidades.Categoria.Columnas.IdCategoria.ToString()).FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns(Entidades.Categoria.Columnas.NombreCategoria.ToString()).FormatearColumna("Nombre", pos, 150)
         .Columns(Entidades.Categoria.Columnas.IdGrupoCategoria.ToString()).FormatearColumna("Grupo", pos, 100)
         .Columns(Entidades.Categoria.Columnas.DescuentoRecargo.ToString()).FormatearColumna("Descuento / Recargo", pos, 80, HAlign.Right, , "N2")
         .Columns(Entidades.Categoria.Columnas.IdCaja.ToString()).Hidden = True
         .Columns(Entidades.CajaNombre.Columnas.NombreCaja.ToString()).FormatearColumna("Caja", pos, 90)
         .Columns(Entidades.Categoria.Columnas.IdTipoComprobante.ToString()).FormatearColumna("Tipo Recibo", pos, 100)


         .Columns(Entidades.Categoria.Columnas.IdInteres.ToString()).Hidden = True
         .Columns(Entidades.Interes.Columnas.NombreInteres.ToString()).FormatearColumna("Interes para Cobranza", pos, 150)
         .Columns(Entidades.Categoria.Columnas.IdInteresCuotas.ToString()).Hidden = True
         .Columns("NombreInteresCuotas").FormatearColumna("Interes para Cuotas", pos, 150)

         .Columns(Entidades.Categoria.Columnas.IdCuenta.ToString()).FormatearColumna("Cuenta", pos, 90)
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).FormatearColumna("Nombre Cuenta", pos, 280)
         .Columns(Entidades.Categoria.Columnas.IdCuentaSecundaria.ToString()).FormatearColumna("Cuenta", pos, 90)
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "Secundaria").FormatearColumna("Cuenta Secundaria", pos, 280)

         If Not Reglas.Publicos.TieneModuloContabilidad Then
            .Columns(Entidades.Categoria.Columnas.IdCuenta.ToString()).Hidden = True
            .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Hidden = True
            .Columns(Entidades.Categoria.Columnas.IdCuentaSecundaria.ToString()).Hidden = True
            .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "Secundaria").Hidden = True
         Else
            If Not Reglas.ContabilidadPublicos.ContabilidadCuentaSecundariaCategoria Then
               .Columns(Entidades.Categoria.Columnas.IdCuentaSecundaria.ToString()).Hidden = True
               .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "Secundaria").Hidden = True
            End If
         End If

         .Columns(Entidades.Categoria.Columnas.IdProducto.ToString()).Hidden = True
         .Columns(Entidades.Categoria.Columnas.NombreProducto.ToString()).Hidden = (Publicos.IDAplicacionSinergia <> "SICLUB")
         .Columns(Entidades.Categoria.Columnas.NombreProducto.ToString()).FormatearColumna("Producto", pos, 280)
         .Columns(Entidades.Categoria.Columnas.RequiereRevisionAdministrativa.ToString()).FormatearColumna("Req. Rev. Administrativa", pos, 90)
         .Columns(Entidades.Categoria.Columnas.NivelAutorizacion.ToString()).FormatearColumna("Nivel de Autorización", pos, 80, HAlign.Right)
         '.Columns(Entidades.Categoria.Columnas.ActualizarVersion.ToString()).FormatearColumna("Actualizar Version", pos, 70, , Not Publicos.ExtrasSinergia)
         .Columns(Entidades.Categoria.Columnas.ActualizarAplicacion.ToString()).FormatearColumna("Actualizar Aplicacion", pos, 70, , Not Reglas.Publicos.TieneModuloControlDeLicencias)
         .Columns(Entidades.Categoria.Columnas.ControlaBackup.ToString()).FormatearColumna("Controla Backup", pos, 80, , Not Reglas.Publicos.TieneModuloControlDeLicencias)

         .Columns(Entidades.Categoria.Columnas.Comisiones.ToString()).FormatearColumna("Comisiones", pos, 80, HAlign.Right, , "N4")

         'PE-31192  Nuevos campos de SiSeN

         .Columns(Entidades.Categoria.Columnas.FirmaMandato.ToString()).Header.Caption = "F.Mandato"
         .Columns(Entidades.Categoria.Columnas.FirmaMandato.ToString()).Hidden = (Publicos.IDAplicacionSinergia <> "SISEN")
         .Columns(Entidades.Categoria.Columnas.FirmaMandato.ToString()).Width = 75

         If Publicos.CargosCalcularPor = "ACCION" Then
            .Columns(Entidades.Categoria.Columnas.AdquiereAcciones.ToString()).Header.Caption = "Adq. Acciones"
            .Columns(Entidades.Categoria.Columnas.AdquiereAcciones.ToString()).Width = 70
            .Columns(Entidades.Categoria.Columnas.AdquiereAcciones.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .Columns(Entidades.Categoria.Columnas.AdquiereCamas.ToString()).Hidden = True
         Else
            .Columns(Entidades.Categoria.Columnas.AdquiereCamas.ToString()).Header.Caption = "Adq. Camas"
            .Columns(Entidades.Categoria.Columnas.AdquiereCamas.ToString()).Width = 70
            .Columns(Entidades.Categoria.Columnas.AdquiereCamas.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
            .Columns(Entidades.Categoria.Columnas.AdquiereAcciones.ToString()).Hidden = True
         End If
         .Columns(Entidades.Categoria.Columnas.AdquiereAcciones.ToString()).Hidden = (Publicos.IDAplicacionSinergia <> "SISEN")
         .Columns(Entidades.Categoria.Columnas.AdquiereCamas.ToString()).Hidden = (Publicos.IDAplicacionSinergia <> "SISEN")

         .Columns(Entidades.Categoria.Columnas.PideConyuge.ToString()).Header.Caption = "Pide Conyuge"
         .Columns(Entidades.Categoria.Columnas.PideConyuge.ToString()).Hidden = (Publicos.IDAplicacionSinergia <> "SISEN")
         .Columns(Entidades.Categoria.Columnas.PideConyuge.ToString()).Width = 70
         .Columns(Entidades.Categoria.Columnas.TPFisicaDatosAdicionales.ToString()).Header.Caption = "TPF Adicionales"
         .Columns(Entidades.Categoria.Columnas.TPFisicaDatosAdicionales.ToString()).Hidden = (Publicos.IDAplicacionSinergia <> "SISEN")
         .Columns(Entidades.Categoria.Columnas.TPFisicaDatosAdicionales.ToString()).Width = 70
         .Columns(Entidades.Categoria.Columnas.PideEmbarcacion.ToString()).Header.Caption = "Embarcacion"
         .Columns(Entidades.Categoria.Columnas.PideEmbarcacion.ToString()).Hidden = (Publicos.IDAplicacionSinergia <> "SISEN")
         .Columns(Entidades.Categoria.Columnas.PideEmbarcacion.ToString()).Width = 70
         .Columns(Entidades.Categoria.Columnas.PideEmbarcacion.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center

         .Columns(Entidades.Categoria.Columnas.PerteneceAlComplejo.ToString()).Header.Caption = "Pertenece al complejo"
         .Columns(Entidades.Categoria.Columnas.PerteneceAlComplejo.ToString()).Hidden = (Publicos.IDAplicacionSinergia <> "SISEN")
         .Columns(Entidades.Categoria.Columnas.PerteneceAlComplejo.ToString()).Width = 85

         .Columns(Entidades.Categoria.Columnas.PagaExpensas.ToString()).Header.Caption = "Expensas"
         .Columns(Entidades.Categoria.Columnas.PagaExpensas.ToString()).Hidden = (Publicos.IDAplicacionSinergia <> "SISEN")
         .Columns(Entidades.Categoria.Columnas.PagaExpensas.ToString()).Width = 70
         .Columns(Entidades.Categoria.Columnas.PagaAlquiler.ToString()).Header.Caption = "Alquiler"
         .Columns(Entidades.Categoria.Columnas.PagaAlquiler.ToString()).Hidden = (Publicos.IDAplicacionSinergia <> "SISEN")
         .Columns(Entidades.Categoria.Columnas.PagaAlquiler.ToString()).Width = 70
         .Columns(Entidades.Categoria.Columnas.ImporteGastosAdmin.ToString()).Header.Caption = "$ Gtos. Admin."
         .Columns(Entidades.Categoria.Columnas.ImporteGastosAdmin.ToString()).Hidden = (Publicos.IDAplicacionSinergia <> "SISEN")
         .Columns(Entidades.Categoria.Columnas.ImporteGastosAdmin.ToString()).Width = 80
         .Columns(Entidades.Categoria.Columnas.ImporteGastosAdmin.ToString()).CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right
         .Columns(Entidades.Categoria.Columnas.ImporteGastosAdmin.ToString()).Format = "N2"

         .Columns(Entidades.Categoria.Columnas.IdCategoriaInversionista.ToString()).Hidden = True
         .Columns(Entidades.Categoria.Columnas.NombreCategoria.ToString() + "Inversionista").Header.Caption = "Categoría Inversionista"
         .Columns(Entidades.Categoria.Columnas.NombreCategoria.ToString() + "Inversionista").Hidden = (Publicos.IDAplicacionSinergia <> "SISEN")
         .Columns(Entidades.Categoria.Columnas.NombreCategoria.ToString() + "Inversionista").Width = 150

         .Columns(Entidades.Categoria.Columnas.IdInteres.ToString()).Hidden = True
         .Columns(Entidades.Interes.Columnas.NombreInteres.ToString()).Header.Caption = "Interés"
         .Columns(Entidades.Interes.Columnas.NombreInteres.ToString()).Hidden = (Publicos.IDAplicacionSinergia <> "SISEN")
         .Columns(Entidades.Interes.Columnas.NombreInteres.ToString()).Width = 280

         .Columns(Entidades.Categoria.Columnas.LimiteMesesDeudaBotado.ToString()).Header.Caption = "Límite Deuda"
         .Columns(Entidades.Categoria.Columnas.LimiteMesesDeudaBotado.ToString()).Hidden = (Publicos.IDAplicacionSinergia <> "SISEN")
         .Columns(Entidades.Categoria.Columnas.LimiteMesesDeudaBotado.ToString()).Width = 80
         .Columns(Entidades.Categoria.Columnas.LimiteMesesDeudaBotado.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Categoria.Columnas.BackColor.ToString()).OcultoPosicion(True, pos)
         .Columns(Entidades.Categoria.Columnas.ForeColor.ToString()).OcultoPosicion(True, pos)

      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.Categoria.Columnas.NombreCategoria.ToString()})
   End Sub

   Private Sub dgvDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      TryCatched(
      Sub()
         Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)(e.Row)
         If dr IsNot Nothing Then
            Dim backColor = dr.Field(Of Integer?)(Entidades.Categoria.Columnas.BackColor.ToString())
            Dim foreColor = dr.Field(Of Integer?)(Entidades.Categoria.Columnas.ForeColor.ToString())
            e.Row.Cells(Entidades.Categoria.Columnas.NombreCategoria.ToString()).ColorFromInteger(foreColor, backColor)
         End If
      End Sub)
   End Sub

#End Region

End Class