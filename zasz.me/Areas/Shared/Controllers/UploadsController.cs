﻿using System;
using System.Web;
using System.Web.Mvc;
using zasz.me.Services;

namespace zasz.me.Areas.Shared.Controllers
{
    public class UploadsController : Controller
    {
        private readonly IFilesService _FilesService;

        public UploadsController(IFilesService FilesService)
        {
            _FilesService = FilesService;
        }

        public ActionResult Default()
        {
            return Browse("Files", "", 1, "");
        }

        public ActionResult Delete(string File)
        {
            try
            {
                _FilesService.Delete(File);
            }
            catch (UnauthorizedAccessException)
            {
                return new HttpNotFoundResult();
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(408);
            }

            return new HttpStatusCodeResult(200);
        }

        /* Url that hits this : http://localhost:2654/Uploads/Browse?CKEditor=editor1&CKEditorFuncNum=1&langCode=en */

        public ActionResult Browse(string Id, string CkEditor, int CkEditorFuncNum, string LangCode)
        {
            Pairs<string, string> Pairs = _FilesService.Browse(Id);
            var ViewModel = new BrowseViewModel {CkEditorFuncNum = CkEditorFuncNum, ThumbsAndFiles = Pairs};
            // Messages can be dispalyed while browsing : Use ViewModel.Message
            return View(ViewModel);
        }

        /* Url that hits this : http://localhost:2654/Uploads/Upload/Images?CKEditor=theEditor&CKEditorFuncNum=4&langCode=en */

        [HttpPost]
        public ActionResult Upload(string Id, string CkEditor, int CkEditorFuncNum, string LangCode)
        {
            var ViewModel = new UploadViewModel {CkEditorFuncNum = CkEditorFuncNum};
            int Count = Request.Files.Count;
            if (Count > 0)
            {
                HttpPostedFileBase PostedFile = Request.Files[0];
                try
                {
                    ViewModel.Url = _FilesService.Upload(PostedFile);
                }
                catch (InvalidOperationException Exception)
                {
                    ViewModel.Message = Exception.Message;
                }
                catch (UnauthorizedAccessException Exception)
                {
                    ViewModel.Message = Exception.Message;
                }
            }
            else
                ViewModel.Message = "Your file did not make it to the server - Network Error.";
            return View(ViewModel);
        }

        #region Nested type: BrowseViewModel

        public class BrowseViewModel
        {
            public Pairs<string, string> ThumbsAndFiles { get; set; }
            public int CkEditorFuncNum { get; set; }
            public string Message { get; set; }
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