$xml = [xml](Get-Content results.xml)
$res = $xml.GetElementsByTagName('UnitTestResult')
$total = $res.Count
$pass = ($res | where {$_.outcome -eq 'Passed'}).Count
$fail = $total - $pass

$html = @"
<html>
<body style='font-family: Arial; background-color: #f4f7f6; padding: 20px;'>
    <div style='background-color: white; padding: 30px; border-radius: 15px; border: 1px solid #ddd; max-width: 800px; margin: auto;'>
        <h1 style='text-align: center; color: #333;'>🚀 Automation Test Execution Report</h1>
        
        <table style='width: 100%; margin-bottom: 20px;'>
            <tr>
                <td style='background-color: #3498db; color: white; padding: 20px; text-align: center; border-radius: 10px; width: 30%;'>
                    <b style='font-size: 1.2em;'>Total</b><br><span style='font-size: 2em;'>$total</span>
                </td>
                <td style='width: 5%;'></td>
                <td style='background-color: #2ecc71; color: white; padding: 20px; text-align: center; border-radius: 10px; width: 30%;'>
                    <b style='font-size: 1.2em;'>Passed</b><br><span style='font-size: 2em;'>$pass</span>
                </td>
                <td style='width: 5%;'></td>
                <td style='background-color: #e74c3c; color: white; padding: 20px; text-align: center; border-radius: 10px; width: 30%;'>
                    <b style='font-size: 1.2em;'>Failed</b><br><span style='font-size: 2em;'>$fail</span>
                </td>
            </tr>
        </table>

        <table style='width: 100%; border-collapse: collapse; margin-top: 20px;'>
            <thead>
                <tr style='background-color: #eee;'>
                    <th style='padding: 12px; text-align: left; border: 1px solid #ddd;'>Test Case Name</th>
                    <th style='padding: 12px; text-align: left; border: 1px solid #ddd;'>Status</th>
                </tr>
            </thead>
            <tbody>
"@

foreach($r in $res) {
    $bg = if($r.outcome -eq 'Passed') { '#d4edda' } else { '#f8d7da' }
    $color = if($r.outcome -eq 'Passed') { '#155724' } else { '#721c24' }
    $html += "<tr style='background-color: $bg;'>
                <td style='padding: 12px; border: 1px solid #ddd;'>$($r.testName)</td>
                <td style='padding: 12px; border: 1px solid #ddd; color: $color; font-weight: bold;'>$($r.outcome)</td>
              </tr>"
}

$html += "</tbody></table></div></body></html>"
$html | Out-File -FilePath results.html -Encoding utf8