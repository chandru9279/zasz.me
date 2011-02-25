using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Configuration;
using zasz.me.Integration;

namespace zasz.me.Controllers
{
    public class UploadsController : Controller
    {
        private UploadsConfig settings;
        private string uploadsDir;

        public UploadsController()
        {
            settings = WebConfigurationManager.GetWebApplicationSection("KCFinder") as UploadsConfig;
            uploadsDir = AppDomain.CurrentDomain.BaseDirectory + settings.UploadDir;
            if(!Directory.Exists(uploadsDir)) Directory.CreateDirectory(uploadsDir);
            uploadsDir += @"\";
        }

        /* Url that hits this : http://localhost:2654/Uploads/Browse?CKEditor=editor1&CKEditorFuncNum=1&langCode=en */

        public ActionResult Browse(string id, string CKEditor, int CKEditorFuncNum, string langCode)
        {
            Directory.GetDirectories(uploadsDir).ToList<string>().ForEach(new Action<string>() { });
            return View();
        }

        /* Url that hits this : http://localhost:2654/Uploads/Upload/Images?CKEditor=theEditor&CKEditorFuncNum=4&langCode=en */
                                
        [HttpPost]
        public ActionResult Upload(string id, string CKEditor, int CKEditorFuncNum, string langCode)
        {
            var ViewModel = new UploadViewModel();
            ViewModel.CKEditorFuncNum = CKEditorFuncNum;
            if (settings.Disabled)
            {
                ViewModel.Message = "You can't upload files now.";
                return View(ViewModel);
            }
            string FileName = "";
            string Folder = "";
            int count = Request.Files.Count;
            if (count > 0)
            {
                HttpPostedFileBase hpf = Request.Files[0] as HttpPostedFileBase;
                if (hpf.ContentLength != 0)
                {
                    FileName = Path.GetFileName(hpf.FileName);
                    if (CheckUploadedFile(FileName))
                    {
                        Folder = GetFolder(FileName);
                        if (!Directory.Exists(uploadsDir + Folder)) Directory.CreateDirectory(uploadsDir + Folder);
                        string savedFileName = uploadsDir + Folder + @"\" + FileName;
                        hpf.SaveAs(savedFileName);
                    }
                    else
                        ViewModel.Message = "File upload denied - only certain filetypes are allowed.";
                }
            }
            else
                ViewModel.Message = "Server error: File upload failed!";

            ViewModel.Url = Url.Content("~/" + settings.UploadDir + "/" + Folder + "/" + FileName);
            return View(ViewModel);
        }

        private string GetFolder(string FileName)
        {
            var Extension = Path.GetExtension(FileName);
            for (int i = 0; i < settings.Mappings.Count; i++)
            {
                if (DoesExtensionMatch(Extension, settings.Mappings[i].FileExtensions)) return settings.Mappings[i].Folder;
            }
            return "Files";
        }

        private bool CheckUploadedFile(string FileName)
        {
            var Extension = Path.GetExtension(FileName);
            if (DoesExtensionMatch(Extension, settings.DeniedExts)) return false; // Disallow files with denied extensions
            return !FileName.StartsWith("."); // Disallow linux hidden files
        }

        private bool DoesExtensionMatch(string Extension, string ExtensionList)
        {
            if (String.IsNullOrEmpty(ExtensionList)) return true;
            var Extensions = ExtensionList.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return Extensions.Contains(Extension.ToLower().Remove(0,1));
        }

        public class UploadViewModel
        {
            public int CKEditorFuncNum { get; set; }
            public string Url { get; set; }
            public string Message { get; set; }
        }
    }
}
