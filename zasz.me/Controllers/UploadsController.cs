using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Microsoft.Practices.Unity.Utility;
using zasz.me.Integration;

namespace zasz.me.Controllers
{
    public class UploadsController : Controller
    {
        private readonly UploadsConfig _Settings;
        private readonly string _ThumbsDirRooted;
        private readonly string _UploadsDirRooted;

        public UploadsController()
        {
            _Settings = WebConfigurationManager.GetWebApplicationSection("Uploads") as UploadsConfig;
            _UploadsDirRooted = AppDomain.CurrentDomain.BaseDirectory + (_Settings != null ? _Settings.UploadDir : "Uploads") + "\\";
            _ThumbsDirRooted = _UploadsDirRooted + (_Settings != null ? _Settings.ThumbsDir : "Thumbs") + "\\";
            if (!Directory.Exists(_UploadsDirRooted)) Directory.CreateDirectory(_UploadsDirRooted);
            if (!Directory.Exists(_ThumbsDirRooted)) Directory.CreateDirectory(_ThumbsDirRooted);
        }

        public ActionResult Delete(string File)
        {
            if (File.StartsWith("/Uploads"))
            {
                try
                {
                    System.IO.File.Delete(Server.MapPath(File));
                    var ThumbFile = _ThumbsDirRooted + Path.GetFileName(File);
                    if (System.IO.File.Exists(ThumbFile)) System.IO.File.Delete(ThumbFile);
                }
                catch(Exception e)
                {
                    return new HttpStatusCodeResult(408);
                }
                return new HttpStatusCodeResult(200);
            }
            return new HttpNotFoundResult();
        }

        /* Url that hits this : http://localhost:2654/Uploads/Browse?CKEditor=editor1&CKEditorFuncNum=1&langCode=en */

        public ActionResult Browse(string Id, string CkEditor, int CkEditorFuncNum, string LangCode)
        {
            var ViewModel = new BrowseViewModel {CkEditorFuncNum = CkEditorFuncNum};
            if (Directory.GetDirectories(_UploadsDirRooted).Any(It => It.EndsWith(Id)))
                foreach (string RootedPath in Directory.GetFiles(_UploadsDirRooted + Id, "*", SearchOption.TopDirectoryOnly))
                    if (!System.IO.File.GetAttributes(RootedPath).HasFlag(FileAttributes.System))
                    {
                        string File = Url.Content("~/" + _Settings.UploadDir + "/" + Id + "/" + Path.GetFileName(RootedPath));
                        var Extension = Path.GetExtension(RootedPath);
                        string Thumb = Id == "Images"
                                           ? Url.Content("~/" + _Settings.UploadDir + "/" + _Settings.ThumbsDir + "/" + Path.GetFileName(RootedPath))
                                           : Url.Content("~/Content/Thumbnails/" + (Extension == null ? "" : Extension.Substring(1)) + ".png");
                        if (!System.IO.File.Exists(Server.MapPath(Thumb))) Thumb = Id == "Images" ? Url.Content("~/Content/Thumbnails/.image.png") : Url.Content("~/Content/Thumbnails/notfound.png");
                        ViewModel.Add(Thumb, File);
                    }
            return View(ViewModel);
        }

        /* Url that hits this : http://localhost:2654/Uploads/Upload/Images?CKEditor=theEditor&CKEditorFuncNum=4&langCode=en */

        [HttpPost]
        public ActionResult Upload(string Id, string CkEditor, int CkEditorFuncNum, string LangCode)
        {
            var ViewModel = new UploadViewModel {CkEditorFuncNum = CkEditorFuncNum};
            if (_Settings.Disabled)
            {
                ViewModel.Message = "You can't upload files now.";
                return View(ViewModel);
            }
            string FileName = "";
            string Folder = "";
            int Count = Request.Files.Count;
            if (Count > 0)
            {
                HttpPostedFileBase Hpf = Request.Files[0];
                if (Hpf != null && Hpf.ContentLength != 0)
                {
                    FileName = Path.GetFileName(Hpf.FileName);
                    if (CheckUploadedFile(FileName))
                    {
                        Folder = FindFolder(FileName);
                        if (!Directory.Exists(_UploadsDirRooted + Folder)) Directory.CreateDirectory(_UploadsDirRooted + Folder);
                        string SavedFileName = _UploadsDirRooted + Folder + "\\" + FileName;
                        Hpf.SaveAs(SavedFileName);
                        if (Id == "Images")
                            Handy.GenerateThumbnail(SavedFileName, _ThumbsDirRooted + FileName, _Settings.ThumbWidth, _Settings.ThumbHeight);
                    }
                    else
                        ViewModel.Message = "File upload denied - only certain filetypes are allowed.";
                }
            }
            else
                ViewModel.Message = "Server error: File upload failed!";

            ViewModel.Url = Url.Content("~/" + _Settings.UploadDir + "/" + Folder + "/" + FileName);
            return View(ViewModel);
        }

        private string FindFolder(string FileName)
        {
            string Extension = Path.GetExtension(FileName);
            for (int I = 0; I < _Settings.Mappings.Count; I++)
            {
                if (Handy.DoesExtensionMatch(Extension, _Settings.Mappings[I].FileExtensions))
                    return _Settings.Mappings[I].Folder;
            }
            return "Files";
        }

        private bool CheckUploadedFile(string FileName)
        {
            string Extension = Path.GetExtension(FileName);
            if (Handy.DoesExtensionMatch(Extension, _Settings.DeniedExts))
                return false; // Disallow files with denied extensions
            return !FileName.StartsWith("."); // Disallow linux hidden files
        }

        #region Nested type: BrowseViewModel

        public class BrowseViewModel
        {
            private readonly List<String> Files = new List<string>();
            private readonly List<String> Thumbs = new List<string>();
            public int CkEditorFuncNum { get; set; }
            public string Message { get; set; }

            public void Add(string Thumb, string File)
            {
                Thumbs.Add(Thumb);
                Files.Add(File);
            }

            public int Count()
            {
                return Files.Count;
            }

            public Pair<string, string> Get(int i)
            {
                return new Pair<string, string>(Thumbs[i], Files[i]);
            }
        }

        #endregion

        #region Nested type: UploadViewModel

        public class UploadViewModel
        {
            public int CkEditorFuncNum { get; set; }
            public string Url { get; set; }
            public string Message { get; set; }
        }

        #endregion
    }
}