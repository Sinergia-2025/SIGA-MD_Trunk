Public Class CuentasDeCajasABM

#Region "Campos"
   Private _publico As Reglas.Publicos
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      _publico = New Reglas.Publicos()
      'Me.BotonImprimir.Hidden = True

      'If Not Publicos.TieneModuloContabilidad Then
      '   Me.Width = Me.Width - 130
      'End If

   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CuentasDeCajasDetalle(DirectCast(GetEntidad(), Entidades.CuentaDeCaja))
      End If
      Return New CuentasDeCajasDetalle(New Entidades.CuentaDeCaja())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.CuentasDeCajas()
   End Function


   Protected Overrides Sub Borrar()
      Dim Cuenta = (dgvDatos.ActiveRow.Cells("IdCuentaCaja").Value.ToString())

      If _publico.ExisteParametroCuenta(Cuenta.ToString(), "CAJA") Then
         MessageBox.Show("ATENCIÓN: No se pueden eliminar Cuentas de Caja pertenencientes a los Parametros del Sistema", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Exit Sub
      End If

      MyBase.Borrar()
   End Sub

   Protected Overrides Sub Imprimir()

      MyBase.Imprimir()

      Try
         Me.Cursor = Cursors.WaitCursor

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.CuentasDeCajas.rdlc", "DataSetCaja_CuentasDeCajas", Me.dtDatos, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = "Cuentas de Caja"
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim cuentasDeCaja As Entidades.CuentaDeCaja
      With Me.dgvDatos.ActiveRow
         cuentasDeCaja = New Reglas.CuentasDeCajas().GetUna(Integer.Parse(.Cells("IdCuentaCaja").Value.ToString()))
      End With
      Return cuentasDeCaja
   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         dgvDatos.OcultaTodasLasColumnas()

         Dim pos As Integer = 0

         .Columns("IdCuentaCaja").FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns("NombreCuentaCaja").FormatearColumna("Nombre", pos, 250)
         .Columns("IdTipoCuenta").FormatearColumna("Tipo", pos, 40, HAlign.Center)
         .Columns("IdGrupoCuenta").FormatearColumna("Grupo", pos, 100)

         .Columns("GeneraContabilidad").FormatearColumna("Genera Contabilidad (x)", pos, 70, HAlign.Center, True)
         .Columns("GeneraContabilidad_SN").FormatearColumna("Genera Contabilidad", pos, 70, HAlign.Center)

         .Columns("IdCuentaContable").FormatearColumna("Cuenta Contable", pos, 90, HAlign.Right)
         .Columns("NombreCuentaContable").FormatearColumna("Nombre Cuenta Contable", pos, 200)
         .Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).FormatearColumna("Centro Costo", pos, 120)

         .Columns("GeneraContabilidad_SN").Hidden = Not Reglas.Publicos.TieneModuloContabilidad
         .Columns("IdCuentaContable").Hidden = Not Reglas.Publicos.TieneModuloContabilidad
         .Columns("NombreCuentaContable").Hidden = Not Reglas.Publicos.TieneModuloContabilidad
         .Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Hidden = Not Reglas.Publicos.TieneModuloContabilidad OrElse Not Reglas.ContabilidadPublicos.UtilizaCentroCostos

         .Columns("IdConceptoCM05").OcultoPosicion(hidden:=True, pos)
         .Columns("DescripcionConceptoCM05").FormatearColumna("Concepto CM05", pos, 150)
         .Columns("TipoConceptoCM05").FormatearColumna("Tipo CM05", pos, 100)
      End With

      dgvDatos.AgregarFiltroEnLinea({"NombreCuentaCaja"})

   End Sub

#End Region

End Class