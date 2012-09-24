using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using zasz.me.Controllers.Utils;
using zasz.me.Models;
using zasz.me.Services.Contracts;

namespace zasz.me.Services.Concrete.PostPopulators
{
    public class MetaPopulator : IPostPopulator
    {
        private readonly ITagRepository repo;

        public MetaPopulator(ITagRepository repo)
        {
            this.repo = repo;
        }

        #region IPostPopulator Members

        public void Populate(Post post, DirectoryInfo directory)
        {
            var fileInfos = directory.GetFiles("meta.txt");
            var reader = new StreamReader(fileInfos.First().OpenRead());
            post.Tags = GetTags(reader.ReadLine());
            post.Timestamp = GetTime(reader.ReadLine());
        }

        #endregion

        internal virtual DateTime GetTime(string timestamp)
        {
            var india = CultureInfo.CreateSpecificCulture("hi-IN");
            var dateTime = DateTime.ParseExact(timestamp, "g", india);
            return dateTime;
        }

        internal virtual List<Tag> GetTags(string tags)
        {
            return tags.Split(Constants.Shredders, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => repo.Get(x) ?? repo.Save(new Tag(x)))
                .ToList();
        }
    }
}