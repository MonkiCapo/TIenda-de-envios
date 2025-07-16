# TIenda-de-envios
```mermaid
erDiagram
    Cliente {
        INT_UNS           ID_Cliente PK
        VARCHAR(45)    Nombre 
        VARCHAR(45)    Correo
        VARCHAR(45)    Telefono
        VARCHAR(45)    Direccion
    }
    Categoria {
        SMALLINT_UNS   ID_Categoria PK
        VARCHAR(45)    Nombre UK
    }
    BancoDigital {
        TINYINT_UNS    ID_BancoDigital PK
        VARCHAR(45)    Nombre
        VARCHAR(45)    Tipo 
    }
    Billetera{
        INT  ID_Billetera PK
        INT_UNS ID_Cliente FK 
        TINYINT_UNS ID_BancoDigital FK
        DECIMAL Saldo
    }

    Comentario {
        INT_UNS FK_Cliente PK,FK
        INT_UNS FK_Producto PK,FK
        VARCHAR(300) Comentario
        DATE Publicado
        DECIMAL Calificacion
    }
    Producto {
        INT_UNS        ID_Producto PK
        INT_UNS        ID_Categoria FK
        VARCHAR(45)    Nombre
        VARCHAR(45)    Descripcion
        DECIMAL        Precio
        INT_UNS        Stock
        DECIMAL        Calificacion
    }

    Carrito {
        INT_UNS        ID_Carrito PK
        INT_UNS        ID_Cliente FK
        INT_UNS        ID_Billetera FK
        DECIMAL       Total
        BOOL Pagado
    }
    ProductoCarrito{
        INT_UNS ID_Carrito PK,FK
        INT_UNS ID_Producto PK,FK
        INT_UNS Cantidad
        DECIMAL PrecioUnitario
    }
    Orden {
        INT_UNS            ID_Orden PK
        DATE           Emision
        DECIMAL          Total
        INT_UNS            ID_Carrito FK
    }
    Envio {
        INT_UNS        ID_Envio PK
        INT_UNS        ID_Orden FK
        DATE           Enviado
        DATE           Entregado
        VARCHAR(45)    Direccion
        VARCHAR(45)    Estado
    }

    Categoria  ||--o{ Producto : ""
    Cliente    ||--o{ Billetera : ""
    Cliente    ||--o{ Carrito : ""
    Cliente ||--o{ Comentario : ""
    Producto ||--o{ ProductoCarrito : ""
    Producto||--o{ Comentario : ""
    BancoDigital ||--o{ Billetera : ""
    Billetera ||--o{ Carrito : ""
     Carrito ||--o{ ProductoCarrito : ""
    Orden ||--|| Envio : ""
    Carrito ||--|| Orden : ""
```
## Procedimientos

Procedimientos encargados de dar de alta a las tablas

``` SQL
CREATE PROCEDURE InsBancoDigital (nombre VARCHAR(45), tipo VARCHAR(45))
BEGIN
    INSERT INTO BancoDigital(Nombre, Tipo)
    VALUES (nombre, tipo);
END;
CREATE PROCEDURE InsCategoria (unNombre VARCHAR(45))
BEGIN
    INSERT INTO Categoria(Nombre)
    VALUES (unNombre);
END;
CREATE PROCEDURE InsCliente (unNombre VARCHAR(45), unCorreo VARCHAR(60), unTelefono VARCHAR(10), unDireccion VARCHAR(60))
BEGIN
    INSERT INTO Cliente (Nombre,Correo,Telefono,Direccion)
    VALUES (unNombre, unCorreo, unTelefono, unDireccion);
END;

CREATE PROCEDURE InsBilletera ( unID_Cliente INT UNSIGNED, unID_BancoDigital TINYINT UNSIGNED, unSaldo DECIMAL(10,2) UNSIGNED)
BEGIN
    INSERT INTO Billetera( ID_Cliente, ID_BancoDigital, Saldo)
    VALUES ( unID_Cliente, unID_BancoDigital, unSaldo);
END;

CREATE PROCEDURE InsProducto (unNombre VARCHAR(300), unDescripcion VARCHAR(700), unPrecio DECIMAL(10,2) UNSIGNED , unStock INT UNSIGNED, unID_Categoria INT UNSIGNED)
BEGIN
    INSERT INTO Producto(Nombre, Descripcion, Precio, Stock, ID_Categoria)
    VALUES (unNombre, unDescripcion, unPrecio, unStock, unID_Categoria);
END;

CREATE PROCEDURE InsComentario (unID_Producto INT UNSIGNED, unID_Cliente INT UNSIGNED, unComentario VARCHAR(700), unEstrellas DECIMAL(2,1) UNSIGNED)
BEGIN
    INSERT INTO Comentario(ID_Producto, ID_Cliente, Publicado, Comentario, Estrellas)
    VALUES (unID_Producto, unID_Cliente,CURDATE() ,unComentario, unEstrellas);
END;

CREATE PROCEDURE InsCarrito(unID_Carrito INT UNSIGNED, unID_Cliente INT UNSIGNED, unID_Billetera TINYINT UNSIGNED)
BEGIN
    INSERT INTO Carrito (ID_Carrito, ID_Cliente, ID_Billetera)
    VALUES (unID_Carrito, unID_Cliente, unID_Billetera);
END;

CREATE PROCEDURE InsProductoCarrito ( unID_Carrito INT UNSIGNED, unID_Producto INT UNSIGNED, uncantidad INT UNSIGNED)
BEGIN
    SELECT uncantidad * precio INTO @total 
    FROM Producto
    WHERE ID_Producto=unID_Producto;

    INSERT INTO ProductoCarrito (ID_Carrito, ID_Producto, cantidad, precioUnitario)
    VALUES (unID_Carrito, unID_Producto, uncantidad, @total);
END;

```
