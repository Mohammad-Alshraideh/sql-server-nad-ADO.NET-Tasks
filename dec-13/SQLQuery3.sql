create database task2;
create table customers
(
customer_id int identity(1,1) primary key,
firstName varchar(20),
lastName varchar(20),
);
create table products
(
product_id int identity(1,1) primary key,
product_name varchar(20) not null,
product_price int not null
);

create table orders
(
order_id int identity(1,1) primary key,
product_key int,
FOREIGN KEY (product_key) REFERENCES products(product_id),
customer_id int,
FOREIGN KEY (customer_id) REFERENCES customers(customer_id),

);

select * from customers;
select * from products;
select * from orders;

insert into customers values('mohammad' , 'alshraideh');
insert into customers values('moath' , 'bdoor');
insert into products values('rice' , 5);
insert into products values('milk' , 10);
insert into orders values(1,2);
insert into orders values(1,1);
insert into orders values(2,2);
select order_id , product_name , product_price ,firstName , lastName from orders
inner join products on orders.product_key = products.product_id
inner join customers on orders.customer_id = customers.customer_id;
