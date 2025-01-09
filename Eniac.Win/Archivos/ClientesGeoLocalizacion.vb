Option Strict Off
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.MapProviders

Public Class ClientesGeoLocalizacion

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Me.cmbTipoMapa.Text = "Google Maps"
      GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly
      Me.gmcMapa.SetPositionByKeywords("Rosario, Argentina")
      GMapProvider.Language = LanguageType.Spanish
      Me.gmcMapa.Zoom = 11

   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      If Me.Clientes IsNot Nothing Then
         Me.tsbObtenerClientes.PerformClick()
      End If
   End Sub

#End Region

#Region "Propiedades"

   Private _clientes As DataTable
   Public Property Clientes() As DataTable
      Get
         Return _clientes
      End Get
      Set(ByVal value As DataTable)
         _clientes = value
      End Set
   End Property

#End Region

#Region "Metodos"

   Private Sub ObtenerClientes()
      If Me.Clientes Is Nothing Then
         Me.Clientes = New Reglas.Clientes().GetAll()
      End If

      Me.trvClientes.Nodes.Clear()
      Dim i As Integer = 0

      For Each dr As DataRow In Me.Clientes.Rows
         Me.trvClientes.Nodes.Add(i.ToString(), dr("NombreCliente").ToString())
         Me.trvClientes.Nodes(i.ToString()).Nodes.Add("dire", dr("Direccion").ToString())
         Me.trvClientes.Nodes(i.ToString()).Nodes.Add("loca", dr("NombreLocalidad").ToString())
         i += 1
         'If i = Me.nudMaximoAMostrar.Value Then
         '   Exit For
         'End If
      Next

   End Sub

   Private Sub CargarMapa()

      Me.gmcMapa.Overlays.Clear()
      Me.gmcMapa.ReloadMap()

      Dim direccion As String
      Dim nombre As String
      Dim gp As GMap.NET.GeocodingProvider = MapProviders.GMapProviders.OpenStreetMap
      Dim pt As PointLatLng
      Dim ov As GMapOverlay = New GMapOverlay("direcciones")
      Dim i As Integer = 0
      Dim provincia As String
      Dim oclientes As Reglas.Clientes

      Me.tspBarra.Visible = True
      If Me.Clientes.Rows.Count > Me.nudMaximoAMostrar.Value Then
         Me.tspBarra.Maximum = Me.nudMaximoAMostrar.Value
      Else
         Me.tspBarra.Maximum = Me.Clientes.Rows.Count
      End If
      Me.tspBarra.Minimum = 0
      Me.tspBarra.Value = 0

      Application.DoEvents()

      For Each dr As DataRow In Me.Clientes.Rows
         i += 1

         If i = Me.nudMaximoAMostrar.Value Then
            Exit For
         End If

         Me.tspBarra.Value = i

         provincia = New Reglas.Localidades().GetUna(Integer.Parse(dr("IdLocalidad").ToString())).NombreProvincia

         direccion = dr("Direccion").ToString() + ", " + dr("NombreLocalidad").ToString() + "," + provincia + ", Argentina"
         nombre = dr("NombreCliente").ToString()


         If dr("GeoLocalizacionLat").ToString() = "" Then
            Try
               pt = gp.GetPoint(direccion, GeoCoderStatusCode.G_GEO_UNKNOWN_ADDRESS)
               oclientes = New Reglas.Clientes()
               oclientes.ActualizarGeolocalizacion(Long.Parse(dr("IdCliente").ToString()), pt.Lat, pt.Lng)

            Catch ex As Exception
               Me.trvClientes.Nodes((i - 1).ToString()).ForeColor = Color.Red
               Continue For
            End Try

            ov.Markers.Add(Me.GetMarca(pt.Lat, pt.Lng, dr("Direccion").ToString() + "-" + dr("NombreLocalidad").ToString(), nombre))

            Me.gmcMapa.Overlays.Add(ov)

         Else

            ov.Markers.Add(Me.GetMarca(Double.Parse(dr("GeoLocalizacionLat").ToString()), Double.Parse(dr("GeoLocalizacionLng").ToString()), dr("Direccion").ToString() + "-" + dr("NombreLocalidad").ToString(), nombre))

            Me.gmcMapa.Overlays.Add(ov)

         End If


      Next

      Me.gmcMapa.SetZoomToFitRect(Me.gmcMapa.GetRectOfAllMarkers("direcciones"))

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbObtenerClientes_Click(sender As Object, e As EventArgs) Handles tsbObtenerClientes.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.tslInfo.Text = "Obteniendo Clientes..."
         Me.ObtenerClientes()
         Application.DoEvents()
         Me.tslInfo.Text = "Cargando Mapa..."
         Me.CargarMapa()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.tslInfo.Text = ""
         Me.tspBarra.Visible = False
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Function GetMarca(latitud As Double, longitud As Double, direccion As String, nombre As String) As GMarkerGoogle
      Dim marker As GMarkerGoogle = New GMarkerGoogle(New PointLatLng(latitud, longitud), GMarkerGoogleType.green)
      marker.ToolTip = New GMap.NET.WindowsForms.GMapToolTip(marker)
      marker.ToolTipText = nombre + "-" + direccion
      Return marker
   End Function

   Private Sub cmbTipoMapa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoMapa.SelectedIndexChanged
      Try
         Select Case Me.cmbTipoMapa.Text
            Case "Google Maps"
               Me.gmcMapa.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance
            Case "Google Satelite Maps"
               Me.gmcMapa.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance
            Case Else
         End Select
         Me.gmcMapa.ReloadMap()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub trvClientes_DoubleClick(sender As Object, e As EventArgs) Handles trvClientes.DoubleClick
      Try
         If Me.trvClientes.SelectedNode IsNot Nothing Then
            If Me.trvClientes.SelectedNode.Nodes("dire") IsNot Nothing Then
               If Me.trvClientes.SelectedNode.ForeColor <> Color.Red Then
                  Me.gmcMapa.SetPositionByKeywords(Me.trvClientes.SelectedNode.Nodes("dire").Text + ", " + Me.trvClientes.SelectedNode.Nodes("loca").Text + ", Argentina")
                  Me.gmcMapa.Zoom = 15
               End If
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tcbZoom_Scroll(sender As Object, e As EventArgs) Handles tcbZoom.Scroll
      Me.gmcMapa.Zoom = Me.tcbZoom.Value
   End Sub

#End Region

End Class