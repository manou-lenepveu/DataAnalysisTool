 Projet <<Iris Viz Stats>>
**************************

Je veux explorer la relation entre la longueur des pétales et l'espèce de l'iris afin de quantifier la probabilité de bien classer une fleur uniquement à partir de cette variable, et de visualiser à partir de cette variable, et de visualiser l'incertitude associée.

Jeu de données: 
    - Source: UCI Iris -fichier iris.data 
    - Localisation: ./data/iris.csv
    - Variables clés: petal-length, species


Usage:
    une page web unique (dashboard) accessible localement

Contraintes tehniques:
    - Stack: ASP.NET Core MVC, PostgreSQL
    - Librairies: Math.Numerics (stats)
                    Chart.js(graphiques)
    - Performance: <200 ms pour le calcul complet des stats

Livrables:
    - iris.csv nettoyé
    - Base PostgreSQL iris-db, table flowers
    - Endpoint /api/iris/stats (JSON)
    - Vue Razor Index.cshtml

Schéma SQL:

CREATE TABLE flowers (
	id SERIAL PRIMARY KEY,
	sepal_length REAL, sepal_width REAL,
	petal_length REAL, petal_width REAL,
	species TEXT
);
