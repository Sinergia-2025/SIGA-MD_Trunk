Public Class CuentasBancariasABM

   Private Sub dgvDatos_AfterRowActivate(sender As Object, e As EventArgs) Handles dgvDatos.AfterRowActivate
      TryCatched(
      Sub()
         Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Dim enable = dr.Field(Of Integer)("IdCuentaBancaria") <> 999
            tsbEditar.Enabled = enable
            tsbBorrar.Enabled = enable
         End If
      End Sub)
   End Sub

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CuentasBancariasDetalle(DirectCast(GetEntidad(), Entidades.CuentaBancaria))
      End If
      Return New CuentasBancariasDetalle(New Entidades.CuentaBancaria())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CuentasBancarias()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      TryCatched(
      Sub()
         Dim parm = New ReportParameterCollection(filtros:=String.Empty)

         Dim frmImprime = New VisorReportes("Eniac.Win.CuentasBancarias.rdlc", "SistemaDataSet_CuentasBancarias", dtDatos, parm, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "Cuentas Bancarias"
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()
      End Sub)
   End Sub

   Protected Overrides Function GetEntidad(filaGrilla As UltraGridRow) As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)(filaGrilla)
      Return New Reglas.CuentasBancarias().GetUna(dr.Field(Of Integer)("IdCuentaBancaria"))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns("IdCuentaBancaria").FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns("CodigoBancario").FormatearColumna("Cód. Bancario", pos, 100, HAlign.Right)
         .Columns("NombreCuenta").FormatearColumna("Nombre Cuenta", pos, 180)
         .Columns("IdCuentaBancariaClase").OcultoPosicion(True, pos)
         .Columns("NombreCuentaBancariaClase").FormatearColumna("Clase Cuenta", pos, 90)
         .Columns("IdBanco").OcultoPosicion(True, pos)
         .Columns("NombreBanco").FormatearColumna("Banco", pos, 120)
         .Columns("IdLocalidad").OcultoPosicion(True, pos)
         .Columns("NombreLocalidad").FormatearColumna("Localidad", pos, 120)
         .Columns("idBancoSucursal").FormatearColumna("Suc. Banco", pos, 50, HAlign.Right)
         .Columns("IdMoneda").OcultoPosicion(True, pos)
         .Columns("NombreMoneda").FormatearColumna("Moneda", pos, 50)
         '.Columns("TieneChequera").FormatearColumna("Cheq.", pos, 40, HAlign.Center) '# Se quita la visibilidad de este campo ya que no tiene función en ningún lado del sistema
         .Columns("Saldo").OcultoPosicion(True, pos)
         .Columns("SaldoConfirmado").OcultoPosicion(True, pos)
         .Columns("Activo").FormatearColumna("Activo", pos, 40, HAlign.Center)
         .Columns("idPlanCuenta").OcultoPosicion(True, pos)
         .Columns("nombrePlanCuenta").FormatearColumna("Plan", pos, 70, , Not Reglas.Publicos.TieneModuloContabilidad)
         .Columns("idCuentaContable").FormatearColumna("Cod. Cuenta", pos, 70, HAlign.Right, Not Reglas.Publicos.TieneModuloContabilidad)
         .Columns("nombreCuentaContable").FormatearColumna("Cuenta Contable", pos, 200, , Not Reglas.Publicos.TieneModuloContabilidad)
         .Columns("Cbu").FormatearColumna("C.B.U.", pos, 150, HAlign.Right)
         .Columns("CbuAlias").FormatearColumna("C.B.U. Alias", pos, 150)
         .Columns("ParaInformarEnFEC").FormatearColumna("Para FEC", pos, 40, HAlign.Center)
         .Columns("IdEmpresa").FormatearColumna("Id", pos, 40, HAlign.Right).Hidden = True
         .Columns("NombreEmpresa").FormatearColumna("Empresa", pos, 150)
      End With
      dgvDatos.AgregarFiltroEnLinea({"NombreCuenta"})
   End Sub

#End Region

End Class