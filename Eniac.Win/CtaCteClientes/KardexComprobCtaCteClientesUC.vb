#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class KardexComprobCtaCteClientesUC
   Implements IUserControlConUltraGrid

#Region "Propiedades Readonly"
   Private _dtDetalle As DataTable
   Public ReadOnly Property dtDetalle As DataTable
      Get
         Return _dtDetalle
      End Get
   End Property
   Public ReadOnly Property Count As Integer
      Get
         If _dtDetalle Is Nothing Then Return 0
         Return _dtDetalle.Rows.Count
      End Get
   End Property
   Private _idSucursal As Integer
   Public ReadOnly Property IdSucursal As Integer
      Get
         Return _idSucursal
      End Get
   End Property
   Private _idTipoComprobante As String
   Public ReadOnly Property IdTipoComprobante As String
      Get
         Return _idTipoComprobante
      End Get
   End Property
   Private _letra As String
   Public ReadOnly Property Letra As String
      Get
         Return _letra
      End Get
   End Property
   Private _centroEmisor As Short
   Public ReadOnly Property CentroEmisor As Short
      Get
         Return _centroEmisor
      End Get
   End Property
   Private _numeroComprobante As Long
   Public ReadOnly Property NumeroComprobante As Long
      Get
         Return _numeroComprobante
      End Get
   End Property
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         ugDetalle.AgregarTotalesSuma({"ImporteCuota"})
         ugDetalle.AgregarFiltroEnLinea({})
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

#Region "Eventos"
   Private Sub ugDetalle_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles ugDetalle.ClickCellButton
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing AndAlso e.Cell.Column.Key = "Ver" Then


            Dim tipoComprobante As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno(dr("IdTipoComprobante").ToString())

            If tipoComprobante.EsRecibo = True Then
               'imprime los recibos
               Dim reg As Reglas.CuentasCorrientes = New Reglas.CuentasCorrientes()
               Dim ctacte As Entidades.CuentaCorriente = reg.GetUna(Integer.Parse(dr(Entidades.CuentaCorriente.Columnas.IdSucursal.ToString()).ToString()),
                                                                    dr(Entidades.CuentaCorriente.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                                    dr(Entidades.CuentaCorriente.Columnas.Letra.ToString()).ToString(),
                                                                    Integer.Parse(dr(Entidades.CuentaCorriente.Columnas.CentroEmisor.ToString()).ToString()),
                                                                    Long.Parse(dr(Entidades.CuentaCorriente.Columnas.NumeroComprobante.ToString()).ToString()))
               Dim imp As RecibosImprimir = New RecibosImprimir()
               imp.ImprimirRecibo(ctacte, True)
            Else
               'imprime los comprobantes que no son recibos
               Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
               Dim venta As Entidades.Venta = oVentas.GetUna(Integer.Parse(dr(Entidades.CuentaCorriente.Columnas.IdSucursal.ToString()).ToString()),
                                                             dr(Entidades.CuentaCorriente.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                             dr(Entidades.CuentaCorriente.Columnas.Letra.ToString()).ToString(),
                                                             Short.Parse(dr(Entidades.CuentaCorriente.Columnas.CentroEmisor.ToString()).ToString()),
                                                             Long.Parse(dr(Entidades.CuentaCorriente.Columnas.NumeroComprobante.ToString()).ToString()))
               Dim oImpr As Impresion = New Impresion(venta)
               If Not tipoComprobante.EsFiscal Then
                  oImpr.ImprimirComprobanteNoFiscal(True)
               Else
                  oImpr.ReImprimirComprobanteFiscal()
               End If
            End If

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      Try
         Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)(e.Row)
         If dr IsNot Nothing Then
            If Integer.Parse(dr(Entidades.CuentaCorriente.Columnas.IdSucursal.ToString()).ToString()) = IdSucursal And
               dr(Entidades.CuentaCorriente.Columnas.IdTipoComprobante.ToString()).ToString() = IdTipoComprobante And
               dr(Entidades.CuentaCorriente.Columnas.Letra.ToString()).ToString() = Letra And
               Short.Parse(dr(Entidades.CuentaCorriente.Columnas.CentroEmisor.ToString()).ToString()) = CentroEmisor And
               Long.Parse(dr(Entidades.CuentaCorriente.Columnas.NumeroComprobante.ToString()).ToString()) = NumeroComprobante Then
               e.Row.Appearance.FontData.Bold = DefaultableBoolean.True
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

#Region "Métodos"
   Public Sub RefrescarDatosGrilla()
      _idSucursal = 0
      _idTipoComprobante = String.Empty
      _letra = String.Empty
      _centroEmisor = 0
      _numeroComprobante = 0

      If _dtDetalle IsNot Nothing Then
         _dtDetalle.Clear()
      End If
   End Sub
   Public Sub CargaGrillaDetalle(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long)
      _idSucursal = idSucursal
      _idTipoComprobante = idTipoComprobante
      _letra = letra
      _centroEmisor = centroEmisor
      _numeroComprobante = numeroComprobante
      CargaGrillaDetalle()
   End Sub
   Private Sub CargaGrillaDetalle()
      Dim rCtaCteDet As Reglas.CuentasCorrientesPagos = New Reglas.CuentasCorrientesPagos()

      Dim decSaldo As Decimal = 0

      Try
         Dim dtTemp As DataTable = _dtDetalle

         _dtDetalle = rCtaCteDet.GetKardexComprobante(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante)
         ugDetalle.DataSource = _dtDetalle

         If dtTemp IsNot Nothing Then dtTemp.Dispose()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
#End Region

#Region "IUserControlConUltraGrid"
   Private ReadOnly Property Grilla As UltraWinGrid.UltraGrid Implements IUserControlConUltraGrid.Grilla
      Get
         Return ugDetalle
      End Get
   End Property
#End Region

End Class