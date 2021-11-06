using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Infrastructure.Web.Application.Pages
{
    /// <inheritdoc />
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class Error : PageModel
    {
        private readonly ILogger<Error> _logger;

        /// <summary>Initializes a new instance of the <see cref="Error"/> class.</summary>
        /// <param name="logger"><see cref="ILogger{TCategoryName}"/></param>
        public Error(ILogger<Error> logger)
        {
            _logger = logger;
        }

        /// <summary><see cref="RequestId"/></summary>
        public string RequestId { get; set; } = null!;

        /// <summary><see cref="ShowRequestId"/></summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        /// <summary><see cref="OnGet"/></summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}