﻿using System.Web.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace zasz.me.Configuration
{
    public class Config
    {
        public static UnityConfigurationSection Unity
        {
            get { return WebConfigurationManager.GetWebApplicationSection("unity") as UnityConfigurationSection; }
        }

        public static UploadsConfig Uploads
        {
            get { return WebConfigurationManager.GetWebApplicationSection("zasz.me/Uploads") as UploadsConfig; }
        }

        public static WritingsConfig Writings
        {
            get { return WebConfigurationManager.GetWebApplicationSection("zasz.me/Writings") as WritingsConfig; }
        }

        public static void PutConfigIn(IUnityContainer BigBox)
        {
            // Type auto inferred
            BigBox.RegisterInstance("MaxPostsPerPage", Writings.MaxPostsPerPage);
            BigBox.RegisterInstance("DescriptionLength", Writings.DescriptionLength);
            BigBox.RegisterInstance(Uploads);
        }
    }
}