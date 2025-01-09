Partial Class Sucursales
   Private Const EstadoVinculacion_Vinculado As String = "<-- Vinculado -->"
   Private Const EstadoVinculacion_CopiarEnAsociado As String = "Copiar -->"
   Private Const EstadoVinculacion_CopiarEnOrigen As String = "<-- Copiar"

   Public Function GetParaDesvincular(idSucursal As Integer) As DataSet
      Return EjecutaConConexion(Function() _GetParaDesvincular(idSucursal))
   End Function
   Public Function GetParaVincular(idSucursal As Integer, idSucursalAsociada As Integer) As DataSet
      Return EjecutaConConexion(Function() _GetParaVincular(idSucursal, idSucursalAsociada))
   End Function
   Public Sub DesvincularSucursales(idSucursal As Integer)
      EjecutaConTransaccion(Sub() _DesvincularSucursales(idSucursal))
   End Sub
   Public Sub VincularSucursales(idSucursal As Integer, idSucursalAsociada As Integer, ds As DataSet)
      EjecutaConTransaccion(Sub() _VincularSucursales(idSucursal, idSucursalAsociada, ds))
   End Sub
   Public Sub RecualculoStockParaRepararInconsistencias(idSucs As IEnumerable(Of Integer))
      EjecutaConTransaccion(Sub() _RecualculoStockParaRepararInconsistencias(idSucs))
   End Sub
   Public Sub ActualizaSucursalAsociada(idSucursal As Integer, sucursalAsociada As Integer)
      EjecutaConTransaccion(Sub() _ActualizaSucursalAsociada(idSucursal, sucursalAsociada))
   End Sub

   Private Function _GetParaDesvincular(idSucursal As Integer) As DataSet
      Dim sql = New SqlServer.Sucursales(da)
      Dim ds = New DataSet()

      ds.Tables.Add("Depositos", sql.GetParaDesvincular_Depositos(idSucursal))
      ds.Tables.Add("Ubicaciones", sql.GetParaDesvincular_Ubicaciones(idSucursal))

      ds.AddRelation("Depositos_Ubicaciones", {"IdSucursal", "IdDeposito"})

      Return ds
   End Function
   Private Function AgregarDepositoParaVincular(dtDepositos As DataTable, drDep As DataRow, drDepAsoc As DataRow) As DataRow

      If drDep IsNot Nothing AndAlso drDep.RowState = DataRowState.Deleted Then drDep = Nothing
      If drDepAsoc IsNot Nothing AndAlso drDepAsoc.RowState = DataRowState.Deleted Then drDepAsoc = Nothing

      If drDep Is Nothing AndAlso drDepAsoc Is Nothing Then Return Nothing

      Dim result = dtDepositos.Rows.Add(If(drDep Is Nothing, DBNull.Value, drDep("IdSucursal")),
                                        If(drDep Is Nothing, DBNull.Value, drDep("NombreSucursal")),
                                        If(drDep Is Nothing, DBNull.Value, drDep("IdDeposito")),
                                        If(drDep Is Nothing, DBNull.Value, drDep("CodigoDeposito")),
                                        If(drDep Is Nothing, DBNull.Value, drDep("NombreDeposito")),
                                        String.Empty,
                                        If(drDepAsoc Is Nothing, DBNull.Value, drDepAsoc("IdSucursal")),
                                        If(drDepAsoc Is Nothing, DBNull.Value, drDepAsoc("NombreSucursal")),
                                        If(drDepAsoc Is Nothing, DBNull.Value, drDepAsoc("IdDeposito")),
                                        If(drDepAsoc Is Nothing, DBNull.Value, drDepAsoc("CodigoDeposito")),
                                        If(drDepAsoc Is Nothing, DBNull.Value, drDepAsoc("NombreDeposito")))

      If drDep IsNot Nothing Then
         drDep.Delete()
         'drDep.Table.AcceptChanges()
      End If

      If drDepAsoc IsNot Nothing Then
         drDepAsoc.Delete()
         'drDepAsoc.Table.AcceptChanges()
      End If

      Return result
   End Function
   Public Function _GetParaVincular(idSucursal As Integer, idSucursalAsociada As Integer) As DataSet
      Dim sql = New SqlServer.Sucursales(da)
      Dim ds = New DataSet()

      Dim dtDepositos = sql.GetParaDesvincular_Depositos(-1)
      Dim dtUbicaciones = sql.GetParaDesvincular_Ubicaciones(-1)

      Using dtDep = New SucursalesDepositos(da).GetDeposito(idSucursal),
            dtDepAsoc = New SucursalesDepositos(da).GetDeposito(idSucursalAsociada),
            dtUbi = New SucursalesUbicaciones(da).GetSucursalDeposito(idDeposito:=0, idSucursal:=idSucursal),
            dtUbiAsoc = New SucursalesUbicaciones(da).GetSucursalDeposito(idDeposito:=0, idSucursal:=idSucursalAsociada)

         For Each tipo In Entidades.Publicos.EnumToArray(Of Entidades.SucursalDeposito.TiposDepositos)

            If dtDep.Count(Function(dr) dr.RowState <> DataRowState.Deleted AndAlso dr.Field(Of String)("TipoDeposito") = tipo.ToString()) = 1 And
               dtDepAsoc.Count(Function(dr) dr.RowState <> DataRowState.Deleted AndAlso dr.Field(Of String)("TipoDeposito") = tipo.ToString()) = 1 Then
               Dim drDep = dtDep.First(Function(dr) dr.RowState <> DataRowState.Deleted AndAlso dr.Field(Of String)("TipoDeposito") = tipo.ToString())
               Dim drDepAsoc = dtDepAsoc.First(Function(dr) dr.RowState <> DataRowState.Deleted AndAlso dr.Field(Of String)("TipoDeposito") = tipo.ToString())

               AgregarDepositoParaVincular(dtDepositos, drDep, drDepAsoc)

            Else
               For Each drDep In dtDep.AsEnumerable().Where(Function(dr) dr.RowState <> DataRowState.Deleted AndAlso dr.Field(Of String)("TipoDeposito") = tipo.ToString())
                  Dim drDepAsoc = dtDepAsoc.FirstOrDefault(Function(dr) dr.RowState <> DataRowState.Deleted AndAlso
                                                                        dr.Field(Of String)("CodigoDeposito") = drDep.Field(Of String)("CodigoDeposito") And
                                                                        dr.Field(Of String)("TipoDeposito") = tipo.ToString())
                  If drDepAsoc Is Nothing Then
                     drDepAsoc = dtDepAsoc.FirstOrDefault(Function(dr) dr.RowState <> DataRowState.Deleted AndAlso
                                                                       dr.Field(Of String)("NombreDeposito") = drDep.Field(Of String)("NombreDeposito") And
                                                                       dr.Field(Of String)("TipoDeposito") = tipo.ToString())
                  End If

                  If drDepAsoc IsNot Nothing Then
                     AgregarDepositoParaVincular(dtDepositos, drDep, drDepAsoc)
                  End If
                  dtDepAsoc.AcceptChanges()
               Next
               dtDep.AcceptChanges()
            End If
         Next

         For Each drDep In dtDep.AsEnumerable()
            AgregarDepositoParaVincular(dtDepositos, drDep, Nothing)
         Next
         For Each drDepAsoc In dtDepAsoc.AsEnumerable()
            AgregarDepositoParaVincular(dtDepositos, Nothing, drDepAsoc)
         Next

         For Each drUbi In dtUbi.AsEnumerable()
            Dim drDeposito = dtDepositos.FirstOrDefault(Function(dr) dr.RowState <> DataRowState.Deleted AndAlso
                                                                     dr.Field(Of Integer?)("IdSucursal").IfNull() = drUbi.Field(Of Integer?)("IdSucursal").IfNull() And
                                                                     dr.Field(Of Integer?)("IdDeposito").IfNull() = drUbi.Field(Of Integer?)("IdDeposito").IfNull())
            If drDeposito IsNot Nothing Then
               AgregarUbicacionParaVincular(dtUbicaciones, drDeposito, drUbi, Nothing)
            End If
         Next
         For Each drUbiAsoc In dtUbiAsoc.AsEnumerable()
            Dim drDeposito = dtDepositos.FirstOrDefault(Function(dr) dr.RowState <> DataRowState.Deleted AndAlso
                                                                     dr.Field(Of Integer?)("IdSucursalAsociada").IfNull() = drUbiAsoc.Field(Of Integer?)("IdSucursal").IfNull() And
                                                                     dr.Field(Of Integer?)("IdDepositoAsociado").IfNull() = drUbiAsoc.Field(Of Integer?)("IdDeposito").IfNull())
            If drDeposito IsNot Nothing Then
               AgregarUbicacionParaVincular(dtUbicaciones, drDeposito, Nothing, drUbiAsoc)
            End If
         Next

      End Using

      ds.Tables.Add("Depositos", dtDepositos)
      ds.Tables.Add("Ubicaciones", dtUbicaciones)

      ds.AddRelation("Depositos_Ubicaciones", {"IdSucursal", "IdDeposito", "IdSucursalAsociada", "IdDepositoASociado"})

      Return ds
   End Function
   Private Function AgregarUbicacionParaVincular(dtUbicaciones As DataTable, drDeposito As DataRow, drUbi As DataRow, drUbiA As DataRow) As DataRow
      Dim result = dtUbicaciones.Rows.Add(If(drDeposito Is Nothing, DBNull.Value, drDeposito("IdSucursal")),
                                          If(drDeposito Is Nothing, DBNull.Value, drDeposito("Nombre")),
                                          If(drDeposito Is Nothing, DBNull.Value, drDeposito("IdDeposito")),
                                          If(drDeposito Is Nothing, DBNull.Value, drDeposito("CodigoDeposito")),
                                          If(drDeposito Is Nothing, DBNull.Value, drDeposito("NombreDeposito")),
                                          If(drUbi Is Nothing, DBNull.Value, drUbi("IdUbicacion")),
                                          If(drUbi Is Nothing, DBNull.Value, drUbi("CodigoUbicacion")),
                                          If(drUbi Is Nothing, DBNull.Value, drUbi("NombreUbicacion")),
                                          String.Empty,
                                          If(drDeposito Is Nothing, DBNull.Value, drDeposito("IdSucursalAsociada")),
                                          If(drDeposito Is Nothing, DBNull.Value, drDeposito("NombreSucursalAsociada")),
                                          If(drDeposito Is Nothing, DBNull.Value, drDeposito("IdDepositoAsociado")),
                                          If(drDeposito Is Nothing, DBNull.Value, drDeposito("CodigoDepositoAsociado")),
                                          If(drDeposito Is Nothing, DBNull.Value, drDeposito("NombreDepositoAsociado")),
                                          If(drUbiA Is Nothing, DBNull.Value, drUbiA("IdUbicacion")),
                                          If(drUbiA Is Nothing, DBNull.Value, drUbiA("CodigoUbicacion")),
                                          If(drUbiA Is Nothing, DBNull.Value, drUbiA("NombreUbicacion")))

      If drUbi IsNot Nothing Then
         drUbi.Delete()
         'drDep.Table.AcceptChanges()
      End If

      If drUbiA IsNot Nothing Then
         drUbiA.Delete()
         'drDepAsoc.Table.AcceptChanges()
      End If

      Return result
   End Function
   Private Sub _DesvincularSucursales(idSucursal As Integer)
      Dim suc = GetUna(idSucursal, incluirLogo:=False)
      If suc.IdSucursalAsociada = 0 Then
         Throw New Exception(String.Format("No es posible desasociar la sucursal {0} {1} porque la misma no se encuentra asociada a ninguna otra sucursal.", idSucursal, suc.Nombre))
      End If

      Dim rDep = New SucursalesDepositos(da)
      rDep._ActualizaDepositoAsociado(idDeposito:=0, suc.IdSucursal, depositoAsociado:=0, sucursalAsociada:=0)
      rDep._ActualizaDepositoAsociado(idDeposito:=0, suc.IdSucursalAsociada, depositoAsociado:=0, sucursalAsociada:=0)

      Dim rUbi = New SucursalesUbicaciones(da)
      rUbi._ActualizaUbicacionAsociada(idDeposito:=0, suc.IdSucursal, idUbicacion:=0, depositoAsociado:=0, sucursalAsociada:=0, ubicacionAsociada:=0)
      rUbi._ActualizaUbicacionAsociada(idDeposito:=0, suc.IdSucursalAsociada, idUbicacion:=0, depositoAsociado:=0, sucursalAsociada:=0, ubicacionAsociada:=0)

      _ActualizaSucursalAsociada(suc.IdSucursal, sucursalAsociada:=0)
      _ActualizaSucursalAsociada(suc.IdSucursalAsociada, sucursalAsociada:=0)

      _RecualculoStockParaRepararInconsistencias({suc.IdSucursal})
      _RecualculoStockParaRepararInconsistencias({suc.IdSucursalAsociada})
   End Sub
   Private Sub _VincularSucursales(idSucursal As Integer, idSucursalAsociada As Integer, ds As DataSet)
      If ds Is Nothing Then
         Throw New ArgumentNullException(NameOf(ds))
      End If

      Dim suc = GetUna(idSucursal, incluirLogo:=False)
      If suc.IdSucursalAsociada <> 0 Then
         Throw New Exception(String.Format("No es posible asociar la sucursal {0} {1} porque la misma ya se encuentra asociada a otra sucursal.", idSucursal, suc.Nombre))
      End If
      Dim sucA = GetUna(idSucursalAsociada, incluirLogo:=False)
      If sucA.IdSucursalAsociada <> 0 Then
         Throw New Exception(String.Format("No es posible asociar la sucursal {0} {1} porque la misma ya se encuentra asociada a otra sucursal.", idSucursalAsociada, sucA.Nombre))
      End If

      Dim rDep = New SucursalesDepositos(da)
      For Each drDeposito In ds.Tables("Depositos").AsEnumerable()
         Dim estado = drDeposito.Field(Of String)("EstadoVinculacion")
         If estado = EstadoVinculacion_Vinculado Then
            rDep._ActualizaDepositoAsociado(drDeposito.Field(Of Integer)("IdDeposito"), suc.IdSucursal, drDeposito.Field(Of Integer)("IdDepositoAsociado"), drDeposito.Field(Of Integer)("IdSucursalAsociada"))
            rDep._ActualizaDepositoAsociado(drDeposito.Field(Of Integer)("IdDepositoAsociado"), drDeposito.Field(Of Integer)("IdSucursalAsociada"), drDeposito.Field(Of Integer)("IdDeposito"), suc.IdSucursal)

         ElseIf estado = EstadoVinculacion_CopiarEnAsociado Then
            Dim deposito = rDep.GetUno(drDeposito.Field(Of Integer)("IdDeposito"), suc.IdSucursal)
            deposito.IdSucursal = idSucursalAsociada
            deposito.IdDeposito = 0
            rDep._Insertar(deposito, actualizandoAsociado:=False, creaUbicacionPredeterminada:=False)

            rDep._ActualizaDepositoAsociado(drDeposito.Field(Of Integer)("IdDeposito"), suc.IdSucursal, deposito.IdDeposito, deposito.IdSucursal)
            rDep._ActualizaDepositoAsociado(deposito.IdDeposito, deposito.IdSucursal, drDeposito.Field(Of Integer)("IdDeposito"), suc.IdSucursal)

            Dim colUbic = drDeposito.GetChildRows("Depositos_Ubicaciones").ToList()

            drDeposito.BeginEdit()
            drDeposito("IdSucursalAsociada") = deposito.IdSucursal
            drDeposito("IdDepositoAsociado") = deposito.IdDeposito
            colUbic.ForEach(Sub(dr) dr.BeginEdit())

            colUbic.ForEach(Sub(dr)
                               drDeposito("IdSucursalAsociada") = deposito.IdSucursal
                               drDeposito("IdDepositoAsociado") = deposito.IdDeposito
                            End Sub)

            colUbic.ForEach(Sub(dr) dr.EndEdit())
            drDeposito.EndEdit()

         ElseIf estado = EstadoVinculacion_CopiarEnOrigen Then
            Dim deposito = rDep.GetUno(drDeposito.Field(Of Integer)("IdDepositoAsociado"), drDeposito.Field(Of Integer)("IdSucursalAsociada"))
            deposito.IdSucursal = idSucursal
            deposito.IdDeposito = 0
            rDep._Insertar(deposito, actualizandoAsociado:=False, creaUbicacionPredeterminada:=False)

            rDep._ActualizaDepositoAsociado(deposito.IdDeposito, deposito.IdSucursal, drDeposito.Field(Of Integer)("IdDepositoAsociado"), drDeposito.Field(Of Integer)("IdSucursalAsociada"))
            rDep._ActualizaDepositoAsociado(drDeposito.Field(Of Integer)("IdDepositoAsociado"), drDeposito.Field(Of Integer)("IdSucursalAsociada"), deposito.IdDeposito, deposito.IdSucursal)

            Dim colUbic = drDeposito.GetChildRows("Depositos_Ubicaciones").ToList()

            drDeposito.BeginEdit()
            drDeposito("IdSucursal") = deposito.IdSucursal
            drDeposito("IdDeposito") = deposito.IdDeposito
            colUbic.ForEach(Sub(dr) dr.BeginEdit())

            colUbic.ForEach(Sub(dr)
                               drDeposito("IdSucursal") = deposito.IdSucursal
                               drDeposito("IdDeposito") = deposito.IdDeposito
                            End Sub)

            colUbic.ForEach(Sub(dr) dr.EndEdit())
            drDeposito.EndEdit()

         End If

      Next


      Dim rUbi = New SucursalesUbicaciones(da)
      For Each drUbicacion In ds.Tables("Ubicaciones").AsEnumerable()
         Dim estado = drUbicacion.Field(Of String)("EstadoVinculacion")
         If estado = EstadoVinculacion_Vinculado Then
            rUbi._ActualizaUbicacionAsociada(drUbicacion.Field(Of Integer)("IdDeposito"), drUbicacion.Field(Of Integer)("IdSucursal"), drUbicacion.Field(Of Integer)("IdUbicacion"),
                                             drUbicacion.Field(Of Integer)("IdDepositoAsociado"), drUbicacion.Field(Of Integer)("IdSucursalAsociada"), drUbicacion.Field(Of Integer)("IdUbicacionAsociada"))
            rUbi._ActualizaUbicacionAsociada(drUbicacion.Field(Of Integer)("IdDepositoAsociado"), drUbicacion.Field(Of Integer)("IdSucursalAsociada"), drUbicacion.Field(Of Integer)("IdUbicacionAsociada"),
                                             drUbicacion.Field(Of Integer)("IdDeposito"), drUbicacion.Field(Of Integer)("IdSucursal"), drUbicacion.Field(Of Integer)("IdUbicacion"))

         ElseIf estado = EstadoVinculacion_CopiarEnAsociado Then
            Dim ubicacion = rUbi.GetUno(drUbicacion.Field(Of Integer)("IdDeposito"), drUbicacion.Field(Of Integer)("IdSucursal"), drUbicacion.Field(Of Integer)("IdUbicacion"))
            ubicacion.IdSucursal = drUbicacion.Field(Of Integer)("IdSucursalAsociada")
            ubicacion.IdDeposito = drUbicacion.Field(Of Integer)("IdDepositoAsociado")
            ubicacion.IdUbicacion = 0
            rUbi._Insertar(ubicacion, actualizandoAsociado:=True)

            rUbi._ActualizaUbicacionAsociada(drUbicacion.Field(Of Integer)("IdDeposito"), drUbicacion.Field(Of Integer)("IdSucursal"), drUbicacion.Field(Of Integer)("IdUbicacion"),
                                             ubicacion.IdDeposito, ubicacion.IdSucursal, ubicacion.IdUbicacion)
            rUbi._ActualizaUbicacionAsociada(ubicacion.IdDeposito, ubicacion.IdSucursal, ubicacion.IdUbicacion,
                                             drUbicacion.Field(Of Integer)("IdDeposito"), drUbicacion.Field(Of Integer)("IdSucursal"), drUbicacion.Field(Of Integer)("IdUbicacion"))

         ElseIf estado = EstadoVinculacion_CopiarEnOrigen Then
            Dim ubicacion = rUbi.GetUno(drUbicacion.Field(Of Integer)("IdDepositoAsociado"), drUbicacion.Field(Of Integer)("IdSucursalAsociada"), drUbicacion.Field(Of Integer)("IdUbicacionAsociada"))
            ubicacion.IdSucursal = drUbicacion.Field(Of Integer)("IdSucursal")
            ubicacion.IdDeposito = drUbicacion.Field(Of Integer)("IdDeposito")
            ubicacion.IdUbicacion = 0
            rUbi._Insertar(ubicacion, actualizandoAsociado:=True)

            rUbi._ActualizaUbicacionAsociada(ubicacion.IdDeposito, ubicacion.IdSucursal, ubicacion.IdUbicacion,
                                             drUbicacion.Field(Of Integer)("IdDepositoAsociado"), drUbicacion.Field(Of Integer)("IdSucursalAsociada"), drUbicacion.Field(Of Integer)("IdUbicacionAsociada"))
            rUbi._ActualizaUbicacionAsociada(drUbicacion.Field(Of Integer)("IdDepositoAsociado"), drUbicacion.Field(Of Integer)("IdSucursalAsociada"), drUbicacion.Field(Of Integer)("IdUbicacionAsociada"),
                                             ubicacion.IdDeposito, ubicacion.IdSucursal, ubicacion.IdUbicacion)

         End If
      Next

      _ActualizaSucursalAsociada(suc.IdSucursal, idSucursalAsociada)
      _ActualizaSucursalAsociada(sucA.IdSucursal, idSucursal)

      _RecualculoStockParaRepararInconsistencias({suc.IdSucursal, sucA.IdSucursal})

   End Sub
   Private Sub _RecualculoStockParaRepararInconsistencias(idSucs As IEnumerable(Of Integer))
      Dim sql = New SqlServer.Sucursales(da)

      sql.RecualculoStockParaRepararInconsistencias_Stock0(idSucs)
      sql.RecualculoStockParaRepararInconsistencias_SumaMovimientos(idSucs)
      sql.RecualculoStockParaRepararInconsistencias_AcumulaDeposito(idSucs)
      sql.RecualculoStockParaRepararInconsistencias_AcumulaSucursal(idSucs)

   End Sub
   Private Sub _ActualizaSucursalAsociada(idSucursal As Integer, sucursalAsociada As Integer)
      Dim sql = New SqlServer.Sucursales(da)
      sql.Sucursales_U_SucAsoc(idSucursal, sucursalAsociada)
   End Sub


   Public Sub VincularDepositos(drCol As IEnumerable(Of DataRow), ds As DataSet)
      Try
         If drCol.CountSecure() <> 2 Then
            Throw New Exception(String.Format("Para poder vincular dos depositos solo debe seleccionar dos filas.{0}{0}Ha seleccionado {1} registros.",
                                              Environment.NewLine, drCol.CountSecure()))
         End If
         If drCol.Any(Function(dr)
                         If dr.Table.Columns.Contains("IdUbicacion") Then
                            Throw New Exception(String.Format("Una de las filas seleccionadas no es un deposito.{0}{0}No es posible vincular.",
                                                           Environment.NewLine))
                         End If
                      End Function) Then
         End If
         If drCol(0).Field(Of Integer?)("IdSucursal").IfNull() = drCol(1).Field(Of Integer?)("IdSucursal").IfNull() Then
            Throw New Exception(String.Format("Los depositos seleccionados pertenecesn a la misma sucursal.{0}{0}No es posible vincular.",
                                           Environment.NewLine))
         End If

         Dim drDep = drCol.First(Function(dr) dr.Field(Of Integer?)("IdSucursal").HasValue)
         Dim drDepAsoc = drCol.First(Function(dr) Not dr.Field(Of Integer?)("IdSucursal").HasValue)
         Dim dtUbicaciones = ds.Tables("Ubicaciones")


         drDep.CopiarValores(drDepAsoc, {"IdSucursalAsociada", "NombreSucursalAsociada",
                                         "IdDepositoASociado", "CodigoDepositoAsociado", "NombreDepositoAsociado"})
         drDep("EstadoVinculacion") = EstadoVinculacion_Vinculado
         ', "IdUbicacionAsociada", "CodigoUbicacionAsociada", "NombreUbicacionAsociada"})

         For Each drUbi In dtUbicaciones.Where(Function(dr) dr.Field(Of Integer?)("IdSucursal").HasValue AndAlso
                                                            dr.Field(Of Integer?)("IdSucursal").IfNull() = drDep.Field(Of Integer?)("IdSucursal").IfNull() And
                                                            dr.Field(Of Integer?)("IdDeposito").IfNull() = drDep.Field(Of Integer?)("IdDeposito").IfNull())

            drUbi.BeginEdit()
            drUbi("IdSucursalAsociada") = drDepAsoc("IdSucursalAsociada")
            drUbi("NombreSucursalAsociada") = drDepAsoc("NombreSucursalAsociada")
            drUbi("IdDepositoAsociado") = drDepAsoc("IdDepositoAsociado")
            drUbi("CodigoDepositoAsociado") = drDepAsoc("CodigoDepositoAsociado")
            drUbi("NombreDepositoAsociado") = drDepAsoc("NombreDepositoAsociado")
            drUbi.EndEdit()

         Next

         For Each drUbi In dtUbicaciones.Where(Function(dr) dr.Field(Of Integer?)("IdSucursalAsociada").HasValue AndAlso
                                                            dr.Field(Of Integer?)("IdSucursalAsociada").IfNull() = drDepAsoc.Field(Of Integer?)("IdSucursalAsociada").IfNull() And
                                                            dr.Field(Of Integer?)("IdDepositoAsociado").IfNull() = drDepAsoc.Field(Of Integer?)("IdDepositoAsociado").IfNull())

            drUbi.BeginEdit()
            drUbi("IdSucursal") = drDep("IdSucursal")
            drUbi("Nombre") = drDep("Nombre")
            drUbi("IdDeposito") = drDep("IdDeposito")
            drUbi("CodigoDeposito") = drDep("CodigoDeposito")
            drUbi("NombreDeposito") = drDep("NombreDeposito")
            drUbi.EndEdit()

         Next


         Dim drUbi1 = dtUbicaciones.SingleOrDefault(Function(dr) dr.Field(Of Integer?)("IdUbicacion").HasValue AndAlso
                                                                 dr.Field(Of Integer?)("IdSucursal").IfNull() = drDep.Field(Of Integer?)("IdSucursal").IfNull() And
                                                                 dr.Field(Of Integer?)("IdDeposito").IfNull() = drDep.Field(Of Integer?)("IdDeposito").IfNull())
         Dim drUbi2 = dtUbicaciones.SingleOrDefault(Function(dr) dr.Field(Of Integer?)("IdUbicacionAsociada").HasValue AndAlso
                                                                 dr.Field(Of Integer?)("IdSucursal").IfNull() = drDep.Field(Of Integer?)("IdSucursal").IfNull() And
                                                                 dr.Field(Of Integer?)("IdDeposito").IfNull() = drDep.Field(Of Integer?)("IdDeposito").IfNull())

         If drUbi1 IsNot Nothing AndAlso drUbi2 IsNot Nothing Then
            drUbi1.CopiarValores(drUbi2, {"IdUbicacionAsociada", "CodigoUbicacionAsociada", "NombreUbicacionAsociada"})
            drUbi1("EstadoVinculacion") = EstadoVinculacion_Vinculado
            drUbi2.Delete()
         End If

         drDepAsoc.Delete()
         ds.AcceptChanges()

      Catch ex As Exception
         ds.RejectChanges()
         Throw
      End Try

   End Sub

   Public Sub CopiarDepositos(drCol As IEnumerable(Of DataRow), ds As DataSet)
      Try
         If drCol.Any(Function(dr) dr.Table.Columns.Contains("IdUbicacion")) Then
            Throw New Exception(String.Format("Una de las filas seleccionadas no es un deposito.{0}{0}No es posible copiar.",
                                              Environment.NewLine))
         End If

         If drCol.Any(Function(dr) dr.Field(Of Integer?)("IdSucursal").HasValue AndAlso dr.Field(Of Integer?)("IdSucursalAsociada").HasValue) Then
            Throw New Exception(String.Format("ha seleccionado un deposito que ya se encuentra vinculado.{0}{0}No es posible copiar.",
                                              Environment.NewLine))
         End If

         Dim dtUbicaciones = ds.Tables("Ubicaciones")

         For Each drDep In drCol.AsEnumerable()  '.Where(Function(dr) dr.Field(Of Integer?)("IdSucursal").HasValue)
            If drDep.Field(Of Integer?)("IdSucursal").HasValue Then
               drDep("EstadoVinculacion") = EstadoVinculacion_CopiarEnAsociado
               dtUbicaciones.Where(Function(drUbic) drUbic.Field(Of Integer?)("IdSucursal").IfNull() = drDep.Field(Of Integer?)("IdSucursal").IfNull() And
                                                    drUbic.Field(Of Integer?)("IdDeposito").IfNull() = drDep.Field(Of Integer?)("IdDeposito").IfNull()).ToList().
                             ForEach(Sub(drUbic) drUbic("EstadoVinculacion") = EstadoVinculacion_CopiarEnAsociado)
            Else
               drDep("EstadoVinculacion") = EstadoVinculacion_CopiarEnOrigen
               dtUbicaciones.Where(Function(drUbic) drUbic.Field(Of Integer?)("IdSucursalAsociada").IfNull() = drDep.Field(Of Integer?)("IdSucursalAsociada").IfNull() And
                                                    drUbic.Field(Of Integer?)("IdDepositoAsociado").IfNull() = drDep.Field(Of Integer?)("IdDepositoAsociado").IfNull()).ToList().
                             ForEach(Sub(drUbic) drUbic("EstadoVinculacion") = EstadoVinculacion_CopiarEnOrigen)
            End If
         Next

         ds.AcceptChanges()

      Catch ex As Exception
         ds.RejectChanges()
         Throw
      End Try

   End Sub

End Class