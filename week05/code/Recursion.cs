using System.Collections;

public static class Recursion
{
    // Problem 1
    public static int SumSquaresRecursive(int n)
{
    if (n <= 0)
        return 0;

    return n * n + SumSquaresRecursive(n - 1);
}


    // Problem 2
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
{
    if (word.Length == size)
    {
        results.Add(word);
        return;
    }

    for (int i = 0; i < letters.Length; i++)
    {
        char c = letters[i];

        // Use the letter only if it is not already in the word.
        if (!word.Contains(c))
        {
            PermutationsChoose(results, letters, size, word + c);
        }
    }
}


    // Problem 3
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
{
    // Initializes the dictionary if it's the first call.
    if (remember == null)
        remember = new Dictionary<int, decimal>();

    // Base Cases
    if (s == 0)
        return 0;
    if (s == 1)
        return 1;
    if (s == 2)
        return 2;
    if (s == 3)
        return 4;

    // If we've already calculated it before, it returns from the cache.
    if (remember.ContainsKey(s))
        return remember[s];

    // Calculate recursively
    decimal ways = CountWaysToClimb(s - 1, remember)
                 + CountWaysToClimb(s - 2, remember)
                 + CountWaysToClimb(s - 3, remember);

    // Keep it in the dictionary.
    remember[s] = ways;

    return ways;
}


    // Problem 4
    public static void WildcardBinary(string pattern, List<string> results)
{
    int index = pattern.IndexOf('*');

    
    if (index == -1)
    {
        results.Add(pattern);
        return;
    }

    
    WildcardBinary(pattern[..index] + "0" + pattern[(index + 1)..], results);

    // Replace the * with 1
    WildcardBinary(pattern[..index] + "1" + pattern[(index + 1)..], results);
}


    // Problem 5
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            var moves = new (int dx, int dy)[]
            {
                (1, 0),
                (-1, 0),
                (0, 1),
                (0, -1)
            };

            foreach (var (dx, dy) in moves)
            {
                int nx = x + dx;
                int ny = y + dy;

                if (maze.IsValidMove(currPath, nx, ny))
                {
                    SolveMaze(results, maze, nx, ny, currPath);
                }
            }
        }

        currPath.RemoveAt(currPath.Count - 1);
    }
}
