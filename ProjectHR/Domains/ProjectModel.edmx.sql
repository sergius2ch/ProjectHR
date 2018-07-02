
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/13/2018 19:20:05
-- Generated from EDMX file: D:\Work\ProjectHR\ProjectHR\Domains\ProjectModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DbHR];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [MaxNumberEmployees] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SkillLevels'
CREATE TABLE [dbo].[SkillLevels] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Level] int  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Firstname] nvarchar(max)  NOT NULL,
    [Secondname] nvarchar(max)  NOT NULL,
    [Lastname] nvarchar(max)  NOT NULL,
    [Birthday] datetime  NOT NULL,
    [EmploymentDate] datetime  NOT NULL,
    [ProbationPeriod_Id] int  NOT NULL,
    [CurrentDepartment_Id] int  NOT NULL,
    [Skill_Id] int  NOT NULL
);
GO

-- Creating table 'Changes'
CREATE TABLE [dbo].[Changes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ChangeDateTime] datetime  NOT NULL,
    [PropertyName] nvarchar(max)  NOT NULL,
    [NewValue] nvarchar(max)  NOT NULL,
    [OldValue] nvarchar(max)  NOT NULL,
    [SubjectEmployee_Id] int  NOT NULL
);
GO

-- Creating table 'Probations'
CREATE TABLE [dbo].[Probations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DurationInMonth] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SkillLevels'
ALTER TABLE [dbo].[SkillLevels]
ADD CONSTRAINT [PK_SkillLevels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Changes'
ALTER TABLE [dbo].[Changes]
ADD CONSTRAINT [PK_Changes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Probations'
ALTER TABLE [dbo].[Probations]
ADD CONSTRAINT [PK_Probations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ProbationPeriod_Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_EmployeeProbation]
    FOREIGN KEY ([ProbationPeriod_Id])
    REFERENCES [dbo].[Probations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeProbation'
CREATE INDEX [IX_FK_EmployeeProbation]
ON [dbo].[Employees]
    ([ProbationPeriod_Id]);
GO

-- Creating foreign key on [CurrentDepartment_Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_EmployeeDepartment]
    FOREIGN KEY ([CurrentDepartment_Id])
    REFERENCES [dbo].[Departments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeDepartment'
CREATE INDEX [IX_FK_EmployeeDepartment]
ON [dbo].[Employees]
    ([CurrentDepartment_Id]);
GO

-- Creating foreign key on [Skill_Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_EmployeeSkillLevel]
    FOREIGN KEY ([Skill_Id])
    REFERENCES [dbo].[SkillLevels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeSkillLevel'
CREATE INDEX [IX_FK_EmployeeSkillLevel]
ON [dbo].[Employees]
    ([Skill_Id]);
GO

-- Creating foreign key on [SubjectEmployee_Id] in table 'Changes'
ALTER TABLE [dbo].[Changes]
ADD CONSTRAINT [FK_ChangeEmployee]
    FOREIGN KEY ([SubjectEmployee_Id])
    REFERENCES [dbo].[Employees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ChangeEmployee'
CREATE INDEX [IX_FK_ChangeEmployee]
ON [dbo].[Changes]
    ([SubjectEmployee_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------