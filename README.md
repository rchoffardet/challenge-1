# Le challenge 

## Introduction

A l'origine, ce challenge est un moyen pour résoudre un différent entre deux parties.  
La première pense que le C++ est imbatable en terme de performance brute.   
La seconde pense qu'elle peut faire mieux que la première en C#.

Face à l'impossibilité de se mettre d'accord, une seule solution :

![C'est l'heure du du-du-du-duel](./duel.gif)

## Les règles
- Respecter le contrat
- Amusez-vous et que Le plus rapide, gagne ! ([Le script de benchmark fait foi](./benchmark/))

## Le contrat
A partir d'une liste de personnes et d'une liste des relations entre ces personnes, votre programme doit déterminer le dégré de la relation entre deux personnes :
- S'il existe une relation directe entre les deux personnes, il s'agit d'une relation au degré `1`.  
- Si la relation existe via un intermédiaire c'est une relation au degré `2`.  
- Avec deux intermédiaires, c'est une relation au degré `3`, etc. 
- Une relation envers soi-même est considéré comme étant de degré `0`
- Une relation inexistante est considéré de degré `-1`.

### Entrée/Sorties
Dans le même répertoire que le programme seront placés tour à tour, les fichiers des différents [datasets](/datasets/). 

Le nom des personnes sera passés en deux arguments, chacun entourée de guillemet. Le degré de la relation resolue devra être retourné dans la sortie standard. 

Un exemple d'appel et de la réponse :

```bash
duel.exe "vector" "captain spic"
3
```
Lors du benchmark, les différentes recherches pré-configurées dans le fichier `search.txt` serviront à contrôler le résultat et à mesurer les performances. Vous pouvez les utiliser librement pour tester votre programme.  

Les données doivent être ré-importées à chaque appel du programme.

### Build
Afin de simplifier le benchmark, les instructions de build doivent être données. Dans l'idéal, il serait bien qu'il soit automatisé via un script et qu'il produise le résutat dans un dossier `dist`.

Le build ne doit produire qu'un seul fichier qui doit être exécutable.

### Le Benchmark

Le benchmark sera exécuté sur ma machine :
```txt 
Système: Windows 11
Processeur: i7-8700K  
RAM: 4x8 Go DDR4 2800 C16
Disque: SanDisk Ultra II 960GB
```
Je ferais au mieux pour réduire au maximum l'activité sur la machine pour éviter de polluer le benchmark. 

## Soumission au challenge

Les soumissions se font via les [issues du projet](https://github.com/rchoffardet/challenge-1/issues). Ils peuvent être sous la forme d'une adresse faire un repository ou d'une archive.