DELETE FROM OrderProduct;
DELETE FROM Orders;
DELETE FROM Payment;
DELETE FROM Product;
DELETE FROM Customer;

DROP TABLE IF EXISTS OrderProduct;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Payment;
DROP TABLE IF EXISTS Product;
DROP TABLE IF EXISTS Customer;

CREATE TABLE `Customer` (
`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
`Name` STRING NOT NULL,
`Street` STRING NOT NULL,
`City` STRING NOT NULL,
`State` STRING NOT NULL,
`Zip` STRING NOT NULL,
`Phone` STRING NOT NULL
);

CREATE TABLE `Orders` (
`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
`CustomerId` INTEGER,
`PaymentId` INTEGER,
`Created` DATETIME,
`Closed` DATETIME,
FOREIGN KEY(`CustomerId`) REFERENCES `Customer`(`Id`));


CREATE TABLE `Payment` (
`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
`CustomerId` INTEGER,
`PaymentType` STRING NOT NULL,
`AccountNumber` STRING NOT NULL,
FOREIGN KEY(`CustomerId`) REFERENCES `Customer`(`Id`)
);

CREATE TABLE `Product` (
`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
`CustomerId` INTEGER,
`Title` STRING NOT NULL,
`Description` STRING NOT NULL,
`Price` INTEGER NOT NULL,
`Quantity` INTEGER  NOT NULL,
`DateAdded` DATETIME,
FOREIGN KEY(`CustomerId`) REFERENCES `Customer`(`Id`)
);

CREATE TABLE `OrderProduct` (
`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
`OrdersId` INTEGER,
`ProductId` INTEGER,
FOREIGN KEY(`OrdersId`) REFERENCES `Orders`(`Id`),
FOREIGN KEY(`ProductId`) REFERENCES `Product`(`Id`));


INSERT INTO Customer
VALUES (null, 'Rang Dipkin', '123 Hosanna', 'Derpville', 'TN', '12345', '1234567890');

INSERT INTO Customer
VALUES (null, 'Bilb Ono', '123 Derp', 'Cheesetown', 'TN', '22223', '1234567890');

INSERT INTO Customer
VALUES (null, 'Hosta Mahogey', '123 Brules Lane', 'Los Angololo', 'CA', '56342', '6153443212');

INSERT INTO Customer
VALUES (null, 'Steve Buschemi', '4222 Lane way', 'Shrim', 'CO', '12355', '1114567890');

INSERT INTO Customer
VALUES (null, 'Dr. Steve Brule', '44 Cheddar Ave', 'Cheeseville', 'CA', '44332', '1232167890');

INSERT INTO Customer
VALUES (null, 'Blumpkin Stevenson', '123 Blurpkin', 'Quequea', 'NV', '111345', '3334567890');

INSERT INTO Customer
VALUES (null, 'Steve Stevenson', '123 Steve', 'Steeeeevz', 'SD', '22233', '1234569999');

INSERT INTO Customer
VALUES (null, 'Dorris Pringle-Brule', '123 Jabroni Rd', 'Jabroniville', 'PA', '12233', '44455566666');


INSERT INTO Payment
VALUES (null, 1, 'VISA', '1111111111111111');

INSERT INTO Payment
VALUES (null, 1, 'MASTER CARD', '245234345734562345');

INSERT INTO Payment
VALUES (null, 2, 'PAYPAY', '2345234523451234123');

INSERT INTO Payment
VALUES (null, 2, 'DINERS CLUB', '7634562341234');

INSERT INTO Payment
VALUES (null, 3, 'AMAZON', '73456234123412346');

INSERT INTO Payment
VALUES (null, 3, 'BITCOIN', '8978456342451234');

INSERT INTO Payment
VALUES (null, 4, 'CASH', '7654352412346457');

INSERT INTO Payment
VALUES (null, 4, 'COINS', '078546232412346456');

INSERT INTO Payment
VALUES (null, 5, 'SHEEP', '0976563123456768');

INSERT INTO Payment
VALUES (null, 5, 'VISA', '96754325234657465');

INSERT INTO Payment
VALUES (null, 6, 'MASTER CARD', '5468343513465475');

INSERT INTO Payment
VALUES (null, 6, 'DISCOVER', '97675432457864');

INSERT INTO Payment
VALUES (null, 7, 'AMAZON', '23457856796773');

INSERT INTO Payment
VALUES (null, 7, 'DISCOVER', '679683436245689');

INSERT INTO Product
VALUES (null, 1, 'Kitten Hat', 'Adorable hat for your kitten', 1995, 50, "2018-01-07");

INSERT INTO Product
VALUES (null, 1, 'Poodle Hat', 'Adorable hat for your poodle ', 1995, 30, "2018-01-20");

INSERT INTO Product
VALUES (null, 2, 'Blond Merkin', 'Blond Short Hair Merkin', 9995, 30, "2017-12-20");

INSERT INTO Product
VALUES (null, 2, 'Christmas Merkin', 'Red and Green Festive Long Hair Merkin', 20000, 30, "2017-11-10");

INSERT INTO Product
VALUES (null, 2, 'Easter Merkin', 'Celebrate the reason for the season with this pink and yellow striped short hair merkin', 5995, 30, "2018-01-31");

INSERT INTO Product
VALUES (null, 3, 'Plumbus', 'Standard Size Plumbus, use with caution', 1000, 100, "2018-02-01");

INSERT INTO Product
VALUES (null, 3, 'Meseeks Box', 'Look at me! Im Mr Meseeks!', 90000, 20, "2018-02-07");

INSERT INTO Orders
VALUES(null, 1, 1, "2018-02-01", "2018-02-01");

INSERT INTO Orders
VALUES(null, 2, 2, "2018-02-01", "2018-02-01");

INSERT INTO Orders
VALUES(null, 3, 7, "2018-02-01", "2018-02-01");

INSERT INTO Orders
VALUES(null, 4, 8, "2018-02-01", "2018-02-01");

INSERT INTO Orders
VALUES(null, 5, 10, "2018-02-01", "2018-02-01");

INSERT INTO Orders
VALUES(null, 6, 12, "2018-02-01", "2018-02-01");

INSERT INTO Orders
VALUES(null, 1, null, "2018-02-01", null);

INSERT INTO Orders
VALUES(null, 2, null, "2018-02-01", null);

INSERT INTO Orders
VALUES(null, 3, null, "2018-02-01", null);

INSERT INTO Orders
VALUES(null, 4, null, "2018-02-01", null);

INSERT INTO Orders
VALUES(null, 5, null, "2018-02-01", null);

INSERT INTO Orders
VALUES(null, 6, null, "2018-02-01", null);

INSERT INTO OrderProduct
VALUES(null, 1, 1);

INSERT INTO OrderProduct
VALUES(null, 1, 1);

INSERT INTO OrderProduct
VALUES(null, 1, 1);

INSERT INTO OrderProduct
VALUES(null, 1, 2);

INSERT INTO OrderProduct
VALUES(null, 1, 2);

INSERT INTO OrderProduct
VALUES(null, 2, 2);

INSERT INTO OrderProduct
VALUES(null, 2, 3);

INSERT INTO OrderProduct
VALUES(null, 2, 4);

INSERT INTO OrderProduct
VALUES(null, 3, 4);

INSERT INTO OrderProduct
VALUES(null, 3, 4);

INSERT INTO OrderProduct
VALUES(null, 3, 4);

INSERT INTO OrderProduct
VALUES(null, 3, 4);

INSERT INTO OrderProduct
VALUES(null, 3, 4);

INSERT INTO OrderProduct
VALUES(null, 4, 4);

INSERT INTO OrderProduct
VALUES(null, 4, 5);

INSERT INTO OrderProduct
VALUES(null, 4, 6);

INSERT INTO OrderProduct
VALUES(null, 5, 5);

INSERT INTO OrderProduct
VALUES(null, 5, 6);

INSERT INTO OrderProduct
VALUES(null, 5, 7);

INSERT INTO OrderProduct
VALUES(null, 6, 7);

INSERT INTO OrderProduct
VALUES(null, 6, 7);

INSERT INTO OrderProduct
VALUES(null, 6, 7);

INSERT INTO OrderProduct
VALUES(null, 7, 7);

INSERT INTO OrderProduct
VALUES(null, 7, 7);

INSERT INTO OrderProduct
VALUES(null, 7, 1);

INSERT INTO OrderProduct
VALUES(null, 7, 1);

INSERT INTO OrderProduct
VALUES(null, 7, 2);

INSERT INTO OrderProduct
VALUES(null, 8, 2);

INSERT INTO OrderProduct
VALUES(null, 8, 2);

INSERT INTO OrderProduct
VALUES(null, 8, 2);

INSERT INTO OrderProduct
VALUES(null, 8, 2);

INSERT INTO OrderProduct
VALUES(null, 8, 2);

INSERT INTO OrderProduct
VALUES(null, 9, 3);

INSERT INTO OrderProduct
VALUES(null, 9, 3);

INSERT INTO OrderProduct
VALUES(null, 9, 3);

INSERT INTO OrderProduct
VALUES(null, 10, 3);

INSERT INTO OrderProduct
VALUES(null, 10, 4);

INSERT INTO OrderProduct
VALUES(null, 10, 5);

INSERT INTO OrderProduct
VALUES(null, 11, 6);

-
SELECT DISTINCT * FROM
(SELECT p.* from Product p
Where p.Id NOT IN (SELECT DISTINCT ProductId FROM OrderProduct) 
AND julianday('now') - julianday(p.DateAdded) > 180
UNION
SELECT p.* FROM
(SELECT  DISTINCT ProductId FROM OrderProduct op
JOIN Orders o ON op.OrdersId = o.Id
WHERE o.Closed is null and (julianday('now') - julianday(o.created)) > 90)
JOIN Product p
ON ProductId = p.Id
WHERE ProductId NOT IN 
(SELECT DISTINCT ProductId FROM OrderProduct op
JOIN Orders o ON op.OrdersId = o.Id
WHERE o.Closed is not null)
UNION
SELECT DISTINCT p.* FROM OrderProduct op
JOIN Orders o ON op.OrdersId = o.Id
JOIN Product p  ON op.ProductID = p.Id
JOIN 
(SELECT ProductId, COUNT(*) as Total FROM OrderProduct
WHERE OrdersId in
(SELECT Id FROM Orders
WHERE Closed is not null)
GROUP BY ProductId) total_sold
ON p.Id = total_sold.ProductId
WHERE o.Closed is not null
AND julianday('now') - julianday(p.DateAdded) > 180
AND p.Quantity > total_sold.Total)