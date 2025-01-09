
Option Explicit On
Option Strict On

Public Class ucCuentas


   'Protected _entidad As Entidades.Entidad
   Private _publicos As ContabilidadPublicos

   Public Sub New()

      InitializeComponent()

      Me._publicos = New ContabilidadPublicos()

   End Sub

#Region "Propiedades"
   Private _cuenta As Entidades.ContabilidadCuenta
   Public Property Cuenta() As Entidades.ContabilidadCuenta
      Get
         Return _cuenta
      End Get
      Set(ByVal value As Entidades.ContabilidadCuenta)
         _cuenta = value
         MostrarEntidad()
      End Set
   End Property
#End Region

   Public Event SelectedCuentaChanged As EventHandler

#Region "Buscadores"

   Private Sub bsccodCuenta_BuscadorClick() Handles bscCodCuenta.BuscadorClick
      Try
         Dim oAsientos As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()
         Me._publicos.PreparaGrillaCuentas(Me.bscCodCuenta)
         Me.bscCodCuenta.Datos = oAsientos.GetCuentasImputablesXCodigo(Long.Parse("0" + Me.bscCodCuenta.Text.Trim()))

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodCuenta_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodCuenta.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            MostrarEntidad(CLng(e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value))
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscDescripcion_BuscadorClick() Handles bscDescripcion.BuscadorClick
      Try
         Dim oAsientos As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()
         Me._publicos.PreparaGrillaCuentas(Me.bscDescripcion)
         Me.bscDescripcion.Datos = oAsientos.GetCuentasImputablesXNombre(Me.bscDescripcion.Text.Trim())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscDescripcion_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscDescripcion.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            MostrarEntidad(CLng(e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value))
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Public Sub MostrarEntidad(idCuenta As Long)
      Cuenta = New Reglas.ContabilidadCuentas().GetUna(idCuenta)
   End Sub

   Public Sub MostrarEntidad()
      Try
         mostrando = True
         If Cuenta Is Nothing Then
            Me.bscCodCuenta.Text = String.Empty
            Me.bscDescripcion.Text = String.Empty
         Else
            Me.bscCodCuenta.Text = Cuenta.IdCuenta.ToString()
            Me.bscDescripcion.Text = Cuenta.NombreCuenta
         End If
         RaiseEvent SelectedCuentaChanged(Me, Nothing)
      Finally
         mostrando = False
      End Try
   End Sub
#End Region

   Dim mostrando As Boolean = False

   Private Sub bscCodCuenta_TextChange(sender As Object, e As EventArgs) Handles bscCodCuenta.TextChange, bscDescripcion.TextChange
      If Not mostrando Then _cuenta = Nothing
   End Sub

End Class
