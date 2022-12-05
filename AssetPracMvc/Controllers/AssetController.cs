using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using AssetPracMvc.Models;



namespace AssetPracMvc.Controllers
{
    public class AssetController : Controller
    {
        // GET: Asset
        [HttpGet]
        public ActionResult GetAssetList()
        {
            List<Asset> TD = new List<Asset>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8044/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var responseTask = client.GetAsync("asset/getasset");
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    // Get back student object
                    var readTask = response.Content.ReadAsAsync<List<Asset>>();
                    readTask.Wait();
                    TD = readTask.Result;


                }
            }
            return View(TD);
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Asset Ninja";

            return View();
        }



        [HttpGet]
        public ActionResult AddAsset()
        {
            

            Asset ast = new Asset();

            return View(ast);
        }


        [HttpPost]
        public ActionResult AddAsset(Asset ev)
        {
            List<Asset> TD = new List<Asset>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8044/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var responseTask = client.PostAsJsonAsync(String.Format("Asset/AddAsset"), ev);
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;
                //if (response.IsSuccessStatusCode)
                //{
                //    // Get back student object
                //    var readTask = response.Content.ReadAsAsync<List<Event>>();
                //    readTask.Wait();
                //    //TD = readTask.Result;


                //}
            }
            return RedirectToAction("GetAssetList");
        }

        //[HttpGet]
        //public ActionResult EditAsset(int id)
        //{
        //    Asset TD = new Asset();

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:8044/api/");
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        //        var responseTask = client.GetAsync(String.Format("asset/editasset ? id = ") + id);
        //        //var responseTask = client.GetAsync("Review/GetTaskReviewbytheirID?ToDoId=" + ToDoId.ToString());
        //        responseTask.Wait();

        //        HttpResponseMessage result = responseTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            // Get back student object
        //            var readTask = result.Content.ReadAsAsync<Asset>();
        //            readTask.Wait();
        //            TD = readTask.Result;


        //        }
        //    }
        //    return View(TD);
        //}

        [HttpGet]
        public ActionResult EditAsset(int id)
        {
            Asset TD = new Asset();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8044/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var EditresponseTask = client.GetAsync(String.Format("asset/EditAsset/?aid=")+ id);
                //var responseTask = client.GetAsync("Review/GetTaskReviewbytheirID?ToDoId=" + ToDoId.ToString());
                EditresponseTask.Wait();

                HttpResponseMessage response = EditresponseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    // Get back student object
                    var readTask = response.Content.ReadAsAsync<Asset>();
                    readTask.Wait();
                    TD = readTask.Result;
                }
            }
            return View(TD);
        }



        [HttpPost]
        public ActionResult EditAsset(Asset ev)
        {
            List<Asset> TD = new List<Asset>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:8044/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var responseTask = client.PutAsJsonAsync(String.Format("asset/EditAsset"), ev);
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;
                //if (response.IsSuccessStatusCode)
                //{
                //    // Get back student object
                //    var readTask = response.Content.ReadAsAsync<List<Event>>();
                //    readTask.Wait();
                //    //TD = readTask.Result;


                //}
            }
            return RedirectToAction("GetAssetList");
        }



        //vIEWS OF THE LIST OF ASSETS TO BE EDITED 
        [HttpGet]
        public ActionResult EditAssets()
        {
            List<Asset> TD = new List<Asset>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8044/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var responseTask = client.GetAsync("asset/getasset");
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    // Get back student object
                    var readTask = response.Content.ReadAsAsync<List<Asset>>();
                    readTask.Wait();
                    TD = readTask.Result;


                }
            }
            return View(TD);
        }

        //vIEWS OF THE LIST OF ASSETS TO BE DELETED 
        [HttpGet]
        public ActionResult DeleteAssets()
        {
            List<Asset> TD = new List<Asset>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8044/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var responseTask = client.GetAsync("asset/getasset");
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    // Get back student object
                    var readTask = response.Content.ReadAsAsync<List<Asset>>();
                    readTask.Wait();
                    TD = readTask.Result;


                }
            }
            return View(TD);
        }

        [HttpGet]
        public ActionResult DeleteAsset(int id)
        {
            Asset TD = new Asset();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8044/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var responseTask = client.GetAsync("asset/DeleteAssets/?aaid=" + id);
                //var responseTask = client.GetAsync("Review/GetTaskReviewbytheirID?ToDoId=" + ToDoId.ToString());
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;
                if (response.IsSuccessStatusCode)
                {
                    // Get back student object
                    var readTask = response.Content.ReadAsAsync<Asset>();
                    readTask.Wait();
                    TD = readTask.Result;
                }
            }
            return View(TD);
        }


        [HttpPost, ActionName("DeleteAsset")]
        public ActionResult DeleteAssets(int id)
        {
            List<Asset> TD = new List<Asset>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:8044/api/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var responseTask = client.DeleteAsync(String.Format("asset/DeleteAssets/?aid=" + id));
                responseTask.Wait();

                HttpResponseMessage response = responseTask.Result;
                //if (response.IsSuccessStatusCode)
                //{
                //    // Get back student object
                //    var readTask = response.Content.ReadAsAsync<List<Event>>();
                //    readTask.Wait();
                //    //TD = readTask.Result;


                //}
            }
            return RedirectToAction("GetAssetList");
        }

        //[HttpPost]
        //public ActionResult DeleteAsset(Asset ev)
        //{
        //    List<Asset> TD = new List<Asset>();

        //    using (var client = new HttpClient())
        //    {

        //        client.BaseAddress = new Uri("http://localhost:8044/api/");
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        //        var responseTask = client.DeleteAsync(String.Format("asset/DeleteAsset"), ev);
        //        responseTask.Wait();

        //        HttpResponseMessage response = responseTask.Result;
        //        //if (response.IsSuccessStatusCode)
        //        //{
        //        //    // Get back student object
        //        //    var readTask = response.Content.ReadAsAsync<List<Event>>();
        //        //    readTask.Wait();
        //        //    //TD = readTask.Result;


        //        //}
        //    }
        //    return RedirectToAction("GetAssetList");
        //}

    }
}


