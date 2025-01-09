Public Class ProductosLotesDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.ProductoSucursal)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Dim dtProductos As DataTable
      Dim oProductos As Reglas.Productos = New Reglas.Productos()
      dtProductos = oProductos.GetAll()

      Dim dtSucursales As DataTable
      Dim oSucursales As Reglas.Sucursales = New Reglas.Sucursales()
      dtSucursales = oSucursales.GetAll()

      For Each dr As DataRow In dtProductos.Rows
         dr("IdProducto") = dr("IdProducto").ToString().Trim()
      Next

      With Me.cmbProducto
         .DisplayMember = "NombreProducto"
         .ValueMember = "IdProducto"
         .DataSource = dtProductos
         .SelectedIndex = -1
      End With

      With Me.cmbSucursal
         .DisplayMember = "Nombre"
         .ValueMember = "IdSucursal"
         .DataSource = dtSucursales.Copy()
         .SelectedIndex = -1
      End With

      Me.BindearControles(Me._entidad)
   End Sub
 

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Me.cmbProducto.Focus()
   End Sub

#End Region

End Class
