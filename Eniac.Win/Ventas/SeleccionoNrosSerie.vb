Imports Infragistics.Win.UltraWinGrid
Public Class SeleccionoNrosSerie
   Private _titNumeroSerie As Dictionary(Of String, String)
   Private _cantidadDeProductos As Integer
   Private _producto As Entidades.Producto
   Private _productosNrosSerie As List(Of Entidades.ProductoNroSerie)
   Private _dtNroSerie As New DataTable
   Public _IdDeposito As Integer = 0
   Public _IdUbicacion As Integer = 0

   Public ReadOnly Property ProductosNrosSerie() As List(Of Entidades.ProductoNroSerie)
      Get
         Return _productosNrosSerie
      End Get
   End Property

   Public Sub New(ByVal cantidadDeProductos As Integer, ByVal producto As Entidades.Producto, ByVal dt As DataTable)
      MyBase.New()
      InitializeComponent()

      Me._productosNrosSerie = New List(Of Entidades.ProductoNroSerie)()

      Me._cantidadDeProductos = cantidadDeProductos
      Me._producto = producto

      Me.lblProducto.Text = producto.NombreProducto

      If Not dt.Columns.Contains("Selec") Then
         dt.Columns.Add("Selec", GetType(Boolean))
      End If
      For Each dr As DataRow In dt.Rows
         dr("Selec") = False
      Next

      _dtNroSerie = dt

      If producto.NrosSeries.Count > 0 Then
         For Each dr As DataRow In _dtNroSerie.Rows
            For Each ns As Entidades.ProductoNroSerie In producto.NrosSeries
               If dr.Field(Of String)("NroSerie") = ns.NroSerie Then
                  dr("Selec") = True
                  Exit For
               End If
            Next
         Next
      End If

   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me.ugNrosSerie.DataSource = _dtNroSerie
         ugNrosSerie.AgregarFiltroEnLinea({"NroSerie"})

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub


   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Try
         Dim cant As Integer = 0
         Dim pns As Entidades.ProductoNroSerie
         Me._productosNrosSerie.Clear()
         For Each dr As DataRow In DirectCast(Me.ugNrosSerie.DataSource, DataTable).Select("Selec = True")
            If cant <= Math.Abs(_cantidadDeProductos) Then
               pns = New Entidades.ProductoNroSerie()
               pns.Producto = Me._producto
               pns.Vendido = True
               pns.Sucursal = New Reglas.Sucursales().GetUna(Entidades.Usuario.Actual.Sucursal.IdSucursal, False)
               pns.IdDeposito = _IdDeposito
               pns.IdUbicacion = _IdUbicacion
               pns.NroSerie = dr.Field(Of String)(Entidades.ProductoNroSerie.Columnas.NroSerie.ToString())
               Me._productosNrosSerie.Add(pns)
               cant = cant + 1
            Else
               ShowMessage("Debe seleccionar solo " + Me._cantidadDeProductos.ToString() + " Nros. Serie.")
               Exit Sub
            End If
         Next

         If cant <> Math.Abs(Me._cantidadDeProductos) Then
            ShowMessage("La cantidad de Nros. de serie debe coincidir con la cantidad a vender")
            Exit Sub
         End If
         Me.DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

End Class