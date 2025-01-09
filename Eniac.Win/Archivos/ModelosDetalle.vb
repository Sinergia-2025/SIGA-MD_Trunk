#Region "Option/Imports"
Option Strict On
Option Explicit On
#End Region
Public Class ModelosDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.Modelo)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Dim dtMarcas As DataTable
         Dim oMarca As Reglas.Marcas = New Reglas.Marcas()
         dtMarcas = oMarca.GetAll()

         Me.BindearControles(Me._entidad)

         If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
            Me.bscCodigoMarca.PresionarBoton()
         ElseIf StateForm = Win.StateForm.Insertar Then
            txtIdModelo.Text = (New Reglas.Modelos().GetCodigoMaximo() + 1).ToString()
            txtOrden.Text = (New Reglas.Modelos().GetOrdenMaximo() + 1).ToString()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Modelos
   End Function
   Protected Overrides Function ValidarDetalle() As String

      If Integer.Parse(Me.txtIdModelo.Text) <= 0 Then
         Me.txtIdModelo.Focus()
         Return "Debe ingresar un Código de Modelo positivo"
      End If

      If Not Me.bscCodigoMarca.Selecciono And Not Me.bscMarca.Selecciono Then
         Me.bscCodigoMarca.Focus()
         Return "No selecciono la marca"
      End If

      Return MyBase.ValidarDetalle()

   End Function


#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
      '   Me.bscCodigoMarca.Text = "0"
      '   Me.bscMarca.Text = String.Empty
      'End If
      If Not Me.HayError Then Me.Close()
      Me.txtIdModelo.Focus()
   End Sub

   Private Sub bscCodigoMarca_BuscadorClick() Handles bscCodigoMarca.BuscadorClick
      Try
         Dim oMarcas As Reglas.Marcas = New Reglas.Marcas
         Me._publicos.PreparaGrillaMarcas(Me.bscCodigoMarca)
         Me.bscCodigoMarca.Datos = oMarcas.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoMarca.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoMarca_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoMarca.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarMarca(e.FilaDevuelta)
            Me.txtOrden.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscMarca_BuscadorClick() Handles bscMarca.BuscadorClick
      Try
         Dim oMarcas As Reglas.Marcas = New Reglas.Marcas
         Me._publicos.PreparaGrillaMarcas(Me.bscMarca)
         Me.bscMarca.Datos = oMarcas.GetPorNombre(Me.bscMarca.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscMarca_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscMarca.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarMarca(e.FilaDevuelta)
            Me.txtOrden.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub



#End Region

#Region "Metodos"

   Private Sub CargarMarca(ByVal dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.Modelo).IdMarca = Int32.Parse(dr.Cells("IdMarca").Value.ToString())
      Me.bscCodigoMarca.Text = dr.Cells("IdMarca").Value.ToString()
      Me.bscMarca.Text = dr.Cells("NombreMarca").Value.ToString()
   End Sub

#End Region

End Class