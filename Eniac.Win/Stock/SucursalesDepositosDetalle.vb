Public Class SucursalesDepositosDetalle
#Region "Campos"
   Private _Publicos As Publicos
   Private _titUsuarios As Dictionary(Of String, String)
   Private _usuariosDepositos As List(Of Entidades.SucursalDepositoUsuario)
   Private _Cargando As Boolean
   Private _regla As Reglas.SucursalesDepositos
   Private _estadoAnterior As Boolean
#End Region

   Public ReadOnly Property Deposito As Entidades.SucursalDeposito
      Get
         Return DirectCast(_entidad, Entidades.SucursalDeposito)
      End Get
   End Property

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.SucursalDeposito)
      Me.New()
      _entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _regla = GetReglas(Of Reglas.SucursalesDepositos)()

            _Publicos = New Publicos()
            _Publicos.CargaComboSucursales(cmbSucursales)

            _Publicos.CargaComboDesdeEnum(cmbTipoDeposito, GetType(Entidades.SucursalDeposito.TiposDepositos))

            BindearControles(_entidad, _liSources)

            Dim rUsu = New Reglas.Usuarios()
            _titUsuarios = GetColumnasVisiblesGrilla(ugUsuarios)

            With ugUsuarios
               .DataSource = rUsu.GetAll(activo:=True)
               .AgregarFiltroEnLinea({"Id", "Nombre"})
            End With
            AjustarColumnasGrilla(ugUsuarios, _titUsuarios)
            ugUsuarios.Refresh()

            CargarUsuariosDepositos()

            If StateForm = Eniac.Win.StateForm.Insertar Then
               cmbTipoDeposito.SelectedIndex = 0
               chbActivo.Checked = True
               chbDisponibleVenta.Checked = True
               cmbSucursales.Focus()
            Else
               cmbTipoDeposito.SelectedValue = Deposito.TipoDeposito
               _estadoAnterior = chbActivo.Checked
            End If

            'Solo permitir cambiar el tipo de deposito en el alta. Una vez creado no se puede cambiar porque hay controles que realizar sobre la información que nos llevaría a inconsistencias si lo permitimos.
            cmbTipoDeposito.Enabled = StateForm = Eniac.Win.StateForm.Insertar
            'cmbTipoDeposito.Enabled = Not _regla.ExisteProductoPredeterminado(Deposito.IdSucursal, Deposito.IdDeposito)

            _Cargando = True
         End Sub)
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.SucursalesDepositos()
   End Function
#End Region

#Region "Eventos"
   Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      If ugUsuarios.Selected.Rows.Count = 0 AndAlso ugUsuarios.ActiveRow IsNot Nothing Then ugUsuarios.ActiveRow.Selected = True

      For Each dg In ugUsuarios.Selected.Rows.OfType(Of UltraGridRow)
         Dim dr = dg.FilaSeleccionada(Of DataRow)()
         If dr IsNot Nothing Then
            Dim idUsr = dr.Field(Of String)("Id")
            Dim usr = _usuariosDepositos.FirstOrDefault(Function(drU) drU.IdUsuario = idUsr)
            If usr Is Nothing Then
               usr = New Entidades.SucursalDepositoUsuario()
               With usr
                  .IdUsuario = dr.Field(Of String)("Id")
                  .NombreUsuario = dr.Field(Of String)("Nombre")
                  .IdDeposito = Deposito.IdDeposito
                  .IdSucursal = cmbSucursales.ValorSeleccionado(Of Integer)
               End With
               _usuariosDepositos.Add(usr)
            End If
            With usr
               .Responsable = ChbResponsable.Checked
               .UsuarioDefault = ChbPorDefecto.Checked
               .PermitirEscritura = ChbPermitirEscritura.Checked
            End With
         End If
      Next
      ugUsuariosDepositos.Rows.Refresh(RefreshRow.FireInitializeRow)
   End Sub

   Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
      TryCatched(
      Sub()
         If ugUsuariosDepositos.Selected.Rows.Count = 0 AndAlso ugUsuariosDepositos.ActiveRow IsNot Nothing Then ugUsuariosDepositos.ActiveRow.Selected = True
         For Each ugr In ugUsuariosDepositos.Selected.Rows.OfType(Of UltraGridRow)
            ugUsuariosDepositos.PerformAction(UltraGridAction.DeleteRows)
         Next
         ugUsuariosDepositos.Rows.Refresh(RefreshRow.FireInitializeRow)
      End Sub)
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargarUsuariosDepositos()
      _usuariosDepositos = Deposito.Usuarios
      ugUsuariosDepositos.DataSource = _usuariosDepositos

      FormatearGrillaUsuariosDepositos()
   End Sub
   Private Sub FormatearGrillaUsuariosDepositos()
      With ugUsuariosDepositos.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()

         .Columns("IdUsuario").FormatearColumna("Id", 1, 60, , hidden:=True)
         .Columns("NombreUsuario").FormatearColumna("Usuario", 2, 134)
         .Columns("Responsable").FormatearColumna("Respons", 3, 50)
         .Columns("UsuarioDefault").FormatearColumna("Por Defecto", 4, 50)
         .Columns("PermitirEscritura").FormatearColumna("Permitir Escritura", 5, 50)
         '-- Campos Ocultos.- ----------------
         .Columns("IdSucursal").FormatearColumna("IdSucursal", 5, 50, , hidden:=True)
         .Columns("IdDeposito").FormatearColumna("IdDeposito", 5, 50, , hidden:=True)
      End With
      ugUsuariosDepositos.AgregarFiltroEnLinea({"Nombre"})
   End Sub

   Protected Overrides Function ValidarDetalle() As String
      If String.IsNullOrEmpty(txtCodigoDeposito.Text) Then
         txtCodigoDeposito.Focus()
         Return "ATENCION: Código de depósito. Debe ingresar uno."
      End If

      If cmbSucursales.SelectedIndex = -1 Then
         cmbSucursales.Focus()
         Return "ATENCION: Sucursal de depósito. Debe elegir una."
      End If

      If String.IsNullOrEmpty(txtNombreDeposito.Text) Then
         txtNombreDeposito.Focus()
         Return "ATENCION: Nombre de depósito. Debe ingresar uno."
      End If

      '-- REQ-41797 - Valida Deposito Estado.- ------------------------------
      If StateForm = Eniac.Win.StateForm.Actualizar Then
         If Not chbActivo.Checked AND (chbActivo.Checked <> _estadoAnterior) Then
            Dim mensaje As String = String.Empty
            If Not (New Reglas.SucursalesDepositos().ValidarInactivacionDeposito(Deposito.IdSucursal, Deposito.IdDeposito, mensaje)) Then
               Return mensaje
            End If
         End If
      End If
      '----------------------------------------------------------------------
      Return MyBase.ValidarDetalle()
   End Function

#End Region
End Class