// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace SpaceTraders.Api.My.Ships.Item.Cooldown
{
    [Obsolete("This class is obsolete. Use CooldownGetResponse instead.")]
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    #pragma warning disable CS1591
    public partial class CooldownResponse : global::SpaceTraders.Api.My.Ships.Item.Cooldown.CooldownGetResponse, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::SpaceTraders.Api.My.Ships.Item.Cooldown.CooldownResponse"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new global::SpaceTraders.Api.My.Ships.Item.Cooldown.CooldownResponse CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::SpaceTraders.Api.My.Ships.Item.Cooldown.CooldownResponse();
        }
    }
}
