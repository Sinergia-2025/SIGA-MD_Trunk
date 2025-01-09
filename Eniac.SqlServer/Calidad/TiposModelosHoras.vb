Public Class TiposModelosHoras
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposModelosHoras_I(IdListaControlTipo As Integer,
                                  IdProductoModelo As Integer,
                                  FechaHorasEstandar As DateTime,
                                  HorasEstandar As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO CalidadTiposModelosHorasEstandar ({0}, {1}, {2}, {3})",
                       Entidades.TipoModeloHora.Columnas.IdListaControlTipo.ToString(),
                       Entidades.TipoModeloHora.Columnas.IdProductoModelo.ToString(),
                       Entidades.TipoModeloHora.Columnas.FechaHorasEstandar.ToString(),
                       Entidades.TipoModeloHora.Columnas.HorasEstandar.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, {1},'{2}' ,{3})",
                       IdListaControlTipo, IdProductoModelo, ObtenerFecha(FechaHorasEstandar, True), HorasEstandar)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposModelosHoras_U(IdListaControlTipo As Integer,
                                  IdProductoModelo As Integer,
                                  FechaHorasEstandar As DateTime,
                                  HorasEstandar As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE CalidadTiposModelosHorasEstandar ")
         .AppendFormat("   SET {0} = {1}", Entidades.TipoModeloHora.Columnas.HorasEstandar.ToString(), HorasEstandar).AppendLine()
         .AppendFormat(" WHERE {0} = {1}", Entidades.TipoModeloHora.Columnas.IdListaControlTipo.ToString(), IdListaControlTipo)
         .AppendFormat("   AND {0} = {1}", Entidades.TipoModeloHora.Columnas.IdProductoModelo.ToString(), IdProductoModelo)
         .AppendFormat("   AND {0} = {1}", Entidades.TipoModeloHora.Columnas.FechaHorasEstandar.ToString(), FechaHorasEstandar)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposModelosHoras_D(IdListaControlTipo As Integer,
                                  IdProductoModelo As Integer,
                                  FechaHorasEstandar As DateTime)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadTiposModelosHorasEstandar ")
         .AppendFormat(" WHERE {0} = {1}", Entidades.TipoModeloHora.Columnas.IdListaControlTipo.ToString(), IdListaControlTipo)
         .AppendFormat("   AND {0} = {1}", Entidades.TipoModeloHora.Columnas.IdProductoModelo.ToString(), IdProductoModelo)
         .AppendFormat("   AND {0} = {1}", Entidades.TipoModeloHora.Columnas.FechaHorasEstandar.ToString(), FechaHorasEstandar)

      End With

      Me.Execute(myQuery.ToString())
   End Sub
   'Public Sub ListasControlModelos_D(idProductoModelo As Integer, idListaControl As Integer)
   '   Dim myQuery As StringBuilder = New StringBuilder()

   '   With myQuery
   '      .AppendLine("DELETE FROM CalidadListasControlProductosModelos ")
   '      .AppendFormat(" WHERE {0} = {1}", Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString(), idProductoModelo)
   '      .AppendFormat(" AND {0} = '{1}'", Entidades.ListaControlModelo.Columnas.IdListaControl.ToString(), idListaControl)

   '   End With

   '   Me.Execute(myQuery.ToString())
   'End Sub
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT LCU.*, U.NombreProductoModelo, LC.NombreListaControl , LC.Orden FROM CalidadListasControlProductosModelos AS LCU").AppendLine()
         .AppendFormat("  LEFT JOIN CalidadProductosModelos AS U ON U.IdProductoModelo = LCU.IdProductoModelo ")
         .AppendFormat(" LEFT JOIN CalidadListasControl AS LC ON LC.IdListaControl = LCU.IdListaControl")
      End With
   End Sub

   Public Function TiposModelosHoras_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         ' .AppendFormat(" WHERE LCU.{0} = {1}", Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString(), idModelo)

         .AppendFormat(" ORDER BY LC.Orden")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function LTiposModelosHoras_G1(IdProductoModelo As Integer, idListaControl As Integer) As DataTable
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