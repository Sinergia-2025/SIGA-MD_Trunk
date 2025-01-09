Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class CategoriasProveedores
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CategoriasProveedores"
      da = New Datos.DataAccess()
   End Sub
   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CategoriasProveedores"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .AppendLine("SELECT CP.IdCategoria,")
         .AppendLine("       CP.NombreCategoria")
         .AppendLine("      ,CP.IdCuentaContable")
         .AppendLine("      ,CC.NombreCuenta")
         .AppendLine(" FROM CategoriasProveedores CP")
         .AppendLine(" LEFT OUTER JOIN ContabilidadCuentas CC ON CC.IdCuenta = CP.IdCuentaContable")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CategoriasProveedores(Me.da).CategoriasProveedores_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim cate As Entidades.CategoriaProveedor = DirectCast(entidad, Entidades.CategoriaProveedor)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.CategoriasProveedores = New SqlServer.CategoriasProveedores(da)

         Dim idCuenta As Long = 0
         If cate.CuentaContable IsNot Nothing Then idCuenta = cate.CuentaContable.IdCuenta

         Select Case tipo
            Case TipoSP._I
               sqlC.CategoriasProveedores_I(cate.IdCategoria, cate.NombreCategoria, idCuenta)

            Case TipoSP._U
               sqlC.CategoriasProveedores_U(cate.IdCategoria, cate.NombreCategoria, idCuenta)

            Case TipoSP._D
               sqlC.CategoriasProveedores_D(cate.IdCategoria)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Function GetPorId(ByVal idCategoria As Integer) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append("SELECT CP.idCategoria")
         .Append("      ,CP.NombreCategoria")
         .AppendLine("      ,CP.IdCuentaContable")
         .AppendLine("      ,CC.NombreCuenta")
         .Append(" FROM CategoriasProveedores CP")
         .AppendLine(" LEFT OUTER JOIN ContabilidadCuentas CC ON CC.IdCuenta = CP.IdCuentaContable")
         .Append("  WHERE idCategoria =" & idCategoria.ToString())
      End With
      Return da.GetDataTable(stbQuery.ToString())
   End Function

   Private Sub CargarUno(o As Entidades.CategoriaProveedor, dr As DataRow)
      With o
         .IdCategoria = dr.Field(Of Integer)(Entidades.CategoriaProveedor.Columnas.IdCategoria.ToString())
         .NombreCategoria = dr.Field(Of String)(Entidades.CategoriaProveedor.Columnas.NombreCategoria.ToString())
         If Publicos.TieneModuloContabilidad AndAlso Not IsDBNull(dr(Entidades.CategoriaProveedor.Columnas.IdCuentaContable.ToString())) Then
            .CuentaContable = New Reglas.ContabilidadCuentas(da)._GetUna(dr.Field(Of Long)(Entidades.CategoriaProveedor.Columnas.IdCuentaContable.ToString()))
         End If
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(ByVal idCategoria As Integer) As Entidades.CategoriaProveedor
      Dim dt As DataTable = Me.GetPorId(idCategoria)
      Dim o As Entidades.CategoriaProveedor = New Entidades.CategoriaProveedor()
      If dt.Rows.Count > 0 Then
         CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetPrimeroCategoria(accion As AccionesSiNoExisteRegistro) As Entidades.CategoriaProveedor
      Return CargaEntidad(GetAll(),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CategoriaProveedor,
                          accion, Function() String.Format("No se encontró ningún Categoria de Proveedores"))
   End Function

   Public Function GetIdMaximo() As Integer
      Dim sql As SqlServer.CategoriasProveedores = New SqlServer.CategoriasProveedores(Me.da)
      Dim dt As DataTable = sql.CategoriasProveedores_GetIdMaximo()
      Dim val As Integer = 0
      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If
      Return val
   End Function
   Public Function GetPorNombreExacto(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT CP.IdCategoria,")
         .AppendLine("       CP.NombreCategoria")
         .AppendLine("      ,CP.IdCuentaContable")
         .AppendLine("      ,CC.NombreCuenta")
         .AppendLine("  FROM CategoriasProveedores AS CP")
         .AppendLine(" LEFT OUTER JOIN ContabilidadCuentas CC ON CC.IdCuenta = CP.IdCuentaContable")
         .AppendLine(" WHERE NombreCategoria = '" & nombre & "' ")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function
#End Region

End Class

