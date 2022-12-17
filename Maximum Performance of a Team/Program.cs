// See https://aka.ms/new-console-template for more information
// https://www.youtube.com/watch?v=Y7UTvogADH0
int n = 6;
var speed = new int[] { 2, 10, 3, 1, 5, 8 };
var efficiency = new int[] { 5, 4, 3, 9, 7, 2 };
int k = 3;
Solution s =new Solution();
var answer = s.MaxPerformance(n, speed, efficiency, k);
Console.WriteLine(answer);

public class Solution
{
  public int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
  {
    /*
    Step 1 - Create jagged array using efficiency and speed
    Step 2 - Sort jagged array on efficiency in desc 
    Step 3 - Create a Min heap(PQ) of speed, to maximize the perf we need to eliminate the less speed element, whenever the count of PQ is equal to k, 
    will be removing the top less speed element from PQ, thats why we need MIN PQ
    n = 6, speed = [2,10,3,1,5,8], efficiency = [5,4,3,9,7,2], k = 2
    */

    var effSpeed = new int[n][];
    for (int i = 0; i < n; i++)
    {
      effSpeed[i] = new int[2];
      effSpeed[i][0] = efficiency[i];
      effSpeed[i][1] = speed[i];
    }

    Array.Sort(effSpeed, (a, b) => { return b[0] - a[0]; });

    PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
    long totalSpeed = 0;
    long maxPerf = 0;
    for (int i = 0; i < n; i++)
    {
      int eff = effSpeed[i][0];
      int spd = effSpeed[i][1];
      if (pq.Count == k)
      {
        totalSpeed -= pq.Dequeue();
      }
      totalSpeed = totalSpeed + spd;
      pq.Enqueue(spd, spd);
      maxPerf = Math.Max(maxPerf, eff * totalSpeed);
    }

    return (int)(maxPerf % (1000000007));
  }
}
