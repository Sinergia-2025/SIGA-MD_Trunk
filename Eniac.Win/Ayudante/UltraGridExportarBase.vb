#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class UltraGridExportarBase
   Protected Sub AbrirArchivoExportado(archivo As String)
      Dim abrirArchivo As Boolean = False

      If Reglas.Publicos.AbrirArchivoExportado <> Reglas.Publicos.AbrirArchivoExportadoModo.Nunca Then
         If Reglas.Publicos.AbrirArchivoExportado = Reglas.Publicos.AbrirArchivoExportadoModo.Siempre Then
            abrirArchivo = True
         Else
            abrirArchivo = MessageBox.Show(String.Format("¿Desea abrir el archivo '{0}' recién exportado?", IO.Path.GetFileName(archivo)),
                                           "Abrir archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes
         End If
      End If

      If abrirArchivo Then
         Process.Start(archivo)
      End If
   End Sub
End Class