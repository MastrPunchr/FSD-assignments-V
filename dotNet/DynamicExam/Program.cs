/*Given an integer array nums, return the length of the longest strictly increasing subsequence.
   
   Example 1:
   Input: nums = [10,9,2,5,3,7,101,18]
   Output: 4
   Explanation: The longest increasing subsequence is [2,5,7,101], therefore the length is 4.
   
   Example 2:
   Input: nums = [0,1,0,3,2,3]
   Output: 4
   
   Example 3:
   Input: nums = [7,7,7,7,7,7,7]
   Output: 1
   
   Constraints:
   
   1 <= nums.length <= 2500
   -104 <= nums[i] <= 104
*/

class Program
{
    public static void Main()
    {
        int a = Increasing([0,1,0,3,2,3]);
        Console.WriteLine(a);
    }

    public static int Increasing(int[] nums)
    {
        int[] dp = new int[nums.Length];
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = 1;
        }
        
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[j] >= nums[i]) continue;
                
                if (dp[j] + 1 > dp[i])
                {
                    dp[i] = dp[j] + 1;
                }
            }
        }

        return dp.Max();
    }
}