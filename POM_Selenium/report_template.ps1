# XML parhein aur data nikaalein
$xml = [xml](Get-Content results.xml)
$res = $xml.GetElementsByTagName('UnitTestResult')
$total = $res.Count
$pass = ($res | where {$_.outcome -eq 'Passed'}).Count
$fail = $total - $pass

# Colorful HTML Design
$html = @"
<html>
<head>
<style>
    body { font-family: 'Segoe UI', Tahoma, sans-serif; background: #f0f2f5; padding: 40px; }
    .card { background: white; padding: 30px; border-radius: 15px; box-shadow: 0 10px 30px rgba(0,0,0,0.1); max-width: 900px; margin: auto; }
    h1 { text-align: center; color: #1a73e8; margin-bottom: 30px; }
    .stats { display: flex; justify-content: space-between; margin-bottom: 30px; }
    .box { padding: 20px; border-radius: 12px; color: white; width: 30%; text-align: center; font-size: 1.1em; font-weight: bold; }
    .blue { background: #1a73e8; }
    .green { background: #34a853; }
    .red { background: #ea4335; }
    table { width: 100%; border-collapse: collapse; margin-top: 20px; }
    th { background: #f8f9fa; padding: 15px; text-align: left; color: #5f6368; border-bottom: 2px solid #eee; }
    td { padding: 15px; border-bottom: 1px solid #eee; color: #3c4043; }
    .Passed { color: #34a853; font-weight: bold; }
    .Failed { color: #ea4335; font-weight: bold; }
</style>
</head>
<body>
<div class='card'>
    <h1>Selenium Test Execution Report</h1>
    <div class='stats'>
        <div class='box blue'>Total Tests<br><span style='font-size:2em'>$total</span></div>
        <div class='box green'>Passed<br><span style='font-size:2em'>$pass</span></div>
        <div class='box red'>Failed<br><span style='font-size:2em'>$fail</span></div>
    </div>
    <table>
        <tr><th>Test Case Name</th><th>Result</th><th>Duration</th></tr>
"@

foreach($r in $res) {
    $status = $r.outcome
    $html += "<tr><td>$($r.testName)</td><td class='$status'>$status</td><td>$($r.duration)</td></tr>"
}

$html += "</table></div></body></html>"
$html | Out-File -FilePath results.html -Encoding utf8