Public Class CuentasBancosABM

#Region "Campos"
   Private _publico As Reglas.Publicos
#End Region


#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publico = New Reglas.Publicos()
         End Sub)
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CuentasBancosDetalle(Me.GetEntidad())
      End If
      Return New CuentasBancosDetalle(New Entidades.CuentaBanco())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CuentasBancos()
   End Function

   Protected Overrides Sub Borrar()
      Dim idCuentaBanco = dgvDatos.ActiveRow.Cells("IdCuentaBanco").Value.ToString()
      If _publico.ExisteParametroCuenta(idCuentaBanco.ToString(), "BANCO") Then
         ShowMessage("ATENCIÓN: No se pueden eliminar Cuentas de Banco pertenencientes a los Parametros del Sistema")
         Exit Sub
      End If
      MyBase.Borrar()
   End Sub

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      TryCatched(
         Sub()
            Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

            Dim frmImprime = New VisorReportes("Eniac.Win.CuentasBancos.rdlc", "SistemaDataSet_CuentasBancos", dtDatos, parm, True, 1) '# 1 = Cantidad Copias
            frmImprime.Text = "Cuentas Bancos"
            frmImprime.Show()
         End Sub)
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      With dgvDatos.ActiveRow
         Return New Reglas.CuentasBancos().GetUna(Integer.Parse(.Cells("IdCuentaBanco").Value.ToString()))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I

         .Columns("IdCuentaBanco").FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns("NombreCuentaBanco").FormatearColumna("Nombre", pos, 250)
         .Columns("IdTipoCuenta").FormatearColumna("Tipo", pos, 40, HAlign.Center, hidden:=True)
         .Columns("DescripcionTipoCuenta").FormatearColumna("Tipo", pos, 60, HAlign.Center)
         .Columns("EsPosdatado").FormatearColumna("Posdat.", pos, 50, HAlign.Center, hidden:=True)
         .Columns("EsPosdatado_SN").FormatearColumna("Posdat.", pos, 50, HAlign.Center)
         .Columns("PideCheque").FormatearColumna("Pide Cheque", pos, 50, HAlign.Center, hidden:=True)
         .Columns("PideCheque_SN").FormatearColumna("Pide Cheque", pos, 50, HAlign.Center)
         .Columns("IdGrupoCuenta").FormatearColumna("Grupo", pos, 100)
         .Columns("IdCuentaContable").FormatearColumna("Cuenta Contable", pos, 90, HAlign.Right, hidden:=Not Reglas.Publicos.TieneModuloContabilidad)
         .Columns("NombreCuentaContable").FormatearColumna("Nombre Cuenta Contable", pos, 200, , hidden:=Not Reglas.Publicos.TieneModuloContabilidad)
         .Columns("IdCentroCosto").OcultoPosicion(hidden:=True, pos)
         .Columns("NombreCentroCosto").FormatearColumna("Centro de Costos", pos, 120, , hidden:=Not Reglas.ContabilidadPublicos.UtilizaCentroCostos)
         .Columns("IdConceptoCM05").OcultoPosicion(hidden:=True, pos)
         .Columns("DescripcionConceptoCM05").FormatearColumna("Concepto CM05", pos, 150)
         .Columns("TipoConceptoCM05").FormatearColumna("Tipo CM05", pos, 100)

      End With
      dgvDatos.AgregarFiltroEnLinea({"NombreCuentaBanco", "IdGrupoCuenta"})
   End Sub

#End Region

End Class