using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud.AppResolver.CommonResolver.Model;
using Crud.AppResolver.ServiceResolver;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Operation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {
        public readonly ICrudServiceResolver _crudServiceResolver;

        public CrudOperationController(ICrudServiceResolver crudServiceResolver)
        {
            _crudServiceResolver = crudServiceResolver;
        }

        [HttpPost]
        [Route(template: "CreateRecord")]
        public async Task<IActionResult> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = null;
            try
            {
                response = await _crudServiceResolver.CreateRecord(request);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route(template:"ReadRecord")]
        public async Task<IActionResult> ReadRecord()
        {
            ReadRecordResponse response = null;
            try
            {
                response = await _crudServiceResolver.ReadRecord();
            }
            catch(Exception ex)
            {

            }
            return Ok(response);
        }

        [HttpPut]
        [Route(template: "UpdateRecord")]
        public async Task<IActionResult> UpdateRecord(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = null;
            try
            {
                response = await _crudServiceResolver.UpdateRecord(request);
            }
            catch (Exception ex)
            {

            }
            return Ok(response);
        }

        [HttpDelete]
        [Route(template: "DeleteRecord")]
        public async Task<IActionResult> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = null;
            try
            {
                response = await _crudServiceResolver.DeleteRecord(request);
            }
            catch (Exception ex)
            {

            }
            return Ok(response);
        }
    }
}