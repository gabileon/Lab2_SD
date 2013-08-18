/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     18-08-2013 16:43:29                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CONVERSACION') and o.name = 'FK_CONVERSA_1_USUARIO')
alter table CONVERSACION
   drop constraint FK_CONVERSA_1_USUARIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('CONVERSACION') and o.name = 'FK_CONVERSA_RELATIONS_USUARIO')
alter table CONVERSACION
   drop constraint FK_CONVERSA_RELATIONS_USUARIO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CONVERSACION')
            and   name  = 'RELATIONSHIP_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index CONVERSACION.RELATIONSHIP_2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('CONVERSACION')
            and   name  = 'RELATIONSHIP_1_FK'
            and   indid > 0
            and   indid < 255)
   drop index CONVERSACION.RELATIONSHIP_1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CONVERSACION')
            and   type = 'U')
   drop table CONVERSACION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('USUARIO')
            and   type = 'U')
   drop table USUARIO
go

/*==============================================================*/
/* Table: CONVERSACION                                          */
/*==============================================================*/
create table CONVERSACION (
   ID_CONVERSACION      int                  not null,
   NAME1                varchar(12)          not null,
   NAME2                varchar(12)          not null,
   FECHA                datetime             not null,
   TEXT                 text                 not null,
   constraint PK_CONVERSACION primary key nonclustered (ID_CONVERSACION)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_1_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_1_FK on CONVERSACION (
NAME1 ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_2_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_2_FK on CONVERSACION (
NAME2 ASC
)
go

/*==============================================================*/
/* Table: USUARIO                                               */
/*==============================================================*/
create table USUARIO (
   NICKNAME             varchar(12)          not null,
   PASSWORD             varchar(8)           not null,
   MAIL                 varchar(30)          not null,
   NOMBRE               varchar(20)          not null,
   APELLIDO             varchar(20)          not null,
   ROL                  int                  not null,
   constraint PK_USUARIO primary key nonclustered (NICKNAME)
)
go

alter table CONVERSACION
   add constraint FK_CONVERSA_1_USUARIO foreign key (NAME1)
      references USUARIO (NICKNAME)
go

alter table CONVERSACION
   add constraint FK_CONVERSA_RELATIONS_USUARIO foreign key (NAME2)
      references USUARIO (NICKNAME)
         on update cascade on delete cascade
go

