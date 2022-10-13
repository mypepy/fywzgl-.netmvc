create database MM
go
use mm
go
create table users  --用户表
(
uid int primary key identity,
uname varchar(20) not null,
pwd varchar(20) not null,
sex char(2),
age int,
birth Datetime default(getdate()) not null,
email varchar(30),
tel varchar(20)
)
go
create table type  --类型表
(
tid int primary key identity,
tname  varchar(20) not null,
createdate datetime default(getdate()),
editdate datetime default(getdate()),
tremark varchar(50)
)
go
create table goods  --物资表
(
gid int primary key identity,
gname varchar(20) not null,
img varchar(500),
source varchar(20),
num int not null,
unit varchar(20),
gremark varchar(50),
tid int foreign key references type(tid)
)
go
create table plans  --计划表
(
pid int primary key identity,
pname varchar(20) not null,
ptime datetime default(getdate()) not null,
pmark varchar(500)
)
go
--drop table users
insert into users(uname,pwd,sex,age,email,tel)values
('adin','123','男',16,'sda@qq.com','13019888921')
select * from users

--drop table type
insert into type(tname,tremark)values
('交通工具','包括汽车，飞机'),
('医疗用品','包括口罩，防护服'),
('食物','包括面包，方便面')
select * from type

--drop table goods
insert into goods(gname,img,source,num,unit,gremark,tid)values
('救艇','img/lunbo1.png','购买',1,'艘','仅此一辆，请爱惜',1)
select * from goods

--drop table plans
insert into plans(pname,pmark)values
('派吃口罩','派送400个口罩到深圳')
select * from plans

select gid,gname,img,source,num,unit,gremark,tname from goods,type where type.tid=goods.tid