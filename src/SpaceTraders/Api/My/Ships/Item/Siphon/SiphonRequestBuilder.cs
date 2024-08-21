// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace SpaceTraders.Api.My.Ships.Item.Siphon
{
    /// <summary>
    /// Builds and executes requests for operations under \my\ships\{shipSymbol}\siphon
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public partial class SiphonRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public SiphonRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/ships/{shipSymbol}/siphon", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public SiphonRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/ships/{shipSymbol}/siphon", rawUrl)
        {
        }
        /// <summary>
        /// Siphon gases, such as hydrocarbon, from gas giants.The ship must be in orbit to be able to siphon and must have siphon mounts and a gas processor installed.
        /// </summary>
        /// <returns>A <see cref="global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonPostResponse"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonPostResponse?> PostAsSiphonPostResponseAsync(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonPostResponse> PostAsSiphonPostResponseAsync(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToPostRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonPostResponse>(requestInfo, global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonPostResponse.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Siphon gases, such as hydrocarbon, from gas giants.The ship must be in orbit to be able to siphon and must have siphon mounts and a gas processor installed.
        /// </summary>
        /// <returns>A <see cref="global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonResponse"/></returns>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        [Obsolete("This method is obsolete. Use PostAsSiphonPostResponseAsync instead.")]
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonResponse?> PostAsync(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonResponse> PostAsync(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            var requestInfo = ToPostRequestInformation(requestConfiguration);
            return await RequestAdapter.SendAsync<global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonResponse>(requestInfo, global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonResponse.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Siphon gases, such as hydrocarbon, from gas giants.The ship must be in orbit to be able to siphon and must have siphon mounts and a gas processor installed.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.POST, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonRequestBuilder WithUrl(string rawUrl)
        {
            return new global::SpaceTraders.Api.My.Ships.Item.Siphon.SiphonRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
        public partial class SiphonRequestBuilderPostRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
    }
}
