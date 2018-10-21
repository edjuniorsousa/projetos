﻿/*
Deployment script for C:\GITHUB\PROJETOS\TESTE\CRUD_MVC5_ANGULARJS\APP_DATA\PRODUTOS.MDF

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "C:\GITHUB\PROJETOS\TESTE\CRUD_MVC5_ANGULARJS\APP_DATA\PRODUTOS.MDF"
:setvar DefaultFilePrefix "C_\GITHUB\PROJETOS\TESTE\CRUD_MVC5_ANGULARJS\APP_DATA\PRODUTOS.MDF_"
:setvar DefaultDataPath "C:\Users\badal\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\badal\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Table].[Id] (SqlSimpleColumn) will not be renamed to id';


GO
PRINT N'Rename refactoring operation with key  is skipped, element [dbo].[Table].[valorTotal] (SqlSimpleColumn) will not be renamed to quantidade';


GO

IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRANSACTION
GO
PRINT N'Creating [dbo].[Compra]...';


GO
CREATE TABLE [dbo].[Compra] (
    [id]         INT          NOT NULL,
    [idProduto]  INT          NULL,
    [quantidade] INT          NULL,
    [valorTotal] DECIMAL (10) NULL,
    [dataVenda]  DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT N'The transacted portion of the database update succeeded.'
COMMIT TRANSACTION
END
ELSE PRINT N'The transacted portion of the database update failed.'
GO
DROP TABLE #tmpErrors
GO
PRINT N'Update complete.';


GO
