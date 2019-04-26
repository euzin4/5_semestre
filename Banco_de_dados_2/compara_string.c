#include <stdio.h>
#include <string.h>

int main()
{
    char t1[] = {"<T1,A,10,20>"};
    char t2[] = {"teste"};
    int tst;

    printf("%s", t1);
    tst = strcmp(t1, t2);
    printf("\n%d", tst);
}
