Properties {
    $MSBuildConfiguration="Release"
    $XunitConsole35="..\packages\xunit.runners.1.9.0.1566\tools\xunit.console.exe"
    $XunitConsole40="..\packages\xunit.runners.1.9.0.1566\tools\xunit.console.clr4.exe"
}

Task Default -depends Test

Task Test -depends Build {
    Exec { .$XunitConsole35 "test\Xbehave.Test.Net35\bin\Debug\Xbehave.Test.dll" /noshadow /nunit "test\Xbehave.Test.Net35\bin\Debug\XBehave.Test.Results.xml" /html "test\Xbehave.Test.Net35\bin\Debug\XBehave.Test.Results.html" }
    Exec { .$XunitConsole40 "test\Xbehave.Test.Net40\bin\Debug\Xbehave.Test.dll" /noshadow /nunit "test\Xbehave.Test.Net40\bin\Debug\XBehave.Test.Results.xml" /html "test\Xbehave.Test.Net40\bin\Debug\XBehave.Test.Results.html" }
}

Task Build -depends Clean {
    Exec { msbuild "Xbehave.sln" /t:Build /p:Configuration=$MSBuildConfiguration }
}

Task Clean -depends ResolveVariables {
    Exec { msbuild "Xbehave.sln" /t:Clean /p:Configuration=$MSBuildConfiguration }
}

Task ResolveVariables {
    Write-Host "MSBuildConfiguration = $MSBuildConfiguration"
    Write-Host "XunitConsole35 = $XunitConsole35"
    Write-Host "XunitConsole40 = $XunitConsole40"
}