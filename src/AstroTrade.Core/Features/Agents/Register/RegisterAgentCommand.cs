using AstroTrade.Core.Models;
using Mediator;

namespace AstroTrade.Core.Features.Agents.Register;

public sealed record RegisterAgentCommand(string Symbol, string Faction, string AccountToken)
    : ICommand<DomainAgent>;
