Public Class RecepcionNotasF
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RecepcionNotasF_I(ByVal idSucursal As Integer, _
                               ByVal nroNota As Integer, _
                               ByVal IdCliente As Long, _
                               ByVal nroOperacion As Integer, _
                               ByVal idProducto As String, _
                               ByVal fechaNota As Date, _
                               ByVal cantidadProductos As Double, _
                               ByVal costoReparacion As Double, _
                               ByVal defectoProducto As String, _
                               ByVal observacion As String, _
                               ByVal estaPrestado As Boolean, _
                               ByVal usuario As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .Append("INSERT INTO RecepcionNotasF")
         .Append("           (IdSucursal")
         .Append("           ,NroNota")
         .Append("           ,IdCliente")
         .Append("           ,NroOperacion")
         .Append("           ,IdProducto")
         .Append("           ,FechaNota")
         .Append("           ,CantidadProductos")
         .Append("           ,CostoReparacion")
         .Append("           ,DefectoProducto")
         .Append("           ,Observacion")
         .Append("           ,EstaPrestado")
         .Append("           ,Usuario )")
         .Append("     VALUES")
         .AppendFormat("           ({0}", idSucursal)
         .AppendFormat("           ,{0}", nroNota)
         .AppendFormat("           ,{0}", IdCliente)
         .AppendFormat("           ,{0}", nroOperacion)
         .AppendFormat("           ,'{0}'", idProducto)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaNota, True))
         .AppendFormat("           ,{0}", cantidadProductos)
         .AppendFormat("           ,{0}", costoReparacion)
         .AppendFormat("           ,'{0}'", defectoProducto)
         .AppendFormat("           ,'{0}'", observacion)
         .AppendFormat("           ,{0}", IIf(estaPrestado, 1, 0))
         .AppendFormat("           ,'{0}')", usuario)
      End With


      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "RecepcionNotasF")
   End Sub

   Public Sub RecepcionNotasF_U(ByVal idSucursal As Integer, _
                               ByVal nroNota As Integer, _
                               ByVal IdCliente As Long, _
                               ByVal nroOperacion As Integer, _
                               ByVal idProducto As String, _
                               ByVal fechaNota As Date, _
                               ByVal cantidadProductos As Double, _
                               ByVal costoReparacion As Double, _
                               ByVal defectoProducto As String, _
                               ByVal observacion As String, _
                               ByVal estaPrestado As Boolean, _
                               ByVal usuario As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .Append("UPDATE RecepcionNotasF ")
         .Append("     SET ")

         'Hay datos que no deberian cambiar, pero por ahora dejo todo.

         .AppendFormat("   IdCliente = {0}", IdCliente)
         .AppendFormat("  ,NroOperacion = {0}", nroOperacion)
         .AppendFormat("  ,IdProducto = '{0}'", idProducto)
         .AppendFormat("  ,FechaNota = '{0}'", Me.ObtenerFecha(fechaNota, True))
         .AppendFormat("  ,CantidadProductos = {0}", cantidadProductos)
         .AppendFormat("  ,CostoReparacion = {0}", costoReparacion)
         .AppendFormat("  ,DefectoProducto = '{0}'", defectoProducto)
         .AppendFormat("  ,Observacion = '{0}'", observacion)
         .AppendFormat("  ,EstaPrestado  = {0}", IIf(estaPrestado, 1, 0))
         .AppendFormat("  ,Usuario = '{0}'", usuario)

         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND NroNota = {0}", nroNota)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "RecepcionNotasF")

   End Sub


   Public Sub RecepcionNotasF_UPrestamo(ByVal idSucursal As Integer, _
                                       ByVal nroNota As Integer, _
                                       ByVal idProductoPrestado As String, _
                                       ByVal cantidadPrestada As Double, _
                                       ByVal observacionPrestamo As String, _
                                       ByVal estaPrestado As Boolean, _
                                       ByVal usuario As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("UPDATE RecepcionNotasF ")
         .Append("     SET ")
         .AppendFormat("            IdProductoPrestado = '{0}'", idProductoPrestado)
         .AppendFormat("           ,CantidadPrestada = {0}", cantidadPrestada)
         .AppendFormat("           ,ObservacionPrestamo = '{0}'", observacionPrestamo)
         If estaPrestado Then
            .AppendFormat("           ,EstaPrestado = 1")
         Else
            .AppendFormat("           ,EstaPrestado = 0")
         End If
         .AppendFormat("           ,Usuario = '{0}'", usuario)

         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND NroNota = {0}", nroNota)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "RecepcionNotasF")

   End Sub

   Public Sub RecepcionNotasF_UDevolucion(ByVal idSucursal As Integer, _
                                         ByVal nroNota As Integer, _
                                         ByVal observacionPrestamo As String, _
                                         ByVal estaPrestado As Boolean, _
                                         ByVal usuario As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("UPDATE RecepcionNotasF ")
         .Append("     SET ")
         .AppendFormat("            ObservacionPrestamo = '{0}'", observacionPrestamo)
         If estaPrestado Then
            .AppendFormat("           , EstaPrestado = 1")
         Else
            .AppendFormat("           , EstaPrestado = 0")
         End If
         .AppendFormat("           ,Usuario = '{0}'", usuario)

         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormat("   AND NroNota = {0}", nroNota)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "RecepcionNotasF")

   End Sub

End Class