Imports Eniac.Controles

Public Class SeleccionaAtributosProductos
   Implements ISeleccionaAtributosProductos
#Region "Campos"

   Public Property Atributo01 As New Entidades.AtributoProducto Implements ISeleccionaAtributosProductos.Atributo01
   Public Property Atributo02 As New Entidades.AtributoProducto Implements ISeleccionaAtributosProductos.Atributo02
   Public Property Atributo03 As New Entidades.AtributoProducto Implements ISeleccionaAtributosProductos.Atributo03
   Public Property Atributo04 As New Entidades.AtributoProducto Implements ISeleccionaAtributosProductos.Atributo04

   Private _onLoad As Boolean = False
   Private _publicos As Publicos


   Public Property idSucursal As Integer Implements ISeleccionaAtributosProductos.idSucursal
   Public Property idProducto As String Implements ISeleccionaAtributosProductos.idProducto

   '-- REQ-34666.- --------------------------------------------------------------------------------------------------
   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
   '-----------------------------------------------------------------------------------------------------------------
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      Try
         MyBase.OnLoad(e)

         Me._publicos = New Publicos()

         _onLoad = True

         '-- REQ-34666.- ---------------------------------------------------------------------------------------
         VerificaValorAtributos()
         bscCodigoAtributo01.Focus()
         '-----------------------------------------------------------------------------------------------------
      Finally
         _onLoad = False
      End Try

   End Sub
#End Region

#Region "Eventos"
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      '----------------------------------------------------------------------------------
      DialogResult = Windows.Forms.DialogResult.Cancel
      Close()
      '----------------------------------------------------------------------------------
   End Sub
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         If ValidarAtributos() Then
            '----------------------------------------------------------------------------------
            Me.Cursor = Cursors.WaitCursor
            '-- Carga datos en Entidades.- ----------------------------------------------------
            With Atributo01
               .IdaAtributoProducto = If(bscCodigoAtributo01.Tag Is Nothing, 0, Integer.Parse(bscCodigoAtributo01.Tag.ToString()))
               .IdAtributoProducto = If(String.IsNullOrEmpty(bscCodigoAtributo01.Text), 0, Integer.Parse(bscCodigoAtributo01.Text.ToString()))
               .Descripcion = bscDescripcionAtributo01.Text
            End With
            With Atributo02
               .IdaAtributoProducto = If(bscCodigoAtributo02.Tag Is Nothing, 0, Integer.Parse(bscCodigoAtributo02.Tag.ToString()))
               .IdAtributoProducto = If(String.IsNullOrEmpty(bscCodigoAtributo02.Text), 0, Integer.Parse(bscCodigoAtributo02.Text.ToString()))
               .Descripcion = bscDescripcionAtributo02.Text
            End With
            With Atributo03
               .IdaAtributoProducto = If(bscCodigoAtributo03.Tag Is Nothing, 0, Integer.Parse(bscCodigoAtributo03.Tag.ToString()))
               .IdAtributoProducto = If(String.IsNullOrEmpty(bscCodigoAtributo03.Text), 0, Integer.Parse(bscCodigoAtributo03.Text.ToString()))
               .Descripcion = bscDescripcionAtributo03.Text
            End With
            With Atributo04
               .IdaAtributoProducto = If(bscCodigoAtributo04.Tag Is Nothing, 0, Integer.Parse(bscCodigoAtributo04.Tag.ToString()))
               .IdAtributoProducto = If(String.IsNullOrEmpty(bscCodigoAtributo04.Text), 0, Integer.Parse(bscCodigoAtributo04.Text.ToString()))
               .Descripcion = bscDescripcionAtributo04.Text
            End With
            '----------------------------------------------------------------------------------
            DialogResult = Windows.Forms.DialogResult.OK
            Close()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   '-- Buscador Atributo 01.- -----------------------------------------------------------------------------------------------------------------------------------------------------------
   Private Sub bscCodigoAtributo01_BuscadorClick() Handles bscCodigoAtributo01.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaAtributoProducto2(bscCodigoAtributo01)
            bscCodigoAtributo01.Datos = New Reglas.AtributosProductos().GetFiltradoPorCodigoIDA(bscCodigoAtributo01.Text.ValorNumericoPorDefecto(0S),
                                                                                                Atributo01.IdGrupoTipoAtributoProducto,
                                                                                                Atributo01.IdTipoAtributoProducto)
         End Sub)
   End Sub
   Private Sub bscDescripcionAtributo01_BuscadorClick() Handles bscDescripcionAtributo01.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaAtributoProducto2(bscDescripcionAtributo01)
            bscDescripcionAtributo01.Datos = New Reglas.AtributosProductos().GetFiltradoPorNombreIDA(bscDescripcionAtributo01.Text,
                                                                                                     Atributo01.IdGrupoTipoAtributoProducto,
                                                                                                     Atributo01.IdTipoAtributoProducto)
         End Sub)
   End Sub
   Private Sub bscAtributo01_BuscadorSeleccion(sender As Object, e As BuscadorEventArgs) Handles bscCodigoAtributo01.BuscadorSeleccion, bscDescripcionAtributo01.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargaDatosAtributo(e.FilaDevuelta, bscCodigoAtributo01, bscDescripcionAtributo01)
            End If
         End Sub)
   End Sub
   '-- Buscador Atributo 02.- -----------------------------------------------------------------------------------------------------------------------------------------------------------
   Private Sub bscCodigoAtributo02_BuscadorClick() Handles bscCodigoAtributo02.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaAtributoProducto2(bscCodigoAtributo02)
            bscCodigoAtributo02.Datos = New Reglas.AtributosProductos().GetFiltradoPorCodigoIDA(bscCodigoAtributo02.Text.ValorNumericoPorDefecto(0S),
                                                                                                Atributo02.IdGrupoTipoAtributoProducto,
                                                                                                Atributo02.IdTipoAtributoProducto)
         End Sub)
   End Sub
   Private Sub bscDescripcionAtributo02_BuscadorClick() Handles bscDescripcionAtributo02.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaAtributoProducto2(bscDescripcionAtributo02)
            bscDescripcionAtributo02.Datos = New Reglas.AtributosProductos().GetFiltradoPorNombreIDA(bscDescripcionAtributo02.Text,
                                                                                                     Atributo02.IdGrupoTipoAtributoProducto,
                                                                                                     Atributo02.IdTipoAtributoProducto)
         End Sub)
   End Sub
   Private Sub bscAtributo02_BuscadorSeleccion(sender As Object, e As BuscadorEventArgs) Handles bscCodigoAtributo02.BuscadorSeleccion, bscDescripcionAtributo02.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargaDatosAtributo(e.FilaDevuelta, bscCodigoAtributo02, bscDescripcionAtributo02)
            End If
         End Sub)
   End Sub
   '-- Buscador Atributo 03.- -----------------------------------------------------------------------------------------------------------------------------------------------------------
   Private Sub bscCodigoAtributo03_BuscadorClick() Handles bscCodigoAtributo03.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaAtributoProducto2(bscCodigoAtributo03)
            bscCodigoAtributo03.Datos = New Reglas.AtributosProductos().GetFiltradoPorCodigoIDA(bscCodigoAtributo03.Text.ValorNumericoPorDefecto(0S),
                                                                                                Atributo03.IdGrupoTipoAtributoProducto,
                                                                                                Atributo03.IdTipoAtributoProducto)
         End Sub)
   End Sub
   Private Sub bscDescripcionAtributo03_BuscadorClick() Handles bscDescripcionAtributo03.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaAtributoProducto2(bscDescripcionAtributo03)
            bscDescripcionAtributo03.Datos = New Reglas.AtributosProductos().GetFiltradoPorNombreIDA(bscDescripcionAtributo03.Text,
                                                                                                     Atributo03.IdGrupoTipoAtributoProducto,
                                                                                                     Atributo03.IdTipoAtributoProducto)
         End Sub)
   End Sub
   Private Sub bscAtributo03_BuscadorSeleccion(sender As Object, e As BuscadorEventArgs) Handles bscCodigoAtributo03.BuscadorSeleccion, bscDescripcionAtributo03.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargaDatosAtributo(e.FilaDevuelta, bscCodigoAtributo03, bscDescripcionAtributo03)
            End If
         End Sub)
   End Sub
   '-- Buscador Atributo 04.- -----------------------------------------------------------------------------------------------------------------------------------------------------------
   Private Sub bscCodigoAtributo04_BuscadorClick() Handles bscCodigoAtributo04.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaAtributoProducto2(bscCodigoAtributo04)
            bscCodigoAtributo04.Datos = New Reglas.AtributosProductos().GetFiltradoPorCodigoIDA(bscCodigoAtributo04.Text.ValorNumericoPorDefecto(0S),
                                                                                                Atributo04.IdGrupoTipoAtributoProducto,
                                                                                                Atributo04.IdTipoAtributoProducto)
         End Sub)
   End Sub
   Private Sub bscDescripcionAtributo04_BuscadorClick() Handles bscDescripcionAtributo04.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaAtributoProducto2(bscDescripcionAtributo04)
            bscDescripcionAtributo04.Datos = New Reglas.AtributosProductos().GetFiltradoPorNombreIDA(bscDescripcionAtributo04.Text,
                                                                                                     Atributo04.IdGrupoTipoAtributoProducto,
                                                                                                     Atributo04.IdTipoAtributoProducto)
         End Sub)
   End Sub
   Private Sub bscAtributo04_BuscadorSeleccion(sender As Object, e As BuscadorEventArgs) Handles bscCodigoAtributo04.BuscadorSeleccion, bscDescripcionAtributo04.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargaDatosAtributo(e.FilaDevuelta, bscCodigoAtributo04, bscDescripcionAtributo04)
            End If
         End Sub)
   End Sub
   '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
#End Region

#Region "Metodos"
   Private Function ValidarAtributos() As Boolean
      If bscCodigoAtributo01.Visible And Not bscCodigoAtributo01.Selecciono And Not bscDescripcionAtributo01.Selecciono Then
         ShowMessage(String.Format("Debe Seleccionar un Atributo {0}!!!", lblAtributo01.Text))
         bscCodigoAtributo01.Focus()
         Return False
      End If
      If bscCodigoAtributo02.Visible And Not bscCodigoAtributo02.Selecciono And Not bscDescripcionAtributo02.Selecciono Then
         ShowMessage(String.Format("Debe Seleccionar un Atributo {0}!!!", lblAtributo02.Text))
         bscCodigoAtributo02.Focus()
         Return False
      End If
      If bscCodigoAtributo03.Visible And Not bscCodigoAtributo03.Selecciono And Not bscDescripcionAtributo03.Selecciono Then
         ShowMessage(String.Format("Debe Seleccionar un Atributo {0}!!!", lblAtributo03.Text))
         bscCodigoAtributo03.Focus()
         Return False
      End If
      If bscCodigoAtributo04.Visible And Not bscCodigoAtributo04.Selecciono And Not bscDescripcionAtributo04.Selecciono Then
         ShowMessage(String.Format("Debe Seleccionar un Atributo {0}!!!", lblAtributo04.Text))
         bscCodigoAtributo04.Focus()
         Return False
      End If
      Return True
   End Function
   Private Sub VerificaValorAtributos()
      Dim eAtributo As Entidades.TipoAtributoProducto

      If TipoAtributo01 > 0 And (Atributo01.IdGrupoTipoAtributoProducto + Atributo01.IdTipoAtributoProducto) > 0 Then
         '-- Carga Valores Check.- -----------------------------------------------------------------------------
         eAtributo = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01)
         lblAtributo01.Text = eAtributo.Descripcion
      Else
         lblAtributo01.Visible = False
         bscCodigoAtributo01.Visible = False
         bscDescripcionAtributo01.Visible = False
      End If

      If TipoAtributo02 > 0 And (Atributo02.IdGrupoTipoAtributoProducto + Atributo02.IdTipoAtributoProducto) > 0 Then
         '-- Carga Valores Check.- ---------------------------------------------------
         eAtributo = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02)
         lblAtributo02.Text = eAtributo.Descripcion
      Else
         lblAtributo02.Visible = False
         bscCodigoAtributo02.Visible = False
         bscDescripcionAtributo02.Visible = False
      End If
      '-- Atributo 003.- -------------------------------------------------------------
      If TipoAtributo03 > 0 And (Atributo03.IdGrupoTipoAtributoProducto + Atributo03.IdTipoAtributoProducto) > 0 Then
         '-- Carga Valores Check.- ---------------------------------------------------
         eAtributo = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo03)
         lblAtributo03.Text = eAtributo.Descripcion
      Else
         lblAtributo03.Visible = False
         bscCodigoAtributo03.Visible = False
         bscDescripcionAtributo03.Visible = False
      End If
      '-- Atributo 004.- -------------------------------------------------------------
      If TipoAtributo04 > 0 And (Atributo04.IdGrupoTipoAtributoProducto + Atributo04.IdTipoAtributoProducto) > 0 Then
         '-- Carga Valores Check.- ---------------------------------------------------
         eAtributo = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo04)
         lblAtributo04.Text = eAtributo.Descripcion
      Else
         lblAtributo04.Visible = False
         bscCodigoAtributo04.Visible = False
         bscDescripcionAtributo04.Visible = False
      End If
   End Sub

   Private Sub CargaDatosAtributo(dr As DataGridViewRow, bscCodigo As Buscador2, bscDescripcion As Buscador2)
      bscCodigo.Text = dr.Cells("IdAtributoProducto").Value.ToString()
      bscDescripcion.Text = dr.Cells("Descripcion").Value.ToString()
      bscCodigo.Tag = dr.Cells("IdaAtributoProducto").Value.ToString()

      If bscCodigo.Equals(bscCodigoAtributo01) Then
         If bscCodigoAtributo02.Visible Then
            bscCodigoAtributo02.Focus()
         ElseIf bscCodigoAtributo03.Visible Then
            bscCodigoAtributo03.Focus()
         ElseIf bscCodigoAtributo04.Visible Then
            bscCodigoAtributo04.Focus()
         Else
            btnAceptar.Focus()
         End If
      ElseIf bscCodigo.Equals(bscCodigoAtributo02) Then
         If bscCodigoAtributo03.Visible Then
            bscCodigoAtributo03.Focus()
         ElseIf bscCodigoAtributo04.Visible Then
            bscCodigoAtributo04.Focus()
         Else
            btnAceptar.Focus()
         End If
      ElseIf bscCodigo.Equals(bscCodigoAtributo03) Then
         If bscCodigoAtributo04.Visible Then
            bscCodigoAtributo04.Focus()
         Else
            btnAceptar.Focus()
         End If
      Else
         btnAceptar.Focus()
      End If

   End Sub

   Private Function ISeleccionaAtributosProductos_ShowDialog(owner As IWin32Window) As DialogResult Implements ISeleccionaAtributosProductos.ShowDialog
      Return ShowDialog(owner)
   End Function

#End Region
End Class