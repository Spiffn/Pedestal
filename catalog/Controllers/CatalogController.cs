using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedestal.Catalog.Infrastructure;
using Pedestal.Catalog.Models;
using Pedestal.Catalog.ViewModels;

namespace Pedestal.Catalog.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : Controller
    {
        private readonly CatalogContext _catalogContext;
        public CatalogController(CatalogContext catalogContext)
        {
            this._catalogContext = catalogContext;
        }

        // GET api/v1/[controller]/modeldydoos[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("modeldydoos")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<Modeldydoo>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<Modeldydoo>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ItemsAsync([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0, string ids = null)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = await GetItemsByIdsAsync(ids);

                if (!items.Any())
                {
                    return BadRequest("ids value invalid. Must be comma-separated list of numbers");
                }

                return Ok(items);
            }

            var totalItems = await _catalogContext.Modeldydoos
                .LongCountAsync();

            var itemsOnPage = await _catalogContext.Modeldydoos
                .OrderBy(c => c.Name)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            /* The "awesome" fix for testing Devspaces */

            /*
            foreach (var pr in itemsOnPage) {
                pr.Name = "Awesome " + pr.Name;
            }
            */

            var model = new PaginatedItemsViewModel<Modeldydoo>(pageIndex, pageSize, totalItems, itemsOnPage);

            return Ok(model);
        }

        private async Task<List<Modeldydoo>> GetItemsByIdsAsync(string ids)
        {
            var numIds = ids.Split(',').Select(id => (Ok: int.TryParse(id, out int x), Value: x));

            if (!numIds.All(nid => nid.Ok))
            {
                return new List<Modeldydoo>();
            }

            var idsToSelect = numIds
                .Select(id => id.Value);

            var items = await _catalogContext.Modeldydoos.Where(ci => idsToSelect.Contains(ci.Id)).ToListAsync();

            return items;
        }

        [HttpGet]
        [Route("modeldydoos/{id:int}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Modeldydoo), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Modeldydoo>> ItemByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var item = await _catalogContext.Modeldydoos.SingleOrDefaultAsync(ci => ci.Id == id);
    
            if (item != null)
            {
                return item;
            }

            return NotFound();
        }

        // GET api/v1/[controller]/modeldydoos/withname/samplename[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("modeldydoos/withname/{name:minlength(1)}")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<Modeldydoo>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginatedItemsViewModel<Modeldydoo>>> ItemsWithNameAsync(string name, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var totalItems = await _catalogContext.Modeldydoos
                .Where(c => c.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase))
                .LongCountAsync();

            var itemsOnPage = await _catalogContext.Modeldydoos
                .Where(c => c.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase))
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();


            return new PaginatedItemsViewModel<Modeldydoo>(pageIndex, pageSize, totalItems, itemsOnPage);
        }

        // GET api/v1/[controller]/modeldydoos/uploader/1[?pageSize=3&pageIndex=10]
        [HttpGet]
        [Route("modeldydoos/uploader/{uploaderId}")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<Modeldydoo>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginatedItemsViewModel<Modeldydoo>>> ItemsByUploader(int uploaderId, [FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var root = _catalogContext.Modeldydoos as IQueryable<Modeldydoo>;

            root = root.Where(ci => ci.UploaderId == uploaderId);

            var totalItems = await root
                .LongCountAsync();

            var itemsOnPage = await root
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItemsViewModel<Modeldydoo>(pageIndex, pageSize, totalItems, itemsOnPage);
        }

        //PUT api/v1/[controller]/items
        [Route("modeldydoo")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> UpdateProductAsync([FromBody]Modeldydoo modeldydoo)
        {
            var Modeldydoo = await _catalogContext.Modeldydoos.SingleOrDefaultAsync(i => i.Id == modeldydoo.Id);

            if (Modeldydoo == null)
            {
                return NotFound(new { Message = $"Item with id {modeldydoo.Id} not found." });
            }

            // Update current product
            Modeldydoo = modeldydoo;
            _catalogContext.Modeldydoos.Update(Modeldydoo);

            await _catalogContext.SaveChangesAsync();

            return CreatedAtAction(nameof(ItemByIdAsync), new { id = modeldydoo.Id }, null);
        }

        //POST api/v1/[controller]/items
        [Route("modeldydoo")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> CreateProductAsync([FromBody]Modeldydoo modeldydoo)
        {
            var item = modeldydoo;

            item.UploadDateUtc = DateTimeOffset.UtcNow;

            _catalogContext.Modeldydoos.Add(item);

            await _catalogContext.SaveChangesAsync();

            return CreatedAtAction(nameof(ItemByIdAsync), new { id = item.Id }, null);
        }

        //DELETE api/v1/[controller]/id
        [Route("modeldydoos/{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteProductAsync(int id)
        {
            var modeldydoo = _catalogContext.Modeldydoos.SingleOrDefault(x => x.Id == id);

            if (modeldydoo == null)
            {
                return NotFound();
            }

            _catalogContext.Modeldydoos.Remove(modeldydoo);

            await _catalogContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
