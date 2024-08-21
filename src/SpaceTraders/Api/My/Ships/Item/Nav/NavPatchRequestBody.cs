// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using SpaceTraders.Api.Models;
using System.Collections.Generic;
using System.IO;
using System;
namespace SpaceTraders.Api.My.Ships.Item.Nav
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    #pragma warning disable CS1591
    public partial class NavPatchRequestBody : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The ship&apos;s set speed when traveling between waypoints or systems.</summary>
        public global::SpaceTraders.Api.Models.ShipNavFlightMode? FlightMode { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::SpaceTraders.Api.My.Ships.Item.Nav.NavPatchRequestBody"/> and sets the default values.
        /// </summary>
        public NavPatchRequestBody()
        {
            AdditionalData = new Dictionary<string, object>();
            FlightMode = global::SpaceTraders.Api.Models.ShipNavFlightMode.CRUISE;
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::SpaceTraders.Api.My.Ships.Item.Nav.NavPatchRequestBody"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::SpaceTraders.Api.My.Ships.Item.Nav.NavPatchRequestBody CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::SpaceTraders.Api.My.Ships.Item.Nav.NavPatchRequestBody();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "flightMode", n => { FlightMode = n.GetEnumValue<global::SpaceTraders.Api.Models.ShipNavFlightMode>(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteEnumValue<global::SpaceTraders.Api.Models.ShipNavFlightMode>("flightMode", FlightMode);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
