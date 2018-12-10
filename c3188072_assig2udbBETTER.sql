--CANNOT DROP DATABASE PROPERLY
IF EXISTS(select * from sys.databases where name='udbBetter')
DROP DATABASE udbBetter
go

CREATE DATABASE udbBetter
go

USE udbBetter
go


--Creates the tblUser table
CREATE TABLE tblUser
(
 userId INT IDENTITY(100001,1) PRIMARY KEY,
 name NVARCHAR(50) NOT NULL,
 email NVARCHAR(50) NOT NULL UNIQUE,
 passcode NVARCHAR(64) NOT NULL,
 parentEmail NVARCHAR(50) NOT NULL,
 pIN INT NOT NULL,
 exercisePoints INT NOT NULL DEFAULT 0,
 retired BIT NOT NULL DEFAULT 0,
 active BIT NOT NULL DEFAULT 0,
 suspended BIT NOT NULL DEFAULT 0,
 creationDate DATETIME DEFAULT GETDATE(),
 battleOccured BIT NOT NULL DEFAULT 0
 )
 --Creates the tblElement table
 CREATE TABLE tblElement
 (
 elementId INT PRIMARY KEY,
 elementName NVARCHAR(10) NOT NULL,
 suspended BIT NOT NULL DEFAULT 0
 )
 
 CREATE TABLE tblTitan
 (
 titanId INT IDENTITY(000001,1) PRIMARY KEY,
 titanName NVARCHAR(30) NOT NULL,
 userId INT NOT NULL,
 elementId INT NOT NULL,
 experience INT NOT NULL DEFAULT 0,
 active BIT NOT NULL DEFAULT 0,
 suspended BIT NOT NULL DEFAULT 0,
 hallOfFame BIT NOT NULL DEFAULT 0,
 creationDate DATETIME  NOT NULL DEFAULT GETDATE(),
 anonymousOwner BIT NOT NULL DEFAULT 0,
 
 CONSTRAINT fk_Owner FOREIGN KEY (userId) references tblUser(userId),
 CONSTRAINT fk_Element FOREIGN KEY (elementId) references tblElement(elementId)
 ) 

 CREATE TABLE tblBattle
 (
 battleId INT IDENTITY(000001,1) PRIMARY KEY,
 battler1 INT NOT NULL,
 battler2 INT NOT NULL,
 battleTime DATETIME NOT NULL DEFAULT GETDATE(),
 battleWinner int NOT NULL,
 CONSTRAINT fk_Battler1 FOREIGN KEY (battler1) references tblTitan(titanId),
 CONSTRAINT fk_Battler2 FOREIGN KEY (battler2) references tblTitan(titanId)
 )

 CREATE TABLE tblExerciseRecord
 (
 exerciseId INT IDENTITY(1,1) PRIMARY KEY,
 userId INT NOT NULL,
 exercisePoints INT NOT NULL,
 creationDate DATETIME  NOT NULL DEFAULT GETDATE(),
 CONSTRAINT fk_ExerciseOwner FOREIGN KEY (userId) references tblUser(userId),
 )
 
 CREATE TABLE tblExperience
 (
 expId INT IDENTITY(001,1) PRIMARY KEY,
 lvl TINYINT NOT NULL,
 step TINYINT NOT NULL,
 expMax INT NOT NULL
 )
 go
 
 -- Create admin account
INSERT INTO tblUser (name, email, passcode, parentEmail, pin, exercisePoints, active) 
	VALUES ('Admin', 'support@betterTheGame.com', 'adminADMINadminADMIN', 'support@betterthegame.com', 1111, 5000, 1);
-- Create a test-user for marking purposes, sessions will start logged in as this user for testing purposes
INSERT INTO tblUser (name, email, passcode, parentEmail, pin, exercisePoints, active) 
	VALUES ('Jonathan', 'jonathan@test.com', 'JonathanPassword', 'jonathanparent@test.com', 1234, 50, 1);

-- Create our elements
INSERT INTO tblElement (elementId, elementName) VALUES (1, 'Fire');
INSERT INTO tblElement (elementId, elementName) VALUES (2, 'Water');
INSERT INTO tblElement (elementId, elementName) VALUES (3, 'Earth');
INSERT INTO tblElement (elementId, elementName) VALUES (4, 'Air');

-- Create our 8 NPCs
-- level 1's
INSERT INTO tblTitan (titanName, userId, elementId, experience, active) VALUES ('Barry', 100001, 1, 0, 1);
INSERT INTO tblTitan (titanName, userId, elementId, experience, active) VALUES ('Darry', 100001, 2, 0, 0);
INSERT INTO tblTitan (titanName, userId, elementId, experience, active) VALUES ('Berry', 100001, 3, 0, 0);
INSERT INTO tblTitan (titanName, userId, elementId, experience, active) VALUES ('Terry', 100001, 4, 0, 0);

-- level 2's
INSERT INTO tblTitan (titanName, userId, elementId, experience, active) VALUES ('Michael', 100001, 1, 205, 0);
INSERT INTO tblTitan (titanName, userId, elementId, experience, active) VALUES ('Bay', 100001, 2, 205, 0);
INSERT INTO tblTitan (titanName, userId, elementId, experience, active) VALUES ('James', 100001, 3, 205, 0);
INSERT INTO tblTitan (titanName, userId, elementId, experience, active) VALUES ('Samson', 100001, 4, 205, 0);

-- Hall of Fame NPCs 
INSERT INTO tblTitan (titanName, userId, elementId, experience, hallOfFame) VALUES ('Hero', 100001, 1, 11501, 1);
INSERT INTO tblTitan (titanName, userId, elementId, experience, hallOfFame, anonymousOwner) VALUES ('Tuscany', 100001, 2, 11501, 1, 1);



-- Create our experiance levels / steps
INSERT INTO tblExperience (lvl, step, expMax) VALUES (1,1,200);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (1,2,425);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (1,3,675);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (1,4,1000);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (2,1,1400);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (2,2,1900);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (2,3,2400);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (2,4,3000);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (3,1,3700);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (3,2,4500);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (3,3,5400);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (3,4,6400);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (4,1,7500);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (4,2,8700);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (4,3,10000);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (4,4,11500);
INSERT INTO tblExperience (lvl, step, expMax) VALUES (100,100,11501);