-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [CardId] bigint  NOT NULL,
    [ContactTypeId] int  NOT NULL
);


