$xml = [xml](Get-Content results.xml)
$res = $xml.GetElementsByTagName('UnitTestResult')
$total = $res.Count
$pass = ($res | where {$_.outcome -eq 'Passed'}).Count
$fail = $total - $pass

$html = @"
<html>
<body style='font-family: Arial, sans-serif; background-color: #f4f7f6; padding: 30px;'>
    <div style='background: white; padding: 25px; border-radius: 15px; box-shadow: 0 10px 20px rgba(0,0,0,0.1); max-width: 800px; margin: auto;'>
        <h1 style='text-align: center; color: #2c3e50;'>🚀 Automation Test Report</h1>
        
        <div style='display: flex; justify-content: space-around; margin: 20px 0;'>
            <div style='background: #3498db; color: white; padding: 20px; border-radius: 10px; width: 28%; text-align: center;'>
                <span style='font-size: 0.9em;'>Total</span><br><span style='font-size: 1.8em; font-weight: bold;'>$total</span>
            </div>
            <div style='background: #2ecc71; color: white; padding: 20px; border-radius: 10px; width: 28%; text-align: center;'>
                <span style='font-size: 0.9em;'>Passed</span><br><span style='font-size: 1.8em; font-weight: bold;'>$pass</span>
            </div>
            <div style='background: #e74c3c; color: white; padding: 20px; border-radius: 10px; width: 28%; text-align: center;'>
                <span style='font-size: 0.9em;'>Failed</span><br><span style='font-size: 1.8em; font-weight: bold;'>$fail</span>
            </div>
        </div>

        <table style='width: 100%; border-collapse: collapse; margin-top: 20px;'>
            <thead>
                <tr style='background-color: #ecf0f1;'>
                    <th style='padding: 12px; text-align: left; border-bottom: 2px solid #bdc3c7;'>Test Case</th>
                    <th style='padding: 12px; text-align: left; border-bottom: 2px solid #bdc3c7;'>Status</th>
                    <th style='padding: 12px; text-align: left; border-bottom: 2px solid #bdc3c7;'>Duration</th>
                </tr>
            </thead>
            <tbody>
"@

foreach($r in $res) {
    $color = if($r.outcome -eq 'Passed') { '#27ae60' } else { '#c0392b' }
    $html += "<tr>
                <td style='padding: 12px; border-bottom: 1px solid #eee;'>$($r.testName)</td>
                <td style='padding: 12px; border-bottom: 1px solid #eee; color: $color; font-weight: bold;'>$($r.outcome)</td>
                <td style='padding: 12px; border-bottom: 1px solid #eee;'>$($r.duration)</td>
              </tr>"
}

$html += "</tbody></table></div></body></html>"
$html | Out-File -FilePath results.html -Encoding utf8