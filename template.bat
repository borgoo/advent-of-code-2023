@echo off
REM Template generator for Advent of Code 2023
REM Usage: template.bat [day_number]
REM Example: template.bat 19

REM Enable ANSI escape sequences
for /f %%A in ('echo prompt $E ^| cmd') do set "ESC=%%A"

setlocal enabledelayedexpansion

if "%1"=="" (
    echo Error: Day number is required
    echo Usage: template.bat [day_number] [-rf]
    echo Example: template.bat 19
    echo          template.bat 18 -rf ^(to remove Day 18^)
    exit /b 1
)

set "DAY=%1"
set "ACTION=%2"

REM Validate day number
if not "%DAY:~0,1%"=="%DAY%" set "DAY=%DAY%"
for /f "delims=0123456789" %%i in ("%DAY%") do (
    echo Error: Day number must be a positive integer
    exit /b 1
)

REM Check for remove flag
if /i "%ACTION%"=="-rf" (
    if exist "docs\Day%DAY%" (
        rmdir /s /q "docs\Day%DAY%" 2>nul
        if not exist "docs\Day%DAY%" echo %ESC%[92mRemoved:%ESC%[0m docs\Day%DAY%
    ) else (
        echo %ESC%[93mWarning:%ESC%[0m docs\Day%DAY% does not exist
    )
    
    if exist "src\AdventOfCode2023.Core\Day%DAY%" (
        rmdir /s /q "src\AdventOfCode2023.Core\Day%DAY%" 2>nul
        if not exist "src\AdventOfCode2023.Core\Day%DAY%" echo %ESC%[92mRemoved:%ESC%[0m src\AdventOfCode2023.Core\Day%DAY%
    ) else (
        echo %ESC%[93mWarning:%ESC%[0m src\AdventOfCode2023.Core\Day%DAY% does not exist
    )
    
    if exist "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%" (
        rmdir /s /q "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%" 2>nul
        if not exist "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%" echo %ESC%[92mRemoved:%ESC%[0m tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%
    ) else (
        echo %ESC%[93mWarning:%ESC%[0m tests\UnitTests\AdventOfCode2023.Tests\Day%DAY% does not exist
    )
    
    echo.
    echo Day%DAY% directories removed%ESC%[92m successfully!%ESC%[0m
    echo.
    exit /b 0
)

REM Check if directories already exist
if exist "docs\Day%DAY%" (
    echo %ESC%[91mERROR:%ESC%[0m Directory docs\Day%DAY% already exists!
    echo Cannot create template - Day %DAY% has already been initialized.
    exit /b 1
)

if exist "src\AdventOfCode2023.Core\Day%DAY%" (
    echo %ESC%[91mERROR:%ESC%[0m Directory src\AdventOfCode2023.Core\Day%DAY% already exists!
    echo Cannot create template - Day %DAY% has already been initialized.
    exit /b 1
)

if exist "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%" (
    echo %ESC%[91mERROR:%ESC%[0m Directory tests\UnitTests\AdventOfCode2023.Tests\Day%DAY% already exists!
    echo Cannot create template - Day %DAY% has already been initialized.
    exit /b 1
)

REM 1. Create docs directory and markdown file
mkdir "docs\Day%DAY%" 2>nul
echo. > "docs\Day%DAY%\Day%DAY%.md"
echo Created: docs\Day%DAY%\Day%DAY%.md

REM 2. Create src directory structure
mkdir "src\AdventOfCode2023.Core\Day%DAY%" 2>nul

REM Create Part1.cs with template
call :CreatePart1File %DAY% "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo Created: src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs

REM Create Part2.cs with template
call :CreatePart2File %DAY% "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo Created: src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs

REM 3. Create test directory structure
mkdir "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%" 2>nul

REM Create Part1.Test.cs with template
call :CreatePart1TestFile %DAY% "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo Created: tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs

REM Create Part2.Test.cs with template
call :CreatePart2TestFile %DAY% "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo Created: tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs

REM Create empty sample input files
echo. > "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.SampleInput.txt"
echo Created: tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.SampleInput.txt

echo. > "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.PuzzleInput.txt"
echo Created: tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.PuzzleInput.txt

echo.
echo Template for Day%DAY% created %ESC%[92msuccessfully%ESC%[0m!
echo.

endlocal

exit /b 0

REM ========================================
REM Helper Subroutines
REM ========================================

:CreatePart1File
echo namespace AdventOfCode2023.Core.Day%~1; > "%~2"
echo. >> "%~2"
echo internal static partial class Day%~1 { >> "%~2"
echo. >> "%~2"
echo     internal static class Part1 { >> "%~2"
echo. >> "%~2"
echo         internal static long Solve^(string rawText^) { >> "%~2"
echo. >> "%~2"
echo             throw new NotImplementedException^(); >> "%~2"
echo         } >> "%~2"
echo. >> "%~2"
echo     } >> "%~2"
echo } >> "%~2"
goto :eof

:CreatePart2File
echo namespace AdventOfCode2023.Core.Day%~1; > "%~2"
echo. >> "%~2"
echo internal static partial class Day%~1 { >> "%~2"
echo. >> "%~2"
echo     internal static class Part2 { >> "%~2"
echo. >> "%~2"
echo         internal static long Solve^(string rawText^) { >> "%~2"
echo. >> "%~2"
echo             throw new NotImplementedException^(); >> "%~2"
echo         } >> "%~2"
echo. >> "%~2"
echo     } >> "%~2"
echo } >> "%~2"
goto :eof

:CreatePart1TestFile
echo using static AdventOfCode2023.Core.Day%~1.Day%~1; > "%~2"
echo. >> "%~2"
echo namespace AdventOfCode2023.Tests.Day%~1; >> "%~2"
echo. >> "%~2"
echo public class Day%~1Part1Test >> "%~2"
echo { >> "%~2"
echo     [Test] >> "%~2"
echo     public void Day%~1Part1_Solve_WithSampleInput_ReturnsExpectedValue^(^) >> "%~2"
echo     { >> "%~2"
echo         string rawText = TestDataHelper.LoadSampleInput^(day: %~1, part: 1^); >> "%~2"
echo         const long expected = -1; >> "%~2"
echo. >> "%~2"
echo         var result = Part1.Solve^(rawText^); >> "%~2"
echo. >> "%~2"
echo         Assert.That^(result, Is.EqualTo^(expected^)^); >> "%~2"
echo     } >> "%~2"
echo. >> "%~2"
echo     [Test] >> "%~2"
echo     public void Day%~1Part1_Solve_WithPuzzleInput_ReturnsExpectedValue^(^) >> "%~2"
echo     { >> "%~2"
echo         string rawText = TestDataHelper.LoadPuzzleInput^(day: %~1, part: 1^); >> "%~2"
echo         const long expected = -1; >> "%~2"
echo. >> "%~2"
echo         var result = Part1.Solve^(rawText^); >> "%~2"
echo. >> "%~2"
echo         Assert.That^(result, Is.EqualTo^(expected^)^); >> "%~2"
echo     } >> "%~2"
echo } >> "%~2"
goto :eof

:CreatePart2TestFile
echo using static AdventOfCode2023.Core.Day%~1.Day%~1; > "%~2"
echo. >> "%~2"
echo namespace AdventOfCode2023.Tests.Day%~1; >> "%~2"
echo. >> "%~2"
echo public class Day%~1Part2Test >> "%~2"
echo { >> "%~2"
echo     [Test] >> "%~2"
echo     public void Day%~1Part2_Solve_WithSampleInput_ReturnsExpectedValue^(^) >> "%~2"
echo     { >> "%~2"
echo         string rawText = TestDataHelper.LoadSampleInput^(day: %~1, part: 1^); >> "%~2"
echo         const long expected = -1; >> "%~2"
echo. >> "%~2"
echo         var result = Part2.Solve^(rawText^); >> "%~2"
echo. >> "%~2"
echo         Assert.That^(result, Is.EqualTo^(expected^)^); >> "%~2"
echo     } >> "%~2"
echo. >> "%~2"
echo     [Test] >> "%~2"
echo     public void Day%~1Part2_Solve_WithPuzzleInput_ReturnsExpectedValue^(^) >> "%~2"
echo     { >> "%~2"
echo         string rawText = TestDataHelper.LoadPuzzleInput^(day: %~1, part: 1^); >> "%~2"
echo         const long expected = -1; >> "%~2"
echo. >> "%~2"
echo         var result = Part2.Solve^(rawText^); >> "%~2"
echo. >> "%~2"
echo         Assert.That^(result, Is.EqualTo^(expected^)^); >> "%~2"
echo     } >> "%~2"
echo } >> "%~2"
goto :eof
