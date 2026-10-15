-- Safe to run more than once: existing tables and rows are preserved.
CREATE DATABASE IF NOT EXISTS `DemoExam2026`
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_unicode_ci;

USE `DemoExam2026`;

CREATE TABLE IF NOT EXISTS `Users` (
    `Id` INT NOT NULL AUTO_INCREMENT,
    `Fio` VARCHAR(255) NOT NULL,
    `Login` VARCHAR(100) NOT NULL,
    `Password` VARCHAR(255) NOT NULL,
    `Role` VARCHAR(50) NOT NULL,
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Import the real user rows from the exam's user_import.xlsx separately.
-- Role values must be AuthorizedClient, Manager, or Administrator.
