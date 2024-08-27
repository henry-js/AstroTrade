dotnet tool restore

$url = "https://stoplight.io/api/v1/projects/spacetraders/spacetraders/nodes/reference/SpaceTraders.json?fromExportButton=true&snapshotType=http_service&deref=optimizedBundle"
$output = "./ApiClient"
$namespace = "SpaceTraders.ApiClient"

dotnet kiota generate `
    --language csharp `
    --openapi $url `
    --output $output `
    --namespace-name $namespace `
    --class-name "Client" `
    --log-level Information `
    --clean-output

dotnet new classlib --output $output --framework net8.0 --language 'C#' --name $namespace --force

Remove-Item $output\Class1.cs

dotnet kiota info -d $url -l CSharp

dotnet add $output package Microsoft.Kiota.Abstractions --version 1.*
dotnet add $output package Microsoft.Kiota.Authentication.Azure --version 1.*
dotnet add $output package Microsoft.Kiota.Http.HttpClientLibrary --version 1.*
dotnet add $output package Microsoft.Kiota.Serialization.Form --version 1.*
dotnet add $output package Microsoft.Kiota.Serialization.Json --version 1.*
dotnet add $output package Microsoft.Kiota.Serialization.Multipart --version 1.*
dotnet add $output package Microsoft.Kiota.Serialization.Text --version 1.*
