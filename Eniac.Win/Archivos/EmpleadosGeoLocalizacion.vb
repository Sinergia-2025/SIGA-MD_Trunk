Option Strict Off
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET.MapProviders

Public Class EmpleadosGeoLocalizacion

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
        If Me.Empleados IsNot Nothing Then
            Me.tsbObtenerEmpleados.PerformClick()
        End If
    End Sub

#End Region

#Region "Propiedades"

    Private _empleados As DataTable
    Public Property Empleados() As DataTable
        Get
            Return _empleados
        End Get
        Set(ByVal value As DataTable)
            _empleados = value
        End Set
    End Property

#End Region

#Region "Metodos"

    Private Sub ObtenerEmpleados()
        If Me.Empleados Is Nothing Then
            Me.Empleados = New Reglas.Empleados().GetAll()
        End If

        Me.trvEmpleados.Nodes.Clear()
        Dim i As Integer = 0

        For Each dr As DataRow In Me.Empleados.Rows
            Me.trvEmpleados.Nodes.Add(i.ToString(), dr("NombreEmpleado").ToString())
            Me.trvEmpleados.Nodes(i.ToString()).Nodes.Add("dire", dr("Direccion").ToString())
            Me.trvEmpleados.Nodes(i.ToString()).Nodes.Add("loca", dr("NombreLocalidad").ToString())
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
        Dim oEmpleados As Reglas.Empleados

        Me.tspBarra.Visible = True
        If Me.Empleados.Rows.Count > Me.nudMaximoAMostrar.Value Then
            Me.tspBarra.Maximum = Me.nudMaximoAMostrar.Value
        Else
            Me.tspBarra.Maximum = Me.Empleados.Rows.Count
        End If
        Me.tspBarra.Minimum = 0
        Me.tspBarra.Value = 0

        Application.DoEvents()

        For Each dr As DataRow In Me.Empleados.Rows
            i += 1

            If i = Me.nudMaximoAMostrar.Value Then
                Exit For
            End If

            Me.tspBarra.Value = i

            provincia = New Reglas.Localidades().GetUna(Integer.Parse(dr("IdLocalidad").ToString())).NombreProvincia

            direccion = dr("Direccion").ToString() + ", " + dr("NombreLocalidad").ToString() + "," + provincia + ", Argentina"
            nombre = dr("NombreEmpleado").ToString()


            If dr("GeoLocalizacionLat").ToString() = "" Then
                Try
                    pt = gp.GetPoint(direccion, GeoCoderStatusCode.G_GEO_UNKNOWN_ADDRESS)
                    oEmpleados = New Reglas.Empleados()
                    oEmpleados.ActualizarGeolocalizacion(dr("TipoDocEmpleado").ToString(), dr("NroDocEmpleado").ToString(), pt.Lat, pt.Lng)

                Catch ex As Exception
                    Me.trvEmpleados.Nodes((i - 1).ToString()).ForeColor = Color.Red
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

    Private Sub tsbObtenerEmpleados_Click(sender As Object, e As EventArgs) Handles tsbObtenerEmpleados.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.tslInfo.Text = "Obteniendo Empleados..."
            Me.ObtenerEmpleados()
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

    Private Sub trvEmpleados_DoubleClick(sender As Object, e As EventArgs) Handles trvEmpleados.DoubleClick
        Try
            If Me.trvEmpleados.SelectedNode IsNot Nothing Then
                If Me.trvEmpleados.SelectedNode.Nodes("dire") IsNot Nothing Then
                    If Me.trvEmpleados.SelectedNode.ForeColor <> Color.Red Then
                        Me.gmcMapa.SetPositionByKeywords(Me.trvEmpleados.SelectedNode.Nodes("dire").Text + ", " + Me.trvEmpleados.SelectedNode.Nodes("loca").Text + ", Argentina")
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