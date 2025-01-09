#Region "Option/Imports"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Public Class AplicacionesFuncionesDetalle
   Private _publicos As Publicos

   Private ReadOnly Property Funcion As Entidades.AplicacionFuncion
      Get
         Return DirectCast(_entidad, Entidades.AplicacionFuncion)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.AplicacionFuncion)
      Me.New()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         _publicos = New Publicos()

         Me.BindearControles(Me._entidad)

         If StateForm = Win.StateForm.Insertar Then

         Else
            If Not String.IsNullOrWhiteSpace(bscIdAplicacion.Text) Then
               Dim enablePrev = bscIdAplicacion.Enabled
               bscIdAplicacion.Enabled = True
               bscIdAplicacion.PresionarBoton()
               bscIdAplicacion.Enabled = enablePrev
            End If
            If Not String.IsNullOrWhiteSpace(bscIdFuncionPadre.Text) Then
               bscIdFuncionPadre.PresionarBoton()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.AplicacionesFunciones()
   End Function
   Protected Overrides Function ValidarDetalle() As String
      Dim _error As String = ""

      If Not bscIdAplicacion.Selecciono Or Not bscNombreAplicacion.Selecciono Then
         bscIdAplicacion.Focus()
         Return "Debe seleccionar una aplicación"
      End If

      If Not String.IsNullOrWhiteSpace(bscIdFuncionPadre.Text) And (Not bscIdFuncionPadre.Selecciono Or Not bscNombreFuncionPadre.Selecciono) Then
         bscIdFuncionPadre.Focus()
         Return "Debe seleccionar una función padre"
      End If

      Return _error
   End Function

   Protected Overrides Sub Aceptar()
      DirectCast(_entidad, Entidades.AplicacionFuncion).IdFuncionPadre = bscIdFuncionPadre.Text
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Busqueda"
   Private Sub bscIdFuncionPadre_BuscadorClick() Handles bscIdFuncionPadre.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaAplicacionFuncion2(Me.bscIdFuncionPadre)
         Me.bscIdFuncionPadre.Datos = New Reglas.AplicacionesFunciones().GetFiltradoPorCodigo(bscIdAplicacion.Text, bscIdFuncionPadre.Text)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   Private Sub bscIdFuncionPadre_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscIdFuncionPadre.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosFuncion(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscNombreFuncionPadre_BuscadorClick() Handles bscNombreFuncionPadre.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaAplicacionFuncion2(Me.bscNombreFuncionPadre)
         Me.bscNombreFuncionPadre.Datos = New Reglas.AplicacionesFunciones().GetFiltradoPorNombre(bscIdAplicacion.Text, Me.bscNombreFuncionPadre.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscNombreFuncionPadre_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreFuncionPadre.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosFuncion(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarDatosFuncion(dr As DataGridViewRow)
      Me.bscNombreFuncionPadre.Text = dr.Cells(Entidades.AplicacionFuncion.Columnas.NombreFuncion.ToString()).Value.ToString()
      Me.bscIdFuncionPadre.Text = dr.Cells(Entidades.AplicacionFuncion.Columnas.IdFuncion.ToString()).Value.ToString().Trim()
      Me.bscNombreFuncionPadre.Selecciono = True
      Me.bscIdFuncionPadre.Selecciono = True
   End Sub


   Private Sub bscIdAplicacion_BuscadorClick() Handles bscIdAplicacion.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaAplicacion2(Me.bscIdAplicacion)
         Me.bscIdAplicacion.Datos = New Reglas.Aplicaciones().GetFiltradoPorCodigo(bscIdAplicacion.Text)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
   Private Sub bscIdAplicacion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscIdAplicacion.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosAplicacion(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscNombreAplicacion_BuscadorClick() Handles bscNombreAplicacion.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaAplicacion2(Me.bscNombreAplicacion)
         Me.bscNombreAplicacion.Datos = New Reglas.Aplicaciones().GetFiltradoPorNombre(Me.bscNombreAplicacion.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscNombreAplicacion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreAplicacion.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosAplicacion(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarDatosAplicacion(dr As DataGridViewRow)
      Me.bscNombreAplicacion.Text = dr.Cells(Entidades.Aplicacion.Columnas.NombreAplicacion.ToString()).Value.ToString()
      Me.bscIdAplicacion.Text = dr.Cells(Entidades.Aplicacion.Columnas.IdAplicacion.ToString()).Value.ToString().Trim()
      Me.bscNombreAplicacion.Selecciono = True
      Me.bscIdAplicacion.Selecciono = True
   End Sub

#End Region

End Class