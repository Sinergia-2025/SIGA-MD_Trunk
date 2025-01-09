Option Explicit On
Option Strict On

Public Class ContabilidadAsientoInterno
    Private _dtGrilla As DataTable
    Private _concepto As String
    Private _origen As String
    Private _frmPadre As Windows.Forms.Form

    Public Property frmPadre() As Windows.Forms.Form
        Get
            Return _frmPadre
        End Get
        Set(ByVal value As Windows.Forms.Form)
            _frmPadre = value
        End Set
    End Property

    Public Property concepto() As String
        Get
            Return _concepto
        End Get
        Set(ByVal value As String)
            _concepto = value
        End Set
    End Property

    Public Property dtGrilla() As DataTable
        Get
            Return _dtGrilla
        End Get
        Set(ByVal value As DataTable)
            _dtGrilla = value
        End Set
    End Property

    Public Property origen() As String
        Get
            Return _origen
        End Get
        Set(ByVal value As String)
            _origen = value
        End Set
    End Property

    Private Sub ContabilidadAsientoInterno_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.dtAsientos.DataSource = Me._dtGrilla
        formatoGrilla()
        Me.txtConcepto.Text = Me._concepto

        getTotalesGrilla()
        
    End Sub


    Private Sub getTotalesGrilla()

        Me.txtTotalDebe.Text = Decimal.Parse(dtGrilla.Compute("sum(debeValor)", "").ToString()).ToString("##,##0.00")
        Me.txtTotalHaber.Text = Decimal.Parse(dtGrilla.Compute("sum(haberValor)", "").ToString()).ToString("##,##0.00")

        If Me.txtTotalDebe.Text <> Me.txtTotalHaber.Text Then
            Me.lblTotales.ForeColor = Color.Red
        Else
            Me.lblTotales.ForeColor = Color.Green
        End If


    End Sub

    Private Sub formatoGrilla()

        'select cr.idRubro,cr.IdCuenta,cc.NombreCuenta 
        ' ,cr.debe,cr.haber,cr.campo 
        ' ,p.IdProducto,p.NombreProducto 
        ' ,0 as debeValor, 0 as haberValor 


        Me.dtAsientos.DisplayLayout.Bands(0).Columns("debe").Hidden = True
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("haber").Hidden = True
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("campo").Hidden = True
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("tipo").Hidden = True
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idplanCuenta").Hidden = True

        'Me.dtAsientos.DisplayLayout.Bands(0).Columns("tipodocSocio").Hidden = True
        'Me.dtAsientos.DisplayLayout.Bands(0).Columns("horarioGrabar").Hidden = True
        'Me.dtAsientos.DisplayLayout.Bands(0).Columns("NombreCuenta").AutoSizeMode = UltraWinGrid.ColumnAutoSizeMode.Default

        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idRubro").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idRubro").MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idRubro").MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idRubro").MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idRubro").MergedCellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idRubro").Header.Caption = "Rubro"
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idRubro").Width = 50

        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idProducto").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idProducto").MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idProducto").MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idProducto").MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idProducto").MergedCellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True

        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idProducto").Header.Caption = "Cod. Prod."
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("idProducto").Width = 60


        Me.dtAsientos.DisplayLayout.Bands(0).Columns("nombreProducto").MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("nombreProducto").MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("nombreProducto").MergedCellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("nombreProducto").MergedCellAppearance.TextHAlign = Infragistics.Win.HAlign.Center
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("nombreProducto").MergedCellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("nombreProducto").Header.Caption = "Producto"
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("nombreProducto").Width = 160

        Me.dtAsientos.DisplayLayout.Bands(0).Columns("debeValor").CellClickAction = UltraWinGrid.CellClickAction.Edit
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("debeValor").Header.Caption = "Debe"
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("debeValor").Width = 50

        Me.dtAsientos.DisplayLayout.Bands(0).Columns("haberValor").CellClickAction = UltraWinGrid.CellClickAction.Edit
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("haberValor").Header.Caption = "Haber"
        Me.dtAsientos.DisplayLayout.Bands(0).Columns("haberValor").Width = 50




        Dim indiceProximo As Integer = 1
        For indiceActual As Integer = 0 To Me.dtAsientos.Rows.Count - 1

            If indiceActual = Me.dtAsientos.Rows.Count - 1 Then Exit Sub

            If dtAsientos.Rows(indiceActual).Cells("idRubro").Value.ToString = dtAsientos.Rows(indiceProximo).Cells("idRubro").Value.ToString And _
                dtAsientos.Rows(indiceActual).Cells("tipo").Value.ToString = dtAsientos.Rows(indiceProximo).Cells("tipo").Value.ToString And _
                dtAsientos.Rows(indiceActual).Cells("campo").Value.ToString = dtAsientos.Rows(indiceProximo).Cells("campo").Value.ToString And _
                dtAsientos.Rows(indiceActual).Cells("debe").Value.ToString = dtAsientos.Rows(indiceProximo).Cells("debe").Value.ToString Then

                Me.dtAsientos.DisplayLayout.Rows(indiceActual).Cells("debevalor").Appearance.BackColor = Color.LightGreen
                Me.dtAsientos.DisplayLayout.Rows(indiceActual).Cells("habervalor").Appearance.BackColor = Color.LightGreen
                Me.dtAsientos.DisplayLayout.Rows(indiceProximo).Cells("debevalor").Appearance.BackColor = Color.LightGreen
                Me.dtAsientos.DisplayLayout.Rows(indiceProximo).Cells("habervalor").Appearance.BackColor = Color.LightGreen
            End If
            indiceProximo += 1
        Next

    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        If Validar() Then

            If (TypeOf (Me.frmPadre) Is FacturacionV2) Then
                DirectCast(Me.frmPadre, FacturacionV2).tablaAsientos = DirectCast(Me.dtAsientos.DataSource, DataTable)
            End If

            If (TypeOf (Me.frmPadre) Is MovimientosDeCompras) Then
                DirectCast(Me.frmPadre, MovimientosDeCompras).tablaAsientos = DirectCast(Me.dtAsientos.DataSource, DataTable)
            End If


            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End If

    End Sub

    Private Function Validar() As Boolean

        Dim dtaux As DataTable = DirectCast(Me.dtAsientos.DataSource, DataTable)
        Dim debe As Decimal = Decimal.Parse(dtaux.Compute("sum(debevalor)", "").ToString)
        Dim haber As Decimal = Decimal.Parse(dtaux.Compute("sum(haberValor)", "").ToString)

        If debe = haber Then
            Return True
        Else
            MessageBox.Show("Verificar Balanceo, la suma del Debe y el Haber debe ser cero", "Asientos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtTotalDebe.Focus()
            Return False
        End If


        Return False

    End Function

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dtAsientos_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtAsientos.AfterCellUpdate
        getTotalesGrilla()
    End Sub
End Class