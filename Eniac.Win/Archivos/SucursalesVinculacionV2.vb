Imports Eniac.Entidades

Public Class SucursalesVinculacionV2

#Region "Campos"
   Private _publicos As Publicos
   Private _cargandoPantalla As Boolean

   Public Property sucOrigen As Entidades.Sucursal
#End Region

#Region "New"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(sucursal As Entidades.Sucursal)
      Me.New()
      sucOrigen = sucursal
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(
         Sub()
            '--
            Me._cargandoPantalla = True
            '-- Carga Deposito Origen.- ---------------------------------------------------------
            _publicos.CargaComboDepositos(cmbDepositoOrigen, sucOrigen.IdSucursal, miraUsuario:=False, permiteEscritura:=False, Entidades.Publicos.SiNoTodos.TODOS)
            '-- Carga Sucursal Asociada.- -------------------------------------------------------
            _publicos.CargaComboSucursales(cmbSucursalAsociada)
            cmbSucursalAsociada.SelectedIndex = -1
            '--
            With sucOrigen
               cmbSucursalOrigen.Text = .Nombre
               txtEmpresaOrigen.Text = .NombreEmpresa
            End With
            '--
            Me._cargandoPantalla = False
            btnDesvincular.Enabled = False
            '--
            If sucOrigen.IdSucursalAsociada <> 0 Then
               cmbSucursalAsociada.SelectedValue = sucOrigen.IdSucursalAsociada
               cmbSucursalAsociada.Enabled = False
               btnDesvincular.Enabled = True
               Text = "Desvincular Sucursales"
            Else
               cmbSucursalAsociada.SelectedIndex = -1
               Text = "Vincular Sucursales"
            End If
            '-----------------------------------------------------------------------------------
            CargaGrillaVinculacion()
         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.Escape Then
         btnCancelar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnVincular.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
   Private Sub cmbSucursalAsociada_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSucursalAsociada.SelectedValueChanged
      TryCatched(
      Sub()
         If Not _cargandoPantalla Then
            Dim dr = cmbSucursalAsociada.ItemSeleccionado(Of DataRow)()
            If dr IsNot Nothing Then
               txtEmpresaAsociada.Text = New Reglas.Sucursales().GetUna(dr.Field(Of Integer)(Entidades.Sucursal.Columnas.IdSucursal.ToString()), False).NombreEmpresa
               If dr.Field(Of Integer)(Entidades.Sucursal.Columnas.IdSucursal.ToString()) = sucOrigen.IdSucursal Then
                  InicializaAsociados()
                  ShowMessage("NO SE PUEDE VINCULAR LA SUCURSAL A SI MISMA")
               Else
                  If dr.Field(Of Integer)(Entidades.Sucursal.Columnas.IdEmpresa.ToString()) <> sucOrigen.IdEmpresa Then
                     InicializaAsociados()
                     ShowMessage("LA SUCURSAL SELECCIONADA PARTENECE A OTRA EMPRESA")
                  End If
                  '-- Carga los Depositos.- -------------------------------
                  _publicos.CargaComboDepositos(cmbDepositoAsociado, Integer.Parse(cmbSucursalAsociada.SelectedValue.ToString()), False, False, Entidades.Publicos.SiNoTodos.TODOS)
                  '-- Posiciona el Deposito.- -----------------------------
                  cmbDepositoAsociado.SelectedIndex = 0
                  '-- Activa el Deposito.-
                  cmbDepositoAsociado.Enabled = True
               End If
            End If
         End If
      End Sub)
   End Sub
   Private Sub cmbDepositoOrigen_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDepositoOrigen.SelectedValueChanged
      TryCatched(
      Sub()
         Dim dr = cmbDepositoOrigen.ItemSeleccionado(Of DataRow)()
         If dr IsNot Nothing Then
            _publicos.CargaComboUbicaciones(cmbUbicacionOrigen, dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdSucursal"))
            cmbUbicacionOrigen.SelectedIndex = 0
         End If
      End Sub)
   End Sub
   Private Sub cmbDepositoAsociado_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDepositoAsociado.SelectedValueChanged
      TryCatched(
      Sub()
         Dim dr = cmbDepositoAsociado.ItemSeleccionado(Of DataRow)()
         If dr IsNot Nothing Then
            _publicos.CargaComboUbicaciones(cmbUbicacionAsociada, dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdSucursal"))
            cmbUbicacionAsociada.SelectedIndex = 0
            cmbUbicacionAsociada.Enabled = True
         End If
      End Sub)
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargaGrillaVinculacion()
      TryCatched(
      Sub()
         Dim regla As New Reglas.Sucursales()
         ugVinculacionSucDepUbi.DataSource = regla.GetVinculaciones(sucOrigen.IdSucursal)
         VerificaDesvinculacion()
      End Sub)
   End Sub
   Private Sub VerificaDesvinculacion()
      TryCatched(Sub() btnDesvincular.Enabled = (DirectCast(ugVinculacionSucDepUbi.DataSource, DataTable).Count > 0))
   End Sub

   Private Sub InicializaAsociados()
      cmbDepositoAsociado.SelectedIndex = -1
      cmbDepositoAsociado.Enabled = False
      cmbUbicacionAsociada.SelectedIndex = -1
      cmbUbicacionAsociada.Enabled = False
   End Sub
   Private Function ValidarVinculacion(vincular As Boolean) As String
      Dim resp As String = String.Empty

      TryCatched(
      Sub()
         If vincular Then
            If cmbSucursalAsociada.SelectedIndex = -1 Then
               cmbSucursalAsociada.Focus()
               resp = "ATENCION: Sucursal Asociada. Debe seleccionar una."
            End If
            If cmbDepositoAsociado.SelectedIndex = -1 Then
               cmbDepositoAsociado.Focus()
               resp = "ATENCION: Depósito Asociado. Debe seleccionar uno."
            End If
            If cmbUbicacionAsociada.SelectedIndex = -1 Then
               cmbUbicacionAsociada.Focus()
               resp = "ATENCION: Ubicación Asociada. Debe seleccionar una."
            End If
            If vincular Then
               Dim regla As New Reglas.Sucursales()
               '-- Valido la vinculación.- ----------------------------------
               Dim ubiOrigen = New Reglas.SucursalesUbicaciones().GetUno(Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString()),
                                                                      sucOrigen.IdSucursal,
                                                                      Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString()))
               Dim ubiAsocia = New Reglas.SucursalesUbicaciones().GetUno(Integer.Parse(cmbDepositoAsociado.SelectedValue.ToString()),
                                                                      Integer.Parse(cmbSucursalAsociada.SelectedValue.ToString()),
                                                                      Integer.Parse(cmbUbicacionAsociada.SelectedValue.ToString()))
               resp = regla.ComparaSucDepUbicaciones(ubiOrigen, ubiAsocia)
               '-------------------------------------------------------------
            End If
         End If
      End Sub)

      Return resp

   End Function

   Private Sub VincularSucDepUbi(vincular As Boolean)
      TryCatched(
      Sub()
         Dim regla As New Reglas.Sucursales()

         Dim resp = ValidarVinculacion(vincular)
         If String.IsNullOrEmpty(resp) Then
            With regla
               .idSucursalOrigen = sucOrigen.IdSucursal
               .idSucursalAsociada = Integer.Parse(cmbSucursalAsociada.SelectedValue.ToString())
               If vincular Then
                  .idDepositoOrigen = Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString())
                  .idUbicacionOrigen = Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString())
                  .idSucursalAsociada = Integer.Parse(cmbSucursalAsociada.SelectedValue.ToString())
                  .idDepositoAsociada = Integer.Parse(cmbDepositoAsociado.SelectedValue.ToString())
                  .idUbicacionAsociada = Integer.Parse(cmbUbicacionAsociada.SelectedValue.ToString())
               Else
                  .idDepositoOrigen = 0
                  .idUbicacionOrigen = 0
                  .idDepositoAsociada = 0
                  .idUbicacionAsociada = 0
               End If
            End With
            regla.VincularSucDepUbi(vincular)
            If vincular Then
               ShowMessage("Vinculacion Exitosa!!!")
               cmbSucursalAsociada.Enabled = False
            Else
               ShowMessage("Desvinculacion Exitosa!!!")
               cmbSucursalAsociada.Enabled = True
               cmbDepositoAsociado.SelectedIndex = 0
               cmbDepositoOrigen.SelectedIndex = 0
            End If
         Else
            ShowMessage(resp)
         End If
         CargaGrillaVinculacion()
      End Sub)
   End Sub

   Private Sub btnVincular_Click(sender As Object, e As EventArgs) Handles btnVincular.Click
      TryCatched(Sub() VincularSucDepUbi(True))
   End Sub

   Private Sub btnDesvincular_Click(sender As Object, e As EventArgs) Handles btnDesvincular.Click
      TryCatched(Sub() VincularSucDepUbi(False))
   End Sub
#End Region

End Class