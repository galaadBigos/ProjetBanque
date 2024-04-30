# Instruction pour lancer les projets
<a name="instruction-pour-lancer-les-projets"></a>

## Build
- Il faut installer le framework .NET 8
- Pour build les projets, il faut se mettre dans le terminal à la racine du projet (*ProjetBanque*) et faire cette commande :
```shell
dotnet build
```

## Run
Pour lancer les application, il faut se mettre dans le terminal à la racine du projet (*ProjetBanque*) et faire ces deux commandes :
```shell
dotnet run --project .\src\ProjetBanque\
dotnet run --project .\src\VirementService\
```

------------------------------------------------------------------------------------------------------------------

# Instruction pour lancer les tests

Pour lancer les tests, il faut se mettre dans le terminal à la racine projet (*ProjetBanque*) et faire ces deux commandes :
```shell
dotnet test .\tests\ProjetBanque.UnitTests\
dotnet test .\tests\VirementService.UnitTests\
```

------------------------------------------------------------------------------------------------------------------

# Jeu de données dans le DbFake

**Banques** :
- LGBD0
	- **Clients** :
		- C01210
			- **Numéros de comptes** :
				- 1250
				- 1260
		- C01260
			-  **Numéros de comptes** :
				- 1250
				- 1260
		- C01510
			-  **Numéros de comptes** :
				- 1250
				- 1260
- LGBD1
	- **Clients** :
		- C01211
			- **Numéros de comptes** :
				- 1251
				- 1261
		- C01261
			-  **Numéros de comptes** :
				- 1251
				- 1261
		- C01511
			-  **Numéros de comptes** :
				- 1251
				- 1261
- LGBD2
	- **Clients** :
		- C01212
			- **Numéros de comptes** :
				- 1252
				- 1262
		- C01262
			-  **Numéros de comptes** :
				- 1252
				- 1262
		- C01512
			-  **Numéros de comptes** :
				- 1252
				- 1262

------------------------------------------------------------------------------------------------------------------

# Utilisation de l'API

## Banque

### Pour récupérer les comptes d'un client :

Remplacer _"[[À_REMPLACER]]"_ par les datas ci-dessus : 
- http://localhost:5219/Banque/RecupererComptesParClient?nomBanque=[[À_REMPLACER]]&numeroclient=[[À_REMPLACER]]

Exemple : 
- http://localhost:5219/Banque/RecupererComptesParClient?nomBanque=LGBD2&numeroclient=C01212

### Pour récupérer les comptes d'une banque :

Remplacer _"[[À_REMPLACER]]"_ par les datas ci-dessus :
- http://localhost:5219/Banque/RecupererComptes?nomBanque=[[À_REMPLACER]]

Exemple : 
- http://localhost:5219/Banque/RecupererComptes?nomBanque=LGBD2

## Virement

### Pour faire un virement interne :

Remplacer _"[[À_REMPLACER]]"_ par les datas ci-dessus :
- http://localhost:5092/VirementInterne?nomBanqueDebiteur=[[À_REMPLACER]]&nomBanqueCrediteur=[[À_REMPLACER]]&numeroCompteDebiteur=[[À_REMPLACER]]&numeroCompteCrediteur=[[À_REMPLACER]]&somme=[[À_REMPLACER]]

Exemple : 
- http://localhost:5092/VirementInterne?nomBanqueDebiteur=LGBD2&nomBanqueCrediteur=LGBD2&numeroCompteDebiteur=1252&numeroCompteCrediteur=1262&somme=200

### Pour faire un virement externe :

Remplacer _"[[À_REMPLACER]]"_ par les datas ci-dessus :
- http://localhost:5092/VirementExterne?nomBanqueDebiteur=[[À_REMPLACER]]&nomBanqueCrediteur=[[À_REMPLACER]]&numeroCompteDebiteur=[[À_REMPLACER]]&numeroCompteCrediteur=[[À_REMPLACER]]&somme=[[À_REMPLACER]]

Exemple : 
- http://localhost:5092/VirementExterne?nomBanqueDebiteur=LGBD1&nomBanqueCrediteur=LGBD2&numeroCompteDebiteur=1251&numeroCompteCrediteur=1262&somme=200
