namespace AdventOfCode2023.Core.Day15;


internal class TrieNode(char? character = null, int hash = 0) {   

    public char? Character {get; init;} = character;
    public int Hash {get; init;} = hash;
    public readonly Dictionary<char, TrieNode> Children = [];
}