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
  Import-Module ($PackagesPath + 'EntityFramework.5.0.0\tools\EntityFramework.psm1')
}

#Starts solr in a new console window
task solrc -precondition { if(Test-Solr) { Write-Host -ForegroundColor Yellow "Solr is already running"; return $false; } return $true; } { 
  Set-Location $SolrPath
  cmd.exe /c start cmd /k java '-Djetty.port=5000' '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar
}

#Starts solr as a process without console
task solrs -precondition { if(Test-Solr) { Write-Host -ForegroundColor Yellow "Solr is already running"; return $false; } return $true; } -action { 
  Set-Location $SolrPath
  javaw '-Djetty.port=5000' '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar
}

#Stops a running solr
task solrx -precondition { return Test-Solr } { 
  Set-Location $SolrPath
  java '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar --stop
}

task solrclean { 
  @('Solr\work\' 
    'Solr\logs\') | % { Skip-Delete ($SolutionPath + $_) }
}

task compile -depends Clean { 
  msbuild $SolutionFile /v:Quiet /t:Build
}

task clean { 
    @('zasz.me\bin\' 
    'zasz.me\obj\'
    'zasz.develop\bin\'
    'zasz.develop\obj\'
    'zasz.health\bin\' 
    'zasz.health\obj\'
    'TestResults\') | % { Skip-Delete ($SolutionPath + $_) }

    msbuild $SolutionFile /v:Quiet /t:Clean 
}

task packages { 
    $nuget = $ToolsPath + 'NuGet.exe'
    Remove-Item $PackagesPath -Recurse -Force
    &$nuget update -self
    &$nuget i ..\zasz.me\packages.config -o $PackagesPath
    &$nuget i ..\zasz.develop\packages.config -o $PackagesPath
    &$nuget i ..\zasz.health\packages.config -o $PackagesPath
}