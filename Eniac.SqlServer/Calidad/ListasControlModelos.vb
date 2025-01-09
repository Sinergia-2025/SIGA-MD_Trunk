Public Class ListasControlModelos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ListasControlModelos_I(IdProductoModelo As Integer,
                                      idListaControl As Integer,
                                        fecha As DateTime,
                                       IdUsuario As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO CalidadListasControlProductosModelos ({0}, {1}, {2}, {3})",
                       Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString(),
                       Entidades.ListaControlModelo.Columnas.IdListaControl.ToString(),
                       Entidades.ListaControlProducto.Columnas.fecha.ToString(),
                       Entidades.ListaControlProducto.Columnas.Idusuario.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, {1},'{2}' ,'{3}')",
                       IdProductoModelo, idListaControl, ObtenerFecha(fecha, True), IdUsuario)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlModelos_U(IdProductoModelo As Integer,
                                      idListaControl As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      'With myQuery
      '   .AppendLine("UPDATE CalidadListasControlProductosModelos ")
      '   .AppendFormat("   SET {0} = '{1}'", Entidades.ListaControlModelo.Columnas.IdRol.ToString(), idUsuario).AppendLine()
      '   .AppendFormat(" WHERE {0} = {1}", Entidades.ListaControlModelo.Columnas.IdListaControl.ToString(), idListaControl)

      'End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlModelos_D(idProductoModelo As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadListasControlProductosModelos ")
         .AppendFormat(" WHERE {0} = {1}", Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString(), idProductoModelo)

      End With

      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub ListasControlModelos_D(idProductoModelo As Integer, idListaControl As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadListasControlProductosModelos ")
         .AppendFormat(" WHERE {0} = {1}", Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString(), idProductoModelo)
         .AppendFormat(" AND {0} = '{1}'", Entidades.ListaControlModelo.Columnas.IdListaControl.ToString(), idListaControl)

      End With

      Me.Execute(myQuery.ToString())
   End Sub
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT LCU.*, U.NombreProductoModelo, LC.NombreListaControl , LC.Orden FROM CalidadListasControlProductosModelos AS LCU").AppendLine()
         .AppendFormat("  LEFT JOIN CalidadProductosModelos AS U ON U.IdProductoModelo = LCU.IdProductoModelo ")
         .AppendFormat(" LEFT JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl")
      End With
   End Sub

   Public Function ListasControlModelos_GA(idModelo As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE LCU.{0} = {1}", Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString(), idModelo)

         .AppendFormat(" ORDER BY LC.Orden")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlModelos_G1(IdProductoModelo As Integer, idListaControl As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE LCU.{0} = {1}", Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString(), IdProductoModelo)
         .AppendFormat(" AND LCU.{0} = '{1}'", Entidades.ListaControlModelo.Columnas.IdListaControl.ToString(), idListaControl)

         .AppendFormat(" ORDER BY LCU.IdListaControl")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlModelos_GInforme(idModelo As Integer, IdListaControl As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE 1= 1")
         If idModelo > 0 Then
            .AppendFormat(" AND LCU.{0} = {1}", Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString(), idModelo)
         End If
         If IdListaControl > 0 Then
            .AppendFormat(" AND LCU.{0} = {1}", Entidades.ListaControlModelo.Columnas.IdListaControl.ToString(), IdListaControl)
         End If

         .AppendFormat(" ORDER BY U.NombreProductoModelo, LC.Orden")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function


End Class