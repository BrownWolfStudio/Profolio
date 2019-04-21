using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BWS.Profolio.Models;
using System.Security.Claims;
using BWS.Profolio.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Octokit.Internal;
using Octokit;

namespace BWS.Profolio.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Get user repositories using Octokit
                string accessToken = await HttpContext.GetTokenAsync("access_token");
                var github = new GitHubClient(
                    new ProductHeaderValue("AspNetCoreGitHubAuth"),
                    new InMemoryCredentialStore(new Credentials(accessToken))
                );

                var user = await github.User.Current();

                var model = new GitHubClaimsViewModel()
                {
                    GitHubName = user.Name,
                    GitHubLogin = user.Login,
                    GitHubUrl = user.Url,
                    GitHubAvatar = user.AvatarUrl,
                    Repositories = await github.Repository.GetAllForCurrent()
                };

                return View(model);
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
