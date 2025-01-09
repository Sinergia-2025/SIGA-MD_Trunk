#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class ConceptosDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region
   Public ReadOnly Property Concepto As Entidades.Concepto
      Get
         Return DirectCast(_entidad, Entidades.Concepto)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Concepto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()

         Dim dtRubrosConceptos As DataTable
         Dim oRubroConcepto As Reglas.RubrosConceptos = New Reglas.RubrosConceptos()
         dtRubrosConceptos = oRubroConcepto.GetAll()

         Me.BindearControles(Me._entidad)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then

            Me.chbActivo.Checked = True
            cmbGrupoGastos.SelectedIndex = 0

            Me.CargarProximoNumero()
            DirectCast(Me._entidad, Entidades.Concepto).Usuario = actual.Nombre

            Me.txtId.Focus()
         Else

            'Navego los tabs para activar los controles combobox y que luego se validen, sino, no sucede.

            Me.bscCodigoRubro.PresionarBoton()
            chbProducto.Checked = Not String.IsNullOrWhiteSpace(Concepto.IdProducto)
            If chbProducto.Checked Then
               bscCodigoProducto2.Text = Concepto.IdProducto
               bscCodigoProducto2.PresionarBoton()
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Conceptos()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If Not Me.bscCodigoRubro.Selecciono And Not Me.bscRubro.Selecciono Then
         Me.bscRubro.Focus()
         Return "No selecciono el Rubro."
      End If

      If chbProducto.Checked And Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono Then
         Me.bscCodigoProducto2.Focus()
         Return "No selecciono un Producto."
      End If

      Return MyBase.ValidarDetalle()
   End Function

   Protected Overrides Sub Aceptar()
      Concepto.IdProducto = bscCodigoProducto2.Text
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtNombre.Focus()
      ''Pasa por aca si dio error la Edicion porque ingreso algun dato invalido.
      'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
      '   Me.bscCodigoRubro.Text = ""
      '   Me.bscRubro.Text = String.Empty
      '   Me.chbActivo.Checked = True
      '   Me.CargarProximoNumero()
      '   Me.txtId.Focus()
      'End If
   End Sub

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      Try
         Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
         Me.bscProducto2.Enabled = Me.chbProducto.Checked
         If Not Me.chbProducto.Checked Then
            Me.bscCodigoProducto2.Text = String.Empty
            Me.bscProducto2.Text = String.Empty
         Else
            Me.bscCodigoProducto2.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


#Region "Eventos Busquedas Foraneas"
   Private Sub bscCodigoRubro_BuscadorClick() Handles bscCodigoRubro.BuscadorClick
      Try
         Dim oRubrosConceptos As Reglas.RubrosConceptos = New Reglas.RubrosConceptos
         Me._publicos.PreparaGrillaRubrosConceptos(Me.bscCodigoRubro)
         Me.bscCodigoRubro.Datos = oRubrosConceptos.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoRubro.Text))
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoRubro_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoRubro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarRubro(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscRubro_BuscadorClick() Handles bscRubro.BuscadorClick
      Try
         Dim oRubrosConceptos As Reglas.RubrosConceptos = New Reglas.RubrosConceptos
         Me._publicos.PreparaGrillaRubrosConceptos(Me.bscRubro)
         Me.bscRubro.Datos = oRubrosConceptos.GetPorNombre(Me.bscRubro.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscRubro_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscRubro.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarRubro(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Me.txtId.Text = (New Reglas.Conceptos().GetCodigoMaximo() + 1).ToString()
   End Sub

   Private Sub CargarRubro(dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.Concepto).IdRubroConcepto = Int32.Parse(dr.Cells("IdRubroConcepto").Value.ToString())
      Me.bscCodigoRubro.Text = dr.Cells("IdRubroConcepto").Value.ToString()
      Me.bscRubro.Text = dr.Cells("NombreRubroConcepto").Value.ToString()
   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
   End Sub

#End Region
End Class