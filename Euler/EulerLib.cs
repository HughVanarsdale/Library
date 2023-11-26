namespace EulerLib
{
    public static class Problems
    {

        /******************************************************************************************
        * In triangle of numbers find max path from top to bottom
        * Actually, read data from bottom to top.
        */
        public static int MaximumPathSum(int[,] matrix){

            // for each row starting on 2nd from last line
            for (int x=matrix.GetLength(0) - 2; x >= 0; x--){
                // for each col from 0 to length
                for (int y = 0; y < matrix.GetLength(1); y++){
                    // add cell to either the one below or the one below and to the right.
                    if (matrix[x,y] != 0){
                        matrix[x,y] = (matrix[x+1, y] > matrix[x+1,y+1]) 
                                    ? matrix[x+1, y] + matrix[x,y]: matrix[x+1,y+1] + matrix[x,y];
                    }
                }
            }
            // max path will be in 0,0 cell
            return matrix[0,0];
        }
    }
}