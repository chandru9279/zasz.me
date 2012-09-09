using System;
using System.Configuration;

namespace zasz.me.Configuration
{
    public class UploadsConfig : ConfigurationSection
    {
        [ConfigurationProperty("Disabled", DefaultValue = "true")]
        public Boolean Disabled
        {
            get { return (Boolean) this["Disabled"]; }
            set { this["Disabled"] = value; }
        }

        [ConfigurationProperty("UploadsFolder", IsRequired = true)]
        public String UploadsFolder
        {
            get { return (String) this["UploadsFolder"]; }
            set { this["UploadsFolder"] = value; }
        }

        [ConfigurationProperty("DeniedExtensions", IsRequired = true)]
        public String DeniedExtensions
        {
            get { return (String) this["DeniedExtensions"]; }
            set { this["DeniedExtensions"] = value; }
        }

        [ConfigurationProperty("ThumbHeight", DefaultValue = 100)]
        public int ThumbHeight
        {
            get { return (int) this["ThumbHeight"]; }
            set { this["ThumbHeight"] = value; }
        }

        [ConfigurationProperty("ThumbWidth", DefaultValue = 100)]
        public int ThumbWidth
        {
            get { return (int) this["ThumbWidth"]; }
            set { this["ThumbWidth"] = value; }
        }

        [ConfigurationProperty("ThumbsFolder", IsRequired = true)]
        public String ThumbsFolder
        {
            get { return (String) this["ThumbsFolder"]; }
            set { this["ThumbsFolder"] = value; }
        }

        [ConfigurationProperty("Organization", IsRequired = true), ConfigurationCollection(typeof (Mapping))]
        public Organization Mappings
        {
            get { return this["Organization"] as Organization; }
        }

        #region Nested type: Mapping

        public class Mapping : ConfigurationElement
        {
            [ConfigurationProperty("Folder")]
            public String Folder
            {
                get { return (String) this["Folder"]; }
                set { this["Folder"] = value; }
            }

            [ConfigurationProperty("FileExtensions")]
            public String FileExtensions
            {
                get { return (String) this["FileExtensions"]; }
                set { this["FileExtensions"] = value; }
            }
        }

        #endregion

        #region Nested type: Organization

        public class Organization : ConfigurationElementCollection
        {
            public override ConfigurationElementCollectionType CollectionType
            {
                get { return ConfigurationElementCollectionType.BasicMap; }
            }

            protected override string ElementName
            {
                get { return "Map"; }
            }

            public Mapping this[int index]
            {
                get { return (Mapping) BaseGet(index); }
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
                return ((Mapping) element).Folder;
            }
        }

        #endregion
    }
}