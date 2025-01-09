Public Class Provincias
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Provincias"
      Me.da = New Eniac.Datos.DataAccess()
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.New()
      Me.da = accesoDatos
   End Sub


#End Region

#Region "Overrides"
   Protected Overridable Function GetSqlServer() As Eniac.SqlServer.Provincias
      Return New SqlServer.Provincias(da)
   End Function
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Dim prov As Entidades.Provincia = DirectCast(entidad, Entidades.Provincia)
      Try
         da.OpenConection()
         da.BeginTransaction()

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Dim en As Entidades.Provincia = DirectCast(entidad, Entidades.Provincia)
      Try
         da.OpenConection()
         da.BeginTransaction()

         If Not Publicos.TieneModuloContabilidad Then
            en.CuentaCompras = Nothing
            en.CuentaVentas = Nothing
         End If

         GetSqlServer().Provincias_U(en.IdProvincia, en.EsAgentePercepcion, en.IngBrutos, en.AgenteIngBrutos, en.IdCuentaDebe, en.IdCuentaHaber, en.Jurisdiccion, en.IdPais, en.IdAFIPProvincia)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub


   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Dim prov As Entidades.Provincia = DirectCast(entidad, Entidades.Provincia)
      Try
         da.OpenConection()
         da.BeginTransaction()

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.Provincias(da).Buscar(entidad.Columna, entidad.Valor.ToString())
      'Dim stbQuery As StringBuilder = New StringBuilder("")
      ''If entidad.Columna = "IdProvincia" Then entidad.Columna = "L." + entidad.Columna

      'If entidad.Columna = "NombreCuentaDebe" Then
      '   entidad.Columna = "CCD.NombreCuenta"
      'ElseIf entidad.Columna = "NombreCuentaHaber" Then
      '   entidad.Columna = "CCH.NombreCuenta"
      'ElseIf entidad.Columna = "NombrePais" Then
      '   entidad.Columna = "PA." + entidad.Columna
      'Else
      '   entidad.Columna = "P." + entidad.Columna
      'End If

      'With stbQuery
      '   .Length = 0
      '   .AppendLine("SELECT P.IdProvincia")
      '   .AppendLine("     , P.NombreProvincia")
      '   .AppendLine("     , P.Jurisdiccion")
      '   .AppendLine("     , P.EsAgentePercepcion")
      '   .AppendLine("     , P.IngBrutos")
      '   .AppendLine("     , P.AgenteIngBrutos")
      '   .AppendLine("      ,P.IdCuentaDebe")
      '   .AppendLine("      ,CCD.NombreCuenta AS NombreCuentaDebe")
      '   .AppendLine("      ,P.IdCuentaHaber")
      '   .AppendLine("      ,CCH.NombreCuenta AS NombreCuentaHaber")
      '   .AppendLine("  FROM Provincias P ")
      '   .AppendLine("  LEFT JOIN ContabilidadCuentas AS CCD ON CCD.idCuenta = P.IdCuentaDebe")
      '   .AppendLine("  LEFT JOIN ContabilidadCuentas AS CCH ON CCH.idCuenta = P.IdCuentaHaber")
      '   .AppendLine("  WHERE " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")
      'End With
      'Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Provincias(da).Provincias_GA()
   End Function

   Private Sub CargarUno(o As Entidades.Provincia, dr As DataRow)

      With o
         .IdProvincia = dr(Entidades.Provincia.Columnas.IdProvincia.ToString()).ToString()
         .NombreProvincia = dr(Entidades.Provincia.Columnas.NombreProvincia.ToString()).ToString()
         .EsAgentePercepcion = Boolean.Parse(dr(Entidades.Provincia.Columnas.EsAgentePercepcion.ToString()).ToString())
         .IngBrutos = dr(Entidades.Provincia.Columnas.IngBrutos.ToString()).ToString()
         .AgenteIngBrutos = dr(Entidades.Provincia.Columnas.AgenteIngBrutos.ToString()).ToString()

         If Publicos.TieneModuloContabilidad Then
            Dim rCtbl As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas(da)
            If Not String.IsNullOrWhiteSpace(dr(Entidades.Provincia.Columnas.IdCuentaDebe.ToString()).ToString()) Then
               .CuentaCompras = rCtbl._GetUna(Long.Parse(dr(Entidades.TipoImpuesto.Columnas.IdCuentaDebe.ToString()).ToString()))
            End If
            If Not String.IsNullOrWhiteSpace(dr(Entidades.Provincia.Columnas.IdCuentaHaber.ToString()).ToString()) Then
               .CuentaVentas = rCtbl._GetUna(Long.Parse(dr(Entidades.TipoImpuesto.Columnas.IdCuentaHaber.ToString()).ToString()))
            End If
         End If
         .Jurisdiccion = Integer.Parse(dr(Entidades.Provincia.Columnas.Jurisdiccion.ToString()).ToString())
         .IdPais = dr(Entidades.Provincia.Columnas.IdPais.ToString()).ToString()
         .IdAFIPProvincia = dr.Field(Of Integer)(Entidades.Provincia.Columnas.IdAFIPProvincia.ToString())
      End With

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.Provincia)
      Return CargaLista(GetAll(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Provincia())
   End Function

   Public Function GetUno(idProvincia As String) As Entidades.Provincia
      Return GetUno(idProvincia, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idProvincia As String, accion As AccionesSiNoExisteRegistro) As Entidades.Provincia
      Return CargaEntidad(Get1(idProvincia),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Provincia(),
                          accion, Function() String.Format("No existe la Provincia con ID '{0}'.", idProvincia))
   End Function

   Public Function Get1(IdProvincia As String) As DataTable
      Return New SqlServer.Provincias(da).Provincias_G1(IdProvincia)
   End Function

#End Region

End Class