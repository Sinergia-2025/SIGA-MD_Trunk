Imports Eniac.Entidades

Public Class MRPAnulacionPlanMaestro

#Region "Campos"
   Private _publicos As Publicos
   Dim dtDetalle As DataTable
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()
         '-- Posiciona el cursor.- 
         txtPlanMaestro.Focus()
         '------------------------
         FormateaGrillaProductos()
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbAnular.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
   Public Sub FormateaGrillaProductos()
      With ugDetalle.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()

         Dim pos = 0I

         .Columns("IdEstado").FormatearColumna("Estado", pos, 150)

         .Columns("IdTipoComprobante").FormatearColumna("Comprobante", pos, 150, HAlign.Left)
         .Columns("Letra").FormatearColumna("L", pos, 30, HAlign.Center)
         .Columns("CentroEmisor").FormatearColumna("Emisor", pos, 50, HAlign.Right)
         .Columns("NumeroOrdenProduccion").FormatearColumna("Numero", pos, 80, HAlign.Right)
         .Columns("FechaOrdenProduccion").FormatearColumna("Fecha", pos, 80, HAlign.Center)

         .Columns("IdProducto").FormatearColumna("Id Producto", pos, 80, HAlign.Left)
         .Columns("NombreProducto").FormatearColumna("Producto", pos, 150, HAlign.Left)
         '.Columns("NombreDepositoDefecto").FormatearColumna("Deposito", pos, 150, HAlign.Left)
         '.Columns("NombreUbicacionDefecto").FormatearColumna("Ubicacion", pos, 150, HAlign.Left)

         .Columns("NombreCliente").FormatearColumna("Cliente", pos, 150, HAlign.Left)


      End With
   End Sub
   Private Sub RefrescarDatosGrilla()
      'Limpio la Grilla.
      ugDetalle.ClearFilas()
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
      txtPlanMaestro.Text = "0"
      txtPlanMaestro.Select()
   End Sub
   Private Sub CargaGrillaDetalle()
      Dim rOP = New Reglas.OrdenesProduccion()
      Dim dtDetalle = rOP.GetOrdenesProduccion(actual.Sucursal.IdSucursal, Nothing,
                              Reglas.Publicos.EstadoOrdenProduccionPlanificacion,
                              Nothing, Nothing, 0, String.Empty, 0, 0,
                              Nothing, Nothing,
                              Nothing, Nothing, Nothing,
                              Nothing, 0, String.Empty, String.Empty, 0, txtPlanMaestro.ValorNumericoPorDefecto(0I), Nothing, Nothing)

      ugDetalle.DataSource = dtDetalle
      FormateaGrillaProductos()
      Me.tssRegistros.Text = (Me.ugDetalle.Rows.Count).ToString() & " Registros"

   End Sub

   Private Sub AnulacionOrdenesProduccionPlanMaestro()
      Dim rOrdenProduccion = New Reglas.OrdenesProduccion()
      rOrdenProduccion.AnulacionOrdenesProduccionPlanMaestro(DirectCast(ugDetalle.DataSource, DataTable), IdFuncion)
   End Sub
#End Region

#Region "Metodos"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbAnular_Click(sender As Object, e As EventArgs) Handles tsbAnular.Click
      TryCatched(
      Sub()
         Dim respuesta As DialogResult

         If ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.UpdateData()
         '-- Anulacion de Plan Maestro.-
         respuesta = ShowPregunta(String.Format("¿Confirma la Anulación de Ordenes de Produccion para el Plan Maestro Nro {0}?", txtPlanMaestro.ValorNumericoPorDefecto(0I)))
         If respuesta = Windows.Forms.DialogResult.Yes Then
            AnulacionOrdenesProduccionPlanMaestro()
         End If
         '-- Mensaje de operacion.-
         ShowMessage(String.Format("¡¡¡ Plan Maestro ({0}) Anulado Exitosamente !!!", txtPlanMaestro.Text()))
         tsbRefrescar.PerformClick()
      End Sub)
   End Sub
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         If txtPlanMaestro.ValorNumericoPorDefecto(0I) = 0 Then
            MessageBox.Show("ATENCION: NO ingreso un número de Plan Maestro valido.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPlanMaestro.Focus()
            Exit Sub
         End If
         '---------------------------------------------------------------------------------------------------------------------------------------------
         Me.Cursor = Cursors.WaitCursor
         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub txtPlanMaestro_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPlanMaestro.KeyDown
      Try
         If e.KeyCode = Keys.Enter Then
            btnConsultar.PerformClick()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

End Class