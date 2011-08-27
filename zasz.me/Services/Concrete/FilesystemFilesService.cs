using System;
using System.IO;
using System.Linq;
using System.Web;
using zasz.me.Areas.Shared.Controllers.Utils;
using zasz.me.Configuration;
using zasz.me.Services.Contracts;

namespace zasz.me.Services.Concrete
{
    public class FilesystemFilesService : IFilesService
    {
        private readonly Func<string, string, bool> DoesExtensionMatch = (Extension, ExtensionList) => Handy.Shred(ExtensionList).Contains(Extension.ToLower().Remove(0, 1));
        private readonly Func<string, string> SysPath = HttpContext.Current.Server.MapPath;
        private readonly UploadsConfig _Settings;
        private readonly string _ThumbsDirRooted;
        private readonly string _UploadsDirRooted;

        public Func<string, string> Convert { get; set; } 

        public FilesystemFilesService(UploadsConfig UploadsConfiguration)
        {
            Convert = It => It; //Does Nothing
            _Settings = UploadsConfiguration;
            _UploadsDirRooted = AppDomain.CurrentDomain.BaseDirectory + _Settings.UploadsFolder + "\\";
            _ThumbsDirRooted = _UploadsDirRooted + _Settings.ThumbsFolder + "\\";
            if (!Directory.Exists(_UploadsDirRooted)) Directory.CreateDirectory(_UploadsDirRooted);
            if (!Directory.Exists(_ThumbsDirRooted)) Directory.CreateDirectory(_ThumbsDirRooted);
        }

        #region IFilesService Members

        public Pairs<string, string> Browse(string Folder)
        {
            Pairs<string, string> BrowseModel = new Pairs<string, string>();
            if (Directory.GetDirectories(_UploadsDirRooted).Any(It => It.EndsWith(Folder)))
                foreach (string RootedPath in Directory.GetFiles(_UploadsDirRooted + Folder, "*", SearchOption.TopDirectoryOnly))
                    if (!File.GetAttributes(RootedPath).HasFlag(FileAttributes.System))
                    {
                        string Filepath = Convert("~/" + _Settings.UploadsFolder + "/" + Folder + "/" + Path.GetFileName(RootedPath));
                        var Extension = Path.GetExtension(RootedPath);
                        string Thumb = Folder == "Images"
                                           ? Convert("~/" + _Settings.UploadsFolder + "/" + _Settings.ThumbsFolder + "/" + Path.GetFileName(RootedPath))
                                           : Convert("~/Content/Thumbnails/" + (Extension == null ? "" : Extension.Substring(1)) + ".png");
                        if (!File.Exists(SysPath(Thumb)))
                            Thumb = Folder == "Images" ? Convert("~/Content/Thumbnails/.image.png") : Convert("~/Content/Thumbnails/notfound.png");
                        BrowseModel.Add(new Pair<string, string>(Thumb, Filepath));
                    }
            return BrowseModel;
        }


        public void Delete(string Filepath)
        {
            if (!Filepath.StartsWith("/" + _Settings.UploadsFolder))
                throw new UnauthorizedAccessException("Cannot delete arbitrary files outside of Uploads Folder");
            File.Delete(SysPath(Filepath));
            var ThumbFile = _ThumbsDirRooted + Path.GetFileName(Filepath);
            if (File.Exists(ThumbFile)) File.Delete(ThumbFile);
        }

        public string Upload(HttpPostedFileBase UploadedFile)
        {
            if (_Settings.Disabled) throw new InvalidOperationException("You can't upload files now.");
            string FileName = "";
            string Folder = "";

            if (UploadedFile != null && UploadedFile.ContentLength != 0)
            {
                FileName = Path.GetFileName(UploadedFile.FileName);
                if (CheckUploadedFile(FileName))
                {
                    Folder = FindFolder(FileName);
                    if (!Directory.Exists(_UploadsDirRooted + Folder)) Directory.CreateDirectory(_UploadsDirRooted + Folder);
                    string SavedFileName = _UploadsDirRooted + Folder + "\\" + FileName;
                    UploadedFile.SaveAs(SavedFileName);
                    if (Folder == "Images")
                        Handy.GenerateThumbnail(SavedFileName, _ThumbsDirRooted + FileName, _Settings.ThumbWidth, _Settings.ThumbHeight);
                }
                else
                    throw new UnauthorizedAccessException("File upload denied - only certain filetypes are allowed.");
            }
            return Convert("~/" + _Settings.UploadsFolder + "/" + Folder + "/" + FileName);
        }

        #endregion

        private string FindFolder(string FileName)
        {
            string Extension = Path.GetExtension(FileName);
            for (int I = 0; I < _Settings.Mappings.Count; I++)
            {
                if (DoesExtensionMatch(Extension, _Settings.Mappings[I].FileExtensions))
                    return _Settings.Mappings[I].Folder;
            }
            return "Files";
        }

        private bool CheckUploadedFile(string FileName)
        {
            string Extension = Path.GetExtension(FileName);
            if (DoesExtensionMatch(Extension, _Settings.DeniedExtensions))
                return false; // Disallow files with denied extensions
            return !FileName.StartsWith("."); // Disallow linux hidden files
        }
    }
}