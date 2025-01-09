Imports actual = Eniac.Entidades.Usuario.Actual

Public Class BaseFiltroMultiple

   Protected _publicos As Publicos
   Protected _columnasAMostrar As List(Of String)
   Protected _pathArchivo As String = "C:\Eniac\Filtros\{0}\"

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)
      Me._publicos = New Publicos()
   End Sub

   Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
      Me.Close()
   End Sub


End Class