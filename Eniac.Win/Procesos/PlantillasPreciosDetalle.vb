Option Strict Off
Public Class PlantillasPreciosDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Plantilla)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.CierraAutomaticamente = True

      Me.BindearControles(Me._entidad, Me._liSources)


      If Me.StateForm = Eniac.Win.StateForm.Insertar Then

         Me.CargarProximoNumero()

         Dim Campos As DataTable
         Campos = New Reglas.Plantillas().GetCampos()
         Me.ugDetalle.DataSource = Campos
         Me.chbSistema.Checked = False

      Else

         Dim CodigoProveedor As Long = New Reglas.Proveedores().GetUno(DirectCast(Me._entidad, Entidades.Plantilla).Proveedor.IdProveedor).CodigoProveedor
         Me.bscCodigoProveedor.Text = CodigoProveedor
         If CodigoProveedor <> 0 Then
            Me.bscCodigoProveedor.PresionarBoton()
         End If

         Me.ugDetalle.DataSource = DirectCast(Me._entidad, Entidades.Plantilla).Campos

         'Dejo Mirar pero no editar.
         If Me.chbSistema.Checked Then
            Me.btnAceptar.Visible = False
         End If

      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Plantillas()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      'If Me.bscCodigoProveedor.Text = "" Then
      '   Return "ATENCION: No Selecciono el Proveedor."
      '   Me.bscCodigoProveedor.Focus()
      'End If

      If Integer.Parse(Me.txtFilaInicial.Text) <= 0 Then
         Return "ATENCION: Fila Inicial es Inválida."
         Me.txtFilaInicial.Focus()
      End If

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()

      If bscCodigoProveedor.Text <> "" Then
         DirectCast(Me._entidad, Entidades.Plantilla).Proveedor = New Reglas.Proveedores().GetUnoPorCodigo(Long.Parse(Me.bscCodigoProveedor.Text.ToString()))
      Else
         DirectCast(Me._entidad, Entidades.Plantilla).Proveedor = Nothing
      End If

      DirectCast(Me._entidad, Entidades.Plantilla).Campos = Me.ugDetalle.DataSource


      MyBase.Aceptar()


   End Sub


#End Region

#Region "Eventos"

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores2(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim pla As Reglas.Plantillas = New Reglas.Plantillas()
      Me.txtIdPlanilla.Text = pla.GetProximoId().ToString()
   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)

      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()

   End Sub

#End Region


End Class