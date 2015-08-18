-- Creating foreign key on [ContactTypeId] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [FK_ContactTypeContact]
    FOREIGN KEY ([ContactTypeId])
    REFERENCES [dbo].[ContactType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


