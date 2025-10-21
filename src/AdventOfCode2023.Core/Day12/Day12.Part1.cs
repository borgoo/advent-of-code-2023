namespace AdventOfCode2023.Core.Day12;

internal static partial class Day12 {

    internal abstract class PartShared {

        protected const char _unknownCharacter = '?';
        protected const char _damagedCharacter = '#';
        protected const char _okCharacter = '.';

        internal abstract long GetSumOfAllPossibleArrangements(string text);

        
        protected static void Force1WhereICanHaveOkPositionsForTheNoGroupsCase(long[,] dp, string pattern, int patternLength) {
            bool foundAGroup = false;
            for(int i = 1; i <= patternLength; i++) {
                
                if(foundAGroup || pattern[i-1] == _damagedCharacter) {
                    foundAGroup = true;
                    dp[i,0] = 0;
                    continue;
                }

                dp[i,0] = 1;
                                               
            }
        }

        protected static long GetAllPossibleArrangements(string pattern, int[] groupsData) {
            
            int patternLength = pattern.Length;
            int groupsCount = groupsData.Length;
            
            long[,] dp = new long[patternLength + 1, groupsCount + 1]; //dp[i][j] => satisfy first j groups with first i characters
            dp[0,0] = 1;
            Force1WhereICanHaveOkPositionsForTheNoGroupsCase(dp, pattern, patternLength);


            for(int i = 1; i <= patternLength; i++) {


                for(int j = 1; j <= groupsCount; j++) {

                    char c = pattern[i-1];
                    int wantedGroupLength = groupsData[j-1];

                    bool isNotAnHardDamagedSpring = c != _damagedCharacter;
                    if(isNotAnHardDamagedSpring) dp[i,j] = dp[i-1,j];

                    bool shouldIRespectTheGroupLengthRestriction = i >= wantedGroupLength;
                    if(!shouldIRespectTheGroupLengthRestriction) continue;

                   
                    bool onlyOneGroupCanBePlaced = true;
                    for(int toBeChecked = wantedGroupLength; toBeChecked > 0 ; toBeChecked--) {
                        int pos = i - toBeChecked;
                        if(pattern[pos] == _okCharacter) {
                            onlyOneGroupCanBePlaced = false;
                            break;
                        }
                    }

                    if(!onlyOneGroupCanBePlaced) continue;

                    bool theGroupStartsExactlyAtTheBeginningOfThePattern = i == wantedGroupLength;
                    if(theGroupStartsExactlyAtTheBeginningOfThePattern){
                        bool weAreCheckingTheFirstGroup = j == 1;
                        if(weAreCheckingTheFirstGroup) dp[i,j]++;
                        continue;
                    }

                    int lastPosBeforeTheGroup = i - wantedGroupLength - 1;
                    char lastCharacterBeforeTheGroup = pattern[lastPosBeforeTheGroup];
                    bool lastCharacterBeforeTheGroupIsNotHardDamaged = lastCharacterBeforeTheGroup != _damagedCharacter;
                    if(lastCharacterBeforeTheGroupIsNotHardDamaged) dp[i,j]+=dp[lastPosBeforeTheGroup, j - 1];

                }
            }

            return dp[patternLength, groupsCount];

        }
        
    }

    internal class Part1 : PartShared {      
      
        internal override long GetSumOfAllPossibleArrangements(string text) {
            string[] lines = text.Split(Environment.NewLine);
            long sum = 0;
            foreach(string line in lines) {
                if(!line.Contains(_unknownCharacter)) throw new InvalidOperationException($"Line does not contain unknown character {line}");
                string[] data = line.Split(' ');
                string completeLine = data[0];
                int[] groupsData = [.. data[1].Split(',').Select(int.Parse)];
                sum += GetAllPossibleArrangements(completeLine, groupsData);
            }
            return sum;
        }
    }
}
