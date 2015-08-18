-- Creating table 'Cards'
CREATE TABLE [dbo].[Cards] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [BranchId] bigint  NOT NULL,
    [SynCode] bigint  NOT NULL,
    [StatusTypeId] int  NOT NULL
);


