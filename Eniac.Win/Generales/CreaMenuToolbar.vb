#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class CreaMenuToolbar

   Private _mnsPrincipal As MenuStrip
   Private _tlsPrincipal As ToolStrip
   Private _cargaPantallasBoton As EventHandler
   Private _cargaPantallas As EventHandler
   Private _abrirMonitorParametros As EventHandler
   Private _container As Form

   Private _menusCargados As Dictionary(Of String, ToolStripMenuItem) = New Dictionary(Of String, ToolStripMenuItem)()

#Region "Constantes"
   Private Const CamposIsNullFormat As String = "{0} IS NULL"
   Private Const CamposIgualStringFormat As String = "{0} = '{1}'"
   Private Const CamposNotBooleanFormat As String = "Not {0}"

   Private Const PrefijoParaMenu As String = "tsm_"
   Private Const PrefijoParaBoton As String = "tsb"
#End Region

   Private Enum ColumnasDataTable
      Id
      Nombre
      EsMenu
      Descripcion
      Enabled
      Visible
      EsBoton
      Archivo
      Pantalla
      IdPadre
      Icono
      Procesado
   End Enum

   Public Sub Crear(container As Form, mnsPrincipal As MenuStrip, tlsPrincipal As ToolStrip, cargaPantallas As EventHandler, cargaPantallasBoton As EventHandler, abrirMonitorParametros As EventHandler)
      Crear(container, mnsPrincipal, tlsPrincipal, cargaPantallas, cargaPantallasBoton, AbrirMonitorParametros, actual.Nombre, actual.Sucursal.Id)
   End Sub
   Public Sub Crear(container As Form, mnsPrincipal As MenuStrip, tlsPrincipal As ToolStrip, cargaPantallas As EventHandler, cargaPantallasBoton As EventHandler, abrirMonitorParametros As EventHandler, idUsuario As String, idSucursal As Integer)
      Try
         Me._container = container
         Me._mnsPrincipal = mnsPrincipal
         Me._tlsPrincipal = tlsPrincipal

         Me._cargaPantallas = cargaPantallas
         Me._cargaPantallasBoton = cargaPantallasBoton
         Me._abrirMonitorParametros = abrirMonitorParametros

         Using dtItemMenu As DataTable = New Eniac.Reglas.Usuarios().ObtenerFuncionesParaMenu(idUsuario, idSucursal)
            For Each dr As DataRow In dtItemMenu.Select(String.Format(CamposIsNullFormat, ColumnasDataTable.IdPadre.ToString()))
               If Boolean.Parse(dr(ColumnasDataTable.EsMenu.ToString()).ToString()) Then
                  Dim menuPadre As ToolStripMenuItem = CrearItemMenu(dr, padre:=Nothing)

                  AgregarOpcionesHijo(menuPadre, dtItemMenu.Select(String.Format(CamposIgualStringFormat, ColumnasDataTable.IdPadre.ToString(), dr(ColumnasDataTable.Id.ToString()))), dtItemMenu)
               End If
               If Boolean.Parse(dr(ColumnasDataTable.EsBoton.ToString()).ToString()) Then
                  Me.CrearBoton(dr)
               End If

               dr(ColumnasDataTable.Procesado.ToString()) = True
            Next

            AgregaOpcionesFijas()
         End Using
      Finally
         Me._mnsPrincipal = Nothing
         Me._tlsPrincipal = Nothing

         Me._cargaPantallas = Nothing
         Me._cargaPantallasBoton = Nothing
      End Try
   End Sub

   Private Sub AgregaOpcionesFijas()
      Dim ixMenuAyuda As Integer = _mnsPrincipal.Items.IndexOfKey("tsm_Ayuda")

      'Crea el itemMenu Ventanas de la aplicación
      Dim mnuVentanas As System.Windows.Forms.ToolStripMenuItem = _
      New System.Windows.Forms.ToolStripMenuItem("Ventanas")
      mnuVentanas.Name = "tsm_Ventanas"
      mnuVentanas.Size = New System.Drawing.Size(161, 22)
      If ixMenuAyuda > -1 Then
         _mnsPrincipal.Items.Insert(ixMenuAyuda, mnuVentanas)
      Else
         _mnsPrincipal.Items.Add(mnuVentanas)
      End If
      _mnsPrincipal.MdiWindowListItem = mnuVentanas

      mnuVentanas.DropDownItems.Add("&Cascada", Nothing, Sub(sender, e) _container.LayoutMdi(MdiLayout.Cascade))
      mnuVentanas.DropDownItems.Add("&Vertical", Nothing, Sub(sender, e) _container.LayoutMdi(MdiLayout.TileVertical))
      mnuVentanas.DropDownItems.Add("&Horizontal", Nothing, Sub(sender, e) _container.LayoutMdi(MdiLayout.TileHorizontal))
      mnuVentanas.DropDownItems.Add("Cerrar &Todas", Nothing, Sub(sender, e)
                                                                 For Each ChildForm As Form In _container.MdiChildren
                                                                    ChildForm.Close()
                                                                 Next
                                                              End Sub)

      'Crea el itemMenu About de la aplicación
      If ixMenuAyuda = -1 Then
         Dim mnuAyuda As ToolStripMenuItem = New ToolStripMenuItem("Ayuda")
         mnuAyuda.Name = "tsm_Ayuda"
         mnuAyuda.Size = New System.Drawing.Size(161, 22)
         mnuAyuda.DropDownItems.Add("Acerca de Sinergia...", Nothing, Sub(sender, e)
                                                                         Using fr As Eniac.Win.BaseAbout = New Eniac.Win.BaseAbout()
                                                                            'fr.MdiParent = _container
                                                                            fr.ShowDialog(_container)
                                                                         End Using
                                                                      End Sub).Name = "tsm_about"
         _mnsPrincipal.Items.Add(mnuAyuda)

      End If

      ixMenuAyuda = _mnsPrincipal.Items.IndexOfKey("tsm_Ayuda")

      Dim itemMenuAyuda As ToolStripMenuItem = DirectCast(_mnsPrincipal.Items(ixMenuAyuda), ToolStripMenuItem)
      itemMenuAyuda.DropDownItems.Add("Vincular Dispositivo", Nothing,
                                      Sub(sender As Object, e As EventArgs)
                                         Dim fr As Eniac.Win.VincularDispositivos = New Eniac.Win.VincularDispositivos()
                                         fr.MdiParent = _container
                                         fr.Show()
                                      End Sub)

      itemMenuAyuda.DropDownItems.Add("Mostrar Monitor de Parámetros", Nothing, Sub(sender, e) _abrirMonitorParametros(sender, e))

      'Crea el itemMenu Salir de la aplicación
      _mnsPrincipal.Items.Add("-")
      _mnsPrincipal.Items.Add("&Salir", My.Resources._stop, Sub(sender, e)
                                                               _container.Close()
                                                            End Sub)

   End Sub

   Private Sub AgregarOpcionesHijo(menuPadre As ToolStripMenuItem, drHijosCol As DataRow(), dtItemMenu As DataTable)
      For Each drHijo As DataRow In drHijosCol
         If Boolean.Parse(drHijo(ColumnasDataTable.EsMenu.ToString()).ToString()) Then
            Dim nuevoMenuPadre As ToolStripMenuItem = CrearItemMenu(drHijo, menuPadre)
            Dim drNuevosHijosCol As DataRow() = dtItemMenu.Select(String.Format(CamposIgualStringFormat, ColumnasDataTable.IdPadre.ToString(), drHijo(ColumnasDataTable.Id.ToString())))
            If drNuevosHijosCol.Length > 0 Then
               AgregarOpcionesHijo(nuevoMenuPadre, drNuevosHijosCol, dtItemMenu)
            End If
         End If
         If Boolean.Parse(drHijo(ColumnasDataTable.EsBoton.ToString()).ToString()) Then
            Me.CrearBoton(drHijo)
         End If
         drHijo(ColumnasDataTable.Procesado.ToString()) = True
      Next
   End Sub

   Private Function CrearItemMenu(dr As DataRow, padre As ToolStripMenuItem) As ToolStripMenuItem
      Dim mnuMenu As ToolStripMenuItem = New ToolStripMenuItem(dr(ColumnasDataTable.Id.ToString()).ToString(), Nothing, If(padre Is Nothing, Nothing, _cargaPantallas))
      mnuMenu.Name = KeyParaMenu(dr)
      mnuMenu.Text = dr(ColumnasDataTable.Nombre.ToString()).ToString()
      mnuMenu.Enabled = Boolean.Parse(dr(ColumnasDataTable.Enabled.ToString()).ToString())
      mnuMenu.Visible = Boolean.Parse(dr(ColumnasDataTable.Visible.ToString()).ToString())
      mnuMenu.Size = New System.Drawing.Size(161, 22)

      If padre IsNot Nothing Then
         mnuMenu.Image = Me.GetImagen(dr)
         mnuMenu.ToolTipText = dr(ColumnasDataTable.Descripcion.ToString()).ToString()
         mnuMenu.Tag = dr
         padre.DropDownItems.Add(mnuMenu)
      Else
         _mnsPrincipal.Items.Add(mnuMenu)
      End If

      _menusCargados.Add(mnuMenu.Name, mnuMenu)

      Return mnuMenu
   End Function

   Private Function CrearBoton(dr As DataRow) As ToolStripButton
      Dim tsbBoton As ToolStripButton = New ToolStripButton(dr(ColumnasDataTable.Id.ToString()).ToString(), Nothing, _cargaPantallasBoton)
      tsbBoton.ImageTransparentColor = System.Drawing.Color.Magenta
      tsbBoton.ToolTipText = dr(ColumnasDataTable.Descripcion.ToString()).ToString()
      tsbBoton.Name = KeyParaBoton(dr)
      tsbBoton.Text = dr(ColumnasDataTable.Nombre.ToString()).ToString()
      tsbBoton.Enabled = Boolean.Parse(dr(ColumnasDataTable.Enabled.ToString()).ToString())
      tsbBoton.Visible = Boolean.Parse(dr(ColumnasDataTable.Visible.ToString()).ToString())
      tsbBoton.Tag = dr
      tsbBoton.Image = Me.GetImagen(dr)
      tsbBoton.Size = New System.Drawing.Size(65, 22)
      Me._tlsPrincipal.Items.Add(tsbBoton)
      Return tsbBoton
   End Function

   Private Function KeyParaMenu(dr As DataRow) As String
      Return String.Concat(PrefijoParaMenu, dr(ColumnasDataTable.Id.ToString()).ToString())
   End Function
   'Private Function KeyParaMenuPadre(dr As DataRow) As String
   '   Return String.Concat(PrefijoParaMenu, dr(ColumnasDataTable.IdPadre.ToString()).ToString())
   'End Function
   Private Function KeyParaBoton(dr As DataRow) As String
      Return String.Concat(PrefijoParaBoton, dr(ColumnasDataTable.IdPadre.ToString()).ToString())
   End Function

   Private Function GetImagen(dr As DataRow) As Bitmap
      Try
         If Not dr.IsNull(ColumnasDataTable.Icono.ToString()) Then
            Using stream As System.IO.MemoryStream = New System.IO.MemoryStream(DirectCast(dr(ColumnasDataTable.Icono.ToString()), Byte()))
               Return New Bitmap(stream)
            End Using
         End If
      Catch
      End Try
      Return Nothing
   End Function
End Class