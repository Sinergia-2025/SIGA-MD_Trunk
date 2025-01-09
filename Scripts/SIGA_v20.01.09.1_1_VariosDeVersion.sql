PRINT ''
PRINT '1. Nueva Tabla: Funciones Documentos'
create table FuncionesDocumentos(
IdFuncion varchar(30) foreign key references Funciones(Id),
IdTipoLink varchar(15),
Orden int,
Link varchar(500),
Descripcion varchar(50)
)