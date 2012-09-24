using System.Collections.Generic;
using zasz.me.Services.Contracts;

namespace zasz.me.Services.Concrete.PostPopulators
{
    public class OrderedPostPopulatorSet : IPostPopulators
    {
        private readonly List<IPostPopulator> populators = new List<IPostPopulator>();

        public OrderedPostPopulatorSet(
            SlugPopulator slug, 
            TitleAndContentPopulator titleAndContent, 
            MetaPopulator meta, 
            PostValidator validator)
        {
            populators.Add(slug); //Slug first, this will be in the error message, if others throw.
            populators.Add(titleAndContent);
            populators.Add(meta);
            populators.Add(validator); //Validator last, to see if the read values, satisfy the ValidationAttributes
        }

        public List<IPostPopulator> All()
        {
            return populators;
        }
    }
}