%{
#include <stdio.h>
#include <string.h>
#include <time.h>
#include <stdlib.h>

#define BITSET_BAR (1024>>5)

#define alloc(x)	memset(malloc(x), '\0', x)

#if sizeof(long) == 4
  #define HIGH_SHIFT 5
  #define LOW_MASK 0x001F
#endif

void add(long element, long *set);

unsigned long *convert_to_bits(long *a)
{
	int i;
	unsigned long *result = alloc(1024);
	for(i = 0; a[i] != 88; i++)
	{
		add(a[i], result);
	}
	return result;
}

int belong(long element, long *set)
{
	if (set[element>>5]&(1<<((element&0x001F) - 1))) return 1;
	else return 0;
}

void add(long element, long *set)
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

//#define YYDEBUG 1
extern int yydebug;

extern FILE *yyin;

int yywrap()
{
	return 1;
}

int yyerror(char *s)
{
}

int main()
{
	//yydebug = 1;
	yyin = fopen("bitset-data.txt", "rb");
	yyparse();
	fclose(yyin);
}
%}

%token DIGIT OPENBR CLOSEBR COMMA ADD SUB MUL EQUAL
%%
exps: | exps expression;

expression: arg EQUAL;

arg: val op val | val;

op: ADD SUB;

val: set MUL set | set;

set: OPENBR setin CLOSEBR {};

setin: | setin digi;

digi: DIGIT {printf("%d\n", $1);};

