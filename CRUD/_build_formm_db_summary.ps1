$ErrorActionPreference = 'Stop'
$base = "E:\COPY Project 2018\RERA2018 project\CRUD"
$csvPath = Join-Path $base "FormM_Flow_Controller_Action_Method_SP_Table_Mapping.csv"
$dumpPath = Join-Path $base "Dump20260506"
$outPath = Join-Path $base "FormM_Flow_With_DB_SP_Summaries.csv"

$rows = Import-Csv -Path $csvPath
$dump = Get-Content -Path $dumpPath -Raw

function Get-SpBlock([string]$spName, [string]$text) {
    $needle = "PROCEDURE ``$spName``"
    $start = $text.IndexOf($needle, [System.StringComparison]::OrdinalIgnoreCase)
    if ($start -lt 0) { return $null }

    $beginPos = $text.IndexOf("BEGIN", $start, [System.StringComparison]::OrdinalIgnoreCase)
    if ($beginPos -lt 0) { return $null }

    $endPos = $text.IndexOf("END ;;", $beginPos, [System.StringComparison]::OrdinalIgnoreCase)
    if ($endPos -lt 0) { return $null }

    return $text.Substring($beginPos, $endPos - $beginPos)
}

function Get-TablesFromBlock([string]$block) {
    if ([string]::IsNullOrWhiteSpace($block)) { return "Not found in dump" }
    $set = New-Object 'System.Collections.Generic.HashSet[string]'
    $patterns = @(
        '(?i)\bfrom\s+`?([a-zA-Z0-9_]+)`?',
        '(?i)\bjoin\s+`?([a-zA-Z0-9_]+)`?',
        '(?i)\binsert\s+into\s+`?([a-zA-Z0-9_]+)`?',
        '(?i)\bupdate\s+`?([a-zA-Z0-9_]+)`?',
        '(?i)\bdelete\s+from\s+`?([a-zA-Z0-9_]+)`?'
    )
    foreach ($p in $patterns) {
        $matches = [regex]::Matches($block, $p)
        foreach ($m in $matches) { $null = $set.Add($m.Groups[1].Value) }
    }
    if ($set.Count -eq 0) { return "No table token parsed" }
    return ((@($set) | Sort-Object) -join '; ')
}

function Get-SpSummary([string]$spName, [string]$block) {
    if ([string]::IsNullOrWhiteSpace($block)) { return "Procedure definition not found in supplied dump." }
    $hasInsert = [regex]::IsMatch($block,'(?i)\binsert\s+into\b')
    $hasUpdate = [regex]::IsMatch($block,'(?i)\bupdate\b')
    $hasDelete = [regex]::IsMatch($block,'(?i)\bdelete\s+from\b')
    $hasSelect = [regex]::IsMatch($block,'(?i)\bselect\b')

    if ($spName -match '(?i)validate') { return 'Validates business rules/eligibility and returns a status/output flag for current Form M step.' }
    if ($spName -match '(?i)paymentgateway') {
        if ($hasInsert) { return 'Creates initial payment-gateway transaction record before redirecting user to payment gateway.' }
        if ($hasUpdate) { return 'Updates payment transaction status and gateway response fields after callback.' }
        return 'Fetches payment transaction rows for Form M display/reconciliation.'
    }
    if ($spName -match '(?i)FactsCase') {
        if ($hasInsert) { return 'Stores Facts of Case document metadata and links it with complaint/profile.' }
        if ($hasDelete) { return 'Deletes selected Facts of Case document row using ids.' }
        return 'Fetches Facts of Case document rows for display/validation.'
    }
    if ($spName -match '(?i)RegDiaryNumber') {
        if ($hasInsert -or $hasUpdate) { return 'Writes diary/registration mapping and marks verification completion flags.' }
        return 'Checks diary/registration prerequisites before final verification submit.'
    }
    if ($spName -match '(?i)AdditionalComplainant|AddtionComplainant') {
        if ($hasInsert) { return 'Adds one additional complainant party record for Form M.' }
        if ($hasDelete) { return 'Deletes one additional complainant party record for Form M.' }
        return 'Fetches additional complainant records for Form M.'
    }
    if ($spName -match '(?i)AdditionalRespondent|AddtionRespondent') {
        if ($hasInsert) { return 'Adds one additional respondent party record for Form M.' }
        if ($hasDelete) { return 'Deletes one additional respondent party record for Form M.' }
        return 'Fetches additional respondent records for Form M.'
    }
    if ($spName -match '(?i)UserProfile') {
        if ($hasInsert) { return 'Creates complainant profile used by complaint forms.' }
        if ($hasUpdate) { return 'Updates complainant profile used by complaint forms.' }
        return 'Fetches complainant profile details.'
    }
    if ($spName -match '(?i)listenclosuresdocuments|Documents') {
        if ($hasInsert) { return 'Stores enclosure document metadata and file linkage for Form M.' }
        if ($hasDelete) { return 'Deletes enclosure document record by ids.' }
        if ($hasUpdate) { return 'Updates document completion/status flag in workflow.' }
        return 'Fetches enclosure document list/details for Form M.'
    }
    if ($spName -match '(?i)formm_details|FormM_Registrationdetails') {
        if ($hasInsert) { return 'Creates primary Form M complaint row (step-1 fields + flags).' }
        if ($hasUpdate) { return 'Updates primary Form M complaint row (step-1 fields + flags).' }
        return 'Fetches primary Form M complaint row for edit/view.'
    }
    if ($spName -match '(?i)Flag_RegStep') { return 'Returns workflow completion flags to decide next step/page.' }
    if ($spName -match '(?i)statusRegdProjectandUnRegdProject') { return 'Returns registration/document status summary for Form M validations.' }

    if ($hasSelect -and -not $hasInsert -and -not $hasUpdate -and -not $hasDelete) { return 'Fetches Form M related records.' }
    if ($hasInsert -and -not $hasUpdate -and -not $hasDelete) { return 'Inserts Form M related records.' }
    if ($hasUpdate -and -not $hasInsert -and -not $hasDelete) { return 'Updates Form M related records.' }
    if ($hasDelete -and -not $hasInsert -and -not $hasUpdate) { return 'Deletes Form M related records.' }
    return 'Performs mixed read/write operations for Form M workflow.'
}

$spCache = @{}
foreach ($r in $rows) {
    $sp = $r.Stored_Procedure
    if (-not $spCache.ContainsKey($sp)) {
        $block = Get-SpBlock -spName $sp -text $dump
        $tables = Get-TablesFromBlock -block $block
        $summary = Get-SpSummary -spName $sp -block $block
        $spCache[$sp] = [PSCustomObject]@{ Tables = $tables; Summary = $summary }
    }
    $r.Database_Table_Name = $spCache[$sp].Tables
    Add-Member -InputObject $r -NotePropertyName "SP_Summary_For_Junior" -NotePropertyValue $spCache[$sp].Summary -Force
}

$rows | Export-Csv -Path $outPath -NoTypeInformation -Encoding UTF8
Write-Output "Created: $outPath"

