Public Class TiposListasProductosProgramacion
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposListasProductosProgramacion_I(IdListaControlTipo As Integer,
                                  Dia As Date,
                                  IdProducto As String,
                                  IdUsuario As String,
                                  FechaModificacion As DateTime)


      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO CalidadProgramacionProduccion ({0}, {1}, {2}, {3}, {4})",
                       Entidades.TipoListaProductoProgramacion.Columnas.IdListaControlTipo.ToString(),
                       Entidades.TipoListaProductoProgramacion.Columnas.Dia.ToString(),
                       Entidades.TipoListaProductoProgramacion.Columnas.IdProducto.ToString(),
                       Entidades.TipoListaProductoProgramacion.Columnas.IdUsuario.ToString(),
                       Entidades.TipoListaProductoProgramacion.Columnas.FechaModificacion.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}','{2}' ,'{3}', '{4}')",
                       IdListaControlTipo, Dia, IdProducto, IdUsuario, ObtenerFecha(FechaModificacion, True))
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposListasProductosProgramacion_U(IdListaControlTipo As Integer,
                                  Dia As Date,
                                  IdProducto As String,
                                  IdUsuario As String,
                                  FechaModificacion As DateTime)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         '.AppendLine("UPDATE CalidadMetasTiposListas ")
         '.AppendFormat("   SET {0} = {1}", Entidades.TipoListaProductoProgramacion.Columnas.MetaCoches.ToString(), MetaCoches).AppendLine()
         '.AppendFormat("   , {0} = '{1}'", Entidades.TipoListaProductoProgramacion.Columnas.IdUsuario.ToString(), IdUsuario).AppendLine()
         '.AppendFormat("   , {0} = '{1}'", Entidades.TipoListaProductoProgramacion.Columnas.FechaModificacion.ToString(), FechaModificacion).AppendLine()
         '.AppendFormat(" WHERE {0} = {1}", Entidades.TipoListaProductoProgramacion.Columnas.IdListaControlTipo.ToString(), IdListaControlTipo)
         '.AppendFormat("   AND {0} = '{1}'", Entidades.TipoListaProductoProgramacion.Columnas.Dia.ToString(), Dia)
         '.AppendFormat("   AND {0} = '{1}'", Entidades.TipoListaProductoProgramacion.Columnas.IdProducto.ToString(), IdProducto)

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposListasProductosProgramacion_D(IdListaControlTipo As Integer,
                                 Dia As Date, IdProducto As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadProgramacionProduccion ")
         .AppendFormat(" WHERE {0} = {1}", Entidades.TipoListaProductoProgramacion.Columnas.IdListaControlTipo.ToString(), IdListaControlTipo)
         .AppendFormat("   AND {0} = '{1}'", Entidades.TipoListaProductoProgramacion.Columnas.Dia.ToString(), Dia.ToShortDateString)
         .AppendFormat("   AND {0} = '{1}'", Entidades.TipoListaProductoProgramacion.Columnas.IdProducto.ToString(), IdProducto)
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
         .AppendFormat("SELECT CPP.*, CT.NombreListaControlTipo, P.NombreProducto,  CMT.NombreProductoModeloTipo
                        FROM CalidadProgramacionProduccion AS CPP
                        INNER JOIN Productos P ON P.IdProducto = CPP.IdProducto 
                        LEFT JOIN CalidadListasControlTipos AS CT ON CT.IdListaControlTipo = CPP.IdListaControlTipo 
                     LEFT JOIN CalidadProductosModelos M ON M.IdProductoModelo = P.IdProductoModelo
					      LEFT JOIN CalidadProductosModelosTipos CMT ON CMT.IdProductoModeloTipo = M.IdProductoModeloTipo   ")
      End With
   End Sub

   Public Function TiposListasProductosProgramacion_GMetas(fechaDesde As Date, fechaHasta As Date) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         ' .AppendFormat(" WHERE LCU.{0} = {1}", Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString(), idModelo)

         .AppendFormat(" ORDER BY CT.NombreListaControlTipo, CML.Dia")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposListasProductosProgramacion_GMetasTotalPorMes(IdListaControlTipo As Integer,
                                                                      fechaDesde As Date, fechaHasta As Date,
                                                                      IdProductoModeloTipo As Integer) As Integer
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine(" SELECT count(CPP.idproducto)  As TotMetas  FROM CalidadProgramacionProduccion AS CPP
                       inner join Productos P ON P.IdProducto = CPP.IdProducto
                       inner join CalidadProductosModelos M ON M.IdProductoModelo = P.IdProductoModelo
                       inner join CalidadProductosModelosTipos MT ON MT.IdProductoModeloTipo = M.IdProductoModeloTipo")

         .AppendFormat(" WHERE CPP.{0} >= '{1}'", Entidades.TipoListaProductoProgramacion.Columnas.Dia.ToString(), fechaDesde.ToStringFormatoPropio)
         .AppendFormat(" AND CPP.{0} <= '{1}'", Entidades.TipoListaProductoProgramacion.Columnas.Dia.ToString(), fechaHasta.ToStringFormatoPropio)
         .AppendFormat(" AND CPP.{0} = {1}", Entidades.TipoListaProductoProgramacion.Columnas.IdListaControlTipo.ToString(), IdListaControlTipo)
         If IdProductoModeloTipo > 0 Then
            .AppendFormat("   AND MT.{0} = {1}", Entidades.ProductoModeloTipo.Columnas.IdProductoModeloTipo.ToString(), IdProductoModeloTipo)
         End If

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

   Public Function TiposListasProductosProgramacion_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         ' .AppendFormat(" WHERE LCU.{0} = {1}", Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString(), idModelo)

         .AppendFormat(" ORDER BY CT.NombreListaControlTipo, CPP.Dia")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposListasProductosProgramacion_GProgramacionTipoLista(IdListaControlTipo As Integer, Dia As Date) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE CPP.{0} = {1}", Entidades.TipoListaProductoProgramacion.Columnas.IdListaControlTipo.ToString(), IdListaControlTipo)
         .AppendFormat("   AND CPP.{0} = '{1}'", Entidades.TipoListaProductoProgramacion.Columnas.Dia.ToString(), Dia)

         .AppendFormat(" ORDER BY CT.NombreListaControlTipo, CPP.Dia")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposListasProductosProgramacion_G1(IdListaControlTipo As Integer,
                                  Dia As Date, IdProducto As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE CPP.{0} = {1}", Entidades.TipoListaProductoProgramacion.Columnas.IdListaControlTipo.ToString(), IdListaControlTipo)
         .AppendFormat("   AND CPP.{0} = '{1}'", Entidades.TipoListaProductoProgramacion.Columnas.Dia.ToString(), Dia)
         .AppendFormat("   AND CPP.{0} = '{1}'", Entidades.TipoListaProductoProgramacion.Columnas.IdProducto.ToString(), IdProducto)

         ' .AppendFormat(" ORDER BY LCU.IdListaControl")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposListasProductosProgramacion_GxTipoModelo(IdListaControlTipo As Integer,
                                  Dia As Date, IdProductoModeloTipo As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE CPP.{0} = {1}", Entidades.TipoListaProductoProgramacion.Columnas.IdListaControlTipo.ToString(), IdListaControlTipo)
         .AppendFormat("   AND CPP.{0} = '{1}'", Entidades.TipoListaProductoProgramacion.Columnas.Dia.ToString(), Dia)
         If IdProductoModeloTipo > 0 Then
            .AppendFormat("   AND CMT.{0} = {1}", Entidades.ProductoModeloTipo.Columnas.IdProductoModeloTipo.ToString(), IdProductoModeloTipo)
         End If

         ' .AppendFormat(" ORDER BY LCU.IdListaControl")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposListasProductosProgramacion_GInforme(idModelo As Integer, IdListaControl As Integer, IdProducto As String) As DataTable
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

   Public Function GetPanelProgramacionProduccion(idProducto As String, fechaDesde As DateTime?, fechaHasta As DateTime?,
                                                   fechaDesdeLiberado As DateTime?, fechaHastaLiberado As DateTime?,
                                                  idestadoCalidad As Integer, idCliente As Long, ubicacion As String,
                                                  liberados As Entidades.Publicos.SiNoTodos, entregados As Entidades.Publicos.SiNoTodos,
                                                  liberadosPDI As Entidades.Publicos.SiNoTodos, IdProductoModeloTipo As Integer,
                                                  pivotcolName As String, sumPivot As String, pivotcolName2 As String, sumPivot2 As String,
                                                  pivotcolName3 As String, sumPivot3 As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT P1.IdProducto, P1.Dia 
 	                       , P1.NombreProducto, P1.CalidadFechaLiberado, P1.NombreProductoModelo, P1.NombreProductoModeloTipo, P1.NombreProductoModeloSubTipo, P1.NombreCliente ")
         .AppendFormatLine("     , {0}", sumPivot.ToString())
         '.AppendFormatLine("     , {0}", sumPivot2.ToString())
         '.AppendFormatLine("     , {0}", sumPivot3.ToString())

         .AppendFormatLine("  FROM (SELECT CPP.Dia , CPP.FechaModificacion, CPP.IdProducto, CPP.IdProducto as Producto , P.CalidadFechaLiberado,
                     CPP.IdUsuario, CT.NombreListaControlTipo, P.NombreProducto, M.NombreProductoModelo, CMT.NombreProductoModeloTipo, CMST.NombreProductoModeloSubTipo, C.NombreCliente
					       , 'IdListaControlTipo__' + CONVERT(VARCHAR(MAX), CT.IdListaControlTipo) IdListaControlTipo 
                        FROM CalidadProgramacionProduccion AS CPP
                        INNER JOIN Productos P ON P.IdProducto = CPP.IdProducto 
                        LEFT JOIN CalidadListasControlTipos AS CT ON CT.IdListaControlTipo = CPP.IdListaControlTipo 
                        LEFT JOIN CalidadProductosModelos M ON M.IdProductoModelo = P.IdProductoModelo
					         LEFT JOIN CalidadProductosModelosTipos CMT ON CMT.IdProductoModeloTipo = M.IdProductoModeloTipo
                        LEFT JOIN CalidadProductosModelosSubTipos CMST ON CMST.IdProductoModeloSubTipo = M.IdProductoModeloSubTipo 
               	      LEFT JOIN ProductosClientes PC ON PC.IdProducto = P.IdProducto 
                        LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente ")

         .AppendLine("   WHERE 1 = 1")
         .AppendLine("   AND P.IdProducto not LIKE '%R%'")
         '.AppendLine("    AND P.CalidadFechaIngreso is not null")
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("           AND P.IdProducto = '{0}'", idProducto)
         End If

         'If fechaDesde.HasValue Then
         '   .AppendFormat("	   AND P.CalidadFechaIngreso >= '{0}'", ObtenerFecha(fechaDesde.Value, False))
         'End If
         'If fechaHasta.HasValue Then
         '   .AppendFormat("      AND P.CalidadFechaIngreso <= '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia, True))
         'End If

         If fechaDesdeLiberado.HasValue Then
            .AppendFormat("	   AND P.CalidadFechaLiberado >= '{0}'", ObtenerFecha(fechaDesdeLiberado.Value, False))
         End If
         If fechaHastaLiberado.HasValue Then
            .AppendFormat("      AND P.CalidadFechaLiberado <= '{0}'", ObtenerFecha(fechaHastaLiberado.Value.UltimoSegundoDelDia, True))
         End If

         If IdProductoModeloTipo <> 0 Then
            .AppendFormatLine("     AND  CMT.IdProductoModeloTipo = {0}", IdProductoModeloTipo)
         End If


         If idestadoCalidad <> 0 Then
            .AppendFormat("     AND EXISTS (SELECT * FROM CalidadListasControlProductos PS1 WHERE PS1.IdProducto = PS.IdProducto AND PS1.IdEstadoCalidad = {0})", idestadoCalidad)
         End If
         If liberados <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("           AND P.CalidadStatusLiberado = '{0}'", liberados = Entidades.Publicos.SiNoTodos.SI)
         End If
         If entregados <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("           AND P.CalidadStatusEntregado = '{0}'", entregados = Entidades.Publicos.SiNoTodos.SI)
         End If

         If liberadosPDI <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("           AND P.CalidadStatusLiberadoPDI = '{0}'", liberadosPDI = Entidades.Publicos.SiNoTodos.SI)
         End If

         If idCliente <> 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", idCliente)
         End If
         If Not String.IsNullOrEmpty(ubicacion) Then
            .AppendFormatLine(" AND PSU.Ubicacion = '{0}'", ubicacion)
         End If


         .AppendFormatLine("        ) P")
         .AppendFormatLine("   PIVOT(MIN(Producto) FOR P.IdListaControlTipo in ({0})) AS P1", pivotcolName)
         .AppendFormatLine(" WHERE 1 = 1")
         If fechaDesde.HasValue Then
            .AppendFormat("	   AND  P1.Dia >= '{0}'", ObtenerFecha(fechaDesde.Value, False))
         End If
         If fechaHasta.HasValue Then
            .AppendFormat("      AND  P1.Dia <= '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia, True))
         End If
         ' .AppendFormatLine(" Where p1.IdListaControlTipo__1 <> ''")
         .AppendFormatLine("     GROUP BY P1.IdProducto, P1.Dia 
 	                       , P1.NombreProducto, P1.CalidadFechaLiberado, P1.NombreProductoModelo, P1.NombreProductoModeloTipo, P1.NombreProductoModeloSubTipo, P1.NombreCliente ")
         .AppendLine("  ORDER BY P1.Dia ASC")
      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetPanelProgramacionProduccionxFechas(idProducto As String, fechaDesde As DateTime?, fechaHasta As DateTime?,
                                                  fechaDesdeLiberado As DateTime?, fechaHastaLiberado As DateTime?,
                                                 idestadoCalidad As Integer, idCliente As Long, ubicacion As String,
                                                 liberados As Entidades.Publicos.SiNoTodos, entregados As Entidades.Publicos.SiNoTodos,
                                                 liberadosPDI As Entidades.Publicos.SiNoTodos, IdProductoModeloTipo As Integer,
                                                 pivotcolName As String, sumPivot As String, pivotcolName2 As String, sumPivot2 As String,
                                                 pivotcolName3 As String, sumPivot3 As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT P1.IdProducto, P1.NombreProducto, P1.NombreProductoModeloTipo  ,P1.NombreCliente ")
         .AppendFormatLine("     , {0}", sumPivot.ToString())
         '.AppendFormatLine("     , {0}", sumPivot2.ToString())
         '.AppendFormatLine("     , {0}", sumPivot3.ToString())

         .AppendFormatLine("  FROM (SELECT CPP.Dia , CPP.FechaModificacion, CPP.IdProducto,  
                     CPP.IdUsuario, CT.NombreListaControlTipo, P.NombreProducto,  CMT.NombreProductoModeloTipo, C.NombreCliente
					       , 'IdListaControlTipo__' + CONVERT(VARCHAR(MAX), CT.IdListaControlTipo) IdListaControlTipo 
                        FROM CalidadProgramacionProduccion AS CPP
                        INNER JOIN Productos P ON P.IdProducto = CPP.IdProducto 
                        LEFT JOIN CalidadListasControlTipos AS CT ON CT.IdListaControlTipo = CPP.IdListaControlTipo 
                        LEFT JOIN CalidadProductosModelos M ON M.IdProductoModelo = P.IdProductoModelo
					         LEFT JOIN CalidadProductosModelosTipos CMT ON CMT.IdProductoModeloTipo = M.IdProductoModeloTipo
                   	   LEFT JOIN ProductosClientes PC ON PC.IdProducto = P.IdProducto 
                        LEFT JOIN Clientes C ON C.IdCliente = PC.IdCliente ")

         .AppendLine("   WHERE 1 = 1")
         .AppendLine("   AND P.IdProducto not LIKE '%R%'")
         If fechaDesde.HasValue Then
            .AppendFormat("	   AND  CPP.Dia >= '{0}'", ObtenerFecha(fechaDesde.Value, False))
         End If
         If fechaHasta.HasValue Then
            .AppendFormat("      AND  CPP.Dia <= '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia, True))
         End If

         '.AppendLine("    AND P.CalidadFechaIngreso is not null")
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("           AND P.IdProducto = '{0}'", idProducto)
         End If

         'If fechaDesde.HasValue Then
         '   .AppendFormat("	   AND P.CalidadFechaIngreso >= '{0}'", ObtenerFecha(fechaDesde.Value, False))
         'End If
         'If fechaHasta.HasValue Then
         '   .AppendFormat("      AND P.CalidadFechaIngreso <= '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia, True))
         'End If

         If fechaDesdeLiberado.HasValue Then
            .AppendFormat("	   AND P.CalidadFechaLiberado >= '{0}'", ObtenerFecha(fechaDesdeLiberado.Value, False))
         End If
         If fechaHastaLiberado.HasValue Then
            .AppendFormat("      AND P.CalidadFechaLiberado <= '{0}'", ObtenerFecha(fechaHastaLiberado.Value.UltimoSegundoDelDia, True))
         End If

         If IdProductoModeloTipo <> 0 Then
            .AppendFormatLine("     AND  CMT.IdProductoModeloTipo = {0}", IdProductoModeloTipo)
         End If


         If idestadoCalidad <> 0 Then
            .AppendFormat("     AND EXISTS (SELECT * FROM CalidadListasControlProductos PS1 WHERE PS1.IdProducto = PS.IdProducto AND PS1.IdEstadoCalidad = {0})", idestadoCalidad)
         End If
         If liberados <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("           AND P.CalidadStatusLiberado = '{0}'", liberados = Entidades.Publicos.SiNoTodos.SI)
         End If
         If entregados <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("           AND P.CalidadStatusEntregado = '{0}'", entregados = Entidades.Publicos.SiNoTodos.SI)
         End If

         If liberadosPDI <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("           AND P.CalidadStatusLiberadoPDI = '{0}'", liberadosPDI = Entidades.Publicos.SiNoTodos.SI)
         End If

         If idCliente <> 0 Then
            .AppendFormatLine("           AND C.IdCliente = {0}", idCliente)
         End If
         If Not String.IsNullOrEmpty(ubicacion) Then
            .AppendFormatLine(" AND PSU.Ubicacion = '{0}'", ubicacion)
         End If


         .AppendFormatLine("        ) P")
         .AppendFormatLine("   PIVOT(MIN(Dia) FOR P.IdListaControlTipo in ({0})) AS P1", pivotcolName)
         .AppendFormatLine(" WHERE 1 = 1")
         ' .AppendFormatLine(" Where p1.IdListaControlTipo__1 <> ''")
         .AppendFormatLine("     GROUP BY P1.IdProducto, P1.NombreProducto, P1.NombreProductoModeloTipo  ,P1.NombreCliente ")
         .AppendLine("  ORDER BY P1.IdProducto ASC")
      End With

      Return GetDataTable(stb.ToString())
   End Function

End Class