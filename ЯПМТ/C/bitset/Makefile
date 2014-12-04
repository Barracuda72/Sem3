all:
	bison -t -d bitset-b.c -o y.tab.c
	flex bitset.c
	gcc lex.yy.c y.tab.c -o bitset 
