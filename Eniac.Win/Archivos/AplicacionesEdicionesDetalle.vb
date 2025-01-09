Option Strict On
Option Explicit On
Imports Eniac.Entidades
Imports Infragistics.Win.UltraWinGrid

Public Class AplicacionesEdicionesDetalle

   Private _publicos As Publicos
   Private _dtModulos As DataTable
   Private _dtModulosEdiciones As DataTable

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Eniac.Entidades.AplicacionEdicion)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

   Private _tit As Dictionary(Of String, String)

   Public ReadOnly Property AplicacionEdicion() As Entidades.AplicacionEdicion
      Get
         Return DirectCast(Me._entidad, AplicacionEdicion)
      End Get
   End Property


#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me._publicos.CargaComboAplicaciones(cmbAplicacion)

         Me.BindearControles(Me._entidad)

         _tit = GetColumnasVisiblesGrilla(ugModulosAplicacion)

         _dtModulos = New Reglas.AplicacionesModulos().GetAll()
         Me.ugModulos.DataSource = _dtModulos

         Me.ugModulosAplicacion.DataSource = AplicacionEdicion.Modulos

         AjustarColumnasGrilla(ugModulosAplicacion, _tit)

         If Me.StateForm = Win.StateForm.Insertar Then
            Me.cmbAplicacion.SelectedIndex = 0
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.AplicacionesEdiciones()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      MyBase.ValidarDetalle()

      If Me.txtIdEdicion.Text.Trim() = "0" Then
         Me.txtIdEdicion.Focus()
         Return "No puede poner el codigo 0."
      End If

      If AplicacionEdicion.Modulos.Count = 0 Then
         If MessageBox.Show("¿Desea grabar la tabla de Ediciones sin Módulos?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            ' cmbModulos.Focus()
            Return "Debe ingresar módulos. Por favor reintente."
         End If
      End If

      Return String.Empty
   End Function

#End Region

#Region "Eventos"
   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtNombreEdicion.Focus()
   End Sub

   Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      Try
         Me.AgregarLinea()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnSacar_Click(sender As Object, e As EventArgs) Handles btnSacar.Click
      Try
         EliminarLinea()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbAlineacionPaneles_CheckedChanged_1(sender As Object, e As EventArgs) Handles chbAlineacionPaneles.CheckedChanged
      If Me.chbAlineacionPaneles.Checked Then
         Me.spcDatos.Orientation = Orientation.Horizontal
      Else
         Me.spcDatos.Orientation = Orientation.Vertical
      End If
   End Sub

#End Region

#Region "Metodos"
   Private Sub AgregarLinea()
      If Me.ValidaLinea() Then
         If ugModulos.Selected.Rows.Count = 0 And ugModulos.ActiveRow IsNot Nothing Then
            ugModulos.ActiveRow.Selected = True
         End If

         Try
            Dim drModuloCol As List(Of DataRow) = New List(Of DataRow)()
            For Each dgModulo As UltraGridRow In ugModulos.Selected.Rows
               If dgModulo.ListObject IsNot Nothing AndAlso
                  TypeOf (dgModulo.ListObject) Is DataRowView AndAlso
                  DirectCast(dgModulo.ListObject, DataRowView).Row IsNot Nothing Then
                  drModuloCol.Add(DirectCast(dgModulo.ListObject, DataRowView).Row)
               End If
            Next

            For Each drModulo As DataRow In drModuloCol

               Dim Modulo As AplicacionEdicionModulo = New AplicacionEdicionModulo()
               Modulo.IdAplicacion = cmbAplicacion.SelectedValue.ToString()
               Modulo.IdEdicion = txtIdEdicion.Text.ToString()
               Modulo.IdModulo = Integer.Parse(drModulo.Item("IdModulo").ToString())
               Modulo.NombreModulo = drModulo.Item("NombreModulo").ToString()

               AplicacionEdicion.Modulos.Add(Modulo)

            Next

         Catch
            _dtModulos.RejectChanges()
            Throw
         End Try
         ugModulosAplicacion.DataBind()
      End If
   End Sub

   Private Function ValidaLinea() As Boolean

      For Each modulo As AplicacionEdicionModulo In AplicacionEdicion.Modulos
         If modulo.IdModulo = Integer.Parse(ugModulos.ActiveRow.Cells("IdModulo").Value.ToString()) Then
            Throw New Exception("Ya existe el modulo.")
         End If
      Next
      Return True
   End Function

   Private Sub EliminarLinea()
      If ugModulosAplicacion.ActiveRow IsNot Nothing AndAlso
         ugModulosAplicacion.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugModulosAplicacion.ActiveRow.ListObject) Is AplicacionEdicionModulo Then
         If MessageBox.Show("¿Desea eliminar el módulo?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            AplicacionEdicion.Modulos.Remove(DirectCast(ugModulosAplicacion.ActiveRow.ListObject, AplicacionEdicionModulo))
            ugModulosAplicacion.DataBind()
         End If
      End If
   End Sub

#End Region




End Class
