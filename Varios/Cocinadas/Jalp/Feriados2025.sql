PRINT ''
PRINT '1. Agregar Feriados de 2025'

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-01-01')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-01-01', 'Año nuevo');
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
    ('2025-03-24', 'Día Nacional de la Memoria por la Verdad y la Justicia');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-04-02')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-04-02', 'Día del Veterano y de los Caídos en la Guerra de Malvinas');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-04-18')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-04-18', 'Viernes Santo');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-05-01')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-05-01', 'Día del Trabajador');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-05-02')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-05-02', 'Puente turístico no laborable');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-05-25')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-05-25', 'Día de la Revolución de Mayo');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-06-16')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-06-16', 'Paso a la Inmortalidad del General Martín Güemes');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-06-20')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-06-20', 'Paso a la Inmortalidad del General Manuel Belgrano');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-07-09')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-07-09', 'Día de la Independencia');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-08-15')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-08-15', 'Puente turístico no laborable');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-08-17')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-08-17', 'Paso a la Inmortalidad del Gral. José de San Martín');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-10-12')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-10-12', 'Día del Respeto a la Diversidad Cultural');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-11-21')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-11-21', 'Puente turístico no laborable');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-11-24')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-11-24', 'Día de la Soberanía Nacional');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-12-08')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-12-08', 'Día de la Inmaculada Concepción de María');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2025-12-25')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2025-12-25', 'Navidad');
    END

IF NOT EXISTS (SELECT * FROM Feriados WHERE FechaFeriado = '2026-01-01')
    BEGIN
    INSERT INTO Feriados VALUES
    ('2026-01-01', 'Año nuevo');
    END