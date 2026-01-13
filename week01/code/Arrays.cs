public static class Arrays
{

   public static double[] MultiplesOf(double number, int length)
   {
    // Step 1: Create an array of type double with the size specified by 'length'.
    // This array will store the multiples of the given number.
    double[] result = new double[length];

      // Step 2: Use a loop to iterate through each index of the array.
      for (int i = 0; i < length; i++)
      {
          // Step 3: Calculate each multiple by multiplying 'number'
          // by (i + 1), since the first multiple should be number * 1.
          result[i] = number * (i + 1);
      }

      // Step 4: Return the completed array containing all multiples.
      return result;
  }


    public static void RotateListRight(List<int> data, int amount)
    {
      // Step 1: Determine the total number of elements in the list.
      // This will be used to calculate which elements need to be moved.
      int count = data.Count;

      // Step 2: Identify the portion of the list that will be rotated to the front.
      // These are the last 'amount' elements in the list.
      List<int> endSlice = data.GetRange(count - amount, amount);

      // Step 3: Remove the last 'amount' elements from the original list.
      // This shortens the list and prepares it for insertion.
      data.RemoveRange(count - amount, amount);

      // Step 4: Insert the saved elements at the beginning of the list.
      // This completes the right rotation.
      data.InsertRange(0, endSlice);
    }
}

