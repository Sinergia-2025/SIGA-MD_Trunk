Public Class FeriadosABM
   Public WithEvents tsbCopiar1 As ToolStripButton

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      tsbCopiar1 = New ToolStripButton()
      tstBarra.Items.Insert(tstBarra.Items.IndexOf(tsbBorrar), tsbCopiar1)
      '
      'tsbCopiar
      '
      tsbCopiar1.Image = Global.Eniac.Win.My.Resources.Resources.copy_ok_24
      tsbCopiar1.ImageTransparentColor = Color.Magenta
      tsbCopiar1.Name = "tsbCopiar"
      tsbCopiar1.Size = New Size(76, 26)
      tsbCopiar1.Text = "&Copiar"

   End Sub

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         BotonImprimir.Visible = False
         tstBuscar.Text = Today.Year.ToString()
         RefreshGrid()
      End Sub)
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New FeriadosDetalle(DirectCast(GetEntidad(), Entidades.Feriado))
      End If
      Return New FeriadosDetalle(New Entidades.Feriado())
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Feriados()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      With dgvDatos.ActiveRow
         Return New Reglas.Feriados().GetUno(Date.Parse(.Cells(Entidades.Feriado.Columnas.FechaFeriado.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col = 0I
         .Columns(Entidades.Feriado.Columnas.FechaFeriado.ToString()).FormatearColumna("Fecha", col, 100, HAlign.Center)
         .Columns(Entidades.Feriado.Columnas.NombreFeriado.ToString()).FormatearColumna("Nombre", col, 400)
      End With
   End Sub

#End Region
#Region "Eventos"
   Private Sub tsbCopiar_Click(sender As Object, e As EventArgs) Handles tsbCopiar1.Click
      TryCatched(
      Sub()
         Dim feriado As Entidades.Feriado = Nothing
         If dgvDatos.ActiveRow IsNot Nothing Then
            feriado = New Entidades.Feriado(Date.Parse(dgvDatos.ActiveRow.Cells(Entidades.Feriado.Columnas.FechaFeriado.ToString()).Value.ToString()))
         End If

         Dim detalle = New FeriadosCopiar(feriado) With {.StateForm = StateForm.Insertar}
         If TypeOf (detalle) Is IConIdFuncion Then
            DirectCast(detalle, IConIdFuncion).IdFuncion = IdFuncion
         End If
         AbrirFormularioNuevo(detalle)
         RefreshGrid()
      End Sub)
   End Sub
#End Region
End Class