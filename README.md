# TIenda-de-envios

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
