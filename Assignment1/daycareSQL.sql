/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2018-12-31 11:13:55 PM                       */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CHILD') and o.name = 'FK_CHILD_BELONG_TO_GROUP')
alter table CHILD
   drop constraint FK_CHILD_BELONG_TO_GROUP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PARENT') and o.name = 'FK_PARENT_HAVE_CHILD')
alter table PARENT
   drop constraint FK_PARENT_HAVE_CHILD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PARENT') and o.name = 'FK_PARENT_INCLUDE_RELATION')
alter table PARENT
   drop constraint FK_PARENT_INCLUDE_RELATION
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CHILD')
            and   name  = 'BELONG_TO_FK'
            and   indid > 0
            and   indid < 255)
   drop index CHILD.BELONG_TO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CHILD')
            and   type = 'U')
   drop table CHILD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"GROUP"')
            and   type = 'U')
   drop table "GROUP"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PARENT')
            and   name  = 'INCLUDE_FK'
            and   indid > 0
            and   indid < 255)
   drop index PARENT.INCLUDE_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PARENT')
            and   name  = 'HAVE_FK'
            and   indid > 0
            and   indid < 255)
   drop index PARENT.HAVE_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PARENT')
            and   type = 'U')
   drop table PARENT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RELATIONSHIP')
            and   type = 'U')
   drop table RELATIONSHIP
go

/*==============================================================*/
/* Table: CHILD                                                 */
/*==============================================================*/
create table CHILD (
   CHILDID              int                  not null,
   GROUPID              int                  not null,
   CHILD_FNAME          varchar(25)          not null,
   CHILD_LNAME          varchar(25)          not null,
   CHILD_DOB            datetime             null,
   CHILD_GENDER         char(6)              null,
   CHILD_SIN            varchar(10)          null,
   CHILD_ALLERGIES      varchar(50)          null,
   constraint PK_CHILD primary key nonclustered (CHILDID)
)
go

/*==============================================================*/
/* Index: BELONG_TO_FK                                          */
/*==============================================================*/
create index BELONG_TO_FK on CHILD (
GROUPID ASC
)
go

/*==============================================================*/
/* Table: "GROUP"                                               */
/*==============================================================*/
create table "GROUP" (
   GROUPID              int                  not null,
   GROUP_AGEMIN         numeric(2)           null,
   GROUP_AGEMAX         numeric(2)           null,
   GROUP_STATUS         varchar(10)          null,
   GROUP_MAXNUM         numeric(2)           null,
   constraint PK_GROUP primary key nonclustered (GROUPID)
)
go

/*==============================================================*/
/* Table: PARENT                                                */
/*==============================================================*/
create table PARENT (
   PARENT_FNAME         varchar(25)          not null,
   PARENT_LNAME         varchar(25)          not null,
   PARENT_DOB           datetime             null,
   PARENT_EMAIL         varchar(25)          null,
   PARENT_PHONENUM      varchar(25)          null,
   PARENT_STREET        varchar(30)          null,
   PARENT_CITY          varchar(30)          null,
   PARENT_PROVINCE      varchar(20)          null,
   PARENT_POSTCODE      varchar(20)          null,
   RELATIONSHIPID       int                  not null,
   CHILDID              int                  not null,
   constraint PK_PARENT primary key nonclustered (RELATIONSHIPID, CHILDID)
)
go

/*==============================================================*/
/* Index: HAVE_FK                                               */
/*==============================================================*/
create index HAVE_FK on PARENT (
CHILDID ASC
)
go

/*==============================================================*/
/* Index: INCLUDE_FK                                            */
/*==============================================================*/
create index INCLUDE_FK on PARENT (
RELATIONSHIPID ASC
)
go

/*==============================================================*/
/* Table: RELATIONSHIP                                          */
/*==============================================================*/
create table RELATIONSHIP (
   RELATIONSHIPID       int                  not null,
   RELATIONSHIP_NAME    varchar(6)           null,
   constraint PK_RELATIONSHIP primary key nonclustered (RELATIONSHIPID)
)
go

alter table CHILD
   add constraint FK_CHILD_BELONG_TO_GROUP foreign key (GROUPID)
      references "GROUP" (GROUPID)
go

alter table PARENT
   add constraint FK_PARENT_HAVE_CHILD foreign key (CHILDID)
      references CHILD (CHILDID)
go

alter table PARENT
   add constraint FK_PARENT_INCLUDE_RELATION foreign key (RELATIONSHIPID)
      references RELATIONSHIP (RELATIONSHIPID)
go

