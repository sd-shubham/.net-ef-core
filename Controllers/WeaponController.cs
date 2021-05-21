using CoreAPIAndEfCore.Dtos;
using CoreAPIAndEfCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreAPIAndEfCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponservice;

        public WeaponController(IWeaponService weaponService) => _weaponservice = weaponService;
        [HttpPost]
        public async Task<IActionResult> Create(WeaponAddDto weapon) => Ok(await _weaponservice.Add(weapon));

    }
}