#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>

#define N 1000000
#define CALL_DELAY 2750	//Задержка на не относящиеся к сортировке действия

static int intcmp(const void *a1, const void *a2)
{
	int i1 = *(int *)a1;
	int i2 = *(int *)a2;
	if(i1 < i2) return -1;
	if(i1 == i2) return 0;
	return 1;
}

void print(int *a)
{
	int i;
	for(i = 0; i < N; i++)
    printf("%d ", a[i]);
	printf("\n");
}

void mysort(int *a, int l, int r)
{
	int i,j,x,y;
	i = l;
	j = r;
	x = a[rand()%(r - l)+l];	//Выбираем средний элемент
	do
	{	
		//Две границы идут навстречу друг другу
		while (a[i] < x) i++;
		while (a[j] > x) j--;
		if(i<=j)
		{
			if(intcmp(&a[i], &a[j]))
			{
				y = a[i];
				a[i] = a[j];
				a[j] = y;
			}
			i++;
			j--;
		}
	} while(i < j);
	if(l < j) mysort(a, l, j);
	if(i < r) mysort(a, i, r);
}

int main()
{
	srand(time(NULL));
	int a[N],b[N];
	int start1, start2, end1, end2, i;
	struct timespec tmp;

	for (i = 0; i < N; i++)
		a[i]=b[i]=rand()%10+1;

	printf("Array before: ");
	//print(a);

	clock_gettime(CLOCK_PROCESS_CPUTIME_ID, &tmp);
	 start1 = tmp.tv_nsec;
   qsort(a, N, sizeof(a[0]), intcmp);
  clock_gettime(CLOCK_PROCESS_CPUTIME_ID, &tmp);
	 start2 = end1 = tmp.tv_nsec;
	 mysort(b,0,N-1);
	clock_gettime(CLOCK_PROCESS_CPUTIME_ID, &tmp);
	 end2 = tmp.tv_nsec;

	printf("Array after qsort: ");
	//print(a);
	printf("Spent %d nanoseconds\n", end1 - start1/* - CALL_DELAY*/);

	printf("Array after mysort: ");
	//print(b);
	printf("Spent %d nanoseconds\n", end2 - start2/* - CALL_DELAY*/);
	return 0;
}

