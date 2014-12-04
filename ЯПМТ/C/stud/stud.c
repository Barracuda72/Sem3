#define _GNU_SOURCE
#include <wchar.h>
#include <stdio.h>
#include <stdlib.h>
#include <strings.h>

#define STRCMP(x, y) strcasecmp(x, y)

#define MAX_L 40

typedef struct _stud
{
	char f[MAX_L];
	char i[MAX_L];
	char o[MAX_L];
	
	char g;
	int old;
	int kurs;
	unsigned char wc;
} stud;

typedef int (*comp_func)(stud *, stud *);

stud *a;
int n;

// Вывод массива на экран
void print(void)
{
	int i;
	for(i = 0; i < n; i++)
        	printf("%s %s %s %c %d %d\n", a[i].f, a[i].i, a[i].o,
                	a[i].g, a[i].old, a[i].kurs);
	printf("\n");
}

// Устойчивая функция сравнения
int comp_stable(stud *s1, stud *s2)
{
  int res;

  res = STRCMP(s1->f, s2->f);
  if (res != 0)
    return res;

  res = STRCMP(s1->i, s2->i);
  if (res != 0)
    return res;

  res = STRCMP(s1->o, s2->o);
  return res;
}

// Печать сортированного списка студентов
void print_sorted()
{
	printf("Before sort:\n");
	print();

  qsort(a, n, sizeof(stud), (__compar_fn_t)comp_stable);

	printf("After sort:\n");
	print();
}

// Сравниваем студентов по количеству вхождений имен
int comp_wc(stud *s1, stud *s2)
{
	if(s1->wc > s2->wc) return -1;
	if(s1->wc < s2->wc) return 1;
	return 0;
}

void count_name(stud *s)
{
	int i,count;
	if(s->wc != 0) return;	// Это имя мы уже посчитали
	for(i = count = 0; i < n; i++)
		if(STRCMP(a[i].i, s->i) == 0)
		{
			count++;
			a[i].wc = 1;
		}
	s->wc = count;
}

void count_names(void)
{
	int i, cnt;

	for(i = 0; i < n; i++)
	{
		count_name(&a[i]);
	}

  qsort(a, n, sizeof(stud), (__compar_fn_t)comp_wc);
	printf("Popular names:\n");
	for(i = 0; (i < n)&&(a[i].wc > 1); i++)
		printf("%s - %d\n", a[i].i, a[i].wc);
}

stud b[50];

// Считывание данных
int read_data()
{
	FILE *f;
	int i;
	if((f = fopen("stud-data.txt", "rb")) != 0)
	{
		fscanf(f, " %d ", &n);
    a = malloc(n*sizeof(stud));
		for(i = 0; i < n; i++)
		{
			fscanf(f, " %s %s %s %c %d %d ",
				a[i].f, a[i].i, a[i].o,
				&a[i].g, &a[i].old, &a[i].kurs);
			a[i].wc = 0;
		}
		fclose(f);
    return 0;
  } else {
    return -1;
  }
}

int main(int argc, char *argv[])
{
  if (!read_data()) 
  {
    print_sorted();

		count_names();

    free(a);
	} else {
		printf("Error open file!\n");
    return -1;
	}
}

