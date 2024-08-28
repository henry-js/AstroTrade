namespace AstroTrade.Domain.SpaceTraders;

// public class RegistrationResponse
// {
//     public Data Data { get; set; }
// }

public class RegistrationResponse
{
    public Agent Agent { get; set; }

    public Contract Contract { get; set; }

    public Faction Faction { get; set; }

    public Ship Ship { get; set; }

    public string Token { get; set; }
}
