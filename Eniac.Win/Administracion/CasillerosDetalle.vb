Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class CasillerosDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Casillero)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()

         _publicos.CargaComboSector(cmbSector)

         'Me._liSources.Add("IdSector", DirectCast(Me._entidad, Entidades.Casillero).Sector)

         Me.BindearControles(Me._entidad)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then

            Me.CargarProximoNumero()
            DirectCast(Me._entidad, Entidades.Casillero).Usuario = actual.Nombre

         Else
            chkCliente.Checked = DirectCast(Me._entidad, Entidades.Casillero).Cliente IsNot Nothing
            If chkCliente.Checked Then
               bscCodigoCliente.Text = DirectCast(Me._entidad, Entidades.Casillero).CodigoCliente.Value.ToString()
               bscNombreCliente.Text = DirectCast(Me._entidad, Entidades.Casillero).NombreCliente

               bscCodigoCliente.Tag = DirectCast(Me._entidad, Entidades.Casillero).IdCliente
               bscNombreCliente.Tag = DirectCast(Me._entidad, Entidades.Casillero).IdCliente
            Else
               bscNombreCliente.Text = ""
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Casilleros
   End Function

   Protected Overrides Function ValidarDetalle() As String
      If Me.chkCliente.Checked AndAlso bscCodigoCliente.Tag Is Nothing Then
         Return "Indicó que el Casillero fue asignado a un cliente, pero no ha seleccionado ninguno."
      End If

      Return MyBase.ValidarDetalle()
   End Function

   Protected Overrides Sub Aceptar()
      If chkCliente.Checked And bscCodigoCliente.Tag IsNot Nothing Then
         If DirectCast(Me._entidad, Entidades.Casillero).Cliente Is Nothing Then
            DirectCast(Me._entidad, Entidades.Casillero).Cliente = New Entidades.Cliente()
         End If
         DirectCast(Me._entidad, Entidades.Casillero).Cliente.IdCliente = Long.Parse(bscCodigoCliente.Tag.ToString())
      Else
         DirectCast(Me._entidad, Entidades.Casillero).Cliente = Nothing
      End If
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   'Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
   '   If Not Me.HayError Then Me.Close()
   '   Me.cmbSector.Focus()
   'End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Dim entidad As Reglas.Clientes = New Reglas.Clientes
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         Dim codigoCliente As Long = -1

         If Me.bscCodigoCliente.Text = "0" Or Me.bscCodigoCliente.Text = "" Then
            Me.bscCodigoCliente.Datos = entidad.GetFiltradoPorCodigo(codigoCliente, False, False)
         Else
            Long.TryParse(Me.bscCodigoCliente.Text, codigoCliente)
            Me.bscCodigoCliente.Datos = entidad.GetFiltradoPorCodigo(codigoCliente, False, False)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarCliente(e.FilaDevuelta)
            'Me.txtTelefono.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      Try
         Dim regla As Reglas.Clientes = New Reglas.Clientes()
         Me._publicos.PreparaGrillaClientes(Me.bscNombreCliente)
         Me.bscNombreCliente.Datos = regla.GetFiltradoPorNombre(bscNombreCliente.Text)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub bscNombreCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarCliente(e.FilaDevuelta)
            'Me.txtTelefono.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chkCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chkCliente.CheckedChanged
      bscCodigoCliente.Permitido = chkCliente.Checked
      bscNombreCliente.Permitido = chkCliente.Checked

      If chkCliente.Checked Then
         If DirectCast(Me._entidad, Entidades.Casillero).CodigoCliente.HasValue Then
            bscCodigoCliente.Text = DirectCast(Me._entidad, Entidades.Casillero).CodigoCliente.Value.ToString()
         Else
            bscCodigoCliente.Text = "0"
         End If
         bscNombreCliente.Text = DirectCast(Me._entidad, Entidades.Casillero).NombreCliente
      Else
         bscCodigoCliente.Text = ""
      End If
   End Sub

#End Region

#Region "Metodos"

   'Private Sub CargarProximoNumero()
   '    Dim oCasillero As Reglas.Casilleros = New Reglas.Casilleros()
   '    Me.txtCodigoCasillero.Text = (oCasillero.GetCodigoMaximo() + 1).ToString()
   'End Sub

   Private Sub CargarCliente(dr As DataGridViewRow)
      Me.bscCodigoCliente.Text = dr.Cells(Entidades.Cliente.Columnas.CodigoCliente.ToString).Value.ToString()
      Me.bscNombreCliente.Text = dr.Cells(Entidades.Cliente.Columnas.NombreCliente.ToString).Value.ToString()

      Me.bscCodigoCliente.Tag = dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString).Value.ToString()
      Me.bscNombreCliente.Tag = dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString).Value.ToString()

      Me.btnAceptar.Focus()
   End Sub


#End Region

   Private Sub CargarProximoNumero()
      Dim oTipoNave As Reglas.Casilleros = New Reglas.Casilleros()
      Me.txtCodigoCasillero.Text = (oTipoNave.GetCodigoMaximo() + 1).ToString()
   End Sub


End Class