using System.Collections.Generic;

namespace zasz.me.Services
{
    public interface IFilesService
    {
        List<string> GetThumbnails(string Folderpath);

    }
}