using Mediator;

using SpaceTraders.Api.Models;

namespace AstroTrade.Core.Features.Agents.Register;

public sealed record RegisterAgentCommand(string Symbol, string Faction, string AccountToken) : ICommand<Agent>;
