--CREATE DATABASE PROJEKT_BD2
--GO

USE PROJEKT_BD2
GO

CREATE TABLE Punkt(punkt dbo.Punkt);
CREATE TABLE Prosta(prosta dbo.Prosta);
CREATE TABLE Trojkat(trojkat dbo.Trojkat);
CREATE TABLE Kwadrat(kwadrat dbo.Kwadrat);
CREATE TABLE Prostokat(prostokat dbo.Prostokat);
CREATE TABLE Rownoleglobok(rownoleglobok dbo.Rownoleglobok);
CREATE TABLE Trapez(trapez dbo.Trapez);
CREATE TABLE Kolo(kolo dbo.Kolo);

DROP TABLE Prosta;
DROP TABLE Punkt;
DROP TABLE Prostokat;
DROP TABLE Rownoleglobok;
DROP TABLE Trapez;
DROP TABLE Kolo;
DROP TABLE Kwadrat;
DROP TABLE Trojkat;


INSERT INTO Punkt(punkt) VALUES('-1/1');
SELECT punkt.ToString() as pkt from Punkt;
-----------------------------------------
INSERT INTO Prosta(prosta) VALUES('-1/1/2/2');
--INSERT INTO Prosta(prosta) VALUES('0/0/0/0');

SELECT prosta.ToString() as prosta from Prosta;
--------------------------------------------
INSERT INTO Trojkat(trojkat) VALUES('-1/1/20/2/3/1');
INSERT INTO Trojkat(trojkat) VALUES('0/0/0/3/4/0');

SELECT trojkat.ToString() as trojkat from Trojkat;
SELECT trojkat.WyznaczPole() as trojkat from Trojkat;
SELECT trojkat.WyznaczObwod() as trojkat from Trojkat;
----------------------------------
INSERT INTO Kwadrat(kwadrat) VALUES('0/0/0/4/4/4/4/0');

SELECT kwadrat.ToString() as kw from Kwadrat;
SELECT kwadrat.WyznaczObwod() as kw from Kwadrat;
SELECT kwadrat.WyznaczPole() as kw from Kwadrat;
-------------------------------------------------
INSERT INTO Prostokat(prostokat) VALUES('0/0/0/4/4/4/4/0');

SELECT prostokat.ToString() as prst from Prostokat;
SELECT prostokat.WyznaczObwod() as prst from Prostokat;
SELECT prostokat.WyznaczPole() as prst from Prostokat;
-------------------------------------------------
INSERT INTO Rownoleglobok(rownoleglobok) VALUES('0/0/0/4/4/4/4/0');

SELECT rownoleglobok.ToString() as rw from Rownoleglobok;
SELECT rownoleglobok.WyznaczObwod() as rw from Rownoleglobok;
SELECT rownoleglobok.WyznaczPole() as rw from Rownoleglobok;
-------------------------------------------------
INSERT INTO Trapez(trapez) VALUES('0/0/0/4/4/4/4/0');
INSERT INTO Trapez(trapez) VALUES('2/0/2/2/0/4/0/0');
INSERT INTO Trapez(trapez) VALUES('0/-3/0/4/2/2/2/0');

SELECT trapez.ToString() as tr from Trapez;
SELECT trapez.WyznaczObwod() as tr from Trapez;
SELECT trapez.WyznaczPole() as tr from Trapez;
-------------------------------------------------
INSERT INTO Kolo(kolo) VALUES('0/0/0/4');

SELECT kolo.ToString() as ko from Kolo;
SELECT kolo.WyznaczObwod() as ko from Kolo;
SELECT kolo.WyznaczPole() as ko from Kolo;