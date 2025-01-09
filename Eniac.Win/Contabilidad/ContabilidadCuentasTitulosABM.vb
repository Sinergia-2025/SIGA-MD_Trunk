Option Explicit On
Option Strict On

Imports Eniac.Win

Public Class ContabilidadCuentasTitulosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Dim frmDetalle As New ContabilidadCuentasTitulosDetalle(DirectCast(Me.GetEntidad(), Entidades.ContabilidadCuentaTitulo))
         frmDetalle.IdCuenta = Integer.Parse(Me.dgvDatos.SelectedCells(0).OwningRow.Cells(Entidades.ContabilidadCuentaTitulo.Columnas.IdCuenta.ToString()).Value.ToString())
         Return frmDetalle
      End If
      Return New ContabilidadCuentasTitulosDetalle(New Entidades.ContabilidadCuentaTitulo)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ContabilidadCuentasTitulo()
   End Function

   Protected Overrides Sub Borrar()

      If TieneHijosLaCuenta(Me.dgvDatos.SelectedCells(0).OwningRow) Then
         MessageBox.Show("La cuenta que intenta eliminar posee cuentas Imputables asociadas. No se puede eliminar", "Cuentas", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Else
         MyBase.Borrar()
      End If

   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim Cuenta As Entidades.ContabilidadCuentaTitulo = New Entidades.ContabilidadCuentaTitulo
      Dim Cuentas As Reglas.ContabilidadCuentasTitulo = New Reglas.ContabilidadCuentasTitulo()

      With Me.dgvDatos.SelectedCells(0).OwningRow
         Cuenta = Cuentas.GetUna(Integer.Parse(.Cells(Entidades.ContabilidadCuentaTitulo.Columnas.IdCuenta.ToString()).Value.ToString()))
      End With

      Return Cuenta

   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Entidades.ContabilidadCuentaTitulo.Columnas.IdCuenta.ToString()).HeaderText = "Id Cta."
         .Columns(Entidades.ContabilidadCuentaTitulo.Columnas.IdCuenta.ToString()).Width = 95
         .Columns(Entidades.ContabilidadCuentaTitulo.Columnas.IdCuenta.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns(Entidades.ContabilidadCuentaTitulo.Columnas.NombreCuenta.ToString()).HeaderText = "Descripción"
         .Columns(Entidades.ContabilidadCuentaTitulo.Columnas.NombreCuenta.ToString()).Width = 300
         .Columns(Entidades.ContabilidadCuentaTitulo.Columnas.NombreCuenta.ToString()).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

         .Columns(Entidades.ContabilidadCuentaTitulo.Columnas.Nivel.ToString()).HeaderText = "Nivel"
         .Columns(Entidades.ContabilidadCuentaTitulo.Columnas.Nivel.ToString()).Width = 60
         .Columns(Entidades.ContabilidadCuentaTitulo.Columnas.Nivel.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         '.Columns(Entidades.ContabilidadCuentaTitulo.Columnas.IdCentroCosto.ToString()).HeaderText = "Centro Costo"
         '.Columns(Entidades.ContabilidadCuentaTitulo.Columnas.IdCentroCosto.ToString()).Width = 80
         '.Columns(Entidades.ContabilidadCuentaTitulo.Columnas.IdCentroCosto.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.ContabilidadCuentaTitulo.Columnas.IdCentroCosto.ToString()).Visible = False

         .Columns(Entidades.ContabilidadCuentaTitulo.Columnas.EsImputable.ToString()).HeaderText = "Imputable"
         .Columns(Entidades.ContabilidadCuentaTitulo.Columnas.EsImputable.ToString()).Width = 60

         .Columns(Entidades.ContabilidadCuentaTitulo.Columnas.Activa.ToString()).HeaderText = "Activa"
         .Columns(Entidades.ContabilidadCuentaTitulo.Columnas.Activa.ToString()).Width = 60

      End With
   End Sub

#End Region

#Region "Privados"

   Private Function TieneHijosLaCuenta(ByVal registroActual As System.Windows.Forms.DataGridViewRow) As Boolean
      Return New Reglas.ContabilidadCuentasTitulo().TieneHijosLaCuenta(Int32.Parse(registroActual.Cells(Eniac.Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()))
   End Function

#End Region

End Class