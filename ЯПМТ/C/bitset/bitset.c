#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#if __SIZEOF_LONG__ == 4
  #define SHIFT 5
  #define MASK 0x001F
#elif __SIZEOF_LONG__ == 8
  #define SHIFT 6
  #define MASK 0x003F
#else
# error Unsupported architecture!
#endif

#define ROW(x) (x>>SHIFT)
#define COL(x) (1L<<((x&MASK) - 1))


#define BITSET_BAR (1024)
#define alloc(x) memset(malloc(x<<SHIFT), '\0', x<<SHIFT)

#define mfree(x) free(x)

//#define STRCHR(x, y) strrchr(x, y)

void set_print(unsigned long *res);

char* strncpy_m(char *dest, const char *src, size_t n)
{
	size_t i;

        for (i = 0 ; i < n-1 && src[i] != '\0' ; i++)
        	dest[i] = src[i];
        for ( ; i < n ; i++)
                dest[i] = '\0';

        return dest;
}

void add(unsigned long element, unsigned long *set);

unsigned long *convert_to_bits(unsigned long *a)
{
	int i;
	unsigned long *result = alloc(BITSET_BAR);
	for(i = 0; a[i] != 88; i++)
	{
		add(a[i], result);
	}
	return result;
}

int belong(unsigned long element, unsigned long *set)
{
	if (set[ROW(element)]&COL(element))
    return 1;
	else 
    return 0;
}

void add(unsigned long element, unsigned long *set)
{
	set[ROW(element)] = set[ROW(element)]|COL(element); 
}

void set_disjunct(unsigned long *set1, unsigned long *set2, unsigned long *res)
{
	int i;
	for (i = 0; i < BITSET_BAR; i++) res[i] = set1[i]|(set2[i]);
	mfree(set1);
	mfree(set2);
//	set_print(res);
}

void set_conjunct(unsigned long *set1, unsigned long *set2, unsigned long *res)
{
	int i;
	for (i = 0; i < BITSET_BAR; i++) res[i] = set1[i]&set2[i];
	mfree(set1);
	mfree(set2);
//	set_print(res);
}

void set_minus(unsigned long *set1, unsigned long *set2, unsigned long *res)
{
	int i;
	for (i = 0; i < BITSET_BAR; i++) res[i] = set1[i]&(~set2[i]);
	mfree(set1);
	mfree(set2);
//	set_print(res);
}

unsigned long *to_bits(char *str)
{
	char *n;
	unsigned long *res = alloc(BITSET_BAR);
	while((n = strtok(str, "[],=")) != NULL)
	{
		str = NULL;
//    printf("Adding %d\n", atoi(n));
		add(atoi(n), res);
	}
	return res;
}

unsigned long *addt(const char *str, int len);

unsigned long *mult(const char *str, int len)
{
	char *pos;
	char str2[256];
	unsigned long *res = alloc(BITSET_BAR);
	strncpy_m(str2, str, len+1);
//	printf("mult : %s, len %d\n", str2, len);
	
	if ((pos = strrchr(str2, '*')) != NULL)
	{
		//printf("Choise 4\n");
		set_conjunct(addt(str2, pos - str2), addt(pos+1, strlen(pos)-1), res);	
		return res;
	}
	else 
	{
		mfree(res);
		return to_bits(str2);
	}
}

unsigned long *addt(const char *str, int len)
{
	char *pos, *ppos, *mpos;
	char str2[256];
	unsigned long *res = alloc(BITSET_BAR);
	strncpy_m(str2, str, len+1);
//	printf("addt : %s, len %d\n", str2, len);
	/* А что последним стоит - плюс или минус? */
	ppos = strrchr(str2, '+');
	mpos = strrchr(str2, '-');
	
	if ((pos = mpos) > ppos)
	{
		//printf("Choise 2\n");
		set_minus(addt(str2, pos - str2), addt(pos+1, strlen(pos)-1), res);
		return res;
	}
	
	else if ((pos = ppos) > mpos)
	{
		//printf("Choise 3\n");
		set_disjunct(addt(str2, pos - str2), addt(pos+1, strlen(pos)-1), res);
		return res;
	}

	else
	{
		mfree(res);
		return mult(str2, len);
	}
}

void set_print(unsigned long *res)
{
	int i;
	printf("[ ");
	for(i = 0; i < BITSET_BAR; i++)
		if(belong(i, res)) printf("%d,", i);
	printf("\b ]\n");
}

int main()
{
	char test[256];
	unsigned long *res;
	FILE *f = fopen("data.txt", "rb");
	while(!feof(f))
	{
		fscanf(f, "%s\n", test);
		test[strlen(test)-1] = 0;
		res = addt(test, strlen(test));
//    puts("Final:");
		set_print(res);
		mfree(res);
	}
	fclose(f);
	return 0;
}

