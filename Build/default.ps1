properties {
	$SolutionPath = (Resolve-Path '..').Path
	$SolutionFile = "$SolutionPath\zasz.me.sln"
	$ToolsPath = "$SolutionPath\Build\Lib\"
	$PackagesPath = "$SolutionPath\packages\"
	$SolrPath = "$SolutionPath\Solr\"
	$DeployPath = "C:\Bin\"
	$BuildPath = "$SolutionPath\Out\Deploy"
    $MigrateTest = $true
}


task default -depends opendev


task build -depends clean {
	#Weird .net issue Any CPU vs AnyCPU
	exec { msbuild $SolutionPath\zasz.me\zasz.me.csproj /p:Configuration=Server /p:MvcBuildViews=true /p:Platform=AnyCPU /p:OutputPath=$BuildPath /v:Quiet}
	Write-Host -ForegroundColor Green "Server build complete."
}


task zip -depends build {
	$zipExe = "$ToolsPath\7z\7z.exe";
	$arguments = "a", "-tzip", "$SolutionPath\Out\Deploy.zip", $BuildPath, "-r";
	exec { &$zipExe $arguments }
	Write-Host -ForegroundColor Green "Zip in $SolutionPath\Out\Deploy.zip."
}


task deploy -depends build, migrate, solrs {
	Trace-Robocopy { robocopy "$BuildPath\_PublishedWebsites" $DeployPath /E /NJH /NJS }
	Write-Host -ForegroundColor Green "Deployed to $DeployPath."
}


task deploycode -depends build {
	Trace-Robocopy { robocopy $BuildPath $DeployPath /E /NJH /NJS }
	Write-Host -ForegroundColor Green "Deployed to $DeployPath."
}


task test -depends compile { 
	$xUnit = $ToolsPath + 'xUnit\xunit.console.clr4.x86.exe'  
	$testCommand = "$xUnit $SolutionPath\zasz.health\bin\zasz.health.dll /html $SolutionPath\Out\TestResults.html"
	Write-Host $testCommand
	exec { Invoke-Expression $testCommand }
	Write-Host -ForegroundColor Green "All tests pass."
}


task db -depends migrate, migratetest


task migrate -depends build { 
	$migrator = $ToolsPath + 'Migrations\migrate.exe'  
	$migrateCommand = "$migrator zasz.me.dll /StartUpDirectory=$SolutionPath\zasz.me\bin\ /connectionStringName:FullContext /startUpConfigurationFile:$SolutionPath\zasz.me\Web.config /verbose"
	Write-Host $migrateCommand
	exec { Invoke-Expression $migrateCommand }
	Write-Host -ForegroundColor Green "Migrated db to the latest version."        
}


task migratetest -depends compile { 
	$migrator = $ToolsPath + 'Migrations\migrate.exe'  
	$migrateCommand = "$migrator zasz.me.dll /StartUpDirectory=$SolutionPath\zasz.health\bin\ /connectionStringName:TestContext /startUpConfigurationFile:$SolutionPath\zasz.health\App.config /verbose"
    Write-Host $migrateCommand
    exec { Invoke-Expression $migrateCommand }
    Write-Host -ForegroundColor Green "Migrated test db."    
}


task solrc -precondition { !(Test-Solr) } { 
	#Starts solr in a new console window  
	Set-Location $SolrPath
	exec { cmd.exe /c start cmd /c java '-Djetty.port=5000' '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar }
	Write-Host -ForegroundColor Green "Solr console started now."	
	$state = Get-State
	if(-not $state.SolrOpened) {
		Open-Solr
		$state.SolrOpened = $true
		Set-State $state
	}
}


task solrs -precondition { !(Test-Solr) } -action { 
	#Starts solr as a process without console	
    Set-Location $SolrPath
	javaw '-Djetty.port=5000' '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar      
	Write-Host -ForegroundColor Green "Solr process started now."
}


task solrx -precondition { return Test-Solr } { 
	#Stops a running solr
	Set-Location $SolrPath
	exec { java '-DSTOP.PORT=5001' '-DSTOP.KEY=halt' -jar start.jar --stop }
	Write-Host -ForegroundColor Green "Solr stopped now."
}

task reindex -depends reload -precondition { return Test-Solr } { 
	$url = 'http://localhost:5000/solr/dataimport?verbose=true&clean=true&commit=true&command=full-import'  
	$xml = Get-Url $url 'Full Import with clean failed!'
	if([string]::IsNullOrEmpty($xml)) { throw 'Returned xml is null ' } else { Write-Host "`r`n`r`n$xml" }
	
	$state = Get-State
	if(-not $state.SolrDataImportOpened) {
		Open-Solr "http://localhost:5000/solr/admin/dataimport.jsp?handler=/dataimport"
		$state.SolrDataImportOpened = $true
		Set-State $state
	}
}

task reload -precondition { return Test-Solr } { 	
	$url = 'http://localhost:5000/solr/admin/cores?action=RELOAD&core=zasz.me.core'
	$xml = Get-Url $url 'Reload configuration failed!'
	if([string]::IsNullOrEmpty($xml)) { throw 'Returned xml is null ' } else { Write-Host "`r`n`r`n$xml" }	
}

task solrclean { 
	@('Solr\work\' 
		'Solr\logs\') | % { Skip-Delete ("$SolutionPath\$_") }
	Write-Host -ForegroundColor Green "Solr cleaned logs and working folder."
}


task compile -depends clean { 
	exec { msbuild $SolutionFile /p:Configuration=Dev /p:Platform="Any CPU" /v:Quiet /t:Build }
	Write-Host -ForegroundColor Green "App compiled in Dev mode"
}


task clean {
	exec { msbuild $SolutionFile /v:Quiet /t:Clean }
	@('zasz.me\bin\' 
	'zasz.me\obj\'
	'zasz.health\bin\' 
	'zasz.health\obj\'
	'Out\') | % { Remove-Item "$SolutionPath\$_\*" -Recurse -exclude .gitkeep -ErrorAction SilentlyContinue }
	Write-Host -ForegroundColor Green "Cleaned all bin obj. Cleaned Out folder."
}


task packages { 
		$nuget = $ToolsPath + 'NuGet.exe'
		$packageSource = 'https://nuget.org/api/v2/'
		if(Test-Path $PackagesPath) { Remove-Item $PackagesPath -Recurse -Force }
		exec { 
		&$nuget update -self
		&$nuget i ..\zasz.me\packages.config -o $PackagesPath -Source $packageSource
		&$nuget i ..\zasz.health\packages.config -o $PackagesPath -Source $packageSource
		}
}


task st {	
	$state = Get-State 
	$state.Keys | % { Write-Host "$_ :" $state[$_] }
}


task opendev -depends solrs {	
	Invoke-Item "$SolutionFile"
}