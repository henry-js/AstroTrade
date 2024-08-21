// <auto-generated/>
using Microsoft.Kiota.Abstractions.Extensions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace SpaceTraders.Api.My.Ships.Item.Mounts.Install
{
    /// <summary>
    /// Builds and executes requests for operations under \my\ships\{shipSymbol}\mounts\install
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
    public partial class InstallRequestBuilder : BaseRequestBuilder
    {
        /// <summary>
        /// Instantiates a new <see cref="global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public InstallRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/ships/{shipSymbol}/mounts/install", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        public InstallRequestBuilder(string rawUrl, IRequestAdapter requestAdapter) : base(requestAdapter, "{+baseurl}/my/ships/{shipSymbol}/mounts/install", rawUrl)
        {
        }
        /// <summary>
        /// Install a mount on a ship.In order to install a mount, the ship must be docked and located in a waypoint that has a `Shipyard` trait. The ship also must have the mount to install in its cargo hold.An installation fee will be deduced by the Shipyard for installing the mount on the ship. 
        /// </summary>
        /// <returns>A <see cref="global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallPostResponse"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallPostResponse?> PostAsInstallPostResponseAsync(global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallPostResponse> PostAsInstallPostResponseAsync(global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            return await RequestAdapter.SendAsync<global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallPostResponse>(requestInfo, global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallPostResponse.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Install a mount on a ship.In order to install a mount, the ship must be docked and located in a waypoint that has a `Shipyard` trait. The ship also must have the mount to install in its cargo hold.An installation fee will be deduced by the Shipyard for installing the mount on the ship. 
        /// </summary>
        /// <returns>A <see cref="global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallResponse"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        [Obsolete("This method is obsolete. Use PostAsInstallPostResponseAsync instead.")]
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public async Task<global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallResponse?> PostAsync(global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#nullable restore
#else
        public async Task<global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallResponse> PostAsync(global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default, CancellationToken cancellationToken = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = ToPostRequestInformation(body, requestConfiguration);
            return await RequestAdapter.SendAsync<global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallResponse>(requestInfo, global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallResponse.CreateFromDiscriminatorValue, default, cancellationToken).ConfigureAwait(false);
        }
        /// <summary>
        /// Install a mount on a ship.In order to install a mount, the ship must be docked and located in a waypoint that has a `Shipyard` trait. The ship also must have the mount to install in its cargo hold.An installation fee will be deduced by the Shipyard for installing the mount on the ship. 
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="body">The request body</param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToPostRequestInformation(global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToPostRequestInformation(global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallPostRequestBody body, Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation(Method.POST, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            return requestInfo;
        }
        /// <summary>
        /// Returns a request builder with the provided arbitrary URL. Using this method means any other path or query parameters are ignored.
        /// </summary>
        /// <returns>A <see cref="global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallRequestBuilder"/></returns>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallRequestBuilder WithUrl(string rawUrl)
        {
            return new global::SpaceTraders.Api.My.Ships.Item.Mounts.Install.InstallRequestBuilder(rawUrl, RequestAdapter);
        }
        /// <summary>
        /// Configuration for the request such as headers, query parameters, and middleware options.
        /// </summary>
        [Obsolete("This class is deprecated. Please use the generic RequestConfiguration class generated by the generator.")]
        [global::System.CodeDom.Compiler.GeneratedCode("Kiota", "1.17.0")]
        public partial class InstallRequestBuilderPostRequestConfiguration : RequestConfiguration<DefaultQueryParameters>
        {
        }
    }
}
