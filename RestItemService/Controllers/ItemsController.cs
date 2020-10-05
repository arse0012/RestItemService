using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestItemService.Controllers
{
    [Route("api/localItems")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private static List<Item> _item = new List<Item>()
        {
            new Item(1, "Bread", "Low", 33),
            new Item(2, "Bread", "Middle", 21),
            new Item(3, "Beer", "Low", 70.5),
            new Item(4, "Soda", "High", 21.4),
            new Item(5, "Milk", "Low", 55.8)

        };

        // GET: api/<ItemsController>
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return _item;
        }

        // GET api/<ItemsController>/5
        [HttpGet] // http request method
        [Route("{id}")] //http request URI
        [ProducesResponseType(StatusCodes.Status200OK)] // http response status
        [ProducesResponseType(StatusCodes.Status404NotFound)] // http response status
        public IActionResult Get(int id)
        {
            if (_item.Exists(i => i.Id == id))
            {
                return Ok(_item.Find(i => i.Id == id));
            }
            return NotFound($"item id {id} not found");
        }
        //Get Items by their "Name"
        [HttpGet]
        [Route("Name/{substring}")]
        public IEnumerable<Item> GetFromSubstring(string substring)
        {
            return _item.FindAll(i => i.Name.Contains(substring));
        }

        //Get Items by there Quality; "Low", "Middle" and "High"
        [HttpGet]
        [Route("Quality/{substring}")]
        public IEnumerable<Item> GetQuality(string substring)
        {
            return _item.FindAll(i => i.Quality.Contains(substring));
        }

        //Search and seperating Items by "LowQuantity" and "HighQuantity"
        [HttpGet]
        [Route("FilterSearch")]
        public IEnumerable<Item> GetWithFilter([FromQuery] FilterItem filter)
        {
            if (filter.HighQuantity == 0) filter.HighQuantity = double.MaxValue;
            return _item.FindAll(i => i.Quantity > filter.LowQuantity && i.Quantity < filter.HighQuantity);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public void Post([FromBody] Item value)
        {
            _item.Add(value);
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Item value)
        {
            Item item = _item.Find(i => i.Id == id);
            if (item != null)
            {
                item.Id = value.Id;
                item.Name = value.Name;
                item.Quality = value.Quality;
                item.Quantity = value.Quantity;
            }
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Item item = _item.Find(i => i.Id == id);
            if (item != null)
            {
                _item.Remove(item);
            }
        }
    }
}
