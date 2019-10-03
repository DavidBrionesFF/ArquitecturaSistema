create database mvc_cliente;

use mvc_cliente;

create table nota(
	id int not null primary key IDENTITY,
	titulo varchar(50) not null,
	mensaje varchar(50) not null
);
