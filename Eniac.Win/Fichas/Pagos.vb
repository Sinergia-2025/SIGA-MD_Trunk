Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Entidades
Imports Eniac.Reglas

Public Class Pagos

#Region "Enumeraciones"

   Public Enum TipoPago
      Pago
      Devolucion
   End Enum

#End Region

#Region "Campos"

   Private _idCaja As Integer = 0
   Private _nroOperacion As Integer
   Private _idCliente As Long
   Private _nroDocCobrador As String
   Private _tipo As TipoPago
   Private _IdSucursal As Integer = 0

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Dim pub As Eniac.Win.Publicos = New Eniac.Win.Publicos()
      'Me.CargaComboCobradores()
      pub.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)

      Me._IdSucursal = Eniac.Entidades.Usuario.Actual.Sucursal.Id

      Me.txtCaja.Text = New Eniac.Reglas.CajasNombres().GetUna(Me._IdSucursal, Me._idCaja).NombreCaja

   End Sub

#End Region

#Region "Constructores"

   Public Sub New(ByVal idCaja As Integer, ByVal tipo As TipoPago, ByVal nroOperacion As Integer, ByVal idCliente As Long, ByVal nroDocCobrador As String, ByVal importeCuota As Decimal)

      Me.InitializeComponent()

      Me._idCaja = idCaja
      Me._nroOperacion = nroOperacion
      Me._idCliente = idCliente
      Me._nroDocCobrador = nroDocCobrador
      Me._tipo = tipo
      If tipo = TipoPago.Pago Then
         Me.Text = "Pagos"
         Me.txtImporte.Text = importeCuota.ToString("##0.00")
      Else
         Me.Text = "Devolución de Pagos"
         Me.txtConcepto.Enabled = False
         Me.txtInteres.Enabled = False
      End If

   End Sub

#End Region

#Region "Eventos"

   Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
      Try
         If Double.Parse(Me.txtImporte.Text) > 0 Then
            If Double.Parse(Me.txtInteres.Text) > 0 Then
               If Me.txtConcepto.Text.Trim().Length = 0 Then
                  MessageBox.Show("Debe contener un concepto si el interes no es cero", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
            End If
            Me.GrabarPago()
         Else
            MessageBox.Show("El importe debe ser distinto de cero.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub

   Private Sub txtImporte_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImporte.Enter
      Me.txtImporte.SelectAll()
   End Sub

#End Region

#Region "Metodos"

   Private Sub PreparaGrillaDatosCobrador(ByVal buscador As Eniac.Controles.Buscador)
      buscador.ColumnasTitulos = New String() {"Tipo", "Nro.", "Nombre", "Telefono", "Celular"}
      buscador.ColumnasAncho = New Integer() {40, 70, 190, 150, 100}
      buscador.Titulo = "Cobradores"
   End Sub

   Private Sub GrabarPago()

      Dim oReg As Eniac.Reglas.FichasPagosDetalle = New Eniac.Reglas.FichasPagosDetalle()
      Dim oPag As Eniac.Entidades.FichaPagoDetalle = New Eniac.Entidades.FichaPagoDetalle(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
      With oPag
         .IdSucursal = Eniac.Entidades.Usuario.Actual.Sucursal.Id
         .IdCaja = Me._idCaja
         .NroOperacion = Me._nroOperacion
         .IdCliente = Me._idCliente
         .FechaPago = Me.dtpFecha.Value
         .Importe = Decimal.Parse(Me.txtImporte.Text)
         .IdCobrador = DirectCast(Me.cmbCobrador.SelectedItem, Entidades.Empleado).IdEmpleado

         If Decimal.Parse(Me.txtInteres.Text) > 0 Then
            .FichaPagoAjuste.IdCaja = .IdCaja
            .FichaPagoAjuste.NroOperacion = .NroOperacion
            .FichaPagoAjuste.IdCliente = .IdCliente
            .FichaPagoAjuste.IdSucursal = .IdSucursal
            .FichaPagoAjuste.Importe = Decimal.Parse(Me.txtInteres.Text)
            .FichaPagoAjuste.FechaPago = .FechaPago
            .FichaPagoAjuste.Concepto = Me.txtConcepto.Text
         End If
      End With
      If Me._tipo = TipoPago.Pago Then
         'pago
         oReg.Insertar(oPag)
         Me.ImprimirRecibo(oPag)
         MessageBox.Show("El pago se realizó con exito!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Else
         'devolucion
         oReg.Actualizar(oPag)
         MessageBox.Show("La Devolución se realizó con exito!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If
      Me.LimpiarCampos()
      Me.Close()
   End Sub

   Private Sub ImprimirRecibo(ByVal pag As Eniac.Entidades.FichaPagoDetalle)
      Me.Cursor = Cursors.WaitCursor

      'obtengo los detalles de pagos para imprimir en el recibo
      Dim oFP As Eniac.Reglas.FichasPagosDetalle = New Eniac.Reglas.FichasPagosDetalle()
      Dim pagos As List(Of Eniac.Entidades.FichaPagoDetalle) = oFP.GetFichasAImprimir(pag.IdSucursal, pag.IdCliente, pag.NroOperacion, pag.FechaPago)

      'recupero si existen ajuste
      Dim oFA As Eniac.Reglas.FichasPagosAjustes = New Eniac.Reglas.FichasPagosAjustes()

      'recupero los datos del cliente
      Dim oCl As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes()
      Dim cliente As Eniac.Entidades.Cliente = oCl.GetUno(pag.IdCliente)

      'calculo monto
      Dim intereses As Double = 0
      Dim concepto As String = String.Empty
      Dim monto As Decimal = 0
      If pagos.Count > 0 Then
         If pagos(0).FichaPagoAjuste.Importe > 0 Then
            monto += pagos(0).FichaPagoAjuste.Importe
            intereses = pagos(0).FichaPagoAjuste.Importe
            concepto = pagos(0).FichaPagoAjuste.Concepto
         End If
      End If
      For Each pago As Eniac.Entidades.FichaPagoDetalle In pagos
         monto += pago.Importe
      Next

      'obtengo el nombre del o los productos
      Dim oFPro As Eniac.Reglas.FichasProductos = New Eniac.Reglas.FichasProductos()
      Dim produc As List(Of Eniac.Entidades.Producto) = oFPro.GetProductosFichas(pag.IdSucursal, pag.NroOperacion, pag.IdCliente)

      Dim productos As String = "  "
      For Each pr As Eniac.Entidades.Producto In produc
         productos += pr.NombreProducto + " / "
      Next
      productos = productos.Substring(0, productos.Length - 2)

      'creo la coleccion de parametros
      Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", pagos(0).FechaPago.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDoc", cliente.CodigoCliente.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", cliente.NombreCliente))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Monto", monto.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Productos", productos))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Intereses", intereses.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Concepto", concepto))

      Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.ReciboPago.rdlc", "SistemaDataSet_FichasPagosDetalle", pagos, parm, 1) '# 1 = Cantidad Copias
      frmImprime.Text = "Recibo pago"
      Me.Cursor = Cursors.Default
      frmImprime.ShowDialog()



   End Sub

   Private Sub LimpiarCampos()
      Me.dtpFecha.Value = DateTime.Now
      Me.txtImporte.Text = "0.00"
      Me.cmbCobrador.SelectedIndex = -1
   End Sub

   Private Sub CargaComboCobradores()
      Dim oCobradores As Eniac.Reglas.Empleados = New Eniac.Reglas.Empleados()
      With Me.cmbCobrador
         .DisplayMember = "NombreEmpleado"
         .ValueMember = "NroDocEmpleado"
         .DataSource = oCobradores.GetAll()
         If Not String.IsNullOrEmpty(Me._nroDocCobrador) Then
            .SelectedValue = Me._nroDocCobrador
         End If
      End With
   End Sub

#End Region

   Private Sub txtInteres_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInteres.Leave
      Try
         Me.txtConcepto.ReadOnly = (Decimal.Parse(Me.txtInteres.Text) <= 0)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class