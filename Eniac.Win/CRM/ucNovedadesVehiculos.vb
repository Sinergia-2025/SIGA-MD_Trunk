Public Class ucNovedadesVehiculos

   Public Property TipoNovedad As Entidades.CRMTipoNovedad

   Private _cargandoCliente As Boolean = False

   Private _idCliente As Long?
   Public Property IdCliente As Long?
      Get
         Return _idCliente
      End Get
      Set(value As Long?)
         _idCliente = value
         Dim dt = New Reglas.Vehiculos().GetFiltradoPorCliente(value.IfNull(), soloActivos:=True)
         If dt.Rows.Count = 1 Then
            bscCodigoVehiculo.PresionarBoton()
         End If
      End Set
   End Property

   Public Property PatenteVehiculo() As String
      Get
         If bscCodigoVehiculo.Selecciono Then
            Return bscCodigoVehiculo.Text
         Else
            Return String.Empty
         End If
      End Get
      Set(value As String)
         Try
            If Not String.IsNullOrWhiteSpace(value) Then
               bscCodigoVehiculo.Text = value
               bscCodigoVehiculo.PresionarBoton()
            Else
               bscCodigoVehiculo.Text = String.Empty
            End If
            OnSelectedChanged(Nothing)
         Catch ex As Exception
            bscCodigoVehiculo.Text = String.Empty
            OnSelectedChanged(Nothing)
            FindForm().ShowMessage(String.Format("No se pudo recuperar el Vehículo: {0}", ex.Message))
         End Try
      End Set
   End Property

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() _publicos = New Publicos())
   End Sub


#Region "Eventos Buscador Vehiculos"
   Private Sub bscCodigoVehiculo_BuscadorClick() Handles bscCodigoVehiculo.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaVehiculos2(bscCodigoVehiculo)
         Dim codigoVehiculo = bscCodigoVehiculo.Text.Trim()
         bscCodigoVehiculo.Datos = New Reglas.Vehiculos().GetFiltradoPorPatente(codigoVehiculo, _idCliente.IfNull(), True)
      End Sub)
   End Sub
   Private Sub bscCodigoVehiculo_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoVehiculo.BuscadorSeleccion
      TryCatched(Sub() CargarDatosVehiculos(e.FilaDevuelta))
   End Sub
   Private Sub CargarDatosVehiculos(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCodigoVehiculo.Text = dr.Cells(Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString()).Value.ToString().Trim()
         txtMarcaVehiculo.Text = dr.Cells("NombreMarcaVehiculo").Value.ToString().Trim()
         txtModeloVehiculo.Text = dr.Cells("NombreModeloVehiculo").Value.ToString().Trim()
         txtAnioPatentamiento.Text = dr.Cells("AnioPatentamiento").Value.ToString().Trim()
         txtColor.Text = dr.Cells("Color").Value.ToString().Trim()

         OnSelectedChanged(Nothing)

         'PatenteVehiculo = bscCodigoVehiculo.Text

         ''''Dim v = New Reglas.Vehiculos().GetUno(dr.Cells(Entidades.Vehiculo.Columnas.PatenteVehiculo.ToString()).Value.ToString().Trim())
         ''''If v.Clientes.Count = 1 Then
         ''''   'bscCodigoCliente.Text = v.Clientes(0).CodigoCliente.ToString()
         ''''   'bscCodigoCliente.PresionarBoton()
         ''''End If
      End If
   End Sub

#End Region

   Private Sub bscCodigoVehiculo_TextChange(sender As Object, e As EventArgs) Handles bscCodigoVehiculo.TextChange
      TryCatched(
      Sub()
         txtMarcaVehiculo.Clear()
         txtModeloVehiculo.Clear()
         txtAnioPatentamiento.Clear()
         txtColor.Clear()
      End Sub)
   End Sub

   Private Sub llbCliente_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked
      Try
         MostrarMasInfo()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub MostrarMasInfo()
      TryCatched(
     Sub()
        Dim Vehiculo As Entidades.Vehiculo = New Entidades.Vehiculo
        If bscCodigoVehiculo.Text <> String.Empty Then
           Vehiculo = New Reglas.Vehiculos().GetUno(bscCodigoVehiculo.Text)
        End If
        Using frm = New VehiculosDetalle(Vehiculo)
           frm.StateForm = If(bscCodigoVehiculo.Text <> String.Empty, StateForm.Actualizar, StateForm.Insertar)
           If frm.ShowDialog(FindForm()) = DialogResult.OK Then
              bscCodigoVehiculo.Text = frm.IdPatente.ToString()
              bscCodigoVehiculo.PresionarBoton()
           End If
        End Using
     End Sub)
   End Sub

End Class
