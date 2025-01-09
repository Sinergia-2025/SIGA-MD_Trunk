Option Strict On
Option Explicit On
Imports System.IO
Public Class Link
   Inherits BaseDetalle
#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.ProductoLinks)
      Me.InitializeComponent()
      _entidad = DirectCast(entidad, Entidades.ProductoLinks)

   End Sub

   Private _publicos As Publicos
#End Region

 
   Private ReadOnly Property Link As Entidades.ProductoLinks
      Get
         Return DirectCast(Me._entidad, Eniac.Entidades.ProductoLinks)
      End Get
   End Property

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      Dim tempText As String = Me.Text

      MyBase.OnLoad(e)

      btnBuscarLink.Visible = StateForm = Win.StateForm.Insertar

      Me._publicos = New Publicos()

      '   _entidad = DirectCast(_regla.GetOClonar(Link), Entidades.Entidad)

      Me.BindearControles(Me._entidad)

      Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()

      If StateForm = Win.StateForm.Insertar Then
         Dim oLink As Reglas.ProductosLinks = New Reglas.ProductosLinks()
         Link.ItemLink = oLink.GetCodigoMaximo(Link.IdProducto) + 1
      End If

      Me.Text = tempText

   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.ProductosLinks()
   End Function

#End Region

#Region "Eventos"

#End Region

#Region "Metodos"
   Protected Overrides Sub Aceptar()

      MyBase.Aceptar()

      If IsNothing(Link.Link) Then
         If String.IsNullOrWhiteSpace(Link.Link) Then
            ShowMessage("Debe seleccionar un archivo a adjuntar.")
            btnBuscarLink.Focus()
            Exit Sub
         End If
        
         Dim fi As FileInfo = New FileInfo(Link.Link)
         If Not fi.Exists Then
            ShowMessage("El archivo seleccionado no existe.")
            btnBuscarLink.Focus()
            Exit Sub
         Else

         End If
      End If
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()

   End Sub

#End Region

   Private Sub btnBuscarLink_Click(sender As Object, e As EventArgs) Handles btnBuscarLink.Click
      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop

      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            Dim fileInfo As FileInfo = New FileInfo(DialogoAbrirArchivo.FileName)
            If fileInfo.Exists Then
               'Si bien aca lo pude abrir, solo es para obtener el path.
               txtNombreLink.Text = DialogoAbrirArchivo.FileName
               txtNombreLink.Focus()
            Else
               ShowMessage(String.Format("No se puede acceder al archivo '{0}'.", DialogoAbrirArchivo.FileName))
            End If
         Catch Ex As Exception
            ShowMessage(String.Format("ATENCION: No se puede leer el Archivo. Error: {0}", Ex.Message))
         End Try
      End If
   End Sub
  
  
End Class