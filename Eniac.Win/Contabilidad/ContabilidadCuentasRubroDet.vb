Imports System.ComponentModel

Public Class ContabilidadCuentasRubroDet

   Private _publicos As Publicos

   Public Enum Procesos
      VENTAS
      COMPRAS
      <Browsable(False)>
      STOCK
   End Enum

   Public ReadOnly Property CuentaRubro As Entidades.ContabilidadCuentaRubro
      Get
         Return DirectCast(_entidad, Entidades.ContabilidadCuentaRubro)
      End Get
   End Property
   Public ReadOnly Property CentrosEmisores As DataTable
      Get
         Return DirectCast(ugCentrosEmisores.DataSource, DataTable)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.ContabilidadCuentaRubro)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Constantes"


#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _publicos.CargaComboDesdeEnum(cmbTipo, GetType(Procesos), , True)

            If Me.StateForm = Win.StateForm.Insertar Then
               cmbTipo.SelectedIndex = -1
            Else
               cmbTipo.SelectedValue = CuentaRubro.Tipo
               UcCuentas1.MostrarEntidad(CuentaRubro.IdCuenta)
               bscCodigoRubro.Text = CuentaRubro.IdRubro.ToString()
               bscCodigoRubro.PresionarBoton()
            End If

            Dim tit = GetColumnasVisiblesGrilla(ugCentrosEmisores)
            ugCentrosEmisores.DataSource = New Reglas.ContabilidadCuentasRubros().GetAll(CuentaRubro.IdPlanCuenta, CuentaRubro.IdRubro, CuentaRubro.Tipo, excluirCentroEmisor:=0)
            AjustarColumnasGrilla(ugCentrosEmisores, tit)
         End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ContabilidadCuentasRubros()
   End Function

   Protected Overrides Sub Aceptar()
      With CuentaRubro
         If cmbTipo.SelectedValue IsNot Nothing Then .Tipo = cmbTipo.SelectedValue.ToString()
         If UcCuentas1.Cuenta IsNot Nothing Then .IdCuenta = UcCuentas1.Cuenta.IdCuenta
         If IsNumeric(bscCodigoRubro.Text) Then .IdRubro = bscCodigoRubro.Text.ValorNumericoPorDefecto(0I)
      End With
      MyBase.Aceptar()
   End Sub

   Protected Overrides Function ValidarDetalle() As String
      If CuentaRubro.IdRubro = 0 Then
         bscCodigoRubro.Focus()
         Return "Debe ingresar un Rubro"
      End If
      If cmbTipo.SelectedValue Is Nothing OrElse String.IsNullOrWhiteSpace(cmbTipo.SelectedValue.ToString()) Then
         cmbTipo.Focus()
         Return "Debe ingresar un tipo"
      End If
      If UcCuentas1.Cuenta Is Nothing OrElse UcCuentas1.Cuenta.IdCuenta = 0 Then
         cmbTipo.Focus()
         Return "Debe ingresar una cuenta"
      End If

      If Me.StateForm = Win.StateForm.Insertar Then
         If DirectCast(GetReglas(), Reglas.ContabilidadCuentasRubros).Existe(CuentaRubro.IdRubro,
                                                                             idCuenta:=Nothing,
                                                                             idPlanCuenta:=Nothing,
                                                                             cmbTipo.SelectedValue.ToString()) Then
            cmbTipo.Focus()
            Return String.Format("Ya se ha configurado una cuenta para el rubro {0} con el tipo {1}",
                                 CuentaRubro.IdRubro, cmbTipo.SelectedValue.ToString())
         End If
      End If
      Return MyBase.ValidarDetalle()
   End Function

   Protected Overrides Function EjecutaInsertar(rg As Reglas.Base, en As Entidades.Entidad) As Entidades.Entidad
      DirectCast(rg, Reglas.ContabilidadCuentasRubros).Insertar(CuentaRubro, CentrosEmisores)
      Return en
   End Function
   Protected Overrides Function EjecutaActualizar(rg As Reglas.Base, en As Entidades.Entidad) As Entidades.Entidad
      DirectCast(rg, Reglas.ContabilidadCuentasRubros).Actualizar(CuentaRubro, CentrosEmisores)
      Return en
   End Function

#End Region

#Region "Eventos"
   Private Sub bscCodigoRubro_BuscadorClick() Handles bscCodigoRubro.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaRubros(bscCodigoRubro)
            bscCodigoRubro.Datos = New Reglas.Rubros().GetPorCodigo(bscCodigoRubro.Text.ValorNumericoPorDefecto(0I))
         End Sub)
   End Sub
   Private Sub bscRubro_BuscadorClick() Handles bscRubro.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaRubros(bscRubro)
            bscRubro.Datos = New Reglas.Rubros().GetPorNombre(bscRubro.Text.Trim())
         End Sub)
   End Sub

   Private Sub bscCodigoRubro_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoRubro.BuscadorSeleccion, bscRubro.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarRubro(e.FilaDevuelta)
            End If
         End Sub)
   End Sub

   Private Sub cmbTipo_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTipo.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub UcCuentas1_SelectedCuentaChanged(sender As Object, e As EventArgs) Handles UcCuentas1.SelectedCuentaChanged
      If UcCuentas1.Cuenta IsNot Nothing Then
         txtCentroEmisor.Focus()
      End If
   End Sub

   Private Sub txtCentroEmisor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCentroEmisor.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub UcCuentas2_SelectedCuentaChanged(sender As Object, e As EventArgs) Handles UcCuentas2.SelectedCuentaChanged
      If UcCuentas1.Cuenta IsNot Nothing Then
         btnInsertar.Focus()
      End If
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(Sub() InsertarCentroEmisor())
   End Sub
   Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
      TryCatched(Sub() LimpiaCentroEmisor())
   End Sub
   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(Sub() EliminarCentroEmisor())
   End Sub
   Private Sub ugCentrosEmisores_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugCentrosEmisores.DoubleClickRow
      TryCatched(Sub() EditarCentroEmisor())
   End Sub

#End Region

#Region "Métodos"
   Private Sub LimpiaCentroEmisor()
      txtCentroEmisor.SetValor(0)
      UcCuentas2.Cuenta = Nothing
   End Sub
   Private Function ValidarCentroEmisor() As Boolean
      Dim centroEmisor = txtCentroEmisor.ValorNumericoPorDefecto(0I)
      If centroEmisor < 1 Then
         ShowMessage("Centro Emisor no válido.")
         txtCentroEmisor.Select()
         Return False
      End If
      If CentrosEmisores.AsEnumerable().Any(Function(dr) dr.Field(Of Integer)("CentroEmisor") = centroEmisor) Then
         ShowMessage("Ya existe una cuenta para el Centro Emisor ingresado.")
         txtCentroEmisor.Select()
         Return False
      End If
      If UcCuentas2.Cuenta Is Nothing Then
         ShowMessage("Debe seleccionar una Cuenta Contable.")
         UcCuentas2.Select()
         Return False
      End If

      Return True
   End Function
   Private Sub InsertarCentroEmisor()
      If ValidarCentroEmisor() Then
         Dim centroEmisor = txtCentroEmisor.ValorNumericoPorDefecto(0I)

         Dim dr = CentrosEmisores.NewRow()
         dr.SetField("CentroEmisor", centroEmisor)
         dr.SetField("IdCuenta", UcCuentas2.Cuenta.IdCuenta)
         dr.SetField("NombreCuenta", UcCuentas2.Cuenta.NombreCuenta)

         CentrosEmisores.Rows.Add(dr)
         LimpiaCentroEmisor()
      End If
   End Sub

   Private Sub EditarCentroEmisor()
      Dim dr = ugCentrosEmisores.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then
         txtCentroEmisor.SetValor(dr.Field(Of Integer)("CentroEmisor"))
         UcCuentas2.bscCodCuenta.Text = dr.Field(Of Long)("IdCuenta").ToString()
         UcCuentas2.bscCodCuenta.PresionarBoton()
         CentrosEmisores.Rows.Remove(dr)
      End If
   End Sub

   Private Sub EliminarCentroEmisor()
      Dim dr = ugCentrosEmisores.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then
         If ShowPregunta("¿Desea eliminar el Centro Emisor seleccionado?") = DialogResult.Yes Then
            CentrosEmisores.Rows.Remove(dr)
         End If
      End If
   End Sub

   Private Sub CargarRubro(dr As DataGridViewRow)
      CuentaRubro.IdRubro = Integer.Parse(dr.Cells("IdRubro").Value.ToString())
      bscCodigoRubro.Text = dr.Cells("IdRubro").Value.ToString()
      bscRubro.Text = dr.Cells("NombreRubro").Value.ToString()

      cmbTipo.Focus()
   End Sub

#End Region

End Class