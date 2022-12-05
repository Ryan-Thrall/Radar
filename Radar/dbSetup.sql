-- Active: 1669487450873@@SG-PersonalProjects-6940-mysql-master.servers.mongodirector.com@3306@Radar

CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture',
        wins int DEFAULT 0,
    ) default charset utf8 COMMENT '';

SELECT * FROM accounts;

CREATE TABLE
    IF NOT EXISTS maps(
        -- DBITEM stuffs
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        -- Unique Stuff
        name VARCHAR(255) NOT NULL,
        size INT NOT NULL,
        gameId INT NOT NULL
    );

CREATE TABLE
    IF NOT EXISTS games(
        -- DBITEM stuffs
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        -- Has a Creator stuffs
        creatorId varchar(255) NOT NULL COMMENT 'Account Id',
        -- Creator Input
        name varchar(255) NOT NULL COMMENT 'Game Name',
        mapId INT COMMENT 'Game Map Id',
        playerLimit INT NOT NULL,
        isPrivate TINYINT,
        pin INT DEFAULT 0,
        -- Game Data
        playerCount INT DEFAULT 0,
        status VARCHAR(255) NOT NULL,
        winnerId VARCHAR(255),
        Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
        Foreign Key (winnerId) REFERENCES accounts (id) ON DELETE CASCADE,
        Foreign Key (mapId) REFERENCES maps(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

SELECT * FROM games;

CREATE TABLE
    IF NOT EXISTS players(
        -- DBITEM stuffs
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        -- Has a Creator stuffs
        creatorId varchar(255) NOT NULL,
        -- Player Data
        playerNum INT NOT NULL,
        gameId INT NOT NULL,
        status VARCHAR(255) NOT NULL,
        techTree VARCHAR(255),
        resources VARCHAR(255),
        faction VARCHAR(255),
        Foreign Key (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';