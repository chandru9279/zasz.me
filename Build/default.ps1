properties {
  $SolutionPath = '..\'
  $SolutionFile = $SolutionPath + 'zasz.me.sln'
  $ToolsPath = $SolutionPath + 'Build\Lib\'
  $PackagesPath = $SolutionPath + 'packages\'
  $SolrPath = $SolutionPath + 'Solr\'
}

task default -depends app

task app -depends Compile, Clean { 
  $SolutionPath 
}

task db { 
  java -version
}

#Starts solr in a new console window
task solrc { 
  Set-Location $SolrPath
  cmd.exe /c start cmd /k java '-Djetty.port=5000' '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar
}

#Starts solr as a process without console
task solrs { 
  Set-Location $SolrPath
  javaw '-Djetty.port=5000' '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar
}

#Stops a running solr
task solrx { 
  Set-Location $SolrPath
  java '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar --stop
}

task compile -depends Clean { 
  msbuild $SolutionFile /v:Quiet /t:Build
}

task clean { 
    @('zasz.me\bin\*' 
    'zasz.me\obj\*'
    'zasz.develop\bin\*'
    'zasz.develop\obj\*'
    'zasz.health\bin\*' 
    'zasz.health\obj\*'
    'TestResults\*') | % { Skip-Delete ($SolutionPath + $_) }

    msbuild $SolutionFile /v:Quiet /t:Clean 
}

task packages { 
    $nuget = $ToolsPath + 'NuGet.exe'
    Remove-Item ($PackagesPath + '*') -recurse
    &$nuget update -self
    &$nuget i ..\zasz.me\packages.config -o $PackagesPath
    &$nuget i ..\zasz.develop\packages.config -o $PackagesPath
    &$nuget i ..\zasz.health\packages.config -o $PackagesPath
}