using System;
using System.Configuration;

namespace zasz.me.Integration
{
    public class UploadsConfig : ConfigurationSection
    {
        [ConfigurationProperty("disabled", DefaultValue = "true")]
        public Boolean Disabled
        {
            get
            { return (Boolean)this["disabled"]; }
            set
            { this["disabled"] = value; }
        }

        [ConfigurationProperty("uploadDir", IsRequired = true)]
        public String UploadDir
        {
            get
            { return (String)this["uploadDir"]; }
            set
            { this["uploadDir"] = value; }
        }

        [ConfigurationProperty("deniedExts", IsRequired = true)]
        public String DeniedExts
        {
            get
            { return (String)this["deniedExts"]; }
            set
            { this["deniedExts"] = value; }
        }

        [ConfigurationProperty("thumbHeight", DefaultValue = 100)]
        public int ThumbHeight
        {
            get
            { return (int)this["thumbHeight"]; }
            set
            { this["thumbHeight"] = value; }
        }

        [ConfigurationProperty("thumbWidth", DefaultValue = 100)]
        public int ThumbWidth
        {
            get
            { return (int)this["thumbWidth"]; }
            set
            { this["thumbWidth"] = value; }
        }

        [ConfigurationProperty("thumbsDir", IsRequired = true)]
        public String ThumbsDir
        {
            get
            { return (String)this["thumbsDir"]; }
            set
            { this["thumbsDir"] = value; }
        }

        [ConfigurationProperty("organization", IsRequired = true), ConfigurationCollection(typeof(Mapping))]
        public Organization Mappings
        {
            get
            { return this["organization"] as Organization; }
        }

        public class Mapping : ConfigurationElement
        {
            [ConfigurationProperty("folder")]
            public String Folder
            {
                get
                { return (String)this["folder"]; }
                set
                { this["folder"] = value; }
            }

            [ConfigurationProperty("fileExtensions")]
            public String FileExtensions
            {
                get
                { return (String)this["fileExtensions"]; }
                set
                { this["fileExtensions"] = value; }
            }
        }

        public class Organization : ConfigurationElementCollection
        {
            public override ConfigurationElementCollectionType CollectionType
            {
                get
                { return ConfigurationElementCollectionType.AddRemoveClearMap; }
            }

            public Mapping this[int index]
            {
                get { return (Mapping)BaseGet(index); }
                set
                {
                    if (BaseGet(index) != null)
                        BaseRemoveAt(index);
                    BaseAdd(index, value);
                }
            }

            protected override ConfigurationElement CreateNewElement()
            {
                return new Mapping();
            }

            protected override object GetElementKey(ConfigurationElement element)
            {
                return ((Mapping)element).Folder;
            }
        }
    }
}