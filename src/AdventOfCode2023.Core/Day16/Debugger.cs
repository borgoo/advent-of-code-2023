namespace AdventOfCode2023.Core.Day16;

internal static class Debugger {

    private static Dictionary<short, char> ReamDirectionHashes(Dictionary<char, short> beamDirectionHashes){
        Dictionary<short, char> result = [];
        foreach(var item in beamDirectionHashes) {
            result.Add(item.Value, item.Key);
        }
        return result;
    }

    internal static void PrintResult(string[] lines, short[,,] seen, Dictionary<char, short> beamDirectionHashes) {

        int rows = lines.Length;
        int cols = lines[0].Length;
        Dictionary<short, char> revertedBeamDirectionHashes = ReamDirectionHashes(beamDirectionHashes);
        for(int x = 0; x < rows; x++) {
            for(int y = 0; y < cols; y++) {
                char c = lines[x][y];
                if(c != '.') {
                    Console.Write(c);
                    continue;
                }
                char? result = null;
                for(short z = 0; z < seen.GetLength(2); z++) {
                    if(seen[x, y, z] != 0) {
                        if(result == null) result = revertedBeamDirectionHashes[z];
                        else if(char.IsDigit(result.Value)) result = (char)(result.Value + '0');
                        else result = '2';
                    }
                }
                result ??= c;
                Console.Write(result);

            }
            Console.WriteLine();
        }

    }
}