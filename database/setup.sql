-- Requires CREATE TABLE permission in the selected database db_u75_p18.
USE `db_u75_p18`;

CREATE TABLE IF NOT EXISTS `Users` (
    `Id` INT NOT NULL AUTO_INCREMENT,
    `Fio` VARCHAR(255) NOT NULL,
    `Login` VARCHAR(100) NOT NULL,
    `Password` VARCHAR(255) NOT NULL,
    `Role` VARCHAR(50) NOT NULL,
    PRIMARY KEY (`Id`),
    UNIQUE KEY `UQ_Users_Login` (`Login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `Users` (`Fio`, `Login`, `Password`, `Role`)
VALUES ('Пользователь', 'user', 'user', 'AuthorizedClient')
ON DUPLICATE KEY UPDATE
    `Fio` = VALUES(`Fio`),
    `Password` = VALUES(`Password`),
    `Role` = VALUES(`Role`);
