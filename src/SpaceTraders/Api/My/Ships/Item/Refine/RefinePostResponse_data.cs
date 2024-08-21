// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using SpaceTraders.Api.Models;
using System.Collections.Generic;
using System.IO;
using System;
namespace SpaceTraders.Api.My.Ships.Item.Refine
{
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    #pragma warning disable CS1591
    public partial class RefinePostResponse_data : IAdditionalDataHolder, IParsable
    #pragma warning restore CS1591
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Ship cargo details.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::SpaceTraders.Api.Models.ShipCargo? Cargo { get; set; }
#nullable restore
#else
        public global::SpaceTraders.Api.Models.ShipCargo Cargo { get; set; }
#endif
        /// <summary>Goods that were consumed during this refining process.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::SpaceTraders.Api.My.Ships.Item.Refine.RefinePostResponse_data_consumed>? Consumed { get; set; }
#nullable restore
#else
        public List<global::SpaceTraders.Api.My.Ships.Item.Refine.RefinePostResponse_data_consumed> Consumed { get; set; }
#endif
        /// <summary>A cooldown is a period of time in which a ship cannot perform certain actions.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::SpaceTraders.Api.Models.Cooldown? Cooldown { get; set; }
#nullable restore
#else
        public global::SpaceTraders.Api.Models.Cooldown Cooldown { get; set; }
#endif
        /// <summary>Goods that were produced by this refining process.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::SpaceTraders.Api.My.Ships.Item.Refine.RefinePostResponse_data_produced>? Produced { get; set; }
#nullable restore
#else
        public List<global::SpaceTraders.Api.My.Ships.Item.Refine.RefinePostResponse_data_produced> Produced { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::SpaceTraders.Api.My.Ships.Item.Refine.RefinePostResponse_data"/> and sets the default values.
        /// </summary>
        public RefinePostResponse_data()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::SpaceTraders.Api.My.Ships.Item.Refine.RefinePostResponse_data"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::SpaceTraders.Api.My.Ships.Item.Refine.RefinePostResponse_data CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::SpaceTraders.Api.My.Ships.Item.Refine.RefinePostResponse_data();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "cargo", n => { Cargo = n.GetObjectValue<global::SpaceTraders.Api.Models.ShipCargo>(global::SpaceTraders.Api.Models.ShipCargo.CreateFromDiscriminatorValue); } },
                { "consumed", n => { Consumed = n.GetCollectionOfObjectValues<global::SpaceTraders.Api.My.Ships.Item.Refine.RefinePostResponse_data_consumed>(global::SpaceTraders.Api.My.Ships.Item.Refine.RefinePostResponse_data_consumed.CreateFromDiscriminatorValue)?.AsList(); } },
                { "cooldown", n => { Cooldown = n.GetObjectValue<global::SpaceTraders.Api.Models.Cooldown>(global::SpaceTraders.Api.Models.Cooldown.CreateFromDiscriminatorValue); } },
                { "produced", n => { Produced = n.GetCollectionOfObjectValues<global::SpaceTraders.Api.My.Ships.Item.Refine.RefinePostResponse_data_produced>(global::SpaceTraders.Api.My.Ships.Item.Refine.RefinePostResponse_data_produced.CreateFromDiscriminatorValue)?.AsList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<global::SpaceTraders.Api.Models.ShipCargo>("cargo", Cargo);
            writer.WriteCollectionOfObjectValues<global::SpaceTraders.Api.My.Ships.Item.Refine.RefinePostResponse_data_consumed>("consumed", Consumed);
            writer.WriteObjectValue<global::SpaceTraders.Api.Models.Cooldown>("cooldown", Cooldown);
            writer.WriteCollectionOfObjectValues<global::SpaceTraders.Api.My.Ships.Item.Refine.RefinePostResponse_data_produced>("produced", Produced);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
