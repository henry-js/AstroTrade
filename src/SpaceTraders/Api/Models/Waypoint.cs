// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace SpaceTraders.Api.Models
{
    /// <summary>
    /// A waypoint is a location that ships can travel to such as a Planet, Moon or Space Station.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public partial class Waypoint : IAdditionalDataHolder, IParsable
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The chart of a system or waypoint, which makes the location visible to other agents.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::SpaceTraders.Api.Models.Chart? Chart { get; set; }
#nullable restore
#else
        public global::SpaceTraders.Api.Models.Chart Chart { get; set; }
#endif
        /// <summary>The faction that controls the waypoint.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::SpaceTraders.Api.Models.WaypointFaction? Faction { get; set; }
#nullable restore
#else
        public global::SpaceTraders.Api.Models.WaypointFaction Faction { get; set; }
#endif
        /// <summary>True if the waypoint is under construction.</summary>
        public bool? IsUnderConstruction { get; set; }
        /// <summary>The modifiers of the waypoint.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::SpaceTraders.Api.Models.WaypointModifier>? Modifiers { get; set; }
#nullable restore
#else
        public List<global::SpaceTraders.Api.Models.WaypointModifier> Modifiers { get; set; }
#endif
        /// <summary>Waypoints that orbit this waypoint.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::SpaceTraders.Api.Models.WaypointOrbital>? Orbitals { get; set; }
#nullable restore
#else
        public List<global::SpaceTraders.Api.Models.WaypointOrbital> Orbitals { get; set; }
#endif
        /// <summary>The symbol of the parent waypoint, if this waypoint is in orbit around another waypoint. Otherwise this value is undefined.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Orbits { get; set; }
#nullable restore
#else
        public string Orbits { get; set; }
#endif
        /// <summary>The symbol of the waypoint.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Symbol { get; set; }
#nullable restore
#else
        public string Symbol { get; set; }
#endif
        /// <summary>The symbol of the system.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? SystemSymbol { get; set; }
#nullable restore
#else
        public string SystemSymbol { get; set; }
#endif
        /// <summary>The traits of the waypoint.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::SpaceTraders.Api.Models.WaypointTrait>? Traits { get; set; }
#nullable restore
#else
        public List<global::SpaceTraders.Api.Models.WaypointTrait> Traits { get; set; }
#endif
        /// <summary>The type of waypoint.</summary>
        public global::SpaceTraders.Api.Models.WaypointType? Type { get; set; }
        /// <summary>Relative position of the waypoint on the system&apos;s x axis. This is not an absolute position in the universe.</summary>
        public int? X { get; set; }
        /// <summary>Relative position of the waypoint on the system&apos;s y axis. This is not an absolute position in the universe.</summary>
        public int? Y { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::SpaceTraders.Api.Models.Waypoint"/> and sets the default values.
        /// </summary>
        public Waypoint()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::SpaceTraders.Api.Models.Waypoint"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::SpaceTraders.Api.Models.Waypoint CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::SpaceTraders.Api.Models.Waypoint();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "chart", n => { Chart = n.GetObjectValue<global::SpaceTraders.Api.Models.Chart>(global::SpaceTraders.Api.Models.Chart.CreateFromDiscriminatorValue); } },
                { "faction", n => { Faction = n.GetObjectValue<global::SpaceTraders.Api.Models.WaypointFaction>(global::SpaceTraders.Api.Models.WaypointFaction.CreateFromDiscriminatorValue); } },
                { "isUnderConstruction", n => { IsUnderConstruction = n.GetBoolValue(); } },
                { "modifiers", n => { Modifiers = n.GetCollectionOfObjectValues<global::SpaceTraders.Api.Models.WaypointModifier>(global::SpaceTraders.Api.Models.WaypointModifier.CreateFromDiscriminatorValue)?.AsList(); } },
                { "orbitals", n => { Orbitals = n.GetCollectionOfObjectValues<global::SpaceTraders.Api.Models.WaypointOrbital>(global::SpaceTraders.Api.Models.WaypointOrbital.CreateFromDiscriminatorValue)?.AsList(); } },
                { "orbits", n => { Orbits = n.GetStringValue(); } },
                { "symbol", n => { Symbol = n.GetStringValue(); } },
                { "systemSymbol", n => { SystemSymbol = n.GetStringValue(); } },
                { "traits", n => { Traits = n.GetCollectionOfObjectValues<global::SpaceTraders.Api.Models.WaypointTrait>(global::SpaceTraders.Api.Models.WaypointTrait.CreateFromDiscriminatorValue)?.AsList(); } },
                { "type", n => { Type = n.GetEnumValue<global::SpaceTraders.Api.Models.WaypointType>(); } },
                { "x", n => { X = n.GetIntValue(); } },
                { "y", n => { Y = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::SpaceTraders.Api.Models.Chart>("chart", Chart);
            writer.WriteObjectValue<global::SpaceTraders.Api.Models.WaypointFaction>("faction", Faction);
            writer.WriteBoolValue("isUnderConstruction", IsUnderConstruction);
            writer.WriteCollectionOfObjectValues<global::SpaceTraders.Api.Models.WaypointModifier>("modifiers", Modifiers);
            writer.WriteCollectionOfObjectValues<global::SpaceTraders.Api.Models.WaypointOrbital>("orbitals", Orbitals);
            writer.WriteStringValue("orbits", Orbits);
            writer.WriteStringValue("symbol", Symbol);
            writer.WriteStringValue("systemSymbol", SystemSymbol);
            writer.WriteCollectionOfObjectValues<global::SpaceTraders.Api.Models.WaypointTrait>("traits", Traits);
            writer.WriteEnumValue<global::SpaceTraders.Api.Models.WaypointType>("type", Type);
            writer.WriteIntValue("x", X);
            writer.WriteIntValue("y", Y);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
