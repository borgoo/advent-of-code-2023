namespace AdventOfCode2023.Core.Day15;

internal static partial class Day15 {

    internal abstract class PartShared {

        protected const char _separator = ',';
        protected static readonly TrieNode _root = new();

        protected static int GetHashValue(string text) {

            TrieNode curr = _root;
            for(int i = 0; i < text.Length; i++) {
                char c = text[i];
                if(!curr.Children.ContainsKey(c)) {
                    int hash = curr.Hash;
                    hash += (int)c;
                    hash *= 17;
                    hash %= 256;                    
                    curr.Children.Add(c, new TrieNode(c, hash));
                }
                curr = curr.Children[c];
            }

            return curr.Hash;
        
        }



    }

    internal class Part1 : PartShared {     

        internal static int GetTotalSum(string rawText) {
            var cmds = rawText.Split(_separator, StringSplitOptions.RemoveEmptyEntries);
            return cmds.Sum(GetHashValue);
        }
    }
}