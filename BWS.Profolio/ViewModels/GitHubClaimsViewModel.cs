using Octokit;
using System.Collections.Generic;

namespace BWS.Profolio.ViewModels
{
    public class GitHubClaimsViewModel
    {
        public string GitHubAvatar { get; set; }

        public string GitHubLogin { get; set; }

        public string GitHubName { get; set; }

        public string GitHubUrl { get; set; }

        public IReadOnlyList<Repository> Repositories { get; set; }
    }
}
