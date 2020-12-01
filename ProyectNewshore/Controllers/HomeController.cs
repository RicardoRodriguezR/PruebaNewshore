using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using System.Diagnostics;
using System.Web.Helpers;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using ProyectNewshore.Models;
using System.Text;

namespace ProyectNewshore.Controllers
{
    public class HomeController : Controller
    {
        public HttpClient Client { get; }

        public HomeController()
        {
            Client = new HttpClient();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IEnumerable<FlightModel>> Index(string origin, string destination, string from)
        {
            try
            {

                var response = await GetFlightsFromApi(origin, destination, from);
                List<FlightModel> ListFliht = new List<FlightModel>();
                foreach (FlightModel f in response)
                {
                    FlightModel coso = new FlightModel
                    {
                        ArrivalStation = f.ArrivalStation,
                        DepartureStation = f.DepartureStation,
                        DepartureDate = f.DepartureDate

                    };

                    ListFliht.Add(coso);
                }
                
                return ListFliht;
                
            }
            catch
            {
                return null;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        

        public async Task<IEnumerable<FlightModel>> GetFlightsFromApi(string FlightOrigin,
            string FlightDestination, string FlightDate)
        {
            try
            {
                List<FlightModel> reply = new List<FlightModel>();
                var requestObject = new
                {
                    Origin = FlightOrigin,
                    Destination = FlightDestination,
                    From = FlightDate
                };
           
                HttpResponseMessage response = await Client.PostAsJsonAsync(
                     "http://testapi.vivaair.com/otatest/api/values", requestObject);
                response.EnsureSuccessStatusCode();
                var responseStream = await response.Content.ReadAsStringAsync();
                responseStream = responseStream.Substring(1, responseStream.Length - 2).Replace("\\", "");
                reply = JsonConvert.DeserializeObject<List<FlightModel>>(responseStream);

                return reply;

            }
            catch
            {
                
                return null;
            }
        }



    }
}