Public Class AnularRequerimientosComprasConfirmar
   Private ReadOnly Property Requerimiento As Entidades.RequerimientoCompra

   Private _publicos As Publicos

   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(rq As Entidades.RequerimientoCompra)
      Me.New()
      Requerimiento = rq
   End Sub

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(Sub() _publicos.CargaComboDesdeEnum(cmbTodos, Reglas.Publicos.TodosEnum.MararTodos))
      TryCatched(Sub() CargarValoresPantalla())
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         btnCancelar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub() AnularRequerimiento())
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
   End Sub
   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      TryCatched(Sub() ugProductos.MarcarDesmarcar(cmbTodos, "Selec",
                                                   Function(dr)
                                                      Dim rqProd = dr.FilaSeleccionada(Of Entidades.RequerimientoCompraProducto)
                                                      Return rqProd IsNot Nothing AndAlso rqProd.CantidadAsignaciones = 0
                                                   End Function))
   End Sub
   Private Sub ugProductos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugProductos.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of Entidades.RequerimientoCompraProducto)
         If dr IsNot Nothing Then
            If dr.CantidadAsignaciones > 0 Then
               e.Row.Cells("Selec").Activation = Activation.Disabled
            End If
         End If
      End Sub)
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargarValoresPantalla()
      If Requerimiento IsNot Nothing Then
         txtTiposComprobantes.SetValor(Requerimiento.IdTipoComprobante)
         txtLetra.SetValor(Requerimiento.Letra)
         txtEmisor.SetValor(Requerimiento.CentroEmisor)
         txtNumeroPosible.SetValor(Requerimiento.NumeroRequerimiento)

         dtpFecha.SetValor(Requerimiento.Fecha)
         txtObservacion.SetValor(Requerimiento.Observacion)

         ugProductos.DataSource = Requerimiento.Productos

      Else
         grbProveedor.Enabled = False
         tbcDetalle.Enabled = False
         btnAceptar.Enabled = False
      End If
   End Sub
   Private Sub AnularRequerimiento()
      ugProductos.UpdateData()
      Dim rRq = New Reglas.RequerimientosCompras()
      rRq.AnularRequerimiento(Requerimiento)
      Close(DialogResult.OK)
   End Sub
#End Region

End Class