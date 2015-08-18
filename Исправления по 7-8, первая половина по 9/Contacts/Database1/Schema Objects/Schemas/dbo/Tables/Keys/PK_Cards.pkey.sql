-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Cards'
ALTER TABLE [dbo].[Cards]
ADD CONSTRAINT [PK_Cards]
    PRIMARY KEY CLUSTERED ([Id] ASC);


