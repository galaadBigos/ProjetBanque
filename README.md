## Build
- Il faut installer le framework .NET 8
- Pour build les projets, il faut se mettre dans le terminal à la racine du projet (*ProjetBanque*) et faire cette commande :
```shell
dotnet build
```

## Faire les appels à l'API 
### Datas
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
### Banque
**Pour récupérer les comptes d'un client :**

Remplacer \[\[ÀREMPLACER]] par les datas ci-dessus :
http://localhost:5219/Banque/RecupererComptesParClient?nomBanque=[[ÀREMPLACER]]&numeroclient=[[ÀREMPLACER]]

Exemple : http://localhost:5219/Banque/RecupererComptesParClient?nomBanque=LGBD2&numeroclient=C01212

**Pour récupérer les comptes d'une banque :**

Remplacer \[\[ÀREMPLACER]] par les datas ci-dessus :
http://localhost:5219/Banque/RecupererComptes?nomBanque=[[ÀREMPLACER]]

Exemple : http://localhost:5219/Banque/RecupererComptes?nomBanque=LGBD2

### Virement
**Pour faire un virement interne :**

Remplacer \[\[ÀREMPLACER]] par les datas ci-dessus :
http://localhost:5092/VirementInterne?nomBanqueDebiteur=[[ÀREMPLACER]]&nomBanqueCrediteur=[[ÀREMPLACER]]&numeroCompteDebiteur=[[ÀREMPLACER]]&numeroCompteCrediteur=[[ÀREMPLACER]]&somme=[[ÀREMPLACER]]

Exemple : http://localhost:5092/VirementInterne?nomBanqueDebiteur=LGBD2&nomBanqueCrediteur=LGBD2&numeroCompteDebiteur=1252&numeroCompteCrediteur=1262&somme=200

**Pour faire un virement externe :**

Remplacer \[\[ÀREMPLACER]] par les datas ci-dessus :
http://localhost:5092/VirementExterne?nomBanqueDebiteur=[[ÀREMPLACER]]&nomBanqueCrediteur=[[ÀREMPLACER]]&numeroCompteDebiteur=[[ÀREMPLACER]]&numeroCompteCrediteur=[[ÀREMPLACER]]&somme=[[ÀREMPLACER]]

Exemple : http://localhost:5092/VirementExterne?nomBanqueDebiteur=LGBD1&nomBanqueCrediteur=LGBD2&numeroCompteDebiteur=1251&numeroCompteCrediteur=1262&somme=200
