Option Strict On
Option Explicit On
Public Class Traducciones
   Private Shared _idioma As String
   Private Shared _aplicacion As String

   Private Shared _traducciones As DataTable
   'Private Shared _pantalla As BaseForm

   Public Shared Sub Cargar()
      Dim tra As Reglas.Traducciones = New Reglas.Traducciones()

      _idioma = "es_AR"
      _aplicacion = Publicos.IDAplicacionSinergia

      _traducciones = tra.GetPorIdioma(_idioma)
   End Sub

   Public Shared Sub SetearControles(ByVal pantalla As BaseForm)
      If _traducciones IsNot Nothing Then
         '_pantalla = pantalla
         SetearValores(pantalla)
      End If
   End Sub

   Public Shared Function TraducirTexto(textoOriginal As String, pantalla As BaseForm, control As String) As String
      Return TraducirTexto(textoOriginal, pantalla.IdFuncion, pantalla.Name, control)
   End Function
   Public Shared Function TraducirTexto(textoOriginal As String, control As String) As String
      Return TraducirTexto(textoOriginal, String.Empty, String.Empty, control)
   End Function

   Private Shared Function TraducirTexto(textoOriginal As String, idFuncion As String, idPantalla As String, control As String) As String
      Dim texto As String
      texto = GetTexto(idFuncion, idPantalla, control)
      If texto Is Nothing Then
         texto = textoOriginal
      End If
      Return texto
   End Function


   Private Shared Sub SetearValores(pantalla As BaseForm)
      Dim texto As String = GetTexto(pantalla.IdFuncion, pantalla.Name, "Me")
      If texto IsNot Nothing Then
         pantalla.Text = texto
      End If

      SetearValores(pantalla, pantalla.Controls)
   End Sub

   Private Shared Sub SetearValores(pantalla As BaseForm, controls As Control.ControlCollection)
      'Setea los controles con su definición en el idioma
      For Each ctr As Control In controls
         If TypeOf ctr Is Infragistics.Win.UltraWinGrid.UltraGrid Then
            For Each banda As Infragistics.Win.UltraWinGrid.UltraGridBand In DirectCast(ctr, Infragistics.Win.UltraWinGrid.UltraGrid).DisplayLayout.Bands
               For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In banda.Columns
                  SeteaTextoColumna(pantalla, col)
               Next
            Next
         ElseIf TypeOf ctr Is DataGridView Then
            For Each col As DataGridViewColumn In DirectCast(ctr, DataGridView).Columns
               SeteaTextoColumna(pantalla, col)
            Next
         ElseIf TypeOf ctr Is ToolStrip Then
            For Each item As ToolStripItem In DirectCast(ctr, ToolStrip).Items
               SeteaTextoColumna(pantalla, item)
            Next
         ElseIf TypeOf ctr Is WebBrowser Then
            'Estos controles no los traducimos.
         Else
            If ctr.Controls.Count > 0 Then
               SetearValores(pantalla, ctr.Controls)
            Else
               SeteaTexto(pantalla, ctr)
            End If
         End If
      Next
   End Sub

   Private Shared Function GetTexto(idFuncion As String, pantalla As String, control As String) As String
      Dim drCol As DataRow()
      drCol = _traducciones.Select(String.Format("{0} = '{1}'", Entidades.Traduccion.Columnas.Control.ToString(), control))
      'Si no hay ninguna traducción para este control no continuo buscando y retorno el texto actual.
      If drCol.Length = 0 Then
         Return Nothing
      Else
         drCol = _traducciones.Select(String.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'",
                                                    Entidades.Traduccion.Columnas.IdFuncion.ToString(), idFuncion,
                                                    Entidades.Traduccion.Columnas.Pantalla.ToString(), pantalla,
                                                    Entidades.Traduccion.Columnas.Control.ToString(), control))
         'Busco si hay una traducción para la Función/Pantalla específicas
         If drCol.Length > 0 Then
            Return drCol(0)(Entidades.Traduccion.Columnas.Texto.ToString()).ToString()
         Else
            'Si no encontró, busco si hay una traducción para la función sin importar la pantalla
            drCol = _traducciones.Select(String.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'",
                                                       Entidades.Traduccion.Columnas.IdFuncion.ToString(), idFuncion,
                                                       Entidades.Traduccion.Columnas.Pantalla.ToString(), String.Empty,
                                                       Entidades.Traduccion.Columnas.Control.ToString(), control))
            If drCol.Length > 0 Then
               Return drCol(0)(Entidades.Traduccion.Columnas.Texto.ToString()).ToString()
            Else
               'Si no encontró, busco si hay una traducción para la aplcación (sin importar la función) pero para la pantalla específica
               drCol = _traducciones.Select(String.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'",
                                                          Entidades.Traduccion.Columnas.IdFuncion.ToString(), _aplicacion,
                                                          Entidades.Traduccion.Columnas.Pantalla.ToString(), pantalla,
                                                          Entidades.Traduccion.Columnas.Control.ToString(), control))
               If drCol.Length > 0 Then
                  Return drCol(0)(Entidades.Traduccion.Columnas.Texto.ToString()).ToString()
               Else
                  'Si no encontró, busco si hay una traducción para la aplcación (sin importar la función) y sin importar la pantalla
                  drCol = _traducciones.Select(String.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'",
                                                             Entidades.Traduccion.Columnas.IdFuncion.ToString(), _aplicacion,
                                                             Entidades.Traduccion.Columnas.Pantalla.ToString(), String.Empty,
                                                             Entidades.Traduccion.Columnas.Control.ToString(), control))
                  If drCol.Length > 0 Then
                     Return drCol(0)(Entidades.Traduccion.Columnas.Texto.ToString()).ToString()
                  Else
                     'Si no encontré ninguna traducción (raro porque lo controlo al comienzo) retorno el texto actual.
                     Return Nothing
                  End If
               End If
            End If
         End If
      End If
   End Function

   Private Shared Sub SeteaTexto(pantalla As BaseForm, control As Control)
      Dim texto As String = GetTexto(pantalla.IdFuncion, pantalla.Name, control.Name)
      If texto IsNot Nothing Then
         control.Text = texto
      End If
   End Sub

   Private Shared Sub SeteaTextoColumna(pantalla As BaseForm, column As Infragistics.Win.UltraWinGrid.UltraGridColumn)
      Dim texto As String = GetTexto(pantalla.IdFuncion, pantalla.Name, column.Key)
      If texto IsNot Nothing Then
         column.Header.Caption = texto
      End If
   End Sub

   Private Shared Sub SeteaTextoColumna(pantalla As BaseForm, column As DataGridViewColumn)
      Dim texto As String = GetTexto(pantalla.IdFuncion, pantalla.Name, column.Name)
      If texto IsNot Nothing Then
         column.HeaderText = texto
      End If
   End Sub

   Private Shared Sub SeteaTextoColumna(pantalla As BaseForm, item As ToolStripItem)
      Dim texto As String = GetTexto(pantalla.IdFuncion, pantalla.Name, item.Name)
      If texto IsNot Nothing Then
         item.Text = texto
      End If
   End Sub
End Class