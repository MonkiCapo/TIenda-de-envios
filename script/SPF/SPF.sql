DELIMITER $$
USE TiendaOnline $$

DELIMITER $$
DROP PROCEDURE IF EXISTS AltaBancoDigital $$
CREATE PROCEDURE AltaBancoDigital (
    IN p_ID_BancoDigital TINYINT UNSIGNED,
    IN p_Nombre VARCHAR(45),
    IN p_Tipo VARCHAR(45)
)