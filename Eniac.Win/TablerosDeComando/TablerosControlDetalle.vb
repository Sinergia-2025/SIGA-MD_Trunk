Public Class TablerosControlDetalle
#Region "Campos"
   Private _Publicos As Publicos
#End Region

   Public ReadOnly Property TableroControl As Entidades.TableroControl
      Get
         Return DirectCast(_entidad, Entidades.TableroControl)
      End Get
   End Property

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(idTableroControlPanel1 As Integer, tableroControl As Entidades.TableroControl)
      InitializeComponent()
      _entidad = tableroControl
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _Publicos = New Publicos()

            BindearControles(_entidad, _liSources)

            If StateForm = Win.StateForm.Actualizar Then
               bscCodigoTabCtrlPnl1.Text = TableroControl.IdTableroControlPanel1.ToString()
               bscCodigoTabCtrlPnl2.Text = TableroControl.IdTableroControlPanel2.ToString()
               bscCodigoTabCtrlPnl3.Text = TableroControl.IdTableroControlPanel3.ToString()
               bscCodigoTabCtrlPnl4.Text = TableroControl.IdTableroControlPanel4.ToString()
               bscCodigoTabCtrlPnl5.Text = TableroControl.IdTableroControlPanel5.ToString()
               bscCodigoTabCtrlPnl6.Text = TableroControl.IdTableroControlPanel6.ToString()
               bscCodigoTabCtrlPnl1.PresionarBoton()
               If TableroControl.IdTableroControlPanel2 > 0 Then bscCodigoTabCtrlPnl2.PresionarBoton()
               If TableroControl.IdTableroControlPanel3 > 0 Then bscCodigoTabCtrlPnl3.PresionarBoton()
               If TableroControl.IdTableroControlPanel4 > 0 Then bscCodigoTabCtrlPnl4.PresionarBoton()
               If TableroControl.IdTableroControlPanel5 > 0 Then bscCodigoTabCtrlPnl5.PresionarBoton()
               If TableroControl.IdTableroControlPanel6 > 0 Then bscCodigoTabCtrlPnl6.PresionarBoton()
            Else
               CargarProximoNumero()
            End If
         End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TablerosControl()
   End Function

   'VALIDAR BUSCADOR DETALLE
   'se valida solo el primer buscador porque es el unico requerido, los demas no son necesarios
   Protected Overrides Function ValidarDetalle() As String
      If Not bscCodigoTabCtrlPnl1.Selecciono And Not bscNombrePanel1.Selecciono Then
         bscNombrePanel1.Focus()
         Return "No selecciono el Panel de Control"
      End If
      'Validaciones para que no se repita el mismo codigo del panel de control 1 con los demas buscadores.
      If bscCodigoTabCtrlPnl1.Text = bscCodigoTabCtrlPnl2.Text & bscCodigoTabCtrlPnl3.Text & bscCodigoTabCtrlPnl4.Text & bscCodigoTabCtrlPnl5.Text & bscCodigoTabCtrlPnl6.Text Then
         bscCodigoTabCtrlPnl1.Focus()
         Return "No se pueden repetir los Paneles de Control"
      End If

      Return MyBase.ValidarDetalle()
   End Function

   Protected Overrides Sub Aceptar()
      '1
      Dim regla = New Reglas.TablerosControlPaneles()
      If bscCodigoTabCtrlPnl1.Text.ValorNumericoPorDefecto(0I) > 0 Then
         TableroControl.TableroControlPanel1 = regla.GetUno(bscCodigoTabCtrlPnl1.Text.ValorNumericoPorDefecto(0I))
      Else
         TableroControl.TableroControlPanel1 = Nothing
      End If
      '2
      If bscCodigoTabCtrlPnl2.Text.ValorNumericoPorDefecto(0I) > 0 Then
         TableroControl.TableroControlPanel2 = regla.GetUno(bscCodigoTabCtrlPnl2.Text.ValorNumericoPorDefecto(0I))
      Else
         TableroControl.TableroControlPanel2 = Nothing
      End If
      '3
      If bscCodigoTabCtrlPnl3.Text.ValorNumericoPorDefecto(0I) > 0 Then
         TableroControl.TableroControlPanel3 = regla.GetUno(bscCodigoTabCtrlPnl3.Text.ValorNumericoPorDefecto(0I))
      Else
         TableroControl.TableroControlPanel3 = Nothing
      End If
      '4
      If bscCodigoTabCtrlPnl4.Text.ValorNumericoPorDefecto(0I) > 0 Then
         TableroControl.TableroControlPanel4 = regla.GetUno(bscCodigoTabCtrlPnl4.Text.ValorNumericoPorDefecto(0I))
      Else
         TableroControl.TableroControlPanel4 = Nothing
      End If
      '5
      If bscCodigoTabCtrlPnl5.Text.ValorNumericoPorDefecto(0I) > 0 Then
         TableroControl.TableroControlPanel5 = regla.GetUno(bscCodigoTabCtrlPnl5.Text.ValorNumericoPorDefecto(0I))
      Else
         TableroControl.TableroControlPanel5 = Nothing
      End If
      '6
      If bscCodigoTabCtrlPnl6.Text.ValorNumericoPorDefecto(0I) > 0 Then
         TableroControl.TableroControlPanel6 = regla.GetUno(bscCodigoTabCtrlPnl6.Text.ValorNumericoPorDefecto(0I))
      Else
         TableroControl.TableroControlPanel6 = Nothing
      End If
      MyBase.Aceptar()
   End Sub
#End Region

#Region "Eventos"

#Region "Buscador 1"
   Private Sub bscCodigoTabCtrlPnl1_BuscadorClick() Handles bscCodigoTabCtrlPnl1.BuscadorClick
      TryCatched(
         Sub()
            Dim rTabCtrlPnl = New Reglas.TablerosControlPaneles()
            _Publicos.PreparaGrillaTablerosControlPanel(bscCodigoTabCtrlPnl1)
            bscCodigoTabCtrlPnl1.Datos = rTabCtrlPnl.GetPorCodigo(bscCodigoTabCtrlPnl1.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub

   Private Sub bscCodigoTabCtrlPnl1_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoTabCtrlPnl1.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarControl1(e.FilaDevuelta)
               bscCodigoTabCtrlPnl2.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscNombrePanel1_BuscadorClick() Handles bscNombrePanel1.BuscadorClick
      TryCatched(
         Sub()
            Dim rTabCtrlPnl = New Reglas.TablerosControlPaneles()
            _Publicos.PreparaGrillaTablerosControlPanel(bscNombrePanel1)
            bscNombrePanel1.Datos = rTabCtrlPnl.GetPorNombre(bscNombrePanel1.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscNombrePanel1_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombrePanel1.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarControl1(e.FilaDevuelta)
               bscCodigoTabCtrlPnl2.Focus()
            End If
         End Sub)
   End Sub
#End Region

#Region "Buscador 2"
   Private Sub bscCodigoTabCtrlPnl2_BuscadorClick() Handles bscCodigoTabCtrlPnl2.BuscadorClick
      TryCatched(
         Sub()
            Dim rTabCtrlPnl = New Reglas.TablerosControlPaneles()
            _Publicos.PreparaGrillaTablerosControlPanel(bscCodigoTabCtrlPnl2)
            bscCodigoTabCtrlPnl2.Datos = rTabCtrlPnl.GetPorCodigo(bscCodigoTabCtrlPnl2.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub

   Private Sub bscCodigoTabCtrlPnl2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoTabCtrlPnl2.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarControl2(e.FilaDevuelta)
               bscCodigoTabCtrlPnl3.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscNombrePanel2_BuscadorClick() Handles bscNombrePanel2.BuscadorClick
      TryCatched(
         Sub()
            Dim rTabCtrlPnl = New Reglas.TablerosControlPaneles()
            _Publicos.PreparaGrillaTablerosControlPanel(bscNombrePanel2)
            bscNombrePanel2.Datos = rTabCtrlPnl.GetPorNombre(bscNombrePanel2.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscNombrePanel2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombrePanel2.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarControl2(e.FilaDevuelta)
               bscCodigoTabCtrlPnl3.Focus()
            End If
         End Sub)
   End Sub
#End Region

#Region "Buscador 3"
   Private Sub bscCodigoTabCtrlPnl3_BuscadorClick() Handles bscCodigoTabCtrlPnl3.BuscadorClick
      TryCatched(
         Sub()
            Dim rTabCtrlPnl = New Reglas.TablerosControlPaneles()
            _Publicos.PreparaGrillaTablerosControlPanel(bscCodigoTabCtrlPnl3)
            bscCodigoTabCtrlPnl3.Datos = rTabCtrlPnl.GetPorCodigo(bscCodigoTabCtrlPnl3.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub

   Private Sub bscCodigoTabCtrlPnl3_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoTabCtrlPnl3.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarControl3(e.FilaDevuelta)
               bscCodigoTabCtrlPnl4.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscNombrePanel3_BuscadorClick() Handles bscNombrePanel3.BuscadorClick
      TryCatched(
         Sub()
            Dim rTabCtrlPnl = New Reglas.TablerosControlPaneles
            _Publicos.PreparaGrillaTablerosControlPanel(bscNombrePanel3)
            bscNombrePanel3.Datos = rTabCtrlPnl.GetPorNombre(bscNombrePanel3.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscNombrePanel3_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombrePanel3.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarControl3(e.FilaDevuelta)
               bscCodigoTabCtrlPnl4.Focus()
            End If
         End Sub)
   End Sub
#End Region

#Region "Buscador 4"
   Private Sub bscCodigoTabCtrlPnl4_BuscadorClick() Handles bscCodigoTabCtrlPnl4.BuscadorClick
      TryCatched(
         Sub()
            Dim rTabCtrlPnl = New Reglas.TablerosControlPaneles()
            _Publicos.PreparaGrillaTablerosControlPanel(Me.bscCodigoTabCtrlPnl4)
            bscCodigoTabCtrlPnl4.Datos = rTabCtrlPnl.GetPorCodigo(bscCodigoTabCtrlPnl4.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub

   Private Sub bscCodigoTabCtrlPnl4_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoTabCtrlPnl4.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarControl4(e.FilaDevuelta)
               bscCodigoTabCtrlPnl5.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscNombrePanel4_BuscadorClick() Handles bscNombrePanel4.BuscadorClick
      TryCatched(
         Sub()
            Dim rTabCtrlPnl = New Reglas.TablerosControlPaneles()
            _Publicos.PreparaGrillaTablerosControlPanel(bscNombrePanel4)
            bscNombrePanel4.Datos = rTabCtrlPnl.GetPorNombre(bscNombrePanel4.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscNombrePanel4_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombrePanel4.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarControl4(e.FilaDevuelta)
               bscCodigoTabCtrlPnl5.Focus()
            End If
         End Sub)
   End Sub
#End Region

#Region "Buscador 5"
   Private Sub bscCodigoTabCtrlPnl5_BuscadorClick() Handles bscCodigoTabCtrlPnl5.BuscadorClick
      TryCatched(
         Sub()
            Dim rTabCtrlPnl = New Reglas.TablerosControlPaneles()
            _Publicos.PreparaGrillaTablerosControlPanel(bscCodigoTabCtrlPnl5)
            bscCodigoTabCtrlPnl5.Datos = rTabCtrlPnl.GetPorCodigo(bscCodigoTabCtrlPnl5.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub

   Private Sub bscCodigoTabCtrlPnl5_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoTabCtrlPnl5.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarControl5(e.FilaDevuelta)
               bscCodigoTabCtrlPnl6.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscNombrePanel5_BuscadorClick() Handles bscNombrePanel5.BuscadorClick
      TryCatched(
         Sub()
            Dim rTabCtrlPnl = New Reglas.TablerosControlPaneles()
            _Publicos.PreparaGrillaTablerosControlPanel(bscNombrePanel5)
            bscNombrePanel5.Datos = rTabCtrlPnl.GetPorNombre(Me.bscNombrePanel5.Text.Trim())
         End Sub)

   End Sub

   Private Sub bscNombrePanel5_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombrePanel5.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarControl5(e.FilaDevuelta)
               bscCodigoTabCtrlPnl6.Focus()
            End If
         End Sub)
   End Sub
#End Region

#Region "Buscador 6"
   Private Sub bscCodigoTabCtrlPnl6_BuscadorClick() Handles bscCodigoTabCtrlPnl6.BuscadorClick
      TryCatched(
         Sub()
            Dim rTabCtrlPnl = New Reglas.TablerosControlPaneles()
            _Publicos.PreparaGrillaTablerosControlPanel(bscCodigoTabCtrlPnl6)
            bscCodigoTabCtrlPnl6.Datos = rTabCtrlPnl.GetPorCodigo(bscCodigoTabCtrlPnl6.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub

   Private Sub bscCodigoTabCtrlPnl6_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoTabCtrlPnl6.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarControl6(e.FilaDevuelta)
               txtFiltro.Focus()
            End If
         End Sub)
   End Sub

   Private Sub bscNombrePanel6_BuscadorClick() Handles bscNombrePanel6.BuscadorClick
      TryCatched(
         Sub()
            Dim rTabCtrlPnl = New Reglas.TablerosControlPaneles()
            _Publicos.PreparaGrillaTablerosControlPanel(Me.bscNombrePanel6)
            bscNombrePanel6.Datos = rTabCtrlPnl.GetPorNombre(Me.bscNombrePanel6.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscNombrePanel6_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombrePanel6.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarControl6(e.FilaDevuelta)
               txtFiltro.Focus()
            End If
         End Sub)
   End Sub
#End Region

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtIdTableroControl.Focus()
   End Sub
#End Region

#Region "Metodos"
   'Eventos CargaControl especificos para cada buscador
   Private Sub CargarControl1(dr As DataGridViewRow)
      bscCodigoTabCtrlPnl1.Text = dr.Cells("IdTableroControlPanel").Value.ToString()
      bscNombrePanel1.Text = dr.Cells("NombrePanel").Value.ToString()
   End Sub

   Private Sub CargarControl2(dr As DataGridViewRow)
      bscCodigoTabCtrlPnl2.Text = dr.Cells("IdTableroControlPanel").Value.ToString()
      bscNombrePanel2.Text = dr.Cells("NombrePanel").Value.ToString()
   End Sub

   Private Sub CargarControl3(dr As DataGridViewRow)
      bscCodigoTabCtrlPnl3.Text = dr.Cells("IdTableroControlPanel").Value.ToString()
      bscNombrePanel3.Text = dr.Cells("NombrePanel").Value.ToString()
   End Sub

   Private Sub CargarControl4(dr As DataGridViewRow)
      bscCodigoTabCtrlPnl4.Text = dr.Cells("IdTableroControlPanel").Value.ToString()
      bscNombrePanel4.Text = dr.Cells("NombrePanel").Value.ToString()
   End Sub

   Private Sub CargarControl5(dr As DataGridViewRow)
      bscCodigoTabCtrlPnl5.Text = dr.Cells("IdTableroControlPanel").Value.ToString()
      bscNombrePanel5.Text = dr.Cells("NombrePanel").Value.ToString()
   End Sub

   Private Sub CargarControl6(dr As DataGridViewRow)
      bscCodigoTabCtrlPnl6.Text = dr.Cells("IdTableroControlPanel").Value.ToString()
      bscNombrePanel6.Text = dr.Cells("NombrePanel").Value.ToString()
   End Sub
   Private Sub CargarProximoNumero()
      Dim rTableroCtrl As Reglas.TablerosControl = New Reglas.TablerosControl()
      txtIdTableroControl.Text = (rTableroCtrl.GetCodigoMaximo(bscCodigoTabCtrlPnl1.Text.ValorNumericoPorDefecto(0I)) + 1).ToString()
   End Sub
#End Region
End Class