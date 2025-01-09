Option Strict On
Option Explicit On
Public Class FacturacionAccionesAdicionales

   Public Property TeclaPresionada As Keys
   'Private Property BotonesDict As Dictionary(Of String, Button)


   Private Property Botones As IEnumerable(Of Button)
   Private Property Acciones As IEnumerable(Of Accion)
   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      Botones = {btn01, btn02, btn03, btn04, btn05, btn06, btn07, btn08, btn09, btn10}
   End Sub
   Public Overloads Function ShowDialog(owner As IWin32Window, acciones As IEnumerable(Of Accion)) As DialogResult
      Me.Acciones = acciones.Where(Function(x) x.Visible).ToArray()
      Return Me.ShowDialog(owner)
   End Function

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         'BotonesDict = New Dictionary(Of String, Button)()

         For i As Integer = 0 To Botones.Count - 1
            If Acciones.Count > i Then
               Dim acc As Accion = Acciones(i)
               Dim boton As Button = Botones(i)
               boton.Text = String.Format("{0} ({1})", acc.NombreAccion, acc.TeclaRapida.ToString().Replace(", ", "+"))
               boton.Tag = acc.TeclaRapida
               If Not String.IsNullOrWhiteSpace(acc.Permiso) Then
                  boton.Enabled = New Reglas.Usuarios().TienePermisos(acc.Permiso)
               End If
               If acc.Imagen IsNot Nothing Then
                  boton.Image = acc.Imagen
               End If
            Else
               OcultarBoton(Botones(i))
            End If
         Next

         'AgregarBoton(btn01, "CopiarComprobantes")
         'AgregarBoton(btn02, "ImpresionTicketFiscal")

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub OcultarBoton(boton As Button)
      boton.Visible = False
      Me.Height = Me.Height - boton.Height - 8
   End Sub

   'Private Sub AgregarBoton(boton As Button, permiso As String)
   '   boton.Enabled = New Reglas.Usuarios().TienePermisos(permiso)

   '   If boton.Enabled Then
   '      BotonesDict.Add(boton.Name, boton)
   '   End If
   'End Sub

   'Protected Overrides Sub OnShown(e As EventArgs)
   '   MyBase.OnShown(e)

   '   If Botones.Count = 0 Then
   '      btnCancelar.PerformClick()
   '   ElseIf Botones.Count = 1 Then
   '      Botones.Values(0).PerformClick()
   '   End If

   'End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Dim accCol As Accion() = Acciones.Where(Function(x) x.TeclaRapida = keyData).ToArray()

      If accCol.Count > 0 Then
         Cerrar(accCol(0).TeclaRapida)
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

   Private Sub btnReemplazarComprobante_Click(sender As Object, e As EventArgs) Handles btn01.Click, btn02.Click, btn03.Click, btn04.Click, btn05.Click, btn06.Click, btn07.Click, btn08.Click, btn09.Click, btn10.Click
      If TypeOf (sender) Is Button AndAlso TypeOf (DirectCast(sender, Button).Tag) Is Keys Then
         Cerrar(DirectCast(DirectCast(sender, Button).Tag, Keys))
      End If
   End Sub

   Private Sub Cerrar(tecla As Keys)
      Try
         TeclaPresionada = tecla
         DialogResult = Windows.Forms.DialogResult.OK
         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      DialogResult = Windows.Forms.DialogResult.Cancel
      Close()
   End Sub


   Public Class Accion
      Public Property TeclaRapida As Keys
      Public Property NombreAccion As String
      Public Property Permiso As String
      Public Property Visible As Boolean
      Public Property Imagen As Image

      Public Sub New(teclaRapida As Keys, nombreAccion As String, permiso As String)
         Me.TeclaRapida = teclaRapida
         Me.NombreAccion = nombreAccion
         Me.Permiso = permiso
         Me.Visible = True
      End Sub
   End Class

End Class