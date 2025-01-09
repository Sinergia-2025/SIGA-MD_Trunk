Imports Eniac.Win

Public Class CartasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbNuevo.Visible = True
      Me.tsbBorrar.Visible = False
      Me.tsbImprimir.Visible = False

   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CartasDetalle(DirectCast(Me.GetEntidad(), Entidades.Carta))
      End If
      Return New CartasDetalle(New Entidades.Carta)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Cartas()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim oCarta As Entidades.Carta = New Entidades.Carta

      With Me.dgvDatos.ActiveCell.Row
         oCarta = New Reglas.Cartas().GetUno(Int32.Parse(.Cells(Entidades.Carta.Columnas.IdCarta.ToString()).Value.ToString()))
      End With

      Return oCarta

   End Function

   Public Function toRTF(ByVal texto As String) As String
      'Vuelve a transformar la comilla guardada el SQL SERVER (lo usa x ejemplo en los acentos)
      Return texto.Replace(Chr(34), "'")
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      'Try
      '   Me.Cursor = Cursors.WaitCursor
      '   Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Personal.Win.Datos.rdlc", "Dominios_Datos", Me.dtDatos)
      '   frmImprime.Text = ""
      '   frmImprime.Show()
      '   Me.Cursor = Cursors.Default
      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try
   End Sub

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)

         'IdCarta
         .Columns(Entidades.Carta.Columnas.IdCarta.ToString()).Header.Caption = "Id"
         .Columns(Entidades.Carta.Columnas.IdCarta.ToString()).Width = 70
         .Columns(Entidades.Carta.Columnas.IdCarta.ToString()).CellAppearance.TextHAlign = HAlign.Right

         'NombreCarta
         .Columns(Entidades.Carta.Columnas.NombreCarta.ToString()).Header.Caption = "Nombre"
         .Columns(Entidades.Carta.Columnas.NombreCarta.ToString()).Width = 150

         'DiasDefault
         .Columns(Entidades.Carta.Columnas.DiasDefault.ToString()).Header.Caption = "Dias"
         .Columns(Entidades.Carta.Columnas.DiasDefault.ToString()).Width = 70
         .Columns(Entidades.Carta.Columnas.DiasDefault.ToString()).CellAppearance.TextHAlign = HAlign.Right

         'ProximaCarta
         .Columns(Entidades.Carta.Columnas.ProximaCarta.ToString()).Header.Caption = "Prox."
         .Columns(Entidades.Carta.Columnas.ProximaCarta.ToString()).Width = 70
         .Columns(Entidades.Carta.Columnas.ProximaCarta.ToString()).CellAppearance.TextHAlign = HAlign.Right

         'Texto
         .Columns(Entidades.Carta.Columnas.Texto.ToString()).Header.Caption = "Texto - Parte 1"
         .Columns(Entidades.Carta.Columnas.Texto.ToString()).Width = 200

         'Texto2
         .Columns(Entidades.Carta.Columnas.Texto2.ToString()).Header.Caption = "Texto - Parte 2"
         .Columns(Entidades.Carta.Columnas.Texto2.ToString()).Width = 200

         'TextoRTF
         .Columns(Entidades.Carta.Columnas.TextoRTF.ToString()).Hidden = True

         'Texto2RTF
         .Columns(Entidades.Carta.Columnas.Texto2RTF.ToString()).Hidden = True

         'Firma
         .Columns(Entidades.Carta.Columnas.Firma.ToString()).Header.Caption = "Firma"
         .Columns(Entidades.Carta.Columnas.Firma.ToString()).Width = 150

         .Columns(Entidades.Carta.Columnas.MiraAnoEnCurso.ToString()).Header.Caption = "Año en Curso"
         .Columns(Entidades.Carta.Columnas.MiraAnoEnCurso.ToString()).Width = 60

         .Columns(Entidades.Carta.Columnas.EsHTML.ToString()).Header.Caption = "Mant.Formato"
         .Columns(Entidades.Carta.Columnas.EsHTML.ToString()).Width = 60

         'Tipo
         .Columns(Entidades.Carta.Columnas.Tipo.ToString()).Header.Caption = "Tipo"
         .Columns(Entidades.Carta.Columnas.Tipo.ToString()).Width = 100

      End With

   End Sub

#End Region

End Class