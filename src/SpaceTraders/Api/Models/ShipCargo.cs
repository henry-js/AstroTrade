// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace SpaceTraders.Api.Models
{
    /// <summary>
    /// Ship cargo details.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public partial class ShipCargo : IAdditionalDataHolder, IParsable
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The max number of items that can be stored in the cargo hold.</summary>
        public int? Capacity { get; set; }
        /// <summary>The items currently in the cargo hold.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::SpaceTraders.Api.Models.ShipCargoItem>? Inventory { get; set; }
#nullable restore
#else
        public List<global::SpaceTraders.Api.Models.ShipCargoItem> Inventory { get; set; }
#endif
        /// <summary>The number of items currently stored in the cargo hold.</summary>
        public int? Units { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::SpaceTraders.Api.Models.ShipCargo"/> and sets the default values.
        /// </summary>
        public ShipCargo()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::SpaceTraders.Api.Models.ShipCargo"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::SpaceTraders.Api.Models.ShipCargo CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::SpaceTraders.Api.Models.ShipCargo();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "capacity", n => { Capacity = n.GetIntValue(); } },
                { "inventory", n => { Inventory = n.GetCollectionOfObjectValues<global::SpaceTraders.Api.Models.ShipCargoItem>(global::SpaceTraders.Api.Models.ShipCargoItem.CreateFromDiscriminatorValue)?.AsList(); } },
                { "units", n => { Units = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("capacity", Capacity);
            writer.WriteCollectionOfObjectValues<global::SpaceTraders.Api.Models.ShipCargoItem>("inventory", Inventory);
            writer.WriteIntValue("units", Units);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
