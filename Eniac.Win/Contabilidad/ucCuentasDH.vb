
Option Explicit On
Option Strict On

Public Class ucCuentasDH


   Protected _entidad As Entidades.Entidad
   Private _publicos As ContabilidadPublicos

   Public Sub New()

      InitializeComponent()

      Me._publicos = New ContabilidadPublicos()

   End Sub

#Region "Propiedades"

   Public Property _Origen As String
   Public Property Origen() As String
      Get
         Return _Origen
      End Get
      Set(ByVal value As String)
         _Origen = value
      End Set
   End Property

   Private _idPlanCuenta As Integer
   Public Property IdPlanCuenta() As Integer
      Get
         Return _idPlanCuenta
      End Get
      Set(ByVal value As Integer)
         _idPlanCuenta = value
      End Set
   End Property

   Public Property _Tipo As String
   Public Property Tipo() As String
      Get
         Return _Tipo
      End Get
      Set(ByVal value As String)
         _Tipo = value
      End Set
   End Property


#End Region


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
            Me.bscDescripcion.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()
            Me.bscCodCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()

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
            Me.bscDescripcion.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()
            Me.bscCodCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bsccodCuentah_BuscadorClick() Handles bscCodCuentaH.BuscadorClick

      Try
         Dim oAsientos As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()
         Me._publicos.PreparaGrillaCuentas(Me.bscCodCuentaH)
         Me.bscCodCuentaH.Datos = oAsientos.GetCuentasImputablesXCodigo(Long.Parse("0" + Me.bscCodCuentaH.Text.Trim()))

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodCuentah_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodCuentaH.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscDescripcionH.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()
            Me.bscCodCuentaH.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscDescripcionh_BuscadorClick() Handles bscDescripcionH.BuscadorClick
      Try
         Dim oAsientos As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()
         Me._publicos.PreparaGrillaCuentas(Me.bscDescripcionH)
         Me.bscDescripcionH.Datos = oAsientos.GetCuentasImputablesXNombre(Me.bscDescripcionH.Text.Trim())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscDescripcionh_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscDescripcionH.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscDescripcionH.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()
            Me.bscCodCuentaH.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Public Function CargarEntidad() As Entidades.ucCuentaDHvb

      Me._entidad = New Entidades.ucCuentaDHvb

      If (Me.bscCodCuenta.Selecciono Or Me.bscDescripcion.Selecciono) And Not String.IsNullOrEmpty(Me.bscCodCuenta.Text) Then
         DirectCast(Me._entidad, Entidades.ucCuentaDHvb).idCuentaDebe = Integer.Parse(Me.bscCodCuenta.Text)
      End If

      If (Me.bscCodCuentaH.Selecciono Or Me.bscDescripcionH.Selecciono) And Not String.IsNullOrEmpty(Me.bscCodCuentaH.Text) Then
         DirectCast(Me._entidad, Entidades.ucCuentaDHvb).idCuentaHaber = Integer.Parse(Me.bscCodCuentaH.Text)
      End If

      DirectCast(Me._entidad, Entidades.ucCuentaDHvb).IdPlanCuenta = Me._idPlanCuenta
      DirectCast(Me._entidad, Entidades.ucCuentaDHvb).Origen = Me._Origen

      DirectCast(Me._entidad, Entidades.ucCuentaDHvb).Tipo = Me._Tipo.ToUpper

      Return DirectCast(Me._entidad, Entidades.ucCuentaDHvb)

   End Function

#End Region

   Private Sub ucCuentasDH_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


      Me.gbTipo.Text = Me._Tipo


   End Sub
End Class
