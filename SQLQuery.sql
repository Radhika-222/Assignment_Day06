create database ProductInventoryDb
use ProductInventoryDb

create table Products
(PId int primary key,
PName nvarchar(50) not null,
Price float,
Quantity int,
MfDate date,
ExpDate date)


select * from Products

