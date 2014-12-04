#include <stdio.h>
#include <time.h>
#include <stdlib.h>
#include <string.h>

#define BITSET_BAR (1024>>5)

#define alloc(x)	memset(malloc(x), '\0', x)

void add(unsigned long element, unsigned long *set);

unsigned long *convert_to_bits(unsigned long *a)
{
	int i;
	unsigned long *result = alloc(1024);
	for(i = 0; a[i] != 88; i++)
	{
		add(a[i], result);
	}
	return result;
}

int belong(unsigned long element, unsigned long *set)
{
	if (set[element>>5]&(1<<((element&0x001F) - 1))) return 1;
	else return 0;
}

void add(unsigned long element, unsigned long *set)
{
	set[element>>5] = set[element>>5]|(1<<((element&0x001F) - 1)); 
}

void set_disjunct(unsigned long *set1, unsigned long *set2, unsigned long *res)
{
	int i;
	for (i = 0; i < BITSET_BAR; i++) res[i] = set1[i]|(set2[i]);
}

void set_conjunct(unsigned long *set1, unsigned long *set2, unsigned long *res)
{
	int i;
	for 
	(i = 0; i < BITSET_BAR; i++) res[i] = set1[i]&set2[i];
}

void set_intersect(unsigned long *set1, unsigned long *set2, unsigned long *res)
{
	int i;
	for (i = 0; i < BITSET_BAR; i++) res[i] = set1[i]&set2[i];
}

void set_minus(unsigned long *set1, unsigned long *set2, unsigned long *res)
{
	int i;
	for (i = 0; i < BITSET_BAR; i++) res[i] = set1[i]&(~set2[i]);
}

unsigned long *get_bits(FILE *f)
{
	int c;
	unsigned long d[100];
	int i = 0;
	while ((c = fgetc(f)) != ']')
	{
		if((c >= '0')&&(c <= '9'))
		{
			d[i] = c - '0';
			i++;
		}
		if(feof(f)) exit(0);
	}
	d[i] = 88;
	return convert_to_bits(d);
}

int main()
{
	FILE *f = fopen("bitset-data.txt", "rb");
	unsigned long *p;
	unsigned long *q;
	unsigned long *res = alloc(BITSET_BAR*1024);
	unsigned long c,i;
	while (!feof(f))
	{
		c = fgetc(f);

		if(c == '=') 
		{
			for(i = 0; i < BITSET_BAR; i++) if(belong(i, p)) printf("%d ", i);
			printf("\n");
			memset(p, '\0', BITSET_BAR);
			memset(q, '\0', BITSET_BAR);
			memset(res, '\0', BITSET_BAR);
			continue;
			//break;
		}
		q = get_bits(f);

		switch(c)
		{
			case '[':
			case '\n':
				//free(p);
				p = q;
				continue;
			case '*':
				set_conjunct(p, q, res);
				break;
			case '+':
				set_disjunct(p, q, res);
				break;
			case '-':
				set_minus(p, q, res);
				break;
			default:
				continue;
		}

			free(p);
			free(q);
			p = res;
			res = alloc(BITSET_BAR*1024);
//__exit:		
//		asm("nop");
	}
	fclose(f);
	/*int i,j;
	unsigned char a[100];
	unsigned long set;
	int n;
	unsigned long res[BITSET_BAR];

//	scanf("%s", &a);
	FILE *f = fopen("bitset-data.txt", "rb");
	fscanf(f, " %d ", &n);
	for(i = 0; i < n; i++)	
	{
		fscanf(f, "%s", a);
		set = calculate(a, &res);
		printf("[");
		for(j = 1; j < 10; j++)
			if(belong(j, set)) printf("%d,", j);
		printf("]\n");
	}
	fclose(f);*/

/*	unsigned long *set1 = alloc(1024);
	unsigned long *set2 = alloc(1024);
	unsigned long *res = alloc(1024);
	int i;

	for(i = 0; i < 256; i++) set1[i] = set2[i] = 0;
*/	/*	Первое множество - 99
	0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0
	0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0
	0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0
	0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 1 0 0 
	*/
//	set1[3] = 4;

	/*	Второе множество - 113
	0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0
	0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0
	0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0
	0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 1 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0
	*/
/*	set2[3] = 65536;

	printf("99 belong to set1? %d\n", belong(99, set1));
	printf("113 belong to set1? %d\n", belong(113, set1));
	printf("99 belong to set2? %d\n", belong(99, set2));
	printf("113 belong to set2? %d\n", belong(113, set2));

	set_conjunct(set1, set2, res);
	printf("99 belong to res? %d\n", belong(99, res));
	printf("113 belong to res? %d\n", belong(113, res));

	set_disjunct(set1, set2, res);
	printf("99 belong to res? %d\n", belong(99, res));
	printf("113 belong to res? %d\n", belong(113, res));

	set_intersect(set1, set2, res);
	printf("99 belong to res? %d\n", belong(99, res));
	printf("113 belong to res? %d\n", belong(113, res));

	free(set1);
	free(set2);
	free(res);
*/	/*
		0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 0 | 0 0 0 0 0 0 0 1 | 1 1 1 1 1 0 1 1
	*/
	
/*	long a[10] = {4, 5, 8, 9, 1, 2, 4, 6, 7, 88};
	res = convert_to_bits(a);
	printf("%x\n", res[0]);
	for ( i = 0; i < 10; i++) 
		if(belong(i, res)) 
			printf("%d ",i);
	printf("\n");
	free(res);*/
	return 0;
}

