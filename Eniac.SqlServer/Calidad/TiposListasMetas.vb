Public Class TiposListasMetas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposListasMetas_I(IdListaControlTipo As Integer,
                                  Dia As Date,
                                  MetaCoches As Integer,
                                  IdUsuario As String,
                                  FechaModificacion As DateTime)


      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO CalidadMetasTiposListas ({0}, {1}, {2}, {3}, {4})",
                       Entidades.TipoListaMeta.Columnas.IdListaControlTipo.ToString(),
                       Entidades.TipoListaMeta.Columnas.Dia.ToString(),
                       Entidades.TipoListaMeta.Columnas.MetaCoches.ToString(),
                       Entidades.TipoListaMeta.Columnas.IdUsuario.ToString(),
                       Entidades.TipoListaMeta.Columnas.FechaModificacion.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}',{2} ,'{3}', '{4}')",
                       IdListaControlTipo, Dia, MetaCoches, IdUsuario, ObtenerFecha(FechaModificacion, True))
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposListasMetas_U(IdListaControlTipo As Integer,
                                  Dia As Date,
                                  MetaCoches As Integer,
                                  IdUsuario As String,
                                  FechaModificacion As DateTime)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE CalidadMetasTiposListas ")
         .AppendFormat("   SET {0} = {1}", Entidades.TipoListaMeta.Columnas.MetaCoches.ToString(), MetaCoches).AppendLine()
         .AppendFormat("   , {0} = '{1}'", Entidades.TipoListaMeta.Columnas.IdUsuario.ToString(), IdUsuario).AppendLine()
         .AppendFormat("   , {0} = '{1}'", Entidades.TipoListaMeta.Columnas.FechaModificacion.ToString(), FechaModificacion).AppendLine()
         .AppendFormat(" WHERE {0} = {1}", Entidades.TipoListaMeta.Columnas.IdListaControlTipo.ToString(), IdListaControlTipo)
         .AppendFormat("   AND {0} = '{1}'", Entidades.TipoListaMeta.Columnas.Dia.ToString(), Dia)

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposListasMetas_D(IdListaControlTipo As Integer,
                                 Dia As Date)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadMetasTiposListas ")
         .AppendFormat(" WHERE {0} = {1}", Entidades.TipoListaMeta.Columnas.IdListaControlTipo.ToString(), IdListaControlTipo)
         .AppendFormat("   AND {0} = '{1}'", Entidades.TipoListaMeta.Columnas.Dia.ToString(), Dia)

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
         .AppendFormat("SELECT CML.*, CT.NombreListaControlTipo
                        FROM CalidadMetasTiposListas AS CML
                        LEFT JOIN CalidadListasControlTipos AS CT ON CT.IdListaControlTipo = CML.IdListaControlTipo  ")
      End With
   End Sub

   Public Function TiposListasMetas_GMetas(fechaDesde As Date, fechaHasta As Date) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         ' .AppendFormat(" WHERE LCU.{0} = {1}", Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString(), idModelo)

         .AppendFormat(" ORDER BY CT.NombreListaControlTipo, CML.Dia")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposListasMetas_GMetasTotalPorMes(IdListaControlTipo As Integer, fechaDesde As Date, fechaHasta As Date) As Integer
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine(" SELECT SUM(MetaCoches)  As TotMetas  FROM CalidadMetasTiposListas AS CML")

         .AppendFormat(" WHERE CML.{0} >= '{1}'", Entidades.TipoListaMeta.Columnas.Dia.ToString(), fechaDesde.ToStringFormatoPropio)
         .AppendFormat(" AND CML.{0} <= '{1}'", Entidades.TipoListaMeta.Columnas.Dia.ToString(), fechaHasta.ToStringFormatoPropio)
         .AppendFormat(" AND CML.{0} = {1}", Entidades.TipoListaMeta.Columnas.IdListaControlTipo.ToString(), IdListaControlTipo)
      End With
      Dim Totales As DataTable = Me.GetDataTable(myQuery.ToString())
      Dim val As Integer = 0
      If Totales.Count <> 0 Then
         If Not String.IsNullOrEmpty(Totales.Rows(0).Item("TotMetas").ToString()) Then
            val = Integer.Parse(Totales.Rows(0).Item("TotMetas").ToString())
         End If
      End If
      Return val
   End Function

   Public Function TiposListasMetas_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         ' .AppendFormat(" WHERE LCU.{0} = {1}", Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString(), idModelo)

         .AppendFormat(" ORDER BY CT.NombreListaControlTipo, CML.Dia")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposListasMetas_G1(IdListaControlTipo As Integer,
                                  Dia As Date) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE CML.{0} = {1}", Entidades.TipoListaMeta.Columnas.IdListaControlTipo.ToString(), IdListaControlTipo)
         .AppendFormat("   AND CML.{0} = '{1}'", Entidades.TipoListaMeta.Columnas.Dia.ToString(), Dia)

         ' .AppendFormat(" ORDER BY LCU.IdListaControl")
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