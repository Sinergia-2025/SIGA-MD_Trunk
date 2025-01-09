Option Strict Off
Imports Infragistics.Win.UltraWinGrid
Public Class ChequerasDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Chequera)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      _publicos = New Publicos
      Me.BindearControles(Me._entidad)

      '# UPDATE
      If StateForm = StateForm.Actualizar Then
         Me.bscCuentaBancariaDestino.Enabled = False
         Me.txtNumeroActual.ReadOnly = True
         Me.txtNumeroDesde.ReadOnly = True

         Me.txtNombreChequera.Enabled = True

         Me.bscCodigoCuentaBancariaDestino.Text = DirectCast(_entidad, Entidades.Chequera).IdCuentaBancaria
         Me.bscCodigoCuentaBancariaDestino.PresionarBoton()
      Else
         Me.chbActivo.Checked = True
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Chequeras()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      '# Validaciones previas
      If Not (Me.bscCodigoCuentaBancariaDestino.Selecciono AndAlso Me.bscCuentaBancariaDestino.Selecciono) Then
         Return "ATENCIÓN: No seleccionó una Cuenta Bancaria."
      End If

      If Me.txtNumeroDesde.Text = "0" Then
         Return "ATENCIÓN: No seleccionó un Número Desde."
      End If

      If Me.txtNumeroHasta.Text = "0" Then
         Return "ATENCIÓN: No seleccionó un Número Hasta."
      End If

      If String.IsNullOrEmpty(Me.txtNombreChequera.Text) Then
         Return "ATENCIÓN: No ingresó un Nombre para la chequera."
      End If

      '# Valido el Desde y Hasta
      If CInt(Me.txtNumeroDesde.Text) > CInt(Me.txtNumeroHasta.Text) Then
         Return "ATENCIÓN: La numeración Desde no puede ser mayor a la numeración Hasta."
      End If

      '# Valido que el Número Actual se encuentre en el rango Desde Hasta
      If Not String.IsNullOrEmpty(Me.txtNumeroActual.Text) Then
         If CInt(Me.txtNumeroActual.Text <> 0) Then

            If (CInt(Me.txtNumeroActual.Text) > CInt(Me.txtNumeroHasta.Text)) OrElse
               (CInt(Me.txtNumeroActual.Text) < CInt(Me.txtNumeroDesde.Text)) Then
               Return "ATENCIÓN: La numeración Actual no puede estar fuera del rango Desde/Hasta."
            End If

         End If
      End If

      '# Valido que no se pueda actualizar el rango Hasta por debajo de la numeración Actual
      If Not String.IsNullOrEmpty(Me.txtNumeroActual.Text) AndAlso Not String.IsNullOrEmpty(Me.txtNumeroHasta.Text) Then
         If CInt(Me.txtNumeroActual.Text <> 0) Then
            If CInt(Me.txtNumeroHasta.Text) < CInt(Me.txtNumeroActual.Text) Then
               Return "ATENCIÓN: La numeración Hasta no puede ser menor a la numeración Actual."
            End If
         End If
      End If

      Return String.Empty
   End Function

   Protected Overrides Sub Aceptar()
      DirectCast(_entidad, Entidades.Chequera).IdCuentaBancaria = CInt(Me.bscCodigoCuentaBancariaDestino.Text)
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Métodos"
   Private Function SugerenciaNombre() As String
      Return String.Format("Desde {0} A {1}", Me.txtNumeroDesde.Text, Me.txtNumeroHasta.Text)
   End Function

   Private Sub CargarDatosCuentaBancariaDestino(ByVal dr As DataGridViewRow)
      Me.bscCodigoCuentaBancariaDestino.Text = dr.Cells("IdCuentaBancaria").Value.ToString()
      Me.bscCuentaBancariaDestino.Text = dr.Cells("NombreCuenta").Value.ToString()

      Me.bscCodigoCuentaBancariaDestino.Selecciono = True
      Me.bscCuentaBancariaDestino.Selecciono = True
   End Sub
#End Region

#Region "Eventos"
   Private Sub bscCuentaBancariaDestino_BuscadorClick() Handles bscCuentaBancariaDestino.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCuentaBancariaDestino)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.bscCuentaBancariaDestino.Datos = oCBancarias.GetFiltradoPorNombre(Me.bscCuentaBancariaDestino.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCuentaBancariaDestino_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscCuentaBancariaDestino.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCuentaBancariaDestino(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoCuentaBancariaDestino_BuscadorClick() Handles bscCodigoCuentaBancariaDestino.BuscadorClick

      Try
         Me._publicos.PreparaGrillaCuentasBancarias(Me.bscCodigoCuentaBancariaDestino)
         Dim oCBancarias As Reglas.CuentasBancarias = New Reglas.CuentasBancarias()
         Me.bscCodigoCuentaBancariaDestino.Datos = oCBancarias.GetFiltradoPorCodigo(Integer.Parse(Me.bscCodigoCuentaBancariaDestino.Text))
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoCuentaBancariaDestino_BuscadorSeleccion(ByVal sender As System.Object, ByVal e As Eniac.Controles.BuscadorEventArgs) Handles bscCodigoCuentaBancariaDestino.BuscadorSeleccion

      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscCodigoCuentaBancariaDestino.Text = e.FilaDevuelta.Cells("IdCuentaBancaria").Value.ToString()
            Me.bscCuentaBancariaDestino.Text = e.FilaDevuelta.Cells("NombreCuenta").Value.ToString()
            Me.bscCuentaBancariaDestino.FilaDevuelta = e.FilaDevuelta

            Me.bscCodigoCuentaBancariaDestino.Selecciono = True
            Me.bscCuentaBancariaDestino.Selecciono = True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub txtNumeroHasta_Leave(sender As Object, e As EventArgs) Handles txtNumeroHasta.Leave
      Try
         If String.IsNullOrEmpty(Me.txtNombreChequera.Text) Then Me.txtNombreChequera.Text = Me.SugerenciaNombre()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

End Class