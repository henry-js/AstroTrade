// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace SpaceTraders.Api.Models
{
    /// <summary>
    /// A module can be installed in a ship and provides a set of capabilities such as storage space or quarters for crew. Module installations are permanent.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public partial class ShipModule : IAdditionalDataHolder, IParsable
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Modules that provide capacity, such as cargo hold or crew quarters will show this value to denote how much of a bonus the module grants.</summary>
        public int? Capacity { get; set; }
        /// <summary>Description of this module.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Description { get; set; }
#nullable restore
#else
        public string Description { get; set; }
#endif
        /// <summary>Name of this module.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>Modules that have a range will such as a sensor array show this value to denote how far can the module reach with its capabilities.</summary>
        public int? Range { get; set; }
        /// <summary>The requirements for installation on a ship</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::SpaceTraders.Api.Models.ShipRequirements? Requirements { get; set; }
#nullable restore
#else
        public global::SpaceTraders.Api.Models.ShipRequirements Requirements { get; set; }
#endif
        /// <summary>The symbol of the module.</summary>
        public global::SpaceTraders.Api.Models.ShipModule_symbol? Symbol { get; set; }
        /// <summary>
        /// Instantiates a new <see cref="global::SpaceTraders.Api.Models.ShipModule"/> and sets the default values.
        /// </summary>
        public ShipModule()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::SpaceTraders.Api.Models.ShipModule"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::SpaceTraders.Api.Models.ShipModule CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::SpaceTraders.Api.Models.ShipModule();
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
                { "description", n => { Description = n.GetStringValue(); } },
                { "name", n => { Name = n.GetStringValue(); } },
                { "range", n => { Range = n.GetIntValue(); } },
                { "requirements", n => { Requirements = n.GetObjectValue<global::SpaceTraders.Api.Models.ShipRequirements>(global::SpaceTraders.Api.Models.ShipRequirements.CreateFromDiscriminatorValue); } },
                { "symbol", n => { Symbol = n.GetEnumValue<global::SpaceTraders.Api.Models.ShipModule_symbol>(); } },
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
            writer.WriteStringValue("description", Description);
            writer.WriteStringValue("name", Name);
            writer.WriteIntValue("range", Range);
            writer.WriteObjectValue<global::SpaceTraders.Api.Models.ShipRequirements>("requirements", Requirements);
            writer.WriteEnumValue<global::SpaceTraders.Api.Models.ShipModule_symbol>("symbol", Symbol);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
