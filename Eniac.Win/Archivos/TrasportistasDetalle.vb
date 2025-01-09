Imports Eniac.Reglas
Imports actual = Eniac.Entidades.Usuario.Actual
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.MapProviders
Imports Infragistics.Win.UltraWinGrid


Public Class TransportistasDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.Transportista)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Dim oLoca As Localidades = New Localidades()
      Dim oTipos As Reglas.TiposDocumento = New Reglas.TiposDocumento()

      Me._publicos = New Publicos()

      Me._publicos.CargaComboCategoriasFiscales(Me.cmbCategoriaFiscal)

      Me._liSources.Add("CategoriaFiscal", DirectCast(Me._entidad, Entidades.Transportista).CategoriaFiscal)

      Me.BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.chbActivo.Checked = True
         Me.CargarProximoNumero()
         'Me.bscCodigoLocalidad.Text = actual.Sucursal.Localidad.IdLocalidad.ToString()
         Me.bscCodigoLocalidad.Text = actual.Sucursal.LocalidadComercial.IdLocalidad.ToString()
         Me.bscCodigoLocalidad.PresionarBoton()
      Else
         Me.bscCodigoLocalidad.PresionarBoton()
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Transportistas
   End Function

   Protected Overrides Function ValidarDetalle() As String

      Dim vacio As String = ""

      If Me.txtCuit.Text <> "" Then
         If Me.txtCuit.Text.Length <> 11 Then
            Return "El número de CUIT ingresado es inválido, deben ser 11 caracteres y posee " & Me.txtCuit.Text.Length.ToString() & "."
         End If
         If Not Publicos.EsCuitValido(Me.txtCuit.Text) Then
            Return "El número de CUIT ingresado es inválido."
         End If
      End If

      Return vacio

   End Function

   Protected Overrides Sub LimpiarControles()
      MyBase.LimpiarControles()
      Me.cmbCategoriaFiscal.SelectedIndex = -1
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
      '   Me.CargarProximoNumero()
      'End If
      Me.txtCodigo.Focus()
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidad)
         Me.bscCodigoLocalidad.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidad.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.cmbCategoriaFiscal.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscNombreLocalidad)
         Me.bscNombreLocalidad.Datos = oLocalidades.GetPorNombre(Me.bscNombreLocalidad.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.cmbCategoriaFiscal.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub lnkLocalidad_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLocalidad.LinkClicked
      Try
         Dim PantLocalidad As LocalidadesDetalle = New LocalidadesDetalle(New Entidades.Localidad())
         PantLocalidad.StateForm = Win.StateForm.Insertar
         PantLocalidad.CierraAutomaticamente = True
         If PantLocalidad.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.bscCodigoLocalidad.Text = PantLocalidad.txtIdLocalidad.Text
            Me.bscCodigoLocalidad.PresionarBoton()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Métodos"

   Private Sub CargarProximoNumero()
      Dim oRegTransportista As Reglas.Transportistas = New Reglas.Transportistas()
      Dim ProximoProveedor As Long
      ProximoProveedor = oRegTransportista.GetCodigoMaximo + 1
      Me.txtCodigo.Text = ProximoProveedor.ToString()
   End Sub

   Private Sub CargarLocalidad(ByVal dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.Transportista).IdLocalidadTransportista = Integer.Parse(dr.Cells("IdLocalidad").Value.ToString())
      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
   End Sub



#End Region

   Private Sub chbActivo_CheckedChanged(sender As Object, e As EventArgs) Handles chbActivo.CheckedChanged
      Try
         If Me.StateForm = Win.StateForm.Actualizar Then
            If chbActivo.Checked = False Then
               Dim oTransportista As Reglas.Transportistas = New Reglas.Transportistas()

               Dim existeCliente As Boolean = oTransportista.GetExisteTransportitasEnCliente(Integer.Parse(txtCodigo.Text))
               If existeCliente Then
                  Me.chbActivo.Checked = True
                  MessageBox.Show("El Transportista esta asignado aun Cliente, NO es Posible Inactivarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
               Dim existeEnRuta As Boolean = oTransportista.GetExisteTransportitasEnRutas(Integer.Parse(txtCodigo.Text))
               If existeEnRuta Then
                  Me.chbActivo.Checked = True
                  MessageBox.Show("El Transportista esta asignado a una Ruta, NO es Posible Inactivarlo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
            End If
         End If
       
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class
