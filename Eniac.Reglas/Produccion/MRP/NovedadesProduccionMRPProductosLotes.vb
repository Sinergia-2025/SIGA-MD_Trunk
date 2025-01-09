Public Class NovedadesProduccionMRPProductosLotes
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.NovedadProduccionMRPProductoLote.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides/Overloads"
   '-- Con Transaccion.- -----------------------------------------------------------------------------
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.NovedadProduccionMRPProductoLote)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.NovedadProduccionMRPProductoLote)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.NovedadProduccionMRPProductoLote)))
   End Sub
   <Obsolete("Usar GetAll(Integer, String, String)", True)>
   Public Overrides Function GetAll() As DataTable
      Return MyBase.GetAll()
   End Function
   Public Overloads Function GetAll(numeroNovedadesProducccion As Integer, codigoOperacion As String, idProducto As String) As DataTable
      Return GetSql().NovedadesProduccionMRPProductosLotes_GA(numeroNovedadesProducccion, codigoOperacion, idProducto)
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.NovedadesProduccionMRPProductosLotes
      Return New SqlServer.NovedadesProduccionMRPProductosLotes(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.NovedadProduccionMRPProductoLote, tipo As TipoSP)
      Dim sqlC = GetSql()
      Select Case tipo
         Case TipoSP._I
            '-- Inserta Procesos Productivos Operaciones.- --------
            sqlC.NovedadesProduccionMRPProductosLotes_I(en.NumeroNovedadesProducccion, en.CodigoOperacion, en.IdProducto, en.EsProductoNecesario, en.IdLote, en.Cantidad)
      End Select
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.NovedadProduccionMRPProductoLote), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.NovedadProduccionMRPProductoLote), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.NovedadProduccionMRPProductoLote), TipoSP._D)
   End Sub
   Public Sub ActualizaNovedadesProductosLotes(entidad As Entidades.NovedadProduccionMRPProducto)
      If entidad.ProductosLotes IsNot Nothing Then
         '-- Elimina los Borrados.- --------------------------------------------------
         For Each ent In entidad.ProductosLotes.Borrados
            _Borrar(ent)
         Next
         '----------------------------------------------------------------------------
         For Each oPL In entidad.ProductosLotes
            If oPL.NumeroNovedadesProducccion = 0 Then
               oPL.NumeroNovedadesProducccion = entidad.NumeroNovedadesProducccion
               _Insertar(oPL)
               '-- Actualizo Productos Lotes.- -----------
               Dim actProd = New ProductosLotes(da)
               Dim pl1 = actProd._GetUno(oPL.IdProducto, oPL.IdLote, entidad.IdSucursal, entidad.IdDeposito, entidad.IdUbicacion)
               If pl1 Is Nothing Then
                  Dim pl As New Entidades.ProductoLote
                  With pl
                     .ProductoSucursal.Sucursal.IdSucursal = entidad.IdSucursal
                     .IdLote = oPL.IdLote
                     .ProductoSucursal.Producto.IdProducto = oPL.IdProducto
                     .IdDeposito = entidad.IdDeposito
                     .IdUbicacion = entidad.IdUbicacion
                     .FechaIngreso = Date.Today
                     .CantidadInicial = oPL.Cantidad
                     .CantidadActual = oPL.Cantidad
                     .PrecioCosto = New Reglas.Productos().GetUno(oPL.IdProducto, False, True).PrecioCosto
                     .Habilitado = True
                  End With
                  actProd.EjecutaSP(pl, TipoSP._I)
               Else
                  actProd.ProductosLotes_UCantidad_Delta(oPL.IdLote, entidad.IdSucursal, oPL.IdProducto, If(entidad.EsProductoNecesario, (oPL.Cantidad * -1), oPL.Cantidad))
               End If
            End If
         Next
         '----------------------------------------------------------------------------
      End If
   End Sub
#End Region
End Class