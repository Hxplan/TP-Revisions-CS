# Vérification de Veterin'air

Compiler la solution en configuration **Debug**, puis lancer depuis la racine du dépôt :

```powershell
powershell.exe -NoProfile -STA -ExecutionPolicy Bypass -File .\Tests\Verifier-Ihm.ps1
```

Le script utilise Windows PowerShell et .NET Framework, comme l'application. Il teste les classes métiers et les vrais boutons du formulaire. Les boîtes d'erreur du processus de test sont fermées automatiquement. Un aperçu du formulaire est enregistré dans le dossier temporaire indiqué en fin d'exécution. Ces fichiers ne constituent pas un troisième projet Visual Studio.

Les vérifications couvrent la création de propriétaires, les animaux rattachés à chacun, les puces uniques, les repas compatibles et incompatibles, le vieillissement, les variations et limites de poids, les dépôts, les soins, les changements de sélection et la suppression. Les actions refusées doivent conserver les données précédentes.

## Parcours manuel

1. Ajouter un propriétaire avec un nom, un prénom et, éventuellement, un solde initial.
2. Le sélectionner dans la liste de gauche, puis créer son animal en cochant au moins un régime alimentaire.
3. Sélectionner l'animal dans le tableau pour activer ses actions.
4. Choisir le type de repas et cliquer sur **Nourrir** : carnivore +300 g, herbivore +150 g, omnivore +200 g, selon les règles du projet.
5. Saisir une quantité en grammes : **Grossir (+)** l'ajoute, **Sport (−)** la retire, **Peser (=)** remplace le poids par la valeur saisie.
6. Utiliser **Vieillir (+1)**, ou choisir une consultation puis **Soigner**. Le tarif est débité du compte ; un solde insuffisant provoque une erreur.
7. Créer un second propriétaire pour vérifier que les animaux sont bien séparés.

Pour une capture d'exception, donner un repas herbivore à un animal dont seul le régime carnivore est coché. La MessageBox doit apparaître et le poids doit rester inchangé.

Les données sont conservées en mémoire pendant la session et sont perdues à la fermeture de l'application.
