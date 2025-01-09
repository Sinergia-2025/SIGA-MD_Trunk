Public Class SubSubRubrosDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(idSubRubro As Integer, subSubRubro As Entidades.SubSubRubro)
      Me.InitializeComponent()
      Me._entidad = subSubRubro
      _idSubRubro = idSubRubro
   End Sub

#End Region

#Region "Campos"

   Private _publicos As Publicos
   Private _idSubRubro As Integer
   Private _estaCargando As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      'Me._tituloNuevo = "Nueva"
      MyBase.OnLoad(e)

      Me._estaCargando = True

      Me._publicos = New Publicos()

      Me.BindearControles(Me._entidad)

      If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
         Me.bscCodigoRubro.PresionarBoton()
         Me.bscCodigoSubRubro.PresionarBoton()
      Else
         If _idSubRubro > 0 Then
            bscCodigoSubRubro.Text = _idSubRubro.ToString()
            bscCodigoSubRubro.PresionarBoton()
            'CargarProximoNumero()
         End If
      End If

      Me._estaCargando = False

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SubSubRubros()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If StateForm = Win.StateForm.Insertar Then
         If Not Me.bscCodigoSubRubro.Selecciono And Not Me.bscSubRubro.Selecciono Then
            Me.bscSubRubro.Focus()
            Return "No selecciono el SubRubro."
         End If
      End If

      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Eventos"

   Private Sub bscCodigoSubRubro_BuscadorClick() Handles bscCodigoSubRubro.BuscadorClick
      Try
         'Dim oRubros As Reglas.SubRubros = New Reglas.SubRubros
         'Me._publicos.PreparaGrillaSubRubrosSS(Me.bscCodigoSubRubro)
         'Me.bscCodigoSubRubro.Datos = oRubros.GetPorCodigoSubrubro(Integer.Parse("0" & Me.bscCodigoSubRubro.Text))

         Dim oSubRubros As Reglas.SubRubros = New Reglas.SubRubros
         Me._publicos.PreparaGrillaSubRubros(Me.bscCodigoSubRubro)
         Me.bscCodigoSubRubro.Datos = oSubRubros.GetPorCodigo(If(IsNumeric(bscCodigoRubro.Text), Integer.Parse(bscCodigoRubro.Text), 0),
                                                              If(IsNumeric(bscCodigoSubRubro.Text), Integer.Parse(bscCodigoSubRubro.Text), 0))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoSubRubro_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoSubRubro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarSubRubro(e.FilaDevuelta)
            Me.txtIdSubSubRubro.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscSubRubro_BuscadorClick() Handles bscSubRubro.BuscadorClick
      Try
         Dim idRubro As Integer = 0
         Dim oRubros As Reglas.SubRubros = New Reglas.SubRubros
         Me._publicos.PreparaGrillaSubRubrosSS(Me.bscSubRubro)
         Integer.TryParse(Me.bscCodigoRubro.Text, idRubro)
         Me.bscSubRubro.Datos = oRubros.GetPorNombre(idRubro, Me.bscSubRubro.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscSubRubro_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscSubRubro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarSubRubro(e.FilaDevuelta)
            Me.txtIdSubSubRubro.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Me.txtIdSubSubRubro.Focus()
   End Sub

   Private Sub bscCodigoRubro_BuscadorClick() Handles bscCodigoRubro.BuscadorClick
      Try
         Dim oRubros As Reglas.Rubros = New Reglas.Rubros
         Me._publicos.PreparaGrillaRubros(Me.bscCodigoRubro)
         Me.bscCodigoRubro.Datos = oRubros.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoRubro.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoRubro_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoRubro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarRubro(e.FilaDevuelta)
            If Me.bscCodigoSubRubro.Visible Then
               Me.bscCodigoSubRubro.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreRubro_BuscadorClick() Handles bscNombreRubro.BuscadorClick
      Try
         Dim oRubros As Reglas.Rubros = New Reglas.Rubros
         Me._publicos.PreparaGrillaRubros(Me.bscNombreRubro)
         Me.bscNombreRubro.Datos = oRubros.GetPorNombre(Me.bscNombreRubro.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreRubro_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreRubro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarRubro(e.FilaDevuelta)
            If Me.bscCodigoSubRubro.Visible Then
               Me.bscCodigoSubRubro.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarSubRubro(ByVal dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.SubSubRubro).IdSubRubro = Integer.Parse(dr.Cells("IdSubRubro").Value.ToString())
      Me.bscCodigoSubRubro.Text = dr.Cells("IdSubRubro").Value.ToString()
      Me.bscSubRubro.Text = dr.Cells("NombreSubRubro").Value.ToString()


      Dim idRubroPantalla As Integer = 0
      If IsNumeric(bscCodigoRubro.Text) Then idRubroPantalla = Integer.Parse(bscCodigoRubro.Text)
      If idRubroPantalla = 0 Then
         Dim tempEstaCargando As Boolean = _estaCargando
         _estaCargando = True
         bscCodigoRubro.Text = dr.Cells("IdRubro").Value.ToString()
         bscCodigoRubro.PresionarBoton()
         _estaCargando = tempEstaCargando
      End If


   End Sub

   Private Sub CargarProximoNumero()
      Dim oRubro As Reglas.SubSubRubros = New Reglas.SubSubRubros()
      Me.txtIdSubSubRubro.Text = (oRubro.GetCodigoMaximo(Integer.Parse(Me.bscCodigoSubRubro.Text)) + 1).ToString()
   End Sub

   Private Sub CargarRubro(ByVal dr As DataGridViewRow)
      'tengo que limpiar el SubRubro si cargo un Rubro si no esta cargando la pantalla
      If Not Me._estaCargando And Me.bscCodigoSubRubro.Visible Then
         Me.bscCodigoSubRubro.Text = "0"
         Me.bscSubRubro.Text = ""
      End If
      If Not Me._estaCargando Then
         Me.txtIdSubSubRubro.Text = "0"
         Me.txtNombreSubSubRubro.Text = ""
      End If

      DirectCast(Me._entidad, Entidades.SubSubRubro).IdRubro = Int32.Parse(dr.Cells("IdRubro").Value.ToString())
      Me.bscCodigoRubro.Text = dr.Cells("IdRubro").Value.ToString()
      Me.bscNombreRubro.Text = dr.Cells("NombreRubro").Value.ToString()
   End Sub

#End Region
End Class
