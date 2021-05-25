create database Gestorvuelos
use Gestorvuelos

Create table Pasajeros
(
IdPasajero int primary key,
NombrePasajero varchar (30),
ApellidoPasajero varchar (30),
NumeroAsiento varchar (30),
Clase varchar (30),
)


Create table Avion
(
Matricula int primary key,
Fabricante varchar (30),
Modelo varchar (30),
Capacidad int,
AutoVuelo varchar (30),
)

create table Personal
(
IdEmpleado int primary key,
NombreEmpelado varchar (50),
ApeidoEmpleado varchar (30),
Profesion varchar (50),
Puesto varchar (30),
)

Create table Aeropuerto
(
ClaveCatastro int primary key,
Calle varchar (30),
Colonia varchar (30),
Ciudad varchar (30),
Estado varchar (30),
CodigoPostal varchar (30),
)

Create table Vuelos
(
IdVuelo int primary key,
Fecha varchar (30),
AeroOrigen varchar (30),
AeroDestino varchar (30),
) 
Delete from Aeropuerto	
Delete from Avion
Delete from Pasajeros
Delete from Personal
Delete from Vuelos


insert into Aeropuerto(ClaveCatastro,Calle,Colonia,Ciudad,Estado,CodigoPostal)values(001,'Del Aeropuerto','Aviasion','Tijuana','Baja California','22630');
insert into Avion(Matricula,Fabricante,Modelo,Capacidad,AutoVuelo)values(1721,'Airliner','Boing 747','45','Si');
insert into Pasajeros (IdPasajero,NombrePasajero,ApellidoPasajero,NumeroAsiento,Clase) values (001,'Juan','Gutierrez','13','Turista');
insert into Personal(IdEmpleado,NombreEmpelado,ApeidoEmpleado,Profesion,Puesto) values (001,'Esteban','Juarez','Piloto','Copiloto');
insert into Vuelos(IdVuelo,Fecha,AeroOrigen,AeroDestino) values (001,'20/08/2021','Juarez','Puebla');

select * from Aeropuerto
select * from Avion
select * from Pasajeros
select * from Personal
select * from Vuelos

