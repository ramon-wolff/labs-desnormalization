-- https://learn.microsoft.com/pt-br/sql/relational-databases/views/create-indexed-views?view=sql-server-ver16#TsqlProcedure
--Set the options to support indexed views.
SET NUMERIC_ROUNDABORT OFF;
SET ANSI_PADDING,
    ANSI_WARNINGS,
    CONCAT_NULL_YIELDS_NULL,
    ARITHABORT,
    QUOTED_IDENTIFIER,
    ANSI_NULLS ON;

--Create view with SCHEMABINDING.
IF OBJECT_ID('dbo.UserSummary', 'view') IS NOT NULL
    DROP VIEW dbo.UserSummary;
GO

CREATE VIEW dbo.UserSummary
    WITH SCHEMABINDING
AS
SELECT u.Id AS UserId, 
	   u.Name AS [Name], 
	   u.Email AS Email, 
	   t.Name AS TenantName,
	   r.Name AS RoleName
FROM dbo.Users u INNER JOIN
	 dbo.Tenants t on u.TenantId = t.Id INNER JOIN 
	 dbo.Roles r on u.RoleId = r.Id;
GO

--Create an index on the view. (materialization)
CREATE UNIQUE CLUSTERED INDEX IDX_V1 ON dbo.UserSummary (
    UserId
);
GO