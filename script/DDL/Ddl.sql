DROP IF EXISTS DATABASE TiendaOnline;

CREATE DATABASE TiendaOnline;

USE TiendaOnline;

CREATE TABLE Cliente (
    ID_Cliente INT UNSIGNED PRIMARY KEY,
    Nombre VARCHAR(45),
    Correo VARCHAR(45),
    Telefono VARCHAR(45),
    Direccion VARCHAR(45)
);

CREATE TABLE Categoria (
    ID_Categoria SMALLINT UNSIGNED PRIMARY KEY,
    Nombre VARCHAR(45) UNIQUE
);

CREATE TABLE BancoDigital (
    ID_BancoDigital TINYINT UNSIGNED PRIMARY KEY,
    Nombre VARCHAR(45),
    Tipo VARCHAR(45)
);

CREATE TABLE Billetera (
    ID_Billetera INT UNSIGNED PRIMARY KEY,
    ID_Cliente INT UNSIGNED,
    ID_BancoDigital TINYINT UNSIGNED,
    Saldo DECIMAL(10,2),
    FOREIGN KEY (ID_Cliente) REFERENCES Cliente(ID_Cliente),
    FOREIGN KEY (ID_BancoDigital) REFERENCES BancoDigital(ID_BancoDigital)
);

CREATE TABLE Producto (
    ID_Producto INT UNSIGNED PRIMARY KEY,
    ID_Categoria SMALLINT UNSIGNED,
    Nombre VARCHAR(45),
    Descripcion VARCHAR(45),
    Precio DECIMAL(10,2),
    Stock INT UNSIGNED,
    Calificacion DECIMAL(3,2),
    FOREIGN KEY (ID_Categoria) REFERENCES Categoria(ID_Categoria)
);

CREATE TABLE Comentario (
    FK_Cliente INT UNSIGNED,
    FK_Producto INT UNSIGNED,
    Comentario VARCHAR(300),
    Publicado DATE,
    Calificacion DECIMAL(3,2),
    PRIMARY KEY (FK_Cliente, FK_Producto),
    FOREIGN KEY (FK_Cliente) REFERENCES Cliente(ID_Cliente),
    FOREIGN KEY (FK_Producto) REFERENCES Producto(ID_Producto)
);

CREATE TABLE Carrito (
    ID_Carrito INT UNSIGNED PRIMARY KEY,
    ID_Cliente INT UNSIGNED,
    ID_Billetera INT UNSIGNED,
    Total DECIMAL(10,2),
    Pagado BOOLEAN,
    FOREIGN KEY (ID_Cliente) REFERENCES Cliente(ID_Cliente),
    FOREIGN KEY (ID_Billetera) REFERENCES Billetera(ID_Billetera)
);

CREATE TABLE ProductoCarrito (
    ID_Carrito INT UNSIGNED,
    ID_Producto INT UNSIGNED,
    Cantidad INT UNSIGNED,
    PrecioUnitario DECIMAL(10,2),
    PRIMARY KEY (ID_Carrito, ID_Producto),
    FOREIGN KEY (ID_Carrito) REFERENCES Carrito(ID_Carrito),
    FOREIGN KEY (ID_Producto) REFERENCES Producto(ID_Producto)
);

CREATE TABLE Orden (
    ID_Orden INT UNSIGNED PRIMARY KEY,
    Emision DATE,
    Total DECIMAL(10,2),
    ID_Carrito INT UNSIGNED,
    FOREIGN KEY (ID_Carrito) REFERENCES Carrito(ID_Carrito)
);

CREATE TABLE Envio (
    ID_Envio INT UNSIGNED PRIMARY KEY,
    ID_Orden INT UNSIGNED,
    Enviado DATE,
    Entregado DATE,
    Direccion VARCHAR(45),
    Estado VARCHAR(45),
    FOREIGN KEY (ID_Orden) REFERENCES Orden(ID_Orden)
);