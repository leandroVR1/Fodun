INSERT INTO Sedes (Nombre, Tipo, CapacidadTotal, Ubicacion, Descripcion)
VALUES 
('Villeta', 'Recreativa', 32, 'Villeta', 'Ocho habitaciones con una alcoba que tiene una cama doble y un camarote, baño, nevera, televisor y terraza cubierta.'),
('El placer – Fusagasugá', 'Recreativa', 34, 'Fusagasugá', 'Varios alojamientos, algunos con habitaciones múltiples y cabañas con sala de estar, sofá cama, baño, cocineta equipada y nevera.'),
('Gonzalo Morante - Chinchiná', 'Recreativa', 30, 'Chinchiná', 'Alojamientos con cocineta, baño, Televisor, dos habitaciones y otros servicios.'),
('Tablones – Palmira', 'Recreativa', 24, 'Palmira', 'Alojamientos con habitaciones dobles, camarotes, sala de estar, televisor, baño y cocineta.'),
('Manguruma – Santa fe de Antioquia', 'Recreativa', 46, 'Santa Fe de Antioquia', 'Alojamientos con cama doble, camarote, sofá cama, baño, terraza y televisor.'),
('Federman - Bogotá', 'Recreativa', 16, 'Bogotá', 'Habitaciones, zona húmeda con baño turco, sauna, jacuzzi, gimnasio, juegos de mesa, sala de masajes y cafetería.')

INSERT INTO Alojamiento (SedeId, TipoAlojamiento, CapacidadMaxima, NumeroHabitaciones, Descripcion)
VALUES 
(1, 'Habitación', 32, 8, 'Ocho habitaciones con una cama doble y un camarote, baño, nevera, televisor y terraza.'),
(2, 'Alojamiento 1', 18, 2, 'Dos habitaciones con baño y televisor, una con cama doble y una sencilla, otra con una cama sencilla.'),
(2, 'Alojamiento 2', 18, 2, 'Dos habitaciones, una con cama doble y la otra con 4 camas sencillas.'),
(3, 'Alojamiento 1', 30, 2, 'Cocineta, baño, Televisor, 2 habitaciones, la 1 con dos camas sencillas, la 2 con una cama doble y una sencilla.'),
(3, 'Alojamiento 2', 30, 2, 'Cocineta, baño, Televisor, 2 habitaciones, la 1 con cama doble, la 2 con dos camas sencillas.'),
(4, 'Alojamiento 1', 24, 1, 'Una habitación con cama doble y un camarote, televisor, baño y cocineta.'),
(5, 'Alojamiento 1', 14, 1, 'Una cama doble, un camarote, baño, terraza y televisor.')

INSERT INTO Disponibilidades (AlojamientoId, FechaInicio, FechaFin, Disponible)
VALUES 
(1, '2024-09-01', '2024-09-10', 1),
(2, '2024-09-05', '2024-09-15', 1),
(3, '2024-09-12', '2024-09-18', 1),
(4, '2024-09-20', '2024-09-25', 0),
(5, '2024-09-25', '2024-10-01', 1),
(6, '2024-09-01', '2024-09-10', 0)

INSERT INTO Tarifas (SedeId, AlojamientoId, Temporada, TipoTemporada, NumeroPersonas, TarifaPorPersona, TarifaPorNoche, FechaInicio, FechaFin)
VALUES 
(1, 1, 'Baja', 'Normal', 4, 0, 70000, '2024-01-01', '2024-03-31'),
(2, 2, 'Alta', 'Festivo', 4, 16000, 90000, '2024-06-01', '2024-08-31'),
(3, 3, 'Baja', 'Normal', 6, 0, 70000, '2024-01-01', '2024-03-31'),
(4, 4, 'Alta', 'Festivo', 6, 16000, 90000, '2024-06-01', '2024-08-31'),
(5, 5, 'Baja', 'Normal', 4, 0, 70000, '2024-01-01', '2024-03-31'),
(6, 6, 'Alta', 'Festivo', 6, 16000, 90000, '2024-06-01', '2024-08-31')


SELECT * FROM Sedes;

SELECT * FROM Usuarios;

SELECT * FROM Alojamiento;

SELECT * FROM Tarifas;

SELECT * FROM Reservas;

SELECT * FROM Disponibilidades;


SELECT a.*
FROM Alojamiento a
JOIN Tarifas t ON a.AlojamientoId = t.AlojamientoId
WHERE EXISTS (
    SELECT 1
    FROM Disponibilidades d
    WHERE d.AlojamientoId = a.AlojamientoId AND d.Disponible = 1
);
