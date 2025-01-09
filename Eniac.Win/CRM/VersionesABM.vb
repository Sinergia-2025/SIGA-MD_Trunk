#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class VersionesABM

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Ayudante.Grilla.AgregarFiltroEnLinea(dgvDatos, {})
         tsbImprimir.Visible = False
         ''Hay que colocarlo del CargarColumnasASumar porque sino da error.
         'Me.LeerPreferencias()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New VersionesDetalle(DirectCast(Me.GetEntidad(), Entidades.Version))
      End If
      Return New VersionesDetalle(New Entidades.Version())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Versiones()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      With Me.dgvDatos.ActiveRow
         Return New Reglas.Versiones().GetUno(.Cells("IdAplicacion").Value.ToString(), .Cells("NroVersion").Value.ToString())
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.Version.Columnas.IdAplicacion.ToString()).FormatearColumna("Aplicación", pos, 100)
         .Columns(Entidades.Version.Columnas.NroVersion.ToString()).FormatearColumna("Nro. Versión", pos, 100)
         .Columns(Entidades.Version.Columnas.VersionFecha.ToString()).FormatearColumna("Fecha Versión", pos, 100, HAlign.Center, , "dd/MM/yyyy HH:mm")
         .Columns(Entidades.Version.Columnas.IdAplicacionBase.ToString()).FormatearColumna("Ap. Base", pos, 100)
         .Columns(Entidades.Version.Columnas.NroVersionAplicacionBase.ToString()).FormatearColumna("Versión Ap. Base", pos, 100)
         .Columns(Entidades.Version.Columnas.VersionFramework.ToString()).FormatearColumna("Versión Framework", pos, 100)
         .Columns(Entidades.Version.Columnas.VersionReportViewer.ToString()).FormatearColumna("Versión ReportViewer", pos, 100)
         .Columns(Entidades.Version.Columnas.VersionLenguaje.ToString()).FormatearColumna("Versión Lenguaje", pos, 100)
      End With
   End Sub
#End Region
End Class