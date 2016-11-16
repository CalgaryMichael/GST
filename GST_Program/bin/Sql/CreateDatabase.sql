USE [master]

IF EXISTS(select * from sys.databases where name = 'GST')
    DROP DATABASE GST

CREATE DATABASE [GST]