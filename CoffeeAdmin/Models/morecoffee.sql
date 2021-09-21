create database morecoffee;

use morecoffee;

create table category (
	id varchar(4) not null,
    name varchar(20) not null,
    description varchar(200) not null,
    username varchar(20),
    primary key(id)
);

create table product (
	id int not null auto_increment,
    name varchar(20) not null,
    description varchar(200) not null,
    price decimal(6,2) not null,
    categoryId varchar(4) not null,
    username varchar(20),
    primary key(id),
    foreign key (categoryId) references category(id)
);

insert into category (id, name, description) values ('COFF','Coffee','Our finest blends roasted in house');
insert into category (id, name, description) values ('PAST','Pastries','Wonderful pastries baked locally');

insert into product (name, description, price, categoryId) values ('Midnight Blend','Dark Roast',2.00,'COFF');
insert into product (name, description, price, categoryId) values ('Croissant','Flakey Buttery Layers',3.50,'PAST');
insert into product (name, description, price, categoryId) values ('Golden Blend','Light Roast',2.00,'COFF');


