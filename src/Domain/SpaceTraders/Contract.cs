namespace AstroTrade.Domain.SpaceTraders;

public class Contract
{
    public string Id { get; set; }

    public string FactionSymbol { get; set; }

    public string Type { get; set; }

    public Terms Terms { get; set; }

    public bool Accepted { get; set; }

    public bool Fulfilled { get; set; }

    public DateTimeOffset Expiration { get; set; }

    public DateTimeOffset DeadlineToAccept { get; set; }
}
