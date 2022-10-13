create database MM
go
use mm
go
create table users  --�û���
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
create table type  --���ͱ�
(
tid int primary key identity,
tname  varchar(20) not null,
createdate datetime default(getdate()),
editdate datetime default(getdate()),
tremark varchar(50)
)
go
create table goods  --���ʱ�
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
create table plans  --�ƻ���
(
pid int primary key identity,
pname varchar(20) not null,
ptime datetime default(getdate()) not null,
pmark varchar(500)
)
go
--drop table users
insert into users(uname,pwd,sex,age,email,tel)values
('adin','123','��',16,'sda@qq.com','13019888921')
select * from users

--drop table type
insert into type(tname,tremark)values
('��ͨ����','�����������ɻ�'),
('ҽ����Ʒ','�������֣�������'),
('ʳ��','���������������')
select * from type

--drop table goods
insert into goods(gname,img,source,num,unit,gremark,tid)values
('��ͧ','img/lunbo1.png','����',1,'��','����һ�����밮ϧ',1)
select * from goods

--drop table plans
insert into plans(pname,pmark)values
('�ɳԿ���','����400�����ֵ�����')
select * from plans

select gid,gname,img,source,num,unit,gremark,tname from goods,type where type.tid=goods.tid