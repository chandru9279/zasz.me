using System;
using System.Web;

namespace zasz.me.Services.Contracts
{
    public interface IFilesService
    {

        Func<string, string> Convert { get; set; } 

        /// <summary>
        /// Browses a given folder with thumbnails and FileUrls
        /// </summary>
        /// <param name="Organization">Parameter specifying which folder, many organizations can be defined in the Uploads section in the configuration</param>
        /// <returns>Returns a table of Thumbnail URLs & Actual File URLs that are present in the folder</returns>
        Pairs<string, string> Browse(string Organization);

        void Delete(string FilepathAppRelative);

        string Upload(HttpPostedFileBase UploadedFile);
    }
}