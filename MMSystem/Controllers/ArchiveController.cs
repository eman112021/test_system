﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMSystem.Model.ViewModel.ArchivesReport;
using MMSystem.Services.Archives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchiveController : ControllerBase
    {
        private readonly IArchives _archives;

        public ArchiveController(IArchives archives)
        {
            _archives = archives;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(int page, int pagesize,int Depid )
        {if (Depid ==25 )

            {
                List<ArchivesViewModel> mail = await _archives.GetAll(page, pagesize);
                if (mail != null)
                    return Ok(mail);

                return NotFound(new
                {
                    message = "لايوجد بريد ",
                    statusCode = 404
                });

            }
            else {
                return Unauthorized();
            }
            


        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateArchiveViewModel model)
        {
           bool result = await _archives.UpdateExternal( model);
            if (result)
                return StatusCode(203,new  {
                    mes ="تمت عملية التعديل بنجاح"
                    ,Stut=203 
                });


            return BadRequest(new
            {
                message = "فشلت العملية ",
                statusCode = 400
            });
        }
    }
}