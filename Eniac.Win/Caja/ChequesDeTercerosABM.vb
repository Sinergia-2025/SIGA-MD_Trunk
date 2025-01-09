Public Class ChequesDeTercerosABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ChequesDeTercerosDetalle(DirectCast(GetEntidad(), Entidades.Cheque))
      End If
      Return New ChequesDeTercerosDetalle(New Entidades.Cheque(actual.Sucursal.Id, actual.Nombre, actual.Pwd))
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Cheques()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      TryCatched(
         Sub()
            Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

            Dim frmImprime = New VisorReportes("Eniac.Win.ChequesDeTerceros.rdlc", "SistemaDataSet_Cheques", dtDatos, parm, True, 1) '# 1 = Cantidad Copias
            frmImprime.Text = Text
            frmImprime.WindowState = FormWindowState.Maximized
            frmImprime.Show()
         End Sub)

   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim oCheq = New Entidades.Cheque(actual.Sucursal.Id, actual.Nombre, actual.Pwd)

      With Me.dgvDatos.ActiveRow
         oCheq = New Reglas.Cheques().GetUno(Integer.Parse(.Cells("IdCheque").Value.ToString()))
      End With

      Return oCheq
   End Function

   Protected Overrides Sub FormatearGrilla()

      With dgvDatos.DisplayLayout.Bands(0)
         dgvDatos.OcultaTodasLasColumnas()

         Dim pos As Integer = 0
         .Columns("IdSucursal").Hidden = True
         .Columns("IdCuentaBancaria").Hidden = True
         .Columns("IdChequera").FormatearColumna("IdChequera", pos, 100, HAlign.Right, True)
         .Columns("IdCheque").FormatearColumna("IdCheque", pos, 100, HAlign.Right, True)
         .Columns("NombreTipoCheque").FormatearColumna("Tipo de Cheque", pos, 100)
         .Columns("NombreCuenta").Hidden = True
         .Columns("NumeroCheque").FormatearColumna("Numero", pos, 80, HAlign.Right)
         .Columns("IdBanco").FormatearColumna("Banco", pos, 40, HAlign.Right)
         .Columns("NombreBanco").FormatearColumna("Nombre Banco", pos, 100)
         .Columns("IdBancoSucursal").FormatearColumna("Suc. Banco", pos, 40, HAlign.Right)
         .Columns("IdLocalidad").FormatearColumna("C.P.", pos, 40, HAlign.Right)
         .Columns("NombreLocalidad").FormatearColumna("Localidad", pos, 100)
         .Columns("NroOperacion").FormatearColumna("Nro. Operación", pos, 100)
         .Columns("FechaEmision").FormatearColumna("Emisión", pos, 75, HAlign.Center, False, "dd/MM/yyyy")
         .Columns("FechaCobro").FormatearColumna("Cobro", pos, 75, HAlign.Center, False, "dd/MM/yyyy")
         .Columns("Titular").FormatearColumna("Titular", pos, 120)
         .Columns("Cuit").FormatearColumna("CUIT", pos, 90)
         .Columns("Importe").FormatearColumna("Importe", pos, 70, HAlign.Right, False, "N2")
         .Columns("IdEstadoCheque").FormatearColumna("Estado", pos, 120)
         .Columns("NroPlanillaIngreso").FormatearColumna("Plan. I.", pos, 50, HAlign.Right)
         .Columns("NroMovimientoIngreso").FormatearColumna("Mov. I.", pos, 50, HAlign.Right)
         .Columns("IdCliente").Hidden = True
         .Columns("CodigoCliente").Hidden = True
         .Columns("NombreCliente").FormatearColumna("Nombre Cliente", pos, 200)
         .Columns("NroPlanillaEgreso").FormatearColumna("Plan. E.", pos, 50, HAlign.Right)
         .Columns("NroMovimientoEgreso").FormatearColumna("Mov. E.", pos, 50, HAlign.Right)
         .Columns("IdProveedor").Hidden = True
         .Columns("CodigoProveedor").Hidden = True
         .Columns("NombreProveedor").FormatearColumna("Nombre Proveedor", pos, 200)
         .Columns("IdProveedorPreasignado").Hidden = True
         .Columns("CodigoProveedorPreasignado").Hidden = True
         .Columns("ProveedorPreasignado").FormatearColumna("Proveedor Pre-Asignado", pos, 200)
         .Columns("IdSituacionCheque").FormatearColumna("Código Situación ", pos, 100, HAlign.Right)
         .Columns("NombreSituacionCheque").FormatearColumna("Nombre Situación", pos, 150, HAlign.Left)
         .Columns("Observacion").FormatearColumna("Observación", pos, 80)
      End With
      dgvDatos.AgregarFiltroEnLinea({"Titular", "NombreCliente", "NombreProveedor"})
   End Sub

   Protected Overrides Sub Borrar()

      Dim strMensaje As String

      Try

         If Me.dgvDatos.Rows.Count > 0 Then

            With Me.dgvDatos.ActiveRow
               'Si tiene movimiento de ingreso (y/o Egreso) no puede borrar el cheque, debe hacerlo por alguna opcion especifica.
               If Integer.Parse("0" & .Cells("NroPlanillaIngreso").Value.ToString()) > 0 Then
                  strMensaje = "NO puede eliminar el cheque porque es utilizado por Caja" & vbNewLine & vbNewLine

                  strMensaje = strMensaje & " Planilla Ingreso:  " & .Cells("NroPlanillaIngreso").Value.ToString
                  strMensaje = strMensaje & " / " & .Cells("NroMovimientoIngreso").Value.ToString

                  If Int32.Parse("0" & .Cells("NroPlanillaEgreso").Value.ToString()) > 0 Then
                     strMensaje = strMensaje & ",  Planilla Egreso:  " & .Cells("NroPlanillaEgreso").Value.ToString
                     strMensaje = strMensaje & " / " & .Cells("NroMovimientoEgreso").Value.ToString
                  End If

                  MessageBox.Show(strMensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                  Exit Sub
               End If


               If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                  Dim cl As Eniac.Reglas.Base = Me.GetReglas()
                  Me._entidad = Me.GetEntidad()
                  cl.Borrar(Me._entidad)
                  Me.RefreshGrid()
               End If
            End With

         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            MessageBox.Show("No se puede eliminar porque esta siendo utilizado", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Try
   End Sub

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Return DirectCast(rg, Reglas.Cheques).GetAll2(actual.Sucursal.Id, False)
   End Function

   Protected Overrides Function Buscar(rg As Reglas.Base, bus As Entidades.Buscar) As DataTable
      Return DirectCast(rg, Reglas.Cheques).Buscar2(bus, False) '.Tables(0)
   End Function

#End Region

End Class