Public Class EstadosPedidosABM
   Implements IConParametros

   Private _tipoTipoComprobante As String
   Private _tipoTipoComprobanteParaCombo As String
   Private _parametros As String

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      If String.IsNullOrWhiteSpace(_tipoTipoComprobante) Then _tipoTipoComprobante = "PEDIDOSCLIE"
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      Me.FormatearGrilla()
   End Sub

   ' Protected Overrides Sub Borrar()

   '     'If Integer.Parse(Me.dgvDatos.SelectedCells(0).OwningRow.Cells(Entidades.CentroCosto.Columnas.IdCentroCosto.ToString()).Value.ToString) = 1 Then
   '     '    MessageBox.Show("Este centro de costo no se puede eliminar", "Centro Costo", MessageBoxButtons.OK, MessageBoxIcon.Information)

   '     If ValidarPlan(Integer.Parse(Me.dgvDatos.SelectedCells(0).OwningRow.Cells(Entidades.CentroCosto.Columnas.IdCentroCosto.ToString()).Value.ToString)) Then
   '         MessageBox.Show("Este Plan tiene cuentas contables asociadas. No se puede eliminar", "Plan Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information)
   '     Else
   '         MyBase.Borrar()
   '     End If

   'End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      Dim frm As EstadosPedidosDetalle
      If estado = StateForm.Actualizar Then
         frm = New EstadosPedidosDetalle(DirectCast(Me.GetEntidad(), Entidades.EstadoPedido))
      Else
         frm = New EstadosPedidosDetalle(New Entidades.EstadoPedido(_tipoTipoComprobante))
      End If
      frm.IdFuncion = IdFuncion
      frm.SetParametros(_parametros)
      Return frm
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.EstadosPedidos()
   End Function

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Return DirectCast(rg, Reglas.EstadosPedidos).GetAll(_tipoTipoComprobante)
   End Function
   Protected Overrides Function Buscar(rg As Reglas.Base, args As Entidades.Buscar) As DataTable
      Return DirectCast(rg, Reglas.EstadosPedidos).Buscar(args, _tipoTipoComprobante)
   End Function

   'Protected Overrides Sub Imprimir()
   '    MyBase.Imprimir()
   '    Try
   '        Me.Cursor = Cursors.WaitCursor
   '        Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

   '        parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresa))

   '        Dim frmImprime As VisorReportes = New VisorReportes("Eniac.SiPrueba.Win.MarcasVehiculos.rdlc", "SistemaDataSet_MarcasVehiculos", Me.dtDatos, parm, True)
   '        frmImprime.Text = Me.Text
   '        frmImprime.Show()
   '        Me.Cursor = Cursors.Default
   '    Catch ex As Exception
   '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '    End Try
   'End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim Estado As Entidades.EstadoPedido = New Entidades.EstadoPedido
      Dim EStados As Reglas.EstadosPedidos = New Reglas.EstadosPedidos()

      With Me.dgvDatos.ActiveRow
         Estado = EStados.GetUno(.Cells(Entidades.EstadoPedido.Columnas.IdEstado.ToString()).Value.ToString(), _tipoTipoComprobante)
      End With

      Return Estado

   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0

         .Columns(Entidades.EstadoPedido.Columnas.IdEstado.ToString()).FormatearColumna("Estado", col, 100)
         .Columns(Entidades.EstadoPedido.Columnas.idTipoComprobante.ToString()).FormatearColumna("Comprobante", col, 100)

         .Columns(Entidades.EstadoPedido.Columnas.SolicitaSucursalParaTipoComprobante.ToString()).FormatearColumna("Sucursal", col, 70)

         .Columns(Entidades.EstadoPedido.Columnas.IdTipoEstado.ToString()).FormatearColumna("Tipo Estado", col, 100)
         .Columns(Entidades.EstadoPedido.Columnas.Orden.ToString()).FormatearColumna("Orden", col, 60)

         .Columns(Entidades.EstadoPedido.Columnas.TipoEstadoPedido.ToString()).Hidden = True

         .Columns(Entidades.EstadoPedido.Columnas.Color.ToString()).FormatearColumna("Color", col, 80, HAlign.Right)
         .Columns(Entidades.EstadoPedido.Columnas.ReservaStock.ToString()).FormatearColumna("Reserva Stock", col, 80, HAlign.Center)

         .Columns("IdDeposito").Hidden = True
         .Columns("NombreDeposito").FormatearColumna("Depósito", col, 100)
         .Columns("IdUbicacion").Hidden = True
         .Columns("NombreUbicacion").FormatearColumna("Ubicación", col, 100)

         .Columns(Entidades.EstadoPedido.Columnas.Divide.ToString()).FormatearColumna("Divide", col, 55, HAlign.Center)
         .Columns(Entidades.EstadoPedido.Columnas.IdEstadoDivideA.ToString()).FormatearColumna("Estado", col, 80)
         .Columns(Entidades.EstadoPedido.Columnas.PorcDivideA.ToString()).FormatearColumna("Porc.", col, 50, HAlign.Right)
         .Columns(Entidades.EstadoPedido.Columnas.IdEstadoDivideB.ToString()).FormatearColumna("Estado", col, 80)
         .Columns(Entidades.EstadoPedido.Columnas.PorcDivideB.ToString()).FormatearColumna("Porc.", col, 50, HAlign.Right)

         .Columns(Entidades.EstadoPedido.Columnas.AfectaPendiente.ToString()).FormatearColumna("Afecta Pendiente", col, 80)
      End With

   End Sub

#End Region

   Private Sub dgvDatos_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      Try
         If e.Row IsNot Nothing AndAlso
            e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Row.ListObject, DataRowView).Row IsNot Nothing Then
            Dim row As DataRow = DirectCast(e.Row.ListObject, DataRowView).Row
            Dim colorColumnKey As String = Entidades.EstadoPedido.Columnas.Color.ToString()
            If row.Table.Columns.Contains(colorColumnKey) AndAlso IsNumeric(e.Row.Cells(colorColumnKey).Value) Then
               Dim colorEstado As Color = Color.FromArgb(Integer.Parse(e.Row.Cells(colorColumnKey).Value.ToString()))
               e.Row.Cells(colorColumnKey).Appearance.BackColor = colorEstado
               e.Row.Cells(colorColumnKey).Appearance.ForeColor = colorEstado
               e.Row.Cells(colorColumnKey).ActiveAppearance.BackColor = colorEstado
               e.Row.Cells(colorColumnKey).ActiveAppearance.ForeColor = colorEstado
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      _parametros = parametros
      Dim parametrosCol As String() = parametros.Split("\"c)
      _tipoTipoComprobante = parametrosCol(0)
      If parametrosCol.Length > 1 Then
         _tipoTipoComprobanteParaCombo = parametrosCol(1)
      End If
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Return "Pendiente documentar"
   End Function
End Class