create table Role
(
	RoleId int primary key identity,
	RoleName varchar(100) not null
)
create table Country
(
	CountryId int primary key identity,
	CountryName varchar(100) not null
)
create table State
(
	StateId int primary key identity,
	StateName varchar(100) not null,
	CountryId int,
	foreign key (CountryId) references Country(CountryId)
)

create table City
(
	CityId int primary key identity,
	CityName varchar(100) not null,
	StateId int,
	foreign key (StateId) references State(StateId)
)

create table ModeMaster 
(
	ModeId int primary key identity,
	ModeName varchar(100)
)

Create table TermMaster
(
	TermId int primary key identity,
	TermName varchar(100)
)

create table PlanMaster
(
	PlanId int primary key identity,
	PlaneCode varchar(100) not null,
	PlanName varchar(100) not null
)

create table UserMaster
(
	UserId int primary key identity,
	UserName varchar(100) not null,
	Password varchar(100) not null,
	CreatedOn datetime not null,
	CreatedBy int ,
	RoleId int,
	foreign key (RoleId) references Role(RoleId)
)


Create table UserDetailMaster
(
	UserDetailId int primary key identity,
	FirstName varchar(100) not null,
	MiddleName varchar(100) not null,
	LastName varchar(100) not null,
	Mobile varchar(100) not null,
	Email varchar(100) not null,
	Address varchar(300) not null,
	PinCode varchar(100),
	AgentCode varchar(100),
	UserId int,
	CityId int,
	foreign key (CityId) references City(CityId),
	foreign key (UserId) references UserMaster(UserId)
)



Create table ClientAssuranceDetail
(
	ClientAssuranceDetailId int primary key identity,
	Premium varchar(100),
	PolicyNumber varchar(100),
	SumOfAssurance varchar(100),
	DateOfMaturity datetime,
	NextPrimiumDate datetime,
	Nominee varchar(100),
	PlanId int,
	TermId int,
	ModeId int,
	ClientDetailId int,
	foreign key (PlanId) references PlanMaster(PlanId),
	foreign key (TermId) references TermMaster(TermId),
	foreign key (ModeId) references ModeMaster(ModeId),
	foreign key (ClientDetailId) references ClientDetailMaster(ClientDetailId)
)
