'Imports Eniac.Controles

Public Class BaseDetalle2

#Region "Campos"

   Public StateForm As StateForm
   Protected _entidad As Entidades.Entidad
   Protected _tituloNuevo As String = "Nuevo"
   Protected _tituloEditar As String = "Editar"
   Protected _tituloConsultar As String = "Consultar"
   Protected _aceptarOk As Boolean = True
   Protected _liSources As Generic.Dictionary(Of String, Eniac.Entidades.Entidad)
   Public HayError As Boolean
   Private _esCopia As Boolean = False
   Protected _estoyAplicando As Boolean = False

#End Region

#Region "Propiedades"

   Private _cierraAutomaticamente As Boolean = False
   Public Property CierraAutomaticamente() As Boolean
      Get
         Return _cierraAutomaticamente
      End Get
      Set(ByVal value As Boolean)
         _cierraAutomaticamente = value
      End Set
   End Property

   Private _ultimaEntidadUsada As Entidades.Entidad
   Public Property UltimaEntidadUsada() As Entidades.Entidad
      Get
         Return _ultimaEntidadUsada
      End Get
      Set(ByVal value As Entidades.Entidad)
         _ultimaEntidadUsada = value
      End Set
   End Property

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      If Me.StateForm = Win.StateForm.Insertar Then
         Me.Text = _tituloNuevo + " " + Me.Text
      ElseIf StateForm = Win.StateForm.Actualizar Then
         Me.Text = _tituloEditar + " " + Me.Text
      ElseIf StateForm = Win.StateForm.Consultar Then
         Me.Text = _tituloConsultar + " " + Me.Text
         btnAceptar.Visible = False
         btnAplicar.Visible = False
         btnCopiar.Visible = False
      End If
      Me._liSources = New Generic.Dictionary(Of String, Eniac.Entidades.Entidad)()
      Me.SeteosDeControles()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Me.Close()
   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      Try
         If StateForm = Win.StateForm.Consultar Then Return
         Me.Aceptar()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnCopiar_Click(sender As Object, e As EventArgs) Handles btnCopiar.Click
      Try
         If StateForm = Win.StateForm.Consultar Then Return
         _esCopia = True
         Me.Aceptar()
      Catch ex As Exception
         ShowError(ex)
      Finally
         _esCopia = False
      End Try

   End Sub

#End Region

#Region "Metodos"

   Protected Sub LimpiarControl(ByVal control As Control)
      If TypeOf control Is Eniac.Controles.TextBox Or TypeOf control Is Eniac.Controles.MaskedTextBox Then
         control.Text = ""
      End If
      If TypeOf control Is Eniac.Controles.ComboBox Then
         Dim com As Eniac.Controles.ComboBox = DirectCast(control, Eniac.Controles.ComboBox)
         'En algunos ABMs hay combos que no se cargan con items. Ejemplo: Productos, el combo de formula para aquellos productos que no tienen receta.
         If com.Items.Count > 0 Then
            com.SelectedIndex = 0
         End If
         com.Text = String.Empty
         com.SelectedItem = Nothing
         com.SelectedText = String.Empty
      End If
      If TypeOf control Is Eniac.Controles.DateTimePicker Then
         DirectCast(control, Eniac.Controles.DateTimePicker).Value = DateTime.Now
      End If
      If TypeOf control Is Eniac.Controles.CheckBox Then
         DirectCast(control, Eniac.Controles.CheckBox).Checked = False
      End If
   End Sub

   Protected Sub SeteosDeControles()
      Dim conf As Configurar = New Configurar
      For Each cr As Control In Me.Controls
         If TypeOf cr Is System.Windows.Forms.GroupBox Then
            For Each cr1 As Control In cr.Controls
               conf.SetearControl(cr1, Me.StateForm)
            Next
         ElseIf TypeOf cr Is TabControl Then
            For Each ctr0 As Control In cr.Controls
               If TypeOf ctr0 Is TabPage Then
                  For Each ctr1 As Control In ctr0.Controls
                     If TypeOf ctr1 Is GroupBox Then
                        For Each ctr2 As Control In ctr1.Controls
                           conf.SetearControl(ctr2, Me.StateForm)
                        Next
                     Else
                        conf.SetearControl(ctr1, Me.StateForm)
                     End If
                  Next
               End If
            Next
         Else
            conf.SetearControl(cr, Me.StateForm)
         End If
      Next
   End Sub

   Protected Function ValidarControles() As String
      Dim resultado As String = ""
      Dim conf As Configurar = New Configurar
      For Each cr As Control In Me.Controls
         If TypeOf cr Is System.Windows.Forms.GroupBox Then
            For Each cr1 As Control In cr.Controls
               If TypeOf cr1 Is System.Windows.Forms.GroupBox Then
                  For Each cr2 As Control In cr1.Controls
                     resultado += conf.ValidarControl(cr2)
                  Next
               Else
                  resultado += conf.ValidarControl(cr1)
               End If
            Next
         ElseIf TypeOf cr Is TabControl Then
            For Each ctr0 As Control In cr.Controls
               If TypeOf ctr0 Is TabPage Then
                  For Each ctr1 As Control In ctr0.Controls
                     If TypeOf ctr1 Is GroupBox Then
                        For Each ctr2 As Control In ctr1.Controls
                           If TypeOf ctr2 Is GroupBox Then
                              For Each ctr3 As Control In ctr2.Controls
                                 resultado += conf.ValidarControl(ctr3)
                              Next
                           Else
                              resultado += conf.ValidarControl(ctr2)
                           End If
                        Next
                     Else
                        resultado += conf.ValidarControl(ctr1)
                     End If
                  Next
               End If
            Next
         ElseIf TypeOf cr Is Infragistics.Win.UltraWinTabControl.UltraTabControl Then
            For Each ctr0 As Infragistics.Win.UltraWinTabControl.UltraTab In DirectCast(cr, Infragistics.Win.UltraWinTabControl.UltraTabControl).Tabs
               For Each ctr1 As Control In ctr0.TabPage.Controls
                  If TypeOf ctr1 Is GroupBox Then
                     For Each ctr2 As Control In ctr1.Controls
                        If TypeOf ctr2 Is GroupBox Then
                           For Each ctr3 As Control In ctr2.Controls
                              resultado += conf.ValidarControl(ctr3)
                           Next
                        Else
                           resultado += conf.ValidarControl(ctr2)
                        End If
                     Next
                  Else
                     resultado += conf.ValidarControl(ctr1)
                  End If
               Next
            Next
         Else
            resultado += conf.ValidarControl(cr)
         End If
      Next
      Return resultado
   End Function

   Public Sub BindearControles(ByVal dataSource As Eniac.Entidades.Entidad, ByVal dataSources As Generic.Dictionary(Of String, Eniac.Entidades.Entidad))
      'Bindea los controles contra un objeto
      For Each ctr As Control In Me.Controls
         If TypeOf ctr Is GroupBox Then
            For Each ctr1 As Control In ctr.Controls
               If TypeOf ctr1 Is GroupBox Then
                  For Each ctr2 As Control In ctr1.Controls
                     Me.BindeaControl(ctr2, dataSource, dataSources)
                  Next
               Else
                  Me.BindeaControl(ctr1, dataSource, dataSources)
               End If
            Next
         ElseIf TypeOf ctr Is TabControl Then
            For Each ctr0 As Control In ctr.Controls
               If TypeOf ctr0 Is TabPage Then
                  For Each ctr1 As Control In ctr0.Controls
                     If TypeOf ctr1 Is GroupBox Then
                        For Each ctr2 As Control In ctr1.Controls
                           If TypeOf ctr2 Is GroupBox Then
                              For Each ctr3 As Control In ctr2.Controls
                                 Me.BindeaControl(ctr3, dataSource, dataSources)
                              Next
                           Else
                              Me.BindeaControl(ctr2, dataSource, dataSources)
                           End If
                        Next
                     Else
                        Me.BindeaControl(ctr1, dataSource, dataSources)
                     End If
                  Next
               End If
            Next
         ElseIf TypeOf ctr Is Infragistics.Win.UltraWinTabControl.UltraTabControl Then
            For Each ctr0 As Infragistics.Win.UltraWinTabControl.UltraTab In DirectCast(ctr, Infragistics.Win.UltraWinTabControl.UltraTabControl).Tabs
               For Each ctr1 As Control In ctr0.TabPage.Controls
                  If TypeOf ctr1 Is GroupBox Then
                     For Each ctr2 As Control In ctr1.Controls
                        If TypeOf ctr2 Is GroupBox Then
                           For Each ctr3 As Control In ctr2.Controls
                              Me.BindeaControl(ctr3, dataSource, dataSources)
                           Next
                        Else
                           Me.BindeaControl(ctr2, dataSource, dataSources)
                        End If
                     Next
                  Else
                     Me.BindeaControl(ctr1, dataSource, dataSources)
                  End If
               Next
            Next
         Else
            Me.BindeaControl(ctr, dataSource, dataSources)
         End If
      Next
   End Sub

   Public Sub BindearControles(ByVal dataSource As Entidades.Entidad)
      'Bindea los controles contra un objeto
      For Each ctr As Control In Me.Controls
         If TypeOf ctr Is GroupBox Then
            For Each ctr1 As Control In ctr.Controls
               If TypeOf ctr1 Is GroupBox Then
                  For Each ctr2 As Control In ctr1.Controls
                     Me.BindeaControl(ctr2, dataSource)
                  Next
               Else
                  Me.BindeaControl(ctr1, dataSource)
               End If
            Next
         ElseIf TypeOf ctr Is TabControl Then
            For Each ctr0 As Control In ctr.Controls
               If TypeOf ctr0 Is TabPage Then
                  For Each ctr1 As Control In ctr0.Controls
                     If TypeOf ctr1 Is GroupBox Then
                        For Each ctr2 As Control In ctr1.Controls
                           Me.BindeaControl(ctr2, dataSource)
                        Next
                     Else
                        Me.BindeaControl(ctr1, dataSource)
                     End If
                  Next
               End If
            Next
         ElseIf TypeOf ctr Is Infragistics.Win.UltraWinTabControl.UltraTabControl Then
            For Each ctr0 As Infragistics.Win.UltraWinTabControl.UltraTab In DirectCast(ctr, Infragistics.Win.UltraWinTabControl.UltraTabControl).Tabs
               For Each ctr1 As Control In ctr0.TabPage.Controls
                  If TypeOf ctr1 Is GroupBox Then
                     For Each ctr2 As Control In ctr1.Controls
                        Me.BindeaControl(ctr2, dataSource)
                     Next
                  Else
                     Me.BindeaControl(ctr1, dataSource)
                  End If
               Next
            Next
         Else
            Me.BindeaControl(ctr, dataSource)
         End If
      Next
   End Sub

   Public Overloads Sub BindeaControl(ByVal control As Control, ByVal dataSource As Eniac.Entidades.Entidad)
      Dim val As String = String.Empty
      Try
         If TypeOf control Is Controles.IBindeos Then
            Dim ibin As Controles.IBindeos
            ibin = DirectCast(control, Controles.IBindeos)
            val = ibin.BindearPropiedadEntidad
            If Not (ibin.BindearPropiedadControl Is Nothing And ibin.BindearPropiedadEntidad Is Nothing) Then
               control.DataBindings.Add(New System.Windows.Forms.Binding(ibin.BindearPropiedadControl, dataSource, ibin.BindearPropiedadEntidad, True, DataSourceUpdateMode.OnPropertyChanged, Nothing))
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, "BINDEO " + val, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Public Overloads Sub BindeaControl(ByVal control As Control, ByVal dataSource As Eniac.Entidades.Entidad, ByVal dataSources As Generic.Dictionary(Of String, Eniac.Entidades.Entidad))
      Dim val As String = String.Empty
      Try
         If TypeOf control Is Controles.IBindeos Then
            Dim ibin As Controles.IBindeos
            ibin = DirectCast(control, Controles.IBindeos)
            val = ibin.BindearPropiedadEntidad
            If Not (String.IsNullOrEmpty(ibin.BindearPropiedadControl) And String.IsNullOrEmpty(ibin.BindearPropiedadEntidad)) Then
               If ibin.BindearPropiedadEntidad.IndexOf(".") <> -1 Then
                  Dim bind() As String = ibin.BindearPropiedadEntidad.Split("."c)
                  dataSource = dataSources(bind(0))
                  control.DataBindings.Add(New System.Windows.Forms.Binding(ibin.BindearPropiedadControl, dataSource, bind(1), True, DataSourceUpdateMode.OnPropertyChanged, Nothing))
               Else
                  control.DataBindings.Add(New System.Windows.Forms.Binding(ibin.BindearPropiedadControl, dataSource, ibin.BindearPropiedadEntidad, True, DataSourceUpdateMode.OnPropertyChanged, Nothing))
               End If
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, "BINDEO " + val, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Overridable"

   Protected Overridable Function GetReglas() As Reglas.Base
      Return New Reglas.Base()
   End Function

   Protected Overridable Function ValidarDetalle() As String
      Return ""
   End Function

   Protected Overridable Sub LimpiarControles()
      For Each ctr As Control In Me.Controls
         If TypeOf ctr Is System.Windows.Forms.GroupBox Then
            For Each ctr1 As Control In ctr.Controls
               If TypeOf ctr1 Is System.Windows.Forms.GroupBox Then
                  For Each ctr2 As Control In ctr1.Controls
                     Me.LimpiarControl(ctr2)
                  Next
               Else
                  Me.LimpiarControl(ctr1)
               End If
            Next
         ElseIf TypeOf ctr Is System.Windows.Forms.TabControl Then
            For Each cr As Control In ctr.Controls
               If TypeOf cr Is TabPage Then
                  For Each cr1 As Control In cr.Controls
                     If TypeOf cr1 Is GroupBox Then
                        For Each cr2 As Control In cr1.Controls
                           If TypeOf cr2 Is GroupBox Then
                              For Each cr3 As Control In cr2.Controls
                                 Me.LimpiarControl(cr3)
                              Next
                           Else
                              Me.LimpiarControl(cr2)
                           End If
                        Next
                     Else
                        Me.LimpiarControl(cr1)
                     End If
                  Next
               End If
            Next
         Else
            Me.LimpiarControl(ctr)
         End If
      Next
   End Sub

   Protected Overridable Function Validar() As Boolean
      Dim res As String
      res = Me.ValidarControles().Trim()
      Dim resValidarDetalle As String = Me.ValidarDetalle()
      If resValidarDetalle <> "" Then
         If res = "" Then
            res = resValidarDetalle
         Else
            res += Convert.ToChar(Keys.Enter) & Me.ValidarDetalle()
         End If
      End If

      If String.IsNullOrWhiteSpace(res) Then
         Return True       'Si no hay errores, devuelvo que Valida (True)
      Else
         MessageBox.Show(res, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False      'Si tengo acumulados mensajes de error, los muestro y digo que NO Valida (False)
      End If

   End Function

   Protected Overridable Function EjecutaInsertar(rg As Reglas.Base, en As Entidades.Entidad) As Entidades.Entidad
      rg.Insertar(Me._entidad)
      Return en
   End Function

   Protected Overridable Function EjecutaActualizar(rg As Reglas.Base, en As Entidades.Entidad) As Entidades.Entidad
      rg.Actualizar(Me._entidad)
      Return en
   End Function

   Protected Overridable Sub Aceptar()
      '   Aceptar(False)
      'End Sub
      'Protected Overridable Sub Aceptar(copia As Boolean)

      Me.HayError = False

      Try
         'Dim res As String
         'res = Me.ValidarControles().Trim()
         'If Me.ValidarDetalle() <> "" Then
         '   If res = "" Then
         '      res = Me.ValidarDetalle()
         '   Else
         '      res += Convert.ToChar(Keys.Enter) & Me.ValidarDetalle()
         '   End If
         'End If
         'If res = "" Then
         If Validar() Then       'Si Valida (True), significa que ni hubo errores, entoces ejecuto la regla.
            Dim oWS As Reglas.Base = Me.GetReglas()
            Me._entidad.Usuario = Eniac.Entidades.Usuario.Actual.Nombre
            'Inserto un registro
            If Me.StateForm = StateForm.Insertar Then
               EjecutaInsertar(oWS, Me._entidad)
               'oWS.Insertar(Me._entidad)
               MessageBox.Show("Se ingreso el registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               If Not _estoyAplicando Then
                  If _esCopia Then
                     LimpiaPantallaParaCopia(_entidad)
                  Else
                     If Not Me.HayError And Not Me.CierraAutomaticamente Then
                        Me.LimpiarControles()
                     End If
                  End If
               End If
            Else
               'Modifico un registro
               EjecutaActualizar(oWS, Me._entidad)
               'oWS.Actualizar(Me._entidad)
               MessageBox.Show("Se actualizo el registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               If Not _estoyAplicando Then
                  If _esCopia Then
                     LimpiaPantallaParaCopia(_entidad)
                  Else
                     Me.DialogResult = Windows.Forms.DialogResult.OK
                     Me.Close()
                  End If
               End If
            End If
         Else        'Si no Valida (False) pongo la bandera de que hay error (el método de validar se encarga de mostrar el mensaje)
            'MessageBox.Show(res, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.HayError = True
         End If
         If Not _estoyAplicando Then
            If Not _esCopia And Not Me.HayError And Me.CierraAutomaticamente Then
               Me.DialogResult = Windows.Forms.DialogResult.OK
               Me.Close()
            End If
         End If
      Catch exSql As System.Data.SqlClient.SqlException
         If exSql.Message.Contains("Cannot insert duplicate key in object") Then
         ElseIf exSql.Message.Contains("No puede insertar valores duplicados") Then 'este mensaje cambiarlo por el correcto
            MessageBox.Show("El código ingresado ya existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         ElseIf exSql.Message.Contains("Expire time") Then
            MessageBox.Show("Expiro el tiempo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         ElseIf exSql.Message.Contains("Time out") Then
            MessageBox.Show("Expiro el tiempo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(exSql.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
         Me.HayError = True
      Catch ex As Exception
         ShowError(ex)
         Me.HayError = True
      End Try
      If Not Me._estoyAplicando AndAlso Not _esCopia AndAlso Not Me.HayError Then
         Me.DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()
      End If

   End Sub

   Protected Overridable Sub LimpiaPantallaParaCopia(enActual As Entidades.Entidad)

   End Sub

#End Region


   Private Sub btnAplicar_Click(sender As Object, e As EventArgs) Handles btnAplicar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Aplicar()
      Catch ex As Exception
         ShowError(ex)
         Me.HayError = True
      Finally
         Me.Cursor = Cursors.Default
         Me._estoyAplicando = False
      End Try
   End Sub

   Private Sub Aplicar()
      If StateForm = Win.StateForm.Consultar Then Return
      Me._estoyAplicando = True
      Me.Aceptar()
      If Not Me.HayError Then
         Me.StateForm = Win.StateForm.Actualizar
         Me.Text.Replace(_tituloNuevo, _tituloEditar)
         Me.SeteosDeControles()
         OnAfterAplicar()
      End If
   End Sub

   Protected Overridable Sub OnAfterAplicar()

   End Sub

End Class

