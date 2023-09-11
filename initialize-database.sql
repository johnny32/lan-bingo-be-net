DROP TABLE Bingo;
DROP TABLE Users;
DROP TABLE Cards;

CREATE TABLE Users (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    description VARCHAR(20) NOT NULL
);

CREATE TABLE Cards (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    description NVARCHAR(120) NOT NULL,
    is_checked INTEGER NOT NULL
);

CREATE TABLE Bingo (
    user_id INTEGER,
    card_id INTEGER,
    PRIMARY KEY (user_id, card_id),
    FOREIGN KEY (user_id) REFERENCES Users(id),
    FOREIGN KEY (card_id) REFERENCES Cards(id)
);

INSERT INTO Cards (description, is_checked) VALUES 
('El gato se sube encima de alguien de imprevisto', 0),
('Cables de ethernet demasiado cortos', 0),
('Ferran no queda en el top 3 en el Rune', 0),
('Varias horas instalando juegos', 0),
('Pere se atraganta', 0),
('Más de 10 personas', 0),
('Se va la luz', 0),
('Ferran come algo del suelo', 0),
('El viernes hasta las 4AM', 0),
('Aythami viene', 0),
('Peditos', 0),
('¡Viene Juanito!', 0),
('Uno o más juegos no funcionan', 0),
('Friegue de paquete al pasar detrás de alguien', 0),
('Más de uno juegan a Mission:Humanity', 0),
('El domingo sólo quedan 4 personas y están cadaver', 0),
('Alguien se come las sobras del otro sin permiso', 0),
('Alguien va sin cascos', 0),
('Alguien se queja de la peste de los calamares', 0),
('Equipos mal equilibrados', 0),
('Menos de 8 personas', 0),
('Ferran tiene ultratumba', 0),
('Cae bebida o comida encima de un teclado', 0),
('Gol en propia al Rocket League', 0),
('Alguien se queja de equipos desequilibrados', 0),
('Se rompe un vaso o plato', 0),
('Mal perdedor lloriqueando', 0),
('Los vecinos se quejan del ruido', 0),
('Teamkilling', 0),
('Número impar de gente', 0),
('La mesa de la cocina no pasa por la puerta', 0),
('Falta de alargos', 0),
('No hay camino cómodo hacia la cocina', 0),
('Alguien se deja un ingrediente en el pedido', 0),
('Alguien se va antes de las 00:00 (Excepto Yusep)', 0),
('4 juegos distintos simultáneamente', 0),
('Varios pedidos llegan a la vez', 0),
('Un confirmed se escaquea', 0),
('Cabemos de sobras', 0),
('Ferran arruina una partida', 0),
('Pere se harta de alguien cantando', 0),
('Pere tira comida al suelo', 0),
('Alberto ragequitea', 0),
('Discusión/War', 0);

INSERT INTO Users (description) VALUES
('Johnny'),
('Anna'),
('Lorenz'),
('Alberto'),
('Pere'),
('Ferran'),
('Dani');