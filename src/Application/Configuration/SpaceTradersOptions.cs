using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroTrade.Application.Configuration;
public class SpaceTradersOptions
{
    public string AccessToken { get; set; } = string.Empty;
}

public class AstroTradeOptions
{
    public SpaceTradersOptions SpaceTraders { get; set; } = new();
}