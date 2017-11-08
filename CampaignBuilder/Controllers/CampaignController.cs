using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using CampaignCore;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace CampaignBuilder.Controllers
{
    public class CampaignController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// GET: /Campaign
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateNew()
        {
            campaignModel = new Campaign();
            return View(campaignModel);
        }

        public IActionResult LoadExisting(string campaignID)
        {
            var path = RetrievePath(campaignID);
            campaignModel = LoadFromDisk(campaignID);
            return View(campaignModel);
        }

        public IActionResult ExportCampaign()
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            handler.GetXMLString(campaignModel, writer);
            var fileName = campaignModel.Title + ".xml";
            return File(stream, "text/xml", fileName);
        }

        private Campaign campaignModel;
        private XMLHandler handler;

        private Campaign LoadFromDisk(string path)
        {
            return handler.ParseXML(path);
        }

        private string RetrievePath(string campaignID)
        {
            // do database stuff
            return "";
        }
    }
}