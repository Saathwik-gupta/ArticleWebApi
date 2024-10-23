using Microsoft.AspNetCore.Mvc;
using ArticleWebApi.Models;
using ArticleWebApi.Services;

namespace ArticleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        // Use the interface IPackageServiceBL instead of the concrete class
        private readonly IPackageServiceBL _packageService;

        // Inject the service using the interface
        public PackagesController(IPackageServiceBL packageService)
        {
            _packageService = packageService;
        }

        // GET: api/packages
        [HttpGet]
        public IActionResult GetPackages()
        {
            var packages = _packageService.GetAllPackages();
            return Ok(packages);
        }

        // GET: api/packages/5
        [HttpGet("{id}")]
        public IActionResult GetPackage(int id)
        {
            var package = _packageService.GetPackageById(id);
            if (package == null)
            {
                return NotFound();
            }
            return Ok(package);
        }

        // POST: api/packages
        [HttpPost]
        public IActionResult PostPackage([FromBody] Package package)
        {
            if (package == null)
            {
                return BadRequest();
            }

            _packageService.AddPackage(package);
            return CreatedAtAction(nameof(GetPackage), new { id = package.PackageId }, package);
        }

        // PUT: api/packages/5
        [HttpPut("{id}")]
        public IActionResult PutPackage(int id, [FromBody] Package package)
        {
            if (id != package.PackageId || package == null)
            {
                return BadRequest();
            }

            _packageService.UpdatePackage(package);
            return NoContent();
        }

        // DELETE: api/packages/5
        [HttpDelete("{id}")]
        public IActionResult DeletePackage(int id)
        {
            var existingPackage = _packageService.GetPackageById(id);
            if (existingPackage == null)
            {
                return NotFound();
            }

            _packageService.DeletePackage(id);
            return NoContent();
        }
    }
}
