drop database Student
create database Student
go
use Student
go
create table Student_Info
(
	Name varchar(20),
	Registration_No varchar(11)not null primary key,
	Exam varchar(15),
	Sesson varchar(10) check (Sesson like '20[0-9][0-9]-20[0-9][0-9]'),
	Board varchar(10),
	Contact_No varchar(20) check (Contact_No like '+[0-9][0-9]01[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
	
)
go
insert into Student_Info (Name,Registration_No,Exam, Sesson,Board,Contact_No)
values('Mimma Aker','123456','Masters','2013-2014','Dhaka','+8801680385421')
go
select*from Student_Info
go
update Student_Info set Name = 'Lira',  Exam='Masters', Sesson='2012-2015', Board='Dhaka', Contact_No='+8801914528321' where Registration_No ='123456'
go
delete from Student_Info where Registration_No='123456'


