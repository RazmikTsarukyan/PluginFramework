using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PluginFramework.Models;

namespace PluginFramework.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PluginController : Controller
	{
		private static List<PluginImg> pluginImgs = new List<PluginImg>();
		
		[HttpGet("getall")]
		public IActionResult Index()
		{
			return Ok(pluginImgs);
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			PluginImg pluginImg = pluginImgs.FirstOrDefault(p => p.Id == id);

			if (pluginImg == null)
				return NotFound("Not Found");

			return Ok(pluginImg);
		}

		[HttpPost("Create")]
		public IActionResult Post(PluginImg pluginImg)
		{
			pluginImgs.Add(pluginImg);

			return Ok(pluginImgs);
		}

		[HttpPut("Update")]
		public IActionResult Put(PluginImg pluginImg)
		{
			PluginImg img = pluginImgs.FirstOrDefault(p => p.Id == pluginImg.Id);

			if (img == null)
				return NotFound("Not Found");

			pluginImgs.Remove(img);
			pluginImgs.Add(pluginImg);

			return Ok(pluginImgs);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			PluginImg pluginImg = pluginImgs.FirstOrDefault(p => p.Id == id);
			
			if(pluginImg == null)
				return NotFound("Not Found");

			pluginImgs.Remove(pluginImg);

			return Ok(pluginImgs);
		}
	}
}
