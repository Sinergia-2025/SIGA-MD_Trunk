#Region "Option"
Option Explicit On
Option Strict On
#End Region
Public Class ChequesPropiosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbNuevo.Visible = False
      Me.tsbBorrar.Visible = False
      'Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ChequesPropiosDetalle(DirectCast(Me.GetEntidad(), Entidades.Cheque))
      End If
      Return New ChequesPropiosDetalle(New Entidades.Cheque())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Cheques()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()

      Try
         Me.Cursor = Cursors.WaitCursor

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.ChequesPropios.rdlc", "SistemaDataSet_Cheques", Me.dtDatos, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad



      Dim oCheq As Entidades.Cheque = New Entidades.Cheque()

      With Me.dgvDatos.ActiveRow

         oCheq = New Reglas.Cheques().GetUno(Int32.Parse(.Cells("IdCheque").Value.ToString()))

      End With

      Return oCheq

   End Function
   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         dgvDatos.OcultaTodasLasColumnas()

         Dim pos As Integer = 0
         .Columns("IdSucursal").Hidden = True
         .Columns("IdCuentaBancaria").Hidden = True
         .Columns("IdChequera").FormatearColumna("IdChequera", pos, 100, HAlign.Right, True)
         .Columns("IdCheque").FormatearColumna("IdCheque", pos, 100, HAlign.Right, True)
         .Columns("NombreTipoCheque").FormatearColumna("Tipo de Cheque", pos, 100)
         .Columns("NombreCuenta").FormatearColumna("Cuenta Bancaria", pos, 100)
         .Columns("NumeroCheque").FormatearColumna("Numero", pos, 80, HAlign.Right)
         .Columns("IdBanco").FormatearColumna("Banco", pos, 40, HAlign.Right)
         .Columns("NombreBanco").FormatearColumna("Nombre Banco", pos, 100)
         .Columns("IdBancoSucursal").FormatearColumna("Suc. Banco", pos, 40, HAlign.Right)
         .Columns("IdLocalidad").FormatearColumna("C.P.", pos, 40, HAlign.Right)
         .Columns("NombreLocalidad").FormatearColumna("Localidad", pos, 100)
         .Columns("NroOperacion").FormatearColumna("Nro. Operación", pos, 100)
         .Columns("FechaEmision").FormatearColumna("Emisión", pos, 75, HAlign.Center, False, Formatos.Format.FechaSinHora)
         .Columns("FechaCobro").FormatearColumna("Cobro", pos, 75, HAlign.Center, False, Formatos.Format.FechaSinHora)
         .Columns("Importe").FormatearColumna("Importe", pos, 70, HAlign.Right, False, Formatos.Format.Decimales2)
         .Columns("Titular").Hidden = True
         .Columns("IdEstadoCheque").FormatearColumna("Estado", pos, 120)
         .Columns("NroPlanillaIngreso").Hidden = True
         .Columns("NroMovimientoIngreso").Hidden = True
         .Columns("IdCliente").Hidden = True
         .Columns("CodigoCliente").Hidden = True
         .Columns("NombreCliente").Hidden = True
         .Columns("NroPlanillaEgreso").FormatearColumna("Plan. E.", pos, 50, HAlign.Right)
         .Columns("NroMovimientoEgreso").FormatearColumna("Mov. E.", pos, 50, HAlign.Right)
         .Columns("IdProveedor").Hidden = True
         .Columns("CodigoProveedor").Hidden = True
         .Columns("NombreProveedor").FormatearColumna("Nombre Proveedor", pos, 200)
      End With

      dgvDatos.AgregarFiltroEnLinea({"NombreCuenta"})

   End Sub

   Protected Overrides Sub Borrar()

      Dim strMensaje As String

      Try

         If Me.dgvDatos.Rows.Count > 0 Then

            'Si tiene movimiento de Egreso no puede borrar el cheque, debe hacerlo por alguna opcion especifica.
            With Me.dgvDatos.ActiveRow
               If Long.Parse(.Cells("NroPlanillaEgreso").Value.ToString()) > 0 Then

                  strMensaje = "NO puede eliminar el Cheque porque tiene Egreso en Caja" & vbNewLine & vbNewLine

                  strMensaje = strMensaje & "Planilla: " & .Cells("NroPlanillaEgreso").Value.ToString
                  strMensaje = strMensaje & ", Movimiento: " & .Cells("NroMovimientoEgreso").Value.ToString

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
      Return DirectCast(rg, Reglas.Cheques).GetAll2(actual.Sucursal.Id, True)
   End Function
   Protected Overrides Function Buscar(rg As Reglas.Base, bus As Entidades.Buscar) As DataTable
      Return DirectCast(rg, Reglas.Cheques).Buscar2(bus, True) '.Tables(0)
   End Function

   'Protected Overrides Sub RefreshGrid()
   '   Try

   '      Dim rg As Reglas.Cheques = DirectCast(Me.GetReglas(), Reglas.Cheques)
   '      If Not Me.tstBuscar.Tag Is Nothing And Me.tstBuscar.Text <> "" Then
   '         Dim bus As Entidades.Buscar = New Entidades.Buscar
   '         bus.Columna = Me.tstBuscar.Tag.ToString()
   '         bus.Valor = Me.tstBuscar.Text.Trim()
   '         Me.dtDatos = rg.Buscar2(bus, True).Tables(0)
   '      Else
   '         Me.dtDatos = rg.GetAll2(actual.Sucursal.Id, True)
   '      End If
   '      Me.dgvDatos.DataSource = Me.dtDatos
   '      If Not Me.dtDatos Is Nothing Then
   '         Me.FormatearGrilla()
   '      End If
   '      If Me.dgvDatos.Rows.Count > 1 Then
   '         Me.tssRegistros.Text = Me.dgvDatos.Rows.Count & " Registros"
   '      Else
   '         Me.tssRegistros.Text = Me.dgvDatos.Rows.Count & " Registro"
   '      End If
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

#End Region

End Class