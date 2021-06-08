USE PROJEKT_BD2
GO

INSERT INTO dbo.Punkt VALUES('-1/1');
INSERT INTO dbo.Punkt VALUES('-9/2');
INSERT INTO dbo.Punkt VALUES('-8/3');
INSERT INTO dbo.Punkt VALUES('-7/4');
INSERT INTO dbo.Punkt VALUES('-6/5');
INSERT INTO dbo.Punkt VALUES('-5/6');
-----------------------------------------
INSERT INTO dbo.Prosta VALUES('-1/1/2/2');
INSERT INTO dbo.Prosta VALUES('0/1/2/2');
INSERT INTO dbo.Prosta VALUES('-1/0/2/2');
INSERT INTO dbo.Prosta VALUES('-1/1/0/2');
INSERT INTO dbo.Prosta VALUES('-1/1/2/0');
INSERT INTO dbo.Prosta VALUES('-1/5/2/2');
--------------------------------------------
INSERT INTO dbo.Trojkat VALUES('-1/1/20/2/3/1');
INSERT INTO dbo.Trojkat VALUES('0/0/0/3/4/0');
INSERT INTO dbo.Trojkat VALUES('-1/1/21/2/0/1');
INSERT INTO dbo.Trojkat VALUES('0/0/0/13/14/0');
INSERT INTO dbo.Trojkat VALUES('2/1/10/2/3/1');
INSERT INTO dbo.Trojkat VALUES('1/2/3/4/5/1');
----------------------------------
INSERT INTO dbo.Kwadrat VALUES('0/0/0/4/4/4/4/0');
INSERT INTO dbo.Kwadrat VALUES('0/0/0/5/5/5/5/0');
INSERT INTO dbo.Kwadrat VALUES('0/0/0/3/3/3/3/0');
INSERT INTO dbo.Kwadrat VALUES('0/0/0/1/1/1/1/0');
INSERT INTO dbo.Kwadrat VALUES('0/0/0/2/2/2/2/0');
INSERT INTO dbo.Kwadrat VALUES('0/0/0/6/6/6/6/0');
-------------------------------------------------
INSERT INTO dbo.Prostokat VALUES('0/0/0/4/4/4/4/0');
INSERT INTO dbo.Prostokat VALUES('0/0/0/5/6/5/6/0');
INSERT INTO dbo.Prostokat VALUES('0/0/0/13/12/13/12/0');
INSERT INTO dbo.Prostokat VALUES('0/0/0/4,5/6/4,5/6/0');
INSERT INTO dbo.Prostokat VALUES('0/0/0/4/6,1/4/6,1/0');
INSERT INTO dbo.Prostokat VALUES('0/0/0/8/9,2/8/9,2/0');
-------------------------------------------------
INSERT INTO dbo.Rownoleglobok VALUES('0/0/0/4/4/4/4/0');
INSERT INTO dbo.Rownoleglobok VALUES('0/0/0/13/4/13/4/0');
INSERT INTO dbo.Rownoleglobok VALUES('0/0/5/0/6/7/1/7');
INSERT INTO dbo.Rownoleglobok VALUES('0/0/5/0/6/9/1/9');
INSERT INTO dbo.Rownoleglobok VALUES('0/0/5/0/7/7/2/7');
INSERT INTO dbo.Rownoleglobok VALUES('0/0/4/0/6/7/2/7');
-------------------------------------------------
INSERT INTO dbo.Trapez VALUES('0/0/0/4/4/4/4/0');
INSERT INTO dbo.Trapez VALUES('2/0/2/2/0/4/0/0');
INSERT INTO dbo.Trapez VALUES('0/-3/0/4/2/2/2/0');
INSERT INTO dbo.Trapez VALUES('-2/0/6/0/4/7/0/7');
INSERT INTO dbo.Trapez VALUES('-3/0/7/0/4/5/0/5');
INSERT INTO dbo.Trapez VALUES('-1/0/5/0/4/7/0/7');
-------------------------------------------------
INSERT INTO dbo.Kolo VALUES('0/0/0/4');
INSERT INTO dbo.Kolo VALUES('0/0/5/0');
INSERT INTO dbo.Kolo VALUES('0/0/13/4');
INSERT INTO dbo.Kolo VALUES('0/0/4/4');
INSERT INTO dbo.Kolo VALUES('0/0/12/4');
INSERT INTO dbo.Kolo VALUES('0/0/3/-1');