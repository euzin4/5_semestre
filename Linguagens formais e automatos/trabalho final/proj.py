texto = open('gramatica.txt', 'r')	#abre o arquivo para leitura 'r'
arq = texto.readlines()				#arq vira um vetor com uma linha em cada posição
string = []

for linha in arq:					#for percorre todas as posições do vetor
	linha=linha.replace('\n','')		#retira o caractere '\n' da variavel que será printada
	linha=linha.replace('<','')
	linha=linha.replace('>','')
	linha=linha.replace(':','')
	linha=linha.replace('=','')
	linha=linha.replace('|','')
	string.extend(linha)
	print(linha)
print(string)
