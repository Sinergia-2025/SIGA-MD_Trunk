Public Class IngresoNumerosSerie

   Private _cantidadDeProductos As Integer
   Private _producto As Entidades.Producto

   Private _IdDeposito As Integer = 0
   Private _IdUbicacion As Integer = 0

   Private _productosNrosSerie As List(Of Entidades.ProductoNroSerie)
   'Private _nrosSerie As List(Of Entidades.ProductoNroSerie)
   Private _totalNroSerie As List(Of Entidades.ProductoNroSerie)
   Private _validar As Boolean = True
   'Private _editarNroSerie As List(Of Entidades.ProductoNroSerie)
   Private _titProductos As Dictionary(Of String, String)

   Public ReadOnly Property ProductosNrosSerie() As List(Of Entidades.ProductoNroSerie)
      Get
         Return _productosNrosSerie
      End Get
   End Property

   Public Sub New(cantidadDeProductos As Integer, producto As Entidades.Producto, TotalNroSerie As List(Of Entidades.ProductoNroSerie), Ver As Boolean, idDeposito As Integer, IdUbicacion As Integer)
      MyBase.New()
      InitializeComponent()
      TryCatched(
      Sub()
         _cantidadDeProductos = cantidadDeProductos
         _producto = producto

         _titProductos = GetColumnasVisiblesGrilla(dgvNrosSerie)

         If producto.NrosSeries.Count = 0 Then

            _productosNrosSerie = New List(Of Entidades.ProductoNroSerie)()

            'Me._nrosSerie = New List(Of Entidades.ProductoNroSerie)()

            If cantidadDeProductos < 4 Then
               Height = 250
            Else
               Height = 500
            End If

            lblProducto.Text = producto.NombreProducto

            _IdDeposito = idDeposito
            _IdUbicacion = IdUbicacion

            AgregarNros(cantidadDeProductos)
            'For i As Int32 = 0 To cantidadDeProductos - 1
            '   pns = New Entidades.ProductoNroSerie()
            '   pns.Producto = producto
            '   pns.Vendido = False
            '   pns.Sucursal.IdSucursal = Entidades.Usuario.Actual.Sucursal.IdSucursal
            '   Me._productosNrosSerie.Add(pns)
            '   'Me._nrosSerie.Add(pns)
            'Next

            dgvNrosSerie.DataSource = _productosNrosSerie.ToArray()
         Else
            'si vengo a editar los numeros de serie elimino o agrego el ultimo
            'si cambie la cantidad de numeros de serie
            If producto.NrosSeries.Count = cantidadDeProductos Then
               _productosNrosSerie = producto.NrosSeries.ToList()
               dgvNrosSerie.DataSource = _productosNrosSerie.ToArray()
            ElseIf producto.NrosSeries.Count < cantidadDeProductos Then
               _productosNrosSerie = producto.NrosSeries.ToList()
               AgregarNros(cantidadDeProductos - producto.NrosSeries.Count)
               dgvNrosSerie.DataSource = _productosNrosSerie.ToArray()
            Else 'aca es menor la cantidad que puse y elimino el ultimo
               _productosNrosSerie = producto.NrosSeries.ToList()
               EliminarNros(producto.NrosSeries.Count - 1, cantidadDeProductos)
               dgvNrosSerie.DataSource = _productosNrosSerie.ToArray()
            End If

         End If
         _totalNroSerie = TotalNroSerie

         dgvNrosSerie.Columns(0).ReadOnly = False
         _validar = Not Ver      'Si vengo del boton ver, no permito modificar los valores y no valido cambios
         If Ver Then
            dgvNrosSerie.Columns("colNumero").ReadOnly = True
         End If

         '# Ajuste de visibilidad de las columnas
         AjustarColumnasGrilla(dgvNrosSerie, _titProductos)
      End Sub)
   End Sub

   Private Sub EliminarNros(desde As Integer, hasta As Integer)
      For i = desde To hasta Step -1
         _productosNrosSerie.RemoveAt(i)
      Next
   End Sub

   Private Sub AgregarNros(canti As Integer)
      Dim pns As Entidades.ProductoNroSerie
      For i = 0 To canti - 1
         pns = New Entidades.ProductoNroSerie With {
            .Producto = _producto,
            .Vendido = False,
            .Sucursal = New Entidades.Sucursal() With {.IdSucursal = actual.Sucursal.IdSucursal},
            .IdDeposito = _IdDeposito,
            .IdUbicacion = _IdUbicacion
         }
         _productosNrosSerie.Add(pns)
      Next
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
      Sub()
         For Each ns In _productosNrosSerie
            If ns.NroSerie Is Nothing Then
               ShowMessage("Un número de serie no puede ser vacio.")
               Exit Sub
            End If
            'Se agrego la validacion a la grilla.
            If ns.NroSerie.Length > 50 Then
               ShowMessage(String.Format("El Número de serie '{0}', tiene mas de 50 caracteres.", ns.NroSerie))
               ShowMessage("Un número de serie tiene mas de 50 caracteres.")
               Exit Sub
            End If
         Next

         Dim cant = 0
         For Each ns In _productosNrosSerie
            For Each ns1 In _productosNrosSerie
               If ns.NroSerie.Trim() = ns1.NroSerie.Trim() Then
                  cant = cant + 1
                  If cant > 1 Then
                     ShowMessage(String.Format("El nro de serie esta repetido: {0}", ns.NroSerie.Trim()))
                     Exit Sub
                  End If
               End If
            Next
            cant = 0
         Next

         If _validar Then
            For Each ns In _productosNrosSerie
               For Each ns2 In _totalNroSerie
                  If ns.Producto.IdProducto.Trim() = ns2.Producto.IdProducto.Trim() AndAlso String.Compare(ns.NroSerie.Trim(), ns2.NroSerie.Trim()) = 0 Then
                     ShowMessage(String.Format("El nro de serie esta repetido: {0}", ns.NroSerie.Trim()))
                     Exit Sub
                  End If
               Next
            Next
         End If

         Close(DialogResult.OK)
      End Sub)
   End Sub

End Class