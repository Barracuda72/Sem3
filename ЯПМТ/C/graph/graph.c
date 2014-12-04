#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Предописания
struct _arc;
struct _node;

// Узел
typedef struct _node
{
  int id,inf;
  struct _node *next;
  struct _arc *arclist;
} node;

// Дуга
typedef struct _arc
{
  int inf;
  struct _arc *next;
  struct _node *adj;
} arc;

// Вспомогательная структура - очередь
typedef struct _queue
{
  node *d;
  struct _queue *next;
} queue;

// Функции работы с очередью
void free_queue(queue **q)
{
  if (*q != NULL)
  {
    free_queue(&((*q)->next));
    free(*q);
    *q = NULL;
  }
}

// Добавление элемента в конец очереди
void add_to_queue(queue **q, node *d)
{
  if (*q != NULL)
    add_to_queue(&((*q)->next), d);
  else {
    *q = malloc(sizeof(queue));
    (*q)->next = NULL;
    (*q)->d = d;
  }
}

// Функции для работы с графами

// Добавление изолированного узла в граф
void add_node(node **graph, int n, int x)
{
  if (*graph == NULL)
  {
    *graph = malloc(sizeof(node));
    (*graph)->id = n;
    (*graph)->inf = x;
    (*graph)->next = NULL;
    (*graph)->arclist = NULL;
  } else {
    add_node(&((*graph)->next), n, x);
  }
}

// Создание дуги
void new_arc(arc **a, node *n, int y)
{
  *a = malloc(sizeof(arc));
  (*a)->adj = n;
  (*a)->inf = y;
  (*a)->next = NULL;
}

// Добавление дуги из u в v
void add_arc(node *u, node *v, int y)
{
  arc *a;
  if ((u != NULL)&&(v != NULL))
  {
    if (u->arclist == NULL)
    {
      new_arc(&(u->arclist), v, y);
    } else {
      a = u->arclist;
      while (a->next != NULL)
        a = a->next;
      new_arc(&(a->next), v, y);
    }
  } else {
    printf("Один из указателей u (%p) или v (%p) равен NULL\n", u, v);
  }
}

// Поиск узла (линейный)
node *find_node(node *g, int k)
{
  while ((g != NULL) && (g->id != k))
    g = g->next;

  return g;
}

// Удаление узла
void delete_node(node **g)
{
  arc *a,*b;
  a = (*g)->arclist;
  while (a != NULL) {
    b = a->next;
    free(a);
    a = b;
  }
  free(*g);
  *g = NULL;
}

// Освобождение памяти, занимаемой графом
void free_graph(node **g)
{
  if (*g != NULL)
  {
    free_graph(&((*g)->next));
    delete_node(g);
  }
}

// Вывод графа на экран
void dump_graph(node *g)
{
  int n;
  node *q;
  arc *a;

  q = g;
  for (n = 0; q != NULL; n++)
    q = q->next;

  printf("В графе %d вершин\n", n);

  for (q = g; q != NULL; q = q->next)
  {
    printf("Вершина %d: ", q->id);
    for (a = q->arclist; a != NULL; a = a->next)
    {
      printf("%d ",a->inf);
    }
    puts("");
  }
}

// Пропуск строки в файле
void skip_line(FILE *f)
{
  while (fgetc(f) != '\n');
}

// Считывание графа из файла
void read_graph(node **g, char *fname)
{
  FILE *f;
  int i, j, n, m, k, z;
  node *u, *v;

  *g = NULL;

  f = fopen(fname, "r");
  fscanf(f, "%d", &n);
  //printf("Предполагаем %d вершин\n", n);
  skip_line(f);

  for (i = 0; i < n; i++)
  {
    add_node(g, i+1, i+1);
  }

  for (i = 0; i < n; i++)
  {
    skip_line(f);
    fscanf(f, "%d", &m);
    //printf("У вершины %d дуг ровно %d\n", i+1, m);
    u = find_node(*g, i+1);
    for (j = 0; j < m; j++)
    {
      fscanf(f, "%d %d", &k, &z);
      v = find_node(*g, k);
      add_arc(u, v, z);
    }
    skip_line(f);
  }
  fclose(f);
}

// Поиск в глубину
node *DFS(node *g, int *a, int inf)
{
  node *res;
  arc *q;

  res = NULL;

  if (g != NULL)
  {
    // Если текущая вершина не посещена
    if (!a[g->id])
    {
      printf("%d ", g->id);
      // Если нашли нужную вершину - вернем ее
      if (g->inf == inf)
        return g;

      a[g->id] = 1;
      // Иначе пройдемся в глубину по всем смежным ей вершинам
      q = g->arclist;
      while ((q != NULL) && (res == NULL))
      {
        res = DFS(q->adj, a, inf);
        q = q->next;
      }
    }
  }
  return res;
}

// Поиск в ширину
node *BFS(node *g, int *a, int inf)
{
  queue *q,*p;
  node *res;
  arc *t;

  res = NULL;
  q = NULL;

  add_to_queue(&q, g);

  do {
    printf("%d ", q->d->id);
    if (q->d->inf == inf)
      res = q->d;
    else {
      // Пометим вершину как пройденную
      a[q->d->id] = 1;

      t = q->d->arclist;

      // Добавим в очередь все смежные с ней вершины, которые мы не обошли
      while (t != NULL)
      {
        if (!a[t->adj->id])
          add_to_queue(&q, t->adj);
        t = t->next;
      }

      // Удалим вершину из очереди
      p = q;
      q = q->next;
      free(p);
    }
  } while ((q != NULL) && (res == NULL));
  
  free_queue(&q);

  return res;
}

#define CODE 5

// Главная функция
int main(int argc, char *argv[])
{
  node *g,*p,*q;
  int *a;

  a = malloc(10*sizeof(int));

  read_graph(&g, "input.txt");
  dump_graph(g);

  q = find_node(g, 3);

  memset(a, 0, 10*sizeof(int));
  p = DFS(q, a, CODE);
  puts("");

  memset(a, 0, 10*sizeof(int));
  p = BFS(q, a, CODE);
  puts("");

  if (p != NULL)
  {
    printf("Вершина нашлась\n");
  } else {
    printf("Вершина потеряна\n");
  }
  free_graph(&g);

  free(a);
  return 0;
}

