Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class TarifaSugerida

#Region "Campos"

   Private _publicos As Publicos

   Public _padre As System.Windows.Forms.Form
   Public _IdProductoPadre As String
   Public _cantDiasPadre As Integer

   Dim dtGrilla As DataTable

#End Region

   Public Property padre() As System.Windows.Forms.Form
      Get
         Return _padre
      End Get
      Set(ByVal value As System.Windows.Forms.Form)
         _padre = value
      End Set
   End Property

   Public Property IdProductoPadre() As String
      Get
         Return _IdProductoPadre
      End Get
      Set(ByVal value As String)
         _IdProductoPadre = value
      End Set
   End Property

   Public Property cantDiasPadre() As Integer
      Get
         Return _cantDiasPadre
      End Get
      Set(ByVal value As Integer)
         _cantDiasPadre = value
      End Set
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.AlquilerTarifaProducto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Dim otarifa As Reglas.AlquileresTarifasProductos = New Reglas.AlquileresTarifasProductos
      Dim dtaux As DataTable

      dtaux = otarifa.Get1(actual.Sucursal.IdSucursal, Me._IdProductoPadre)

      If dtaux.Rows.Count = 0 Then
         MessageBox.Show("No se encontraron Tarifas para el Producto seleccionado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.Close()
      End If

      Me.grdcostos.DataSource = dtaux

      buscarTarifa(dtaux)

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.AlquileresTarifasProductos
   End Function

   Private Sub buscarTarifa(ByVal dtaux As DataTable)
      Dim i As Integer = 0
      For Each fila As DataRow In dtaux.Rows
         i += 1
         If CInt(fila("cantdias")) = Me._cantDiasPadre Then
            Me.grdcostos.Rows(i - 1).DefaultCellStyle.ForeColor = Color.Red
         End If
      Next
   End Sub

   Private Function crearTablaGrilla() As DataTable
      Dim datosGrillas As New DataTable
      datosGrillas.Columns.Add("IdProducto", System.Type.GetType("System.Int32"))
      datosGrillas.Columns.Add("cantdias", System.Type.GetType("System.String"))
      datosGrillas.Columns.Add("PrecioAlquiler", System.Type.GetType("System.Decimal"))
      Return datosGrillas
   End Function

   Private Sub grdcostos_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdcostos.CellDoubleClick
      If (TypeOf (Me.padre) Is AlquilerDetalle) Then
         DirectCast(Me.padre, AlquilerDetalle)._tarifa = CDec(Me.grdcostos.Rows(e.RowIndex).Cells("PrecioAlquiler").Value)
         Me.Close()
      End If
   End Sub

End Class