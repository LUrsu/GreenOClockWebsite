
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 12/12/2011 00:36:56
-- Generated from EDMX file: C:\Users\Ryan\Desktop\Green O'Clock\Green O'Clock\trunk\GreenOClock\GreenOClock.Data\GreenOClockEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [greenocldb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PersonalActivityPersonalProgress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Progresses_PersonalProgress] DROP CONSTRAINT [FK_PersonalActivityPersonalProgress];
GO
IF OBJECT_ID(N'[dbo].[FK_UserGroupProgress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Progresses_GroupProgress] DROP CONSTRAINT [FK_UserGroupProgress];
GO
IF OBJECT_ID(N'[dbo].[FK_UserPersonalProgress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Progresses_PersonalProgress] DROP CONSTRAINT [FK_UserPersonalProgress];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupActivityGroupProgress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Progresses_GroupProgress] DROP CONSTRAINT [FK_GroupActivityGroupProgress];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyGroupActivity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activities_GroupActivity] DROP CONSTRAINT [FK_CompanyGroupActivity];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyCompanyEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompanyEmployees] DROP CONSTRAINT [FK_CompanyCompanyEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCompanyEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompanyEmployees] DROP CONSTRAINT [FK_UserCompanyEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeTypeCompanyEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompanyEmployees] DROP CONSTRAINT [FK_EmployeeTypeCompanyEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupActivityGroupMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_GroupActivityGroupMember];
GO
IF OBJECT_ID(N'[dbo].[FK_UserGroupMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GroupMembers] DROP CONSTRAINT [FK_UserGroupMember];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonalActivity_inherits_Activity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activities_PersonalActivity] DROP CONSTRAINT [FK_PersonalActivity_inherits_Activity];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonalProgress_inherits_Progress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Progresses_PersonalProgress] DROP CONSTRAINT [FK_PersonalProgress_inherits_Progress];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupProgress_inherits_Progress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Progresses_GroupProgress] DROP CONSTRAINT [FK_GroupProgress_inherits_Progress];
GO
IF OBJECT_ID(N'[dbo].[FK_GroupActivity_inherits_Activity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activities_GroupActivity] DROP CONSTRAINT [FK_GroupActivity_inherits_Activity];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Activities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activities];
GO
IF OBJECT_ID(N'[dbo].[Companies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Companies];
GO
IF OBJECT_ID(N'[dbo].[Progresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Progresses];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[EmployeeTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeTypes];
GO
IF OBJECT_ID(N'[dbo].[CompanyEmployees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompanyEmployees];
GO
IF OBJECT_ID(N'[dbo].[GroupMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GroupMembers];
GO
IF OBJECT_ID(N'[dbo].[Activities_PersonalActivity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activities_PersonalActivity];
GO
IF OBJECT_ID(N'[dbo].[Progresses_PersonalProgress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Progresses_PersonalProgress];
GO
IF OBJECT_ID(N'[dbo].[Progresses_GroupProgress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Progresses_GroupProgress];
GO
IF OBJECT_ID(N'[dbo].[Activities_GroupActivity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activities_GroupActivity];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Activities'
CREATE TABLE [dbo].[Activities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(40)  NOT NULL,
    [Description] nvarchar(255)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Companies'
CREATE TABLE [dbo].[Companies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Country] nvarchar(50)  NOT NULL,
    [State] nvarchar(50)  NOT NULL,
    [City] nvarchar(50)  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Progresses'
CREATE TABLE [dbo].[Progresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [ActivityId] int  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NULL,
    [Description] nvarchar(255)  NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] uniqueidentifier  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'EmployeeTypes'
CREATE TABLE [dbo].[EmployeeTypes] (
    [Name] nvarchar(max)  NOT NULL,
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'CompanyEmployees'
CREATE TABLE [dbo].[CompanyEmployees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CompanyId] int  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [EmployeeTypeId] int  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'GroupMembers'
CREATE TABLE [dbo].[GroupMembers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GroupActivityId] int  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Activities_PersonalActivity'
CREATE TABLE [dbo].[Activities_PersonalActivity] (
    [UserId] uniqueidentifier  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Progresses_PersonalProgress'
CREATE TABLE [dbo].[Progresses_PersonalProgress] (
    [User_Id] uniqueidentifier  NOT NULL,
    [PersonalActivity_Id] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Progresses_GroupProgress'
CREATE TABLE [dbo].[Progresses_GroupProgress] (
    [User_Id] uniqueidentifier  NOT NULL,
    [GroupActivityId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Activities_GroupActivity'
CREATE TABLE [dbo].[Activities_GroupActivity] (
    [CompanyId] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [PK_Activities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Companies'
ALTER TABLE [dbo].[Companies]
ADD CONSTRAINT [PK_Companies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Progresses'
ALTER TABLE [dbo].[Progresses]
ADD CONSTRAINT [PK_Progresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmployeeTypes'
ALTER TABLE [dbo].[EmployeeTypes]
ADD CONSTRAINT [PK_EmployeeTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CompanyEmployees'
ALTER TABLE [dbo].[CompanyEmployees]
ADD CONSTRAINT [PK_CompanyEmployees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GroupMembers'
ALTER TABLE [dbo].[GroupMembers]
ADD CONSTRAINT [PK_GroupMembers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Activities_PersonalActivity'
ALTER TABLE [dbo].[Activities_PersonalActivity]
ADD CONSTRAINT [PK_Activities_PersonalActivity]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Progresses_PersonalProgress'
ALTER TABLE [dbo].[Progresses_PersonalProgress]
ADD CONSTRAINT [PK_Progresses_PersonalProgress]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Progresses_GroupProgress'
ALTER TABLE [dbo].[Progresses_GroupProgress]
ADD CONSTRAINT [PK_Progresses_GroupProgress]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Activities_GroupActivity'
ALTER TABLE [dbo].[Activities_GroupActivity]
ADD CONSTRAINT [PK_Activities_GroupActivity]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PersonalActivity_Id] in table 'Progresses_PersonalProgress'
ALTER TABLE [dbo].[Progresses_PersonalProgress]
ADD CONSTRAINT [FK_PersonalActivityPersonalProgress]
    FOREIGN KEY ([PersonalActivity_Id])
    REFERENCES [dbo].[Activities_PersonalActivity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonalActivityPersonalProgress'
CREATE INDEX [IX_FK_PersonalActivityPersonalProgress]
ON [dbo].[Progresses_PersonalProgress]
    ([PersonalActivity_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Progresses_GroupProgress'
ALTER TABLE [dbo].[Progresses_GroupProgress]
ADD CONSTRAINT [FK_UserGroupProgress]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserGroupProgress'
CREATE INDEX [IX_FK_UserGroupProgress]
ON [dbo].[Progresses_GroupProgress]
    ([User_Id]);
GO

-- Creating foreign key on [User_Id] in table 'Progresses_PersonalProgress'
ALTER TABLE [dbo].[Progresses_PersonalProgress]
ADD CONSTRAINT [FK_UserPersonalProgress]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPersonalProgress'
CREATE INDEX [IX_FK_UserPersonalProgress]
ON [dbo].[Progresses_PersonalProgress]
    ([User_Id]);
GO

-- Creating foreign key on [GroupActivityId] in table 'Progresses_GroupProgress'
ALTER TABLE [dbo].[Progresses_GroupProgress]
ADD CONSTRAINT [FK_GroupActivityGroupProgress]
    FOREIGN KEY ([GroupActivityId])
    REFERENCES [dbo].[Activities_GroupActivity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupActivityGroupProgress'
CREATE INDEX [IX_FK_GroupActivityGroupProgress]
ON [dbo].[Progresses_GroupProgress]
    ([GroupActivityId]);
GO

-- Creating foreign key on [CompanyId] in table 'Activities_GroupActivity'
ALTER TABLE [dbo].[Activities_GroupActivity]
ADD CONSTRAINT [FK_CompanyGroupActivity]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyGroupActivity'
CREATE INDEX [IX_FK_CompanyGroupActivity]
ON [dbo].[Activities_GroupActivity]
    ([CompanyId]);
GO

-- Creating foreign key on [CompanyId] in table 'CompanyEmployees'
ALTER TABLE [dbo].[CompanyEmployees]
ADD CONSTRAINT [FK_CompanyCompanyEmployee]
    FOREIGN KEY ([CompanyId])
    REFERENCES [dbo].[Companies]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyCompanyEmployee'
CREATE INDEX [IX_FK_CompanyCompanyEmployee]
ON [dbo].[CompanyEmployees]
    ([CompanyId]);
GO

-- Creating foreign key on [UserId] in table 'CompanyEmployees'
ALTER TABLE [dbo].[CompanyEmployees]
ADD CONSTRAINT [FK_UserCompanyEmployee]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCompanyEmployee'
CREATE INDEX [IX_FK_UserCompanyEmployee]
ON [dbo].[CompanyEmployees]
    ([UserId]);
GO

-- Creating foreign key on [EmployeeTypeId] in table 'CompanyEmployees'
ALTER TABLE [dbo].[CompanyEmployees]
ADD CONSTRAINT [FK_EmployeeTypeCompanyEmployee]
    FOREIGN KEY ([EmployeeTypeId])
    REFERENCES [dbo].[EmployeeTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeTypeCompanyEmployee'
CREATE INDEX [IX_FK_EmployeeTypeCompanyEmployee]
ON [dbo].[CompanyEmployees]
    ([EmployeeTypeId]);
GO

-- Creating foreign key on [GroupActivityId] in table 'GroupMembers'
ALTER TABLE [dbo].[GroupMembers]
ADD CONSTRAINT [FK_GroupActivityGroupMember]
    FOREIGN KEY ([GroupActivityId])
    REFERENCES [dbo].[Activities_GroupActivity]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_GroupActivityGroupMember'
CREATE INDEX [IX_FK_GroupActivityGroupMember]
ON [dbo].[GroupMembers]
    ([GroupActivityId]);
GO

-- Creating foreign key on [UserId] in table 'GroupMembers'
ALTER TABLE [dbo].[GroupMembers]
ADD CONSTRAINT [FK_UserGroupMember]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserGroupMember'
CREATE INDEX [IX_FK_UserGroupMember]
ON [dbo].[GroupMembers]
    ([UserId]);
GO

-- Creating foreign key on [Id] in table 'Activities_PersonalActivity'
ALTER TABLE [dbo].[Activities_PersonalActivity]
ADD CONSTRAINT [FK_PersonalActivity_inherits_Activity]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Activities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Progresses_PersonalProgress'
ALTER TABLE [dbo].[Progresses_PersonalProgress]
ADD CONSTRAINT [FK_PersonalProgress_inherits_Progress]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Progresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Progresses_GroupProgress'
ALTER TABLE [dbo].[Progresses_GroupProgress]
ADD CONSTRAINT [FK_GroupProgress_inherits_Progress]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Progresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Activities_GroupActivity'
ALTER TABLE [dbo].[Activities_GroupActivity]
ADD CONSTRAINT [FK_GroupActivity_inherits_Activity]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Activities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------