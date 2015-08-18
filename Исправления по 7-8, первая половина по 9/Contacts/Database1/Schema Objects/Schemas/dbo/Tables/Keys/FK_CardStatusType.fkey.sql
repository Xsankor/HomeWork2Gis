-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StatusTypeId] in table 'Cards'
ALTER TABLE [dbo].[Cards]
ADD CONSTRAINT [FK_CardStatusType]
    FOREIGN KEY ([StatusTypeId])
    REFERENCES [dbo].[StatusType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


