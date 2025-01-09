Option Strict On
Option Explicit On
Imports Eniac.Win
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Public Class ProvinciasABM

#Region "Campos"

   Private _publicos As Publicos

   Private _tit As Dictionary(Of String, String) = New Dictionary(Of String, String)()

   Private IdUsuario As String = actual.Nombre

#End Region

#Region "Overrides"
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Provincias()
   End Function
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         '_tit = New Dictionary(Of String, String)()
         'For Each col As UltraGridColumn In dgvDatos.DisplayLayout.Bands(0).Columns
         '   If Not col.Hidden Then
         '      _tit.Add(col.Key, String.Empty)
         '   End If
         'Next

         Me._publicos = New Publicos()

         Me.tsbBorrar.Enabled = False
         Me.tsbNuevo.Enabled = False
         Me.tsbNuevo.Visible = False
         Me.tsbBorrar.Visible = False
         Me.tsbImprimir.Visible = False
         Me.tsbImprimir.Enabled = False

         'CargaGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ProvinciasDetalle(DirectCast(Me.GetEntidad(), Entidades.Provincia))
      End If
      Return New ProvinciasDetalle(New Entidades.Provincia)
   End Function

#End Region
   
#Region "Metodos"

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      MyBase.GetEntidad()

      Dim provincia As Entidades.Provincia = New Entidades.Provincia

      With Me.dgvDatos.ActiveCell.Row
         provincia = New Reglas.Provincias().GetUno(.Cells("IdProvincia").Value.ToString())
      End With

      Return provincia

   End Function


   Protected Overrides Sub FormatearGrilla()

      dgvDatos.AgregarFiltroEnLinea({Entidades.Provincia.Columnas.NombreProvincia.ToString()})

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0

         .Columns(Entidades.Provincia.Columnas.IdPais.ToString()).Hidden = True
         .Columns(Entidades.Pais.Columnas.NombrePais.ToString()).FormatearColumna("País", col, 120)
         .Columns(Entidades.Provincia.Columnas.IdProvincia.ToString()).FormatearColumna("Código", col, 80)
         .Columns(Entidades.Provincia.Columnas.NombreProvincia.ToString()).FormatearColumna("Provincia", col, 120)
         .Columns(Entidades.Provincia.Columnas.Jurisdiccion.ToString()).FormatearColumna("Jurisd.", col, 70, HAlign.Center)
         .Columns(Entidades.Provincia.Columnas.EsAgentePercepcion.ToString()).FormatearColumna("Es Agente Percep.", col, 80, HAlign.Center)
         .Columns(Entidades.Provincia.Columnas.IngBrutos.ToString()).FormatearColumna("Nro. Contribuyente IIBB", col, 150, HAlign.Right)
         .Columns(Entidades.Provincia.Columnas.AgenteIngBrutos.ToString()).FormatearColumna("Nro. Agente IIBB", col, 150, HAlign.Right)

         .Columns(Entidades.Provincia.Columnas.IdCuentaDebe.ToString()).FormatearColumna("Cta Compras", col, 80, HAlign.Right)
         .Columns("NombreCuentaDebe").FormatearColumna("Nombre Cuenta Compras", col, 150)

         .Columns(Entidades.Provincia.Columnas.IdCuentaHaber.ToString()).FormatearColumna("Cta Ventas", col, 80, HAlign.Right)
         .Columns("NombreCuentaHaber").FormatearColumna("Nombre Cuenta Ventas", col, 150)

         If Not Publicos.TieneModuloContabilidad Then
            .Columns("idCuentaDebe").Hidden = True
            .Columns("nombreCuentaDebe").Hidden = True
            .Columns("idCuentaHaber").Hidden = True
            .Columns("nombreCuentaHaber").Hidden = True
         End If
      End With
   End Sub

   'Private Sub RefrescarDatosGrilla()

   '   If Not Me.dgvDatos.DataSource Is Nothing Then
   '      DirectCast(Me.dgvDatos.DataSource, DataTable).Rows.Clear()
   '   End If

   'End Sub

   'Private Sub CargaGrilla()

   '   Dim oProvincias As Reglas.Provincias = GetReglas()

   '   Dim dtDetalle As DataTable
   '   ', dt As DataTable, drCl As DataRow

   '   dtDetalle = oProvincias.GetAll()

   '   Me.dgvDatos.DataSource = dtDetalle

   '   AjustarColumnasGrilla()
   '   'Me.FormatearGrilla()

   '   Me.tssRegistros.Text = Me.dgvDatos.Rows.Count.ToString() & " Registros"

   'End Sub

   'Private Sub AjustarColumnasGrilla()
   '   'SI SE DESEA CAMBIAR EL TITULO DE ALGUNA COLUMNA EN PARTICULAR
   '   'tit("NOMBRECOLUMNA") = "NUEVO HEADER"

   '   For Each col As UltraGridColumn In dgvDatos.DisplayLayout.Bands(0).Columns
   '      col.Hidden = Not _tit.ContainsKey(col.Key)
   '      If _tit.ContainsKey(col.Key) Then
   '         If Not String.IsNullOrWhiteSpace(_tit(col.Key)) Then
   '            col.Header.Caption = _tit(col.Key)
   '         End If
   '      End If
   '   Next
   'End Sub

#End Region

#Region "Eventos"
   'Private Sub Provincias_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
   '   If e.KeyCode = Keys.F5 Then
   '      Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
   '   End If
   'End Sub

   'Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
   '   Try
   '      Me.Cursor = Cursors.WaitCursor

   '      Me.RefrescarDatosGrilla()

   '      Me.tssRegistros.Text = Me.dgvDatos.Rows.Count.ToString() & " Registros"

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

   '   Finally
   '      Me.Cursor = Cursors.Default
   '   End Try
   'End Sub

   'Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
   '   Me.Close()
   'End Sub


#End Region

End Class