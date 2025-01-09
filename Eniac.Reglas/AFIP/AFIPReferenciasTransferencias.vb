Public Class AFIPReferenciasTransferencias
   Inherits Base(Of Entidades.AFIPReferenciaTransferencia, SqlServer.AFIPReferenciasTransferencias)

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.AFIPReferenciaTransferencia.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Protected Overrides Function Buscar(entidad As Entidades.Buscar, sql As SqlServer.AFIPReferenciasTransferencias) As DataTable
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Protected Overloads Overrides Function GetAll(sql As SqlServer.AFIPReferenciasTransferencias) As DataTable
      Return sql.AFIPReferenciasTransferencias_GA()
   End Function

   Protected Overrides Function GetSql() As SqlServer.AFIPReferenciasTransferencias
      Return New SqlServer.AFIPReferenciasTransferencias(Me.da)
   End Function

   Protected Overrides Sub EjecutaSP(en As Entidades.AFIPReferenciaTransferencia, sql As SqlServer.AFIPReferenciasTransferencias, tipo As TipoSP)
      Select Case tipo
         Case TipoSP._I
            sql.AFIPReferenciasTransferencias_I(en.IdAFIPReferenciaTransferencia, en.NombreReferenciaTransferencia, en.DescripcionReferenciaTransferencia)
         Case TipoSP._U
            sql.AFIPReferenciasTransferencias_U(en.IdAFIPReferenciaTransferencia, en.NombreReferenciaTransferencia, en.DescripcionReferenciaTransferencia)
         Case TipoSP._D
            sql.AFIPReferenciasTransferencias_D(en.IdAFIPReferenciaTransferencia)
      End Select

   End Sub

   Protected Overrides Sub CargarUno(o As Entidades.AFIPReferenciaTransferencia, dr As DataRow)
      With o
         .IdAFIPReferenciaTransferencia = dr.Field(Of String)(Entidades.AFIPReferenciaTransferencia.Columnas.IdAFIPReferenciaTransferencia.ToString())
         .NombreReferenciaTransferencia = dr.Field(Of String)(Entidades.AFIPReferenciaTransferencia.Columnas.NombreReferenciaTransferencia.ToString())
         .DescripcionReferenciaTransferencia = dr.Field(Of String)(Entidades.AFIPReferenciaTransferencia.Columnas.DescripcionReferenciaTransferencia.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idAFIPReferenciaTransferencia As String) As Entidades.AFIPReferenciaTransferencia
      Return GetUno(idAFIPReferenciaTransferencia, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idAFIPReferenciaTransferencia As String, accion As AccionesSiNoExisteRegistro) As Entidades.AFIPReferenciaTransferencia
      Return CargaEntidad(New SqlServer.AFIPReferenciasTransferencias(Me.da).AFIPReferenciasTransferencias_G1(idAFIPReferenciaTransferencia),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.AFIPReferenciaTransferencia(),
                          accion, Function() String.Format("No existe Referencia de Transferencia de AFIP con Id: {0}", idAFIPReferenciaTransferencia))
   End Function

   Public Function GetTodos() As List(Of Entidades.AFIPReferenciaTransferencia)
      Return CargaLista(New SqlServer.AFIPReferenciasTransferencias(Me.da).AFIPReferenciasTransferencias_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.AFIPReferenciaTransferencia())
   End Function

#End Region

End Class