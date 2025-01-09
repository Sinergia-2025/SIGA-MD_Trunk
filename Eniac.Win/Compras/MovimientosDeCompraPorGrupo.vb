Public Class MovimientosDeCompraPorGrupo

   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(total As Decimal, dt As DataTable)
      Me.New(total, dt, Modo.Insertar)
   End Sub
   Public Sub New(total As Decimal, dt As DataTable, modo As Modo)
      Me.New()
      _total = total
      _dt = dt
      _modo = modo
      DialogResult = DialogResult.No
   End Sub

   Public Enum Modo
      Insertar
      Modificar
      Consultar
   End Enum


   Private _total As Decimal
   Private _dt As DataTable
   Private _dtExpensas As DataTable
   Private _modo As Modo

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      txtTotalADistribuir.Text = _total.ToString("N2")
      txtTotalDistribuido.Text = (0).ToString("N2")

      InitializeDtExpensas()

      grdExpensas.DataSource = _dtExpensas
      FormatearGrilla()

      MuestraTotalDistribuido()
      If _modo = Modo.Consultar Then
         cmdAceptar.Visible = False
         cmdCancelar.Text = "Cerrar"
      End If
   End Sub

   Private Sub FormatearGrilla()

      With Me.grdExpensas.DisplayLayout.Bands(0)
         .Columns(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString()).Hidden = True
         .Columns(Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString()).Header.Caption = "Grupo de camas"
         .Columns(Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString()).Width = 200
         .Columns(Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString()).CellActivation = Activation.NoEdit
         .Columns("porcentaje").Header.Caption = "Porcentaje"
         .Columns("porcentaje").Width = 80
         .Columns("porcentaje").MaskInput = "{double:-9.2}"
         .Columns("porcentaje").CellAppearance.TextHAlign = HAlign.Right
         .Columns("importe").Header.Caption = "Importe"
         .Columns("importe").Width = 80
         .Columns("importe").MaskInput = "{double:-9.2}"
         .Columns("importe").CellAppearance.TextHAlign = HAlign.Right

         If _modo = Modo.Consultar Then
            .Columns("porcentaje").CellActivation = Activation.NoEdit
            .Columns("porcentaje").Hidden = True
            .Columns("importe").CellActivation = Activation.NoEdit
         End If

      End With
      Me.grdExpensas.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
   End Sub

   Private Sub MuestraTotalDistribuido()
      Dim _totalDistribuido As Decimal = 0
      For Each drExpensas As DataRow In _dtExpensas.Rows
         If Not IsDBNull(drExpensas("importe")) Then
            Dim importe As Decimal = 0
            Decimal.TryParse(drExpensas("importe").ToString(), importe)
            _totalDistribuido += importe
         End If
      Next
      txtTotalDistribuido.Text = _totalDistribuido.ToString("N2")
   End Sub

   Private Sub InitializeDtExpensas()
      _dtExpensas = New DataTable("Expensas")

      _dtExpensas.Columns.Add(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString(), GetType(String))
      _dtExpensas.Columns.Add(Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString(), GetType(String))
      _dtExpensas.Columns.Add("porcentaje", GetType(Decimal))
      _dtExpensas.Columns.Add("importe", GetType(Decimal))

      Dim dtGrupos As DataTable = New Reglas.GruposCamas().GetAll()
      'Dim dtGrupos As DataTable = New Cliente.GruposCamas().GetParaExpensas()

      Dim porcentajeTotal As Decimal = 0

      For Each drGrupos As DataRow In dtGrupos.Rows
         Dim drExpensas As DataRow = _dtExpensas.NewRow()
         drExpensas(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString()) = drGrupos(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString())
         drExpensas(Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString()) = drGrupos(Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString())
         drExpensas("porcentaje") = 0
         drExpensas("importe") = 0

         For Each dr As DataRow In _dt.Rows
            If _dt.Columns.Contains(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString()) AndAlso
               dr(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString()).ToString() = drExpensas(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString()).ToString() Then

               Dim importe As Decimal = 0
               Dim porcentaje As Decimal = 0
               If Not IsDBNull(dr("importe")) Then
                  Decimal.TryParse(dr("importe").ToString(), importe)
               End If

               porcentaje = (importe / _total) * 100
               porcentajeTotal += porcentaje

               drExpensas("importe") = importe
               drExpensas("porcentaje") = porcentaje
            End If
         Next
         _dtExpensas.Rows.Add(drExpensas)
      Next

      If _modo = Modo.Insertar AndAlso porcentajeTotal < 100 Then

         'Si solo tiene uno, corresponderia el 100%.
         If _dtExpensas.Rows.Count = 1 Then
            _dtExpensas(0)("porcentaje") = 100
            _dtExpensas(0)("importe") = _total
         Else
            Dim dr As DataRow() = _dtExpensas.Select(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString() & " = 'GRAL'")
            If dr.Length > 0 Then
               Dim porcentaje As Decimal = 100 - porcentajeTotal
               dr(0)("porcentaje") = porcentaje
               dr(0)("importe") = _total * porcentaje / 100
            End If
         End If

      End If

   End Sub

   Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
      Try
         Aceptar()
         DialogResult = Windows.Forms.DialogResult.Yes
         Close()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         grdExpensas.Focus()
      End Try
   End Sub

   Private Sub Aceptar()
      MuestraTotalDistribuido()

      Dim totADist As Decimal
      Dim totDistr As Decimal

      Decimal.TryParse(txtTotalADistribuir.Text, totADist)
      Decimal.TryParse(txtTotalDistribuido.Text, totDistr)

      If Math.Round(totADist, 2) <> Math.Round(totDistr, 2) Then
         Throw New Exception(String.Format("No es correcta la distribución de expensas. Se deben distribuir {0:N2} y se ha distribuido en total {1:N2}.",
                                           totADist, totDistr))
      End If

      _dt.Rows.Clear()
      For Each drExpensas As DataRow In _dtExpensas.Rows
         Dim dr As DataRow = _dt.NewRow()

         dr(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString()) = drExpensas(Entidades.GrupoCama.Columnas.IdGrupoCama.ToString())
         dr(Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString()) = drExpensas(Entidades.GrupoCama.Columnas.NombreGrupoCama.ToString())
         dr("importe") = drExpensas("importe")

         _dt.Rows.Add(dr)
      Next
   End Sub

   Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
      DialogResult = DialogResult.No
      Close()
   End Sub

   Private Sub grdExpensas_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles grdExpensas.AfterCellUpdate
      If e.Cell.Column.Key = "porcentaje" Then
         Dim porc As Decimal = 0
         Dim totADist As Decimal

         If Not IsDBNull(e.Cell.Row.Cells("porcentaje").Value) Then
            Decimal.TryParse(e.Cell.Row.Cells("porcentaje").Value.ToString(), porc)
         End If
         Decimal.TryParse(txtTotalADistribuir.Text, totADist)

         e.Cell.Row.Cells("importe").Value = totADist * porc / 100
      End If
      MuestraTotalDistribuido()
   End Sub
End Class