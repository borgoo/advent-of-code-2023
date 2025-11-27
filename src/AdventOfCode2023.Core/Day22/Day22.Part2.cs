namespace AdventOfCode2023.Core.Day22; 
 
internal static partial class Day22 {


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

    internal class Part2 : PartShared {

        internal new class Space3D : PartShared.Space3D
        {
            private readonly int[,,] _backupSpace;
            public Space3D(int N, int M, int W, BrickLine[] brickLines) : base(N, M, W, brickLines)
            {
                _backupSpace = new int[Space.GetLength(0), Space.GetLength(1), Space.GetLength(2)];
                Buffer.BlockCopy(Space, 0, _backupSpace, 0, Space.Length * sizeof(int));
            }

            internal int DestroyBricksWithChainReaction(){
                return _brickLinesDictionary.Keys.Sum(DestroyBrickWithChainReaction);
            }

            internal int DestroyBrickWithChainReaction(int brickKey) {

                int result = 0;
                BrickLine curr = _brickLinesDictionary[brickKey];
                Unset(curr);
                for(int i = curr.MaxZ + 1; i <= W; i++) {
                    foreach(int aboveLevelBrickKey in _bricksByZ[i]) {
                        BrickLine aboveLevelBrick = _brickLinesDictionary[aboveLevelBrickKey];
                        if(!WillFall(aboveLevelBrick)) continue;
                        result++;
                        Unset(aboveLevelBrick);
                    }
                }

                Buffer.BlockCopy(_backupSpace, 0, Space, 0, Space.Length * sizeof(int));

                return result;



            }
            
          
        }



        internal static long CountHowManyBreaksCanBeDisintegratedWithChainReaction(string rawText) { 
    
            var (maxX, maxY, maxZ, brickLines) = GetSpace3DDataFromInput(rawText);
            Space3D space = new(maxX, maxY, maxZ, brickLines);
            // Debugger.GenerateThreeJSHTMLFile(space);

            int result = space.DestroyBricksWithChainReaction();
            return result;
        } 
 
    } 
} 
