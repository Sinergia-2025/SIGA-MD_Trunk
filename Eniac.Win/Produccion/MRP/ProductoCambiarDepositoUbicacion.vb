
Public Class ProductoCambiarDepositoUbicacion
#Region "Campos"
   Private _publicos As Publicos
   Private _Producto As Entidades.NovedadProduccionMRPProducto

   Private _cargandoInicio As Boolean

#End Region

#Region "New"
   Private Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(oprProducto As Entidades.NovedadProduccionMRPProducto)
      Me.New()
      _Producto = oprProducto
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()
            '---------------------------------------------------------------------------------------------
            _cargandoInicio = True
            '-- Carga Combos de Depositos.- --------------------------------------------------------------
            _publicos.CargaComboDepositos(cmbDepositoNuevo, actual.Sucursal.IdSucursal, miraUsuario:=True, PermiteEscritura:=True, Entidades.Publicos.SiNoTodos.SI)
            '-- Carga Datos de inicio.- ------------------------------------------------------------------
            CargaDatosInicio()
            '---------------------------------------------------------------------------------------------
            _cargandoInicio = False
            '-- Posiciona el Cursor.- 
            cmbDepositoNuevo.Select()
         End Sub)
   End Sub

#End Region

#Region "Metodos"
   Private Sub CargaDatosInicio()
      With _Producto
         txtProducto.Text = String.Format("{0} - {1}", .IdProducto, .NombreProducto)
         txtDepositoActual.Text = .NombreDeposito
         txtUbicacionActual.Text = .NombreUbicacion
         txtCantidad.Text = .Cantidad.ToString("N2")
         txtCantidadNuevo.Text = .Cantidad.ToString("N2")
      End With
      cmbDepositoNuevo.SelectedIndex = 0
   End Sub
#End Region

#Region "Limpieza Campos"

#End Region

#Region "Eventos"
   Private Sub cmbDepositoNuevo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoNuevo.SelectedIndexChanged
      TryCatched(
         Sub()
            Dim dr = cmbDepositoNuevo.ItemSeleccionado(Of DataRow)()
            If dr IsNot Nothing Then
               _publicos.CargaComboUbicaciones(cmbUbicacionNuevo, dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdSucursal"))
               cmbUbicacionNuevo.SelectedIndex = 0
            End If
         End Sub)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(Sub()
                    With _Producto
                       .IdDeposito = Integer.Parse(cmbDepositoNuevo.SelectedValue.ToString())
                       .NombreDeposito = cmbDepositoNuevo.Text
                       .IdUbicacion = Integer.Parse(cmbUbicacionNuevo.SelectedValue.ToString())
                       .NombreUbicacion = cmbUbicacionNuevo.Text
                    End With
                    Close(DialogResult.OK)
                 End Sub)
   End Sub

#End Region
End Class