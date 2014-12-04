#include <stdio.h>
#include <stdlib.h>
#include <limits.h>

#define MIN 0
#define MAX 1
#define SZ 10

int row[SZ][2] = {0};
int col[SZ][2] = {0};

int sedl(int a[SZ][SZ], int x, int y)
{
  if ((a[x][y] == row[x][MIN]) && 
      (a[x][y] == col[y][MAX]))
      return 1;
  if ((a[x][y] == row[x][MAX]) && 
      (a[x][y] == col[y][MIN]))
      return 1;
  return 0;
}

int main(int argc, char *argv[])
{
  FILE *f = fopen("data.txt", "r");
  int m,n,i,j;
  int a[SZ][SZ];
  
  fscanf(f, "%d %d\n", &m, &n);

  for (i = 0; i < SZ; i++)
  {
    row[i][MIN] = INT_MAX;
    row[i][MAX] = INT_MIN;
    col[i][MIN] = INT_MAX;
    col[i][MAX] = INT_MIN;
  }

  for (i = 0; i < m; i++)
  {
    for (j = 0; j < n; j++)
    {
      fscanf(f, "%d", &a[i][j]);

      if (a[i][j] < row[i][MIN])
        row[i][MIN] = a[i][j];

      if (a[i][j] > row[i][MAX])
        row[i][MAX] = a[i][j];

      if (a[i][j] < col[j][MIN])
        col[j][MIN] = a[i][j];

      if (a[i][j] > col[j][MAX])
        col[j][MAX] = a[i][j];
    }
  }
  fclose(f);

  f = fopen("out.txt", "w");
  for (i = 0; i < m; i++)
  {
    for (j = 0; j < n; j++)
    {
      if (sedl(a, i, j))
      {
        fprintf(f, "Найден седловой элемент: %d на позиции %d:%d\n", a[i][j], i, j);
      }
    }
  }
  close(f);
}

