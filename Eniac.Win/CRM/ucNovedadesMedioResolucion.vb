Option Strict On
Option Explicit On
Public Class ucNovedadesMedioResolucion

   Private _terminoCargaInicial As Boolean = False

   Private _idTipoNovedad As String
   Public Property IdTipoNovedad() As String
      Get
         Return _idTipoNovedad
      End Get
      Set(ByVal value As String)
         _idTipoNovedad = value
         If _terminoCargaInicial Then
            _publicos.CargaComboCRMMetodoResolucionNovedad(cmbMedioResolucion, value)
         End If
      End Set
   End Property

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      _publicos.CargaComboCRMMetodoResolucionNovedad(cmbMedioResolucion, IdTipoNovedad)

      _terminoCargaInicial = True
   End Sub

   Public Property IdMetodoResolucionNovedad() As Integer
      Get
         If cmbMedioResolucion.SelectedValue Is Nothing Then Return 0
         Return Integer.Parse(cmbMedioResolucion.SelectedValue.ToString())
      End Get
      Set(ByVal value As Integer)
         Try
            cmbMedioResolucion.SelectedValue = value
         Catch ex As Exception
            cmbMedioResolucion.SelectedIndex = -1
         End Try
      End Set
   End Property
End Class
