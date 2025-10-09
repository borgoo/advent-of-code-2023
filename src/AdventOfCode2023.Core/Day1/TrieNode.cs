namespace AdventOfCode2023.Core.Day1;


internal class TrieNode(char? character = null, int? numericalValue = 0, bool endOfWord = false) {   

    public char? Character {get; init;} = character;
    public int? NumericalValue {get; init;} = numericalValue;
    public bool EndOfWord {get; init;} = endOfWord;
    public readonly Dictionary<char, TrieNode> Children = [];
}