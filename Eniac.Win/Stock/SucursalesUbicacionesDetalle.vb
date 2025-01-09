Imports Eniac.Reglas

Public Class SucursalesUbicacionesDetalle

#Region "Campos"
   Private _Publicos As Publicos
   Public _Cargando As Boolean = False
   Private _nombreaAnterior As String
#End Region

   Private ReadOnly Property Ubicacion As Entidades.SucursalUbicacion
      Get
         Return DirectCast(_entidad, Entidades.SucursalUbicacion)
      End Get
   End Property

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.SucursalUbicacion)
      Me.New()
      _entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _Publicos = New Publicos()
         _Publicos.CargaComboSucursales(cmbSucursales)
         _Publicos.CargaComboEstadoUbicaciones(cmbEstadosUbicaciones)

         BindearControles(_entidad, _liSources)

         If StateForm = Eniac.Win.StateForm.Actualizar Then
            Dim idDeposito = Ubicacion.IdDeposito
            _Publicos.CargaComboDepositos(cmbDepositos, Integer.Parse(cmbSucursales.SelectedValue.ToString()), False, False, Entidades.Publicos.SiNoTodos.TODOS)
            cmbDepositos.SelectedValue = idDeposito
            _nombreaAnterior = DirectCast(_entidad, Eniac.Entidades.SucursalUbicacion).NombreUbicacion.Trim()
         End If

         If StateForm = Eniac.Win.StateForm.Insertar Then
            chbActivo.Checked = True
         End If

         _Cargando = True
      End Sub)
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.SucursalesUbicaciones()
   End Function

#End Region

#Region "Eventos"
   Private Sub cmbSucursales_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursales.SelectedIndexChanged
      TryCatched(
      Sub()
         If _Cargando Then
            _Cargando = False
            _Publicos.CargaComboDepositos(cmbDepositos, Integer.Parse(cmbSucursales.SelectedValue.ToString()), False, False, Entidades.Publicos.SiNoTodos.TODOS)
            _Cargando = True
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"
   Protected Overrides Sub Aceptar()
      Dim resp = ValidarDetalle()
      _Cargando = False

      If String.IsNullOrEmpty(resp) Then

         If StateForm = Eniac.Win.StateForm.Insertar Then
            '-- Recupera IdUbicacion.- ------------------------------------------------------------------------------
            Ubicacion.IdUbicacion = New Reglas.SucursalesUbicaciones().GetCodigoMaximo(cmbDepositos.ValorSeleccionado(Of Integer),
                                                                                       cmbSucursales.ValorSeleccionado(Of Integer)) + 1
            '-- Recupera Sucursal Asociada.- ------------------------------------------------------------------------
            Ubicacion.SucursalAsociada = New Reglas.Sucursales().GetUna(cmbSucursales.ValorSeleccionado(Of Integer), False).IdSucursalAsociada
         End If
         MyBase.Aceptar()
      Else
         ShowMessage(resp)
      End If
      _Cargando = True
   End Sub

   Protected Overrides Function ValidarDetalle() As String

      If cmbSucursales.SelectedIndex = -1 Then
         cmbSucursales.Focus()
         Return "ATENCION: Sucursal. Debe ingresar una."
      End If

      If cmbDepositos.SelectedIndex = -1 Then
         cmbDepositos.Focus()
         Return "ATENCION: Depósito. Debe elegir uno."
      End If

      If String.IsNullOrEmpty(txtNombreUbicacion.Text) Then
         txtNombreUbicacion.Focus()
         Return "ATENCION: Nombre de Ubicación. Debe ingresar uno."
      End If

      If cmbEstadosUbicaciones.SelectedIndex = -1 Then
         cmbEstadosUbicaciones.Focus()
         Return "ATENCION: Estados Ubicaciones. Debe elegir uno."
      End If
      'PE 44274 
      'Validacion que no se repita por una sucursarl y un deposito por el mismo nombre 
      Dim sucursales As SucursalesUbicaciones
      sucursales = New SucursalesUbicaciones()
      Dim dt As DataTable
      dt = sucursales.GetAll()
      If StateForm = StateForm.Insertar Then
         Return ValidaNoRepeticionNombre(dt)
      Else
         If _nombreaAnterior <> txtNombreUbicacion.Text Then
            Return ValidaNoRepeticionNombre(dt)
         End If
      End If
      Return MyBase.ValidarDetalle()
   End Function
   Private Function ValidaNoRepeticionNombre(dt As DataTable) As String
      For Each reg As DataRow In dt.Rows
         If reg(Eniac.Entidades.SucursalUbicacion.Columnas.IdSucursal.ToString()).ToString() = cmbSucursales.SelectedValue.ToString() And
            reg(Eniac.Entidades.SucursalUbicacion.Columnas.IdDeposito.ToString()).ToString() = cmbDepositos.SelectedValue.ToString() And txtNombreUbicacion.Text.Trim().ToUpper() = reg(Eniac.Entidades.SucursalUbicacion.Columnas.NombreUbicacion.ToString()).ToString().ToUpper() Then
            Return "La descripcion ingresada ya ha sido asignada a otra ubicacion dentro de la misma Sucursal Deposito."
         End If
      Next
      Return String.Empty
   End Function
#End Region
End Class