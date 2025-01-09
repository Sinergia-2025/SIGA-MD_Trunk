Public Class ProduccionProductosComp
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "ProduccionProductosComp"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overloads Function GetAll(idSucursal As Integer, idproduccion As Integer, orden As Integer, idProducto As String) As DataTable
      Return New SqlServer.ProduccionProductosComp(da).ProduccionProductosComponentes_GA(idSucursal, idproduccion, orden, idProducto)
   End Function

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.ProduccionProductoComp)))
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos(idSucursal As Integer, idproduccion As Integer, orden As Integer, idProducto As String) As List(Of Entidades.ProduccionProductoComp)
      Return CargaLista(GetAll(idSucursal, idproduccion, orden, idProducto),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProduccionProductoComp())
   End Function

   Public Sub _Insertar(entidad As Entidades.ProduccionProductoComp)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.ProduccionProductoComp, tipo As TipoSP)
      Dim sql = New SqlServer.ProduccionProductosComp(da)
      Dim rCompLote = New ProduccionProductosComponentesLotes(da)
      Dim rCompNroSerie = New ProduccionProductosComponentesNrosSerie(da)
      Select Case tipo
         Case TipoSP._I
            If Not en.Lotes.AnySecure() AndAlso Not String.IsNullOrWhiteSpace(en.IdLote) Then
               en.Lotes.Add(New Entidades.ProduccionProductoCompLote(en) With {
                                 .IdLote = en.IdLote,
                                 .Cantidad = en.Cantidad
                            })
            End If

            If en.SecuenciaFormula = 0 Then
               en.SecuenciaFormula = GetSecuenciaMaxima(en.IdSucursal, en.IdProduccion, en.Orden, en.IdProducto, en.IdProductoComponente) + 1
            End If

            sql.ProduccionProductosComp_I(en.IdSucursal, en.IdProduccion, en.Orden, en.IdProducto,
                                          en.IdDeposito, en.IdUbicacion,
                                          en.IdProductoElaborado, en.IdUnicoNodoProductoElaborado,
                                          en.IdProductoComponente, en.IdUnicoNodoProductoComponente,
                                          en.IdFormula, en.SecuenciaFormula,
                                          en.NombreProductoElaborado, en.NombreProductoComponente, en.NombreFormula,
                                          en.Cantidad, en.CantidadEnFormula,
                                          en.PrecioCosto, en.PrecioVenta, en.ImporteCosto, en.ImporteVenta,
                                          en.SegunCalculoForma, en.FormulaCalculoKilaje,
                                          en.IdMoneda) '', en.IdLote)

            rCompLote._Insertar(en)
            rCompNroSerie._Insertar(en)

         Case TipoSP._U
            Throw New NotImplementedException("El método UPDATE de la tabla ProduccionProductosComponentes no está implementado")

         Case TipoSP._D
            Throw New NotImplementedException("El método DELETE de la tabla ProduccionProductosComponentes no está implementado")

         Case TipoSP._M
            Throw New NotImplementedException("El método MERGE de la tabla ProduccionProductosComponentes no está implementado")

      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ProduccionProductoComp, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)("IdSucursal")
         .IdProduccion = dr.Field(Of Integer)("IdProduccion")
         .Orden = dr.Field(Of Integer)("Orden")
         .IdProducto = dr.Field(Of String)("IdProducto")

         .IdDeposito = dr.Field(Of Integer)("IdDeposito")
         .IdUbicacion = dr.Field(Of Integer)("IdUbicacion")

         .IdUnicoNodoProductoElaborado = dr.Field(Of String)("IdUnicoNodoProductoElaborado")
         .IdProductoElaborado = dr.Field(Of String)("IdProductoElaborado")
         .IdProductoComponente = dr.Field(Of String)("IdProductoComponente")
         .IdUnicoNodoProductoComponente = dr.Field(Of String)("IdUnicoNodoProductoComponente")
         .SecuenciaFormula = dr.Field(Of Integer)("SecuenciaFormula")

         .IdFormula = dr.Field(Of Integer)("IdFormula")

         .NombreProductoElaborado = dr.Field(Of String)("NombreProductoElaborado")
         .NombreProductoComponente = dr.Field(Of String)("NombreProductoComponente")
         .NombreFormula = dr.Field(Of String)("NombreFormula")

         .PrecioCosto = dr.Field(Of Decimal)("PrecioCosto")
         .PrecioVenta = dr.Field(Of Decimal)("PrecioVenta")
         .Cantidad = dr.Field(Of Decimal)("Cantidad")
         .CantidadEnFormula = dr.Field(Of Decimal)("CantidadEnFormula")

         .SegunCalculoForma = dr.Field(Of Boolean)("SegunCalculoForma")
         .ImporteCosto = dr.Field(Of Decimal)("ImporteCosto")
         .ImporteVenta = dr.Field(Of Decimal)("ImporteVenta")

         .FormulaCalculoKilaje = dr.Field(Of String)("FormulaCalculoKilaje")

         .IdMoneda = dr.Field(Of Integer?)("IdMoneda").IfNull()
         '.IdLote = dr.Field(Of String)("IdLote").IfNull()

         .IdDepositoDefecto = dr.Field(Of Integer)(Entidades.Producto.Columnas.IdDepositoDefecto.ToString())
         .IdUbicacionDefecto = dr.Field(Of Integer)(Entidades.Producto.Columnas.IdUbicacionDefecto.ToString())

         .Lotes = New ProduccionProductosComponentesLotes(da).GetTodos(.IdSucursal, .IdProduccion, .Orden, .IdProducto, .IdProductoComponente, .SecuenciaFormula)
         .NrosSerie = New ProduccionProductosComponentesNrosSerie(da).GetTodos(.IdSucursal, .IdProduccion, .Orden, .IdProducto, .IdProductoComponente, .SecuenciaFormula)

      End With
   End Sub

   Private Function GetSecuenciaMaxima(idSucursal As Integer, idProduccion As Integer, orden As Integer, idProducto As String, idProductoComponente As String) As Integer
      Return New SqlServer.ProduccionProductosComp(da).GetSecuenciaMaxima(idSucursal, idProduccion, orden, idProducto, idProductoComponente)
   End Function

#End Region

End Class