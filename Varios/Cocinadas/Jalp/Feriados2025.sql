PRINT ''
PRINT '1. Agregar Feriados de 2025'

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-01-01')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-01-01', 'A�o nuevo');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-03-03')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-03-03', 'Carnaval');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-03-04')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-03-04', 'Carnaval');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-03-24')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-03-24', 'D�a Nacional de la Memoria por la Verdad y la Justicia');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-04-02')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-04-02', 'D�a del Veterano y de los Ca�dos en la Guerra de Malvinas');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-04-18')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-04-18', 'Viernes Santo');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-05-01')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-05-01', 'D�a del Trabajador');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-05-02')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-05-02', 'Puente tur�stico no laborable');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-05-25')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-05-25', 'D�a de la Revoluci�n de Mayo');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-06-16')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-06-16', 'Paso a la Inmortalidad del General Mart�n G�emes');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-06-20')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-06-20', 'Paso a la Inmortalidad del General Manuel Belgrano');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-07-09')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-07-09', 'D�a de la Independencia');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-08-15')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-08-15', 'Puente tur�stico no laborable');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-08-17')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-08-17', 'Paso a la Inmortalidad del Gral. Jos� de San Mart�n');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-10-12')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-10-12', 'D�a del Respeto a la Diversidad Cultural');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-11-21')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-11-21', 'Puente tur�stico no laborable');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-11-24')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-11-24', 'D�a de la Soberan�a Nacional');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-12-08')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-12-08', 'D�a de la Inmaculada Concepci�n de Mar�a');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-12-25')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-12-25', 'Navidad');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2026-01-01')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2026-01-01', 'A�o nuevo');
    END