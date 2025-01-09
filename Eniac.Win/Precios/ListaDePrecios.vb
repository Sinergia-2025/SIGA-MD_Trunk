Option Strict Off
Public Class ListaDePrecios

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()
         Me._publicos.CargaComboListaDePrecios(Me.cmbListaDePrecios)

         Dim oMarca As Reglas.Marcas = New Reglas.Marcas()
         Me.cmbMarca.ValueMember = "IdMarca"
         Me.cmbMarca.DisplayMember = "NombreMarca"

         Me.cmbMarca.DataSource = oMarca.GetAll()
         Me.cmbMarca.SelectedIndex = -1

         Dim oRubro As Reglas.Rubros = New Reglas.Rubros()
         Me.cmbRubro.ValueMember = "IdRubro"
         Me.cmbRubro.DisplayMember = "NombreRubro"

         Me.cmbRubro.DataSource = oRubro.GetAll()
         Me.cmbRubro.SelectedIndex = -1

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbMarca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbMarca.CheckedChanged
      Me.cmbMarca.Enabled = Me.chbMarca.Checked
      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         Me.cmbMarca.SelectedIndex = 0
      End If
   End Sub

   Private Sub chbRubro_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbRubro.CheckedChanged
      Me.cmbRubro.Enabled = Me.chbRubro.Checked
      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
      Else
         Me.cmbRubro.SelectedIndex = 0
      End If
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try

         Dim CodigoMarca As Integer = 0
         Dim NombreMarca As String = String.Empty

         Dim CodigoRubro As Integer = 0
         Dim NombreRubro As String = String.Empty

         Dim blnPreciosConIVA As Boolean
         'Dim decCoeficienteIVA As Decimal

         Dim Filtros As String

         Me.Cursor = Cursors.WaitCursor

         Dim oListaPrecios As Reglas.PreciosCostoVenta = New Reglas.PreciosCostoVenta()

         If Me.chbMarca.Checked Then
            If Me.cmbMarca.SelectedIndex <> -1 Then
               CodigoMarca = Me.cmbMarca.SelectedItem("IdMarca").ToString()
               NombreMarca = Me.cmbMarca.Text
            End If
         End If

         If Me.chbRubro.Checked Then
            If Me.cmbRubro.SelectedIndex <> -1 Then
               CodigoRubro = Me.cmbRubro.SelectedItem("IdRubro").ToString()
               NombreRubro = Me.cmbRubro.Text
            End If
         End If

         Dim OrdenarPor As String = IIf(Me.rbtOrdenPorCodigo.Checked, "CODIGO", "NOMBRE").ToString()

         blnPreciosConIVA = (New Reglas.Parametros().GetValor("PRECIOCONIVA") = "SI")

         Dim dt As DataTable = oListaPrecios.GetListaCostoVenta(Eniac.Entidades.Usuario.Actual.Sucursal.Id, _
                                                                DirectCast(Me.cmbListaDePrecios.SelectedItem,  _
                                                            Entidades.ListaDePrecios).IdListaPrecios, _
                                                         CodigoMarca, CodigoRubro, OrdenarPor)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", Eniac.Entidades.Usuario.Actual.Sucursal.Nombre))

         'Por ahora asi, tal vez a futuro lo tome de alguna tabla
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", DateTime.Now))


         Filtros = "Filtros: Marca: " & IIf(NombreMarca = "", "TODAS", NombreMarca)

         Filtros = Filtros & " / Rubro: " & IIf(NombreRubro = "", "TODOS", NombreRubro)

         Filtros = Filtros & " / Lista de Precios: " & Me.cmbListaDePrecios.Text

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PrecioConIVA", blnPreciosConIVA))

         'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CoeficienteIVA", decCoeficienteIVA))


         'Dim frmImprime As VisorReportes = New VisorReportes(My.Application.Info.AssemblyName & ".ListaDePrecios.rdlc", "dsPrecios_ListaDePreciosCosto", dt, parm)
         Dim frmImprime As VisorReportes
         Dim strReporte As String = String.Empty

         Select Case True

            Case optPorMarca.Checked
               If Me.rbtOrdenAlfabetico.Checked Then
                  strReporte = "ListaDePrecios_Marca.rdlc"
               Else
                  strReporte = "ListaDePrecios_Marca_Codigo.rdlc"
               End If

            Case optPorRubro.Checked
               If Me.rbtOrdenAlfabetico.Checked Then
                  strReporte = "ListaDePrecios_Rubro.rdlc"
               Else
                  strReporte = "ListaDePrecios_Rubro_Codigo.rdlc"
               End If

            Case optAlfabetico.Checked
               strReporte = "ListaDePrecios.rdlc"

            Case Else
               strReporte = "ListaDePrecios_Codigo.rdlc"

         End Select

         frmImprime = New VisorReportes("Eniac.Win." & strReporte, "dsPrecios_ListaDePreciosCosto", dt, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = "Listas de Precios"
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub


#End Region

   Private Sub optAlfabetico_CheckedChanged(sender As Object, e As EventArgs) Handles optAlfabetico.CheckedChanged
      Try

         Me.gpbOrdenarPor.Visible = Not Me.optAlfabetico.Checked

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub optPorCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles optPorCodigo.CheckedChanged
      Try

         Me.gpbOrdenarPor.Visible = Not Me.optPorCodigo.Checked

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

End Class