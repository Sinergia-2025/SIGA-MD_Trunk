Imports Eniac.Entidades

Public Class SucursalesVinculacion
   Private Property Sucursal As Entidades.Sucursal
   Private _publicos As Publicos

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub
   Public Sub New(sucursal As Entidades.Sucursal)
      Me.New()

      Me.Sucursal = sucursal
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(Sub() InicializaCombos())

      TryCatched(Sub() CargarPantalla())

   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.Escape Then
         btnCancelar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function


#Region "Eventos"
   Private Sub cmbSucursales_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSucursales.SelectedValueChanged
      TryCatched(Sub() CambioSucursal())
   End Sub


   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
         Sub()
            Dim regla = New Reglas.Sucursales()
            If Sucursal.IdSucursalAsociada <> 0 Then
               regla.DesvincularSucursales(Sucursal.IdSucursal)
            Else
               regla.VincularSucursales(Sucursal.IdSucursal, cmbSucursales.ValorSeleccionado(Of Integer), ugVincularDepositos.DataSource(Of DataSet))
            End If
            DialogResult = DialogResult.OK
            Close()
         End Sub)
   End Sub

   Private Sub btnAsociarDepositos_Click(sender As Object, e As EventArgs) Handles btnAsociarDepositos.Click
      TryCatched(Sub() AsociarDepositos())
   End Sub
   Private Sub btnCopiarDeposito_Click(sender As Object, e As EventArgs) Handles btnCopiarDeposito.Click
      TryCatched(Sub() CopiarDepositos())
   End Sub

#End Region

#Region "Métodos"
   Private Sub InicializaCombos()
      _publicos.CargaComboSucursales(cmbSucursales)
   End Sub
   Private Sub CambioSucursal()
      If Sucursal.IdSucursalAsociada = 0 Then
         Using errBuilder = New Entidades.ErrorBuilder()
            Dim selSuc = New Reglas.Sucursales().GetUna(cmbSucursales.ValorSeleccionado(Of Integer), incluirLogo:=False)
            If selSuc IsNot Nothing Then
               If Sucursal.IdSucursal = selSuc.IdSucursal Then
                  errBuilder.AddError("NO SE PUEDE VINCULAR LA SUCURSAL A SI MISMA")
               End If
               If Sucursal.IdEmpresa <> selSuc.IdEmpresa Then
                  errBuilder.AddError("LA SUCURSAL SELECCIONADA PARTENECE A OTRA EMPRESA")
               End If
               If selSuc.IdSucursalAsociada <> 0 Then
                  errBuilder.AddError("LA SUCURSAL SELECCIONADA SE ENCUENTRA VINCULADA A OTRA SUCURSAL")
               End If
            End If
            lblMensajeValidacion.Text = errBuilder.ToString()
            lblMensajeValidacion.Visible = errBuilder.Any()

            If Not errBuilder.AnyError() Then
               CargaGrillaParaVincular()
            End If
         End Using
      End If
   End Sub
   Private Sub CargarPantalla()
      txtIdSucursal.SetValor(Sucursal.Id)
      txtNombre.Text = Sucursal.Nombre
      txtNombreEmpresa.Text = Sucursal.NombreEmpresa

      lblSucursalesVinculadas.Visible = Sucursal.IdSucursalAsociada <> 0
      lblSucursalesNoVinculadas.Visible = Not lblSucursalesVinculadas.Visible
      If Sucursal.IdSucursalAsociada <> 0 Then
         cmbSucursales.SelectedValue = Sucursal.IdSucursalAsociada
         cmbSucursales.Enabled = False

         CargaGrillaSegunSucursales()

         Text = "Desvincular Sucursales"

      Else
         cmbSucursales.Enabled = True

         'CargaGrillaParaVincular()

         Text = "Vincular Sucursal"

      End If
   End Sub
   Private Sub CargaGrillaSegunSucursales()
      Dim regla = New Reglas.Sucursales()
      ugVincularDepositos.DataSource = regla.GetParaDesvincular(Sucursal.IdSucursal)

      FormatearGrillaDepositos()
   End Sub

   Private Sub FormatearGrillaDepositos()
      ugVincularDepositos.DisplayLayout.Bands.OfType(Of UltraGridBand).ToList().ForEach(Sub(b) b.OcultaTodasLasColumnas())

      Dim pos = 0I
      With ugVincularDepositos.DisplayLayout
         With .Bands(0)
            .Columns("CodigoDeposito").FormatearColumna("Código", pos, 80)
            .Columns("NombreDeposito").FormatearColumna("Nombre", pos, 120)

            .Columns("EstadoVinculacion").FormatearColumna("Estado", pos, 120, HAlign.Center, Sucursal.IdSucursalAsociada <> 0)

            .Columns("CodigoDepositoAsociado").FormatearColumna("Código", pos, 80)
            .Columns("NombreDepositoAsociado").FormatearColumna("Nombre", pos, 120)
         End With

         If .Bands.Count > 1 Then
            pos = 0I
            With .Bands(1)
               .Columns("CodigoUbicacion").FormatearColumna("Código", pos, 80)
               .Columns("NombreUbicacion").FormatearColumna("Nombre", pos, 120)

               .Columns("EstadoVinculacion").FormatearColumna("Estado", pos, 120, HAlign.Center, Sucursal.IdSucursalAsociada <> 0)

               .Columns("CodigoUbicacionAsociada").FormatearColumna("Código", pos, 80)
               .Columns("NombreUbicacionAsociada").FormatearColumna("Nombre", pos, 120)
            End With
         End If
      End With

      ugVincularDepositos.ColapsarExpandir(AccionColapsarExpandir.Expandir)
   End Sub

   Private Sub CargaGrillaParaVincular()
      Dim regla = New Reglas.Sucursales()
      ugVincularDepositos.DataSource = regla.GetParaVincular(Sucursal.IdSucursal, cmbSucursales.ValorSeleccionado(Of Integer))

      FormatearGrillaDepositos()
   End Sub

   Private Function GetFilasSeleccionados() As IEnumerable(Of DataRow)
      'drCol As IEnumerable(Of DataRow)
      Return ugVincularDepositos.Selected.Cells.OfType(Of UltraGridCell).ToList().
             ConvertAll(Function(udc) udc.Row.FilaSeleccionada(Of DataRow)).Where(Function(dr) dr IsNot Nothing).Distinct()
   End Function

   Private Sub AsociarDepositos()
      Dim regla = New Reglas.Sucursales()
      regla.VincularDepositos(GetFilasSeleccionados(), ugVincularDepositos.DataSource(Of DataSet))
   End Sub

   Private Sub CopiarDepositos()
      Dim regla = New Reglas.Sucursales()
      regla.CopiarDepositos(GetFilasSeleccionados(), ugVincularDepositos.DataSource(Of DataSet))
   End Sub

#End Region

End Class