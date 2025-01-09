Option Strict On
Option Explicit On
Option Infer On
Partial Class Proyectos
   Public Function GetNovedadesPorProyecto(proyectoFinalizado As Entidades.Publicos.SiNoTodos,
                                            finalizado As Entidades.Publicos.SiNoTodos,
                                            idEstadoProyecto As Integer,
                                            idTipoNovedad As String,
                                            idProyecto As Integer,
                                            idCliente As Long,
                                            idClasificacionProyecto As Integer,
                                            soloConNovedades As Boolean,
                                            tipoUsuario As Integer) As DataTable

      Return EjecutaConConexion(Function()
                                   Dim idTipoNovedadCol = If(String.IsNullOrWhiteSpace(idTipoNovedad), {"PENDIENTE", "TICKETS", "REQUER"}, {idTipoNovedad})
                                   Dim dt = New SqlServer.Proyectos(da).GetNovedadesPorProyecto(idTipoNovedadCol,
                                                                                                proyectoFinalizado,
                                                                                                finalizado,
                                                                                                idEstadoProyecto,
                                                                                                idProyecto,
                                                                                                idCliente,
                                                                                                idClasificacionProyecto,
                                                                                                soloConNovedades,
                                                                                                tipoUsuario)
                                   Dim dicColumnas = New Dictionary(Of String, StringBuilder)()
                                   Dim lstColumnas = New List(Of String)()
                                   For Each dc As DataColumn In dt.Columns
                                      Dim split = dc.ColumnName.Split("/"c)
                                      If split.Length > 1 Then
                                         If dicColumnas.ContainsKey(split(0)) Then
                                            dicColumnas(split(0)).AppendFormat(" + ISNULL([{0}], 0)", dc.ColumnName)
                                         Else
                                            dicColumnas.Add(split(0), New StringBuilder())
                                            dicColumnas(split(0)).AppendFormat("ISNULL([{0}], 0)", dc.ColumnName)
                                         End If
                                      ElseIf dc.ColumnName.EndsWith("_TOTALES_") Then
                                         lstColumnas.Add(dc.ColumnName)
                                      End If
                                   Next
                                   For Each c In lstColumnas
                                      dt.Columns.Add(c.TrimEnd("_"c), GetType(Decimal), String.Format("IIF({0} = 0, NULL, {0})", String.Concat(c)))
                                   Next

                                   For Each idTipo In idTipoNovedadCol
                                      Dim exp = If(dicColumnas.ContainsKey(idTipo), dicColumnas(idTipo).ToString(), "NULL")
                                      dt.Columns.Add(String.Concat(idTipo, "___"), GetType(Decimal), exp)
                                      dt.Columns.Add(String.Concat("___", idTipo), GetType(Decimal), String.Format("IIF({0} = 0, NULL, {0})", String.Concat(idTipo, "___")))
                                   Next

                                   'For Each kv In dicColumnas
                                   '   dt.Columns.Add(String.Concat(kv.Key, "___"), GetType(Decimal), kv.Value.ToString())
                                   '   dt.Columns.Add(String.Concat("___", kv.Key), GetType(Decimal), String.Format("IIF({0} = 0, NULL, {0})", String.Concat(kv.Key, "___")))
                                   'Next
                                   Return dt
                                End Function)
   End Function
End Class