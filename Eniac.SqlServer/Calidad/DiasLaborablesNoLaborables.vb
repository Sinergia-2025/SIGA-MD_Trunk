Public Class DiasLaborablesNoLaborables
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub DiasLaborablesNoLaborables_I(Dia As Date,
                                  Laborable As Boolean)


      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO CalidadDiasLaborablesNoLaborables ({0}, {1})",
                       Entidades.DiaLaborableNoLaborable.Columnas.Dia.ToString(),
                       Entidades.DiaLaborableNoLaborable.Columnas.Laborable.ToString()).AppendLine()
         .AppendFormat("     VALUES ('{0}', '{1}')",
                       Dia, Laborable)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub DiasLaborablesNoLaborables_U(Dia As Date,
                                  Laborable As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE CalidadDiasLaborablesNoLaborables ")
         .AppendFormat("   SET {0} = '{1}'", Entidades.DiaLaborableNoLaborable.Columnas.Laborable.ToString(), Laborable).AppendLine()
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.DiaLaborableNoLaborable.Columnas.Dia.ToString(), Dia)

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub DiasLaborablesNoLaborables_D(Dia As Date)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadDiasLaborablesNoLaborables ")
         .AppendFormat(" WHERE {0} = {1}", Entidades.DiaLaborableNoLaborable.Columnas.Dia.ToString(), Dia)
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
         .AppendFormat("SELECT * FROM CalidadDiasLaborablesNoLaborables ")
      End With
   End Sub

   Public Function DiasLaborablesNoLaborables_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         ' .AppendFormat(" WHERE LCU.{0} = {1}", Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString(), idModelo)

         .AppendFormat(" ORDER BY CT.NombreListaControlTipo, CML.Dia")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function DiasLaborablesNoLaborables_G1(Dia As Date) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE {0} = '{1}'", Entidades.DiaLaborableNoLaborable.Columnas.Dia.ToString(), Dia)

         ' .AppendFormat(" ORDER BY LCU.IdListaControl")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function DiasLaborablesNoLaborables_GxFechas(desde As Date, hasta As Date) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         '  .AppendFormat(" WHERE {0} >= '{1}'", Entidades.DiaLaborableNoLaborable.Columnas.Dia.ToString(), desde.ToString("dd/MM/yyyy"))
         ' .AppendFormat("      AND {0} <= '{1}'", Entidades.DiaLaborableNoLaborable.Columnas.Dia.ToString(), hasta.ToString("dd/MM/yyyy"))

         ' .AppendFormat(" ORDER BY LCU.IdListaControl")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   'Public Function ListasControlModelos_GInforme(idModelo As Integer, IdListaControl As Integer) As DataTable
   '   Dim myQuery As StringBuilder = New StringBuilder()
   '   With myQuery
   '      Me.SelectTexto(myQuery)

   '      .AppendFormat(" WHERE 1= 1")
   '      If idModelo > 0 Then
   '         .AppendFormat(" AND LCU.{0} = {1}", Entidades.ListaControlModelo.Columnas.IdProductoModelo.ToString(), idModelo)
   '      End If
   '      If IdListaControl > 0 Then
   '         .AppendFormat(" AND LCU.{0} = {1}", Entidades.ListaControlModelo.Columnas.IdListaControl.ToString(), IdListaControl)
   '      End If

   '      .AppendFormat(" ORDER BY U.NombreProductoModelo, LC.Orden")
   '   End With
   '   Return Me.GetDataTable(myQuery.ToString())
   'End Function


End Class