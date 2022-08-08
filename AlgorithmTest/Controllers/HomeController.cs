using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlgorithmTest.Models;

namespace AlgorithmTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public AlgoModel algoModel = new AlgoModel();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            algoModel.output = new List<int>();
        }

        public IActionResult Index()
        {
            return View(algoModel);
        }

        public IActionResult Privacy()
        {
            return View(algoModel);
        }

        public IActionResult GetResultAnagrams(string InputString, string AnagramString)
        {
            algoModel.InputString = InputString;
            algoModel.AnagramString = AnagramString;

            List<int> result = AlgoHelper.SearchResult(InputString, AnagramString);

            algoModel.output = result;

            return View(algoModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
