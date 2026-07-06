using BankPOS.DTOs;
using BankPOS.Entities;
using BankPOS.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankPOS.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpPost("api/createBranch")]
        public async Task<ActionResult<APIResponse<CreateBranchResponse>>> CreateBranch([FromBody] CreateBranchRequest request)
        {
            var branch = new Branch
            {
                BranchCode = request.BranchCode,
                BranchName = request.Name,
                Location = request.Location
            };
            var createdBranch = await _branchService.OpenBranchAsync(branch);
            return Ok(
                new APIResponse<CreateBranchResponse>("Branch Created Succcessfully",
                new CreateBranchResponse(
                    createdBranch.Id,
                    createdBranch.BranchCode,
                    createdBranch.BranchName,
                    createdBranch.Location
                ))
            );
        }
    }
}