Public Class InfVentasPorSubRubroProducto

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)

         pnlModelos.Visible = Reglas.Publicos.ProductoTieneModelo
         pnlSubRubros.Visible = Reglas.Publicos.ProductoTieneSubRubro
         pnlSubSubRubros.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

         ugDetalle.AgregarTotalesSuma({"ImporteNeto", "Cantidad", "Kilos"})
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim filtros = New StringBuilder()
         filtros.AppendFormat("Fechas: Desde {0} Hasta {1}", dtpDesde.Text, dtpHasta.Text)

         cmbMarcas.CargaFiltroImpresion(filtros)
         cmbModelos.CargaFiltroImpresion(filtros)
         cmbRubros.CargaFiltroImpresion(filtros)
         cmbSubRubros.CargaFiltroImpresion(filtros)
         cmbSubSubRubros.CargaFiltroImpresion(filtros)

         Dim dt = ugDetalle.DataSource(Of DataTable)

         Dim parm = New ReportParameterCollection(filtros.ToString())

         Dim nombreReporte = If(chkExpandAll.Checked, "Eniac.Win.InfVentasPorSubRubroProducto.rdlc", "Eniac.Win.InfVentasPorSubRubro.rdlc")

         Dim frmImprime = New VisorReportes(nombreReporte, "DSReportes_InfVentasPorSubRubroProducto", dt, parm, True, 1) With {'# 1 = Cantidad Copias
            .Text = Text,
            .WindowState = FormWindowState.Maximized
         }
         frmImprime.Show()
      End Sub)
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub
   Private Sub cmbMarcas_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcas.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim marcas = cmbMarcas.GetMarcas(todosVacio:=True)
                    cmbModelos.ConcatenarNombreMarca = marcas.CountSecure() <> 1
                    cmbModelos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                           marcas:=marcas)
                 End Sub)
   End Sub
   Private Sub cmbRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim rubros = cmbRubros.GetRubros(todosVacio:=True)
                    cmbSubRubros.ConcatenarNombreRubro = rubros.CountSecure() <> 1
                    cmbSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                             rubros:=rubros)
                 End Sub)
   End Sub
   Private Sub cmbSubRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim subRubros = cmbSubRubros.GetSubRubros(todosVacio:=True)
                    cmbSubSubRubros.ConcatenarNombreSubRubro = subRubros.CountSecure() <> 1
                    cmbSubSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                                subRubro:=subRubros)
                 End Sub)

   End Sub
#End Region

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll))
   End Sub
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefrescarDatosGrilla()
      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      cmbMarcas.Refrescar()
      cmbModelos.Refrescar()
      cmbRubros.Refrescar()
      cmbSubRubros.Refrescar()
      cmbSubSubRubros.Refrescar()

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()
   End Sub
   Private Sub CargaGrillaDetalle()
      Dim rVProd = New Reglas.VentasProductos()
      Dim dtDetalle = rVProd.GetTotalesPorSubRubrosProductos(actual.Sucursal.Id, dtpDesde.Value, dtpHasta.Value,
                                                             cmbMarcas.GetMarcas(todosVacio:=True), cmbModelos.GetModelos(todosVacio:=True),
                                                             cmbRubros.GetRubros(todosVacio:=True), cmbSubRubros.GetSubRubros(todosVacio:=True), cmbSubSubRubros.GetSubSubRubros(todosVacio:=True))
      Dim dt = CrearDT()
      For Each dr In dtDetalle.AsEnumerable
         Dim drCl = dt.NewRow()
         drCl("IdSubRubro") = dr.Field(Of Integer)("IdSubRubro")
         drCl("NombreSubRubro") = dr.Field(Of String)("NombreSubRubro")
         drCl("IdProducto") = dr.Field(Of String)("IdProducto")
         drCl("NombreProducto") = dr.Field(Of String)("NombreProducto")
         drCl("ImporteNeto") = dr.Field(Of Decimal)("ImporteNeto")
         drCl("Cantidad") = dr.Field(Of Decimal)("Cantidad")
         drCl("Kilos") = dr.Field(Of Decimal)("Kilos")

         dt.Rows.Add(drCl)
      Next
      ugDetalle.DataSource = dt
   End Sub
   Private Function CrearDT() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("IdSubRubro", GetType(Integer))
         .Columns.Add("NombreSubRubro", GetType(String))
         .Columns.Add("IdProducto", GetType(String))
         .Columns.Add("NombreProducto", GetType(String))
         .Columns.Add("ImporteNeto", GetType(Decimal))
         .Columns.Add("Cantidad", GetType(Decimal))
         .Columns.Add("Kilos", GetType(Decimal))
      End With
      Return dtTemp
   End Function
#End Region

End Class