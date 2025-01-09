Option Explicit On
Option Strict On
Public Class ContabilidadCuentasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Dim frmDetalle As New ContabilidadCuentasDetalle(DirectCast(Me.GetEntidad(), Entidades.ContabilidadCuenta))
         Return frmDetalle
      End If
      Return New ContabilidadCuentasDetalle(New Entidades.ContabilidadCuenta())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ContabilidadCuentas()
   End Function

   Protected Overrides Sub Borrar()
      Try
         Dim ent As Entidades.ContabilidadCuenta = DirectCast(Me.GetEntidad(), Entidades.ContabilidadCuenta)
         If ent.Nivel = 1 Then
            MessageBox.Show("No se puede eliminar una cuenta de nivel 1.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
         If Me.TieneAsientosLaCuenta(ent.IdCuenta) Then
            MessageBox.Show("La cuenta que intenta eliminar posee asientos contables asociados. No se puede eliminar.", "Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MyBase.Borrar()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim cta As Entidades.ContabilidadCuenta = New Entidades.ContabilidadCuenta()
      Dim cuentas As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()

      With Me.dgvDatos.ActiveCell.Row
         cta = cuentas.GetUna(Long.Parse(.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()))
      End With

      Return cta

   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).FormatearColumna("Id Cta.", pos, 85, HAlign.Right)
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).FormatearColumna("Descripción", pos, 250)
         .Columns(Entidades.ContabilidadCuenta.Columnas.Nivel.ToString()).FormatearColumna("Nivel", pos, 60, HAlign.Right)
         .Columns(Entidades.ContabilidadCuenta.Columnas.EsImputable.ToString()).FormatearColumna("Imputable", pos, 70, HAlign.Center)
         .Columns(Entidades.ContabilidadCuenta.Columnas.AjustaPorInflacion.ToString()).FormatearColumna("Ajusta Por Inflación", pos, 70, HAlign.Center)
         .Columns(Entidades.ContabilidadCuenta.Columnas.TipoCuenta.ToString()).FormatearColumna("Tipo de Cuenta", pos, 100)
         .Columns(Entidades.ContabilidadCuenta.Columnas.Activa.ToString()).FormatearColumna("Activa", pos, 60, HAlign.Center)

         .Columns(Entidades.ContabilidadCuenta.Columnas.IdCuentaPadre.ToString()).FormatearColumna("Id Cta. Madre", pos, 85, HAlign.Right)
         .Columns("NombreCuentaPadre").FormatearColumna("Cta. Madre", pos, 250)
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString(), "NombreCuentaPadre"})
   End Sub

#End Region

#Region "privados"

   Private Function TieneAsientosLaCuenta(ByVal idCuenta As Long) As Boolean
      Return New Reglas.ContabilidadCuentas().TieneAsientosLaCuenta(idCuenta)
   End Function

#End Region

End Class