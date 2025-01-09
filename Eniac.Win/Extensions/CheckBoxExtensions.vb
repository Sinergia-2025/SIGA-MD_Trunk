#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports System.Runtime.CompilerServices
#End Region
Public Module CheckBoxExtensions
   <Extension>
   Public Function FiltroCheckedChanged(chb As Eniac.Controles.CheckBox, cmb As Eniac.Controles.ComboBox) As Eniac.Controles.CheckBox
      Return FiltroCheckedChanged(chb, cmb,
                                  Sub(cmb1)
                                     If cmb1.Items.Count > 0 Then
                                        cmb1.SelectedIndex = 0
                                     End If
                                  End Sub)
   End Function
   <Extension>
   Public Function FiltroCheckedChanged(chb As Eniac.Controles.CheckBox, cmb As Eniac.Controles.ComboBox, defaultValue As Object) As Eniac.Controles.CheckBox
      Return FiltroCheckedChanged(chb, cmb,
                                  Sub(cmb1)
                                     cmb1.SelectedValue = defaultValue
                                  End Sub)
   End Function
   <Extension>
   Public Function FiltroCheckedChanged(chb As Eniac.Controles.CheckBox, cmb As Eniac.Controles.ComboBox, defaultValue As Object, disableValue As Object) As Eniac.Controles.CheckBox
      Return FiltroCheckedChanged(chb, cmb,
                                  Sub(cmb1)
                                     cmb1.SelectedValue = defaultValue
                                  End Sub,
                                  Sub(cmb1)
                                     cmb.SelectedValue = disableValue
                                  End Sub)
   End Function
   <Extension>
   Public Function FiltroCheckedChanged(chb As Eniac.Controles.CheckBox, cmb As Eniac.Controles.ComboBox, accionDefaultValue As Action(Of Eniac.Controles.ComboBox)) As Eniac.Controles.CheckBox
      Return FiltroCheckedChanged(chb, cmb, accionDefaultValue,
                                  Sub(cmb1)
                                     cmb.SelectedIndex = -1
                                  End Sub)
   End Function
   Private Function FiltroCheckedChanged(chb As Eniac.Controles.CheckBox, cmb As Eniac.Controles.ComboBox, accionDefaultValue As Action(Of Eniac.Controles.ComboBox), accionDisable As Action(Of Eniac.Controles.ComboBox)) As Eniac.Controles.CheckBox
      cmb.Enabled = chb.Checked
      If chb.Checked Then
         accionDefaultValue(cmb)
         cmb.Select()
      Else
         accionDisable(cmb)   ' cmb.SelectedIndex = -1
      End If
      Return chb
   End Function

   <Extension>
   Public Function FiltroCheckedChanged(chb As Controles.CheckBox, txt As Controles.TextBox) As Eniac.Controles.CheckBox
      Return FiltroCheckedChanged(chb, txt, String.Empty, String.Empty)
   End Function
   <Extension>
   Public Function FiltroCheckedChanged(chb As Controles.CheckBox, txt As Controles.TextBox, defaultValue As String) As Eniac.Controles.CheckBox
      Return FiltroCheckedChanged(chb, txt, defaultValue, defaultValue)
   End Function
   <Extension>
   Public Function FiltroCheckedChanged(chb As Controles.CheckBox, txt As Controles.TextBox, defaultValue As String, disableValue As String) As Eniac.Controles.CheckBox
      Return FiltroCheckedChanged(chb, txt,
                                  Sub(txt1)
                                     txt1.Text = defaultValue
                                  End Sub,
                                  Sub(txt1)
                                     txt.Text = disableValue
                                  End Sub)
   End Function
   Private Function FiltroCheckedChanged(chb As Controles.CheckBox, txt As Controles.TextBox, accionDefaultValue As Action(Of Controles.TextBox), accionDisable As Action(Of Controles.TextBox)) As Controles.CheckBox
      txt.Enabled = chb.Checked
      If chb.Checked Then
         accionDefaultValue(txt)
         txt.Select()
      Else
         accionDisable(txt)   ' cmb.SelectedIndex = -1
      End If
      Return chb
   End Function

   <Extension>
   Public Function FiltroCheckedChanged(chb As Controles.CheckBox, chbMesCompleto As Controles.CheckBox, dtpDesde As Controles.DateTimePicker, dtpHasta As Controles.DateTimePicker) As Controles.CheckBox
      Return chb.FiltroCheckedChanged(chbMesCompleto, dtpDesde, dtpHasta, defaultDesde:=Date.Today, defaultHasta:=Date.Today.UltimoSegundoDelDia())
   End Function
   <Extension>
   Public Function FiltroCheckedChanged(chb As Controles.CheckBox, dtpDesde As Controles.DateTimePicker, dtpHasta As Controles.DateTimePicker) As Controles.CheckBox
      Return chb.FiltroCheckedChanged(dtpDesde, dtpHasta, defaultDesde:=Date.Today, defaultHasta:=Date.Today.UltimoSegundoDelDia())
   End Function
   <Extension>
   Public Function FiltroCheckedChanged(chb As Controles.CheckBox, dtpDesde As Controles.DateTimePicker, dtpHasta As Controles.DateTimePicker,
                                        defaultDesde As Date, defaultHasta As Date) As Controles.CheckBox
      dtpDesde.Enabled = chb.Checked
      dtpHasta.Enabled = chb.Checked

      If chb.Checked Then
         dtpDesde.Value = defaultDesde
         dtpHasta.Value = defaultHasta
      End If
      dtpDesde.Focus()

      Return chb
   End Function
   <Extension>
   Public Function FiltroCheckedChanged(chb As Controles.CheckBox, chbMesCompleto As Controles.CheckBox, dtpDesde As Controles.DateTimePicker, dtpHasta As Controles.DateTimePicker,
                                        defaultDesde As Date, defaultHasta As Date) As Controles.CheckBox
      chb.FiltroCheckedChanged(dtpDesde, dtpHasta, defaultDesde, defaultHasta)
      chbMesCompleto.Enabled = chb.Checked
      If chb.Checked Then
         chbMesCompleto.Checked = False
      End If

      Return chb
   End Function

   <Extension>
   Public Function FiltroCheckedChangedMesCompleto(chb As Eniac.Controles.CheckBox, dtpDesde As Eniac.Controles.DateTimePicker, dtpHasta As Eniac.Controles.DateTimePicker) As Eniac.Controles.CheckBox
      Return FiltroCheckedChangedMesCompleto(chb, dtpDesde, dtpHasta, True)
   End Function
   <Extension>
   Public Function FiltroCheckedChangedMesCompleto(chb As Eniac.Controles.CheckBox, dtpDesde As Eniac.Controles.DateTimePicker, dtpHasta As Eniac.Controles.DateTimePicker, ultimoSegundo As Boolean) As Eniac.Controles.CheckBox
      If chb.Checked Then
         dtpDesde.Value = dtpDesde.Value.PrimerDiaMes()
         dtpHasta.Value = dtpDesde.Value.UltimoDiaMes(ultimoSegundo)
      End If

      dtpDesde.Enabled = Not chb.Checked
      dtpHasta.Enabled = Not chb.Checked

      Return chb
   End Function


   <Extension>
   Public Function FiltroCheckedChanged(chb As Eniac.Controles.CheckBox, ParamArray buscadores() As Eniac.Controles.Buscador2) As Eniac.Controles.CheckBox
      Return chb.FiltroCheckedChanged(usaPermitido:=False, buscadores)
   End Function

   <Extension>
   Public Function FiltroCheckedChanged(chb As Eniac.Controles.CheckBox, usaPermitido As Boolean, ParamArray buscadores() As Eniac.Controles.Buscador2) As Eniac.Controles.CheckBox
      For Each bsc As Controles.Buscador2 In buscadores
         If usaPermitido Then
            bsc.Permitido = chb.Checked
            bsc.Text = String.Empty
            bsc.Tag = Nothing
         Else
            bsc.Enabled = chb.Checked
         End If
         '  If chb.Checked Then
         bsc.Text = String.Empty
         bsc.Tag = Nothing
         '  End If
      Next
      If buscadores.Length > 0 Then
         buscadores(0).Focus()
      End If
      Return chb
   End Function

   <Extension>
   Public Function FiltroCheckedChanged(chb As Controles.CheckBox, ParamArray buscadores() As Controles.Buscador) As Controles.CheckBox
      Return chb.FiltroCheckedChanged(usaPermitido:=True, buscadores)
   End Function

   <Extension>
   Public Function FiltroCheckedChanged(chb As Controles.CheckBox, usaPermitido As Boolean, ParamArray buscadores() As Controles.Buscador) As Controles.CheckBox
      For Each bsc As Controles.Buscador In buscadores
         If usaPermitido Then
            bsc.Permitido = chb.Checked
            bsc.Enabled = True
         Else
            bsc.Enabled = chb.Checked
            bsc.Permitido = True
         End If
         'If chb.Checked Then
         bsc.Text = String.Empty
         bsc.Tag = Nothing
         'End If
      Next
      If buscadores.Length > 0 Then
         buscadores(0).Focus()
      End If
      Return chb
   End Function

   <Extension()>
   Public Function ToStringEspañol(chb As Controles.CheckBox) As String
      Return chb.Checked.ToStringEspañol()
   End Function


End Module