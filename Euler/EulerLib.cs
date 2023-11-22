namespace Euler
{
    public static class Problems
    {
        public static int MaximumPathSum(int[,] matrix){

            for (int x=matrix.GetLength(0) - 2; x >= 0; x--){
                for (int y = 0; y < matrix.GetLength(1); y++){
                    if (matrix[x,y] != 0){
                        matrix[x,y] = (matrix[x+1, y] > matrix[x+1,y+1]) 
                                    ? matrix[x+1, y] + matrix[x,y]: matrix[x+1,y+1] + matrix[x,y];
                    }
                }
            }

            return matrix[0,0];
        }
    }
}