Option Explicit On
Option Strict On

Public Class ContabilidadReportesAdmin

#Region "Campos"

   Private _publicos As ContabilidadPublicos
   Private _idCuenta As Long
   Private _nombreCuenta As String

   Dim idPlan As Integer = 1 'default
   Dim SucursalesSelect As String = String.Empty
   Dim suc As List(Of Integer) = New List(Of Integer)

#End Region

#Region "Propiedades"

   Public Property IdCuenta() As Long
      Get
         Return _idCuenta
      End Get
      Set(ByVal value As Long)
         _idCuenta = value
      End Set
   End Property

   Public Property NombreCuenta() As String
      Get
         Return _nombreCuenta
      End Get
      Set(ByVal value As String)
         _nombreCuenta = value
      End Set
   End Property

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New ContabilidadPublicos()

      Me._publicos.CargaComboPlanes(Me.cmbPlan, True)
      Me._publicos.CargarSucursalesACheckListBox(Me.clbSucursales)

      Me.CargarValoresIniciales()

   End Sub

   Public Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ContabilidadReportes()
   End Function

#End Region

   Private Sub CargarValoresIniciales()
      Me.dtpDesde.Value = Date.Now
      Me.dtpHasta.Value = Date.Now
      Me.dtpBalance.Value = Date.Now
   End Sub

   Private Function AplicarJerarquia(ByVal codigo As String) As String

      Return codigo.Substring(0, 1) & "." _
                      & codigo.Substring(1, 2) & "." _
                      & codigo.Substring(3, 2) & "." _
                      & codigo.Substring(5, 3)
   End Function

   Private Sub cmdReporte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReporte.Click

      idPlan = CInt(Me.cmbPlan.SelectedValue)
      SucursalesSelect = String.Empty
      suc.Clear()

      For Each ite As Object In Me.clbSucursales.CheckedItems
         suc.Add(DirectCast(ite, Entidades.Sucursal).Id)
         SucursalesSelect += DirectCast(ite, Entidades.Sucursal).Nombre & " - "
      Next

      Select Case Me.tbListados.SelectedIndex
         Case Is = 0 'BALANCE
            Me.GenerarBalance()

         Case Is = 1 'ASIENTO
            Me.GenerarAsiento()

         Case Is = 2 'LIBRO MAYOR
            Me.GenerarLibroMayor()

         Case Is = 3 'CUENTAS
            Me.GenerarPlanCuentas()
      End Select

   End Sub

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerPlan.Click
      Dim frm As New ContabilidadPlanesCuentasPreView
      frm.IdPlanCuenta = CInt(Me.cmbPlan.SelectedValue)
      frm.ShowDialog()
   End Sub

#Region "ASIENTOS"

   Private Sub GenerarAsiento()

      If ValidarAsiento() Then

         Dim idAsiento As Integer
         Dim dscAsiento As String = Me.bscConcepto.Text
         Dim fechaAsiento As Date

         If Me.txtNumeroAsiento.Text = String.Empty Or Me.txtNumeroAsiento.Text = "0" Then
            idAsiento = -1
         Else
            idAsiento = CInt(Me.txtNumeroAsiento.Text)
         End If

         If Me.dtFechaAsiento.Checked Then
            fechaAsiento = Me.dtFechaAsiento.Value
         Else
            fechaAsiento = Date.MinValue
         End If

         Dim reg As Reglas.ContabilidadReportes = New Reglas.ContabilidadReportes
         Dim oReporteAsiento As New Entidades.ContabilidadReporte

         Dim dtsAsientos As New dtsAsientos()
         oReporteAsiento = reg.Asiento_GetDetalle(idAsiento, fechaAsiento, idPlan, suc.ToArray())


         If oReporteAsiento.detallesAsiento Is Nothing OrElse oReporteAsiento.detallesAsiento.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron datos para los filtros seleccionados", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If


         Try
            dtsAsientos.Tables("dtAsientos").Merge(oReporteAsiento.detallesAsiento)
            'creo la coleccion de parametros
            Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresa))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("idAsiento", oReporteAsiento.detallesAsiento.Rows(0)("idAsiento").ToString))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("dscAsiento", oReporteAsiento.detallesAsiento.Rows(0)("NombreAsiento").ToString))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("fechaAsiento", CDate(oReporteAsiento.detallesAsiento.Rows(0)("fechaAsiento")).ToShortDateString))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PlanCta", Me.cmbPlan.Text))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Sucursal", SucursalesSelect))

            Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.rptAsientos.rdlc", "dtsAsientos_dtAsientos", dtsAsientos.Tables("dtAsientos"), parm, True)
            frmImprime.Text = "Asientos"
            frmImprime.rvReporte.DocumentMapCollapsed = True
            frmImprime.Size = New Size(780, 600)
            frmImprime.StartPosition = FormStartPosition.CenterScreen
            frmImprime.ShowDialog()


         Catch ex As Exception
            MessageBox.Show(ex.Message, "Imprimir Asientos", MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try

      End If
   End Sub

   Private Function ValidarAsiento() As Boolean

      If Me.txtNumeroAsiento.Text = String.Empty And _
         Me.bscConcepto.Text = String.Empty And _
         Me.dtFechaAsiento.Checked = False Then
         MessageBox.Show("Ingrese un Filtro para generar el informe.", "Asiento Contable", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtNumeroAsiento.Focus()
         Return False

      End If

      Return True
   End Function


   Private Sub bscConcepto_BuscadorClick() Handles bscConcepto.BuscadorClick

      Try
         Dim oAsientos As Reglas.ContabilidadAsientos = New Reglas.ContabilidadAsientos
         Me.bscConcepto.Datos = oAsientos.GetPorNombre(Me.bscConcepto.Text.Trim())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscConcepto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscConcepto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscConcepto.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadAsiento.Columnas.NombreAsiento.ToString()).Value.ToString()
            Me.txtNumeroAsiento.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadAsiento.Columnas.IdAsiento.ToString()).Value.ToString()
            Me.dtFechaAsiento.Value = CDate(e.FilaDevuelta.Cells(Entidades.ContabilidadAsiento.Columnas.FechaAsiento.ToString()).Value)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         'Me.Nuevo()
      End Try
   End Sub
#End Region

#Region "LIBRO MAYOR"

   Private Sub GenerarLibroMayor()

      If ValidarLibroMayor() Then

         Dim fechaDesde As Date
         Dim strFechaDesde As String = String.Empty
         Dim fechaHasta As Date = Me.dtpHasta.Value
         Dim codCuenta As Integer = CInt(Me.bscCodCuenta.Text)

         If Me.dtpDesde.Checked Then
            fechaDesde = Me.dtpDesde.Value
            strFechaDesde = Me.dtpDesde.Value.ToShortDateString
         Else
            fechaDesde = Date.MinValue
            strFechaDesde = "-"
         End If

         Dim reg As Reglas.ContabilidadReportes = New Reglas.ContabilidadReportes
         Dim oReporteLibro As New Entidades.ContabilidadReporte

         Dim dtsLibroMayor As New dtsLibroMayor
         oReporteLibro = reg.LibroMayor(fechaDesde, fechaHasta, codCuenta, idPlan, suc.ToArray())


         If oReporteLibro.libroMayor Is Nothing OrElse oReporteLibro.libroMayor.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron datos para los filtros seleccionados", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         'dtsLibroMayor_dtLibro
         Try
            dtsLibroMayor.Tables("dtLibro").Merge(oReporteLibro.libroMayor)
            'creo la coleccion de parametros
            Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresa))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cuenta", AplicarJerarquia(Me.bscCodCuenta.Text) & " - " & Me.bscDescripcion.Text))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fdesde", strFechaDesde))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fhasta", fechaHasta.ToShortDateString))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PlanCta", Me.cmbPlan.Text))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Sucursal", SucursalesSelect))

            Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.rptLibroMayor.rdlc", "dtsLibroMayor_dtLibro", dtsLibroMayor.Tables("dtLibro"), parm, True)
            frmImprime.Text = "Libro Mayor"
            frmImprime.rvReporte.DocumentMapCollapsed = True
            frmImprime.Size = New Size(780, 600)
            frmImprime.StartPosition = FormStartPosition.CenterScreen
            frmImprime.ShowDialog()


         Catch ex As Exception
            MessageBox.Show(ex.Message, "Imprimir Libro Mayor", MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try

      End If

   End Sub

   Private Function ValidarLibroMayor() As Boolean

      If Me.bscCodCuenta.Text = String.Empty Then
         MessageBox.Show("Selecione una cuenta para generar el Mayor", "Libro Mayor", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodCuenta.Focus()
         Return False
      End If
      Return True
   End Function

   Private Sub bsccodCuenta_BuscadorClick() Handles bscCodCuenta.BuscadorClick

      Try
         Dim oAsientos As Reglas.ContabilidadAsientos = New Reglas.ContabilidadAsientos
         Me._publicos.PreparaGrillaCuentas(Me.bscCodCuenta)
         Me.bscCodCuenta.Datos = oAsientos.GetCuentas4PorCodigo(Integer.Parse(Me.cmbPlan.SelectedValue.ToString()), Integer.Parse("0" & Me.bscCodCuenta.Text.Trim()))

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodCuenta_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodCuenta.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscDescripcion.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCodCuenta.Text = e.FilaDevuelta.Cells("idCuenta").Value.ToString()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscDescripcion_BuscadorClick() Handles bscDescripcion.BuscadorClick

      Try
         Dim oAsientos As Reglas.ContabilidadAsientos = New Reglas.ContabilidadAsientos
         Me._publicos.PreparaGrillaCuentas(Me.bscDescripcion)
         Me.bscDescripcion.Datos = oAsientos.GetCuentas4PorDescipcion(Integer.Parse(Me.cmbPlan.SelectedValue.ToString()), Me.bscDescripcion.Text.Trim())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscDescripcion_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscDescripcion.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscDescripcion.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCodCuenta.Text = e.FilaDevuelta.Cells("idCuenta").Value.ToString()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmdPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlan.Click

      Dim frmplan As New ContabilidadPlanesCuentasPreView
      frmplan.Padre = Me
      frmplan.IdPlanCuenta = CInt(Me.cmbPlan.SelectedValue)
      frmplan.ShowDialog()

      If Me._nombreCuenta <> String.Empty Then
         Me.bscDescripcion.Text = Me._nombreCuenta
         Me.bscCodCuenta.Text = Me._idCuenta.ToString
      End If
   End Sub
#End Region

#Region "PLAN CUENTA"

   Private Sub GenerarPlanCuentas()

   End Sub

#End Region

#Region "BALANCE"

   Private Sub GenerarBalance()

      If ValidarBalance() Then
         Dim FechaHasta As Date = Me.dtpBalance.Value


         Dim reg As Reglas.ContabilidadReportes = New Reglas.ContabilidadReportes
         Dim oReporteBalance As New Entidades.ContabilidadReporte

         Dim dtsBalance As New dtsBalance
         oReporteBalance = reg.balance(FechaHasta, idPlan, suc.ToArray())


         If oReporteBalance.Balance Is Nothing OrElse oReporteBalance.Balance.Rows.Count = 0 Then
            MessageBox.Show("No se encontraron datos para los filtros seleccionados", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         Try
            dtsBalance.Tables("dtBalance").Merge(oReporteBalance.Balance)
            If Not (oReporteBalance.BalanceN4 Is Nothing) AndAlso oReporteBalance.BalanceN4.Rows.Count <> 0 Then
               dtsBalance.Tables("dtBalance").Merge(oReporteBalance.BalanceN4)
            End If

            'creo la coleccion de parametros
            Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresa))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("fechaHasta", FechaHasta.ToShortDateString))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("PlanCta", Me.cmbPlan.Text))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Sucursal", SucursalesSelect))

            Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.rptBalance.rdlc", "dtsBalance_dtBalance", dtsBalance.Tables("dtBalance"), parm, True)
            frmImprime.Text = "Balance de Sumas y Saldos"
            frmImprime.rvReporte.DocumentMapCollapsed = True
            frmImprime.Size = New Size(780, 600)
            frmImprime.StartPosition = FormStartPosition.CenterScreen
            frmImprime.ShowDialog()

         Catch ex As Exception
            MessageBox.Show(ex.Message, "Imprimir Balance", MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try

      End If

   End Sub

   Private Function ValidarBalance() As Boolean
      Return True
   End Function

#End Region

End Class