Option Strict Off

Public Class TransportistasABM

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Dim tsi As ToolStripButton = New ToolStripButton("Geo", Nothing, AddressOf PresionarGeo)
      Me.tstBarra.Items.Insert(Me.tstBarra.Items.Count - 1, tsi)

   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TransportistasDetalle(Me.GetEntidad())
      End If
      Return New TransportistasDetalle(New Entidades.Transportista)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Transportistas()
   End Function
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Transportistas.rdlc", "SistemaDataSet_Transportistas", Me.dtDatos, True)
         frmImprime.Text = "Transportistas"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim transporte As Entidades.Transportista = New Entidades.Transportista
      With Me.dgvDatos.ActiveCell.Row
         transporte = New Reglas.Transportistas().GetUno(Integer.Parse(.Cells("IdTransportista").Value.ToString()))
      End With
      Return transporte
   End Function


   Protected Overrides Sub FormatearGrilla()

      Grilla.AgregarFiltroEnLinea(dgvDatos, {("idTransportista").ToString(), "NombreTransportista", "NombreCategoriaFiscal", "DireccionTransportista"})

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         .Columns("idTransportista").FormatearColumna("Codigo", pos, 70, HAlign.Right)
         .Columns("NombreTransportista").FormatearColumna("Transportista", pos, 200, HAlign.Right)
         .Columns("DireccionTransportista").FormatearColumna("Direccion", pos, 120, HAlign.Right)
         .Columns("IdLocalidadTransportista").Hidden = True
         .Columns("NombreLocalidad").FormatearColumna("Localidad", pos, 120, HAlign.Right)
         .Columns("cuitTransportista").FormatearColumna("Cuit Transp", pos, 90, HAlign.Right)
         .Columns("TelefonoTransportista").FormatearColumna("Tel Transp", pos, 120, HAlign.Right)
         .Columns("NombreCategoriaFiscal").FormatearColumna("Categoria Fiscal", pos, 120, HAlign.Right)
         .Columns("LetraFiscal").Hidden = True
         .Columns("IdCategoriaFiscalTransportista").Hidden = True
         .Columns("KilosMaximo").FormatearColumna("kilosMaximo", pos, 80, HAlign.Right)
         .Columns("PaletsMaximo").FormatearColumna("kilosMaximo", pos, 80, HAlign.Right)
         .Columns("Activo").FormatearColumna("kilosMaximo", pos, 45, HAlign.Right)

      End With

   End Sub

   Public Sub PresionarGeo(ByVal o As Object, ByVal e As EventArgs)
      Try
         Dim geo As EmpleadosGeoLocalizacion = New EmpleadosGeoLocalizacion()
         geo.Empleados = DirectCast(Me.dgvDatos.DataSource, DataTable)
         geo.ShowDialog()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

End Class