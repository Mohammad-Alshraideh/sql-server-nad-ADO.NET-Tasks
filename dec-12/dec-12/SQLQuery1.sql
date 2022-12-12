create table customers
(
ID int primary key,
Fname varchar(20),
Lname varchar(20),
phoneNumber varchar(15),
email varchar(30),
street varchar(20),
city varchar(20),
zip_code int
);

create table orders
(
orderId int primary key,
CustomerID int FOREIGN KEY REFERENCES customers(ID),
Total_Price float,
);

create table products
(
product_id int,
product_name varchar(15),
product_price float,
);

create table employees 
(
ID int primary key,
Fname varchar(20),
Lname varchar(20),
position varchar(15),
phoneNumber varchar(15),
email varchar(30),
);