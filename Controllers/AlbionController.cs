using Microsoft.AspNetCore.Mvc;
using AlbionCrafter.Helper;
using AlbionCrafter.Interfaces;
using AlbionCrafter.Models;
using AlbionCrafter.Repository;

namespace AlbionCrafter.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AlbionController : ControllerBase
{
    private readonly ILogger<AlbionController> _logger;
    private readonly IWeaponTreat _weaponTreat;
    private readonly IProfitCalculator _profitCalculator;


    private readonly IXmlRepository _xmlRepository;

    public AlbionController(ILogger<AlbionController> logger, IXmlRepository xmlRepository, IWeaponTreat weaponTreat, IProfitCalculator profitCalculator)
    {
        _logger = logger;
        _weaponTreat = weaponTreat;
        _profitCalculator = profitCalculator;
        _xmlRepository = xmlRepository;
    }

    [HttpGet(Name = "GetWeapons")]
    [ProducesResponseType(typeof(WeaponCostDTO), 200)]
    public IActionResult GetWeapons()
    {
        var repository = new XmlRepository();
        var result = _weaponTreat.ListWeapons(repository.ListAllRecipes());
        return Ok(result);
    }

    [HttpGet(Name = "GetByCategoryId")]
    [ProducesResponseType(typeof(WeaponCostDTO), 200)]
    public IActionResult GetWeaponsByCategoryId(GearType gearType)
    {
        var repository = new XmlRepository();

        var result = _weaponTreat.ListWeapons(repository.ListRecipesByCategoryId(((int)gearType)));
        return Ok(result);
    }

    [HttpPost(Name = "CalcProfit")]
    [ProducesResponseType(typeof(List<ProfitStructure>), 200)]
    public IActionResult PostCalcProfit(WeaponCostDTO listOfWeapons)
    {
        var profit = _profitCalculator.CalculateProfit(listOfWeapons);
        return Ok(profit);
    }
}
