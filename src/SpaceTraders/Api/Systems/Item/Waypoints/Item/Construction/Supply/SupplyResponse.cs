// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace SpaceTraders.Api.Systems.Item.Waypoints.Item.Construction.Supply
{
    [Obsolete("This class is obsolete. Use SupplyPostResponse instead.")]
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    #pragma warning disable CS1591
    public partial class SupplyResponse : global::SpaceTraders.Api.Systems.Item.Waypoints.Item.Construction.Supply.SupplyPostResponse, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::SpaceTraders.Api.Systems.Item.Waypoints.Item.Construction.Supply.SupplyResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::SpaceTraders.Api.Systems.Item.Waypoints.Item.Construction.Supply.SupplyResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::SpaceTraders.Api.Systems.Item.Waypoints.Item.Construction.Supply.SupplyResponse();
        }
    }
}
