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
    echo Day%DAY% directories removed %ESC%[92m successfully!%ESC%[0m
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
type nul > "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo namespace AdventOfCode2023.Core.Day%DAY%;>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo.>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo internal static partial class Day%DAY% {>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo.>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo     internal static class Part1 {>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo.>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo         internal static long Solve^(string rawText^) {>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo.>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo             throw new NotImplementedException^();>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo         }>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo.>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo     }>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo }>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs"
echo Created: src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part1.cs

REM Create Part2.cs with template
type nul > "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo namespace AdventOfCode2023.Core.Day%DAY%;>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo.>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo internal static partial class Day%DAY% {>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo.>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo     internal static class Part2 {>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo.>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo         internal static long Solve^(string rawText^) {>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo.>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo             throw new NotImplementedException^();>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo         }>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo.>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo     }>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo }>> "src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs"
echo Created: src\AdventOfCode2023.Core\Day%DAY%\Day%DAY%.Part2.cs

REM 3. Create test directory structure
mkdir "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%" 2>nul

REM Create Part1.Test.cs with template
type nul > "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo using static AdventOfCode2023.Core.Day%DAY%.Day%DAY%;>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo.>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo namespace AdventOfCode2023.Tests.Day%DAY%;>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo.>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo public class Day%DAY%Part1Test>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo {>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo     [Test]>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo     public void Day%DAY%Part1_Solve_WithSampleInput_ReturnsExpectedValue^(^)>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo     {>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo         string rawText = TestDataHelper.LoadSampleInput^(day: %DAY%, part: 1^);>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo         const long expected = -1;>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo.>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo         var result = Part1.Solve^(rawText^);>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo.>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo         Assert.That^(result, Is.EqualTo^(expected^)^);>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo     }>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo.>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo     [Test]>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo     public void Day%DAY%Part1_Solve_WithPuzzleInput_ReturnsExpectedValue^(^)>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo     {>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo         string rawText = TestDataHelper.LoadPuzzleInput^(day: %DAY%, part: 1^);>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo         const long expected = -1;>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo.>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo         var result = Part1.Solve^(rawText^);>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo.>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo         Assert.That^(result, Is.EqualTo^(expected^)^);>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo     }>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo }>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs"
echo Created: tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part1.Test.cs

REM Create Part2.Test.cs with template
type nul > "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo using static AdventOfCode2023.Core.Day%DAY%.Day%DAY%;>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo.>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo namespace AdventOfCode2023.Tests.Day%DAY%;>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo.>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo public class Day%DAY%Part2Test>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo {>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo     [Test]>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo     public void Day%DAY%Part2_Solve_WithSampleInput_ReturnsExpectedValue^(^)>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo     {>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo         string rawText = TestDataHelper.LoadSampleInput^(day: %DAY%, part: 1^);>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo         const long expected = -1;>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo.>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo         var result = Part2.Solve^(rawText^);>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo.>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo         Assert.That^(result, Is.EqualTo^(expected^)^);>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo     }>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo.>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo     [Test]>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo     public void Day%DAY%Part2_Solve_WithPuzzleInput_ReturnsExpectedValue^(^)>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo     {>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo         string rawText = TestDataHelper.LoadPuzzleInput^(day: %DAY%, part: 1^);>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo         const long expected = -1;>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo.>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo         var result = Part2.Solve^(rawText^);>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo.>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo         Assert.That^(result, Is.EqualTo^(expected^)^);>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo     }>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
echo }>> "tests\UnitTests\AdventOfCode2023.Tests\Day%DAY%\Day%DAY%.Part2.Test.cs"
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

