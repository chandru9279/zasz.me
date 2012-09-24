using System.Collections.Generic;

namespace zasz.me.Services.Contracts
{
    public interface IPostPopulators
    {
        List<IPostPopulator> All();
    }
}