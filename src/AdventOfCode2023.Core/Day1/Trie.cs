namespace AdventOfCode2023.Core.Day1;

internal class Trie {

    private static readonly string[] _spelledNumbers = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
       
    public readonly TrieNode Root = new();

    public Trie() {
        int index = 1;
        foreach(string word in _spelledNumbers) {
            AddWord(word, index++);
        }
    }

    private void AddWord(string word, int payload) {

        TrieNode curr = Root;

        for(int i = 0; i < word.Length; i++) {
            char c = word[i];
            bool isEndOfWord = i == word.Length - 1;
            if(!curr.Children.ContainsKey(c)) {
                int? numericalValue = isEndOfWord ? payload : null;
                curr.Children.Add(c, new TrieNode(c, numericalValue, isEndOfWord));
            }
            curr = curr.Children[c];
        }
    }
}