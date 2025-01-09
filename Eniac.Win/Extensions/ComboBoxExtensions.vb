Imports System.Runtime.CompilerServices
Namespace Extensiones
   Public Module ComboBoxExtensions
      <Extension>
      Public Function ItemSeleccionado(Of T)(cmb As ComboBox, chb As CheckBox) As T
         Return cmb.ItemSeleccionado(Of T)(chb.Checked)
      End Function
      <Extension>
      Public Function ItemSeleccionado(Of T)(cmb As ComboBox, checked As Boolean) As T
         If checked Then
            Return cmb.ItemSeleccionado(Of T)()
         End If
         Return Nothing
      End Function
      <Extension>
      Public Function ItemSeleccionado(Of T)(cmb As ComboBox) As T
         If cmb.SelectedIndex > -1 Then
            If TypeOf (cmb.SelectedItem) Is T Then
               Return DirectCast(cmb.SelectedItem, T)

            ElseIf TypeOf (cmb.SelectedItem) Is DataRowView AndAlso
                  DirectCast(cmb.SelectedItem, DataRowView).Row IsNot Nothing AndAlso
                  TypeOf (DirectCast(cmb.SelectedItem, DataRowView).Row) Is T Then
               Return DirectCast(Convert.ChangeType(DirectCast(cmb.SelectedItem, DataRowView).Row, GetType(T)), T)

            End If
         End If
         Return Nothing
      End Function
      <Extension>
      Public Function ValorSeleccionado(Of T)(cmb As ComboBox, chb As CheckBox, valorPorDefecto As T) As T
         Return cmb.ValorSeleccionado(chb.Checked, valorPorDefecto)
      End Function
      <Extension>
      Public Function ValorSeleccionado(Of T)(cmb As ComboBox, checked As Boolean, valorPorDefecto As T) As T
         If checked Then
            Return cmb.ValorSeleccionado(Of T)
         End If
         Return valorPorDefecto
      End Function
      <Extension>
      Public Function ValorSeleccionado(Of T)(cmb As ComboBox, valorPorDefecto As T) As T
         Return cmb.ValorSeleccionado(True, valorPorDefecto)
      End Function
      <Extension>
      Public Function ValorSeleccionado(Of T)(cmb As ComboBox) As T
         If cmb.SelectedIndex > -1 Then
            If TypeOf (cmb.SelectedValue) Is T Then
               Return DirectCast(cmb.SelectedValue, T)

            ElseIf TypeOf (cmb.SelectedValue) Is DataRowView AndAlso
                  DirectCast(cmb.SelectedValue, DataRowView).Row IsNot Nothing AndAlso
                  TypeOf (DirectCast(cmb.SelectedValue, DataRowView).Row) Is T Then
               Return DirectCast(Convert.ChangeType(DirectCast(cmb.SelectedValue, DataRowView).Row, GetType(T)), T)

            End If
         End If
         Return Nothing
      End Function

      <Extension>
      Public Function SetValorPredeterminado(Of T)(cmb As ComboBox, predicate As Func(Of T, Boolean)) As T
         Dim col As IList(Of T)
         Try
            col = DirectCast(cmb.DataSource, IList(Of T))
         Catch ex As InvalidCastException
            Throw New Exception(String.Format("Error en SetValorPredeterminado al castear la colección del combo: {0}. Excepción: {1}",
                                              cmb.Name, ex.Message, GetType(IList(Of T)).Name), ex)
         End Try

         Dim def = col.FirstOrDefault(predicate)
         If def IsNot Nothing Then
            cmb.SelectedItem = def
         Else
            cmb.SelectedIndex = -1
         End If

         Return def
      End Function

      <Extension>
      Public Function SelectedIndexIfAny(cmb As ComboBox, index As Integer) As ComboBox
         cmb.SelectedIndex = If(cmb.Items.Count = 0, -1, index)
         Return cmb
      End Function

      <Extension>
      Public Function ExistsItem(Of T)(cmb As ComboBox, itemToFind As T) As Boolean
         Return cmb.Items.OfType(Of T).Any(Function(i) i.Equals(itemToFind))
      End Function
      <Extension>
      Public Function Any(cmb As ComboBox) As Boolean
         Return cmb.Items.Count > 0
      End Function

      <Extension>
      Public Function SetSelectedIndexSecure(cmb As ComboBox, index As Integer) As ComboBox
         If cmb.Items.Count > index Then
            cmb.SelectedIndex = index
         End If
         Return cmb
      End Function

   End Module
End Namespace