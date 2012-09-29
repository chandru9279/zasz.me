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
        public const string DateFormat = "g";
        private readonly ITagRepository repo;
        public readonly CultureInfo IndiaCulture = CultureInfo.CreateSpecificCulture("hi-IN");

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
            return DateTime.ParseExact(timestamp, DateFormat, IndiaCulture);
        }

        internal virtual List<Tag> GetTags(string tags)
        {
            return tags.Split(Constants.Shredders, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => repo.Get(x) ?? repo.Save(new Tag(x)))
                .ToList();
        }
    }
}