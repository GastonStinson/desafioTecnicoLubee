using Microsoft.AspNetCore.Mvc;

namespace desaTec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContractsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> GetContract(int id)
        {
            var contract = await _context.Contracts
            .Where(c => c.Id == id)
            .Include(c => c.ContractItems)
                .ThenInclude(ci => ci.Item)
            .Select(c => new
        {
        // Contract
        c.CourseCode,
        c.FechaAlta,
        c.ColegioNombre,
        c.ColegioNivel,
        c.ColegioCurso,
        c.ColegioLocalidad,
        c.CantidadEgresados,
        c.Total,
        c.FechaEntrega,

        ContractItems = c.ContractItems.Select(ci => new
        {
            // ContractItem
            ci.Id,
            ci.ContractId,
            ci.ItemId,
            ci.CreateDate,
            ci.UpdateDate,
            ci.Enabled,
            ci.Deleted,
            ci.CreatedBy,

            // Item relacionado
            Item = new
            {
                ci.Item.Id,
                ci.Item.Nombre,
                ci.Item.Precio
            }
        }).ToList()
    })
    .FirstOrDefaultAsync();

            if (contract == null)
            {
                return NotFound();
            }

            return contract;
        }
    }

}