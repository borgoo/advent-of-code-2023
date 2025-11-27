namespace AdventOfCode2023.Core.Day22; 
 
internal static partial class Day22 { 

    internal abstract class PartShared {

        
        protected static class Coordinates {
            public readonly static int X = 0;
            public readonly static int Y = 1;
            public readonly static int Z = 2;
        }

        internal readonly struct BrickLine
        {
            public readonly int Key { get; init; }
            public readonly int[] From { get; init; }
            public readonly int[] To { get; init; }

            public readonly int MinZ { get; init; }
            public readonly int MaxZ { get; init; }
            public readonly bool IsSinglePoint { get; init; }

            public readonly (int dx, int dy, int dz) Direction { get; init; }
        
            public BrickLine(int[] from, int[] to, int key)
            {
                Key = key;
                From = from;
                To = to;
                MinZ = Math.Min(From[Coordinates.Z], To[Coordinates.Z]);
                MaxZ = Math.Max(From[Coordinates.Z], To[Coordinates.Z]);
                IsSinglePoint = From[Coordinates.X] == To[Coordinates.X] && From[Coordinates.Y] == To[Coordinates.Y] && From[Coordinates.Z] == To[Coordinates.Z];
                Direction = (To[Coordinates.X] - From[Coordinates.X], To[Coordinates.Y] - From[Coordinates.Y], To[Coordinates.Z] - From[Coordinates.Z]);
            
            }


        }

        internal class Space3D {
            internal int N {get; init;}
            internal int M {get; init;}
            internal int W {get; init;}
            internal int[,,] Space {get; init;}

            internal int MinLimitZ {get; init;}

            protected const int _empty = 0;

            protected readonly Dictionary<int, BrickLine> _brickLinesDictionary = [];
            protected readonly Dictionary<int, HashSet<int>> _bricksByZ;
            

            internal Space3D(int N, int M, int W, BrickLine[] brickLines) {
                this.N = N;
                this.M = M;
                this.W = W;
                Space = new int[N+1, M+1, W+1];
                MinLimitZ = brickLines.Min(b => b.MinZ);


                LoadAllTheBricksIntoSpaceAndMakeThemFallDown(brickLines);
                _bricksByZ = BuildBricksByZ();
            }

            private static int CompareBrickLines(BrickLine a, BrickLine b)
            {
                if (a.To[Coordinates.Z] == b.To[Coordinates.Z]) return a.From[Coordinates.Z].CompareTo(b.From[Coordinates.Z]);
                return a.To[Coordinates.Z].CompareTo(b.To[Coordinates.Z]);
            }

            private void LoadAllTheBricksIntoSpaceAndMakeThemFallDown(BrickLine[] brickLines) {
                
                int n = brickLines.Length;
                Array.Sort(brickLines, CompareBrickLines);

                for (int j = 0; j < n; j++)
                {
                    BrickLine curr = brickLines[j];
                    if (AlreadyBusy(curr)) throw new Exception("Space already busy");

                    while (curr.MinZ > MinLimitZ) {
                        int[] from = [.. curr.From];
                        from[Coordinates.Z]--;
                        int[] to = [.. curr.To];
                        to[Coordinates.Z]--;
                        BrickLine next = new( from, to, curr.Key );
                        if (AlreadyBusy(next)) break;
                        Unset(curr);
                        Set(next);
                        curr = next;
                    }
                    Set(curr);

                    _brickLinesDictionary.Add(curr.Key, curr);

                }
            }

            private Dictionary<int, HashSet<int>> BuildBricksByZ(){
                Dictionary<int, HashSet<int>> bricksByZ = Enumerable.Range(MinLimitZ, W).ToDictionary(z => z, z => new HashSet<int>());
                
                foreach(var (key, brick) in _brickLinesDictionary) {
                    bricksByZ[brick.MinZ].Add(key);
                }

                return bricksByZ;
            }
            internal void Unset(BrickLine brickLine) {
                Set(brickLine, _empty);
            }

            internal void Set(BrickLine brickLine) {
                Set(brickLine, brickLine.Key);
            }

            private void Set(BrickLine brickLine, int key) {

                if(brickLine.IsSinglePoint) {
                    Space[brickLine.From[Coordinates.X], brickLine.From[Coordinates.Y], brickLine.From[Coordinates.Z]] = key;
                    return;
                }

                for(int i = 0; i <= brickLine.Direction.dx; i++) Space[brickLine.From[Coordinates.X] + i, brickLine.From[Coordinates.Y], brickLine.From[Coordinates.Z]] = key;
                for(int i = 0; i <= brickLine.Direction.dy; i++) Space[brickLine.From[Coordinates.X] , brickLine.From[Coordinates.Y] + i, brickLine.From[Coordinates.Z]] = key;
                for(int i = 0; i <= brickLine.Direction.dz; i++) Space[brickLine.From[Coordinates.X] , brickLine.From[Coordinates.Y], brickLine.From[Coordinates.Z] + i] = key;                
            }

            internal bool AlreadyBusy(BrickLine brickLine) {

                if (brickLine.IsSinglePoint)
                {
                    int spaceVal = Space[brickLine.From[Coordinates.X], brickLine.From[Coordinates.Y], brickLine.From[Coordinates.Z]];
                    return spaceVal != _empty && spaceVal != brickLine.Key;
                }

                for (int i = 0; i <= brickLine.Direction.dx; i++)
                {
                    int spaceVal = Space[brickLine.From[Coordinates.X] + i, brickLine.From[Coordinates.Y], brickLine.From[Coordinates.Z]];
                    if (spaceVal != _empty && spaceVal != brickLine.Key) return true;   

                }
                for (int i = 0; i <= brickLine.Direction.dy; i++)
                {
                    int spaceVal = Space[brickLine.From[Coordinates.X], brickLine.From[Coordinates.Y] + i, brickLine.From[Coordinates.Z]];
                    if (spaceVal != _empty && spaceVal != brickLine.Key) return true;

                }
                for (int i = 0; i <= brickLine.Direction.dz; i++)
                {
                    int spaceVal = Space[brickLine.From[Coordinates.X], brickLine.From[Coordinates.Y], brickLine.From[Coordinates.Z] + i];
                    if (spaceVal != _empty && spaceVal != brickLine.Key) return true;

                }
                return false;

                
            }

            protected bool WillFall(BrickLine brickLine) {

                if (brickLine.MinZ <= MinLimitZ) return false;

                int[] from = [.. brickLine.From];
                from[Coordinates.Z]--;
                int[] to = [.. brickLine.To];
                to[Coordinates.Z]--;
                BrickLine next = new(from, to, brickLine.Key);

                return !AlreadyBusy(next);
            }

            internal int DestroyBricksSafely() {

                int count = 0;
                foreach(var (key, brick) in _brickLinesDictionary) {

                    Unset(brick);
                    bool atLeastOneAboveWillFall = _bricksByZ[brick.MaxZ + 1].Any(key => WillFall(_brickLinesDictionary[key]));
                    if(!atLeastOneAboveWillFall) count++;
                    Set(brick);
                }

                return count;
            }

           
        }

        protected static (int maxX, int maxY, int maxZ, BrickLine[] brickLines) GetSpace3DDataFromInput(string rawText) {

            string[] lines = rawText.Split(Environment.NewLine);
            int n = lines.Length;
            BrickLine[] brickLines = new BrickLine[n];
            int maxX = 0, maxY = 0, maxZ = 0, i = 0;
            foreach (string line in lines) {
                string[] parts = line.Split('~');
                int[] from = [.. parts[0].Split(',').Select(int.Parse)];
                int[] to = [.. parts[1].Split(',').Select(int.Parse)];
                maxX = Math.Max(maxX, Math.Max(from[Coordinates.X], to[Coordinates.X]));
                maxY = Math.Max(maxY, Math.Max(from[Coordinates.Y], to[Coordinates.Y]));
                maxZ = Math.Max(maxZ, Math.Max(from[Coordinates.Z], to[Coordinates.Z]));
                brickLines[i] = new BrickLine(from, to, i+1);
                i++;
            }
            return (maxX, maxY, maxZ, brickLines);
        }

    

    }

    /***
     * 
     * ^ Z
     * |
     * |
     * |----> Y
     * |
     * v X
     * 
     * */

    internal class Part1 : PartShared { 

        internal static int CountHowManyBreaksCanBeSafetelyDisintegrated(string rawText)
        {
            var (maxX, maxY, maxZ, brickLines) = GetSpace3DDataFromInput(rawText);
            Space3D space = new(maxX, maxY, maxZ, brickLines);
            // Debugger.GenerateThreeJSHTMLFile(space);

            int result = space.DestroyBricksSafely();
            return result;

        }

    } 
}

