/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[SecondName]
      ,[FirstName]
      ,[ThirdName]
      ,[Birthday]
      ,[Serial]
      ,[Number]
  FROM [PawnshopDB].[dbo].[Customers]