properties {
  $SolutionPath = (Resolve-Path '..').Path
  $SolutionFile = "$SolutionPath\zasz.me.sln"
  $ToolsPath = "$SolutionPath\Build\Lib\"
  $PackagesPath = "$SolutionPath\packages\"
  $SolrPath = "$SolutionPath\Solr\"
}

task default -depends app

task app -depends compile { 
  $SolutionPath 
}

task db  { 
  $migrator = $ToolsPath + 'Migrations\migrate.exe'  
  $migrateCommand = "$migrator zasz_me.dll /StartUpDirectory=$SolutionPath\zasz.me\bin\ /connectionStringName:FullContext /startUpConfigurationFile:$SolutionPath\zasz.me\Web.config /verbose"
  Write-Host $migrateCommand
  Invoke-Expression $migrateCommand
}


task solrc -precondition { if(Test-Solr) { Write-Host -ForegroundColor Yellow "Solr is already running"; return $false; } return $true; } { 
  #Starts solr in a new console window
  Set-Location $SolrPath
  cmd.exe /c start cmd /k java '-Djetty.port=5000' '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar
}


task solrs -precondition { if(Test-Solr) { Write-Host -ForegroundColor Yellow "Solr is already running"; return $false; } return $true; } -action { 
  #Starts solr as a process without console
  Set-Location $SolrPath
  javaw '-Djetty.port=5000' '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar
}


task solrx -precondition { return Test-Solr } { 
  #Stops a running solr
  Set-Location $SolrPath
  java '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar --stop
}


task solrclean { 
  @('Solr\work\' 
    'Solr\logs\') | % { Skip-Delete ("$SolutionPath\$_") }
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
    'TestResults\') | % { Skip-Delete ("$SolutionPath\$_") }

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