create database ProductInventoryDb
use ProductInventoryDb

create table Products
(PId int primary key,
PName nvarchar(50) not null,
Price float,
Quantity int,
MfDate date,
ExpDate date)
  
 insert into Products values
(1,'Laptop',40000.80,5,'09/25/2018','08/04/2025'),
(2,'Headphones',2000.80,10,'07/05/2021','03/26/2024'),
(3,'Smartphone',25000.99,08,'12/12/2023','11/12/2025'),
(4,'Videogame',10000.30,05,'11/25/2018','06/04/2021'),
(5,'Sunscreen Lotion',250.99,03,'12/01/2019','12/31/2020')



select * from Products

