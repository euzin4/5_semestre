#include <stdio.h>

int main(){
	int vet1[8]={2,13,7,31,2,52,2,7};
	int i, j, rpt=0, vet2[8];

	for(i=0; i<8; i++){
		for (j=0; j<8; ++j){
			if(vet1[i] == vet1[j]){
				rpt++;
			}
		}
		vet2[i] = rpt;
		rpt = 0;
		printf("%d repete %d vezes\n", vet1[i], vet2[i]);
	}
}
