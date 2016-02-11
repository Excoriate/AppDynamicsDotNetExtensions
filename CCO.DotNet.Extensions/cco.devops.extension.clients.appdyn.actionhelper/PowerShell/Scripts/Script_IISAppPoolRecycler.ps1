#PowerShell Script by Alex Torres (CCO-Ecommerce). 
#This Script receive a parameter from any application, console, process or executable.  This parameter 
#should be an integer, that represente the order of Application pool listed in IIS instance
#that we cant to recycle. 
#Use with precaution

Import-Module WebAdministration -ErrorAction SilentlyContinue 
$appPoolOrder = args[0]	 
$pooltable = @{} 
$pools = gci iis:\apppools 
$i = 0  
foreach ($a in $pools )
{
	$pool = $a.Name
	$i += 1
	$pooltable.Add($i, $pool)
	Write-Host "$i > Application Pool's listed in IIS Instance: $pool "
} 
Write-Host ""    
	
	foreach ($h in $pooltable.GetEnumerator()) 
	{   
		$key = $h.Name
		$val = $h.Value  
			if ($key -eq $appPoolOrder)
			{
				Write-Host "Recycled : $val"           
				Restart-WebAppPool $val        
			}  
	}
   
Write-Host "Operation Complete" -ForegroundColor Magenta 
Write-Host "" 