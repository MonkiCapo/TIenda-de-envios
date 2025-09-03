DELIMITER $$
USE TiendaOnline $$

DELIMITER $$
DROP PROCEDURE IF EXISTS AltaBancoDigital $$
CREATE PROCEDURE AltaBancoDigital (OUT unIdBanco INT UNSIGNED, unNombre VARCHAR(45), unTipo VARCHAR(45))
BEGIN
    INSERT INTO BancoDigital (nombre, tipo) VALUES (unNombre, unTipo);
    SET unIdBanco = LAST_INSERT_ID();
END $$

DELIMITER $$

DROP PROCEDURE IF EXISTS AltaCliente $$
CREATE PROCEDURE AltaCliente (OUT unIdCliente INT UNSIGNED, unNombre VARCHAR(45), unEmail VARCHAR(45), unTelefono VARCHAR(15), unaDireccion VARCHAR(100))
BEGIN
    INSERT INTO Cliente (nombre, email, telefono, direccion) VALUES (unNombre, unEmail, unTelefono, unaDireccion);
    SET unIdCliente = LAST_INSERT_ID();
END $$

DELIMITER $$

DROP PROCEDURE IF EXISTS AltaCategoria $$
CREATE PROCEDURE AltaCategoria (OUT unIdCategoria INT UNSIGNED, unNombre VARCHAR(45))
BEGIN
    INSERT INTO Categoria (nombre) VALUES (unNombre);
    SET unIdCategoria = LAST_INSERT_ID();
END $$

DELIMITER $$

DROP PROCEDURE IF EXISTS AltaProducto $$
CREATE PROCEDURE AltaProducto (OUT unIdProducto INT UNSIGNED, unIdCategoria INT UNSIGNED, unNombre VARCHAR(45), unaDescripcion VARCHAR(200), unPrecio DECIMAL(10,2), unStock INT, unaCalificacion DECIMAL(5,2))
BEGIN
    INSERT INTO Producto (id_categoria, nombre, descripcion, precio, stock) VALUES (unIdCategoria, unNombre, unaDescripcion, unPrecio, unStock, unaCalificacion);
    SET unIdProducto = LAST_INSERT_ID();
END $$

DELIMITER $$

DROP PROCEDURE IF EXISTS AltaBilletera $$
CREATE PROCEDURE AltaBilletera (OUT unIdBilletera INT UNSIGNED, unIdCliente INT UNSIGNED, unIdBanco INT UNSIGNED, unSaldo DECIMAL(10,2))
BEGIN
    INSERT INTO Billetera (id_cliente, id_banco, saldo) VALUES (unIdCliente, unIdBanco, unSaldo);
    SET unIdBilletera = LAST_INSERT_ID();
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS AltaCarrito $$
CREATE PROCEDURE AltaCarrito (OUT unIdCarrito INT UNSIGNED, unIdCliente INT UNSIGNED, unaBilletera INT UNSIGNED, unTotal DECIMAL(10,2), Pagado? bool)
BEGIN
    INSERT INTO Carrito (id_cliente, id_billetera, total, Pagado?) VALUES (unIdCliente, unaBilletera, unTotal, Pagado?);
    SET unIdCarrito = LAST_INSERT_ID();
END $$

