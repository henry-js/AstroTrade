// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using System.Collections.Generic;
using System.IO;
using System;
namespace SpaceTraders.Api.Models
{
    /// <summary>
    /// The terms to fulfill the contract.
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public partial class ContractTerms : IAdditionalDataHolder, IParsable
    {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The deadline for the contract.</summary>
        public DateTimeOffset? Deadline { get; set; }
        /// <summary>The cargo that needs to be delivered to fulfill the contract.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<global::SpaceTraders.Api.Models.ContractDeliverGood>? Deliver { get; set; }
#nullable restore
#else
        public List<global::SpaceTraders.Api.Models.ContractDeliverGood> Deliver { get; set; }
#endif
        /// <summary>Payments for the contract.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public global::SpaceTraders.Api.Models.ContractPayment? Payment { get; set; }
#nullable restore
#else
        public global::SpaceTraders.Api.Models.ContractPayment Payment { get; set; }
#endif
        /// <summary>
        /// Instantiates a new <see cref="global::SpaceTraders.Api.Models.ContractTerms"/> and sets the default values.
        /// </summary>
        public ContractTerms()
        {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <returns>A <see cref="global::SpaceTraders.Api.Models.ContractTerms"/></returns>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static global::SpaceTraders.Api.Models.ContractTerms CreateFromDiscriminatorValue(IParseNode parseNode)
        {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new global::SpaceTraders.Api.Models.ContractTerms();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        /// <returns>A IDictionary&lt;string, Action&lt;IParseNode&gt;&gt;</returns>
        public virtual IDictionary<string, Action<IParseNode>> GetFieldDeserializers()
        {
            return new Dictionary<string, Action<IParseNode>>
            {
                { "deadline", n => { Deadline = n.GetDateTimeOffsetValue(); } },
                { "deliver", n => { Deliver = n.GetCollectionOfObjectValues<global::SpaceTraders.Api.Models.ContractDeliverGood>(global::SpaceTraders.Api.Models.ContractDeliverGood.CreateFromDiscriminatorValue)?.AsList(); } },
                { "payment", n => { Payment = n.GetObjectValue<global::SpaceTraders.Api.Models.ContractPayment>(global::SpaceTraders.Api.Models.ContractPayment.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public virtual void Serialize(ISerializationWriter writer)
        {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteDateTimeOffsetValue("deadline", Deadline);
            writer.WriteCollectionOfObjectValues<global::SpaceTraders.Api.Models.ContractDeliverGood>("deliver", Deliver);
            writer.WriteObjectValue<global::SpaceTraders.Api.Models.ContractPayment>("payment", Payment);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
