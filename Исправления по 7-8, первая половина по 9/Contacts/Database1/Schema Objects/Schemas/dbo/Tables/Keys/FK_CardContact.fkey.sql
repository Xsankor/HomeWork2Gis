-- Creating foreign key on [CardId] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [FK_CardContact]
    FOREIGN KEY ([CardId])
    REFERENCES [dbo].[Cards]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


