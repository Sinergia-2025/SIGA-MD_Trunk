Option Explicit On
Option Strict On

Public Class ConsultarCodigosLibres

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Dim arrMaestros As ArrayList = New ArrayList
      arrMaestros.Insert(0, "Productos")
      arrMaestros.Insert(1, "Marcas")
      arrMaestros.Insert(2, "Rubros")

      Me.cmbTabla.DataSource = arrMaestros

      Me.cmbTabla.SelectedIndex = 0

      Me.tssRegistros.Text = "0 Registros"

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Function Valida() As Boolean
      If Me.txtDesde.Text.Length = 0 Then
         MessageBox.Show("Debe ingresar un número desde.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtDesde.Focus()
         Return False
      End If
      If Me.txtHasta.Text.Length = 0 Then
         MessageBox.Show("Debe ingresar un número hasta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtHasta.Focus()
         Return False
      End If
      If Int32.Parse(Me.txtDesde.Text) > Int32.Parse(Me.txtHasta.Text) Then
         MessageBox.Show("El número desde, debe ser menor o igual que hasta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtDesde.Focus()
         Return False
      End If
      Return True
   End Function
   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
      Try
         If Me.Valida() Then
            Me.ConsultarCL()
         End If
      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ConsultarCL()
      Dim dtP As DataTable = New DataTable()
      dtP.Columns.Add(New DataColumn("Col1", System.Type.GetType("System.Int32")))
      dtP.Columns.Add(New DataColumn("Col2", System.Type.GetType("System.Int32")))
      dtP.Columns.Add(New DataColumn("Col3", System.Type.GetType("System.Int32")))
      dtP.Columns.Add(New DataColumn("Col4", System.Type.GetType("System.Int32")))
      dtP.Columns.Add(New DataColumn("Col5", System.Type.GetType("System.Int32")))
      dtP.Columns.Add(New DataColumn("Col6", System.Type.GetType("System.Int32")))
      dtP.Columns.Add(New DataColumn("Col7", System.Type.GetType("System.Int32")))
      dtP.Columns.Add(New DataColumn("Col8", System.Type.GetType("System.Int32")))

      Dim dt As DataTable = Me.GetDT()
      Dim dr As DataRow = Nothing

      Dim con As Int32 = 0
      Dim drP As DataRow = dtP.NewRow()
      Dim Cantidad As Integer = 0

      'recorro la cota de numero que ingreso para consultar
      For i As Int64 = Int64.Parse(Me.txtDesde.Text) To Int64.Parse(Me.txtHasta.Text)
         If Me.cmbTabla.Text = "Productos" Then
            dr = dt.Rows.Find(i.ToString().PadLeft(15))
         Else
            dr = dt.Rows.Find(i)
         End If
         If dr Is Nothing Then
            Cantidad = Cantidad + 1
            drP(con) = i
            con += 1
            If con = 8 Then
               dtP.Rows.Add(drP)
               drP = dtP.NewRow()
               con = 0
            End If
         End If
      Next
      If con <> 0 Then
         dtP.Rows.Add(drP)
      End If

      Me.dgvCodigoLibres.DataSource = dtP

      Me.tssRegistros.Text = Cantidad.ToString() & " Registros"

   End Sub

   Private Function GetDT() As DataTable
      Dim dt As DataTable
      Dim col() As DataColumn
      Select Case Me.cmbTabla.Text
         Case "Productos"
            Dim reg As Reglas.Productos = New Reglas.Productos()
            dt = reg.GetAll()
            col = New DataColumn() {dt.Columns("IdProducto")}
         Case "Marcas"
            Dim reg As Reglas.Marcas = New Reglas.Marcas()
            dt = reg.GetAll()
            col = New DataColumn() {dt.Columns("IdMarca")}
         Case "Rubros"
            Dim reg As Reglas.Rubros = New Reglas.Rubros()
            dt = reg.GetAll()
            col = New DataColumn() {dt.Columns("IdRubro")}
         Case Else
            Return Nothing
      End Select
      dt.PrimaryKey = col
      Return dt
   End Function

   Private Sub cmbTabla_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTabla.SelectedIndexChanged

      Select Case Me.cmbTabla.Text
         Case "Marcas"
            Dim reg As Reglas.Marcas = New Reglas.Marcas()
            Me.txtHasta.Text = reg.GetCodigoMaximo().ToString()

         Case "Rubros"
            Dim reg As Reglas.Rubros = New Reglas.Rubros()
            Me.txtHasta.Text = reg.GetCodigoMaximo().ToString()

         Case Else
            'Case "Productos"
            Dim reg As Reglas.Productos = New Reglas.Productos()
            Me.txtHasta.Text = reg.GetCodigoMaximo().ToString()
            'Nada...
      End Select

      If Not Me.dgvCodigoLibres.DataSource Is Nothing Then
         DirectCast(Me.dgvCodigoLibres.DataSource, DataTable).Rows.Clear()
         Me.tssRegistros.Text = "0 Registros"
      End If

   End Sub


End Class
