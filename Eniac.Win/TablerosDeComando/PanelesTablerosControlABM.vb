Public Class PanelesTablerosControlABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      MyBase.OnLoad(e)
      Me.dgvDatos.AgregarFiltroEnLinea({Entidades.TableroControlPanel.Columnas.NombrePanel.ToString(),
                                        Entidades.TableroControlPanel.Columnas.Parametros.ToString(),
                                        Entidades.TableroControlPanel.Columnas.IdController.ToString()})
   End Sub

   'GET DETALLE
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New PanelesTablerosControlDetalle(DirectCast(Me.GetEntidad(), Entidades.TableroControlPanel))
      End If
      Return New PanelesTablerosControlDetalle(New Entidades.TableroControlPanel)
   End Function
   'GET REGLAS
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TablerosControlPaneles()
   End Function
   'GET ENTIDAD
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim PanelControl As Entidades.TableroControlPanel = New Entidades.TableroControlPanel()
      Dim r As Reglas.TablerosControlPaneles = New Reglas.TablerosControlPaneles()

      With Me.dgvDatos.ActiveCell.Row
         PanelControl.IdTableroControlPanel = Integer.Parse(.Cells("IdTableroControlPanel").Value.ToString())
         PanelControl = r.GetUno(PanelControl.IdTableroControlPanel)
      End With
      Return PanelControl
   End Function

   'IMPRIMIR
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
   End Sub

   'FORMATEAR GRILLA
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.TableroControlPanel.Columnas.IdTableroControlPanel.ToString()).FormatearColumna("Código", col, 80, HAlign.Center)
         .Columns(Entidades.TableroControlPanel.Columnas.NombrePanel.ToString()).FormatearColumna("Nombre", col, 250, HAlign.Left)

         .Columns(Entidades.TableroControlPanel.Columnas.BackColor1.ToString()).FormatearColumna("Color 1", col, 50, HAlign.Center)
         .Columns(Entidades.TableroControlPanel.Columnas.BackColor2.ToString()).FormatearColumna("Color 2", col, 50, HAlign.Center)

         .Columns(Entidades.TableroControlPanel.Columnas.IdController.ToString()).FormatearColumna("Controlador", col, 250, HAlign.Left)
         .Columns(Entidades.TableroControlPanel.Columnas.Parametros.ToString()).FormatearColumna("Parametros", col, 200, HAlign.Center)

         .Columns(Entidades.TableroControlPanel.Columnas.ForeColor1.ToString()).OcultoPosicion(True, col)
         .Columns(Entidades.TableroControlPanel.Columnas.ForeColor2.ToString()).OcultoPosicion(True, col)

      End With
   End Sub

#End Region

   Private Sub dgvDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      TryCatched(Sub()
                    Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)(e.Row)
                    If dr IsNot Nothing Then
                       Dim iBackColor1 = dr.Field(Of Integer?)(Entidades.TableroControlPanel.Columnas.BackColor1.ToString())
                       Dim iBackColor2 = dr.Field(Of Integer?)(Entidades.TableroControlPanel.Columnas.BackColor2.ToString())

                       Dim iForeColor1 = dr.Field(Of Integer?)(Entidades.TableroControlPanel.Columnas.ForeColor1.ToString())
                       Dim iForeColor2 = dr.Field(Of Integer?)(Entidades.TableroControlPanel.Columnas.ForeColor2.ToString())

                       Dim backColor1 = If(iBackColor1.HasValue, Color.FromArgb(iBackColor1.Value), Nothing)
                       Dim backColor2 = If(iBackColor2.HasValue, Color.FromArgb(iBackColor2.Value), Nothing)

                       Dim foreColor1 = If(iForeColor1.HasValue, Color.FromArgb(iForeColor1.Value), Nothing)
                       Dim foreColor2 = If(iForeColor2.HasValue, Color.FromArgb(iForeColor2.Value), Nothing)

                       e.Row.Cells(Entidades.TableroControlPanel.Columnas.BackColor1.ToString()).Color(foreColor1, backColor1)
                       e.Row.Cells(Entidades.TableroControlPanel.Columnas.BackColor2.ToString()).Color(foreColor2, backColor2)

                    End If
                 End Sub)
   End Sub

End Class