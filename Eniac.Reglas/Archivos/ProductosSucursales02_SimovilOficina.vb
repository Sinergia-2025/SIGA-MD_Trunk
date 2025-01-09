Partial Class ProductosSucursales

   'Se ejecuta desde afuera de siga. No eliminar.
   Public Sub AjustaStockDesdeSimovilOficina(idEjecucion As Guid)
      EjecutaConTransaccion(Sub() _AjustaStockDesdeSimovilOficina(idEjecucion, actual.Sucursal.Id))
   End Sub
   Public Sub _AjustaStockDesdeSimovilOficina(idEjecucion As Guid, idSucursal As Integer)
      Dim rAj = New SimovilOficina.AjustesStock(da)
      Dim ajs = rAj.GetTodos(idEjecucion, idSucursal)

      Dim rProductos = New Productos(da)
      For Each aj In ajs
         Try
            If Not rProductos.Existe(aj.IdProducto) Then
               Throw New Exception(String.Format("No existe producto con Id: {0}.", aj.IdProducto))
            End If
            rProductos._AjustarStock(aj.IdSucursal, aj.IdProducto, aj.Stock,
                                     metodoGrabacion:=Entidades.Entidad.MetodoGrabacion.Manual, idFuncion:=String.Empty)
            aj.Estado = Entidades.SimovilOficina.EstadosAjusteStock.PROCESADO
            rAj._Actualizar(aj)
         Catch ex As Exception
            aj.Estado = Entidades.SimovilOficina.EstadosAjusteStock.ERROR
            aj.MensajeError = ex.Message
            rAj._Actualizar(aj)
         End Try
      Next
   End Sub

End Class