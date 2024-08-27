using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroTrade.Domain.SpaceTraders;

public class SpaceTradersStatus
{
    public string Status { get; set; }
    public string Version { get; set; }
    public DateTimeOffset ResetDate { get; set; }
    public string Description { get; set; }
    public Stats Stats { get; set; }
    public Leaderboards Leaderboards { get; set; }
    public ServerResets ServerResets { get; set; }
    public Announcement[] Announcements { get; set; }
    public Link[] Links { get; set; }
}

public partial class Announcement
{
    public string Title { get; set; }
    public string Body { get; set; }
}

public partial class Leaderboards
{
    public MostCredit[] MostCredits { get; set; }
    public MostSubmittedChart[] MostSubmittedCharts { get; set; }
}

public partial class MostCredit
{
    public string AgentSymbol { get; set; }
    public long Credits { get; set; }
}

public partial class MostSubmittedChart
{
    public string AgentSymbol { get; set; }
    public long ChartCount { get; set; }
}

public partial class Link
{
    public string Name { get; set; }
    public Uri Url { get; set; }
}

public partial class ServerResets
{
    public DateTimeOffset Next { get; set; }
    public string Frequency { get; set; }
}

public partial class Stats
{
    public long Agents { get; set; }
    public long Ships { get; set; }
    public long Systems { get; set; }
    public long Waypoints { get; set; }
}
