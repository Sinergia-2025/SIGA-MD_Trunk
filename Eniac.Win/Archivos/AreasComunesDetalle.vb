Public Class AreasComunesDetalle

   Private _publicos As Publicos
   Private _onLoad As Boolean = False

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.AreaComun)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Propiedades"
   Public ReadOnly Property AreaComun() As Entidades.AreaComun
      Get
         If Me._entidad Is Nothing Then Return Nothing
         Return DirectCast(Me._entidad, Entidades.AreaComun)
      End Get
   End Property

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      Try
         _onLoad = True
         MyBase.OnLoad(e)

         Me._publicos = New Publicos()

         Me._publicos.CargaComboNaves(Me.cmbNaves, MiraPC:=False)

         Me.BindearControles(Me._entidad)

         chbEsNave.Checked = DirectCast(Me._entidad, Entidades.AreaComun).Nave IsNot Nothing
         cmbNaves.Enabled = chbEsNave.Checked

         If AreaComun IsNot Nothing AndAlso AreaComun.Cliente IsNot Nothing Then
            chbEsCliente.Checked = True
            Me.bscCodigoCliente.Text = AreaComun.IdCliente.Value.ToString()
            Me.bscNombreCliente.Text = AreaComun.NombreCliente
            Me.bscCodigoCliente.Tag = AreaComun.IdCliente.Value.ToString()
            Me.bscNombreCliente.Tag = AreaComun.IdCliente.Value.ToString()
         End If

         Me.bscCodigoCliente.Enabled = chbEsCliente.Checked
         Me.bscNombreCliente.Enabled = chbEsCliente.Checked

         Me.txtCoeficiente.Text = AreaComun.Coeficiente.ToString("N7")
      Finally
         _onLoad = False
      End Try
   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.AreasComunes
   End Function
   Protected Overrides Sub Aceptar()


      If chbEsNave.Checked Then
         Dim reglaNave = New Reglas.Naves()
         AreaComun.Nave = reglaNave.GetUno(cmbNaves.ValorSeleccionado(Of Short))
      Else
         AreaComun.Nave = Nothing
      End If

      If chbEsCliente.Checked Then
         Dim reglaCliente = New Reglas.Clientes()
         AreaComun.Cliente = reglaCliente.GetUno(CInt(bscCodigoCliente.Tag))
      Else
         AreaComun.Cliente = Nothing
      End If

      MyBase.Aceptar()
   End Sub

   Protected Overrides Function ValidarDetalle() As String

      If chbEsNave.Checked And cmbNaves.SelectedIndex < 0 Then
         Return "Se ha seleccionado que el área imputa a una nave, pero no se ha seleccionado ninguna."
      End If

      If chbEsCliente.Checked And bscCodigoCliente.Tag Is Nothing Then
         Return "Se ha seleccionado que el área imputa a un cliente, pero no se ha seleccionado ninguno."
      End If

      If chbEsCliente.Checked And chbEsNave.Checked Then
         Return "Un área no puede imputar a una nave y a un cliente al mismo tiempo. Debe desmarcar alguno de los dos para poder continuar."
      End If

      Return MyBase.ValidarDetalle()
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As System.Object, e As EventArgs) Handles btnAceptar.Click
      Try
         If Not Me.HayError Then Me.Close()
         Me.txtIdAreaComun.Focus()
      Catch ex As Exception

      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Try
         Dim entidad As Reglas.Clientes = New Reglas.Clientes()
         Me._publicos.PreparaGrillaClientes(Me.bscCodigoCliente)
         'Me.bscCodigoCliente.Datos = entidad.GetFiltradoPorCodigo(Me.bscCodigoCliente.Text)
         Dim codigoCliente As Long = -1
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = entidad.GetFiltradoPorCodigo(codigoCliente, False, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As System.Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      Try
         Dim entidad As Reglas.Clientes = New Reglas.Clientes()
         Me._publicos.PreparaGrillaClientes(Me.bscNombreCliente)
         Me.bscNombreCliente.Datos = entidad.GetFiltradoPorNombre(Me.bscNombreCliente.Text, True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaPaciente))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreCliente_BuscadorSeleccion(sender As System.Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscNombreCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub chbEsNave_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsNave.CheckedChanged
      cmbNaves.Enabled = chbEsNave.Checked
      If Not _onLoad Then
         If chbEsNave.Checked And cmbNaves.Items.Count > 0 Then
            cmbNaves.SelectedIndex = 0
         Else
            cmbNaves.SelectedIndex = -1
         End If
      End If
   End Sub
   Private Sub chbEsCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbEsCliente.CheckedChanged
      bscCodigoCliente.Enabled = chbEsCliente.Checked
      bscNombreCliente.Enabled = chbEsCliente.Checked
      If Not _onLoad Then
         If Not chbEsCliente.Checked Then
            bscCodigoCliente.Text = String.Empty
            bscCodigoCliente.Tag = Nothing
            bscNombreCliente.Text = String.Empty
            bscNombreCliente.Tag = Nothing
         End If
      End If
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      bscCodigoCliente.Text = dr.Cells(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Value.ToString()
      bscNombreCliente.Text = dr.Cells(Entidades.Cliente.Columnas.NombreCliente.ToString()).Value.ToString()
      bscCodigoCliente.Tag = dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()
      bscNombreCliente.Tag = dr.Cells(Entidades.Cliente.Columnas.IdCliente.ToString()).Value.ToString()
      btnAceptar.Focus()
   End Sub

#End Region

End Class