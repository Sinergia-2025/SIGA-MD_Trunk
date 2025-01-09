Option Explicit On
Option Strict On

Public Class SeleccionCajaDefecto

   Private _publicos As Publicos
   Private _solicitaVendedorPorDefecto As Boolean
   Private _solicitaTipoComprobantePorDefecto As Boolean
   Private _idCaja As Integer
   Private _vendedor As Entidades.Empleado
   Private _idTipoComprobante As String
   '-.PE-32996.-
   Private _idUsuario As String = actual.Nombre

   Public Sub New(solicitaVendedorPorDefecto As Boolean, solicitaTipoComprobantePorDefecto As Boolean,
                  idCaja As Integer, vendedor As Entidades.Empleado, idTipoComprobante As String)
      InitializeComponent()
      _solicitaTipoComprobantePorDefecto = solicitaTipoComprobantePorDefecto
      _solicitaVendedorPorDefecto = solicitaVendedorPorDefecto
      _idCaja = idCaja
      _vendedor = vendedor
      _idTipoComprobante = idTipoComprobante
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         Me._publicos = New Publicos()

         Dim blnMiraUsuario As Boolean = True, blnMiraPC As Boolean = True, blnCajasModificables As Boolean = False
         Me._publicos.CargaComboCajas(Me.cmbCajas, Entidades.Usuario.Actual.Sucursal.Id, blnMiraUsuario, blnMiraPC, blnCajasModificables)

         '-.PE-32996.-
         Dim rEmpleados = New Reglas.Empleados
         If rEmpleados.GetPorTipo(Entidades.Publicos.TiposEmpleados.VENDEDOR, _idUsuario, False).Count = 0 Then
            'El usuario no es vendedor
            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Else
            'El usuario es vendedor
            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, _idUsuario)
         End If
         '-----------

         Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, True, "VENTAS", , , "SI", True)
         cmbTiposComprobantes.SetSelectedIndexSecure(0) '.SelectedIndex = 0

         cmbVendedor.Enabled = _solicitaVendedorPorDefecto
         cmbTiposComprobantes.Enabled = _solicitaTipoComprobantePorDefecto

         Inicializa()
      End Sub)
   End Sub

   Private Sub Inicializa()
      If _idCaja > 0 Then
         cmbCajas.SelectedValue = _idCaja
      End If
      If _vendedor IsNot Nothing Then
         cmbVendedor.SelectedItem = GetVendedorCombo(_vendedor.IdEmpleado)
      End If
      If Not String.IsNullOrWhiteSpace(_idTipoComprobante) Then
         cmbTiposComprobantes.SelectedValue = _idTipoComprobante
      End If
   End Sub


   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Me.Close()
   End Sub

   Public ReadOnly Property IdCaja() As Integer
      Get
         Return Integer.Parse(Me.cmbCajas.SelectedValue.ToString())
      End Get
   End Property

   Public ReadOnly Property Vendedor() As Entidades.Empleado
      Get
         Return DirectCast(cmbVendedor.SelectedItem, Entidades.Empleado)
      End Get
   End Property

   Public ReadOnly Property IdTipoComprobante() As String
      Get
         Return Me.cmbTiposComprobantes.SelectedValue.ToString()
      End Get
   End Property

   Private Function GetVendedorCombo(ByVal Id As Integer) As Object
      Dim empleados As List(Of Entidades.Empleado) = DirectCast(Me.cmbVendedor.DataSource, List(Of Entidades.Empleado))
      For Each emp As Entidades.Empleado In empleados
         If Id = emp.IdEmpleado Then
            Return emp
         End If
      Next
      Return Nothing
   End Function

End Class