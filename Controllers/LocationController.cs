using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StorageAPI.Dto;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace StorageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetLocation()
        {
            var locations = new string[]
            {
                "Locate 1", "Locate 2"
            };

            return Ok(locations);
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation(UpdateAuditTargetDto updateModel)
        {
            Dictionary<string, string> err = new();
            bool valid = true;

            while (true)
            {
                if (updateModel == null)
                {
                    err.TryAdd(nameof(UpdateAuditTargetDto), "Model không có dữ liệu.");
                    break;
                }

                Func<UpdateAuditTargetDto, bool> name = (x) =>
                {
                    if (string.IsNullOrEmpty(updateModel.Name))
                    {
                        err.TryAdd(nameof(UpdateAuditTargetDto.Name), "Yêu cầu nhập tên.");
                        return false;
                    }
                    if (updateModel.Name.Length > 4)
                    {
                        err.TryAdd(nameof(UpdateAuditTargetDto.Name), "Tên không được quá 4 ký tự.");
                        return false;
                    }
                    return true;
                };

                Func<UpdateAuditTargetDto, bool> positionCode = (x) =>
                {
                    if (string.IsNullOrEmpty(updateModel.PositionCode))
                    {
                        err.TryAdd(nameof(UpdateAuditTargetDto.PositionCode), "Yêu cầu nhập.");
                        return false;
                    }
                    if (updateModel.PositionCode.Length > 9)
                    {
                        err.TryAdd(nameof(UpdateAuditTargetDto.PositionCode), "Vị trí tối đa 9 ký tự.");
                        return false;
                    }
                    return true;
                };

                break;
            }

            return Ok(new
            {
                valid,
                err
            });
        }
    }
}
