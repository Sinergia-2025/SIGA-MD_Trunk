Imports Microsoft.Reporting.WinForms

Public Class BaseForm
   Implements IConIdFuncion

   Public Property IdFuncion As String Implements IConIdFuncion.IdFuncion

   Private _cal As Calculadora = New Calculadora()

   Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
      MyBase.OnKeyUp(e)
      If e.Control And e.KeyCode = Keys.W Then
         Me.Close()
      End If
      If e.Control And e.KeyCode = Keys.K Then
         If TypeOf Me.ActiveControl Is Eniac.Controles.TextBox Then
            Me._cal.ulcCalculadora.Clear()

            Dim int As Decimal = 0

            If Not String.IsNullOrEmpty(DirectCast(Me.ActiveControl, Eniac.Controles.TextBox).Text) And IsNumeric(DirectCast(Me.ActiveControl, Eniac.Controles.TextBox).Text) Then
               int = Decimal.Parse(DirectCast(Me.ActiveControl, Eniac.Controles.TextBox).Text)
            End If

            If int <> 0 Then
               'Me._cal.ulcCalculadora.Text = int.ToString()
               Dim str() As Char = int.ToString().ToArray()
               For Each cr As Char In str
                  Me._cal.ulcCalculadora.PushButton(cr)
               Next
            End If

            If Me._cal.ShowDialog() = Windows.Forms.DialogResult.OK Then
               DirectCast(Me.ActiveControl, Eniac.Controles.TextBox).Text = Me._cal.ulcCalculadora.Text
            End If

         End If
      End If

   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      If Entidades.Usuario.Actual.Sucursal IsNot Nothing Then
         If Entidades.Usuario.Actual.Sucursal.ColorSucursal <> 0 Then
            If Entidades.Usuario.Actual.Sucursal.ColorSucursal <> -1 Then
               Me.BackColor = System.Drawing.Color.FromArgb(Entidades.Usuario.Actual.Sucursal.ColorSucursal)
            End If
         End If
      End If

      Traducciones.SetearControles(Me)

   End Sub

   <Obsolete("Utilizar PreferenciasLeer(Infragistics.Win.UltraWinGrid.UltraGrid, ToolStripButton)")>
   Public Sub PreferenciasLeer(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
      PreferenciasLeer(grid, Nothing)
   End Sub

   Public Sub PreferenciasLeer(grid As Infragistics.Win.UltraWinGrid.UltraGrid, tsbPreferencias As ToolStripButton)
      PreferenciasLeer(grid:=grid, sufijoXML:=Nothing, tsbPreferencias:=tsbPreferencias)
   End Sub

   '# Nuevo
   Public Sub PreferenciasLeer(grid As Infragistics.Win.UltraWinGrid.UltraGrid, sufijoXML As String, tsbPreferencias As ToolStripButton)
      Dim nameGrid As String = String.Empty
      Try
         nameGrid = grid.FindForm().Name + sufijoXML + "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            grid.DisplayLayout.LoadFromXml(nameGrid)
         End If

         SetColorBotonPreferencias(grid, sufijoXML, tsbPreferencias)

      Catch ex As Exception
         'si por algun motivo el archivo esta mal confeccionado o es viejo o tiene problemas lo elimina
         'de la carpeta sin dar error
         System.IO.File.Delete(nameGrid)
      End Try
   End Sub

   Public Sub SetColorBotonPreferencias(grid As Infragistics.Win.UltraWinGrid.UltraGrid, tsbPreferencias As ToolStripButton)
      SetColorBotonPreferencias(grid:=grid, sufijoXML:=Nothing, tsbPreferencias:=tsbPreferencias)
   End Sub

   '# Nuevo
   Public Sub SetColorBotonPreferencias(grid As Infragistics.Win.UltraWinGrid.UltraGrid, sufijoXML As String, tsbPreferencias As ToolStripButton)
      If tsbPreferencias IsNot Nothing Then
         If System.IO.File.Exists(grid.FindForm().Name + sufijoXML + "Grid.xml") Then
            tsbPreferencias.BackColor = Color.DarkGray
         Else
            tsbPreferencias.BackColor = Nothing
         End If
      End If
   End Sub

   <Obsolete("Utilizar PreferenciasCargar(Infragistics.Win.UltraWinGrid.UltraGrid, ToolStripButton)")>
   Public Sub PreferenciasCargar(grid As Infragistics.Win.UltraWinGrid.UltraGrid)
      PreferenciasCargar(grid, Nothing)
   End Sub
   Public Sub PreferenciasCargar(grid As Infragistics.Win.UltraWinGrid.UltraGrid, tsbPreferencias As ToolStripButton)
      PreferenciasCargar(grid:=grid, sufijoXML:=String.Empty, tsbPreferencias:=tsbPreferencias)
   End Sub
   Public Sub PreferenciasCargar(grid As Infragistics.Win.UltraWinGrid.UltraGrid, sufijoXML As String, tsbPreferencias As ToolStripButton)
      Dim pre As Preferencias = New Preferencias(grid, True)
      pre.SufijoXML = sufijoXML
      pre.ShowDialog()
      SetColorBotonPreferencias(grid, tsbPreferencias)
   End Sub

   Protected Sub EnterClickBoton(boton As Button, e As System.Windows.Forms.KeyEventArgs)
      If e.KeyCode = Keys.Enter Then
         boton.PerformClick()
      End If
   End Sub

   Public Sub PresionarTab(e As KeyEventArgs)
      PresionarTab(e, Nothing)
   End Sub

   Protected Sub PresionarTab(e As KeyEventArgs, accionAdicional As Action)
      TryCatched(Sub()
                    If e.KeyCode = Keys.Enter Then
                       Me.ProcessTabKey(True)
                       If accionAdicional IsNot Nothing Then accionAdicional()
                    End If
                 End Sub)
   End Sub
   Protected Sub PresionarTab(e As KeyPressEventArgs)
      TryCatched(Sub()
                    If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                       Me.ProcessTabKey(True)
                    End If
                 End Sub)
   End Sub

   Public Overridable Function GetColumnasVisiblesGrilla(grilla As UltraWinGrid.UltraGrid) As Dictionary(Of String, String)
      Return GetColumnasVisiblesGrilla(grilla.DisplayLayout.Bands(0))
   End Function

   Protected Overridable Function GetColumnasVisiblesGrilla(banda As UltraWinGrid.UltraGridBand) As Dictionary(Of String, String)
      Dim _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
      For Each col As UltraWinGrid.UltraGridColumn In banda.Columns
         If Not col.Hidden Then
            _tit.Add(col.Key, String.Empty)
         End If
      Next
      Return _tit
   End Function

   Public Overridable Function AjustarColumnasGrilla(grilla As UltraWinGrid.UltraGrid, tit As Dictionary(Of String, String)) As Integer
      Return AjustarColumnasGrilla(grilla.DisplayLayout.Bands(0), tit)
   End Function

   Protected Overridable Function AjustarColumnasGrilla(banda As UltraWinGrid.UltraGridBand, tit As Dictionary(Of String, String)) As Integer
      'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
      'tit("NOMBRECOLUMNA") = "NUEVO HEADER"
      Dim visiblePosition As Integer = -1

      For Each col As UltraWinGrid.UltraGridColumn In banda.Columns
         If Not col.IsChaptered Then
            col.Hidden = Not tit.ContainsKey(col.Key)
         End If
         If tit.ContainsKey(col.Key) Then
            If Not String.IsNullOrWhiteSpace(tit(col.Key)) Then
               col.Header.Caption = tit(col.Key)
            End If
            visiblePosition = Math.Max(col.Header.VisiblePosition, visiblePosition)
         End If
      Next
      Return Math.Max(visiblePosition, 0)
   End Function


   Protected Overridable Function GetColumnasVisiblesGrilla(grilla As DataGridView) As Dictionary(Of String, String)
      Dim _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()
      For Each col As DataGridViewColumn In grilla.Columns
         If col.Visible Then
            _tit.Add(col.Name, String.Empty)
         End If
      Next
      Return _tit
   End Function
   Protected Overridable Function GetOrdenColumnasGrilla(grilla As DataGridView) As Dictionary(Of String, Integer)
      Dim _tit = New Dictionary(Of String, Integer)()
      For Each col As DataGridViewColumn In grilla.Columns.OfType(Of DataGridViewColumn).OrderBy(Function(c) c.DisplayIndex)
         _tit.Add(col.Name, col.DisplayIndex)
      Next
      Return _tit
   End Function

   Protected Overridable Sub AjustarColumnasGrilla(grilla As DataGridView, tit As Dictionary(Of String, String))
      'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
      'tit("NOMBRECOLUMNA") = "NUEVO HEADER"

      Dim index As Integer = 0
      For Each col As DataGridViewColumn In grilla.Columns
         col.Visible = tit.ContainsKey(col.Name)
         col.DisplayIndex = index
         index += 1
         If tit.ContainsKey(col.Name) Then
            If Not String.IsNullOrWhiteSpace(tit(col.Name)) Then
               col.HeaderText = tit(col.Name)
            End If
         End If
      Next
   End Sub
   Protected Overridable Sub AjustarOrdenColumnasGrilla(grilla As DataGridView, ord As Dictionary(Of String, Integer))
      Dim colNames = grilla.Columns.OfType(Of DataGridViewColumn).ToList().ConvertAll(Function(c) c.Name)
      For Each o In ord.ToList().OrderByDescending(Function(o1) o1.Value)
         If colNames.Contains(o.Key) Then
            grilla.Columns.Item(o.Key).DisplayIndex = o.Value
         End If
      Next
   End Sub

   Public Overloads Function ShowDialog(owner As BaseForm) As DialogResult
      IdFuncion = owner.IdFuncion
      Return MyBase.ShowDialog(owner)
   End Function

End Class