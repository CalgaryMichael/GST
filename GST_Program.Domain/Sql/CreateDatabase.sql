USE [master]

IF EXISTS(select * from sys.databases where name = 'GST')
    DROP DATABASE GST

CREATE DATABASE[GST] ON PRIMARY
    (NAME = GST
    ,FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\GST.mdf'
    ,SIZE = 8192KB
    ,MAXSIZE = UNLIMITED)
LOG ON
    (NAME = N'GST_log'
    ,FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\GST_log.ldf'
    ,SIZE = 8192KB
    ,MAXSIZE = 2048MB)