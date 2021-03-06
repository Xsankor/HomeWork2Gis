﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("TestDBModel", "FK_CardContact", "Cards", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(TestDB.Cards), "Contacts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(TestDB.Contacts), true)]
[assembly: EdmRelationshipAttribute("TestDBModel", "FK_CardStatusType", "StatusType", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(TestDB.StatusType), "Cards", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(TestDB.Cards), true)]
[assembly: EdmRelationshipAttribute("TestDBModel", "FK_ContactTypeContact", "ContactType", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(TestDB.ContactType), "Contacts", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(TestDB.Contacts), true)]

#endregion

namespace TestDB
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class TestDBEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new TestDBEntities object using the connection string found in the 'TestDBEntities' section of the application configuration file.
        /// </summary>
        public TestDBEntities() : base("name=TestDBEntities", "TestDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new TestDBEntities object.
        /// </summary>
        public TestDBEntities(string connectionString) : base(connectionString, "TestDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new TestDBEntities object.
        /// </summary>
        public TestDBEntities(EntityConnection connection) : base(connection, "TestDBEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Cards> Cards
        {
            get
            {
                if ((_Cards == null))
                {
                    _Cards = base.CreateObjectSet<Cards>("Cards");
                }
                return _Cards;
            }
        }
        private ObjectSet<Cards> _Cards;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Contacts> Contacts
        {
            get
            {
                if ((_Contacts == null))
                {
                    _Contacts = base.CreateObjectSet<Contacts>("Contacts");
                }
                return _Contacts;
            }
        }
        private ObjectSet<Contacts> _Contacts;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ContactType> ContactType
        {
            get
            {
                if ((_ContactType == null))
                {
                    _ContactType = base.CreateObjectSet<ContactType>("ContactType");
                }
                return _ContactType;
            }
        }
        private ObjectSet<ContactType> _ContactType;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<StatusType> StatusType
        {
            get
            {
                if ((_StatusType == null))
                {
                    _StatusType = base.CreateObjectSet<StatusType>("StatusType");
                }
                return _StatusType;
            }
        }
        private ObjectSet<StatusType> _StatusType;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Cards EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCards(Cards cards)
        {
            base.AddObject("Cards", cards);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Contacts EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToContacts(Contacts contacts)
        {
            base.AddObject("Contacts", contacts);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the ContactType EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToContactType(ContactType contactType)
        {
            base.AddObject("ContactType", contactType);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the StatusType EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToStatusType(StatusType statusType)
        {
            base.AddObject("StatusType", statusType);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TestDBModel", Name="Cards")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Cards : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Cards object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="branchId">Initial value of the BranchId property.</param>
        /// <param name="synCode">Initial value of the SynCode property.</param>
        /// <param name="statusTypeId">Initial value of the StatusTypeId property.</param>
        public static Cards CreateCards(global::System.Int64 id, global::System.String name, global::System.Int64 branchId, global::System.Int64 synCode, global::System.Int32 statusTypeId)
        {
            Cards cards = new Cards();
            cards.Id = id;
            cards.Name = name;
            cards.BranchId = branchId;
            cards.SynCode = synCode;
            cards.StatusTypeId = statusTypeId;
            return cards;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int64 _Id;
        partial void OnIdChanging(global::System.Int64 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 BranchId
        {
            get
            {
                return _BranchId;
            }
            set
            {
                OnBranchIdChanging(value);
                ReportPropertyChanging("BranchId");
                _BranchId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("BranchId");
                OnBranchIdChanged();
            }
        }
        private global::System.Int64 _BranchId;
        partial void OnBranchIdChanging(global::System.Int64 value);
        partial void OnBranchIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 SynCode
        {
            get
            {
                return _SynCode;
            }
            set
            {
                OnSynCodeChanging(value);
                ReportPropertyChanging("SynCode");
                _SynCode = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SynCode");
                OnSynCodeChanged();
            }
        }
        private global::System.Int64 _SynCode;
        partial void OnSynCodeChanging(global::System.Int64 value);
        partial void OnSynCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 StatusTypeId
        {
            get
            {
                return _StatusTypeId;
            }
            set
            {
                OnStatusTypeIdChanging(value);
                ReportPropertyChanging("StatusTypeId");
                _StatusTypeId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("StatusTypeId");
                OnStatusTypeIdChanged();
            }
        }
        private global::System.Int32 _StatusTypeId;
        partial void OnStatusTypeIdChanging(global::System.Int32 value);
        partial void OnStatusTypeIdChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TestDBModel", "FK_CardContact", "Contacts")]
        public EntityCollection<Contacts> Contacts
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Contacts>("TestDBModel.FK_CardContact", "Contacts");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Contacts>("TestDBModel.FK_CardContact", "Contacts", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TestDBModel", "FK_CardStatusType", "StatusType")]
        public StatusType StatusType
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<StatusType>("TestDBModel.FK_CardStatusType", "StatusType").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<StatusType>("TestDBModel.FK_CardStatusType", "StatusType").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<StatusType> StatusTypeReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<StatusType>("TestDBModel.FK_CardStatusType", "StatusType");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<StatusType>("TestDBModel.FK_CardStatusType", "StatusType", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TestDBModel", Name="Contacts")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Contacts : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Contacts object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="value">Initial value of the Value property.</param>
        /// <param name="cardId">Initial value of the CardId property.</param>
        /// <param name="contactTypeId">Initial value of the ContactTypeId property.</param>
        public static Contacts CreateContacts(global::System.Int64 id, global::System.String value, global::System.Int64 cardId, global::System.Int32 contactTypeId)
        {
            Contacts contacts = new Contacts();
            contacts.Id = id;
            contacts.Value = value;
            contacts.CardId = cardId;
            contacts.ContactTypeId = contactTypeId;
            return contacts;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int64 _Id;
        partial void OnIdChanging(global::System.Int64 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Value
        {
            get
            {
                return _Value;
            }
            set
            {
                OnValueChanging(value);
                ReportPropertyChanging("Value");
                _Value = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Value");
                OnValueChanged();
            }
        }
        private global::System.String _Value;
        partial void OnValueChanging(global::System.String value);
        partial void OnValueChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 CardId
        {
            get
            {
                return _CardId;
            }
            set
            {
                OnCardIdChanging(value);
                ReportPropertyChanging("CardId");
                _CardId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CardId");
                OnCardIdChanged();
            }
        }
        private global::System.Int64 _CardId;
        partial void OnCardIdChanging(global::System.Int64 value);
        partial void OnCardIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ContactTypeId
        {
            get
            {
                return _ContactTypeId;
            }
            set
            {
                OnContactTypeIdChanging(value);
                ReportPropertyChanging("ContactTypeId");
                _ContactTypeId = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ContactTypeId");
                OnContactTypeIdChanged();
            }
        }
        private global::System.Int32 _ContactTypeId;
        partial void OnContactTypeIdChanging(global::System.Int32 value);
        partial void OnContactTypeIdChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TestDBModel", "FK_CardContact", "Cards")]
        public Cards Cards
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Cards>("TestDBModel.FK_CardContact", "Cards").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Cards>("TestDBModel.FK_CardContact", "Cards").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Cards> CardsReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Cards>("TestDBModel.FK_CardContact", "Cards");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Cards>("TestDBModel.FK_CardContact", "Cards", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TestDBModel", "FK_ContactTypeContact", "ContactType")]
        public ContactType ContactType
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ContactType>("TestDBModel.FK_ContactTypeContact", "ContactType").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ContactType>("TestDBModel.FK_ContactTypeContact", "ContactType").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<ContactType> ContactTypeReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<ContactType>("TestDBModel.FK_ContactTypeContact", "ContactType");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<ContactType>("TestDBModel.FK_ContactTypeContact", "ContactType", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TestDBModel", Name="ContactType")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class ContactType : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new ContactType object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        public static ContactType CreateContactType(global::System.Int32 id, global::System.String name)
        {
            ContactType contactType = new ContactType();
            contactType.Id = id;
            contactType.Name = name;
            return contactType;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TestDBModel", "FK_ContactTypeContact", "Contacts")]
        public EntityCollection<Contacts> Contacts
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Contacts>("TestDBModel.FK_ContactTypeContact", "Contacts");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Contacts>("TestDBModel.FK_ContactTypeContact", "Contacts", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="TestDBModel", Name="StatusType")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class StatusType : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new StatusType object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        public static StatusType CreateStatusType(global::System.Int32 id, global::System.String name)
        {
            StatusType statusType = new StatusType();
            statusType.Id = id;
            statusType.Name = name;
            return statusType;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion

    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("TestDBModel", "FK_CardStatusType", "Cards")]
        public EntityCollection<Cards> Cards
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Cards>("TestDBModel.FK_CardStatusType", "Cards");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Cards>("TestDBModel.FK_CardStatusType", "Cards", value);
                }
            }
        }

        #endregion

    }

    #endregion

    
}
