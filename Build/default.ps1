properties {
  $SolutionPath = (Resolve-Path '..').Path
  $SolutionFile = "$SolutionPath\zasz.me.sln"
  $ToolsPath = "$SolutionPath\Build\Lib\"
  $PackagesPath = "$SolutionPath\packages\"
  $SolrPath = "$SolutionPath\Solr\"
  $DeployPath = "C:\Bin\zasz.me\"
}


task default -depends compile


task deploy -depends test, db, solrs { 
  msbuild $SolutionFile /p:Configuration=Server /p:Platform="Any CPU" /v:Quiet /t:Build
}


task test -depends compile { 
  $xUnit = $ToolsPath + 'xUnit\xunit.console.clr4.x86.exe'  
  $testCommand = "$xUnit $SolutionPath\zasz.health\bin\zasz_health.dll /html $SolutionPath\Out\TestResults.html"
  Write-Host $testCommand
  exec { Invoke-Expression $testCommand }
}


task db -depends compile { 
  $migrator = $ToolsPath + 'Migrations\migrate.exe'  
  $migrateCommand = "$migrator zasz_me.dll /StartUpDirectory=$SolutionPath\zasz.me\bin\ /connectionStringName:FullContext /startUpConfigurationFile:$SolutionPath\zasz.me\Web.config /verbose"
  Write-Host $migrateCommand
  exec { Invoke-Expression $migrateCommand }
}


task solrc -precondition { if(Test-Solr) { Write-Host -ForegroundColor Yellow "Solr is already running"; return $false; } return $true; } { 
  #Starts solr in a new console window
  Set-Location $SolrPath
  exec { cmd.exe /c start cmd /c java '-Djetty.port=5000' '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar }
}


task solrs -precondition { if(Test-Solr) { Write-Host -ForegroundColor Yellow "Solr is already running"; return $false; } return $true; } -action { 
  #Starts solr as a process without console
  Set-Location $SolrPath
  exec { javaw '-Djetty.port=5000' '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar }
}


task solrx -precondition { return Test-Solr } { 
  #Stops a running solr
  Set-Location $SolrPath
  exec { java '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar --stop }
}


task solrclean { 
  @('Solr\work\' 
    'Solr\logs\') | % { Skip-Delete ("$SolutionPath\$_") }
}


task compile -depends Clean { 
  exec { msbuild $SolutionFile /v:Quiet /t:Build }
}


task clean { 
    @('zasz.me\bin\' 
    'zasz.me\obj\'
    'zasz.develop\bin\'
    'zasz.develop\obj\'
    'zasz.health\bin\' 
    'zasz.health\obj\'
    'Out\') | % { Skip-Delete ("$SolutionPath\$_") }

    exec { msbuild $SolutionFile /v:Quiet /t:Clean }
}


task packages { 
    $nuget = $ToolsPath + 'NuGet.exe'
    Remove-Item $PackagesPath -Recurse -Force
    exec { 
    &$nuget update -self
    &$nuget i ..\zasz.me\packages.config -o $PackagesPath
    &$nuget i ..\zasz.develop\packages.config -o $PackagesPath
    &$nuget i ..\zasz.health\packages.config -o $PackagesPath
    }
}